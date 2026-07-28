<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Bodega
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tx_Nombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tx_Abreviatura = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tx_Direccion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tx_Indicaciones = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Tx_TelefonoBodega = New System.Windows.Forms.TextBox()
        Me.Tx_CelularBodega = New System.Windows.Forms.TextBox()
        Me.Tx_CorreoBodega = New System.Windows.Forms.TextBox()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Tx_CorreoCompra = New System.Windows.Forms.TextBox()
        Me.Tx_CelularCompra = New System.Windows.Forms.TextBox()
        Me.Tx_TelefonoCompra = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_CódigoArtículo = New System.Windows.Forms.Label()
        Me.Gb_JefeBodega = New System.Windows.Forms.GroupBox()
        Me.Gb_Comprador = New System.Windows.Forms.GroupBox()
        Me.Cu_Ciudad_OC = New FormulariosClasesBase.Cu_Ciudad()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Gb_DependenciaSC = New System.Windows.Forms.GroupBox()
        Me.Bt_CrearDependencia = New System.Windows.Forms.Button()
        Me.Bt_CrearBase = New System.Windows.Forms.Button()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Cb_Base = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Ck_EsBodegaPrincipal = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cb_Empresa = New System.Windows.Forms.ComboBox()
        Me.Cu_Bp_VBSubgerencia = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Cu_Ciudad_Bodega = New FormulariosClasesBase.Cu_Ciudad()
        Me.Tt_Bodega = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Cb_Gerencia = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.Gb_JefeBodega.SuspendLayout()
        Me.Gb_Comprador.SuspendLayout()
        Me.Gb_DependenciaSC.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nombre:"
        '
        'Tx_Nombre
        '
        Me.Tx_Nombre.Location = New System.Drawing.Point(80, 7)
        Me.Tx_Nombre.MaxLength = 50
        Me.Tx_Nombre.Name = "Tx_Nombre"
        Me.Tx_Nombre.Size = New System.Drawing.Size(308, 20)
        Me.Tx_Nombre.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(401, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Abrev.:"
        '
        'Tx_Abreviatura
        '
        Me.Tx_Abreviatura.Location = New System.Drawing.Point(446, 7)
        Me.Tx_Abreviatura.MaxLength = 10
        Me.Tx_Abreviatura.Name = "Tx_Abreviatura"
        Me.Tx_Abreviatura.Size = New System.Drawing.Size(69, 20)
        Me.Tx_Abreviatura.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Dirección:"
        '
        'Tx_Direccion
        '
        Me.Tx_Direccion.Location = New System.Drawing.Point(80, 33)
        Me.Tx_Direccion.MaxLength = 99
        Me.Tx_Direccion.Name = "Tx_Direccion"
        Me.Tx_Direccion.Size = New System.Drawing.Size(308, 20)
        Me.Tx_Direccion.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Indicaciones:"
        '
        'Tx_Indicaciones
        '
        Me.Tx_Indicaciones.Location = New System.Drawing.Point(80, 59)
        Me.Tx_Indicaciones.MaxLength = 199
        Me.Tx_Indicaciones.Multiline = True
        Me.Tx_Indicaciones.Name = "Tx_Indicaciones"
        Me.Tx_Indicaciones.Size = New System.Drawing.Size(501, 45)
        Me.Tx_Indicaciones.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(401, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Ciudad:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(152, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Teléfono:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Celular:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(299, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Correo Electrónico:"
        '
        'Tx_TelefonoBodega
        '
        Me.Tx_TelefonoBodega.Location = New System.Drawing.Point(210, 22)
        Me.Tx_TelefonoBodega.MaxLength = 10
        Me.Tx_TelefonoBodega.Name = "Tx_TelefonoBodega"
        Me.Tx_TelefonoBodega.Size = New System.Drawing.Size(74, 20)
        Me.Tx_TelefonoBodega.TabIndex = 3
        '
        'Tx_CelularBodega
        '
        Me.Tx_CelularBodega.Location = New System.Drawing.Point(67, 22)
        Me.Tx_CelularBodega.MaxLength = 10
        Me.Tx_CelularBodega.Name = "Tx_CelularBodega"
        Me.Tx_CelularBodega.Size = New System.Drawing.Size(70, 20)
        Me.Tx_CelularBodega.TabIndex = 1
        '
        'Tx_CorreoBodega
        '
        Me.Tx_CorreoBodega.Location = New System.Drawing.Point(402, 22)
        Me.Tx_CorreoBodega.MaxLength = 60
        Me.Tx_CorreoBodega.Name = "Tx_CorreoBodega"
        Me.Tx_CorreoBodega.Size = New System.Drawing.Size(320, 20)
        Me.Tx_CorreoBodega.TabIndex = 5
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Location = New System.Drawing.Point(672, 3)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cancelar.TabIndex = 2
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Location = New System.Drawing.Point(591, 3)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Aceptar.TabIndex = 1
        Me.Btn_Aceptar.Text = "Aceptar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Tx_CorreoCompra
        '
        Me.Tx_CorreoCompra.Location = New System.Drawing.Point(402, 22)
        Me.Tx_CorreoCompra.MaxLength = 50
        Me.Tx_CorreoCompra.Name = "Tx_CorreoCompra"
        Me.Tx_CorreoCompra.Size = New System.Drawing.Size(320, 20)
        Me.Tx_CorreoCompra.TabIndex = 5
        '
        'Tx_CelularCompra
        '
        Me.Tx_CelularCompra.Location = New System.Drawing.Point(67, 22)
        Me.Tx_CelularCompra.MaxLength = 10
        Me.Tx_CelularCompra.Name = "Tx_CelularCompra"
        Me.Tx_CelularCompra.Size = New System.Drawing.Size(70, 20)
        Me.Tx_CelularCompra.TabIndex = 1
        '
        'Tx_TelefonoCompra
        '
        Me.Tx_TelefonoCompra.Location = New System.Drawing.Point(210, 22)
        Me.Tx_TelefonoCompra.MaxLength = 10
        Me.Tx_TelefonoCompra.Name = "Tx_TelefonoCompra"
        Me.Tx_TelefonoCompra.Size = New System.Drawing.Size(74, 20)
        Me.Tx_TelefonoCompra.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(299, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Correo Electrónico:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(22, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Celular:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(152, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Telefono:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lb_CódigoArtículo)
        Me.Panel1.Controls.Add(Me.Btn_Aceptar)
        Me.Panel1.Controls.Add(Me.Btn_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 332)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(757, 30)
        Me.Panel1.TabIndex = 20
        '
        'Lb_CódigoArtículo
        '
        Me.Lb_CódigoArtículo.AutoSize = True
        Me.Lb_CódigoArtículo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CódigoArtículo.ForeColor = System.Drawing.Color.Red
        Me.Lb_CódigoArtículo.Location = New System.Drawing.Point(11, 8)
        Me.Lb_CódigoArtículo.Name = "Lb_CódigoArtículo"
        Me.Lb_CódigoArtículo.Size = New System.Drawing.Size(52, 13)
        Me.Lb_CódigoArtículo.TabIndex = 0
        Me.Lb_CódigoArtículo.Text = "Label13"
        Me.Lb_CódigoArtículo.Visible = False
        '
        'Gb_JefeBodega
        '
        Me.Gb_JefeBodega.Controls.Add(Me.Label9)
        Me.Gb_JefeBodega.Controls.Add(Me.Label10)
        Me.Gb_JefeBodega.Controls.Add(Me.Label11)
        Me.Gb_JefeBodega.Controls.Add(Me.Tx_TelefonoBodega)
        Me.Gb_JefeBodega.Controls.Add(Me.Tx_CelularBodega)
        Me.Gb_JefeBodega.Controls.Add(Me.Tx_CorreoBodega)
        Me.Gb_JefeBodega.Location = New System.Drawing.Point(13, 110)
        Me.Gb_JefeBodega.Name = "Gb_JefeBodega"
        Me.Gb_JefeBodega.Size = New System.Drawing.Size(735, 48)
        Me.Gb_JefeBodega.TabIndex = 14
        Me.Gb_JefeBodega.TabStop = False
        Me.Gb_JefeBodega.Text = "Contacto de la Bodega"
        '
        'Gb_Comprador
        '
        Me.Gb_Comprador.Controls.Add(Me.Cu_Ciudad_OC)
        Me.Gb_Comprador.Controls.Add(Me.Label18)
        Me.Gb_Comprador.Controls.Add(Me.Label17)
        Me.Gb_Comprador.Controls.Add(Me.Tx_CorreoCompra)
        Me.Gb_Comprador.Controls.Add(Me.Label16)
        Me.Gb_Comprador.Controls.Add(Me.Tx_CelularCompra)
        Me.Gb_Comprador.Controls.Add(Me.Label14)
        Me.Gb_Comprador.Controls.Add(Me.Tx_TelefonoCompra)
        Me.Gb_Comprador.Location = New System.Drawing.Point(13, 164)
        Me.Gb_Comprador.Name = "Gb_Comprador"
        Me.Gb_Comprador.Size = New System.Drawing.Size(735, 76)
        Me.Gb_Comprador.TabIndex = 15
        Me.Gb_Comprador.TabStop = False
        Me.Gb_Comprador.Text = "Compras"
        '
        'Cu_Ciudad_OC
        '
        Me.Cu_Ciudad_OC.Location = New System.Drawing.Point(67, 47)
        Me.Cu_Ciudad_OC.Name = "Cu_Ciudad_OC"
        Me.Cu_Ciudad_OC.Size = New System.Drawing.Size(302, 23)
        Me.Cu_Ciudad_OC.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(22, 51)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Ciudad:"
        '
        'Gb_DependenciaSC
        '
        Me.Gb_DependenciaSC.Controls.Add(Me.Cb_Gerencia)
        Me.Gb_DependenciaSC.Controls.Add(Me.Label13)
        Me.Gb_DependenciaSC.Controls.Add(Me.Bt_CrearDependencia)
        Me.Gb_DependenciaSC.Controls.Add(Me.Bt_CrearBase)
        Me.Gb_DependenciaSC.Controls.Add(Me.Cb_Dependencia)
        Me.Gb_DependenciaSC.Controls.Add(Me.Cb_Base)
        Me.Gb_DependenciaSC.Controls.Add(Me.Label12)
        Me.Gb_DependenciaSC.Controls.Add(Me.Label8)
        Me.Gb_DependenciaSC.Location = New System.Drawing.Point(389, 215)
        Me.Gb_DependenciaSC.Name = "Gb_DependenciaSC"
        Me.Gb_DependenciaSC.Size = New System.Drawing.Size(359, 106)
        Me.Gb_DependenciaSC.TabIndex = 19
        Me.Gb_DependenciaSC.TabStop = False
        Me.Gb_DependenciaSC.Text = "SisControl"
        '
        'Bt_CrearDependencia
        '
        Me.Bt_CrearDependencia.AutoSize = True
        Me.Bt_CrearDependencia.Location = New System.Drawing.Point(323, 46)
        Me.Bt_CrearDependencia.Name = "Bt_CrearDependencia"
        Me.Bt_CrearDependencia.Size = New System.Drawing.Size(23, 23)
        Me.Bt_CrearDependencia.TabIndex = 6
        Me.Bt_CrearDependencia.Tag = "562"
        Me.Bt_CrearDependencia.Text = "+"
        Me.Tt_Bodega.SetToolTip(Me.Bt_CrearDependencia, "Crear una nueva dependencia Siscontrol de la base seleccionada")
        Me.Bt_CrearDependencia.UseVisualStyleBackColor = True
        '
        'Bt_CrearBase
        '
        Me.Bt_CrearBase.AutoSize = True
        Me.Bt_CrearBase.Location = New System.Drawing.Point(323, 20)
        Me.Bt_CrearBase.Name = "Bt_CrearBase"
        Me.Bt_CrearBase.Size = New System.Drawing.Size(23, 23)
        Me.Bt_CrearBase.TabIndex = 4
        Me.Bt_CrearBase.Tag = "561"
        Me.Bt_CrearBase.Text = "+"
        Me.Tt_Bodega.SetToolTip(Me.Bt_CrearBase, "Crear una nueva base para SisControl")
        Me.Bt_CrearBase.UseVisualStyleBackColor = True
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.Location = New System.Drawing.Point(99, 48)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(220, 21)
        Me.Cb_Dependencia.TabIndex = 3
        '
        'Cb_Base
        '
        Me.Cb_Base.FormattingEnabled = True
        Me.Cb_Base.Location = New System.Drawing.Point(99, 21)
        Me.Cb_Base.Name = "Cb_Base"
        Me.Cb_Base.Size = New System.Drawing.Size(220, 21)
        Me.Cb_Base.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Dependencia:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(62, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Base:"
        '
        'Ck_EsBodegaPrincipal
        '
        Me.Ck_EsBodegaPrincipal.AutoSize = True
        Me.Ck_EsBodegaPrincipal.Location = New System.Drawing.Point(624, 87)
        Me.Ck_EsBodegaPrincipal.Name = "Ck_EsBodegaPrincipal"
        Me.Ck_EsBodegaPrincipal.Size = New System.Drawing.Size(121, 17)
        Me.Ck_EsBodegaPrincipal.TabIndex = 13
        Me.Ck_EsBodegaPrincipal.Text = "Es Bodega Principal"
        Me.Tt_Bodega.SetToolTip(Me.Ck_EsBodegaPrincipal, "Indica si los movimientos de esta bodega pueden asociar solamente los centros de " & _
        "costo del contrato o los de toda la compañía")
        Me.Ck_EsBodegaPrincipal.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 250)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Persona V.Bo.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(530, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Empresa:"
        '
        'Cb_Empresa
        '
        Me.Cb_Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Empresa.FormattingEnabled = True
        Me.Cb_Empresa.Location = New System.Drawing.Point(587, 7)
        Me.Cb_Empresa.Name = "Cb_Empresa"
        Me.Cb_Empresa.Size = New System.Drawing.Size(121, 21)
        Me.Cb_Empresa.TabIndex = 5
        '
        'Cu_Bp_VBSubgerencia
        '
        Me.Cu_Bp_VBSubgerencia.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_Bp_VBSubgerencia.Location = New System.Drawing.Point(80, 246)
        Me.Cu_Bp_VBSubgerencia.Name = "Cu_Bp_VBSubgerencia"
        Me.Cu_Bp_VBSubgerencia.Size = New System.Drawing.Size(302, 23)
        Me.Cu_Bp_VBSubgerencia.TabIndex = 17
        Me.Cu_Bp_VBSubgerencia.Tipo = "PHVBSG"
        Me.Cu_Bp_VBSubgerencia.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_CentroCosto1
        '
        Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto1.Location = New System.Drawing.Point(13, 283)
        Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
        Me.Cu_CentroCosto1.Size = New System.Drawing.Size(367, 38)
        Me.Cu_CentroCosto1.TabIndex = 18
        '
        'Cu_Ciudad_Bodega
        '
        Me.Cu_Ciudad_Bodega.Location = New System.Drawing.Point(446, 33)
        Me.Cu_Ciudad_Bodega.Name = "Cu_Ciudad_Bodega"
        Me.Cu_Ciudad_Bodega.Size = New System.Drawing.Size(302, 23)
        Me.Cu_Ciudad_Bodega.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(43, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Gerencia:"
        '
        'Cb_Gerencia
        '
        Me.Cb_Gerencia.FormattingEnabled = True
        Me.Cb_Gerencia.Location = New System.Drawing.Point(99, 75)
        Me.Cb_Gerencia.Name = "Cb_Gerencia"
        Me.Cb_Gerencia.Size = New System.Drawing.Size(220, 21)
        Me.Cb_Gerencia.TabIndex = 8
        '
        'Fr_Bodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(757, 362)
        Me.Controls.Add(Me.Cb_Empresa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cu_Bp_VBSubgerencia)
        Me.Controls.Add(Me.Ck_EsBodegaPrincipal)
        Me.Controls.Add(Me.Gb_DependenciaSC)
        Me.Controls.Add(Me.Cu_CentroCosto1)
        Me.Controls.Add(Me.Gb_Comprador)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Gb_JefeBodega)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Tx_Nombre)
        Me.Controls.Add(Me.Tx_Indicaciones)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Tx_Abreviatura)
        Me.Controls.Add(Me.Cu_Ciudad_Bodega)
        Me.Controls.Add(Me.Tx_Direccion)
        Me.Controls.Add(Me.Label5)
        Me.MaximizeBox = False
        Me.Name = "Fr_Bodega"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bodega"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Gb_JefeBodega.ResumeLayout(False)
        Me.Gb_JefeBodega.PerformLayout()
        Me.Gb_Comprador.ResumeLayout(False)
        Me.Gb_Comprador.PerformLayout()
        Me.Gb_DependenciaSC.ResumeLayout(False)
        Me.Gb_DependenciaSC.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tx_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tx_Abreviatura As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Tx_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Tx_Indicaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Tx_TelefonoBodega As System.Windows.Forms.TextBox
    Friend WithEvents Tx_CelularBodega As System.Windows.Forms.TextBox
    Friend WithEvents Tx_CorreoBodega As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Cu_Ciudad_Bodega As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Tx_CorreoCompra As System.Windows.Forms.TextBox
    Friend WithEvents Tx_CelularCompra As System.Windows.Forms.TextBox
    Friend WithEvents Tx_TelefonoCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lb_CódigoArtículo As System.Windows.Forms.Label
    Friend WithEvents Gb_JefeBodega As System.Windows.Forms.GroupBox
    Friend WithEvents Gb_Comprador As System.Windows.Forms.GroupBox
    Friend WithEvents Cu_Ciudad_OC As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
    Friend WithEvents Gb_DependenciaSC As System.Windows.Forms.GroupBox
    Friend WithEvents Ck_EsBodegaPrincipal As System.Windows.Forms.CheckBox
    Friend WithEvents Cu_Bp_VBSubgerencia As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_Base As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cb_Empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Bt_CrearDependencia As System.Windows.Forms.Button
    Friend WithEvents Bt_CrearBase As System.Windows.Forms.Button
    Friend WithEvents Tt_Bodega As System.Windows.Forms.ToolTip
    Friend WithEvents Cb_Gerencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
