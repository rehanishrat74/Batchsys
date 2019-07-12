Imports System.Drawing.Printing
Public Class customPrint

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'This method displays a PageSetupDialog object. If the
        ' user clicks OK in the dialog, selected results of
        ' the dialog are displayed in ListBox1.
        ' Initialize the dialog's PrinterSettings property to hold user
        ' defined printer settings.
        PageSetupDialog1.PageSettings = _
            New System.Drawing.Printing.PageSettings

        ' Initialize dialog's PrinterSettings property to hold user
        ' set printer settings.
        '*****************************************************************
        'Visual Basic  Copy Code 
        ' Add list of supported paper sizes found on the printer. 
        ' The DisplayMember property is used to identify the property that will provide the display string.

        Dim pkSize As PaperSize
        'For i = 0 To printDoc.PrinterSettings.PaperSizes.Count - 1
        '    pkSize = printDoc.PrinterSettings.PaperSizes.Item(i)
        '    comboPaperSize.Items.Add(pkSize)
        'Next

        ' Create a PaperSize and specify the custom paper size through the constructor and add to combobox.
        Dim pkCustomSize1 As New PaperSize("Custom Paper Size", 100, 200)
        ' comboPaperSize.Items.Add(pkCustomSize1)

        '*****************************************************************
        PageSetupDialog1.PrinterSettings = _
            New System.Drawing.Printing.PrinterSettings

        'Do not show the network in the printer dialog.
        PageSetupDialog1.ShowNetwork = False
        PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1
        'Show the dialog storing the result.
        Dim result As DialogResult = PageSetupDialog1.ShowDialog()

        ' If the result is OK, display selected settings in
        ' ListBox1. These values can be used when printing the
        ' document.

        If (result = DialogResult.OK) Then
            Dim results() As Object = New Object() _
                {PageSetupDialog1.PageSettings.Margins, _
                 PageSetupDialog1.PageSettings.PaperSize, _
                 PageSetupDialog1.PageSettings.Landscape, _
                 PageSetupDialog1.PrinterSettings.PrinterName, _
                 PageSetupDialog1.PrinterSettings.PrintRange}
            ListBox1.Items.AddRange(results)
        End If

    End Sub
End Class