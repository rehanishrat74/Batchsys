Imports System
Imports System.Diagnostics

Public Class Form1
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Try
            If Me.chkAutoSearch.Checked Then
                'Printer.PrinterID = Printer.Imaje9020.AutoSearchPrinter("c:\")
                Printer.Imaje9020.AutoSetPrinter(Printer.TracePath)
            Else
                'Printer.PrinterID = Printer.Imaje9020.SetPrinterParam(Me.cmbBaudRate.SelectedText.ToString.Trim & "," & Me.cmbPort.SelectedText.ToString.Trim)
                Printer.PrinterID = Printer.Imaje9020.SetPrinter(Me.cmbBaudRate.Text.ToString.Trim & "," & Me.cmbPort.Text.ToString.Trim, Printer.TracePath)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show(ex.StackTrace)
        End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Printer.Imaje9020.ClosePort(Printer.PrinterID, Printer.TracePath)
        Catch
        End Try
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Printer.Imaje9020.SendMessage_9020(Printer.PrinterID & "," & Me.txtMessage.Text, Printer.TracePath)
    End Sub

    Private Sub btnButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnButton1.Click
        Dim program As New Process()
        program.StartInfo.FileName = "C:\Program Files\Imaje SA\Imaje Printer API DLL\EXAMPLES\VBAppSTP\BIN\S7APITest.exe"
        program.StartInfo.Arguments = " "
        program.Start()
    End Sub
End Class
