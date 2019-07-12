Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing.Icon
Imports System.IO
Public Class frmViewReport
    Dim sUserCode As String
    Public aParameterList As ArrayList

    Public sReportName As String
    'Public Property ReportParameter()
    Public Property ParameterList() As ArrayList
        Get
            Return aParameterList
        End Get
        Set(ByVal value As ArrayList)
            aParameterList = value
        End Set
    End Property
    Public Property ReportName() As String
        Get
            Return sReportName
        End Get
        Set(ByVal value As String)
            sReportName = value
        End Set
    End Property
    Public Sub New(ByVal value As String, ByVal usercode As String)
        sUserCode = usercode
        sReportName = value
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal value As String, ByVal ParameterList As ArrayList, ByVal usercode As String)
        sUserCode = usercode
        sReportName = value
        aParameterList = ParameterList
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmViewReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim fBatch As Form
        'fBatch = frmBatch
        'fBatch.Show()
        'Dim fSerials As Form
        ''fSerials = frmSerials
        'fSerials = frmMain
        'fSerials.Show()


        '' ''Dim frm As New frmMain(sUserCode)
        '' ''frm.Show()
    End Sub

    Private Sub frmViewReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        '    '    Dim ico As New System.Drawing.Icon(Application.StartupPath & "\TBS_small3.ico")
        '    '    Me.Icon = ico
        '    'Catch ex As Exception

        '    'End Try
        'TODO: This line of code loads data into the 'ReportDataSet.SerialReport' table. You can move, or remove it, as needed.
        Me.SerialReportTableAdapter.Fill(Me.ReportDataSet.SerialReport)
        'Me.ViewReport(Common.PrintPageSize.Report)
        Dim rptname As String = sReportName
        Dim rpt As New ReportDocument
        Select Case rptname
            Case "Serial"
                rpt = New rptSerial
            Case "Multi"
                rpt = New rptBatch
        End Select
        'Dim rpt As New BatchSystem.rptSerialSingle
        'Dim rpt As New BatchSystem.rptBatch
        rpt.SetDataSource(Me.ReportDataSet)

        If aParameterList IsNot Nothing Then
            Dim obj As Object
            For Each mReportParameters As ReportParameters In aParameterList
                obj = mReportParameters.sParameterType
                rpt.SetParameterValue(mReportParameters.ParameterName, mReportParameters.ParameterValue)
            Next
        End If
        'rpt.SetParameterValue("pProductCode", "Love")
        'rpt.SetParameterValue("pPacketSize", "10")
        'rpt.SetParameterValue("pIsUplod", "No")
        'rpt.SetParameterValue("pDateFrom", "04/01/2008")
        ''rpt.SetParameterValue("pDateFrom", CType("04/01/2008", Date))
        'rpt.SetParameterValue("pDateTo", CType("04/01/2008", Date))
        Me.rptViewer.ReportSource = rpt

    End Sub


    Friend Function ViewReport(ByVal sReportName As String, _
                       Optional ByVal sSelectionFormula As String = "", _
                       Optional ByVal param As String = "") As Boolean
        'Declaring variablesables
        Dim intCounter As Integer
        Dim intCounter1 As Integer

        'Crystal Report's report document object
        Dim objReport As New _
                    CrystalDecisions.CrystalReports.Engine.ReportDocument

        'object of table Log on info of Crystal report
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

        'Parameter value object of crystal report 
        ' parameters used for adding the value to parameter.
        Dim paraValue As New CrystalDecisions.Shared.ParameterDiscreteValue

        'Current parameter value object(collection) of crystal report parameters.
        Dim currValue As CrystalDecisions.Shared.ParameterValues

        'Sub report object of crystal report.
        Dim mySubReportObject As _
                  CrystalDecisions.CrystalReports.Engine.SubreportObject

        'Sub report document of crystal report.
        Dim mySubRepDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        Dim strParValPair() As String
        Dim strVal() As String
        Dim index As Integer

        Try


            'Load the report
            'objReport.PrintOptions.PaperSize
            'PrintOptions.PageContentHeight()
            objReport.Load(sReportName)

            'Check if there are parameters or not in report.
            intCounter = objReport.DataDefinition.ParameterFields.Count

            'As parameter fields collection also picks the selection 
            ' formula which is not the parametermeter
            ' so if total parameter count is 1 then we check whether 
            ' its a parameter or selection formula.

            If intCounter = 1 Then
                If InStr(objReport.DataDefinition.ParameterFields(0).ParameterFieldName, ".", CompareMethod.Text) > 0 Then
                    intCounter = 0
                End If
            End If

            'If there are parameters in report and 
            'user has passed them then split the 
            'parameter string and Apply the values 
            'to there concurent parameters.

            If intCounter > 0 And Trim(param) <> "" Then
                strParValPair = param.Split("&")

                For index = 0 To UBound(strParValPair)
                    If InStr(strParValPair(index), "=") > 0 Then
                        strVal = strParValPair(index).Split("=")
                        paraValue.Value = strVal(1)
                        currValue = _
                         objReport.DataDefinition.ParameterFields(strVal(0)).CurrentValues
                        currValue.Add(paraValue)
                        objReport.DataDefinition.ParameterFields(strVal(0)).ApplyCurrentValues(currValue)
                    End If
                Next
            End If
            'Set the connection information to ConInfo object so that we can apply the 
            ' connection information on each table in the reporteport

            'ConInfo.ConnectionInfo.UserID = <User Name>
            'ConInfo.ConnectionInfo.Password = <Password>
            'ConInfo.ConnectionInfo.ServerName = <Server Name>
            'ConInfo.ConnectionInfo.DatabaseName = <Database Name>

            For intCounter = 0 To objReport.Database.Tables.Count - 1
                objReport.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
            Next

            ' Loop through each section on the report then look 
            ' through each object in the section
            ' if the object is a subreport, then apply logon info 
            ' on each table of that sub report

            For index = 0 To objReport.ReportDefinition.Sections.Count - 1
                For intCounter = 0 To _
                      objReport.ReportDefinition.Sections(index).ReportObjects.Count - 1
                    With objReport.ReportDefinition.Sections(index)
                        If .ReportObjects(intCounter).Kind = _
                           CrystalDecisions.Shared.ReportObjectKind.SubreportObject Then
                            mySubReportObject = CType(.ReportObjects(intCounter), _
                            CrystalDecisions.CrystalReports.Engine.SubreportObject)
                            mySubRepDoc = _
                             mySubReportObject.OpenSubreport(mySubReportObject.SubreportName)
                            For intCounter1 = 0 To mySubRepDoc.Database.Tables.Count - 1
                                mySubRepDoc.Database.Tables(intCounter1).ApplyLogOnInfo(ConInfo)
                                mySubRepDoc.Database.Tables(intCounter1).ApplyLogOnInfo(ConInfo)
                            Next
                        End If
                    End With
                Next
            Next
            'If there is a selection formula passed to this function then use that
            If sSelectionFormula.Length > 0 Then
                objReport.RecordSelectionFormula = sSelectionFormula
            End If
            'Re setting control 
            rptViewer.ReportSource = Nothing

            'Set the current report object to report.
            rptViewer.ReportSource = objReport

            'Show the report
            rptViewer.Show()
            Return True
            'Catch ex As Exception
            '    MsgBox(ex.Message)
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
    End Function


End Class