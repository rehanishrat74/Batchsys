Imports System.IO

Public Class frmUsers
    Public sStatus As String  '' used for status of Region form means add or edit status
    Private Sub frmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub
    Private Sub SetComboUsers()
        Dim dtUsers As DataTable
        dtUsers = Common.GetUsers()
        With Me.cmbUsers
            .Text = String.Empty
            .DataSource = Nothing
            .Refresh()
            .DisplayMember = "UserName"
            .ValueMember = "UserCode"
            .DataSource = dtUsers
            .Refresh()
        End With
        If cmbUsers.Items.Count > 0 Then
            cmbUsers.SelectedIndex = 0
            Dim UserCode As Integer = cmbUsers.SelectedValue
            'Dim UserCode As Integer = 0
            'If cmbUsers.Text <> "" Then
            '    UserCode = Convert.ToInt16(cmbUsers.SelectedValue)
            'End If
            dtgRights.DataSource = Nothing
            dtgRights.Columns.Clear()
            SetRightsGrid(UserCode)
        Else
            dtgRights.DataSource = Nothing
            dtgRights.Columns.Clear()
            SetRightsGrid("0")
        End If
        dtgRights.ReadOnly = True
    End Sub
    Private Sub SetRightsGrid(ByVal UserCode As String)
        Try
            Dim dt As DataTable
            dt = Common.GetUserRights(UserCode)
            Dim dcMenuId As New DataColumn(dt.Columns("MenuID").ColumnName, dt.Columns("MenuID").DataType)
            Dim dcMenuName As New DataColumn(dt.Columns("MenuName").ColumnName, dt.Columns("MenuName").DataType)
            Dim dcVisible As New DataColumn(dt.Columns("IsVisible").ColumnName, dt.Columns("IsVisible").DataType)

            Dim columnId As New DataGridViewTextBoxColumn()
            columnId.DataPropertyName = dcMenuId.ColumnName
            columnId.HeaderText = "Menu ID"
            columnId.Name = dcMenuId.ColumnName
            'columnId.SortMode = DataGridViewColumnSortMode.Automatic
            columnId.SortMode = DataGridViewColumnSortMode.NotSortable
            columnId.ValueType = dcMenuId.DataType
            columnId.Width = 135
            dtgRights.Columns.Add(columnId)
            dtgRights.Columns(dcMenuId.ColumnName).Visible = False


            Dim column As New DataGridViewTextBoxColumn()
            column.DataPropertyName = dcMenuName.ColumnName
            column.HeaderText = "Menu Name"
            column.Name = dcMenuName.ColumnName
            'column.SortMode = DataGridViewColumnSortMode.Automatic
            column.SortMode = DataGridViewColumnSortMode.NotSortable
            column.ValueType = dcMenuName.DataType
            column.Width = 180
            dtgRights.Columns.Add(column)
            'dtgRights.Columns(dcId.ColumnName).Visible = False

            Dim column1 As New DataGridViewCheckBoxColumn()
            column1.DataPropertyName = dcVisible.ColumnName
            column1.HeaderText = "Visible"
            column1.Name = dcVisible.ColumnName
            'column1.SortMode = DataGridViewColumnSortMode.Automatic
            column1.SortMode = DataGridViewColumnSortMode.NotSortable
            ''column1.ValueType = dcVisible.DataType
            column1.Width = 100
            dtgRights.Columns.Add(column1)

            Dim iTotalRows As Integer = 0
            Dim bCheck As Boolean = False
            For iTotalRows = 0 To dt.Rows.Count - 1
                Me.dtgRights.Rows.Add()
                dtgRights.Rows(iTotalRows).Cells(0).Value = dt.Rows(iTotalRows)("MenuID")
                dtgRights.Rows(iTotalRows).Cells(1).Value = dt.Rows(iTotalRows)("MenuName")
                If dt.Rows(iTotalRows)("IsVisible") = 0 Then
                    bCheck = False
                Else
                    bCheck = True
                End If
                dtgRights.Rows(iTotalRows).Cells(2).Value = bCheck
                ''dtgRights.Rows(iTotalRows).Cells(2).Value = dt.Rows(iTotalRows)("IsVisible")
                ''dtgRights.Rows(iTotalRows).Cells(2).Value = Convert.ToBoolean( dt.Rows(iTotalRows)("IsVisible")
                ''dtgRights.Rows(iTotalRows).Cells(2).Value = dt.Rows(iTotalRows)("PacketSize")
                ''dtgRights.Rows(iTotalRows).Cells(3).Value = dt.Rows(iTotalRows)("ID")
            Next

            'dtgPackets.DataSource = dt
            'dtgPackets.Refresh()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetControls()
        Try

            ''Me.lblUserName.Visible = False
            Me.txtUserName.Visible = False
            Me.cmbUsers.Visible = True
            Me.txtPassword.Enabled = False
            Me.txtUserId.Enabled = False
            Me.txtUserName.Enabled = False
            ''Me.lblUserCode.Enabled = False


            Me.btnCancel.Enabled = False
            Me.btnSave.Enabled = False
            Me.btnAdd.Enabled = True

            Me.btnChildCancel.Enabled = False
            Me.btnChildSave.Enabled = False

            ''Me.btnEdit.Enabled = True
            ''Me.btnChildAdd.Enabled = True

            dtgRights.Rows.Clear()
            SetComboUsers()
            If cmbUsers.Items.Count = 0 Then
                'btnChildAdd.Enabled = False
                'btnChildDel.Enabled = False
                btnChidEdit.Enabled = False
                btnEdit.Enabled = False
            Else
                btnEdit.Enabled = True
                'btnChildDel.Enabled = True
                'btnChidEdit.Enabled = True
            End If
            If dtgRights.RowCount > 0 Then
                'btnChildDel.Enabled = True
                btnChidEdit.Enabled = True
            Else
                btnChidEdit.Enabled = False
            End If
            btnChildCancel.Enabled = False
            btnChildSave.Enabled = False
            'btnSearch.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Error : Please Try later...")
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try

            sStatus = "Add"
            Me.cmbUsers.Visible = False
            Me.txtUserName.Visible = True
            Me.txtUserName.Text = System.String.Empty
            Me.txtUserName.Enabled = True
            Me.txtUserId.Text = System.String.Empty
            Me.txtUserId.Enabled = True
            Me.txtPassword.Text = System.String.Empty
            Me.txtPassword.Enabled = True

            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnSave.Enabled = True
            btnChidEdit.Enabled = False
            btnChildSave.Enabled = False
            btnChildCancel.Enabled = False
            'btnChildAdd.Enabled = True
            'btnChildDel.Enabled = False
            cmbUsers.DataSource = Nothing
            cmbUsers.Refresh()
            'cmbRegions.Items.Clear()
            dtgRights.DataSource = Nothing
            dtgRights.Rows.Clear()
            dtgRights.Refresh()
            setDefautGrid()
            dtgRights.Enabled = True
            dtgRights.ReadOnly = False
            txtUserName.Focus()
        Catch ex As Exception
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub setDefautGrid()
        Dim ht As New Hashtable()
        ht.Add("OpenToolStripMenuItem", "File Open")
        ht.Add("SerialsToolStripMenuItem", "Security Codes")
        ht.Add("ProductsToolStripMenuItem", "Products")
        ht.Add("SingleRepotToolStripMenuItem", "Report Single Security Code")
        ht.Add("MultipleSerialsToolStripMenuItem", "Report Multiple Security Codes")
        ht.Add("TextFileToolStripMenuItem", "Report Text File")
        ht.Add("RegionsToolStripMenuItem", "Regions")
        ht.Add("mnuPrinterSetPort", "Printer Status")
        ht.Add("mnuPrinterCodePrint", "Print Security Code")
        ht.Add("mnuTrace", "Trace")
        ''ht.Add("mnuTrace", "Trace")
        ht.Add("CreateToolStripMenuItem", "Create Users")
        ht.Add("mnuPrinterClosePort", "Printer Port Close")
        ht.Add("mnuPrinterStartStopMachine", "Start Stop Printer")
        ht.Add("mnuPrinterStatus", "Printer Status")

        For Each de As DictionaryEntry In ht
            dtgRights.Rows.Add()
            dtgRights.Rows(dtgRights.RowCount - 1).Cells(0).Value = de.Key
            dtgRights.Rows(dtgRights.RowCount - 1).Cells(1).Value = de.Value
            dtgRights.Rows(dtgRights.RowCount - 1).Cells(2).Value = 0
        Next
        'For iTotalRows = 0 To dt.Rows.Count - 1
        '    ht.add("dtgRights.Rows.Add()
        '    dtgRights.Rows(iTotalRows).Cells(0).Value = dt.Rows(iTotalRows)("MenuID")
        '    dtgRights.Rows(iTotalRows).Cells(1).Value = dt.Rows(iTotalRows)("MenuName")
        '    dtgRights.Rows(iTotalRows).Cells(2).Value = dt.Rows(iTotalRows)("IsVisible")

        'Next

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            sStatus = "Edit"

            Me.txtPassword.Enabled = True
            Me.txtUserId.Enabled = True


            Me.btnAdd.Enabled = False
            Me.btnEdit.Enabled = False
            Me.btnSave.Enabled = True
            Me.btnCancel.Enabled = True

            Me.btnChidEdit.Enabled = False
            'Me.btnChildAdd.Enabled = False
            Me.btnChildCancel.Enabled = False
            'Me.btnSearch.Enabled = False
            'Me.btnChildDel.Enabled = False
            Me.btnChildSave.Enabled = False

            btnChidEdit.Enabled = False
            btnChildSave.Enabled = False
            btnChildCancel.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim UderID As Integer = cmbUsers.SelectedIndex
        sStatus = System.String.Empty
        SetControls()
        If UderID > -1 Then
            cmbUsers.SelectedIndex = UderID
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If sStatus = "Add" Then
            Add_Users()
            'sStatus = System.String.Empty
            'SetControls()
            'cmbProducts1.SelectedIndex = cmbProducts1.Items.Count - 1
        ElseIf sStatus = "Edit" Then
            Edit_Users()
            'Edit_Child()
            'sStatus = System.String.Empty
            SetControls()
        End If
    End Sub
    Private Function Add_Detail(ByVal UserCode As Integer) As Boolean
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0
        Dim iTotalRow As Integer = 0
        'Dim iRegionCode As Integer
        Dim bRowsCheck As Boolean = False
        Dim cCheckBox As String = ""
        Try

            cmdText = "delete from UserRights where UserID=" & UserCode
            ExecuteQuery(cmdText, Execute.None)

            For iTotalRow = 0 To dtgRights.RowCount - 1
                'If dtgProducts.Rows(iTotalRow).Cells(0).Value > 0 And dtgProducts.Rows(iTotalRow).Cells(1).Value = Nothing And dtgProducts.Rows(iTotalRow).Cells(2).Value = Nothing Then
                'cmdText = "Select count(*) from  ProductPacketRegion where RegionCode=" & iRegionCode & " And ProdcutPacketID=" & dtgProducts.Rows(iTotalRow).Cells(0).Value
                'duplicate = ExecuteQuery(cmdText, Execute.Scalar)
                'If duplicate = 0 Then
                If dtgRights.Rows(iTotalRow).Cells(2).Value = True Then
                    cCheckBox = "1"
                Else
                    cCheckBox = "0"
                End If
                'cCheckBox = dtgRights.Rows(iTotalRow).Cells(2).Value
                cmdText = "INSERT INTO UserRights (UserID,MenuID,MenuName,IsVisible) values(" & UserCode & ",'" & dtgRights.Rows(iTotalRow).Cells(0).Value & "','" & dtgRights.Rows(iTotalRow).Cells(1).Value & "','" & cCheckBox & "')"
                ExecuteQuery(cmdText, Execute.None)
                'End If
                ''End If
            Next
            Return True
        Catch ex As Exception
            ''MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ''Return False
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    'create it if it doesn't
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net :Function: Add_Detail() Form:frmUsers  , " & DateTime.Now & " , " & ex.Message)
                    sw.WriteLine("and source is : " & ex.StackTrace)
                    sw.Close()
                End Using
                ''MessageBox.Show("Error " & ex.Message.ToString)
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.Close()
        End Try
    End Function
    Private Sub Add_Users()
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0
        Dim sEncPassword As String = System.String.Empty
        Dim oSecurity As New Security()
        Try
            If txtUserName.Text.Length > 0 AndAlso txtUserName.Text <> "" Then
                If txtUserId.Text.Length > 0 AndAlso txtUserId.Text <> "" Then
                    If txtPassword.Text.Length > 0 AndAlso txtPassword.Text <> "" Then
                        cmdText = "Select * from users where UserName='" & txtUserName.Text & "'"
                        duplicate = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar))
                        If duplicate = 0 Then
                            cmdText = "Select * from users where UserID='" & txtUserId.Text & "'"
                            duplicate = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar))
                            If duplicate = 0 Then
                                sEncPassword = oSecurity.EncryptText(txtPassword.Text)
                                ''cmdText = "INSERT INTO Users (UserID,UserName,Password) VALUES ('" & txtUserId.Text & "','" & txtUserName.Text & "','" & txtPassword.Text & "');"
                                'cmdText = "INSERT INTO Users (UserID,UserName,UserPassword) VALUES ('" & txtUserId.Text & "','" & txtUserName.Text & "','" & txtPassword.Text & "')"
                                cmdText = "INSERT INTO Users (UserID,UserName,UserPassword) VALUES ('" & txtUserId.Text & "','" & txtUserName.Text & "','" & sEncPassword & "')"
                                ExecuteQuery(cmdText, Execute.None)
                                cmdText = "select max(UserCode) from Users"
                                Dim UserID As Integer = 0
                                UserID = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar))
                                'If bDetaialAdd = True Then
                                '    Dim bDetailAdd As Boolean = Add_Detail(RegionID)
                                '    bDetaialAdd = False
                                'End If
                                Dim bAdd As Boolean = Add_Detail(UserID)
                                If bAdd = True Then
                                    MessageBox.Show("Record insert Success", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    SetControls()
                                    If cmbUsers.Items.Count > 0 Then
                                        cmbUsers.SelectedIndex = cmbUsers.Items.Count - 1
                                    End If
                                Else
                                    MessageBox.Show("Record not insert Success", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            Else
                                MessageBox.Show("User Id already exits.....")
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("User Name already exits.....")
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Password must be Enter...")
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("User ID must be Enter...")
                    Exit Sub
                End If
            Else
                MessageBox.Show("User Name must be Enter...")
                Exit Sub
            End If
        Catch ex As Exception
            'Dim f As frmMain = CType(Me.MdiParent, frmMain)
            'If f.mnuTrace.Checked Then
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    'create it if it doesn't
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net : , " & DateTime.Now & " , " & ex.Message)
                    sw.WriteLine("and source is : " & ex.StackTrace)
                    sw.Close()
                End Using
                ''MessageBox.Show("Error " & ex.Message.ToString)
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try

    End Sub
    Private Sub Edit_Users()
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0
        Dim sEncPassword As String = System.String.Empty
        Dim oSecurity As New Security()
        Try

            If (cmbUsers.SelectedValue <> Nothing) Then
                If txtUserId.Text.Length > 0 AndAlso txtUserId.Text <> "" Then
                    If txtPassword.Text.Length > 0 AndAlso txtPassword.Text <> "" Then
                        cmdText = "Select * from users where UserID='" & txtUserId.Text & "' and UserCode <>" & cmbUsers.SelectedValue
                        duplicate = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar))
                        If duplicate = 0 Then
                            sEncPassword = oSecurity.EncryptText(txtPassword.Text)
                            'cmdText = "update Users set UserID='" & txtUserId.Text & "',UserPassword='" & txtPassword.Text & "' Where UserCode=" & cmbUsers.SelectedValue
                            cmdText = "update Users set UserID='" & txtUserId.Text & "',UserPassword='" & sEncPassword & "' Where UserCode=" & cmbUsers.SelectedValue
                            ExecuteQuery(cmdText, Execute.None)
                            Add_Detail(cmbUsers.SelectedValue)
                        Else
                            MessageBox.Show("User ID already exits.....")
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("User Id mus be Enter.....")
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Password must be Enter...")
                    Exit Sub
                End If
                Else
                MessageBox.Show("User Name must be Enter...")
                    Exit Sub
                End If
        Catch ex As Exception
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    'create it if it doesn't
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net : , " & DateTime.Now & " , " & ex.Message)
                    sw.WriteLine("and source is : " & ex.StackTrace)
                    sw.Close()
                End Using
                ''MessageBox.Show("Error " & ex.Message.ToString)
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub btnChidEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChidEdit.Click
        sStatus = "ChildEdit"
        dtgRights.ReadOnly = False
        btnAdd.Enabled = False
        btnCancel.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnChidEdit.Enabled = False
        btnChildCancel.Enabled = True
        btnChildSave.Enabled = True

    End Sub

    Private Sub btnChildSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildSave.Click
        sStatus = System.String.Empty
        Dim iUserIndex As Integer = cmbUsers.SelectedIndex
        If (cmbUsers.SelectedValue <> Nothing) Then
            Add_Detail(cmbUsers.SelectedValue)
            SetControls()
            cmbUsers.SelectedIndex = iUserIndex
        End If
    End Sub

    Private Sub txtUserName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserName.TextChanged

    End Sub

    Private Sub cmbUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsers.SelectedIndexChanged
        If Me.cmbUsers.SelectedValue <> Nothing Then
            Dim sUserCode As String = cmbUsers.SelectedValue
            Dim cmdText As String = "SELECT * FROM Users WHERE UserCode=" & sUserCode
            Dim rowUser As DataRow
            Dim ds As DataSet
            ds = ExecuteQuery(cmdText, Execute.DataSet)
            rowUser = ds.Tables(0).Rows(0)
            txtUserId.Text = rowUser("UserID")
            txtPassword.Text = rowUser("UserPassword")
            dtgRights.Columns.Clear()
            dtgRights.DataSource = Nothing

            SetRightsGrid(sUserCode)

            If dtgRights.RowCount > 0 Then
                btnChidEdit.Enabled = True
                'btnChildDel.Enabled = True
            Else
                btnChidEdit.Enabled = False
                'btnChildDel.Enabled = False
            End If
        End If

        If sStatus = "Edit" Then
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnSave.Enabled = False
            btnCancel.Enabled = False
            Me.txtPassword.Enabled = False
            Me.txtUserId.Enabled = False
            If dtgRights.RowCount > 0 Then
                btnChidEdit.Enabled = True
                'btnChildDel.Enabled = True
            Else
                btnChidEdit.Enabled = False
                'btnChildDel.Enabled = False
            End If
            btnChildCancel.Enabled = False
            btnChildSave.Enabled = False
        End If
    End Sub

    Private Sub btnChildCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildCancel.Click


        Dim UserIndex As Integer = cmbUsers.SelectedIndex
        'SetControls()

        dtgRights.Rows.Clear()
        'SetComboRegions()
        If cmbUsers.Items.Count > 0 Then
            cmbUsers.SelectedIndex = 0
            Dim userCode As Integer = cmbUsers.SelectedValue
            dtgRights.DataSource = Nothing
            dtgRights.Columns.Clear()
            SetRightsGrid(userCode)
            ''SetProductRegionGrid(RegionCode)
        End If
        dtgRights.ReadOnly = True
        btnChildCancel.Enabled = False
        btnChildSave.Enabled = False
        If dtgRights.RowCount > 0 Then
            btnChidEdit.Enabled = True
        Else
            btnChidEdit.Enabled = False
        End If
        'If cmbRegions.Items.Count = 0 Then
        '    'btnChildAdd.Enabled = False
        '    'btnChildDel.Enabled = False
        '    btnChidEdit.Enabled = False
        'Else
        '    'btnChildAdd.Enabled = True
        '    'btnChildDel.Enabled = True
        '    btnChidEdit.Enabled = True
        'End If
        'btnSearch.Enabled = False


        'If RegionIndex > 0 Then
        '    cmbRegions.SelectedIndex = RegionIndex
        'End If
        'If txtRegCode.Text <> "" Then
        '    btnChildAdd.Enabled = True
        'End If
        If sStatus <> "Add" Then
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            cmbUsers.Enabled = True
        End If
        sStatus = "sView"
    End Sub
End Class