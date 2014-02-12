Imports aispa.classquery
Public Class form_home
    Dim Obj_query As classquery = New classquery()
    Private Sub form_home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        form_login.TopMost = True
        form_login.Show()
        'form_login.BringToFront()
        Me.Enabled = False
        form_login.txt_user.Focus()
    End Sub
    Private Sub btn_loadgeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadgeneral.Click
        form_genaral.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_loadmain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadmain.Click
        form_mainmgr.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_loadorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadorder.Click
        form_order.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_loadinout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadinout.Click
        form_in_out.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_logout.Click
        Obj_query.SetEmdId(0)
        Me.Enabled = False
        form_login.Show()
        lbl_welcome.Text = ""
    End Sub

    

  
    Private Sub btn_loadservice_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadservice_user.Click
        form_service.Show()
        Me.Enabled = False
    End Sub
    Private Sub btn_loadrecieve_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadrecieve_user.Click
        form_recieve.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_loadinout_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadinout_user.Click
        form_in_out.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_logout_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_logout_user.Click
        Obj_query.SetEmdId(0)
        Me.Enabled = False
        form_login.Show()
        lbl_welcome.Text = ""
    End Sub

    Private Sub btn_loadmain_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadmain_user.Click
        form_mainmgr.tab_management.TabPages.RemoveAt(1)
        form_mainmgr.Show()
        Me.Enabled = False
    End Sub


    Private Sub btn_loadbring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadbring.Click
        form_bring.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_loadbring_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadbring_user.Click
        form_bring.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_loadrecieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadrecieve.Click
        form_recieve.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_loadservice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadservice.Click
        form_service.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_loadreport_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadreport_user.Click
        form_report.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_loadreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadreport.Click
        form_report.Show()
        Me.Enabled = False
    End Sub
End Class