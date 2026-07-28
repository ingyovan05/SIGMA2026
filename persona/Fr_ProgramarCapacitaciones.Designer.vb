<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ProgramarCapacitaciones
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Dgv_Personal = New System.Windows.Forms.DataGridView()
        Me.ColPer_IdPersona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPer_NombreCompleto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPer_Identificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_ControlesCalificaciones = New System.Windows.Forms.Panel()
        Me.Bt_AgregarCalificacion = New System.Windows.Forms.Button()
        Me.Lb_TextoActividad = New System.Windows.Forms.Label()
        Me.Cb_ActividadCapacitacion = New System.Windows.Forms.ComboBox()
        Me.Dtp_FechaProgramaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Lb_TextoFechaProgramaInicio = New System.Windows.Forms.Label()
        Me.Sc_Programacion = New System.Windows.Forms.SplitContainer()
        Me.Sc_Actividades = New System.Windows.Forms.SplitContainer()
        Me.Pn_ControlesPersonal = New System.Windows.Forms.Panel()
        Me.Cubp_Persona = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_TextoPersona = New System.Windows.Forms.Label()
        Me.Bt_AgregarPersona = New System.Windows.Forms.Button()
        Me.Pn_TituloPersonal = New System.Windows.Forms.Panel()
        Me.Lb_TextoTituloPersonal = New System.Windows.Forms.Label()
        Me.Dgv_Calificaciones = New System.Windows.Forms.DataGridView()
        Me.ColCal_CodigoActividadCapacitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCal_NombreActividadCapacitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_TituloCalificaciones = New System.Windows.Forms.Panel()
        Me.Lb_TextoTituloCalificaciones = New System.Windows.Forms.Label()
        Me.Dgv_Programacion = New System.Windows.Forms.DataGridView()
        Me.ColPro_CodigoActividadCapacitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPro_NombreActividadCapacitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPro_Idpersona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPro_Identificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPro_NombreCompleto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPro_FechaProgramaInicio = New Persona.CalendarColumn()
        Me.ColPro_FechaProgramaFin = New Persona.CalendarColumn()
        Me.Pn_ControlesProgramacion = New System.Windows.Forms.Panel()
        Me.Bt_AgregarProgramacion = New System.Windows.Forms.Button()
        Me.Lb_TextoFechaProgramaFin = New System.Windows.Forms.Label()
        Me.Dtp_FechaProgramaFin = New System.Windows.Forms.DateTimePicker()
        Me.Pn_TituloProgramacion = New System.Windows.Forms.Panel()
        Me.Lb_TextoTituloProgramacion = New System.Windows.Forms.Label()
        Me.Tt_ProgramarCapacitaciones = New System.Windows.Forms.ToolTip(Me.components)
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
        Me.CalendarColumn1 = New Persona.CalendarColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Flp_Botones.SuspendLayout()
        CType(Me.Dgv_Personal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_ControlesCalificaciones.SuspendLayout()
        CType(Me.Sc_Programacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sc_Programacion.Panel1.SuspendLayout()
        Me.Sc_Programacion.Panel2.SuspendLayout()
        Me.Sc_Programacion.SuspendLayout()
        CType(Me.Sc_Actividades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sc_Actividades.Panel1.SuspendLayout()
        Me.Sc_Actividades.Panel2.SuspendLayout()
        Me.Sc_Actividades.SuspendLayout()
        Me.Pn_ControlesPersonal.SuspendLayout()
        Me.Pn_TituloPersonal.SuspendLayout()
        CType(Me.Dgv_Calificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_TituloCalificaciones.SuspendLayout()
        CType(Me.Dgv_Programacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_ControlesProgramacion.SuspendLayout()
        Me.Pn_TituloProgramacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 631)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(984, 30)
        Me.Flp_Botones.TabIndex = 0
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(906, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(825, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 1
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Dgv_Personal
        '
        Me.Dgv_Personal.AllowUserToAddRows = False
        Me.Dgv_Personal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Personal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Personal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPer_IdPersona, Me.ColPer_NombreCompleto, Me.ColPer_Identificacion})
        Me.Dgv_Personal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Personal.Location = New System.Drawing.Point(0, 69)
        Me.Dgv_Personal.Name = "Dgv_Personal"
        Me.Dgv_Personal.Size = New System.Drawing.Size(490, 319)
        Me.Dgv_Personal.TabIndex = 1
        '
        'ColPer_IdPersona
        '
        Me.ColPer_IdPersona.DataPropertyName = "IDPERSONA"
        Me.ColPer_IdPersona.HeaderText = "IDPERSONA"
        Me.ColPer_IdPersona.Name = "ColPer_IdPersona"
        Me.ColPer_IdPersona.ReadOnly = True
        Me.ColPer_IdPersona.Visible = False
        '
        'ColPer_NombreCompleto
        '
        Me.ColPer_NombreCompleto.DataPropertyName = "NOMBRECOMPLETO"
        Me.ColPer_NombreCompleto.HeaderText = "Nombre"
        Me.ColPer_NombreCompleto.Name = "ColPer_NombreCompleto"
        Me.ColPer_NombreCompleto.ReadOnly = True
        Me.ColPer_NombreCompleto.ToolTipText = "Nombre completo"
        '
        'ColPer_Identificacion
        '
        Me.ColPer_Identificacion.DataPropertyName = "IDENTIFICACION"
        Me.ColPer_Identificacion.HeaderText = "Cédula"
        Me.ColPer_Identificacion.Name = "ColPer_Identificacion"
        Me.ColPer_Identificacion.ReadOnly = True
        Me.ColPer_Identificacion.ToolTipText = "Número de identificación"
        '
        'Pn_ControlesCalificaciones
        '
        Me.Pn_ControlesCalificaciones.Controls.Add(Me.Bt_AgregarCalificacion)
        Me.Pn_ControlesCalificaciones.Controls.Add(Me.Lb_TextoActividad)
        Me.Pn_ControlesCalificaciones.Controls.Add(Me.Cb_ActividadCapacitacion)
        Me.Pn_ControlesCalificaciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_ControlesCalificaciones.Location = New System.Drawing.Point(0, 24)
        Me.Pn_ControlesCalificaciones.Name = "Pn_ControlesCalificaciones"
        Me.Pn_ControlesCalificaciones.Size = New System.Drawing.Size(490, 45)
        Me.Pn_ControlesCalificaciones.TabIndex = 2
        '
        'Bt_AgregarCalificacion
        '
        Me.Bt_AgregarCalificacion.AutoSize = True
        Me.Bt_AgregarCalificacion.Location = New System.Drawing.Point(403, 11)
        Me.Bt_AgregarCalificacion.Name = "Bt_AgregarCalificacion"
        Me.Bt_AgregarCalificacion.Size = New System.Drawing.Size(75, 23)
        Me.Bt_AgregarCalificacion.TabIndex = 9
        Me.Bt_AgregarCalificacion.Text = "Agregar"
        Me.Bt_AgregarCalificacion.UseVisualStyleBackColor = True
        '
        'Lb_TextoActividad
        '
        Me.Lb_TextoActividad.AutoSize = True
        Me.Lb_TextoActividad.Location = New System.Drawing.Point(12, 16)
        Me.Lb_TextoActividad.Name = "Lb_TextoActividad"
        Me.Lb_TextoActividad.Size = New System.Drawing.Size(54, 13)
        Me.Lb_TextoActividad.TabIndex = 4
        Me.Lb_TextoActividad.Text = "Actividad:"
        '
        'Cb_ActividadCapacitacion
        '
        Me.Cb_ActividadCapacitacion.DisplayMember = "NOMBREACTIVIDADCAPACITACION"
        Me.Cb_ActividadCapacitacion.FormattingEnabled = True
        Me.Cb_ActividadCapacitacion.Location = New System.Drawing.Point(69, 12)
        Me.Cb_ActividadCapacitacion.Name = "Cb_ActividadCapacitacion"
        Me.Cb_ActividadCapacitacion.Size = New System.Drawing.Size(328, 21)
        Me.Cb_ActividadCapacitacion.TabIndex = 3
        Me.Cb_ActividadCapacitacion.ValueMember = "CODIGOACTIVIDADCAPACITACION"
        '
        'Dtp_FechaProgramaInicio
        '
        Me.Dtp_FechaProgramaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaProgramaInicio.Location = New System.Drawing.Point(114, 13)
        Me.Dtp_FechaProgramaInicio.Name = "Dtp_FechaProgramaInicio"
        Me.Dtp_FechaProgramaInicio.Size = New System.Drawing.Size(100, 20)
        Me.Dtp_FechaProgramaInicio.TabIndex = 8
        '
        'Lb_TextoFechaProgramaInicio
        '
        Me.Lb_TextoFechaProgramaInicio.AutoSize = True
        Me.Lb_TextoFechaProgramaInicio.Location = New System.Drawing.Point(12, 16)
        Me.Lb_TextoFechaProgramaInicio.Name = "Lb_TextoFechaProgramaInicio"
        Me.Lb_TextoFechaProgramaInicio.Size = New System.Drawing.Size(99, 13)
        Me.Lb_TextoFechaProgramaInicio.TabIndex = 7
        Me.Lb_TextoFechaProgramaInicio.Text = "Fecha programada:"
        '
        'Sc_Programacion
        '
        Me.Sc_Programacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sc_Programacion.Location = New System.Drawing.Point(0, 0)
        Me.Sc_Programacion.Name = "Sc_Programacion"
        Me.Sc_Programacion.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Sc_Programacion.Panel1
        '
        Me.Sc_Programacion.Panel1.Controls.Add(Me.Sc_Actividades)
        '
        'Sc_Programacion.Panel2
        '
        Me.Sc_Programacion.Panel2.Controls.Add(Me.Dgv_Programacion)
        Me.Sc_Programacion.Panel2.Controls.Add(Me.Pn_ControlesProgramacion)
        Me.Sc_Programacion.Panel2.Controls.Add(Me.Pn_TituloProgramacion)
        Me.Sc_Programacion.Size = New System.Drawing.Size(984, 631)
        Me.Sc_Programacion.SplitterDistance = 388
        Me.Sc_Programacion.TabIndex = 3
        '
        'Sc_Actividades
        '
        Me.Sc_Actividades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sc_Actividades.Location = New System.Drawing.Point(0, 0)
        Me.Sc_Actividades.Name = "Sc_Actividades"
        '
        'Sc_Actividades.Panel1
        '
        Me.Sc_Actividades.Panel1.Controls.Add(Me.Dgv_Personal)
        Me.Sc_Actividades.Panel1.Controls.Add(Me.Pn_ControlesPersonal)
        Me.Sc_Actividades.Panel1.Controls.Add(Me.Pn_TituloPersonal)
        Me.Sc_Actividades.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'Sc_Actividades.Panel2
        '
        Me.Sc_Actividades.Panel2.Controls.Add(Me.Dgv_Calificaciones)
        Me.Sc_Actividades.Panel2.Controls.Add(Me.Pn_ControlesCalificaciones)
        Me.Sc_Actividades.Panel2.Controls.Add(Me.Pn_TituloCalificaciones)
        Me.Sc_Actividades.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Sc_Actividades.Size = New System.Drawing.Size(984, 388)
        Me.Sc_Actividades.SplitterDistance = 490
        Me.Sc_Actividades.TabIndex = 0
        '
        'Pn_ControlesPersonal
        '
        Me.Pn_ControlesPersonal.Controls.Add(Me.Cubp_Persona)
        Me.Pn_ControlesPersonal.Controls.Add(Me.Lb_TextoPersona)
        Me.Pn_ControlesPersonal.Controls.Add(Me.Bt_AgregarPersona)
        Me.Pn_ControlesPersonal.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_ControlesPersonal.Location = New System.Drawing.Point(0, 24)
        Me.Pn_ControlesPersonal.Name = "Pn_ControlesPersonal"
        Me.Pn_ControlesPersonal.Size = New System.Drawing.Size(490, 45)
        Me.Pn_ControlesPersonal.TabIndex = 3
        '
        'Cubp_Persona
        '
        Me.Cubp_Persona.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cubp_Persona.Location = New System.Drawing.Point(62, 12)
        Me.Cubp_Persona.Name = "Cubp_Persona"
        Me.Cubp_Persona.Size = New System.Drawing.Size(296, 23)
        Me.Cubp_Persona.TabIndex = 9
        Me.Cubp_Persona.Tipo = "P"
        Me.Cubp_Persona.valorcajatexto = "IDENTIFICACION"
        '
        'Lb_TextoPersona
        '
        Me.Lb_TextoPersona.AutoSize = True
        Me.Lb_TextoPersona.Location = New System.Drawing.Point(12, 16)
        Me.Lb_TextoPersona.Name = "Lb_TextoPersona"
        Me.Lb_TextoPersona.Size = New System.Drawing.Size(49, 13)
        Me.Lb_TextoPersona.TabIndex = 2
        Me.Lb_TextoPersona.Text = "Persona:"
        '
        'Bt_AgregarPersona
        '
        Me.Bt_AgregarPersona.Location = New System.Drawing.Point(361, 12)
        Me.Bt_AgregarPersona.Name = "Bt_AgregarPersona"
        Me.Bt_AgregarPersona.Size = New System.Drawing.Size(75, 23)
        Me.Bt_AgregarPersona.TabIndex = 1
        Me.Bt_AgregarPersona.Text = "Agregar"
        Me.Bt_AgregarPersona.UseVisualStyleBackColor = True
        '
        'Pn_TituloPersonal
        '
        Me.Pn_TituloPersonal.Controls.Add(Me.Lb_TextoTituloPersonal)
        Me.Pn_TituloPersonal.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloPersonal.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloPersonal.Name = "Pn_TituloPersonal"
        Me.Pn_TituloPersonal.Size = New System.Drawing.Size(490, 24)
        Me.Pn_TituloPersonal.TabIndex = 4
        '
        'Lb_TextoTituloPersonal
        '
        Me.Lb_TextoTituloPersonal.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_TextoTituloPersonal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoTituloPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoTituloPersonal.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TextoTituloPersonal.Name = "Lb_TextoTituloPersonal"
        Me.Lb_TextoTituloPersonal.Size = New System.Drawing.Size(490, 24)
        Me.Lb_TextoTituloPersonal.TabIndex = 0
        Me.Lb_TextoTituloPersonal.Text = "Agregar personas"
        Me.Lb_TextoTituloPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_Calificaciones
        '
        Me.Dgv_Calificaciones.AllowUserToAddRows = False
        Me.Dgv_Calificaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Calificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Calificaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCal_CodigoActividadCapacitacion, Me.ColCal_NombreActividadCapacitacion})
        Me.Dgv_Calificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Calificaciones.Location = New System.Drawing.Point(0, 69)
        Me.Dgv_Calificaciones.Name = "Dgv_Calificaciones"
        Me.Dgv_Calificaciones.Size = New System.Drawing.Size(490, 319)
        Me.Dgv_Calificaciones.TabIndex = 4
        '
        'ColCal_CodigoActividadCapacitacion
        '
        Me.ColCal_CodigoActividadCapacitacion.DataPropertyName = "CODIGOACTIVIDADCAPACITACION"
        Me.ColCal_CodigoActividadCapacitacion.HeaderText = "CODIGOACTIVIDADCAPACITACION"
        Me.ColCal_CodigoActividadCapacitacion.Name = "ColCal_CodigoActividadCapacitacion"
        Me.ColCal_CodigoActividadCapacitacion.ReadOnly = True
        Me.ColCal_CodigoActividadCapacitacion.Visible = False
        '
        'ColCal_NombreActividadCapacitacion
        '
        Me.ColCal_NombreActividadCapacitacion.DataPropertyName = "NOMBREACTIVIDADCAPACITACION"
        Me.ColCal_NombreActividadCapacitacion.HeaderText = "Actividad"
        Me.ColCal_NombreActividadCapacitacion.Name = "ColCal_NombreActividadCapacitacion"
        Me.ColCal_NombreActividadCapacitacion.ReadOnly = True
        Me.ColCal_NombreActividadCapacitacion.ToolTipText = "Actividad capacitación"
        '
        'Pn_TituloCalificaciones
        '
        Me.Pn_TituloCalificaciones.Controls.Add(Me.Lb_TextoTituloCalificaciones)
        Me.Pn_TituloCalificaciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloCalificaciones.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloCalificaciones.Name = "Pn_TituloCalificaciones"
        Me.Pn_TituloCalificaciones.Size = New System.Drawing.Size(490, 24)
        Me.Pn_TituloCalificaciones.TabIndex = 3
        '
        'Lb_TextoTituloCalificaciones
        '
        Me.Lb_TextoTituloCalificaciones.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_TextoTituloCalificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoTituloCalificaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoTituloCalificaciones.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TextoTituloCalificaciones.Name = "Lb_TextoTituloCalificaciones"
        Me.Lb_TextoTituloCalificaciones.Size = New System.Drawing.Size(490, 24)
        Me.Lb_TextoTituloCalificaciones.TabIndex = 0
        Me.Lb_TextoTituloCalificaciones.Text = "Agregar calificaciones"
        Me.Lb_TextoTituloCalificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_Programacion
        '
        Me.Dgv_Programacion.AllowUserToAddRows = False
        Me.Dgv_Programacion.AllowUserToOrderColumns = True
        Me.Dgv_Programacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Programacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Programacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPro_CodigoActividadCapacitacion, Me.ColPro_NombreActividadCapacitacion, Me.ColPro_Idpersona, Me.ColPro_Identificacion, Me.ColPro_NombreCompleto, Me.ColPro_FechaProgramaInicio, Me.ColPro_FechaProgramaFin})
        Me.Dgv_Programacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Programacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Programacion.Location = New System.Drawing.Point(0, 69)
        Me.Dgv_Programacion.Name = "Dgv_Programacion"
        Me.Dgv_Programacion.Size = New System.Drawing.Size(984, 170)
        Me.Dgv_Programacion.TabIndex = 5
        '
        'ColPro_CodigoActividadCapacitacion
        '
        Me.ColPro_CodigoActividadCapacitacion.DataPropertyName = "CODIGOACTIVIDADCAPACITACION"
        Me.ColPro_CodigoActividadCapacitacion.HeaderText = "CODIGOACTIVIDADCAPACITACION"
        Me.ColPro_CodigoActividadCapacitacion.Name = "ColPro_CodigoActividadCapacitacion"
        Me.ColPro_CodigoActividadCapacitacion.ReadOnly = True
        Me.ColPro_CodigoActividadCapacitacion.Visible = False
        '
        'ColPro_NombreActividadCapacitacion
        '
        Me.ColPro_NombreActividadCapacitacion.DataPropertyName = "NOMBREACTIVIDADCAPACITACION"
        Me.ColPro_NombreActividadCapacitacion.HeaderText = "Actividad"
        Me.ColPro_NombreActividadCapacitacion.Name = "ColPro_NombreActividadCapacitacion"
        Me.ColPro_NombreActividadCapacitacion.ReadOnly = True
        Me.ColPro_NombreActividadCapacitacion.ToolTipText = "Actividad capacitación"
        '
        'ColPro_Idpersona
        '
        Me.ColPro_Idpersona.DataPropertyName = "IDPERSONA"
        Me.ColPro_Idpersona.HeaderText = "IDPERSONA"
        Me.ColPro_Idpersona.Name = "ColPro_Idpersona"
        Me.ColPro_Idpersona.ReadOnly = True
        Me.ColPro_Idpersona.Visible = False
        '
        'ColPro_Identificacion
        '
        Me.ColPro_Identificacion.DataPropertyName = "IDENTIFICACION"
        Me.ColPro_Identificacion.HeaderText = "Cédula"
        Me.ColPro_Identificacion.Name = "ColPro_Identificacion"
        Me.ColPro_Identificacion.ReadOnly = True
        Me.ColPro_Identificacion.ToolTipText = "Número de identificación"
        '
        'ColPro_NombreCompleto
        '
        Me.ColPro_NombreCompleto.DataPropertyName = "NOMBRECOMPLETO"
        Me.ColPro_NombreCompleto.HeaderText = "Nombre"
        Me.ColPro_NombreCompleto.Name = "ColPro_NombreCompleto"
        Me.ColPro_NombreCompleto.ReadOnly = True
        Me.ColPro_NombreCompleto.ToolTipText = "Nombre completo"
        '
        'ColPro_FechaProgramaInicio
        '
        Me.ColPro_FechaProgramaInicio.DataPropertyName = "FECHAPROGRAMADAINICIO"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ColPro_FechaProgramaInicio.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColPro_FechaProgramaInicio.HeaderText = "Fecha desde"
        Me.ColPro_FechaProgramaInicio.Name = "ColPro_FechaProgramaInicio"
        Me.ColPro_FechaProgramaInicio.ToolTipText = "Fecha inicial de programación"
        '
        'ColPro_FechaProgramaFin
        '
        Me.ColPro_FechaProgramaFin.DataPropertyName = "FECHAPROGRAMADAFIN"
        Me.ColPro_FechaProgramaFin.HeaderText = "Fecha hasta"
        Me.ColPro_FechaProgramaFin.Name = "ColPro_FechaProgramaFin"
        Me.ColPro_FechaProgramaFin.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColPro_FechaProgramaFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColPro_FechaProgramaFin.ToolTipText = "Fecha final de programación"
        '
        'Pn_ControlesProgramacion
        '
        Me.Pn_ControlesProgramacion.Controls.Add(Me.Bt_AgregarProgramacion)
        Me.Pn_ControlesProgramacion.Controls.Add(Me.Lb_TextoFechaProgramaFin)
        Me.Pn_ControlesProgramacion.Controls.Add(Me.Dtp_FechaProgramaFin)
        Me.Pn_ControlesProgramacion.Controls.Add(Me.Lb_TextoFechaProgramaInicio)
        Me.Pn_ControlesProgramacion.Controls.Add(Me.Dtp_FechaProgramaInicio)
        Me.Pn_ControlesProgramacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_ControlesProgramacion.Location = New System.Drawing.Point(0, 24)
        Me.Pn_ControlesProgramacion.Name = "Pn_ControlesProgramacion"
        Me.Pn_ControlesProgramacion.Size = New System.Drawing.Size(984, 45)
        Me.Pn_ControlesProgramacion.TabIndex = 6
        '
        'Bt_AgregarProgramacion
        '
        Me.Bt_AgregarProgramacion.AutoSize = True
        Me.Bt_AgregarProgramacion.Location = New System.Drawing.Point(377, 12)
        Me.Bt_AgregarProgramacion.Name = "Bt_AgregarProgramacion"
        Me.Bt_AgregarProgramacion.Size = New System.Drawing.Size(131, 23)
        Me.Bt_AgregarProgramacion.TabIndex = 10
        Me.Bt_AgregarProgramacion.Text = "Agregar a Programación"
        Me.Bt_AgregarProgramacion.UseVisualStyleBackColor = True
        '
        'Lb_TextoFechaProgramaFin
        '
        Me.Lb_TextoFechaProgramaFin.AutoSize = True
        Me.Lb_TextoFechaProgramaFin.Location = New System.Drawing.Point(220, 16)
        Me.Lb_TextoFechaProgramaFin.Name = "Lb_TextoFechaProgramaFin"
        Me.Lb_TextoFechaProgramaFin.Size = New System.Drawing.Size(36, 13)
        Me.Lb_TextoFechaProgramaFin.TabIndex = 12
        Me.Lb_TextoFechaProgramaFin.Text = "hasta:"
        '
        'Dtp_FechaProgramaFin
        '
        Me.Dtp_FechaProgramaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaProgramaFin.Location = New System.Drawing.Point(259, 13)
        Me.Dtp_FechaProgramaFin.Name = "Dtp_FechaProgramaFin"
        Me.Dtp_FechaProgramaFin.ShowCheckBox = True
        Me.Dtp_FechaProgramaFin.Size = New System.Drawing.Size(112, 20)
        Me.Dtp_FechaProgramaFin.TabIndex = 11
        '
        'Pn_TituloProgramacion
        '
        Me.Pn_TituloProgramacion.Controls.Add(Me.Lb_TextoTituloProgramacion)
        Me.Pn_TituloProgramacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloProgramacion.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloProgramacion.Name = "Pn_TituloProgramacion"
        Me.Pn_TituloProgramacion.Size = New System.Drawing.Size(984, 24)
        Me.Pn_TituloProgramacion.TabIndex = 4
        '
        'Lb_TextoTituloProgramacion
        '
        Me.Lb_TextoTituloProgramacion.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_TextoTituloProgramacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoTituloProgramacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoTituloProgramacion.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TextoTituloProgramacion.Name = "Lb_TextoTituloProgramacion"
        Me.Lb_TextoTituloProgramacion.Size = New System.Drawing.Size(984, 24)
        Me.Lb_TextoTituloProgramacion.TabIndex = 0
        Me.Lb_TextoTituloProgramacion.Text = "Agendar calificaciones"
        Me.Lb_TextoTituloProgramacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDPERSONA"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDPERSONA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IDENTIFICACION"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cédula"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ToolTipText = "Número de identificación"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NOMBRECOMPLETO"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ToolTipText = "Nombre completo"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "CODIGOACTIVIDADCAPACITACION"
        Me.DataGridViewTextBoxColumn4.HeaderText = "CODIGOACTIVIDADCAPACITACION"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "NOMBREACTIVIDADCAPACITACION"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Actividad"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ToolTipText = "Actividad capacitación"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "CODIGOENTIDADCERTIFICADORA"
        Me.DataGridViewTextBoxColumn6.HeaderText = "CODIGOENTIDADCERTIFICADORA"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "NOMBREENTIDADCERTIFICADORA"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Entidad"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ToolTipText = "Entidad certificadora"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "IDPERSONA"
        Me.DataGridViewTextBoxColumn8.HeaderText = "IDPERSONA"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "IDENTIFICACION"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Cédula"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ToolTipText = "Número de identificación"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "NOMBRECOMPLETO"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ToolTipText = "Nombre completo"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "CODIGOACTIVIDADCAPACITACION"
        Me.DataGridViewTextBoxColumn11.HeaderText = "CODIGOACTIVIDADCAPACITACION"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ToolTipText = "Entidad certificadora"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "NOMBREACTIVIDADCAPACITACION"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Actividad"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ToolTipText = "Actividad capacitación"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "CODIGOENTIDADCERTIFICADORA"
        Me.DataGridViewTextBoxColumn13.HeaderText = "CODIGOENTIDADCERTIFICADORA"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ToolTipText = "Número de identificación"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "NOMBREENTIDADCERTIFICADORA"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Entidad"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ToolTipText = "Entidad certificadora"
        '
        'CalendarColumn1
        '
        Me.CalendarColumn1.DataPropertyName = "FECHAPROGRAMADA"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.CalendarColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.CalendarColumn1.HeaderText = "Fecha"
        Me.CalendarColumn1.Name = "CalendarColumn1"
        Me.CalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CalendarColumn1.ToolTipText = "Fecha programada"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "FECHAPROGRAMADA"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ToolTipText = "Fecha programada"
        '
        'Fr_ProgramarCapacitaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.Sc_Programacion)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Name = "Fr_ProgramarCapacitaciones"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Programar calificaciones"
        Me.Flp_Botones.ResumeLayout(False)
        CType(Me.Dgv_Personal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_ControlesCalificaciones.ResumeLayout(False)
        Me.Pn_ControlesCalificaciones.PerformLayout()
        Me.Sc_Programacion.Panel1.ResumeLayout(False)
        Me.Sc_Programacion.Panel2.ResumeLayout(False)
        CType(Me.Sc_Programacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_Programacion.ResumeLayout(False)
        Me.Sc_Actividades.Panel1.ResumeLayout(False)
        Me.Sc_Actividades.Panel2.ResumeLayout(False)
        CType(Me.Sc_Actividades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sc_Actividades.ResumeLayout(False)
        Me.Pn_ControlesPersonal.ResumeLayout(False)
        Me.Pn_ControlesPersonal.PerformLayout()
        Me.Pn_TituloPersonal.ResumeLayout(False)
        CType(Me.Dgv_Calificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_TituloCalificaciones.ResumeLayout(False)
        CType(Me.Dgv_Programacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_ControlesProgramacion.ResumeLayout(False)
        Me.Pn_ControlesProgramacion.PerformLayout()
        Me.Pn_TituloProgramacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Dgv_Personal As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Pn_ControlesCalificaciones As System.Windows.Forms.Panel
    Friend WithEvents Lb_TextoActividad As System.Windows.Forms.Label
    Friend WithEvents Cb_ActividadCapacitacion As System.Windows.Forms.ComboBox
    Friend WithEvents Dtp_FechaProgramaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_TextoFechaProgramaInicio As System.Windows.Forms.Label
    Friend WithEvents Sc_Programacion As System.Windows.Forms.SplitContainer
    Friend WithEvents Sc_Actividades As System.Windows.Forms.SplitContainer
    Friend WithEvents Pn_ControlesPersonal As System.Windows.Forms.Panel
    Friend WithEvents Cubp_Persona As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_TextoPersona As System.Windows.Forms.Label
    Friend WithEvents Bt_AgregarPersona As System.Windows.Forms.Button
    Friend WithEvents Pn_TituloPersonal As System.Windows.Forms.Panel
    Friend WithEvents Pn_TituloCalificaciones As System.Windows.Forms.Panel
    Friend WithEvents Pn_TituloProgramacion As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Calificaciones As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv_Programacion As System.Windows.Forms.DataGridView
    Friend WithEvents Lb_TextoTituloPersonal As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoTituloCalificaciones As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoTituloProgramacion As System.Windows.Forms.Label
    Friend WithEvents Bt_AgregarCalificacion As System.Windows.Forms.Button
    Friend WithEvents Tt_ProgramarCapacitaciones As System.Windows.Forms.ToolTip
    Friend WithEvents Pn_ControlesProgramacion As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarProgramacion As System.Windows.Forms.Button
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
    Friend WithEvents CalendarColumn1 As Persona.CalendarColumn
    Friend WithEvents ColPer_IdPersona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPer_NombreCompleto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPer_Identificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lb_TextoFechaProgramaFin As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaProgramaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents ColCal_CodigoActividadCapacitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCal_NombreActividadCapacitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPro_CodigoActividadCapacitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPro_NombreActividadCapacitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPro_Idpersona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPro_Identificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPro_NombreCompleto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPro_FechaProgramaInicio As Persona.CalendarColumn
    Friend WithEvents ColPro_FechaProgramaFin As Persona.CalendarColumn
End Class
