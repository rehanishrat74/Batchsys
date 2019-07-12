Attribute VB_Name = "modConstDecl"
'This module will contain constant declarations
'''''''''''''''''''''''''''''''''''''''''''''''
' The one and only success code
Public Const IJ_SUCCESS = &H0
' Generic error code
Public Const IJ_ERROR = &HFFFFFFFF
' Errors in detail (All negative values)
' General Errors
Public Const ERROR_NO_MEMORY = &HA0000000
Public Const ERROR_INVALID_ARGS = &HA1000000
Public Const ERROR_INVALID_CONNECTION = &HA2000000
' Communication Errors
Public Const ERROR_OPENING_PORT = &HB0000000
Public Const ERROR_COMM = &HB1000000
Public Const ERROR_IN_READ = &HB2000000
Public Const ERROR_IN_WRITE = &HB3000000
Public Const ERROR_COMM_TIMEOUT = &HB4000000
' Data Errors
Public Const ERROR_WRONG_DATA = &HC0000000
Public Const ERROR_WRONG_CRC = &HC1000000
' Printer Errors
Public Const ERROR_WRONG_PRINTER = &HD0000000
Public Const ERROR_NACK = &HD1000000
' Message building
Public Const ERROR_START_BUILD_NOT_CALLED = &HF0000000
Public Const ERROR_ADDBLOCK_NOT_CALLED = &HF1000000
Public Const ERROR_DATABUFFER_OVERFLOW = &HF2000000
' Miscellaneous
Public Const ERROR_FEATURE_NOT_SUPPORTED = &HE0000000
Public Const ERROR_IN_FILE_NAME = &HE1000000
Public Const ERROR_WRONG_FILE = &HE2000000
Public Const ERROR_IN_FILE_OPENING = &HE3000000
Public Const ERROR_DATA_OVERFLOW = &HE4000000
Public Const ERROR_NO_VERSIONINFO = &HE5000000
Public Const ERROR_FINDING_PORTS = &HE6000000
Public Const ERROR_NO_PORT_DETECTED = &HE7000000
' Printer id
Public Const S7PRINTERID = 2   'ID for S7 printer
Public Const S7SPRINTERID = 3  'ID for S7 printer
' Port constants
Public Const NOPARITY = 0
Public Const EVENPARITY = 2
Public Const ONESTOPBIT = 0
Public Const TWOSTOPBIT = 2
'constants for flow control for port operations
Public Const SOFTWARE_CONTROL = &H4
Public Const HARDWARE_CONTROL = &H2
Public Const NO_CONTROL = 0
'Constant for port number
Public Const COM1 = 1
Public Const COM2 = 2
Public Const COM3 = 3
Public Const COM4 = 4
'maximum message length
'Public Const MAX_MSGLEN_4K = 4096
'constants for printer set up
Public Const S7_JET_STOP = &H0
Public Const S7_JET_START = &H1
Public Const S7_PRINTER_STOP = &H8
Public Const S7_PRINTER_START_ON_STOP = &HC
Public Const S7_PRINTER_START_ON_STANDBY = &HD


'****************************************************
'9020
'****************************************************

Public Const S9020PRINTERID = 5 'ID for 9020/9030 printer
'Public Const IJ_SUCCESS = 0
Public Const MACHINE_RESTART = &HC
Public Const MACHINE_STOP = &H8
Public Const MAX_MSGLEN_4K = 4095
