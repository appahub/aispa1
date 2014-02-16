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
        If choosecusfrom = "buy" Then
            form_service.txt_custypeid.Text = grid_showcustomer.Rows(rowindex).Cells(5).Value.ToString
            form_service.txt_cusid.Text = grid_showcustomer.Rows(rowindex).Cells(0).Value.ToString
            form_service.txt_cusname.Text = grid_showcustomer.Rows(rowindex).Cells(1).Value.ToString
        ElseIf choosecusfrom = "use" Then
            form_service.txt_custypeid_use.Text = grid_showcustomer.Rows(rowindex).Cells(5).Value.ToString
            form_service.txt_cusid_use.Text = grid_showcustomer.Rows(rowindex).Cells(0).Value.ToString
            form_service.txt_cusname_use.Text = grid_showcustomer.Rows(rowindex).Cells(1).Value.ToString
        End If
        

        Dim Sql As String = "exec getPromotion_notuse " &
            grid_showcustomer.Rows(rowindex).Cells(0).Value.ToString &
            "," & grid_showcustomer.Rows(rowindex).Cells(5).Value.ToString &
            ",'" & form_service.dtp_servdate.Value.ToString("yyyyMMdd") & "'"

        Dim promnotuse As DataTable = Obj_query.selectDatatoGrid(Sql)
        'Dim promnotuse2 As DataTable = Obj_query.selectDatatoGrid(Sql)

        Sql = "exec getPromotionUse " &
            grid_showcustomer.Rows(rowindex).Cells(0).Value.ToString &
            "," & grid_showcustomer.Rows(rowindex).Cells(5).Value.ToString &
            ",'" & form_service.dtp_servdate.Value.ToString("yyyyMMdd") & "'"

        Dim promuse As DataTable = Obj_query.selectDatatoGrid(Sql)
        ''Dim promuse2 As DataTable = Obj_query.selectDatatoGrid(Sql)

        For Each puse As DataRow In promuse.Rows
            Dim count As Integer = promnotuse.Rows.Count - 1
            While count >= 0
                If puse(0) = promnotuse.Rows(count)(0) Then
                    promnotuse.Rows.RemoveAt(count)
                End If
                count -= 1
            End While
        Next

        If choosecusfrom = "buy" Then
            GetDataToGrid_nonsql(promnotuse, form_service.grid_packet, "prom")
            GetDataToGrid_nonsql(promuse, form_service.grid_chooseprom, "promnotchoose")

            form_service.pal_showafterchoosecus.Visible = True
            form_service.grp_selectprom.Visible = True
        ElseIf choosecusfrom = "use" Then
            GetDataToGrid_nonsql(promuse, form_service.grid_promuse, "prom")
            form_service.grp_detailprom.Visible = True
        End If
        
        Me.Close()
    End Sub

    Private Sub GetDataToGrid_nonsql(ByVal mytbl As DataTable, ByVal mygrid As DataGridView, ByVal type As String)
        mygrid.Rows.Clear()
        For Each rows As DataRow In mytbl.Rows
            If type = "prom" Then
                'If Not (rows(4).ToString = "F" And rows(1).ToString = "แถม-ฟรี") Then
                Dim row As String() = New String() {False, rows(0), rows(1), rows(2), rows(3), rows(4), rows(5), rows(6), rows(7), rows(8), rows(9)}
                mygrid.Rows.Add(row)
                'End If
            ElseIf type = "promnotchoose" Then
                Dim row As String() = New String() {rows(0), rows(1), rows(2), rows(3), rows(4), rows(5), rows(6), rows(7), rows(8), rows(9)}
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
    Private Sub GetDataToGrid(ByVal mysql As String, ByVal mygrid As DataGridView, ByVal type As String)
        Dim dataTable As DataTable = Obj_query.selectDatatoGrid(mysql)
        If dataTable.Rows.Count < 0 Then
            dataTable.Rows.Add(New Object() {1, "ไม่มีข้อมูล"})
        End If
        mygrid.Rows.Clear()
        For Each rows As DataRow In dataTable.Rows
            If type = "prom" Then
                'If Not (rows(4).ToString = "F" And rows(1).ToString = "แถม-ฟรี") Then
                Dim row As String() = New String() {False, rows(0), rows(1), rows(2), rows(3), rows(4), rows(5), rows(6), rows(7), rows(8), rows(9)}
                mygrid.Rows.Add(row)
                'End If
            ElseIf type = "promnotchoose" Then
                Dim row As String() = New String() {rows(0), rows(1), rows(2), rows(3), rows(4), rows(5), rows(6), rows(7), rows(8), rows(9)}
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