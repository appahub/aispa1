Imports aispa.classquery
Imports System.Data.SqlClient
Public Class form_add_money
    Dim Obj_query As New classquery()
    Dim Sql As String
    Dim datatable As New DataTable
    Dim selectedIndex As Integer
    Dim minlimit As Double = 0.0
    Dim maxmoney As Double = 0.0
    Private Sub add_money_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_leftmoney.Text = form_mainmgr.txt_mmoney.Text
        Dim typeid = form_mainmgr.cbo_mtypemem.SelectedValue
        If typeid > -1 Then
            Sql = "select convert(varchar,isnull(custype_minlimit,0),1) money,convert(varchar,isnull(custype_amount,0),1) maxmoney from customer_type(nolock) where custype_id = " & typeid
            DataTable = Obj_query.selectDatatoGrid(Sql)
            minlimit = Double.Parse(datatable.Rows(0)("money").ToString().Trim())
            maxmoney = Double.Parse(datatable.Rows(0)("maxmoney").ToString().Trim())
            'Dim chooseaddmoney As Double = minlimit - Double.Parse(lbl_leftmoney.Text)
            If minlimit > 0 Then
                lbl_notice.Text = "กรุณาระบุจำนวนวงเงิน มากกว่า หรือ เท่ากับ " & minlimit
            Else
                lbl_notice.Text = "ยอดคงเหลือของคุณ ยังสามารถใช้งานได้ตามปกติ "
            End If
            txt_addmoney.Text = Math.Abs(minlimit).ToString("#,##0.00")
            lbl_notice.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        Dim addmoney As Double = 0.0
        Dim moneytext As String = txt_addmoney.Text
        If Double.TryParse(moneytext, addmoney) And addmoney >= 0 And addmoney >= minlimit Then
            Dim leftmoney As Double = Double.Parse(form_mainmgr.txt_mmoney.Text)
            Dim usemoney As Double = Double.Parse(form_mainmgr.txt_amoney.Text)
            Dim totalmoney As Double = addmoney + leftmoney
            Dim paymorethanlimitleft As Double = 0.0
            If addmoney > minlimit Then
                paymorethanlimitleft = addmoney - minlimit
            End If
            Dim totalusemoney As Double = maxmoney + usemoney + paymorethanlimitleft
            form_mainmgr.txt_mmoney.Text = totalmoney.ToString("#,##0.00")
            form_mainmgr.txt_amoney.Text = totalusemoney.ToString("#,##0.00")
            Me.Close()
        Else
            MsgBox("จำนวนเงินต้องมากกว่า หรือ เท่ากับ " & minlimit)
        End If
    End Sub
End Class