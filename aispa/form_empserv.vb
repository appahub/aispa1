Public Class form_empserv
    Private Sub btn_confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        service_name.Clear()
        service_type.Clear()
        service_id.Clear()
        service_empid.Clear()
        For Each row As DataGridViewRow In grid_servemp.Rows
            'MsgBox(row.Cells(1).Value & " : " & row.Cells(2).Value & " : " & row.Cells(3).Value)
            Dim servname As String = row.Cells(0).Value
            Dim typeinsert As String = row.Cells(2).Value
            Dim id As String = row.Cells(1).Value
            Dim empid As String = row.Cells(4).Value
            service_name.Add(servname)
            service_type.Add(typeinsert)
            service_id.Add(id)
            service_empid.Add(empid)
        Next
        Me.Close()
    End Sub
End Class