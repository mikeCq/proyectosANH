<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bascula2
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
        Me.TxDatoRecibido = New System.Windows.Forms.TextBox()
        Me.LbDatoEnviar = New System.Windows.Forms.Label()
        Me.LbDatoRecibido = New System.Windows.Forms.Label()
        Me.BtnEnviar = New System.Windows.Forms.Button()
        Me.TxDatoEnviado = New System.Windows.Forms.TextBox()
        Me.CbPuertosSeriales = New System.Windows.Forms.ComboBox()
        Me.BtnConectar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxDatoRecibido
        '
        Me.TxDatoRecibido.Location = New System.Drawing.Point(121, 216)
        Me.TxDatoRecibido.Name = "TxDatoRecibido"
        Me.TxDatoRecibido.Size = New System.Drawing.Size(310, 20)
        Me.TxDatoRecibido.TabIndex = 13
        '
        'LbDatoEnviar
        '
        Me.LbDatoEnviar.AutoSize = True
        Me.LbDatoEnviar.Location = New System.Drawing.Point(395, 39)
        Me.LbDatoEnviar.Name = "LbDatoEnviar"
        Me.LbDatoEnviar.Size = New System.Drawing.Size(107, 13)
        Me.LbDatoEnviar.TabIndex = 11
        Me.LbDatoEnviar.Text = "Escriba dato a enviar"
        '
        'LbDatoRecibido
        '
        Me.LbDatoRecibido.AutoSize = True
        Me.LbDatoRecibido.Location = New System.Drawing.Point(260, 200)
        Me.LbDatoRecibido.Name = "LbDatoRecibido"
        Me.LbDatoRecibido.Size = New System.Drawing.Size(39, 13)
        Me.LbDatoRecibido.TabIndex = 12
        Me.LbDatoRecibido.Text = "Label1"
        '
        'BtnEnviar
        '
        Me.BtnEnviar.Location = New System.Drawing.Point(414, 81)
        Me.BtnEnviar.Name = "BtnEnviar"
        Me.BtnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.BtnEnviar.TabIndex = 10
        Me.BtnEnviar.Text = "Button3"
        Me.BtnEnviar.UseVisualStyleBackColor = True
        '
        'TxDatoEnviado
        '
        Me.TxDatoEnviado.Location = New System.Drawing.Point(335, 55)
        Me.TxDatoEnviado.Name = "TxDatoEnviado"
        Me.TxDatoEnviado.Size = New System.Drawing.Size(233, 20)
        Me.TxDatoEnviado.TabIndex = 9
        '
        'CbPuertosSeriales
        '
        Me.CbPuertosSeriales.FormattingEnabled = True
        Me.CbPuertosSeriales.Location = New System.Drawing.Point(90, 12)
        Me.CbPuertosSeriales.Name = "CbPuertosSeriales"
        Me.CbPuertosSeriales.Size = New System.Drawing.Size(116, 21)
        Me.CbPuertosSeriales.TabIndex = 8
        '
        'BtnConectar
        '
        Me.BtnConectar.Location = New System.Drawing.Point(90, 51)
        Me.BtnConectar.Name = "BtnConectar"
        Me.BtnConectar.Size = New System.Drawing.Size(116, 27)
        Me.BtnConectar.TabIndex = 6
        Me.BtnConectar.Text = "Button1"
        Me.BtnConectar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 66)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 293)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(648, 150)
        Me.DataGridView1.TabIndex = 14
        '
        'Bascula2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 636)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TxDatoRecibido)
        Me.Controls.Add(Me.LbDatoEnviar)
        Me.Controls.Add(Me.LbDatoRecibido)
        Me.Controls.Add(Me.BtnEnviar)
        Me.Controls.Add(Me.TxDatoEnviado)
        Me.Controls.Add(Me.CbPuertosSeriales)
        Me.Controls.Add(Me.BtnConectar)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Bascula2"
        Me.Text = "Bascula2"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxDatoRecibido As TextBox
    Friend WithEvents LbDatoEnviar As Label
    Friend WithEvents LbDatoRecibido As Label
    Friend WithEvents BtnEnviar As Button
    Friend WithEvents TxDatoEnviado As TextBox
    Friend WithEvents CbPuertosSeriales As ComboBox
    Friend WithEvents BtnConectar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
End Class
