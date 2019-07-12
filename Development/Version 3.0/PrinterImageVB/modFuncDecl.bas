Attribute VB_Name = "modFuncDecl"
'This module will contain API function declarations
'''''''''''''''''''''''''''''''''''''''''''''''''
'ComPort related functions
Declare Function IJ_ConfigureAndStartPort Lib "IMASCP.dll" (mySerInfo As IJ_SerialInfo, _
          myPrinterInfo As IJ_PrinterInfo) As Long
Declare Function IJ_ClosePort Lib "IMASCP.dll" (ByVal lPrinterID As Long) As Long
'Sendings
Declare Function IJS7_PrinterSetup Lib "IMASCP.dll" _
    (ByVal lPrinterID As Long, ByVal nJetAndMachineState As Long) As Long
Declare Function IJS7_SendCounterInitialization Lib "IMASCP.dll" _
   (ByVal lPrinterID As Long, ByVal lCounter As Long) As Long
'*************************************************************************
'S7
Declare Function IJS7_SendMessage Lib "IMASCP.dll" _
    (ByVal lPrinterID As Long, ByRef myS7MessageIndicator As IJS7_MessageIndicator, ByRef myS7MessageInfo As IJS7_MessageInfo) As Long
'*************************************************************************
'9020 Printer operation Sending functions
 '**************************************
 'Declare Function IJS7_PrinterSetup Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByVal nJetAndMachineState As Long) As Long
 Declare Function IJS9020_AddBlock Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef myMessage As Message, ByVal nPosition As Long, ByVal nFont As Long, ByVal nBold As Long) As Long
 Declare Function IJS9020_AddTextMessage Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef myMessage As Message, ByVal strTextMessage As String) As Long
 Declare Function IJS9020_CopyBufferToMessage Lib "IMASCP.dll" (ByRef myMessage As Message, ByRef myMessageInfo As MESSAGEINFO_9020) As Long
 Declare Function IJS9020_StartBuildMessage Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef myMessage As Message) As Long
 Declare Function IJS9020_SendMessage Lib "IMASCP.dll" (ByVal lPrinterID As Long, ByRef messageIndicator9020 As MESSAGEINDICATOR_9020, ByRef messageInfo9020 As MESSAGEINFO_9020) As Long
 
'***********************************************************************
    
'Getings
Declare Function IJS7_GetPrinterParams Lib "IMASCP.dll" _
   (ByVal lPrinterID As Long, ByRef myS7PrinterStatusInfo As IJS7_PrinterStatusInfo) As Long
Declare Function IJS7_GetSoftwareVersion Lib "IMASCP.dll" _
   (ByVal lPrinterID As Long, ByRef myS7SWVersionInfo As IJS7_SWVersionInfo) As Long
'Message Building calls
Declare Function IJS7_StartBuildMessage Lib "IMASCP.dll" _
  (ByVal lPrinterID As Long, ByRef myS7Message As IJS7_Message) As Long
Declare Function IJS7_AddLine Lib "IMASCP.dll" _
   (ByVal lPrinterID As Long, ByRef myS7Message As IJS7_Message) As Long
Declare Function IJS7_AddBlock Lib "IMASCP.dll" _
   (ByVal lPrinterID As Long, ByRef myS7Message As IJS7_Message, _
     ByVal lPosition As Long, ByVal lFont As Long, ByVal lBolderization As Long) As Long
Declare Function IJS7_AddTextMessage Lib "IMASCP.dll" _
  (ByVal lPrinterID As Long, ByRef myS7Message As IJS7_Message, _
     ByVal strText As String) As Long
Declare Function IJS7_AddCounterMessage Lib "IMASCP.dll" _
   (ByVal lPrinterID As Long, ByRef myS7Message As IJS7_Message, _
     ByVal lCounterNum As Long) As Long
Declare Function IJS7_AddAutodateMessage Lib "IMASCP.dll" _
   (ByVal lPrinterID As Long, ByRef myS7Message As IJS7_Message, _
     ByVal bExtended As Byte, ByVal strAutodateInfo As String) As Long
Declare Function IJS7_AddBarcodeMessage Lib "IMASCP.dll" _
    (ByVal lPrinterID As Long, ByRef myS7Message As IJS7_Message, _
     ByVal bCode As Byte, ByRef bBarCodeData As Byte, ByVal lElementLen As Long) As Long
Declare Function IJS7_AddTabulationMessage Lib "IMASCP.dll" _
   (ByVal lPrinterID As Long, ByRef myS7Message As IJS7_Message, _
     ByVal lNumEmptyRaster As Long) As Long
Declare Function IJS7_CopyBufferToMessage Lib "IMASCP.dll" _
   (ByRef myS7Message As IJS7_Message, ByRef myS7MessageInfo As IJS7_MessageInfo) As Long
Declare Function IJ_AutoSearchPrinter Lib "IMASCP.dll" (ByRef lpAutoDetect As AUTODETECTINFO) As Integer

Declare Function GetAPIVersion Lib "InfiniImageCP.dll" () As Integer
Declare Function testFunction Lib "InfiniImageCP.dll" () As Integer
Public Declare Function SearchPrinter Lib "InfiniImageCP.dll" () As Integer

