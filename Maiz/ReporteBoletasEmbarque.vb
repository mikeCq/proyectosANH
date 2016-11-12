﻿Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class ReporteBoletasEmbarque
    Private Sub ReporteBoletasEmbarque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim RptBoletasEmbarques As New ReporteBoletaEmbarque
        RptBoletasEmbarques.SetDatabaseLogon("sa", "Usuario01", "MSISTEMAS", "MAIZ")
        RptBoletasEmbarques.SetParameterValue("@idembarque", ControlEmbarques.codigoEmbarque)
        RptBoletasEmbarques.SetParameterValue("@MaizAmarillo", ControlEmbarques.MaizAmarillo)
        RptBoletasEmbarques.SetParameterValue("@MaizBlanco", ControlEmbarques.MaizBlanco)

        CrBoletaEmbarque.ReportSource = RptBoletasEmbarques
    End Sub
End Class