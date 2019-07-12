Imports System.IO
Public Class frmCodesShow
    Public dtCodes As DataTable
    Public Shared iID As String
    Public Shared iRange As Integer
    Public sProudctName As String
    Public Sub New(ByVal value As DataTable, ByVal strProductName As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dtCodes = value
        sProudctName = strProductName
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        iID = ""
        iRange = 0
        Me.Close()
    End Sub

    Private Sub btnPrinted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrinted.Click
        If optRange.Checked = True Then
            If txtRange.Text.Length > 0 AndAlso IsNumeric(txtRange.Text) AndAlso txtRange.Text > 0 Then
                If txtRange.Text > dtCodes.Rows.Count Then
                    MessageBox.Show("The enter Range is greter then Total UnPrinted Codes....")
                    Exit Sub
                End If
                iRange = txtRange.Text
                iID = 0
                Me.Close()
            Else
                MessageBox.Show("Please enter the correct Range....")
            End If
        Else
            If dtgCodes.SelectedRows.Count > 0 Then
                iID = dtgCodes.SelectedRows(0).Cells(0).Value
                iRange = 0
                Me.Close()
            ElseIf txtRange.Text.Length > 0 AndAlso IsNumeric(txtRange.Text) AndAlso txtRange.Text > 0 Then
                iRange = txtRange.Text
                iID = 0
                Me.Close()
            Else
                MessageBox.Show("Please select row ....")
            End If
        End If
    End Sub

    Private Sub frmCodesShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            lblProduct.Text = sProudctName
            dtgCodes.Columns.Clear()
            dtgCodes.DataSource = dtCodes
            'dtgSearch.DataBindings
            dtgCodes.Refresh()
            dtgCodes.Columns(0).Width = 275
            'dtgCodes.Columns(0).Visible = False
            ' dtgCodes.Rows(0).Selected = True
            optRange.Checked = False
            optCode.Checked = True
            dtgCodes.Enabled = True
            'Catch ex As Exception
            '    MessageBox.Show(" Error  " & ex.Message)
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
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub dtgCodes_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCodes.CellEnter
        Try

            dtgCodes.Rows(e.RowIndex).Selected = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgCodes_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCodes.RowEnter
        Try

            dtgCodes.Rows(e.RowIndex).Selected = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub optRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRange.CheckedChanged
        txtRange.Enabled = True
        dtgCodes.Enabled = False
        If dtgCodes.SelectedRows.Count > 0 Then
            Dim cnt As Integer = dtgCodes.SelectedRows.Count
            Dim iRow As Integer
            For iRow = 0 To cnt - 1
                Me.dtgCodes.SelectedRows(0).Selected = False
            Next
        End If
    End Sub

    Private Sub optCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCode.CheckedChanged
        txtRange.Enabled = False
        txtRange.Text = ""
        dtgCodes.Enabled = True
        dtgCodes.Rows(0).Selected = True
    End Sub

    Private Sub frmCodesShow_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub dtgCodes_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgCodes.UserDeletingRow
        e.Cancel = True
    End Sub

    Private Sub txtRange_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRange.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = Keys.Back Then
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub dtgCodes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCodes.CellClick
        Try
            dtgCodes.Rows(e.RowIndex).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgCodes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCodes.CellDoubleClick
        Try
            dtgCodes.Rows(e.RowIndex).Selected = True
        Catch ex As Exception

        End Try
    End Sub
End Class