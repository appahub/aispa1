<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_in_out
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
        Me.components = New System.ComponentModel.Container()
        Me.tab_management = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cbo_inoutpos = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_showdate = New System.Windows.Forms.TextBox()
        Me.txt_empname = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_searchmemid = New System.Windows.Forms.Button()
        Me.btn_resetinout = New System.Windows.Forms.Button()
        Me.btn_addinout = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_inout = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_showcurrentdate = New System.Windows.Forms.Label()
        Me.grid_showinout = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lblend = New System.Windows.Forms.Label()
        Me.lblstart = New System.Windows.Forms.Label()
        Me.dtpend = New System.Windows.Forms.DateTimePicker()
        Me.dtpstart = New System.Windows.Forms.DateTimePicker()
        Me.txt_ename = New System.Windows.Forms.TextBox()
        Me.lbl_ename = New System.Windows.Forms.Label()
        Me.cbo_searchinout = New System.Windows.Forms.ComboBox()
        Me.lbl_pos = New System.Windows.Forms.Label()
        Me.cbo_searchby = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_searchmemid2 = New System.Windows.Forms.Button()
        Me.btn_searchinout = New System.Windows.Forms.Button()
        Me.dtp_searchinout = New System.Windows.Forms.DateTimePicker()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.txt_searchinout = New System.Windows.Forms.TextBox()
        Me.lbl_empid = New System.Windows.Forms.Label()
        Me.grid_searchinout = New System.Windows.Forms.DataGridView()
        Me.autoUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.tab_management.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grid_showinout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.grid_searchinout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tab_management
        '
        Me.tab_management.Controls.Add(Me.TabPage1)
        Me.tab_management.Controls.Add(Me.TabPage2)
        Me.tab_management.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_management.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.tab_management.Location = New System.Drawing.Point(0, 0)
        Me.tab_management.Name = "tab_management"
        Me.tab_management.SelectedIndex = 0
        Me.tab_management.Size = New System.Drawing.Size(988, 612)
        Me.tab_management.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(980, 579)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "บันทึกเวลาเข้า - ออก งาน"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbo_inoutpos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txt_showdate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txt_empname)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_searchmemid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_resetinout)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_addinout)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txt_inout)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.lbl_showcurrentdate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grid_showinout)
        Me.SplitContainer1.Size = New System.Drawing.Size(974, 573)
        Me.SplitContainer1.SplitterDistance = 320
        Me.SplitContainer1.TabIndex = 0
        '
        'cbo_inoutpos
        '
        Me.cbo_inoutpos.FormattingEnabled = True
        Me.cbo_inoutpos.Location = New System.Drawing.Point(114, 80)
        Me.cbo_inoutpos.Name = "cbo_inoutpos"
        Me.cbo_inoutpos.Size = New System.Drawing.Size(147, 28)
        Me.cbo_inoutpos.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "ตำแหน่ง"
        '
        'txt_showdate
        '
        Me.txt_showdate.Enabled = False
        Me.txt_showdate.Location = New System.Drawing.Point(114, 190)
        Me.txt_showdate.Name = "txt_showdate"
        Me.txt_showdate.Size = New System.Drawing.Size(175, 26)
        Me.txt_showdate.TabIndex = 9
        '
        'txt_empname
        '
        Me.txt_empname.Enabled = False
        Me.txt_empname.Location = New System.Drawing.Point(114, 154)
        Me.txt_empname.Name = "txt_empname"
        Me.txt_empname.Size = New System.Drawing.Size(147, 26)
        Me.txt_empname.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 20)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "ชื่อพนักงาน"
        '
        'btn_searchmemid
        '
        Me.btn_searchmemid.Image = Global.aispa.My.Resources.Resources.search_icon_hi
        Me.btn_searchmemid.Location = New System.Drawing.Point(258, 113)
        Me.btn_searchmemid.Name = "btn_searchmemid"
        Me.btn_searchmemid.Size = New System.Drawing.Size(31, 29)
        Me.btn_searchmemid.TabIndex = 6
        Me.btn_searchmemid.UseVisualStyleBackColor = True
        '
        'btn_resetinout
        '
        Me.btn_resetinout.Image = Global.aispa.My.Resources.Resources.cancle_icon
        Me.btn_resetinout.Location = New System.Drawing.Point(160, 266)
        Me.btn_resetinout.Name = "btn_resetinout"
        Me.btn_resetinout.Size = New System.Drawing.Size(88, 38)
        Me.btn_resetinout.TabIndex = 5
        Me.btn_resetinout.UseVisualStyleBackColor = True
        '
        'btn_addinout
        '
        Me.btn_addinout.Image = Global.aispa.My.Resources.Resources.save_icon
        Me.btn_addinout.Location = New System.Drawing.Point(41, 266)
        Me.btn_addinout.Name = "btn_addinout"
        Me.btn_addinout.Size = New System.Drawing.Size(88, 38)
        Me.btn_addinout.TabIndex = 4
        Me.btn_addinout.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "วันที่ เข้า - ออก"
        '
        'txt_inout
        '
        Me.txt_inout.BackColor = System.Drawing.Color.White
        Me.txt_inout.Enabled = False
        Me.txt_inout.Location = New System.Drawing.Point(114, 116)
        Me.txt_inout.Name = "txt_inout"
        Me.txt_inout.Size = New System.Drawing.Size(147, 26)
        Me.txt_inout.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "รหัสพนักงาน"
        '
        'lbl_showcurrentdate
        '
        Me.lbl_showcurrentdate.AutoSize = True
        Me.lbl_showcurrentdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_showcurrentdate.Location = New System.Drawing.Point(34, 41)
        Me.lbl_showcurrentdate.Name = "lbl_showcurrentdate"
        Me.lbl_showcurrentdate.Size = New System.Drawing.Size(0, 20)
        Me.lbl_showcurrentdate.TabIndex = 1
        '
        'grid_showinout
        '
        Me.grid_showinout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_showinout.Location = New System.Drawing.Point(34, 83)
        Me.grid_showinout.Name = "grid_showinout"
        Me.grid_showinout.Size = New System.Drawing.Size(558, 190)
        Me.grid_showinout.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(980, 579)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ตรวจสอบการเข้า - ออกงาน"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblend)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblstart)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpend)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpstart)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txt_ename)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbl_ename)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cbo_searchinout)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbl_pos)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cbo_searchby)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btn_searchmemid2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btn_searchinout)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtp_searchinout)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbl_date)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txt_searchinout)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbl_empid)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Panel2.Controls.Add(Me.grid_searchinout)
        Me.SplitContainer2.Size = New System.Drawing.Size(974, 573)
        Me.SplitContainer2.SplitterDistance = 322
        Me.SplitContainer2.TabIndex = 0
        '
        'lblend
        '
        Me.lblend.AutoSize = True
        Me.lblend.Location = New System.Drawing.Point(19, 151)
        Me.lblend.Name = "lblend"
        Me.lblend.Size = New System.Drawing.Size(69, 20)
        Me.lblend.TabIndex = 23
        Me.lblend.Text = "วันที่สิ้นสุด"
        '
        'lblstart
        '
        Me.lblstart.AutoSize = True
        Me.lblstart.Location = New System.Drawing.Point(19, 109)
        Me.lblstart.Name = "lblstart"
        Me.lblstart.Size = New System.Drawing.Size(76, 20)
        Me.lblstart.TabIndex = 22
        Me.lblstart.Text = "วันที่เริ่มต้น"
        '
        'dtpend
        '
        Me.dtpend.Location = New System.Drawing.Point(101, 146)
        Me.dtpend.Name = "dtpend"
        Me.dtpend.Size = New System.Drawing.Size(152, 26)
        Me.dtpend.TabIndex = 21
        '
        'dtpstart
        '
        Me.dtpstart.Location = New System.Drawing.Point(101, 104)
        Me.dtpstart.Name = "dtpstart"
        Me.dtpstart.Size = New System.Drawing.Size(152, 26)
        Me.dtpstart.TabIndex = 20
        '
        'txt_ename
        '
        Me.txt_ename.Location = New System.Drawing.Point(101, 146)
        Me.txt_ename.Name = "txt_ename"
        Me.txt_ename.Size = New System.Drawing.Size(147, 26)
        Me.txt_ename.TabIndex = 19
        '
        'lbl_ename
        '
        Me.lbl_ename.AutoSize = True
        Me.lbl_ename.Location = New System.Drawing.Point(11, 149)
        Me.lbl_ename.Name = "lbl_ename"
        Me.lbl_ename.Size = New System.Drawing.Size(77, 20)
        Me.lbl_ename.TabIndex = 18
        Me.lbl_ename.Text = "ชื่อพนักงาน"
        '
        'cbo_searchinout
        '
        Me.cbo_searchinout.FormattingEnabled = True
        Me.cbo_searchinout.Location = New System.Drawing.Point(101, 103)
        Me.cbo_searchinout.Name = "cbo_searchinout"
        Me.cbo_searchinout.Size = New System.Drawing.Size(147, 28)
        Me.cbo_searchinout.TabIndex = 17
        Me.cbo_searchinout.Visible = False
        '
        'lbl_pos
        '
        Me.lbl_pos.AutoSize = True
        Me.lbl_pos.Location = New System.Drawing.Point(11, 106)
        Me.lbl_pos.Name = "lbl_pos"
        Me.lbl_pos.Size = New System.Drawing.Size(59, 20)
        Me.lbl_pos.TabIndex = 16
        Me.lbl_pos.Text = "ตำแหน่ง"
        Me.lbl_pos.Visible = False
        '
        'cbo_searchby
        '
        Me.cbo_searchby.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbo_searchby.FormattingEnabled = True
        Me.cbo_searchby.Items.AddRange(New Object() {"วันที่เข้างาน", "รหัส/ชื่อพนักงาน", "ตำแหน่งพนักงาน", "ช่วงเวลาที่เข้างาน"})
        Me.cbo_searchby.Location = New System.Drawing.Point(101, 67)
        Me.cbo_searchby.Name = "cbo_searchby"
        Me.cbo_searchby.Size = New System.Drawing.Size(173, 28)
        Me.cbo_searchby.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "ค้นหาจาก"
        '
        'btn_searchmemid2
        '
        Me.btn_searchmemid2.Image = Global.aispa.My.Resources.Resources.search_icon_hi
        Me.btn_searchmemid2.Location = New System.Drawing.Point(250, 104)
        Me.btn_searchmemid2.Name = "btn_searchmemid2"
        Me.btn_searchmemid2.Size = New System.Drawing.Size(31, 27)
        Me.btn_searchmemid2.TabIndex = 13
        Me.btn_searchmemid2.UseVisualStyleBackColor = True
        Me.btn_searchmemid2.Visible = False
        '
        'btn_searchinout
        '
        Me.btn_searchinout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_searchinout.Image = Global.aispa.My.Resources.Resources.search_icon
        Me.btn_searchinout.Location = New System.Drawing.Point(52, 195)
        Me.btn_searchinout.Name = "btn_searchinout"
        Me.btn_searchinout.Size = New System.Drawing.Size(81, 38)
        Me.btn_searchinout.TabIndex = 11
        Me.btn_searchinout.UseVisualStyleBackColor = True
        '
        'dtp_searchinout
        '
        Me.dtp_searchinout.CustomFormat = ""
        Me.dtp_searchinout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dtp_searchinout.Location = New System.Drawing.Point(101, 102)
        Me.dtp_searchinout.Name = "dtp_searchinout"
        Me.dtp_searchinout.Size = New System.Drawing.Size(175, 26)
        Me.dtp_searchinout.TabIndex = 10
        Me.dtp_searchinout.Value = New Date(2013, 9, 15, 0, 0, 0, 0)
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_date.Location = New System.Drawing.Point(7, 107)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(69, 20)
        Me.lbl_date.TabIndex = 9
        Me.lbl_date.Text = "วันที่ค้นหา"
        '
        'txt_searchinout
        '
        Me.txt_searchinout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_searchinout.Location = New System.Drawing.Point(101, 104)
        Me.txt_searchinout.Name = "txt_searchinout"
        Me.txt_searchinout.Size = New System.Drawing.Size(147, 26)
        Me.txt_searchinout.TabIndex = 8
        Me.txt_searchinout.Visible = False
        '
        'lbl_empid
        '
        Me.lbl_empid.AutoSize = True
        Me.lbl_empid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_empid.Location = New System.Drawing.Point(7, 106)
        Me.lbl_empid.Name = "lbl_empid"
        Me.lbl_empid.Size = New System.Drawing.Size(84, 20)
        Me.lbl_empid.TabIndex = 7
        Me.lbl_empid.Text = "รหัสพนักงาน"
        Me.lbl_empid.Visible = False
        '
        'grid_searchinout
        '
        Me.grid_searchinout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_searchinout.Location = New System.Drawing.Point(42, 55)
        Me.grid_searchinout.Name = "grid_searchinout"
        Me.grid_searchinout.Size = New System.Drawing.Size(600, 502)
        Me.grid_searchinout.TabIndex = 0
        '
        'autoUpdate
        '
        Me.autoUpdate.Interval = 1000
        '
        'form_in_out
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 612)
        Me.Controls.Add(Me.tab_management)
        Me.Name = "form_in_out"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "form_in_out"
        Me.tab_management.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grid_showinout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.grid_searchinout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tab_management As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btn_resetinout As System.Windows.Forms.Button
    Friend WithEvents btn_addinout As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_inout As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grid_showinout As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btn_searchmemid As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btn_searchmemid2 As System.Windows.Forms.Button
    Friend WithEvents btn_searchinout As System.Windows.Forms.Button
    Friend WithEvents dtp_searchinout As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents txt_searchinout As System.Windows.Forms.TextBox
    Friend WithEvents lbl_empid As System.Windows.Forms.Label
    Friend WithEvents grid_searchinout As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_showcurrentdate As System.Windows.Forms.Label
    Friend WithEvents cbo_searchby As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_empname As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_showdate As System.Windows.Forms.TextBox
    Friend WithEvents autoUpdate As System.Windows.Forms.Timer
    Friend WithEvents cbo_inoutpos As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_searchinout As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_pos As System.Windows.Forms.Label
    Friend WithEvents txt_ename As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ename As System.Windows.Forms.Label
    Friend WithEvents lblend As System.Windows.Forms.Label
    Friend WithEvents lblstart As System.Windows.Forms.Label
    Friend WithEvents dtpend As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpstart As System.Windows.Forms.DateTimePicker
End Class
