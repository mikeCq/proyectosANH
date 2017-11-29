Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class TransferenciasSilos
    Private Sub TransferenciasSilos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LimpiarCampos()
        LlenarComboOrigen()
    End Sub
    Private Sub LimpiarCampos()
        LlenarComboOrigen()
        CbSiloDestino.SelectedIndex = -1
        CbSiloOrigen.SelectedIndex = -1
        LbContenidoDestino.Text = "0.00"
        LbContenidoOrigen.Text = "0.00"
        LbMaxDestino.Text = "0.00"
        LbMaxOrigen.Text = "0.00"
        NuToneladasOrigen.Value = 0
    End Sub
    Private Sub LlenarComboOrigen()
        Dim cmdllenaCbOrigen As SqlCommand
        Dim da As SqlDataAdapter
        Dim ds As DataSet

        cmdllenaCbOrigen = New SqlCommand("sp_CbAlmacenOrigen")
        cmdllenaCbOrigen.CommandType = CommandType.StoredProcedure
        cmdllenaCbOrigen.Connection = cnn

        da = New SqlDataAdapter(cmdllenaCbOrigen)
        ds = New DataSet()
        da.Fill(ds)
        CbSiloOrigen.DataSource = ds.Tables(0)
        CbSiloOrigen.DisplayMember = "nombre_almacen"
        CbSiloOrigen.ValueMember = "id_almacen"
        CbSiloOrigen.SelectedIndex = -1
    End Sub
    Private Sub CargaDatosOrigen()
        Dim cmd As New SqlCommand("Sp_ObtieneSiloOrigen", cnn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlClient.SqlParameter("@IdAlmacen", CbSiloOrigen.SelectedValue))
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim dt As New DataSet()
        da.Fill(dt)
        LbContenidoOrigen.Text = dt.Tables(0).Rows(0)("tonEntradas").ToString()
        LbMaxOrigen.Text = dt.Tables(0).Rows(0)("Capacidad").ToString()
    End Sub
    Private Sub CargaDatosDestino()
        Dim cmd As New SqlCommand("Sp_ObtieneSiloOrigen", cnn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlClient.SqlParameter("@IdAlmacen", CbSiloDestino.SelectedValue))
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim dt As New DataSet()
        da.Fill(dt)
        LbContenidoDestino.Text = dt.Tables(0).Rows(0)("tonEntradas").ToString()
        LbMaxDestino.Text = dt.Tables(0).Rows(0)("Capacidad").ToString()
    End Sub
    Private Sub LlenaComboDestino(ByVal IdAlmacen As String)
        Dim cmdllenaCbDestino As SqlCommand
        Dim da As SqlDataAdapter
        Dim ds As DataSet

        cmdllenaCbDestino = New SqlCommand("Sp_CbAlmacenDestino")
        cmdllenaCbDestino.CommandType = CommandType.StoredProcedure
        cmdllenaCbDestino.Parameters.AddWithValue("@IdAlmacen", IdAlmacen)
        cmdllenaCbDestino.Connection = cnn

        da = New SqlDataAdapter(cmdllenaCbDestino)
        ds = New DataSet()
        da.Fill(ds)
        CbSiloDestino.DataSource = ds.Tables(0)
        CbSiloDestino.DisplayMember = "nombre_almacen"
        CbSiloDestino.ValueMember = "id_almacen"
        CbSiloDestino.SelectedIndex = -1
    End Sub
    Private Sub CbSiloOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbSiloOrigen.SelectionChangeCommitted
        LlenaComboDestino(CbSiloOrigen.SelectedValue)
        CargaDatosOrigen()
        LbContenidoDestino.Text = "0.00"
        LbMaxDestino.Text = "0.00"
        NuToneladasOrigen.Value = 0
    End Sub
    Private Sub LimpiarCamposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarCamposToolStripMenuItem.Click
        LimpiarCampos()
    End Sub
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub CbSiloDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbSiloDestino.SelectionChangeCommitted
        CargaDatosDestino()
    End Sub

    Private Sub BtTransferir_Click(sender As Object, e As EventArgs) Handles BtTransferir.Click
        Dim ContenidoOrigen As Decimal = Val(LbContenidoOrigen.Text)
        Dim ContenidoDestino As Decimal = Val(LbContenidoDestino.Text)
        Dim MaxOrigen As Decimal = Val(LbMaxOrigen.Text)
        Dim MaxDestino As Decimal = Val(LbMaxDestino.Text)

        Dim SumaTranferencia As Double = (NuToneladasOrigen.Value + Val(LbContenidoDestino.Text))
        If CbSiloOrigen.Text = "" Then
            MessageBox.Show("El campo Silo Origen no puede estar vacio.")
            Exit Sub
        ElseIf CbSiloDestino.Text = "" Then
            MessageBox.Show("El campo Silo Destino no puede estar vacio.")
            Exit Sub
        ElseIf NuToneladasOrigen.Value = 0 Then
            MessageBox.Show("El valor de Silo Origen debe ser mayor a 0.")
            Exit Sub
        ElseIf NuToneladasOrigen.Value > MaxOrigen Then
            MessageBox.Show("Se esta excediento la Capacidad Maxima para el Silo Origen: " + CbSiloOrigen.Text)
            Exit Sub
        ElseIf NuToneladasOrigen.Value > ContenidoOrigen Then
            MessageBox.Show("Se esta excediento las Toneladas Contenidas para el Silo Origen: " + CbSiloOrigen.Text)
            Exit Sub
        ElseIf NuToneladasOrigen.Value > MaxDestino Then
            MessageBox.Show("Se esta excediento la Capacidad Maxima para el Silo Destino: " + CbSiloDestino.Text)
            Exit Sub
        ElseIf SumaTranferencia > MaxDestino Then
            MessageBox.Show("Las toneladas a transferir sobrepasan la Capacidad Maxima del Silo Destino: " + CbSiloDestino.Text)
            Exit Sub
        Else
            Dim opc As DialogResult = MsgBox("¿Desea iniciar la transferencia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir")
            If opc = DialogResult.Yes Then
                LbContenidoOrigen.Text = Format(Val(LbContenidoOrigen.Text), "##,##00.000") - NuToneladasOrigen.Value
                LbContenidoDestino.Text = Format(Val(LbContenidoDestino.Text), "##,##00.000") + NuToneladasOrigen.Value
                NuToneladasOrigen.Value = 0
                ActualizaTranferenciaAlmacen(CbSiloOrigen.SelectedValue, CbSiloDestino.SelectedValue, Val(LbContenidoOrigen.Text), Val(LbContenidoDestino.Text))

            ElseIf opc = DialogResult.No Then

            End If
        End If
    End Sub
    Private Sub ActualizaTranferenciaAlmacen(ByVal IdAlmacenOrigen As String, ByVal IdAlmacenDestino As String, ByVal ContenidoOrigen As Decimal, ByVal ContenidoDestino As Decimal)
        Try
            Dim cmd As New SqlCommand("Sp_ActualizaTranferenciaAlmacen", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@IdAlmacenOrigen", IdAlmacenOrigen)
            cmd.Parameters.AddWithValue("@ContenidoOrigen", ContenidoOrigen)
            cmd.Parameters.AddWithValue("@IdAlmacenDestino", IdAlmacenDestino)
            cmd.Parameters.AddWithValue("@ContenidoDestino", ContenidoDestino)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Transferencia completada con exito!")
        Catch ex As Exception
            MsgBox("Se ha producido el siguiente error: " + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub
End Class