Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Text.RegularExpressions
Public Class Compradores
    Dim modifica As Integer = 0
    Private Sub Compradores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
        BtnNuevo_Click(sender, e)
        Desbloquear()
        BtnGuardar.Visible = True
        BtnModificar.Visible = False
    End Sub
    Private Sub Desbloquear()
        'If TxIdComprador.Text = "" Then
        '    GBCompradores.Enabled = True
        'Else
        '    GBCompradores.Enabled = False
        'End If
        TxNombre.Enabled = True
        TxRfc.Enabled = True
        TxCalle.Enabled = True
        TxNumero.Enabled = True
        CbColonia.Enabled = True
        CbCiudad.Enabled = True
        TxEstado.Enabled = True
        TxCpostal.Enabled = True
        TxContacto.Enabled = True
        TxTelefono.Enabled = True
        TxCelular.Enabled = True
        TxCorreo.Enabled = True
    End Sub
    Private Sub Bloquear()
        'If TxIdComprador.Text = "" Then
        '    GBCompradores.Enabled = True
        'Else
        '    GBCompradores.Enabled = False
        'End If
        TxNombre.Enabled = False
        TxRfc.Enabled = False
        TxCalle.Enabled = False
        TxNumero.Enabled = False
        CbColonia.Enabled = False
        CbCiudad.Enabled = False
        TxEstado.Enabled = False
        TxCpostal.Enabled = False
        TxContacto.Enabled = False
        TxTelefono.Enabled = False
        TxCelular.Enabled = False
        TxCorreo.Enabled = False
    End Sub
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If TxNombre.Text = "" Or TxRfc.Text = "" Or TxCalle.Text = "" Then
            MessageBox.Show("Verifica campos en blanco", "Aviso")
        Else
            Try
                Dim cmd As New SqlCommand("Sp_InsNueCom", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                If TxIdComprador.Text Is String.Empty Then
                    TxIdComprador.Text = generaIDComprador(TxIdComprador.Text)
                End If
                cmd.Parameters.AddWithValue("@Consecutivo", TxIdComprador.Text)
                cmd.Parameters.AddWithValue("@NomCom", TxNombre.Text)
                cmd.Parameters.AddWithValue("@rfc_comprador", TxRfc.Text)
                cmd.Parameters.AddWithValue("@calle_comprador", TxCalle.Text)
                cmd.Parameters.AddWithValue("@num_dom", TxNumero.Text)
                cmd.Parameters.AddWithValue("@colonia_comprador", UCase(CbColonia.Text))
                cmd.Parameters.AddWithValue("@Ciudad_comprador", UCase(CbCiudad.Text))
                cmd.Parameters.AddWithValue("@estado_comprador", UCase(TxEstado.Text))
                cmd.Parameters.AddWithValue("@codigo_postal", TxCpostal.Text)
                cmd.Parameters.AddWithValue("@persona_contacto", TxContacto.Text)
                cmd.Parameters.AddWithValue("@telefono_comprador", TxTelefono.Text)
                cmd.Parameters.AddWithValue("@celular_comprador", TxCelular.Text)
                cmd.Parameters.AddWithValue("@correo_electronico", TxCorreo.Text)
                TxIdComprador.Text = cmd.Parameters("@Consecutivo").Value.ToString()
                cmd.ExecuteNonQuery()
                'controlBloqueo()               
            Catch ex As Exception
                MsgBox("Error", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub



    Private Sub actualizaComprador()
        Dim cmd As New SqlCommand("Sp_InsNueCom", cnn)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Consecutivo", TxIdComprador.Text)
        cmd.Parameters.AddWithValue("@NomCom", TxNombre.Text)
        cmd.Parameters.AddWithValue("@rfc_comprador", TxRfc.Text)
        cmd.Parameters.AddWithValue("@calle_comprador", TxCalle.Text)
        cmd.Parameters.AddWithValue("@num_dom", TxNumero.Text)
        cmd.Parameters.AddWithValue("@colonia_comprador", UCase(CbColonia.Text))
        cmd.Parameters.AddWithValue("@Ciudad_comprador", UCase(CbCiudad.Text))
        cmd.Parameters.AddWithValue("@estado_comprador", UCase(TxEstado.Text))
        cmd.Parameters.AddWithValue("@codigo_postal", TxCpostal.Text)
        cmd.Parameters.AddWithValue("@persona_contacto", TxContacto.Text)
        cmd.Parameters.AddWithValue("@telefono_comprador", TxTelefono.Text)
        cmd.Parameters.AddWithValue("@celular_comprador", TxCelular.Text)
        cmd.Parameters.AddWithValue("@correo_electronico", TxCorreo.Text)

        cmd.ExecuteNonQuery()

        modifica = 0
        'controlBloqueo()
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxNumero.KeyPress
        Dim Cadena = ".0123456789S/NSsn"
        If InStr(Cadena, e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub llenarCombos()
        Dim cmdllenaCbCol As SqlCommand
        Dim da As SqlDataAdapter
        Dim ds As DataSet

        cmdllenaCbCol = New SqlCommand("Sp_CbColonias")
        cmdllenaCbCol.CommandType = CommandType.StoredProcedure
        cmdllenaCbCol.Connection = cnn

        da = New SqlDataAdapter(cmdllenaCbCol)
        ds = New DataSet()
        da.Fill(ds)

        CbColonia.DataSource = ds.Tables(0)
        CbColonia.DisplayMember = "nombre_colonia"
        CbColonia.ValueMember = "Id_colonia"
        CbColonia.SelectedIndex = -1

        Dim cmdllenaCbCiu As SqlCommand

        cmdllenaCbCiu = New SqlCommand("Sp_CbCiudades")
        cmdllenaCbCiu.CommandType = CommandType.StoredProcedure
        cmdllenaCbCiu.Connection = cnn

        da = New SqlDataAdapter(cmdllenaCbCiu)
        ds = New DataSet()
        da.Fill(ds)
        CbCiudad.DataSource = ds.Tables(0)
        CbCiudad.DisplayMember = "nombre_ciudad"
        CbCiudad.ValueMember = "id_ciudad"
        CbCiudad.SelectedIndex = -1

    End Sub
    Private PRCorEle As New Regex("\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")
    Private Sub TxCorreoFisica_TextChanged(sender As Object, e As EventArgs) Handles TxCorreo.Leave

        If Not PRCorEle.IsMatch(TxCorreo.Text) And TxCorreo.Text <> "" Then
            MessageBox.Show("El correo no cuenta con el formato correcto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxCorreo.Focus()
        End If

    End Sub
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim BuscarComprador As New BuscarComprador
        BuscarComprador.ShowDialog()
        Dim codigoSeleccionado As Object = BuscarComprador.CodigoComprador
        If BuscarComprador.CodigoComprador <> Nothing Then
            Dim cmd As New SqlCommand("sp_seleccioncomprador", cnn)

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlClient.SqlParameter("@idcomprador", BuscarComprador.CodigoComprador))

            Dim da As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)

            Dim row As DataRow = dt.Rows(0)

            TxIdComprador.Text = CStr(row("id_comprador"))
            TxNombre.Text = CStr(row("nombre_comprador"))
            TxRfc.Text = CStr(row("rfc_comprador"))
            TxCalle.Text = CStr(row("calle_comprador"))
            TxNumero.Text = CStr(row("numero_dom_comprador"))
            CbColonia.Text = CStr(row("colonia_comprador"))
            CbCiudad.Text = CStr(row("ciudad_comprador"))
            TxEstado.Text = CStr(row("estado_comprador"))
            TxCpostal.Text = CStr(row("codigo_postal"))
            TxContacto.Text = CStr(row("persona_contacto"))
            TxTelefono.Text = CStr(row("telefono_comprador"))
            TxCelular.Text = CStr(row("Celular_comprador"))
            TxCorreo.Text = CStr(row("correo_electronico"))
        ElseIf BuscarComprador.CodigoComprador = Nothing Then
            Exit Sub
        End If
        'controlBloqueo()
        Bloquear()
        BtnGuardar.Visible = False
        BtnModificar.Visible = True
    End Sub
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        TxIdComprador.Text = ""
        TxNombre.Text = ""
        TxRfc.Text = ""
        TxCalle.Text = ""
        TxNumero.Text = ""
        CbColonia.Text = ""
        CbCiudad.Text = ""
        TxEstado.Text = ""
        TxCpostal.Text = ""
        TxContacto.Text = ""
        TxTelefono.Text = ""
        TxCelular.Text = ""
        TxCorreo.Text = ""
        'controlBloqueo()
        Desbloquear()
    End Sub
    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Dim opc As DialogResult = MessageBox.Show("¿Esta seguro de modificar los datos del registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If opc = DialogResult.Yes Then
            Desbloquear()
            modifica = 1
            BtnModificar.Visible = False
            BtnGuardar.Visible = True
        End If
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Close()
    End Sub
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If TxIdComprador.Text = "" Then
            MessageBox.Show("No se ha seleccionado ningun registro", "Aviso")
        Else
            Dim cmd As New SqlCommand("Sp_EliminarComprador", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlClient.SqlParameter("@IdComprador", TxIdComprador.Text))
            cmd.ExecuteNonQuery()
            BtnNuevo_Click(sender, e)
            MessageBox.Show("Registro eliminado con éxito", "Aviso")
        End If
    End Sub
End Class