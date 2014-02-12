Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_showproduct
    Dim Obj_query = New classquery()
    Private Sub form_showproduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim prodtype As Integer = productype
        Dim Sql As String = "select prod_id 'รหัส',prod_name 'ชื่อผลิตภัณฑ์',prod_brand 'ยี่ห้อ',convert(varchar,prod_price,1) 'ราคาสินค้า',prod_capacity 'ปริมาตร',b.unit_name 'หน่วยนับสินค้า',c.unit_name 'หน่วยนับปริมาตร',d.prod_type_name 'ประเภทสินค้า' from product a(nolock) join unit b(nolock) on a.unit_id = b.unit_id join unit c on a.unit_id_cap = c.unit_id join product_type d on a.prod_type_id = d.prod_type_id  where a.prod_type_id = " & prodtype & "order by prod_id"
        Dim DataTable As DataTable = Obj_query.selectDatatoGrid(Sql)
        If DataTable.Rows.Count < 0 Then
            DataTable.Rows.Add(New Object() {1, "ไม่มีข้อมูล"})
        End If
        With grid_showproduct
            .AutoGenerateColumns = True
            .DataSource = DataTable
        End With
    End Sub

    Private Sub grid_showproduct_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showproduct.CellClick
        Dim rowindex As Integer = grid_showproduct.CurrentRow.Index
        Dim prodid As String = grid_showproduct.Rows(rowindex).Cells(0).Value.ToString
        Dim prodname As String = grid_showproduct.Rows(rowindex).Cells(1).Value.ToString
        Dim brand As String = grid_showproduct.Rows(rowindex).Cells(2).Value.ToString
        Dim price As String = grid_showproduct.Rows(rowindex).Cells(3).Value.ToString
        Dim capa As String = grid_showproduct.Rows(rowindex).Cells(4).Value.ToString
        Dim unit As String = grid_showproduct.Rows(rowindex).Cells(5).Value.ToString
        Dim unitcap As String = grid_showproduct.Rows(rowindex).Cells(6).Value.ToString
        Dim prodtype As String = grid_showproduct.Rows(rowindex).Cells(7).Value.ToString
        Dim runno As Integer = 1
        If currentgrid.Rows.Count > 0 Then
            runno = Integer.Parse(currentgrid.Rows(currentgrid.Rows.Count - 1).Cells(1).Value.ToString())
            runno += 1
        End If
        If (prodname <> "" And prodid <> "") Then
            currentprodname.Text = prodname
            Dim row As String() = New String() {False, runno, prodname, "1", unit, price, brand, capa, prodid, "", unitcap, prodtype}
            If currentgrid.Rows.Count > 0 Then
                For i As Integer = 0 To currentgrid.Rows.Count - 1
                    If currentgrid.Rows(i).Cells(0).Value <> "" Then
                        If currentgrid.Rows(i).Cells(2).Value.Equals(prodname) And
                            currentgrid.Rows(i).Cells(4).Value.Equals(unit) And
                            currentgrid.Rows(i).Cells(6).Value.Equals(brand) And
                            currentgrid.Rows(i).Cells(7).Value.Equals(capa) And
                            currentgrid.Rows(i).Cells(10).Value.Equals(unitcap) And
                            currentgrid.Rows(i).Cells(11).Value.Equals(prodtype) Then
                            Exit Sub
                        End If
                    End If
                Next
            End If

            currentgrid.Rows.Add(row)
            Dim chk As New DataGridViewCheckBoxColumn()
            If (currentgrid.Columns.Count = 10) Then
                currentgrid.Columns.Add(chk)
                chk.Name = "ลบรายการ"
            End If

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