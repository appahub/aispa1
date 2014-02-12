Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_in_out
    Dim sql As String = ""
    Dim Obj_query As New classquery()
    Dim DataTable As DataTable
    Dim selectedIndex As Integer
    Dim searchbyindex As Integer
    Dim typeseach As Integer
    Private Sub btn_addinout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addinout.Click
        Dim inout_id As String = txt_inout.Text
        Dim mydate As Date = Date.Parse(txt_showdate.Text)
        Dim inout_time As String = mydate.ToString("yyyy-MM-dd HH:mm")
        Dim inout_timechk As String = mydate.ToString("yyyyMMdd HH:mm")
        Dim answer As DialogResult
        answer = MessageBox.Show("คุณต้องการบันทึกรายการเข้า-ออกงานนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            If (inout_id <> "" And inout_time <> "") Then
                sql = "select in_out_id,isnull(CONVERT(varchar,in_out_end),'') from in_out(nolock) where convert(varchar(8),in_out_start,112) = '" & inout_timechk.Substring(0, 8) & "'" &
                " and emp_id = " & inout_id
                DataTable = Obj_query.selectDatatoGrid(sql)
                If DataTable.Rows.Count > 0 Then
                    If DataTable.Rows(0).Item(1).ToString() = "" Then
                        sql =
                    " update in_out set" &
                    " in_out_end = '" & inout_time & "' where emp_id =  " & inout_id & " and in_out_id = " & DataTable.Rows(0).Item(0).ToString()
                    Else
                        MsgBox("ไม่สามารถบันทึกเวลาได้เนื่องจาก มีการบันทึกเวลา เข้า-ออก งานเรียบร้อยแล้ว")
                        sql = ""
                    End If
                Else
                    sql =
                     " insert into in_out " &
                     " (in_out_start,emp_id) " &
                     " values('" & inout_time & "'," & inout_id & ")"
                End If

                If Obj_query.DMLData(sql) Then
                    MsgBox("บันทึกเวลาเรียบร้อยแล้ว")
                    UpdateDatainGrid(selectedIndex)
                    clearData(selectedIndex)
                Else
                    If sql <> "" Then
                        MsgBox("ไม่สามารถบันทึกเวลาได้เนื่องจาก ข้อมูลผิดพลาด")
                    End If
                End If
            Else
                MsgBox("กรุณากรอกข้อมูลให้ถูกต้อง")
            End If
        Else
            MsgBox("ยกเลิกการบันทึกการเข้า-ออกงาน")
        End If
    End Sub
    Private Sub UpdateDatainGrid(ByVal index As Integer)
        'Dim myalltab() As String = {"customer", "employee", "product"}
        Dim sqlqueryeachtab(2) As String
        sqlqueryeachtab(0) = "select emp_fullname 'ชื่อพนักงาน',in_out_start 'วัน-เวลา เข้างาน',in_out_end 'วัน-เวลา ออกงาน' from in_out as a join employee as b on a.emp_id = b.emp_id  where convert(varchar(10),in_out_start,103) = convert(varchar(10),GETDATE(),103) order by in_out_start"
        sqlqueryeachtab(1) = "select emp_fullname 'ชื่อพนักงาน',in_out_start 'วัน-เวลา เข้างาน',in_out_end 'วัน-เวลา ออกงาน' from in_out as a join employee as b on a.emp_id = b.emp_id  where convert(varchar(10),in_out_start,103) = convert(varchar(10),GETDATE(),103) order by in_out_start"
        Dim mygrid() As DataGridView = {grid_showinout, grid_searchinout}
        GetDataToGrid(sqlqueryeachtab(index), mygrid(index))
        Dim havedropdown(,) As String =
        {
            {"0", "select pos_id ID,pos_name Name from position(nolock) order by pos_id ", "0"},
            {"1", "select pos_id ID,pos_name Name from position(nolock) order by pos_id ", "1"}
        }
        Dim mycombobox() As ComboBox = {
               cbo_inoutpos, cbo_searchinout
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
    Private Sub clearData(ByVal index)
        If index = 0 Then
            txt_inout.Text = ""
            txt_empname.Text = ""
        ElseIf index = 1 Then
            txt_searchinout.Text = ""
        End If
    End Sub
    Private Sub GetDataToGrid(ByVal mysql As String, ByVal mygrid As DataGridView)
        sql = mysql
        DataTable = Obj_query.selectDatatoGrid(sql)
        If DataTable.Rows.Count < 0 Then
            DataTable.Rows.Add(New Object() {1, "ไม่มีข้อมูล"})
        End If
        With mygrid
            .AutoGenerateColumns = True
            .DataSource = DataTable
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Font = New Font("Microsoft Sans Serif", 10)
        End With
    End Sub
    Private Sub tab_management_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_management.Click
        selectedIndex = tab_management.SelectedIndex
        txt_showdate.Text = DateTime.Now().ToString("dd/MM/yyyy HH:mm")
        dtp_searchinout.Value = DateTime.Now()
        UpdateDatainGrid(selectedIndex)
        clearData(selectedIndex)
    End Sub
    Private Sub form_in_out_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectedIndex = 0
        UpdateDatainGrid(selectedIndex)
        lbl_showcurrentdate.Text = "วันที่ " + DateTime.Now().ToString("dd MMMM yyyy  เวลา HH:mm น.")
        cbo_searchby.SelectedIndex = 0
        txt_showdate.Text = DateTime.Now().ToString("dd/MM/yyyy HH:mm")
        autoUpdate.Enabled = True
    End Sub
    Private Sub form_in_out_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim leadtimeproductsql As String = "select prod_id 'รหัส',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',d.prod_type_name 'ประเภทสินค้า',convert(varchar,prod_price,1) 'ราคาสินค้า','บาท' 'หน่วยนับ',a.prod_qty 'จำนวนสินค้า',b.unit_name 'หน่วยนับ',prod_capacity 'ปริมาตร',c.unit_name 'หน่วยนับปริมาตร' from product a(nolock) join unit b(nolock) on a.unit_id = b.unit_id join unit c on a.unit_id_cap = c.unit_id join product_type d on a.prod_type_id = d.prod_type_id  where (prod_qty - prod_leadtime) between (prod_leadtime * -1) and 2 order by prod_id"
        GetDataToGrid(leadtimeproductsql, form_home.grid_alertproduct)
        form_home.Enabled = True
        autoUpdate.Enabled = False
    End Sub 'Form1_Closing

    Private Sub btn_searchmemid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchmemid.Click
        If selectedIndex = 0 Then
            getEmployeeformpage = 1
        End If
        form_showEmployee.Show()
    End Sub

    Private Sub btn_searchmemid2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchmemid2.Click
        If selectedIndex = 1 Then
            getEmployeeformpage = 2
        End If
        form_showEmployee.Show()
    End Sub

    Private Sub btn_resetsearchinout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clearData(selectedIndex)
    End Sub

    Private Sub btn_resetinout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetinout.Click
        clearData(selectedIndex)
    End Sub

    Private Sub btn_searchinout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchinout.Click
        Dim inout_id As String = txt_searchinout.Text
        Dim inout_timechk As String = ""
        Dim condition As String = ""
        If searchbyindex = 0 Then ' ค้นหาจากวันที่
            inout_timechk = dtp_searchinout.Value.ToString("yyyyMMdd")
            condition = " where convert(varchar(10),in_out_start,112) = '" & inout_timechk & "'"
            If (inout_timechk <> "") Then
                sql = "select emp_fullname 'ชื่อพนักงาน',in_out_start 'วัน-เวลา เข้างาน',in_out_end 'วัน-เวลา ออกงาน' from in_out as a join employee as b on a.emp_id = b.emp_id " & condition
            End If
        ElseIf searchbyindex = 1 Then 'ค้าหาจากรหัสพนักงาน
            condition = " where a.emp_id = " & inout_id & ""
            If (inout_id <> "") Then
                sql = "select emp_fullname 'ชื่อพนักงาน',in_out_start 'วัน-เวลา เข้างาน',in_out_end 'วัน-เวลา ออกงาน' from in_out as a join employee as b on a.emp_id = b.emp_id " &
                condition
            End If
        ElseIf searchbyindex = 2 Then 'ค้าหาจากตำแหน่ง
            Dim inoutpos_id As String = cbo_searchinout.SelectedValue
            condition = " where pos_id = " & inoutpos_id & ""
            If (inoutpos_id <> "") Then
                sql = "select emp_fullname 'ชื่อพนักงาน',in_out_start 'วัน-เวลา เข้างาน',in_out_end 'วัน-เวลา ออกงาน' from in_out as a join employee as b on a.emp_id = b.emp_id " &
                condition & " "
            End If
        ElseIf searchbyindex = 3 Then ' ค้นหาจากช่วงวันที่
            Dim inout_start As String = dtpstart.Value.ToString("yyyyMMdd")
            Dim inout_end As String = dtpend.Value.ToString("yyyyMMdd")
            If Integer.Parse(inout_start) > Integer.Parse(inout_end) Then
                MsgBox("ไม่สามารถค้นหาได้เนื่องจากวันเริ่มต้นมากกว่าวันสิ้นสุดที่จะค้นหา")
                Exit Sub
            End If
            condition = " where convert(varchar(10),in_out_start,112) between  '" & inout_start & "' and '" & inout_end & "'"
            If (inout_start <> "" And inout_end <> "") Then
                sql = "select emp_fullname 'ชื่อพนักงาน',in_out_start 'วัน-เวลา เข้างาน',in_out_end 'วัน-เวลา ออกงาน' from in_out as a join employee as b on a.emp_id = b.emp_id " & condition
            End If
        End If
        GetDataToGrid(sql, grid_searchinout)
    End Sub

    Private Sub cbo_searchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchby.SelectedIndexChanged
        searchbyindex = cbo_searchby.SelectedIndex
        If selectedIndex = 1 Then
            getEmployeeformpage = 2
        End If
        If searchbyindex = 0 Then
            UpdateDatainGrid(1)
            txt_searchinout.Visible = False
            txt_ename.Visible = False
            btn_searchmemid2.Visible = False
            lbl_empid.Visible = False
            lbl_ename.Visible = False
            lbl_pos.Visible = False
            cbo_searchinout.Visible = False
            lbl_date.Visible = True
            dtp_searchinout.Visible = True
            lblstart.Visible = False
            lblend.Visible = False
            dtpstart.Visible = False
            dtpend.Visible = False
            lbl_pos.Visible = False
        ElseIf searchbyindex = 1 Then
            txt_searchinout.Enabled = False
            txt_ename.Enabled = False
            txt_searchinout.Visible = True
            txt_ename.Visible = True
            btn_searchmemid2.Visible = True
            lbl_empid.Visible = True
            lbl_ename.Visible = True
            lbl_date.Visible = False
            dtp_searchinout.Visible = False
            lbl_pos.Visible = False
            cbo_searchinout.Visible = False
            lblstart.Visible = False
            lblend.Visible = False
            dtpstart.Visible = False
            dtpend.Visible = False
            lbl_pos.Visible = False

        ElseIf searchbyindex = 2 Then
            txt_searchinout.Visible = False
            txt_ename.Visible = False
            btn_searchmemid2.Visible = False
            lbl_empid.Visible = False
            lbl_ename.Visible = False
            txt_searchinout.Enabled = False
            lbl_date.Visible = False
            dtp_searchinout.Visible = False
            lblstart.Visible = False
            lblend.Visible = False
            dtpstart.Visible = False
            dtpend.Visible = False
            lbl_pos.Visible = True
            cbo_searchinout.Visible = True
        ElseIf searchbyindex = 3 Then
            txt_searchinout.Visible = False
            txt_ename.Visible = False
            btn_searchmemid2.Visible = False
            lbl_empid.Visible = False
            lbl_ename.Visible = False
            txt_searchinout.Enabled = False
            lbl_date.Visible = False
            dtp_searchinout.Visible = False
            lbl_pos.Visible = False
            cbo_searchinout.Visible = False
            lblstart.Visible = True
            lblend.Visible = True
            dtpstart.Visible = True
            dtpend.Visible = True
        End If
    End Sub


    Private Sub autoUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles autoUpdate.Tick
        txt_showdate.Text = DateTime.Now().ToString("dd/MM/yyyy HH:mm")
        lbl_showcurrentdate.Text = "วันที่ " + DateTime.Now().ToString("dd MMMM yyyy  เวลา HH:mm น.")
    End Sub

    Private Sub cbo_inoutpos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_inoutpos.SelectedIndexChanged
        If (searchbyindex = 0) Then
            getEmployeeformpage = 1 'ค้นหา จากงานจากตำแหน่งหน้า กรอกเข้าออกทำงาน
        End If
    End Sub

End Class