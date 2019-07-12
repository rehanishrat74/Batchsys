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
Public Class frmReportCriteria
    Public sReportCriteria As String
    Dim sUserCode As String
    Public Property ReportName() As String
        Get
            Return sReportCriteria
        End Get
        Set(ByVal value As String)
            sReportCriteria = value
        End Set
    End Property

    Public Sub New(ByVal value As String, ByVal userCode As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        sReportCriteria = value
        sUserCode = userCode
    End Sub
    Public Function PapulateTextFile(ByVal dtTable As DataTable) As Boolean
        Dim FileName As String
        Dim sw As StreamWriter
        'streamwriter is used to write text
        Try
            With SaveFileDialog1
                .InitialDirectory = Application.StartupPath()
                'With SaveFileDialog1
                .FileName = "Security Code"
                .Filter = "Text files (*.txt)|*.txt"
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    'MessageBox.Show(dlgSaveData.FileName)
                    FileName = .FileName
                    'Dim fileEx As String = FileName.Substring(FileName.IndexOf("."), FileName.Length - FileName.IndexOf("."))
                    'FileName = FileName.Replace(fileEx, ".txt")
                    sw = New StreamWriter(FileName)
                    Dim strText As String = System.String.Empty
                    Dim drText As DataRow
                    For Each drText In dtTable.Rows()
                        strText = drText(0)
                        'strText = drText(0) & "," & drText(1)
                        'sw.WriteLine(drText(0))
                        sw.WriteLine(strText)
                    Next
                    sw.Close()
                    Return True
                Else
                    Return False
                End If
            End With
        Catch es As Exception
            MessageBox.Show(es.Message)
            If Not (sw Is Nothing) Then
                sw.Close()
            End If
            Return False
        End Try
    End Function

    Private Sub GenrateReport(ByVal batchNo As Int32)
        Common.SetSerials(batchNo)
    End Sub
    Private Sub GenrateReport(ByVal SerialCondition As String, ByVal dateFrom As Date, ByVal dateTo As Date)
        Common.SetSerials(SerialCondition, dateFrom, dateTo)
    End Sub
    Private Sub GenrateReport(ByVal SerialCondition As String, ByVal ProdcutCode As String, ByVal PacketZize As Integer)
        Common.SetSerials(SerialCondition, ProdcutCode, PacketZize)
    End Sub
    Private Sub GenrateReport(ByVal SerialCondition As String, ByVal ProdcutCode As String, ByVal PacketZize As Integer, ByVal dateFrom As Date, ByVal dateTo As Date)
        Common.SetSerials(SerialCondition, ProdcutCode, PacketZize, dateFrom, dateTo)
    End Sub
    Private Sub GenrateReport(ByVal SerialCondition As String, ByVal ProdcutCode As String, ByVal PacketZize As Integer, ByVal Region As String, ByVal dateFrom As Date, ByVal dateTo As Date)
        Common.SetSerials(SerialCondition, ProdcutCode, PacketZize, Region, dateFrom, dateTo)
    End Sub
    Private Function SetParameter() As ArrayList

        Dim ProductPacket As String()
        Dim ProPack As String
        ProPack = cmbProduct.SelectedValue
        ProductPacket = ProPack.Split(" ")



        Dim ParasArrayList As New ArrayList
        Dim myParaMeter As ReportParameters
        myParaMeter = New ReportParameters
        myParaMeter.ParameterName = "pProductCode"
        'myParaMeter.ParameterValue = cmbProduct.Text
        myParaMeter.ParameterValue = ProductPacket(0)
        'myParaMeter.ParameterValue = cmbProduct.SelectedText
        'myParaMeter.ParameterType=
        ParasArrayList.Add(myParaMeter)

        myParaMeter = New ReportParameters
        myParaMeter.ParameterName = "pPacketSize"
        'myParaMeter.ParameterValue = cmbPacket.Text
        myParaMeter.ParameterValue = ProductPacket(1)
        'myParaMeter.ParameterType=
        ParasArrayList.Add(myParaMeter)

        myParaMeter = New ReportParameters
        myParaMeter.ParameterName = "pIsUplod"
        If Me.rdoBatch.Checked Then
            myParaMeter.ParameterValue = "No"
        Else
            myParaMeter.ParameterValue = "Yes"
        End If
        'myParaMeter.ParameterType=
        ParasArrayList.Add(myParaMeter)


        myParaMeter = New ReportParameters
        myParaMeter.ParameterName = "pRegion"

        myParaMeter.ParameterValue = cmbRegions.Text

        'myParaMeter.ParameterType=
        ParasArrayList.Add(myParaMeter)

        myParaMeter = New ReportParameters
        myParaMeter.ParameterName = "pDateFrom"
        myParaMeter.ParameterValue = Me.dtFrom.Value.Date
        'myParaMeter.ParameterType=
        ParasArrayList.Add(myParaMeter)

        myParaMeter = New ReportParameters
        myParaMeter.ParameterName = "pDateTo"
        myParaMeter.ParameterValue = Me.dtTo.Value.Date
        'myParaMeter.ParameterType=
        ParasArrayList.Add(myParaMeter)

        Return ParasArrayList
    End Function
    Private Sub ShowReort(ByVal sReportType As String, ByVal PacketSize As Integer)
        '' ''If Me.rdoBatch.Checked Then
        '' ''    GenrateReport("N", cmbProduct.SelectedValue, PacketSize, dtFrom.Value.Date, dtTo.Value.Date)
        '' ''Else
        '' ''    GenrateReport("Y", cmbProduct.SelectedValue, PacketSize, dtFrom.Value.Date, dtTo.Value.Date)
        '' ''End If

        Dim ProductPacket As String()
        Dim ProPack As String
        ProPack = cmbProduct.SelectedValue
        ProductPacket = ProPack.Split(" ")

        If Me.rdoBatch.Checked Then
            GenrateReport("N", ProductPacket(0), PacketSize, dtFrom.Value.Date, dtTo.Value.Date)
        Else
            GenrateReport("Y", ProductPacket(0), PacketSize, dtFrom.Value.Date, dtTo.Value.Date)
        End If


        Dim viewReport As New Form
        If Me.rdoBatch.Checked Then
            Common.PrintPageSize.IsUploaded = False
        Else
            Common.PrintPageSize.IsUploaded = False
        End If
        Dim ParameterArrayList As New ArrayList
        ParameterArrayList = SetParameter()
        Dim frm As New frmViewReport(sReportType, ParameterArrayList, sUserCode)
        'Dim frm As New frmViewReport(sReportType)
        frm.Show()
        Me.Hide()
    End Sub
    Private Sub ShowReort(ByVal sReportType As String, ByVal PacketSize As Integer, ByVal Region As String)
        If Me.rdoBatch.Checked Then
            GenrateReport("N", cmbProduct.SelectedValue, PacketSize, Region, dtFrom.Value.Date, dtTo.Value.Date)
        Else
            GenrateReport("Y", cmbProduct.SelectedValue, PacketSize, Region, dtFrom.Value.Date, dtTo.Value.Date)
        End If
        Dim viewReport As New Form
        If Me.rdoBatch.Checked Then
            Common.PrintPageSize.IsUploaded = False
        Else
            Common.PrintPageSize.IsUploaded = False
        End If
        Dim ParameterArrayList As New ArrayList
        ParameterArrayList = SetParameter()
        Dim frm As New frmViewReport(sReportType, ParameterArrayList, sUserCode)
        'Dim frm As New frmViewReport(sReportType)
        frm.Show()
        Me.Hide()
    End Sub
    Public Function FindReportData(ByVal cmdText As String) As Boolean
        Dim dsSerials As DataSet
        dsSerials = ExecuteQuery(cmdText, Execute.DataSet)
        Dim TotalRecord As Integer = dsSerials.Tables(0).Rows.Count
        If TotalRecord > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim bRecrdsFound As Boolean = False
        Dim sReportCri As String = sReportCriteria

        Try
            If Me.cmbProduct.SelectedValue <> Nothing Then
                'If cmbPacket.Text.Length > 0 AndAlso IsNumeric(cmbPacket.Text) AndAlso cmbPacket.Text > 0 Then
                If cmbRegions.Text.Length > 0 And cmbRegions.Text <> Nothing Then

                    Dim ProductPacket As String()
                    Dim ProPack As String
                    ProPack = cmbProduct.SelectedValue
                    ProductPacket = ProPack.Split(" ")

                    Dim PacketSize As Integer = ProductPacket(1)
                    Dim cmdText As String = System.String.Empty
                    If Me.rdoBatch.Checked Then
                        cmdText = "SELECT Serials,ProductCode From Serials WHERE IsUploaded='N'"
                    Else
                        cmdText = "SELECT Serials,ProductCode From Serials WHERE IsUploaded='Y'"
                    End If


                    


                    '' ''cmdText += " And ProductCode='" & Me.cmbProduct.SelectedValue & "'  And PacketSize=" & PacketSize
                    '' ''cmdText += " And Region='" & Me.cmbRegions.Text & "' "
                    '' ''cmdText += "And InsDate Between (#" & Format(dtFrom.Value, "MM/dd/yyyy") & "#) And (#" & Format(dtTo.Value, "MM/dd/yyyy") & "#);"


                    cmdText += " And ProductCode='" & ProductPacket(0) & "'  And PacketSize=" & PacketSize
                    cmdText += " And Region='" & Me.cmbRegions.Text & "' "
                    cmdText += "And InsDate Between (#" & Format(dtFrom.Value, "MM/dd/yyyy") & "#) And (#" & Format(dtTo.Value, "MM/dd/yyyy") & "#);"



                    'cmdText += "And InsDate Between (#" & dtFrom.Value & "#) And (#" & dtTo.Value & "#);"
                    'cmdText += " And day(InsDate) Between (" & dtFrom.Value.Day & ") And (" & dtTo.Value.Day & ")"
                    'cmdText += " And month(InsDate) Between (" & dtFrom.Value.Month & ") And (" & dtTo.Value.Month & ")"
                    'cmdText += " And year(InsDate) Between (" & dtFrom.Value.Year & ") And (" & dtTo.Value.Year & ");"
                    bRecrdsFound = FindReportData(cmdText)

                    If bRecrdsFound = True Then
                        ' ''Select Case sReportCri
                        ' ''    Case "Serial"
                        ' ''        ShowReort("Serial", PacketSize)
                        ' ''    Case "Multi"
                        ' ''        ShowReort("Multi", PacketSize)
                        ' ''    Case "Text"
                        ' ''        GenerateTextFile(cmdText)
                        ' ''End Select
                        Select Case sReportCri
                            Case "Serial"
                                ShowReort("Serial", PacketSize)
                            Case "Multi"
                                ShowReort("Multi", PacketSize)
                            Case "Text"
                                GenerateTextFile(cmdText)
                        End Select
                    Else
                        MessageBox.Show("Security Code not found according to given criteria...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Please Select Region ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'Else
                '    MessageBox.Show("Please Select Packet  Size...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            Else
                MessageBox.Show("Please Select Product ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'Catch ex As Exception
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
        'Try
        '    If Me.cmbProduct.SelectedValue <> Nothing Then
        '        If cmbPacket.Text.Length > 0 AndAlso IsNumeric(cmbPacket.Text) AndAlso cmbPacket.Text > 0 Then
        '            Dim PacketSize As Integer = cmbPacket.Text
        '            Dim cmdText As String = System.String.Empty
        '            If Me.rdoBatch.Checked Then
        '                cmdText = "SELECT Serials From Serials WHERE IsUploaded='N'"
        '            Else
        '                cmdText = "SELECT Serials From Serials WHERE IsUploaded='Y'"
        '            End If
        '            cmdText += " And ProductCode='" & Me.cmbProduct.SelectedValue & "'  And PacketSize=" & PacketSize
        '            cmdText += " And day(InsDate) Between (" & dtFrom.Value.Day & ") And (" & dtFrom.Value.Day & ")"
        '            cmdText += " And month(InsDate) Between (" & dtFrom.Value.Month & ") And (" & dtFrom.Value.Month & ")"
        '            cmdText += " And year(InsDate) Between (" & dtFrom.Value.Year & ") And (" & dtFrom.Value.Year & ");"
        '            bRecrdsFound = FindReportData(cmdText)

        '            If bRecrdsFound = True Then
        '                Select Case sReportCri
        '                    Case "Serial"
        '                        ShowReort("Serial", PacketSize)
        '                    Case "Multi"
        '                        ShowReort("Multi", PacketSize)
        '                    Case "Text"
        '                        GenerateTextFile(cmdText)
        '                End Select
        '            Else
        '                MessageBox.Show("Security Code not found according to given criteria...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            End If
        '        Else
        '            MessageBox.Show("Please Select Packet  Size...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If
        '    Else
        '        MessageBox.Show("Please Select Product ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub GenerateTextFile(ByVal cmdText As String)
        Dim bFileCreate As Boolean = False
        Try
            Dim dsText As New DataSet
            dsText = ExecuteQuery(cmdText, Execute.DataSet)
            Dim dtText As New DataTable
            dtText = dsText.Tables(0)
            bFileCreate = PapulateTextFile(dtText)
            If bFileCreate = True Then
                MessageBox.Show("Text file of Security Code Generated  ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Text file of Security Code not Generated  ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'Catch ex As Exception
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
    'Private Sub GenerateTextFile()
    '    Dim cmdText As String = System.String.Empty
    '    Dim bFileCreate As Boolean = False
    '    Try
    '        If Me.cmbProduct.SelectedValue <> Nothing Then
    '            If cmbPacket.Text.Length > 0 AndAlso IsNumeric(cmbPacket.Text) AndAlso cmbPacket.Text > 0 Then
    '                Dim PacketSize As Integer = cmbPacket.Text
    '                If Me.rdoBatch.Checked Then
    '                    cmdText = "SELECT Serials From Serials WHERE IsUploaded='N'"
    '                Else
    '                    cmdText = "SELECT Serials From Serials WHERE IsUploaded='Y'"
    '                End If
    '                cmdText += " And ProductCode='" & Me.cmbProduct.SelectedValue & "'  And PacketSize=" & PacketSize
    '                cmdText += " And day(InsDate) Between (" & dtFrom.Value.Day & ") And (" & dtFrom.Value.Day & ")"
    '                cmdText += " And month(InsDate) Between (" & dtFrom.Value.Month & ") And (" & dtFrom.Value.Month & ")"
    '                cmdText += " And year(InsDate) Between (" & dtFrom.Value.Year & ") And (" & dtFrom.Value.Year & ");"
    '                Dim dsText As New DataSet
    '                dsText = ExecuteQuery(cmdText, Execute.DataSet)
    '                Dim dtText As New DataTable
    '                dtText = dsText.Tables(0)
    '                If dtText.Rows.Count > 0 Then
    '                    bFileCreate = PapulateTextFile(dtText)
    '                    If bFileCreate = True Then
    '                        MessageBox.Show("Text file of Serials Generated  ...", "Batch System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Else
    '                        MessageBox.Show("Text file of Serials not Generated  ...", "Batch System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If
    '                Else
    '                    cmdText = "Select Count(*) from Serials where "
    '                    cmdText += " ProductCode='" & Me.cmbProduct.SelectedValue & "'  And PacketSize=" & PacketSize
    '                    Dim TotalRecod As Integer = ExecuteQuery(cmdText, Execute.Scalar)
    '                    If TotalRecod > 0 Then
    '                        MessageBox.Show("Serials not found according to given criteria...", "Batch System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Else
    '                        MessageBox.Show("Please Generate Serials First...", "Batch System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If
    '                End If
    '            Else
    '                MessageBox.Show("Please Select Packet  Size...", "Batch System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        Else
    '            MessageBox.Show("Please Select Product ...", "Batch System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Private Sub SetCombos()
        SetProductCombo()
        ' ''If cmbProduct.Items.Count > 0 Then
        ' ''    cmbProduct.SelectedIndex = 0
        ' ''    Dim ProductCode As String = cmbProduct.SelectedValue
        ' ''    SetPacketsCombo(ProductCode)
        ' ''    If cmbPacket.Items.Count > 0 Then
        ' ''        Dim PacketSize As Integer = cmbPacket.Text
        ' ''        SetComboRegions(ProductCode, PacketSize)
        ' ''    End If
        ' ''End If
        If cmbProduct.Items.Count > 0 Then
            Dim ProductPacket As String()
            Dim ProPack As String
            ProPack = cmbProduct.SelectedValue
            ProductPacket = ProPack.Split(" ")
            SetComboRegions(ProductPacket(0).ToString, ProductPacket(1).ToString)
        End If
    End Sub
    Private Sub SetComboRegions(ByVal ProductCode As String, ByVal PacketSize As Integer)
        Dim dtRegions As DataTable
        dtRegions = Common.GetRegions(ProductCode, PacketSize)
        With Me.cmbRegions
            .Text = String.Empty
            .DisplayMember = "RegionCode"
            .ValueMember = "ID"
            .DataSource = dtRegions
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
    Private Sub SetProductCombo()
        Dim dtProducts As DataTable
        'dtProducts = Common.GetProducts()
        dtProducts = Common.GetProductsPackets()
        With Me.cmbProduct
            .Text = String.Empty
            .DisplayMember = "ProductName"
            .ValueMember = "ProductCode"
            .DataSource = dtProducts
            .Refresh()
        End With
    End Sub
    Private Sub frmReportCriteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        '    Dim ico As New System.Drawing.Icon(Application.StartupPath & "\TBS_small3.ico")
        '    Me.Icon = ico
        'Catch ex As Exception

        'End Try
        SetCombos()
        Dim sReportCri As String = sReportCriteria
        Select Case sReportCri
            Case "Serial"
                btnReport.Text = "Show"
            Case "Multi"
                btnReport.Text = "Show"
            Case "Text"
                btnReport.Text = "Generate Text"
        End Select
    End Sub
    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

        If Not SaveFileDialog1.FileName.EndsWith(".txt") Then
            MsgBox("File " & SaveFileDialog1.FileName & _
                " is not a .txt file", MsgBoxStyle.Exclamation, "Invalid File Type")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProduct.SelectedIndexChanged
        ''If Me.cmbProduct.SelectedValue <> Nothing Then
        ''    Dim sProCode As String = cmbProduct.SelectedValue
        ''    SetPacketsCombo(sProCode)
        ''    If Me.cmbPacket.SelectedValue <> Nothing Then
        ''        Dim iPacketSize As Integer = cmbPacket.Text
        ''        SetComboRegions(sProCode, iPacketSize)
        ''    End If
        ''End If
        If Me.cmbProduct.SelectedValue <> Nothing Then
            Dim ProductPacket As String()
            Dim ProPack As String
            ProPack = cmbProduct.SelectedValue
            ProductPacket = ProPack.Split(" ")
            SetComboRegions(ProductPacket(0).ToString, ProductPacket(1).ToString)
        End If
    End Sub

    Private Sub cmbPacket_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPacket.SelectedIndexChanged
        Try
            If Me.cmbPacket.SelectedValue <> Nothing Then
                SetComboRegions(cmbProduct.SelectedValue, cmbPacket.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbRegions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegions.SelectedIndexChanged

    End Sub

    Private Sub cmbRegions_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbRegions.KeyPress
        e.Handled = True
    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub
End Class