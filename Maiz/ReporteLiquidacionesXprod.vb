Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class ReporteLiquidacionesXprod
    Private Sub ReporteLiquidacionesXprod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim RptLiquidacionProd As New ReporteLiquidacionesXproductor
        Dim codigo As String = liquidacionCalculosProd.codigoLiquidacionTP
        RptLiquidacionProd.SetDatabaseLogon("sa", "Usuario01", "SERVER2008\SERVER12", "MAIZ")
        RptLiquidacionProd.SetParameterValue("@idliquidaciontprincipal", liquidacionCalculosProd.codigoLiquidacionTP)
        CrLiquidacionProd.ReportSource = RptLiquidacionProd

    End Sub

End Class