<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TipoCambioDiario
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
        Me.NuTipoCambio = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtAceptar = New System.Windows.Forms.Button()
        Me.DtFechaActualizacion = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.NuTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NuTipoCambio
        '
        Me.NuTipoCambio.DecimalPlaces = 4
        Me.NuTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuTipoCambio.Location = New System.Drawing.Point(176, 114)
        Me.NuTipoCambio.Name = "NuTipoCambio"
        Me.NuTipoCambio.Size = New System.Drawing.Size(104, 24)
        Me.NuTipoCambio.TabIndex = 1
        Me.NuTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(433, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Captura el tipo de cambio correspondiente al dia de hoy."
        '
        'BtAceptar
        '
        Me.BtAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAceptar.Location = New System.Drawing.Point(176, 187)
        Me.BtAceptar.Name = "BtAceptar"
        Me.BtAceptar.Size = New System.Drawing.Size(98, 32)
        Me.BtAceptar.TabIndex = 2
        Me.BtAceptar.Text = "Aceptar"
        Me.BtAceptar.UseVisualStyleBackColor = True
        '
        'DtFechaActualizacion
        '
        Me.DtFechaActualizacion.Enabled = False
        Me.DtFechaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFechaActualizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaActualizacion.Location = New System.Drawing.Point(228, 57)
        Me.DtFechaActualizacion.Name = "DtFechaActualizacion"
        Me.DtFechaActualizacion.Size = New System.Drawing.Size(117, 24)
        Me.DtFechaActualizacion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(77, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Ultima Actualización:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(154, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "$"
        '
        'TipoCambioDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 231)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtFechaActualizacion)
        Me.Controls.Add(Me.BtAceptar)
        Me.Controls.Add(Me.NuTipoCambio)
        Me.Controls.Add(Me.Label2)
        Me.Name = "TipoCambioDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tipo de Cambio Hoy"
        CType(Me.NuTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NuTipoCambio As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents BtAceptar As Button
    Friend WithEvents DtFechaActualizacion As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
