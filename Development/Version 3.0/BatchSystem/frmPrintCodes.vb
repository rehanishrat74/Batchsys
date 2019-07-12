Imports System.IO
Imports System.Xml
Public Class frmPrintCodes

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click

        Dim dsCodes As DataSet
        Try
            Dim sw1 As StreamWriter
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(" ")
            sw1.WriteLine(".Net : Print Codes ")
            sw1.WriteLine(".Net : Form PrintCodes() : btnShow_Click() ")
            sw1.Close()
            If Me.cmbProduct.SelectedValue <> Nothing Then
                'If cmbPacket.Text.Length > 0 AndAlso IsNumeric(cmbPacket.Text) AndAlso cmbPacket.Text > 0 Then ' by Saad
                If cmbRegions.Text.Length > 0 And cmbRegions.Text <> Nothing Then


                    Dim ProductPacket As String()
                    Dim ProPack As String
                    ProPack = cmbProduct.SelectedValue
                    ProductPacket = ProPack.Split(" ")
                    Dim PacketSize As Integer = ProductPacket(1).ToString
                    Dim product As String = ProductPacket(0).ToString


                    Dim cmdText As String = System.String.Empty
                    'If Me.rdoBatch.Checked Then
                    '    cmdText = "SELECT Serials From Serials WHERE IsUploaded='N'"
                    'Else
                    '    cmdText = "SELECT Serials From Serials WHERE IsUploaded='Y'"
                    'End If

                    cmdText = "SELECT Serials From Serials WHERE IsUploaded='N'"
                    cmdText += " And ProductCode='" & Me.cmbProduct.SelectedValue & "'  And PacketSize=" & PacketSize
                    cmdText = "SELECT Serials From Serials WHERE "
                    cmdText += " ProductCode='" & product & "'  And PacketSize=" & PacketSize
                    cmdText += " And Region='" & Me.cmbRegions.Text & "' "
                    cmdText += " And IsPrinted='N' "
                    cmdText += "And InsDate Between (#" & Format(dtFrom.Value, "MM/dd/yyyy") & "#) And (#" & Format(dtTo.Value, "MM/dd/yyyy") & "#);"

                    dsCodes = ExecuteQuery(cmdText, Execute.DataSet)

                    If dsCodes.Tables(0).Rows.Count > 0 Then
                        Dim f As frmCodesShow
                        f = New frmCodesShow(dsCodes.Tables(0), Me.cmbProduct.Text)
                        'f.Text = "Product and Packet Size"
                        f.ShowDialog(Me)
                        Dim iSelectID As String = frmCodesShow.iID
                        Dim iSelectRange As Integer = frmCodesShow.iRange

                        Dim strRetValue As String = System.String.Empty
                        Dim lReturnValue As Long
                        Dim strMessage As String
                        'lReturnValue = CType(SendMessage("ASEDE312", lPrinterID, 15, 81, 1), Long)
                        'strRetValue = SendMessage("ASEDE312", lPrinterID, 15, 81, 1)


                        If iSelectID.Length > 0 Then
                            lsbPrintedCodes.Visible = False
                            Label2.Visible = False
                            strMessage = iSelectID
                            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                            sw1.WriteLine(".Net btnShow_Click : Single message Printing")
                            sw1.WriteLine(".Net btnShow_Click : Message to Print is : " & strMessage)
                            sw1.WriteLine(".Net btnShow_Click : Calling function SendMessage(" & strMessage & "," & lPrinterID & ",15,81,1)")
                            sw1.Close()
                            strRetValue = SendMessage(strMessage, lPrinterID, 15, 81, 1)
                            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                            sw1.WriteLine(".Net btnShow_Click : Return form the function SendMessage ")
                            sw1.WriteLine(".Net btnShow_Click : The value return is  :" & strRetValue)
                            sw1.Close()
                            If strRetValue <> "" Then
                                lReturnValue = CType(strRetValue, Long)
                                If lReturnValue = ConstEnum.IJ_SUCCESS Then
                                    cmdText = "UPDATE Serials SET IsPrinted='Y' WHERE Serials='" & strMessage & "'  "
                                    MessageBox.Show("Message Printed Success", "Batch Security System", MessageBoxButtons.OK)
                                Else
                                    Dim objmodFunctions As New modFunctions
                                    objmodFunctions.ShowFailureMessage(lReturnValue)
                                    Exit Sub
                                End If
                            Else
                                MessageBox.Show("Error , Try Later....")
                                Exit Sub
                            End If
                        ElseIf iSelectRange > 0 Then
                            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                            sw1.WriteLine(".Net btnShow_Click : Multiple message Printing")
                            sw1.Close()
                            lsbPrintedCodes.Visible = True
                            Label2.Visible = True
                            Dim i As Integer = 0
                            Dim dtCode As DataTable
                            Dim strPrintedCode As String = System.String.Empty
                            dtCode = dsCodes.Tables(0)
                            For i = 0 To iSelectRange - 1
                                strMessage = dtCode.Rows(i)(0).ToString
                                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                                sw1.WriteLine(".Net btnShow_Click : Message to Print is : " & strMessage)
                                sw1.WriteLine(".Net btnShow_Click : Calling function SendMessage(" & strMessage & "," & lPrinterID & ",15,81,1)")
                                sw1.Close()
                                strRetValue = SendMessage(strMessage, lPrinterID, 15, 81, 1)
                                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                                sw1.WriteLine(".Net btnShow_Click : Return form the function SendMessage ")
                                sw1.WriteLine(".Net btnShow_Click : The value return is  :" & strRetValue)
                                sw1.Close()
                                If strRetValue <> "" Then
                                    lReturnValue = CType(strRetValue, Long)
                                    If lReturnValue = ConstEnum.IJ_SUCCESS Then
                                        cmdText = "UPDATE Serials SET IsPrinted='Y' WHERE Serials='" & strMessage & "'  "
                                        'strPrintedCode = strPrintedCode & strMessage & ","
                                        'lblCodePrinted.Text = strPrintedCode.Substring(0, strPrintedCode.Length - 1).Trim
                                        lsbPrintedCodes.Items.Add(strMessage)
                                    Else
                                        Dim objmodFunctions As New modFunctions
                                        objmodFunctions.ShowFailureMessage(lReturnValue)
                                    End If
                                Else
                                    MessageBox.Show("Error , Try Later....")
                                    Exit Sub
                                End If
                                strMessage = System.String.Empty
                            Next
                            MessageBox.Show("Message Printed Success", "Batch Security System", MessageBoxButtons.OK)
                        Else

                        End If
                    Else
                        MessageBox.Show("Security Code not found according to given criteria...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Please Select Region ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'Else
                'MessageBox.Show("Please Select Packet  Size...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            Else
                MessageBox.Show("Please Select Product ...", "TBS Security Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
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
            '    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub cmbProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProduct.SelectedIndexChanged
        If Me.cmbProduct.SelectedValue <> Nothing Then
            Dim sProCode As String = cmbProduct.SelectedValue
            SetPacketsCombo(sProCode)
            If Me.cmbPacket.SelectedValue <> Nothing Then
                Dim iPacketSize As Integer = cmbPacket.Text
                SetComboRegions(sProCode, iPacketSize)
            End If
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
    Private Sub SetCombos()
        SetProductCombo()

        If cmbProduct.Items.Count > 0 Then
            Dim ProductPacket As String()
            Dim ProPack As String
            ProPack = cmbProduct.SelectedValue
            ProductPacket = ProPack.Split(" ")
            SetComboRegions(ProductPacket(0).ToString, ProductPacket(1).ToString)
        End If

        'By Saad 
        'If cmbProduct.Items.Count > 0 Then
        '    cmbProduct.SelectedIndex = 0
        '    Dim ProductCode As String = cmbProduct.SelectedValue
        '    SetPacketsCombo(ProductCode)
        '    If cmbPacket.Items.Count > 0 Then
        '        Dim PacketSize As Integer = cmbPacket.Text
        '        SetComboRegions(ProductCode, PacketSize)
        '    End If
        'End If
    End Sub

    Private Sub frmPrintCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetCombos()
        lsbPrintedCodes.Visible = False
        Label2.Visible = False
        ''lPrinterID = 12345
    End Sub
    Public Function SendMessage(ByVal MessageText As String, ByVal PrinterID As Integer, ByVal Position As Integer, ByVal Font As Integer, ByVal Bold As Integer) As String
        Dim retValue As String = System.String.Empty
        Dim strXml As String

        Try

            Dim sw1 As StreamWriter
            sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
            sw1.WriteLine(".Net : SendMessage(" & MessageText & "," & PrinterID & " , " & Position & "," & Font & "," & Bold & " ) ")

            sw1.WriteLine(".Net : SendMessage() Create XML")

            strXml = "<root>"
            strXml += "<printerid>" & PrinterID & "</printerid>"
            strXml += "<position>" & Position & "</position>"
            strXml += "<font>" & Font & "</font>"
            strXml += "<bold>" & Bold & "</bold>"
            strXml += "<messagetext>" & MessageText & "</messagetext>"
            strXml += "</root>"

            sw1.WriteLine(".Net : SendMessage()  XML is " & strXml)
            sw1.WriteLine(".Net : SendMessage() Create object of  InfiniImageVB.PrinterImaje ")
            sw1.Close()

            Dim obj As New InfiniImageVB.PrinterImaje
            Dim sResult As String
            If bTrace = True Then
                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                sw1.WriteLine(".Net : SendMessage() Calling  SendMessage2(" & strXml & "," & Application.StartupPath() & ")  of  InfiniImageVB.PrinterImaje ")
                sw1.Close()
                'sResult = obj.SendMessage2(strXml, Application.StartupPath())
                sResult = obj.SendMessage_9020(strXml, Application.StartupPath())
                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                sw1.WriteLine(".Net : SendMessage() Return from  SendMessage2(" & strXml & ")  of  InfiniImageVB.PrinterImaje ")
                sw1.WriteLine(".Net : SendMessage() The Return xml is " & sResult)
                sw1.WriteLine(".Net : SendMessage() Process completed")
                sw1.Close()
            Else
                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                sw1.WriteLine(".Net : SendMessage() Calling  SendMessage2(" & strXml & ")  of  InfiniImageVB.PrinterImaje ")
                sw1.Close()
                'sResult = obj.SendMessage2(strXml, "")
                sResult = obj.SendMessage_9020(strXml, "")
                sw1 = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\Log.txt", FileMode.Append))
                sw1.WriteLine(".Net : SendMessage() Return from  SendMessage2(" & strXml & ")  of  InfiniImageVB.PrinterImaje ")
                sw1.WriteLine(".Net : SendMessage() The Return xml is " & sResult)
                sw1.WriteLine(".Net : SendMessage() Process completed")
                sw1.Close()
            End If
            'sResult = obj.SendMessage2(strXml, Application.StartupPath())

            Dim myXMLDoc As New XmlDocument
            myXMLDoc.LoadXml(sResult)

            'retValue = myXMLDoc.SelectSingleNode("//retvalue").Value
            retValue = myXMLDoc.SelectSingleNode("//retvalue").InnerText

            ' Return retValue

            'Catch ex As Exception
            '    ''MessageBox.Show("Error " & ex.Message.ToString)
            '    Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\MyError.txt", FileMode.Append))
            '        sw.WriteLine("Error from .Net : , " & DateTime.Now & " , " & ex.Message)
            '    End Using
            '    MessageBox.Show("Error try Later....")
            '    Return ""
            'End Try
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
            '    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Return retValue
    End Function

    Private Sub lsbPrintedCodes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lsbPrintedCodes.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbProduct_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProduct.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbPacket_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPacket.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbRegions_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbRegions.KeyPress
        e.Handled = True
    End Sub


    Private Sub cmbRegions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegions.SelectedIndexChanged

    End Sub
End Class