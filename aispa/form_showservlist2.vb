Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_showservlist2
    Dim Obj_query = New classquery()
    Private Sub form_showservlist2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim prodtype As Integer = productype
        'Dim servlistid As String = form_mainmgr.cbo_servlisttype.SelectedValue
        Dim Sql As String = "select ROW_NUMBER() over (order by liserv_id) 'ลำดับ',liserv_name 'รายการบริการ' , b.liserv_type_name 'ประเภทรายการบริการ' " +
                " , convert(varchar,liserv_price,1) 'ราคา' , liserv_id " +
                " from service_list a(nolock) " +
                " join service_list_type b(nolock) on a.liserv_type_id = b.liserv_type_id " +
                " where a.liserv_type_id = " + servlistidselect + ""
        Dim sqlcbo As String = "select emp_id ID,emp_fullname Name from employee"
        Dim DataTable As DataTable = Obj_query.selectDatatoGrid(Sql)
        If DataTable.Rows.Count < 0 Then
            DataTable.Rows.Add(New Object() {1, "ไม่มีข้อมูล"})
        End If
        With grid_showservlist2
            .AutoGenerateColumns = True
            .DataSource = DataTable
        End With
        grid_showservlist2.Columns(4).Visible = False
    End Sub

    Private Sub grid_showservlist2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showservlist2.CellClick
        Dim rowindex As Integer = grid_showservlist2.CurrentRow.Index
        Dim servname As String = grid_showservlist2.Rows(rowindex).Cells(1).Value.ToString
        Dim servtype As String = grid_showservlist2.Rows(rowindex).Cells(2).Value.ToString
        Dim servprice As String = grid_showservlist2.Rows(rowindex).Cells(3).Value.ToString
        servprice = servprice.Substring(0, servprice.Length - 2)
        Dim servid As String = grid_showservlist2.Rows(rowindex).Cells(4).Value.ToString
        If (servname <> "" And servid <> "") Then
            If servtypeshow = "normal" Then
                gridnow = form_mainmgr.grid_showpromprod
                form_mainmgr.txt_servlist.Text = servname

            ElseIf servtypeshow = "used" Then
                gridnow = form_mainmgr.grid_servchoosedo
                form_mainmgr.txt_searchservused.Text = servname
            End If
            Dim runno As Integer = 1
            If gridnow.Rows.Count > 0 Then
                runno = Integer.Parse(gridnow.Rows(gridnow.Rows.Count - 1).Cells(1).Value.ToString())
                runno += 1
            End If
            Dim row As String() = New String() {False, runno, servname, servtype, servprice, servid, ""}
            If gridnow.Rows.Count > 0 Then
                For i As Integer = 0 To gridnow.Rows.Count - 1
                    If gridnow.Rows(i).Cells(1).Value <> "" Then
                        If gridnow.Rows(i).Cells(2).Value.Equals(servname) And
                            gridnow.Rows(i).Cells(3).Value.Equals(servtype) And
                            gridnow.Rows(i).Cells(4).Value.Equals(servprice) And
                            gridnow.Rows(i).Cells(5).Value.Equals(servid) Then
                            Exit Sub
                        End If
                    End If
                Next
            End If
            gridnow.Rows.Add(row)
        End If
        If gridnow.Rows.Count > 0 Then
            If servtypeshow = "normal" Then
                form_mainmgr.txt_promotionprice.Enabled = True
                form_mainmgr.txt_qtyfree.Enabled = True
            ElseIf servtypeshow = "used" Then
                form_mainmgr.txt_qtyused.Enabled = True
            End If
        End If
    End Sub
End Class