Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class RutasDocumentos
    Private folderBrowserDialog1 As FolderBrowserDialog
    Private Sub RutasDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand("sp_ObtUbicacionDocumentos", cnn)

        cmd.CommandType = CommandType.StoredProcedure

        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)

        Dim row As DataRow = dt.Rows(0)


        TBRuta.Text = CStr(row("RutaPrincipal"))
        TBNombreRaiz.Text = CStr(row("NombreCarpetaRaiz"))
        TBPersonas.Text = CStr(row("DocumentosProductores"))
        TBLotes.Text = CStr(row("DocumentosLotes"))
        TbContratosProductores.Text = CStr(row("ContratosProductores"))
        TbContratosCompradores.Text = CStr(row("ContratosCompradores"))
        TbAnexo.Text = CStr(row("Anexos"))
        TbPreregistro.Text = CStr(row("PreRegistro"))
        TbActaParticipacion.Text = CStr(row("ActaParticipacion"))
        TbTemporadas.Text = CStr(row("Temporadas"))
        TbNombreAnual.Text = CStr(row("NombreAnual"))

        GbUbicacionDocumentos.Enabled = False
    End Sub
    Private Sub BTUbicacion_Click(sender As Object, e As EventArgs) Handles BTUbicacion.Click
        Dim Ruta As String = ""
        Ruta = TBRuta.Text
        TBRuta.Text = AbrirRutaPrincipal(Ruta)
    End Sub
    Private Sub BtCarpetaTemporada_Click(sender As Object, e As EventArgs) Handles BtCarpetaTemporada.Click
        Dim Ruta As String = ""
        Ruta = TBRuta.Text & "\" & TBNombreRaiz.Text & "\" & TbTemporadas.Text & "\" '& TbNombreAnual.Text
        AbrirRutaAnual(Ruta)
    End Sub
    Private Function AbrirRutaPrincipal(ByVal Ruta As String)
        Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Try
            ' Configuración del FolderBrowserDialog
            With folderBrowserDialog1

                .Reset() ' resetea

                ' leyenda
                .Description = " Seleccionar una carpeta "
                ' Path " Mis documentos "
                .SelectedPath = Ruta

                ' deshabilita el botón " crear nueva carpeta "
                .ShowNewFolderButton = True

                '.RootFolder = Environment.SpecialFolder.Desktop
                '.RootFolder = Environment.SpecialFolder.StartMenu

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo

                ' si se presionó el botón aceptar ...
                If ret = DialogResult.OK Then

                    'Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                    'nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)

                    'MsgBox("Total de archivos: " & CStr(nFiles.Count),
                    '                        MsgBoxStyle.Information)
                    Ruta = LTrim(RTrim(folderBrowserDialog1.SelectedPath))
                End If

                .Dispose()
            End With

        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
        Return Ruta
    End Function
    Private Sub AbrirRutaAnual(ByVal Ruta As String)
        Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Try
            ' Configuración del FolderBrowserDialog
            With folderBrowserDialog1

                .Reset() ' resetea

                ' leyenda
                .Description = " Seleccionar una carpeta "
                ' Path " Mis documentos "
                .SelectedPath = Ruta

                ' deshabilita el botón " crear nueva carpeta "
                .ShowNewFolderButton = True

                '.RootFolder = Environment.SpecialFolder.Desktop
                '.RootFolder = Environment.SpecialFolder.StartMenu

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo

                ' si se presionó el botón aceptar ...
                If ret = DialogResult.OK Then

                    'Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                    'nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)

                    'MsgBox("Total de archivos: " & CStr(nFiles.Count),
                    '                        MsgBoxStyle.Information)
                    'Ruta = folderBrowserDialog1.SelectedPath
                    TbNombreAnual.Text = LTrim(RTrim(Strings.Right(folderBrowserDialog1.SelectedPath, 7)))
                End If

                .Dispose()
            End With

        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub CrearCarpetas()
        Dim NuevaTemporada As String = TBRuta.Text & "\" & TBNombreRaiz.Text & "\" & TbTemporadas.Text & "\" & TbNombreAnual.Text
        If Not Directory.Exists(NuevaTemporada & "\" & TbContratosProductores.Text) Or Directory.Exists(NuevaTemporada) Then
            Directory.CreateDirectory(NuevaTemporada & "\" & TbContratosProductores.Text)
            Directory.CreateDirectory(NuevaTemporada & "\" & TbContratosCompradores.Text)
            Directory.CreateDirectory(NuevaTemporada & "\" & TbAnexo.Text)
            Directory.CreateDirectory(NuevaTemporada & "\" & TbPreregistro.Text)
            Directory.CreateDirectory(NuevaTemporada & "\" & TbActaParticipacion.Text)
        End If
    End Sub
    Private Sub Guardar()
        Dim cnn As New SqlConnection(ConexionPrincipal)
        Dim cmdGuardar As SqlCommand

        cnn.Open()
        cmdGuardar = New SqlCommand("sp_InsDocumentos", cnn)
        cmdGuardar.CommandType = CommandType.StoredProcedure
            cmdGuardar.Parameters.Add(New SqlParameter("@IdUbicacion", 1))
            cmdGuardar.Parameters.Add(New SqlParameter("@RutaPrincipal", TBRuta.Text))
            cmdGuardar.Parameters.Add(New SqlParameter("@NombreCarpetaRaiz", TBNombreRaiz.Text))
            cmdGuardar.Parameters.Add(New SqlParameter("@DocumentosProductores", TBPersonas.Text))
            cmdGuardar.Parameters.Add(New SqlParameter("@DocumentosLotes", TBLotes.Text))
            cmdGuardar.Parameters.Add(New SqlParameter("@ContratosProductores", TbContratosProductores.Text))
            cmdGuardar.Parameters.Add(New SqlParameter("@ContratosCompradores", TbContratosCompradores.Text))
            cmdGuardar.Parameters.Add(New SqlParameter("@Anexos", TbAnexo.Text))
            cmdGuardar.Parameters.Add(New SqlParameter("@PreRegistro", TbPreregistro.Text))
            cmdGuardar.Parameters.Add(New SqlParameter("@ActaParticipacion", TbActaParticipacion.Text))
            cmdGuardar.Parameters.Add(New SqlParameter("@Temporadas", TbTemporadas.Text))
            cmdGuardar.Parameters.Add(New SqlParameter("@NombreAnual", TbNombreAnual.Text))
            cmdGuardar.ExecuteNonQuery()
        cnn.Close()
        CrearCarpetas()
        GbUbicacionDocumentos.Enabled = False
    End Sub
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub GuardarActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarActualizarToolStripMenuItem.Click
        Guardar()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click

    End Sub
End Class