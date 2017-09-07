Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class ReporteBoletasSalidas
    Private Sub ReporteBoletasSalidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim CrReport As ReporteBoletaSalida = New ReporteBoletaSalida

            Dim da As New SqlCommand("sp_ReporteBoletaSalida", cnn)
            Dim Ruta As String = "\\192.168.10.30\docs_sistemas\RPT_MAIZ\ReporteBoletaSalida.rpt"
            'Dim Ruta As String = Application.StartupPath & "\RPT\ReporteBoletaSalida.rpt"
            da.CommandType = CommandType.StoredProcedure
            Dim NombreCampo As New SqlClient.SqlParameter()
            NombreCampo.ParameterName = "@IdSalida"
            NombreCampo.SqlDbType = SqlDbType.NVarChar
            NombreCampo.Value = ControlSalidas.codigoSalida

            Dim MaizBlanco As New SqlClient.SqlParameter()
            MaizBlanco.ParameterName = "@MaizBlanco"
            MaizBlanco.SqlDbType = SqlDbType.NVarChar
            MaizBlanco.Value = ControlSalidas.MaizBlanco

            Dim MaizAmarillo As New SqlClient.SqlParameter()
            MaizAmarillo.ParameterName = "@MaizAmarillo"
            MaizAmarillo.SqlDbType = SqlDbType.NVarChar
            MaizAmarillo.Value = ControlSalidas.MaizAmarillo

            da.Parameters.Add(NombreCampo)
            da.Parameters.Add(MaizBlanco)
            da.Parameters.Add(MaizAmarillo)
            Dim dasp_ReporteBoletaEmbarque As New SqlClient.SqlDataAdapter()
            dasp_ReporteBoletaEmbarque.SelectCommand = da
            Dim ds As New DataTable
            dasp_ReporteBoletaEmbarque.Fill(ds)

            CrReport.Load(Ruta)

            CrReport.SetDataSource(ds)

            CrBoletaSalida.ReportSource = CrReport
        Catch ex As Exception
            MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
        End Try
    End Sub
End Class