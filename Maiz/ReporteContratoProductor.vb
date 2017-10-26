Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Public Class ReporteContratoProductor

    Private Sub CrContratoProductor_Load(sender As Object, e As EventArgs) Handles CrContratoProductor.Load
        Try
            Dim CrReport As RPTContratoProductor = New RPTContratoProductor

            Dim da As New SqlCommand("sp_ContratoProductor", cnn)
            Dim Ruta As String = "\\192.168.10.30\docs_sistemas\RPT_MAIZ\RPTContratoProductor.rpt"
            da.CommandType = CommandType.StoredProcedure
            Dim IdCompras As New SqlClient.SqlParameter()
            IdCompras.ParameterName = "@IdContratoC"
            IdCompras.SqlDbType = SqlDbType.NVarChar
            IdCompras.Value = ContratosCompras.codigoCompras
            Dim dasp_ReporteBoletaEmbarque As New SqlClient.SqlDataAdapter()
            dasp_ReporteBoletaEmbarque.SelectCommand = da

            Dim ds As New DataTable

            da.Parameters.Add(IdCompras)
            dasp_ReporteBoletaEmbarque.Fill(ds)

            CrReport.Load(Ruta)
            CrReport.SetDataSource(ds)

            CrContratoProductor.ReportSource = CrReport

            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
            Dim CrFormatType As New PdfRtfWordFormatOptions
            Dim RutaPDF As String = ContratosCompras.CadenaDocumento & ".pdf"
            CrDiskFileDestinationOptions.DiskFileName = RutaPDF
            CrExportOptions = CrReport.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .ExportDestinationOptions = CrDiskFileDestinationOptions
                .ExportFormatOptions = CrFormatType
            End With
            CrReport.Export()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class