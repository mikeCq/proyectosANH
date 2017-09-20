Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class ReporteVentas
    Private Sub ReporteVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim codigo As String = LiquidacionXcomprador.codigoLiquidacionVenta

        Try
            Dim CrReport As RptVentaXcomprador = New RptVentaXcomprador

            Dim da As New SqlCommand("sp_reporteVentaLiquidacion", cnn)
            Dim Ruta As String = "\\192.168.10.30\docs_sistemas\RPT_MAIZ\RptVentaXcomprador.rpt"
            'Dim Ruta As String = Application.StartupPath & "\RPT\ReporteBoletaEntrada.rpt"
            da.CommandType = CommandType.StoredProcedure
            Dim IdLiquidacion As New SqlClient.SqlParameter()
            IdLiquidacion.ParameterName = "@IdLiquidacionVenta"
            IdLiquidacion.SqlDbType = SqlDbType.NVarChar
            IdLiquidacion.Value = codigo

            da.Parameters.Add(IdLiquidacion)

            Dim dasp_ReporteBoletaEmbarque As New SqlClient.SqlDataAdapter()
            dasp_ReporteBoletaEmbarque.SelectCommand = da
            Dim ds As New DataTable
            dasp_ReporteBoletaEmbarque.Fill(ds)


            Dim daResumen As New SqlCommand("sp_resumenVentasLiquidadas", cnn)
            daResumen.CommandType = CommandType.StoredProcedure
            Dim IdLiquidacionR As New SqlClient.SqlParameter()
            IdLiquidacionR.ParameterName = "@idLiquidacionResumen"
            IdLiquidacionR.SqlDbType = SqlDbType.NVarChar
            IdLiquidacionR.Value = codigo

            daResumen.Parameters.Add(IdLiquidacionR)

            Dim dasp_ResumenBoletas As New SqlClient.SqlDataAdapter()
            dasp_ResumenBoletas.SelectCommand = daResumen
            Dim dsResumen As New DataTable
            dasp_ResumenBoletas.Fill(dsResumen)

            CrReport.Load(Ruta)

            CrReport.SetDataSource(ds)
            CrReport.Subreports("VentaResumen").SetDataSource(dsResumen)
            CrLiquidacionVenta.ReportSource = CrReport

            codigo = ""
        Catch ex As Exception
            MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
        End Try
    End Sub
End Class