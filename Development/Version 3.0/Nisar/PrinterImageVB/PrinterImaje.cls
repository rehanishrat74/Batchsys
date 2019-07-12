VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "PrinterImaje"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public Function PrinterSetup(PrinterID As String, JetStatus As String, sFilePath As String) As String

    On Error GoTo ErrorMessage
    Dim lPrinterID As Long
    Dim lJetStatus As Long
    
    lPrinterID = CLng(PrinterID)
    lJetStatus = CLng(JetStatus)
    WriteLog "Calling IJS7_PrinterSetup", sFilePath & "\Trace", "PrinterSetup.txt"
    PrinterSetup = CStr(IJS7_PrinterSetup(lPrinterID, lJetStatus))
    WriteLog "Called IJS7_PrinterSetup", sFilePath & "\Trace", "PrinterSetup.txt"
    Exit Function
    
ErrorMessage:
       'Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
        WriteLog "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description, sFilePath & "\Trace", "PrinterSetup.txt"
End Function
Public Function StartBuildMessage(PrinterID As String) As String
    
    Dim lPrinterID As Long
    lPrinterID = CLng(PrinterID)
    
    
    Dim objIJS7_Message As IJS7_Message
    Dim lReturn As Long
    lReturn = IJS7_StartBuildMessage(lPrinterID, objIJS7_Message)
    
'    MsgBox ("The value return and " & lReturn)
    Dim strXML As String
    
    strXML = "<root>"
    strXML = strXML & "<retvalue>" & lReturn & "</retvalue>"
''''    strXml = strXml & "<params class='objIJS7_Message' name='bAddedBlock'>" & objIJS7_Message.bAddedBlock & "</params>"
''''    'strXml = strXml & "<params class='objIJS7_Message' name='bMsg'>" & CStr(objIJS7_Message.bMsg) & "</params>"
''''    strXml = strXml & "<params class='objIJS7_Message' name='bStartedBuild'>" & objIJS7_Message.bStartedBuild & "</params>"
''''    strXml = strXml & "<params class='objIJS7_Message' name='lNextPos'>" & objIJS7_Message.lNextPos & "</params>"
''''    strXml = strXml & "<params class='objIJS7_Message' name='lNumBarCodes'>" & objIJS7_Message.lNumBarCodes & "</params>"
''''    strXml = strXml & "<params class='objIJS7_Message' name='lNumBlocks'>" & objIJS7_Message.lNumBlocks & "</params>"
''''    strXml = strXml & "<params class='objIJS7_Message' name='lNumLines'>" & objIJS7_Message.lNumLines & "</params>"
    strXML = strXML & "<bAddedBlock>" & objIJS7_Message.bAddedBlock & "</bAddedBlock>"
    strXML = strXML & "<bStartedBuild>" & objIJS7_Message.bStartedBuild & "</bStartedBuild>"
    strXML = strXML & "<lNextPos>" & objIJS7_Message.lNextPos & "</lNextPos>"
    strXML = strXML & "<lNumBarCodes>" & objIJS7_Message.lNumBarCodes & "</lNumBarCodes>"
    strXML = strXML & "<lNumBlocks>" & objIJS7_Message.lNumBlocks & "</lNumBlocks>"
    strXML = strXML & "<lNumLines>" & objIJS7_Message.lNumLines & "</lNumLines>"
    strXML = strXML & "<bMsg>"
    
    Dim l As Long, lUBound As Long, lLBound As Long
    lLBound = LBound(objIJS7_Message.bMsg)
    lUBound = UBound(objIJS7_Message.bMsg)

 ' ReDim DestArray(lLBound To lUBound)
 
  Dim m As String
  For l = lLBound To lUBound
      'DestArray(l) = SourceArray(l)
      strXML = strXML & "<msg id='" & l & "'>" & ChrB(objIJS7_Message.bMsg(l)) & "</msg >"
  Next
    'aMsg() = objIJS7_Message.bMsg()
    
    strXML = strXML & "</bMsg>"
    strXML = strXML & "</root>"
    StartBuildMessage = strXML
End Function

'Function to return if the specified year is a leap year
Public Function IsLeapYear(yr As Variant) As Boolean
   'If year is divisible by 4 and not divisible by 100, or
   'It is divisible by 400, it is a leap year
    If (yr Mod 4 = 0 And yr Mod 100 <> 0) Or yr Mod 400 = 0 Then
       IsLeapYear = True
   Else
       IsLeapYear = False
   End If
   
End Function


Public Function AddBlock(strXML As String) As String
    
    Dim lPrinterID As Long
    Dim lPosition As Long
    Dim lFont As Long
    Dim lBolderization As Long
    
    Dim myXMLDoc As New MSXML.DOMDocument

    myXMLDoc.loadXML (strXML)
'    MsgBox (strXml)
'    Dim PrinterID_node As IXMLDOMNode
'    Set PrinterID_node = myXMLDoc.selectSingleNode("//printerid")
'
'    Dim Position_node As IXMLDOMNode
'    Set Position_node = myXMLDoc.selectSingleNode("//position")
'
'    Dim Font_node As IXMLDOMNode
'    Set Font_node = myXMLDoc.selectSingleNode("//font")
'
'    Dim Bold_node As IXMLDOMNode
'    Set Bold_node = myXMLDoc.selectSingleNode("//bold")
    
    lPrinterID = CLng(myXMLDoc.selectSingleNode("//printerid").Text)
     
    lPosition = CLng(myXMLDoc.selectSingleNode("//position").Text)
     
    lFont = CLng(myXMLDoc.selectSingleNode("//font").Text)
     
    lBolderization = CLng(myXMLDoc.selectSingleNode("//bold").Text)
    
'   MsgBox ("ab2")
    
'    Dim Prams As IXMLDOMNodeList
'    Set Prams = myXMLDoc.selectNodes("//params")
'    Dim child As IXMLDOMNode
'
   Dim objIJS7_Message As IJS7_Message
'   MsgBox ("ab")
   If myXMLDoc.selectSingleNode("//bAddedBlock").Text <> "" Then
    objIJS7_Message.bAddedBlock = CByte(myXMLDoc.selectSingleNode("//bAddedBlock").Text)
   End If
   
'   MsgBox ("ab3")
   'objIJS7_Message.bMsg = myXMLDoc.selectSingleNode("//bAddedBlock").Text
   If myXMLDoc.selectSingleNode("//bStartedBuild").Text <> "" Then
        objIJS7_Message.bStartedBuild = myXMLDoc.selectSingleNode("//bStartedBuild").Text
   End If
   
  
   
    If myXMLDoc.selectSingleNode("//lNextPos").Text <> "" Then
        objIJS7_Message.lNextPos = myXMLDoc.selectSingleNode("//lNextPos").Text
   End If
   
    If myXMLDoc.selectSingleNode("//lNumBarCodes").Text <> "" Then
        objIJS7_Message.lNumBarCodes = myXMLDoc.selectSingleNode("//lNumBarCodes").Text
    End If
    If myXMLDoc.selectSingleNode("//lNumBlocks").Text <> "" Then
        objIJS7_Message.lNumBlocks = myXMLDoc.selectSingleNode("//lNumBlocks").Text
    End If
   If myXMLDoc.selectSingleNode("//lNumLines").Text <> "" Then
        objIJS7_Message.lNumLines = myXMLDoc.selectSingleNode("//lNumLines").Text
    End If
   
   
  Dim bMsg(MAX_MSGLEN_4K - 1) As Byte
  
   
    Dim message As IXMLDOMNodeList
    Dim messageNode As IXMLDOMNode


'    Set sections = mydoc.selectNodes("//Product")
    MsgBox ("ab4")
    Dim i As Integer
    For Each messageNode In myXMLDoc.selectNodes("//msg")
    'MsgBox (messageNode.Attributes(0).Text)
    i = CInt(messageNode.Attributes(0).Text)
'       bMsg(i) = messageNode.Text
        bMsg(i) = 0
    Next
    
     MsgBox ("ab5")
    
    objIJS7_Message.bMsg(MAX_MSGLEN_4K - 1) = bMsg()
    
    Dim lReturn As Long
    lReturn = IJS7_AddBlock(lPrinterID, objIJS7_Message, lPosition, lFont, lBolderization)
    
   ' Dim aMsg(MAX_MSGLEN_4K - 1) As Byte
    
    Dim strXmlReturn As String
    
    strXmlReturn = "<root>"
    strXmlReturn = strXmlReturn & "<retvalue>'" & lReturn & "'</retvalue>"
    strXmlReturn = strXmlReturn & "<bAddedBlock>" & objIJS7_Message.bAddedBlock & "</bAddedBlock>"
    strXmlReturn = strXmlReturn & "<bStartedBuild>" & objIJS7_Message.bStartedBuild & "</bStartedBuild>"
    strXmlReturn = strXmlReturn & "<lNextPos>" & objIJS7_Message.lNextPos & "</lNextPos>"
    strXmlReturn = strXmlReturn & "<lNumBarCodes>" & objIJS7_Message.lNumBarCodes & "</lNumBarCodes>"
    strXmlReturn = strXmlReturn & "<lNumBlocks>" & objIJS7_Message.lNumBlocks & "</lNumBlocks>"
    strXmlReturn = strXmlReturn & "<lNumLines>" & objIJS7_Message.lNumLines & "</lNumLines>"
    strXmlReturn = strXmlReturn & "<bMsg>"
    
    Dim l As Long, lUBound As Long, lLBound As Long
    lLBound = LBound(objIJS7_Message.bMsg)
    lUBound = UBound(objIJS7_Message.bMsg)

 ' ReDim DestArray(lLBound To lUBound)
  For l = lLBound To lUBound
      'DestArray(l) = SourceArray(l)
      'strXmlReturn = strXmlReturn & "<" & l & ">" & objIJS7_Message.bMsg(l) & "</" & l & ">"
      strXML = strXML & "<msg id='" & l & "'>" & objIJS7_Message.bMsg(l) & "</msg >"
  Next
    'aMsg() = objIJS7_Message.bMsg()
    
    strXmlReturn = strXmlReturn & "</bMsg>"
    strXmlReturn = strXmlReturn & "<root>"
    AddBlock = strXmlReturn
    
'''''    strXmlReturn = "<root>"
'''''    strXmlReturn = strXmlReturn & "<retvalue>'" & lReturn & "'</retvalue>"
'''''    strXmlReturn = strXmlReturn & "<params class='objIJS7_Message' name='bAddedBlock'>" & objIJS7_Message.bAddedBlock & "</params>"
'''''    'strXmlReturn = strXmlReturn & "<params class='objIJS7_Message' name='bMsg'>" & CStr(objIJS7_Message.bMsg) & "</params>"
'''''    strXmlReturn = strXmlReturn & "<params class='objIJS7_Message' name='bStartedBuild'>" & objIJS7_Message.bStartedBuild & "</params>"
'''''    strXmlReturn = strXmlReturn & "<params class='objIJS7_Message' name='lNextPos'>" & objIJS7_Message.lNextPos & "</params>"
'''''    strXmlReturn = strXmlReturn & "<params class='objIJS7_Message' name='lNumBarCodes'>" & objIJS7_Message.lNumBarCodes & "</params>"
'''''    strXmlReturn = strXmlReturn & "<params class='objIJS7_Message' name='lNumBlocks'>" & objIJS7_Message.lNumBlocks & "</params>"
'''''    strXmlReturn = strXmlReturn & "<params class='objIJS7_Message' name='lNumLines'>" & objIJS7_Message.lNumLines & "</params>"
'''''    strXmlReturn = strXmlReturn & "<params class='objIJS7_Message' name='lNumLines'>" & objIJS7_Message.lNumLines & "</params>"
'''''    strXmlReturn = strXmlReturn & "<params class='objIJS7_Message' name='lNumLines'>" & objIJS7_Message.lNumLines & "</params>"
'''''    strXmlReturn = strXmlReturn & "<root>"
'''''    AddBlock = strXmlReturn
End Function


Public Function ConfigureAndStartPort(strXML As String, sFilePath As String) As String
On Error GoTo ErrorMessage

WriteLog "Start", sFilePath & "\Trace", "ConfigureAndStartPort.txt"
WriteLog strXML, sFilePath & "\Trace", "ConfigureAndStartPort.txt"

Dim sSWVersion As String

Dim mySerialInfo As New IJ_SerialInfo
Dim myPrinterInfo As New IJ_PrinterInfo
    
    Dim nPort As Byte
    Dim nBaudRate As Long
    Dim bParity As Byte
    Dim bStopbits As Byte
    Dim bDatabits As Byte
    Dim bFlowCtrl As Byte
    
    Dim bPrinterType As Byte
    Dim szSWVersionMajor As String * 4
    Dim szSWVersionMinor As String * 4
     
    
    Dim lPrinterID As Long
    Dim lPosition As Long
    Dim lFont As Long
    Dim lBolderization As Long
    Dim strText As String
    Dim strReturn As String
    
    'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(), Create xml document"
    
    Dim myXMLDoc As New MSXML.DOMDocument
    'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),Load xml doc "
    myXMLDoc.loadXML (strXML)
    'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),loaded xml doc and doc is  " & strXML
    
    WriteLog "loaded xml doc", sFilePath & "\Trace", "ConfigureAndStartPort.txt"
    
    If myXMLDoc.selectSingleNode("//nPort").Text <> "" Then
        nPort = CByte(myXMLDoc.selectSingleNode("//nPort").Text)
        mySerialInfo.nPort = nPort
        'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),mySerialInfo.nPort is : " & mySerialInfo.nPort
        WriteLog "nPort -->" & nPort, sFilePath & "\Trace", "ConfigureAndStartPort.txt"
    End If
    
    If myXMLDoc.selectSingleNode("//nBaudRate").Text <> "" Then
        nBaudRate = CLng(myXMLDoc.selectSingleNode("//nBaudRate").Text)
        mySerialInfo.nBaudRate = nBaudRate
        'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),mySerialInfo.nBaudRate is : " & mySerialInfo.nBaudRate
        WriteLog "nBaudRate -->" & nBaudRate, sFilePath & "\Trace", "ConfigureAndStartPort.txt"
    End If
    
    If myXMLDoc.selectSingleNode("//bParity").Text <> "" Then
        bParity = CByte(myXMLDoc.selectSingleNode("//bParity").Text)
        mySerialInfo.bParity = bParity
        'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),mySerialInfo.bParity is : " & mySerialInfo.bParity
        WriteLog "bParity" & bParity, sFilePath & "\Trace", "ConfigureAndStartPort.txt"
    End If
    
    If myXMLDoc.selectSingleNode("//bStopbits").Text <> "" Then
        bStopbits = CByte(myXMLDoc.selectSingleNode("//bStopbits").Text)
        mySerialInfo.bStopbits = bStopbits
        'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),mySerialInfo.bStopbits is : " & mySerialInfo.bStopbits
        WriteLog "bStopbits" & bStopbits, sFilePath & "\Trace", "ConfigureAndStartPort.txt"
    End If
    
    If myXMLDoc.selectSingleNode("//bDatabits").Text <> "" Then
        bDatabits = CByte(myXMLDoc.selectSingleNode("//bDatabits").Text)
        mySerialInfo.bDatabits = bDatabits
        'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),mySerialInfo.bDatabits is : " & mySerialInfo.bDatabits
        WriteLog "bDatabits" & bDatabits, sFilePath & "\Trace", "ConfigureAndStartPort.txt"
    End If
    
    If myXMLDoc.selectSingleNode("//bFlowCtrl").Text <> "" Then
        bFlowCtrl = CByte(myXMLDoc.selectSingleNode("//bFlowCtrl").Text)
        mySerialInfo.bFlowCtrl = bFlowCtrl
        'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),mySerialInfo.bFlowCtrl is : " & mySerialInfo.bFlowCtrl
    End If
    
    If myXMLDoc.selectSingleNode("//bPrinterType").Text <> "" Then
        bPrinterType = CByte(myXMLDoc.selectSingleNode("//bPrinterType").Text)
        myPrinterInfo.bPrinterType = bPrinterType
        'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),myPrinterInfo.bPrinterType is : " & myPrinterInfo.bPrinterType
        WriteLog "bPrinterType" & bPrinterType, sFilePath & "\Trace", "ConfigureAndStartPort.txt"
    End If
    
   
    myPrinterInfo.szSWVersionMajor = sSWVersion & vbNullChar
    'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),myPrinterInfo.szSWVersionMajor is : " & myPrinterInfo.szSWVersionMajor
    
    If myXMLDoc.selectSingleNode("//szSWVersionMinor").Text <> "" Then
        szSWVersionMinor = myXMLDoc.selectSingleNode("//szSWVersionMinor").Text & vbNullChar
        myPrinterInfo.szSWVersionMinor = szSWVersionMinor & vbNullChar
        'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(),myPrinterInfo.szSWVersionMinor is : " & myPrinterInfo.szSWVersionMinor & vbNullChar
    End If

'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(" & strXML & "," & sFilePath & "), calling the function IJ_ConfigureAndStartPort() of IMASCP.dll "
    ConfigureAndStartPort = CStr(IJ_ConfigureAndStartPort(mySerialInfo, myPrinterInfo))
    
    WriteLog "ConfigureAndStartPort" & ConfigureAndStartPort, sFilePath & "\Trace", "ConfigureAndStartPort.txt"
    
    'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(), return back from the function IJ_ConfigureAndStartPort() of IMASCP.dll "
    'Write #1, "VB 6.0  : Function : ConfigureAndStartPort(), return value is " & ConfigureAndStartPort
 'Close 1
    Exit Function
    
ErrorMessage:
    WriteLog "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description & ConfigureAndStartPort, sFilePath & "\Trace", "ConfigureAndStartPort.txt"
End Function

Public Function ClosePort(PrinterID As String, sFilePath As String) As String
    On Error GoTo ErrorMessage
    Dim lPrinterID As Long
    lPrinterID = CLng(PrinterID)
    ClosePort = CStr(IJ_ClosePort(lPrinterID))
       Exit Function
ErrorMessage:
'Dim sFilePath As String
'sFilePath = App.Path & "\mytext.txt"
'If Dir(sFilePath) <> "" Then
'        Open sFilePath For Append As #1
'        Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
'Else
'    Open sFilePath For Output As #1
'    Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
'End If
'Close #1
If sFilePath <> "" Then
Dim fso As New FileSystemObject
If fso.FolderExists(sFilePath & "\Trace") Then
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1
'    If Not fso.FileExists(App.Path & "\testfolder\Abc.Mdb") Then
'        fso.CopyFile App.Path & "\Abc.Mdb", App.Path & "\testfolder\Abc.Mdb", True
'    End If
Else ' folder doesn't exist so create it then copy file there
    fso.CreateFolder sFilePath & "\Trace"
    'fso.CopyFile App.Path & "\Abc.Mdb", App.Path & "\testfolder\Abc.Mdb", True
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1
End If
End If

End Function

Public Function SendMessage2(strXML As String, sFilePath As String) As String
    
    On Error GoTo ErrorMessage
    
    'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : SendMessage2(" & strXML & "," & sFilePath & " ), come in function of InfiniImage.PrinterImaje"
    'Write #1, "VB 6.0  : Function : SendMessage2 () Parsing xml to xmldocumnet "
    
    Dim lPrinterID As Long
    Dim lPosition As Long
    Dim lFont As Long
    Dim lBolderization As Long
    Dim strText As String
    Dim strReturn As String
    
    Dim myXMLDoc As New MSXML.DOMDocument
    myXMLDoc.loadXML (strXML)
    lPrinterID = CLng(myXMLDoc.selectSingleNode("//printerid").Text)
    lPosition = CLng(myXMLDoc.selectSingleNode("//position").Text)
    lFont = CLng(myXMLDoc.selectSingleNode("//font").Text)
    lBolderization = CLng(myXMLDoc.selectSingleNode("//bold").Text)
    strText = myXMLDoc.selectSingleNode("//messagetext").Text
    
     'Write #1, "VB 6.0  : Function : SendMessage2 () Parsing complete "
    
    Dim bGenParams As Byte
    Dim bMuttitopActivation As Byte
    Dim lTachoDivision As Long
    Dim lForwardMargin As Long
    Dim lReturnMargin As Long
    Dim lIntervalMargin As Long
    Dim lPrintingSpeed As Long
    Dim lMultilinePrinting As Long
    
    Dim bFisrtByte As Byte
    Dim bSecondByte As Byte
    Dim lStartValue As Long
    Dim lEndValue As Long
    Dim lCounterStep As Long
    Dim lIncDivider As Long
    
    Dim bUnit As Byte
    Dim lPostDate As Long
    
    
    ''' first we create IJS7_StartBuildMessage

    
    
    'Dim objIJS7_Message As IJS7_Message
    Dim lReturn As Long
    'MsgBox ("The value of printer is " & lPrinterID)
    'Write #1, "VB 6.0  : Function : SendMessage2 () calling the IJS7_StartBuildMessage method of IMASCP.dll"
    lReturn = IJS7_StartBuildMessage(lPrinterID, myMessage)
    'Write #1, "VB 6.0  : Function : SendMessage2 () come back from  the IJS7_StartBuildMessage method of IMASCP.dll"
    'Write #1, "VB 6.0  : Function : SendMessage2 () the return value is " & lReturn
    'Close 1
'    MsgBox ("The value retun by bulider is " & lReturn)
    
    If lReturn <> IJ_SUCCESS Then
'        strReturn = "<root><retvalue>" & lReturn & "</retvalue><id>nisar</id></root>"
        strReturn = "<root><retvalue>2000</retvalue></root>"
        SendMessage2 = strReturn
        Exit Function        'exit from the current procedure
    End If
    
    '''After the startBuildMessage we add block
    'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : SendMessage2 () calling the IJS7_AddBlock method of IMASCP.dll"
    lReturn = IJS7_AddBlock(lPrinterID, myMessage, lPosition, lFont, lBolderization)
    'Write #1, "VB 6.0  : Function : SendMessage2 () come back from  the IJS7_AddBlock method of IMASCP.dll"
    'Write #1, "VB 6.0  : Function : SendMessage2 () the return value is " & lReturn
    'Close 1
    
    If lReturn <> IJ_SUCCESS Then
        'strReturn = "<root><retvalue>" & lReturn & "</retvalue></root>"
        strReturn = "<root><retvalue>2001</retvalue></root>"
        SendMessage2 = strReturn
         Exit Function       'exit from the current procedure
    End If
    
    ''' After the block add we add the text message
    'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : SendMessage2 () calling the IJS7_AddTextMessage method of IMASCP.dll"
     lReturn = IJS7_AddTextMessage(lPrinterID, myMessage, strText)
     'Write #1, "VB 6.0  : Function : SendMessage2 () come back from  the IJS7_AddTextMessage method of IMASCP.dll"
    'Write #1, "VB 6.0  : Function : SendMessage2 () the return value is " & lReturn
    'Close 1
    If lReturn <> IJ_SUCCESS Then
        'strReturn = "<root><retvalue>" & lReturn & "</retvalue></root>"
        strReturn = "<root><retvalue>2002</retvalue></root>"
        SendMessage2 = strReturn
         Exit Function       'exit from the current procedure
    End If
    
    ''' After the text insert we Coppying the message array to message info structure
   'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : SendMessage2 () Setting the myS7GenParamInfo and myS7MessageInfo struct"
   myS7MessageInfo.myS7GenParamInfo.bGenParams = &H10 'first byte of the general parameters
                                                       'Message,horizontal and vertical sense are normal
                                                       'Tachy mode yes
                                                       'Set off object
                                                       'margin mode millimetre
    myS7MessageInfo.myS7GenParamInfo.bMuttitopActivation = 0    'no multitop activation
    myS7MessageInfo.myS7GenParamInfo.lForwardMargin = 100       'forward margin 100
    myS7MessageInfo.myS7GenParamInfo.lIntervalMargin = 5        'interval margin 5
    myS7MessageInfo.myS7GenParamInfo.lReturnMargin = 50         'return margin 50
    myS7MessageInfo.myS7GenParamInfo.lTachoDivision = 14        'tacho division 14
    myS7MessageInfo.myS7GenParamInfo.lPrintingSpeed = 250       'printing speed 250
    myS7MessageInfo.myS7GenParamInfo.lMultilinePrinting = 0
    'Filling variable parameter structure
    'Filling counter
    myS7MessageInfo.myS7VarParamInfo.arrS7CounterParamInfo(0).bFisrtByte = &HC9 'with leading zero
                                                                                'indication of overflow
                                                                                'incrementation and 9 significant figures
    myS7MessageInfo.myS7VarParamInfo.arrS7CounterParamInfo(0).bSecondByte = &H60 'object incrementation
                                                                                 'rest zero
    myS7MessageInfo.myS7VarParamInfo.arrS7CounterParamInfo(0).lStartValue = 111111111  'start value of counter
    myS7MessageInfo.myS7VarParamInfo.arrS7CounterParamInfo(0).lEndValue = 555555555    'end value
    myS7MessageInfo.myS7VarParamInfo.arrS7CounterParamInfo(0).lIncDivider = 1          'batch 1
    myS7MessageInfo.myS7VarParamInfo.arrS7CounterParamInfo(0).lCounterStep = 1         'step 1
    'Filling postdate
    myS7MessageInfo.myS7VarParamInfo.arrPostDate(0).bUnit = 0 'in days
    myS7MessageInfo.myS7VarParamInfo.arrPostDate(0).lPostDate = 365 'one year
    'filling barcode
    myS7MessageInfo.myS7VarParamInfo.arrS7BarCodeInfo(0).bBolderization = 1  'bolderization 1
    myS7MessageInfo.myS7VarParamInfo.arrS7BarCodeInfo(0).bIdentification = 0 '2/5 interlaced code
    myS7MessageInfo.myS7VarParamInfo.arrS7BarCodeInfo(0).bNarrowBar = 1      'narrow bar width 1
    myS7MessageInfo.myS7VarParamInfo.arrS7BarCodeInfo(0).bNarrowSpace = 1    'narrow space width 1
    myS7MessageInfo.myS7VarParamInfo.arrS7BarCodeInfo(0).bTrameHeight = 16   'trame height
    myS7MessageInfo.myS7VarParamInfo.arrS7BarCodeInfo(0).bWideBar = 2        'wide bar 2
    myS7MessageInfo.myS7VarParamInfo.arrS7BarCodeInfo(0).bWideSpace = 2      'wide space 2
    myS7MessageInfo.myS7VarParamInfo.arrS7BarCodeInfo(0).bControlByte = 1    'with control byte
    myS7MessageInfo.myS7VarParamInfo.arrS7BarCodeInfo(0).bSpecial = 0        'standard code
    myS7MessageInfo.myS7VarParamInfo.arrS7BarCodeInfo(0).bVideoMode = 0      'video mode no
    'filling structure indicator
    myS7MessageIndicator.bGenParamsPresent = 1  'general param present
    myS7MessageIndicator.bMsgPresent = 1        'message present
    myS7MessageIndicator.bNumBarCodes = 1       'one bar code
    myS7MessageIndicator.bNumCounters = 1       'one counter
    myS7MessageIndicator.bNumPostdates = 1      'one post date
    
    'Write #1, "VB 6.0  : Function : SendMessage2 () calling the IJS7_CopyBufferToMessage method of IMASCP.dll"
    lReturn = IJS7_CopyBufferToMessage(myMessage, myS7MessageInfo)
    'Write #1, "VB 6.0  : Function : SendMessage2 () come back from  the IJS7_CopyBufferToMessage method of IMASCP.dll"
    'Write #1, "VB 6.0  : Function : SendMessage2 () the return value is " & lReturn
    'Close 1
    If lReturn <> IJ_SUCCESS Then
        'strReturn = "<root><retvalue>" & lReturn & "</retvalue></root>"
        strReturn = "<root><retvalue>2003</retvalue></root>"
        SendMessage2 = strReturn
        Exit Function        'exit from the current procedure
    End If
    
    'calling api function to send message to printer
    'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : SendMessage2 () calling the IJS7_SendMessage method of IMASCP.dll"
    lReturn = IJS7_SendMessage(lPrinterID, myS7MessageIndicator, myS7MessageInfo)
    'Write #1, "VB 6.0  : Function : SendMessage2 () come back from  the .dll"
    'Write #1, "VB 6.0  : Function : SendMessage2 () the return value is " & lReturn
    'Write #1, "VB 6.0  : Function : SendMessage2 () Completed Process"
    'Close 1
    If lReturn = IJ_SUCCESS Then
        strReturn = "<root><retvalue>" & lReturn & "</retvalue></root>"
        SendMessage2 = strReturn
    Else
        strReturn = "<root><retvalue>" & lReturn & "</retvalue></root>"
        SendMessage2 = strReturn
    End If
    Exit Function
ErrorMessage:
'Dim sFilePath As String
'sFilePath = App.Path & "\mytext.txt"
'If Dir(sFilePath) <> "" Then
'        Open sFilePath For Append As #1
'        Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
'Else
'    Open sFilePath For Output As #1
'    Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
'End If
''Close #1
If sFilePath <> "" Then
Dim fso As New FileSystemObject
If fso.FolderExists(sFilePath & "\Trace") Then
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1
'    If Not fso.FileExists(App.Path & "\testfolder\Abc.Mdb") Then
'        fso.CopyFile App.Path & "\Abc.Mdb", App.Path & "\testfolder\Abc.Mdb", True
'    End If
Else ' folder doesn't exist so create it then copy file there
    fso.CreateFolder sFilePath & "\Trace"
    'fso.CopyFile App.Path & "\Abc.Mdb", App.Path & "\testfolder\Abc.Mdb", True
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1
End If
End If
End Function

Public Function GetPrinterParams(PrinterID As String, sFilePath As String) As String

    On Error GoTo ErrorMessage
 Dim lPrinterID As Long
    Dim strReturn As String
    lPrinterID = CLng(PrinterID)
    'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : GetPrinterParams(" & PrinterID & "," & sFilePath & "), come in function of InfiniImage.PrinterImaje"
    'Write #1, "VB 6.0  : Function : GetPrinterParams(), calling the function IJS7_GetPrinterParams(" & lPrinterID & " and reference of myS7PrinterStatusInfo struct ) of IMASCP.dll "

   

    Dim lReturn As Long

    lReturn = IJS7_GetPrinterParams(lPrinterID, myS7PrinterStatusInfo)
    'Write #1, "VB 6.0  : Function : GetPrinterParams(), come back and the value return is :  " & lReturn
    'Write #1, "VB 6.0  : Function : GetPrinterParams(),Create xml from reference structur "
    strReturn = "<root><retvalue>" & lReturn & "</retvalue>"
    strReturn = strReturn & "<bPrinterState>" & myS7PrinterStatusInfo.bPrinterState & "</bPrinterState>"
    strReturn = strReturn & "<lAccumPressure>" & myS7PrinterStatusInfo.lAccumPressure & "</lAccumPressure>"
    strReturn = strReturn & "<lBufferPressure>" & myS7PrinterStatusInfo.lBufferPressure & "</lBufferPressure>"
    strReturn = strReturn & "<lJet1Speed>" & myS7PrinterStatusInfo.lJet1Speed & "</lJet1Speed>"
    strReturn = strReturn & "<lJet2Speed>" & myS7PrinterStatusInfo.lJet2Speed & "</lJet2Speed>"
    strReturn = strReturn & "<lRefPressure>" & myS7PrinterStatusInfo.lRefPressure & "</lRefPressure>"
    strReturn = strReturn & "<lTemp>" & myS7PrinterStatusInfo.lTemp & "</lTemp>"
    strReturn = strReturn & "</root>"
    'Write #1, "VB 6.0  : Function : GetPrinterParams(),the created xml is " & strReturn
    'Close 1
    GetPrinterParams = strReturn
    Exit Function
ErrorMessage:
''Dim sFilePath As String
''sFilePath = App.Path & "\mytext.txt"
'If Dir(sFilePath) <> "" Then
'        Open sFilePath For Append As #1
'        Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
'Else
'    Open sFilePath For Output As #1
'    Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
'End If
''Close #1
If sFilePath <> "" Then
Dim fso As New FileSystemObject
If fso.FolderExists(sFilePath & "\Trace") Then
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1
'    If Not fso.FileExists(App.Path & "\testfolder\Abc.Mdb") Then
'        fso.CopyFile App.Path & "\Abc.Mdb", App.Path & "\testfolder\Abc.Mdb", True
'    End If
Else ' folder doesn't exist so create it then copy file there
    fso.CreateFolder sFilePath & "\Trace"
    'fso.CopyFile App.Path & "\Abc.Mdb", App.Path & "\testfolder\Abc.Mdb", True
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1
End If
End If
End Function


'Public Function GetPrinterParams() As String
'
'    On Error GoTo ErrorMessage
'
'    Dim lPrinterID As Long
'    Dim strReturn As String
'    lPrinterID = CLng(PrinterID)
'
'    Dim lReturn As Long
'
'    lReturn = IJS7_GetPrinterParams(g_lPrinterID, myS7PrinterStatusInfo)
'
'    strReturn = "<root><retvalue>" & lReturn & "</retvalue>"
'    strReturn = strReturn & "<bPrinterState>" & myS7PrinterStatusInfo.bPrinterState & "</bPrinterState>"
'    strReturn = strReturn & "<lAccumPressure>" & myS7PrinterStatusInfo.lAccumPressure & "</lAccumPressure>"
'    strReturn = strReturn & "<lBufferPressure>" & myS7PrinterStatusInfo.lBufferPressure & "</lBufferPressure>"
'    strReturn = strReturn & "<lJet1Speed>" & myS7PrinterStatusInfo.lJet1Speed & "</lJet1Speed>"
'    strReturn = strReturn & "<lJet2Speed>" & myS7PrinterStatusInfo.lJet2Speed & "</lJet2Speed>"
'    strReturn = strReturn & "<lRefPressure>" & myS7PrinterStatusInfo.lRefPressure & "</lRefPressure>"
'    strReturn = strReturn & "<lTemp>" & myS7PrinterStatusInfo.lTemp & "</lTemp>"
'    strReturn = strReturn & "</root>"
'
'    GetPrinterParams = strReturn
'    Exit Function
'ErrorMessage:
'
'If sFilePath <> "" Then
'Dim fso As New FileSystemObject
'If fso.FolderExists(sFilePath & "\Trace") Then
'    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
'        Open sFilePath For Append As #1
'        Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
'    Else
'        Open sFilePath & "\Trace\MyError.txt" For Output As #1
'        Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
'    End If
'    'Close #1
'
'Else
'    fso.CreateFolder sFilePath & "\Trace"
'    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
'        Open sFilePath For Append As #1
'        Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
'    Else
'        Open sFilePath & "\Trace\MyError.txt" For Output As #1
'        Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
'    End If
'    'Close #1
'End If
'End If
'End Function

Public Function AutoSearchPrinter(sFilePath As String) As String

    On Error GoTo ErrorMessage

    Dim lPrinterID As Long
    Dim strReturn As String
   ''lPrinterID = CLng(PrinterID)

Dim aPrinterID() As Long

    Dim nRet As Integer
    nRet = IJ_AutoSearchPrinter(myAUTODETECTINFO)
    aPrinterID = aAutoDetect.dwPrinterID()
   

Dim i As Integer

    strReturn = "<root><retvalue>" & nRet & "</retvalue>"
    For i = 0 To UBound(aPrinterID)
        strReturn = strReturn & "<lPrinterId>" & aPrinterID(i) & "</lPrinterId>"
    Next
    'aAutoDetect.szAutoDetectInfo
    strReturn = strReturn & "<szAutoDetectInfo>" & " " & "</szAutoDetectInfo>"
    strReturn = strReturn & "</root>"
    AutoSearchPrinter = strReturn
    Exit Function
ErrorMessage:

If sFilePath <> "" Then
Dim fso As New FileSystemObject
If fso.FolderExists(sFilePath & "\Trace") Then
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : AutoSearchPrinter , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : AutoSearchPrinter , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1

Else
    fso.CreateFolder sFilePath & "\Trace"
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : AutoSearchPrinter , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : AutoSearchPrinter , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1
End If
End If
End Function

Public Function AutoDetectPrinter(sFilePath As String) As String

    On Error GoTo ErrorMessage
    WriteLog "Start", sFilePath & "\Trace", "AutoDetectPrinter.txt"
   
    Dim i As Integer
    i = SearchPrinter()
    WriteLog "SearchPrinter()-->" & i, sFilePath & "\Trace", "AutoDetectPrinter.txt"
    AutoDetectPrinter = CStr(i)
    Exit Function
ErrorMessage:
        'Write #1, "Error from vb6 , Function : AutoDetectPrinter , Error number : " & Err.Number & " and Description : " & Err.Description
        WriteLog "Error from vb6 , Function : AutoDetectPrinter , Error number : " & Err.Number & " and Description : " & Err.Description, sFilePath & "\Trace", "AutoDetectPrinter.txt"
End Function

Public Function GetDLLVersion(sFilePath As String) As String

    On Error GoTo ErrorMessage
    'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : GetDLLVersion(" & sFilePath & "), come in function of InfiniImageVB.PrinterImaje"
    'Write #1, "VB 6.0  : Function : GetDLLVersion(" & sFilePath & "), calling the function GetAPIVersion() of InfiniImageCP.dll "
    'Close 1
    Dim i As Integer
    ''Dim sVersion As String
    i = GetAPIVersion()
    ''MsgBox ("Nisar")
    'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : GetAPIVersion(), retrun back in GetDLLVersion function from GetAPIVersion() of InfiniImageCP.dll"
    'Write #1, "VB 6.0  : Function : GetDLLVersion(" & sFilePath & "), retrun value is : " & i
    ''Write #1, "VB 6.0  : Function : GetDLLVersion(" & sFilePath & "), retrun Software version is : " & sVersion
    'Write #1, "VB 6.0  : Function : GetDLLVersion(" & sFilePath & "), The work of GetDLLVersion() is complete and return the " & i & " as a string "
    'Close 1
GetDLLVersion = CStr(i)
    Exit Function
ErrorMessage:

If sFilePath <> "" Then
Dim fso As New FileSystemObject
If fso.FolderExists(sFilePath & "\Trace") Then
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : GetDLLVersion , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : GetDLLVersion , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1

Else
    fso.CreateFolder sFilePath & "\Trace"
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : GetDLLVersion , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : GetDLLVersion , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1
End If
End If
End Function


Public Function TestNisar(sFilePath As String) As String

    On Error GoTo ErrorMessage
    'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : TestNisar(" & sFilePath & "), come in function of InfiniImage.PrinterImaje"
    'Write #1, "VB 6.0  : Function : TestNisar(" & sFilePath & "), calling the function testFunction() of InfiniImageCP.dll "
    'Close 1
    Dim i As Integer
    i = testFunction()
    'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : TestNisar(), retrun back in GetDLLVersion function from testFunction() of InfiniImageCP.dll"
    'Write #1, "VB 6.0  : Function : TestNisar(" & sFilePath & "), retrun value is : " & i
    'Write #1, "VB 6.0  : Function : TestNisar(" & sFilePath & "), The work of TestNisar() is complete and return the " & i & " as a string "
    'Close 1
TestNisar = CStr(i)
    Exit Function
ErrorMessage:

If sFilePath <> "" Then
Dim fso As New FileSystemObject
If fso.FolderExists(sFilePath & "\Trace") Then
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : TestNisar , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : TestNisar , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1

Else
    fso.CreateFolder sFilePath & "\Trace"
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
        'Open sFilePath For Append As #1
        'Write #1, "Error from vb6 , Function : TestNisar , Error number : " & Err.Number & " and Description : " & Err.Description
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        'Write #1, "Error from vb6 ,Function : TestNisar , Error number : " & Err.Number & " and Description : " & Err.Description
    End If
    'Close #1
End If
End If
End Function

Public Function TestError(strXML As String, sFilePath As String) As String
MsgBox ("The path of application is " & App.Path)
On Error GoTo Err

Dim lNumber As Long
lNumber = CLng(strXML)
TestError = "ok"
   Exit Function
Err:
'   Dim sFilePath As String
'sFilePath = App.Path & "\mytext.txt"
'If Dir(sFilePath) <> "" Then
'        Open sFilePath For Append As #1
'        Write #1, "Error from vb6 , Function : TestError , Error number : " & Err.Number & " and Description : " & Err.Description
'Else
'    Open sFilePath For Output As #1
'    Write #1, "Error from vb6 ,Function : TestError , Error number : " & Err.Number & " and Description : " & Err.Description
'End If
'Close #1

'Dim sFilePath As String
'sFilePath = App.Path & "\mytext.txt"
If sFilePath <> "" Then
Dim fso As New FileSystemObject
If fso.FolderExists(sFilePath & "\Trace") Then
MsgBox ("nisar1")
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
    MsgBox ("nisar2")
        'Open sFilePath & "\Trace\MyError.txt" For Append As #1
        MsgBox ("nisar3")
        'Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
        MsgBox ("nisar4")
    Else
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        MsgBox ("nisar5")
        'Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
        MsgBox ("nisar6")
    End If
    'Close #1
'    If Not fso.FileExists(App.Path & "\testfolder\Abc.Mdb") Then
'        fso.CopyFile App.Path & "\Abc.Mdb", App.Path & "\testfolder\Abc.Mdb", True
'    End If
Else ' folder doesn't exist so create it then copy file there
MsgBox ("nisar7")
    fso.CreateFolder sFilePath & "\Trace"
    'fso.CopyFile App.Path & "\Abc.Mdb", App.Path & "\testfolder\Abc.Mdb", True
    If Dir(sFilePath & "\Trace\MyError.txt") <> "" Then
    MsgBox ("nisar8")
        'Open sFilePath & "\Trace\MyError.txt" For Append As #1
        MsgBox ("nisar9")
        'Write #1, "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
        MsgBox ("nisar10")
    Else
    MsgBox ("nisar11")
        'Open sFilePath & "\Trace\MyError.txt" For Output As #1
        MsgBox ("nisar12")
        'Write #1, "Error from vb6 ,Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description
        MsgBox ("nisar13")
    End If
    'Close #1
End If
MsgBox ("nisar14")
End If
End Function


Public Function TestXml(strXML As String) As String
   'If year is divisible by 4 and not divisible by 100, or
   'It is divisible by 400, it is a leap year
'    If (yr Mod 4 = 0 And yr Mod 100 <> 0) Or yr Mod 400 = 0 Then
'       IsLeapYear = True
'   Else
'       IsLeapYear = False
'   End If
MsgBox ("Step1")
Dim mydoc As New MSXML.DOMDocument
MsgBox ("Step2")
mydoc.loadXML (strXML)
MsgBox ("Step3")
Dim Product As IXMLDOMNodeList
Set Product = mydoc.selectNodes("//Product")
Dim child As IXMLDOMNode
MsgBox ("Step4")
For Each child In mydoc.selectNodes("//Product")
    'MsgBox (section.selectSingleNode("param").Text)
    MsgBox (child.Attributes(0).Text & " " & child.Text)
    'SectionsList.AddItem_
    'section.selectSingleNode("Product").Text
    Next
TestXml = "OK"
   
End Function

'***************************************************************************************************************************************************
'9020                               Block Start
'***************************************************************************************************************************************************
Public Function SendMessage_9020(strXML As String, sFilePath As String) As String
    
    On Error GoTo ErrorMessage
    
    WriteLog "Start", sFilePath & "\Trace", "SendMessage_9020.txt"
    WriteLog strXML, sFilePath & "\Trace", "SendMessage_9020.txt"
    'Open sFilePath & "\Trace\SendMessage_9020.TXT" For Output As #2
    'Print #2, "SendMessage_9020--> Start"
    
    'Open sFilePath & "\Trace\Log.TXT" For Append As #1
    'Write #1, "VB 6.0  : Function : SendMessage2(" & strXML & "," & sFilePath & " ), come in function of InfiniImage.PrinterImaje"
    'Write #1, "VB 6.0  : Function : SendMessage2 () Parsing xml to xmldocumnet "
    
    Dim lPrinterID As Long
    Dim lPosition As Long
    Dim lFont As Long
    Dim lBolderization As Long
    Dim strText As String
    Dim strReturn As String
    
    Dim myXMLDoc As New MSXML.DOMDocument
    myXMLDoc.loadXML (strXML)
    lPrinterID = CLng(myXMLDoc.selectSingleNode("//printerid").Text)
    lPosition = CLng(myXMLDoc.selectSingleNode("//position").Text)
    lFont = CLng(myXMLDoc.selectSingleNode("//font").Text)
    lBolderization = CLng(myXMLDoc.selectSingleNode("//bold").Text)
    strText = myXMLDoc.selectSingleNode("//messagetext").Text
        
    Dim bGenParams As Byte
    Dim bMuttitopActivation As Byte
    Dim lTachoDivision As Long
    Dim lForwardMargin As Long
    Dim lReturnMargin As Long
    Dim lIntervalMargin As Long
    Dim lPrintingSpeed As Long
    Dim lMultilinePrinting As Long
    
    Dim bFisrtByte As Byte
    Dim bSecondByte As Byte
    Dim lStartValue As Long
    Dim lEndValue As Long
    Dim lCounterStep As Long
    Dim lIncDivider As Long
    
    Dim bUnit As Byte
    Dim lPostDate As Long
    
    'first we create IJS7_StartBuildMessage
    'Dim objIJS7_Message As IJS7_Message
    Dim lReturn As Long
    WriteLog "Calling IJS9020_StartBuildMessage", sFilePath & "\Trace", "SendMessage_9020.txt"
        lReturn = IJS9020_StartBuildMessage(lPrinterID, myMessage_9020)
    WriteLog "Called IJS9020_StartBuildMessage", sFilePath & "\Trace", "SendMessage_9020.txt"
    
    If lReturn <> IJ_SUCCESS Then
    WriteLog "lReturn <> IJ_SUCCESS", sFilePath & "\Trace", "SendMessage_9020.txt"
        'strReturn = "<root><retvalue>" & lReturn & "</retvalue><id>nisar</id></root>"
        strReturn = "<root><retvalue>2000</retvalue></root>"
        SendMessage_9020 = strReturn
        Exit Function        'exit from the current procedure
    End If
    
    'After the startBuildMessage we add block
    WriteLog "Calling IJS9020_AddBlock", sFilePath & "\Trace", "SendMessage_9020.txt"
        lReturn = IJS9020_AddBlock(g_lPrinterID, myMessage_9020, 1, 81, 1)
    WriteLog "Calling IJS9020_AddBlock", sFilePath & "\Trace", "SendMessage_9020.txt"

    If lReturn <> IJ_SUCCESS Then
    WriteLog "lReturn <> IJ_SUCCESS", sFilePath & "\Trace", "SendMessage_9020.txt"
        'strReturn = "<root><retvalue>" & lReturn & "</retvalue></root>"
        strReturn = "<root><retvalue>2001</retvalue></root>"
        SendMessage_9020 = strReturn
         Exit Function       'exit from the current procedure
    End If
     WriteLog "Calling IJS9020_AddBlock", sFilePath & "\Trace", "SendMessage_9020.txt"
     lReturn = IJS9020_AddTextMessage(g_lPrinterID, myMessage_9020, strText)
     WriteLog "Called IJS9020_AddBlock", sFilePath & "\Trace", "SendMessage_9020.txt"
   
    If lReturn <> IJ_SUCCESS Then
    WriteLog "lReturn <> IJ_SUCCESS", sFilePath & "\Trace", "SendMessage_9020.txt"
        strReturn = "<root><retvalue>2002</retvalue></root>"
        SendMessage_9020 = strReturn
         Exit Function       'exit from the current procedure
    End If
    
   ' Initialise the message indicator structure
    myMessageIndicator9020.bGenParamsPresent = 1
    myMessageIndicator9020.bMsgPresent = 1
    myMessageIndicator9020.bPresenceCounterBase = 0
    myMessageIndicator9020.nNumBarCodes = 0
    myMessageIndicator9020.nNumCounters = 0
    myMessageIndicator9020.nNumPostdates = 0
    
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
        
   WriteLog "Calling IJS9020_CopyBufferToMessage", sFilePath & "\Trace", "SendMessage_9020.txt"
    lReturn = IJS9020_CopyBufferToMessage(myMessage_9020, myMessageInfo9020)
   WriteLog "Called IJS9020_CopyBufferToMessage", sFilePath & "\Trace", "SendMessage_9020.txt"
    If lReturn <> IJ_SUCCESS Then
    WriteLog "lReturn <> IJ_SUCCESS", sFilePath & "\Trace", "SendMessage_9020.txt"
        strReturn = "<root><retvalue>2003</retvalue></root>"
        SendMessage_9020 = strReturn
        Exit Function        'exit from the current procedure
    End If
    
    WriteLog "Calling IJS9020_SendMessage", sFilePath & "\Trace", "SendMessage_9020.txt"
    lReturn = IJS9020_SendMessage(g_lPrinterID, myMessageIndicator9020, myMessageInfo9020)
    WriteLog "Called IJS9020_SendMessage", sFilePath & "\Trace", "SendMessage_9020.txt"
    
    If lReturn = IJ_SUCCESS Then
        strReturn = "<root><retvalue>" & lReturn & "</retvalue></root>"
       SendMessage_9020 = strReturn
    Else
        strReturn = "<root><retvalue>" & lReturn & "</retvalue></root>"
       SendMessage_9020 = strReturn
    End If
     WriteLog "End", sFilePath & "\Trace", "SendMessage_9020.txt"
    Exit Function
ErrorMessage:
        WriteLog "Error from vb6 , Function : ConfigureAndStartPort , Error number : " & Err.Number & " and Description : " & Err.Description, sFilePath & "\Trace", "SendMessage_9020.txt"

End Function


Public Function SetPrinterParam(PrinterInfo As String) As String
    Dim nPort As Integer
    Dim strPort As String
    Dim prntInfo() As String
    prntInfo() = Split(PrinterInfo, ",")
        
    strPort = prntInfo(1)
    nPort = Val(strPort)
    mySerialInfo_9020.nPort = nPort
    
    'Select Case cboBaudRate.Text
    Select Case prntInfo(0)
        Case "38400"
           mySerialInfo_9020.nBaudRate = 38400
        Case "19200"
           mySerialInfo_9020.nBaudRate = 19200
        Case "9600"
           mySerialInfo_9020.nBaudRate = 9600
    End Select
    
   mySerialInfo_9020.bStopbits = 0
   mySerialInfo_9020.bParity = 0
   mySerialInfo_9020.bDatabits = 8
    
    'Set the printer id as 9020
    myPrinterInfo_9020.bPrinterType = S9020PRINTERID
    
    g_lPrinterID = IJ_ConfigureAndStartPort(mySerialInfo, myPrinterInfo)
    If g_lPrinterID <= 0 Then
        MsgBox ("Error in opening the port!")
    Else
        MsgBox ("Port opened")
    End If
   SetPrinterParam = g_lPrinterID
End Function


'***************************************************************************************************************************************************
'9020                               Block End
'***************************************************************************************************************************************************

