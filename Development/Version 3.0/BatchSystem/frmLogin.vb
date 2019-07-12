Imports Microsoft.Win32
Imports System.Security.Cryptography
Imports System.IO


Public Class frmLogin

    Private Sub rptWindows_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    ' Declare the PrintDocument object.
    Private WithEvents docToPrint As New Printing.PrintDocument

    ' This method will set properties on the PrintDialog object and
    ' then display the dialog.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs)

        ' Allow the user to choose the page range he or she would
        ' like to print.
        PrintDialog1.AllowSomePages = True
        ' Show the help button.
        PrintDialog1.ShowHelp = True
        Dim pSize As New System.Drawing.Printing.PaperSize("Custom", 2, 2)
        ' Set the Document property to the PrintDocument for 
        ' which the PrintPage Event has been handled. To display the
        ' dialog, either this property or the PrinterSettings property 
        ' must be set 
        PrintDialog1.Document = docToPrint

        Dim result As DialogResult = PrintDialog1.ShowDialog()

        ' If the result is OK then print the document.
        If (result = DialogResult.OK) Then
            docToPrint.Print()
        End If

    End Sub

    ' The PrintDialog will print the document
    ' by handling the document's PrintPage event.
    Private Sub document_PrintPage(ByVal sender As Object, _
       ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
           Handles docToPrint.PrintPage

        ' Insert code to render the page here.
        ' This code will be called when the control is drawn.

        ' The following code will render a simple
        ' message on the printed document.
        Dim text As String = "In document_PrintPage method."
        Dim printFont As New System.Drawing.Font _
            ("Arial", 35, System.Drawing.FontStyle.Regular)

        ' Draw the content.
        e.Graphics.DrawString(text, printFont, _
            System.Drawing.Brushes.Black, 10, 10)
    End Sub

    Public Sub Printing()
        'Dim streamToPrint As IO.StreamReader
        'Try
        '    streamToPrint = New IO.StreamReader("filePath")
        '    Try
        '        'printFont = New Font("Arial", 10)
        '        Dim pd As New System.Drawing.Printing.PrintDocument()
        '        AddHandler pd.PrintPage, AddressOf pd_PrintPage
        '        pd.PrinterSettings.PrinterName = "printer"
        '        ' Set the page orientation to landscape.
        '        pd.DefaultPageSettings.Landscape = True
        '        pd.Print()
        '    Finally
        '        streamToPrint.Close()
        '    End Try
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    'Public Function pd_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)



    'End Function

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sDecPassword As String = System.String.Empty
        Dim oSecurity As New Security()
        Try
            'Dim frm As Form
            'frm = frmBatch
            'frm = frmSerials
            'frm = frmMain

            Dim cmdText As String = "Select * from Users where UserID='" & Me.TextBox1.Text & "'"
            Dim dsUser As DataSet
            dsUser = CType(ExecuteQuery(cmdText, Execute.DataSet), DataSet)

            If dsUser.Tables(0).Rows.Count > 0 Then
                sDecPassword = oSecurity.DecryptText(dsUser.Tables(0).Rows(0)("UserPassword"))
                'If TextBox2.Text.Equals(dsUser.Tables(0).Rows(0)("UserPassword")) Then
                If TextBox2.Text.Equals(sDecPassword) Then
                    Dim frm As New frmMain(dsUser.Tables(0).Rows(0)("UserCode"))
                    cmdText = "Select count(*) from Products"

                    Dim TotalRecords As Integer = 1 'ExecuteQuery(cmdText, Execute.Scalar)  'by Saad 08/08/08

                    ' If TotalRecords = 0 Then

                    'Dim objKey As Microsoft.Win32.RegistryKey
                    'objKey.SetValue("HKEY_LOCAL_MACHINE\software\InfiniLogic\ApplicationPath\Path", "fsdkflskdjflksdjfkls")

                    Dim pRegKey As RegistryKey = Registry.LocalMachine
                    ''Dim sKey As RegistryKey = pRegKey.OpenSubKey("software", True)
                    Dim sKey As RegistryKey = pRegKey.OpenSubKey("software", True)
                    ''Dim ikey As RegistryKey = sKey.OpenSubKey("InfiniLogic", False)
                    Dim ikey As RegistryKey = sKey.CreateSubKey("InfiniLogic", RegistryKeyPermissionCheck.ReadWriteSubTree)
                    ''Dim aKey As RegistryKey = ikey.OpenSubKey("ApplicationPath", True)
                    Dim aKey As RegistryKey = ikey.CreateSubKey("ApplicationPath", RegistryKeyPermissionCheck.ReadWriteSubTree)
                    Dim sValue As String = Application.StartupPath() + "\PrinterInfo.TXT"
                    aKey.SetValue("PrintInfoPath", sValue.Replace("\", "\\"))

                    Dim pRegKey1 As RegistryKey = Registry.LocalMachine
                    ''Dim sKey As RegistryKey = pRegKey.OpenSubKey("software", True)
                    Dim sKey1 As RegistryKey = pRegKey1.OpenSubKey("software", True)
                    ''Dim ikey As RegistryKey = sKey.OpenSubKey("InfiniLogic", False)
                    Dim ikey1 As RegistryKey = sKey1.CreateSubKey("InfiniLogic", RegistryKeyPermissionCheck.ReadWriteSubTree)
                    ''Dim aKey As RegistryKey = ikey.OpenSubKey("ApplicationPath", True)
                    Dim aKey1 As RegistryKey = ikey1.CreateSubKey("ApplicationPath", RegistryKeyPermissionCheck.ReadWriteSubTree)
                    Dim sValue1 As String = Application.StartupPath() + "\Trace\Log.TXT"
                    ''Dim sValue1 As String = Application.StartupPath() + "\Trace"
                    aKey1.SetValue("LogPath", sValue1.Replace("\", "\\"))

                    If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                        'create it if it doesn't
                        Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                    End If

                    Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                        sw.WriteLine("Login in the application")
                        sw.Close()
                    End Using


                    'pRegKey = pRegKey.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0")
                    'Dim val As Object = pRegKey.GetValue("VendorIdentifier")

                    If TotalRecords = 0 Then

                        Dim Products() As String = {"Love", "Jeans", "Classic", "Elite", "Extra Safe", "Fetherlite", "Fetherlite + 2 Promo pack", "Fetherlite Warming", "Fetherlite Warming + 2 Promo pack", "Fetherlite ultima", "Fetherlite Elite", "Together", "Tingle", "Tingle promotion pack", _
                                                    "Excita", "Select", "Select Strawberry", "Select banana", "Perfect Fit", "Perfect Fit Promotion pack", "Pleasuremax", "Pleasuremax Tingle", "Pleasuremax warming", "Performa"}
                        Dim Packet(23)() As Integer
                        Dim Regions() As String = {"J", "G", "D"}

                        Packet(0) = New Integer() {1, 3, 10}
                        Packet(1) = New Integer() {3, 12}
                        Packet(2) = New Integer() {3, 12}
                        Packet(3) = New Integer() {3, 12}
                        Packet(4) = New Integer() {3, 12}
                        Packet(5) = New Integer() {1, 3, 8, 12, 18}

                        Packet(6) = New Integer() {14}
                        Packet(7) = New Integer() {1, 3, 12}
                        Packet(8) = New Integer() {14}
                        Packet(9) = New Integer() {3, 12}
                        Packet(10) = New Integer() {3, 12}
                        Packet(11) = New Integer() {3, 12}

                        Packet(12) = New Integer() {1, 3, 12}
                        Packet(13) = New Integer() {3}
                        Packet(14) = New Integer() {3, 12}
                        Packet(15) = New Integer() {3, 12}
                        Packet(16) = New Integer() {3, 12}

                        Packet(17) = New Integer() {3, 12}
                        Packet(18) = New Integer() {1, 3, 8, 12}
                        Packet(19) = New Integer() {3}
                        Packet(20) = New Integer() {3, 8, 12}
                        Packet(21) = New Integer() {3, 12}
                        Packet(22) = New Integer() {3, 12}
                        Packet(23) = New Integer() {3, 12}
                        'Packet(24) = New Integer() {8}
                        'Packet(25) = New Integer() {8}
                        'Packet(26) = New Integer() {8}

                        Dim iProduct As Integer = 0
                        Dim iPacket As Integer = 0
                        Dim PacketSize As Integer = 0
                        Dim Productid As Integer = 0

                        cmdText = "insert into Regions (RegionCode,Description) values ('J','j')"
                        ExecuteQuery(cmdText, Execute.None)

                        cmdText = "insert into Regions (RegionCode,Description) values ('G','g')"
                        ExecuteQuery(cmdText, Execute.None)

                        cmdText = "insert into Regions (RegionCode,Description) values ('D','d')"
                        ExecuteQuery(cmdText, Execute.None)

                        Dim ds As New DataSet
                        Dim dtRegion As New DataTable
                        Dim drRegion As DataRow
                        cmdText = "Select * from Regions "
                        ds = ExecuteQuery(cmdText, Execute.DataSet)
                        dtRegion = ds.Tables(0)


                        Dim ProductPacketID As Integer = 0

                        For iProduct = 0 To 23
                            Productid = 0
                            cmdText = "select max(ID) from Products"
                            Productid = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar)) + 1
                            cmdText = "insert into Products (ProductCode,ProductName) values ('" & Productid & "','" & Products(iProduct) & "')"
                            ExecuteQuery(cmdText, Execute.None)

                            For iPacket = 0 To Packet(iProduct).Length - 1
                                PacketSize = Packet(iProduct)(iPacket)
                                cmdText = "Insert into Packets (ProductCode,PacketSize) values('" & Productid & "'," & PacketSize & ")"
                                ExecuteQuery(cmdText, Execute.None)

                                cmdText = "select max(SystemId) from Packets"
                                ProductPacketID = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar))
                                For Each drRegion In dtRegion.Rows
                                    cmdText = "Insert into ProductPacketRegion (RegionCode,ProdcutPacketID) values(" & drRegion("ID") & "," & ProductPacketID & ")"
                                    ExecuteQuery(cmdText, Execute.None)
                                Next
                            Next
                        Next
                    End If
                    frm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid User/Password", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                'TextBox1.Text = System.String.Empty
                'TextBox2.Text = System.String.Empty
                MessageBox.Show("Invalid User/Password", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


            '' '' ''If Me.TextBox1.Text.Equals("admin") And Me.TextBox2.Text.Equals("admin") Then
            '' '' ''    Dim cmdText As String = "Select count(*) from Products"
            '' '' ''    Dim TotalRecords As Integer = ExecuteQuery(cmdText, Execute.Scalar)
            '' '' ''    If TotalRecords = 0 Then
            '' '' ''        Dim Products() As String = {"Love", "Jeans", "Classic", "Elite", "Extra Safe", "Fetherlite", "Fetherlite + 2 Promo pack", "Fetherlite Warming", "Fetherlite Warming + 2 Promo pack", "Fetherlite ultima", "Fetherlite Elite", "Together", "Tingle", "Tingle promotion pack", _
            '' '' ''                                    "Excita", "Select", "Select Strawberry", "Select banana", "Perfect Fit", "Perfect Fit Promotion pack", "Pleasuremax", "Pleasuremax Tingle", "Pleasuremax warming", "Performa"}
            '' '' ''        Dim Packet(23)() As Integer
            '' '' ''        Dim Regions() As String = {"J", "G", "D"}

            '' '' ''        Packet(0) = New Integer() {1, 3, 10}
            '' '' ''        Packet(1) = New Integer() {3, 12}
            '' '' ''        Packet(2) = New Integer() {3, 12}
            '' '' ''        Packet(3) = New Integer() {3, 12}
            '' '' ''        Packet(4) = New Integer() {3, 12}
            '' '' ''        Packet(5) = New Integer() {1, 3, 8, 12, 18}

            '' '' ''        Packet(6) = New Integer() {14}
            '' '' ''        Packet(7) = New Integer() {1, 3, 12}
            '' '' ''        Packet(8) = New Integer() {14}
            '' '' ''        Packet(9) = New Integer() {3, 12}
            '' '' ''        Packet(10) = New Integer() {3, 12}
            '' '' ''        Packet(11) = New Integer() {3, 12}

            '' '' ''        Packet(12) = New Integer() {1, 3, 12}
            '' '' ''        Packet(13) = New Integer() {3}
            '' '' ''        Packet(14) = New Integer() {3, 12}
            '' '' ''        Packet(15) = New Integer() {3, 12}
            '' '' ''        Packet(16) = New Integer() {3, 12}

            '' '' ''        Packet(17) = New Integer() {3, 12}
            '' '' ''        Packet(18) = New Integer() {1, 3, 8, 12}
            '' '' ''        Packet(19) = New Integer() {3}
            '' '' ''        Packet(20) = New Integer() {3, 8, 12}
            '' '' ''        Packet(21) = New Integer() {3, 12}
            '' '' ''        Packet(22) = New Integer() {3, 12}
            '' '' ''        Packet(23) = New Integer() {3, 12}
            '' '' ''        'Packet(24) = New Integer() {8}
            '' '' ''        'Packet(25) = New Integer() {8}
            '' '' ''        'Packet(26) = New Integer() {8}

            '' '' ''        Dim iProduct As Integer = 0
            '' '' ''        Dim iPacket As Integer = 0
            '' '' ''        Dim PacketSize As Integer = 0
            '' '' ''        Dim Productid As Integer = 0

            '' '' ''        cmdText = "insert into Regions (RegionCode,Description) values ('J','j')"
            '' '' ''        ExecuteQuery(cmdText, Execute.None)

            '' '' ''        cmdText = "insert into Regions (RegionCode,Description) values ('G','g')"
            '' '' ''        ExecuteQuery(cmdText, Execute.None)

            '' '' ''        cmdText = "insert into Regions (RegionCode,Description) values ('D','d')"
            '' '' ''        ExecuteQuery(cmdText, Execute.None)

            '' '' ''        Dim ds As New DataSet
            '' '' ''        Dim dtRegion As New DataTable
            '' '' ''        Dim drRegion As DataRow
            '' '' ''        cmdText = "Select * from Regions "
            '' '' ''        ds = ExecuteQuery(cmdText, Execute.DataSet)
            '' '' ''        dtRegion = ds.Tables(0)


            '' '' ''        Dim ProductPacketID As Integer = 0

            '' '' ''        For iProduct = 0 To 23
            '' '' ''            Productid = 0
            '' '' ''            cmdText = "select max(ID) from Products"
            '' '' ''            Productid = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar)) + 1
            '' '' ''            cmdText = "insert into Products (ProductCode,ProductName) values ('" & Productid & "','" & Products(iProduct) & "')"
            '' '' ''            ExecuteQuery(cmdText, Execute.None)

            '' '' ''            For iPacket = 0 To Packet(iProduct).Length - 1
            '' '' ''                PacketSize = Packet(iProduct)(iPacket)
            '' '' ''                cmdText = "Insert into Packets (ProductCode,PacketSize) values('" & Productid & "'," & PacketSize & ")"
            '' '' ''                ExecuteQuery(cmdText, Execute.None)

            '' '' ''                cmdText = "select max(SystemId) from Packets"
            '' '' ''                ProductPacketID = CheckDBNull(ExecuteQuery(cmdText, Execute.Scalar))
            '' '' ''                For Each drRegion In dtRegion.Rows
            '' '' ''                    cmdText = "Insert into ProductPacketRegion (RegionCode,ProdcutPacketID) values(" & drRegion("ID") & "," & ProductPacketID & ")"
            '' '' ''                    ExecuteQuery(cmdText, Execute.None)
            '' '' ''                Next
            '' '' ''            Next
            '' '' ''        Next
            '' '' ''    End If
            '' '' ''    frm.Show()
            '' '' ''    Me.Hide()
            '' '' ''Else
            '' '' ''MessageBox.Show("Invalid User/Password", "Batch System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '' '' ''End If

        Catch ex As Exception
            ''MessageBox.Show("Error : Try later..")
            If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                'create it if it doesn't
                Directory.CreateDirectory(Application.StartupPath() & "\Trace")
            End If

            Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                sw.WriteLine("Error from .Net : LognForm , " & DateTime.Now & " , " & ex.Message)
                sw.WriteLine("and source is : " & ex.StackTrace)
                sw.Close()
            End Using
            ''MessageBox.Show("Error " & ex.Message.ToString)
            MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DesDemo.Show()

    End Sub
End Class