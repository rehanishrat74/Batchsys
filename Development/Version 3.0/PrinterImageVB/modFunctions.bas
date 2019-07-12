Attribute VB_Name = "modFunctions"
'This module will contain global function definitions
'''''''''''''''''''''''''''''''''''''''
'Function for showing the error message
'''''''''''''''''''''''''''''''''''''''
Public Sub ShowFailureMessage(lRet As Long)
    Dim strTemp As String
    Select Case lRet
        Case ERROR_NO_MEMORY
            strTemp = "Error no memory"
        Case ERROR_INVALID_ARGS
            strTemp = "Error invalid arguements"
        Case ERROR_INVALID_CONNECTION
            strTemp = "Error invalid connection"
        ' Communication Errors
        Case ERROR_OPENING_PORT
            strTemp = "Error opening port"
        Case ERROR_COMM
            strTemp = "Error in communication"
        Case ERROR_IN_READ
            strTemp = "Error in read"
        Case ERROR_IN_WRITE
            strTemp = "Error in write"
        Case ERROR_COMM_TIMEOUT
            strTemp = "Error com time out"
        ' Data Errors
        Case ERROR_WRONG_DATA
            strTemp = "Error wrong data"
        Case ERROR_WRONG_CRC
            strTemp = "Error wrong CRC"
        ' Printer Errors
        Case ERROR_WRONG_PRINTER
            strTemp = "Error wrong printer"
        Case ERROR_NACK
            strTemp = "Error NACK from printer"
        ' Miscellaneous
        Case ERROR_DATA_OVERFLOW
            strTemp = "Error data over flow"
        Case ERROR_NO_VERSIONINFO
            strTemp = "Error no version info"
        Case ERROR_FINDING_PORTS
            strTemp = "Error in finding port"
        Case ERROR_NO_PORT_DETECTED
            strTemp = "Error port not detected"
        Case Else
            strTemp = "General error"
    End Select
    MsgBox strTemp, vbCritical, "Failed"
End Sub
