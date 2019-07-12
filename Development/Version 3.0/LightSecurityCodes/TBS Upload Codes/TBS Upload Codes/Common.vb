Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net

Module Common


    'Private conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BatchSystem.mdb")
    'Private conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BatchSystem.mdb;User ID=Admin;Password=atchsystem")
    Private cmd As OleDbCommand
    Private da As OleDbDataAdapter
    'Public Function ExecuteQuery(ByVal cmdText As String, ByVal type As Execute) As Object
    '    Dim ds As New DataSet
    '    Dim returnObject As Object = 0
    '    With conn
    '        If Not .State = ConnectionState.Closed Then
    '            .Close()
    '        End If
    '        .Open()
    '    End With
    '    cmd = New OleDbCommand()
    '    With cmd
    '        .Connection = conn
    '        .CommandText = cmdText
    '        .CommandType = CommandType.Text
    '        Select Case type
    '            Case Execute.Scalar
    '                returnObject = .ExecuteScalar()
    '            Case Execute.None
    '                returnObject = .ExecuteNonQuery
    '            Case Execute.Reader
    '                returnObject = .ExecuteReader()
    '            Case Execute.DataSet
    '                da = New OleDbDataAdapter
    '                With da
    '                    .SelectCommand = cmd
    '                    .Fill(ds)
    '                End With
    '                returnObject = ds
    '        End Select
    '    End With
    '    conn.Close()
    '    Return returnObject
    'End Function

    Public Function UpLoadSecutrityCodes(ByVal str As String) As String
        Dim sResult As String = System.String.Empty
        If Not str.Equals(String.Empty) Then
            Dim upload As New com.infinishops.tbs.Service1

            Try
                sResult = upload.UploadCodes(str).ToLower
            Catch ex As Exception
                Throw ex
            End Try
        Else
            MessageBox.Show("Security Codes not found...", "Light Security Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return sResult
    End Function

    Enum Execute
        DataSet
        Reader
        None
        Scalar
    End Enum

    Enum BatchType
        Uploaded
        NotUploaded
    End Enum
End Module
Public Class UploadSerials
    Inherits System.Net.WebClient
    Public Sub New()
        MyBase.New()
    End Sub
    Protected Overrides Function GetWebRequest(ByVal uri As Uri) As WebRequest
        Dim request As HttpWebRequest = CType(MyBase.GetWebRequest(uri), HttpWebRequest)
        request.ProtocolVersion = HttpVersion.Version10
        Return request
    End Function
End Class
