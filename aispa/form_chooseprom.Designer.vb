<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_chooseprom
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
        Me.grid_chooseprom = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_chooseprom = New System.Windows.Forms.Button()
        Me.choose = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ชื่อโปรโมชั่น = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.promtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.promprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.liservid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grid_chooseprom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid_chooseprom
        '
        Me.grid_chooseprom.AllowUserToAddRows = False
        Me.grid_chooseprom.AllowUserToDeleteRows = False
        Me.grid_chooseprom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_chooseprom.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.choose, Me.ชื่อโปรโมชั่น, Me.promtype, Me.promprice, Me.servid, Me.liservid})
        Me.grid_chooseprom.Location = New System.Drawing.Point(1, 37)
        Me.grid_chooseprom.Name = "grid_chooseprom"
        Me.grid_chooseprom.Size = New System.Drawing.Size(319, 170)
        Me.grid_chooseprom.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "เลือกโปรโมชั่น"
        '
        'btn_chooseprom
        '
        Me.btn_chooseprom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_chooseprom.Location = New System.Drawing.Point(58, 213)
        Me.btn_chooseprom.Name = "btn_chooseprom"
        Me.btn_chooseprom.Size = New System.Drawing.Size(186, 37)
        Me.btn_chooseprom.TabIndex = 2
        Me.btn_chooseprom.Text = "เลือกโปรโมชั่น"
        Me.btn_chooseprom.UseVisualStyleBackColor = True
        '
        'choose
        '
        Me.choose.HeaderText = "เลือก"
        Me.choose.Name = "choose"
        '
        'ชื่อโปรโมชั่น
        '
        Me.ชื่อโปรโมชั่น.HeaderText = "ชื่อโปรโมชั่น"
        Me.ชื่อโปรโมชั่น.Name = "ชื่อโปรโมชั่น"
        Me.ชื่อโปรโมชั่น.ReadOnly = True
        Me.ชื่อโปรโมชั่น.Width = 175
        '
        'promtype
        '
        Me.promtype.HeaderText = "promtype"
        Me.promtype.Name = "promtype"
        Me.promtype.ReadOnly = True
        Me.promtype.Visible = False
        '
        'promprice
        '
        Me.promprice.HeaderText = "promprice"
        Me.promprice.Name = "promprice"
        Me.promprice.ReadOnly = True
        Me.promprice.Visible = False
        '
        'servid
        '
        Me.servid.HeaderText = "promid"
        Me.servid.Name = "servid"
        Me.servid.ReadOnly = True
        Me.servid.Visible = False
        '
        'liservid
        '
        Me.liservid.HeaderText = "liservid"
        Me.liservid.Name = "liservid"
        Me.liservid.ReadOnly = True
        Me.liservid.Visible = False
        '
        'form_chooseprom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 262)
        Me.Controls.Add(Me.btn_chooseprom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grid_chooseprom)
        Me.Name = "form_chooseprom"
        Me.Text = "form_chooseprom"
        CType(Me.grid_chooseprom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid_chooseprom As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_chooseprom As System.Windows.Forms.Button
    Friend WithEvents choose As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ชื่อโปรโมชั่น As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents promtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents promprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents servid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents liservid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
