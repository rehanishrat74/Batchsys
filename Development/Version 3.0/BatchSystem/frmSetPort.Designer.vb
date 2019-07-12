<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetPort
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
        Me.lblPort = New System.Windows.Forms.Label
        Me.lblSpeed = New System.Windows.Forms.Label
        Me.cmbPort = New System.Windows.Forms.ComboBox
        Me.cmbSpeed = New System.Windows.Forms.ComboBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.dgvPrinter = New System.Windows.Forms.DataGridView
        Me.btnClosPort = New System.Windows.Forms.Button
        Me.lsbIds = New System.Windows.Forms.ListBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ColId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColPrinter = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSpeed = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPrinter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(24, 23)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(26, 13)
        Me.lblPort.TabIndex = 0
        Me.lblPort.Text = "Port"
        '
        'lblSpeed
        '
        Me.lblSpeed.AutoSize = True
        Me.lblSpeed.Location = New System.Drawing.Point(24, 55)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(38, 13)
        Me.lblSpeed.TabIndex = 1
        Me.lblSpeed.Text = "Speed"
        '
        'cmbPort
        '
        Me.cmbPort.FormattingEnabled = True
        Me.cmbPort.Location = New System.Drawing.Point(88, 19)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(121, 21)
        Me.cmbPort.TabIndex = 2
        '
        'cmbSpeed
        '
        Me.cmbSpeed.FormattingEnabled = True
        Me.cmbSpeed.Location = New System.Drawing.Point(88, 51)
        Me.cmbSpeed.Name = "cmbSpeed"
        Me.cmbSpeed.Size = New System.Drawing.Size(121, 21)
        Me.cmbSpeed.TabIndex = 3
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(17, 301)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "Set"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(98, 301)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.cmbPort)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.lblPort)
        Me.GroupBox1.Controls.Add(Me.btnOk)
        Me.GroupBox1.Controls.Add(Me.cmbSpeed)
        Me.GroupBox1.Controls.Add(Me.lblSpeed)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 330)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configure Port"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.dgvPrinter)
        Me.GroupBox2.Controls.Add(Me.btnClosPort)
        Me.GroupBox2.Controls.Add(Me.lsbIds)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(17, 120)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(318, 175)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Printer Detected"
        '
        'btnSearch
        '
        Me.btnSearch.Enabled = False
        Me.btnSearch.Location = New System.Drawing.Point(87, 146)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dgvPrinter
        '
        Me.dgvPrinter.AllowUserToAddRows = False
        Me.dgvPrinter.AllowUserToDeleteRows = False
        Me.dgvPrinter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrinter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColId, Me.ColPrinter, Me.colPort, Me.colSpeed})
        Me.dgvPrinter.Location = New System.Drawing.Point(6, 19)
        Me.dgvPrinter.Name = "dgvPrinter"
        Me.dgvPrinter.ReadOnly = True
        Me.dgvPrinter.Size = New System.Drawing.Size(306, 121)
        Me.dgvPrinter.TabIndex = 11
        '
        'btnClosPort
        '
        Me.btnClosPort.Location = New System.Drawing.Point(6, 146)
        Me.btnClosPort.Name = "btnClosPort"
        Me.btnClosPort.Size = New System.Drawing.Size(75, 23)
        Me.btnClosPort.TabIndex = 10
        Me.btnClosPort.Text = "Close Port"
        Me.btnClosPort.UseVisualStyleBackColor = True
        '
        'lsbIds
        '
        Me.lsbIds.FormattingEnabled = True
        Me.lsbIds.Location = New System.Drawing.Point(6, 19)
        Me.lsbIds.Name = "lsbIds"
        Me.lsbIds.Size = New System.Drawing.Size(306, 121)
        Me.lsbIds.TabIndex = 9
        Me.lsbIds.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(17, 97)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(116, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Auto Detect Printer"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ColId
        '
        Me.ColId.HeaderText = "Printer ID"
        Me.ColId.Name = "ColId"
        Me.ColId.ReadOnly = True
        Me.ColId.Visible = False
        '
        'ColPrinter
        '
        Me.ColPrinter.HeaderText = "Printer"
        Me.ColPrinter.Name = "ColPrinter"
        Me.ColPrinter.ReadOnly = True
        '
        'colPort
        '
        Me.colPort.HeaderText = "Com Port"
        Me.colPort.Name = "colPort"
        Me.colPort.ReadOnly = True
        Me.colPort.Width = 80
        '
        'colSpeed
        '
        Me.colSpeed.HeaderText = "Speed"
        Me.colSpeed.Name = "colSpeed"
        Me.colSpeed.ReadOnly = True
        Me.colSpeed.Width = 80
        '
        'frmSetPort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 366)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(369, 393)
        Me.MinimumSize = New System.Drawing.Size(369, 393)
        Me.Name = "frmSetPort"
        Me.ShowIcon = False
        Me.Text = "Configure Port"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvPrinter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents cmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents lsbIds As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClosPort As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvPrinter As System.Windows.Forms.DataGridView
    Friend WithEvents ColId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPrinter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSpeed As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
