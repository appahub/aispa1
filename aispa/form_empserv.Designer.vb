<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_empserv
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grid_servemp = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.haveemp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_confirm = New System.Windows.Forms.Button()
        Me.btn_cancle = New System.Windows.Forms.Button()
        CType(Me.grid_servemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "กรุณาเลือกพนักงาน"
        '
        'grid_servemp
        '
        Me.grid_servemp.AllowUserToAddRows = False
        Me.grid_servemp.AllowUserToDeleteRows = False
        Me.grid_servemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_servemp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.id, Me.type, Me.haveemp})
        Me.grid_servemp.Location = New System.Drawing.Point(27, 56)
        Me.grid_servemp.Name = "grid_servemp"
        Me.grid_servemp.Size = New System.Drawing.Size(550, 182)
        Me.grid_servemp.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "รายการบริการ / โปรโมชั่น"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 160
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'type
        '
        Me.type.HeaderText = "type"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        Me.type.Visible = False
        '
        'haveemp
        '
        Me.haveemp.HeaderText = "พนักงานที่ทำบริการ"
        Me.haveemp.Name = "haveemp"
        Me.haveemp.ReadOnly = True
        Me.haveemp.Width = 160
        '
        'btn_confirm
        '
        Me.btn_confirm.Location = New System.Drawing.Point(65, 245)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(134, 40)
        Me.btn_confirm.TabIndex = 2
        Me.btn_confirm.Text = "ยืนยัน"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'btn_cancle
        '
        Me.btn_cancle.Location = New System.Drawing.Point(205, 245)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(134, 40)
        Me.btn_cancle.TabIndex = 3
        Me.btn_cancle.Text = "ยกเลิก"
        Me.btn_cancle.UseVisualStyleBackColor = True
        '
        'form_empserv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 297)
        Me.Controls.Add(Me.btn_cancle)
        Me.Controls.Add(Me.btn_confirm)
        Me.Controls.Add(Me.grid_servemp)
        Me.Controls.Add(Me.Label1)
        Me.Name = "form_empserv"
        Me.Text = "form_empserv"
        CType(Me.grid_servemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grid_servemp As System.Windows.Forms.DataGridView
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents btn_cancle As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents haveemp As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
