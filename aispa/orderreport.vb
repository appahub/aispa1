Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class orderreport

    Private Sub orderreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim crConnectionInfo As New ConnectionInfo()
        Dim cryRpt As New ReportDocument

        Dim orderid As String = form_order.txt_orderid.Text
        If orderid <> "" Then
            Dim report As orderproduct = New orderproduct

            report.SetDatabaseLogon("sa", "P@ssw0rd", "aispa", "aispa")
            report.SetParameterValue("@order_id", orderid)
            CrystalReportViewer1.ReportSource = report
            Try
                'Dim CrExportOptions As ExportOptions
                'Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                'Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                'CrDiskFileDestinationOptions.DiskFileName = "C:\"
                'CrExportOptions = cryRpt.ExportOptions
                'With CrExportOptions
                '    .ExportDestinationType = ExportDestinationType.DiskFile
                '    .ExportFormatType = ExportFormatType.PortableDocFormat
                '    .DestinationOptions = CrDiskFileDestinationOptions
                '    .FormatOptions = CrFormatTypeOptions
                'End With
                report.ExportToDisk(ExportFormatType.PortableDocFormat, "E:\test.PDF")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        

        

        
    End Sub
End Class