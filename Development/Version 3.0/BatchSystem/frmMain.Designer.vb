<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTrace = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SerialsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RegionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TextFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SingleRepotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MultipleSerialsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrinterSetPort = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrinterClosePort = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrinterStartStopMachine = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrinterStatus = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrinterCodePrint = New System.Windows.Forms.ToolStripMenuItem
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpTopicsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SendLogFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.PrinteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.FormToolStripMenuItem, Me.ReportToolStripMenuItem, Me.TestToolStripMenuItem, Me.PrinterToolStripMenuItem, Me.UserToolStripMenuItem, Me.HelpToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(368, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.CloseToolStripMenuItem, Me.mnuTrace, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'mnuTrace
        '
        Me.mnuTrace.CheckOnClick = True
        Me.mnuTrace.Name = "mnuTrace"
        Me.mnuTrace.Size = New System.Drawing.Size(112, 22)
        Me.mnuTrace.Text = "Trace"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'FormToolStripMenuItem
        '
        Me.FormToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SerialsToolStripMenuItem, Me.ProductsToolStripMenuItem, Me.RegionsToolStripMenuItem})
        Me.FormToolStripMenuItem.Name = "FormToolStripMenuItem"
        Me.FormToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.FormToolStripMenuItem.Text = "Form"
        '
        'SerialsToolStripMenuItem
        '
        Me.SerialsToolStripMenuItem.Name = "SerialsToolStripMenuItem"
        Me.SerialsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SerialsToolStripMenuItem.Text = "Security Code"
        '
        'ProductsToolStripMenuItem
        '
        Me.ProductsToolStripMenuItem.Name = "ProductsToolStripMenuItem"
        Me.ProductsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ProductsToolStripMenuItem.Text = "Products"
        '
        'RegionsToolStripMenuItem
        '
        Me.RegionsToolStripMenuItem.Name = "RegionsToolStripMenuItem"
        Me.RegionsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RegionsToolStripMenuItem.Text = "Regions"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TextFileToolStripMenuItem, Me.SingleRepotToolStripMenuItem, Me.MultipleSerialsToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ReportToolStripMenuItem.Text = "&Report"
        '
        'TextFileToolStripMenuItem
        '
        Me.TextFileToolStripMenuItem.Name = "TextFileToolStripMenuItem"
        Me.TextFileToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.TextFileToolStripMenuItem.Text = "Text File"
        '
        'SingleRepotToolStripMenuItem
        '
        Me.SingleRepotToolStripMenuItem.Name = "SingleRepotToolStripMenuItem"
        Me.SingleRepotToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.SingleRepotToolStripMenuItem.Text = "Security Code"
        '
        'MultipleSerialsToolStripMenuItem
        '
        Me.MultipleSerialsToolStripMenuItem.Name = "MultipleSerialsToolStripMenuItem"
        Me.MultipleSerialsToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.MultipleSerialsToolStripMenuItem.Text = "Multiple Security Codes"
        '
        'PrinterToolStripMenuItem
        '
        Me.PrinterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrinterSetPort, Me.mnuPrinterClosePort, Me.mnuPrinterStartStopMachine, Me.mnuPrinterStatus, Me.mnuPrinterCodePrint})
        Me.PrinterToolStripMenuItem.Name = "PrinterToolStripMenuItem"
        Me.PrinterToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.PrinterToolStripMenuItem.Text = "Printer"
        Me.PrinterToolStripMenuItem.Visible = False
        '
        'mnuPrinterSetPort
        '
        Me.mnuPrinterSetPort.Name = "mnuPrinterSetPort"
        Me.mnuPrinterSetPort.Size = New System.Drawing.Size(195, 22)
        Me.mnuPrinterSetPort.Text = "Port Configuration"
        '
        'mnuPrinterClosePort
        '
        Me.mnuPrinterClosePort.Enabled = False
        Me.mnuPrinterClosePort.Name = "mnuPrinterClosePort"
        Me.mnuPrinterClosePort.Size = New System.Drawing.Size(195, 22)
        Me.mnuPrinterClosePort.Text = "Close Port"
        '
        'mnuPrinterStartStopMachine
        '
        Me.mnuPrinterStartStopMachine.Enabled = False
        Me.mnuPrinterStartStopMachine.Name = "mnuPrinterStartStopMachine"
        Me.mnuPrinterStartStopMachine.Size = New System.Drawing.Size(195, 22)
        Me.mnuPrinterStartStopMachine.Text = "Start/Stop Machine Jet"
        '
        'mnuPrinterStatus
        '
        Me.mnuPrinterStatus.Enabled = False
        Me.mnuPrinterStatus.Name = "mnuPrinterStatus"
        Me.mnuPrinterStatus.Size = New System.Drawing.Size(195, 22)
        Me.mnuPrinterStatus.Text = "Pritner Status"
        '
        'mnuPrinterCodePrint
        '
        Me.mnuPrinterCodePrint.Enabled = False
        Me.mnuPrinterCodePrint.Name = "mnuPrinterCodePrint"
        Me.mnuPrinterCodePrint.Size = New System.Drawing.Size(195, 22)
        Me.mnuPrinterCodePrint.Text = "Print Security Codes"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateToolStripMenuItem})
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'CreateToolStripMenuItem
        '
        Me.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem"
        Me.CreateToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CreateToolStripMenuItem.Text = "Create"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpTopicsToolStripMenuItem, Me.AboutToolStripMenuItem, Me.SendLogFileToolStripMenuItem})
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem1.Text = "&Help"
        '
        'HelpTopicsToolStripMenuItem
        '
        Me.HelpTopicsToolStripMenuItem.Name = "HelpTopicsToolStripMenuItem"
        Me.HelpTopicsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HelpTopicsToolStripMenuItem.Text = "Help Topics"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem.Text = "About Us"
        '
        'SendLogFileToolStripMenuItem
        '
        Me.SendLogFileToolStripMenuItem.Name = "SendLogFileToolStripMenuItem"
        Me.SendLogFileToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SendLogFileToolStripMenuItem.Text = "Send Log File"
        Me.SendLogFileToolStripMenuItem.Visible = False
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrinteToolStripMenuItem})
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.TestToolStripMenuItem.Text = "Printer"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PrinteToolStripMenuItem
        '
        Me.PrinteToolStripMenuItem.Name = "PrinteToolStripMenuItem"
        Me.PrinteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PrinteToolStripMenuItem.Text = "Print"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 396)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximumSize = New System.Drawing.Size(376, 423)
        Me.MinimumSize = New System.Drawing.Size(376, 423)
        Me.Name = "frmMain"
        Me.Text = "Diagnostic TBS Security Code"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SerialsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SingleRepotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MultipleSerialsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpTopicsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrinterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrinterSetPort As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrinterCodePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrinterClosePort As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrinterStartStopMachine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrinterStatus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendLogFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrinteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
