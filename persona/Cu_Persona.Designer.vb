<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Persona
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cu_Persona))
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Dgv_Persona = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Lb_CantidadReportes = New System.Windows.Forms.Label()
        Me.Pn_Propiedades = New System.Windows.Forms.Panel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Pg_DetalleLista = New System.Windows.Forms.PropertyGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pb_FotoPersona = New System.Windows.Forms.PictureBox()
        Me.Ck_MostrarFotoPersona = New System.Windows.Forms.CheckBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Pn_Calificaciones = New System.Windows.Forms.Panel()
        Me.Dgv_Calificaciones = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Lb_CantidadCalificaciones = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Nbc_Persona = New NetBarControl.NetBarControl()
        Me.Nbg_VerificarEstado = New NetBarControl.NetBarGroup()
        Me.Nbi_RegistrarEstado = New NetBarControl.NetBarItem()
        Me.Nbi_ConsultarEstado = New NetBarControl.NetBarItem()
        Me.Nbi_VerResumen = New NetBarControl.NetBarItem()
        Me.Nbi_HistorialConsultas = New NetBarControl.NetBarItem()
        Me.Nbi_AgregarPersonaSeguridad = New NetBarControl.NetBarItem()
        Me.Nbg_Persona = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarPersonas = New NetBarControl.NetBarItem()
        Me.Nbi_VerPersona = New NetBarControl.NetBarItem()
        Me.Nbi_RegistrarPersona = New NetBarControl.NetBarItem()
        Me.Nbi_RegistrarPersonaBásico = New NetBarControl.NetBarItem()
        Me.Nbi_EditarRegistroPersona = New NetBarControl.NetBarItem()
        Me.Nbi_EditarPersonaBasico = New NetBarControl.NetBarItem()
        Me.Nbi_DesactivarPersona = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarPersona = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirFormatos = New NetBarControl.NetBarItem()
        Me.Nbi_RegistrarContrato = New NetBarControl.NetBarItem()
        Me.Nbi_SubirValidacionHDeVida = New NetBarControl.NetBarItem()
        Me.Nbi_VerValidacionHDeVida = New NetBarControl.NetBarItem()
        Me.Nbg_Examenes = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarExamenes = New NetBarControl.NetBarItem()
        Me.Nbi_EnviarAExamenes = New NetBarControl.NetBarItem()
        Me.Nbi_HabilitarEdición = New NetBarControl.NetBarItem()
        Me.Nbi_EditarExamen = New NetBarControl.NetBarItem()
        Me.Nbi_ConceptoMedico = New NetBarControl.NetBarItem()
        Me.Nbi_VerExamen = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarExamenes = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirExamenes = New NetBarControl.NetBarItem()
        Me.Nbi_AgregarVacunas = New NetBarControl.NetBarItem()
        Me.Nbg_COVID19 = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarEncuestas = New NetBarControl.NetBarItem()
        Me.Nbi_CrearEncuesta = New NetBarControl.NetBarItem()
        Me.Nbi_VerEncuestaCovid = New NetBarControl.NetBarItem()
        Me.Nbi_EditarEncuesta = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarEncuesta = New NetBarControl.NetBarItem()
        Me.Nbi_CancelarEncuesta = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirEncuesta = New NetBarControl.NetBarItem()
        Me.Nbi_AutorizarIngresoCOVID = New NetBarControl.NetBarItem()
        Me.Nbi_AutorizarIngresoMultiple = New NetBarControl.NetBarItem()
        Me.Nbi_RegistrarTemperatura = New NetBarControl.NetBarItem()
        Me.Nbg_ProgramaCalificación = New NetBarControl.NetBarGroup()
        Me.Nbi_CargarCalificaciones = New NetBarControl.NetBarItem()
        Me.Nbi_AgregarCalificación = New NetBarControl.NetBarItem()
        Me.Nbi_GestionarCalificaciones = New NetBarControl.NetBarItem()
        Me.Nbi_ProgramarCapacitaciones = New NetBarControl.NetBarItem()
        Me.Nbi_ImprimirCarnet = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarCalificacion = New NetBarControl.NetBarItem()
        Me.Nbg_EvalaucionDesempeño = New NetBarControl.NetBarGroup()
        Me.Nbi_ListarEvaluacion = New NetBarControl.NetBarItem()
        Me.Nbi_CrearEvaluacion = New NetBarControl.NetBarItem()
        Me.Nbi_VerEvaluacion = New NetBarControl.NetBarItem()
        Me.Nbi_EditarEvaluacion = New NetBarControl.NetBarItem()
        Me.Nbi_BuscarEvaluacion = New NetBarControl.NetBarItem()
        Me.Nbi_EnviarCorreo = New NetBarControl.NetBarItem()
        Me.Nbi_EnviarCorreoBloque = New NetBarControl.NetBarItem()
        Me.Im_Defecto = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Dgv_Persona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Pn_Propiedades.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Pb_FotoPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Calificaciones.SuspendLayout()
        CType(Me.Dgv_Calificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel3)
        Me.Panel6.Controls.Add(Me.Splitter1)
        Me.Panel6.Controls.Add(Me.Pn_Calificaciones)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(190, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(673, 463)
        Me.Panel6.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.SplitContainer1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(673, 276)
        Me.Panel3.TabIndex = 12
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Dgv_Persona)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Pn_Propiedades)
        Me.SplitContainer1.Size = New System.Drawing.Size(673, 276)
        Me.SplitContainer1.SplitterDistance = 359
        Me.SplitContainer1.TabIndex = 9
        '
        'Dgv_Persona
        '
        Me.Dgv_Persona.AllowUserToAddRows = False
        Me.Dgv_Persona.AllowUserToDeleteRows = False
        Me.Dgv_Persona.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Persona.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_Persona.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv_Persona.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_Persona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Persona.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_Persona.Name = "Dgv_Persona"
        Me.Dgv_Persona.ReadOnly = True
        Me.Dgv_Persona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Persona.Size = New System.Drawing.Size(359, 258)
        Me.Dgv_Persona.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel2.Controls.Add(Me.Lb_CantidadReportes)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(359, 18)
        Me.Panel2.TabIndex = 8
        '
        'Lb_CantidadReportes
        '
        Me.Lb_CantidadReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_CantidadReportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadReportes.ForeColor = System.Drawing.Color.Black
        Me.Lb_CantidadReportes.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CantidadReportes.Name = "Lb_CantidadReportes"
        Me.Lb_CantidadReportes.Size = New System.Drawing.Size(359, 18)
        Me.Lb_CantidadReportes.TabIndex = 0
        Me.Lb_CantidadReportes.Text = "Cantidad de Personas:"
        Me.Lb_CantidadReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pn_Propiedades
        '
        Me.Pn_Propiedades.AutoSize = True
        Me.Pn_Propiedades.BackColor = System.Drawing.SystemColors.Control
        Me.Pn_Propiedades.Controls.Add(Me.SplitContainer2)
        Me.Pn_Propiedades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Propiedades.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Propiedades.Name = "Pn_Propiedades"
        Me.Pn_Propiedades.Size = New System.Drawing.Size(310, 276)
        Me.Pn_Propiedades.TabIndex = 11
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Pg_DetalleLista)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Pb_FotoPersona)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Ck_MostrarFotoPersona)
        Me.SplitContainer2.Panel2MinSize = 180
        Me.SplitContainer2.Size = New System.Drawing.Size(310, 276)
        Me.SplitContainer2.SplitterDistance = 234
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 2
        '
        'Pg_DetalleLista
        '
        Me.Pg_DetalleLista.CategoryForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Pg_DetalleLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pg_DetalleLista.Location = New System.Drawing.Point(0, 18)
        Me.Pg_DetalleLista.Name = "Pg_DetalleLista"
        Me.Pg_DetalleLista.Size = New System.Drawing.Size(310, 216)
        Me.Pg_DetalleLista.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(310, 18)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(310, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Propiedades"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pb_FotoPersona
        '
        Me.Pb_FotoPersona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pb_FotoPersona.Location = New System.Drawing.Point(0, 27)
        Me.Pb_FotoPersona.Name = "Pb_FotoPersona"
        Me.Pb_FotoPersona.Size = New System.Drawing.Size(310, 153)
        Me.Pb_FotoPersona.TabIndex = 3
        Me.Pb_FotoPersona.TabStop = False
        '
        'Ck_MostrarFotoPersona
        '
        Me.Ck_MostrarFotoPersona.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Ck_MostrarFotoPersona.Dock = System.Windows.Forms.DockStyle.Top
        Me.Ck_MostrarFotoPersona.Location = New System.Drawing.Point(0, 0)
        Me.Ck_MostrarFotoPersona.Name = "Ck_MostrarFotoPersona"
        Me.Ck_MostrarFotoPersona.Size = New System.Drawing.Size(310, 27)
        Me.Ck_MostrarFotoPersona.TabIndex = 4
        Me.Ck_MostrarFotoPersona.Text = "Mostrar Foto Persona"
        Me.Ck_MostrarFotoPersona.UseVisualStyleBackColor = False
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 276)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(673, 1)
        Me.Splitter1.TabIndex = 10
        Me.Splitter1.TabStop = False
        '
        'Pn_Calificaciones
        '
        Me.Pn_Calificaciones.Controls.Add(Me.Dgv_Calificaciones)
        Me.Pn_Calificaciones.Controls.Add(Me.Panel4)
        Me.Pn_Calificaciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Calificaciones.Location = New System.Drawing.Point(0, 277)
        Me.Pn_Calificaciones.Name = "Pn_Calificaciones"
        Me.Pn_Calificaciones.Size = New System.Drawing.Size(673, 186)
        Me.Pn_Calificaciones.TabIndex = 10
        '
        'Dgv_Calificaciones
        '
        Me.Dgv_Calificaciones.AllowUserToAddRows = False
        Me.Dgv_Calificaciones.AllowUserToDeleteRows = False
        Me.Dgv_Calificaciones.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleGreen
        Me.Dgv_Calificaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_Calificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Calificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Calificaciones.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_Calificaciones.Name = "Dgv_Calificaciones"
        Me.Dgv_Calificaciones.ReadOnly = True
        Me.Dgv_Calificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Calificaciones.Size = New System.Drawing.Size(673, 168)
        Me.Dgv_Calificaciones.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel4.Controls.Add(Me.Lb_CantidadCalificaciones)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(673, 18)
        Me.Panel4.TabIndex = 9
        '
        'Lb_CantidadCalificaciones
        '
        Me.Lb_CantidadCalificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_CantidadCalificaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadCalificaciones.ForeColor = System.Drawing.Color.Black
        Me.Lb_CantidadCalificaciones.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CantidadCalificaciones.Name = "Lb_CantidadCalificaciones"
        Me.Lb_CantidadCalificaciones.Size = New System.Drawing.Size(673, 18)
        Me.Lb_CantidadCalificaciones.TabIndex = 0
        Me.Lb_CantidadCalificaciones.Text = "Cantidad de Personas:"
        Me.Lb_CantidadCalificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "images.jpg")
        '
        'Nbc_Persona
        '
        Me.Nbc_Persona.ActiveGroup = Me.Nbg_Examenes
        Me.Nbc_Persona.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_Persona.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_Persona, Me.Nbg_VerificarEstado, Me.Nbg_Examenes, Me.Nbg_COVID19, Me.Nbg_ProgramaCalificación, Me.Nbg_EvalaucionDesempeño})
        Me.Nbc_Persona.GroupsFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbc_Persona.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_Persona.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_Persona.Location = New System.Drawing.Point(0, 0)
        Me.Nbc_Persona.Name = "Nbc_Persona"
        Me.Nbc_Persona.ShowOverflowPanel = False
        Me.Nbc_Persona.Size = New System.Drawing.Size(190, 463)
        Me.Nbc_Persona.TabIndex = 3
        Me.Nbc_Persona.Tag = "32"
        Me.Nbc_Persona.Text = "NetBarControl1"
        '
        'Nbg_VerificarEstado
        '
        Me.Nbg_VerificarEstado.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_RegistrarEstado, Me.Nbi_ConsultarEstado, Me.Nbi_VerResumen, Me.Nbi_HistorialConsultas, Me.Nbi_AgregarPersonaSeguridad})
        Me.Nbg_VerificarEstado.Name = "Nbg_VerificarEstado"
        Me.Nbg_VerificarEstado.Tag = "866"
        Me.Nbg_VerificarEstado.Text = "Verificar Estado"
        '
        'Nbi_RegistrarEstado
        '
        Me.Nbi_RegistrarEstado.Name = "Nbi_RegistrarEstado"
        Me.Nbi_RegistrarEstado.Tag = "867"
        Me.Nbi_RegistrarEstado.Text = "Registrar Estado"
        '
        'Nbi_ConsultarEstado
        '
        Me.Nbi_ConsultarEstado.Name = "Nbi_ConsultarEstado"
        Me.Nbi_ConsultarEstado.Tag = "868"
        Me.Nbi_ConsultarEstado.Text = "Consultar Estado"
        '
        'Nbi_VerResumen
        '
        Me.Nbi_VerResumen.Name = "Nbi_VerResumen"
        Me.Nbi_VerResumen.Tag = "869"
        Me.Nbi_VerResumen.Text = "Ver Resumen"
        '
        'Nbi_HistorialConsultas
        '
        Me.Nbi_HistorialConsultas.Name = "Nbi_HistorialConsultas"
        Me.Nbi_HistorialConsultas.Tag = "870"
        Me.Nbi_HistorialConsultas.Text = "Historial Consultas"
        '
        'Nbi_AgregarPersonaSeguridad
        '
        Me.Nbi_AgregarPersonaSeguridad.Name = "Nbi_AgregarPersonaSeguridad"
        Me.Nbi_AgregarPersonaSeguridad.Tag = "885"
        Me.Nbi_AgregarPersonaSeguridad.Text = "Agregar Persona"
        '
        'Nbg_Persona
        '
        Me.Nbg_Persona.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarPersonas, Me.Nbi_VerPersona, Me.Nbi_RegistrarPersona, Me.Nbi_RegistrarPersonaBásico, Me.Nbi_EditarRegistroPersona, Me.Nbi_EditarPersonaBasico, Me.Nbi_DesactivarPersona, Me.Nbi_BuscarPersona, Me.Nbi_ImprimirFormatos, Me.Nbi_RegistrarContrato, Me.Nbi_SubirValidacionHDeVida, Me.Nbi_VerValidacionHDeVida})
        Me.Nbg_Persona.Name = "Nbg_Persona"
        Me.Nbg_Persona.SmallImage = CType(resources.GetObject("Nbg_Persona.SmallImage"), System.Drawing.Image)
        Me.Nbg_Persona.Tag = "33"
        Me.Nbg_Persona.Text = "Persona"
        '
        'Nbi_CargarPersonas
        '
        Me.Nbi_CargarPersonas.Name = "Nbi_CargarPersonas"
        Me.Nbi_CargarPersonas.Tag = "560"
        Me.Nbi_CargarPersonas.Text = "Cargar Personas"
        '
        'Nbi_VerPersona
        '
        Me.Nbi_VerPersona.Name = "Nbi_VerPersona"
        Me.Nbi_VerPersona.SmallImage = Global.Persona.My.Resources.Resources.FVerPersona
        Me.Nbi_VerPersona.Tag = "209"
        Me.Nbi_VerPersona.Text = "Ver Persona"
        '
        'Nbi_RegistrarPersona
        '
        Me.Nbi_RegistrarPersona.Name = "Nbi_RegistrarPersona"
        Me.Nbi_RegistrarPersona.SmallImage = Global.Persona.My.Resources.Resources.FNuevoPersona
        Me.Nbi_RegistrarPersona.Tag = "39"
        Me.Nbi_RegistrarPersona.Text = "Registrar Persona"
        '
        'Nbi_RegistrarPersonaBásico
        '
        Me.Nbi_RegistrarPersonaBásico.Name = "Nbi_RegistrarPersonaBásico"
        Me.Nbi_RegistrarPersonaBásico.Tag = "39"
        Me.Nbi_RegistrarPersonaBásico.Text = "Registrar Persona Básico"
        '
        'Nbi_EditarRegistroPersona
        '
        Me.Nbi_EditarRegistroPersona.Name = "Nbi_EditarRegistroPersona"
        Me.Nbi_EditarRegistroPersona.SmallImage = Global.Persona.My.Resources.Resources.FEditarPersona
        Me.Nbi_EditarRegistroPersona.Tag = "40"
        Me.Nbi_EditarRegistroPersona.Text = "Editar Persona"
        '
        'Nbi_EditarPersonaBasico
        '
        Me.Nbi_EditarPersonaBasico.Name = "Nbi_EditarPersonaBasico"
        Me.Nbi_EditarPersonaBasico.Tag = "40"
        Me.Nbi_EditarPersonaBasico.Text = "Editar Persona Básico"
        '
        'Nbi_DesactivarPersona
        '
        Me.Nbi_DesactivarPersona.Name = "Nbi_DesactivarPersona"
        Me.Nbi_DesactivarPersona.SmallImage = Global.Persona.My.Resources.Resources.FDesactivarPersona
        Me.Nbi_DesactivarPersona.Tag = "41"
        Me.Nbi_DesactivarPersona.Text = "Desactivar"
        '
        'Nbi_BuscarPersona
        '
        Me.Nbi_BuscarPersona.Name = "Nbi_BuscarPersona"
        Me.Nbi_BuscarPersona.SmallImage = Global.Persona.My.Resources.Resources.Buscar
        Me.Nbi_BuscarPersona.Tag = "555"
        Me.Nbi_BuscarPersona.Text = "Buscar Persona"
        '
        'Nbi_ImprimirFormatos
        '
        Me.Nbi_ImprimirFormatos.Name = "Nbi_ImprimirFormatos"
        Me.Nbi_ImprimirFormatos.Tag = "45"
        Me.Nbi_ImprimirFormatos.Text = "Imprimir Formatos"
        '
        'Nbi_RegistrarContrato
        '
        Me.Nbi_RegistrarContrato.Name = "Nbi_RegistrarContrato"
        Me.Nbi_RegistrarContrato.Tag = "42"
        Me.Nbi_RegistrarContrato.Text = "Registrar Contrato"
        '
        'Nbi_SubirValidacionHDeVida
        '
        Me.Nbi_SubirValidacionHDeVida.Name = "Nbi_SubirValidacionHDeVida"
        Me.Nbi_SubirValidacionHDeVida.Tag = "883"
        Me.Nbi_SubirValidacionHDeVida.Text = "Subir Validación Hoja de Vida"
        '
        'Nbi_VerValidacionHDeVida
        '
        Me.Nbi_VerValidacionHDeVida.Name = "Nbi_VerValidacionHDeVida"
        Me.Nbi_VerValidacionHDeVida.Tag = "884"
        Me.Nbi_VerValidacionHDeVida.Text = "Ver Validación Hoja de Vida"
        '
        'Nbg_Examenes
        '
        Me.Nbg_Examenes.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarExamenes, Me.Nbi_EnviarAExamenes, Me.Nbi_HabilitarEdición, Me.Nbi_EditarExamen, Me.Nbi_ConceptoMedico, Me.Nbi_VerExamen, Me.Nbi_BuscarExamenes, Me.Nbi_ImprimirExamenes, Me.Nbi_AgregarVacunas})
        Me.Nbg_Examenes.Name = "Nbg_Examenes"
        Me.Nbg_Examenes.Tag = "701"
        Me.Nbg_Examenes.Text = "Exámenes Médicos"
        '
        'Nbi_ListarExamenes
        '
        Me.Nbi_ListarExamenes.Name = "Nbi_ListarExamenes"
        Me.Nbi_ListarExamenes.Tag = "704"
        Me.Nbi_ListarExamenes.Text = "Cargar Listado"
        '
        'Nbi_EnviarAExamenes
        '
        Me.Nbi_EnviarAExamenes.Name = "Nbi_EnviarAExamenes"
        Me.Nbi_EnviarAExamenes.Tag = "703"
        Me.Nbi_EnviarAExamenes.Text = "Enviar a Exámenes"
        '
        'Nbi_HabilitarEdición
        '
        Me.Nbi_HabilitarEdición.Name = "Nbi_HabilitarEdición"
        Me.Nbi_HabilitarEdición.Tag = "881"
        Me.Nbi_HabilitarEdición.Text = "Habilitar Edición"
        '
        'Nbi_EditarExamen
        '
        Me.Nbi_EditarExamen.Name = "Nbi_EditarExamen"
        Me.Nbi_EditarExamen.Tag = "882"
        Me.Nbi_EditarExamen.Text = "Editar Examen"
        '
        'Nbi_ConceptoMedico
        '
        Me.Nbi_ConceptoMedico.Name = "Nbi_ConceptoMedico"
        Me.Nbi_ConceptoMedico.Tag = "707"
        Me.Nbi_ConceptoMedico.Text = "Agregar Concepto"
        '
        'Nbi_VerExamen
        '
        Me.Nbi_VerExamen.Name = "Nbi_VerExamen"
        Me.Nbi_VerExamen.Tag = "706"
        Me.Nbi_VerExamen.Text = "Ver Examen"
        '
        'Nbi_BuscarExamenes
        '
        Me.Nbi_BuscarExamenes.Name = "Nbi_BuscarExamenes"
        Me.Nbi_BuscarExamenes.Tag = "705"
        Me.Nbi_BuscarExamenes.Text = "Buscar"
        '
        'Nbi_ImprimirExamenes
        '
        Me.Nbi_ImprimirExamenes.Name = "Nbi_ImprimirExamenes"
        Me.Nbi_ImprimirExamenes.Tag = "702"
        Me.Nbi_ImprimirExamenes.Text = "Reimpresión de Exámenes"
        '
        'Nbi_AgregarVacunas
        '
        Me.Nbi_AgregarVacunas.Name = "Nbi_AgregarVacunas"
        Me.Nbi_AgregarVacunas.Tag = "954"
        Me.Nbi_AgregarVacunas.Text = "Agregar Vacunas"
        '
        'Nbg_COVID19
        '
        Me.Nbg_COVID19.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarEncuestas, Me.Nbi_CrearEncuesta, Me.Nbi_VerEncuestaCovid, Me.Nbi_EditarEncuesta, Me.Nbi_BuscarEncuesta, Me.Nbi_CancelarEncuesta, Me.Nbi_ImprimirEncuesta, Me.Nbi_AutorizarIngresoCOVID, Me.Nbi_AutorizarIngresoMultiple, Me.Nbi_RegistrarTemperatura})
        Me.Nbg_COVID19.Name = "Nbg_COVID19"
        Me.Nbg_COVID19.Tag = "773"
        Me.Nbg_COVID19.Text = "COVID-19"
        '
        'Nbi_CargarEncuestas
        '
        Me.Nbi_CargarEncuestas.Name = "Nbi_CargarEncuestas"
        Me.Nbi_CargarEncuestas.Tag = "774"
        Me.Nbi_CargarEncuestas.Text = "Cargar Encuestas COVID"
        '
        'Nbi_CrearEncuesta
        '
        Me.Nbi_CrearEncuesta.Name = "Nbi_CrearEncuesta"
        Me.Nbi_CrearEncuesta.Tag = "775"
        Me.Nbi_CrearEncuesta.Text = "Crear Encuesta COVID"
        '
        'Nbi_VerEncuestaCovid
        '
        Me.Nbi_VerEncuestaCovid.Name = "Nbi_VerEncuestaCovid"
        Me.Nbi_VerEncuestaCovid.Text = "Ver Encuesta Covid"
        '
        'Nbi_EditarEncuesta
        '
        Me.Nbi_EditarEncuesta.Name = "Nbi_EditarEncuesta"
        Me.Nbi_EditarEncuesta.Tag = "776"
        Me.Nbi_EditarEncuesta.Text = "Editar Encuesta COVID"
        '
        'Nbi_BuscarEncuesta
        '
        Me.Nbi_BuscarEncuesta.Name = "Nbi_BuscarEncuesta"
        Me.Nbi_BuscarEncuesta.Tag = "777"
        Me.Nbi_BuscarEncuesta.Text = "Buscar Encuesta COVID"
        '
        'Nbi_CancelarEncuesta
        '
        Me.Nbi_CancelarEncuesta.Name = "Nbi_CancelarEncuesta"
        Me.Nbi_CancelarEncuesta.Tag = "778"
        Me.Nbi_CancelarEncuesta.Text = "Cancelar Encuesta COVID"
        '
        'Nbi_ImprimirEncuesta
        '
        Me.Nbi_ImprimirEncuesta.Name = "Nbi_ImprimirEncuesta"
        Me.Nbi_ImprimirEncuesta.Tag = "779"
        Me.Nbi_ImprimirEncuesta.Text = "Imprimir Encuesta COVID"
        '
        'Nbi_AutorizarIngresoCOVID
        '
        Me.Nbi_AutorizarIngresoCOVID.Name = "Nbi_AutorizarIngresoCOVID"
        Me.Nbi_AutorizarIngresoCOVID.Tag = "781"
        Me.Nbi_AutorizarIngresoCOVID.Text = "Autorizar Ingreso Una Vez"
        '
        'Nbi_AutorizarIngresoMultiple
        '
        Me.Nbi_AutorizarIngresoMultiple.Name = "Nbi_AutorizarIngresoMultiple"
        Me.Nbi_AutorizarIngresoMultiple.Tag = "781"
        Me.Nbi_AutorizarIngresoMultiple.Text = "Autorizar Ingreso Multiple"
        '
        'Nbi_RegistrarTemperatura
        '
        Me.Nbi_RegistrarTemperatura.Name = "Nbi_RegistrarTemperatura"
        Me.Nbi_RegistrarTemperatura.Text = "Registrar Temperatura"
        '
        'Nbg_ProgramaCalificación
        '
        Me.Nbg_ProgramaCalificación.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_CargarCalificaciones, Me.Nbi_AgregarCalificación, Me.Nbi_GestionarCalificaciones, Me.Nbi_ProgramarCapacitaciones, Me.Nbi_ImprimirCarnet, Me.Nbi_BuscarCalificacion})
        Me.Nbg_ProgramaCalificación.Name = "Nbg_ProgramaCalificación"
        Me.Nbg_ProgramaCalificación.Tag = "718"
        Me.Nbg_ProgramaCalificación.Text = "Programa Calificación"
        '
        'Nbi_CargarCalificaciones
        '
        Me.Nbi_CargarCalificaciones.Name = "Nbi_CargarCalificaciones"
        Me.Nbi_CargarCalificaciones.Text = "Cargar Calificaciones"
        '
        'Nbi_AgregarCalificación
        '
        Me.Nbi_AgregarCalificación.Name = "Nbi_AgregarCalificación"
        Me.Nbi_AgregarCalificación.Tag = "719"
        Me.Nbi_AgregarCalificación.Text = "Agregar Calificación"
        '
        'Nbi_GestionarCalificaciones
        '
        Me.Nbi_GestionarCalificaciones.Name = "Nbi_GestionarCalificaciones"
        Me.Nbi_GestionarCalificaciones.Tag = "720"
        Me.Nbi_GestionarCalificaciones.Text = "Gestionar Calificaciones"
        '
        'Nbi_ProgramarCapacitaciones
        '
        Me.Nbi_ProgramarCapacitaciones.Name = "Nbi_ProgramarCapacitaciones"
        Me.Nbi_ProgramarCapacitaciones.Tag = "772"
        Me.Nbi_ProgramarCapacitaciones.Text = "Programar Capacitaciones"
        '
        'Nbi_ImprimirCarnet
        '
        Me.Nbi_ImprimirCarnet.Name = "Nbi_ImprimirCarnet"
        Me.Nbi_ImprimirCarnet.Tag = "721"
        Me.Nbi_ImprimirCarnet.Text = "Imprimir Carnet"
        '
        'Nbi_BuscarCalificacion
        '
        Me.Nbi_BuscarCalificacion.Name = "Nbi_BuscarCalificacion"
        Me.Nbi_BuscarCalificacion.Text = "Buscar Calificación"
        '
        'Nbg_EvalaucionDesempeño
        '
        Me.Nbg_EvalaucionDesempeño.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_ListarEvaluacion, Me.Nbi_CrearEvaluacion, Me.Nbi_VerEvaluacion, Me.Nbi_EditarEvaluacion, Me.Nbi_BuscarEvaluacion, Me.Nbi_EnviarCorreo, Me.Nbi_EnviarCorreoBloque})
        Me.Nbg_EvalaucionDesempeño.Name = "Nbg_EvalaucionDesempeño"
        Me.Nbg_EvalaucionDesempeño.Tag = "858"
        Me.Nbg_EvalaucionDesempeño.Text = "Evaluación Desempeño"
        '
        'Nbi_ListarEvaluacion
        '
        Me.Nbi_ListarEvaluacion.Name = "Nbi_ListarEvaluacion"
        Me.Nbi_ListarEvaluacion.Tag = "859"
        Me.Nbi_ListarEvaluacion.Text = "Listar"
        '
        'Nbi_CrearEvaluacion
        '
        Me.Nbi_CrearEvaluacion.Name = "Nbi_CrearEvaluacion"
        Me.Nbi_CrearEvaluacion.Tag = "860"
        Me.Nbi_CrearEvaluacion.Text = "Crear"
        '
        'Nbi_VerEvaluacion
        '
        Me.Nbi_VerEvaluacion.Name = "Nbi_VerEvaluacion"
        Me.Nbi_VerEvaluacion.Tag = "861"
        Me.Nbi_VerEvaluacion.Text = "Ver"
        '
        'Nbi_EditarEvaluacion
        '
        Me.Nbi_EditarEvaluacion.Name = "Nbi_EditarEvaluacion"
        Me.Nbi_EditarEvaluacion.Tag = "862"
        Me.Nbi_EditarEvaluacion.Text = "Editar"
        '
        'Nbi_BuscarEvaluacion
        '
        Me.Nbi_BuscarEvaluacion.Name = "Nbi_BuscarEvaluacion"
        Me.Nbi_BuscarEvaluacion.Tag = "863"
        Me.Nbi_BuscarEvaluacion.Text = "Buscar"
        '
        'Nbi_EnviarCorreo
        '
        Me.Nbi_EnviarCorreo.Name = "Nbi_EnviarCorreo"
        Me.Nbi_EnviarCorreo.Tag = "864"
        Me.Nbi_EnviarCorreo.Text = "Enviar Correos"
        '
        'Nbi_EnviarCorreoBloque
        '
        Me.Nbi_EnviarCorreoBloque.Name = "Nbi_EnviarCorreoBloque"
        Me.Nbi_EnviarCorreoBloque.Tag = "865"
        Me.Nbi_EnviarCorreoBloque.Text = "Enviar Correos en Bloque"
        '
        'Im_Defecto
        '
        Me.Im_Defecto.ImageStream = CType(resources.GetObject("Im_Defecto.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Im_Defecto.TransparentColor = System.Drawing.Color.Transparent
        Me.Im_Defecto.Images.SetKeyName(0, "defecto.jpg")
        '
        'Cu_Persona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Nbc_Persona)
        Me.Name = "Cu_Persona"
        Me.Size = New System.Drawing.Size(863, 463)
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Dgv_Persona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Pn_Propiedades.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.Pb_FotoPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Calificaciones.ResumeLayout(False)
        CType(Me.Dgv_Calificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Persona As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Lb_CantidadReportes As System.Windows.Forms.Label
    Friend WithEvents IDPERSONADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDENTIFICACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LUGARDEEXPEDICIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRECOMPLETODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHANACIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LUGARNACIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GENERODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TARJETAPROFESIONALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRUPOSANGUINEODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRETIPOESTADOCIVILDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LICENCIACONDUCCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CORREOELECTRONICODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMEROCONTACTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIRECCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Nbc_Persona As NetBarControl.NetBarControl
    Friend WithEvents Nbg_Persona As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_RegistrarPersona As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarRegistroPersona As NetBarControl.NetBarItem
    Friend WithEvents Nbi_DesactivarPersona As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerPersona As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarPersona As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarPersonas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirFormatos As NetBarControl.NetBarItem
    Friend WithEvents Nbi_RegistrarContrato As NetBarControl.NetBarItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Pn_Propiedades As System.Windows.Forms.Panel
    Friend WithEvents Pg_DetalleLista As System.Windows.Forms.PropertyGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Nbi_RegistrarPersonaBásico As NetBarControl.NetBarItem
    Friend WithEvents Nbg_Examenes As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_EnviarAExamenes As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirExamenes As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ListarExamenes As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarExamenes As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerExamen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ConceptoMedico As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarPersonaBasico As NetBarControl.NetBarItem
    Friend WithEvents Nbg_ProgramaCalificación As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_AgregarCalificación As NetBarControl.NetBarItem
    Friend WithEvents Nbi_GestionarCalificaciones As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirCarnet As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarCalificaciones As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarCalificacion As NetBarControl.NetBarItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Pn_Calificaciones As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Calificaciones As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Lb_CantidadCalificaciones As System.Windows.Forms.Label
    Friend WithEvents Nbi_ProgramarCapacitaciones As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearEncuesta As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarEncuesta As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CancelarEncuesta As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ImprimirEncuesta As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CargarEncuestas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarEncuesta As NetBarControl.NetBarItem
    Friend WithEvents Nbi_AutorizarIngresoCOVID As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerEncuestaCovid As NetBarControl.NetBarItem
    Friend WithEvents Nbg_COVID19 As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_AutorizarIngresoMultiple As NetBarControl.NetBarItem
    Friend WithEvents Nbi_RegistrarTemperatura As NetBarControl.NetBarItem
    Friend WithEvents Nbg_EvalaucionDesempeño As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_ListarEvaluacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_CrearEvaluacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerEvaluacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarEvaluacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_BuscarEvaluacion As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EnviarCorreo As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EnviarCorreoBloque As NetBarControl.NetBarItem
    Friend WithEvents Nbg_VerificarEstado As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_RegistrarEstado As NetBarControl.NetBarItem
    Friend WithEvents Nbi_ConsultarEstado As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerResumen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HistorialConsultas As NetBarControl.NetBarItem
    Friend WithEvents Nbi_HabilitarEdición As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarExamen As NetBarControl.NetBarItem
    Friend WithEvents Nbi_SubirValidacionHDeVida As NetBarControl.NetBarItem
    Friend WithEvents Nbi_VerValidacionHDeVida As NetBarControl.NetBarItem
    Friend WithEvents Nbi_AgregarPersonaSeguridad As NetBarControl.NetBarItem
    Friend WithEvents Nbi_AgregarVacunas As NetBarControl.NetBarItem
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Pb_FotoPersona As System.Windows.Forms.PictureBox
    Friend WithEvents Ck_MostrarFotoPersona As System.Windows.Forms.CheckBox
    Friend WithEvents Im_Defecto As System.Windows.Forms.ImageList

End Class
