<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_PersonaBasico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_PersonaBasico))
        Me.Bt_TomarFoto = New System.Windows.Forms.Button()
        Me.GroupBox_DirecciónResidencia = New System.Windows.Forms.GroupBox()
        Me.Cu_CiudadDirección = New FormulariosClasesBase.Cu_Ciudad()
        Me.Tx_Dirección = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tx_Teléfono = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Tx_TeléfonoMóvil = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Tx_CorreoElectrónico = New System.Windows.Forms.TextBox()
        Me.Tx_NumeroContacto = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Tx_Observación = New System.Windows.Forms.TextBox()
        Me.Cu_CiudadExpedición = New FormulariosClasesBase.Cu_Ciudad()
        Me.GroupBox_Genero = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RadioButton_Femenino = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Masculino = New System.Windows.Forms.RadioButton()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.Tx_Identificacion = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel_Botones = New System.Windows.Forms.Panel()
        Me.DTP_FechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.Tx_PrimerNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tx_SegundoNombre = New System.Windows.Forms.TextBox()
        Me.Tx_PrimerApellido = New System.Windows.Forms.TextBox()
        Me.Tx_SegundoApellido = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Lb_PrimerNombre = New System.Windows.Forms.Label()
        Me.Cu_CiudadNacimiento = New FormulariosClasesBase.Cu_Ciudad()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Tx_PesoKg = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.DTP_FechaExpedición = New System.Windows.Forms.DateTimePicker()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.CB_TipoIdentificación = New System.Windows.Forms.ComboBox()
        Me.PictureBox_Foto_Persona = New System.Windows.Forms.PictureBox()
        Me.Bt_CargarFoto = New System.Windows.Forms.Button()
        Me.Button_Sin_Imagen = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Im_Defecto = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip_Mensajes = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog_ArchivoXML = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox_DirecciónResidencia.SuspendLayout()
        Me.GroupBox_Genero.SuspendLayout()
        Me.Panel_Botones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox_Foto_Persona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bt_TomarFoto
        '
        Me.Bt_TomarFoto.Location = New System.Drawing.Point(699, 168)
        Me.Bt_TomarFoto.Name = "Bt_TomarFoto"
        Me.Bt_TomarFoto.Size = New System.Drawing.Size(52, 23)
        Me.Bt_TomarFoto.TabIndex = 26
        Me.Bt_TomarFoto.Text = "Tomar"
        Me.Bt_TomarFoto.UseVisualStyleBackColor = True
        '
        'GroupBox_DirecciónResidencia
        '
        Me.GroupBox_DirecciónResidencia.Controls.Add(Me.Cu_CiudadDirección)
        Me.GroupBox_DirecciónResidencia.Controls.Add(Me.Tx_Dirección)
        Me.GroupBox_DirecciónResidencia.Controls.Add(Me.Label6)
        Me.GroupBox_DirecciónResidencia.Location = New System.Drawing.Point(8, 216)
        Me.GroupBox_DirecciónResidencia.Name = "GroupBox_DirecciónResidencia"
        Me.GroupBox_DirecciónResidencia.Size = New System.Drawing.Size(807, 46)
        Me.GroupBox_DirecciónResidencia.TabIndex = 29
        Me.GroupBox_DirecciónResidencia.TabStop = False
        Me.GroupBox_DirecciónResidencia.Text = "Dirección Residencia"
        '
        'Cu_CiudadDirección
        '
        Me.Cu_CiudadDirección.Location = New System.Drawing.Point(506, 17)
        Me.Cu_CiudadDirección.Name = "Cu_CiudadDirección"
        Me.Cu_CiudadDirección.Size = New System.Drawing.Size(291, 23)
        Me.Cu_CiudadDirección.TabIndex = 1
        '
        'Tx_Dirección
        '
        Me.Tx_Dirección.Location = New System.Drawing.Point(12, 19)
        Me.Tx_Dirección.MaxLength = 100
        Me.Tx_Dirección.Multiline = True
        Me.Tx_Dirección.Name = "Tx_Dirección"
        Me.Tx_Dirección.Size = New System.Drawing.Size(444, 18)
        Me.Tx_Dirección.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(464, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Ciudad:"
        '
        'Tx_Teléfono
        '
        Me.Tx_Teléfono.Location = New System.Drawing.Point(112, 151)
        Me.Tx_Teléfono.MaxLength = 10
        Me.Tx_Teléfono.Name = "Tx_Teléfono"
        Me.Tx_Teléfono.Size = New System.Drawing.Size(165, 20)
        Me.Tx_Teléfono.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(57, 154)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Teléfono:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Teléfono Móvil:"
        '
        'Tx_TeléfonoMóvil
        '
        Me.Tx_TeléfonoMóvil.Location = New System.Drawing.Point(112, 126)
        Me.Tx_TeléfonoMóvil.MaxLength = 10
        Me.Tx_TeléfonoMóvil.Name = "Tx_TeléfonoMóvil"
        Me.Tx_TeléfonoMóvil.Size = New System.Drawing.Size(165, 20)
        Me.Tx_TeléfonoMóvil.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(289, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Correo Electrónico:"
        '
        'Tx_CorreoElectrónico
        '
        Me.Tx_CorreoElectrónico.Location = New System.Drawing.Point(389, 126)
        Me.Tx_CorreoElectrónico.MaxLength = 50
        Me.Tx_CorreoElectrónico.Name = "Tx_CorreoElectrónico"
        Me.Tx_CorreoElectrónico.Size = New System.Drawing.Size(165, 20)
        Me.Tx_CorreoElectrónico.TabIndex = 21
        '
        'Tx_NumeroContacto
        '
        Me.Tx_NumeroContacto.Location = New System.Drawing.Point(389, 151)
        Me.Tx_NumeroContacto.MaxLength = 10
        Me.Tx_NumeroContacto.Name = "Tx_NumeroContacto"
        Me.Tx_NumeroContacto.Size = New System.Drawing.Size(165, 20)
        Me.Tx_NumeroContacto.TabIndex = 23
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(293, 154)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(93, 13)
        Me.Label28.TabIndex = 20
        Me.Label28.Text = "Numero Contacto:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(11, 265)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 13)
        Me.Label22.TabIndex = 35
        Me.Label22.Text = "Observación:"
        '
        'Tx_Observación
        '
        Me.Tx_Observación.Location = New System.Drawing.Point(8, 284)
        Me.Tx_Observación.MaxLength = 200
        Me.Tx_Observación.Multiline = True
        Me.Tx_Observación.Name = "Tx_Observación"
        Me.Tx_Observación.Size = New System.Drawing.Size(807, 47)
        Me.Tx_Observación.TabIndex = 30
        Me.Tx_Observación.Tag = "-1"
        '
        'Cu_CiudadExpedición
        '
        Me.Cu_CiudadExpedición.Location = New System.Drawing.Point(112, 71)
        Me.Cu_CiudadExpedición.Name = "Cu_CiudadExpedición"
        Me.Cu_CiudadExpedición.Size = New System.Drawing.Size(261, 23)
        Me.Cu_CiudadExpedición.TabIndex = 13
        '
        'GroupBox_Genero
        '
        Me.GroupBox_Genero.Controls.Add(Me.Label7)
        Me.GroupBox_Genero.Controls.Add(Me.RadioButton_Femenino)
        Me.GroupBox_Genero.Controls.Add(Me.RadioButton_Masculino)
        Me.GroupBox_Genero.Location = New System.Drawing.Point(560, 121)
        Me.GroupBox_Genero.Name = "GroupBox_Genero"
        Me.GroupBox_Genero.Size = New System.Drawing.Size(127, 93)
        Me.GroupBox_Genero.TabIndex = 24
        Me.GroupBox_Genero.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Genero:"
        '
        'RadioButton_Femenino
        '
        Me.RadioButton_Femenino.AutoSize = True
        Me.RadioButton_Femenino.Location = New System.Drawing.Point(50, 36)
        Me.RadioButton_Femenino.Name = "RadioButton_Femenino"
        Me.RadioButton_Femenino.Size = New System.Drawing.Size(71, 17)
        Me.RadioButton_Femenino.TabIndex = 2
        Me.RadioButton_Femenino.TabStop = True
        Me.RadioButton_Femenino.Text = "Femenino"
        Me.RadioButton_Femenino.UseVisualStyleBackColor = True
        '
        'RadioButton_Masculino
        '
        Me.RadioButton_Masculino.AutoSize = True
        Me.RadioButton_Masculino.Location = New System.Drawing.Point(50, 12)
        Me.RadioButton_Masculino.Name = "RadioButton_Masculino"
        Me.RadioButton_Masculino.Size = New System.Drawing.Size(73, 17)
        Me.RadioButton_Masculino.TabIndex = 1
        Me.RadioButton_Masculino.TabStop = True
        Me.RadioButton_Masculino.Text = "Masculino"
        Me.RadioButton_Masculino.UseVisualStyleBackColor = True
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancelar.Location = New System.Drawing.Point(736, 3)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cancelar.TabIndex = 1
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(655, 4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Aceptar.TabIndex = 0
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'Tx_Identificacion
        '
        Me.Tx_Identificacion.Location = New System.Drawing.Point(482, 48)
        Me.Tx_Identificacion.MaxLength = 15
        Me.Tx_Identificacion.Name = "Tx_Identificacion"
        Me.Tx_Identificacion.Size = New System.Drawing.Size(201, 20)
        Me.Tx_Identificacion.TabIndex = 11
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(406, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 13)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Identificación:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 52)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(97, 13)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Tipo Identificación:"
        '
        'Panel_Botones
        '
        Me.Panel_Botones.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel_Botones.Controls.Add(Me.Button_Cancelar)
        Me.Panel_Botones.Controls.Add(Me.Button_Aceptar)
        Me.Panel_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel_Botones.Location = New System.Drawing.Point(0, 337)
        Me.Panel_Botones.Name = "Panel_Botones"
        Me.Panel_Botones.Size = New System.Drawing.Size(824, 30)
        Me.Panel_Botones.TabIndex = 37
        '
        'DTP_FechaNacimiento
        '
        Me.DTP_FechaNacimiento.Checked = False
        Me.DTP_FechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaNacimiento.Location = New System.Drawing.Point(554, 97)
        Me.DTP_FechaNacimiento.Name = "DTP_FechaNacimiento"
        Me.DTP_FechaNacimiento.ShowCheckBox = True
        Me.DTP_FechaNacimiento.Size = New System.Drawing.Size(129, 20)
        Me.DTP_FechaNacimiento.TabIndex = 19
        '
        'Tx_PrimerNombre
        '
        Me.Tx_PrimerNombre.BackColor = System.Drawing.Color.White
        Me.Tx_PrimerNombre.Location = New System.Drawing.Point(112, 6)
        Me.Tx_PrimerNombre.MaxLength = 30
        Me.Tx_PrimerNombre.Name = "Tx_PrimerNombre"
        Me.Tx_PrimerNombre.Size = New System.Drawing.Size(200, 20)
        Me.Tx_PrimerNombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(386, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Segundo Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Primer Apellido:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(386, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Segundo Apellido:"
        '
        'Tx_SegundoNombre
        '
        Me.Tx_SegundoNombre.Location = New System.Drawing.Point(482, 6)
        Me.Tx_SegundoNombre.MaxLength = 30
        Me.Tx_SegundoNombre.Name = "Tx_SegundoNombre"
        Me.Tx_SegundoNombre.Size = New System.Drawing.Size(201, 20)
        Me.Tx_SegundoNombre.TabIndex = 3
        '
        'Tx_PrimerApellido
        '
        Me.Tx_PrimerApellido.Location = New System.Drawing.Point(112, 27)
        Me.Tx_PrimerApellido.MaxLength = 30
        Me.Tx_PrimerApellido.Name = "Tx_PrimerApellido"
        Me.Tx_PrimerApellido.Size = New System.Drawing.Size(200, 20)
        Me.Tx_PrimerApellido.TabIndex = 5
        '
        'Tx_SegundoApellido
        '
        Me.Tx_SegundoApellido.Location = New System.Drawing.Point(482, 27)
        Me.Tx_SegundoApellido.MaxLength = 30
        Me.Tx_SegundoApellido.Name = "Tx_SegundoApellido"
        Me.Tx_SegundoApellido.Size = New System.Drawing.Size(201, 20)
        Me.Tx_SegundoApellido.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Ciudad Expedición:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(455, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Fecha Nacimiento:"
        '
        'Lb_PrimerNombre
        '
        Me.Lb_PrimerNombre.AutoSize = True
        Me.Lb_PrimerNombre.Location = New System.Drawing.Point(30, 9)
        Me.Lb_PrimerNombre.Name = "Lb_PrimerNombre"
        Me.Lb_PrimerNombre.Size = New System.Drawing.Size(79, 13)
        Me.Lb_PrimerNombre.TabIndex = 0
        Me.Lb_PrimerNombre.Text = "Primer Nombre:"
        '
        'Cu_CiudadNacimiento
        '
        Me.Cu_CiudadNacimiento.Location = New System.Drawing.Point(112, 97)
        Me.Cu_CiudadNacimiento.Name = "Cu_CiudadNacimiento"
        Me.Cu_CiudadNacimiento.Size = New System.Drawing.Size(261, 23)
        Me.Cu_CiudadNacimiento.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.Controls.Add(Me.Tx_PesoKg)
        Me.Panel1.Controls.Add(Me.Label39)
        Me.Panel1.Controls.Add(Me.Panel_Botones)
        Me.Panel1.Controls.Add(Me.Bt_TomarFoto)
        Me.Panel1.Controls.Add(Me.GroupBox_DirecciónResidencia)
        Me.Panel1.Controls.Add(Me.Tx_PrimerNombre)
        Me.Panel1.Controls.Add(Me.Lb_PrimerNombre)
        Me.Panel1.Controls.Add(Me.Tx_Teléfono)
        Me.Panel1.Controls.Add(Me.DTP_FechaExpedición)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Tx_TeléfonoMóvil)
        Me.Panel1.Controls.Add(Me.Tx_Observación)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Cu_CiudadExpedición)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.CB_TipoIdentificación)
        Me.Panel1.Controls.Add(Me.Tx_CorreoElectrónico)
        Me.Panel1.Controls.Add(Me.Tx_SegundoNombre)
        Me.Panel1.Controls.Add(Me.Tx_NumeroContacto)
        Me.Panel1.Controls.Add(Me.Tx_Identificacion)
        Me.Panel1.Controls.Add(Me.Tx_PrimerApellido)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Tx_SegundoApellido)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Bt_CargarFoto)
        Me.Panel1.Controls.Add(Me.DTP_FechaNacimiento)
        Me.Panel1.Controls.Add(Me.Button_Sin_Imagen)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Cu_CiudadNacimiento)
        Me.Panel1.Controls.Add(Me.GroupBox_Genero)
        Me.Panel1.Controls.Add(Me.PictureBox_Foto_Persona)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(824, 367)
        Me.Panel1.TabIndex = 0
        '
        'Tx_PesoKg
        '
        Me.Tx_PesoKg.Location = New System.Drawing.Point(389, 175)
        Me.Tx_PesoKg.MaxLength = 3
        Me.Tx_PesoKg.Name = "Tx_PesoKg"
        Me.Tx_PesoKg.Size = New System.Drawing.Size(58, 20)
        Me.Tx_PesoKg.TabIndex = 25
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(321, 178)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(65, 13)
        Me.Label39.TabIndex = 28
        Me.Label39.Text = "Peso en Kg:"
        '
        'DTP_FechaExpedición
        '
        Me.DTP_FechaExpedición.Checked = False
        Me.DTP_FechaExpedición.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaExpedición.Location = New System.Drawing.Point(554, 71)
        Me.DTP_FechaExpedición.Name = "DTP_FechaExpedición"
        Me.DTP_FechaExpedición.ShowCheckBox = True
        Me.DTP_FechaExpedición.Size = New System.Drawing.Size(129, 20)
        Me.DTP_FechaExpedición.TabIndex = 15
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(456, 74)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(95, 13)
        Me.Label33.TabIndex = 14
        Me.Label33.Text = "Fecha Expedición:"
        '
        'CB_TipoIdentificación
        '
        Me.CB_TipoIdentificación.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CB_TipoIdentificación.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CB_TipoIdentificación.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TipoIdentificación.FormattingEnabled = True
        Me.CB_TipoIdentificación.Location = New System.Drawing.Point(112, 48)
        Me.CB_TipoIdentificación.Name = "CB_TipoIdentificación"
        Me.CB_TipoIdentificación.Size = New System.Drawing.Size(200, 21)
        Me.CB_TipoIdentificación.TabIndex = 9
        '
        'PictureBox_Foto_Persona
        '
        Me.PictureBox_Foto_Persona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox_Foto_Persona.ErrorImage = CType(resources.GetObject("PictureBox_Foto_Persona.ErrorImage"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.Image = CType(resources.GetObject("PictureBox_Foto_Persona.Image"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.InitialImage = CType(resources.GetObject("PictureBox_Foto_Persona.InitialImage"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.Location = New System.Drawing.Point(695, 6)
        Me.PictureBox_Foto_Persona.Name = "PictureBox_Foto_Persona"
        Me.PictureBox_Foto_Persona.Size = New System.Drawing.Size(120, 160)
        Me.PictureBox_Foto_Persona.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_Foto_Persona.TabIndex = 42
        Me.PictureBox_Foto_Persona.TabStop = False
        '
        'Bt_CargarFoto
        '
        Me.Bt_CargarFoto.Location = New System.Drawing.Point(754, 168)
        Me.Bt_CargarFoto.Name = "Bt_CargarFoto"
        Me.Bt_CargarFoto.Size = New System.Drawing.Size(53, 23)
        Me.Bt_CargarFoto.TabIndex = 27
        Me.Bt_CargarFoto.Text = "Cargar"
        Me.Bt_CargarFoto.UseVisualStyleBackColor = True
        '
        'Button_Sin_Imagen
        '
        Me.Button_Sin_Imagen.Location = New System.Drawing.Point(699, 191)
        Me.Button_Sin_Imagen.Name = "Button_Sin_Imagen"
        Me.Button_Sin_Imagen.Size = New System.Drawing.Size(108, 23)
        Me.Button_Sin_Imagen.TabIndex = 28
        Me.Button_Sin_Imagen.Text = "Sin Imagen"
        Me.Button_Sin_Imagen.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(11, 101)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(99, 13)
        Me.Label23.TabIndex = 16
        Me.Label23.Text = "Ciudad Nacimiento:"
        '
        'Im_Defecto
        '
        Me.Im_Defecto.ImageStream = CType(resources.GetObject("Im_Defecto.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Im_Defecto.TransparentColor = System.Drawing.Color.Transparent
        Me.Im_Defecto.Images.SetKeyName(0, "defecto.jpg")
        '
        'Fr_PersonaBasico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 367)
        Me.Controls.Add(Me.Panel1)
        Me.MaximumSize = New System.Drawing.Size(840, 406)
        Me.MinimumSize = New System.Drawing.Size(840, 406)
        Me.Name = "Fr_PersonaBasico"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Persona Básico"
        Me.GroupBox_DirecciónResidencia.ResumeLayout(False)
        Me.GroupBox_DirecciónResidencia.PerformLayout()
        Me.GroupBox_Genero.ResumeLayout(False)
        Me.GroupBox_Genero.PerformLayout()
        Me.Panel_Botones.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox_Foto_Persona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bt_TomarFoto As System.Windows.Forms.Button
    Friend WithEvents GroupBox_DirecciónResidencia As System.Windows.Forms.GroupBox
    Friend WithEvents Cu_CiudadDirección As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Tx_Dirección As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Tx_Teléfono As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Tx_TeléfonoMóvil As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Tx_CorreoElectrónico As System.Windows.Forms.TextBox
    Friend WithEvents Tx_NumeroContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Tx_Observación As System.Windows.Forms.TextBox
    Friend WithEvents Cu_CiudadExpedición As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents GroupBox_Genero As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RadioButton_Femenino As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_Masculino As System.Windows.Forms.RadioButton
    Friend WithEvents Button_Cancelar As System.Windows.Forms.Button
    Public WithEvents Button_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Tx_Identificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel_Botones As System.Windows.Forms.Panel
    Friend WithEvents DTP_FechaNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tx_PrimerNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tx_SegundoNombre As System.Windows.Forms.TextBox
    Friend WithEvents Tx_PrimerApellido As System.Windows.Forms.TextBox
    Friend WithEvents Tx_SegundoApellido As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Lb_PrimerNombre As System.Windows.Forms.Label
    Friend WithEvents Cu_CiudadNacimiento As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DTP_FechaExpedición As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents CB_TipoIdentificación As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox_Foto_Persona As System.Windows.Forms.PictureBox
    Friend WithEvents Bt_CargarFoto As System.Windows.Forms.Button
    Friend WithEvents Button_Sin_Imagen As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Im_Defecto As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip_Mensajes As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog_ArchivoXML As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Tx_PesoKg As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
End Class
