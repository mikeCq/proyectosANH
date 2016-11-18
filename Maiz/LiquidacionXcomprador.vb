Imports System.Data.SqlClient
Public Class LiquidacionXcomprador
    Private Sub LiquidacionXcomprador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarComboBox()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BTNNuevo.Click
        TBTipoDeCambio.Text = ""
        NUDPrecioContrato.Value = 0.00
        CBTipoMoneda.SelectedValue = -1
        TBPrecioPorTonelada.Text = ""
        TBImporte.Text = ""
        NUDToneladasSeleccionadas.Value = 0.00
        NUDTotalLiquidar.Value = 0.00
        CBComprador.SelectedValue = -1
        TBContrato.Text = ""
        CBTipoMoneda.SelectedIndex = -1
        '---PESTAÑA DE LIQUIDACION-------------------
        TBTipoDeCambioBL.Text = ""
        NUDPrecioContratoBL.Value = 0.00
        NUDTotalLiquidadoBL.Value = 0.00
        CBTipoMonedaBL.SelectedIndex = -1
        TBPrecioPorToneladaBL.Text = ""
        TBImporteBL.Text = ""
        CBCompradorBL.SelectedValue = -1
        TBContratoBL.Text = ""
        TBMetodoPagoBL.Text = ""
        TBBancoBL.Text = ""
        TBUltimosDigitosBL.Text = ""
        RBTNContratoBL.Checked = False
        RBTNLibreBL.Checked = False
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BTNImprimir.Click

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BTNGuardar.Click

    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click

    End Sub
    Private Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click

    End Sub
    '--------------METODOS---------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub LlenarComboBox()
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        '------LLENAR CBTIPOMONEDA--------
        CBTipoMoneda.SelectedIndex = -1
        CBTipoMoneda.Items.Add("DLS")
        CBTipoMoneda.Items.Add("MXN")
        '------LLENAR CBTIPOMONEDABL--------
        CBTipoMonedaBL.SelectedIndex = -1
        CBTipoMonedaBL.Items.Add("DLS")
        CBTipoMonedaBL.Items.Add("MXN")
        '------LLENAR CBCOMPRADOR--------
        Dim CmdCBComprador As SqlCommand
        CmdCBComprador = New SqlCommand("sp_cbCompradoresContrato")
        CmdCBComprador.CommandType = CommandType.StoredProcedure
        CmdCBComprador.Connection = cnn
        da = New SqlDataAdapter(CmdCBComprador)
        ds = New DataSet()
        da.Fill(ds)
        CBComprador.DataSource = ds.Tables(0)
        CBComprador.DisplayMember = "Nombre_Comprador"
        CBComprador.ValueMember = "Id_Comprador"
        CBComprador.SelectedIndex = -1
        '------LLENAR CBCOMPRADORBL--------
        Dim CmdCBCompradorLB As SqlCommand
        CmdCBCompradorLB = New SqlCommand("sp_cbCompradoresContrato")
        CmdCBCompradorLB.CommandType = CommandType.StoredProcedure
        CmdCBCompradorLB.Connection = cnn
        da = New SqlDataAdapter(CmdCBCompradorLB)
        ds = New DataSet()
        da.Fill(ds)
        CBCompradorBL.DataSource = ds.Tables(0)
        CBCompradorBL.DisplayMember = "Nombre_Comprador"
        CBCompradorBL.ValueMember = "Id_Comprador"
        CBCompradorBL.SelectedIndex = -1
    End Sub
End Class