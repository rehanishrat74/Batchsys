/******************************************************************************
Module Name	: STRUCTS.H
Description	: This file contains the declaration of the data-structures 
			  used by API for S4, S8 and S7 printers and High level API calls

Date		: 14 June 2000
Notices		: Copyright(c) 2000-2001 Imaje SA, France
******************************************************************************/
#ifndef __STRUCTS_H__
#define __STRUCTS_H__

//
// Constants used in the structures
//
#define MAX_MSGLEN_1K		1024
#define MAX_MSGLEN_2K		2048
#define MAX_MSGLEN_4K		4096
#define MAX_CONNECTIONS		16
#define LEN_AUTODETECT_INFO	512

/////////////////////////// Structure Declarations ////////////////////////////
//
// This structure holds the communication parameters
typedef struct tag_COMINFO
{
   BYTE    bPort;
   DWORD   dwBaudRate;
   BYTE	   bParity;
   BYTE    bStopBits;
   BYTE    bByteSize;
   BYTE	   bFlowCtrl;
} COMINFO, *LPCOMINFO;

// This structure actually hold the printer information
typedef struct tag_PRINTERINFO
{
	UINT nPrinterType;
	TCHAR szSWVersion[4];
	TCHAR szHeadType[4];
} PRINTERINFO, *LPPRINTERINFO;

//
// Auto detect Info structure
//
typedef struct tag_AUTODETECTINFO {
	TCHAR szAutoDetectInfo[LEN_AUTODETECT_INFO];
	DWORD dwPrinterID[MAX_CONNECTIONS];
} AUTODETECTINFO, *LPAUTODETECTINFO;

//
// Msg. structure used in message composition functions
//
typedef struct tag_MESSAGE {
	BYTE bMsg[MAX_MSGLEN_4K];
	UINT nNextPos;
	UINT nNumLines;
	UINT nNumBarCodes;
	UINT nNumBlocks;
	BYTE fStartedBuild;
	BYTE fAddedBlock;
} MESSAGE, *LPMESSAGE;

///////////////////// HIGHLEVEL SPECIFIC STRUCTURE DECLARATIONS ///////////////
//
// Printer Information
//
typedef struct tag_IJ_PRINTERINFO {
	BYTE bLanguage;
	UINT nWatchdog;
	BYTE bCoverRecupFault;
	UINT nHeadType;
	UINT nDefferedStopTime;
	BYTE fStartAutoClock;
	UINT nMachineOperatingTime;
	UINT nNumToPrintInMultitop;
	UINT nLibraryMsgNum;
	UINT nJet1Allign;
	UINT nJet2Allign;
	UINT nJet3Allign;
	UINT nJet4Allign;
	// Reserved
	DWORD dwReserved1;
	DWORD dwReserved2;
} IJ_PRINTERINFO, *LPIJ_PRINTERINFO;

//
// Printer Status Information
//
typedef struct tag_IJ_PRINTERSTATUSINFO {
	BYTE bPrinterType;
	// S4 Data Details
	UINT nMotorSpeedOrTransferTime;
	float dPressure;
	UINT nViscoFillingTime;
	UINT nAdditiveAddn;
	float dAveJetSpeed;
	UINT nElectCmpt;
	UINT nInkCkt;
	// S7 Data Details
	BYTE bPrinterState;
	int nRefPressure;
	int nAccumPressure;
	int nBufferPressure;
	UINT bTemp;
	UINT nJet1Speed;
	UINT nJet2Speed;
	// Reserved
	DWORD dwReserved1;
	DWORD dwReserved2;
} IJ_PRINTERSTATUSINFO, *LPIJ_PRINTERSTATUSINFO;

//
// Jet Information
//
typedef struct tag_IJ_JETINFO
{
	BYTE bPrinterType;
	BYTE bJetStatus;
	// Reserved
	DWORD dwReserved1;
	DWORD dwReserved2;
} IJ_JETINFO, *LPIJ_JETINFO;

//
// IJ Message Indicator
//
typedef struct tag_IJ_MESSAGEINDICATOR {
	BYTE fGenParamsPresent;
	BYTE fMsgPresent;
	UINT nNumCounters;
	UINT nNumPostdates;
	UINT nNumBarCodes;
} IJ_MESSAGEINDICATOR, *LPIJ_MESSAGEINDICATOR;

//
// IJ Message general parameters information
//
typedef struct tag_IJ_GENPARAMINFO {
      BYTE bMsgModes;
      BYTE fMultitopActivation;
      UINT nTachoDivision;
      UINT nForwardMargin;
      UINT nReturnMargin;
      UINT nIntervalMargin;
      UINT nPrintingSpeed;
      UINT nMultilinePrinting;
} IJ_GENPARAMINFO, *LPIJ_GENPARAMINFO;

//
// IJ Counter parameters parameters information
//
typedef struct tag_IJ_COUNTERPARAMINFO {
	BYTE bFirstByte;
	BYTE bSecondByte;
	ULONG lStartValue;
	ULONG lEndValue;
	UINT nStepCounter;
	UINT nIncDivider;
} IJ_COUNTERPARAMINFO, *LPIJ_COUNTERPARAMINFO;

//
// IJ Postdate info
//
typedef struct tag_IJ_POSTDATEINFO {
	BYTE bType;	// Days/Months/Year
	UINT nValue;
} IJ_POSTDATEINFO, *LPIJ_POSTDATEINFO;

//
// IJ Barcode information
//
typedef struct tag_IJ_BARCODEINFO {
	BYTE fSpecial;
	BYTE bIdentification;
	BYTE bTrameHeightOrCurrentRaster;
	BYTE bBolderizationOrTypeOfCode;
	BYTE bNarrowBar;
	BYTE bNarrowSpace;
	BYTE bWideBar;
	BYTE bWideSpace;
	BYTE bVideoMode;
	BYTE fControlByte;
	BYTE fTextPos;
} IJ_BARCODEINFO, *LPIJ_BARCODEINFO;

//
// IJ Message variable parameters information
//
typedef struct tag_IJ_VARPARAMINFO {
	IJ_COUNTERPARAMINFO IJ_CounterParamInfo[15];
	IJ_POSTDATEINFO IJ_PostdateInfo[6];
	IJ_BARCODEINFO IJ_BarCodeInfo[3];
} IJ_VARPARAMINFO, *LPIJ_VARPARAMINFO;

//
// IJ Message information
//
typedef struct tag_IJ_MESSAGEINFO {
	IJ_GENPARAMINFO IJ_GenParamInfo;
	IJ_VARPARAMINFO IJ_VarParamInfo;
	BYTE bMessage[MAX_MSGLEN_4K];
	UINT nMsgLen;
} IJ_MESSAGEINFO, *LPIJ_MESSAGEINFO;

//
// Fault information
//
typedef struct tag_IJ_FAULTINFO {
	BYTE bPrinterType;
	// S4 Fault information
	BYTE bGeneral;
	BYTE bHard;
	BYTE bPrinter;
	BYTE bHardIMPJet1;
	BYTE bIMPJet1;
	BYTE bHeadJet1;
	BYTE bHardIMPJet2;
	BYTE bIMPJet2;
	BYTE bHeadJet2;
	BYTE bHardIMPJet3;
	BYTE bIMPJet3;
	BYTE bHeadJet3;
	BYTE bHardIMPJet4;
	BYTE bIMPJet4;
	BYTE bHeadJet4;
	UINT nPhase;
	UINT nSubPhase;
	// S7 Fault Information
	UINT nNumOfFaults;
	BYTE bFaultCodeData[128];
	// Reserved
	DWORD dwReserved1;
	DWORD dwReserved2;
} IJ_FAULTINFO, *LPIJ_FAULTINFO;


//////////////////////// S4(S8) SPECIFIC STRUCTURE DECLARATIONS ///////////////////
//
// S4 Printer information (applies for S8 also)
// 
typedef struct tag_S4_PRINTERINFO {
	BYTE bLanguage;
	UINT nWatchdog;
	BYTE bCoverRecupFault;
	UINT nHeadType;
	UINT nDefferedStopTime;
	BYTE fStartAutoClock;
	UINT nMachineOperatingTime;
	UINT nNumToPrintInMultitop;
	UINT nLibraryMsgNum;
	UINT nJet1Allign;
	UINT nJet2Allign;
	UINT nJet3Allign;
	UINT nJet4Allign;
} S4_PRINTERINFO, *LPS4_PRINTERINFO, 
  S8_PRINTERINFO, *LPS8_PRINTERINFO;

//
// S4 General Prameters information (applies for S8 also)
//
typedef struct tag_S4_GENPARAMINFO {
	BYTE bMsgModes;		// Combination of hash defined values	
	UINT nPrintSpeedOrTachoDiv;
	UINT nForwardMargin;
	UINT nReturnMargin;
	UINT nInterval;
	UINT nObjectTopFilter;
} S4_GENPARAMINFO, *LPS4_GENPARAMINFO, 
  S8_GENPARAMINFO, *LPS8_GENPARAMINFO;

//
// S4 Variable Prameters information (applies for S8 also)
//
typedef struct tag_S4_VARPARAMINFO {
	BYTE bMsgModes;
	UINT nNumFiguresToPrint;
	ULONG lInitialValue;
	ULONG lFinalValue;
	UINT nStepCounter;
	UINT nLotCounter;
	BYTE fPostdateInDays;
	UINT nPostDate;
} S4_VARPARAMINFO, *LPS4_VARPARAMINFO, 
  S8_VARPARAMINFO, *LPS8_VARPARAMINFO;

//
// S4 Printer Message information (applies for S8 also)
//
typedef struct tag_S4_MESSAGEINFO {
	S4_GENPARAMINFO S4_GenParamInfo;
	S4_VARPARAMINFO S4_VarParamInfo;
	BYTE bMsg[MAX_MSGLEN_2K];
	UINT nMsgLen;
} S4_MESSAGEINFO, *LPS4_MESSAGEINFO, 
  S8_MESSAGEINFO, *LPS8_MESSAGEINFO;

//
// S4 Printer Partial Message information (applies for S8 also)
//
typedef struct tag_S4_PARTIALMESSAGEINFO {
	UINT nAddressToModify;
	BYTE bMsgToReplace[MAX_MSGLEN_1K];
	UINT nMsgLen;
} S4_PARTIALMESSAGEINFO, *LPS4_PARTIALMESSAGEINFO, 
  S8_PARTIALMESSAGEINFO, *LPS8_PARTIALMESSAGEINFO;

//
// S4 Keyboard code information (applies for S8 also)
//
typedef struct tag_S4_KEYBOARDCODEINFO { 
	TCHAR chCode1;
	TCHAR chCode2;
	TCHAR chCode3;
} S4_KEYBOARDCODEINFO, *LPS4_KEYBOARDCODEINFO, 
  S8_KEYBOARDCODEINFO, *LPS8_KEYBOARDCODEINFO;

//
// S4 Security code information (applies for S8 also)
//
typedef struct tag_S4_SECURITYCODEINFO {
	TCHAR chCode1;
	TCHAR chCode2;
	TCHAR chCode3;
} S4_SECURITYCODEINFO, *LPS4_SECURITYCODEINFO, 
  S8_SECURITYCODEINFO, *LPS8_SECURITYCODEINFO;

//
// S4 Jet information (applies for S8 also)
//
typedef struct tag_S4_JETINFO {
	UINT nJetSpeed;
	BYTE bJetPhase;
} S4_JETINFO, *LPS4_JETINFO, 
  S8_JETINFO, *LPS8_JETINFO;

//
// S4 Counter parameters information (applies for S8 also)
//
typedef struct tag_S4_COUNTERPARAMINFO {
	ULONG lInitialValue;
	ULONG lFinalValue;
	UINT nStepCounter;
	UINT nBatchCounter;
} S4_COUNTERPARAMINFO, *LPS4_COUNTERPARAMINFO, 
  S8_COUNTERPARAMINFO, *LPS8_COUNTERPARAMINFO;

//
// S4 Shift code information (applies for S8 also)
//
typedef struct tag_S4_SHIFTCODEINFO {
	UINT nStartTimeHours;
	UINT nStartTimeMin;
	UINT nIntervalHours;
	UINT nIntervalMin;
	BYTE bTypeCode;
} S4_SHIFTCODEINFO, *LPS4_SHIFTCODEINFO, 
  S8_SHIFTCODEINFO, *LPS8_SHIFTCODEINFO;

//
// S4 Autoclock information (applies for S8 also)
//
typedef struct tag_S4_AUTOCLOCKINFO {
	UINT nSec;
	UINT nMin;
	UINT nHour;
	UINT nDay;
	UINT nMonth;
	UINT nYear;
	TCHAR chMode24Hours;
} S4_AUTOCLOCKINFO, *LPS4_AUTOCLOCKINFO, 
  S8_AUTOCLOCKINFO, *LPS8_AUTOCLOCKINFO;

//
// S4 Printer Status information (applies for S8 also)
//
typedef struct tag_S4_PRINTERSTATUSINFO {
	UINT nMotorSpeedOrTransferTime;
	float dPressure;	// bar
	UINT nViscoFillingTime;
	UINT nAdditiveAddn;
	float dAveJetSpeed;	// m/s
	UINT nElectCmpt;
	UINT nInkCkt;
} S4_PRINTERSTATUSINFO, *LPS4_PRINTERSTATUSINFO, 
  S8_PRINTERSTATUSINFO, *LPS8_PRINTERSTATUSINFO;

//
// S4 Ink Circuit information (applies for S8 also)
//
typedef struct tag_S4_INKCKTINFO {
	BYTE bELV;
	BYTE bLevels;
	UINT nVisco;
	UINT nRefVisco;
	UINT nNumOfAdditive;
} S4_INKCKTINFO, *LPS4_INKCKTINFO, 
  S8_INKCKTINFO, *LPS8_INKCKTINFO;

//
// S4 CRC Proms information (applies for S8 also)
//
typedef struct tag_S4_CRCPROMSINFO {
	BYTE bCoverRecupFault;
	UINT nWorkingHours;
	TCHAR szCHCKPgmCPU[8];    
	BYTE bNozzleTypeIMP1;
	BYTE bTypeOfGTIMP1;
	TCHAR szCHCKPgmIMP1[8];
	BYTE bNozzleTypeIMP2;
	BYTE bTypeOfGTIMP2;
	TCHAR szCHCKPgmIMP2[8];
	BYTE bNozzleTypeIMP3;
	BYTE bTypeOfGTIMP3;
	TCHAR szCHCKPgmIMP3[8];
	BYTE bNozzleTypeIMP4;
	BYTE bTypeOfGTIMP4;
	TCHAR szCHCKPgmIMP4[8];
	BYTE fStopHoro;
} S4_CRCPROMSINFO, *LPS4_CRCPROMSINFO, 
  S8_CRCPROMSINFO, *LPS8_CRCPROMSINFO;

//
// S4 Printer Fault information (applies for S8 also)
//
typedef struct tag_S4_FAULTINFO {
	BYTE bGeneral;
	BYTE bHard;
	BYTE bPrinter;
	BYTE bHardIMPJet1;
	BYTE bIMPJet1;
	BYTE bHeadJet1;
	BYTE bHardIMPJet2;
	BYTE bIMPJet2;
	BYTE bHeadJet2;
	BYTE bHardIMPJet3;
	BYTE bIMPJet3;
	BYTE bHeadJet3;
	BYTE bHardIMPJet4;
	BYTE bIMPJet4;
	BYTE bHeadJet4;
	UINT nPhase;
	UINT nSubPhase;
} S4_FAULTINFO, *LPS4_FAULTINFO, 
  S8_FAULTINFO, *LPS8_FAULTINFO;

//
// S4 SI Status information (applies for S8 also)
//
typedef struct tag_S4_SISTATUSINFO {
	UINT nICPhaseNum;
	UINT nICSubPhaseNum;
	UINT nTimeOfSubPhase;
	BYTE bLevels;
	BYTE bELV;
	BYTE bAPAndDisELVs;
	UINT nPressure;
	BYTE fEndOfPhase;
} S4_SISTATUSINFO, *LPS4_SISTATUSINFO, 
  S8_SISTATUSINFO, *LPS8_SISTATUSINFO;

//
// S4 Current counter information (applies for S8 also)
//
typedef struct tag_S4_CURRCOUNTERINFO {
	ULONG lCounterValueCurr;
	UINT nBatchValueCurr;
} S4_CURRCOUNTERINFO, *LPS4_CURRCOUNTERINFO, 
  S8_CURRCOUNTERINFO, *LPS8_CURRCOUNTERINFO;

//
// S4 Bar Code information
//
typedef struct tag_S4_BARCODEINFO {
	BYTE bFlags;				
	BYTE bIdentification;		
	BYTE fCurrentRaster;			
	BYTE bTypeOfCode;			
	BYTE bNarrowBar;			
	BYTE bNarrowSpace;			
	BYTE bWideBar;				
	BYTE bWideSpace;			
} S4_BARCODEINFO, *LPS4_BARCODEINFO,
  S8_BARCODEINFO, *LPS8_BARCODEINFO;

//
// S8 Month Table and Code information
//
typedef struct tag_S8_MONTHTABLECODEINFO {
	TCHAR szHourChangeHour[8];
	TCHAR szCodeDigits[52];
	TCHAR szCodeLetters[32];
	TCHAR szMonthTable[48];
} S8_MONTHTABLECODEINFO, *LPS8_MONTHTABLECODEINFO;


//////////////////////// S7 SPECIFIC STRUCTURE DECLARATIONS ///////////////////
//
// S7 Printer status information
//
typedef struct tag_S7_PRINTERSTATUSINFO {
	BYTE bPrinterState;
	int nRefPressure;		// +/-
	int nAccumPressure;		// +/-
	int nBufferPressure;	// +/-
	UINT bTemp;
	UINT nJet1Speed;
	UINT nJet2Speed;
} S7_PRINTERSTATUSINFO, *LPS7_PRINTERSTATUSINFO;

//
// S7 Message Indicator
//
typedef struct tag_S7_MESSAGEINDICATOR {
	BYTE fGenParamsPresent;
	BYTE fMsgPresent;
	UINT nNumCounters;
	UINT nNumPostdates;
	UINT nNumBarCodes;
} S7_MESSAGEINDICATOR, *LPS7_MESSAGEINDICATOR;

//
// S7 Message general parameters information
//
typedef struct tag_S7_GENPARAMINFO {
      BYTE bMsgModes;
      BYTE fMultitopActivation;
      UINT nTachoDivision;
      UINT nForwardMargin;
      UINT nReturnMargin;
      UINT nIntervalMargin;
      UINT nPrintingSpeed;
      UINT nMultilinePrinting;
} S7_GENPARAMINFO, *LPS7_GENPARAMINFO;

//
// S7 Counter parameters parameters information
//
typedef struct tag_S7_COUNTERPARAMINFO {
	BYTE bFirstByte;
	BYTE bSecondByte;
	ULONG lStartValue;
	ULONG lEndValue;
	UINT nStepCounter;
	UINT nIncDivider;
} S7_COUNTERPARAMINFO, *LPS7_COUNTERPARAMINFO;

//
// S7 Postdate info
//
typedef struct tag_S7_POSTDATEINFO {
	BYTE bType;	// Days/Months/Year
	UINT nValue;
} S7_POSTDATEINFO, *LPS7_POSTDATEINFO;
//
// S7 Barcode information
//
typedef struct tag_S7_BARCODEINFO {
	BYTE fSpecial;
	BYTE bIdentification;
	BYTE bTrameHeight;
	BYTE bBolderization;
	BYTE bNarrowBar;
	BYTE bNarrowSpace;
	BYTE bWideBar;
	BYTE bWideSpace;
	BYTE fVideoMode;
	BYTE fControlByte;
	BYTE bTextPos;
} S7_BARCODEINFO, *LPS7_BARCODEINFO;

//
// S7 Message variable parameters information
//
typedef struct tag_S7_VARPARAMINFO {
	S7_COUNTERPARAMINFO S7_CounterParamInfo[15];
	S7_POSTDATEINFO S7_PostdateInfo[6];
	S7_BARCODEINFO S7_BarCodeInfo[3];
} S7_VARPARAMINFO, *LPS7_VARPARAMINFO;

//
// S7 Message information
//
typedef struct tag_S7_MESSAGEINFO {
	S7_GENPARAMINFO S7_GenParamInfo;
	S7_VARPARAMINFO S7_VarParamInfo;
	BYTE bMessage[MAX_MSGLEN_4K];
	UINT nMsgLen;
} S7_MESSAGEINFO, *LPS7_MESSAGEINFO;

//
// S7 Partial Message information
//
typedef struct tag_S7_PARTIALMESSAGEINFO {
	UINT nNumAreasToAmend;
	BYTE bModificationMsg[MAX_MSGLEN_2K];
	UINT nMsgLen;
} S7_PARTIALMESSAGEINFO, *LPS7_PARTIALMESSAGEINFO;

//
// S7 Printer Fault information
//
typedef struct tag_S7_FAULTINFO {
	UINT nNumOfFaults;
	BYTE bFaultCodeData[128];
} S7_FAULTINFO, *LPS7_FAULTINFO;

//
// S7 Printer Fault History information
//
typedef struct tag_S7_FAULTHISTORYINFO {
	BYTE bFaultCode;
	UINT nDay;
	UINT nMonth;
	UINT nYear;
	UINT nHours;
	UINT nMin;
	S7_PRINTERSTATUSINFO arrS7_PrinterStatusInfo[10];
} S7_FAULTHISTORYINFO, *LPS7_FAULTHISTORYINFO;

//
// S7 Autoclock information
//
typedef struct tag_S7_AUTOCLOCKINFO {
	UINT nSec;
	UINT nMin;
	UINT nHours;
	TCHAR chHourMode;
	UINT nDay;
	UINT nMonth;
	UINT nYear;
	UINT nDayOfYear;
	UINT nWeekOfYear;
} S7_AUTOCLOCKINFO, *LPS7_AUTOCLOCKINFO;

//
// S7 Shiftcode1information
//
typedef struct tag_S7_SHIFTCODE1PARAMS {
	BYTE bStartHour;
	BYTE bStartMinute;
	TCHAR ch24HourMode;
	BYTE bIntervalHours;
	BYTE bIntervalMinutes;
} S7_SHIFTCODE1PARAMS, *LPS7_SHIFTCODE1PARAMS;

//
// S7 Shiftcode2information
//
typedef struct tag_S7_SHIFTCODE2PARAMS {
	BYTE bStartDay;
	BYTE bStartMonth;
	BYTE bStartHour;
	BYTE bStartMinute;
	TCHAR ch24HourMode;
	BYTE bIntervalDays;
	BYTE bIntervalHours;
	BYTE bIntervalMinutes;
} S7_SHIFTCODE2PARAMS, *LPS7_SHIFTCODE2PARAMS;

//
// S7 Shiftcode2information
//
typedef struct tag_S7_SHIFTCODE3PARAMS {
	BYTE bWeekTable[7];
	S7_SHIFTCODE1PARAMS ShiftCode1Params[7];
} S7_SHIFTCODE3PARAMS, *LPS7_SHIFTCODE3PARAMS;

//
// S7 Autodate parameters information
//
typedef struct tag_S7_AUTODATEPARAMINFO {
	UINT nPostdateModulo[6];
	BYTE bFirstDayOfCoding;
	BYTE bLanguage1;
	BYTE bLanguage2;
	S7_SHIFTCODE1PARAMS ShiftCode1Params;
	S7_SHIFTCODE2PARAMS ShiftCode2Params;
	S7_SHIFTCODE3PARAMS ShiftCode3Params;
} S7_AUTODATEPARAMINFO, *LPS7_AUTODATEPARAMINFO;

//
// S7 Autodate table information
//
typedef struct tag_S7_AUTODATETABLEINFO {
	BYTE bTypeOfTable;
	TCHAR szTableData[1536];
} S7_AUTODATETABLEINFO, *LPS7_AUTODATETABLEINFO;

//
//
// S7 Tacho and Flytime information
//
typedef struct tag_S7_TACHOFLYTIMEINFO {
	UINT nMeasurementType;
	ULONG lCountvalue;
} S7_TACHOFLYTIMEINFO, *LPS7_TACHOFLYTIMEINFO;

//
// S7 Printer Software version information
//
typedef struct tag_S7_SWVERSIONINFO {
	TCHAR szInkProcessorVer[4];
	UINT nAppType1;
	TCHAR szPrintProcessorVer[4];
	UINT nAppType2;
} S7_SWVERSIONINFO, *LPS7_SWVERSIONINFO;

//
// S7 Character generators
//
typedef struct tag_S7_CHARGEN {
	TCHAR chTitle[16];
	BYTE bRefNum;
	BYTE bDotsPerFrame;
	UINT nTramesPerChar;
	BYTE bNumChars;
	BYTE bNumByteOfFullTrame;
} S7_CHARGEN, *LPS7_CHARGEN;

//
// S7 Character generators information
//
typedef struct tag_S7_CHARGENINFO {
	UINT nNumGen;
	S7_CHARGEN arrS7CharGen[64];
} S7_CHARGENINFO, *LPS7_CHARGENINFO;

//
// S7 dates info structures
//
typedef struct tag_S7_DATEINFO
{
	BYTE bDay;
	BYTE bMonth;
	BYTE bYear;
} S7_DATEINFO, *LPS7_DATEINFO;

//
// S7 module info structures
// 
typedef struct tag_S7_MODULEINFO {
	UINT nHoursOfOperation;
	S7_DATEINFO DateInfo[4];
} S7_MODULEINFO, *LPS7_MODULEINFO;

//
// S7 Module change Date information
//
typedef struct tag_S7_MODULECHNGDATEINFO {
	S7_MODULEINFO InkManagementModule;
	S7_MODULEINFO PrintModule;
	S7_MODULEINFO SupplyModule;
	S7_MODULEINFO CommandModule;
	UINT nInkAddCounter;
	UINT nAdditiveAddCounter;
} S7_MODULECHNGDATEINFO, *LPS7_MODULECHNGDATEINFO;

//
// S7 Language of Month information
//
typedef struct tag_S7_LANGOFMONTHINFO {
	UINT nLanguage1;
	TCHAR szTable1[48];
	UINT nLanguage2;
	TCHAR szTable2[48];
} S7_LANGOFMONTHINFO, *LPS7_LANGOFMONTHINFO;


///////////////////////////////// End Of File /////////////////////////////////
#endif
