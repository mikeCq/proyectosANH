Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class BuscarCompradorLiquidacionVenta
    Private _codigoComprador As String
    Public Property CodigoComprador() As String
        Get
            Return _codigoComprador
        End Get
        Set(ByVal value As String)
            _codigoComprador = value
        End Set
    End Property

End Class