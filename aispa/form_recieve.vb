Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_recieve
    Public Obj_query As New classquery()
    Dim sql As String
    Dim datatable As New DataTable
    Dim selectedIndex As Integer
    Dim click_order As Boolean = False
    Dim old_recieve_prod() As Integer = New Integer(50) {}
#Region "receive"
    Private Sub btn_addreceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addreceive.Click
        Dim receivedate As String = dtp_receivedate.Value.ToString("yyyy-MM-dd HH:MM")
        Dim emp_id As Integer = module_emp_id
        Dim datetomorow As Integer = Integer.Parse(Date.Now().ToString("yyyyMMdd"))
        Dim datecurrent As Integer = Integer.Parse(dtp_receivedate.Value.ToString("yyyyMMdd"))
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการบันทึกรายการรับนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If (grid_showreceiveprod.Rows.Count > 0 And receivedate <> "" And emp_id > 0 And datecurrent <= datetomorow) Then
                If grid_showreceiveprod.Rows.Count > 0 Then
                    For i As Integer = 0 To grid_showreceiveprod.Rows.Count - 1
                        If grid_showreceiveprod.Rows(i).Cells(1).Value <> "" And grid_showreceiveprod.Rows(i).Cells(3).Value = "" Then
                            MsgBox("ไม่ได้ระบุจำนวน")
                            Exit Sub
                        End If
                    Next
                End If
                sql = "insert into product_receive values (GETDATE()," & currentorderid & "," & module_emp_id & ")"
                If (Obj_query.DMLData(sql)) Then
                    sql = "declare @lastid as integer = IDENT_CURRENT('product_receive')"
                    Dim havedata As Boolean = False
                    For Each row As DataGridViewRow In grid_showreceiveprod.Rows
                        Dim prod_id As String = row.Cells(11).Value
                        Dim prod_qty As String = row.Cells(3).Value
                        Dim prod_price As Double = Double.Parse(row.Cells(7).Value.ToString())
                        Dim qty As Integer
                        Dim chkqty As String = "select isnull(( deorder_qty - ( select SUM(b.dereceive_qty) sum_qty from product_receive a(nolock) " &
                        " join product_receive_detail b(nolock) on a.receive_id = b.receive_id" &
                        " where prod_id = " & prod_id & " and a.order_id = " & currentorderid & " ) ),deorder_qty) qty from product_order_detail where prod_id = " & prod_id & " and order_id = " & currentorderid
                        Dim qtyinstock As Integer = Obj_query.selectdataInt(chkqty)
                        If Integer.TryParse(prod_qty, qty) And qty <= qtyinstock Then
                            If qty > 0 Then
                                sql &= "insert into product_receive_detail values (" & qty & ", " & (qty * prod_price) & " , @lastid , " & prod_id & ")"
                                havedata = True
                            End If
                        Else
                            sql &= " delete from product_receive where receive_id = @lastid "
                            If (Obj_query.DMLData(sql)) Then
                                MsgBox("ผลิตภัณฑ์ที่รับมากกว่าจำนวนที่สั่ง หรือ กรอกข้อมูลไม่ถูกต้อง กรุณาทำรายการใหม่")
                            End If
                            Exit Sub
                        End If
                    Next
                    If havedata = True Then
                        If (Obj_query.DMLData(sql)) Then
                            MsgBox("เพิ่มข้อมูลการรับเรียบร้อยแล้ว")
                        Else
                            MsgBox("มีบางข้อมูลอาจจะ เพิ่มไม่ได้ กรุณาตรวจสอบ")
                        End If
                    Else
                        sql &= " delete from product_receive where receive_id = @lastid "
                        If (Obj_query.DMLData(sql)) Then
                            MsgBox("กรูณากรอกจำนวนผลิตภัณฑ์ที่รับ")
                        End If
                    End If

                    UpdateOrderStatus(currentorderid)
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้ กรุณาตรวจสอบ")
                End If
            Else
                MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
            End If
        End If

    End Sub

    Private Sub btn_editreceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editreceive.Click
        Dim receiveid As String = txt_receiveid.Text
        Dim receivedate As String = dtp_receivedate.Value.ToString("yyyy-MM-dd HH:MM")
        Dim emp_id As Integer = module_emp_id
        Dim datetomorow As Integer = Integer.Parse(Date.Now().ToString("yyyyMMdd"))
        Dim datecurrent As Integer = Integer.Parse(dtp_receivedate.Value.ToString("yyyyMMdd"))
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการแก้ไขรายการรับนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If (receiveid <> "" And grid_showreceiveprod.Rows.Count > 0 And receivedate <> "" And emp_id > 0 And datecurrent <= datetomorow) Then
                If grid_showreceiveprod.Rows.Count > 0 Then
                    For i As Integer = 0 To grid_showreceiveprod.Rows.Count - 1
                        If grid_showreceiveprod.Rows(i).Cells(1).Value <> "" And grid_showreceiveprod.Rows(i).Cells(3).Value = "" Then
                            MsgBox("ไม่ได้ระบุจำนวนรับ")
                            Exit Sub
                        End If
                    Next
                End If
                sql = ""
                For r As Integer = 0 To grid_showreceiveprod.Rows.Count - 1
                    Dim row As DataGridViewRow = grid_showreceiveprod.Rows(r)
                    Dim dereceiveid As String = row.Cells(12).Value.ToString()
                    Dim pid As String = row.Cells(11).Value.ToString()
                    Dim prod_qty As String = row.Cells(3).Value
                    Dim prod_order As String = row.Cells(4).Value
                    Dim prod_left As String = row.Cells(5).Value.ToString()
                    Dim prod_price As Double = Double.Parse(row.Cells(7).Value.ToString())
                    Dim qty As Integer
                    Dim chkqty As String = "select isnull(( deorder_qty - ( select SUM(b.dereceive_qty) sum_qty from product_receive a(nolock) " &
                        " join product_receive_detail b(nolock) on a.receive_id = b.receive_id" &
                        " where prod_id = " & pid & " and a.order_id = " & currentorderid & " ) ),deorder_qty) qty from product_order_detail where prod_id = " & pid & " and order_id = " & currentorderid
                    Dim qtyinstock As Integer = Obj_query.selectdataInt(chkqty)
                    Dim chksql As String = "select count(*) from product_receive_detail where dereceive_id = " & dereceiveid & " and prod_id = " & pid
                    sql = "update product_receive set emp_id = " & module_emp_id & " where receive_id = " & receiveid
                    If Obj_query.selectdataInt(chksql) <= 0 Or dereceiveid = "" Then
                        If Integer.TryParse(prod_qty, qty) And (qty <= qtyinstock Or dereceiveid = "") Then
                            If qty > 0 Then
                                sql &= "insert into product_receive_detail values (" & qty & ", " & (qty * prod_price) & " , @lastid , " & pid & ")"
                            End If
                        Else
                            MsgBox("กรอกข้อมูลไม่ถูกต้องกรุณาตรวจสอบ หรือ ผลิตภัณฑ์ที่รับเกินกว่าจำนวนที่สั่งซื้อ")
                            Exit Sub
                        End If
                    Else
                        If Integer.TryParse(prod_qty, qty) And qty > 0 And (qty <= qtyinstock Or prod_left <> "0" Or prod_qty = prod_order) Then
                            sql &= " update product_receive_detail set dereceive_qty = " & qty & ",dereceive_price = " & (qty * prod_price) & " where prod_id = " & pid &
                                " and dereceive_id = " & dereceiveid
                        Else
                            If qty > qtyinstock Then
                                MsgBox("ผลิตภัณฑ์คงเหลือไม่เพียงพอ กรุณาทำรายการใหม่")
                            Else
                                MsgBox("กรอกข้อมูลไม่ถูกต้องกรุณาตรวจสอบ")
                            End If

                            Exit Sub
                        End If

                    End If
                Next

                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขการรับเรียบร้อยแล้ว")
                Else
                    MsgBox("มีบางข้อมูลอาจจะ แก้ไขไม่ได้ กรุณาตรวจสอบ")
                End If
                UpdateOrderStatus(currentorderid)

                UpdateDatainGrid(selectedIndex)
                clearData(selectedIndex)
            Else
                MsgBox("กรุณากรอกข้อมูลให้ครบ")
            End If
        End If
    End Sub

    Private Sub btn_delreceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delreceive.Click
        Dim receiveid As String = txt_receiveid.Text
        Dim emp_id As Integer = module_emp_id
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการรับนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        sql = ""
        Dim deldetailsuccess = False
        If answer = vbYes Then
            If (receiveid <> "") Then
                If grid_showreceiveprod.Rows.Count > 0 Then
                    Dim totalproduct = grid_showreceiveprod.Rows.Count - 1
                    While (totalproduct >= 0)
                        Dim detailreceiveid As String = grid_showreceiveprod.Rows(totalproduct).Cells(12).Value
                        If grid_showreceiveprod.Rows(totalproduct).Cells(0).Value = True Then
                            sql &= " delete from product_receive_detail where dereceive_id = " & detailreceiveid
                            grid_showreceiveprod.Rows.RemoveAt(totalproduct)
                        End If
                        totalproduct -= 1
                    End While
                End If

                If grid_showreceiveprod.Rows.Count = 0 Then
                    sql &= " delete from product_receive_detail where dereceive_id = " & receiveid

                    sql &= " delete from product_receive where receive_id = " & receiveid
                End If
                If sql <> "" Then
                    If Obj_query.DMLData(sql) Then
                        MsgBox("ลบการรับเรียบร้อยแล้ว")
                        clearData(selectedIndex)
                    Else
                        MsgBox("มีบางข้อมูลอาจจะ ลบไม่ได้ กรุณาตรวจสอบ หรือ ข้อมูลอาจจะมีการใช้งานอยู่")
                    End If
                Else
                    MsgBox("กรุณาเลือกรายการที่ต้องการลบ")
                End If
                
            Else
                MsgBox("ข้อมูลบาง field ไม่ถูกต้อง")
            End If
        End If
        UpdateOrderStatus(currentorderid)
        UpdateDatainGrid(selectedIndex)

    End Sub
    Private Sub UpdateOrderStatus(ByVal orderid As Integer)
        sql = " select COUNT(*) from product_order a(nolock)" &
              " join product_order_detail b(nolock) on a.order_id = b.order_id " &
              " where a.order_id = " & orderid
        Dim totallistinthisorder As Integer = Obj_query.selectdataInt(sql)
        'sql = " select COUNT(*) from product_order a(nolock)" &
        '      " join product_order_detail b(nolock) on a.order_id = b.order_id " &
        '      " join product_receive c(nolock) on a.order_id = c.order_id" &
        '      " join product_receive_detail d(nolock) on c.receive_id = d.receive_id and b.prod_id = d.prod_id" &
        '      " where b.deorder_qty = d.dereceive_qty and a.order_id = " & orderid
        sql = " select count(*) from product_order a(nolock) " &
            " join product_order_detail b(nolock) on a.order_id = b.order_id " &
            " join ( select SUM(b.dereceive_qty) sum_qty, prod_id from product_receive a(nolock)" &
            " join product_receive_detail b(nolock) on a.receive_id = b.receive_id " &
            " where a.order_id = " & orderid & " group by prod_id ) as d  on b.prod_id = d.prod_id and d.sum_qty = b.deorder_qty " &
            " where(a.order_id = " & orderid & ") "
        Dim successlistinthisorder As Integer = Obj_query.selectdataInt(sql)
        If totallistinthisorder = successlistinthisorder Then
            sql = "update product_order set order_status = 'Y' where order_id = " & orderid
        Else
            sql = "update product_order set order_status = 'N' where order_id = " & orderid
        End If
        Obj_query.DMLData(sql)
    End Sub
    Private Sub btn_resetreceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetreceive.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchreceive.Click
        Dim dropdownindex As Integer = cbo_searchreceive.SelectedIndex
        Dim textsearch As String = txt_searchreceive.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                sql = "select receive_id 'รหัสการรับ',convert(varchar(10),receive_date,103) 'วันที่รับ',convert(varchar(10),order_date,103) 'วันที่สั่ง',e.sup_companyname 'ตัวแทนจำหน่าย',  c.emp_fullname 'พนักงานที่ทำรายการรับ' ,a.order_id,e.sup_id  from product_receive as a " &
            " join employee as c on a.emp_id = c.emp_id " &
            " join product_order d on a.order_id = d.order_id " &
            " join supplier e on d.sup_id = e.sup_id " &
            " order by receive_id desc"
            ElseIf dropdownindex = 1 Then
                sql = "select receive_id 'รหัสการรับ',convert(varchar(10),receive_date,103) 'วันที่รับ',convert(varchar(10),order_date,103) 'วันที่สั่ง',e.sup_companyname 'ตัวแทนจำหน่าย',  c.emp_fullname 'พนักงานที่ทำรายการรับ' ,a.order_id,e.sup_id  from product_receive as a " &
            " join employee as c on a.emp_id = c.emp_id " &
            " join product_order d on a.order_id = d.order_id " &
            " join supplier e on d.sup_id = e.sup_id  where convert(varchar(10),receive_date,103) = '" & textsearch & "' order by receive_id desc"
            ElseIf dropdownindex = 2 Then
                sql = "select receive_id 'รหัสการรับ',convert(varchar(10),receive_date,103) 'วันที่รับ',convert(varchar(10),order_date,103) 'วันที่สั่ง',e.sup_companyname 'ตัวแทนจำหน่าย',  c.emp_fullname 'พนักงานที่ทำรายการรับ' ,a.order_id,e.sup_id  from product_receive as a " &
            " join employee as c on a.emp_id = c.emp_id " &
            " join product_order d on a.order_id = d.order_id " &
            " join supplier e on d.sup_id = e.sup_id  where c.emp_fullname like '" & textsearch & "%' or c.emp_fullname like '%" & textsearch & "%' or c.emp_fullname like '%" & textsearch & "'   order by receive_id desc"
            End If
            GetDataToGrid(sql, grid_receiveresult)
        End If
    End Sub
    Private Sub grid_receiveresult_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_receiveresult.CellClick
        click_order = False
        Dim rowindex As Integer = grid_receiveresult.CurrentRow.Index
        If grid_receiveresult.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_receiveid.Text = grid_receiveresult.Rows(rowindex).Cells(0).Value.ToString
            dtp_receivedate.Value = grid_receiveresult.Rows(rowindex).Cells(1).Value.ToString
            currentorderid = grid_receiveresult.Rows(rowindex).Cells(5).Value.ToString

            grid_showreceiveprod.Rows.Clear()
            sql = "select a.dereceive_id ID,b.prod_name Name,b.prod_brand,b.prod_capacity,a.dereceive_qty,c.unit_name,convert(varchar,prod_price,1) 'price',b.prod_id,d.unit_name,e.prod_type_name from product_receive_detail as a join product as b on a.prod_id = b.prod_id join unit c on b.unit_id = c.unit_id join unit d on b.unit_id_cap = d.unit_id join product_type e on b.prod_type_id = e.prod_type_id  where receive_id = " & grid_receiveresult.Rows(rowindex).Cells(0).Value & " order by a.dereceive_id"
            datatable = Obj_query.selectDatatoGrid(sql)
            Dim mysql As String = ""
            For i As Integer = 0 To datatable.Rows.Count - 1
                mysql = "select deorder_qty from product_order_detail a(nolock)  " &
                " join  product_receive b(nolock) on a.order_id = b.order_id " &
                " where receive_id = " & grid_receiveresult.Rows(rowindex).Cells(0).Value & " and prod_id = " & datatable.Rows(i)(7)
                Dim order_datatable As DataTable = Obj_query.selectDatatoGrid(mysql)
                Dim order_qty As Integer = 0
                Dim left_qty As Integer = 0
                Dim chkqty As String = "select isnull(( deorder_qty - ( select SUM(b.dereceive_qty) sum_qty from product_receive a(nolock) " &
                        " join product_receive_detail b(nolock) on a.receive_id = b.receive_id" &
                        " where prod_id = " & datatable.Rows(i)(7) & " and a.order_id = " & currentorderid & " ) ),deorder_qty) qty from product_order_detail where prod_id = " & datatable.Rows(i)(7) & " and order_id = " & currentorderid
                Dim receive_qty As Integer = Integer.Parse(Obj_query.selectdataInt(chkqty).ToString())
                If order_datatable.Rows.Count > 0 Then
                    order_qty = Integer.Parse(order_datatable.Rows(0)(0).ToString())
                    left_qty = receive_qty
                End If
                Dim total As Double = Integer.Parse(datatable.Rows(i)(4)) * Double.Parse(datatable.Rows(i)(6))
                Dim row As String() = New String() {False, (i + 1), datatable.Rows(i)(1), datatable.Rows(i)(4), order_qty, left_qty, datatable.Rows(i)(5), datatable.Rows(i)(6), total.ToString("0.00"), datatable.Rows(i)(2), datatable.Rows(i)(3), datatable.Rows(i)(7), datatable.Rows(i)(0), datatable.Rows(i)(8), datatable.Rows(i)(9)}
                grid_showreceiveprod.Rows.Add(row)
            Next
            btn_receivereport.Visible = True
            btn_addreceive.Visible = False
            btn_editreceive.Visible = True
            btn_delreceive.Visible = True
        End If
    End Sub
#End Region
    Private Sub form_receive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectedIndex = 0
        UpdateDatainGrid(0)
        currentgrid = grid_showreceiveprod
        'currentprodname = txt_receiveprod
    End Sub
    Private Sub form_receive_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim leadtimeproductsql As String = "select prod_id 'รหัส',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',d.prod_type_name 'ประเภทสินค้า',convert(varchar,prod_price,1) 'ราคาสินค้า','บาท' 'หน่วยนับ',a.prod_qty 'จำนวนสินค้า',b.unit_name 'หน่วยนับ',prod_capacity 'ปริมาตร',c.unit_name 'หน่วยนับปริมาตร' from product a(nolock) join unit b(nolock) on a.unit_id = b.unit_id join unit c on a.unit_id_cap = c.unit_id join product_type d on a.prod_type_id = d.prod_type_id  where (prod_qty - prod_leadtime) between (prod_leadtime * -1) and 2 order by prod_id"
        GetDataToGrid(leadtimeproductsql, form_home.grid_alertproduct)
        form_home.Enabled = True
    End Sub 'Form1_Closing
    Private Sub UpdateDatainGrid(ByVal index As Integer)
        Dim sqlqueryeachtab(3) As String
        sqlqueryeachtab(0) = "select receive_id 'รหัสการรับ',convert(varchar(10),receive_date,103) 'วันที่รับ',convert(varchar(10),order_date,103) 'วันที่สั่ง',e.sup_companyname 'ตัวแทนจำหน่าย',  c.emp_fullname 'พนักงานที่ทำรายการรับ' ,a.order_id,e.sup_id  from product_receive as a " &
            " join employee as c on a.emp_id = c.emp_id " &
            " join product_order d on a.order_id = d.order_id " &
            " join supplier e on d.sup_id = e.sup_id " &
            " order by receive_id desc"
        sqlqueryeachtab(1) = "select order_id 'รหัสการสั่งซื้อ' , order_date 'วันที่สั่งซื้อ'  , sup_companyname 'ตัวแทนจัดจำหน่าย' from product_order a(nolock) join supplier b(nolock) on a.sup_id = b.sup_id where order_status = 'N' order by order_id desc"
        Dim mygrid() As DataGridView = {grid_receiveresult, grid_showrev_unsuc}
        GetDataToGrid(sqlqueryeachtab(0), mygrid(0))
        GetDataToGrid(sqlqueryeachtab(1), mygrid(1))
        grid_receiveresult.Columns(5).Visible = False
        grid_receiveresult.Columns(6).Visible = False

    End Sub
    Private Sub clearData(ByVal index)
        If index = 0 Then
            txt_receiveid.Text = ""
            'txt_receiveprod.Text = ""
            dtp_receivedate.Value = Date.Now
            grid_showreceiveprod.Rows.Clear()
            btn_addreceive.Visible = True
            btn_editreceive.Visible = False
            btn_delreceive.Visible = False
            btn_receivereport.Visible = False
        End If
    End Sub
    Private Sub GetDataToGrid(ByVal mysql As String, ByVal mygrid As DataGridView)
        sql = mysql
        datatable = Obj_query.selectDatatoGrid(sql)
        If datatable.Rows.Count < 0 Then
            datatable.Rows.Add(New Object() {1, "ไม่มีข้อมูล"})
        End If
        With mygrid
            .AutoGenerateColumns = True
            .DataSource = datatable
            .Font = New Font("Microsoft Sans Serif", 10)
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 30
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
        End With
        If mygrid.Rows.Count > 0 Then
            For i As Integer = 1 To mygrid.Columns.Count - 1
                If mygrid.Rows(0).Cells(i).Value <> Nothing Then
                    Dim mydl As Double
                    If Double.TryParse(mygrid.Rows(0).Cells(i).Value, mydl) Then
                        mygrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub GetDatatoCombobox(ByVal mysql As String, ByVal mycombobox As ComboBox)
        sql = mysql
        datatable = Obj_query.selectDatatoGrid(sql)
        mycombobox.ValueMember = "ID"
        mycombobox.DisplayMember = "Name"
        mycombobox.DataSource = datatable
    End Sub

    Private Sub btn_searchproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        form_showproduct2.Show()
    End Sub

    Private Sub btn_delproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delproductreceive.Click
        Dim totalproduct = grid_showreceiveprod.Rows.Count - 1
        While (totalproduct >= 0)
            grid_showreceiveprod.Rows(totalproduct).Cells(0).Value = True
            totalproduct -= 1
        End While
    End Sub

    Private Sub cbo_searchreceive_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchreceive.SelectedIndexChanged
        If cbo_searchreceive.SelectedIndex = 0 Then
            txt_searchreceive.Text = ""
        End If
    End Sub


    Private Sub btn_receivereport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_receivereport.Click
        'receivereport.Show()
    End Sub


    Private Sub grid_receiveresult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_receiveresult.CellContentClick

    End Sub
    Private Sub grid_showreceiveprod_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showreceiveprod.CellEndEdit
        Dim rowindex As Integer = grid_showreceiveprod.CurrentRow.Index
        Dim prod_id As String = grid_showreceiveprod.Rows(rowindex).Cells(0).Value.ToString
        Dim prod_left As String = grid_showreceiveprod.Rows(rowindex).Cells(5).Value.ToString
        Dim prod_recieve As String = grid_showreceiveprod.Rows(rowindex).Cells(3).Value.ToString
        If prod_left <> "0" And e.ColumnIndex = 3 Then
            Dim chkqty As String = "select isnull(( deorder_qty - ( select SUM(b.dereceive_qty) sum_qty from product_receive a(nolock) " &
                        " join product_receive_detail b(nolock) on a.receive_id = b.receive_id" &
                        " where prod_id = " & prod_id & " and a.order_id = " & currentorderid & " ) ),deorder_qty) qty from product_order_detail where prod_id = " & prod_id & " and order_id = " & currentorderid
            Dim receive_totalqty As Integer = Obj_query.selectdataInt(chkqty)
            Dim receive_qty As Integer = Integer.Parse(grid_showreceiveprod.Rows(rowindex).Cells(3).Value.ToString)
            Dim order_qty As Integer = Integer.Parse(grid_showreceiveprod.Rows(rowindex).Cells(4).Value.ToString)
            Dim price_unit As Double = Double.Parse(grid_showreceiveprod.Rows(rowindex).Cells(7).Value.ToString)
            Dim left_qty As Integer = 0
            Dim totalprice As Double = 0
            receive_qty = receive_totalqty + receive_qty
            If order_qty >= receive_qty Then
                left_qty = order_qty - receive_qty - old_recieve_prod(rowindex)
                totalprice = price_unit * receive_qty
            End If

            grid_showreceiveprod.Rows(rowindex).Cells(5).Value = left_qty.ToString()
            grid_showreceiveprod.Rows(rowindex).Cells(8).Value = totalprice.ToString("0.00")
        End If
        
    End Sub

    Private Sub grid_showrev_unsuc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showrev_unsuc.CellClick
        click_order = True
        btn_addreceive.Visible = True
        btn_editreceive.Visible = False
        btn_delreceive.Visible = False
        btn_receivereport.Visible = False
        Dim rowindex As Integer = grid_showrev_unsuc.CurrentRow.Index
        currentorderid = grid_showrev_unsuc.Rows(rowindex).Cells(0).Value.ToString
        LoadProduct()
    End Sub

    Private Sub LoadProduct()
        currentgrid.Rows.Clear()
        If currentorderid = "" Then
            MsgBox("รหัสใบสั่งซื้อไม่ถูกต้อง")
            Me.Close()
            Exit Sub
        End If
        Dim order_sql As String = "select a.prod_id 'รหัส',a.prod_name 'ชื่อผลิตภัณฑ์',a.prod_brand 'ยี่ห้อ',convert(varchar,a.prod_price,1) 'ราคาสินค้า',a.prod_capacity 'ปริมาตร',b.unit_name 'หน่วยนับสินค้า',c.unit_name 'หน่วยนับปริมาตร',d.prod_type_name 'ประเภทสินค้า',g.order_id,e.deorder_qty " &
            " from product a(nolock) join unit b(nolock) on a.unit_id = b.unit_id " &
            " join unit c on a.unit_id_cap = c.unit_id join product_type d on a.prod_type_id = d.prod_type_id " &
            " join product_order_detail e(nolock) on e.prod_id = a.prod_id " &
            " join product_order g(nolock) on e.order_id=g.order_id " &
            " where g.order_id = " & currentorderid & "  order by a.prod_id"
        Dim orderdatatable As DataTable = Obj_query.selectDatatoGrid(order_sql)
        Dim indexprodingrid As Integer = 0
        For row As Integer = 0 To orderdatatable.Rows.Count - 1
            Dim prodid As String = orderdatatable.Rows(row)(0).ToString()
            Dim prodname As String = orderdatatable.Rows(row)(1).ToString
            Dim brand As String = orderdatatable.Rows(row)(2).ToString
            Dim price As String = orderdatatable.Rows(row)(3).ToString
            Dim capa As String = orderdatatable.Rows(row)(4).ToString
            Dim unit As String = orderdatatable.Rows(row)(5).ToString
            Dim unitcap As String = orderdatatable.Rows(row)(6).ToString
            Dim prodtype As String = orderdatatable.Rows(row)(7).ToString
            Dim prod_qty_order As String = orderdatatable.Rows(row)(9).ToString
            currentorderid = orderdatatable.Rows(row)(8).ToString
            'Dim sql = "select dereceive_qty,dereceive_price from product_receive a(nolock) " &
            '" join product_receive_detail b(nolock) on a.receive_id = b.receive_id " &
            '" where order_id = " & currentorderid & " and prod_id = " & prodid
            Dim sql = "select isnull(SUM(b.dereceive_qty),0) sum_qty,isnull(sum(b.dereceive_price),0) sum_price  from product_receive a(nolock) " &
                        " join product_receive_detail b(nolock) on a.receive_id = b.receive_id" &
                        " where prod_id = " & prodid & " and a.order_id = " & currentorderid
            Dim receivedata As DataTable = Obj_query.selectDatatoGrid(sql)
            Dim receive_qty As Integer = 0
            Dim receive_price As Double = 0.0
            If receivedata.Rows.Count > 0 Then
                receive_qty = Integer.Parse(receivedata.Rows(0)(0).ToString())
                receive_price = Double.Parse(receivedata.Rows(0)(1).ToString())
            End If
            Dim runno As Integer = 1
            If grid_showreceiveprod.Rows.Count > 0 Then
                runno = Integer.Parse(currentgrid.Rows(grid_showreceiveprod.Rows.Count - 1).Cells(1).Value.ToString())
                runno += 1
            End If
            If (prodname <> "" And prodid <> "") Then
                Dim prod_canrecieve As Integer = prod_qty_order - receive_qty
                Dim prod_leftleft As Integer = prod_qty_order - prod_canrecieve - receive_qty
                If prod_canrecieve > 0 Then
                    old_recieve_prod(indexprodingrid) = receive_qty
                    indexprodingrid = indexprodingrid + 1
                    'currentprodname.Text = prodname

                    If prod_canrecieve = 0 Then
                        prod_leftleft = 0
                    End If
                    Dim product_row As String() = New String() {False, runno, prodname, prod_canrecieve, prod_qty_order, prod_canrecieve, unit, price, Double.Parse(price * prod_canrecieve).ToString("0.00"), brand, capa, prodid, "", unitcap, prodtype}
                    If currentgrid.Rows.Count > 0 Then
                        For i As Integer = 0 To currentgrid.Rows.Count - 1
                            If currentgrid.Rows(i).Cells(0).Value <> "" Then
                                If currentgrid.Rows(i).Cells(2).Value.Equals(prodname) And
                                    currentgrid.Rows(i).Cells(6).Value.Equals(unit) And
                                    currentgrid.Rows(i).Cells(9).Value.Equals(brand) And
                                    currentgrid.Rows(i).Cells(10).Value.Equals(capa) And
                                    currentgrid.Rows(i).Cells(13).Value.Equals(unitcap) And
                                    currentgrid.Rows(i).Cells(14).Value.Equals(prodtype) Then
                                    Exit Sub
                                End If
                            End If
                        Next
                    End If

                    currentgrid.Rows.Add(product_row)
                    If prod_canrecieve = 0 Then
                        currentgrid.Rows(currentgrid.Rows.Count - 1).Cells(3).ReadOnly = True
                    End If
                End If
                
                'Dim chk As New DataGridViewCheckBoxColumn()
                'If (currentgrid.Columns.Count = 10) Then
                '    currentgrid.Columns.Add(chk)
                '    chk.Name = "ลบรายการ"
                'End If

                If currentgrid.Rows.Count > 0 Then
                    For i As Integer = 1 To currentgrid.Columns.Count - 1
                        If currentgrid.Rows(0).Cells(i).Value <> Nothing Then
                            Dim mydl As Double
                            If Double.TryParse(currentgrid.Rows(0).Cells(i).Value, mydl) Then
                                currentgrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub grid_showrev_unsuc_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showrev_unsuc.CellContentClick

    End Sub

    Private Sub grid_showreceiveprod_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showreceiveprod.CellContentClick
    End Sub
End Class