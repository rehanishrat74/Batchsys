VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "imaje9020"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
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

Private Function BarCode(message As String, sFilePath As String) As Boolean
'done
WriteLog "Barcode Start", sFilePath, "Barcode.txt"

Dim byteBarcode() As Byte
Dim isBarcodeAdded As Boolean

isBarcodeAdded = False
byteBarcode = message

WriteLog "LBound(byteBarcode)" & LBound(byteBarcode), sFilePath, "Barcode"
WriteLog "UBound(byteBarcode)" & UBound(byteBarcode), sFilePath, "Barcode"

For i = LBound(byteBarcode) To UBound(byteBarcode) - 1
If i <> 0 Then
i = i + 1
End If
    WriteLog "byteBarcode(" & i & ")" & byteBarcode(i), sFilePath, "Barcode"
    lRetValue = IJS9020_AddBarcodeMessage(g_lPrinterID, myMessage_9020, bCode, byteBarcode(i), 3)
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        WriteLog "AddBarcodeMessage function failed", sFilePath, "Barcode"
        MsgBox "AddBarcodeMessage function failed", vbOKOnly, "Error"
        isBarcodeAdded = False 'exit from the current procedure
        Exit Function
    End If
    isBarcodeAdded = True
Next
BarCode = isBarcodeAdded
End Function

'***************************************************************************************************************************************************
'9020                               Block Start
'***************************************************************************************************************************************************

Public Sub ClosePort(lPrinterID As String, sFilePath As String)
'done
 WriteLog "ClosePort Start", sFilePath, "Closeport.txt"
    Dim lRetValue As Long
    WriteLog "lPrinterID" & Val(lPrinterID), sFilePath, "Closeport.txt"
    WriteLog "Calling IJ_ClosePort", sFilePath, "Closeport.txt"
        lRetValue = IJ_ClosePort(Val(lPrinterID))
    WriteLog "Called IJ_ClosePort", sFilePath, "Closeport.txt"
    WriteLog "lRetValue = IJ_SUCCESS " & lRetValue = IJ_SUCCESS, sFilePath, "Closeport.txt"
       If lRetValue = IJ_SUCCESS Then
       MsgBox ("Port closed")
       Else
       MsgBox ("Error in closing the port!")
       End If
End Sub

Public Sub SendMessage_9020(messageInfo As String, sFilePath As String)
    'done
    On Error GoTo ErrorMessage
    WriteLog "SendMessage_9020 Start", sFilePath, "SendMessage_9020.txt"
      Dim lRetValue As Long
      Dim message() As String
      
      
      message() = Split(messageInfo, ",")
      
      'message (0) printer ID
      'message (0) Message
      
      WriteLog "printer ID -> " & message(0), sFilePath, "SendMessage_9020.txt"
      WriteLog "Message -> " & message(1), sFilePath, "SendMessage_9020.txt"
      g_lPrinterID = message(0)
    
    
    ' Initialise the message indicator structure
    
    myMessageIndicator9020.bGenParamsPresent = 1
    myMessageIndicator9020.bMsgPresent = 1
    myMessageIndicator9020.bPresenceCounterBase = 0
    myMessageIndicator9020.nNumBarCodes = 1
    myMessageIndicator9020.nNumCounters = 0
    myMessageIndicator9020.nNumPostdates = 1
    
    ' Initialise the message info structure
    myMessageInfo9020.genParamInfo9020.bMsgModes = 1
    myMessageInfo9020.genParamInfo9020.bMultitopActivation = 1
    myMessageInfo9020.genParamInfo9020.bHegirienCalender = 0
    myMessageInfo9020.genParamInfo9020.bDifferentialSpeed = 0
    myMessageInfo9020.genParamInfo9020.lTachoDivisionOrDistBtwCells = 30
    myMessageInfo9020.genParamInfo9020.lForwardMargin = 100
    myMessageInfo9020.genParamInfo9020.lReturnMargin = 100
    myMessageInfo9020.genParamInfo9020.lIntervalMargin = 10
    myMessageInfo9020.genParamInfo9020.lPrintingSpeed = 100
    myMessageInfo9020.genParamInfo9020.lMultilinePrinting = 0
    
     'Filling postdate
    myMessageInfo9020.varParamInfo9020.S7PostdateInfo(0).bUnit = 0 'in days
    myMessageInfo9020.varParamInfo9020.S7PostdateInfo(0).lPostDate = 365 'one year
    
    'filling barcode
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bBolderization = 1  'bolderization 1
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bIdentification = 0 '2/5 interlaced code
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bNarrowBar = 1      'narrow bar width 1
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bNarrowSpace = 1    'narrow space width 1
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bTrameHeight = 16   'trame height
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bWideBar = 2        'wide bar 2
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bWideSpace = 2      'wide space 2
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bControlByte = 1    'with control byte
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bSpecial = 0        'standard code
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bVideoMode = 0      'video mode no
    myMessageInfo9020.varParamInfo9020.S7BarCodeInfo(0).bTextPos = 1
    
   'start of building message
    
    WriteLog "Calling IJS9020_StartBuildMessage", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_StartBuildMessage(g_lPrinterID, myMessage_9020)
    WriteLog "Called IJS9020_StartBuildMessage", sFilePath, "SendMessage_9020.txt"
    
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        MsgBox "StartBuildMessage function failed", vbOKOnly, "Error"
        Unload Me
        Exit Sub
        'exit from the current procedure
    End If
    
    'adding block with font Latin Ind.5 (81) and vertical position 15 and bolderization 1
    WriteLog "Calling IJS9020_AddBlock", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_AddBlock(g_lPrinterID, myMessage_9020, 8, 81, 1)
    WriteLog "Called IJS9020_AddBlock", sFilePath, "SendMessage_9020.txt"
    
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        MsgBox "Addblock function failed", vbOKOnly, "Error"
        Unload Me
        Exit Sub        'exit from the current procedure
    End If
    'adding text "Mfg Date"
    
    WriteLog "Calling IJS9020_AddTextMessage", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_AddTextMessage(g_lPrinterID, myMessage_9020, "Mfg Date : ")
    WriteLog "Called IJS9020_AddTextMessage", sFilePath, "SendMessage_9020.txt"
    
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        MsgBox "AddTextMessage function failed", vbOKOnly, "Error"
        Unload Me
        Exit Sub        'exit from the current procedure
    End If
    
    'adding  Date , not extnended, for date in DD/MM/YY format
    WriteLog "Calling IJS9020_AddAutodateMessage", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_AddAutodateMessage(g_lPrinterID, myMessage_9020, 0, "DD|/|MM|/|YY|")
    WriteLog "Called IJS9020_AddAutodateMessage", sFilePath, "SendMessage_9020.txt"
    
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        MsgBox "AddAutodateMessage function failed", vbOKOnly, "Error"
        Unload Me
        Exit Sub        'exit from the current procedure
    End If
    'adding line 2
    WriteLog "Calling IJS9020_AddLine", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_AddLine(g_lPrinterID, myMessage_9020)
    WriteLog "Called IJS9020_AddLine", sFilePath, "SendMessage_9020.txt"
    
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        MsgBox "AddLine function failed", vbOKOnly, "Error"
        Unload Me
        Exit Sub        'exit from the current procedure
    End If
    
    'adding block with font Latin Ind.5 (81) and vertical position 8 and bolderization 1
    WriteLog "Calling IJS9020_AddBlock", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_AddBlock(g_lPrinterID, myMessage_9020, 1, 81, 1)
    WriteLog "Called IJS9020_AddBlock", sFilePath, "SendMessage_9020.txt"
    
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        MsgBox "Addblock function failed", vbOKOnly, "Error"
        Unload Me
        Exit Sub        'exit from the current procedure
    End If
    'adding text "Batch No : "
   WriteLog "Calling IJS9020_AddTextMessage", sFilePath, "SendMessage_9020.txt"
   lRetValue = IJS9020_AddTextMessage(g_lPrinterID, myMessage_9020, "Exp Date : ")
   WriteLog "Called IJS9020_AddTextMessage", sFilePath, "SendMessage_9020.txt"
   
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        MsgBox "AddTextMessage function failed", vbOKOnly, "Error"
        Unload Me
        Exit Sub        'exit from the current procedure
   End If
   
    'adding post date , not extnended, for post date in DD/MM/YY format
    WriteLog "Calling IJS9020_AddAutodateMessage", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_AddAutodateMessage(g_lPrinterID, myMessage_9020, 0, "PM1|/|PMY1|/|PY1|")
    WriteLog "Called IJS9020_AddAutodateMessage", sFilePath, "SendMessage_9020.txt"
    
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        MsgBox "AddAutodateMessage function failed", vbOKOnly, "Error"
        Unload Me
        Exit Sub        'exit from the current procedure
    End If
    'adding tabulation of 20 rasters
    WriteLog "Calling IJS9020_AddTabulationMessage", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_AddTabulationMessage(g_lPrinterID, myMessage_9020, 20)
    WriteLog "Called IJS9020_AddTabulationMessage", sFilePath, "SendMessage_9020.txt"
    
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        MsgBox "IJS9020_AddTabulationMessage function failed", vbOKOnly, "Error"
        Unload Me
        Exit Sub        'exit from the current procedure
    End If
    
    'adding barcode
    'bCode = 1  'first barcode
    'bCodeData(0) = &H31 'to code 123
    'bCodeData(1) = &H32
    'bCodeData(2) = &H33
    WriteLog "Calling IJS9020_AddTextMessage", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_AddTextMessage(g_lPrinterID, myMessage_9020, message(1))
    WriteLog "Called IJS9020_AddTextMessage", sFilePath, "SendMessage_9020.txt"
    'lRetValue = IJS9020_AddBarcodeMessage(g_lPrinterID, myMessage_9020, bCode, bCodeData(0), 3)
     'If BarCode <> True Then
        'MsgBox "AddBarcodeMessage function failed", vbOKOnly, "Error"
        'Unload Me
        'Exit Sub        'exit from the current procedure
     'End If
     
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
         MsgBox "AddTextMessage function failed", vbOKOnly, "Error"
      '  Unload Me
        Exit Sub        'exit from the current procedure
    End If
    
    'Coppying the message array to message info structure
    WriteLog "Calling IJS9020_AddTextMessage", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_CopyBufferToMessage(myMessage_9020, myMessageInfo9020)
    WriteLog "Called IJS9020_AddTextMessage", sFilePath, "SendMessage_9020.txt"
    
    If lRetValue <> IJ_SUCCESS Then
        'if function failed
        MsgBox "IJS9020_CopyBufferToMessage function failed", vbOKOnly, "Error"
        Unload Me
        Exit Sub        'exit from the current procedure
    End If
    WriteLog "Calling IJS9020_SendMessage", sFilePath, "SendMessage_9020.txt"
    lRetValue = IJS9020_SendMessage(g_lPrinterID, myMessageIndicator9020, myMessageInfo9020)
    WriteLog "Called IJS9020_SendMessage", sFilePath, "SendMessage_9020.txt"
    If lRetValue = IJ_SUCCESS Then
        
        WriteLog "Message sent Success", sFilePath, "SendMessage_9020.txt"
    Else
        WriteLog "Message sent Fails", sFilePath, "SendMessage_9020.txt"
        'if function failed
        'ShowFailureMessage lRetValue
        'WriteLog lRetValue
    End If
    WriteLog "SendMessage_9020 End", sFilePath, "SendMessage_9020.txt"
ErrorMessage:
        WriteLog "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description, sFilePath & "\Trace", "SendMessage_9020.txt"
End Sub


Public Function SetPrinter(printerInfo As String, sFilePath As String) As String
'done
    WriteLog "SetPrinter Start", sFilePath, "SetPrinter.txt"
    
    Dim nPort As Integer
    Dim strPort As String
    Dim prntInfo() As String
    prntInfo() = Split(printerInfo, ",")
    
    'prntInfo (0) BaudRate
    'prntInfo (1) Com Port
    WriteLog "BaudRate" & prntInfo(0), sFilePath, "SetPrinter.txt"
    WriteLog "Com Port" & prntInfo(0), sFilePath, "SetPrinter.txt"
    
    strPort = prntInfo(1)
    nPort = Val(strPort)
    mySerialInfo_9020.nPort = nPort
    
    'Select Case cboBaudRate.Text
    Select Case prntInfo(0)
        Case "38400"
        WriteLog "Case" & prntInfo(0), sFilePath, "SetPrinter.txt"
           mySerialInfo_9020.nBaudRate = 38400
        Case "19200"
        WriteLog "Case" & prntInfo(0), sFilePath, "SetPrinter.txt"
           mySerialInfo_9020.nBaudRate = 19200
        Case "9600"
        WriteLog "Case" & prntInfo(0), sFilePath, "SetPrinter.txt"
           mySerialInfo_9020.nBaudRate = 9600
    End Select
    
   mySerialInfo_9020.bStopbits = 0
   mySerialInfo_9020.bParity = 0
   mySerialInfo_9020.bDatabits = 8
    
    'Set the printer id as 9020
    myPrinterInfo_9020.bPrinterType = S9020PRINTERID
     WriteLog "Calling IJ_ConfigureAndStartPort" & prntInfo(0), sFilePath, "SetPrinter.txt"
    g_lPrinterID = IJ_ConfigureAndStartPort(mySerialInfo_9020, myPrinterInfo_9020)
     WriteLog "Called IJ_ConfigureAndStartPort" & prntInfo(0), sFilePath, "SetPrinter.txt"
     WriteLog "return value of g_lPrinterID" & CStr(g_lPrinterID), sFilePath, "SetPrinter.txt"
     
    If g_lPrinterID <= 0 Then
        MsgBox ("Error in opening the port!")
    Else
        MsgBox ("Port opened")
    End If
   SetPrinter = g_lPrinterID
   WriteLog "SetPrinter End", sFilePath, "SetPrinter.txt"
End Function

Public Function AutoSetPrinter(sFilePath As String) As String
'done
    On Error GoTo ErrorMessage
WriteLog "AutoSetPrinter Start", sFilePath, "AutoSetPrinter.txt"
    Dim aPrinterID() As Long
    Dim i As Integer
    Dim lPrinterID As Long
    Dim strReturn As String
    Dim nRet As Integer
    
   ''lPrinterID = CLng(PrinterID)
   WriteLog "Calling IJ_AutoSearchPrinter", sFilePath, "AutoSetPrinter.txt"
    nRet = IJ_AutoSearchPrinter(myAUTODETECTINFO)
    WriteLog "Called IJ_AutoSearchPrinter", sFilePath, "AutoSetPrinter.txt"
    
    aPrinterID = myAUTODETECTINFO.dwPrinterID()
    WriteLog "Printers Found --> " & CStr(nRet), sFilePath, "AutoSetPrinter.txt"
    strReturn = "<root><retvalue>" & nRet & "</retvalue>"

    For i = 0 To UBound(aPrinterID)
        strReturn = strReturn & "<lPrinterId>" & aPrinterID(i) & "</lPrinterId>"
    Next
        strReturn = strReturn & "<szAutoDetectInfo>" & CStr(myAUTODETECTINFO.szAutoDetectInfo) & "</szAutoDetectInfo>"
    strReturn = strReturn & "</root>"
    AutoSetPrinter = strReturn
    Exit Function
    WriteLog "AutoSetPrinter End", sFilePath, "AutoSetPrinter.txt"
ErrorMessage:
    WriteLog "Error from vb6 , Function : AutoSearchPrinter , Error number : " & Err.Number & " and Description : " & Err.Description, sFilePath, "AutoSetPrinter.txt"
End Function

'***************************************************************************************************************************************************
'9020                               Block End
'***************************************************************************************************************************************************
