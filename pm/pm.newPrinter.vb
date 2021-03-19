Public Class newPrinter

    ' -------------------------------------------------------------------------------------
    ' pm.Form.NewPrinter
    ' -------------------------------------------------------------------------------------
    ' The controls on this form present the user with an interface to add a new printer
    ' to the System Configuration.  This class only contains windows events.
    ' -------------------------------------------------------------------------------------
    ' [%  ] [Function Name]         [Purpose]
    ' [100] cmdCancel_Click         The user has pressed the cancel button on the form
    ' [100] cmdAdd_Click            The user has pressed the add buton
    ' [100] txtName_KeyDown         User presses a key in the txtName textbox
    ' [100] txtShare_Keydown        User presses a key in the txtShare textbox
    ' -------------------------------------------------------------------------------------
    Public oldName As String = Nothing
    Public oldPath As String = Nothing
    Public oldShare As String = Nothing

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click        
        log("Canceled New Printer dialog")
        Try
            Me.Dispose()
        Catch ex As Exception
            log("Attempted to close pm.NewPrinter (form), but failed with:")
            log(ex.Message)
        End Try

    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ' Validate Form Entry
        If txtName.Text = "" Then
            MsgBox("You must provide a name for this printer.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Adding Printer")
            log("Attempted to add a printer without a name")
            Exit Sub
        End If

        If txtShare.Text = "" Then
            MsgBox("You must provide a share for this printer.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Adding Printer")
            log("Attempted to add a printer without a share")
            Exit Sub
        End If

        log("Calling Add New Printer:")
        log("  Name: " & txtName.Text)
        log("  Share: " & txtShare.Text)
        log("  Path : " & txtPath.Text)

        AddSystemPrinter(txtName.Text, txtShare.Text, txtPath.Text)

        Me.Dispose()

    End Sub

    Private Sub txtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown

        Select Case e.KeyCode

            ' If the enter key was pressed
            Case Keys.Enter

                If txtName.Text = "" Then
                    ' Check to see if we have a printer name.  If not, exit.
                    log("  AddPrinter: Enter pressed on blank printer name.")
                    Exit Sub

                Else
                    If txtShare.Text = "" Then
                        ' Check to see if we have a share name.  If not, switch over to that field.
                        log("  AddPrinter: Enter pressed on printer name, but blank share name")
                        txtShare.Focus()

                    Else
                        ' If we have a share name, then we'll perform the add event.
                        log("  AddPrinter: Enter Pressed on Printer Name, attempting to add printer")
                        cmdAdd.PerformClick()
                    End If

                End If


        End Select
    End Sub

    Private Sub txtShare_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShare.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If txtShare.Text = "" Then
                    ' Check to see if we have a share name.  If not, exit.
                    log("  AddPrinter: Enter pressed on blank share name.")
                    Exit Sub
                Else
                    If txtName.Text = "" Then
                        ' Check to see if we have a printer name.  If not, switch focus to that field
                        log("  AddPrinter: Enter pressed on share name, but blank printer name")
                        txtName.Focus()
                    Else
                        ' If we have a printer name, then we'll try to perform the add event
                        log("  AddPrinter: Enter Pressed on Share Name, attempting to add printer")
                        cmdAdd.PerformClick()
                    End If
                End If

        End Select
    End Sub

    
 
    Private Sub newPrinter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load        

        If Not pm.DefaultPrintServer.StartsWith("\\") Then pm.DefaultPrintServer = "\\" & pm.DefaultPrintServer
        If Not pm.DefaultPrintServer.EndsWith("\") Then pm.DefaultPrintServer = pm.DefaultPrintServer & "\"
        txtShare.Text = pm.DefaultPrintServer
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        log(" Updating Printer: " & oldName)
        log("    Removing old printer")
        pmDataFunctions.RemoveSystemPrinter(oldName, oldPath)

        log("    Creating New Printer")
        pmDataFunctions.AddSystemPrinter(txtName.Text, txtShare.Text, txtPath.Text)

        log("    Clearing form data")
        txtName.Text = ""
        txtShare.Text = ""
        txtPath.Text = ""
        oldName = ""
        oldPath = ""
        oldShare = ""
        UpdatePrinterList()

        Me.Dispose()

    End Sub
End Class