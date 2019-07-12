Imports System.IO
Imports System.Xml

Public Class frmLightSecurityCode

    Private Sub btnUploadCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadCodes.Click
        Dim FileName As String
        Try
            If txtFilePath.Text = Nothing Then
                MessageBox.Show("Select File first", "Light Security Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If Not File.Exists(txtFilePath.Text) Then
                    MessageBox.Show("File not exists,Select the correct path", "Light Security Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    FileName = txtFilePath.Text
                    Dim iLastIndex As Integer = FileName.LastIndexOf(".") + 1
                    Dim sExtention As String = System.String.Empty
                    sExtention = FileName.Substring(iLastIndex, FileName.Length - iLastIndex)
                    'Dim sFileExtension() As String = FileName.Split(".")
                    'If sFileExtension.Length > 1 And sFileExtension(1) = "txt" Then
                    If sExtention <> "" And sExtention = "txt" Then
                        Dim sr As StreamReader = File.OpenText(FileName)
                        Dim myText As String = System.String.Empty
                        myText += "<Doc>"
                        Do While Not sr.EndOfStream
                            Dim arrSerIds() As String = sr.ReadLine.Split(",")
                            myText += "<Product Code=" & Chr(34) & arrSerIds(0) & Chr(34) & " Id=" & Chr(34) & arrSerIds(1) & Chr(34) & " />"
                        Loop
                        sr.Close()
                        myText += "</Doc>"
                        Select Case Common.UpLoadSecutrityCodes(myText).ToLower
                            Case "success"
                                MessageBox.Show("Codes Upload Successfully")
                            Case "failed"
                                MessageBox.Show("Codes Not Upload")
                            Case "duplicate record"
                                MessageBox.Show("Duplicated Record not allow to upload, Codes Not Upload")
                        End Select
                    Else
                        MessageBox.Show("Only .txt file allow", "Light Security Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch es As Exception
            MessageBox.Show(es.Message)
        End Try
        'Dim FileName As String
        'Try
        '    With OpenFileDialog1
        '        .InitialDirectory = Application.StartupPath()
        '        .Filter = "Text files (*.txt)|*.txt"
        '        If .ShowDialog() = Windows.Forms.DialogResult.OK Then
        '            FileName = .FileName
        '            Dim sr As StreamReader = File.OpenText(FileName)
        '            Dim myText As String = System.String.Empty

        '            'myText += "<NewDataSet>"
        '            myText += "<Doc>"
        '            Do While Not sr.EndOfStream
        '                Dim arrSerIds() As String = sr.ReadLine.Split(",")
        '                myText += "<Product Code=" & Chr(34) & arrSerIds(0) & Chr(34) & " Id=" & Chr(34) & arrSerIds(1) & Chr(34) & " />"
        '            Loop
        '            sr.Close()
        '            myText += "</Doc>"
        '            If Common.UpLoadSerials(myText) Then
        '                MessageBox.Show("Codes Upload Successfully")
        '            Else
        '                MessageBox.Show("Codes Not Upload")
        '            End If
        '        End If
        '    End With
        'Catch es As Exception
        '    MessageBox.Show(es.Message)
        'End Try


    End Sub

    Private Sub btnFileBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileBrowse.Click
        Dim FileName As String
        Try
            With OpenFileDialog1
                .InitialDirectory = Application.StartupPath()
                .Filter = "Text files (*.txt)|*.txt"
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    FileName = .FileName
                    txtFilePath.Text = FileName
                End If
            End With
        Catch es As Exception
            MessageBox.Show(es.Message)
        End Try
    End Sub
    Private Sub txtFilePath_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilePath.Leave
        If txtFilePath.Text = "" Then
            txtFilePath.Text = "[Enter File Path here...]"
        End If
    End Sub

    Private Sub frmLightSecurityCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
