<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Compras
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
        Me.Nbc_Compras = New NetBarControl.NetBarControl()
        Me.Nbg_Factura = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarRelaciónFacturas = New NetBarControl.NetBarItem()
        Me.Nbi_CrearRelaciónFacturas = New NetBarControl.NetBarItem()
        Me.Nbi_EditarRelaciónFacturas = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirRelación = New NetBarControl.NetBarItem()
        Me.Nbi_RegistrarFactura = New NetBarControl.NetBarItem()
        Me.Nbi_RelFactura = New NetBarControl.NetBarItem()
        Me.Nbi_VerFacturas = New NetBarControl.NetBarItem()
        Me.Nbi_HabilitarImpresionRelacion = New NetBarControl.NetBarItem()
        Me.Nbi_CargarRelaciónFacturasTodas = New NetBarControl.NetBarItem()
        Me.Nbi_EnviarCorreosOCSinFacturaAsociada = New NetBarControl.NetBarItem()
        Me.Nbi_SubirPdfRelacionFactura = New NetBarControl.NetBarItem()
        Me.Nbi_VerPdfRelacionFactura = New NetBarControl.NetBarItem()
        Me.Nbi_SubirPdfBloqueRF = New NetBarControl.NetBarItem()
        Me.Nbi_HistorialArchivosFactura = New NetBarControl.NetBarItem()
        Me.NetBarGroupControlContainer1 = New NetBarControl.NetBarGroupControlContainer()
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
        Me.Nbg_Requisiciones = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarRQ = New NetBarControl.NetBarItem()
        Me.Nbi_CrearRQ = New NetBarControl.NetBarItem()
        Me.Nbi_VerRQ = New NetBarControl.NetBarItem()
        Me.Nbi_EditarRQ = New NetBarControl.NetBarItem()
        Me.Nbi_GenerarOC = New NetBarControl.NetBarItem()
        Me.Nbi_CancelarRQ = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirRequisición = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirComplementoRQ = New NetBarControl.NetBarItem()
        Me.Nbi_AsignarComprador = New NetBarControl.NetBarItem()
        Me.Nbi_RevisiónBodegaPrincipal = New NetBarControl.NetBarItem()
        Me.Nbi_TrazabilidadRQ = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarRQ = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarXarticuloRQ = New NetBarControl.NetBarItem()
        Me.Nbi_HablitarImpresionRQ = New NetBarControl.NetBarItem()
        Me.Nbi_CopiarRQ = New NetBarControl.NetBarItem()
        Me.Nbi_CopiarRQxCotizar = New NetBarControl.NetBarItem()
        Me.Nbi_CambiarTipoStock = New NetBarControl.NetBarItem()
        Me.Nbi_PendienteRQxUsers = New NetBarControl.NetBarItem()
        Me.Nbi_VistoBuenoGerencia = New NetBarControl.NetBarItem()
        Me.Nbi_SubirPDFVbG = New NetBarControl.NetBarItem()
        Me.Nbi_VerPDFVbG = New NetBarControl.NetBarItem()
        Me.Nbi_SubirPdfBloqueRQ = New NetBarControl.NetBarItem()
        Me.Nbi_HistorialArchivosPdfRQ = New NetBarControl.NetBarItem()
        Me.Nbg_OrdenCompra = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarOC = New NetBarControl.NetBarItem()
        Me.Nbi_CrearOC = New NetBarControl.NetBarItem()
        Me.Nbi_VerOC = New NetBarControl.NetBarItem()
        Me.Nbi_EditarOC = New NetBarControl.NetBarItem()
        Me.Nbi_CancelarOC = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirOrdenCompra = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarOC = New NetBarControl.NetBarItem()
        Me.Nbi_HabilitarImpresionOC = New NetBarControl.NetBarItem()
        Me.Nbi_CopiarOC = New NetBarControl.NetBarItem()
        Me.Nb_PendienteOCxEAxUser = New NetBarControl.NetBarItem()
        Me.Nbi_VerEAxOC = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarxArticulo = New NetBarControl.NetBarItem()
        Me.Nbi_DistribuirCostos = New NetBarControl.NetBarItem()
        Me.Nbi_SubirOC = New NetBarControl.NetBarItem()
        Me.Nbi_VerPdfOC = New NetBarControl.NetBarItem()
        Me.Nbi_SubirPdfBloqueOC = New NetBarControl.NetBarItem()
        Me.Nbi_HistorialArchivosPdfOC = New NetBarControl.NetBarItem()
        Me.Nbg_Proveedores = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarProveedor = New NetBarControl.NetBarItem()
        Me.Nbi_CrearProveedor = New NetBarControl.NetBarItem()
        Me.Nbi_EditarProveedor = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarPorSuministro = New NetBarControl.NetBarItem()
        Me.Nbi_BucarXArticulo = New NetBarControl.NetBarItem()
        Me.Nbi_BucarXCiudad = New NetBarControl.NetBarItem()
        Me.Nbi_BucarProveedor = New NetBarControl.NetBarItem()
        Me.Nbg_SolicitudMaquinaria = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarSolicitud = New NetBarControl.NetBarItem()
        Me.Nbi_CrearSolicitud = New NetBarControl.NetBarItem()
        Me.Nbi_VerSolicitud = New NetBarControl.NetBarItem()
        Me.Nbi_EditarSolicitud = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirSolicitud = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarSolicitud = New NetBarControl.NetBarItem()
        Me.Nbi_ConvertirA_Rq = New NetBarControl.NetBarItem()
        Me.Nbg_Filtro = New NetBarControl.NetBarGroup()
        Me.Pn_ContenedorPrincipal = New System.Windows.Forms.Panel()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.Pn_ContenedorLista = New System.Windows.Forms.Panel()
        Me.Pn_ContenedorItemArticulos = New System.Windows.Forms.Panel()
        Me.Dgv_ListaItemRequisición = New System.Windows.Forms.DataGridView()
        Me.Cms_CancelarItemRQ = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CancelarItemToolStripMenuItemRQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarCantidadItemToolStripMenuItemRQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiarIdentificaciónDocumentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pn_ContenedorTitulointegrantes = New System.Windows.Forms.Panel()
        Me.Lb_Pendientes = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Lb_CantidadItems = New System.Windows.Forms.Label()
        Me.Pn_ListaPrincipal = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DGV_ListaRequisiciones = New System.Windows.Forms.DataGridView()
        Me.Cms_Ordenar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OrdenarPorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pn_Contenedortitulocuadrillas = New System.Windows.Forms.Panel()
        Me.Lb_CantidadRequisición = New System.Windows.Forms.Label()
        Me.Pn_Propiedades = New System.Windows.Forms.Panel()
        Me.Pg_DetalleLista = New System.Windows.Forms.PropertyGrid()
        Me.Pn_Suministros = New System.Windows.Forms.Panel()
        Me.Dgv_Suministros = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ChB_MostrarSuministros = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pn_tituloformulario = New System.Windows.Forms.Panel()
        Me.Lb_Cargado = New System.Windows.Forms.Label()
        Me.Cms_CancelarItemOC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CancelarItemToolStripMenuItemOC = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarCantidadItemToolStripMenuItemOC = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_Facturas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_EAxOC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarDocumentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nbc_Compras.SuspendLayout()
        Me.NetBarGroupControlContainer1.SuspendLayout()
        Me.Pn_ContenedorPrincipal.SuspendLayout()
        Me.Pn_ContenedorLista.SuspendLayout()
        Me.Pn_ContenedorItemArticulos.SuspendLayout()
        CType(Me.Dgv_ListaItemRequisición, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_CancelarItemRQ.SuspendLayout()
        Me.Pn_ContenedorTitulointegrantes.SuspendLayout()
        Me.Pn_ListaPrincipal.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DGV_ListaRequisiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_Ordenar.SuspendLayout()
        Me.Pn_Contenedortitulocuadrillas.SuspendLayout()
        Me.Pn_Propiedades.SuspendLayout()
        Me.Pn_Suministros.SuspendLayout()
        CType(Me.Dgv_Suministros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Pn_tituloformulario.SuspendLayout()
        Me.Cms_CancelarItemOC.SuspendLayout()
        Me.Cms_Facturas.SuspendLayout()
        Me.Cms_EAxOC.SuspendLayout()
        Me.SuspendLayout()
        '
        'Nbc_Compras
        '
        Me.Nbc_Compras.ActiveGroup = Me.Nbg_Requisiciones
        Me.Nbc_Compras.Controls.Add(Me.NetBarGroupControlContainer1)
        Me.Nbc_Compras.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_Compras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Compras.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_Requisiciones, Me.Nbg_OrdenCompra, Me.Nbg_Proveedores, Me.Nbg_Factura, Me.Nbg_SolicitudMaquinaria, Me.Nbg_Filtro})
        Me.Nbc_Compras.GroupsFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Compras.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_Compras.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_Compras.Location = New System.Drawing.Point(0, 0)
        Me.Nbc_Compras.Name = "Nbc_Compras"
        Me.Nbc_Compras.ShowOverflowPanel = False
        Me.Nbc_Compras.Size = New System.Drawing.Size(205, 530)
        Me.Nbc_Compras.TabIndex = 12
        Me.Nbc_Compras.Tag = "254"
        Me.Nbc_Compras.Text = "NetBarControl1"
        '
        'Nbg_Factura
        '
        Me.Nbg_Factura.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarRelaciónFacturas, Me.Nbi_CrearRelaciónFacturas, Me.Nbi_EditarRelaciónFacturas, Me.Nbi_ImprimirRelación, Me.Nbi_RegistrarFactura, Me.Nbi_RelFactura, Me.Nbi_VerFacturas, Me.Nbi_HabilitarImpresionRelacion, Me.Nbi_CargarRelaciónFacturasTodas, Me.Nbi_EnviarCorreosOCSinFacturaAsociada, Me.Nbi_SubirPdfRelacionFactura, Me.Nbi_VerPdfRelacionFactura, Me.Nbi_SubirPdfBloqueRF, Me.Nbi_HistorialArchivosFactura})
        Me.Nbg_Factura.Name = "Nbg_Factura"
        Me.Nbg_Factura.Tag = "393"
        Me.Nbg_Factura.Text = "Factura"
        '
        'Nbi_CargarRelaciónFacturas
        '
        Me.Nbi_CargarRelaciónFacturas.Name = "Nbi_CargarRelaciónFacturas"
        Me.Nbi_CargarRelaciónFacturas.Tag = "394"
        Me.Nbi_CargarRelaciónFacturas.Text = "Cargar Relación Facturas"
        '
        'Nbi_CrearRelaciónFacturas
        '
        Me.Nbi_CrearRelaciónFacturas.Name = "Nbi_CrearRelaciónFacturas"
        Me.Nbi_CrearRelaciónFacturas.Tag = "395"
        Me.Nbi_CrearRelaciónFacturas.Text = "Crear Relación Facturas"
        '
        'Nbi_EditarRelaciónFacturas
        '
        Me.Nbi_EditarRelaciónFacturas.Name = "Nbi_EditarRelaciónFacturas"
        Me.Nbi_EditarRelaciónFacturas.Tag = "396"
        Me.Nbi_EditarRelaciónFacturas.Text = "Editar Relación Facturas"
        '
        'Nbi_ImprimirRelación
        '
        Me.Nbi_ImprimirRelación.Name = "Nbi_ImprimirRelación"
        Me.Nbi_ImprimirRelación.Tag = "397"
        Me.Nbi_ImprimirRelación.Text = "Imprimir Relación"
        '
        'Nbi_RegistrarFactura
        '
        Me.Nbi_RegistrarFactura.Name = "Nbi_RegistrarFactura"
        Me.Nbi_RegistrarFactura.Tag = "398"
        Me.Nbi_RegistrarFactura.Text = "Registrar Factura de Proveedor"
        '
        'Nbi_RelFactura
        '
        Me.Nbi_RelFactura.Name = "Nbi_RelFactura"
        Me.Nbi_RelFactura.Tag = "399"
        Me.Nbi_RelFactura.Text = "Relacionar Factura a OC"
        '
        'Nbi_VerFacturas
        '
        Me.Nbi_VerFacturas.Name = "Nbi_VerFacturas"
        Me.Nbi_VerFacturas.Tag = "401"
        Me.Nbi_VerFacturas.Text = "Ver Facturas x Proveedor"
        '
        'Nbi_HabilitarImpresionRelacion
        '
        Me.Nbi_HabilitarImpresionRelacion.Name = "Nbi_HabilitarImpresionRelacion"
        Me.Nbi_HabilitarImpresionRelacion.Tag = "402"
        Me.Nbi_HabilitarImpresionRelacion.Text = "Habilitar Impresion Relación"
        '
        'Nbi_CargarRelaciónFacturasTodas
        '
        Me.Nbi_CargarRelaciónFacturasTodas.Name = "Nbi_CargarRelaciónFacturasTodas"
        Me.Nbi_CargarRelaciónFacturasTodas.Tag = "403"
        Me.Nbi_CargarRelaciónFacturasTodas.Text = "Cargar Todas Relación Factura"
        '
        'Nbi_EnviarCorreosOCSinFacturaAsociada
        '
        Me.Nbi_EnviarCorreosOCSinFacturaAsociada.Name = "Nbi_EnviarCorreosOCSinFacturaAsociada"
        Me.Nbi_EnviarCorreosOCSinFacturaAsociada.Tag = "563"
        Me.Nbi_EnviarCorreosOCSinFacturaAsociada.Text = "Enviar Correos OC sin Factura Asociada"
        '
        'Nbi_SubirPdfRelacionFactura
        '
        Me.Nbi_SubirPdfRelacionFactura.Name = "Nbi_SubirPdfRelacionFactura"
        Me.Nbi_SubirPdfRelacionFactura.Tag = "955"
        Me.Nbi_SubirPdfRelacionFactura.Text = "Subir PDF Relación Facturas"
        '
        'Nbi_VerPdfRelacionFactura
        '
        Me.Nbi_VerPdfRelacionFactura.Name = "Nbi_VerPdfRelacionFactura"
        Me.Nbi_VerPdfRelacionFactura.Tag = "956"
        Me.Nbi_VerPdfRelacionFactura.Text = "Ver PDF Relación Facturas"
        '
        'Nbi_SubirPdfBloqueRF
        '
        Me.Nbi_SubirPdfBloqueRF.Name = "Nbi_SubirPdfBloqueRF"
        Me.Nbi_SubirPdfBloqueRF.Tag = "985"
        Me.Nbi_SubirPdfBloqueRF.Text = "Subir PDFs RF En Bloque"
        '
        'Nbi_HistorialArchivosFactura
        '
        Me.Nbi_HistorialArchivosFactura.Name = "Nbi_HistorialArchivosFactura"
        Me.Nbi_HistorialArchivosFactura.Tag = "425"
        Me.Nbi_HistorialArchivosFactura.Text = "Historial Archivos PDF Factura"
        '
        'NetBarGroupControlContainer1
        '
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Bt_FiltrarLista)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Ck_Filtro3)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Tx_ValorFiltro3)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Cb_FiltrarPor3)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Ck_Filtro2)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Tx_ValorFiltro2)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Cb_FiltrarPor2)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Ck_Filtro1)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Label3)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Tx_ValorFiltro1)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Cb_FiltrarPor1)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Lb_Filtro)
        Me.NetBarGroupControlContainer1.Name = "NetBarGroupControlContainer1"
        Me.NetBarGroupControlContainer1.Size = New System.Drawing.Size(196, 311)
        Me.NetBarGroupControlContainer1.TabIndex = 2
        '
        'Bt_FiltrarLista
        '
        Me.Bt_FiltrarLista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_FiltrarLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_FiltrarLista.Location = New System.Drawing.Point(107, 206)
        Me.Bt_FiltrarLista.Name = "Bt_FiltrarLista"
        Me.Bt_FiltrarLista.Size = New System.Drawing.Size(69, 23)
        Me.Bt_FiltrarLista.TabIndex = 24
        Me.Bt_FiltrarLista.Text = "Filtrar Lista"
        Me.Bt_FiltrarLista.UseVisualStyleBackColor = True
        '
        'Ck_Filtro3
        '
        Me.Ck_Filtro3.AutoSize = True
        Me.Ck_Filtro3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ck_Filtro3.Location = New System.Drawing.Point(3, 157)
        Me.Ck_Filtro3.Name = "Ck_Filtro3"
        Me.Ck_Filtro3.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtro3.TabIndex = 23
        Me.Ck_Filtro3.UseVisualStyleBackColor = True
        '
        'Tx_ValorFiltro3
        '
        Me.Tx_ValorFiltro3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_ValorFiltro3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_ValorFiltro3.Location = New System.Drawing.Point(24, 180)
        Me.Tx_ValorFiltro3.MaxLength = 50
        Me.Tx_ValorFiltro3.Name = "Tx_ValorFiltro3"
        Me.Tx_ValorFiltro3.Size = New System.Drawing.Size(152, 20)
        Me.Tx_ValorFiltro3.TabIndex = 22
        '
        'Cb_FiltrarPor3
        '
        Me.Cb_FiltrarPor3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_FiltrarPor3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_FiltrarPor3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_FiltrarPor3.FormattingEnabled = True
        Me.Cb_FiltrarPor3.Location = New System.Drawing.Point(24, 152)
        Me.Cb_FiltrarPor3.Name = "Cb_FiltrarPor3"
        Me.Cb_FiltrarPor3.Size = New System.Drawing.Size(152, 21)
        Me.Cb_FiltrarPor3.TabIndex = 21
        '
        'Ck_Filtro2
        '
        Me.Ck_Filtro2.AutoSize = True
        Me.Ck_Filtro2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ck_Filtro2.Location = New System.Drawing.Point(3, 104)
        Me.Ck_Filtro2.Name = "Ck_Filtro2"
        Me.Ck_Filtro2.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtro2.TabIndex = 20
        Me.Ck_Filtro2.UseVisualStyleBackColor = True
        '
        'Tx_ValorFiltro2
        '
        Me.Tx_ValorFiltro2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_ValorFiltro2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_ValorFiltro2.Location = New System.Drawing.Point(24, 127)
        Me.Tx_ValorFiltro2.MaxLength = 50
        Me.Tx_ValorFiltro2.Name = "Tx_ValorFiltro2"
        Me.Tx_ValorFiltro2.Size = New System.Drawing.Size(152, 20)
        Me.Tx_ValorFiltro2.TabIndex = 19
        '
        'Cb_FiltrarPor2
        '
        Me.Cb_FiltrarPor2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_FiltrarPor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_FiltrarPor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_FiltrarPor2.FormattingEnabled = True
        Me.Cb_FiltrarPor2.Location = New System.Drawing.Point(24, 99)
        Me.Cb_FiltrarPor2.Name = "Cb_FiltrarPor2"
        Me.Cb_FiltrarPor2.Size = New System.Drawing.Size(152, 21)
        Me.Cb_FiltrarPor2.TabIndex = 18
        '
        'Ck_Filtro1
        '
        Me.Ck_Filtro1.AutoSize = True
        Me.Ck_Filtro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ck_Filtro1.Location = New System.Drawing.Point(3, 50)
        Me.Ck_Filtro1.Name = "Ck_Filtro1"
        Me.Ck_Filtro1.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtro1.TabIndex = 17
        Me.Ck_Filtro1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Filtrar por:"
        '
        'Tx_ValorFiltro1
        '
        Me.Tx_ValorFiltro1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_ValorFiltro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_ValorFiltro1.Location = New System.Drawing.Point(24, 73)
        Me.Tx_ValorFiltro1.MaxLength = 50
        Me.Tx_ValorFiltro1.Name = "Tx_ValorFiltro1"
        Me.Tx_ValorFiltro1.Size = New System.Drawing.Size(152, 20)
        Me.Tx_ValorFiltro1.TabIndex = 15
        '
        'Cb_FiltrarPor1
        '
        Me.Cb_FiltrarPor1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_FiltrarPor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_FiltrarPor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_FiltrarPor1.FormattingEnabled = True
        Me.Cb_FiltrarPor1.Location = New System.Drawing.Point(24, 45)
        Me.Cb_FiltrarPor1.Name = "Cb_FiltrarPor1"
        Me.Cb_FiltrarPor1.Size = New System.Drawing.Size(152, 21)
        Me.Cb_FiltrarPor1.TabIndex = 14
        '
        'Lb_Filtro
        '
        Me.Lb_Filtro.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_Filtro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_Filtro.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Filtro.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Filtro.Name = "Lb_Filtro"
        Me.Lb_Filtro.Size = New System.Drawing.Size(196, 18)
        Me.Lb_Filtro.TabIndex = 1
        Me.Lb_Filtro.Text = "Label2"
        Me.Lb_Filtro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Nbg_Requisiciones
        '
        Me.Nbg_Requisiciones.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarRQ, Me.Nbi_CrearRQ, Me.Nbi_VerRQ, Me.Nbi_EditarRQ, Me.Nbi_GenerarOC, Me.Nbi_CancelarRQ, Me.Nbi_ImprimirRequisición, Me.Nbi_ImprimirComplementoRQ, Me.Nbi_AsignarComprador, Me.Nbi_RevisiónBodegaPrincipal, Me.Nbi_TrazabilidadRQ, Me.Nbi_BuscarRQ, Me.Nbi_BuscarXarticuloRQ, Me.Nbi_HablitarImpresionRQ, Me.Nbi_CopiarRQ, Me.Nbi_CopiarRQxCotizar, Me.Nbi_CambiarTipoStock, Me.Nbi_PendienteRQxUsers, Me.Nbi_VistoBuenoGerencia, Me.Nbi_SubirPDFVbG, Me.Nbi_VerPDFVbG, Me.Nbi_SubirPdfBloqueRQ, Me.Nbi_HistorialArchivosPdfRQ})
        Me.Nbg_Requisiciones.Name = "Nbg_Requisiciones"
        Me.Nbg_Requisiciones.Tag = "255"
        Me.Nbg_Requisiciones.Text = "Requisición"
        '
        'Nbi_CargarRQ
        '
        Me.Nbi_CargarRQ.Name = "Nbi_CargarRQ"
        Me.Nbi_CargarRQ.Tag = "261"
        Me.Nbi_CargarRQ.Text = "Cargar Requisiciones"
        '
        'Nbi_CrearRQ
        '
        Me.Nbi_CrearRQ.Name = "Nbi_CrearRQ"
        Me.Nbi_CrearRQ.Tag = "262"
        Me.Nbi_CrearRQ.Text = "Crear Requisición"
        '
        'Nbi_VerRQ
        '
        Me.Nbi_VerRQ.Name = "Nbi_VerRQ"
        Me.Nbi_VerRQ.Tag = "356"
        Me.Nbi_VerRQ.Text = "Ver Requisición"
        '
        'Nbi_EditarRQ
        '
        Me.Nbi_EditarRQ.Name = "Nbi_EditarRQ"
        Me.Nbi_EditarRQ.Tag = "263"
        Me.Nbi_EditarRQ.Text = "Editar Requisición"
        '
        'Nbi_GenerarOC
        '
        Me.Nbi_GenerarOC.Name = "Nbi_GenerarOC"
        Me.Nbi_GenerarOC.Tag = "264"
        Me.Nbi_GenerarOC.Text = "Generar Orden de Compra"
        '
        'Nbi_CancelarRQ
        '
        Me.Nbi_CancelarRQ.Name = "Nbi_CancelarRQ"
        Me.Nbi_CancelarRQ.Tag = "265"
        Me.Nbi_CancelarRQ.Text = "Cancelar Requisición"
        '
        'Nbi_ImprimirRequisición
        '
        Me.Nbi_ImprimirRequisición.Name = "Nbi_ImprimirRequisición"
        Me.Nbi_ImprimirRequisición.Tag = "266"
        Me.Nbi_ImprimirRequisición.Text = "Imprimir Requisición"
        '
        'Nbi_ImprimirComplementoRQ
        '
        Me.Nbi_ImprimirComplementoRQ.Name = "Nbi_ImprimirComplementoRQ"
        Me.Nbi_ImprimirComplementoRQ.Tag = "648"
        Me.Nbi_ImprimirComplementoRQ.Text = "Imprimir Complemento RQ"
        '
        'Nbi_AsignarComprador
        '
        Me.Nbi_AsignarComprador.Name = "Nbi_AsignarComprador"
        Me.Nbi_AsignarComprador.Tag = "267"
        Me.Nbi_AsignarComprador.Text = "Asignar Persona que gestiona"
        '
        'Nbi_RevisiónBodegaPrincipal
        '
        Me.Nbi_RevisiónBodegaPrincipal.Name = "Nbi_RevisiónBodegaPrincipal"
        Me.Nbi_RevisiónBodegaPrincipal.Tag = "268"
        Me.Nbi_RevisiónBodegaPrincipal.Text = "Revisión Bodega Principal"
        '
        'Nbi_TrazabilidadRQ
        '
        Me.Nbi_TrazabilidadRQ.Name = "Nbi_TrazabilidadRQ"
        Me.Nbi_TrazabilidadRQ.Tag = "340"
        Me.Nbi_TrazabilidadRQ.Text = "Ver Trazabilidad"
        '
        'Nbi_BuscarRQ
        '
        Me.Nbi_BuscarRQ.Name = "Nbi_BuscarRQ"
        Me.Nbi_BuscarRQ.Tag = "386"
        Me.Nbi_BuscarRQ.Text = "Buscar Requisición"
        '
        'Nbi_BuscarXarticuloRQ
        '
        Me.Nbi_BuscarXarticuloRQ.Name = "Nbi_BuscarXarticuloRQ"
        Me.Nbi_BuscarXarticuloRQ.Text = "Buscar Por Artículo"
        '
        'Nbi_HablitarImpresionRQ
        '
        Me.Nbi_HablitarImpresionRQ.Name = "Nbi_HablitarImpresionRQ"
        Me.Nbi_HablitarImpresionRQ.Tag = "387"
        Me.Nbi_HablitarImpresionRQ.Text = "Habilitar Impresión"
        '
        'Nbi_CopiarRQ
        '
        Me.Nbi_CopiarRQ.Name = "Nbi_CopiarRQ"
        Me.Nbi_CopiarRQ.Text = "Copiar RQ Portapapeles"
        '
        'Nbi_CopiarRQxCotizar
        '
        Me.Nbi_CopiarRQxCotizar.Name = "Nbi_CopiarRQxCotizar"
        Me.Nbi_CopiarRQxCotizar.Text = "Copiar RQ Para Cotizar"
        '
        'Nbi_CambiarTipoStock
        '
        Me.Nbi_CambiarTipoStock.Name = "Nbi_CambiarTipoStock"
        Me.Nbi_CambiarTipoStock.Tag = "554"
        Me.Nbi_CambiarTipoStock.Text = "Cambiar Tipo Stock / No Stock"
        '
        'Nbi_PendienteRQxUsers
        '
        Me.Nbi_PendienteRQxUsers.Name = "Nbi_PendienteRQxUsers"
        Me.Nbi_PendienteRQxUsers.Tag = "699"
        Me.Nbi_PendienteRQxUsers.Text = "Pendiente RQ x Usuario"
        '
        'Nbi_VistoBuenoGerencia
        '
        Me.Nbi_VistoBuenoGerencia.Name = "Nbi_VistoBuenoGerencia"
        Me.Nbi_VistoBuenoGerencia.Tag = "840"
        Me.Nbi_VistoBuenoGerencia.Text = "Visto Bueno Gerencia"
        '
        'Nbi_SubirPDFVbG
        '
        Me.Nbi_SubirPDFVbG.Name = "Nbi_SubirPDFVbG"
        Me.Nbi_SubirPDFVbG.Tag = "841"
        Me.Nbi_SubirPDFVbG.Text = "Subir PDF VbG"
        '
        'Nbi_VerPDFVbG
        '
        Me.Nbi_VerPDFVbG.Name = "Nbi_VerPDFVbG"
        Me.Nbi_VerPDFVbG.Tag = "842"
        Me.Nbi_VerPDFVbG.Text = "Ver PDF VbG"
        '
        'Nbi_SubirPdfBloqueRQ
        '
        Me.Nbi_SubirPdfBloqueRQ.Name = "Nbi_SubirPdfBloqueRQ"
        Me.Nbi_SubirPdfBloqueRQ.Tag = "983"
        Me.Nbi_SubirPdfBloqueRQ.Text = "Subir PDFs RQ En Bloque"
        '
        'Nbi_HistorialArchivosPdfRQ
        '
        Me.Nbi_HistorialArchivosPdfRQ.Name = "Nbi_HistorialArchivosPdfRQ"
        Me.Nbi_HistorialArchivosPdfRQ.Tag = "423"
        Me.Nbi_HistorialArchivosPdfRQ.Text = "Historial Archivos RQ"
        '
        'Nbg_OrdenCompra
        '
        Me.Nbg_OrdenCompra.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarOC, Me.Nbi_CrearOC, Me.Nbi_VerOC, Me.Nbi_EditarOC, Me.Nbi_CancelarOC, Me.Nbi_ImprimirOrdenCompra, Me.Nbi_BuscarOC, Me.Nbi_HabilitarImpresionOC, Me.Nbi_CopiarOC, Me.Nb_PendienteOCxEAxUser, Me.Nbi_VerEAxOC, Me.Nbi_BuscarxArticulo, Me.Nbi_DistribuirCostos, Me.Nbi_SubirOC, Me.Nbi_VerPdfOC, Me.Nbi_SubirPdfBloqueOC, Me.Nbi_HistorialArchivosPdfOC})
        Me.Nbg_OrdenCompra.Name = "Nbg_OrdenCompra"
        Me.Nbg_OrdenCompra.Tag = "256"
        Me.Nbg_OrdenCompra.Text = "Órdenes de Compra"
        '
        'Nbi_CargarOC
        '
        Me.Nbi_CargarOC.Name = "Nbi_CargarOC"
        Me.Nbi_CargarOC.Tag = "269"
        Me.Nbi_CargarOC.Text = "Cargar Ordenes de Compra"
        '
        'Nbi_CrearOC
        '
        Me.Nbi_CrearOC.Name = "Nbi_CrearOC"
        Me.Nbi_CrearOC.Tag = "270"
        Me.Nbi_CrearOC.Text = "Crear Orden de Compra"
        '
        'Nbi_VerOC
        '
        Me.Nbi_VerOC.Name = "Nbi_VerOC"
        Me.Nbi_VerOC.Tag = "360"
        Me.Nbi_VerOC.Text = "Ver Orden de Compra"
        '
        'Nbi_EditarOC
        '
        Me.Nbi_EditarOC.Name = "Nbi_EditarOC"
        Me.Nbi_EditarOC.Tag = "271"
        Me.Nbi_EditarOC.Text = "Editar Orden de Compra"
        '
        'Nbi_CancelarOC
        '
        Me.Nbi_CancelarOC.Name = "Nbi_CancelarOC"
        Me.Nbi_CancelarOC.Tag = "272"
        Me.Nbi_CancelarOC.Text = "Cancelar Orden de Compra"
        '
        'Nbi_ImprimirOrdenCompra
        '
        Me.Nbi_ImprimirOrdenCompra.Name = "Nbi_ImprimirOrdenCompra"
        Me.Nbi_ImprimirOrdenCompra.Tag = "273"
        Me.Nbi_ImprimirOrdenCompra.Text = "Imprimir Orden de Compra"
        '
        'Nbi_BuscarOC
        '
        Me.Nbi_BuscarOC.Name = "Nbi_BuscarOC"
        Me.Nbi_BuscarOC.Tag = "391"
        Me.Nbi_BuscarOC.Text = "Buscar Orden de Compra"
        '
        'Nbi_HabilitarImpresionOC
        '
        Me.Nbi_HabilitarImpresionOC.Name = "Nbi_HabilitarImpresionOC"
        Me.Nbi_HabilitarImpresionOC.Tag = "392"
        Me.Nbi_HabilitarImpresionOC.Text = "Habilitar Impresión"
        '
        'Nbi_CopiarOC
        '
        Me.Nbi_CopiarOC.Name = "Nbi_CopiarOC"
        Me.Nbi_CopiarOC.Text = "Copiar OC  Portapapeles"
        '
        'Nb_PendienteOCxEAxUser
        '
        Me.Nb_PendienteOCxEAxUser.Name = "Nb_PendienteOCxEAxUser"
        Me.Nb_PendienteOCxEAxUser.Text = "Pendiente OC x EA x Usuario"
        '
        'Nbi_VerEAxOC
        '
        Me.Nbi_VerEAxOC.Name = "Nbi_VerEAxOC"
        Me.Nbi_VerEAxOC.Tag = "843"
        Me.Nbi_VerEAxOC.Text = "Ver EA x OC"
        '
        'Nbi_BuscarxArticulo
        '
        Me.Nbi_BuscarxArticulo.Name = "Nbi_BuscarxArticulo"
        Me.Nbi_BuscarxArticulo.Tag = "845"
        Me.Nbi_BuscarxArticulo.Text = "Buscar por Artículo"
        '
        'Nbi_DistribuirCostos
        '
        Me.Nbi_DistribuirCostos.Name = "Nbi_DistribuirCostos"
        Me.Nbi_DistribuirCostos.Tag = "846"
        Me.Nbi_DistribuirCostos.Text = "Distribución Costos OC"
        '
        'Nbi_SubirOC
        '
        Me.Nbi_SubirOC.Name = "Nbi_SubirOC"
        Me.Nbi_SubirOC.Tag = "951"
        Me.Nbi_SubirOC.Text = "Subir PDF OC"
        '
        'Nbi_VerPdfOC
        '
        Me.Nbi_VerPdfOC.Name = "Nbi_VerPdfOC"
        Me.Nbi_VerPdfOC.Tag = "952"
        Me.Nbi_VerPdfOC.Text = "Ver PDF OC"
        '
        'Nbi_SubirPdfBloqueOC
        '
        Me.Nbi_SubirPdfBloqueOC.Name = "Nbi_SubirPdfBloqueOC"
        Me.Nbi_SubirPdfBloqueOC.Tag = "984"
        Me.Nbi_SubirPdfBloqueOC.Text = "Subir PDFs OC En Bloque"
        '
        'Nbi_HistorialArchivosPdfOC
        '
        Me.Nbi_HistorialArchivosPdfOC.Name = "Nbi_HistorialArchivosPdfOC"
        Me.Nbi_HistorialArchivosPdfOC.Tag = "424"
        Me.Nbi_HistorialArchivosPdfOC.Text = "Historial Archivos OC"
        '
        'Nbg_Proveedores
        '
        Me.Nbg_Proveedores.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarProveedor, Me.Nbi_CrearProveedor, Me.Nbi_EditarProveedor, Me.Nbi_BuscarPorSuministro, Me.Nbi_BucarXArticulo, Me.Nbi_BucarXCiudad, Me.Nbi_BucarProveedor})
        Me.Nbg_Proveedores.Name = "Nbg_Proveedores"
        Me.Nbg_Proveedores.Tag = "257"
        Me.Nbg_Proveedores.Text = "Proveedores"
        '
        'Nbi_CargarProveedor
        '
        Me.Nbi_CargarProveedor.Name = "Nbi_CargarProveedor"
        Me.Nbi_CargarProveedor.Tag = "274"
        Me.Nbi_CargarProveedor.Text = "Cargar Proveedores"
        '
        'Nbi_CrearProveedor
        '
        Me.Nbi_CrearProveedor.Name = "Nbi_CrearProveedor"
        Me.Nbi_CrearProveedor.Tag = "275"
        Me.Nbi_CrearProveedor.Text = "Crear Proveedor"
        '
        'Nbi_EditarProveedor
        '
        Me.Nbi_EditarProveedor.Name = "Nbi_EditarProveedor"
        Me.Nbi_EditarProveedor.Tag = "276"
        Me.Nbi_EditarProveedor.Text = "Editar Proveedor"
        '
        'Nbi_BuscarPorSuministro
        '
        Me.Nbi_BuscarPorSuministro.Name = "Nbi_BuscarPorSuministro"
        Me.Nbi_BuscarPorSuministro.Text = "Buscar Proveedor X Suministro"
        '
        'Nbi_BucarXArticulo
        '
        Me.Nbi_BucarXArticulo.Name = "Nbi_BucarXArticulo"
        Me.Nbi_BucarXArticulo.Text = "Buscar Proveedor X Artículo"
        '
        'Nbi_BucarXCiudad
        '
        Me.Nbi_BucarXCiudad.Name = "Nbi_BucarXCiudad"
        Me.Nbi_BucarXCiudad.Text = "Buscar Proveedor X Ciudad"
        '
        'Nbi_BucarProveedor
        '
        Me.Nbi_BucarProveedor.Name = "Nbi_BucarProveedor"
        Me.Nbi_BucarProveedor.Text = "Buscar proveedor"
        '
        'Nbg_SolicitudMaquinaria
        '
        Me.Nbg_SolicitudMaquinaria.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarSolicitud, Me.Nbi_CrearSolicitud, Me.Nbi_VerSolicitud, Me.Nbi_EditarSolicitud, Me.Nbi_ImprimirSolicitud, Me.Nbi_BuscarSolicitud, Me.Nbi_ConvertirA_Rq})
        Me.Nbg_SolicitudMaquinaria.Name = "Nbg_SolicitudMaquinaria"
        Me.Nbg_SolicitudMaquinaria.Tag = "569"
        Me.Nbg_SolicitudMaquinaria.Text = "Solicitud de Maquinaria"
        '
        'Nbi_CargarSolicitud
        '
        Me.Nbi_CargarSolicitud.Name = "Nbi_CargarSolicitud"
        Me.Nbi_CargarSolicitud.Tag = "570"
        Me.Nbi_CargarSolicitud.Text = "Cargar Solicitudes"
        '
        'Nbi_CrearSolicitud
        '
        Me.Nbi_CrearSolicitud.Name = "Nbi_CrearSolicitud"
        Me.Nbi_CrearSolicitud.Tag = "571"
        Me.Nbi_CrearSolicitud.Text = "Crear Solicitud"
        '
        'Nbi_VerSolicitud
        '
        Me.Nbi_VerSolicitud.Name = "Nbi_VerSolicitud"
        Me.Nbi_VerSolicitud.Tag = "572"
        Me.Nbi_VerSolicitud.Text = "Ver Solicitud"
        '
        'Nbi_EditarSolicitud
        '
        Me.Nbi_EditarSolicitud.Name = "Nbi_EditarSolicitud"
        Me.Nbi_EditarSolicitud.Tag = "573"
        Me.Nbi_EditarSolicitud.Text = "Editar Solicitud"
        '
        'Nbi_ImprimirSolicitud
        '
        Me.Nbi_ImprimirSolicitud.Name = "Nbi_ImprimirSolicitud"
        Me.Nbi_ImprimirSolicitud.Tag = "574"
        Me.Nbi_ImprimirSolicitud.Text = "Imprimir Solicitud"
        '
        'Nbi_BuscarSolicitud
        '
        Me.Nbi_BuscarSolicitud.Name = "Nbi_BuscarSolicitud"
        Me.Nbi_BuscarSolicitud.Tag = "575"
        Me.Nbi_BuscarSolicitud.Text = "Buscar Solicitud"
        '
        'Nbi_ConvertirA_Rq
        '
        Me.Nbi_ConvertirA_Rq.Name = "Nbi_ConvertirA_Rq"
        Me.Nbi_ConvertirA_Rq.Tag = "576"
        Me.Nbi_ConvertirA_Rq.Text = "Convertir a Requisición"
        '
        'Nbg_Filtro
        '
        Me.Nbg_Filtro.ControlContainer = Me.NetBarGroupControlContainer1
        Me.Nbg_Filtro.Name = "Nbg_Filtro"
        Me.Nbg_Filtro.Style = NetBarControl.NetBarGroupStyle.ControlContainer
        Me.Nbg_Filtro.Tag = "258"
        Me.Nbg_Filtro.Text = "Filtro"
        '
        'Pn_ContenedorPrincipal
        '
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Splitter2)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Pn_ContenedorLista)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Pn_ListaPrincipal)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Pn_tituloformulario)
        Me.Pn_ContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ContenedorPrincipal.Location = New System.Drawing.Point(205, 0)
        Me.Pn_ContenedorPrincipal.Name = "Pn_ContenedorPrincipal"
        Me.Pn_ContenedorPrincipal.Size = New System.Drawing.Size(675, 530)
        Me.Pn_ContenedorPrincipal.TabIndex = 13
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Location = New System.Drawing.Point(0, 324)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(675, 1)
        Me.Splitter2.TabIndex = 10
        Me.Splitter2.TabStop = False
        '
        'Pn_ContenedorLista
        '
        Me.Pn_ContenedorLista.Controls.Add(Me.Pn_ContenedorItemArticulos)
        Me.Pn_ContenedorLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ContenedorLista.Location = New System.Drawing.Point(0, 324)
        Me.Pn_ContenedorLista.Name = "Pn_ContenedorLista"
        Me.Pn_ContenedorLista.Size = New System.Drawing.Size(675, 206)
        Me.Pn_ContenedorLista.TabIndex = 9
        '
        'Pn_ContenedorItemArticulos
        '
        Me.Pn_ContenedorItemArticulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_ContenedorItemArticulos.Controls.Add(Me.Dgv_ListaItemRequisición)
        Me.Pn_ContenedorItemArticulos.Controls.Add(Me.Pn_ContenedorTitulointegrantes)
        Me.Pn_ContenedorItemArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ContenedorItemArticulos.Location = New System.Drawing.Point(0, 0)
        Me.Pn_ContenedorItemArticulos.Name = "Pn_ContenedorItemArticulos"
        Me.Pn_ContenedorItemArticulos.Size = New System.Drawing.Size(675, 206)
        Me.Pn_ContenedorItemArticulos.TabIndex = 8
        '
        'Dgv_ListaItemRequisición
        '
        Me.Dgv_ListaItemRequisición.AllowUserToAddRows = False
        Me.Dgv_ListaItemRequisición.AllowUserToDeleteRows = False
        Me.Dgv_ListaItemRequisición.AllowUserToOrderColumns = True
        Me.Dgv_ListaItemRequisición.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_ListaItemRequisición.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ListaItemRequisición.ContextMenuStrip = Me.Cms_CancelarItemRQ
        Me.Dgv_ListaItemRequisición.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaItemRequisición.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_ListaItemRequisición.Name = "Dgv_ListaItemRequisición"
        Me.Dgv_ListaItemRequisición.ReadOnly = True
        Me.Dgv_ListaItemRequisición.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_ListaItemRequisición.Size = New System.Drawing.Size(673, 186)
        Me.Dgv_ListaItemRequisición.TabIndex = 7
        '
        'Cms_CancelarItemRQ
        '
        Me.Cms_CancelarItemRQ.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_CancelarItemRQ.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelarItemToolStripMenuItemRQ, Me.CancelarCantidadItemToolStripMenuItemRQ, Me.CopiarIdentificaciónDocumentoToolStripMenuItem})
        Me.Cms_CancelarItemRQ.Name = "Cms_CancelarItem"
        Me.Cms_CancelarItemRQ.Size = New System.Drawing.Size(251, 70)
        Me.Cms_CancelarItemRQ.Tag = "284"
        '
        'CancelarItemToolStripMenuItemRQ
        '
        Me.CancelarItemToolStripMenuItemRQ.Name = "CancelarItemToolStripMenuItemRQ"
        Me.CancelarItemToolStripMenuItemRQ.Size = New System.Drawing.Size(250, 22)
        Me.CancelarItemToolStripMenuItemRQ.Text = "Cancelar Item"
        '
        'CancelarCantidadItemToolStripMenuItemRQ
        '
        Me.CancelarCantidadItemToolStripMenuItemRQ.Name = "CancelarCantidadItemToolStripMenuItemRQ"
        Me.CancelarCantidadItemToolStripMenuItemRQ.Size = New System.Drawing.Size(250, 22)
        Me.CancelarCantidadItemToolStripMenuItemRQ.Text = "Cancelar Cantidad Item"
        '
        'CopiarIdentificaciónDocumentoToolStripMenuItem
        '
        Me.CopiarIdentificaciónDocumentoToolStripMenuItem.Name = "CopiarIdentificaciónDocumentoToolStripMenuItem"
        Me.CopiarIdentificaciónDocumentoToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.CopiarIdentificaciónDocumentoToolStripMenuItem.Text = "Copiar Identificación Documento"
        '
        'Pn_ContenedorTitulointegrantes
        '
        Me.Pn_ContenedorTitulointegrantes.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_ContenedorTitulointegrantes.Controls.Add(Me.Lb_Pendientes)
        Me.Pn_ContenedorTitulointegrantes.Controls.Add(Me.LinkLabel1)
        Me.Pn_ContenedorTitulointegrantes.Controls.Add(Me.Lb_CantidadItems)
        Me.Pn_ContenedorTitulointegrantes.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_ContenedorTitulointegrantes.Location = New System.Drawing.Point(0, 0)
        Me.Pn_ContenedorTitulointegrantes.Name = "Pn_ContenedorTitulointegrantes"
        Me.Pn_ContenedorTitulointegrantes.Size = New System.Drawing.Size(673, 18)
        Me.Pn_ContenedorTitulointegrantes.TabIndex = 6
        '
        'Lb_Pendientes
        '
        Me.Lb_Pendientes.AutoSize = True
        Me.Lb_Pendientes.Location = New System.Drawing.Point(50, 2)
        Me.Lb_Pendientes.Name = "Lb_Pendientes"
        Me.Lb_Pendientes.Size = New System.Drawing.Size(60, 13)
        Me.Lb_Pendientes.TabIndex = 4
        Me.Lb_Pendientes.TabStop = True
        Me.Lb_Pendientes.Text = "Pendientes"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(7, 2)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(37, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Todos"
        '
        'Lb_CantidadItems
        '
        Me.Lb_CantidadItems.AutoSize = True
        Me.Lb_CantidadItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadItems.ForeColor = System.Drawing.Color.Black
        Me.Lb_CantidadItems.Location = New System.Drawing.Point(143, 2)
        Me.Lb_CantidadItems.Name = "Lb_CantidadItems"
        Me.Lb_CantidadItems.Size = New System.Drawing.Size(219, 13)
        Me.Lb_CantidadItems.TabIndex = 0
        Me.Lb_CantidadItems.Text = "Artículos solicitados en la requisición"
        Me.Lb_CantidadItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pn_ListaPrincipal
        '
        Me.Pn_ListaPrincipal.Controls.Add(Me.SplitContainer1)
        Me.Pn_ListaPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_ListaPrincipal.Location = New System.Drawing.Point(0, 24)
        Me.Pn_ListaPrincipal.Name = "Pn_ListaPrincipal"
        Me.Pn_ListaPrincipal.Size = New System.Drawing.Size(675, 300)
        Me.Pn_ListaPrincipal.TabIndex = 12
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DGV_ListaRequisiciones)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Pn_Contenedortitulocuadrillas)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Pn_Propiedades)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(675, 300)
        Me.SplitContainer1.SplitterDistance = 450
        Me.SplitContainer1.TabIndex = 4
        '
        'DGV_ListaRequisiciones
        '
        Me.DGV_ListaRequisiciones.AllowUserToAddRows = False
        Me.DGV_ListaRequisiciones.AllowUserToDeleteRows = False
        Me.DGV_ListaRequisiciones.AllowUserToOrderColumns = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGV_ListaRequisiciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_ListaRequisiciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV_ListaRequisiciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_ListaRequisiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaRequisiciones.ContextMenuStrip = Me.Cms_Ordenar
        Me.DGV_ListaRequisiciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_ListaRequisiciones.Location = New System.Drawing.Point(0, 18)
        Me.DGV_ListaRequisiciones.Name = "DGV_ListaRequisiciones"
        Me.DGV_ListaRequisiciones.ReadOnly = True
        Me.DGV_ListaRequisiciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_ListaRequisiciones.Size = New System.Drawing.Size(450, 282)
        Me.DGV_ListaRequisiciones.TabIndex = 3
        '
        'Cms_Ordenar
        '
        Me.Cms_Ordenar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_Ordenar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrdenarPorToolStripMenuItem})
        Me.Cms_Ordenar.Name = "Cms_Ordenar"
        Me.Cms_Ordenar.Size = New System.Drawing.Size(139, 26)
        '
        'OrdenarPorToolStripMenuItem
        '
        Me.OrdenarPorToolStripMenuItem.Name = "OrdenarPorToolStripMenuItem"
        Me.OrdenarPorToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.OrdenarPorToolStripMenuItem.Text = "Ordenar Por"
        '
        'Pn_Contenedortitulocuadrillas
        '
        Me.Pn_Contenedortitulocuadrillas.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_Contenedortitulocuadrillas.Controls.Add(Me.Lb_CantidadRequisición)
        Me.Pn_Contenedortitulocuadrillas.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Contenedortitulocuadrillas.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Contenedortitulocuadrillas.Name = "Pn_Contenedortitulocuadrillas"
        Me.Pn_Contenedortitulocuadrillas.Size = New System.Drawing.Size(450, 18)
        Me.Pn_Contenedortitulocuadrillas.TabIndex = 8
        '
        'Lb_CantidadRequisición
        '
        Me.Lb_CantidadRequisición.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_CantidadRequisición.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadRequisición.ForeColor = System.Drawing.Color.Black
        Me.Lb_CantidadRequisición.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CantidadRequisición.Name = "Lb_CantidadRequisición"
        Me.Lb_CantidadRequisición.Size = New System.Drawing.Size(450, 18)
        Me.Lb_CantidadRequisición.TabIndex = 0
        Me.Lb_CantidadRequisición.Text = "Requisiciones pendientes"
        Me.Lb_CantidadRequisición.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pn_Propiedades
        '
        Me.Pn_Propiedades.AutoSize = True
        Me.Pn_Propiedades.Controls.Add(Me.Pg_DetalleLista)
        Me.Pn_Propiedades.Controls.Add(Me.Pn_Suministros)
        Me.Pn_Propiedades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Propiedades.Location = New System.Drawing.Point(0, 18)
        Me.Pn_Propiedades.Name = "Pn_Propiedades"
        Me.Pn_Propiedades.Size = New System.Drawing.Size(221, 282)
        Me.Pn_Propiedades.TabIndex = 11
        '
        'Pg_DetalleLista
        '
        Me.Pg_DetalleLista.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Pg_DetalleLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pg_DetalleLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pg_DetalleLista.LineColor = System.Drawing.SystemColors.ControlDark
        Me.Pg_DetalleLista.Location = New System.Drawing.Point(0, 0)
        Me.Pg_DetalleLista.Name = "Pg_DetalleLista"
        Me.Pg_DetalleLista.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.Pg_DetalleLista.Size = New System.Drawing.Size(221, 189)
        Me.Pg_DetalleLista.TabIndex = 10
        '
        'Pn_Suministros
        '
        Me.Pn_Suministros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Suministros.Controls.Add(Me.Dgv_Suministros)
        Me.Pn_Suministros.Controls.Add(Me.Panel4)
        Me.Pn_Suministros.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Suministros.Location = New System.Drawing.Point(0, 189)
        Me.Pn_Suministros.Name = "Pn_Suministros"
        Me.Pn_Suministros.Size = New System.Drawing.Size(221, 93)
        Me.Pn_Suministros.TabIndex = 12
        Me.Pn_Suministros.Visible = False
        '
        'Dgv_Suministros
        '
        Me.Dgv_Suministros.AllowUserToAddRows = False
        Me.Dgv_Suministros.AllowUserToDeleteRows = False
        Me.Dgv_Suministros.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Dgv_Suministros.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_Suministros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_Suministros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Suministros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Suministros.Location = New System.Drawing.Point(0, 25)
        Me.Dgv_Suministros.Name = "Dgv_Suministros"
        Me.Dgv_Suministros.ReadOnly = True
        Me.Dgv_Suministros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Suministros.Size = New System.Drawing.Size(219, 66)
        Me.Dgv_Suministros.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.ChB_MostrarSuministros)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(219, 25)
        Me.Panel4.TabIndex = 0
        '
        'ChB_MostrarSuministros
        '
        Me.ChB_MostrarSuministros.AutoSize = True
        Me.ChB_MostrarSuministros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChB_MostrarSuministros.Location = New System.Drawing.Point(0, 0)
        Me.ChB_MostrarSuministros.Name = "ChB_MostrarSuministros"
        Me.ChB_MostrarSuministros.Size = New System.Drawing.Size(217, 23)
        Me.ChB_MostrarSuministros.TabIndex = 0
        Me.ChB_MostrarSuministros.Text = "Mostrar Suministros"
        Me.ChB_MostrarSuministros.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(221, 18)
        Me.Panel1.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(221, 18)
        Me.Label1.TabIndex = 0
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
        Me.Pn_tituloformulario.Size = New System.Drawing.Size(675, 24)
        Me.Pn_tituloformulario.TabIndex = 11
        '
        'Lb_Cargado
        '
        Me.Lb_Cargado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Cargado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Cargado.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Cargado.Name = "Lb_Cargado"
        Me.Lb_Cargado.Size = New System.Drawing.Size(675, 24)
        Me.Lb_Cargado.TabIndex = 0
        Me.Lb_Cargado.Text = "Label1"
        Me.Lb_Cargado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cms_CancelarItemOC
        '
        Me.Cms_CancelarItemOC.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_CancelarItemOC.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelarItemToolStripMenuItemOC, Me.CancelarCantidadItemToolStripMenuItemOC})
        Me.Cms_CancelarItemOC.Name = "Cms_CancelarItem"
        Me.Cms_CancelarItemOC.Size = New System.Drawing.Size(199, 48)
        Me.Cms_CancelarItemOC.Tag = "285"
        '
        'CancelarItemToolStripMenuItemOC
        '
        Me.CancelarItemToolStripMenuItemOC.Name = "CancelarItemToolStripMenuItemOC"
        Me.CancelarItemToolStripMenuItemOC.Size = New System.Drawing.Size(198, 22)
        Me.CancelarItemToolStripMenuItemOC.Text = "Cancelar Item"
        '
        'CancelarCantidadItemToolStripMenuItemOC
        '
        Me.CancelarCantidadItemToolStripMenuItemOC.Name = "CancelarCantidadItemToolStripMenuItemOC"
        Me.CancelarCantidadItemToolStripMenuItemOC.Size = New System.Drawing.Size(198, 22)
        Me.CancelarCantidadItemToolStripMenuItemOC.Text = "Cancelar Cantidad Item"
        '
        'Cms_Facturas
        '
        Me.Cms_Facturas.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_Facturas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarFacturaToolStripMenuItem, Me.EditarFacturaToolStripMenuItem})
        Me.Cms_Facturas.Name = "Cms_Facturas"
        Me.Cms_Facturas.Size = New System.Drawing.Size(160, 48)
        '
        'EliminarFacturaToolStripMenuItem
        '
        Me.EliminarFacturaToolStripMenuItem.Name = "EliminarFacturaToolStripMenuItem"
        Me.EliminarFacturaToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.EliminarFacturaToolStripMenuItem.Text = "Eliminar Factura"
        '
        'EditarFacturaToolStripMenuItem
        '
        Me.EditarFacturaToolStripMenuItem.Name = "EditarFacturaToolStripMenuItem"
        Me.EditarFacturaToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.EditarFacturaToolStripMenuItem.Text = "Editar Factura"
        '
        'Cms_EAxOC
        '
        Me.Cms_EAxOC.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarDocumentoToolStripMenuItem})
        Me.Cms_EAxOC.Name = "Cms_EAxOC"
        Me.Cms_EAxOC.Size = New System.Drawing.Size(176, 26)
        '
        'CopiarDocumentoToolStripMenuItem
        '
        Me.CopiarDocumentoToolStripMenuItem.Name = "CopiarDocumentoToolStripMenuItem"
        Me.CopiarDocumentoToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.CopiarDocumentoToolStripMenuItem.Text = "Copiar Documento"
        '
        'Cu_Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pn_ContenedorPrincipal)
        Me.Controls.Add(Me.Nbc_Compras)
        Me.Name = "Cu_Compras"
        Me.Size = New System.Drawing.Size(880, 530)
        Me.Nbc_Compras.ResumeLayout(False)
        Me.NetBarGroupControlContainer1.ResumeLayout(False)
        Me.NetBarGroupControlContainer1.PerformLayout()
        Me.Pn_ContenedorPrincipal.ResumeLayout(False)
        Me.Pn_ContenedorLista.ResumeLayout(False)
        Me.Pn_ContenedorItemArticulos.ResumeLayout(False)
        CType(Me.Dgv_ListaItemRequisición, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_CancelarItemRQ.ResumeLayout(False)
        Me.Pn_ContenedorTitulointegrantes.ResumeLayout(False)
        Me.Pn_ContenedorTitulointegrantes.PerformLayout()
        Me.Pn_ListaPrincipal.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DGV_ListaRequisiciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_Ordenar.ResumeLayout(False)
        Me.Pn_Contenedortitulocuadrillas.ResumeLayout(False)
        Me.Pn_Propiedades.ResumeLayout(False)
        Me.Pn_Suministros.ResumeLayout(False)
        CType(Me.Dgv_Suministros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Pn_tituloformulario.ResumeLayout(False)
        Me.Cms_CancelarItemOC.ResumeLayout(False)
        Me.Cms_Facturas.ResumeLayout(False)
        Me.Cms_EAxOC.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Nbc_Compras As NetBarControl.NetBarControl
    Friend WithEvents Nbg_Requisiciones As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CrearRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CancelarRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbg_OrdenCompra As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CrearOC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarOC As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Filtro As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CancelarOC As NetBarControl.NetBarItem
    Friend WithEvents Pn_ContenedorPrincipal As System.Windows.Forms.Panel
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents DGV_ListaRequisiciones As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Contenedortitulocuadrillas As System.Windows.Forms.Panel
    Friend WithEvents Lb_CantidadRequisición As System.Windows.Forms.Label
    Friend WithEvents Nbg_Proveedores As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CargarProveedor As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearProveedor As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarProveedor As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarOC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_GenerarOC As NetBarControl.NetBarItem
    Friend WithEvents Pn_ContenedorLista As System.Windows.Forms.Panel
    Friend WithEvents Pn_ContenedorItemArticulos As System.Windows.Forms.Panel
    Friend WithEvents Dgv_ListaItemRequisición As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_ContenedorTitulointegrantes As System.Windows.Forms.Panel
    Friend WithEvents Lb_CantidadItems As System.Windows.Forms.Label
    Friend WithEvents Nbi_ImprimirOrdenCompra As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirRequisición As NetBarControl.NetBarItem
    Friend WithEvents Cms_CancelarItemRQ As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CancelarItemToolStripMenuItemRQ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Pn_tituloformulario As System.Windows.Forms.Panel
    Friend WithEvents Lb_Cargado As System.Windows.Forms.Label
    Friend WithEvents Nbi_AsignarComprador As NetBarControl.NetBarItem
    Friend WithEvents Nbi_RevisiónBodegaPrincipal As NetBarControl.NetBarItem
    Friend WithEvents Cms_CancelarItemOC As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CancelarItemToolStripMenuItemOC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Lb_Pendientes As System.Windows.Forms.LinkLabel
    Friend WithEvents Pn_ListaPrincipal As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pg_DetalleLista As System.Windows.Forms.PropertyGrid
    Friend WithEvents Nbi_TrazabilidadRQ As NetBarControl.NetBarItem
    Friend WithEvents NetBarGroupControlContainer1 As NetBarControl.NetBarGroupControlContainer
    Friend WithEvents Lb_Filtro As System.Windows.Forms.Label
    Friend WithEvents Bt_FiltrarLista As System.Windows.Forms.Button
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
    Friend WithEvents CancelarCantidadItemToolStripMenuItemOC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_VerOC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerRQ As NetBarControl.NetBarItem
    Friend WithEvents Cms_Ordenar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OrdenarPorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_BuscarOC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HablitarImpresionRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HabilitarImpresionOC As NetBarControl.NetBarItem
    Friend WithEvents CancelarCantidadItemToolStripMenuItemRQ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbg_Factura As NetBarControl.NetBarGroup
    Friend WithEvents Cms_Facturas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminarFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_RegistrarFactura As NetBarControl.NetBarItem
    Friend WithEvents Nbi_RelFactura As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerFacturas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarRelaciónFacturas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearRelaciónFacturas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarRelaciónFacturas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirRelación As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HabilitarImpresionRelacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarRelaciónFacturasTodas As NetBarControl.NetBarItem
    Friend WithEvents Pn_Propiedades As System.Windows.Forms.Panel
    Friend WithEvents Pn_Suministros As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Suministros As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ChB_MostrarSuministros As System.Windows.Forms.CheckBox
    Friend WithEvents Nbi_BuscarPorSuministro As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BucarXArticulo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CopiarRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CopiarOC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarXarticuloRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BucarProveedor As NetBarControl.NetBarItem
    Friend WithEvents CopiarIdentificaciónDocumentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_BucarXCiudad As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CambiarTipoStock As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EnviarCorreosOCSinFacturaAsociada As NetBarControl.NetBarItem
    Friend WithEvents Nbg_SolicitudMaquinaria As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CargarSolicitud As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearSolicitud As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerSolicitud As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarSolicitud As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirSolicitud As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarSolicitud As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ConvertirA_Rq As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirComplementoRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbi_PendienteRQxUsers As NetBarControl.NetBarItem
    Friend WithEvents Nb_PendienteOCxEAxUser As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CopiarRQxCotizar As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VistoBuenoGerencia As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirPDFVbG As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerPDFVbG As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerEAxOC As NetBarControl.NetBarItem
    Friend WithEvents Cms_EAxOC As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopiarDocumentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_BuscarxArticulo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_DistribuirCostos As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirOC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerPdfOC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirPdfRelacionFactura As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerPdfRelacionFactura As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirPdfBloqueOC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirPdfBloqueRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirPdfBloqueRF As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HistorialArchivosFactura As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HistorialArchivosPdfRQ As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HistorialArchivosPdfOC As NetBarControl.NetBarItem

End Class
