Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_showservlist
    Dim Obj_query = New classquery()
    Private Sub form_showservlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim prodtype As Integer = productype
        Dim servlistid As String = form_service.cboservtype.SelectedValue
        Dim Sql As String = "select ROW_NUMBER() over (order by liserv_id) 'ลำดับ',liserv_name 'รายการบริการ' , b.liserv_type_name 'ประเภทรายการบริการ' " &
                " , convert(varchar,liserv_price,1) 'ราคา' , convert(varchar,liserv_id) " &
                " from service_list a(nolock) " &
                " join service_list_type b(nolock) on a.liserv_type_id = b.liserv_type_id " &
                " where a.liserv_type_id = " & servlistid & ""
        Dim DataTable As DataTable = Obj_query.selectDatatoGrid(Sql)
        If DataTable.Rows.Count < 0 Then
            DataTable.Rows.Add(New Object() {1, "ไม่มีข้อมูล"})
        End If
        With grid_showservlist
            .AutoGenerateColumns = True
            .DataSource = DataTable
        End With
        grid_showservlist.Columns(4).Visible = False
    End Sub
    Private Sub grid_showservlist_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showservlist.CellClick
        Dim rowindex As Integer = grid_showservlist.CurrentRow.Index
        Dim servname As String = grid_showservlist.Rows(rowindex).Cells(1).Value.ToString
        Dim servtype As String = grid_showservlist.Rows(rowindex).Cells(2).Value.ToString
        Dim servprice As String = grid_showservlist.Rows(rowindex).Cells(3).Value.ToString
        Dim servid As String = grid_showservlist.Rows(rowindex).Cells(4).Value.ToString
        Dim runno As Integer = 1
        
        Dim gridnow As DataGridView = form_service.grid_showservlist
        If gridnow.Rows.Count > 0 Then
            runno = Integer.Parse(gridnow.Rows(gridnow.Rows.Count - 1).Cells(1).Value.ToString())
            runno += 1
        End If
        If (servname <> "" And servid <> "") Then
            form_service.txt_servname.Text = servname
            'Dim row As String() = New String() {False, runno, servname, servtype, servprice, empname, servid, empid}
            Dim row As String() = New String() {False, runno, servname, servtype, servprice, servid}
            If gridnow.Rows.Count > 0 Then
                For i As Integer = 0 To gridnow.Rows.Count - 1
                    If gridnow.Rows(i).Cells(1).Value <> "" Then
                        If gridnow.Rows(i).Cells(2).Value.Equals(servname) And
                            gridnow.Rows(i).Cells(3).Value.Equals(servtype) And
                            gridnow.Rows(i).Cells(4).Value.Equals(servprice) Then
                            Exit Sub
                        End If
                    End If
                Next
            End If

            gridnow.Rows.Add(row)
            Dim price_all As Double = Double.Parse(form_service.price_all.Text)
            Dim new_price As Double = Double.Parse(servprice)
            Dim now_price_all As Double = price_all + new_price
            form_service.price_all.Text = now_price_all.ToString("#,##0.00")
            form_service.price_normal.Text = now_price_all.ToString("#,##0.00")
            'Dim price_discount As Double = Double.Parse(form_service.price_discount.Text)
            'Dim now_price_discount As Double = price_discount - 0 ' 0 คือ ค่าที่ต้องเอามาจาก promotion
            'form_service.price_discount.Text = now_price_discount.ToString("0,00.00")
            'Dim price_amount As Double = Double.Parse(form_service.price_amount.Text)
            'Dim new_price_amount As Double = now_price_all - now_price_discount
            'form_service.price_amount.Text = new_price_amount.ToString("0,00.00")
            Dim chk As New DataGridViewCheckBoxColumn()
            If (gridnow.Columns.Count = 5) Then
                gridnow.Columns.Add(chk)
                chk.Name = "ลบรายการ"
            End If

            If gridnow.Rows.Count > 0 Then
                For i As Integer = 1 To gridnow.Columns.Count - 1
                    If gridnow.Rows(0).Cells(i).Value <> Nothing Then
                        Dim mydl As Double
                        If Double.TryParse(gridnow.Rows(0).Cells(i).Value, mydl) Then
                            gridnow.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        End If
                    End If
                Next
            End If
            Me.Close()
        End If
    End Sub
End Class