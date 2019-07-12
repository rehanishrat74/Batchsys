<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSerials1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSerials1))
        Me.grbSerials = New System.Windows.Forms.GroupBox
        Me.chkPrint = New System.Windows.Forms.CheckBox
        Me.cmbRegions = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTotalSerials = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbProduct = New System.Windows.Forms.ComboBox
        Me.lblProduct = New System.Windows.Forms.Label
        Me.btnSerials = New System.Windows.Forms.Button
        Me.btnUploadSerial = New System.Windows.Forms.Button
        Me.txtBatchSize = New System.Windows.Forms.TextBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lblRegion = New System.Windows.Forms.Label
        Me.cmbPacket = New System.Windows.Forms.ComboBox
        Me.lblPacket = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grbSerials.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbSerials
        '
        Me.grbSerials.Controls.Add(Me.chkPrint)
        Me.grbSerials.Controls.Add(Me.cmbRegions)
        Me.grbSerials.Controls.Add(Me.Label3)
        Me.grbSerials.Controls.Add(Me.txtTotalSerials)
        Me.grbSerials.Controls.Add(Me.Label2)
        Me.grbSerials.Controls.Add(Me.cmbProduct)
        Me.grbSerials.Controls.Add(Me.lblProduct)
        Me.grbSerials.Controls.Add(Me.btnSerials)
        Me.grbSerials.Controls.Add(Me.btnUploadSerial)
        Me.grbSerials.Controls.Add(Me.txtBatchSize)
        Me.grbSerials.Controls.Add(Me.ProgressBar1)
        Me.grbSerials.Controls.Add(Me.lblRegion)
        Me.grbSerials.Controls.Add(Me.cmbPacket)
        Me.grbSerials.Controls.Add(Me.lblPacket)
        Me.grbSerials.Location = New System.Drawing.Point(8, 20)
        Me.grbSerials.Name = "grbSerials"
        Me.grbSerials.Size = New System.Drawing.Size(341, 330)
        Me.grbSerials.TabIndex = 21
        Me.grbSerials.TabStop = False
        Me.grbSerials.Text = "Security Code"
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.Location = New System.Drawing.Point(205, 198)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(79, 17)
        Me.chkPrint.TabIndex = 34
        Me.chkPrint.Text = "Print codes"
        Me.chkPrint.UseVisualStyleBackColor = True
        Me.chkPrint.Visible = False
        '
        'cmbRegions
        '
        Me.cmbRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegions.FormattingEnabled = True
        Me.cmbRegions.Location = New System.Drawing.Point(122, 78)
        Me.cmbRegions.Name = "cmbRegions"
        Me.cmbRegions.Size = New System.Drawing.Size(167, 21)
        Me.cmbRegions.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Batch Size"
        '
        'txtTotalSerials
        '
        Me.txtTotalSerials.CausesValidation = False
        Me.txtTotalSerials.Enabled = False
        Me.txtTotalSerials.Location = New System.Drawing.Point(122, 151)
        Me.txtTotalSerials.Name = "txtTotalSerials"
        Me.txtTotalSerials.Size = New System.Drawing.Size(77, 20)
        Me.txtTotalSerials.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Total Codes"
        '
        'cmbProduct
        '
        Me.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProduct.FormattingEnabled = True
        Me.cmbProduct.Location = New System.Drawing.Point(122, 44)
        Me.cmbProduct.Name = "cmbProduct"
        Me.cmbProduct.Size = New System.Drawing.Size(167, 21)
        Me.cmbProduct.TabIndex = 19
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(49, 48)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(44, 13)
        Me.lblProduct.TabIndex = 26
        Me.lblProduct.Text = "Product"
        '
        'btnSerials
        '
        Me.btnSerials.Location = New System.Drawing.Point(52, 194)
        Me.btnSerials.Name = "btnSerials"
        Me.btnSerials.Size = New System.Drawing.Size(138, 23)
        Me.btnSerials.TabIndex = 22
        Me.btnSerials.Text = "Generate Security Codes"
        Me.btnSerials.UseVisualStyleBackColor = True
        '
        'btnUploadSerial
        '
        Me.btnUploadSerial.Location = New System.Drawing.Point(52, 238)
        Me.btnUploadSerial.Name = "btnUploadSerial"
        Me.btnUploadSerial.Size = New System.Drawing.Size(138, 23)
        Me.btnUploadSerial.TabIndex = 24
        Me.btnUploadSerial.Text = "Upload Security Codes"
        Me.btnUploadSerial.UseVisualStyleBackColor = True
        '
        'txtBatchSize
        '
        Me.txtBatchSize.CausesValidation = False
        Me.txtBatchSize.Location = New System.Drawing.Point(122, 115)
        Me.txtBatchSize.Name = "txtBatchSize"
        Me.txtBatchSize.Size = New System.Drawing.Size(77, 20)
        Me.txtBatchSize.TabIndex = 20
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(21, 282)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(298, 14)
        Me.ProgressBar1.TabIndex = 23
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(48, 84)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(41, 13)
        Me.lblRegion.TabIndex = 21
        Me.lblRegion.Text = "Region"
        '
        'cmbPacket
        '
        Me.cmbPacket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPacket.Enabled = False
        Me.cmbPacket.FormattingEnabled = True
        Me.cmbPacket.Location = New System.Drawing.Point(122, 17)
        Me.cmbPacket.Name = "cmbPacket"
        Me.cmbPacket.Size = New System.Drawing.Size(167, 21)
        Me.cmbPacket.TabIndex = 28
        Me.cmbPacket.Visible = False
        '
        'lblPacket
        '
        Me.lblPacket.AutoSize = True
        Me.lblPacket.Enabled = False
        Me.lblPacket.Location = New System.Drawing.Point(49, 21)
        Me.lblPacket.Name = "lblPacket"
        Me.lblPacket.Size = New System.Drawing.Size(64, 13)
        Me.lblPacket.TabIndex = 29
        Me.lblPacket.Text = "Packet Size"
        Me.lblPacket.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(150, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Label1"
        '
        'frmSerials1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 355)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grbSerials)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(369, 393)
        Me.MinimumSize = New System.Drawing.Size(369, 393)
        Me.Name = "frmSerials1"
        Me.ShowIcon = False
        Me.Text = "Security Code"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grbSerials.ResumeLayout(False)
        Me.grbSerials.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbSerials As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPacket As System.Windows.Forms.ComboBox
    Friend WithEvents lblPacket As System.Windows.Forms.Label
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents btnSerials As System.Windows.Forms.Button
    Friend WithEvents btnUploadSerial As System.Windows.Forms.Button
    Friend WithEvents txtBatchSize As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents txtTotalSerials As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbRegions As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
    Friend WithEvents cmbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
