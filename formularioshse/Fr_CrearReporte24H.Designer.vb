<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_CrearReporte24H
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
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Cb_Contrato = New System.Windows.Forms.ComboBox()
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
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Lb_DirectorResidente = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaBodegaMedicoEnfermero = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaBodegaCoordinadorHSE = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaBodegaResponsableActividad = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaBodegaDirectorObra = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaMedicoEnfermero = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaCoordinadorHSE = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaResponsableActividad = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaDirectorObra = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Ck_OtrosAnexos = New System.Windows.Forms.CheckBox()
        Me.Ck_AnexoInformesMedicos = New System.Windows.Forms.CheckBox()
        Me.Ck_AnexoFotos = New System.Windows.Forms.CheckBox()
        Me.Ck_AnexoDibujos = New System.Windows.Forms.CheckBox()
        Me.Tb_OtrosAnexos = New System.Windows.Forms.TextBox()
        Me.Lb_OtrosAnexos = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Tb_CategoriaResultante = New System.Windows.Forms.TextBox()
        Me.Lb_CategoriaResultante = New System.Windows.Forms.Label()
        Me.Tb_EvitadoAccidente = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Cb_Recurrencia = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Cb_Severidad = New System.Windows.Forms.ComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Tb_AccionInmediata3 = New System.Windows.Forms.TextBox()
        Me.Lb_AccionInmediata3 = New System.Windows.Forms.Label()
        Me.Tb_AccionInmediata2 = New System.Windows.Forms.TextBox()
        Me.Lb_AccionInmediata2 = New System.Windows.Forms.Label()
        Me.Tb_AccionInmediata1 = New System.Windows.Forms.TextBox()
        Me.Lb_AccionInmediata1 = New System.Windows.Forms.Label()
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
        Me.Tx_Empleador = New System.Windows.Forms.TextBox()
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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Gb_TipoAccidente = New System.Windows.Forms.GroupBox()
        Me.Lb_TipoAccidente = New System.Windows.Forms.Label()
        Me.Rb_PropioTrabajo = New System.Windows.Forms.RadioButton()
        Me.Rb_Recreativo = New System.Windows.Forms.RadioButton()
        Me.Rb_Deportivo = New System.Windows.Forms.RadioButton()
        Me.Rb_Transito = New System.Windows.Forms.RadioButton()
        Me.Rb_Violencia = New System.Windows.Forms.RadioButton()
        Me.Gb_CausoMuerte = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Rb_MuerteSi = New System.Windows.Forms.RadioButton()
        Me.Rb_MuerteNo = New System.Windows.Forms.RadioButton()
        Me.Gb_Testigos = New System.Windows.Forms.GroupBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Rb_TestigosSi = New System.Windows.Forms.RadioButton()
        Me.Rb_TestigosNo = New System.Windows.Forms.RadioButton()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Rb_TrabajoHabitualNo = New System.Windows.Forms.RadioButton()
        Me.Rb_TrabajoHabitualSi = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Tb_OtraParteAfectada = New System.Windows.Forms.TextBox()
        Me.Lb_ParteAfectada = New System.Windows.Forms.Label()
        Me.Tb_OtroTipoLesion = New System.Windows.Forms.TextBox()
        Me.Tb_OtroMecanismoAccidente = New System.Windows.Forms.TextBox()
        Me.Lb_TipoLesion = New System.Windows.Forms.Label()
        Me.Cb_TipoLesion = New System.Windows.Forms.ComboBox()
        Me.Lb_Mecanismo = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Tb_OtroSitioIncidente = New System.Windows.Forms.TextBox()
        Me.Cb_MecanismoAccidente = New System.Windows.Forms.ComboBox()
        Me.Lb_SitioIncidente = New System.Windows.Forms.Label()
        Me.Tx_TrabajoHabitual = New System.Windows.Forms.TextBox()
        Me.Cb_SitioIncidente = New System.Windows.Forms.ComboBox()
        Me.Lb_TrabajoHabitual = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Cb_JornadaIncidente = New System.Windows.Forms.ComboBox()
        Me.Tb_OtroAgenteAccidente = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Tb_DiagnosticoLesion = New System.Windows.Forms.TextBox()
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
        Me.Cu_CiudadPersonaAfectada = New FormulariosClasesBase.Cu_Ciudad()
        Me.Lb_CiudadResidencia = New System.Windows.Forms.Label()
        Me.DTP_FechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.GroupBox_Genero = New System.Windows.Forms.GroupBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Rb_Femenino = New System.Windows.Forms.RadioButton()
        Me.Rb_Masculino = New System.Windows.Forms.RadioButton()
        Me.DTP_InicioContrato = New System.Windows.Forms.DateTimePicker()
        Me.Cb_AFP = New System.Windows.Forms.ComboBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Cb_EPS = New System.Windows.Forms.ComboBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Cb_JornadaHabitual = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Tb_Salario = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Cb_OcupacionHabitual = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Cb_CargoPersonaAccidente = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Tb_CorreoElectronico = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Tb_TelefonoMovil = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Tb_Telefono = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Tb_Direccion = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaAfectada = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaAfectada = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cb_TipoVinculacion = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Dgv_Testigos = New System.Windows.Forms.DataGridView()
        Me.Cedula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVCB_Cargo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Pn_tituloConceptos = New System.Windows.Forms.Panel()
        Me.Bt_Agregar = New System.Windows.Forms.Button()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Cms_EliminarFila = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarFilaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.Gb_TipoAccidente.SuspendLayout()
        Me.Gb_CausoMuerte.SuspendLayout()
        Me.Gb_Testigos.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox_Genero.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.Dgv_Testigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_tituloConceptos.SuspendLayout()
        Me.Pn_Botones.SuspendLayout()
        Me.Cms_EliminarFila.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(-1, 2)
        Me.TabControl1.MaximumSize = New System.Drawing.Size(914, 551)
        Me.TabControl1.MinimumSize = New System.Drawing.Size(914, 551)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(914, 551)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Cb_Contrato)
        Me.TabPage1.Controls.Add(Me.Cb_ActividadPrincipal)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Cu_CiudadIncidente)
        Me.TabPage1.Controls.Add(Me.GroupBox8)
        Me.TabPage1.Controls.Add(Me.Label30)
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.DTP_HorasLaboradas)
        Me.TabPage1.Controls.Add(Me.Label47)
        Me.TabPage1.Controls.Add(Me.Label58)
        Me.TabPage1.Controls.Add(Me.Label57)
        Me.TabPage1.Controls.Add(Me.Label56)
        Me.TabPage1.Controls.Add(Me.Lb_DirectorResidente)
        Me.TabPage1.Controls.Add(Me.Cu_AsociarPersonaBodegaMedicoEnfermero)
        Me.TabPage1.Controls.Add(Me.Cu_AsociarPersonaBodegaCoordinadorHSE)
        Me.TabPage1.Controls.Add(Me.Cu_AsociarPersonaBodegaResponsableActividad)
        Me.TabPage1.Controls.Add(Me.Cu_AsociarPersonaBodegaDirectorObra)
        Me.TabPage1.Controls.Add(Me.Cu_BuscarPersonaMedicoEnfermero)
        Me.TabPage1.Controls.Add(Me.Cu_BuscarPersonaCoordinadorHSE)
        Me.TabPage1.Controls.Add(Me.Cu_BuscarPersonaResponsableActividad)
        Me.TabPage1.Controls.Add(Me.Cu_BuscarPersonaDirectorObra)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Cb_CargoReporta)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Cu_AsociarPersonaReporte)
        Me.TabPage1.Controls.Add(Me.Cu_BuscarPersonaReporta)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.DTP_HoraIncidente)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.DTP_FechaIncidente)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Tb_SitioIncidente)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Tx_Empleador)
        Me.TabPage1.Controls.Add(Me.Lb_Empleador)
        Me.TabPage1.Controls.Add(Me.Ck_Empleador)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Cb_Area)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Cb_TipoConsecuencia)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Cb_TipoIncidente)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Cb_Proyecto)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(906, 525)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Información General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Cb_Contrato
        '
        Me.Cb_Contrato.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Contrato.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Contrato.FormattingEnabled = True
        Me.Cb_Contrato.Location = New System.Drawing.Point(91, 9)
        Me.Cb_Contrato.Name = "Cb_Contrato"
        Me.Cb_Contrato.Size = New System.Drawing.Size(104, 21)
        Me.Cb_Contrato.TabIndex = 1
        '
        'Cb_ActividadPrincipal
        '
        Me.Cb_ActividadPrincipal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_ActividadPrincipal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_ActividadPrincipal.FormattingEnabled = True
        Me.Cb_ActividadPrincipal.Location = New System.Drawing.Point(743, 38)
        Me.Cb_ActividadPrincipal.Name = "Cb_ActividadPrincipal"
        Me.Cb_ActividadPrincipal.Size = New System.Drawing.Size(152, 21)
        Me.Cb_ActividadPrincipal.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(642, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Actividad Principal:"
        '
        'Cu_CiudadIncidente
        '
        Me.Cu_CiudadIncidente.Location = New System.Drawing.Point(616, 67)
        Me.Cu_CiudadIncidente.Name = "Cu_CiudadIncidente"
        Me.Cu_CiudadIncidente.Size = New System.Drawing.Size(283, 23)
        Me.Cu_CiudadIncidente.TabIndex = 21
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label32)
        Me.GroupBox8.Controls.Add(Me.Rb_LugarDentroEmpresa)
        Me.GroupBox8.Controls.Add(Me.Rb_LugarFueraEmpresa)
        Me.GroupBox8.Location = New System.Drawing.Point(9, 92)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(388, 35)
        Me.GroupBox8.TabIndex = 22
        Me.GroupBox8.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(6, 14)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(118, 13)
        Me.Label32.TabIndex = 23
        Me.Label32.Text = "Lugar Ocurrio Incidente"
        '
        'Rb_LugarDentroEmpresa
        '
        Me.Rb_LugarDentroEmpresa.AutoSize = True
        Me.Rb_LugarDentroEmpresa.Location = New System.Drawing.Point(129, 11)
        Me.Rb_LugarDentroEmpresa.Name = "Rb_LugarDentroEmpresa"
        Me.Rb_LugarDentroEmpresa.Size = New System.Drawing.Size(126, 17)
        Me.Rb_LugarDentroEmpresa.TabIndex = 24
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
        Me.Rb_LugarFueraEmpresa.TabIndex = 25
        Me.Rb_LugarFueraEmpresa.TabStop = True
        Me.Rb_LugarFueraEmpresa.Text = "Fuera de la empresa"
        Me.Rb_LugarFueraEmpresa.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(561, 72)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 13)
        Me.Label30.TabIndex = 111
        Me.Label30.Text = "Municipio:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Rb_ZonaUrbana)
        Me.GroupBox7.Controls.Add(Me.Rb_ZonaRural)
        Me.GroupBox7.Controls.Add(Me.Label31)
        Me.GroupBox7.Location = New System.Drawing.Point(315, 58)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(238, 35)
        Me.GroupBox7.TabIndex = 18
        Me.GroupBox7.TabStop = False
        '
        'Rb_ZonaUrbana
        '
        Me.Rb_ZonaUrbana.AutoSize = True
        Me.Rb_ZonaUrbana.Location = New System.Drawing.Point(172, 11)
        Me.Rb_ZonaUrbana.Name = "Rb_ZonaUrbana"
        Me.Rb_ZonaUrbana.Size = New System.Drawing.Size(60, 17)
        Me.Rb_ZonaUrbana.TabIndex = 20
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
        Me.Rb_ZonaRural.TabIndex = 19
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
        Me.Label31.TabIndex = 64
        Me.Label31.Text = "Zona Ocurrio Incidente"
        '
        'DTP_HorasLaboradas
        '
        Me.DTP_HorasLaboradas.Checked = False
        Me.DTP_HorasLaboradas.CustomFormat = "HH:mm"
        Me.DTP_HorasLaboradas.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_HorasLaboradas.Location = New System.Drawing.Point(331, 139)
        Me.DTP_HorasLaboradas.Name = "DTP_HorasLaboradas"
        Me.DTP_HorasLaboradas.ShowCheckBox = True
        Me.DTP_HorasLaboradas.ShowUpDown = True
        Me.DTP_HorasLaboradas.Size = New System.Drawing.Size(93, 20)
        Me.DTP_HorasLaboradas.TabIndex = 31
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(216, 143)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(112, 13)
        Me.Label47.TabIndex = 30
        Me.Label47.Text = "Horas Laboradas Día:"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(456, 494)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(98, 13)
        Me.Label58.TabIndex = 67
        Me.Label58.Text = "Medico/Enfermero:"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(462, 463)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(92, 13)
        Me.Label57.TabIndex = 61
        Me.Label57.Text = "Coordinador HSE:"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(17, 494)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(85, 13)
        Me.Label56.TabIndex = 64
        Me.Label56.Text = "Resp. Actividad:"
        '
        'Lb_DirectorResidente
        '
        Me.Lb_DirectorResidente.AutoSize = True
        Me.Lb_DirectorResidente.Location = New System.Drawing.Point(14, 463)
        Me.Lb_DirectorResidente.Name = "Lb_DirectorResidente"
        Me.Lb_DirectorResidente.Size = New System.Drawing.Size(88, 13)
        Me.Lb_DirectorResidente.TabIndex = 58
        Me.Lb_DirectorResidente.Text = "Director de Obra:"
        '
        'Cu_AsociarPersonaBodegaMedicoEnfermero
        '
        Me.Cu_AsociarPersonaBodegaMedicoEnfermero.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodegaMedicoEnfermero.CrearUsuario = False
        Me.Cu_AsociarPersonaBodegaMedicoEnfermero.Location = New System.Drawing.Point(871, 491)
        Me.Cu_AsociarPersonaBodegaMedicoEnfermero.Name = "Cu_AsociarPersonaBodegaMedicoEnfermero"
        Me.Cu_AsociarPersonaBodegaMedicoEnfermero.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodegaMedicoEnfermero.TabIndex = 69
        Me.Cu_AsociarPersonaBodegaMedicoEnfermero.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodegaMedicoEnfermero.TipoBúsqueda = "P"
        '
        'Cu_AsociarPersonaBodegaCoordinadorHSE
        '
        Me.Cu_AsociarPersonaBodegaCoordinadorHSE.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodegaCoordinadorHSE.CrearUsuario = False
        Me.Cu_AsociarPersonaBodegaCoordinadorHSE.Location = New System.Drawing.Point(871, 460)
        Me.Cu_AsociarPersonaBodegaCoordinadorHSE.Name = "Cu_AsociarPersonaBodegaCoordinadorHSE"
        Me.Cu_AsociarPersonaBodegaCoordinadorHSE.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodegaCoordinadorHSE.TabIndex = 63
        Me.Cu_AsociarPersonaBodegaCoordinadorHSE.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodegaCoordinadorHSE.TipoBúsqueda = "P"
        '
        'Cu_AsociarPersonaBodegaResponsableActividad
        '
        Me.Cu_AsociarPersonaBodegaResponsableActividad.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodegaResponsableActividad.CrearUsuario = False
        Me.Cu_AsociarPersonaBodegaResponsableActividad.Location = New System.Drawing.Point(416, 491)
        Me.Cu_AsociarPersonaBodegaResponsableActividad.Name = "Cu_AsociarPersonaBodegaResponsableActividad"
        Me.Cu_AsociarPersonaBodegaResponsableActividad.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodegaResponsableActividad.TabIndex = 66
        Me.Cu_AsociarPersonaBodegaResponsableActividad.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodegaResponsableActividad.TipoBúsqueda = "P"
        '
        'Cu_AsociarPersonaBodegaDirectorObra
        '
        Me.Cu_AsociarPersonaBodegaDirectorObra.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodegaDirectorObra.CrearUsuario = False
        Me.Cu_AsociarPersonaBodegaDirectorObra.Location = New System.Drawing.Point(416, 460)
        Me.Cu_AsociarPersonaBodegaDirectorObra.Name = "Cu_AsociarPersonaBodegaDirectorObra"
        Me.Cu_AsociarPersonaBodegaDirectorObra.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodegaDirectorObra.TabIndex = 60
        Me.Cu_AsociarPersonaBodegaDirectorObra.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodegaDirectorObra.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaMedicoEnfermero
        '
        Me.Cu_BuscarPersonaMedicoEnfermero.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaMedicoEnfermero.Location = New System.Drawing.Point(555, 490)
        Me.Cu_BuscarPersonaMedicoEnfermero.Name = "Cu_BuscarPersonaMedicoEnfermero"
        Me.Cu_BuscarPersonaMedicoEnfermero.Size = New System.Drawing.Size(320, 23)
        Me.Cu_BuscarPersonaMedicoEnfermero.TabIndex = 68
        Me.Cu_BuscarPersonaMedicoEnfermero.Tipo = "PABO"
        Me.Cu_BuscarPersonaMedicoEnfermero.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaCoordinadorHSE
        '
        Me.Cu_BuscarPersonaCoordinadorHSE.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaCoordinadorHSE.Location = New System.Drawing.Point(555, 459)
        Me.Cu_BuscarPersonaCoordinadorHSE.Name = "Cu_BuscarPersonaCoordinadorHSE"
        Me.Cu_BuscarPersonaCoordinadorHSE.Size = New System.Drawing.Size(320, 23)
        Me.Cu_BuscarPersonaCoordinadorHSE.TabIndex = 62
        Me.Cu_BuscarPersonaCoordinadorHSE.Tipo = "PABO"
        Me.Cu_BuscarPersonaCoordinadorHSE.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaResponsableActividad
        '
        Me.Cu_BuscarPersonaResponsableActividad.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaResponsableActividad.Location = New System.Drawing.Point(102, 490)
        Me.Cu_BuscarPersonaResponsableActividad.Name = "Cu_BuscarPersonaResponsableActividad"
        Me.Cu_BuscarPersonaResponsableActividad.Size = New System.Drawing.Size(318, 23)
        Me.Cu_BuscarPersonaResponsableActividad.TabIndex = 65
        Me.Cu_BuscarPersonaResponsableActividad.Tipo = "PABO"
        Me.Cu_BuscarPersonaResponsableActividad.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaDirectorObra
        '
        Me.Cu_BuscarPersonaDirectorObra.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaDirectorObra.Location = New System.Drawing.Point(102, 459)
        Me.Cu_BuscarPersonaDirectorObra.Name = "Cu_BuscarPersonaDirectorObra"
        Me.Cu_BuscarPersonaDirectorObra.Size = New System.Drawing.Size(318, 23)
        Me.Cu_BuscarPersonaDirectorObra.TabIndex = 59
        Me.Cu_BuscarPersonaDirectorObra.Tipo = "PABO"
        Me.Cu_BuscarPersonaDirectorObra.valorcajatexto = "IDENTIFICACION"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Ck_OtrosAnexos)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoInformesMedicos)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoFotos)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoDibujos)
        Me.GroupBox5.Controls.Add(Me.Tb_OtrosAnexos)
        Me.GroupBox5.Controls.Add(Me.Lb_OtrosAnexos)
        Me.GroupBox5.Location = New System.Drawing.Point(468, 341)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(431, 78)
        Me.GroupBox5.TabIndex = 46
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Anexos"
        '
        'Ck_OtrosAnexos
        '
        Me.Ck_OtrosAnexos.AutoSize = True
        Me.Ck_OtrosAnexos.Checked = True
        Me.Ck_OtrosAnexos.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_OtrosAnexos.Location = New System.Drawing.Point(344, 20)
        Me.Ck_OtrosAnexos.Name = "Ck_OtrosAnexos"
        Me.Ck_OtrosAnexos.Size = New System.Drawing.Size(51, 17)
        Me.Ck_OtrosAnexos.TabIndex = 50
        Me.Ck_OtrosAnexos.Text = "Otros"
        Me.Ck_OtrosAnexos.UseVisualStyleBackColor = True
        '
        'Ck_AnexoInformesMedicos
        '
        Me.Ck_AnexoInformesMedicos.AutoSize = True
        Me.Ck_AnexoInformesMedicos.Checked = True
        Me.Ck_AnexoInformesMedicos.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_AnexoInformesMedicos.Location = New System.Drawing.Point(229, 20)
        Me.Ck_AnexoInformesMedicos.Name = "Ck_AnexoInformesMedicos"
        Me.Ck_AnexoInformesMedicos.Size = New System.Drawing.Size(109, 17)
        Me.Ck_AnexoInformesMedicos.TabIndex = 49
        Me.Ck_AnexoInformesMedicos.Text = "Informes Médicos"
        Me.Ck_AnexoInformesMedicos.UseVisualStyleBackColor = True
        '
        'Ck_AnexoFotos
        '
        Me.Ck_AnexoFotos.AutoSize = True
        Me.Ck_AnexoFotos.Checked = True
        Me.Ck_AnexoFotos.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_AnexoFotos.Location = New System.Drawing.Point(134, 20)
        Me.Ck_AnexoFotos.Name = "Ck_AnexoFotos"
        Me.Ck_AnexoFotos.Size = New System.Drawing.Size(89, 17)
        Me.Ck_AnexoFotos.TabIndex = 48
        Me.Ck_AnexoFotos.Text = "Fotos/Videos"
        Me.Ck_AnexoFotos.UseVisualStyleBackColor = True
        '
        'Ck_AnexoDibujos
        '
        Me.Ck_AnexoDibujos.AutoSize = True
        Me.Ck_AnexoDibujos.Checked = True
        Me.Ck_AnexoDibujos.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_AnexoDibujos.Location = New System.Drawing.Point(12, 20)
        Me.Ck_AnexoDibujos.Name = "Ck_AnexoDibujos"
        Me.Ck_AnexoDibujos.Size = New System.Drawing.Size(116, 17)
        Me.Ck_AnexoDibujos.TabIndex = 47
        Me.Ck_AnexoDibujos.Text = "Dibujos/Diagramas"
        Me.Ck_AnexoDibujos.UseVisualStyleBackColor = True
        '
        'Tb_OtrosAnexos
        '
        Me.Tb_OtrosAnexos.Location = New System.Drawing.Point(61, 44)
        Me.Tb_OtrosAnexos.MaxLength = 30
        Me.Tb_OtrosAnexos.Name = "Tb_OtrosAnexos"
        Me.Tb_OtrosAnexos.Size = New System.Drawing.Size(252, 20)
        Me.Tb_OtrosAnexos.TabIndex = 52
        '
        'Lb_OtrosAnexos
        '
        Me.Lb_OtrosAnexos.AutoSize = True
        Me.Lb_OtrosAnexos.Location = New System.Drawing.Point(9, 47)
        Me.Lb_OtrosAnexos.Name = "Lb_OtrosAnexos"
        Me.Lb_OtrosAnexos.Size = New System.Drawing.Size(40, 13)
        Me.Lb_OtrosAnexos.TabIndex = 51
        Me.Lb_OtrosAnexos.Text = "¿Cual?"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Tb_CategoriaResultante)
        Me.GroupBox4.Controls.Add(Me.Lb_CategoriaResultante)
        Me.GroupBox4.Controls.Add(Me.Tb_EvitadoAccidente)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.Cb_Recurrencia)
        Me.GroupBox4.Controls.Add(Me.Label50)
        Me.GroupBox4.Controls.Add(Me.Cb_Severidad)
        Me.GroupBox4.Controls.Add(Me.Label51)
        Me.GroupBox4.Location = New System.Drawing.Point(468, 168)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(431, 167)
        Me.GroupBox4.TabIndex = 34
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Perdida Potencial"
        '
        'Tb_CategoriaResultante
        '
        Me.Tb_CategoriaResultante.Enabled = False
        Me.Tb_CategoriaResultante.Location = New System.Drawing.Point(129, 16)
        Me.Tb_CategoriaResultante.Name = "Tb_CategoriaResultante"
        Me.Tb_CategoriaResultante.Size = New System.Drawing.Size(165, 20)
        Me.Tb_CategoriaResultante.TabIndex = 37
        '
        'Lb_CategoriaResultante
        '
        Me.Lb_CategoriaResultante.AutoSize = True
        Me.Lb_CategoriaResultante.Location = New System.Drawing.Point(14, 20)
        Me.Lb_CategoriaResultante.Name = "Lb_CategoriaResultante"
        Me.Lb_CategoriaResultante.Size = New System.Drawing.Size(111, 13)
        Me.Lb_CategoriaResultante.TabIndex = 36
        Me.Lb_CategoriaResultante.Text = "Categoría Resultante:"
        '
        'Tb_EvitadoAccidente
        '
        Me.Tb_EvitadoAccidente.Location = New System.Drawing.Point(11, 90)
        Me.Tb_EvitadoAccidente.MaxLength = 350
        Me.Tb_EvitadoAccidente.Multiline = True
        Me.Tb_EvitadoAccidente.Name = "Tb_EvitadoAccidente"
        Me.Tb_EvitadoAccidente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tb_EvitadoAccidente.Size = New System.Drawing.Size(411, 60)
        Me.Tb_EvitadoAccidente.TabIndex = 43
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(14, 74)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(209, 13)
        Me.Label52.TabIndex = 42
        Me.Label52.Text = "¿Como pudo haberse evitado el incidente?"
        '
        'Cb_Recurrencia
        '
        Me.Cb_Recurrencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Recurrencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Recurrencia.FormattingEnabled = True
        Me.Cb_Recurrencia.Items.AddRange(New Object() {"Uno en 3 años", "Uno en 2 años", "Uno en 1 año"})
        Me.Cb_Recurrencia.Location = New System.Drawing.Point(295, 43)
        Me.Cb_Recurrencia.Name = "Cb_Recurrencia"
        Me.Cb_Recurrencia.Size = New System.Drawing.Size(127, 21)
        Me.Cb_Recurrencia.TabIndex = 41
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(226, 48)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(68, 13)
        Me.Label50.TabIndex = 40
        Me.Label50.Text = "Recurrencia:"
        '
        'Cb_Severidad
        '
        Me.Cb_Severidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Severidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Severidad.FormattingEnabled = True
        Me.Cb_Severidad.Location = New System.Drawing.Point(75, 43)
        Me.Cb_Severidad.Name = "Cb_Severidad"
        Me.Cb_Severidad.Size = New System.Drawing.Size(148, 21)
        Me.Cb_Severidad.TabIndex = 39
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(14, 48)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(58, 13)
        Me.Label51.TabIndex = 38
        Me.Label51.Text = "Severidad:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Tb_AccionInmediata3)
        Me.GroupBox2.Controls.Add(Me.Lb_AccionInmediata3)
        Me.GroupBox2.Controls.Add(Me.Tb_AccionInmediata2)
        Me.GroupBox2.Controls.Add(Me.Lb_AccionInmediata2)
        Me.GroupBox2.Controls.Add(Me.Tb_AccionInmediata1)
        Me.GroupBox2.Controls.Add(Me.Lb_AccionInmediata1)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 255)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 164)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Acciones Inmediatas"
        '
        'Tb_AccionInmediata3
        '
        Me.Tb_AccionInmediata3.Location = New System.Drawing.Point(32, 113)
        Me.Tb_AccionInmediata3.MaxLength = 100
        Me.Tb_AccionInmediata3.Multiline = True
        Me.Tb_AccionInmediata3.Name = "Tb_AccionInmediata3"
        Me.Tb_AccionInmediata3.Size = New System.Drawing.Size(391, 40)
        Me.Tb_AccionInmediata3.TabIndex = 51
        '
        'Lb_AccionInmediata3
        '
        Me.Lb_AccionInmediata3.AutoSize = True
        Me.Lb_AccionInmediata3.Location = New System.Drawing.Point(10, 113)
        Me.Lb_AccionInmediata3.Name = "Lb_AccionInmediata3"
        Me.Lb_AccionInmediata3.Size = New System.Drawing.Size(16, 13)
        Me.Lb_AccionInmediata3.TabIndex = 50
        Me.Lb_AccionInmediata3.Text = "3."
        '
        'Tb_AccionInmediata2
        '
        Me.Tb_AccionInmediata2.Location = New System.Drawing.Point(32, 66)
        Me.Tb_AccionInmediata2.MaxLength = 100
        Me.Tb_AccionInmediata2.Multiline = True
        Me.Tb_AccionInmediata2.Name = "Tb_AccionInmediata2"
        Me.Tb_AccionInmediata2.Size = New System.Drawing.Size(391, 40)
        Me.Tb_AccionInmediata2.TabIndex = 49
        '
        'Lb_AccionInmediata2
        '
        Me.Lb_AccionInmediata2.AutoSize = True
        Me.Lb_AccionInmediata2.Location = New System.Drawing.Point(10, 66)
        Me.Lb_AccionInmediata2.Name = "Lb_AccionInmediata2"
        Me.Lb_AccionInmediata2.Size = New System.Drawing.Size(16, 13)
        Me.Lb_AccionInmediata2.TabIndex = 48
        Me.Lb_AccionInmediata2.Text = "2."
        '
        'Tb_AccionInmediata1
        '
        Me.Tb_AccionInmediata1.Location = New System.Drawing.Point(32, 19)
        Me.Tb_AccionInmediata1.MaxLength = 100
        Me.Tb_AccionInmediata1.Multiline = True
        Me.Tb_AccionInmediata1.Name = "Tb_AccionInmediata1"
        Me.Tb_AccionInmediata1.Size = New System.Drawing.Size(391, 40)
        Me.Tb_AccionInmediata1.TabIndex = 47
        '
        'Lb_AccionInmediata1
        '
        Me.Lb_AccionInmediata1.AutoSize = True
        Me.Lb_AccionInmediata1.Location = New System.Drawing.Point(10, 19)
        Me.Lb_AccionInmediata1.Name = "Lb_AccionInmediata1"
        Me.Lb_AccionInmediata1.Size = New System.Drawing.Size(16, 13)
        Me.Lb_AccionInmediata1.TabIndex = 46
        Me.Lb_AccionInmediata1.Text = "1."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tb_Descripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 168)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 80)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Descripcion Incidente ¿Qué, Cuándo,Cómo y Por qué pasó?"
        '
        'Tb_Descripcion
        '
        Me.Tb_Descripcion.Location = New System.Drawing.Point(13, 20)
        Me.Tb_Descripcion.MaxLength = 500
        Me.Tb_Descripcion.Multiline = True
        Me.Tb_Descripcion.Name = "Tb_Descripcion"
        Me.Tb_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tb_Descripcion.Size = New System.Drawing.Size(410, 51)
        Me.Tb_Descripcion.TabIndex = 33
        '
        'Cb_CargoReporta
        '
        Me.Cb_CargoReporta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_CargoReporta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_CargoReporta.FormattingEnabled = True
        Me.Cb_CargoReporta.Location = New System.Drawing.Point(603, 430)
        Me.Cb_CargoReporta.Name = "Cb_CargoReporta"
        Me.Cb_CargoReporta.Size = New System.Drawing.Size(295, 21)
        Me.Cb_CargoReporta.TabIndex = 57
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(467, 434)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 13)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "Cargo De Quien Reporta:"
        '
        'Cu_AsociarPersonaReporte
        '
        Me.Cu_AsociarPersonaReporte.componenteasociado = Nothing
        Me.Cu_AsociarPersonaReporte.CrearUsuario = False
        Me.Cu_AsociarPersonaReporte.Location = New System.Drawing.Point(416, 429)
        Me.Cu_AsociarPersonaReporte.Name = "Cu_AsociarPersonaReporte"
        Me.Cu_AsociarPersonaReporte.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaReporte.TabIndex = 55
        Me.Cu_AsociarPersonaReporte.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaReporte.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaReporta
        '
        Me.Cu_BuscarPersonaReporta.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaReporta.Location = New System.Drawing.Point(102, 428)
        Me.Cu_BuscarPersonaReporta.Name = "Cu_BuscarPersonaReporta"
        Me.Cu_BuscarPersonaReporta.Size = New System.Drawing.Size(318, 23)
        Me.Cu_BuscarPersonaReporta.TabIndex = 54
        Me.Cu_BuscarPersonaReporta.Tipo = "PABO"
        Me.Cu_BuscarPersonaReporta.valorcajatexto = "IDENTIFICACION"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 430)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "Reportado Por:"
        '
        'DTP_HoraIncidente
        '
        Me.DTP_HoraIncidente.Checked = False
        Me.DTP_HoraIncidente.CustomFormat = "hh:mm tt"
        Me.DTP_HoraIncidente.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_HoraIncidente.Location = New System.Drawing.Point(92, 140)
        Me.DTP_HoraIncidente.Name = "DTP_HoraIncidente"
        Me.DTP_HoraIncidente.ShowCheckBox = True
        Me.DTP_HoraIncidente.ShowUpDown = True
        Me.DTP_HoraIncidente.Size = New System.Drawing.Size(93, 20)
        Me.DTP_HoraIncidente.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 143)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Hora Incidente :"
        '
        'DTP_FechaIncidente
        '
        Me.DTP_FechaIncidente.Checked = False
        Me.DTP_FechaIncidente.Location = New System.Drawing.Point(522, 103)
        Me.DTP_FechaIncidente.Name = "DTP_FechaIncidente"
        Me.DTP_FechaIncidente.ShowCheckBox = True
        Me.DTP_FechaIncidente.Size = New System.Drawing.Size(222, 20)
        Me.DTP_FechaIncidente.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(432, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Fecha Incidente:"
        '
        'Tb_SitioIncidente
        '
        Me.Tb_SitioIncidente.Location = New System.Drawing.Point(91, 66)
        Me.Tb_SitioIncidente.MaxLength = 50
        Me.Tb_SitioIncidente.Name = "Tb_SitioIncidente"
        Me.Tb_SitioIncidente.Size = New System.Drawing.Size(210, 20)
        Me.Tb_SitioIncidente.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Sitio Incidente:"
        '
        'Tx_Empleador
        '
        Me.Tx_Empleador.Location = New System.Drawing.Point(499, 37)
        Me.Tx_Empleador.MaxLength = 50
        Me.Tx_Empleador.Name = "Tx_Empleador"
        Me.Tx_Empleador.Size = New System.Drawing.Size(136, 20)
        Me.Tx_Empleador.TabIndex = 13
        '
        'Lb_Empleador
        '
        Me.Lb_Empleador.AutoSize = True
        Me.Lb_Empleador.Location = New System.Drawing.Point(369, 39)
        Me.Lb_Empleador.Name = "Lb_Empleador"
        Me.Lb_Empleador.Size = New System.Drawing.Size(125, 13)
        Me.Lb_Empleador.TabIndex = 12
        Me.Lb_Empleador.Text = "¿Nombre del empleador?"
        '
        'Ck_Empleador
        '
        Me.Ck_Empleador.AutoSize = True
        Me.Ck_Empleador.Checked = True
        Me.Ck_Empleador.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_Empleador.Location = New System.Drawing.Point(351, 40)
        Me.Ck_Empleador.Name = "Ck_Empleador"
        Me.Ck_Empleador.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Empleador.TabIndex = 11
        Me.Ck_Empleador.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(215, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "¿El empleador es Ismocol?"
        '
        'Cb_Area
        '
        Me.Cb_Area.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Area.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Area.FormattingEnabled = True
        Me.Cb_Area.Location = New System.Drawing.Point(91, 37)
        Me.Cb_Area.Name = "Cb_Area"
        Me.Cb_Area.Size = New System.Drawing.Size(119, 21)
        Me.Cb_Area.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(54, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Área:"
        '
        'Cb_TipoConsecuencia
        '
        Me.Cb_TipoConsecuencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoConsecuencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoConsecuencia.FormattingEnabled = True
        Me.Cb_TipoConsecuencia.Location = New System.Drawing.Point(712, 9)
        Me.Cb_TipoConsecuencia.Name = "Cb_TipoConsecuencia"
        Me.Cb_TipoConsecuencia.Size = New System.Drawing.Size(182, 21)
        Me.Cb_TipoConsecuencia.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(630, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Consecuencia:"
        '
        'Cb_TipoIncidente
        '
        Me.Cb_TipoIncidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoIncidente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoIncidente.FormattingEnabled = True
        Me.Cb_TipoIncidente.Location = New System.Drawing.Point(533, 9)
        Me.Cb_TipoIncidente.Name = "Cb_TipoIncidente"
        Me.Cb_TipoIncidente.Size = New System.Drawing.Size(83, 21)
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
        Me.Cb_Proyecto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Proyecto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Proyecto.FormattingEnabled = True
        Me.Cb_Proyecto.Location = New System.Drawing.Point(258, 9)
        Me.Cb_Proyecto.Name = "Cb_Proyecto"
        Me.Cb_Proyecto.Size = New System.Drawing.Size(173, 21)
        Me.Cb_Proyecto.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proyecto:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Contrato:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(906, 525)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Información del afectado"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Gb_TipoAccidente)
        Me.GroupBox6.Controls.Add(Me.Gb_CausoMuerte)
        Me.GroupBox6.Controls.Add(Me.Gb_Testigos)
        Me.GroupBox6.Controls.Add(Me.GroupBox11)
        Me.GroupBox6.Controls.Add(Me.Tb_OtraParteAfectada)
        Me.GroupBox6.Controls.Add(Me.Lb_ParteAfectada)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroTipoLesion)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroMecanismoAccidente)
        Me.GroupBox6.Controls.Add(Me.Lb_TipoLesion)
        Me.GroupBox6.Controls.Add(Me.Cb_TipoLesion)
        Me.GroupBox6.Controls.Add(Me.Lb_Mecanismo)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroSitioIncidente)
        Me.GroupBox6.Controls.Add(Me.Cb_MecanismoAccidente)
        Me.GroupBox6.Controls.Add(Me.Lb_SitioIncidente)
        Me.GroupBox6.Controls.Add(Me.Tx_TrabajoHabitual)
        Me.GroupBox6.Controls.Add(Me.Cb_SitioIncidente)
        Me.GroupBox6.Controls.Add(Me.Lb_TrabajoHabitual)
        Me.GroupBox6.Controls.Add(Me.Label41)
        Me.GroupBox6.Controls.Add(Me.Label33)
        Me.GroupBox6.Controls.Add(Me.Cb_JornadaIncidente)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroAgenteAccidente)
        Me.GroupBox6.Controls.Add(Me.Label25)
        Me.GroupBox6.Controls.Add(Me.Tb_DiagnosticoLesion)
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
        Me.GroupBox6.Location = New System.Drawing.Point(13, 216)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(887, 303)
        Me.GroupBox6.TabIndex = 106
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Información Sobre el Accidente"
        '
        'Gb_TipoAccidente
        '
        Me.Gb_TipoAccidente.Controls.Add(Me.Lb_TipoAccidente)
        Me.Gb_TipoAccidente.Controls.Add(Me.Rb_PropioTrabajo)
        Me.Gb_TipoAccidente.Controls.Add(Me.Rb_Recreativo)
        Me.Gb_TipoAccidente.Controls.Add(Me.Rb_Deportivo)
        Me.Gb_TipoAccidente.Controls.Add(Me.Rb_Transito)
        Me.Gb_TipoAccidente.Controls.Add(Me.Rb_Violencia)
        Me.Gb_TipoAccidente.Location = New System.Drawing.Point(11, 17)
        Me.Gb_TipoAccidente.Name = "Gb_TipoAccidente"
        Me.Gb_TipoAccidente.Size = New System.Drawing.Size(623, 37)
        Me.Gb_TipoAccidente.TabIndex = 107
        Me.Gb_TipoAccidente.TabStop = False
        '
        'Lb_TipoAccidente
        '
        Me.Lb_TipoAccidente.AutoSize = True
        Me.Lb_TipoAccidente.Location = New System.Drawing.Point(6, 15)
        Me.Lb_TipoAccidente.Name = "Lb_TipoAccidente"
        Me.Lb_TipoAccidente.Size = New System.Drawing.Size(99, 13)
        Me.Lb_TipoAccidente.TabIndex = 1
        Me.Lb_TipoAccidente.Text = "Tipo De Accidente:"
        '
        'Rb_PropioTrabajo
        '
        Me.Rb_PropioTrabajo.AutoSize = True
        Me.Rb_PropioTrabajo.Location = New System.Drawing.Point(468, 13)
        Me.Rb_PropioTrabajo.Name = "Rb_PropioTrabajo"
        Me.Rb_PropioTrabajo.Size = New System.Drawing.Size(112, 17)
        Me.Rb_PropioTrabajo.TabIndex = 6
        Me.Rb_PropioTrabajo.TabStop = True
        Me.Rb_PropioTrabajo.Text = "Propios del trabajo"
        Me.Rb_PropioTrabajo.UseVisualStyleBackColor = True
        '
        'Rb_Recreativo
        '
        Me.Rb_Recreativo.AutoSize = True
        Me.Rb_Recreativo.Location = New System.Drawing.Point(335, 13)
        Me.Rb_Recreativo.Name = "Rb_Recreativo"
        Me.Rb_Recreativo.Size = New System.Drawing.Size(126, 17)
        Me.Rb_Recreativo.TabIndex = 5
        Me.Rb_Recreativo.TabStop = True
        Me.Rb_Recreativo.Text = "Recreativo O Cultural"
        Me.Rb_Recreativo.UseVisualStyleBackColor = True
        '
        'Rb_Deportivo
        '
        Me.Rb_Deportivo.AutoSize = True
        Me.Rb_Deportivo.Location = New System.Drawing.Point(257, 14)
        Me.Rb_Deportivo.Name = "Rb_Deportivo"
        Me.Rb_Deportivo.Size = New System.Drawing.Size(71, 17)
        Me.Rb_Deportivo.TabIndex = 4
        Me.Rb_Deportivo.TabStop = True
        Me.Rb_Deportivo.Text = "Deportivo"
        Me.Rb_Deportivo.UseVisualStyleBackColor = True
        '
        'Rb_Transito
        '
        Me.Rb_Transito.AutoSize = True
        Me.Rb_Transito.Location = New System.Drawing.Point(187, 14)
        Me.Rb_Transito.Name = "Rb_Transito"
        Me.Rb_Transito.Size = New System.Drawing.Size(63, 17)
        Me.Rb_Transito.TabIndex = 3
        Me.Rb_Transito.TabStop = True
        Me.Rb_Transito.Text = "Transito"
        Me.Rb_Transito.UseVisualStyleBackColor = True
        '
        'Rb_Violencia
        '
        Me.Rb_Violencia.AutoSize = True
        Me.Rb_Violencia.Location = New System.Drawing.Point(112, 14)
        Me.Rb_Violencia.Name = "Rb_Violencia"
        Me.Rb_Violencia.Size = New System.Drawing.Size(68, 17)
        Me.Rb_Violencia.TabIndex = 2
        Me.Rb_Violencia.TabStop = True
        Me.Rb_Violencia.Text = "Violencia"
        Me.Rb_Violencia.UseVisualStyleBackColor = True
        '
        'Gb_CausoMuerte
        '
        Me.Gb_CausoMuerte.Controls.Add(Me.Label29)
        Me.Gb_CausoMuerte.Controls.Add(Me.Rb_MuerteSi)
        Me.Gb_CausoMuerte.Controls.Add(Me.Rb_MuerteNo)
        Me.Gb_CausoMuerte.Location = New System.Drawing.Point(645, 17)
        Me.Gb_CausoMuerte.Name = "Gb_CausoMuerte"
        Me.Gb_CausoMuerte.Size = New System.Drawing.Size(180, 38)
        Me.Gb_CausoMuerte.TabIndex = 108
        Me.Gb_CausoMuerte.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 16)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(85, 13)
        Me.Label29.TabIndex = 1
        Me.Label29.Text = "¿Causo Muerte?"
        '
        'Rb_MuerteSi
        '
        Me.Rb_MuerteSi.AutoSize = True
        Me.Rb_MuerteSi.Location = New System.Drawing.Point(97, 14)
        Me.Rb_MuerteSi.Name = "Rb_MuerteSi"
        Me.Rb_MuerteSi.Size = New System.Drawing.Size(34, 17)
        Me.Rb_MuerteSi.TabIndex = 2
        Me.Rb_MuerteSi.TabStop = True
        Me.Rb_MuerteSi.Text = "Si"
        Me.Rb_MuerteSi.UseVisualStyleBackColor = True
        '
        'Rb_MuerteNo
        '
        Me.Rb_MuerteNo.AutoSize = True
        Me.Rb_MuerteNo.Location = New System.Drawing.Point(137, 14)
        Me.Rb_MuerteNo.Name = "Rb_MuerteNo"
        Me.Rb_MuerteNo.Size = New System.Drawing.Size(39, 17)
        Me.Rb_MuerteNo.TabIndex = 3
        Me.Rb_MuerteNo.TabStop = True
        Me.Rb_MuerteNo.Text = "No"
        Me.Rb_MuerteNo.UseVisualStyleBackColor = True
        '
        'Gb_Testigos
        '
        Me.Gb_Testigos.Controls.Add(Me.Label46)
        Me.Gb_Testigos.Controls.Add(Me.Rb_TestigosSi)
        Me.Gb_Testigos.Controls.Add(Me.Rb_TestigosNo)
        Me.Gb_Testigos.Location = New System.Drawing.Point(695, 252)
        Me.Gb_Testigos.Name = "Gb_Testigos"
        Me.Gb_Testigos.Size = New System.Drawing.Size(183, 38)
        Me.Gb_Testigos.TabIndex = 140
        Me.Gb_Testigos.TabStop = False
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(6, 16)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(88, 13)
        Me.Label46.TabIndex = 1
        Me.Label46.Text = "¿Hubo Testigos?"
        '
        'Rb_TestigosSi
        '
        Me.Rb_TestigosSi.AutoSize = True
        Me.Rb_TestigosSi.Location = New System.Drawing.Point(99, 14)
        Me.Rb_TestigosSi.Name = "Rb_TestigosSi"
        Me.Rb_TestigosSi.Size = New System.Drawing.Size(34, 17)
        Me.Rb_TestigosSi.TabIndex = 2
        Me.Rb_TestigosSi.TabStop = True
        Me.Rb_TestigosSi.Text = "Si"
        Me.Rb_TestigosSi.UseVisualStyleBackColor = True
        '
        'Rb_TestigosNo
        '
        Me.Rb_TestigosNo.AutoSize = True
        Me.Rb_TestigosNo.Location = New System.Drawing.Point(138, 14)
        Me.Rb_TestigosNo.Name = "Rb_TestigosNo"
        Me.Rb_TestigosNo.Size = New System.Drawing.Size(39, 17)
        Me.Rb_TestigosNo.TabIndex = 3
        Me.Rb_TestigosNo.TabStop = True
        Me.Rb_TestigosNo.Text = "No"
        Me.Rb_TestigosNo.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Rb_TrabajoHabitualNo)
        Me.GroupBox11.Controls.Add(Me.Rb_TrabajoHabitualSi)
        Me.GroupBox11.Controls.Add(Me.Label15)
        Me.GroupBox11.Location = New System.Drawing.Point(331, 53)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(303, 35)
        Me.GroupBox11.TabIndex = 111
        Me.GroupBox11.TabStop = False
        '
        'Rb_TrabajoHabitualNo
        '
        Me.Rb_TrabajoHabitualNo.AutoSize = True
        Me.Rb_TrabajoHabitualNo.Location = New System.Drawing.Point(253, 12)
        Me.Rb_TrabajoHabitualNo.Name = "Rb_TrabajoHabitualNo"
        Me.Rb_TrabajoHabitualNo.Size = New System.Drawing.Size(39, 17)
        Me.Rb_TrabajoHabitualNo.TabIndex = 113
        Me.Rb_TrabajoHabitualNo.TabStop = True
        Me.Rb_TrabajoHabitualNo.Text = "No"
        Me.Rb_TrabajoHabitualNo.UseVisualStyleBackColor = True
        '
        'Rb_TrabajoHabitualSi
        '
        Me.Rb_TrabajoHabitualSi.AutoSize = True
        Me.Rb_TrabajoHabitualSi.Location = New System.Drawing.Point(213, 12)
        Me.Rb_TrabajoHabitualSi.Name = "Rb_TrabajoHabitualSi"
        Me.Rb_TrabajoHabitualSi.Size = New System.Drawing.Size(34, 17)
        Me.Rb_TrabajoHabitualSi.TabIndex = 112
        Me.Rb_TrabajoHabitualSi.TabStop = True
        Me.Rb_TrabajoHabitualSi.Text = "Si"
        Me.Rb_TrabajoHabitualSi.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(203, 13)
        Me.Label15.TabIndex = 111
        Me.Label15.Text = "¿Estaba Realizando su Trabajo Habitual?"
        '
        'Tb_OtraParteAfectada
        '
        Me.Tb_OtraParteAfectada.Location = New System.Drawing.Point(382, 151)
        Me.Tb_OtraParteAfectada.MaxLength = 30
        Me.Tb_OtraParteAfectada.Name = "Tb_OtraParteAfectada"
        Me.Tb_OtraParteAfectada.Size = New System.Drawing.Size(496, 20)
        Me.Tb_OtraParteAfectada.TabIndex = 125
        '
        'Lb_ParteAfectada
        '
        Me.Lb_ParteAfectada.AutoSize = True
        Me.Lb_ParteAfectada.Location = New System.Drawing.Point(336, 154)
        Me.Lb_ParteAfectada.Name = "Lb_ParteAfectada"
        Me.Lb_ParteAfectada.Size = New System.Drawing.Size(40, 13)
        Me.Lb_ParteAfectada.TabIndex = 124
        Me.Lb_ParteAfectada.Text = "¿Cual?"
        '
        'Tb_OtroTipoLesion
        '
        Me.Tb_OtroTipoLesion.Location = New System.Drawing.Point(382, 122)
        Me.Tb_OtroTipoLesion.MaxLength = 30
        Me.Tb_OtroTipoLesion.Name = "Tb_OtroTipoLesion"
        Me.Tb_OtroTipoLesion.Size = New System.Drawing.Size(496, 20)
        Me.Tb_OtroTipoLesion.TabIndex = 121
        '
        'Tb_OtroMecanismoAccidente
        '
        Me.Tb_OtroMecanismoAccidente.Location = New System.Drawing.Point(382, 210)
        Me.Tb_OtroMecanismoAccidente.MaxLength = 30
        Me.Tb_OtroMecanismoAccidente.Name = "Tb_OtroMecanismoAccidente"
        Me.Tb_OtroMecanismoAccidente.Size = New System.Drawing.Size(496, 20)
        Me.Tb_OtroMecanismoAccidente.TabIndex = 133
        '
        'Lb_TipoLesion
        '
        Me.Lb_TipoLesion.AutoSize = True
        Me.Lb_TipoLesion.Location = New System.Drawing.Point(336, 125)
        Me.Lb_TipoLesion.Name = "Lb_TipoLesion"
        Me.Lb_TipoLesion.Size = New System.Drawing.Size(40, 13)
        Me.Lb_TipoLesion.TabIndex = 120
        Me.Lb_TipoLesion.Text = "¿Cual?"
        '
        'Cb_TipoLesion
        '
        Me.Cb_TipoLesion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoLesion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoLesion.FormattingEnabled = True
        Me.Cb_TipoLesion.Location = New System.Drawing.Point(146, 122)
        Me.Cb_TipoLesion.Name = "Cb_TipoLesion"
        Me.Cb_TipoLesion.Size = New System.Drawing.Size(173, 21)
        Me.Cb_TipoLesion.TabIndex = 119
        '
        'Lb_Mecanismo
        '
        Me.Lb_Mecanismo.AutoSize = True
        Me.Lb_Mecanismo.Location = New System.Drawing.Point(336, 213)
        Me.Lb_Mecanismo.Name = "Lb_Mecanismo"
        Me.Lb_Mecanismo.Size = New System.Drawing.Size(40, 13)
        Me.Lb_Mecanismo.TabIndex = 132
        Me.Lb_Mecanismo.Text = "¿Cual?"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(77, 125)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(65, 13)
        Me.Label36.TabIndex = 118
        Me.Label36.Text = "Tipo Lesión:"
        '
        'Tb_OtroSitioIncidente
        '
        Me.Tb_OtroSitioIncidente.Location = New System.Drawing.Point(382, 93)
        Me.Tb_OtroSitioIncidente.MaxLength = 30
        Me.Tb_OtroSitioIncidente.Name = "Tb_OtroSitioIncidente"
        Me.Tb_OtroSitioIncidente.Size = New System.Drawing.Size(496, 20)
        Me.Tb_OtroSitioIncidente.TabIndex = 117
        '
        'Cb_MecanismoAccidente
        '
        Me.Cb_MecanismoAccidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_MecanismoAccidente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_MecanismoAccidente.FormattingEnabled = True
        Me.Cb_MecanismoAccidente.Location = New System.Drawing.Point(146, 209)
        Me.Cb_MecanismoAccidente.Name = "Cb_MecanismoAccidente"
        Me.Cb_MecanismoAccidente.Size = New System.Drawing.Size(173, 21)
        Me.Cb_MecanismoAccidente.TabIndex = 131
        '
        'Lb_SitioIncidente
        '
        Me.Lb_SitioIncidente.AutoSize = True
        Me.Lb_SitioIncidente.Location = New System.Drawing.Point(336, 98)
        Me.Lb_SitioIncidente.Name = "Lb_SitioIncidente"
        Me.Lb_SitioIncidente.Size = New System.Drawing.Size(40, 13)
        Me.Lb_SitioIncidente.TabIndex = 116
        Me.Lb_SitioIncidente.Text = "¿Cual?"
        '
        'Tx_TrabajoHabitual
        '
        Me.Tx_TrabajoHabitual.Location = New System.Drawing.Point(690, 64)
        Me.Tx_TrabajoHabitual.MaxLength = 30
        Me.Tx_TrabajoHabitual.Name = "Tx_TrabajoHabitual"
        Me.Tx_TrabajoHabitual.Size = New System.Drawing.Size(188, 20)
        Me.Tx_TrabajoHabitual.TabIndex = 113
        '
        'Cb_SitioIncidente
        '
        Me.Cb_SitioIncidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_SitioIncidente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_SitioIncidente.FormattingEnabled = True
        Me.Cb_SitioIncidente.Location = New System.Drawing.Point(146, 93)
        Me.Cb_SitioIncidente.Name = "Cb_SitioIncidente"
        Me.Cb_SitioIncidente.Size = New System.Drawing.Size(173, 21)
        Me.Cb_SitioIncidente.TabIndex = 115
        '
        'Lb_TrabajoHabitual
        '
        Me.Lb_TrabajoHabitual.AutoSize = True
        Me.Lb_TrabajoHabitual.Location = New System.Drawing.Point(642, 67)
        Me.Lb_TrabajoHabitual.Name = "Lb_TrabajoHabitual"
        Me.Lb_TrabajoHabitual.Size = New System.Drawing.Size(40, 13)
        Me.Lb_TrabajoHabitual.TabIndex = 112
        Me.Lb_TrabajoHabitual.Text = "¿Cual?"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(10, 212)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(132, 13)
        Me.Label41.TabIndex = 130
        Me.Label41.Text = "Mecanismo del Accidente:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(65, 96)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(77, 13)
        Me.Label33.TabIndex = 114
        Me.Label33.Text = "Sitio Incidente:"
        '
        'Cb_JornadaIncidente
        '
        Me.Cb_JornadaIncidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_JornadaIncidente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_JornadaIncidente.FormattingEnabled = True
        Me.Cb_JornadaIncidente.Items.AddRange(New Object() {"Normal", "Extra"})
        Me.Cb_JornadaIncidente.Location = New System.Drawing.Point(146, 64)
        Me.Cb_JornadaIncidente.Name = "Cb_JornadaIncidente"
        Me.Cb_JornadaIncidente.Size = New System.Drawing.Size(173, 21)
        Me.Cb_JornadaIncidente.TabIndex = 110
        '
        'Tb_OtroAgenteAccidente
        '
        Me.Tb_OtroAgenteAccidente.Location = New System.Drawing.Point(382, 181)
        Me.Tb_OtroAgenteAccidente.MaxLength = 30
        Me.Tb_OtroAgenteAccidente.Name = "Tb_OtroAgenteAccidente"
        Me.Tb_OtroAgenteAccidente.Size = New System.Drawing.Size(496, 20)
        Me.Tb_OtroAgenteAccidente.TabIndex = 129
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(30, 67)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 13)
        Me.Label25.TabIndex = 109
        Me.Label25.Text = "Jornada del Incidente:"
        '
        'Tb_DiagnosticoLesion
        '
        Me.Tb_DiagnosticoLesion.Location = New System.Drawing.Point(146, 238)
        Me.Tb_DiagnosticoLesion.MaxLength = 100
        Me.Tb_DiagnosticoLesion.Name = "Tb_DiagnosticoLesion"
        Me.Tb_DiagnosticoLesion.Size = New System.Drawing.Size(307, 20)
        Me.Tb_DiagnosticoLesion.TabIndex = 135
        '
        'Lb_AgenteAccidente
        '
        Me.Lb_AgenteAccidente.AutoSize = True
        Me.Lb_AgenteAccidente.Location = New System.Drawing.Point(336, 183)
        Me.Lb_AgenteAccidente.Name = "Lb_AgenteAccidente"
        Me.Lb_AgenteAccidente.Size = New System.Drawing.Size(40, 13)
        Me.Lb_AgenteAccidente.TabIndex = 128
        Me.Lb_AgenteAccidente.Text = "¿Cual?"
        '
        'Cb_AgenteAccidente
        '
        Me.Cb_AgenteAccidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_AgenteAccidente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_AgenteAccidente.FormattingEnabled = True
        Me.Cb_AgenteAccidente.Location = New System.Drawing.Point(146, 180)
        Me.Cb_AgenteAccidente.Name = "Cb_AgenteAccidente"
        Me.Cb_AgenteAccidente.Size = New System.Drawing.Size(173, 21)
        Me.Cb_AgenteAccidente.TabIndex = 127
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(16, 243)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(126, 13)
        Me.Label42.TabIndex = 134
        Me.Label42.Text = "Diagnóstico de la Lesión:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(30, 183)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(112, 13)
        Me.Label39.TabIndex = 126
        Me.Label39.Text = "Agente del Accidente:"
        '
        'Tb_Traslado
        '
        Me.Tb_Traslado.Location = New System.Drawing.Point(410, 266)
        Me.Tb_Traslado.MaxLength = 30
        Me.Tb_Traslado.Name = "Tb_Traslado"
        Me.Tb_Traslado.Size = New System.Drawing.Size(272, 20)
        Me.Tb_Traslado.TabIndex = 139
        '
        'Cb_ParteAfectada
        '
        Me.Cb_ParteAfectada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_ParteAfectada.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_ParteAfectada.FormattingEnabled = True
        Me.Cb_ParteAfectada.Location = New System.Drawing.Point(146, 151)
        Me.Cb_ParteAfectada.Name = "Cb_ParteAfectada"
        Me.Cb_ParteAfectada.Size = New System.Drawing.Size(173, 21)
        Me.Cb_ParteAfectada.TabIndex = 123
        '
        'Lb_Trasladado
        '
        Me.Lb_Trasladado.AutoSize = True
        Me.Lb_Trasladado.Location = New System.Drawing.Point(335, 271)
        Me.Lb_Trasladado.Name = "Lb_Trasladado"
        Me.Lb_Trasladado.Size = New System.Drawing.Size(72, 13)
        Me.Lb_Trasladado.TabIndex = 138
        Me.Lb_Trasladado.Text = "Trasladado a:"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(7, 154)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(135, 13)
        Me.Label37.TabIndex = 122
        Me.Label37.Text = "Parte del Cuerpo Afectada:"
        '
        'Cb_AtencionInmediata
        '
        Me.Cb_AtencionInmediata.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_AtencionInmediata.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_AtencionInmediata.FormattingEnabled = True
        Me.Cb_AtencionInmediata.Items.AddRange(New Object() {"MEDEVAC", "Regreso a su trabajo", "Hospitalizado", "Enviado a su casa", "Traslado a centro de Atención"})
        Me.Cb_AtencionInmediata.Location = New System.Drawing.Point(146, 266)
        Me.Cb_AtencionInmediata.Name = "Cb_AtencionInmediata"
        Me.Cb_AtencionInmediata.Size = New System.Drawing.Size(173, 21)
        Me.Cb_AtencionInmediata.TabIndex = 137
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(41, 270)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(101, 13)
        Me.Label44.TabIndex = 136
        Me.Label44.Text = "Atención Inmediata:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Cu_CiudadPersonaAfectada)
        Me.GroupBox3.Controls.Add(Me.Lb_CiudadResidencia)
        Me.GroupBox3.Controls.Add(Me.DTP_FechaNacimiento)
        Me.GroupBox3.Controls.Add(Me.Label53)
        Me.GroupBox3.Controls.Add(Me.GroupBox_Genero)
        Me.GroupBox3.Controls.Add(Me.DTP_InicioContrato)
        Me.GroupBox3.Controls.Add(Me.Cb_AFP)
        Me.GroupBox3.Controls.Add(Me.Label59)
        Me.GroupBox3.Controls.Add(Me.Cb_EPS)
        Me.GroupBox3.Controls.Add(Me.Label49)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Cb_JornadaHabitual)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Tb_Salario)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Cb_OcupacionHabitual)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Cb_CargoPersonaAccidente)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Tb_CorreoElectronico)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Tb_TelefonoMovil)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Tb_Telefono)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Tb_Direccion)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Cu_AsociarPersonaAfectada)
        Me.GroupBox3.Controls.Add(Me.Cu_BuscarPersonaAfectada)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Cb_TipoVinculacion)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(886, 198)
        Me.GroupBox3.TabIndex = 70
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Información Persona Afectada"
        '
        'Cu_CiudadPersonaAfectada
        '
        Me.Cu_CiudadPersonaAfectada.Location = New System.Drawing.Point(110, 104)
        Me.Cu_CiudadPersonaAfectada.Name = "Cu_CiudadPersonaAfectada"
        Me.Cu_CiudadPersonaAfectada.Size = New System.Drawing.Size(286, 23)
        Me.Cu_CiudadPersonaAfectada.TabIndex = 93
        '
        'Lb_CiudadResidencia
        '
        Me.Lb_CiudadResidencia.AutoSize = True
        Me.Lb_CiudadResidencia.Location = New System.Drawing.Point(6, 109)
        Me.Lb_CiudadResidencia.Name = "Lb_CiudadResidencia"
        Me.Lb_CiudadResidencia.Size = New System.Drawing.Size(99, 13)
        Me.Lb_CiudadResidencia.TabIndex = 92
        Me.Lb_CiudadResidencia.Text = "Ciudad Residencia:"
        '
        'DTP_FechaNacimiento
        '
        Me.DTP_FechaNacimiento.Checked = False
        Me.DTP_FechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaNacimiento.Location = New System.Drawing.Point(111, 48)
        Me.DTP_FechaNacimiento.Name = "DTP_FechaNacimiento"
        Me.DTP_FechaNacimiento.ShowCheckBox = True
        Me.DTP_FechaNacimiento.Size = New System.Drawing.Size(146, 20)
        Me.DTP_FechaNacimiento.TabIndex = 81
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(9, 53)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(96, 13)
        Me.Label53.TabIndex = 80
        Me.Label53.Text = "Fecha Nacimiento:"
        '
        'GroupBox_Genero
        '
        Me.GroupBox_Genero.Controls.Add(Me.Label60)
        Me.GroupBox_Genero.Controls.Add(Me.Rb_Femenino)
        Me.GroupBox_Genero.Controls.Add(Me.Rb_Masculino)
        Me.GroupBox_Genero.Location = New System.Drawing.Point(677, 13)
        Me.GroupBox_Genero.Name = "GroupBox_Genero"
        Me.GroupBox_Genero.Size = New System.Drawing.Size(203, 31)
        Me.GroupBox_Genero.TabIndex = 76
        Me.GroupBox_Genero.TabStop = False
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(3, 12)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(45, 13)
        Me.Label60.TabIndex = 77
        Me.Label60.Text = "Genero:"
        '
        'Rb_Femenino
        '
        Me.Rb_Femenino.AutoSize = True
        Me.Rb_Femenino.Location = New System.Drawing.Point(131, 10)
        Me.Rb_Femenino.Name = "Rb_Femenino"
        Me.Rb_Femenino.Size = New System.Drawing.Size(71, 17)
        Me.Rb_Femenino.TabIndex = 79
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
        Me.Rb_Masculino.TabIndex = 78
        Me.Rb_Masculino.TabStop = True
        Me.Rb_Masculino.Text = "Masculino"
        Me.Rb_Masculino.UseVisualStyleBackColor = True
        '
        'DTP_InicioContrato
        '
        Me.DTP_InicioContrato.Checked = False
        Me.DTP_InicioContrato.Location = New System.Drawing.Point(662, 164)
        Me.DTP_InicioContrato.MaxDate = New Date(2021, 6, 2, 0, 0, 0, 0)
        Me.DTP_InicioContrato.Name = "DTP_InicioContrato"
        Me.DTP_InicioContrato.ShowCheckBox = True
        Me.DTP_InicioContrato.Size = New System.Drawing.Size(218, 20)
        Me.DTP_InicioContrato.TabIndex = 105
        Me.DTP_InicioContrato.Value = New Date(2021, 6, 2, 0, 0, 0, 0)
        '
        'Cb_AFP
        '
        Me.Cb_AFP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_AFP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_AFP.FormattingEnabled = True
        Me.Cb_AFP.Location = New System.Drawing.Point(549, 49)
        Me.Cb_AFP.Name = "Cb_AFP"
        Me.Cb_AFP.Size = New System.Drawing.Size(207, 21)
        Me.Cb_AFP.TabIndex = 85
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(517, 53)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(30, 13)
        Me.Label59.TabIndex = 84
        Me.Label59.Text = "AFP:"
        '
        'Cb_EPS
        '
        Me.Cb_EPS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_EPS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_EPS.FormattingEnabled = True
        Me.Cb_EPS.Location = New System.Drawing.Point(297, 49)
        Me.Cb_EPS.Name = "Cb_EPS"
        Me.Cb_EPS.Size = New System.Drawing.Size(207, 21)
        Me.Cb_EPS.TabIndex = 83
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(265, 53)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(31, 13)
        Me.Label49.TabIndex = 82
        Me.Label49.Text = "EPS:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(550, 168)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(111, 13)
        Me.Label28.TabIndex = 104
        Me.Label28.Text = "Fecha Inicio Contrato:"
        '
        'Cb_JornadaHabitual
        '
        Me.Cb_JornadaHabitual.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_JornadaHabitual.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_JornadaHabitual.FormattingEnabled = True
        Me.Cb_JornadaHabitual.Items.AddRange(New Object() {"Diurna", "Nocturna", "Mixto", "Turnos"})
        Me.Cb_JornadaHabitual.Location = New System.Drawing.Point(410, 164)
        Me.Cb_JornadaHabitual.Name = "Cb_JornadaHabitual"
        Me.Cb_JornadaHabitual.Size = New System.Drawing.Size(131, 21)
        Me.Cb_JornadaHabitual.TabIndex = 103
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(278, 168)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(129, 13)
        Me.Label24.TabIndex = 102
        Me.Label24.Text = "Jornada Trabajo Habitual:"
        '
        'Tb_Salario
        '
        Me.Tb_Salario.Location = New System.Drawing.Point(111, 164)
        Me.Tb_Salario.MaxLength = 18
        Me.Tb_Salario.Name = "Tb_Salario"
        Me.Tb_Salario.Size = New System.Drawing.Size(149, 20)
        Me.Tb_Salario.TabIndex = 101
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(63, 168)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(42, 13)
        Me.Label23.TabIndex = 100
        Me.Label23.Text = "Salario:"
        '
        'Cb_OcupacionHabitual
        '
        Me.Cb_OcupacionHabitual.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_OcupacionHabitual.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_OcupacionHabitual.FormattingEnabled = True
        Me.Cb_OcupacionHabitual.Location = New System.Drawing.Point(549, 135)
        Me.Cb_OcupacionHabitual.Name = "Cb_OcupacionHabitual"
        Me.Cb_OcupacionHabitual.Size = New System.Drawing.Size(270, 21)
        Me.Cb_OcupacionHabitual.TabIndex = 99
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(443, 139)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 13)
        Me.Label22.TabIndex = 98
        Me.Label22.Text = "Ocupación Habitual:"
        '
        'Cb_CargoPersonaAccidente
        '
        Me.Cb_CargoPersonaAccidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_CargoPersonaAccidente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_CargoPersonaAccidente.FormattingEnabled = True
        Me.Cb_CargoPersonaAccidente.Location = New System.Drawing.Point(111, 135)
        Me.Cb_CargoPersonaAccidente.Name = "Cb_CargoPersonaAccidente"
        Me.Cb_CargoPersonaAccidente.Size = New System.Drawing.Size(282, 21)
        Me.Cb_CargoPersonaAccidente.TabIndex = 97
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(67, 139)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 96
        Me.Label21.Text = "Cargo:"
        '
        'Tb_CorreoElectronico
        '
        Me.Tb_CorreoElectronico.Location = New System.Drawing.Point(549, 105)
        Me.Tb_CorreoElectronico.MaxLength = 60
        Me.Tb_CorreoElectronico.Name = "Tb_CorreoElectronico"
        Me.Tb_CorreoElectronico.Size = New System.Drawing.Size(271, 20)
        Me.Tb_CorreoElectronico.TabIndex = 95
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(450, 109)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(97, 13)
        Me.Label20.TabIndex = 94
        Me.Label20.Text = "Correo Electrónico:"
        '
        'Tb_TelefonoMovil
        '
        Me.Tb_TelefonoMovil.Location = New System.Drawing.Point(760, 76)
        Me.Tb_TelefonoMovil.MaxLength = 10
        Me.Tb_TelefonoMovil.Name = "Tb_TelefonoMovil"
        Me.Tb_TelefonoMovil.Size = New System.Drawing.Size(120, 20)
        Me.Tb_TelefonoMovil.TabIndex = 91
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(677, 80)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 13)
        Me.Label19.TabIndex = 90
        Me.Label19.Text = "Teléfono Movil:"
        '
        'Tb_Telefono
        '
        Me.Tb_Telefono.Location = New System.Drawing.Point(549, 76)
        Me.Tb_Telefono.MaxLength = 10
        Me.Tb_Telefono.Name = "Tb_Telefono"
        Me.Tb_Telefono.Size = New System.Drawing.Size(125, 20)
        Me.Tb_Telefono.TabIndex = 89
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(495, 80)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 88
        Me.Label18.Text = "Teléfono:"
        '
        'Tb_Direccion
        '
        Me.Tb_Direccion.Location = New System.Drawing.Point(111, 76)
        Me.Tb_Direccion.MaxLength = 150
        Me.Tb_Direccion.Name = "Tb_Direccion"
        Me.Tb_Direccion.Size = New System.Drawing.Size(378, 20)
        Me.Tb_Direccion.TabIndex = 87
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(50, 80)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 13)
        Me.Label17.TabIndex = 86
        Me.Label17.Text = "Dirección:"
        '
        'Cu_AsociarPersonaAfectada
        '
        Me.Cu_AsociarPersonaAfectada.componenteasociado = Nothing
        Me.Cu_AsociarPersonaAfectada.CrearUsuario = False
        Me.Cu_AsociarPersonaAfectada.Location = New System.Drawing.Point(642, 20)
        Me.Cu_AsociarPersonaAfectada.Name = "Cu_AsociarPersonaAfectada"
        Me.Cu_AsociarPersonaAfectada.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaAfectada.TabIndex = 75
        Me.Cu_AsociarPersonaAfectada.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaAfectada.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaAfectada
        '
        Me.Cu_BuscarPersonaAfectada.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAfectada.Location = New System.Drawing.Point(375, 19)
        Me.Cu_BuscarPersonaAfectada.Name = "Cu_BuscarPersonaAfectada"
        Me.Cu_BuscarPersonaAfectada.Size = New System.Drawing.Size(271, 23)
        Me.Cu_BuscarPersonaAfectada.TabIndex = 74
        Me.Cu_BuscarPersonaAfectada.Tipo = "PABO"
        Me.Cu_BuscarPersonaAfectada.valorcajatexto = "IDENTIFICACION"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(265, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(110, 13)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Nombre del Afectado:"
        '
        'Cb_TipoVinculacion
        '
        Me.Cb_TipoVinculacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoVinculacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoVinculacion.FormattingEnabled = True
        Me.Cb_TipoVinculacion.Items.AddRange(New Object() {"Empleador", "Contratante", "Cooperativa Trabajo Asociado"})
        Me.Cb_TipoVinculacion.Location = New System.Drawing.Point(111, 19)
        Me.Cb_TipoVinculacion.Name = "Cb_TipoVinculacion"
        Me.Cb_TipoVinculacion.Size = New System.Drawing.Size(147, 21)
        Me.Cb_TipoVinculacion.TabIndex = 72
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 13)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "Tipo de Vinculación:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Dgv_Testigos)
        Me.TabPage3.Controls.Add(Me.Pn_tituloConceptos)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(906, 525)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Testigos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Dgv_Testigos
        '
        Me.Dgv_Testigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Testigos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cedula, Me.Nombre, Me.DGVCB_Cargo})
        Me.Dgv_Testigos.Location = New System.Drawing.Point(3, 28)
        Me.Dgv_Testigos.Name = "Dgv_Testigos"
        Me.Dgv_Testigos.Size = New System.Drawing.Size(900, 524)
        Me.Dgv_Testigos.TabIndex = 147
        '
        'Cedula
        '
        Me.Cedula.DataPropertyName = "Cedula"
        Me.Cedula.HeaderText = "Cedula"
        Me.Cedula.Name = "Cedula"
        Me.Cedula.Width = 105
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 450
        '
        'DGVCB_Cargo
        '
        Me.DGVCB_Cargo.DataPropertyName = "Cargo"
        Me.DGVCB_Cargo.HeaderText = "Cargo"
        Me.DGVCB_Cargo.Name = "DGVCB_Cargo"
        Me.DGVCB_Cargo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVCB_Cargo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVCB_Cargo.Width = 300
        '
        'Pn_tituloConceptos
        '
        Me.Pn_tituloConceptos.BackColor = System.Drawing.Color.Gainsboro
        Me.Pn_tituloConceptos.Controls.Add(Me.Bt_Agregar)
        Me.Pn_tituloConceptos.Controls.Add(Me.Label48)
        Me.Pn_tituloConceptos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_tituloConceptos.Location = New System.Drawing.Point(3, 3)
        Me.Pn_tituloConceptos.Name = "Pn_tituloConceptos"
        Me.Pn_tituloConceptos.Size = New System.Drawing.Size(900, 25)
        Me.Pn_tituloConceptos.TabIndex = 1
        '
        'Bt_Agregar
        '
        Me.Bt_Agregar.Location = New System.Drawing.Point(78, 2)
        Me.Bt_Agregar.Name = "Bt_Agregar"
        Me.Bt_Agregar.Size = New System.Drawing.Size(60, 21)
        Me.Bt_Agregar.TabIndex = 146
        Me.Bt_Agregar.Text = "Agregar"
        Me.Bt_Agregar.UseVisualStyleBackColor = True
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
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(826, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 149
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(745, 4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 148
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.Color.Silver
        Me.Pn_Botones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Pn_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 553)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(914, 34)
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
        'Fr_CrearReporte24H
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 587)
        Me.Controls.Add(Me.Pn_Botones)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximumSize = New System.Drawing.Size(930, 626)
        Me.MinimumSize = New System.Drawing.Size(930, 626)
        Me.Name = "Fr_CrearReporte24H"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Incidente"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.Gb_TipoAccidente.ResumeLayout(False)
        Me.Gb_TipoAccidente.PerformLayout()
        Me.Gb_CausoMuerte.ResumeLayout(False)
        Me.Gb_CausoMuerte.PerformLayout()
        Me.Gb_Testigos.ResumeLayout(False)
        Me.Gb_Testigos.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox_Genero.ResumeLayout(False)
        Me.GroupBox_Genero.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Dgv_Testigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_tituloConceptos.ResumeLayout(False)
        Me.Pn_tituloConceptos.PerformLayout()
        Me.Pn_Botones.ResumeLayout(False)
        Me.Cms_EliminarFila.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Tb_SitioIncidente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Tx_Empleador As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Empleador As System.Windows.Forms.Label
    Friend WithEvents Ck_Empleador As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cb_Area As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Cb_CargoReporta As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaReporte As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Tb_Telefono As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Tb_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaAfectada As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaAfectada As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoVinculacion As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_OcupacionHabitual As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Cb_CargoPersonaAccidente As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Tb_CorreoElectronico As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Tb_TelefonoMovil As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Cb_JornadaIncidente As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Cb_JornadaHabitual As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Tb_Salario As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Tx_TrabajoHabitual As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TrabajoHabitual As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Rb_MuerteSi As System.Windows.Forms.RadioButton
    Friend WithEvents Tb_OtroSitioIncidente As System.Windows.Forms.TextBox
    Friend WithEvents Lb_SitioIncidente As System.Windows.Forms.Label
    Friend WithEvents Cb_SitioIncidente As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Rb_MuerteNo As System.Windows.Forms.RadioButton
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
    Friend WithEvents Tb_DiagnosticoLesion As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_EvitadoAccidente As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Cb_Recurrencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Cb_Severidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Lb_DirectorResidente As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaBodegaMedicoEnfermero As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaBodegaCoordinadorHSE As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaBodegaResponsableActividad As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaBodegaDirectorObra As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaMedicoEnfermero As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BuscarPersonaCoordinadorHSE As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BuscarPersonaResponsableActividad As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BuscarPersonaDirectorObra As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Tb_OtrosAnexos As System.Windows.Forms.TextBox
    Friend WithEvents Lb_OtrosAnexos As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_TestigosNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_TestigosSi As System.Windows.Forms.RadioButton
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Tb_Traslado As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Trasladado As System.Windows.Forms.Label
    Friend WithEvents Cb_AtencionInmediata As System.Windows.Forms.ComboBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Pn_tituloConceptos As System.Windows.Forms.Panel
    Friend WithEvents Bt_Agregar As System.Windows.Forms.Button
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Dgv_Testigos As System.Windows.Forms.DataGridView
    Friend WithEvents Cb_AFP As System.Windows.Forms.ComboBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Cb_EPS As System.Windows.Forms.ComboBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
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
    Friend WithEvents Ck_AnexoDibujos As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_OtrosAnexos As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_AnexoInformesMedicos As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_AnexoFotos As System.Windows.Forms.CheckBox
    Friend WithEvents DTP_FechaNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_Genero As System.Windows.Forms.GroupBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Rb_Femenino As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Masculino As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_TrabajoHabitualNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_TrabajoHabitualSi As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    'Friend WithEvents Bt_VerMatriz As System.Windows.Forms.Button
    Friend WithEvents Tb_CategoriaResultante As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CategoriaResultante As System.Windows.Forms.Label
    Friend WithEvents Cedula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVCB_Cargo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Tb_AccionInmediata3 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_AccionInmediata3 As System.Windows.Forms.Label
    Friend WithEvents Tb_AccionInmediata2 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_AccionInmediata2 As System.Windows.Forms.Label
    Friend WithEvents Tb_AccionInmediata1 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_AccionInmediata1 As System.Windows.Forms.Label
    Friend WithEvents Cb_Contrato As System.Windows.Forms.ComboBox
    Friend WithEvents Gb_TipoAccidente As System.Windows.Forms.GroupBox
    Friend WithEvents Gb_CausoMuerte As System.Windows.Forms.GroupBox
    Friend WithEvents Gb_Testigos As System.Windows.Forms.GroupBox
    Friend WithEvents Lb_TipoAccidente As System.Windows.Forms.Label
    Friend WithEvents Rb_PropioTrabajo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Recreativo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Deportivo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Transito As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Violencia As System.Windows.Forms.RadioButton
    Friend WithEvents Lb_CiudadResidencia As System.Windows.Forms.Label
    Friend WithEvents Cu_CiudadPersonaAfectada As FormulariosClasesBase.Cu_Ciudad

End Class
