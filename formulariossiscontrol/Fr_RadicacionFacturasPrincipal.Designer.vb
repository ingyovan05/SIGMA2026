<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_RadicacionFacturasPrincipal
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pn_Filtro = New System.Windows.Forms.Panel()
        Me.Tx_Nit = New System.Windows.Forms.TextBox()
        Me.Bt_BorrarFiltro = New System.Windows.Forms.Button()
        Me.Gb_Fechas = New System.Windows.Forms.GroupBox()
        Me.Tlp_Fechas = New System.Windows.Forms.TableLayoutPanel()
        Me.Lb_FechaDesde = New System.Windows.Forms.Label()
        Me.Dtp_FechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaHasta = New System.Windows.Forms.Label()
        Me.Dtp_FechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Lb_NIT = New System.Windows.Forms.Label()
        Me.Lb_Proveedor = New System.Windows.Forms.Label()
        Me.Tx_Proveedor = New System.Windows.Forms.TextBox()
        Me.Lb_Factura = New System.Windows.Forms.Label()
        Me.Tx_Factura = New System.Windows.Forms.TextBox()
        Me.Ck_PendientesRadicar = New System.Windows.Forms.CheckBox()
        Me.Flp_BotonesDer = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Dgv_Listado = New System.Windows.Forms.DataGridView()
        Me.Col_NitFormateado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_TipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Factura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Gerencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaRadicaPrincipal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_MarcarRadicado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Col_IdRecepcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Consecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_PersonaFuncionario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Dependencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdDependencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Memo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NumeroRelacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NroRadicado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NitSinFormato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cms_OpcionesListado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_EditarValor = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tss_Separador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Tsmi_MarcarSeleccionadas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_DesmarcarSeleccionadas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tlp_Botones = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_BotonesIzq = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_LimpiarMarcas = New System.Windows.Forms.Button()
        Me.Tc_ListadoFacturacion = New System.Windows.Forms.TabControl()
        Me.Tp_CorrespRecibida = New System.Windows.Forms.TabPage()
        Me.Tp_FacturaElectronica = New System.Windows.Forms.TabPage()
        Me.Dgv_FacturaElectronica = New System.Windows.Forms.DataGridView()
        Me.Col_FE_NitFormateado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FE_Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FE_TipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FE_Factura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FE_Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FE_Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FE_Gerencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FE_FechaRadicaPrincipal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FE_MarcarRadicado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Col_FE_IdAprobacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FE_Aprobacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FE_NitSinFormato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ti_AplicaFiltro = New System.Windows.Forms.Timer(Me.components)
        Me.Pn_Filtro.SuspendLayout()
        Me.Gb_Fechas.SuspendLayout()
        Me.Tlp_Fechas.SuspendLayout()
        Me.Flp_BotonesDer.SuspendLayout()
        CType(Me.Dgv_Listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_OpcionesListado.SuspendLayout()
        Me.Tlp_Botones.SuspendLayout()
        Me.Flp_BotonesIzq.SuspendLayout()
        Me.Tc_ListadoFacturacion.SuspendLayout()
        Me.Tp_CorrespRecibida.SuspendLayout()
        Me.Tp_FacturaElectronica.SuspendLayout()
        CType(Me.Dgv_FacturaElectronica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pn_Filtro
        '
        Me.Pn_Filtro.Controls.Add(Me.Tx_Nit)
        Me.Pn_Filtro.Controls.Add(Me.Bt_BorrarFiltro)
        Me.Pn_Filtro.Controls.Add(Me.Gb_Fechas)
        Me.Pn_Filtro.Controls.Add(Me.Lb_NIT)
        Me.Pn_Filtro.Controls.Add(Me.Lb_Proveedor)
        Me.Pn_Filtro.Controls.Add(Me.Tx_Proveedor)
        Me.Pn_Filtro.Controls.Add(Me.Lb_Factura)
        Me.Pn_Filtro.Controls.Add(Me.Tx_Factura)
        Me.Pn_Filtro.Controls.Add(Me.Ck_PendientesRadicar)
        Me.Pn_Filtro.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Filtro.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Filtro.Name = "Pn_Filtro"
        Me.Pn_Filtro.Size = New System.Drawing.Size(804, 116)
        Me.Pn_Filtro.TabIndex = 0
        '
        'Tx_Nit
        '
        Me.Tx_Nit.Location = New System.Drawing.Point(68, 63)
        Me.Tx_Nit.MaxLength = 20
        Me.Tx_Nit.Name = "Tx_Nit"
        Me.Tx_Nit.Size = New System.Drawing.Size(114, 20)
        Me.Tx_Nit.TabIndex = 2
        '
        'Bt_BorrarFiltro
        '
        Me.Bt_BorrarFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_BorrarFiltro.AutoSize = True
        Me.Bt_BorrarFiltro.Location = New System.Drawing.Point(718, 86)
        Me.Bt_BorrarFiltro.Name = "Bt_BorrarFiltro"
        Me.Bt_BorrarFiltro.Size = New System.Drawing.Size(75, 23)
        Me.Bt_BorrarFiltro.TabIndex = 8
        Me.Bt_BorrarFiltro.Text = "Borrar Filtro"
        Me.Bt_BorrarFiltro.UseVisualStyleBackColor = True
        '
        'Gb_Fechas
        '
        Me.Gb_Fechas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Gb_Fechas.Controls.Add(Me.Tlp_Fechas)
        Me.Gb_Fechas.Location = New System.Drawing.Point(12, 12)
        Me.Gb_Fechas.Name = "Gb_Fechas"
        Me.Gb_Fechas.Size = New System.Drawing.Size(780, 45)
        Me.Gb_Fechas.TabIndex = 0
        Me.Gb_Fechas.TabStop = False
        Me.Gb_Fechas.Text = "Fechas de Registro"
        '
        'Tlp_Fechas
        '
        Me.Tlp_Fechas.ColumnCount = 6
        Me.Tlp_Fechas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.Tlp_Fechas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.Tlp_Fechas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.Tlp_Fechas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.Tlp_Fechas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.Tlp_Fechas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Fechas.Controls.Add(Me.Lb_FechaDesde, 0, 0)
        Me.Tlp_Fechas.Controls.Add(Me.Dtp_FechaDesde, 1, 0)
        Me.Tlp_Fechas.Controls.Add(Me.Lb_FechaHasta, 3, 0)
        Me.Tlp_Fechas.Controls.Add(Me.Dtp_FechaHasta, 4, 0)
        Me.Tlp_Fechas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tlp_Fechas.Location = New System.Drawing.Point(3, 16)
        Me.Tlp_Fechas.Name = "Tlp_Fechas"
        Me.Tlp_Fechas.RowCount = 1
        Me.Tlp_Fechas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Fechas.Size = New System.Drawing.Size(774, 26)
        Me.Tlp_Fechas.TabIndex = 0
        '
        'Lb_FechaDesde
        '
        Me.Lb_FechaDesde.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_FechaDesde.AutoSize = True
        Me.Lb_FechaDesde.Location = New System.Drawing.Point(9, 0)
        Me.Lb_FechaDesde.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Lb_FechaDesde.Name = "Lb_FechaDesde"
        Me.Lb_FechaDesde.Size = New System.Drawing.Size(41, 26)
        Me.Lb_FechaDesde.TabIndex = 0
        Me.Lb_FechaDesde.Text = "Desde:"
        Me.Lb_FechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dtp_FechaDesde
        '
        Me.Dtp_FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaDesde.Location = New System.Drawing.Point(53, 3)
        Me.Dtp_FechaDesde.Name = "Dtp_FechaDesde"
        Me.Dtp_FechaDesde.Size = New System.Drawing.Size(94, 20)
        Me.Dtp_FechaDesde.TabIndex = 1
        '
        'Lb_FechaHasta
        '
        Me.Lb_FechaHasta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_FechaHasta.AutoSize = True
        Me.Lb_FechaHasta.Location = New System.Drawing.Point(212, 0)
        Me.Lb_FechaHasta.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Lb_FechaHasta.Name = "Lb_FechaHasta"
        Me.Lb_FechaHasta.Size = New System.Drawing.Size(38, 26)
        Me.Lb_FechaHasta.TabIndex = 2
        Me.Lb_FechaHasta.Text = "Hasta:"
        Me.Lb_FechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dtp_FechaHasta
        '
        Me.Dtp_FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaHasta.Location = New System.Drawing.Point(253, 3)
        Me.Dtp_FechaHasta.Name = "Dtp_FechaHasta"
        Me.Dtp_FechaHasta.Size = New System.Drawing.Size(94, 20)
        Me.Dtp_FechaHasta.TabIndex = 3
        '
        'Lb_NIT
        '
        Me.Lb_NIT.AutoSize = True
        Me.Lb_NIT.Location = New System.Drawing.Point(37, 66)
        Me.Lb_NIT.Name = "Lb_NIT"
        Me.Lb_NIT.Size = New System.Drawing.Size(28, 13)
        Me.Lb_NIT.TabIndex = 1
        Me.Lb_NIT.Text = "NIT:"
        '
        'Lb_Proveedor
        '
        Me.Lb_Proveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_Proveedor.AutoSize = True
        Me.Lb_Proveedor.Location = New System.Drawing.Point(206, 66)
        Me.Lb_Proveedor.Name = "Lb_Proveedor"
        Me.Lb_Proveedor.Size = New System.Drawing.Size(59, 13)
        Me.Lb_Proveedor.TabIndex = 3
        Me.Lb_Proveedor.Text = "Proveedor:"
        '
        'Tx_Proveedor
        '
        Me.Tx_Proveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Proveedor.Location = New System.Drawing.Point(268, 63)
        Me.Tx_Proveedor.Name = "Tx_Proveedor"
        Me.Tx_Proveedor.Size = New System.Drawing.Size(524, 20)
        Me.Tx_Proveedor.TabIndex = 4
        '
        'Lb_Factura
        '
        Me.Lb_Factura.AutoSize = True
        Me.Lb_Factura.Location = New System.Drawing.Point(19, 92)
        Me.Lb_Factura.Name = "Lb_Factura"
        Me.Lb_Factura.Size = New System.Drawing.Size(46, 13)
        Me.Lb_Factura.TabIndex = 5
        Me.Lb_Factura.Text = "Factura:"
        '
        'Tx_Factura
        '
        Me.Tx_Factura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Factura.Location = New System.Drawing.Point(68, 89)
        Me.Tx_Factura.Name = "Tx_Factura"
        Me.Tx_Factura.Size = New System.Drawing.Size(114, 20)
        Me.Tx_Factura.TabIndex = 6
        '
        'Ck_PendientesRadicar
        '
        Me.Ck_PendientesRadicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ck_PendientesRadicar.AutoSize = True
        Me.Ck_PendientesRadicar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_PendientesRadicar.Checked = True
        Me.Ck_PendientesRadicar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_PendientesRadicar.Location = New System.Drawing.Point(560, 90)
        Me.Ck_PendientesRadicar.Name = "Ck_PendientesRadicar"
        Me.Ck_PendientesRadicar.Size = New System.Drawing.Size(137, 17)
        Me.Ck_PendientesRadicar.TabIndex = 7
        Me.Ck_PendientesRadicar.Text = "Pendientes por Radicar"
        Me.Ck_PendientesRadicar.UseVisualStyleBackColor = True
        '
        'Flp_BotonesDer
        '
        Me.Flp_BotonesDer.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_BotonesDer.Controls.Add(Me.Bt_Guardar)
        Me.Flp_BotonesDer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_BotonesDer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_BotonesDer.Location = New System.Drawing.Point(139, 0)
        Me.Flp_BotonesDer.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_BotonesDer.Name = "Flp_BotonesDer"
        Me.Flp_BotonesDer.Size = New System.Drawing.Size(665, 30)
        Me.Flp_BotonesDer.TabIndex = 0
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(587, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Enabled = False
        Me.Bt_Guardar.Location = New System.Drawing.Point(506, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 1
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Dgv_Listado
        '
        Me.Dgv_Listado.AllowUserToAddRows = False
        Me.Dgv_Listado.AllowUserToDeleteRows = False
        Me.Dgv_Listado.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv_Listado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Listado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Listado.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_Listado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Listado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_NitFormateado, Me.Col_Proveedor, Me.Col_TipoDocumento, Me.Col_Factura, Me.Col_Valor, Me.Col_Moneda, Me.Col_Gerencia, Me.Col_FechaRadicaPrincipal, Me.Col_MarcarRadicado, Me.Col_IdRecepcion, Me.Col_Consecutivo, Me.Col_PersonaFuncionario, Me.Col_Descripcion, Me.Col_Dependencia, Me.Col_IdDependencia, Me.Col_Memo, Me.Col_NumeroRelacion, Me.Col_NroRadicado, Me.Col_NitSinFormato})
        Me.Dgv_Listado.ContextMenuStrip = Me.Cms_OpcionesListado
        Me.Dgv_Listado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Listado.Location = New System.Drawing.Point(3, 3)
        Me.Dgv_Listado.Name = "Dgv_Listado"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv_Listado.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_Listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Listado.Size = New System.Drawing.Size(790, 423)
        Me.Dgv_Listado.TabIndex = 0
        '
        'Col_NitFormateado
        '
        Me.Col_NitFormateado.DataPropertyName = "NITFORMATEADO"
        Me.Col_NitFormateado.HeaderText = "NIT"
        Me.Col_NitFormateado.Name = "Col_NitFormateado"
        Me.Col_NitFormateado.ReadOnly = True
        Me.Col_NitFormateado.ToolTipText = "NIT del Proveedor"
        '
        'Col_Proveedor
        '
        Me.Col_Proveedor.DataPropertyName = "DE"
        Me.Col_Proveedor.FillWeight = 200.0!
        Me.Col_Proveedor.HeaderText = "Proveedor"
        Me.Col_Proveedor.Name = "Col_Proveedor"
        Me.Col_Proveedor.ReadOnly = True
        Me.Col_Proveedor.ToolTipText = "Nombre o Razón Social del Proveedor"
        '
        'Col_TipoDocumento
        '
        Me.Col_TipoDocumento.DataPropertyName = "TIPODOCUMENTO"
        Me.Col_TipoDocumento.HeaderText = "Tipo Doc."
        Me.Col_TipoDocumento.Name = "Col_TipoDocumento"
        Me.Col_TipoDocumento.ReadOnly = True
        Me.Col_TipoDocumento.ToolTipText = "Tipo de Documento"
        '
        'Col_Factura
        '
        Me.Col_Factura.DataPropertyName = "NUMERODOCUMENTO"
        Me.Col_Factura.HeaderText = "No. Doc."
        Me.Col_Factura.Name = "Col_Factura"
        Me.Col_Factura.ReadOnly = True
        Me.Col_Factura.ToolTipText = "Número del Documento"
        '
        'Col_Valor
        '
        Me.Col_Valor.DataPropertyName = "VALOR"
        DataGridViewCellStyle3.Format = "C2"
        Me.Col_Valor.DefaultCellStyle = DataGridViewCellStyle3
        Me.Col_Valor.HeaderText = "Valor"
        Me.Col_Valor.Name = "Col_Valor"
        Me.Col_Valor.ReadOnly = True
        '
        'Col_Moneda
        '
        Me.Col_Moneda.DataPropertyName = "MONEDA"
        Me.Col_Moneda.FillWeight = 50.0!
        Me.Col_Moneda.HeaderText = "Mon."
        Me.Col_Moneda.Name = "Col_Moneda"
        Me.Col_Moneda.ReadOnly = True
        Me.Col_Moneda.ToolTipText = "Tipo de moneda o divisa"
        '
        'Col_Gerencia
        '
        Me.Col_Gerencia.DataPropertyName = "NOMBREGERENCIA"
        Me.Col_Gerencia.FillWeight = 150.0!
        Me.Col_Gerencia.HeaderText = "Gerencia"
        Me.Col_Gerencia.Name = "Col_Gerencia"
        Me.Col_Gerencia.ReadOnly = True
        '
        'Col_FechaRadicaPrincipal
        '
        Me.Col_FechaRadicaPrincipal.DataPropertyName = "FECHARECEPCION"
        Me.Col_FechaRadicaPrincipal.HeaderText = "Fecha Recep."
        Me.Col_FechaRadicaPrincipal.Name = "Col_FechaRadicaPrincipal"
        Me.Col_FechaRadicaPrincipal.ReadOnly = True
        Me.Col_FechaRadicaPrincipal.ToolTipText = "Fecha de radicado en Recepción"
        '
        'Col_MarcarRadicado
        '
        Me.Col_MarcarRadicado.DataPropertyName = "RADICADOCONTABILIDAD"
        Me.Col_MarcarRadicado.FalseValue = "N"
        Me.Col_MarcarRadicado.HeaderText = "Marcar Radicado"
        Me.Col_MarcarRadicado.Name = "Col_MarcarRadicado"
        Me.Col_MarcarRadicado.TrueValue = "S"
        '
        'Col_IdRecepcion
        '
        Me.Col_IdRecepcion.DataPropertyName = "IDRECEPCION"
        Me.Col_IdRecepcion.HeaderText = "Id Recepción"
        Me.Col_IdRecepcion.Name = "Col_IdRecepcion"
        Me.Col_IdRecepcion.ReadOnly = True
        Me.Col_IdRecepcion.Visible = False
        '
        'Col_Consecutivo
        '
        Me.Col_Consecutivo.DataPropertyName = "CONSECUTIVO"
        Me.Col_Consecutivo.HeaderText = "Consecutivo"
        Me.Col_Consecutivo.Name = "Col_Consecutivo"
        Me.Col_Consecutivo.ReadOnly = True
        Me.Col_Consecutivo.Visible = False
        '
        'Col_PersonaFuncionario
        '
        Me.Col_PersonaFuncionario.DataPropertyName = "PERSONAFUNCIONARIO"
        Me.Col_PersonaFuncionario.HeaderText = "Funcionario Para"
        Me.Col_PersonaFuncionario.Name = "Col_PersonaFuncionario"
        Me.Col_PersonaFuncionario.ReadOnly = True
        Me.Col_PersonaFuncionario.Visible = False
        '
        'Col_Descripcion
        '
        Me.Col_Descripcion.DataPropertyName = "DESCRIPCION"
        Me.Col_Descripcion.HeaderText = "Descripción"
        Me.Col_Descripcion.Name = "Col_Descripcion"
        Me.Col_Descripcion.ReadOnly = True
        Me.Col_Descripcion.Visible = False
        '
        'Col_Dependencia
        '
        Me.Col_Dependencia.DataPropertyName = "NOMBREDEPENDENCIA"
        Me.Col_Dependencia.HeaderText = "Dependencia"
        Me.Col_Dependencia.Name = "Col_Dependencia"
        Me.Col_Dependencia.ReadOnly = True
        Me.Col_Dependencia.Visible = False
        '
        'Col_IdDependencia
        '
        Me.Col_IdDependencia.DataPropertyName = "IDDEPENDENCIAPARA"
        Me.Col_IdDependencia.HeaderText = "Id Dependencia"
        Me.Col_IdDependencia.Name = "Col_IdDependencia"
        Me.Col_IdDependencia.ReadOnly = True
        Me.Col_IdDependencia.Visible = False
        '
        'Col_Memo
        '
        Me.Col_Memo.DataPropertyName = "MEMO"
        Me.Col_Memo.HeaderText = "Memo"
        Me.Col_Memo.Name = "Col_Memo"
        Me.Col_Memo.ReadOnly = True
        Me.Col_Memo.Visible = False
        '
        'Col_NumeroRelacion
        '
        Me.Col_NumeroRelacion.DataPropertyName = "NUMERORELACION"
        Me.Col_NumeroRelacion.HeaderText = "No. Relación"
        Me.Col_NumeroRelacion.Name = "Col_NumeroRelacion"
        Me.Col_NumeroRelacion.ReadOnly = True
        Me.Col_NumeroRelacion.Visible = False
        '
        'Col_NroRadicado
        '
        Me.Col_NroRadicado.DataPropertyName = "NRORADICADO"
        Me.Col_NroRadicado.HeaderText = "No. Radicado"
        Me.Col_NroRadicado.Name = "Col_NroRadicado"
        Me.Col_NroRadicado.ReadOnly = True
        Me.Col_NroRadicado.Visible = False
        '
        'Col_NitSinFormato
        '
        Me.Col_NitSinFormato.DataPropertyName = "NIT"
        Me.Col_NitSinFormato.HeaderText = "NIT sin Formato"
        Me.Col_NitSinFormato.Name = "Col_NitSinFormato"
        Me.Col_NitSinFormato.ReadOnly = True
        Me.Col_NitSinFormato.Visible = False
        '
        'Cms_OpcionesListado
        '
        Me.Cms_OpcionesListado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_EditarValor, Me.Tss_Separador1, Me.Tsmi_MarcarSeleccionadas, Me.Tsmi_DesmarcarSeleccionadas})
        Me.Cms_OpcionesListado.Name = "Cms_OpcionesListado"
        Me.Cms_OpcionesListado.Size = New System.Drawing.Size(207, 76)
        '
        'Tsmi_EditarValor
        '
        Me.Tsmi_EditarValor.Name = "Tsmi_EditarValor"
        Me.Tsmi_EditarValor.Size = New System.Drawing.Size(206, 22)
        Me.Tsmi_EditarValor.Text = "Editar Valor..."
        '
        'Tss_Separador1
        '
        Me.Tss_Separador1.Name = "Tss_Separador1"
        Me.Tss_Separador1.Size = New System.Drawing.Size(203, 6)
        '
        'Tsmi_MarcarSeleccionadas
        '
        Me.Tsmi_MarcarSeleccionadas.Name = "Tsmi_MarcarSeleccionadas"
        Me.Tsmi_MarcarSeleccionadas.Size = New System.Drawing.Size(206, 22)
        Me.Tsmi_MarcarSeleccionadas.Text = "Marcar seleccionadas"
        '
        'Tsmi_DesmarcarSeleccionadas
        '
        Me.Tsmi_DesmarcarSeleccionadas.Name = "Tsmi_DesmarcarSeleccionadas"
        Me.Tsmi_DesmarcarSeleccionadas.Size = New System.Drawing.Size(206, 22)
        Me.Tsmi_DesmarcarSeleccionadas.Text = "Desmarcar seleccionadas"
        '
        'Tlp_Botones
        '
        Me.Tlp_Botones.ColumnCount = 2
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Botones.Controls.Add(Me.Flp_BotonesIzq, 0, 0)
        Me.Tlp_Botones.Controls.Add(Me.Flp_BotonesDer, 1, 0)
        Me.Tlp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_Botones.Location = New System.Drawing.Point(0, 571)
        Me.Tlp_Botones.Name = "Tlp_Botones"
        Me.Tlp_Botones.RowCount = 1
        Me.Tlp_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Botones.Size = New System.Drawing.Size(804, 30)
        Me.Tlp_Botones.TabIndex = 2
        '
        'Flp_BotonesIzq
        '
        Me.Flp_BotonesIzq.AutoSize = True
        Me.Flp_BotonesIzq.Controls.Add(Me.Bt_LimpiarMarcas)
        Me.Flp_BotonesIzq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_BotonesIzq.Location = New System.Drawing.Point(0, 0)
        Me.Flp_BotonesIzq.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_BotonesIzq.Name = "Flp_BotonesIzq"
        Me.Flp_BotonesIzq.Size = New System.Drawing.Size(139, 30)
        Me.Flp_BotonesIzq.TabIndex = 0
        '
        'Bt_LimpiarMarcas
        '
        Me.Bt_LimpiarMarcas.AutoSize = True
        Me.Bt_LimpiarMarcas.Enabled = False
        Me.Bt_LimpiarMarcas.Location = New System.Drawing.Point(3, 3)
        Me.Bt_LimpiarMarcas.Name = "Bt_LimpiarMarcas"
        Me.Bt_LimpiarMarcas.Size = New System.Drawing.Size(133, 23)
        Me.Bt_LimpiarMarcas.TabIndex = 0
        Me.Bt_LimpiarMarcas.Text = "Limpiar todas las Marcas"
        Me.Bt_LimpiarMarcas.UseVisualStyleBackColor = True
        '
        'Tc_ListadoFacturacion
        '
        Me.Tc_ListadoFacturacion.Controls.Add(Me.Tp_CorrespRecibida)
        Me.Tc_ListadoFacturacion.Controls.Add(Me.Tp_FacturaElectronica)
        Me.Tc_ListadoFacturacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tc_ListadoFacturacion.Location = New System.Drawing.Point(0, 116)
        Me.Tc_ListadoFacturacion.Name = "Tc_ListadoFacturacion"
        Me.Tc_ListadoFacturacion.SelectedIndex = 0
        Me.Tc_ListadoFacturacion.Size = New System.Drawing.Size(804, 455)
        Me.Tc_ListadoFacturacion.TabIndex = 1
        '
        'Tp_CorrespRecibida
        '
        Me.Tp_CorrespRecibida.Controls.Add(Me.Dgv_Listado)
        Me.Tp_CorrespRecibida.Location = New System.Drawing.Point(4, 22)
        Me.Tp_CorrespRecibida.Name = "Tp_CorrespRecibida"
        Me.Tp_CorrespRecibida.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_CorrespRecibida.Size = New System.Drawing.Size(796, 429)
        Me.Tp_CorrespRecibida.TabIndex = 0
        Me.Tp_CorrespRecibida.Text = "Correspondencia Recibida"
        Me.Tp_CorrespRecibida.UseVisualStyleBackColor = True
        '
        'Tp_FacturaElectronica
        '
        Me.Tp_FacturaElectronica.Controls.Add(Me.Dgv_FacturaElectronica)
        Me.Tp_FacturaElectronica.Location = New System.Drawing.Point(4, 22)
        Me.Tp_FacturaElectronica.Name = "Tp_FacturaElectronica"
        Me.Tp_FacturaElectronica.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_FacturaElectronica.Size = New System.Drawing.Size(796, 429)
        Me.Tp_FacturaElectronica.TabIndex = 1
        Me.Tp_FacturaElectronica.Text = "Facturación Electrónica"
        Me.Tp_FacturaElectronica.UseVisualStyleBackColor = True
        '
        'Dgv_FacturaElectronica
        '
        Me.Dgv_FacturaElectronica.AllowUserToAddRows = False
        Me.Dgv_FacturaElectronica.AllowUserToDeleteRows = False
        Me.Dgv_FacturaElectronica.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv_FacturaElectronica.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Dgv_FacturaElectronica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_FacturaElectronica.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_FacturaElectronica.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Dgv_FacturaElectronica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_FacturaElectronica.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_FE_NitFormateado, Me.Col_FE_Proveedor, Me.Col_FE_TipoDocumento, Me.Col_FE_Factura, Me.Col_FE_Valor, Me.Col_FE_Moneda, Me.Col_FE_Gerencia, Me.Col_FE_FechaRadicaPrincipal, Me.Col_FE_MarcarRadicado, Me.Col_FE_IdAprobacion, Me.Col_FE_Aprobacion, Me.Col_FE_NitSinFormato})
        Me.Dgv_FacturaElectronica.ContextMenuStrip = Me.Cms_OpcionesListado
        Me.Dgv_FacturaElectronica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_FacturaElectronica.Location = New System.Drawing.Point(3, 3)
        Me.Dgv_FacturaElectronica.Name = "Dgv_FacturaElectronica"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv_FacturaElectronica.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.Dgv_FacturaElectronica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_FacturaElectronica.Size = New System.Drawing.Size(790, 423)
        Me.Dgv_FacturaElectronica.TabIndex = 0
        '
        'Col_FE_NitFormateado
        '
        Me.Col_FE_NitFormateado.DataPropertyName = "NITFORMATEADO"
        Me.Col_FE_NitFormateado.HeaderText = "NIT"
        Me.Col_FE_NitFormateado.Name = "Col_FE_NitFormateado"
        Me.Col_FE_NitFormateado.ReadOnly = True
        Me.Col_FE_NitFormateado.ToolTipText = "NIT del Proveedor"
        '
        'Col_FE_Proveedor
        '
        Me.Col_FE_Proveedor.DataPropertyName = "PROVEEDOR"
        Me.Col_FE_Proveedor.FillWeight = 200.0!
        Me.Col_FE_Proveedor.HeaderText = "Proveedor"
        Me.Col_FE_Proveedor.Name = "Col_FE_Proveedor"
        Me.Col_FE_Proveedor.ReadOnly = True
        Me.Col_FE_Proveedor.ToolTipText = "Nombre o Razón Social del Proveedor"
        '
        'Col_FE_TipoDocumento
        '
        Me.Col_FE_TipoDocumento.DataPropertyName = "TIPODOCUMENTO"
        Me.Col_FE_TipoDocumento.HeaderText = "Tipo Doc."
        Me.Col_FE_TipoDocumento.Name = "Col_FE_TipoDocumento"
        Me.Col_FE_TipoDocumento.ReadOnly = True
        Me.Col_FE_TipoDocumento.ToolTipText = "Tipo de Documento"
        '
        'Col_FE_Factura
        '
        Me.Col_FE_Factura.DataPropertyName = "NUMERODOCUMENTO"
        Me.Col_FE_Factura.HeaderText = "No. Doc."
        Me.Col_FE_Factura.Name = "Col_FE_Factura"
        Me.Col_FE_Factura.ReadOnly = True
        Me.Col_FE_Factura.ToolTipText = "Número del Documento"
        '
        'Col_FE_Valor
        '
        Me.Col_FE_Valor.DataPropertyName = "VALOR"
        DataGridViewCellStyle7.Format = "C2"
        Me.Col_FE_Valor.DefaultCellStyle = DataGridViewCellStyle7
        Me.Col_FE_Valor.HeaderText = "Valor"
        Me.Col_FE_Valor.Name = "Col_FE_Valor"
        Me.Col_FE_Valor.ReadOnly = True
        Me.Col_FE_Valor.ToolTipText = "Valor de la Factura"
        '
        'Col_FE_Moneda
        '
        Me.Col_FE_Moneda.DataPropertyName = "MONEDA"
        Me.Col_FE_Moneda.FillWeight = 50.0!
        Me.Col_FE_Moneda.HeaderText = "Mon."
        Me.Col_FE_Moneda.Name = "Col_FE_Moneda"
        Me.Col_FE_Moneda.ReadOnly = True
        Me.Col_FE_Moneda.ToolTipText = "Tipo de moneda o divisa"
        '
        'Col_FE_Gerencia
        '
        Me.Col_FE_Gerencia.DataPropertyName = "NOMBREGERENCIA"
        Me.Col_FE_Gerencia.FillWeight = 150.0!
        Me.Col_FE_Gerencia.HeaderText = "Gerencia"
        Me.Col_FE_Gerencia.Name = "Col_FE_Gerencia"
        Me.Col_FE_Gerencia.ReadOnly = True
        '
        'Col_FE_FechaRadicaPrincipal
        '
        Me.Col_FE_FechaRadicaPrincipal.DataPropertyName = "FECHAACEPTACION"
        Me.Col_FE_FechaRadicaPrincipal.HeaderText = "Fecha Recep."
        Me.Col_FE_FechaRadicaPrincipal.Name = "Col_FE_FechaRadicaPrincipal"
        Me.Col_FE_FechaRadicaPrincipal.ReadOnly = True
        Me.Col_FE_FechaRadicaPrincipal.ToolTipText = "Fecha de radicado en Recepción"
        '
        'Col_FE_MarcarRadicado
        '
        Me.Col_FE_MarcarRadicado.DataPropertyName = "RADICADOCONTABILIDAD"
        Me.Col_FE_MarcarRadicado.FalseValue = "N"
        Me.Col_FE_MarcarRadicado.HeaderText = "Marcar Radicado"
        Me.Col_FE_MarcarRadicado.Name = "Col_FE_MarcarRadicado"
        Me.Col_FE_MarcarRadicado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_FE_MarcarRadicado.TrueValue = "S"
        '
        'Col_FE_IdAprobacion
        '
        Me.Col_FE_IdAprobacion.DataPropertyName = "IDAPROBACION"
        Me.Col_FE_IdAprobacion.HeaderText = "IdAprobacion"
        Me.Col_FE_IdAprobacion.Name = "Col_FE_IdAprobacion"
        Me.Col_FE_IdAprobacion.ReadOnly = True
        Me.Col_FE_IdAprobacion.Visible = False
        '
        'Col_FE_Aprobacion
        '
        Me.Col_FE_Aprobacion.DataPropertyName = "APROBACION"
        Me.Col_FE_Aprobacion.HeaderText = "Aprobacion"
        Me.Col_FE_Aprobacion.Name = "Col_FE_Aprobacion"
        Me.Col_FE_Aprobacion.ReadOnly = True
        Me.Col_FE_Aprobacion.Visible = False
        '
        'Col_FE_NitSinFormato
        '
        Me.Col_FE_NitSinFormato.DataPropertyName = "NIT"
        Me.Col_FE_NitSinFormato.HeaderText = "NIT sin Formato"
        Me.Col_FE_NitSinFormato.Name = "Col_FE_NitSinFormato"
        Me.Col_FE_NitSinFormato.ReadOnly = True
        Me.Col_FE_NitSinFormato.Visible = False
        '
        'Ti_AplicaFiltro
        '
        Me.Ti_AplicaFiltro.Interval = 500
        '
        'Fr_RadicacionFacturasPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 601)
        Me.Controls.Add(Me.Tc_ListadoFacturacion)
        Me.Controls.Add(Me.Pn_Filtro)
        Me.Controls.Add(Me.Tlp_Botones)
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "Fr_RadicacionFacturasPrincipal"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Radicación de Facturas"
        Me.Pn_Filtro.ResumeLayout(False)
        Me.Pn_Filtro.PerformLayout()
        Me.Gb_Fechas.ResumeLayout(False)
        Me.Tlp_Fechas.ResumeLayout(False)
        Me.Tlp_Fechas.PerformLayout()
        Me.Flp_BotonesDer.ResumeLayout(False)
        CType(Me.Dgv_Listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_OpcionesListado.ResumeLayout(False)
        Me.Tlp_Botones.ResumeLayout(False)
        Me.Tlp_Botones.PerformLayout()
        Me.Flp_BotonesIzq.ResumeLayout(False)
        Me.Flp_BotonesIzq.PerformLayout()
        Me.Tc_ListadoFacturacion.ResumeLayout(False)
        Me.Tp_CorrespRecibida.ResumeLayout(False)
        Me.Tp_FacturaElectronica.ResumeLayout(False)
        CType(Me.Dgv_FacturaElectronica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Filtro As System.Windows.Forms.Panel
    Friend WithEvents Flp_BotonesDer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Dgv_Listado As System.Windows.Forms.DataGridView
    Friend WithEvents Lb_NIT As System.Windows.Forms.Label
    Friend WithEvents Lb_FechaHasta As System.Windows.Forms.Label
    Friend WithEvents Lb_FechaDesde As System.Windows.Forms.Label
    Friend WithEvents Tx_Factura As System.Windows.Forms.TextBox
    Friend WithEvents Dtp_FechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_FechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Ck_PendientesRadicar As System.Windows.Forms.CheckBox
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Lb_Factura As System.Windows.Forms.Label
    Friend WithEvents Gb_Fechas As System.Windows.Forms.GroupBox
    Friend WithEvents Tlp_Fechas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cms_OpcionesListado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_MarcarSeleccionadas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_DesmarcarSeleccionadas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tx_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Proveedor As System.Windows.Forms.Label
    Friend WithEvents Tlp_Botones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Flp_BotonesIzq As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_LimpiarMarcas As System.Windows.Forms.Button
    Friend WithEvents Bt_BorrarFiltro As System.Windows.Forms.Button
    Friend WithEvents Tc_ListadoFacturacion As System.Windows.Forms.TabControl
    Friend WithEvents Tp_CorrespRecibida As System.Windows.Forms.TabPage
    Friend WithEvents Tp_FacturaElectronica As System.Windows.Forms.TabPage
    Friend WithEvents Dgv_FacturaElectronica As System.Windows.Forms.DataGridView
    Friend WithEvents Col_NitFormateado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_TipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Factura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Gerencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaRadicaPrincipal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_MarcarRadicado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Col_IdRecepcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Consecutivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_PersonaFuncionario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Dependencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdDependencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Memo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NumeroRelacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NroRadicado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NitSinFormato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_NitFormateado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_TipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_Factura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_Gerencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_FechaRadicaPrincipal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_MarcarRadicado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Col_FE_IdAprobacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_Aprobacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FE_NitSinFormato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tsmi_EditarValor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tss_Separador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Ti_AplicaFiltro As System.Windows.Forms.Timer
    Friend WithEvents Tx_Nit As System.Windows.Forms.TextBox
End Class
