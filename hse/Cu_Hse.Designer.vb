<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Hse
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
        Me.Nbc_HSE = New NetBarControl.NetBarControl()
        Me.Nbg_ExamenMedico = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarExamenes = New NetBarControl.NetBarItem()
        Me.Nbi_RegistrarExamen = New NetBarControl.NetBarItem()
        Me.Nbi_VerExamen = New NetBarControl.NetBarItem()
        Me.Nbi_EditarExamen = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarExamen = New NetBarControl.NetBarItem()
        Me.Nbi_RegistrarConcepto = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirConceptoMedico = New NetBarControl.NetBarItem()
        Me.Nbi_HabilitarImpresionConcepto = New NetBarControl.NetBarItem()
        Me.Nbi_EditarConcepto = New NetBarControl.NetBarItem()
        Me.Nbi_InformeCondicionesSalud = New NetBarControl.NetBarItem()
        Me.Nbi_SubirPdfEM = New NetBarControl.NetBarItem()
        Me.Nbi_VerPdfEM = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirHC = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarEnfermedades = New NetBarControl.NetBarItem()
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
        Me.Nbg_Reportes = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarReporte = New NetBarControl.NetBarItem()
        Me.Nbi_CrearReporte = New NetBarControl.NetBarItem()
        Me.Nbi_VerReporte = New NetBarControl.NetBarItem()
        Me.Nbi_EditarReporte = New NetBarControl.NetBarItem()
        Me.Nbi_GenerarInvestigacion = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarReporte = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirReporte = New NetBarControl.NetBarItem()
        Me.Nbi_HablitarImpresionR24 = New NetBarControl.NetBarItem()
        Me.Nbi_AsociarUsuarioBaseHSE = New NetBarControl.NetBarItem()
        Me.Nbg_Investigaciones = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarInvestigaciones = New NetBarControl.NetBarItem()
        Me.Nbi_VerInvestigacion = New NetBarControl.NetBarItem()
        Me.Nbi_EditarInvestigacion = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarInvestigacion = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirInvestigacion = New NetBarControl.NetBarItem()
        Me.Nbi_HabilitarImpresionInvestigacion = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirAlertaSeguridad = New NetBarControl.NetBarItem()
        Me.Nbg_ResumenEstadistico = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarResumenes = New NetBarControl.NetBarItem()
        Me.Nbi_VerResumen = New NetBarControl.NetBarItem()
        Me.Nbi_RegistrarResumenEstadistico = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarResumenEstadistico = New NetBarControl.NetBarItem()
        Me.Nbi_EditarResumen = New NetBarControl.NetBarItem()
        Me.Nbi_HabilitarEdicion = New NetBarControl.NetBarItem()
        Me.Nbi_ExportarResumenBase = New NetBarControl.NetBarItem()
        Me.Nbi_ExportarResumenIsmocol = New NetBarControl.NetBarItem()
        Me.Nbi_ResumenEstidisticoProyecto = New NetBarControl.NetBarItem()
        Me.Nbg_Filtro = New NetBarControl.NetBarGroup()
        Me.Pn_ContenedorPrincipal = New System.Windows.Forms.Panel()
        Me.Pn_ListaPrincipal = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DGV_ListaReportes = New System.Windows.Forms.DataGridView()
        Me.Cms_Ordenar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OrdenarPorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pn_ContenedorReportes = New System.Windows.Forms.Panel()
        Me.Lb_CantidadReportes = New System.Windows.Forms.Label()
        Me.Pn_Propiedades = New System.Windows.Forms.Panel()
        Me.Pg_DetalleLista = New System.Windows.Forms.PropertyGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pn_tituloformulario = New System.Windows.Forms.Panel()
        Me.Lb_Cargado = New System.Windows.Forms.Label()
        Me.Nbc_HSE.SuspendLayout()
        Me.NetBarGroupControlContainer1.SuspendLayout()
        Me.Pn_ContenedorPrincipal.SuspendLayout()
        Me.Pn_ListaPrincipal.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DGV_ListaReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_Ordenar.SuspendLayout()
        Me.Pn_ContenedorReportes.SuspendLayout()
        Me.Pn_Propiedades.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Pn_tituloformulario.SuspendLayout()
        Me.SuspendLayout()
        '
        'Nbc_HSE
        '
        Me.Nbc_HSE.ActiveGroup = Me.Nbg_ExamenMedico
        Me.Nbc_HSE.Controls.Add(Me.NetBarGroupControlContainer1)
        Me.Nbc_HSE.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_HSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_HSE.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_Reportes, Me.Nbg_Investigaciones, Me.Nbg_ResumenEstadistico, Me.Nbg_Filtro, Me.Nbg_ExamenMedico})
        Me.Nbc_HSE.GroupsFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_HSE.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_HSE.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_HSE.Location = New System.Drawing.Point(0, 0)
        Me.Nbc_HSE.Name = "Nbc_HSE"
        Me.Nbc_HSE.ShowOverflowPanel = False
        Me.Nbc_HSE.Size = New System.Drawing.Size(205, 530)
        Me.Nbc_HSE.TabIndex = 12
        Me.Nbc_HSE.Tag = "254"
        Me.Nbc_HSE.Text = "NetBarControl1"
        '
        'Nbg_ExamenMedico
        '
        Me.Nbg_ExamenMedico.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarExamenes, Me.Nbi_RegistrarExamen, Me.Nbi_VerExamen, Me.Nbi_EditarExamen, Me.Nbi_BuscarExamen, Me.Nbi_RegistrarConcepto, Me.Nbi_ImprimirConceptoMedico, Me.Nbi_HabilitarImpresionConcepto, Me.Nbi_EditarConcepto, Me.Nbi_InformeCondicionesSalud, Me.Nbi_SubirPdfEM, Me.Nbi_VerPdfEM, Me.Nbi_ImprimirHC, Me.Nbi_BuscarEnfermedades})
        Me.Nbg_ExamenMedico.Name = "Nbg_ExamenMedico"
        Me.Nbg_ExamenMedico.Tag = "937"
        Me.Nbg_ExamenMedico.Text = "Exámenes Médicos"
        '
        'Nbi_CargarExamenes
        '
        Me.Nbi_CargarExamenes.Name = "Nbi_CargarExamenes"
        Me.Nbi_CargarExamenes.Tag = "938"
        Me.Nbi_CargarExamenes.Text = "Cargar Exámenes"
        '
        'Nbi_RegistrarExamen
        '
        Me.Nbi_RegistrarExamen.Name = "Nbi_RegistrarExamen"
        Me.Nbi_RegistrarExamen.Tag = "939"
        Me.Nbi_RegistrarExamen.Text = "Registrar Examen"
        '
        'Nbi_VerExamen
        '
        Me.Nbi_VerExamen.Name = "Nbi_VerExamen"
        Me.Nbi_VerExamen.Tag = "940"
        Me.Nbi_VerExamen.Text = "Ver Examen"
        '
        'Nbi_EditarExamen
        '
        Me.Nbi_EditarExamen.Name = "Nbi_EditarExamen"
        Me.Nbi_EditarExamen.Tag = "941"
        Me.Nbi_EditarExamen.Text = "Editar Examen"
        '
        'Nbi_BuscarExamen
        '
        Me.Nbi_BuscarExamen.Name = "Nbi_BuscarExamen"
        Me.Nbi_BuscarExamen.Tag = "942"
        Me.Nbi_BuscarExamen.Text = "Buscar Examen"
        '
        'Nbi_RegistrarConcepto
        '
        Me.Nbi_RegistrarConcepto.Name = "Nbi_RegistrarConcepto"
        Me.Nbi_RegistrarConcepto.Tag = "943"
        Me.Nbi_RegistrarConcepto.Text = "Registrar Concepto"
        '
        'Nbi_ImprimirConceptoMedico
        '
        Me.Nbi_ImprimirConceptoMedico.Name = "Nbi_ImprimirConceptoMedico"
        Me.Nbi_ImprimirConceptoMedico.Tag = "944"
        Me.Nbi_ImprimirConceptoMedico.Text = "Imprimir Concepto Médico"
        '
        'Nbi_HabilitarImpresionConcepto
        '
        Me.Nbi_HabilitarImpresionConcepto.Name = "Nbi_HabilitarImpresionConcepto"
        Me.Nbi_HabilitarImpresionConcepto.Tag = "945"
        Me.Nbi_HabilitarImpresionConcepto.Text = "Habilitar Impresión Concepto Médico"
        '
        'Nbi_EditarConcepto
        '
        Me.Nbi_EditarConcepto.Name = "Nbi_EditarConcepto"
        Me.Nbi_EditarConcepto.Tag = "953"
        Me.Nbi_EditarConcepto.Text = "Editar Concepto Médico"
        '
        'Nbi_InformeCondicionesSalud
        '
        Me.Nbi_InformeCondicionesSalud.Name = "Nbi_InformeCondicionesSalud"
        Me.Nbi_InformeCondicionesSalud.Tag = "957"
        Me.Nbi_InformeCondicionesSalud.Text = "Generar Informe Condiciones Salud"
        '
        'Nbi_SubirPdfEM
        '
        Me.Nbi_SubirPdfEM.Name = "Nbi_SubirPdfEM"
        Me.Nbi_SubirPdfEM.Tag = "1026"
        Me.Nbi_SubirPdfEM.Text = "Subir Pdf Concepto Médico"
        '
        'Nbi_VerPdfEM
        '
        Me.Nbi_VerPdfEM.Name = "Nbi_VerPdfEM"
        Me.Nbi_VerPdfEM.Tag = "1027"
        Me.Nbi_VerPdfEM.Text = "Ver Pdf Concepto Médico"
        '
        'Nbi_ImprimirHC
        '
        Me.Nbi_ImprimirHC.Name = "Nbi_ImprimirHC"
        Me.Nbi_ImprimirHC.Tag = "1028"
        Me.Nbi_ImprimirHC.Text = "Imprimir Historia Clinica"
        '
        'Nbi_BuscarEnfermedades
        '
        Me.Nbi_BuscarEnfermedades.Name = "Nbi_BuscarEnfermedades"
        Me.Nbi_BuscarEnfermedades.Tag = "1031"
        Me.Nbi_BuscarEnfermedades.Text = "Buscar Enfermedades CIE10"
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
        Me.NetBarGroupControlContainer1.Size = New System.Drawing.Size(196, 371)
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
        'Nbg_Reportes
        '
        Me.Nbg_Reportes.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarReporte, Me.Nbi_CrearReporte, Me.Nbi_VerReporte, Me.Nbi_EditarReporte, Me.Nbi_GenerarInvestigacion, Me.Nbi_BuscarReporte, Me.Nbi_ImprimirReporte, Me.Nbi_HablitarImpresionR24, Me.Nbi_AsociarUsuarioBaseHSE})
        Me.Nbg_Reportes.Name = "Nbg_Reportes"
        Me.Nbg_Reportes.Tag = "890"
        Me.Nbg_Reportes.Text = "Reportes"
        '
        'Nbi_CargarReporte
        '
        Me.Nbi_CargarReporte.Name = "Nbi_CargarReporte"
        Me.Nbi_CargarReporte.Tag = "891"
        Me.Nbi_CargarReporte.Text = "Cargar Reportes"
        '
        'Nbi_CrearReporte
        '
        Me.Nbi_CrearReporte.Name = "Nbi_CrearReporte"
        Me.Nbi_CrearReporte.Tag = "892"
        Me.Nbi_CrearReporte.Text = "Crear Reporte"
        '
        'Nbi_VerReporte
        '
        Me.Nbi_VerReporte.Name = "Nbi_VerReporte"
        Me.Nbi_VerReporte.Tag = "893"
        Me.Nbi_VerReporte.Text = "Ver Reporte"
        '
        'Nbi_EditarReporte
        '
        Me.Nbi_EditarReporte.Name = "Nbi_EditarReporte"
        Me.Nbi_EditarReporte.Tag = "894"
        Me.Nbi_EditarReporte.Text = "Editar Reporte"
        '
        'Nbi_GenerarInvestigacion
        '
        Me.Nbi_GenerarInvestigacion.Name = "Nbi_GenerarInvestigacion"
        Me.Nbi_GenerarInvestigacion.Tag = "895"
        Me.Nbi_GenerarInvestigacion.Text = "Abrir Investigacion"
        '
        'Nbi_BuscarReporte
        '
        Me.Nbi_BuscarReporte.Name = "Nbi_BuscarReporte"
        Me.Nbi_BuscarReporte.Tag = "896"
        Me.Nbi_BuscarReporte.Text = "Buscar Reporte"
        '
        'Nbi_ImprimirReporte
        '
        Me.Nbi_ImprimirReporte.Name = "Nbi_ImprimirReporte"
        Me.Nbi_ImprimirReporte.Tag = "897"
        Me.Nbi_ImprimirReporte.Text = "Imprimir Reporte"
        '
        'Nbi_HablitarImpresionR24
        '
        Me.Nbi_HablitarImpresionR24.Name = "Nbi_HablitarImpresionR24"
        Me.Nbi_HablitarImpresionR24.Tag = "898"
        Me.Nbi_HablitarImpresionR24.Text = "Habilitar Impresión"
        '
        'Nbi_AsociarUsuarioBaseHSE
        '
        Me.Nbi_AsociarUsuarioBaseHSE.Name = "Nbi_AsociarUsuarioBaseHSE"
        Me.Nbi_AsociarUsuarioBaseHSE.Tag = "936"
        Me.Nbi_AsociarUsuarioBaseHSE.Text = "Asociar Usuario Base"
        '
        'Nbg_Investigaciones
        '
        Me.Nbg_Investigaciones.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarInvestigaciones, Me.Nbi_VerInvestigacion, Me.Nbi_EditarInvestigacion, Me.Nbi_BuscarInvestigacion, Me.Nbi_ImprimirInvestigacion, Me.Nbi_HabilitarImpresionInvestigacion, Me.Nbi_ImprimirAlertaSeguridad})
        Me.Nbg_Investigaciones.Name = "Nbg_Investigaciones"
        Me.Nbg_Investigaciones.Tag = "899"
        Me.Nbg_Investigaciones.Text = "Investigaciones"
        '
        'Nbi_CargarInvestigaciones
        '
        Me.Nbi_CargarInvestigaciones.Name = "Nbi_CargarInvestigaciones"
        Me.Nbi_CargarInvestigaciones.Tag = "900"
        Me.Nbi_CargarInvestigaciones.Text = "Cargar Investigaciones"
        '
        'Nbi_VerInvestigacion
        '
        Me.Nbi_VerInvestigacion.Name = "Nbi_VerInvestigacion"
        Me.Nbi_VerInvestigacion.Tag = "901"
        Me.Nbi_VerInvestigacion.Text = "Ver Investigación"
        '
        'Nbi_EditarInvestigacion
        '
        Me.Nbi_EditarInvestigacion.Name = "Nbi_EditarInvestigacion"
        Me.Nbi_EditarInvestigacion.Tag = "902"
        Me.Nbi_EditarInvestigacion.Text = "Editar Investigación"
        '
        'Nbi_BuscarInvestigacion
        '
        Me.Nbi_BuscarInvestigacion.Name = "Nbi_BuscarInvestigacion"
        Me.Nbi_BuscarInvestigacion.Tag = "903"
        Me.Nbi_BuscarInvestigacion.Text = "Buscar Investigación"
        '
        'Nbi_ImprimirInvestigacion
        '
        Me.Nbi_ImprimirInvestigacion.Name = "Nbi_ImprimirInvestigacion"
        Me.Nbi_ImprimirInvestigacion.Tag = "904"
        Me.Nbi_ImprimirInvestigacion.Text = "Imprimir Investigación"
        '
        'Nbi_HabilitarImpresionInvestigacion
        '
        Me.Nbi_HabilitarImpresionInvestigacion.Name = "Nbi_HabilitarImpresionInvestigacion"
        Me.Nbi_HabilitarImpresionInvestigacion.Tag = "905"
        Me.Nbi_HabilitarImpresionInvestigacion.Text = "Habilitar Impresion Investigación"
        '
        'Nbi_ImprimirAlertaSeguridad
        '
        Me.Nbi_ImprimirAlertaSeguridad.Name = "Nbi_ImprimirAlertaSeguridad"
        Me.Nbi_ImprimirAlertaSeguridad.Tag = "906"
        Me.Nbi_ImprimirAlertaSeguridad.Text = "Imprimir Alerta De Seguridad"
        '
        'Nbg_ResumenEstadistico
        '
        Me.Nbg_ResumenEstadistico.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarResumenes, Me.Nbi_VerResumen, Me.Nbi_RegistrarResumenEstadistico, Me.Nbi_BuscarResumenEstadistico, Me.Nbi_EditarResumen, Me.Nbi_HabilitarEdicion, Me.Nbi_ExportarResumenBase, Me.Nbi_ExportarResumenIsmocol, Me.Nbi_ResumenEstidisticoProyecto})
        Me.Nbg_ResumenEstadistico.Name = "Nbg_ResumenEstadistico"
        Me.Nbg_ResumenEstadistico.Tag = "907"
        Me.Nbg_ResumenEstadistico.Text = "Resumen Estadístico"
        '
        'Nbi_CargarResumenes
        '
        Me.Nbi_CargarResumenes.Name = "Nbi_CargarResumenes"
        Me.Nbi_CargarResumenes.Tag = "908"
        Me.Nbi_CargarResumenes.Text = "Cargar Datos Resumen Estadísitco"
        '
        'Nbi_VerResumen
        '
        Me.Nbi_VerResumen.Name = "Nbi_VerResumen"
        Me.Nbi_VerResumen.Tag = "909"
        Me.Nbi_VerResumen.Text = "Ver Datos Resumen Estadístico"
        '
        'Nbi_RegistrarResumenEstadistico
        '
        Me.Nbi_RegistrarResumenEstadistico.Name = "Nbi_RegistrarResumenEstadistico"
        Me.Nbi_RegistrarResumenEstadistico.Tag = "910"
        Me.Nbi_RegistrarResumenEstadistico.Text = "Registrar Datos Resumen Estadístico"
        '
        'Nbi_BuscarResumenEstadistico
        '
        Me.Nbi_BuscarResumenEstadistico.Name = "Nbi_BuscarResumenEstadistico"
        Me.Nbi_BuscarResumenEstadistico.Tag = "911"
        Me.Nbi_BuscarResumenEstadistico.Text = "Buscar"
        '
        'Nbi_EditarResumen
        '
        Me.Nbi_EditarResumen.Name = "Nbi_EditarResumen"
        Me.Nbi_EditarResumen.Tag = "912"
        Me.Nbi_EditarResumen.Text = "Editar Resumen Estadístico"
        '
        'Nbi_HabilitarEdicion
        '
        Me.Nbi_HabilitarEdicion.Name = "Nbi_HabilitarEdicion"
        Me.Nbi_HabilitarEdicion.Tag = "913"
        Me.Nbi_HabilitarEdicion.Text = "Habilitar Edición"
        '
        'Nbi_ExportarResumenBase
        '
        Me.Nbi_ExportarResumenBase.Name = "Nbi_ExportarResumenBase"
        Me.Nbi_ExportarResumenBase.Tag = "914"
        Me.Nbi_ExportarResumenBase.Text = "Resumen Estadístico x Base"
        '
        'Nbi_ExportarResumenIsmocol
        '
        Me.Nbi_ExportarResumenIsmocol.Name = "Nbi_ExportarResumenIsmocol"
        Me.Nbi_ExportarResumenIsmocol.Tag = "915"
        Me.Nbi_ExportarResumenIsmocol.Text = "Resumen Estadístico Ismocol"
        '
        'Nbi_ResumenEstidisticoProyecto
        '
        Me.Nbi_ResumenEstidisticoProyecto.Name = "Nbi_ResumenEstidisticoProyecto"
        Me.Nbi_ResumenEstidisticoProyecto.Tag = "916"
        Me.Nbi_ResumenEstidisticoProyecto.Text = "Resumen Estadístico x Proyecto"
        '
        'Nbg_Filtro
        '
        Me.Nbg_Filtro.ControlContainer = Me.NetBarGroupControlContainer1
        Me.Nbg_Filtro.Name = "Nbg_Filtro"
        Me.Nbg_Filtro.Style = NetBarControl.NetBarGroupStyle.ControlContainer
        Me.Nbg_Filtro.Tag = "258"
        Me.Nbg_Filtro.Text = "Filtro"
        Me.Nbg_Filtro.Visible = False
        '
        'Pn_ContenedorPrincipal
        '
        Me.Pn_ContenedorPrincipal.AutoSize = True
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Pn_ListaPrincipal)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Pn_tituloformulario)
        Me.Pn_ContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ContenedorPrincipal.Location = New System.Drawing.Point(205, 0)
        Me.Pn_ContenedorPrincipal.Name = "Pn_ContenedorPrincipal"
        Me.Pn_ContenedorPrincipal.Size = New System.Drawing.Size(675, 530)
        Me.Pn_ContenedorPrincipal.TabIndex = 13
        '
        'Pn_ListaPrincipal
        '
        Me.Pn_ListaPrincipal.Controls.Add(Me.SplitContainer1)
        Me.Pn_ListaPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ListaPrincipal.Location = New System.Drawing.Point(0, 24)
        Me.Pn_ListaPrincipal.Name = "Pn_ListaPrincipal"
        Me.Pn_ListaPrincipal.Size = New System.Drawing.Size(675, 506)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.DGV_ListaReportes)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Pn_ContenedorReportes)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Pn_Propiedades)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(675, 506)
        Me.SplitContainer1.SplitterDistance = 450
        Me.SplitContainer1.TabIndex = 4
        '
        'DGV_ListaReportes
        '
        Me.DGV_ListaReportes.AllowUserToAddRows = False
        Me.DGV_ListaReportes.AllowUserToDeleteRows = False
        Me.DGV_ListaReportes.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGV_ListaReportes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_ListaReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV_ListaReportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_ListaReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaReportes.ContextMenuStrip = Me.Cms_Ordenar
        Me.DGV_ListaReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_ListaReportes.Location = New System.Drawing.Point(0, 18)
        Me.DGV_ListaReportes.Name = "DGV_ListaReportes"
        Me.DGV_ListaReportes.ReadOnly = True
        Me.DGV_ListaReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_ListaReportes.Size = New System.Drawing.Size(450, 488)
        Me.DGV_ListaReportes.TabIndex = 3
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
        'Pn_ContenedorReportes
        '
        Me.Pn_ContenedorReportes.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_ContenedorReportes.Controls.Add(Me.Lb_CantidadReportes)
        Me.Pn_ContenedorReportes.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_ContenedorReportes.Location = New System.Drawing.Point(0, 0)
        Me.Pn_ContenedorReportes.Name = "Pn_ContenedorReportes"
        Me.Pn_ContenedorReportes.Size = New System.Drawing.Size(450, 18)
        Me.Pn_ContenedorReportes.TabIndex = 8
        '
        'Lb_CantidadReportes
        '
        Me.Lb_CantidadReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_CantidadReportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadReportes.ForeColor = System.Drawing.Color.Black
        Me.Lb_CantidadReportes.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CantidadReportes.Name = "Lb_CantidadReportes"
        Me.Lb_CantidadReportes.Size = New System.Drawing.Size(450, 18)
        Me.Lb_CantidadReportes.TabIndex = 0
        Me.Lb_CantidadReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pn_Propiedades
        '
        Me.Pn_Propiedades.AutoSize = True
        Me.Pn_Propiedades.Controls.Add(Me.Pg_DetalleLista)
        Me.Pn_Propiedades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Propiedades.Location = New System.Drawing.Point(0, 18)
        Me.Pn_Propiedades.Name = "Pn_Propiedades"
        Me.Pn_Propiedades.Size = New System.Drawing.Size(221, 488)
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
        Me.Pg_DetalleLista.Size = New System.Drawing.Size(221, 488)
        Me.Pg_DetalleLista.TabIndex = 10
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
        'Cu_Hse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pn_ContenedorPrincipal)
        Me.Controls.Add(Me.Nbc_HSE)
        Me.Name = "Cu_Hse"
        Me.Size = New System.Drawing.Size(880, 530)
        Me.Tag = ""
        Me.Nbc_HSE.ResumeLayout(False)
        Me.NetBarGroupControlContainer1.ResumeLayout(False)
        Me.NetBarGroupControlContainer1.PerformLayout()
        Me.Pn_ContenedorPrincipal.ResumeLayout(False)
        Me.Pn_ListaPrincipal.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DGV_ListaReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_Ordenar.ResumeLayout(False)
        Me.Pn_ContenedorReportes.ResumeLayout(False)
        Me.Pn_Propiedades.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Pn_tituloformulario.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Nbc_HSE As NetBarControl.NetBarControl
    Friend WithEvents Nbg_Reportes As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CrearReporte As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarReporte As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Filtro As NetBarControl.NetBarGroup
    Friend WithEvents Pn_ContenedorPrincipal As System.Windows.Forms.Panel
    Friend WithEvents DGV_ListaReportes As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_ContenedorReportes As System.Windows.Forms.Panel
    Friend WithEvents Lb_CantidadReportes As System.Windows.Forms.Label
    Friend WithEvents Nbi_CargarReporte As NetBarControl.NetBarItem
    Friend WithEvents Nbi_GenerarInvestigacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirReporte As NetBarControl.NetBarItem
    Friend WithEvents Pn_tituloformulario As System.Windows.Forms.Panel
    Friend WithEvents Lb_Cargado As System.Windows.Forms.Label
    Friend WithEvents Pn_ListaPrincipal As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pg_DetalleLista As System.Windows.Forms.PropertyGrid
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
    Friend WithEvents Nbi_VerReporte As NetBarControl.NetBarItem
    Friend WithEvents Cms_Ordenar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OrdenarPorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_BuscarReporte As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HablitarImpresionR24 As NetBarControl.NetBarItem
    Friend WithEvents Pn_Propiedades As System.Windows.Forms.Panel
    Friend WithEvents Nbg_Investigaciones As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CargarInvestigaciones As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerInvestigacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarInvestigacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirInvestigacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HabilitarImpresionInvestigacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarInvestigacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirAlertaSeguridad As NetBarControl.NetBarItem
    Friend WithEvents Nbg_ResumenEstadistico As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_RegistrarResumenEstadistico As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarResumenes As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerResumen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarResumen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HabilitarEdicion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ExportarResumenBase As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ExportarResumenIsmocol As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ResumenEstidisticoProyecto As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarResumenEstadistico As NetBarControl.NetBarItem
    Friend WithEvents Nbi_AsociarUsuarioBaseHSE As NetBarControl.NetBarItem
    Friend WithEvents Nbg_ExamenMedico As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CargarExamenes As NetBarControl.NetBarItem
    Friend WithEvents Nbi_RegistrarExamen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerExamen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarExamen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarExamen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_RegistrarConcepto As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirConceptoMedico As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HabilitarImpresionConcepto As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarConcepto As NetBarControl.NetBarItem
    Friend WithEvents Nbi_InformeCondicionesSalud As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirPdfEM As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerPdfEM As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirHC As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarEnfermedades As NetBarControl.NetBarItem

End Class

