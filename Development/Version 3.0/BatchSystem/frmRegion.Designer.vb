<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegion
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
        Me.grbRegions = New System.Windows.Forms.GroupBox
        Me.txtRegDesc = New System.Windows.Forms.TextBox
        Me.lblRegDesc = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.lblRegID = New System.Windows.Forms.Label
        Me.txtRegCode = New System.Windows.Forms.TextBox
        Me.lblRegCode = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.cmbRegions = New System.Windows.Forms.ComboBox
        Me.btnChildCancel = New System.Windows.Forms.Button
        Me.dtgProducts = New System.Windows.Forms.DataGridView
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProduct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPacket = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColPKey = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnChildAdd = New System.Windows.Forms.Button
        Me.btnChildDel = New System.Windows.Forms.Button
        Me.btnChildSave = New System.Windows.Forms.Button
        Me.btnChidEdit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.grbProducts = New System.Windows.Forms.GroupBox
        Me.lblSelectedRegion = New System.Windows.Forms.Label
        Me.grbRegions.SuspendLayout()
        CType(Me.dtgProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbProducts.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbRegions
        '
        Me.grbRegions.Controls.Add(Me.txtRegDesc)
        Me.grbRegions.Controls.Add(Me.lblRegDesc)
        Me.grbRegions.Controls.Add(Me.btnAdd)
        Me.grbRegions.Controls.Add(Me.btnEdit)
        Me.grbRegions.Controls.Add(Me.lblRegID)
        Me.grbRegions.Controls.Add(Me.txtRegCode)
        Me.grbRegions.Controls.Add(Me.lblRegCode)
        Me.grbRegions.Controls.Add(Me.btnCancel)
        Me.grbRegions.Controls.Add(Me.btnSave)
        Me.grbRegions.Controls.Add(Me.cmbRegions)
        Me.grbRegions.Location = New System.Drawing.Point(8, 20)
        Me.grbRegions.Name = "grbRegions"
        Me.grbRegions.Size = New System.Drawing.Size(341, 130)
        Me.grbRegions.TabIndex = 35
        Me.grbRegions.TabStop = False
        Me.grbRegions.Text = "Regions"
        '
        'txtRegDesc
        '
        Me.txtRegDesc.Location = New System.Drawing.Point(90, 59)
        Me.txtRegDesc.Name = "txtRegDesc"
        Me.txtRegDesc.Size = New System.Drawing.Size(206, 20)
        Me.txtRegDesc.TabIndex = 2
        '
        'lblRegDesc
        '
        Me.lblRegDesc.AutoSize = True
        Me.lblRegDesc.Location = New System.Drawing.Point(15, 67)
        Me.lblRegDesc.Name = "lblRegDesc"
        Me.lblRegDesc.Size = New System.Drawing.Size(60, 13)
        Me.lblRegDesc.TabIndex = 39
        Me.lblRegDesc.Text = "Description"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(37, 98)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(103, 98)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 23)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'lblRegID
        '
        Me.lblRegID.AutoSize = True
        Me.lblRegID.Location = New System.Drawing.Point(15, 16)
        Me.lblRegID.Name = "lblRegID"
        Me.lblRegID.Size = New System.Drawing.Size(41, 13)
        Me.lblRegID.TabIndex = 35
        Me.lblRegID.Text = "Region"
        '
        'txtRegCode
        '
        Me.txtRegCode.Location = New System.Drawing.Point(90, 16)
        Me.txtRegCode.Name = "txtRegCode"
        Me.txtRegCode.Size = New System.Drawing.Size(139, 20)
        Me.txtRegCode.TabIndex = 1
        Me.txtRegCode.Visible = False
        '
        'lblRegCode
        '
        Me.lblRegCode.AutoSize = True
        Me.lblRegCode.Location = New System.Drawing.Point(15, 21)
        Me.lblRegCode.Name = "lblRegCode"
        Me.lblRegCode.Size = New System.Drawing.Size(69, 13)
        Me.lblRegCode.TabIndex = 42
        Me.lblRegCode.Text = "Region Code"
        Me.lblRegCode.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(237, 98)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(171, 98)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(60, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbRegions
        '
        Me.cmbRegions.FormattingEnabled = True
        Me.cmbRegions.Location = New System.Drawing.Point(90, 16)
        Me.cmbRegions.Name = "cmbRegions"
        Me.cmbRegions.Size = New System.Drawing.Size(160, 21)
        Me.cmbRegions.TabIndex = 0
        '
        'btnChildCancel
        '
        Me.btnChildCancel.Location = New System.Drawing.Point(280, 110)
        Me.btnChildCancel.Name = "btnChildCancel"
        Me.btnChildCancel.Size = New System.Drawing.Size(55, 23)
        Me.btnChildCancel.TabIndex = 43
        Me.btnChildCancel.Text = "Cancel"
        Me.btnChildCancel.UseVisualStyleBackColor = True
        '
        'dtgProducts
        '
        Me.dtgProducts.AllowUserToAddRows = False
        Me.dtgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colProduct, Me.colPacket, Me.ColPKey})
        Me.dtgProducts.Location = New System.Drawing.Point(6, 51)
        Me.dtgProducts.Name = "dtgProducts"
        Me.dtgProducts.ReadOnly = True
        Me.dtgProducts.Size = New System.Drawing.Size(268, 140)
        Me.dtgProducts.TabIndex = 38
        '
        'colID
        '
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'colProduct
        '
        Me.colProduct.HeaderText = "Product"
        Me.colProduct.Name = "colProduct"
        Me.colProduct.ReadOnly = True
        Me.colProduct.Width = 135
        '
        'colPacket
        '
        Me.colPacket.HeaderText = "Packet Size"
        Me.colPacket.Name = "colPacket"
        Me.colPacket.ReadOnly = True
        Me.colPacket.Width = 90
        '
        'ColPKey
        '
        Me.ColPKey.HeaderText = "PKey"
        Me.ColPKey.Name = "ColPKey"
        Me.ColPKey.ReadOnly = True
        Me.ColPKey.Visible = False
        '
        'btnChildAdd
        '
        Me.btnChildAdd.Location = New System.Drawing.Point(280, 52)
        Me.btnChildAdd.Name = "btnChildAdd"
        Me.btnChildAdd.Size = New System.Drawing.Size(55, 23)
        Me.btnChildAdd.TabIndex = 39
        Me.btnChildAdd.Text = "Assign"
        Me.btnChildAdd.UseVisualStyleBackColor = True
        '
        'btnChildDel
        '
        Me.btnChildDel.Location = New System.Drawing.Point(280, 81)
        Me.btnChildDel.Name = "btnChildDel"
        Me.btnChildDel.Size = New System.Drawing.Size(55, 23)
        Me.btnChildDel.TabIndex = 40
        Me.btnChildDel.Text = "Delete"
        Me.btnChildDel.UseVisualStyleBackColor = True
        '
        'btnChildSave
        '
        Me.btnChildSave.Location = New System.Drawing.Point(280, 139)
        Me.btnChildSave.Name = "btnChildSave"
        Me.btnChildSave.Size = New System.Drawing.Size(55, 23)
        Me.btnChildSave.TabIndex = 41
        Me.btnChildSave.Text = "Save"
        Me.btnChildSave.UseVisualStyleBackColor = True
        '
        'btnChidEdit
        '
        Me.btnChidEdit.Location = New System.Drawing.Point(280, 23)
        Me.btnChidEdit.Name = "btnChidEdit"
        Me.btnChidEdit.Size = New System.Drawing.Size(55, 23)
        Me.btnChidEdit.TabIndex = 42
        Me.btnChidEdit.Text = "Edit"
        Me.btnChidEdit.UseVisualStyleBackColor = True
        Me.btnChidEdit.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Assign Products to Selected Region Here"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(280, 168)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(55, 23)
        Me.btnSearch.TabIndex = 45
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'grbProducts
        '
        Me.grbProducts.Controls.Add(Me.lblSelectedRegion)
        Me.grbProducts.Controls.Add(Me.btnSearch)
        Me.grbProducts.Controls.Add(Me.Label1)
        Me.grbProducts.Controls.Add(Me.btnChidEdit)
        Me.grbProducts.Controls.Add(Me.btnChildSave)
        Me.grbProducts.Controls.Add(Me.btnChildDel)
        Me.grbProducts.Controls.Add(Me.btnChildAdd)
        Me.grbProducts.Controls.Add(Me.dtgProducts)
        Me.grbProducts.Controls.Add(Me.btnChildCancel)
        Me.grbProducts.Location = New System.Drawing.Point(8, 156)
        Me.grbProducts.Name = "grbProducts"
        Me.grbProducts.Size = New System.Drawing.Size(341, 205)
        Me.grbProducts.TabIndex = 36
        Me.grbProducts.TabStop = False
        Me.grbProducts.Text = "Assigning Regions"
        '
        'lblSelectedRegion
        '
        Me.lblSelectedRegion.AutoSize = True
        Me.lblSelectedRegion.Location = New System.Drawing.Point(6, 15)
        Me.lblSelectedRegion.Name = "lblSelectedRegion"
        Me.lblSelectedRegion.Size = New System.Drawing.Size(41, 13)
        Me.lblSelectedRegion.TabIndex = 46
        Me.lblSelectedRegion.Text = "Region"
        '
        'frmRegion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 366)
        Me.ControlBox = False
        Me.Controls.Add(Me.grbProducts)
        Me.Controls.Add(Me.grbRegions)
        Me.MaximumSize = New System.Drawing.Size(369, 393)
        Me.MinimumSize = New System.Drawing.Size(369, 393)
        Me.Name = "frmRegion"
        Me.ShowIcon = False
        Me.Text = "frmRegion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grbRegions.ResumeLayout(False)
        Me.grbRegions.PerformLayout()
        CType(Me.dtgProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbProducts.ResumeLayout(False)
        Me.grbProducts.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbRegions As System.Windows.Forms.GroupBox
    Friend WithEvents cmbRegions As System.Windows.Forms.ComboBox
    Friend WithEvents txtRegDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblRegDesc As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents lblRegID As System.Windows.Forms.Label
    Friend WithEvents txtRegCode As System.Windows.Forms.TextBox
    Friend WithEvents lblRegCode As System.Windows.Forms.Label
    Friend WithEvents btnChildCancel As System.Windows.Forms.Button
    Friend WithEvents dtgProducts As System.Windows.Forms.DataGridView
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProduct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPacket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnChildAdd As System.Windows.Forms.Button
    Friend WithEvents btnChildDel As System.Windows.Forms.Button
    Friend WithEvents btnChildSave As System.Windows.Forms.Button
    Friend WithEvents btnChidEdit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grbProducts As System.Windows.Forms.GroupBox
    Friend WithEvents lblSelectedRegion As System.Windows.Forms.Label
End Class
