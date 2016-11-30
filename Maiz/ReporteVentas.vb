Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class ReporteVentas
    Private Sub ReporteVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rptReporteVentas As New RptVentaXcomprador
        Dim codigo As String = LiquidacionXcomprador.codigoLiquidacionVenta
        rptReporteVentas.SetDatabaseLogon("sa", "Usuario01", "SERVER2008\SERVER12", "MAIZ")
        rptReporteVentas.SetParameterValue("@idliquidacionVenta", codigo)
        CrLiquidacionVenta.ReportSource = rptReporteVentas
    End Sub
End Class