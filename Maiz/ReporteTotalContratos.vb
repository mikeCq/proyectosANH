Public Class ReporteTotalContratos
    Private Sub ReporteContratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rptReporteTotalContratos As New RPTTotalContratado
        Dim codigo As String = LiquidacionXcomprador.codigoLiquidacionVenta
        rptReporteTotalContratos.SetDatabaseLogon(VarGlob.UserDB, VarGlob.PasswordDB, VarGlob.ServerDB, VarGlob.DataBase)
        CrTotalContratado.ReportSource = rptReporteTotalContratos
    End Sub
End Class