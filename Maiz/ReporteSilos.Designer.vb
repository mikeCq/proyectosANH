<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteSilos
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
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.RbSalidas = New System.Windows.Forms.RadioButton()
        Me.RbEntradas = New System.Windows.Forms.RadioButton()
        Me.CbAlmacen = New System.Windows.Forms.ComboBox()
        Me.LbLote = New System.Windows.Forms.Label()
        Me.CbAcopio = New System.Windows.Forms.ComboBox()
        Me.Btlimpiar = New System.Windows.Forms.Button()
        Me.DTFinal = New System.Windows.Forms.DateTimePicker()
        Me.DTInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txpro = New System.Windows.Forms.Label()
        Me.BtGenerarReporte = New System.Windows.Forms.Button()
        Me.CrSilos = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.RbSalidas)
        Me.SplitContainer2.Panel1.Controls.Add(Me.RbEntradas)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CbAlmacen)
        Me.SplitContainer2.Panel1.Controls.Add(Me.LbLote)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CbAcopio)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Btlimpiar)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DTFinal)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DTInicio)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Txpro)
        Me.SplitContainer2.Panel1.Controls.Add(Me.BtGenerarReporte)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.CrSilos)
        Me.SplitContainer2.Size = New System.Drawing.Size(1378, 786)
        Me.SplitContainer2.SplitterDistance = 372
        Me.SplitContainer2.TabIndex = 2
        '
        'RbSalidas
        '
        Me.RbSalidas.AutoSize = True
        Me.RbSalidas.Location = New System.Drawing.Point(211, 59)
        Me.RbSalidas.Name = "RbSalidas"
        Me.RbSalidas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RbSalidas.Size = New System.Drawing.Size(59, 17)
        Me.RbSalidas.TabIndex = 16
        Me.RbSalidas.TabStop = True
        Me.RbSalidas.Text = "Salidas"
        Me.RbSalidas.UseVisualStyleBackColor = True
        '
        'RbEntradas
        '
        Me.RbEntradas.AutoSize = True
        Me.RbEntradas.Location = New System.Drawing.Point(115, 59)
        Me.RbEntradas.Name = "RbEntradas"
        Me.RbEntradas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RbEntradas.Size = New System.Drawing.Size(67, 17)
        Me.RbEntradas.TabIndex = 15
        Me.RbEntradas.TabStop = True
        Me.RbEntradas.Text = "Entradas"
        Me.RbEntradas.UseVisualStyleBackColor = True
        '
        'CbAlmacen
        '
        Me.CbAlmacen.FormattingEnabled = True
        Me.CbAlmacen.Location = New System.Drawing.Point(115, 127)
        Me.CbAlmacen.Name = "CbAlmacen"
        Me.CbAlmacen.Size = New System.Drawing.Size(239, 21)
        Me.CbAlmacen.TabIndex = 14
        '
        'LbLote
        '
        Me.LbLote.AutoSize = True
        Me.LbLote.Enabled = False
        Me.LbLote.Location = New System.Drawing.Point(14, 130)
        Me.LbLote.Name = "LbLote"
        Me.LbLote.Size = New System.Drawing.Size(54, 13)
        Me.LbLote.TabIndex = 13
        Me.LbLote.Text = "Almacen :"
        '
        'CbAcopio
        '
        Me.CbAcopio.FormattingEnabled = True
        Me.CbAcopio.Location = New System.Drawing.Point(115, 95)
        Me.CbAcopio.Name = "CbAcopio"
        Me.CbAcopio.Size = New System.Drawing.Size(239, 21)
        Me.CbAcopio.TabIndex = 12
        '
        'Btlimpiar
        '
        Me.Btlimpiar.Location = New System.Drawing.Point(113, 273)
        Me.Btlimpiar.Name = "Btlimpiar"
        Me.Btlimpiar.Size = New System.Drawing.Size(75, 23)
        Me.Btlimpiar.TabIndex = 5
        Me.Btlimpiar.Text = "Limpiar"
        Me.Btlimpiar.UseVisualStyleBackColor = True
        '
        'DTFinal
        '
        Me.DTFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFinal.Location = New System.Drawing.Point(257, 165)
        Me.DTFinal.Name = "DTFinal"
        Me.DTFinal.Size = New System.Drawing.Size(97, 20)
        Me.DTFinal.TabIndex = 3
        Me.DTFinal.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'DTInicio
        '
        Me.DTInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTInicio.Location = New System.Drawing.Point(115, 165)
        Me.DTInicio.Name = "DTInicio"
        Me.DTInicio.Size = New System.Drawing.Size(97, 20)
        Me.DTInicio.TabIndex = 2
        Me.DTInicio.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(227, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "al"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Buscar del"
        '
        'Txpro
        '
        Me.Txpro.AutoSize = True
        Me.Txpro.Location = New System.Drawing.Point(14, 98)
        Me.Txpro.Name = "Txpro"
        Me.Txpro.Size = New System.Drawing.Size(95, 13)
        Me.Txpro.TabIndex = 2
        Me.Txpro.Text = "Centro de Acopio :"
        '
        'BtGenerarReporte
        '
        Me.BtGenerarReporte.Location = New System.Drawing.Point(252, 273)
        Me.BtGenerarReporte.Name = "BtGenerarReporte"
        Me.BtGenerarReporte.Size = New System.Drawing.Size(100, 23)
        Me.BtGenerarReporte.TabIndex = 4
        Me.BtGenerarReporte.Text = "Generar Reporte"
        Me.BtGenerarReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtGenerarReporte.UseVisualStyleBackColor = True
        '
        'CrSilos
        '
        Me.CrSilos.ActiveViewIndex = -1
        Me.CrSilos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrSilos.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrSilos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrSilos.Location = New System.Drawing.Point(0, 0)
        Me.CrSilos.Name = "CrSilos"
        Me.CrSilos.ShowCloseButton = False
        Me.CrSilos.ShowGroupTreeButton = False
        Me.CrSilos.ShowLogo = False
        Me.CrSilos.ShowParameterPanelButton = False
        Me.CrSilos.ShowRefreshButton = False
        Me.CrSilos.Size = New System.Drawing.Size(1002, 786)
        Me.CrSilos.TabIndex = 0
        Me.CrSilos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReporteSilos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1378, 786)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Name = "ReporteSilos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reporte de Silos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents RbSalidas As RadioButton
    Friend WithEvents RbEntradas As RadioButton
    Friend WithEvents CbAlmacen As ComboBox
    Friend WithEvents LbLote As Label
    Friend WithEvents CbAcopio As ComboBox
    Friend WithEvents Btlimpiar As Button
    Friend WithEvents DTFinal As DateTimePicker
    Friend WithEvents DTInicio As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Txpro As Label
    Friend WithEvents BtGenerarReporte As Button
    Friend WithEvents CrSilos As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
