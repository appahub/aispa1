Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_recieve_old
    Dim Obj_query As New classquery()
    Dim sql As String
    Dim datatable As New DataTable
    Dim selectedIndex As Integer
    Dim plus_colume As Integer = 0
    Dim readytodo As Boolean = False
    Dim sup_id As Integer
    Private Sub form_recieve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectedIndex = 0
        UpdateSupplier(selectedIndex)
    End Sub
    Private Sub form_recieve_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        form_home.Enabled = True
    End Sub 'Form1_Closing
    Private Sub tab_management_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_management.Click
        selectedIndex = tab_management.SelectedIndex
        UpdateSupplier(selectedIndex)
    End Sub
    Private Sub UpdateSupplier(ByVal index As Integer)

        Dim havedropdown(,) As String =
        {
            {"0", "select sup_id ID,sup_companyname Name from supplier(nolock) order by sup_id", "0"},
            {"1", "select sup_id ID,sup_companyname Name from supplier(nolock) order by sup_id", "1"}
        }
        Dim mygrid() As DataGridView = {grid_managerecieve1, grid_managerecieve2}
        Dim mycombobox() As ComboBox = {
            cbo_supplier1, cbo_supplier2
        }
        For i As Integer = 0 To havedropdown.GetLength(0) - 1
            If (index.ToString() = havedropdown(i, 0)) Then
                GetDatatoCombobox(havedropdown(i, 1), mycombobox(Integer.Parse(havedropdown(i, 2))))
            End If
        Next
        readytodo = True
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
                If Not IsDBNull(mygrid.Rows(0).Cells(i).Value) Then
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
    Private Sub setReadonlyGridunsuc(ByVal mygrid As DataGridView)
        For i As Integer = 0 To mygrid.Columns.Count - 1
            If ((i <> 9 And i <> 7)) Then
                mygrid.Columns(i).ReadOnly = True
            End If
            If i = 10 Then
                mygrid.Columns(i).Visible = False
            End If
        Next
    End Sub
    Private Sub setReadonlyGridsuc(ByVal mygrid As DataGridView)
        For i As Integer = 0 To mygrid.Columns.Count - 1
            If ((i <> 10 And i <> 8 And i <> 0)) Then
                mygrid.Columns(i).ReadOnly = True
            End If
            If i = 11 Or i = 12 Or i = 13 Then
                mygrid.Columns(i).Visible = False
            End If
        Next
    End Sub
    Private Sub cbo_supplier1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_supplier1.SelectedIndexChanged
        sup_id = cbo_supplier1.SelectedValue
        getorder_receivelist()

    End Sub
    Private Sub getorder_receivelist()
        Dim sqlquery() As String =
        {
            " select distinct order_id 'รหัสการสั่งซื้อ',convert(varchar(10),order_date,103) 'วันที่สั่งซื้อ' from product_order (nolock) " &
            " where isnull(order_status,'N') = 'N' and  sup_id = " & sup_id,
            " select distinct a.order_id 'รหัสการสั่งซื้อ',convert(varchar(10),a.order_date,103) 'วันที่สั่งซื้อ' from product_order a(nolock) " &
            " join product_receive c(nolock) on a.order_id = c.order_id " &
            " where a.sup_id = " & sup_id
        }
        Dim grid_orderrecieve() As DataGridView = {grid_showrev_unsuc, grid_showrev_suc}

        GetDataToGrid(sqlquery(0), grid_orderrecieve(0)) ' SHow detail in Recieve_unsuccess
        GetDataToGrid(sqlquery(1), grid_orderrecieve(1)) ' SHow detail in Recieve_success
    End Sub
    Private Sub grid_showrev_suc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showrev_suc.CellClick
        btn_delrecieve.Visible = True
        plus_colume = 1
        Dim rowindex As Integer = grid_showrev_suc.CurrentRow.Index
        Dim orderid As String = grid_showrev_suc.Rows(rowindex).Cells(0).Value.ToString
        sql = "select ROW_NUMBER() OVER(ORDER BY a.order_id DESC) AS 'ลำดับ'" &
              " , a.order_id 'รหัสการสั่งซื้อ', convert(varchar(10),order_date,103) 'วันที่สั่งซื้อ',prod_name 'ซื้อผลิตภัณฑ์'" &
              " , prod_brand 'ยี่ห้อ',prod_capacity + ' ' + g.unit_name 'ปริมาตร',b.deorder_qty 'จำนวนที่สั่ง' " &
              " ,d.dereceive_qty 'จำนวนที่รับ',f.unit_name 'หน่วยนับ' " &
              " ,d.dereceive_price 'ราคา/บาท' , b.prod_id , d.dereceive_id , c.receive_id" &
              " from product_order a(nolock) " &
              " join product_order_detail b(nolock) on a.order_id = b.order_id " &
              " join product_receive c(nolock) on a.order_id = c.order_id " &
              " join product_receive_detail d(nolock) on c.receive_id = d.receive_id and b.prod_id = d.prod_id and isnull(d.dereceive_qty,'') <> '' " &
              " join product e(nolock) on b.prod_id = e.prod_id " &
              " join unit f(nolock) on e.unit_id = f.unit_id " &
              " join unit g(nolock) on e.unit_id_cap = g.unit_id " &
              " where  a.order_id = " & orderid
        clear_grid(grid_managerecieve1)
        Dim chk As New DataGridViewCheckBoxColumn()
        grid_managerecieve1.Columns.Add(chk)
        chk.Name = "ลบรายการ"
        GetDataToGrid(sql, grid_managerecieve1)
        setReadonlyGridsuc(grid_managerecieve1)

    End Sub
    Private Sub grid_showrev_unsuc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showrev_unsuc.CellClick
        btn_delrecieve.Visible = False
        plus_colume = 0
        Dim rowindex As Integer = grid_showrev_unsuc.CurrentRow.Index
        Dim orderid As String = grid_showrev_unsuc.Rows(rowindex).Cells(0).Value.ToString
        sql = "select ROW_NUMBER() OVER(ORDER BY a.order_id DESC) AS 'ลำดับ'" &
              " , a.order_id 'รหัสการสั่งซื้อ' , convert(varchar(10),order_date,103) 'วันที่สั่งซื้อ',prod_name 'ซื้อผลิตภัณฑ์'" &
              " , prod_brand 'ยี่ห้อ',prod_capacity + ' ' + g.unit_name 'ปริมาตร',b.deorder_qty 'จำนวนที่สั่ง' " &
              " ,d.dereceive_qty 'จำนวนที่รับ',f.unit_name 'หน่วยนับ' " &
              " ,d.dereceive_price 'ราคา/บาท' , b.prod_id " &
              " from product_order a(nolock) " &
              " left join product_order_detail b(nolock) on a.order_id = b.order_id " &
              " left join product_receive c(nolock) on a.order_id = c.order_id " &
              " left join product_receive_detail d(nolock) on c.receive_id = d.receive_id and b.prod_id = d.prod_id" &
              " join product e(nolock) on b.prod_id = e.prod_id " &
              " join unit f(nolock) on e.unit_id = f.unit_id " &
              " join unit g(nolock) on e.unit_id_cap = g.unit_id " &
              " where isnull(order_status,'N') = 'N' and (b.deorder_qty <> d.dereceive_qty or isnull(d.dereceive_qty,'')='')  and a.order_id = " & orderid
        clear_grid(grid_managerecieve1)
        GetDataToGrid(sql, grid_managerecieve1)
        setReadonlyGridunsuc(grid_managerecieve1)

    End Sub

    Private Sub btn_addrecieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addrecieve.Click
        Dim orderid As String = grid_managerecieve1.Rows(0).Cells(1 + plus_colume).Value.ToString()
        module_emp_id = 1
        btn_delrecieve.Visible = False
        Dim createrecieve As Boolean = False
        sql = "select order_id from product_receive where order_id = " & orderid & " and convert(varchar(10),receive_date,103) = convert(varchar(10),GETDATE(),103)"
        If Obj_query.countdata(sql) >= 0 Then
            sql = "insert into product_receive values (GETDATE()," & orderid & "," & module_emp_id & ")"
            For Each row As DataGridViewRow In grid_managerecieve1.Rows
                Dim o_qty1 As Integer = Integer.Parse(row.Cells(6 + plus_colume).Value.ToString())
                Dim qty_num1 As Integer
                Dim price_num1 As Double
                If row.Cells(7 + plus_colume).Value.ToString() <> "" And row.Cells(9 + plus_colume).Value.ToString() <> "" And Integer.TryParse(row.Cells(7 + plus_colume).Value.ToString(), qty_num1) And qty_num1 <= o_qty1 And Double.TryParse(row.Cells(9 + plus_colume).Value.ToString(), price_num1) Then
                    createrecieve = True
                End If
            Next
        Else
            createrecieve = True
        End If

        If createrecieve = True Then

            If Obj_query.DMLData(sql) Then
                sql = "declare @lastid as integer = IDENT_CURRENT('product_receive')"

                For Each row As DataGridViewRow In grid_managerecieve1.Rows
                    Dim qty As String = row.Cells(7 + plus_colume).Value.ToString()
                    Dim price As String = row.Cells(9 + plus_colume).Value.ToString()
                    Dim o_qty As Integer = Integer.Parse(row.Cells(6 + plus_colume).Value.ToString())
                    Dim prod_id As String = row.Cells(10 + plus_colume).Value.ToString()
                    Dim qty_num As Integer
                    Dim price_num As Double
                    Dim descriptio As String = ""
                    Dim suc As Integer = 0
                    If qty <> "" And Integer.TryParse(qty, qty_num) And qty_num <= o_qty And Double.TryParse(price, price_num) Then
                        Dim chkdup As String = "declare @lastid as integer = IDENT_CURRENT('product_receive')"
                        chkdup &= "select COUNT(*) from product_receive_detail where receive_id = @lastid and prod_id = " & prod_id
                        If (Obj_query.selectdataInt(chkdup) > 0) Then
                            sql &= "update product_receive_detail set dereceive_qty = " & qty_num & " , dereceive_price = " & price_num & " where receive_id = @lastid and prod_id = " & prod_id
                        Else
                            sql &= " insert into product_receive_detail values (" & qty_num & ", " & price_num & " , @lastid , " & prod_id & ")"
                        End If

                    End If
                Next
            End If
            If Obj_query.DMLData(sql) Then
                MsgBox("ทำการบันทึกรายการรับสินค้าเรียบร้อยแล้ว")
                clear_grid(grid_managerecieve1)
            Else
                MsgBox("กรอกข้อมูลไม่ถูกต้องกรุณาตรวจสอบ")
            End If
        Else
            MsgBox("กรอกข้อมูลไม่ถูกต้องกรุณาตรวจสอบ")
        End If
        UpdateOrderStatus(orderid)
        getorder_receivelist()
    End Sub
    Private Sub clear_grid(ByVal mygrid As DataGridView)
        mygrid.DataSource = Nothing
        mygrid.Columns.Clear()
        mygrid.Refresh()
        mygrid.RefreshEdit()
    End Sub
    Private Sub UpdateOrderStatus(ByVal orderid As Integer)
        sql = " select COUNT(*) from product_order a(nolock)" &
              " join product_order_detail b(nolock) on a.order_id = b.order_id " &
              " where a.order_id = " & orderid
        Dim totallistinthisorder As Integer = Obj_query.selectdataInt(sql)
        sql = " select COUNT(*) from product_order a(nolock)" &
              " join product_order_detail b(nolock) on a.order_id = b.order_id " &
              " join product_receive c(nolock) on a.order_id = c.order_id" &
              " join product_receive_detail d(nolock) on c.receive_id = d.receive_id and b.prod_id = d.prod_id" &
              " where b.deorder_qty = d.dereceive_qty and a.order_id = " & orderid
        Dim successlistinthisorder As Integer = Obj_query.selectdataInt(sql)
        If totallistinthisorder = successlistinthisorder Then
            sql = "update product_order set order_status = 'Y' where order_id = " & orderid
        Else
            sql = "update product_order set order_status = 'N' where order_id = " & orderid
        End If
        Obj_query.DMLData(sql)
    End Sub


    Private Sub btn_delrecieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delrecieve.Click
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการรับผลิตภัณฑ์นี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            Dim del As Integer = 0
            Dim receiveid As String = ""
            Dim orderid As String = ""
            For Each row As DataGridViewRow In grid_managerecieve1.Rows
                If row.Cells(0).Value = True Then
                    Dim dereceiveid As String = row.Cells(12).Value.ToString()
                    receiveid = row.Cells(13).Value.ToString()
                    orderid = row.Cells(2).Value.ToString()
                    sql = "delete from product_receive_detail where dereceive_id = " & dereceiveid
                    sql &= " update product_order set order_status = 'N' where order_id = " & orderid
                    If (Obj_query.DMLData(sql)) Then
                        del = del + 1
                    End If
                End If
            Next
            'Console.WriteLine(del & " : " & grid_managerecieve1.Rows.Count)
            If del = grid_managerecieve1.Rows.Count Then
                sql = "delete from product_receive where receive_id = " & receiveid
                If (Obj_query.DMLData(sql)) Then
                    MsgBox("ลบรายการรับผลิตภัณฑ์เรียบร้อยแล้ว")
                End If
            ElseIf del > 0 Then
                MsgBox("ลบรายการรับผลิตภัณฑ์เรียบร้อยแล้ว")
            End If
            If orderid <> "" Then
                UpdateOrderStatus(orderid)
                getorder_receivelist()
                clear_grid(grid_managerecieve1)
            End If
        End If
    End Sub

    Private Sub btn_searchreceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchreceive.Click
        clear_grid(grid_managerecieve2)
        sup_id = cbo_supplier2.SelectedValue
        Dim searchdate As String = dtp_receivedate.Value.ToString("yyyyMMdd")
        Dim searchby As String = ""
        If cbo_searchby.SelectedIndex = 0 Then
            sql = " select distinct c.receive_id 'รหัสการรับผลิตภัณฑ์',convert(varchar(10),c.receive_date,103) 'วันที่รับผลิตภัณฑ์' from product_order a(nolock) " &
            " join product_receive c(nolock) on a.order_id = c.order_id order by (c.receive_id) desc "
        ElseIf cbo_searchby.SelectedIndex = 1 Then
            sql = " select distinct c.receive_id 'รหัสการรับผลิตภัณฑ์',convert(varchar(10),c.receive_date,103) 'วันที่รับผลิตภัณฑ์' from product_order a(nolock) " &
            " join product_receive c(nolock) on a.order_id = c.order_id " &
            " where a.sup_id = " & sup_id & " order by (c.receive_id) desc  "
        ElseIf cbo_searchby.SelectedIndex = 2 Then
            sql = " select distinct c.receive_id 'รหัสการรับผลิตภัณฑ์',convert(varchar(10),c.receive_date,103) 'วันที่รับผลิตภัณฑ์' from product_order a(nolock) " &
            " join product_receive c(nolock) on a.order_id = c.order_id " &
            " where convert(varchar(8),c.receive_date,112) = '" & searchdate & "'"
        End If
        GetDataToGrid(sql, grid_revsearch)
        'sql = "select ROW_NUMBER() OVER(ORDER BY a.order_id DESC) AS 'ลำดับ'" &
        '      " , a.order_id 'รหัสการสั่งซื้อ', convert(varchar(10),order_date,103) 'วันที่สั่งซื้อ',prod_name 'ซื้อผลิตภัณฑ์'" &
        '      " , prod_brand 'ยี่ห้อ',prod_capacity + ' ' + g.unit_name 'ปริมาตร',b.deorder_qty 'จำนวนที่สั่ง' " &
        '      " ,d.dereceive_qty 'จำนวนที่รับ',f.unit_name 'หน่วยนับ' " &
        '      " ,d.dereceive_price 'ราคา/บาท' , b.prod_id , d.dereceive_id , c.receive_id" &
        '      " from product_order a(nolock) " &
        '      " join product_order_detail b(nolock) on a.order_id = b.order_id " &
        '      " join product_receive c(nolock) on a.order_id = c.order_id " &
        '      " join product_receive_detail d(nolock) on c.receive_id = d.receive_id and b.prod_id = d.prod_id and isnull(d.dereceive_qty,'') <> '' " &
        '      " join product e(nolock) on b.prod_id = e.prod_id " &
        '      " join unit f(nolock) on e.unit_id = f.unit_id " &
        '      " join unit g(nolock) on e.unit_id_cap = g.unit_id " &
        '      " where  a.order_id = " & orderid
        'clear_grid(grid_managerecieve2)
        'GetDataToGrid(sql, grid_managerecieve2)
    End Sub

    Private Sub grid_revsearch_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_revsearch.CellClick
        Dim rowindex As Integer = grid_revsearch.CurrentRow.Index
        Dim searchid As String = grid_revsearch.Rows(rowindex).Cells(0).Value.ToString
        Dim searchdate As String = Date.Parse(grid_revsearch.Rows(rowindex).Cells(1).Value).ToString("yyyyMMdd")
        sql = "select ROW_NUMBER() OVER(ORDER BY a.order_id DESC) AS 'ลำดับ'" &
              " , a.order_id 'รหัสการสั่งซื้อ', convert(varchar(10),order_date,103) 'วันที่สั่งซื้อ',prod_name 'ซื้อผลิตภัณฑ์'" &
              " , prod_brand 'ยี่ห้อ',prod_capacity + ' ' + g.unit_name 'ปริมาตร',b.deorder_qty 'จำนวนที่สั่ง' " &
              " ,d.dereceive_qty 'จำนวนที่รับ',f.unit_name 'หน่วยนับ' " &
              " ,d.dereceive_price 'ราคา/บาท'" &
              " from product_order a(nolock) " &
              " join product_order_detail b(nolock) on a.order_id = b.order_id " &
              " join product_receive c(nolock) on a.order_id = c.order_id " &
              " join product_receive_detail d(nolock) on c.receive_id = d.receive_id and b.prod_id = d.prod_id and isnull(d.dereceive_qty,'') <> '' " &
              " join product e(nolock) on b.prod_id = e.prod_id " &
              " join unit f(nolock) on e.unit_id = f.unit_id " &
              " join unit g(nolock) on e.unit_id_cap = g.unit_id " &
              " where  c.receive_id = " & searchid
        clear_grid(grid_managerecieve2)
        GetDataToGrid(sql, grid_managerecieve2)
    End Sub

    Private Sub cbo_searchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchby.SelectedIndexChanged
        If cbo_searchby.SelectedIndex = 1 Then
            lbl_supplier2.Visible = True
            cbo_supplier2.Visible = True
            lbl_receivedate.Visible = False
            dtp_receivedate.Visible = False
        ElseIf cbo_searchby.SelectedIndex = 2 Then
            lbl_supplier2.Visible = False
            cbo_supplier2.Visible = False
            lbl_receivedate.Visible = True
            dtp_receivedate.Visible = True
        End If
    End Sub

    Private Sub btn_resetmemberrecieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetmemberrecieve.Click
        clear_grid(grid_managerecieve1)
    End Sub
End Class