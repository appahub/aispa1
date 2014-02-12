Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_showcustomer
    Dim Obj_query = New classquery()
    Private Sub form_showcustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim prodtype As Integer = productype
        Dim cussearch As String = form_service.txt_cusname.Text.Trim ' เป็น id ก็ได้ หรือ เป็นชื่อก็ได้
        If cussearch <> "" Then
            Dim split As String() = cussearch.Split(" ")
            If split.Length > 1 Then
                cussearch = cussearch.Replace(split(0), "").Trim() ' เอาไว้ตัดคำนำหน้าชื่อออก 
            End If
        End If
        Dim Sql As String = "select cus_id 'รหัสสมาชิก',b.prefix_name +' ' + cus_fullname 'ชื่อสมาชิก',case cus_sex when 'M' then 'ชาย' else 'หญิง' end 'เพศ',c.custype_name 'ประเภทสมาชิก',convert(varchar,cus_money,1) 'วงเงินคงเหลือ',a.custype_id" +
            " from customer a(nolock) " &
            " join prefix b(nolock) on a.prefix_id = b.prefix_id " &
            " join customer_type c(nolock) on a.custype_id = c.custype_id " &
            " where cus_id like '%" & cussearch & "' or cus_id like '%" & cussearch & "%' or cus_id like '" & cussearch & "%' " &
            " or cus_fullname like '%" & cussearch & "' or cus_fullname like '%" & cussearch & "%' or cus_fullname like '" & cussearch & "%' "
        Dim DataTable As DataTable = Obj_query.selectDatatoGrid(Sql)
        If DataTable.Rows.Count < 0 Then
            
        End If
        With grid_showcustomer
            .AutoGenerateColumns = True
            .DataSource = DataTable
        End With
        grid_showcustomer.Columns(5).Visible = False
    End Sub

    Private Sub grid_showcustomer_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showcustomer.CellClick
        Dim rowindex As Integer = grid_showcustomer.CurrentRow.Index
        form_service.txt_custypeid.Text = grid_showcustomer.Rows(rowindex).Cells(5).Value.ToString
        form_service.txt_cusid.Text = grid_showcustomer.Rows(rowindex).Cells(0).Value.ToString
        form_service.txt_cusname.Text = grid_showcustomer.Rows(rowindex).Cells(1).Value.ToString

        Dim Sql As String = " select distinct a.prom_name 'ชื่อโปรโมชั่น',  " &
            " case  " &
                " when a.prom_type = 'F' then 'แถมฟรี' " &
                " when a.prom_type = 'S' then 'ส่วนลด' " &
                " when a.prom_type = 'P' then 'แพ็คเกจ' " &
            " End 'ประเภท',convert(varchar,prom_price,1) 'ราคา' " &
            " , 'ยังไม่ได้สมัคร'  'สิทธิ์' " &
            " , 'F' 'flag' , a.prom_id,a.prom_regis,a.prom_startdate,a.prom_enddate from promotion a(nolock) " &
            " join customer_type_promotion b(nolock) on a.prom_id = b.prom_id " &
            " where (ISNULL(a.prom_qty_used, 0) <> 0) OR a.prom_type = 'S' " &
            " and b.custype_id = " & grid_showcustomer.Rows(rowindex).Cells(5).Value.ToString &
            " and " & form_service.dtp_servdate.Value.ToString("yyyyMMdd") &
            " between convert(varchar(8),a.prom_startdate,112) and convert(varchar(8),a.prom_enddate,112) " &
            " except " &
            " select d.prom_name 'ชื่อโปรโมชั่น',  " &
            " case  " &
                " when d.prom_type = 'P' then 'แพ็คเกจ' " &
            " End 'ประเภท',convert(varchar,prom_price,1) 'ราคา'  " &
            " ,  'ยังไม่ได้สมัคร'  'สิทธิ์'" &
            " ,  'F' 'flag' , d.prom_id,d.prom_regis,d.prom_startdate,d.prom_enddate from service a(nolock) " &
            " join bill b(nolock) on a.serv_id = b.serv_id " &
            " join bill_detail c(nolock) on b.bill_id = c.bill_id " &
            " join promotion d(nolock) on c.prom_id = d.prom_id " &
            " left join ( select cus_id, prom_id,isnull(COUNT(prom_id),0) count from use_service a(nolock) " &
            " join use_service_detail b(nolock) on a.use_id = b.use_id " &
            " group by cus_id, prom_id ) e on a.cus_id = e.cus_id and d.prom_id = e.prom_id " &
            " where ISNULL(d.prom_qty_used,0) <> 0 " &
            " and isnull(e.count,0) <= isnull((d.prom_qty_used + d.prom_qty_free),0) " &
            " and a.cus_id = " & grid_showcustomer.Rows(rowindex).Cells(0).Value.ToString &
            " and " & form_service.dtp_servdate.Value.ToString("yyyyMMdd") &
            " between convert(varchar(8),d.prom_startdate,112) and convert(varchar(8),d.prom_enddate,112) "
        GetDataToGrid(Sql, form_service.grid_packet, "prom")

        Sql = " select distinct a.prom_name 'ชื่อโปรโมชั่น',  " &
            " case  " &
                " when a.prom_type = 'F' then 'แถมฟรี' " &
                " when a.prom_type = 'P' then 'แพ็คเกจ' " &
            " End 'ประเภท',convert(varchar,prom_price,1) 'ราคา' " &
            " , 'ยังไม่ได้สมัคร'  'สิทธิ์' " &
            " , 'F' 'flag' , a.prom_id,a.prom_regis,a.prom_startdate,a.prom_enddate from promotion a(nolock) " &
            " join customer_type_promotion b(nolock) on a.prom_id = b.prom_id " &
            " where (ISNULL(a.prom_qty_used, 0) = 0) and a.prom_type <> 'S' " &
            " and b.custype_id = " & grid_showcustomer.Rows(rowindex).Cells(5).Value.ToString &
            " and " & form_service.dtp_servdate.Value.ToString("yyyyMMdd") &
            " between convert(varchar(8),a.prom_startdate,112) and convert(varchar(8),a.prom_enddate,112) "

        GetDataToGrid(Sql, form_service.grid_chooseprom, "promnotchoose")
        form_service.pal_showafterchoosecus.Visible = True
        form_service.grp_selectprom.Visible = True
        Me.Close()
    End Sub
    Private Sub GetDataToGrid(ByVal mysql As String, ByVal mygrid As DataGridView, ByVal type As String)
        Dim dataTable As DataTable = Obj_query.selectDatatoGrid(mysql)
        If dataTable.Rows.Count < 0 Then
            dataTable.Rows.Add(New Object() {1, "ไม่มีข้อมูล"})
        End If
        mygrid.Rows.Clear()
        For Each rows As DataRow In dataTable.Rows
            If type = "prom" Then
                'If Not (rows(4).ToString = "F" And rows(1).ToString = "แถม-ฟรี") Then
                Dim row As String() = New String() {False, rows(0), rows(1), rows(2), rows(3), rows(4), rows(5), rows(6), rows(7), rows(8)}
                mygrid.Rows.Add(row)
                'End If
            ElseIf type = "promnotchoose" Then
                Dim row As String() = New String() {rows(0), rows(1), rows(2), rows(3), rows(4), rows(5), rows(6), rows(7), rows(8)}
                mygrid.Rows.Add(row)
            End If
        Next
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
End Class