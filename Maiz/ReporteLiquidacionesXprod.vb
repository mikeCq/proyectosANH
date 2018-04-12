Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class ReporteLiquidacionesXprod
    Private Sub ReporteLiquidacionesXprod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim RptLiquidacionProd As New ReporteLiquidacionesXproductor
        'Dim codigo As String = liquidacionCalculosProd.codigoLiquidacionTP
        'RptLiquidacionProd.SetDatabaseLogon(VarGlob.UserDB, VarGlob.PasswordDB, VarGlob.ServerDB, VarGlob.DataBase)
        'RptLiquidacionProd.SetParameterValue("@idliquidaciontprincipal", liquidacionCalculosProd.codigoLiquidacionTP)
        'CrLiquidacionProd.ReportSource = RptLiquidacionProd

        Try
            Dim CrReport As ReporteLiquidacionesXproductor = New ReporteLiquidacionesXproductor

            Dim da As New SqlCommand("sp_reporteLiquidacionXproductor1", cnn)
            'Dim Ruta As String = "\\192.168.10.30\docs_sistemas\RPT_MAIZ\ReporteLiquidacionesXproductor.rpt"
            Dim Ruta As String = Application.StartupPath & "\RPT\ReporteLiquidacionesXproductor.rpt"
            da.CommandType = CommandType.StoredProcedure
            Dim IdLiquidacion As New SqlClient.SqlParameter()
            IdLiquidacion.ParameterName = "@idliquidaciont"
            IdLiquidacion.SqlDbType = SqlDbType.NVarChar
            IdLiquidacion.Value = liquidacionCalculosProd.codigoLiquidacionTP

            da.Parameters.Add(IdLiquidacion)

            Dim dasp_ReporteBoletaEmbarque As New SqlClient.SqlDataAdapter()
            dasp_ReporteBoletaEmbarque.SelectCommand = da
            Dim ds As New DataTable
            dasp_ReporteBoletaEmbarque.Fill(ds)


            Dim daResumen As New SqlCommand("sp_resumenBoletasLiquidadas", cnn)
            daResumen.CommandType = CommandType.StoredProcedure
            Dim IdLiquidacionP As New SqlClient.SqlParameter()
            IdLiquidacionP.ParameterName = "@idLiquidacionTotal"
            IdLiquidacionP.SqlDbType = SqlDbType.NVarChar
            IdLiquidacionP.Value = liquidacionCalculosProd.codigoLiquidacionTP

            daResumen.Parameters.Add(IdLiquidacionP)

            Dim dasp_ResumenBoletas As New SqlClient.SqlDataAdapter()
            dasp_ResumenBoletas.SelectCommand = daResumen
            Dim dsResumen As New DataTable
            dasp_ResumenBoletas.Fill(dsResumen)

            CrReport.Load(Ruta)

            CrReport.SetDataSource(ds)
            CrReport.Subreports("ResumenBoletas").SetDataSource(dsResumen)
            CrLiquidacionProd.ReportSource = CrReport
        Catch ex As Exception
            MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
        End Try
    End Sub

End Class