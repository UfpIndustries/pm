Public Class debug

    Private Sub debug_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub



    Private Sub debug_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim groupBoxWidth = (Me.Width - 48) / 2
        Dim groupBoxHeight = (Me.Height) - 72
        Dim dtaSize = ((Me.Width - 48) / 2) - 12


        grpUserMode.Left = 12
        grpUserMode.Width = groupBoxWidth
        grpUserMode.Height = groupBoxHeight

        dtaPrinters.Left = 6
        dtaPrinters.Width = dtaSize
        dtaPrinters.Height = ((grpUserMode.Height / 2) - 35)

        dtaUserSettings.Top = dtaPrinters.Top + dtaPrinters.Height + 12
        dtaUserSettings.Left = 6
        dtaUserSettings.Width = dtaSize
        dtaUserSettings.Height = dtaPrinters.Height


        txtDefPrinter.Left = 89
        txtDefPrinter.Width = dtaPrinters.Width - 89 + 6

        grpAdminMode.Left = 12 + groupBoxWidth + 12
        grpAdminMode.Width = groupBoxWidth
        grpAdminMode.Height = groupBoxHeight

        txtLog.Left = txtLog.Left
        txtLog.Width = dtaSize
        txtLog.Height = (grpAdminMode.Height - 45 - 10)




    End Sub


    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub txtLog_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLog.MouseDoubleClick
        Select Case MsgBox("Are you sure you want to clear the log file?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Clear Log:")
            Case MsgBoxResult.Yes
                txtLog.Text = ""
        End Select
    End Sub



    Private Sub DelPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelPrinter.Click

        Select Case MsgBox("This will remove the printer from the users selection." & vbCrLf & vbCrLf & "Are you sure you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Printer:")
            Case MsgBoxResult.Yes
                log("    --> Removing Printer")
                If pmDataFunctions.RemoveUserPrinter(dtaUserSettings.Item(1, dtaUserSettings.CurrentRow.Index).Value, _
                                          dtaUserSettings.Item(3, dtaUserSettings.CurrentRow.Index).Value) = True Then
                    log("Printer Removed")
                    pmPrinterFunctions.UpdatePrinterList()
                Else
                    log("Could not remove printer")
                End If

            Case Else
                log("Printer not deleted")
        End Select


    End Sub

    Private Sub dtaUserSettings_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtaUserSettings.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            log("Right click on User Settings: Show menu")

            Dim hit As DataGridView.HitTestInfo = sender.hittest(e.X, e.Y)
            log("  Hit Type: " & hit.Type.ToString)
            If hit.Type = DataGridViewHitTestType.Cell Then
                If Not dtaUserSettings.Rows(hit.RowIndex).Selected Then
                    log("    -> User right clicked a row that wasn't selected: selecting it for them")
                    dtaUserSettings.ClearSelection()
                    dtaUserSettings.Rows(hit.RowIndex).Selected = True
                    dtaUserSettings.CurrentCell = dtaUserSettings.Rows(hit.RowIndex).Cells(0)
                End If

                Try

                    Dim name As String = dtaUserSettings.Item(1, dtaUserSettings.CurrentRow.Index).Value
                    log("    --> Printer Name: " & name)

                    Dim path As String = dtaUserSettings.Item(3, dtaUserSettings.CurrentRow.Index).Value
                    log("    --> Path        : " & path)

                    DelPrinter.Text = "Delete: " & name


                    Dim p As Point = New Point(e.X, e.Y)
                    ctxUserData.Show(dtaUserSettings, p)
                Catch ex As Exception
                    log("Error: Most likely caused by click on the blank row in the user configuration")
                End Try
            End If
        End If
    End Sub



    Private Sub debug_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
End Class