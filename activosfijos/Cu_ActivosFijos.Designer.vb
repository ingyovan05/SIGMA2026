<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_ActivosFijos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Nbc_Equipos = New NetBarControl.NetBarControl()
        Me.Nbg_Equipo = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarEquipos = New NetBarControl.NetBarItem()
        Me.Nbi_CrearEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_ClonarEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_EditarEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_DarBaja = New NetBarControl.NetBarItem()
        Me.Nbi_EliminarEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_EstadoUso = New NetBarControl.NetBarItem()
        Me.Nbi_VerCaracteristicas = New NetBarControl.NetBarItem()
        Me.Nbi_CrearRevisiónExterna = New NetBarControl.NetBarItem()
        Me.Nbi_VerHojaVida = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirPazSalvo = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirStickerEquipo = New NetBarControl.NetBarItem()
        Me.Nbi_Asegurado = New NetBarControl.NetBarItem()
        Me.NetBarGroupControlContainer1 = New NetBarControl.NetBarGroupControlContainer()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Btn_Filtrar = New System.Windows.Forms.Button()
        Me.Tx_ValorFiltro3 = New System.Windows.Forms.TextBox()
        Me.Cb_FiltrarPor3 = New System.Windows.Forms.ComboBox()
        Me.Ck_Filtro3 = New System.Windows.Forms.CheckBox()
        Me.Tx_ValorFiltro2 = New System.Windows.Forms.TextBox()
        Me.Cb_FiltrarPor2 = New System.Windows.Forms.ComboBox()
        Me.Ck_Filtro2 = New System.Windows.Forms.CheckBox()
        Me.Tx_ValorFiltro1 = New System.Windows.Forms.TextBox()
        Me.Cb_FiltrarPor1 = New System.Windows.Forms.ComboBox()
        Me.Ck_Filtro1 = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Nbg_Administracion = New NetBarControl.NetBarGroup()
        Me.Nbi_AdministrarTipos = New NetBarControl.NetBarItem()
        Me.Nbi_RestaurarEquipo = New NetBarControl.NetBarItem()
        Me.Nbg_Traslados = New NetBarControl.NetBarGroup()
        Me.Nbi_PendientesEnviados = New NetBarControl.NetBarItem()
        Me.Nbi_EnviadosRecibidos = New NetBarControl.NetBarItem()
        Me.Nbi_PendientesRecibir = New NetBarControl.NetBarItem()
        Me.Nbi_Recibidos = New NetBarControl.NetBarItem()
        Me.Nbg_RevisiónExterna = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarRevisionesExternas = New NetBarControl.NetBarItem()
        Me.Nbi_VerRevisiónExterna = New NetBarControl.NetBarItem()
        Me.Nbi_EditarRevisiónExterna = New NetBarControl.NetBarItem()
        Me.Nbi_CerrarRevisiónExterna = New NetBarControl.NetBarItem()
        Me.Nbi_AnularRevisiónExterna = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarRevisiónExterna = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirRevisiónExterna = New NetBarControl.NetBarItem()
        Me.Nbg_Filtrar = New NetBarControl.NetBarGroup()
        Me.Pn_ContenedorPrincipal = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Dgv_Equipos = New System.Windows.Forms.DataGridView()
        Me.Pg_DetalleLista = New System.Windows.Forms.PropertyGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Dgv_Historial = New System.Windows.Forms.DataGridView()
        Me.ESTADOBODEGA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAENTRADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTRADAALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BODEGAENTRADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHASALIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALIDAALMACEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BODEGASALIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REMISION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dgv_Componentes = New System.Windows.Forms.DataGridView()
        Me.IDCOMPONENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn43 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn46 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn51 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn52 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn60 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn62 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn70 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn71 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn72 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn73 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn74 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn75 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NetBarGroupControlContainer3 = New NetBarControl.NetBarGroupControlContainer()
        Me.Nbc_Equipos.SuspendLayout()
        Me.NetBarGroupControlContainer1.SuspendLayout()
        Me.Pn_ContenedorPrincipal.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Dgv_Equipos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.Dgv_Historial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_Componentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Nbc_Equipos
        '
        Me.Nbc_Equipos.ActiveGroup = Me.Nbg_Equipo
        Me.Nbc_Equipos.Controls.Add(Me.NetBarGroupControlContainer1)
        Me.Nbc_Equipos.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_Equipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Equipos.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_Equipo, Me.Nbg_Administracion, Me.Nbg_Traslados, Me.Nbg_RevisiónExterna, Me.Nbg_Filtrar})
        Me.Nbc_Equipos.GroupsFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Equipos.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_Equipos.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_Equipos.Location = New System.Drawing.Point(0, 0)
        Me.Nbc_Equipos.Name = "Nbc_Equipos"
        Me.Nbc_Equipos.ShowOverflowPanel = False
        Me.Nbc_Equipos.Size = New System.Drawing.Size(220, 510)
        Me.Nbc_Equipos.TabIndex = 13
        Me.Nbc_Equipos.Tag = "515"
        Me.Nbc_Equipos.Text = "NetBarControl1"
        '
        'Nbg_Equipo
        '
        Me.Nbg_Equipo.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarEquipos, Me.Nbi_CrearEquipo, Me.Nbi_ClonarEquipo, Me.Nbi_EditarEquipo, Me.Nbi_DarBaja, Me.Nbi_EliminarEquipo, Me.Nbi_BuscarEquipo, Me.Nbi_EstadoUso, Me.Nbi_VerCaracteristicas, Me.Nbi_CrearRevisiónExterna, Me.Nbi_VerHojaVida, Me.Nbi_ImprimirPazSalvo, Me.Nbi_ImprimirStickerEquipo, Me.Nbi_Asegurado})
        Me.Nbg_Equipo.Name = "Nbg_Equipo"
        Me.Nbg_Equipo.Tag = "516"
        Me.Nbg_Equipo.Text = "Equipo"
        '
        'Nbi_CargarEquipos
        '
        Me.Nbi_CargarEquipos.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_CargarEquipos.Name = "Nbi_CargarEquipos"
        Me.Nbi_CargarEquipos.Tag = "520"
        Me.Nbi_CargarEquipos.Text = "Cargar Equipos"
        '
        'Nbi_CrearEquipo
        '
        Me.Nbi_CrearEquipo.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_CrearEquipo.Name = "Nbi_CrearEquipo"
        Me.Nbi_CrearEquipo.Tag = "521"
        Me.Nbi_CrearEquipo.Text = "Crear Equipo"
        '
        'Nbi_ClonarEquipo
        '
        Me.Nbi_ClonarEquipo.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_ClonarEquipo.Name = "Nbi_ClonarEquipo"
        Me.Nbi_ClonarEquipo.Tag = "522"
        Me.Nbi_ClonarEquipo.Text = "Clonar Equipo"
        '
        'Nbi_EditarEquipo
        '
        Me.Nbi_EditarEquipo.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_EditarEquipo.Name = "Nbi_EditarEquipo"
        Me.Nbi_EditarEquipo.Tag = "523"
        Me.Nbi_EditarEquipo.Text = "Editar Equipo"
        '
        'Nbi_DarBaja
        '
        Me.Nbi_DarBaja.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_DarBaja.Name = "Nbi_DarBaja"
        Me.Nbi_DarBaja.Tag = "524"
        Me.Nbi_DarBaja.Text = "Dar de Baja"
        '
        'Nbi_EliminarEquipo
        '
        Me.Nbi_EliminarEquipo.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_EliminarEquipo.Name = "Nbi_EliminarEquipo"
        Me.Nbi_EliminarEquipo.Tag = "525"
        Me.Nbi_EliminarEquipo.Text = "Eliminar Equipo"
        '
        'Nbi_BuscarEquipo
        '
        Me.Nbi_BuscarEquipo.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_BuscarEquipo.Name = "Nbi_BuscarEquipo"
        Me.Nbi_BuscarEquipo.Tag = "526"
        Me.Nbi_BuscarEquipo.Text = "Buscar Equipo"
        '
        'Nbi_EstadoUso
        '
        Me.Nbi_EstadoUso.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_EstadoUso.Name = "Nbi_EstadoUso"
        Me.Nbi_EstadoUso.Tag = "527"
        Me.Nbi_EstadoUso.Text = "Estado Uso"
        '
        'Nbi_VerCaracteristicas
        '
        Me.Nbi_VerCaracteristicas.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_VerCaracteristicas.Name = "Nbi_VerCaracteristicas"
        Me.Nbi_VerCaracteristicas.Tag = "534"
        Me.Nbi_VerCaracteristicas.Text = "Ver Características"
        '
        'Nbi_CrearRevisiónExterna
        '
        Me.Nbi_CrearRevisiónExterna.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_CrearRevisiónExterna.Name = "Nbi_CrearRevisiónExterna"
        Me.Nbi_CrearRevisiónExterna.Tag = "543"
        Me.Nbi_CrearRevisiónExterna.Text = "Crear Revisión Externa"
        '
        'Nbi_VerHojaVida
        '
        Me.Nbi_VerHojaVida.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_VerHojaVida.Name = "Nbi_VerHojaVida"
        Me.Nbi_VerHojaVida.Tag = "545"
        Me.Nbi_VerHojaVida.Text = "Ver Hoja Vida"
        '
        'Nbi_ImprimirPazSalvo
        '
        Me.Nbi_ImprimirPazSalvo.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_ImprimirPazSalvo.Name = "Nbi_ImprimirPazSalvo"
        Me.Nbi_ImprimirPazSalvo.Tag = "546"
        Me.Nbi_ImprimirPazSalvo.Text = "Imprimir Acta Paz y Salvo"
        '
        'Nbi_ImprimirStickerEquipo
        '
        Me.Nbi_ImprimirStickerEquipo.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_ImprimirStickerEquipo.Name = "Nbi_ImprimirStickerEquipo"
        Me.Nbi_ImprimirStickerEquipo.Tag = "887"
        Me.Nbi_ImprimirStickerEquipo.Text = "Imprimir Sticker Equipo"
        '
        'Nbi_Asegurado
        '
        Me.Nbi_Asegurado.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_Asegurado.Name = "Nbi_Asegurado"
        Me.Nbi_Asegurado.Tag = "946"
        Me.Nbi_Asegurado.Text = "Asegurado / Desasegurado"
        '
        'NetBarGroupControlContainer1
        '
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Label6)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Btn_Filtrar)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Tx_ValorFiltro3)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Cb_FiltrarPor3)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Ck_Filtro3)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Tx_ValorFiltro2)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Cb_FiltrarPor2)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Ck_Filtro2)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Tx_ValorFiltro1)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Cb_FiltrarPor1)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Ck_Filtro1)
        Me.NetBarGroupControlContainer1.Controls.Add(Me.Label5)
        Me.NetBarGroupControlContainer1.Name = "NetBarGroupControlContainer1"
        Me.NetBarGroupControlContainer1.Size = New System.Drawing.Size(211, 321)
        Me.NetBarGroupControlContainer1.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(2, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Filtrar Por:"
        '
        'Btn_Filtrar
        '
        Me.Btn_Filtrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Filtrar.Location = New System.Drawing.Point(104, 197)
        Me.Btn_Filtrar.Name = "Btn_Filtrar"
        Me.Btn_Filtrar.Size = New System.Drawing.Size(87, 23)
        Me.Btn_Filtrar.TabIndex = 10
        Me.Btn_Filtrar.Text = "Filtrar Listas"
        Me.Btn_Filtrar.UseVisualStyleBackColor = True
        '
        'Tx_ValorFiltro3
        '
        Me.Tx_ValorFiltro3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_ValorFiltro3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_ValorFiltro3.Location = New System.Drawing.Point(20, 171)
        Me.Tx_ValorFiltro3.Name = "Tx_ValorFiltro3"
        Me.Tx_ValorFiltro3.Size = New System.Drawing.Size(171, 20)
        Me.Tx_ValorFiltro3.TabIndex = 9
        '
        'Cb_FiltrarPor3
        '
        Me.Cb_FiltrarPor3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_FiltrarPor3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_FiltrarPor3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_FiltrarPor3.FormattingEnabled = True
        Me.Cb_FiltrarPor3.Location = New System.Drawing.Point(20, 147)
        Me.Cb_FiltrarPor3.Name = "Cb_FiltrarPor3"
        Me.Cb_FiltrarPor3.Size = New System.Drawing.Size(171, 21)
        Me.Cb_FiltrarPor3.TabIndex = 8
        '
        'Ck_Filtro3
        '
        Me.Ck_Filtro3.AutoSize = True
        Me.Ck_Filtro3.Location = New System.Drawing.Point(2, 151)
        Me.Ck_Filtro3.Name = "Ck_Filtro3"
        Me.Ck_Filtro3.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtro3.TabIndex = 7
        Me.Ck_Filtro3.UseVisualStyleBackColor = True
        '
        'Tx_ValorFiltro2
        '
        Me.Tx_ValorFiltro2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_ValorFiltro2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_ValorFiltro2.Location = New System.Drawing.Point(20, 118)
        Me.Tx_ValorFiltro2.Name = "Tx_ValorFiltro2"
        Me.Tx_ValorFiltro2.Size = New System.Drawing.Size(171, 20)
        Me.Tx_ValorFiltro2.TabIndex = 6
        '
        'Cb_FiltrarPor2
        '
        Me.Cb_FiltrarPor2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_FiltrarPor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_FiltrarPor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_FiltrarPor2.FormattingEnabled = True
        Me.Cb_FiltrarPor2.Location = New System.Drawing.Point(20, 94)
        Me.Cb_FiltrarPor2.Name = "Cb_FiltrarPor2"
        Me.Cb_FiltrarPor2.Size = New System.Drawing.Size(171, 21)
        Me.Cb_FiltrarPor2.TabIndex = 5
        '
        'Ck_Filtro2
        '
        Me.Ck_Filtro2.AutoSize = True
        Me.Ck_Filtro2.Location = New System.Drawing.Point(2, 98)
        Me.Ck_Filtro2.Name = "Ck_Filtro2"
        Me.Ck_Filtro2.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtro2.TabIndex = 4
        Me.Ck_Filtro2.UseVisualStyleBackColor = True
        '
        'Tx_ValorFiltro1
        '
        Me.Tx_ValorFiltro1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_ValorFiltro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_ValorFiltro1.Location = New System.Drawing.Point(20, 65)
        Me.Tx_ValorFiltro1.Name = "Tx_ValorFiltro1"
        Me.Tx_ValorFiltro1.Size = New System.Drawing.Size(171, 20)
        Me.Tx_ValorFiltro1.TabIndex = 3
        '
        'Cb_FiltrarPor1
        '
        Me.Cb_FiltrarPor1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_FiltrarPor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_FiltrarPor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Cb_FiltrarPor1.FormattingEnabled = True
        Me.Cb_FiltrarPor1.Location = New System.Drawing.Point(20, 41)
        Me.Cb_FiltrarPor1.Name = "Cb_FiltrarPor1"
        Me.Cb_FiltrarPor1.Size = New System.Drawing.Size(171, 21)
        Me.Cb_FiltrarPor1.TabIndex = 2
        '
        'Ck_Filtro1
        '
        Me.Ck_Filtro1.AutoSize = True
        Me.Ck_Filtro1.Location = New System.Drawing.Point(2, 48)
        Me.Ck_Filtro1.Name = "Ck_Filtro1"
        Me.Ck_Filtro1.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtro1.TabIndex = 1
        Me.Ck_Filtro1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Info
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(211, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Seleccione los filtros"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Nbg_Administracion
        '
        Me.Nbg_Administracion.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_AdministrarTipos, Me.Nbi_RestaurarEquipo})
        Me.Nbg_Administracion.Name = "Nbg_Administracion"
        Me.Nbg_Administracion.Tag = "517"
        Me.Nbg_Administracion.Text = "Administración"
        '
        'Nbi_AdministrarTipos
        '
        Me.Nbi_AdministrarTipos.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_AdministrarTipos.Name = "Nbi_AdministrarTipos"
        Me.Nbi_AdministrarTipos.Tag = "528"
        Me.Nbi_AdministrarTipos.Text = "Administrar Tipos / Subtipos"
        '
        'Nbi_RestaurarEquipo
        '
        Me.Nbi_RestaurarEquipo.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_RestaurarEquipo.Name = "Nbi_RestaurarEquipo"
        Me.Nbi_RestaurarEquipo.Tag = "529"
        Me.Nbi_RestaurarEquipo.Text = "Restaurar De Baja"
        '
        'Nbg_Traslados
        '
        Me.Nbg_Traslados.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_PendientesEnviados, Me.Nbi_EnviadosRecibidos, Me.Nbi_PendientesRecibir, Me.Nbi_Recibidos})
        Me.Nbg_Traslados.Name = "Nbg_Traslados"
        Me.Nbg_Traslados.Tag = "518"
        Me.Nbg_Traslados.Text = "Traslados"
        '
        'Nbi_PendientesEnviados
        '
        Me.Nbi_PendientesEnviados.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_PendientesEnviados.Name = "Nbi_PendientesEnviados"
        Me.Nbi_PendientesEnviados.Tag = "530"
        Me.Nbi_PendientesEnviados.Text = "Enviados Pendientes"
        '
        'Nbi_EnviadosRecibidos
        '
        Me.Nbi_EnviadosRecibidos.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_EnviadosRecibidos.Name = "Nbi_EnviadosRecibidos"
        Me.Nbi_EnviadosRecibidos.Tag = "531"
        Me.Nbi_EnviadosRecibidos.Text = "Enviados Recibidos"
        '
        'Nbi_PendientesRecibir
        '
        Me.Nbi_PendientesRecibir.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_PendientesRecibir.Name = "Nbi_PendientesRecibir"
        Me.Nbi_PendientesRecibir.Tag = "532"
        Me.Nbi_PendientesRecibir.Text = "Pendientes por Recibir"
        '
        'Nbi_Recibidos
        '
        Me.Nbi_Recibidos.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_Recibidos.Name = "Nbi_Recibidos"
        Me.Nbi_Recibidos.Tag = "533"
        Me.Nbi_Recibidos.Text = "Recibidos"
        '
        'Nbg_RevisiónExterna
        '
        Me.Nbg_RevisiónExterna.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarRevisionesExternas, Me.Nbi_VerRevisiónExterna, Me.Nbi_EditarRevisiónExterna, Me.Nbi_CerrarRevisiónExterna, Me.Nbi_AnularRevisiónExterna, Me.Nbi_BuscarRevisiónExterna, Me.Nbi_ImprimirRevisiónExterna})
        Me.Nbg_RevisiónExterna.Name = "Nbg_RevisiónExterna"
        Me.Nbg_RevisiónExterna.Tag = "535"
        Me.Nbg_RevisiónExterna.Text = "Revisión Externa"
        '
        'Nbi_CargarRevisionesExternas
        '
        Me.Nbi_CargarRevisionesExternas.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_CargarRevisionesExternas.Name = "Nbi_CargarRevisionesExternas"
        Me.Nbi_CargarRevisionesExternas.Tag = "536"
        Me.Nbi_CargarRevisionesExternas.Text = "Cargar Revisiones Externas"
        '
        'Nbi_VerRevisiónExterna
        '
        Me.Nbi_VerRevisiónExterna.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_VerRevisiónExterna.Name = "Nbi_VerRevisiónExterna"
        Me.Nbi_VerRevisiónExterna.Tag = "537"
        Me.Nbi_VerRevisiónExterna.Text = "Ver Revisión Externa"
        '
        'Nbi_EditarRevisiónExterna
        '
        Me.Nbi_EditarRevisiónExterna.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_EditarRevisiónExterna.Name = "Nbi_EditarRevisiónExterna"
        Me.Nbi_EditarRevisiónExterna.Tag = "538"
        Me.Nbi_EditarRevisiónExterna.Text = "Editar Revisión Externa"
        '
        'Nbi_CerrarRevisiónExterna
        '
        Me.Nbi_CerrarRevisiónExterna.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_CerrarRevisiónExterna.Name = "Nbi_CerrarRevisiónExterna"
        Me.Nbi_CerrarRevisiónExterna.Tag = "539"
        Me.Nbi_CerrarRevisiónExterna.Text = "Cerrar Revisión Externa"
        '
        'Nbi_AnularRevisiónExterna
        '
        Me.Nbi_AnularRevisiónExterna.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_AnularRevisiónExterna.Name = "Nbi_AnularRevisiónExterna"
        Me.Nbi_AnularRevisiónExterna.Tag = "540"
        Me.Nbi_AnularRevisiónExterna.Text = "Anular Revisión Externa"
        '
        'Nbi_BuscarRevisiónExterna
        '
        Me.Nbi_BuscarRevisiónExterna.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_BuscarRevisiónExterna.Name = "Nbi_BuscarRevisiónExterna"
        Me.Nbi_BuscarRevisiónExterna.Tag = "541"
        Me.Nbi_BuscarRevisiónExterna.Text = "Buscar Revisión Externa"
        '
        'Nbi_ImprimirRevisiónExterna
        '
        Me.Nbi_ImprimirRevisiónExterna.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Nbi_ImprimirRevisiónExterna.Name = "Nbi_ImprimirRevisiónExterna"
        Me.Nbi_ImprimirRevisiónExterna.Tag = "542"
        Me.Nbi_ImprimirRevisiónExterna.Text = "Imprimir Revisión Externa"
        '
        'Nbg_Filtrar
        '
        Me.Nbg_Filtrar.ControlContainer = Me.NetBarGroupControlContainer1
        Me.Nbg_Filtrar.Name = "Nbg_Filtrar"
        Me.Nbg_Filtrar.Style = NetBarControl.NetBarGroupStyle.ControlContainer
        Me.Nbg_Filtrar.Tag = "519"
        Me.Nbg_Filtrar.Text = "Filtrar"
        '
        'Pn_ContenedorPrincipal
        '
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.SplitContainer1)
        Me.Pn_ContenedorPrincipal.Controls.Add(Me.Lb_Titulo)
        Me.Pn_ContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ContenedorPrincipal.Location = New System.Drawing.Point(220, 0)
        Me.Pn_ContenedorPrincipal.Name = "Pn_ContenedorPrincipal"
        Me.Pn_ContenedorPrincipal.Size = New System.Drawing.Size(738, 510)
        Me.Pn_ContenedorPrincipal.TabIndex = 14
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 23)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(738, 487)
        Me.SplitContainer1.SplitterDistance = 346
        Me.SplitContainer1.TabIndex = 2
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Dgv_Equipos)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Pg_DetalleLista)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer2.Size = New System.Drawing.Size(738, 346)
        Me.SplitContainer2.SplitterDistance = 506
        Me.SplitContainer2.TabIndex = 0
        '
        'Dgv_Equipos
        '
        Me.Dgv_Equipos.AllowUserToAddRows = False
        Me.Dgv_Equipos.AllowUserToDeleteRows = False
        Me.Dgv_Equipos.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Equipos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Equipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Equipos.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Equipos.MultiSelect = False
        Me.Dgv_Equipos.Name = "Dgv_Equipos"
        Me.Dgv_Equipos.ReadOnly = True
        Me.Dgv_Equipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Equipos.Size = New System.Drawing.Size(504, 344)
        Me.Dgv_Equipos.TabIndex = 1
        '
        'Pg_DetalleLista
        '
        Me.Pg_DetalleLista.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Pg_DetalleLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pg_DetalleLista.Font = New System.Drawing.Font("Tahoma", 6.75!)
        Me.Pg_DetalleLista.Location = New System.Drawing.Point(0, 23)
        Me.Pg_DetalleLista.Name = "Pg_DetalleLista"
        Me.Pg_DetalleLista.Size = New System.Drawing.Size(226, 321)
        Me.Pg_DetalleLista.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.AliceBlue
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Informacion Adicional"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Dgv_Historial)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Dgv_Componentes)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer3.Size = New System.Drawing.Size(738, 137)
        Me.SplitContainer3.SplitterDistance = 509
        Me.SplitContainer3.TabIndex = 0
        '
        'Dgv_Historial
        '
        Me.Dgv_Historial.AllowUserToAddRows = False
        Me.Dgv_Historial.AllowUserToDeleteRows = False
        Me.Dgv_Historial.AllowUserToOrderColumns = True
        Me.Dgv_Historial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_Historial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Historial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ESTADOBODEGA, Me.FECHAENTRADA, Me.ENTRADAALMACEN, Me.BODEGAENTRADA, Me.FECHASALIDA, Me.SALIDAALMACEN, Me.BODEGASALIDA, Me.REMISION})
        Me.Dgv_Historial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Historial.Location = New System.Drawing.Point(0, 40)
        Me.Dgv_Historial.MultiSelect = False
        Me.Dgv_Historial.Name = "Dgv_Historial"
        Me.Dgv_Historial.ReadOnly = True
        Me.Dgv_Historial.Size = New System.Drawing.Size(507, 95)
        Me.Dgv_Historial.TabIndex = 1
        '
        'ESTADOBODEGA
        '
        Me.ESTADOBODEGA.DataPropertyName = "ESTADO"
        Me.ESTADOBODEGA.HeaderText = "Est"
        Me.ESTADOBODEGA.Name = "ESTADOBODEGA"
        Me.ESTADOBODEGA.ReadOnly = True
        Me.ESTADOBODEGA.Width = 47
        '
        'FECHAENTRADA
        '
        Me.FECHAENTRADA.DataPropertyName = "FECHAENTRADA"
        Me.FECHAENTRADA.HeaderText = "Fecha EA"
        Me.FECHAENTRADA.Name = "FECHAENTRADA"
        Me.FECHAENTRADA.ReadOnly = True
        Me.FECHAENTRADA.Width = 73
        '
        'ENTRADAALMACEN
        '
        Me.ENTRADAALMACEN.DataPropertyName = "ENTRADAALMACEN"
        Me.ENTRADAALMACEN.HeaderText = "Entrada Almacén"
        Me.ENTRADAALMACEN.Name = "ENTRADAALMACEN"
        Me.ENTRADAALMACEN.ReadOnly = True
        Me.ENTRADAALMACEN.Width = 104
        '
        'BODEGAENTRADA
        '
        Me.BODEGAENTRADA.DataPropertyName = "BODEGAENTRADA"
        Me.BODEGAENTRADA.HeaderText = "Bod EA"
        Me.BODEGAENTRADA.Name = "BODEGAENTRADA"
        Me.BODEGAENTRADA.ReadOnly = True
        Me.BODEGAENTRADA.Width = 51
        '
        'FECHASALIDA
        '
        Me.FECHASALIDA.DataPropertyName = "FECHASALIDA"
        Me.FECHASALIDA.HeaderText = "Fecha SA"
        Me.FECHASALIDA.Name = "FECHASALIDA"
        Me.FECHASALIDA.ReadOnly = True
        Me.FECHASALIDA.Width = 73
        '
        'SALIDAALMACEN
        '
        Me.SALIDAALMACEN.DataPropertyName = "SALIDAALMACEN"
        Me.SALIDAALMACEN.HeaderText = "Salida Almacén"
        Me.SALIDAALMACEN.Name = "SALIDAALMACEN"
        Me.SALIDAALMACEN.ReadOnly = True
        Me.SALIDAALMACEN.Width = 96
        '
        'BODEGASALIDA
        '
        Me.BODEGASALIDA.DataPropertyName = "BODEGASALIDA"
        Me.BODEGASALIDA.HeaderText = "Bod Dest"
        Me.BODEGASALIDA.Name = "BODEGASALIDA"
        Me.BODEGASALIDA.ReadOnly = True
        Me.BODEGASALIDA.Width = 70
        '
        'REMISION
        '
        Me.REMISION.DataPropertyName = "REMISION"
        Me.REMISION.HeaderText = "Remisión"
        Me.REMISION.Name = "REMISION"
        Me.REMISION.ReadOnly = True
        Me.REMISION.Width = 75
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(507, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "A=Activo ; P=Pendiente ; I=Inactivo(estuvo en la bodega)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(507, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Historial del equipo (registros a partir del 03/02/2015)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_Componentes
        '
        Me.Dgv_Componentes.AllowUserToAddRows = False
        Me.Dgv_Componentes.AllowUserToDeleteRows = False
        Me.Dgv_Componentes.AllowUserToOrderColumns = True
        Me.Dgv_Componentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_Componentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDCOMPONENTE, Me.DataGridViewTextBoxColumn36, Me.DataGridViewCheckBoxColumn1})
        Me.Dgv_Componentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Componentes.Location = New System.Drawing.Point(0, 20)
        Me.Dgv_Componentes.MultiSelect = False
        Me.Dgv_Componentes.Name = "Dgv_Componentes"
        Me.Dgv_Componentes.ReadOnly = True
        Me.Dgv_Componentes.Size = New System.Drawing.Size(223, 115)
        Me.Dgv_Componentes.TabIndex = 2
        '
        'IDCOMPONENTE
        '
        Me.IDCOMPONENTE.DataPropertyName = "IDEQUIPO"
        Me.IDCOMPONENTE.FillWeight = 0.5155153!
        Me.IDCOMPONENTE.HeaderText = "IDEQUIPO"
        Me.IDCOMPONENTE.Name = "IDCOMPONENTE"
        Me.IDCOMPONENTE.ReadOnly = True
        Me.IDCOMPONENTE.Visible = False
        Me.IDCOMPONENTE.Width = 84
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "CODIGO"
        Me.DataGridViewTextBoxColumn36.FillWeight = 203.2368!
        Me.DataGridViewTextBoxColumn36.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "ACTIVO_FIJO"
        Me.DataGridViewCheckBoxColumn1.FillWeight = 190.8128!
        Me.DataGridViewCheckBoxColumn1.HeaderText = "ES ACTIVO FIJO"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.Width = 94
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(223, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Componentes del Equipo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Lb_Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(738, 23)
        Me.Lb_Titulo.TabIndex = 0
        Me.Lb_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDEQUIPO"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDEQUIPO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 84
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CODIGO"
        Me.DataGridViewTextBoxColumn2.FillWeight = 298.9899!
        Me.DataGridViewTextBoxColumn2.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 74
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "IDESTADO"
        Me.DataGridViewTextBoxColumn3.HeaderText = "IDESTADO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 87
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ESTADO"
        Me.DataGridViewTextBoxColumn4.FillWeight = 336.8621!
        Me.DataGridViewTextBoxColumn4.HeaderText = "ESTADO ACTUAL"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 121
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "IDPROVEEDOR"
        Me.DataGridViewTextBoxColumn5.HeaderText = "IDPROVEEDOR"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 111
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "PROVEEDOR"
        Me.DataGridViewTextBoxColumn6.FillWeight = 210.3547!
        Me.DataGridViewTextBoxColumn6.HeaderText = "PROVEEDOR"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "IDARTICULO"
        Me.DataGridViewTextBoxColumn7.HeaderText = "IDARTICULO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 97
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "NOMBRE_ARTICULO"
        Me.DataGridViewTextBoxColumn8.FillWeight = 258.5166!
        Me.DataGridViewTextBoxColumn8.HeaderText = "NOMBRE DE ARTICULO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 154
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "DESCRIPCION_ARTICULO"
        Me.DataGridViewTextBoxColumn9.FillWeight = 215.1119!
        Me.DataGridViewTextBoxColumn9.HeaderText = "DESCRIPCION DEL ARTICULO"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 186
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "DESCRIPCION_ADICIONAL"
        Me.DataGridViewTextBoxColumn10.FillWeight = 168.2348!
        Me.DataGridViewTextBoxColumn10.HeaderText = "DESCRIPCION ADICIONAL DEL EQUIPO"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 233
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "IDTIPO"
        Me.DataGridViewTextBoxColumn11.HeaderText = "IDTIPO"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        Me.DataGridViewTextBoxColumn11.Width = 68
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "TIPO"
        Me.DataGridViewTextBoxColumn12.FillWeight = 50.45852!
        Me.DataGridViewTextBoxColumn12.HeaderText = "TIPO DE ARTICULO"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 132
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "CODIGO_TIPO"
        Me.DataGridViewTextBoxColumn13.HeaderText = "CODIGO_TIPO"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 105
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "IDSUBTIPO"
        Me.DataGridViewTextBoxColumn14.HeaderText = "IDSUBTIPO"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 90
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "SUBTIPO"
        Me.DataGridViewTextBoxColumn15.FillWeight = 43.18421!
        Me.DataGridViewTextBoxColumn15.HeaderText = "SUBTIPO DE ARTICULO"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 154
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "CODIGO_SUBTIPO"
        Me.DataGridViewTextBoxColumn16.HeaderText = "CODIGO_SUBTIPO"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 127
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "COMPONENTE_DE"
        Me.DataGridViewTextBoxColumn17.HeaderText = "COMPONENTE_DE"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 129
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "IDBODEGA_INGRESO"
        Me.DataGridViewTextBoxColumn18.HeaderText = "IDBODEGA_INGRESO"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Visible = False
        Me.DataGridViewTextBoxColumn18.Width = 143
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "FECHA_INGRESO"
        Me.DataGridViewTextBoxColumn19.FillWeight = 38.46033!
        Me.DataGridViewTextBoxColumn19.HeaderText = "FECHA DE INGRESO A LA EMPRESA"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn19.Visible = False
        Me.DataGridViewTextBoxColumn19.Width = 199
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "BODEGA_INGRESO"
        Me.DataGridViewTextBoxColumn20.FillWeight = 21.62883!
        Me.DataGridViewTextBoxColumn20.HeaderText = "BODEGA INICIAL DE INGRESO"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn20.Visible = False
        Me.DataGridViewTextBoxColumn20.Width = 187
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "IDPERSONA_INGRESO"
        Me.DataGridViewTextBoxColumn21.FillWeight = 21.62883!
        Me.DataGridViewTextBoxColumn21.HeaderText = "IDPERSONA_INGRESO"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Visible = False
        Me.DataGridViewTextBoxColumn21.Width = 150
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "PERSONA_INGRESO"
        Me.DataGridViewTextBoxColumn22.FillWeight = 15.9972!
        Me.DataGridViewTextBoxColumn22.HeaderText = "PERSONA QUE INGRESO EL EQUIPO"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Visible = False
        Me.DataGridViewTextBoxColumn22.Width = 222
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "FECHA_REGISTRO"
        Me.DataGridViewTextBoxColumn23.FillWeight = 9.082086!
        Me.DataGridViewTextBoxColumn23.HeaderText = "FECHA DE REGISTRO EN EL SISTEMA"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Visible = False
        Me.DataGridViewTextBoxColumn23.Width = 228
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "IDPERSONA_REGISTRO"
        Me.DataGridViewTextBoxColumn24.FillWeight = 9.082086!
        Me.DataGridViewTextBoxColumn24.HeaderText = "IDPERSONA_REGISTRO"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Visible = False
        Me.DataGridViewTextBoxColumn24.Width = 157
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "PERSONA_REGISTRO"
        Me.DataGridViewTextBoxColumn25.FillWeight = 4.941341!
        Me.DataGridViewTextBoxColumn25.HeaderText = "PERSONA QUE REGISTRO EL EQUIPO"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Visible = False
        Me.DataGridViewTextBoxColumn25.Width = 229
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "IDPERSONA_ASIGNADA"
        Me.DataGridViewTextBoxColumn26.FillWeight = 4.941341!
        Me.DataGridViewTextBoxColumn26.HeaderText = "IDPERSONA_ASIGNADA"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Visible = False
        Me.DataGridViewTextBoxColumn26.Width = 156
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "PERSONA_ASIGNADA"
        Me.DataGridViewTextBoxColumn27.FillWeight = 1.65959!
        Me.DataGridViewTextBoxColumn27.HeaderText = "PERSONA ASIGNADA"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Visible = False
        Me.DataGridViewTextBoxColumn27.Width = 142
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "IDMODELO"
        Me.DataGridViewTextBoxColumn28.FillWeight = 1.65959!
        Me.DataGridViewTextBoxColumn28.HeaderText = "IDMODELO"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        Me.DataGridViewTextBoxColumn28.Visible = False
        Me.DataGridViewTextBoxColumn28.Width = 89
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "MODELO"
        Me.DataGridViewTextBoxColumn29.FillWeight = 0.6572587!
        Me.DataGridViewTextBoxColumn29.HeaderText = "MODELO"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        Me.DataGridViewTextBoxColumn29.Visible = False
        Me.DataGridViewTextBoxColumn29.Width = 78
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "IDMARCA"
        Me.DataGridViewTextBoxColumn30.FillWeight = 0.6572587!
        Me.DataGridViewTextBoxColumn30.HeaderText = "IDMARCA"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        Me.DataGridViewTextBoxColumn30.Visible = False
        Me.DataGridViewTextBoxColumn30.Width = 81
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "MARCA"
        Me.DataGridViewTextBoxColumn31.FillWeight = 0.5033312!
        Me.DataGridViewTextBoxColumn31.HeaderText = "MARCA"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        Me.DataGridViewTextBoxColumn31.Visible = False
        Me.DataGridViewTextBoxColumn31.Width = 70
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "CODIGOISMOCOL"
        Me.DataGridViewTextBoxColumn32.FillWeight = 1.108987!
        Me.DataGridViewTextBoxColumn32.HeaderText = "CODIGO ISMOCOL ANTIGUO"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        Me.DataGridViewTextBoxColumn32.Visible = False
        Me.DataGridViewTextBoxColumn32.Width = 177
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "CODIGOACCESS"
        Me.DataGridViewTextBoxColumn33.FillWeight = 0.7039959!
        Me.DataGridViewTextBoxColumn33.HeaderText = "CODIGO ACCESS ANTIGUO"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        Me.DataGridViewTextBoxColumn33.Visible = False
        Me.DataGridViewTextBoxColumn33.Width = 171
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "CODIGOMECANICO"
        Me.DataGridViewTextBoxColumn34.FillWeight = 0.5155153!
        Me.DataGridViewTextBoxColumn34.HeaderText = "CODIGO MECANICO ANTIGUO"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        Me.DataGridViewTextBoxColumn34.Visible = False
        Me.DataGridViewTextBoxColumn34.Width = 185
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "BODEGASALIDA"
        Me.DataGridViewTextBoxColumn38.HeaderText = "BODEGA DE DESTINO"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.ReadOnly = True
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn40.DataPropertyName = "ESTADO"
        Me.DataGridViewTextBoxColumn40.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        Me.DataGridViewTextBoxColumn40.ReadOnly = True
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn42.DataPropertyName = "CODIGO"
        Me.DataGridViewTextBoxColumn42.FillWeight = 203.2368!
        Me.DataGridViewTextBoxColumn42.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        Me.DataGridViewTextBoxColumn42.ReadOnly = True
        '
        'DataGridViewTextBoxColumn43
        '
        Me.DataGridViewTextBoxColumn43.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn43.DataPropertyName = "IDESTADO"
        Me.DataGridViewTextBoxColumn43.HeaderText = "IDESTADO"
        Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
        Me.DataGridViewTextBoxColumn43.ReadOnly = True
        Me.DataGridViewTextBoxColumn43.Visible = False
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn44.DataPropertyName = "IDPROVEEDOR"
        Me.DataGridViewTextBoxColumn44.HeaderText = "IDPROVEEDOR"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        Me.DataGridViewTextBoxColumn44.ReadOnly = True
        Me.DataGridViewTextBoxColumn44.Visible = False
        '
        'DataGridViewTextBoxColumn46
        '
        Me.DataGridViewTextBoxColumn46.DataPropertyName = "IDTIPO"
        Me.DataGridViewTextBoxColumn46.FillWeight = 0.5155153!
        Me.DataGridViewTextBoxColumn46.HeaderText = "IDTIPO"
        Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
        Me.DataGridViewTextBoxColumn46.ReadOnly = True
        Me.DataGridViewTextBoxColumn46.Visible = False
        Me.DataGridViewTextBoxColumn46.Width = 68
        '
        'DataGridViewTextBoxColumn51
        '
        Me.DataGridViewTextBoxColumn51.DataPropertyName = "IDBODEGA_INGRESO"
        Me.DataGridViewTextBoxColumn51.FillWeight = 21.62883!
        Me.DataGridViewTextBoxColumn51.HeaderText = "IDBODEGA_INGRESO"
        Me.DataGridViewTextBoxColumn51.Name = "DataGridViewTextBoxColumn51"
        Me.DataGridViewTextBoxColumn51.ReadOnly = True
        Me.DataGridViewTextBoxColumn51.Visible = False
        Me.DataGridViewTextBoxColumn51.Width = 143
        '
        'DataGridViewTextBoxColumn52
        '
        Me.DataGridViewTextBoxColumn52.DataPropertyName = "FECHA_INGRESO"
        Me.DataGridViewTextBoxColumn52.FillWeight = 38.46033!
        Me.DataGridViewTextBoxColumn52.HeaderText = "FECHA DE INGRESO A LA EMPRESA"
        Me.DataGridViewTextBoxColumn52.Name = "DataGridViewTextBoxColumn52"
        Me.DataGridViewTextBoxColumn52.ReadOnly = True
        Me.DataGridViewTextBoxColumn52.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn52.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn52.Visible = False
        Me.DataGridViewTextBoxColumn52.Width = 199
        '
        'DataGridViewTextBoxColumn60
        '
        Me.DataGridViewTextBoxColumn60.DataPropertyName = "IDMARCA"
        Me.DataGridViewTextBoxColumn60.FillWeight = 0.5155153!
        Me.DataGridViewTextBoxColumn60.HeaderText = "IDMARCA"
        Me.DataGridViewTextBoxColumn60.Name = "DataGridViewTextBoxColumn60"
        Me.DataGridViewTextBoxColumn60.ReadOnly = True
        Me.DataGridViewTextBoxColumn60.Visible = False
        Me.DataGridViewTextBoxColumn60.Width = 81
        '
        'DataGridViewTextBoxColumn62
        '
        Me.DataGridViewTextBoxColumn62.DataPropertyName = "MODELO"
        Me.DataGridViewTextBoxColumn62.FillWeight = 22.6251!
        Me.DataGridViewTextBoxColumn62.HeaderText = "MODELO"
        Me.DataGridViewTextBoxColumn62.Name = "DataGridViewTextBoxColumn62"
        Me.DataGridViewTextBoxColumn62.ReadOnly = True
        Me.DataGridViewTextBoxColumn62.Visible = False
        Me.DataGridViewTextBoxColumn62.Width = 78
        '
        'DataGridViewTextBoxColumn70
        '
        Me.DataGridViewTextBoxColumn70.DataPropertyName = "MODELO"
        Me.DataGridViewTextBoxColumn70.FillWeight = 22.6251!
        Me.DataGridViewTextBoxColumn70.HeaderText = "MODELO"
        Me.DataGridViewTextBoxColumn70.Name = "DataGridViewTextBoxColumn70"
        Me.DataGridViewTextBoxColumn70.Width = 78
        '
        'DataGridViewTextBoxColumn71
        '
        Me.DataGridViewTextBoxColumn71.DataPropertyName = "IDMARCA"
        Me.DataGridViewTextBoxColumn71.HeaderText = "IDMARCA"
        Me.DataGridViewTextBoxColumn71.Name = "DataGridViewTextBoxColumn71"
        Me.DataGridViewTextBoxColumn71.Visible = False
        Me.DataGridViewTextBoxColumn71.Width = 81
        '
        'DataGridViewTextBoxColumn72
        '
        Me.DataGridViewTextBoxColumn72.DataPropertyName = "MARCA"
        Me.DataGridViewTextBoxColumn72.FillWeight = 14.24611!
        Me.DataGridViewTextBoxColumn72.HeaderText = "MARCA"
        Me.DataGridViewTextBoxColumn72.Name = "DataGridViewTextBoxColumn72"
        Me.DataGridViewTextBoxColumn72.Width = 70
        '
        'DataGridViewTextBoxColumn73
        '
        Me.DataGridViewTextBoxColumn73.DataPropertyName = "CODIGOISMOCOL"
        Me.DataGridViewTextBoxColumn73.FillWeight = 1.108987!
        Me.DataGridViewTextBoxColumn73.HeaderText = "CODIGO ISMOCOL ANTIGUO"
        Me.DataGridViewTextBoxColumn73.Name = "DataGridViewTextBoxColumn73"
        Me.DataGridViewTextBoxColumn73.Visible = False
        Me.DataGridViewTextBoxColumn73.Width = 177
        '
        'DataGridViewTextBoxColumn74
        '
        Me.DataGridViewTextBoxColumn74.DataPropertyName = "CODIGOACCESS"
        Me.DataGridViewTextBoxColumn74.FillWeight = 0.7039959!
        Me.DataGridViewTextBoxColumn74.HeaderText = "CODIGO ACCESS ANTIGUO"
        Me.DataGridViewTextBoxColumn74.Name = "DataGridViewTextBoxColumn74"
        Me.DataGridViewTextBoxColumn74.Visible = False
        Me.DataGridViewTextBoxColumn74.Width = 171
        '
        'DataGridViewTextBoxColumn75
        '
        Me.DataGridViewTextBoxColumn75.DataPropertyName = "CODIGOMECANICO"
        Me.DataGridViewTextBoxColumn75.FillWeight = 0.5155153!
        Me.DataGridViewTextBoxColumn75.HeaderText = "CODIGO MECANICO ANTIGUO"
        Me.DataGridViewTextBoxColumn75.Name = "DataGridViewTextBoxColumn75"
        Me.DataGridViewTextBoxColumn75.Visible = False
        Me.DataGridViewTextBoxColumn75.Width = 185
        '
        'NetBarGroupControlContainer3
        '
        Me.NetBarGroupControlContainer3.Name = "NetBarGroupControlContainer3"
        Me.NetBarGroupControlContainer3.Size = New System.Drawing.Size(0, 0)
        Me.NetBarGroupControlContainer3.TabIndex = 0
        '
        'Cu_ActivosFijos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pn_ContenedorPrincipal)
        Me.Controls.Add(Me.Nbc_Equipos)
        Me.Name = "Cu_ActivosFijos"
        Me.Size = New System.Drawing.Size(958, 510)
        Me.Nbc_Equipos.ResumeLayout(False)
        Me.NetBarGroupControlContainer1.ResumeLayout(False)
        Me.NetBarGroupControlContainer1.PerformLayout()
        Me.Pn_ContenedorPrincipal.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Dgv_Equipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.Dgv_Historial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_Componentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Nbc_Equipos As NetBarControl.NetBarControl
    Friend WithEvents Pn_ContenedorPrincipal As System.Windows.Forms.Panel
    Friend WithEvents Nbg_Administracion As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_AdministrarTipos As NetBarControl.NetBarItem
    Friend WithEvents Lb_Titulo As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Pg_DetalleLista As System.Windows.Forms.PropertyGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Dgv_Historial As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv_Componentes As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn70 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn71 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn72 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn73 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn74 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn75 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn43 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn44 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn46 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn51 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn52 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn60 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn62 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nbg_Traslados As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_PendientesEnviados As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EnviadosRecibidos As NetBarControl.NetBarItem
    Friend WithEvents Nbi_PendientesRecibir As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Recibidos As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Filtrar As NetBarControl.NetBarGroup
    Friend WithEvents NetBarGroupControlContainer3 As NetBarControl.NetBarGroupControlContainer
    Friend WithEvents NetBarGroupControlContainer1 As NetBarControl.NetBarGroupControlContainer
    Friend WithEvents Cb_FiltrarPor1 As System.Windows.Forms.ComboBox
    Friend WithEvents Ck_Filtro1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Tx_ValorFiltro1 As System.Windows.Forms.TextBox
    Friend WithEvents Tx_ValorFiltro3 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_FiltrarPor3 As System.Windows.Forms.ComboBox
    Friend WithEvents Ck_Filtro3 As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_ValorFiltro2 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_FiltrarPor2 As System.Windows.Forms.ComboBox
    Friend WithEvents Ck_Filtro2 As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Filtrar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Nbi_RestaurarEquipo As NetBarControl.NetBarItem
    Friend WithEvents IDCOMPONENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Nbg_Equipo As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CargarEquipos As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ClonarEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_DarBaja As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EliminarEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EstadoUso As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerCaracteristicas As NetBarControl.NetBarItem
    Friend WithEvents ESTADOBODEGA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAENTRADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTRADAALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BODEGAENTRADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHASALIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALIDAALMACEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BODEGASALIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REMISION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nbg_RevisiónExterna As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_CargarRevisionesExternas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_AnularRevisiónExterna As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerRevisiónExterna As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarRevisiónExterna As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CerrarRevisiónExterna As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirRevisiónExterna As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearRevisiónExterna As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarRevisiónExterna As NetBarControl.NetBarItem
    Friend WithEvents Dgv_Equipos As System.Windows.Forms.DataGridView
    Friend WithEvents Nbi_VerHojaVida As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirPazSalvo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirStickerEquipo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Asegurado As NetBarControl.NetBarItem

End Class
