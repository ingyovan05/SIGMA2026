<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Contrato
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
        Me.Dgv_Contratos = New System.Windows.Forms.DataGridView()
        Me.LISTACONTRATOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lb_CantidadResultados = New System.Windows.Forms.Label()
        Me.Nbc_Contrato = New NetBarControl.NetBarControl()
        Me.Nbg_Contrato = New NetBarControl.NetBarGroup()
        Me.Nbi_Cargar_Contratos = New NetBarControl.NetBarItem()
        Me.Nbi_VerContrato = New NetBarControl.NetBarItem()
        Me.Nbi_Editar = New NetBarControl.NetBarItem()
        Me.Nbi_Buscar = New NetBarControl.NetBarItem()
        Me.Nbi_Prorrogar_Contrato = New NetBarControl.NetBarItem()
        Me.Nbi_Otrosi_Contrato = New NetBarControl.NetBarItem()
        Me.Nbi_Terminar = New NetBarControl.NetBarItem()
        Me.Nbi_Suspender = New NetBarControl.NetBarItem()
        Me.Nbi_Extender = New NetBarControl.NetBarItem()
        Me.Nbi_Activar = New NetBarControl.NetBarItem()
        Me.Nbi_Reclasificar = New NetBarControl.NetBarItem()
        Me.Nbi_RevContratosXterminar = New NetBarControl.NetBarItem()
        Me.Nbi_GestionarProrrogas = New NetBarControl.NetBarItem()
        Me.Nbi_HistorialContratos = New NetBarControl.NetBarItem()
        Me.Nbg_Proyecto = New NetBarControl.NetBarGroup()
        Me.Nbi_VincularBase = New NetBarControl.NetBarItem()
        Me.Nbi_DesvincularBase = New NetBarControl.NetBarItem()
        Me.Nbi_CambiarTurno = New NetBarControl.NetBarItem()
        Me.Nbg_Imprimir = New NetBarControl.NetBarGroup()
        Me.Nbi_FormatosContratación = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirBloque = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirProrrogas = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirOtrosi = New NetBarControl.NetBarItem()
        Me.Nbi_Imprimir = New NetBarControl.NetBarItem()
        Me.Nbi_ImpContratoAnterior = New NetBarControl.NetBarItem()
        Me.Pg_Detalles = New System.Windows.Forms.PropertyGrid()
        Me.Lb_Propiedades = New System.Windows.Forms.Label()
        Me.Sc_Contratos = New System.Windows.Forms.SplitContainer()
        Me.Sc_Detalles = New System.Windows.Forms.SplitContainer()
        Me.Dgv_Prorrogas = New System.Windows.Forms.DataGridView()
        Me.DGVTBC_Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogasConsecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogasFechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogasFechaFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogasFechaFirma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogasDuracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogasTipoDuracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogasUsuarioModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogasFechaModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogaIdContratoProrroga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cms_OpcionesProrrogas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_ImprimirProrrogas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_ImprimirOtrosi = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGVTBC_ProrrogaIdContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogaUsuarioregistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogaIdUsuarioregistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogaFechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogaIdUsuarioModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ProrrogaEstadoProrroga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_LugarFirma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lb_TituloProrrogas = New System.Windows.Forms.Label()
        Me.Dgv_Conceptos = New System.Windows.Forms.DataGridView()
        Me.DGVTBC_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_VALOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_PERIODICIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnVistaDatos = New System.Windows.Forms.Panel()
        Me.PnDetalle = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        CType(Me.Dgv_Contratos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LISTACONTRATOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sc_Contratos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sc_Contratos.Panel1.SuspendLayout()
        Me.Sc_Contratos.Panel2.SuspendLayout()
        Me.Sc_Contratos.SuspendLayout()
        CType(Me.Sc_Detalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sc_Detalles.Panel1.SuspendLayout()
        Me.Sc_Detalles.Panel2.SuspendLayout()
        Me.Sc_Detalles.SuspendLayout()
        CType(Me.Dgv_Prorrogas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_OpcionesProrrogas.SuspendLayout()
        CType(Me.Dgv_Conceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnVistaDatos.SuspendLayout()
        Me.PnDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_Contratos
        '
        Me.Dgv_Contratos.AllowUserToAddRows = False
        Me.Dgv_Contratos.AllowUserToDeleteRows = False
        Me.Dgv_Contratos.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Contratos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Contratos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Contratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Contratos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Contratos.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_Contratos.MultiSelect = False
        Me.Dgv_Contratos.Name = "Dgv_Contratos"
        Me.Dgv_Contratos.ReadOnly = True
        Me.Dgv_Contratos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Contratos.Size = New System.Drawing.Size(588, 466)
        Me.Dgv_Contratos.TabIndex = 2
        '
        'Lb_CantidadResultados
        '
        Me.Lb_CantidadResultados.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Lb_CantidadResultados.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_CantidadResultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadResultados.ForeColor = System.Drawing.Color.Black
        Me.Lb_CantidadResultados.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CantidadResultados.Name = "Lb_CantidadResultados"
        Me.Lb_CantidadResultados.Size = New System.Drawing.Size(588, 18)
        Me.Lb_CantidadResultados.TabIndex = 9
        Me.Lb_CantidadResultados.Text = "Cantidad de Contratos:"
        Me.Lb_CantidadResultados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Nbc_Contrato
        '
        Me.Nbc_Contrato.ActiveGroup = Me.Nbg_Contrato
        Me.Nbc_Contrato.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_Contrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Contrato.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_Contrato, Me.Nbg_Proyecto, Me.Nbg_Imprimir})
        Me.Nbc_Contrato.GroupsFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Contrato.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_Contrato.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_Contrato.Location = New System.Drawing.Point(0, 0)
        Me.Nbc_Contrato.Name = "Nbc_Contrato"
        Me.Nbc_Contrato.ShowOverflowPanel = False
        Me.Nbc_Contrato.Size = New System.Drawing.Size(190, 625)
        Me.Nbc_Contrato.TabIndex = 11
        Me.Nbc_Contrato.Tag = "650"
        Me.Nbc_Contrato.Text = "NetBarControl1"
        '
        'Nbg_Contrato
        '
        Me.Nbg_Contrato.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_Cargar_Contratos, Me.Nbi_VerContrato, Me.Nbi_Editar, Me.Nbi_Buscar, Me.Nbi_Prorrogar_Contrato, Me.Nbi_Otrosi_Contrato, Me.Nbi_Terminar, Me.Nbi_Suspender, Me.Nbi_Extender, Me.Nbi_Activar, Me.Nbi_Reclasificar, Me.Nbi_RevContratosXterminar, Me.Nbi_GestionarProrrogas, Me.Nbi_HistorialContratos})
        Me.Nbg_Contrato.Name = "Nbg_Contrato"
        Me.Nbg_Contrato.SmallImage = Global.Contrato.My.Resources.Resources.FContrato
        Me.Nbg_Contrato.Tag = "653"
        Me.Nbg_Contrato.Text = "Contrato"
        '
        'Nbi_Cargar_Contratos
        '
        Me.Nbi_Cargar_Contratos.Name = "Nbi_Cargar_Contratos"
        Me.Nbi_Cargar_Contratos.Tag = "654"
        Me.Nbi_Cargar_Contratos.Text = "Cargar Contratos"
        '
        'Nbi_VerContrato
        '
        Me.Nbi_VerContrato.Name = "Nbi_VerContrato"
        Me.Nbi_VerContrato.SmallImage = Global.Contrato.My.Resources.Resources.FVerContrato
        Me.Nbi_VerContrato.Tag = "655"
        Me.Nbi_VerContrato.Text = "Ver Contrato"
        '
        'Nbi_Editar
        '
        Me.Nbi_Editar.Name = "Nbi_Editar"
        Me.Nbi_Editar.SmallImage = Global.Contrato.My.Resources.Resources.FEditarContrato
        Me.Nbi_Editar.Tag = "656"
        Me.Nbi_Editar.Text = "Editar Contrato"
        '
        'Nbi_Buscar
        '
        Me.Nbi_Buscar.Name = "Nbi_Buscar"
        Me.Nbi_Buscar.Tag = "665"
        Me.Nbi_Buscar.Text = "Buscar Contrato"
        '
        'Nbi_Prorrogar_Contrato
        '
        Me.Nbi_Prorrogar_Contrato.Name = "Nbi_Prorrogar_Contrato"
        Me.Nbi_Prorrogar_Contrato.SmallImage = Global.Contrato.My.Resources.Resources.FProrrogas
        Me.Nbi_Prorrogar_Contrato.Tag = "662"
        Me.Nbi_Prorrogar_Contrato.Text = "Prorrogar Contrato"
        '
        'Nbi_Otrosi_Contrato
        '
        Me.Nbi_Otrosi_Contrato.Name = "Nbi_Otrosi_Contrato"
        Me.Nbi_Otrosi_Contrato.Tag = "717"
        Me.Nbi_Otrosi_Contrato.Text = "Registrar Otrosí"
        '
        'Nbi_Terminar
        '
        Me.Nbi_Terminar.ForeColor = System.Drawing.Color.Red
        Me.Nbi_Terminar.Name = "Nbi_Terminar"
        Me.Nbi_Terminar.SmallImage = Global.Contrato.My.Resources.Resources.FTerminarContrato
        Me.Nbi_Terminar.Tag = "660"
        Me.Nbi_Terminar.Text = "Terminar Contrato"
        '
        'Nbi_Suspender
        '
        Me.Nbi_Suspender.Name = "Nbi_Suspender"
        Me.Nbi_Suspender.Tag = "724"
        Me.Nbi_Suspender.Text = "Suspender Contrato"
        '
        'Nbi_Extender
        '
        Me.Nbi_Extender.Name = "Nbi_Extender"
        Me.Nbi_Extender.Tag = "723"
        Me.Nbi_Extender.Text = "Extender Contrato"
        '
        'Nbi_Activar
        '
        Me.Nbi_Activar.Name = "Nbi_Activar"
        Me.Nbi_Activar.Tag = "658"
        Me.Nbi_Activar.Text = "Activar Contrato"
        '
        'Nbi_Reclasificar
        '
        Me.Nbi_Reclasificar.Name = "Nbi_Reclasificar"
        Me.Nbi_Reclasificar.Tag = "746"
        Me.Nbi_Reclasificar.Text = "Reclasificar Contrato"
        '
        'Nbi_RevContratosXterminar
        '
        Me.Nbi_RevContratosXterminar.Name = "Nbi_RevContratosXterminar"
        Me.Nbi_RevContratosXterminar.Tag = "747"
        Me.Nbi_RevContratosXterminar.Text = "Rev. Contratos por Terminar"
        '
        'Nbi_GestionarProrrogas
        '
        Me.Nbi_GestionarProrrogas.Name = "Nbi_GestionarProrrogas"
        Me.Nbi_GestionarProrrogas.Tag = "748"
        Me.Nbi_GestionarProrrogas.Text = "Gestionar Prórrogas"
        '
        'Nbi_HistorialContratos
        '
        Me.Nbi_HistorialContratos.Name = "Nbi_HistorialContratos"
        Me.Nbi_HistorialContratos.Tag = "888"
        Me.Nbi_HistorialContratos.Text = "Historial Cambios"
        '
        'Nbg_Proyecto
        '
        Me.Nbg_Proyecto.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_VincularBase, Me.Nbi_DesvincularBase, Me.Nbi_CambiarTurno})
        Me.Nbg_Proyecto.Name = "Nbg_Proyecto"
        Me.Nbg_Proyecto.SmallImage = Global.Contrato.My.Resources.Resources.FProyecto
        Me.Nbg_Proyecto.Tag = "666"
        Me.Nbg_Proyecto.Text = "Proyecto"
        '
        'Nbi_VincularBase
        '
        Me.Nbi_VincularBase.Name = "Nbi_VincularBase"
        Me.Nbi_VincularBase.SmallImage = Global.Contrato.My.Resources.Resources.FVincularPersona
        Me.Nbi_VincularBase.Tag = "667"
        Me.Nbi_VincularBase.Text = "Vincular Base"
        '
        'Nbi_DesvincularBase
        '
        Me.Nbi_DesvincularBase.Name = "Nbi_DesvincularBase"
        Me.Nbi_DesvincularBase.SmallImage = Global.Contrato.My.Resources.Resources.FDesvincularPersona
        Me.Nbi_DesvincularBase.Tag = "668"
        Me.Nbi_DesvincularBase.Text = "Desvincular Base"
        '
        'Nbi_CambiarTurno
        '
        Me.Nbi_CambiarTurno.Name = "Nbi_CambiarTurno"
        Me.Nbi_CambiarTurno.SmallImage = Global.Contrato.My.Resources.Resources.FCambiarTurno
        Me.Nbi_CambiarTurno.Tag = "669"
        Me.Nbi_CambiarTurno.Text = "Cambiar Turno"
        '
        'Nbg_Imprimir
        '
        Me.Nbg_Imprimir.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_FormatosContratación, Me.Nbi_ImprimirBloque, Me.Nbi_ImprimirProrrogas, Me.Nbi_ImprimirOtrosi, Me.Nbi_Imprimir, Me.Nbi_ImpContratoAnterior})
        Me.Nbg_Imprimir.Name = "Nbg_Imprimir"
        Me.Nbg_Imprimir.SmallImage = Global.Contrato.My.Resources.Resources.Printer
        Me.Nbg_Imprimir.Tag = "670"
        Me.Nbg_Imprimir.Text = "Imprimir"
        '
        'Nbi_FormatosContratación
        '
        Me.Nbi_FormatosContratación.Name = "Nbi_FormatosContratación"
        Me.Nbi_FormatosContratación.SmallImage = Global.Contrato.My.Resources.Resources.FImprimirFormatos
        Me.Nbi_FormatosContratación.Tag = "671"
        Me.Nbi_FormatosContratación.Text = "Formatos Contratación"
        '
        'Nbi_ImprimirBloque
        '
        Me.Nbi_ImprimirBloque.Name = "Nbi_ImprimirBloque"
        Me.Nbi_ImprimirBloque.SmallImage = Global.Contrato.My.Resources.Resources.FImprimirBloque
        Me.Nbi_ImprimirBloque.Tag = "672"
        Me.Nbi_ImprimirBloque.Text = "Imprimir Bloque"
        '
        'Nbi_ImprimirProrrogas
        '
        Me.Nbi_ImprimirProrrogas.Name = "Nbi_ImprimirProrrogas"
        Me.Nbi_ImprimirProrrogas.Tag = "730"
        Me.Nbi_ImprimirProrrogas.Text = "Imprimir Prórrogas"
        '
        'Nbi_ImprimirOtrosi
        '
        Me.Nbi_ImprimirOtrosi.Name = "Nbi_ImprimirOtrosi"
        Me.Nbi_ImprimirOtrosi.Tag = "731"
        Me.Nbi_ImprimirOtrosi.Text = "Imprimir Otrosí"
        '
        'Nbi_Imprimir
        '
        Me.Nbi_Imprimir.Name = "Nbi_Imprimir"
        Me.Nbi_Imprimir.Tag = "736"
        Me.Nbi_Imprimir.Text = "Imprimir F-014 Modificado"
        '
        'Nbi_ImpContratoAnterior
        '
        Me.Nbi_ImpContratoAnterior.Name = "Nbi_ImpContratoAnterior"
        Me.Nbi_ImpContratoAnterior.Tag = "886"
        Me.Nbi_ImpContratoAnterior.Text = "Contrato Rev.  Anterior"
        '
        'Pg_Detalles
        '
        Me.Pg_Detalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pg_Detalles.Location = New System.Drawing.Point(0, 18)
        Me.Pg_Detalles.Name = "Pg_Detalles"
        Me.Pg_Detalles.Size = New System.Drawing.Size(242, 466)
        Me.Pg_Detalles.TabIndex = 1
        '
        'Lb_Propiedades
        '
        Me.Lb_Propiedades.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Lb_Propiedades.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Propiedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Propiedades.ForeColor = System.Drawing.Color.Black
        Me.Lb_Propiedades.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Propiedades.Name = "Lb_Propiedades"
        Me.Lb_Propiedades.Size = New System.Drawing.Size(242, 18)
        Me.Lb_Propiedades.TabIndex = 2
        Me.Lb_Propiedades.Text = "Propiedades"
        Me.Lb_Propiedades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Sc_Contratos
        '
        Me.Sc_Contratos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sc_Contratos.Location = New System.Drawing.Point(0, 0)
        Me.Sc_Contratos.Name = "Sc_Contratos"
        '
        'Sc_Contratos.Panel1
        '
        Me.Sc_Contratos.Panel1.Controls.Add(Me.Dgv_Contratos)
        Me.Sc_Contratos.Panel1.Controls.Add(Me.Lb_CantidadResultados)
        '
        'Sc_Contratos.Panel2
        '
        Me.Sc_Contratos.Panel2.Controls.Add(Me.Pg_Detalles)
        Me.Sc_Contratos.Panel2.Controls.Add(Me.Lb_Propiedades)
        Me.Sc_Contratos.Size = New System.Drawing.Size(834, 484)
        Me.Sc_Contratos.SplitterDistance = 588
        Me.Sc_Contratos.TabIndex = 13
        '
        'Sc_Detalles
        '
        Me.Sc_Detalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sc_Detalles.Location = New System.Drawing.Point(0, 0)
        Me.Sc_Detalles.Name = "Sc_Detalles"
        '
        'Sc_Detalles.Panel1
        '
        Me.Sc_Detalles.Panel1.Controls.Add(Me.Dgv_Prorrogas)
        Me.Sc_Detalles.Panel1.Controls.Add(Me.Lb_TituloProrrogas)
        '
        'Sc_Detalles.Panel2
        '
        Me.Sc_Detalles.Panel2.Controls.Add(Me.Dgv_Conceptos)
        Me.Sc_Detalles.Panel2.Controls.Add(Me.Label1)
        Me.Sc_Detalles.Size = New System.Drawing.Size(834, 138)
        Me.Sc_Detalles.SplitterDistance = 520
        Me.Sc_Detalles.TabIndex = 8
        '
        'Dgv_Prorrogas
        '
        Me.Dgv_Prorrogas.AllowUserToAddRows = False
        Me.Dgv_Prorrogas.AllowUserToDeleteRows = False
        Me.Dgv_Prorrogas.AllowUserToResizeRows = False
        Me.Dgv_Prorrogas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Prorrogas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Prorrogas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Prorrogas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBC_Tipo, Me.DGVTBC_ProrrogasConsecutivo, Me.DGVTBC_ProrrogasFechaInicio, Me.DGVTBC_ProrrogasFechaFin, Me.DGVTBC_ProrrogasFechaFirma, Me.DGVTBC_ProrrogasDuracion, Me.DGVTBC_ProrrogasTipoDuracion, Me.DGVTBC_ProrrogasUsuarioModifica, Me.DGVTBC_ProrrogasFechaModifica, Me.DGVTBC_ProrrogaIdContratoProrroga, Me.DGVTBC_ProrrogaIdContrato, Me.DGVTBC_ProrrogaUsuarioregistra, Me.DGVTBC_ProrrogaIdUsuarioregistra, Me.DGVTBC_ProrrogaFechaRegistro, Me.DGVTBC_ProrrogaIdUsuarioModifica, Me.DGVTBC_ProrrogaEstadoProrroga, Me.DGVTBC_LugarFirma})
        Me.Dgv_Prorrogas.ContextMenuStrip = Me.Cms_OpcionesProrrogas
        Me.Dgv_Prorrogas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Prorrogas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Prorrogas.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_Prorrogas.Margin = New System.Windows.Forms.Padding(2)
        Me.Dgv_Prorrogas.MultiSelect = False
        Me.Dgv_Prorrogas.Name = "Dgv_Prorrogas"
        Me.Dgv_Prorrogas.ReadOnly = True
        Me.Dgv_Prorrogas.RowHeadersVisible = False
        Me.Dgv_Prorrogas.RowTemplate.Height = 24
        Me.Dgv_Prorrogas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Prorrogas.Size = New System.Drawing.Size(520, 120)
        Me.Dgv_Prorrogas.TabIndex = 6
        '
        'DGVTBC_Tipo
        '
        Me.DGVTBC_Tipo.DataPropertyName = "TIPO"
        Me.DGVTBC_Tipo.HeaderText = "Tipo"
        Me.DGVTBC_Tipo.Name = "DGVTBC_Tipo"
        Me.DGVTBC_Tipo.ReadOnly = True
        Me.DGVTBC_Tipo.ToolTipText = "Tipo"
        '
        'DGVTBC_ProrrogasConsecutivo
        '
        Me.DGVTBC_ProrrogasConsecutivo.DataPropertyName = "CONSECUTIVOPRORROGA"
        Me.DGVTBC_ProrrogasConsecutivo.HeaderText = "Consec."
        Me.DGVTBC_ProrrogasConsecutivo.Name = "DGVTBC_ProrrogasConsecutivo"
        Me.DGVTBC_ProrrogasConsecutivo.ReadOnly = True
        Me.DGVTBC_ProrrogasConsecutivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVTBC_ProrrogasConsecutivo.ToolTipText = "Consecutivo"
        '
        'DGVTBC_ProrrogasFechaInicio
        '
        Me.DGVTBC_ProrrogasFechaInicio.DataPropertyName = "FECHAINICIO"
        Me.DGVTBC_ProrrogasFechaInicio.HeaderText = "Fecha Inicio"
        Me.DGVTBC_ProrrogasFechaInicio.Name = "DGVTBC_ProrrogasFechaInicio"
        Me.DGVTBC_ProrrogasFechaInicio.ReadOnly = True
        Me.DGVTBC_ProrrogasFechaInicio.ToolTipText = "Fecha de inicio"
        '
        'DGVTBC_ProrrogasFechaFin
        '
        Me.DGVTBC_ProrrogasFechaFin.DataPropertyName = "FECHAFIN"
        Me.DGVTBC_ProrrogasFechaFin.HeaderText = "Fecha Fin"
        Me.DGVTBC_ProrrogasFechaFin.Name = "DGVTBC_ProrrogasFechaFin"
        Me.DGVTBC_ProrrogasFechaFin.ReadOnly = True
        Me.DGVTBC_ProrrogasFechaFin.ToolTipText = "Fecha de finalización"
        '
        'DGVTBC_ProrrogasFechaFirma
        '
        Me.DGVTBC_ProrrogasFechaFirma.DataPropertyName = "FECHAFIRMA"
        Me.DGVTBC_ProrrogasFechaFirma.HeaderText = "Firma"
        Me.DGVTBC_ProrrogasFechaFirma.Name = "DGVTBC_ProrrogasFechaFirma"
        Me.DGVTBC_ProrrogasFechaFirma.ReadOnly = True
        Me.DGVTBC_ProrrogasFechaFirma.ToolTipText = "Fecha de firma"
        '
        'DGVTBC_ProrrogasDuracion
        '
        Me.DGVTBC_ProrrogasDuracion.DataPropertyName = "DURACION"
        Me.DGVTBC_ProrrogasDuracion.HeaderText = "Duración"
        Me.DGVTBC_ProrrogasDuracion.Name = "DGVTBC_ProrrogasDuracion"
        Me.DGVTBC_ProrrogasDuracion.ReadOnly = True
        Me.DGVTBC_ProrrogasDuracion.ToolTipText = "Duración"
        '
        'DGVTBC_ProrrogasTipoDuracion
        '
        Me.DGVTBC_ProrrogasTipoDuracion.DataPropertyName = "CODIGOTIPODURACION"
        Me.DGVTBC_ProrrogasTipoDuracion.HeaderText = "Tipo Duración"
        Me.DGVTBC_ProrrogasTipoDuracion.Name = "DGVTBC_ProrrogasTipoDuracion"
        Me.DGVTBC_ProrrogasTipoDuracion.ReadOnly = True
        Me.DGVTBC_ProrrogasTipoDuracion.ToolTipText = "Tipo Duración"
        '
        'DGVTBC_ProrrogasUsuarioModifica
        '
        Me.DGVTBC_ProrrogasUsuarioModifica.DataPropertyName = "USUARIOMODIFICA"
        Me.DGVTBC_ProrrogasUsuarioModifica.HeaderText = "Usuario Modifica"
        Me.DGVTBC_ProrrogasUsuarioModifica.Name = "DGVTBC_ProrrogasUsuarioModifica"
        Me.DGVTBC_ProrrogasUsuarioModifica.ReadOnly = True
        Me.DGVTBC_ProrrogasUsuarioModifica.ToolTipText = "Usuario Modifica"
        '
        'DGVTBC_ProrrogasFechaModifica
        '
        Me.DGVTBC_ProrrogasFechaModifica.DataPropertyName = "FECHAMODIFICACION"
        Me.DGVTBC_ProrrogasFechaModifica.HeaderText = "Fecha modificación"
        Me.DGVTBC_ProrrogasFechaModifica.Name = "DGVTBC_ProrrogasFechaModifica"
        Me.DGVTBC_ProrrogasFechaModifica.ReadOnly = True
        Me.DGVTBC_ProrrogasFechaModifica.ToolTipText = "Fecha modificación"
        '
        'DGVTBC_ProrrogaIdContratoProrroga
        '
        Me.DGVTBC_ProrrogaIdContratoProrroga.ContextMenuStrip = Me.Cms_OpcionesProrrogas
        Me.DGVTBC_ProrrogaIdContratoProrroga.DataPropertyName = "IDCONTRATOPRORROGA"
        Me.DGVTBC_ProrrogaIdContratoProrroga.HeaderText = "IDCONTRATOPRORROGA"
        Me.DGVTBC_ProrrogaIdContratoProrroga.Name = "DGVTBC_ProrrogaIdContratoProrroga"
        Me.DGVTBC_ProrrogaIdContratoProrroga.ReadOnly = True
        Me.DGVTBC_ProrrogaIdContratoProrroga.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVTBC_ProrrogaIdContratoProrroga.Visible = False
        '
        'Cms_OpcionesProrrogas
        '
        Me.Cms_OpcionesProrrogas.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_OpcionesProrrogas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_ImprimirProrrogas, Me.Tsmi_ImprimirOtrosi})
        Me.Cms_OpcionesProrrogas.Name = "Cms_OpcionesProrrogas"
        Me.Cms_OpcionesProrrogas.Size = New System.Drawing.Size(184, 48)
        '
        'Tsmi_ImprimirProrrogas
        '
        Me.Tsmi_ImprimirProrrogas.Name = "Tsmi_ImprimirProrrogas"
        Me.Tsmi_ImprimirProrrogas.Size = New System.Drawing.Size(183, 22)
        Me.Tsmi_ImprimirProrrogas.Tag = "730"
        Me.Tsmi_ImprimirProrrogas.Text = "Imprimir prórrogas..."
        '
        'Tsmi_ImprimirOtrosi
        '
        Me.Tsmi_ImprimirOtrosi.Name = "Tsmi_ImprimirOtrosi"
        Me.Tsmi_ImprimirOtrosi.Size = New System.Drawing.Size(183, 22)
        Me.Tsmi_ImprimirOtrosi.Tag = "731"
        Me.Tsmi_ImprimirOtrosi.Text = "Imprimir otrosí..."
        '
        'DGVTBC_ProrrogaIdContrato
        '
        Me.DGVTBC_ProrrogaIdContrato.DataPropertyName = "IDCONTRATO"
        Me.DGVTBC_ProrrogaIdContrato.HeaderText = "IDCONTRATO"
        Me.DGVTBC_ProrrogaIdContrato.Name = "DGVTBC_ProrrogaIdContrato"
        Me.DGVTBC_ProrrogaIdContrato.ReadOnly = True
        Me.DGVTBC_ProrrogaIdContrato.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVTBC_ProrrogaIdContrato.Visible = False
        '
        'DGVTBC_ProrrogaUsuarioregistra
        '
        Me.DGVTBC_ProrrogaUsuarioregistra.DataPropertyName = "USUARIOREGISTRA"
        Me.DGVTBC_ProrrogaUsuarioregistra.HeaderText = "USUARIOREGISTRA"
        Me.DGVTBC_ProrrogaUsuarioregistra.Name = "DGVTBC_ProrrogaUsuarioregistra"
        Me.DGVTBC_ProrrogaUsuarioregistra.ReadOnly = True
        Me.DGVTBC_ProrrogaUsuarioregistra.ToolTipText = "Usuario Registra"
        Me.DGVTBC_ProrrogaUsuarioregistra.Visible = False
        '
        'DGVTBC_ProrrogaIdUsuarioregistra
        '
        Me.DGVTBC_ProrrogaIdUsuarioregistra.DataPropertyName = "IDUSUARIOREGISTRA"
        Me.DGVTBC_ProrrogaIdUsuarioregistra.HeaderText = "IDUSUARIOREGISTRA"
        Me.DGVTBC_ProrrogaIdUsuarioregistra.Name = "DGVTBC_ProrrogaIdUsuarioregistra"
        Me.DGVTBC_ProrrogaIdUsuarioregistra.ReadOnly = True
        Me.DGVTBC_ProrrogaIdUsuarioregistra.Visible = False
        '
        'DGVTBC_ProrrogaFechaRegistro
        '
        Me.DGVTBC_ProrrogaFechaRegistro.DataPropertyName = "FECHAREGISTRO"
        Me.DGVTBC_ProrrogaFechaRegistro.HeaderText = "FECHAREGISTRO"
        Me.DGVTBC_ProrrogaFechaRegistro.Name = "DGVTBC_ProrrogaFechaRegistro"
        Me.DGVTBC_ProrrogaFechaRegistro.ReadOnly = True
        Me.DGVTBC_ProrrogaFechaRegistro.Visible = False
        '
        'DGVTBC_ProrrogaIdUsuarioModifica
        '
        Me.DGVTBC_ProrrogaIdUsuarioModifica.DataPropertyName = "IDUSUARIOMODIFICA"
        Me.DGVTBC_ProrrogaIdUsuarioModifica.HeaderText = "IDUSUARIOMODIFICA"
        Me.DGVTBC_ProrrogaIdUsuarioModifica.Name = "DGVTBC_ProrrogaIdUsuarioModifica"
        Me.DGVTBC_ProrrogaIdUsuarioModifica.ReadOnly = True
        Me.DGVTBC_ProrrogaIdUsuarioModifica.Visible = False
        '
        'DGVTBC_ProrrogaEstadoProrroga
        '
        Me.DGVTBC_ProrrogaEstadoProrroga.DataPropertyName = "ESTADOPRORROGA"
        Me.DGVTBC_ProrrogaEstadoProrroga.HeaderText = "ESTADOPRORROGA"
        Me.DGVTBC_ProrrogaEstadoProrroga.Name = "DGVTBC_ProrrogaEstadoProrroga"
        Me.DGVTBC_ProrrogaEstadoProrroga.ReadOnly = True
        Me.DGVTBC_ProrrogaEstadoProrroga.ToolTipText = "Estado"
        Me.DGVTBC_ProrrogaEstadoProrroga.Visible = False
        '
        'DGVTBC_LugarFirma
        '
        Me.DGVTBC_LugarFirma.DataPropertyName = "LUGARFIRMA"
        Me.DGVTBC_LugarFirma.HeaderText = "LUGARFIRMA"
        Me.DGVTBC_LugarFirma.Name = "DGVTBC_LugarFirma"
        Me.DGVTBC_LugarFirma.ReadOnly = True
        Me.DGVTBC_LugarFirma.Visible = False
        '
        'Lb_TituloProrrogas
        '
        Me.Lb_TituloProrrogas.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Lb_TituloProrrogas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_TituloProrrogas.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_TituloProrrogas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TituloProrrogas.ForeColor = System.Drawing.Color.Black
        Me.Lb_TituloProrrogas.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TituloProrrogas.Name = "Lb_TituloProrrogas"
        Me.Lb_TituloProrrogas.Size = New System.Drawing.Size(520, 18)
        Me.Lb_TituloProrrogas.TabIndex = 7
        Me.Lb_TituloProrrogas.Text = "Prorrogas y Otrosí"
        Me.Lb_TituloProrrogas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Dgv_Conceptos
        '
        Me.Dgv_Conceptos.AllowUserToAddRows = False
        Me.Dgv_Conceptos.AllowUserToDeleteRows = False
        Me.Dgv_Conceptos.AllowUserToResizeRows = False
        Me.Dgv_Conceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Conceptos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Conceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Conceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBC_NOMBRE, Me.DGVTBC_VALOR, Me.DGVTBC_PERIODICIDAD})
        Me.Dgv_Conceptos.ContextMenuStrip = Me.Cms_OpcionesProrrogas
        Me.Dgv_Conceptos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Conceptos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Conceptos.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_Conceptos.Margin = New System.Windows.Forms.Padding(2)
        Me.Dgv_Conceptos.MultiSelect = False
        Me.Dgv_Conceptos.Name = "Dgv_Conceptos"
        Me.Dgv_Conceptos.ReadOnly = True
        Me.Dgv_Conceptos.RowHeadersVisible = False
        Me.Dgv_Conceptos.RowTemplate.Height = 24
        Me.Dgv_Conceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Conceptos.Size = New System.Drawing.Size(310, 120)
        Me.Dgv_Conceptos.TabIndex = 7
        '
        'DGVTBC_NOMBRE
        '
        Me.DGVTBC_NOMBRE.DataPropertyName = "NOMBRETIPOCONCEPTOCONTRATO"
        Me.DGVTBC_NOMBRE.HeaderText = "Nombre"
        Me.DGVTBC_NOMBRE.Name = "DGVTBC_NOMBRE"
        Me.DGVTBC_NOMBRE.ReadOnly = True
        '
        'DGVTBC_VALOR
        '
        Me.DGVTBC_VALOR.DataPropertyName = "VALOR"
        Me.DGVTBC_VALOR.HeaderText = "Valor"
        Me.DGVTBC_VALOR.Name = "DGVTBC_VALOR"
        Me.DGVTBC_VALOR.ReadOnly = True
        '
        'DGVTBC_PERIODICIDAD
        '
        Me.DGVTBC_PERIODICIDAD.DataPropertyName = "PERIODICIDAD"
        Me.DGVTBC_PERIODICIDAD.HeaderText = "Periodicidad"
        Me.DGVTBC_PERIODICIDAD.Name = "DGVTBC_PERIODICIDAD"
        Me.DGVTBC_PERIODICIDAD.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(310, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Conceptos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnVistaDatos
        '
        Me.PnVistaDatos.Controls.Add(Me.Sc_Contratos)
        Me.PnVistaDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnVistaDatos.Location = New System.Drawing.Point(190, 0)
        Me.PnVistaDatos.Name = "PnVistaDatos"
        Me.PnVistaDatos.Size = New System.Drawing.Size(834, 484)
        Me.PnVistaDatos.TabIndex = 11
        '
        'PnDetalle
        '
        Me.PnDetalle.Controls.Add(Me.Sc_Detalles)
        Me.PnDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnDetalle.Location = New System.Drawing.Point(190, 487)
        Me.PnDetalle.Name = "PnDetalle"
        Me.PnDetalle.Size = New System.Drawing.Size(834, 138)
        Me.PnDetalle.TabIndex = 10
        '
        'Splitter1
        '
        Me.Splitter1.Cursor = System.Windows.Forms.Cursors.HSplit
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(190, 484)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(834, 3)
        Me.Splitter1.TabIndex = 4
        Me.Splitter1.TabStop = False
        '
        'Cu_Contrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.PnVistaDatos)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.PnDetalle)
        Me.Controls.Add(Me.Nbc_Contrato)
        Me.Name = "Cu_Contrato"
        Me.Size = New System.Drawing.Size(1024, 625)
        CType(Me.Dgv_Contratos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LISTACONTRATOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_Contratos.Panel1.ResumeLayout(False)
        Me.Sc_Contratos.Panel2.ResumeLayout(False)
        CType(Me.Sc_Contratos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_Contratos.ResumeLayout(False)
        Me.Sc_Detalles.Panel1.ResumeLayout(False)
        Me.Sc_Detalles.Panel2.ResumeLayout(False)
        CType(Me.Sc_Detalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_Detalles.ResumeLayout(False)
        CType(Me.Dgv_Prorrogas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_OpcionesProrrogas.ResumeLayout(False)
        CType(Me.Dgv_Conceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnVistaDatos.ResumeLayout(False)
        Me.PnDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv_Contratos As System.Windows.Forms.DataGridView
    Friend WithEvents FECHACONTRATODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOBANCOCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LISTACONTRATOSBindingSource As System.Windows.Forms.BindingSource

    Friend WithEvents Lb_CantidadResultados As System.Windows.Forms.Label
    Friend WithEvents Nbc_Contrato As NetBarControl.NetBarControl
    Friend WithEvents Nbg_Contrato As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_Editar As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Terminar As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Imprimir As NetBarControl.NetBarGroup
    Friend WithEvents Nbg_Proyecto As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_FormatosContratación As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirBloque As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Prorrogar_Contrato As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VincularBase As NetBarControl.NetBarItem
    Friend WithEvents Nbi_DesvincularBase As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CambiarTurno As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerContrato As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Cargar_Contratos As NetBarControl.NetBarItem
    Friend WithEvents IDCONTRATODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOCONTRATODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRECOMPLETODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDENTIFICACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRETIPOCARGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAINGRESODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOTIPOSALARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DURACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPODURACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREFRENTETRABAJODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nbi_Buscar As NetBarControl.NetBarItem
    Friend WithEvents Lb_Propiedades As System.Windows.Forms.Label
    Friend WithEvents Pg_Detalles As System.Windows.Forms.PropertyGrid
    Friend WithEvents Sc_Contratos As System.Windows.Forms.SplitContainer
    Friend WithEvents Dgv_Prorrogas As System.Windows.Forms.DataGridView
    Friend WithEvents Lb_TituloProrrogas As System.Windows.Forms.Label
    Friend WithEvents Sc_Detalles As System.Windows.Forms.SplitContainer
    Friend WithEvents Nbi_Otrosi_Contrato As NetBarControl.NetBarItem
    Friend WithEvents Cms_OpcionesProrrogas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_ImprimirProrrogas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_ImprimirOtrosi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nbi_Extender As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Suspender As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirProrrogas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirOtrosi As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Activar As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Imprimir As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Reclasificar As NetBarControl.NetBarItem
    Friend WithEvents Nbi_RevContratosXterminar As NetBarControl.NetBarItem
    Friend WithEvents Nbi_GestionarProrrogas As NetBarControl.NetBarItem
    Friend WithEvents PnVistaDatos As System.Windows.Forms.Panel
    Friend WithEvents PnDetalle As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Dgv_Conceptos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGVTBC_NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_VALOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_PERIODICIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogasConsecutivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogasFechaInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogasFechaFin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogasFechaFirma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogasDuracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogasTipoDuracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogasUsuarioModifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogasFechaModifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogaIdContratoProrroga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogaIdContrato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogaUsuarioregistra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogaIdUsuarioregistra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogaFechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogaIdUsuarioModifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ProrrogaEstadoProrroga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_LugarFirma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nbi_ImpContratoAnterior As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HistorialContratos As NetBarControl.NetBarItem

End Class
