Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class TipoCambioDiario
    Dim valor As Double
    Private _precioDolar As String
    Public Property PrecioDolar() As String
        Get
            Return _precioDolar
        End Get
        Set(value As String)
            _precioDolar = value
        End Set
    End Property
    Private Sub TipoCambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlBox = False
        CargaTipoCambio()
        NuTipoCambio.Focus()
    End Sub

    Private Sub CargaTipoCambio()
        Dim cmd As New SqlCommand("sp_ConsultaTipoCambio", cnn)

        cmd.CommandType = CommandType.StoredProcedure

        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)
        Dim row As DataRow = dt.Rows(0)
        DtFechaActualizacion.Value = row("FechaDeCambio")
        NuTipoCambio.Value = row("ValorMxn")
        valor = row("ValorMxn")
    End Sub
    Private Sub ActualizaTipoCambio()
        DtFechaActualizacion.Value = Now
        Dim cmd As New SqlCommand("sp_ActFechaCambio", cnn)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@PrecioDolar", NuTipoCambio.Value)
        cmd.Parameters.AddWithValue("@FechaCambio", Now)
        cmd.ExecuteNonQuery()
        PrecioDolar = NuTipoCambio.Value
    End Sub
    Private Sub BtAceptar_Click() Handles BtAceptar.Click
        ' MsgBox(WeekdayName(Weekday(DtFechaActualizacion.Value)))
        Dim opcDialog As DialogResult = MsgBox("¿Es el tipo de cambio correcto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)
        If opcDialog = DialogResult.Yes And NuTipoCambio.Value = valor And (Weekday(Now) = 7 Or Weekday(Now) = 1 Or Weekday(Now) = 2) Then
            ActualizaTipoCambio()
            valor = 0
            Me.Close()
        ElseIf opcDialog = DialogResult.Yes And NuTipoCambio.Value <> valor Then
            ActualizaTipoCambio()
            valor = 0
            Me.Close()
        ElseIf opcDialog = DialogResult.Yes And NuTipoCambio.Value = valor Then
            MessageBox.Show("El tipo de cambio no se a actualizado aun.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            NuTipoCambio.Focus()
        End If
    End Sub

End Class