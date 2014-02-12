Public Class form_chooseprom

    Private Sub btn_chooseprom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_chooseprom.Click
        Dim result = MessageBox.Show("ยืนยันการเลือกใช้โปรโมชั่นนี้ใช่หรือไม่", "caption", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Yes Then
            Dim servlist_id As ArrayList = New ArrayList
            Dim prom_name As ArrayList = New ArrayList
            Dim alldata As ArrayList = New ArrayList
            For Each rows As DataGridViewRow In grid_chooseprom.Rows
                If rows.Cells(0).Value = True Then
                    servlist_id.Add(rows.Cells(5).Value.ToString)
                    prom_name.Add(rows.Cells(1).Value.ToString)
                    alldata.Add(rows.Cells(1).Value.ToString & "|" & rows.Cells(2).Value.ToString & "|" & rows.Cells(3).Value.ToString & "|" & rows.Cells(4).Value.ToString & "|" & rows.Cells(5).Value.ToString)
                End If
            Next
            If servlist_id.Count > 1 Then ' ถ้ามากกว่า 1 จะหาดูว่า มีรายการบริการ ซ้ำโปรโมชั่นกันหรือเปล่า
                For i As Integer = 0 To servlist_id.Count - 1
                    Dim data1 As String() = servlist_id(i).ToString().Split(",")
                    Dim promname1 As String = prom_name(i).ToString()
                    For j As Integer = i + 1 To servlist_id.Count - 1
                        Dim data2 As String() = servlist_id(j).ToString().Split(",")
                        Dim promname2 As String = prom_name(j).ToString()
                        For aa As Integer = 0 To data1.Length - 1
                            For bb As Integer = 0 To data2.Length - 1
                                If data1(aa) = data2(bb) Then
                                    MsgBox("โปรโมชั่นที่คุณเลือก มีรายการบริการซ้ำกัน ระหว่าง " & promname1 & " กับ " & promname2)
                                    Exit Sub
                                End If
                            Next
                        Next
                    Next
                Next
            End If
            dataaftercheckpromotion = alldata
            Me.Close()
        Else
            MsgBox("ไม่เลือกโปรโมชั่น")
            Me.Close()
        End If
    End Sub
End Class