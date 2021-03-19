Public Module pmDataFunctions
    ' -------------------------------------------------------------------------------------
    ' Data Functions    
    ' -------------------------------------------------------------------------------------
    ' These functions manipulate all of the data in the data sets and data tables.  Any 
    ' manipulation of a dataset/datatable that occurs during a windows event should be done
    ' through a call to a function in this module.
    ' -------------------------------------------------------------------------------------
    ' [%  ] [Function Name]         [Purpose]
    ' [100] printers-getShareName   Returns the sharename of a printer
    ' [100] AddUserPrinter          Adds a printer to the users configuration datatable
    ' [100] RemoveUserPrinter       Removes a printer from theusers configuration datatable
    ' [100] UpdateTree              Updates the tree configuration in the data set
    ' -------------------------------------------------------------------------------------
    

    Function AddUserPrinter(ByVal Name As String, ByVal Share As String, ByVal Path As String, Optional ByVal isDefault As Boolean = False)
        ' ====================================================================================
        ' RemoveUserPrinter
        ' Removes a printer from the users configuration data table
        '    param 1: The name of the printer to remove
        '    param 2: The path of the printer to remove (treeNode path)
        ' ====================================================================================

        ' Log our intent
        log("Adding new printer to user table:")
        log("  Name   : " & Name)
        log("  Share  : " & Share)
        log("  Path   : " & Path)
        log("  Default: " & isDefault)

        Try
            ' Create a new data row to hold our printer.  Populate it with the
            ' information that we were passed.
            Dim newPtr As DataRow = pm.dtUserPrinters.NewRow
            newPtr("Name") = Name
            newPtr("Share") = Share
            newPtr("Path") = Path
            newPtr("Default") = isDefault

            ' Add the printer to the users configuration in memory
            pmCode.unSavedData(True, "user")
            pm.dtUserPrinters.Rows.Add(newPtr)

            unSavedData(True, "user")
            ' No error; return true and continue.
            Return True
        Catch ex As Exception
            ' Log the error that occurred.
            log(" Failed to Add Printer")
            log(ex.Message)
            Return False
        End Try

        ' Something really odd happened here.  We'll return false, but we should have never got this far into the function.
        Return False
    End Function
    Function RemoveUserPrinter(ByVal Name As String, ByVal Path As String)
        ' ====================================================================================
        ' RemoveUserPrinter
        ' Removes a printer from the users configuration data table
        '    param 1: The name of the printer to remove
        '    param 2: The path of the printer to remove (treeNode path)
        ' ====================================================================================

        ' Log our intent
        log("Removing Printer from User Table:")
        log("  Name : " & Name)
        log("  Path : " & Path)

        Try

            ' Loop through each printer in the users table.
            For chkDel As Integer = pm.dtUserPrinters.Rows.Count - 1 To 0 Step -1

                ' Grab a row of data which should contain one printer
                Dim ptr As DataRow = pm.dtUserPrinters.Rows(chkDel)

                ' Check the printer name and path to see if this is the printer we want 
                ' to remove.  If it is, remove it and return true.
                If ((ptr("Name").ToString.ToLower = Name.ToLower) And _
                    (ptr("Path").ToString.ToLower = Path.ToLower)) Then
                    pm.dtUserPrinters.Rows.Remove(ptr)
                    unSavedData(True, "user")
                    Return True
                End If
            Next

        Catch ex As Exception
            ' Return the error that was generated, and false.
            log("  Failed to remove printer.")
            log(ex.Message)
            Return False
        End Try

        ' If we got here, there was not a printer that matched the critera so we'll return
        ' false and exit.
        Return False
    End Function

    Public Function AddSystemPrinter(ByVal PrinterName As String, ByVal Share As String, ByVal Path As String, Optional ByVal Message As String = "")
        ' We're adding a new printer.  Log what we know for reference later
        log("Adding a new printer")
        log("  New Printer Name  : " & PrinterName)
        log("  New Printer Share : " & Share)
        log("  New Printer Path  : " & Path)

        ' Check for Duplicate Printers
        Try
            For checkDup As Integer = 0 To pm.dtPrinters.Rows.Count - 1
                Dim buffer As DataRow = pm.dtPrinters.Rows(checkDup)

                If LCase(buffer("Name")) = LCase(PrinterName) Then
                    log("Duplicate Printer Found: " & PrinterName)

                    If LCase(buffer("Path")) = LCase(Path) Then
                        MsgBox("This printer already exists.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Add Printer")
                        log("ERROR: Could not add printer becuase printer already exists.")

                        Return False
                    End If
                End If

                buffer = Nothing
            Next
        Catch ex As Exception
            MsgBox("pm Encoutnered an error while attempting to check for duplicate printers in the Configuration Table." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.Question, "pm.Error: Add Printers to Tree: Dupe check")
        End Try





        ' Create a new row for our printer data table
        Try
            Dim newRow As DataRow = pm.dtPrinters.NewRow
            newRow("Name") = PrinterName
            newRow("Share") = Share
            newRow("Path") = Path
            newRow("Message") = Message

            pm.dtPrinters.Rows.Add(newRow)
            log("Printer Added")
            unSavedData(True, "pm")
            UpdatePrinterList()
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function
    Public Function RemoveSystemPrinter(ByVal Name As String, ByVal Path As String)
        log("Remvoing Printer: " & Path & "\" & Name)

        Try
            For dCounter As Integer = pm.dtPrinters.Rows.Count - 1 To 0 Step -1
                Dim dPrinter As DataRow = pm.dtPrinters.Rows(dCounter)
                Dim bufCurName As String = dPrinter("Name").tolower
                Dim bufCurPath As String = dPrinter("Path").tolower

                If ((bufCurPath = Path.ToLower) And (bufCurName = Name.ToLower)) Then
                    log("  Deleting all Record of this printer")
                    pm.dtPrinters.Rows.Remove(dPrinter)
                    pmCode.unSavedData(True, "pm")
                    log("  Printer Deleted")                    
                End If
            Next
        Catch ex As Exception
            MsgBox("pm Encountered an error while trying to remove a printer from the configuration." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Remove System Printer")
            Return False
        End Try

        Return True
    End Function

    Public Function SetDefaultPrinter(ByVal Name As String, ByVal Path As String)
        For setDefault = 0 To pm.dtUserPrinters.Rows.Count - 1
            Dim ptr As DataRow = pm.dtUserPrinters.Rows(setDefault)
            If ((Name.ToLower = ptr("Name").tolower) And (Path.ToLower = ptr("Path").tolower)) Then
                ptr("Default") = True
            Else
                ptr("Default") = False
            End If
        Next

        ' Update the unsaved user data if we're not building the tree
        If Not pm.bBuildingTree Then pmCode.unSavedData(True, "user")
        Return True
    End Function

    Public Function UpdateTree()
        Try
            ' Clear any existing tree data that might be stored in the dataset
            log("  Clearing stale Tree Configuration")
            pm.dtTree.Clear()

            ' Serialize the tree.  Store it in a new data row inside our datatable.
            log("  Storing new Tree Configuration")

            ' Add update the datatable with the new tree configuration
            Dim row As DataRow = pm.dtTree.NewRow
            row("Configuration") = TreeViewFunctions.TreeViewToString(pm.treePrinters)
            pm.dtTree.Rows.Add(row)
            row = Nothing
            Return True

        Catch ex As Exception
            MsgBox("pm Encoutnered an error while trying to update the tree configuration in the data table." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Update Tree")
            Return False
        End Try
        
    End Function
    Function printers_getShareName(ByVal Name As String, ByVal Path As String)
        ' ====================================================================================
        ' printers_GetShareName
        ' This function will give you the sharename of the printer based on a name and
        ' the path in the tree.
        '
        '   param1: The name of the printer 
        '   param2: The full path of the printer (the path in the treee, not the share)
        ' ====================================================================================
        Try
            ' Loop through each known printer
            For i As Integer = 0 To pm.dtPrinters.Rows.Count - 1

                ' Create a datarow with one printer in it
                Dim chkPrinter As DataRow = pm.dtPrinters.Rows(i)

                ' Check to see if the name and the path  match.  If they do, return the share.  Otherwise keep going.
                If ((chkPrinter("Name").ToString.ToLower = Name.ToLower) And (chkPrinter("Path").ToString.ToLower = Path.ToLower)) Then
                    Return chkPrinter("Share")
                End If
            Next
        Catch ex As Exception
            ' Some error occurred
            Return Nothing
        End Try

        ' We didn't find a printer that matched the criteria that was specified.  We can 
        ' return nothing and exit.
        Return Nothing
    End Function

End Module
