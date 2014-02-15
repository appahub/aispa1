Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_service
    Dim Obj_query As New classquery()
    Dim sql As String
    Dim datatable As New DataTable
    Dim selectedIndex As Integer
    Dim isedit As Boolean = False
    Dim clickinchoosepromotion As Boolean = False
    Dim frombuy As Boolean = False
    Dim globalservlist As ArrayList = New ArrayList()
#Region "totalcontrol"
    Private Sub UpdateDatainGrid(ByVal index As Integer)
        
        Dim sqlqueryeachtab(3) As String
        sqlqueryeachtab(0) = "select ROW_NUMBER() over (order by serv_id desc)'ลำดับ',serv_date 'วันที่บริการ'," &
        " b.cus_fullname 'สมาชิกมาใช้บริการ' , c.emp_fullname 'พนักงานทำรายการ' , serv_comment 'หมายเหตุ' " &
        " ,case when serv_sts = 'S' then 'เสร็จสมบูรณ์' when serv_sts = 'C' then 'ยกเลิกรายการ' when serv_sts = 'S' then 'เสร็จสมบูรณ์' when serv_sts = 'W' then 'รอใช้บริการ' end 'สถานะการบริการ',serv_id 'รหัสการบริการ',b.cus_id,b.custype_id" &
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
        If TabControl1.SelectedIndex = 0 Then
            frombuy = False
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
            grid_usedtobuy.Rows.Clear()
            panel_afterbuy.Visible = False
            pal_showafterchoosecus.Visible = False
            UpdateDatainGrid(0)
        ElseIf TabControl1.SelectedIndex = 1 Then
            pal_promuse.Visible = False
            grid_promuse.Rows.Clear()
            grid_servchoice.Rows.Clear()
            grid_servuse.Rows.Clear()
            grid_detailprom.Rows.Clear()
            grid_promuse.Rows.Clear()
            btn_addservuse.Visible = True
            btn_delservuse.Visible = False
            pal_showafter.Visible = False
            pal_promuse.Visible = True
            grid_servchoice.Visible = True
            Label14.Visible = True
            txt_cusname_use.Text = ""
            txt_cusid_use.Text = ""
            txt_custypeid_use.Text = ""
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
        choosecusfrom = "buy"
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
        Dim servid As String = ""

        If cus_id <> "" And servdatefindprom <> "" And grid_showservlist.Rows.Count > 0 Then ' service_type.Count > 0 And เอาไว้เช็คว่าเลือกพนักงานหรือยัง
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


            sql = "insert into service (serv_date,serv_comment,cus_id,emp_id,serv_sts) values ('" & servdatefindprom & "' , '" & comment & "'," & cus_id & "," & emp_id & ",'W')" ' S = Success
            If Obj_query.DMLData(sql) Then
                servid = Obj_query.selectdataInt("select IDENT_CURRENT('service')").ToString()

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
                Dim pricenormal As Double = Double.Parse(price_normal.Text)
                Dim pricepacket As Double = Double.Parse(price_packet.Text)
                Dim priceall As Double = Double.Parse(price_all.Text)

                If Obj_query.DMLData(sql) Then
                    sql = " insert into bill (serv_id,bill_date,bill_price_normal,bill_price_packet,bill_price_total) " &
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
                                LoadDataTO_page2()
                                clearData()
                                frombuy = True
                                TabControl1.SelectedIndex = 1
                                txt_servid_use.Text = servid.ToString()
                            End If
                        Else
                            MsgBox("เพิ่มรายการบริการเรียบร้อยแล้ว")
                            LoadDataTO_page2()
                            clearData()
                            frombuy = True
                            TabControl1.SelectedIndex = 1
                            txt_servid_use.Text = servid.ToString()
                        End If
                    End If
                End If
            End If
        Else
            MsgBox("กรุณาระบุข้อมูลให้ถูกต้อง หรือ ยังไม่ได้กำหนดพนักงานที่ให้บริการ")
        End If
    End Sub
    Private Sub LoadDataTO_page2()
        txt_cusid_use.Text = txt_cusid.Text
        txt_custypeid_use.Text = txt_custypeid.Text
        txt_cusname_use.Text = txt_cusname.Text
        btn_choosecus_use.Visible = False
        Dim index As Integer = 1
        For Each r As DataGridViewRow In globalservlist
            Dim rows As String() = {False, index, r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value, r.Cells(5).Value, r.Cells(6).Value, r.Cells(7).Value}
            grid_servchoice.Rows.Add(rows)
            index += 1
        Next
    End Sub
    Private Sub grid_servresult_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_servresult.CellClick
        clickinchoosepromotion = True
        pal_showafterchoosecus.Visible = False

        Dim row As Integer = grid_servresult.CurrentRow.Index
        isedit = True
        'clearData()
        btn_delserv.Visible = True
        grid_showservlist.Rows.Clear()
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

        Dim Promsql As String = "exec getPromotionBuy " &
            grid_servresult.Rows(row).Cells(7).Value.ToString &
            "," & grid_servresult.Rows(row).Cells(8).Value.ToString &
            ",'" & dtp_servdate.Value.ToString("yyyyMMdd") & "'" &
            ", " & grid_servresult.Rows(row).Cells(6).Value.ToString

        GetDataToGridPromotion(Promsql, grid_usedtobuy, "promnotchoose")

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
        panel_afterbuy.Visible = True
        btn_addserv.Visible = False
        btn_delserv.Visible = True
        'pal_showafterchoosecus.Visible = True
        grp_selectprom.Visible = True
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
            globalservlist = serv_dontabout_prom
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
                    Dim pname_arr As ArrayList = New ArrayList()
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
                            pname_arr.Add(promservlist(4))
                        End If
                    Next
                    If thispromlist_count = 0 Then
                        ' หาวิธีลบมาด้วยว่า ถ้าเกิดเพิ่มโปรโมชั่นนี้ไม่ได้ จะลบ ออกจาก ดาต้ากริดแต่ ตอนนี้ลบและเหมือนมันติด เออเร่อ
                        MsgBox("คุณสามารถใช้โปรโมชั่น " & pname & " ได้เลยในหน้าจอการใช้บริการ ")
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

    Private Sub btn_searchserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_searchserv.Click
        Dim index As Integer = cbo_searchserv.SelectedIndex
        Dim textsearch As String = txt_searchserv.Text
        Dim searchsql As String = ""
        If index = 0 Then ' total
            searchsql = "select ROW_NUMBER() over (order by serv_id desc)'ลำดับ',serv_date 'วันที่บริการ'," &
        " b.cus_fullname 'สมาชิกมาใช้บริการ' , c.emp_fullname 'พนักงานทำรายการ' , serv_comment 'หมายเหตุ' " &
        " ,case when serv_sts = 'S' then 'เสร็จสมบูรณ์' when serv_sts = 'C' then 'ยกเลิกรายการ' when serv_sts = 'W' then 'รอใช้บริการ' end 'สถานะการบริการ',serv_id 'รหัสการบริการ',b.cus_id,b.custype_id" &
        " from service a(nolock) " &
        " join customer b(nolock) on a.cus_id = b.cus_id" &
        " join employee c(nolock) on a.emp_id = c.emp_id" &
        " where serv_sts <> 'C'" &
        " order by serv_id desc"
        ElseIf index = 1 Then ' service date
            searchsql = "select ROW_NUMBER() over (order by serv_id desc)'ลำดับ',serv_date 'วันที่บริการ'," &
        " b.cus_fullname 'สมาชิกมาใช้บริการ' , c.emp_fullname 'พนักงานทำรายการ' , serv_comment 'หมายเหตุ' " &
        " ,case when serv_sts = 'S' then 'เสร็จสมบูรณ์' when serv_sts = 'C' then 'ยกเลิกรายการ' when serv_sts = 'W' then 'รอใช้บริการ' end 'สถานะการบริการ',serv_id 'รหัสการบริการ',b.cus_id,b.custype_id" &
        " from service a(nolock) " &
        " join customer b(nolock) on a.cus_id = b.cus_id" &
        " join employee c(nolock) on a.emp_id = c.emp_id" &
        " where serv_sts <> 'C' and convert(varchar(10),serv_date,103) = '" & textsearch & "'" &
        " order by serv_id desc"
        ElseIf index = 2 Then ' customer name
            searchsql = "select ROW_NUMBER() over (order by serv_id desc)'ลำดับ',serv_date 'วันที่บริการ'," &
        " b.cus_fullname 'สมาชิกมาใช้บริการ' , c.emp_fullname 'พนักงานทำรายการ' , serv_comment 'หมายเหตุ' " &
        " ,case when serv_sts = 'S' then 'เสร็จสมบูรณ์' when serv_sts = 'C' then 'ยกเลิกรายการ' when serv_sts = 'W' then 'รอใช้บริการ' end 'สถานะการบริการ',serv_id 'รหัสการบริการ',b.cus_id,b.custype_id" &
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
        " where serv_sts = 'W'" &
        " order by serv_id desc"
        ElseIf index = 4 Then
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
                    Dim rowinsert As String() = New String() {False, runno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4), grid_packet.Rows(nowdatais).Cells(1).Value, grid_packet.Rows(nowdatais).Cells(5).Value}
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
    End Sub

    Private Sub btn_chooseemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_chooseemp.Click
        Dim serv_dontabout_prom As ArrayList = New ArrayList

        For Each rowlist As DataGridViewRow In grid_servuse.Rows
            serv_dontabout_prom.Add(rowlist)
        Next
        If serv_dontabout_prom.Count < 0 Then
            MsgBox("กรุณาเลือกใช้บริการก่อน")
            Exit Sub
        End If
        Dim showforchooseemp As ArrayList = New ArrayList()
        For Each promserv As DataGridViewRow In grid_promuse.Rows
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
    Private Sub GetPromotion()
        Dim Promsql As String = "exec getPromotionUse " &
            txt_cusid_use.Text &
            "," & txt_custypeid_use.Text &
            ",'" & dtp_servuse.Value.ToString("yyyyMMdd") & "'"

        GetDataToGridPromotion(Promsql, grid_promuse, "prom")
    End Sub

    Private Sub grid_usedtobuy_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_usedtobuy.CellClick
        ' เอาข้อมูลโปรโมชั่นไปแสดงใน ดาต้ากริดแสดงรายการ โปรโมชั่นที่เลือก
        Dim nowdatais As Integer = e.RowIndex
        Dim promservnew As DataTable = get_Promlistall(grid_usedtobuy.Rows(nowdatais).Cells(5).Value) ' โปรโมชั่นที่เลือก
        grp_selectprom.Text = "รายการบริการของ โปรโมชั่น " & grid_usedtobuy.Rows(nowdatais).Cells(0).Value
        grid_selectprom.Rows.Clear()
        Dim promrunno As Integer = 1
        For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
            Dim rowinsert As String() = New String() {False, promrunno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
            grid_selectprom.Rows.Add(rowinsert)
            promrunno += 1
        Next
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            If frombuy = True Then
                txt_servid_use.Visible = True
                txt_cusname_use.Enabled = False
                GetPromotion()
            End If
        End If
        GetUseservtoGrid()
    End Sub

    Private Sub GetUseservtoGrid()
        sql = "select ROW_NUMBER() over (order by use_id desc)'ลำดับ', use_date 'วันที่บริการ'" &
        " , b.cus_fullname 'สมาชิกมาใช้บริการ' , c.emp_fullname 'พนักงานทำรายการ'  " &
        " , case when a.use_sts = 'S' then 'เสร็จสมบูรณ์' when a.use_sts = 'C' then 'ยกเลิกรายการ' when a.use_sts = 'S' then 'เสร็จสมบูรณ์' end 'สถานะการบริการ'" &
        " , isnull(serv_id,'') 'รหัสการบริการ',use_id,b.cus_id,b.custype_id " &
        " from use_service a(nolock)  " &
        " join customer b(nolock) on a.cus_id = b.cus_id " &
        " join employee c(nolock) on a.emp_id = c.emp_id " &
        " where a.use_sts <> 'C' " &
        " order by use_id  desc "
        GetDataToGrid(sql, grid_resultuse)
        grid_resultuse.Columns(5).Visible = False
    End Sub

    Private Sub grid_servchoice_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_servchoice.CellContentClick
        If grid_servchoice.CurrentCell.ColumnIndex.Equals(0) Then
            If grid_servchoice.CurrentCell.Value = False Then
                grid_servchoice.CurrentCell.Value = True
                grid_servchoice.UpdateCellValue(0, e.RowIndex)
                Dim index As Integer = 1
                If grid_servuse.Rows.Count > 0 Then
                    index = grid_servuse.Rows.Count
                    index += 1
                End If
                Dim row As String() = {False, index, grid_servchoice.Rows(e.RowIndex).Cells(2).Value, grid_servchoice.Rows(e.RowIndex).Cells(3).Value, grid_servchoice.Rows(e.RowIndex).Cells(4).Value, grid_servchoice.Rows(e.RowIndex).Cells(5).Value, grid_servchoice.Rows(e.RowIndex).Cells(6).Value, grid_servchoice.Rows(e.RowIndex).Cells(7).Value}
                grid_servuse.Rows.Add(row)
            ElseIf grid_servchoice.CurrentCell.Value = True Then
                grid_servchoice.CurrentCell.Value = False
                grid_servchoice.UpdateCellValue(0, e.RowIndex)
                Dim delid As String = grid_servchoice.Rows(e.RowIndex).Cells(5).Value
                Dim count As Integer = grid_servuse.Rows.Count - 1
                While count >= 0
                    If grid_servuse.Rows(count).Cells(5).Value = delid Then
                        grid_servuse.Rows.RemoveAt(count)
                    End If
                    count -= 1
                End While
            End If
        End If
    End Sub

    Private Sub grid_promuse_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_promuse.CellClick
        If e.ColumnIndex <> 0 Then
            Dim nowdatais As Integer = e.RowIndex
            Dim promservnew As DataTable = get_Promlistall(grid_promuse.Rows(nowdatais).Cells(6).Value) ' โปรโมชั่นที่เลือก
            grp_detailprom.Text = "รายการบริการของ โปรโมชั่น " & grid_promuse.Rows(nowdatais).Cells(1).Value
            grid_detailprom.Rows.Clear()
            Dim promrunno As Integer = 1
            For Each servlistrow As DataRow In promservnew.Rows ' รายการโปรโมชั่นที่ได้จากการ เลือกโปรโมชั่น
                Dim rowinsert As String() = New String() {False, promrunno, servlistrow(1), servlistrow(2), servlistrow(3), servlistrow(4)}
                grid_detailprom.Rows.Add(rowinsert)
                promrunno += 1
            Next
        End If
    End Sub

    Private Sub grid_promuse_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_promuse.CellContentClick
        If grid_promuse.CurrentCell.ColumnIndex.Equals(0) Then

            If grid_promuse.CurrentCell.Value = False Then
                grid_promuse.CurrentCell.Value = True
                grid_promuse.UpdateCellValue(0, e.RowIndex)

                ' add promservlist
                Dim promrunno As Integer = 1
                If grid_servchoice.Rows.Count > 0 Then
                    promrunno = grid_servchoice.Rows.Count
                End If
                Dim promservnew As DataTable = get_Promlistall(grid_promuse.Rows(e.RowIndex).Cells(6).Value)
                For Each servnew As DataRow In promservnew.Rows
                    Dim row As String() = {False, promrunno, servnew(1), servnew(2), servnew(3), servnew(4), grid_promuse.Rows(e.RowIndex).Cells(1).Value, grid_promuse.Rows(e.RowIndex).Cells(6).Value}
                    grid_servchoice.Rows.Add(row)
                    promrunno += 1
                Next
            ElseIf grid_promuse.CurrentCell.Value = True Then
                grid_promuse.CurrentCell.Value = False
                grid_promuse.UpdateCellValue(0, e.RowIndex)

                Dim promservnew As DataTable = get_Promlistall(grid_promuse.Rows(e.RowIndex).Cells(6).Value)
                For Each servnew As DataRow In promservnew.Rows
                    Dim count As Integer = grid_servchoice.Rows.Count - 1
                    While count >= 0
                        If grid_servchoice.Rows(count).Cells(2).Value = servnew(1) And grid_servuse.Rows(count).Cells(3).Value = servnew(2) Then
                            grid_servchoice.Rows.RemoveAt(count)
                        End If
                        count -= 1
                    End While
                Next
            End If
        End If
    End Sub

    Private Sub btn_addservuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addservuse.Click
        If txt_cusid_use.Text <> "" And txt_custypeid_use.Text <> "" And txt_cusname_use.Text <> "" And grid_servuse.Rows.Count > 0 And service_type.Count > 0 Then

            Dim cusid As Integer = txt_cusid_use.Text
            Dim custypeid As Integer = txt_custypeid_use.Text
            Dim usedate As String = dtp_servuse.Value.ToString("yyyyMMdd")
            Dim servid As String = txt_servid_use.Text

            If servid = "" Then ' กรณี มาใช้บริการโปรโมชั่นเลย 
                sql = "insert into use_service (cus_id, use_date, use_sts, emp_id) values " &
                        " (" & cusid & ", '" & usedate & "','S', " & module_emp_id & ") "
            ElseIf servid <> "" Then ' กรณีที่ มีการใช้งานหลังจากซื้อบริการ
                sql = "insert into use_service (cus_id, serv_id, use_date, use_sts, emp_id) values " &
                        " (" & cusid & ", " & servid & ", '" & usedate & "','S', " & module_emp_id & ") "
            End If

            'service_name.Add(servname)
            'service_type.Add(typeinsert)
            'service_id.Add(id)
            'service_empid.Add(empid)

            If Obj_query.DMLData(sql) Then
                Dim servforinsert As ArrayList = New ArrayList()
                Dim useid As Integer = Obj_query.selectdataInt("select IDENT_CURRENT('use_service')").ToString()
                For Each r As DataGridViewRow In grid_servuse.Rows
                    For i As Integer = 0 To service_type.Count - 1
                        Dim strforinsert As String = ""
                        If r.Cells(7).Value = service_id(i) Then
                            strforinsert = useid & "|" & r.Cells(7).Value & "|" & r.Cells(5).Value & "|" & service_empid(i)
                            servforinsert.Add(strforinsert)
                        End If
                    Next
                Next

                Dim sqldetail As String = ""
                For Each row As String In servforinsert
                    Dim data As String() = row.Split("|")
                    sqldetail &= "insert into use_service_detail (use_id, prom_id, liserv_id, emp_id) " &
                        " values (" & data(0) & ", " & data(1) & ", " & data(2) & ", " & data(3) & ")"
                Next

                If Obj_query.DMLData(sqldetail) Then
                    If txt_servid_use.Text <> "" Then
                        sql = "update service set serv_sts = 'S' where serv_id = " & txt_servid_use.Text
                        Obj_query.DMLData(sql)
                    End If

                    MsgBox("เพิ่มข้อมูลการใช้เรียบร้อยแล้ว")
                    clearData()
                End If
            End If
        Else
            MsgBox("กรุณาระบุข้อมูลให้ถูกต้อง หรือ ยังไม่ได้กำหนดพนักงานที่ให้บริการ")
        End If
    End Sub

    Private Sub btn_choosecus_use_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_choosecus_use.Click
        choosecusfrom = "use"
        form_showcustomer.Show()
    End Sub

    Private Sub btn_delservuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delservuse.Click
        sql = "update use_service set use_sts = 'C' where use_id = " & txt_useid.Text
        If Obj_query.DMLData(sql) Then
            MsgBox("ยกเลิกรายการบริการนี้เรียบร้อยแล้ว")
        End If
        GetUseservtoGrid()
        clearData()
    End Sub

    Private Sub grid_resultuse_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_resultuse.CellClick
        Dim index As Integer = e.RowIndex
        Dim useid As String = grid_resultuse.Rows(index).Cells(6).Value
        Dim servid As String = grid_resultuse.Rows(index).Cells(5).Value
        Dim cusname As String = grid_resultuse.Rows(index).Cells(2).Value
        Dim cusid As String = grid_resultuse.Rows(index).Cells(7).Value
        Dim custypeid As String = grid_resultuse.Rows(index).Cells(8).Value
        Dim dateuse As String = grid_resultuse.Rows(index).Cells(1).Value
        dtp_servuse.Value = grid_resultuse.Rows(index).Cells(1).Value
        txt_cusid_use.Text = cusid
        txt_custypeid_use.Text = custypeid
        txt_cusname_use.Text = cusname
        txt_servid_use.Text = servid
        txt_useid.Text = useid
        btn_addservuse.Visible = False
        btn_delservuse.Visible = True
        pal_showafter.Visible = True
        pal_promuse.Visible = False
        grid_servchoice.Visible = False
        Label14.Visible = False
        Dim Promsql As String = "exec getPromotionUse_Success " &
            cusid &
            "," & custypeid &
            ",'" & dtp_servuse.Value.ToString("yyyyMMdd") & "'" &
            ", " & useid

        GetDataToGridPromotion(Promsql, grid_showafter, "promnotchoose")

        Dim Sqlservlist As String = "select ROW_NUMBER() over (order by c.liserv_id) 'ลำดับ',c.liserv_name 'รายการบริการ' , d.liserv_type_name 'ประเภทรายการบริการ'  " &
         " , convert(varchar,c.liserv_price,1) 'ราคา' , convert(varchar,c.liserv_id) " &
         " from use_service a(nolock) " &
         " join use_service_detail b(nolock) on a.use_id = b.use_id " &
         " join service_list c(nolock) on b.liserv_id = c.liserv_id " &
         " join service_list_type d(nolock) on c.liserv_type_id = d.liserv_type_id " &
         " where a.use_id = " & useid
        Dim detailservicelist As DataTable = Obj_query.selectDatatoGrid(Sqlservlist)

        grid_servuse.Rows.Clear()
        For i As Integer = 0 To detailservicelist.Rows.Count - 1
            Dim runno As Integer = detailservicelist(i)(0).ToString()
            Dim servname As String = detailservicelist(i)(1).ToString()
            Dim servtype As String = detailservicelist(i)(2).ToString()
            Dim servprice As String = detailservicelist(i)(3).ToString()
            Dim servid1 As String = detailservicelist(i)(4).ToString()
            Dim rowliserv As String() = New String() {False, runno, servname, servtype, servprice, servid1}
            grid_servuse.Rows.Add(rowliserv)
        Next
    End Sub

    Private Sub grid_resultuse_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_resultuse.CellContentClick

    End Sub

    Private Sub grid_servresult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_servresult.CellContentClick

    End Sub

    Private Sub btn_clearservuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clearservuse.Click
        clearData()
    End Sub
End Class