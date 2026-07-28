<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Bodega
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
        Me.Nbc_Bodega = New NetBarControl.NetBarControl()
        Me.Nbg_EntradaAlmacen = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarEntradasAlmacen = New NetBarControl.NetBarItem()
        Me.Nbi_CrearEA = New NetBarControl.NetBarItem()
        Me.Nbi_VerEA = New NetBarControl.NetBarItem()
        Me.Nbi_EditarEA = New NetBarControl.NetBarItem()
        Me.Nbi_CancelarEA = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirEntradaAlmacen = New NetBarControl.NetBarItem()
        Me.Nbi_HabilitarImpresionEntrada = New NetBarControl.NetBarItem()
        Me.Nbi_DevolucionProveedor = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarEntrada = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarEntradaPorArticulo = New NetBarControl.NetBarItem()
        Me.Nbi_SubirEntradaAlmacen = New NetBarControl.NetBarItem()
        Me.Nbi_VerPdfEntradaAlmacen = New NetBarControl.NetBarItem()
        Me.Nbi_SubirPdfBloqueEA = New NetBarControl.NetBarItem()
        Me.Nbi_HistorialArchivosPdfEA = New NetBarControl.NetBarItem()
        Me.Nbi_ImpSticker = New NetBarControl.NetBarItem()
        Me.NetBarGroupControlContainer3 = New NetBarControl.NetBarGroupControlContainer()
        Me.Bt_FiltrarLista = New System.Windows.Forms.Button()
        Me.Ck_Filtro3 = New System.Windows.Forms.CheckBox()
        Me.Tx_ValorFiltro3 = New System.Windows.Forms.TextBox()
        Me.Cb_FiltrarPor3 = New System.Windows.Forms.ComboBox()
        Me.Ck_Filtro2 = New System.Windows.Forms.CheckBox()
        Me.Tx_ValorFiltro2 = New System.Windows.Forms.TextBox()
        Me.Cb_FiltrarPor2 = New System.Windows.Forms.ComboBox()
        Me.Ck_Filtro1 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tx_ValorFiltro1 = New System.Windows.Forms.TextBox()
        Me.Cb_FiltrarPor1 = New System.Windows.Forms.ComboBox()
        Me.Lb_Filtro = New System.Windows.Forms.Label()
        Me.Nbg_SalidaAlmacen = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarSalidaAlmacen = New NetBarControl.NetBarItem()
        Me.Nbi_CrearSA = New NetBarControl.NetBarItem()
        Me.Nbi_VerSA = New NetBarControl.NetBarItem()
        Me.Nbi_EditarSA = New NetBarControl.NetBarItem()
        Me.Nbi_CancelarSA = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirSalidaAlmacen = New NetBarControl.NetBarItem()
        Me.Nbi_HabilitarImpresion = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarSalidaAlmacen = New NetBarControl.NetBarItem()
        Me.Nbi_RegistrarDatosTransportador = New NetBarControl.NetBarItem()
        Me.Nbi_SalidasDotación = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarSalidaPorArticulo = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarCustodias = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarCustodiaH = New NetBarControl.NetBarItem()
        Me.Nbi_SubirSalida = New NetBarControl.NetBarItem()
        Me.Nbi_VerSalidaAlmacenPDF = New NetBarControl.NetBarItem()
        Me.Nbi_SubirPdfBloqueSA = New NetBarControl.NetBarItem()
        Me.Nbi_HistorialArchivosPdfSA = New NetBarControl.NetBarItem()
        Me.Nbi_EnviarCorreoPenSATC = New NetBarControl.NetBarItem()
        Me.Nbi_TrasCustodia = New NetBarControl.NetBarItem()
        Me.Nbg_Traslados = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarNoFinEnviaTB = New NetBarControl.NetBarItem()
        Me.Nbi_CargarNoFinDestTB = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarRemision = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirRemisión = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirRemisiónValorizada = New NetBarControl.NetBarItem()
        Me.Nbi_EnviarCorreosSAPendientesXEA = New NetBarControl.NetBarItem()
        Me.Nbg_Bodega = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarBodegas = New NetBarControl.NetBarItem()
        Me.Nbi_CrearBodega = New NetBarControl.NetBarItem()
        Me.Nbi_VerBodega = New NetBarControl.NetBarItem()
        Me.Nbi_ModificarBodega = New NetBarControl.NetBarItem()
        Me.Nbi_ActivarBodega = New NetBarControl.NetBarItem()
        Me.Nbi_DesactivarBodega = New NetBarControl.NetBarItem()
        Me.Nbi_CambiarBodega = New NetBarControl.NetBarItem()
        Me.Nbi_AsociarUsuarioBodega = New NetBarControl.NetBarItem()
        Me.Nbg_Filtro = New NetBarControl.NetBarGroup()
        Me.Pn_ContenedorPrincipal = New System.Windows.Forms.Panel()
        Me.Pn_ContenedorItems = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Pn_ItemsEA_SA = New System.Windows.Forms.Panel()
        Me.DGV_ListaItem = New System.Windows.Forms.DataGridView()
        Me.Cms_CancelarItem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CancelarItemEAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevoluciónAProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltrarEquiposXCódigoArticuloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pn_ContenedorTitulointegrantes = New System.Windows.Forms.Panel()
        Me.Lb_MovimientoDos = New System.Windows.Forms.Label()
        Me.Pn_equiposasociados = New System.Windows.Forms.Panel()
        Me.DGV_Equipos = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DGV_Lista = New System.Windows.Forms.DataGridView()
        Me.Cms_Ordenar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OrdenarPorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pn_Contenedortitulocuadrillas = New System.Windows.Forms.Panel()
        Me.Lb_Movimiento = New System.Windows.Forms.Label()
        Me.Pg_DetalleLista = New System.Windows.Forms.PropertyGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pn_tituloformulario = New System.Windows.Forms.Panel()
        Me.Lb_Cargado = New System.Windows.Forms.Label()
        Me.NetBarGroupControlContainer1 = New NetBarControl.NetBarGroupControlContainer()
        Me.NetBarGroupControlContainer2 = New NetBarControl.NetBarGroupControlContainer()
        Me.Cms_BodegasInactivas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_VerBodega = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_ActivarBodega = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nbc_Bodega.SuspendLayout()
        Me.NetBarGroupControlContainer3.SuspendLayout()
        Me.Pn_ContenedorPrincipal.SuspendLayout()
        Me.Pn_ContenedorItems.SuspendLayout()
        Me.Pn_ItemsEA_SA.SuspendLayout()
        CType(Me.DGV_ListaItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_CancelarItem.SuspendLayout()
        Me.Pn_ContenedorTitulointegrantes.SuspendLayout()
        Me.Pn_equiposasociados.SuspendLayout()
        CType(Me.DGV_Equipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DGV_Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_Ordenar.SuspendLayout()
        Me.Pn_Contenedortitulocuadrillas.SuspendLayout()
        Me.Pn_tituloformulario.SuspendLayout()
        Me.Cms_BodegasInactivas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Nbc_Bodega
        '
        Me.Nbc_Bodega.ActiveGroup = Me.Nbg_SalidaAlmacen
        Me.Nbc_Bodega.Controls.Add(Me.NetBarGroupControlContainer3)
        Me.Nbc_Bodega.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_Bodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Bodega.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_SalidaAlmacen, Me.Nbg_EntradaAlmacen, Me.Nbg_Traslados, Me.Nbg_Bodega, Me.Nbg_Filtro})
        Me.Nbc_Bodega.GroupsFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Bodega.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_Bodega.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_Bodega.Location = New System.Drawing.Point(0, 0)
        Me.Nbc_Bodega.Name = "Nbc_Bodega"
        Me.Nbc_Bodega.ShowOverflowPanel = False
        Me.Nbc_Bodega.Size = New System.Drawing.Size(202, 527)
        Me.Nbc_Bodega.TabIndex = 13
        Me.Nbc_Bodega.Tag = "294"
        Me.Nbc_Bodega.Text = "NetBarControl1"
        '
        'Nbg_EntradaAlmacen
        '
        Me.Nbg_EntradaAlmacen.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarEntradasAlmacen, Me.Nbi_CrearEA, Me.Nbi_VerEA, Me.Nbi_EditarEA, Me.Nbi_CancelarEA, Me.Nbi_ImprimirEntradaAlmacen, Me.Nbi_HabilitarImpresionEntrada, Me.Nbi_DevolucionProveedor, Me.Nbi_BuscarEntrada, Me.Nbi_BuscarEntradaPorArticulo, Me.Nbi_SubirEntradaAlmacen, Me.Nbi_VerPdfEntradaAlmacen, Me.Nbi_SubirPdfBloqueEA, Me.Nbi_HistorialArchivosPdfEA, Me.Nbi_ImpSticker})
        Me.Nbg_EntradaAlmacen.Name = "Nbg_EntradaAlmacen"
        Me.Nbg_EntradaAlmacen.Tag = "296"
        Me.Nbg_EntradaAlmacen.Text = "Entrada Almacén"
        '
        'Nbi_CargarEntradasAlmacen
        '
        Me.Nbi_CargarEntradasAlmacen.Name = "Nbi_CargarEntradasAlmacen"
        Me.Nbi_CargarEntradasAlmacen.Tag = "307"
        Me.Nbi_CargarEntradasAlmacen.Text = "Cargar Entradas Almacén"
        '
        'Nbi_CrearEA
        '
        Me.Nbi_CrearEA.Name = "Nbi_CrearEA"
        Me.Nbi_CrearEA.Tag = "308"
        Me.Nbi_CrearEA.Text = "Crear Entrada Almacén"
        '
        'Nbi_VerEA
        '
        Me.Nbi_VerEA.Name = "Nbi_VerEA"
        Me.Nbi_VerEA.Text = "Ver Entrada de Almacén"
        '
        'Nbi_EditarEA
        '
        Me.Nbi_EditarEA.Name = "Nbi_EditarEA"
        Me.Nbi_EditarEA.Tag = "309"
        Me.Nbi_EditarEA.Text = "Editar Entrada Almacén"
        '
        'Nbi_CancelarEA
        '
        Me.Nbi_CancelarEA.Name = "Nbi_CancelarEA"
        Me.Nbi_CancelarEA.Tag = "310"
        Me.Nbi_CancelarEA.Text = "Cancelar Entrada Almacén"
        '
        'Nbi_ImprimirEntradaAlmacen
        '
        Me.Nbi_ImprimirEntradaAlmacen.Name = "Nbi_ImprimirEntradaAlmacen"
        Me.Nbi_ImprimirEntradaAlmacen.Tag = "311"
        Me.Nbi_ImprimirEntradaAlmacen.Text = "Imprimir Entrada Almacen"
        '
        'Nbi_HabilitarImpresionEntrada
        '
        Me.Nbi_HabilitarImpresionEntrada.Name = "Nbi_HabilitarImpresionEntrada"
        Me.Nbi_HabilitarImpresionEntrada.Tag = "409"
        Me.Nbi_HabilitarImpresionEntrada.Text = "Habilitar Impresión"
        '
        'Nbi_DevolucionProveedor
        '
        Me.Nbi_DevolucionProveedor.Name = "Nbi_DevolucionProveedor"
        Me.Nbi_DevolucionProveedor.Tag = "410"
        Me.Nbi_DevolucionProveedor.Text = "Devolución a Proveedor"
        '
        'Nbi_BuscarEntrada
        '
        Me.Nbi_BuscarEntrada.Name = "Nbi_BuscarEntrada"
        Me.Nbi_BuscarEntrada.Text = "Buscar Entrada de Almacen"
        '
        'Nbi_BuscarEntradaPorArticulo
        '
        Me.Nbi_BuscarEntradaPorArticulo.Name = "Nbi_BuscarEntradaPorArticulo"
        Me.Nbi_BuscarEntradaPorArticulo.Tag = "553"
        Me.Nbi_BuscarEntradaPorArticulo.Text = "Buscar Entrada por Artículo"
        '
        'Nbi_SubirEntradaAlmacen
        '
        Me.Nbi_SubirEntradaAlmacen.Name = "Nbi_SubirEntradaAlmacen"
        Me.Nbi_SubirEntradaAlmacen.Tag = "949"
        Me.Nbi_SubirEntradaAlmacen.Text = "Subir PDF Entrada Almacén"
        '
        'Nbi_VerPdfEntradaAlmacen
        '
        Me.Nbi_VerPdfEntradaAlmacen.Name = "Nbi_VerPdfEntradaAlmacen"
        Me.Nbi_VerPdfEntradaAlmacen.Tag = "950"
        Me.Nbi_VerPdfEntradaAlmacen.Text = "Ver PDF Entrada Almacén"
        '
        'Nbi_SubirPdfBloqueEA
        '
        Me.Nbi_SubirPdfBloqueEA.Name = "Nbi_SubirPdfBloqueEA"
        Me.Nbi_SubirPdfBloqueEA.Tag = "987"
        Me.Nbi_SubirPdfBloqueEA.Text = "Subir PDFs EA En Bloque"
        '
        'Nbi_HistorialArchivosPdfEA
        '
        Me.Nbi_HistorialArchivosPdfEA.Name = "Nbi_HistorialArchivosPdfEA"
        Me.Nbi_HistorialArchivosPdfEA.Tag = "428"
        Me.Nbi_HistorialArchivosPdfEA.Text = "Historial Archivos EA"
        '
        'Nbi_ImpSticker
        '
        Me.Nbi_ImpSticker.Name = "Nbi_ImpSticker"
        Me.Nbi_ImpSticker.Tag = "349"
        Me.Nbi_ImpSticker.Text = "Imprimir Sticker's"
        '
        'NetBarGroupControlContainer3
        '
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Bt_FiltrarLista)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Ck_Filtro3)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Tx_ValorFiltro3)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Cb_FiltrarPor3)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Ck_Filtro2)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Tx_ValorFiltro2)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Cb_FiltrarPor2)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Ck_Filtro1)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Label3)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Tx_ValorFiltro1)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Cb_FiltrarPor1)
        Me.NetBarGroupControlContainer3.Controls.Add(Me.Lb_Filtro)
        Me.NetBarGroupControlContainer3.Name = "NetBarGroupControlContainer3"
        Me.NetBarGroupControlContainer3.Size = New System.Drawing.Size(193, 338)
        Me.NetBarGroupControlContainer3.TabIndex = 21
        '
        'Bt_FiltrarLista
        '
        Me.Bt_FiltrarLista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_FiltrarLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_FiltrarLista.Location = New System.Drawing.Point(121, 205)
        Me.Bt_FiltrarLista.Name = "Bt_FiltrarLista"
        Me.Bt_FiltrarLista.Size = New System.Drawing.Size(69, 23)
        Me.Bt_FiltrarLista.TabIndex = 13
        Me.Bt_FiltrarLista.Text = "Filtrar Lista"
        Me.Bt_FiltrarLista.UseVisualStyleBackColor = True
        '
        'Ck_Filtro3
        '
        Me.Ck_Filtro3.AutoSize = True
        Me.Ck_Filtro3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ck_Filtro3.Location = New System.Drawing.Point(3, 156)
        Me.Ck_Filtro3.Name = "Ck_Filtro3"
        Me.Ck_Filtro3.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtro3.TabIndex = 11
        Me.Ck_Filtro3.UseVisualStyleBackColor = True
        '
        'Tx_ValorFiltro3
        '
        Me.Tx_ValorFiltro3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_ValorFiltro3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_ValorFiltro3.Location = New System.Drawing.Point(24, 179)
        Me.Tx_ValorFiltro3.MaxLength = 50
        Me.Tx_ValorFiltro3.Name = "Tx_ValorFiltro3"
        Me.Tx_ValorFiltro3.Size = New System.Drawing.Size(166, 20)
        Me.Tx_ValorFiltro3.TabIndex = 10
        '
        'Cb_FiltrarPor3
        '
        Me.Cb_FiltrarPor3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_FiltrarPor3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_FiltrarPor3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_FiltrarPor3.FormattingEnabled = True
        Me.Cb_FiltrarPor3.Location = New System.Drawing.Point(24, 151)
        Me.Cb_FiltrarPor3.Name = "Cb_FiltrarPor3"
        Me.Cb_FiltrarPor3.Size = New System.Drawing.Size(166, 21)
        Me.Cb_FiltrarPor3.TabIndex = 9
        '
        'Ck_Filtro2
        '
        Me.Ck_Filtro2.AutoSize = True
        Me.Ck_Filtro2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ck_Filtro2.Location = New System.Drawing.Point(3, 103)
        Me.Ck_Filtro2.Name = "Ck_Filtro2"
        Me.Ck_Filtro2.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtro2.TabIndex = 8
        Me.Ck_Filtro2.UseVisualStyleBackColor = True
        '
        'Tx_ValorFiltro2
        '
        Me.Tx_ValorFiltro2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_ValorFiltro2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_ValorFiltro2.Location = New System.Drawing.Point(24, 126)
        Me.Tx_ValorFiltro2.MaxLength = 50
        Me.Tx_ValorFiltro2.Name = "Tx_ValorFiltro2"
        Me.Tx_ValorFiltro2.Size = New System.Drawing.Size(166, 20)
        Me.Tx_ValorFiltro2.TabIndex = 7
        '
        'Cb_FiltrarPor2
        '
        Me.Cb_FiltrarPor2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_FiltrarPor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_FiltrarPor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_FiltrarPor2.FormattingEnabled = True
        Me.Cb_FiltrarPor2.Location = New System.Drawing.Point(24, 98)
        Me.Cb_FiltrarPor2.Name = "Cb_FiltrarPor2"
        Me.Cb_FiltrarPor2.Size = New System.Drawing.Size(166, 21)
        Me.Cb_FiltrarPor2.TabIndex = 6
        '
        'Ck_Filtro1
        '
        Me.Ck_Filtro1.AutoSize = True
        Me.Ck_Filtro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ck_Filtro1.Location = New System.Drawing.Point(3, 49)
        Me.Ck_Filtro1.Name = "Ck_Filtro1"
        Me.Ck_Filtro1.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtro1.TabIndex = 5
        Me.Ck_Filtro1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Filtrar por:"
        '
        'Tx_ValorFiltro1
        '
        Me.Tx_ValorFiltro1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_ValorFiltro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_ValorFiltro1.Location = New System.Drawing.Point(24, 72)
        Me.Tx_ValorFiltro1.MaxLength = 50
        Me.Tx_ValorFiltro1.Name = "Tx_ValorFiltro1"
        Me.Tx_ValorFiltro1.Size = New System.Drawing.Size(166, 20)
        Me.Tx_ValorFiltro1.TabIndex = 2
        '
        'Cb_FiltrarPor1
        '
        Me.Cb_FiltrarPor1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_FiltrarPor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_FiltrarPor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_FiltrarPor1.FormattingEnabled = True
        Me.Cb_FiltrarPor1.Location = New System.Drawing.Point(24, 44)
        Me.Cb_FiltrarPor1.Name = "Cb_FiltrarPor1"
        Me.Cb_FiltrarPor1.Size = New System.Drawing.Size(166, 21)
        Me.Cb_FiltrarPor1.TabIndex = 1
        '
        'Lb_Filtro
        '
        Me.Lb_Filtro.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_Filtro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_Filtro.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Filtro.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Filtro.Name = "Lb_Filtro"
        Me.Lb_Filtro.Size = New System.Drawing.Size(193, 18)
        Me.Lb_Filtro.TabIndex = 0
        Me.Lb_Filtro.Text = "Label2"
        Me.Lb_Filtro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Nbg_SalidaAlmacen
        '
        Me.Nbg_SalidaAlmacen.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarSalidaAlmacen, Me.Nbi_CrearSA, Me.Nbi_VerSA, Me.Nbi_EditarSA, Me.Nbi_CancelarSA, Me.Nbi_ImprimirSalidaAlmacen, Me.Nbi_HabilitarImpresion, Me.Nbi_BuscarSalidaAlmacen, Me.Nbi_RegistrarDatosTransportador, Me.Nbi_SalidasDotación, Me.Nbi_BuscarSalidaPorArticulo, Me.Nbi_BuscarCustodias, Me.Nbi_BuscarCustodiaH, Me.Nbi_SubirSalida, Me.Nbi_VerSalidaAlmacenPDF, Me.Nbi_SubirPdfBloqueSA, Me.Nbi_HistorialArchivosPdfSA, Me.Nbi_EnviarCorreoPenSATC, Me.Nbi_TrasCustodia})
        Me.Nbg_SalidaAlmacen.Name = "Nbg_SalidaAlmacen"
        Me.Nbg_SalidaAlmacen.Tag = "295"
        Me.Nbg_SalidaAlmacen.Text = "Salida Almacén"
        '
        'Nbi_CargarSalidaAlmacen
        '
        Me.Nbi_CargarSalidaAlmacen.Name = "Nbi_CargarSalidaAlmacen"
        Me.Nbi_CargarSalidaAlmacen.Tag = "302"
        Me.Nbi_CargarSalidaAlmacen.Text = "Cargar Salida Almacén"
        '
        'Nbi_CrearSA
        '
        Me.Nbi_CrearSA.Name = "Nbi_CrearSA"
        Me.Nbi_CrearSA.Tag = "303"
        Me.Nbi_CrearSA.Text = "Crear Salida Almacén"
        '
        'Nbi_VerSA
        '
        Me.Nbi_VerSA.Name = "Nbi_VerSA"
        Me.Nbi_VerSA.Tag = "368"
        Me.Nbi_VerSA.Text = "Ver Salida Almacén"
        '
        'Nbi_EditarSA
        '
        Me.Nbi_EditarSA.Name = "Nbi_EditarSA"
        Me.Nbi_EditarSA.Tag = "304"
        Me.Nbi_EditarSA.Text = "Editar Salida Almacén"
        '
        'Nbi_CancelarSA
        '
        Me.Nbi_CancelarSA.Name = "Nbi_CancelarSA"
        Me.Nbi_CancelarSA.Tag = "305"
        Me.Nbi_CancelarSA.Text = "Cancelar Salida Almacén"
        '
        'Nbi_ImprimirSalidaAlmacen
        '
        Me.Nbi_ImprimirSalidaAlmacen.Name = "Nbi_ImprimirSalidaAlmacen"
        Me.Nbi_ImprimirSalidaAlmacen.Tag = "306"
        Me.Nbi_ImprimirSalidaAlmacen.Text = "Imprimir Salida Almacen"
        '
        'Nbi_HabilitarImpresion
        '
        Me.Nbi_HabilitarImpresion.Name = "Nbi_HabilitarImpresion"
        Me.Nbi_HabilitarImpresion.Tag = "407"
        Me.Nbi_HabilitarImpresion.Text = "Habilitar Impresión"
        '
        'Nbi_BuscarSalidaAlmacen
        '
        Me.Nbi_BuscarSalidaAlmacen.Name = "Nbi_BuscarSalidaAlmacen"
        Me.Nbi_BuscarSalidaAlmacen.Text = "Buscar Salida de Almacen"
        '
        'Nbi_RegistrarDatosTransportador
        '
        Me.Nbi_RegistrarDatosTransportador.Name = "Nbi_RegistrarDatosTransportador"
        Me.Nbi_RegistrarDatosTransportador.Tag = "551"
        Me.Nbi_RegistrarDatosTransportador.Text = "Registrar Datos Transportador"
        '
        'Nbi_SalidasDotación
        '
        Me.Nbi_SalidasDotación.Name = "Nbi_SalidasDotación"
        Me.Nbi_SalidasDotación.Tag = "323"
        Me.Nbi_SalidasDotación.Text = "Salidas Dotación x Persona"
        '
        'Nbi_BuscarSalidaPorArticulo
        '
        Me.Nbi_BuscarSalidaPorArticulo.Name = "Nbi_BuscarSalidaPorArticulo"
        Me.Nbi_BuscarSalidaPorArticulo.Tag = "412"
        Me.Nbi_BuscarSalidaPorArticulo.Text = "Buscar Salida por Artículo"
        '
        'Nbi_BuscarCustodias
        '
        Me.Nbi_BuscarCustodias.Name = "Nbi_BuscarCustodias"
        Me.Nbi_BuscarCustodias.Tag = "559"
        Me.Nbi_BuscarCustodias.Text = "Buscar Custodias"
        '
        'Nbi_BuscarCustodiaH
        '
        Me.Nbi_BuscarCustodiaH.Name = "Nbi_BuscarCustodiaH"
        Me.Nbi_BuscarCustodiaH.Tag = "879"
        Me.Nbi_BuscarCustodiaH.Text = "Buscar Custodia Htas x Persona"
        '
        'Nbi_SubirSalida
        '
        Me.Nbi_SubirSalida.Name = "Nbi_SubirSalida"
        Me.Nbi_SubirSalida.Tag = "947"
        Me.Nbi_SubirSalida.Text = "Subir PDF Salida Almacén"
        '
        'Nbi_VerSalidaAlmacenPDF
        '
        Me.Nbi_VerSalidaAlmacenPDF.Name = "Nbi_VerSalidaAlmacenPDF"
        Me.Nbi_VerSalidaAlmacenPDF.Tag = "948"
        Me.Nbi_VerSalidaAlmacenPDF.Text = "Ver PDF Salida Almacén"
        '
        'Nbi_SubirPdfBloqueSA
        '
        Me.Nbi_SubirPdfBloqueSA.Name = "Nbi_SubirPdfBloqueSA"
        Me.Nbi_SubirPdfBloqueSA.Tag = "986"
        Me.Nbi_SubirPdfBloqueSA.Text = "Subir PDFs SA En Bloque"
        '
        'Nbi_HistorialArchivosPdfSA
        '
        Me.Nbi_HistorialArchivosPdfSA.Name = "Nbi_HistorialArchivosPdfSA"
        Me.Nbi_HistorialArchivosPdfSA.Tag = "426"
        Me.Nbi_HistorialArchivosPdfSA.Text = "Historial Archivos SA"
        '
        'Nbi_EnviarCorreoPenSATC
        '
        Me.Nbi_EnviarCorreoPenSATC.Name = "Nbi_EnviarCorreoPenSATC"
        Me.Nbi_EnviarCorreoPenSATC.Tag = "1025"
        Me.Nbi_EnviarCorreoPenSATC.Text = "Enviar Correo Custodias pendientes PDF"
        '
        'Nbi_TrasCustodia
        '
        Me.Nbi_TrasCustodia.Name = "Nbi_TrasCustodia"
        Me.Nbi_TrasCustodia.Tag = "1029"
        Me.Nbi_TrasCustodia.Text = "Trasladar Custodias"
        '
        'Nbg_Traslados
        '
        Me.Nbg_Traslados.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarNoFinEnviaTB, Me.Nbi_CargarNoFinDestTB, Me.Nbi_BuscarRemision, Me.Nbi_ImprimirRemisión, Me.Nbi_ImprimirRemisiónValorizada, Me.Nbi_EnviarCorreosSAPendientesXEA})
        Me.Nbg_Traslados.Name = "Nbg_Traslados"
        Me.Nbg_Traslados.Tag = "297"
        Me.Nbg_Traslados.Text = "Traslados Bodega"
        '
        'Nbi_CargarNoFinEnviaTB
        '
        Me.Nbi_CargarNoFinEnviaTB.Name = "Nbi_CargarNoFinEnviaTB"
        Me.Nbi_CargarNoFinEnviaTB.Tag = "312"
        Me.Nbi_CargarNoFinEnviaTB.Text = "Sin confirmar en el destino"
        '
        'Nbi_CargarNoFinDestTB
        '
        Me.Nbi_CargarNoFinDestTB.Name = "Nbi_CargarNoFinDestTB"
        Me.Nbi_CargarNoFinDestTB.Tag = "313"
        Me.Nbi_CargarNoFinDestTB.Text = "Sin ingreso Bodega Actual"
        '
        'Nbi_BuscarRemision
        '
        Me.Nbi_BuscarRemision.Name = "Nbi_BuscarRemision"
        Me.Nbi_BuscarRemision.Text = "Buscar Remisión"
        '
        'Nbi_ImprimirRemisión
        '
        Me.Nbi_ImprimirRemisión.Name = "Nbi_ImprimirRemisión"
        Me.Nbi_ImprimirRemisión.Tag = "315"
        Me.Nbi_ImprimirRemisión.Text = "Imprimir Remisión"
        '
        'Nbi_ImprimirRemisiónValorizada
        '
        Me.Nbi_ImprimirRemisiónValorizada.Name = "Nbi_ImprimirRemisiónValorizada"
        Me.Nbi_ImprimirRemisiónValorizada.Tag = "547"
        Me.Nbi_ImprimirRemisiónValorizada.Text = "Imprimir Remisión Valorizada"
        '
        'Nbi_EnviarCorreosSAPendientesXEA
        '
        Me.Nbi_EnviarCorreosSAPendientesXEA.Name = "Nbi_EnviarCorreosSAPendientesXEA"
        Me.Nbi_EnviarCorreosSAPendientesXEA.Tag = "564"
        Me.Nbi_EnviarCorreosSAPendientesXEA.Text = "Enviar Correos SA pendientes por Ingreso"
        '
        'Nbg_Bodega
        '
        Me.Nbg_Bodega.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarBodegas, Me.Nbi_CrearBodega, Me.Nbi_VerBodega, Me.Nbi_ModificarBodega, Me.Nbi_ActivarBodega, Me.Nbi_DesactivarBodega, Me.Nbi_CambiarBodega, Me.Nbi_AsociarUsuarioBodega})
        Me.Nbg_Bodega.Name = "Nbg_Bodega"
        Me.Nbg_Bodega.Tag = "298"
        Me.Nbg_Bodega.Text = "Bodega"
        '
        'Nbi_CargarBodegas
        '
        Me.Nbi_CargarBodegas.Name = "Nbi_CargarBodegas"
        Me.Nbi_CargarBodegas.Tag = "316"
        Me.Nbi_CargarBodegas.Text = "Cargar Bodegas"
        '
        'Nbi_CrearBodega
        '
        Me.Nbi_CrearBodega.Name = "Nbi_CrearBodega"
        Me.Nbi_CrearBodega.Tag = "317"
        Me.Nbi_CrearBodega.Text = "Crear Bodega"
        '
        'Nbi_VerBodega
        '
        Me.Nbi_VerBodega.Name = "Nbi_VerBodega"
        Me.Nbi_VerBodega.Tag = "753"
        Me.Nbi_VerBodega.Text = "Ver Bodega"
        '
        'Nbi_ModificarBodega
        '
        Me.Nbi_ModificarBodega.Name = "Nbi_ModificarBodega"
        Me.Nbi_ModificarBodega.Tag = "318"
        Me.Nbi_ModificarBodega.Text = "Modificar Bodega"
        '
        'Nbi_ActivarBodega
        '
        Me.Nbi_ActivarBodega.Name = "Nbi_ActivarBodega"
        Me.Nbi_ActivarBodega.Tag = "754"
        Me.Nbi_ActivarBodega.Text = "Activar Bodega"
        '
        'Nbi_DesactivarBodega
        '
        Me.Nbi_DesactivarBodega.Name = "Nbi_DesactivarBodega"
        Me.Nbi_DesactivarBodega.Tag = "755"
        Me.Nbi_DesactivarBodega.Text = "Desactivar Bodega"
        '
        'Nbi_CambiarBodega
        '
        Me.Nbi_CambiarBodega.Name = "Nbi_CambiarBodega"
        Me.Nbi_CambiarBodega.Tag = "319"
        Me.Nbi_CambiarBodega.Text = "Cambiar de Bodega"
        '
        'Nbi_AsociarUsuarioBodega
        '
        Me.Nbi_AsociarUsuarioBodega.Name = "Nbi_AsociarUsuarioBodega"
        Me.Nbi_AsociarUsuarioBodega.Tag = "320"
        Me.Nbi_AsociarUsuarioBodega.Text = "Asociar Usuario a Bodega"
        '
        'Nbg_Filtro
        '
        Me.Nbg_Filtro.ControlContainer = Me.NetBarGroupControlContainer3
        Me.Nbg_Filtro.Name = "Nbg_Filtro"
        Me.Nbg_Filtro.Style = NetBarControl.NetBarGroupStyle.ControlContainer
        Me.Nbg_Filtro.Tag = "299"
        Me.Nbg_Filtro.Text = "Filtro"
        '
        'Pn_ContenedorPrincipal
        '
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Pn_ContenedorItems)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Splitter2)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.SplitContainer1)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Pn_tituloformulario)
        Me.Pn_ContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ContenedorPrincipal.Location = New System.Drawing.Point(202, 0)
        Me.Pn_ContenedorPrincipal.Name = "Pn_ContenedorPrincipal"
        Me.Pn_ContenedorPrincipal.Size = New System.Drawing.Size(839, 527)
        Me.Pn_ContenedorPrincipal.TabIndex = 14
        '
        'Pn_ContenedorItems
        '
        Me.Pn_ContenedorItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_ContenedorItems.Controls.Add(Me.Splitter1)
        Me.Pn_ContenedorItems.Controls.Add(Me.Pn_ItemsEA_SA)
        Me.Pn_ContenedorItems.Controls.Add(Me.Pn_equiposasociados)
        Me.Pn_ContenedorItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ContenedorItems.Location = New System.Drawing.Point(0, 325)
        Me.Pn_ContenedorItems.Name = "Pn_ContenedorItems"
        Me.Pn_ContenedorItems.Size = New System.Drawing.Size(839, 202)
        Me.Pn_ContenedorItems.TabIndex = 8
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(434, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 200)
        Me.Splitter1.TabIndex = 19
        Me.Splitter1.TabStop = False
        '
        'Pn_ItemsEA_SA
        '
        Me.Pn_ItemsEA_SA.Controls.Add(Me.DGV_ListaItem)
        Me.Pn_ItemsEA_SA.Controls.Add(Me.Pn_ContenedorTitulointegrantes)
        Me.Pn_ItemsEA_SA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ItemsEA_SA.Location = New System.Drawing.Point(0, 0)
        Me.Pn_ItemsEA_SA.Name = "Pn_ItemsEA_SA"
        Me.Pn_ItemsEA_SA.Size = New System.Drawing.Size(437, 200)
        Me.Pn_ItemsEA_SA.TabIndex = 18
        '
        'DGV_ListaItem
        '
        Me.DGV_ListaItem.AllowUserToAddRows = False
        Me.DGV_ListaItem.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DGV_ListaItem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_ListaItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV_ListaItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_ListaItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaItem.ContextMenuStrip = Me.Cms_CancelarItem
        Me.DGV_ListaItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_ListaItem.Location = New System.Drawing.Point(0, 18)
        Me.DGV_ListaItem.Name = "DGV_ListaItem"
        Me.DGV_ListaItem.ReadOnly = True
        Me.DGV_ListaItem.Size = New System.Drawing.Size(437, 182)
        Me.DGV_ListaItem.TabIndex = 7
        '
        'Cms_CancelarItem
        '
        Me.Cms_CancelarItem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelarItemEAToolStripMenuItem, Me.DevoluciónAProveedorToolStripMenuItem, Me.FiltrarEquiposXCódigoArticuloToolStripMenuItem})
        Me.Cms_CancelarItem.Name = "Cms_CancelarItem"
        Me.Cms_CancelarItem.Size = New System.Drawing.Size(246, 70)
        Me.Cms_CancelarItem.Tag = "332"
        '
        'CancelarItemEAToolStripMenuItem
        '
        Me.CancelarItemEAToolStripMenuItem.Name = "CancelarItemEAToolStripMenuItem"
        Me.CancelarItemEAToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.CancelarItemEAToolStripMenuItem.Text = "Cancelar Item"
        '
        'DevoluciónAProveedorToolStripMenuItem
        '
        Me.DevoluciónAProveedorToolStripMenuItem.Name = "DevoluciónAProveedorToolStripMenuItem"
        Me.DevoluciónAProveedorToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.DevoluciónAProveedorToolStripMenuItem.Text = "Devolución a proveedor"
        '
        'FiltrarEquiposXCódigoArticuloToolStripMenuItem
        '
        Me.FiltrarEquiposXCódigoArticuloToolStripMenuItem.Name = "FiltrarEquiposXCódigoArticuloToolStripMenuItem"
        Me.FiltrarEquiposXCódigoArticuloToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.FiltrarEquiposXCódigoArticuloToolStripMenuItem.Text = "Filtrar Equipos x Código Articulo"
        '
        'Pn_ContenedorTitulointegrantes
        '
        Me.Pn_ContenedorTitulointegrantes.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_ContenedorTitulointegrantes.Controls.Add(Me.Lb_MovimientoDos)
        Me.Pn_ContenedorTitulointegrantes.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_ContenedorTitulointegrantes.Location = New System.Drawing.Point(0, 0)
        Me.Pn_ContenedorTitulointegrantes.Name = "Pn_ContenedorTitulointegrantes"
        Me.Pn_ContenedorTitulointegrantes.Size = New System.Drawing.Size(437, 18)
        Me.Pn_ContenedorTitulointegrantes.TabIndex = 6
        '
        'Lb_MovimientoDos
        '
        Me.Lb_MovimientoDos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_MovimientoDos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_MovimientoDos.ForeColor = System.Drawing.Color.Black
        Me.Lb_MovimientoDos.Location = New System.Drawing.Point(0, 0)
        Me.Lb_MovimientoDos.Name = "Lb_MovimientoDos"
        Me.Lb_MovimientoDos.Size = New System.Drawing.Size(437, 18)
        Me.Lb_MovimientoDos.TabIndex = 0
        Me.Lb_MovimientoDos.Text = "Movimiento_DOS"
        Me.Lb_MovimientoDos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pn_equiposasociados
        '
        Me.Pn_equiposasociados.Controls.Add(Me.DGV_Equipos)
        Me.Pn_equiposasociados.Controls.Add(Me.Panel1)
        Me.Pn_equiposasociados.Dock = System.Windows.Forms.DockStyle.Right
        Me.Pn_equiposasociados.Location = New System.Drawing.Point(437, 0)
        Me.Pn_equiposasociados.Name = "Pn_equiposasociados"
        Me.Pn_equiposasociados.Size = New System.Drawing.Size(400, 200)
        Me.Pn_equiposasociados.TabIndex = 20
        '
        'DGV_Equipos
        '
        Me.DGV_Equipos.AllowUserToAddRows = False
        Me.DGV_Equipos.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DGV_Equipos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_Equipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Equipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_Equipos.Location = New System.Drawing.Point(0, 18)
        Me.DGV_Equipos.Name = "DGV_Equipos"
        Me.DGV_Equipos.ReadOnly = True
        Me.DGV_Equipos.Size = New System.Drawing.Size(400, 182)
        Me.DGV_Equipos.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 18)
        Me.Panel1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(400, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Equipos Asociados"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Location = New System.Drawing.Point(0, 324)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(839, 1)
        Me.Splitter2.TabIndex = 10
        Me.Splitter2.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DGV_Lista)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Pn_Contenedortitulocuadrillas)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Pg_DetalleLista)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Size = New System.Drawing.Size(839, 300)
        Me.SplitContainer1.SplitterDistance = 622
        Me.SplitContainer1.TabIndex = 17
        '
        'DGV_Lista
        '
        Me.DGV_Lista.AllowUserToAddRows = False
        Me.DGV_Lista.AllowUserToDeleteRows = False
        Me.DGV_Lista.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGV_Lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV_Lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV_Lista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGV_Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Lista.ContextMenuStrip = Me.Cms_Ordenar
        Me.DGV_Lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_Lista.Location = New System.Drawing.Point(0, 18)
        Me.DGV_Lista.Name = "DGV_Lista"
        Me.DGV_Lista.ReadOnly = True
        Me.DGV_Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_Lista.Size = New System.Drawing.Size(622, 282)
        Me.DGV_Lista.TabIndex = 11
        '
        'Cms_Ordenar
        '
        Me.Cms_Ordenar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrdenarPorToolStripMenuItem})
        Me.Cms_Ordenar.Name = "Cms_Ordenar"
        Me.Cms_Ordenar.Size = New System.Drawing.Size(142, 26)
        '
        'OrdenarPorToolStripMenuItem
        '
        Me.OrdenarPorToolStripMenuItem.Name = "OrdenarPorToolStripMenuItem"
        Me.OrdenarPorToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.OrdenarPorToolStripMenuItem.Text = "Ordenar Por:"
        '
        'Pn_Contenedortitulocuadrillas
        '
        Me.Pn_Contenedortitulocuadrillas.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_Contenedortitulocuadrillas.Controls.Add(Me.Lb_Movimiento)
        Me.Pn_Contenedortitulocuadrillas.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Contenedortitulocuadrillas.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Contenedortitulocuadrillas.Name = "Pn_Contenedortitulocuadrillas"
        Me.Pn_Contenedortitulocuadrillas.Size = New System.Drawing.Size(622, 18)
        Me.Pn_Contenedortitulocuadrillas.TabIndex = 12
        '
        'Lb_Movimiento
        '
        Me.Lb_Movimiento.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Movimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Movimiento.ForeColor = System.Drawing.Color.Black
        Me.Lb_Movimiento.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Movimiento.Name = "Lb_Movimiento"
        Me.Lb_Movimiento.Size = New System.Drawing.Size(622, 25)
        Me.Lb_Movimiento.TabIndex = 0
        Me.Lb_Movimiento.Text = "Movimiento"
        Me.Lb_Movimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Pg_DetalleLista.Size = New System.Drawing.Size(213, 282)
        Me.Pg_DetalleLista.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 18)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Propiedades"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pn_tituloformulario
        '
        Me.Pn_tituloformulario.BackColor = System.Drawing.SystemColors.Info
        Me.Pn_tituloformulario.Controls.Add(Me.Lb_Cargado)
        Me.Pn_tituloformulario.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_tituloformulario.Location = New System.Drawing.Point(0, 0)
        Me.Pn_tituloformulario.Name = "Pn_tituloformulario"
        Me.Pn_tituloformulario.Size = New System.Drawing.Size(839, 24)
        Me.Pn_tituloformulario.TabIndex = 13
        '
        'Lb_Cargado
        '
        Me.Lb_Cargado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Cargado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Cargado.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Cargado.Name = "Lb_Cargado"
        Me.Lb_Cargado.Size = New System.Drawing.Size(839, 24)
        Me.Lb_Cargado.TabIndex = 0
        Me.Lb_Cargado.Text = "Label1"
        Me.Lb_Cargado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NetBarGroupControlContainer1
        '
        Me.NetBarGroupControlContainer1.Name = "NetBarGroupControlContainer1"
        Me.NetBarGroupControlContainer1.Size = New System.Drawing.Size(0, 0)
        Me.NetBarGroupControlContainer1.TabIndex = 0
        '
        'NetBarGroupControlContainer2
        '
        Me.NetBarGroupControlContainer2.Name = "NetBarGroupControlContainer2"
        Me.NetBarGroupControlContainer2.Size = New System.Drawing.Size(0, 0)
        Me.NetBarGroupControlContainer2.TabIndex = 0
        '
        'Cms_BodegasInactivas
        '
        Me.Cms_BodegasInactivas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_VerBodega, Me.Tsmi_ActivarBodega})
        Me.Cms_BodegasInactivas.Name = "Cms_BodegasInactivas"
        Me.Cms_BodegasInactivas.Size = New System.Drawing.Size(155, 48)
        Me.Cms_BodegasInactivas.Tag = "752"
        Me.Cms_BodegasInactivas.Text = "Bodegas inactivas"
        '
        'Tsmi_VerBodega
        '
        Me.Tsmi_VerBodega.Name = "Tsmi_VerBodega"
        Me.Tsmi_VerBodega.Size = New System.Drawing.Size(154, 22)
        Me.Tsmi_VerBodega.Tag = "756"
        Me.Tsmi_VerBodega.Text = "Ver Bodega..."
        '
        'Tsmi_ActivarBodega
        '
        Me.Tsmi_ActivarBodega.Name = "Tsmi_ActivarBodega"
        Me.Tsmi_ActivarBodega.Size = New System.Drawing.Size(154, 22)
        Me.Tsmi_ActivarBodega.Tag = "757"
        Me.Tsmi_ActivarBodega.Text = "Activar Bodega"
        '
        'Cu_Bodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pn_ContenedorPrincipal)
        Me.Controls.Add(Me.Nbc_Bodega)
        Me.Name = "Cu_Bodega"
        Me.Size = New System.Drawing.Size(1041, 527)
        Me.Nbc_Bodega.ResumeLayout(False)
        Me.NetBarGroupControlContainer3.ResumeLayout(False)
        Me.NetBarGroupControlContainer3.PerformLayout()
        Me.Pn_ContenedorPrincipal.ResumeLayout(False)
        Me.Pn_ContenedorItems.ResumeLayout(False)
        Me.Pn_ItemsEA_SA.ResumeLayout(False)
        CType(Me.DGV_ListaItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_CancelarItem.ResumeLayout(False)
        Me.Pn_ContenedorTitulointegrantes.ResumeLayout(False)
        Me.Pn_equiposasociados.ResumeLayout(False)
        CType(Me.DGV_Equipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DGV_Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_Ordenar.ResumeLayout(False)
        Me.Pn_Contenedortitulocuadrillas.ResumeLayout(False)
        Me.Pn_tituloformulario.ResumeLayout(False)
        Me.Cms_BodegasInactivas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Nbc_Bodega As NetBarControl.NetBarControl
    Friend WithEvents Nbg_EntradaAlmacen As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CrearEA As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarEA As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CancelarEA As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Filtro As NetBarControl.NetBarGroup
    Friend WithEvents Nbg_Traslados As NetBarControl.NetBarGroup
    Friend WithEvents Pn_ContenedorPrincipal As System.Windows.Forms.Panel
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents Nbi_CargarEntradasAlmacen As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Bodega As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CrearBodega As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ModificarBodega As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarBodegas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CambiarBodega As NetBarControl.NetBarItem
    Friend WithEvents Nbi_AsociarUsuarioBodega As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirEntradaAlmacen As NetBarControl.NetBarItem
    Friend WithEvents Pn_ContenedorItems As System.Windows.Forms.Panel
    Friend WithEvents DGV_ListaItem As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_ContenedorTitulointegrantes As System.Windows.Forms.Panel
    Friend WithEvents Lb_MovimientoDos As System.Windows.Forms.Label
    Friend WithEvents Nbi_CargarNoFinEnviaTB As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarNoFinDestTB As NetBarControl.NetBarItem
    Friend WithEvents Nbg_SalidaAlmacen As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CargarSalidaAlmacen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearSA As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarSA As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CancelarSA As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirSalidaAlmacen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirRemisión As NetBarControl.NetBarItem
    Friend WithEvents Cms_CancelarItem As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CancelarItemEAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Pn_tituloformulario As System.Windows.Forms.Panel
    Friend WithEvents Lb_Cargado As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV_Lista As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Contenedortitulocuadrillas As System.Windows.Forms.Panel
    Friend WithEvents Lb_Movimiento As System.Windows.Forms.Label
    Friend WithEvents Pg_DetalleLista As System.Windows.Forms.PropertyGrid
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents NetBarGroupControlContainer1 As NetBarControl.NetBarGroupControlContainer
    Friend WithEvents NetBarGroupControlContainer2 As NetBarControl.NetBarGroupControlContainer
    Friend WithEvents NetBarGroupControlContainer3 As NetBarControl.NetBarGroupControlContainer
    Friend WithEvents Lb_Filtro As System.Windows.Forms.Label
    Friend WithEvents Ck_Filtro3 As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_ValorFiltro3 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_FiltrarPor3 As System.Windows.Forms.ComboBox
    Friend WithEvents Ck_Filtro2 As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_ValorFiltro2 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_FiltrarPor2 As System.Windows.Forms.ComboBox
    Friend WithEvents Ck_Filtro1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tx_ValorFiltro1 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_FiltrarPor1 As System.Windows.Forms.ComboBox
    Friend WithEvents Bt_FiltrarLista As System.Windows.Forms.Button
    Friend WithEvents Nbi_VerSA As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerEA As NetBarControl.NetBarItem
    Friend WithEvents Cms_Ordenar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OrdenarPorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_HabilitarImpresion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HabilitarImpresionEntrada As NetBarControl.NetBarItem
    Friend WithEvents DevoluciónAProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_DevolucionProveedor As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarSalidaAlmacen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarEntrada As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarRemision As NetBarControl.NetBarItem
    Friend WithEvents Pn_ItemsEA_SA As System.Windows.Forms.Panel
    Friend WithEvents Pn_equiposasociados As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV_Equipos As System.Windows.Forms.DataGridView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents FiltrarEquiposXCódigoArticuloToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_ImprimirRemisiónValorizada As NetBarControl.NetBarItem
    Friend WithEvents Nbi_RegistrarDatosTransportador As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SalidasDotación As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarSalidaPorArticulo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarEntradaPorArticulo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarCustodias As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EnviarCorreosSAPendientesXEA As NetBarControl.NetBarItem
    Friend WithEvents Cms_BodegasInactivas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_ActivarBodega As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_VerBodega As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_DesactivarBodega As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerBodega As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ActivarBodega As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarCustodiaH As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirSalida As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerSalidaAlmacenPDF As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirEntradaAlmacen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerPdfEntradaAlmacen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirPdfBloqueEA As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirPdfBloqueSA As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HistorialArchivosPdfSA As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HistorialArchivosPdfEA As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImpSticker As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EnviarCorreoPenSATC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_TrasCustodia As NetBarControl.NetBarItem

End Class
