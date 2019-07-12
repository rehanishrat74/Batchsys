<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewReport
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewReport))
        Me.rptViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SerialReportBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportDataSet = New BatchSystem.ReportDataSet
        Me.SerialReportTableAdapter = New BatchSystem.ReportDataSetTableAdapters.SerialReportTableAdapter
        CType(Me.SerialReportBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptViewer
        '
        Me.rptViewer.ActiveViewIndex = -1
        Me.rptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptViewer.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.SerialReportBindingSource, "Serials", True))
        Me.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptViewer.Location = New System.Drawing.Point(0, 0)
        Me.rptViewer.Name = "rptViewer"
        Me.rptViewer.SelectionFormula = ""
        Me.rptViewer.ShowGroupTreeButton = False
        Me.rptViewer.Size = New System.Drawing.Size(613, 493)
        Me.rptViewer.TabIndex = 0
        Me.rptViewer.ViewTimeSelectionFormula = ""
        '
        'SerialReportBindingSource
        '
        Me.SerialReportBindingSource.DataMember = "SerialReport"
        Me.SerialReportBindingSource.DataSource = Me.ReportDataSet
        '
        'ReportDataSet
        '
        Me.ReportDataSet.DataSetName = "ReportDataSet"
        Me.ReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SerialReportTableAdapter
        '
        Me.SerialReportTableAdapter.ClearBeforeFill = True
        '
        'frmViewReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 493)
        Me.Controls.Add(Me.rptViewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmViewReport"
        Me.Text = "frmViewReport"
        CType(Me.SerialReportBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ReportDataSet As BatchSystem.ReportDataSet
    Friend WithEvents SerialReportBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SerialReportTableAdapter As BatchSystem.ReportDataSetTableAdapters.SerialReportTableAdapter
End Class
