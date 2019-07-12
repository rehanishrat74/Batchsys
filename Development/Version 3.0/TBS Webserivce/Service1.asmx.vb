Imports System.Web.Services
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

<System.Web.Services.WebService(Namespace := "http://tempuri.org/tbs.infinishops.com/Service1")> _
Public Class Service1
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page    
    ' and press F5.
    '
    ''''<WebMethod()> _
    ''''Public Function HelloWorld() As String
    ''''    Return "Hello World"
    ''''End Function

    <WebMethod()> _
    Public Function UploadDataFromApp(ByVal FileString As String) As String
        
        Try
            ''''Dim SqlPara(2) As SqlParameter

            Dim strValues() As String = FileString.Split(",")
            For i As Integer = 0 To strValues.Length - 1
                DataAccess.ExecuteNonQuery("SetData", strValues(i)) '' "Insert into TBS_Data values('" & strValues(i) & "')")
                '''DataAccess.ExecuteNonQuery("Insert into TBS_Data values('" & strValues(i) & "')", "0)
            Next
            Return "Success"
        Catch ex As Exception
            Return "Failed"
            Throw ex
        End Try


    End Function
    <WebMethod()> _
    Public Function UploadCodes(ByVal FileString As String) As String
        Dim iResult As Integer = 0
        Try
           
            iResult = DataAccess.ExecuteQuery("TBS_InsertCodes", FileString)
            If iResult = 2008 Then
                Return "Success"
            ElseIf iResult = 2627 Then
                Return "Duplicate Record"
            Else
                Return "Failed"
            End If
        Catch ex As Exception
            Return "Failed"
            Throw ex
        End Try
    End Function

    <WebMethod()> _
    Public Function UploadSecurityCodes(ByVal FileString As String) As String
        Dim iResult As Integer = 0
        Try

            'iResult = DataAccess.ExecuteQuery("TBS_InsertSecurrityCodes", FileString)
            iResult = DataAccess.ExecuteQuery("TBS_InsertSecurityCodes", FileString)
            If iResult = 2008 Then
                Return "Success"
            ElseIf iResult = 2627 Then
                Return "Duplicate Record"
            Else
                Return "Failed"
            End If
        Catch ex As Exception
            Return "Failed"
            Throw ex
        End Try
    End Function
End Class
