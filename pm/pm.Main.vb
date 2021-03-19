

Public Class pm
    Public WithEvents chkDefPrinter As New fancyListbox

    ' Data Structures
    Public dsData As New DataSet("pm") ' Master Data
    Public dtPrinters As DataTable = dsData.Tables.Add("Printers") ' Printer Table
    public dtTree As DataTable = dsData.Tables.Add("Tree") ' The tree data

    Public dsUserData As New DataSet("pm.User")
    Public dtUserPrinters As DataTable = dsUserData.Tables.Add("Printers")
    Public dtTempList As DataTable = dsUserData.Tables.Add("tmpPrinterList")
    Public version As String = ".01"

    ' Program Settings
    Public bUnsavedData As Boolean = False
    Public bUnsaved_UserData As Boolean = False
    Public bUnsaved_PMData As Boolean = False
    Public bBuildingTree As Boolean = False
    Public AttemptingToClose As Boolean = False

    Public userMode As String = "User"
    Public bCreateAndExit As Boolean = False
    Public bDebug As Boolean = False
    Public ForceUserFile As Boolean = False
    Public ForceConfigFile As Boolean = False
    Public SaveUserOnExit As Boolean = False
    Public SaveConfigOnExit As Boolean = False

    Public preventConfigOpen As Boolean = False
    Public preventSettingsOpen As Boolean = False

    Public DefaultPrintServer As String = ""

    ' Global Options
    Public PrinterFile As String = ""
    Public UserFile As String = ""
    Public defPrinterName As String = ""
    Public defPrinterPath As String = ""
    Public createPrintersOnExit As Boolean = True

    Public Security As New Security

    ' Debug Variables
    Public dbg As New debug


    Private Sub pm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not AttemptingToClose Then
            log("pm is closing")
            If Not AttemptToClose(True) Then
                e.Cancel = True
            Else
                Connect_Printers()
            End If


        End If

    End Sub ' pm.Close Event

    Private Sub pm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        log("Initializing pm")
        Me.Visible = False

        ' Set the title bar with the computer name.
        Me.Text = Me.Text + " on " & System.Net.Dns.GetHostName

        ' Force the debug window close at start.  We don't want to see it 
        ' unless we choose it.
        If bDebug Then
            dbg.Visible = True
        Else
            dbg.Visible = False
        End If

        ' Build the Data Tables
        log("  Building Data Tables")
        log("    Printer List")

        ' dtPrinters.Columns.Add("Checked", GetType(Boolean))
        dtPrinters.Columns.Add("Name")
        dtPrinters.Columns.Add("Share")
        dtPrinters.Columns.Add("Path")
        dtPrinters.Columns.Add("Message")
        dbg.dtaPrinters.DataSource = dtPrinters

        log("    Treeview Data")
        dtTree.Columns.Add("Configuration")

        log("    User Configuration Settings")
        dtUserPrinters.Columns.Add("Default", GetType(Boolean))
        dtUserPrinters.Columns.Add("Name")
        dtUserPrinters.Columns.Add("Share")
        dtUserPrinters.Columns.Add("Path")
        dbg.dtaUserSettings.DataSource = dtUserPrinters

        log("    Temporary Data")
        dtTempList.Columns.Add("Name")
        dtTempList.Columns.Add("Path")

        ' Configure Misc Controls
        unSavedData(bUnsavedData)

        ' Process Command Lines       
        ProcessCommandLineArguments()

        ' Finish Initialising the program based on the command line information
        ' Also, check the .config file to see if anything has been added, but 
        ' command line will override the .config file.
        loadStartupData()
        Security.ModeChange(userMode)

        ' Check to see if we need to display the main form.
        If bCreateAndExit Then
            Me.Visible = False
        Else
            Me.Visible = True
        End If

        ' Configure the controls on the form.
        If preventConfigOpen Then
            If userMode.ToLower <> "admin" Then fileLoadPrinter.Visible = False
            log("  PreventConfigOpen: Disable open user config file")
        End If

        If preventSettingsOpen Then
            If userMode.ToLower <> "admin" Then fileOpenUserConfig.Visible = False
            log("  PreventSettingsOpen: Disable open pm.config file")
        End If

        ' Regiser HotKeys
        log("  Regisering Hotkeys")
        log("     Alt+A")
        pmHotKey.RegisterHotKey(Me, 1, "A", pmHotKey.KeyModifier.Alt)

        log("     Alt+C")
        pmHotKey.RegisterHotKey(Me, 3, "C", pmHotKey.KeyModifier.Alt)

        log("     Alt+D")
        pmHotKey.RegisterHotKey(Me, 4, "D", pmHotKey.KeyModifier.Alt)

        log("     Alt+D")
        pmHotKey.RegisterHotKey(Me, 5, "E", pmHotKey.KeyModifier.Alt)

        ' Add the fancylistbox to the group box on the main form.
        grpPrinters.Controls.Add(chkDefPrinter)
        chkDefPrinter.Sorting = SortOrder.Ascending

        log("pm.Initialised")

        ' Check to see if we need to creat printers and exit.
        ' if we do, we'll call connect and then terminate the program
        If bCreateAndExit Then
            Connect_Printers()
            Me.Close()
        End If



    End Sub ' pm.Load Event





    ' Debug Events
    ' These events are added to facilitate debugging.
    ' ==========================================================================================================
    Private Sub DebugWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebugWindowToolStripMenuItem.Click
        toggleDebug()
    End Sub
    Private Sub SwitchModesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModeChange.Click
        log("DEBUG: Changing Operation Mode")
        Select Case userMode
            Case Is = "Admin"
                Security.ModeChange("User")
            Case Is = "User"
                Security.ModeChange("Admin")
            Case Else
                Security.ModeChange("User")
        End Select
    End Sub
    Private Sub UnsavedDataToggleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxUnsavedData.Click
        log("DEBUG: Enabling all unsaved data flags")
        pmCode.unSavedData(True, "pm")
        pmCode.unSavedData(True, "user")

    End Sub

    ' treePrinters Events
    ' This control maintains a list of paths that are available to the user.  They are saved and loaded 
    ' from a printer manager configuration file, or PMC file.
    ' ==========================================================================================================
    Private Sub treePrinters_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles treePrinters.MouseDown
        ' ======================================================
        ' Security: Check to see if the user has permissions to 
        '           display the context menu on this object.
        ' ======================================================
        If Not Security.canSeeFolderContextMenu Then
            log("Local security is preventing the Folder Context menu from being displayed")
            Exit Sub
        End If


        ' Check to see if the button that was pressed was the right mouse button
        If e.Button = MouseButtons.Right Then
            ' Create a new POINT object and grab the tree node at this point
            Dim p As Point = New Point(e.X, e.Y)
            Dim node As TreeNode = treePrinters.GetNodeAt(p)

            ' Check to see if we clicked on a specific node, or in the root space.
            If Not node Is Nothing Then
                ' The selected point is a node.  We will configure the context menu
                ' and show it, as well as selecting the node itself.
                ctxAdminFolderNew.Enabled = True
                ctxAdminFolderRemove.Enabled = True
                ctxAdminPrinters.Enabled = True

                treePrinters.SelectedNode = node
                ctxTree.Show(treePrinters, p)
                p = Nothing
                log("Right click on : " & treePrinters.SelectedNode.FullPath.ToString)
            Else
                ' The selected point is not a node.  We will configure the context menu
                ' and show it.
                ctxAdminFolderNew.Enabled = True
                ctxAdminFolderRemove.Enabled = False
                ctxAdminPrinters.Enabled = False
                ctxTree.Show(treePrinters, p)
                p = Nothing
                log("Right clicked in empty space on the tree")
            End If
        End If
    End Sub
    Private Sub treePrinters_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treePrinters.AfterSelect
        UpdatePrinterList()
    End Sub

    ' chkPrinters Events
    ' This control maintains a list of printers based on the path selected in the tree control(treePrinters)
    ' The data for this control is loaded and saved in a printer management user file, or PMU file.  The data
    ' itself is loaded into a dataset so it can be manipulated on the fly.
    ' ==========================================================================================================
    Private Sub chkDefPrinter_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkDefPrinter.ItemCheck
        ' Check to see if we're building the tree.  If we are, then we don't need to process anything in this list.
        If bBuildingTree Then Exit Sub


        Select Case e.NewValue
            Case CheckState.Unchecked
                
                ' We need to check to see if the printer is the users default.
                ' If this box is checked, changing to unchecked, AND it's the default printer: we need to abort.
                Dim defPrinter = (defPrinterPath & "\" & defPrinterName).ToLower
                Dim selPrinter = (treePrinters.SelectedNode.FullPath & "\" & chkDefPrinter.Items(e.Index).Text).ToLower

                If defPrinter = selPrinter Then
                    MsgBox("This printer is currently your default printer.  You can not remove it until you select another one.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "pm.Error:")
                    e.NewValue = CheckState.Checked                    
                    Exit Sub
                End If

                ' User has removed the check mark from a printer in the users list.
                ' We need to remove it from the users table
                RemoveUserPrinter(chkDefPrinter.Items(e.Index).Text, treePrinters.SelectedNode.FullPath)

            Case CheckState.Checked
                ' The user has put a check mark in the box next to a printer.
                ' We need to perform some logic and add it to the users data table if it meets our criteria.

                Try
                    For checkUSersPrinters = 0 To dtUserPrinters.Rows.Count - 1
                        ' Loop through each printer in the list
                        ' Grab one row at a time.
                        Dim chkPtr As DataRow = dtUserPrinters.Rows(checkUSersPrinters)

                        ' Check to see if the name of the printer that we're currently on
                        ' matches the name of the printer that we have selected.
                        If chkPtr("Name").ToString.ToLower = chkDefPrinter.Items(e.Index).Text.ToString.ToLower Then

                            ' The name matches the printer.  This means that we have a printer in our users list
                            ' that matches the one we've selected.  Since printers can have the same names as long
                            ' as they are in different paths, we'll go ahead and check the path, too.  If the paths
                            ' are the same, then we don't need to do anything becuase this printer is already in the
                            ' users list of printers.
                            If chkPtr("Path").ToString.ToLower = treePrinters.SelectedNode.FullPath.ToLower Then
                                Exit Sub
                            End If
                        End If
                    Next
                Catch ex As Exception
                    log("  An unknown error occurred")
                    log("    a.  User clicked on a printer (" & chkDefPrinter.Items(e.Index).Text & ")")
                    log("    b.  pm Was attempting to see if the printer was already in the users list.")
                    log("    c.  Error occurred.")
                    log(ex.Message)
                End Try


                ' The printer does not exist the users list.  We will now add it.                
                log("Selected Printer: " & chkDefPrinter.Items(e.Index).Text)

                ' We need to grab the share from the main
                Dim tmpShare As String = printers_getShareName(chkDefPrinter.Items(e.Index).Text, treePrinters.SelectedNode.FullPath)

                AddUserPrinter(chkDefPrinter.Items(e.Index).Text, tmpShare, treePrinters.SelectedNode.FullPath, False)
                Exit Sub

            Case Else
                log("The printer checkbox is in an inconsistant state and pm could not check or uncheck the box properly.")
        End Select
    End Sub    
    Private Sub chkDefPrinters_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkDefPrinter.MouseDown
        ' ======================================================
        ' Security: Check to see if the user has permissions to 
        '           display the context menu on this object.
        ' ======================================================
        If Not Security.canSeePrinterContextMenu Then
            log("Local Security is preventing the Printer context menu from being displayed")
            Exit Sub
        End If

        If e.Button = MouseButtons.Right Then
            ' Get the point where the mouse was clicked        
            Dim p As Point = New Point(e.X, e.Y)

            ' Determine what was clicked on.  If it was an item in the list, 
            ' make sure it's selected.
            Dim iSelected As Integer = chkDefPrinter.IndexFromPoint(p)


            If iSelected > -1 Then
                ' User clicked on an item in the list
                ' Select the item that the user clicked on
                chkDefPrinter.SelectedIndex = iSelected

                ' Customize the context menu
                ctxAdminAddPrinter.Visible = True
                ctxAdminRemovePrinter.Visible = True
                ctxSetDefaultPrinter.Enabled = True
                ctxSetDefaultPrinter.Text = "Set Default Printer: " & chkDefPrinter.SelectedItem.text
                log("Right clicked on: " & chkDefPrinter.Items(iSelected).Text)

            Else
                ' User clicked on blank space

                ' Customize the context menu
                ctxAdminAddPrinter.Visible = True
                ctxAdminRemovePrinter.Visible = False
                ctxSetDefaultPrinter.Text = "Set Default Printer: <none selected>"
                ctxSetDefaultPrinter.Enabled = False
            End If


            log("Display Context Menu for Printers")
            ctxPrinters.Show(chkDefPrinter, p)

            p = Nothing
        End If
    End Sub
    


    ' Menu Events
    ' These events control what happens when a user clicks on a menu.
    ' ==========================================================================================================
    Private Sub LoadPrinterFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fileLoadPrinter.Click
        ' ======================================================
        ' Security: Check to see if the user has permissions to 
        '           add a new printer
        ' ======================================================
        If Not Security.canLoadConfigFile Then
            log("Error: User does not have access to load the configuration file")
            MsgBox("Error: You do not have access to load the configuration file", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "pm.Error: Load Config File")
            Exit Sub
        End If


        log("Load Printer Configuration Requested")
        ' Check for any unsaved data
        If bUnsavedData Then
            Select Case MsgBox("You currently have unsaved data.  If you load a configuration file, you will loose all of this unsaved data." & vbCrLf & vbCrLf & _
                               "Do you still want to load a configuration file?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "pm.Question")
                Case MsgBoxResult.No
                    log("  User had unsaved data and requested to cancel load operation")
                    Exit Sub
            End Select
        End If

        log("  Prompting for Filename")

        ' Check to make sure we're getting a good filename
        If inFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            log("  User Canceled Load Operation")
            Exit Sub
        End If

        If inFile.FileName = "" Then
            log("  User provided a blank name.  Must abort.")
            Exit Sub
        End If


        If inFile.CheckFileExists Then
            OpenPrinterConfigFile(inFile.FileName)
        Else
            MsgBox("The file could not be loaded becuase it did not exist.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: File Open")
        End If
    End Sub
    Private Sub SavePrinterFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fileSavePrinter.Click
        ' ======================================================
        ' Security: Check to see if the user has permissions to 
        '           add a new printer
        ' ======================================================
        If Not Security.canSaveConfigFile Then
            log("Error: User does not have access to save the pm.Configuration file")
            MsgBox("Error: You do not have access to save the pm.Configuration file", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "pm.Error: Save Config File")
            Exit Sub
        End If

        log("Preparing to Save Configuration Data")
        log("  Refreshing all the data so no stale data is saved")

        ' Make sure we're getting a good filename before we move on...
        If ForceConfigFile Then
            log("  ForceConfigFile Enabled: Calling save to " & PrinterFile)
            SavePrinterConfigFile(PrinterFile)

        Else
            If outFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                log("  Canceled at user's request.")
                Exit Sub
            End If

            If outFile.FileName = "" Then
                log("  Filename was blank, aborting.")
                Exit Sub
            End If

            SavePrinterConfigFile(outFile.FileName)

        End If




    End Sub
    Private Sub mnuConnectPrinters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConnectPrinters.Click
        log("Clicked Menu Option to Connect Printers")
        Connect_Printers()
    End Sub
    Private Sub ctxSaveUserConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fileSaveUserConfig.Click
        ' ======================================================
        ' Security: Check to see if the user has permissions to 
        '           add a new printer
        ' ======================================================
        If Not Security.canSaveUserFile Then
            log("Error: User does not have access to save their settings")
            MsgBox("Error: You do not have access to save changes to your configuration file", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "pm.Error: Save User File")
            Exit Sub
        End If

        If ForceUserFile Then
            log("  ForceUserFile Enabled: Calling save to " & UserFile)
            SaveUserFile(UserFile)
        Else

            ' Show the save file dialog and make sure we got a good response.
            If oUserFile.FileName <> "" Then sUSerFile.FileName = oUserFile.FileName
            sUSerFile.Filter = "pm User Configuration Files (*.pmu)|*.pmu|All Files (*.*)|*.*"

            If sUSerFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                log("User canceled save operation")
                Exit Sub
            End If

            If sUSerFile.FileName = "" Then
                log("User entered a blank filename when attempting to save.")
                Exit Sub
            End If
        End If


    End Sub
    Private Sub OpenUserConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fileOpenUserConfig.Click
        ' ======================================================
        ' Security: Check to see if the user has permissions to 
        '           add a new printer
        ' ======================================================
        If Not Security.canLoadUserFile Then
            log("Error: User does not have access to load a configuration file")
            MsgBox("Error: You do not have access to load a configuration file", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "pm.Error: Open User File")
            Exit Sub
        End If

        ' Show the open file dialog and make sure we got a good response.
        If oUserFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            log("User canceled open operation")
            Exit Sub
        End If

        If oUserFile.FileName = "" Then
            log("User entered a blank filename when attempting to load.")
            Exit Sub
        End If

        OpenUserFile(oUserFile.FileName)
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        AttemptToClose(False)
    End Sub
    Private Sub ctxAdminPrinterNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAdminPrinterNew.Click
        ' ======================================================
        ' Security: Check to see if the user has permissions to 
        '           add a new printer
        ' ======================================================
        If Not Security.canAddPrinter Then
            log("Error:  Access Denied while attempting to add a new printer")
            MsgBox("Error: Access Denied", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "pm.Error: Add New Printer")
            Exit Sub
        End If
        Show_AddNewPrinterDialog()        
    End Sub
    Private Sub ctxAdminAddPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAdminAddPrinter.Click
        ' ======================================================
        ' Security: Check to see if the user has permissions to 
        '           add a new printer
        ' ======================================================
        If Not Security.canAddPrinter Then
            log("Error:  Access Denied while attempting to add a new printer")
            MsgBox("Error: Access Denied", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "pm.Error: Add New Printer")
            Exit Sub
        End If
        Show_AddNewPrinterDialog()
    End Sub
    Private Sub ctxAdminRemovePrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAdminRemovePrinter.Click
        RemoveSystemPrinter(chkDefPrinter.SelectedItem.text, treePrinters.SelectedNode.FullPath.ToString)
        UpdatePrinterList()
    End Sub
    Private Sub ctxAdminFolderNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAdminFolderNew.Click
        ' ======================================================
        ' Security: Check to see if the user has permissions to 
        '           add a new printer
        ' ======================================================
        If Not Security.canAddFolder Then
            log("Error: Access Denied while attempting to add a new printer")
            MsgBox("Error: Access Denied", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "pm.Error: Remove Folder")
            Exit Sub
        End If
        If treePrinters.SelectedNode Is Nothing Then
            AddNewFolder("")
        Else
            AddNewFolder("", treePrinters.SelectedNode.FullPath.ToString)
        End If
    End Sub
    Private Sub ctxAdminFolderRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAdminFolderRemove.Click
        ' ======================================================
        ' Security: Check to see if the user has permissions to 
        '           add a new printer
        ' ======================================================
        If Not Security.canRemoveFolder Then
            log("Error: Access Denied while attempting to remove a folder")
            MsgBox("Error: Access Denied", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "pm.Error: Remove Folder")
            Exit Sub
        End If

        log("Removing Folder:")
        ' Exit the sub if we don't have a node selected
        If treePrinters.SelectedNode Is Nothing Then
            log("  Attempt to remove a folder without selecting a node.")
            Exit Sub
        End If


        Select Case MsgBox("If you remove a folder, all printers and folders underneath it will also be removed." & vbCrLf & vbCrLf & "Delete Folder: " & treePrinters.SelectedNode.FullPath.ToString, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "pm.Question")
            Case Is = MsgBoxResult.No
                log("User did not agree to terms of folder deletion.")
                log("Remove Folder Aborted")
                Exit Sub
            Case Else
                log("User agreed to terms of folder deletion")
        End Select

        ' Remove the folder
        removeFolder(treePrinters.SelectedNode.FullPath.ToString)
        UpdatePrinterList()

    End Sub
    Private Sub ctxSetDefaultPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxSetDefaultPrinter.Click
        log("Setting Default Printer")
        ' If we're setting a default printer, then we need to make sure it's going to get added
        ' to the users configuration data.

        Dim item As ListViewItem = chkDefPrinter.SelectedItem
        If Not item.Checked Then item.Checked = True
       

        'Dim ndx As Integer = chkDefPrinter.Items.IndexOf(chkDefPrinter.SelectedItem)
        'chkDefPrinter.setItemChecked(ndx, True)
        'chkDefPrinter.setItemChecked(chkPrinters.Items.IndexOf(chkDefPrinter.SelectedItem), True)
       

        SetDefaultPrinterAction(chkDefPrinter.SelectedItem.text, treePrinters.SelectedNode.FullPath)
        UpdatePrinterList()


    End Sub
    Private Sub pm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        grpPrinters.Width = Me.Width - 36
        grpPrinters.Height = Me.Height - (27 * 2) - 40

        treePrinters.Left = 6
        treePrinters.Width = (grpPrinters.Width / 2) - 15
        treePrinters.Height = grpPrinters.Height - 24 - 26

        cmdConnect.Width = 161
        cmdConnect.Height = 23


        chkDefPrinter.Top = treePrinters.Top
        chkDefPrinter.Left = 24 + treePrinters.Width
        chkDefPrinter.Width = treePrinters.Width
        chkDefPrinter.Height = treePrinters.Height

        cmdConnect.Top = chkDefPrinter.Top + chkDefPrinter.Height + 3
        cmdConnect.Left = (chkDefPrinter.Left + chkDefPrinter.Width) - cmdConnect.Width
    End Sub


    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = pmHotKey.WM_HOTKEY Then
            pmHotKey.handleHotKeyEvent(m.WParam)
        End If
        MyBase.WndProc(m)
    End Sub 'System wide hotkey event handling


    Private Sub mnuUnsavedUserData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUnsavedUserData.Click
        pmCode.unSavedData(False, "user")
    End Sub
    Private Sub ShowDebugWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowDebugWindowToolStripMenuItem.Click
        ToggleDebug()
    End Sub
    Private Sub pmUnsavedConfigData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pmUnsavedConfigData.Click
        pmCode.unSavedData(False, "pm")
    End Sub
    Private Sub ctxEditPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEditPrinter.Click
        show_EditPrinterDialog()
    End Sub

 


    
    


    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        Connect_Printers()
    End Sub
End Class
