Imports System.Data.SqlClient
Public Class ReporteEstatusContrato
    Private Sub BtGenerarReporte_Click(sender As Object, e As EventArgs) Handles BtGenerarReporte.Click
        Dim RPTEstatusContrato As New RPTEstatusContrato
        RPTEstatusContrato.SetDatabaseLogon(VarGlob.UserDB, VarGlob.PasswordDB, VarGlob.ServerDB, VarGlob.DataBase)
        RPTEstatusContrato.SetParameterValue("@IdCliente", CBComprador.SelectedValue)
        RPTEstatusContrato.SetParameterValue("@IdEstatus", CBEstatusContrato.SelectedValue)
        CREstatusContrato.ReportSource = RPTEstatusContrato
    End Sub

    Private Sub ReporteEstatusContrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
    End Sub
    Private Sub llenarCombos()
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        Dim cmdllenaCbPro As SqlCommand
        cmdllenaCbPro = New SqlCommand("sp_NombreClientes")
        cmdllenaCbPro.CommandType = CommandType.StoredProcedure
        cmdllenaCbPro.Connection = cnn
        da = New SqlDataAdapter(cmdllenaCbPro)
        ds = New DataSet()
        da.Fill(ds)
        CBComprador.DataSource = ds.Tables(0)
        CBComprador.DisplayMember = "Nombre"
        CBComprador.ValueMember = "Id_Cliente"
        CBComprador.SelectedIndex = -1

        CBEstatusContrato.Items.Add("COMPLETO")
        CBEstatusContrato.Items.Add("INCOMPLETO")
    End Sub
End Class