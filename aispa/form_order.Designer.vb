<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_order
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
        Me.cbo_orderproducttype = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_delorder = New System.Windows.Forms.Button()
        Me.btn_editorder = New System.Windows.Forms.Button()
        Me.btn_resetorder = New System.Windows.Forms.Button()
        Me.btn_addorder = New System.Windows.Forms.Button()
        Me.btn_searchproduct = New System.Windows.Forms.Button()
        Me.txt_orderprod = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_ordersupplier = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_orderdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_orderid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_searchorder = New System.Windows.Forms.ComboBox()
        Me.btn_searchorder = New System.Windows.Forms.Button()
        Me.txt_searchorder = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grid_orderresult = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_orderreport = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_delproduct = New System.Windows.Forms.Button()
        Me.grid_showorderprod = New System.Windows.Forms.DataGridView()
        Me.del = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.runno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prod_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prod_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.capacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.detail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grid_orderresult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grid_showorderprod, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbo_orderproducttype)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_delorder)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_editorder)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_resetorder)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_addorder)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_searchproduct)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txt_orderprod)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbo_ordersupplier)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtp_orderdate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txt_orderid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cbo_searchorder)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_searchorder)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txt_searchorder)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grid_orderresult)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 381)
        Me.SplitContainer1.SplitterDistance = 452
        Me.SplitContainer1.TabIndex = 0
        '
        'cbo_orderproducttype
        '
        Me.cbo_orderproducttype.FormattingEnabled = True
        Me.cbo_orderproducttype.Location = New System.Drawing.Point(130, 171)
        Me.cbo_orderproducttype.Name = "cbo_orderproducttype"
        Me.cbo_orderproducttype.Size = New System.Drawing.Size(200, 28)
        Me.cbo_orderproducttype.TabIndex = 99
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 20)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "ประเภทสินค้า"
        '
        'btn_delorder
        '
        Me.btn_delorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_delorder.Image = Global.aispa.My.Resources.Resources.delete_icon
        Me.btn_delorder.Location = New System.Drawing.Point(172, 278)
        Me.btn_delorder.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_delorder.Name = "btn_delorder"
        Me.btn_delorder.Size = New System.Drawing.Size(79, 40)
        Me.btn_delorder.TabIndex = 96
        Me.btn_delorder.UseVisualStyleBackColor = True
        Me.btn_delorder.Visible = False
        '
        'btn_editorder
        '
        Me.btn_editorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_editorder.Image = Global.aispa.My.Resources.Resources.edit_icon
        Me.btn_editorder.Location = New System.Drawing.Point(81, 278)
        Me.btn_editorder.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_editorder.Name = "btn_editorder"
        Me.btn_editorder.Size = New System.Drawing.Size(79, 40)
        Me.btn_editorder.TabIndex = 95
        Me.btn_editorder.UseVisualStyleBackColor = True
        Me.btn_editorder.Visible = False
        '
        'btn_resetorder
        '
        Me.btn_resetorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_resetorder.Image = Global.aispa.My.Resources.Resources.cancle_icon
        Me.btn_resetorder.Location = New System.Drawing.Point(267, 278)
        Me.btn_resetorder.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_resetorder.Name = "btn_resetorder"
        Me.btn_resetorder.Size = New System.Drawing.Size(83, 40)
        Me.btn_resetorder.TabIndex = 94
        Me.btn_resetorder.UseVisualStyleBackColor = True
        '
        'btn_addorder
        '
        Me.btn_addorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_addorder.Image = Global.aispa.My.Resources.Resources.add_icon
        Me.btn_addorder.Location = New System.Drawing.Point(107, 278)
        Me.btn_addorder.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_addorder.Name = "btn_addorder"
        Me.btn_addorder.Size = New System.Drawing.Size(79, 40)
        Me.btn_addorder.TabIndex = 93
        Me.btn_addorder.UseVisualStyleBackColor = True
        '
        'btn_searchproduct
        '
        Me.btn_searchproduct.Image = Global.aispa.My.Resources.Resources.search_icon_hi
        Me.btn_searchproduct.Location = New System.Drawing.Point(297, 210)
        Me.btn_searchproduct.Name = "btn_searchproduct"
        Me.btn_searchproduct.Size = New System.Drawing.Size(31, 28)
        Me.btn_searchproduct.TabIndex = 9
        Me.btn_searchproduct.UseVisualStyleBackColor = True
        '
        'txt_orderprod
        '
        Me.txt_orderprod.Location = New System.Drawing.Point(130, 212)
        Me.txt_orderprod.Name = "txt_orderprod"
        Me.txt_orderprod.Size = New System.Drawing.Size(167, 26)
        Me.txt_orderprod.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ผลิตภัณฑ์ที่สั่งซื้อ"
        '
        'cbo_ordersupplier
        '
        Me.cbo_ordersupplier.FormattingEnabled = True
        Me.cbo_ordersupplier.Location = New System.Drawing.Point(130, 130)
        Me.cbo_ordersupplier.Name = "cbo_ordersupplier"
        Me.cbo_ordersupplier.Size = New System.Drawing.Size(200, 28)
        Me.cbo_ordersupplier.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "ชื่อบริษัท"
        '
        'dtp_orderdate
        '
        Me.dtp_orderdate.Location = New System.Drawing.Point(130, 90)
        Me.dtp_orderdate.Name = "dtp_orderdate"
        Me.dtp_orderdate.Size = New System.Drawing.Size(200, 26)
        Me.dtp_orderdate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "วันที่สั่งซื้อ"
        '
        'txt_orderid
        '
        Me.txt_orderid.Enabled = False
        Me.txt_orderid.Location = New System.Drawing.Point(130, 48)
        Me.txt_orderid.Name = "txt_orderid"
        Me.txt_orderid.Size = New System.Drawing.Size(167, 26)
        Me.txt_orderid.TabIndex = 1
        Me.txt_orderid.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "รหัสการสั่งซื้อ"
        Me.Label1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 25)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "รายการสั่งซื้อ"
        '
        'cbo_searchorder
        '
        Me.cbo_searchorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbo_searchorder.FormattingEnabled = True
        Me.cbo_searchorder.Items.AddRange(New Object() {"ทั้งหมด", "วันที่สั่งซื้อ(dd/mm/yyyy)", "ผู้ติดต่อ", "ชื่อบริษัท"})
        Me.cbo_searchorder.Location = New System.Drawing.Point(63, 51)
        Me.cbo_searchorder.Margin = New System.Windows.Forms.Padding(2)
        Me.cbo_searchorder.Name = "cbo_searchorder"
        Me.cbo_searchorder.Size = New System.Drawing.Size(202, 28)
        Me.cbo_searchorder.TabIndex = 101
        '
        'btn_searchorder
        '
        Me.btn_searchorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_searchorder.Image = Global.aispa.My.Resources.Resources.search_icon
        Me.btn_searchorder.Location = New System.Drawing.Point(459, 42)
        Me.btn_searchorder.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_searchorder.Name = "btn_searchorder"
        Me.btn_searchorder.Size = New System.Drawing.Size(86, 41)
        Me.btn_searchorder.TabIndex = 103
        Me.btn_searchorder.UseVisualStyleBackColor = True
        '
        'txt_searchorder
        '
        Me.txt_searchorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_searchorder.Location = New System.Drawing.Point(269, 51)
        Me.txt_searchorder.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_searchorder.Name = "txt_searchorder"
        Me.txt_searchorder.Size = New System.Drawing.Size(175, 26)
        Me.txt_searchorder.TabIndex = 102
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
        'grid_orderresult
        '
        Me.grid_orderresult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_orderresult.Location = New System.Drawing.Point(51, 120)
        Me.grid_orderresult.Name = "grid_orderresult"
        Me.grid_orderresult.Size = New System.Drawing.Size(488, 229)
        Me.grid_orderresult.TabIndex = 97
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btn_orderreport)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btn_delproduct)
        Me.Panel1.Controls.Add(Me.grid_showorderprod)
        Me.Panel1.Location = New System.Drawing.Point(0, 387)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 275)
        Me.Panel1.TabIndex = 1
        '
        'btn_orderreport
        '
        Me.btn_orderreport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_orderreport.Image = Global.aispa.My.Resources.Resources.print_icon
        Me.btn_orderreport.Location = New System.Drawing.Point(841, 222)
        Me.btn_orderreport.Name = "btn_orderreport"
        Me.btn_orderreport.Size = New System.Drawing.Size(137, 41)
        Me.btn_orderreport.TabIndex = 106
        Me.btn_orderreport.UseVisualStyleBackColor = True
        Me.btn_orderreport.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(191, 25)
        Me.Label7.TabIndex = 105
        Me.Label7.Text = "รายละเอียดการสั่งซื้อ"
        '
        'btn_delproduct
        '
        Me.btn_delproduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_delproduct.Image = Global.aispa.My.Resources.Resources.all_icon
        Me.btn_delproduct.Location = New System.Drawing.Point(23, 38)
        Me.btn_delproduct.Name = "btn_delproduct"
        Me.btn_delproduct.Size = New System.Drawing.Size(137, 41)
        Me.btn_delproduct.TabIndex = 99
        Me.btn_delproduct.UseVisualStyleBackColor = True
        '
        'grid_showorderprod
        '
        Me.grid_showorderprod.AllowUserToAddRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grid_showorderprod.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_showorderprod.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grid_showorderprod.ColumnHeadersHeight = 30
        Me.grid_showorderprod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grid_showorderprod.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.del, Me.runno, Me.prod_name, Me.prod_qty, Me.unit, Me.price, Me.brand, Me.capacity, Me.prodid, Me.detail, Me.unit2, Me.prodtype})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid_showorderprod.DefaultCellStyle = DataGridViewCellStyle3
        Me.grid_showorderprod.Location = New System.Drawing.Point(23, 85)
        Me.grid_showorderprod.Name = "grid_showorderprod"
        Me.grid_showorderprod.Size = New System.Drawing.Size(812, 178)
        Me.grid_showorderprod.TabIndex = 98
        '
        'del
        '
        Me.del.HeaderText = "ลบรายการ"
        Me.del.Name = "del"
        Me.del.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.del.Width = 50
        '
        'runno
        '
        Me.runno.HeaderText = "ลำดับ"
        Me.runno.Name = "runno"
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
        Me.prod_qty.HeaderText = "จำนวน"
        Me.prod_qty.Name = "prod_qty"
        Me.prod_qty.Width = 55
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
        Me.detail.Visible = False
        '
        'unit2
        '
        Me.unit2.HeaderText = "หน่วยนับปริมาตร"
        Me.unit2.Name = "unit2"
        '
        'prodtype
        '
        Me.prodtype.HeaderText = "ประเภทสินค้า"
        Me.prodtype.Name = "prodtype"
        '
        'form_order
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 662)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "form_order"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "การสั่งซื้อ"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grid_orderresult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grid_showorderprod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cbo_ordersupplier As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_orderdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_orderid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_searchproduct As System.Windows.Forms.Button
    Friend WithEvents txt_orderprod As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_delorder As System.Windows.Forms.Button
    Friend WithEvents btn_editorder As System.Windows.Forms.Button
    Friend WithEvents btn_resetorder As System.Windows.Forms.Button
    Friend WithEvents btn_addorder As System.Windows.Forms.Button
    Friend WithEvents grid_orderresult As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_searchorder As System.Windows.Forms.ComboBox
    Friend WithEvents btn_searchorder As System.Windows.Forms.Button
    Friend WithEvents txt_searchorder As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_orderproducttype As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_delproduct As System.Windows.Forms.Button
    Friend WithEvents grid_showorderprod As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_orderreport As System.Windows.Forms.Button
    Friend WithEvents del As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents runno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prod_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prod_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents capacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents detail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unit2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodtype As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
