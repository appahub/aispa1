<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_showservlist
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
        Me.grid_showservlist = New System.Windows.Forms.DataGridView()
        CType(Me.grid_showservlist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid_showservlist
        '
        Me.grid_showservlist.AllowUserToAddRows = False
        Me.grid_showservlist.AllowUserToDeleteRows = False
        Me.grid_showservlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_showservlist.Location = New System.Drawing.Point(0, 0)
        Me.grid_showservlist.Name = "grid_showservlist"
        Me.grid_showservlist.ReadOnly = True
        Me.grid_showservlist.Size = New System.Drawing.Size(388, 262)
        Me.grid_showservlist.TabIndex = 2
        '
        'form_showservlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 262)
        Me.Controls.Add(Me.grid_showservlist)
        Me.Name = "form_showservlist"
        Me.Text = "form_showservlist"
        CType(Me.grid_showservlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grid_showservlist As System.Windows.Forms.DataGridView
End Class
