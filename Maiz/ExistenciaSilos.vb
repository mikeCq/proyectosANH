Public Class ExistenciaSilos
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim colidboleta As New DataGridViewTextBoxColumn
        colidboleta.Name = "numeroBoleta"
        colidboleta.HeaderText = "Boleta"
        colidboleta.Width = 50
        DataGridView1.Columns.Insert(0, colidboleta)

        Dim colIdProductor As New DataGridViewTextBoxColumn
        colIdProductor.Name = "IdProductor"
        DataGridView1.Columns.Insert(1, colIdProductor)

        Dim colidfecha As New DataGridViewTextBoxColumn
        colidfecha.HeaderText = "Fecha"
        colidfecha.Width = 70
        colidfecha.Name = "Fecha_Pesaje"
        DataGridView1.Columns.Insert(2, colidfecha)

        Dim col As New ProgressColumn

        col.HeaderText = "%"
        col.Width = 70
        col.Name = "Porcentaje"
        DataGridView1.Columns.Insert(3, col)

        'DataGridView1.Columns.Add(col)
        'DataGridView1.AllowUserToAddRows = False
        DataGridView1.RowCount = 5
        Dim x As Integer = 1
        For Each row As DataGridViewRow In DataGridView1.Rows
            row.Cells(0).Value = x * 20
            x += 1
        Next
    End Sub
End Class

Public Class ProgressColumn
    Inherits DataGridViewColumn
    Public Sub New()
        'MyBase.New(New ProgressCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal Value As DataGridViewCell)
            ' Ensure that the cell used for the template is a ProgressCell.
            If Value IsNot Nothing And Not TypeOf (Value) Is ProgressCell Then
                Throw New InvalidCastException("Must be a ProgressCell")
            End If
            MyBase.CellTemplate = Value
        End Set
    End Property
End Class

Public Class ProgressCell
    Inherits DataGridViewImageCell
    Protected Overrides Function GetFormattedValue(ByVal value As Object, ByVal rowIndex As Integer, ByRef cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal valueTypeConverter As System.ComponentModel.TypeConverter, ByVal formattedValueTypeConverter As System.ComponentModel.TypeConverter, ByVal context As System.Windows.Forms.DataGridViewDataErrorContexts) As Object
        ' Create bitmap.
        Dim bmp As Bitmap = New Bitmap(Me.Size.Width, Me.Size.Height)

        Using g As Graphics = Graphics.FromImage(bmp)

            ' Percentage.
            Dim percentage As Double = 0
            Double.TryParse(Me.Value.ToString(), percentage)
            Dim text As String = percentage.ToString() + " %"

            ' Get width and height of text.
            Dim f As Font = New Font("Verdana", 10, FontStyle.Regular)
            Dim w As Integer = CType(g.MeasureString(text, f).Width, Integer)
            Dim h As Integer = CType(g.MeasureString(text, f).Height, Integer)

            ' Draw pile.
            g.DrawRectangle(Pens.Black, 2, 2, Me.Size.Width - 6, Me.Size.Height - 6)
            g.FillRectangle(Brushes.Blue, 3, 3, CInt((Me.Size.Width - 6) * percentage / 100), CInt(Me.Size.Height - 7))

            Dim rect As RectangleF = New RectangleF(0, 0, bmp.Width, bmp.Height)
            Dim sf As StringFormat = New StringFormat()
            sf.Alignment = StringAlignment.Center
            g.DrawString(text, f, Brushes.Red, rect, sf)
        End Using

        Return bmp
    End Function


End Class