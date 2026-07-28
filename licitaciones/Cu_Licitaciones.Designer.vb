<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Licitaciones
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
        Me.Dgv_Equipos = New System.Windows.Forms.DataGridView()
        Me.Pn_ContenedorPrincipal = New System.Windows.Forms.Panel()
        Me.SC_Principal = New System.Windows.Forms.SplitContainer()
        Me.Dgv_Lista = New System.Windows.Forms.DataGridView()
        Me.Tlp_Totales = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_TotalCostoDirecto = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TextoTotalCostoDirecto = New System.Windows.Forms.Label()
        Me.Flp_Administracion = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TextoAdministracion = New System.Windows.Forms.Label()
        Me.Flp_Imprevistos = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TextoImprevistos = New System.Windows.Forms.Label()
        Me.Flp_Utilidades = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TextoUtilidades = New System.Windows.Forms.Label()
        Me.Flp_TotalCosto = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TextoTotalCosto = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_PorcentajeAdministracion = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_PorcentajeImprevistos = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_PorcentajeUtilidades = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TotalCostoDirecto = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TotalAdministracion = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TotalImprevistos = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TotalUtilidades = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel8 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TotalCosto = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel9 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TextoTotalHorasHombre = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel10 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TotalHorasHombre = New System.Windows.Forms.Label()
        Me.Pn_ContenedorTitulo = New System.Windows.Forms.Panel()
        Me.Lb_ListaPrincipal = New System.Windows.Forms.Label()
        Me.Pg_DetalleLista = New System.Windows.Forms.PropertyGrid()
        Me.Lb_Propiedades = New System.Windows.Forms.Label()
        Me.Pn_tituloformulario = New System.Windows.Forms.Panel()
        Me.Lb_NombreLicitacion = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Sc_EquipoManoObra = New System.Windows.Forms.SplitContainer()
        Me.Sc_MaterialesEquipo = New System.Windows.Forms.SplitContainer()
        Me.Pn_Equipos = New System.Windows.Forms.Panel()
        Me.Lb_MovimientoDos = New System.Windows.Forms.Label()
        Me.Dgv_Materiales = New System.Windows.Forms.DataGridView()
        Me.Pn_Materiales = New System.Windows.Forms.Panel()
        Me.Lb_Materiales = New System.Windows.Forms.Label()
        Me.Dgv_ManodeObra = New System.Windows.Forms.DataGridView()
        Me.Pn_ManoDeObra = New System.Windows.Forms.Panel()
        Me.Lb_ManoDeObra = New System.Windows.Forms.Label()
        Me.Cms_OpcionesLicitacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Lic_SeleccionarLicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Lic_EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Lic_ClonarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Lic_ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Lic_EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nbg_ManoDeObra = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarManoDeObra = New NetBarControl.NetBarItem()
        Me.Nbi_CrearManoDeObra = New NetBarControl.NetBarItem()
        Me.Nbi_EditarManoDeObra = New NetBarControl.NetBarItem()
        Me.Nbi_ClonarManoDeObra = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarManoDeObra = New NetBarControl.NetBarItem()
        Me.Nbi_EliminarManoDeObra = New NetBarControl.NetBarItem()
        Me.Nbi_ClonarEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_EditarEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_CrearEquipo = New NetBarControl.NetBarItem()
        Me.Nbg_Equipo = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarEquipos = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_EliminarEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirItems = New NetBarControl.NetBarItem()
        Me.Nbi_EliminarItems = New NetBarControl.NetBarItem()
        Me.Nbi_ClonarItems = New NetBarControl.NetBarItem()
        Me.Nbi_ClonarMaterial = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarMaterial = New NetBarControl.NetBarItem()
        Me.Nbi_EditarMaterial = New NetBarControl.NetBarItem()
        Me.Nbi_CrearMaterial = New NetBarControl.NetBarItem()
        Me.Nbg_Materiales = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarMateriales = New NetBarControl.NetBarItem()
        Me.Nbi_EliminarMaterial = New NetBarControl.NetBarItem()
        Me.Nbc_Licitaciones = New NetBarControl.NetBarControl()
        Me.Nbg_APUItems = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarItems = New NetBarControl.NetBarItem()
        Me.Nbi_CrearItems = New NetBarControl.NetBarItem()
        Me.Nbi_EditarItems = New NetBarControl.NetBarItem()
        Me.Nbi_ImportarItems = New NetBarControl.NetBarItem()
        Me.Nbi_ImportarEstructura = New NetBarControl.NetBarItem()
        Me.Nbi_ExportarItems = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarItems = New NetBarControl.NetBarItem()
        Me.Nbg_Licitaciones = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarListaLicitaciones = New NetBarControl.NetBarItem()
        Me.Nbi_CrearLicitacion = New NetBarControl.NetBarItem()
        Me.Nbi_EditarLicitacion = New NetBarControl.NetBarItem()
        Me.Nbi_ClonarLicitacion = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarLicitaciones = New NetBarControl.NetBarItem()
        Me.Nbi_SeleccionarLicitacion = New NetBarControl.NetBarItem()
        Me.Nbi_PermisosLicitacion = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirLicitacion = New NetBarControl.NetBarItem()
        Me.Nbi_EliminarLicitacion = New NetBarControl.NetBarItem()
        Me.Nbi_VerMaquinariaYEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_VerMaterialesLicitacion = New NetBarControl.NetBarItem()
        Me.Nbi_VerManoDeObra = New NetBarControl.NetBarItem()
        Me.Nbg_Herramientas = New NetBarControl.NetBarGroup()
        Me.Nbi_Soldadura = New NetBarControl.NetBarItem()
        Me.Nbi_DiscosyGratas = New NetBarControl.NetBarItem()
        Me.Nbi_Revestimiento = New NetBarControl.NetBarItem()
        Me.Nbi_OxígenoAcetileno = New NetBarControl.NetBarItem()
        Me.Nbi_AgregarTipoUnidad = New NetBarControl.NetBarItem()
        Me.Cms_OpcionesItems = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Apu_EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Apu_ClonarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Apu_EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_OpcionesEquipos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ME_EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ME_ClonarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ME_EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_OpcionesMaterial = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Ma_EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Ma_ClonarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Ma_EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_OpcionesManoDeObra = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MO_EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MO_ClonarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MO_EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Dgv_Equipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_ContenedorPrincipal.SuspendLayout()
        CType(Me.SC_Principal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SC_Principal.Panel1.SuspendLayout()
        Me.SC_Principal.Panel2.SuspendLayout()
        Me.SC_Principal.SuspendLayout()
        CType(Me.Dgv_Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tlp_Totales.SuspendLayout()
        Me.Flp_TotalCostoDirecto.SuspendLayout()
        Me.Flp_Administracion.SuspendLayout()
        Me.Flp_Imprevistos.SuspendLayout()
        Me.Flp_Utilidades.SuspendLayout()
        Me.Flp_TotalCosto.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.FlowLayoutPanel7.SuspendLayout()
        Me.FlowLayoutPanel8.SuspendLayout()
        Me.FlowLayoutPanel9.SuspendLayout()
        Me.FlowLayoutPanel10.SuspendLayout()
        Me.Pn_ContenedorTitulo.SuspendLayout()
        Me.Pn_tituloformulario.SuspendLayout()
        CType(Me.Sc_EquipoManoObra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sc_EquipoManoObra.Panel1.SuspendLayout()
        Me.Sc_EquipoManoObra.Panel2.SuspendLayout()
        Me.Sc_EquipoManoObra.SuspendLayout()
        CType(Me.Sc_MaterialesEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sc_MaterialesEquipo.Panel1.SuspendLayout()
        Me.Sc_MaterialesEquipo.Panel2.SuspendLayout()
        Me.Sc_MaterialesEquipo.SuspendLayout()
        Me.Pn_Equipos.SuspendLayout()
        CType(Me.Dgv_Materiales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Materiales.SuspendLayout()
        CType(Me.Dgv_ManodeObra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_ManoDeObra.SuspendLayout()
        Me.Cms_OpcionesLicitacion.SuspendLayout()
        Me.Cms_OpcionesItems.SuspendLayout()
        Me.Cms_OpcionesEquipos.SuspendLayout()
        Me.Cms_OpcionesMaterial.SuspendLayout()
        Me.Cms_OpcionesManoDeObra.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_Equipos
        '
        Me.Dgv_Equipos.AllowUserToAddRows = False
        Me.Dgv_Equipos.AllowUserToDeleteRows = False
        Me.Dgv_Equipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Equipos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Equipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Equipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Equipos.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_Equipos.Name = "Dgv_Equipos"
        Me.Dgv_Equipos.ReadOnly = True
        Me.Dgv_Equipos.Size = New System.Drawing.Size(219, 85)
        Me.Dgv_Equipos.TabIndex = 7
        '
        'Pn_ContenedorPrincipal
        '
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.SC_Principal)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Pn_tituloformulario)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Splitter1)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Sc_EquipoManoObra)
        Me.Pn_ContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ContenedorPrincipal.Location = New System.Drawing.Point(202, 0)
        Me.Pn_ContenedorPrincipal.Name = "Pn_ContenedorPrincipal"
        Me.Pn_ContenedorPrincipal.Size = New System.Drawing.Size(823, 530)
        Me.Pn_ContenedorPrincipal.TabIndex = 25
        '
        'SC_Principal
        '
        Me.SC_Principal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SC_Principal.Location = New System.Drawing.Point(0, 24)
        Me.SC_Principal.Name = "SC_Principal"
        '
        'SC_Principal.Panel1
        '
        Me.SC_Principal.Panel1.Controls.Add(Me.Dgv_Lista)
        Me.SC_Principal.Panel1.Controls.Add(Me.Tlp_Totales)
        Me.SC_Principal.Panel1.Controls.Add(Me.Pn_ContenedorTitulo)
        '
        'SC_Principal.Panel2
        '
        Me.SC_Principal.Panel2.Controls.Add(Me.Pg_DetalleLista)
        Me.SC_Principal.Panel2.Controls.Add(Me.Lb_Propiedades)
        Me.SC_Principal.Size = New System.Drawing.Size(823, 400)
        Me.SC_Principal.SplitterDistance = 569
        Me.SC_Principal.TabIndex = 1
        '
        'Dgv_Lista
        '
        Me.Dgv_Lista.AllowUserToAddRows = False
        Me.Dgv_Lista.AllowUserToDeleteRows = False
        Me.Dgv_Lista.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.Dgv_Lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Lista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Lista.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_Lista.Name = "Dgv_Lista"
        Me.Dgv_Lista.ReadOnly = True
        Me.Dgv_Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Lista.Size = New System.Drawing.Size(569, 262)
        Me.Dgv_Lista.TabIndex = 11
        '
        'Tlp_Totales
        '
        Me.Tlp_Totales.ColumnCount = 3
        Me.Tlp_Totales.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Totales.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.Tlp_Totales.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.Tlp_Totales.Controls.Add(Me.Flp_TotalCostoDirecto, 0, 0)
        Me.Tlp_Totales.Controls.Add(Me.Flp_Administracion, 0, 1)
        Me.Tlp_Totales.Controls.Add(Me.Flp_Imprevistos, 0, 2)
        Me.Tlp_Totales.Controls.Add(Me.Flp_Utilidades, 0, 3)
        Me.Tlp_Totales.Controls.Add(Me.Flp_TotalCosto, 0, 4)
        Me.Tlp_Totales.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.Tlp_Totales.Controls.Add(Me.FlowLayoutPanel2, 1, 2)
        Me.Tlp_Totales.Controls.Add(Me.FlowLayoutPanel3, 1, 3)
        Me.Tlp_Totales.Controls.Add(Me.FlowLayoutPanel4, 2, 0)
        Me.Tlp_Totales.Controls.Add(Me.FlowLayoutPanel5, 2, 1)
        Me.Tlp_Totales.Controls.Add(Me.FlowLayoutPanel6, 2, 2)
        Me.Tlp_Totales.Controls.Add(Me.FlowLayoutPanel7, 2, 3)
        Me.Tlp_Totales.Controls.Add(Me.FlowLayoutPanel8, 2, 4)
        Me.Tlp_Totales.Controls.Add(Me.FlowLayoutPanel9, 0, 5)
        Me.Tlp_Totales.Controls.Add(Me.FlowLayoutPanel10, 1, 5)
        Me.Tlp_Totales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_Totales.Location = New System.Drawing.Point(0, 280)
        Me.Tlp_Totales.Name = "Tlp_Totales"
        Me.Tlp_Totales.RowCount = 6
        Me.Tlp_Totales.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp_Totales.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp_Totales.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp_Totales.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp_Totales.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp_Totales.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp_Totales.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp_Totales.Size = New System.Drawing.Size(569, 120)
        Me.Tlp_Totales.TabIndex = 13
        '
        'Flp_TotalCostoDirecto
        '
        Me.Flp_TotalCostoDirecto.Controls.Add(Me.Lb_TextoTotalCostoDirecto)
        Me.Flp_TotalCostoDirecto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_TotalCostoDirecto.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_TotalCostoDirecto.Location = New System.Drawing.Point(0, 0)
        Me.Flp_TotalCostoDirecto.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_TotalCostoDirecto.Name = "Flp_TotalCostoDirecto"
        Me.Flp_TotalCostoDirecto.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Flp_TotalCostoDirecto.Size = New System.Drawing.Size(329, 20)
        Me.Flp_TotalCostoDirecto.TabIndex = 0
        '
        'Lb_TextoTotalCostoDirecto
        '
        Me.Lb_TextoTotalCostoDirecto.AutoSize = True
        Me.Lb_TextoTotalCostoDirecto.Location = New System.Drawing.Point(190, 3)
        Me.Lb_TextoTotalCostoDirecto.Name = "Lb_TextoTotalCostoDirecto"
        Me.Lb_TextoTotalCostoDirecto.Size = New System.Drawing.Size(136, 13)
        Me.Lb_TextoTotalCostoDirecto.TabIndex = 1
        Me.Lb_TextoTotalCostoDirecto.Text = "TOTAL COSTO DIRECTO:"
        '
        'Flp_Administracion
        '
        Me.Flp_Administracion.Controls.Add(Me.Lb_TextoAdministracion)
        Me.Flp_Administracion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Administracion.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Administracion.Location = New System.Drawing.Point(0, 20)
        Me.Flp_Administracion.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Administracion.Name = "Flp_Administracion"
        Me.Flp_Administracion.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Flp_Administracion.Size = New System.Drawing.Size(329, 20)
        Me.Flp_Administracion.TabIndex = 1
        '
        'Lb_TextoAdministracion
        '
        Me.Lb_TextoAdministracion.AutoSize = True
        Me.Lb_TextoAdministracion.Location = New System.Drawing.Point(223, 3)
        Me.Lb_TextoAdministracion.Name = "Lb_TextoAdministracion"
        Me.Lb_TextoAdministracion.Size = New System.Drawing.Size(103, 13)
        Me.Lb_TextoAdministracion.TabIndex = 3
        Me.Lb_TextoAdministracion.Text = "ADMINISTRACIÓN:"
        '
        'Flp_Imprevistos
        '
        Me.Flp_Imprevistos.Controls.Add(Me.Lb_TextoImprevistos)
        Me.Flp_Imprevistos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Imprevistos.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Imprevistos.Location = New System.Drawing.Point(0, 40)
        Me.Flp_Imprevistos.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Imprevistos.Name = "Flp_Imprevistos"
        Me.Flp_Imprevistos.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Flp_Imprevistos.Size = New System.Drawing.Size(329, 20)
        Me.Flp_Imprevistos.TabIndex = 2
        '
        'Lb_TextoImprevistos
        '
        Me.Lb_TextoImprevistos.AutoSize = True
        Me.Lb_TextoImprevistos.Location = New System.Drawing.Point(243, 3)
        Me.Lb_TextoImprevistos.Name = "Lb_TextoImprevistos"
        Me.Lb_TextoImprevistos.Size = New System.Drawing.Size(83, 13)
        Me.Lb_TextoImprevistos.TabIndex = 3
        Me.Lb_TextoImprevistos.Text = "IMPREVISTOS:"
        '
        'Flp_Utilidades
        '
        Me.Flp_Utilidades.Controls.Add(Me.Lb_TextoUtilidades)
        Me.Flp_Utilidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Utilidades.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Utilidades.Location = New System.Drawing.Point(0, 60)
        Me.Flp_Utilidades.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Utilidades.Name = "Flp_Utilidades"
        Me.Flp_Utilidades.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Flp_Utilidades.Size = New System.Drawing.Size(329, 20)
        Me.Flp_Utilidades.TabIndex = 3
        '
        'Lb_TextoUtilidades
        '
        Me.Lb_TextoUtilidades.AutoSize = True
        Me.Lb_TextoUtilidades.Location = New System.Drawing.Point(252, 3)
        Me.Lb_TextoUtilidades.Name = "Lb_TextoUtilidades"
        Me.Lb_TextoUtilidades.Size = New System.Drawing.Size(74, 13)
        Me.Lb_TextoUtilidades.TabIndex = 3
        Me.Lb_TextoUtilidades.Text = "UTILIDADES:"
        '
        'Flp_TotalCosto
        '
        Me.Flp_TotalCosto.Controls.Add(Me.Lb_TextoTotalCosto)
        Me.Flp_TotalCosto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_TotalCosto.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_TotalCosto.Location = New System.Drawing.Point(0, 80)
        Me.Flp_TotalCosto.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_TotalCosto.Name = "Flp_TotalCosto"
        Me.Flp_TotalCosto.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Flp_TotalCosto.Size = New System.Drawing.Size(329, 20)
        Me.Flp_TotalCosto.TabIndex = 4
        '
        'Lb_TextoTotalCosto
        '
        Me.Lb_TextoTotalCosto.AutoSize = True
        Me.Lb_TextoTotalCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoTotalCosto.Location = New System.Drawing.Point(229, 3)
        Me.Lb_TextoTotalCosto.Name = "Lb_TextoTotalCosto"
        Me.Lb_TextoTotalCosto.Size = New System.Drawing.Size(97, 13)
        Me.Lb_TextoTotalCosto.TabIndex = 3
        Me.Lb_TextoTotalCosto.Text = "TOTAL COSTO:"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Lb_PorcentajeAdministracion)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(329, 20)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(40, 20)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'Lb_PorcentajeAdministracion
        '
        Me.Lb_PorcentajeAdministracion.AutoSize = True
        Me.Lb_PorcentajeAdministracion.Location = New System.Drawing.Point(3, 3)
        Me.Lb_PorcentajeAdministracion.Name = "Lb_PorcentajeAdministracion"
        Me.Lb_PorcentajeAdministracion.Size = New System.Drawing.Size(21, 13)
        Me.Lb_PorcentajeAdministracion.TabIndex = 4
        Me.Lb_PorcentajeAdministracion.Text = "0%"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Lb_PorcentajeImprevistos)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(329, 40)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(40, 20)
        Me.FlowLayoutPanel2.TabIndex = 7
        '
        'Lb_PorcentajeImprevistos
        '
        Me.Lb_PorcentajeImprevistos.AutoSize = True
        Me.Lb_PorcentajeImprevistos.Location = New System.Drawing.Point(3, 3)
        Me.Lb_PorcentajeImprevistos.Name = "Lb_PorcentajeImprevistos"
        Me.Lb_PorcentajeImprevistos.Size = New System.Drawing.Size(21, 13)
        Me.Lb_PorcentajeImprevistos.TabIndex = 5
        Me.Lb_PorcentajeImprevistos.Text = "0%"
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.Lb_PorcentajeUtilidades)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(329, 60)
        Me.FlowLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(40, 20)
        Me.FlowLayoutPanel3.TabIndex = 8
        '
        'Lb_PorcentajeUtilidades
        '
        Me.Lb_PorcentajeUtilidades.AutoSize = True
        Me.Lb_PorcentajeUtilidades.Location = New System.Drawing.Point(3, 3)
        Me.Lb_PorcentajeUtilidades.Name = "Lb_PorcentajeUtilidades"
        Me.Lb_PorcentajeUtilidades.Size = New System.Drawing.Size(21, 13)
        Me.Lb_PorcentajeUtilidades.TabIndex = 5
        Me.Lb_PorcentajeUtilidades.Text = "0%"
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.Lb_TotalCostoDirecto)
        Me.FlowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(369, 0)
        Me.FlowLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(200, 20)
        Me.FlowLayoutPanel4.TabIndex = 9
        '
        'Lb_TotalCostoDirecto
        '
        Me.Lb_TotalCostoDirecto.AutoSize = True
        Me.Lb_TotalCostoDirecto.Location = New System.Drawing.Point(3, 3)
        Me.Lb_TotalCostoDirecto.Name = "Lb_TotalCostoDirecto"
        Me.Lb_TotalCostoDirecto.Size = New System.Drawing.Size(22, 13)
        Me.Lb_TotalCostoDirecto.TabIndex = 0
        Me.Lb_TotalCostoDirecto.Text = "$ 0"
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.Lb_TotalAdministracion)
        Me.FlowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(369, 20)
        Me.FlowLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(200, 20)
        Me.FlowLayoutPanel5.TabIndex = 10
        '
        'Lb_TotalAdministracion
        '
        Me.Lb_TotalAdministracion.AutoSize = True
        Me.Lb_TotalAdministracion.Location = New System.Drawing.Point(3, 3)
        Me.Lb_TotalAdministracion.Name = "Lb_TotalAdministracion"
        Me.Lb_TotalAdministracion.Size = New System.Drawing.Size(22, 13)
        Me.Lb_TotalAdministracion.TabIndex = 2
        Me.Lb_TotalAdministracion.Text = "$ 0"
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Controls.Add(Me.Lb_TotalImprevistos)
        Me.FlowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(369, 40)
        Me.FlowLayoutPanel6.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(200, 20)
        Me.FlowLayoutPanel6.TabIndex = 11
        '
        'Lb_TotalImprevistos
        '
        Me.Lb_TotalImprevistos.AutoSize = True
        Me.Lb_TotalImprevistos.Location = New System.Drawing.Point(3, 3)
        Me.Lb_TotalImprevistos.Name = "Lb_TotalImprevistos"
        Me.Lb_TotalImprevistos.Size = New System.Drawing.Size(22, 13)
        Me.Lb_TotalImprevistos.TabIndex = 2
        Me.Lb_TotalImprevistos.Text = "$ 0"
        '
        'FlowLayoutPanel7
        '
        Me.FlowLayoutPanel7.Controls.Add(Me.Lb_TotalUtilidades)
        Me.FlowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel7.Location = New System.Drawing.Point(369, 60)
        Me.FlowLayoutPanel7.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        Me.FlowLayoutPanel7.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel7.Size = New System.Drawing.Size(200, 20)
        Me.FlowLayoutPanel7.TabIndex = 12
        '
        'Lb_TotalUtilidades
        '
        Me.Lb_TotalUtilidades.AutoSize = True
        Me.Lb_TotalUtilidades.Location = New System.Drawing.Point(3, 3)
        Me.Lb_TotalUtilidades.Name = "Lb_TotalUtilidades"
        Me.Lb_TotalUtilidades.Size = New System.Drawing.Size(22, 13)
        Me.Lb_TotalUtilidades.TabIndex = 2
        Me.Lb_TotalUtilidades.Text = "$ 0"
        '
        'FlowLayoutPanel8
        '
        Me.FlowLayoutPanel8.Controls.Add(Me.Lb_TotalCosto)
        Me.FlowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel8.Location = New System.Drawing.Point(369, 80)
        Me.FlowLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel8.Name = "FlowLayoutPanel8"
        Me.FlowLayoutPanel8.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel8.Size = New System.Drawing.Size(200, 20)
        Me.FlowLayoutPanel8.TabIndex = 13
        '
        'Lb_TotalCosto
        '
        Me.Lb_TotalCosto.AutoSize = True
        Me.Lb_TotalCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TotalCosto.Location = New System.Drawing.Point(3, 3)
        Me.Lb_TotalCosto.Name = "Lb_TotalCosto"
        Me.Lb_TotalCosto.Size = New System.Drawing.Size(25, 13)
        Me.Lb_TotalCosto.TabIndex = 2
        Me.Lb_TotalCosto.Text = "$ 0"
        '
        'FlowLayoutPanel9
        '
        Me.FlowLayoutPanel9.Controls.Add(Me.Lb_TextoTotalHorasHombre)
        Me.FlowLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel9.Location = New System.Drawing.Point(0, 100)
        Me.FlowLayoutPanel9.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel9.Name = "FlowLayoutPanel9"
        Me.FlowLayoutPanel9.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel9.Size = New System.Drawing.Size(329, 20)
        Me.FlowLayoutPanel9.TabIndex = 14
        '
        'Lb_TextoTotalHorasHombre
        '
        Me.Lb_TextoTotalHorasHombre.AutoSize = True
        Me.Lb_TextoTotalHorasHombre.Location = New System.Drawing.Point(190, 3)
        Me.Lb_TextoTotalHorasHombre.Name = "Lb_TextoTotalHorasHombre"
        Me.Lb_TextoTotalHorasHombre.Size = New System.Drawing.Size(136, 13)
        Me.Lb_TextoTotalHorasHombre.TabIndex = 4
        Me.Lb_TextoTotalHorasHombre.Text = "TOTAL HORAS HOMBRE:"
        '
        'FlowLayoutPanel10
        '
        Me.Tlp_Totales.SetColumnSpan(Me.FlowLayoutPanel10, 2)
        Me.FlowLayoutPanel10.Controls.Add(Me.Lb_TotalHorasHombre)
        Me.FlowLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel10.Location = New System.Drawing.Point(329, 100)
        Me.FlowLayoutPanel10.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel10.Name = "FlowLayoutPanel10"
        Me.FlowLayoutPanel10.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.FlowLayoutPanel10.Size = New System.Drawing.Size(240, 20)
        Me.FlowLayoutPanel10.TabIndex = 15
        '
        'Lb_TotalHorasHombre
        '
        Me.Lb_TotalHorasHombre.AutoSize = True
        Me.Lb_TotalHorasHombre.Location = New System.Drawing.Point(3, 3)
        Me.Lb_TotalHorasHombre.Name = "Lb_TotalHorasHombre"
        Me.Lb_TotalHorasHombre.Size = New System.Drawing.Size(13, 13)
        Me.Lb_TotalHorasHombre.TabIndex = 5
        Me.Lb_TotalHorasHombre.Text = "0"
        '
        'Pn_ContenedorTitulo
        '
        Me.Pn_ContenedorTitulo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_ContenedorTitulo.Controls.Add(Me.Lb_ListaPrincipal)
        Me.Pn_ContenedorTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_ContenedorTitulo.Location = New System.Drawing.Point(0, 0)
        Me.Pn_ContenedorTitulo.Name = "Pn_ContenedorTitulo"
        Me.Pn_ContenedorTitulo.Size = New System.Drawing.Size(569, 18)
        Me.Pn_ContenedorTitulo.TabIndex = 12
        '
        'Lb_ListaPrincipal
        '
        Me.Lb_ListaPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_ListaPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_ListaPrincipal.ForeColor = System.Drawing.Color.Black
        Me.Lb_ListaPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.Lb_ListaPrincipal.Name = "Lb_ListaPrincipal"
        Me.Lb_ListaPrincipal.Size = New System.Drawing.Size(569, 18)
        Me.Lb_ListaPrincipal.TabIndex = 0
        Me.Lb_ListaPrincipal.Text = "Lista Principal"
        Me.Lb_ListaPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pg_DetalleLista
        '
        Me.Pg_DetalleLista.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Pg_DetalleLista.CommandsBackColor = System.Drawing.SystemColors.Control
        Me.Pg_DetalleLista.CommandsDisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.Pg_DetalleLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pg_DetalleLista.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pg_DetalleLista.LineColor = System.Drawing.SystemColors.ControlDark
        Me.Pg_DetalleLista.Location = New System.Drawing.Point(0, 18)
        Me.Pg_DetalleLista.Name = "Pg_DetalleLista"
        Me.Pg_DetalleLista.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.Pg_DetalleLista.Size = New System.Drawing.Size(250, 382)
        Me.Pg_DetalleLista.TabIndex = 19
        '
        'Lb_Propiedades
        '
        Me.Lb_Propiedades.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Lb_Propiedades.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Propiedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Propiedades.ForeColor = System.Drawing.Color.Black
        Me.Lb_Propiedades.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Propiedades.Name = "Lb_Propiedades"
        Me.Lb_Propiedades.Size = New System.Drawing.Size(250, 18)
        Me.Lb_Propiedades.TabIndex = 17
        Me.Lb_Propiedades.Text = "Propiedades"
        Me.Lb_Propiedades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pn_tituloformulario
        '
        Me.Pn_tituloformulario.BackColor = System.Drawing.SystemColors.Info
        Me.Pn_tituloformulario.Controls.Add(Me.Lb_NombreLicitacion)
        Me.Pn_tituloformulario.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_tituloformulario.Location = New System.Drawing.Point(0, 0)
        Me.Pn_tituloformulario.Name = "Pn_tituloformulario"
        Me.Pn_tituloformulario.Size = New System.Drawing.Size(823, 24)
        Me.Pn_tituloformulario.TabIndex = 0
        '
        'Lb_NombreLicitacion
        '
        Me.Lb_NombreLicitacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_NombreLicitacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_NombreLicitacion.Location = New System.Drawing.Point(0, 0)
        Me.Lb_NombreLicitacion.Name = "Lb_NombreLicitacion"
        Me.Lb_NombreLicitacion.Size = New System.Drawing.Size(823, 24)
        Me.Lb_NombreLicitacion.TabIndex = 0
        Me.Lb_NombreLicitacion.Text = "LICITACIONES"
        Me.Lb_NombreLicitacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 424)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(823, 3)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        Me.Splitter1.Visible = False
        '
        'Sc_EquipoManoObra
        '
        Me.Sc_EquipoManoObra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Sc_EquipoManoObra.Location = New System.Drawing.Point(0, 427)
        Me.Sc_EquipoManoObra.Name = "Sc_EquipoManoObra"
        '
        'Sc_EquipoManoObra.Panel1
        '
        Me.Sc_EquipoManoObra.Panel1.Controls.Add(Me.Sc_MaterialesEquipo)
        '
        'Sc_EquipoManoObra.Panel2
        '
        Me.Sc_EquipoManoObra.Panel2.Controls.Add(Me.Dgv_ManodeObra)
        Me.Sc_EquipoManoObra.Panel2.Controls.Add(Me.Pn_ManoDeObra)
        Me.Sc_EquipoManoObra.Size = New System.Drawing.Size(823, 103)
        Me.Sc_EquipoManoObra.SplitterDistance = 438
        Me.Sc_EquipoManoObra.TabIndex = 3
        Me.Sc_EquipoManoObra.Visible = False
        '
        'Sc_MaterialesEquipo
        '
        Me.Sc_MaterialesEquipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sc_MaterialesEquipo.Location = New System.Drawing.Point(0, 0)
        Me.Sc_MaterialesEquipo.Name = "Sc_MaterialesEquipo"
        '
        'Sc_MaterialesEquipo.Panel1
        '
        Me.Sc_MaterialesEquipo.Panel1.Controls.Add(Me.Dgv_Equipos)
        Me.Sc_MaterialesEquipo.Panel1.Controls.Add(Me.Pn_Equipos)
        '
        'Sc_MaterialesEquipo.Panel2
        '
        Me.Sc_MaterialesEquipo.Panel2.Controls.Add(Me.Dgv_Materiales)
        Me.Sc_MaterialesEquipo.Panel2.Controls.Add(Me.Pn_Materiales)
        Me.Sc_MaterialesEquipo.Size = New System.Drawing.Size(438, 103)
        Me.Sc_MaterialesEquipo.SplitterDistance = 219
        Me.Sc_MaterialesEquipo.TabIndex = 21
        '
        'Pn_Equipos
        '
        Me.Pn_Equipos.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_Equipos.Controls.Add(Me.Lb_MovimientoDos)
        Me.Pn_Equipos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Equipos.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Equipos.Name = "Pn_Equipos"
        Me.Pn_Equipos.Size = New System.Drawing.Size(219, 18)
        Me.Pn_Equipos.TabIndex = 8
        '
        'Lb_MovimientoDos
        '
        Me.Lb_MovimientoDos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_MovimientoDos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_MovimientoDos.ForeColor = System.Drawing.Color.Black
        Me.Lb_MovimientoDos.Location = New System.Drawing.Point(0, 0)
        Me.Lb_MovimientoDos.Name = "Lb_MovimientoDos"
        Me.Lb_MovimientoDos.Size = New System.Drawing.Size(219, 18)
        Me.Lb_MovimientoDos.TabIndex = 0
        Me.Lb_MovimientoDos.Text = "Equipos"
        Me.Lb_MovimientoDos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Dgv_Materiales
        '
        Me.Dgv_Materiales.AllowUserToAddRows = False
        Me.Dgv_Materiales.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Dgv_Materiales.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_Materiales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Materiales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Dgv_Materiales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Materiales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Materiales.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_Materiales.Name = "Dgv_Materiales"
        Me.Dgv_Materiales.ReadOnly = True
        Me.Dgv_Materiales.Size = New System.Drawing.Size(215, 85)
        Me.Dgv_Materiales.TabIndex = 8
        '
        'Pn_Materiales
        '
        Me.Pn_Materiales.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_Materiales.Controls.Add(Me.Lb_Materiales)
        Me.Pn_Materiales.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Materiales.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Materiales.Name = "Pn_Materiales"
        Me.Pn_Materiales.Size = New System.Drawing.Size(215, 18)
        Me.Pn_Materiales.TabIndex = 7
        '
        'Lb_Materiales
        '
        Me.Lb_Materiales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Materiales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Materiales.ForeColor = System.Drawing.Color.Black
        Me.Lb_Materiales.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Materiales.Name = "Lb_Materiales"
        Me.Lb_Materiales.Size = New System.Drawing.Size(215, 18)
        Me.Lb_Materiales.TabIndex = 0
        Me.Lb_Materiales.Text = "Materiales"
        Me.Lb_Materiales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Dgv_ManodeObra
        '
        Me.Dgv_ManodeObra.AllowUserToAddRows = False
        Me.Dgv_ManodeObra.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Dgv_ManodeObra.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.Dgv_ManodeObra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_ManodeObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ManodeObra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ManodeObra.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_ManodeObra.Name = "Dgv_ManodeObra"
        Me.Dgv_ManodeObra.ReadOnly = True
        Me.Dgv_ManodeObra.Size = New System.Drawing.Size(381, 85)
        Me.Dgv_ManodeObra.TabIndex = 9
        '
        'Pn_ManoDeObra
        '
        Me.Pn_ManoDeObra.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_ManoDeObra.Controls.Add(Me.Lb_ManoDeObra)
        Me.Pn_ManoDeObra.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_ManoDeObra.Location = New System.Drawing.Point(0, 0)
        Me.Pn_ManoDeObra.Name = "Pn_ManoDeObra"
        Me.Pn_ManoDeObra.Size = New System.Drawing.Size(381, 18)
        Me.Pn_ManoDeObra.TabIndex = 10
        '
        'Lb_ManoDeObra
        '
        Me.Lb_ManoDeObra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_ManoDeObra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_ManoDeObra.ForeColor = System.Drawing.Color.Black
        Me.Lb_ManoDeObra.Location = New System.Drawing.Point(0, 0)
        Me.Lb_ManoDeObra.Name = "Lb_ManoDeObra"
        Me.Lb_ManoDeObra.Size = New System.Drawing.Size(381, 18)
        Me.Lb_ManoDeObra.TabIndex = 0
        Me.Lb_ManoDeObra.Text = "Mano de Obra"
        Me.Lb_ManoDeObra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cms_OpcionesLicitacion
        '
        Me.Cms_OpcionesLicitacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Lic_SeleccionarLicToolStripMenuItem, Me.ToolStripSeparator1, Me.Lic_EditarToolStripMenuItem, Me.Lic_ClonarToolStripMenuItem, Me.Lic_ImprimirToolStripMenuItem, Me.Lic_EliminarToolStripMenuItem})
        Me.Cms_OpcionesLicitacion.Name = "Cms_Ordenar"
        Me.Cms_OpcionesLicitacion.Size = New System.Drawing.Size(189, 120)
        '
        'Lic_SeleccionarLicToolStripMenuItem
        '
        Me.Lic_SeleccionarLicToolStripMenuItem.Name = "Lic_SeleccionarLicToolStripMenuItem"
        Me.Lic_SeleccionarLicToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.Lic_SeleccionarLicToolStripMenuItem.Tag = "589"
        Me.Lic_SeleccionarLicToolStripMenuItem.Text = "Seleccionar Licitación"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(185, 6)
        '
        'Lic_EditarToolStripMenuItem
        '
        Me.Lic_EditarToolStripMenuItem.Name = "Lic_EditarToolStripMenuItem"
        Me.Lic_EditarToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.Lic_EditarToolStripMenuItem.Tag = "586"
        Me.Lic_EditarToolStripMenuItem.Text = "Editar"
        '
        'Lic_ClonarToolStripMenuItem
        '
        Me.Lic_ClonarToolStripMenuItem.Name = "Lic_ClonarToolStripMenuItem"
        Me.Lic_ClonarToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.Lic_ClonarToolStripMenuItem.Tag = "587"
        Me.Lic_ClonarToolStripMenuItem.Text = "Clonar"
        '
        'Lic_ImprimirToolStripMenuItem
        '
        Me.Lic_ImprimirToolStripMenuItem.Name = "Lic_ImprimirToolStripMenuItem"
        Me.Lic_ImprimirToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.Lic_ImprimirToolStripMenuItem.Tag = "591"
        Me.Lic_ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'Lic_EliminarToolStripMenuItem
        '
        Me.Lic_EliminarToolStripMenuItem.Name = "Lic_EliminarToolStripMenuItem"
        Me.Lic_EliminarToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.Lic_EliminarToolStripMenuItem.Tag = "592"
        Me.Lic_EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'Nbg_ManoDeObra
        '
        Me.Nbg_ManoDeObra.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarManoDeObra, Me.Nbi_CrearManoDeObra, Me.Nbi_EditarManoDeObra, Me.Nbi_ClonarManoDeObra, Me.Nbi_BuscarManoDeObra, Me.Nbi_EliminarManoDeObra})
        Me.Nbg_ManoDeObra.Name = "Nbg_ManoDeObra"
        Me.Nbg_ManoDeObra.Tag = "620"
        Me.Nbg_ManoDeObra.Text = "Mano de Obra"
        '
        'Nbi_CargarManoDeObra
        '
        Me.Nbi_CargarManoDeObra.Name = "Nbi_CargarManoDeObra"
        Me.Nbi_CargarManoDeObra.Tag = "621"
        Me.Nbi_CargarManoDeObra.Text = "Cargar Listado"
        '
        'Nbi_CrearManoDeObra
        '
        Me.Nbi_CrearManoDeObra.Name = "Nbi_CrearManoDeObra"
        Me.Nbi_CrearManoDeObra.Tag = "622"
        Me.Nbi_CrearManoDeObra.Text = "Crear"
        '
        'Nbi_EditarManoDeObra
        '
        Me.Nbi_EditarManoDeObra.Name = "Nbi_EditarManoDeObra"
        Me.Nbi_EditarManoDeObra.Tag = "623"
        Me.Nbi_EditarManoDeObra.Text = "Editar"
        '
        'Nbi_ClonarManoDeObra
        '
        Me.Nbi_ClonarManoDeObra.Name = "Nbi_ClonarManoDeObra"
        Me.Nbi_ClonarManoDeObra.Tag = "624"
        Me.Nbi_ClonarManoDeObra.Text = "Clonar"
        '
        'Nbi_BuscarManoDeObra
        '
        Me.Nbi_BuscarManoDeObra.Name = "Nbi_BuscarManoDeObra"
        Me.Nbi_BuscarManoDeObra.Tag = "625"
        Me.Nbi_BuscarManoDeObra.Text = "Buscar"
        '
        'Nbi_EliminarManoDeObra
        '
        Me.Nbi_EliminarManoDeObra.Name = "Nbi_EliminarManoDeObra"
        Me.Nbi_EliminarManoDeObra.Tag = "626"
        Me.Nbi_EliminarManoDeObra.Text = "Eliminar"
        '
        'Nbi_ClonarEquipo
        '
        Me.Nbi_ClonarEquipo.Name = "Nbi_ClonarEquipo"
        Me.Nbi_ClonarEquipo.Tag = "617"
        Me.Nbi_ClonarEquipo.Text = "Clonar"
        '
        'Nbi_EditarEquipo
        '
        Me.Nbi_EditarEquipo.Name = "Nbi_EditarEquipo"
        Me.Nbi_EditarEquipo.Tag = "616"
        Me.Nbi_EditarEquipo.Text = "Editar"
        '
        'Nbi_CrearEquipo
        '
        Me.Nbi_CrearEquipo.Name = "Nbi_CrearEquipo"
        Me.Nbi_CrearEquipo.Tag = "615"
        Me.Nbi_CrearEquipo.Text = "Crear"
        '
        'Nbg_Equipo
        '
        Me.Nbg_Equipo.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarEquipos, Me.Nbi_CrearEquipo, Me.Nbi_EditarEquipo, Me.Nbi_ClonarEquipo, Me.Nbi_BuscarEquipo, Me.Nbi_EliminarEquipo})
        Me.Nbg_Equipo.Name = "Nbg_Equipo"
        Me.Nbg_Equipo.Tag = "613"
        Me.Nbg_Equipo.Text = "Maquinaria y Equipos"
        '
        'Nbi_CargarEquipos
        '
        Me.Nbi_CargarEquipos.Name = "Nbi_CargarEquipos"
        Me.Nbi_CargarEquipos.Tag = "614"
        Me.Nbi_CargarEquipos.Text = "Cargar Listado"
        '
        'Nbi_BuscarEquipo
        '
        Me.Nbi_BuscarEquipo.Name = "Nbi_BuscarEquipo"
        Me.Nbi_BuscarEquipo.Tag = "618"
        Me.Nbi_BuscarEquipo.Text = "Buscar"
        '
        'Nbi_EliminarEquipo
        '
        Me.Nbi_EliminarEquipo.Name = "Nbi_EliminarEquipo"
        Me.Nbi_EliminarEquipo.Tag = "619"
        Me.Nbi_EliminarEquipo.Text = "Eliminar"
        '
        'Nbi_ImprimirItems
        '
        Me.Nbi_ImprimirItems.Name = "Nbi_ImprimirItems"
        Me.Nbi_ImprimirItems.Tag = "604"
        Me.Nbi_ImprimirItems.Text = "Imprimir"
        '
        'Nbi_EliminarItems
        '
        Me.Nbi_EliminarItems.Name = "Nbi_EliminarItems"
        Me.Nbi_EliminarItems.Tag = "605"
        Me.Nbi_EliminarItems.Text = "Eliminar"
        '
        'Nbi_ClonarItems
        '
        Me.Nbi_ClonarItems.Name = "Nbi_ClonarItems"
        Me.Nbi_ClonarItems.Tag = "600"
        Me.Nbi_ClonarItems.Text = "Clonar"
        '
        'Nbi_ClonarMaterial
        '
        Me.Nbi_ClonarMaterial.Name = "Nbi_ClonarMaterial"
        Me.Nbi_ClonarMaterial.Tag = "610"
        Me.Nbi_ClonarMaterial.Text = "Clonar"
        '
        'Nbi_BuscarMaterial
        '
        Me.Nbi_BuscarMaterial.Name = "Nbi_BuscarMaterial"
        Me.Nbi_BuscarMaterial.Tag = "611"
        Me.Nbi_BuscarMaterial.Text = "Buscar"
        '
        'Nbi_EditarMaterial
        '
        Me.Nbi_EditarMaterial.Name = "Nbi_EditarMaterial"
        Me.Nbi_EditarMaterial.Tag = "609"
        Me.Nbi_EditarMaterial.Text = "Editar"
        '
        'Nbi_CrearMaterial
        '
        Me.Nbi_CrearMaterial.Name = "Nbi_CrearMaterial"
        Me.Nbi_CrearMaterial.Tag = "608"
        Me.Nbi_CrearMaterial.Text = "Crear"
        '
        'Nbg_Materiales
        '
        Me.Nbg_Materiales.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarMateriales, Me.Nbi_CrearMaterial, Me.Nbi_EditarMaterial, Me.Nbi_ClonarMaterial, Me.Nbi_BuscarMaterial, Me.Nbi_EliminarMaterial})
        Me.Nbg_Materiales.Name = "Nbg_Materiales"
        Me.Nbg_Materiales.Tag = "606"
        Me.Nbg_Materiales.Text = "Materiales"
        '
        'Nbi_CargarMateriales
        '
        Me.Nbi_CargarMateriales.Name = "Nbi_CargarMateriales"
        Me.Nbi_CargarMateriales.Tag = "607"
        Me.Nbi_CargarMateriales.Text = "Cargar Listado"
        '
        'Nbi_EliminarMaterial
        '
        Me.Nbi_EliminarMaterial.Name = "Nbi_EliminarMaterial"
        Me.Nbi_EliminarMaterial.Tag = "612"
        Me.Nbi_EliminarMaterial.Text = "Eliminar"
        '
        'Nbc_Licitaciones
        '
        Me.Nbc_Licitaciones.ActiveGroup = Me.Nbg_APUItems
        Me.Nbc_Licitaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_Licitaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Licitaciones.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_Licitaciones, Me.Nbg_APUItems, Me.Nbg_Equipo, Me.Nbg_Materiales, Me.Nbg_ManoDeObra, Me.Nbg_Herramientas})
        Me.Nbc_Licitaciones.GroupsFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Licitaciones.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_Licitaciones.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_Licitaciones.Location = New System.Drawing.Point(0, 0)
        Me.Nbc_Licitaciones.Name = "Nbc_Licitaciones"
        Me.Nbc_Licitaciones.ShowOverflowPanel = False
        Me.Nbc_Licitaciones.Size = New System.Drawing.Size(202, 530)
        Me.Nbc_Licitaciones.TabIndex = 24
        Me.Nbc_Licitaciones.Tag = "294"
        Me.Nbc_Licitaciones.Text = "Licitaciones"
        '
        'Nbg_APUItems
        '
        Me.Nbg_APUItems.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarItems, Me.Nbi_CrearItems, Me.Nbi_EditarItems, Me.Nbi_ClonarItems, Me.Nbi_ImportarItems, Me.Nbi_ImportarEstructura, Me.Nbi_ExportarItems, Me.Nbi_BuscarItems, Me.Nbi_ImprimirItems, Me.Nbi_EliminarItems})
        Me.Nbg_APUItems.Name = "Nbg_APUItems"
        Me.Nbg_APUItems.Tag = "596"
        Me.Nbg_APUItems.Text = "APU Ítems"
        '
        'Nbi_CargarItems
        '
        Me.Nbi_CargarItems.Name = "Nbi_CargarItems"
        Me.Nbi_CargarItems.Tag = "597"
        Me.Nbi_CargarItems.Text = "Cargar Listado"
        '
        'Nbi_CrearItems
        '
        Me.Nbi_CrearItems.Name = "Nbi_CrearItems"
        Me.Nbi_CrearItems.Tag = "598"
        Me.Nbi_CrearItems.Text = "Crear"
        '
        'Nbi_EditarItems
        '
        Me.Nbi_EditarItems.Name = "Nbi_EditarItems"
        Me.Nbi_EditarItems.Tag = "599"
        Me.Nbi_EditarItems.Text = "Editar"
        '
        'Nbi_ImportarItems
        '
        Me.Nbi_ImportarItems.Name = "Nbi_ImportarItems"
        Me.Nbi_ImportarItems.Tag = "601"
        Me.Nbi_ImportarItems.Text = "Importar Ítems"
        '
        'Nbi_ImportarEstructura
        '
        Me.Nbi_ImportarEstructura.Name = "Nbi_ImportarEstructura"
        Me.Nbi_ImportarEstructura.Text = "Importar Estructura"
        '
        'Nbi_ExportarItems
        '
        Me.Nbi_ExportarItems.Name = "Nbi_ExportarItems"
        Me.Nbi_ExportarItems.Tag = "602"
        Me.Nbi_ExportarItems.Text = "Exportar Ítems"
        '
        'Nbi_BuscarItems
        '
        Me.Nbi_BuscarItems.Name = "Nbi_BuscarItems"
        Me.Nbi_BuscarItems.Tag = "603"
        Me.Nbi_BuscarItems.Text = "Buscar"
        '
        'Nbg_Licitaciones
        '
        Me.Nbg_Licitaciones.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarListaLicitaciones, Me.Nbi_CrearLicitacion, Me.Nbi_EditarLicitacion, Me.Nbi_ClonarLicitacion, Me.Nbi_BuscarLicitaciones, Me.Nbi_SeleccionarLicitacion, Me.Nbi_PermisosLicitacion, Me.Nbi_ImprimirLicitacion, Me.Nbi_EliminarLicitacion, Me.Nbi_VerMaquinariaYEquipo, Me.Nbi_VerMaterialesLicitacion, Me.Nbi_VerManoDeObra})
        Me.Nbg_Licitaciones.Name = "Nbg_Licitaciones"
        Me.Nbg_Licitaciones.Tag = "583"
        Me.Nbg_Licitaciones.Text = "Licitaciones"
        '
        'Nbi_CargarListaLicitaciones
        '
        Me.Nbi_CargarListaLicitaciones.Name = "Nbi_CargarListaLicitaciones"
        Me.Nbi_CargarListaLicitaciones.Tag = "584"
        Me.Nbi_CargarListaLicitaciones.Text = "Cargar Listado"
        '
        'Nbi_CrearLicitacion
        '
        Me.Nbi_CrearLicitacion.Name = "Nbi_CrearLicitacion"
        Me.Nbi_CrearLicitacion.Tag = "585"
        Me.Nbi_CrearLicitacion.Text = "Crear"
        '
        'Nbi_EditarLicitacion
        '
        Me.Nbi_EditarLicitacion.Name = "Nbi_EditarLicitacion"
        Me.Nbi_EditarLicitacion.Tag = "586"
        Me.Nbi_EditarLicitacion.Text = "Editar"
        '
        'Nbi_ClonarLicitacion
        '
        Me.Nbi_ClonarLicitacion.Name = "Nbi_ClonarLicitacion"
        Me.Nbi_ClonarLicitacion.Tag = "587"
        Me.Nbi_ClonarLicitacion.Text = "Clonar"
        '
        'Nbi_BuscarLicitaciones
        '
        Me.Nbi_BuscarLicitaciones.Name = "Nbi_BuscarLicitaciones"
        Me.Nbi_BuscarLicitaciones.Tag = "588"
        Me.Nbi_BuscarLicitaciones.Text = "Buscar"
        '
        'Nbi_SeleccionarLicitacion
        '
        Me.Nbi_SeleccionarLicitacion.Name = "Nbi_SeleccionarLicitacion"
        Me.Nbi_SeleccionarLicitacion.Tag = "589"
        Me.Nbi_SeleccionarLicitacion.Text = "Seleccionar Licitación"
        '
        'Nbi_PermisosLicitacion
        '
        Me.Nbi_PermisosLicitacion.Name = "Nbi_PermisosLicitacion"
        Me.Nbi_PermisosLicitacion.Tag = "590"
        Me.Nbi_PermisosLicitacion.Text = "Asignar Permisos"
        '
        'Nbi_ImprimirLicitacion
        '
        Me.Nbi_ImprimirLicitacion.Name = "Nbi_ImprimirLicitacion"
        Me.Nbi_ImprimirLicitacion.Tag = "591"
        Me.Nbi_ImprimirLicitacion.Text = "Imprimir"
        '
        'Nbi_EliminarLicitacion
        '
        Me.Nbi_EliminarLicitacion.Name = "Nbi_EliminarLicitacion"
        Me.Nbi_EliminarLicitacion.Tag = "592"
        Me.Nbi_EliminarLicitacion.Text = "Eliminar"
        '
        'Nbi_VerMaquinariaYEquipo
        '
        Me.Nbi_VerMaquinariaYEquipo.Name = "Nbi_VerMaquinariaYEquipo"
        Me.Nbi_VerMaquinariaYEquipo.Tag = "594"
        Me.Nbi_VerMaquinariaYEquipo.Text = "Ver Maquinaria y Equipo"
        '
        'Nbi_VerMaterialesLicitacion
        '
        Me.Nbi_VerMaterialesLicitacion.Name = "Nbi_VerMaterialesLicitacion"
        Me.Nbi_VerMaterialesLicitacion.Tag = "593"
        Me.Nbi_VerMaterialesLicitacion.Text = "Ver Materiales"
        '
        'Nbi_VerManoDeObra
        '
        Me.Nbi_VerManoDeObra.Name = "Nbi_VerManoDeObra"
        Me.Nbi_VerManoDeObra.Tag = "595"
        Me.Nbi_VerManoDeObra.Text = "Ver Mano De Obra"
        '
        'Nbg_Herramientas
        '
        Me.Nbg_Herramientas.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_Soldadura, Me.Nbi_DiscosyGratas, Me.Nbi_Revestimiento, Me.Nbi_OxígenoAcetileno, Me.Nbi_AgregarTipoUnidad})
        Me.Nbg_Herramientas.Name = "Nbg_Herramientas"
        Me.Nbg_Herramientas.Tag = "628"
        Me.Nbg_Herramientas.Text = "Herramientas"
        '
        'Nbi_Soldadura
        '
        Me.Nbi_Soldadura.Name = "Nbi_Soldadura"
        Me.Nbi_Soldadura.Tag = "629"
        Me.Nbi_Soldadura.Text = "Soldadura"
        '
        'Nbi_DiscosyGratas
        '
        Me.Nbi_DiscosyGratas.Name = "Nbi_DiscosyGratas"
        Me.Nbi_DiscosyGratas.Tag = "630"
        Me.Nbi_DiscosyGratas.Text = "Discos y Gratas"
        '
        'Nbi_Revestimiento
        '
        Me.Nbi_Revestimiento.Name = "Nbi_Revestimiento"
        Me.Nbi_Revestimiento.Tag = "631"
        Me.Nbi_Revestimiento.Text = "Revestimiento"
        '
        'Nbi_OxígenoAcetileno
        '
        Me.Nbi_OxígenoAcetileno.Name = "Nbi_OxígenoAcetileno"
        Me.Nbi_OxígenoAcetileno.Tag = "632"
        Me.Nbi_OxígenoAcetileno.Text = "Oxígeno Acetileno"
        '
        'Nbi_AgregarTipoUnidad
        '
        Me.Nbi_AgregarTipoUnidad.Name = "Nbi_AgregarTipoUnidad"
        Me.Nbi_AgregarTipoUnidad.Tag = "634"
        Me.Nbi_AgregarTipoUnidad.Text = "Agregar Tipos de Unidad"
        '
        'Cms_OpcionesItems
        '
        Me.Cms_OpcionesItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Apu_EditarToolStripMenuItem, Me.Apu_ClonarToolStripMenuItem, Me.Apu_EliminarToolStripMenuItem})
        Me.Cms_OpcionesItems.Name = "Cms_Ordenar"
        Me.Cms_OpcionesItems.Size = New System.Drawing.Size(118, 70)
        '
        'Apu_EditarToolStripMenuItem
        '
        Me.Apu_EditarToolStripMenuItem.Name = "Apu_EditarToolStripMenuItem"
        Me.Apu_EditarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.Apu_EditarToolStripMenuItem.Tag = "599"
        Me.Apu_EditarToolStripMenuItem.Text = "Editar"
        '
        'Apu_ClonarToolStripMenuItem
        '
        Me.Apu_ClonarToolStripMenuItem.Name = "Apu_ClonarToolStripMenuItem"
        Me.Apu_ClonarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.Apu_ClonarToolStripMenuItem.Tag = "600"
        Me.Apu_ClonarToolStripMenuItem.Text = "Clonar"
        '
        'Apu_EliminarToolStripMenuItem
        '
        Me.Apu_EliminarToolStripMenuItem.Name = "Apu_EliminarToolStripMenuItem"
        Me.Apu_EliminarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.Apu_EliminarToolStripMenuItem.Tag = "605"
        Me.Apu_EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'Cms_OpcionesEquipos
        '
        Me.Cms_OpcionesEquipos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ME_EditarToolStripMenuItem, Me.ME_ClonarToolStripMenuItem, Me.ME_EliminarToolStripMenuItem})
        Me.Cms_OpcionesEquipos.Name = "Cms_Ordenar"
        Me.Cms_OpcionesEquipos.Size = New System.Drawing.Size(118, 70)
        '
        'ME_EditarToolStripMenuItem
        '
        Me.ME_EditarToolStripMenuItem.Name = "ME_EditarToolStripMenuItem"
        Me.ME_EditarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ME_EditarToolStripMenuItem.Tag = "616"
        Me.ME_EditarToolStripMenuItem.Text = "Editar"
        '
        'ME_ClonarToolStripMenuItem
        '
        Me.ME_ClonarToolStripMenuItem.Name = "ME_ClonarToolStripMenuItem"
        Me.ME_ClonarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ME_ClonarToolStripMenuItem.Tag = "617"
        Me.ME_ClonarToolStripMenuItem.Text = "Clonar"
        '
        'ME_EliminarToolStripMenuItem
        '
        Me.ME_EliminarToolStripMenuItem.Name = "ME_EliminarToolStripMenuItem"
        Me.ME_EliminarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ME_EliminarToolStripMenuItem.Tag = "619"
        Me.ME_EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'Cms_OpcionesMaterial
        '
        Me.Cms_OpcionesMaterial.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Ma_EditarToolStripMenuItem, Me.Ma_ClonarToolStripMenuItem, Me.Ma_EliminarToolStripMenuItem})
        Me.Cms_OpcionesMaterial.Name = "Cms_Ordenar"
        Me.Cms_OpcionesMaterial.Size = New System.Drawing.Size(118, 70)
        '
        'Ma_EditarToolStripMenuItem
        '
        Me.Ma_EditarToolStripMenuItem.Name = "Ma_EditarToolStripMenuItem"
        Me.Ma_EditarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.Ma_EditarToolStripMenuItem.Tag = "609"
        Me.Ma_EditarToolStripMenuItem.Text = "Editar"
        '
        'Ma_ClonarToolStripMenuItem
        '
        Me.Ma_ClonarToolStripMenuItem.Name = "Ma_ClonarToolStripMenuItem"
        Me.Ma_ClonarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.Ma_ClonarToolStripMenuItem.Tag = "610"
        Me.Ma_ClonarToolStripMenuItem.Text = "Clonar"
        '
        'Ma_EliminarToolStripMenuItem
        '
        Me.Ma_EliminarToolStripMenuItem.Name = "Ma_EliminarToolStripMenuItem"
        Me.Ma_EliminarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.Ma_EliminarToolStripMenuItem.Tag = "612"
        Me.Ma_EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'Cms_OpcionesManoDeObra
        '
        Me.Cms_OpcionesManoDeObra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MO_EditarToolStripMenuItem, Me.MO_ClonarToolStripMenuItem, Me.MO_EliminarToolStripMenuItem})
        Me.Cms_OpcionesManoDeObra.Name = "Cms_Ordenar"
        Me.Cms_OpcionesManoDeObra.Size = New System.Drawing.Size(118, 70)
        '
        'MO_EditarToolStripMenuItem
        '
        Me.MO_EditarToolStripMenuItem.Name = "MO_EditarToolStripMenuItem"
        Me.MO_EditarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.MO_EditarToolStripMenuItem.Tag = "623"
        Me.MO_EditarToolStripMenuItem.Text = "Editar"
        '
        'MO_ClonarToolStripMenuItem
        '
        Me.MO_ClonarToolStripMenuItem.Name = "MO_ClonarToolStripMenuItem"
        Me.MO_ClonarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.MO_ClonarToolStripMenuItem.Tag = "624"
        Me.MO_ClonarToolStripMenuItem.Text = "Clonar"
        '
        'MO_EliminarToolStripMenuItem
        '
        Me.MO_EliminarToolStripMenuItem.Name = "MO_EliminarToolStripMenuItem"
        Me.MO_EliminarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.MO_EliminarToolStripMenuItem.Tag = "626"
        Me.MO_EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'Cu_Licitaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pn_ContenedorPrincipal)
        Me.Controls.Add(Me.Nbc_Licitaciones)
        Me.Name = "Cu_Licitaciones"
        Me.Size = New System.Drawing.Size(1025, 530)
        CType(Me.Dgv_Equipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_ContenedorPrincipal.ResumeLayout(False)
        Me.SC_Principal.Panel1.ResumeLayout(False)
        Me.SC_Principal.Panel2.ResumeLayout(False)
        CType(Me.SC_Principal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SC_Principal.ResumeLayout(False)
        CType(Me.Dgv_Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tlp_Totales.ResumeLayout(False)
        Me.Flp_TotalCostoDirecto.ResumeLayout(False)
        Me.Flp_TotalCostoDirecto.PerformLayout()
        Me.Flp_Administracion.ResumeLayout(False)
        Me.Flp_Administracion.PerformLayout()
        Me.Flp_Imprevistos.ResumeLayout(False)
        Me.Flp_Imprevistos.PerformLayout()
        Me.Flp_Utilidades.ResumeLayout(False)
        Me.Flp_Utilidades.PerformLayout()
        Me.Flp_TotalCosto.ResumeLayout(False)
        Me.Flp_TotalCosto.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel5.PerformLayout()
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.FlowLayoutPanel6.PerformLayout()
        Me.FlowLayoutPanel7.ResumeLayout(False)
        Me.FlowLayoutPanel7.PerformLayout()
        Me.FlowLayoutPanel8.ResumeLayout(False)
        Me.FlowLayoutPanel8.PerformLayout()
        Me.FlowLayoutPanel9.ResumeLayout(False)
        Me.FlowLayoutPanel9.PerformLayout()
        Me.FlowLayoutPanel10.ResumeLayout(False)
        Me.FlowLayoutPanel10.PerformLayout()
        Me.Pn_ContenedorTitulo.ResumeLayout(False)
        Me.Pn_tituloformulario.ResumeLayout(False)
        Me.Sc_EquipoManoObra.Panel1.ResumeLayout(False)
        Me.Sc_EquipoManoObra.Panel2.ResumeLayout(False)
        CType(Me.Sc_EquipoManoObra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_EquipoManoObra.ResumeLayout(False)
        Me.Sc_MaterialesEquipo.Panel1.ResumeLayout(False)
        Me.Sc_MaterialesEquipo.Panel2.ResumeLayout(False)
        CType(Me.Sc_MaterialesEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_MaterialesEquipo.ResumeLayout(False)
        Me.Pn_Equipos.ResumeLayout(False)
        CType(Me.Dgv_Materiales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Materiales.ResumeLayout(False)
        CType(Me.Dgv_ManodeObra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_ManoDeObra.ResumeLayout(False)
        Me.Cms_OpcionesLicitacion.ResumeLayout(False)
        Me.Cms_OpcionesItems.ResumeLayout(False)
        Me.Cms_OpcionesEquipos.ResumeLayout(False)
        Me.Cms_OpcionesMaterial.ResumeLayout(False)
        Me.Cms_OpcionesManoDeObra.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv_Equipos As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_ContenedorPrincipal As System.Windows.Forms.Panel
    Friend WithEvents SC_Principal As System.Windows.Forms.SplitContainer
    Friend WithEvents Dgv_Lista As System.Windows.Forms.DataGridView
    Friend WithEvents Cms_OpcionesLicitacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Pn_ContenedorTitulo As System.Windows.Forms.Panel
    Friend WithEvents Lb_ListaPrincipal As System.Windows.Forms.Label
    Friend WithEvents Pg_DetalleLista As System.Windows.Forms.PropertyGrid
    Friend WithEvents Lb_Propiedades As System.Windows.Forms.Label
    Friend WithEvents Pn_tituloformulario As System.Windows.Forms.Panel
    Friend WithEvents Lb_NombreLicitacion As System.Windows.Forms.Label
    Friend WithEvents Nbg_ManoDeObra As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_ClonarEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Equipo As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_BuscarEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirItems As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EliminarItems As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ClonarItems As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ClonarMaterial As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarMaterial As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarMaterial As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearMaterial As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Materiales As NetBarControl.NetBarGroup
    Friend WithEvents Nbc_Licitaciones As NetBarControl.NetBarControl
    Friend WithEvents Nbg_Licitaciones As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CrearLicitacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarLicitacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SeleccionarLicitacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_PermisosLicitacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarLicitaciones As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ClonarLicitacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirLicitacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EliminarLicitacion As NetBarControl.NetBarItem
    Friend WithEvents Nbg_APUItems As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CrearItems As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarItems As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImportarItems As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ExportarItems As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarItems As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Herramientas As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_EliminarMaterial As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearManoDeObra As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarManoDeObra As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ClonarManoDeObra As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarManoDeObra As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EliminarManoDeObra As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EliminarEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Soldadura As NetBarControl.NetBarItem
    Friend WithEvents Nbi_DiscosyGratas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Revestimiento As NetBarControl.NetBarItem
    Friend WithEvents Nbi_OxígenoAcetileno As NetBarControl.NetBarItem
    Friend WithEvents Sc_EquipoManoObra As System.Windows.Forms.SplitContainer
    Friend WithEvents Sc_MaterialesEquipo As System.Windows.Forms.SplitContainer
    Friend WithEvents Dgv_Materiales As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Materiales As System.Windows.Forms.Panel
    Friend WithEvents Lb_Materiales As System.Windows.Forms.Label
    Friend WithEvents Pn_Equipos As System.Windows.Forms.Panel
    Friend WithEvents Lb_MovimientoDos As System.Windows.Forms.Label
    Friend WithEvents Pn_ManoDeObra As System.Windows.Forms.Panel
    Friend WithEvents Lb_ManoDeObra As System.Windows.Forms.Label
    Friend WithEvents Dgv_ManodeObra As System.Windows.Forms.DataGridView
    Friend WithEvents Nbi_VerMaterialesLicitacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarListaLicitaciones As NetBarControl.NetBarItem
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Nbi_CargarItems As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerMaquinariaYEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerManoDeObra As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarEquipos As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarMateriales As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarManoDeObra As NetBarControl.NetBarItem
    Friend WithEvents Cms_OpcionesItems As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Cms_OpcionesEquipos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Cms_OpcionesMaterial As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Cms_OpcionesManoDeObra As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Lic_SeleccionarLicToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Lic_EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lic_ClonarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lic_ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lic_EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Apu_EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Apu_ClonarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Apu_EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ME_EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ME_ClonarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ME_EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Ma_EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Ma_ClonarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Ma_EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MO_EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MO_ClonarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MO_EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_AgregarTipoUnidad As NetBarControl.NetBarItem
    Friend WithEvents Tlp_Totales As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Flp_TotalCostoDirecto As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_TotalCostoDirecto As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoTotalCostoDirecto As System.Windows.Forms.Label
    Friend WithEvents Flp_Administracion As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_TotalAdministracion As System.Windows.Forms.Label
    Friend WithEvents Lb_PorcentajeAdministracion As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoAdministracion As System.Windows.Forms.Label
    Friend WithEvents Flp_Imprevistos As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_TotalImprevistos As System.Windows.Forms.Label
    Friend WithEvents Lb_PorcentajeImprevistos As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoImprevistos As System.Windows.Forms.Label
    Friend WithEvents Flp_Utilidades As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_TotalUtilidades As System.Windows.Forms.Label
    Friend WithEvents Lb_PorcentajeUtilidades As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoUtilidades As System.Windows.Forms.Label
    Friend WithEvents Flp_TotalCosto As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_TotalCosto As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoTotalCosto As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel4 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel5 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel6 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel7 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel8 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel9 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_TextoTotalHorasHombre As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel10 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_TotalHorasHombre As System.Windows.Forms.Label
    Friend WithEvents Nbi_ImportarEstructura As NetBarControl.NetBarItem

End Class
