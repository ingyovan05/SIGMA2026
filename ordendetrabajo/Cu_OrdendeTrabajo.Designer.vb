<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_OrdendeTrabajo
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
        Me.Nbc_OrdenesDeTrabajo = New NetBarControl.NetBarControl()
        Me.Nbg_ExportarExcel = New NetBarControl.NetBarGroup()
        Me.Nbi_OM = New NetBarControl.NetBarItem()
        Me.Nbi_ReporteDiarioxOM = New NetBarControl.NetBarItem()
        Me.Nbi_SabanaFacturacionOM = New NetBarControl.NetBarItem()
        Me.Nbi_ResumenFacturacion = New NetBarControl.NetBarItem()
        Me.Nbi_AnalisisComparativoxOMs = New NetBarControl.NetBarItem()
        Me.Nbi_Informe246 = New NetBarControl.NetBarItem()
        Me.Nbg_OrdenTrabajo = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarOT = New NetBarControl.NetBarItem()
        Me.Nbi_CrearOT = New NetBarControl.NetBarItem()
        Me.Nbi_VerOT = New NetBarControl.NetBarItem()
        Me.Nbi_ClonarOT = New NetBarControl.NetBarItem()
        Me.Nbi_ModificarOT = New NetBarControl.NetBarItem()
        Me.Nbi_CambiarEstado = New NetBarControl.NetBarItem()
        Me.Nbi_CambiarEstadoSAP = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarOT = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarOT_Portapapeles = New NetBarControl.NetBarItem()
        Me.NetBarItem1 = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirOT = New NetBarControl.NetBarItem()
        Me.Nbi_ImprAnalisisComparativo = New NetBarControl.NetBarItem()
        Me.Nbi_ImprAnalisisComparativoxServicio = New NetBarControl.NetBarItem()
        Me.Nbi_ImprObraEjecutadaxOM = New NetBarControl.NetBarItem()
        Me.Nbi_ImprObraEjecutadaxOMEntreFechas = New NetBarControl.NetBarItem()
        Me.Nbg_MaterialNoConforme = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarMNC = New NetBarControl.NetBarItem()
        Me.Nbi_CrearMNC = New NetBarControl.NetBarItem()
        Me.Nbi_EditarMNC = New NetBarControl.NetBarItem()
        Me.Nbi_VerMNC = New NetBarControl.NetBarItem()
        Me.Nbi_AnularMNC = New NetBarControl.NetBarItem()
        Me.Nbi_CerrarMNC = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarMNC = New NetBarControl.NetBarItem()
        Me.Nbg_NoConformidad = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarNC = New NetBarControl.NetBarItem()
        Me.Nbi_CrearNC = New NetBarControl.NetBarItem()
        Me.Nbi_EditarNC = New NetBarControl.NetBarItem()
        Me.Nbi_VerNC = New NetBarControl.NetBarItem()
        Me.Nbi_AnularNC = New NetBarControl.NetBarItem()
        Me.Nbi_CerrarNC = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarNC = New NetBarControl.NetBarItem()
        Me.Nbg_IntervencionDirecta = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarID = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarID = New NetBarControl.NetBarItem()
        Me.Nbg_ObrasSobreDDV = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarOSDDV = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarOSDDV = New NetBarControl.NetBarItem()
        Me.Nbg_Valvulas = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarV = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarV = New NetBarControl.NetBarItem()
        Me.Nbg_URPC = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarURPC = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarURPC = New NetBarControl.NetBarItem()
        Me.Nbg_VariablesMantenimiento = New NetBarControl.NetBarGroup()
        Me.Nbi_Graficar = New NetBarControl.NetBarItem()
        Me.Nbg_DefectologiaXSoldador = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarDS = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarDS = New NetBarControl.NetBarItem()
        Me.Nbg_TablerosTBG = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarTBG = New NetBarControl.NetBarItem()
        Me.Nbi_CrearTBG = New NetBarControl.NetBarItem()
        Me.Nbi_EditarTBG = New NetBarControl.NetBarItem()
        Me.Nbi_VerTBG = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarTBG = New NetBarControl.NetBarItem()
        Me.Nbg_PlanDeOptimizacion = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarPlanesOptimizacion = New NetBarControl.NetBarItem()
        Me.Nbi_CrearPlanOptimizacion = New NetBarControl.NetBarItem()
        Me.Nbi_EditarPlanOptimizacion = New NetBarControl.NetBarItem()
        Me.Nbi_VerPlanOptimizacion = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarPlanesOptimizacion = New NetBarControl.NetBarItem()
        Me.Pn_CantidadOrdenTrabajo = New System.Windows.Forms.Panel()
        Me.Lb_CantidadOrdenTrabajo = New System.Windows.Forms.Label()
        Me.Dgv_ListaOrdenTrabajo = New System.Windows.Forms.DataGridView()
        Me.Cms_CambioEstado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_CambiarEstadoOT = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sc_Listado = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Dgv_ListaServicios = New System.Windows.Forms.DataGridView()
        Me.Pn_CantidadServicios = New System.Windows.Forms.Panel()
        Me.Lb_CantidadServicios = New System.Windows.Forms.Label()
        Me.Pg_Propiedades = New System.Windows.Forms.PropertyGrid()
        Me.Pn_Propiedades = New System.Windows.Forms.Panel()
        Me.Lb_Propiedades = New System.Windows.Forms.Label()
        Me.NetBarItem2 = New NetBarControl.NetBarItem()
        Me.Ds_Informe1 = New Informe.Ds_Informe()
        Me.Pn_CantidadOrdenTrabajo.SuspendLayout()
        CType(Me.Dgv_ListaOrdenTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_CambioEstado.SuspendLayout()
        CType(Me.Sc_Listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sc_Listado.Panel1.SuspendLayout()
        Me.Sc_Listado.Panel2.SuspendLayout()
        Me.Sc_Listado.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Dgv_ListaServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_CantidadServicios.SuspendLayout()
        Me.Pn_Propiedades.SuspendLayout()
        CType(Me.Ds_Informe1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Nbc_OrdenesDeTrabajo
        '
        Me.Nbc_OrdenesDeTrabajo.ActiveGroup = Me.Nbg_ExportarExcel
        Me.Nbc_OrdenesDeTrabajo.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_OrdenesDeTrabajo.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_OrdenTrabajo, Me.Nbg_ExportarExcel, Me.Nbg_MaterialNoConforme, Me.Nbg_NoConformidad, Me.Nbg_IntervencionDirecta, Me.Nbg_ObrasSobreDDV, Me.Nbg_Valvulas, Me.Nbg_URPC, Me.Nbg_VariablesMantenimiento, Me.Nbg_DefectologiaXSoldador, Me.Nbg_TablerosTBG, Me.Nbg_PlanDeOptimizacion})
        Me.Nbc_OrdenesDeTrabajo.GroupsFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_OrdenesDeTrabajo.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_OrdenesDeTrabajo.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_OrdenesDeTrabajo.Location = New System.Drawing.Point(0, 0)
        Me.Nbc_OrdenesDeTrabajo.Name = "Nbc_OrdenesDeTrabajo"
        Me.Nbc_OrdenesDeTrabajo.ShowOverflowButton = False
        Me.Nbc_OrdenesDeTrabajo.ShowOverflowPanel = False
        Me.Nbc_OrdenesDeTrabajo.Size = New System.Drawing.Size(232, 600)
        Me.Nbc_OrdenesDeTrabajo.TabIndex = 0
        Me.Nbc_OrdenesDeTrabajo.Tag = ""
        Me.Nbc_OrdenesDeTrabajo.Text = "Órdenes de Trabajo"
        '
        'Nbg_ExportarExcel
        '
        Me.Nbg_ExportarExcel.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_OM, Me.Nbi_ReporteDiarioxOM, Me.Nbi_SabanaFacturacionOM, Me.Nbi_ResumenFacturacion, Me.Nbi_AnalisisComparativoxOMs, Me.Nbi_Informe246})
        Me.Nbg_ExportarExcel.Name = "Nbg_ExportarExcel"
        Me.Nbg_ExportarExcel.Tag = "725"
        Me.Nbg_ExportarExcel.Text = "Exportar Excel"
        '
        'Nbi_OM
        '
        Me.Nbi_OM.Name = "Nbi_OM"
        Me.Nbi_OM.Tag = "727"
        Me.Nbi_OM.Text = "Resumen OM's Programada"
        '
        'Nbi_ReporteDiarioxOM
        '
        Me.Nbi_ReporteDiarioxOM.Name = "Nbi_ReporteDiarioxOM"
        Me.Nbi_ReporteDiarioxOM.Tag = "726"
        Me.Nbi_ReporteDiarioxOM.Text = "Reporte Diario x OM's"
        '
        'Nbi_SabanaFacturacionOM
        '
        Me.Nbi_SabanaFacturacionOM.Name = "Nbi_SabanaFacturacionOM"
        Me.Nbi_SabanaFacturacionOM.Tag = "749"
        Me.Nbi_SabanaFacturacionOM.Text = "Sabana de Facturación x OM's"
        '
        'Nbi_ResumenFacturacion
        '
        Me.Nbi_ResumenFacturacion.Name = "Nbi_ResumenFacturacion"
        Me.Nbi_ResumenFacturacion.Tag = "727"
        Me.Nbi_ResumenFacturacion.Text = "Resumen Facturación x OM's"
        '
        'Nbi_AnalisisComparativoxOMs
        '
        Me.Nbi_AnalisisComparativoxOMs.Name = "Nbi_AnalisisComparativoxOMs"
        Me.Nbi_AnalisisComparativoxOMs.Tag = "728"
        Me.Nbi_AnalisisComparativoxOMs.Text = "Análisis Comparativo x OM's"
        '
        'Nbi_Informe246
        '
        Me.Nbi_Informe246.Name = "Nbi_Informe246"
        Me.Nbi_Informe246.Tag = "1024"
        Me.Nbi_Informe246.Text = "Informe 246 x OM´s"
        '
        'Nbg_OrdenTrabajo
        '
        Me.Nbg_OrdenTrabajo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbg_OrdenTrabajo.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarOT, Me.Nbi_CrearOT, Me.Nbi_VerOT, Me.Nbi_ClonarOT, Me.Nbi_ModificarOT, Me.Nbi_CambiarEstado, Me.Nbi_CambiarEstadoSAP, Me.Nbi_BuscarOT, Me.Nbi_BuscarOT_Portapapeles, Me.NetBarItem1, Me.Nbi_ImprimirOT, Me.Nbi_ImprAnalisisComparativo, Me.Nbi_ImprAnalisisComparativoxServicio, Me.Nbi_ImprObraEjecutadaxOM, Me.Nbi_ImprObraEjecutadaxOMEntreFechas})
        Me.Nbg_OrdenTrabajo.Name = "Nbg_OrdenTrabajo"
        Me.Nbg_OrdenTrabajo.Tag = "673"
        Me.Nbg_OrdenTrabajo.Text = "Orden Mantenimiento SAP"
        '
        'Nbi_ListarOT
        '
        Me.Nbi_ListarOT.Name = "Nbi_ListarOT"
        Me.Nbi_ListarOT.Tag = "708"
        Me.Nbi_ListarOT.Text = "Cargar OM´s"
        '
        'Nbi_CrearOT
        '
        Me.Nbi_CrearOT.Name = "Nbi_CrearOT"
        Me.Nbi_CrearOT.Tag = "674"
        Me.Nbi_CrearOT.Text = "Crear OM"
        '
        'Nbi_VerOT
        '
        Me.Nbi_VerOT.Name = "Nbi_VerOT"
        Me.Nbi_VerOT.Tag = "764"
        Me.Nbi_VerOT.Text = "Ver OM"
        '
        'Nbi_ClonarOT
        '
        Me.Nbi_ClonarOT.Name = "Nbi_ClonarOT"
        Me.Nbi_ClonarOT.Tag = "674"
        Me.Nbi_ClonarOT.Text = "Clonar OM"
        '
        'Nbi_ModificarOT
        '
        Me.Nbi_ModificarOT.Name = "Nbi_ModificarOT"
        Me.Nbi_ModificarOT.Tag = "675"
        Me.Nbi_ModificarOT.Text = "Editar OM"
        '
        'Nbi_CambiarEstado
        '
        Me.Nbi_CambiarEstado.Name = "Nbi_CambiarEstado"
        Me.Nbi_CambiarEstado.Tag = "709"
        Me.Nbi_CambiarEstado.Text = "Cambiar Estado OM SIGMA"
        '
        'Nbi_CambiarEstadoSAP
        '
        Me.Nbi_CambiarEstadoSAP.Name = "Nbi_CambiarEstadoSAP"
        Me.Nbi_CambiarEstadoSAP.Tag = "769"
        Me.Nbi_CambiarEstadoSAP.Text = "Cambiar Estado OM SAP"
        '
        'Nbi_BuscarOT
        '
        Me.Nbi_BuscarOT.Name = "Nbi_BuscarOT"
        Me.Nbi_BuscarOT.Tag = "710"
        Me.Nbi_BuscarOT.Text = "Buscar OM"
        '
        'Nbi_BuscarOT_Portapapeles
        '
        Me.Nbi_BuscarOT_Portapapeles.Name = "Nbi_BuscarOT_Portapapeles"
        Me.Nbi_BuscarOT_Portapapeles.Tag = "710"
        Me.Nbi_BuscarOT_Portapapeles.Text = "Buscar OM Portapapeles"
        '
        'NetBarItem1
        '
        Me.NetBarItem1.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NetBarItem1.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.NetBarItem1.Name = "NetBarItem1"
        Me.NetBarItem1.Text = "----------------------------"
        '
        'Nbi_ImprimirOT
        '
        Me.Nbi_ImprimirOT.Name = "Nbi_ImprimirOT"
        Me.Nbi_ImprimirOT.Tag = "676"
        Me.Nbi_ImprimirOT.Text = "Imprimir OM's"
        '
        'Nbi_ImprAnalisisComparativo
        '
        Me.Nbi_ImprAnalisisComparativo.Name = "Nbi_ImprAnalisisComparativo"
        Me.Nbi_ImprAnalisisComparativo.Tag = "728"
        Me.Nbi_ImprAnalisisComparativo.Text = "Imprimir Análisis Comparativo x OM"
        '
        'Nbi_ImprAnalisisComparativoxServicio
        '
        Me.Nbi_ImprAnalisisComparativoxServicio.Name = "Nbi_ImprAnalisisComparativoxServicio"
        Me.Nbi_ImprAnalisisComparativoxServicio.Tag = "728"
        Me.Nbi_ImprAnalisisComparativoxServicio.Text = "Imprimir Análisis Comparativo x Servicio"
        '
        'Nbi_ImprObraEjecutadaxOM
        '
        Me.Nbi_ImprObraEjecutadaxOM.Name = "Nbi_ImprObraEjecutadaxOM"
        Me.Nbi_ImprObraEjecutadaxOM.Tag = "729"
        Me.Nbi_ImprObraEjecutadaxOM.Text = "Imprimir Obra Ejecutada x OM"
        '
        'Nbi_ImprObraEjecutadaxOMEntreFechas
        '
        Me.Nbi_ImprObraEjecutadaxOMEntreFechas.Name = "Nbi_ImprObraEjecutadaxOMEntreFechas"
        Me.Nbi_ImprObraEjecutadaxOMEntreFechas.Text = "Imp. Obra Ejec. x OM Entre Fechas"
        Me.Nbi_ImprObraEjecutadaxOMEntreFechas.Visible = False
        '
        'Nbg_MaterialNoConforme
        '
        Me.Nbg_MaterialNoConforme.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarMNC, Me.Nbi_CrearMNC, Me.Nbi_EditarMNC, Me.Nbi_VerMNC, Me.Nbi_AnularMNC, Me.Nbi_CerrarMNC, Me.Nbi_BuscarMNC})
        Me.Nbg_MaterialNoConforme.Name = "Nbg_MaterialNoConforme"
        Me.Nbg_MaterialNoConforme.Tag = "794"
        Me.Nbg_MaterialNoConforme.Text = "Material No Conforme"
        '
        'Nbi_ListarMNC
        '
        Me.Nbi_ListarMNC.Name = "Nbi_ListarMNC"
        Me.Nbi_ListarMNC.Tag = "795"
        Me.Nbi_ListarMNC.Text = "Cargar Listado"
        '
        'Nbi_CrearMNC
        '
        Me.Nbi_CrearMNC.Name = "Nbi_CrearMNC"
        Me.Nbi_CrearMNC.Tag = "796"
        Me.Nbi_CrearMNC.Text = "Registrar Material No Conforme"
        '
        'Nbi_EditarMNC
        '
        Me.Nbi_EditarMNC.Name = "Nbi_EditarMNC"
        Me.Nbi_EditarMNC.Tag = "797"
        Me.Nbi_EditarMNC.Text = "Editar"
        '
        'Nbi_VerMNC
        '
        Me.Nbi_VerMNC.Name = "Nbi_VerMNC"
        Me.Nbi_VerMNC.Tag = "798"
        Me.Nbi_VerMNC.Text = "Ver"
        '
        'Nbi_AnularMNC
        '
        Me.Nbi_AnularMNC.Name = "Nbi_AnularMNC"
        Me.Nbi_AnularMNC.Tag = "799"
        Me.Nbi_AnularMNC.Text = "Anular"
        '
        'Nbi_CerrarMNC
        '
        Me.Nbi_CerrarMNC.Name = "Nbi_CerrarMNC"
        Me.Nbi_CerrarMNC.Tag = "800"
        Me.Nbi_CerrarMNC.Text = "Registrar Cierre"
        '
        'Nbi_BuscarMNC
        '
        Me.Nbi_BuscarMNC.Name = "Nbi_BuscarMNC"
        Me.Nbi_BuscarMNC.Tag = "801"
        Me.Nbi_BuscarMNC.Text = "Buscar"
        '
        'Nbg_NoConformidad
        '
        Me.Nbg_NoConformidad.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarNC, Me.Nbi_CrearNC, Me.Nbi_EditarNC, Me.Nbi_VerNC, Me.Nbi_AnularNC, Me.Nbi_CerrarNC, Me.Nbi_BuscarNC})
        Me.Nbg_NoConformidad.Name = "Nbg_NoConformidad"
        Me.Nbg_NoConformidad.Tag = "802"
        Me.Nbg_NoConformidad.Text = "No Conformidad"
        '
        'Nbi_ListarNC
        '
        Me.Nbi_ListarNC.Name = "Nbi_ListarNC"
        Me.Nbi_ListarNC.Tag = "803"
        Me.Nbi_ListarNC.Text = "Cargar Listado"
        '
        'Nbi_CrearNC
        '
        Me.Nbi_CrearNC.Name = "Nbi_CrearNC"
        Me.Nbi_CrearNC.Tag = "804"
        Me.Nbi_CrearNC.Text = "Registrar No Conformidad"
        '
        'Nbi_EditarNC
        '
        Me.Nbi_EditarNC.Name = "Nbi_EditarNC"
        Me.Nbi_EditarNC.Tag = "805"
        Me.Nbi_EditarNC.Text = "Editar"
        '
        'Nbi_VerNC
        '
        Me.Nbi_VerNC.Name = "Nbi_VerNC"
        Me.Nbi_VerNC.Tag = "806"
        Me.Nbi_VerNC.Text = "Ver"
        '
        'Nbi_AnularNC
        '
        Me.Nbi_AnularNC.Name = "Nbi_AnularNC"
        Me.Nbi_AnularNC.Tag = "807"
        Me.Nbi_AnularNC.Text = "Anular"
        '
        'Nbi_CerrarNC
        '
        Me.Nbi_CerrarNC.Name = "Nbi_CerrarNC"
        Me.Nbi_CerrarNC.Tag = "808"
        Me.Nbi_CerrarNC.Text = "Registrar Cierre"
        '
        'Nbi_BuscarNC
        '
        Me.Nbi_BuscarNC.Name = "Nbi_BuscarNC"
        Me.Nbi_BuscarNC.Tag = "809"
        Me.Nbi_BuscarNC.Text = "Buscar"
        '
        'Nbg_IntervencionDirecta
        '
        Me.Nbg_IntervencionDirecta.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarID, Me.Nbi_BuscarID})
        Me.Nbg_IntervencionDirecta.Name = "Nbg_IntervencionDirecta"
        Me.Nbg_IntervencionDirecta.Tag = "810"
        Me.Nbg_IntervencionDirecta.Text = "Intervención Directa"
        '
        'Nbi_ListarID
        '
        Me.Nbi_ListarID.Name = "Nbi_ListarID"
        Me.Nbi_ListarID.Tag = "811"
        Me.Nbi_ListarID.Text = "Cargar Listado"
        '
        'Nbi_BuscarID
        '
        Me.Nbi_BuscarID.Name = "Nbi_BuscarID"
        Me.Nbi_BuscarID.Tag = "812"
        Me.Nbi_BuscarID.Text = "Buscar"
        '
        'Nbg_ObrasSobreDDV
        '
        Me.Nbg_ObrasSobreDDV.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarOSDDV, Me.Nbi_BuscarOSDDV})
        Me.Nbg_ObrasSobreDDV.Name = "Nbg_ObrasSobreDDV"
        Me.Nbg_ObrasSobreDDV.Tag = "813"
        Me.Nbg_ObrasSobreDDV.Text = "Obras Sobre DDV"
        '
        'Nbi_ListarOSDDV
        '
        Me.Nbi_ListarOSDDV.Name = "Nbi_ListarOSDDV"
        Me.Nbi_ListarOSDDV.Tag = "814"
        Me.Nbi_ListarOSDDV.Text = "Cargar Listado"
        '
        'Nbi_BuscarOSDDV
        '
        Me.Nbi_BuscarOSDDV.Name = "Nbi_BuscarOSDDV"
        Me.Nbi_BuscarOSDDV.Tag = "815"
        Me.Nbi_BuscarOSDDV.Text = "Buscar"
        '
        'Nbg_Valvulas
        '
        Me.Nbg_Valvulas.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarV, Me.Nbi_BuscarV})
        Me.Nbg_Valvulas.Name = "Nbg_Valvulas"
        Me.Nbg_Valvulas.Tag = "816"
        Me.Nbg_Valvulas.Text = "Válvulas"
        '
        'Nbi_ListarV
        '
        Me.Nbi_ListarV.Name = "Nbi_ListarV"
        Me.Nbi_ListarV.Tag = "817"
        Me.Nbi_ListarV.Text = "Cargar Listado"
        '
        'Nbi_BuscarV
        '
        Me.Nbi_BuscarV.Name = "Nbi_BuscarV"
        Me.Nbi_BuscarV.Tag = "818"
        Me.Nbi_BuscarV.Text = "Buscar"
        '
        'Nbg_URPC
        '
        Me.Nbg_URPC.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarURPC, Me.Nbi_BuscarURPC})
        Me.Nbg_URPC.Name = "Nbg_URPC"
        Me.Nbg_URPC.Tag = "819"
        Me.Nbg_URPC.Text = "URPC"
        '
        'Nbi_ListarURPC
        '
        Me.Nbi_ListarURPC.Name = "Nbi_ListarURPC"
        Me.Nbi_ListarURPC.Tag = "820"
        Me.Nbi_ListarURPC.Text = "Cargar Listado"
        '
        'Nbi_BuscarURPC
        '
        Me.Nbi_BuscarURPC.Name = "Nbi_BuscarURPC"
        Me.Nbi_BuscarURPC.Tag = "821"
        Me.Nbi_BuscarURPC.Text = "Buscar"
        '
        'Nbg_VariablesMantenimiento
        '
        Me.Nbg_VariablesMantenimiento.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_Graficar})
        Me.Nbg_VariablesMantenimiento.Name = "Nbg_VariablesMantenimiento"
        Me.Nbg_VariablesMantenimiento.Tag = "822"
        Me.Nbg_VariablesMantenimiento.Text = "Variables Mantenimiento"
        '
        'Nbi_Graficar
        '
        Me.Nbi_Graficar.Name = "Nbi_Graficar"
        Me.Nbi_Graficar.Text = "Graficar Variables Mantenimiento"
        '
        'Nbg_DefectologiaXSoldador
        '
        Me.Nbg_DefectologiaXSoldador.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarDS, Me.Nbi_BuscarDS})
        Me.Nbg_DefectologiaXSoldador.Name = "Nbg_DefectologiaXSoldador"
        Me.Nbg_DefectologiaXSoldador.Tag = "824"
        Me.Nbg_DefectologiaXSoldador.Text = "Defectología Por Soldador"
        '
        'Nbi_ListarDS
        '
        Me.Nbi_ListarDS.Name = "Nbi_ListarDS"
        Me.Nbi_ListarDS.Tag = "825"
        Me.Nbi_ListarDS.Text = "Cargar Listado"
        '
        'Nbi_BuscarDS
        '
        Me.Nbi_BuscarDS.Name = "Nbi_BuscarDS"
        Me.Nbi_BuscarDS.Tag = "826"
        Me.Nbi_BuscarDS.Text = "Buscar"
        '
        'Nbg_TablerosTBG
        '
        Me.Nbg_TablerosTBG.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarTBG, Me.Nbi_CrearTBG, Me.Nbi_EditarTBG, Me.Nbi_VerTBG, Me.Nbi_BuscarTBG})
        Me.Nbg_TablerosTBG.Name = "Nbg_TablerosTBG"
        Me.Nbg_TablerosTBG.Tag = "827"
        Me.Nbg_TablerosTBG.Text = "Tableros TBG"
        '
        'Nbi_CargarTBG
        '
        Me.Nbi_CargarTBG.Name = "Nbi_CargarTBG"
        Me.Nbi_CargarTBG.Tag = "828"
        Me.Nbi_CargarTBG.Text = "Cargar Listado"
        '
        'Nbi_CrearTBG
        '
        Me.Nbi_CrearTBG.Name = "Nbi_CrearTBG"
        Me.Nbi_CrearTBG.Tag = "829"
        Me.Nbi_CrearTBG.Text = "Crear TBG"
        '
        'Nbi_EditarTBG
        '
        Me.Nbi_EditarTBG.Name = "Nbi_EditarTBG"
        Me.Nbi_EditarTBG.Tag = "831"
        Me.Nbi_EditarTBG.Text = "Editar"
        '
        'Nbi_VerTBG
        '
        Me.Nbi_VerTBG.Name = "Nbi_VerTBG"
        Me.Nbi_VerTBG.Tag = "832"
        Me.Nbi_VerTBG.Text = "Ver"
        '
        'Nbi_BuscarTBG
        '
        Me.Nbi_BuscarTBG.Name = "Nbi_BuscarTBG"
        Me.Nbi_BuscarTBG.Tag = "830"
        Me.Nbi_BuscarTBG.Text = "Buscar"
        '
        'Nbg_PlanDeOptimizacion
        '
        Me.Nbg_PlanDeOptimizacion.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarPlanesOptimizacion, Me.Nbi_CrearPlanOptimizacion, Me.Nbi_EditarPlanOptimizacion, Me.Nbi_VerPlanOptimizacion, Me.Nbi_BuscarPlanesOptimizacion})
        Me.Nbg_PlanDeOptimizacion.Name = "Nbg_PlanDeOptimizacion"
        Me.Nbg_PlanDeOptimizacion.Tag = "833"
        Me.Nbg_PlanDeOptimizacion.Text = "Plan de Optimización"
        '
        'Nbi_ListarPlanesOptimizacion
        '
        Me.Nbi_ListarPlanesOptimizacion.Name = "Nbi_ListarPlanesOptimizacion"
        Me.Nbi_ListarPlanesOptimizacion.Tag = "834"
        Me.Nbi_ListarPlanesOptimizacion.Text = "Listar"
        '
        'Nbi_CrearPlanOptimizacion
        '
        Me.Nbi_CrearPlanOptimizacion.Name = "Nbi_CrearPlanOptimizacion"
        Me.Nbi_CrearPlanOptimizacion.Tag = "835"
        Me.Nbi_CrearPlanOptimizacion.Text = "Crear"
        '
        'Nbi_EditarPlanOptimizacion
        '
        Me.Nbi_EditarPlanOptimizacion.Name = "Nbi_EditarPlanOptimizacion"
        Me.Nbi_EditarPlanOptimizacion.Tag = "836"
        Me.Nbi_EditarPlanOptimizacion.Text = "Editar"
        '
        'Nbi_VerPlanOptimizacion
        '
        Me.Nbi_VerPlanOptimizacion.Name = "Nbi_VerPlanOptimizacion"
        Me.Nbi_VerPlanOptimizacion.Tag = "837"
        Me.Nbi_VerPlanOptimizacion.Text = "Ver"
        '
        'Nbi_BuscarPlanesOptimizacion
        '
        Me.Nbi_BuscarPlanesOptimizacion.Name = "Nbi_BuscarPlanesOptimizacion"
        Me.Nbi_BuscarPlanesOptimizacion.Tag = "838"
        Me.Nbi_BuscarPlanesOptimizacion.Text = "Buscar"
        '
        'Pn_CantidadOrdenTrabajo
        '
        Me.Pn_CantidadOrdenTrabajo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_CantidadOrdenTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_CantidadOrdenTrabajo.Controls.Add(Me.Lb_CantidadOrdenTrabajo)
        Me.Pn_CantidadOrdenTrabajo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_CantidadOrdenTrabajo.Location = New System.Drawing.Point(0, 0)
        Me.Pn_CantidadOrdenTrabajo.Name = "Pn_CantidadOrdenTrabajo"
        Me.Pn_CantidadOrdenTrabajo.Size = New System.Drawing.Size(540, 23)
        Me.Pn_CantidadOrdenTrabajo.TabIndex = 1
        '
        'Lb_CantidadOrdenTrabajo
        '
        Me.Lb_CantidadOrdenTrabajo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_CantidadOrdenTrabajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadOrdenTrabajo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CantidadOrdenTrabajo.Name = "Lb_CantidadOrdenTrabajo"
        Me.Lb_CantidadOrdenTrabajo.Size = New System.Drawing.Size(538, 23)
        Me.Lb_CantidadOrdenTrabajo.TabIndex = 0
        Me.Lb_CantidadOrdenTrabajo.Text = "Cantidad de Órdenes de Trabajo:"
        Me.Lb_CantidadOrdenTrabajo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Dgv_ListaOrdenTrabajo
        '
        Me.Dgv_ListaOrdenTrabajo.AllowUserToAddRows = False
        Me.Dgv_ListaOrdenTrabajo.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_ListaOrdenTrabajo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_ListaOrdenTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_ListaOrdenTrabajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_ListaOrdenTrabajo.ContextMenuStrip = Me.Cms_CambioEstado
        Me.Dgv_ListaOrdenTrabajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaOrdenTrabajo.Location = New System.Drawing.Point(0, 23)
        Me.Dgv_ListaOrdenTrabajo.Name = "Dgv_ListaOrdenTrabajo"
        Me.Dgv_ListaOrdenTrabajo.ReadOnly = True
        Me.Dgv_ListaOrdenTrabajo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_ListaOrdenTrabajo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_ListaOrdenTrabajo.Size = New System.Drawing.Size(540, 356)
        Me.Dgv_ListaOrdenTrabajo.TabIndex = 0
        '
        'Cms_CambioEstado
        '
        Me.Cms_CambioEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_CambioEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_CambiarEstadoOT})
        Me.Cms_CambioEstado.Name = "Cms_CambioEstado"
        Me.Cms_CambioEstado.Size = New System.Drawing.Size(203, 26)
        Me.Cms_CambioEstado.Tag = "418"
        '
        'Tsmi_CambiarEstadoOT
        '
        Me.Tsmi_CambiarEstadoOT.Name = "Tsmi_CambiarEstadoOT"
        Me.Tsmi_CambiarEstadoOT.Size = New System.Drawing.Size(202, 22)
        Me.Tsmi_CambiarEstadoOT.Text = "Cambiar estado de la OT"
        '
        'Sc_Listado
        '
        Me.Sc_Listado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sc_Listado.Location = New System.Drawing.Point(232, 0)
        Me.Sc_Listado.Name = "Sc_Listado"
        '
        'Sc_Listado.Panel1
        '
        Me.Sc_Listado.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'Sc_Listado.Panel2
        '
        Me.Sc_Listado.Panel2.Controls.Add(Me.Pg_Propiedades)
        Me.Sc_Listado.Panel2.Controls.Add(Me.Pn_Propiedades)
        Me.Sc_Listado.Size = New System.Drawing.Size(792, 600)
        Me.Sc_Listado.SplitterDistance = 540
        Me.Sc_Listado.TabIndex = 2
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Dgv_ListaOrdenTrabajo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Pn_CantidadOrdenTrabajo)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Dgv_ListaServicios)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Pn_CantidadServicios)
        Me.SplitContainer1.Size = New System.Drawing.Size(540, 600)
        Me.SplitContainer1.SplitterDistance = 379
        Me.SplitContainer1.TabIndex = 24
        '
        'Dgv_ListaServicios
        '
        Me.Dgv_ListaServicios.AllowUserToAddRows = False
        Me.Dgv_ListaServicios.AllowUserToDeleteRows = False
        Me.Dgv_ListaServicios.AllowUserToOrderColumns = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Dgv_ListaServicios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_ListaServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ListaServicios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaServicios.Location = New System.Drawing.Point(0, 23)
        Me.Dgv_ListaServicios.Name = "Dgv_ListaServicios"
        Me.Dgv_ListaServicios.ReadOnly = True
        Me.Dgv_ListaServicios.Size = New System.Drawing.Size(540, 194)
        Me.Dgv_ListaServicios.TabIndex = 1
        '
        'Pn_CantidadServicios
        '
        Me.Pn_CantidadServicios.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_CantidadServicios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_CantidadServicios.Controls.Add(Me.Lb_CantidadServicios)
        Me.Pn_CantidadServicios.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_CantidadServicios.Location = New System.Drawing.Point(0, 0)
        Me.Pn_CantidadServicios.Name = "Pn_CantidadServicios"
        Me.Pn_CantidadServicios.Size = New System.Drawing.Size(540, 23)
        Me.Pn_CantidadServicios.TabIndex = 23
        '
        'Lb_CantidadServicios
        '
        Me.Lb_CantidadServicios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_CantidadServicios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadServicios.Location = New System.Drawing.Point(1, 0)
        Me.Lb_CantidadServicios.Name = "Lb_CantidadServicios"
        Me.Lb_CantidadServicios.Size = New System.Drawing.Size(538, 23)
        Me.Lb_CantidadServicios.TabIndex = 0
        Me.Lb_CantidadServicios.Text = "Cantidad  de Servicios de OT:"
        Me.Lb_CantidadServicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pg_Propiedades
        '
        Me.Pg_Propiedades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pg_Propiedades.Location = New System.Drawing.Point(0, 23)
        Me.Pg_Propiedades.Name = "Pg_Propiedades"
        Me.Pg_Propiedades.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.Pg_Propiedades.Size = New System.Drawing.Size(248, 577)
        Me.Pg_Propiedades.TabIndex = 21
        '
        'Pn_Propiedades
        '
        Me.Pn_Propiedades.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_Propiedades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Propiedades.Controls.Add(Me.Lb_Propiedades)
        Me.Pn_Propiedades.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Propiedades.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Propiedades.Name = "Pn_Propiedades"
        Me.Pn_Propiedades.Size = New System.Drawing.Size(248, 23)
        Me.Pn_Propiedades.TabIndex = 22
        '
        'Lb_Propiedades
        '
        Me.Lb_Propiedades.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_Propiedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Propiedades.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Propiedades.Name = "Lb_Propiedades"
        Me.Lb_Propiedades.Size = New System.Drawing.Size(246, 23)
        Me.Lb_Propiedades.TabIndex = 0
        Me.Lb_Propiedades.Text = "Propiedades"
        Me.Lb_Propiedades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NetBarItem2
        '
        Me.NetBarItem2.Name = "NetBarItem2"
        Me.NetBarItem2.Tag = "728"
        Me.NetBarItem2.Text = "Imprimir Análisis Comparativo"
        '
        'Ds_Informe1
        '
        Me.Ds_Informe1.DataSetName = "Ds_Informe"
        Me.Ds_Informe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Cu_OrdendeTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Sc_Listado)
        Me.Controls.Add(Me.Nbc_OrdenesDeTrabajo)
        Me.Name = "Cu_OrdendeTrabajo"
        Me.Size = New System.Drawing.Size(1024, 600)
        Me.Pn_CantidadOrdenTrabajo.ResumeLayout(False)
        CType(Me.Dgv_ListaOrdenTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_CambioEstado.ResumeLayout(False)
        Me.Sc_Listado.Panel1.ResumeLayout(False)
        Me.Sc_Listado.Panel2.ResumeLayout(False)
        CType(Me.Sc_Listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_Listado.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Dgv_ListaServicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_CantidadServicios.ResumeLayout(False)
        Me.Pn_Propiedades.ResumeLayout(False)
        CType(Me.Ds_Informe1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Nbc_OrdenesDeTrabajo As NetBarControl.NetBarControl
    Friend WithEvents Pn_CantidadOrdenTrabajo As System.Windows.Forms.Panel
    Friend WithEvents NUMEROOTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JUSTIFICACIONOTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAINICIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAFINDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLAZODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SISTEMADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sc_Listado As System.Windows.Forms.SplitContainer
    Friend WithEvents Pg_Propiedades As System.Windows.Forms.PropertyGrid
    Friend WithEvents Lb_CantidadOrdenTrabajo As System.Windows.Forms.Label
    Friend WithEvents Nbg_OrdenTrabajo As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CrearOT As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ModificarOT As NetBarControl.NetBarItem
    Friend WithEvents Cms_CambioEstado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_CambiarEstadoOT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_ImprimirOT As NetBarControl.NetBarItem
    Friend WithEvents Dgv_ListaOrdenTrabajo As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Propiedades As System.Windows.Forms.Panel
    Friend WithEvents Lb_Propiedades As System.Windows.Forms.Label
    Friend WithEvents Nbi_CambiarEstado As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ListarOT As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarOT As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ClonarOT As NetBarControl.NetBarItem
    Friend WithEvents Ds_Informe1 As Informe.Ds_Informe
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Dgv_ListaServicios As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_CantidadServicios As System.Windows.Forms.Panel
    Friend WithEvents Lb_CantidadServicios As System.Windows.Forms.Label

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub Cu_OrdendeTrabajo_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Sc_Listado.SplitterDistance = Me.Width * 0.65
            Me.SplitContainer1.SplitterDistance = Me.Height * 0.65
        Catch ex As Exception

        End Try
    End Sub
    Friend WithEvents Nbg_ExportarExcel As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_OM As NetBarControl.NetBarItem
    Friend WithEvents NetBarItem1 As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SabanaFacturacionOM As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ReporteDiarioxOM As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ResumenFacturacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_AnalisisComparativoxOMs As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprAnalisisComparativo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerOT As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprObraEjecutadaxOM As NetBarControl.NetBarItem
    Friend WithEvents NetBarItem2 As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarOT_Portapapeles As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CambiarEstadoSAP As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprAnalisisComparativoxServicio As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprObraEjecutadaxOMEntreFechas As NetBarControl.NetBarItem
    Friend WithEvents Nbg_MaterialNoConforme As NetBarControl.NetBarGroup
    Friend WithEvents Nbg_NoConformidad As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_ListarMNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearMNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarMNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_AnularMNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CerrarMNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ListarNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_AnularNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CerrarNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerMNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarMNC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarNC As NetBarControl.NetBarItem
    Friend WithEvents Nbg_IntervencionDirecta As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_ListarID As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarID As NetBarControl.NetBarItem
    Friend WithEvents Nbg_ObrasSobreDDV As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_ListarOSDDV As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarOSDDV As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Valvulas As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_ListarV As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarV As NetBarControl.NetBarItem
    Friend WithEvents Nbg_URPC As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_ListarURPC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarURPC As NetBarControl.NetBarItem
    Friend WithEvents Nbg_VariablesMantenimiento As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_Graficar As NetBarControl.NetBarItem
    Friend WithEvents Nbg_DefectologiaXSoldador As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_ListarDS As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarDS As NetBarControl.NetBarItem
    Friend WithEvents Nbg_TablerosTBG As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CargarTBG As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearTBG As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarTBG As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarTBG As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerTBG As NetBarControl.NetBarItem
    Friend WithEvents Nbg_PlanDeOptimizacion As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_ListarPlanesOptimizacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearPlanOptimizacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarPlanOptimizacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerPlanOptimizacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarPlanesOptimizacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Informe246 As NetBarControl.NetBarItem


End Class