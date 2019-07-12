Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices

<ComVisibleAttribute(True)> _
Public Class Access
    Private random As System.Random
    Public batchSize As Int32 = 0
    Public counter As Int32 = 0
    Public currentBatchNo As Int32
    Public iDuplicate As Integer = 0
    Private conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BatchSystem.mdb")
    'Private conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BatchSystem.mdb;User ID=Admin;Password=atchsystem")
    Private cmd As OleDbCommand
    Private da As OleDbDataAdapter
    Structure PrintPageSize
        Shared Height = 0, Width = 0, LeftMargin = 0, RightMargin = 0, Header = 0, Footer As Int16 = 0
        Dim IsPrint As Boolean
        Shared Report As String = String.Empty
        Shared IsUploaded As Boolean
    End Structure
    Private Function GetFirstSerialNo() As Int32
        Dim seed As Int32 = Convert.ToInt32(Date.Now.Second + Date.Now.Millisecond + Date.Now.Second)
        random = New System.Random(seed)
        Return random.Next(100, 999)
        'Return random.Next(100, 999)
    End Function
    Private Function GetSecondSerialNo() As Int32
        Dim seed As Int32 = Convert.ToInt32(Date.Now.Second + Date.Now.Millisecond)
        random = New System.Random(seed)
        'Return random.Next(10000, 99999)
        Return random.Next(1000, 9999)
    End Function
    Public Function ExecuteQuery(ByVal cmdText As String, ByVal type As Execute, ByVal conConnection As OleDbConnection) As Object
        Dim ds As New DataSet
        Dim returnObject As Object = 0
        'With conConnection
        '    If Not .State = conConnectionectionState.Closed Then
        '        .Close()
        '    End If
        '    .Open()
        'End With
        cmd = New OleDbCommand()
        With cmd
            .Connection = conConnection
            .CommandText = cmdText
            .CommandType = CommandType.Text
            Select Case type
                Case Execute.Scalar
                    returnObject = .ExecuteScalar()
                Case Execute.None
                    returnObject = .ExecuteNonQuery
                Case Execute.Reader
                    returnObject = .ExecuteReader()
                Case Execute.DataSet
                    da = New OleDbDataAdapter
                    With da
                        .SelectCommand = cmd
                        .Fill(ds)
                    End With
                    returnObject = ds
            End Select
        End With
        'conn.Close()
        Return returnObject
    End Function
    Public Function ExecuteQuery(ByVal cmdText As String, ByVal type As Execute) As Object
        Dim ds As New DataSet
        Dim returnObject As Object = 0
        With conn
            If Not .State = ConnectionState.Closed Then
                .Close()
            End If
            .Open()
        End With
        cmd = New OleDbCommand()
        With cmd
            .Connection = conn
            .CommandText = cmdText
            .CommandType = CommandType.Text
            Select Case type
                Case Execute.Scalar
                    returnObject = .ExecuteScalar()
                Case Execute.None
                    returnObject = .ExecuteNonQuery
                Case Execute.Reader
                    returnObject = .ExecuteReader()
                Case Execute.DataSet
                    da = New OleDbDataAdapter
                    With da
                        .SelectCommand = cmd
                        .Fill(ds)
                    End With
                    returnObject = ds
            End Select
        End With
        conn.Close()
        Return returnObject
    End Function
    Private Function GetSerials(ByVal ProductCode As String, ByVal PacketSize As Integer, ByVal Region As String, ByVal IsUpload As String) As DataTable
        'Dim cmdText As String = "Select Serials.ID, Serials.Serials FROM Serials Where IsUploaded <> 'Y';"
        Dim cmdText As String = "Select Serials.ID,Serials.PacketSize, Serials.Serials,Serials.ProductCode,Serials.Region,Serials.InsDate FROM Serials Where IsUploaded ='" & IsUpload & "' " & _
                                " And ProductCode='" & ProductCode & "' And PacketSize=" & PacketSize & " And Region='" & Region & "'"
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Private Function GetSerials() As DataTable
        'Dim cmdText As String = "Select Serials.ID, Serials.Serials FROM Serials Where IsUploaded <> 'Y';"
        Dim cmdText As String = "Select Serials.ID,Serials.PacketSize, Serials.Serials,Serials.ProductCode,Serials.Region FROM Serials Where IsUploaded <> 'Y';"
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Private Function GetSerials(ByVal batchNo As Int32) As DataTable
        ' Dim cmdText As String = "SELECT Serials From Serials WHERE BatchNo=" & batchNo
        Dim cmdText As String = "Select  Serials.Serials FROM Serials Where batchNo=" & batchNo & " and IsUploaded <> 'Y';"
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Private Function GetSerialsReport(ByVal batchNo As Int32) As DataTable
        Dim cmdText As String = "Select  Serials.Serials FROM Serials Where batchNo=" & batchNo & ";"
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetTimeSerialNo() As String
        Dim TimeBuilder As New StringBuilder
        Dim h As Integer = 0
        Dim s As Integer = 0
        Dim m As Integer = 0

        h = Now.Hour
        s = Now.Second
        m = Now.Minute


        If m >= 0 And m <= 9 Then
            TimeBuilder.Append(m)
            TimeBuilder.Append(s)
        ElseIf m >= 10 And m <= 35 Then
            TimeBuilder.Append(Convert.ToChar(m + 87))
            TimeBuilder.Append(s)
        Else
            TimeBuilder.Append(s)
            TimeBuilder.Append(Convert.ToChar(126 - m))
        End If

        If h >= 0 And h <= 9 Then
            TimeBuilder.Append(h)
        Else
            TimeBuilder.Append(Convert.ToChar(126 - h))
        End If
        If TimeBuilder.ToString.Length < 4 Then
            TimeBuilder.Append(Convert.ToChar(random.Next(97, 122)))
        End If
        Return TimeBuilder.ToString()
    End Function
    Public Function Sum(ByRef No As String) As Integer
        Dim js As String = No
        Dim l As Integer = 0
        l = js.Length
        Dim inew As Integer = 0
        Dim k As Integer = 0
        For k = 0 To l - 1
            inew = inew + js.Substring(k, 1)
        Next
        Return inew
    End Function
    Public Function GetSeedMinMax(ByRef SelectSeed As Int16) As Hashtable

        Dim hSeed As New Hashtable

        Select Case SelectSeed

            Case 1

                hSeed.Add(0, 1) : hSeed.Add(1, 9)

            Case 2

                hSeed.Add(0, 10) : hSeed.Add(1, 99)

            Case 3

                hSeed.Add(0, 100) : hSeed.Add(1, 999)

            Case 4

                hSeed.Add(0, 1000) : hSeed.Add(1, 9999)

            Case 5

                hSeed.Add(0, 10000) : hSeed.Add(1, 99999)

            Case 6

                hSeed.Add(0, 100000) : hSeed.Add(1, 999999)

            Case 7

                hSeed.Add(0, 1000000) : hSeed.Add(1, 9999999)

            Case 8

                hSeed.Add(0, 10000000) : hSeed.Add(1, 99999999)

            Case 9

                hSeed.Add(0, 100000000) : hSeed.Add(1, 999999999)

        End Select

        Return hSeed

    End Function
    Public Function TestDs() As DataTable
        'Dim oAdapter As SqlClient.SqlDataAdapter

        Dim ds As DataSet
        Dim cmdText As String = "select * from Serials"
        ds = ExecuteQuery(cmdText, Execute.DataSet)
        Return ds.Tables(0)
    End Function
    Public Function GetSerialNoxxx(ByRef batchNo As Int32) As String
        Dim bContinue As Boolean = True
        Dim builder As StringBuilder
        Dim sno As String = ""
        Dim objRegex As New Regex("^[a-zA-Z0-9]{10}$")
        Dim random As System.Random
        Dim rNumber As Int32
        Dim serial As String = String.Empty
        Dim duplicate As Integer = 0

        '        random = New System.Random(Date.Now.Month + Date.Now.Day + Date.Now.Hour + Date.Now.Minute + Date.Now.Second + Date.Now.Millisecond)

        Do While bContinue = True
            serial = String.Empty
            builder = New StringBuilder
            Dim alphLength As Int64 = random.Next(1, 9)
            For index As Int32 = 1 To alphLength
                'random = New System.Random(index + Date.Now.Month + Date.Now.Day + Date.Now.Hour + Date.Now.Minute + Date.Now.Second + Date.Now.Millisecond)
                rNumber = random.Next(0, 49) + random.Next(0, 50)
                If rNumber < 65 Then
                    rNumber = random.Next(65, 90)
                ElseIf rNumber > 90 Then
                    rNumber = random.Next(97, 122)
                End If
                serial += Microsoft.VisualBasic.ChrW(rNumber)
            Next
            'random = New System.Random(Date.Now.Month + Date.Now.Day + Date.Now.Hour + Date.Now.Minute + Date.Now.Second + Date.Now.Millisecond)
            'MessageBox.Show(serial + Convert.ToString(random.Next(Me.GetSeedMinMax(10 - seed).Item(0), Me.GetSeedMinMax(10 - seed).Item(1))))
            sno = serial + Convert.ToString(random.Next(GetSeedMinMax(10 - alphLength).Item(0), GetSeedMinMax(10 - alphLength).Item(1)))
            duplicate = 0

            Dim cmdText As String = "SELECT 1 as dupID FROM Serials WHERE Serials ='" & sno & "';"
            duplicate = ExecuteQuery(cmdText, Execute.Scalar)
            If duplicate <> 1 Then
                If objRegex.IsMatch(sno) Then
                    bContinue = False
                End If
            Else
                bContinue = True
            End If
        Loop
        Return sno
    End Function
    Public Function GetSerialNo(ByRef random As System.Random) As String
        Dim bContinue As Boolean = True
        Dim builder As StringBuilder
        Dim sno As String = ""
        Dim objRegex As New Regex("^[a-zA-Z0-9]{10}$")
        Dim rNumber As Int32
        Dim serial As String = String.Empty
        Dim duplicate As Integer = 0

        Do While bContinue = True
            serial = String.Empty
            builder = New StringBuilder
            Dim alphLength As Int64 = random.Next(1, 9)
            For index As Int32 = 1 To alphLength
                rNumber = random.Next(0, 49) + random.Next(0, 50)
                If rNumber < 65 Then
                    rNumber = random.Next(65, 90)
                ElseIf rNumber > 90 Then
                    rNumber = random.Next(97, 122)
                End If
                serial += Microsoft.VisualBasic.ChrW(rNumber)
            Next
            sno = serial + Convert.ToString(random.Next(GetSeedMinMax(10 - alphLength).Item(0), GetSeedMinMax(10 - alphLength).Item(1)))
            duplicate = 0

            Dim cmdText As String = "SELECT 1 as dupID FROM Serials WHERE Serials ='" & sno & "';"
            duplicate = ExecuteQuery(cmdText, Execute.Scalar)
            If duplicate <> 1 Then
                If objRegex.IsMatch(sno) Then
                    bContinue = False
                End If
            Else
                bContinue = True
            End If
        Loop
        Return sno
    End Function
    Public Function GetSerialNo1(ByRef batchNo As Int32) As String
        '''' Without Data Base         '''Time=2 Minute Records=133 Duplicate=0


        Dim bContinue As Boolean = True
        Dim sBuilder As StringBuilder
        Dim sno As String = ""
        Dim iYear As Integer = 0
        Dim objRegex As New Regex("^[a-zA-Z0-9]{11}$")
        Dim duplicate As Integer = 0
        Do While bContinue = True
            sBuilder = New StringBuilder
            sBuilder.Append(Convert.ToChar(Now.Month + 108))
            sBuilder.Append(GetSecondSerialNo())
            If Now.Day >= 6 Then
                sBuilder.Append(Convert.ToChar(128 - Now.Day))
            Else
                sBuilder.Append(Now.Day)
            End If
            sBuilder.Append(GetTimeSerialNo())
            iYear = Convert.ToInt32((Now.Year.ToString).Substring(2, 2))
            sBuilder.Append(Convert.ToChar(64 + iYear))
            sno = sBuilder.ToString()
            If objRegex.IsMatch(sno) Then
                bContinue = False
            Else
                bContinue = True
            End If
        Loop
        Return sno
    End Function
    Public Function GetSerialNo2(ByRef batchNo As Int32) As String

        Dim bContinue As Boolean = True
        Dim iYear As Integer = 0
        Dim sBuilder As StringBuilder
        Dim sno As String = ""
        Dim objRegex As New Regex("^[a-zA-Z0-9]{11}$")
        Dim duplicate As Integer = 0
        Do While bContinue = True
            sBuilder = New StringBuilder
            sBuilder.Append(Convert.ToChar(Now.Month + 108))
            sBuilder.Append(GetSecondSerialNo())
            If Now.Day >= 6 Then
                sBuilder.Append(Convert.ToChar(128 - Now.Day))
            Else
                sBuilder.Append(Now.Day)
            End If
            sBuilder.Append(GetTimeSerialNo())
            iYear = Convert.ToInt32((Now.Year.ToString).Substring(2, 2))
            sBuilder.Append(Convert.ToChar(64 + iYear))
            sno = sBuilder.ToString()

            If objRegex.IsMatch(sno) Then
                duplicate = 0
                Dim cmdText As String = "SELECT 1 as dupID FROM Serials WHERE Serials ='" & sno & "';"
                duplicate = ExecuteQuery(cmdText, Execute.Scalar)
                If duplicate <> 1 Then
                    bContinue = False
                Else
                    bContinue = True
                End If
            Else
                bContinue = True
            End If
        Loop
        Return sno
    End Function
    Public Function GetSerialNoOld(ByRef batchNo As Int32) As String
        'Return GetFirstSerialNo() & GetSecondSerialNo() & batchNo
        Dim bContinue As Boolean = True
        Dim sBuilder As StringBuilder
        Dim sno As String = ""
        Dim iDay As Integer = 0
        Dim iYear As Integer = 0
        Dim objRegex As New Regex("^[a-zA-Z0-9]{10}$")

        Do While bContinue = True
            sBuilder = New StringBuilder
            sBuilder.Append(Convert.ToChar(Convert.ToInt32(Now.Month) + 108))
            sBuilder.Append(GetSecondSerialNo())
            'sBuilder.Append(GetFirstSerialNo())
            iDay = Convert.ToInt32(Now.Day)
            If iDay >= 6 Then
                sBuilder.Append(Convert.ToChar(128 - Convert.ToInt32(Now.Day)))
            Else
                sBuilder.Append(Now.Day)
            End If
            sBuilder.Append(GetTimeSerialNo())
            'sBuilder.Append(GetSecondSerialNo())
            iYear = Convert.ToInt32((Now.Year.ToString).Substring(2, 2))
            sBuilder.Append(Convert.ToChar(64 + iYear))

            sno = sBuilder.ToString()
            If objRegex.IsMatch(sno) Then
                bContinue = False
            End If
        Loop
        Return sno

    End Function
    Public Function GetRegions() As DataTable
        Dim cmdText As String = String.Empty

        cmdText = "SELECT * FROM Regions "

        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetRegions(ByVal ProductCode As String, ByVal PacketSize As Integer) As DataTable
        Dim cmdText As String = String.Empty

        'cmdText = "SELECT * FROM Regions "

        cmdText = "Select Regions.RegionCode,Regions.ID,Regions.Description from ProductPacketRegion,Packets,Regions " & _
         " where ProductPacketRegion.ProdcutPacketID = Packets.SystemId and ProductPacketRegion.RegionCode=Regions.ID " & _
        " and Packets.ProductCode='" & ProductCode & "'  and Packets.PacketSize=" & PacketSize
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetProducts() As DataTable
        Dim cmdText As String = String.Empty

        cmdText = "SELECT * FROM Products "
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetProductsPackets() As DataTable
        Dim cmdText As String = String.Empty

        ''''''cmdText = "SELECT * FROM Products "

        cmdText = "select pr.productcode & ' ' & pc.PacketSize as ProductCode ,pc.SKU_Code & '  ' & pr.ProductName & ' ' & pc.PacketSize & " & Chr(34) & "'s" & Chr(34) & " as ProductName from products pr,packets pc  where(pr.productcode = pc.productcode) order by pc.SKU_Code "

        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetPackets(ByVal ProductCode As String) As DataTable
        Dim cmdText As String = String.Empty

        cmdText = "SELECT * FROM Packets where ProductCode='" & ProductCode & "'"

        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetProductsAndPackets(ByVal RegionCode As String) As DataTable
        Dim cmdText As String = String.Empty

        'cmdText = "select Packets.ProductCode,Packets.PacketSize,Products.ProductName from Packets " & _
        '            " inner join Products on Packets.ProductCode=Products.ProductCode " & _
        '            " where Packets.SystemId in (Select ProdcutPacketID from ProductPacketRegion where RegionCode=" & RegionCode & ")"
        cmdText = "Select ProductPacketRegion.ID,ProductPacketRegion.ProdcutPacketID,Packets.ProductCode,Packets.PacketSize,Products.ProductName from ProductPacketRegion, Packets, Products " & _
          " where ProductPacketRegion.ProdcutPacketID = Packets.SystemId And Products.ProductCode=Packets.ProductCode  And ProductPacketRegion.RegionCode =" & RegionCode
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetUserRights(ByVal UserCode As String) As DataTable
        Dim cmdText As String = String.Empty
        cmdText = "Select * from UserRights where UserID=" & UserCode
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetUsers() As DataTable
        Dim cmdText As String = String.Empty
        cmdText = "Select * from Users "
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetBatchNo(ByRef lastBatchNo As Int32) As Int32
        random = New System.Random(lastBatchNo)
        Dim seed As Int64 = random.Next(999999999)
        random = New System.Random(seed)
        Return random.Next(1000, 9999)
    End Function
    Public Function GetBatchNo(ByVal type As BatchType) As DataTable
        Dim cmdText As String = String.Empty
        Select Case type
            Case BatchType.Uploaded
                cmdText = "SELECT BatchNo FROM Batch WHERE IsUploaded <>'N'"
            Case BatchType.NotUploaded
                cmdText = "SELECT BatchNo FROM Batch WHERE IsUploaded <>'Y'"
        End Select
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetBatchNo() As DataTable
        Dim cmdText As String = "Select BatchNo From Batch"
        Return CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet).Tables(0)
    End Function
    Public Function GetCSFString(ByVal ProductCode As String, ByVal PacketSize As Integer, ByVal Region As String, ByVal IsUpload As String) As String
        Dim cfsString As String = String.Empty
        Dim cfsIds As String = String.Empty
        Dim dtCFS As DataTable = GetSerials(ProductCode, PacketSize, Region, IsUpload)
        If dtCFS.Rows.Count > 0 Then
            For Each row As DataRow In dtCFS.Rows
                'cfsString += row("Serials").ToString & "," & row("ProductCode").ToString & "," & row("PacketSize").ToString & "," & row("Region").ToString & ","
                cfsString += row("Serials").ToString & "," & row("ProductCode").ToString & "," & row("PacketSize").ToString & "," & row("Region").ToString & "," & row("InsDate").ToString & ","
                cfsIds += row("ID").ToString & ","
            Next
            cfsString = cfsString.Substring(0, cfsString.Length - 1).Trim
            cfsString += "~~" & cfsIds.Substring(0, cfsIds.Length - 1).Trim
            Return cfsString
        Else
            Return String.Empty
        End If
    End Function
    Public Function GetCSFString() As String
        'Dim cfsString As String = String.Empty
        'Dim cfsIds As String = String.Empty
        'Dim dtCFS As DataTable = GetSerials()
        'If dtCFS.Rows.Count > 0 Then
        '    For Each row As DataRow In dtCFS.Rows
        '        cfsString += row("Serials").ToString & ","
        '        cfsIds += row("ID").ToString & ","
        '    Next
        '    cfsString = cfsString.Substring(0, cfsString.Length - 1).Trim
        '    cfsString += "~~" & cfsIds.Substring(0, cfsIds.Length - 1).Trim
        '    Return cfsString
        'Else
        '    Return String.Empty
        'End If
        Dim cfsString As String = String.Empty
        Dim cfsIds As String = String.Empty
        Dim dtCFS As DataTable = GetSerials()
        If dtCFS.Rows.Count > 0 Then
            For Each row As DataRow In dtCFS.Rows
                cfsString += row("Serials").ToString & "," & row("ProductCode").ToString & "," & row("PacketSize").ToString & "," & row("Region").ToString & ","
                cfsIds += row("ID").ToString & ","
            Next
            cfsString = cfsString.Substring(0, cfsString.Length - 1).Trim
            cfsString += "~~" & cfsIds.Substring(0, cfsIds.Length - 1).Trim
            Return cfsString
        Else
            Return String.Empty
        End If
    End Function
    Public Function GetCSFString(ByVal batchNo As Int32) As String
        Dim cfsString As String = String.Empty
        'Dim dtCFS As DataTable = GetSerials(batchNo)
        Dim dtCFS As DataTable = GetSerials(batchNo)
        If dtCFS.Rows.Count > 0 Then
            For Each row As DataRow In dtCFS.Rows
                cfsString += row("Serials").ToString & ","
            Next
            Return cfsString.Substring(0, cfsString.Length - 1)
        Else
            Return String.Empty
        End If
    End Function
    Public Function UpLoadSerials(ByVal str As String) As Boolean


        'If Not str.Equals(String.Empty) Then
        '    Dim upload As New com.infinishops.tbs2.Service1
        '    Dim arrSerIds() As String = str.Split(",")
        '    Dim i As Integer = 0
        '    Dim myXMLText As String = System.String.Empty
        '    myXMLText += "<Doc>"
        '    Do While i < arrSerIds.Length
        '        myXMLText += "<Product Code=" & Chr(34) & arrSerIds(i) & Chr(34) & " Id=" & Chr(34) & arrSerIds(i + 1) & Chr(34) & " />"
        '        i += 2
        '    Loop
        '    myXMLText += "</Doc>"
        '    Try
        '        Select Case upload.UploadCodes(myXMLText).ToLower
        '            Case "Success".ToLower
        '                Return True
        '            Case "Failed".ToLower
        '                Return False
        '        End Select
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        '    Return True
        'Else
        '    MessageBox.Show("Serials not found...", "Batch System", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If






    End Function
    Public Function UpLoadSecurityCodes(ByVal str As String) As String
        Dim sResult As String = System.String.Empty

        'If Not str.Equals(String.Empty) Then

        '    Dim upload As New com.infinishops.tbs2.Service1
        '    Dim arrSerIds() As String = str.Split(",")
        '    Dim i As Integer = 0
        '    Dim myXMLText As String = System.String.Empty
        '    Dim strDate1 As String = System.String.Empty
        '    Dim strDate As String = System.String.Empty
        '    myXMLText += "<Doc>"
        '    Do While i < arrSerIds.Length
        '        'strDate1 = arrSerIds(i + 4).ToString
        '        'strDate = Format(Convert.ToDateTime(strDate1), "MM/dd/yyyy")
        '        ''myXMLText += "<Product Code=" & Chr(34) & arrSerIds(i) & Chr(34) & " Id=" & Chr(34) & arrSerIds(i + 1) & Chr(34) & " Packet=" & Chr(34) & arrSerIds(i + 2) & Chr(34) & " Region=" & Chr(34) & arrSerIds(i + 3) & Chr(34) & " />"
        '        myXMLText += "<Product Code=" & Chr(34) & arrSerIds(i) & Chr(34) & " Id=" & Chr(34) & arrSerIds(i + 1) & Chr(34) & " Packet=" & Chr(34) & arrSerIds(i + 2) & Chr(34) & " Region=" & Chr(34) & arrSerIds(i + 3) & Chr(34) & " Date=" & Chr(34) & Format(Convert.ToDateTime(arrSerIds(i + 4).ToString), "MM/dd/yyyy") & Chr(34) & " />"
        '        i += 5
        '        strDate = System.String.Empty
        '    Loop
        '    myXMLText += "</Doc>"
        '    Try
        '        sResult = upload.UploadSecurityCodes(myXMLText).ToLower
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'Else
        '    MessageBox.Show("Serials not found...", "Batch System", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

        Return sResult
    End Function
    Public Function UpdateSerialsStatus(ByVal serial As String, ByVal Connection As OleDbConnection, Optional ByVal Ids As Boolean = False) As Boolean
        Dim cmdText As String = String.Empty

        If Ids Then
            cmdText = "UPDATE Serials SET Serials.IsUploaded ='Y'  WHERE ID In (" & serial & ") ; "
        Else
            cmdText = "UPDATE Serials SET Serials.IsUploaded ='Y'  WHERE Serials.Serials IN (SELECT serials From Serials WHERE batchNo = " & serial & "); "
            ExecuteQuery(cmdText, Execute.None, Connection)
            cmdText = "UPDATE Batch SET Batch.IsUploaded ='Y' WHERE batchNo =" & serial & ";"
        End If
        ExecuteQuery(cmdText, Execute.None, Connection)
    End Function
    Public Function UpdateSerialsStatus(ByVal serial As String, Optional ByVal Ids As Boolean = False) As Boolean
        Dim cmdText As String = String.Empty

        If Ids Then
            cmdText = "UPDATE Serials SET Serials.IsUploaded ='Y'  WHERE ID In (" & serial & ") ; "
        Else
            cmdText = "UPDATE Serials SET Serials.IsUploaded ='Y'  WHERE Serials.Serials IN (SELECT serials From Serials WHERE batchNo = " & serial & "); "
            ExecuteQuery(cmdText, Execute.None)
            cmdText = "UPDATE Batch SET Batch.IsUploaded ='Y' WHERE batchNo =" & serial & ";"
        End If
        ExecuteQuery(cmdText, Execute.None)
    End Function
    Public Function IsExistsBatch(ByVal batchXml As String, ByVal batchNo As Int64) As Boolean
        Dim xmlNode As Xml.XmlNode
        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc.LoadXml(batchXml)
        xmlNode = xmlDoc.SelectSingleNode("//Table[BatchNo='" & Convert.ToString(batchNo) & "']")
        Return IIf(xmlNode Is Nothing, False, True)
    End Function
    Public Sub GenerateReportXml(ByVal batchNo As Int32)
        Dim xmlWriter As New Xml.XmlTextWriter(IO.Directory.GetCurrentDirectory & "/serials.xml", System.Text.Encoding.UTF8)
        GetSerialsReport(batchNo).DataSet.WriteXml(xmlWriter)
        xmlWriter.Close()
    End Sub
    Public Sub SetSerials(ByVal batchNo As Int32)
        Dim cmdText As String
        cmdText = "DELETE FROM SerialReport"
        ExecuteQuery(cmdText, Execute.None)
        cmdText = "INSERT INTO SerialReport(Serials)SELECT Serials From Serials WHERE BatchNo=" & batchNo & ";"
        ExecuteQuery(cmdText, Execute.None)
    End Sub
    Public Sub SetSerials(ByVal serialCond As String, ByVal dateFrom As Date, ByVal dateTo As Date)
        Dim cmdText As String
        cmdText = "DELETE FROM SerialReport"
        ExecuteQuery(cmdText, Execute.None)

        cmdText = "INSERT INTO SerialReport(Serials)SELECT Serials From Serials WHERE IsUploaded='" & serialCond & "'"
        'cmdText += "And InsDate Between (#" & dateFrom & "#) And (#" & dateTo & "#);"

        ExecuteQuery(cmdText, Execute.None)
    End Sub
    Public Sub SetSerials(ByVal serialCond As String, ByVal ProdcutCode As String, ByVal PacketSize As Integer)
        Dim cmdText As String
        cmdText = "DELETE FROM SerialReport"
        ExecuteQuery(cmdText, Execute.None)

        cmdText = "INSERT INTO SerialReport(Serials)SELECT Serials From Serials WHERE IsUploaded='" & serialCond & "'"
        cmdText += "And ProductCode='" & ProdcutCode & "'  And PacketSize=" & PacketSize & ";"
        'cmdText += "And InsDate Between (#" & dateFrom & "#) And (#" & dateTo & "#);"

        ExecuteQuery(cmdText, Execute.None)
    End Sub
    Public Sub SetSerials(ByVal serialCond As String, ByVal ProdcutCode As String, ByVal PacketSize As Integer, ByVal dateFrom As Date, ByVal dateTo As Date)
        Dim cmdText As String
        cmdText = "DELETE FROM SerialReport"
        ExecuteQuery(cmdText, Execute.None)

        cmdText = "INSERT INTO SerialReport(Serials)SELECT Serials From Serials WHERE IsUploaded='" & serialCond & "'"
        cmdText += " And ProductCode='" & ProdcutCode & "'  And PacketSize=" & PacketSize
        cmdText += "And InsDate Between (#" & Format(dateFrom.Date, "MM/dd/yyyy") & "#) And (#" & Format(dateTo.Date, "MM/dd/yyyy") & "#);"
        'cmdText += "And InsDate Between (#" & dateFrom.Date & "#) And (#" & dateTo.Date & "#);"
        'cmdText += " And day(InsDate) Between (" & dateFrom.Day & ") And (" & dateTo.Day & ")"
        'cmdText += " And month(InsDate) Between (" & dateFrom.Month & ") And (" & dateTo.Month & ")"
        'cmdText += " And year(InsDate) Between (" & dateFrom.Year & ") And (" & dateTo.Year & ");"

        ExecuteQuery(cmdText, Execute.None)
    End Sub
    Public Sub SetSerials(ByVal serialCond As String, ByVal ProdcutCode As String, ByVal PacketSize As Integer, ByVal Region As String, ByVal dateFrom As Date, ByVal dateTo As Date)
        Dim cmdText As String
        cmdText = "DELETE FROM SerialReport"
        ExecuteQuery(cmdText, Execute.None)

        cmdText = "INSERT INTO SerialReport(Serials)SELECT Serials From Serials WHERE IsUploaded='" & serialCond & "'"
        cmdText += " And ProductCode='" & ProdcutCode & "'  And PacketSize=" & PacketSize
        cmdText += " And Region='" & Region & "' "
        cmdText += "And InsDate Between (#" & Format(dateFrom.Date, "MM/dd/yyyy") & "#) And (#" & Format(dateTo.Date, "MM/dd/yyyy") & "#);"
        'cmdText += "And InsDate Between (#" & dateFrom.Date & "#) And (#" & dateTo.Date & "#);"
        'cmdText += " And day(InsDate) Between (" & dateFrom.Day & ") And (" & dateTo.Day & ")"
        'cmdText += " And month(InsDate) Between (" & dateFrom.Month & ") And (" & dateTo.Month & ")"
        'cmdText += " And year(InsDate) Between (" & dateFrom.Year & ") And (" & dateTo.Year & ");"

        ExecuteQuery(cmdText, Execute.None)
    End Sub
    Public Function CheckDBNull(ByVal value As Object) As Integer
        If IsDBNull(value) Then
            Return 0
        Else
            Return value
        End If
    End Function
    Public Sub InsertBatch(ByRef batchNo As Int32)
        Dim cmdText As String = "INSERT INTO batch(BatchNo)VALUES(" & batchNo & ")"
        ExecuteQuery(cmdText, Execute.None)
    End Sub
    'Public Sub InsertSerial(ByRef SerialNo As Int64)
    '    Dim cmdText As String = "INSERT INTO serials(Serials,BatchNo)VALUES(" & SerialNo & "," & currentBatchNo & ")"
    '    ExecuteQuery(cmdText, Execute.None)
    'End Sub
    Public Sub InsertSerial(ByRef SerialNo As String)
        Try
            Dim cmdText As String = "INSERT INTO serials(Serials,BatchNo)VALUES('" & SerialNo & "'," & "1234" & ")"
            ExecuteQuery(cmdText, Execute.None)
        Catch ex As System.Data.OleDb.OleDbException
            If (ex.ErrorCode = -2147467259) Then
                iDuplicate = iDuplicate + 1
            End If
        End Try
    End Sub
    Public Function InsertSerialNo(ByRef SerialNo As String) As Boolean
        Dim bRetrun As Boolean = False
        Try
            Dim cmdText As String = "INSERT INTO serials(Serials,ProductCode)VALUES('" & SerialNo & "',1234)"
            ExecuteQuery(cmdText, Execute.None)
        Catch ex As System.Data.OleDb.OleDbException
            If (ex.ErrorCode = -2147467259) Then
                bRetrun = True
            End If
        End Try
        Return bRetrun
    End Function
    Public Function InsertSerialNo(ByRef SerialNo As String, ByVal ProductID As String) As Boolean
        Dim bRetrun As Boolean = False
        Try
            Dim cmdText As String = "INSERT INTO serials(Serials,ProductCode)VALUES('" & SerialNo & "','" & ProductID & "')"
            ExecuteQuery(cmdText, Execute.None)
        Catch ex As System.Data.OleDb.OleDbException
            If (ex.ErrorCode = -2147467259) Then
                bRetrun = True
            End If
        End Try
        Return bRetrun
    End Function
    Public Function InsertSerialNo(ByRef SerialNo As String, ByVal ProductID As String, ByVal PacketSize As Integer) As Boolean
        Dim bRetrun As Boolean = False
        Try
            Dim cmdText As String = "INSERT INTO serials(Serials,ProductCode,PacketSize)VALUES('" & SerialNo & "','" & ProductID & "'," & PacketSize & ")"
            ExecuteQuery(cmdText, Execute.None)
        Catch ex As System.Data.OleDb.OleDbException
            If (ex.ErrorCode = -2147467259) Then
                bRetrun = True
            End If
        End Try
        Return bRetrun
    End Function
    Public Function InsertSerialNo(ByRef SerialNo As String, ByVal ProductID As String, ByVal PacketSize As Integer, ByVal Region As String) As Boolean
        Dim bRetrun As Boolean = False
        Try
            Dim cmdText As String = "INSERT INTO serials(Serials,ProductCode,PacketSize,Region)VALUES('" & SerialNo & "','" & ProductID & "'," & PacketSize & ",'" & Region & "')"
            ExecuteQuery(cmdText, Execute.None)
        Catch ex As System.Data.OleDb.OleDbException
            If (ex.ErrorCode = -2147467259) Then
                bRetrun = True
            End If
        End Try
        Return bRetrun
    End Function
    Public Function InsertSerialNo(ByRef SerialNo As String, ByVal ProductID As String, ByVal PacketSize As Integer, ByVal Region As String, ByVal ProductPacketRegionID As Integer) As Boolean
        Dim bRetrun As Boolean = False
        Try
            Dim cmdText As String = "INSERT INTO serials(Serials,ProductCode,PacketSize,Region,ProdcutPacketRegionID)VALUES('" & SerialNo & "','" & ProductID & "'," & PacketSize & ",'" & Region & "'," & ProductPacketRegionID & ")"
            ExecuteQuery(cmdText, Execute.None)
        Catch ex As System.Data.OleDb.OleDbException
            If (ex.ErrorCode = -2147467259) Then
                bRetrun = True
            End If
        End Try
        Return bRetrun
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
End Class
