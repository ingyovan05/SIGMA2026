<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_ReporteDiario
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Dgv_Reportes = New System.Windows.Forms.DataGridView()
        Me.CMS_Opciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeleccionarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PortapapelesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_ClonarReporte = New System.Windows.Forms.ToolStripMenuItem()
        Me.OBSERVACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_VistaDatos = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Pn_TitiloMaestro = New System.Windows.Forms.Panel()
        Me.Lb_CantidadReportes = New System.Windows.Forms.Label()
        Me.PgDetalleReporte = New System.Windows.Forms.PropertyGrid()
        Me.Pn_Propiedades = New System.Windows.Forms.Panel()
        Me.Lb_Propiedades = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Dgv_ListaIntegrantes = New System.Windows.Forms.DataGridView()
        Me.DGVTBC_CONTRATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_NPERSONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DVGTBC_CATEGORIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_CARGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_HNORMALES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_HDIURNAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_HNOCTURNAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_HRNOCTURNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cms_IntegrantesReporte = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RegistrarNovedadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pn_TituloDetallePersonas = New System.Windows.Forms.Panel()
        Me.Lb_CantidadIntegrantes = New System.Windows.Forms.Label()
        Me.Dgv_ListaEquipos = New System.Windows.Forms.DataGridView()
        Me.DGVTBC_CEQUIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_INICIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_FINAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_DISPONIBLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_VARADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_OBSERVACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_TituloDetalleEquipos = New System.Windows.Forms.Panel()
        Me.Lb_CantidadEquipos = New System.Windows.Forms.Label()
        Me.Cms_OpcionesEquipo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RegistrarNovedadEquipoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EquiposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoverDeReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SacarDelReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarAlReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Nbc_Reportes = New NetBarControl.NetBarControl()
        Me.Nbg_Imprimir = New NetBarControl.NetBarGroup()
        Me.Nbi_Reporte = New NetBarControl.NetBarItem()
        Me.Nbi_ReporteBlanco = New NetBarControl.NetBarItem()
        Me.Nbi_ReporteSinDiligenciar = New NetBarControl.NetBarItem()
        Me.Nbi_Novedades = New NetBarControl.NetBarItem()
        Me.Nbi_NovedadesEquipos = New NetBarControl.NetBarItem()
        Me.Nbi_ReporteBasico = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirCEquipo = New NetBarControl.NetBarItem()
        Me.NetBarGroupControlContainer1 = New NetBarControl.NetBarGroupControlContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Bt_PerPendReportar = New System.Windows.Forms.Button()
        Me.Bt_SolicitudLiquidacion = New System.Windows.Forms.Button()
        Me.Bt_BonoTecnico = New System.Windows.Forms.Button()
        Me.Bt_ControlViaticos = New System.Windows.Forms.Button()
        Me.Bt_ReporteIncapacidades = New System.Windows.Forms.Button()
        Me.Bt_SinIncidencia = New System.Windows.Forms.Button()
        Me.Bt_AuxTransporte = New System.Windows.Forms.Button()
        Me.Bt_AuxAlimentacion = New System.Windows.Forms.Button()
        Me.Bt_GenerarSobretiempo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_FinPeriodo = New System.Windows.Forms.Label()
        Me.Lb_InicioPeriodo = New System.Windows.Forms.Label()
        Me.Cb_CorteNómina = New System.Windows.Forms.ComboBox()
        Me.Lb_Año = New System.Windows.Forms.Label()
        Me.Cb_AñoInforme = New System.Windows.Forms.ComboBox()
        Me.Lb_Corte = New System.Windows.Forms.Label()
        Me.Nbg_Reportes = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarReporteDiario = New NetBarControl.NetBarItem()
        Me.Nbi_Nuevo = New NetBarControl.NetBarItem()
        Me.Nbi_Clonar = New NetBarControl.NetBarItem()
        Me.Nbi_Modificar = New NetBarControl.NetBarItem()
        Me.Nbi_Habilitar = New NetBarControl.NetBarItem()
        Me.Nbi_Buscar = New NetBarControl.NetBarItem()
        Me.Separador = New NetBarControl.NetBarItem()
        Me.Nbi_ListarCuadrillas = New NetBarControl.NetBarItem()
        Me.Nbi_CrearCuadrilla = New NetBarControl.NetBarItem()
        Me.Nbi_EditarCaudrilla = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarCuadrillas = New NetBarControl.NetBarItem()
        Me.Nbg_ExportarExcelRD = New NetBarControl.NetBarGroup()
        Me.Nbi_RDxFechas = New NetBarControl.NetBarItem()
        Me.Nbi_RTxCodContrato = New NetBarControl.NetBarItem()
        Me.Nbg_Informes = New NetBarControl.NetBarGroup()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Pn_Detalle = New System.Windows.Forms.Panel()
        CType(Me.Dgv_Reportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_Opciones.SuspendLayout()
        Me.Pn_VistaDatos.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Pn_TitiloMaestro.SuspendLayout()
        Me.Pn_Propiedades.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Dgv_ListaIntegrantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_IntegrantesReporte.SuspendLayout()
        Me.Pn_TituloDetallePersonas.SuspendLayout()
        CType(Me.Dgv_ListaEquipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_TituloDetalleEquipos.SuspendLayout()
        Me.Cms_OpcionesEquipo.SuspendLayout()
        Me.Nbc_Reportes.SuspendLayout()
        Me.NetBarGroupControlContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Pn_Detalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_Reportes
        '
        Me.Dgv_Reportes.AllowUserToAddRows = False
        Me.Dgv_Reportes.AllowUserToDeleteRows = False
        Me.Dgv_Reportes.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Reportes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Reportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Reportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Reportes.ContextMenuStrip = Me.CMS_Opciones
        Me.Dgv_Reportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Reportes.Location = New System.Drawing.Point(0, 21)
        Me.Dgv_Reportes.Name = "Dgv_Reportes"
        Me.Dgv_Reportes.ReadOnly = True
        Me.Dgv_Reportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Reportes.Size = New System.Drawing.Size(452, 319)
        Me.Dgv_Reportes.TabIndex = 4
        '
        'CMS_Opciones
        '
        Me.CMS_Opciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CMS_Opciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarToolStripMenuItem, Me.TSMI_ClonarReporte})
        Me.CMS_Opciones.Name = "CMS_Opciones"
        Me.CMS_Opciones.Size = New System.Drawing.Size(154, 48)
        '
        'SeleccionarToolStripMenuItem
        '
        Me.SeleccionarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PortapapelesToolStripMenuItem})
        Me.SeleccionarToolStripMenuItem.Name = "SeleccionarToolStripMenuItem"
        Me.SeleccionarToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.SeleccionarToolStripMenuItem.Tag = "188"
        Me.SeleccionarToolStripMenuItem.Text = "Seleccionar"
        '
        'PortapapelesToolStripMenuItem
        '
        Me.PortapapelesToolStripMenuItem.Name = "PortapapelesToolStripMenuItem"
        Me.PortapapelesToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.PortapapelesToolStripMenuItem.Tag = "189"
        Me.PortapapelesToolStripMenuItem.Text = "Portapapeles"
        '
        'TSMI_ClonarReporte
        '
        Me.TSMI_ClonarReporte.Name = "TSMI_ClonarReporte"
        Me.TSMI_ClonarReporte.Size = New System.Drawing.Size(153, 22)
        Me.TSMI_ClonarReporte.Text = "Clonar Reporte"
        '
        'OBSERVACIONDataGridViewTextBoxColumn
        '
        Me.OBSERVACIONDataGridViewTextBoxColumn.DataPropertyName = "OBSERVACION"
        Me.OBSERVACIONDataGridViewTextBoxColumn.HeaderText = "Observación"
        Me.OBSERVACIONDataGridViewTextBoxColumn.Name = "OBSERVACIONDataGridViewTextBoxColumn"
        Me.OBSERVACIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.OBSERVACIONDataGridViewTextBoxColumn.Width = 92
        '
        'Pn_VistaDatos
        '
        Me.Pn_VistaDatos.Controls.Add(Me.SplitContainer1)
        Me.Pn_VistaDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_VistaDatos.Location = New System.Drawing.Point(241, 0)
        Me.Pn_VistaDatos.Name = "Pn_VistaDatos"
        Me.Pn_VistaDatos.Size = New System.Drawing.Size(751, 340)
        Me.Pn_VistaDatos.TabIndex = 5
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Dgv_Reportes)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Pn_TitiloMaestro)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PgDetalleReporte)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Pn_Propiedades)
        Me.SplitContainer1.Size = New System.Drawing.Size(751, 340)
        Me.SplitContainer1.SplitterDistance = 452
        Me.SplitContainer1.TabIndex = 11
        '
        'Pn_TitiloMaestro
        '
        Me.Pn_TitiloMaestro.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_TitiloMaestro.Controls.Add(Me.Lb_CantidadReportes)
        Me.Pn_TitiloMaestro.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TitiloMaestro.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TitiloMaestro.Name = "Pn_TitiloMaestro"
        Me.Pn_TitiloMaestro.Size = New System.Drawing.Size(452, 21)
        Me.Pn_TitiloMaestro.TabIndex = 7
        '
        'Lb_CantidadReportes
        '
        Me.Lb_CantidadReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_CantidadReportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadReportes.ForeColor = System.Drawing.Color.Black
        Me.Lb_CantidadReportes.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CantidadReportes.Name = "Lb_CantidadReportes"
        Me.Lb_CantidadReportes.Size = New System.Drawing.Size(452, 21)
        Me.Lb_CantidadReportes.TabIndex = 0
        Me.Lb_CantidadReportes.Text = "Cantidad de Reportes:"
        Me.Lb_CantidadReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PgDetalleReporte
        '
        Me.PgDetalleReporte.BackColor = System.Drawing.SystemColors.Control
        Me.PgDetalleReporte.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.PgDetalleReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PgDetalleReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PgDetalleReporte.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PgDetalleReporte.Location = New System.Drawing.Point(0, 21)
        Me.PgDetalleReporte.Name = "PgDetalleReporte"
        Me.PgDetalleReporte.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.PgDetalleReporte.Size = New System.Drawing.Size(295, 319)
        Me.PgDetalleReporte.TabIndex = 19
        '
        'Pn_Propiedades
        '
        Me.Pn_Propiedades.Controls.Add(Me.Lb_Propiedades)
        Me.Pn_Propiedades.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Propiedades.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Propiedades.Name = "Pn_Propiedades"
        Me.Pn_Propiedades.Size = New System.Drawing.Size(295, 21)
        Me.Pn_Propiedades.TabIndex = 2
        '
        'Lb_Propiedades
        '
        Me.Lb_Propiedades.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Lb_Propiedades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Propiedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Propiedades.ForeColor = System.Drawing.Color.Black
        Me.Lb_Propiedades.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Propiedades.Name = "Lb_Propiedades"
        Me.Lb_Propiedades.Size = New System.Drawing.Size(295, 21)
        Me.Lb_Propiedades.TabIndex = 1
        Me.Lb_Propiedades.Text = "Propiedades"
        Me.Lb_Propiedades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Dgv_ListaIntegrantes)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Pn_TituloDetallePersonas)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Dgv_ListaEquipos)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Pn_TituloDetalleEquipos)
        Me.SplitContainer2.Size = New System.Drawing.Size(751, 200)
        Me.SplitContainer2.SplitterDistance = 469
        Me.SplitContainer2.TabIndex = 11
        '
        'Dgv_ListaIntegrantes
        '
        Me.Dgv_ListaIntegrantes.AllowUserToAddRows = False
        Me.Dgv_ListaIntegrantes.AllowUserToDeleteRows = False
        Me.Dgv_ListaIntegrantes.AllowUserToOrderColumns = True
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Dgv_ListaIntegrantes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_ListaIntegrantes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_ListaIntegrantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBC_CONTRATO, Me.DGVTBC_NPERSONA, Me.DVGTBC_CATEGORIA, Me.DGVTBC_CARGO, Me.DGVTBC_TOTAL, Me.DGVTBC_HNORMALES, Me.DGVTBC_HDIURNAS, Me.DGVTBC_HNOCTURNAS, Me.DGVTBC_HRNOCTURNO})
        Me.Dgv_ListaIntegrantes.ContextMenuStrip = Me.Cms_IntegrantesReporte
        Me.Dgv_ListaIntegrantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaIntegrantes.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_ListaIntegrantes.Name = "Dgv_ListaIntegrantes"
        Me.Dgv_ListaIntegrantes.ReadOnly = True
        Me.Dgv_ListaIntegrantes.Size = New System.Drawing.Size(469, 182)
        Me.Dgv_ListaIntegrantes.TabIndex = 6
        '
        'DGVTBC_CONTRATO
        '
        Me.DGVTBC_CONTRATO.DataPropertyName = "CODIGOCONTRATO"
        Me.DGVTBC_CONTRATO.FillWeight = 60.0!
        Me.DGVTBC_CONTRATO.HeaderText = "Contrato"
        Me.DGVTBC_CONTRATO.Name = "DGVTBC_CONTRATO"
        Me.DGVTBC_CONTRATO.ReadOnly = True
        Me.DGVTBC_CONTRATO.Width = 70
        '
        'DGVTBC_NPERSONA
        '
        Me.DGVTBC_NPERSONA.DataPropertyName = "NOMBREPERSONA"
        Me.DGVTBC_NPERSONA.HeaderText = "Nombre"
        Me.DGVTBC_NPERSONA.Name = "DGVTBC_NPERSONA"
        Me.DGVTBC_NPERSONA.ReadOnly = True
        Me.DGVTBC_NPERSONA.Width = 150
        '
        'DVGTBC_CATEGORIA
        '
        Me.DVGTBC_CATEGORIA.DataPropertyName = "CODIGOTIPOCATEGORIAPERSONAL"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DVGTBC_CATEGORIA.DefaultCellStyle = DataGridViewCellStyle5
        Me.DVGTBC_CATEGORIA.HeaderText = "Cat"
        Me.DVGTBC_CATEGORIA.Name = "DVGTBC_CATEGORIA"
        Me.DVGTBC_CATEGORIA.ReadOnly = True
        Me.DVGTBC_CATEGORIA.Width = 40
        '
        'DGVTBC_CARGO
        '
        Me.DGVTBC_CARGO.DataPropertyName = "NOMBRETIPOCARGO"
        Me.DGVTBC_CARGO.HeaderText = "Cargo"
        Me.DGVTBC_CARGO.Name = "DGVTBC_CARGO"
        Me.DGVTBC_CARGO.ReadOnly = True
        Me.DGVTBC_CARGO.Width = 120
        '
        'DGVTBC_TOTAL
        '
        Me.DGVTBC_TOTAL.DataPropertyName = "TOTAL"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGVTBC_TOTAL.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGVTBC_TOTAL.HeaderText = "Total"
        Me.DGVTBC_TOTAL.MaxInputLength = 3
        Me.DGVTBC_TOTAL.Name = "DGVTBC_TOTAL"
        Me.DGVTBC_TOTAL.ReadOnly = True
        Me.DGVTBC_TOTAL.Width = 40
        '
        'DGVTBC_HNORMALES
        '
        Me.DGVTBC_HNORMALES.DataPropertyName = "HN"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGVTBC_HNORMALES.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGVTBC_HNORMALES.HeaderText = "HN"
        Me.DGVTBC_HNORMALES.MaxInputLength = 3
        Me.DGVTBC_HNORMALES.Name = "DGVTBC_HNORMALES"
        Me.DGVTBC_HNORMALES.ReadOnly = True
        Me.DGVTBC_HNORMALES.Width = 40
        '
        'DGVTBC_HDIURNAS
        '
        Me.DGVTBC_HDIURNAS.DataPropertyName = "HED"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGVTBC_HDIURNAS.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGVTBC_HDIURNAS.HeaderText = "HED"
        Me.DGVTBC_HDIURNAS.MaxInputLength = 3
        Me.DGVTBC_HDIURNAS.Name = "DGVTBC_HDIURNAS"
        Me.DGVTBC_HDIURNAS.ReadOnly = True
        Me.DGVTBC_HDIURNAS.Width = 40
        '
        'DGVTBC_HNOCTURNAS
        '
        Me.DGVTBC_HNOCTURNAS.DataPropertyName = "HEN"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGVTBC_HNOCTURNAS.DefaultCellStyle = DataGridViewCellStyle9
        Me.DGVTBC_HNOCTURNAS.HeaderText = "HEN"
        Me.DGVTBC_HNOCTURNAS.MaxInputLength = 3
        Me.DGVTBC_HNOCTURNAS.Name = "DGVTBC_HNOCTURNAS"
        Me.DGVTBC_HNOCTURNAS.ReadOnly = True
        Me.DGVTBC_HNOCTURNAS.Width = 40
        '
        'DGVTBC_HRNOCTURNO
        '
        Me.DGVTBC_HRNOCTURNO.DataPropertyName = "RN"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGVTBC_HRNOCTURNO.DefaultCellStyle = DataGridViewCellStyle10
        Me.DGVTBC_HRNOCTURNO.HeaderText = "RN"
        Me.DGVTBC_HRNOCTURNO.MaxInputLength = 3
        Me.DGVTBC_HRNOCTURNO.Name = "DGVTBC_HRNOCTURNO"
        Me.DGVTBC_HRNOCTURNO.ReadOnly = True
        Me.DGVTBC_HRNOCTURNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVTBC_HRNOCTURNO.Width = 40
        '
        'Cms_IntegrantesReporte
        '
        Me.Cms_IntegrantesReporte.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_IntegrantesReporte.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarNovedadToolStripMenuItem})
        Me.Cms_IntegrantesReporte.Name = "Cms_IntegrantesReporte"
        Me.Cms_IntegrantesReporte.Size = New System.Drawing.Size(172, 26)
        '
        'RegistrarNovedadToolStripMenuItem
        '
        Me.RegistrarNovedadToolStripMenuItem.Name = "RegistrarNovedadToolStripMenuItem"
        Me.RegistrarNovedadToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.RegistrarNovedadToolStripMenuItem.Tag = "761"
        Me.RegistrarNovedadToolStripMenuItem.Text = "Registrar Novedad"
        '
        'Pn_TituloDetallePersonas
        '
        Me.Pn_TituloDetallePersonas.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_TituloDetallePersonas.Controls.Add(Me.Lb_CantidadIntegrantes)
        Me.Pn_TituloDetallePersonas.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloDetallePersonas.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloDetallePersonas.Name = "Pn_TituloDetallePersonas"
        Me.Pn_TituloDetallePersonas.Size = New System.Drawing.Size(469, 18)
        Me.Pn_TituloDetallePersonas.TabIndex = 5
        '
        'Lb_CantidadIntegrantes
        '
        Me.Lb_CantidadIntegrantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_CantidadIntegrantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadIntegrantes.ForeColor = System.Drawing.Color.Black
        Me.Lb_CantidadIntegrantes.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CantidadIntegrantes.Name = "Lb_CantidadIntegrantes"
        Me.Lb_CantidadIntegrantes.Size = New System.Drawing.Size(469, 18)
        Me.Lb_CantidadIntegrantes.TabIndex = 0
        Me.Lb_CantidadIntegrantes.Text = "Lista de personas asociadas al reporte            Cantidad: "
        Me.Lb_CantidadIntegrantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Dgv_ListaEquipos
        '
        Me.Dgv_ListaEquipos.AllowUserToAddRows = False
        Me.Dgv_ListaEquipos.AllowUserToDeleteRows = False
        Me.Dgv_ListaEquipos.AllowUserToOrderColumns = True
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Dgv_ListaEquipos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.Dgv_ListaEquipos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Dgv_ListaEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ListaEquipos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBC_CEQUIPO, Me.DGVTBC_DESCRIPCION, Me.DataGridViewTextBoxColumn1, Me.DGVTBC_INICIAL, Me.DGVTBC_FINAL, Me.DGVTBC_DISPONIBLE, Me.DGVTBC_VARADO, Me.DGVTBC_OBSERVACION})
        Me.Dgv_ListaEquipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaEquipos.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_ListaEquipos.Name = "Dgv_ListaEquipos"
        Me.Dgv_ListaEquipos.Size = New System.Drawing.Size(278, 182)
        Me.Dgv_ListaEquipos.TabIndex = 10
        '
        'DGVTBC_CEQUIPO
        '
        Me.DGVTBC_CEQUIPO.DataPropertyName = "CODIGOEQUIPO"
        Me.DGVTBC_CEQUIPO.HeaderText = "Codigo Equipo"
        Me.DGVTBC_CEQUIPO.Name = "DGVTBC_CEQUIPO"
        '
        'DGVTBC_DESCRIPCION
        '
        Me.DGVTBC_DESCRIPCION.DataPropertyName = "DESCRIPCION"
        Me.DGVTBC_DESCRIPCION.HeaderText = "Descripcion"
        Me.DGVTBC_DESCRIPCION.Name = "DGVTBC_DESCRIPCION"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "TOTAL"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DGVTBC_INICIAL
        '
        Me.DGVTBC_INICIAL.DataPropertyName = "INICIAL"
        Me.DGVTBC_INICIAL.HeaderText = "Inicial"
        Me.DGVTBC_INICIAL.Name = "DGVTBC_INICIAL"
        '
        'DGVTBC_FINAL
        '
        Me.DGVTBC_FINAL.DataPropertyName = "FINAL"
        Me.DGVTBC_FINAL.HeaderText = "Final"
        Me.DGVTBC_FINAL.Name = "DGVTBC_FINAL"
        '
        'DGVTBC_DISPONIBLE
        '
        Me.DGVTBC_DISPONIBLE.DataPropertyName = "DISPONIBLE"
        Me.DGVTBC_DISPONIBLE.HeaderText = "Disponible"
        Me.DGVTBC_DISPONIBLE.Name = "DGVTBC_DISPONIBLE"
        '
        'DGVTBC_VARADO
        '
        Me.DGVTBC_VARADO.DataPropertyName = "VARADO"
        Me.DGVTBC_VARADO.HeaderText = "Varado"
        Me.DGVTBC_VARADO.Name = "DGVTBC_VARADO"
        '
        'DGVTBC_OBSERVACION
        '
        Me.DGVTBC_OBSERVACION.DataPropertyName = "OBSERVACION"
        Me.DGVTBC_OBSERVACION.HeaderText = "Observación"
        Me.DGVTBC_OBSERVACION.Name = "DGVTBC_OBSERVACION"
        '
        'Pn_TituloDetalleEquipos
        '
        Me.Pn_TituloDetalleEquipos.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_TituloDetalleEquipos.Controls.Add(Me.Lb_CantidadEquipos)
        Me.Pn_TituloDetalleEquipos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloDetalleEquipos.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloDetalleEquipos.Name = "Pn_TituloDetalleEquipos"
        Me.Pn_TituloDetalleEquipos.Size = New System.Drawing.Size(278, 18)
        Me.Pn_TituloDetalleEquipos.TabIndex = 9
        '
        'Lb_CantidadEquipos
        '
        Me.Lb_CantidadEquipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_CantidadEquipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadEquipos.ForeColor = System.Drawing.Color.Black
        Me.Lb_CantidadEquipos.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CantidadEquipos.Name = "Lb_CantidadEquipos"
        Me.Lb_CantidadEquipos.Size = New System.Drawing.Size(278, 18)
        Me.Lb_CantidadEquipos.TabIndex = 0
        Me.Lb_CantidadEquipos.Text = "Lista de equipos asociadas al reporte            Cantidad: "
        Me.Lb_CantidadEquipos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cms_OpcionesEquipo
        '
        Me.Cms_OpcionesEquipo.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_OpcionesEquipo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarNovedadEquipoToolStripMenuItem, Me.EquiposToolStripMenuItem})
        Me.Cms_OpcionesEquipo.Name = "Cms_OpcionesEquipo"
        Me.Cms_OpcionesEquipo.Size = New System.Drawing.Size(172, 48)
        Me.Cms_OpcionesEquipo.Tag = ""
        '
        'RegistrarNovedadEquipoToolStripMenuItem
        '
        Me.RegistrarNovedadEquipoToolStripMenuItem.Name = "RegistrarNovedadEquipoToolStripMenuItem"
        Me.RegistrarNovedadEquipoToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.RegistrarNovedadEquipoToolStripMenuItem.Tag = "225"
        Me.RegistrarNovedadEquipoToolStripMenuItem.Text = "Registrar Novedad"
        '
        'EquiposToolStripMenuItem
        '
        Me.EquiposToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoverDeReporteToolStripMenuItem, Me.SacarDelReporteToolStripMenuItem, Me.AgregarAlReporteToolStripMenuItem})
        Me.EquiposToolStripMenuItem.Name = "EquiposToolStripMenuItem"
        Me.EquiposToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.EquiposToolStripMenuItem.Tag = "190"
        Me.EquiposToolStripMenuItem.Text = "Equipos"
        '
        'MoverDeReporteToolStripMenuItem
        '
        Me.MoverDeReporteToolStripMenuItem.Name = "MoverDeReporteToolStripMenuItem"
        Me.MoverDeReporteToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.MoverDeReporteToolStripMenuItem.Tag = "193"
        Me.MoverDeReporteToolStripMenuItem.Text = "Mover de Reporte"
        '
        'SacarDelReporteToolStripMenuItem
        '
        Me.SacarDelReporteToolStripMenuItem.Name = "SacarDelReporteToolStripMenuItem"
        Me.SacarDelReporteToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SacarDelReporteToolStripMenuItem.Tag = "191"
        Me.SacarDelReporteToolStripMenuItem.Text = "Sacar del Reporte"
        '
        'AgregarAlReporteToolStripMenuItem
        '
        Me.AgregarAlReporteToolStripMenuItem.Name = "AgregarAlReporteToolStripMenuItem"
        Me.AgregarAlReporteToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.AgregarAlReporteToolStripMenuItem.Tag = "192"
        Me.AgregarAlReporteToolStripMenuItem.Text = "Agregar al Reporte"
        '
        'Nbc_Reportes
        '
        Me.Nbc_Reportes.ActiveGroup = Me.Nbg_Informes
        Me.Nbc_Reportes.Controls.Add(Me.NetBarGroupControlContainer1)
        Me.Nbc_Reportes.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_Reportes.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_Reportes, Me.Nbg_Imprimir, Me.Nbg_ExportarExcelRD, Me.Nbg_Informes})
        Me.Nbc_Reportes.GroupsFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Reportes.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_Reportes.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_Reportes.Location = New System.Drawing.Point(0, 0)
        Me.Nbc_Reportes.Name = "Nbc_Reportes"
        Me.Nbc_Reportes.ShowOverflowButton = False
        Me.Nbc_Reportes.ShowOverflowPanel = False
        Me.Nbc_Reportes.Size = New System.Drawing.Size(241, 543)
        Me.Nbc_Reportes.TabIndex = 8
        Me.Nbc_Reportes.Tag = "680"
        Me.Nbc_Reportes.Text = "Reportes Diarios"
        '
        'Nbg_Imprimir
        '
        Me.Nbg_Imprimir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Nbg_Imprimir.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_Reporte, Me.Nbi_ReporteBlanco, Me.Nbi_ReporteSinDiligenciar, Me.Nbi_Novedades, Me.Nbi_NovedadesEquipos, Me.Nbi_ReporteBasico, Me.Nbi_ImprimirCEquipo})
        Me.Nbg_Imprimir.Name = "Nbg_Imprimir"
        Me.Nbg_Imprimir.SmallImage = Global.Reportediario.My.Resources.Resources.Printer
        Me.Nbg_Imprimir.Tag = "682"
        Me.Nbg_Imprimir.Text = "Imprimir"
        '
        'Nbi_Reporte
        '
        Me.Nbi_Reporte.Name = "Nbi_Reporte"
        Me.Nbi_Reporte.SmallImage = Global.Reportediario.My.Resources.Resources.ImprimirReporte
        Me.Nbi_Reporte.Tag = "683"
        Me.Nbi_Reporte.Text = "Imprimir Reporte Técnico"
        '
        'Nbi_ReporteBlanco
        '
        Me.Nbi_ReporteBlanco.Name = "Nbi_ReporteBlanco"
        Me.Nbi_ReporteBlanco.SmallImage = Global.Reportediario.My.Resources.Resources.ImprimirReporteBlanco
        Me.Nbi_ReporteBlanco.Tag = "684"
        Me.Nbi_ReporteBlanco.Text = "Imprimir Reporte Tecnico en Blanco"
        '
        'Nbi_ReporteSinDiligenciar
        '
        Me.Nbi_ReporteSinDiligenciar.Name = "Nbi_ReporteSinDiligenciar"
        Me.Nbi_ReporteSinDiligenciar.SmallImage = Global.Reportediario.My.Resources.Resources.ImprimirReporteSinDiligenciar
        Me.Nbi_ReporteSinDiligenciar.Tag = "685"
        Me.Nbi_ReporteSinDiligenciar.Text = "Imprimir Reporte Sin Diligenciar"
        '
        'Nbi_Novedades
        '
        Me.Nbi_Novedades.Name = "Nbi_Novedades"
        Me.Nbi_Novedades.SmallImage = Global.Reportediario.My.Resources.Resources.ImprimirReporteNovedad_2
        Me.Nbi_Novedades.Tag = "686"
        Me.Nbi_Novedades.Text = "Imprimir Novedades Personas"
        '
        'Nbi_NovedadesEquipos
        '
        Me.Nbi_NovedadesEquipos.Name = "Nbi_NovedadesEquipos"
        Me.Nbi_NovedadesEquipos.SmallImage = Global.Reportediario.My.Resources.Resources.ImprimirReporteNovedadPersonaEquipo
        Me.Nbi_NovedadesEquipos.Tag = "687"
        Me.Nbi_NovedadesEquipos.Text = "Imprimir Novedades Equipos"
        '
        'Nbi_ReporteBasico
        '
        Me.Nbi_ReporteBasico.Name = "Nbi_ReporteBasico"
        Me.Nbi_ReporteBasico.Tag = "722"
        Me.Nbi_ReporteBasico.Text = "Imprimir Reporte Básico"
        '
        'Nbi_ImprimirCEquipo
        '
        Me.Nbi_ImprimirCEquipo.Name = "Nbi_ImprimirCEquipo"
        Me.Nbi_ImprimirCEquipo.Text = "Imprimir Control Equipo"
        '
        'NetBarGroupControlContainer1
        '
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Panel2)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Panel1)
        Me.NetBarGroupControlContainer1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.NetBarGroupControlContainer1.Name = "NetBarGroupControlContainer1"
        Me.NetBarGroupControlContainer1.Size = New System.Drawing.Size(232, 384)
        Me.NetBarGroupControlContainer1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Bt_PerPendReportar)
        Me.Panel2.Controls.Add(Me.Bt_SolicitudLiquidacion)
        Me.Panel2.Controls.Add(Me.Bt_BonoTecnico)
        Me.Panel2.Controls.Add(Me.Bt_ControlViaticos)
        Me.Panel2.Controls.Add(Me.Bt_ReporteIncapacidades)
        Me.Panel2.Controls.Add(Me.Bt_SinIncidencia)
        Me.Panel2.Controls.Add(Me.Bt_AuxTransporte)
        Me.Panel2.Controls.Add(Me.Bt_AuxAlimentacion)
        Me.Panel2.Controls.Add(Me.Bt_GenerarSobretiempo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 123)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(232, 261)
        Me.Panel2.TabIndex = 12
        '
        'Bt_PerPendReportar
        '
        Me.Bt_PerPendReportar.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_PerPendReportar.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Bt_PerPendReportar.Location = New System.Drawing.Point(0, 224)
        Me.Bt_PerPendReportar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_PerPendReportar.Name = "Bt_PerPendReportar"
        Me.Bt_PerPendReportar.Size = New System.Drawing.Size(232, 28)
        Me.Bt_PerPendReportar.TabIndex = 13
        Me.Bt_PerPendReportar.Tag = ""
        Me.Bt_PerPendReportar.Text = "Personas Pendientes de Reportar"
        Me.Bt_PerPendReportar.UseVisualStyleBackColor = True
        '
        'Bt_SolicitudLiquidacion
        '
        Me.Bt_SolicitudLiquidacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_SolicitudLiquidacion.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Bt_SolicitudLiquidacion.Location = New System.Drawing.Point(0, 196)
        Me.Bt_SolicitudLiquidacion.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_SolicitudLiquidacion.Name = "Bt_SolicitudLiquidacion"
        Me.Bt_SolicitudLiquidacion.Size = New System.Drawing.Size(232, 28)
        Me.Bt_SolicitudLiquidacion.TabIndex = 12
        Me.Bt_SolicitudLiquidacion.Tag = "750"
        Me.Bt_SolicitudLiquidacion.Text = "Solicitud Liquidación Final Contrato"
        Me.Bt_SolicitudLiquidacion.UseVisualStyleBackColor = True
        '
        'Bt_BonoTecnico
        '
        Me.Bt_BonoTecnico.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_BonoTecnico.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Bt_BonoTecnico.Location = New System.Drawing.Point(0, 168)
        Me.Bt_BonoTecnico.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_BonoTecnico.Name = "Bt_BonoTecnico"
        Me.Bt_BonoTecnico.Size = New System.Drawing.Size(232, 28)
        Me.Bt_BonoTecnico.TabIndex = 9
        Me.Bt_BonoTecnico.Tag = "742"
        Me.Bt_BonoTecnico.Text = "Generar Bono Técnico"
        Me.Bt_BonoTecnico.UseVisualStyleBackColor = True
        '
        'Bt_ControlViaticos
        '
        Me.Bt_ControlViaticos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_ControlViaticos.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Bt_ControlViaticos.Location = New System.Drawing.Point(0, 140)
        Me.Bt_ControlViaticos.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_ControlViaticos.Name = "Bt_ControlViaticos"
        Me.Bt_ControlViaticos.Size = New System.Drawing.Size(232, 28)
        Me.Bt_ControlViaticos.TabIndex = 11
        Me.Bt_ControlViaticos.Tag = "744"
        Me.Bt_ControlViaticos.Text = "Generar Control de Viáticos"
        Me.Bt_ControlViaticos.UseVisualStyleBackColor = True
        '
        'Bt_ReporteIncapacidades
        '
        Me.Bt_ReporteIncapacidades.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_ReporteIncapacidades.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Bt_ReporteIncapacidades.Location = New System.Drawing.Point(0, 112)
        Me.Bt_ReporteIncapacidades.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_ReporteIncapacidades.Name = "Bt_ReporteIncapacidades"
        Me.Bt_ReporteIncapacidades.Size = New System.Drawing.Size(232, 28)
        Me.Bt_ReporteIncapacidades.TabIndex = 10
        Me.Bt_ReporteIncapacidades.Tag = "743"
        Me.Bt_ReporteIncapacidades.Text = "Generar Novedades"
        Me.Bt_ReporteIncapacidades.UseVisualStyleBackColor = True
        '
        'Bt_SinIncidencia
        '
        Me.Bt_SinIncidencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_SinIncidencia.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Bt_SinIncidencia.Location = New System.Drawing.Point(0, 84)
        Me.Bt_SinIncidencia.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_SinIncidencia.Name = "Bt_SinIncidencia"
        Me.Bt_SinIncidencia.Size = New System.Drawing.Size(232, 28)
        Me.Bt_SinIncidencia.TabIndex = 8
        Me.Bt_SinIncidencia.Tag = "741"
        Me.Bt_SinIncidencia.Text = "Generar Aux. Sin Incidencia"
        Me.Bt_SinIncidencia.UseVisualStyleBackColor = True
        '
        'Bt_AuxTransporte
        '
        Me.Bt_AuxTransporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_AuxTransporte.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Bt_AuxTransporte.Location = New System.Drawing.Point(0, 56)
        Me.Bt_AuxTransporte.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_AuxTransporte.Name = "Bt_AuxTransporte"
        Me.Bt_AuxTransporte.Size = New System.Drawing.Size(232, 28)
        Me.Bt_AuxTransporte.TabIndex = 6
        Me.Bt_AuxTransporte.Tag = "739"
        Me.Bt_AuxTransporte.Text = "Generar Aux. De Transporte"
        Me.Bt_AuxTransporte.UseVisualStyleBackColor = True
        '
        'Bt_AuxAlimentacion
        '
        Me.Bt_AuxAlimentacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_AuxAlimentacion.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Bt_AuxAlimentacion.Location = New System.Drawing.Point(0, 28)
        Me.Bt_AuxAlimentacion.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_AuxAlimentacion.Name = "Bt_AuxAlimentacion"
        Me.Bt_AuxAlimentacion.Size = New System.Drawing.Size(232, 28)
        Me.Bt_AuxAlimentacion.TabIndex = 7
        Me.Bt_AuxAlimentacion.Tag = "740"
        Me.Bt_AuxAlimentacion.Text = "Generar Aux. De Alimentación"
        Me.Bt_AuxAlimentacion.UseVisualStyleBackColor = True
        '
        'Bt_GenerarSobretiempo
        '
        Me.Bt_GenerarSobretiempo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_GenerarSobretiempo.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Bt_GenerarSobretiempo.Location = New System.Drawing.Point(0, 0)
        Me.Bt_GenerarSobretiempo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_GenerarSobretiempo.Name = "Bt_GenerarSobretiempo"
        Me.Bt_GenerarSobretiempo.Size = New System.Drawing.Size(232, 28)
        Me.Bt_GenerarSobretiempo.TabIndex = 4
        Me.Bt_GenerarSobretiempo.Tag = "738"
        Me.Bt_GenerarSobretiempo.Text = "Generar Sobretiempo"
        Me.Bt_GenerarSobretiempo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Lb_FinPeriodo)
        Me.Panel1.Controls.Add(Me.Lb_InicioPeriodo)
        Me.Panel1.Controls.Add(Me.Cb_CorteNómina)
        Me.Panel1.Controls.Add(Me.Lb_Año)
        Me.Panel1.Controls.Add(Me.Cb_AñoInforme)
        Me.Panel1.Controls.Add(Me.Lb_Corte)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 123)
        Me.Panel1.TabIndex = 5
        '
        'Lb_FinPeriodo
        '
        Me.Lb_FinPeriodo.AutoSize = True
        Me.Lb_FinPeriodo.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Lb_FinPeriodo.Location = New System.Drawing.Point(33, 93)
        Me.Lb_FinPeriodo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lb_FinPeriodo.Name = "Lb_FinPeriodo"
        Me.Lb_FinPeriodo.Size = New System.Drawing.Size(30, 16)
        Me.Lb_FinPeriodo.TabIndex = 5
        Me.Lb_FinPeriodo.Text = "Fin:"
        '
        'Lb_InicioPeriodo
        '
        Me.Lb_InicioPeriodo.AutoSize = True
        Me.Lb_InicioPeriodo.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Lb_InicioPeriodo.Location = New System.Drawing.Point(20, 69)
        Me.Lb_InicioPeriodo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lb_InicioPeriodo.Name = "Lb_InicioPeriodo"
        Me.Lb_InicioPeriodo.Size = New System.Drawing.Size(43, 16)
        Me.Lb_InicioPeriodo.TabIndex = 4
        Me.Lb_InicioPeriodo.Text = "Inicio:"
        '
        'Cb_CorteNómina
        '
        Me.Cb_CorteNómina.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Cb_CorteNómina.FormattingEnabled = True
        Me.Cb_CorteNómina.Items.AddRange(New Object() {"XXXXXX"})
        Me.Cb_CorteNómina.Location = New System.Drawing.Point(129, 35)
        Me.Cb_CorteNómina.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Cb_CorteNómina.Name = "Cb_CorteNómina"
        Me.Cb_CorteNómina.Size = New System.Drawing.Size(91, 24)
        Me.Cb_CorteNómina.TabIndex = 3
        '
        'Lb_Año
        '
        Me.Lb_Año.AutoSize = True
        Me.Lb_Año.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Lb_Año.Location = New System.Drawing.Point(27, 10)
        Me.Lb_Año.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lb_Año.Name = "Lb_Año"
        Me.Lb_Año.Size = New System.Drawing.Size(35, 16)
        Me.Lb_Año.TabIndex = 0
        Me.Lb_Año.Text = "Año:"
        '
        'Cb_AñoInforme
        '
        Me.Cb_AñoInforme.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Cb_AñoInforme.FormattingEnabled = True
        Me.Cb_AñoInforme.Location = New System.Drawing.Point(129, 7)
        Me.Cb_AñoInforme.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Cb_AñoInforme.Name = "Cb_AñoInforme"
        Me.Cb_AñoInforme.Size = New System.Drawing.Size(91, 24)
        Me.Cb_AñoInforme.TabIndex = 1
        '
        'Lb_Corte
        '
        Me.Lb_Corte.AutoSize = True
        Me.Lb_Corte.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Lb_Corte.Location = New System.Drawing.Point(19, 39)
        Me.Lb_Corte.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lb_Corte.Name = "Lb_Corte"
        Me.Lb_Corte.Size = New System.Drawing.Size(44, 16)
        Me.Lb_Corte.TabIndex = 2
        Me.Lb_Corte.Text = "Corte:"
        '
        'Nbg_Reportes
        '
        Me.Nbg_Reportes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Nbg_Reportes.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarReporteDiario, Me.Nbi_Nuevo, Me.Nbi_Clonar, Me.Nbi_Modificar, Me.Nbi_Habilitar, Me.Nbi_Buscar, Me.Separador, Me.Nbi_ListarCuadrillas, Me.Nbi_CrearCuadrilla, Me.Nbi_EditarCaudrilla, Me.Nbi_BuscarCuadrillas})
        Me.Nbg_Reportes.Name = "Nbg_Reportes"
        Me.Nbg_Reportes.SmallImage = Global.Reportediario.My.Resources.Resources.ImprimirReporte
        Me.Nbg_Reportes.Tag = "677"
        Me.Nbg_Reportes.Text = "Reportes"
        '
        'Nbi_ListarReporteDiario
        '
        Me.Nbi_ListarReporteDiario.Name = "Nbi_ListarReporteDiario"
        Me.Nbi_ListarReporteDiario.Tag = "711"
        Me.Nbi_ListarReporteDiario.Text = "Listar Reporte"
        '
        'Nbi_Nuevo
        '
        Me.Nbi_Nuevo.Name = "Nbi_Nuevo"
        Me.Nbi_Nuevo.SmallImage = Global.Reportediario.My.Resources.Resources.FNuevoReporte
        Me.Nbi_Nuevo.Tag = "678"
        Me.Nbi_Nuevo.Text = "Nuevo Reporte"
        '
        'Nbi_Clonar
        '
        Me.Nbi_Clonar.Name = "Nbi_Clonar"
        Me.Nbi_Clonar.Tag = "712"
        Me.Nbi_Clonar.Text = "Clonar Reporte"
        '
        'Nbi_Modificar
        '
        Me.Nbi_Modificar.Name = "Nbi_Modificar"
        Me.Nbi_Modificar.SmallImage = Global.Reportediario.My.Resources.Resources.FEditarReporte
        Me.Nbi_Modificar.Tag = "679"
        Me.Nbi_Modificar.Text = "Editar Reporte"
        '
        'Nbi_Habilitar
        '
        Me.Nbi_Habilitar.Name = "Nbi_Habilitar"
        Me.Nbi_Habilitar.SmallImage = Global.Reportediario.My.Resources.Resources.FHabilitarReporte
        Me.Nbi_Habilitar.Tag = "680"
        Me.Nbi_Habilitar.Text = "Habilitar Reporte"
        '
        'Nbi_Buscar
        '
        Me.Nbi_Buscar.Name = "Nbi_Buscar"
        Me.Nbi_Buscar.Tag = "681"
        Me.Nbi_Buscar.Text = "Buscar Reporte"
        '
        'Separador
        '
        Me.Separador.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Separador.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.Separador.Name = "Separador"
        Me.Separador.Text = "-------------------------------"
        '
        'Nbi_ListarCuadrillas
        '
        Me.Nbi_ListarCuadrillas.Name = "Nbi_ListarCuadrillas"
        Me.Nbi_ListarCuadrillas.Tag = "713"
        Me.Nbi_ListarCuadrillas.Text = "Listar Cuadrillas"
        '
        'Nbi_CrearCuadrilla
        '
        Me.Nbi_CrearCuadrilla.Name = "Nbi_CrearCuadrilla"
        Me.Nbi_CrearCuadrilla.Tag = "714"
        Me.Nbi_CrearCuadrilla.Text = "Crear Cuadrillas"
        '
        'Nbi_EditarCaudrilla
        '
        Me.Nbi_EditarCaudrilla.Name = "Nbi_EditarCaudrilla"
        Me.Nbi_EditarCaudrilla.Tag = "715"
        Me.Nbi_EditarCaudrilla.Text = "Editar Cuadrilla"
        '
        'Nbi_BuscarCuadrillas
        '
        Me.Nbi_BuscarCuadrillas.Name = "Nbi_BuscarCuadrillas"
        Me.Nbi_BuscarCuadrillas.Tag = "735"
        Me.Nbi_BuscarCuadrillas.Text = "Buscar Cuadrilla"
        '
        'Nbg_ExportarExcelRD
        '
        Me.Nbg_ExportarExcelRD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Nbg_ExportarExcelRD.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_RDxFechas, Me.Nbi_RTxCodContrato})
        Me.Nbg_ExportarExcelRD.Name = "Nbg_ExportarExcelRD"
        Me.Nbg_ExportarExcelRD.Tag = "733"
        Me.Nbg_ExportarExcelRD.Text = "Exportar Excel"
        '
        'Nbi_RDxFechas
        '
        Me.Nbi_RDxFechas.Name = "Nbi_RDxFechas"
        Me.Nbi_RDxFechas.Tag = "734"
        Me.Nbi_RDxFechas.Text = "Reporte Diario x Fechas"
        '
        'Nbi_RTxCodContrato
        '
        Me.Nbi_RTxCodContrato.Name = "Nbi_RTxCodContrato"
        Me.Nbi_RTxCodContrato.Tag = "745"
        Me.Nbi_RTxCodContrato.Text = "Reporte Trabajador x Código Contrato"
        '
        'Nbg_Informes
        '
        Me.Nbg_Informes.ControlContainer = Me.NetBarGroupControlContainer1
        Me.Nbg_Informes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Nbg_Informes.Name = "Nbg_Informes"
        Me.Nbg_Informes.Style = NetBarControl.NetBarGroupStyle.ControlContainer
        Me.Nbg_Informes.Tag = "737"
        Me.Nbg_Informes.Text = "Informes a Nómina"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(241, 340)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(751, 3)
        Me.Splitter1.TabIndex = 9
        Me.Splitter1.TabStop = False
        '
        'Pn_Detalle
        '
        Me.Pn_Detalle.Controls.Add(Me.SplitContainer2)
        Me.Pn_Detalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Detalle.Location = New System.Drawing.Point(241, 343)
        Me.Pn_Detalle.Name = "Pn_Detalle"
        Me.Pn_Detalle.Size = New System.Drawing.Size(751, 200)
        Me.Pn_Detalle.TabIndex = 8
        '
        'Cu_ReporteDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Pn_VistaDatos)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Pn_Detalle)
        Me.Controls.Add(Me.Nbc_Reportes)
        Me.Name = "Cu_ReporteDiario"
        Me.Size = New System.Drawing.Size(992, 543)
        CType(Me.Dgv_Reportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_Opciones.ResumeLayout(False)
        Me.Pn_VistaDatos.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Pn_TitiloMaestro.ResumeLayout(False)
        Me.Pn_Propiedades.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Dgv_ListaIntegrantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_IntegrantesReporte.ResumeLayout(False)
        Me.Pn_TituloDetallePersonas.ResumeLayout(False)
        CType(Me.Dgv_ListaEquipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_TituloDetalleEquipos.ResumeLayout(False)
        Me.Cms_OpcionesEquipo.ResumeLayout(False)
        Me.Nbc_Reportes.ResumeLayout(False)
        Me.NetBarGroupControlContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Pn_Detalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv_Reportes As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_VistaDatos As System.Windows.Forms.Panel

    Friend WithEvents Dgv_ListaIntegrantes As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_TituloDetallePersonas As System.Windows.Forms.Panel
    Friend WithEvents Lb_CantidadIntegrantes As System.Windows.Forms.Label

    Friend WithEvents CODIGOPROYECTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OBSERVACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pn_TitiloMaestro As System.Windows.Forms.Panel
    Friend WithEvents Lb_CantidadReportes As System.Windows.Forms.Label
    Friend WithEvents CMS_Opciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SeleccionarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PortapapelesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Cms_IntegrantesReporte As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RegistrarNovedadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IDCONTRATODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREPERSONADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRETIPOCATEGORIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRETIPOCARGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORASNORMALESDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORASEXTRASDIURNASDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORASEXTRASNOCTURNASDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORASRECARGONOCTURNODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nbc_Reportes As NetBarControl.NetBarControl
    Friend WithEvents Nbg_Reportes As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_Nuevo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Modificar As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Habilitar As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Imprimir As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_Reporte As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ReporteBlanco As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Novedades As NetBarControl.NetBarItem
    Friend WithEvents Pn_TituloDetalleEquipos As System.Windows.Forms.Panel
    Friend WithEvents Lb_CantidadEquipos As System.Windows.Forms.Label
    Friend WithEvents Dgv_ListaEquipos As System.Windows.Forms.DataGridView
    Friend WithEvents Cms_OpcionesEquipo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SacarDelReporteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarAlReporteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoverDeReporteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrarNovedadEquipoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IDREPORTEDIARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDEQUIPODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INICIALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FINALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DISPONIBLEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VARADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OBSERVACIONDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDACTIVIDADPRINCIPALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPROYECTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FORMAREPORTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPODISPONIBILIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DISPONIBILIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MAXIMOHFKFDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TANQUEOGALONESDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPERSONAOPERADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDADICIONALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTALADICIONALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nbi_NovedadesEquipos As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ReporteSinDiligenciar As NetBarControl.NetBarItem
    Friend WithEvents EquiposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FECHAREPORTEDIARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRETIPODISCIPLINADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOFRENTETRABAJODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TSMI_ClonarReporte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_Buscar As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Clonar As NetBarControl.NetBarItem
    Friend WithEvents PgDetalleReporte As System.Windows.Forms.PropertyGrid
    Friend WithEvents Lb_Propiedades As System.Windows.Forms.Label
    Friend WithEvents Pn_Propiedades As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents DGVTBC_CEQUIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_INICIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_FINAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_DISPONIBLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_VARADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_OBSERVACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nbi_CrearCuadrilla As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ListarCuadrillas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ListarReporteDiario As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarCaudrilla As NetBarControl.NetBarItem
    Friend WithEvents DGVTBC_CONTRATO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_NPERSONA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DVGTBC_CATEGORIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_CARGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_HNORMALES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_HDIURNAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_HNOCTURNAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_HRNOCTURNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Separador As NetBarControl.NetBarItem
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Nbi_ReporteBasico As NetBarControl.NetBarItem
    Friend WithEvents Pn_Detalle As System.Windows.Forms.Panel
    Friend WithEvents Nbg_ExportarExcelRD As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_RDxFechas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarCuadrillas As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Informes As NetBarControl.NetBarGroup
    Friend WithEvents NetBarGroupControlContainer1 As NetBarControl.NetBarGroupControlContainer
    Friend WithEvents Bt_GenerarSobretiempo As System.Windows.Forms.Button
    Friend WithEvents Cb_CorteNómina As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Corte As System.Windows.Forms.Label
    Friend WithEvents Cb_AñoInforme As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Año As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lb_FinPeriodo As System.Windows.Forms.Label
    Friend WithEvents Lb_InicioPeriodo As System.Windows.Forms.Label
    Friend WithEvents Nbi_RTxCodContrato As NetBarControl.NetBarItem
    Friend WithEvents Bt_ControlViaticos As System.Windows.Forms.Button
    Friend WithEvents Bt_ReporteIncapacidades As System.Windows.Forms.Button
    Friend WithEvents Bt_BonoTecnico As System.Windows.Forms.Button
    Friend WithEvents Bt_SinIncidencia As System.Windows.Forms.Button
    Friend WithEvents Bt_AuxAlimentacion As System.Windows.Forms.Button
    Friend WithEvents Bt_AuxTransporte As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Bt_SolicitudLiquidacion As System.Windows.Forms.Button
    Friend WithEvents Bt_PerPendReportar As System.Windows.Forms.Button
    Friend WithEvents Nbi_ImprimirCEquipo As NetBarControl.NetBarItem

End Class
