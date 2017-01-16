Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class BuscarCompradorLiquidacionVenta
    Private _codigoVenta As String
    Public Property CodigoVenta() As String
        Get
            Return _codigoVenta
        End Get
        Set(ByVal value As String)
            _codigoVenta = value
        End Set
    End Property
    Private Sub BtBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim cmd As New SqlCommand("sp_LlenaDgCompradoresLiquidacionVentas", cnn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Comprador", TbBuscarComprador.Text)
        cmd.ExecuteNonQuery()
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataSet
        da.Fill(dt)
        DGVCompradores.DataSource = dt.Tables(0).DefaultView
        PropiedadesDGVCompradores()
        If DGVCompradores.RowCount > 0 Then DGVCompradores.Rows(0).Selected = False
    End Sub
    Private Sub TxProductor(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TbBuscarComprador.KeyDown
        Dim cmd As New SqlCommand("sp_LlenaDgCompradoresLiquidacionVentas", cnn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Comprador", TbBuscarComprador.Text)
        cmd.ExecuteNonQuery()
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataSet
        da.Fill(dt)
        DGVCompradores.DataSource = dt.Tables(0).DefaultView
        PropiedadesDGVCompradores()
        If DGVCompradores.RowCount > 0 Then DGVCompradores.Rows(0).Selected = False
    End Sub
    Private Sub BtSeleccionar_Click(sender As Object, e As EventArgs) Handles BtnSeleccionar.Click, DGVCompradores.DoubleClick
        If DGVCompradores.RowCount = 0 Then
            MessageBox.Show("No hay datos para seleccionar.")
        ElseIf DGVCompradores.CurrentRow IsNot Nothing Then
            _codigoVenta = CStr(DGVCompradores.CurrentRow.Cells(0).Value)
            Close()
        End If
    End Sub

    Private Sub BtCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        DGVCompradores.Columns.Clear()
        Close()
    End Sub
    Private Sub PropiedadesDGVCompradores()
        DGVCompradores.Columns("id_ContratoV").HeaderText = "Id de contrato"
        DGVCompradores.Columns("id_ContratoV").Width = 50
        DGVCompradores.Columns("fechaAlta").HeaderText = "Fecha de registro"
        DGVCompradores.Columns("fechaAlta").Width = 50
        DGVCompradores.Columns("id_Comprador").Visible = False
        DGVCompradores.Columns("Nombre_Comprador").HeaderText = "Nombre del comprador"
        DGVCompradores.Columns("Nombre_Comprador").Width = 100
        DGVCompradores.Columns("toneladasVentas").HeaderText = "Toneladas"
        DGVCompradores.Columns("precioxtonelada").HeaderText = "Precio"
        DGVCompradores.Columns("moneda").HeaderText = "Moneda"
        DGVCompradores.Columns("TipoContrato").HeaderText = "Tipo de contrato"
        DGVCompradores.Columns("ToneladasRestantes").HeaderText = "Toneladas restantes"
        DGVCompradores.Columns("id_Temporada").Visible = False
        DGVCompradores.Columns("fechaLiquidacion").HeaderText = "Fecha a liquidar"
    End Sub
    Private Sub BuscarCompradorLiquidacionVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'PropiedadesDGVCompradores()
    End Sub
End Class