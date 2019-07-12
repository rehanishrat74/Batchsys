<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLightSecurityCode
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnUploadCodes = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.txtFilePath = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnFileBrowse = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnUploadCodes
        '
        Me.btnUploadCodes.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnUploadCodes.Location = New System.Drawing.Point(48, 186)
        Me.btnUploadCodes.Name = "btnUploadCodes"
        Me.btnUploadCodes.Size = New System.Drawing.Size(122, 22)
        Me.btnUploadCodes.TabIndex = 0
        Me.btnUploadCodes.Text = "Upload Codes"
        Me.btnUploadCodes.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtFilePath
        '
        Me.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilePath.Location = New System.Drawing.Point(48, 82)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(232, 20)
        Me.txtFilePath.TabIndex = 1
        Me.txtFilePath.Text = "[Enter File Path here...]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "File"
        '
        'btnFileBrowse
        '
        Me.btnFileBrowse.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnFileBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFileBrowse.Location = New System.Drawing.Point(225, 108)
        Me.btnFileBrowse.Name = "btnFileBrowse"
        Me.btnFileBrowse.Size = New System.Drawing.Size(55, 23)
        Me.btnFileBrowse.TabIndex = 3
        Me.btnFileBrowse.Text = "Browse"
        Me.btnFileBrowse.UseVisualStyleBackColor = True
        '
        'frmLightSecurityCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.btnFileBrowse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFilePath)
        Me.Controls.Add(Me.btnUploadCodes)
        Me.MaximumSize = New System.Drawing.Size(300, 300)
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "frmLightSecurityCode"
        Me.ShowIcon = False
        Me.Text = "Light Security Codes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUploadCodes As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFileBrowse As System.Windows.Forms.Button

End Class
