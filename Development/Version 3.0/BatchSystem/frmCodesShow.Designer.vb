<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodesShow
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
        Me.dtgCodes = New System.Windows.Forms.DataGridView
        Me.txtRange = New System.Windows.Forms.TextBox
        Me.btnPrinted = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.optRange = New System.Windows.Forms.RadioButton
        Me.optCode = New System.Windows.Forms.RadioButton
        Me.lblProduct = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dtgCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgCodes
        '
        Me.dtgCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCodes.Location = New System.Drawing.Point(12, 89)
        Me.dtgCodes.MultiSelect = False
        Me.dtgCodes.Name = "dtgCodes"
        Me.dtgCodes.ReadOnly = True
        Me.dtgCodes.Size = New System.Drawing.Size(337, 243)
        Me.dtgCodes.TabIndex = 1
        '
        'txtRange
        '
        Me.txtRange.Location = New System.Drawing.Point(101, 29)
        Me.txtRange.Name = "txtRange"
        Me.txtRange.Size = New System.Drawing.Size(75, 20)
        Me.txtRange.TabIndex = 3
        '
        'btnPrinted
        '
        Me.btnPrinted.Location = New System.Drawing.Point(12, 338)
        Me.btnPrinted.Name = "btnPrinted"
        Me.btnPrinted.Size = New System.Drawing.Size(75, 23)
        Me.btnPrinted.TabIndex = 6
        Me.btnPrinted.Text = "Print Code"
        Me.btnPrinted.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(101, 338)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'optRange
        '
        Me.optRange.AutoSize = True
        Me.optRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRange.Location = New System.Drawing.Point(9, 30)
        Me.optRange.Name = "optRange"
        Me.optRange.Size = New System.Drawing.Size(94, 19)
        Me.optRange.TabIndex = 8
        Me.optRange.TabStop = True
        Me.optRange.Text = "Enter Range"
        Me.optRange.UseVisualStyleBackColor = True
        '
        'optCode
        '
        Me.optCode.AutoSize = True
        Me.optCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optCode.Location = New System.Drawing.Point(9, 60)
        Me.optCode.Name = "optCode"
        Me.optCode.Size = New System.Drawing.Size(145, 19)
        Me.optCode.TabIndex = 9
        Me.optCode.TabStop = True
        Me.optCode.Text = "Select Code from Grid"
        Me.optCode.UseVisualStyleBackColor = True
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(101, 9)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(0, 13)
        Me.lblProduct.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Product Name :"
        '
        'frmCodesShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 366)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblProduct)
        Me.Controls.Add(Me.optCode)
        Me.Controls.Add(Me.optRange)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPrinted)
        Me.Controls.Add(Me.txtRange)
        Me.Controls.Add(Me.dtgCodes)
        Me.MaximumSize = New System.Drawing.Size(369, 393)
        Me.MinimumSize = New System.Drawing.Size(369, 393)
        Me.Name = "frmCodesShow"
        Me.Text = "Security Codes for Printing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgCodes As System.Windows.Forms.DataGridView
    Friend WithEvents txtRange As System.Windows.Forms.TextBox
    Friend WithEvents btnPrinted As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents optRange As System.Windows.Forms.RadioButton
    Friend WithEvents optCode As System.Windows.Forms.RadioButton
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
