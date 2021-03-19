Imports System.Printing

Module pmPrinterFunctions
    ' -------------------------------------------------------------------------------------
    ' Printer Functions
    ' -------------------------------------------------------------------------------------
    ' These functions manage actionst hat are done with printers.  Any windows event that
    ' triggers a printer function should be redirected to a call to a function in this 
    ' module.  Printer functions that maniuplate data in the data sets/ data tables are
    ' not in this module, they are in pmDataFunctions.
    ' -------------------------------------------------------------------------------------
    ' [%  ] [Function Name]             [Purpose]
    ' [100] SetDefaultPrinter           Sets a users default printer in the users config
    ' [100] AddNewFolder                Adds a new folder to the Printer Tree
    ' [100] Remove Folder               Removes a folder from the printer tree
    ' [100] show_AddNewPrinterDialog    Displays the add new printer window
    ' [100] UpdatePrinterList           Updates the printer list using the path in the tree
    ' [100] ConnectPrinters             Inits a process that connects all selected printers
    ' [100] MakeDefaultPrinter          Makes a printer the default printer in the session
    ' [100] MapPrinter                  Connects to a network printer
    ' -------------------------------------------------------------------------------------

    Function SetDefaultPrinterAction(ByVal Name As String, ByVal Path As String)
        Dim bFoundNode As Boolean = False
        Dim bFoundPrinter As Boolean = False
        Dim bUserHasPrinter As Boolean = False

        log("Setting Default Printer")
        log("  Looking at printer nodes: " & pm.treePrinters.Nodes.Count)
        Try
            log("  Checking to make sure the tree node is loaded")

            Dim tn As TreeNode = Treeview_Search(Path, pm.treePrinters.Nodes, False, True)
            If Not tn Is Nothing Then
                log("    Found Node:" & tn.Text)
                bFoundNode = True
            End If
            tn = Nothing

            If Not bFoundNode Then
                log("    User has a default printer that appears to not exist.")
                log("      Please make sure the Printer list is loaded before the user data!")
                log("      If you load the user configuration before the configuration, pm does")
                log("      not know about the printers in the users configuration file!")
                log("      This is a non-critical error but you may experience problems later.")
            End If
            

        Catch ex As Exception
            log("    An unknown error occurred")
            log("    Function : pmPrinterFunctions.SetDefaultPrinter(" & Name & ", " & Path & ")")
            log("    Operation: Check to make sure the path is valid")
            log(ex.Message)
        End Try



        Try
            ' Verify the printer exists in the specified path
            log("  Checking Name and path to make sure user has this printer")
            For check As Integer = 0 To pm.dtPrinters.Rows.Count - 1
                Dim ptr As DataRow = pm.dtPrinters.Rows(check)
                If ((ptr("Path").ToString.ToLower = Path.ToLower) And (ptr("Name").ToString.ToLower = Name.ToLower)) Then
                    bFoundPrinter = True
                    log("    The path was found in the tree")
                    Exit For
                End If
            Next

            If Not bFoundPrinter Then
                log("    User has a default printer that appears to not exist.")
                log("      Please make sure the Printer list is loaded before the user data!")
                log("      If you load the user configuration before the configuration, pm does")
                log("      not know about the printers in the users configuration file!")
                log("      This is a non-critical error but you may experience problems later.")
            End If
            
        Catch ex As Exception
            log("    An unknown error occurred")
            log("    Function : pmPrinterFunctions.SetDefaultPrinter(" & Name & ", " & Path & ")")
            log("    Operation: Verify printer exists in path")
            log(ex.Message)
        End Try



        Try
            ' Verify the Printer exist in the user space
            log("  Checking to see if user has the printer loaded")
            For check As Integer = 0 To pm.dtUserPrinters.Rows.Count - 1
                Dim ptr As DataRow = pm.dtUserPrinters.Rows(check)
                If ((ptr("Path").ToString.ToLower = Path.ToLower) And (ptr("Name").ToString.ToLower = Name.ToLower)) Then
                    bUserHasPrinter = True
                    log("    The user has the printer in their list")
                    Exit For
                End If
            Next

            If Not bUserHasPrinter Then
                log("    User has a default printer that appears to not exist.")
                log("      Please make sure the Printer list is loaded before the user data!")
                log("      If you load the user configuration before the configuration, pm does")
                log("      not know about the printers in the users configuration file!")
                log("      This is a non-critical error but you may experience problems later.")
            End If

        Catch ex As Exception
            log("    An unknown error occurred")
            log("    Function : pmPrinterFunctions.SetDefaultPrinter(" & Name & ", " & Path & ")")
            log("    Operation: The user has this printer in their user configuration data")
            log(ex.Message)
        End Try




        ' Set the default printer in the data set
        ' Start by removing all default printers...
        Try

            pm.defPrinterName = Name
            pm.defPrinterPath = Path
            pm.dbg.txtDefPrinter.Text = pm.defPrinterPath & "\" & pm.defPrinterName
            pm.status.Text = "Default Printer: " & pm.defPrinterName
            SetDefaultPrinter(pm.defPrinterName, pm.defPrinterPath)

            pm.status.Text = "Default Printer: " & pm.defPrinterName
            Return True

        Catch ex As Exception
            pm.defPrinterName = Name
            pm.defPrinterPath = Path
            pm.dbg.txtDefPrinter.Text = "<none>"
            pm.status.Text = "Default Printer: "

            MsgBox("pm Encountered an error while attempting to set the default printer." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Set Default Printer")

            Return False
        End Try


    End Function

    Function Show_AddNewPrinterDialog()   
        ' Check to see if a tree node is selected.  If we don't have one, we can't add a printer.
        If pm.treePrinters.SelectedNode Is Nothing Then
            MsgBox("Before you add a printer, you must select a node in the tree.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Add Printer")
            log("Attempted to add a printer without selecting a node.")
            Return False
        End If

        log("Showing new printer dialog")
        Try
            Dim newPrinterDialog As New newPrinter
            newPrinterDialog.txtPath.Text = pm.treePrinters.SelectedNode.FullPath.ToString
            newPrinterDialog.Show()
            Return True
        Catch ex As Exception
            MsgBox("pm Attempted to add a printer to the list, but failed." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Update Printer List")
            Return False
        End Try


    End Function
    Function Update_UserPrinter(ByVal oName As String, ByVal oShare As String, ByVal oPath As String, ByVal Name As String, ByVal Share As String, ByVal Path As String)
        Try
            For i As Integer = 0 To pm.dtUserPrinters.Rows.Count - 1
                Dim ptr As DataRow = pm.dtUserPrinters.Rows(i)

                If ptr("Name").ToString.ToLower = oName.ToLower Then
                    If ptr("Share").ToString.ToLower = oShare.ToLower Then
                        If ptr("Path").ToString.ToLower = oPath.ToLower Then
                            log("Printer information changed: Updating users configuration")
                            ptr("Name") = Name
                            ptr("Share") = Share
                            ptr("Path") = Path
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("pm Encoutnered an error while attempting to update the user printer." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Update User Printer")
            Return False
        End Try
        Return True
    End Function

    Function AddNewFolder(Optional ByVal FolderName As String = "", Optional ByVal Path As String = "")

        ' We're adding a new folder.  Log what we know for reference later.
        log("Adding a new Folder")
        log("  New Folder Name: " & FolderName)
        log("  New Folder Path: " & Path)

        ' Get the new folder name.  Exit the sub if nothing is entered.
        If FolderName = "" Then
            FolderName = InputBox("Please enter the name of the folder you wish to create:", "Printer Management: New folder", FolderName)

            ' Check to see if we got a folder name
            If FolderName = "" Then
                log("User did not enter a folder name when requested.")
                Return False
            End If
        End If

        ' Check to see where the node should be created.
        ' If the there is not a node selected, we'll create the 
        ' node under the root node.
        If pm.treePrinters.SelectedNode Is Nothing Then
            pm.treePrinters.Nodes.Add(New TreeNode(FolderName, 1, 2))
            unSavedData(True, "pm")
            log(" Folder Created: " & FolderName)
        Else
            pm.treePrinters.SelectedNode.Nodes.Add(New TreeNode(FolderName, 1, 2))
            pm.treePrinters.SelectedNode.Expand()
            unSavedData(True, "pm")
            log("  Folder Created: " & FolderName)
        End If

        ' sort the tree
        pm.treePrinters.BeginUpdate()
        pm.treePrinters.Sort()
        pm.treePrinters.EndUpdate()
        log("Sorted Tree")
        Return True
    End Function
    Function removeFolder(ByVal path As String)
        log("  Remove Folder: " & path)
        Try
            ' Loop through all printers and remove all printers that match this folder:
            For dCounter As Integer = pm.dtPrinters.Rows.Count - 1 To 0 Step -1
                Dim dPrinter As DataRow = pm.dtPrinters.Rows(dCounter)
                Dim bufCurName As String = dPrinter("Name")
                Dim bufCurPath As String = dPrinter("Path").tolower

                If bufCurPath.StartsWith(LCase(path)) Then
                    log("  Removing Printer: " & bufCurPath & "\" & dPrinter("Name"))
                    pm.dtPrinters.Rows.Remove(dPrinter)
                End If

            Next

            ' Remove the node from the tree
            pm.treePrinters.SelectedNode.Remove()

            unSavedData(True, "pm")
            Return True

        Catch ex As Exception
            MsgBox("ERROR: Attempt to remove printer folder failed." + vbCrLf + vbCrLf + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Remove Folder")
            Return False
        End Try
    End Function

    Public Function UpdatePrinterList()
        ' ========================================
        ' Display printers in this tree nodes path
        ' ========================================
        ' Inform pm that we're building the tree
        pm.bBuildingTree = True

        ' Clear the existing printers from the check box
        pm.chkDefPrinter.Items.Clear()

        ' If there is not a selected node, something went wrong and we'll exit.  This really should
        ' never happen.
        If pm.treePrinters.SelectedNode Is Nothing Then
            Return False
        End If



        ' Grab all the printers in the users datatable that match the path.  Store them in our temporary
        ' datatable.  This will make large queries faster than querying the main datatable.
        Try
            pm.dtTempList.Clear()
            For populate = 0 To pm.dtUserPrinters.Rows.Count - 1
                Dim ptr As DataRow = pm.dtUserPrinters.Rows(populate)
                If ptr("Path").ToString.ToLower = pm.treePrinters.SelectedNode.FullPath.ToLower Then
                    ' Printer is a match -- add it to the temporary list
                    Dim newPtr As DataRow = pm.dtTempList.NewRow
                    newPtr("Name") = ptr("Name")
                    newPtr("Path") = ptr("Path")
                    pm.dtTempList.Rows.Add(newPtr)
                    ptr = Nothing
                End If
            Next
        Catch ex As Exception
            MsgBox("pm Encoutnered an error while attempting to add the printer to the user configuration." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Update Printer List")
            Return False
        End Try


        ' Loop through the printers in our datatable and display the the ones that are in this path.
        Try
            For check As Integer = 0 To pm.dtPrinters.Rows.Count - 1
                Dim bfrState As Boolean = False
                Dim bfrRow As DataRow = pm.dtPrinters.Rows(check)
                If LCase(bfrRow("Path")) = LCase(pm.treePrinters.SelectedNode.FullPath.ToString) Then
                    ' Check each of the printers in the users temporary list to see if 
                    ' it exists.  If it does, then we need to check it.  
                    For isChecked As Integer = 0 To pm.dtUserPrinters.Rows.Count - 1
                        Dim tmpPtr As DataRow = pm.dtUserPrinters.Rows(isChecked)
                        If tmpPtr("Name").ToString.ToLower = bfrRow("Name").ToString.ToLower Then
                            bfrState = True
                            Exit For
                        Else
                            bfrState = False
                        End If
                    Next


                    ' Craete a listview item wtih this printer in it. 
                    ' Then add it to the listbox
                    Dim bfrItem As New ListViewItem
                    bfrItem.Text = bfrRow("Name")
                    bfrItem.Checked = bfrState
                    pm.chkDefPrinter.Items.Add(bfrItem)

                    bfrState = Nothing                    
                    bfrItem = Nothing

                End If
            Next

        Catch ex As Exception
            MsgBox("pm Encoutnered an error while attempting to add the printer to the user configuration." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Update Printer List")
            Return False
        End Try

        pm.bBuildingTree = False

        ' Bold the default printer
        If pm.defPrinterPath.ToLower = pm.treePrinters.SelectedNode.FullPath.ToLower Then
            pm.chkDefPrinter.BoldEntry(pm.defPrinterName)
        End If

        ' resize the list, JUST in case it wasn't resized proeprly
        pm.chkDefPrinter.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        Return True
    End Function

    

    Public Function Connect_Printers()
        Dim startTime As DateTime = Now
        Dim stopTime As DateTime = Nothing

        ' Disable Controls
        pm.cmdConnect.Enabled = False

        ' Loop through All of the users printers
        pm.dbg.prg.Visible = True
        pm.Progress.Visible = True
        pm.prgLabel.Visible = True

        pm.dbg.prg.Minimum = 0
        pm.Progress.Minimum = 0

        pm.Progress.Maximum = pm.dtUserPrinters.Rows.Count
        pm.dbg.prg.Maximum = pm.dtUserPrinters.Rows.Count

        ' We're going to be busy for a little bit, so 
        ' set the curost to an hourglass
        pm.Cursor = Cursors.WaitCursor

        ' Loop through all of the printers in the users table.
        ' Connect to each printer.
        Try
            For i As Integer = 0 To pm.dtUserPrinters.Rows.Count - 1
                ' increment our progress bar.
                pm.dbg.prg.Value = pm.dbg.prg.Value + 1
                pm.Progress.Value = pm.Progress.Value + 1
                pm.Refresh()

                ' Grab a row, which will be one printer definition
                Dim uPrt As DataRow = pm.dtUserPrinters.Rows(i)
                pm.prgLabel.Text = "Connecting Printer: " & uPrt("Name")
                pm.Refresh()

                ' Map the printer.
                Dim MapPtr = Map_Printer(uPrt("Share").ToString)

                ' Check the results of mapping the printer.
                If MapPtr = "success" Then

                    ' Check to see if we need to make this printer our default. 
                    If uPrt("Default") = True Then
                        log("  Making This Printer the default")
                        Make_DefaultPrinter(uPrt("Share"))
                    End If
                    log("Connected : " & uPrt("Name"))
                Else
                    log("Could not conect to printer: " & uPrt("Name"))
                    log(MapPtr)
                End If


            Next
        Catch ex As Exception
            MsgBox("pm Encoutnered an error while attempting to connect to a following Printer:" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Connecting to printer")
            Return False
        End Try


        ' Send our times to the log
        stopTime = Now
        log("Total Time: " & (startTime - stopTime).ToString)

        ' Cleanup        
        pm.dbg.prg.Value = 0
        pm.Progress.Value = 0
        pm.prgLabel.Visible = 0

        pm.dbg.prg.Visible = False
        pm.Progress.Visible = False

        stopTime = Nothing
        startTime = Nothing

        ' Put our mouse pointer back to normal
        pm.Cursor = Cursors.Arrow

        ' Enable Controls
        pm.cmdConnect.Enabled = True

        Return True
    End Function
    Function Make_DefaultPrinter(ByVal share As String)
        Dim spooler As New LocalPrintServer(PrintSystemDesiredAccess.None)
        Dim enumerationFlags() As EnumeratedPrintQueueTypes = {EnumeratedPrintQueueTypes.Connections}
        Dim oWMI = CreateObject("WScript.Network")

        Try
            For Each Q In spooler.GetPrintQueues(enumerationFlags)
                ' TODO: Determine if this printer is the one we want to make default, then make it default!
                Dim printerShare As String = Q.FullName.Replace(Q.Name, Q.ShareName)

                If printerShare.ToLower = share.ToLower Then
                    log("Setting Default Printer: " & printerShare)
                    Try
                        oWMI.SetDefaultPrinter(printerShare)
                        Return True
                    Catch ex As Exception
                        MsgBox("Could not set default printer to : " & printerShare, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Errror: Set default printer")
                        Return False
                    End Try
                End If
            Next

        Catch ex As Exception
            Return False
        End Try

        ' If we got here, then the user most likely didn't have a default printer set.
        Return False
    End Function
    Function Map_Printer(ByVal share As String)

        Dim Spooler As New LocalPrintServer
        Dim status = Nothing

        Try
            Spooler.ConnectToPrintQueue(share)
            Return "success"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Function show_EditPrinterDialog()
        ' Security Check        

        If Not pm.Security.canEditPrinter Then Return False

        log("Showing edit printer dialog")
        Try
            Dim editPrinterDialog As New frmUpdatePrinter
            editPrinterDialog.txtPrinterName.Text = pm.chkDefPrinter.SelectedItem.text
            editPrinterDialog.txtPrinterPath.Text = pm.treePrinters.SelectedNode.FullPath.ToString
            editPrinterDialog.txtPrinterShare.Text = pmDataFunctions.printers_getShareName(pm.chkDefPrinter.SelectedItem.text, pm.treePrinters.SelectedNode.FullPath.ToString)

            editPrinterDialog.txtOPrinterName.Text = editPrinterDialog.txtPrinterName.Text
            editPrinterDialog.txtOPrinterPath.Text = editPrinterDialog.txtPrinterPath.Text
            editPrinterDialog.txtOPrinterShare.Text = editPrinterDialog.txtPrinterShare.Text
            editPrinterDialog.Show()
            Return True
        Catch ex As Exception
            MsgBox("pm Attempted to add a printer to the list, but failed." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Update Printer List")
            Return False
        End Try

    End Function
    Function PrinterExists(ByVal Name As String, ByVal path As String)
        Try
            For check = 0 To pm.dtUserPrinters.Rows.Count - 1
                Dim ptr As DataRow = pm.dtUserPrinters.Rows(check)
                If ((Name.ToLower = ptr("Name").ToString.ToLower) And (path.ToLower = ptr("Path").ToString.ToLower)) Then
                    Return True
                End If
            Next
        Catch ex As Exception
            MsgBox("pm Encountered an error while trying to see if a printer existed." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Printer Exists?")
            Return False
        End Try
        
        Return False
    End Function

    
End Module
