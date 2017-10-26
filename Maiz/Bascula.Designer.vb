<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bascula
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnConectar = New System.Windows.Forms.Button()
        Me.CbPuertosSeriales = New System.Windows.Forms.ComboBox()
        Me.TxDatoEnviado = New System.Windows.Forms.TextBox()
        Me.BtnEnviar = New System.Windows.Forms.Button()
        Me.LbDatoRecibido = New System.Windows.Forms.Label()
        Me.TxDatoRecibido = New System.Windows.Forms.TextBox()
        Me.LbDatoEnviar = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 66)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnConectar
        '
        Me.BtnConectar.Location = New System.Drawing.Point(91, 52)
        Me.BtnConectar.Name = "BtnConectar"
        Me.BtnConectar.Size = New System.Drawing.Size(116, 27)
        Me.BtnConectar.TabIndex = 0
        Me.BtnConectar.Text = "Button1"
        Me.BtnConectar.UseVisualStyleBackColor = True
        '
        'CbPuertosSeriales
        '
        Me.CbPuertosSeriales.FormattingEnabled = True
        Me.CbPuertosSeriales.Location = New System.Drawing.Point(91, 13)
        Me.CbPuertosSeriales.Name = "CbPuertosSeriales"
        Me.CbPuertosSeriales.Size = New System.Drawing.Size(116, 21)
        Me.CbPuertosSeriales.TabIndex = 1
        '
        'TxDatoEnviado
        '
        Me.TxDatoEnviado.Location = New System.Drawing.Point(336, 56)
        Me.TxDatoEnviado.Name = "TxDatoEnviado"
        Me.TxDatoEnviado.Size = New System.Drawing.Size(233, 20)
        Me.TxDatoEnviado.TabIndex = 2
        '
        'BtnEnviar
        '
        Me.BtnEnviar.Location = New System.Drawing.Point(415, 82)
        Me.BtnEnviar.Name = "BtnEnviar"
        Me.BtnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.BtnEnviar.TabIndex = 3
        Me.BtnEnviar.Text = "Button3"
        Me.BtnEnviar.UseVisualStyleBackColor = True
        '
        'LbDatoRecibido
        '
        Me.LbDatoRecibido.AutoSize = True
        Me.LbDatoRecibido.Location = New System.Drawing.Point(261, 201)
        Me.LbDatoRecibido.Name = "LbDatoRecibido"
        Me.LbDatoRecibido.Size = New System.Drawing.Size(39, 13)
        Me.LbDatoRecibido.TabIndex = 4
        Me.LbDatoRecibido.Text = "Label1"
        '
        'TxDatoRecibido
        '
        Me.TxDatoRecibido.Location = New System.Drawing.Point(122, 217)
        Me.TxDatoRecibido.Name = "TxDatoRecibido"
        Me.TxDatoRecibido.Size = New System.Drawing.Size(310, 20)
        Me.TxDatoRecibido.TabIndex = 5
        '
        'LbDatoEnviar
        '
        Me.LbDatoEnviar.AutoSize = True
        Me.LbDatoEnviar.Location = New System.Drawing.Point(396, 40)
        Me.LbDatoEnviar.Name = "LbDatoEnviar"
        Me.LbDatoEnviar.Size = New System.Drawing.Size(107, 13)
        Me.LbDatoEnviar.TabIndex = 4
        Me.LbDatoEnviar.Text = "Escriba dato a enviar"
        '
        'Bascula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 577)
        Me.Controls.Add(Me.TxDatoRecibido)
        Me.Controls.Add(Me.LbDatoEnviar)
        Me.Controls.Add(Me.LbDatoRecibido)
        Me.Controls.Add(Me.BtnEnviar)
        Me.Controls.Add(Me.TxDatoEnviado)
        Me.Controls.Add(Me.CbPuertosSeriales)
        Me.Controls.Add(Me.BtnConectar)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Bascula"
        Me.Text = "Bascula"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents BtnConectar As Button
    Friend WithEvents CbPuertosSeriales As ComboBox
    Friend WithEvents TxDatoEnviado As TextBox
    Friend WithEvents BtnEnviar As Button
    Friend WithEvents LbDatoRecibido As Label
    Friend WithEvents TxDatoRecibido As TextBox
    Friend WithEvents LbDatoEnviar As Label
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
End Class
