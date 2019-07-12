Attribute VB_Name = "modStructDecl"
'This module will structures and global variable declarations
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'Structure declarations
'SerialInfo Structure
Public Type IJ_SerialInfo1
     nPort As Byte
     nBaudRate As Long
     bParity As Byte
     bStopbits As Byte
     bDatabits As Byte
     bFlowCtrl As Byte
End Type
'PrinterInfo Structure
Public Type IJ_PrinterInfo1
     bPrinterType As Byte
     szSWVersionMajor As String * 4
     szSWVersionMinor As String * 4
End Type
'S7 Printer status info structure
Public Type IJS7_PrinterStatusInfo
    bPrinterState As Byte
    lRefPressure As Long
    lAccumPressure As Long
    lBufferPressure As Long
    lTemp As Long
    lJet1Speed As Long
    lJet2Speed As Long
End Type
'Structure for Software version
Public Type IJS7_SWVersionInfo
    szInkProcessorVer As String * 3
    lAppType1 As Long
    szPrintProcessorVer As String * 3
    lAppType2 As Long
End Type
'Message structure indicator
Public Type IJS7_MessageIndicator
    bGenParamsPresent As Byte
    bMsgPresent As Byte
    bNumCounters As Long
    bNumPostdates As Long
    bNumBarCodes As Long
End Type
'Structure for Counter parameters
Public Type IJS7_CounterParamInfo
    bFisrtByte As Byte
    bSecondByte As Byte
    lStartValue As Long
    lEndValue As Long
    lCounterStep As Long
    lIncDivider As Long
End Type
'Structure for post date paramters
Public Type IJS7_PostdateInfo
    bUnit As Byte
    lPostDate As Long
End Type
'Structure for Barcode information
Public Type IJS7_BarCodeInfo
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
'Structure for variable parameters information
Public Type IJS7_VarParamInfo
    arrS7CounterParamInfo(14) As IJS7_CounterParamInfo
    arrPostDate(5) As IJS7_PostdateInfo
    arrS7BarCodeInfo(2) As IJS7_BarCodeInfo
End Type
'Structure for General parameters
Public Type IJS7_GenParamInfo
    bGenParams As Byte
    bMuttitopActivation As Byte
    lTachoDivision As Long
    lForwardMargin As Long
    lReturnMargin As Long
    lIntervalMargin As Long
    lPrintingSpeed As Long
    lMultilinePrinting As Long
End Type
' S7 Message information
Public Type IJS7_MessageInfo
    myS7GenParamInfo As IJS7_GenParamInfo
    myS7VarParamInfo As IJS7_VarParamInfo
    bMessage(MAX_MSGLEN_4K - 1) As Byte
    lMsgLen As Long
End Type
'Structure used for message building calls
Public Type IJS7_Message
    bMsg(MAX_MSGLEN_4K - 1) As Byte
    lNextPos As Long
    lNumLines As Long
    lNumBarCodes As Long
    lNumBlocks As Long
    bStartedBuild As Byte
    bAddedBlock As Byte
End Type

'Public Type AUTODETECTINFO
   ' szAutoDetectInfo As String * 4
    'dwPrinterID() As Long
'End Type


'Global variables declarations
Public lReturn As Long              'To store return value of API call
Public g_lPrinterID As Long         'To store the printer ID
Public sPrnt As String              'To store the printer type
Public sPort As String              'To store the port name
Public sSWVersion As String         'To store the s/w version
Public iNoOfCountersS7 As Integer   'To store the no. of counters
'Global structures
Public mySerialInfo As IJ_SerialInfo        'Serial info structure
Public myPrinterInfo As IJ_PrinterInfo     'Printer info structure
Public myS7PrinterStatusInfo As IJS7_PrinterStatusInfo  'printer status info structure
Public myS7SWVersionInfo As IJS7_SWVersionInfo          's/w version info
Public myS7MessageIndicator As IJS7_MessageIndicator    'message structure indicator
Public myS7MessageInfo As IJS7_MessageInfo              'message info structure
Public myMessage As IJS7_Message                        'message structure used by message building call
Public aAutoDetect As AUTODETECTINFO



'Printer declaration
'9020

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
    
    Public Type PrinterInfo
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
Public myPrinterInfo_9020 As PrinterInfo
'Public g_lPrinterID As Long
Public myGenParamInfo9020 As GENPARAMINFO_9020
Public myVarParamInfo9020 As VARPARAMINFO_9020
Public myMessageIndicator9020 As MESSAGEINDICATOR_9020
Public myMessageInfo9020 As MESSAGEINFO_9020
Public myMessage_9020 As message
Public myAUTODETECTINFO As AUTODETECTINFO
