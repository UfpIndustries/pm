Public Class pmHotKey
    ' -------------------------------------------------------------------------------------
    ' pm.HotKey
    ' -------------------------------------------------------------------------------------
    ' This class handles hotkeys.  
    ' -------------------------------------------------------------------------------------
    '   To register a new hotkey:
    '    1. ) Use the register event:
    '    2. ) Add the following subroutine to the form that the hotkey will be "bound" to
    '         Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '           If m.Msg = pmHotKey.WM_HOTKEY Then
    '             pmHotKey.handleHotKeyEvent(m.WParam)
    '           End If
    '           MyBase.WndProc(m)
    '         End Sub
    ' -------------------------------------------------------------------------------------
#Region "Declarations - WinAPI, Hotkey constant and Modifier Enum"
    Public Declare Function RegisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    Public Declare Function UnregisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer) As Integer
    Public Const WM_HOTKEY As Integer = &H312

    Enum KeyModifier
        None = 0
        Alt = &H1
        Control = &H2
        Shift = &H4
        Winkey = &H8
    End Enum 'This enum is just to make it easier to call the registerHotKey function: The modifier integer codes are replaced by a friendly "Alt","Shift" etc.

#End Region

#Region "Hotkey registration, unregistration and handling"
    Public Shared Sub registerHotkey(ByRef sourceForm As Form, ByVal ndx As Integer, ByVal triggerKey As String, ByVal modifier As KeyModifier)
        RegisterHotKey(sourceForm.Handle, ndx, modifier, Asc(triggerKey.ToUpper))
    End Sub
    Public Shared Sub unregisterHotkeys(ByRef sourceForm As Form, ByVal ndx As Integer)
        UnregisterHotKey(sourceForm.Handle, ndx)  'Remember to call unregisterHotkeys() when closing your application.
    End Sub
    Public Shared Sub handleHotKeyEvent(ByVal hotkeyID As IntPtr)
        Select Case hotkeyID.ToString
            Case "1"
                log("Hotkey (" & hotkeyID.ToString & "): New Printer:")
                pmPrinterFunctions.Show_AddNewPrinterDialog()
            Case Is = "3"
                log("Hotkey (" & hotkeyID.ToString & "): Connect to Printers")
                pmPrinterFunctions.Connect_Printers()

            Case Is = "4"
                log("Hotkey (" & hotkeyID.ToString & "): Toggle Debug Window")
                pmCode.ToggleDebug()

            Case Is = "5"
                log("Hotkey (" & hotkeyID.ToString & ") : Edit Printer")
                If pm.chkDefPrinter.SelectedItem IsNot Nothing Then pmPrinterFunctions.show_EditPrinterDialog()

            Case Else
                log("Hotkey (" & hotkeyID.ToString & "): Unknown hotkey was pressed")
        End Select

    End Sub
#End Region
End Class


