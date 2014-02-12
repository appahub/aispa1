Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_showEmployee
    Dim Obj_query As New classquery()
    Private Sub form_showEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String
        If getEmployeeformpage = 1 Then
            Dim pos As Integer = form_in_out.cbo_inoutpos.SelectedValue
            Sql = "select emp_id 'รหัส',emp_fullname 'ชื่อพนักงาน' from employee(nolock) where pos_id = " & pos & " order by emp_id"
        Else
            Sql = "select emp_id 'รหัส',emp_fullname 'ชื่อพนักงาน' from employee(nolock) order by emp_id"
        End If
       
        Dim DataTable As DataTable = Obj_query.selectDatatoGrid(Sql)
        If DataTable.Rows.Count < 0 Then
            DataTable.Rows.Add(New Object() {1, "ไม่มีข้อมูล"})
        End If
        With grid_showmember
            .AutoGenerateColumns = True
            .DataSource = DataTable
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub grid_showmember_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_showmember.CellClick
        Dim rowindex As Integer = grid_showmember.CurrentRow.Index
        If (grid_showmember.Rows(rowindex).Cells(1).Value.ToString <> "") Then
            If getEmployeeformpage <> 9 Then
                form_in_out.txt_inout.Text = grid_showmember.Rows(rowindex).Cells(0).Value.ToString
                form_in_out.txt_empname.Text = grid_showmember.Rows(rowindex).Cells(1).Value.ToString
                form_in_out.txt_searchinout.Text = grid_showmember.Rows(rowindex).Cells(0).Value.ToString
                form_in_out.txt_ename.Text = grid_showmember.Rows(rowindex).Cells(1).Value.ToString
            Else
                form_bring.txt_pickempid.Text = grid_showmember.Rows(rowindex).Cells(0).Value.ToString
                form_bring.txt_pickempname.Text = grid_showmember.Rows(rowindex).Cells(1).Value.ToString
            End If
            Me.Close()
        End If
        
    End Sub
End Class