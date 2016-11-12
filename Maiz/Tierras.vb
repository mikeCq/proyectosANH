Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class Tierras
    Dim modifica As Integer = 0
    Private Sub Tierras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarcombos()
        BtnNuevo_Click(sender, e)
        bloqueaBotones()
        NuSupTotal.Controls(0).Visible = False
        NuSupCultivable.Controls(0).Visible = False
    End Sub
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        TxIdLote.Text = ""
        TxNoLote.Text = ""
        CBColonia.SelectedIndex = -1
        CBPropietario.SelectedIndex = -1
        TxRfc.Text = ""
        TxCurp.Text = ""
        TxFolio.Text = ""
        NuSupTotal.Value = 0
        NuSupCultivable.Value = 0
        TxVolumen.Text = ""
        TxNGrados.Text = ""
        TxNHoras.Text = ""
        TxNMinutos.Text = ""
        TxWGrados.Text = ""
        TxWHoras.Text = ""
        TxWMinutos.Text = ""
        TxFolioRPP.Text = ""
        TxLibroRPP.Text = ""
        TxFolio.Text = ""
        TxNumeroRPP.Text = ""
        DTRpp.Value = "01/01/1900"
        TxRegimen.Text = ""
        TxTitulo.Text = ""
        DtTitulo.Value = "01/01/1900"
        bloqueaBotones()
        NuSupCultivable.Enabled = True
        NuSupTotal.Enabled = True
        GbEscrituracion.Enabled = True

    End Sub
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If CBColonia.SelectedIndex = -1 Or CBPropietario.SelectedIndex = -1 Or NuSupTotal.Value = 0 Or NuSupCultivable.Value = 0 Or TxNGrados.Text = "" Or TxNHoras.Text = "" Or TxWGrados.Text = "" Or TxWHoras.Text = "" Or TxWMinutos.Text = "" Or TxNumeroRPP.Text = "" Or TxFolioRPP.Text = "" Or TxLibroRPP.Text = "" Or DTRpp.Value = "01/01/1900" Or DtTitulo.Value = "01/01/1900" Then
            MessageBox.Show("Verifica campos en blanco", "Aviso")
        ElseIf LoteRegistrado(TxIdLote.Text) = True And modifica = 0 Then
            MessageBox.Show("Ya existe el lote " + TxIdLote.Text + ".")
        ElseIf LoteRegistrado(TxIdLote.Text) = True And modifica = 1 Then
            ActualizaTierra()
            MessageBox.Show("Lote actualizado con exito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                Dim cmd As New SqlCommand("Sp_InsNueTie", cnn)

                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Consecutivo", generaCodigoTierra(TxIdLote.Text))
                cmd.Parameters.AddWithValue("@Numlote", TxNoLote.Text)
                cmd.Parameters.AddWithValue("@idColonia", CBColonia.SelectedValue)
                cmd.Parameters.AddWithValue("@idCliente", CBPropietario.SelectedValue)
                cmd.Parameters.AddWithValue("@folioLote", TxFolio.Text)
                cmd.Parameters.AddWithValue("@supTotal", NuSupTotal.Value)
                cmd.Parameters.AddWithValue("@supCultivable", NuSupCultivable.Value)
                cmd.Parameters.AddWithValue("@supCultivableRestante", NuSupCultivable.Value)
                cmd.Parameters.AddWithValue("@Volumen", TxVolumen.Text)
                cmd.Parameters.AddWithValue("@latGrados", TxNGrados.Text)
                cmd.Parameters.AddWithValue("@latHoras", TxNHoras.Text)
                cmd.Parameters.AddWithValue("@latMinutos", TxNMinutos.Text)
                cmd.Parameters.AddWithValue("@lonGrados", TxWGrados.Text)
                cmd.Parameters.AddWithValue("@lonHoras", TxWHoras.Text)
                cmd.Parameters.AddWithValue("@lonMinutos", TxWMinutos.Text)
                cmd.Parameters.AddWithValue("@numRpp", TxNumeroRPP.Text)
                cmd.Parameters.AddWithValue("@folioRpp", TxFolioRPP.Text)
                cmd.Parameters.AddWithValue("@libroRpp", TxLibroRPP.Text)
                cmd.Parameters.AddWithValue("@fecjaRpp", DTRpp.Value)
                cmd.Parameters.AddWithValue("@tituloAgua", TxTitulo.Text)
                cmd.Parameters.AddWithValue("@RegimenHidrico", TxRegimen.Text)
                cmd.Parameters.AddWithValue("@fechaTitulo", DtTitulo.Value)
                cmd.Parameters.AddWithValue("@hectareaprometida", 0)
                cmd.Parameters.AddWithValue("@Hectareapromrestante", 0)
                cmd.Parameters.AddWithValue("@rendimiento", 0)

                TxIdLote.Text = cmd.Parameters("@Consecutivo").Value.ToString()

                cmd.ExecuteNonQuery()

                bloqueaBotones()
            Catch ex As Exception
                MsgBox("Error", MsgBoxStyle.Critical)
            End Try

        End If

    End Sub
    Private Sub llenarcombos()
        Dim cmdllenaCbCol As SqlCommand
        Dim da As SqlDataAdapter
        Dim ds As DataSet

        cmdllenaCbCol = New SqlCommand("Sp_CbColonias")
        cmdllenaCbCol.CommandType = CommandType.StoredProcedure
        cmdllenaCbCol.Connection = cnn

        da = New SqlDataAdapter(cmdllenaCbCol)
        ds = New DataSet()
        da.Fill(ds)
        CBColonia.DataSource = ds.Tables(0)
        CBColonia.DisplayMember = "nombre_colonia"
        CBColonia.ValueMember = "Id_colonia"
        CBColonia.SelectedIndex = -1

        Dim cmdllenaCbPro As SqlCommand

        cmdllenaCbPro = New SqlCommand("Sp_CbProductorCl")
        cmdllenaCbPro.CommandType = CommandType.StoredProcedure
        cmdllenaCbPro.Connection = cnn

        da = New SqlDataAdapter(cmdllenaCbPro)
        ds = New DataSet()
        da.Fill(ds)
        CBPropietario.DataSource = ds.Tables(0)
        CBPropietario.DisplayMember = "nombreProductor"
        CBPropietario.ValueMember = "Id_cliente"
        CBPropietario.SelectedIndex = -1
    End Sub
    Private Sub DatosPropietario() Handles CBPropietario.SelectionChangeCommitted
        Dim cmd As New SqlCommand("sp_SeleccionaDatos_productor", cnn)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@IdProductor", CBPropietario.SelectedValue)

        cmd.ExecuteNonQuery()

        Dim da As New SqlDataAdapter(cmd)

        Dim dt As New DataTable

        da.Fill(dt)

        Dim row As DataRow = dt.Rows(0)
        If CStr(row("Tipo_Persona")) = "F" Then
            TxRfc.Text = CStr(row("RFC_Cliente"))
            TxCurp.Text = CStr(row("CURP_Cliente"))
            TxCurp.Visible = True
            Label15.Visible = True
        Else
            TxRfc.Text = CStr(row("RFC_Cliente"))
            TxCurp.Visible = False
            Label15.Visible = False
        End If

    End Sub
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim BuscarTierras As New BuscarTierras
        BuscarTierras.ShowDialog()
        Dim NumLote As Object = BuscarTierras.NumeroLote
        If BuscarTierras.NumeroLote <> Nothing Then
            Dim cmd As New SqlCommand("sp_selecciontierra", cnn)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlClient.SqlParameter("@idtierra", BuscarTierras.NumeroLote))

            Dim da As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)

            Dim row As DataRow = dt.Rows(0)

            TxIdLote.Text = CStr(row("id_tierra"))
            TxNoLote.Text = CStr(row("numero_lote"))
            CBColonia.SelectedValue = CStr(row("colonia"))
            CBPropietario.SelectedValue = CStr(row("id_propietario"))
            TxFolio.Text = CStr(row("folio_lote"))
            NuSupTotal.Value = row("superficie_total")
            NuSupCultivable.Value = row("superficie_cultivable_total")
            TxVolumen.Text = row("volumen")
            TxNGrados.Text = CStr(row("latitud_grados"))
            TxNHoras.Text = CStr(row("latitud_horas"))
            TxNMinutos.Text = CStr(row("latitud_minutos"))
            TxWGrados.Text = CStr(row("longitud_grados"))
            TxWHoras.Text = CStr(row("longitud_horas"))
            TxWMinutos.Text = CStr(row("longitud_minutos"))
            TxNumeroRPP.Text = CStr(row("numero_rpp"))
            TxFolioRPP.Text = CStr(row("folio_rpp"))
            TxLibroRPP.Text = CStr(row("libro_rpp"))
            DTRpp.Value = row("fecha_rpp")
            TxTitulo.Text = CStr(row("titulo_agua"))
            TxRegimen.Text = CStr(row("regimen_hidrico"))
            DtTitulo.Value = row("fecha_titulo_agua")
            DatosPropietario()

        End If
        bloqueaBotones()
    End Sub
    Private Sub bloqueaBotones()
        If TxIdLote.Text = "" And CBPropietario.SelectedValue = Nothing Then
            BtnModificar.Enabled = False
            GbDatos.Enabled = True
        Else
            BtnModificar.Enabled = True
            GbDatos.Enabled = False
        End If
    End Sub
    Private Sub desbloqueabotones()
        If TxIdLote.Text <> "" And CBPropietario.SelectedValue <> Nothing Then
            BtnModificar.Enabled = True
            GbDatos.Enabled = True
            NuSupCultivable.Enabled = False
            NuSupTotal.Enabled = False
            GbEscrituracion.Enabled = False
        End If
    End Sub
    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Dim opc As DialogResult = MessageBox.Show("¿Esta seguro de modificar los datos del registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If opc = DialogResult.Yes Then
            desbloqueabotones()
            modifica = 1
        End If
    End Sub
    Private Sub ActualizaTierra()

        Try
            Dim cmd As New SqlCommand("sp_ActLotes", cnn)

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@idtierra", TxIdLote.Text)
            cmd.Parameters.AddWithValue("@numlote", TxNoLote.Text)
            cmd.Parameters.AddWithValue("@idcolonia", CBColonia.SelectedValue)
            cmd.Parameters.AddWithValue("@idcliente", CBPropietario.SelectedValue)
            cmd.Parameters.AddWithValue("@foliolote", TxFolio.Text)
            cmd.Parameters.AddWithValue("@volumen", TxVolumen.Text)
            cmd.Parameters.AddWithValue("@latgrados", TxNGrados.Text)
            cmd.Parameters.AddWithValue("@lathoras", TxNHoras.Text)
            cmd.Parameters.AddWithValue("@latminutos", TxNMinutos.Text)
            cmd.Parameters.AddWithValue("@longrados", TxWGrados.Text)
            cmd.Parameters.AddWithValue("@lonhoras", TxWHoras.Text)
            cmd.Parameters.AddWithValue("@lonminutos", TxWMinutos.Text)
            cmd.Parameters.AddWithValue("@numrpp", TxNumeroRPP.Text)
            cmd.Parameters.AddWithValue("@foliorpp", TxFolioRPP.Text)
            cmd.Parameters.AddWithValue("@librorpp", TxLibroRPP.Text)
            cmd.Parameters.AddWithValue("@fecjarpp", DTRpp.Value)
            cmd.Parameters.AddWithValue("@tituloagua", TxTitulo.Text)
            cmd.Parameters.AddWithValue("@RegimenHidrico", TxRegimen.Text)
            cmd.Parameters.AddWithValue("@fechatitulo", DtTitulo.Value)

            cmd.ExecuteNonQuery()
            modifica = 0
            bloqueaBotones()
        Catch ex As Exception
            MsgBox("Error ", MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click

        Close()

    End Sub


End Class