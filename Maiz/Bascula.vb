Imports System.IO.Ports

Public Class Bascula
    Dim az As String     'utilizada para almacenar los datos que se reciben por el puerto
    Dim sib As Integer    ' sera utilizada como contador
    Dim msn(1000) As String    'vector que servira de buffer para los datos que van llegando al puerto
    Sub Setup_Puerto_Serie()
        Try
            With SerialPort1
                If .IsOpen Then
                    .Close()
                End If
                .PortName = CbPuertosSeriales.Text
                .BaudRate = 19200 '// 19200 baud rate
                .DataBits = 8 '// 8 data bits
                .StopBits = IO.Ports.StopBits.One '// 1 Stop bit
                .Parity = IO.Ports.Parity.None '
                .DtrEnable = False
                .Handshake = IO.Ports.Handshake.None
                .ReadBufferSize = 2048
                .WriteBufferSize = 1024
                '.ReceivedBytesThreshold = 1
                .WriteTimeout = 500
                .Encoding = System.Text.Encoding.Default
                .Open() ' ABRE EL PUERTO SERIE
            End With
        Catch ex As Exception
            MsgBox("Error al abrir el puerto serial: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
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
    Private Sub Bascula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSerialPortNames()
        CheckForIllegalCrossThreadCalls = False ' DESACTIVA ERROR POR SUBPROCESO
    End Sub
    Private Sub BtnConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConectar.Click
        Try
            If BtnConectar.Text = "Conectar" Then
                BtnConectar.Text = "Desconectar"
                Setup_Puerto_Serie()
            Else
                If SerialPort1.IsOpen Then
                    SerialPort1.Close()
                End If
                BtnConectar.Text = "Conectar"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button_enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnviar.Click
        sib = 0
        Try
            SerialPort1.Write(Me.TxDatoEnviado.Text)
            Me.TxDatoRecibido.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            az = SerialPort1.ReadExisting.Trim
            msn(sib) = az
            Me.TxDatoRecibido.Text += msn(sib) + " "
            sib = sib + 1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class