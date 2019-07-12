<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnOpen = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.chkAutoSearch = New System.Windows.Forms.CheckBox
        Me.cmbPort = New System.Windows.Forms.ComboBox
        Me.cmbBaudRate = New System.Windows.Forms.ComboBox
        Me.lblLabel1 = New System.Windows.Forms.Label
        Me.lblLabel2 = New System.Windows.Forms.Label
        Me.lblLabel3 = New System.Windows.Forms.Label
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnButton1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(198, 29)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(129, 23)
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "Open Connection"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(198, 60)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(129, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close Connection"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'chkAutoSearch
        '
        Me.chkAutoSearch.AutoSize = True
        Me.chkAutoSearch.Location = New System.Drawing.Point(198, 89)
        Me.chkAutoSearch.Name = "chkAutoSearch"
        Me.chkAutoSearch.Size = New System.Drawing.Size(85, 17)
        Me.chkAutoSearch.TabIndex = 2
        Me.chkAutoSearch.Text = "Auto Search"
        Me.chkAutoSearch.UseVisualStyleBackColor = True
        '
        'cmbPort
        '
        Me.cmbPort.FormattingEnabled = True
        Me.cmbPort.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cmbPort.Location = New System.Drawing.Point(70, 31)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(121, 21)
        Me.cmbPort.TabIndex = 3
        '
        'cmbBaudRate
        '
        Me.cmbBaudRate.FormattingEnabled = True
        Me.cmbBaudRate.Items.AddRange(New Object() {"38400", "19200", "9600"})
        Me.cmbBaudRate.Location = New System.Drawing.Point(70, 62)
        Me.cmbBaudRate.Name = "cmbBaudRate"
        Me.cmbBaudRate.Size = New System.Drawing.Size(121, 21)
        Me.cmbBaudRate.TabIndex = 4
        '
        'lblLabel1
        '
        Me.lblLabel1.AutoSize = True
        Me.lblLabel1.Location = New System.Drawing.Point(5, 39)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(57, 13)
        Me.lblLabel1.TabIndex = 5
        Me.lblLabel1.Text = "Port Name"
        '
        'lblLabel2
        '
        Me.lblLabel2.AutoSize = True
        Me.lblLabel2.Location = New System.Drawing.Point(5, 70)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(58, 13)
        Me.lblLabel2.TabIndex = 6
        Me.lblLabel2.Text = "Baud Rate"
        '
        'lblLabel3
        '
        Me.lblLabel3.AutoSize = True
        Me.lblLabel3.Location = New System.Drawing.Point(4, 132)
        Me.lblLabel3.Name = "lblLabel3"
        Me.lblLabel3.Size = New System.Drawing.Size(50, 13)
        Me.lblLabel3.TabIndex = 7
        Me.lblLabel3.Text = "Message"
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(70, 129)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(121, 20)
        Me.txtMessage.TabIndex = 8
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(198, 127)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 9
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnButton1
        '
        Me.btnButton1.Location = New System.Drawing.Point(70, 100)
        Me.btnButton1.Name = "btnButton1"
        Me.btnButton1.Size = New System.Drawing.Size(75, 23)
        Me.btnButton1.TabIndex = 10
        Me.btnButton1.Text = "Test"
        Me.btnButton1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 167)
        Me.Controls.Add(Me.btnButton1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.lblLabel3)
        Me.Controls.Add(Me.lblLabel2)
        Me.Controls.Add(Me.lblLabel1)
        Me.Controls.Add(Me.cmbBaudRate)
        Me.Controls.Add(Me.cmbPort)
        Me.Controls.Add(Me.chkAutoSearch)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOpen)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chkAutoSearch As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel3 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnButton1 As System.Windows.Forms.Button

End Class
