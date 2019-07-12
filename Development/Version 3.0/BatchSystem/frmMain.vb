Imports InfiniImageVB
Imports System.Xml
Imports System.IO
Public Class frmMain
    Dim sUserCode As String
    Public Sub New(ByVal value As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        sUserCode = value
    End Sub
    Private Sub SerialsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerialsToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        'Dim activeChildform As Form = Me.ActiveMdiChild
        If activeChild Is Nothing Then
        Else
            If activeChild.Name = "SerialsGen" Then
                Exit Sub
            Else
                activeChild.Close()
            End If
        End If

        ' Dim NewMDIChild As New frmSerials1()
        Dim NewMDIChild As New frmSerials1()
        NewMDIChild.Name = "SerialsGen"
        'Set the Parent Form of the Child window.
        NewMDIChild.MdiParent = Me
        Try
            Dim ico As New System.Drawing.Icon(Application.StartupPath & "\TBS_small3.ico")
            Me.Icon = ico
        Catch ex As Exception

        End Try
        'Display the new form.
        NewMDIChild.Show()
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        'Dim activeChildform As Form = Me.ActiveMdiChild
        If activeChild Is Nothing Then
        Else
            If activeChild.Name = "Products" Then
                Exit Sub
            Else
                activeChild.Close()
            End If
        End If

        Dim NewMDIChild As New frmProduct
        NewMDIChild.Name = "Products"
        'Set the Parent Form of the Child window.
        NewMDIChild.MdiParent = Me

        'Display the new form.
        NewMDIChild.Show()
    End Sub

    Private Sub SingleRepotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SingleRepotToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        'Dim activeChildform As Form = Me.ActiveMdiChild
        If activeChild Is Nothing Then
        Else
            If activeChild.Name = "ReportSerial" Then
                Exit Sub
            Else
                activeChild.Close()
            End If
        End If

        Dim NewMDIChild As New frmReportCriteria("Serial", sUserCode)
        NewMDIChild.Name = "ReportSerial"
        NewMDIChild.Text = "Report Security Code"
        NewMDIChild.GroupBox4.Text = "Report Security Code"
        'Set the Parent Form of the Child window.
        NewMDIChild.MdiParent = Me
        Try
            Dim ico As New System.Drawing.Icon(Application.StartupPath & "\TBS_small3.ico")
            Me.Icon = ico
        Catch ex As Exception

        End Try
        'Display the new form.
        NewMDIChild.Show()
    End Sub

    Private Sub MultipleSerialsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultipleSerialsToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        'Dim activeChildform As Form = Me.ActiveMdiChild
        If activeChild Is Nothing Then
        Else
            If activeChild.Name = "ReportMulti" Then
                Exit Sub
            Else
                activeChild.Close()
            End If
        End If

        Dim NewMDIChild As New frmReportCriteria("Multi", sUserCode)
        NewMDIChild.Name = "ReportMulti"
        NewMDIChild.Text = "Report Security Codes"
        NewMDIChild.GroupBox4.Text = "Report Multiple Security Codes"
        'Set the Parent Form of the Child window.
        NewMDIChild.MdiParent = Me
        Try
            Dim ico As New System.Drawing.Icon(Application.StartupPath & "\TBS_small3.ico")
            Me.Icon = ico
        Catch ex As Exception

        End Try
        'Display the new form.
        NewMDIChild.Show()
    End Sub

    Private Sub TextFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextFileToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        'Dim activeChildform As Form = Me.ActiveMdiChild
        If activeChild Is Nothing Then
        Else
            If activeChild.Name = "ReportText" Then
                Exit Sub
            Else
                activeChild.Close()
            End If
        End If

        Dim NewMDIChild As New frmReportCriteria("Text", sUserCode)
        NewMDIChild.Name = "ReportText"
        NewMDIChild.Text = "Report Text"
        NewMDIChild.GroupBox4.Text = "Report Text File"
        'Set the Parent Form of the Child window.
        NewMDIChild.MdiParent = Me
        Try
            Dim ico As New System.Drawing.Icon(Application.StartupPath & "\TBS_small3.ico")
            Me.Icon = ico
        Catch ex As Exception

        End Try
        'Display the new form.
        NewMDIChild.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim FileName As String
        'Dim sw As StreamWriter
        'streamwriter is used to write text
        Try
            With OpenFileDialog1
                .InitialDirectory = Application.StartupPath()
                .Filter = "Text files (*.txt)|*.txt"
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    FileName = .FileName
                    System.Diagnostics.Process.Start("notepad.exe", FileName)
                End If
            End With
        Catch es As Exception
            MessageBox.Show(es.Message)
        End Try

        'System.Diagnostics.Process.Start("notepad.exe", "C:\Serails.txt")
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        If Not OpenFileDialog1.FileName.EndsWith(".txt") Then
            MsgBox("File " & OpenFileDialog1.FileName & " is not a .txt file", MsgBoxStyle.Exclamation, "Invalid File Type")
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mnuTrace.Checked = True
        bTrace = True
        Dim cmdText As String = System.String.Empty
        Dim ds As DataSet
        cmdText = "Select * from UserRights where userid=" & sUserCode
        ds = CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet)
        Dim ht As New Hashtable()
        Me.OpenToolStripMenuItem.Visible = False
        Me.SerialsToolStripMenuItem.Visible = False
        Me.ProductsToolStripMenuItem.Visible = False
        Me.SingleRepotToolStripMenuItem.Visible = False
        Me.MultipleSerialsToolStripMenuItem.Visible = False
        Me.TextFileToolStripMenuItem.Visible = False
        Me.RegionsToolStripMenuItem.Visible = False
        Me.mnuPrinterSetPort.Visible = False
        Me.mnuPrinterCodePrint.Visible = False
        Me.mnuTrace.Visible = False
        Me.CreateToolStripMenuItem.Visible = False

        Me.mnuPrinterClosePort.Visible = False
        Me.mnuPrinterStartStopMachine.Visible = False
        Me.mnuPrinterStatus.Visible = False
        ''Me.mnuPrinterCodePrint.Visible = False

        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim bCheck As Boolean = False
        For Each dr In dt.Rows
            If dr("IsVisible") = 1 Then
                bCheck = True
            Else
                bCheck = False
            End If
            SetMenuItems(dr("MenuID"), bCheck)
            '''CType(dr("MenuID"), System.Windows.Forms.ToolStripMenuItem).Visible = True
        Next

    End Sub

    Public Sub SetMenuItems(ByVal sMenuName As String, ByVal bVisaible As Boolean)
        Select Case sMenuName
            Case "OpenToolStripMenuItem"
                Me.OpenToolStripMenuItem.Visible = bVisaible
            Case "SerialsToolStripMenuItem"
                Me.SerialsToolStripMenuItem.Visible = bVisaible
            Case "ProductsToolStripMenuItem"
                Me.ProductsToolStripMenuItem.Visible = bVisaible
            Case "SingleRepotToolStripMenuItem"
                Me.SingleRepotToolStripMenuItem.Visible = bVisaible
            Case "MultipleSerialsToolStripMenuItem"
                Me.MultipleSerialsToolStripMenuItem.Visible = bVisaible
            Case "TextFileToolStripMenuItem"
                Me.TextFileToolStripMenuItem.Visible = bVisaible
            Case "RegionsToolStripMenuItem"
                Me.RegionsToolStripMenuItem.Visible = bVisaible
            Case "mnuPrinterSetPort"
                Me.mnuPrinterSetPort.Visible = bVisaible
            Case "mnuPrinterCodePrint"
                Me.mnuPrinterCodePrint.Visible = bVisaible
            Case "mnuTrace"
                Me.mnuTrace.Visible = bVisaible
            Case "CreateToolStripMenuItem"
                Me.CreateToolStripMenuItem.Visible = bVisaible
            Case "mnuPrinterClosePort"
                Me.mnuPrinterClosePort.Visible = bVisaible
            Case "mnuPrinterStartStopMachine"
                Me.mnuPrinterStartStopMachine.Visible = bVisaible
            Case "mnuPrinterStatus"
                Me.mnuPrinterStatus.Visible = bVisaible
        End Select
    End Sub

    Private Sub RegionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegionsToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild

        If activeChild Is Nothing Then
        Else
            If activeChild.Name = "Regions" Then
                Exit Sub
            Else
                activeChild.Close()
            End If
        End If

        Dim NewMDIChild As New frmRegion
        NewMDIChild.Name = "Regions"
        NewMDIChild.MdiParent = Me

        'Display the new form.
        NewMDIChild.Show()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        If activeChild IsNot Nothing Then
            activeChild.Close()
        End If

    End Sub

    Private Sub mnuPrinterSetPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrinterSetPort.Click
        Dim activeChild As Form = Me.ActiveMdiChild

        If activeChild Is Nothing Then
        Else
            If activeChild.Name = "PortConfigure" Then
                Exit Sub
            Else
                activeChild.Close()
            End If
        End If

        Dim NewMDIChild As New frmSetPort
        NewMDIChild.Name = "PortConfigure"
        NewMDIChild.MdiParent = Me

        'Display the new form.
        NewMDIChild.Show()
    End Sub

    Private Sub mnuPrinterClosePort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrinterClosePort.Click

        Dim objPrintImaje As New InfiniImageVB.PrinterImaje
        Dim iResult As String

        Try
            If (MessageBox.Show("If you close the port, printer connection will be broken. Do you want to close the port ?", "Delete Warning", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, False) = Windows.Forms.DialogResult.Yes) Then

                'MessageBox.Show("The printer id is : " & lPrinterID)
                iResult = objPrintImaje.ClosePort(lPrinterID, Application.StartupPath())
                Dim lReturn As Long
                lReturn = CType(iResult, Long)

                If lReturn = ConstEnum.IJ_SUCCESS Then
                    MsgBox("Port Closed", vbOKOnly, "Success")
                    Me.mnuPrinterSetPort.Enabled = True
                    Me.mnuPrinterClosePort.Enabled = False
                    Me.mnuPrinterCodePrint.Enabled = False
                    Me.mnuPrinterStatus.Enabled = False
                    Me.mnuPrinterStartStopMachine.Enabled = False
                Else
                    Dim objErrorShow As New modFunctions
                    objErrorShow.ShowFailureMessage(lReturn)
                End If
            End If
        Catch ex As Exception
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
        End Try
    End Sub

    Private Sub mnuPrinterCodePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrinterCodePrint.Click
        Dim activeChild As Form = Me.ActiveMdiChild

        If activeChild Is Nothing Then
        Else
            If activeChild.Name = "PrintCodes" Then
                Exit Sub
            Else
                activeChild.Close()
            End If
        End If

        Dim NewMDIChild As New frmPrintCodes
        NewMDIChild.Name = "PrintCodes"
        NewMDIChild.MdiParent = Me
        NewMDIChild.Show()
    End Sub

    Private Sub mnuTrace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTrace.Click
        Try

            If Directory.Exists(Application.StartupPath() & "\Trace") Then
                'create it if it doesn't
                'Dim file1 As  File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Open)
                'file1 = File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Open)

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Create))
                    sw.WriteLine("")
                    sw.Close()
                End Using
            End If
            If mnuTrace.Checked = True Then
                bTrace = True
            Else
                bTrace = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild

        If activeChild Is Nothing Then
        Else
            If activeChild.Name = "Users" Then
                Exit Sub
            Else
                activeChild.Close()
            End If
        End If

        Dim NewMDIChild As New frmUsers
        NewMDIChild.Name = "Users"
        NewMDIChild.MdiParent = Me

        'Display the new form.
        NewMDIChild.Show()
    End Sub
    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click
        Dim f() As Form = Me.MdiChildren
        If (f.Length > 0) Then
            Me.CloseToolStripMenuItem.Enabled = True
        Else
            Me.CloseToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub FileToolStripMenuItem_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FileToolStripMenuItem.MouseMove
        Dim f() As Form = Me.MdiChildren
        If (f.Length > 0) Then
            Me.CloseToolStripMenuItem.Enabled = True
        Else
            Me.CloseToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ''MessageBox.Show("nisar123")
        End
    End Sub
    Private Sub SendLogFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendLogFileToolStripMenuItem.Click
        Try

            LogSend()
        Catch ex As Exception
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net : , GetDllVersion() , frmSetPort" & DateTime.Now & " , " & ex.Message)
                    sw.WriteLine("and source is : " & ex.StackTrace)
                    sw.Close()
                End Using
                MessageBox.Show("Log file not send ,plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Log file not send ,plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Public Sub LogSend()
        Dim sr As StreamReader
        sr = New StreamReader(Application.StartupPath() & "\Trace\Log.txt")
        Dim s As String = sr.Read()
    End Sub
    Private Sub HelpTopicsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpTopicsToolStripMenuItem.Click
        'Dim str As String = Application.StartupPath
        Process.Start(Application.StartupPath & "/TBS_Help.mht")
    End Sub
    Private Sub PrinteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrinteToolStripMenuItem.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "/TBS_Printer.exe")
    End Sub
End Class