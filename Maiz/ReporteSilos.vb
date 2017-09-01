Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class ReporteSilos
    Private Sub ReporteSilos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CrSilos.ReportSource = Nothing
        CrSilos.Refresh()
        llenarCombos()
    End Sub
    Private Sub llenarCombos()

        Dim da As SqlDataAdapter
        Dim ds As DataSet

        Dim cmdllenaCbSil As SqlCommand

        cmdllenaCbSil = New SqlCommand("Sp_CbAcopio")
        cmdllenaCbSil.CommandType = CommandType.StoredProcedure
        cmdllenaCbSil.Connection = cnn

        da = New SqlDataAdapter(cmdllenaCbSil)
        ds = New DataSet()
        da.Fill(ds)
        CbAcopio.DataSource = ds.Tables(0)
        CbAcopio.DisplayMember = "NombreCentro"
        CbAcopio.ValueMember = "Id_CentroAcopio"
        CbAcopio.SelectedIndex = -1
    End Sub
    Private Sub seleccionarAlmacenXacopio() Handles CbAcopio.SelectionChangeCommitted

        Dim cmdllenaCbAlm As SqlCommand
        Dim da As SqlDataAdapter
        Dim ds As DataSet

        cmdllenaCbAlm = New SqlCommand("Sp_CbAlmacen")
        cmdllenaCbAlm.CommandType = CommandType.StoredProcedure
        cmdllenaCbAlm.Parameters.Add(New SqlClient.SqlParameter("@idacopio", CbAcopio.SelectedValue))
        cmdllenaCbAlm.Connection = cnn

        da = New SqlDataAdapter(cmdllenaCbAlm)
        ds = New DataSet()
        da.Fill(ds)
        CbAlmacen.DataSource = ds.Tables(0)
        CbAlmacen.DisplayMember = "nombre_almacen"
        CbAlmacen.ValueMember = "id_almacen"
        CbAlmacen.SelectedIndex = -1
    End Sub
    Private Sub limpiar()
        RbEntradas.Checked = False
        RbSalidas.Checked = False
        CbAcopio.SelectedIndex = -1
        CbAcopio.Text = ""
        CbAlmacen.SelectedIndex = -1
        CbAlmacen.Text = ""
        DTInicio.Value = "01/01/2000"
        DTFinal.Value = "01/01/2000"
    End Sub

    Private Sub Btlimpiar_Click(sender As Object, e As EventArgs) Handles Btlimpiar.Click
        limpiar()
    End Sub

    Private Sub BtGenerarReporte_Click(sender As Object, e As EventArgs) Handles BtGenerarReporte.Click
        Try
            Dim RptSilos As New RPTSilos
            If DTInicio.Value <= DTFinal.Value And DTFinal.Value >= DTInicio.Value Then
                RptSilos.SetDatabaseLogon(VarGlob.UserDB, VarGlob.PasswordDB, VarGlob.ServerDB, VarGlob.DataBase)
                RptSilos.SetParameterValue("@IdTipo", IIf(RbEntradas.Checked = True, "ENT", "SAL"))
                RptSilos.SetParameterValue("@idAcopio", CbAcopio.SelectedValue)
                RptSilos.SetParameterValue("@idAlmacen", CbAlmacen.SelectedValue)
                RptSilos.SetParameterValue("@FechaInicio", DTInicio.Value)
                RptSilos.SetParameterValue("@FechaFinal", DTFinal.Value)
                CrSilos.ReportSource = RptSilos
            Else
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final, ni la fecha final, menor que la fecha inicial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                limpiar()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class