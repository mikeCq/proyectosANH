<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteTotalContratos
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
        Me.CrTotalContratado = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CrTotalContratado
        '
        Me.CrTotalContratado.ActiveViewIndex = -1
        Me.CrTotalContratado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrTotalContratado.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrTotalContratado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrTotalContratado.Location = New System.Drawing.Point(0, 0)
        Me.CrTotalContratado.Name = "CrTotalContratado"
        Me.CrTotalContratado.ShowCloseButton = False
        Me.CrTotalContratado.ShowGroupTreeButton = False
        Me.CrTotalContratado.ShowLogo = False
        Me.CrTotalContratado.ShowParameterPanelButton = False
        Me.CrTotalContratado.ShowRefreshButton = False
        Me.CrTotalContratado.Size = New System.Drawing.Size(627, 429)
        Me.CrTotalContratado.TabIndex = 3
        Me.CrTotalContratado.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReporteTotalContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 429)
        Me.Controls.Add(Me.CrTotalContratado)
        Me.Name = "ReporteTotalContratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reporte Total de Contratos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CrTotalContratado As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
