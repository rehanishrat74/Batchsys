Public Class SearchPage2
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
    Protected WithEvents lblProductCode As System.Web.UI.WebControls.Label
    Protected WithEvents txtProductCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPacketSize As System.Web.UI.WebControls.Label
    Protected WithEvents txtPacketSize As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblRegion As System.Web.UI.WebControls.Label
    Protected WithEvents txtRegion As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        

        Dim objCommon As New Common
        'ds = DataAccess.ExecuteDataSet("TBS_spVerifySecuriytCode3", Trim(txtSearch.Text)) ''' "select Data from TBS_DATA where Data like '" & Trim(txtSearch.Text) & "'")
        objCommon = DataAccess.ExecuteObject("TBS_spVerifySecuriytCodeByAdmin", Trim(txtSearch.Text)) ''' "select Data from TBS_DATA where Data like '" & Trim(txtSearch.Text) & "'")

        If objCommon.GetOutPutCode = 2000 Then
            txtVerified.Text = "Not Found "
            txtProductCode.Text = System.String.Empty
            txtPacketSize.Text = System.String.Empty
            txtRegion.Text = System.String.Empty
        ElseIf objCommon.GetOutPutCode = 2002 Then
            txtVerified.Text = "Number Found"
            Dim ds As New DataSet
            ds = objCommon.GetDataSet
            txtProductCode.Text = ds.Tables(0).Rows(0).Item("ProductID")
            txtPacketSize.Text = ds.Tables(0).Rows(0).Item("PacketSize")
            txtRegion.Text = ds.Tables(0).Rows(0).Item("Region")
        Else
        End If
    End Sub
End Class
