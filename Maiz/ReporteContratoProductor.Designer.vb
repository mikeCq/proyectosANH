<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteContratoProductor
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
        Me.CrContratoProductor = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CrContratoProductor
        '
        Me.CrContratoProductor.ActiveViewIndex = -1
        Me.CrContratoProductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrContratoProductor.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrContratoProductor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrContratoProductor.Location = New System.Drawing.Point(0, 0)
        Me.CrContratoProductor.Name = "CrContratoProductor"
        Me.CrContratoProductor.ShowCloseButton = False
        Me.CrContratoProductor.ShowCopyButton = False
        Me.CrContratoProductor.ShowLogo = False
        Me.CrContratoProductor.ShowParameterPanelButton = False
        Me.CrContratoProductor.ShowRefreshButton = False
        Me.CrContratoProductor.Size = New System.Drawing.Size(944, 596)
        Me.CrContratoProductor.TabIndex = 0
        '
        'ReporteContratoProductor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 596)
        Me.Controls.Add(Me.CrContratoProductor)
        Me.Name = "ReporteContratoProductor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ReporteContratoProductor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CrContratoProductor As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
