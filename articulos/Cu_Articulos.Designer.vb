<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Articulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cu_Articulos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Tv_Grupos = New System.Windows.Forms.TreeView()
        Me.Il_Materiales = New System.Windows.Forms.ImageList(Me.components)
        Me.Lb_TituloArbol = New System.Windows.Forms.Label()
        Me.Sc_Listado = New System.Windows.Forms.SplitContainer()
        Me.Dgv_Articulos = New System.Windows.Forms.DataGridView()
        Me.Cms_Artículos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SacarDeControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Pn_Bt_Opciones = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBt_BuscarArticulo = New System.Windows.Forms.ToolStripButton()
        Me.TSBt_ImprimirSticker = New System.Windows.Forms.ToolStripButton()
        Me.TSBt_EditarTS = New System.Windows.Forms.ToolStripButton()
        Me.TSBt_VerInventarios = New System.Windows.Forms.ToolStripButton()
        Me.TSBt_UyStock = New System.Windows.Forms.ToolStripButton()
        Me.TSBt_TrazabilidadxBase = New System.Windows.Forms.ToolStripButton()
        Me.TSBt_Trazabilidad = New System.Windows.Forms.ToolStripButton()
        Me.Lb_TituloListado = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Pg_DetalleLista = New System.Windows.Forms.PropertyGrid()
        Me.Lb_Propiedades = New System.Windows.Forms.Label()
        Me.Pb_FotoArticulo = New System.Windows.Forms.PictureBox()
        Me.Ck_MostrarFotoArticulo = New System.Windows.Forms.CheckBox()
        Me.Sc_Detalle = New System.Windows.Forms.SplitContainer()
        Me.Dgv_TablaDisponibilidad = New System.Windows.Forms.DataGridView()
        Me.Lb_TituloDisponibilidad = New System.Windows.Forms.Label()
        Me.Ck_MostrarDisponibilidad = New System.Windows.Forms.CheckBox()
        Me.Dgv_TablaProveedores = New System.Windows.Forms.DataGridView()
        Me.Lb_TituloProveedor = New System.Windows.Forms.Label()
        Me.Ck_ProveedoresArticulo = New System.Windows.Forms.CheckBox()
        Me.Cms_SubClase = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_CrearTipoCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_EliminarSubClase = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_CambiarNombreSubClase = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_StockXArbol_SubClase = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_TipoCategoría = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_CrearCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_ModificarTipoCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_EliminarTipoCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_CambiarNombreTipoCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_StockXArbol_TipoCategoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_Categoría = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_CrearTipoCategoríaStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_ModificarCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_CrearArtículo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_EliminarCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_CambiarNombreCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_StockXArbol_Categoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_CategoríaSinCategoria = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_ModificarCategoria2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_CrearArtículo2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_EliminarCategoríaSinCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_CambiarNombreCategoríaSinCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_StockXArbol_Categoria2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_Grupo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_CrearClase = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_EliminarGrupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_CambiarNombreGrupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_StockXArbol_Grupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_Familia = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_CrearGrupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_EliminarFamilia = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_CambiarNombreFamilia = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_StockXArbol_Familia = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_SubClaseSinCategoría = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_EliminarSubClaseSinCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_CambiarNombreSubClaseSinCategoría = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_StockXArbol_SubClase2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_Clase = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_CrearSubclase = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_EliminarClase = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_CambiarNombreClase = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_StockXArbol_Clase = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sc_Articulos = New System.Windows.Forms.SplitContainer()
        Me.Nbc_Articulos = New NetBarControl.NetBarControl()
        Me.Nbg_Articulo = New NetBarControl.NetBarGroup()
        Me.Nbi_BuscarArticulo = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirSticker = New NetBarControl.NetBarItem()
        Me.Nbi_EditarTipos = New NetBarControl.NetBarItem()
        Me.Nbi_VerInventario = New NetBarControl.NetBarItem()
        Me.Nbi_FijarCaracteristicaArticulo = New NetBarControl.NetBarItem()
        Me.Nbi_TrazabilidadArticulo = New NetBarControl.NetBarItem()
        Me.Nbi_TrazabilidadArticuloTotal = New NetBarControl.NetBarItem()
        Me.Nbi_DistribucionArticuloxCant = New NetBarControl.NetBarItem()
        Me.Nbgcc_Arbol = New NetBarControl.NetBarGroupControlContainer()
        Me.Nbg_Arbol = New NetBarControl.NetBarGroup()
        Me.Im_Defecto = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Sc_Listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sc_Listado.Panel1.SuspendLayout()
        Me.Sc_Listado.Panel2.SuspendLayout()
        Me.Sc_Listado.SuspendLayout()
        CType(Me.Dgv_Articulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_Artículos.SuspendLayout()
        Me.Pn_Bt_Opciones.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Pb_FotoArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sc_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sc_Detalle.Panel1.SuspendLayout()
        Me.Sc_Detalle.Panel2.SuspendLayout()
        Me.Sc_Detalle.SuspendLayout()
        CType(Me.Dgv_TablaDisponibilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_TablaProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_SubClase.SuspendLayout()
        Me.Cms_TipoCategoría.SuspendLayout()
        Me.Cms_Categoría.SuspendLayout()
        Me.Cms_CategoríaSinCategoria.SuspendLayout()
        Me.Cms_Grupo.SuspendLayout()
        Me.Cms_Familia.SuspendLayout()
        Me.Cms_SubClaseSinCategoría.SuspendLayout()
        Me.Cms_Clase.SuspendLayout()
        CType(Me.Sc_Articulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sc_Articulos.Panel1.SuspendLayout()
        Me.Sc_Articulos.Panel2.SuspendLayout()
        Me.Sc_Articulos.SuspendLayout()
        Me.Nbc_Articulos.SuspendLayout()
        Me.Nbgcc_Arbol.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tv_Grupos
        '
        Me.Tv_Grupos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tv_Grupos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tv_Grupos.ImageIndex = 0
        Me.Tv_Grupos.ImageList = Me.Il_Materiales
        Me.Tv_Grupos.Location = New System.Drawing.Point(0, 0)
        Me.Tv_Grupos.Name = "Tv_Grupos"
        Me.Tv_Grupos.SelectedImageIndex = 1
        Me.Tv_Grupos.Size = New System.Drawing.Size(291, 521)
        Me.Tv_Grupos.TabIndex = 0
        '
        'Il_Materiales
        '
        Me.Il_Materiales.ImageStream = CType(resources.GetObject("Il_Materiales.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Il_Materiales.TransparentColor = System.Drawing.Color.Transparent
        Me.Il_Materiales.Images.SetKeyName(0, "112_RightArrowShort_Blue_16x16_72.png")
        Me.Il_Materiales.Images.SetKeyName(1, "112_RightArrowShort_Green_16x16_72.png")
        Me.Il_Materiales.Images.SetKeyName(2, "112_RightArrowShort_Orange_16x16_72.png")
        '
        'Lb_TituloArbol
        '
        Me.Lb_TituloArbol.BackColor = System.Drawing.SystemColors.Control
        Me.Lb_TituloArbol.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Lb_TituloArbol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TituloArbol.ForeColor = System.Drawing.Color.Black
        Me.Lb_TituloArbol.Location = New System.Drawing.Point(0, 521)
        Me.Lb_TituloArbol.Name = "Lb_TituloArbol"
        Me.Lb_TituloArbol.Size = New System.Drawing.Size(291, 20)
        Me.Lb_TituloArbol.TabIndex = 1
        Me.Lb_TituloArbol.Text = "Ver codificación en el árbol"
        Me.Lb_TituloArbol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Sc_Listado
        '
        Me.Sc_Listado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sc_Listado.Location = New System.Drawing.Point(0, 0)
        Me.Sc_Listado.Name = "Sc_Listado"
        '
        'Sc_Listado.Panel1
        '
        Me.Sc_Listado.Panel1.Controls.Add(Me.Dgv_Articulos)
        Me.Sc_Listado.Panel1.Controls.Add(Me.Tx_Descripcion)
        Me.Sc_Listado.Panel1.Controls.Add(Me.Pn_Bt_Opciones)
        Me.Sc_Listado.Panel1.Controls.Add(Me.Lb_TituloListado)
        '
        'Sc_Listado.Panel2
        '
        Me.Sc_Listado.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Sc_Listado.Size = New System.Drawing.Size(700, 500)
        Me.Sc_Listado.SplitterDistance = 500
        Me.Sc_Listado.TabIndex = 14
        '
        'Dgv_Articulos
        '
        Me.Dgv_Articulos.AllowUserToAddRows = False
        Me.Dgv_Articulos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Articulos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Articulos.ContextMenuStrip = Me.Cms_Artículos
        Me.Dgv_Articulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Articulos.Location = New System.Drawing.Point(0, 111)
        Me.Dgv_Articulos.Name = "Dgv_Articulos"
        Me.Dgv_Articulos.ReadOnly = True
        Me.Dgv_Articulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Articulos.Size = New System.Drawing.Size(500, 389)
        Me.Dgv_Articulos.TabIndex = 0
        '
        'Cms_Artículos
        '
        Me.Cms_Artículos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificarArtículoToolStripMenuItem, Me.EliminarArtículoToolStripMenuItem, Me.AgregarControlToolStripMenuItem, Me.SacarDeControlToolStripMenuItem})
        Me.Cms_Artículos.Name = "Cms_Artículos"
        Me.Cms_Artículos.Size = New System.Drawing.Size(246, 92)
        Me.Cms_Artículos.Tag = "253"
        '
        'ModificarArtículoToolStripMenuItem
        '
        Me.ModificarArtículoToolStripMenuItem.Name = "ModificarArtículoToolStripMenuItem"
        Me.ModificarArtículoToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ModificarArtículoToolStripMenuItem.Tag = "253"
        Me.ModificarArtículoToolStripMenuItem.Text = "Modificar Artículo"
        '
        'EliminarArtículoToolStripMenuItem
        '
        Me.EliminarArtículoToolStripMenuItem.Name = "EliminarArtículoToolStripMenuItem"
        Me.EliminarArtículoToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.EliminarArtículoToolStripMenuItem.Tag = "253"
        Me.EliminarArtículoToolStripMenuItem.Text = "Eliminar Artículos Seleccionados"
        '
        'AgregarControlToolStripMenuItem
        '
        Me.AgregarControlToolStripMenuItem.Name = "AgregarControlToolStripMenuItem"
        Me.AgregarControlToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.AgregarControlToolStripMenuItem.Tag = "253"
        Me.AgregarControlToolStripMenuItem.Text = "Agregar Control..."
        '
        'SacarDeControlToolStripMenuItem
        '
        Me.SacarDeControlToolStripMenuItem.Name = "SacarDeControlToolStripMenuItem"
        Me.SacarDeControlToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.SacarDeControlToolStripMenuItem.Tag = "253"
        Me.SacarDeControlToolStripMenuItem.Text = "Quitar de Control"
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_Descripcion.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tx_Descripcion.Location = New System.Drawing.Point(0, 71)
        Me.Tx_Descripcion.Margin = New System.Windows.Forms.Padding(10)
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.ReadOnly = True
        Me.Tx_Descripcion.Size = New System.Drawing.Size(500, 40)
        Me.Tx_Descripcion.TabIndex = 13
        '
        'Pn_Bt_Opciones
        '
        Me.Pn_Bt_Opciones.Controls.Add(Me.ToolStrip1)
        Me.Pn_Bt_Opciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Bt_Opciones.Location = New System.Drawing.Point(0, 18)
        Me.Pn_Bt_Opciones.Name = "Pn_Bt_Opciones"
        Me.Pn_Bt_Opciones.Size = New System.Drawing.Size(500, 53)
        Me.Pn_Bt_Opciones.TabIndex = 20
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBt_BuscarArticulo, Me.TSBt_ImprimirSticker, Me.TSBt_EditarTS, Me.TSBt_VerInventarios, Me.TSBt_UyStock, Me.TSBt_TrazabilidadxBase, Me.TSBt_Trazabilidad})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(500, 53)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBt_BuscarArticulo
        '
        Me.TSBt_BuscarArticulo.Image = CType(resources.GetObject("TSBt_BuscarArticulo.Image"), System.Drawing.Image)
        Me.TSBt_BuscarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBt_BuscarArticulo.Name = "TSBt_BuscarArticulo"
        Me.TSBt_BuscarArticulo.Size = New System.Drawing.Size(62, 20)
        Me.TSBt_BuscarArticulo.Tag = "348"
        Me.TSBt_BuscarArticulo.Text = "Buscar"
        '
        'TSBt_ImprimirSticker
        '
        Me.TSBt_ImprimirSticker.Image = CType(resources.GetObject("TSBt_ImprimirSticker.Image"), System.Drawing.Image)
        Me.TSBt_ImprimirSticker.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBt_ImprimirSticker.Name = "TSBt_ImprimirSticker"
        Me.TSBt_ImprimirSticker.Size = New System.Drawing.Size(111, 20)
        Me.TSBt_ImprimirSticker.Tag = "349"
        Me.TSBt_ImprimirSticker.Text = "Imprimir Sticker"
        '
        'TSBt_EditarTS
        '
        Me.TSBt_EditarTS.Image = CType(resources.GetObject("TSBt_EditarTS.Image"), System.Drawing.Image)
        Me.TSBt_EditarTS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBt_EditarTS.Name = "TSBt_EditarTS"
        Me.TSBt_EditarTS.Size = New System.Drawing.Size(138, 20)
        Me.TSBt_EditarTS.Tag = "349"
        Me.TSBt_EditarTS.Text = "Editar Tipos/subtipos"
        '
        'TSBt_VerInventarios
        '
        Me.TSBt_VerInventarios.Image = CType(resources.GetObject("TSBt_VerInventarios.Image"), System.Drawing.Image)
        Me.TSBt_VerInventarios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBt_VerInventarios.Name = "TSBt_VerInventarios"
        Me.TSBt_VerInventarios.Size = New System.Drawing.Size(104, 20)
        Me.TSBt_VerInventarios.Tag = "349"
        Me.TSBt_VerInventarios.Text = "Ver Inventarios"
        '
        'TSBt_UyStock
        '
        Me.TSBt_UyStock.Image = CType(resources.GetObject("TSBt_UyStock.Image"), System.Drawing.Image)
        Me.TSBt_UyStock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBt_UyStock.Name = "TSBt_UyStock"
        Me.TSBt_UyStock.Size = New System.Drawing.Size(121, 20)
        Me.TSBt_UyStock.Tag = "349"
        Me.TSBt_UyStock.Text = "Ubicación y Stock"
        '
        'TSBt_TrazabilidadxBase
        '
        Me.TSBt_TrazabilidadxBase.Image = CType(resources.GetObject("TSBt_TrazabilidadxBase.Image"), System.Drawing.Image)
        Me.TSBt_TrazabilidadxBase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBt_TrazabilidadxBase.Name = "TSBt_TrazabilidadxBase"
        Me.TSBt_TrazabilidadxBase.Size = New System.Drawing.Size(125, 20)
        Me.TSBt_TrazabilidadxBase.Tag = "349"
        Me.TSBt_TrazabilidadxBase.Text = "Trazabilidad x Base"
        '
        'TSBt_Trazabilidad
        '
        Me.TSBt_Trazabilidad.Image = CType(resources.GetObject("TSBt_Trazabilidad.Image"), System.Drawing.Image)
        Me.TSBt_Trazabilidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBt_Trazabilidad.Name = "TSBt_Trazabilidad"
        Me.TSBt_Trazabilidad.Size = New System.Drawing.Size(89, 20)
        Me.TSBt_Trazabilidad.Tag = "349"
        Me.TSBt_Trazabilidad.Text = "Trazabilidad"
        '
        'Lb_TituloListado
        '
        Me.Lb_TituloListado.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Lb_TituloListado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_TituloListado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TituloListado.ForeColor = System.Drawing.Color.Black
        Me.Lb_TituloListado.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TituloListado.Name = "Lb_TituloListado"
        Me.Lb_TituloListado.Size = New System.Drawing.Size(500, 18)
        Me.Lb_TituloListado.TabIndex = 19
        Me.Lb_TituloListado.Text = "Listado de artículos"
        Me.Lb_TituloListado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Pg_DetalleLista)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Lb_Propiedades)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Pb_FotoArticulo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Ck_MostrarFotoArticulo)
        Me.SplitContainer1.Panel2MinSize = 150
        Me.SplitContainer1.Size = New System.Drawing.Size(196, 500)
        Me.SplitContainer1.SplitterDistance = 346
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 21
        '
        'Pg_DetalleLista
        '
        Me.Pg_DetalleLista.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Pg_DetalleLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pg_DetalleLista.LineColor = System.Drawing.SystemColors.ControlDark
        Me.Pg_DetalleLista.Location = New System.Drawing.Point(0, 18)
        Me.Pg_DetalleLista.Name = "Pg_DetalleLista"
        Me.Pg_DetalleLista.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.Pg_DetalleLista.Size = New System.Drawing.Size(196, 328)
        Me.Pg_DetalleLista.TabIndex = 20
        '
        'Lb_Propiedades
        '
        Me.Lb_Propiedades.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Lb_Propiedades.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Propiedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Propiedades.ForeColor = System.Drawing.Color.Black
        Me.Lb_Propiedades.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Propiedades.Name = "Lb_Propiedades"
        Me.Lb_Propiedades.Size = New System.Drawing.Size(196, 18)
        Me.Lb_Propiedades.TabIndex = 18
        Me.Lb_Propiedades.Text = "Propiedades"
        Me.Lb_Propiedades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pb_FotoArticulo
        '
        Me.Pb_FotoArticulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pb_FotoArticulo.Location = New System.Drawing.Point(0, 27)
        Me.Pb_FotoArticulo.Name = "Pb_FotoArticulo"
        Me.Pb_FotoArticulo.Size = New System.Drawing.Size(196, 123)
        Me.Pb_FotoArticulo.TabIndex = 6
        Me.Pb_FotoArticulo.TabStop = False
        '
        'Ck_MostrarFotoArticulo
        '
        Me.Ck_MostrarFotoArticulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Ck_MostrarFotoArticulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Ck_MostrarFotoArticulo.Location = New System.Drawing.Point(0, 0)
        Me.Ck_MostrarFotoArticulo.Name = "Ck_MostrarFotoArticulo"
        Me.Ck_MostrarFotoArticulo.Size = New System.Drawing.Size(196, 27)
        Me.Ck_MostrarFotoArticulo.TabIndex = 7
        Me.Ck_MostrarFotoArticulo.Text = "Mostrar Foto Artículo"
        Me.Ck_MostrarFotoArticulo.UseVisualStyleBackColor = False
        '
        'Sc_Detalle
        '
        Me.Sc_Detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sc_Detalle.Location = New System.Drawing.Point(0, 0)
        Me.Sc_Detalle.Name = "Sc_Detalle"
        '
        'Sc_Detalle.Panel1
        '
        Me.Sc_Detalle.Panel1.Controls.Add(Me.Dgv_TablaDisponibilidad)
        Me.Sc_Detalle.Panel1.Controls.Add(Me.Lb_TituloDisponibilidad)
        Me.Sc_Detalle.Panel1.Controls.Add(Me.Ck_MostrarDisponibilidad)
        '
        'Sc_Detalle.Panel2
        '
        Me.Sc_Detalle.Panel2.Controls.Add(Me.Dgv_TablaProveedores)
        Me.Sc_Detalle.Panel2.Controls.Add(Me.Lb_TituloProveedor)
        Me.Sc_Detalle.Panel2.Controls.Add(Me.Ck_ProveedoresArticulo)
        Me.Sc_Detalle.Size = New System.Drawing.Size(700, 136)
        Me.Sc_Detalle.SplitterDistance = 356
        Me.Sc_Detalle.TabIndex = 0
        '
        'Dgv_TablaDisponibilidad
        '
        Me.Dgv_TablaDisponibilidad.AllowUserToAddRows = False
        Me.Dgv_TablaDisponibilidad.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Dgv_TablaDisponibilidad.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_TablaDisponibilidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_TablaDisponibilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_TablaDisponibilidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_TablaDisponibilidad.Location = New System.Drawing.Point(0, 37)
        Me.Dgv_TablaDisponibilidad.Name = "Dgv_TablaDisponibilidad"
        Me.Dgv_TablaDisponibilidad.Size = New System.Drawing.Size(356, 99)
        Me.Dgv_TablaDisponibilidad.TabIndex = 13
        '
        'Lb_TituloDisponibilidad
        '
        Me.Lb_TituloDisponibilidad.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Lb_TituloDisponibilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_TituloDisponibilidad.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_TituloDisponibilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TituloDisponibilidad.ForeColor = System.Drawing.Color.Black
        Me.Lb_TituloDisponibilidad.Location = New System.Drawing.Point(0, 17)
        Me.Lb_TituloDisponibilidad.Name = "Lb_TituloDisponibilidad"
        Me.Lb_TituloDisponibilidad.Size = New System.Drawing.Size(356, 20)
        Me.Lb_TituloDisponibilidad.TabIndex = 1
        Me.Lb_TituloDisponibilidad.Text = "DISPONIBILIDAD DE ARTÍCULO"
        Me.Lb_TituloDisponibilidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Ck_MostrarDisponibilidad
        '
        Me.Ck_MostrarDisponibilidad.BackColor = System.Drawing.Color.SkyBlue
        Me.Ck_MostrarDisponibilidad.Dock = System.Windows.Forms.DockStyle.Top
        Me.Ck_MostrarDisponibilidad.Location = New System.Drawing.Point(0, 0)
        Me.Ck_MostrarDisponibilidad.Name = "Ck_MostrarDisponibilidad"
        Me.Ck_MostrarDisponibilidad.Padding = New System.Windows.Forms.Padding(4, 1, 0, 0)
        Me.Ck_MostrarDisponibilidad.Size = New System.Drawing.Size(356, 17)
        Me.Ck_MostrarDisponibilidad.TabIndex = 2
        Me.Ck_MostrarDisponibilidad.Tag = "245"
        Me.Ck_MostrarDisponibilidad.Text = "Mostrar disponibilidad en las bodegas"
        Me.Ck_MostrarDisponibilidad.UseVisualStyleBackColor = False
        '
        'Dgv_TablaProveedores
        '
        Me.Dgv_TablaProveedores.AllowUserToAddRows = False
        Me.Dgv_TablaProveedores.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Dgv_TablaProveedores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_TablaProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_TablaProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_TablaProveedores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_TablaProveedores.Location = New System.Drawing.Point(0, 37)
        Me.Dgv_TablaProveedores.Name = "Dgv_TablaProveedores"
        Me.Dgv_TablaProveedores.Size = New System.Drawing.Size(340, 99)
        Me.Dgv_TablaProveedores.TabIndex = 15
        '
        'Lb_TituloProveedor
        '
        Me.Lb_TituloProveedor.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Lb_TituloProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_TituloProveedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_TituloProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TituloProveedor.ForeColor = System.Drawing.Color.Black
        Me.Lb_TituloProveedor.Location = New System.Drawing.Point(0, 17)
        Me.Lb_TituloProveedor.Name = "Lb_TituloProveedor"
        Me.Lb_TituloProveedor.Size = New System.Drawing.Size(340, 20)
        Me.Lb_TituloProveedor.TabIndex = 1
        Me.Lb_TituloProveedor.Text = "PROVEEDOR DE ARTÍCULO"
        Me.Lb_TituloProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Ck_ProveedoresArticulo
        '
        Me.Ck_ProveedoresArticulo.BackColor = System.Drawing.Color.SkyBlue
        Me.Ck_ProveedoresArticulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Ck_ProveedoresArticulo.Location = New System.Drawing.Point(0, 0)
        Me.Ck_ProveedoresArticulo.Name = "Ck_ProveedoresArticulo"
        Me.Ck_ProveedoresArticulo.Padding = New System.Windows.Forms.Padding(4, 1, 0, 0)
        Me.Ck_ProveedoresArticulo.Size = New System.Drawing.Size(340, 17)
        Me.Ck_ProveedoresArticulo.TabIndex = 3
        Me.Ck_ProveedoresArticulo.Tag = "246"
        Me.Ck_ProveedoresArticulo.Text = "Mostrar proveedores"
        Me.Ck_ProveedoresArticulo.UseVisualStyleBackColor = False
        '
        'Cms_SubClase
        '
        Me.Cms_SubClase.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_CrearTipoCategoría, Me.Tsmi_EliminarSubClase, Me.Tsmi_CambiarNombreSubClase, Me.Tsmi_StockXArbol_SubClase})
        Me.Cms_SubClase.Name = "Cms_Clase"
        Me.Cms_SubClase.Size = New System.Drawing.Size(232, 92)
        Me.Cms_SubClase.Tag = "250"
        '
        'Tsmi_CrearTipoCategoría
        '
        Me.Tsmi_CrearTipoCategoría.Name = "Tsmi_CrearTipoCategoría"
        Me.Tsmi_CrearTipoCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CrearTipoCategoría.Tag = "250"
        Me.Tsmi_CrearTipoCategoría.Text = "Crear Tipo Categoría"
        '
        'Tsmi_EliminarSubClase
        '
        Me.Tsmi_EliminarSubClase.Name = "Tsmi_EliminarSubClase"
        Me.Tsmi_EliminarSubClase.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_EliminarSubClase.Tag = "250"
        Me.Tsmi_EliminarSubClase.Text = "Eliminar SubClase"
        '
        'Tsmi_CambiarNombreSubClase
        '
        Me.Tsmi_CambiarNombreSubClase.Name = "Tsmi_CambiarNombreSubClase"
        Me.Tsmi_CambiarNombreSubClase.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CambiarNombreSubClase.Tag = "250"
        Me.Tsmi_CambiarNombreSubClase.Text = "Cambiar Nombre"
        '
        'Tsmi_StockXArbol_SubClase
        '
        Me.Tsmi_StockXArbol_SubClase.Name = "Tsmi_StockXArbol_SubClase"
        Me.Tsmi_StockXArbol_SubClase.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_StockXArbol_SubClase.Tag = "646"
        Me.Tsmi_StockXArbol_SubClase.Text = "Exportar Stock por Cód. Árbol"
        '
        'Cms_TipoCategoría
        '
        Me.Cms_TipoCategoría.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_CrearCategoría, Me.Tsmi_ModificarTipoCategoría, Me.Tsmi_EliminarTipoCategoría, Me.Tsmi_CambiarNombreTipoCategoría, Me.Tsmi_StockXArbol_TipoCategoria})
        Me.Cms_TipoCategoría.Name = "Cms_TipoCategoría"
        Me.Cms_TipoCategoría.Size = New System.Drawing.Size(232, 114)
        Me.Cms_TipoCategoría.Tag = "251"
        '
        'Tsmi_CrearCategoría
        '
        Me.Tsmi_CrearCategoría.Name = "Tsmi_CrearCategoría"
        Me.Tsmi_CrearCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CrearCategoría.Tag = "251"
        Me.Tsmi_CrearCategoría.Text = "Crear Categoría"
        '
        'Tsmi_ModificarTipoCategoría
        '
        Me.Tsmi_ModificarTipoCategoría.Name = "Tsmi_ModificarTipoCategoría"
        Me.Tsmi_ModificarTipoCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_ModificarTipoCategoría.Tag = "251"
        Me.Tsmi_ModificarTipoCategoría.Text = "Modificar Tipo Categoría"
        '
        'Tsmi_EliminarTipoCategoría
        '
        Me.Tsmi_EliminarTipoCategoría.Name = "Tsmi_EliminarTipoCategoría"
        Me.Tsmi_EliminarTipoCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_EliminarTipoCategoría.Tag = "251"
        Me.Tsmi_EliminarTipoCategoría.Text = "Eliminar Tipo Categoría"
        '
        'Tsmi_CambiarNombreTipoCategoría
        '
        Me.Tsmi_CambiarNombreTipoCategoría.Name = "Tsmi_CambiarNombreTipoCategoría"
        Me.Tsmi_CambiarNombreTipoCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CambiarNombreTipoCategoría.Tag = "251"
        Me.Tsmi_CambiarNombreTipoCategoría.Text = "Cambiar Nombre"
        '
        'Tsmi_StockXArbol_TipoCategoria
        '
        Me.Tsmi_StockXArbol_TipoCategoria.Name = "Tsmi_StockXArbol_TipoCategoria"
        Me.Tsmi_StockXArbol_TipoCategoria.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_StockXArbol_TipoCategoria.Tag = "646"
        Me.Tsmi_StockXArbol_TipoCategoria.Text = "Exportar Stock por Cód. Árbol"
        '
        'Cms_Categoría
        '
        Me.Cms_Categoría.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_CrearTipoCategoríaStrip, Me.Tsmi_ModificarCategoría, Me.Tsmi_CrearArtículo, Me.Tsmi_EliminarCategoría, Me.Tsmi_CambiarNombreCategoría, Me.Tsmi_StockXArbol_Categoria})
        Me.Cms_Categoría.Name = "Cms_Clase"
        Me.Cms_Categoría.Size = New System.Drawing.Size(232, 136)
        Me.Cms_Categoría.Tag = "252"
        '
        'Tsmi_CrearTipoCategoríaStrip
        '
        Me.Tsmi_CrearTipoCategoríaStrip.Name = "Tsmi_CrearTipoCategoríaStrip"
        Me.Tsmi_CrearTipoCategoríaStrip.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CrearTipoCategoríaStrip.Tag = "252"
        Me.Tsmi_CrearTipoCategoríaStrip.Text = "Crear Tipo Categoría"
        '
        'Tsmi_ModificarCategoría
        '
        Me.Tsmi_ModificarCategoría.Name = "Tsmi_ModificarCategoría"
        Me.Tsmi_ModificarCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_ModificarCategoría.Tag = "252"
        Me.Tsmi_ModificarCategoría.Text = "Modificar Categoría"
        '
        'Tsmi_CrearArtículo
        '
        Me.Tsmi_CrearArtículo.Name = "Tsmi_CrearArtículo"
        Me.Tsmi_CrearArtículo.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CrearArtículo.Tag = "252"
        Me.Tsmi_CrearArtículo.Text = "Crear Artículo"
        '
        'Tsmi_EliminarCategoría
        '
        Me.Tsmi_EliminarCategoría.Name = "Tsmi_EliminarCategoría"
        Me.Tsmi_EliminarCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_EliminarCategoría.Tag = "252"
        Me.Tsmi_EliminarCategoría.Text = "Eliminar Categoría"
        '
        'Tsmi_CambiarNombreCategoría
        '
        Me.Tsmi_CambiarNombreCategoría.Name = "Tsmi_CambiarNombreCategoría"
        Me.Tsmi_CambiarNombreCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CambiarNombreCategoría.Tag = "252"
        Me.Tsmi_CambiarNombreCategoría.Text = "Cambiar Nombre"
        '
        'Tsmi_StockXArbol_Categoria
        '
        Me.Tsmi_StockXArbol_Categoria.Name = "Tsmi_StockXArbol_Categoria"
        Me.Tsmi_StockXArbol_Categoria.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_StockXArbol_Categoria.Tag = "646"
        Me.Tsmi_StockXArbol_Categoria.Text = "Exportar Stock por Cód. Árbol"
        '
        'Cms_CategoríaSinCategoria
        '
        Me.Cms_CategoríaSinCategoria.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_ModificarCategoria2, Me.Tsmi_CrearArtículo2, Me.Tsmi_EliminarCategoríaSinCategoría, Me.Tsmi_CambiarNombreCategoríaSinCategoría, Me.Tsmi_StockXArbol_Categoria2})
        Me.Cms_CategoríaSinCategoria.Name = "Cms_Clase"
        Me.Cms_CategoríaSinCategoria.Size = New System.Drawing.Size(232, 114)
        Me.Cms_CategoríaSinCategoria.Tag = "252"
        '
        'Tsmi_ModificarCategoria2
        '
        Me.Tsmi_ModificarCategoria2.Name = "Tsmi_ModificarCategoria2"
        Me.Tsmi_ModificarCategoria2.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_ModificarCategoria2.Tag = "252"
        Me.Tsmi_ModificarCategoria2.Text = "Modificar Categoría"
        '
        'Tsmi_CrearArtículo2
        '
        Me.Tsmi_CrearArtículo2.Name = "Tsmi_CrearArtículo2"
        Me.Tsmi_CrearArtículo2.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CrearArtículo2.Tag = "252"
        Me.Tsmi_CrearArtículo2.Text = "Crear Artículo"
        '
        'Tsmi_EliminarCategoríaSinCategoría
        '
        Me.Tsmi_EliminarCategoríaSinCategoría.Name = "Tsmi_EliminarCategoríaSinCategoría"
        Me.Tsmi_EliminarCategoríaSinCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_EliminarCategoríaSinCategoría.Tag = "252"
        Me.Tsmi_EliminarCategoríaSinCategoría.Text = "Eliminar Categoría"
        '
        'Tsmi_CambiarNombreCategoríaSinCategoría
        '
        Me.Tsmi_CambiarNombreCategoríaSinCategoría.Name = "Tsmi_CambiarNombreCategoríaSinCategoría"
        Me.Tsmi_CambiarNombreCategoríaSinCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CambiarNombreCategoríaSinCategoría.Tag = "252"
        Me.Tsmi_CambiarNombreCategoríaSinCategoría.Text = "Cambiar Nombre"
        '
        'Tsmi_StockXArbol_Categoria2
        '
        Me.Tsmi_StockXArbol_Categoria2.Name = "Tsmi_StockXArbol_Categoria2"
        Me.Tsmi_StockXArbol_Categoria2.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_StockXArbol_Categoria2.Tag = "646"
        Me.Tsmi_StockXArbol_Categoria2.Text = "Exportar Stock por Cód. Árbol"
        '
        'Cms_Grupo
        '
        Me.Cms_Grupo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_CrearClase, Me.Tsmi_EliminarGrupo, Me.Tsmi_CambiarNombreGrupo, Me.Tsmi_StockXArbol_Grupo})
        Me.Cms_Grupo.Name = "Cms_Grupo"
        Me.Cms_Grupo.Size = New System.Drawing.Size(232, 92)
        Me.Cms_Grupo.Tag = "248"
        '
        'Tsmi_CrearClase
        '
        Me.Tsmi_CrearClase.Name = "Tsmi_CrearClase"
        Me.Tsmi_CrearClase.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CrearClase.Tag = "248"
        Me.Tsmi_CrearClase.Text = "Crear Clase"
        '
        'Tsmi_EliminarGrupo
        '
        Me.Tsmi_EliminarGrupo.Name = "Tsmi_EliminarGrupo"
        Me.Tsmi_EliminarGrupo.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_EliminarGrupo.Tag = "248"
        Me.Tsmi_EliminarGrupo.Text = "Eliminar Grupo"
        '
        'Tsmi_CambiarNombreGrupo
        '
        Me.Tsmi_CambiarNombreGrupo.Name = "Tsmi_CambiarNombreGrupo"
        Me.Tsmi_CambiarNombreGrupo.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CambiarNombreGrupo.Tag = "248"
        Me.Tsmi_CambiarNombreGrupo.Text = "Cambiar Nombre"
        '
        'Tsmi_StockXArbol_Grupo
        '
        Me.Tsmi_StockXArbol_Grupo.Name = "Tsmi_StockXArbol_Grupo"
        Me.Tsmi_StockXArbol_Grupo.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_StockXArbol_Grupo.Tag = "646"
        Me.Tsmi_StockXArbol_Grupo.Text = "Exportar Stock por Cód. Árbol"
        '
        'Cms_Familia
        '
        Me.Cms_Familia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_CrearGrupo, Me.Tsmi_EliminarFamilia, Me.Tsmi_CambiarNombreFamilia, Me.Tsmi_StockXArbol_Familia})
        Me.Cms_Familia.Name = "Cmd_Familia"
        Me.Cms_Familia.Size = New System.Drawing.Size(232, 92)
        Me.Cms_Familia.Tag = "247"
        '
        'Tsmi_CrearGrupo
        '
        Me.Tsmi_CrearGrupo.Name = "Tsmi_CrearGrupo"
        Me.Tsmi_CrearGrupo.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CrearGrupo.Tag = "247"
        Me.Tsmi_CrearGrupo.Text = "Crear Grupo"
        '
        'Tsmi_EliminarFamilia
        '
        Me.Tsmi_EliminarFamilia.Name = "Tsmi_EliminarFamilia"
        Me.Tsmi_EliminarFamilia.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_EliminarFamilia.Tag = "247"
        Me.Tsmi_EliminarFamilia.Text = "Eliminar Familia"
        '
        'Tsmi_CambiarNombreFamilia
        '
        Me.Tsmi_CambiarNombreFamilia.Name = "Tsmi_CambiarNombreFamilia"
        Me.Tsmi_CambiarNombreFamilia.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CambiarNombreFamilia.Tag = "247"
        Me.Tsmi_CambiarNombreFamilia.Text = "Cambiar Nombre"
        '
        'Tsmi_StockXArbol_Familia
        '
        Me.Tsmi_StockXArbol_Familia.Name = "Tsmi_StockXArbol_Familia"
        Me.Tsmi_StockXArbol_Familia.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_StockXArbol_Familia.Tag = "646"
        Me.Tsmi_StockXArbol_Familia.Text = "Exportar Stock por Cód. Árbol"
        '
        'Cms_SubClaseSinCategoría
        '
        Me.Cms_SubClaseSinCategoría.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_EliminarSubClaseSinCategoría, Me.Tsmi_CambiarNombreSubClaseSinCategoría, Me.Tsmi_StockXArbol_SubClase2})
        Me.Cms_SubClaseSinCategoría.Name = "Cms_Clase"
        Me.Cms_SubClaseSinCategoría.Size = New System.Drawing.Size(232, 70)
        Me.Cms_SubClaseSinCategoría.Tag = "250"
        '
        'Tsmi_EliminarSubClaseSinCategoría
        '
        Me.Tsmi_EliminarSubClaseSinCategoría.Name = "Tsmi_EliminarSubClaseSinCategoría"
        Me.Tsmi_EliminarSubClaseSinCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_EliminarSubClaseSinCategoría.Tag = "250"
        Me.Tsmi_EliminarSubClaseSinCategoría.Text = "Eliminar SubClase"
        '
        'Tsmi_CambiarNombreSubClaseSinCategoría
        '
        Me.Tsmi_CambiarNombreSubClaseSinCategoría.Name = "Tsmi_CambiarNombreSubClaseSinCategoría"
        Me.Tsmi_CambiarNombreSubClaseSinCategoría.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CambiarNombreSubClaseSinCategoría.Tag = "250"
        Me.Tsmi_CambiarNombreSubClaseSinCategoría.Text = "Cambiar Nombre"
        '
        'Tsmi_StockXArbol_SubClase2
        '
        Me.Tsmi_StockXArbol_SubClase2.Name = "Tsmi_StockXArbol_SubClase2"
        Me.Tsmi_StockXArbol_SubClase2.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_StockXArbol_SubClase2.Tag = "646"
        Me.Tsmi_StockXArbol_SubClase2.Text = "Exportar Stock por Cód. Árbol"
        '
        'Cms_Clase
        '
        Me.Cms_Clase.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_CrearSubclase, Me.Tsmi_EliminarClase, Me.Tsmi_CambiarNombreClase, Me.Tsmi_StockXArbol_Clase})
        Me.Cms_Clase.Name = "Cms_Clase"
        Me.Cms_Clase.Size = New System.Drawing.Size(232, 92)
        Me.Cms_Clase.Tag = "249"
        '
        'Tsmi_CrearSubclase
        '
        Me.Tsmi_CrearSubclase.Name = "Tsmi_CrearSubclase"
        Me.Tsmi_CrearSubclase.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CrearSubclase.Tag = "249"
        Me.Tsmi_CrearSubclase.Text = "Crear Subclase"
        '
        'Tsmi_EliminarClase
        '
        Me.Tsmi_EliminarClase.Name = "Tsmi_EliminarClase"
        Me.Tsmi_EliminarClase.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_EliminarClase.Tag = "249"
        Me.Tsmi_EliminarClase.Text = "Eliminar Clase"
        '
        'Tsmi_CambiarNombreClase
        '
        Me.Tsmi_CambiarNombreClase.Name = "Tsmi_CambiarNombreClase"
        Me.Tsmi_CambiarNombreClase.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_CambiarNombreClase.Tag = "249"
        Me.Tsmi_CambiarNombreClase.Text = "Cambiar Nombre"
        '
        'Tsmi_StockXArbol_Clase
        '
        Me.Tsmi_StockXArbol_Clase.Name = "Tsmi_StockXArbol_Clase"
        Me.Tsmi_StockXArbol_Clase.Size = New System.Drawing.Size(231, 22)
        Me.Tsmi_StockXArbol_Clase.Tag = "646"
        Me.Tsmi_StockXArbol_Clase.Text = "Exportar Stock por Cód. Árbol"
        '
        'Sc_Articulos
        '
        Me.Sc_Articulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sc_Articulos.Location = New System.Drawing.Point(300, 0)
        Me.Sc_Articulos.Name = "Sc_Articulos"
        Me.Sc_Articulos.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Sc_Articulos.Panel1
        '
        Me.Sc_Articulos.Panel1.Controls.Add(Me.Sc_Listado)
        '
        'Sc_Articulos.Panel2
        '
        Me.Sc_Articulos.Panel2.Controls.Add(Me.Sc_Detalle)
        Me.Sc_Articulos.Size = New System.Drawing.Size(700, 640)
        Me.Sc_Articulos.SplitterDistance = 500
        Me.Sc_Articulos.TabIndex = 15
        '
        'Nbc_Articulos
        '
        Me.Nbc_Articulos.ActiveGroup = Me.Nbg_Articulo
        Me.Nbc_Articulos.Controls.Add(Me.Nbgcc_Arbol)
        Me.Nbc_Articulos.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_Articulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Articulos.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_Arbol, Me.Nbg_Articulo})
        Me.Nbc_Articulos.GroupsFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Articulos.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_Articulos.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_Articulos.Location = New System.Drawing.Point(0, 0)
        Me.Nbc_Articulos.Name = "Nbc_Articulos"
        Me.Nbc_Articulos.ShowOverflowPanel = False
        Me.Nbc_Articulos.Size = New System.Drawing.Size(300, 640)
        Me.Nbc_Articulos.TabIndex = 16
        Me.Nbc_Articulos.Tag = ""
        Me.Nbc_Articulos.Text = "NetBarControl1"
        '
        'Nbg_Articulo
        '
        Me.Nbg_Articulo.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_BuscarArticulo, Me.Nbi_ImprimirSticker, Me.Nbi_EditarTipos, Me.Nbi_VerInventario, Me.Nbi_FijarCaracteristicaArticulo, Me.Nbi_TrazabilidadArticulo, Me.Nbi_TrazabilidadArticuloTotal, Me.Nbi_DistribucionArticuloxCant})
        Me.Nbg_Articulo.Name = "Nbg_Articulo"
        Me.Nbg_Articulo.Text = "Artículo"
        '
        'Nbi_BuscarArticulo
        '
        Me.Nbi_BuscarArticulo.Name = "Nbi_BuscarArticulo"
        Me.Nbi_BuscarArticulo.Tag = "348"
        Me.Nbi_BuscarArticulo.Text = "Buscar Artículo"
        '
        'Nbi_ImprimirSticker
        '
        Me.Nbi_ImprimirSticker.Name = "Nbi_ImprimirSticker"
        Me.Nbi_ImprimirSticker.Tag = "349"
        Me.Nbi_ImprimirSticker.Text = "Imprimir Sticker"
        '
        'Nbi_EditarTipos
        '
        Me.Nbi_EditarTipos.Name = "Nbi_EditarTipos"
        Me.Nbi_EditarTipos.Tag = "349"
        Me.Nbi_EditarTipos.Text = "Editar Tipos/subtipos"
        '
        'Nbi_VerInventario
        '
        Me.Nbi_VerInventario.Name = "Nbi_VerInventario"
        Me.Nbi_VerInventario.Tag = "349"
        Me.Nbi_VerInventario.Text = "Ver Inventario"
        '
        'Nbi_FijarCaracteristicaArticulo
        '
        Me.Nbi_FijarCaracteristicaArticulo.Name = "Nbi_FijarCaracteristicaArticulo"
        Me.Nbi_FijarCaracteristicaArticulo.Tag = "349"
        Me.Nbi_FijarCaracteristicaArticulo.Text = "Ubicación y Stock"
        '
        'Nbi_TrazabilidadArticulo
        '
        Me.Nbi_TrazabilidadArticulo.Name = "Nbi_TrazabilidadArticulo"
        Me.Nbi_TrazabilidadArticulo.Tag = "349"
        Me.Nbi_TrazabilidadArticulo.Text = "Trazabilidad x Base"
        '
        'Nbi_TrazabilidadArticuloTotal
        '
        Me.Nbi_TrazabilidadArticuloTotal.Name = "Nbi_TrazabilidadArticuloTotal"
        Me.Nbi_TrazabilidadArticuloTotal.Tag = "349"
        Me.Nbi_TrazabilidadArticuloTotal.Text = "Trazabilidad"
        '
        'Nbi_DistribucionArticuloxCant
        '
        Me.Nbi_DistribucionArticuloxCant.Name = "Nbi_DistribucionArticuloxCant"
        Me.Nbi_DistribucionArticuloxCant.Text = "Distribución Artículo x Cantidad"
        '
        'Nbgcc_Arbol
        '
        Me.Nbgcc_Arbol.Controls.Add(Me.Tv_Grupos)
        Me.Nbgcc_Arbol.Controls.Add(Me.Lb_TituloArbol)
        Me.Nbgcc_Arbol.Name = "Nbgcc_Arbol"
        Me.Nbgcc_Arbol.Size = New System.Drawing.Size(291, 541)
        Me.Nbgcc_Arbol.TabIndex = 2
        '
        'Nbg_Arbol
        '
        Me.Nbg_Arbol.ControlContainer = Me.Nbgcc_Arbol
        Me.Nbg_Arbol.Name = "Nbg_Arbol"
        Me.Nbg_Arbol.Style = NetBarControl.NetBarGroupStyle.ControlContainer
        Me.Nbg_Arbol.Text = "Árbol de artículos"
        '
        'Im_Defecto
        '
        Me.Im_Defecto.ImageStream = CType(resources.GetObject("Im_Defecto.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Im_Defecto.TransparentColor = System.Drawing.Color.Transparent
        Me.Im_Defecto.Images.SetKeyName(0, "images.png")
        '
        'Cu_Articulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Sc_Articulos)
        Me.Controls.Add(Me.Nbc_Articulos)
        Me.Name = "Cu_Articulos"
        Me.Size = New System.Drawing.Size(1000, 640)
        Me.Sc_Listado.Panel1.ResumeLayout(False)
        Me.Sc_Listado.Panel1.PerformLayout()
        Me.Sc_Listado.Panel2.ResumeLayout(False)
        CType(Me.Sc_Listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_Listado.ResumeLayout(False)
        CType(Me.Dgv_Articulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_Artículos.ResumeLayout(False)
        Me.Pn_Bt_Opciones.ResumeLayout(False)
        Me.Pn_Bt_Opciones.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Pb_FotoArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_Detalle.Panel1.ResumeLayout(False)
        Me.Sc_Detalle.Panel2.ResumeLayout(False)
        CType(Me.Sc_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_Detalle.ResumeLayout(False)
        CType(Me.Dgv_TablaDisponibilidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_TablaProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_SubClase.ResumeLayout(False)
        Me.Cms_TipoCategoría.ResumeLayout(False)
        Me.Cms_Categoría.ResumeLayout(False)
        Me.Cms_CategoríaSinCategoria.ResumeLayout(False)
        Me.Cms_Grupo.ResumeLayout(False)
        Me.Cms_Familia.ResumeLayout(False)
        Me.Cms_SubClaseSinCategoría.ResumeLayout(False)
        Me.Cms_Clase.ResumeLayout(False)
        Me.Sc_Articulos.Panel1.ResumeLayout(False)
        Me.Sc_Articulos.Panel2.ResumeLayout(False)
        CType(Me.Sc_Articulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_Articulos.ResumeLayout(False)
        Me.Nbc_Articulos.ResumeLayout(False)
        Me.Nbgcc_Arbol.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv_Articulos As System.Windows.Forms.DataGridView
    Friend WithEvents Tv_Grupos As System.Windows.Forms.TreeView

    Friend WithEvents Cms_SubClase As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_CrearTipoCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Il_Materiales As System.Windows.Forms.ImageList
    Friend WithEvents Cms_TipoCategoría As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_CrearCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_ModificarTipoCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cms_Categoría As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_CrearTipoCategoríaStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_CrearArtículo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_ModificarCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cms_CategoríaSinCategoria As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_ModificarCategoria2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_CrearArtículo2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cms_Grupo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_CrearClase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cms_Familia As System.Windows.Forms.ContextMenuStrip

    Friend WithEvents Tsmi_CrearGrupo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lb_TituloArbol As System.Windows.Forms.Label
    Friend WithEvents Tsmi_EliminarGrupo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_EliminarFamilia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_EliminarSubClase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cms_SubClaseSinCategoría As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_EliminarSubClaseSinCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_EliminarTipoCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_EliminarCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_EliminarCategoríaSinCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cms_Artículos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificarArtículoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarArtículoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_CambiarNombreFamilia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_CambiarNombreGrupo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_CambiarNombreSubClase As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents Tsmi_CambiarNombreSubClaseSinCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_CambiarNombreTipoCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_CambiarNombreCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_CambiarNombreCategoríaSinCategoría As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cms_Clase As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_CrearSubclase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_EliminarClase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_CambiarNombreClase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sc_Detalle As System.Windows.Forms.SplitContainer

    'Friend WithEvents Cu_DisponibilidaArticulo1 As Articulos.Cu_DisponibilidaArticulo
    Friend WithEvents Ck_MostrarDisponibilidad As System.Windows.Forms.CheckBox
    ' Friend WithEvents Cu_ProveedoresArticulos1 As Articulos.Cu_ProveedoresArticulos
    Friend WithEvents Ck_ProveedoresArticulo As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox


    Friend WithEvents Sc_Listado As System.Windows.Forms.SplitContainer
    Friend WithEvents Lb_Propiedades As System.Windows.Forms.Label
    Friend WithEvents Pg_DetalleLista As System.Windows.Forms.PropertyGrid

    Friend WithEvents Dgv_TablaDisponibilidad As Windows.Forms.DataGridView
    Friend WithEvents Lb_TituloDisponibilidad As Windows.Forms.Label
    Friend WithEvents Lb_TituloProveedor As Windows.Forms.Label
    Friend WithEvents Dgv_TablaProveedores As Windows.Forms.DataGridView
    Friend WithEvents SacarDeControlToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarControlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_StockXArbol_SubClase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_StockXArbol_Clase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_StockXArbol_Familia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_StockXArbol_Grupo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_StockXArbol_TipoCategoria As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_StockXArbol_Categoria As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_StockXArbol_Categoria2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_StockXArbol_SubClase2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lb_TituloListado As System.Windows.Forms.Label
    Friend WithEvents Sc_Articulos As System.Windows.Forms.SplitContainer
    Friend WithEvents Nbc_Articulos As NetBarControl.NetBarControl
    Friend WithEvents Nbg_Arbol As NetBarControl.NetBarGroup
    Friend WithEvents Nbgcc_Arbol As NetBarControl.NetBarGroupControlContainer
    Friend WithEvents Nbg_Articulo As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_BuscarArticulo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirSticker As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarTipos As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerInventario As NetBarControl.NetBarItem
    Friend WithEvents Nbi_FijarCaracteristicaArticulo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_TrazabilidadArticulo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_TrazabilidadArticuloTotal As NetBarControl.NetBarItem
    Friend WithEvents Pn_Bt_Opciones As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBt_BuscarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBt_ImprimirSticker As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBt_EditarTS As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBt_VerInventarios As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBt_UyStock As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBt_TrazabilidadxBase As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBt_Trazabilidad As System.Windows.Forms.ToolStripButton
    Friend WithEvents Nbi_DistribucionArticuloxCant As NetBarControl.NetBarItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Pb_FotoArticulo As System.Windows.Forms.PictureBox
    Friend WithEvents Ck_MostrarFotoArticulo As System.Windows.Forms.CheckBox
    Friend WithEvents Im_Defecto As System.Windows.Forms.ImageList
End Class
