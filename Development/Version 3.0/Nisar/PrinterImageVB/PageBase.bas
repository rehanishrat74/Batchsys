Attribute VB_Name = "PageBase"
Public Sub WriteLog(message As String, folder As String, fileName As String)

Dim fso As New FileSystemObject
If Not fso.FolderExists(folder) Then
fso.CreateFolder folder
End If
    If fso.FileExists(folder & "\" & fileName) Then
            Open folder & "\" & fileName For Append As #1
        Write #1, message
    Else
        Open folder & "\" & fileName For Output As #1
        Write #1, message
    End If
Close #1
End Sub
