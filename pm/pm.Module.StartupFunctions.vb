Module pmStartupFunctions
    ' -------------------------------------------------------------------------------------
    ' Startup Functions
    ' -------------------------------------------------------------------------------------
    ' These functions handle the startup process of the applications.  Anything that should
    ' be automated on startup belongs in here.  All calls from Windows Events that occur
    ' on startup should reference functions that are sotred in this module.
    ' -------------------------------------------------------------------------------------
    ' [%  ] [Function Name]                 [Purpose]
    ' [100] ProcessCommandLineArguments     Looks at command line arguments, adjust settings on the fly.
    ' [100] loadStatupData                  Loads data passed to the command line or in the .config file
    ' -------------------------------------------------------------------------------------

    Function ProcessCommandLineArguments()
        log("  Processing Command Line Arguments")

        Dim args = System.Environment.GetCommandLineArgs
        For iArgs = 0 To UBound(args)
            Dim arg As String = ""
            log("    ARG: " & args(iArgs))

            arg = "-debug"
            If args(iArgs).ToLower.StartsWith(arg) Then
                log("       : Enabling Debug Mode")
                pm.bDebug = True
            End If

            ' -------------------------------------------------------------------------------------
            ' Check for the Printers Configuration File
            ' -------------------------------------------------------------------------------------
            arg = "-printerfile:"
            If args(iArgs).ToLower.StartsWith(arg) Then
                pm.PrinterFile = args(iArgs).Substring(arg.Length, args(iArgs).Length - arg.Length)
                log("       : Found Printer Configuration File arg")

                If My.Settings.AutoLoadConfigPreventsOpenConfig = True Then
                    log("         --> Disabling Open Printer Settings becuase AutoLoadConfigPreventsOpen is true")
                    pm.preventConfigOpen = True
                End If

                If My.Settings.AutoLoadConfigWillAutoSaveConfig = True Then
                    log("         --> Forcing Auto Save of Configuration File changes")
                    pm.fileSavePrinter.Visible = False
                    pm.SaveConfigOnExit = True
                End If

            End If

            ' -------------------------------------------------------------------------------------
            ' Check for UserFile
            ' -------------------------------------------------------------------------------------
            arg = "-userfile:"
            If args(iArgs).ToLower.StartsWith(arg) Then
                pm.UserFile = Trim(args(iArgs).Substring(arg.Length, args(iArgs).Length - arg.Length))
                log("       : Found User Configuration File arg")

                If My.Settings.AutoLoadUsersPreventsOpen = True Then
                    log("         --> Disabling Open User file becuase AutoLoadSettingsPreventsOpen is true")
                    pm.preventSettingsOpen = True
                Else
                    log("         --> PM Configuration File will not be auto saved")

                End If

                If My.Settings.AutoLoadUserWillAutoSaveUser = True Then
                    log("         --> Forcing Auto Save of User Configuration File changes")
                    pm.fileSaveUserConfig.Visible = False
                    pm.SaveUserOnExit = True
                Else
                    log("         --> User Configuration File will not be auto saved")
                End If
            End If

            ' -------------------------------------------------------------------------------------
            ' Check for mode
            ' -------------------------------------------------------------------------------------
            arg = "-mode:"
            If args(iArgs).ToLower.StartsWith(arg) Then
                Dim bufMode = args(iArgs).Substring(arg.Length, args(iArgs).Length - arg.Length)
                log("       : Operation Mode Specified on Command Line")

                Select Case bufMode.ToLower
                    Case "admin"
                        pm.userMode = "Admin"
                    Case "user"
                        pm.userMode = "User"
                    Case Else
                        pm.userMode = "User"
                End Select
            End If

            ' -------------------------------------------------------------------------------------
            ' Check for -CreateAndExit
            ' -------------------------------------------------------------------------------------
            arg = "-createandexit"
            If pm.bCreateAndExit = False Then
                If args(iArgs).ToLower.StartsWith(arg) Then
                    pm.bCreateAndExit = True
                    log("  Printers will be created and pm will exit automatically")
                Else
                    pm.bCreateAndExit = False
                End If
            End If

            ' -------------------------------------------------------------------------------------
            ' Check for -SaveUserOnExit
            ' -------------------------------------------------------------------------------------
            arg = "-savesettingsonexit"
            If pm.SaveUserOnExit = False Then
                If args(iArgs).ToLower.StartsWith(arg) Then
                    pm.SaveUserOnExit = True
                    log("  User Configuration will be saved on exit")
                Else
                    pm.SaveUserOnExit = False
                End If
            End If

            ' -------------------------------------------------------------------------------------
            ' Check for -SaveConfigOnExit
            ' -------------------------------------------------------------------------------------
            arg = "-saveconfigonexit"
            If pm.SaveConfigOnExit = False Then
                If args(iArgs).ToLower.StartsWith(arg) Then
                    pm.SaveConfigOnExit = True
                    log("PM Configuration will be saved on exit")
                Else
                    pm.SaveConfigOnExit = False
                End If
            End If

            ' -------------------------------------------------------------------------------------
            ' Check to see if we should hide the file menu
            ' -------------------------------------------------------------------------------------
            arg = "-hidefile"
            If args(iArgs).ToLower.StartsWith(arg) Then
                pm.FileToolStripMenuItem.Visible = False
            End If


            ' -------------------------------------------------------------------------------------
            ' Check for -PreventConfigOpen
            ' -------------------------------------------------------------------------------------
            arg = "-preventConfigOpen"
            If args(iArgs).ToLower.StartsWith(arg) Then
                pm.preventConfigOpen = True
            End If

            ' -------------------------------------------------------------------------------------
            ' Check for -PreventSettingsOpen
            ' -------------------------------------------------------------------------------------
            arg = "-preventSettingsOpen"
            If args(iArgs).ToLower.StartsWith(arg) Then
                pm.preventSettingsOpen = True
            End If

            ' -------------------------------------------------------------------------------------
            ' Check for -DefaultPrintServer
            ' -------------------------------------------------------------------------------------
            arg = "-defaultprintserver:"
            If args(iArgs).ToLower.StartsWith(arg) Then
                pm.DefaultPrintServer = args(iArgs).Substring(arg.Length, args(iArgs).Length - arg.Length)
            End If

            ' -------------------------------------------------------------------------------------
            ' Check for -doNotCreateOnClose
            ' -------------------------------------------------------------------------------------
            arg = "-doNotCreateOnClose"
            If args(iArgs).ToLower.StartsWith(arg) Then
                pm.createPrintersOnExit = False            
            End If

            ' -------------------------------------------------------------------------------------
            ' check for -?
            ' -------------------------------------------------------------------------------------
            arg = "-?"
            If args(iArgs).ToLower.StartsWith(arg) Then
                pmCode.ShowHelp()
            End If
        Next

        Return True
    End Function
    Function loadStartupData()
        log("Loading Startup Data")

        ' -------------------------------------------------------------------------------------
        ' Check for a default printer configuration file
        ' -------------------------------------------------------------------------------------
        If pm.PrinterFile = "" Then pm.PrinterFile = My.Settings.ConfigurationFile
        If pm.PrinterFile <> "" Then
            log("Auto-Opening Printer Configuration File")

            Select Case System.IO.File.Exists(pm.PrinterFile)
                Case True
                    OpenPrinterConfigFile(pm.PrinterFile)
                Case Else
                    log("    : File not found")
                    log("    : " + pm.PrinterFile)

            End Select
        Else
            log("    : No default file was provided")
        End If

        ' -------------------------------------------------------------------------------------
        ' Check for a default user configuration file
        ' -------------------------------------------------------------------------------------
        If pm.UserFile = "" Then pm.UserFile = My.Settings.UserSettings
        If pm.UserFile <> "" Then
            log("Auto-opening User Configuration File")

            Select Case System.IO.File.Exists(pm.UserFile)
                Case True
                    OpenUserFile(pm.UserFile)
                Case Else
                    log("    : Could not open " & pm.UserFile)
                    log("    : File not found")
                    log("    : " + pm.UserFile)

            End Select
        Else
            log("    : No User Configuration File Specified")
        End If

        ' -------------------------------------------------------------------------------------
        ' Check for -SaveUserOnExit
        ' -------------------------------------------------------------------------------------
        If pm.SaveUserOnExit = False Then
            If My.Settings.SaveUserOnExit Then
                pm.SaveUserOnExit = True
                log("    .Config: Forcing SaveUserOnExit")
            End If
        End If

        
        Return True
    End Function
End Module
