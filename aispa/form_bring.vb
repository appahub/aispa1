Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_bring
    Public Obj_query As New classquery()
    Dim sql As String
    Dim datatable As New DataTable
    Dim selectedIndex As Integer
#Region "bring"
    Private Sub btn_addbring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addbring.Click
        Dim bringdate As String = dtp_bringdate.Value.ToString("yyyy-MM-dd HH:MM")
        Dim emp_id As Integer = module_emp_id
        Dim datetomorow As Integer = Integer.Parse(Date.Now().ToString("yyyyMMdd"))
        Dim datecurrent As Integer = Integer.Parse(dtp_bringdate.Value.ToString("yyyyMMdd"))
        Dim emp_pick_id As String = txt_pickempid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการบันทึกรายการเบิกนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If (grid_showbringprod.Rows.Count > 0 And bringdate <> "" And emp_id > 0 And datecurrent <= datetomorow) Then
                If grid_showbringprod.Rows.Count > 0 Then
                    For i As Integer = 0 To grid_showbringprod.Rows.Count - 1
                        If grid_showbringprod.Rows(i).Cells(1).Value <> "" And grid_showbringprod.Rows(i).Cells(3).Value = "" Then
                            MsgBox("ไม่ได้ระบุจำนวน")
                            Exit Sub
                        End If
                    Next
                End If
                sql = "insert into picking values (GETDATE()," & module_emp_id & "," & emp_pick_id & ")"
                If (Obj_query.DMLData(sql)) Then
                    sql = "declare @lastid as integer = IDENT_CURRENT('picking')"
                    For Each row As DataGridViewRow In grid_showbringprod.Rows
                        Dim prod_id As String = row.Cells(8).Value
                        Dim prod_qty As String = row.Cells(3).Value
                        Dim qty As Integer
                        Dim chkqty As String = "select prod_qty from product where prod_id = " & prod_id
                        Dim qtyinstock As Integer = Obj_query.selectdataInt(chkqty)
                        If Integer.TryParse(prod_qty, qty) And qty > 0 And qty <= qtyinstock Then
                            sql &= "insert into picking_detail values (" & qty & " , @lastid , " & prod_id & ")"
                        Else
                            sql &= " delete from picking where pick_id = @lastid "
                            If (Obj_query.DMLData(sql)) Then
                                MsgBox("ผลิตภัณฑ์คงเหลือไม่เพียงพอ กรุณาทำรายการใหม่")
                            End If
                            Exit Sub
                        End If
                    Next
                    If (Obj_query.DMLData(sql)) Then
                        MsgBox("เพิ่มข้อมูลการเบิกเรียบร้อยแล้ว")
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

    Private Sub btn_editbring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editbring.Click
        Dim bringid As String = txt_bringid.Text
        Dim bringdate As String = dtp_bringdate.Value.ToString("yyyy-MM-dd HH:MM")
        Dim emp_id As Integer = module_emp_id
        Dim emp_pick_id As String = txt_pickempid.Text
        Dim datetomorow As Integer = Integer.Parse(Date.Now().ToString("yyyyMMdd"))
        Dim datecurrent As Integer = Integer.Parse(dtp_bringdate.Value.ToString("yyyyMMdd"))
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการแก้ไขรายการเบิกนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If (bringid <> "" And grid_showbringprod.Rows.Count > 0 And bringdate <> "" And emp_id > 0 And datecurrent <= datetomorow) Then
                If grid_showbringprod.Rows.Count > 0 Then
                    For i As Integer = 0 To grid_showbringprod.Rows.Count - 1
                        If grid_showbringprod.Rows(i).Cells(1).Value <> "" And grid_showbringprod.Rows(i).Cells(3).Value = "" Then
                            MsgBox("ไม่ได้ระบุจำนวนเบิก")
                            Exit Sub
                        End If
                    Next
                End If
                sql = ""
                For r As Integer = 0 To grid_showbringprod.Rows.Count - 1
                    Dim row As DataGridViewRow = grid_showbringprod.Rows(r)
                    Dim depickid As String = row.Cells(9).Value.ToString()
                    Dim pid As String = row.Cells(8).Value.ToString()
                    Dim prod_qty As String = row.Cells(3).Value
                    Dim qty As Integer
                    Dim chkqty As String = "select prod_qty from product where prod_id = " & pid
                    Dim qtyinstock As Integer = Obj_query.selectdataInt(chkqty)
                    Dim chksql As String = "select count(*) from picking_detail where depick_id = " & depickid & " and prod_id = " & pid
                    sql = "update picking set emp_id = " & module_emp_id & ",pick_date='" & bringdate & "',emp_id_pick = " & emp_pick_id & " where pick_id = " & bringid
                    If Obj_query.selectdataInt(chksql) <= 0 Or depickid = "" Then
                        If Integer.TryParse(prod_qty, qty) And qty > 0 And qty <= qtyinstock Then
                            sql &= " insert into picking_detail values (" & qty & " ," & bringid & " , " & pid & ")"
                        Else
                            MsgBox("กรอกข้อมูลไม่ถูกต้องกรุณาตรวจสอบ หรือ ผลิตภัณฑ์คงเหลือไม่เพียงพอ")
                            Exit Sub
                        End If
                    Else
                        If Integer.TryParse(prod_qty, qty) And qty > 0 And qty <= qtyinstock Then
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

                    If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขการเบิกเรียบร้อยแล้ว")
                    Else
                        MsgBox("มีบางข้อมูลอาจจะ แก้ไขไม่ได้ กรุณาตรวจสอบ")
                    End If

                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
            Else
                MsgBox("กรุณากรอกข้อมูลให้ครบ")
            End If
        End If
    End Sub

    Private Sub btn_delbring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delbring.Click
        Dim bringid As String = txt_bringid.Text
        Dim emp_id As Integer = module_emp_id
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการเบิกนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim deldetailsuccess = False
        If answer = vbYes Then
            If (bringid <> "") Then
                If grid_showbringprod.Rows.Count > 0 Then
                    Dim totalproduct = grid_showbringprod.Rows.Count - 1
                    While (totalproduct >= 0)
                        Dim detailbringid As String = grid_showbringprod.Rows(totalproduct).Cells(9).Value
                        If grid_showbringprod.Rows(totalproduct).Cells(0).Value = True Then
                            sql &= " delete from picking_detail where depick_id = " & detailbringid
                            grid_showbringprod.Rows.RemoveAt(totalproduct)
                        End If
                        totalproduct -= 1
                    End While
                End If
                If grid_showbringprod.Rows.Count = 0 Then
                    sql &= " delete from picking_detail where depick_id = " & bringid

                    sql &= " delete from picking where pick_id = " & bringid
                    clearData(selectedIndex)
                End If

                If Obj_query.DMLData(sql) Then
                    MsgBox("ลบการเบิกเรียบร้อยแล้ว")
                Else
                    MsgBox("มีบางข้อมูลอาจจะ ลบไม่ได้ กรุณาตรวจสอบ หรือ ข้อมูลอาจจะมีการใช้งานอยู่")
                End If
            Else
                MsgBox("ข้อมูลบาง field ไม่ถูกต้อง")
            End If
        End If
        UpdateDatainGrid(selectedIndex)

    End Sub

    Private Sub btn_resetbring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetbring.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchbring.Click
        Dim dropdownindex As Integer = cbo_searchbring.SelectedIndex
        Dim textsearch As String = txt_searchbring.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select pick_id 'รหัสการเบิก',convert(varchar(10),pick_date,103) 'วันที่เบิก', c.emp_fullname 'พนักงานที่ทำรายการเบิก',d.emp_fullname 'พนักงานที่เบิก',d.emp_id from picking as a join employee as c on a.emp_id = c.emp_id join employee d on a.emp_id_pick = d.emp_id where convert(varchar(10),pick_date,103) = '" & textsearch & "' order by pick_id desc"
            ElseIf dropdownindex = 2 Then
                sql = "select pick_id 'รหัสการเบิก',convert(varchar(10),pick_date,103) 'วันที่เบิก', c.emp_fullname 'พนักงานที่ทำรายการเบิก',d.emp_fullname 'พนักงานที่เบิก',d.emp_id from picking as a join employee as c on a.emp_id = c.emp_id join employee d on a.emp_id_pick = d.emp_id where c.emp_fullname like '" & textsearch & "%' or c.emp_fullname like '%" & textsearch & "%' or c.emp_fullname like '%" & textsearch & "'   order by pick_id desc"
            End If
            GetDataToGrid(sql, grid_bringresult)
        End If
    End Sub
    Private Sub grid_bringresult_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_bringresult.CellClick
        Dim rowindex As Integer = grid_bringresult.CurrentRow.Index
        If grid_bringresult.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_bringid.Text = grid_bringresult.Rows(rowindex).Cells(0).Value
            dtp_bringdate.Value = grid_bringresult.Rows(rowindex).Cells(1).Value
            txt_pickempname.Text = grid_bringresult.Rows(rowindex).Cells(3).Value
            txt_pickempid.Text = grid_bringresult.Rows(rowindex).Cells(4).Value
            grid_showbringprod.Rows.Clear()
            sql = "select a.depick_id ID,b.prod_name Name,b.prod_brand,b.prod_capacity,a.depick_qty,c.unit_name,convert(varchar,prod_price,1) 'price',b.prod_id,d.unit_name,e.prod_type_name from picking_detail as a join product as b on a.prod_id = b.prod_id join unit c on b.unit_id = c.unit_id join unit d on b.unit_id_cap = d.unit_id join product_type e on b.prod_type_id = e.prod_type_id  where pick_id = " & grid_bringresult.Rows(rowindex).Cells(0).Value & " order by a.depick_id"
            datatable = Obj_query.selectDatatoGrid(sql)
            For i As Integer = 0 To datatable.Rows.Count - 1
                Dim row As String() = New String() {False, (i + 1), datatable.Rows(i)(1), datatable.Rows(i)(4), datatable.Rows(i)(5), datatable.Rows(i)(6), datatable.Rows(i)(2), datatable.Rows(i)(3), datatable.Rows(i)(7), datatable.Rows(i)(0), datatable.Rows(i)(8), datatable.Rows(i)(9)}
                grid_showbringprod.Rows.Add(row)
                Dim chk As New DataGridViewCheckBoxColumn()

                If (grid_showbringprod.Columns.Count < 10) Then
                    grid_showbringprod.Columns.Add(chk)
                    chk.Name = "ลบรายการ"
                End If
            Next
            btn_bringreport.Visible = True
            btn_addbring.Visible = False
            btn_editbring.Visible = True
            btn_delbring.Visible = True
        End If
    End Sub
#End Region
    Private Sub form_bring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectedIndex = 0
        UpdateDatainGrid(0)
        currentgrid = grid_showbringprod
        currentprodname = txt_bringprod
    End Sub
    Private Sub form_bring_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim leadtimeproductsql As String = "select prod_id 'รหัส',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',d.prod_type_name 'ประเภทสินค้า',convert(varchar,prod_price,1) 'ราคาสินค้า','บาท' 'หน่วยนับ',a.prod_qty 'จำนวนสินค้า',b.unit_name 'หน่วยนับ',prod_capacity 'ปริมาตร',c.unit_name 'หน่วยนับปริมาตร' from product a(nolock) join unit b(nolock) on a.unit_id = b.unit_id join unit c on a.unit_id_cap = c.unit_id join product_type d on a.prod_type_id = d.prod_type_id  where (prod_qty - prod_leadtime) between (prod_leadtime * -1) and 2 order by prod_id"
        GetDataToGrid(leadtimeproductsql, form_home.grid_alertproduct)
        form_home.Enabled = True
    End Sub 'Form1_Closing
    Private Sub UpdateDatainGrid(ByVal index As Integer)
        Dim sqlqueryeachtab(3) As String
        sqlqueryeachtab(0) = "select pick_id 'รหัสการเบิก',convert(varchar(10),pick_date,103) 'วันที่เบิก', c.emp_fullname 'พนักงานที่ทำรายการเบิก',d.emp_fullname 'พนักงานที่เบิก',d.emp_id from picking as a join employee as c on a.emp_id = c.emp_id join employee d on a.emp_id_pick = d.emp_id order by pick_id desc"

        Dim havedropdown(,) As String =
        {
            {"0", "select prod_type_id 'ID' ,prod_type_name 'Name'  from product_type order by prod_type_id", "0"}
        }
        Dim mygrid() As DataGridView = {grid_bringresult}
        Dim mycombobox() As ComboBox = {
            cbo_bringproducttype
        }
        For i As Integer = 0 To havedropdown.GetLength(0) - 1
            If (index.ToString() = havedropdown(i, 0)) Then
                GetDatatoCombobox(havedropdown(i, 1), mycombobox(Integer.Parse(havedropdown(i, 2))))
            End If
        Next
        GetDataToGrid(sqlqueryeachtab(index), mygrid(index))
        grid_bringresult.Columns(4).Visible = False

    End Sub
    Private Sub clearData(ByVal index)
        If index = 0 Then
            txt_bringid.Text = ""
            txt_bringprod.Text = ""
            dtp_bringdate.Value = Date.Now
            grid_showbringprod.Rows.Clear()
            btn_addbring.Visible = True
            btn_editbring.Visible = False
            btn_delbring.Visible = False
            btn_bringreport.Visible = False
            txt_pickempid.Text = ""
            txt_pickempname.Text = ""
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

    Private Sub btn_searchproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchproductbring.Click
        form_showproduct.Show()
    End Sub

    Private Sub btn_delproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delproductbring.Click
        Dim totalproduct = grid_showbringprod.Rows.Count - 1
        While (totalproduct >= 0)
            grid_showbringprod.Rows(totalproduct).Cells(0).Value = True
            totalproduct -= 1
        End While
    End Sub

    Private Sub grid_showbringprod_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim rowindex As Integer = grid_showbringprod.CurrentRow.Index
        If grid_showbringprod.Rows(rowindex).Cells(1).Value = Nothing Then

        End If
    End Sub

    Private Sub cbo_searchbring_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchbring.SelectedIndexChanged
        If cbo_searchbring.SelectedIndex = 0 Then
            txt_searchbring.Text = ""
        End If
    End Sub


    Private Sub btn_bringreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bringreport.Click
        'bringreport.Show()
    End Sub

    Private Sub cbo_bringproducttype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_bringproducttype.SelectedIndexChanged
        productype = cbo_bringproducttype.SelectedValue
    End Sub

    Private Sub btn_searchmempick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchmempick.Click
        getEmployeeformpage = 9
        form_showEmployee.Show()
    End Sub

    Private Sub grid_bringresult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_bringresult.CellContentClick

    End Sub
End Class