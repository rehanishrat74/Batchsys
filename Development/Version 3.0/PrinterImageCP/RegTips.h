// RegTips.h : main header file for the REGTIPS application
//

#if !defined(AFX_REGTIPS_H__3F00DAEF_E1E5_11D7_8E58_DD309E912959__INCLUDED_)
#define AFX_REGTIPS_H__3F00DAEF_E1E5_11D7_8E58_DD309E912959__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

//#ifndef __AFXWIN_H__
//	#error include 'stdafx.h' before including this file for PCH
include "stdafx.h"
//#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CRegTipsApp:
// See RegTips.cpp for the implementation of this class
//

class CRegTipsApp : public CWinApp
{
public:
	CRegTipsApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CRegTipsApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CRegTipsApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_REGTIPS_H__3F00DAEF_E1E5_11D7_8E58_DD309E912959__INCLUDED_)
