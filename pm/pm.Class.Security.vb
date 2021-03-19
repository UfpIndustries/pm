Public Class Security

    Private l_canEditPrinter As Boolean = False
    Private l_canAddPrinter As Boolean = False
    Private l_canAddFolder As Boolean = False
    Private l_canRemoveFolder As Boolean = False
    Private l_canLoadConfigFile As Boolean = False
    Private l_canSaveConfigFile As Boolean = False
    Private l_canLoadUserFile As Boolean = False
    Private l_canSaveUserFile As Boolean = False
    Private l_canSeeFolderContextMenu As Boolean = False
    Private l_canSeePrinterContextMenu As Boolean = False


    Private l_SecurityMode As String = "user"

    Public Property canEditPrinter()
        Get
            Return l_canEditPrinter
        End Get
        Set(ByVal value)
            l_canEditPrinter = value
        End Set
    End Property '             Property: Can Edit Printers
    Public Property canSeePrinterContextMenu()
        Get
            Return l_canSeePrinterContextMenu
        End Get
        Set(ByVal value)
            l_canSeePrinterContextMenu = value
        End Set
    End Property '   Property: Can see the context menus on the printer list
    Public Property canSeeFolderContextMenu()
        Get
            Return l_canSeeFolderContextMenu
        End Get
        Set(ByVal value)
            l_canSeeFolderContextMenu = value
        End Set
    End Property '    Property: Can see the context menus on the folder list
    Public Property canAddPrinter()
        Get
            Return l_canAddPrinter
        End Get
        Set(ByVal value)
            l_canAddPrinter = value
        End Set
    End Property '              Property: Can Add a printer   
    Public Property canAddFolder()
        Get
            Return l_canAddFolder
        End Get
        Set(ByVal value)
            l_canAddFolder = value
        End Set
    End Property '               Property: Can add a new folder
    Public Property canRemoveFolder()
        Get
            Return l_canRemoveFolder
        End Get
        Set(ByVal value)
            l_canRemoveFolder = value
        End Set
    End Property '            Property: Can remove a folder
    Public Property canLoadConfigFile()
        Get
            Return l_canLoadConfigFile
        End Get
        Set(ByVal value)
            l_canLoadConfigFile = value
        End Set
    End Property '          Property: Can Load Configuration Files
    Public Property canSaveConfigFile()
        Get
            Return l_canSaveConfigFile
        End Get
        Set(ByVal value)
            l_canSaveConfigFile = value
        End Set
    End Property '          Property: Can Save Configuration Files
    Public Property canLoadUserFile()
        Get
            Return l_canLoadUserFile
        End Get
        Set(ByVal value)
            l_canLoadUserFile = value
        End Set
    End Property '            Property: Can Load User File
    Public Property canSaveUserFile()
        Get
            Return l_canSaveUserFile
        End Get
        Set(ByVal value)
            l_canSaveUserFile = value
        End Set
    End Property '            Property: Can Save User File
    Public Property Mode()
        Get
            Return l_SecurityMode
        End Get
        Set(ByVal value)
            l_SecurityMode = value
            EvaluateSecurity()
        End Set
    End Property '          '            Property: Controls the Security Mode

    Public Function EvaluateSecurity()
        Select Case l_SecurityMode.ToLower
            Case Is = "admin"
                l_canEditPrinter = True
                l_canAddPrinter = True
                l_canAddFolder = True
                l_canRemoveFolder = True
                l_canLoadConfigFile = True
                l_canSaveConfigFile = True
                l_canLoadUserFile = True
                l_canSaveUserFile = True
                l_canSeeFolderContextMenu = True
                l_canSeePrinterContextMenu = True

            Case Is = "user"
                l_canEditPrinter = False
                l_canAddPrinter = False
                l_canAddFolder = False
                l_canRemoveFolder = False
                l_canLoadConfigFile = False
                l_canSaveConfigFile = False
                l_canLoadUserFile = True
                l_canSaveUserFile = True
                l_canSeeFolderContextMenu = True
                l_canSeePrinterContextMenu = True
        End Select

        Return Nothing
    End Function

    Function ModeChange(ByVal mode As String)
        pm.userMode = mode
        pm.Security.Mode = mode
        log("  Requested Mode Change: " & pm.userMode)

        Select Case pm.userMode
            Case "Admin"
                ' Form Menus

                pm.fileLoadPrinter.Visible = True
                pm.fileSavePrinter.Visible = True
                pm.ctxFileSepTop.Visible = True

                pm.fileOpenUserConfig.Visible = True
                pm.fileSaveUserConfig.Visible = True

                pm.ctxDebug.Visible = True

                ' Context Menus
                pm.ctxFolderAdmin.Visible = True
                pm.ctxPrinterAdmin.Visible = True


                pm.ViewToolStripMenuItem.Visible = True

                pm.ctxModeChange.Text = "Admin Mode Enabled"



            Case "User"
                ' Form Menus
                pm.fileLoadPrinter.Visible = False
                pm.fileSavePrinter.Visible = False
                pm.ctxFileSepTop.Visible = False

                pm.ViewToolStripMenuItem.Visible = False

                If pm.preventConfigOpen Then pm.fileOpenUserConfig.Visible = False

                ' Context Menus
                pm.ctxFolderAdmin.Visible = False
                pm.ctxPrinterAdmin.Visible = False

                pm.ctxModeChange.Text = "User Mode Enabled"

        End Select

        Return mode
    End Function '    

End Class
