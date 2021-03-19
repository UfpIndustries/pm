<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pm))
        Me.mnu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.fileLoadPrinter = New System.Windows.Forms.ToolStripMenuItem()
        Me.fileSavePrinter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxFileSepTop = New System.Windows.Forms.ToolStripSeparator()
        Me.fileOpenUserConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.fileSaveUserConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxDebug = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxModeChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxUnsavedData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUnsavedUserData = New System.Windows.Forms.ToolStripMenuItem()
        Me.pmUnsavedConfigData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConnectPrinters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowDebugWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpPrinters = New System.Windows.Forms.GroupBox()
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.treePrinters = New System.Windows.Forms.TreeView()
        Me.ctxTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxFolderAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAdminPrinters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAdminPrinterNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAdminFolders = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAdminFolderNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAdminFolderRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.inFile = New System.Windows.Forms.OpenFileDialog()
        Me.ctxPrinters = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxPrinterAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAdminAddPrinter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEditPrinter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAdminRemovePrinter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxSetDefaultPrinter = New System.Windows.Forms.ToolStripMenuItem()
        Me.outFile = New System.Windows.Forms.SaveFileDialog()
        Me.sUSerFile = New System.Windows.Forms.SaveFileDialog()
        Me.oUserFile = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.prgLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.DragCounter = New System.Windows.Forms.Timer(Me.components)
        Me.mnu.SuspendLayout()
        Me.grpPrinters.SuspendLayout()
        Me.ctxTree.SuspendLayout()
        Me.ctxPrinters.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnu
        '
        Me.mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.PrintersToolStripMenuItem})
        Me.mnu.Location = New System.Drawing.Point(0, 0)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(741, 24)
        Me.mnu.TabIndex = 0
        Me.mnu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileLoadPrinter, Me.fileSavePrinter, Me.ctxFileSepTop, Me.fileOpenUserConfig, Me.fileSaveUserConfig, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'fileLoadPrinter
        '
        Me.fileLoadPrinter.Image = Global.pm.My.Resources.Resources.file_open_icon
        Me.fileLoadPrinter.Name = "fileLoadPrinter"
        Me.fileLoadPrinter.Size = New System.Drawing.Size(206, 22)
        Me.fileLoadPrinter.Text = "Load Printer File"
        '
        'fileSavePrinter
        '
        Me.fileSavePrinter.Image = Global.pm.My.Resources.Resources.file_save_as_icon
        Me.fileSavePrinter.Name = "fileSavePrinter"
        Me.fileSavePrinter.Size = New System.Drawing.Size(206, 22)
        Me.fileSavePrinter.Text = "Save Printer File"
        '
        'ctxFileSepTop
        '
        Me.ctxFileSepTop.Name = "ctxFileSepTop"
        Me.ctxFileSepTop.Size = New System.Drawing.Size(203, 6)
        '
        'fileOpenUserConfig
        '
        Me.fileOpenUserConfig.Image = Global.pm.My.Resources.Resources.file_open_icon
        Me.fileOpenUserConfig.Name = "fileOpenUserConfig"
        Me.fileOpenUserConfig.Size = New System.Drawing.Size(206, 22)
        Me.fileOpenUserConfig.Text = "Open User Configuration"
        '
        'fileSaveUserConfig
        '
        Me.fileSaveUserConfig.Image = Global.pm.My.Resources.Resources.file_save_as_icon
        Me.fileSaveUserConfig.Name = "fileSaveUserConfig"
        Me.fileSaveUserConfig.Size = New System.Drawing.Size(206, 22)
        Me.fileSaveUserConfig.Text = "Save User Configuration"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(203, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.pm.My.Resources.Resources.x
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxDebug})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'ctxDebug
        '
        Me.ctxDebug.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DebugWindowToolStripMenuItem, Me.ctxModeChange, Me.ctxUnsavedData})
        Me.ctxDebug.Image = Global.pm.My.Resources.Resources.kcm_system_icon
        Me.ctxDebug.Name = "ctxDebug"
        Me.ctxDebug.Size = New System.Drawing.Size(175, 22)
        Me.ctxDebug.Text = "Debug Information"
        '
        'DebugWindowToolStripMenuItem
        '
        Me.DebugWindowToolStripMenuItem.Image = Global.pm.My.Resources.Resources.alt_d
        Me.DebugWindowToolStripMenuItem.Name = "DebugWindowToolStripMenuItem"
        Me.DebugWindowToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.DebugWindowToolStripMenuItem.Text = "Debug Window"
        '
        'ctxModeChange
        '
        Me.ctxModeChange.Name = "ctxModeChange"
        Me.ctxModeChange.Size = New System.Drawing.Size(182, 22)
        Me.ctxModeChange.Text = "Change to <> Mode"
        '
        'ctxUnsavedData
        '
        Me.ctxUnsavedData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.mnuUnsavedUserData, Me.pmUnsavedConfigData, Me.ToolStripSeparator2})
        Me.ctxUnsavedData.Name = "ctxUnsavedData"
        Me.ctxUnsavedData.Size = New System.Drawing.Size(182, 22)
        Me.ctxUnsavedData.Text = "Unsaved Data"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(166, 6)
        '
        'mnuUnsavedUserData
        '
        Me.mnuUnsavedUserData.Name = "mnuUnsavedUserData"
        Me.mnuUnsavedUserData.Size = New System.Drawing.Size(169, 22)
        Me.mnuUnsavedUserData.Text = "User"
        '
        'pmUnsavedConfigData
        '
        Me.pmUnsavedConfigData.Name = "pmUnsavedConfigData"
        Me.pmUnsavedConfigData.Size = New System.Drawing.Size(169, 22)
        Me.pmUnsavedConfigData.Text = "pm Configuration"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(166, 6)
        '
        'PrintersToolStripMenuItem
        '
        Me.PrintersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConnectPrinters, Me.ShowDebugWindowToolStripMenuItem})
        Me.PrintersToolStripMenuItem.Name = "PrintersToolStripMenuItem"
        Me.PrintersToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.PrintersToolStripMenuItem.Text = "Printers"
        '
        'mnuConnectPrinters
        '
        Me.mnuConnectPrinters.Image = Global.pm.My.Resources.Resources.alt_c
        Me.mnuConnectPrinters.Name = "mnuConnectPrinters"
        Me.mnuConnectPrinters.Size = New System.Drawing.Size(188, 22)
        Me.mnuConnectPrinters.Text = "Connect My Printers"
        '
        'ShowDebugWindowToolStripMenuItem
        '
        Me.ShowDebugWindowToolStripMenuItem.Name = "ShowDebugWindowToolStripMenuItem"
        Me.ShowDebugWindowToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ShowDebugWindowToolStripMenuItem.Text = "Show Debug Window"
        '
        'grpPrinters
        '
        Me.grpPrinters.Controls.Add(Me.cmdConnect)
        Me.grpPrinters.Controls.Add(Me.treePrinters)
        Me.grpPrinters.Location = New System.Drawing.Point(12, 27)
        Me.grpPrinters.Name = "grpPrinters"
        Me.grpPrinters.Size = New System.Drawing.Size(582, 359)
        Me.grpPrinters.TabIndex = 1
        Me.grpPrinters.TabStop = False
        Me.grpPrinters.Text = "Available Printers"
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(415, 315)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(161, 23)
        Me.cmdConnect.TabIndex = 1
        Me.cmdConnect.Text = "Connect My Printers"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'treePrinters
        '
        Me.treePrinters.Location = New System.Drawing.Point(12, 19)
        Me.treePrinters.Name = "treePrinters"
        Me.treePrinters.Size = New System.Drawing.Size(296, 319)
        Me.treePrinters.TabIndex = 0
        '
        'ctxTree
        '
        Me.ctxTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxFolderAdmin})
        Me.ctxTree.Name = "ctxTree"
        Me.ctxTree.Size = New System.Drawing.Size(154, 26)
        '
        'ctxFolderAdmin
        '
        Me.ctxFolderAdmin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxAdminPrinters, Me.ctxAdminFolders})
        Me.ctxFolderAdmin.Image = Global.pm.My.Resources.Resources.kcm_system_icon
        Me.ctxFolderAdmin.Name = "ctxFolderAdmin"
        Me.ctxFolderAdmin.Size = New System.Drawing.Size(153, 22)
        Me.ctxFolderAdmin.Text = "Administration"
        '
        'ctxAdminPrinters
        '
        Me.ctxAdminPrinters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxAdminPrinterNew})
        Me.ctxAdminPrinters.Image = Global.pm.My.Resources.Resources.printer
        Me.ctxAdminPrinters.Name = "ctxAdminPrinters"
        Me.ctxAdminPrinters.Size = New System.Drawing.Size(114, 22)
        Me.ctxAdminPrinters.Text = "Printers"
        '
        'ctxAdminPrinterNew
        '
        Me.ctxAdminPrinterNew.Image = Global.pm.My.Resources.Resources.printer
        Me.ctxAdminPrinterNew.Name = "ctxAdminPrinterNew"
        Me.ctxAdminPrinterNew.Size = New System.Drawing.Size(161, 22)
        Me.ctxAdminPrinterNew.Text = "Add New Printer"
        '
        'ctxAdminFolders
        '
        Me.ctxAdminFolders.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxAdminFolderNew, Me.ctxAdminFolderRemove})
        Me.ctxAdminFolders.Image = Global.pm.My.Resources.Resources.new_folder
        Me.ctxAdminFolders.Name = "ctxAdminFolders"
        Me.ctxAdminFolders.Size = New System.Drawing.Size(114, 22)
        Me.ctxAdminFolders.Text = "Folders"
        '
        'ctxAdminFolderNew
        '
        Me.ctxAdminFolderNew.Image = Global.pm.My.Resources.Resources.new_folder
        Me.ctxAdminFolderNew.Name = "ctxAdminFolderNew"
        Me.ctxAdminFolderNew.Size = New System.Drawing.Size(200, 22)
        Me.ctxAdminFolderNew.Text = "Add New Folder"
        '
        'ctxAdminFolderRemove
        '
        Me.ctxAdminFolderRemove.Image = Global.pm.My.Resources.Resources.edit_delete_icon
        Me.ctxAdminFolderRemove.Name = "ctxAdminFolderRemove"
        Me.ctxAdminFolderRemove.Size = New System.Drawing.Size(200, 22)
        Me.ctxAdminFolderRemove.Text = "Remove Selected Folder"
        '
        'inFile
        '
        Me.inFile.DefaultExt = "pm"
        Me.inFile.FileName = "*.pmc"
        Me.inFile.Filter = "pm Configuration Files (*.pmc)|*.pmc|All Files (*.*)|*.*"
        Me.inFile.Title = "pm.Open"
        '
        'ctxPrinters
        '
        Me.ctxPrinters.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxPrinterAdmin, Me.ctxSetDefaultPrinter})
        Me.ctxPrinters.Name = "ctxPrinters"
        Me.ctxPrinters.Size = New System.Drawing.Size(184, 48)
        '
        'ctxPrinterAdmin
        '
        Me.ctxPrinterAdmin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxAdminAddPrinter, Me.ctxEditPrinter, Me.ctxAdminRemovePrinter})
        Me.ctxPrinterAdmin.Image = Global.pm.My.Resources.Resources.kcm_system_icon
        Me.ctxPrinterAdmin.Name = "ctxPrinterAdmin"
        Me.ctxPrinterAdmin.Size = New System.Drawing.Size(183, 22)
        Me.ctxPrinterAdmin.Text = "Admin"
        '
        'ctxAdminAddPrinter
        '
        Me.ctxAdminAddPrinter.Image = Global.pm.My.Resources.Resources.alt_a
        Me.ctxAdminAddPrinter.Name = "ctxAdminAddPrinter"
        Me.ctxAdminAddPrinter.Size = New System.Drawing.Size(155, 22)
        Me.ctxAdminAddPrinter.Text = "Add Printer"
        '
        'ctxEditPrinter
        '
        Me.ctxEditPrinter.Image = Global.pm.My.Resources.Resources.kcm_system_icon
        Me.ctxEditPrinter.Name = "ctxEditPrinter"
        Me.ctxEditPrinter.Size = New System.Drawing.Size(155, 22)
        Me.ctxEditPrinter.Text = "Edit Printer"
        '
        'ctxAdminRemovePrinter
        '
        Me.ctxAdminRemovePrinter.Image = Global.pm.My.Resources.Resources.edit_delete_icon
        Me.ctxAdminRemovePrinter.Name = "ctxAdminRemovePrinter"
        Me.ctxAdminRemovePrinter.Size = New System.Drawing.Size(155, 22)
        Me.ctxAdminRemovePrinter.Text = "Remove Printer"
        '
        'ctxSetDefaultPrinter
        '
        Me.ctxSetDefaultPrinter.Name = "ctxSetDefaultPrinter"
        Me.ctxSetDefaultPrinter.Size = New System.Drawing.Size(183, 22)
        Me.ctxSetDefaultPrinter.Text = "Set as Default Printer"
        '
        'outFile
        '
        Me.outFile.DefaultExt = "pm"
        Me.outFile.FileName = "*.pmc"
        Me.outFile.Filter = "pm Configuration Files (*.pmc)|*.pmc|All Files (*.*)|*.*"
        Me.outFile.Title = "pm.Save"
        '
        'sUSerFile
        '
        Me.sUSerFile.DefaultExt = "pmu"
        Me.sUSerFile.Filter = "pm User Configuration Files (*.pmu)|*.pmu|All Files (*.*)|*.*"
        '
        'oUserFile
        '
        Me.oUserFile.AddExtension = False
        Me.oUserFile.DefaultExt = "pmu"
        Me.oUserFile.FileName = "*.pmu"
        Me.oUserFile.Filter = "pm User Configuration Files (*.pmu)|*.pmu|All Files (*.*)|*.*"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status, Me.prgLabel, Me.Progress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 417)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(741, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(726, 17)
        Me.status.Spring = True
        Me.status.Text = "Your default printer is: <not selected>"
        Me.status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'prgLabel
        '
        Me.prgLabel.Name = "prgLabel"
        Me.prgLabel.Size = New System.Drawing.Size(42, 17)
        Me.prgLabel.Text = "Status:"
        Me.prgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.prgLabel.Visible = False
        '
        'Progress
        '
        Me.Progress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Progress.Name = "Progress"
        Me.Progress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Progress.Size = New System.Drawing.Size(100, 16)
        Me.Progress.Visible = False
        '
        'DragCounter
        '
        Me.DragCounter.Interval = 3000
        '
        'pm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 439)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnu)
        Me.Controls.Add(Me.grpPrinters)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnu
        Me.Name = "pm"
        Me.Text = "Printer Management"
        Me.mnu.ResumeLayout(False)
        Me.mnu.PerformLayout()
        Me.grpPrinters.ResumeLayout(False)
        Me.ctxTree.ResumeLayout(False)
        Me.ctxPrinters.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxDebug As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebugWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpPrinters As System.Windows.Forms.GroupBox
    Friend WithEvents treePrinters As System.Windows.Forms.TreeView
    Friend WithEvents ctxTree As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents inFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents fileLoadPrinter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fileSavePrinter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxPrinters As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxPrinterAdmin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxAdminAddPrinter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxAdminRemovePrinter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxSetDefaultPrinter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxModeChange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxFolderAdmin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxAdminPrinters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxAdminPrinterNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxAdminFolders As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxAdminFolderNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxAdminFolderRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents outFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ctxUnsavedData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxFileSepTop As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents fileSaveUserConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fileOpenUserConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sUSerFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents oUserFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PrintersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConnectPrinters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUnsavedUserData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pmUnsavedConfigData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Progress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents DragCounter As System.Windows.Forms.Timer
    Friend WithEvents ctxEditPrinter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents prgLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ShowDebugWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdConnect As System.Windows.Forms.Button

End Class
