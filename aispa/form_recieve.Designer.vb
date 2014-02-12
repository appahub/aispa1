<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_recieve
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grid_showrev_unsuc = New System.Windows.Forms.DataGridView()
        Me.btn_delreceive = New System.Windows.Forms.Button()
        Me.btn_editreceive = New System.Windows.Forms.Button()
        Me.btn_resetreceive = New System.Windows.Forms.Button()
        Me.btn_addreceive = New System.Windows.Forms.Button()
        Me.dtp_receivedate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_receiveid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_searchreceive = New System.Windows.Forms.ComboBox()
        Me.btn_searchreceive = New System.Windows.Forms.Button()
        Me.txt_searchreceive = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grid_receiveresult = New System.Windows.Forms.DataGridView()
        Me.grid_showreceiveprod = New System.Windows.Forms.DataGridView()
        Me.del = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.runno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prod_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prod_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prod_qty2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prod_qty3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sumtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.capacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.detail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_receivereport = New System.Windows.Forms.Button()
        Me.btn_delproductreceive = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grid_showrev_unsuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_receiveresult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_showreceiveprod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_delreceive)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_editreceive)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_resetreceive)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_addreceive)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtp_receivedate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txt_receiveid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cbo_searchreceive)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_searchreceive)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txt_searchreceive)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grid_receiveresult)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 381)
        Me.SplitContainer1.SplitterDistance = 452
        Me.SplitContainer1.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grid_showrev_unsuc)
        Me.GroupBox1.Location = New System.Drawing.Point(69, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 194)
        Me.GroupBox1.TabIndex = 97
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "รายการสั่งซื้อที่ยังรับไม่ครบ"
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
        Me.grid_showrev_unsuc.Size = New System.Drawing.Size(302, 162)
        Me.grid_showrev_unsuc.TabIndex = 0
        '
        'btn_delreceive
        '
        Me.btn_delreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_delreceive.Image = Global.aispa.My.Resources.Resources.delete_icon
        Me.btn_delreceive.Location = New System.Drawing.Point(178, 315)
        Me.btn_delreceive.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_delreceive.Name = "btn_delreceive"
        Me.btn_delreceive.Size = New System.Drawing.Size(79, 40)
        Me.btn_delreceive.TabIndex = 96
        Me.btn_delreceive.UseVisualStyleBackColor = True
        Me.btn_delreceive.Visible = False
        '
        'btn_editreceive
        '
        Me.btn_editreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_editreceive.Image = Global.aispa.My.Resources.Resources.edit_icon
        Me.btn_editreceive.Location = New System.Drawing.Point(87, 315)
        Me.btn_editreceive.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_editreceive.Name = "btn_editreceive"
        Me.btn_editreceive.Size = New System.Drawing.Size(79, 40)
        Me.btn_editreceive.TabIndex = 95
        Me.btn_editreceive.UseVisualStyleBackColor = True
        Me.btn_editreceive.Visible = False
        '
        'btn_resetreceive
        '
        Me.btn_resetreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_resetreceive.Image = Global.aispa.My.Resources.Resources.cancle_icon
        Me.btn_resetreceive.Location = New System.Drawing.Point(273, 315)
        Me.btn_resetreceive.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_resetreceive.Name = "btn_resetreceive"
        Me.btn_resetreceive.Size = New System.Drawing.Size(83, 40)
        Me.btn_resetreceive.TabIndex = 94
        Me.btn_resetreceive.UseVisualStyleBackColor = True
        '
        'btn_addreceive
        '
        Me.btn_addreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_addreceive.Image = Global.aispa.My.Resources.Resources.add_icon
        Me.btn_addreceive.Location = New System.Drawing.Point(113, 315)
        Me.btn_addreceive.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_addreceive.Name = "btn_addreceive"
        Me.btn_addreceive.Size = New System.Drawing.Size(79, 40)
        Me.btn_addreceive.TabIndex = 93
        Me.btn_addreceive.UseVisualStyleBackColor = True
        '
        'dtp_receivedate
        '
        Me.dtp_receivedate.Enabled = False
        Me.dtp_receivedate.Location = New System.Drawing.Point(173, 62)
        Me.dtp_receivedate.Name = "dtp_receivedate"
        Me.dtp_receivedate.Size = New System.Drawing.Size(200, 26)
        Me.dtp_receivedate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(113, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "วันที่รับ"
        '
        'txt_receiveid
        '
        Me.txt_receiveid.Enabled = False
        Me.txt_receiveid.Location = New System.Drawing.Point(173, 21)
        Me.txt_receiveid.Name = "txt_receiveid"
        Me.txt_receiveid.Size = New System.Drawing.Size(167, 26)
        Me.txt_receiveid.TabIndex = 1
        Me.txt_receiveid.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(92, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "รหัสการรับ"
        Me.Label1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 25)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "รายการรับผลิตภัณฑ์"
        '
        'cbo_searchreceive
        '
        Me.cbo_searchreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbo_searchreceive.FormattingEnabled = True
        Me.cbo_searchreceive.Items.AddRange(New Object() {"ทั้งหมด", "วันที่รับ(dd/mm/yyyy)", "พนักงานที่รับ"})
        Me.cbo_searchreceive.Location = New System.Drawing.Point(63, 51)
        Me.cbo_searchreceive.Margin = New System.Windows.Forms.Padding(2)
        Me.cbo_searchreceive.Name = "cbo_searchreceive"
        Me.cbo_searchreceive.Size = New System.Drawing.Size(202, 28)
        Me.cbo_searchreceive.TabIndex = 101
        '
        'btn_searchreceive
        '
        Me.btn_searchreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_searchreceive.Image = Global.aispa.My.Resources.Resources.search_icon
        Me.btn_searchreceive.Location = New System.Drawing.Point(459, 42)
        Me.btn_searchreceive.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_searchreceive.Name = "btn_searchreceive"
        Me.btn_searchreceive.Size = New System.Drawing.Size(86, 41)
        Me.btn_searchreceive.TabIndex = 103
        Me.btn_searchreceive.UseVisualStyleBackColor = True
        '
        'txt_searchreceive
        '
        Me.txt_searchreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_searchreceive.Location = New System.Drawing.Point(269, 51)
        Me.txt_searchreceive.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_searchreceive.Name = "txt_searchreceive"
        Me.txt_searchreceive.Size = New System.Drawing.Size(175, 26)
        Me.txt_searchreceive.TabIndex = 102
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(-2, 54)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 20)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "ค้นหาจาก"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grid_receiveresult
        '
        Me.grid_receiveresult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_receiveresult.Location = New System.Drawing.Point(51, 120)
        Me.grid_receiveresult.Name = "grid_receiveresult"
        Me.grid_receiveresult.Size = New System.Drawing.Size(489, 229)
        Me.grid_receiveresult.TabIndex = 97
        '
        'grid_showreceiveprod
        '
        Me.grid_showreceiveprod.AllowUserToAddRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grid_showreceiveprod.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_showreceiveprod.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grid_showreceiveprod.ColumnHeadersHeight = 45
        Me.grid_showreceiveprod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grid_showreceiveprod.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.del, Me.runno, Me.prod_name, Me.prod_qty, Me.prod_qty2, Me.prod_qty3, Me.unit, Me.price, Me.sumtotal, Me.brand, Me.capacity, Me.prodid, Me.detail, Me.unit2, Me.prodtype})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid_showreceiveprod.DefaultCellStyle = DataGridViewCellStyle3
        Me.grid_showreceiveprod.Location = New System.Drawing.Point(23, 85)
        Me.grid_showreceiveprod.Name = "grid_showreceiveprod"
        Me.grid_showreceiveprod.Size = New System.Drawing.Size(812, 178)
        Me.grid_showreceiveprod.TabIndex = 98
        '
        'del
        '
        Me.del.HeaderText = "ลบ"
        Me.del.Name = "del"
        Me.del.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.del.Width = 50
        '
        'runno
        '
        Me.runno.HeaderText = "ลำดับ"
        Me.runno.Name = "runno"
        Me.runno.ReadOnly = True
        Me.runno.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.runno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.runno.Width = 50
        '
        'prod_name
        '
        Me.prod_name.HeaderText = "ชื่อผลิตภัณฑ์"
        Me.prod_name.Name = "prod_name"
        Me.prod_name.ReadOnly = True
        Me.prod_name.Width = 150
        '
        'prod_qty
        '
        Me.prod_qty.HeaderText = "จำนวนที่รับ"
        Me.prod_qty.Name = "prod_qty"
        Me.prod_qty.Width = 55
        '
        'prod_qty2
        '
        Me.prod_qty2.HeaderText = "จำนวนที่สั่ง"
        Me.prod_qty2.Name = "prod_qty2"
        Me.prod_qty2.ReadOnly = True
        Me.prod_qty2.Width = 55
        '
        'prod_qty3
        '
        Me.prod_qty3.HeaderText = "จำนวนค้างรับ"
        Me.prod_qty3.Name = "prod_qty3"
        Me.prod_qty3.ReadOnly = True
        Me.prod_qty3.Width = 55
        '
        'unit
        '
        Me.unit.HeaderText = "หน่วยนับผลิตภัณฑ์"
        Me.unit.Name = "unit"
        Me.unit.ReadOnly = True
        Me.unit.Width = 80
        '
        'price
        '
        Me.price.HeaderText = "ราคา/หน่วย"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'sumtotal
        '
        Me.sumtotal.HeaderText = "ราคารวม"
        Me.sumtotal.Name = "sumtotal"
        Me.sumtotal.ReadOnly = True
        '
        'brand
        '
        Me.brand.HeaderText = "ยี่ห้อ"
        Me.brand.Name = "brand"
        Me.brand.ReadOnly = True
        '
        'capacity
        '
        Me.capacity.HeaderText = "ปริมาตร"
        Me.capacity.Name = "capacity"
        Me.capacity.ReadOnly = True
        '
        'prodid
        '
        Me.prodid.HeaderText = "รหัสสินค้า"
        Me.prodid.Name = "prodid"
        Me.prodid.ReadOnly = True
        Me.prodid.Visible = False
        '
        'detail
        '
        Me.detail.HeaderText = "รหัสรายละเอียด"
        Me.detail.Name = "detail"
        Me.detail.ReadOnly = True
        Me.detail.Visible = False
        '
        'unit2
        '
        Me.unit2.HeaderText = "หน่วยนับปริมาตร"
        Me.unit2.Name = "unit2"
        Me.unit2.ReadOnly = True
        '
        'prodtype
        '
        Me.prodtype.HeaderText = "ประเภทสินค้า"
        Me.prodtype.Name = "prodtype"
        Me.prodtype.ReadOnly = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(175, 25)
        Me.Label7.TabIndex = 105
        Me.Label7.Text = "รายละเอียดการเบิก"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btn_receivereport)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btn_delproductreceive)
        Me.Panel1.Controls.Add(Me.grid_showreceiveprod)
        Me.Panel1.Location = New System.Drawing.Point(0, 387)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 275)
        Me.Panel1.TabIndex = 5
        '
        'btn_receivereport
        '
        Me.btn_receivereport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_receivereport.Image = Global.aispa.My.Resources.Resources.print_icon
        Me.btn_receivereport.Location = New System.Drawing.Point(841, 222)
        Me.btn_receivereport.Name = "btn_receivereport"
        Me.btn_receivereport.Size = New System.Drawing.Size(137, 41)
        Me.btn_receivereport.TabIndex = 106
        Me.btn_receivereport.UseVisualStyleBackColor = True
        Me.btn_receivereport.Visible = False
        '
        'btn_delproductreceive
        '
        Me.btn_delproductreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_delproductreceive.Image = Global.aispa.My.Resources.Resources.all_icon
        Me.btn_delproductreceive.Location = New System.Drawing.Point(23, 38)
        Me.btn_delproductreceive.Name = "btn_delproductreceive"
        Me.btn_delproductreceive.Size = New System.Drawing.Size(137, 41)
        Me.btn_delproductreceive.TabIndex = 99
        Me.btn_delproductreceive.UseVisualStyleBackColor = True
        '
        'form_recieve
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 662)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "form_recieve"
        Me.Text = "form_recieve"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grid_showrev_unsuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_receiveresult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_showreceiveprod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_delproductreceive As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btn_delreceive As System.Windows.Forms.Button
    Friend WithEvents btn_editreceive As System.Windows.Forms.Button
    Friend WithEvents btn_resetreceive As System.Windows.Forms.Button
    Friend WithEvents btn_addreceive As System.Windows.Forms.Button
    Friend WithEvents dtp_receivedate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_receiveid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_searchreceive As System.Windows.Forms.ComboBox
    Friend WithEvents btn_searchreceive As System.Windows.Forms.Button
    Friend WithEvents txt_searchreceive As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grid_receiveresult As System.Windows.Forms.DataGridView
    Friend WithEvents grid_showreceiveprod As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_receivereport As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grid_showrev_unsuc As System.Windows.Forms.DataGridView
    Friend WithEvents del As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents runno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prod_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prod_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prod_qty2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prod_qty3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sumtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents capacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents detail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unit2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodtype As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
