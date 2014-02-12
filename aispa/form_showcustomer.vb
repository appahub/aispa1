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

        Dim Sql As String = " select a.prom_name 'ชื่อโปรโมชั่น', " &
            " case " &
                " when a.prom_type = 'S' then 'ส่วนลด' " &
                " when a.prom_type = 'F' then 'แถม-ฟรี'" &
                " when a.prom_type = 'P' then 'แพ็คเกจ'" &
            " End 'ประเภท',convert(varchar,prom_price,1) 'ราคา' " &
            ", case " &
                " when a.prom_type = 'P' and convert(int,isnull(c.count,0)) <= 0   then 'ยังไม่ได้สมัคร'" &
                " when a.prom_type = 'P' and convert(int,isnull(c.count,0)) > 0 and convert(int,isnull(c.count,0)) <= (a.prom_qty_used + a.prom_qty_free) then 'สามารถใช้ได้'" &
                " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) = 0 and isnull(a.prom_qty_free,0) > 0 and convert(int,isnull(d.count,0)) <= isnull(a.prom_qty_free,0)  then 'สามารถใช้ได้' " &
                " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) > 0 and convert(int,isnull(d.count,0)) >= isnull(a.prom_qty_used,0) and convert(int,isnull(d.count,0)) <= (isnull(a.prom_qty_used,0) + isnull(a.prom_qty_free,0)) then 'สามารถใช้ได้' " &
                " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) > 0 and convert(int,isnull(d.count,0)) > isnull(a.prom_qty_used,0) and convert(int,isnull(d.count,0)) > (isnull(a.prom_qty_used,0) + isnull(a.prom_qty_free,0))  then 'ไม่สามารถใช้ได้' " &
                " when a.prom_type = 'F' and isnull(a.prom_qty_free,0) = 0 and isnull(a.prom_qty_used,0) = 0  then 'สามารถใช้ได้' " &
                " else 'สามารถใช้ได้'" &
            "  End 'สิทธิ์'" &
            ", case " &
                " when a.prom_type = 'P' and convert(int,isnull(c.count,0)) <= 0  then 'F'" &
                " when a.prom_type = 'P' and convert(int,isnull(c.count,0)) > 0 and convert(int,isnull(c.count,0)) <= (a.prom_qty_used + a.prom_qty_free) then 'T'" &
                " when a.prom_type = 'F' and convert(int,isnull(d.count,0)) <= 0  then 'T' " &
                " when a.prom_type = 'F' and convert(int,isnull(d.count,0)) > 0 and convert(int,isnull(d.count,0)) > (isnull(a.prom_qty_used,0) + isnull(a.prom_qty_free,0)) then 'F' " &
                " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) = 0 and isnull(a.prom_qty_free,0) > 0 and convert(int,isnull(d.count,0)) <= isnull(a.prom_qty_free,0)  then 'T' " &
                " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) > 0 and convert(int,isnull(d.count,0)) >= isnull(a.prom_qty_used,0) and convert(int,isnull(d.count,0)) <= (isnull(a.prom_qty_used,0) + isnull(a.prom_qty_free,0)) then 'T' " &
                " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) > 0 and convert(int,isnull(d.count,0)) > isnull(a.prom_qty_used,0) and convert(int,isnull(d.count,0)) > (isnull(a.prom_qty_used,0) + isnull(a.prom_qty_free,0))  then 'F' " &
                " when a.prom_type = 'F' and isnull(a.prom_qty_free,0) = 0 and isnull(a.prom_qty_used,0) = 0  then 'T' " &
            " else '-'" &
            "  End 'flag' , a.prom_id,a.prom_regis,a.prom_startdate,a.prom_enddate" &
            " from promotion a(nolock)" &
            " join customer_type_promotion b(nolock) on a.prom_id = b.prom_id" &
            " Left Join" &
            " ( select prom_id , isnull(COUNT(*),0) count from bill_detail " &
            " group by prom_id ) c on a.prom_id = c.prom_id and a.prom_type = 'P' and c.count > 0 " &
            " Left Join" &
            " ( select prom_id , isnull(COUNT(*),0) count from bill_detail " &
            " group by prom_id ) d on a.prom_id = d.prom_id and a.prom_type = 'F' " &
            " where b.custype_id = " & grid_showcustomer.Rows(rowindex).Cells(5).Value.ToString & "and (a.prom_type <> 'P' and isnull(c.prom_id,'') = '') " &
            " and " & form_service.dtp_servdate.Value.ToString("yyyyMMdd") &
            " between convert(varchar(8),a.prom_startdate,112) and convert(varchar(8),a.prom_enddate,112)"
        GetDataToGrid(Sql, form_service.grid_chooseprom, "prom")

        Sql = " select a.prom_name 'ชื่อโปรโมชั่น',  " &
              " case  " &
              " when a.prom_type = 'P' then 'แพ็คเกจ' " &
              " End 'ประเภท',convert(varchar,prom_price,1) 'ราคา'  " &
              " , case  " &
              " when a.prom_type = 'P' and isnull(b.bill_id,'') = ''   then 'ยังไม่ได้สมัคร' " &
              " End 'สิทธิ์' " &
              " , case  " &
              " when a.prom_type = 'P' and isnull(b.bill_id,'') = ''  then 'F' " &
              " End 'flag' , a.prom_id,a.prom_regis,a.prom_startdate,a.prom_enddate " &
              " from promotion a(nolock) " &
              " join customer_type_promotion e(nolock) on a.prom_id = e.prom_id " &
              " left join bill_detail b(nolock) on a.prom_id = b.prom_id " &
              " where a.prom_type = 'P' and e.custype_id = " & grid_showcustomer.Rows(rowindex).Cells(5).Value.ToString &
              " and " & form_service.dtp_servdate.Value.ToString("yyyyMMdd") &
              " between convert(varchar(8),a.prom_startdate,112) and convert(varchar(8),a.prom_enddate,112)"

        GetDataToGrid(Sql, form_service.grid_packet, "prom")
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
                If Not (rows(4).ToString = "F" And rows(1).ToString = "แถม-ฟรี") Then
                    Dim row As String() = New String() {False, rows(0), rows(1), rows(2), rows(3), rows(4), rows(5), rows(6), rows(7), rows(8)}
                    mygrid.Rows.Add(row)
                End If
            ElseIf type = "emp" Then
                Dim row As String() = New String() {False, rows(0), rows(1)}
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