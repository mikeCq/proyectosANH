Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class ReporteORI
    Private Sub ReporteORI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BTGeneraReporte_Click(sender As Object, e As EventArgs) Handles BTGeneraReporte.Click
        llenaexcel()
    End Sub
    'Sub CargarArchivoExcel(ByVal Path As String)
    '    Dim xlsApp As Excel.Application
    '    Dim xlsLibro As Excel.Workbook
    '    Dim xlsHoja As Excel.Worksheet
    '    Dim Filas As Integer
    '    'Dim ExcelValido As Boolean

    '    Filas = 2

    '    xlsApp = New Excel.Application()

    '    Try
    '        xlsLibro = xlsApp.Workbooks.Open(Path, True, True, , "")
    '        xlsHoja = xlsApp.Worksheets("Hoja1")

    '        ' ExcelValido = ValidarArchivoExcel(xlsHoja)

    '        '  If (ExcelValido) Then

    '        Colateral.Inicializar()
    '        Colateral.Campo(10).valor = xlsHoja.Range("K" & CType(Filas, String)).Text

    '        If (Proceso.Existe("rr_ExiColFecCie", Colateral, 1)) Then
    '            lblMensaje.Text = String.Format("No se pudieron agregar los registros porque ya existen registros con la fecha de corte {0}", xlsHoja.Range("K" & CType(Filas, String)).Text)
    '        Else
    '            While (xlsHoja.Range("A" & CType(Filas, String)).Text <> String.Empty)
    '                Colateral.Campo(0).Valor = xlsHoja.Range("A" & CType(Filas, String)).Text
    '                Colateral.Campo(1).Valor = xlsHoja.Range("B" & CType(Filas, String)).Text
    '                Colateral.Campo(2).Valor = xlsHoja.Range("C" & CType(Filas, String)).Text
    '                Colateral.Campo(3).Valor = xlsHoja.Range("D" & CType(Filas, String)).Text
    '                Colateral.Campo(4).Valor = xlsHoja.Range("E" & CType(Filas, String)).Text
    '                Colateral.Campo(5).Valor = xlsHoja.Range("F" & CType(Filas, String)).Text
    '                Colateral.Campo(6).Valor = xlsHoja.Range("G" & CType(Filas, String)).Text
    '                Colateral.Campo(7).Valor = xlsHoja.Range("H" & CType(Filas, String)).Text
    '                Colateral.Campo(8).Valor = xlsHoja.Range("I" & CType(Filas, String)).Text
    '                Colateral.Campo(9).Valor = IIf(xlsHoja.Range("J" & CType(Filas, String)).Text = String.Empty, 0, xlsHoja.Range("J" & CType(Filas, String)).Text)
    '                Colateral.Campo(10).Valor = xlsHoja.Range("K" & CType(Filas, String)).Text

    '                Proceso.Comando("rr_InsCol", Colateral, 1)

    '                Filas = Filas + 1
    '            End While
    '            Label1.Text = "Los registros se agregaron correctamente"
    '            xlsLibro.Close(SaveChanges:=False)
    '        End If
    '        'Else
    '        '    lblMensaje.Text = "Los registros no se agregaron ya que están incompletos, complete los registros e intente de nuevo"
    '        'End If
    '    Catch ex As Exception
    '        Label1.Text = ex.InnerException.ToString()
    '    Finally
    '        xlsApp.Quit()
    '        xlsHoja = Nothing
    '        xlsLibro = Nothing
    '        xlsApp = Nothing
    '    End Try
    'End Sub
    Private Sub llenaexcel()


        'Dim cmd As New SqlCommand("sp_seleccionIdProdEnt", cnn)

        'cmd.CommandType = CommandType.StoredProcedure
        'Dim da As New SqlClient.SqlDataAdapter(cmd)
        'Dim dt As New DataSet

        'da.Fill(dt)


        Dim m_Excel As Microsoft.Office.Interop.Excel.Application
        Dim strRutaExcel As String = Replace(My.Computer.FileSystem.CurrentDirectory, "bin\Debug", "")
        Dim archivo_incoming As String = strRutaExcel + "Libro1.xlsx"
        Dim ContFila As Integer = 1

        'Dim oDr As SqlDataReader = Nothing
        'Dim sb As New StringBuilder
        'Dim oConex As New SqlConnection
        'Dim ocmd As New SqlCommand

        'oConex.ConnectionString = VarGlob.ConexionPrincipal.ToString()
        'oConex.Open()
        'ocmd.Connection = oConex
        'ocmd.CommandType = CommandType.Text

        'sb.Append("SELECT * FROM ControlEntradas")
        'ocmd.CommandText = sb.ToString
        'oDr = ocmd.ExecuteReader()

        Dim cmd As New SqlCommand("sp_llenarDgColonias", cnn)

        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim dt As New DataSet

        da.Fill(dt)

        'strRutaExcel = archivo_incoming
        m_Excel = CreateObject("Excel.Application")
        m_Excel.Workbooks.Open(archivo_incoming)
        m_Excel.Visible = False 'Dejamos el libro oculto

        'While oDr.Read()
        For Contador1 = 0 To dt.Tables(0).Rows.Count - 1
            ContFila = ContFila + 1
            ' LLenar columna de la celda 
            m_Excel.Cells(ContFila, 2).value = CStr(dt.Tables(0).Rows(Contador1)("id_colonia"))
            m_Excel.Cells(ContFila, 3).value = CStr(dt.Tables(0).Rows(Contador1)("Nombre_colonia"))
            m_Excel.Cells(ContFila, 4).value = CStr(dt.Tables(0).Rows(Contador1)("Descripcion"))
            m_Excel.Cells(ContFila, 5).value = CStr(dt.Tables(0).Rows(Contador1)("CP_colonia"))

            'Escribimos en cada celda en archivo execel
            m_Excel.DisplayAlerts = False
            m_Excel.Application.ActiveWorkbook.SaveAs(archivo_incoming)

        Next


        'End While
        MsgBox("Se realizo el llenado de formato con exito!")
        m_Excel.Visible = True

        'Eliminamos la instancia de Excel de memoria
        If Not m_Excel Is Nothing Then
            '  m_Excel.Quit()
            m_Excel = Nothing
        End If
    End Sub
End Class