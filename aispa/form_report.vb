Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class form_report

    Private Sub btn_reportcustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reportcustomer.Click
        Dim crConnectionInfo As New ConnectionInfo()
        Dim cryRpt As New ReportDocument
        Dim reportDate As String = DateTime.Now().ToString("dd/MM/yyyy")
        Dim foldername As String = dtp_startdate.Value.ToString("yyyyMMdd").Substring(0, 6)
        If (Not System.IO.Directory.Exists("D:\AispaReport")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Customer_Report")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Customer_Report")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Customer_Report\" & foldername)) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Customer_Report\" & foldername)
        End If

        Dim filename As String = "รายงานลูกค้า_" & dtp_startdate.Value.ToString("yyyyMMdd") & ".PDF"
        Dim fullfilename As String = "D:\AispaReport\Customer_Report\" & foldername & "\" & filename
        If reportDate <> "" Then
            Dim report As report_customer = New report_customer

            report.SetDatabaseLogon("sa", "P@ssw0rd", "aispa", "aispa")
            report.SetParameterValue("@reportdate", reportDate)
            Try
                report.ExportToDisk(ExportFormatType.PortableDocFormat, fullfilename)
            Catch ex As Exception

            End Try
            System.Diagnostics.Process.Start(fullfilename)
        End If
    End Sub
    Private Sub form_report_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        form_home.Enabled = True
    End Sub 'Form1_Closing

    Private Sub btn_reportemployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reportemployee.Click
        Dim crConnectionInfo As New ConnectionInfo()
        Dim cryRpt As New ReportDocument
        Dim reportDate As String = DateTime.Now().ToString("dd/MM/yyyy")
        Dim foldername As String = dtp_startdate.Value.ToString("yyyyMMdd").Substring(0, 6)
        If (Not System.IO.Directory.Exists("D:\AispaReport")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Employee_Report")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Employee_Report")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Employee_Report\" & foldername)) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Employee_Report\" & foldername)
        End If

        Dim filename As String = "รายงานลูกค้า_" & dtp_startdate.Value.ToString("yyyyMMdd") & ".PDF"
        Dim fullfilename As String = "D:\AispaReport\Employee_Report\" & foldername & "\" & filename
        If reportDate <> "" Then
            Dim report As report_employee = New report_employee

            report.SetDatabaseLogon("sa", "P@ssw0rd", "aispa", "aispa")
            report.SetParameterValue("@reportdate", reportDate)
            Try
                report.ExportToDisk(ExportFormatType.PortableDocFormat, fullfilename)
            Catch ex As Exception

            End Try
            System.Diagnostics.Process.Start(fullfilename)
        End If
    End Sub

    Private Sub btn_reportproductleft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reportproductleft.Click
        Dim crConnectionInfo As New ConnectionInfo()
        Dim cryRpt As New ReportDocument
        Dim reportDate As String = DateTime.Now().ToString("dd/MM/yyyy")
        Dim foldername As String = dtp_startdate.Value.ToString("yyyyMMdd").Substring(0, 6)
        If (Not System.IO.Directory.Exists("D:\AispaReport")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Product_Left_Report")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Product_Left_Report")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Product_Left_Report\" & foldername)) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Product_Left_Report\" & foldername)
        End If

        Dim filename As String = "รายงานผลิตภัณฑ์คงเหลือ_" & dtp_startdate.Value.ToString("yyyyMMdd") & ".PDF"
        Dim fullfilename As String = "D:\AispaReport\Product_Left_Report\" & foldername & "\" & filename
        If reportDate <> "" Then
            Dim report As report_product_left = New report_product_left

            report.SetDatabaseLogon("sa", "P@ssw0rd", "aispa", "aispa")
            report.SetParameterValue("@reportdate", reportDate)
            Try
                report.ExportToDisk(ExportFormatType.PortableDocFormat, fullfilename)
            Catch ex As Exception

            End Try
            System.Diagnostics.Process.Start(fullfilename)
        End If
    End Sub

    Private Sub btn_reportproductorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reportproductorder.Click
        Dim crConnectionInfo As New ConnectionInfo()
        Dim cryRpt As New ReportDocument
        Dim reportDate As String = DateTime.Now().ToString("dd/MM/yyyy")
        Dim foldername As String = DateTime.Now().ToString("yyyyMMdd").Substring(0, 6)
        Dim StartDate As String = dtp_startdate.Value.ToString("dd/MM/yyyy")
        Dim EndDate As String = dtp_enddate.Value.ToString("dd/MM/yyyy")
        Dim StartsearchDate As String = dtp_startdate.Value.ToString("yyyyMMdd")
        Dim EndsearchDate As String = dtp_enddate.Value.ToString("yyyyMMdd")
        If (Not System.IO.Directory.Exists("D:\AispaReport")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Product_Order_Report")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Product_Order_Report")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Product_Order_Report\" & foldername)) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Product_Order_Report\" & foldername)
        End If

        Dim filename As String = "รายงานสั่งซื้อผลิตภัณฑ์_" & DateTime.Now().ToString("yyyyMMdd") & ".PDF"
        Dim fullfilename As String = "D:\AispaReport\Product_Order_Report\" & foldername & "\" & filename
        If reportDate <> "" Then
            Dim report As report_product_order = New report_product_order

            report.SetDatabaseLogon("sa", "P@ssw0rd", "aispa", "aispa")
            report.SetParameterValue("@reportdate", reportDate)
            report.SetParameterValue("@startdate", StartDate)
            report.SetParameterValue("@enddate", EndDate)
            report.SetParameterValue("@startsearchdate", StartsearchDate)
            report.SetParameterValue("@endsearchdate", EndsearchDate)
            Try
                report.ExportToDisk(ExportFormatType.PortableDocFormat, fullfilename)
            Catch ex As Exception

            End Try
            System.Diagnostics.Process.Start(fullfilename)
        End If
    End Sub

    Private Sub btn_reportproductpick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reportproductpick.Click
        Dim crConnectionInfo As New ConnectionInfo()
        Dim cryRpt As New ReportDocument
        Dim reportDate As String = DateTime.Now().ToString("dd/MM/yyyy")
        Dim foldername As String = DateTime.Now().ToString("yyyyMMdd").Substring(0, 6)
        Dim StartDate As String = dtp_startdate.Value.ToString("dd/MM/yyyy")
        Dim EndDate As String = dtp_enddate.Value.ToString("dd/MM/yyyy")
        Dim StartsearchDate As String = dtp_startdate.Value.ToString("yyyyMMdd")
        Dim EndsearchDate As String = dtp_enddate.Value.ToString("yyyyMMdd")
        If (Not System.IO.Directory.Exists("D:\AispaReport")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Product_Picking_Report")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Product_Picking_Report")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Product_Picking_Report\" & foldername)) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Product_Picking_Report\" & foldername)
        End If

        Dim filename As String = "รายงานเบิกผลิตภัณฑ์_" & DateTime.Now().ToString("yyyyMMdd") & ".PDF"
        Dim fullfilename As String = "D:\AispaReport\Product_Picking_Report\" & foldername & "\" & filename
        If reportDate <> "" Then
            Dim report As report_product_pick = New report_product_pick

            report.SetDatabaseLogon("sa", "P@ssw0rd", "aispa", "aispa")
            report.SetParameterValue("@reportdate", reportDate)
            report.SetParameterValue("@startdate", StartDate)
            report.SetParameterValue("@enddate", EndDate)
            report.SetParameterValue("@startsearchdate", StartsearchDate)
            report.SetParameterValue("@endsearchdate", EndsearchDate)
            Try
                report.ExportToDisk(ExportFormatType.PortableDocFormat, fullfilename)
            Catch ex As Exception

            End Try
            System.Diagnostics.Process.Start(fullfilename)
        End If
    End Sub

    Private Sub btn_cus_serv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cus_serv.Click
        Dim crConnectionInfo As New ConnectionInfo()
        Dim cryRpt As New ReportDocument
        Dim reportDate As String = DateTime.Now().ToString("dd/MM/yyyy")
        Dim foldername As String = DateTime.Now().ToString("yyyyMMdd").Substring(0, 6)
        Dim StartDate As String = dtp_startdate.Value.ToString("dd/MM/yyyy")
        Dim EndDate As String = dtp_enddate.Value.ToString("dd/MM/yyyy")
        Dim StartsearchDate As String = dtp_startdate.Value.ToString("yyyyMMdd")
        Dim EndsearchDate As String = dtp_enddate.Value.ToString("yyyyMMdd")
        If (Not System.IO.Directory.Exists("D:\AispaReport")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Customer_Service_Report")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Customer_Service_Report")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Customer_Service_Report\" & foldername)) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Customer_Service_Report\" & foldername)
        End If

        Dim filename As String = "รายงานผู้มาใช้บริการ_" & DateTime.Now().ToString("yyyyMMdd") & ".PDF"
        Dim fullfilename As String = "D:\AispaReport\Customer_Service_Report\" & foldername & "\" & filename
        If reportDate <> "" Then
            Dim report As report_customer_service = New report_customer_service

            report.SetDatabaseLogon("sa", "P@ssw0rd", "aispa", "aispa")
            report.SetParameterValue("@reportdate", reportDate)
            report.SetParameterValue("@startdate", StartDate)
            report.SetParameterValue("@enddate", EndDate)
            report.SetParameterValue("@startsearchdate", StartsearchDate)
            report.SetParameterValue("@endsearchdate", EndsearchDate)
            Try
                report.ExportToDisk(ExportFormatType.PortableDocFormat, fullfilename)
            Catch ex As Exception

            End Try
            System.Diagnostics.Process.Start(fullfilename)
        End If
    End Sub

    Private Sub btn_emp_serv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_emp_serv.Click
        Dim crConnectionInfo As New ConnectionInfo()
        Dim cryRpt As New ReportDocument
        Dim reportDate As String = DateTime.Now().ToString("dd/MM/yyyy")
        Dim foldername As String = DateTime.Now().ToString("yyyyMMdd").Substring(0, 6)
        Dim StartDate As String = dtp_startdate.Value.ToString("dd/MM/yyyy")
        Dim EndDate As String = dtp_enddate.Value.ToString("dd/MM/yyyy")
        Dim StartsearchDate As String = dtp_startdate.Value.ToString("yyyyMMdd")
        Dim EndsearchDate As String = dtp_enddate.Value.ToString("yyyyMMdd")
        If (Not System.IO.Directory.Exists("D:\AispaReport")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Employee_Service_Report")) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Employee_Service_Report")
        End If
        If (Not System.IO.Directory.Exists("D:\AispaReport\Employee_Service_Report\" & foldername)) Then
            System.IO.Directory.CreateDirectory("D:\AispaReport\Employee_Service_Report\" & foldername)
        End If

        Dim filename As String = "รายงานพนักงานที่ให้บริการ_" & DateTime.Now().ToString("yyyyMMdd") & ".PDF"
        Dim fullfilename As String = "D:\AispaReport\Employee_Service_Report\" & foldername & "\" & filename
        If reportDate <> "" Then
            Dim report As report_employee_service = New report_employee_service

            report.SetDatabaseLogon("sa", "P@ssw0rd", "aispa", "aispa")
            report.SetParameterValue("@reportdate", reportDate)
            report.SetParameterValue("@startdate", StartDate)
            report.SetParameterValue("@enddate", EndDate)
            report.SetParameterValue("@startsearchdate", StartsearchDate)
            report.SetParameterValue("@endsearchdate", EndsearchDate)
            Try
                report.ExportToDisk(ExportFormatType.PortableDocFormat, fullfilename)
            Catch ex As Exception

            End Try
            System.Diagnostics.Process.Start(fullfilename)
        End If
    End Sub
End Class