Imports aispa.classquery
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class form_order
    Public Obj_query As New classquery()
    Dim sql As String
    Dim datatable As New DataTable
    Dim selectedIndex As Integer
#Region "order"
    Private Sub btn_addorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addorder.Click
        Dim orderdate As String = dtp_orderdate.Value.ToString("yyyy-MM-dd HH:MM")
        Dim orderdatechk As String = dtp_orderdate.Value.ToString("yyyyMMdd")
        Dim ordersup As String = cbo_ordersupplier.SelectedValue
        Dim emp_id As Integer = module_emp_id
        Dim datetomorow As Integer = Integer.Parse(Date.Now().ToString("yyyyMMdd"))
        Dim datecurrent As Integer = Integer.Parse(dtp_orderdate.Value.ToString("yyyyMMdd"))
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการบันทึกรายการสั่งซื้อนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If (grid_showorderprod.Rows.Count > 0 And orderdate <> "" And ordersup <> "" And emp_id > 0 And datecurrent <= datetomorow) Then
                If grid_showorderprod.Rows.Count > 0 Then
                    For i As Integer = 0 To grid_showorderprod.Rows.Count - 1
                        If grid_showorderprod.Rows(i).Cells(1).Value <> "" And grid_showorderprod.Rows(i).Cells(3).Value = "" Then
                            MsgBox("ไม่ได้ระบุจำนวนสั่งซื้อ")
                            Exit Sub
                        End If
                    Next
                End If
                'sql = "select count(*) from product_order(nolock) where convert(varchar(8),order_date,112) = '" & orderdatechk & "' and sup_id = " & ordersup
                'If Obj_query.selectdataInt(sql) > 0 Then
                '    sql = " update product_order " &
                '         " set emp_id = " & emp_id & ",order_status = 'N' where order_date = convert(datetime,'" & orderdate & "') and sup_id = " & ordersup
                'Else
                sql = " insert into product_order (order_date,sup_id,emp_id,order_status) " &
                     " values (convert(datetime,'" & orderdate & "')," & ordersup & "," & emp_id & ",'N')"
                'End If

                If Obj_query.DMLData(sql) Then
                    sql = "select MAX(order_id) 'maxid' from product_order(nolock)"
                    datatable = Obj_query.selectDatatoGrid(sql)
                    Dim order_id = datatable.Rows(0)("maxid").ToString().Trim()
                    Dim flag As Boolean = False
                    For i As Integer = 0 To grid_showorderprod.Rows.Count - 1
                        Dim prod_id As String = grid_showorderprod.Rows(i).Cells(8).Value
                        Dim prod_qty As String = grid_showorderprod.Rows(i).Cells(3).Value
                        If grid_showorderprod.Rows(i).Cells(1).Value <> "" Then
                            sql = "select deorder_qty from product_order_detail where order_id = " & order_id & " and prod_id = " & prod_id
                            Dim myqty As Integer = Obj_query.selectdataInt(sql)
                            'If myqty > 0 Then
                            '    sql = " update product_order_detail set  " &
                            ' " deorder_qty = " & (prod_qty + myqty) & " where  order_id = " & order_id & " and prod_id = " & prod_id & ""
                            'Else
                            sql = " insert into product_order_detail (deorder_qty,order_id,prod_id) " &
                    " values(" & prod_qty & ", " & order_id & ", " & prod_id & ")"
                            'End If

                            If Obj_query.DMLData(sql) Then
                                flag = True
                            End If
                        End If

                    Next
                    If flag Then
                        MsgBox("เพิ่มข้อมูลการสั่งซื้อเรียบร้อยแล้ว")
                    Else
                        MsgBox("มีบางข้อมูลอาจจะ เพิ่มไม่ได้ กรุณาตรวจสอบ")
                    End If

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

    Private Sub btn_editorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editorder.Click
        Dim orderid As String = txt_orderid.Text
        Dim orderdate As String = dtp_orderdate.Value.ToString("yyyy-MM-dd HH:MM")
        Dim ordersup As String = cbo_ordersupplier.SelectedValue
        Dim emp_id As Integer = module_emp_id
        Dim datetomorow As Integer = Integer.Parse(Date.Now().ToString("yyyyMMdd"))
        Dim datecurrent As Integer = Integer.Parse(dtp_orderdate.Value.ToString("yyyyMMdd"))
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการแก้ไขรายการสั่งซื้อนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then


            If (orderid <> "" And grid_showorderprod.Rows.Count > 0 And orderdate <> "" And ordersup <> "" And emp_id > 0 And datecurrent <= datetomorow) Then
                If grid_showorderprod.Rows.Count > 0 Then
                    For i As Integer = 0 To grid_showorderprod.Rows.Count - 1
                        If grid_showorderprod.Rows(i).Cells(1).Value <> "" And grid_showorderprod.Rows(i).Cells(3).Value = "" Then
                            MsgBox("ไม่ได้ระบุจำนวนสั่งซื้อ")
                            Exit Sub
                        End If
                    Next
                End If
                sql =
                        " update product_order set order_date = '" & orderdate & "' ,sup_id = " & ordersup & ",emp_id = " & emp_id &
                        " where order_id = " & orderid
                If Obj_query.DMLData(sql) Then
                    Dim flag As Boolean = False
                    sql =
                       " delete from product_order_detail where order_id = " & orderid
                    Dim sqlcount = "select count(prod_type_id) from product_order_detail where order_id = " & orderid
                    If Obj_query.DMLData(sql) Or Obj_query.countdata(sqlcount) = 0 Then
                        For i As Integer = 0 To grid_showorderprod.Rows.Count - 1
                            Dim prod_id As String = grid_showorderprod.Rows(i).Cells(8).Value
                            Dim prod_qty As String = grid_showorderprod.Rows(i).Cells(3).Value
                            If grid_showorderprod.Rows(i).Cells(1).Value <> "" Then
                                sql =
                                    " insert into product_order_detail (deorder_qty,order_id,prod_id) " &
                                    " values(" & prod_qty & ", " & orderid & ", " & prod_id & ")"
                                If Obj_query.DMLData(sql) Then
                                    flag = True
                                End If
                            End If

                        Next
                    End If

                    If flag Then
                        MsgBox("แก้ไขการสั่งซื้อเรียบร้อยแล้ว")
                    Else
                        MsgBox("มีบางข้อมูลอาจจะ แก้ไขไม่ได้ กรุณาตรวจสอบ")
                    End If

                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("มีบางข้อมูลอาจจะ แก้ไขไม่ได้ กรุณาตรวจสอบ")
                End If
            Else
                MsgBox("กรุณากรอกข้อมูลให้ครบ")
            End If
        End If
    End Sub

    Private Sub btn_delorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delorder.Click
        Dim orderid As String = txt_orderid.Text
        Dim emp_id As Integer = Obj_query.GetEmpId()
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการสั่งซื้อนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim deldetailsuccess = False
        If answer = vbYes Then
            If (orderid <> "") Then
                If grid_showorderprod.Rows.Count > 0 Then
                    Dim totalproduct = grid_showorderprod.Rows.Count - 1
                    While (totalproduct >= 0)
                        Dim detailorderid As String = grid_showorderprod.Rows(totalproduct).Cells(9).Value
                        If grid_showorderprod.Rows(totalproduct).Cells(0).Value = True Then
                            sql =
                  " delete from  product_order_detail where deorder_id = " & detailorderid
                            Dim sqlcnt As String = "select count(prod_type_id) from product_order_detail where deorder_id = " & detailorderid
                            If Obj_query.DMLData(sql) Or (Obj_query.countdata(sqlcnt) = 0) Then
                                grid_showorderprod.Rows.RemoveAt(totalproduct)
                                deldetailsuccess = True
                            End If
                        End If
                        totalproduct -= 1
                    End While
                End If
                If grid_showorderprod.Rows.Count = 0 Then
                    sql =
                        " delete from  product_order_detail where order_id = " & orderid
                    Dim sqlcount = "select count(prod_type_id) from product_order_detail where order_id = " & orderid
                    If Obj_query.DMLData(sql) Or Obj_query.countdata(sqlcount) = 0 Then
                        Dim flag As Boolean = False
                        sql =
                           " delete from product_order where order_id = " & orderid
                        If Obj_query.DMLData(sql) Then
                            flag = True
                        End If

                        If flag Then
                            MsgBox("ลบการสั่งซื้อเรียบร้อยแล้ว")
                        Else
                            MsgBox("มีบางข้อมูลอาจจะ ลบไม่ได้ กรุณาตรวจสอบ หรือ ข้อมูลอาจจะมีการใช้งานอยู่")
                        End If

                        UpdateDatainGrid(selectedIndex)
                        clearData(selectedIndex)
                    Else
                        MsgBox("มีบางข้อมูลอาจจะ แก้ไขไม่ได้ กรุณาตรวจสอบ")
                    End If
                ElseIf deldetailsuccess = True Then
                    MsgBox("ลบรายการผลิตภัณฑ์เรียบร้อยแล้ว")
                ElseIf deldetailsuccess = False Then
                    MsgBox("ไม่สามารถลบรายการสั่งซื้อนี้ได้ เนื่องจากมีรายการสินค้าอยู่")
                End If
            Else
                MsgBox("ข้อมูลบาง field ไม่ถูกต้อง")
            End If
        End If


        'Dim orderid As String = txt_orderid.Text
        'Dim emp_id As Integer = Obj_query.GetEmpId()
        'Dim answer As DialogResult
        'answer = MessageBox.Show("คุณต้องการลบรายละเอียดรายการสั่งซื้อนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If answer = vbYes Then

        'End If
    End Sub

    Private Sub btn_resetorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetorder.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchorder.Click
        Dim dropdownindex As Integer = cbo_searchorder.SelectedIndex
        Dim textsearch As String = txt_searchorder.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select order_id 'รหัส',convert(varchar(10),order_date,103) 'วันที่สั่งซื้อ' , sup_companyname 'ชื่อบริษัท', sub_name 'ชื่อผู้ติดต่อ' , c.emp_fullname 'พนักงานที่ทำรายการสั่งซื้อ' from product_order as a join supplier as b on a.sup_id = b.sup_id join employee as c on a.emp_id = c.emp_id  where convert(varchar(10),order_date,103) = '" & textsearch & "' order by order_date desc,order_id desc"
            ElseIf dropdownindex = 2 Then
                sql = "select order_id 'รหัส',convert(varchar(10),order_date,103) 'วันที่สั่งซื้อ' , sup_companyname 'ชื่อบริษัท', sub_name 'ชื่อผู้ติดต่อ' , c.emp_fullname 'พนักงานที่ทำรายการสั่งซื้อ' from product_order as a join supplier as b on a.sup_id = b.sup_id join employee as c on a.emp_id = c.emp_id where sub_name like '" & textsearch & "%' or sub_name like '%" & textsearch & "%' or sub_name like '%" & textsearch & "'   order by order_date desc ,order_id desc"
            ElseIf dropdownindex = 3 Then
                sql = "select order_id 'รหัส',convert(varchar(10),order_date,103) 'วันที่สั่งซื้อ' , sup_companyname 'ชื่อบริษัท', sub_name 'ชื่อผู้ติดต่อ' , c.emp_fullname 'พนักงานที่ทำรายการสั่งซื้อ' from product_order as a join supplier as b on a.sup_id = b.sup_id join employee as c on a.emp_id = c.emp_id where sup_companyname like '" & textsearch & "%' or sup_companyname like '%" & textsearch & "%' or sup_companyname like '%" & textsearch & "'   order by order_date desc ,order_id desc"
            End If
            GetDataToGrid(sql, grid_orderresult)
        End If
    End Sub
    Private Sub grid_orderresult_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_orderresult.CellClick
        Dim rowindex As Integer = grid_orderresult.CurrentRow.Index
        If grid_orderresult.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_orderid.Text = grid_orderresult.Rows(rowindex).Cells(0).Value
            dtp_orderdate.Value = grid_orderresult.Rows(rowindex).Cells(1).Value
            cbo_ordersupplier.SelectedIndex = cbo_ordersupplier.FindString(grid_orderresult.Rows(rowindex).Cells(2).Value)
            grid_showorderprod.Rows.Clear()
            sql = "select a.deorder_id ID,b.prod_name Name,b.prod_brand,b.prod_capacity,a.deorder_qty,c.unit_name,convert(varchar,prod_price,1) 'price',b.prod_id,d.unit_name,e.prod_type_name from product_order_detail as a join product as b on a.prod_id = b.prod_id join unit c on b.unit_id = c.unit_id join unit d on b.unit_id_cap = d.unit_id join product_type e on b.prod_type_id = e.prod_type_id  where order_id = " & grid_orderresult.Rows(rowindex).Cells(0).Value & " order by a.deorder_id"
            datatable = Obj_query.selectDatatoGrid(sql)
            For i As Integer = 0 To datatable.Rows.Count - 1
                Dim row As String() = New String() {False, (i + 1), datatable.Rows(i)(1), datatable.Rows(i)(4), datatable.Rows(i)(5), datatable.Rows(i)(6), datatable.Rows(i)(2), datatable.Rows(i)(3), datatable.Rows(i)(7), datatable.Rows(i)(0), datatable.Rows(i)(8), datatable.Rows(i)(9)}
                grid_showorderprod.Rows.Add(row)
                Dim chk As New DataGridViewCheckBoxColumn()

                If (grid_showorderprod.Columns.Count < 10) Then
                    grid_showorderprod.Columns.Add(chk)
                    chk.Name = "ลบรายการ"
                End If
            Next
            btn_orderreport.Visible = True
            btn_addorder.Visible = False
            btn_editorder.Visible = True
            btn_delorder.Visible = True
        End If
    End Sub
#End Region
    Private Sub form_order_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectedIndex = 0
        UpdateDatainGrid(0)
        currentgrid = grid_showorderprod
        currentprodname = txt_orderprod
    End Sub
    Private Sub form_order_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim leadtimeproductsql As String = "select prod_id 'รหัส',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',d.prod_type_name 'ประเภทสินค้า',convert(varchar,prod_price,1) 'ราคาสินค้า','บาท' 'หน่วยนับ',a.prod_qty 'จำนวนสินค้า',b.unit_name 'หน่วยนับ',prod_capacity 'ปริมาตร',c.unit_name 'หน่วยนับปริมาตร' from product a(nolock) join unit b(nolock) on a.unit_id = b.unit_id join unit c on a.unit_id_cap = c.unit_id join product_type d on a.prod_type_id = d.prod_type_id  where (prod_qty - prod_leadtime) between (prod_leadtime * -1) and 2 order by prod_id"
        GetDataToGrid(leadtimeproductsql, form_home.grid_alertproduct)
        form_home.Enabled = True
    End Sub 'Form1_Closing
    Private Sub UpdateDatainGrid(ByVal index As Integer)
        Dim sqlqueryeachtab(3) As String
        sqlqueryeachtab(0) = "select order_id 'รหัสการสั่งซื้อ',convert(varchar(10),order_date,103) 'วันที่สั่งซื้อ', sup_companyname 'ชื่อบริษัท' , sub_name 'ชื่อผู้ติดต่อ' , c.emp_fullname 'พนักงานที่ทำรายการสั่งซื้อ' from product_order as a join supplier as b on a.sup_id = b.sup_id join employee as c on a.emp_id = c.emp_id order by order_date desc,order_id desc"

        Dim havedropdown(,) As String =
        {
            {"0", "select sup_id ID,sup_companyname Name from supplier order by sup_id", "0"},
            {"0", "select prod_type_id 'ID' ,prod_type_name 'Name'  from product_type order by prod_type_id", "1"}
        }
        Dim mygrid() As DataGridView = {grid_orderresult}
        Dim mycombobox() As ComboBox = {
            cbo_ordersupplier, cbo_orderproducttype
        }
        For i As Integer = 0 To havedropdown.GetLength(0) - 1
            If (index.ToString() = havedropdown(i, 0)) Then
                GetDatatoCombobox(havedropdown(i, 1), mycombobox(Integer.Parse(havedropdown(i, 2))))
            End If
        Next
        GetDataToGrid(sqlqueryeachtab(index), mygrid(index))

    End Sub
    Private Sub clearData(ByVal index)
        If index = 0 Then
            txt_orderid.Text = ""
            txt_orderprod.Text = ""
            cbo_ordersupplier.SelectedIndex = 0
            dtp_orderdate.Value = Date.Now
            grid_showorderprod.Rows.Clear()
            btn_addorder.Visible = True
            btn_editorder.Visible = False
            btn_delorder.Visible = False
            btn_orderreport.Visible = False
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

    Private Sub btn_searchproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchproduct.Click
        form_showproduct.Show()
    End Sub

    Private Sub btn_delproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delproduct.Click
        Dim totalproduct = grid_showorderprod.Rows.Count - 1
        While (totalproduct >= 0)
            grid_showorderprod.Rows(totalproduct).Cells(0).Value = True
            totalproduct -= 1
        End While
    End Sub

    Private Sub grid_showorderprod_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim rowindex As Integer = grid_showorderprod.CurrentRow.Index
        If grid_showorderprod.Rows(rowindex).Cells(1).Value = Nothing Then

        End If
    End Sub

    Private Sub cbo_searchorder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchorder.SelectedIndexChanged
        If cbo_searchorder.SelectedIndex = 0 Then
            txt_searchorder.Text = ""
        End If
    End Sub


    Private Sub btn_orderreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_orderreport.Click, btn_orderreport.Click
        Dim crConnectionInfo As New ConnectionInfo()
        Dim cryRpt As New ReportDocument
        Dim orderid As String = txt_orderid.Text
        Dim foldername As String = dtp_orderdate.Value.ToString("yyyyMMdd").Substring(0, 6)
        If (Not System.IO.Directory.Exists("D:\AispaReport")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Order_Report")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Order_Report")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Order_Report\" & foldername)) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Order_Report\" & foldername)
        End If

        Dim filename As String = "ใบสั่งซื้อผลิตภัณฑ์_" & dtp_orderdate.Value.ToString("yyyyMMdd") & ".PDF"
        Dim fullfilename As String = "D:\AispaReport\Order_Report\" & foldername & "\" & filename
        If orderid <> "" Then
            Dim report As orderproduct = New orderproduct

            report.SetDatabaseLogon("sa", "P@ssw0rd", "aispa", "aispa")
            report.SetParameterValue("@order_id", orderid)
            Try
                report.ExportToDisk(ExportFormatType.PortableDocFormat, fullfilename)
            Catch ex As Exception

            End Try
            System.Diagnostics.Process.Start(fullfilename)
        End If
        'orderreport.Show()
    End Sub

    Private Sub cbo_orderproducttype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_orderproducttype.SelectedIndexChanged
        productype = cbo_orderproducttype.SelectedValue
    End Sub
End Class