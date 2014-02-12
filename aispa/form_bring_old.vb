Imports aispa.classquery
Public Class form_bring_old
    Dim Obj_query As New classquery()
    Dim sql As String
    Dim datatable As New DataTable
    Dim selectedIndex As Integer
    Dim plus_colume As Integer = 0
    Dim myindexsearchby As Integer = 0
    Dim prodindex As Integer = 0
    Dim product As ArrayList = New ArrayList
    Dim prodtype_id As Integer
    Dim pickid As String

    Private Sub form_bring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectedIndex = 0
        UpdateProduct(selectedIndex)
    End Sub
    Private Sub form_bring_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        form_home.Enabled = True
    End Sub 'Form1_Closing
    Private Sub tab_management_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_management.Click
        selectedIndex = tab_management.SelectedIndex
        UpdateProduct(selectedIndex)
        If selectedIndex = 1 Then
            sql = "select ROW_NUMBER() OVER(ORDER BY a.prod_id ) AS 'ลำดับ',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',prod_capacity + ' ' + c.unit_name 'ปริมาตร',d.prod_type_name 'ประเภท', a.prod_qty 'คงเหลือ',a.prod_leadtime 'จุดสั่งซื้อ',b.unit_name 'หน่วยนับ' from product a(nolock) " &
                    " join unit b(nolock) on a.unit_id = b.unit_id " &
                    " join unit c(nolock) on a.unit_id_cap = c.unit_id " &
                    " join product_type d(nolock) on a.prod_type_id = d.prod_type_id " &
                    " order by a.prod_id "
            GetDataToGrid(sql, grid_showstockproduct)
        End If
    End Sub
    Private Sub UpdateProduct(ByVal index As Integer)
        sql = "select pick_id 'รหัสการเบิก',pick_date 'วันที่เบิก' from picking order by pick_id desc"
        Dim havedropdown(,) As String =
        {
            {"0", "select prod_type_id ID,prod_type_name Name from product_type order by prod_type_id", "0"},
            {"0", "select emp_id ID,emp_fullname Name from employee(nolock) order by emp_id", "1"}
        }
        GetDataToGrid(sql, grid_showbring)
        Dim mycombobox() As ComboBox = {
            cbo_prodtype, cbo_searchbyemp
        }
        For i As Integer = 0 To havedropdown.GetLength(0) - 1
            If (index.ToString() = havedropdown(i, 0)) Then
                GetDatatoCombobox(havedropdown(i, 1), mycombobox(Integer.Parse(havedropdown(i, 2))))
            End If
        Next
    End Sub
    Private Sub GetDatatoCombobox(ByVal mysql As String, ByVal mycombobox As ComboBox)
        sql = mysql
        datatable = Obj_query.selectDatatoGrid(sql)
        mycombobox.ValueMember = "ID"
        mycombobox.DisplayMember = "Name"
        mycombobox.DataSource = datatable
    End Sub

    Private Sub cbo_prodtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_prodtype.SelectedIndexChanged
        prodtype_id = cbo_prodtype.SelectedValue
        getproductlist()
    End Sub
    Private Sub getproductlist()
        Dim sqlquery() As String =
        {
            " select prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',a.prod_capacity + ' ' + b.unit_name 'ปริมาตร',prod_qty 'คงเหลือ',prod_id from product a(nolock) " &
            " join unit b(nolock) on a.unit_id_cap = b.unit_id where prod_type_id = " & prodtype_id
        }
        Dim grid_orderrecieve() As DataGridView = {grid_showproduct}

        GetDataToGrid(sqlquery(0), grid_orderrecieve(0)) ' SHow Product when choose product type
        grid_orderrecieve(0).Columns(4).Visible = False ' ไม่แสดง prod_id
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

    Private Sub grid_showproduct_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showproduct.CellClick
        Dim rowindex As Integer = grid_showproduct.CurrentRow.Index
        Dim prodid As String = grid_showproduct.Rows(rowindex).Cells(4).Value.ToString()
        Dim prodname As String = grid_showproduct.Rows(rowindex).Cells(0).Value.ToString()
        Dim prodbrand As String = grid_showproduct.Rows(rowindex).Cells(1).Value.ToString()
        Dim cap As String = grid_showproduct.Rows(rowindex).Cells(2).Value.ToString()
        If product.Count > 0 Then
            For Each p As String() In product
                If p(4) = prodid Then
                    Exit Sub
                End If
            Next
        End If
        Dim prod As String() = {prodname, prodbrand, cap, "1", prodid, ""}
        product.Add(prod)
        setProducttoGrid()
    End Sub
    Private Sub setProducttoGrid()
        clear_grid(grid_bringprod)
        grid_bringprod.ColumnCount = 6

        grid_bringprod.Columns(0).Name = "ชื่อผลิตภัณฑ์"
        grid_bringprod.Columns(1).Name = "ยี่ห้อ"
        grid_bringprod.Columns(2).Name = "ปริมาตร"
        grid_bringprod.Columns(3).Name = "จำนวนที่เบิก"
        grid_bringprod.Columns(4).Name = "prodid"
        grid_bringprod.Columns(5).Name = "depickid"
        For Each p As String() In product
            grid_bringprod.Rows.Add(p)
        Next
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.Name = "ลบรายการ"
        grid_bringprod.Columns.Insert(0, chk)
        setReadonlyGrid(grid_bringprod)
    End Sub
    Private Sub setReadonlyGrid(ByVal mygrid As DataGridView)
        For i As Integer = 0 To mygrid.Columns.Count - 1
            If ((i <> 0 And i <> 4)) Then
                mygrid.Columns(i).ReadOnly = True
            End If
            If i = 5 Or i = 6 Then
                mygrid.Columns(i).Visible = False
            End If
        Next
    End Sub
    Private Sub setReadonlyGrid2(ByVal mygrid As DataGridView)
        For i As Integer = 0 To mygrid.Columns.Count - 1
            If ((i <> 0 And i <> 7)) Then
                mygrid.Columns(i).ReadOnly = True
            End If
            If i = 9 Then
                mygrid.Columns(i).Visible = False
            End If
        Next
    End Sub
    Private Sub clear_grid(ByVal mygrid As DataGridView)
        mygrid.DataSource = Nothing
        mygrid.Columns.Clear()
        mygrid.Refresh()
        mygrid.RefreshEdit()
    End Sub

    Private Sub btn_addbring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addbring.Click
        If product.Count > 0 Then
            sql = "insert into picking values (GETDATE()," & module_emp_id & ")"
            If (Obj_query.DMLData(sql)) Then
                sql = "declare @lastid as integer = IDENT_CURRENT('picking')"
                For Each row As DataGridViewRow In grid_bringprod.Rows
                    Dim pid As String = row.Cells(5).Value.ToString()
                    Dim qty As Integer
                    Dim chkqty As String = "select prod_qty from product where prod_id = " & pid
                    Dim qtyinstock As Integer = Obj_query.selectdataInt(chkqty)
                    If Integer.TryParse(row.Cells(4).Value.ToString(), qty) And qty > 0 And qty <= qtyinstock Then
                        sql &= "insert into picking_detail values (" & qty & " , @lastid , " & pid & ")"
                    Else
                        If qty > qtyinstock Then
                            sql &= " delete from picking where pick_id = @lastid "
                            If (Obj_query.DMLData(sql)) Then
                                MsgBox("ผลิตภัณฑ์คงเหลือไม่เพียงพอ กรุณาทำรายการใหม่")
                            End If
                        Else
                            MsgBox("กรอกข้อมูลไม่ถูกต้องกรุณาตรวจสอบ")
                        End If
                        Exit Sub
                    End If
                Next
                If (Obj_query.DMLData(sql)) Then
                    MsgBox("เพิ่มรายการการเบิกผลิตภัณฑ์เรียบร้อยแล้ว")
                    clear_grid(grid_bringprod)
                    product.Clear()
                    getproductlist()
                    UpdateProduct(selectedIndex)
                End If
            End If
        Else
            MsgBox("กรุณาเลือกผลิตภัณฑ์ที่จะเบิก")
        End If
    End Sub
    Private Sub btn_delbring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delbring.Click
        sql = ""
        Dim countdel As Integer = 0
        For Each row As DataGridViewRow In grid_bringprod.Rows
            If row.Cells(0).Value = True Then
                Dim rowindex As Integer = row.Selected
                Dim delpickid As String = row.Cells(6).Value.ToString()
                grid_bringprod.Rows.RemoveAt(rowindex)
                product.RemoveAt(rowindex)
                If delpickid <> "" Then
                    sql &= " delete from picking_detail where depick_id = " & delpickid
                    countdel += 1
                End If
            End If
        Next
        Dim chksql = "select count(*) from picking where pick_id = " & pickid
        Dim countmydata = Obj_query.selectdataInt(chksql)
        If countdel = countmydata And countmydata > 0 Then
            sql &= " delete from picking where pick_id = " & pickid
        End If
        If sql <> "" Then
            If Obj_query.DMLData(sql) Then
                MsgBox("ทำการลบรายการเรียบร้อยแล้ว")
                setProducttoGrid()
                updateshowpicking()
                getproductlist()
                UpdateProduct(selectedIndex)
            End If
        End If
    End Sub

    Private Sub cbo_searchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchby.SelectedIndexChanged
        Dim rowindex = cbo_searchby.SelectedIndex
        If rowindex = 0 Then
            lbl_seachbyemp.Visible = False
            cbo_searchbyemp.Visible = False
            lbl_searchbydate.Visible = False
            dtp_searchbydate.Visible = False
        ElseIf rowindex = 1 Then
            lbl_seachbyemp.Visible = True
            cbo_searchbyemp.Visible = True
            lbl_searchbydate.Visible = False
            dtp_searchbydate.Visible = False
        ElseIf rowindex = 2 Then
            lbl_searchbydate.Visible = True
            dtp_searchbydate.Visible = True
            lbl_seachbyemp.Visible = False
            cbo_searchbyemp.Visible = False
        End If
    End Sub

    Private Sub btn_searchmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchmember.Click
        updateshowpicking()
    End Sub
    Private Sub updateshowpicking()
        Dim rowindex = cbo_searchby.SelectedIndex
        If rowindex = 0 Then
            sql = "select pick_id 'รหัสการเบิก',pick_date 'วันที่เบิก' from picking order by pick_id desc"
        ElseIf rowindex = 1 Then
            Dim empid As String = cbo_searchbyemp.SelectedValue.ToString()
            sql = "select pick_id 'รหัสการเบิก',pick_date 'วันที่เบิก' from picking " &
                  " where emp_id = " & empid & " order by pick_id desc"
        ElseIf rowindex = 2 Then
            Dim searchdate As String = dtp_searchbydate.Value.ToString("yyyyMMdd")
            sql = "select pick_id 'รหัสการเบิก',pick_date 'วันที่เบิก' from picking " &
                  " where convert(varchar(8),pick_date,112) = '" & searchdate & "' order by pick_id desc"
        End If
        If rowindex > -1 Then
            GetDataToGrid(sql, grid_showbring)
        End If

    End Sub
    Private Sub grid_showbring_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showbring.CellClick
        btn_addbring.Visible = False
        btn_delbring.Visible = True
        btn_editbring.Visible = True
        Dim rowindex = grid_showbring.CurrentRow.Index
        pickid = grid_showbring.Rows(rowindex).Cells(0).Value.ToString()
        sql = "select prod_name,prod_brand,prod_capacity+' '+d.unit_name,b.depick_qty,c.prod_id,b.depick_id from picking a(nolock) " &
                  " join picking_detail b(nolock) on a.pick_id = b.pick_id " &
                  " join product c(nolock) on b.prod_id = c.prod_id " &
                  " join unit d(nolock) on c.unit_id_cap = d.unit_id " &
                  " where a.pick_id = " & pickid & "order by a.pick_id desc"
        product = Obj_query.selectdatatoarraylist(sql)
        setProducttoGrid()
    End Sub

    Private Sub btn_resetbring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetbring.Click
        btn_addbring.Visible = True
        btn_editbring.Visible = False
        product.Clear()
        clear_grid(grid_bringprod)
    End Sub

    Private Sub btn_editbring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editbring.Click
        sql = ""
        For r As Integer = 0 To grid_bringprod.Rows.Count - 1
            Dim row As DataGridViewRow = grid_bringprod.Rows(r)
            Dim depickid As String = row.Cells(6).Value.ToString()
            Dim pid As String = row.Cells(5).Value.ToString()
            Dim qty As Integer
            Dim chkqty As String = "select prod_qty from product where prod_id = " & pid
            Dim qtyinstock As Integer = Obj_query.selectdataInt(chkqty)
            Dim chksql As String = "select count(*) from picking_detail where depick_id = " & depickid & " and prod_id = " & pid
            sql = "update picking set emp_id = " & module_emp_id & " where pick_id = " & pickid
            If Obj_query.selectdataInt(chksql) <= 0 Or depickid = "" Then
                If Integer.TryParse(row.Cells(4).Value.ToString(), qty) And qty > 0 And qty <= qtyinstock Then
                    sql &= " insert into picking_detail values (" & qty & " ," & pickid & " , " & pid & ")"
                Else
                    MsgBox("กรอกข้อมูลไม่ถูกต้องกรุณาตรวจสอบ หรือ ผลิตภัณฑ์คงเหลือไม่เพียงพอ")
                    Exit Sub
                End If
            Else
                If Integer.TryParse(row.Cells(4).Value.ToString(), qty) And qty > 0 And qty <= qtyinstock Then
                    sql &= " update picking_detail set depick_qty = " & qty & " where prod_id = " & pid &
                        " and depick_id = " & depickid
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
        If (Obj_query.DMLData(sql)) Then
            MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
            sql = "select prod_name,prod_brand,prod_capacity+' '+d.unit_name,b.depick_qty,c.prod_id,b.depick_id from picking a(nolock) " &
                " join picking_detail b(nolock) on a.pick_id = b.pick_id " &
                " join product c(nolock) on b.prod_id = c.prod_id " &
                " join unit d(nolock) on c.unit_id_cap = d.unit_id " &
                " where a.pick_id = " & pickid & "order by a.pick_id desc"
            product = Obj_query.selectdatatoarraylist(sql)
            setProducttoGrid()
            updateshowpicking()
            getproductlist()
            UpdateProduct(selectedIndex)
        End If
    End Sub

    Private Sub btn_searchprods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchprods.Click
        Dim dropdownindex As Integer = cbo_searchprods.SelectedIndex
        Dim textsearch As String = txt_searchprods.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0 Or dropdownindex = 1) Then
            If dropdownindex = 0 Then
                sql = "select ROW_NUMBER() OVER(ORDER BY a.prod_id ) AS 'ลำดับ',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',prod_capacity + ' ' + c.unit_name 'ปริมาตร',d.prod_type_name 'ประเภท', a.prod_qty 'คงเหลือ',a.prod_leadtime 'จุดสั่งซื้อ',b.unit_name 'หน่วยนับ' from product a(nolock) " &
                    " join unit b(nolock) on a.unit_id = b.unit_id " &
                    " join unit c(nolock) on a.unit_id_cap = c.unit_id " &
                    " join product_type d(nolock) on a.prod_type_id = d.prod_type_id " &
                    " order by a.prod_id "
            ElseIf dropdownindex = 1 Then
                sql = "select ROW_NUMBER() OVER(ORDER BY a.prod_id ) AS 'ลำดับ',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',prod_capacity + ' ' + c.unit_name 'ปริมาตร',d.prod_type_name 'ประเภท', a.prod_qty 'คงเหลือ',a.prod_leadtime 'จุดสั่งซื้อ',b.unit_name 'หน่วยนับ' from product a(nolock) " &
                    " join unit b(nolock) on a.unit_id = b.unit_id " &
                    " join unit c(nolock) on a.unit_id_cap = c.unit_id " &
                    " join product_type d(nolock) on a.prod_type_id = d.prod_type_id " &
                    " where (prod_qty - prod_leadtime) between (prod_leadtime * -1) and 2 " &
                    " order by a.prod_id "
            ElseIf dropdownindex = 2 Then
                sql = "select ROW_NUMBER() OVER(ORDER BY a.prod_id ) AS 'ลำดับ',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',prod_capacity + ' ' + c.unit_name 'ปริมาตร',d.prod_type_name 'ประเภท', a.prod_qty 'คงเหลือ',a.prod_leadtime 'จุดสั่งซื้อ',b.unit_name 'หน่วยนับ' from product a(nolock) " &
                    " join unit b(nolock) on a.unit_id = b.unit_id " &
                    " join unit c(nolock) on a.unit_id_cap = c.unit_id " &
                    " join product_type d(nolock) on a.prod_type_id = d.prod_type_id " &
                    " where d.prod_type_name like '" & textsearch & "%' or d.prod_type_name like '%" & textsearch & "%' or d.prod_type_name like '%" & textsearch & "' " &
                    " order by a.prod_id "
            ElseIf dropdownindex = 3 Then
                sql = "select ROW_NUMBER() OVER(ORDER BY a.prod_id ) AS 'ลำดับ',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',prod_capacity + ' ' + c.unit_name 'ปริมาตร',d.prod_type_name 'ประเภท', a.prod_qty 'คงเหลือ',a.prod_leadtime 'จุดสั่งซื้อ',b.unit_name 'หน่วยนับ' from product a(nolock) " &
                    " join unit b(nolock) on a.unit_id = b.unit_id " &
                    " join unit c(nolock) on a.unit_id_cap = c.unit_id " &
                    " join product_type d(nolock) on a.prod_type_id = d.prod_type_id " &
                    " where a.prod_name like '" & textsearch & "%' or a.prod_name like '%" & textsearch & "%' or a.prod_name like '%" & textsearch & "' " &
                    " order by a.prod_id "
            End If
            GetDataToGrid(sql, grid_showstockproduct)
        End If
    End Sub


    Private Sub grid_bringprod_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_bringprod.CellEndEdit
        Dim rowindex As Integer = grid_bringprod.CurrentRow.Index
        Dim editproduct As String() = product(rowindex)
        editproduct(3) = grid_bringprod.Rows(rowindex).Cells(4).Value.ToString()
        product(rowindex) = editproduct
    End Sub
End Class