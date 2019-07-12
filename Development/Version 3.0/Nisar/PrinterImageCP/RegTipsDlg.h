// RegTipsDlg.h : header file
//

#if !defined(AFX_REGTIPSDLG_H__3F00DAF1_E1E5_11D7_8E58_DD309E912959__INCLUDED_)
#define AFX_REGTIPSDLG_H__3F00DAF1_E1E5_11D7_8E58_DD309E912959__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CRegTipsDlg dialog

class CRegTipsDlg : public CDialog
{
// Construction
public:
	char *m_tmpChar;
	DWORD m_tmpWord;
	CRegTipsDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CRegTipsDlg)
	enum { IDD = IDD_REGTIPS_DIALOG };
	CEdit	m_editCtrl;
	CListBox	m_listRegistryText;
	CString	m_Title;
	CString	m_Message;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CRegTipsDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CRegTipsDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnSelchangeListRegistrytext();
	afx_msg void OnAddTip();
	afx_msg void OnRemoveTip();
	afx_msg void OnWindowsReboot();
	afx_msg void OnWindowsShutdown();
	afx_msg HBRUSH OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_REGTIPSDLG_H__3F00DAF1_E1E5_11D7_8E58_DD309E912959__INCLUDED_)
