Imports System
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography



Public Class DesBase64Encypt

    Private key() As Byte = {}
    Dim IV As Byte() = New Byte() {0, 0, 0, 0, 0, 0, 0, 0}
    Private Const EncryptionKey As String = "infini12"

    Public Function Decrypt(ByVal stringToDecrypt As String) As String

        Try
            Dim inputByteArray(stringToDecrypt.Length) As Byte
            key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey)
            Dim des As New DESCryptoServiceProvider
            des.Mode = CipherMode.CBC
            des.Padding = PaddingMode.Zeros
            inputByteArray = Convert.FromBase64String(stringToDecrypt)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch ex As Exception
            'oops - add your exception logic 
        End Try

    End Function

    Public Function Encrypt(ByVal stringToEncrypt As String) As String

        Try
            key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey)
            Dim des As New DESCryptoServiceProvider
            des.Mode = CipherMode.CBC
            des.Padding = PaddingMode.Zeros
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(stringToEncrypt)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            'oops - add your exception logic
        End Try

    End Function

End Class
