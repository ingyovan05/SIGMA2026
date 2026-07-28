<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_BoletaSalida
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_BoletaSalida))
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cb_HorarioLlegada = New System.Windows.Forms.ComboBox()
        Me.Cb_MinLlegada = New System.Windows.Forms.ComboBox()
        Me.Cb_HoraLlegada = New System.Windows.Forms.ComboBox()
        Me.Cb_horarioSalida = New System.Windows.Forms.ComboBox()
        Me.Cb_minSalida = New System.Windows.Forms.ComboBox()
        Me.Cb_HoraSalida = New System.Windows.Forms.ComboBox()
        Me.Dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cb_TipoDiligencia = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Cu_Trabajador = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_AsociarPersonaTrabajador = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Cu_BuscarPersonaJefedepartamento = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_AsociarPersonaJefeAdministrativo = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaJefedepartamento = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaJefeAdministrativo = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Dtp_HoraLlegadaVigilante = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Dtp_HoraSalidaVigilante = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersonaVigilanteSalida = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_AsociarPersonaVigilanteEntrada = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaVigilanteSalida = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaVigilanteEntrada = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Info
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(618, 30)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "BOLETA DE SALIDA"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(17, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(101, 13)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "Nombre Trabajador:"
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.Location = New System.Drawing.Point(123, 40)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(193, 21)
        Me.Cb_Dependencia.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(46, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Dependencia:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Hora Salida:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(383, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Hora Llegada:"
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Location = New System.Drawing.Point(20, 106)
        Me.Tx_Descripcion.MaxLength = 150
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(557, 74)
        Me.Tx_Descripcion.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Descrición:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Jefe Departamento:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Jefe Administrativo:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cb_HorarioLlegada)
        Me.GroupBox1.Controls.Add(Me.Cb_MinLlegada)
        Me.GroupBox1.Controls.Add(Me.Cb_HoraLlegada)
        Me.GroupBox1.Controls.Add(Me.Cb_horarioSalida)
        Me.GroupBox1.Controls.Add(Me.Cb_minSalida)
        Me.GroupBox1.Controls.Add(Me.Cb_HoraSalida)
        Me.GroupBox1.Controls.Add(Me.Dtp_Fecha)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Cb_TipoDiligencia)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Cu_Trabajador)
        Me.GroupBox1.Controls.Add(Me.Cu_AsociarPersonaTrabajador)
        Me.GroupBox1.Controls.Add(Me.Tx_Descripcion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Cb_Dependencia)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(591, 196)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Trabajador"
        '
        'Cb_HorarioLlegada
        '
        Me.Cb_HorarioLlegada.FormattingEnabled = True
        Me.Cb_HorarioLlegada.Items.AddRange(New Object() {"am", "pm"})
        Me.Cb_HorarioLlegada.Location = New System.Drawing.Point(537, 68)
        Me.Cb_HorarioLlegada.Name = "Cb_HorarioLlegada"
        Me.Cb_HorarioLlegada.Size = New System.Drawing.Size(38, 21)
        Me.Cb_HorarioLlegada.TabIndex = 10
        '
        'Cb_MinLlegada
        '
        Me.Cb_MinLlegada.FormattingEnabled = True
        Me.Cb_MinLlegada.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.Cb_MinLlegada.Location = New System.Drawing.Point(495, 68)
        Me.Cb_MinLlegada.Name = "Cb_MinLlegada"
        Me.Cb_MinLlegada.Size = New System.Drawing.Size(36, 21)
        Me.Cb_MinLlegada.TabIndex = 9
        '
        'Cb_HoraLlegada
        '
        Me.Cb_HoraLlegada.FormattingEnabled = True
        Me.Cb_HoraLlegada.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Cb_HoraLlegada.Location = New System.Drawing.Point(453, 68)
        Me.Cb_HoraLlegada.Name = "Cb_HoraLlegada"
        Me.Cb_HoraLlegada.Size = New System.Drawing.Size(36, 21)
        Me.Cb_HoraLlegada.TabIndex = 8
        '
        'Cb_horarioSalida
        '
        Me.Cb_horarioSalida.FormattingEnabled = True
        Me.Cb_horarioSalida.Items.AddRange(New Object() {"am", "pm"})
        Me.Cb_horarioSalida.Location = New System.Drawing.Point(340, 68)
        Me.Cb_horarioSalida.Name = "Cb_horarioSalida"
        Me.Cb_horarioSalida.Size = New System.Drawing.Size(38, 21)
        Me.Cb_horarioSalida.TabIndex = 7
        '
        'Cb_minSalida
        '
        Me.Cb_minSalida.FormattingEnabled = True
        Me.Cb_minSalida.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.Cb_minSalida.Location = New System.Drawing.Point(298, 68)
        Me.Cb_minSalida.Name = "Cb_minSalida"
        Me.Cb_minSalida.Size = New System.Drawing.Size(36, 21)
        Me.Cb_minSalida.TabIndex = 6
        '
        'Cb_HoraSalida
        '
        Me.Cb_HoraSalida.FormattingEnabled = True
        Me.Cb_HoraSalida.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Cb_HoraSalida.Location = New System.Drawing.Point(256, 68)
        Me.Cb_HoraSalida.Name = "Cb_HoraSalida"
        Me.Cb_HoraSalida.Size = New System.Drawing.Size(36, 21)
        Me.Cb_HoraSalida.TabIndex = 5
        '
        'Dtp_Fecha
        '
        Me.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha.Location = New System.Drawing.Point(67, 68)
        Me.Dtp_Fecha.Name = "Dtp_Fecha"
        Me.Dtp_Fecha.Size = New System.Drawing.Size(122, 20)
        Me.Dtp_Fecha.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Fecha:"
        '
        'Cb_TipoDiligencia
        '
        Me.Cb_TipoDiligencia.FormattingEnabled = True
        Me.Cb_TipoDiligencia.Items.AddRange(New Object() {"Personal", "Laboral"})
        Me.Cb_TipoDiligencia.Location = New System.Drawing.Point(407, 41)
        Me.Cb_TipoDiligencia.Name = "Cb_TipoDiligencia"
        Me.Cb_TipoDiligencia.Size = New System.Drawing.Size(121, 21)
        Me.Cb_TipoDiligencia.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(323, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Tipo Diligencia:"
        '
        'Cu_Trabajador
        '
        Me.Cu_Trabajador.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_Trabajador.Location = New System.Drawing.Point(121, 11)
        Me.Cu_Trabajador.Name = "Cu_Trabajador"
        Me.Cu_Trabajador.Size = New System.Drawing.Size(423, 23)
        Me.Cu_Trabajador.TabIndex = 0
        Me.Cu_Trabajador.Tipo = "PADEP"
        Me.Cu_Trabajador.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_AsociarPersonaTrabajador
        '
        Me.Cu_AsociarPersonaTrabajador.componenteasociado = "Cu_Trabajador"
        Me.Cu_AsociarPersonaTrabajador.CrearUsuario = True
        Me.Cu_AsociarPersonaTrabajador.Location = New System.Drawing.Point(550, 11)
        Me.Cu_AsociarPersonaTrabajador.Name = "Cu_AsociarPersonaTrabajador"
        Me.Cu_AsociarPersonaTrabajador.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaTrabajador.TabIndex = 1
        Me.Cu_AsociarPersonaTrabajador.Tag = "286"
        Me.Cu_AsociarPersonaTrabajador.TipoAsociacion = "DEP"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Cu_BuscarPersonaJefedepartamento)
        Me.GroupBox2.Controls.Add(Me.Cu_AsociarPersonaJefeAdministrativo)
        Me.GroupBox2.Controls.Add(Me.Cu_AsociarPersonaJefedepartamento)
        Me.GroupBox2.Controls.Add(Me.Cu_BuscarPersonaJefeAdministrativo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 242)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(591, 72)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Autoriza"
        '
        'Cu_BuscarPersonaJefedepartamento
        '
        Me.Cu_BuscarPersonaJefedepartamento.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaJefedepartamento.Location = New System.Drawing.Point(113, 13)
        Me.Cu_BuscarPersonaJefedepartamento.Name = "Cu_BuscarPersonaJefedepartamento"
        Me.Cu_BuscarPersonaJefedepartamento.Size = New System.Drawing.Size(423, 23)
        Me.Cu_BuscarPersonaJefedepartamento.TabIndex = 12
        Me.Cu_BuscarPersonaJefedepartamento.Tipo = "PADEP"
        Me.Cu_BuscarPersonaJefedepartamento.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_AsociarPersonaJefeAdministrativo
        '
        Me.Cu_AsociarPersonaJefeAdministrativo.componenteasociado = "Cu_BuscarPersonaJefeAdministrativo"
        Me.Cu_AsociarPersonaJefeAdministrativo.CrearUsuario = True
        Me.Cu_AsociarPersonaJefeAdministrativo.Location = New System.Drawing.Point(542, 42)
        Me.Cu_AsociarPersonaJefeAdministrativo.Name = "Cu_AsociarPersonaJefeAdministrativo"
        Me.Cu_AsociarPersonaJefeAdministrativo.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaJefeAdministrativo.TabIndex = 15
        Me.Cu_AsociarPersonaJefeAdministrativo.Tag = "286"
        Me.Cu_AsociarPersonaJefeAdministrativo.TipoAsociacion = "DEP"
        '
        'Cu_AsociarPersonaJefedepartamento
        '
        Me.Cu_AsociarPersonaJefedepartamento.componenteasociado = "Cu_BuscarPersonaJefedepartamento"
        Me.Cu_AsociarPersonaJefedepartamento.CrearUsuario = True
        Me.Cu_AsociarPersonaJefedepartamento.Location = New System.Drawing.Point(542, 13)
        Me.Cu_AsociarPersonaJefedepartamento.Name = "Cu_AsociarPersonaJefedepartamento"
        Me.Cu_AsociarPersonaJefedepartamento.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaJefedepartamento.TabIndex = 13
        Me.Cu_AsociarPersonaJefedepartamento.Tag = "286"
        Me.Cu_AsociarPersonaJefedepartamento.TipoAsociacion = "DEP"
        '
        'Cu_BuscarPersonaJefeAdministrativo
        '
        Me.Cu_BuscarPersonaJefeAdministrativo.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaJefeAdministrativo.Location = New System.Drawing.Point(113, 42)
        Me.Cu_BuscarPersonaJefeAdministrativo.Name = "Cu_BuscarPersonaJefeAdministrativo"
        Me.Cu_BuscarPersonaJefeAdministrativo.Size = New System.Drawing.Size(423, 23)
        Me.Cu_BuscarPersonaJefeAdministrativo.TabIndex = 14
        Me.Cu_BuscarPersonaJefeAdministrativo.Tipo = "PADEP"
        Me.Cu_BuscarPersonaJefeAdministrativo.valorcajatexto = "IDENTIFICACION"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Dtp_HoraLlegadaVigilante)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Dtp_HoraSalidaVigilante)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Cu_BuscarPersonaVigilanteSalida)
        Me.GroupBox3.Controls.Add(Me.Cu_AsociarPersonaVigilanteEntrada)
        Me.GroupBox3.Controls.Add(Me.Cu_AsociarPersonaVigilanteSalida)
        Me.GroupBox3.Controls.Add(Me.Cu_BuscarPersonaVigilanteEntrada)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 321)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(591, 134)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos Vigilante"
        '
        'Dtp_HoraLlegadaVigilante
        '
        Me.Dtp_HoraLlegadaVigilante.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.Dtp_HoraLlegadaVigilante.Location = New System.Drawing.Point(119, 107)
        Me.Dtp_HoraLlegadaVigilante.Name = "Dtp_HoraLlegadaVigilante"
        Me.Dtp_HoraLlegadaVigilante.ShowUpDown = True
        Me.Dtp_HoraLlegadaVigilante.Size = New System.Drawing.Size(106, 20)
        Me.Dtp_HoraLlegadaVigilante.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(43, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Hora Llegada:"
        '
        'Dtp_HoraSalidaVigilante
        '
        Me.Dtp_HoraSalidaVigilante.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.Dtp_HoraSalidaVigilante.Location = New System.Drawing.Point(117, 53)
        Me.Dtp_HoraSalidaVigilante.Name = "Dtp_HoraSalidaVigilante"
        Me.Dtp_HoraSalidaVigilante.ShowUpDown = True
        Me.Dtp_HoraSalidaVigilante.Size = New System.Drawing.Size(106, 20)
        Me.Dtp_HoraSalidaVigilante.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(50, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Hora Salida:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Vigilante Salida:"
        '
        'Cu_BuscarPersonaVigilanteSalida
        '
        Me.Cu_BuscarPersonaVigilanteSalida.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaVigilanteSalida.Location = New System.Drawing.Point(115, 24)
        Me.Cu_BuscarPersonaVigilanteSalida.Name = "Cu_BuscarPersonaVigilanteSalida"
        Me.Cu_BuscarPersonaVigilanteSalida.Size = New System.Drawing.Size(423, 23)
        Me.Cu_BuscarPersonaVigilanteSalida.TabIndex = 16
        Me.Cu_BuscarPersonaVigilanteSalida.Tipo = "PADEP"
        Me.Cu_BuscarPersonaVigilanteSalida.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_AsociarPersonaVigilanteEntrada
        '
        Me.Cu_AsociarPersonaVigilanteEntrada.componenteasociado = "Cu_BuscarPersonaVigilanteEntrada"
        Me.Cu_AsociarPersonaVigilanteEntrada.CrearUsuario = True
        Me.Cu_AsociarPersonaVigilanteEntrada.Location = New System.Drawing.Point(548, 78)
        Me.Cu_AsociarPersonaVigilanteEntrada.Name = "Cu_AsociarPersonaVigilanteEntrada"
        Me.Cu_AsociarPersonaVigilanteEntrada.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaVigilanteEntrada.TabIndex = 20
        Me.Cu_AsociarPersonaVigilanteEntrada.Tag = "286"
        Me.Cu_AsociarPersonaVigilanteEntrada.TipoAsociacion = "DEP"
        '
        'Cu_AsociarPersonaVigilanteSalida
        '
        Me.Cu_AsociarPersonaVigilanteSalida.componenteasociado = "Cu_BuscarPersonaVigilanteSalida"
        Me.Cu_AsociarPersonaVigilanteSalida.CrearUsuario = True
        Me.Cu_AsociarPersonaVigilanteSalida.Location = New System.Drawing.Point(548, 24)
        Me.Cu_AsociarPersonaVigilanteSalida.Name = "Cu_AsociarPersonaVigilanteSalida"
        Me.Cu_AsociarPersonaVigilanteSalida.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaVigilanteSalida.TabIndex = 17
        Me.Cu_AsociarPersonaVigilanteSalida.Tag = "286"
        Me.Cu_AsociarPersonaVigilanteSalida.TipoAsociacion = "DEP"
        '
        'Cu_BuscarPersonaVigilanteEntrada
        '
        Me.Cu_BuscarPersonaVigilanteEntrada.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaVigilanteEntrada.Location = New System.Drawing.Point(115, 78)
        Me.Cu_BuscarPersonaVigilanteEntrada.Name = "Cu_BuscarPersonaVigilanteEntrada"
        Me.Cu_BuscarPersonaVigilanteEntrada.Size = New System.Drawing.Size(423, 23)
        Me.Cu_BuscarPersonaVigilanteEntrada.TabIndex = 19
        Me.Cu_BuscarPersonaVigilanteEntrada.Tipo = "PADEP"
        Me.Cu_BuscarPersonaVigilanteEntrada.valorcajatexto = "IDENTIFICACION"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Vigilante Entrada:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 460)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(618, 30)
        Me.Panel1.TabIndex = 3
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(450, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 22
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(529, 2)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 23
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Fr_BoletaSalida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 490)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label16)
        Me.Name = "Fr_BoletaSalida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fr_BoletaSalida"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaTrabajador As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_Trabajador As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaJefedepartamento As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaJefedepartamento As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaJefeAdministrativo As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaJefeAdministrativo As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Dtp_HoraLlegadaVigilante As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Dtp_HoraSalidaVigilante As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaVigilanteSalida As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_AsociarPersonaVigilanteEntrada As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaVigilanteSalida As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaVigilanteEntrada As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Cb_TipoDiligencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cb_horarioSalida As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_minSalida As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_HoraSalida As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_HorarioLlegada As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_MinLlegada As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_HoraLlegada As System.Windows.Forms.ComboBox
End Class
