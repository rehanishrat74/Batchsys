Attribute VB_Name = "Common"



Public Const S9020PRINTERID = 5 'ID for 9020/9030 printer
Public Const IJ_SUCCESS = 0
Public Const MACHINE_RESTART = &HC
Public Const MACHINE_STOP = &H8
Public Const MAX_MSGLEN_4K = 4095

'Structure declarations for the High level API calls
'***************************************************

' Msg. structure used in message composition functions
' *************************************************
Public Type message
    bMsg(MAX_MSGLEN_4K) As Byte
    lPosition As Long
    lNumLines As Long
    lNumBarCode As Long
    lNumBlocks As Long
    bStartedBuild As Byte
    bAddedBlock As Byte
End Type

'////////////SerialInfo Structure//////////////
    Public Type SerialInfo
         nPort As Byte
         nBaudRate As Long
         bParity As Byte
         bStopbits As Byte
         bDatabits As Byte
         bFlowCtrl As Byte
    End Type

'////////////PrinterInfo Structure/////////////
    
    Public Type printerInfo
         bPrinterType As Long
         szSWVersionMajor As String * 4
         szHeadType As String * 4
    End Type

'Structure for Barcode information
'*********************************

Public Type S7_BarCodeInfo
    bSpecial As Byte
    bIdentification As Byte
    bTrameHeight As Byte
    bBolderization As Byte
    bNarrowBar As Byte
    bNarrowSpace As Byte
    bWideBar As Byte
    bWideSpace As Byte
    bVideoMode As Byte
    bControlByte As Byte
    bTextPos  As Byte
End Type


Public Type S7_PostdateInfo
    bUnit As Byte
    lPostDate As Long
End Type

Public Type MESSAGEINDICATOR_9020
    bGenParamsPresent As Byte
    bMsgPresent As Byte
    bPresenceCounterBase As Byte
    nNumCounters As Long
    nNumPostdates As Long
    nNumBarCodes As Long
End Type

Public Type GENPARAMINFO_9020
    bMsgModes As Byte
    bMultitopActivation As Byte
    bHegirienCalender As Byte
    bDifferentialSpeed As Byte
    lTachoDivisionOrDistBtwCells As Long
    lForwardMargin As Long
    lReturnMargin As Long
    lIntervalMargin As Long
    lPrintingSpeed As Long
    lMultilinePrinting As Long
End Type

Public Type COUNTERPARAMINFO_9020
    bFirstByte As Byte
    bSecondByte As Byte
    szStartValue As String * 10
    szEndValue As String * 10
    lStepCounter As Long
    lIncDivider As Long
    bFirstDigit As Byte
    bLastDigit As Byte
End Type

Public Type VARPARAMINFO_9020
    CounterParamInfo9020(14) As COUNTERPARAMINFO_9020
    S7PostdateInfo(5) As S7_PostdateInfo
    S7BarCodeInfo(2) As S7_BarCodeInfo
End Type

Public Type MESSAGEINFO_9020
    genParamInfo9020 As GENPARAMINFO_9020
    varParamInfo9020 As VARPARAMINFO_9020
    bMessage(MAX_MSGLEN_4K) As Byte
    nMsgLen As Long
End Type

Public Type AUTODETECTINFO
        szAutoDetectInfo  As String * 512
        dwPrinterID(16)   As Long
 End Type

'Declarations for the High level structures
'******************************************
    
Public mySerialInfo_9020 As SerialInfo
Public myPrinterInfo_9020 As printerInfo
Public g_lPrinterID As Long
Public myGenParamInfo9020 As GENPARAMINFO_9020
Public myVarParamInfo9020 As VARPARAMINFO_9020
Public myMessageIndicator9020 As MESSAGEINDICATOR_9020
Public myMessageInfo9020 As MESSAGEINFO_9020
Public myMessage_9020 As message
Public myAUTODETECTINFO As AUTODETECTINFO

'ComPort related functions
'*************************

Declare Function IJ_ConfigureAndStartPort Lib "IMASCP.dll" (ByRef mySerialInfo As SerialInfo, ByRef myPrinterInfo As printerInfo) As Long
Declare Function IJ_ClosePort Lib "IMASCP.dll" (ByVal nPrinterID As Long) As Long
Declare Function IJ_AutoSearchPrinter Lib "IMASCP.dll" (ByRef myAUTODETECTINFO As AUTODETECTINFO) As Integer
     
'9020 Printer operation Sending functions
 '**************************************
 
 Declare Function IJS7_PrinterSetup Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByVal nJetAndMachineState As Long) As Long
 Declare Function IJS9020_AddBlock Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef myMessage As message, ByVal nPosition As Long, ByVal nFont As Long, ByVal nBold As Long) As Long
 Declare Function IJS9020_AddTextMessage Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef myMessage As message, ByVal strTextMessage As String) As Long
 Declare Function IJS9020_CopyBufferToMessage Lib "IMASCP.dll" (ByRef myMessage As message, ByRef myMessageInfo As MESSAGEINFO_9020) As Long
 Declare Function IJS9020_StartBuildMessage Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef myMessage As message) As Long
 Declare Function IJS9020_SendMessage Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef messageIndicator9020 As MESSAGEINDICATOR_9020, ByRef messageInfo9020 As MESSAGEINFO_9020) As Long
 Declare Function IJS9020_AddBarcodeMessage Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef myMessage As message, ByVal bCode As Byte, ByRef bBarCodeData As Byte, ByVal lElementLen As Long) As Long
 Declare Function IJS9020_AddAutodateMessage Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef myMessage As message, ByVal bExtended As Byte, ByVal strAutodateInfo As String) As Long
 Declare Function IJS9020_AddLine Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef myMessage As message) As Long
 Declare Function IJS9020_AddTabulationMessage Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef myMessage As message, ByVal lNumEmptyRaster As Long) As Long
 
