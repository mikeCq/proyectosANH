Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class ReporteCompras
    Private Sub ReporteCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CrComprasXproductor.ReportSource = Nothing
        CrComprasXproductor.Refresh()
        limpiarCampos()
        llenarCombos()
    End Sub
    Private Sub llenarCombos()
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        Dim cmdllenaCbPro As SqlCommand

        cmdllenaCbPro = New SqlCommand("sp_cproductoresConliquidaciones")
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
        CbProductor.Text = ""
        CbProductor.SelectedIndex = -1
        DTInicio.Value = "01/01/1900"
        DTFinal.Value = "01/01/1900"
        CbTipoContrato.Text = ""
        CbTipoContrato.SelectedIndex = -1
    End Sub
    Private Sub generaReporte(sender As Object, e As EventArgs) Handles BtGenerarReporte.Click
        Try
            Dim CrReport As RptComprasXproductor = New RptComprasXproductor

            Dim da As New SqlCommand("sp_ReporteCompras", cnn)
            Dim Ruta As String = "\\192.168.10.30\docs_sistemas\RPT_MAIZ\RptComprasXproductor.rpt"
            'Dim Ruta As String = Application.StartupPath & "\RPT\ReporteBoletaEntrada.rpt"
            da.CommandType = CommandType.StoredProcedure
            Dim IdProductor As New SqlClient.SqlParameter()
            IdProductor.ParameterName = "@idproductor"
            IdProductor.SqlDbType = SqlDbType.NVarChar
            IdProductor.Value = IIf(CbProductor.SelectedValue = Nothing, "", CbProductor.SelectedValue)

            Dim TipoContrato As New SqlClient.SqlParameter()
            TipoContrato.ParameterName = "@tipoContrato"
            TipoContrato.SqlDbType = SqlDbType.NVarChar
            TipoContrato.Value = IIf(CbTipoContrato.Text = Nothing, "", CbTipoContrato.Text)

            Dim FechaInicio As New SqlClient.SqlParameter()
            FechaInicio.ParameterName = "@fechaini"
            FechaInicio.SqlDbType = SqlDbType.DateTime
            FechaInicio.Value = DTInicio.Value

            Dim FechaFinal As New SqlClient.SqlParameter()
            FechaFinal.ParameterName = "@fechafin"
            FechaFinal.SqlDbType = SqlDbType.DateTime
            FechaFinal.Value = DTFinal.Value

            da.Parameters.Add(IdProductor)
            da.Parameters.Add(TipoContrato)
            da.Parameters.Add(FechaInicio)
            da.Parameters.Add(FechaFinal)
            Dim dasp_ReporteBoletaEmbarque As New SqlClient.SqlDataAdapter()
            dasp_ReporteBoletaEmbarque.SelectCommand = da
            Dim ds As New DataTable
            dasp_ReporteBoletaEmbarque.Fill(ds)

            CrReport.Load(Ruta)

            CrReport.SetDataSource(ds)

            CrComprasXproductor.ReportSource = CrReport
        Catch ex As Exception
            MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
        End Try
    End Sub
    Private Sub TxContraseña_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTFinal.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim CrReport As RptComprasXproductor = New RptComprasXproductor

                Dim da As New SqlCommand("sp_ReporteCompras", cnn)
                Dim Ruta As String = "\\192.168.10.30\docs_sistemas\RPT_MAIZ\RptComprasXproductor.rpt"
                'Dim Ruta As String = Application.StartupPath & "\RPT\ReporteBoletaEntrada.rpt"
                da.CommandType = CommandType.StoredProcedure
                Dim IdProductor As New SqlClient.SqlParameter()
                IdProductor.ParameterName = "@idproductor"
                IdProductor.SqlDbType = SqlDbType.NVarChar
                IdProductor.Value = IIf(CbProductor.SelectedValue = Nothing, "", CbProductor.SelectedValue)

                Dim TipoContrato As New SqlClient.SqlParameter()
                TipoContrato.ParameterName = "@tipoContrato"
                TipoContrato.SqlDbType = SqlDbType.NVarChar
                TipoContrato.Value = IIf(CbTipoContrato.Text = Nothing, "", CbTipoContrato.Text)

                Dim FechaInicio As New SqlClient.SqlParameter()
                FechaInicio.ParameterName = "@fechaini"
                FechaInicio.SqlDbType = SqlDbType.DateTime
                FechaInicio.Value = DTInicio.Value

                Dim FechaFinal As New SqlClient.SqlParameter()
                FechaFinal.ParameterName = "@fechafin"
                FechaFinal.SqlDbType = SqlDbType.DateTime
                FechaFinal.Value = DTFinal.Value

                da.Parameters.Add(IdProductor)
                da.Parameters.Add(TipoContrato)
                da.Parameters.Add(FechaInicio)
                da.Parameters.Add(FechaFinal)
                Dim dasp_ReporteBoletaEmbarque As New SqlClient.SqlDataAdapter()
                dasp_ReporteBoletaEmbarque.SelectCommand = da
                Dim ds As New DataTable
                dasp_ReporteBoletaEmbarque.Fill(ds)

                CrReport.Load(Ruta)

                CrReport.SetDataSource(ds)

                CrComprasXproductor.ReportSource = CrReport
            Catch ex As Exception
                MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
            End Try
        End If
    End Sub
End Class