Imports System.IO
Public Class modFunctions

    'This module will contain global function definitions
    '''''''''''''''''''''''''''''''''''''''
    'Function for showing the error message
    '''''''''''''''''''''''''''''''''''''''
    Public Sub ShowFailureMessage(ByVal lRet As Long)
        Dim strTemp As String
        Select Case lRet
            Case ConstEnum.ERROR_NO_MEMORY
                strTemp = "Error no memory"
            Case ConstEnum.ERROR_INVALID_ARGS
                strTemp = "Error invalid arguements"
            Case ConstEnum.ERROR_INVALID_CONNECTION
                strTemp = "Error invalid connection"
                ' Communication Errors
            Case ConstEnum.ERROR_OPENING_PORT
                strTemp = "Error opening port"
            Case ConstEnum.ERROR_COMM
                strTemp = "Error in communication"
            Case ConstEnum.ERROR_IN_READ
                strTemp = "Error in read"
            Case ConstEnum.ERROR_IN_WRITE
                strTemp = "Error in write"
            Case ConstEnum.ERROR_COMM_TIMEOUT
                strTemp = "Error com time out"
                ' Data Errors
            Case ConstEnum.ERROR_WRONG_DATA
                strTemp = "Error wrong data"
            Case ConstEnum.ERROR_WRONG_CRC
                strTemp = "Error wrong CRC"
                ' Printer Errors
            Case ConstEnum.ERROR_WRONG_PRINTER
                strTemp = "Error wrong printer"
            Case ConstEnum.ERROR_NACK
                strTemp = "Error NACK from printer"
                ' Miscellaneous
            Case ConstEnum.ERROR_DATA_OVERFLOW
                strTemp = "Error data over flow"
            Case ConstEnum.ERROR_NO_VERSIONINFO
                strTemp = "Error no version info"
            Case ConstEnum.ERROR_FINDING_PORTS
                strTemp = "Error in finding port"
            Case ConstEnum.ERROR_NO_PORT_DETECTED
                strTemp = "Error port not detected"
            Case 2000
                strTemp = "StartBuildMessage function failed"
            Case 2001
                strTemp = "Addblock function failed"
            Case 2002
                strTemp = "AddTextMessage function failed"
            Case 2003
                strTemp = "Copy CopyBufferToMessage function failed"
            Case Else
                strTemp = "General error"
        End Select
        MsgBox(strTemp, vbCritical, "Failed")
        If bTrace = True Then
            If Not Directory.Exists(Application.StartupPath() & "\Trace") Then
                'create it if it doesn't
                Directory.CreateDirectory(Application.StartupPath() & "\Trace")
            End If

            Using sw As StreamWriter = New StreamWriter(File.Open(Application.StartupPath() & "\Trace\MyError.txt", FileMode.Append))
                sw.WriteLine("Error from .VB : , " & DateTime.Now & " , " & strTemp)
                sw.Close()
            End Using
        End If
    End Sub

End Class
Public Enum ConstEnum

    'This module will contain constant declarations
    '''''''''''''''''''''''''''''''''''''''''''''''
    ' The one and only success code
    IJ_SUCCESS = &H0
    '  error code
    IJ_ERROR = &HFFFFFFFF
    ' Errors in detail (All negative values)
    ' General Errors
    ERROR_NO_MEMORY = &HA0000000
    ERROR_INVALID_ARGS = &HA1000000
    ERROR_INVALID_CONNECTION = &HA2000000
    ' Communication Errors
    ERROR_OPENING_PORT = &HB0000000
    ERROR_COMM = &HB1000000
    ERROR_IN_READ = &HB2000000
    ERROR_IN_WRITE = &HB3000000
    ERROR_COMM_TIMEOUT = &HB4000000
    ' Data Errors
    ERROR_WRONG_DATA = &HC0000000
    ERROR_WRONG_CRC = &HC1000000
    ' Printer Errors
    ERROR_WRONG_PRINTER = &HD0000000
    ERROR_NACK = &HD1000000
    ' Message building
    ERROR_START_BUILD_NOT_CALLED = &HF0000000
    ERROR_ADDBLOCK_NOT_CALLED = &HF1000000
    ERROR_DATABUFFER_OVERFLOW = &HF2000000
    ' Miscellaneous
    ERROR_FEATURE_NOT_SUPPORTED = &HE0000000
    ERROR_IN_FILE_NAME = &HE1000000
    ERROR_WRONG_FILE = &HE2000000
    ERROR_IN_FILE_OPENING = &HE3000000
    ERROR_DATA_OVERFLOW = &HE4000000
    ERROR_NO_VERSIONINFO = &HE5000000
    ERROR_FINDING_PORTS = &HE6000000
    ERROR_NO_PORT_DETECTED = &HE7000000
    ' Printer id
    S7PRINTERID = 2   'ID for S7 printer
    S7SPRINTERID = 3  'ID for S7 printer
    ' Port constants
    NOPARITY = 0
    EVENPARITY = 2
    ONESTOPBIT = 0
    TWOSTOPBIT = 2
    'constants for flow control for port operations
    SOFTWARE_CONTROL = &H4
    HARDWARE_CONTROL = &H2
    NO_CONTROL = 0
    'Constant for port number
    COM1 = 1
    COM2 = 2
    COM3 = 3
    COM4 = 4
    'maximum message length
    MAX_MSGLEN_4K = 4096
    'constants for printer set up
    S7_JET_STOP = &H0
    S7_JET_START = &H1
    S7_PRINTER_STOP = &H8
    S7_PRINTER_START_ON_STOP = &HC
    S7_PRINTER_START_ON_STANDBY = &HD
End Enum
