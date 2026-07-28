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
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaBodega4 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaBodega3 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaBodega2 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaBodega1 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaValida4 = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaValida2 = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaValida3 = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaValida1 = New FormulariosClasesBase.Cu_BuscarPersona()
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
        Me.Dgv_AccionesInmediatas = New System.Windows.Forms.DataGridView()
        Me.DGVT_AccionesInmediatas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_CedulaAcciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_NombreAcciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Tb_Contrato = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
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
        Me.Rb_TestigosNo = New System.Windows.Forms.RadioButton()
        Me.Tb_OtroSitioIncidente = New System.Windows.Forms.TextBox()
        Me.Cb_MecanismoAccidente = New System.Windows.Forms.ComboBox()
        Me.Lb_SitioIncidente = New System.Windows.Forms.Label()
        Me.Tx_TrabajoHabitual = New System.Windows.Forms.TextBox()
        Me.Cb_SitioIncidente = New System.Windows.Forms.ComboBox()
        Me.Lb_TrabajoHabitual = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Rb_TestigosSi = New System.Windows.Forms.RadioButton()
        Me.Cb_JornadaIncidente = New System.Windows.Forms.ComboBox()
        Me.Tb_OtroAgenteAccidente = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Tb_DiagnosticoLesion = New System.Windows.Forms.TextBox()
        Me.Lb_AgenteAccidente = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
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
        Me.Rb_MuerteNo = New System.Windows.Forms.RadioButton()
        Me.Rb_MuerteSi = New System.Windows.Forms.RadioButton()
        Me.Label29 = New System.Windows.Forms.Label()
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
        CType(Me.Dgv_AccionesInmediatas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
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
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(914, 578)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
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
        Me.TabPage1.Controls.Add(Me.Label55)
        Me.TabPage1.Controls.Add(Me.Cu_AsociarPersonaBodega4)
        Me.TabPage1.Controls.Add(Me.Cu_AsociarPersonaBodega3)
        Me.TabPage1.Controls.Add(Me.Cu_AsociarPersonaBodega2)
        Me.TabPage1.Controls.Add(Me.Cu_AsociarPersonaBodega1)
        Me.TabPage1.Controls.Add(Me.Cu_BuscarPersonaValida4)
        Me.TabPage1.Controls.Add(Me.Cu_BuscarPersonaValida2)
        Me.TabPage1.Controls.Add(Me.Cu_BuscarPersonaValida3)
        Me.TabPage1.Controls.Add(Me.Cu_BuscarPersonaValida1)
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
        Me.TabPage1.Controls.Add(Me.Tb_Contrato)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(906, 552)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Información General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Cb_ActividadPrincipal
        '
        Me.Cb_ActividadPrincipal.FormattingEnabled = True
        Me.Cb_ActividadPrincipal.Location = New System.Drawing.Point(716, 42)
        Me.Cb_ActividadPrincipal.Name = "Cb_ActividadPrincipal"
        Me.Cb_ActividadPrincipal.Size = New System.Drawing.Size(184, 21)
        Me.Cb_ActividadPrincipal.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(620, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Actividad Principal"
        '
        'Cu_CiudadIncidente
        '
        Me.Cu_CiudadIncidente.Location = New System.Drawing.Point(616, 79)
        Me.Cu_CiudadIncidente.Name = "Cu_CiudadIncidente"
        Me.Cu_CiudadIncidente.Size = New System.Drawing.Size(283, 23)
        Me.Cu_CiudadIncidente.TabIndex = 21
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label32)
        Me.GroupBox8.Controls.Add(Me.Rb_LugarDentroEmpresa)
        Me.GroupBox8.Controls.Add(Me.Rb_LugarFueraEmpresa)
        Me.GroupBox8.Location = New System.Drawing.Point(19, 105)
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
        Me.Label30.Location = New System.Drawing.Point(562, 82)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(52, 13)
        Me.Label30.TabIndex = 111
        Me.Label30.Text = "Municipio"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Rb_ZonaUrbana)
        Me.GroupBox7.Controls.Add(Me.Rb_ZonaRural)
        Me.GroupBox7.Controls.Add(Me.Label31)
        Me.GroupBox7.Location = New System.Drawing.Point(315, 70)
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
        Me.DTP_HorasLaboradas.Location = New System.Drawing.Point(327, 149)
        Me.DTP_HorasLaboradas.Name = "DTP_HorasLaboradas"
        Me.DTP_HorasLaboradas.ShowCheckBox = True
        Me.DTP_HorasLaboradas.ShowUpDown = True
        Me.DTP_HorasLaboradas.Size = New System.Drawing.Size(93, 20)
        Me.DTP_HorasLaboradas.TabIndex = 31
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(220, 153)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(101, 13)
        Me.Label47.TabIndex = 30
        Me.Label47.Text = "Horas laboradas dia"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(433, 518)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(66, 13)
        Me.Label58.TabIndex = 67
        Me.Label58.Text = "Validado por"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(433, 485)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(66, 13)
        Me.Label57.TabIndex = 61
        Me.Label57.Text = "Validado por"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(16, 518)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(66, 13)
        Me.Label56.TabIndex = 64
        Me.Label56.Text = "Validado por"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(16, 485)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(66, 13)
        Me.Label55.TabIndex = 58
        Me.Label55.Text = "Validado por"
        '
        'Cu_AsociarPersonaBodega4
        '
        Me.Cu_AsociarPersonaBodega4.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodega4.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega4.Location = New System.Drawing.Point(830, 512)
        Me.Cu_AsociarPersonaBodega4.Name = "Cu_AsociarPersonaBodega4"
        Me.Cu_AsociarPersonaBodega4.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega4.TabIndex = 69
        Me.Cu_AsociarPersonaBodega4.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodega4.TipoBúsqueda = "P"
        '
        'Cu_AsociarPersonaBodega3
        '
        Me.Cu_AsociarPersonaBodega3.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodega3.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega3.Location = New System.Drawing.Point(830, 478)
        Me.Cu_AsociarPersonaBodega3.Name = "Cu_AsociarPersonaBodega3"
        Me.Cu_AsociarPersonaBodega3.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega3.TabIndex = 63
        Me.Cu_AsociarPersonaBodega3.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodega3.TipoBúsqueda = "P"
        '
        'Cu_AsociarPersonaBodega2
        '
        Me.Cu_AsociarPersonaBodega2.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodega2.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega2.Location = New System.Drawing.Point(376, 512)
        Me.Cu_AsociarPersonaBodega2.Name = "Cu_AsociarPersonaBodega2"
        Me.Cu_AsociarPersonaBodega2.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega2.TabIndex = 66
        Me.Cu_AsociarPersonaBodega2.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodega2.TipoBúsqueda = "P"
        '
        'Cu_AsociarPersonaBodega1
        '
        Me.Cu_AsociarPersonaBodega1.componenteasociado = Nothing
        Me.Cu_AsociarPersonaBodega1.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega1.Location = New System.Drawing.Point(376, 478)
        Me.Cu_AsociarPersonaBodega1.Name = "Cu_AsociarPersonaBodega1"
        Me.Cu_AsociarPersonaBodega1.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega1.TabIndex = 60
        Me.Cu_AsociarPersonaBodega1.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodega1.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaValida4
        '
        Me.Cu_BuscarPersonaValida4.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaValida4.Location = New System.Drawing.Point(563, 512)
        Me.Cu_BuscarPersonaValida4.Name = "Cu_BuscarPersonaValida4"
        Me.Cu_BuscarPersonaValida4.Size = New System.Drawing.Size(265, 23)
        Me.Cu_BuscarPersonaValida4.TabIndex = 68
        Me.Cu_BuscarPersonaValida4.Tipo = "PABO"
        Me.Cu_BuscarPersonaValida4.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaValida2
        '
        Me.Cu_BuscarPersonaValida2.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaValida2.Location = New System.Drawing.Point(563, 478)
        Me.Cu_BuscarPersonaValida2.Name = "Cu_BuscarPersonaValida2"
        Me.Cu_BuscarPersonaValida2.Size = New System.Drawing.Size(265, 23)
        Me.Cu_BuscarPersonaValida2.TabIndex = 62
        Me.Cu_BuscarPersonaValida2.Tipo = "PABO"
        Me.Cu_BuscarPersonaValida2.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaValida3
        '
        Me.Cu_BuscarPersonaValida3.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaValida3.Location = New System.Drawing.Point(111, 512)
        Me.Cu_BuscarPersonaValida3.Name = "Cu_BuscarPersonaValida3"
        Me.Cu_BuscarPersonaValida3.Size = New System.Drawing.Size(265, 23)
        Me.Cu_BuscarPersonaValida3.TabIndex = 65
        Me.Cu_BuscarPersonaValida3.Tipo = "PABO"
        Me.Cu_BuscarPersonaValida3.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaValida1
        '
        Me.Cu_BuscarPersonaValida1.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaValida1.Location = New System.Drawing.Point(111, 478)
        Me.Cu_BuscarPersonaValida1.Name = "Cu_BuscarPersonaValida1"
        Me.Cu_BuscarPersonaValida1.Size = New System.Drawing.Size(265, 23)
        Me.Cu_BuscarPersonaValida1.TabIndex = 59
        Me.Cu_BuscarPersonaValida1.Tipo = "PABO"
        Me.Cu_BuscarPersonaValida1.valorcajatexto = "IDENTIFICACION"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Ck_OtrosAnexos)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoInformesMedicos)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoFotos)
        Me.GroupBox5.Controls.Add(Me.Ck_AnexoDibujos)
        Me.GroupBox5.Controls.Add(Me.Tb_OtrosAnexos)
        Me.GroupBox5.Controls.Add(Me.Lb_OtrosAnexos)
        Me.GroupBox5.Location = New System.Drawing.Point(468, 353)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(424, 78)
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
        Me.Tb_OtrosAnexos.Location = New System.Drawing.Point(61, 47)
        Me.Tb_OtrosAnexos.MaxLength = 30
        Me.Tb_OtrosAnexos.Name = "Tb_OtrosAnexos"
        Me.Tb_OtrosAnexos.Size = New System.Drawing.Size(252, 20)
        Me.Tb_OtrosAnexos.TabIndex = 52
        '
        'Lb_OtrosAnexos
        '
        Me.Lb_OtrosAnexos.AutoSize = True
        Me.Lb_OtrosAnexos.Location = New System.Drawing.Point(9, 50)
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
        Me.GroupBox4.Location = New System.Drawing.Point(468, 180)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(431, 167)
        Me.GroupBox4.TabIndex = 34
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Perdida Potencial"
        '
        'Tb_CategoriaResultante
        '
        Me.Tb_CategoriaResultante.Enabled = False
        Me.Tb_CategoriaResultante.Location = New System.Drawing.Point(120, 19)
        Me.Tb_CategoriaResultante.Name = "Tb_CategoriaResultante"
        Me.Tb_CategoriaResultante.Size = New System.Drawing.Size(114, 20)
        Me.Tb_CategoriaResultante.TabIndex = 37
        '
        'Lb_CategoriaResultante
        '
        Me.Lb_CategoriaResultante.AutoSize = True
        Me.Lb_CategoriaResultante.Location = New System.Drawing.Point(14, 24)
        Me.Lb_CategoriaResultante.Name = "Lb_CategoriaResultante"
        Me.Lb_CategoriaResultante.Size = New System.Drawing.Size(101, 13)
        Me.Lb_CategoriaResultante.TabIndex = 36
        Me.Lb_CategoriaResultante.Text = "Categoria resultante"
        '
        'Tb_EvitadoAccidente
        '
        Me.Tb_EvitadoAccidente.Location = New System.Drawing.Point(17, 108)
        Me.Tb_EvitadoAccidente.MaxLength = 350
        Me.Tb_EvitadoAccidente.Multiline = True
        Me.Tb_EvitadoAccidente.Name = "Tb_EvitadoAccidente"
        Me.Tb_EvitadoAccidente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tb_EvitadoAccidente.Size = New System.Drawing.Size(405, 48)
        Me.Tb_EvitadoAccidente.TabIndex = 43
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(14, 81)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(209, 13)
        Me.Label52.TabIndex = 42
        Me.Label52.Text = "¿Como pudo haberse evitado el incidente?"
        '
        'Cb_Recurrencia
        '
        Me.Cb_Recurrencia.FormattingEnabled = True
        Me.Cb_Recurrencia.Items.AddRange(New Object() {"Uno en 3 años", "Uno en 2 años", "Uno en 1 año"})
        Me.Cb_Recurrencia.Location = New System.Drawing.Point(295, 51)
        Me.Cb_Recurrencia.Name = "Cb_Recurrencia"
        Me.Cb_Recurrencia.Size = New System.Drawing.Size(127, 21)
        Me.Cb_Recurrencia.TabIndex = 41
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(229, 56)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(65, 13)
        Me.Label50.TabIndex = 40
        Me.Label50.Text = "Recurrencia"
        '
        'Cb_Severidad
        '
        Me.Cb_Severidad.FormattingEnabled = True
        Me.Cb_Severidad.Location = New System.Drawing.Point(75, 51)
        Me.Cb_Severidad.Name = "Cb_Severidad"
        Me.Cb_Severidad.Size = New System.Drawing.Size(148, 21)
        Me.Cb_Severidad.TabIndex = 39
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(14, 56)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(55, 13)
        Me.Label51.TabIndex = 38
        Me.Label51.Text = "Severidad"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Dgv_AccionesInmediatas)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 267)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 164)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Acciones Inmediatas"
        '
        'Dgv_AccionesInmediatas
        '
        Me.Dgv_AccionesInmediatas.AllowUserToAddRows = False
        Me.Dgv_AccionesInmediatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_AccionesInmediatas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVT_AccionesInmediatas, Me.DGVT_CedulaAcciones, Me.DGVT_NombreAcciones})
        Me.Dgv_AccionesInmediatas.Location = New System.Drawing.Point(9, 19)
        Me.Dgv_AccionesInmediatas.Name = "Dgv_AccionesInmediatas"
        Me.Dgv_AccionesInmediatas.Size = New System.Drawing.Size(414, 131)
        Me.Dgv_AccionesInmediatas.TabIndex = 45
        '
        'DGVT_AccionesInmediatas
        '
        Me.DGVT_AccionesInmediatas.DataPropertyName = "ACCION"
        Me.DGVT_AccionesInmediatas.HeaderText = "Acciones Inmediatas"
        Me.DGVT_AccionesInmediatas.MaxInputLength = 50
        Me.DGVT_AccionesInmediatas.Name = "DGVT_AccionesInmediatas"
        Me.DGVT_AccionesInmediatas.Width = 200
        '
        'DGVT_CedulaAcciones
        '
        Me.DGVT_CedulaAcciones.DataPropertyName = "CEDULA"
        Me.DGVT_CedulaAcciones.HeaderText = "Cedula"
        Me.DGVT_CedulaAcciones.MaxInputLength = 15
        Me.DGVT_CedulaAcciones.Name = "DGVT_CedulaAcciones"
        '
        'DGVT_NombreAcciones
        '
        Me.DGVT_NombreAcciones.DataPropertyName = "NOMBRE"
        Me.DGVT_NombreAcciones.HeaderText = "Nombre"
        Me.DGVT_NombreAcciones.Name = "DGVT_NombreAcciones"
        Me.DGVT_NombreAcciones.Width = 150
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tb_Descripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 181)
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
        Me.Cb_CargoReporta.FormattingEnabled = True
        Me.Cb_CargoReporta.Location = New System.Drawing.Point(563, 442)
        Me.Cb_CargoReporta.Name = "Cb_CargoReporta"
        Me.Cb_CargoReporta.Size = New System.Drawing.Size(266, 21)
        Me.Cb_CargoReporta.TabIndex = 57
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(437, 450)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 13)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "Cargo de quien reporta"
        '
        'Cu_AsociarPersonaReporte
        '
        Me.Cu_AsociarPersonaReporte.componenteasociado = Nothing
        Me.Cu_AsociarPersonaReporte.CrearUsuario = False
        Me.Cu_AsociarPersonaReporte.Location = New System.Drawing.Point(376, 446)
        Me.Cu_AsociarPersonaReporte.Name = "Cu_AsociarPersonaReporte"
        Me.Cu_AsociarPersonaReporte.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaReporte.TabIndex = 55
        Me.Cu_AsociarPersonaReporte.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaReporte.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaReporta
        '
        Me.Cu_BuscarPersonaReporta.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaReporta.Location = New System.Drawing.Point(111, 446)
        Me.Cu_BuscarPersonaReporta.Name = "Cu_BuscarPersonaReporta"
        Me.Cu_BuscarPersonaReporta.Size = New System.Drawing.Size(265, 23)
        Me.Cu_BuscarPersonaReporta.TabIndex = 54
        Me.Cu_BuscarPersonaReporta.Tipo = "PABO"
        Me.Cu_BuscarPersonaReporta.valorcajatexto = "IDENTIFICACION"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 450)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "Reportado por"
        '
        'DTP_HoraIncidente
        '
        Me.DTP_HoraIncidente.Checked = False
        Me.DTP_HoraIncidente.CustomFormat = "hh:mm tt"
        Me.DTP_HoraIncidente.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_HoraIncidente.Location = New System.Drawing.Point(105, 150)
        Me.DTP_HoraIncidente.Name = "DTP_HoraIncidente"
        Me.DTP_HoraIncidente.ShowCheckBox = True
        Me.DTP_HoraIncidente.ShowUpDown = True
        Me.DTP_HoraIncidente.Size = New System.Drawing.Size(93, 20)
        Me.DTP_HoraIncidente.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Hora Incidente"
        '
        'DTP_FechaIncidente
        '
        Me.DTP_FechaIncidente.Checked = False
        Me.DTP_FechaIncidente.Location = New System.Drawing.Point(535, 116)
        Me.DTP_FechaIncidente.Name = "DTP_FechaIncidente"
        Me.DTP_FechaIncidente.ShowCheckBox = True
        Me.DTP_FechaIncidente.Size = New System.Drawing.Size(222, 20)
        Me.DTP_FechaIncidente.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(445, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Fecha Incidente"
        '
        'Tb_SitioIncidente
        '
        Me.Tb_SitioIncidente.Location = New System.Drawing.Point(96, 79)
        Me.Tb_SitioIncidente.MaxLength = 50
        Me.Tb_SitioIncidente.Name = "Tb_SitioIncidente"
        Me.Tb_SitioIncidente.Size = New System.Drawing.Size(210, 20)
        Me.Tb_SitioIncidente.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Sitio Incidente"
        '
        'Tx_Empleador
        '
        Me.Tx_Empleador.Location = New System.Drawing.Point(480, 42)
        Me.Tx_Empleador.MaxLength = 50
        Me.Tx_Empleador.Name = "Tx_Empleador"
        Me.Tx_Empleador.Size = New System.Drawing.Size(136, 20)
        Me.Tx_Empleador.TabIndex = 13
        '
        'Lb_Empleador
        '
        Me.Lb_Empleador.AutoSize = True
        Me.Lb_Empleador.Location = New System.Drawing.Point(355, 47)
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
        Me.Ck_Empleador.Location = New System.Drawing.Point(337, 47)
        Me.Ck_Empleador.Name = "Ck_Empleador"
        Me.Ck_Empleador.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Empleador.TabIndex = 11
        Me.Ck_Empleador.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(203, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "¿El empleador es Ismocol?"
        '
        'Cb_Area
        '
        Me.Cb_Area.FormattingEnabled = True
        Me.Cb_Area.Location = New System.Drawing.Point(62, 42)
        Me.Cb_Area.Name = "Cb_Area"
        Me.Cb_Area.Size = New System.Drawing.Size(128, 21)
        Me.Cb_Area.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Area"
        '
        'Cb_TipoConsecuencia
        '
        Me.Cb_TipoConsecuencia.FormattingEnabled = True
        Me.Cb_TipoConsecuencia.Location = New System.Drawing.Point(703, 9)
        Me.Cb_TipoConsecuencia.Name = "Cb_TipoConsecuencia"
        Me.Cb_TipoConsecuencia.Size = New System.Drawing.Size(140, 21)
        Me.Cb_TipoConsecuencia.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(625, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Consecuencia"
        '
        'Cb_TipoIncidente
        '
        Me.Cb_TipoIncidente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Cb_TipoIncidente.FormattingEnabled = True
        Me.Cb_TipoIncidente.Location = New System.Drawing.Point(533, 9)
        Me.Cb_TipoIncidente.Name = "Cb_TipoIncidente"
        Me.Cb_TipoIncidente.Size = New System.Drawing.Size(77, 21)
        Me.Cb_TipoIncidente.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(437, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tipo de Incidente"
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
        Me.Label2.Location = New System.Drawing.Point(203, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proyecto"
        '
        'Tb_Contrato
        '
        Me.Tb_Contrato.Location = New System.Drawing.Point(89, 9)
        Me.Tb_Contrato.MaxLength = 12
        Me.Tb_Contrato.Name = "Tb_Contrato"
        Me.Tb_Contrato.Size = New System.Drawing.Size(101, 20)
        Me.Tb_Contrato.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Contrato No."
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(906, 552)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Información del afectado"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.GroupBox11)
        Me.GroupBox6.Controls.Add(Me.Tb_OtraParteAfectada)
        Me.GroupBox6.Controls.Add(Me.Lb_ParteAfectada)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroTipoLesion)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroMecanismoAccidente)
        Me.GroupBox6.Controls.Add(Me.Lb_TipoLesion)
        Me.GroupBox6.Controls.Add(Me.Cb_TipoLesion)
        Me.GroupBox6.Controls.Add(Me.Lb_Mecanismo)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.Rb_TestigosNo)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroSitioIncidente)
        Me.GroupBox6.Controls.Add(Me.Cb_MecanismoAccidente)
        Me.GroupBox6.Controls.Add(Me.Lb_SitioIncidente)
        Me.GroupBox6.Controls.Add(Me.Tx_TrabajoHabitual)
        Me.GroupBox6.Controls.Add(Me.Cb_SitioIncidente)
        Me.GroupBox6.Controls.Add(Me.Lb_TrabajoHabitual)
        Me.GroupBox6.Controls.Add(Me.Label41)
        Me.GroupBox6.Controls.Add(Me.Label33)
        Me.GroupBox6.Controls.Add(Me.Rb_TestigosSi)
        Me.GroupBox6.Controls.Add(Me.Cb_JornadaIncidente)
        Me.GroupBox6.Controls.Add(Me.Tb_OtroAgenteAccidente)
        Me.GroupBox6.Controls.Add(Me.Label25)
        Me.GroupBox6.Controls.Add(Me.Tb_DiagnosticoLesion)
        Me.GroupBox6.Controls.Add(Me.Lb_AgenteAccidente)
        Me.GroupBox6.Controls.Add(Me.Label46)
        Me.GroupBox6.Controls.Add(Me.Cb_AgenteAccidente)
        Me.GroupBox6.Controls.Add(Me.Label42)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.Tb_Traslado)
        Me.GroupBox6.Controls.Add(Me.Cb_ParteAfectada)
        Me.GroupBox6.Controls.Add(Me.Lb_Trasladado)
        Me.GroupBox6.Controls.Add(Me.Label37)
        Me.GroupBox6.Controls.Add(Me.Cb_AtencionInmediata)
        Me.GroupBox6.Controls.Add(Me.Label44)
        Me.GroupBox6.Location = New System.Drawing.Point(15, 271)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(874, 278)
        Me.GroupBox6.TabIndex = 107
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Información sobre el accidente"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Rb_TrabajoHabitualNo)
        Me.GroupBox11.Controls.Add(Me.Rb_TrabajoHabitualSi)
        Me.GroupBox11.Controls.Add(Me.Label15)
        Me.GroupBox11.Location = New System.Drawing.Point(265, 13)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(303, 39)
        Me.GroupBox11.TabIndex = 110
        Me.GroupBox11.TabStop = False
        '
        'Rb_TrabajoHabitualNo
        '
        Me.Rb_TrabajoHabitualNo.AutoSize = True
        Me.Rb_TrabajoHabitualNo.Location = New System.Drawing.Point(253, 14)
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
        Me.Rb_TrabajoHabitualSi.Location = New System.Drawing.Point(213, 14)
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
        Me.Label15.Location = New System.Drawing.Point(4, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(203, 13)
        Me.Label15.TabIndex = 111
        Me.Label15.Text = "¿Estaba Realizando su Trabajo Habitual?"
        '
        'Tb_OtraParteAfectada
        '
        Me.Tb_OtraParteAfectada.Location = New System.Drawing.Point(313, 117)
        Me.Tb_OtraParteAfectada.MaxLength = 30
        Me.Tb_OtraParteAfectada.Name = "Tb_OtraParteAfectada"
        Me.Tb_OtraParteAfectada.Size = New System.Drawing.Size(189, 20)
        Me.Tb_OtraParteAfectada.TabIndex = 127
        '
        'Lb_ParteAfectada
        '
        Me.Lb_ParteAfectada.AutoSize = True
        Me.Lb_ParteAfectada.Location = New System.Drawing.Point(270, 122)
        Me.Lb_ParteAfectada.Name = "Lb_ParteAfectada"
        Me.Lb_ParteAfectada.Size = New System.Drawing.Size(40, 13)
        Me.Lb_ParteAfectada.TabIndex = 126
        Me.Lb_ParteAfectada.Text = "¿Cual?"
        '
        'Tb_OtroTipoLesion
        '
        Me.Tb_OtroTipoLesion.Location = New System.Drawing.Point(249, 87)
        Me.Tb_OtroTipoLesion.MaxLength = 30
        Me.Tb_OtroTipoLesion.Name = "Tb_OtroTipoLesion"
        Me.Tb_OtroTipoLesion.Size = New System.Drawing.Size(189, 20)
        Me.Tb_OtroTipoLesion.TabIndex = 123
        '
        'Tb_OtroMecanismoAccidente
        '
        Me.Tb_OtroMecanismoAccidente.Location = New System.Drawing.Point(306, 183)
        Me.Tb_OtroMecanismoAccidente.MaxLength = 30
        Me.Tb_OtroMecanismoAccidente.Name = "Tb_OtroMecanismoAccidente"
        Me.Tb_OtroMecanismoAccidente.Size = New System.Drawing.Size(189, 20)
        Me.Tb_OtroMecanismoAccidente.TabIndex = 136
        '
        'Lb_TipoLesion
        '
        Me.Lb_TipoLesion.AutoSize = True
        Me.Lb_TipoLesion.Location = New System.Drawing.Point(206, 92)
        Me.Lb_TipoLesion.Name = "Lb_TipoLesion"
        Me.Lb_TipoLesion.Size = New System.Drawing.Size(40, 13)
        Me.Lb_TipoLesion.TabIndex = 122
        Me.Lb_TipoLesion.Text = "¿Cual?"
        '
        'Cb_TipoLesion
        '
        Me.Cb_TipoLesion.FormattingEnabled = True
        Me.Cb_TipoLesion.Location = New System.Drawing.Point(72, 87)
        Me.Cb_TipoLesion.Name = "Cb_TipoLesion"
        Me.Cb_TipoLesion.Size = New System.Drawing.Size(121, 21)
        Me.Cb_TipoLesion.TabIndex = 121
        '
        'Lb_Mecanismo
        '
        Me.Lb_Mecanismo.AutoSize = True
        Me.Lb_Mecanismo.Location = New System.Drawing.Point(263, 188)
        Me.Lb_Mecanismo.Name = "Lb_Mecanismo"
        Me.Lb_Mecanismo.Size = New System.Drawing.Size(40, 13)
        Me.Lb_Mecanismo.TabIndex = 135
        Me.Lb_Mecanismo.Text = "¿Cual?"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(7, 92)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(62, 13)
        Me.Label36.TabIndex = 120
        Me.Label36.Text = "Tipo Lesion"
        '
        'Rb_TestigosNo
        '
        Me.Rb_TestigosNo.AutoSize = True
        Me.Rb_TestigosNo.Location = New System.Drawing.Point(698, 253)
        Me.Rb_TestigosNo.Name = "Rb_TestigosNo"
        Me.Rb_TestigosNo.Size = New System.Drawing.Size(39, 17)
        Me.Rb_TestigosNo.TabIndex = 145
        Me.Rb_TestigosNo.TabStop = True
        Me.Rb_TestigosNo.Text = "No"
        Me.Rb_TestigosNo.UseVisualStyleBackColor = True
        '
        'Tb_OtroSitioIncidente
        '
        Me.Tb_OtroSitioIncidente.Location = New System.Drawing.Point(258, 56)
        Me.Tb_OtroSitioIncidente.MaxLength = 30
        Me.Tb_OtroSitioIncidente.Name = "Tb_OtroSitioIncidente"
        Me.Tb_OtroSitioIncidente.Size = New System.Drawing.Size(149, 20)
        Me.Tb_OtroSitioIncidente.TabIndex = 119
        '
        'Cb_MecanismoAccidente
        '
        Me.Cb_MecanismoAccidente.FormattingEnabled = True
        Me.Cb_MecanismoAccidente.Location = New System.Drawing.Point(138, 183)
        Me.Cb_MecanismoAccidente.Name = "Cb_MecanismoAccidente"
        Me.Cb_MecanismoAccidente.Size = New System.Drawing.Size(121, 21)
        Me.Cb_MecanismoAccidente.TabIndex = 133
        '
        'Lb_SitioIncidente
        '
        Me.Lb_SitioIncidente.AutoSize = True
        Me.Lb_SitioIncidente.Location = New System.Drawing.Point(215, 61)
        Me.Lb_SitioIncidente.Name = "Lb_SitioIncidente"
        Me.Lb_SitioIncidente.Size = New System.Drawing.Size(40, 13)
        Me.Lb_SitioIncidente.TabIndex = 118
        Me.Lb_SitioIncidente.Text = "¿Cual?"
        '
        'Tx_TrabajoHabitual
        '
        Me.Tx_TrabajoHabitual.Location = New System.Drawing.Point(616, 25)
        Me.Tx_TrabajoHabitual.MaxLength = 30
        Me.Tx_TrabajoHabitual.Name = "Tx_TrabajoHabitual"
        Me.Tx_TrabajoHabitual.Size = New System.Drawing.Size(129, 20)
        Me.Tx_TrabajoHabitual.TabIndex = 115
        '
        'Cb_SitioIncidente
        '
        Me.Cb_SitioIncidente.FormattingEnabled = True
        Me.Cb_SitioIncidente.Location = New System.Drawing.Point(84, 56)
        Me.Cb_SitioIncidente.Name = "Cb_SitioIncidente"
        Me.Cb_SitioIncidente.Size = New System.Drawing.Size(121, 21)
        Me.Cb_SitioIncidente.TabIndex = 117
        '
        'Lb_TrabajoHabitual
        '
        Me.Lb_TrabajoHabitual.AutoSize = True
        Me.Lb_TrabajoHabitual.Location = New System.Drawing.Point(574, 29)
        Me.Lb_TrabajoHabitual.Name = "Lb_TrabajoHabitual"
        Me.Lb_TrabajoHabitual.Size = New System.Drawing.Size(40, 13)
        Me.Lb_TrabajoHabitual.TabIndex = 114
        Me.Lb_TrabajoHabitual.Text = "¿Cual?"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(6, 188)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(128, 13)
        Me.Label41.TabIndex = 132
        Me.Label41.Text = "Mecanismo del accidente"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(6, 61)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(74, 13)
        Me.Label33.TabIndex = 116
        Me.Label33.Text = "Sitio Incidente"
        '
        'Rb_TestigosSi
        '
        Me.Rb_TestigosSi.AutoSize = True
        Me.Rb_TestigosSi.Location = New System.Drawing.Point(665, 253)
        Me.Rb_TestigosSi.Name = "Rb_TestigosSi"
        Me.Rb_TestigosSi.Size = New System.Drawing.Size(34, 17)
        Me.Rb_TestigosSi.TabIndex = 144
        Me.Rb_TestigosSi.TabStop = True
        Me.Rb_TestigosSi.Text = "Si"
        Me.Rb_TestigosSi.UseVisualStyleBackColor = True
        '
        'Cb_JornadaIncidente
        '
        Me.Cb_JornadaIncidente.FormattingEnabled = True
        Me.Cb_JornadaIncidente.Items.AddRange(New Object() {"Normal", "Extra"})
        Me.Cb_JornadaIncidente.Location = New System.Drawing.Point(119, 26)
        Me.Cb_JornadaIncidente.Name = "Cb_JornadaIncidente"
        Me.Cb_JornadaIncidente.Size = New System.Drawing.Size(121, 21)
        Me.Cb_JornadaIncidente.TabIndex = 109
        '
        'Tb_OtroAgenteAccidente
        '
        Me.Tb_OtroAgenteAccidente.Location = New System.Drawing.Point(290, 151)
        Me.Tb_OtroAgenteAccidente.MaxLength = 30
        Me.Tb_OtroAgenteAccidente.Name = "Tb_OtroAgenteAccidente"
        Me.Tb_OtroAgenteAccidente.Size = New System.Drawing.Size(189, 20)
        Me.Tb_OtroAgenteAccidente.TabIndex = 131
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 29)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(109, 13)
        Me.Label25.TabIndex = 108
        Me.Label25.Text = "Jornada del Incidente"
        '
        'Tb_DiagnosticoLesion
        '
        Me.Tb_DiagnosticoLesion.Location = New System.Drawing.Point(129, 218)
        Me.Tb_DiagnosticoLesion.MaxLength = 100
        Me.Tb_DiagnosticoLesion.Name = "Tb_DiagnosticoLesion"
        Me.Tb_DiagnosticoLesion.Size = New System.Drawing.Size(307, 20)
        Me.Tb_DiagnosticoLesion.TabIndex = 138
        '
        'Lb_AgenteAccidente
        '
        Me.Lb_AgenteAccidente.AutoSize = True
        Me.Lb_AgenteAccidente.Location = New System.Drawing.Point(247, 156)
        Me.Lb_AgenteAccidente.Name = "Lb_AgenteAccidente"
        Me.Lb_AgenteAccidente.Size = New System.Drawing.Size(40, 13)
        Me.Lb_AgenteAccidente.TabIndex = 130
        Me.Lb_AgenteAccidente.Text = "¿Cual?"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(574, 255)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(88, 13)
        Me.Label46.TabIndex = 143
        Me.Label46.Text = "¿Hubo Testigos?"
        '
        'Cb_AgenteAccidente
        '
        Me.Cb_AgenteAccidente.FormattingEnabled = True
        Me.Cb_AgenteAccidente.Location = New System.Drawing.Point(117, 151)
        Me.Cb_AgenteAccidente.Name = "Cb_AgenteAccidente"
        Me.Cb_AgenteAccidente.Size = New System.Drawing.Size(121, 21)
        Me.Cb_AgenteAccidente.TabIndex = 129
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(6, 221)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(119, 13)
        Me.Label42.TabIndex = 137
        Me.Label42.Text = "Diagnostico de la lesión"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(7, 156)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(108, 13)
        Me.Label39.TabIndex = 128
        Me.Label39.Text = "Agente del accidente"
        '
        'Tb_Traslado
        '
        Me.Tb_Traslado.Location = New System.Drawing.Point(366, 252)
        Me.Tb_Traslado.MaxLength = 30
        Me.Tb_Traslado.Name = "Tb_Traslado"
        Me.Tb_Traslado.Size = New System.Drawing.Size(189, 20)
        Me.Tb_Traslado.TabIndex = 142
        '
        'Cb_ParteAfectada
        '
        Me.Cb_ParteAfectada.FormattingEnabled = True
        Me.Cb_ParteAfectada.Location = New System.Drawing.Point(137, 117)
        Me.Cb_ParteAfectada.Name = "Cb_ParteAfectada"
        Me.Cb_ParteAfectada.Size = New System.Drawing.Size(121, 21)
        Me.Cb_ParteAfectada.TabIndex = 125
        '
        'Lb_Trasladado
        '
        Me.Lb_Trasladado.AutoSize = True
        Me.Lb_Trasladado.Location = New System.Drawing.Point(291, 255)
        Me.Lb_Trasladado.Name = "Lb_Trasladado"
        Me.Lb_Trasladado.Size = New System.Drawing.Size(69, 13)
        Me.Lb_Trasladado.TabIndex = 141
        Me.Lb_Trasladado.Text = "Trasladado a"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 122)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(130, 13)
        Me.Label37.TabIndex = 124
        Me.Label37.Text = "Parte del cuerpo afectada"
        '
        'Cb_AtencionInmediata
        '
        Me.Cb_AtencionInmediata.FormattingEnabled = True
        Me.Cb_AtencionInmediata.Items.AddRange(New Object() {"MEDEVAC", "Regreso a su trabajo", "Hospitalizado", "Enviado a su casa", "Traslado a centro de Atención"})
        Me.Cb_AtencionInmediata.Location = New System.Drawing.Point(112, 249)
        Me.Cb_AtencionInmediata.Name = "Cb_AtencionInmediata"
        Me.Cb_AtencionInmediata.Size = New System.Drawing.Size(173, 21)
        Me.Cb_AtencionInmediata.TabIndex = 140
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(6, 255)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(98, 13)
        Me.Label44.TabIndex = 139
        Me.Label44.Text = "Atención Inmediata"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DTP_FechaNacimiento)
        Me.GroupBox3.Controls.Add(Me.Label53)
        Me.GroupBox3.Controls.Add(Me.GroupBox_Genero)
        Me.GroupBox3.Controls.Add(Me.DTP_InicioContrato)
        Me.GroupBox3.Controls.Add(Me.Cb_AFP)
        Me.GroupBox3.Controls.Add(Me.Label59)
        Me.GroupBox3.Controls.Add(Me.Cb_EPS)
        Me.GroupBox3.Controls.Add(Me.Label49)
        Me.GroupBox3.Controls.Add(Me.Rb_MuerteNo)
        Me.GroupBox3.Controls.Add(Me.Rb_MuerteSi)
        Me.GroupBox3.Controls.Add(Me.Label29)
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
        Me.GroupBox3.Location = New System.Drawing.Point(15, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(875, 251)
        Me.GroupBox3.TabIndex = 70
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Información Persona Afectada"
        '
        'DTP_FechaNacimiento
        '
        Me.DTP_FechaNacimiento.Checked = False
        Me.DTP_FechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaNacimiento.Location = New System.Drawing.Point(110, 55)
        Me.DTP_FechaNacimiento.Name = "DTP_FechaNacimiento"
        Me.DTP_FechaNacimiento.ShowCheckBox = True
        Me.DTP_FechaNacimiento.Size = New System.Drawing.Size(112, 20)
        Me.DTP_FechaNacimiento.TabIndex = 77
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(5, 58)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(96, 13)
        Me.Label53.TabIndex = 76
        Me.Label53.Text = "Fecha Nacimiento:"
        '
        'GroupBox_Genero
        '
        Me.GroupBox_Genero.Controls.Add(Me.Label60)
        Me.GroupBox_Genero.Controls.Add(Me.Rb_Femenino)
        Me.GroupBox_Genero.Controls.Add(Me.Rb_Masculino)
        Me.GroupBox_Genero.Location = New System.Drawing.Point(265, 46)
        Me.GroupBox_Genero.Name = "GroupBox_Genero"
        Me.GroupBox_Genero.Size = New System.Drawing.Size(203, 31)
        Me.GroupBox_Genero.TabIndex = 78
        Me.GroupBox_Genero.TabStop = False
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(3, 12)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(45, 13)
        Me.Label60.TabIndex = 79
        Me.Label60.Text = "Genero:"
        '
        'Rb_Femenino
        '
        Me.Rb_Femenino.AutoSize = True
        Me.Rb_Femenino.Location = New System.Drawing.Point(131, 10)
        Me.Rb_Femenino.Name = "Rb_Femenino"
        Me.Rb_Femenino.Size = New System.Drawing.Size(71, 17)
        Me.Rb_Femenino.TabIndex = 81
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
        Me.Rb_Masculino.TabIndex = 80
        Me.Rb_Masculino.TabStop = True
        Me.Rb_Masculino.Text = "Masculino"
        Me.Rb_Masculino.UseVisualStyleBackColor = True
        '
        'DTP_InicioContrato
        '
        Me.DTP_InicioContrato.Checked = False
        Me.DTP_InicioContrato.Location = New System.Drawing.Point(549, 198)
        Me.DTP_InicioContrato.MaxDate = New Date(2021, 6, 2, 0, 0, 0, 0)
        Me.DTP_InicioContrato.Name = "DTP_InicioContrato"
        Me.DTP_InicioContrato.ShowCheckBox = True
        Me.DTP_InicioContrato.Size = New System.Drawing.Size(218, 20)
        Me.DTP_InicioContrato.TabIndex = 103
        Me.DTP_InicioContrato.Value = New Date(2021, 6, 2, 0, 0, 0, 0)
        '
        'Cb_AFP
        '
        Me.Cb_AFP.FormattingEnabled = True
        Me.Cb_AFP.Location = New System.Drawing.Point(294, 84)
        Me.Cb_AFP.Name = "Cb_AFP"
        Me.Cb_AFP.Size = New System.Drawing.Size(207, 21)
        Me.Cb_AFP.TabIndex = 85
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(262, 88)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(27, 13)
        Me.Label59.TabIndex = 84
        Me.Label59.Text = "AFP"
        '
        'Cb_EPS
        '
        Me.Cb_EPS.FormattingEnabled = True
        Me.Cb_EPS.Location = New System.Drawing.Point(37, 84)
        Me.Cb_EPS.Name = "Cb_EPS"
        Me.Cb_EPS.Size = New System.Drawing.Size(207, 21)
        Me.Cb_EPS.TabIndex = 83
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(5, 88)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(28, 13)
        Me.Label49.TabIndex = 82
        Me.Label49.Text = "EPS"
        '
        'Rb_MuerteNo
        '
        Me.Rb_MuerteNo.AutoSize = True
        Me.Rb_MuerteNo.Location = New System.Drawing.Point(131, 228)
        Me.Rb_MuerteNo.Name = "Rb_MuerteNo"
        Me.Rb_MuerteNo.Size = New System.Drawing.Size(39, 17)
        Me.Rb_MuerteNo.TabIndex = 106
        Me.Rb_MuerteNo.TabStop = True
        Me.Rb_MuerteNo.Text = "No"
        Me.Rb_MuerteNo.UseVisualStyleBackColor = True
        '
        'Rb_MuerteSi
        '
        Me.Rb_MuerteSi.AutoSize = True
        Me.Rb_MuerteSi.Location = New System.Drawing.Point(97, 228)
        Me.Rb_MuerteSi.Name = "Rb_MuerteSi"
        Me.Rb_MuerteSi.Size = New System.Drawing.Size(34, 17)
        Me.Rb_MuerteSi.TabIndex = 105
        Me.Rb_MuerteSi.TabStop = True
        Me.Rb_MuerteSi.Text = "Si"
        Me.Rb_MuerteSi.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 230)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(85, 13)
        Me.Label29.TabIndex = 104
        Me.Label29.Text = "¿Causo Muerte?"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(439, 201)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(108, 13)
        Me.Label28.TabIndex = 102
        Me.Label28.Text = "Fecha Inicio Contrato"
        '
        'Cb_JornadaHabitual
        '
        Me.Cb_JornadaHabitual.FormattingEnabled = True
        Me.Cb_JornadaHabitual.Items.AddRange(New Object() {"Diurna", "Nocturna", "Mixto", "Turnos"})
        Me.Cb_JornadaHabitual.Location = New System.Drawing.Point(310, 198)
        Me.Cb_JornadaHabitual.Name = "Cb_JornadaHabitual"
        Me.Cb_JornadaHabitual.Size = New System.Drawing.Size(121, 21)
        Me.Cb_JornadaHabitual.TabIndex = 101
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(178, 201)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(126, 13)
        Me.Label24.TabIndex = 100
        Me.Label24.Text = "Jornada Trabajo Habitual"
        '
        'Tb_Salario
        '
        Me.Tb_Salario.Location = New System.Drawing.Point(45, 198)
        Me.Tb_Salario.MaxLength = 18
        Me.Tb_Salario.Name = "Tb_Salario"
        Me.Tb_Salario.Size = New System.Drawing.Size(126, 20)
        Me.Tb_Salario.TabIndex = 99
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(5, 201)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 13)
        Me.Label23.TabIndex = 98
        Me.Label23.Text = "Salario"
        '
        'Cb_OcupacionHabitual
        '
        Me.Cb_OcupacionHabitual.FormattingEnabled = True
        Me.Cb_OcupacionHabitual.Location = New System.Drawing.Point(663, 160)
        Me.Cb_OcupacionHabitual.Name = "Cb_OcupacionHabitual"
        Me.Cb_OcupacionHabitual.Size = New System.Drawing.Size(121, 21)
        Me.Cb_OcupacionHabitual.TabIndex = 97
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(556, 163)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(101, 13)
        Me.Label22.TabIndex = 96
        Me.Label22.Text = "Ocupacion Habitual"
        '
        'Cb_CargoPersonaAccidente
        '
        Me.Cb_CargoPersonaAccidente.FormattingEnabled = True
        Me.Cb_CargoPersonaAccidente.Location = New System.Drawing.Point(420, 160)
        Me.Cb_CargoPersonaAccidente.Name = "Cb_CargoPersonaAccidente"
        Me.Cb_CargoPersonaAccidente.Size = New System.Drawing.Size(121, 21)
        Me.Cb_CargoPersonaAccidente.TabIndex = 95
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(379, 163)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 13)
        Me.Label21.TabIndex = 94
        Me.Label21.Text = "Cargo"
        '
        'Tb_CorreoElectronico
        '
        Me.Tb_CorreoElectronico.Location = New System.Drawing.Point(100, 160)
        Me.Tb_CorreoElectronico.MaxLength = 60
        Me.Tb_CorreoElectronico.Name = "Tb_CorreoElectronico"
        Me.Tb_CorreoElectronico.Size = New System.Drawing.Size(271, 20)
        Me.Tb_CorreoElectronico.TabIndex = 93
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(5, 163)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(94, 13)
        Me.Label20.TabIndex = 92
        Me.Label20.Text = "Correo Electrónico"
        '
        'Tb_TelefonoMovil
        '
        Me.Tb_TelefonoMovil.Location = New System.Drawing.Point(607, 118)
        Me.Tb_TelefonoMovil.MaxLength = 10
        Me.Tb_TelefonoMovil.Name = "Tb_TelefonoMovil"
        Me.Tb_TelefonoMovil.Size = New System.Drawing.Size(120, 20)
        Me.Tb_TelefonoMovil.TabIndex = 91
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(556, 122)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 90
        Me.Label19.Text = "Teléfono"
        '
        'Tb_Telefono
        '
        Me.Tb_Telefono.Location = New System.Drawing.Point(431, 118)
        Me.Tb_Telefono.MaxLength = 10
        Me.Tb_Telefono.Name = "Tb_Telefono"
        Me.Tb_Telefono.Size = New System.Drawing.Size(120, 20)
        Me.Tb_Telefono.TabIndex = 89
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(379, 122)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 88
        Me.Label18.Text = "Teléfono"
        '
        'Tb_Direccion
        '
        Me.Tb_Direccion.Location = New System.Drawing.Point(59, 118)
        Me.Tb_Direccion.MaxLength = 150
        Me.Tb_Direccion.Name = "Tb_Direccion"
        Me.Tb_Direccion.Size = New System.Drawing.Size(312, 20)
        Me.Tb_Direccion.TabIndex = 87
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(5, 122)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 86
        Me.Label17.Text = "Direccion"
        '
        'Cu_AsociarPersonaAfectada
        '
        Me.Cu_AsociarPersonaAfectada.componenteasociado = Nothing
        Me.Cu_AsociarPersonaAfectada.CrearUsuario = False
        Me.Cu_AsociarPersonaAfectada.Location = New System.Drawing.Point(644, 25)
        Me.Cu_AsociarPersonaAfectada.Name = "Cu_AsociarPersonaAfectada"
        Me.Cu_AsociarPersonaAfectada.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaAfectada.TabIndex = 75
        Me.Cu_AsociarPersonaAfectada.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaAfectada.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaAfectada
        '
        Me.Cu_BuscarPersonaAfectada.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAfectada.Location = New System.Drawing.Point(376, 23)
        Me.Cu_BuscarPersonaAfectada.Name = "Cu_BuscarPersonaAfectada"
        Me.Cu_BuscarPersonaAfectada.Size = New System.Drawing.Size(265, 23)
        Me.Cu_BuscarPersonaAfectada.TabIndex = 74
        Me.Cu_BuscarPersonaAfectada.Tipo = "PABO"
        Me.Cu_BuscarPersonaAfectada.valorcajatexto = "IDENTIFICACION"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(262, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 13)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Nombre del Afectado"
        '
        'Cb_TipoVinculacion
        '
        Me.Cb_TipoVinculacion.FormattingEnabled = True
        Me.Cb_TipoVinculacion.Items.AddRange(New Object() {"Empleador", "Contratante", "Cooperativa Trabajo Asociado"})
        Me.Cb_TipoVinculacion.Location = New System.Drawing.Point(110, 24)
        Me.Cb_TipoVinculacion.Name = "Cb_TipoVinculacion"
        Me.Cb_TipoVinculacion.Size = New System.Drawing.Size(134, 21)
        Me.Cb_TipoVinculacion.TabIndex = 72
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "Tipo de Vinculación"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Dgv_Testigos)
        Me.TabPage3.Controls.Add(Me.Pn_tituloConceptos)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(906, 552)
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
        Me.Cedula.HeaderText = "Cedula"
        Me.Cedula.Name = "Cedula"
        Me.Cedula.Width = 105
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 450
        '
        'DGVCB_Cargo
        '
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
        'Fr_CrearReporte24H
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 611)
        Me.Controls.Add(Me.Pn_Botones)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximumSize = New System.Drawing.Size(930, 650)
        Me.MinimumSize = New System.Drawing.Size(930, 650)
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
        CType(Me.Dgv_AccionesInmediatas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
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
    Friend WithEvents Tb_Contrato As System.Windows.Forms.TextBox
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
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaBodega4 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaBodega3 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaBodega2 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaBodega1 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaValida4 As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BuscarPersonaValida2 As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BuscarPersonaValida3 As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BuscarPersonaValida1 As FormulariosClasesBase.Cu_BuscarPersona
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
    Friend WithEvents Cedula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVCB_Cargo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_TrabajoHabitualNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_TrabajoHabitualSi As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    'Friend WithEvents Bt_VerMatriz As System.Windows.Forms.Button
    Friend WithEvents Tb_CategoriaResultante As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CategoriaResultante As System.Windows.Forms.Label
    Friend WithEvents Dgv_AccionesInmediatas As System.Windows.Forms.DataGridView
    Friend WithEvents DGVT_AccionesInmediatas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_CedulaAcciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_NombreAcciones As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
