Imports System.Data.SqlClient
Public Class ReporteEstatusContrato
    Private Sub ReporteEstatusContrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
        CREstatusContrato.ReportSource = Nothing
        CREstatusContrato.Refresh()
    End Sub
    Private Sub BtGenerarReporte_Click(sender As Object, e As EventArgs) Handles BtGenerarReporte.Click
        Dim RPTEstatusContrato As New RPTEstatusContrato
        If CBEstatusContrato.Text = "" Then
            MessageBox.Show("Seleccione un estatus.", "Aviso")
        Else

            Dim CrReport As RPTEstatusContrato = New RPTEstatusContrato

            Dim da As New SqlCommand("sp_ReporteEstatusContrato", cnn)
            Dim Ruta As String = "\\192.168.10.30\docs_sistemas\RPT_MAIZ\RPTEstatusContrato.rpt"
            'Dim Ruta As String = Application.StartupPath & "\RPT\ReporteBoletaEntrada.rpt"
            da.CommandType = CommandType.StoredProcedure
            Dim Estatus As New SqlClient.SqlParameter()
            Estatus.ParameterName = "@IdEstatus"
            Estatus.SqlDbType = SqlDbType.Int
            Estatus.Value = CBEstatusContrato.SelectedValue


            da.Parameters.Add(Estatus)
            Dim dasp_ReporteBoletaEmbarque As New SqlClient.SqlDataAdapter()
            dasp_ReporteBoletaEmbarque.SelectCommand = da
            Dim ds As New DataTable
            dasp_ReporteBoletaEmbarque.Fill(ds)

            CrReport.Load(Ruta)

            CrReport.SetDataSource(ds)

            CREstatusContrato.ReportSource = CrReport
        End If

    End Sub
    Private Sub llenarCombos()
        Dim da As SqlDataAdapter
        Dim ds As DataSet

        Dim cmdllenaEstatus As SqlCommand
        cmdllenaEstatus = New SqlCommand("SP_CBESTATUS")
        cmdllenaEstatus.CommandType = CommandType.StoredProcedure
        cmdllenaEstatus.Connection = cnn
        da = New SqlDataAdapter(cmdllenaEstatus)
        ds = New DataSet()
        da.Fill(ds)
        CBEstatusContrato.DataSource = ds.Tables(0)
        CBEstatusContrato.DisplayMember = "ESTATUS"
        CBEstatusContrato.ValueMember = "ID"
        CBEstatusContrato.SelectedIndex = -1
    End Sub

    Private Sub Btlimpiar_Click(sender As Object, e As EventArgs) Handles Btlimpiar.Click
        CBEstatusContrato.Text = ""
        CBEstatusContrato.SelectedIndex = -1
        CREstatusContrato.ReportSource = Nothing
        CREstatusContrato.Refresh()
    End Sub

End Class