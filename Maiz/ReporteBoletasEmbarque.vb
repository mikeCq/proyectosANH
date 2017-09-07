Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class ReporteBoletasEmbarque
    Private Sub ReporteBoletasEmbarque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim CrReport As ReporteBoletaEmbarque = New ReporteBoletaEmbarque

            Dim da As New SqlCommand("sp_ReporteBoletaEmbarque", cnn)
            Dim Ruta As String = "\\192.168.10.30\docs_sistemas\RPT_MAIZ\ReporteBoletaEmbarque.rpt"
            'Dim Ruta As String = Application.StartupPath & "\RPT\ReporteBoletaEmbarque.rpt"
            da.CommandType = CommandType.StoredProcedure
            Dim NombreCampo As New SqlClient.SqlParameter()
            NombreCampo.ParameterName = "@idEmbarque"
            NombreCampo.SqlDbType = SqlDbType.NVarChar
            NombreCampo.Value = ControlEmbarques.codigoEmbarque

            Dim MaizBlanco As New SqlClient.SqlParameter()
            MaizBlanco.ParameterName = "@MaizBlanco"
            MaizBlanco.SqlDbType = SqlDbType.NVarChar
            MaizBlanco.Value = ControlEmbarques.MaizBlanco

            Dim MaizAmarillo As New SqlClient.SqlParameter()
            MaizAmarillo.ParameterName = "@MaizAmarillo"
            MaizAmarillo.SqlDbType = SqlDbType.NVarChar
            MaizAmarillo.Value = ControlEmbarques.MaizAmarillo

            da.Parameters.Add(NombreCampo)
            da.Parameters.Add(MaizBlanco)
            da.Parameters.Add(MaizAmarillo)
            Dim dasp_ReporteBoletaEmbarque As New SqlClient.SqlDataAdapter()
            dasp_ReporteBoletaEmbarque.SelectCommand = da
            Dim ds As New DataTable
            dasp_ReporteBoletaEmbarque.Fill(ds)

            CrReport.Load(Ruta)
            CrReport.SetDataSource(ds)

            CrBoletaEmbarque.ReportSource = CrReport
        Catch ex As Exception
            MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
        End Try
    End Sub
End Class