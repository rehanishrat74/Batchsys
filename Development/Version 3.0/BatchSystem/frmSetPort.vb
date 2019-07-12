Imports InfiniImageVB
Imports System.Xml
Imports Microsoft.Win32
Imports System.IO
Public Class frmSetPort
    Dim bTrace As Boolean = True
    Private Sub frmSetPort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckBox1.Checked = False
        cmbPort.Items.Add("COM1")
        cmbPort.Items.Add("COM2")
        cmbPort.Items.Add("COM3")
        cmbPort.Items.Add("COM4")
        'Seting default values
        cmbPort.Text = "COM1"
        'default values for serial info structure
        'mySerialInfo.bDatabits = 8
        'mySerialInfo.bParity = NOPARITY
        'mySerialInfo.bFlowCtrl = NO_CONTROL
        ''seting to default value
        'If mySerialInfo.nBaudRate = 0 Then
        '    mySerialInfo.nBaudRate = 38400
        'End If
        'assigning baud rate
        ' cboSpeed.Text = mySerialInfo.nBaudRate
        cmbSpeed.Items.Add("9600")
        cmbSpeed.Items.Add("19200")
        cmbSpeed.Items.Add("38400")
        cmbSpeed.Text = 38400
        'mySerialInfo.bStopbits = ONESTOPBI
        '''' call function for get s/w version 
        ''TestFunction()
        ''GetDllVersion()
    End Sub
    Public Sub TestFunction()
        Try
            Dim sResult As String
            Dim obj As New InfiniImageVB.PrinterImaje
            
            'sResult = obj.TestNisar(Application.StartupPath())
        Catch ex As Exception
            btnOk.Enabled = True
            btnCancel.Enabled = True
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    'create it if it doesn't
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net : , GetDllVersion() , frmSetPort" & DateTime.Now & " , " & ex.Message)
                    sw.WriteLine("and source is : " & ex.StackTrace)
                    sw.Close()
                End Using
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Public Sub GetDllVersion()
        Try
            Dim sResult As String
            Dim sw1 As StreamWriter
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net : GetDllVersion() ")

            sw1.WriteLine(".Net : GetDllVersion() Create object of  InfiniImageVB.PrinterImaje ")
            Dim obj As New InfiniImageVB.PrinterImaje
            sw1.WriteLine(".Net : GetDllVersion() :Obj is created")
            sw1.WriteLine(".Net : GetDllVersion() :Calling the function AutoDetectPrinter(Application.StartupPath()) of InfiniImageVB.dll")
            sw1.Close()
            sResult = obj.GetDLLVersion(Application.StartupPath())
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net : GetDllVersion() :Calling complete and return the value" & sResult)
            sw1.WriteLine(".Net : GetDllVersion() : Completed")

            sw1.Close()

        Catch ex As Exception
            btnOk.Enabled = True
            btnCancel.Enabled = True
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    'create it if it doesn't
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net : , GetDllVersion() , frmSetPort" & DateTime.Now & " , " & ex.Message)
                    sw.WriteLine("and source is : " & ex.StackTrace)
                    sw.Close()
                End Using
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            Dim sw1 As StreamWriter
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net : PortSeting ")
            sw1.Close()
            btnOk.Enabled = False
            btnCancel.Enabled = False
            GroupBox2.Enabled = False
            CheckBox1.Enabled = False
            cmbPort.Enabled = False
            cmbSpeed.Enabled = False
            If (CheckBox1.Checked = False) Then
                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                sw1.WriteLine(".Net btnOk_Click  : AutoSerachPrinter Check box is unched")
                Dim szSWVersionMajor As String = " "
                Dim strRetVal As String = System.String.Empty
                Dim lReturnValue As Long
                Dim nPort As Integer
                Dim nBaudRate As Long
                Select Case cmbPort.Text
                    Case "COM1"
                        nPort = ConstEnum.COM1
                    Case "COM2"
                        nPort = ConstEnum.COM2
                    Case "COM3"
                        nPort = ConstEnum.COM3
                    Case "COM4"
                        nPort = ConstEnum.COM4
                End Select
                sw1.WriteLine(".Net btnOk_Click : Com value is set to : " & nPort.ToString())
                nBaudRate = Val(cmbSpeed.Text)
                sw1.WriteLine(".Net btnOk_Click : BaudRate value is set to : " & nBaudRate.ToString())
                sw1.WriteLine(".Net btnOk_Click : calling the ConfigureAndStartPort function of .net")
                sw1.Close()
                sw1.Dispose()
                strRetVal = ConfigureAndStartPort(nPort, nBaudRate, szSWVersionMajor)

                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                sw1.WriteLine(".Net btnOk_Click : return the result from ConfigureAndStartPort is : " + strRetVal)
                sw1.Close()
                If strRetVal <> "" Then
                    sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                    sw1.WriteLine(".Net btnOk_Click :Tehe return is not null")
                    sw1.Close()
                    lReturnValue = CType(strRetVal, Long)
                    lPrinterID = lReturnValue
                    If lReturnValue < 0 Then
                        sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                        sw1.WriteLine(".Net: btnOk_Click ,the return value is less then 0")
                        Dim objmodFunctions As New modFunctions
                        objmodFunctions.ShowFailureMessage(lReturnValue)
                        sw1.WriteLine(".Net btnOk_Click : Show the failuremessage")
                        sw1.WriteLine(".Net btnOk_Click : The process is completed")
                        btnOk.Enabled = True
                        btnCancel.Enabled = True
                        CheckBox1.Enabled = True
                        cmbPort.Enabled = True
                        cmbSpeed.Enabled = True
                        sw1.Close()
                    Else
                        sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                        sw1.WriteLine(".Net : return value is less grather then 0")
                        MessageBox.Show("Start Port Success", "PrintImaje", MessageBoxButtons.OK)
                        Dim f As frmMain = CType(Me.MdiParent, frmMain)
                        sw1.WriteLine(".Net : disable and enable the menu items ")
                        f.mnuPrinterSetPort.Enabled = False
                        f.mnuPrinterClosePort.Enabled = True
                        f.mnuPrinterCodePrint.Enabled = True
                        f.mnuPrinterStatus.Enabled = True
                        f.mnuPrinterStartStopMachine.Enabled = True
                        Port = nPort
                        BaudRate = nBaudRate
                        Parity = ConstEnum.NOPARITY
                        Stopbits = ConstEnum.ONESTOPBIT
                        PrinterType = 5 'ConstEnum.S7PRINTERID
                        Databits = 8
                        FlowCtrl = ConstEnum.NO_CONTROL
                        SWVersionMajor = szSWVersionMajor
                        sw1.Close()
                    End If
                End If
            Else
                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                sw1.WriteLine(".Net : The autoserachPrintercheckbox is true")
                sw1.Close()
                If dgvPrinter.SelectedRows.Count > 0 Then
                    sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                    sw1.WriteLine(".Net : the datagrid row selection is true")
                    sw1.WriteLine(".Net : Calling the function CloseOtherPorts() to close all port")
                    sw1.Close()
                    CloseOtherPorts()
                    sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                    sw1.WriteLine(".Net : return from the function CloseOtherPorts() ")
                    ''MessageBox.Show("The value of row is : " + dgvPrinter.Rows(dgvPrinter.SelectedRows(0).Index).Cells(0).Value.ToString())
                    lPrinterID = dgvPrinter.Rows(dgvPrinter.SelectedRows(0).Index).Cells(0).Value
                    sw1.WriteLine(".Net : set the global printer id is " + dgvPrinter.Rows(dgvPrinter.SelectedRows(0).Index).Cells(0).Value.ToString())
                    MessageBox.Show("Start Port Success", "PrintImaje", MessageBoxButtons.OK)
                    sw1.WriteLine(".Net : Begin seting the menu items enable and disable ")
                    Dim f As frmMain = CType(Me.MdiParent, frmMain)
                    f.mnuPrinterSetPort.Enabled = False
                    f.mnuPrinterClosePort.Enabled = True
                    f.mnuPrinterCodePrint.Enabled = True
                    f.mnuPrinterStatus.Enabled = True
                    f.mnuPrinterStartStopMachine.Enabled = True
                    sw1.WriteLine(".Net : end seting the menu items enable and disable ")
                    sw1.Close()
                    If dgvPrinter.Rows(dgvPrinter.SelectedRows(0).Index).Cells(2).Value <> "Undefined" Then
                        Port = dgvPrinter.Rows(dgvPrinter.SelectedRows(0).Index).Cells(2).Value
                        BaudRate = dgvPrinter.Rows(dgvPrinter.SelectedRows(0).Index).Cells(3).Value
                    End If
                    Parity = ConstEnum.NOPARITY
                    Stopbits = ConstEnum.ONESTOPBIT
                    Databits = 8
                    FlowCtrl = ConstEnum.NO_CONTROL
                    sw1.Close()
                Else
                    sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                    sw1.WriteLine(".Net : the datagrid row selection is not true")
                    sw1.WriteLine(".Net : show message for select row")
                    MessageBox.Show("Select Printer first...")
                    btnOk.Enabled = True
                    btnCancel.Enabled = True
                    CheckBox1.Enabled = True
                    sw1.Close()
                End If
            End If
            btnCancel.Enabled = True
        Catch ex As Exception
            btnOk.Enabled = True
            btnCancel.Enabled = True
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    'create it if it doesn't
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net : , btnOk_Click , frmSetPort" & DateTime.Now & " , " & ex.Message)
                    sw.WriteLine("and source is : " & ex.StackTrace)
                    sw.Close()
                End Using
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try

    End Sub
    Public Sub CloseOtherPorts()
        Try
            Dim sw1 As StreamWriter
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine("  ")
            sw1.WriteLine(".Net : CloseOtherPorts() ")
            sw1.WriteLine(".Net : CloseOtherPorts() Create object for InfiniImageVB.PrinterImaje ")
            Dim objPrintImaje As New InfiniImageVB.PrinterImaje
            sw1.WriteLine(".Net : CloseOtherPorts() Object Created ")
            sw1.Close()
            Dim iResult As String

            Dim iTotalRows As Integer = dgvPrinter.Rows.Count - 1
            Dim iSelIndex As Long = dgvPrinter.SelectedRows(0).Cells(0).Value
            Dim i As Integer = 0

            For i = 0 To iTotalRows
                If dgvPrinter.Rows(i).Cells(0).Value <> iSelIndex Then
                    sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                    sw1.WriteLine(".Net : CloseOtherPorts() Call the function of objPrintImaje.ClosePort( " & dgvPrinter.Rows(i).Cells(0).Value & " , " & Application.StartupPath() & ") ")
                    iResult = objPrintImaje.ClosePort(dgvPrinter.Rows(i).Cells(0).Value, Application.StartupPath())
                    sw1.WriteLine(".Net : CloseOtherPorts() Retturn back and result is  " & iResult)
                    sw1.Close()
                    Me.dgvPrinter.Rows.RemoveAt(i)
                    i = i - 1
                    iTotalRows = iTotalRows - 1
                    If dgvPrinter.Rows.Count - 1 = 0 Then
                        Exit For
                    End If

                End If
            Next
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net : CloseOtherPorts() The process completed")
            sw1.Close()
        Catch ex As Exception
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net :  , CloseOtherPorts , frmSetPort " & DateTime.Now & " , " & ex.Message)
                    sw.WriteLine(ex.StackTrace)
                    sw.Close()
                End Using
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Public Sub AutoSearchPrinterVB()
        Try
            Dim sResult As String
            Dim obj As New InfiniImageVB.PrinterImaje
            sResult = obj.AutoDetectPrinter(Application.StartupPath())
            MessageBox.Show("Printer(s) detect : " + sResult)
            Dim i As Integer = Convert.ToInt16(sResult)
            lsbIds.Items.Clear()

            If i > 0 Then
                ' ''Dim xmldoc As New XmlDocument
                ' ''Dim sFileName As String = Application.StartupPath() + "\PrinterInfo.TXT"
                ' '' ''Dim sFileName As String = "c:\PrinterInfo.TXT"
                ' ''xmldoc.Load(sFileName)

                ' ''Dim book As XmlNode
                ' ''Dim nodeList As XmlNodeList
                ' ''Dim root As XmlNode = xmldoc.DocumentElement

                ' ''nodeList = xmldoc.SelectNodes("//p")

                ' ''lsbIds.Items.Clear()

                ' ''For Each book In nodeList
                ' ''    lsbIds.Items.Add(book.InnerText)
                ' ''Next

                ' ''Dim xmldoc As New XmlDocument
                ' '' ''Dim sFileName As String = Application.StartupPath() + "\PrinterInfo.TXT"
                ' ''Dim sFileName As String = "c:\PrinterInfo.TXT"
                ' ''xmldoc.Load(sFileName)

                ' ''Dim sPrintInfo As String = xmldoc.SelectSingleNode("//printerinfo").InnerText
                ' '' ''sPrintInfo = sPrintInfo.Replace("#", "")
                ' ''sPrintInfo = sPrintInfo.Substring(0, sPrintInfo.Length - 2)
                ' ''Dim arPrinterInfo() As String = sPrintInfo.Split("$")
                ' ''Dim arComInjfo() As String
                ' ''Dim j As Integer
                ' ''For j = 0 To arPrinterInfo.Length - 1
                ' ''    arComInjfo = arPrinterInfo(j).Split("|")
                ' ''    lsbIds.Items.Add("Printer : " + arComInjfo(0) + " Port : " + arComInjfo(arComInjfo.Length - 1) + " Speed : " + arComInjfo(arComInjfo.Length - 2))
                ' ''Next
            Else
                lsbIds.Items.Clear()
            End If

            ' '' ''Dim xmldoc As New XmlDocument
            ' '' ''Dim sFileName As String = Application.StartupPath() + "\PrinterInfo.TXT"
            ' '' '' ''Dim sFileName As String = "c:\PrinterInfo.TXT"
            ' '' ''xmldoc.Load(sFileName)

            ' '' ''Dim book As XmlNode
            ' '' ''Dim nodeList As XmlNodeList
            ' '' ''Dim root As XmlNode = xmldoc.DocumentElement

            ' '' ''nodeList = xmldoc.SelectNodes("//p")

            ' '' ''lsbIds.Items.Clear()

            ' '' ''For Each book In nodeList
            ' '' ''    lsbIds.Items.Add(book.InnerText)
            ' '' ''Next

            Dim xmldoc As New XmlDocument
            Dim sFileName As String = Application.StartupPath() + "\PrinterInfo.TXT"
            ''Dim sFileName As String = "c:\PrinterInfo.TXT"
            xmldoc.Load(sFileName)

            Dim sPrintInfo As String = xmldoc.SelectSingleNode("//printerinfo").InnerText
            ''sPrintInfo = sPrintInfo.Replace("#", "")
            sPrintInfo = sPrintInfo.Substring(0, sPrintInfo.Length - 2)
            Dim arPrinterInfo() As String = sPrintInfo.Split("$")
            Dim arComInjfo() As String
            Dim j As Integer
            For j = 0 To arPrinterInfo.Length - 1
                arComInjfo = arPrinterInfo(j).Split("|")
                lsbIds.Items.Add("Printer : " + arComInjfo(0) + " Port : " + arComInjfo(arComInjfo.Length - 1) + " Speed : " + arComInjfo(arComInjfo.Length - 2))
            Next

        Catch ex As Exception
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net : , " & DateTime.Now & " , " & ex.Message)
                    sw.WriteLine("and source is : " & ex.StackTrace)
                    sw.Close()
                End Using
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Public Sub AutoSearchPrinter()
        Try
            Dim sw1 As StreamWriter
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net : AutoSearchPrinter() : enter in the AutoSearchPrinter() funcion ")
            Dim sResult As String
            sw1.WriteLine(".Net : AutoSearchPrinter() : Creating the InfiniImageVB.PrinterImaje obj ")
            Dim obj As New InfiniImageVB.PrinterImaje
            sw1.WriteLine(".Net : AutoSearchPrinter() :Obj is created")
            sw1.WriteLine(".Net : AutoSearchPrinter() :Calling the function AutoDetectPrinter( " & Application.StartupPath() & ") of InfiniImageVB.dll")
            sw1.Close()
            sResult = obj.AutoDetectPrinter(Application.StartupPath())
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net : AutoSearchPrinter() : out from  the function AutoDetectPrinter(Application.StartupPath()) of InfiniImageVB.dll")
            sw1.WriteLine(".Net : AutoSearchPrinter() : Return the result from function AutoDetectPrinter(Application.StartupPath()) of InfiniImageVB.dll is : " + sResult)
            sw1.WriteLine(".Net : AutoSearchPrinter() : convert the result into interger value")
            Dim i As Integer = Convert.ToInt16(sResult)
            ''i = 5
            sw1.WriteLine(".Net : AutoSearchPrinter() : conversion is completed")
            lsbIds.Items.Clear()
            sw1.WriteLine(".Net : AutoSearchPrinter() :Check the value which is retruned")
            If i > 0 Then
                sw1.WriteLine(".Net : AutoSearchPrinter() :The returned value grater then 0")
                sw1.WriteLine(".Net : AutoSearchPrinter() : Clear all row from gridview")
                dgvPrinter.Rows.Clear()
                sw1.WriteLine(".Net : AutoSearchPrinter() : Clearation is competed")
                Dim xmldoc As New XmlDocument
                sw1.WriteLine(".Net : AutoSearchPrinter() : created XmlDcoument")
                Dim sFileName As String = Application.StartupPath() + "\PrinterInfo.TXT"
                ''Dim sFileName As String = "c:\PrinterInfo.TXT"
                sw1.WriteLine(".Net : AutoSearchPrinter() : start loading XmlDcoument")
                xmldoc.Load(sFileName)
                sw1.WriteLine(".Net : AutoSearchPrinter() : XmlDcoument loaded")

                Dim Id As XmlNode
                Dim nodeList As XmlNodeList
                Dim root As XmlNode = xmldoc.DocumentElement

                sw1.WriteLine(".Net : AutoSearchPrinter() : Select the nodes of //p in nodeList")
                nodeList = xmldoc.SelectNodes("//p")
                Dim inodelength As Integer = nodeList.Count - 1
                Dim arr(inodelength) As Integer
                Dim k As Integer = 0

                For Each Id In nodeList
                    arr(k) = Id.InnerText
                    k += 1
                Next
                sw1.WriteLine(".Net : AutoSearchPrinter() : get the printer information string from xmldocument  //printerinfo.InnerText")
                Dim sPrintInfo As String = xmldoc.SelectSingleNode("//printerinfo").InnerText
                sw1.WriteLine(".Net : AutoSearchPrinter() : Processing start upon Printer information and add it in gridview")
                ''If Convert.ToInt64(sPrintInfo.Length()) > 5 Then
                If sPrintInfo.Length > 5 Then
                    MessageBox.Show("the printer info is 1")
                    ''sPrintInfo = sPrintInfo.Substring(0, Convert.ToInt64(sPrintInfo.Length()) - 2)
                    sPrintInfo = sPrintInfo.Substring(0, sPrintInfo.Length - 2)
                    MessageBox.Show("the printer info is 2")
                    Dim arPrinterInfo() As String = sPrintInfo.Split("$")
                    Dim arComInjfo() As String
                    Dim j As Integer
                    For j = 0 To arPrinterInfo.Length - 1
                        arComInjfo = arPrinterInfo(j).Split("|")
                        ''lsbIds.Items.Add("Printer : " + arComInjfo(0) + " Port : " + arComInjfo(arComInjfo.Length - 1) + " Speed : " + arComInjfo(arComInjfo.Length - 2))
                        dgvPrinter.Rows.Add()
                        dgvPrinter.Rows(j).Cells(0).Value = arr(j)
                        dgvPrinter.Rows(j).Cells(1).Value = arComInjfo(0)
                        dgvPrinter.Rows(j).Cells(2).Value = arComInjfo(arComInjfo.Length - 1)
                        dgvPrinter.Rows(j).Cells(3).Value = arComInjfo(arComInjfo.Length - 2)
                    Next
                Else
                    'sPrintInfo = sPrintInfo.Substring(0, sPrintInfo.Length - 2)
                    'Dim arPrinterInfo() As String = sPrintInfo.Split("$")
                    'Dim arComInjfo() As String
                    Dim j As Integer
                    For j = 0 To arr.Length - 1
                        'arComInjfo = arPrinterInfo(j).Split("|")
                        ''lsbIds.Items.Add("Printer : " + arComInjfo(0) + " Port : " + arComInjfo(arComInjfo.Length - 1) + " Speed : " + arComInjfo(arComInjfo.Length - 2))
                        sw1.WriteLine(".Net : AutoSearchPrinter() New Row add in Gridview")
                        dgvPrinter.Rows.Add()
                        dgvPrinter.Rows(j).Cells(0).Value = arr(j).ToString()
                        dgvPrinter.Rows(j).Cells(0).Value = arr(j)
                        sw1.WriteLine(".Net : AutoSearchPrinter() Printer id is added : " + arr(j).ToString())
                        dgvPrinter.Rows(j).Cells(1).Value = "Printer :" + (j + 1).ToString()
                        sw1.WriteLine(".Net : AutoSearchPrinter() Printer Name is add Printer :" + (j + 1).ToString())
                        dgvPrinter.Rows(j).Cells(2).Value = "Undefined"
                        dgvPrinter.Rows(j).Cells(3).Value = "Undefined"
                    Next
                End If

                ' ''sPrintInfo = sPrintInfo.Substring(0, sPrintInfo.Length - 2)
                ' ''Dim arPrinterInfo() As String = sPrintInfo.Split("$")
                ' ''Dim arComInjfo() As String
                ' ''Dim j As Integer
                ' ''For j = 0 To arPrinterInfo.Length - 1
                ' ''    arComInjfo = arPrinterInfo(j).Split("|")
                ' ''    ''lsbIds.Items.Add("Printer : " + arComInjfo(0) + " Port : " + arComInjfo(arComInjfo.Length - 1) + " Speed : " + arComInjfo(arComInjfo.Length - 2))
                ' ''    dgvPrinter.Rows.Add()
                ' ''    dgvPrinter.Rows(j).Cells(0).Value = arr(j)
                ' ''    dgvPrinter.Rows(j).Cells(1).Value = arComInjfo(0)
                ' ''    dgvPrinter.Rows(j).Cells(2).Value = arComInjfo(arComInjfo.Length - 1)
                ' ''    dgvPrinter.Rows(j).Cells(3).Value = arComInjfo(arComInjfo.Length - 2)
                ' ''Next

                If dgvPrinter.Rows.Count > 0 Then
                    btnCancel.Enabled = True
                    btnClosPort.Enabled = True
                    btnOk.Enabled = True
                    dgvPrinter.Rows(0).Selected = True
                    GroupBox2.Enabled = True
                End If
                sw1.WriteLine(".Net : AutoSearchPrinter() : Processing end")
            Else
                sw1.WriteLine(".Net : AutoSearchPrinter() :The returned value not grater then 0")
                sw1.WriteLine(".Net : AutoSearchPrinter() : Removing all row of datagird which exit already")
                dgvPrinter.Rows.Clear()
                sw1.WriteLine(".Net : AutoSearchPrinter() : Remove completed")
            End If

            sw1.WriteLine(".Net : AutoSearchPrinter() : All working is completed of function AutoSearchPrinter()")
            sw1.Close()
        Catch ex As Exception
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net , AutoSearchPrinter : , " & DateTime.Now & " , " & ex.Message)
                    sw.WriteLine("and source is : " & ex.StackTrace)
                    sw.Close()
                End Using
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Public Function ConfigureAndStartPort(ByVal nPort As Integer, ByVal nBaudRate As Integer, ByVal strSWVersionMajor As String) As String
        Dim retValue As String = System.String.Empty
        Dim sResult As String = System.String.Empty
        Dim strXml As String

        Dim sw1 As StreamWriter
        sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
        sw1.WriteLine(".Net  :  ConfigureAndStartPort () , Create the xml document ")

        ''Dim strSWVersionMinor As String
        SWVersionMinor = "00"
        Try
            strXml = "<root>"
            strXml += "<nPort>" & nPort & "</nPort>"
            strXml += "<nBaudRate>" & nBaudRate & "</nBaudRate>"
            strXml += "<bPrinterType>" & ConstEnum.S7PRINTERID & "</bPrinterType>"
            strXml += "<szSWVersionMajor>" & strSWVersionMajor & "</szSWVersionMajor>"
            strXml += "<szSWVersionMinor>" & SWVersionMinor & "</szSWVersionMinor>"

            strXml += "<bParity>" & ConstEnum.NOPARITY & "</bParity>"
            strXml += "<bStopbits>" & ConstEnum.ONESTOPBIT & "</bStopbits>"
            strXml += "<bDatabits>8</bDatabits>"
            strXml += "<bFlowCtrl>" & ConstEnum.NO_CONTROL & "</bFlowCtrl>"
            strXml += "</root>"
            sw1.WriteLine(".Net  :  ConfigureAndStartPort () , Createtion is compelted ")
            sw1.WriteLine(".Net  :  ConfigureAndStartPort () , Declate/objetct the functilon is InfiniImageVB.PrinterImaj ")
            Dim obj As New InfiniImageVB.PrinterImaje
            sw1.WriteLine(".Net  :  ConfigureAndStartPort () , Declate pk ")
            sw1.Close()

            Return obj.SetPrinterParam(nBaudRate & "," & nPort)

            'If bTrace = True Then
            '    sw1.WriteLine(".Net  ConfigureAndStartPort() :  calling the ConfigureAndStartPort() function ")
            '    sw1.Close()
            '    sResult = obj.ConfigureAndStartPort(strXml, Application.StartupPath())
            'Else
            '    sw1.WriteLine(".Net  :  ConfigureAndStartPort (), calling the ConfigureAndStartPort() function of InfiniImageVB.dll ")
            '    sw1.Close()
            '    sResult = obj.ConfigureAndStartPort(strXml, "")
            'End If
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net  :  ConfigureAndStartPort , Return from ConfigureAndStartPort() function  of InfiniImageVB.dll and return value is : " & sResult)
            sw1.WriteLine(".Net  : ConfigureAndStartPort, Return from ConfigureAndStartPort() function  of InfiniImageVB.dll and return value is : " & sResult)
            sw1.WriteLine(".Net  : ConfigureAndStartPort, The process is complet of ConfigureAndStartPort() ")
            sw1.Close()
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
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return ""
        End Try
        Return sResult
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            cmbPort.Enabled = False
            cmbSpeed.Enabled = False
            GroupBox2.Enabled = True
            btnSearch.Enabled = True
            btnOk.Enabled = False
            btnClosPort.Enabled = False
        Else
            btnOk.Enabled = True
            cmbPort.Enabled = True
            cmbSpeed.Enabled = True
            btnSearch.Enabled = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim sw1 As StreamWriter

        Try

            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net : btnSearch_Click : Search button click on Port Seting Form ")

            btnSearch.Enabled = False
            btnOk.Enabled = False
            btnCancel.Enabled = False
            GroupBox2.Enabled = False

            sw1.WriteLine(".Net : btnSearch_Click : Calling the AutoSearchPrinter() function of .net ")
            sw1.Close()

            AutoSearchPrinter()

            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net : btnSearch_Click : out from AutoSearchPrinter() function of .net ")
            sw1.WriteLine(".Net : btnSearch_Click : The work is completed of Buton Search ")
            btnCancel.Enabled = True

        Catch ex As Exception

            sw1.WriteLine(".Net : ******************************************")
            sw1.WriteLine(".Net : Exception : " & ex.Message)
            sw1.WriteLine(".Net : ******************************************")
            sw1.WriteLine(".Net : Exception : " & ex.StackTrace)
            sw1.WriteLine(".Net : ******************************************")

        Finally

            sw1.Close()

        End Try
    End Sub

    Private Sub btnClosPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClosPort.Click
        Try
            Dim sw1 As StreamWriter
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(" ")
            sw1.WriteLine(".Net btnClosPort_Click() ")
            sw1.Close()
            If dgvPrinter.Rows.Count > 0 Then
                If (MessageBox.Show("If you close the port, printer connection will be broken. Do you want to close the port ?", "Delete Warning", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, False) = Windows.Forms.DialogResult.Yes) Then

                    Dim bBoolean As Boolean
                    If dgvPrinter.SelectedRows.Count > 0 Then

                        Dim cnt As Integer = dgvPrinter.SelectedRows.Count
                        Dim iRow As Integer
                        For iRow = 0 To cnt - 1
                            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                            sw1.WriteLine(".Net btnClosPort_Click() Calling the function of PortClose(" & dgvPrinter.SelectedRows(0).Index & ") ")
                            sw1.Close()
                            bBoolean = PortClose(dgvPrinter.SelectedRows(0).Index)
                            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                            sw1.WriteLine(".Net btnClosPort_Click() Return back and the value is " & bBoolean.ToString())
                            sw1.Close()
                            If bBoolean = True Then
                                Me.dgvPrinter.Rows.RemoveAt(Me.dgvPrinter.SelectedRows(0).Index)
                            Else
                                Me.dgvPrinter.SelectedRows(0).Selected = False
                            End If
                        Next
                    End If
                Else
                    MessageBox.Show("Please select the row first for colse the port...")
                End If
            End If
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net btnClosPort_Click() Process is completed ")
            sw1.Close()

        Catch ex As Exception
            If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                Directory.CreateDirectory(Application.StartupPath() & "\Trace")
            End If

            Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                sw.WriteLine("Error from .Net : btnClosPort_Click, frmSetPort, " & DateTime.Now & " , " & ex.Message)
                sw.WriteLine("and source is : " & ex.StackTrace)
                sw.Close()
            End Using
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Function PortClose(ByVal PrinterID As Integer) As Boolean
        Try
            Dim sw1 As StreamWriter
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(" ")
            sw1.WriteLine(".Net : PortClose(" & PrinterID & ") Enter  ")
            sw1.WriteLine(".Net : PortClose () : Create object of InfiniImageVB.PrinterImaje ")
            Dim objPrintImaje As New InfiniImageVB.PrinterImaje
            sw1.WriteLine(".Net : PortClose () : Object is created ")
            sw1.WriteLine(".Net : PortClose () : Calling the function objPrintImaje.ClosePort(" & PrinterID & "," & Application.StartupPath() & ") ")
            sw1.Close()
            Dim iResult As String
            iResult = objPrintImaje.ClosePort(PrinterID, Application.StartupPath())
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net : PortClose () : Return back and the result is  " & iResult)
            sw1.WriteLine(".Net : PortClose () : Process complete")
            sw1.Close()
            Dim lReturn As Long
            lReturn = CType(iResult, Long)

            If lReturn = ConstEnum.IJ_SUCCESS Then
                MsgBox("Port Closed", vbOKOnly, "Success")
                Return True
            Else
                Dim objErrorShow As New modFunctions
                objErrorShow.ShowFailureMessage(lReturn)
                Return False
            End If
        Catch ex As Exception
            If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                Directory.CreateDirectory(Application.StartupPath() & "\Trace")
            End If
            Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                sw.WriteLine("Error from .Net : , " & DateTime.Now & " , " & ex.Message)
                sw.WriteLine("and source is : " & ex.StackTrace)
                sw.Close()
            End Using
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub dgvPrinter_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrinter.RowEnter
        Try
            dgvPrinter.Rows(e.RowIndex).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvPrinter_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrinter.CellEnter

    End Sub

    Private Sub dgvPrinter_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrinter.CellClick
        Try
            dgvPrinter.Rows(e.RowIndex).Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvPrinter_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrinter.CellDoubleClick
        Try
            dgvPrinter.Rows(e.RowIndex).Selected = True
        Catch ex As Exception
        End Try
    End Sub
End Class