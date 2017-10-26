Imports System.IO.Ports
Imports System.Threading

Public Class Bascula2
    Dim nombre_puerto As String
    Private Sub captura_puerto2()
        Dim returnStr As String = ""

        On Error GoTo fallo


        'Variable global
        nombre_puerto = CbPuertosSeriales.Text

        Using com1 As IO.Ports.SerialPort = My.Computer.Ports.OpenSerialPort(nombre_puerto)
            com1.DataBits = 8
            com1.ReadTimeout = 3600
            Dim Incoming As String = com1.ReadLine()
            returnStr = Incoming
            Thread.Sleep(100)
            Incoming = com1.ReadLine()
            com1.Close()
        End Using

        Exit Sub
fallo:
        MsgBox(Err.Description, vbCritical)
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If DataGridView1.CurrentCell.ColumnIndex = 1 Then 'Columna que se captura el peso
            DataGridView1.CurrentCell.Value = fp_captura_peso()
        End If
    End Sub

    Private Function fp_captura_peso() As Double
        Dim lnLen As Long
        Dim lnCRpos As Object
        Dim InBuffer As Object
        Dim InMiddle, InDistinct As Object
        Dim peso_final As Object = 0
        Dim n As Long
        Dim lcEntrada As String = " "
        On Error GoTo fallo

        fp_captura_peso = 0

        Using com1 As IO.Ports.SerialPort = My.Computer.Ports.OpenSerialPort(nombre_puerto)
            Dim Incoming As String = com1.ReadLine()
            Thread.Sleep(100)
            Incoming = com1.ReadLine()
            lcEntrada = Incoming
        End Using

        If Len(Trim(lcEntrada)) > 10 Then
            Dim subStrings() As String
            Dim TestArray() As String = Split(lcEntrada, ",")

            For i As Integer = 0 To TestArray.Length - 1
                If TestArray(i) <> "" Then
                    If Char.IsNumber(Trim(TestArray(i))) = True Then
                        peso_final = TestArray(i)
                    End If
                End If
            Next

            If IsNumeric(peso_final) Then
                If peso_final >= 0 Then
                    fp_captura_peso = Format(CDbl(peso_final), "###,##0.0000")
                    Exit Function
                End If
            Else
                fp_captura_peso = 0
            End If
        Else
            MsgBox("No se ha detectado peso, intente nuevamente...", vbCritical)
        End If

        Exit Function

fallo:
        MsgBox(Err.Description)
    End Function
    Private Sub GetSerialPortNames()

        ' muestra COM ports disponibles.

        Dim l As Integer

        Dim ncom As String

        Try

            CbPuertosSeriales.Items.Clear()

            For Each sp As String In My.Computer.Ports.SerialPortNames

                l = sp.Length

                If ((sp(l - 1) >= "0") And (sp(l - 1) <= "9")) Then
                    CbPuertosSeriales.Items.Add(sp)
                Else
                    'hay una letra al final del COM
                    ncom = sp.Substring(0, l - 1)
                    CbPuertosSeriales.Items.Add(ncom)
                End If
            Next
            If CbPuertosSeriales.Items.Count >= 1 Then

                CbPuertosSeriales.Text = CbPuertosSeriales.Items(0)

            Else

                CbPuertosSeriales.Text = ""

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Bascula2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSerialPortNames()
        CheckForIllegalCrossThreadCalls = False ' DESACTIVA ERROR POR SUBPROCESO
    End Sub
End Class