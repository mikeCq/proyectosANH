Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class ReporteProductores
    Private Sub ReporteProductores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CRentradas.ReportSource = Nothing
        CRentradas.Refresh()
        TxNumBoleta.Select()
        limpiarCampos()
        llenarCombos()
    End Sub
    Private Sub llenarCombos()
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        Dim cmdllenaCbPro As SqlCommand

        cmdllenaCbPro = New SqlCommand("Sp_CbProductorEntradasReporte")
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
            Dim RptEntradas As New ReporteEntradas
            If DTInicio.Value <= DTFinal.Value And DTFinal.Value >= DTInicio.Value Then
                Dim CrReport As ReporteEntradas = New ReporteEntradas

                Dim da As New SqlCommand("sp_reporteEntradas", cnn)
                Dim Ruta As String = "\\192.168.10.30\docs_sistemas\RPT_MAIZ\ReporteEntradas.rpt"
                da.CommandType = CommandType.StoredProcedure
                Dim NumBoleta As New SqlClient.SqlParameter()
                NumBoleta.ParameterName = "@NumBoleta"
                NumBoleta.SqlDbType = SqlDbType.NVarChar
                NumBoleta.Value = TxNumBoleta.Text

                Dim Productor As New SqlClient.SqlParameter()
                Productor.ParameterName = "@Productor"
                Productor.SqlDbType = SqlDbType.NVarChar
                Productor.Value = IIf(CbProductor.SelectedValue = Nothing, "", CbProductor.SelectedValue)

                Dim FechaIni As New SqlClient.SqlParameter()
                FechaIni.ParameterName = "@Fechaini"
                FechaIni.SqlDbType = SqlDbType.Date
                FechaIni.Value = DTInicio.Value

                Dim FechaFin As New SqlClient.SqlParameter()
                FechaFin.ParameterName = "@FechaFin"
                FechaFin.SqlDbType = SqlDbType.Date
                FechaFin.Value = DTFinal.Value

                da.Parameters.Add(NumBoleta)
                da.Parameters.Add(Productor)
                da.Parameters.Add(FechaIni)
                da.Parameters.Add(FechaFin)

                Dim dasp_ReporteBoletaEmbarque As New SqlClient.SqlDataAdapter()
                dasp_ReporteBoletaEmbarque.SelectCommand = da
                Dim ds As New DataTable
                dasp_ReporteBoletaEmbarque.Fill(ds)

                CrReport.Load(Ruta)

                CrReport.SetDataSource(ds)

                CRentradas.ReportSource = CrReport
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
                Dim RptEntradas As New ReporteEntradas
                If DTInicio.Value <= DTFinal.Value And DTFinal.Value >= DTInicio.Value Then
                    Dim CrReport As ReporteEntradas = New ReporteEntradas

                    Dim da As New SqlCommand("sp_reporteEntradas", cnn)
                    Dim Ruta As String = "\\192.168.10.30\docs_sistemas\RPT_MAIZ\ReporteEntradas.rpt"
                    da.CommandType = CommandType.StoredProcedure
                    Dim NumBoleta As New SqlClient.SqlParameter()
                    NumBoleta.ParameterName = "@NumBoleta"
                    NumBoleta.SqlDbType = SqlDbType.NVarChar
                    NumBoleta.Value = TxNumBoleta.Text

                    Dim Productor As New SqlClient.SqlParameter()
                    Productor.ParameterName = "@Productor"
                    Productor.SqlDbType = SqlDbType.NVarChar
                    Productor.Value = IIf(CbProductor.SelectedValue = Nothing, "", CbProductor.SelectedValue)

                    Dim FechaIni As New SqlClient.SqlParameter()
                    FechaIni.ParameterName = "@Fechaini"
                    FechaIni.SqlDbType = SqlDbType.Date
                    FechaIni.Value = DTInicio.Value

                    Dim FechaFin As New SqlClient.SqlParameter()
                    FechaFin.ParameterName = "@FechaFin"
                    FechaFin.SqlDbType = SqlDbType.Date
                    FechaFin.Value = DTFinal.Value

                    da.Parameters.Add(NumBoleta)
                    da.Parameters.Add(Productor)
                    da.Parameters.Add(FechaIni)
                    da.Parameters.Add(FechaFin)

                    Dim dasp_ReporteBoletaEmbarque As New SqlClient.SqlDataAdapter()
                    dasp_ReporteBoletaEmbarque.SelectCommand = da
                    Dim ds As New DataTable
                    dasp_ReporteBoletaEmbarque.Fill(ds)

                    CrReport.Load(Ruta)

                    CrReport.SetDataSource(ds)

                    CRentradas.ReportSource = CrReport
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