<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class newPrinter
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
        Me.GroupBox = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.txtShare = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblShare = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.lblConfigurePrinter = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.GroupBox.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.cmdUpdate)
        Me.GroupBox.Controls.Add(Me.cmdCancel)
        Me.GroupBox.Controls.Add(Me.cmdAdd)
        Me.GroupBox.Controls.Add(Me.txtPath)
        Me.GroupBox.Controls.Add(Me.txtShare)
        Me.GroupBox.Controls.Add(Me.txtName)
        Me.GroupBox.Controls.Add(Me.lblPath)
        Me.GroupBox.Controls.Add(Me.lblShare)
        Me.GroupBox.Controls.Add(Me.lblName)
        Me.GroupBox.Controls.Add(Me.lblConfigurePrinter)
        Me.GroupBox.Controls.Add(Me.PictureBox1)
        Me.GroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(613, 154)
        Me.GroupBox.TabIndex = 0
        Me.GroupBox.TabStop = False
        Me.GroupBox.Text = "New Printer Configuration"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(438, 122)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(528, 121)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 3
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.DarkGray
        Me.txtPath.Enabled = False
        Me.txtPath.ForeColor = System.Drawing.Color.SpringGreen
        Me.txtPath.Location = New System.Drawing.Point(317, 95)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(286, 20)
        Me.txtPath.TabIndex = 7
        Me.txtPath.TabStop = False
        '
        'txtShare
        '
        Me.txtShare.Location = New System.Drawing.Point(317, 69)
        Me.txtShare.Name = "txtShare"
        Me.txtShare.Size = New System.Drawing.Size(286, 20)
        Me.txtShare.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(317, 43)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(286, 20)
        Me.txtName.TabIndex = 1
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(254, 98)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(57, 13)
        Me.lblPath.TabIndex = 4
        Me.lblPath.Text = "Tree Path:"
        '
        'lblShare
        '
        Me.lblShare.AutoSize = True
        Me.lblShare.Location = New System.Drawing.Point(240, 72)
        Me.lblShare.Name = "lblShare"
        Me.lblShare.Size = New System.Drawing.Size(71, 13)
        Me.lblShare.TabIndex = 3
        Me.lblShare.Text = "Printer Share:"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(240, 46)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(71, 13)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Printer Name:"
        '
        'lblConfigurePrinter
        '
        Me.lblConfigurePrinter.AutoSize = True
        Me.lblConfigurePrinter.Location = New System.Drawing.Point(208, 19)
        Me.lblConfigurePrinter.Name = "lblConfigurePrinter"
        Me.lblConfigurePrinter.Size = New System.Drawing.Size(103, 13)
        Me.lblConfigurePrinter.TabIndex = 1
        Me.lblConfigurePrinter.Text = "Configure the Printer"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.pm.My.Resources.Resources.printer
        Me.PictureBox1.Location = New System.Drawing.Point(6, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(151, 125)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(528, 122)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 21)
        Me.cmdUpdate.TabIndex = 8
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        Me.cmdUpdate.Visible = False
        '
        'newPrinter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(632, 174)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox)
        Me.Name = "newPrinter"
        Me.Text = "newPrinter"
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents txtShare As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblShare As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblConfigurePrinter As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
End Class
