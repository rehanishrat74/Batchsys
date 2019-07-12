<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduct
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
        Me.grbProduct = New System.Windows.Forms.GroupBox
        Me.cmbProducts1 = New System.Windows.Forms.ComboBox
        Me.txtProName = New System.Windows.Forms.TextBox
        Me.lblProName = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtProCode = New System.Windows.Forms.TextBox
        Me.lblProCode = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.lblProID = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnChildCancel = New System.Windows.Forms.Button
        Me.btnChidEdit = New System.Windows.Forms.Button
        Me.btnChildSave = New System.Windows.Forms.Button
        Me.btnChildDel = New System.Windows.Forms.Button
        Me.btnChildAdd = New System.Windows.Forms.Button
        Me.dtgPackets = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SKU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grbProduct.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgPackets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbProduct
        '
        Me.grbProduct.Controls.Add(Me.cmbProducts1)
        Me.grbProduct.Controls.Add(Me.txtProName)
        Me.grbProduct.Controls.Add(Me.lblProName)
        Me.grbProduct.Controls.Add(Me.btnCancel)
        Me.grbProduct.Controls.Add(Me.txtProCode)
        Me.grbProduct.Controls.Add(Me.lblProCode)
        Me.grbProduct.Controls.Add(Me.btnSave)
        Me.grbProduct.Controls.Add(Me.btnAdd)
        Me.grbProduct.Controls.Add(Me.btnEdit)
        Me.grbProduct.Controls.Add(Me.lblProID)
        Me.grbProduct.Location = New System.Drawing.Point(8, 20)
        Me.grbProduct.Name = "grbProduct"
        Me.grbProduct.Size = New System.Drawing.Size(341, 150)
        Me.grbProduct.TabIndex = 34
        Me.grbProduct.TabStop = False
        Me.grbProduct.Text = "Products"
        '
        'cmbProducts1
        '
        Me.cmbProducts1.FormattingEnabled = True
        Me.cmbProducts1.Location = New System.Drawing.Point(75, 42)
        Me.cmbProducts1.Name = "cmbProducts1"
        Me.cmbProducts1.Size = New System.Drawing.Size(167, 21)
        Me.cmbProducts1.TabIndex = 41
        '
        'txtProName
        '
        Me.txtProName.Location = New System.Drawing.Point(75, 52)
        Me.txtProName.Name = "txtProName"
        Me.txtProName.Size = New System.Drawing.Size(213, 20)
        Me.txtProName.TabIndex = 40
        '
        'lblProName
        '
        Me.lblProName.AutoSize = True
        Me.lblProName.Location = New System.Drawing.Point(29, 59)
        Me.lblProName.Name = "lblProName"
        Me.lblProName.Size = New System.Drawing.Size(35, 13)
        Me.lblProName.TabIndex = 39
        Me.lblProName.Text = "Name"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(162, 112)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 23)
        Me.btnCancel.TabIndex = 38
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtProCode
        '
        Me.txtProCode.Location = New System.Drawing.Point(75, 69)
        Me.txtProCode.Name = "txtProCode"
        Me.txtProCode.Size = New System.Drawing.Size(122, 20)
        Me.txtProCode.TabIndex = 37
        Me.txtProCode.Visible = False
        '
        'lblProCode
        '
        Me.lblProCode.AutoSize = True
        Me.lblProCode.Location = New System.Drawing.Point(16, 73)
        Me.lblProCode.Name = "lblProCode"
        Me.lblProCode.Size = New System.Drawing.Size(32, 13)
        Me.lblProCode.TabIndex = 36
        Me.lblProCode.Text = "Code"
        Me.lblProCode.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(94, 112)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(60, 23)
        Me.btnSave.TabIndex = 33
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(28, 112)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 23)
        Me.btnAdd.TabIndex = 32
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(228, 112)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 23)
        Me.btnEdit.TabIndex = 31
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        Me.btnEdit.Visible = False
        '
        'lblProID
        '
        Me.lblProID.AutoSize = True
        Me.lblProID.Location = New System.Drawing.Point(16, 50)
        Me.lblProID.Name = "lblProID"
        Me.lblProID.Size = New System.Drawing.Size(44, 13)
        Me.lblProID.TabIndex = 35
        Me.lblProID.Text = "Product"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnChildCancel)
        Me.GroupBox2.Controls.Add(Me.btnChidEdit)
        Me.GroupBox2.Controls.Add(Me.btnChildSave)
        Me.GroupBox2.Controls.Add(Me.btnChildDel)
        Me.GroupBox2.Controls.Add(Me.btnChildAdd)
        Me.GroupBox2.Controls.Add(Me.dtgPackets)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 179)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(341, 175)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Packets"
        '
        'btnChildCancel
        '
        Me.btnChildCancel.Location = New System.Drawing.Point(262, 135)
        Me.btnChildCancel.Name = "btnChildCancel"
        Me.btnChildCancel.Size = New System.Drawing.Size(55, 23)
        Me.btnChildCancel.TabIndex = 43
        Me.btnChildCancel.Text = "Cancel"
        Me.btnChildCancel.UseVisualStyleBackColor = True
        '
        'btnChidEdit
        '
        Me.btnChidEdit.Location = New System.Drawing.Point(262, 77)
        Me.btnChidEdit.Name = "btnChidEdit"
        Me.btnChidEdit.Size = New System.Drawing.Size(55, 23)
        Me.btnChidEdit.TabIndex = 42
        Me.btnChidEdit.Text = "Edit"
        Me.btnChidEdit.UseVisualStyleBackColor = True
        '
        'btnChildSave
        '
        Me.btnChildSave.Location = New System.Drawing.Point(262, 106)
        Me.btnChildSave.Name = "btnChildSave"
        Me.btnChildSave.Size = New System.Drawing.Size(55, 23)
        Me.btnChildSave.TabIndex = 41
        Me.btnChildSave.Text = "Save"
        Me.btnChildSave.UseVisualStyleBackColor = True
        '
        'btnChildDel
        '
        Me.btnChildDel.Location = New System.Drawing.Point(262, 48)
        Me.btnChildDel.Name = "btnChildDel"
        Me.btnChildDel.Size = New System.Drawing.Size(55, 23)
        Me.btnChildDel.TabIndex = 40
        Me.btnChildDel.Text = "Delete"
        Me.btnChildDel.UseVisualStyleBackColor = True
        '
        'btnChildAdd
        '
        Me.btnChildAdd.Location = New System.Drawing.Point(262, 19)
        Me.btnChildAdd.Name = "btnChildAdd"
        Me.btnChildAdd.Size = New System.Drawing.Size(55, 23)
        Me.btnChildAdd.TabIndex = 39
        Me.btnChildAdd.Text = "Add"
        Me.btnChildAdd.UseVisualStyleBackColor = True
        '
        'dtgPackets
        '
        Me.dtgPackets.AllowUserToAddRows = False
        Me.dtgPackets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPackets.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.SKU})
        Me.dtgPackets.Location = New System.Drawing.Point(17, 19)
        Me.dtgPackets.Name = "dtgPackets"
        Me.dtgPackets.ReadOnly = True
        Me.dtgPackets.Size = New System.Drawing.Size(243, 140)
        Me.dtgPackets.TabIndex = 38
        '
        'Column1
        '
        Me.Column1.HeaderText = "Packet Size"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 90
        '
        'SKU
        '
        Me.SKU.HeaderText = "SKU Code"
        Me.SKU.Name = "SKU"
        Me.SKU.ReadOnly = True
        Me.SKU.Width = 105
        '
        'frmProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 366)
        Me.ControlBox = False
        Me.Controls.Add(Me.grbProduct)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximumSize = New System.Drawing.Size(369, 393)
        Me.MinimumSize = New System.Drawing.Size(369, 393)
        Me.Name = "frmProduct"
        Me.ShowIcon = False
        Me.Text = "Products"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grbProduct.ResumeLayout(False)
        Me.grbProduct.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dtgPackets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbProduct As System.Windows.Forms.GroupBox
    Friend WithEvents txtProName As System.Windows.Forms.TextBox
    Friend WithEvents lblProName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtProCode As System.Windows.Forms.TextBox
    Friend WithEvents lblProCode As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents lblProID As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnChidEdit As System.Windows.Forms.Button
    Friend WithEvents btnChildSave As System.Windows.Forms.Button
    Friend WithEvents btnChildDel As System.Windows.Forms.Button
    Friend WithEvents btnChildAdd As System.Windows.Forms.Button
    Friend WithEvents dtgPackets As System.Windows.Forms.DataGridView
    Friend WithEvents cmbProducts1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnChildCancel As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SKU As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
