﻿Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_showproduct2
    Dim Obj_query = New classquery()
    Private Sub form_showproduct2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim prodtype As Integer = productype
        Dim order_id As String = currentorderid
        If order_id = "" Then
            MsgBox("รหัสใบสั่งซื้อไม่ถูกต้อง")
            Me.Close()
            Exit Sub
        End If
        Dim Sql As String = "select a.prod_id 'รหัส',a.prod_name 'ชื่อผลิตภัณฑ์',a.prod_brand 'ยี่ห้อ',convert(varchar,a.prod_price,1) 'ราคาสินค้า',a.prod_capacity 'ปริมาตร',b.unit_name 'หน่วยนับสินค้า',c.unit_name 'หน่วยนับปริมาตร',d.prod_type_name 'ประเภทสินค้า',g.order_id,e.deorder_qty " &
            " from product a(nolock) join unit b(nolock) on a.unit_id = b.unit_id " &
            " join unit c on a.unit_id_cap = c.unit_id join product_type d on a.prod_type_id = d.prod_type_id " &
            " join product_order_detail e(nolock) on e.prod_id = a.prod_id " &
            " join product_order g(nolock) on e.order_id=g.order_id " &
            " where g.order_id = " & order_id & "  order by a.prod_id"
        Dim DataTable As DataTable = Obj_query.selectDatatoGrid(Sql)
        If DataTable.Rows.Count < 0 Then
            DataTable.Rows.Add(New Object() {1, "ไม่มีข้อมูล"})
        End If
        With grid_showproduct2
            .AutoGenerateColumns = True
            .DataSource = DataTable
        End With
        grid_showproduct2.Columns(8).Visible = False
    End Sub

    Private Sub grid_showproduct2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showproduct2.CellClick
        Dim rowindex As Integer = grid_showproduct2.CurrentRow.Index
        Dim prodid As String = grid_showproduct2.Rows(rowindex).Cells(0).Value.ToString
        Dim prodname As String = grid_showproduct2.Rows(rowindex).Cells(1).Value.ToString
        Dim brand As String = grid_showproduct2.Rows(rowindex).Cells(2).Value.ToString
        Dim price As String = grid_showproduct2.Rows(rowindex).Cells(3).Value.ToString
        Dim capa As String = grid_showproduct2.Rows(rowindex).Cells(4).Value.ToString
        Dim unit As String = grid_showproduct2.Rows(rowindex).Cells(5).Value.ToString
        Dim unitcap As String = grid_showproduct2.Rows(rowindex).Cells(6).Value.ToString
        Dim prodtype As String = grid_showproduct2.Rows(rowindex).Cells(7).Value.ToString
        Dim prod_qty_order As String = grid_showproduct2.Rows(rowindex).Cells(9).Value.ToString
        currentorderid = grid_showproduct2.Rows(rowindex).Cells(8).Value.ToString
        Dim sql = "select dereceive_qty,dereceive_price from product_receive a(nolock) " &
        " join product_receive_detail b(nolock) on a.receive_id = b.receive_id " &
        " where order_id = " & currentorderid & " and prod_id = " & prodid
        Dim receivedata As DataTable = Obj_query.selectDatatoGrid(sql)
        Dim receive_qty As Integer = 0
        Dim receive_price As Double = 0.0
        If receivedata.Rows.Count > 0 Then
            receive_qty = Integer.Parse(receivedata.Rows(0)(0).ToString())
            receive_price = Double.Parse(receivedata.Rows(0)(1).ToString())
        End If
        Dim runno As Integer = 1
        If currentgrid.Rows.Count > 0 Then
            runno = Integer.Parse(currentgrid.Rows(currentgrid.Rows.Count - 1).Cells(1).Value.ToString())
            runno += 1
        End If
        If (prodname <> "" And prodid <> "") Then
            currentprodname.Text = prodname
            Dim row As String() = New String() {False, runno, prodname, "0", prod_qty_order, (prod_qty_order - 0), unit, price, Double.Parse(price * 1).ToString("0.00"), brand, capa, prodid, "", unitcap, prodtype}
            If currentgrid.Rows.Count > 0 Then
                For i As Integer = 0 To currentgrid.Rows.Count - 1
                    If currentgrid.Rows(i).Cells(0).Value <> "" Then
                        If currentgrid.Rows(i).Cells(2).Value.Equals(prodname) And
                            currentgrid.Rows(i).Cells(6).Value.Equals(unit) And
                            currentgrid.Rows(i).Cells(9).Value.Equals(brand) And
                            currentgrid.Rows(i).Cells(10).Value.Equals(capa) And
                            currentgrid.Rows(i).Cells(13).Value.Equals(unitcap) And
                            currentgrid.Rows(i).Cells(14).Value.Equals(prodtype) Then
                            Exit Sub
                        End If
                    End If
                Next
            End If

            currentgrid.Rows.Add(row)
            'Dim chk As New DataGridViewCheckBoxColumn()
            'If (currentgrid.Columns.Count = 10) Then
            '    currentgrid.Columns.Add(chk)
            '    chk.Name = "ลบรายการ"
            'End If

            If currentgrid.Rows.Count > 0 Then
                For i As Integer = 1 To currentgrid.Columns.Count - 1
                    If currentgrid.Rows(0).Cells(i).Value <> Nothing Then
                        Dim mydl As Double
                        If Double.TryParse(currentgrid.Rows(0).Cells(i).Value, mydl) Then
                            currentgrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        End If
                    End If
                Next
            End If
            Me.Close()
        End If
    End Sub
End Class