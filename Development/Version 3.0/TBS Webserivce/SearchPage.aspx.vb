Imports System.Data.SqlClient

Public Class SearchPage
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents LiteralMsg As System.Web.UI.WebControls.Literal
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSearch As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtVerified As System.Web.UI.WebControls.TextBox
    Protected WithEvents PnlSearch As System.Web.UI.WebControls.Panel

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public counter As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            btnSearch.Enabled = True


        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'Old code 
        '''''''''If txtSearch.Text <> "" Then
        ''''''''Dim ds As New DataSet
        ''''''''ds = DataAccess.ExecuteDataSet("GetData", Trim(txtSearch.Text)) ''' "select Data from TBS_DATA where Data like '" & Trim(txtSearch.Text) & "'")
        ''''''''If ds.Tables.Count <= 0 Then
        ''''''''    txtVerified.Text = "Not Found "
        ''''''''ElseIf ds.Tables(0).Rows.Count <= 0 Then
        ''''''''    txtVerified.Text = "Not Found "

        ''''''''Else
        ''''''''    With ds.Tables(0)
        ''''''''        If .Rows(0)(0) = 0 Then
        ''''''''            btnSearch.Enabled = False
        ''''''''            LiteralMsg.Visible = True
        ''''''''            LiteralMsg.Text = "<font color = 'Blue'><b>" & " We regret to inform you that you have reached maximum search limit" & "</font>"
        ''''''''        ElseIf .Rows(0)(0) = -1 Then
        ''''''''            txtVerified.Text = "Not Found "
        ''''''''        ElseIf .Rows(0)(0) <> -1 Then
        ''''''''            txtVerified.Text = "Number Found"
        ''''''''        End If
        ''''''''    End With
        ''''''''End If
        '''''''''Else

        '''''''''End If


        ''' New coding 18/01/2008

        Dim ds As New DataSet
        Dim objCommon As New Common
        'ds = DataAccess.ExecuteDataSet("TBS_spVerifySecuriytCode3", Trim(txtSearch.Text)) ''' "select Data from TBS_DATA where Data like '" & Trim(txtSearch.Text) & "'")
        objCommon = DataAccess.ExecuteObject("TBS_spVerifySecuriytCode", Trim(txtSearch.Text)) ''' "select Data from TBS_DATA where Data like '" & Trim(txtSearch.Text) & "'")

        If objCommon.GetOutPutCode = 2000 Then
            txtVerified.Text = "Not Found "
        ElseIf objCommon.GetOutPutCode = 2001 Then
            btnSearch.Enabled = False
            LiteralMsg.Visible = True
            txtVerified.Text = System.String.Empty
            LiteralMsg.Text = "<font color = 'Blue'><b>" & " Code has already been verified" & "</font>"
        ElseIf objCommon.GetOutPutCode = 2002 Then
            txtVerified.Text = "Number Found"
        Else
        End If
    End Sub

    Public Shared Function ExecuteDataSet(ByVal QueryString As String, Optional ByVal DrpValue As Integer = -1) As DataSet
        Dim _conn As String = System.Configuration.ConfigurationSettings.AppSettings("connectionString")
        Dim Conn As New SqlConnection(_conn)
        Dim cmd As New SqlCommand
        cmd.Connection = Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = QueryString
        Conn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter(cmd)
        Try
            da.Fill(ds)
            Return (ds)
        Catch ex As Exception
            ex.ToString()
        Finally
            Conn.Close()

        End Try


    End Function


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
