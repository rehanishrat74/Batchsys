Public Class Demo
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
    Protected WithEvents ColA As System.Web.UI.WebControls.Label
    Protected WithEvents ColB As System.Web.UI.WebControls.Label
    Protected WithEvents ColC As System.Web.UI.WebControls.Label
    Protected WithEvents ColD As System.Web.UI.WebControls.Label
    Protected WithEvents ColE As System.Web.UI.WebControls.Label
    Protected WithEvents ColF As System.Web.UI.WebControls.Label

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
        objCommon = DataAccess.ExecuteObject("TBS_spVerifyCode2", Trim(txtSearch.Text)) ''' "select Data from TBS_DATA where Data like '" & Trim(txtSearch.Text) & "'")
        ColA.Text = System.String.Empty
        ColB.Text = System.String.Empty
        ColC.Text = System.String.Empty
        ColD.Text = System.String.Empty
        ColE.Text = System.String.Empty
        ColF.Text = System.String.Empty
        txtVerified.Text = System.String.Empty
        If objCommon.GetOutPutCode = 2000 Then
            txtVerified.Text = "Not Found "
            ColA.Text = "Not Found "
            'ColB.Text = System.String.Empty
            'ColC.Text = System.String.Empty
            'ColD.Text = System.String.Empty
            'ColE.Text = System.String.Empty
            'ColF.Text = System.String.Empty
        ElseIf objCommon.GetOutPutCode = 2002 Then
            txtVerified.Text = "Number Found"
            Dim ds As New DataSet
            ds = objCommon.GetDataSet
            ColA.Text = ds.Tables(0).Rows(0).Item("ColA")
            ColB.Text = ds.Tables(0).Rows(0).Item("ColB")
            ColC.Text = ds.Tables(0).Rows(0).Item("ColC")
            ColD.Text = ds.Tables(0).Rows(0).Item("ColD")
            ColE.Text = ds.Tables(0).Rows(0).Item("ColE")
            ColF.Text = ds.Tables(0).Rows(0).Item("ColF")
        ElseIf objCommon.GetOutPutCode = 2001 Then
            btnSearch.Enabled = False
            'LiteralMsg.Visible = True
            txtVerified.Text = System.String.Empty
            'LiteralMsg.Text = "<font color = 'Blue'><b>" & " Diese Nummer ist gesperrt. Bitte wenden Sie sich an die Daimler AG in Stuttgart. Vielen Dank" & "</font>"
            ColA.Text = "Diese Nummer ist gesperrt. Bitte wenden Sie sich an die Daimler AG in Stuttgart. Vielen Dank"

        End If
    End Sub
End Class
