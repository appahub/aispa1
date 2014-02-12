Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_genaral
    Dim Obj_query As New classquery()
    Dim sql As String
    Dim datatable As New DataTable
    Dim selectedIndex As Integer

#Region "tab_service"
    Private Sub btn_addservice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addservice.Click
        Dim servname As String = txt_servicename.Text
        Dim servtype As Integer = cbo_serviceservtype.SelectedValue
        Dim servprice As Double = 0.0
        If servname <> "" And servtype > 0 And Double.TryParse(txt_serviceprice.Text, servprice) Then
            Try
                sql = " insert into service_list " &
               " (liserv_name,liserv_price,liserv_type_id) " &
               " values('" & servname & "'," & servprice & " , " & servtype & " )"
                If Obj_query.DMLData(sql) Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
            
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_editservice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editservice.Click
        Dim servid As String = txt_serviceid.Text
        Dim servname As String = txt_servicename.Text
        Dim servtype As Integer = cbo_serviceservtype.SelectedValue
        Dim servprice As Double = 0.0
        If servname <> "" And servtype > 0 And Double.TryParse(txt_serviceprice.Text, servprice) Then
            Try
                sql =
               " update service_list set " &
               " liserv_name = '" & servname & "',liserv_price = '" & servprice & "',liserv_type_id = " & servtype &
                " where liserv_id = " & servid
                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
            
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_delservice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delservice.Click
        Dim servid As String = txt_serviceid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการบริการนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If servid <> "" Then
                Try
                    sql =
                   " delete from service_list " &
                   " where liserv_id = " & servid
                    If Obj_query.DMLData(sql) Then
                        MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
                        UpdateDatainGrid(selectedIndex)
                        clearData(selectedIndex)
                    Else
                        MsgBox("ไม่สามารถลบข้อมูลนี้ได้ เพราะมีการใช้ข้อมูลอยู่")
                    End If
                Catch ex As Exception
                    MsgBox("ไม่สามารถลบข้อมูลนี้ได้")
                End Try

            Else
                MsgBox("ข้อมูลบาง field ไม่ถูกต้อง")
            End If
        End If
    End Sub

    Private Sub btn_resetservice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetservice.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchservice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchservice.Click
        Dim dropdownindex As Integer = cbo_searchservice.SelectedIndex
        Dim textsearch As String = txt_searchservice.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select liserv_id 'รหัสรายการบริการ',liserv_name 'ชื่อรายการบริการ',convert(varchar,liserv_price,1) 'ราคา' , b.liserv_type_name 'ประเภทรายการบริการ' from service_list(nolock) as a join service_list_type(nolock) as b on a.liserv_type_id = b.liserv_type_id where liserv_id=" & textsearch & " order by liserv_id"
            ElseIf dropdownindex = 2 Then
                sql = "select liserv_id 'รหัสรายการบริการ',liserv_name 'ชื่อรายการบริการ',convert(varchar,liserv_price,1) 'ราคา' , b.liserv_type_name 'ประเภทรายการบริการ' from service_list(nolock) as a join service_list_type(nolock) as b on a.liserv_type_id = b.liserv_type_id where liserv_name like '" & textsearch & "%' or liserv_name like '%" & textsearch & "%' or liserv_name like '%" & textsearch & "'   order by liserv_id"
            ElseIf dropdownindex = 3 Then
                sql = "select liserv_id 'รหัสรายการบริการ',liserv_name 'ชื่อรายการบริการ',convert(varchar,liserv_price,1) 'ราคา' , b.liserv_type_name 'ประเภทรายการบริการ' from service_list(nolock) as a join service_list_type(nolock) as b on a.liserv_type_id = b.liserv_type_id where b.liserv_type_name like '" & textsearch & "%' or b.liserv_type_name like '%" & textsearch & "%' or b.liserv_type_name like '%" & textsearch & "'   order by liserv_id"
            ElseIf dropdownindex = 4 Then
                sql = "select liserv_id 'รหัสรายการบริการ',liserv_name 'ชื่อรายการบริการ',convert(varchar,liserv_price,1) 'ราคา' , b.liserv_type_name 'ประเภทรายการบริการ' from service_list(nolock) as a join service_list_type(nolock) as b on a.liserv_type_id = b.liserv_type_id where liserv_price like '" & textsearch & "%' or liserv_price like '%" & textsearch & "%' or liserv_price like '%" & textsearch & "' order by liserv_id"
            End If
            GetDataToGrid(sql, grid_servicelist)
        End If
    End Sub

    Private Sub grid_servicelist_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_servicelist.CellClick
        Dim rowindex As Integer = grid_servicelist.CurrentRow.Index
        If grid_servicelist.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_serviceid.Text = grid_servicelist.Rows(rowindex).Cells(0).Value
            txt_servicename.Text = grid_servicelist.Rows(rowindex).Cells(1).Value
            txt_serviceprice.Text = grid_servicelist.Rows(rowindex).Cells(2).Value
            cbo_serviceservtype.SelectedIndex = cbo_serviceservtype.FindString(grid_servicelist.Rows(rowindex).Cells(3).Value)
            btn_addservice.Visible = False
            btn_editservice.Visible = True
            btn_delservice.Visible = True
            txt_servicename.Focus()
        End If

    End Sub
#End Region
#Region "tab_promotion"
    'Private Sub btn_addpromotion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim promname As String = txt_promotionname.Text
    '    Dim promcont As String = txt_promotioncont.Text
    '    Dim promstart As String = dtp_promotionstart.Value.ToString("yyyy-MM-dd")
    '    Dim promend As String = dtp_promotionend.Value.ToString("yyyy-MM-dd")
    '    Dim promprice As Double = 0.0
    '    If promname <> "" And promstart <> "" And promend <> "" And Double.TryParse(txt_promotionprice.Text, promprice) Then
    '        Try
    '            sql =
    '           " insert into promotion " &
    '           " (prom_name,prom_condition,prom_price,prom_startdate,prom_enddate) " &
    '           " values('" & promname & "','" & promcont & "' ," & promprice & " ,convert(datetime,'" & promstart & "'),convert(datetime,'" & promend & "') )"

    '            If Obj_query.DMLData(sql) Then
    '                MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
    '                UpdateDatainGrid(selectedIndex)
    '                clearData(selectedIndex)
    '            Else
    '                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
    '            End If
    '        Catch ex As Exception
    '            MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
    '        End Try

    '    Else
    '        MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
    '    End If
    'End Sub

    'Private Sub btn_editpromotion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim promid As String = txt_promotionid.Text
    '    Dim promname As String = txt_promotionname.Text
    '    Dim promcont As String = txt_promotioncont.Text
    '    Dim promstart As String = dtp_promotionstart.Value.ToString("yyyy-MM-dd")
    '    Dim promend As String = dtp_promotionend.Value.ToString("yyyy-MM-dd")
    '    Dim promprice As Double = 0.0
    '    If promname <> "" And promstart <> "" And promend <> "" And Double.TryParse(txt_promotionprice.Text, promprice) Then
    '        Try
    '            sql =
    '           " update promotion set " &
    '           " prom_name='" & promname & "',prom_condition = '" & promcont & "',prom_price=" & promprice &
    '           ",prom_startdate = convert(datetime,'" & promstart & "'),prom_enddate = convert(datetime,'" & promend & "') " &
    '           " where prom_id = " & promid
    '            If Obj_query.DMLData(sql) Then
    '                MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
    '                UpdateDatainGrid(selectedIndex)
    '                clearData(selectedIndex)
    '            Else
    '                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
    '            End If
    '        Catch ex As Exception
    '            MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
    '        End Try

    '    Else
    '        MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
    '    End If
    'End Sub

    'Private Sub btn_delpromotion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim promid As String = txt_promotionid.Text
    '    Dim answer As DialogResult
    '    answer = MessageBox.Show("คุณต้องการลบรายการโปรโมชั่นนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '    If answer = vbYes Then
    '        If promid <> "" Then
    '            Try
    '                sql =
    '               " delete from promotion" &
    '               " where prom_id = " & promid
    '                If Obj_query.DMLData(sql) Then
    '                    MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
    '                    UpdateDatainGrid(selectedIndex)
    '                    clearData(selectedIndex)
    '                Else
    '                    MsgBox("ไม่สามารถลบข้อมูลนี้ได้ เพราะมีการใช้ข้อมูลอยู่")
    '                End If
    '            Catch ex As Exception
    '                MsgBox("ไม่สามารถลบข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
    '            End Try
    '        Else
    '            MsgBox("ข้อมูลบาง field ไม่ถูกต้อง")
    '        End If
    '    End If
    'End Sub

    'Private Sub btn_resetpromotion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    clearData(selectedIndex)
    'End Sub

    'Private Sub btn_searchpromotion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim dropdownindex As Integer = cbo_searchpromotion.SelectedIndex
    '    Dim textsearch As String = txt_searchpromotion.Text
    '    If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
    '        If dropdownindex = 0 Then
    '            UpdateDatainGrid(selectedIndex)
    '        ElseIf dropdownindex = 1 Then
    '            sql = "select prom_id 'รหัสโปรโมชั่น',prom_name 'ชื่อโปรโมชั่น' , prom_condition 'เงื่อนไข' , convert(varchar,prom_price,1) 'ราคาโปรโมชั่น' , prom_startdate 'วันเริ่มต้น' , prom_enddate 'วันสิ้นสุด' from promotion(nolock) where prom_id=" & textsearch & " order by prom_id"
    '        ElseIf dropdownindex = 2 Then
    '            sql = "select prom_id 'รหัสโปรโมชั่น',prom_name 'ชื่อโปรโมชั่น' , prom_condition 'เงื่อนไข' , convert(varchar,prom_price,1) 'ราคาโปรโมชั่น' , prom_startdate 'วันเริ่มต้น' , prom_enddate 'วันสิ้นสุด' from promotion(nolock) where prom_name like '" & textsearch & "%' or prom_name like '%" & textsearch & "%' or prom_name like '%" & textsearch & "'   order by prom_id"
    '        End If
    '        GetDataToGrid(sql, grid_promotion)
    '    End If
    'End Sub

    'Private Sub grid_promotion_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Dim rowindex As Integer = grid_promotion.CurrentRow.Index
    '    If grid_promotion.Rows(rowindex).Cells(1).Value.ToString <> "" Then
    '        txt_promotionid.Text = grid_promotion.Rows(rowindex).Cells(0).Value
    '        txt_promotionname.Text = grid_promotion.Rows(rowindex).Cells(1).Value
    '        txt_promotioncont.Text = grid_promotion.Rows(rowindex).Cells(2).Value
    '        txt_promotionprice.Text = grid_promotion.Rows(rowindex).Cells(3).Value
    '        dtp_promotionstart.Value = grid_promotion.Rows(rowindex).Cells(4).Value
    '        dtp_promotionend.Value = grid_promotion.Rows(rowindex).Cells(5).Value
    '        btn_addpromotion.Visible = False
    '        btn_editpromotion.Visible = True
    '        btn_delpromotion.Visible = True
    '        txt_promotionname.Focus()
    '    End If
    'End Sub
#End Region
#Region "tab_suplier"
    Private Sub btn_addsub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addsub.Click
        Dim sup_companyname As String = txt_subcompany.Text
        Dim sub_name As String = txt_subname.Text
        Dim sub_address As String = txt_subaddress.Text
        Dim sub_phone As String = txt_subphone.Text
        Dim sub_fax As String = txt_subfax.Text
        If sup_companyname <> "" And sub_name <> "" And sub_phone <> "" Then
            Try
                sql =
               " insert into supplier " &
               " (sup_companyname,sub_name,sub_address,sub_phone,sub_fax) " &
               " values('" & sup_companyname & "','" & sub_name & "' ,'" & sub_address & "' ,'" & sub_phone & "','" & sub_fax & "' )"
                If Obj_query.DMLData(sql) Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try

        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_editsub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editsub.Click
        Dim sup_id As String = txt_supid.Text
        Dim sup_companyname As String = txt_subcompany.Text
        Dim sub_name As String = txt_subname.Text
        Dim sub_address As String = txt_subaddress.Text
        Dim sub_phone As String = txt_subphone.Text
        Dim sub_fax As String = txt_subfax.Text
        If sup_companyname <> "" And sub_name <> "" Then
            Try
                sql =
              " update supplier set " &
              " sup_companyname = '" & sup_companyname & "',sub_name = '" & sub_name & "',sub_address = '" & sub_address & "',sub_phone = '" & sub_phone & "' ,sub_fax = '" & sub_fax & "' " &
              " where sup_id = " & sup_id
                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_delsub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delsub.Click
        Dim sup_id As String = txt_supid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการบริษัทตัวแทนจำหน่ายนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If sup_id <> "" Then
                Try
                    sql =
                   " delete from supplier " &
                   " where sup_id = " & sup_id
                    If Obj_query.DMLData(sql) Then
                        MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
                        UpdateDatainGrid(selectedIndex)
                        clearData(selectedIndex)
                    Else
                        MsgBox("ไม่สามารถลบข้อมูลได้ เพราะมีการใช้ข้อมูลอยู่")
                    End If
                Catch ex As Exception
                    MsgBox("ไม่สามารถลบข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End Try
            Else
                MsgBox("ข้อมูลบาง field ไม่ถูกต้อง")
            End If
        End If
    End Sub

    Private Sub btn_resetsub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetsub.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchsub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchsub.Click
        Dim dropdownindex As Integer = cbo_searchsub.SelectedIndex
        Dim textsearch As String = txt_searchsub.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select sup_id 'รหัสผู้ส่งสินค้า',sup_companyname 'ชื่อบริษัท',sub_name 'ชื่อผู้ส่ง' ,sub_address 'ที่อยู่',sub_phone 'เบอร์โทร',sub_fax 'เบอร์ Fax' from supplier(nolock) where sup_id=" & textsearch & " order by sup_id"
            ElseIf dropdownindex = 2 Then
                sql = "select sup_id 'รหัสผู้ส่งสินค้า',sup_companyname 'ชื่อบริษัท',sub_name 'ชื่อผู้ส่ง' ,sub_address 'ที่อยู่',sub_phone 'เบอร์โทร',sub_fax 'เบอร์ Fax' from supplier(nolock) where sup_companyname like '" & textsearch & "%' or sup_companyname like '%" & textsearch & "%' or sup_companyname like '%" & textsearch & "'   order by sup_id"
            ElseIf dropdownindex = 3 Then
                sql = "select sup_id 'รหัสผู้ส่งสินค้า',sup_companyname 'ชื่อบริษัท',sub_name 'ชื่อผู้ส่ง' ,sub_address 'ที่อยู่',sub_phone 'เบอร์โทร',sub_fax 'เบอร์ Fax' from supplier(nolock) where sub_name like '" & textsearch & "%' or sub_name like '%" & textsearch & "%' or sub_name like '%" & textsearch & "'   order by sup_id"
            ElseIf dropdownindex = 4 Then
                sql = "select sup_id 'รหัส',sup_companyname 'ชื่อบริษัท',sub_name 'ชื่อผู้ส่ง' ,sub_address 'ที่อยู่',sub_phone 'เบอร์โทร',sub_fax 'เบอร์ Fax' from supplier(nolock) where sub_phone like '" & textsearch & "%' or sub_phone like '%" & textsearch & "%' or sub_phone like '%" & textsearch & "' or sub_fax like '" & textsearch & "%' or sub_fax like '%" & textsearch & "%' or sub_fax like '%" & textsearch & "'   order by sup_id"
            End If
            GetDataToGrid(sql, grid_supplier)
        End If
    End Sub

    Private Sub grid_supplier_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_supplier.CellClick
        Dim rowindex As Integer = grid_supplier.CurrentRow.Index
        If grid_supplier.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_supid.Text = grid_supplier.Rows(rowindex).Cells(0).Value
            txt_subcompany.Text = grid_supplier.Rows(rowindex).Cells(1).Value
            txt_subname.Text = grid_supplier.Rows(rowindex).Cells(2).Value
            txt_subaddress.Text = grid_supplier.Rows(rowindex).Cells(3).Value
            txt_subphone.Text = grid_supplier.Rows(rowindex).Cells(4).Value
            txt_subfax.Text = grid_supplier.Rows(rowindex).Cells(5).Value
            btn_addsub.Visible = False
            btn_editsub.Visible = True
            btn_delsub.Visible = True
            txt_subname.Focus()
        End If
    End Sub
#End Region
#Region "tab_prefix"
    Private Sub btn_addprefix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addprefix.Click
        Dim prefixname As String = txt_prefixname.Text
        If prefixname <> "" Then
            Try
                sql =
               " insert into prefix " &
               " (prefix_name) " &
               " values('" & prefixname & "')"
                If Obj_query.DMLData(sql) Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub
    Private Sub btn_editprefix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editprefix.Click
        Dim prefixname As String = txt_prefixname.Text
        Dim prefixid As String = txt_prefixid.Text
        If prefixname <> "" Then
            Try
                sql =
              " update prefix " &
              " set prefix_name = '" & prefixname & "' where prefix_id = " & prefixid
                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub
    Private Sub btn_delprefix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delprefix.Click
        Dim prefixid As String = txt_prefixid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการคำหน้าชื่อนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If prefixid <> "" Then
                Try
                    sql =
                  " delete from prefix " &
                  " where prefix_id = " & prefixid
                    If Obj_query.DMLData(sql) Then
                        MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
                        UpdateDatainGrid(selectedIndex)
                        clearData(selectedIndex)
                    Else
                        MsgBox("ไม่สามารถลบข้อมูลนี้ได้ เพราะมีการใช้ข้อมูลอยู่")
                    End If
                Catch ex As Exception
                    MsgBox("ไม่สามารถลบข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End Try
            End If
        End If
    End Sub
    Private Sub btn_searchprefix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchprefix.Click
        Dim dropdownindex As Integer = cbo_searchprefix.SelectedIndex
        Dim textsearch As String = txt_searchprefix.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select prefix_id 'รหัสคำนำหน้าชื่อ',prefix_name 'คำนำหน้าชื่อ' from prefix(nolock) where prefix_id=" & textsearch & " order by prefix_id"
            ElseIf dropdownindex = 2 Then
                sql = "select prefix_id 'รหัสคำนำหน้าชื่อ',prefix_name 'คำนำหน้าชื่อ' from prefix(nolock) where prefix_name like '" & textsearch & "%' or prefix_name like '%" & textsearch & "%' or prefix_name like '%" & textsearch & "'   order by prefix_id"
            End If
            GetDataToGrid(sql, grid_prefix)
        End If
    End Sub
    Private Sub btn_resetprefix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetprefix.Click
        clearData(selectedIndex)
    End Sub
    Private Sub grid_prefix_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_prefix.CellClick
        Dim rowindex As Integer = grid_prefix.CurrentRow.Index
        If grid_prefix.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_prefixid.Text = grid_prefix.Rows(rowindex).Cells(0).Value
            txt_prefixname.Text = grid_prefix.Rows(rowindex).Cells(1).Value
            btn_addprefix.Visible = False
            btn_editprefix.Visible = True
            btn_delprefix.Visible = True
            txt_prefixname.Focus()
        End If
        
    End Sub
    
#End Region
#Region "tab_position"
    Private Sub btn_addposition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addposition.Click
        Dim positionname As String = txt_positionname.Text

        Dim positionsalary As Double = 0.0
        If positionname <> "" And Double.TryParse(txt_positionsalary.Text, positionsalary) Then
            Try
                sql =
               " insert into position " &
               " (pos_name,pos_salary) " &
               " values('" & positionname & "'," & positionsalary & ")"
                If Obj_query.DMLData(sql) Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก มีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub
    Private Sub btn_editposition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editposition.Click
        Dim positionid As String = txt_positionid.Text
        Dim positionname As String = txt_positionname.Text
        Dim positionsalary As Double = 0.0
        If positionid <> "" And positionname <> "" And Double.TryParse(txt_positionsalary.Text.Replace(",", ""), positionsalary) Then
            Try
                sql =
              " update position " &
              " set pos_name = '" & positionname & "',pos_salary = " & positionsalary & " where pos_id = " & positionid

                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก มีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_delposition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delposition.Click
        Dim positionid As String = txt_positionid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการตำแหน่งนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If positionid <> "" Then
                Try
                    sql =
                  " delete from position " &
                  " where pos_id = " & positionid
                    If Obj_query.DMLData(sql) Then
                        MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
                        UpdateDatainGrid(selectedIndex)
                        clearData(selectedIndex)
                    Else
                        MsgBox("ไม่สามารถลบข้อมูลนี้ได้ เพราะมีการใช้ข้อมูลอยู่")
                    End If
                Catch ex As Exception
                    MsgBox("ไม่สามารถลบข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End Try
            End If
        End If
    End Sub

    Private Sub btn_resetposition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetposition.Click
        clearData(selectedIndex)
    End Sub


    Private Sub btn_searchposition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchposition.Click
        Dim dropdownindex As Integer = cbo_searchposition.SelectedIndex
        Dim textsearch As String = txt_searchposition.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select pos_id 'รหัสตำแหน่ง',pos_name 'ชื่อตำแหน่ง',Convert(varchar,pos_salary,1) 'เงินเดือน' from position(nolock)  where pos_id=" & textsearch & " order by pos_id"
            ElseIf dropdownindex = 2 Then
                sql = "select pos_id 'รหัสตำแหน่ง',pos_name 'ชื่อตำแหน่ง',Convert(varchar,pos_salary,1) 'เงินเดือน' from position(nolock)  where pos_name like '" & textsearch & "%' or pos_name like '%" & textsearch & "%' or pos_name like '%" & textsearch & "'   order by pos_id"
            ElseIf dropdownindex = 3 Then
                sql = "select pos_id 'รหัสตำแหน่ง',pos_name 'ชื่อตำแหน่ง',Convert(varchar,pos_salary,1) 'เงินเดือน' from position(nolock)  where pos_salary like '" & textsearch & "%' or pos_salary like '%" & textsearch & "%' or pos_salary like '%" & textsearch & "'   order by pos_id"
            End If
            GetDataToGrid(sql, grid_position)
        End If
    End Sub
    Private Sub grid_position_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_position.CellClick
        Dim rowindex As Integer = grid_position.CurrentRow.Index
        If grid_position.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_positionid.Text = grid_position.Rows(rowindex).Cells(0).Value
            txt_positionname.Text = grid_position.Rows(rowindex).Cells(1).Value
            txt_positionsalary.Text = Double.Parse(grid_position.Rows(rowindex).Cells(2).Value).ToString("#,##0.00")
            btn_addposition.Visible = False
            btn_editposition.Visible = True
            btn_delposition.Visible = True
            txt_positionname.Focus()
        End If
    End Sub
#End Region
#Region "tab_commission"

    Private Sub btn_addcommission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addcommission.Click
        Dim commvalue As Double
        Dim commstartdate As String = dtp_commissionstart.Value.ToString("yyyy-MM-dd")
        Dim commenddate As String = dtp_commissionend.Value.ToString("yyyy-MM-dd")
        Dim commposition As Integer = cbo_comissionpostion.SelectedValue
        If Double.TryParse(txt_commissionname.Text, commvalue) And commstartdate <> "" And commenddate <> "" And commposition > 0 Then
            Try
                sql =
               " insert into commission " &
               " (com_percent,com_startdate,com_enddate,pos_id) " &
               " values(" & commvalue & ",convert(datetime,'" & commstartdate & "'),convert(datetime,'" & commenddate & "')," & commposition & ")"
                If Obj_query.DMLData(sql) Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_editcomission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editcomission.Click
        Dim commid As String = txt_commissionid.Text
        Dim commvalue As Double
        Dim commstartdate As String = dtp_commissionstart.Value.ToString("yyyy-MM-dd")
        Dim commenddate As String = dtp_commissionend.Value.ToString("yyyy-MM-dd")
        Dim commposition As Integer = cbo_comissionpostion.SelectedValue
        If commid <> "" And Double.TryParse(txt_commissionname.Text, commvalue) And commstartdate <> "" And commenddate <> "" And commposition > 0 Then
            Try
                sql =
              " update commission " &
              " set com_percent = " & commvalue & ",com_startdate = convert(datetime,'" & commstartdate & "'),com_enddate = convert(datetime,'" & commenddate & "' ), pos_id = " & commposition & " where com_id = " & commid
                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_delcommission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delcommission.Click
        Dim commid As String = txt_commissionid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการคอมมิชชั่นนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If commid <> "" Then
                Try
                    sql =
                  " delete from commission " &
                  " where com_id = " & commid
                    If Obj_query.DMLData(sql) Then
                        MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
                        UpdateDatainGrid(selectedIndex)
                        clearData(selectedIndex)
                    Else
                        MsgBox("ไม่สามารถลบข้อมูลนี้ได้ เพราะมีการใช้ข้อมูลอยู่")
                    End If
                Catch ex As Exception
                    MsgBox("ไม่สามารถลบข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End Try
            End If
        End If
    End Sub

    Private Sub btn_resetcomission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetcomission.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchcomission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchcomission.Click
        Dim dropdownindex As Integer = cbo_searchcommission.SelectedIndex
        Dim textsearch As String = txt_searchcomission.Text

        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select com_id 'รหัสคอมมิสชั่น',com_percent 'เปอร์เซ็น(%)',convert(varchar(10),com_startdate,103) 'วันที่เริ่มต้น' , convert(varchar(10),com_enddate,103) 'วันที่สิ้นสุด' ,b.pos_name 'ตำแหน่ง' from commission(nolock) as a join position(nolock) as b on a.pos_id = b.pos_id  where com_id=" & textsearch & " order by com_id"
            ElseIf dropdownindex = 2 Then
                sql = "select com_id 'รหัสคอมมิสชั่น',com_percent 'เปอร์เซ็น(%)',convert(varchar(10),com_startdate,103) 'วันที่เริ่มต้น' , convert(varchar(10),com_enddate,103) 'วันที่สิ้นสุด' ,b.pos_name 'ตำแหน่ง' from commission(nolock) as a join position(nolock) as b on a.pos_id = b.pos_id  where com_percent = " & textsearch & "order by com_id"
            ElseIf dropdownindex = 3 Then
                sql = "select com_id 'รหัสคอมมิสชั่น',com_percent 'เปอร์เซ็น(%)',convert(varchar(10),com_startdate,103) 'วันที่เริ่มต้น' , convert(varchar(10),com_enddate,103) 'วันที่สิ้นสุด' ,b.pos_name 'ตำแหน่ง' from commission(nolock) as a join position(nolock) as b on a.pos_id = b.pos_id  where convert(varchar(10),com_startdate,103) = '" & textsearch & "' order by com_id"
            ElseIf dropdownindex = 4 Then
                sql = "select com_id 'รหัสคอมมิสชั่น',com_percent 'เปอร์เซ็น(%)',convert(varchar(10),com_startdate,103) 'วันที่เริ่มต้น' , convert(varchar(10),com_enddate,103) 'วันที่สิ้นสุด' ,b.pos_name 'ตำแหน่ง' from commission(nolock) as a join position(nolock) as b on a.pos_id = b.pos_id  where convert(varchar(10),com_enddate,103) = '" & textsearch & "' order by com_id"
            End If
            GetDataToGrid(sql, grid_commission)
        End If
    End Sub

    Private Sub grid_commission_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_commission.CellClick
        Dim rowindex As Integer = grid_commission.CurrentRow.Index
        If grid_commission.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_commissionid.Text = grid_commission.Rows(rowindex).Cells(0).Value
            txt_commissionname.Text = grid_commission.Rows(rowindex).Cells(1).Value
            dtp_commissionstart.Value = grid_commission.Rows(rowindex).Cells(2).Value
            dtp_commissionend.Value = grid_commission.Rows(rowindex).Cells(3).Value
            cbo_comissionpostion.SelectedIndex = cbo_comissionpostion.FindString(grid_commission.Rows(rowindex).Cells(4).Value)
            btn_addcommission.Visible = False
            btn_editcomission.Visible = True
            btn_delcommission.Visible = True
            txt_commissionname.Focus()
        End If
    End Sub
#End Region
#Region "tab_customer_type"
    Private Sub btn_addcustype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addcustype.Click
        Dim custypename As String = txt_custypename.Text
        Dim custypelimit As Double = 0.0
        Dim custypeamount As Double = 0.0
        If custypename <> "" And (Double.TryParse(txt_custypelimit.Text, custypelimit) Or txt_custypelimit.Text = Nothing) And (Double.TryParse(txt_custypeamount.Text, custypeamount) Or txt_custypeamount.Text = Nothing) Then
            Try
                sql =
               " insert into customer_type " &
               " (custype_name,custype_minlimit,custype_amount) " &
               " values('" & custypename & "'," & custypelimit & "," & custypeamount & ")"
                If Obj_query.DMLData(sql) Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_editcustype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editcustype.Click
        Dim custypeid As String = txt_custypeid.Text
        Dim custypename As String = txt_custypename.Text
        Dim custypelimit As Double = 0.0
        Dim custypeamount As Double = 0.0
        If custypeid <> "" And custypename <> "" And Double.TryParse(txt_custypelimit.Text.Replace(",", ""), custypelimit) And (Double.TryParse(txt_custypeamount.Text, custypeamount) Or txt_custypeamount.Text = Nothing) Then
            Try
                sql =
              " update customer_type " &
              " set custype_name = '" & custypename & "',custype_minlimit = " & custypelimit & " ,custype_amount = " & custypeamount & " where custype_id = " & custypeid
                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_delcustype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delcustype.Click
        Dim custypeid As String = txt_custypeid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการประเภทผู้ใช้บริการนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If custypeid <> "" Then
                Try
                    sql =
                  " delete from customer_type " &
                  " where custype_id = " & custypeid
                    If Obj_query.DMLData(sql) Then
                        MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
                        UpdateDatainGrid(selectedIndex)
                        clearData(selectedIndex)
                    Else
                        MsgBox("ไม่สามารถลบข้อมูลนี้ได้ เพราะมีการใช้ข้อมูลอยู่")
                    End If
                Catch ex As Exception
                    MsgBox("ไม่สามารถลบข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End Try
            End If
        End If
    End Sub

    Private Sub btn_resetcustype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetcustype.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchcustype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchcustype.Click
        Dim dropdownindex As Integer = cbo_searchcustype.SelectedIndex
        Dim textsearch As String = txt_searchcustype.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select custype_id 'รหัสประเภทผู้ใช้บริการ',custype_name 'ชื่อประเภทผู้ใช้บริการ' , Convert(varchar,isnull(custype_minlimit,0),1) 'วงเงินขั่นต่ำ', Convert(varchar,isnull(custype_amount,0),1) 'วงเงินที่ได้รับจริง' from customer_type(nolock)  where custype_id=" & textsearch & " order by custype_id"
            ElseIf dropdownindex = 2 Then
                sql = "select custype_id 'รหัสประเภทผู้ใช้บริการ',custype_name 'ชื่อประเภทผู้ใช้บริการ' , Convert(varchar,isnull(custype_minlimit,0),1) 'วงเงินขั่นต่ำ', Convert(varchar,isnull(custype_amount,0),1) 'วงเงินที่ได้รับจริง' from customer_type(nolock)  where custype_name like '" & textsearch & "%' or custype_name like '%" & textsearch & "%' or custype_name like '%" & textsearch & "'   order by custype_id"
            End If
            GetDataToGrid(sql, grid_customertype)
        End If
    End Sub

    Private Sub grid_customertype_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_customertype.CellClick
        Dim rowindex As Integer = grid_customertype.CurrentRow.Index
        If grid_customertype.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_custypeid.Text = grid_customertype.Rows(rowindex).Cells(0).Value
            txt_custypename.Text = grid_customertype.Rows(rowindex).Cells(1).Value
            txt_custypelimit.Text = Double.Parse(grid_customertype.Rows(rowindex).Cells(2).Value).ToString("#,##0.00")
            txt_custypeamount.Text = Double.Parse(grid_customertype.Rows(rowindex).Cells(3).Value).ToString("#,##0.00")
            btn_addcustype.Visible = False
            btn_editcustype.Visible = True
            btn_delcustype.Visible = True
            txt_custypename.Focus()
        End If
    End Sub
#End Region
#Region "tab_product_type"
    Private Sub btn_addprodtype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addprodtype.Click
        Dim prodtypename As String = txt_prodtypename.Text
        If prodtypename <> "" Then
            Try
                sql =
               " insert into product_type " &
               " (prod_type_name) " &
               " values('" & prodtypename & "')"
                If Obj_query.DMLData(sql) Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_editprodtype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editprodtype.Click
        Dim prodtypename As String = txt_prodtypename.Text
        Dim prodtypeid As String = txt_prodtypeid.Text
        If prodtypename <> "" Then
            Try
                sql =
              " update product_type " &
              " set prod_type_name = '" & prodtypename & "' where prod_type_id = " & prodtypeid
                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_delprodtype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delprodtype.Click
        Dim prodtypeid As String = txt_prodtypeid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการประเภทผลิตภัณฑ์นี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If prodtypeid <> "" Then
                Try
                    sql =
                  " delete from product_type " &
                  " where prod_type_id = " & prodtypeid
                    If Obj_query.DMLData(sql) Then
                        MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
                        UpdateDatainGrid(selectedIndex)
                        clearData(selectedIndex)
                    Else
                        MsgBox("ไม่สามารถลบข้อมูลนี้ได้ เพราะมีการใช้ข้อมูลอยู่")
                    End If
                Catch ex As Exception
                    MsgBox("ไม่สามารถลบข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End Try
            End If
        End If
    End Sub

    Private Sub btn_resetprodtype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetprodtype.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchprodtype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchprodtype.Click
        Dim dropdownindex As Integer = cbo_searchprodtype.SelectedIndex
        Dim textsearch As String = txt_searchprodtype.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select prod_type_id 'รหัสประเภทสินค้า',prod_type_name 'ชื่อประเภทสินค้า' from product_type(nolock) where prod_type_id=" & textsearch & " order by prod_type_id"
            ElseIf dropdownindex = 2 Then
                sql = "select prod_type_id 'รหัสประเภทสินค้า',prod_type_name 'ชื่อประเภทสินค้า' from product_type(nolock) where prod_type_name like '" & textsearch & "%' or prod_type_name like '%" & textsearch & "%' or prod_type_name like '%" & textsearch & "'   order by prod_type_id"
            End If
            GetDataToGrid(sql, grid_producttype)
        End If
    End Sub

    Private Sub grid_producttype_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_producttype.CellClick
        Dim rowindex As Integer = grid_producttype.CurrentRow.Index
        If grid_producttype.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_prodtypeid.Text = grid_producttype.Rows(rowindex).Cells(0).Value
            txt_prodtypename.Text = grid_producttype.Rows(rowindex).Cells(1).Value
            btn_addprodtype.Visible = False
            btn_editprodtype.Visible = True
            btn_delprodtype.Visible = True
            txt_prodtypename.Focus()
        End If
    End Sub
#End Region
#Region "tab_servicelisttype"
    Private Sub btn_addservicelisttype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addservicelisttype.Click
        Dim servicelisttypename As String = txt_servicelisttypename.Text
        If servicelisttypename <> "" Then
            Try
                sql =
               " insert into service_list_type " &
               " (liserv_type_name) " &
               " values('" & servicelisttypename & "')"
                If Obj_query.DMLData(sql) Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_editservicelisttype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editservicelisttype.Click
        Dim servicelisttypename As String = txt_servicelisttypename.Text
        Dim servicelisttypeid As String = txt_servicelisttypeid.Text
        If servicelisttypename <> "" Then
            Try
                sql =
              " update service_list_type " &
              " set liserv_type_name = '" & servicelisttypename & "' where liserv_type_id = " & servicelisttypeid
                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_delservicelisttype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delservicelisttype.Click
        Dim servicelisttypeid As String = txt_servicelisttypeid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการประเภทรายการบริการนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If servicelisttypeid <> "" Then
                Try
                    sql =
                  " delete from service_list_type " &
                  " where liserv_type_id = " & servicelisttypeid
                    If Obj_query.DMLData(sql) Then
                        MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
                        UpdateDatainGrid(selectedIndex)
                        clearData(selectedIndex)
                    Else
                        MsgBox("ไม่สามารถลบข้อมูลนี้ได้ เพราะมีการใช้ข้อมูลอยู่")
                    End If
                Catch ex As Exception
                    MsgBox("ไม่สามารถลบข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End Try
            End If
        End If
    End Sub

    Private Sub btn_resetservicelisttype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetservicelisttype.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchservicelisttype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchservicelisttype.Click
        Dim dropdownindex As Integer = cbo_searchservicelisttype.SelectedIndex
        Dim textsearch As String = txt_searchservicelisttype.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select liserv_type_id 'รหัสประเภทรายการบริการ', liserv_type_name 'ชื่อประเภทรายการบริการ' from service_list_type(nolock) where liserv_type_id=" & textsearch & " order by liserv_type_id"
            ElseIf dropdownindex = 2 Then
                sql = "select liserv_type_id 'รหัสประเภทรายการบริการ', liserv_type_name 'ชื่อประเภทรายการบริการ' from service_list_type(nolock) where liserv_type_name like '" & textsearch & "%' or liserv_type_name like '%" & textsearch & "%' or liserv_type_name like '%" & textsearch & "'   order by liserv_type_id"
            End If
            GetDataToGrid(sql, grid_servicelisttype)
        End If
    End Sub

    Private Sub grid_servicelisttype_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_servicelisttype.CellClick
        Dim rowindex As Integer = grid_servicelisttype.CurrentRow.Index
        If grid_servicelisttype.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_servicelisttypeid.Text = grid_servicelisttype.Rows(rowindex).Cells(0).Value
            txt_servicelisttypename.Text = grid_servicelisttype.Rows(rowindex).Cells(1).Value
            btn_addservicelisttype.Visible = False
            btn_editservicelisttype.Visible = True
            btn_delservicelisttype.Visible = True
            txt_servicelisttypename.Focus()
        End If
    End Sub
#End Region
#Region "tab_unit"
    Private Sub btn_addunit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addunit.Click
        Dim unitname As String = txt_unitname.Text
        If unitname <> "" Then
            Try
                sql =
               " insert into unit " &
               " (unit_name) " &
               " values('" & unitname & "')"
                If Obj_query.DMLData(sql) Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_editunit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editunit.Click
        Dim unitname As String = txt_unitname.Text
        Dim unitid As String = txt_unitid.Text
        If unitname <> "" Then
            Try
                sql =
               " update unit set " &
               " unit_name = '" & unitname & "' where unit_id = " & unitid
                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้ เพราะมีข้อมูลนี้อยู่แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_delunit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delunit.Click
        Dim unitname As String = txt_unitname.Text
        Dim unitid As String = txt_unitid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการหน่วยนับนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If unitname <> "" Then
                Try
                    sql =
                   " delete from unit " &
                   " where unit_id = " & unitid
                    If Obj_query.DMLData(sql) Then
                        MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
                        UpdateDatainGrid(selectedIndex)
                        clearData(selectedIndex)
                    Else
                        MsgBox("ไม่สามารถลบข้อมูลนี้ได้ เพราะมีการใช้ข้อมูลอยู่")
                    End If
                Catch ex As Exception
                    MsgBox("ไม่สามารถลบข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End Try
            Else
                MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
            End If
        End If
    End Sub

    Private Sub btn_resetunit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetunit.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchunit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchunit.Click
        Dim dropdownindex As Integer = cbo_searchunit.SelectedIndex
        Dim textsearch As String = txt_searchunit.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select unit_id 'รหัสหน่วยนับ',unit_name 'ชื่อหน่วยนับ' from unit(nolock) where unit_id=" & textsearch & " order by unit_id"
            ElseIf dropdownindex = 2 Then
                sql = "select unit_id 'รหัสหน่วยนับ',unit_name 'ชื่อหน่วยนับ' from unit(nolock) where unit_name like '" & textsearch & "%' or unit_name like '%" & textsearch & "%' or unit_name like '%" & textsearch & "'   order by unit_id"
            End If
            GetDataToGrid(sql, grid_unit)
        End If
    End Sub

    Private Sub grid_unit_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_unit.CellClick
        Dim rowindex As Integer = grid_unit.CurrentRow.Index
        If grid_unit.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_unitid.Text = grid_unit.Rows(rowindex).Cells(0).Value
            txt_unitname.Text = grid_unit.Rows(rowindex).Cells(1).Value
            btn_addunit.Visible = False
            btn_editunit.Visible = True
            btn_delunit.Visible = True
            txt_unitname.Focus()
        End If
    End Sub
#End Region
#Region "totalcontrol"
    Private Sub tab_management_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_management.Click
        selectedIndex = tab_management.SelectedIndex
        UpdateDatainGrid(selectedIndex)
    End Sub
    Private Sub UpdateDatainGrid(ByVal index As Integer)
        Dim myalltab() As String = {"service_list", "promotion", "supplier", "prefix", "position", "commission", "customer_type", "product_type", "service_list_type", "unit"}
        Dim sqlqueryeachtab(9) As String
        sqlqueryeachtab(0) = "select liserv_id 'รหัสรายการบริการ',liserv_name 'ชื่อรายการบริการ',convert(varchar,liserv_price,1) 'ราคา' , b.liserv_type_name 'ประเภทรายการบริการ' from service_list(nolock) as a join service_list_type(nolock) as b on a.liserv_type_id = b.liserv_type_id order by liserv_id"
        'sqlqueryeachtab(1) = "select prom_id 'รหัสโปรโมชั่น',prom_name 'ชื่อโปรโมชั่น' , prom_condition 'เงื่อนไข' ,convert(varchar,prom_price,1) 'ราคาโปรโมชั่น' , prom_startdate 'วันเริ่มต้น' , prom_enddate 'วันสิ้นสุด' from promotion(nolock) order by prom_id"
        sqlqueryeachtab(1) = "select sup_id 'รหัสผู้ส่งสินค้า',sup_companyname 'ชื่อบริษัท',sub_name 'ชื่อผู้ส่ง' ,sub_address 'ที่อยู่',sub_phone 'เบอร์โทร',sub_fax 'เบอร์ Fax' from supplier(nolock) order by sup_id"
        sqlqueryeachtab(2) = "select prefix_id 'รหัสคำนำหน้าชื่อ',prefix_name 'คำนำหน้าชื่อ' from prefix(nolock) order by prefix_id"
        sqlqueryeachtab(3) = "select pos_id 'รหัสตำแหน่ง',pos_name 'ชื่อตำแหน่ง',Convert(varchar,pos_salary,1) 'เงินเดือน' from position(nolock) order by pos_id"
        sqlqueryeachtab(4) = "select com_id 'รหัสคอมมิสชั่น',com_percent 'เปอร์เซ็น(%)',convert(varchar(10),com_startdate,103) 'วันที่เริ่มต้น' , convert(varchar(10),com_enddate,103) 'วันที่สิ้นสุด' ,b.pos_name 'ตำแหน่ง' from commission(nolock) as a join position(nolock) as b on a.pos_id = b.pos_id"
        sqlqueryeachtab(5) = "select custype_id 'รหัสประเภทผู้ใช้บริการ',custype_name 'ชื่อประเภทผู้ใช้บริการ' , Convert(varchar,isnull(custype_minlimit,0),1) 'วงเงินขั่นต่ำ', Convert(varchar,isnull(custype_amount,0),1) 'วงเงินที่ได้รับจริง' from customer_type(nolock) order by custype_id"
        sqlqueryeachtab(6) = "select prod_type_id 'รหัสประเภทสินค้า',prod_type_name 'ชื่อประเภทสินค้า' from product_type(nolock) order by prod_type_id"
        sqlqueryeachtab(7) = "select liserv_type_id 'รหัสประเภทรายการบริการ', liserv_type_name 'ชื่อประเภทรายการบริการ' from service_list_type(nolock) order by liserv_type_id"
        sqlqueryeachtab(8) = "select unit_id 'รหัสหน่วยนับ',unit_name 'ชื่อหน่วยนับ' from unit(nolock) order by unit_id"

        Dim havedropdown(,) As String =
            {
                {"0", "select liserv_type_id ID,liserv_type_name Name from service_list_type order by liserv_type_id ", "0"},
                {"4", "select pos_id ID,pos_name Name from position(nolock) order by pos_id ", "1"}
            }
        Dim mygrid() As DataGridView = {grid_servicelist, grid_supplier, grid_prefix, grid_position, grid_commission, grid_customertype, grid_producttype, grid_servicelisttype, grid_unit}
        Dim mycombobox() As ComboBox = {
            cbo_serviceservtype, cbo_comissionpostion
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
            txt_serviceid.Text = ""
            txt_servicename.Text = ""
            txt_serviceprice.Text = ""
            cbo_serviceservtype.SelectedIndex = 0
            btn_addservice.Visible = True
            btn_editservice.Visible = False
            btn_delservice.Visible = False
            'ElseIf index = 1 Then
            '    txt_promotionid.Text = ""
            '    txt_promotionname.Text = ""
            '    txt_promotioncont.Text = ""
            '    txt_promotionprice.Text = ""
            '    dtp_promotionstart.Value = Date.Now
            '    dtp_promotionend.Value = Date.Now
            '    btn_addpromotion.Visible = True
            '    btn_editpromotion.Visible = False
            '    btn_delpromotion.Visible = False
        ElseIf index = 1 Then
            txt_supid.Text = ""
            txt_subcompany.Text = ""
            txt_subname.Text = ""
            txt_subaddress.Text = ""
            txt_subphone.Text = ""
            txt_subfax.Text = ""
            btn_addsub.Visible = True
            btn_editsub.Visible = False
            btn_delsub.Visible = False
        ElseIf (index = 2) Then
            txt_prefixname.Text = ""
            txt_prefixid.Text = ""
            btn_addprefix.Visible = True
            btn_editprefix.Visible = False
            btn_delprefix.Visible = False
        ElseIf index = 3 Then
            txt_positionid.Text = ""
            txt_positionname.Text = ""
            txt_positionsalary.Text = ""
            btn_addposition.Visible = True
            btn_editposition.Visible = False
            btn_delposition.Visible = False
        ElseIf index = 4 Then
            txt_commissionid.Text = ""
            txt_commissionname.Text = ""
            dtp_commissionstart.Value = DateTime.Now
            dtp_commissionend.Value = DateTime.Now
            cbo_comissionpostion.SelectedIndex = 0
            btn_addcommission.Visible = True
            btn_editcomission.Visible = False
            btn_delcommission.Visible = False
        ElseIf index = 5 Then
            txt_custypeid.Text = ""
            txt_custypename.Text = ""
            txt_custypelimit.Text = ""
            txt_custypeamount.Text = ""
            btn_addcustype.Visible = True
            btn_editcustype.Visible = False
            btn_delcustype.Visible = False
        ElseIf index = 6 Then
            txt_prodtypeid.Text = ""
            txt_prodtypename.Text = ""
            btn_addprodtype.Visible = True
            btn_editprodtype.Visible = False
            btn_delprodtype.Visible = False
        ElseIf index = 7 Then
            txt_servicelisttypeid.Text = ""
            txt_servicelisttypename.Text = ""
            btn_addservicelisttype.Visible = True
            btn_editservicelisttype.Visible = False
            btn_delservicelisttype.Visible = False
        ElseIf index = 8 Then
            txt_unitid.Text = ""
            txt_unitname.Text = ""
            btn_addunit.Visible = True
            btn_editunit.Visible = False
            btn_delunit.Visible = False
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
#End Region

    Private Sub form_genaral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectedIndex = 0
        UpdateDatainGrid(selectedIndex)
    End Sub
    Private Sub form_genaral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim leadtimeproductsql As String = "select prod_id 'รหัส',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',d.prod_type_name 'ประเภทสินค้า',convert(varchar,prod_price,1) 'ราคาสินค้า','บาท' 'หน่วยนับ',a.prod_qty 'จำนวนสินค้า',b.unit_name 'หน่วยนับ',prod_capacity 'ปริมาตร',c.unit_name 'หน่วยนับปริมาตร' from product a(nolock) join unit b(nolock) on a.unit_id = b.unit_id join unit c on a.unit_id_cap = c.unit_id join product_type d on a.prod_type_id = d.prod_type_id  where (prod_qty - prod_leadtime) between (prod_leadtime * -1) and 2 order by prod_id"
        GetDataToGrid(leadtimeproductsql, form_home.grid_alertproduct)
        form_home.Enabled = True
    End Sub 'Form1_Closing
    
   
    Private Sub cbo_searchservice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchservice.SelectedIndexChanged
        If cbo_searchservice.SelectedIndex = 0 Then
            txt_searchservice.Text = ""
        End If
    End Sub

    'Private Sub cbo_searchpromotion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cbo_searchpromotion.SelectedIndex = 0 Then
    '        txt_searchpromotion.Text = ""
    '    End If
    'End Sub

    Private Sub cbo_searchsub_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchsub.SelectedIndexChanged
        If cbo_searchsub.SelectedIndex = 0 Then
            txt_searchsub.Text = ""
        End If
    End Sub

    Private Sub cbo_searchprefix_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchprefix.SelectedIndexChanged
        If cbo_searchprefix.SelectedIndex = 0 Then
            txt_searchprefix.Text = ""
        End If
    End Sub

    Private Sub cbo_searchposition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchposition.SelectedIndexChanged
        If cbo_searchposition.SelectedIndex = 0 Then
            txt_searchposition.Text = ""
        End If
    End Sub

    Private Sub cbo_searchcommission_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchcommission.SelectedIndexChanged
        If cbo_searchcommission.SelectedIndex = 0 Then
            txt_searchcomission.Text = ""
        End If
    End Sub

    Private Sub cbo_searchcustype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchcustype.SelectedIndexChanged
        If cbo_searchcustype.SelectedIndex = 0 Then
            txt_searchcustype.Text = ""
        End If
    End Sub

    Private Sub cbo_searchprodtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchprodtype.SelectedIndexChanged
        If cbo_searchprodtype.SelectedIndex = 0 Then
            txt_searchprodtype.Text = ""
        End If
    End Sub

    Private Sub cbo_searchservicelisttype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchservicelisttype.SelectedIndexChanged
        If cbo_searchservicelisttype.SelectedIndex = 0 Then
            txt_searchservicelisttype.Text = ""
        End If
    End Sub

    Private Sub cbo_searchunit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchunit.SelectedIndexChanged
        If cbo_searchunit.SelectedIndex = 0 Then
            txt_searchunit.Text = ""
        End If
    End Sub

   
    Private Sub txt_custypelimit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_custypelimit.TextChanged
        txt_custypeamount.Text = txt_custypelimit.Text
    End Sub
End Class