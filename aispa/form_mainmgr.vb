Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_mainmgr
    Dim Obj_query As New classquery()
    Dim sql As String
    Dim datatable As New DataTable
    Dim selectedIndex As Integer
    Dim conditiondiscount As String = ""
    Dim canchangememtype As Boolean = True
    Dim nowis As String = "start"
    Dim chooseall As Boolean = False
    Dim custypeall As Boolean = False
#Region "tab_member"
    Private Sub btn_addmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addmember.Click
        Dim mname As String = txt_mname.Text
        Dim mphone As String = txt_mphone.Text
        Dim sex As String = ""
        If rdo_msexM.Checked Then
            sex = "M"
        ElseIf rdo_msexF.Checked Then
            sex = "F"
        End If
        Dim maddress As String = txt_maddress.Text
        Dim money As Double = 0.0
        Dim amount As Double = 0.0
        Dim mtype As Integer = Integer.Parse(cbo_mtypemem.SelectedValue)
        Dim mprefix As Integer = Integer.Parse(cbo_mprefix.SelectedValue)
        sql = "select convert(varchar,custype_minlimit,1) money from customer_type(nolock) where custype_id = " & mtype
        datatable = Obj_query.selectDatatoGrid(sql)
        Dim minlimi = datatable.Rows(0)("money").ToString().Trim()
        Dim phone As Double = 0
        Dim positionsalary As Double = 0.0
        Dim dateregis As String = dtp_mregis.Value.ToString("yyyy-MM-dd")
        Dim datetomorow As Integer = Integer.Parse(Date.Now().ToString("yyyyMMdd"))
        Dim datecurrent As Integer = Integer.Parse(dtp_mregis.Value.ToString("yyyyMMdd"))
        If mname <> "" And sex <> "" And ((Double.TryParse(txt_mmoney.Text, money)) And money >= minlimi) And ((Double.TryParse(txt_amoney.Text, amount))) And mtype > 0 And mprefix > 0 And (txt_mphone.Text.Length = 10 And dateregis <> "" And datecurrent <= datetomorow) Then
            Try
                sql =
                 " insert into customer " &
                 " (cus_fullname,cus_phone,cus_sex,cus_address,cus_money,cus_regis,prefix_id,custype_id,cus_amount) " &
                 " values('" & mname & "','" & mphone & "','" & sex & "','" & maddress & "'," &
                 " " & money & ",'" & dateregis & "','" & mprefix & "','" & mtype & "', " & amount & ")"

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

    Private Sub btn_editmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editmember.Click
        Dim mid As String = txt_mid.Text
        Dim mname As String = txt_mname.Text
        Dim mphone As String = txt_mphone.Text
        Dim sex As String = ""
        If rdo_msexM.Checked Then
            sex = "M"
        ElseIf rdo_msexF.Checked Then
            sex = "F"
        End If
        Dim maddress As String = txt_maddress.Text
        Dim money As Double = 0.0
        Dim amount As Double = 0.0
        Dim mtype As Integer = Integer.Parse(cbo_mtypemem.SelectedValue)
        Dim mprefix As Integer = Integer.Parse(cbo_mprefix.SelectedValue)
        sql = "select convert(varchar,custype_minlimit,1) money from customer_type(nolock) where custype_id = " & mtype
        datatable = Obj_query.selectDatatoGrid(sql)
        Dim minlimi = datatable.Rows(0)("money").ToString().Trim()
        Dim positionsalary As Double = 0.0
        Dim dateregis As String = dtp_mregis.Value.ToString("yyyy-MM-dd")
        Dim datetomorow As Integer = Integer.Parse(Date.Now().ToString("yyyyMMdd"))
        Dim datecurrent As Integer = Integer.Parse(dtp_mregis.Value.ToString("yyyyMMdd"))
        If mid <> "" And mname <> "" And sex <> "" And ((Double.TryParse(txt_mmoney.Text, money)) And money >= minlimi) And ((Double.TryParse(txt_amoney.Text, amount))) And mtype > 0 And mprefix > 0 And dateregis <> "" And datecurrent <= datetomorow Then
            Try
                sql =
              " update customer " &
              " set cus_fullname = '" & mname & "',cus_phone ='" & mphone & "',cus_sex ='" & sex & "', cus_address = '" & maddress & "'" &
              ",cus_money = " & money & ",cus_regis = '" & dateregis & "', prefix_id = " & mprefix & " , custype_id = " & mtype & " , cus_amount = " & amount & " where cus_id = " & mid
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

    Private Sub btn_delmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delmember.Click
        Dim mid As String = txt_mid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการผู้ใช้บริการนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If mid <> "" Then
                Try
                    sql =
                 " delete from customer " &
                 " where cus_id = " & mid
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

    Private Sub btn_resetmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetmember.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchmember.Click
        Dim dropdownindex As Integer = cbo_searchmember.SelectedIndex
        Dim textsearch As String = txt_searchmember.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select cus_id 'รหัสผู้ใช้บริการ',(b.prefix_name +' '+ cus_fullname)  'ชื่อผู้ใช้บริการ',cus_phone 'เบอร์โทรศัพท์',case when cus_sex = 'M' then 'ชาย' when cus_sex = 'F' then 'หญิง' end 'เพศ',cus_address 'ที่อยู่',convert(varchar,isnull(cus_money,0),1) 'วงเงิน',convert(varchar,isnull(cus_amount,0),1) 'วงเงินที่ใช้จริง' , c.custype_name 'ประเภทสมาชิก',convert(varchar(10),cus_regis,103) 'วันที่สมัคร' from customer(nolock) as a join prefix as b on a.prefix_id = b.prefix_id join customer_type as c on a.custype_id = c.custype_id  where cus_id=" & textsearch & " order by cus_id"
            ElseIf dropdownindex = 2 Then
                sql = "select cus_id 'รหัสผู้ใช้บริการ',(b.prefix_name +' '+ cus_fullname)  'ชื่อผู้ใช้บริการ',cus_phone 'เบอร์โทรศัพท์',case when cus_sex = 'M' then 'ชาย' when cus_sex = 'F' then 'หญิง' end 'เพศ',cus_address 'ที่อยู่',convert(varchar,isnull(cus_money,0),1) 'วงเงิน',convert(varchar,isnull(cus_amount,0),1) 'วงเงินที่ใช้จริง' , c.custype_name 'ประเภทสมาชิก',convert(varchar(10),cus_regis,103) 'วันที่สมัคร' from customer(nolock) as a join prefix as b on a.prefix_id = b.prefix_id join customer_type as c on a.custype_id = c.custype_id  where cus_fullname like '" & textsearch & "%' or cus_fullname like '%" & textsearch & "%' or cus_fullname like '%" & textsearch & "'   order by cus_id"
            ElseIf dropdownindex = 3 Then
                Dim Man As String = "ชาย"
                Dim Woman As String = "หญิง"
                If (Man.IndexOf(textsearch) > -1) Then
                    textsearch = "M"
                ElseIf Woman.IndexOf(textsearch) > -1 Then
                    textsearch = "F"
                End If
                sql = "select cus_id 'รหัสผู้ใช้บริการ',(b.prefix_name +' '+ cus_fullname)  'ชื่อผู้ใช้บริการ',cus_phone 'เบอร์โทรศัพท์',case when cus_sex = 'M' then 'ชาย' when cus_sex = 'F' then 'หญิง' end 'เพศ',cus_address 'ที่อยู่',convert(varchar,isnull(cus_money,0),1) 'วงเงิน',convert(varchar,isnull(cus_amount,0),1) 'วงเงินที่ใช้จริง' , c.custype_name 'ประเภทสมาชิก',convert(varchar(10),cus_regis,103) 'วันที่สมัคร' from customer(nolock) as a join prefix as b on a.prefix_id = b.prefix_id join customer_type as c on a.custype_id = c.custype_id  where cus_sex = '" & textsearch.ToUpper() & "'   order by cus_id"
            ElseIf dropdownindex = 4 Then
                sql = "select cus_id 'รหัสผู้ใช้บริการ',(b.prefix_name +' '+ cus_fullname)  'ชื่อผู้ใช้บริการ',cus_phone 'เบอร์โทรศัพท์',case when cus_sex = 'M' then 'ชาย' when cus_sex = 'F' then 'หญิง' end 'เพศ',cus_address 'ที่อยู่',convert(varchar,isnull(cus_money,0),1) 'วงเงิน',convert(varchar,isnull(cus_amount,0),1) 'วงเงินที่ใช้จริง' , c.custype_name 'ประเภทสมาชิก',convert(varchar(10),cus_regis,103) 'วันที่สมัคร' from customer(nolock) as a join prefix as b on a.prefix_id = b.prefix_id join customer_type as c on a.custype_id = c.custype_id  where cus_phone like '" & textsearch & "%' or cus_phone like '%" & textsearch & "%' or cus_phone like '%" & textsearch & "'   order by cus_id"
            ElseIf dropdownindex = 5 Then
                sql = "select cus_id 'รหัสผู้ใช้บริการ',(b.prefix_name +' '+ cus_fullname)  'ชื่อผู้ใช้บริการ',cus_phone 'เบอร์โทรศัพท์',case when cus_sex = 'M' then 'ชาย' when cus_sex = 'F' then 'หญิง' end 'เพศ',cus_address 'ที่อยู่',convert(varchar,isnull(cus_money,0),1) 'วงเงิน',convert(varchar,isnull(cus_amount,0),1) 'วงเงินที่ใช้จริง' , c.custype_name 'ประเภทสมาชิก' from customer(nolock) as a join prefix as b on a.prefix_id = b.prefix_id join customer_type as c on a.custype_id = c.custype_id  where c.custype_name like '" & textsearch & "%' or c.custype_name like '%" & textsearch & "%' or c.custype_name like '%" & textsearch & "'   order by cus_id"
            End If
            GetDataToGrid(sql, grid_customer)
        End If
    End Sub
    Private Sub grid_customer_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_customer.CellClick
        Dim rowindex As Integer = grid_customer.CurrentRow.Index
        If grid_customer.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_mid.Text = grid_customer.Rows(rowindex).Cells(0).Value
            btn_addmoney.Visible = True
            Dim name As String = grid_customer.Rows(rowindex).Cells(1).Value
            Dim splitprefix_name() As String = name.Split(" ")
            txt_mname.Text = name.Substring(splitprefix_name(0).Length, name.Length - splitprefix_name(0).Length).Trim()
            cbo_mprefix.SelectedIndex = cbo_mprefix.FindString(splitprefix_name(0))
            Dim sex As String = grid_customer.Rows(rowindex).Cells(3).Value
            If sex = "ชาย" Then
                rdo_msexM.Select()
            ElseIf sex = "หญิง" Then
                rdo_msexF.Select()
            End If
            dtp_mregis.Value = grid_customer.Rows(rowindex).Cells(8).Value
            txt_maddress.Text = grid_customer.Rows(rowindex).Cells(4).Value
            txt_mphone.Text = grid_customer.Rows(rowindex).Cells(2).Value
            txt_mmoney.Text = grid_customer.Rows(rowindex).Cells(5).Value
            txt_mmoney.Enabled = False
            txt_amoney.Text = grid_customer.Rows(rowindex).Cells(6).Value
            Dim chkmoney As Double = 0
            If Double.TryParse(txt_mmoney.Text, chkmoney) And chkmoney > 0 Then
                'cbo_mtypemem.Enabled = False
                canchangememtype = False ' เปลี่ยน action ก่อนที่มันจะไปเปลี่ยนค่าใน combobox
            End If
            cbo_mtypemem.SelectedIndex = cbo_mtypemem.FindString(grid_customer.Rows(rowindex).Cells(7).Value)
            checkmemtype()
            btn_addmember.Visible = False
            btn_editmember.Visible = True
            btn_delmember.Visible = True
            txt_mname.Focus()
        End If
    End Sub
    Private Sub cbo_mprefix_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mprefix.SelectedIndexChanged
        If cbo_mprefix.Text = "นาย" Then
            rdo_msexM.Select()
            rdo_msexM.Enabled = True
            rdo_msexF.Enabled = False
        ElseIf cbo_mprefix.Text = "นาง" Or cbo_mprefix.Text = "นางสาว" Then
            rdo_msexF.Select()
            rdo_msexF.Enabled = True
            rdo_msexM.Enabled = False
        Else
            rdo_msexM.Select()
            rdo_msexF.Enabled = True
            rdo_msexM.Enabled = True
        End If
    End Sub
    Private Sub cbo_mtypemem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_mtypemem.SelectedIndexChanged
        'If canchangememtype = True Then
        checkmemtype()
        ' End If

    End Sub
    Private Sub checkmemtype()
        Dim typeid = cbo_mtypemem.SelectedValue
        If typeid > -1 Then
            sql = "select convert(varchar,isnull(custype_minlimit,0),1) money,convert(varchar,isnull(custype_amount,0),1) amountmoney from customer_type(nolock) where custype_id = " & typeid
            datatable = Obj_query.selectDatatoGrid(sql)
            Dim minlimit = datatable.Rows(0)("money").ToString().Trim()
            Dim amount = datatable.Rows(0)("amountmoney").ToString().Trim()
            If canchangememtype = True Then
                txt_mmoney.Text = minlimit
                txt_amoney.Text = amount
            End If
            lbl_showlimit.Text = "กรุณาระบุจำนวนวงเงิน มากกว่า หรือ เท่ากับ " & minlimit
            lbl_showlimit.ForeColor = Color.Red
        End If
    End Sub
    Private Sub btn_addmoney_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addmoney.Click
        form_add_money.ShowDialog()
    End Sub
#End Region
#Region "tab_employee"
    Private Sub btn_addemployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addemployee.Click
        Dim empname As String = txt_employeename.Text
        Dim empprefix As Integer = cbo_employeeprefix.SelectedValue
        Dim empsex As String = ""
        If rdo_employeesexM.Checked Then
            empsex = "M"
        ElseIf rdo_employeesexF.Checked Then
            empsex = "F"
        End If
        Dim empaddress As String = txt_employeeaddress.Text
        Dim empphone As String = txt_employeephone.Text
        Dim emppos As Integer = cbo_employeeposition.SelectedValue
        Dim empprivi As String = ""
        If rdo_Admin.Checked Then
            empprivi = "Administrator"
        ElseIf rdo_User.Checked Then
            empprivi = "User"
        End If
        Dim empuser As String = txt_employeeusername.Text
        Dim emppass As String = txt_employeepass.Text
        Dim emprepass As String = txt_employeerepass.Text
        If empname <> "" And empsex <> "" And empprefix > 0 And emppos > 0 And empprivi <> "" And ((empprivi = "Administrator" And empuser <> "" And emppass <> "" And emprepass <> "") Or (empprivi = "User")) Then
            If (emppass <> emprepass Or emppass.Length < 6 Or emprepass.Length < 6) Then
                MsgBox("รหัสผ่านไม่ตรงกัน หรือ ความยาวน้อยกว่า 6 ตัว")
                Exit Sub
            End If
            Try
                sql =
                 " insert into employee " &
                 " (emp_fullname,emp_phone,emp_address,emp_sex,emp_username,emp_password,emp_privilege,prefix_id,pos_id) " &
                 " values('" & empname & "','" & empphone & "','" & empaddress & "','" & empsex & "'," &
                 " '" & empuser & "','" & emppass & "','" & empprivi & "'," & empprefix & "," & emppos & ")"
                If Obj_query.DMLData(sql) Then
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ชื่อผู้ใช้งานระบบนี้มีผู้ใช้แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_editemployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editemployee.Click
        Dim empid As String = txt_employeeid.Text
        Dim empname As String = txt_employeename.Text
        Dim empprefix As Integer = cbo_employeeprefix.SelectedValue
        Dim empsex As String = ""
        If rdo_employeesexM.Checked Then
            empsex = "M"
        ElseIf rdo_employeesexF.Checked Then
            empsex = "F"
        End If
        Dim empaddress As String = txt_employeeaddress.Text
        Dim empphone As String = txt_employeephone.Text
        Dim emppos As Integer = cbo_employeeposition.SelectedValue
        Dim empprivi As String = ""
        If rdo_Admin.Checked Then
            empprivi = "Administrator"
        ElseIf rdo_User.Checked Then
            empprivi = "User"
        End If
        Dim empuser As String = txt_employeeusername.Text
        Dim emppass As String = txt_employeepass.Text
        Dim emprepass As String = txt_employeerepass.Text
        If empname <> "" And empsex <> "" And empprefix > 0 And emppos > 0 And ((empprivi = "Administrator" And empuser <> "" And emppass <> "") Or (empprivi = "User")) Then
            If (emppass <> emprepass Or emppass.Length < 6 Or emprepass.Length < 6) Then
                MsgBox("รหัสผ่านไม่ตรงกัน หรือ ความยาวของรหัสผ่านน้อยกว่า 6 ตัวอักษร")
                Exit Sub
            End If
            Try
                sql =
              " update employee " &
              " set emp_fullname = '" & empname & "',emp_phone ='" & empphone & "',emp_address ='" & empaddress &
              "', emp_sex = '" & empsex & "'" &
              ",emp_username = '" & empuser & "', emp_password = '" & emppass & "' , emp_privilege = '" & empprivi & "' " &
              ",prefix_id = " & empprefix & " ,pos_id = " & emppos & "  where emp_id = " & empid
                If Obj_query.DMLData(sql) Then
                    MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ชื่อผู้ใช้งานระบบนี้มีผู้ใช้แล้ว")
                End If
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try
        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_delemployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delemployee.Click
        Dim empid As String = txt_employeeid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการพนักงานนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If empid <> "" Then
                Try
                    sql =
                  " delete from employee " &
                  " where emp_id = " & empid
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

    Private Sub btn_resetemployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetemployee.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchemployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchemployee.Click
        Dim dropdownindex As Integer = cbo_searchemployee.SelectedIndex
        Dim textsearch As String = txt_searchemployee.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select emp_id 'รหัสพนักงาน',(b.prefix_name +' '+ emp_fullname) 'ชื่อพนักงาน',emp_phone 'เบอร์โทรศัพท์',c.pos_name 'ตำแหน่ง',a.emp_username 'ชื่อผู้ใช้งานระบบ', CASE WHEN emp_sex = 'M' THEN 'ชาย'  WHEN emp_sex = 'F' THEN 'หญิง'  END 'เพศ',emp_address 'ที่อยู่' from employee(nolock) as a join prefix(nolock) as b on a.prefix_id = b.prefix_id join position(nolock) as c on a.pos_id = c.pos_id where emp_id=" & textsearch & " order by emp_id"
            ElseIf dropdownindex = 2 Then
                sql = "select emp_id 'รหัสพนักงาน',(b.prefix_name +' '+ emp_fullname) 'ชื่อพนักงาน',emp_phone 'เบอร์โทรศัพท์',c.pos_name 'ตำแหน่ง',a.emp_username 'ชื่อผู้ใช้งานระบบ', CASE WHEN emp_sex = 'M' THEN 'ชาย'  WHEN emp_sex = 'F' THEN 'หญิง'  END 'เพศ',emp_address 'ที่อยู่' from employee(nolock) as a join prefix(nolock) as b on a.prefix_id = b.prefix_id join position(nolock) as c on a.pos_id = c.pos_id where emp_fullname like '" & textsearch & "%' or emp_fullname like '%" & textsearch & "%' or emp_fullname like '%" & textsearch & "'   order by emp_id"
            ElseIf dropdownindex = 3 Then
                Dim Man As String = "ชาย"
                Dim Woman As String = "หญิง"
                If (Man.IndexOf(textsearch) > -1) Then
                    textsearch = "M"
                ElseIf Woman.IndexOf(textsearch) > -1 Then
                    textsearch = "F"
                End If
                sql = "select emp_id 'รหัสพนักงาน',(b.prefix_name +' '+ emp_fullname) 'ชื่อพนักงาน',emp_phone 'เบอร์โทรศัพท์',c.pos_name 'ตำแหน่ง',a.emp_username 'ชื่อผู้ใช้งานระบบ', CASE WHEN emp_sex = 'M' THEN 'ชาย'  WHEN emp_sex = 'F' THEN 'หญิง'  END 'เพศ',emp_address 'ที่อยู่' from employee(nolock) as a join prefix(nolock) as b on a.prefix_id = b.prefix_id join position(nolock) as c on a.pos_id = c.pos_id where emp_sex = '" & textsearch.ToUpper() & "'   order by emp_id"
            ElseIf dropdownindex = 4 Then
                sql = "select emp_id 'รหัสพนักงาน',(b.prefix_name +' '+ emp_fullname) 'ชื่อพนักงาน',emp_phone 'เบอร์โทรศัพท์',c.pos_name 'ตำแหน่ง',a.emp_username 'ชื่อผู้ใช้งานระบบ', CASE WHEN emp_sex = 'M' THEN 'ชาย'  WHEN emp_sex = 'F' THEN 'หญิง'  END 'เพศ',emp_address 'ที่อยู่' from employee(nolock) as a join prefix(nolock) as b on a.prefix_id = b.prefix_id join position(nolock) as c on a.pos_id = c.pos_id where emp_phone like '" & textsearch & "%' or emp_phone like '%" & textsearch & "%' or emp_phone like '%" & textsearch & "'   order by emp_id"
            ElseIf dropdownindex = 5 Then
                sql = "select emp_id 'รหัสพนักงาน',(b.prefix_name +' '+ emp_fullname) 'ชื่อพนักงาน',emp_phone 'เบอร์โทรศัพท์',c.pos_name 'ตำแหน่ง',a.emp_username 'ชื่อผู้ใช้งานระบบ', CASE WHEN emp_sex = 'M' THEN 'ชาย'  WHEN emp_sex = 'F' THEN 'หญิง'  END 'เพศ',emp_address 'ที่อยู่' from employee(nolock) as a join prefix(nolock) as b on a.prefix_id = b.prefix_id join position(nolock) as c on a.pos_id = c.pos_id where c.pos_name like '" & textsearch & "%' or c.pos_name like '%" & textsearch & "%' or c.pos_name like '%" & textsearch & "'   order by emp_id"
            End If
            GetDataToGrid(sql, grid_employee)
        End If
    End Sub

    Private Sub grid_employee_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_employee.CellClick
        Dim rowindex As Integer = grid_employee.CurrentRow.Index
        If grid_employee.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_employeeid.Text = grid_employee.Rows(rowindex).Cells(0).Value
            Dim name As String = grid_employee.Rows(rowindex).Cells(1).Value
            Dim splitprefix_name() As String = name.Split(" ")
            txt_employeename.Text = name.Substring(splitprefix_name(0).Length, name.Length - splitprefix_name(0).Length).Trim()
            'splitprefix_name(1)
            cbo_mprefix.SelectedIndex = cbo_mprefix.FindString(splitprefix_name(0))
            Dim empsex As String = grid_employee.Rows(rowindex).Cells(3).Value
            If empsex = "ชาย" Then
                rdo_employeesexM.Select()
            ElseIf empsex = "หญิง" Then
                rdo_employeesexF.Select()
            End If
            txt_employeeaddress.Text = grid_employee.Rows(rowindex).Cells(6).Value
            txt_employeephone.Text = grid_employee.Rows(rowindex).Cells(2).Value
            sql = "select emp_privilege,prefix_name,pos_name,emp_username,emp_password from employee(nolock) as a join prefix(nolock) as b on a.prefix_id = b.prefix_id join position(nolock) as c on a.pos_id = c.pos_id  where emp_id = " & grid_employee.Rows(rowindex).Cells(0).Value

            datatable = Obj_query.selectDatatoGrid(sql)
            Dim privi As String = datatable.Rows(0)("emp_privilege").ToString().Trim
            If privi = "Administrator" Then
                rdo_Admin.Select()
            ElseIf privi = "User" Then
                rdo_User.Select()
            End If

            cbo_employeeprefix.SelectedIndex = cbo_employeeprefix.FindString(datatable.Rows(0)("prefix_name").ToString().Trim)
            cbo_employeeposition.SelectedIndex = cbo_employeeposition.FindString(datatable.Rows(0)("pos_name").ToString().Trim)
            txt_employeeusername.Text = datatable.Rows(0)("emp_username").ToString().Trim
            txt_employeepass.Text = datatable.Rows(0)("emp_password").ToString().Trim
            txt_employeerepass.Text = datatable.Rows(0)("emp_password").ToString().Trim
            btn_addemployee.Visible = False
            btn_editemployee.Visible = True
            btn_delemployee.Visible = True
            txt_employeename.Focus()
        End If
    End Sub
    Private Sub cbo_employeeprefix_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_employeeprefix.SelectedIndexChanged
        If cbo_employeeprefix.Text = "นาย" Then
            rdo_employeesexM.Select()
            rdo_employeesexM.Enabled = True
            rdo_employeesexF.Enabled = False
        ElseIf cbo_employeeprefix.Text = "นาง" Or cbo_employeeprefix.Text = "นางสาว" Then
            rdo_employeesexF.Select()
            rdo_employeesexF.Enabled = True
            rdo_employeesexM.Enabled = False
        Else
            rdo_employeesexM.Select()
            rdo_employeesexF.Enabled = True
            rdo_employeesexM.Enabled = True
        End If
    End Sub
#End Region
#Region "tab_product"
    Private Sub btn_addproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addproduct.Click
        Dim prodname As String = txt_productname.Text
        Dim prodtype As Integer = cbo_productprodtype.SelectedValue
        Dim prodbrand As String = txt_productbrand.Text
        Dim prodqyt As Integer = 0
        Dim produnit1 As Integer = cbo_productunit1.SelectedValue
        Dim prodprice As Double = 0.0
        Dim produnit2 As String = cbo_productunit2.SelectedValue
        Dim prodcapacity As String = txt_productcapacity.Text
        Dim prodleadtime As Integer = 0
        If prodname <> "" And prodtype > 0 And prodbrand <> "" And Integer.TryParse(txt_productqty.Text, prodqyt) And produnit1 > 0 And produnit2 > 0 And Double.TryParse(txt_productprice.Text, prodprice) And Integer.TryParse(txt_productleadtime.Text, prodleadtime) Then
            Try
                sql =
                 " insert into product " &
                 " (prod_name,prod_leadtime,prod_qty,prod_price,prod_brand,prod_capacity,prod_type_id,unit_id,unit_id_cap) " &
                 " values('" & prodname & "'," & prodleadtime & "," & prodqyt & "," & prodprice & "," &
                 " '" & prodbrand & "','" & prodcapacity & "'," & prodtype & "," & produnit1 & "," & produnit2 & ")"
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

    Private Sub btn_editproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editproduct.Click
        Dim prodid As String = txt_productid.Text
        Dim prodname As String = txt_productname.Text
        Dim prodtype As Integer = cbo_productprodtype.SelectedValue
        Dim prodbrand As String = txt_productbrand.Text
        Dim prodqyt As Integer = 0
        Dim produnit1 As Integer = cbo_productunit1.SelectedValue
        Dim produnit2 As String = cbo_productunit2.SelectedValue
        Dim prodprice As Double = 0.0
        Dim prodcapacity As String = txt_productcapacity.Text

        Dim prodleadtime As Integer = 0
        If prodname <> "" And prodtype > 0 And prodbrand <> "" And Integer.TryParse(txt_productqty.Text, prodqyt) And produnit1 > 0 And produnit2 > 0 And Double.TryParse(txt_productprice.Text, prodprice) And Integer.TryParse(txt_productleadtime.Text, prodleadtime) Then
            Try
                sql =
                 " update product set " &
                 " prod_name = '" & prodname & "' ,prod_leadtime = " & prodleadtime & ",prod_qty = " & prodqyt &
                 ",prod_price = " & prodprice & "" &
                 ",prod_brand = '" & prodbrand & "' ,prod_capacity = '" & prodcapacity & "',prod_type_id = " & prodtype & ",unit_id = " & produnit1 & " " & ",unit_id_cap = " & produnit2 &
                 " where prod_id = " & prodid
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

    Private Sub btn_delproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delproduct.Click
        Dim prodid As String = txt_productid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบรายการผลิตภัณฑ์นี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If prodid <> "" Then
                Try
                    sql =
                  " delete from product " &
                  " where prod_id = " & prodid
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

    Private Sub btn_resetproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetproduct.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchproduct.Click

        Dim dropdownindex As Integer = cbo_searchproduct.SelectedIndex
        Dim textsearch As String = txt_searchproduct.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select prod_id 'รหัสผลิตภัณฑ์', prod_name 'ชื่อผลิตภัณฑ์', convert(varchar,(prod_qty)) 'จำนวนผลิตภัณฑ์', b.unit_name 'หน่วยนับผลิตภัณฑ์', convert(varchar,prod_price,1) 'ราคา',prod_brand 'ยี่ห้อ' ,prod_capacity 'ปริมาตร', d.unit_name 'หน่วยนับปริมาตร',c.prod_type_name 'ประเภทผลิตภัณฑ์',a.prod_leadtime 'จุดสั่งซื้อ' from product(nolock) as a join unit(nolock) as b on a.unit_id = b.unit_id join product_type(nolock) as c on a.prod_type_id = c.prod_type_id join unit d on a.unit_id_cap = d.unit_id where prod_id=" & textsearch & " order by prod_id"
            ElseIf dropdownindex = 2 Then
                sql = "select prod_id 'รหัสผลิตภัณฑ์', prod_name 'ชื่อผลิตภัณฑ์', convert(varchar,(prod_qty)) 'จำนวนผลิตภัณฑ์', b.unit_name 'หน่วยนับผลิตภัณฑ์', convert(varchar,prod_price,1) 'ราคา',prod_brand 'ยี่ห้อ' ,prod_capacity 'ปริมาตร', d.unit_name 'หน่วยนับปริมาตร',c.prod_type_name 'ประเภทผลิตภัณฑ์',a.prod_leadtime 'จุดสั่งซื้อ' from product(nolock) as a join unit(nolock) as b on a.unit_id = b.unit_id join product_type(nolock) as c on a.prod_type_id = c.prod_type_id join unit d on a.unit_id_cap = d.unit_id where prod_name like '" & textsearch & "%' or prod_name like '%" & textsearch & "%' or prod_name like '%" & textsearch & "'   order by prod_id"
            ElseIf dropdownindex = 3 Then
                sql = "select prod_id 'รหัสผลิตภัณฑ์', prod_name 'ชื่อผลิตภัณฑ์', convert(varchar,(prod_qty)) 'จำนวนผลิตภัณฑ์', b.unit_name 'หน่วยนับผลิตภัณฑ์', convert(varchar,prod_price,1) 'ราคา',prod_brand 'ยี่ห้อ' ,prod_capacity 'ปริมาตร', d.unit_name 'หน่วยนับปริมาตร',c.prod_type_name 'ประเภทผลิตภัณฑ์',a.prod_leadtime 'จุดสั่งซื้อ' from product(nolock) as a join unit(nolock) as b on a.unit_id = b.unit_id join product_type(nolock) as c on a.prod_type_id = c.prod_type_id join unit d on a.unit_id_cap = d.unit_id where c.prod_type_name  like '" & textsearch & "%' or c.prod_type_name like '%" & textsearch & "%' or c.prod_type_name like '%" & textsearch & "'   order by prod_id"
            ElseIf dropdownindex = 4 Then
                sql = "select prod_id 'รหัสผลิตภัณฑ์', prod_name 'ชื่อผลิตภัณฑ์', convert(varchar,(prod_qty)) 'จำนวนผลิตภัณฑ์', b.unit_name 'หน่วยนับผลิตภัณฑ์', convert(varchar,prod_price,1) 'ราคา',prod_brand 'ยี่ห้อ' ,prod_capacity 'ปริมาตร', d.unit_name 'หน่วยนับปริมาตร',c.prod_type_name 'ประเภทผลิตภัณฑ์',a.prod_leadtime 'จุดสั่งซื้อ' from product(nolock) as a join unit(nolock) as b on a.unit_id = b.unit_id join product_type(nolock) as c on a.prod_type_id = c.prod_type_id join unit d on a.unit_id_cap = d.unit_id where a.prod_brand  like '" & textsearch & "%' or a.prod_brand like '%" & textsearch & "%' or a.prod_brand like '%" & textsearch & "'   order by prod_id"
            End If
            GetDataToGrid(sql, grid_product)
        End If
    End Sub

    Private Sub grid_product_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_product.CellClick
        Dim rowindex As Integer = grid_product.CurrentRow.Index
        If grid_product.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_productid.Text = grid_product.Rows(rowindex).Cells(0).Value
            txt_productname.Text = grid_product.Rows(rowindex).Cells(1).Value
            txt_productqty.Text = grid_product.Rows(rowindex).Cells(2).Value
            cbo_productunit1.SelectedIndex = cbo_productunit1.FindString(grid_product.Rows(rowindex).Cells(3).Value)
            txt_productprice.Text = grid_product.Rows(rowindex).Cells(4).Value
            txt_productbrand.Text = grid_product.Rows(rowindex).Cells(5).Value
            txt_productcapacity.Text = grid_product.Rows(rowindex).Cells(6).Value
            cbo_productunit2.SelectedIndex = cbo_productunit2.FindString(grid_product.Rows(rowindex).Cells(7).Value)
            cbo_productprodtype.SelectedIndex = cbo_productprodtype.FindString(grid_product.Rows(rowindex).Cells(8).Value)
            txt_productleadtime.Text = grid_product.Rows(rowindex).Cells(9).Value
            btn_addproduct.Visible = False
            btn_editproduct.Visible = True
            btn_delproduct.Visible = True
            txt_productname.Focus()
        End If
    End Sub
#End Region
#Region "tab_promotion"

#End Region
#Region "totalcontrol"
    Private Sub tab_management_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_management.Click
        selectedIndex = tab_management.SelectedIndex
        UpdateDatainGrid(selectedIndex)
        clearData(selectedIndex)
    End Sub
    Private Sub UpdateDatainGrid(ByVal index As Integer)
        Dim myalltab() As String = {"customer", "employee", "product", "promotion"}
        If (emp_Privilage <> "" And emp_Privilage = "User" And index = 1) Then
            index = 2
        End If
        Dim sqlqueryeachtab(3) As String
        sqlqueryeachtab(0) = "select cus_id 'รหัสผู้ใช้บริการ',(b.prefix_name +' '+ cus_fullname)  'ชื่อผู้ใช้บริการ',cus_phone 'เบอร์โทรศัพท์',case when cus_sex = 'M' then 'ชาย' when cus_sex = 'F' then 'หญิง' end 'เพศ',cus_address 'ที่อยู่',convert(varchar,isnull(cus_money,0),1) 'วงเงิน',convert(varchar,isnull(cus_amount,0),1) 'วงเงินที่ใช้จริง' , c.custype_name 'ประเภทสมาชิก',convert(varchar(10),cus_regis,103) 'วันที่สมัคร' from customer(nolock) as a join prefix as b on a.prefix_id = b.prefix_id join customer_type as c on a.custype_id = c.custype_id order by cus_id"
        sqlqueryeachtab(1) = "select emp_id 'รหัสพนักงาน',(b.prefix_name +' '+ emp_fullname) 'ชื่อพนักงาน',emp_phone 'เบอร์โทรศัพท์',c.pos_name 'ตำแหน่ง',a.emp_username 'ชื่อผู้ใช้งานระบบ', CASE WHEN emp_sex = 'M' THEN 'ชาย'  WHEN emp_sex = 'F' THEN 'หญิง'  END 'เพศ',emp_address 'ที่อยู่' from employee(nolock) as a join prefix(nolock) as b on a.prefix_id = b.prefix_id join position(nolock) as c on a.pos_id = c.pos_id order by emp_id"
        sqlqueryeachtab(2) = "select prod_id 'รหัสผลิตภัณฑ์', prod_name 'ชื่อผลิตภัณฑ์', convert(varchar,(prod_qty)) 'จำนวนผลิตภัณฑ์', b.unit_name 'หน่วยนับผลิตภัณฑ์', convert(varchar,prod_price,1) 'ราคา',prod_brand 'ยี่ห้อ' ,prod_capacity 'ปริมาตร', d.unit_name 'หน่วยนับปริมาตร',c.prod_type_name 'ประเภทผลิตภัณฑ์',a.prod_leadtime 'จุดสั่งซื้อ' from product(nolock) as a join unit(nolock) as b on a.unit_id = b.unit_id join product_type(nolock) as c on a.prod_type_id = c.prod_type_id join unit d on a.unit_id_cap = d.unit_id order by prod_id "
        sqlqueryeachtab(3) = "select ROW_NUMBER() Over (order by prom_id) 'ลำดับ',prom_name 'ชื่อโปรโมชั่น' , prom_condition 'เงื่อนไข',convert(varchar,prom_price,1) 'ราคา' " +
                " ,convert(varchar(10),prom_startdate,103) 'วันที่เริ่มใช้' , convert(varchar(10),prom_enddate,103) 'วันที่สิ้นสุด',prom_id,isnull(prom_qty_free,'') prom_qty_free,isnull(prom_qty_used,'') prom_qty_used " +
                " ,isnull(prom_type ,'') prom_type ,'','',case when prom_type = 'S' then 'ส่วนลด' when prom_type = 'F' then 'แถม - ฟรี' when prom_type = 'P' then 'แถม - ฟรี' end 'ประเภทบริการ'" +
                " ,a.prom_regis from promotion a(nolock)  order by prom_id" ' p = packet but when show is free

        Dim havedropdown(,) As String =
        {
            {"0", "select prefix_id ID, prefix_name Name from prefix(nolock) order by prefix_id ", "0"},
            {"0", "select custype_id ID,custype_name Name from customer_type(nolock) order by custype_id", "1"},
            {"1", "select prefix_id ID, prefix_name Name from prefix(nolock) order by prefix_id ", "2"},
            {"1", "select pos_id ID,pos_name Name from position(nolock) order by pos_id ", "3"},
            {"2", "select prod_type_id ID,prod_type_name Name from product_type order by prod_type_id ", "4"},
            {"2", "select unit_id ID,unit_name Name from unit order by unit_id ", "5"},
            {"2", "select unit_id ID,unit_name Name from unit order by unit_id ", "6"},
            {"3", "select liserv_type_id ID,liserv_type_name Name from service_list_type order by liserv_type_id ", "7"},
            {"3", "select liserv_type_id ID,liserv_type_name Name from service_list_type order by liserv_type_id ", "8"},
            {"3", "select liserv_type_id ID,liserv_type_name Name from service_list_type order by liserv_type_id ", "9"}
        }
        Dim mygrid() As DataGridView = {grid_customer, grid_employee, grid_product, grid_promresult}
        Dim mycombobox() As ComboBox = {
            cbo_mprefix, cbo_mtypemem, cbo_employeeprefix, cbo_employeeposition,
            cbo_productprodtype, cbo_productunit1, cbo_productunit2, cbo_servlisttype, cbo_servlisttypeused, cbo_servlisttypefree
        }
        getCustomerType()
        For i As Integer = 0 To havedropdown.GetLength(0) - 1
            If (index.ToString() = havedropdown(i, 0)) Then
                GetDatatoCombobox(havedropdown(i, 1), mycombobox(Integer.Parse(havedropdown(i, 2))))
            End If
        Next
        GetDataToGrid(sqlqueryeachtab(index), mygrid(index))
    End Sub
    Private Sub getCustomerType()
        Dim query_sql = "select custype_id ID,custype_name Name from customer_type order by custype_id"
        Dim data_custype As DataTable = Obj_query.selectDatatoGrid(query_sql)
        grid_membertype.Rows.Clear()
        If data_custype.Rows.Count > 0 Then
            For Each row As DataRow In data_custype.Rows
                Dim datarow As String() = New String() {False, row(1), row(0)}
                grid_membertype.Rows.Add(datarow)
            Next
        End If
    End Sub
    Private Sub clearData(ByVal index)
        If (emp_Privilage <> "" And emp_Privilage = "User" And index = 1) Then
            index = 2
        End If
        If index = 0 Then
            canchangememtype = True
            'cbo_mtypemem.Enabled = True
            txt_amoney.Enabled = True
            txt_mmoney.Enabled = True
            txt_mid.Text = ""
            txt_mname.Text = ""
            txt_maddress.Text = ""
            txt_amoney.Text = ""
            txt_mmoney.Text = ""
            txt_mphone.Text = ""
            cbo_mprefix.SelectedIndex = 0
            cbo_mtypemem.SelectedIndex = 0
            If cbo_mprefix.Text = "นาย" Then
                rdo_msexM.Select()
            ElseIf cbo_mprefix.Text = "นาง" Or cbo_mprefix.Text = "นางสาว" Then
                rdo_msexF.Select()
            End If
            Dim typeid = cbo_mtypemem.SelectedValue
            If typeid > -1 Then
                sql = "select convert(varchar,custype_minlimit,1) money from customer_type(nolock) where custype_id = " & typeid
                datatable = Obj_query.selectDatatoGrid(sql)
                Dim minlimit = datatable.Rows(0)("money").ToString().Trim()
                txt_mmoney.Text = minlimit
                lbl_showlimit.Text = "กรุณาระบุจำนวนวงเงิน มากกว่า หรือ เท่ากับ " & minlimit
                lbl_showlimit.ForeColor = Color.Red
            End If
            btn_addmember.Visible = True
            btn_editmember.Visible = False
            btn_delmember.Visible = False
            btn_addmoney.Visible = False
            ' lbl_showlimit.Text = ""
        ElseIf index = 1 Then
            txt_employeeid.Text = ""
            txt_employeename.Text = ""
            txt_employeeaddress.Text = ""
            txt_employeephone.Text = ""
            txt_employeeusername.Text = ""
            txt_employeepass.Text = ""
            txt_employeerepass.Text = ""
            cbo_employeeposition.SelectedIndex = 0
            cbo_employeeprefix.SelectedIndex = 0
            rdo_User.Select()
            If cbo_employeeprefix.Text = "นาย" Then
                rdo_employeesexM.Select()
            ElseIf cbo_employeeprefix.Text = "นาง" Or cbo_employeeprefix.Text = "นางสาว" Then
                rdo_employeesexF.Select()
            End If
            btn_addemployee.Visible = True
            btn_editemployee.Visible = False
            btn_delemployee.Visible = False
        ElseIf index = 2 Then
            txt_productid.Text = ""
            txt_productname.Text = ""
            txt_productbrand.Text = ""
            txt_productcapacity.Text = ""
            txt_productleadtime.Text = ""
            txt_productprice.Text = ""
            txt_productqty.Text = ""
            cbo_productprodtype.SelectedIndex = 0
            cbo_productunit1.SelectedIndex = 0
            btn_addproduct.Visible = True
            btn_editproduct.Visible = False
            btn_delproduct.Visible = False
        ElseIf index = 3 Then
            nowis = "start"
            Dim totalproduct = grid_membertype.Rows.Count - 1
            While (totalproduct >= 0)
                grid_membertype.Rows(totalproduct).Cells(0).Value = False
                totalproduct -= 1
            End While
            chooseall = False
            custypeall = False
            chk_choosetypeall.Checked = False
            pal_price_packet.Visible = False
            txt_promotionprice.Enabled = False
            txt_qtyfree.Enabled = False
            txt_qtyused.Enabled = False
            chk_regismem.Checked = False
            pal_regismem.Visible = True
            rdo_do.Checked = False
            rdo_free.Checked = False
            txt_fullprice.Text = ""
            txt_price_packet.Text = ""
            txt_promotionid.Text = ""
            txt_promotionname.Text = ""
            txt_promotioncont.Text = ""
            txt_promotionprice.Text = ""
            dtp_promotionstart.Value = DateTime.Now()
            dtp_promotionend.Value = DateTime.Now()
            cbo_servlisttype.SelectedIndex = 0
            cbo_servlisttypeused.SelectedIndex = 0
            cbo_servlisttypefree.SelectedIndex = 0
            txt_servlistfree.Text = ""
            txt_qtyfree.Text = ""
            txt_qtyused.Text = ""
            txt_searchservused.Text = ""
            txt_searchservused_id.Text = ""
            cbo_promtype.SelectedIndex = 0
            txt_servlist.Text = ""
            grid_showpromprod.Rows.Clear()
            grid_servchoosedo.Rows.Clear()
            btn_addprom.Visible = True
            btn_editprom.Visible = False
            btn_delprom.Visible = False
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
        If selectedIndex = 3 Then
            If mygrid.Columns.Count > 10 Then
                mygrid.Columns(6).Visible = False
                mygrid.Columns(7).Visible = False
                mygrid.Columns(8).Visible = False
                mygrid.Columns(9).Visible = False
                mygrid.Columns(10).Visible = False
                mygrid.Columns(13).Visible = False
            End If
        End If
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

    Private Sub form_mainmgr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectedIndex = 0
        UpdateDatainGrid(selectedIndex)
        cbo_promtype.SelectedIndex = 0
    End Sub
    Private Sub form_mainmgr_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim leadtimeproductsql As String = "select prod_id 'รหัส',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',d.prod_type_name 'ประเภทสินค้า',convert(varchar,prod_price,1) 'ราคาสินค้า','บาท' 'หน่วยนับ',a.prod_qty 'จำนวนสินค้า',b.unit_name 'หน่วยนับ',prod_capacity 'ปริมาตร',c.unit_name 'หน่วยนับปริมาตร' from product a(nolock) join unit b(nolock) on a.unit_id = b.unit_id join unit c on a.unit_id_cap = c.unit_id join product_type d on a.prod_type_id = d.prod_type_id  where (prod_qty - prod_leadtime) between (prod_leadtime * -1) and 2 order by prod_id"
        GetDataToGrid(leadtimeproductsql, form_home.grid_alertproduct)
        form_home.Enabled = True
    End Sub 'Form1_Closing

    Private Sub cbo_searchmember_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchmember.SelectedIndexChanged
        If cbo_searchmember.SelectedIndex = 0 Then
            txt_searchmember.Text = ""
        End If
    End Sub

    Private Sub cbo_searchemployee_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchemployee.SelectedIndexChanged
        If cbo_searchemployee.SelectedIndex = 0 Then
            txt_searchemployee.Text = ""
        End If
    End Sub

    Private Sub cbo_searchproduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchproduct.SelectedIndexChanged
        If cbo_searchproduct.SelectedIndex = 0 Then
            txt_searchproduct.Text = ""
        End If
    End Sub

    Private Sub cbo_searchprom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchprom.SelectedIndexChanged
        If cbo_searchprom.SelectedIndex = 0 Then
            txt_searchprom.Text = ""
        End If
    End Sub
    Private Sub btn_searchproductprom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchproductprom.Click
        servlistidselect = cbo_servlisttype.SelectedValue
        servtypeshow = "normal"
        form_showservlist2.Show()
    End Sub
    Private Sub btn_searchservused_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchservused.Click
        servlistidselect = cbo_servlisttypeused.SelectedValue
        servtypeshow = "used"
        form_showservlist2.Show()
    End Sub

    Private Sub btn_delproductprom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delproductprom.Click
        Dim totalproduct = grid_showpromprod.Rows.Count - 1
        While (totalproduct >= 0)
            grid_showpromprod.Rows(totalproduct).Cells(0).Value = True
            totalproduct -= 1
        End While
    End Sub

    Private Sub btn_addprom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addprom.Click
        Dim promname As String = txt_promotionname.Text
        Dim promcont As String = txt_promotioncont.Text
        Dim promstart As String = dtp_promotionstart.Value.ToString("yyyy-MM-dd")
        Dim promend As String = dtp_promotionend.Value.ToString("yyyy-MM-dd")
        Dim promprice As Double = 0.0
        Dim prodtypeid As Integer = cbo_promtype.SelectedIndex
        Dim qtyfree As String = txt_qtyfree.Text
        Dim qtyused As String = txt_qtyused.Text
        Dim servusedid As String = txt_searchservused_id.Text
        Dim onlyregis As String = ""
        If chk_regismem.Checked = True Then
            onlyregis = "Y"
        Else
            onlyregis = "N"
        End If
        If promname <> "" And promstart <> "" And promend <> "" Then
            Try
                If prodtypeid = 0 Then ' ส่วนลด
                    If Double.TryParse(txt_promotionprice.Text, promprice) Then
                        sql =
              " insert into promotion " &
              " (prom_name,prom_condition,prom_price,prom_startdate,prom_enddate,prom_type,prom_regis) " &
              " values('" & promname & "','" & promcont & "' ," & promprice & " ,convert(datetime,'" & promstart & "'),convert(datetime,'" & promend & "') ,'S','" & onlyregis & "')"
                    End If
                ElseIf prodtypeid = 1 Then ' แถม ฟรี
                    Dim qtyint As Integer = 0
                    Dim qtyusedint As Integer = 0
                    If Integer.TryParse(qtyfree, qtyint) Or Integer.TryParse(qtyfree, qtyusedint) Then
                        Dim typepromfree As String = "F"
                        Dim prom_price_packet As Double = 0.0
                        If chooseall = True Then
                            typepromfree = "P"
                            If Not Double.TryParse(txt_price_packet.Text, prom_price_packet) Then
                                prom_price_packet = 0.0
                            End If
                        End If
                        sql =
              " insert into promotion " &
              " (prom_name,prom_condition,prom_price,prom_startdate,prom_enddate,prom_qty_free,prom_type,prom_qty_used,prom_regis) " &
              " values('" & promname & "','" & promcont & "' ," & prom_price_packet & " ,convert(datetime,'" & promstart & "'),convert(datetime,'" & promend & "')," & qtyint & " ,'" & typepromfree & "'," & qtyusedint & " ,'" & onlyregis & "')"
                    End If
                End If
                If Obj_query.DMLData(sql) Then
                    'MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                    sql = ""
                    Dim promid As String = Obj_query.selectdataInt("select IDENT_CURRENT('promotion')").ToString()
                    If promid <> "" Then
                        For Each r As DataGridViewRow In grid_showpromprod.Rows
                            Dim servlistid As String = r.Cells(5).Value.ToString()
                            If servlistid <> "" Then
                                Dim sqlchkdup As String = "select count(*) from promotion_detail where prom_id = " & promid & " and liserv_id = " & servlistid
                                If Obj_query.selectdataInt(sqlchkdup) <= 0 Then
                                    sql &= " insert into promotion_detail (liserv_id,prom_id) " &
                                    " values (" & servlistid & " ," & promid & ") "
                                End If
                            End If
                        Next
                        For Each r As DataGridViewRow In grid_membertype.Rows
                            Dim custype_id As String = r.Cells(2).Value.ToString()
                            If r.Cells(0).Value = True And custype_id <> "" Then
                                Dim sqlchkdup As String = "select count(*) from customer_type_promotion where prom_id = " & promid & " and custype_id = " & custype_id
                                If Obj_query.selectdataInt(sqlchkdup) <= 0 Then
                                    sql &= " insert into customer_type_promotion (prom_id,custype_id) " &
                                    " values (" & promid & "," & custype_id & ") "
                                End If
                            End If
                        Next
                        If prodtypeid = 1 Then 'ต้องทำบริการก่อนแถม
                            For Each r As DataGridViewRow In grid_servchoosedo.Rows
                                Dim servlistid As String = r.Cells(5).Value.ToString()
                                If servlistid <> "" Then
                                    Dim sqlchkdup As String = "select count(*) from service_promotion where prom_id = " & promid & " and liserv_id = " & servlistid
                                    If Obj_query.selectdataInt(sqlchkdup) <= 0 Then
                                        sql &= " insert into service_promotion (prom_id,liserv_id) " &
                                        " values (" & promid & "," & servlistid & ") "
                                    End If
                                End If
                            Next
                        End If
                        If Obj_query.DMLData(sql) Then
                            MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว")
                            UpdateDatainGrid(selectedIndex)
                            clearData(selectedIndex)
                        Else
                            sql = "delete from promotion where prom_id = " & promid
                            Obj_query.DMLData(sql)
                            MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                        End If
                    End If


                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString())
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try

        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_resetprom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetprom.Click
        clearData(selectedIndex)
    End Sub

    Private Sub grid_promresult_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_promresult.CellClick
        nowis = "edit"
        rdo_do.Checked = False
        rdo_free.Checked = False
        pal_do.Visible = False
        pal_free.Visible = False
        grp_servshow.Visible = False
        pal_regismem.Visible = True
        Dim rowindex As Integer = grid_promresult.CurrentRow.Index
        If grid_promresult.Rows(rowindex).Cells(1).Value.ToString <> "" Then
            txt_promotionid.Text = grid_promresult.Rows(rowindex).Cells(6).Value
            txt_promotionname.Text = grid_promresult.Rows(rowindex).Cells(1).Value
            txt_promotioncont.Text = grid_promresult.Rows(rowindex).Cells(2).Value
            txt_promotionprice.Text = grid_promresult.Rows(rowindex).Cells(3).Value
            txt_price_packet.Text = grid_promresult.Rows(rowindex).Cells(3).Value
            dtp_promotionstart.Value = grid_promresult.Rows(rowindex).Cells(4).Value
            dtp_promotionend.Value = grid_promresult.Rows(rowindex).Cells(5).Value
            txt_qtyfree.Text = grid_promresult.Rows(rowindex).Cells(7).Value
            txt_qtyused.Text = grid_promresult.Rows(rowindex).Cells(8).Value
            Dim flag_regis As String = grid_promresult.Rows(rowindex).Cells(13).Value
            If flag_regis = "Y" Then
                chk_regismem.Checked = True
            ElseIf flag_regis = "N" Then
                chk_regismem.Checked = False
            End If
            Dim promtype As String = grid_promresult.Rows(rowindex).Cells(9).Value.ToString()
            If promtype = "S" Then
                cbo_promtype.SelectedIndex = 0
                grp_servshow.Visible = False
            ElseIf promtype = "F" Then
                cbo_promtype.SelectedIndex = 1
                grp_servshow.Visible = True
            ElseIf promtype = "P" Then
                pal_regismem.Visible = False
                cbo_promtype.SelectedIndex = 1
                grp_servshow.Visible = True
                chooseall = True
                pal_price_packet.Visible = True
                'ElseIf promtype = "P" Then
                '    cbo_promtype.SelectedIndex = 3
                '    grp_servshow.Visible = False
            End If
            grid_showpromprod.Rows.Clear()
            sql = "select ROW_NUMBER() over (order by b.liserv_id) 'ลำดับ',b.liserv_name 'รายการบริการ' , c.liserv_type_name 'ประเภทรายการบริการ' " +
                " , convert(varchar,b.liserv_price,1) 'ราคา' , b.liserv_id,a.deprom_id from promotion_detail a(nolock) " +
                " join service_list b(nolock) on a.liserv_id = b.liserv_id " +
                " join service_list_type c(nolock) on b.liserv_type_id = c.liserv_type_id " +
                " where a.prom_id = " & txt_promotionid.Text
            datatable = Obj_query.selectDatatoGrid(sql)
            For i As Integer = 0 To datatable.Rows.Count - 1
                Dim row As String() = New String() {False, datatable.Rows(i)(0), datatable.Rows(i)(1), datatable.Rows(i)(2), datatable.Rows(i)(3), datatable.Rows(i)(4), datatable.Rows(i)(5)}
                grid_showpromprod.Rows.Add(row)
            Next
            sql = "select b.custype_id,b.custype_name from customer_type_promotion a(nolock) " &
                " join customer_type b(nolock) on a.custype_id =  b.custype_id " &
                " where a.prom_id = " & txt_promotionid.Text
            datatable = Obj_query.selectDatatoGrid(sql)
            For Each d As DataGridViewRow In grid_membertype.Rows
                d.Cells(0).Value = False
            Next
            For i As Integer = 0 To datatable.Rows.Count - 1
                For Each d As DataGridViewRow In grid_membertype.Rows
                    If datatable.Rows(i)(0) = d.Cells(2).Value.ToString Then
                        d.Cells(0).Value = True
                    End If
                Next
            Next

            If promtype = "F" Or promtype = "P" Then
                grid_servchoosedo.Rows.Clear()
                sql = "select ROW_NUMBER() over (order by b.liserv_id) 'ลำดับ',b.liserv_name 'รายการบริการ' , c.liserv_type_name 'ประเภทรายการบริการ' " +
                " , convert(varchar,b.liserv_price,1) 'ราคา' , b.liserv_id,a.serv_promid from service_promotion a(nolock) " +
                " join service_list b(nolock) on a.liserv_id = b.liserv_id " +
                " join service_list_type c(nolock) on b.liserv_type_id = c.liserv_type_id " +
                " where a.prom_id = " & txt_promotionid.Text
                datatable = Obj_query.selectDatatoGrid(sql)
                For i As Integer = 0 To datatable.Rows.Count - 1
                    Dim row As String() = New String() {False, datatable.Rows(i)(0), datatable.Rows(i)(1), datatable.Rows(i)(2), datatable.Rows(i)(3), datatable.Rows(i)(4), datatable.Rows(i)(5)}
                    grid_servchoosedo.Rows.Add(row)
                Next
            End If
            If grid_showpromprod.Rows.Count > 0 Then
                If promtype = "S" Then
                    txt_promotionprice.Enabled = True
                ElseIf promtype = "F" Then
                    txt_qtyfree.Enabled = True
                End If
            End If
            If grid_servchoosedo.Rows.Count > 0 Then
                If promtype = "P" Or promtype = "F" Then
                    txt_qtyused.Enabled = True
                End If
            End If
            btn_addprom.Visible = False
            btn_editprom.Visible = True
            btn_delprom.Visible = True
        End If
    End Sub

    Private Sub btn_editprom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editprom.Click
        Dim promid As String = txt_promotionid.Text
        Dim promname As String = txt_promotionname.Text
        Dim promcont As String = txt_promotioncont.Text
        Dim promstart As String = dtp_promotionstart.Value.ToString("yyyy-MM-dd")
        Dim promend As String = dtp_promotionend.Value.ToString("yyyy-MM-dd")
        Dim promprice As Double = 0.0
        Dim prodtypeid As Integer = cbo_promtype.SelectedIndex
        Dim qtyfree As String = txt_qtyfree.Text
        Dim qtyused As String = txt_qtyused.Text
        Dim servusedid As String = txt_searchservused_id.Text
        Dim onlyregis As String = ""
        If chk_regismem.Checked = True Then
            onlyregis = "Y"
        Else
            onlyregis = "N"
        End If
        If promname <> "" And promstart <> "" And promend <> "" Then
            Try
                If prodtypeid = 0 Then ' ส่วนลด
                    If Double.TryParse(txt_promotionprice.Text, promprice) Then
                        sql =
              " update promotion set " &
              " prom_name = '" & promname & "',prom_condition = '" & promcont & "'" &
              " ,prom_price = " & promprice & ",prom_startdate = convert(datetime,'" & promstart & "'),prom_enddate = convert(datetime,'" & promend & "') " &
              " ,prom_type = 'S' , prom_qty_free = 0 ,prom_regis = '" & onlyregis & "'" &
              " where prom_id = " & promid
                    End If
                ElseIf prodtypeid = 1 Then ' แถม ฟรี
                    Dim qtyint As Integer = 0
                    Dim qtyusedint As Integer = 0
                    Dim typepromfree As String = "F"
                    Dim prom_price_packet As Double = 0.0
                    If chooseall = True Then
                        typepromfree = "P"
                        If Not Double.TryParse(txt_price_packet.Text, prom_price_packet) Then
                            prom_price_packet = 0.0
                        End If
                    End If
                    If Integer.TryParse(qtyfree, qtyint) And Integer.TryParse(qtyused, qtyusedint) Then
                        sql =
             " update promotion set " &
             " prom_name = '" & promname & "',prom_condition = '" & promcont & "'" &
             ",prom_price = " & prom_price_packet & " ,prom_startdate = convert(datetime,'" & promstart & "'),prom_enddate = convert(datetime,'" & promend & "') " &
             ",prom_qty_free = " & qtyint & ",prom_type = '" & typepromfree & "',prom_qty_used = " & qtyusedint & " , prom_regis = '" & onlyregis & "'" &
             " where prom_id = " & promid
                    End If
                End If

                If Obj_query.DMLData(sql) Then
                    sql = ""
                    If promid <> "" Then
                        For Each r As DataGridViewRow In grid_showpromprod.Rows
                            Dim servlistid As String = r.Cells(5).Value.ToString()
                            If servlistid <> "" Then
                                Dim sqlchkdup As String = "select count(*) from promotion_detail where prom_id = " & promid & " and liserv_id = " & servlistid
                                If Obj_query.selectdataInt(sqlchkdup) <= 0 Then
                                    sql &= " insert into promotion_detail (liserv_id,prom_id) " +
                                    " values (" & servlistid & " ," & promid & ") "
                                End If
                            End If
                        Next
                        For Each r As DataGridViewRow In grid_membertype.Rows
                            Dim custype_id As String = r.Cells(2).Value.ToString()
                            If r.Cells(0).Value = True And custype_id <> "" Then
                                Dim sqlchkdup As String = "select count(*) from customer_type_promotion where prom_id = " & promid & " and custype_id = " & custype_id
                                If Obj_query.selectdataInt(sqlchkdup) <= 0 Then
                                    sql &= " insert into customer_type_promotion (prom_id,custype_id) " &
                                    " values (" & promid & "," & custype_id & ") "
                                End If
                            End If
                        Next
                        If prodtypeid = 1 Then 'ต้องทำบริการก่อนแถม
                            For Each r As DataGridViewRow In grid_servchoosedo.Rows
                                Dim servlistid As String = r.Cells(5).Value.ToString()
                                If servlistid <> "" Then
                                    Dim sqlchkdup As String = "select count(*) from service_promotion where prom_id = " & promid & " and liserv_id = " & servlistid
                                    If Obj_query.selectdataInt(sqlchkdup) <= 0 Then
                                        sql &= " insert into service_promotion (prom_id,liserv_id) " &
                                        " values (" & promid & "," & servlistid & ") "
                                    End If
                                End If
                            Next
                        End If
                        If sql <> "" Then
                            If Obj_query.DMLData(sql) Then
                                MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                                UpdateDatainGrid(selectedIndex)
                                clearData(selectedIndex)
                            Else
                                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                            End If
                        Else
                            MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
                        End If

                    End If
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString())
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ข้อมูลไม่ถูกต้อง")
            End Try

        Else
            MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
        End If
    End Sub

    Private Sub btn_delprom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delprom.Click
        Dim promid As String = txt_promotionid.Text
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการลบโปรโมชั่นนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim deldetailsuccess = False
        If answer = vbYes Then
            If (promid <> "") Then
                If grid_showpromprod.Rows.Count > 0 Then
                    Dim totalservlist = grid_showpromprod.Rows.Count - 1
                    While (totalservlist >= 0)
                        Dim detailpromid As String = grid_showpromprod.Rows(totalservlist).Cells(6).Value
                        If grid_showpromprod.Rows(totalservlist).Cells(0).Value = True Then
                            sql &= " delete from promotion_detail where deprom_id = " & detailpromid
                            grid_showpromprod.Rows.RemoveAt(totalservlist)
                        End If
                        totalservlist -= 1
                    End While
                End If
                If grid_servchoosedo.Rows.Count > 0 Then
                    Dim totalservlist = grid_servchoosedo.Rows.Count - 1
                    While (totalservlist >= 0)
                        Dim serv_promid As String = grid_servchoosedo.Rows(totalservlist).Cells(6).Value
                        If grid_servchoosedo.Rows(totalservlist).Cells(0).Value = True Then
                            sql &= " delete from service_promotion where serv_promid = " & serv_promid
                            grid_servchoosedo.Rows.RemoveAt(totalservlist)
                        End If
                        totalservlist -= 1
                    End While
                End If
                If grid_showpromprod.Rows.Count = 0 Or grid_servchoosedo.Rows.Count = 0 Then
                    sql &= " delete from service_promotion where prom_id = " & promid
                    sql &= " delete from customer_type_promotion where prom_id = " & promid
                    sql &= " delete from promotion_detail where prom_id = " & promid

                    sql &= " delete from promotion where prom_id = " & promid
                    clearData(selectedIndex)
                End If

                If Obj_query.DMLData(sql) Then
                    MsgBox("ลบการโปรโมชั่นเรียบร้อยแล้ว")
                Else
                    MsgBox("มีบางข้อมูลอาจจะ ลบไม่ได้ กรุณาตรวจสอบ หรือ ข้อมูลอาจจะมีการใช้งานอยู่")
                End If
            Else
                MsgBox("ข้อมูลบาง field ไม่ถูกต้อง")
            End If
        End If
        UpdateDatainGrid(selectedIndex)
    End Sub

    Private Sub btn_searchprom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchprom.Click
        Dim dropdownindex As Integer = cbo_searchprom.SelectedIndex
        Dim textsearch As String = txt_searchprom.Text
        If dropdownindex <> -1 And (textsearch <> "" Or dropdownindex = 0) Then
            If dropdownindex = 0 Then
                UpdateDatainGrid(selectedIndex)
            ElseIf dropdownindex = 1 Then
                sql = "select ROW_NUMBER() Over (order by prom_id) 'ลำดับ',prom_name 'ชื่อโปรโมชั่น' , prom_condition 'เงื่อนไข',convert(varchar,prom_price,1) 'ราคา' " &
                " ,convert(varchar(10),prom_startdate,103) 'วันที่เริ่มใช้' , convert(varchar(10),prom_enddate,103) 'วันที่สิ้นสุด',prom_id,isnull(prom_qty_free,'') prom_qty_free " &
                " ,isnull(prom_type ,'') prom_type ,'','',case when prom_type = 'S' then 'ส่วนลด' when prom_type = 'F' then 'แถม - ฟรี' when prom_type = 'D' then 'ทำบริการ(แถม)' end 'ประเภทบริการ'" &
                " ,a.prom_regis from promotion a(nolock)" &
                " where a.prom_name like '" & textsearch & "%' or a.prom_name like '%" & textsearch & "%' or a.prom_name like '%" & textsearch & "' order by prom_id"
                GetDataToGrid(sql, grid_promresult)
            End If
        End If
    End Sub

    Private Sub cbo_promtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_promtype.SelectedIndexChanged
        Dim index As Integer = cbo_promtype.SelectedIndex
        If index > 0 Then
            Dim flagmem_isall = True
            For Each memtype As DataGridViewRow In grid_membertype.Rows
                If memtype.Cells(0).Value = False Then
                    flagmem_isall = False
                    Exit For
                End If
            Next
            If flagmem_isall = True And nowis = "start" Then
                chooseall = True
                pal_regismem.Visible = False
                pal_price_packet.Visible = True
            End If
        End If
        If nowis = "start" Then
            If cbo_servlisttype.Items.Count > 0 And cbo_servlisttypeused.Items.Count > 0 And cbo_servlisttypefree.Items.Count > 0 Then
                txt_promotionprice.Text = ""
                txt_servlistfree.Text = ""
                txt_qtyfree.Text = ""
                txt_qtyused.Text = ""
                txt_searchservused.Text = ""
                txt_searchservused_id.Text = ""
                txt_servlist.Text = ""
                cbo_servlisttype.SelectedIndex = 0
                cbo_servlisttypeused.SelectedIndex = 0
                cbo_servlisttypefree.SelectedIndex = 0
            End If
        End If
        If index = 0 Then
            pal_sale.Visible = True
            pal_do.Visible = False
            pal_free.Visible = False
            rdo_free.Visible = False
            rdo_do.Visible = False
        ElseIf index = 1 Then
            pal_sale.Visible = False
            pal_do.Visible = False
            pal_free.Visible = False
            rdo_free.Visible = True
            rdo_do.Visible = True
        End If
    End Sub

    Private Sub btn_selectallservchoo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_selectallservchoo.Click
        Dim totalproduct = grid_servchoosedo.Rows.Count - 1
        While (totalproduct >= 0)
            grid_servchoosedo.Rows(totalproduct).Cells(0).Value = True
            totalproduct -= 1
        End While
    End Sub

    Private Sub cbo_servlisttypefree_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_servlisttypefree.SelectedIndexChanged
        'Dim servtype As String = cbo_servlisttype.SelectedValue
        'sql = "select liserv_id ID,liserv_name Name from service_list where liserv_type_id = " & servtype & " order by liserv_id  "
        'GetDatatoCombobox(sql, cbo_servlisttype)
    End Sub

    Private Sub btn_searchproductpromfree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchproductpromfree.Click
        servlistidselect = cbo_servlisttypefree.SelectedValue
        servtypeshow = "normal"
        form_showservlist2.Show()
    End Sub

    Private Sub grid_membertype_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_membertype.CellClick
        If grid_membertype.CurrentCell.ColumnIndex.Equals(0) Then
            If cbo_promtype.SelectedIndex > 0 Then
                pal_regismem.Visible = True
                pal_price_packet.Visible = False
                chooseall = False
            End If
        End If
    End Sub

    Private Sub rdo_free_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_free.CheckedChanged
        pal_free.Visible = True
        pal_do.Visible = False
        grp_servshow.Visible = False
    End Sub

    Private Sub rdo_do_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_do.CheckedChanged
        pal_free.Visible = False
        pal_do.Visible = True
        grp_servshow.Visible = True
    End Sub

    Private Sub txt_qtyused_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtyused.KeyPress
        
    End Sub

    Private Sub grid_promresult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_promresult.CellContentClick

    End Sub

    Private Sub txt_qtyused_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_qtyused.KeyUp
        If grid_servchoosedo.Rows.Count > 0 Then
            Dim qty_used As Double = 0
            Dim packetprice As Double = 0
            If Double.TryParse(txt_qtyused.Text, qty_used) And txt_qtyused.Text <> "" Then
                For Each row As DataGridViewRow In grid_servchoosedo.Rows
                    Dim servprice As Double = Double.Parse(row.Cells(4).Value)
                    packetprice += servprice * qty_used
                Next
                txt_price_packet.Text = packetprice.ToString("#,##0.00")
                lbl_msg.Text = ""
            Else
                lbl_msg.Text = "เป็นตัวเลขเท่านั้น"
            End If

        End If
    End Sub

    Private Sub grid_showpromprod_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grid_showpromprod.RowsAdded
        If grid_showpromprod.Rows.Count > 0 Then
            Dim priceall As Double = 0.0
            For Each promlist As DataGridViewRow In grid_showpromprod.Rows
                priceall += Double.Parse(promlist.Cells(4).Value.ToString())
            Next
            txt_fullprice.Text = priceall.ToString("#,##0.00")
        End If
    End Sub

    Private Sub grid_membertype_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_membertype.CellContentClick

    End Sub

    Private Sub chk_choosetypeall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_choosetypeall.CheckedChanged
        If custypeall = False Then
            If cbo_promtype.SelectedIndex > 0 Then
                chooseall = True
                pal_regismem.Visible = False
                pal_price_packet.Visible = True
            End If
            Dim totalproduct = grid_membertype.Rows.Count - 1
            While (totalproduct >= 0)
                grid_membertype.Rows(totalproduct).Cells(0).Value = True
                totalproduct -= 1
            End While
            custypeall = True
        Else
            If cbo_promtype.SelectedIndex > 0 Then
                chooseall = False
                pal_regismem.Visible = False
                pal_price_packet.Visible = True
            End If
            Dim totalproduct = grid_membertype.Rows.Count - 1
            While (totalproduct >= 0)
                grid_membertype.Rows(totalproduct).Cells(0).Value = False
                totalproduct -= 1
            End While
            custypeall = False
        End If
        
    End Sub

End Class