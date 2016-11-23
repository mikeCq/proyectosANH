Imports System.Data.SqlClient
Public Class LiquidacionXcomprador
    Dim IdLiquidacionTotal As String
    Dim PrecioContrato As Double
    Dim Moneda As Integer
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
        DesmarcarChecks()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click, Me.FormClosed
        Limpiar()
        Me.Close()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BTNImprimir.Click

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BTNGuardar.Click
        Guardar()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click
        Buscar()
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
        Dim CmdCBEmpresas As SqlCommand
        CmdCBEmpresas = New SqlCommand("sp_CbEmpresas")
        CmdCBEmpresas.CommandType = CommandType.StoredProcedure
        CmdCBEmpresas.Connection = cnn
        da = New SqlDataAdapter(CmdCBEmpresas)
        ds = New DataSet()
        da.Fill(ds)
        CBEmpresa.DataSource = ds.Tables(0)
        CBEmpresa.DisplayMember = "RazonSocial"
        CBEmpresa.ValueMember = "Id_Empresa"
        CBEmpresa.SelectedIndex = -1
        '------LLENAR CBCOMPRADORBL--------
        Dim CmdCBCompradorLB As SqlCommand
        CmdCBCompradorLB = New SqlCommand("sp_cbContratoLiquidacionesVenta")
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
        'CBComprador.SelectedValue = -1
        CBTipoMoneda.SelectedIndex = -1
        DGVSalidasSeleccionadas.Columns.Clear()
        DGVSalidasSeleccionadas.DataSource = Nothing
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
    Private Sub DGVSalidas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVSalidas.CellContentClick
        Dim Contador As Integer
        For Contador = 0 To DGVSalidas.RowCount - 1
            If DGVSalidas.Rows(Contador).Selected Then
                If DGVSalidas.Rows(Contador).Cells("ChCol").Value = False Then
                    DGVSalidas.Rows(Contador).Cells("ChCol").Value = True
                ElseIf DGVSalidas.Rows(Contador).Cells("ChCol").Value = True Then
                    DGVSalidas.Rows(Contador).Cells("ChCol").Value = False
                End If
            End If
        Next Contador
        ContarChecksMarcados()
    End Sub
    Private Sub ContarChecksMarcados()
        Dim PuestosAcumulados As Double
        For Each row As DataGridViewRow In DGVSalidas.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("ChCol").Value)
            If isSelected = True Then
                PuestosAcumulados = PuestosAcumulados + row.Cells("Total").Value.ToString()
            End If
        Next row
        NUDToneladasSeleccionadas.Value = PuestosAcumulados
        PuestosAcumulados = 0
    End Sub
    Private Sub DesmarcarChecks()
        For Contador = 0 To DGVSalidas.RowCount - 1
            If DGVSalidas.Rows(Contador).Cells("ChCol").Value = True Then
                DGVSalidas.Rows(Contador).Cells("ChCol").Value = False
            End If
        Next Contador
    End Sub
    Private Sub Guardar()
        If DGVSalidasSeleccionadas.RowCount = 0 Then
            MessageBox.Show("No hay datos para guardar.")
        ElseIf NUDToneladasSeleccionadas.Value = NUDTotalLiquidar.Value Then
            IdLiquidacionTotal = ""
            Dim Contador As Integer
            IdLiquidacionTotal = generaCodigoVenta(IdLiquidacionTotal)
            For Contador = 0 To DGVSalidasSeleccionadas.RowCount - 1
                Dim CodigoLiquidacion As String = ""
                Dim cmd1 As New SqlCommand("sp_InsertarVentaResumen", cnn)
                cmd1.CommandType = CommandType.StoredProcedure
                cmd1.Parameters.Clear()
                cmd1.Parameters.AddWithValue("@IdVentaComprador", generaCodigoVentaResumen(CodigoLiquidacion))
                cmd1.Parameters.AddWithValue("@idSalida", DGVSalidasSeleccionadas.Rows(Contador).Cells("IdSalida").Value.ToString)
                cmd1.Parameters.AddWithValue("@numeroBoleta", DGVSalidasSeleccionadas.Rows(Contador).Cells("numeroBoleta").Value)
                cmd1.Parameters.AddWithValue("@IdComprador", DGVSalidasSeleccionadas.Rows(Contador).Cells("IdComprador").Value.ToString())
                cmd1.Parameters.AddWithValue("@NombreComprador", TBIdComprador.Text)
                cmd1.Parameters.AddWithValue("@grupoGrano", DGVSalidasSeleccionadas.Rows(Contador).Cells("grupoGrano").Value.ToString())
                cmd1.Parameters.AddWithValue("@Neto", (CDbl(DGVSalidasSeleccionadas.Rows(Contador).Cells("Neto").Value)) / 1000)
                cmd1.Parameters.AddWithValue("@deduccion", (CDbl(DGVSalidasSeleccionadas.Rows(Contador).Cells("Deducciones").Value)) / 1000)
                cmd1.Parameters.AddWithValue("@Total", (CDbl(DGVSalidasSeleccionadas.Rows(Contador).Cells("Total").Value)) / 1000)
                cmd1.Parameters.AddWithValue("@moneda", CBTipoMoneda.Text)
                cmd1.Parameters.AddWithValue("@IdVentaTotalComprador", IdLiquidacionTotal)

                cmd1.ExecuteNonQuery()

            Next Contador
            DGVSalidasSeleccionadas.Columns.Clear()

            For Contador = 0 To DGVSalidas.RowCount - 1
                If DGVSalidas.Rows(Contador).Cells("ChCol").Value = True Then
                    Dim cmd2 As New SqlCommand("sp_ActTotalComprador", cnn)

                    cmd2.CommandType = CommandType.StoredProcedure

                    cmd2.Parameters.AddWithValue("@idSalida", DGVSalidas.Rows(Contador).Cells("IdSalida").Value.ToString)
                    cmd2.Parameters.AddWithValue("@TotalXliquidar", (CDbl(DGVSalidas.Rows(Contador).Cells("Total").Value)) / 1000)
                    cmd2.ExecuteNonQuery()
                End If
            Next Contador

            DGVSalidas.Columns.Clear()
            DGVSalidas.DataSource = Nothing

            LlenarDGVsalidas()
            PropiedadesDGVSalidas()

            Dim cmd4 As New SqlCommand("sp_InsertarVentaTotal", cnn)

            Dim TipoCambio, precioXTonMn, ImporteMn As Double
            TipoCambio = CDbl(IIf(TBTipoDeCambio.Text = "", 0, TBTipoDeCambio.Text))
            precioXTonMn = TBPrecioPorTonelada.Text
            ImporteMn = CDbl(TBImporte.Text)

            cmd4.CommandType = CommandType.StoredProcedure

            cmd4.Parameters.AddWithValue("@IdVentaTotalComprador", IdLiquidacionTotal)

            cmd4.Parameters.AddWithValue("@IdContratoVenta", TBIdContrato.Text)

            cmd4.Parameters.AddWithValue("@Idcomprador", TBIdComprador.Text)

            cmd4.Parameters.AddWithValue("@GrupoGrano", "AMARILLO")

            cmd4.Parameters.AddWithValue("@FechaVenta", Now)

            cmd4.Parameters.AddWithValue("@TotalVentaContrato", (NUDTotalLiquidar.Value / 1000))

            cmd4.Parameters.AddWithValue("@TipoDeCambio", TipoCambio)

            cmd4.Parameters.AddWithValue("@PrecioContrato", PrecioContrato)

            cmd4.Parameters.AddWithValue("@Moneda", CBTipoMoneda.SelectedValue)

            cmd4.Parameters.AddWithValue("@PrecioToneladaMxn", TBPrecioPorTonelada.Text)

            cmd4.Parameters.AddWithValue("@ImporteTotal", ImporteMn)

            cmd4.Parameters.AddWithValue("@Contrato", TBContrato.Text)

            cmd4.Parameters.AddWithValue("@MetodoPago", TBMetodoPago.Text)

            cmd4.Parameters.AddWithValue("@Banco", TBBanco.Text)

            cmd4.Parameters.AddWithValue("@UltimosDigitos", TBUltimosDigitos.Text)

            cmd4.Parameters.AddWithValue("@ImporteLetra", UCase(letras(TBImporte.Text)))

            cmd4.Parameters.AddWithValue("@IdEmpresa", CBEmpresa.SelectedValue)

            cmd4.Parameters.AddWithValue("@IdTipoLiquidacion", IIf(RBTNSi.Checked = True, 0, 1))

            cmd4.ExecuteNonQuery()
            EstatusContrato()


        Else
            MessageBox.Show("Las toneladas de boletas seleccionadas no coinciden con el total a liquidar, favor de verificar.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        '-___-CbMonedaVerificar()
        '--LimpiarGuardar()
    End Sub
    Private Sub Buscar()
        Dim BuscarCompradorLiquidacionVenta As New BuscarCompradorLiquidacionVenta
        BuscarCompradorLiquidacionVenta.ShowDialog()
        Dim CodigoComprador As Object = BuscarCompradorLiquidacionVenta.CodigoVenta
        Dim cmd As New SqlCommand("sp_DatosContratoVenta", cnn)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlClient.SqlParameter("@IdContratoVenta", BuscarCompradorLiquidacionVenta.CodigoVenta))

        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim dt As New DataSet()
        da.Fill(dt)

        TBIdContrato.Text = CStr(dt.Tables(0).Rows(0)("id_contratoV").ToString())
        TBIdComprador.Text = CStr(dt.Tables(0).Rows(0)("id_comprador").ToString())
        TBNombreComprador.Text = CStr(dt.Tables(0).Rows(0)("Nombre_Comprador").ToString())
        NUDToneladasContrato.Value = CDbl(dt.Tables(0).Rows(0)("toneladasVentas").ToString())
        NUDToneladasRestantes.Value = CDbl(dt.Tables(0).Rows(0)("toneladasrestantes").ToString())
        PrecioContrato = CDbl(dt.Tables(0).Rows(0)("precioXtonelada").ToString())
        TbEstatusContrato.Text = IIf(dt.Tables(0).Rows(0)("EstatusContrato").ToString() = 0, "INCOMPLETO", "COMPLETO")
        Moneda = dt.Tables(0).Rows(0)("moneda").ToString()
        If dt.Tables(0).Rows(0)("TipoContrato").ToString() = 0 Then
            RBTNSi.Checked = True
        Else
            RBTNNo.Checked = True
        End If


        Dim cmd3 As New SqlCommand("sp_LlenaDGVTotalLiquidado", cnn)

        cmd3.CommandType = CommandType.StoredProcedure
        cmd3.Parameters.Add(New SqlClient.SqlParameter("@IdComprador", TBIdComprador.Text))

        Dim da3 As New SqlClient.SqlDataAdapter(cmd3)
        Dim dt3 As New DataSet()
        da3.Fill(dt3)
        Dim BanderaContrato As Integer
        If (dt3.Tables(0).Rows.Count = 0) Then

            BanderaContrato = 0
        Else
            BanderaContrato = dt.Tables(0).Rows(0)("EstatusContrato")
        End If
        If dt3.Tables(0).Rows.Count <> 0 Then
            TBNombreComprador.Text = dt3.Tables(0).Rows(0)("NombreComprador").ToString()
        Else
            TBNombreComprador.Text = dt.Tables(0).Rows(0)("NombreComprador").ToString()
        End If
        If BanderaContrato = 1 Then
            '    If RbNo.Checked = True Then
            '        RbContrato.Checked = True
            '        RbContrato.Enabled = True
            '        RbLibre.Checked = False
            '        RbLibre.Enabled = True
            '    Else
            '        RbContrato.Enabled = False
            '        RbLibre.Enabled = True
            '        RbContrato.Checked = False
            '        RbLibre.Checked = True
            '    End If
            'Else
            '    If RbSi.Checked = True Then
            '        RbContrato.Enabled = True
            '        RbLibre.Enabled = True
            '        RbContrato.Checked = True
            '        RbLibre.Checked = False
            '    Else
            '        RbContrato.Enabled = True
            '        RbLibre.Enabled = False
            '        RbContrato.Checked = True
            '        RbLibre.Checked = False
            '    End If
        End If
        DGVTotalLiquidado.DataSource = dt3.Tables(0).DefaultView
    End Sub
    Private Sub EstatusContrato()
        Dim IdEstatusContrato As Integer
        Dim cmd As New SqlCommand("sp_ActEstatusContratoVenta", cnn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Clear()
        cmd.Parameters.Add(New SqlClient.SqlParameter("@IdEstatusContrato", 0))
        cmd.Parameters.Add(New SqlClient.SqlParameter("@contrato", IdLiquidacionTotal))
        cmd.Parameters.Add(New SqlClient.SqlParameter("@sumapagado", NUDTotalLiquidar.Value))
        cmd.Parameters("@IdEstatusContrato").Direction = ParameterDirection.InputOutput
        cmd.ExecuteNonQuery()
        IdEstatusContrato = cmd.Parameters("@IdEstatusContrato").Value
        If IdEstatusContrato = 1 Then
            TbEstatusContrato.Text = "COMPLETO"
        Else
            TbEstatusContrato.Text = "INCOMPLETO"
        End If
    End Sub
    Private Sub TBNombreComprador_TextChanged(sender As Object, e As EventArgs) Handles TBNombreComprador.TextChanged

    End Sub

    Private Sub NUDToneladasContrato_ValueChanged(sender As Object, e As EventArgs) Handles NUDToneladasContrato.ValueChanged

    End Sub

    Private Sub NUDToneladasRestantes_ValueChanged(sender As Object, e As EventArgs) Handles NUDToneladasRestantes.ValueChanged

    End Sub

    Private Sub TbEstatusContrato_TextChanged(sender As Object, e As EventArgs) Handles TbEstatusContrato.TextChanged

    End Sub


End Class