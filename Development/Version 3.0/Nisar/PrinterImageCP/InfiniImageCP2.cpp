// TestDll2.cpp: implementation of the TestDll2 class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "TestDll2.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

TestDll2::TestDll2()
{

}

TestDll2::~TestDll2()
{

}

// TestDll.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include <windows.h>
#include <tchar.h>

#define MAX_CONNECTIONS		16
#define LEN_AUTODETECT_INFO	512
//
// Auto detect Info structure
//
typedef struct tag_AUTODETECTINFO {
	//TCHAR szAutoDetectInfo[LEN_AUTODETECT_INFO];
	DWORD dwPrinterID[MAX_CONNECTIONS];
} AUTODETECTINFO, *LPAUTODETECTINFO;




typedef UINT (CALLBACK* LPFNDLLFUNC1)(VOID);
typedef UINT (CALLBACK* LPFNDLLFUNC2)(LPCSTR);

HINSTANCE hDLL;              
LPFNDLLFUNC1 MyFunc1;    
LPFNDLLFUNC2 MyFunc2;
UINT  uReturnVal;



BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{



    return TRUE;
}
bool NisarFunction()
{
hDLL = LoadLibrary("c:\\IMASCP.dll");
if (hDLL != NULL)
	{
		Func1 = (LPFNDLLFUNC1)GetProcAddress(hDLL,"IJ_AutoSearchPrinter");
		MyFunc2 = (LPFNDLLFUNC2)GetProcAddress(hDLL,"MyDLLFunc2");

		if (!MyFunc1 || !MyFunc2)
		{
			//Show error message
			FreeLibrary(hDLL);       
			return false;
		}
		else
		{

		//ypedef AUTODETECTINFO (CALLBACK *MyFunc)(int);
		//yFunc PushLongData;
//shLongData = (MyFunc)GetProcAddress(hDLL,"IJ_AutoSearchPrinter");
			AUTODETECTINFO AutoDetect; // Auto DetectPrinter Structure
			int nNumOfPrintersDetected = 0; // No. of Printers Detected
			int nRet ;
			// Call the AutoDetect Printer API
		//	nRet = IJ_AutoSearchPrinter (&AutoDetect);
				nRet = (Func1)(&AutoDetect);
			// Copy the Number of Printers Detected
			nNumOfPrintersDetected = nRet;
			//printf("NisarKhan!\n") ;
			//uReturnVal = MyFunc1();
			//uReturnVal = MyFunc1();
			uReturnVal = MyFunc2("HELLO WORLD!");
		}
	}
return true;
}
int MyDLLFunc1() {
	MessageBox(NULL,"My DLL Function 1","",MB_OK);

	return true;
}

int MyDLLFunc2(char *TEXT) {
	MessageBox(NULL,TEXT,"",MB_OK);

	return true;
}
