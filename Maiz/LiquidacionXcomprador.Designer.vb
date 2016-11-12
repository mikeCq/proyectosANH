<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LiquidacionXcomprador
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LiquidacionXcomprador))
        Me.TbLiquidacionXProd = New System.Windows.Forms.TabControl()
        Me.TpBoletasXliquidar = New System.Windows.Forms.TabPage()
        Me.RbNo = New System.Windows.Forms.RadioButton()
        Me.RbSi = New System.Windows.Forms.RadioButton()
        Me.NuTotalLiquidar = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NuTonSeleccion = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DgSeleccionLiquidaciones = New System.Windows.Forms.DataGridView()
        Me.DgEntradasLiq = New System.Windows.Forms.DataGridView()
        Me.TpBoletasLiquidadas = New System.Windows.Forms.TabPage()
        Me.DgLiquidaciones = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxProductor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NuPrecioTon = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NuLibre = New System.Windows.Forms.NumericUpDown()
        Me.NuContrato = New System.Windows.Forms.NumericUpDown()
        Me.BtGuardar = New System.Windows.Forms.Button()
        Me.BtSalir = New System.Windows.Forms.Button()
        Me.BtNuevo = New System.Windows.Forms.Button()
        Me.BtBuscar = New System.Windows.Forms.Button()
        Me.BtAgregarSeleccion = New System.Windows.Forms.Button()
        Me.TbLiquidacionXProd.SuspendLayout()
        Me.TpBoletasXliquidar.SuspendLayout()
        CType(Me.NuTotalLiquidar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuTonSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgSeleccionLiquidaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgEntradasLiq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpBoletasLiquidadas.SuspendLayout()
        CType(Me.DgLiquidaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuPrecioTon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuLibre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbLiquidacionXProd
        '
        Me.TbLiquidacionXProd.Controls.Add(Me.TpBoletasXliquidar)
        Me.TbLiquidacionXProd.Controls.Add(Me.TpBoletasLiquidadas)
        Me.TbLiquidacionXProd.Location = New System.Drawing.Point(12, 154)
        Me.TbLiquidacionXProd.Name = "TbLiquidacionXProd"
        Me.TbLiquidacionXProd.SelectedIndex = 0
        Me.TbLiquidacionXProd.Size = New System.Drawing.Size(1313, 464)
        Me.TbLiquidacionXProd.TabIndex = 55
        '
        'TpBoletasXliquidar
        '
        Me.TpBoletasXliquidar.Controls.Add(Me.RbNo)
        Me.TpBoletasXliquidar.Controls.Add(Me.RbSi)
        Me.TpBoletasXliquidar.Controls.Add(Me.NuTotalLiquidar)
        Me.TpBoletasXliquidar.Controls.Add(Me.Label7)
        Me.TpBoletasXliquidar.Controls.Add(Me.NuTonSeleccion)
        Me.TpBoletasXliquidar.Controls.Add(Me.Label4)
        Me.TpBoletasXliquidar.Controls.Add(Me.Label5)
        Me.TpBoletasXliquidar.Controls.Add(Me.BtAgregarSeleccion)
        Me.TpBoletasXliquidar.Controls.Add(Me.DgSeleccionLiquidaciones)
        Me.TpBoletasXliquidar.Controls.Add(Me.DgEntradasLiq)
        Me.TpBoletasXliquidar.Location = New System.Drawing.Point(4, 22)
        Me.TpBoletasXliquidar.Name = "TpBoletasXliquidar"
        Me.TpBoletasXliquidar.Padding = New System.Windows.Forms.Padding(3)
        Me.TpBoletasXliquidar.Size = New System.Drawing.Size(1305, 438)
        Me.TpBoletasXliquidar.TabIndex = 0
        Me.TpBoletasXliquidar.Text = "Boletas por Liquidar"
        Me.TpBoletasXliquidar.UseVisualStyleBackColor = True
        '
        'RbNo
        '
        Me.RbNo.AutoSize = True
        Me.RbNo.Enabled = False
        Me.RbNo.Location = New System.Drawing.Point(205, 7)
        Me.RbNo.Name = "RbNo"
        Me.RbNo.Size = New System.Drawing.Size(41, 17)
        Me.RbNo.TabIndex = 48
        Me.RbNo.TabStop = True
        Me.RbNo.Text = "NO"
        Me.RbNo.UseVisualStyleBackColor = True
        '
        'RbSi
        '
        Me.RbSi.AutoSize = True
        Me.RbSi.Enabled = False
        Me.RbSi.Location = New System.Drawing.Point(164, 7)
        Me.RbSi.Name = "RbSi"
        Me.RbSi.Size = New System.Drawing.Size(35, 17)
        Me.RbSi.TabIndex = 49
        Me.RbSi.TabStop = True
        Me.RbSi.Text = "SI"
        Me.RbSi.UseVisualStyleBackColor = True
        '
        'NuTotalLiquidar
        '
        Me.NuTotalLiquidar.DecimalPlaces = 2
        Me.NuTotalLiquidar.Enabled = False
        Me.NuTotalLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuTotalLiquidar.Location = New System.Drawing.Point(1176, 5)
        Me.NuTotalLiquidar.Maximum = New Decimal(New Integer() {276447231, 23283, 0, 0})
        Me.NuTotalLiquidar.Name = "NuTotalLiquidar"
        Me.NuTotalLiquidar.Size = New System.Drawing.Size(124, 21)
        Me.NuTotalLiquidar.TabIndex = 46
        Me.NuTotalLiquidar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuTotalLiquidar.ThousandsSeparator = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label7.Location = New System.Drawing.Point(1072, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 15)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Total a Liquidar :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'NuTonSeleccion
        '
        Me.NuTonSeleccion.DecimalPlaces = 2
        Me.NuTonSeleccion.Enabled = False
        Me.NuTonSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuTonSeleccion.Location = New System.Drawing.Point(560, 5)
        Me.NuTonSeleccion.Maximum = New Decimal(New Integer() {276447231, 23283, 0, 0})
        Me.NuTonSeleccion.Name = "NuTonSeleccion"
        Me.NuTonSeleccion.Size = New System.Drawing.Size(124, 21)
        Me.NuTonSeleccion.TabIndex = 47
        Me.NuTonSeleccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuTonSeleccion.ThousandsSeparator = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label4.Location = New System.Drawing.Point(390, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 15)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Boletas Seleccionadas (Kg) :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 15)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Cuenta con Contrato Libre :"
        '
        'DgSeleccionLiquidaciones
        '
        Me.DgSeleccionLiquidaciones.AllowUserToAddRows = False
        Me.DgSeleccionLiquidaciones.AllowUserToDeleteRows = False
        Me.DgSeleccionLiquidaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgSeleccionLiquidaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DgSeleccionLiquidaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgSeleccionLiquidaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DgSeleccionLiquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgSeleccionLiquidaciones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DgSeleccionLiquidaciones.Location = New System.Drawing.Point(726, 30)
        Me.DgSeleccionLiquidaciones.MultiSelect = False
        Me.DgSeleccionLiquidaciones.Name = "DgSeleccionLiquidaciones"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgSeleccionLiquidaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DgSeleccionLiquidaciones.RowHeadersVisible = False
        Me.DgSeleccionLiquidaciones.RowHeadersWidth = 40
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgSeleccionLiquidaciones.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DgSeleccionLiquidaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgSeleccionLiquidaciones.Size = New System.Drawing.Size(574, 402)
        Me.DgSeleccionLiquidaciones.TabIndex = 40
        '
        'DgEntradasLiq
        '
        Me.DgEntradasLiq.AllowUserToAddRows = False
        Me.DgEntradasLiq.AllowUserToDeleteRows = False
        Me.DgEntradasLiq.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgEntradasLiq.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DgEntradasLiq.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgEntradasLiq.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DgEntradasLiq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgEntradasLiq.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DgEntradasLiq.Location = New System.Drawing.Point(6, 30)
        Me.DgEntradasLiq.Name = "DgEntradasLiq"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgEntradasLiq.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.DgEntradasLiq.RowHeadersVisible = False
        Me.DgEntradasLiq.RowHeadersWidth = 40
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgEntradasLiq.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.DgEntradasLiq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgEntradasLiq.Size = New System.Drawing.Size(678, 402)
        Me.DgEntradasLiq.TabIndex = 41
        '
        'TpBoletasLiquidadas
        '
        Me.TpBoletasLiquidadas.Controls.Add(Me.DgLiquidaciones)
        Me.TpBoletasLiquidadas.Location = New System.Drawing.Point(4, 22)
        Me.TpBoletasLiquidadas.Name = "TpBoletasLiquidadas"
        Me.TpBoletasLiquidadas.Padding = New System.Windows.Forms.Padding(3)
        Me.TpBoletasLiquidadas.Size = New System.Drawing.Size(1305, 438)
        Me.TpBoletasLiquidadas.TabIndex = 1
        Me.TpBoletasLiquidadas.Text = "Boletas Liquidadas"
        Me.TpBoletasLiquidadas.UseVisualStyleBackColor = True
        '
        'DgLiquidaciones
        '
        Me.DgLiquidaciones.AllowUserToAddRows = False
        Me.DgLiquidaciones.AllowUserToDeleteRows = False
        Me.DgLiquidaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgLiquidaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DgLiquidaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLiquidaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.DgLiquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgLiquidaciones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DgLiquidaciones.Location = New System.Drawing.Point(6, 30)
        Me.DgLiquidaciones.Name = "DgLiquidaciones"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLiquidaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.DgLiquidaciones.RowHeadersVisible = False
        Me.DgLiquidaciones.RowHeadersWidth = 40
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgLiquidaciones.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.DgLiquidaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLiquidaciones.Size = New System.Drawing.Size(678, 402)
        Me.DgLiquidaciones.TabIndex = 42
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 15)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "ID Productor :"
        '
        'TxProductor
        '
        Me.TxProductor.Enabled = False
        Me.TxProductor.Location = New System.Drawing.Point(135, 101)
        Me.TxProductor.Name = "TxProductor"
        Me.TxProductor.Size = New System.Drawing.Size(124, 20)
        Me.TxProductor.TabIndex = 53
        Me.TxProductor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 15)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Precio X tonelada :"
        '
        'NuPrecioTon
        '
        Me.NuPrecioTon.DecimalPlaces = 2
        Me.NuPrecioTon.Enabled = False
        Me.NuPrecioTon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuPrecioTon.Location = New System.Drawing.Point(135, 127)
        Me.NuPrecioTon.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.NuPrecioTon.Name = "NuPrecioTon"
        Me.NuPrecioTon.Size = New System.Drawing.Size(124, 21)
        Me.NuPrecioTon.TabIndex = 51
        Me.NuPrecioTon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuPrecioTon.ThousandsSeparator = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(265, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 15)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Toneladas Libres(Kg) :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(311, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Contrato (Kg) :"
        '
        'NuLibre
        '
        Me.NuLibre.DecimalPlaces = 2
        Me.NuLibre.Enabled = False
        Me.NuLibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuLibre.Location = New System.Drawing.Point(402, 127)
        Me.NuLibre.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.NuLibre.Name = "NuLibre"
        Me.NuLibre.Size = New System.Drawing.Size(124, 21)
        Me.NuLibre.TabIndex = 47
        Me.NuLibre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuLibre.ThousandsSeparator = True
        '
        'NuContrato
        '
        Me.NuContrato.DecimalPlaces = 2
        Me.NuContrato.Enabled = False
        Me.NuContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuContrato.Location = New System.Drawing.Point(402, 100)
        Me.NuContrato.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.NuContrato.Name = "NuContrato"
        Me.NuContrato.Size = New System.Drawing.Size(124, 21)
        Me.NuContrato.TabIndex = 48
        Me.NuContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuContrato.ThousandsSeparator = True
        '
        'BtGuardar
        '
        Me.BtGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BtGuardar.Location = New System.Drawing.Point(94, 12)
        Me.BtGuardar.Name = "BtGuardar"
        Me.BtGuardar.Size = New System.Drawing.Size(76, 72)
        Me.BtGuardar.TabIndex = 43
        Me.BtGuardar.Text = "Guardar"
        Me.BtGuardar.UseVisualStyleBackColor = True
        '
        'BtSalir
        '
        Me.BtSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BtSalir.Location = New System.Drawing.Point(258, 12)
        Me.BtSalir.Name = "BtSalir"
        Me.BtSalir.Size = New System.Drawing.Size(76, 72)
        Me.BtSalir.TabIndex = 44
        Me.BtSalir.Text = "Salir"
        Me.BtSalir.UseVisualStyleBackColor = True
        '
        'BtNuevo
        '
        Me.BtNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BtNuevo.Location = New System.Drawing.Point(12, 12)
        Me.BtNuevo.Name = "BtNuevo"
        Me.BtNuevo.Size = New System.Drawing.Size(76, 72)
        Me.BtNuevo.TabIndex = 45
        Me.BtNuevo.Text = "Nuevo"
        Me.BtNuevo.UseVisualStyleBackColor = True
        '
        'BtBuscar
        '
        Me.BtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BtBuscar.Location = New System.Drawing.Point(176, 12)
        Me.BtBuscar.Name = "BtBuscar"
        Me.BtBuscar.Size = New System.Drawing.Size(76, 72)
        Me.BtBuscar.TabIndex = 46
        Me.BtBuscar.Text = "Buscar"
        Me.BtBuscar.UseVisualStyleBackColor = True
        '
        'BtAgregarSeleccion
        '
        Me.BtAgregarSeleccion.BackColor = System.Drawing.Color.White
        Me.BtAgregarSeleccion.BackgroundImage = CType(resources.GetObject("BtAgregarSeleccion.BackgroundImage"), System.Drawing.Image)
        Me.BtAgregarSeleccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtAgregarSeleccion.Location = New System.Drawing.Point(690, 30)
        Me.BtAgregarSeleccion.Name = "BtAgregarSeleccion"
        Me.BtAgregarSeleccion.Size = New System.Drawing.Size(30, 30)
        Me.BtAgregarSeleccion.TabIndex = 42
        Me.BtAgregarSeleccion.UseVisualStyleBackColor = False
        '
        'LiquidacionXcomprador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1336, 630)
        Me.Controls.Add(Me.TbLiquidacionXProd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxProductor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NuPrecioTon)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NuLibre)
        Me.Controls.Add(Me.NuContrato)
        Me.Controls.Add(Me.BtGuardar)
        Me.Controls.Add(Me.BtSalir)
        Me.Controls.Add(Me.BtNuevo)
        Me.Controls.Add(Me.BtBuscar)
        Me.Name = "LiquidacionXcomprador"
        Me.Text = "LiquidacionXcomprador"
        Me.TbLiquidacionXProd.ResumeLayout(False)
        Me.TpBoletasXliquidar.ResumeLayout(False)
        Me.TpBoletasXliquidar.PerformLayout()
        CType(Me.NuTotalLiquidar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuTonSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgSeleccionLiquidaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgEntradasLiq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpBoletasLiquidadas.ResumeLayout(False)
        CType(Me.DgLiquidaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuPrecioTon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuLibre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuContrato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TbLiquidacionXProd As TabControl
    Friend WithEvents TpBoletasXliquidar As TabPage
    Friend WithEvents RbNo As RadioButton
    Friend WithEvents RbSi As RadioButton
    Friend WithEvents NuTotalLiquidar As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents NuTonSeleccion As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents BtAgregarSeleccion As Button
    Friend WithEvents DgSeleccionLiquidaciones As DataGridView
    Friend WithEvents DgEntradasLiq As DataGridView
    Friend WithEvents TpBoletasLiquidadas As TabPage
    Friend WithEvents DgLiquidaciones As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents TxProductor As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents NuPrecioTon As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents NuLibre As NumericUpDown
    Friend WithEvents NuContrato As NumericUpDown
    Friend WithEvents BtGuardar As Button
    Friend WithEvents BtSalir As Button
    Friend WithEvents BtNuevo As Button
    Friend WithEvents BtBuscar As Button
End Class
