Imports System.IO
Public Class frmRegion
    Public sStatus As String  '' used for status of Region form means add or edit status
    Public bDetaialAdd As Boolean  '' used for check the status of add detail of Products
    Public iCurRow As Integer
    Public iCurCel As Integer

    Private Sub cmbRegions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegions.SelectedIndexChanged
        If Me.cmbRegions.SelectedValue <> Nothing Then
            lblSelectedRegion.Text = "Region    " & cmbRegions.Text
            Dim sRegCode As String = cmbRegions.SelectedValue
            Dim cmdText As String = "SELECT * FROM Regions WHERE ID=" & sRegCode
            Dim rowRegion As DataRow
            Dim dsRegion As DataSet
            dsRegion = ExecuteQuery(cmdText, Execute.DataSet)
            rowRegion = dsRegion.Tables(0).Rows(0)
            txtRegDesc.Text = rowRegion("Description")
            dtgProducts.Columns.Clear()
            dtgProducts.DataSource = Nothing

            SetProductRegionGrid(sRegCode)
            If dtgProducts.RowCount > 0 Then
                btnChidEdit.Enabled = True
                btnChildDel.Enabled = True
            Else
                btnChidEdit.Enabled = False
                btnChildDel.Enabled = False
            End If
        End If

        If sStatus = "Edit" Then
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnSave.Enabled = False
            btnCancel.Enabled = False
            Me.txtRegDesc.Enabled = False
            If dtgProducts.RowCount > 0 Then
                btnChidEdit.Enabled = True
                btnChildDel.Enabled = True
            Else
                btnChidEdit.Enabled = False
                btnChildDel.Enabled = False
            End If
            btnChildCancel.Enabled = False
            btnChildSave.Enabled = False
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try

            sStatus = "Add"
            lblSelectedRegion.Text = "Region    "
            lblRegDesc.Visible = True
            txtRegDesc.Visible = True
            cmbRegions.Visible = False
            lblRegID.Visible = False
            lblRegCode.Visible = True
            txtRegCode.Visible = True
            Me.txtRegDesc.Enabled = True
            txtRegCode.Text = System.String.Empty
            txtRegDesc.Text = System.String.Empty
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnSave.Enabled = True
            btnChildAdd.Enabled = True
            btnChildDel.Enabled = False
            cmbRegions.DataSource = Nothing
            cmbRegions.Refresh()
            'cmbRegions.Items.Clear()
            dtgProducts.DataSource = Nothing
            dtgProducts.Rows.Clear()
            dtgProducts.Refresh()
        Catch ex As Exception
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If sStatus = "Add" Then
            Add_ProductRegion()
            'sStatus = System.String.Empty
            'SetControls()
            'cmbProducts1.SelectedIndex = cmbProducts1.Items.Count - 1
        ElseIf sStatus = "Edit" Then
            Edit_Region()
            'Edit_Child()
            'sStatus = System.String.Empty
            SetControls()
        End If
    End Sub
    Private Sub Add_ProductRegion()
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0

        Try
            If txtRegCode.Text.Length AndAlso txtRegCode.Text <> "" Then
                cmdText = "Select ID from Regions where RegionCode='" & txtRegCode.Text & "'"
                duplicate = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar))
                If duplicate = 0 Then
                    'cmdText = "select max(ID) from Regions"
                    'Dim RegionID As Integer = 0
                    'RegionID = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar)) + 1
                    cmdText = "INSERT INTO Regions (RegionCode,Description) VALUES ('" & txtRegCode.Text & "','" & txtRegDesc.Text & "')"
                    ExecuteQuery(cmdText, Execute.None)
                    cmdText = "select max(ID) from Regions"
                    Dim RegionID As Integer = 0
                    RegionID = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar))
                    If bDetaialAdd = True Then
                        Dim bDetailAdd As Boolean = Add_Detail(RegionID)
                        bDetaialAdd = False
                    End If
                    sStatus = System.String.Empty
                    MessageBox.Show("Record insert Success", "Regions", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SetControls()
                    If cmbRegions.Items.Count > 0 Then
                        cmbRegions.SelectedIndex = cmbRegions.Items.Count - 1
                    End If

                Else
                    MessageBox.Show("Region already exits ,Change the Region Code ", "Regions", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Enter the Region code", "Regions", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Private Sub SetControls()
        Try

            lblSelectedRegion.Text = "Region    "
            Me.lblRegCode.Visible = False
            Me.txtRegCode.Visible = False
            Me.lblRegDesc.Visible = True
            Me.txtRegDesc.Visible = True
            Me.cmbRegions.Visible = True
            Me.cmbRegions.Enabled = True
            Me.lblRegID.Visible = True
            Me.txtRegDesc.Enabled = False
            Me.txtRegCode.Text = System.String.Empty
            Me.txtRegDesc.Text = System.String.Empty


            Me.btnCancel.Enabled = False
            Me.btnSave.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnChildAdd.Enabled = True
            dtgProducts.Rows.Clear()
            SetComboRegions()
            If cmbRegions.Items.Count = 0 Then
                btnChildAdd.Enabled = False
                btnChildDel.Enabled = False
                btnChidEdit.Enabled = False
                btnEdit.Enabled = False
            Else
                btnChildAdd.Enabled = True
                btnChildDel.Enabled = True
                btnChidEdit.Enabled = True
            End If
            If dtgProducts.RowCount > 0 Then
                btnChildDel.Enabled = True
                btnChidEdit.Enabled = True
            End If
            btnChildCancel.Enabled = False
            btnChildSave.Enabled = False
            btnSearch.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Error : Please Try later...")
        End Try
    End Sub

    Private Sub SetComboRegions()
        Dim dtRegions As DataTable
        dtRegions = Common.GetRegions()
        With Me.cmbRegions
            .Text = String.Empty
            .DisplayMember = "RegionCode"
            .ValueMember = "ID"
            .DataSource = dtRegions
            .Refresh()
        End With
        If cmbRegions.Items.Count > 0 Then
            cmbRegions.SelectedIndex = 0
            Dim RegionCode As Integer = cmbRegions.SelectedValue
            dtgProducts.DataSource = Nothing
            dtgProducts.Columns.Clear()
            SetProductRegionGrid(RegionCode)
        End If
        dtgProducts.ReadOnly = True
    End Sub
    Private Sub SetProductRegionGrid(ByVal RegionCode As String)
        Try
            Dim dtProPaacket As DataTable
            dtProPaacket = Common.GetProductsAndPackets(RegionCode)
            Dim dcId As New DataColumn(dtProPaacket.Columns("ProdcutPacketID").ColumnName, dtProPaacket.Columns("ProdcutPacketID").DataType)
            Dim dcProductName As New DataColumn(dtProPaacket.Columns("ProductName").ColumnName, dtProPaacket.Columns("ProductName").DataType)
            Dim dcPacketSize As New DataColumn(dtProPaacket.Columns("PacketSize").ColumnName, dtProPaacket.Columns("PacketSize").DataType)
            Dim dcPrimaryKey As New DataColumn(dtProPaacket.Columns("ID").ColumnName, dtProPaacket.Columns("ID").DataType)

            Dim column As New DataGridViewTextBoxColumn()
            column.DataPropertyName = dcId.ColumnName
            column.HeaderText = "ID"
            column.Name = dcId.ColumnName
            column.SortMode = DataGridViewColumnSortMode.Automatic
            column.ValueType = dcId.DataType
            dtgProducts.Columns.Add(column)
            dtgProducts.Columns(dcId.ColumnName).Visible = False

            Dim column1 As New DataGridViewTextBoxColumn()
            column1.DataPropertyName = dcProductName.ColumnName
            column1.HeaderText = "Product"
            column1.Name = dcProductName.ColumnName
            column1.SortMode = DataGridViewColumnSortMode.Automatic
            column1.ValueType = dcProductName.DataType
            column1.Width = 135
            dtgProducts.Columns.Add(column1)


            Dim column2 As New DataGridViewTextBoxColumn()
            column2.DataPropertyName = dcPacketSize.ColumnName
            column2.HeaderText = "Packet Size"
            column2.Name = dcPacketSize.ColumnName
            column2.SortMode = DataGridViewColumnSortMode.Automatic
            column2.ValueType = dcPacketSize.DataType
            column2.Width = 90
            dtgProducts.Columns.Add(column2)

            Dim column3 As New DataGridViewTextBoxColumn()
            column3.DataPropertyName = dcPrimaryKey.ColumnName
            column3.HeaderText = "PKey"
            column3.Name = dcPrimaryKey.ColumnName
            column3.SortMode = DataGridViewColumnSortMode.Automatic
            column3.ValueType = dcPrimaryKey.DataType
            column3.Width = 90
            dtgProducts.Columns.Add(column3)
            dtgProducts.Columns(dcPrimaryKey.ColumnName).Visible = False

            Dim iTotalRows As Integer = 0

            For iTotalRows = 0 To dtProPaacket.Rows.Count - 1
                Me.dtgProducts.Rows.Add()
                dtgProducts.Rows(iTotalRows).Cells(0).Value = dtProPaacket.Rows(iTotalRows)("ProdcutPacketID")
                dtgProducts.Rows(iTotalRows).Cells(1).Value = dtProPaacket.Rows(iTotalRows)("ProductName")
                dtgProducts.Rows(iTotalRows).Cells(2).Value = dtProPaacket.Rows(iTotalRows)("PacketSize")
                dtgProducts.Rows(iTotalRows).Cells(3).Value = dtProPaacket.Rows(iTotalRows)("ID")
            Next

            'dtgPackets.DataSource = dtProPaacket
            'dtgPackets.Refresh()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            sStatus = "Edit"
            Me.lblRegDesc.Visible = True
            Me.txtRegDesc.Visible = True
            Me.lblRegID.Visible = True
            Me.cmbRegions.Visible = True
            Me.lblRegCode.Visible = False
            Me.txtRegCode.Visible = False
            Me.txtRegDesc.Enabled = True

            Me.btnAdd.Enabled = False
            Me.btnEdit.Enabled = False
            Me.btnSave.Enabled = True
            Me.btnCancel.Enabled = True

            Me.btnChidEdit.Enabled = False
            Me.btnChildAdd.Enabled = False
            Me.btnChildCancel.Enabled = False
            Me.btnSearch.Enabled = False
            Me.btnChildDel.Enabled = False
            Me.btnChildSave.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim RegionID As Integer = cmbRegions.SelectedIndex
        sStatus = System.String.Empty
        SetControls()
        If RegionID > -1 Then
            cmbRegions.SelectedIndex = RegionID
        End If
    End Sub

    Private Sub Edit_Region()
        Try
            Dim cmdText As String = System.String.Empty
            If (cmbRegions.SelectedValue <> Nothing) Then
                cmdText = "UPDATE  Regions set Description='" & txtRegDesc.Text & "' where ID=" & cmbRegions.SelectedValue
                ExecuteQuery(cmdText, Execute.None)

                MessageBox.Show("Record upadate Success", "Regions", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sStatus = System.String.Empty
                'SetControls()
            Else
                MessageBox.Show("For Regions code update,Select Region first", "Regions", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmRegion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub btnChildAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildAdd.Click
        If cmbRegions.Text <> "" Or txtRegCode.Text <> "" Then
            bDetaialAdd = True
            dtgProducts.ReadOnly = False
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
                btnCancel.Enabled = False
                cmbRegions.Enabled = False
            End If

            'btnCancel.Enabled = True
            btnChildCancel.Enabled = True
            If dtgProducts.RowCount > 0 Then
                If Not dtgProducts.Item(0, dtgProducts.RowCount - 1).Value = Nothing Then
                    Me.dtgProducts.Rows.Add()
                    Me.dtgProducts.CurrentCell = Me.dtgProducts(1, dtgProducts.RowCount - 1)
                    'Me.dtgProducts.Rows(dtgProducts.RowCount - 1).Selected = True
                    'Me.dtgProducts.Item(1, dtgProducts.RowCount - 1).Selected = True
                End If
            Else
                Me.dtgProducts.Rows.Add()
            End If
        End If
        'Me.dtgProducts.Rows.Add()
    End Sub

    Private Sub btnChildSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildSave.Click

        Dim RegionID As Integer = cmbRegions.SelectedIndex
        If sStatus = "Add" Then
            Add_ProductRegion()
            'sStatus = System.String.Empty
            'SetControls()
        ElseIf sStatus = "Edit" Then
            Edit_Child()
            'sStatus = System.String.Empty
            SetControls()
            cmbRegions.SelectedIndex = RegionID
        End If
        If bDetaialAdd = True And sStatus = System.String.Empty Then
            'Dim selProID As Integer = cmbProducts1.SelectedIndex
            Add_Detail()
            bDetaialAdd = False
            SetControls()
            cmbRegions.SelectedIndex = RegionID
        End If
    End Sub
    Private Sub Edit_Child()
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0
        Dim iTotalRow As Integer = 0
        Dim iRegionCode As Integer = 0
        Try
            iRegionCode = cmbRegions.SelectedValue
            Dim i As Integer
            For i = 0 To dtgProducts.RowCount - 1
                cmdText = "Update ProductPacketRegion set  ProdcutPacketID=" & dtgProducts.Rows(i).Cells(0).Value & " where  ID=" & dtgProducts.Rows(i).Cells(0).Value
                ExecuteQuery(cmdText, Execute.None)
            Next
        Catch ex As Exception
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function Add_Detail(ByVal RegionCode As Integer) As Boolean
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0
        Dim iTotalRow As Integer = 0
        Dim iRegionCode As Integer
        Dim bRowsCheck As Boolean = False
        Try
            bRowsCheck = CheckRows_Insert()
            If bRowsCheck = False Then
                If dtgProducts.RowCount > 0 Then
                    iRegionCode = RegionCode
                    For iTotalRow = 0 To dtgProducts.RowCount - 1
                        'If dtgProducts.Rows(iTotalRow).Cells(0).Value > 0 And dtgProducts.Rows(iTotalRow).Cells(1).Value = Nothing And dtgProducts.Rows(iTotalRow).Cells(2).Value = Nothing Then
                        cmdText = "Select count(*) from  ProductPacketRegion where RegionCode=" & iRegionCode & " And ProdcutPacketID=" & dtgProducts.Rows(iTotalRow).Cells(0).Value
                        duplicate = ExecuteQuery(cmdText, Execute.Scalar)
                        If duplicate = 0 Then
                            cmdText = "INSERT INTO ProductPacketRegion (RegionCode,ProdcutPacketID) values(" & iRegionCode & "," & dtgProducts.Rows(iTotalRow).Cells(0).Value & ")"
                            ExecuteQuery(cmdText, Execute.None)
                        End If
                        'End If
                    Next
                    Return True
                End If
            Else
                MessageBox.Show("Data not in correct order pls add record again...")
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub Add_Detail()
        Dim cmdText As String = System.String.Empty
        Dim duplicate As Integer = 0
        Dim iTotalRow As Integer = 0
        Dim iRegionCode As Integer
        Dim bRowsCheck As Boolean = False

        'Dim sProductCode = System.String.Empty
        Try
            bRowsCheck = CheckRows_Insert()
            If bRowsCheck = False Then
                If dtgProducts.RowCount > 0 Then
                    iRegionCode = cmbRegions.SelectedValue
                    For iTotalRow = 0 To dtgProducts.RowCount - 1
                        'If dtgProducts.Rows(iTotalRow).Cells(0).Value > 0 And dtgProducts.Rows(iTotalRow).Cells(1).Value = Nothing And dtgProducts.Rows(iTotalRow).Cells(2).Value = Nothing Then
                        cmdText = "Select count(*) from  ProductPacketRegion where RegionCode=" & iRegionCode & " And ProdcutPacketID=" & dtgProducts.Rows(iTotalRow).Cells(0).Value
                        duplicate = ExecuteQuery(cmdText, Execute.Scalar)
                        If duplicate = 0 Then
                            cmdText = "INSERT INTO ProductPacketRegion (RegionCode,ProdcutPacketID) values(" & iRegionCode & "," & dtgProducts.Rows(iTotalRow).Cells(0).Value & ")"
                            ExecuteQuery(cmdText, Execute.None)
                        End If
                        'End If
                    Next
                End If
            Else
                MessageBox.Show("Data not in correct order pls add record again...")
            End If
        Catch ex As Exception
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtgProducts_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dtgProducts.EditingControlShowing
        'AddHandler e.Control.KeyUp, AddressOf Control_KeyUp
        RemoveHandler e.Control.KeyPress, AddressOf Control_KeyPress
        AddHandler e.Control.KeyPress, AddressOf Control_KeyPress
        RemoveHandler e.Control.KeyDown, AddressOf Control_KeyDown
        AddHandler e.Control.KeyDown, AddressOf Control_KeyDown

    End Sub
    Public Function CheckDuplicate_Rows(ByVal colNumber As Integer, ByVal rowNumber As Integer, ByVal value As String) As Boolean
        Dim bResult As Boolean = False
        Dim i As Integer
        For i = 0 To dtgProducts.RowCount - 1
            If CheckDBNull(value) = CheckDBNull(dtgProducts.Item(2, i).Value) And dtgProducts.Item(1, i).Value = dtgProducts.Item(1, rowNumber).Value And rowNumber <> i Then
                MessageBox.Show("Same record not allow to insert")
                dtgProducts.Item(2, rowNumber).Value = 0
                bResult = True
            End If
        Next
        Return bResult
    End Function

    Public Function CheckDuplicate_Rows() As Boolean
        Dim bResult As Boolean = False
        Dim i As Integer
        Dim j As Integer
        For i = 0 To dtgProducts.RowCount - 1
            For j = 0 To dtgProducts.RowCount - 1
                If CheckDBNull(dtgProducts.Item(2, i).Value) = CheckDBNull(dtgProducts.Item(2, j).Value) And dtgProducts.Item(1, i).Value = dtgProducts.Item(1, j).Value And i <> j Then
                    MessageBox.Show("The Product and Packet Size already assigned to selected Region...")
                    dtgProducts.Item(2, j).Value = 0
                    bResult = True
                End If
            Next
        Next
    End Function
    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If dtgProducts.Item(3, dtgProducts.CurrentCell.RowIndex).Value = Nothing Then
        Else
            e.Handled = True
        End If
        'If (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or Asc(e.KeyChar) = Keys.Back Then
        'Else
        '    e.Handled = True
        'End If
    End Sub

    Private Sub Control_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim cmdText As String = System.String.Empty
        Dim point As New Point
        point = dtgProducts.CurrentCellAddress
        Dim col As Integer = point.X
        Dim row As Integer = point.Y
        Dim bDuplicateRow As Boolean = False

        If e.KeyCode = Keys.F9 Then
            Dim sIds As String = System.String.Empty
            If dtgProducts.RowCount > 0 Then

                Dim i As Integer = 0
                For i = 0 To dtgProducts.RowCount - 1
                    If dtgProducts.Item(0, i).Value IsNot Nothing Then
                        sIds += dtgProducts.Item(0, i).Value & ","
                    End If
                Next

            End If
            If sIds <> System.String.Empty Then
                sIds = sIds.Substring(0, sIds.Length - 1).Trim
                cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets " & _
                        " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode " & _
                        " Where Packets.SystemId not in(" & sIds & ")"
            Else
                cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets " & _
                            " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode "
            End If
            Dim f As frmSearch
            f = New frmSearch(cmdText)
            f.Text = "Product and Packet Size"
            f.ShowDialog(Me)
            Dim iSelectID As Integer = frmSearch.iID


            cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets" & _
                                            " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode WHERE SystemId=" & iSelectID
            Dim dsPackets As DataSet
            dsPackets = ExecuteQuery(cmdText, Execute.DataSet)
            If dsPackets.Tables(0).Rows.Count > 0 Then
                dtgProducts.Item(0, row).Value = dsPackets.Tables(0).Rows(0).Item("SystemId")
                dtgProducts.Item(1, row).Value = dsPackets.Tables(0).Rows(0).Item("ProductName")
                dtgProducts.Item(2, row).Value = dsPackets.Tables(0).Rows(0).Item("PacketSize")
                SendKeys.Send("{ENTER}")
                SendKeys.Send("{TAB}")
            End If
        End If

        'If e.KeyCode = Keys.F9 Then
        '    If dtgProducts.Item(3, row).Value = Nothing Then
        '        Dim f As frmSearch
        '        'If dtgProducts.CurrentCell.ColumnIndex = 1 Then
        '        If dtgProducts.CurrentCell.ColumnIndex = 1 Then
        '            'MessageBox.Show(dtgProducts.CurrentCell.ToString)
        '            '    cmdText = "SELECT  Packets.SystemId,Packets.ProductCode,Packets.PacketSize ,Products.ProductName FROM Packets " & _
        '            '                " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode "
        '            cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets " & _
        '                                        " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode "
        '        ElseIf dtgProducts.CurrentCell.ColumnIndex = 2 Then
        '            If dtgProducts.Item(1, row).Value = "" Then
        '                MessageBox.Show("First Select product...")
        '                Exit Sub
        '            End If
        '            '    cmdText = "SELECT  Packets.SystemId,Packets.ProductCode,Packets.PacketSize ,Products.ProductName FROM Packets " & _
        '            '                " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode where Products.ProductName='" & dtgProducts.Item(1, row).Value & "'"
        '            cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets " & _
        '                                        " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode where Products.ProductName='" & dtgProducts.Item(1, row).Value & "'"
        '        End If
        '        f = New frmSearch(cmdText)
        '        f.ShowDialog(Me)
        '        Dim iSelectID As Integer = frmSearch.iID
        '        'cmdText = "SELECT  Packets.SystemId,Packets.ProductCode,Packets.PacketSize ,Products.ProductName FROM Packets" & _
        '        '                " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode WHERE SystemId=" & iSelectID
        '        cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets" & _
        '                                    " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode WHERE SystemId=" & iSelectID
        '        Dim dsPackets As DataSet
        '        dsPackets = ExecuteQuery(cmdText, Execute.DataSet)
        '        If dsPackets.Tables(0).Rows.Count > 0 Then
        '            dtgProducts.Item(0, row).Value = dsPackets.Tables(0).Rows(0).Item("SystemId")
        '            dtgProducts.Item(1, row).Value = dsPackets.Tables(0).Rows(0).Item("ProductName")
        '            dtgProducts.Item(2, row).Value = dsPackets.Tables(0).Rows(0).Item("PacketSize")
        '            SendKeys.Send("{ENTER}")
        '            SendKeys.Send("{TAB}")
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub dtgProducts_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dtgProducts.CellValidating
        Dim cell As DataGridViewCell = dtgProducts.Item(e.ColumnIndex, e.RowIndex)
        Dim cmdText As String = System.String.Empty
        Dim ds As DataSet
        Dim dtProducts As DataTable
        Dim iFoundRecord As Integer = 0

        If sStatus = "Edit" Then
            Dim iFoundRec As Integer
            If cell.IsInEditMode Then
                Dim c As Control = dtgProducts.EditingControl
                If e.ColumnIndex = 1 Then
                    cmdText = "Select count(*) from Serials where ProdcutPacketRegionID=" & Me.dtgProducts.Rows(e.RowIndex).Cells(3).Value
                    iFoundRecord = ExecuteQuery(cmdText, Execute.Scalar)
                    If iFoundRec > 0 Then
                        MessageBox.Show("Record not updata,Product has serials...")
                        cmdText = "select ProductPacketRegion.ProdcutPacketID,Products.ProductName " & _
                                   " from ProductPacketRegion, Products, Packets " & _
                                    " where(ProductPacketRegion.ProdcutPacketID = Packets.SystemId and Products.ProductCode=Packets.ProductCode " & _
                                    " and ProductPacketRegion.id=" & Me.dtgProducts.Rows(e.RowIndex).Cells(3).Value
                        ds = ExecuteQuery(cmdText, Execute.DataSet)
                        Me.dtgProducts.Rows(e.RowIndex).Cells(1).Value = ds.Tables(0).Rows(0).Item("ProductName")
                        Me.dtgProducts.Rows(e.RowIndex).Cells(0).Value = ds.Tables(0).Rows(0).Item("ProdcutPacketID")
                    Else
                        btnChidEdit.Enabled = True
                    End If
                End If
            End If
        End If

        '        If e.ColumnIndex = 2 Then
        '            If IsNumeric(c.Text) Then
        '                Dim i As Integer = 0
        '                For i = 0 To dtgProducts.RowCount - 1
        '                    If c.Text = dtgProducts.Item(0, i).Value And e.RowIndex <> i Then
        '                        MessageBox.Show("Duplicate record not allow to Update")
        '                        cmdText = "Select PacketSize from packets where SystemId=" & dtgProducts.Rows(e.RowIndex).Cells(1).Value
        '                        'c.Text = ExecuteQuery(cmdText, Execute.Scalar)
        '                        ''e.Cancel = True
        '                        'Exit Sub
        '                        Exit For
        '                    End If
        '                Next
        '            Else
        '                MessageBox.Show("Packet size must be numeric", "Products", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                cmdText = "Select PacketSize from packets where SystemId=" & dtgProducts.Rows(e.RowIndex).Cells(1).Value
        '            End If
        '        End If
        '        If cmdText <> System.String.Empty Then
        '            c.Text = ExecuteQuery(cmdText, Execute.Scalar)
        '            Exit Sub
        '        End If
        '        Select Case dtgProducts.Columns(e.ColumnIndex).Name
        '            Case "PacketSize"
        '                cmdText = "Select count(*) as total from  Serials inner join packets on Serials.ProductCode = packets.ProductCode where Serials.ProductCode='" & cmbProducts1.SelectedValue & "' And Serials.PacketSize=packets.PacketSize and packets.SystemId=" & dtgProducts.Rows(e.RowIndex).Cells(1).Value
        '                'cmdText = cmdText & " union all " & "select count(*) as total from packets where ProductCode='" & cmbProducts1.SelectedValue & "' And PacketSize=" & dtgProducts.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        '                'cmdText = "select sum(total) from ( " & cmdText & ")"
        '                'cmdText = "Select count(*) from packets where PacketSize=" & dtgProducts.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & " And "
        '                iFoundRec = ExecuteQuery(cmdText, Execute.Scalar)
        '                If iFoundRec = 0 Then
        '                    btnChildSave.Enabled = True
        '                    'cmdText = "Update Packets set PacketSize=" & dtgProducts.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & " where ProductCode='" & cmbProducts1.SelectedValue & "' and SystemId=" & dtgProducts.Rows(e.RowIndex).Cells(1).Value
        '                    'ExecuteQuery(cmdText, Execute.None)
        '                Else
        '                    MessageBox.Show("Record not allow to update", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    cmdText = System.String.Empty
        '                    cmdText = "Select PacketSize from packets where SystemId=" & dtgProducts.Rows(e.RowIndex).Cells(1).Value
        '                    c.Text = ExecuteQuery(cmdText, Execute.Scalar)
        '                    Exit Sub
        '                    'dtgProducts.Columns.Clear()
        '                    'dtgProducts.DataSource = Nothing
        '                    'dtgProducts.Rows.Clear()
        '                    'dtgProducts.Refresh()
        '                    'dtgProducts.AutoGenerateColumns = False
        '                    'SetPacketGrid(cmbProducts1.SelectedValue)
        '                    'c.Text = c.
        '                End If
        '        End Select
        '    End If
        'End If
        If bDetaialAdd = True Then
            If cell.IsInEditMode Then
                Dim c As Control = dtgProducts.EditingControl
                Dim i As Integer = 0
                If e.ColumnIndex = 2 Then
                    Dim bDulicateRow As Boolean = False
                    If Not IsNumeric(c.Text) AndAlso c.Text.Length > 0 Then
                        MessageBox.Show("Packet size must be numeric", "Regions", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        c.Text = 0
                        dtgProducts.Item(0, e.RowIndex).Value = 0
                        'e.Cancel = True
                        Exit Sub
                    ElseIf c.Text = "" Then
                        dtgProducts.Item(0, e.RowIndex).Value = 0
                        Exit Sub
                    End If

                    bDulicateRow = CheckDuplicate_Rows(e.ColumnIndex, e.RowIndex, c.Text)
                    If bDulicateRow = True Then
                        'MessageBox.Show("Duplicate record not allow to insert")
                        'e.Cancel = True
                        c.Text = 0
                        dtgProducts.Item(0, e.RowIndex).Value = 0
                        Exit Sub
                    End If
                End If

                'If e.ColumnIndex = 1 Then
                If e.ColumnIndex = 1 And c.Text <> "" Then
                    cmdText = "Select * from packets inner join products on packets.ProductCode=products.ProductCode" & _
                                "  where products.ProductName='" & c.Text & "'"
                    ds = ExecuteQuery(cmdText, Execute.DataSet)
                    'Dim dtProducts As DataTable = ds.Tables(0)
                    dtProducts = ds.Tables(0)
                    If dtProducts.Rows.Count < 1 Then
                        MessageBox.Show("Enter the correct Product or Press F9 Key , or click the Search button....")
                        c.Text = ""
                        dtgProducts.Item(0, e.RowIndex).Value = 0
                        'e.Cancel = True
                        Exit Sub
                    End If

                End If
                'If e.ColumnIndex = 2 Then
                If e.ColumnIndex = 2 Then
                    If c.Text <> 0 Then
                        'If Not IsNumeric(c.Text) Then
                        '    MessageBox.Show("Packet size must be numeric", "Products", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '    c.Text = 0
                        '    e.Cancel = True
                        '    Exit Sub
                        'End If
                        If dtgProducts.Item(1, e.RowIndex).Value = "" Then
                            MessageBox.Show("Select the product first....")
                            Exit Sub
                        End If
                        cmdText = "Select * from packets inner join products on packets.ProductCode=products.ProductCode" & _
                                                        "  where products.ProductName='" & dtgProducts.Item(1, e.RowIndex).Value & "' And packets.PacketSize=" & c.Text
                        ds = Nothing
                        ds = ExecuteQuery(cmdText, Execute.DataSet)
                        dtProducts = Nothing
                        dtProducts = ds.Tables(0)
                        If dtProducts.Rows.Count < 1 Then
                            MessageBox.Show("Enter the correct Packet Size or Press F9 Key or Click the Search Button.....")
                            c.Text = 0
                            dtgProducts.Item(0, e.RowIndex).Value = 0
                            'e.Cancel = True
                            Exit Sub
                        Else
                            dtgProducts.Item(0, e.RowIndex).Value = dtProducts.Rows(0).Item("SystemId")
                            dtgProducts.Item(1, e.RowIndex).Value = dtProducts.Rows(0).Item("ProductName")
                            dtgProducts.Item(2, e.RowIndex).Value = dtProducts.Rows(0).Item("PacketSize")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dtgProducts_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProducts.CellValidated

    End Sub

    Private Sub dtgProducts_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dtgProducts.RowsAdded
        ' MessageBox.Show("Nisar")
    End Sub

    Private Sub dtgProducts_RowValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dtgProducts.RowValidating
        If bDetaialAdd = True Then
            Dim bDuplicateRow As Boolean
            bDuplicateRow = CheckDuplicate_Rows()
        End If

    End Sub
    Public Function CheckRows_Insert() As Boolean
        Dim i As Integer
        Dim bCheckRow As Boolean = False
        For i = 0 To dtgProducts.RowCount - 1
            If dtgProducts.Item(0, i).Value = Nothing Or dtgProducts.Item(0, i).Value = 0 Then
                If i = dtgProducts.RowCount - 1 Then
                    dtgProducts.Rows.RemoveAt(i)
                Else
                    bCheckRow = True
                End If
                Exit For
            End If
        Next
        Return bCheckRow
    End Function

    Private Sub btnChidEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChidEdit.Click
        Try
            sStatus = "Edit"
            lblRegCode.Visible = True
            cmbRegions.Visible = True
            lblRegDesc.Visible = False
            txtRegDesc.Visible = False

            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnChidEdit.Enabled = False
            btnCancel.Enabled = False
            btnSave.Enabled = False
            'btnChildSave.Enabled = True
            btnChildAdd.Enabled = False
            btnChildDel.Enabled = False
            btnChildCancel.Enabled = True
            dtgProducts.ReadOnly = False
        Catch ex As Exception
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnChildCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildCancel.Click
        'sStatus = System.String.Empty
        bDetaialAdd = False
        

        Dim RegionIndex As Integer = cmbRegions.SelectedIndex
        'SetControls()

        dtgProducts.Rows.Clear()
        'SetComboRegions()
        If cmbRegions.Items.Count > 0 Then
            cmbRegions.SelectedIndex = 0
            Dim RegionCode As Integer = cmbRegions.SelectedValue
            dtgProducts.DataSource = Nothing
            dtgProducts.Columns.Clear()
            SetProductRegionGrid(RegionCode)
        End If
        dtgProducts.ReadOnly = True

        If cmbRegions.Items.Count = 0 Then
            btnChildAdd.Enabled = False
            btnChildDel.Enabled = False
            btnChidEdit.Enabled = False
        Else
            btnChildAdd.Enabled = True
            btnChildDel.Enabled = True
            btnChidEdit.Enabled = True
        End If
        btnChildCancel.Enabled = False
        btnChildSave.Enabled = False
        btnSearch.Enabled = False


        If RegionIndex > 0 Then
            cmbRegions.SelectedIndex = RegionIndex
        End If
        If txtRegCode.Text <> "" Then
            btnChildAdd.Enabled = True
        End If
        If sStatus <> "Add" Then
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            cmbRegions.Enabled = True
        End If

    End Sub

    Private Sub btnChildDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChildDel.Click
        Dim cmdText As String = System.String.Empty
        Dim iFoundKey As Integer = 0
        Dim sRegionCode As String = System.String.Empty
        sRegionCode = cmbRegions.Text
        If (MessageBox.Show("Do you really want to delete selected record(s)?", "Delete Warning", MessageBoxButtons.YesNo, _
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, False) = Windows.Forms.DialogResult.Yes) Then
            Try
                If dtgProducts.SelectedRows.Count > 0 Then

                    Dim cnt As Integer = dtgProducts.SelectedRows.Count
                    Dim iRow As Integer
                    For iRow = 0 To cnt - 1
                        'If Me.dtgProducts.SelectedRows.Count > 0 Then
                        'If (Me.dtgPackets.SelectedRows.Count > 0 And Me.dtgPackets.SelectedRows(0).Index <> Me.dtgPackets.Rows.Count - 1) Then
                        cmdText = "Select count(*) from Serials where ProdcutPacketRegionID=" & Me.dtgProducts.SelectedRows(0).Cells(3).Value
                        iFoundKey = ExecuteQuery(cmdText, Execute.Scalar)
                        If iFoundKey = 0 Then
                            cmdText = "Delete * from ProductPacketRegion where ID=" & Me.dtgProducts.SelectedRows(0).Cells(3).Value
                            ExecuteQuery(cmdText, Execute.None)
                            Me.dtgProducts.Rows.RemoveAt(Me.dtgProducts.SelectedRows(0).Index)
                        Else
                            Me.dtgProducts.SelectedRows(0).Selected = False
                            MessageBox.Show("Record not delete,Packet has Security Code", "Products", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        'End If
                    Next
                Else
                    MessageBox.Show("Select row form Packet")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub dtgProducts_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProducts.CellEnter
        Try

            btnSearch.Enabled = False
            If bDetaialAdd = True And dtgProducts.Item(3, e.RowIndex).Value = Nothing Then
                iCurRow = e.RowIndex
                iCurCel = e.ColumnIndex
                btnSearch.Enabled = True
            End If

            'dtgProducts(e.ColumnIndex, e.RowIndex).Style.SelectionBackColor = Color.Blue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click



        Dim cmdText As String = System.String.Empty
        Dim iRowIndex As Integer = iCurRow
        Dim iCelIndex As Integer = iCurCel


        Dim sIds As String = System.String.Empty
        If dtgProducts.RowCount > 0 Then

            Dim i As Integer = 0
            For i = 0 To dtgProducts.RowCount - 1
                If dtgProducts.Item(0, i).Value IsNot Nothing Then
                    sIds += dtgProducts.Item(0, i).Value & ","
                End If
            Next

        End If
        If sIds <> System.String.Empty Then
            sIds = sIds.Substring(0, sIds.Length - 1).Trim
            cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets " & _
                    " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode " & _
                    " Where Packets.SystemId not in(" & sIds & ")"
        Else
            cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets " & _
                        " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode "
        End If
        Dim f As frmSearch
        f = New frmSearch(cmdText)
        f.Text = "Product and Packet Size"
        f.ShowDialog(Me)
        Dim iSelectID As Integer = frmSearch.iID


        cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets" & _
                                        " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode WHERE SystemId=" & iSelectID
        Dim dsPackets As DataSet
        dsPackets = ExecuteQuery(cmdText, Execute.DataSet)
        If dsPackets.Tables(0).Rows.Count > 0 Then
            dtgProducts.Item(0, iRowIndex).Value = dsPackets.Tables(0).Rows(0).Item("SystemId")
            dtgProducts.Item(1, iRowIndex).Value = dsPackets.Tables(0).Rows(0).Item("ProductName")
            dtgProducts.Item(2, iRowIndex).Value = dsPackets.Tables(0).Rows(0).Item("PacketSize")
        End If




        'Dim cmdText As String = System.String.Empty
        'Dim iRowIndex As Integer = iCurRow
        'Dim iCelIndex As Integer = iCurCel

        'Dim bDuplicateRow As Boolean = False


        'Dim f As frmSearch
        'If iCurCel = 1 Then
        '    cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets " & _
        '                                " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode "
        'ElseIf iCurCel = 2 Then
        '    If dtgProducts.Item(1, iCurRow).Value = "" Then
        '        MessageBox.Show("First Select product...")
        '        Exit Sub
        '    End If
        '    cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets " & _
        '                                " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode where Products.ProductName='" & dtgProducts.Item(1, iCurRow).Value & "'"
        'End If
        'f = New frmSearch(cmdText)
        'f.ShowDialog(Me)
        'Dim iSelectID As Integer = frmSearch.iID
        'cmdText = "SELECT  Packets.SystemId,Packets.PacketSize ,Products.ProductName FROM Packets" & _
        '                            " INNER JOIN  Products on Packets.ProductCode=Products.ProductCode WHERE SystemId=" & iSelectID
        'Dim dsPackets As DataSet
        'dsPackets = ExecuteQuery(cmdText, Execute.DataSet)
        'If dsPackets.Tables(0).Rows.Count > 0 Then
        '    dtgProducts.Item(0, iCurRow).Value = dsPackets.Tables(0).Rows(0).Item("SystemId")
        '    dtgProducts.Item(1, iCurRow).Value = dsPackets.Tables(0).Rows(0).Item("ProductName")
        '    dtgProducts.Item(2, iCurRow).Value = dsPackets.Tables(0).Rows(0).Item("PacketSize")
        '    iCurRow = 0
        '    iCurCel = 0
        '    btnSearch.Enabled = False
        'End If
    End Sub

    Private Sub cmbRegions_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbRegions.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtRegCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegCode.Leave
        lblSelectedRegion.Text = "Region    " & txtRegCode.Text
    End Sub

    Private Sub dtgProducts_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProducts.RowEnter
        Try

            If bDetaialAdd = False Then
                dtgProducts.Rows(e.RowIndex).Selected = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgProducts_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProducts.CellClick
        Try

            If bDetaialAdd = False Then
                dtgProducts.Rows(e.RowIndex).Selected = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgProducts_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProducts.CellDoubleClick
        Try

            If bDetaialAdd = False Then
                dtgProducts.Rows(e.RowIndex).Selected = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgProducts_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgProducts.UserDeletingRow
        e.Cancel = True
    End Sub
End Class