Module pmCode
    ' -------------------------------------------------------------------------------------
    ' pm.Code
    ' -------------------------------------------------------------------------------------
    ' Misc routines that do not fit any other category belong in this module.
    ' -------------------------------------------------------------------------------------
    ' [%  ] [Function Name]         [Purpose]
    ' [100] Log                     Send a message to the log
    ' [100] AttemptToClose          Checks to see if it save to close the program
    ' [100] CloseProgram            Closes the program
    ' [100] ModeChange              Toggles the user mode and manipulates all the controls 
    '                                       that are impacted
    ' [100] unSavedData             Toggles unsaved data flag, and manipulate all controls 
    '                                       that are impacted
    ' [100] ToggleDebug             Toggle the visibility of the debug form
    ' [100] ShowHelp                Display the help information on the debug screen
    ' -------------------------------------------------------------------------------------

    ' API Declarations
    ' Send Message-----------------------------------------------------------------------------------------------------------
    Private Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal winHandle As Int32, ByVal wMsg As Int32, _
                                                                                ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    Public Const EM_SCROLL = &HB5
    Public Const SB_BOTTOM = 7
    Public Const SB_TOP = 6

    ' Global Variable Declarations

    Public userMode As String = "User"
    Public bCreateAndExit As Boolean = False
    Public bDebug As Boolean = False




    Function log(ByVal text)        
        Try
            pm.dbg.txtLog.Text = pm.dbg.txtLog.Text & "[" & TimeOfDay & "] " & text & vbCrLf
            SendMessage(pm.dbg.txtLog.Handle.ToInt32, EM_SCROLL, SB_BOTTOM, 0)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function '             Send a message to the log
    Function AttemptToClose(ByVal justChecking As Boolean)
        pm.AttemptingToClose = True

        If pm.bUnsavedData Then

            If pm.bUnsaved_UserData Then
                If pm.SaveUserOnExit Then
                    log("  ForceUserFile: Automatically saving User configurations")
                    SaveUserFile(pm.UserFile)
                Else
                    Dim resp = MsgBox("You have made changes to your selected printers, but did not save the changes." & vbCrLf & "If you continue, all data will be lost." & vbCrLf & vbCrLf & "Do you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "pm.Exit: Unsaved User Data")

                    Select Case resp
                        Case MsgBoxResult.Yes
                            CloseProgram()
                            AttemptToClose = False
                            pm.AttemptingToClose = False
                            Return True
                        Case Else
                            AttemptToClose = False
                            pm.AttemptingToClose = False
                            Return False
                    End Select
                End If
            End If

            If pm.bUnsaved_PMData Then
                If pm.SaveConfigOnExit Then
                    log("  ForceConfigFile: Automatically saving PM Configuration")
                    SavePrinterConfigFile(pm.PrinterFile)
                Else
                    Dim resp = MsgBox("You have made changes to the Available printers." & vbCrLf & "If you continue, all data will be lost." & vbCrLf & vbCrLf & "Do you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "pm.Exit: Unsaved pm Data")

                    Select Case resp
                        Case MsgBoxResult.Yes
                            Select Case justChecking
                                Case Is = True
                                    Return True
                                    AttemptToClose = False
                                    pm.AttemptingToClose = False
                                Case Else
                                    AttemptToClose = False
                                    pm.AttemptingToClose = False
                                    CloseProgram()                                    
                                    Return True
                            End Select

                        Case Else
                            AttemptToClose = False
                            Return False
                    End Select
                End If

            End If


            Select Case justChecking
                Case True
                    AttemptToClose = False
                    Return True
                Case Else
                    AttemptToClose = False
                    CloseProgram()
                    Return True
            End Select

        Else
            Select Case justChecking
                Case True
                    AttemptToClose = False
                    Return True
                Case Else
                    AttemptToClose = False
                    CloseProgram()
                    Return True
            End Select

        End If
    End Function '  Checks to see if it save to close the program
    Function CloseProgram()
        Try
            ' Unregistery Hotkeys
            log("Unregistering Hotkeys")
            log("  1: New Printer - Alt+A")
            pmHotKey.unregisterHotkeys(pm, 1)

            log("  3: New Printer - Alt+C")
            pmHotKey.unregisterHotkeys(pm, 3)

            log("  4: New Printer - Alt+D")
            pmHotKey.unregisterHotkeys(pm, 4)

            If pm.createPrintersOnExit Then pmPrinterFunctions.Connect_Printers()

            pm.dbg.Close()
            pm.Close()
            Return True
        Catch ex As Exception
            MsgBox("An error occurred while trying to shut the program down." & vbCrLf & "pm was asked to quit, but couldn't." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "pm.Error: Shutting Down")
            Return False
        End Try
    End Function '    Closes the program
    
    Function unSavedData(ByVal mode As Boolean, Optional ByVal type As String = "")
        ' Check to see what type of unsaved data we have
        If type.ToLower = "user" Then pm.bUnsaved_UserData = mode
        If type.ToLower = "pm" Then pm.bUnsaved_PMData = mode

        ' Check to see if one of our unsaved data types is true...
        If ((pm.bUnsaved_PMData = True) Or (pm.bUnsaved_UserData = True)) Then
            pm.bUnsavedData = True
            log(" pm.Unsaved Data:")
            log("   User Data : " & pm.bUnsaved_UserData)
            log("     pm Data : " & pm.bUnsaved_PMData)
        End If

        ' If both of our datatypes are false, we will set everything to false.
        If ((pm.bUnsaved_PMData = False) And (pm.bUnsaved_UserData) = False) Then pm.bUnsavedData = False


        ' Toggles the Unsaved Data value.        
        Select Case pm.bUnsavedData
            Case True
                pm.ctxUnsavedData.Image = My.Resources.unsaved_data
                log("  Unsaved Data Flag is now on")
            Case Else
                pm.ctxUnsavedData.Image = Nothing
                log("  Unsaved Data Flag is now off")
        End Select

        If pm.bUnsaved_UserData Then
            pm.mnuUnsavedUserData.Visible = True
        Else
            pm.mnuUnsavedUserData.Visible = False
        End If

        If pm.bUnsaved_PMData Then
            pm.pmUnsavedConfigData.Visible = True
        Else
            pm.pmUnsavedConfigData.Visible = False
        End If

        Return True
    End Function '     Toggles unsaved data flag, and manipulate all controls that are impacted
    Function ToggleDebug()
        ' =======================
        ' Toggle the debug window
        ' =======================
        Select Case pm.dbg.Visible
            Case True
                pm.dbg.Hide()
                Return False
            Case Else
                pm.dbg.Show()
                Return True
        End Select

    End Function '     Toggle the visibility of the debug form
    Function ShowHelp()
        log("Request to show help file: Showing")
        log("")
        log("")
        log("===============================================================================")
        log("pm : A printer Management Solution v" & pm.version)
        log("===============================================================================")
        log("-Debug                Enables debug mode")
        log("")
        log("Configuration Options")
        log("-------------------------------------------------------------------------------")
        log("-printerFile:<*.pmc>  AutoLoad List of printers")
        log("-userFile:<*.pmu>     AutoLoad User Confiugration File")
        log("")
        log("Operation Modes")
        log("-------------------------------------------------------------------------------")
        log("-mode:<mode>          Start in <mode>.  Mode can be user or admin")
        log("-createAndExit        Create Printers and exit the program")
        log("")
        log("AutoSave Options")
        log("-------------------------------------------------------------------------------")
        log("-saveSettingsOnExit   Save User Settings when program exists - no prompt")
        log("-saveConfigOnExit     Save PM Configuration when program exist - no prompt")
        log("                      WARNING: This can cause unexpected data loss!")
        log("===============================================================================")
        log("")
        log("")
        log("")
        pm.dbg.Visible = True
        Return Nothing
    End Function '        Display the help information on the debug screen


    Function Treeview_Search(ByVal SearchString As String, ByVal Nodes As TreeNodeCollection, Optional ByVal ExactMatch As Boolean = False, Optional ByVal Recursive As Boolean = True) As TreeNode
        Dim ret As TreeNode

        For Each tn As TreeNode In Nodes
            If ExactMatch = True Then
                If tn.FullPath = SearchString Then Return tn
            Else
                If tn.FullPath.IndexOf(SearchString) <> -1 Then Return tn
            End If

            If Recursive = True Then
                If tn.Nodes.Count > 0 Then
                    ret = Treeview_Search(SearchString, tn.Nodes, ExactMatch, Recursive)
                    If Not ret Is Nothing Then Return ret
                End If
            End If
        Next
        Return Nothing
    End Function

End Module
