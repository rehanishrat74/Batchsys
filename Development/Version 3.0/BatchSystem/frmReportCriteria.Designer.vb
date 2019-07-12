<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportCriteria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportCriteria))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmbRegions = New System.Windows.Forms.ComboBox
        Me.lblRegion = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbPacket = New System.Windows.Forms.ComboBox
        Me.lblPacket = New System.Windows.Forms.Label
        Me.cmbProduct = New System.Windows.Forms.ComboBox
        Me.lblProduct = New System.Windows.Forms.Label
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.rdoBatch2 = New System.Windows.Forms.RadioButton
        Me.rdoBatch = New System.Windows.Forms.RadioButton
        Me.btnReport = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmbRegions)
        Me.GroupBox4.Controls.Add(Me.lblRegion)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.cmbPacket)
        Me.GroupBox4.Controls.Add(Me.lblPacket)
        Me.GroupBox4.Controls.Add(Me.cmbProduct)
        Me.GroupBox4.Controls.Add(Me.lblProduct)
        Me.GroupBox4.Controls.Add(Me.dtTo)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.dtFrom)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.rdoBatch2)
        Me.GroupBox4.Controls.Add(Me.rdoBatch)
        Me.GroupBox4.Controls.Add(Me.btnReport)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(341, 330)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Report"
        '
        'cmbRegions
        '
        Me.cmbRegions.FormattingEnabled = True
        Me.cmbRegions.Location = New System.Drawing.Point(104, 96)
        Me.cmbRegions.Name = "cmbRegions"
        Me.cmbRegions.Size = New System.Drawing.Size(167, 21)
        Me.cmbRegions.TabIndex = 36
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(30, 102)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(41, 13)
        Me.lblRegion.TabIndex = 35
        Me.lblRegion.Text = "Region"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 204)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Select Date"
        '
        'cmbPacket
        '
        Me.cmbPacket.Enabled = False
        Me.cmbPacket.FormattingEnabled = True
        Me.cmbPacket.Location = New System.Drawing.Point(104, 14)
        Me.cmbPacket.Name = "cmbPacket"
        Me.cmbPacket.Size = New System.Drawing.Size(167, 21)
        Me.cmbPacket.TabIndex = 32
        Me.cmbPacket.Visible = False
        '
        'lblPacket
        '
        Me.lblPacket.AutoSize = True
        Me.lblPacket.Enabled = False
        Me.lblPacket.Location = New System.Drawing.Point(30, 17)
        Me.lblPacket.Name = "lblPacket"
        Me.lblPacket.Size = New System.Drawing.Size(64, 13)
        Me.lblPacket.TabIndex = 33
        Me.lblPacket.Text = "Packet Size"
        Me.lblPacket.Visible = False
        '
        'cmbProduct
        '
        Me.cmbProduct.FormattingEnabled = True
        Me.cmbProduct.Location = New System.Drawing.Point(104, 59)
        Me.cmbProduct.Name = "cmbProduct"
        Me.cmbProduct.Size = New System.Drawing.Size(167, 21)
        Me.cmbProduct.TabIndex = 30
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(30, 59)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(44, 13)
        Me.lblProduct.TabIndex = 31
        Me.lblProduct.Text = "Product"
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(228, 223)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(95, 20)
        Me.dtTo.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(183, 227)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "To"
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(72, 223)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(95, 20)
        Me.dtFrom.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "From"
        '
        'rdoBatch2
        '
        Me.rdoBatch2.AutoSize = True
        Me.rdoBatch2.Location = New System.Drawing.Point(30, 171)
        Me.rdoBatch2.Name = "rdoBatch2"
        Me.rdoBatch2.Size = New System.Drawing.Size(140, 17)
        Me.rdoBatch2.TabIndex = 15
        Me.rdoBatch2.Text = "Security Code Uploaded"
        Me.rdoBatch2.UseVisualStyleBackColor = True
        '
        'rdoBatch
        '
        Me.rdoBatch.AutoSize = True
        Me.rdoBatch.Checked = True
        Me.rdoBatch.Location = New System.Drawing.Point(30, 148)
        Me.rdoBatch.Name = "rdoBatch"
        Me.rdoBatch.Size = New System.Drawing.Size(160, 17)
        Me.rdoBatch.TabIndex = 14
        Me.rdoBatch.TabStop = True
        Me.rdoBatch.Text = "Security Code Not Uploaded"
        Me.rdoBatch.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(30, 282)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(122, 23)
        Me.btnReport.TabIndex = 7
        Me.btnReport.Text = "Show"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        '
        'frmReportCriteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 366)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(369, 393)
        Me.MinimumSize = New System.Drawing.Size(369, 393)
        Me.Name = "frmReportCriteria"
        Me.ShowIcon = False
        Me.Text = "Report Criteria"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rdoBatch2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBatch As System.Windows.Forms.RadioButton
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents cmbPacket As System.Windows.Forms.ComboBox
    Friend WithEvents lblPacket As System.Windows.Forms.Label
    Friend WithEvents cmbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbRegions As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegion As System.Windows.Forms.Label
End Class
