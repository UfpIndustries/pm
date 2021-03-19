Module pmFileFunctions

    ' -------------------------------------------------------------------------------------
    ' File Functions
    ' -------------------------------------------------------------------------------------
    ' The functions in this module control the file operations.  Any call to an external
    ' file should be made through functions in this module.  All file operations that occur
    ' during windows events should reference functions stored in this module.
    ' -------------------------------------------------------------------------------------
    ' [%  ] [Function Name]         [Purpose]
    ' [100] OpenPrinterConfigFile   Open Printer Configuration File: Printers.pmc
    ' [100] SavePrinterConfigFile   Save Printer Configuration File: Printers.pmc
    ' [100] OpenUserFile            Open User Configuration File: MyPrinters.pmu
    ' [100] SaveUserFile            Save User configuration File: MyPrinters.pmu
    ' -------------------------------------------------------------------------------------

    Function OpenPrinterConfigFile(ByVal filename As String)
        log("Opening Configuration File:")
        log("  File: " & filename)

        ' Clear the data so we don't end up with duplicates.
        ' If we don't clear, the .ReadXML method of the dataset will just append data.
        pm.dsData.Clear()

        Try
            ' Read the new file and set the unsaved data bit to false.
            pm.dsData.ReadXml(filename)
            unSavedData(False, "pm")

            ' Get the Treeview from the data set and restore it
            log("  Rebuilding TreeView")
            pm.treePrinters.Nodes.Clear()
            TreeViewFunctions.LoadTreeViewDataFromString(pm.treePrinters, (pm.dtTree.Rows(0))(0))

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Function SavePrinterConfigFile(ByVal filename As String)
        log("Saving Configuration File:")
        log("  File: " & filename)

        pmDataFunctions.updateTree()

        Try

            ' Write the data
            pm.dsData.WriteXml(filename)
            log("Configuration Saved")
            unSavedData(False, "pm")
            Return (True)

        Catch ex As Exception
            MsgBox("An error occurred while attempting to save the configuration file." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Save Printer Configuration File")
            Return False

        End Try
    End Function

    Function OpenUserFile(ByVal Filename)
        ' Clear out existing data
        pm.dtUserPrinters.Clear()
        pm.defPrinterName = ""
        pm.defPrinterPath = ""



        Try
            pm.dtUserPrinters.ReadXml(Filename)
            UpdatePrinterList()

            ' Once we get the list of printers, we need to set our default
            For check As Integer = 0 To pm.dtUserPrinters.Rows.Count - 1
                Dim ptr As DataRow = pm.dtUserPrinters.Rows(check)
                If ptr("Default") = True Then
                    SetDefaultPrinterAction(ptr("Name"), ptr("Path"))
                End If
            Next

            


        Catch ex As Exception
            Return False
        End Try

        Try
            ' Try to set the node in the treeview to the one specified in the default printer
            Dim tn As TreeNode = Treeview_Search(pm.defPrinterPath, pm.treePrinters.Nodes, False, True)
            If Not tn Is Nothing Then
                log("  Setting Default Printer Node")
                pm.treePrinters.SelectedNode = tn
            End If
        Catch ex As Exception
            log("  Tried to set the default node, but the path doesn't exist in the tree")
        End Try

        Try
            ' Try to set select the printer that matches our default if it's available in the list
            For Each item In pm.chkDefPrinter.Items
                If item.text.tolower = pm.defPrinterName.ToLower Then
                    log("  Automatically selecting printer")
                    pm.chkDefPrinter.SelectedItem = item.text
                End If
            Next

            'For Each bufPrinter In pm.chkPrinters.Items
            ' If bufPrinter.ToString.ToLower = pm.defPrinterName.ToLower Then
            'log("  Automatically selecting printer")
            'pm.chkPrinters.SelectedItem = bufPrinter
            'End If
            'Next

        Catch ex As Exception

        End Try
        

        unSavedData(False, "user")

        Return True
    End Function
    Function SaveUserFile(ByVal filename)
        ' Clear out our temporary data -- we don't need to save that.
        pm.dtTempList.Clear()


        Try
            ' Save the dataset
            pm.dsUserData.WriteXml(filename)
            pmCode.unSavedData(False, "user")
            Return True

        Catch ex As Exception
            MsgBox("An error occurred while attempting to save the User Configuration File." + vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Save User Configuration")
            Return False
        End Try

    End Function
End Module
