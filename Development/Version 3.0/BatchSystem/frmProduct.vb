Imports System.Data.OleDb
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports BatchSystem.Common
Imports System.Collections.Generic
Public Class frmProduct
    Public sStatus As String  '' used for status of Product form means add or edit status
    Public bDetaialAdd As Boolean  '' used for check the status of add detail of Packets
    Private Sub Add_Detail(ByVal sProductCode As String)
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0
        Dim iTotalRow As Integer = 0
        Try
            If dtgPackets.RowCount > 0 Then
                For iTotalRow = 0 To dtgPackets.RowCount - 1
                    cmdText = "Select count(*) from  Packets where ProductCode='" & sProductCode & "' And PacketSize=" & dtgPackets.Rows(iTotalRow).Cells(0).Value
                    duplicate = ExecuteQuery(cmdText, Execute.Scalar)
                    If duplicate = 0 Then
                        cmdText = "Insert into Packets (ProductCode,PacketSize) values('" & sProductCode & "'," & dtgPackets.Rows(iTotalRow).Cells(0).Value & ")"
                        ExecuteQuery(cmdText, Execute.None)
                    End If
                Next
            End If
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
        Catch ex As Exception
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
        End Try
    End Sub
    Private Sub Add_Detail()
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0
        Dim iTotalRow As Integer = 0
        Dim sProductCode = System.String.Empty
        Try
            If dtgPackets.RowCount > 0 Then
                sProductCode = cmbProducts1.SelectedValue
                For iTotalRow = 0 To dtgPackets.RowCount - 1
                    If dtgPackets.Rows(iTotalRow).Cells(0).Value > 0 And dtgPackets.Rows(iTotalRow).Cells(1).Value = Nothing Then
                        cmdText = "Select count(*) from  Packets where ProductCode='" & sProductCode & "' And PacketSize=" & dtgPackets.Rows(iTotalRow).Cells(0).Value
                        duplicate = ExecuteQuery(cmdText, Execute.Scalar)
                        If duplicate = 0 Then
                            cmdText = "Insert into Packets (ProductCode,PacketSize,SKU_CODE) values('" & sProductCode & "','" & dtgPackets.Rows(iTotalRow).Cells(0).Value & "','" & dtgPackets.Rows(iTotalRow).Cells(2).Value & "')"
                            ExecuteQuery(cmdText, Execute.None)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
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
        End Try
    End Sub

    Private Sub btnChildSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildSave.Click
        Dim selProID As Integer = cmbProducts1.SelectedIndex
        If sStatus = "Add" Then
            Add_Product()
            'sStatus = System.String.Empty
            'SetControls()
        ElseIf sStatus = "Edit" Then
            Edit_Child()
            ' Edit_Product()
            'sStatus = System.String.Empty
            SetControls()
            cmbProducts1.SelectedIndex = selProID
        End If
        If bDetaialAdd = True And sStatus = System.String.Empty Then
            'Dim selProID As Integer = cmbProducts1.SelectedIndex
            Add_Detail()
            bDetaialAdd = False
            SetControls()
            cmbProducts1.SelectedIndex = selProID
        End If
    End Sub

    Private Sub btnChildAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildAdd.Click
        bDetaialAdd = True
        dtgPackets.ReadOnly = False
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnChidEdit.Enabled = False
        btnChildSave.Enabled = True
        btnChildDel.Enabled = False
        '''' changing 
        'btnSave.Enabled = True
        'btnCancel.Enabled = True
        If sStatus <> "Add" Then
            btnSave.Enabled = False
        End If

        btnCancel.Enabled = False
        btnChildCancel.Enabled = True

        Me.dtgPackets.Rows.Add()
    End Sub

    Private Sub btnChildDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildDel.Click
        Dim cmdText As String = System.String.Empty
        Dim iFoundKey As Integer = 0
        If (MessageBox.Show("Do you really want to delete selected record(s)?", "Delete Warning", MessageBoxButtons.YesNo, _
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, False) = Windows.Forms.DialogResult.Yes) Then
            Try
                If dtgPackets.SelectedRows.Count > 0 Then

                    Dim cnt As Integer = dtgPackets.SelectedRows.Count
                    Dim iRow As Integer
                    For iRow = 0 To cnt - 1
                        If Me.dtgPackets.SelectedRows.Count > 0 Then
                            'If (Me.dtgPackets.SelectedRows.Count > 0 And Me.dtgPackets.SelectedRows(0).Index <> Me.dtgPackets.Rows.Count - 1) Then
                            cmdText = "Select count(*) from Serials where ProductCode='" & cmbProducts1.SelectedValue & "' and PacketSize=" & Me.dtgPackets.SelectedRows(0).Cells(0).Value
                            iFoundKey = ExecuteQuery(cmdText, Execute.Scalar)
                            If iFoundKey = 0 Then
                                cmdText = "Delete * from Packets where ProductCode='" & cmbProducts1.SelectedValue & "' and PacketSize=" & Me.dtgPackets.SelectedRows(0).Cells(0).Value
                                ExecuteQuery(cmdText, Execute.None)
                                Me.dtgPackets.Rows.RemoveAt(Me.dtgPackets.SelectedRows(0).Index)
                            Else
                                Me.dtgPackets.SelectedRows(0).Selected = False
                                MessageBox.Show("Record not delete,Packet has Security Code", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("Select row form Packet")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Add_Product()
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0

        Try
            If txtProName.Text.Length > 0 AndAlso txtProName.Text <> " " Then
                cmdText = "Select ID from Products where ProductName='" & txtProName.Text & "'"
                duplicate = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar))
                If duplicate = 0 Then
                    cmdText = "select max(ID) from Products"
                    Dim Productid As Integer = 0
                    Productid = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar)) + 1
                    cmdText = "insert into Products (ProductCode,ProductName) values ('" & Productid & "','" & txtProName.Text & "')"
                    ExecuteQuery(cmdText, Execute.None)

                    If bDetaialAdd = True Then
                        Add_Detail(Productid)
                        bDetaialAdd = False
                    End If
                    sStatus = System.String.Empty
                    MessageBox.Show("Record insert Success", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SetControls()
                    cmbProducts1.SelectedIndex = cmbProducts1.Items.Count - 1
                Else
                    MessageBox.Show("Product already exits ,Change the product name", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Enter the Product Name", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
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
    Private Sub Edit_Child()
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0
        Dim iTotalRow As Integer = 0
        Dim sProductCode = System.String.Empty
        Try
            Dim i As Integer
            For i = 0 To dtgPackets.RowCount - 1
                cmdText = "Update Packets set PacketSize=" & dtgPackets.Rows(i).Cells(0).Value & ",SKU_CODE=" & dtgPackets.Rows(i).Cells(2).Value & " where ProductCode='" & cmbProducts1.SelectedValue & "' and SystemId=" & dtgPackets.Rows(i).Cells(1).Value
                ExecuteQuery(cmdText, Execute.None)
            Next
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
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
    Private Sub Edit_Product()
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0
        Try
            If (cmbProducts1.SelectedValue <> Nothing) Then
                If cmbProducts1.SelectedValue <> txtProCode.Text Then
                    If Not IsNumeric(txtProCode.Text) Then
                        cmdText = "select count(*) from Products where ProductCode='" & txtProCode.Text & "'"
                        duplicate = ExecuteQuery(cmdText, Execute.Scalar)
                        If duplicate = 0 Then
                            'cmdText = "select count(*) from Products pro right JOIN serials AS se ON pro.ProductCode = se.ProductCode where pro.id=" & cmbProducts1.SelectedValue
                            cmdText = "Select count(*) from Serials where ProductCode='" & cmbProducts1.SelectedValue & "'"
                            duplicate = ExecuteQuery(cmdText, Execute.Scalar)
                            If duplicate = 0 Then
                                cmdText = "update  Products set ProductCode='" & txtProCode.Text & "' where ProductCode='" & cmbProducts1.SelectedValue & "'"
                                ExecuteQuery(cmdText, Execute.None)
                                cmdText = "update  Packets set ProductCode='" & txtProCode.Text & "' where ProductCode='" & cmbProducts1.SelectedValue & "'"
                                ExecuteQuery(cmdText, Execute.None)
                                MessageBox.Show("Record upadate Success", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                sStatus = System.String.Empty
                                SetControls()
                            Else
                                MessageBox.Show("Product Code has Security Code,Record not update", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            MessageBox.Show("Product Code Already Exits,Record not update", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Product Code must be Alpa Numeric,Record not update", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    sStatus = System.String.Empty
                    SetControls()
                End If
            Else
                MessageBox.Show("For Product code update,Select product first", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
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
    Private Sub btnChidEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChidEdit.Click
        Try
            sStatus = "Edit"
            lblProID.Visible = True
            cmbProducts1.Visible = True
            'lblProCode.Visible = True
            lblProCode.Visible = False
            'txtProCode.Visible = True
            txtProCode.Visible = False
            'txtProCode.Enabled = True
            lblProName.Visible = False
            txtProName.Visible = False
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnChidEdit.Enabled = False
            btnCancel.Enabled = False
            'btnCancel.Enabled = True
            'btnSave.Enabled = True
            btnSave.Enabled = False
            btnChildSave.Enabled = True
            btnChildAdd.Enabled = False
            btnChildDel.Enabled = False
            btnChildCancel.Enabled = True
            dtgPackets.ReadOnly = False
        Catch ex As Exception
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            'cmbProducts1.Tex
            sStatus = "Add"
            lblProID.Visible = False
            cmbProducts1.Visible = False
            lblProCode.Visible = False
            txtProCode.Visible = False
            lblProName.Visible = True
            txtProName.Visible = True
            txtProName.Text = System.String.Empty
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnSave.Enabled = True

            '''' changing coding for child
            btnChidEdit.Enabled = False
            btnChildSave.Enabled = False
            btnChildCancel.Enabled = False
            btnChildDel.Enabled = False

            dtgPackets.DataSource = Nothing
            dtgPackets.Rows.Clear()
            dtgPackets.Refresh()
            'dtgPackets.Columns.Clear()
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
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


    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            sStatus = "Edit"
            lblProID.Visible = True
            cmbProducts1.Visible = True
            'lblProCode.Visible = True
            'lblProCode.Visible = False
            'txtProCode.Visible = True
            txtProCode.Visible = False
            'txtProCode.Enabled = True
            lblProName.Visible = False
            txtProName.Visible = False
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnChidEdit.Enabled = False
            btnCancel.Enabled = True
            btnSave.Enabled = True
            btnChildSave.Enabled = True
            btnChildAdd.Enabled = False
            btnChildDel.Enabled = False
            dtgPackets.ReadOnly = False
        Catch ex As Exception
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If sStatus = "Add" Then
            Add_Product()
            'sStatus = System.String.Empty
            'SetControls()
            'cmbProducts1.SelectedIndex = cmbProducts1.Items.Count - 1
        ElseIf sStatus = "Edit" Then
            'Edit_Product()
            'sStatus = System.String.Empty
            SetControls()
        End If
        If bDetaialAdd = True And sStatus = System.String.Empty Then
            Add_Detail()
            bDetaialAdd = False
            Dim selProID As Integer = cmbProducts1.SelectedIndex
            SetControls()
            cmbProducts1.SelectedIndex = selProID
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        sStatus = System.String.Empty
        SetControls()
    End Sub
    Private Sub SetControls()
        Me.lblProID.Visible = True
        Me.cmbProducts1.Visible = True
        Me.lblProCode.Visible = True
        lblProCode.Visible = False
        'Me.txtProCode.Visible = True
        'Me.txtProCode.Enabled = False
        txtProCode.Visible = False
        Me.lblProName.Visible = False
        Me.txtProName.Visible = False
        Me.btnAdd.Enabled = True
        Me.btnChildDel.Enabled = True
        Me.btnChildAdd.Enabled = True
        Me.btnEdit.Enabled = True
        btnChidEdit.Enabled = True
        Me.btnSave.Enabled = False
        Me.btnChildSave.Enabled = False
        Me.btnCancel.Enabled = False
        Me.btnChildCancel.Enabled = False
        SetComboProducts()
        If cmbProducts1.Items.Count > 0 Then
            cmbProducts1.SelectedIndex = 0
            Dim ProductCode As String = cmbProducts1.SelectedValue
            dtgPackets.Columns.Clear()
            SetPacketGrid(ProductCode)
        End If
        dtgPackets.ReadOnly = True
    End Sub
    Private Sub SetComboProducts()
        Dim dtProducts As DataTable
        dtProducts = Common.GetProducts()
        With Me.cmbProducts1
            .Text = String.Empty
            .DisplayMember = "ProductName"
            .ValueMember = "ProductCode"
            .DataSource = dtProducts
            .Refresh()
        End With
    End Sub
    Private Sub SetPacketGrid(ByVal ProductCode As String)
        Try
            Dim dtPackets As DataTable
            dtPackets = Common.GetPackets(ProductCode)
            Dim dcSize As New DataColumn(dtPackets.Columns("PacketSize").ColumnName, dtPackets.Columns("PacketSize").DataType)
            Dim dcId As New DataColumn(dtPackets.Columns("SystemId").ColumnName, dtPackets.Columns("SystemId").DataType)
            Dim dcSKU As New DataColumn(dtPackets.Columns("SKU_CODE").ColumnName, dtPackets.Columns("SKU_Code").DataType)

            Dim column As New DataGridViewTextBoxColumn()
            column.DataPropertyName = dcSize.ColumnName
            column.HeaderText = "Packet Size"
            column.Name = dcSize.ColumnName
            column.SortMode = DataGridViewColumnSortMode.Automatic
            column.ValueType = dcSize.DataType
            'column.Width = 195
            dtgPackets.Columns.Add(column)

            Dim column1 As New DataGridViewTextBoxColumn()
            column1.DataPropertyName = dcId.ColumnName
            column1.HeaderText = "ID"
            column1.Name = dcId.ColumnName
            column1.SortMode = DataGridViewColumnSortMode.Automatic
            column1.ValueType = dcId.DataType
            dtgPackets.Columns.Add(column1)
            dtgPackets.Columns(dcId.ColumnName).Visible = False

            Dim column2 As New DataGridViewTextBoxColumn()
            column2.DataPropertyName = dcSKU.ColumnName
            column2.Name = dcSKU.ColumnName
            column2.SortMode = DataGridViewColumnSortMode.Automatic
            column2.ValueType = dcSKU.DataType
            dtgPackets.Columns.Add(column2)

            Dim iTotalRows As Integer = 0

            For iTotalRows = 0 To dtPackets.Rows.Count - 1
                Me.dtgPackets.Rows.Add()
                dtgPackets.Rows(iTotalRows).Cells(0).Value = dtPackets.Rows(iTotalRows)("PacketSize")
                dtgPackets.Rows(iTotalRows).Cells(1).Value = dtPackets.Rows(iTotalRows)("SystemId")
                dtgPackets.Rows(iTotalRows).Cells(2).Value = dtPackets.Rows(iTotalRows)("SKU_CODE")
            Next

            'dtgPackets.DataSource = dtPackets
            'dtgPackets.Refresh()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbProducts1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProducts1.SelectedIndexChanged
        If Me.cmbProducts1.SelectedValue <> Nothing Then
            Dim sProCode As String = cmbProducts1.SelectedValue
            'Dim cmdText As String = "Select * from Products where ProductCode='" & sProCode & "'"
            'Dim rowProduct As DataRow
            'Dim dsProduct As DataSet
            'dsProduct = ExecuteQuery(cmdText, Execute.DataSet)
            'rowProduct = dsProduct.Tables(0).Rows(0)
            'txtProCode.Text = rowProduct("ProductCode")
            txtProCode.Text = sProCode
            'txtProName = rowProduct("ProductName")
            dtgPackets.Columns.Clear()
            dtgPackets.DataSource = Nothing
            dtgPackets.Rows.Clear()
            dtgPackets.Refresh()
            dtgPackets.AutoGenerateColumns = False
            SetPacketGrid(sProCode)
            If dtgPackets.RowCount > 0 Then
                btnChidEdit.Enabled = True
                btnChildDel.Enabled = True
            Else
                btnChidEdit.Enabled = False
                btnChildDel.Enabled = False
            End If
        End If
        If sStatus = "Edit" Then
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnCancel.Enabled = False
            btnChildAdd.Enabled = True
            btnChildSave.Enabled = False
            btnChildCancel.Enabled = False
            If dtgPackets.RowCount > 0 Then
                btnChidEdit.Enabled = True
                btnChildDel.Enabled = True
            Else
                btnChidEdit.Enabled = False
                btnChildDel.Enabled = False
            End If
        End If
    End Sub

    Private Sub dtgPackets_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPackets.CellValueChanged
        'If sStatus = "Edit" Then



        '    Dim cell As DataGridViewCell = dtgPackets.Item(e.ColumnIndex, e.RowIndex)

        '    Dim cmdText As String = System.String.Empty
        '    Dim iFoundRec As Integer
        '    If cell.IsInEditMode Then
        '        Dim c As Control = dtgPackets.EditingControl
        '        Select Case dtgPackets.Columns(e.ColumnIndex).Name
        '            Case "PacketSize"
        '                cmdText = "Select count(*) as total from  Serials inner join packets on Serials.ProductCode = packets.ProductCode where Serials.ProductCode='" & cmbProducts1.SelectedValue & "' And Serials.PacketSize=packets.PacketSize and packets.SystemId=" & dtgPackets.Rows(e.RowIndex).Cells(1).Value
        '                cmdText = cmdText & " union all " & "select count(*) as total from packets where ProductCode='" & cmbProducts1.SelectedValue & "' And PacketSize=" & dtgPackets.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        '                cmdText = "select sum(total) from ( " & cmdText & ")"
        '                iFoundRec = ExecuteQuery(cmdText, Execute.Scalar)
        '                If iFoundRec = 0 Then
        '                    cmdText = "Update Packets set PacketSize=" & dtgPackets.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & " where ProductCode='" & cmbProducts1.SelectedValue & "' and SystemId=" & dtgPackets.Rows(e.RowIndex).Cells(1).Value
        '                    ExecuteQuery(cmdText, Execute.None)
        '                Else
        '                    MessageBox.Show("Record not update", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    dtgPackets.Columns.Clear()
        '                    dtgPackets.DataSource = Nothing
        '                    dtgPackets.Rows.Clear()
        '                    dtgPackets.Refresh()
        '                    dtgPackets.AutoGenerateColumns = False
        '                    SetPacketGrid(cmbProducts1.SelectedValue)
        '                End If
        '        End Select
        '    End If
        'End If
    End Sub

    Private Sub dtgPackets_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgPackets.UserDeletingRow
        e.Cancel = True
    End Sub

    Private Sub dtgPackets_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dtgPackets.CellValidating
        Dim cell As DataGridViewCell = dtgPackets.Item(e.ColumnIndex, e.RowIndex)

        'If cell.IsInEditMode Then
        '    Dim c As Control = dtgPackets.EditingControl
        '    If e.ColumnIndex = 0 Then
        '        If Not IsNumeric(c.Text) Then
        '            MessageBox.Show("Packet size must be numeric", "Products", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            c.Text = 0
        '            'e.Cancel = True
        '        End If
        '    End If
        'End If

        If sStatus = "Edit" Then
            Dim cmdText As String = System.String.Empty
            Dim iFoundRec As Integer
            If cell.IsInEditMode Then
                Dim c As Control = dtgPackets.EditingControl
                'Dim c As Control = dtgPackets.EditingControl
                If e.ColumnIndex = 0 Then
                    If IsNumeric(c.Text) Then
                        Dim i As Integer = 0
                        For i = 0 To dtgPackets.RowCount - 1
                            If c.Text = dtgPackets.Item(0, i).Value And e.RowIndex <> i Then
                                MessageBox.Show("Same record not allow to Update")
                                cmdText = "Select PacketSize from packets where SystemId=" & dtgPackets.Rows(e.RowIndex).Cells(1).Value
                                'c.Text = ExecuteQuery(cmdText, Execute.Scalar)
                                ''e.Cancel = True
                                'Exit Sub
                                Exit For
                            End If
                        Next
                    Else
                        MessageBox.Show("Packet size must be numeric", "Products", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        cmdText = "Select PacketSize from packets where SystemId=" & dtgPackets.Rows(e.RowIndex).Cells(1).Value
                    End If
                End If
                If cmdText <> System.String.Empty Then
                    c.Text = ExecuteQuery(cmdText, Execute.Scalar)
                    Exit Sub
                End If
                Select Case dtgPackets.Columns(e.ColumnIndex).Name
                    Case "PacketSize"
                        cmdText = "Select count(*) as total from  Serials inner join packets on Serials.ProductCode = packets.ProductCode where Serials.ProductCode='" & cmbProducts1.SelectedValue & "' And Serials.PacketSize=packets.PacketSize and packets.SystemId=" & dtgPackets.Rows(e.RowIndex).Cells(1).Value
                        'cmdText = cmdText & " union all " & "select count(*) as total from packets where ProductCode='" & cmbProducts1.SelectedValue & "' And PacketSize=" & dtgPackets.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                        'cmdText = "select sum(total) from ( " & cmdText & ")"
                        'cmdText = "Select count(*) from packets where PacketSize=" & dtgPackets.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & " And "
                        iFoundRec = ExecuteQuery(cmdText, Execute.Scalar)
                        If iFoundRec = 0 Then
                            btnChildSave.Enabled = True
                            'cmdText = "Update Packets set PacketSize=" & dtgPackets.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & " where ProductCode='" & cmbProducts1.SelectedValue & "' and SystemId=" & dtgPackets.Rows(e.RowIndex).Cells(1).Value
                            'ExecuteQuery(cmdText, Execute.None)
                        Else
                            MessageBox.Show("Record not allow to update", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            cmdText = System.String.Empty
                            cmdText = "Select PacketSize from packets where SystemId=" & dtgPackets.Rows(e.RowIndex).Cells(1).Value
                            c.Text = ExecuteQuery(cmdText, Execute.Scalar)
                            Exit Sub
                            'dtgPackets.Columns.Clear()
                            'dtgPackets.DataSource = Nothing
                            'dtgPackets.Rows.Clear()
                            'dtgPackets.Refresh()
                            'dtgPackets.AutoGenerateColumns = False
                            'SetPacketGrid(cmbProducts1.SelectedValue)
                            'c.Text = c.
                        End If
                End Select
            End If
        End If
        If bDetaialAdd = True Then
            If cell.IsInEditMode Then
                Dim c As Control = dtgPackets.EditingControl
                If e.ColumnIndex = 0 Then
                    If Not IsNumeric(c.Text) Then
                        MessageBox.Show("Packet size must be numeric", "Products", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        c.Text = 0
                    End If
                    Dim i As Integer = 0
                    For i = 0 To dtgPackets.RowCount - 1
                        If c.Text = dtgPackets.Item(0, i).Value And e.RowIndex <> i Then
                            MessageBox.Show("Same record not allow to insert")
                            e.Cancel = True
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub frmProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Icon = New Icon(Me.GetType(), "TBS_small3.ico")
        'Try
        '    Dim ico As New System.Drawing.Icon(Application.StartupPath & "\TBS_small3.ico")
        '    Me.Icon = ico
        '    Me.Icon.i()

        'Catch ex As Exception

        'End Try
        'Me.Icon = Nothing


        SetControls()
    End Sub

    Private Sub btnChildCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildCancel.Click
        sStatus = System.String.Empty
        bDetaialAdd = False
        Dim ProductIndex As Integer = cmbProducts1.SelectedIndex
        SetControls()
        cmbProducts1.SelectedIndex = ProductIndex
    End Sub

    Private Sub cmbProducts1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProducts1.KeyPress
        e.Handled = True
    End Sub

    Private Sub dtgPackets_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPackets.RowEnter
        Try
            dtgPackets.Rows(e.RowIndex).Selected = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtgPackets_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPackets.CellDoubleClick
        Try
            dtgPackets.Rows(e.RowIndex).Selected = True

        Catch ex As Exception

        End Try
    End Sub
End Class