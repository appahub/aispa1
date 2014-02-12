Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_login
    Dim sql As String = ""
    Dim Obj_query As New classquery()
    Dim DataTable As DataTable
    Dim success As Boolean = False
    Private Sub form_login_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If success = False Then
            form_home.Close()
        End If
    End Sub 'Form1_Closing
    Private Sub form_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        success = False
    End Sub
    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        Dim user As String = txt_user.Text.Trim
        Dim pass As String = txt_pass.Text.Trim
        If user <> "" And pass <> "" Then
            sql = "select emp_id,emp_fullname,emp_privilege from employee where emp_username = '" & user & "' and emp_password = '" & pass & "'"
            DataTable = Obj_query.selectDatatoGrid(sql)
            If DataTable.Rows.Count > 0 Then
                MsgBox("เข้าสู่ระบบเรียบร้อยแล้ว")
                success = True
                module_emp_id = DataTable.Rows(0)("emp_id").ToString().Trim
                Dim privilege As String = DataTable.Rows(0)("emp_privilege").ToString().Trim
                form_home.lbl_welcome.Text = "ยินดีต้อนรับ คุณ " & DataTable.Rows(0)("emp_fullname").ToString().Trim
                emp_Privilage = privilege
                form_home.grp_product.Visible = True
                If (privilege = "Administrator") Then
                    form_home.Panel_User.Visible = False
                    form_home.panel_Admin.Visible = True
                ElseIf (privilege = "User") Then
                    form_home.Panel_User.Visible = True
                    form_home.panel_Admin.Visible = False

                End If
                Dim leadtimeproductsql As String = "select prod_id 'รหัส',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',d.prod_type_name 'ประเภทสินค้า',convert(varchar,prod_price,1) 'ราคาสินค้า','บาท' 'หน่วยนับ',a.prod_qty 'จำนวนสินค้า',b.unit_name 'หน่วยนับ',prod_capacity 'ปริมาตร',c.unit_name 'หน่วยนับปริมาตร' from product a(nolock) join unit b(nolock) on a.unit_id = b.unit_id join unit c on a.unit_id_cap = c.unit_id join product_type d on a.prod_type_id = d.prod_type_id  where (prod_qty - prod_leadtime) between (prod_leadtime * -1) and 2 order by prod_id"
                GetDataToGrid(leadtimeproductsql, form_home.grid_alertproduct)
                form_home.Enabled = True
                form_home.Show()
                Me.Close()
            Else
                MsgBox("ชื่อผู้ใช้ หรือ รหัสผ่านไม่ถูกต้อง")
            End If
        End If
    End Sub
    Private Sub LoadAlertProduct()
        Dim Sql As String = ""
        Dim DataTable As DataTable = Obj_query.selectDatatoGrid(Sql)
        If DataTable.Rows.Count < 0 Then
            DataTable.Rows.Add(New Object() {1, "ไม่มีข้อมูล"})
        End If
        With form_home.grid_alertproduct
            .AutoGenerateColumns = True
            .DataSource = DataTable
        End With
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
    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        txt_user.Text = ""
        txt_pass.Text = ""
        txt_user.Focus()
    End Sub

    Private Sub btn_loadinout_user_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadinout_user_login.Click
        Me.TopMost = False
        form_in_out.ShowDialog()
        form_in_out.BringToFront()
        form_in_out.TopMost = True
        'Me.TopMost = False
        'Me.Enabled = False
    End Sub
End Class
