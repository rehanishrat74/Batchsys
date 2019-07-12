Imports System.Data.OleDb
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports BatchSystem.Common
Imports System.Collections.Generic
Public Class frmSerials1
    Private connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BatchSystem.mdb")
    Private isDuplicateBatch As Int32 = 0
    Private isNumber As Boolean = False
    Private toolTip1 As New ToolTip()
    Private Sub SetControls(ByVal isEnabled As Boolean)
        Me.cmbProduct.Enabled = isEnabled
        Me.txtBatchSize.Enabled = isEnabled
        'Me.btnReport.Enabled = isEnabled
        Me.btnUploadSerial.Enabled = isEnabled
        'Me.rdoBatch.Enabled = isEnabled
        'Me.rdoBatch2.Enabled = isEnabled
        'Me.dtFrom.Enabled = isEnabled
        'Me.dtTo.Enabled = isEnabled
        Me.btnSerials.Enabled = isEnabled
        'MenuStrip1.Enabled = isEnabled
        Dim f As frmMain = CType(Me.MdiParent, frmMain)
        f.MenuStrip1.Enabled = isEnabled
        'Form1 f = (Form1)this.MDIParent;
        'f.toolStripButton1.Enabled = false;

    End Sub
    Private Sub frmBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        '    Dim ico As New System.Drawing.Icon(Application.StartupPath & "\TBS_small3.ico")
        '    Me.Icon = ico
        'Catch ex As Exception

        'End Try
        Me.Icon = Nothing
        'Me.btnBatch.Visible = False
        grbSerials.Visible = True
        'grbProducts.Visible = False
        SetCombos()
        'SetComboRegions()
        'SetProductCombo()



        ' Set up the delays for the ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        toolTip1.ShowAlways = True

        ' Set up the ToolTip text for the Button and Checkbox.
        'toolTip1.SetToolTip(Me.cmbRegions, "My Region")

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
    End Sub
    Private Sub SetComboRegions(ByVal ProductCode As String, ByVal PacketSize As Integer)
        Dim dtRegions As DataTable
        dtRegions = Common.GetRegions(ProductCode, PacketSize)
        With Me.cmbRegions
            .Text = String.Empty
            .DisplayMember = "RegionCode"
            '            .ValueMember = "ID"
            .ValueMember = "Description"
            .DataSource = dtRegions
            .Refresh()
        End With
    End Sub
    Private Sub SetCombos()
        'SetProductCombo()
        'If cmbProduct.Items.Count > 0 Then
        '    cmbProduct.SelectedIndex = 0
        '    Dim ProductCode As String = cmbProduct.SelectedValue
        '    SetPacketsCombo(ProductCode)
        'End If
        SetProductCombo()
        'If cmbProduct.Items.Count > 0 Then
        '    cmbProduct.SelectedIndex = 0
        '    Dim ProductCode As String = cmbProduct.SelectedValue
        '    SetPacketsCombo(ProductCode)
        '    If cmbPacket.Items.Count > 0 Then
        '        Dim PacketSize As Integer = cmbPacket.Text
        '        SetComboRegions(ProductCode, PacketSize)
        '    End If
        'End If

        If cmbProduct.Items.Count > 0 Then
            Dim ProductPacket As String()
            Dim ProPack As String
            ProPack = cmbProduct.SelectedValue
            ProductPacket = ProPack.Split(" ")
            SetComboRegions(ProductPacket(0).ToString, ProductPacket(1).ToString)
        End If

    End Sub
    Private Sub SetProductCombo()
        Dim dtProducts As DataTable
        dtProducts = Common.GetProductsPackets()
        With Me.cmbProduct
            .Text = String.Empty
            .DisplayMember = "ProductName"
            .ValueMember = "ProductCode"
            .DataSource = dtProducts

            .Refresh()
        End With
    End Sub
    Private Sub SetPacketsCombo(ByVal ProductCode As String)
        Dim dtPackets As DataTable
        dtPackets = Common.GetPackets(ProductCode)
        With Me.cmbPacket
            .Text = String.Empty
            .DisplayMember = "PacketSize"
            .ValueMember = "ProductCode"
            .DataSource = dtPackets
            .Refresh()
        End With
    End Sub
    Private Function GenrateSerial5(ByRef random As System.Random, ByVal productID As String, ByVal packetSize As Integer, ByVal Region As String, ByVal ProductPacketRegionID As Integer) As Boolean
        Dim bReturn As Boolean = False
        Try
            'check data with data base from unique key constrain
            Dim bContinue As Boolean = True
            Dim builder As StringBuilder
            Dim sno As String = String.Empty
            Dim rNumber As Int32
            Dim serial As String = String.Empty
            Dim duplicate As Integer = 0
            Dim i As Integer = 0
            Dim bDuplicate As Boolean = False
            Dim objRegex As New Regex("^[a-zA-Z0-9]{12}$")
            Dim objB64e As New DesBase64Encypt

            For i = 1 To 25
                bReturn = False
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

                sno = serial + Convert.ToString(random.Next(GetSeedMinMax(12 - alphLength).Item(0), GetSeedMinMax(12 - alphLength).Item(1)))
                If objRegex.IsMatch(sno) Then

                    'Changes By SAk : Starts
                    Dim strFS As String = FormattedString(sno, 2, sno.Length)
                    Dim strFSS() As String = strFS.Split(" ")
                    Dim dataMetrix As String = String.Empty
                    Dim strBase64 As String = String.Empty
                    Dim strWithOutEQ As String = String.Empty
                    Dim strHumanCode As String

                    dataMetrix = strFSS(0) & strFSS(1) & strFSS(2) & strFSS(3) & "*" & strFSS(4) & strFSS(5) & strFSS(6) & strFSS(7) & strFSS(8) & "#" & strFSS(9) & strFSS(10) & strFSS(11)
                    strBase64 = objB64e.Encrypt(dataMetrix)
                    strWithOutEQ = strBase64.Substring(0, strBase64.Length - 2)
                    strHumanCode = strFSS(5) & strFSS(3) & strFSS(10) & strFSS(6) & strFSS(4) & strFSS(2) & strFSS(1) & strFSS(8) & strFSS(11) & strFSS(7) & strFSS(0) & strFSS(9)
                    'Changes : Ends

                    bDuplicate = InsertSerialNo(dataMetrix.ToUpper(), strHumanCode.ToUpper(), strBase64, strWithOutEQ, productID, packetSize, Region, ProductPacketRegionID)
                    If bDuplicate = True Then
                        'Dim arrChar() As Char = sno.ToCharArray()
                        'Array.Reverse(arrChar)
                        'sno = arrChar.ToString()
                        bDuplicate = Insert_DublicateSerialNo(dataMetrix.ToUpper(), strHumanCode.ToUpper(), strBase64, strWithOutEQ, productID, packetSize, Region, ProductPacketRegionID)
                    End If

                    If bDuplicate = True Then
                        sno = System.String.Empty
                    Else
                        counter += 1
                        Me.ProgressBar1.PerformStep()
                        bReturn = True
                        Exit For
                    End If

                End If
            Next
        Catch ex As System.Data.OleDb.OleDbException
            'If (ex.ErrorCode = -2147467259) Then
            '    sno = System.String.Empty
            'End If
            's.Close()
        End Try
        Return bReturn
    End Function

    Public Shared Function Unique12DigitNumber() As String

        Dim random As System.Random
        random = New System.Random(Date.Now.Month + Date.Now.Day + Date.Now.Hour + Date.Now.Minute + Date.Now.Second + Date.Now.Millisecond)

        'check data with data base from unique key constrain
        Dim bContinue As Boolean = True
        Dim builder As StringBuilder
        Dim sno As String = String.Empty
        Dim rNumber As Int32
        Dim serial As String = String.Empty
        Dim duplicate As Integer = 0
        Dim i As Integer = 0

        Dim bDuplicate As Boolean = False
        Dim objRegex As New Regex("^[a-zA-Z0-9]{12}$")
        For i = 1 To 25
            'bReturn = False
            serial = String.Empty
            builder = New StringBuilder
            Dim alphLength As Int64 = Random.Next(1, 9)
            For index As Int32 = 1 To alphLength
                rNumber = Random.Next(0, 49) + Random.Next(0, 50)
                If rNumber < 65 Then
                    rNumber = Random.Next(65, 90)
                ElseIf rNumber > 90 Then
                    rNumber = Random.Next(97, 122)
                End If
                serial += Microsoft.VisualBasic.ChrW(rNumber)
            Next
            sno = serial + Convert.ToString(Random.Next(GetSeedMinMax(12 - alphLength).Item(0), GetSeedMinMax(12 - alphLength).Item(1)))

        Next
        Return sno
    End Function

    Public Shared Function FormattedString(ByVal Content As String, ByVal ContentLength As Integer, ByVal TotalLength As Integer) As String
        Dim SpaceIndex As Integer = 0
        Dim PreviousSpaceIndex As Integer
        Dim CurrrentIndex As Integer = -1
        Dim ContentLen As Integer = Content.Length
        If Content = "" Then
            Return ""
        End If
        Do While True
            PreviousSpaceIndex = SpaceIndex
            SpaceIndex = Content.IndexOf(" "c, (SpaceIndex + 1))
            If ((SpaceIndex - PreviousSpaceIndex) > (ContentLength + 1)) OrElse Content.IndexOf(" "c, (CurrrentIndex + 1)) = -1 Then
                If (CurrrentIndex + ContentLength) < Content.Length Then
                    TotalLength += 1
                    Content = Content.Insert((CurrrentIndex + ContentLength), " ")
                    CurrrentIndex = 0
                    SpaceIndex = 0
                End If
            Else
                CurrrentIndex = SpaceIndex
            End If
            If SpaceIndex < 0 Then
                Exit Do
            End If
        Loop
        Return IIf((ContentLen > TotalLength), Content.Substring(0, TotalLength).TrimEnd() & "...", Content)
    End Function

    Private Function GenrateSerial5(ByRef random As System.Random, ByVal productID As String, ByVal packetSize As Integer) As Boolean
        Dim bReturn As Boolean = False
        Try
            'check data with data base from unique key constrain
            Dim bContinue As Boolean = True
            Dim builder As StringBuilder
            Dim sno As String = String.Empty
            Dim rNumber As Int32
            Dim serial As String = String.Empty
            Dim duplicate As Integer = 0
            Dim i As Integer = 0

            Dim bDuplicate As Boolean = False
            Dim path As String = Application.StartupPath() & "\SecurityCode.txt"

            If File.Exists(path) = False Then
                Dim sw As StreamWriter = File.CreateText(path)
                sw.Flush()
                sw.Close()
            End If

            Dim sr As StreamReader = File.OpenText(path)
            Dim myText As String
            myText = sr.ReadToEnd()
            sr.Close()

            Dim fs As New FileStream(path, FileMode.Open, FileAccess.Write)
            'Dim fs As New FileStream(path, FileMode.Create, FileAccess.Write)
            'declaring a FileStream and creating a document file named file with 
            'access mode of writing
            Dim s As New StreamWriter(fs)

            s.Write(myText)
            Dim objRegex As New Regex("^[a-zA-Z0-9]{10}$")
            For i = 1 To 25
                bReturn = False
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
                If objRegex.IsMatch(sno) Then
                    bDuplicate = InsertSerialNo(sno.ToUpper(), productID, packetSize)
                    If bDuplicate = True Then
                        Dim arrChar() As Char = sno.ToCharArray()
                        Array.Reverse(arrChar)
                        sno = arrChar.ToString()
                        bDuplicate = InsertSerialNo(sno.ToUpper(), productID, packetSize)
                    End If
                    If bDuplicate = True Then
                        sno = System.String.Empty
                    Else
                        s.WriteLine(sno)
                        counter += 1
                        'Me.ProgressBar1.Increment(counter)
                        Me.ProgressBar1.PerformStep()
                        bReturn = True
                        Exit For
                    End If
                End If
            Next
            s.Close()

        Catch ex As System.Data.OleDb.OleDbException
            'If (ex.ErrorCode = -2147467259) Then
            '    sno = System.String.Empty
            'End If
            's.Close()
        End Try
        Return bReturn
    End Function
    Private Function GenrateSerial4(ByRef random As System.Random, ByVal productID As String) As Boolean
        'check data with data base from unique key constrain
        Dim bContinue As Boolean = True
        Dim builder As StringBuilder
        Dim sno As String = String.Empty
        Dim rNumber As Int32
        Dim serial As String = String.Empty
        Dim duplicate As Integer = 0
        Dim i As Integer = 0
        Dim bReturn As Boolean = False
        Dim bDuplicate As Boolean = False
        Try
            Dim objRegex As New Regex("^[a-zA-Z0-9]{10}$")
            For i = 1 To 25
                bReturn = False
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
                If objRegex.IsMatch(sno) Then
                    bDuplicate = InsertSerialNo(sno, productID)
                    If bDuplicate = True Then
                        Dim arrChar() As Char = sno.ToCharArray()
                        Array.Reverse(arrChar)
                        sno = arrChar.ToString()
                        bDuplicate = InsertSerialNo(sno, productID)
                    End If
                    If bDuplicate = True Then
                        sno = System.String.Empty
                    Else
                        counter += 1
                        'Me.ProgressBar1.Increment(counter)
                        Me.ProgressBar1.PerformStep()
                        bReturn = True
                        Exit For
                    End If
                End If
            Next

        Catch ex As System.Data.OleDb.OleDbException
            'If (ex.ErrorCode = -2147467259) Then
            '    sno = System.String.Empty
            'End If
        End Try
        Return bReturn
    End Function
    Private Sub RemoveItems(ByRef ct As ComboBox)
        'For Each item As Object In ct.Items

        'Next
    End Sub
    Private Sub Serials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim arrSerIds() As String = Common.GetCSFString.Split("~~")
        If Common.UpLoadSerials(arrSerIds(0)) Then

            'Common.UpdateSerialsStatus(Me.cmbBatchNo.SelectedValue)
            Common.UpdateSerialsStatus(arrSerIds(2), True)
            'SetBatchCombo()

            MessageBox.Show("Uploaded Success...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Uploaded Failed...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


    Private Sub txtBatchSize_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue > 47 And e.KeyValue < 58) Or (e.KeyValue > 95 And e.KeyValue < 106) Or e.KeyValue = 8 Then
            Me.isNumber = True
        End If
    End Sub
    Private Sub txtBatchSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Me.isNumber Then
            Me.txtBatchSize.Text = 0
        End If
        Me.isNumber = False
    End Sub

    'Private Sub PrintGeneratedCodes()

    '        Dim f As frmCodesShow
    '    f = New frmCodesShow(dsCodes.Tables(0), Me.cmbProduct.Text)
    '        'f.Text = "Product and Packet Size"
    '        f.ShowDialog(Me)
    '        Dim iSelectID As String = frmCodesShow.iID
    '        Dim iSelectRange As Integer = frmCodesShow.iRange

    '        Dim strRetValue As String = System.String.Empty
    '        Dim lReturnValue As Long
    '        Dim strMessage As String
    '        'lReturnValue = CType(SendMessage("ASEDE312", lPrinterID, 15, 81, 1), Long)
    '        'strRetValue = SendMessage("ASEDE312", lPrinterID, 15, 81, 1)


    '        If iSelectID.Length > 0 Then
    '            lsbPrintedCodes.Visible = False
    '            Label2.Visible = False
    '            strMessage = iSelectID
    '            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
    '            sw1.WriteLine(".Net btnShow_Click : Single message Printing")
    '            sw1.WriteLine(".Net btnShow_Click : Message to Print is : " & strMessage)
    '            sw1.WriteLine(".Net btnShow_Click : Calling function SendMessage(" & strMessage & "," & lPrinterID & ",15,81,1)")
    '            sw1.Close()
    '            strRetValue = SendMessage(strMessage, lPrinterID, 15, 81, 1)
    '            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
    '            sw1.WriteLine(".Net btnShow_Click : Return form the function SendMessage ")
    '            sw1.WriteLine(".Net btnShow_Click : The value return is  :" & strRetValue)
    '            sw1.Close()
    '            If strRetValue <> "" Then
    '                lReturnValue = CType(strRetValue, Long)
    '                If lReturnValue = ConstEnum.IJ_SUCCESS Then
    '                    cmdText = "UPDATE Serials SET IsPrinted='Y' WHERE Serials='" & strMessage & "'  "
    '                    MessageBox.Show("Message Printed Success", "Batch Security System", MessageBoxButtons.OK)
    '                Else
    '                    Dim objmodFunctions As New modFunctions
    '                    objmodFunctions.ShowFailureMessage(lReturnValue)
    '                    Exit Sub
    '                End If
    '            Else
    '                MessageBox.Show("Error , Try Later....")
    '                Exit Sub
    '            End If
    '        ElseIf iSelectRange > 0 Then
    '            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
    '            sw1.WriteLine(".Net btnShow_Click : Multiple message Printing")
    '            sw1.Close()
    '            lsbPrintedCodes.Visible = True
    '            Label2.Visible = True
    '            Dim i As Integer = 0
    '            Dim dtCode As DataTable
    '            Dim strPrintedCode As String = System.String.Empty
    '            dtCode = dsCodes.Tables(0)
    '            For i = 0 To iSelectRange - 1
    '                strMessage = dtCode.Rows(i)(0).ToString
    '                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
    '                sw1.WriteLine(".Net btnShow_Click : Message to Print is : " & strMessage)
    '                sw1.WriteLine(".Net btnShow_Click : Calling function SendMessage(" & strMessage & "," & lPrinterID & ",15,81,1)")
    '                sw1.Close()
    '                strRetValue = SendMessage(strMessage, lPrinterID, 15, 81, 1)
    '                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
    '                sw1.WriteLine(".Net btnShow_Click : Return form the function SendMessage ")
    '                sw1.WriteLine(".Net btnShow_Click : The value return is  :" & strRetValue)
    '                sw1.Close()
    '                If strRetValue <> "" Then
    '                    lReturnValue = CType(strRetValue, Long)
    '                    If lReturnValue = ConstEnum.IJ_SUCCESS Then
    '                        cmdText = "UPDATE Serials SET IsPrinted='Y' WHERE Serials='" & strMessage & "'  "
    '                        'strPrintedCode = strPrintedCode & strMessage & ","
    '                        'lblCodePrinted.Text = strPrintedCode.Substring(0, strPrintedCode.Length - 1).Trim
    '                        lsbPrintedCodes.Items.Add(strMessage)
    '                    Else
    '                        Dim objmodFunctions As New modFunctions
    '                        objmodFunctions.ShowFailureMessage(lReturnValue)
    '                    End If
    '                Else
    '                    MessageBox.Show("Error , Try Later....")
    '                    Exit Sub
    '                End If
    '                strMessage = System.String.Empty
    '            Next
    '            MessageBox.Show("Message Printed Success", "Batch Security System", MessageBoxButtons.OK)
    '        Else

    '        End If

    'End Sub

    Private Sub btnSerials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerials.Click

        Try
            If Me.cmbProduct.SelectedValue <> Nothing Then
                'If cmbPacket.Text.Length > 0 AndAlso IsNumeric(cmbPacket.Text) AndAlso cmbPacket.Text <> 0 Then
                If cmbRegions.SelectedValue <> Nothing Then
                    If txtBatchSize.Text.Length > 0 AndAlso IsNumeric(txtBatchSize.Text) AndAlso txtBatchSize.Text > 0 Then
                        Me.SetControls(False)
                        batchSize = IIf(IsNumeric(txtBatchSize.Text), txtBatchSize.Text, 0)
                        'batchSize = IIf(IsNumeric(cmbPacket.Text), cmbPacket.Text, 0)
                        counter = 0
                        Me.ProgressBar1.Minimum = 1
                        Me.ProgressBar1.Maximum = batchSize
                        Me.ProgressBar1.Step = 1
                        Dim i As Integer = 0
                        Dim Random As System.Random
                        Dim bInsertCheck As Boolean
                        Dim iProductPacketRegionID As Integer = 0
                        ''''' addition

                        Dim ProductPacket As String()
                        Dim ProPack As String
                        ProPack = cmbProduct.SelectedValue
                        ProductPacket = ProPack.Split(" ")


                        '' ''Dim cmdText As String = "select ProductPacketRegion.ID from ProductPacketRegion ,Regions,Packets " & _
                        '' ''" where ProductPacketRegion.ProdcutPacketID = Packets.SystemId and Regions.id=ProductPacketRegion.RegionCode " & _
                        '' ''" and Packets.ProductCode='" & cmbProduct.SelectedValue & "'  And Packets.PacketSize = " & cmbPacket.Text & "  and Regions.RegionCode='" & cmbRegions.Text & "'"
                        '' ''Dim ds As DataSet = ExecuteQuery(cmdText, Execute.DataSet)

                        Dim cmdText As String = "select ProductPacketRegion.ID from ProductPacketRegion ,Regions,Packets " & _
                        " where ProductPacketRegion.ProdcutPacketID = Packets.SystemId and Regions.id=ProductPacketRegion.RegionCode " & _
                        " and Packets.ProductCode='" & ProductPacket(0) & "'  And Packets.PacketSize = " & ProductPacket(1) & "  and Regions.RegionCode='" & cmbRegions.Text & "'"
                        Dim ds As DataSet = ExecuteQuery(cmdText, Execute.DataSet)


                        iProductPacketRegionID = ds.Tables(0).Rows(0).Item("ID")
                        Random = New System.Random(Date.Now.Month + Date.Now.Day + Date.Now.Hour + Date.Now.Minute + Date.Now.Second + Date.Now.Millisecond)
                        For i = 1 To batchSize
                            ' '' ''bInsertCheck = Me.GenrateSerial5(Random, cmbProduct.SelectedValue, cmbPacket.Text, cmbRegions.Text, iProductPacketRegionID)
                            bInsertCheck = Me.GenrateSerial5(Random, ProductPacket(0), ProductPacket(1), cmbRegions.Text, iProductPacketRegionID)
                            If bInsertCheck = False Then
                                i = i - 1
                                Random = New System.Random(Date.Now.Month + Date.Now.Day + Date.Now.Hour + Date.Now.Minute + Date.Now.Second + Date.Now.Millisecond)
                            End If
                        Next
                        Me.SetControls(True)
                        MessageBox.Show("Security Code Generated", "TBS Security Code : " & Date.Now, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtTotalSerials.Text = txtTotalSerials.Text + batchSize
                        Me.ProgressBar1.Refresh()
                        Me.ProgressBar1.Maximum = 0
                        'SetBatchCombo()
                    Else
                        MessageBox.Show("Please Enter Batch size correct...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Please Select Region  ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                ''Else
                ''    MessageBox.Show("Please Select Packet  Size...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ''End If
            Else
                MessageBox.Show("Please Select Product ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            'Catch ex As Exception
            '    If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
            '        'create it if it doesn't
            '        Directory.CreateDirectory(Application.StartupPath() & "\Trace")
            '    End If

            '    Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
            '        sw.WriteLine("Error from .Net : , " & DateTime.Now & " , " & ex.Message)
            '        sw.Close()
            '    End Using
            '    ''MessageBox.Show("Error " & ex.Message.ToString)
            '    MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub btnUploadSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadSerial.Click

        Try
            Me.SetControls(False)
            If Me.cmbProduct.SelectedValue <> Nothing Then
                ''''If cmbPacket.Text.Length > 0 AndAlso IsNumeric(cmbPacket.Text) AndAlso cmbPacket.Text <> 0 Then
                If cmbRegions.SelectedValue <> Nothing Then
                    'If txtBatchSize.Text.Length > 0 AndAlso IsNumeric(txtBatchSize.Text) AndAlso txtBatchSize.Text > 0 Then

                    Dim ProductPacket As String()
                    Dim ProPack As String
                    ProPack = cmbProduct.SelectedValue
                    ProductPacket = ProPack.Split(" ")


                    '''Dim sSerIDs As String = Common.GetCSFString(cmbProduct.SelectedValue, cmbPacket.Text, cmbRegions.Text, "N")
                    Dim sSerIDs As String = Common.GetCSFString(ProductPacket(0), ProductPacket(1), cmbRegions.Text, "N")
                    If sSerIDs.Length > 0 Then
                        Dim arrSerIds() As String = sSerIDs.Split("~~")
                        Dim sResult As String = System.String.Empty
                        sResult = Common.UpLoadSecurityCodes(arrSerIds(0))
                        Dim sIDsAyyayList As New ArrayList
                        'sResult = "success"
                        Select Case sResult
                            Case "success"
                                sIDsAyyayList = GetIDByArray(arrSerIds(2), 500)
                                Dim objIDs As Object
                                With connection
                                    .Open()
                                End With
                                'Common.UpdateSerialsStatus(arrSerIds(2), True)
                                For Each objIDs In sIDsAyyayList
                                    Common.UpdateSerialsStatus(objIDs.ToString, connection, True)
                                Next
                                If Not connection.State = ConnectionState.Closed Then
                                    connection.Close()
                                End If
                                Me.SetControls(True)
                                MessageBox.Show("Uploaded Success...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Case "failed"
                                MessageBox.Show("Uploaded Failed...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Case "duplicate record"
                                MessageBox.Show("Same Codes not allow to upload", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Select
                    Else
                        MessageBox.Show("Security Code not found according to given criteria...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    'Else
                    '    MessageBox.Show("Please Enter Batch size correct...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'End If
                Else
                    MessageBox.Show("Please Select Region  ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                ' ''Else
                ' ''    MessageBox.Show("Please Select Packet  Size...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' ''End If
            Else
                MessageBox.Show("Please Select Product ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


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
            If Not connection.State = ConnectionState.Closed Then
                connection.Close()
            End If
        Finally
            Me.SetControls(True)
        End Try


        'Catch ex As Exception
        '    MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    If Not connection.State = ConnectionState.Closed Then
        '        connection.Close()
        '    End If
        'Finally
        '    Me.SetControls(True)
        'End Try

        'Try


        '    Dim arrSerIds() As String = Common.GetCSFString.Split("~~")
        '    Dim sResult As String = System.String.Empty
        '    'sResult = Common.UpLoadSecurityCodes(arrSerIds(0))
        '    Dim sIDsAyyayList As New ArrayList
        '    sResult = "success"
        '    Select Case sResult
        '        Case "success"
        '            sIDsAyyayList = GetIDByArray(arrSerIds(2))
        '            Dim objIDs As Object
        '            For Each objIDs In sIDsAyyayList
        '                Common.UpdateSerialsStatus(objIDs.ToString, True)
        '            Next
        '            'Common.UpdateSerialsStatus(arrSerIds(2), True)
        '            MessageBox.Show("Uploaded Successfully...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Case "failed"
        '            MessageBox.Show("Uploaded Failed...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Case "duplicate record"
        '            MessageBox.Show("Duplicate Codes not allow to upload", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Select
        'Catch ex As Exception
        '    MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Public Function GetIDByArray(ByVal ID As String, ByVal Size As Integer) As ArrayList
        Dim IdsArrayList As New ArrayList
        Dim sIds As String = ID
        Dim sAyyayId As String = System.String.Empty
        Dim AyyayListId As Array
        AyyayListId = ID.Split(",")
        Dim sNewId As String
        Dim bConditon As Boolean = True
        sAyyayId = sIds
        Dim arraySize As Integer = 0
        Dim i As Integer = 0
        arraySize = AyyayListId.Length
        If arraySize = Size Or arraySize < Size Then
            IdsArrayList.Add(ID)
        Else
            Do While bConditon = True
                If arraySize > Size Then
                    sNewId = System.String.Empty
                    For i = 1 To Size
                        sNewId = sNewId & AyyayListId(arraySize - i) & ","
                    Next
                    sNewId += sNewId.Substring(0, sNewId.Length - 1).Trim
                    IdsArrayList.Add(sNewId)
                    arraySize = arraySize - Size
                Else
                    sNewId = System.String.Empty
                    For i = 1 To arraySize
                        sNewId = sNewId & AyyayListId(arraySize - i) & ","
                    Next
                    sNewId += sNewId.Substring(0, sNewId.Length - 1).Trim
                    IdsArrayList.Add(sNewId)
                    bConditon = False
                End If
            Loop
        End If
        Return IdsArrayList
    End Function
    Public Function GetIDByArray(ByVal ID As String) As ArrayList
        Dim IdsArrayList As New ArrayList
        Dim q As New System.Collections.SortedList

        'Dim iLastIndex As Integer
        Dim sIds As String = ID
        Dim sAyyayId As String = System.String.Empty
        Dim AyyayListId As Array
        AyyayListId = ID.Split(",")
        Dim sNewId As String
        Dim bConditon As Boolean = True
        sAyyayId = sIds
        Dim arraySize As Integer = 0
        Dim i As Integer = 0
        arraySize = AyyayListId.Length
        If arraySize = 5000 Or arraySize < 5000 Then
            IdsArrayList.Add(ID)
        Else
            Do While bConditon = True
                If arraySize > 5000 Then
                    sNewId = System.String.Empty
                    For i = 1 To 5000
                        'For i = 0 To 1000
                        sNewId = sNewId & AyyayListId(arraySize - i) & ","
                    Next
                    sNewId += sNewId.Substring(0, sNewId.Length - 1).Trim
                    IdsArrayList.Add(sNewId)
                    'arraySize = AyyayListId.Length - (5000 + arraySize)
                    arraySize = arraySize - 5000
                Else
                    sNewId = System.String.Empty
                    For i = 1 To arraySize
                        'For i = arraySize To AyyayListId.Length
                        sNewId = sNewId & AyyayListId(arraySize - i) & ","
                    Next
                    sNewId += sNewId.Substring(0, sNewId.Length - 1).Trim
                    IdsArrayList.Add(sNewId)
                    bConditon = False
                End If
            Loop
        End If


        ''iLastIndex = sIds.LastIndexOf(",")

        'Do While bConditon = True
        '    iLastIndex = sIds.LastIndexOf(",")
        '    If iLastIndex > 1000 Then
        '        sAyyayId = System.String.Empty
        '        sAyyayId = sIds.Substring(0, iLastIndex)
        '        sIds = sIds.Substring(iLastIndex + 1, sIds.Length - 1)
        '        IdsArrayList.Add(sAyyayId)
        '    Else
        '        IdsArrayList.Add(sAyyayId)
        '        bConditon = False
        '    End If
        'Loop
        Return IdsArrayList
    End Function
    Private Sub cmbProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProduct.SelectedIndexChanged
        '' ''If Me.cmbProduct.SelectedValue <> Nothing Then
        '' ''    Dim sProCode As String = cmbProduct.SelectedValue
        '' ''    SetPacketsCombo(sProCode)
        '' ''    If Me.cmbPacket.SelectedValue <> Nothing Then
        '' ''        Dim iPacketSize As Integer = cmbPacket.Text
        '' ''        SetComboRegions(sProCode, iPacketSize)
        '' ''    End If

        '' ''    'Dim iTotalSerials As Integer = GetTotalSerials(cmbProduct.SelectedValue, cmbPacket.Text)
        '' ''    Dim iTotalSerials As Integer = GetTotalSerials(cmbProduct.SelectedValue, cmbPacket.Text, cmbRegions.Text)
        '' ''    txtTotalSerials.Text = iTotalSerials
        '' ''End If

        If Me.cmbProduct.SelectedValue <> Nothing Then
            Dim ProductPacket As String()
            Dim ProPack As String
            ProPack = cmbProduct.SelectedValue
            ProductPacket = ProPack.Split(" ")
            SetComboRegions(ProductPacket(0).ToString, ProductPacket(1).ToString)

            'Dim iTotalSerials As Integer = GetTotalSerials(cmbProduct.SelectedValue, cmbPacket.Text)
            Dim iTotalSerials As Integer = GetTotalSerials(ProductPacket(0), ProductPacket(1), cmbRegions.Text)
            txtTotalSerials.Text = iTotalSerials
        End If


    End Sub


    Private Sub cmbPacket_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPacket.SelectedIndexChanged
        Try
            If Me.cmbPacket.SelectedValue <> Nothing Then
                SetComboRegions(cmbProduct.SelectedValue, cmbPacket.Text)
                If cmbRegions.Text <> Nothing Then
                    txtBatchSize.Text = cmbPacket.Text
                    Dim iTotalSerials = GetTotalSerials(cmbProduct.SelectedValue, cmbPacket.Text, cmbRegions.Text)
                    txtTotalSerials.Text = iTotalSerials
                Else
                    txtTotalSerials.Text = 0
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function GetTotalSerials(ByVal ProductCode As String, ByVal PacketSize As Integer) As Integer
        Dim cmdText As String = System.String.Empty
        cmdText = "Select count(*) from Serials where ProductCode='" & ProductCode & "' And PacketSize=" & PacketSize & " ;"
        Dim TotalRecord As Integer = ExecuteQuery(cmdText, Execute.Scalar)
        Return TotalRecord
    End Function
    Private Function GetTotalSerials(ByVal ProductCode As String, ByVal PacketSize As Integer, ByVal Region As String) As Integer
        Dim cmdText As String = System.String.Empty
        cmdText = "Select count(*) from Serials where ProductCode='" & ProductCode & "' And PacketSize=" & PacketSize & " AND Region='" & Region & "';"
        Dim TotalRecord As Integer = ExecuteQuery(cmdText, Execute.Scalar)
        Return TotalRecord
    End Function

    Private Sub cmbRegions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegions.SelectedIndexChanged
        ' ''If cmbRegions.Text <> Nothing Then
        ' ''    txtBatchSize.Text = cmbPacket.Text
        ' ''    Dim iTotalSerials = GetTotalSerials(cmbProduct.SelectedValue, cmbPacket.Text, cmbRegions.Text)
        ' ''    txtTotalSerials.Text = iTotalSerials
        ' ''Else
        ' ''    txtTotalSerials.Text = 0
        ' ''End If

        If cmbRegions.Text <> Nothing Then
            Dim ProductPacket As String()
            Dim ProPack As String
            ProPack = cmbProduct.SelectedValue
            ProductPacket = ProPack.Split(" ")

            txtBatchSize.Text = ProductPacket(1)
            Dim iTotalSerials = GetTotalSerials(ProductPacket(0), ProductPacket(1), cmbRegions.Text)
            txtTotalSerials.Text = iTotalSerials
        Else
            txtTotalSerials.Text = 0
        End If
    End Sub

    Private Sub cmbRegions_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbRegions.KeyPress
        e.Handled = True
    End Sub
    Private Sub cmbRegions_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegions.MouseEnter
        toolTip1.SetToolTip(cmbRegions, cmbRegions.SelectedValue)
    End Sub

    Private Sub frmSerials1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ''MessageBox.Show("nisar")
    End Sub

    Private Sub grbSerials_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbSerials.Enter

    End Sub


End Class