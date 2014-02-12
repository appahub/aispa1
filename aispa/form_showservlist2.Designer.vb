<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_showservlist2
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
        Me.grid_showservlist2 = New System.Windows.Forms.DataGridView()
        CType(Me.grid_showservlist2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid_showservlist2
        '
        Me.grid_showservlist2.AllowUserToAddRows = False
        Me.grid_showservlist2.AllowUserToDeleteRows = False
        Me.grid_showservlist2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_showservlist2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_showservlist2.Location = New System.Drawing.Point(0, 0)
        Me.grid_showservlist2.Name = "grid_showservlist2"
        Me.grid_showservlist2.ReadOnly = True
        Me.grid_showservlist2.Size = New System.Drawing.Size(388, 262)
        Me.grid_showservlist2.TabIndex = 3
        '
        'form_showservlist2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 262)
        Me.Controls.Add(Me.grid_showservlist2)
        Me.Name = "form_showservlist2"
        Me.Text = "form_showservlist2"
        CType(Me.grid_showservlist2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grid_showservlist2 As System.Windows.Forms.DataGridView
End Class
