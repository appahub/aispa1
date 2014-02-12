<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_bring
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txt_pickempname = New System.Windows.Forms.TextBox()
        Me.btn_searchmempick = New System.Windows.Forms.Button()
        Me.txt_pickempid = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_bringproducttype = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_delbring = New System.Windows.Forms.Button()
        Me.btn_editbring = New System.Windows.Forms.Button()
        Me.btn_resetbring = New System.Windows.Forms.Button()
        Me.btn_addbring = New System.Windows.Forms.Button()
        Me.btn_searchproductbring = New System.Windows.Forms.Button()
        Me.txt_bringprod = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_bringdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_bringid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_searchbring = New System.Windows.Forms.ComboBox()
        Me.btn_searchbring = New System.Windows.Forms.Button()
        Me.txt_searchbring = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grid_bringresult = New System.Windows.Forms.DataGridView()
        Me.del = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btn_bringreport = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_delproductbring = New System.Windows.Forms.Button()
        Me.grid_showbringprod = New System.Windows.Forms.DataGridView()
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grid_bringresult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_showbringprod, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.txt_pickempname)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_searchmempick)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txt_pickempid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbo_bringproducttype)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_delbring)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_editbring)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_resetbring)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_addbring)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_searchproductbring)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txt_bringprod)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtp_bringdate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txt_bringid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cbo_searchbring)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_searchbring)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txt_searchbring)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grid_bringresult)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 381)
        Me.SplitContainer1.SplitterDistance = 452
        Me.SplitContainer1.TabIndex = 2
        '
        'txt_pickempname
        '
        Me.txt_pickempname.BackColor = System.Drawing.Color.White
        Me.txt_pickempname.Enabled = False
        Me.txt_pickempname.Location = New System.Drawing.Point(139, 204)
        Me.txt_pickempname.Name = "txt_pickempname"
        Me.txt_pickempname.Size = New System.Drawing.Size(147, 26)
        Me.txt_pickempname.TabIndex = 103
        '
        'btn_searchmempick
        '
        Me.btn_searchmempick.Image = Global.aispa.My.Resources.Resources.search_icon_hi
        Me.btn_searchmempick.Location = New System.Drawing.Point(284, 201)
        Me.btn_searchmempick.Name = "btn_searchmempick"
        Me.btn_searchmempick.Size = New System.Drawing.Size(31, 29)
        Me.btn_searchmempick.TabIndex = 102
        Me.btn_searchmempick.UseVisualStyleBackColor = True
        '
        'txt_pickempid
        '
        Me.txt_pickempid.BackColor = System.Drawing.Color.White
        Me.txt_pickempid.Enabled = False
        Me.txt_pickempid.Location = New System.Drawing.Point(140, 204)
        Me.txt_pickempid.Name = "txt_pickempid"
        Me.txt_pickempid.Size = New System.Drawing.Size(147, 26)
        Me.txt_pickempid.TabIndex = 101
        Me.txt_pickempid.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 207)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "รหัสพนักงาน"
        '
        'cbo_bringproducttype
        '
        Me.cbo_bringproducttype.FormattingEnabled = True
        Me.cbo_bringproducttype.Location = New System.Drawing.Point(139, 122)
        Me.cbo_bringproducttype.Name = "cbo_bringproducttype"
        Me.cbo_bringproducttype.Size = New System.Drawing.Size(200, 28)
        Me.cbo_bringproducttype.TabIndex = 99
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 20)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "ประเภทผลิตภัณฑ์"
        '
        'btn_delbring
        '
        Me.btn_delbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_delbring.Image = Global.aispa.My.Resources.Resources.delete_icon
        Me.btn_delbring.Location = New System.Drawing.Point(152, 275)
        Me.btn_delbring.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_delbring.Name = "btn_delbring"
        Me.btn_delbring.Size = New System.Drawing.Size(79, 40)
        Me.btn_delbring.TabIndex = 96
        Me.btn_delbring.UseVisualStyleBackColor = True
        Me.btn_delbring.Visible = False
        '
        'btn_editbring
        '
        Me.btn_editbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_editbring.Image = Global.aispa.My.Resources.Resources.edit_icon
        Me.btn_editbring.Location = New System.Drawing.Point(61, 275)
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
        Me.btn_resetbring.Location = New System.Drawing.Point(247, 275)
        Me.btn_resetbring.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_resetbring.Name = "btn_resetbring"
        Me.btn_resetbring.Size = New System.Drawing.Size(83, 40)
        Me.btn_resetbring.TabIndex = 94
        Me.btn_resetbring.UseVisualStyleBackColor = True
        '
        'btn_addbring
        '
        Me.btn_addbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_addbring.Image = Global.aispa.My.Resources.Resources.add_icon
        Me.btn_addbring.Location = New System.Drawing.Point(87, 275)
        Me.btn_addbring.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_addbring.Name = "btn_addbring"
        Me.btn_addbring.Size = New System.Drawing.Size(79, 40)
        Me.btn_addbring.TabIndex = 93
        Me.btn_addbring.UseVisualStyleBackColor = True
        '
        'btn_searchproductbring
        '
        Me.btn_searchproductbring.Image = Global.aispa.My.Resources.Resources.search_icon_hi
        Me.btn_searchproductbring.Location = New System.Drawing.Point(308, 161)
        Me.btn_searchproductbring.Name = "btn_searchproductbring"
        Me.btn_searchproductbring.Size = New System.Drawing.Size(31, 28)
        Me.btn_searchproductbring.TabIndex = 9
        Me.btn_searchproductbring.UseVisualStyleBackColor = True
        '
        'txt_bringprod
        '
        Me.txt_bringprod.Location = New System.Drawing.Point(139, 163)
        Me.txt_bringprod.Name = "txt_bringprod"
        Me.txt_bringprod.Size = New System.Drawing.Size(167, 26)
        Me.txt_bringprod.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ผลิตภัณฑ์ที่เบิก"
        '
        'dtp_bringdate
        '
        Me.dtp_bringdate.Enabled = False
        Me.dtp_bringdate.Location = New System.Drawing.Point(139, 90)
        Me.dtp_bringdate.Name = "dtp_bringdate"
        Me.dtp_bringdate.Size = New System.Drawing.Size(200, 26)
        Me.dtp_bringdate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "วันที่เบิก"
        '
        'txt_bringid
        '
        Me.txt_bringid.Enabled = False
        Me.txt_bringid.Location = New System.Drawing.Point(139, 48)
        Me.txt_bringid.Name = "txt_bringid"
        Me.txt_bringid.Size = New System.Drawing.Size(167, 26)
        Me.txt_bringid.TabIndex = 1
        Me.txt_bringid.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "รหัสการเบิก"
        Me.Label1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 25)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "รายการเบิก"
        '
        'cbo_searchbring
        '
        Me.cbo_searchbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbo_searchbring.FormattingEnabled = True
        Me.cbo_searchbring.Items.AddRange(New Object() {"ทั้งหมด", "วันที่เบิก(dd/mm/yyyy)", "พนักงานที่เบิก"})
        Me.cbo_searchbring.Location = New System.Drawing.Point(63, 51)
        Me.cbo_searchbring.Margin = New System.Windows.Forms.Padding(2)
        Me.cbo_searchbring.Name = "cbo_searchbring"
        Me.cbo_searchbring.Size = New System.Drawing.Size(202, 28)
        Me.cbo_searchbring.TabIndex = 101
        '
        'btn_searchbring
        '
        Me.btn_searchbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_searchbring.Image = Global.aispa.My.Resources.Resources.search_icon
        Me.btn_searchbring.Location = New System.Drawing.Point(459, 42)
        Me.btn_searchbring.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_searchbring.Name = "btn_searchbring"
        Me.btn_searchbring.Size = New System.Drawing.Size(86, 41)
        Me.btn_searchbring.TabIndex = 103
        Me.btn_searchbring.UseVisualStyleBackColor = True
        '
        'txt_searchbring
        '
        Me.txt_searchbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_searchbring.Location = New System.Drawing.Point(269, 51)
        Me.txt_searchbring.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_searchbring.Name = "txt_searchbring"
        Me.txt_searchbring.Size = New System.Drawing.Size(175, 26)
        Me.txt_searchbring.TabIndex = 102
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
        'grid_bringresult
        '
        Me.grid_bringresult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_bringresult.Location = New System.Drawing.Point(51, 120)
        Me.grid_bringresult.Name = "grid_bringresult"
        Me.grid_bringresult.Size = New System.Drawing.Size(444, 229)
        Me.grid_bringresult.TabIndex = 97
        '
        'del
        '
        Me.del.HeaderText = "ลบรายการ"
        Me.del.Name = "del"
        Me.del.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.del.Width = 50
        '
        'btn_bringreport
        '
        Me.btn_bringreport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_bringreport.Image = Global.aispa.My.Resources.Resources.print_icon
        Me.btn_bringreport.Location = New System.Drawing.Point(841, 222)
        Me.btn_bringreport.Name = "btn_bringreport"
        Me.btn_bringreport.Size = New System.Drawing.Size(137, 41)
        Me.btn_bringreport.TabIndex = 106
        Me.btn_bringreport.UseVisualStyleBackColor = True
        Me.btn_bringreport.Visible = False
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
        'btn_delproductbring
        '
        Me.btn_delproductbring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_delproductbring.Image = Global.aispa.My.Resources.Resources.all_icon
        Me.btn_delproductbring.Location = New System.Drawing.Point(23, 38)
        Me.btn_delproductbring.Name = "btn_delproductbring"
        Me.btn_delproductbring.Size = New System.Drawing.Size(137, 41)
        Me.btn_delproductbring.TabIndex = 99
        Me.btn_delproductbring.UseVisualStyleBackColor = True
        '
        'grid_showbringprod
        '
        Me.grid_showbringprod.AllowUserToAddRows = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grid_showbringprod.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_showbringprod.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grid_showbringprod.ColumnHeadersHeight = 30
        Me.grid_showbringprod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grid_showbringprod.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.del, Me.runno, Me.prod_name, Me.prod_qty, Me.unit, Me.price, Me.brand, Me.capacity, Me.prodid, Me.detail, Me.unit2, Me.prodtype})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid_showbringprod.DefaultCellStyle = DataGridViewCellStyle6
        Me.grid_showbringprod.Location = New System.Drawing.Point(23, 85)
        Me.grid_showbringprod.Name = "grid_showbringprod"
        Me.grid_showbringprod.Size = New System.Drawing.Size(812, 178)
        Me.grid_showbringprod.TabIndex = 98
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btn_bringreport)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btn_delproductbring)
        Me.Panel1.Controls.Add(Me.grid_showbringprod)
        Me.Panel1.Location = New System.Drawing.Point(0, 387)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 275)
        Me.Panel1.TabIndex = 3
        '
        'form_bring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 662)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "form_bring"
        Me.Text = "form_bring"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grid_bringresult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_showbringprod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cbo_bringproducttype As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_delbring As System.Windows.Forms.Button
    Friend WithEvents btn_editbring As System.Windows.Forms.Button
    Friend WithEvents btn_resetbring As System.Windows.Forms.Button
    Friend WithEvents btn_addbring As System.Windows.Forms.Button
    Friend WithEvents btn_searchproductbring As System.Windows.Forms.Button
    Friend WithEvents txt_bringprod As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_bringdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_bringid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_searchbring As System.Windows.Forms.ComboBox
    Friend WithEvents btn_searchbring As System.Windows.Forms.Button
    Friend WithEvents txt_searchbring As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grid_bringresult As System.Windows.Forms.DataGridView
    Friend WithEvents del As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btn_bringreport As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_delproductbring As System.Windows.Forms.Button
    Friend WithEvents grid_showbringprod As System.Windows.Forms.DataGridView
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_searchmempick As System.Windows.Forms.Button
    Friend WithEvents txt_pickempid As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_pickempname As System.Windows.Forms.TextBox
End Class
