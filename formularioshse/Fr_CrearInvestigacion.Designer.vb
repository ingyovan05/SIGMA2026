<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_CrearInvestigacion
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tp_InformacionGeneral = New System.Windows.Forms.TabPage()
        Me.Cb_Contrato = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Tb_EstuvoMal = New System.Windows.Forms.TextBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Rb_TrabajoHabitualNo = New System.Windows.Forms.RadioButton()
        Me.Rb_TrabajoHabitualSi = New System.Windows.Forms.RadioButton()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Dgv_LineaTiempo = New System.Windows.Forms.DataGridView()
        Me.DGVT_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarLineaTiempo = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Cb_CondicionClima = New System.Windows.Forms.ComboBox()
        Me.Lb_CondicionClima = New System.Windows.Forms.Label()
        Me.Tb_TrabajoHabitual = New System.Windows.Forms.TextBox()
        Me.Lb_TrabajoHabitual = New System.Windows.Forms.Label()
        Me.Cb_JornadaIncidente = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Cb_JornadaHabitual = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Cb_ActividadPrincipal = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cu_CiudadIncidente = New FormulariosClasesBase.Cu_Ciudad()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Rb_LugarDentroEmpresa = New System.Windows.Forms.RadioButton()
        Me.Rb_LugarFueraEmpresa = New System.Windows.Forms.RadioButton()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Rb_ZonaUrbana = New System.Windows.Forms.RadioButton()
        Me.Rb_ZonaRural = New System.Windows.Forms.RadioButton()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.DTP_HorasLaboradas = New System.Windows.Forms.DateTimePicker()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Tb_Descripcion = New System.Windows.Forms.TextBox()
        Me.Cb_CargoReporta = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaReporte = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaReporta = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DTP_HoraIncidente = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DTP_FechaIncidente = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Tb_SitioIncidente = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Tb_Empleador = New System.Windows.Forms.TextBox()
        Me.Lb_Empleador = New System.Windows.Forms.Label()
        Me.Ck_Empleador = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cb_Area = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cb_TipoConsecuencia = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cb_TipoIncidente = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cb_Proyecto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tp_InformacionAfectado = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Cu_AsociarPersonaMedico = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.DTP_HoraConceptoMedico = New System.Windows.Forms.DateTimePicker()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersonaMedico = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cb_CargoMedico = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.DTP_FechaConceptoMedico = New System.Windows.Forms.DateTimePicker()
        Me.Tb_OtraParteAfectada = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Lb_ParteAfectada = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaBodega5 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Tb_OtroTipoLesion = New System.Windows.Forms.TextBox()
        Me.Tb_OtroMecanismoAccidente = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Lb_TipoLesion = New System.Windows.Forms.Label()
        Me.Cb_TipoLesion = New System.Windows.Forms.ComboBox()
        Me.Lb_Mecanismo = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Cb_MecanismoAccidente = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Tb_OtroAgenteAccidente = New System.Windows.Forms.TextBox()
        Me.Tb_ComentarioMedico = New System.Windows.Forms.TextBox()
        Me.Lb_AgenteAccidente = New System.Windows.Forms.Label()
        Me.Cb_AgenteAccidente = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Tb_Traslado = New System.Windows.Forms.TextBox()
        Me.Cb_ParteAfectada = New System.Windows.Forms.ComboBox()
        Me.Lb_Trasladado = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Cb_AtencionInmediata = New System.Windows.Forms.ComboBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Tb_ExperienciaOcupacional = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Tb_CargoActual = New System.Windows.Forms.TextBox()
        Me.Num_ExperienciaMeses = New System.Windows.Forms.NumericUpDown()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.DTP_FechaRegresoTrabajo = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Num_DiasSitio = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Num_ExperienciaAños = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DTP_FechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.GroupBox_Genero = New System.Windows.Forms.GroupBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Rb_Femenino = New System.Windows.Forms.RadioButton()
        Me.Rb_Masculino = New System.Windows.Forms.RadioButton()
        Me.DTP_InicioContrato = New System.Windows.Forms.DateTimePicker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Cb_CargoPersonaAccidente = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaAfectada = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaAfectada = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cb_TipoVinculacion = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Tp_AfectacionAmbDaños = New System.Windows.Forms.TabPage()
        Me.Lb_AfectacionDaño = New System.Windows.Forms.Label()
        Me.Lb_NombreInvolucrado = New System.Windows.Forms.Label()
        Me.Lb_CantidadSustancia = New System.Windows.Forms.Label()
        Me.Lb_CargoAfectacionDaños = New System.Windows.Forms.Label()
        Me.Lb_AtencionPrestadaAfectacionDaños = New System.Windows.Forms.Label()
        Me.Lb_UnidadSustancia = New System.Windows.Forms.Label()
        Me.Cb_CargoAfectacionDaños = New System.Windows.Forms.ComboBox()
        Me.Cb_UnidadSustancia = New System.Windows.Forms.ComboBox()
        Me.Tb_CantidadSustancia = New System.Windows.Forms.TextBox()
        Me.Tb_SustanciaProceso = New System.Windows.Forms.TextBox()
        Me.Tb_AtencionPrestadaAfectacionDaños = New System.Windows.Forms.TextBox()
        Me.Tb_AfectacionDaño = New System.Windows.Forms.TextBox()
        Me.Lb_SustanciaProceso = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Tp_ValoracionIncidente = New System.Windows.Forms.TabPage()
        Me.Gb_Costos = New System.Windows.Forms.GroupBox()
        Me.Tb_Costo7 = New System.Windows.Forms.TextBox()
        Me.Lb_Costo7 = New System.Windows.Forms.Label()
        Me.Tb_Especificar6 = New System.Windows.Forms.TextBox()
        Me.Lb_Especificar6 = New System.Windows.Forms.Label()
        Me.Tb_Costo6 = New System.Windows.Forms.TextBox()
        Me.Lb_Costo6 = New System.Windows.Forms.Label()
        Me.Tb_Especificar2 = New System.Windows.Forms.TextBox()
        Me.Lb_Especificar2 = New System.Windows.Forms.Label()
        Me.Tb_Especificar3 = New System.Windows.Forms.TextBox()
        Me.Lb_Especificar3 = New System.Windows.Forms.Label()
        Me.Tb_Especificar4 = New System.Windows.Forms.TextBox()
        Me.Lb_Especificar4 = New System.Windows.Forms.Label()
        Me.Tb_Especificar5 = New System.Windows.Forms.TextBox()
        Me.Lb_Especificar5 = New System.Windows.Forms.Label()
        Me.Tb_Especificar1 = New System.Windows.Forms.TextBox()
        Me.Lb_Especificar1 = New System.Windows.Forms.Label()
        Me.Tb_Costo2 = New System.Windows.Forms.TextBox()
        Me.Lb_Costo2 = New System.Windows.Forms.Label()
        Me.Tb_Costo3 = New System.Windows.Forms.TextBox()
        Me.Lb_Costo3 = New System.Windows.Forms.Label()
        Me.Tb_Costo4 = New System.Windows.Forms.TextBox()
        Me.Lb_Costo4 = New System.Windows.Forms.Label()
        Me.Tb_Costo5 = New System.Windows.Forms.TextBox()
        Me.Lb_Costo5 = New System.Windows.Forms.Label()
        Me.Tb_Costo1 = New System.Windows.Forms.TextBox()
        Me.Lb_Costo1 = New System.Windows.Forms.Label()
        Me.Gb_PerdidaReal = New System.Windows.Forms.GroupBox()
        Me.Tb_CategoriaResultanteReal = New System.Windows.Forms.TextBox()
        Me.Lb_CategoriaResultanteReal = New System.Windows.Forms.Label()
        Me.Cb_RecurrenciaReal = New System.Windows.Forms.ComboBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Cb_SeveridadReal = New System.Windows.Forms.ComboBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Tb_CategoriaResultante = New System.Windows.Forms.TextBox()
        Me.Lb_CategoriaResultante = New System.Windows.Forms.Label()
        Me.Tb_PeorConsecuencia = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Cb_Recurrencia = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Cb_Severidad = New System.Windows.Forms.ComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Tp_Testigos = New System.Windows.Forms.TabPage()
        Me.Gb_Preguntas = New System.Windows.Forms.GroupBox()
        Me.Gb_Pregunta2 = New System.Windows.Forms.GroupBox()
        Me.Tb_Pregunta2 = New System.Windows.Forms.TextBox()
        Me.Lb_Pregunta2 = New System.Windows.Forms.Label()
        Me.Rb_Pregunta2No = New System.Windows.Forms.RadioButton()
        Me.Rb_Pregunta2Si = New System.Windows.Forms.RadioButton()
        Me.Gb_Pregunta1 = New System.Windows.Forms.GroupBox()
        Me.Tb_Pregunta1 = New System.Windows.Forms.TextBox()
        Me.Lb_Pregunta1 = New System.Windows.Forms.Label()
        Me.Rb_Pregunta1No = New System.Windows.Forms.RadioButton()
        Me.Rb_Pregunta1Si = New System.Windows.Forms.RadioButton()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Dgv_Testigos = New System.Windows.Forms.DataGridView()
        Me.DGVT_CedulaTestigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_NombreTestigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVCB_CargoTestigo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVTB_DescripcionTestigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_tituloConceptos = New System.Windows.Forms.Panel()
        Me.Bt_AgregarTestigo = New System.Windows.Forms.Button()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Tp_AnalisisCausas = New System.Windows.Forms.TabPage()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarCausaBasicaTrabajo = New System.Windows.Forms.Button()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Dgv_CausasInmediatasCondiciones = New System.Windows.Forms.DataGridView()
        Me.DGVC_TipoCausaInmediataCondiciones = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVT_DescripcionCausaInmediataCondiciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dgv_CausasBasicasTrabajo = New System.Windows.Forms.DataGridView()
        Me.DGVC_TipoCausaBasicaTrabajo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVT_DescripcionCausaBasicaTrabajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarCausaInmediataCondiciones = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarCausaBasicaPersonal = New System.Windows.Forms.Button()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Dgv_CausasBasicasPersonales = New System.Windows.Forms.DataGridView()
        Me.DGVC_TipoCausaBasicaPersonales = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Dgv_DescripcionCausaBasicaPersonales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dgv_CausasInmediatasActos = New System.Windows.Forms.DataGridView()
        Me.DGVC_TipoCausaInmediataActos = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVT_DescripcionCausaInmediataActos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarCausaInmediataActos = New System.Windows.Forms.Button()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Tp_PlanAccion = New System.Windows.Forms.TabPage()
        Me.Tb_OtraEntidad = New System.Windows.Forms.TextBox()
        Me.Lb_OtraEntidad = New System.Windows.Forms.Label()
        Me.Ck_OtraEntidad = New System.Windows.Forms.CheckBox()
        Me.Ck_Cliente = New System.Windows.Forms.CheckBox()
        Me.Ck_AutoridadAmbiental = New System.Windows.Forms.CheckBox()
        Me.Dgv_Evidencias = New System.Windows.Forms.DataGridView()
        Me.DGVC_TipoEvidencia = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVT_DescripcionEvidencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_Evidencias = New System.Windows.Forms.Panel()
        Me.Bt_AgregarEvidencia = New System.Windows.Forms.Button()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Ck_MinisterioTrabajo = New System.Windows.Forms.CheckBox()
        Me.Ck_Organismo = New System.Windows.Forms.CheckBox()
        Me.Ck_CAR = New System.Windows.Forms.CheckBox()
        Me.Ck_EPS = New System.Windows.Forms.CheckBox()
        Me.Ck_ARL = New System.Windows.Forms.CheckBox()
        Me.Lb_EntidadNotificada = New System.Windows.Forms.Label()
        Me.Dgv_AccionesATomar = New System.Windows.Forms.DataGridView()
        Me.DGVT_Accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVCB_CargoAcciones = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVC_Prioridad = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Pn_Acciones = New System.Windows.Forms.Panel()
        Me.Bt_AgregarAccion = New System.Windows.Forms.Button()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Tp_Investigadores = New System.Windows.Forms.TabPage()
        Me.Cb_CargoAprobo = New System.Windows.Forms.ComboBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.DTP_FechaAprobacion = New System.Windows.Forms.DateTimePicker()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Ck_OtrosAnexos = New System.Windows.Forms.CheckBox()
        Me.Ck_AnexoAlerta = New System.Windows.Forms.CheckBox()
        Me.Ck_AnexoReporte24H = New System.Windows.Forms.CheckBox()
        Me.Ck_AnexoDocumentos = New System.Windows.Forms.CheckBox()
        Me.Ck_AnexoFotos = New System.Windows.Forms.CheckBox()
        Me.Ck_AnexoDibujos = New System.Windows.Forms.CheckBox()
        Me.Tb_OtrosAnexos = New System.Windows.Forms.TextBox()
        Me.Lb_OtrosAnexos = New System.Windows.Forms.Label()
        Me.Gb_Concepto = New System.Windows.Forms.GroupBox()
        Me.Tb_ConceptoAsesorJuridico = New System.Windows.Forms.TextBox()
        Me.Lb_FechaAsesor = New System.Windows.Forms.Label()
        Me.DTP_FechaConceptoAsesor = New System.Windows.Forms.DateTimePicker()
        Me.Lb_NombreAsesor = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaBodegaAsesor = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaAsesorJuridico = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_FechaHSE = New System.Windows.Forms.Label()
        Me.DTP_FechaConceptoHSE = New System.Windows.Forms.DateTimePicker()
        Me.Lb_AsesorJuridico = New System.Windows.Forms.Label()
        Me.Lb_NombreHSE = New System.Windows.Forms.Label()
        Me.Tb_ConceptoHSE = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaBodegaHSE = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaHSE = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Dgv_Investigadores = New System.Windows.Forms.DataGridView()
        Me.DGVT_CedulaInvestigador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_NombreInvestigador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_RolInvestigador = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarInvestigacion = New System.Windows.Forms.Button()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaBodega10 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaAprobo = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Cms_EliminarFila = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarFilaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.Tp_InformacionGeneral.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.Dgv_LineaTiempo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Tp_InformacionAfectado.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Num_ExperienciaMeses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_DiasSitio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_ExperienciaAños, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_Genero.SuspendLayout()
        Me.Tp_AfectacionAmbDaños.SuspendLayout()
        Me.Tp_ValoracionIncidente.SuspendLayout()
        Me.Gb_Costos.SuspendLayout()
        Me.Gb_PerdidaReal.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Tp_Testigos.SuspendLayout()
        Me.Gb_Preguntas.SuspendLayout()
        Me.Gb_Pregunta2.SuspendLayout()
        Me.Gb_Pregunta1.SuspendLayout()
        CType(Me.Dgv_Testigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_tituloConceptos.SuspendLayout()
        Me.Tp_AnalisisCausas.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.Dgv_CausasInmediatasCondiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_CausasBasicasTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.Dgv_CausasBasicasPersonales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_CausasInmediatasActos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Tp_PlanAccion.SuspendLayout()
        CType(Me.Dgv_Evidencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Evidencias.SuspendLayout()
        CType(Me.Dgv_AccionesATomar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Acciones.SuspendLayout()
        Me.Tp_Investigadores.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Gb_Concepto.SuspendLayout()
        CType(Me.Dgv_Investigadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Pn_Botones.SuspendLayout()
        Me.Cms_EliminarFila.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Tp_InformacionGeneral)
        Me.TabControl1.Controls.Add(Me.Tp_InformacionAfectado)
        Me.TabControl1.Controls.Add(Me.Tp_AfectacionAmbDaños)
        Me.TabControl1.Controls.Add(Me.Tp_ValoracionIncidente)
        Me.TabControl1.Controls.Add(Me.Tp_Testigos)
        Me.TabControl1.Controls.Add(Me.Tp_AnalisisCausas)
        Me.TabControl1.Controls.Add(Me.Tp_PlanAccion)
        Me.TabControl1.Controls.Add(Me.Tp_Investigadores)
        Me.TabControl1.Location = New System.Drawing.Point(-1, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(914, 578)
        Me.TabControl1.TabIndex = 0
        '
        'Tp_InformacionGeneral
        '
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cb_Contrato)
        Me.Tp_InformacionGeneral.Controls.Add(Me.GroupBox2)
        Me.Tp_InformacionGeneral.Controls.Add(Me.GroupBox11)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Dgv_LineaTiempo)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Panel1)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cb_CondicionClima)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Lb_CondicionClima)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Tb_TrabajoHabitual)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Lb_TrabajoHabitual)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cb_JornadaIncidente)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label25)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cb_JornadaHabitual)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label24)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cb_ActividadPrincipal)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label7)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cu_CiudadIncidente)
        Me.Tp_InformacionGeneral.Controls.Add(Me.GroupBox8)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label30)
        Me.Tp_InformacionGeneral.Controls.Add(Me.GroupBox7)
        Me.Tp_InformacionGeneral.Controls.Add(Me.DTP_HorasLaboradas)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label47)
        Me.Tp_InformacionGeneral.Controls.Add(Me.GroupBox1)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cb_CargoReporta)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label12)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cu_AsociarPersonaReporte)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cu_BuscarPersonaReporta)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label11)
        Me.Tp_InformacionGeneral.Controls.Add(Me.DTP_HoraIncidente)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label10)
        Me.Tp_InformacionGeneral.Controls.Add(Me.DTP_FechaIncidente)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label9)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Tb_SitioIncidente)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label8)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Tb_Empleador)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Lb_Empleador)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Ck_Empleador)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label6)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cb_Area)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label5)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cb_TipoConsecuencia)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label4)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cb_TipoIncidente)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label3)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Cb_Proyecto)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label2)
        Me.Tp_InformacionGeneral.Controls.Add(Me.Label1)
        Me.Tp_InformacionGeneral.Location = New System.Drawing.Point(4, 22)
        Me.Tp_InformacionGeneral.Name = "Tp_InformacionGeneral"
        Me.Tp_InformacionGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_InformacionGeneral.Size = New System.Drawing.Size(906, 552)
        Me.Tp_InformacionGeneral.TabIndex = 0
        Me.Tp_InformacionGeneral.Text = "Información General"
        Me.Tp_InformacionGeneral.UseVisualStyleBackColor = True
        '
        'Cb_Contrato
        '
        Me.Cb_Contrato.FormattingEnabled = True
        Me.Cb_Contrato.Location = New System.Drawing.Point(88, 9)
        Me.Cb_Contrato.Name = "Cb_Contrato"
        Me.Cb_Contrato.Size = New System.Drawing.Size(112, 21)
        Me.Cb_Contrato.TabIndex = 55
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Tb_EstuvoMal)
        Me.GroupBox2.Location = New System.Drawing.Point(469, 232)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(430, 83)
        Me.GroupBox2.TabIndex = 53
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "¿Qué estuvo mal?"
        '
        'Tb_EstuvoMal
        '
        Me.Tb_EstuvoMal.Location = New System.Drawing.Point(13, 20)
        Me.Tb_EstuvoMal.MaxLength = 500
        Me.Tb_EstuvoMal.Multiline = True
        Me.Tb_EstuvoMal.Name = "Tb_EstuvoMal"
        Me.Tb_EstuvoMal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tb_EstuvoMal.Size = New System.Drawing.Size(405, 57)
        Me.Tb_EstuvoMal.TabIndex = 54
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Rb_TrabajoHabitualNo)
        Me.GroupBox11.Controls.Add(Me.Rb_TrabajoHabitualSi)
        Me.GroupBox11.Controls.Add(Me.Label26)
        Me.GroupBox11.Location = New System.Drawing.Point(14, 154)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(303, 39)
        Me.GroupBox11.TabIndex = 33
        Me.GroupBox11.TabStop = False
        '
        'Rb_TrabajoHabitualNo
        '
        Me.Rb_TrabajoHabitualNo.AutoSize = True
        Me.Rb_TrabajoHabitualNo.Location = New System.Drawing.Point(253, 14)
        Me.Rb_TrabajoHabitualNo.Name = "Rb_TrabajoHabitualNo"
        Me.Rb_TrabajoHabitualNo.Size = New System.Drawing.Size(39, 17)
        Me.Rb_TrabajoHabitualNo.TabIndex = 36
        Me.Rb_TrabajoHabitualNo.TabStop = True
        Me.Rb_TrabajoHabitualNo.Text = "No"
        Me.Rb_TrabajoHabitualNo.UseVisualStyleBackColor = True
        '
        'Rb_TrabajoHabitualSi
        '
        Me.Rb_TrabajoHabitualSi.AutoSize = True
        Me.Rb_TrabajoHabitualSi.Location = New System.Drawing.Point(213, 14)
        Me.Rb_TrabajoHabitualSi.Name = "Rb_TrabajoHabitualSi"
        Me.Rb_TrabajoHabitualSi.Size = New System.Drawing.Size(34, 17)
        Me.Rb_TrabajoHabitualSi.TabIndex = 35
        Me.Rb_TrabajoHabitualSi.TabStop = True
        Me.Rb_TrabajoHabitualSi.Text = "Si"
        Me.Rb_TrabajoHabitualSi.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(4, 16)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(203, 13)
        Me.Label26.TabIndex = 34
        Me.Label26.Text = "¿Estaba Realizando su Trabajo Habitual?"
        '
        'Dgv_LineaTiempo
        '
        Me.Dgv_LineaTiempo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_LineaTiempo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVT_Descripcion})
        Me.Dgv_LineaTiempo.Location = New System.Drawing.Point(3, 351)
        Me.Dgv_LineaTiempo.Name = "Dgv_LineaTiempo"
        Me.Dgv_LineaTiempo.Size = New System.Drawing.Size(900, 201)
        Me.Dgv_LineaTiempo.TabIndex = 56
        '
        'DGVT_Descripcion
        '
        Me.DGVT_Descripcion.DataPropertyName = "DESCRIPCION"
        Me.DGVT_Descripcion.HeaderText = "Descripcion de los Hechos"
        Me.DGVT_Descripcion.MaxInputLength = 250
        Me.DGVT_Descripcion.Name = "DGVT_Descripcion"
        Me.DGVT_Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVT_Descripcion.Width = 300
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.Bt_AgregarLineaTiempo)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Location = New System.Drawing.Point(3, 324)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(900, 25)
        Me.Panel1.TabIndex = 129
        '
        'Bt_AgregarLineaTiempo
        '
        Me.Bt_AgregarLineaTiempo.Location = New System.Drawing.Point(124, 2)
        Me.Bt_AgregarLineaTiempo.Name = "Bt_AgregarLineaTiempo"
        Me.Bt_AgregarLineaTiempo.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarLineaTiempo.TabIndex = 55
        Me.Bt_AgregarLineaTiempo.Text = "Agregar"
        Me.Bt_AgregarLineaTiempo.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(3, 4)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(119, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Linea de tiempo"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cb_CondicionClima
        '
        Me.Cb_CondicionClima.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_CondicionClima.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_CondicionClima.FormattingEnabled = True
        Me.Cb_CondicionClima.Location = New System.Drawing.Point(813, 203)
        Me.Cb_CondicionClima.Name = "Cb_CondicionClima"
        Me.Cb_CondicionClima.Size = New System.Drawing.Size(86, 21)
        Me.Cb_CondicionClima.TabIndex = 50
        '
        'Lb_CondicionClima
        '
        Me.Lb_CondicionClima.AutoSize = True
        Me.Lb_CondicionClima.Location = New System.Drawing.Point(705, 207)
        Me.Lb_CondicionClima.Name = "Lb_CondicionClima"
        Me.Lb_CondicionClima.Size = New System.Drawing.Size(102, 13)
        Me.Lb_CondicionClima.TabIndex = 49
        Me.Lb_CondicionClima.Text = "Condición del Clima:"
        '
        'Tb_TrabajoHabitual
        '
        Me.Tb_TrabajoHabitual.Location = New System.Drawing.Point(371, 166)
        Me.Tb_TrabajoHabitual.MaxLength = 30
        Me.Tb_TrabajoHabitual.Name = "Tb_TrabajoHabitual"
        Me.Tb_TrabajoHabitual.Size = New System.Drawing.Size(283, 20)
        Me.Tb_TrabajoHabitual.TabIndex = 38
        '
        'Lb_TrabajoHabitual
        '
        Me.Lb_TrabajoHabitual.AutoSize = True
        Me.Lb_TrabajoHabitual.Location = New System.Drawing.Point(328, 170)
        Me.Lb_TrabajoHabitual.Name = "Lb_TrabajoHabitual"
        Me.Lb_TrabajoHabitual.Size = New System.Drawing.Size(40, 13)
        Me.Lb_TrabajoHabitual.TabIndex = 37
        Me.Lb_TrabajoHabitual.Text = "¿Cual?"
        '
        'Cb_JornadaIncidente
        '
        Me.Cb_JornadaIncidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_JornadaIncidente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_JornadaIncidente.FormattingEnabled = True
        Me.Cb_JornadaIncidente.Items.AddRange(New Object() {"Normal", "Extra"})
        Me.Cb_JornadaIncidente.Location = New System.Drawing.Point(406, 128)
        Me.Cb_JornadaIncidente.Name = "Cb_JornadaIncidente"
        Me.Cb_JornadaIncidente.Size = New System.Drawing.Size(134, 21)
        Me.Cb_JornadaIncidente.TabIndex = 30
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(288, 132)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 13)
        Me.Label25.TabIndex = 29
        Me.Label25.Text = "Jornada del Incidente:"
        '
        'Cb_JornadaHabitual
        '
        Me.Cb_JornadaHabitual.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_JornadaHabitual.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_JornadaHabitual.FormattingEnabled = True
        Me.Cb_JornadaHabitual.Items.AddRange(New Object() {"Diurna", "Nocturna", "Mixto", "Turnos"})
        Me.Cb_JornadaHabitual.Location = New System.Drawing.Point(148, 128)
        Me.Cb_JornadaHabitual.Name = "Cb_JornadaHabitual"
        Me.Cb_JornadaHabitual.Size = New System.Drawing.Size(121, 21)
        Me.Cb_JornadaHabitual.TabIndex = 28
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(9, 132)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(129, 13)
        Me.Label24.TabIndex = 27
        Me.Label24.Text = "Jornada Trabajo Habitual:"
        '
        'Cb_ActividadPrincipal
        '
        Me.Cb_ActividadPrincipal.FormattingEnabled = True
        Me.Cb_ActividadPrincipal.Location = New System.Drawing.Point(715, 39)
        Me.Cb_ActividadPrincipal.Name = "Cb_ActividadPrincipal"
        Me.Cb_ActividadPrincipal.Size = New System.Drawing.Size(185, 21)
        Me.Cb_ActividadPrincipal.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(620, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Actividad Principal:"
        '
        'Cu_CiudadIncidente
        '
        Me.Cu_CiudadIncidente.Location = New System.Drawing.Point(70, 202)
        Me.Cu_CiudadIncidente.Name = "Cu_CiudadIncidente"
        Me.Cu_CiudadIncidente.Size = New System.Drawing.Size(236, 23)
        Me.Cu_CiudadIncidente.TabIndex = 44
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label32)
        Me.GroupBox8.Controls.Add(Me.Rb_LugarDentroEmpresa)
        Me.GroupBox8.Controls.Add(Me.Rb_LugarFueraEmpresa)
        Me.GroupBox8.Location = New System.Drawing.Point(312, 193)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(388, 35)
        Me.GroupBox8.TabIndex = 45
        Me.GroupBox8.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(6, 14)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(121, 13)
        Me.Label32.TabIndex = 46
        Me.Label32.Text = "Lugar Ocurrio Incidente:"
        '
        'Rb_LugarDentroEmpresa
        '
        Me.Rb_LugarDentroEmpresa.AutoSize = True
        Me.Rb_LugarDentroEmpresa.Location = New System.Drawing.Point(129, 11)
        Me.Rb_LugarDentroEmpresa.Name = "Rb_LugarDentroEmpresa"
        Me.Rb_LugarDentroEmpresa.Size = New System.Drawing.Size(126, 17)
        Me.Rb_LugarDentroEmpresa.TabIndex = 47
        Me.Rb_LugarDentroEmpresa.TabStop = True
        Me.Rb_LugarDentroEmpresa.Text = "Dentro de la empresa"
        Me.Rb_LugarDentroEmpresa.UseVisualStyleBackColor = True
        '
        'Rb_LugarFueraEmpresa
        '
        Me.Rb_LugarFueraEmpresa.AutoSize = True
        Me.Rb_LugarFueraEmpresa.Location = New System.Drawing.Point(257, 11)
        Me.Rb_LugarFueraEmpresa.Name = "Rb_LugarFueraEmpresa"
        Me.Rb_LugarFueraEmpresa.Size = New System.Drawing.Size(121, 17)
        Me.Rb_LugarFueraEmpresa.TabIndex = 48
        Me.Rb_LugarFueraEmpresa.TabStop = True
        Me.Rb_LugarFueraEmpresa.Text = "Fuera de la empresa"
        Me.Rb_LugarFueraEmpresa.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(16, 207)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 13)
        Me.Label30.TabIndex = 43
        Me.Label30.Text = "Municipio:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Rb_ZonaUrbana)
        Me.GroupBox7.Controls.Add(Me.Rb_ZonaRural)
        Me.GroupBox7.Controls.Add(Me.Label31)
        Me.GroupBox7.Location = New System.Drawing.Point(661, 155)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(238, 39)
        Me.GroupBox7.TabIndex = 39
        Me.GroupBox7.TabStop = False
        '
        'Rb_ZonaUrbana
        '
        Me.Rb_ZonaUrbana.AutoSize = True
        Me.Rb_ZonaUrbana.Location = New System.Drawing.Point(172, 11)
        Me.Rb_ZonaUrbana.Name = "Rb_ZonaUrbana"
        Me.Rb_ZonaUrbana.Size = New System.Drawing.Size(60, 17)
        Me.Rb_ZonaUrbana.TabIndex = 42
        Me.Rb_ZonaUrbana.TabStop = True
        Me.Rb_ZonaUrbana.Text = "Urbana"
        Me.Rb_ZonaUrbana.UseVisualStyleBackColor = True
        '
        'Rb_ZonaRural
        '
        Me.Rb_ZonaRural.AutoSize = True
        Me.Rb_ZonaRural.Location = New System.Drawing.Point(121, 11)
        Me.Rb_ZonaRural.Name = "Rb_ZonaRural"
        Me.Rb_ZonaRural.Size = New System.Drawing.Size(50, 17)
        Me.Rb_ZonaRural.TabIndex = 41
        Me.Rb_ZonaRural.TabStop = True
        Me.Rb_ZonaRural.Text = "Rural"
        Me.Rb_ZonaRural.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(5, 14)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(116, 13)
        Me.Label31.TabIndex = 40
        Me.Label31.Text = "Zona Ocurrio Incidente"
        '
        'DTP_HorasLaboradas
        '
        Me.DTP_HorasLaboradas.Checked = False
        Me.DTP_HorasLaboradas.CustomFormat = "HH:mm"
        Me.DTP_HorasLaboradas.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_HorasLaboradas.Location = New System.Drawing.Point(656, 128)
        Me.DTP_HorasLaboradas.Name = "DTP_HorasLaboradas"
        Me.DTP_HorasLaboradas.ShowCheckBox = True
        Me.DTP_HorasLaboradas.ShowUpDown = True
        Me.DTP_HorasLaboradas.Size = New System.Drawing.Size(93, 20)
        Me.DTP_HorasLaboradas.TabIndex = 32
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(546, 132)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(101, 13)
        Me.Label47.TabIndex = 31
        Me.Label47.Text = "Horas laboradas dia"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tb_Descripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 232)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 83)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Descripcion Incidente"
        '
        'Tb_Descripcion
        '
        Me.Tb_Descripcion.Location = New System.Drawing.Point(13, 20)
        Me.Tb_Descripcion.MaxLength = 500
        Me.Tb_Descripcion.Multiline = True
        Me.Tb_Descripcion.Name = "Tb_Descripcion"
        Me.Tb_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tb_Descripcion.Size = New System.Drawing.Size(405, 57)
        Me.Tb_Descripcion.TabIndex = 52
        '
        'Cb_CargoReporta
        '
        Me.Cb_CargoReporta.FormattingEnabled = True
        Me.Cb_CargoReporta.Location = New System.Drawing.Point(633, 98)
        Me.Cb_CargoReporta.Name = "Cb_CargoReporta"
        Me.Cb_CargoReporta.Size = New System.Drawing.Size(266, 21)
        Me.Cb_CargoReporta.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(506, 102)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(125, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Cargo de Quien Reporta:"
        '
        'Cu_AsociarPersonaReporte
        '
        Me.Cu_AsociarPersonaReporte.componenteasociado = Nothing
        Me.Cu_AsociarPersonaReporte.CrearUsuario = False
        Me.Cu_AsociarPersonaReporte.Location = New System.Drawing.Point(466, 98)
        Me.Cu_AsociarPersonaReporte.Name = "Cu_AsociarPersonaReporte"
        Me.Cu_AsociarPersonaReporte.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaReporte.TabIndex = 24
        Me.Cu_AsociarPersonaReporte.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaReporte.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaReporta
        '
        Me.Cu_BuscarPersonaReporta.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaReporta.Location = New System.Drawing.Point(88, 97)
        Me.Cu_BuscarPersonaReporta.Name = "Cu_BuscarPersonaReporta"
        Me.Cu_BuscarPersonaReporta.Size = New System.Drawing.Size(382, 23)
        Me.Cu_BuscarPersonaReporta.TabIndex = 23
        Me.Cu_BuscarPersonaReporta.Tipo = "PABO"
        Me.Cu_BuscarPersonaReporta.valorcajatexto = "IDENTIFICACION"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Reportado Por:"
        '
        'DTP_HoraIncidente
        '
        Me.DTP_HoraIncidente.Checked = False
        Me.DTP_HoraIncidente.CustomFormat = "hh:mm tt"
        Me.DTP_HoraIncidente.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_HoraIncidente.Location = New System.Drawing.Point(800, 69)
        Me.DTP_HoraIncidente.Name = "DTP_HoraIncidente"
        Me.DTP_HoraIncidente.ShowCheckBox = True
        Me.DTP_HoraIncidente.ShowUpDown = True
        Me.DTP_HoraIncidente.Size = New System.Drawing.Size(100, 20)
        Me.DTP_HoraIncidente.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(714, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Hora Incidente:"
        '
        'DTP_FechaIncidente
        '
        Me.DTP_FechaIncidente.Checked = False
        Me.DTP_FechaIncidente.Location = New System.Drawing.Point(502, 69)
        Me.DTP_FechaIncidente.Name = "DTP_FechaIncidente"
        Me.DTP_FechaIncidente.ShowCheckBox = True
        Me.DTP_FechaIncidente.Size = New System.Drawing.Size(200, 20)
        Me.DTP_FechaIncidente.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(412, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Fecha Incidente:"
        '
        'Tb_SitioIncidente
        '
        Me.Tb_SitioIncidente.Location = New System.Drawing.Point(88, 69)
        Me.Tb_SitioIncidente.MaxLength = 50
        Me.Tb_SitioIncidente.Name = "Tb_SitioIncidente"
        Me.Tb_SitioIncidente.Size = New System.Drawing.Size(318, 20)
        Me.Tb_SitioIncidente.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Sitio Incidente:"
        '
        'Tb_Empleador
        '
        Me.Tb_Empleador.Location = New System.Drawing.Point(480, 39)
        Me.Tb_Empleador.MaxLength = 50
        Me.Tb_Empleador.Name = "Tb_Empleador"
        Me.Tb_Empleador.Size = New System.Drawing.Size(136, 20)
        Me.Tb_Empleador.TabIndex = 13
        '
        'Lb_Empleador
        '
        Me.Lb_Empleador.AutoSize = True
        Me.Lb_Empleador.Location = New System.Drawing.Point(355, 43)
        Me.Lb_Empleador.Name = "Lb_Empleador"
        Me.Lb_Empleador.Size = New System.Drawing.Size(125, 13)
        Me.Lb_Empleador.TabIndex = 12
        Me.Lb_Empleador.Text = "¿Nombre del empleador?"
        '
        'Ck_Empleador
        '
        Me.Ck_Empleador.AutoSize = True
        Me.Ck_Empleador.Location = New System.Drawing.Point(337, 42)
        Me.Ck_Empleador.Name = "Ck_Empleador"
        Me.Ck_Empleador.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Empleador.TabIndex = 11
        Me.Ck_Empleador.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(203, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "¿El empleador es Ismocol?"
        '
        'Cb_Area
        '
        Me.Cb_Area.FormattingEnabled = True
        Me.Cb_Area.Location = New System.Drawing.Point(88, 39)
        Me.Cb_Area.Name = "Cb_Area"
        Me.Cb_Area.Size = New System.Drawing.Size(112, 21)
        Me.Cb_Area.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(55, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Area:"
        '
        'Cb_TipoConsecuencia
        '
        Me.Cb_TipoConsecuencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoConsecuencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoConsecuencia.FormattingEnabled = True
        Me.Cb_TipoConsecuencia.Location = New System.Drawing.Point(716, 9)
        Me.Cb_TipoConsecuencia.Name = "Cb_TipoConsecuencia"
        Me.Cb_TipoConsecuencia.Size = New System.Drawing.Size(184, 21)
        Me.Cb_TipoConsecuencia.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(635, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Consecuencia:"
        '
        'Cb_TipoIncidente
        '
        Me.Cb_TipoIncidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Cb_TipoIncidente.FormattingEnabled = True
        Me.Cb_TipoIncidente.Location = New System.Drawing.Point(533, 9)
        Me.Cb_TipoIncidente.Name = "Cb_TipoIncidente"
        Me.Cb_TipoIncidente.Size = New System.Drawing.Size(96, 21)
        Me.Cb_TipoIncidente.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(437, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tipo de Incidente:"
        '
        'Cb_Proyecto
        '
        Me.Cb_Proyecto.FormattingEnabled = True
        Me.Cb_Proyecto.Location = New System.Drawing.Point(258, 9)
        Me.Cb_Proyecto.Name = "Cb_Proyecto"
        Me.Cb_Proyecto.Size = New System.Drawing.Size(173, 21)
        Me.Cb_Proyecto.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(202, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proyecto:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Contrato:"
        '
        'Tp_InformacionAfectado
        '
        Me.Tp_InformacionAfectado.Controls.Add(Me.GroupBox6)
        Me.Tp_InformacionAfectado.Controls.Add(Me.GroupBox3)
        Me.Tp_InformacionAfectado.Location = New System.Drawing.Point(4, 22)
        Me.Tp_InformacionAfectado.Name = "Tp_InformacionAfectado"
        Me.Tp_InformacionAfectado.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_InformacionAfectado.Size = New System.Drawing.Size(906, 552)
        Me.Tp_InformacionAfectado.TabIndex = 1
        Me.Tp_InformacionAfectado.Text = "Información del Afectado"
        Me.Tp_InformacionAfectado.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Cu_AsociarPersonaMedico)
        Me.GroupBox6.Controls.Add(Me.DTP_HoraConceptoMedico)
        Me.GroupBox6.Controls.Add(Me.Label33)
        Me.GroupBox6.Controls.Add(Me.Cu_BuscarPersonaMedico)
        Me.GroupBox6.Controls.Add(Me.Cb_CargoMedico)
        Me.GroupBox6.Controls.Add(Me.Label29)
        Me.GroupBox6.Controls.Add(Me.DTP_FechaConceptoMedico)
        Me.GroupBox6.Controls.Add(Me.Tb_OtraParteAfectada)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.Lb_ParteAfectada)
        Me.GroupBox6.Controls.Add(Me.Cu_AsociarPersonaBodega5)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroTipoLesion)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroMecanismoAccidente)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Controls.Add(Me.Lb_TipoLesion)
        Me.GroupBox6.Controls.Add(Me.Cb_TipoLesion)
        Me.GroupBox6.Controls.Add(Me.Lb_Mecanismo)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.Cb_MecanismoAccidente)
        Me.GroupBox6.Controls.Add(Me.Label41)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroAgenteAccidente)
        Me.GroupBox6.Controls.Add(Me.Tb_ComentarioMedico)
        Me.GroupBox6.Controls.Add(Me.Lb_AgenteAccidente)
        Me.GroupBox6.Controls.Add(Me.Cb_AgenteAccidente)
        Me.GroupBox6.Controls.Add(Me.Label42)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.Tb_Traslado)
        Me.GroupBox6.Controls.Add(Me.Cb_ParteAfectada)
        Me.GroupBox6.Controls.Add(Me.Lb_Trasladado)
        Me.GroupBox6.Controls.Add(Me.Label37)
        Me.GroupBox6.Controls.Add(Me.Cb_AtencionInmediata)
        Me.GroupBox6.Controls.Add(Me.Label44)
        Me.GroupBox6.Location = New System.Drawing.Point(11, 165)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(885, 261)
        Me.GroupBox6.TabIndex = 87
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Información Sobre el Accidente"
        '
        'Cu_AsociarPersonaMedico
        '
        Me.Cu_AsociarPersonaMedico.componenteasociado = Nothing
        Me.Cu_AsociarPersonaMedico.CrearUsuario = False
        Me.Cu_AsociarPersonaMedico.Location = New System.Drawing.Point(576, 201)
        Me.Cu_AsociarPersonaMedico.Name = "Cu_AsociarPersonaMedico"
        Me.Cu_AsociarPersonaMedico.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaMedico.TabIndex = 128
        Me.Cu_AsociarPersonaMedico.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaMedico.TipoBúsqueda = "P"
        '
        'DTP_HoraConceptoMedico
        '
        Me.DTP_HoraConceptoMedico.Checked = False
        Me.DTP_HoraConceptoMedico.CustomFormat = "hh:mm tt"
        Me.DTP_HoraConceptoMedico.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_HoraConceptoMedico.Location = New System.Drawing.Point(408, 232)
        Me.DTP_HoraConceptoMedico.Name = "DTP_HoraConceptoMedico"
        Me.DTP_HoraConceptoMedico.ShowCheckBox = True
        Me.DTP_HoraConceptoMedico.ShowUpDown = True
        Me.DTP_HoraConceptoMedico.Size = New System.Drawing.Size(93, 20)
        Me.DTP_HoraConceptoMedico.TabIndex = 127
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(285, 235)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(120, 13)
        Me.Label33.TabIndex = 122
        Me.Label33.Text = "Hora Concepto Médico:"
        '
        'Cu_BuscarPersonaMedico
        '
        Me.Cu_BuscarPersonaMedico.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaMedico.Location = New System.Drawing.Point(154, 200)
        Me.Cu_BuscarPersonaMedico.Name = "Cu_BuscarPersonaMedico"
        Me.Cu_BuscarPersonaMedico.Size = New System.Drawing.Size(425, 23)
        Me.Cu_BuscarPersonaMedico.TabIndex = 112
        Me.Cu_BuscarPersonaMedico.Tipo = "PABO"
        Me.Cu_BuscarPersonaMedico.valorcajatexto = "IDENTIFICACION"
        '
        'Cb_CargoMedico
        '
        Me.Cb_CargoMedico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_CargoMedico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_CargoMedico.FormattingEnabled = True
        Me.Cb_CargoMedico.Location = New System.Drawing.Point(662, 201)
        Me.Cb_CargoMedico.Name = "Cb_CargoMedico"
        Me.Cb_CargoMedico.Size = New System.Drawing.Size(208, 21)
        Me.Cb_CargoMedico.TabIndex = 115
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(621, 205)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(38, 13)
        Me.Label29.TabIndex = 114
        Me.Label29.Text = "Cargo:"
        '
        'DTP_FechaConceptoMedico
        '
        Me.DTP_FechaConceptoMedico.Checked = False
        Me.DTP_FechaConceptoMedico.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaConceptoMedico.Location = New System.Drawing.Point(157, 229)
        Me.DTP_FechaConceptoMedico.Name = "DTP_FechaConceptoMedico"
        Me.DTP_FechaConceptoMedico.ShowCheckBox = True
        Me.DTP_FechaConceptoMedico.Size = New System.Drawing.Size(112, 20)
        Me.DTP_FechaConceptoMedico.TabIndex = 121
        '
        'Tb_OtraParteAfectada
        '
        Me.Tb_OtraParteAfectada.Location = New System.Drawing.Point(418, 50)
        Me.Tb_OtraParteAfectada.MaxLength = 30
        Me.Tb_OtraParteAfectada.Name = "Tb_OtraParteAfectada"
        Me.Tb_OtraParteAfectada.Size = New System.Drawing.Size(455, 20)
        Me.Tb_OtraParteAfectada.TabIndex = 95
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(22, 233)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(127, 13)
        Me.Label20.TabIndex = 120
        Me.Label20.Text = "Fecha Concepto Médico:"
        '
        'Lb_ParteAfectada
        '
        Me.Lb_ParteAfectada.AutoSize = True
        Me.Lb_ParteAfectada.Location = New System.Drawing.Point(374, 54)
        Me.Lb_ParteAfectada.Name = "Lb_ParteAfectada"
        Me.Lb_ParteAfectada.Size = New System.Drawing.Size(40, 13)
        Me.Lb_ParteAfectada.TabIndex = 94
        Me.Lb_ParteAfectada.Text = "¿Cual?"
        '
        'Cu_AsociarPersonaBodega5
        '
        Me.Cu_AsociarPersonaBodega5.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodega5.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega5.Location = New System.Drawing.Point(538, 200)
        Me.Cu_AsociarPersonaBodega5.Name = "Cu_AsociarPersonaBodega5"
        Me.Cu_AsociarPersonaBodega5.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega5.TabIndex = 113
        Me.Cu_AsociarPersonaBodega5.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodega5.TipoBúsqueda = "P"
        '
        'Tb_OtroTipoLesion
        '
        Me.Tb_OtroTipoLesion.Location = New System.Drawing.Point(418, 20)
        Me.Tb_OtroTipoLesion.MaxLength = 30
        Me.Tb_OtroTipoLesion.Name = "Tb_OtroTipoLesion"
        Me.Tb_OtroTipoLesion.Size = New System.Drawing.Size(455, 20)
        Me.Tb_OtroTipoLesion.TabIndex = 91
        '
        'Tb_OtroMecanismoAccidente
        '
        Me.Tb_OtroMecanismoAccidente.Location = New System.Drawing.Point(418, 110)
        Me.Tb_OtroMecanismoAccidente.MaxLength = 30
        Me.Tb_OtroMecanismoAccidente.Name = "Tb_OtroMecanismoAccidente"
        Me.Tb_OtroMecanismoAccidente.Size = New System.Drawing.Size(455, 20)
        Me.Tb_OtroMecanismoAccidente.TabIndex = 103
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(47, 204)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(102, 13)
        Me.Label23.TabIndex = 110
        Me.Label23.Text = "Nombre Prof. Salud:"
        '
        'Lb_TipoLesion
        '
        Me.Lb_TipoLesion.AutoSize = True
        Me.Lb_TipoLesion.Location = New System.Drawing.Point(374, 24)
        Me.Lb_TipoLesion.Name = "Lb_TipoLesion"
        Me.Lb_TipoLesion.Size = New System.Drawing.Size(40, 13)
        Me.Lb_TipoLesion.TabIndex = 90
        Me.Lb_TipoLesion.Text = "¿Cual?"
        '
        'Cb_TipoLesion
        '
        Me.Cb_TipoLesion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoLesion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoLesion.FormattingEnabled = True
        Me.Cb_TipoLesion.Location = New System.Drawing.Point(155, 20)
        Me.Cb_TipoLesion.Name = "Cb_TipoLesion"
        Me.Cb_TipoLesion.Size = New System.Drawing.Size(173, 21)
        Me.Cb_TipoLesion.TabIndex = 89
        '
        'Lb_Mecanismo
        '
        Me.Lb_Mecanismo.AutoSize = True
        Me.Lb_Mecanismo.Location = New System.Drawing.Point(374, 114)
        Me.Lb_Mecanismo.Name = "Lb_Mecanismo"
        Me.Lb_Mecanismo.Size = New System.Drawing.Size(40, 13)
        Me.Lb_Mecanismo.TabIndex = 102
        Me.Lb_Mecanismo.Text = "¿Cual?"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(84, 24)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(65, 13)
        Me.Label36.TabIndex = 88
        Me.Label36.Text = "Tipo Lesión:"
        '
        'Cb_MecanismoAccidente
        '
        Me.Cb_MecanismoAccidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_MecanismoAccidente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_MecanismoAccidente.FormattingEnabled = True
        Me.Cb_MecanismoAccidente.Location = New System.Drawing.Point(155, 110)
        Me.Cb_MecanismoAccidente.Name = "Cb_MecanismoAccidente"
        Me.Cb_MecanismoAccidente.Size = New System.Drawing.Size(173, 21)
        Me.Cb_MecanismoAccidente.TabIndex = 101
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(17, 114)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(132, 13)
        Me.Label41.TabIndex = 100
        Me.Label41.Text = "Mecanismo del Accidente:"
        '
        'Tb_OtroAgenteAccidente
        '
        Me.Tb_OtroAgenteAccidente.Location = New System.Drawing.Point(418, 80)
        Me.Tb_OtroAgenteAccidente.MaxLength = 30
        Me.Tb_OtroAgenteAccidente.Name = "Tb_OtroAgenteAccidente"
        Me.Tb_OtroAgenteAccidente.Size = New System.Drawing.Size(455, 20)
        Me.Tb_OtroAgenteAccidente.TabIndex = 99
        '
        'Tb_ComentarioMedico
        '
        Me.Tb_ComentarioMedico.Location = New System.Drawing.Point(155, 170)
        Me.Tb_ComentarioMedico.MaxLength = 100
        Me.Tb_ComentarioMedico.Name = "Tb_ComentarioMedico"
        Me.Tb_ComentarioMedico.Size = New System.Drawing.Size(716, 20)
        Me.Tb_ComentarioMedico.TabIndex = 109
        '
        'Lb_AgenteAccidente
        '
        Me.Lb_AgenteAccidente.AutoSize = True
        Me.Lb_AgenteAccidente.Location = New System.Drawing.Point(374, 84)
        Me.Lb_AgenteAccidente.Name = "Lb_AgenteAccidente"
        Me.Lb_AgenteAccidente.Size = New System.Drawing.Size(40, 13)
        Me.Lb_AgenteAccidente.TabIndex = 98
        Me.Lb_AgenteAccidente.Text = "¿Cual?"
        '
        'Cb_AgenteAccidente
        '
        Me.Cb_AgenteAccidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_AgenteAccidente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_AgenteAccidente.FormattingEnabled = True
        Me.Cb_AgenteAccidente.Location = New System.Drawing.Point(155, 80)
        Me.Cb_AgenteAccidente.Name = "Cb_AgenteAccidente"
        Me.Cb_AgenteAccidente.Size = New System.Drawing.Size(173, 21)
        Me.Cb_AgenteAccidente.TabIndex = 97
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(26, 173)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(123, 13)
        Me.Label42.TabIndex = 108
        Me.Label42.Text = "Comentarios Prof. Salud:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(37, 84)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(112, 13)
        Me.Label39.TabIndex = 96
        Me.Label39.Text = "Agente del Accidente:"
        '
        'Tb_Traslado
        '
        Me.Tb_Traslado.Location = New System.Drawing.Point(418, 140)
        Me.Tb_Traslado.MaxLength = 30
        Me.Tb_Traslado.Name = "Tb_Traslado"
        Me.Tb_Traslado.Size = New System.Drawing.Size(455, 20)
        Me.Tb_Traslado.TabIndex = 107
        '
        'Cb_ParteAfectada
        '
        Me.Cb_ParteAfectada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_ParteAfectada.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_ParteAfectada.FormattingEnabled = True
        Me.Cb_ParteAfectada.Location = New System.Drawing.Point(155, 50)
        Me.Cb_ParteAfectada.Name = "Cb_ParteAfectada"
        Me.Cb_ParteAfectada.Size = New System.Drawing.Size(173, 21)
        Me.Cb_ParteAfectada.TabIndex = 93
        '
        'Lb_Trasladado
        '
        Me.Lb_Trasladado.AutoSize = True
        Me.Lb_Trasladado.Location = New System.Drawing.Point(342, 144)
        Me.Lb_Trasladado.Name = "Lb_Trasladado"
        Me.Lb_Trasladado.Size = New System.Drawing.Size(72, 13)
        Me.Lb_Trasladado.TabIndex = 106
        Me.Lb_Trasladado.Text = "Trasladado a:"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(14, 54)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(135, 13)
        Me.Label37.TabIndex = 92
        Me.Label37.Text = "Parte del Cuerpo Afectada:"
        '
        'Cb_AtencionInmediata
        '
        Me.Cb_AtencionInmediata.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_AtencionInmediata.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_AtencionInmediata.FormattingEnabled = True
        Me.Cb_AtencionInmediata.Items.AddRange(New Object() {"MEDEVAC", "Regreso a su trabajo", "Hospitalizado", "Enviado a su casa", "Traslado a centro de Atención"})
        Me.Cb_AtencionInmediata.Location = New System.Drawing.Point(155, 140)
        Me.Cb_AtencionInmediata.Name = "Cb_AtencionInmediata"
        Me.Cb_AtencionInmediata.Size = New System.Drawing.Size(173, 21)
        Me.Cb_AtencionInmediata.TabIndex = 105
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(48, 144)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(101, 13)
        Me.Label44.TabIndex = 104
        Me.Label44.Text = "Atención Inmediata:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Tb_ExperienciaOcupacional)
        Me.GroupBox3.Controls.Add(Me.Label43)
        Me.GroupBox3.Controls.Add(Me.Tb_CargoActual)
        Me.GroupBox3.Controls.Add(Me.Num_ExperienciaMeses)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Controls.Add(Me.DTP_FechaRegresoTrabajo)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Num_DiasSitio)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Num_ExperienciaAños)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.DTP_FechaNacimiento)
        Me.GroupBox3.Controls.Add(Me.Label53)
        Me.GroupBox3.Controls.Add(Me.GroupBox_Genero)
        Me.GroupBox3.Controls.Add(Me.DTP_InicioContrato)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Cb_CargoPersonaAccidente)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Cu_AsociarPersonaAfectada)
        Me.GroupBox3.Controls.Add(Me.Cu_BuscarPersonaAfectada)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Cb_TipoVinculacion)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(885, 146)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Información Persona Afectada"
        '
        'Tb_ExperienciaOcupacional
        '
        Me.Tb_ExperienciaOcupacional.Location = New System.Drawing.Point(139, 110)
        Me.Tb_ExperienciaOcupacional.Name = "Tb_ExperienciaOcupacional"
        Me.Tb_ExperienciaOcupacional.ReadOnly = True
        Me.Tb_ExperienciaOcupacional.Size = New System.Drawing.Size(100, 20)
        Me.Tb_ExperienciaOcupacional.TabIndex = 80
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(8, 114)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(128, 13)
        Me.Label43.TabIndex = 79
        Me.Label43.Text = "Experiencia Ocupacional:"
        '
        'Tb_CargoActual
        '
        Me.Tb_CargoActual.Location = New System.Drawing.Point(479, 50)
        Me.Tb_CargoActual.Name = "Tb_CargoActual"
        Me.Tb_CargoActual.ReadOnly = True
        Me.Tb_CargoActual.Size = New System.Drawing.Size(100, 20)
        Me.Tb_CargoActual.TabIndex = 70
        '
        'Num_ExperienciaMeses
        '
        Me.Num_ExperienciaMeses.Location = New System.Drawing.Point(829, 80)
        Me.Num_ExperienciaMeses.Maximum = New Decimal(New Integer() {11, 0, 0, 0})
        Me.Num_ExperienciaMeses.Name = "Num_ExperienciaMeses"
        Me.Num_ExperienciaMeses.Size = New System.Drawing.Size(44, 20)
        Me.Num_ExperienciaMeses.TabIndex = 78
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(660, 84)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(164, 13)
        Me.Label34.TabIndex = 77
        Me.Label34.Text = "Experiencia Ocupacional (meses)"
        '
        'DTP_FechaRegresoTrabajo
        '
        Me.DTP_FechaRegresoTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaRegresoTrabajo.Location = New System.Drawing.Point(603, 109)
        Me.DTP_FechaRegresoTrabajo.Name = "DTP_FechaRegresoTrabajo"
        Me.DTP_FechaRegresoTrabajo.RightToLeftLayout = True
        Me.DTP_FechaRegresoTrabajo.ShowCheckBox = True
        Me.DTP_FechaRegresoTrabajo.Size = New System.Drawing.Size(112, 20)
        Me.DTP_FechaRegresoTrabajo.TabIndex = 84
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(450, 113)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(148, 13)
        Me.Label19.TabIndex = 83
        Me.Label19.Text = "Fecha de Regreso al Trabajo:"
        '
        'Num_DiasSitio
        '
        Me.Num_DiasSitio.Location = New System.Drawing.Point(386, 111)
        Me.Num_DiasSitio.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.Num_DiasSitio.Name = "Num_DiasSitio"
        Me.Num_DiasSitio.Size = New System.Drawing.Size(44, 20)
        Me.Num_DiasSitio.TabIndex = 82
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(247, 115)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(137, 13)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Número de Días en el Sitio:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(375, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 13)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "Cargo Actual Años:"
        '
        'Num_ExperienciaAños
        '
        Me.Num_ExperienciaAños.Location = New System.Drawing.Point(613, 80)
        Me.Num_ExperienciaAños.Name = "Num_ExperienciaAños"
        Me.Num_ExperienciaAños.Size = New System.Drawing.Size(44, 20)
        Me.Num_ExperienciaAños.TabIndex = 76
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(450, 84)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(157, 13)
        Me.Label27.TabIndex = 75
        Me.Label27.Text = "Experiencia Ocupacional (años)"
        '
        'DTP_FechaNacimiento
        '
        Me.DTP_FechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaNacimiento.Location = New System.Drawing.Point(545, 19)
        Me.DTP_FechaNacimiento.Name = "DTP_FechaNacimiento"
        Me.DTP_FechaNacimiento.ShowCheckBox = True
        Me.DTP_FechaNacimiento.Size = New System.Drawing.Size(112, 20)
        Me.DTP_FechaNacimiento.TabIndex = 62
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(444, 23)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(96, 13)
        Me.Label53.TabIndex = 61
        Me.Label53.Text = "Fecha Nacimiento:"
        '
        'GroupBox_Genero
        '
        Me.GroupBox_Genero.Controls.Add(Me.Label60)
        Me.GroupBox_Genero.Controls.Add(Me.Rb_Femenino)
        Me.GroupBox_Genero.Controls.Add(Me.Rb_Masculino)
        Me.GroupBox_Genero.Location = New System.Drawing.Point(670, 12)
        Me.GroupBox_Genero.Name = "GroupBox_Genero"
        Me.GroupBox_Genero.Size = New System.Drawing.Size(203, 31)
        Me.GroupBox_Genero.TabIndex = 63
        Me.GroupBox_Genero.TabStop = False
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(6, 12)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(45, 13)
        Me.Label60.TabIndex = 64
        Me.Label60.Text = "Genero:"
        '
        'Rb_Femenino
        '
        Me.Rb_Femenino.AutoSize = True
        Me.Rb_Femenino.Location = New System.Drawing.Point(131, 10)
        Me.Rb_Femenino.Name = "Rb_Femenino"
        Me.Rb_Femenino.Size = New System.Drawing.Size(71, 17)
        Me.Rb_Femenino.TabIndex = 66
        Me.Rb_Femenino.TabStop = True
        Me.Rb_Femenino.Text = "Femenino"
        Me.Rb_Femenino.UseVisualStyleBackColor = True
        '
        'Rb_Masculino
        '
        Me.Rb_Masculino.AutoSize = True
        Me.Rb_Masculino.Location = New System.Drawing.Point(55, 10)
        Me.Rb_Masculino.Name = "Rb_Masculino"
        Me.Rb_Masculino.Size = New System.Drawing.Size(73, 17)
        Me.Rb_Masculino.TabIndex = 65
        Me.Rb_Masculino.TabStop = True
        Me.Rb_Masculino.Text = "Masculino"
        Me.Rb_Masculino.UseVisualStyleBackColor = True
        '
        'DTP_InicioContrato
        '
        Me.DTP_InicioContrato.Location = New System.Drawing.Point(120, 50)
        Me.DTP_InicioContrato.Name = "DTP_InicioContrato"
        Me.DTP_InicioContrato.ShowCheckBox = True
        Me.DTP_InicioContrato.Size = New System.Drawing.Size(208, 20)
        Me.DTP_InicioContrato.TabIndex = 68
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 54)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(111, 13)
        Me.Label28.TabIndex = 67
        Me.Label28.Text = "Fecha Inicio Contrato:"
        '
        'Cb_CargoPersonaAccidente
        '
        Me.Cb_CargoPersonaAccidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_CargoPersonaAccidente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_CargoPersonaAccidente.FormattingEnabled = True
        Me.Cb_CargoPersonaAccidente.Location = New System.Drawing.Point(60, 80)
        Me.Cb_CargoPersonaAccidente.Name = "Cb_CargoPersonaAccidente"
        Me.Cb_CargoPersonaAccidente.Size = New System.Drawing.Size(370, 21)
        Me.Cb_CargoPersonaAccidente.TabIndex = 74
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(19, 84)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 73
        Me.Label21.Text = "Cargo:"
        '
        'Cu_AsociarPersonaAfectada
        '
        Me.Cu_AsociarPersonaAfectada.componenteasociado = Nothing
        Me.Cu_AsociarPersonaAfectada.CrearUsuario = False
        Me.Cu_AsociarPersonaAfectada.Location = New System.Drawing.Point(403, 19)
        Me.Cu_AsociarPersonaAfectada.Name = "Cu_AsociarPersonaAfectada"
        Me.Cu_AsociarPersonaAfectada.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaAfectada.TabIndex = 60
        Me.Cu_AsociarPersonaAfectada.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaAfectada.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaAfectada
        '
        Me.Cu_BuscarPersonaAfectada.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAfectada.Location = New System.Drawing.Point(60, 18)
        Me.Cu_BuscarPersonaAfectada.Name = "Cu_BuscarPersonaAfectada"
        Me.Cu_BuscarPersonaAfectada.Size = New System.Drawing.Size(347, 23)
        Me.Cu_BuscarPersonaAfectada.TabIndex = 59
        Me.Cu_BuscarPersonaAfectada.Tipo = "PABO"
        Me.Cu_BuscarPersonaAfectada.valorcajatexto = "IDENTIFICACION"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Nombre:"
        '
        'Cb_TipoVinculacion
        '
        Me.Cb_TipoVinculacion.FormattingEnabled = True
        Me.Cb_TipoVinculacion.Items.AddRange(New Object() {"Empleador", "Contratante", "Cooperativa Trabajo Asociado"})
        Me.Cb_TipoVinculacion.Location = New System.Drawing.Point(739, 50)
        Me.Cb_TipoVinculacion.Name = "Cb_TipoVinculacion"
        Me.Cb_TipoVinculacion.Size = New System.Drawing.Size(134, 21)
        Me.Cb_TipoVinculacion.TabIndex = 72
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(629, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 13)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "Tipo de Vinculación:"
        '
        'Tp_AfectacionAmbDaños
        '
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Lb_AfectacionDaño)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Lb_NombreInvolucrado)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Lb_CantidadSustancia)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Lb_CargoAfectacionDaños)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Lb_AtencionPrestadaAfectacionDaños)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Lb_UnidadSustancia)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Cb_CargoAfectacionDaños)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Cb_UnidadSustancia)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Tb_CantidadSustancia)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Tb_SustanciaProceso)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Tb_AtencionPrestadaAfectacionDaños)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Tb_AfectacionDaño)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Lb_SustanciaProceso)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños)
        Me.Tp_AfectacionAmbDaños.Controls.Add(Me.Cu_BuscarPersonaInvolucradaAfectacionDaños)
        Me.Tp_AfectacionAmbDaños.Location = New System.Drawing.Point(4, 22)
        Me.Tp_AfectacionAmbDaños.Name = "Tp_AfectacionAmbDaños"
        Me.Tp_AfectacionAmbDaños.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_AfectacionAmbDaños.Size = New System.Drawing.Size(906, 552)
        Me.Tp_AfectacionAmbDaños.TabIndex = 6
        Me.Tp_AfectacionAmbDaños.Text = "Información de la Afectación"
        Me.Tp_AfectacionAmbDaños.UseVisualStyleBackColor = True
        '
        'Lb_AfectacionDaño
        '
        Me.Lb_AfectacionDaño.AutoSize = True
        Me.Lb_AfectacionDaño.Location = New System.Drawing.Point(124, 49)
        Me.Lb_AfectacionDaño.Name = "Lb_AfectacionDaño"
        Me.Lb_AfectacionDaño.Size = New System.Drawing.Size(61, 13)
        Me.Lb_AfectacionDaño.TabIndex = 130
        Me.Lb_AfectacionDaño.Text = "Afectación:"
        '
        'Lb_NombreInvolucrado
        '
        Me.Lb_NombreInvolucrado.AutoSize = True
        Me.Lb_NombreInvolucrado.Location = New System.Drawing.Point(62, 82)
        Me.Lb_NombreInvolucrado.Name = "Lb_NombreInvolucrado"
        Me.Lb_NombreInvolucrado.Size = New System.Drawing.Size(123, 13)
        Me.Lb_NombreInvolucrado.TabIndex = 133
        Me.Lb_NombreInvolucrado.Text = "Nombre del Involucrado:"
        '
        'Lb_CantidadSustancia
        '
        Me.Lb_CantidadSustancia.AutoSize = True
        Me.Lb_CantidadSustancia.Location = New System.Drawing.Point(593, 18)
        Me.Lb_CantidadSustancia.Name = "Lb_CantidadSustancia"
        Me.Lb_CantidadSustancia.Size = New System.Drawing.Size(52, 13)
        Me.Lb_CantidadSustancia.TabIndex = 128
        Me.Lb_CantidadSustancia.Text = "Cantidad:"
        '
        'Lb_CargoAfectacionDaños
        '
        Me.Lb_CargoAfectacionDaños.AutoSize = True
        Me.Lb_CargoAfectacionDaños.Location = New System.Drawing.Point(590, 82)
        Me.Lb_CargoAfectacionDaños.Name = "Lb_CargoAfectacionDaños"
        Me.Lb_CargoAfectacionDaños.Size = New System.Drawing.Size(38, 13)
        Me.Lb_CargoAfectacionDaños.TabIndex = 136
        Me.Lb_CargoAfectacionDaños.Text = "Cargo:"
        '
        'Lb_AtencionPrestadaAfectacionDaños
        '
        Me.Lb_AtencionPrestadaAfectacionDaños.AutoSize = True
        Me.Lb_AtencionPrestadaAfectacionDaños.Location = New System.Drawing.Point(18, 113)
        Me.Lb_AtencionPrestadaAfectacionDaños.Name = "Lb_AtencionPrestadaAfectacionDaños"
        Me.Lb_AtencionPrestadaAfectacionDaños.Size = New System.Drawing.Size(97, 13)
        Me.Lb_AtencionPrestadaAfectacionDaños.TabIndex = 138
        Me.Lb_AtencionPrestadaAfectacionDaños.Text = "Atención Prestada:"
        '
        'Lb_UnidadSustancia
        '
        Me.Lb_UnidadSustancia.AutoSize = True
        Me.Lb_UnidadSustancia.Location = New System.Drawing.Point(403, 18)
        Me.Lb_UnidadSustancia.Name = "Lb_UnidadSustancia"
        Me.Lb_UnidadSustancia.Size = New System.Drawing.Size(44, 13)
        Me.Lb_UnidadSustancia.TabIndex = 126
        Me.Lb_UnidadSustancia.Text = "Unidad:"
        '
        'Cb_CargoAfectacionDaños
        '
        Me.Cb_CargoAfectacionDaños.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_CargoAfectacionDaños.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_CargoAfectacionDaños.FormattingEnabled = True
        Me.Cb_CargoAfectacionDaños.Location = New System.Drawing.Point(634, 78)
        Me.Cb_CargoAfectacionDaños.Name = "Cb_CargoAfectacionDaños"
        Me.Cb_CargoAfectacionDaños.Size = New System.Drawing.Size(264, 21)
        Me.Cb_CargoAfectacionDaños.TabIndex = 137
        '
        'Cb_UnidadSustancia
        '
        Me.Cb_UnidadSustancia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_UnidadSustancia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_UnidadSustancia.FormattingEnabled = True
        Me.Cb_UnidadSustancia.Location = New System.Drawing.Point(452, 14)
        Me.Cb_UnidadSustancia.Name = "Cb_UnidadSustancia"
        Me.Cb_UnidadSustancia.Size = New System.Drawing.Size(121, 21)
        Me.Cb_UnidadSustancia.TabIndex = 127
        '
        'Tb_CantidadSustancia
        '
        Me.Tb_CantidadSustancia.Location = New System.Drawing.Point(652, 14)
        Me.Tb_CantidadSustancia.MaxLength = 18
        Me.Tb_CantidadSustancia.Name = "Tb_CantidadSustancia"
        Me.Tb_CantidadSustancia.Size = New System.Drawing.Size(100, 20)
        Me.Tb_CantidadSustancia.TabIndex = 129
        '
        'Tb_SustanciaProceso
        '
        Me.Tb_SustanciaProceso.Location = New System.Drawing.Point(190, 14)
        Me.Tb_SustanciaProceso.MaxLength = 50
        Me.Tb_SustanciaProceso.Name = "Tb_SustanciaProceso"
        Me.Tb_SustanciaProceso.Size = New System.Drawing.Size(195, 20)
        Me.Tb_SustanciaProceso.TabIndex = 125
        '
        'Tb_AtencionPrestadaAfectacionDaños
        '
        Me.Tb_AtencionPrestadaAfectacionDaños.Location = New System.Drawing.Point(18, 138)
        Me.Tb_AtencionPrestadaAfectacionDaños.MaxLength = 500
        Me.Tb_AtencionPrestadaAfectacionDaños.Multiline = True
        Me.Tb_AtencionPrestadaAfectacionDaños.Name = "Tb_AtencionPrestadaAfectacionDaños"
        Me.Tb_AtencionPrestadaAfectacionDaños.Size = New System.Drawing.Size(877, 197)
        Me.Tb_AtencionPrestadaAfectacionDaños.TabIndex = 139
        '
        'Tb_AfectacionDaño
        '
        Me.Tb_AfectacionDaño.Location = New System.Drawing.Point(190, 46)
        Me.Tb_AfectacionDaño.MaxLength = 100
        Me.Tb_AfectacionDaño.Name = "Tb_AfectacionDaño"
        Me.Tb_AfectacionDaño.Size = New System.Drawing.Size(709, 20)
        Me.Tb_AfectacionDaño.TabIndex = 132
        '
        'Lb_SustanciaProceso
        '
        Me.Lb_SustanciaProceso.AutoSize = True
        Me.Lb_SustanciaProceso.Location = New System.Drawing.Point(13, 18)
        Me.Lb_SustanciaProceso.Name = "Lb_SustanciaProceso"
        Me.Lb_SustanciaProceso.Size = New System.Drawing.Size(172, 13)
        Me.Lb_SustanciaProceso.TabIndex = 124
        Me.Lb_SustanciaProceso.Text = "Sustancia o Elemento Involucrado:"
        '
        'Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños
        '
        Me.Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños.CrearUsuario = False
        Me.Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños.Location = New System.Drawing.Point(550, 77)
        Me.Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños.Name = "Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños"
        Me.Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños.TabIndex = 135
        Me.Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaInvolucradaAfectacionDaños
        '
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Location = New System.Drawing.Point(190, 76)
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Name = "Cu_BuscarPersonaInvolucradaAfectacionDaños"
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Size = New System.Drawing.Size(364, 23)
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.TabIndex = 134
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Tipo = "PABO"
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.valorcajatexto = "IDENTIFICACION"
        '
        'Tp_ValoracionIncidente
        '
        Me.Tp_ValoracionIncidente.Controls.Add(Me.Gb_Costos)
        Me.Tp_ValoracionIncidente.Controls.Add(Me.Gb_PerdidaReal)
        Me.Tp_ValoracionIncidente.Controls.Add(Me.GroupBox4)
        Me.Tp_ValoracionIncidente.Location = New System.Drawing.Point(4, 22)
        Me.Tp_ValoracionIncidente.Name = "Tp_ValoracionIncidente"
        Me.Tp_ValoracionIncidente.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_ValoracionIncidente.Size = New System.Drawing.Size(906, 552)
        Me.Tp_ValoracionIncidente.TabIndex = 4
        Me.Tp_ValoracionIncidente.Text = "Valoración Incidente"
        Me.Tp_ValoracionIncidente.UseVisualStyleBackColor = True
        '
        'Gb_Costos
        '
        Me.Gb_Costos.Controls.Add(Me.Tb_Costo7)
        Me.Gb_Costos.Controls.Add(Me.Lb_Costo7)
        Me.Gb_Costos.Controls.Add(Me.Tb_Especificar6)
        Me.Gb_Costos.Controls.Add(Me.Lb_Especificar6)
        Me.Gb_Costos.Controls.Add(Me.Tb_Costo6)
        Me.Gb_Costos.Controls.Add(Me.Lb_Costo6)
        Me.Gb_Costos.Controls.Add(Me.Tb_Especificar2)
        Me.Gb_Costos.Controls.Add(Me.Lb_Especificar2)
        Me.Gb_Costos.Controls.Add(Me.Tb_Especificar3)
        Me.Gb_Costos.Controls.Add(Me.Lb_Especificar3)
        Me.Gb_Costos.Controls.Add(Me.Tb_Especificar4)
        Me.Gb_Costos.Controls.Add(Me.Lb_Especificar4)
        Me.Gb_Costos.Controls.Add(Me.Tb_Especificar5)
        Me.Gb_Costos.Controls.Add(Me.Lb_Especificar5)
        Me.Gb_Costos.Controls.Add(Me.Tb_Especificar1)
        Me.Gb_Costos.Controls.Add(Me.Lb_Especificar1)
        Me.Gb_Costos.Controls.Add(Me.Tb_Costo2)
        Me.Gb_Costos.Controls.Add(Me.Lb_Costo2)
        Me.Gb_Costos.Controls.Add(Me.Tb_Costo3)
        Me.Gb_Costos.Controls.Add(Me.Lb_Costo3)
        Me.Gb_Costos.Controls.Add(Me.Tb_Costo4)
        Me.Gb_Costos.Controls.Add(Me.Lb_Costo4)
        Me.Gb_Costos.Controls.Add(Me.Tb_Costo5)
        Me.Gb_Costos.Controls.Add(Me.Lb_Costo5)
        Me.Gb_Costos.Controls.Add(Me.Tb_Costo1)
        Me.Gb_Costos.Controls.Add(Me.Lb_Costo1)
        Me.Gb_Costos.Location = New System.Drawing.Point(9, 191)
        Me.Gb_Costos.Name = "Gb_Costos"
        Me.Gb_Costos.Size = New System.Drawing.Size(890, 234)
        Me.Gb_Costos.TabIndex = 150
        Me.Gb_Costos.TabStop = False
        Me.Gb_Costos.Text = "Costos Estimados del Accidente"
        '
        'Tb_Costo7
        '
        Me.Tb_Costo7.Enabled = False
        Me.Tb_Costo7.Location = New System.Drawing.Point(133, 201)
        Me.Tb_Costo7.MaxLength = 18
        Me.Tb_Costo7.Name = "Tb_Costo7"
        Me.Tb_Costo7.ReadOnly = True
        Me.Tb_Costo7.Size = New System.Drawing.Size(176, 20)
        Me.Tb_Costo7.TabIndex = 176
        '
        'Lb_Costo7
        '
        Me.Lb_Costo7.AutoSize = True
        Me.Lb_Costo7.Location = New System.Drawing.Point(25, 205)
        Me.Lb_Costo7.Name = "Lb_Costo7"
        Me.Lb_Costo7.Size = New System.Drawing.Size(99, 13)
        Me.Lb_Costo7.TabIndex = 175
        Me.Lb_Costo7.Text = "Costos Estimados $"
        '
        'Tb_Especificar6
        '
        Me.Tb_Especificar6.Location = New System.Drawing.Point(394, 171)
        Me.Tb_Especificar6.MaxLength = 70
        Me.Tb_Especificar6.Name = "Tb_Especificar6"
        Me.Tb_Especificar6.Size = New System.Drawing.Size(470, 20)
        Me.Tb_Especificar6.TabIndex = 174
        '
        'Lb_Especificar6
        '
        Me.Lb_Especificar6.AutoSize = True
        Me.Lb_Especificar6.Location = New System.Drawing.Point(327, 175)
        Me.Lb_Especificar6.Name = "Lb_Especificar6"
        Me.Lb_Especificar6.Size = New System.Drawing.Size(62, 13)
        Me.Lb_Especificar6.TabIndex = 173
        Me.Lb_Especificar6.Text = "Especificar:"
        '
        'Tb_Costo6
        '
        Me.Tb_Costo6.Location = New System.Drawing.Point(133, 171)
        Me.Tb_Costo6.MaxLength = 18
        Me.Tb_Costo6.Name = "Tb_Costo6"
        Me.Tb_Costo6.Size = New System.Drawing.Size(176, 20)
        Me.Tb_Costo6.TabIndex = 172
        '
        'Lb_Costo6
        '
        Me.Lb_Costo6.AutoSize = True
        Me.Lb_Costo6.Location = New System.Drawing.Point(83, 175)
        Me.Lb_Costo6.Name = "Lb_Costo6"
        Me.Lb_Costo6.Size = New System.Drawing.Size(41, 13)
        Me.Lb_Costo6.TabIndex = 171
        Me.Lb_Costo6.Text = "Otros $"
        '
        'Tb_Especificar2
        '
        Me.Tb_Especificar2.Location = New System.Drawing.Point(394, 52)
        Me.Tb_Especificar2.MaxLength = 70
        Me.Tb_Especificar2.Name = "Tb_Especificar2"
        Me.Tb_Especificar2.Size = New System.Drawing.Size(470, 20)
        Me.Tb_Especificar2.TabIndex = 158
        '
        'Lb_Especificar2
        '
        Me.Lb_Especificar2.AutoSize = True
        Me.Lb_Especificar2.Location = New System.Drawing.Point(327, 56)
        Me.Lb_Especificar2.Name = "Lb_Especificar2"
        Me.Lb_Especificar2.Size = New System.Drawing.Size(62, 13)
        Me.Lb_Especificar2.TabIndex = 157
        Me.Lb_Especificar2.Text = "Especificar:"
        '
        'Tb_Especificar3
        '
        Me.Tb_Especificar3.Location = New System.Drawing.Point(394, 83)
        Me.Tb_Especificar3.MaxLength = 70
        Me.Tb_Especificar3.Name = "Tb_Especificar3"
        Me.Tb_Especificar3.Size = New System.Drawing.Size(470, 20)
        Me.Tb_Especificar3.TabIndex = 162
        '
        'Lb_Especificar3
        '
        Me.Lb_Especificar3.AutoSize = True
        Me.Lb_Especificar3.Location = New System.Drawing.Point(327, 87)
        Me.Lb_Especificar3.Name = "Lb_Especificar3"
        Me.Lb_Especificar3.Size = New System.Drawing.Size(62, 13)
        Me.Lb_Especificar3.TabIndex = 161
        Me.Lb_Especificar3.Text = "Especificar:"
        '
        'Tb_Especificar4
        '
        Me.Tb_Especificar4.Location = New System.Drawing.Point(394, 114)
        Me.Tb_Especificar4.MaxLength = 70
        Me.Tb_Especificar4.Name = "Tb_Especificar4"
        Me.Tb_Especificar4.Size = New System.Drawing.Size(470, 20)
        Me.Tb_Especificar4.TabIndex = 166
        '
        'Lb_Especificar4
        '
        Me.Lb_Especificar4.AutoSize = True
        Me.Lb_Especificar4.Location = New System.Drawing.Point(327, 118)
        Me.Lb_Especificar4.Name = "Lb_Especificar4"
        Me.Lb_Especificar4.Size = New System.Drawing.Size(62, 13)
        Me.Lb_Especificar4.TabIndex = 165
        Me.Lb_Especificar4.Text = "Especificar:"
        '
        'Tb_Especificar5
        '
        Me.Tb_Especificar5.Location = New System.Drawing.Point(394, 143)
        Me.Tb_Especificar5.MaxLength = 70
        Me.Tb_Especificar5.Name = "Tb_Especificar5"
        Me.Tb_Especificar5.Size = New System.Drawing.Size(470, 20)
        Me.Tb_Especificar5.TabIndex = 170
        '
        'Lb_Especificar5
        '
        Me.Lb_Especificar5.AutoSize = True
        Me.Lb_Especificar5.Location = New System.Drawing.Point(327, 147)
        Me.Lb_Especificar5.Name = "Lb_Especificar5"
        Me.Lb_Especificar5.Size = New System.Drawing.Size(62, 13)
        Me.Lb_Especificar5.TabIndex = 169
        Me.Lb_Especificar5.Text = "Especificar:"
        '
        'Tb_Especificar1
        '
        Me.Tb_Especificar1.Location = New System.Drawing.Point(394, 21)
        Me.Tb_Especificar1.MaxLength = 70
        Me.Tb_Especificar1.Name = "Tb_Especificar1"
        Me.Tb_Especificar1.Size = New System.Drawing.Size(470, 20)
        Me.Tb_Especificar1.TabIndex = 154
        '
        'Lb_Especificar1
        '
        Me.Lb_Especificar1.AutoSize = True
        Me.Lb_Especificar1.Location = New System.Drawing.Point(327, 25)
        Me.Lb_Especificar1.Name = "Lb_Especificar1"
        Me.Lb_Especificar1.Size = New System.Drawing.Size(62, 13)
        Me.Lb_Especificar1.TabIndex = 153
        Me.Lb_Especificar1.Text = "Especificar:"
        '
        'Tb_Costo2
        '
        Me.Tb_Costo2.Location = New System.Drawing.Point(133, 52)
        Me.Tb_Costo2.MaxLength = 18
        Me.Tb_Costo2.Name = "Tb_Costo2"
        Me.Tb_Costo2.Size = New System.Drawing.Size(176, 20)
        Me.Tb_Costo2.TabIndex = 156
        '
        'Lb_Costo2
        '
        Me.Lb_Costo2.AutoSize = True
        Me.Lb_Costo2.Location = New System.Drawing.Point(11, 56)
        Me.Lb_Costo2.Name = "Lb_Costo2"
        Me.Lb_Costo2.Size = New System.Drawing.Size(113, 13)
        Me.Lb_Costo2.TabIndex = 155
        Me.Lb_Costo2.Text = "Perdida de Producto $"
        '
        'Tb_Costo3
        '
        Me.Tb_Costo3.Location = New System.Drawing.Point(133, 83)
        Me.Tb_Costo3.MaxLength = 18
        Me.Tb_Costo3.Name = "Tb_Costo3"
        Me.Tb_Costo3.Size = New System.Drawing.Size(176, 20)
        Me.Tb_Costo3.TabIndex = 160
        '
        'Lb_Costo3
        '
        Me.Lb_Costo3.AutoSize = True
        Me.Lb_Costo3.Location = New System.Drawing.Point(42, 87)
        Me.Lb_Costo3.Name = "Lb_Costo3"
        Me.Lb_Costo3.Size = New System.Drawing.Size(82, 13)
        Me.Lb_Costo3.TabIndex = 159
        Me.Lb_Costo3.Text = "Reparaciones $"
        '
        'Tb_Costo4
        '
        Me.Tb_Costo4.Location = New System.Drawing.Point(133, 114)
        Me.Tb_Costo4.MaxLength = 18
        Me.Tb_Costo4.Name = "Tb_Costo4"
        Me.Tb_Costo4.Size = New System.Drawing.Size(176, 20)
        Me.Tb_Costo4.TabIndex = 164
        '
        'Lb_Costo4
        '
        Me.Lb_Costo4.AutoSize = True
        Me.Lb_Costo4.Location = New System.Drawing.Point(45, 118)
        Me.Lb_Costo4.Name = "Lb_Costo4"
        Me.Lb_Costo4.Size = New System.Drawing.Size(79, 13)
        Me.Lb_Costo4.TabIndex = 163
        Me.Lb_Costo4.Text = "Investigacion $"
        '
        'Tb_Costo5
        '
        Me.Tb_Costo5.Location = New System.Drawing.Point(133, 143)
        Me.Tb_Costo5.MaxLength = 18
        Me.Tb_Costo5.Name = "Tb_Costo5"
        Me.Tb_Costo5.Size = New System.Drawing.Size(176, 20)
        Me.Tb_Costo5.TabIndex = 168
        '
        'Lb_Costo5
        '
        Me.Lb_Costo5.AutoSize = True
        Me.Lb_Costo5.Location = New System.Drawing.Point(8, 147)
        Me.Lb_Costo5.Name = "Lb_Costo5"
        Me.Lb_Costo5.Size = New System.Drawing.Size(116, 13)
        Me.Lb_Costo5.TabIndex = 167
        Me.Lb_Costo5.Text = "Acciones Correctivas $"
        '
        'Tb_Costo1
        '
        Me.Tb_Costo1.Location = New System.Drawing.Point(133, 21)
        Me.Tb_Costo1.MaxLength = 18
        Me.Tb_Costo1.Name = "Tb_Costo1"
        Me.Tb_Costo1.Size = New System.Drawing.Size(176, 20)
        Me.Tb_Costo1.TabIndex = 152
        '
        'Lb_Costo1
        '
        Me.Lb_Costo1.AutoSize = True
        Me.Lb_Costo1.Location = New System.Drawing.Point(78, 25)
        Me.Lb_Costo1.Name = "Lb_Costo1"
        Me.Lb_Costo1.Size = New System.Drawing.Size(46, 13)
        Me.Lb_Costo1.TabIndex = 151
        Me.Lb_Costo1.Text = "Costo 1:"
        '
        'Gb_PerdidaReal
        '
        Me.Gb_PerdidaReal.Controls.Add(Me.Tb_CategoriaResultanteReal)
        Me.Gb_PerdidaReal.Controls.Add(Me.Lb_CategoriaResultanteReal)
        Me.Gb_PerdidaReal.Controls.Add(Me.Cb_RecurrenciaReal)
        Me.Gb_PerdidaReal.Controls.Add(Me.Label64)
        Me.Gb_PerdidaReal.Controls.Add(Me.Cb_SeveridadReal)
        Me.Gb_PerdidaReal.Controls.Add(Me.Label66)
        Me.Gb_PerdidaReal.Location = New System.Drawing.Point(9, 429)
        Me.Gb_PerdidaReal.Name = "Gb_PerdidaReal"
        Me.Gb_PerdidaReal.Size = New System.Drawing.Size(890, 81)
        Me.Gb_PerdidaReal.TabIndex = 177
        Me.Gb_PerdidaReal.TabStop = False
        Me.Gb_PerdidaReal.Text = "Perdida Real"
        '
        'Tb_CategoriaResultanteReal
        '
        Me.Tb_CategoriaResultanteReal.Location = New System.Drawing.Point(132, 17)
        Me.Tb_CategoriaResultanteReal.Name = "Tb_CategoriaResultanteReal"
        Me.Tb_CategoriaResultanteReal.Size = New System.Drawing.Size(210, 20)
        Me.Tb_CategoriaResultanteReal.TabIndex = 180
        '
        'Lb_CategoriaResultanteReal
        '
        Me.Lb_CategoriaResultanteReal.AutoSize = True
        Me.Lb_CategoriaResultanteReal.Location = New System.Drawing.Point(14, 22)
        Me.Lb_CategoriaResultanteReal.Name = "Lb_CategoriaResultanteReal"
        Me.Lb_CategoriaResultanteReal.Size = New System.Drawing.Size(109, 13)
        Me.Lb_CategoriaResultanteReal.TabIndex = 179
        Me.Lb_CategoriaResultanteReal.Text = "Categoria Resultante:"
        '
        'Cb_RecurrenciaReal
        '
        Me.Cb_RecurrenciaReal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_RecurrenciaReal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_RecurrenciaReal.FormattingEnabled = True
        Me.Cb_RecurrenciaReal.Items.AddRange(New Object() {"Uno en 3 años", "Uno en 2 años", "Uno en 1 año"})
        Me.Cb_RecurrenciaReal.Location = New System.Drawing.Point(429, 45)
        Me.Cb_RecurrenciaReal.Name = "Cb_RecurrenciaReal"
        Me.Cb_RecurrenciaReal.Size = New System.Drawing.Size(127, 21)
        Me.Cb_RecurrenciaReal.TabIndex = 183
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(358, 50)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(65, 13)
        Me.Label64.TabIndex = 182
        Me.Label64.Text = "Recurrencia"
        '
        'Cb_SeveridadReal
        '
        Me.Cb_SeveridadReal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_SeveridadReal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_SeveridadReal.FormattingEnabled = True
        Me.Cb_SeveridadReal.Location = New System.Drawing.Point(131, 45)
        Me.Cb_SeveridadReal.Name = "Cb_SeveridadReal"
        Me.Cb_SeveridadReal.Size = New System.Drawing.Size(211, 21)
        Me.Cb_SeveridadReal.TabIndex = 181
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(68, 50)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(55, 13)
        Me.Label66.TabIndex = 181
        Me.Label66.Text = "Severidad"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Tb_CategoriaResultante)
        Me.GroupBox4.Controls.Add(Me.Lb_CategoriaResultante)
        Me.GroupBox4.Controls.Add(Me.Tb_PeorConsecuencia)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.Cb_Recurrencia)
        Me.GroupBox4.Controls.Add(Me.Label50)
        Me.GroupBox4.Controls.Add(Me.Cb_Severidad)
        Me.GroupBox4.Controls.Add(Me.Label51)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(890, 175)
        Me.GroupBox4.TabIndex = 140
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Perdida Potencial"
        '
        'Tb_CategoriaResultante
        '
        Me.Tb_CategoriaResultante.Location = New System.Drawing.Point(128, 21)
        Me.Tb_CategoriaResultante.Name = "Tb_CategoriaResultante"
        Me.Tb_CategoriaResultante.Size = New System.Drawing.Size(211, 20)
        Me.Tb_CategoriaResultante.TabIndex = 143
        '
        'Lb_CategoriaResultante
        '
        Me.Lb_CategoriaResultante.AutoSize = True
        Me.Lb_CategoriaResultante.Location = New System.Drawing.Point(11, 26)
        Me.Lb_CategoriaResultante.Name = "Lb_CategoriaResultante"
        Me.Lb_CategoriaResultante.Size = New System.Drawing.Size(111, 13)
        Me.Lb_CategoriaResultante.TabIndex = 142
        Me.Lb_CategoriaResultante.Text = "Categoría Resultante:"
        '
        'Tb_PeorConsecuencia
        '
        Me.Tb_PeorConsecuencia.Location = New System.Drawing.Point(14, 101)
        Me.Tb_PeorConsecuencia.MaxLength = 100
        Me.Tb_PeorConsecuencia.Multiline = True
        Me.Tb_PeorConsecuencia.Name = "Tb_PeorConsecuencia"
        Me.Tb_PeorConsecuencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tb_PeorConsecuencia.Size = New System.Drawing.Size(860, 62)
        Me.Tb_PeorConsecuencia.TabIndex = 149
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(11, 79)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(298, 13)
        Me.Label52.TabIndex = 148
        Me.Label52.Text = "¿Cúal pudo haber sido la peor consecuencia de este evento?"
        '
        'Cb_Recurrencia
        '
        Me.Cb_Recurrencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Recurrencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Recurrencia.FormattingEnabled = True
        Me.Cb_Recurrencia.Items.AddRange(New Object() {"Uno en 3 años", "Uno en 2 años", "Uno en 1 año"})
        Me.Cb_Recurrencia.Location = New System.Drawing.Point(438, 51)
        Me.Cb_Recurrencia.Name = "Cb_Recurrencia"
        Me.Cb_Recurrencia.Size = New System.Drawing.Size(127, 21)
        Me.Cb_Recurrencia.TabIndex = 147
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(362, 55)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(68, 13)
        Me.Label50.TabIndex = 146
        Me.Label50.Text = "Recurrencia:"
        '
        'Cb_Severidad
        '
        Me.Cb_Severidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Severidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Severidad.FormattingEnabled = True
        Me.Cb_Severidad.Location = New System.Drawing.Point(128, 51)
        Me.Cb_Severidad.Name = "Cb_Severidad"
        Me.Cb_Severidad.Size = New System.Drawing.Size(211, 21)
        Me.Cb_Severidad.TabIndex = 145
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(64, 55)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(58, 13)
        Me.Label51.TabIndex = 144
        Me.Label51.Text = "Severidad:"
        '
        'Tp_Testigos
        '
        Me.Tp_Testigos.Controls.Add(Me.Gb_Preguntas)
        Me.Tp_Testigos.Controls.Add(Me.Label68)
        Me.Tp_Testigos.Controls.Add(Me.Dgv_Testigos)
        Me.Tp_Testigos.Controls.Add(Me.Pn_tituloConceptos)
        Me.Tp_Testigos.Location = New System.Drawing.Point(4, 22)
        Me.Tp_Testigos.Name = "Tp_Testigos"
        Me.Tp_Testigos.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_Testigos.Size = New System.Drawing.Size(906, 552)
        Me.Tp_Testigos.TabIndex = 2
        Me.Tp_Testigos.Text = "Testigos"
        Me.Tp_Testigos.UseVisualStyleBackColor = True
        '
        'Gb_Preguntas
        '
        Me.Gb_Preguntas.Controls.Add(Me.Gb_Pregunta2)
        Me.Gb_Preguntas.Controls.Add(Me.Gb_Pregunta1)
        Me.Gb_Preguntas.Location = New System.Drawing.Point(8, 296)
        Me.Gb_Preguntas.Name = "Gb_Preguntas"
        Me.Gb_Preguntas.Size = New System.Drawing.Size(891, 167)
        Me.Gb_Preguntas.TabIndex = 188
        Me.Gb_Preguntas.TabStop = False
        '
        'Gb_Pregunta2
        '
        Me.Gb_Pregunta2.Controls.Add(Me.Tb_Pregunta2)
        Me.Gb_Pregunta2.Controls.Add(Me.Lb_Pregunta2)
        Me.Gb_Pregunta2.Controls.Add(Me.Rb_Pregunta2No)
        Me.Gb_Pregunta2.Controls.Add(Me.Rb_Pregunta2Si)
        Me.Gb_Pregunta2.Location = New System.Drawing.Point(6, 89)
        Me.Gb_Pregunta2.Name = "Gb_Pregunta2"
        Me.Gb_Pregunta2.Size = New System.Drawing.Size(874, 70)
        Me.Gb_Pregunta2.TabIndex = 193
        Me.Gb_Pregunta2.TabStop = False
        Me.Gb_Pregunta2.Text = " ¿Se habían identificado conductas o condiciones riesgosas previas o durante el i" & _
    "ncidente?"
        '
        'Tb_Pregunta2
        '
        Me.Tb_Pregunta2.Location = New System.Drawing.Point(347, 21)
        Me.Tb_Pregunta2.MaxLength = 200
        Me.Tb_Pregunta2.Multiline = True
        Me.Tb_Pregunta2.Name = "Tb_Pregunta2"
        Me.Tb_Pregunta2.Size = New System.Drawing.Size(521, 40)
        Me.Tb_Pregunta2.TabIndex = 197
        '
        'Lb_Pregunta2
        '
        Me.Lb_Pregunta2.AutoSize = True
        Me.Lb_Pregunta2.Location = New System.Drawing.Point(113, 24)
        Me.Lb_Pregunta2.Name = "Lb_Pregunta2"
        Me.Lb_Pregunta2.Size = New System.Drawing.Size(228, 13)
        Me.Lb_Pregunta2.TabIndex = 196
        Me.Lb_Pregunta2.Text = "¿Dónde se identificaron y cómo se divulgaron?"
        '
        'Rb_Pregunta2No
        '
        Me.Rb_Pregunta2No.AutoSize = True
        Me.Rb_Pregunta2No.Location = New System.Drawing.Point(51, 22)
        Me.Rb_Pregunta2No.Name = "Rb_Pregunta2No"
        Me.Rb_Pregunta2No.Size = New System.Drawing.Size(39, 17)
        Me.Rb_Pregunta2No.TabIndex = 195
        Me.Rb_Pregunta2No.TabStop = True
        Me.Rb_Pregunta2No.Text = "No"
        Me.Rb_Pregunta2No.UseVisualStyleBackColor = True
        '
        'Rb_Pregunta2Si
        '
        Me.Rb_Pregunta2Si.AutoSize = True
        Me.Rb_Pregunta2Si.Location = New System.Drawing.Point(11, 22)
        Me.Rb_Pregunta2Si.Name = "Rb_Pregunta2Si"
        Me.Rb_Pregunta2Si.Size = New System.Drawing.Size(34, 17)
        Me.Rb_Pregunta2Si.TabIndex = 194
        Me.Rb_Pregunta2Si.TabStop = True
        Me.Rb_Pregunta2Si.Text = "Si"
        Me.Rb_Pregunta2Si.UseVisualStyleBackColor = True
        '
        'Gb_Pregunta1
        '
        Me.Gb_Pregunta1.Controls.Add(Me.Tb_Pregunta1)
        Me.Gb_Pregunta1.Controls.Add(Me.Lb_Pregunta1)
        Me.Gb_Pregunta1.Controls.Add(Me.Rb_Pregunta1No)
        Me.Gb_Pregunta1.Controls.Add(Me.Rb_Pregunta1Si)
        Me.Gb_Pregunta1.Location = New System.Drawing.Point(6, 13)
        Me.Gb_Pregunta1.Name = "Gb_Pregunta1"
        Me.Gb_Pregunta1.Size = New System.Drawing.Size(874, 70)
        Me.Gb_Pregunta1.TabIndex = 7
        Me.Gb_Pregunta1.TabStop = False
        Me.Gb_Pregunta1.Text = "¿Indicar si hay deficiencias en la identificación, evaluación de peligros y/o asp" & _
    "ectos ambientales, e implementación de controles?"
        '
        'Tb_Pregunta1
        '
        Me.Tb_Pregunta1.Location = New System.Drawing.Point(203, 21)
        Me.Tb_Pregunta1.MaxLength = 200
        Me.Tb_Pregunta1.Multiline = True
        Me.Tb_Pregunta1.Name = "Tb_Pregunta1"
        Me.Tb_Pregunta1.Size = New System.Drawing.Size(665, 40)
        Me.Tb_Pregunta1.TabIndex = 192
        '
        'Lb_Pregunta1
        '
        Me.Lb_Pregunta1.AutoSize = True
        Me.Lb_Pregunta1.Location = New System.Drawing.Point(113, 24)
        Me.Lb_Pregunta1.Name = "Lb_Pregunta1"
        Me.Lb_Pregunta1.Size = New System.Drawing.Size(84, 13)
        Me.Lb_Pregunta1.TabIndex = 191
        Me.Lb_Pregunta1.Text = "¿Cuáles fueron?"
        '
        'Rb_Pregunta1No
        '
        Me.Rb_Pregunta1No.AutoSize = True
        Me.Rb_Pregunta1No.Location = New System.Drawing.Point(51, 22)
        Me.Rb_Pregunta1No.Name = "Rb_Pregunta1No"
        Me.Rb_Pregunta1No.Size = New System.Drawing.Size(39, 17)
        Me.Rb_Pregunta1No.TabIndex = 190
        Me.Rb_Pregunta1No.TabStop = True
        Me.Rb_Pregunta1No.Text = "No"
        Me.Rb_Pregunta1No.UseVisualStyleBackColor = True
        '
        'Rb_Pregunta1Si
        '
        Me.Rb_Pregunta1Si.AutoSize = True
        Me.Rb_Pregunta1Si.Location = New System.Drawing.Point(11, 22)
        Me.Rb_Pregunta1Si.Name = "Rb_Pregunta1Si"
        Me.Rb_Pregunta1Si.Size = New System.Drawing.Size(34, 17)
        Me.Rb_Pregunta1Si.TabIndex = 189
        Me.Rb_Pregunta1Si.TabStop = True
        Me.Rb_Pregunta1Si.Text = "Si"
        Me.Rb_Pregunta1Si.UseVisualStyleBackColor = True
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(6, 297)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(0, 13)
        Me.Label68.TabIndex = 6
        '
        'Dgv_Testigos
        '
        Me.Dgv_Testigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Testigos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVT_CedulaTestigo, Me.DGVT_NombreTestigo, Me.DGVCB_CargoTestigo, Me.DGVTB_DescripcionTestigo})
        Me.Dgv_Testigos.Location = New System.Drawing.Point(3, 28)
        Me.Dgv_Testigos.Name = "Dgv_Testigos"
        Me.Dgv_Testigos.Size = New System.Drawing.Size(900, 263)
        Me.Dgv_Testigos.TabIndex = 187
        '
        'DGVT_CedulaTestigo
        '
        Me.DGVT_CedulaTestigo.DataPropertyName = "Cedula"
        Me.DGVT_CedulaTestigo.HeaderText = "Cedula"
        Me.DGVT_CedulaTestigo.Name = "DGVT_CedulaTestigo"
        Me.DGVT_CedulaTestigo.Width = 105
        '
        'DGVT_NombreTestigo
        '
        Me.DGVT_NombreTestigo.DataPropertyName = "Nombre"
        Me.DGVT_NombreTestigo.HeaderText = "Nombre"
        Me.DGVT_NombreTestigo.Name = "DGVT_NombreTestigo"
        Me.DGVT_NombreTestigo.Width = 200
        '
        'DGVCB_CargoTestigo
        '
        Me.DGVCB_CargoTestigo.DataPropertyName = "Cargo"
        Me.DGVCB_CargoTestigo.HeaderText = "Cargo"
        Me.DGVCB_CargoTestigo.Name = "DGVCB_CargoTestigo"
        Me.DGVCB_CargoTestigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVCB_CargoTestigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVCB_CargoTestigo.Width = 250
        '
        'DGVTB_DescripcionTestigo
        '
        Me.DGVTB_DescripcionTestigo.DataPropertyName = "DESCRIPCION"
        Me.DGVTB_DescripcionTestigo.HeaderText = "Observación"
        Me.DGVTB_DescripcionTestigo.MaxInputLength = 100
        Me.DGVTB_DescripcionTestigo.Name = "DGVTB_DescripcionTestigo"
        Me.DGVTB_DescripcionTestigo.Width = 300
        '
        'Pn_tituloConceptos
        '
        Me.Pn_tituloConceptos.BackColor = System.Drawing.Color.Gainsboro
        Me.Pn_tituloConceptos.Controls.Add(Me.Bt_AgregarTestigo)
        Me.Pn_tituloConceptos.Controls.Add(Me.Label48)
        Me.Pn_tituloConceptos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_tituloConceptos.Location = New System.Drawing.Point(3, 3)
        Me.Pn_tituloConceptos.Name = "Pn_tituloConceptos"
        Me.Pn_tituloConceptos.Size = New System.Drawing.Size(900, 25)
        Me.Pn_tituloConceptos.TabIndex = 1
        '
        'Bt_AgregarTestigo
        '
        Me.Bt_AgregarTestigo.Location = New System.Drawing.Point(78, 2)
        Me.Bt_AgregarTestigo.Name = "Bt_AgregarTestigo"
        Me.Bt_AgregarTestigo.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarTestigo.TabIndex = 186
        Me.Bt_AgregarTestigo.Text = "Agregar"
        Me.Bt_AgregarTestigo.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.Blue
        Me.Label48.Location = New System.Drawing.Point(3, 4)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(69, 16)
        Me.Label48.TabIndex = 0
        Me.Label48.Text = "Testigos"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tp_AnalisisCausas
        '
        Me.Tp_AnalisisCausas.Controls.Add(Me.Panel9)
        Me.Tp_AnalisisCausas.Controls.Add(Me.Dgv_CausasInmediatasCondiciones)
        Me.Tp_AnalisisCausas.Controls.Add(Me.Dgv_CausasBasicasTrabajo)
        Me.Tp_AnalisisCausas.Controls.Add(Me.DataGridView1)
        Me.Tp_AnalisisCausas.Controls.Add(Me.Panel8)
        Me.Tp_AnalisisCausas.Controls.Add(Me.Panel5)
        Me.Tp_AnalisisCausas.Controls.Add(Me.Dgv_CausasBasicasPersonales)
        Me.Tp_AnalisisCausas.Controls.Add(Me.Dgv_CausasInmediatasActos)
        Me.Tp_AnalisisCausas.Controls.Add(Me.Panel3)
        Me.Tp_AnalisisCausas.Location = New System.Drawing.Point(4, 22)
        Me.Tp_AnalisisCausas.Name = "Tp_AnalisisCausas"
        Me.Tp_AnalisisCausas.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_AnalisisCausas.Size = New System.Drawing.Size(906, 552)
        Me.Tp_AnalisisCausas.TabIndex = 10
        Me.Tp_AnalisisCausas.Text = "Análisis de Causas"
        Me.Tp_AnalisisCausas.UseVisualStyleBackColor = True
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel9.Controls.Add(Me.Bt_AgregarCausaBasicaTrabajo)
        Me.Panel9.Controls.Add(Me.Label40)
        Me.Panel9.Location = New System.Drawing.Point(3, 408)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(900, 25)
        Me.Panel9.TabIndex = 8
        '
        'Bt_AgregarCausaBasicaTrabajo
        '
        Me.Bt_AgregarCausaBasicaTrabajo.Location = New System.Drawing.Point(282, 2)
        Me.Bt_AgregarCausaBasicaTrabajo.Name = "Bt_AgregarCausaBasicaTrabajo"
        Me.Bt_AgregarCausaBasicaTrabajo.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarCausaBasicaTrabajo.TabIndex = 209
        Me.Bt_AgregarCausaBasicaTrabajo.Text = "Agregar"
        Me.Bt_AgregarCausaBasicaTrabajo.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Blue
        Me.Label40.Location = New System.Drawing.Point(3, 4)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(273, 16)
        Me.Label40.TabIndex = 0
        Me.Label40.Text = "Causas Básicas - Factores del trabajo"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_CausasInmediatasCondiciones
        '
        Me.Dgv_CausasInmediatasCondiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_CausasInmediatasCondiciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVC_TipoCausaInmediataCondiciones, Me.DGVT_DescripcionCausaInmediataCondiciones})
        Me.Dgv_CausasInmediatasCondiciones.Location = New System.Drawing.Point(2, 163)
        Me.Dgv_CausasInmediatasCondiciones.Name = "Dgv_CausasInmediatasCondiciones"
        Me.Dgv_CausasInmediatasCondiciones.Size = New System.Drawing.Size(900, 110)
        Me.Dgv_CausasInmediatasCondiciones.TabIndex = 206
        '
        'DGVC_TipoCausaInmediataCondiciones
        '
        Me.DGVC_TipoCausaInmediataCondiciones.DataPropertyName = "IDTIPOEVIDENCIAYCAUSA"
        Me.DGVC_TipoCausaInmediataCondiciones.HeaderText = "Tipo de causa inmediata"
        Me.DGVC_TipoCausaInmediataCondiciones.Name = "DGVC_TipoCausaInmediataCondiciones"
        Me.DGVC_TipoCausaInmediataCondiciones.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_TipoCausaInmediataCondiciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVC_TipoCausaInmediataCondiciones.Width = 305
        '
        'DGVT_DescripcionCausaInmediataCondiciones
        '
        Me.DGVT_DescripcionCausaInmediataCondiciones.DataPropertyName = "DESCRIPCION"
        Me.DGVT_DescripcionCausaInmediataCondiciones.HeaderText = "Descripcion"
        Me.DGVT_DescripcionCausaInmediataCondiciones.MaxInputLength = 300
        Me.DGVT_DescripcionCausaInmediataCondiciones.Name = "DGVT_DescripcionCausaInmediataCondiciones"
        Me.DGVT_DescripcionCausaInmediataCondiciones.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVT_DescripcionCausaInmediataCondiciones.Width = 550
        '
        'Dgv_CausasBasicasTrabajo
        '
        Me.Dgv_CausasBasicasTrabajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_CausasBasicasTrabajo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVC_TipoCausaBasicaTrabajo, Me.DGVT_DescripcionCausaBasicaTrabajo})
        Me.Dgv_CausasBasicasTrabajo.Location = New System.Drawing.Point(3, 433)
        Me.Dgv_CausasBasicasTrabajo.Name = "Dgv_CausasBasicasTrabajo"
        Me.Dgv_CausasBasicasTrabajo.Size = New System.Drawing.Size(900, 116)
        Me.Dgv_CausasBasicasTrabajo.TabIndex = 210
        '
        'DGVC_TipoCausaBasicaTrabajo
        '
        Me.DGVC_TipoCausaBasicaTrabajo.DataPropertyName = "IDTIPOEVIDENCIAYCAUSA"
        Me.DGVC_TipoCausaBasicaTrabajo.HeaderText = "Tipo de causa básica"
        Me.DGVC_TipoCausaBasicaTrabajo.Name = "DGVC_TipoCausaBasicaTrabajo"
        Me.DGVC_TipoCausaBasicaTrabajo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_TipoCausaBasicaTrabajo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVC_TipoCausaBasicaTrabajo.Width = 305
        '
        'DGVT_DescripcionCausaBasicaTrabajo
        '
        Me.DGVT_DescripcionCausaBasicaTrabajo.DataPropertyName = "DESCRIPCION"
        Me.DGVT_DescripcionCausaBasicaTrabajo.HeaderText = "Descripcion"
        Me.DGVT_DescripcionCausaBasicaTrabajo.MaxInputLength = 300
        Me.DGVT_DescripcionCausaBasicaTrabajo.Name = "DGVT_DescripcionCausaBasicaTrabajo"
        Me.DGVT_DescripcionCausaBasicaTrabajo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVT_DescripcionCausaBasicaTrabajo.Width = 550
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn1})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 167)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(0, 0)
        Me.DataGridView1.TabIndex = 9
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.HeaderText = "Tipo de causa inmediata"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn1.Width = 305
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 550
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel8.Controls.Add(Me.Bt_AgregarCausaInmediataCondiciones)
        Me.Panel8.Controls.Add(Me.Label38)
        Me.Panel8.Location = New System.Drawing.Point(3, 138)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(900, 25)
        Me.Panel8.TabIndex = 8
        '
        'Bt_AgregarCausaInmediataCondiciones
        '
        Me.Bt_AgregarCausaInmediataCondiciones.Location = New System.Drawing.Point(320, 2)
        Me.Bt_AgregarCausaInmediataCondiciones.Name = "Bt_AgregarCausaInmediataCondiciones"
        Me.Bt_AgregarCausaInmediataCondiciones.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarCausaInmediataCondiciones.TabIndex = 205
        Me.Bt_AgregarCausaInmediataCondiciones.Text = "Agregar"
        Me.Bt_AgregarCausaInmediataCondiciones.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Blue
        Me.Label38.Location = New System.Drawing.Point(3, 4)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(311, 16)
        Me.Label38.TabIndex = 0
        Me.Label38.Text = "Causas Inmediatas - Condiciones Inseguras"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel5.Controls.Add(Me.Bt_AgregarCausaBasicaPersonal)
        Me.Panel5.Controls.Add(Me.Label76)
        Me.Panel5.Location = New System.Drawing.Point(3, 273)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(900, 25)
        Me.Panel5.TabIndex = 7
        '
        'Bt_AgregarCausaBasicaPersonal
        '
        Me.Bt_AgregarCausaBasicaPersonal.Location = New System.Drawing.Point(286, 2)
        Me.Bt_AgregarCausaBasicaPersonal.Name = "Bt_AgregarCausaBasicaPersonal"
        Me.Bt_AgregarCausaBasicaPersonal.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarCausaBasicaPersonal.TabIndex = 207
        Me.Bt_AgregarCausaBasicaPersonal.Text = "Agregar"
        Me.Bt_AgregarCausaBasicaPersonal.UseVisualStyleBackColor = True
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.Blue
        Me.Label76.Location = New System.Drawing.Point(3, 4)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(277, 16)
        Me.Label76.TabIndex = 0
        Me.Label76.Text = "Causas Básicas - Factores Personales"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_CausasBasicasPersonales
        '
        Me.Dgv_CausasBasicasPersonales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_CausasBasicasPersonales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVC_TipoCausaBasicaPersonales, Me.Dgv_DescripcionCausaBasicaPersonales})
        Me.Dgv_CausasBasicasPersonales.Location = New System.Drawing.Point(3, 298)
        Me.Dgv_CausasBasicasPersonales.Name = "Dgv_CausasBasicasPersonales"
        Me.Dgv_CausasBasicasPersonales.Size = New System.Drawing.Size(900, 110)
        Me.Dgv_CausasBasicasPersonales.TabIndex = 208
        '
        'DGVC_TipoCausaBasicaPersonales
        '
        Me.DGVC_TipoCausaBasicaPersonales.DataPropertyName = "IDTIPOEVIDENCIAYCAUSA"
        Me.DGVC_TipoCausaBasicaPersonales.HeaderText = "Tipo de causa básica"
        Me.DGVC_TipoCausaBasicaPersonales.Name = "DGVC_TipoCausaBasicaPersonales"
        Me.DGVC_TipoCausaBasicaPersonales.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_TipoCausaBasicaPersonales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVC_TipoCausaBasicaPersonales.Width = 305
        '
        'Dgv_DescripcionCausaBasicaPersonales
        '
        Me.Dgv_DescripcionCausaBasicaPersonales.DataPropertyName = "DESCRIPCION"
        Me.Dgv_DescripcionCausaBasicaPersonales.HeaderText = "Descripcion"
        Me.Dgv_DescripcionCausaBasicaPersonales.MaxInputLength = 300
        Me.Dgv_DescripcionCausaBasicaPersonales.Name = "Dgv_DescripcionCausaBasicaPersonales"
        Me.Dgv_DescripcionCausaBasicaPersonales.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_DescripcionCausaBasicaPersonales.Width = 550
        '
        'Dgv_CausasInmediatasActos
        '
        Me.Dgv_CausasInmediatasActos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_CausasInmediatasActos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVC_TipoCausaInmediataActos, Me.DGVT_DescripcionCausaInmediataActos})
        Me.Dgv_CausasInmediatasActos.Location = New System.Drawing.Point(3, 28)
        Me.Dgv_CausasInmediatasActos.Name = "Dgv_CausasInmediatasActos"
        Me.Dgv_CausasInmediatasActos.Size = New System.Drawing.Size(900, 110)
        Me.Dgv_CausasInmediatasActos.TabIndex = 204
        '
        'DGVC_TipoCausaInmediataActos
        '
        Me.DGVC_TipoCausaInmediataActos.DataPropertyName = "IDTIPOEVIDENCIAYCAUSA"
        Me.DGVC_TipoCausaInmediataActos.HeaderText = "Tipo de causa inmediata"
        Me.DGVC_TipoCausaInmediataActos.Name = "DGVC_TipoCausaInmediataActos"
        Me.DGVC_TipoCausaInmediataActos.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_TipoCausaInmediataActos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVC_TipoCausaInmediataActos.Width = 305
        '
        'DGVT_DescripcionCausaInmediataActos
        '
        Me.DGVT_DescripcionCausaInmediataActos.DataPropertyName = "DESCRIPCION"
        Me.DGVT_DescripcionCausaInmediataActos.HeaderText = "Descripcion"
        Me.DGVT_DescripcionCausaInmediataActos.MaxInputLength = 300
        Me.DGVT_DescripcionCausaInmediataActos.Name = "DGVT_DescripcionCausaInmediataActos"
        Me.DGVT_DescripcionCausaInmediataActos.Width = 550
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.Label73)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(900, 25)
        Me.Panel3.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.Bt_AgregarCausaInmediataActos)
        Me.Panel4.Controls.Add(Me.Label74)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(900, 25)
        Me.Panel4.TabIndex = 4
        '
        'Bt_AgregarCausaInmediataActos
        '
        Me.Bt_AgregarCausaInmediataActos.Location = New System.Drawing.Point(273, 1)
        Me.Bt_AgregarCausaInmediataActos.Name = "Bt_AgregarCausaInmediataActos"
        Me.Bt_AgregarCausaInmediataActos.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarCausaInmediataActos.TabIndex = 203
        Me.Bt_AgregarCausaInmediataActos.Text = "Agregar"
        Me.Bt_AgregarCausaInmediataActos.UseVisualStyleBackColor = True
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.Blue
        Me.Label74.Location = New System.Drawing.Point(3, 4)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(264, 16)
        Me.Label74.TabIndex = 0
        Me.Label74.Text = "Causas Inmediatas - Actos Inseguros"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(90, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 21)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.Blue
        Me.Label73.Location = New System.Drawing.Point(3, 4)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(85, 16)
        Me.Label73.TabIndex = 0
        Me.Label73.Text = "Evidencias"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tp_PlanAccion
        '
        Me.Tp_PlanAccion.Controls.Add(Me.Tb_OtraEntidad)
        Me.Tp_PlanAccion.Controls.Add(Me.Lb_OtraEntidad)
        Me.Tp_PlanAccion.Controls.Add(Me.Ck_OtraEntidad)
        Me.Tp_PlanAccion.Controls.Add(Me.Ck_Cliente)
        Me.Tp_PlanAccion.Controls.Add(Me.Ck_AutoridadAmbiental)
        Me.Tp_PlanAccion.Controls.Add(Me.Dgv_Evidencias)
        Me.Tp_PlanAccion.Controls.Add(Me.Pn_Evidencias)
        Me.Tp_PlanAccion.Controls.Add(Me.Ck_MinisterioTrabajo)
        Me.Tp_PlanAccion.Controls.Add(Me.Ck_Organismo)
        Me.Tp_PlanAccion.Controls.Add(Me.Ck_CAR)
        Me.Tp_PlanAccion.Controls.Add(Me.Ck_EPS)
        Me.Tp_PlanAccion.Controls.Add(Me.Ck_ARL)
        Me.Tp_PlanAccion.Controls.Add(Me.Lb_EntidadNotificada)
        Me.Tp_PlanAccion.Controls.Add(Me.Dgv_AccionesATomar)
        Me.Tp_PlanAccion.Controls.Add(Me.Pn_Acciones)
        Me.Tp_PlanAccion.Location = New System.Drawing.Point(4, 22)
        Me.Tp_PlanAccion.Name = "Tp_PlanAccion"
        Me.Tp_PlanAccion.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_PlanAccion.Size = New System.Drawing.Size(906, 552)
        Me.Tp_PlanAccion.TabIndex = 11
        Me.Tp_PlanAccion.Text = "Plan de Acción"
        Me.Tp_PlanAccion.UseVisualStyleBackColor = True
        '
        'Tb_OtraEntidad
        '
        Me.Tb_OtraEntidad.Location = New System.Drawing.Point(321, 527)
        Me.Tb_OtraEntidad.MaxLength = 50
        Me.Tb_OtraEntidad.Name = "Tb_OtraEntidad"
        Me.Tb_OtraEntidad.Size = New System.Drawing.Size(390, 20)
        Me.Tb_OtraEntidad.TabIndex = 225
        '
        'Lb_OtraEntidad
        '
        Me.Lb_OtraEntidad.AutoSize = True
        Me.Lb_OtraEntidad.Location = New System.Drawing.Point(275, 530)
        Me.Lb_OtraEntidad.Name = "Lb_OtraEntidad"
        Me.Lb_OtraEntidad.Size = New System.Drawing.Size(40, 13)
        Me.Lb_OtraEntidad.TabIndex = 224
        Me.Lb_OtraEntidad.Text = "¿Cual?"
        '
        'Ck_OtraEntidad
        '
        Me.Ck_OtraEntidad.AutoSize = True
        Me.Ck_OtraEntidad.Location = New System.Drawing.Point(223, 529)
        Me.Ck_OtraEntidad.Name = "Ck_OtraEntidad"
        Me.Ck_OtraEntidad.Size = New System.Drawing.Size(46, 17)
        Me.Ck_OtraEntidad.TabIndex = 223
        Me.Ck_OtraEntidad.Text = "Otra"
        Me.Ck_OtraEntidad.UseVisualStyleBackColor = True
        '
        'Ck_Cliente
        '
        Me.Ck_Cliente.AutoSize = True
        Me.Ck_Cliente.Location = New System.Drawing.Point(164, 529)
        Me.Ck_Cliente.Name = "Ck_Cliente"
        Me.Ck_Cliente.Size = New System.Drawing.Size(58, 17)
        Me.Ck_Cliente.TabIndex = 222
        Me.Ck_Cliente.Text = "Cliente"
        Me.Ck_Cliente.UseVisualStyleBackColor = True
        '
        'Ck_AutoridadAmbiental
        '
        Me.Ck_AutoridadAmbiental.AutoSize = True
        Me.Ck_AutoridadAmbiental.Location = New System.Drawing.Point(731, 510)
        Me.Ck_AutoridadAmbiental.Name = "Ck_AutoridadAmbiental"
        Me.Ck_AutoridadAmbiental.Size = New System.Drawing.Size(120, 17)
        Me.Ck_AutoridadAmbiental.TabIndex = 221
        Me.Ck_AutoridadAmbiental.Text = "Autoridad Ambiental"
        Me.Ck_AutoridadAmbiental.UseVisualStyleBackColor = True
        '
        'Dgv_Evidencias
        '
        Me.Dgv_Evidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Evidencias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVC_TipoEvidencia, Me.DGVT_DescripcionEvidencia})
        Me.Dgv_Evidencias.Location = New System.Drawing.Point(3, 26)
        Me.Dgv_Evidencias.Name = "Dgv_Evidencias"
        Me.Dgv_Evidencias.Size = New System.Drawing.Size(900, 235)
        Me.Dgv_Evidencias.TabIndex = 212
        '
        'DGVC_TipoEvidencia
        '
        Me.DGVC_TipoEvidencia.DataPropertyName = "IDTIPOEVIDENCIAYCAUSA"
        Me.DGVC_TipoEvidencia.HeaderText = "Tipo de evidencia"
        Me.DGVC_TipoEvidencia.Name = "DGVC_TipoEvidencia"
        Me.DGVC_TipoEvidencia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_TipoEvidencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVC_TipoEvidencia.Width = 305
        '
        'DGVT_DescripcionEvidencia
        '
        Me.DGVT_DescripcionEvidencia.DataPropertyName = "DESCRIPCION"
        Me.DGVT_DescripcionEvidencia.HeaderText = "Descripcion"
        Me.DGVT_DescripcionEvidencia.MaxInputLength = 300
        Me.DGVT_DescripcionEvidencia.Name = "DGVT_DescripcionEvidencia"
        Me.DGVT_DescripcionEvidencia.Width = 550
        '
        'Pn_Evidencias
        '
        Me.Pn_Evidencias.BackColor = System.Drawing.Color.Gainsboro
        Me.Pn_Evidencias.Controls.Add(Me.Bt_AgregarEvidencia)
        Me.Pn_Evidencias.Controls.Add(Me.Label72)
        Me.Pn_Evidencias.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Evidencias.Location = New System.Drawing.Point(3, 3)
        Me.Pn_Evidencias.Name = "Pn_Evidencias"
        Me.Pn_Evidencias.Size = New System.Drawing.Size(900, 25)
        Me.Pn_Evidencias.TabIndex = 11
        '
        'Bt_AgregarEvidencia
        '
        Me.Bt_AgregarEvidencia.Location = New System.Drawing.Point(90, 2)
        Me.Bt_AgregarEvidencia.Name = "Bt_AgregarEvidencia"
        Me.Bt_AgregarEvidencia.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarEvidencia.TabIndex = 211
        Me.Bt_AgregarEvidencia.Text = "Agregar"
        Me.Bt_AgregarEvidencia.UseVisualStyleBackColor = True
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.Blue
        Me.Label72.Location = New System.Drawing.Point(3, 4)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(85, 16)
        Me.Label72.TabIndex = 0
        Me.Label72.Text = "Evidencias"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Ck_MinisterioTrabajo
        '
        Me.Ck_MinisterioTrabajo.AutoSize = True
        Me.Ck_MinisterioTrabajo.Location = New System.Drawing.Point(490, 510)
        Me.Ck_MinisterioTrabajo.Name = "Ck_MinisterioTrabajo"
        Me.Ck_MinisterioTrabajo.Size = New System.Drawing.Size(235, 17)
        Me.Ck_MinisterioTrabajo.TabIndex = 220
        Me.Ck_MinisterioTrabajo.Text = "Dirección Territorial del Ministerio de Trabajo"
        Me.Ck_MinisterioTrabajo.UseVisualStyleBackColor = True
        '
        'Ck_Organismo
        '
        Me.Ck_Organismo.AutoSize = True
        Me.Ck_Organismo.Location = New System.Drawing.Point(333, 510)
        Me.Ck_Organismo.Name = "Ck_Organismo"
        Me.Ck_Organismo.Size = New System.Drawing.Size(151, 17)
        Me.Ck_Organismo.TabIndex = 219
        Me.Ck_Organismo.Text = "Organismo de certificación"
        Me.Ck_Organismo.UseVisualStyleBackColor = True
        '
        'Ck_CAR
        '
        Me.Ck_CAR.AutoSize = True
        Me.Ck_CAR.Location = New System.Drawing.Point(279, 510)
        Me.Ck_CAR.Name = "Ck_CAR"
        Me.Ck_CAR.Size = New System.Drawing.Size(48, 17)
        Me.Ck_CAR.TabIndex = 218
        Me.Ck_CAR.Text = "CAR"
        Me.Ck_CAR.UseVisualStyleBackColor = True
        '
        'Ck_EPS
        '
        Me.Ck_EPS.AutoSize = True
        Me.Ck_EPS.Location = New System.Drawing.Point(223, 510)
        Me.Ck_EPS.Name = "Ck_EPS"
        Me.Ck_EPS.Size = New System.Drawing.Size(47, 17)
        Me.Ck_EPS.TabIndex = 217
        Me.Ck_EPS.Text = "EPS"
        Me.Ck_EPS.UseVisualStyleBackColor = True
        '
        'Ck_ARL
        '
        Me.Ck_ARL.AutoSize = True
        Me.Ck_ARL.Location = New System.Drawing.Point(164, 509)
        Me.Ck_ARL.Name = "Ck_ARL"
        Me.Ck_ARL.Size = New System.Drawing.Size(47, 17)
        Me.Ck_ARL.TabIndex = 216
        Me.Ck_ARL.Text = "ARL"
        Me.Ck_ARL.UseVisualStyleBackColor = True
        '
        'Lb_EntidadNotificada
        '
        Me.Lb_EntidadNotificada.AutoSize = True
        Me.Lb_EntidadNotificada.Location = New System.Drawing.Point(9, 510)
        Me.Lb_EntidadNotificada.Name = "Lb_EntidadNotificada"
        Me.Lb_EntidadNotificada.Size = New System.Drawing.Size(150, 13)
        Me.Lb_EntidadNotificada.TabIndex = 215
        Me.Lb_EntidadNotificada.Text = "Grupos de Interés Notificados:"
        '
        'Dgv_AccionesATomar
        '
        Me.Dgv_AccionesATomar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_AccionesATomar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVT_Accion, Me.DGVCB_CargoAcciones, Me.DGVC_Prioridad})
        Me.Dgv_AccionesATomar.Location = New System.Drawing.Point(3, 289)
        Me.Dgv_AccionesATomar.Name = "Dgv_AccionesATomar"
        Me.Dgv_AccionesATomar.Size = New System.Drawing.Size(900, 215)
        Me.Dgv_AccionesATomar.TabIndex = 214
        '
        'DGVT_Accion
        '
        Me.DGVT_Accion.DataPropertyName = "Accion"
        Me.DGVT_Accion.HeaderText = "Accion"
        Me.DGVT_Accion.MaxInputLength = 100
        Me.DGVT_Accion.Name = "DGVT_Accion"
        Me.DGVT_Accion.Width = 300
        '
        'DGVCB_CargoAcciones
        '
        Me.DGVCB_CargoAcciones.DataPropertyName = "CARGO"
        Me.DGVCB_CargoAcciones.HeaderText = "Cargo"
        Me.DGVCB_CargoAcciones.Name = "DGVCB_CargoAcciones"
        Me.DGVCB_CargoAcciones.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVCB_CargoAcciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVCB_CargoAcciones.Width = 280
        '
        'DGVC_Prioridad
        '
        Me.DGVC_Prioridad.DataPropertyName = "PRIORIDAD"
        Me.DGVC_Prioridad.HeaderText = "Prioridad"
        Me.DGVC_Prioridad.Name = "DGVC_Prioridad"
        Me.DGVC_Prioridad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_Prioridad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVC_Prioridad.Width = 75
        '
        'Pn_Acciones
        '
        Me.Pn_Acciones.BackColor = System.Drawing.Color.Gainsboro
        Me.Pn_Acciones.Controls.Add(Me.Bt_AgregarAccion)
        Me.Pn_Acciones.Controls.Add(Me.Label75)
        Me.Pn_Acciones.Location = New System.Drawing.Point(3, 265)
        Me.Pn_Acciones.Name = "Pn_Acciones"
        Me.Pn_Acciones.Size = New System.Drawing.Size(900, 25)
        Me.Pn_Acciones.TabIndex = 3
        '
        'Bt_AgregarAccion
        '
        Me.Bt_AgregarAccion.Location = New System.Drawing.Point(90, 2)
        Me.Bt_AgregarAccion.Name = "Bt_AgregarAccion"
        Me.Bt_AgregarAccion.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarAccion.TabIndex = 213
        Me.Bt_AgregarAccion.Text = "Agregar"
        Me.Bt_AgregarAccion.UseVisualStyleBackColor = True
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.Blue
        Me.Label75.Location = New System.Drawing.Point(3, 4)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(72, 16)
        Me.Label75.TabIndex = 0
        Me.Label75.Text = "Acciones"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tp_Investigadores
        '
        Me.Tp_Investigadores.Controls.Add(Me.Cb_CargoAprobo)
        Me.Tp_Investigadores.Controls.Add(Me.Label87)
        Me.Tp_Investigadores.Controls.Add(Me.DTP_FechaAprobacion)
        Me.Tp_Investigadores.Controls.Add(Me.Label86)
        Me.Tp_Investigadores.Controls.Add(Me.Label85)
        Me.Tp_Investigadores.Controls.Add(Me.GroupBox5)
        Me.Tp_Investigadores.Controls.Add(Me.Gb_Concepto)
        Me.Tp_Investigadores.Controls.Add(Me.Dgv_Investigadores)
        Me.Tp_Investigadores.Controls.Add(Me.Panel7)
        Me.Tp_Investigadores.Controls.Add(Me.Cu_AsociarPersonaBodega10)
        Me.Tp_Investigadores.Controls.Add(Me.Cu_BuscarPersonaAprobo)
        Me.Tp_Investigadores.Location = New System.Drawing.Point(4, 22)
        Me.Tp_Investigadores.Name = "Tp_Investigadores"
        Me.Tp_Investigadores.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_Investigadores.Size = New System.Drawing.Size(906, 552)
        Me.Tp_Investigadores.TabIndex = 12
        Me.Tp_Investigadores.Text = "Equipo Investigador"
        Me.Tp_Investigadores.UseVisualStyleBackColor = True
        '
        'Cb_CargoAprobo
        '
        Me.Cb_CargoAprobo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_CargoAprobo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_CargoAprobo.FormattingEnabled = True
        Me.Cb_CargoAprobo.Location = New System.Drawing.Point(426, 507)
        Me.Cb_CargoAprobo.Name = "Cb_CargoAprobo"
        Me.Cb_CargoAprobo.Size = New System.Drawing.Size(160, 21)
        Me.Cb_CargoAprobo.TabIndex = 301
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Location = New System.Drawing.Point(385, 511)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(38, 13)
        Me.Label87.TabIndex = 300
        Me.Label87.Text = "Cargo:"
        '
        'DTP_FechaAprobacion
        '
        Me.DTP_FechaAprobacion.Checked = False
        Me.DTP_FechaAprobacion.Location = New System.Drawing.Point(695, 507)
        Me.DTP_FechaAprobacion.Name = "DTP_FechaAprobacion"
        Me.DTP_FechaAprobacion.ShowCheckBox = True
        Me.DTP_FechaAprobacion.Size = New System.Drawing.Size(200, 20)
        Me.DTP_FechaAprobacion.TabIndex = 303
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Location = New System.Drawing.Point(593, 511)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(97, 13)
        Me.Label86.TabIndex = 302
        Me.Label86.Text = "Fecha Aprobación:"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(14, 511)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(44, 13)
        Me.Label85.TabIndex = 257
        Me.Label85.Text = "Aprobó:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Ck_OtrosAnexos)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoAlerta)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoReporte24H)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoDocumentos)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoFotos)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoDibujos)
        Me.GroupBox5.Controls.Add(Me.Tb_OtrosAnexos)
        Me.GroupBox5.Controls.Add(Me.Lb_OtrosAnexos)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 425)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(890, 73)
        Me.GroupBox5.TabIndex = 247
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Anexos"
        '
        'Ck_OtrosAnexos
        '
        Me.Ck_OtrosAnexos.AutoSize = True
        Me.Ck_OtrosAnexos.Location = New System.Drawing.Point(607, 19)
        Me.Ck_OtrosAnexos.Name = "Ck_OtrosAnexos"
        Me.Ck_OtrosAnexos.Size = New System.Drawing.Size(51, 17)
        Me.Ck_OtrosAnexos.TabIndex = 253
        Me.Ck_OtrosAnexos.Text = "Otros"
        Me.Ck_OtrosAnexos.UseVisualStyleBackColor = True
        '
        'Ck_AnexoAlerta
        '
        Me.Ck_AnexoAlerta.AutoSize = True
        Me.Ck_AnexoAlerta.Location = New System.Drawing.Point(484, 19)
        Me.Ck_AnexoAlerta.Name = "Ck_AnexoAlerta"
        Me.Ck_AnexoAlerta.Size = New System.Drawing.Size(117, 17)
        Me.Ck_AnexoAlerta.TabIndex = 252
        Me.Ck_AnexoAlerta.Text = "Alerta de seguridad"
        Me.Ck_AnexoAlerta.UseVisualStyleBackColor = True
        '
        'Ck_AnexoReporte24H
        '
        Me.Ck_AnexoReporte24H.AutoSize = True
        Me.Ck_AnexoReporte24H.Location = New System.Drawing.Point(370, 19)
        Me.Ck_AnexoReporte24H.Name = "Ck_AnexoReporte24H"
        Me.Ck_AnexoReporte24H.Size = New System.Drawing.Size(108, 17)
        Me.Ck_AnexoReporte24H.TabIndex = 251
        Me.Ck_AnexoReporte24H.Text = "Reporte 24 horas"
        Me.Ck_AnexoReporte24H.UseVisualStyleBackColor = True
        '
        'Ck_AnexoDocumentos
        '
        Me.Ck_AnexoDocumentos.AutoSize = True
        Me.Ck_AnexoDocumentos.Location = New System.Drawing.Point(229, 19)
        Me.Ck_AnexoDocumentos.Name = "Ck_AnexoDocumentos"
        Me.Ck_AnexoDocumentos.Size = New System.Drawing.Size(135, 17)
        Me.Ck_AnexoDocumentos.TabIndex = 250
        Me.Ck_AnexoDocumentos.Text = "Documentos/Registros"
        Me.Ck_AnexoDocumentos.UseVisualStyleBackColor = True
        '
        'Ck_AnexoFotos
        '
        Me.Ck_AnexoFotos.AutoSize = True
        Me.Ck_AnexoFotos.Location = New System.Drawing.Point(134, 19)
        Me.Ck_AnexoFotos.Name = "Ck_AnexoFotos"
        Me.Ck_AnexoFotos.Size = New System.Drawing.Size(89, 17)
        Me.Ck_AnexoFotos.TabIndex = 249
        Me.Ck_AnexoFotos.Text = "Fotos/Videos"
        Me.Ck_AnexoFotos.UseVisualStyleBackColor = True
        '
        'Ck_AnexoDibujos
        '
        Me.Ck_AnexoDibujos.AutoSize = True
        Me.Ck_AnexoDibujos.Location = New System.Drawing.Point(12, 19)
        Me.Ck_AnexoDibujos.Name = "Ck_AnexoDibujos"
        Me.Ck_AnexoDibujos.Size = New System.Drawing.Size(116, 17)
        Me.Ck_AnexoDibujos.TabIndex = 248
        Me.Ck_AnexoDibujos.Text = "Dibujos/Diagramas"
        Me.Ck_AnexoDibujos.UseVisualStyleBackColor = True
        '
        'Tb_OtrosAnexos
        '
        Me.Tb_OtrosAnexos.Location = New System.Drawing.Point(65, 44)
        Me.Tb_OtrosAnexos.MaxLength = 30
        Me.Tb_OtrosAnexos.Name = "Tb_OtrosAnexos"
        Me.Tb_OtrosAnexos.Size = New System.Drawing.Size(252, 20)
        Me.Tb_OtrosAnexos.TabIndex = 256
        '
        'Lb_OtrosAnexos
        '
        Me.Lb_OtrosAnexos.AutoSize = True
        Me.Lb_OtrosAnexos.Location = New System.Drawing.Point(9, 47)
        Me.Lb_OtrosAnexos.Name = "Lb_OtrosAnexos"
        Me.Lb_OtrosAnexos.Size = New System.Drawing.Size(40, 13)
        Me.Lb_OtrosAnexos.TabIndex = 255
        Me.Lb_OtrosAnexos.Text = "¿Cual?"
        '
        'Gb_Concepto
        '
        Me.Gb_Concepto.Controls.Add(Me.Tb_ConceptoAsesorJuridico)
        Me.Gb_Concepto.Controls.Add(Me.Lb_FechaAsesor)
        Me.Gb_Concepto.Controls.Add(Me.DTP_FechaConceptoAsesor)
        Me.Gb_Concepto.Controls.Add(Me.Lb_NombreAsesor)
        Me.Gb_Concepto.Controls.Add(Me.Cu_AsociarPersonaBodegaAsesor)
        Me.Gb_Concepto.Controls.Add(Me.Cu_BuscarPersonaAsesorJuridico)
        Me.Gb_Concepto.Controls.Add(Me.Lb_FechaHSE)
        Me.Gb_Concepto.Controls.Add(Me.DTP_FechaConceptoHSE)
        Me.Gb_Concepto.Controls.Add(Me.Lb_AsesorJuridico)
        Me.Gb_Concepto.Controls.Add(Me.Lb_NombreHSE)
        Me.Gb_Concepto.Controls.Add(Me.Tb_ConceptoHSE)
        Me.Gb_Concepto.Controls.Add(Me.Label79)
        Me.Gb_Concepto.Controls.Add(Me.Cu_AsociarPersonaBodegaHSE)
        Me.Gb_Concepto.Controls.Add(Me.Cu_BuscarPersonaHSE)
        Me.Gb_Concepto.Location = New System.Drawing.Point(6, 219)
        Me.Gb_Concepto.Name = "Gb_Concepto"
        Me.Gb_Concepto.Size = New System.Drawing.Size(892, 200)
        Me.Gb_Concepto.TabIndex = 228
        Me.Gb_Concepto.TabStop = False
        Me.Gb_Concepto.Text = "Concepto y Recomendaciones "
        '
        'Tb_ConceptoAsesorJuridico
        '
        Me.Tb_ConceptoAsesorJuridico.Location = New System.Drawing.Point(12, 124)
        Me.Tb_ConceptoAsesorJuridico.MaxLength = 300
        Me.Tb_ConceptoAsesorJuridico.Multiline = True
        Me.Tb_ConceptoAsesorJuridico.Name = "Tb_ConceptoAsesorJuridico"
        Me.Tb_ConceptoAsesorJuridico.Size = New System.Drawing.Size(870, 37)
        Me.Tb_ConceptoAsesorJuridico.TabIndex = 237
        '
        'Lb_FechaAsesor
        '
        Me.Lb_FechaAsesor.AutoSize = True
        Me.Lb_FechaAsesor.Location = New System.Drawing.Point(407, 173)
        Me.Lb_FechaAsesor.Name = "Lb_FechaAsesor"
        Me.Lb_FechaAsesor.Size = New System.Drawing.Size(40, 13)
        Me.Lb_FechaAsesor.TabIndex = 245
        Me.Lb_FechaAsesor.Text = "Fecha:"
        '
        'DTP_FechaConceptoAsesor
        '
        Me.DTP_FechaConceptoAsesor.Checked = False
        Me.DTP_FechaConceptoAsesor.Location = New System.Drawing.Point(456, 169)
        Me.DTP_FechaConceptoAsesor.Name = "DTP_FechaConceptoAsesor"
        Me.DTP_FechaConceptoAsesor.ShowCheckBox = True
        Me.DTP_FechaConceptoAsesor.Size = New System.Drawing.Size(220, 20)
        Me.DTP_FechaConceptoAsesor.TabIndex = 246
        '
        'Lb_NombreAsesor
        '
        Me.Lb_NombreAsesor.AutoSize = True
        Me.Lb_NombreAsesor.Location = New System.Drawing.Point(12, 173)
        Me.Lb_NombreAsesor.Name = "Lb_NombreAsesor"
        Me.Lb_NombreAsesor.Size = New System.Drawing.Size(47, 13)
        Me.Lb_NombreAsesor.TabIndex = 238
        Me.Lb_NombreAsesor.Text = "Nombre:"
        '
        'Cu_AsociarPersonaBodegaAsesor
        '
        Me.Cu_AsociarPersonaBodegaAsesor.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodegaAsesor.CrearUsuario = False
        Me.Cu_AsociarPersonaBodegaAsesor.Location = New System.Drawing.Point(350, 169)
        Me.Cu_AsociarPersonaBodegaAsesor.Name = "Cu_AsociarPersonaBodegaAsesor"
        Me.Cu_AsociarPersonaBodegaAsesor.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodegaAsesor.TabIndex = 240
        Me.Cu_AsociarPersonaBodegaAsesor.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodegaAsesor.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaAsesorJuridico
        '
        Me.Cu_BuscarPersonaAsesorJuridico.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAsesorJuridico.Location = New System.Drawing.Point(63, 168)
        Me.Cu_BuscarPersonaAsesorJuridico.Name = "Cu_BuscarPersonaAsesorJuridico"
        Me.Cu_BuscarPersonaAsesorJuridico.Size = New System.Drawing.Size(292, 23)
        Me.Cu_BuscarPersonaAsesorJuridico.TabIndex = 239
        Me.Cu_BuscarPersonaAsesorJuridico.Tipo = "PABO"
        Me.Cu_BuscarPersonaAsesorJuridico.valorcajatexto = "IDENTIFICACION"
        '
        'Lb_FechaHSE
        '
        Me.Lb_FechaHSE.AutoSize = True
        Me.Lb_FechaHSE.Location = New System.Drawing.Point(409, 82)
        Me.Lb_FechaHSE.Name = "Lb_FechaHSE"
        Me.Lb_FechaHSE.Size = New System.Drawing.Size(40, 13)
        Me.Lb_FechaHSE.TabIndex = 234
        Me.Lb_FechaHSE.Text = "Fecha:"
        '
        'DTP_FechaConceptoHSE
        '
        Me.DTP_FechaConceptoHSE.Checked = False
        Me.DTP_FechaConceptoHSE.Location = New System.Drawing.Point(458, 78)
        Me.DTP_FechaConceptoHSE.Name = "DTP_FechaConceptoHSE"
        Me.DTP_FechaConceptoHSE.ShowCheckBox = True
        Me.DTP_FechaConceptoHSE.Size = New System.Drawing.Size(218, 20)
        Me.DTP_FechaConceptoHSE.TabIndex = 235
        '
        'Lb_AsesorJuridico
        '
        Me.Lb_AsesorJuridico.AutoSize = True
        Me.Lb_AsesorJuridico.Location = New System.Drawing.Point(12, 108)
        Me.Lb_AsesorJuridico.Name = "Lb_AsesorJuridico"
        Me.Lb_AsesorJuridico.Size = New System.Drawing.Size(80, 13)
        Me.Lb_AsesorJuridico.TabIndex = 236
        Me.Lb_AsesorJuridico.Text = "Asesor Jurídico"
        '
        'Lb_NombreHSE
        '
        Me.Lb_NombreHSE.AutoSize = True
        Me.Lb_NombreHSE.Location = New System.Drawing.Point(10, 82)
        Me.Lb_NombreHSE.Name = "Lb_NombreHSE"
        Me.Lb_NombreHSE.Size = New System.Drawing.Size(47, 13)
        Me.Lb_NombreHSE.TabIndex = 231
        Me.Lb_NombreHSE.Text = "Nombre:"
        '
        'Tb_ConceptoHSE
        '
        Me.Tb_ConceptoHSE.Location = New System.Drawing.Point(12, 35)
        Me.Tb_ConceptoHSE.MaxLength = 300
        Me.Tb_ConceptoHSE.Multiline = True
        Me.Tb_ConceptoHSE.Name = "Tb_ConceptoHSE"
        Me.Tb_ConceptoHSE.Size = New System.Drawing.Size(874, 37)
        Me.Tb_ConceptoHSE.TabIndex = 230
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(9, 18)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(99, 13)
        Me.Label79.TabIndex = 229
        Me.Label79.Text = "Departamento HSE"
        '
        'Cu_AsociarPersonaBodegaHSE
        '
        Me.Cu_AsociarPersonaBodegaHSE.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodegaHSE.CrearUsuario = False
        Me.Cu_AsociarPersonaBodegaHSE.Location = New System.Drawing.Point(349, 78)
        Me.Cu_AsociarPersonaBodegaHSE.Name = "Cu_AsociarPersonaBodegaHSE"
        Me.Cu_AsociarPersonaBodegaHSE.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodegaHSE.TabIndex = 233
        Me.Cu_AsociarPersonaBodegaHSE.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodegaHSE.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaHSE
        '
        Me.Cu_BuscarPersonaHSE.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaHSE.Location = New System.Drawing.Point(63, 77)
        Me.Cu_BuscarPersonaHSE.Name = "Cu_BuscarPersonaHSE"
        Me.Cu_BuscarPersonaHSE.Size = New System.Drawing.Size(292, 23)
        Me.Cu_BuscarPersonaHSE.TabIndex = 232
        Me.Cu_BuscarPersonaHSE.Tipo = "PABO"
        Me.Cu_BuscarPersonaHSE.valorcajatexto = "IDENTIFICACION"
        '
        'Dgv_Investigadores
        '
        Me.Dgv_Investigadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Investigadores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVT_CedulaInvestigador, Me.DGVT_NombreInvestigador, Me.DGVC_RolInvestigador})
        Me.Dgv_Investigadores.Location = New System.Drawing.Point(3, 28)
        Me.Dgv_Investigadores.Name = "Dgv_Investigadores"
        Me.Dgv_Investigadores.Size = New System.Drawing.Size(900, 185)
        Me.Dgv_Investigadores.TabIndex = 227
        '
        'DGVT_CedulaInvestigador
        '
        Me.DGVT_CedulaInvestigador.DataPropertyName = "Cedula"
        Me.DGVT_CedulaInvestigador.HeaderText = "Cedula"
        Me.DGVT_CedulaInvestigador.Name = "DGVT_CedulaInvestigador"
        Me.DGVT_CedulaInvestigador.Width = 105
        '
        'DGVT_NombreInvestigador
        '
        Me.DGVT_NombreInvestigador.DataPropertyName = "Nombre"
        Me.DGVT_NombreInvestigador.HeaderText = "Nombre"
        Me.DGVT_NombreInvestigador.Name = "DGVT_NombreInvestigador"
        Me.DGVT_NombreInvestigador.Width = 350
        '
        'DGVC_RolInvestigador
        '
        Me.DGVC_RolInvestigador.DataPropertyName = "Rol"
        Me.DGVC_RolInvestigador.HeaderText = "Rol"
        Me.DGVC_RolInvestigador.Name = "DGVC_RolInvestigador"
        Me.DGVC_RolInvestigador.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_RolInvestigador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVC_RolInvestigador.Width = 300
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel7.Controls.Add(Me.Bt_AgregarInvestigacion)
        Me.Panel7.Controls.Add(Me.Label78)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(3, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(900, 25)
        Me.Panel7.TabIndex = 4
        '
        'Bt_AgregarInvestigacion
        '
        Me.Bt_AgregarInvestigacion.Location = New System.Drawing.Point(103, 2)
        Me.Bt_AgregarInvestigacion.Name = "Bt_AgregarInvestigacion"
        Me.Bt_AgregarInvestigacion.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarInvestigacion.TabIndex = 226
        Me.Bt_AgregarInvestigacion.Text = "Agregar"
        Me.Bt_AgregarInvestigacion.UseVisualStyleBackColor = True
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.ForeColor = System.Drawing.Color.Blue
        Me.Label78.Location = New System.Drawing.Point(3, 4)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(94, 16)
        Me.Label78.TabIndex = 0
        Me.Label78.Text = "Investigador"
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cu_AsociarPersonaBodega10
        '
        Me.Cu_AsociarPersonaBodega10.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodega10.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega10.Location = New System.Drawing.Point(354, 507)
        Me.Cu_AsociarPersonaBodega10.Name = "Cu_AsociarPersonaBodega10"
        Me.Cu_AsociarPersonaBodega10.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega10.TabIndex = 259
        Me.Cu_AsociarPersonaBodega10.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodega10.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaAprobo
        '
        Me.Cu_BuscarPersonaAprobo.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAprobo.Location = New System.Drawing.Point(69, 506)
        Me.Cu_BuscarPersonaAprobo.Name = "Cu_BuscarPersonaAprobo"
        Me.Cu_BuscarPersonaAprobo.Size = New System.Drawing.Size(290, 23)
        Me.Cu_BuscarPersonaAprobo.TabIndex = 258
        Me.Cu_BuscarPersonaAprobo.Tipo = "PABO"
        Me.Cu_BuscarPersonaAprobo.valorcajatexto = "IDENTIFICACION"
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(826, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 3
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(745, 4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 2
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.Color.Silver
        Me.Pn_Botones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Pn_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 582)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(914, 29)
        Me.Pn_Botones.TabIndex = 4
        '
        'Cms_EliminarFila
        '
        Me.Cms_EliminarFila.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarFilaToolStripMenuItem})
        Me.Cms_EliminarFila.Name = "Cms_EliminarFila"
        Me.Cms_EliminarFila.Size = New System.Drawing.Size(139, 26)
        '
        'EliminarFilaToolStripMenuItem
        '
        Me.EliminarFilaToolStripMenuItem.Name = "EliminarFilaToolStripMenuItem"
        Me.EliminarFilaToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.EliminarFilaToolStripMenuItem.Text = "Eliminar Fila"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 550
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 550
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 550
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Cedula"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 105
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 300
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Accion"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 300
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Cedula"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 105
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 350
        '
        'Fr_CrearInvestigacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 611)
        Me.Controls.Add(Me.Pn_Botones)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximumSize = New System.Drawing.Size(930, 650)
        Me.MinimumSize = New System.Drawing.Size(930, 650)
        Me.Name = "Fr_CrearInvestigacion"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Incidente"
        Me.TabControl1.ResumeLayout(False)
        Me.Tp_InformacionGeneral.ResumeLayout(False)
        Me.Tp_InformacionGeneral.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.Dgv_LineaTiempo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Tp_InformacionAfectado.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Num_ExperienciaMeses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_DiasSitio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_ExperienciaAños, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_Genero.ResumeLayout(False)
        Me.GroupBox_Genero.PerformLayout()
        Me.Tp_AfectacionAmbDaños.ResumeLayout(False)
        Me.Tp_AfectacionAmbDaños.PerformLayout()
        Me.Tp_ValoracionIncidente.ResumeLayout(False)
        Me.Gb_Costos.ResumeLayout(False)
        Me.Gb_Costos.PerformLayout()
        Me.Gb_PerdidaReal.ResumeLayout(False)
        Me.Gb_PerdidaReal.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Tp_Testigos.ResumeLayout(False)
        Me.Tp_Testigos.PerformLayout()
        Me.Gb_Preguntas.ResumeLayout(False)
        Me.Gb_Pregunta2.ResumeLayout(False)
        Me.Gb_Pregunta2.PerformLayout()
        Me.Gb_Pregunta1.ResumeLayout(False)
        Me.Gb_Pregunta1.PerformLayout()
        CType(Me.Dgv_Testigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_tituloConceptos.ResumeLayout(False)
        Me.Pn_tituloConceptos.PerformLayout()
        Me.Tp_AnalisisCausas.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.Dgv_CausasInmediatasCondiciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_CausasBasicasTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.Dgv_CausasBasicasPersonales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_CausasInmediatasActos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Tp_PlanAccion.ResumeLayout(False)
        Me.Tp_PlanAccion.PerformLayout()
        CType(Me.Dgv_Evidencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Evidencias.ResumeLayout(False)
        Me.Pn_Evidencias.PerformLayout()
        CType(Me.Dgv_AccionesATomar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Acciones.ResumeLayout(False)
        Me.Pn_Acciones.PerformLayout()
        Me.Tp_Investigadores.ResumeLayout(False)
        Me.Tp_Investigadores.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Gb_Concepto.ResumeLayout(False)
        Me.Gb_Concepto.PerformLayout()
        CType(Me.Dgv_Investigadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Pn_Botones.ResumeLayout(False)
        Me.Cms_EliminarFila.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Tp_InformacionGeneral As System.Windows.Forms.TabPage
    Friend WithEvents Tp_InformacionAfectado As System.Windows.Forms.TabPage
    Friend WithEvents Tb_SitioIncidente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Tb_Empleador As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Empleador As System.Windows.Forms.Label
    Friend WithEvents Ck_Empleador As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoConsecuencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoIncidente As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cb_Proyecto As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaIncidente As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DTP_HoraIncidente As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaReporta As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Cb_CargoReporta As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaReporte As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Cu_AsociarPersonaAfectada As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaAfectada As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoVinculacion As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_CargoPersonaAccidente As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Tb_OtroAgenteAccidente As System.Windows.Forms.TextBox
    Friend WithEvents Lb_AgenteAccidente As System.Windows.Forms.Label
    Friend WithEvents Cb_AgenteAccidente As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Cb_ParteAfectada As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Tb_OtroTipoLesion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TipoLesion As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoLesion As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Tb_OtroMecanismoAccidente As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Mecanismo As System.Windows.Forms.Label
    Friend WithEvents Cb_MecanismoAccidente As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Traslado As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Trasladado As System.Windows.Forms.Label
    Friend WithEvents Cb_AtencionInmediata As System.Windows.Forms.ComboBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Tp_Testigos As System.Windows.Forms.TabPage
    Friend WithEvents Pn_tituloConceptos As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarTestigo As System.Windows.Forms.Button
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Dgv_Testigos As System.Windows.Forms.DataGridView
    Friend WithEvents Cms_EliminarFila As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminarFilaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DTP_HorasLaboradas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_ZonaUrbana As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_ZonaRural As System.Windows.Forms.RadioButton
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Rb_LugarDentroEmpresa As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_LugarFueraEmpresa As System.Windows.Forms.RadioButton
    Friend WithEvents Cu_CiudadIncidente As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Cb_ActividadPrincipal As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Tb_OtraParteAfectada As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ParteAfectada As System.Windows.Forms.Label
    Friend WithEvents DTP_InicioContrato As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_FechaNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_Genero As System.Windows.Forms.GroupBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Rb_Femenino As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Masculino As System.Windows.Forms.RadioButton
    Friend WithEvents Tp_ValoracionIncidente As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_PeorConsecuencia As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Cb_Recurrencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Cb_Severidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Tb_TrabajoHabitual As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TrabajoHabitual As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Cb_JornadaIncidente As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Cb_JornadaHabitual As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Cb_Area As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cb_CondicionClima As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_CondicionClima As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaRegresoTrabajo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Num_DiasSitio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Num_ExperienciaAños As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Cb_CargoMedico As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaConceptoMedico As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaBodega5 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Tb_ComentarioMedico As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents DTP_HoraConceptoMedico As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaMedico As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Tp_AfectacionAmbDaños As System.Windows.Forms.TabPage
    Friend WithEvents Lb_AfectacionDaño As System.Windows.Forms.Label
    Friend WithEvents Lb_NombreInvolucrado As System.Windows.Forms.Label
    Friend WithEvents Lb_CantidadSustancia As System.Windows.Forms.Label
    Friend WithEvents Lb_CargoAfectacionDaños As System.Windows.Forms.Label
    Friend WithEvents Lb_AtencionPrestadaAfectacionDaños As System.Windows.Forms.Label
    Friend WithEvents Lb_UnidadSustancia As System.Windows.Forms.Label
    Friend WithEvents Cb_CargoAfectacionDaños As System.Windows.Forms.ComboBox
    Friend WithEvents Cu_AsociarPersonaBodegaInvolucradaAfectacionDaños As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaInvolucradaAfectacionDaños As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Tb_CantidadSustancia As System.Windows.Forms.TextBox
    Friend WithEvents Tb_SustanciaProceso As System.Windows.Forms.TextBox
    Friend WithEvents Tb_AtencionPrestadaAfectacionDaños As System.Windows.Forms.TextBox
    Friend WithEvents Tb_AfectacionDaño As System.Windows.Forms.TextBox
    Friend WithEvents Lb_SustanciaProceso As System.Windows.Forms.Label
    Friend WithEvents Gb_PerdidaReal As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_RecurrenciaReal As System.Windows.Forms.ComboBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Cb_SeveridadReal As System.Windows.Forms.ComboBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Gb_Costos As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Especificar2 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Especificar2 As System.Windows.Forms.Label
    Friend WithEvents Tb_Especificar3 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Especificar3 As System.Windows.Forms.Label
    Friend WithEvents Tb_Especificar4 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Especificar4 As System.Windows.Forms.Label
    Friend WithEvents Tb_Especificar5 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Especificar5 As System.Windows.Forms.Label
    Friend WithEvents Tb_Especificar1 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Especificar1 As System.Windows.Forms.Label
    Friend WithEvents Tb_Costo2 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Costo2 As System.Windows.Forms.Label
    Friend WithEvents Tb_Costo3 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Costo3 As System.Windows.Forms.Label
    Friend WithEvents Tb_Costo4 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Costo4 As System.Windows.Forms.Label
    Friend WithEvents Tb_Costo5 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Costo5 As System.Windows.Forms.Label
    Friend WithEvents Tb_Costo1 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Costo1 As System.Windows.Forms.Label
    Friend WithEvents Tp_AnalisisCausas As System.Windows.Forms.TabPage
    Friend WithEvents Dgv_CausasBasicasPersonales As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv_CausasInmediatasActos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarCausaInmediataActos As System.Windows.Forms.Button
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarCausaBasicaPersonal As System.Windows.Forms.Button
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Tp_PlanAccion As System.Windows.Forms.TabPage
    Friend WithEvents Ck_MinisterioTrabajo As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_Organismo As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_CAR As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_EPS As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_ARL As System.Windows.Forms.CheckBox
    Friend WithEvents Lb_EntidadNotificada As System.Windows.Forms.Label
    Friend WithEvents Dgv_AccionesATomar As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Acciones As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarAccion As System.Windows.Forms.Button
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Tp_Investigadores As System.Windows.Forms.TabPage
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarInvestigacion As System.Windows.Forms.Button
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Dgv_Investigadores As System.Windows.Forms.DataGridView
    Friend WithEvents Cb_UnidadSustancia As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dgv_LineaTiempo As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarLineaTiempo As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Gb_Preguntas As System.Windows.Forms.GroupBox
    Friend WithEvents Gb_Pregunta2 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Pregunta2 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Pregunta2 As System.Windows.Forms.Label
    Friend WithEvents Rb_Pregunta2No As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Pregunta2Si As System.Windows.Forms.RadioButton
    Friend WithEvents Gb_Pregunta1 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Pregunta1 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Pregunta1 As System.Windows.Forms.Label
    Friend WithEvents Rb_Pregunta1No As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Pregunta1Si As System.Windows.Forms.RadioButton
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Dgv_Evidencias As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Evidencias As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarEvidencia As System.Windows.Forms.Button
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Cb_CargoAprobo As System.Windows.Forms.ComboBox
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaAprobacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaBodega10 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaAprobo As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Ck_OtrosAnexos As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_AnexoAlerta As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_AnexoReporte24H As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_AnexoDocumentos As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_AnexoFotos As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_AnexoDibujos As System.Windows.Forms.CheckBox
    Friend WithEvents Tb_OtrosAnexos As System.Windows.Forms.TextBox
    Friend WithEvents Lb_OtrosAnexos As System.Windows.Forms.Label
    Friend WithEvents Gb_Concepto As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_ConceptoAsesorJuridico As System.Windows.Forms.TextBox
    Friend WithEvents Lb_FechaAsesor As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaConceptoAsesor As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_NombreAsesor As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaBodegaAsesor As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaAsesorJuridico As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_FechaHSE As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaConceptoHSE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_AsesorJuridico As System.Windows.Forms.Label
    Friend WithEvents Lb_NombreHSE As System.Windows.Forms.Label
    Friend WithEvents Tb_ConceptoHSE As System.Windows.Forms.TextBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaBodegaHSE As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaHSE As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Num_ExperienciaMeses As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Tb_OtraEntidad As System.Windows.Forms.TextBox
    Friend WithEvents Lb_OtraEntidad As System.Windows.Forms.Label
    Friend WithEvents Ck_OtraEntidad As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_Cliente As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_AutoridadAmbiental As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_TrabajoHabitualNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_TrabajoHabitualSi As System.Windows.Forms.RadioButton
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarCausaBasicaTrabajo As System.Windows.Forms.Button
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Dgv_CausasInmediatasCondiciones As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv_CausasBasicasTrabajo As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarCausaInmediataCondiciones As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents DGVT_CedulaInvestigador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_NombreInvestigador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_RolInvestigador As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVT_CedulaTestigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_NombreTestigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVCB_CargoTestigo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVTB_DescripcionTestigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_TipoCausaInmediataCondiciones As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVT_DescripcionCausaInmediataCondiciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_TipoCausaBasicaTrabajo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVT_DescripcionCausaBasicaTrabajo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_TipoCausaBasicaPersonales As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Dgv_DescripcionCausaBasicaPersonales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_TipoCausaInmediataActos As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVT_DescripcionCausaInmediataActos As System.Windows.Forms.DataGridViewTextBoxColumn
    'Friend WithEvents Bt_VerMatriz As System.Windows.Forms.Button
    'Friend WithEvents Bt_VerMatrizReal As System.Windows.Forms.Button
    Friend WithEvents Tb_CargoActual As System.Windows.Forms.TextBox
    Friend WithEvents Tb_CategoriaResultanteReal As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CategoriaResultanteReal As System.Windows.Forms.Label
    Friend WithEvents Tb_CategoriaResultante As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CategoriaResultante As System.Windows.Forms.Label
    Friend WithEvents DGVC_TipoEvidencia As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVT_DescripcionEvidencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tb_ExperienciaOcupacional As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents DGVT_Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tb_Costo7 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Costo7 As System.Windows.Forms.Label
    Friend WithEvents Tb_Especificar6 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Especificar6 As System.Windows.Forms.Label
    Friend WithEvents Tb_Costo6 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Costo6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_EstuvoMal As System.Windows.Forms.TextBox
    Friend WithEvents Cu_AsociarPersonaMedico As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cb_Contrato As System.Windows.Forms.ComboBox
    Friend WithEvents DGVT_Accion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVCB_CargoAcciones As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVC_Prioridad As System.Windows.Forms.DataGridViewComboBoxColumn

End Class
