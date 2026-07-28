<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AgregarPersona
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_AgregarPersona))
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Rb_Femenino = New System.Windows.Forms.RadioButton()
        Me.Rb_Masculino = New System.Windows.Forms.RadioButton()
        Me.Tx_TelefonoMovil = New System.Windows.Forms.TextBox()
        Me.Lb_TelefonoMovil = New System.Windows.Forms.Label()
        Me.Tx_Identificacion = New System.Windows.Forms.TextBox()
        Me.Lb_Identificacion = New System.Windows.Forms.Label()
        Me.Cb_TipoIdentificacion = New System.Windows.Forms.ComboBox()
        Me.Lb_TipoIdentifiacion = New System.Windows.Forms.Label()
        Me.Tx_SegundoApellido = New System.Windows.Forms.TextBox()
        Me.Lb_SegundoApellido = New System.Windows.Forms.Label()
        Me.Tx_PrimerApellido = New System.Windows.Forms.TextBox()
        Me.Lb_PrimerApellido = New System.Windows.Forms.Label()
        Me.Tx_SegundoNombre = New System.Windows.Forms.TextBox()
        Me.Lb_SegundoNombre = New System.Windows.Forms.Label()
        Me.Tx_PrimerNombre = New System.Windows.Forms.TextBox()
        Me.Lb_PrimerNombre = New System.Windows.Forms.Label()
        Me.Pn_Contenido = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lb_CiudadExpedicion = New System.Windows.Forms.Label()
        Me.Cu_CiudadExpedicion = New FormulariosClasesBase.Cu_Ciudad()
        Me.Lb_FechaExpedicion = New System.Windows.Forms.Label()
        Me.Dtp_FechaExpedicion = New System.Windows.Forms.DateTimePicker()
        Me.Flp_EsPersona = New System.Windows.Forms.FlowLayoutPanel()
        Me.Ck_Empleado = New System.Windows.Forms.CheckBox()
        Me.Ck_Cliente = New System.Windows.Forms.CheckBox()
        Me.Ck_ContratistaProveedor = New System.Windows.Forms.CheckBox()
        Me.Lb_Genero = New System.Windows.Forms.Label()
        Me.Flp_Genero = New System.Windows.Forms.FlowLayoutPanel()
        Me.Gb_DireccionResidencia = New System.Windows.Forms.GroupBox()
        Me.Tlp_DireccionResidencia = New System.Windows.Forms.TableLayoutPanel()
        Me.Pn_CiudadDireccion = New System.Windows.Forms.Panel()
        Me.Lb_CiudadDireccion = New System.Windows.Forms.Label()
        Me.Cu_CiudadDireccion = New FormulariosClasesBase.Cu_Ciudad()
        Me.Tx_Direccion = New System.Windows.Forms.TextBox()
        Me.Gb_Contacto = New System.Windows.Forms.GroupBox()
        Me.Pn_Contacto = New System.Windows.Forms.Panel()
        Me.Lb_CorreoElectronico = New System.Windows.Forms.Label()
        Me.Tx_CorreoElectronico = New System.Windows.Forms.TextBox()
        Me.Lb_Telefono = New System.Windows.Forms.Label()
        Me.Tx_Telefono = New System.Windows.Forms.TextBox()
        Me.Im_Defecto = New System.Windows.Forms.ImageList(Me.components)
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Contenido.SuspendLayout()
        Me.Flp_EsPersona.SuspendLayout()
        Me.Flp_Genero.SuspendLayout()
        Me.Gb_DireccionResidencia.SuspendLayout()
        Me.Tlp_DireccionResidencia.SuspendLayout()
        Me.Pn_CiudadDireccion.SuspendLayout()
        Me.Gb_Contacto.SuspendLayout()
        Me.Pn_Contacto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.Location = New System.Drawing.Point(621, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(540, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 337)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(699, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Rb_Femenino
        '
        Me.Rb_Femenino.AutoSize = True
        Me.Rb_Femenino.Location = New System.Drawing.Point(83, 3)
        Me.Rb_Femenino.Name = "Rb_Femenino"
        Me.Rb_Femenino.Size = New System.Drawing.Size(71, 17)
        Me.Rb_Femenino.TabIndex = 1
        Me.Rb_Femenino.TabStop = True
        Me.Rb_Femenino.Text = "Femenino"
        Me.Rb_Femenino.UseVisualStyleBackColor = True
        '
        'Rb_Masculino
        '
        Me.Rb_Masculino.AutoSize = True
        Me.Rb_Masculino.Checked = True
        Me.Rb_Masculino.Location = New System.Drawing.Point(4, 3)
        Me.Rb_Masculino.Name = "Rb_Masculino"
        Me.Rb_Masculino.Size = New System.Drawing.Size(73, 17)
        Me.Rb_Masculino.TabIndex = 0
        Me.Rb_Masculino.TabStop = True
        Me.Rb_Masculino.Text = "Masculino"
        Me.Rb_Masculino.UseVisualStyleBackColor = True
        '
        'Tx_TelefonoMovil
        '
        Me.Tx_TelefonoMovil.Location = New System.Drawing.Point(95, 10)
        Me.Tx_TelefonoMovil.MaxLength = 10
        Me.Tx_TelefonoMovil.Name = "Tx_TelefonoMovil"
        Me.Tx_TelefonoMovil.Size = New System.Drawing.Size(200, 20)
        Me.Tx_TelefonoMovil.TabIndex = 1
        '
        'Lb_TelefonoMovil
        '
        Me.Lb_TelefonoMovil.AutoSize = True
        Me.Lb_TelefonoMovil.Location = New System.Drawing.Point(12, 13)
        Me.Lb_TelefonoMovil.Name = "Lb_TelefonoMovil"
        Me.Lb_TelefonoMovil.Size = New System.Drawing.Size(80, 13)
        Me.Lb_TelefonoMovil.TabIndex = 0
        Me.Lb_TelefonoMovil.Text = "Teléfono Móvil:"
        '
        'Tx_Identificacion
        '
        Me.Tx_Identificacion.Location = New System.Drawing.Point(480, 62)
        Me.Tx_Identificacion.MaxLength = 15
        Me.Tx_Identificacion.Name = "Tx_Identificacion"
        Me.Tx_Identificacion.Size = New System.Drawing.Size(201, 20)
        Me.Tx_Identificacion.TabIndex = 11
        '
        'Lb_Identificacion
        '
        Me.Lb_Identificacion.AutoSize = True
        Me.Lb_Identificacion.Location = New System.Drawing.Point(364, 65)
        Me.Lb_Identificacion.Name = "Lb_Identificacion"
        Me.Lb_Identificacion.Size = New System.Drawing.Size(113, 13)
        Me.Lb_Identificacion.TabIndex = 10
        Me.Lb_Identificacion.Text = "Número Identificación:"
        '
        'Cb_TipoIdentificacion
        '
        Me.Cb_TipoIdentificacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoIdentificacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoIdentificacion.DisplayMember = "NOMBRETIPOIDENTIFICACION"
        Me.Cb_TipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoIdentificacion.FormattingEnabled = True
        Me.Cb_TipoIdentificacion.Location = New System.Drawing.Point(110, 62)
        Me.Cb_TipoIdentificacion.Name = "Cb_TipoIdentificacion"
        Me.Cb_TipoIdentificacion.Size = New System.Drawing.Size(200, 21)
        Me.Cb_TipoIdentificacion.TabIndex = 9
        Me.Cb_TipoIdentificacion.ValueMember = "CODIGOTIPOIDENTIFICACION"
        '
        'Lb_TipoIdentifiacion
        '
        Me.Lb_TipoIdentifiacion.AutoSize = True
        Me.Lb_TipoIdentifiacion.Location = New System.Drawing.Point(10, 65)
        Me.Lb_TipoIdentifiacion.Name = "Lb_TipoIdentifiacion"
        Me.Lb_TipoIdentifiacion.Size = New System.Drawing.Size(97, 13)
        Me.Lb_TipoIdentifiacion.TabIndex = 8
        Me.Lb_TipoIdentifiacion.Text = "Tipo Identificación:"
        '
        'Tx_SegundoApellido
        '
        Me.Tx_SegundoApellido.Location = New System.Drawing.Point(480, 36)
        Me.Tx_SegundoApellido.MaxLength = 30
        Me.Tx_SegundoApellido.Name = "Tx_SegundoApellido"
        Me.Tx_SegundoApellido.Size = New System.Drawing.Size(201, 20)
        Me.Tx_SegundoApellido.TabIndex = 7
        '
        'Lb_SegundoApellido
        '
        Me.Lb_SegundoApellido.AutoSize = True
        Me.Lb_SegundoApellido.Location = New System.Drawing.Point(384, 39)
        Me.Lb_SegundoApellido.Name = "Lb_SegundoApellido"
        Me.Lb_SegundoApellido.Size = New System.Drawing.Size(93, 13)
        Me.Lb_SegundoApellido.TabIndex = 6
        Me.Lb_SegundoApellido.Text = "Segundo Apellido:"
        '
        'Tx_PrimerApellido
        '
        Me.Tx_PrimerApellido.Location = New System.Drawing.Point(110, 36)
        Me.Tx_PrimerApellido.MaxLength = 30
        Me.Tx_PrimerApellido.Name = "Tx_PrimerApellido"
        Me.Tx_PrimerApellido.Size = New System.Drawing.Size(200, 20)
        Me.Tx_PrimerApellido.TabIndex = 5
        '
        'Lb_PrimerApellido
        '
        Me.Lb_PrimerApellido.AutoSize = True
        Me.Lb_PrimerApellido.Location = New System.Drawing.Point(28, 39)
        Me.Lb_PrimerApellido.Name = "Lb_PrimerApellido"
        Me.Lb_PrimerApellido.Size = New System.Drawing.Size(79, 13)
        Me.Lb_PrimerApellido.TabIndex = 4
        Me.Lb_PrimerApellido.Text = "Primer Apellido:"
        '
        'Tx_SegundoNombre
        '
        Me.Tx_SegundoNombre.Location = New System.Drawing.Point(480, 10)
        Me.Tx_SegundoNombre.MaxLength = 30
        Me.Tx_SegundoNombre.Name = "Tx_SegundoNombre"
        Me.Tx_SegundoNombre.Size = New System.Drawing.Size(201, 20)
        Me.Tx_SegundoNombre.TabIndex = 3
        '
        'Lb_SegundoNombre
        '
        Me.Lb_SegundoNombre.AutoSize = True
        Me.Lb_SegundoNombre.Location = New System.Drawing.Point(384, 13)
        Me.Lb_SegundoNombre.Name = "Lb_SegundoNombre"
        Me.Lb_SegundoNombre.Size = New System.Drawing.Size(93, 13)
        Me.Lb_SegundoNombre.TabIndex = 2
        Me.Lb_SegundoNombre.Text = "Segundo Nombre:"
        '
        'Tx_PrimerNombre
        '
        Me.Tx_PrimerNombre.BackColor = System.Drawing.Color.White
        Me.Tx_PrimerNombre.Location = New System.Drawing.Point(110, 10)
        Me.Tx_PrimerNombre.MaxLength = 30
        Me.Tx_PrimerNombre.Name = "Tx_PrimerNombre"
        Me.Tx_PrimerNombre.Size = New System.Drawing.Size(200, 20)
        Me.Tx_PrimerNombre.TabIndex = 1
        '
        'Lb_PrimerNombre
        '
        Me.Lb_PrimerNombre.AutoSize = True
        Me.Lb_PrimerNombre.Location = New System.Drawing.Point(28, 13)
        Me.Lb_PrimerNombre.Name = "Lb_PrimerNombre"
        Me.Lb_PrimerNombre.Size = New System.Drawing.Size(79, 13)
        Me.Lb_PrimerNombre.TabIndex = 0
        Me.Lb_PrimerNombre.Text = "Primer Nombre:"
        '
        'Pn_Contenido
        '
        Me.Pn_Contenido.Controls.Add(Me.Label1)
        Me.Pn_Contenido.Controls.Add(Me.Lb_PrimerNombre)
        Me.Pn_Contenido.Controls.Add(Me.Tx_PrimerNombre)
        Me.Pn_Contenido.Controls.Add(Me.Lb_SegundoNombre)
        Me.Pn_Contenido.Controls.Add(Me.Tx_SegundoNombre)
        Me.Pn_Contenido.Controls.Add(Me.Lb_PrimerApellido)
        Me.Pn_Contenido.Controls.Add(Me.Tx_PrimerApellido)
        Me.Pn_Contenido.Controls.Add(Me.Lb_SegundoApellido)
        Me.Pn_Contenido.Controls.Add(Me.Tx_SegundoApellido)
        Me.Pn_Contenido.Controls.Add(Me.Lb_TipoIdentifiacion)
        Me.Pn_Contenido.Controls.Add(Me.Cb_TipoIdentificacion)
        Me.Pn_Contenido.Controls.Add(Me.Lb_Identificacion)
        Me.Pn_Contenido.Controls.Add(Me.Tx_Identificacion)
        Me.Pn_Contenido.Controls.Add(Me.Lb_CiudadExpedicion)
        Me.Pn_Contenido.Controls.Add(Me.Cu_CiudadExpedicion)
        Me.Pn_Contenido.Controls.Add(Me.Lb_FechaExpedicion)
        Me.Pn_Contenido.Controls.Add(Me.Dtp_FechaExpedicion)
        Me.Pn_Contenido.Controls.Add(Me.Flp_EsPersona)
        Me.Pn_Contenido.Controls.Add(Me.Lb_Genero)
        Me.Pn_Contenido.Controls.Add(Me.Flp_Genero)
        Me.Pn_Contenido.Controls.Add(Me.Gb_DireccionResidencia)
        Me.Pn_Contenido.Controls.Add(Me.Gb_Contacto)
        Me.Pn_Contenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Contenido.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Contenido.Name = "Pn_Contenido"
        Me.Pn_Contenido.Size = New System.Drawing.Size(699, 337)
        Me.Pn_Contenido.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Tipo Tercero:"
        '
        'Lb_CiudadExpedicion
        '
        Me.Lb_CiudadExpedicion.AutoSize = True
        Me.Lb_CiudadExpedicion.Location = New System.Drawing.Point(9, 93)
        Me.Lb_CiudadExpedicion.Name = "Lb_CiudadExpedicion"
        Me.Lb_CiudadExpedicion.Size = New System.Drawing.Size(98, 13)
        Me.Lb_CiudadExpedicion.TabIndex = 12
        Me.Lb_CiudadExpedicion.Text = "Ciudad Expedición:"
        '
        'Cu_CiudadExpedicion
        '
        Me.Cu_CiudadExpedicion.Location = New System.Drawing.Point(109, 89)
        Me.Cu_CiudadExpedicion.Name = "Cu_CiudadExpedicion"
        Me.Cu_CiudadExpedicion.Size = New System.Drawing.Size(261, 23)
        Me.Cu_CiudadExpedicion.TabIndex = 13
        '
        'Lb_FechaExpedicion
        '
        Me.Lb_FechaExpedicion.AutoSize = True
        Me.Lb_FechaExpedicion.ForeColor = System.Drawing.Color.Black
        Me.Lb_FechaExpedicion.Location = New System.Drawing.Point(382, 93)
        Me.Lb_FechaExpedicion.Name = "Lb_FechaExpedicion"
        Me.Lb_FechaExpedicion.Size = New System.Drawing.Size(95, 13)
        Me.Lb_FechaExpedicion.TabIndex = 14
        Me.Lb_FechaExpedicion.Text = "Fecha Expedición:"
        '
        'Dtp_FechaExpedicion
        '
        Me.Dtp_FechaExpedicion.Checked = False
        Me.Dtp_FechaExpedicion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaExpedicion.Location = New System.Drawing.Point(480, 90)
        Me.Dtp_FechaExpedicion.Name = "Dtp_FechaExpedicion"
        Me.Dtp_FechaExpedicion.ShowCheckBox = True
        Me.Dtp_FechaExpedicion.Size = New System.Drawing.Size(115, 20)
        Me.Dtp_FechaExpedicion.TabIndex = 15
        '
        'Flp_EsPersona
        '
        Me.Flp_EsPersona.AutoSize = True
        Me.Flp_EsPersona.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Flp_EsPersona.Controls.Add(Me.Ck_Empleado)
        Me.Flp_EsPersona.Controls.Add(Me.Ck_Cliente)
        Me.Flp_EsPersona.Controls.Add(Me.Ck_ContratistaProveedor)
        Me.Flp_EsPersona.Location = New System.Drawing.Point(110, 118)
        Me.Flp_EsPersona.Name = "Flp_EsPersona"
        Me.Flp_EsPersona.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Flp_EsPersona.Size = New System.Drawing.Size(298, 23)
        Me.Flp_EsPersona.TabIndex = 16
        '
        'Ck_Empleado
        '
        Me.Ck_Empleado.AutoSize = True
        Me.Ck_Empleado.Location = New System.Drawing.Point(4, 3)
        Me.Ck_Empleado.Name = "Ck_Empleado"
        Me.Ck_Empleado.Size = New System.Drawing.Size(73, 17)
        Me.Ck_Empleado.TabIndex = 0
        Me.Ck_Empleado.Text = "Empleado"
        Me.Ck_Empleado.UseVisualStyleBackColor = True
        '
        'Ck_Cliente
        '
        Me.Ck_Cliente.AutoSize = True
        Me.Ck_Cliente.Location = New System.Drawing.Point(83, 3)
        Me.Ck_Cliente.Name = "Ck_Cliente"
        Me.Ck_Cliente.Size = New System.Drawing.Size(58, 17)
        Me.Ck_Cliente.TabIndex = 1
        Me.Ck_Cliente.Text = "Cliente"
        Me.Ck_Cliente.UseVisualStyleBackColor = True
        '
        'Ck_ContratistaProveedor
        '
        Me.Ck_ContratistaProveedor.AutoSize = True
        Me.Ck_ContratistaProveedor.Checked = True
        Me.Ck_ContratistaProveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_ContratistaProveedor.Location = New System.Drawing.Point(147, 3)
        Me.Ck_ContratistaProveedor.Name = "Ck_ContratistaProveedor"
        Me.Ck_ContratistaProveedor.Size = New System.Drawing.Size(147, 17)
        Me.Ck_ContratistaProveedor.TabIndex = 2
        Me.Ck_ContratistaProveedor.Text = "Contratista y/o Proveedor"
        Me.Ck_ContratistaProveedor.UseVisualStyleBackColor = True
        '
        'Lb_Genero
        '
        Me.Lb_Genero.AutoSize = True
        Me.Lb_Genero.Location = New System.Drawing.Point(432, 122)
        Me.Lb_Genero.Name = "Lb_Genero"
        Me.Lb_Genero.Size = New System.Drawing.Size(45, 13)
        Me.Lb_Genero.TabIndex = 17
        Me.Lb_Genero.Text = "Género:"
        Me.Lb_Genero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Flp_Genero
        '
        Me.Flp_Genero.AutoSize = True
        Me.Flp_Genero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Flp_Genero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Flp_Genero.Controls.Add(Me.Rb_Masculino)
        Me.Flp_Genero.Controls.Add(Me.Rb_Femenino)
        Me.Flp_Genero.Location = New System.Drawing.Point(480, 116)
        Me.Flp_Genero.Name = "Flp_Genero"
        Me.Flp_Genero.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Flp_Genero.Size = New System.Drawing.Size(160, 25)
        Me.Flp_Genero.TabIndex = 18
        '
        'Gb_DireccionResidencia
        '
        Me.Gb_DireccionResidencia.Controls.Add(Me.Tlp_DireccionResidencia)
        Me.Gb_DireccionResidencia.Location = New System.Drawing.Point(12, 148)
        Me.Gb_DireccionResidencia.Margin = New System.Windows.Forms.Padding(0)
        Me.Gb_DireccionResidencia.Name = "Gb_DireccionResidencia"
        Me.Gb_DireccionResidencia.Size = New System.Drawing.Size(676, 92)
        Me.Gb_DireccionResidencia.TabIndex = 19
        Me.Gb_DireccionResidencia.TabStop = False
        Me.Gb_DireccionResidencia.Text = "Dirección de Residencia"
        '
        'Tlp_DireccionResidencia
        '
        Me.Tlp_DireccionResidencia.ColumnCount = 1
        Me.Tlp_DireccionResidencia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_DireccionResidencia.Controls.Add(Me.Pn_CiudadDireccion, 0, 1)
        Me.Tlp_DireccionResidencia.Controls.Add(Me.Tx_Direccion, 0, 0)
        Me.Tlp_DireccionResidencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tlp_DireccionResidencia.Location = New System.Drawing.Point(3, 16)
        Me.Tlp_DireccionResidencia.Margin = New System.Windows.Forms.Padding(0)
        Me.Tlp_DireccionResidencia.Name = "Tlp_DireccionResidencia"
        Me.Tlp_DireccionResidencia.RowCount = 2
        Me.Tlp_DireccionResidencia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.Tlp_DireccionResidencia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Tlp_DireccionResidencia.Size = New System.Drawing.Size(670, 73)
        Me.Tlp_DireccionResidencia.TabIndex = 0
        '
        'Pn_CiudadDireccion
        '
        Me.Pn_CiudadDireccion.Controls.Add(Me.Lb_CiudadDireccion)
        Me.Pn_CiudadDireccion.Controls.Add(Me.Cu_CiudadDireccion)
        Me.Pn_CiudadDireccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_CiudadDireccion.Location = New System.Drawing.Point(0, 40)
        Me.Pn_CiudadDireccion.Margin = New System.Windows.Forms.Padding(0)
        Me.Pn_CiudadDireccion.Name = "Pn_CiudadDireccion"
        Me.Pn_CiudadDireccion.Size = New System.Drawing.Size(670, 33)
        Me.Pn_CiudadDireccion.TabIndex = 1
        '
        'Lb_CiudadDireccion
        '
        Me.Lb_CiudadDireccion.AutoSize = True
        Me.Lb_CiudadDireccion.Location = New System.Drawing.Point(49, 7)
        Me.Lb_CiudadDireccion.Name = "Lb_CiudadDireccion"
        Me.Lb_CiudadDireccion.Size = New System.Drawing.Size(43, 13)
        Me.Lb_CiudadDireccion.TabIndex = 0
        Me.Lb_CiudadDireccion.Text = "Ciudad:"
        '
        'Cu_CiudadDireccion
        '
        Me.Cu_CiudadDireccion.Location = New System.Drawing.Point(94, 3)
        Me.Cu_CiudadDireccion.Name = "Cu_CiudadDireccion"
        Me.Cu_CiudadDireccion.Size = New System.Drawing.Size(261, 23)
        Me.Cu_CiudadDireccion.TabIndex = 1
        '
        'Tx_Direccion
        '
        Me.Tx_Direccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tx_Direccion.Location = New System.Drawing.Point(0, 0)
        Me.Tx_Direccion.Margin = New System.Windows.Forms.Padding(0)
        Me.Tx_Direccion.MaxLength = 100
        Me.Tx_Direccion.Multiline = True
        Me.Tx_Direccion.Name = "Tx_Direccion"
        Me.Tx_Direccion.Size = New System.Drawing.Size(670, 40)
        Me.Tx_Direccion.TabIndex = 0
        '
        'Gb_Contacto
        '
        Me.Gb_Contacto.Controls.Add(Me.Pn_Contacto)
        Me.Gb_Contacto.Location = New System.Drawing.Point(12, 246)
        Me.Gb_Contacto.Margin = New System.Windows.Forms.Padding(0)
        Me.Gb_Contacto.Name = "Gb_Contacto"
        Me.Gb_Contacto.Size = New System.Drawing.Size(676, 84)
        Me.Gb_Contacto.TabIndex = 20
        Me.Gb_Contacto.TabStop = False
        Me.Gb_Contacto.Text = "Contacto"
        '
        'Pn_Contacto
        '
        Me.Pn_Contacto.Controls.Add(Me.Lb_TelefonoMovil)
        Me.Pn_Contacto.Controls.Add(Me.Tx_TelefonoMovil)
        Me.Pn_Contacto.Controls.Add(Me.Lb_CorreoElectronico)
        Me.Pn_Contacto.Controls.Add(Me.Tx_CorreoElectronico)
        Me.Pn_Contacto.Controls.Add(Me.Lb_Telefono)
        Me.Pn_Contacto.Controls.Add(Me.Tx_Telefono)
        Me.Pn_Contacto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Contacto.Location = New System.Drawing.Point(3, 16)
        Me.Pn_Contacto.Name = "Pn_Contacto"
        Me.Pn_Contacto.Size = New System.Drawing.Size(670, 65)
        Me.Pn_Contacto.TabIndex = 0
        '
        'Lb_CorreoElectronico
        '
        Me.Lb_CorreoElectronico.AutoSize = True
        Me.Lb_CorreoElectronico.Location = New System.Drawing.Point(365, 13)
        Me.Lb_CorreoElectronico.Name = "Lb_CorreoElectronico"
        Me.Lb_CorreoElectronico.Size = New System.Drawing.Size(97, 13)
        Me.Lb_CorreoElectronico.TabIndex = 2
        Me.Lb_CorreoElectronico.Text = "Correo Electrónico:"
        '
        'Tx_CorreoElectronico
        '
        Me.Tx_CorreoElectronico.Location = New System.Drawing.Point(465, 10)
        Me.Tx_CorreoElectronico.MaxLength = 50
        Me.Tx_CorreoElectronico.Name = "Tx_CorreoElectronico"
        Me.Tx_CorreoElectronico.Size = New System.Drawing.Size(201, 20)
        Me.Tx_CorreoElectronico.TabIndex = 3
        '
        'Lb_Telefono
        '
        Me.Lb_Telefono.AutoSize = True
        Me.Lb_Telefono.Location = New System.Drawing.Point(40, 39)
        Me.Lb_Telefono.Name = "Lb_Telefono"
        Me.Lb_Telefono.Size = New System.Drawing.Size(52, 13)
        Me.Lb_Telefono.TabIndex = 4
        Me.Lb_Telefono.Text = "Teléfono:"
        '
        'Tx_Telefono
        '
        Me.Tx_Telefono.Location = New System.Drawing.Point(95, 36)
        Me.Tx_Telefono.MaxLength = 10
        Me.Tx_Telefono.Name = "Tx_Telefono"
        Me.Tx_Telefono.Size = New System.Drawing.Size(200, 20)
        Me.Tx_Telefono.TabIndex = 5
        '
        'Im_Defecto
        '
        Me.Im_Defecto.ImageStream = CType(resources.GetObject("Im_Defecto.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Im_Defecto.TransparentColor = System.Drawing.Color.Transparent
        Me.Im_Defecto.Images.SetKeyName(0, "defecto.jpg")
        '
        'Fr_AgregarPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 367)
        Me.Controls.Add(Me.Pn_Contenido)
        Me.Controls.Add(Me.Flp_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_AgregarPersona"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar Persona"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Contenido.ResumeLayout(False)
        Me.Pn_Contenido.PerformLayout()
        Me.Flp_EsPersona.ResumeLayout(False)
        Me.Flp_EsPersona.PerformLayout()
        Me.Flp_Genero.ResumeLayout(False)
        Me.Flp_Genero.PerformLayout()
        Me.Gb_DireccionResidencia.ResumeLayout(False)
        Me.Tlp_DireccionResidencia.ResumeLayout(False)
        Me.Tlp_DireccionResidencia.PerformLayout()
        Me.Pn_CiudadDireccion.ResumeLayout(False)
        Me.Pn_CiudadDireccion.PerformLayout()
        Me.Gb_Contacto.ResumeLayout(False)
        Me.Pn_Contacto.ResumeLayout(False)
        Me.Pn_Contacto.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Public WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Rb_Femenino As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Masculino As System.Windows.Forms.RadioButton
    Friend WithEvents Tx_TelefonoMovil As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TelefonoMovil As System.Windows.Forms.Label
    Friend WithEvents Tx_Identificacion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Identificacion As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoIdentificacion As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TipoIdentifiacion As System.Windows.Forms.Label
    Friend WithEvents Tx_SegundoApellido As System.Windows.Forms.TextBox
    Friend WithEvents Lb_SegundoApellido As System.Windows.Forms.Label
    Friend WithEvents Tx_PrimerApellido As System.Windows.Forms.TextBox
    Friend WithEvents Lb_PrimerApellido As System.Windows.Forms.Label
    Friend WithEvents Tx_SegundoNombre As System.Windows.Forms.TextBox
    Friend WithEvents Lb_SegundoNombre As System.Windows.Forms.Label
    Friend WithEvents Tx_PrimerNombre As System.Windows.Forms.TextBox
    Friend WithEvents Lb_PrimerNombre As System.Windows.Forms.Label
    Friend WithEvents Pn_Contenido As System.Windows.Forms.Panel
    Friend WithEvents Flp_Genero As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_Genero As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaExpedicion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaExpedicion As System.Windows.Forms.Label
    Friend WithEvents Cu_CiudadExpedicion As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Lb_CiudadExpedicion As System.Windows.Forms.Label
    Friend WithEvents Flp_EsPersona As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Ck_Empleado As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_Cliente As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_ContratistaProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents Gb_DireccionResidencia As System.Windows.Forms.GroupBox
    Friend WithEvents Tlp_DireccionResidencia As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Pn_CiudadDireccion As System.Windows.Forms.Panel
    Friend WithEvents Lb_CiudadDireccion As System.Windows.Forms.Label
    Friend WithEvents Cu_CiudadDireccion As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Tx_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Telefono As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Telefono As System.Windows.Forms.Label
    Friend WithEvents Lb_CorreoElectronico As System.Windows.Forms.Label
    Friend WithEvents Tx_CorreoElectronico As System.Windows.Forms.TextBox
    Friend WithEvents Gb_Contacto As System.Windows.Forms.GroupBox
    Friend WithEvents Pn_Contacto As System.Windows.Forms.Panel
    Friend WithEvents Im_Defecto As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
