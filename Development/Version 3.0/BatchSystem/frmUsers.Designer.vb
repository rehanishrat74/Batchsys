<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        Me.grbUsers = New System.Windows.Forms.GroupBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUserId = New System.Windows.Forms.TextBox
        Me.lblRegDesc = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.lblUserName = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.cmbUsers = New System.Windows.Forms.ComboBox
        Me.grbRights = New System.Windows.Forms.GroupBox
        Me.btnChidEdit = New System.Windows.Forms.Button
        Me.btnChildSave = New System.Windows.Forms.Button
        Me.dtgRights = New System.Windows.Forms.DataGridView
        Me.colMenuName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVisible = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnChildCancel = New System.Windows.Forms.Button
        Me.grbUsers.SuspendLayout()
        Me.grbRights.SuspendLayout()
        CType(Me.dtgRights, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbUsers
        '
        Me.grbUsers.Controls.Add(Me.txtPassword)
        Me.grbUsers.Controls.Add(Me.Label1)
        Me.grbUsers.Controls.Add(Me.txtUserId)
        Me.grbUsers.Controls.Add(Me.lblRegDesc)
        Me.grbUsers.Controls.Add(Me.btnAdd)
        Me.grbUsers.Controls.Add(Me.btnEdit)
        Me.grbUsers.Controls.Add(Me.lblUserName)
        Me.grbUsers.Controls.Add(Me.btnCancel)
        Me.grbUsers.Controls.Add(Me.btnSave)
        Me.grbUsers.Controls.Add(Me.cmbUsers)
        Me.grbUsers.Controls.Add(Me.txtUserName)
        Me.grbUsers.Location = New System.Drawing.Point(8, 20)
        Me.grbUsers.Name = "grbUsers"
        Me.grbUsers.Size = New System.Drawing.Size(339, 143)
        Me.grbUsers.TabIndex = 36
        Me.grbUsers.TabStop = False
        Me.grbUsers.Text = "User"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(90, 79)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(139, 20)
        Me.txtPassword.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Password"
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(90, 50)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(139, 20)
        Me.txtUserId.TabIndex = 1
        '
        'lblRegDesc
        '
        Me.lblRegDesc.AutoSize = True
        Me.lblRegDesc.Location = New System.Drawing.Point(15, 50)
        Me.lblRegDesc.Name = "lblRegDesc"
        Me.lblRegDesc.Size = New System.Drawing.Size(43, 13)
        Me.lblRegDesc.TabIndex = 39
        Me.lblRegDesc.Text = "User ID"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(36, 112)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(102, 112)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 23)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(15, 19)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(60, 13)
        Me.lblUserName.TabIndex = 35
        Me.lblUserName.Text = "User Name"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(236, 112)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(170, 112)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(60, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(90, 16)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(141, 20)
        Me.txtUserName.TabIndex = 0
        Me.txtUserName.Visible = False
        '
        'cmbUsers
        '
        Me.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsers.FormattingEnabled = True
        Me.cmbUsers.Location = New System.Drawing.Point(90, 16)
        Me.cmbUsers.Name = "cmbUsers"
        Me.cmbUsers.Size = New System.Drawing.Size(142, 21)
        Me.cmbUsers.TabIndex = 0
        '
        'grbRights
        '
        Me.grbRights.Controls.Add(Me.btnChidEdit)
        Me.grbRights.Controls.Add(Me.btnChildSave)
        Me.grbRights.Controls.Add(Me.dtgRights)
        Me.grbRights.Controls.Add(Me.btnChildCancel)
        Me.grbRights.Location = New System.Drawing.Point(8, 169)
        Me.grbRights.Name = "grbRights"
        Me.grbRights.Size = New System.Drawing.Size(341, 185)
        Me.grbRights.TabIndex = 37
        Me.grbRights.TabStop = False
        Me.grbRights.Text = "User Right "
        '
        'btnChidEdit
        '
        Me.btnChidEdit.Location = New System.Drawing.Point(13, 155)
        Me.btnChidEdit.Name = "btnChidEdit"
        Me.btnChidEdit.Size = New System.Drawing.Size(55, 23)
        Me.btnChidEdit.TabIndex = 42
        Me.btnChidEdit.Text = "Edit"
        Me.btnChidEdit.UseVisualStyleBackColor = True
        '
        'btnChildSave
        '
        Me.btnChildSave.Location = New System.Drawing.Point(135, 155)
        Me.btnChildSave.Name = "btnChildSave"
        Me.btnChildSave.Size = New System.Drawing.Size(55, 23)
        Me.btnChildSave.TabIndex = 41
        Me.btnChildSave.Text = "Save"
        Me.btnChildSave.UseVisualStyleBackColor = True
        '
        'dtgRights
        '
        Me.dtgRights.AllowUserToAddRows = False
        Me.dtgRights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgRights.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMenuName, Me.colVisible})
        Me.dtgRights.Location = New System.Drawing.Point(6, 19)
        Me.dtgRights.Name = "dtgRights"
        Me.dtgRights.ReadOnly = True
        Me.dtgRights.Size = New System.Drawing.Size(329, 130)
        Me.dtgRights.TabIndex = 38
        '
        'colMenuName
        '
        Me.colMenuName.HeaderText = "Menu Name"
        Me.colMenuName.Name = "colMenuName"
        Me.colMenuName.ReadOnly = True
        Me.colMenuName.Width = 180
        '
        'colVisible
        '
        Me.colVisible.HeaderText = "Visible"
        Me.colVisible.Name = "colVisible"
        Me.colVisible.ReadOnly = True
        '
        'btnChildCancel
        '
        Me.btnChildCancel.Location = New System.Drawing.Point(74, 155)
        Me.btnChildCancel.Name = "btnChildCancel"
        Me.btnChildCancel.Size = New System.Drawing.Size(55, 23)
        Me.btnChildCancel.TabIndex = 43
        Me.btnChildCancel.Text = "Cancel"
        Me.btnChildCancel.UseVisualStyleBackColor = True
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 366)
        Me.ControlBox = False
        Me.Controls.Add(Me.grbUsers)
        Me.Controls.Add(Me.grbRights)
        Me.MaximumSize = New System.Drawing.Size(369, 393)
        Me.MinimumSize = New System.Drawing.Size(369, 393)
        Me.Name = "frmUsers"
        Me.Text = "Users"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grbUsers.ResumeLayout(False)
        Me.grbUsers.PerformLayout()
        Me.grbRights.ResumeLayout(False)
        CType(Me.dtgRights, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbUsers As System.Windows.Forms.GroupBox
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents lblRegDesc As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cmbUsers As System.Windows.Forms.ComboBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grbRights As System.Windows.Forms.GroupBox
    Friend WithEvents btnChidEdit As System.Windows.Forms.Button
    Friend WithEvents btnChildSave As System.Windows.Forms.Button
    Friend WithEvents dtgRights As System.Windows.Forms.DataGridView
    Friend WithEvents btnChildCancel As System.Windows.Forms.Button
    Friend WithEvents colMenuName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisible As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
