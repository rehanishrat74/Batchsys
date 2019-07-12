Imports System.IO
Imports System.Security.Cryptography


Public Class Security
    Private Const keyValue As String = "Nisar9181"

    Private Key As Byte()

    Private Vector As Byte()

    'Public Property EncryptedText()
    '    Get
    '        Return Me._encryptedText
    '    End Get
    '    Set(ByVal value)
    '        Me._encryptedText = value
    '    End Set
    'End Property

    'Public Property DecryptedText()
    '    Get
    '        Return Me._decryptedText
    '    End Get
    '    Set(ByVal value)
    '        Me._decryptedText = value
    '    End Set
    'End Property

   
    Public Function EncryptText(ByVal sText As String) As String
        Try

            Dim original As String = sText

            ' Create a new instance of the RijndaelManaged
            ' class.  This generates a new key and initialization 
            ' vector (IV).
            Dim myRijndael As New RijndaelManaged()

            GenerateKey()



            ' Encrypt the string to an array of bytes.
            Dim encrypted As Byte() = encryptStringToBytes_AES(original, key, Vector)



            Dim strReturn = Convert.ToBase64String(encrypted)
            Return strReturn
        Catch ex As Exception
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net : ,Class : Security ,Funcation Name : EncryptText , " & DateTime.Now & " , " & ex.Message)
                    sw.Close()
                End Using
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return ""
        End Try
    End Function

    Public Function DecryptText(ByVal strText) As String
        Try
            Dim myRijndael As New RijndaelManaged()
            Dim enc As Byte() = Convert.FromBase64String(strText)
            GenerateKey()
            Dim roundtrip As String = decryptStringFromBytes_AES(enc, key, Vector)
            ''MessageBox.Show(roundtrip)
            Return roundtrip
        Catch ex As Exception
            If bTrace = True Then
                If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                    Directory.CreateDirectory(Application.StartupPath() & "\Trace")
                End If

                Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                    sw.WriteLine("Error from .Net : ,Class : Security ,Funcation Name : EncryptText , " & DateTime.Now & " , " & ex.Message)
                    sw.Close()
                End Using
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Plese try later....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return ""
        End Try
    End Function

    Private Sub GenerateKey()



        Dim sha As New SHA384Managed()

        Dim asc As New System.Text.ASCIIEncoding()

        'Dim b As Byte() = sha.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password))
        Dim b As Byte() = sha.ComputeHash(asc.GetBytes(keyValue))



        Dim read() As [Byte] = New Byte(32) {}

        Key = New Byte(31) {}

        Vector = New Byte(15) {}



        Array.Copy(b, 0, Key, 0, 32)

        Array.Copy(b, 32, Vector, 0, 16)

    End Sub

    Function encryptStringToBytes_AES(ByVal plainText As String, ByVal Key() As Byte, ByVal IV() As Byte) As Byte()
        ' Check arguments.
        If plainText Is Nothing OrElse plainText.Length <= 0 Then
            Throw New ArgumentNullException("plainText")
        End If
        If Key Is Nothing OrElse Key.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        If IV Is Nothing OrElse IV.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        ' Declare the streams used
        ' to encrypt to an in memory
        ' array of bytes.
        Dim msEncrypt As MemoryStream = Nothing
        Dim csEncrypt As CryptoStream = Nothing
        Dim swEncrypt As StreamWriter = Nothing

        ' Declare the RijndaelManaged object
        ' used to encrypt the data.
        Dim aesAlg As RijndaelManaged = Nothing

        ' Declare the bytes used to hold the
        ' encrypted data.
        Dim encrypted As Byte() = Nothing

        Try
            ' Create a RijndaelManaged object
            ' with the specified key and IV.
            aesAlg = New RijndaelManaged()
            aesAlg.Key = Key
            aesAlg.IV = IV

            ' Create a decrytor to perform the stream transform.
            Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)

            ' Create the streams used for encryption.
            msEncrypt = New MemoryStream()
            csEncrypt = New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
            swEncrypt = New StreamWriter(csEncrypt)

            'Write all data to the stream.
            swEncrypt.Write(plainText)
        Catch ex As Exception


        Finally
            ' Clean things up.
            ' Close the streams.
            If Not (swEncrypt Is Nothing) Then
                swEncrypt.Close()
            End If
            If Not (csEncrypt Is Nothing) Then
                csEncrypt.Close()
            End If
            If Not (msEncrypt Is Nothing) Then
                msEncrypt.Close()
            End If
            ' Clear the RijndaelManaged object.
            If Not (aesAlg Is Nothing) Then
                aesAlg.Clear()
            End If
        End Try
        ' Return the encrypted bytes from the memory stream.
        Return msEncrypt.ToArray()

    End Function

    Function decryptStringFromBytes_AES(ByVal cipherText() As Byte, ByVal Key() As Byte, ByVal IV() As Byte) As String
        ' Check arguments.
        If cipherText Is Nothing OrElse cipherText.Length <= 0 Then
            Throw New ArgumentNullException("cipherText")
        End If
        If Key Is Nothing OrElse Key.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        If IV Is Nothing OrElse IV.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        ' TDeclare the streams used
        ' to decrypt to an in memory
        ' array of bytes.
        Dim msDecrypt As MemoryStream = Nothing
        Dim csDecrypt As CryptoStream = Nothing
        Dim srDecrypt As StreamReader = Nothing

        ' Declare the RijndaelManaged object
        ' used to decrypt the data.
        Dim aesAlg As RijndaelManaged = Nothing

        ' Declare the string used to hold
        ' the decrypted text.
        Dim plaintext As String = Nothing

        Try
            ' Create a RijndaelManaged object
            ' with the specified key and IV.
            aesAlg = New RijndaelManaged()
            aesAlg.Key = Key
            aesAlg.IV = IV

            ' Create a decrytor to perform the stream transform.
            Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

            ' Create the streams used for decryption.
            msDecrypt = New MemoryStream(cipherText)
            csDecrypt = New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
            srDecrypt = New StreamReader(csDecrypt)

            ' Read the decrypted bytes from the decrypting stream
            ' and place them in a string.
            plaintext = srDecrypt.ReadToEnd()
        Finally
            ' Clean things up.
            ' Close the streams.
            If Not (srDecrypt Is Nothing) Then
                srDecrypt.Close()
            End If
            If Not (csDecrypt Is Nothing) Then
                csDecrypt.Close()
            End If
            If Not (msDecrypt Is Nothing) Then
                msDecrypt.Close()
            End If
            ' Clear the RijndaelManaged object.
            If Not (aesAlg Is Nothing) Then
                aesAlg.Clear()
            End If
        End Try
        Return plaintext

    End Function
End Class
