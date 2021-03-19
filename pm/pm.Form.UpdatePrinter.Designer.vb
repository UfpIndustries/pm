<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdatePrinter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdatePrinter))
        Me.grpUpdatePrinter = New System.Windows.Forms.GroupBox
        Me.picPrinter = New System.Windows.Forms.PictureBox
        Me.txtOPrinterName = New System.Windows.Forms.TextBox
        Me.txtOPrinterShare = New System.Windows.Forms.TextBox
        Me.txtOPrinterPath = New System.Windows.Forms.TextBox
        Me.txtPrinterName = New System.Windows.Forms.TextBox
        Me.txtPrinterShare = New System.Windows.Forms.TextBox
        Me.txtPrinterPath = New System.Windows.Forms.TextBox
        Me.lblPrinterName = New System.Windows.Forms.Label
        Me.lblPrinterShare = New System.Windows.Forms.Label
        Me.lblPrinterPath = New System.Windows.Forms.Label
        Me.lblOldValue = New System.Windows.Forms.Label
        Me.lblNewValue = New System.Windows.Forms.Label
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.grpUpdatePrinter.SuspendLayout()
        CType(Me.picPrinter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpUpdatePrinter
        '
        Me.grpUpdatePrinter.Controls.Add(Me.picPrinter)
        Me.grpUpdatePrinter.Location = New System.Drawing.Point(12, 12)
        Me.grpUpdatePrinter.Name = "grpUpdatePrinter"
        Me.grpUpdatePrinter.Size = New System.Drawing.Size(147, 137)
        Me.grpUpdatePrinter.TabIndex = 0
        Me.grpUpdatePrinter.TabStop = False
        Me.grpUpdatePrinter.Text = "Update Printer"
        '
        'picPrinter
        '
        Me.picPrinter.Image = Global.pm.My.Resources.Resources.printer
        Me.picPrinter.Location = New System.Drawing.Point(6, 12)
        Me.picPrinter.Name = "picPrinter"
        Me.picPrinter.Size = New System.Drawing.Size(135, 119)
        Me.picPrinter.TabIndex = 0
        Me.picPrinter.TabStop = False
        '
        'txtOPrinterName
        '
        Me.txtOPrinterName.Enabled = False
        Me.txtOPrinterName.Location = New System.Drawing.Point(273, 48)
        Me.txtOPrinterName.Name = "txtOPrinterName"
        Me.txtOPrinterName.Size = New System.Drawing.Size(190, 20)
        Me.txtOPrinterName.TabIndex = 1
        Me.txtOPrinterName.TabStop = False
        '
        'txtOPrinterShare
        '
        Me.txtOPrinterShare.Enabled = False
        Me.txtOPrinterShare.Location = New System.Drawing.Point(273, 74)
        Me.txtOPrinterShare.Name = "txtOPrinterShare"
        Me.txtOPrinterShare.Size = New System.Drawing.Size(190, 20)
        Me.txtOPrinterShare.TabIndex = 2
        Me.txtOPrinterShare.TabStop = False
        '
        'txtOPrinterPath
        '
        Me.txtOPrinterPath.Enabled = False
        Me.txtOPrinterPath.Location = New System.Drawing.Point(273, 100)
        Me.txtOPrinterPath.Name = "txtOPrinterPath"
        Me.txtOPrinterPath.Size = New System.Drawing.Size(190, 20)
        Me.txtOPrinterPath.TabIndex = 3
        Me.txtOPrinterPath.TabStop = False
        '
        'txtPrinterName
        '
        Me.txtPrinterName.Location = New System.Drawing.Point(507, 48)
        Me.txtPrinterName.Name = "txtPrinterName"
        Me.txtPrinterName.Size = New System.Drawing.Size(190, 20)
        Me.txtPrinterName.TabIndex = 4
        '
        'txtPrinterShare
        '
        Me.txtPrinterShare.Location = New System.Drawing.Point(507, 74)
        Me.txtPrinterShare.Name = "txtPrinterShare"
        Me.txtPrinterShare.Size = New System.Drawing.Size(190, 20)
        Me.txtPrinterShare.TabIndex = 5
        '
        'txtPrinterPath
        '
        Me.txtPrinterPath.Location = New System.Drawing.Point(507, 100)
        Me.txtPrinterPath.Name = "txtPrinterPath"
        Me.txtPrinterPath.Size = New System.Drawing.Size(190, 20)
        Me.txtPrinterPath.TabIndex = 6
        '
        'lblPrinterName
        '
        Me.lblPrinterName.AutoSize = True
        Me.lblPrinterName.Location = New System.Drawing.Point(184, 51)
        Me.lblPrinterName.Name = "lblPrinterName"
        Me.lblPrinterName.Size = New System.Drawing.Size(68, 13)
        Me.lblPrinterName.TabIndex = 7
        Me.lblPrinterName.Text = "Printer Name"
        '
        'lblPrinterShare
        '
        Me.lblPrinterShare.AutoSize = True
        Me.lblPrinterShare.Location = New System.Drawing.Point(184, 77)
        Me.lblPrinterShare.Name = "lblPrinterShare"
        Me.lblPrinterShare.Size = New System.Drawing.Size(68, 13)
        Me.lblPrinterShare.TabIndex = 8
        Me.lblPrinterShare.Text = "Printer Share"
        '
        'lblPrinterPath
        '
        Me.lblPrinterPath.AutoSize = True
        Me.lblPrinterPath.Location = New System.Drawing.Point(190, 103)
        Me.lblPrinterPath.Name = "lblPrinterPath"
        Me.lblPrinterPath.Size = New System.Drawing.Size(62, 13)
        Me.lblPrinterPath.TabIndex = 9
        Me.lblPrinterPath.Text = "Printer Path"
        '
        'lblOldValue
        '
        Me.lblOldValue.AutoSize = True
        Me.lblOldValue.Location = New System.Drawing.Point(270, 24)
        Me.lblOldValue.Name = "lblOldValue"
        Me.lblOldValue.Size = New System.Drawing.Size(53, 13)
        Me.lblOldValue.TabIndex = 10
        Me.lblOldValue.Text = "Old Value"
        '
        'lblNewValue
        '
        Me.lblNewValue.AutoSize = True
        Me.lblNewValue.Location = New System.Drawing.Point(504, 24)
        Me.lblNewValue.Name = "lblNewValue"
        Me.lblNewValue.Size = New System.Drawing.Size(59, 13)
        Me.lblNewValue.TabIndex = 11
        Me.lblNewValue.Text = "New Value"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(622, 126)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 12
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(507, 126)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmUpdatePrinter
        '
        Me.ClientSize = New System.Drawing.Size(723, 162)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.lblNewValue)
        Me.Controls.Add(Me.lblOldValue)
        Me.Controls.Add(Me.lblPrinterPath)
        Me.Controls.Add(Me.lblPrinterShare)
        Me.Controls.Add(Me.lblPrinterName)
        Me.Controls.Add(Me.txtPrinterPath)
        Me.Controls.Add(Me.txtPrinterShare)
        Me.Controls.Add(Me.txtPrinterName)
        Me.Controls.Add(Me.txtOPrinterPath)
        Me.Controls.Add(Me.txtOPrinterShare)
        Me.Controls.Add(Me.txtOPrinterName)
        Me.Controls.Add(Me.grpUpdatePrinter)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUpdatePrinter"
        Me.Text = "pm.Update Printer"
        Me.grpUpdatePrinter.ResumeLayout(False)
        CType(Me.picPrinter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpUpdatePrinter As System.Windows.Forms.GroupBox
    Friend WithEvents picPrinter As System.Windows.Forms.PictureBox
    Friend WithEvents txtOPrinterName As System.Windows.Forms.TextBox
    Friend WithEvents txtOPrinterShare As System.Windows.Forms.TextBox
    Friend WithEvents txtOPrinterPath As System.Windows.Forms.TextBox
    Friend WithEvents txtPrinterName As System.Windows.Forms.TextBox
    Friend WithEvents txtPrinterShare As System.Windows.Forms.TextBox
    Friend WithEvents txtPrinterPath As System.Windows.Forms.TextBox
    Friend WithEvents lblPrinterName As System.Windows.Forms.Label
    Friend WithEvents lblPrinterShare As System.Windows.Forms.Label
    Friend WithEvents lblPrinterPath As System.Windows.Forms.Label
    Friend WithEvents lblOldValue As System.Windows.Forms.Label
    Friend WithEvents lblNewValue As System.Windows.Forms.Label
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
