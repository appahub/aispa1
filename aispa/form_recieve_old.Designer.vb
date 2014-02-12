<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_recieve_old
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
        Me.grid_showrev_suc = New System.Windows.Forms.DataGridView()
        Me.cbo_supplier1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grid_showrev_unsuc = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_addrecieve = New System.Windows.Forms.Button()
        Me.btn_delrecieve = New System.Windows.Forms.Button()
        Me.btn_resetmemberrecieve = New System.Windows.Forms.Button()
        Me.grid_managerecieve1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.cbo_searchby = New System.Windows.Forms.ComboBox()
        Me.ค้นหาจาก = New System.Windows.Forms.Label()
        Me.btn_searchreceive = New System.Windows.Forms.Button()
        Me.dtp_receivedate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_receivedate = New System.Windows.Forms.Label()
        Me.cbo_supplier2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.grid_revsearch = New System.Windows.Forms.DataGridView()
        Me.lbl_supplier2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grid_managerecieve2 = New System.Windows.Forms.DataGridView()
        Me.tab_management.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grid_showrev_suc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grid_showrev_unsuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_managerecieve1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grid_revsearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_managerecieve2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tab_management
        '
        Me.tab_management.Controls.Add(Me.TabPage1)
        Me.tab_management.Controls.Add(Me.TabPage2)
        Me.tab_management.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.tab_management.Location = New System.Drawing.Point(1, -1)
        Me.tab_management.Name = "tab_management"
        Me.tab_management.SelectedIndex = 0
        Me.tab_management.Size = New System.Drawing.Size(1000, 650)
        Me.tab_management.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(992, 617)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "จัดการการรับผลิตภัณฑ์"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbo_supplier1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_addrecieve)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_delrecieve)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_resetmemberrecieve)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grid_managerecieve1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Size = New System.Drawing.Size(986, 611)
        Me.SplitContainer1.SplitterDistance = 348
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grid_showrev_suc)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 303)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(315, 194)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "รายการที่รับผลิตภัณฑ์เรียบร้อยแล้ว"
        '
        'grid_showrev_suc
        '
        Me.grid_showrev_suc.AllowUserToAddRows = False
        Me.grid_showrev_suc.AllowUserToDeleteRows = False
        Me.grid_showrev_suc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grid_showrev_suc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_showrev_suc.Location = New System.Drawing.Point(6, 25)
        Me.grid_showrev_suc.Name = "grid_showrev_suc"
        Me.grid_showrev_suc.ReadOnly = True
        Me.grid_showrev_suc.Size = New System.Drawing.Size(302, 150)
        Me.grid_showrev_suc.TabIndex = 1
        '
        'cbo_supplier1
        '
        Me.cbo_supplier1.FormattingEnabled = True
        Me.cbo_supplier1.Location = New System.Drawing.Point(137, 36)
        Me.cbo_supplier1.Name = "cbo_supplier1"
        Me.cbo_supplier1.Size = New System.Drawing.Size(194, 28)
        Me.cbo_supplier1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grid_showrev_unsuc)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 194)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "รายการการรับผลิตภัณฑ์ที่ยังไม่ครบ"
        '
        'grid_showrev_unsuc
        '
        Me.grid_showrev_unsuc.AllowUserToAddRows = False
        Me.grid_showrev_unsuc.AllowUserToDeleteRows = False
        Me.grid_showrev_unsuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grid_showrev_unsuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_showrev_unsuc.Location = New System.Drawing.Point(7, 26)
        Me.grid_showrev_unsuc.Name = "grid_showrev_unsuc"
        Me.grid_showrev_unsuc.ReadOnly = True
        Me.grid_showrev_unsuc.Size = New System.Drawing.Size(302, 150)
        Me.grid_showrev_unsuc.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ตัวแทนจัดจำหน่าย"
        '
        'btn_addrecieve
        '
        Me.btn_addrecieve.Location = New System.Drawing.Point(181, 514)
        Me.btn_addrecieve.Name = "btn_addrecieve"
        Me.btn_addrecieve.Size = New System.Drawing.Size(86, 40)
        Me.btn_addrecieve.TabIndex = 97
        Me.btn_addrecieve.Text = "บักทึก"
        Me.btn_addrecieve.UseVisualStyleBackColor = True
        '
        'btn_delrecieve
        '
        Me.btn_delrecieve.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_delrecieve.Image = Global.aispa.My.Resources.Resources.delete_icon
        Me.btn_delrecieve.Location = New System.Drawing.Point(293, 514)
        Me.btn_delrecieve.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_delrecieve.Name = "btn_delrecieve"
        Me.btn_delrecieve.Size = New System.Drawing.Size(79, 40)
        Me.btn_delrecieve.TabIndex = 96
        Me.btn_delrecieve.UseVisualStyleBackColor = True
        Me.btn_delrecieve.Visible = False
        '
        'btn_resetmemberrecieve
        '
        Me.btn_resetmemberrecieve.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_resetmemberrecieve.Image = Global.aispa.My.Resources.Resources.cancle_icon
        Me.btn_resetmemberrecieve.Location = New System.Drawing.Point(388, 514)
        Me.btn_resetmemberrecieve.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_resetmemberrecieve.Name = "btn_resetmemberrecieve"
        Me.btn_resetmemberrecieve.Size = New System.Drawing.Size(79, 40)
        Me.btn_resetmemberrecieve.TabIndex = 94
        Me.btn_resetmemberrecieve.UseVisualStyleBackColor = True
        '
        'grid_managerecieve1
        '
        Me.grid_managerecieve1.AllowUserToAddRows = False
        Me.grid_managerecieve1.AllowUserToDeleteRows = False
        Me.grid_managerecieve1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_managerecieve1.Location = New System.Drawing.Point(42, 79)
        Me.grid_managerecieve1.Name = "grid_managerecieve1"
        Me.grid_managerecieve1.Size = New System.Drawing.Size(589, 418)
        Me.grid_managerecieve1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "รายการผลิตภัณฑ์"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(992, 617)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ค้นหารายการรับผลิตภัณฑ์"
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.cbo_searchby)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ค้นหาจาก)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btn_searchreceive)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtp_receivedate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbl_receivedate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cbo_supplier2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbl_supplier2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.grid_managerecieve2)
        Me.SplitContainer2.Size = New System.Drawing.Size(986, 611)
        Me.SplitContainer2.SplitterDistance = 348
        Me.SplitContainer2.TabIndex = 1
        '
        'cbo_searchby
        '
        Me.cbo_searchby.FormattingEnabled = True
        Me.cbo_searchby.Items.AddRange(New Object() {"ทั้งหมด", "ตัวแทนจำหน่าย", "วันที่รับผลิตภัณฑ์"})
        Me.cbo_searchby.Location = New System.Drawing.Point(137, 41)
        Me.cbo_searchby.Name = "cbo_searchby"
        Me.cbo_searchby.Size = New System.Drawing.Size(194, 28)
        Me.cbo_searchby.TabIndex = 106
        '
        'ค้นหาจาก
        '
        Me.ค้นหาจาก.AutoSize = True
        Me.ค้นหาจาก.Location = New System.Drawing.Point(64, 44)
        Me.ค้นหาจาก.Name = "ค้นหาจาก"
        Me.ค้นหาจาก.Size = New System.Drawing.Size(67, 20)
        Me.ค้นหาจาก.TabIndex = 105
        Me.ค้นหาจาก.Text = "ค้นหาโดย"
        '
        'btn_searchreceive
        '
        Me.btn_searchreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_searchreceive.Image = Global.aispa.My.Resources.Resources.search_icon
        Me.btn_searchreceive.Location = New System.Drawing.Point(137, 147)
        Me.btn_searchreceive.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_searchreceive.Name = "btn_searchreceive"
        Me.btn_searchreceive.Size = New System.Drawing.Size(86, 41)
        Me.btn_searchreceive.TabIndex = 104
        Me.btn_searchreceive.UseVisualStyleBackColor = True
        '
        'dtp_receivedate
        '
        Me.dtp_receivedate.Location = New System.Drawing.Point(137, 86)
        Me.dtp_receivedate.Name = "dtp_receivedate"
        Me.dtp_receivedate.Size = New System.Drawing.Size(200, 26)
        Me.dtp_receivedate.TabIndex = 4
        Me.dtp_receivedate.Visible = False
        '
        'lbl_receivedate
        '
        Me.lbl_receivedate.AutoSize = True
        Me.lbl_receivedate.Location = New System.Drawing.Point(34, 91)
        Me.lbl_receivedate.Name = "lbl_receivedate"
        Me.lbl_receivedate.Size = New System.Drawing.Size(97, 20)
        Me.lbl_receivedate.TabIndex = 3
        Me.lbl_receivedate.Text = "วันที่ทำรายการ"
        Me.lbl_receivedate.Visible = False
        '
        'cbo_supplier2
        '
        Me.cbo_supplier2.FormattingEnabled = True
        Me.cbo_supplier2.Location = New System.Drawing.Point(142, 86)
        Me.cbo_supplier2.Name = "cbo_supplier2"
        Me.cbo_supplier2.Size = New System.Drawing.Size(194, 28)
        Me.cbo_supplier2.TabIndex = 2
        Me.cbo_supplier2.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.grid_revsearch)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 193)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(315, 378)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "รายการรับผลิตภัณฑ์"
        '
        'grid_revsearch
        '
        Me.grid_revsearch.AllowUserToAddRows = False
        Me.grid_revsearch.AllowUserToDeleteRows = False
        Me.grid_revsearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grid_revsearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_revsearch.Location = New System.Drawing.Point(6, 22)
        Me.grid_revsearch.Name = "grid_revsearch"
        Me.grid_revsearch.ReadOnly = True
        Me.grid_revsearch.Size = New System.Drawing.Size(302, 350)
        Me.grid_revsearch.TabIndex = 2
        '
        'lbl_supplier2
        '
        Me.lbl_supplier2.AutoSize = True
        Me.lbl_supplier2.Location = New System.Drawing.Point(18, 89)
        Me.lbl_supplier2.Name = "lbl_supplier2"
        Me.lbl_supplier2.Size = New System.Drawing.Size(118, 20)
        Me.lbl_supplier2.TabIndex = 0
        Me.lbl_supplier2.Text = "ตัวแทนจัดจำหน่าย"
        Me.lbl_supplier2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 25)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "รายการผลิตภัณฑ์"
        '
        'grid_managerecieve2
        '
        Me.grid_managerecieve2.AllowUserToAddRows = False
        Me.grid_managerecieve2.AllowUserToDeleteRows = False
        Me.grid_managerecieve2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_managerecieve2.Location = New System.Drawing.Point(42, 55)
        Me.grid_managerecieve2.Name = "grid_managerecieve2"
        Me.grid_managerecieve2.ReadOnly = True
        Me.grid_managerecieve2.Size = New System.Drawing.Size(593, 419)
        Me.grid_managerecieve2.TabIndex = 1
        '
        'form_recieve_old
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 662)
        Me.Controls.Add(Me.tab_management)
        Me.Name = "form_recieve_old"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "form_recieve"
        Me.tab_management.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grid_showrev_suc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grid_showrev_unsuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_managerecieve1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grid_revsearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_managerecieve2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tab_management As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_supplier1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents cbo_supplier2 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_supplier2 As System.Windows.Forms.Label
    Friend WithEvents grid_managerecieve2 As System.Windows.Forms.DataGridView
    Friend WithEvents grid_showrev_suc As System.Windows.Forms.DataGridView
    Friend WithEvents grid_showrev_unsuc As System.Windows.Forms.DataGridView
    Friend WithEvents grid_managerecieve1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_delrecieve As System.Windows.Forms.Button
    Friend WithEvents btn_resetmemberrecieve As System.Windows.Forms.Button
    Friend WithEvents btn_addrecieve As System.Windows.Forms.Button
    Friend WithEvents dtp_receivedate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_receivedate As System.Windows.Forms.Label
    Friend WithEvents grid_revsearch As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_searchreceive As System.Windows.Forms.Button
    Friend WithEvents cbo_searchby As System.Windows.Forms.ComboBox
    Friend WithEvents ค้นหาจาก As System.Windows.Forms.Label
End Class
