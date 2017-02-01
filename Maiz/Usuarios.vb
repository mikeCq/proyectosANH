Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class Usuarios
    Dim modifica As Integer = 0
    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
        LimpiarCampos()
        controlBloqueo()
        BtnActualizar.Visible = False

    End Sub
    Private Sub llenarCombos()
        Dim cmdllenaCbTipUsu As SqlCommand
        Dim da As SqlDataAdapter
        Dim ds As DataSet

        cmdllenaCbTipUsu = New SqlCommand("sp_CbTipoUsuario")
        cmdllenaCbTipUsu.CommandType = CommandType.StoredProcedure
        cmdllenaCbTipUsu.Connection = cnn

        da = New SqlDataAdapter(cmdllenaCbTipUsu)
        ds = New DataSet()
        da.Fill(ds)
        CBTipoUsuario.DataSource = ds.Tables(0)
        CBTipoUsuario.DisplayMember = "Nombre_tipousuario"
        CBTipoUsuario.ValueMember = "Id_tipousuario"
        CBTipoUsuario.SelectedIndex = -1
    End Sub
    Private Sub LimpiarCampos() Handles BtnNuevo.Click

        TxIdUsuario.Text = ""
        TxNombre.Text = ""
        Txusuario.Text = ""
        TxContraseña.Text = ""
        CBTipoUsuario.SelectedIndex = -1
        GBUsuario.Enabled = True

    End Sub

    Private Sub controlBloqueo()
        If TxIdUsuario.Text = "" Then
            GBUsuario.Enabled = True
        Else
            GBUsuario.Enabled = False
        End If
    End Sub
    Private Sub controlDesbloqueo()
        If TxIdUsuario.Text = "" Then
            GBUsuario.Enabled = False
        Else
            GBUsuario.Enabled = True
        End If
    End Sub


    Private Sub Guardar(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim idusuario As String = ""
        If CBTipoUsuario.SelectedIndex = -1 Or TxNombre.Text = "" Or Txusuario.Text = "" Then
            MessageBox.Show("Verifica campos en blanco", "Aviso")
        ElseIf IdUsuRegistrado(TxIdUsuario.Text) = True Or usuarioRegistrado(Txusuario.Text) = True Then
            If TxIdUsuario.Text = "" Then

                MessageBox.Show("Ya existe el usuario " + Txusuario.Text + ".")

            Else

                MessageBox.Show("Ya existe el usuario " + TxIdUsuario.Text + ".")

            End If
        Else
            Try
                Dim cmd As New SqlCommand("Sp_InsNueUsu", cnn)

                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@idusuario", generaCodigoUsuario(idusuario))
                cmd.Parameters.AddWithValue("@nombre", TxNombre.Text)
                cmd.Parameters.AddWithValue("@usuario", Txusuario.Text)
                cmd.Parameters.AddWithValue("@clave", TxContraseña.Text)
                cmd.Parameters.AddWithValue("@tipo", CBTipoUsuario.SelectedValue)

                TxIdUsuario.Text = cmd.Parameters("@idusuario").Value.ToString()

                cmd.ExecuteNonQuery()
                controlBloqueo()
            Catch ex As Exception
                MsgBox("Error.", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub




    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim BuscarUsuario As New BuscarUsuario
        BuscarUsuario.ShowDialog()
        LimpiarCampos()
        If BuscarUsuario.CodigoUsuario <> Nothing Then
            Dim cmd As New SqlCommand("sp_seleccionusuario", cnn)

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlClient.SqlParameter("@idusuario", BuscarUsuario.CodigoUsuario))

            Dim da As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)

            Dim row As DataRow = dt.Rows(0)

            TxIdUsuario.Text = CStr(row("id_usuario"))
            TxNombre.Text = CStr(row("nombre"))
            Txusuario.Text = CStr(row("usuario"))
            TxContraseña.Text = CStr(row("clave"))
            CBTipoUsuario.SelectedValue = row("tipo")

        End If
        controlBloqueo()
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click

        Close()

    End Sub

    Private Sub LimpiarCampos(sender As Object, e As EventArgs) Handles BtnNuevo.Click

    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Dim opc As DialogResult = MessageBox.Show("¿Esta seguro de modificar los datos del registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If opc = DialogResult.Yes Then
            controlDesbloqueo()
            modifica = 1
            BtnGuardar.Visible = False
            BtnActualizar.Visible = True

        End If
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        Try

            If CBTipoUsuario.SelectedIndex = -1 Or TxNombre.Text = "" Or TxContraseña.Text = "" Or Txusuario.Text = "" Then
                MessageBox.Show("Verifica campos en blanco", "Aviso")

            Else
                Dim cmd5 As New SqlCommand("Sp_ActualizacionUsuario", cnn)

                cmd5.CommandType = CommandType.StoredProcedure

                cmd5.Parameters.AddWithValue("@idusuario", TxIdUsuario.Text)
                cmd5.Parameters.AddWithValue("@nombre", TxNombre.Text)
                cmd5.Parameters.AddWithValue("@usuario", Txusuario.Text)
                cmd5.Parameters.AddWithValue("@clave", TxContraseña.Text)
                cmd5.Parameters.AddWithValue("@tipo", CBTipoUsuario.SelectedValue)

                cmd5.ExecuteNonQuery()
                controlBloqueo()
                BtnActualizar.Visible = False
                BtnGuardar.Visible = True
            End If
        Catch ex As Exception
            MsgBox("Error.", MsgBoxStyle.Critical)

        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click


        If TxIdUsuario.Text = "" Then
            MessageBox.Show("No tienes seleccionado ningún Usuario", "Aviso")
        Else
            Dim Respuesta As DialogResult
            Respuesta = MessageBox.Show("Esta seguro de eliminar al usuario :" + TxNombre.Text + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If Respuesta = DialogResult.Yes Then
                Dim eliminar As New SqlCommand("Sp_EliminarUsuario", cnn)
                eliminar.CommandType = CommandType.StoredProcedure
                eliminar.Parameters.AddWithValue("@idusuario", TxIdUsuario.Text)
                eliminar.ExecuteNonQuery()
                LimpiarCampos()
            End If
        End If
    End Sub
End Class