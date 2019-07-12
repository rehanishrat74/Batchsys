Public Class frmSearch
    Private nonNumberEntered As Boolean = False

    Public Shared iID As Integer
    Public sCmdText As String
    Public dtSearch As DataTable
    'Public Shared Property getID()
    '    Get
    '        Return iID
    '    End Get
    '    Set(ByVal value)
    '        iID = value
    '    End Set
    'End Property

    Public Sub New(ByVal cmdText As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        sCmdText = cmdText
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If dtgSearch.SelectedRows.Count > 0 Then
            iID = dtgSearch.SelectedRows(0).Cells(0).Value
            Me.Close()
        Else
            MessageBox.Show("Please select row")
        End If
        'iID = 10
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        iID = 0
        Me.Close()
    End Sub

    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dsSearch As DataSet
        Try

            dsSearch = Common.ExecuteQuery(sCmdText, Execute.DataSet)
            dtSearch = dsSearch.Tables(0)
            dtgSearch.Columns.Clear()
            dtgSearch.DataSource = dtSearch
            'dtgSearch.DataBindings
            dtgSearch.Refresh()
            dtgSearch.Columns(0).Visible = False
            dtgSearch.Rows(0).Selected = True
            Dim dcSearch As DataColumn
            For Each dcSearch In dtSearch.Columns
                cmbFields.Items.Add(dcSearch.ColumnName)
            Next
            'cmbFields.Columns(dcId.ColumnName).Visible = False

            If cmbFields.Items.Count > 0 Then
                cmbFields.Items.RemoveAt(0)
                cmbFields.SelectedIndex = 0
                cmbOptions.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show(" Error  " & ex.Message)
        End Try
    End Sub


    Private Sub txtCondition_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCondition.TextChanged
        Dim strExpr As String
        'Dim strSort As String

        Dim foundRows As DataRow()

        If txtCondition.Text.Length > 0 AndAlso txtCondition.Text <> "" Then
            If cmbOptions.Text = "Like" Then
                strExpr = cmbFields.Text & " " & cmbOptions.Text & " '" & txtCondition.Text & "%'"
            Else
                strExpr = cmbFields.Text & " " & cmbOptions.Text & " " & txtCondition.Text
            End If
            'strExpr = cmbFields.Text & " " & cmbOptions.Text & " " & txtCondition.Text
            'strSort = "OrderDate DESC"
            foundRows = dtSearch.Select(strExpr)
            'Dim dv As New DataView(dt, "FirstName = 'Joe'", "FirstName", DataViewRowState.CurrentRows)
            Dim dv As New DataView(dtSearch, strExpr, cmbFields.Text, DataViewRowState.CurrentRows)
            'MessageBox.Show(foundRows.Length)
            'Dim dtTable As New DataTable
            '' dtTable = dtSearch
            'dtTable.Rows.Clear()
            'Dim dr As DataRow
            'For Each dr In foundRows
            '    dtTable.Rows.Add(dr)
            'Next
            dtgSearch.DataSource = Nothing
            dtgSearch.DataSource = dv
            dtgSearch.Columns(0).Visible = False
            dtgSearch.Refresh()

        Else
            dtgSearch.DataSource = Nothing
            dtgSearch.DataSource = dtSearch
            dtgSearch.Columns(0).Visible = False
            dtgSearch.Refresh()
        End If

    End Sub

    Private Sub cmbFields_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFields.SelectedIndexChanged
        txtCondition.Text = System.String.Empty
        Dim dc As New DataColumn
        dc = dtSearch.Columns(cmbFields.Text)
        Select Case dc.DataType.FullName
            Case "System.String"
                cmbOptions.Items.Clear()
                cmbOptions.Items.Add("Like")
                cmbOptions.SelectedIndex = 0
                'cmbOptions
                'MessageBox.Show("String")
            Case "System.Int32", "System.Int64"
                cmbOptions.Items.Clear()
                cmbOptions.Items.Add("=")
                cmbOptions.Items.Add(">")
                cmbOptions.Items.Add("<")
                cmbOptions.Items.Add("<>")
                cmbOptions.SelectedIndex = 0
                'MessageBox.Show("int")
        End Select

    End Sub

    Private Sub dtgSearch_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSearch.RowEnter
        Try

            dtgSearch.Rows(e.RowIndex).Selected = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCondition_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCondition.KeyPress
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        End If

    End Sub

    Private Sub txtCondition_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCondition.KeyDown
        nonNumberEntered = False
        Dim dc As New DataColumn
        dc = dtSearch.Columns(cmbFields.Text)
        Select Case dc.DataType.FullName
            Case "System.String"
            Case "System.Int32", "System.Int64"
                If e.KeyCode < 48 OrElse e.KeyCode > 57 Then
                    If e.KeyCode < 95 OrElse e.KeyCode > 104 Then
                        If e.KeyCode <> Keys.Back Then
                            nonNumberEntered = True
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub cmbOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOptions.SelectedIndexChanged

    End Sub

    Private Sub dtgSearch_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSearch.CellEnter
        Try

            dtgSearch.Rows(e.RowIndex).Selected = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgSearch_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSearch.CellClick
        Try

            dtgSearch.Rows(e.RowIndex).Selected = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgSearch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSearch.CellDoubleClick
        Try

            dtgSearch.Rows(e.RowIndex).Selected = True

        Catch ex As Exception

        End Try
    End Sub
End Class