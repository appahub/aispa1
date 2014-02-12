<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_showcustomer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grid_showcustomer = New System.Windows.Forms.DataGridView()
        CType(Me.grid_showcustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid_showcustomer
        '
        Me.grid_showcustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_showcustomer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_showcustomer.Location = New System.Drawing.Point(0, 0)
        Me.grid_showcustomer.Name = "grid_showcustomer"
        Me.grid_showcustomer.Size = New System.Drawing.Size(489, 262)
        Me.grid_showcustomer.TabIndex = 2
        '
        'form_showcustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 262)
        Me.Controls.Add(Me.grid_showcustomer)
        Me.Name = "form_showcustomer"
        Me.Text = "form_showcustomer"
        CType(Me.grid_showcustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grid_showcustomer As System.Windows.Forms.DataGridView
End Class
