<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class debug
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(debug))
        Me.grpUserMode = New System.Windows.Forms.GroupBox()
        Me.dtaUserSettings = New System.Windows.Forms.DataGridView()
        Me.dtaPrinters = New System.Windows.Forms.DataGridView()
        Me.txtDefPrinter = New System.Windows.Forms.TextBox()
        Me.lblDefPrinter = New System.Windows.Forms.Label()
        Me.grpAdminMode = New System.Windows.Forms.GroupBox()
        Me.prg = New System.Windows.Forms.ProgressBar()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.mnu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.inFile = New System.Windows.Forms.OpenFileDialog()
        Me.ctxUserData = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DelPrinter = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpUserMode.SuspendLayout()
        CType(Me.dtaUserSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtaPrinters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAdminMode.SuspendLayout()
        Me.mnu.SuspendLayout()
        Me.ctxUserData.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpUserMode
        '
        Me.grpUserMode.Controls.Add(Me.dtaUserSettings)
        Me.grpUserMode.Controls.Add(Me.dtaPrinters)
        Me.grpUserMode.Controls.Add(Me.txtDefPrinter)
        Me.grpUserMode.Controls.Add(Me.lblDefPrinter)
        Me.grpUserMode.Location = New System.Drawing.Point(12, 27)
        Me.grpUserMode.Name = "grpUserMode"
        Me.grpUserMode.Size = New System.Drawing.Size(400, 400)
        Me.grpUserMode.TabIndex = 0
        Me.grpUserMode.TabStop = False
        Me.grpUserMode.Text = "User Mode Debugging"
        '
        'dtaUserSettings
        '
        Me.dtaUserSettings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dtaUserSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtaUserSettings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtaUserSettings.Location = New System.Drawing.Point(6, 221)
        Me.dtaUserSettings.MultiSelect = False
        Me.dtaUserSettings.Name = "dtaUserSettings"
        Me.dtaUserSettings.ReadOnly = True
        Me.dtaUserSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtaUserSettings.Size = New System.Drawing.Size(388, 169)
        Me.dtaUserSettings.TabIndex = 3
        '
        'dtaPrinters
        '
        Me.dtaPrinters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtaPrinters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtaPrinters.Location = New System.Drawing.Point(6, 45)
        Me.dtaPrinters.Name = "dtaPrinters"
        Me.dtaPrinters.Size = New System.Drawing.Size(388, 169)
        Me.dtaPrinters.TabIndex = 2
        '
        'txtDefPrinter
        '
        Me.txtDefPrinter.Enabled = False
        Me.txtDefPrinter.Location = New System.Drawing.Point(89, 19)
        Me.txtDefPrinter.Name = "txtDefPrinter"
        Me.txtDefPrinter.Size = New System.Drawing.Size(305, 20)
        Me.txtDefPrinter.TabIndex = 1
        '
        'lblDefPrinter
        '
        Me.lblDefPrinter.AutoSize = True
        Me.lblDefPrinter.Location = New System.Drawing.Point(6, 22)
        Me.lblDefPrinter.Name = "lblDefPrinter"
        Me.lblDefPrinter.Size = New System.Drawing.Size(77, 13)
        Me.lblDefPrinter.TabIndex = 0
        Me.lblDefPrinter.Text = "Default Printer:"
        '
        'grpAdminMode
        '
        Me.grpAdminMode.Controls.Add(Me.prg)
        Me.grpAdminMode.Controls.Add(Me.lblLog)
        Me.grpAdminMode.Controls.Add(Me.txtLog)
        Me.grpAdminMode.Location = New System.Drawing.Point(420, 27)
        Me.grpAdminMode.Name = "grpAdminMode"
        Me.grpAdminMode.Size = New System.Drawing.Size(400, 400)
        Me.grpAdminMode.TabIndex = 1
        Me.grpAdminMode.TabStop = False
        Me.grpAdminMode.Text = "Admin Mode Debugging"
        '
        'prg
        '
        Me.prg.Location = New System.Drawing.Point(40, 16)
        Me.prg.Name = "prg"
        Me.prg.Size = New System.Drawing.Size(354, 16)
        Me.prg.TabIndex = 2
        Me.prg.Visible = False
        '
        'lblLog
        '
        Me.lblLog.AutoSize = True
        Me.lblLog.Location = New System.Drawing.Point(8, 19)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(25, 13)
        Me.lblLog.TabIndex = 1
        Me.lblLog.Text = "Log"
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.White
        Me.txtLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtLog.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.Black
        Me.txtLog.Location = New System.Drawing.Point(6, 45)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(387, 349)
        Me.txtLog.TabIndex = 0
        Me.txtLog.WordWrap = False
        '
        'mnu
        '
        Me.mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.mnu.Location = New System.Drawing.Point(0, 0)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(832, 24)
        Me.mnu.TabIndex = 2
        Me.mnu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'inFile
        '
        Me.inFile.FileName = "*.printers"
        '
        'ctxUserData
        '
        Me.ctxUserData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DelPrinter})
        Me.ctxUserData.Name = "ctxUserData"
        Me.ctxUserData.Size = New System.Drawing.Size(198, 26)
        '
        'DelPrinter
        '
        Me.DelPrinter.Image = Global.pm.My.Resources.Resources.edit_delete_icon
        Me.DelPrinter.Name = "DelPrinter"
        Me.DelPrinter.Size = New System.Drawing.Size(197, 22)
        Me.DelPrinter.Text = "Delete: <select printer>"
        '
        'debug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 433)
        Me.Controls.Add(Me.grpAdminMode)
        Me.Controls.Add(Me.grpUserMode)
        Me.Controls.Add(Me.mnu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnu
        Me.Name = "debug"
        Me.Text = "Printer Management - Debug Log"
        Me.grpUserMode.ResumeLayout(False)
        Me.grpUserMode.PerformLayout()
        CType(Me.dtaUserSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtaPrinters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAdminMode.ResumeLayout(False)
        Me.grpAdminMode.PerformLayout()
        Me.mnu.ResumeLayout(False)
        Me.mnu.PerformLayout()
        Me.ctxUserData.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpUserMode As System.Windows.Forms.GroupBox
    Friend WithEvents dtaPrinters As System.Windows.Forms.DataGridView
    Friend WithEvents txtDefPrinter As System.Windows.Forms.TextBox
    Friend WithEvents lblDefPrinter As System.Windows.Forms.Label
    Friend WithEvents grpAdminMode As System.Windows.Forms.GroupBox
    Friend WithEvents mnu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents inFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblLog As System.Windows.Forms.Label
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents dtaUserSettings As System.Windows.Forms.DataGridView
    Friend WithEvents prg As System.Windows.Forms.ProgressBar
    Friend WithEvents ctxUserData As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DelPrinter As System.Windows.Forms.ToolStripMenuItem
End Class
