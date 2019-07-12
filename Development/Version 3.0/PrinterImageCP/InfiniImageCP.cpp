
/*
Created by : Nisar Khan
Date : 16 April 2008
Version : 1.0
*/

#include "stdafx.h"
#include <windows.h>
#include <tchar.h>
#include<iostream>
#include<string>
#include<fstream>


using namespace std;

#define MAX_CONNECTIONS		16
#define LEN_AUTODETECT_INFO	512
#define IJ_SUCCESS  0x00000000

//
// Auto detect Info structure
//

typedef struct tag_AUTODETECTINFO {
	TCHAR szAutoDetectInfo[LEN_AUTODETECT_INFO];
	DWORD dwPrinterID[MAX_CONNECTIONS];
} AUTODETECTINFO, *LPAUTODETECTINFO;

typedef struct tag_S7_SWVERSIONINFO {
	TCHAR szInkProcessorVer[4];
	UINT nAppType1;
	TCHAR szPrintProcessorVer[4];
	UINT nAppType2;
} S7_SWVERSIONINFO, *LPS7_SWVERSIONINFO;



typedef UINT (CALLBACK* LPFNDLLFUNC1)(LPAUTODETECTINFO);
typedef int (CALLBACK* LPFNDLLFUNC2)(LPTSTR);


HINSTANCE hDLL;
              
LPFNDLLFUNC1 AutoSearchPrinter; 
LPFNDLLFUNC2 GetVersionAPI; 

   

UINT  uReturnVal;



BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{   return TRUE; }


/*
Just for testing the applicaion
Created by Nisar Khan
*/

int testFunction()
{
MessageBox(NULL,"1\n","",MB_OK);
char* sFileName1="c:\\Log.TXT";

	HKEY hKey1 = 0;
	char buf1[255] = {0};
	DWORD dwType1 = 0;
	DWORD dwBufSize1 = sizeof(buf1);
	const char* subkey1 = "Software\\InfiniLogic\\ApplicationPath";
if( RegOpenKey(HKEY_LOCAL_MACHINE,subkey1,&hKey1) == ERROR_SUCCESS)
{
	MessageBox(NULL,"2\n","",MB_OK);
	dwType1 = REG_SZ;
	if( RegQueryValueEx(hKey1,"LogPath",0, &dwType1, (BYTE*)buf1, &dwBufSize1) == ERROR_SUCCESS)
	{
		MessageBox(NULL,"3\n","",MB_OK);
		//sFileName1="";
		string strFilePath (buf1);
		MessageBox(NULL,"4\n","",MB_OK);
		strFilePath += _T("\\Log.txt");
		MessageBox(NULL,"5\n","",MB_OK);
		FILE* fp1 ;
		const char* tempdl = strFilePath.c_str();
		MessageBox(NULL,"6\n","",MB_OK);
		//fp1 = fopen(sFileName1,"a");
		fp1 = fopen(tempdl,"a");
		MessageBox(NULL,"7\n","",MB_OK);
		MessageBox(NULL,tempdl,"",MB_OK);
		fprintf (fp1,"Data from test correct");
		fclose(fp1);
		MessageBox(NULL,"8\n","",MB_OK);

	}
}
return 1;
}


/*
It uses for get the API version that is being used by the printer
Created by Nisar Khan
*/

int GetAPIVersion() {

char* sFileName1="c:\\Log.TXT";

	HKEY hKey1 = 0;
	char buf1[255] = {0};
	DWORD dwType1 = 0;
	DWORD dwBufSize1 = sizeof(buf1);
	const char* subkey1 = "Software\\InfiniLogic\\ApplicationPath";
if( RegOpenKey(HKEY_LOCAL_MACHINE,subkey1,&hKey1) == ERROR_SUCCESS)
{
	dwType1 = REG_SZ;
	if( RegQueryValueEx(hKey1,"LogPath",0, &dwType1, (BYTE*)buf1, &dwBufSize1) == ERROR_SUCCESS)
	{
		sFileName1="";
		sFileName1=buf1;
	}
}

FILE* fp1 ;
fp1 = fopen(sFileName1,"a");
fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): Enter in GetAPIVersion of InfiniImageCP.dll ");
fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): Loading the  IMASCP.dll");

hDLL = LoadLibrary("IMASCP.dll");

fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): Loading complete of  IMASCP.dll");

int iRet=0;
char* sFileName="c:\\PrinterInfo.txt";

fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): Chencking the IMASCP.dll us loaded or not");
fclose(fp1);

if (hDLL != NULL)
{
	fp1 = fopen(sFileName1,"a");
	fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): The IMASCP.dll us loaded sucefully");
	fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): Reference and get the process adress of the function IJ_GetDLLVersion from loaded dll means IMASCP.dll");
	GetVersionAPI = (LPFNDLLFUNC2)GetProcAddress(hDLL,"IJ_GetDLLVersion");
	fprintf (fp1,"\nVC++ 6.0 : Function GetDLLVersion(): Checking reference and Process adress of the function IJ_GetDLLVersion from loaded dll means IMASCP.dll");
	fclose(fp1);
	if (!GetVersionAPI)
	{
		fp1 = fopen(sFileName1,"a");
		fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): reference and Process adress of the function IJ_GetDLLVersion from loaded dll means IMASCP.dll is not found");
		MessageBox(NULL,"the Function IJ_GetDLLVersion not load  from given dll","",MB_OK);
		FreeLibrary(hDLL); 
		fclose(fp1);
		return false;
	}
	else
	{
		fp1 = fopen(sFileName1,"a");
		fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): reference and Process adress of the function IJ_GetDLLVersion from loaded dll means IMASCP.dll is found");
		char szDLLVersion[255] = {0} ; 				
		int nRet = 0;
		fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): calling the function IJ_GetDLLVersion(szDLLVersion) of  IMASCP.dll ");
		fclose(fp1);
		nRet = GetVersionAPI(szDLLVersion);
		

		if( nRet != IJ_SUCCESS)
		{

			MessageBox(NULL,"Return value not Success\n","",MB_OK);
			
			fp1 = fopen(sFileName1,"a");
			fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): Return value not Success :");
			fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): return back and the value is :");
			fprintf (fp1, "%d",nRet);
			fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): return the reference string and the value of this string is :");
			fprintf (fp1, "%s",szDLLVersion);
			fprintf (fp1,"\nVC++ 6.0 : The process of function GetAPIVersion() of InfiniImageCP is completed and return the value \n");
			fclose(fp1);
			
			return nRet;
		}
		else
		{
			if (strcmp (szDLLVersion, "1.0.1.0") != 0)
			{
				fp1 = fopen(sFileName1,"a");
				fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): Incorrect DLL Version :");
				fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): return back and the value is :");
				fprintf (fp1, "%d",nRet);
				fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): return the reference string and the value of this string is :");
				fprintf (fp1, "%s",szDLLVersion);
				fprintf (fp1,"\nVC++ 6.0 : The process of function GetAPIVersion()of InfiniImage2 is completed and return the value \n");
				fclose(fp1);
			
				return nRet;
			}
			
			fp1 = fopen(sFileName1,"a");
			fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): Correct DLL Version :");
			fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): return back and the value is :");
			fprintf (fp1, "%d",nRet);
			fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): return the reference string and the value of this string is :");
			fprintf (fp1, "%s",szDLLVersion);
			fprintf (fp1,"\nVC++ 6.0 : The process of function GetAPIVersion()of InfiniImage2 is completed and return the value \n");
			fclose(fp1);

			return nRet;
		}
	}
}
else
{
	MessageBox(NULL,"Not Load the dll  IMASCP.dll.....","",MB_OK);
	
	fp1 = fopen(sFileName1,"a");
	fprintf (fp1,"\nVC++ 6.0 : Function GetAPIVersion(): The IMASCP.dll not loaded sucefully");
	fprintf (fp1,"\nVC++ 6.0 : The process of function GetAPIVersion()of InfiniImage2 is completed and return the value \n");
	fclose(fp1);
	
	return 0;
}

}

/*
It uses for Search the printer by auto functionality and return the number of printer if found
or negative value
Created by Nisar Khan
*/

int SearchPrinter() {

char* sFileName1="c:\\Log.txt";

	HKEY hKey1 = 0;
	char buf1[255] = {0};
	DWORD dwType1 = 0;
	DWORD dwBufSize1 = sizeof(buf1);

	const char* subkey1 = "Software\\InfiniLogic\\ApplicationPath";

if( RegOpenKey(HKEY_LOCAL_MACHINE,subkey1,&hKey1) == ERROR_SUCCESS)
{
	dwType1 = REG_SZ;
	if( RegQueryValueEx(hKey1,"LogPath",0, &dwType1, (BYTE*)buf1, &dwBufSize1) == ERROR_SUCCESS)
	{
		sFileName1="";
		sFileName1=buf1;
	}

	FILE* fp1 ;
	fp1 = fopen(sFileName1,"a");
	fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : Enter in SearchPrinter() of InfiniImageCP.dll ");
	fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : Loading the  IMASCP.dll");
	hDLL = LoadLibrary("IMASCP.dll");
	fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : Loading complete of  IMASCP.dll");

	int iRet=0;
	char* sFileName="c:\\PrinterInfo.TXT";

	fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : Chencking the IMASCP.dll us loaded or not");
	fclose(fp1);

	if (hDLL != NULL)
		{
		fp1 = fopen(sFileName1,"a");
			fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : The IMASCP.dll us loaded sucefully");
			fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : Reference and get the process adress of the function IJ_AutoSearchPrinter from loaded dll means IMASCP.dll");
			AutoSearchPrinter = (LPFNDLLFUNC1)GetProcAddress(hDLL,"IJ_AutoSearchPrinter");
			fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : Checking reference and Process adress of the function IJ_AutoSearchPrinter from loaded dll means IMASCP.dll");
			fclose(fp1);
			if (!AutoSearchPrinter)
			{
				fp1 = fopen(sFileName1,"a");
				fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : reference and Process adress of the function IJ_AutoSearchPrinter from loaded dll means IMASCP.dll is not found");
				MessageBox(NULL,"the Function IJ_AutoSearchPriner not load  from given dll","",MB_OK);
				FreeLibrary(hDLL);
				fclose(fp1);
				return false;
			}
			else
			{
				fp1 = fopen(sFileName1,"a");
				fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : reference and Process adress of the function IJ_AutoSearchPrinter from loaded dll means IMASCP.dll is found");
				fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : Delare AUTODETECTINFO AutoDetect for Function IJ_AutoSearchPrinter()");
				AUTODETECTINFO AutoDetect; // Auto DetectPrinter Structure
				int nNumOfPrintersDetected = 0; // No. of Printers Detected
				int nRet=0 ;
				fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : Calling Function IJ_AutoSearchPrinter() of IMASCP.dll");
				nRet = AutoSearchPrinter(&AutoDetect);
				fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : Calling complete and return from Function IJ_AutoSearchPrinter() of IMASCP.dll");
				fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : The return value is :");
				fprintf (fp1, "%d",nRet);
				fprintf (fp1," IJ_AutoSearchPrinter() of IMASCP.dll");
				iRet=nRet;
				fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : Checking the return value");
				fclose(fp1);
				if(nRet>0)
				{
					fp1 = fopen(sFileName1,"a");
					fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : the return value is grather then 0");
					nNumOfPrintersDetected=iRet;
					fprintf (fp1,"\nVC++ 6.0 : Start process for creating xml file which have printer id and printer information");
					HKEY hKey = 0;
					char buf[255] = {0};
					DWORD dwType = 0;
					DWORD dwBufSize = sizeof(buf);
					const char* subkey = "Software\\InfiniLogic\\ApplicationPath";

					if( RegOpenKey(HKEY_LOCAL_MACHINE,subkey,&hKey) == ERROR_SUCCESS)
					{
						dwType = REG_SZ;
						if( RegQueryValueEx(hKey,"PrintInfoPath",0, &dwType, (BYTE*)buf, &dwBufSize) == ERROR_SUCCESS)
						{
	
							sFileName="";
							sFileName=buf;
		
						}
					/*else{}*/
					RegCloseKey(hKey);
					}
					/*else{//MessageBox(NULL,"Can not open key\n","",MB_OK);}*/
				
					FILE* fp ;
					
					fp = fopen(sFileName,"w");
					
				 int i=0;
					

					fprintf (fp,"<root>");

					for (i = 0; i < nNumOfPrintersDetected; i++)
						{
					
							fprintf (fp,"\n<p>");		
							fprintf (fp,"%d",AutoDetect.dwPrinterID[i]);		
							fprintf (fp,"</p>");		
						}

					fprintf (fp,"\n<printerinfo>");
					fprintf (fp,"%s", AutoDetect.szAutoDetectInfo);
					fprintf (fp,"</printerinfo>");
					
					fprintf (fp,"\n</root>");
					fprintf (fp1,"\nVC++ 6.0 : End process for creating xml file which have printer id and printer information");
					fprintf (fp1,"\nVC++ 6.0 : The process of function SearchPrinter of InfiniImage2 is completed and return the value \n");
					fclose(fp);
					fclose(fp1);
					return nRet;
				}
				else
				{

					///// testing

					AutoDetect.szAutoDetectInfo[0]="a";
					//// testing end
					fp1 = fopen(sFileName1,"a");
					fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : the return value is not grather then 0");
					
					MessageBox(NULL,"Printer(s) not found..!","",MB_OK);
					fprintf (fp1,"\nVC++ 6.0 : The process of function SearchPrinter of InfiniImage2 is completed and return the value\n ");
					fclose(fp1);
					return 0;
				}
			}
		}
	else
	{
		MessageBox(NULL,"Not Load the dll  IMASCP.dll.....","",MB_OK);

		fp1 = fopen(sFileName1,"a");
		fprintf (fp1,"\nVC++ 6.0 : Function SearchPrinter : The IMASCP.dll not loaded sucefully");
		fprintf (fp1,"\nVC++ 6.0 : The process of function SearchPrinter of InfiniImage2 is completed and return the value \n");
		fclose(fp1);

		return 0;
	}
}

}