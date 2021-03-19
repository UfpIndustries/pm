Public Class frmUpdatePrinter

    
    Private Sub frmUpdatePrinter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmdUpdate.Enabled = False        
    End Sub '        Form load event
    Function SomethingToUpdate()
        Dim updates As Boolean = False
        Dim oPN = txtOPrinterName.Text.ToLower
        Dim nPN = txtPrinterName.Text.ToLower

        Dim oPS = txtOPrinterShare.Text.ToLower
        Dim nPS = txtPrinterShare.Text.ToLower

        Dim oPP = txtOPrinterPath.Text.ToLower
        Dim nPP = txtPrinterShare.Text.ToLower

        If Not txtOPrinterName.Text.ToLower = txtPrinterName.Text.ToLower Then updates = True
        If Not txtOPrinterShare.Text.ToLower = txtPrinterShare.Text.ToLower Then updates = True
        If Not txtOPrinterPath.Text.ToLower = txtPrinterPath.Text.ToLower Then updates = True

        If updates Then
            Return True
        Else
            Return False
        End If
    End Function '               Determines if the new values are differnent than the old
    Private Sub txtPrinterName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrinterName.TextChanged
        cmdUpdate.Enabled = SomethingToUpdate()
    End Sub '   TextChanged Event
    Private Sub txtPrinterShare_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrinterShare.TextChanged
        cmdUpdate.Enabled = SomethingToUpdate()
    End Sub '  TextChanged Event
    Private Sub txtPrinterPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrinterPath.TextChanged
        cmdUpdate.Enabled = SomethingToUpdate()
    End Sub '   TextChanged Event
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        log("Update Request Canceled")
        Me.Dispose()
    End Sub '              Cancel the Update request
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        log("Updating Printer:")
        log("  Verifying the path: ")
        Dim tn As TreeNode = Treeview_Search(txtPrinterPath.Text, pm.treePrinters.Nodes, False, True)
        If tn Is Nothing Then
            log("    The path does not exist!  Please create it first.")
            MsgBox("pm Encountered an error while attempting to update the printer." & vbCrLf & vbCrLf & "The path provided does not exist.  Please create it before attempting to move printers to it.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "pm.Error: Update Printer")
            tn = Nothing
            Exit Sub

        Else
            log("    Path Exists")
        End If
        tn = Nothing

        log("  Removing old printer")
        pmDataFunctions.RemoveSystemPrinter(txtOPrinterName.Text, txtOPrinterPath.Text)

        log("  Adding new printer")
        pmDataFunctions.AddSystemPrinter(txtPrinterName.Text, txtPrinterShare.Text, txtPrinterPath.Text)

        pmPrinterFunctions.Update_UserPrinter(txtOPrinterName.Text, txtOPrinterShare.Text, txtOPrinterPath.Text, txtPrinterName.Text, txtPrinterShare.Text, txtPrinterPath.Text)
        UpdatePrinterList()
        Me.Dispose()
    End Sub '              Update the printer.

End Class