Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_service
    Dim Obj_query As New classquery()
    Dim sql As String
    Dim datatable As New DataTable
    Dim selectedIndex As Integer
    Dim isedit As Boolean = False
    Dim clickinchoosepromotion As Boolean = False
#Region "totalcontrol"
    Private Sub UpdateDatainGrid(ByVal index As Integer)
        Dim sqlqueryeachtab(3) As String
        sqlqueryeachtab(0) = "select ROW_NUMBER() over (order by serv_id desc)'ลำดับ',serv_date 'วันที่บริการ'," &
        " b.cus_fullname 'สมาชิกมาใช้บริการ' , c.emp_fullname 'พนักงานทำรายการ' , serv_comment 'หมายเหตุ' " &
        " ,case when serv_sts = 'S' then 'เสร็จสมบูรณ์' when serv_sts = 'C' then 'ยกเลิกรายการ' end 'สถานะการบริการ',serv_id 'รหัสการบริการ',b.cus_id,b.custype_id" &
        " from service a(nolock) " &
        " join customer b(nolock) on a.cus_id = b.cus_id" &
        " join employee c(nolock) on a.emp_id = c.emp_id" &
        " where serv_sts <> 'C'" &
        " order by serv_id desc"
        Dim havedropdown(,) As String =
        {
            {"0", "select liserv_type_id ID,liserv_type_name Name from service_list_type(nolock) order by  liserv_type_id", "0"}
        }
        Dim mygrid() As DataGridView = {grid_servresult}
        Dim mycombobox() As ComboBox = {
            cboservtype
        }
        For i As Integer = 0 To havedropdown.GetLength(0) - 1
            If (index.ToString() = havedropdown(i, 0)) Then
                GetDatatoCombobox(havedropdown(i, 1), mycombobox(Integer.Parse(havedropdown(i, 2))))
            End If
        Next
        GetDataToGrid(sqlqueryeachtab(index), mygrid(index))

    End Sub
    Private Sub clearData()
        clickinchoosepromotion = False
        txt_cusid.Text = ""
        txt_cusname.Text = ""
        txt_custypeid.Text = ""
        dtp_servdate.Value = DateTime.Now
        cboservtype.SelectedIndex = 0
        txt_servname.Text = ""
        txt_servid.Text = ""
        txt_searchserv.Text = ""
        txt_servcomment.Text = ""
        price_all.Text = "0.00"
        price_normal.Text = "0.00"
        'price_prom.Text = "0.00"
        price_packet.Text = "0.00"
        btn_delserv.Visible = False
        btn_delservlist.Visible = False
        grp_selectprom.Visible = False
        grid_selectprom.Rows.Clear()
        grid_packet.Rows.Clear()
        grid_showservlist.Rows.Clear()
        pal_showafterchoosecus.Visible = False
        UpdateDatainGrid(0)
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
        mygrid.Columns(6).Visible = False
        mygrid.Columns(7).Visible = False
        mygrid.Columns(8).Visible = False
    End Sub
    Private Sub GetDatatoCombobox(ByVal mysql As String, ByVal mycombobox As ComboBox)
        sql = mysql
        datatable = Obj_query.selectDatatoGrid(sql)
        mycombobox.ValueMember = "ID"
        mycombobox.DisplayMember = "Name"
        mycombobox.DataSource = datatable
    End Sub
    Private Sub GetDataToGridforprom(ByVal mysql As String, ByVal mygrid As DataGridView, ByVal type As String)
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
#End Region

    Private Sub form_service_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UpdateDatainGrid(0)
    End Sub
    Private Sub form_mainmgr_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        form_home.Enabled = True
    End Sub 'Form1_Closing

    Private Sub btn_showcus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_showcus.Click
        form_showcustomer.Show()
    End Sub

    Private Sub btn_searchservlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchservlist.Click
        form_showservlist.Show()
    End Sub

    Private Sub btn_addserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addserv.Click
        Dim servdatefindprom As String = dtp_servdate.Value.ToString("yyyyMMdd")
        Dim cus_typeid As String = txt_custypeid.Text
        Dim cus_id As String = txt_cusid.Text
        Dim comment As String = txt_servcomment.Text
        Dim emp_id As Integer = module_emp_id

        If cus_id <> "" And servdatefindprom <> "" Then ' service_type.Count > 0 And เอาไว้เช็คว่าเลือกพนักงานหรือยัง
            ' แยกว่าพนักงานคนใหนทำบริการ ของรายการบริการ หรือ โปรโมชั่น 
            Dim normalservice As ArrayList = New ArrayList
            Dim promotionservice As ArrayList = New ArrayList

            Dim doinpacketalready As Boolean = False
            For Each rowlist As DataGridViewRow In grid_showservlist.Rows ' เก็บรายการบริการที่เลือกมา
                normalservice.Add(rowlist.Cells(5).Value)
            Next
            For Each promserv As DataGridViewRow In grid_packet.Rows
                If promserv.Cells(0).Value = True Then
                    promotionservice.Add(promserv.Cells(6).Value)
                End If
            Next


            sql = "insert into service (serv_date,serv_comment,cus_id,emp_id,serv_sts) values ('" & servdatefindprom & "' , '" & comment & "'," & cus_id & "," & emp_id & ",'S')" ' S = Success
            If Obj_query.DMLData(sql) Then
                Dim servid As String = Obj_query.selectdataInt("select IDENT_CURRENT('service')").ToString()

                sql = ""
                For Each rowserv As DataGridViewRow In grid_showservlist.Rows
                    Dim normaladd As Boolean = False
                    If normalservice.Count > 0 Then
                        For Each normalserv As String In normalservice
                            If rowserv.Cells(5).Value = normalserv Then
                                sql &= " insert into service_detail (serv_id,liserv_id) values " &
                                    " ( " & servid & "," & normalserv & " )"
                                normaladd = True
                                Exit For
                            End If
                        Next
                    End If
                Next
                Dim pricenormal As String = price_normal.Text
                Dim pricepacket As String = price_packet.Text
                Dim priceall As String = price_all.Text

                If Obj_query.DMLData(sql) Then
                    sql = "insert into bill (serv_id,bill_date,bill_price_normal,bill_price_packet,bill_price_total) " &
                        " values (" & servid & ", '" & servdatefindprom & "', " & pricenormal & ", " & pricepacket & ", " & priceall & " )"

                    If Obj_query.DMLData(sql) Then
                        Dim billid As String = Obj_query.selectdataInt("select IDENT_CURRENT('bill')").ToString()
                        sql = ""
                        If promotionservice.Count > 0 Then
                            For Each promserv As String In promotionservice

                                sql &= "insert into bill_detail (prom_id,bill_id) values " &
                                     " ( " & promserv & "," & billid & " )"
                            Next
                            If Obj_query.DMLData(sql) Then
                                MsgBox("เพิ่มรายการบริการเรียบร้อยแล้ว")
                            End If
                        Else
                            MsgBox("เพิ่มรายการบริการเรียบร้อยแล้ว")
                        End If
                    End If
                End If
            End If
            clearData()
        Else
            MsgBox("กรุณาระบุข้อมูลให้ถูกต้อง หรือ ยังไม่ได้กำหนดพนักงานที่ให้บริการ")
        End If
    End Sub

    Private Sub grid_servresult_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_servresult.CellClick
        clickinchoosepromotion = True
        Dim row As Integer = grid_servresult.CurrentRow.Index
        isedit = True
        'clearData()
        btn_delserv.Visible = True
        txt_servid.Text = grid_servresult.Rows(row).Cells(6).Value.ToString
        dtp_servdate.Value = grid_servresult.Rows(row).Cells(1).Value
        txt_cusname.Text = grid_servresult.Rows(row).Cells(2).Value.ToString
        txt_servcomment.Text = grid_servresult.Rows(row).Cells(4).Value.ToString
        txt_cusid.Text = grid_servresult.Rows(row).Cells(7).Value.ToString
        txt_custypeid.Text = grid_servresult.Rows(row).Cells(8).Value.ToString

        Dim Sql As String = " select ROW_NUMBER() over (order by d.liserv_id) 'ลำดับ',d.liserv_name , e.liserv_type_name " &
        " , convert(varchar,liserv_price,1) 'ราคา' , d.liserv_id " &
        " from service a(nolock) " &
        " join service_detail b(nolock) on a.serv_id =b.serv_id " &
        " join service_list d(nolock) on b.liserv_id = d.liserv_id " &
        " join service_list_type e(nolock) on d.liserv_type_id = e.liserv_type_id " &
        " where a.serv_id = " & txt_servid.Text
        Dim detailservicelist As DataTable = Obj_query.selectDatatoGrid(Sql)
        Dim totalprice As Double = 0.0

        ' ดึงราคาจาก bill ของ การซื้อบริการที่จะดูข้อมูล 

        Dim sql_getprice As String = "select convert(varchar,bill_price_normal,1) normal," &
            " convert(varchar,bill_price_packet,1) packet, convert(varchar,bill_price_total,1) total " &
            " from bill where serv_id = " & txt_servid.Text
        Dim price_dt As DataTable = Obj_query.selectDatatoGrid(sql_getprice)

        price_normal.Text = price_dt.Rows(0)(0)
        price_packet.Text = price_dt.Rows(0)(1)
        price_all.Text = price_dt.Rows(0)(2)

        Dim Promsql As String = " select distinct a.prom_name 'ชื่อโปรโมชั่น',  " &
            " case  " &
                " when a.prom_type = 'F' then 'แถมฟรี' " &
                " when a.prom_type = 'S' then 'ส่วนลด' " &
                " when a.prom_type = 'P' then 'แพ็คเกจ' " &
            " End 'ประเภท',convert(varchar,prom_price,1) 'ราคา' " &
            " , 'ยังไม่ได้สมัคร'  'สิทธิ์' " &
            " , 'F' 'flag' , a.prom_id,a.prom_regis,a.prom_startdate,a.prom_enddate from promotion a(nolock) " &
            " join customer_type_promotion b(nolock) on a.prom_id = b.prom_id " &
            " where (ISNULL(a.prom_qty_used, 0) <> 0) OR a.prom_type = 'S' " &
            " and b.custype_id = " & txt_custypeid.Text &
            " and " & dtp_servdate.Value.ToString("yyyyMMdd") &
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
            " and a.cus_id = " & txt_cusid.Text &
            " and " & dtp_servdate.Value.ToString("yyyyMMdd") &
            " between convert(varchar(8),d.prom_startdate,112) and convert(varchar(8),d.prom_enddate,112) "
        GetDataToGridPromotion(Promsql, grid_packet, "prom")

        Promsql = " select distinct a.prom_name 'ชื่อโปรโมชั่น',  " &
            " case  " &
                " when a.prom_type = 'F' then 'แถมฟรี' " &
                " when a.prom_type = 'P' then 'แพ็คเกจ' " &
            " End 'ประเภท',convert(varchar,prom_price,1) 'ราคา' " &
            " , 'ยังไม่ได้สมัคร'  'สิทธิ์' " &
            " , 'F' 'flag' , a.prom_id,a.prom_regis,a.prom_startdate,a.prom_enddate from promotion a(nolock) " &
            " join customer_type_promotion b(nolock) on a.prom_id = b.prom_id " &
            " where (ISNULL(a.prom_qty_used, 0) = 0) and a.prom_type <> 'S' " &
            " and b.custype_id = " & txt_custypeid.Text &
            " and " & dtp_servdate.Value.ToString("yyyyMMdd") &
            " between convert(varchar(8),a.prom_startdate,112) and convert(varchar(8),a.prom_enddate,112) "

        GetDataToGridPromotion(Promsql, grid_chooseprom, "promnotchoose")

        ' check already choose promotion
        Dim sqlchooseprom As String = "select prom_id from bill a(nolock) " &
            " join bill_detail b(nolock) on a.bill_id = b.bill_id where a.serv_id = " & txt_servid.Text
        Dim chooseprom_dt As DataTable = Obj_query.selectDatatoGrid(sqlchooseprom)

        For Each rowprom As DataGridViewRow In grid_packet.Rows
            For Each rowchooseprom As DataRow In chooseprom_dt.Rows
                If rowprom.Cells(6).Value = rowchooseprom(0) Then
                    rowprom.Cells(0).Value = True
                    grid_packet.UpdateCellValue(0, rowprom.Index)
                End If
            Next
        Next
        btn_addserv.Visible = False
        btn_delserv.Visible = True
        pal_showafterchoosecus.Visible = True
        grp_selectprom.Visible = True
        '' แสดงรายการโปรโมชั่นที่เกี่ยวข้อง
        'Dim Sqlshowprom As String = " select a.prom_name 'ชื่อโปรโมชั่น', " &
        '    " case " &
        '        " when a.prom_type = 'S' then 'ส่วนลด' " &
        '        " when a.prom_type = 'F' then 'แถม-ฟรี'" &
        '        " when a.prom_type = 'P' then 'แพ็คเกจ'" &
        '    " End 'ประเภท',convert(varchar,prom_price,1) 'ราคา' " &
        '    ", case " &
        '        " when a.prom_type = 'P' and convert(int,isnull(c.count,0)) <= 0   then 'ยังไม่ได้สมัคร'" &
        '        " when a.prom_type = 'P' and convert(int,isnull(c.count,0)) > 0 and convert(int,isnull(c.count,0)) <= (a.prom_qty_used + a.prom_qty_free) then 'สามารถใช้ได้'" &
        '        " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) = 0 and isnull(a.prom_qty_free,0) > 0 and convert(int,isnull(d.count,0)) <= isnull(a.prom_qty_free,0)  then 'สามารถใช้ได้' " &
        '        " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) > 0 and convert(int,isnull(d.count,0)) >= isnull(a.prom_qty_used,0) and convert(int,isnull(d.count,0)) <= (isnull(a.prom_qty_used,0) + isnull(a.prom_qty_free,0)) then 'สามารถใช้ได้' " &
        '        " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) > 0 and convert(int,isnull(d.count,0)) > isnull(a.prom_qty_used,0) and convert(int,isnull(d.count,0)) > (isnull(a.prom_qty_used,0) + isnull(a.prom_qty_free,0))  then 'ไม่สามารถใช้ได้' " &
        '        " when a.prom_type = 'F' and isnull(a.prom_qty_free,0) = 0 and isnull(a.prom_qty_used,0) = 0  then 'สามารถใช้ได้' " &
        '        " else 'สามารถใช้ได้'" &
        '    "  End 'สิทธิ์'" &
        '    ", case " &
        '        " when a.prom_type = 'P' and convert(int,isnull(c.count,0)) <= 0  then 'F'" &
        '        " when a.prom_type = 'P' and convert(int,isnull(c.count,0)) > 0 and convert(int,isnull(c.count,0)) <= (a.prom_qty_used + a.prom_qty_free) then 'T'" &
        '        " when a.prom_type = 'F' and convert(int,isnull(d.count,0)) <= 0  then 'T' " &
        '        " when a.prom_type = 'F' and convert(int,isnull(d.count,0)) > 0 and convert(int,isnull(d.count,0)) > (isnull(a.prom_qty_used,0) + isnull(a.prom_qty_free,0)) then 'F' " &
        '        " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) = 0 and isnull(a.prom_qty_free,0) > 0 and convert(int,isnull(d.count,0)) <= isnull(a.prom_qty_free,0)  then 'T' " &
        '        " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) > 0 and convert(int,isnull(d.count,0)) >= isnull(a.prom_qty_used,0) and convert(int,isnull(d.count,0)) <= (isnull(a.prom_qty_used,0) + isnull(a.prom_qty_free,0)) then 'T' " &
        '        " when a.prom_type = 'F' and isnull(a.prom_qty_used,0) > 0 and convert(int,isnull(d.count,0)) > isnull(a.prom_qty_used,0) and convert(int,isnull(d.count,0)) > (isnull(a.prom_qty_used,0) + isnull(a.prom_qty_free,0))  then 'F' " &
        '        " when a.prom_type = 'F' and isnull(a.prom_qty_free,0) = 0 and isnull(a.prom_qty_used,0) = 0  then 'T' " &
        '    " else '-'" &
        '    "  End 'flag' , a.prom_id,a.prom_regis,a.prom_startdate,a.prom_enddate" &
        '    " from promotion a(nolock)" &
        '    " join customer_type_promotion b(nolock) on a.prom_id = b.prom_id" &
        '    " Left Join" &
        '    " ( select prom_id , isnull(COUNT(*),0) count from bill_detail " &
        '    " group by prom_id ) c on a.prom_id = c.prom_id and a.prom_type = 'P'" &
        '    " Left Join" &
        '    " ( select prom_id , isnull(COUNT(*),0) count from bill_detail " &
        '    " group by prom_id ) d on a.prom_id = d.prom_id and a.prom_type = 'F' " &
        '    " where b.custype_id = " & txt_custypeid.Text &
        '    " and " & dtp_servdate.Value.ToString("yyyyMMdd") &
        '    " between convert(varchar(8),a.prom_startdate,112) and convert(varchar(8),a.prom_enddate,112)"
        'GetDataToGridforprom(Sqlshowprom, grid_chooseprom, "prom")
        'pal_showafterchoosecus.Visible = True
        'grid_showservlist.Rows.Clear()
        'For i As Integer = 0 To detailservicelist.Rows.Count - 1
        '    Dim servprice As String = detailservicelist(i)(3).ToString()
        '    totalprice += Double.Parse(servprice)
        '    price_normal.Text = totalprice.ToString("#,##0.00")
        '    price_all.Text = totalprice.ToString("#,##0.00")
        'Next
        For i As Integer = 0 To detailservicelist.Rows.Count - 1
            Dim runno As Integer = detailservicelist(i)(0).ToString()
            Dim servname As String = detailservicelist(i)(1).ToString()
            Dim servtype As String = detailservicelist(i)(2).ToString()
            Dim servprice As String = detailservicelist(i)(3).ToString()
            Dim servid As String = detailservicelist(i)(4).ToString()
            Dim rowliserv As String() = New String() {False, runno, servname, servtype, servprice, servid}
            grid_showservlist.Rows.Add(rowliserv)
        Next
        clickinchoosepromotion = False
    End Sub
    Private Sub GetDataToGridPromotion(ByVal mysql As String, ByVal mygrid As DataGridView, ByVal type As String)
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
    Private Sub btn_resetserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resetserv.Click
        clearData()
    End Sub

    Private Sub btn_confirmprom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_delproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delproduct.Click
        btn_delserv.Visible = True
        For i As Integer = 0 To grid_showservlist.Rows.Count - 1
            grid_showservlist.Rows(i).Cells(0).Value = True
        Next
    End Sub

    Private Sub btn_delserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delserv.Click
        sql = "update service set serv_sts = 'C' where serv_id = " & txt_servid.Text
        If Obj_query.DMLData(sql) Then
            MsgBox("ยกเลิกรายการบริการนี้เรียบร้อยแล้ว")
        End If
        clearData()
    End Sub

    Private Sub grid_showservlist_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showservlist.CellClick
        If isedit = False Then
            btn_delservlist.Visible = True
        End If
    End Sub

    Private Sub grid_showservlist_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grid_showservlist.RowsAdded
        If clickinchoosepromotion = False Then
            Dim rownow As Integer = 0
            Dim serv_dontabout_prom As ArrayList = New ArrayList
            Dim doinpacketalready As Boolean = False
            For Each rowlist As DataGridViewRow In grid_showservlist.Rows ' เก็บรายการบริการที่เลือกมา
                serv_dontabout_prom.Add(rowlist)
            Next
            For Each promserv As DataGridViewRow In grid_packet.Rows
                If promserv.Cells(0).Value = True Then
                    Dim chkservlist As DataTable = get_Promlistall(promserv.Cells(6).Value.ToString)
                    For Each rowpromserv As DataRow In chkservlist.Rows
                        Dim count As Integer = serv_dontabout_prom.Count - 1
                        While (count >= 0)
                            'MsgBox(rowpromserv(1) & " : " & serv_dontabout_prom(count).Cells(2).Value & " : " & rowpromserv(2) & " : " & serv_dontabout_prom(count).Cells(3).Value)
                            If rowpromserv(1) = serv_dontabout_prom(count).Cells(2).Value And rowpromserv(2) = serv_dontabout_prom(count).Cells(3).Value Then
                                'serv_dontabout_prom.RemoveAt(count)
                                serv_dontabout_prom.RemoveAt(count)
                            End If
                            count -= 1
                        End While
                    Next
                End If
            Next
            For Each promlistforchk As DataGridViewRow In grid_packet.Rows
                Dim servlistdatatable As DataTable = get_Promlistall(promlistforchk.Cells(6).Value.ToString)
                Dim thispromlist_count As Integer = servlistdatatable.Rows.Count
                For Each promservlist As DataRow In servlistdatatable.Rows ' รายการบริการ แต่ละโปรโมชั่น
                    For i As Integer = 0 To serv_dontabout_prom.Count - 1 ' รายการบริการที่เลือกมาใน ดาตากริด
                        If serv_dontabout_prom(i).Cells(1).Value <> "" Then
                            If serv_dontabout_prom(i).Cells(2).Value.Equals(promservlist(1)) And
                                serv_dontabout_prom(i).Cells(3).Value.Equals(promservlist(2)) And
                                serv_dontabout_prom(i).Cells(4).Value.Equals(promservlist(3)) Then
                                thispromlist_count -= 1
                            End If
                        End If
                    Next
                Next
                If thispromlist_count = 0 Then
                    grid_packet.CurrentCell = grid_packet.Item(0, rownow)
                    promlistforchk.Cells(0).Value = True
                    grid_packet.UpdateCellValue(0, rownow)

                    Dim promservnew As DataTable = get_Promlistall(grid_packet.Rows(rownow).Cells(6).Value) ' โปรโมชั่นที่เลือก
                    Dim flag_is_packet As Boolean = False
                    'If grid_chooseprom.Rows(rownow).Cells(5).Value = "F" And grid_chooseprom.Rows(rownow).Cells(2).Value = "แพ็คเกจ" And grid_chooseprom.Rows(rownow).Cells(0).Value = False Then
                    Dim answer As DialogResult
                    answer = MessageBox.Show("คุณต้องการสมัคร โปรโมชั่นนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If answer = vbNo Then
                        grid_packet.RefreshEdit()
                        grid_packet.Rows(rownow).Cells(0).Value = False
                        'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
                        grid_packet.UpdateCellValue(0, rownow)
                        'delservadd(promservnew)
                        Exit Sub
                    ElseIf answer = vbYes Then
                        grid_packet.Rows(rownow).Cells(0).Value = True
                        'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
                        grid_packet.UpdateCellValue(0, rownow)
                        flag_is_packet = True
                        doinpacketalready = True
                    End If
                    ' End If
                    Dim pricenornal As Double = Double.Parse(price_normal.Text)
                    Dim pricedo As Double = 0.0
                    Dim priceprom As Double = 0.0
                    Dim pricepacket As Double = Double.Parse(price_packet.Text)
                    Dim pricenow As Double = Double.Parse(price_all.Text)
                    Dim pricedel As Double = 0.0
                    Dim priceold As Double = Double.Parse(price_normal.Text)
                    For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
                        If servlistrow(5) = "do" Then
                            pricedo += Double.Parse(servlistrow(3))
                        End If
                        pricenornal += Double.Parse(servlistrow(3))
                        pricedel += Double.Parse(servlistrow(3))
                    Next

                    If grid_packet.Rows(rownow).Cells(2).Value = "ส่วนลด" Then
                        Dim paymoney As Double = 0
                        pricenow += Double.Parse(grid_packet.Rows(rownow).Cells(3).Value)
                        'If grid_chooseprom.Rows(nowdatais).Cells(5).Value <> "F" Then
                        '    paymoney = Double.Parse(price_all.Text)
                        'End If
                        'priceprom += Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value) '(pricenornal) '- Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value))
                    ElseIf grid_packet.Rows(rownow).Cells(2).Value = "แถม-ฟรี" Then
                        'ตรงแถมฟรี ยังไงก็ต้อง เช็คว่า คนนี้มาใช้บริการแล้วกี่ครั้งถ้ายังใช่บริการไม่ครบก็ไม่สามารถใช่สิทธิ์ แถมฟรีได้
                        'priceprom += (pricenornal - pricedo)
                        pricenow += pricedo
                    ElseIf grid_packet.Rows(rownow).Cells(2).Value = "แพ็คเกจ" Then
                        ' ตรงแพ็คเกจ ก็ต้อง เช็คว่า คนนี้มาใช้บริการครบจำครั้งที่ต้องทำ กับ จำนวนที่แถม แล้วหรือยัง ถ้าครบแล้วก็ต้องจ่ายตังเพิ่ม แต่ถ้ายังก็
                        ' ทำได้เลย โดยการ ลดราคาสิ่งที่ทำ
                        'priceprom += (pricenornal)
                        If grid_packet.Rows(rownow).Cells(5).Value = "F" Then
                            pricepacket += Double.Parse(grid_chooseprom.Rows(rownow).Cells(3).Value)
                            pricenow += Double.Parse(grid_chooseprom.Rows(rownow).Cells(3).Value)
                        End If
                    End If
                    price_normal.Text = (pricenornal - pricedel).ToString("#,##0.00")
                    'price_prom.Text = priceprom.ToString("#,##0.00")
                    price_packet.Text = pricepacket.ToString("#,##0.00")
                    price_all.Text = (pricenow - pricedel).ToString("#,##0.00")
                End If
                rownow += 1
            Next

            If doinpacketalready = False Then ' กรณีที่ รายการบริการที่เลือกไม่ตรงกับ โปรโมชั่นที่ต้องซื้อก่อนหน้านี้เลย
                rownow = 0
                For Each promlistforchk As DataGridViewRow In grid_chooseprom.Rows
                    Dim servlistdatatable As DataTable = get_Promlistall(promlistforchk.Cells(5).Value.ToString)
                    Dim thispromlist_count As Integer = servlistdatatable.Rows.Count
                    Dim pname As String = ""
                    For Each promservlist As DataRow In servlistdatatable.Rows ' รายการบริการ แต่ละโปรโมชั่น
                        For i As Integer = 0 To serv_dontabout_prom.Count - 1 ' รายการบริการที่เลือกมาใน ดาตากริด
                            If serv_dontabout_prom(i).Cells(1).Value <> "" Then
                                If serv_dontabout_prom(i).Cells(2).Value.Equals(promservlist(1)) And
                                    serv_dontabout_prom(i).Cells(3).Value.Equals(promservlist(2)) And
                                    serv_dontabout_prom(i).Cells(4).Value.Equals(promservlist(3)) Then
                                    thispromlist_count -= 1
                                End If
                            End If
                        Next
                        If thispromlist_count = 0 Then
                            pname = promservlist(1)
                        End If
                    Next
                    If thispromlist_count = 0 Then
                        MsgBox("คุณสามารถใช้โปรโมชั่น " & pname & " ได้เลยในหน้าจอการใช้บริการ")
                        'Dim promservnew As DataTable = get_Promlistall(grid_packet.Rows(rownow).Cells(6).Value) ' โปรโมชั่นที่เลือก
                        'Dim flag_is_packet As Boolean = False
                        'If grid_packet.Rows(rownow).Cells(5).Value = "F" And grid_packet.Rows(rownow).Cells(2).Value = "แพ็คเกจ" And grid_packet.Rows(rownow).Cells(0).Value = False Then
                        '    Dim answer As DialogResult
                        '    answer = MessageBox.Show("คุณต้องการสมัคร แพ็คเกจนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        '    If answer = vbNo Then
                        '        grid_packet.RefreshEdit()
                        '        grid_packet.Rows(rownow).Cells(0).Value = False
                        '        'Dim checkCell As DataGridViewCheckBoxCell = grid_packet.Rows(nowdatais).Cells(0)
                        '        grid_packet.UpdateCellValue(0, rownow)
                        '        'delservadd(promservnew)
                        '        Exit Sub
                        '    ElseIf answer = vbYes Then
                        '        grid_packet.Rows(rownow).Cells(0).Value = True
                        '        'Dim checkCell As DataGridViewCheckBoxCell = grid_packet.Rows(nowdatais).Cells(0)
                        '        grid_packet.UpdateCellValue(0, rownow)
                        '        flag_is_packet = True
                        '    End If
                        'End If
                        'Dim pricenornal As Double = Double.Parse(price_normal.Text)
                        'Dim pricedo As Double = 0.0
                        'Dim priceprom As Double = 0.0
                        'Dim pricepacket As Double = Double.Parse(price_packet.Text)
                        'Dim pricenow As Double = Double.Parse(price_all.Text)
                        'Dim pricedel As Double = 0.0
                        'For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
                        '    If servlistrow(5) = "do" Then
                        '        pricedo += Double.Parse(servlistrow(3))
                        '    End If
                        '    pricenornal += Double.Parse(servlistrow(3))
                        '    pricedel += Double.Parse(servlistrow(3))
                        'Next
                        'If grid_packet.Rows(rownow).Cells(2).Value = "ส่วนลด" Then
                        '    Dim paymoney As Double = 0
                        '    pricenow += Double.Parse(grid_packet.Rows(rownow).Cells(3).Value)
                        '    'If grid_packet.Rows(nowdatais).Cells(5).Value <> "F" Then
                        '    '    paymoney = Double.Parse(price_all.Text)
                        '    'End If
                        '    'priceprom += Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value) '(pricenornal) '- Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value))
                        'ElseIf grid_packet.Rows(rownow).Cells(2).Value = "แถม-ฟรี" Then
                        '    'ตรงแถมฟรี ยังไงก็ต้อง เช็คว่า คนนี้มาใช้บริการแล้วกี่ครั้งถ้ายังใช่บริการไม่ครบก็ไม่สามารถใช่สิทธิ์ แถมฟรีได้
                        '    'priceprom += (pricenornal - pricedo)
                        '    pricenow += pricedo
                        'ElseIf grid_packet.Rows(rownow).Cells(2).Value = "แพ็คเกจ" Then
                        '    ' ตรงแพ็คเกจ ก็ต้อง เช็คว่า คนนี้มาใช้บริการครบจำครั้งที่ต้องทำ กับ จำนวนที่แถม แล้วหรือยัง ถ้าครบแล้วก็ต้องจ่ายตังเพิ่ม แต่ถ้ายังก็
                        '    ' ทำได้เลย โดยการ ลดราคาสิ่งที่ทำ
                        '    'priceprom += (pricenornal)
                        '    If grid_packet.Rows(rownow).Cells(5).Value = "F" Then
                        '        pricepacket += Double.Parse(grid_packet.Rows(rownow).Cells(3).Value)
                        '        pricenow += Double.Parse(grid_packet.Rows(rownow).Cells(3).Value)
                        '    End If
                        'End If
                        'price_normal.Text = (pricenornal - pricedel).ToString("#,##0.00")
                        ''price_prom.Text = priceprom.ToString("#,##0.00")
                        'price_packet.Text = pricepacket.ToString("#,##0.00")
                        'price_all.Text = (pricenow - pricedel).ToString("#,##0.00")
                    End If
                    rownow += 1
                Next
            End If
        End If
    End Sub
    Private Function get_Promlistall(ByVal promid As String) As DataTable
        Dim sqlchooseprom As String = " select ROW_NUMBER() over (order by a.liserv_id) 'ลำดับ',liserv_name 'รายการบริการ' , b.liserv_type_name 'ประเภทรายการบริการ'  " &
                    " , convert(varchar,liserv_price,1) 'ราคา' , convert(varchar,a.liserv_id) , 'prom' 'datatype' " &
                    " from service_list a(nolock)  " &
                    " join service_list_type b(nolock) on a.liserv_type_id = b.liserv_type_id  " &
                    " join promotion_detail c(nolock) on a.liserv_id = c.liserv_id" &
                    " join promotion d(nolock) on c.prom_id = d.prom_id  " &
                    " where d.prom_id = " & promid ' ดึงข้อมูลของ การบริการที่แถมของแต่ละ โปรโมชั่นมา 

        Dim sqlchooseprom_do As String = "select ROW_NUMBER() over (order by a.liserv_id) 'ลำดับ',liserv_name 'รายการบริการ' , c.liserv_type_name 'ประเภทรายการบริการ' " &
            " , convert(varchar,liserv_price,1) 'ราคา' , convert(varchar,a.liserv_id) , 'do' 'datatype' from service_promotion a(nolock) " &
            " join service_list b(nolock) on a.liserv_id = b.liserv_id " &
            " join service_list_type c(nolock) on b.liserv_type_id = c.liserv_type_id " &
            " where a.prom_id = " & promid ' ดึงข้อมูลของการบริการที่ต้องทำ ( เป็นกรณีที่ แถม - ฟรี )

        Dim servlistdatatable As DataTable = Obj_query.selectDatatoGrid(sqlchooseprom)
        Dim servlist_prom As DataTable = Obj_query.selectDatatoGrid(sqlchooseprom)
        Dim servlist_havetodo As DataTable = Obj_query.selectDatatoGrid(sqlchooseprom_do)
        If servlist_havetodo.Rows.Count > 0 Then
            ' clear data if duplicate
            For i As Integer = 0 To servlistdatatable.Rows.Count - 1
                Dim indexhavetodo As Integer = servlist_havetodo.Rows.Count - 1
                While indexhavetodo >= 0
                    If servlistdatatable.Rows(i)(1) = servlist_havetodo.Rows(indexhavetodo)(1) And servlistdatatable.Rows(i)(2) = servlist_havetodo.Rows(indexhavetodo)(2) Then
                        servlist_havetodo.Rows.RemoveAt(indexhavetodo)
                        Exit For
                    End If
                    indexhavetodo -= 1
                End While
            Next
            servlistdatatable.Merge(servlist_havetodo)
        End If
        Return servlistdatatable
    End Function

    Private Sub grid_servresult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_servresult.CellContentClick

    End Sub

    Private Sub grid_chooseprom_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_chooseprom.CellClick
        ' เอาข้อมูลโปรโมชั่นไปแสดงใน ดาต้ากริดแสดงรายการ โปรโมชั่นที่เลือก
        Dim nowdatais As Integer = e.RowIndex
        Dim promservnew As DataTable = get_Promlistall(grid_chooseprom.Rows(nowdatais).Cells(5).Value) ' โปรโมชั่นที่เลือก
        grp_selectprom.Text = "รายการบริการของ โปรโมชั่น " & grid_chooseprom.Rows(nowdatais).Cells(0).Value
        grid_selectprom.Rows.Clear()
        Dim promrunno As Integer = 1
        For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
            Dim rowinsert As String() = New String() {False, promrunno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
            grid_selectprom.Rows.Add(rowinsert)
            promrunno += 1
        Next
    End Sub

    Private Sub grid_chooseprom_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_chooseprom.CellContentClick
        'Dim nowdatais As Integer = 0
        'nowadd = "prom"
        'If grid_chooseprom.CurrentCell.ColumnIndex.Equals(0) Then
        '    Dim nowaction As String = "add"
        '    Dim pricenornal As Double = Double.Parse(price_normal.Text)
        '    Dim pricedo As Double = 0.0
        '    Dim priceprom As Double = 0.0
        '    Dim pricepacket As Double = Double.Parse(price_packet.Text)
        '    Dim pricenow As Double = Double.Parse(price_all.Text)
        '    nowdatais = e.RowIndex
        '    Dim promservnew As DataTable = get_Promlistall(grid_chooseprom.Rows(nowdatais).Cells(6).Value) ' โปรโมชั่นที่เลือก

        '    ' เอาข้อมูลโปรโมชั่นไปแสดงใน ดาต้ากริดแสดงรายการ โปรโมชั่นที่เลือก
        '    grp_selectprom.Text = "รายการบริการของ โปรโมชั่น " & grid_chooseprom.Rows(nowdatais).Cells(1).Value
        '    grid_selectprom.Rows.Clear()
        '    Dim promrunno As Integer = 1
        '    For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
        '        Dim rowinsert As String() = New String() {False, promrunno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
        '        grid_selectprom.Rows.Add(rowinsert)
        '        promrunno += 1
        '    Next

        '    If grid_chooseprom.Rows(nowdatais).Cells(5).Value = "F" And grid_chooseprom.Rows(nowdatais).Cells(2).Value = "แพ็คเกจ" And grid_chooseprom.Rows(nowdatais).Cells(0).Value = False Then
        '        Dim flagdup As Boolean = False
        '        Dim promname As String = ""
        '        For Each promadd As DataRow In promservnew.Rows
        '            For Each prominlist As DataGridViewRow In grid_showservlist.Rows
        '                If promadd(1) = prominlist.Cells(2).Value And promadd(2) = prominlist.Cells(3).Value Then
        '                    flagdup = True
        '                    promname = promadd(1)
        '                    Exit For
        '                End If
        '            Next
        '        Next

        '        If flagdup = True Then
        '            MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_chooseprom.Rows(nowdatais).Cells(1).Value & " นี้ได้ เนื่องจาก รายการบริการซ้ำกับ โปรโมชั่นอื่น")
        '            grid_chooseprom.Rows(nowdatais).Cells(0).Value = False
        '            'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
        '            grid_chooseprom.UpdateCellValue(0, nowdatais)
        '            Exit Sub
        '        Else
        '            Dim answer As DialogResult
        '            answer = MessageBox.Show("คุณต้องการสมัคร แพ็คเกจนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '            If answer = vbNo Then
        '                grid_chooseprom.RefreshEdit()
        '                grid_chooseprom.Rows(nowdatais).Cells(0).Value = False
        '                'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
        '                grid_chooseprom.UpdateCellValue(0, nowdatais)
        '                Exit Sub
        '            End If
        '        End If

        '    End If

        '    ' check dup with packet 

        '    For Each rowprom As DataGridViewRow In grid_packet.Rows
        '        If rowprom.Cells(0).Value = True Then
        '            Dim flagdup As Boolean = False
        '            Dim promname As String = ""
        '            Dim prompacket As DataTable = get_Promlistall(rowprom.Cells(6).Value)
        '            For Each promadd As DataRow In promservnew.Rows
        '                For Each prompacket2 As DataRow In prompacket.Rows
        '                    If promadd(1) = prompacket2(1) And promadd(2) = prompacket2(2) Then
        '                        flagdup = True
        '                        promname = promadd(1)
        '                        Exit For
        '                    End If
        '                Next
        '            Next
        '            If flagdup = True Then
        '                MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_chooseprom.Rows(nowdatais).Cells(1).Value & " นี้ได้ เนื่องจาก รายการบริการซ้ำกับ โปรโมชั่นอื่น")
        '                grid_chooseprom.Rows(nowdatais).Cells(0).Value = False
        '                'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
        '                grid_chooseprom.UpdateCellValue(0, nowdatais)
        '                Exit Sub
        '            Else
        '            End If
        '        End If
        '    Next
        '    If grid_chooseprom.CurrentCell.Value = True Then
        '        'grid_chooseprom.CurrentCell.Value = False
        '        nowaction = "del"
        '    Else
        '        'grid_chooseprom.CurrentCell.Value = True
        '        nowaction = "add"
        '    End If
        '    ' check dup promotion if promotion for register
        '    'Dim duplicateProm As ArrayList = New ArrayList()
        '    'form_chooseduppromotion.cbo_dupprom.Items.Clear()
        '    If nowaction = "add" Then
        '        If grid_chooseprom.Rows(nowdatais).Cells(7).Value = "Y" Then ' Check โปรโมชั่น ที่เป็นโปรโมชั่นกับการสมัครสมาชิก
        '            Dim countpromfor_reg As Integer = 0
        '            For Each promlist As DataGridViewRow In grid_chooseprom.Rows
        '                If promlist.Cells(0).Value = True And promlist.Cells(7).Value = "Y" And promlist.Cells(1).Value <> grid_chooseprom.Rows(nowdatais).Cells(1).Value Then ' หาโปรโมชั่นที่เป็นโปรโมชั่นของการสมัครสมาชิกอันแรกที่เจอ
        '                    countpromfor_reg += 1
        '                End If
        '            Next
        '            If countpromfor_reg > 0 Then
        '                MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_chooseprom.Rows(nowdatais).Cells(1).Value & "นี้ได้")
        '                grid_chooseprom.RefreshEdit()
        '                grid_chooseprom.Rows(nowdatais).Cells(0).Value = False
        '                'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
        '                grid_chooseprom.UpdateCellValue(0, nowdatais)
        '                Exit Sub
        '            End If
        '        End If

        '        ' ตรวจสอบโปรโมชั่น ทั่วไป ในกรณีที่เลือกมาใหม่ ดูว่าสิ่งที่เลือกมาใหม่ ที่อยุ่แล้วกับโปรโมชั่นที่เลือกก่อนหน้าหรือเปล่า
        '        Dim countpromfor_regnormal As Integer = 0
        '        For Each promlist As DataGridViewRow In grid_chooseprom.Rows
        '            If promlist.Cells(0).Value = True And promlist.Cells(6).Value <> grid_chooseprom.Rows(nowdatais).Cells(6).Value Then
        '                Dim promservlistall As DataTable = get_Promlistall(promlist.Cells(6).Value)
        '                Dim count As Integer = promservlistall.Rows.Count
        '                Dim flag As Boolean = False
        '                For Each rowserv As DataRow In promservlistall.Rows
        '                    For Each rowservnow As DataRow In promservnew.Rows
        '                        If rowserv(1) = rowservnow(1) And rowserv(2) = rowservnow(2) Then
        '                            flag = True
        '                            Exit For
        '                        End If
        '                    Next
        '                Next
        '                If flag = True Then
        '                    MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_chooseprom.Rows(nowdatais).Cells(1).Value & " นี้ได้ เนื่องจาก รายการบริการซ้ำกับ โปรโมชั่น " & promlist.Cells(1).Value)
        '                    grid_chooseprom.RefreshEdit()
        '                    grid_chooseprom.Rows(nowdatais).Cells(0).Value = False
        '                    'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
        '                    grid_chooseprom.UpdateCellValue(0, nowdatais)
        '                    Exit Sub
        '                End If
        '            End If
        '        Next

        '        ' add servlist to grid
        '        Dim runno As Integer = 1
        '        If grid_showservlist.Rows.Count > 0 Then
        '            runno = grid_showservlist.Rows.Count
        '        End If
        '        For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
        '            Dim rowinsert As String() = New String() {False, runno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
        '            grid_showservlist.Rows.Add(rowinsert)
        '            If servlistrow(5) = "do" Then
        '                pricedo += Double.Parse(servlistrow(3))
        '            End If
        '            pricenornal += Double.Parse(servlistrow(3))
        '            runno += 1
        '        Next
        '        If grid_chooseprom.Rows(nowdatais).Cells(2).Value = "ส่วนลด" Then
        '            Dim paymoney As Double = 0
        '            pricenow += Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value)
        '            'If grid_chooseprom.Rows(nowdatais).Cells(5).Value <> "F" Then
        '            '    paymoney = Double.Parse(price_all.Text)
        '            'End If
        '            'priceprom += Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value) '(pricenornal) '- Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value))
        '        ElseIf grid_chooseprom.Rows(nowdatais).Cells(2).Value = "แถม-ฟรี" Then
        '            'ตรงแถมฟรี ยังไงก็ต้อง เช็คว่า คนนี้มาใช้บริการแล้วกี่ครั้งถ้ายังใช่บริการไม่ครบก็ไม่สามารถใช่สิทธิ์ แถมฟรีได้
        '            'priceprom += (pricenornal - pricedo)
        '            pricenow += pricedo
        '        ElseIf grid_chooseprom.Rows(nowdatais).Cells(2).Value = "แพ็คเกจ" Then
        '            ' ตรงแพ็คเกจ ก็ต้อง เช็คว่า คนนี้มาใช้บริการครบจำครั้งที่ต้องทำ กับ จำนวนที่แถม แล้วหรือยัง ถ้าครบแล้วก็ต้องจ่ายตังเพิ่ม แต่ถ้ายังก็
        '            ' ทำได้เลย โดยการ ลดราคาสิ่งที่ทำ
        '            'priceprom += (pricenornal)
        '            If grid_chooseprom.Rows(nowdatais).Cells(5).Value = "F" Then
        '                pricepacket += Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value)
        '                pricenow += Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value)
        '            End If
        '        End If
        '    ElseIf nowaction = "del" Then
        '        ' add servlist to grid
        '        Dim rowdelindex = 0
        '        Dim gridcount As Integer = grid_showservlist.Rows.Count - 1
        '        While (gridcount >= 0)
        '            For Each delrow As DataRow In promservnew.Rows
        '                If grid_showservlist.Rows(gridcount).Cells(2).Value = delrow(1) And grid_showservlist.Rows(gridcount).Cells(3).Value = delrow(2) Then
        '                    grid_showservlist.Rows(gridcount).Cells(0).Value = True
        '                End If
        '            Next
        '            gridcount -= 1
        '        End While

        '        Dim totalserv = grid_showservlist.Rows.Count - 1
        '        While (totalserv >= 0)
        '            If grid_showservlist.Rows(totalserv).Cells(0).Value = True Then
        '                grid_showservlist.Rows.RemoveAt(totalserv)
        '            End If
        '            totalserv -= 1
        '        End While


        '        Dim pricedelnormal As Double = 0.0
        '        For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
        '            'Dim rowinsert As String() = New String() {False, runno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
        '            'grid_showservlist.Rows.Add(rowinsert)
        '            If servlistrow(5) = "do" Then
        '                pricedo += Double.Parse(servlistrow(3))
        '            End If
        '            pricenornal -= Double.Parse(servlistrow(3))
        '            pricedelnormal += Double.Parse(servlistrow(3))
        '        Next
        '        If grid_chooseprom.Rows(nowdatais).Cells(2).Value = "ส่วนลด" Then
        '            'MsgBox("A" & priceprom & " : " & pricenornal)
        '            pricenow -= Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value)
        '            'priceprom -= (pricedelnormal - Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value))
        '            'MsgBox("B" & priceprom & " : " & pricenornal)
        '        ElseIf grid_chooseprom.Rows(nowdatais).Cells(2).Value = "แถม-ฟรี" Then
        '            'ตรงแถมฟรี ยังไงก็ต้อง เช็คว่า คนนี้มาใช้บริการแล้วกี่ครั้งถ้ายังใช่บริการไม่ครบก็ไม่สามารถใช่สิทธิ์ แถมฟรีได้
        '            'priceprom -= (pricedelnormal - pricedo)
        '            pricenow -= pricedo
        '        ElseIf grid_chooseprom.Rows(nowdatais).Cells(2).Value = "แพ็คเกจ" Then
        '            ' ตรงแพ็คเกจ ก็ต้อง เช็คว่า คนนี้มาใช้บริการครบจำครั้งที่ต้องทำ กับ จำนวนที่แถม แล้วหรือยัง ถ้าครบแล้วก็ต้องจ่ายตังเพิ่ม แต่ถ้ายังก็
        '            ' ทำได้เลย โดยการ ลดราคาสิ่งที่ทำ
        '            'priceprom -= (pricedelnormal)
        '            If grid_chooseprom.Rows(nowdatais).Cells(5).Value = "F" Then
        '                pricepacket -= Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value)
        '                pricenow -= Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value)
        '            End If
        '        End If
        '    End If

        '    'pricenow = (pricenornal - priceprom + pricepacket)
        '    price_normal.Text = pricenornal.ToString("#,##0.00")
        '    'price_prom.Text = priceprom.ToString("#,##0.00")
        '    price_packet.Text = pricepacket.ToString("#,##0.00")
        '    price_all.Text = pricenow.ToString("#,##0.00")
        '    grid_chooseprom.Rows(e.RowIndex).Selected = False
        'End If
    End Sub


    Private Sub btn_choosemember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_choosemember.Click

        Dim serv_dontabout_prom As ArrayList = New ArrayList
        For Each rowlist As DataGridViewRow In grid_showservlist.Rows
            serv_dontabout_prom.Add(rowlist)
        Next

        Dim showforchooseemp As ArrayList = New ArrayList()
        For Each promserv As DataGridViewRow In grid_chooseprom.Rows
            If promserv.Cells(0).Value = True Then
                Dim chkservlist As DataTable = get_Promlistall(promserv.Cells(6).Value.ToString)
                Dim flag As Boolean = False
                For Each rowpromserv As DataRow In chkservlist.Rows
                    Dim count As Integer = serv_dontabout_prom.Count - 1
                    flag = False
                    While (count >= 0)
                        'MsgBox(rowpromserv(1) & " : " & serv_dontabout_prom(count).Cells(2).Value & " : " & rowpromserv(2) & " : " & serv_dontabout_prom(count).Cells(3).Value)
                        If rowpromserv(1) = serv_dontabout_prom(count).Cells(2).Value And rowpromserv(2) = serv_dontabout_prom(count).Cells(3).Value Then
                            'serv_dontabout_prom.RemoveAt(count)
                            serv_dontabout_prom.RemoveAt(count)
                            flag = True
                        End If
                        count -= 1
                    End While
                Next
                If flag = True Or promserv.Cells(1).Value = "แพ็คเกจ" Then
                    showforchooseemp.Add(promserv.Cells(1).Value & "|" & promserv.Cells(6).Value.ToString & "|P") ' P = Promotion
                End If
            End If
        Next

        For Each promserv As DataGridViewRow In grid_packet.Rows
            If promserv.Cells(0).Value = True Then
                Dim chkservlist As DataTable = get_Promlistall(promserv.Cells(6).Value.ToString)
                Dim flag As Boolean = False
                For Each rowpromserv As DataRow In chkservlist.Rows
                    Dim count As Integer = serv_dontabout_prom.Count - 1
                    flag = False
                    While (count >= 0)
                        'MsgBox(rowpromserv(1) & " : " & serv_dontabout_prom(count).Cells(2).Value & " : " & rowpromserv(2) & " : " & serv_dontabout_prom(count).Cells(3).Value)
                        If rowpromserv(1) = serv_dontabout_prom(count).Cells(2).Value And rowpromserv(2) = serv_dontabout_prom(count).Cells(3).Value Then
                            'serv_dontabout_prom.RemoveAt(count)
                            serv_dontabout_prom.RemoveAt(count)
                            flag = True
                        End If
                        count -= 1
                    End While
                Next
                If flag = True Or promserv.Cells(1).Value = "แพ็คเกจ" Then
                    showforchooseemp.Add(promserv.Cells(1).Value & "|" & promserv.Cells(6).Value.ToString & "|P") ' P = Promotion
                End If
            End If
        Next
        For Each servleft As DataGridViewRow In serv_dontabout_prom
            showforchooseemp.Add(servleft.Cells(2).Value & "( " & servleft.Cells(3).Value & " )" & "|" & servleft.Cells(5).Value & "|S") ' S = Service
        Next

        Dim sql As String = "select emp_id 'ID' , emp_fullname 'Name' from employee(nolock)"
        Dim datatbl As DataTable = Obj_query.selectDatatoGrid(sql)
        Dim cbo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        cbo.HeaderText = "เลือกพนักงาน"
        cbo.Width = 156
        cbo.DataSource = datatbl
        cbo.ValueMember = "ID"
        cbo.DisplayMember = "Name"
        For Each chooseemp As String In showforchooseemp
            Dim info As String() = chooseemp.Split("|")
            Dim n As Integer = form_empserv.grid_servemp.Rows.Add()
            form_empserv.grid_servemp.Rows(n).Cells(0).Value = info(0)
            form_empserv.grid_servemp.Rows(n).Cells(1).Value = info(1)
            form_empserv.grid_servemp.Rows(n).Cells(2).Value = info(2)
            If service_type.Count > 0 Then
                For i As Integer = 0 To service_type.Count - 1
                    Dim haveemp As Boolean = False
                    If info(1) = service_id(i) And info(2) = service_type(i) Then 'รหัสการบริการ หรือ รหัสโปรโมชั่น'
                        For Each empname As DataRow In datatbl.Rows
                            If service_empid(i) = empname(0) Then
                                form_empserv.grid_servemp.Rows(n).Cells(3).Value = empname(1)
                                haveemp = True
                            End If
                        Next
                    Else
                        form_empserv.grid_servemp.Rows(n).Cells(3).Value = "กรุณาเลือกพนักงาน"
                    End If
                    If haveemp = True Then
                        Exit For
                    End If
                Next
            Else
                form_empserv.grid_servemp.Rows(n).Cells(3).Value = "กรุณาเลือกพนักงาน"
            End If
            'form_empserv.grid_servemp.Rows(n).Cells(1).Value = cbo
        Next
        form_empserv.grid_servemp.Columns.Add(cbo)
        form_empserv.Show()
    End Sub

    Private Sub btn_searchserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchserv.Click
        Dim index As Integer = cbo_searchserv.SelectedIndex
        Dim textsearch As String = txt_searchserv.Text
        Dim searchsql As String = ""
        If index = 0 Then ' total
            searchsql = "select ROW_NUMBER() over (order by serv_id desc)'ลำดับ',serv_date 'วันที่บริการ'," &
        " b.cus_fullname 'สมาชิกมาใช้บริการ' , c.emp_fullname 'พนักงานทำรายการ' , serv_comment 'หมายเหตุ' " &
        " ,case when serv_sts = 'S' then 'เสร็จสมบูรณ์' when serv_sts = 'C' then 'ยกเลิกรายการ' end 'สถานะการบริการ',serv_id 'รหัสการบริการ',b.cus_id,b.custype_id" &
        " from service a(nolock) " &
        " join customer b(nolock) on a.cus_id = b.cus_id" &
        " join employee c(nolock) on a.emp_id = c.emp_id" &
        " where serv_sts <> 'C'" &
        " order by serv_id desc"
        ElseIf index = 1 Then ' service date
            searchsql = "select ROW_NUMBER() over (order by serv_id desc)'ลำดับ',serv_date 'วันที่บริการ'," &
        " b.cus_fullname 'สมาชิกมาใช้บริการ' , c.emp_fullname 'พนักงานทำรายการ' , serv_comment 'หมายเหตุ' " &
        " ,case when serv_sts = 'S' then 'เสร็จสมบูรณ์' when serv_sts = 'C' then 'ยกเลิกรายการ' end 'สถานะการบริการ',serv_id 'รหัสการบริการ',b.cus_id,b.custype_id" &
        " from service a(nolock) " &
        " join customer b(nolock) on a.cus_id = b.cus_id" &
        " join employee c(nolock) on a.emp_id = c.emp_id" &
        " where serv_sts <> 'C' and convert(varchar(10),serv_date,103) = '" & textsearch & "'" &
        " order by serv_id desc"
        ElseIf index = 2 Then ' customer name
            searchsql = "select ROW_NUMBER() over (order by serv_id desc)'ลำดับ',serv_date 'วันที่บริการ'," &
        " b.cus_fullname 'สมาชิกมาใช้บริการ' , c.emp_fullname 'พนักงานทำรายการ' , serv_comment 'หมายเหตุ' " &
        " ,case when serv_sts = 'S' then 'เสร็จสมบูรณ์' when serv_sts = 'C' then 'ยกเลิกรายการ' end 'สถานะการบริการ',serv_id 'รหัสการบริการ',b.cus_id,b.custype_id" &
        " from service a(nolock) " &
        " join customer b(nolock) on a.cus_id = b.cus_id" &
        " join employee c(nolock) on a.emp_id = c.emp_id" &
        " where serv_sts <> 'C' and  b.cus_fullname like '" & textsearch & "%' or b.cus_fullname like '%" & textsearch & "%' or b.cus_fullname like '%" & textsearch & "'" &
        " order by serv_id desc"
        ElseIf index = 3 Then
            searchsql = "select ROW_NUMBER() over (order by serv_id desc)'ลำดับ',serv_date 'วันที่บริการ'," &
        " b.cus_fullname 'สมาชิกมาใช้บริการ' , c.emp_fullname 'พนักงานทำรายการ' , serv_comment 'หมายเหตุ' " &
        " ,case when serv_sts = 'S' then 'เสร็จสมบูรณ์' when serv_sts = 'C' then 'ยกเลิกรายการ' end 'สถานะการบริการ',serv_id 'รหัสการบริการ',b.cus_id,b.custype_id" &
        " from service a(nolock) " &
        " join customer b(nolock) on a.cus_id = b.cus_id" &
        " join employee c(nolock) on a.emp_id = c.emp_id" &
        " where serv_sts = 'C'" &
        " order by serv_id desc"
        End If
        GetDataToGrid(searchsql, grid_servresult)
    End Sub

    Private Sub cbo_searchserv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_searchserv.SelectedIndexChanged
        Dim index As Integer = cbo_searchserv.SelectedIndex
        If index = 0 Then
            txt_searchserv.Text = ""
        End If
    End Sub

    Private Sub grid_showservlist_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showservlist.CellContentClick

    End Sub

    Private Sub btn_delservlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delservlist.Click
        Dim totalserv = grid_showservlist.Rows.Count - 1
        While (totalserv >= 0)
            If grid_showservlist.Rows(totalserv).Cells(0).Value = True Then
                grid_showservlist.Rows.RemoveAt(totalserv)
            End If
            totalserv -= 1
        End While
    End Sub

    Private Sub grid_packet_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_packet.CellClick
        ' เอาข้อมูลโปรโมชั่นไปแสดงใน ดาต้ากริดแสดงรายการ โปรโมชั่นที่เลือก
        If e.ColumnIndex <> 0 Then
            Dim nowdatais As Integer = e.RowIndex
            Dim promservnew As DataTable = get_Promlistall(grid_packet.Rows(nowdatais).Cells(6).Value) ' โปรโมชั่นที่เลือก
            grp_selectprom.Text = "รายการบริการของ โปรโมชั่น " & grid_packet.Rows(nowdatais).Cells(1).Value
            grid_selectprom.Rows.Clear()
            Dim promrunno As Integer = 1
            For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
                Dim rowinsert As String() = New String() {False, promrunno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
                grid_selectprom.Rows.Add(rowinsert)
                promrunno += 1
            Next
        End If
        
    End Sub

    Private Sub grid_packet_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_packet.CellContentClick
        Dim nowdatais As Integer = 0
        If grid_packet.CurrentCell.ColumnIndex.Equals(0) Then
            Dim nowaction As String = "add"
            Dim pricenornal As Double = Double.Parse(price_normal.Text)
            Dim pricedo As Double = 0.0
            Dim priceprom As Double = 0.0
            Dim pricepacket As Double = Double.Parse(price_packet.Text)
            Dim pricenow As Double = Double.Parse(price_all.Text)
            nowdatais = e.RowIndex
            Dim promservnew As DataTable = get_Promlistall(grid_packet.Rows(nowdatais).Cells(6).Value) ' โปรโมชั่นที่เลือก

            If grid_packet.CurrentCell.Value = True Then
                'grid_chooseprom.CurrentCell.Value = False
                nowaction = "del"
                grid_packet.Rows(nowdatais).Cells(0).Value = False
                'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
                grid_packet.UpdateCellValue(0, nowdatais)
            Else
                'grid_chooseprom.CurrentCell.Value = True
                Dim flagdup As Boolean = False
                Dim promname As String = ""
                For Each promadd As DataRow In promservnew.Rows
                    For Each prominlist As DataGridViewRow In grid_showservlist.Rows
                        If promadd(1) = prominlist.Cells(2).Value And promadd(2) = prominlist.Cells(3).Value Then
                            flagdup = True
                            promname = promadd(1)
                            Exit For
                        End If
                    Next
                Next

                If flagdup = True Then
                    MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_packet.Rows(nowdatais).Cells(1).Value & " นี้ได้ เนื่องจาก รายการบริการซ้ำกับ โปรโมชั่นอื่น")
                    grid_packet.Rows(nowdatais).Cells(0).Value = False
                    'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
                    grid_packet.UpdateCellValue(0, nowdatais)
                    Exit Sub
                End If

                Dim answer As DialogResult
                answer = MessageBox.Show("คุณต้องการสมัคร แพ็คเกจนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If answer = vbNo Then
                    grid_packet.RefreshEdit()
                    grid_packet.Rows(nowdatais).Cells(0).Value = False
                    'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
                    grid_packet.UpdateCellValue(0, nowdatais)
                    Exit Sub
                Else
                    clickinchoosepromotion = True
                    nowaction = "add"
                    grid_packet.Rows(nowdatais).Cells(0).Value = True
                    'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
                    grid_packet.UpdateCellValue(0, nowdatais)
                End If
                
            End If


            'If grid_packet.Rows(nowdatais).Cells(5).Value = "F" And grid_packet.Rows(nowdatais).Cells(2).Value = "แพ็คเกจ" And grid_packet.Rows(nowdatais).Cells(0).Value = False Then
            

            'End If

            ' check dup with packet 

            'For Each rowprom As DataGridViewRow In grid_packet.Rows
            '    If rowprom.Cells(0).Value = True Then
            '        Dim flagdup As Boolean = False
            '        Dim promname As String = ""
            '        Dim prompacket As DataTable = get_Promlistall(rowprom.Cells(6).Value)
            '        For Each promadd As DataRow In promservnew.Rows
            '            For Each prompacket2 As DataRow In prompacket.Rows
            '                If promadd(1) = prompacket2(1) And promadd(2) = prompacket2(2) Then
            '                    flagdup = True
            '                    promname = promadd(1)
            '                    Exit For
            '                End If
            '            Next
            '        Next
            '        If flagdup = True Then
            '            MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_chooseprom.Rows(nowdatais).Cells(1).Value & " นี้ได้ เนื่องจาก รายการบริการซ้ำกับ โปรโมชั่นอื่น")
            '            grid_chooseprom.Rows(nowdatais).Cells(0).Value = False
            '            'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
            '            grid_chooseprom.UpdateCellValue(0, nowdatais)
            '            Exit Sub
            '        Else
            '        End If
            '    End If
            'Next

            
            ' check dup promotion if promotion for register
            'Dim duplicateProm As ArrayList = New ArrayList()
            'form_chooseduppromotion.cbo_dupprom.Items.Clear()
            If nowaction = "add" Then
                If grid_packet.Rows(nowdatais).Cells(7).Value = "Y" Then ' Check โปรโมชั่น ที่เป็นโปรโมชั่นกับการสมัครสมาชิก
                    Dim countpromfor_reg As Integer = 0
                    For Each promlist As DataGridViewRow In grid_packet.Rows
                        If promlist.Cells(0).Value = True And promlist.Cells(7).Value = "Y" And promlist.Cells(1).Value <> grid_packet.Rows(nowdatais).Cells(1).Value Then ' หาโปรโมชั่นที่เป็นโปรโมชั่นของการสมัครสมาชิกอันแรกที่เจอ
                            countpromfor_reg += 1
                        End If
                    Next
                    If countpromfor_reg > 0 Then
                        MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_packet.Rows(nowdatais).Cells(1).Value & "นี้ได้")
                        grid_packet.RefreshEdit()
                        grid_packet.Rows(nowdatais).Cells(0).Value = False
                        'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
                        grid_packet.UpdateCellValue(0, nowdatais)
                        Exit Sub
                    End If
                End If

                ' ตรวจสอบโปรโมชั่น ทั่วไป ในกรณีที่เลือกมาใหม่ ดูว่าสิ่งที่เลือกมาใหม่ ที่อยุ่แล้วกับโปรโมชั่นที่เลือกก่อนหน้าหรือเปล่า
                Dim countpromfor_regnormal As Integer = 0
                For Each promlist As DataGridViewRow In grid_packet.Rows
                    If promlist.Cells(0).Value = True And promlist.Cells(6).Value <> grid_packet.Rows(nowdatais).Cells(6).Value Then
                        Dim promservlistall As DataTable = get_Promlistall(promlist.Cells(6).Value)
                        Dim count As Integer = promservlistall.Rows.Count
                        Dim flag As Boolean = False
                        For Each rowserv As DataRow In promservlistall.Rows
                            For Each rowservnow As DataRow In promservnew.Rows
                                If rowserv(1) = rowservnow(1) And rowserv(2) = rowservnow(2) Then
                                    flag = True
                                    Exit For
                                End If
                            Next
                        Next
                        If flag = True Then
                            MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_packet.Rows(nowdatais).Cells(1).Value & " นี้ได้ เนื่องจาก รายการบริการซ้ำกับ โปรโมชั่น " & promlist.Cells(1).Value)
                            grid_packet.RefreshEdit()
                            grid_packet.Rows(nowdatais).Cells(0).Value = False
                            'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
                            grid_packet.UpdateCellValue(0, nowdatais)
                            Exit Sub
                        End If
                    End If
                Next

                ' add servlist to grid
                Dim runno As Integer = 1
                If grid_showservlist.Rows.Count > 0 Then
                    runno = grid_showservlist.Rows.Count
                End If
                For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
                    Dim rowinsert As String() = New String() {False, runno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
                    grid_showservlist.Rows.Add(rowinsert)
                    If servlistrow(5) = "do" Then
                        pricedo += Double.Parse(servlistrow(3))
                    End If
                    pricenornal += Double.Parse(servlistrow(3))
                    runno += 1
                Next
                If grid_packet.Rows(nowdatais).Cells(2).Value = "ส่วนลด" Then
                    Dim paymoney As Double = 0
                    pricenow += Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
                    'If grid_chooseprom.Rows(nowdatais).Cells(5).Value <> "F" Then
                    '    paymoney = Double.Parse(price_all.Text)
                    'End If
                    'priceprom += Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value) '(pricenornal) '- Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value))
                ElseIf grid_packet.Rows(nowdatais).Cells(2).Value = "แถม-ฟรี" Then
                    'ตรงแถมฟรี ยังไงก็ต้อง เช็คว่า คนนี้มาใช้บริการแล้วกี่ครั้งถ้ายังใช่บริการไม่ครบก็ไม่สามารถใช่สิทธิ์ แถมฟรีได้
                    'priceprom += (pricenornal - pricedo)
                    pricenow += pricedo
                ElseIf grid_packet.Rows(nowdatais).Cells(2).Value = "แพ็คเกจ" Then
                    ' ตรงแพ็คเกจ ก็ต้อง เช็คว่า คนนี้มาใช้บริการครบจำครั้งที่ต้องทำ กับ จำนวนที่แถม แล้วหรือยัง ถ้าครบแล้วก็ต้องจ่ายตังเพิ่ม แต่ถ้ายังก็
                    ' ทำได้เลย โดยการ ลดราคาสิ่งที่ทำ
                    'priceprom += (pricenornal)
                    If grid_packet.Rows(nowdatais).Cells(5).Value = "F" Then
                        pricepacket += Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
                        pricenow += Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
                    End If
                End If
            ElseIf nowaction = "del" Then
                ' add servlist to grid
                Dim rowdelindex = 0
                Dim gridcount As Integer = grid_showservlist.Rows.Count - 1
                While (gridcount >= 0)
                    For Each delrow As DataRow In promservnew.Rows
                        If grid_showservlist.Rows(gridcount).Cells(2).Value = delrow(1) And grid_showservlist.Rows(gridcount).Cells(3).Value = delrow(2) Then
                            grid_showservlist.Rows(gridcount).Cells(0).Value = True
                        End If
                    Next
                    gridcount -= 1
                End While

                Dim totalserv = grid_showservlist.Rows.Count - 1
                While (totalserv >= 0)
                    If grid_showservlist.Rows(totalserv).Cells(0).Value = True Then
                        grid_showservlist.Rows.RemoveAt(totalserv)
                    End If
                    totalserv -= 1
                End While


                Dim pricedelnormal As Double = 0.0
                For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
                    'Dim rowinsert As String() = New String() {False, runno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
                    'grid_showservlist.Rows.Add(rowinsert)
                    If servlistrow(5) = "do" Then
                        pricedo += Double.Parse(servlistrow(3))
                    End If
                    pricenornal -= Double.Parse(servlistrow(3))
                    pricedelnormal += Double.Parse(servlistrow(3))
                Next
                If grid_packet.Rows(nowdatais).Cells(2).Value = "ส่วนลด" Then
                    'MsgBox("A" & priceprom & " : " & pricenornal)
                    pricenow -= Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
                    'priceprom -= (pricedelnormal - Double.Parse(grid_chooseprom.Rows(nowdatais).Cells(3).Value))
                    'MsgBox("B" & priceprom & " : " & pricenornal)
                ElseIf grid_packet.Rows(nowdatais).Cells(2).Value = "แถม-ฟรี" Then
                    'ตรงแถมฟรี ยังไงก็ต้อง เช็คว่า คนนี้มาใช้บริการแล้วกี่ครั้งถ้ายังใช่บริการไม่ครบก็ไม่สามารถใช่สิทธิ์ แถมฟรีได้
                    'priceprom -= (pricedelnormal - pricedo)
                    pricenow -= pricedo
                ElseIf grid_packet.Rows(nowdatais).Cells(2).Value = "แพ็คเกจ" Then
                    ' ตรงแพ็คเกจ ก็ต้อง เช็คว่า คนนี้มาใช้บริการครบจำครั้งที่ต้องทำ กับ จำนวนที่แถม แล้วหรือยัง ถ้าครบแล้วก็ต้องจ่ายตังเพิ่ม แต่ถ้ายังก็
                    ' ทำได้เลย โดยการ ลดราคาสิ่งที่ทำ
                    'priceprom -= (pricedelnormal)
                    If grid_packet.Rows(nowdatais).Cells(5).Value = "F" Then
                        pricepacket -= Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
                        pricenow -= Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
                    End If
                End If
            End If

            'pricenow = (pricenornal - priceprom + pricepacket)
            price_normal.Text = pricenornal.ToString("#,##0.00")
            'price_prom.Text = priceprom.ToString("#,##0.00")
            price_packet.Text = pricepacket.ToString("#,##0.00")
            price_all.Text = pricenow.ToString("#,##0.00")
            grid_packet.Rows(e.RowIndex).Selected = False
        End If
        clickinchoosepromotion = False

        'Dim nowdatais As Integer = 0
        'If grid_packet.CurrentCell.ColumnIndex.Equals(0) Then
        '    Dim nowaction As String = "add"
        '    Dim pricenornal As Double = Double.Parse(price_normal.Text)
        '    Dim pricedo As Double = 0.0
        '    Dim priceprom As Double = 0.0
        '    Dim pricepacket As Double = Double.Parse(price_packet.Text)
        '    Dim pricenow As Double = Double.Parse(price_all.Text)
        '    nowdatais = e.RowIndex
        '    Dim promservnew As DataTable = get_Promlistall(grid_packet.Rows(nowdatais).Cells(6).Value) ' โปรโมชั่นที่เลือก

        '    If grid_packet.Rows(nowdatais).Cells(5).Value = "F" And grid_packet.Rows(nowdatais).Cells(2).Value = "แพ็คเกจ" And grid_packet.Rows(nowdatais).Cells(0).Value = False Then
        '        Dim flagdup As Boolean = False
        '        Dim promname As String = ""
        '        For Each promadd As DataRow In promservnew.Rows
        '            For Each prominlist As DataGridViewRow In grid_showservlist.Rows
        '                If promadd(1) = prominlist.Cells(2).Value And promadd(2) = prominlist.Cells(3).Value Then
        '                    flagdup = True
        '                    promname = promadd(1)
        '                    Exit For
        '                End If
        '            Next
        '        Next

        '        If flagdup = True Then
        '            MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_packet.Rows(nowdatais).Cells(1).Value & " นี้ได้ เนื่องจาก รายการบริการซ้ำกับ โปรโมชั่นอื่น")
        '            grid_packet.Rows(nowdatais).Cells(0).Value = False
        '            'Dim checkCell As DataGridViewCheckBoxCell = grid_packet.Rows(nowdatais).Cells(0)
        '            grid_packet.UpdateCellValue(0, nowdatais)
        '            Exit Sub
        '            'Else
        '            '    answer = MessageBox.Show("คุณต้องการสมัคร แพ็คเกจนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '            '    If answer = vbNo Then
        '            '        grid_packet.RefreshEdit()
        '            '        grid_packet.Rows(nowdatais).Cells(0).Value = False
        '            '        'Dim checkCell As DataGridViewCheckBoxCell = grid_packet.Rows(nowdatais).Cells(0)
        '            '        grid_packet.UpdateCellValue(0, nowdatais)
        '            '        Exit Sub
        '            '    End If
        '        End If

        '    End If

        '    ' check dup with packet 

        '    For Each rowprom As DataGridViewRow In grid_packet.Rows
        '        If rowprom.Cells(0).Value = True Then
        '            Dim flagdup As Boolean = False
        '            Dim promname As String = ""
        '            Dim prompacket As DataTable = get_Promlistall(rowprom.Cells(6).Value)
        '            For Each promadd As DataRow In promservnew.Rows
        '                For Each prompacket2 As DataRow In prompacket.Rows
        '                    If promadd(1) = prompacket2(1) And promadd(2) = prompacket2(2) Then
        '                        flagdup = True
        '                        promname = promadd(1)
        '                        Exit For
        '                    End If
        '                Next
        '            Next
        '            If flagdup = True Then
        '                MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_packet.Rows(nowdatais).Cells(1).Value & " นี้ได้ เนื่องจาก รายการบริการซ้ำกับ โปรโมชั่นอื่น")
        '                grid_packet.Rows(nowdatais).Cells(0).Value = False
        '                'Dim checkCell As DataGridViewCheckBoxCell = grid_chooseprom.Rows(nowdatais).Cells(0)
        '                grid_packet.UpdateCellValue(0, nowdatais)
        '                Exit Sub
        '            Else
        '            End If
        '        End If
        '    Next
        '    If grid_packet.CurrentCell.Value = True Then
        '        'grid_packet.CurrentCell.Value = False
        '        nowaction = "del"
        '    Else
        '        'grid_packet.CurrentCell.Value = True
        '        nowaction = "add"
        '    End If

        '    Dim answer As DialogResult
        '    answer = MessageBox.Show("คุณต้องการสมัคร โปรโมชั่นนี้ใช่หรือไม่", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If answer = vbNo Then
        '        grid_packet.RefreshEdit()
        '        grid_packet.Rows(nowdatais).Cells(0).Value = False
        '        'Dim checkCell As DataGridViewCheckBoxCell = grid_packet.Rows(nowdatais).Cells(0)
        '        grid_packet.UpdateCellValue(0, nowdatais)
        '        Exit Sub
        '    Else
        '        clickinchoosepromotion = True
        '    End If

        '    ' check dup promotion if promotion for register
        '    'Dim duplicateProm As ArrayList = New ArrayList()
        '    'form_chooseduppromotion.cbo_dupprom.Items.Clear()
        '    If nowaction = "add" Then
        '        If grid_packet.Rows(nowdatais).Cells(7).Value = "Y" Then ' Check โปรโมชั่น ที่เป็นโปรโมชั่นกับการสมัครสมาชิก
        '            Dim countpromfor_reg As Integer = 0
        '            For Each promlist As DataGridViewRow In grid_packet.Rows
        '                If promlist.Cells(0).Value = True And promlist.Cells(7).Value = "Y" And promlist.Cells(1).Value <> grid_packet.Rows(nowdatais).Cells(1).Value Then ' หาโปรโมชั่นที่เป็นโปรโมชั่นของการสมัครสมาชิกอันแรกที่เจอ
        '                    countpromfor_reg += 1
        '                End If
        '            Next
        '            If countpromfor_reg > 0 Then
        '                MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_packet.Rows(nowdatais).Cells(1).Value & "นี้ได้")
        '                grid_packet.RefreshEdit()
        '                grid_packet.Rows(nowdatais).Cells(0).Value = False
        '                'Dim checkCell As DataGridViewCheckBoxCell = grid_packet.Rows(nowdatais).Cells(0)
        '                grid_packet.UpdateCellValue(0, nowdatais)
        '                Exit Sub
        '            End If
        '        End If

        '        ' ตรวจสอบโปรโมชั่น ทั่วไป ในกรณีที่เลือกมาใหม่ ดูว่าสิ่งที่เลือกมาใหม่ ที่อยุ่แล้วกับโปรโมชั่นที่เลือกก่อนหน้าหรือเปล่า
        '        Dim countpromfor_regnormal As Integer = 0
        '        For Each promlist As DataGridViewRow In grid_packet.Rows
        '            If promlist.Cells(0).Value = True And promlist.Cells(6).Value <> grid_packet.Rows(nowdatais).Cells(6).Value Then
        '                Dim promservlistall As DataTable = get_Promlistall(promlist.Cells(6).Value)
        '                Dim count As Integer = promservlistall.Rows.Count
        '                Dim flag As Boolean = False
        '                For Each rowserv As DataRow In promservlistall.Rows
        '                    For Each rowservnow As DataRow In promservnew.Rows
        '                        If rowserv(1) = rowservnow(1) And rowserv(2) = rowservnow(2) Then
        '                            flag = True
        '                            Exit For
        '                        End If
        '                    Next
        '                Next
        '                If flag = True Then
        '                    MsgBox("ไม่สามารถใช้ โปรโมชั่น " & grid_packet.Rows(nowdatais).Cells(1).Value & " นี้ได้ เนื่องจาก รายการบริการซ้ำกับ โปรโมชั่น " & promlist.Cells(1).Value)
        '                    grid_packet.RefreshEdit()
        '                    grid_packet.Rows(nowdatais).Cells(0).Value = False
        '                    'Dim checkCell As DataGridViewCheckBoxCell = grid_packet.Rows(nowdatais).Cells(0)
        '                    grid_packet.UpdateCellValue(0, nowdatais)
        '                    Exit Sub
        '                End If
        '            End If
        '        Next

        '        ' add servlist to grid
        '        Dim runno As Integer = 1
        '        If grid_showservlist.Rows.Count > 0 Then
        '            runno = grid_showservlist.Rows.Count
        '        End If
        '        For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
        '            Dim rowinsert As String() = New String() {False, runno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
        '            grid_showservlist.Rows.Add(rowinsert)
        '            If servlistrow(5) = "do" Then
        '                pricedo += Double.Parse(servlistrow(3))
        '            End If
        '            pricenornal += Double.Parse(servlistrow(3))
        '            runno += 1
        '        Next
        '        If grid_packet.Rows(nowdatais).Cells(2).Value = "ส่วนลด" Then
        '            Dim paymoney As Double = 0
        '            pricenow += Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
        '            'If grid_packet.Rows(nowdatais).Cells(5).Value <> "F" Then
        '            '    paymoney = Double.Parse(price_all.Text)
        '            'End If
        '            'priceprom += Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value) '(pricenornal) '- Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value))
        '        ElseIf grid_packet.Rows(nowdatais).Cells(2).Value = "แถม-ฟรี" Then
        '            'ตรงแถมฟรี ยังไงก็ต้อง เช็คว่า คนนี้มาใช้บริการแล้วกี่ครั้งถ้ายังใช่บริการไม่ครบก็ไม่สามารถใช่สิทธิ์ แถมฟรีได้
        '            'priceprom += (pricenornal - pricedo)
        '            pricenow += pricedo
        '        ElseIf grid_packet.Rows(nowdatais).Cells(2).Value = "แพ็คเกจ" Then
        '            ' ตรงแพ็คเกจ ก็ต้อง เช็คว่า คนนี้มาใช้บริการครบจำครั้งที่ต้องทำ กับ จำนวนที่แถม แล้วหรือยัง ถ้าครบแล้วก็ต้องจ่ายตังเพิ่ม แต่ถ้ายังก็
        '            ' ทำได้เลย โดยการ ลดราคาสิ่งที่ทำ
        '            'priceprom += (pricenornal)
        '            If grid_packet.Rows(nowdatais).Cells(5).Value = "F" Then
        '                pricepacket += Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
        '                pricenow += Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
        '            End If
        '        End If
        '    ElseIf nowaction = "del" Then
        '        ' add servlist to grid
        '        Dim rowdelindex = 0
        '        Dim gridcount As Integer = grid_showservlist.Rows.Count - 1
        '        While (gridcount >= 0)
        '            For Each delrow As DataRow In promservnew.Rows
        '                If grid_showservlist.Rows(gridcount).Cells(2).Value = delrow(1) And grid_showservlist.Rows(gridcount).Cells(3).Value = delrow(2) Then
        '                    grid_showservlist.Rows(gridcount).Cells(0).Value = True
        '                End If
        '            Next
        '            gridcount -= 1
        '        End While

        '        Dim totalserv = grid_showservlist.Rows.Count - 1
        '        While (totalserv >= 0)
        '            If grid_showservlist.Rows(totalserv).Cells(0).Value = True Then
        '                grid_showservlist.Rows.RemoveAt(totalserv)
        '            End If
        '            totalserv -= 1
        '        End While


        '        Dim pricedelnormal As Double = 0.0
        '        For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
        '            'Dim rowinsert As String() = New String() {False, runno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
        '            'grid_showservlist.Rows.Add(rowinsert)
        '            If servlistrow(5) = "do" Then
        '                pricedo += Double.Parse(servlistrow(3))
        '            End If
        '            pricenornal -= Double.Parse(servlistrow(3))
        '            pricedelnormal += Double.Parse(servlistrow(3))
        '        Next
        '        If grid_packet.Rows(nowdatais).Cells(2).Value = "ส่วนลด" Then
        '            'MsgBox("A" & priceprom & " : " & pricenornal)
        '            pricenow -= Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
        '            'priceprom -= (pricedelnormal - Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value))
        '            'MsgBox("B" & priceprom & " : " & pricenornal)
        '        ElseIf grid_packet.Rows(nowdatais).Cells(2).Value = "แถม-ฟรี" Then
        '            'ตรงแถมฟรี ยังไงก็ต้อง เช็คว่า คนนี้มาใช้บริการแล้วกี่ครั้งถ้ายังใช่บริการไม่ครบก็ไม่สามารถใช่สิทธิ์ แถมฟรีได้
        '            'priceprom -= (pricedelnormal - pricedo)
        '            pricenow -= pricedo
        '        ElseIf grid_packet.Rows(nowdatais).Cells(2).Value = "แพ็คเกจ" Then
        '            ' ตรงแพ็คเกจ ก็ต้อง เช็คว่า คนนี้มาใช้บริการครบจำครั้งที่ต้องทำ กับ จำนวนที่แถม แล้วหรือยัง ถ้าครบแล้วก็ต้องจ่ายตังเพิ่ม แต่ถ้ายังก็
        '            ' ทำได้เลย โดยการ ลดราคาสิ่งที่ทำ
        '            'priceprom -= (pricedelnormal)
        '            If grid_packet.Rows(nowdatais).Cells(5).Value = "F" Then
        '                pricepacket -= Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
        '                pricenow -= Double.Parse(grid_packet.Rows(nowdatais).Cells(3).Value)
        '            End If
        '        End If
        '    End If

        '    'pricenow = (pricenornal - priceprom + pricepacket)
        '    price_normal.Text = pricenornal.ToString("#,##0.00")
        '    'price_prom.Text = priceprom.ToString("#,##0.00")
        '    price_packet.Text = pricepacket.ToString("#,##0.00")
        '    price_all.Text = pricenow.ToString("#,##0.00")
        '    grid_packet.Rows(e.RowIndex).Selected = False
        'End If
        'clickinchoosepromotion = False
    End Sub
End Class