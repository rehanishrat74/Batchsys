<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintCodes
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
        Me.btnShow = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.lsbPrintedCodes = New System.Windows.Forms.ListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbRegions
        '
        Me.cmbRegions.FormattingEnabled = True
        Me.cmbRegions.Location = New System.Drawing.Point(105, 84)
        Me.cmbRegions.Name = "cmbRegions"
        Me.cmbRegions.Size = New System.Drawing.Size(167, 21)
        Me.cmbRegions.TabIndex = 50
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(30, 88)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(41, 13)
        Me.lblRegion.TabIndex = 49
        Me.lblRegion.Text = "Region"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Select Date"
        '
        'cmbPacket
        '
        Me.cmbPacket.FormattingEnabled = True
        Me.cmbPacket.Location = New System.Drawing.Point(105, 13)
        Me.cmbPacket.Name = "cmbPacket"
        Me.cmbPacket.Size = New System.Drawing.Size(167, 21)
        Me.cmbPacket.TabIndex = 46
        Me.cmbPacket.Visible = False
        '
        'lblPacket
        '
        Me.lblPacket.AutoSize = True
        Me.lblPacket.Location = New System.Drawing.Point(30, 17)
        Me.lblPacket.Name = "lblPacket"
        Me.lblPacket.Size = New System.Drawing.Size(64, 13)
        Me.lblPacket.TabIndex = 47
        Me.lblPacket.Text = "Packet Size"
        Me.lblPacket.Visible = False
        '
        'cmbProduct
        '
        Me.cmbProduct.FormattingEnabled = True
        Me.cmbProduct.Location = New System.Drawing.Point(105, 45)
        Me.cmbProduct.Name = "cmbProduct"
        Me.cmbProduct.Size = New System.Drawing.Size(167, 21)
        Me.cmbProduct.TabIndex = 44
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(30, 49)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(44, 13)
        Me.lblProduct.TabIndex = 45
        Me.lblProduct.Text = "Product"
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(223, 140)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(95, 20)
        Me.dtTo.TabIndex = 43
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(186, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "To"
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(75, 140)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(95, 20)
        Me.dtFrom.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "From"
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(137, 186)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(87, 23)
        Me.btnShow.TabIndex = 37
        Me.btnShow.Text = "Print Codes"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Printed Codes : "
        '
        'lsbPrintedCodes
        '
        Me.lsbPrintedCodes.FormattingEnabled = True
        Me.lsbPrintedCodes.Location = New System.Drawing.Point(126, 229)
        Me.lsbPrintedCodes.Name = "lsbPrintedCodes"
        Me.lsbPrintedCodes.Size = New System.Drawing.Size(120, 95)
        Me.lsbPrintedCodes.TabIndex = 52
        Me.lsbPrintedCodes.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnShow)
        Me.GroupBox1.Controls.Add(Me.lsbPrintedCodes)
        Me.GroupBox1.Controls.Add(Me.lblRegion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbRegions)
        Me.GroupBox1.Controls.Add(Me.dtTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtFrom)
        Me.GroupBox1.Controls.Add(Me.cmbPacket)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblProduct)
        Me.GroupBox1.Controls.Add(Me.cmbProduct)
        Me.GroupBox1.Controls.Add(Me.lblPacket)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 330)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Print Security Code"
        '
        'frmPrintCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 366)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(369, 393)
        Me.MinimumSize = New System.Drawing.Size(369, 393)
        Me.Name = "frmPrintCodes"
        Me.ShowIcon = False
        Me.Text = "Print Security Codes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbRegions As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPacket As System.Windows.Forms.ComboBox
    Friend WithEvents lblPacket As System.Windows.Forms.Label
    Friend WithEvents cmbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lsbPrintedCodes As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
