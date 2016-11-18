﻿Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class ReporteEntradasGlobalXprod
    Private Sub ReporteEntradasGlobalXprod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CrEntradasGlobalXprod.ReportSource = Nothing
        CrEntradasGlobalXprod.Refresh()
        TxNumBoleta.Select()
        limpiarCampos()
        llenarCombos()
    End Sub
    Private Sub llenarCombos()
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        Dim cmdllenaCbPro As SqlCommand

        cmdllenaCbPro = New SqlCommand("Sp_CbProductorEntradasGlobalReporte")
        cmdllenaCbPro.CommandType = CommandType.StoredProcedure
        cmdllenaCbPro.Connection = cnn

        da = New SqlDataAdapter(cmdllenaCbPro)
        ds = New DataSet()
        da.Fill(ds)
        CbProductor.DataSource = ds.Tables(0)
        CbProductor.DisplayMember = "nombreProductor"
        CbProductor.ValueMember = "Id_cliente"
        CbProductor.SelectedIndex = -1
    End Sub
    Private Sub limpiarCampos() Handles Btlimpiar.Click
        TxNumBoleta.Text = ""
        CbProductor.Text = ""
        CbProductor.SelectedIndex = -1
        DTInicio.Value = "01/01/1900"
        DTFinal.Value = "01/01/1900"
    End Sub
    Private Sub generaReporte(sender As Object, e As EventArgs) Handles BtGenerarReporte.Click
        Try


            Dim RptReporteEntradasGlobalxProd As New ReporteEntradaGlobalXprod
            If DTInicio.Value <= DTFinal.Value And DTFinal.Value >= DTInicio.Value Then
                RptReporteEntradasGlobalxProd.SetDatabaseLogon("sa", "Usuario01", "SERVER2008\SERVER12", "MAIZ")
                RptReporteEntradasGlobalxProd.SetParameterValue("@numboleta", TxNumBoleta.Text)
                RptReporteEntradasGlobalxProd.SetParameterValue("@productor", IIf(CbProductor.SelectedValue = Nothing, "", CbProductor.SelectedValue))
                RptReporteEntradasGlobalxProd.SetParameterValue("@fechaini", DTInicio.Value)
                RptReporteEntradasGlobalxProd.SetParameterValue("@fechafin", DTFinal.Value)
                CrEntradasGlobalXprod.ReportSource = RptReporteEntradasGlobalxProd
            Else
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final, ni la fecha final, menor que la fecha inicial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                limpiarCampos()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TxContraseña_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxNumBoleta.KeyDown, DTFinal.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim RptReporteEntradasGlobalxProd As New ReporteEntradaGlobalXprod
                If DTInicio.Value <= DTFinal.Value And DTFinal.Value >= DTInicio.Value Then
                    RptReporteEntradasGlobalxProd.SetDatabaseLogon("sa", "Usuario01", "SERVER2008\SERVER12", "MAIZ")
                    RptReporteEntradasGlobalxProd.SetParameterValue("@numboleta", TxNumBoleta.Text)
                    RptReporteEntradasGlobalxProd.SetParameterValue("@productor", IIf(CbProductor.SelectedValue = Nothing, "", CbProductor.SelectedValue))
                    RptReporteEntradasGlobalxProd.SetParameterValue("@fechaini", DTInicio.Value)
                    RptReporteEntradasGlobalxProd.SetParameterValue("@fechafin", DTFinal.Value)
                    CrEntradasGlobalXprod.ReportSource = RptReporteEntradasGlobalxProd
                Else
                    MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final, ni la fecha final, menor que la fecha inicial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    limpiarCampos()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
End Class