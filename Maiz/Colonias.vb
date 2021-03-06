﻿Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class Colonias
    Private Sub Colonias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NuMaxTon.Controls(0).Visible = False
        limpiarCampos()
        CargarData()
    End Sub
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If TxNombre.Text = "" Or TxDescripcion.Text = "" Or TxCodigoPostal.Text = "" Or NuMaxTon.Value = 0 Then
            MessageBox.Show("Verifica campos en blanco", "Aviso")
            'ElseIf coloniaRegistrado(TxIdColonia.Text) = True Then
            '    MessageBox.Show("Ya existe la colonia " + TxIdColonia.Text + ".")
        Else
            Try
                If TxIdColonia.Text Is String.Empty Then
                    TxIdColonia.Text = generaCodigoColonia(TxIdColonia.Text)
                End If
                Dim cmd As New SqlCommand("Sp_InsNueCol", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Consecutivo", TxIdColonia.Text)
                cmd.Parameters.AddWithValue("@NomColonia", TxNombre.Text)
                cmd.Parameters.AddWithValue("@descripcion", TxDescripcion.Text)
                cmd.Parameters.AddWithValue("@maxton", NuMaxTon.Value)
                cmd.Parameters.AddWithValue("@cpcolonia", TxCodigoPostal.Text)
                TxIdColonia.Text = cmd.Parameters("@Consecutivo").Value.ToString()
                cmd.ExecuteNonQuery()
                Llenatextid()
                CargarData()
                limpiarCampos()
            Catch ex As Exception
                MsgBox("Error", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub Llenatextid()

        Dim dt As New DataTable
        Dim SqlCon As String = "Select max(Id_colonia)as Id_colonia from colonias"
        Dim comnd As New SqlCommand(SqlCon, cnn)
        Dim drd As SqlDataReader
        drd = comnd.ExecuteReader()
        If drd.Read() Then
            TxIdColonia.Text = drd.Item("Id_colonia").ToString()
        End If
        drd.Close()

    End Sub
    Private Sub CargarData()

        Dim cmd As New SqlCommand("sp_llenarDgColonias", cnn)
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        DgColonias.DataSource = dt

    End Sub
    Private Sub SeleccionCiudad(sender As Object, e As EventArgs) Handles DgColonias.DoubleClick
        If DgColonias.RowCount = 0 Then
            MessageBox.Show("No hay datos para seleccionar.")
        ElseIf Not DgColonias Is Nothing Then
            Dim valorId As String
            valorId = CStr(DgColonias.CurrentRow.Cells(0).Value)
            TxIdColonia.Text = valorId
            Dim cmd As New SqlCommand("sp_seleccionIdColonia", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlClient.SqlParameter("@idcolonia", valorId))
            Dim da As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim row As DataRow = dt.Rows(0)
            TxNombre.Text = CStr(row("nombre_colonia"))
            TxDescripcion.Text = CStr(row("Descripcion"))
            NuMaxTon.Value = row("Max_Ton_X_Ha")
            TxCodigoPostal.Text = CStr(row("cp_colonia"))
            BloquearCampos()
        End If
    End Sub
    Private Sub limpiarCampos()
        TxIdColonia.Text = ""
        TxNombre.Text = ""
        TxDescripcion.Text = ""
        TxCodigoPostal.Text = ""
        NuMaxTon.Value = 0
    End Sub
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        limpiarCampos()
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Close()
    End Sub
    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        If TxIdColonia.Text Is String.Empty Then
            MsgBox("No se ha seleccionado ningun registro")
            Exit Sub
        End If
        Dim opc As DialogResult = MessageBox.Show("¿Esta seguro de modificar los datos del registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If opc = DialogResult.Yes Then
            DesbloquearCampos()
            'modifica = 1
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click

    End Sub
    Private Sub BloquearCampos()
        TxNombre.Enabled = False
        TxCodigoPostal.Enabled = False
        TxDescripcion.Enabled = False
        NuMaxTon.Enabled = False
    End Sub
    Private Sub DesbloquearCampos()
        TxNombre.Enabled = True
        TxCodigoPostal.Enabled = True
        TxDescripcion.Enabled = True
        NuMaxTon.Enabled = True
    End Sub
End Class