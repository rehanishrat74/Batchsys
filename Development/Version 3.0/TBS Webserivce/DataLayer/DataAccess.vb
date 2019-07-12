Imports System.Data
Imports System.Data.SqlClient

Public Class DataAccess

    Public Shared _conn As String = System.Configuration.ConfigurationSettings.AppSettings("connectionString")

    Public Shared Sub ExecuteNonQuery(ByVal QueryText As String, ByVal param1 As String)
        Dim Conn As New SqlConnection(_conn)
        Dim cmd As New SqlCommand
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = QueryText
        cmd.Parameters.Add("@Data", param1)
        Conn.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ex.ToString()
        Finally
            Conn.Close()
        End Try
    End Sub

    Public Shared Function ExecuteQuery(ByVal QueryText As String, ByVal param1 As String) As Integer
        Dim Conn As New SqlConnection(_conn)
        Dim cmd As New SqlCommand
        Dim iResult As Integer
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = QueryText
        cmd.Parameters.Add("@Doc", param1)
        Dim paramOutPut As New SqlParameter
        paramOutPut.ParameterName = "@outParam"
        paramOutPut.SqlDbType = SqlDbType.Int
        paramOutPut.Direction = ParameterDirection.Output

        cmd.Parameters.Add(paramOutPut)
        Conn.Open()
        Try
            cmd.ExecuteNonQuery()
            iResult = cmd.Parameters("@outParam").Value
        Catch exSql As System.Data.SqlClient.SqlException
            If exSql.Number = 2627 Then
                iResult = 2627
            End If
            exSql.ToString()
        Catch ex As Exception
            ex.ToString()
            iResult = 0
        Finally
            Conn.Close()
        End Try
        Return iResult
    End Function
    Public Shared Function ExecuteReader(ByVal QueryString As String, Optional ByVal DrpValue As Integer = -1) As SqlDataReader

        Dim Conn As New SqlConnection(_conn)
        Dim cmd As New SqlCommand
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = QueryString
        If DrpValue > -1 Then
            cmd.Parameters.Add("@ID", DrpValue)
        End If

        Dim dr As SqlDataReader

        Conn.Open()
        Try
            dr = cmd.ExecuteReader()
            Return (dr)
        Catch ex As Exception
            ex.ToString()
        Finally
            Conn = Nothing

        End Try


    End Function

    Public Shared Function ExecuteDataSet(ByVal QueryString As String, ByVal DrpValue As String) As DataSet
        Dim Conn As New SqlConnection(_conn)
        Dim cmd As New SqlCommand
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = QueryString
        cmd.Parameters.Add("@Data", DrpValue)
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


    Public Shared Function ExecuteDataSetQuery(ByVal QueryString As String) As DataSet
        Dim Conn As New SqlConnection("Data Source=Server6; Initial Catalog = M2; User Id=sqluser; Password=D8kjhy;")
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
            'Conn.Close()

        End Try


    End Function

    Public Shared Function ExecuteObject(ByVal QueryText As String, ByVal param1 As String) As Common
        Dim objCommon As New Common
        Dim Conn As New SqlConnection(_conn)
        Dim cmd As New SqlCommand
        Dim iResult As Integer
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = QueryText
        cmd.Parameters.Add("@Code", param1)
        Dim paramOutPut As New SqlParameter
        paramOutPut.ParameterName = "@outParam"
        paramOutPut.SqlDbType = SqlDbType.Int
        paramOutPut.Direction = ParameterDirection.Output

        cmd.Parameters.Add(paramOutPut)
        Conn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter(cmd)
        Try
            'cmd.ExecuteNonQuery()
            da.Fill(ds)
            iResult = cmd.Parameters("@outParam").Value
            objCommon.dsDataSet = ds
            objCommon.OutPurCode = iResult


        Catch ex As Exception
            ex.ToString()
            iResult = 0
            objCommon.dsDataSet = Nothing
            objCommon.OutPurCode = 0
        Finally
            Conn.Close()
        End Try
        Return objCommon
    End Function
End Class
