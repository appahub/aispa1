<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_bring_old
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
        Me.tab_management = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_searchmember = New System.Windows.Forms.Button()
        Me.dtp_searchbydate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_seachbyemp = New System.Windows.Forms.Label()
        Me.lbl_searchbydate = New System.Windows.Forms.Label()
        Me.cbo_searchbyemp = New System.Windows.Forms.ComboBox()
        Me.grid_showbring = New System.Windows.Forms.DataGridView()
        Me.cbo_searchby = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grid_showproduct = New System.Windows.Forms.DataGridView()
        Me.cbo_prodtype = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_delbring = New System.Windows.Forms.Button()
        Me.btn_editbring = New System.Windows.Forms.Button()
        Me.btn_resetbring = New System.Windows.Forms.Button()
        Me.btn_addbring = New System.Windows.Forms.Button()
        Me.grid_bringprod = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.grid_showstockproduct = New System.Windows.Forms.DataGridView()
        Me.cbo_searchprods = New System.Windows.Forms.ComboBox()
        Me.btn_searchprods = New System.Windows.Forms.Button()
        Me.txt_searchprods = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tab_management.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grid_showbring, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grid_showproduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_bringprod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.grid_showstockproduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tab_management
        '
        Me.tab_management.Controls.Add(Me.TabPage1)
        Me.tab_management.Controls.Add(Me.TabPage3)
        Me.tab_management.Location = New System.Drawing.Point(0, 2)
        Me.tab_management.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tab_management.Name = "tab_management"
        Me.tab_management.SelectedIndex = 0
        Me.tab_management.Size = New System.Drawing.Size(1000, 733)
        Me.tab_management.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage1.Size = New System.Drawing.Size(992, 700)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "การเบิกผลิตภัณฑ์"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 5)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbo_prodtype)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_delbring)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_editbring)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_resetbring)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_addbring)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grid_bringprod)
        Me.SplitContainer1.Size = New System.Drawing.Size(984, 690)
        Me.SplitContainer1.SplitterDistance = 402
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_searchmember)
        Me.GroupBox2.Controls.Add(Me.dtp_searchbydate)
        Me.GroupBox2.Controls.Add(Me.lbl_seachbyemp)
        Me.GroupBox2.Controls.Add(Me.lbl_searchbydate)
        Me.GroupBox2.Controls.Add(Me.cbo_searchbyemp)
        Me.GroupBox2.Controls.Add(Me.grid_showbring)
        Me.GroupBox2.Controls.Add(Me.cbo_searchby)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 285)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(355, 367)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "รายการเบิกผลิตภัณฑ์"
        '
        'btn_searchmember
        '
        Me.btn_searchmember.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_searchmember.Image = Global.aispa.My.Resources.Resources.search_icon
        Me.btn_searchmember.Location = New System.Drawing.Point(107, 92)
        Me.btn_searchmember.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_searchmember.Name = "btn_searchmember"
        Me.btn_searchmember.Size = New System.Drawing.Size(86, 41)
        Me.btn_searchmember.TabIndex = 26
        Me.btn_searchmember.UseVisualStyleBackColor = True
        '
        'dtp_searchbydate
        '
        Me.dtp_searchbydate.Location = New System.Drawing.Point(107, 60)
        Me.dtp_searchbydate.Name = "dtp_searchbydate"
        Me.dtp_searchbydate.Size = New System.Drawing.Size(200, 26)
        Me.dtp_searchbydate.TabIndex = 11
        Me.dtp_searchbydate.Visible = False
        '
        'lbl_seachbyemp
        '
        Me.lbl_seachbyemp.AutoSize = True
        Me.lbl_seachbyemp.Location = New System.Drawing.Point(6, 63)
        Me.lbl_seachbyemp.Name = "lbl_seachbyemp"
        Me.lbl_seachbyemp.Size = New System.Drawing.Size(94, 20)
        Me.lbl_seachbyemp.TabIndex = 12
        Me.lbl_seachbyemp.Text = "พนักงานที่เบิก"
        Me.lbl_seachbyemp.Visible = False
        '
        'lbl_searchbydate
        '
        Me.lbl_searchbydate.AutoSize = True
        Me.lbl_searchbydate.Location = New System.Drawing.Point(42, 66)
        Me.lbl_searchbydate.Name = "lbl_searchbydate"
        Me.lbl_searchbydate.Size = New System.Drawing.Size(59, 20)
        Me.lbl_searchbydate.TabIndex = 10
        Me.lbl_searchbydate.Text = "วันที่เบิก"
        Me.lbl_searchbydate.Visible = False
        '
        'cbo_searchbyemp
        '
        Me.cbo_searchbyemp.FormattingEnabled = True
        Me.cbo_searchbyemp.Location = New System.Drawing.Point(108, 60)
        Me.cbo_searchbyemp.Name = "cbo_searchbyemp"
        Me.cbo_searchbyemp.Size = New System.Drawing.Size(163, 28)
        Me.cbo_searchbyemp.TabIndex = 13
        Me.cbo_searchbyemp.Visible = False
        '
        'grid_showbring
        '
        Me.grid_showbring.AllowUserToAddRows = False
        Me.grid_showbring.AllowUserToDeleteRows = False
        Me.grid_showbring.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grid_showbring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_showbring.Location = New System.Drawing.Point(6, 151)
        Me.grid_showbring.Name = "grid_showbring"
        Me.grid_showbring.ReadOnly = True
        Me.grid_showbring.Size = New System.Drawing.Size(342, 210)
        Me.grid_showbring.TabIndex = 0
        '
        'cbo_searchby
        '
        Me.cbo_searchby.FormattingEnabled = True
        Me.cbo_searchby.Items.AddRange(New Object() {"ทั้งหมด", "พนักงานที่เบิก", "วันที่เบิก"})
        Me.cbo_searchby.Location = New System.Drawing.Point(108, 25)
        Me.cbo_searchby.Name = "cbo_searchby"
        Me.cbo_searchby.Size = New System.Drawing.Size(200, 28)
        Me.cbo_searchby.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(34, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "ค้นหาจาก"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grid_showproduct)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(355, 192)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ผลิตภัณฑ์"
        '
        'grid_showproduct
        '
        Me.grid_showproduct.AllowUserToAddRows = False
        Me.grid_showproduct.AllowUserToDeleteRows = False
        Me.grid_showproduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_showproduct.Location = New System.Drawing.Point(7, 25)
        Me.grid_showproduct.Name = "grid_showproduct"
        Me.grid_showproduct.ReadOnly = True
        Me.grid_showproduct.Size = New System.Drawing.Size(342, 161)
        Me.grid_showproduct.TabIndex = 0
        '
        'cbo_prodtype
        '
        Me.cbo_prodtype.FormattingEnabled = True
        Me.cbo_prodtype.Location = New System.Drawing.Point(135, 53)
        Me.cbo_prodtype.Name = "cbo_prodtype"
        Me.cbo_prodtype.Size = New System.Drawing.Size(237, 28)
        Me.cbo_prodtype.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ประเภทผลิตภัณฑ์"
        '
        'btn_delbring
        '
        Me.btn_delbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_delbring.Image = Global.aispa.My.Resources.Resources.delete_icon
        Me.btn_delbring.Location = New System.Drawing.Point(257, 509)
        Me.btn_delbring.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_delbring.Name = "btn_delbring"
        Me.btn_delbring.Size = New System.Drawing.Size(79, 40)
        Me.btn_delbring.TabIndex = 96
        Me.btn_delbring.UseVisualStyleBackColor = True
        '
        'btn_editbring
        '
        Me.btn_editbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_editbring.Image = Global.aispa.My.Resources.Resources.edit_icon
        Me.btn_editbring.Location = New System.Drawing.Point(166, 553)
        Me.btn_editbring.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_editbring.Name = "btn_editbring"
        Me.btn_editbring.Size = New System.Drawing.Size(79, 40)
        Me.btn_editbring.TabIndex = 95
        Me.btn_editbring.UseVisualStyleBackColor = True
        Me.btn_editbring.Visible = False
        '
        'btn_resetbring
        '
        Me.btn_resetbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_resetbring.Image = Global.aispa.My.Resources.Resources.cancle_icon
        Me.btn_resetbring.Location = New System.Drawing.Point(352, 509)
        Me.btn_resetbring.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_resetbring.Name = "btn_resetbring"
        Me.btn_resetbring.Size = New System.Drawing.Size(79, 40)
        Me.btn_resetbring.TabIndex = 94
        Me.btn_resetbring.UseVisualStyleBackColor = True
        '
        'btn_addbring
        '
        Me.btn_addbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_addbring.Image = Global.aispa.My.Resources.Resources.add_icon
        Me.btn_addbring.Location = New System.Drawing.Point(166, 509)
        Me.btn_addbring.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_addbring.Name = "btn_addbring"
        Me.btn_addbring.Size = New System.Drawing.Size(79, 40)
        Me.btn_addbring.TabIndex = 93
        Me.btn_addbring.UseVisualStyleBackColor = True
        '
        'grid_bringprod
        '
        Me.grid_bringprod.AllowUserToAddRows = False
        Me.grid_bringprod.AllowUserToDeleteRows = False
        Me.grid_bringprod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_bringprod.Location = New System.Drawing.Point(20, 53)
        Me.grid_bringprod.Name = "grid_bringprod"
        Me.grid_bringprod.Size = New System.Drawing.Size(542, 431)
        Me.grid_bringprod.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.grid_showstockproduct)
        Me.TabPage3.Controls.Add(Me.cbo_searchprods)
        Me.TabPage3.Controls.Add(Me.btn_searchprods)
        Me.TabPage3.Controls.Add(Me.txt_searchprods)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage3.Size = New System.Drawing.Size(992, 700)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "ตรวจสอบจำนวนคงเหลือผลิตภัณฑ์"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'grid_showstockproduct
        '
        Me.grid_showstockproduct.AllowUserToAddRows = False
        Me.grid_showstockproduct.AllowUserToDeleteRows = False
        Me.grid_showstockproduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_showstockproduct.Location = New System.Drawing.Point(84, 109)
        Me.grid_showstockproduct.Name = "grid_showstockproduct"
        Me.grid_showstockproduct.Size = New System.Drawing.Size(841, 401)
        Me.grid_showstockproduct.TabIndex = 108
        '
        'cbo_searchprods
        '
        Me.cbo_searchprods.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbo_searchprods.FormattingEnabled = True
        Me.cbo_searchprods.Items.AddRange(New Object() {"ทั้งหมด", "ผลิตภัณฑ์ใกล้หมด", "ประเภทผลิตภัณฑ์", "ชื่อผลิตภัณฑ์"})
        Me.cbo_searchprods.Location = New System.Drawing.Point(277, 37)
        Me.cbo_searchprods.Margin = New System.Windows.Forms.Padding(2)
        Me.cbo_searchprods.Name = "cbo_searchprods"
        Me.cbo_searchprods.Size = New System.Drawing.Size(202, 28)
        Me.cbo_searchprods.TabIndex = 105
        '
        'btn_searchprods
        '
        Me.btn_searchprods.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_searchprods.Image = Global.aispa.My.Resources.Resources.search_icon
        Me.btn_searchprods.Location = New System.Drawing.Point(673, 28)
        Me.btn_searchprods.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_searchprods.Name = "btn_searchprods"
        Me.btn_searchprods.Size = New System.Drawing.Size(86, 41)
        Me.btn_searchprods.TabIndex = 107
        Me.btn_searchprods.UseVisualStyleBackColor = True
        '
        'txt_searchprods
        '
        Me.txt_searchprods.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_searchprods.Location = New System.Drawing.Point(483, 37)
        Me.txt_searchprods.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_searchprods.Name = "txt_searchprods"
        Me.txt_searchprods.Size = New System.Drawing.Size(175, 26)
        Me.txt_searchprods.TabIndex = 106
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(212, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 20)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "ค้นหาจาก"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'form_bring_old
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 737)
        Me.Controls.Add(Me.tab_management)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "form_bring_old"
        Me.Text = "form_bring"
        Me.tab_management.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grid_showbring, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grid_showproduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_bringprod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.grid_showstockproduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tab_management As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cbo_prodtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grid_showbring As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grid_showproduct As System.Windows.Forms.DataGridView
    Friend WithEvents grid_bringprod As System.Windows.Forms.DataGridView
    Friend WithEvents btn_delbring As System.Windows.Forms.Button
    Friend WithEvents btn_editbring As System.Windows.Forms.Button
    Friend WithEvents btn_resetbring As System.Windows.Forms.Button
    Friend WithEvents btn_addbring As System.Windows.Forms.Button
    Friend WithEvents lbl_seachbyemp As System.Windows.Forms.Label
    Friend WithEvents dtp_searchbydate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_searchbydate As System.Windows.Forms.Label
    Friend WithEvents cbo_searchbyemp As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_searchby As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_searchmember As System.Windows.Forms.Button
    Friend WithEvents grid_showstockproduct As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_searchprods As System.Windows.Forms.ComboBox
    Friend WithEvents btn_searchprods As System.Windows.Forms.Button
    Friend WithEvents txt_searchprods As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
