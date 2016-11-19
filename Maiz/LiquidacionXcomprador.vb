Imports System.Data.SqlClient
Public Class LiquidacionXcomprador
    Private Sub LiquidacionXcomprador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarComboBox()
        LlenarDGVsalidas()
        PropiedadesDGVSalidas()
    End Sub
    Private Sub PropiedadesDGVSalidas()
        If DGVSalidas.Columns("ChCol") Is Nothing Then
            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
            checkBoxColumn.HeaderText = ""
            checkBoxColumn.Width = 40
            checkBoxColumn.Name = "ChCol"
            DGVSalidas.Columns.Insert(11, checkBoxColumn)
        End If
        DGVSalidas.Columns("id_salida").Visible = False
        DGVSalidas.Columns("id_empresa").Visible = False
        DGVSalidas.Columns("razonsocial").Visible = False
        DGVSalidas.Columns("bruto").Visible = False
        DGVSalidas.Columns("Tara").Visible = False

        DGVSalidas.Columns("Total").ReadOnly = False

        DGVSalidas.Columns("Neto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVSalidas.Columns("Deducciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVSalidas.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DGVSalidas.Columns("Bruto").DefaultCellStyle.Format = "###,##0.00"
        DGVSalidas.Columns("Tara").DefaultCellStyle.Format = "###,##0.00"
        DGVSalidas.Columns("Neto").DefaultCellStyle.Format = "###,##0.00"
        DGVSalidas.Columns("Deducciones").DefaultCellStyle.Format = "###,##0.00"
        DGVSalidas.Columns("Total").DefaultCellStyle.Format = "###,##0.00"
    End Sub
    Private Sub PropiedadesDGVSalidasSeleccionadas()
        Dim DGVTBCIdSalida As New DataGridViewTextBoxColumn
        DGVTBCIdSalida.Name = "id_salida"
        DGVTBCIdSalida.Visible = False
        DGVSalidasSeleccionadas.Columns.Insert(0, DGVTBCIdSalida)

        Dim DGVTBCIdBoleta As New DataGridViewTextBoxColumn
        DGVTBCIdBoleta.Name = "numeroBoleta"
        DGVTBCIdBoleta.HeaderText = "Boleta"
        DGVTBCIdBoleta.Width = 50
        DGVSalidasSeleccionadas.Columns.Insert(1, DGVTBCIdBoleta)

        Dim DGVTBCIdEmpresa As New DataGridViewTextBoxColumn
        DGVTBCIdEmpresa.Name = "id_empresa"
        DGVTBCIdEmpresa.Visible = False
        DGVSalidasSeleccionadas.Columns.Insert(2, DGVTBCIdEmpresa)

        Dim DGVTBCFecha As New DataGridViewTextBoxColumn
        DGVTBCFecha.HeaderText = "Fecha"
        DGVTBCFecha.Width = 70
        DGVTBCFecha.Name = "Fecha_Pesaje"
        DGVTBCFecha.Visible = False
        DGVSalidasSeleccionadas.Columns.Insert(3, DGVTBCFecha)

        Dim DGVTBCGrano As New DataGridViewTextBoxColumn()
        DGVTBCGrano.HeaderText = "Grano"
        DGVTBCGrano.Width = 75
        DGVTBCGrano.Name = "grupoGrano"
        DGVSalidasSeleccionadas.Columns.Insert(4, DGVTBCGrano)

        Dim DGVTBCNeto As New DataGridViewTextBoxColumn()
        DGVTBCNeto.HeaderText = "Neto"
        DGVTBCNeto.Width = 65
        DGVTBCNeto.Name = "Neto"
        DGVSalidasSeleccionadas.Columns.Insert(5, DGVTBCNeto)

        Dim DGVTBCDeducciones As New DataGridViewTextBoxColumn()
        DGVTBCDeducciones.HeaderText = "Deducciones"
        DGVTBCDeducciones.Width = 60
        DGVTBCDeducciones.Name = "Deducciones"
        DGVSalidasSeleccionadas.Columns.Insert(6, DGVTBCDeducciones)

        Dim DGVTBCTotal As New DataGridViewTextBoxColumn()
        DGVTBCTotal.HeaderText = "Total"
        DGVTBCTotal.Width = 70
        DGVTBCTotal.Name = "Total"
        DGVSalidasSeleccionadas.Columns.Insert(7, DGVTBCTotal)

        DGVSalidasSeleccionadas.Columns("Neto").DefaultCellStyle.Format = "###,##0.00"
        DGVSalidasSeleccionadas.Columns("Deducciones").DefaultCellStyle.Format = "###,##0.00"
        DGVSalidasSeleccionadas.Columns("Total").DefaultCellStyle.Format = "###,##0.00"

        DGVSalidasSeleccionadas.Columns("Neto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVSalidasSeleccionadas.Columns("Deducciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVSalidasSeleccionadas.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BTNNuevo.Click
        Limpiar()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click, Me.FormClosed
        Limpiar()
        Me.Close()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BTNImprimir.Click

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BTNGuardar.Click

    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click

    End Sub
    Private Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click
        Agregar()
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
    Private Sub Limpiar()
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
        CBTipoMoneda.Items.Clear()
        CBTipoMonedaBL.Items.Clear()
    End Sub
    Private Sub LlenarDGVsalidas()
        Dim cmd As New SqlCommand("sp_llenarDgvSalidas", cnn)
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim dt As New DataSet()
        da.Fill(dt)
        DGVSalidas.DataSource = dt.Tables(0).DefaultView
    End Sub
    Private Sub Agregar()
        DGVSalidasSeleccionadas.Columns.Clear()
        DGVSalidasSeleccionadas.DataSource = Nothing
        PropiedadesDGVSalidasSeleccionadas()
        Dim Contador As Integer
        For Contador = 0 To DGVSalidas.RowCount - 1
            If DGVSalidas.Rows(Contador).Cells("ChCol").Value = True Then
                DGVSalidasSeleccionadas.Rows.Add(DGVSalidas.Rows(Contador).Cells("id_salida").Value.ToString(), DGVSalidas.Rows(Contador).Cells("numeroBoleta").Value, DGVSalidas.Rows(Contador).Cells("id_Empresa").Value.ToString(), DGVSalidas.Rows(Contador).Cells("Fecha_Pesaje").Value, DGVSalidas.Rows(Contador).Cells("grupoGrano").Value.ToString(), DGVSalidas.Rows(Contador).Cells("Neto").Value, DGVSalidas.Rows(Contador).Cells("Deducciones").Value, DGVSalidas.Rows(Contador).Cells("Total").Value)
            End If
        Next Contador
        Dim PuestosAcumulados As Double
        For Contador = 0 To DGVSalidasSeleccionadas.RowCount - 1
            PuestosAcumulados = PuestosAcumulados + DGVSalidasSeleccionadas.Rows(Contador).Cells("Total").Value
        Next Contador
        NUDTotalLiquidar.Value = PuestosAcumulados
        PuestosAcumulados = 0
    End Sub
End Class