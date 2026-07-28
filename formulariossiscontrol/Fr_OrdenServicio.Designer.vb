<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_OrdenServicio
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
        Dim Label22 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_OrdenServicio))
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Dtp_FechaFactura = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Tx_NroFactura = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Tx_Observación = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_Consecutivo = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Pn_Cierre = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Cb_AurorizaDctoSS = New System.Windows.Forms.ComboBox()
        Me.Dtp_FechaRecibido = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_FechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Tx_ValorCierre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Cu_Recibido = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_AsociarPersonaRecibido = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Pn_Inicial = New System.Windows.Forms.Panel()
        Me.AOT = New FormulariosClasesBase.Cu_Asociar()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.AOC = New FormulariosClasesBase.Cu_Asociar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Cb_AcepatadaPor = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Cb_TipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Tx_DigVerificación = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Tx_Contratista = New System.Windows.Forms.TextBox()
        Me.Cu_AsociarPersonaSolicitado = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaAceptada = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_Aceptada = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Bt_BuscarDeContratista = New System.Windows.Forms.Button()
        Me.Tx_ValorFactura = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Cu_Solicitada = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Tx_Descripción = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cb_Base = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cu_Ciudad = New FormulariosClasesBase.Cu_Ciudad()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tx_NombreContratista = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tx_Dirección = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Label22 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Pn_Cierre.SuspendLayout()
        Me.Pn_Inicial.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.Location = New System.Drawing.Point(228, 261)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(73, 13)
        Label22.TabIndex = 81
        Label22.Text = "Tipo Moneda:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(593, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 13)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Fecha Vencimiento:"
        '
        'Dtp_FechaFactura
        '
        Me.Dtp_FechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaFactura.Location = New System.Drawing.Point(464, 41)
        Me.Dtp_FechaFactura.Name = "Dtp_FechaFactura"
        Me.Dtp_FechaFactura.ShowCheckBox = True
        Me.Dtp_FechaFactura.Size = New System.Drawing.Size(112, 20)
        Me.Dtp_FechaFactura.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(382, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 13)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Fecha Factura:"
        '
        'Tx_NroFactura
        '
        Me.Tx_NroFactura.Location = New System.Drawing.Point(263, 41)
        Me.Tx_NroFactura.MaxLength = 200
        Me.Tx_NroFactura.Name = "Tx_NroFactura"
        Me.Tx_NroFactura.Size = New System.Drawing.Size(112, 20)
        Me.Tx_NroFactura.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(208, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Factura:"
        '
        'Tx_Observación
        '
        Me.Tx_Observación.Location = New System.Drawing.Point(292, 67)
        Me.Tx_Observación.MaxLength = 50
        Me.Tx_Observación.Name = "Tx_Observación"
        Me.Tx_Observación.Size = New System.Drawing.Size(452, 20)
        Me.Tx_Observación.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(219, 71)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Observación:"
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(855, 30)
        Me.Lb_Titulo.TabIndex = 21
        Me.Lb_Titulo.Text = "ORDEN DE PRESTACIÓN DE SERVICIO"
        Me.Lb_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lb_Consecutivo)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 434)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(855, 43)
        Me.Panel1.TabIndex = 24
        '
        'Lb_Consecutivo
        '
        Me.Lb_Consecutivo.AutoSize = True
        Me.Lb_Consecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Consecutivo.ForeColor = System.Drawing.Color.Red
        Me.Lb_Consecutivo.Location = New System.Drawing.Point(11, 15)
        Me.Lb_Consecutivo.Name = "Lb_Consecutivo"
        Me.Lb_Consecutivo.Size = New System.Drawing.Size(52, 13)
        Me.Lb_Consecutivo.TabIndex = 2
        Me.Lb_Consecutivo.Text = "Label13"
        Me.Lb_Consecutivo.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(690, 11)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(771, 10)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(2, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 13)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Fecha Recibido:"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(16, 17)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(70, 13)
        Me.LinkLabel3.TabIndex = 52
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "Persona por parte de ISMOCOL que certifica la prestación del servicio"
        Me.LinkLabel3.Text = "Recibido por:"
        '
        'Pn_Cierre
        '
        Me.Pn_Cierre.Controls.Add(Me.Label16)
        Me.Pn_Cierre.Controls.Add(Me.Cb_AurorizaDctoSS)
        Me.Pn_Cierre.Controls.Add(Me.Dtp_FechaRecibido)
        Me.Pn_Cierre.Controls.Add(Me.Dtp_FechaVencimiento)
        Me.Pn_Cierre.Controls.Add(Me.Tx_ValorCierre)
        Me.Pn_Cierre.Controls.Add(Me.Label8)
        Me.Pn_Cierre.Controls.Add(Me.Tx_NroFactura)
        Me.Pn_Cierre.Controls.Add(Me.LinkLabel3)
        Me.Pn_Cierre.Controls.Add(Me.Label14)
        Me.Pn_Cierre.Controls.Add(Me.Tx_Observación)
        Me.Pn_Cierre.Controls.Add(Me.Label15)
        Me.Pn_Cierre.Controls.Add(Me.Cu_Recibido)
        Me.Pn_Cierre.Controls.Add(Me.Cu_AsociarPersonaRecibido)
        Me.Pn_Cierre.Controls.Add(Me.Dtp_FechaFactura)
        Me.Pn_Cierre.Controls.Add(Me.Label12)
        Me.Pn_Cierre.Controls.Add(Me.Label18)
        Me.Pn_Cierre.Controls.Add(Me.Label10)
        Me.Pn_Cierre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Cierre.Location = New System.Drawing.Point(0, 335)
        Me.Pn_Cierre.Name = "Pn_Cierre"
        Me.Pn_Cierre.Size = New System.Drawing.Size(855, 99)
        Me.Pn_Cierre.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(562, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 13)
        Me.Label16.TabIndex = 58
        Me.Label16.Text = "Autoriza Dcto SS:"
        '
        'Cb_AurorizaDctoSS
        '
        Me.Cb_AurorizaDctoSS.FormattingEnabled = True
        Me.Cb_AurorizaDctoSS.Location = New System.Drawing.Point(659, 14)
        Me.Cb_AurorizaDctoSS.Name = "Cb_AurorizaDctoSS"
        Me.Cb_AurorizaDctoSS.Size = New System.Drawing.Size(177, 21)
        Me.Cb_AurorizaDctoSS.TabIndex = 18
        '
        'Dtp_FechaRecibido
        '
        Me.Dtp_FechaRecibido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaRecibido.Location = New System.Drawing.Point(90, 40)
        Me.Dtp_FechaRecibido.Name = "Dtp_FechaRecibido"
        Me.Dtp_FechaRecibido.Size = New System.Drawing.Size(98, 20)
        Me.Dtp_FechaRecibido.TabIndex = 56
        '
        'Dtp_FechaVencimiento
        '
        Me.Dtp_FechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaVencimiento.Location = New System.Drawing.Point(700, 41)
        Me.Dtp_FechaVencimiento.Name = "Dtp_FechaVencimiento"
        Me.Dtp_FechaVencimiento.ShowCheckBox = True
        Me.Dtp_FechaVencimiento.Size = New System.Drawing.Size(114, 20)
        Me.Dtp_FechaVencimiento.TabIndex = 55
        '
        'Tx_ValorCierre
        '
        Me.Tx_ValorCierre.Location = New System.Drawing.Point(90, 67)
        Me.Tx_ValorCierre.MaxLength = 200
        Me.Tx_ValorCierre.Name = "Tx_ValorCierre"
        Me.Tx_ValorCierre.Size = New System.Drawing.Size(113, 20)
        Me.Tx_ValorCierre.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Valor Cierre:"
        '
        'Cu_Recibido
        '
        Me.Cu_Recibido.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_Recibido.Location = New System.Drawing.Point(87, 12)
        Me.Cu_Recibido.Name = "Cu_Recibido"
        Me.Cu_Recibido.Size = New System.Drawing.Size(423, 23)
        Me.Cu_Recibido.TabIndex = 0
        Me.Cu_Recibido.Tipo = "PADEP"
        Me.Cu_Recibido.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_AsociarPersonaRecibido
        '
        Me.Cu_AsociarPersonaRecibido.componenteasociado = "Cu_Recibido"
        Me.Cu_AsociarPersonaRecibido.CrearUsuario = True
        Me.Cu_AsociarPersonaRecibido.Location = New System.Drawing.Point(513, 12)
        Me.Cu_AsociarPersonaRecibido.Name = "Cu_AsociarPersonaRecibido"
        Me.Cu_AsociarPersonaRecibido.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaRecibido.TabIndex = 17
        Me.Cu_AsociarPersonaRecibido.Tag = "286"
        Me.Cu_AsociarPersonaRecibido.TipoAsociacion = "DEP"
        Me.Cu_AsociarPersonaRecibido.TipoBúsqueda = "P"
        '
        'Pn_Inicial
        '
        Me.Pn_Inicial.Controls.Add(Me.AOT)
        Me.Pn_Inicial.Controls.Add(Me.Label13)
        Me.Pn_Inicial.Controls.Add(Me.AOC)
        Me.Pn_Inicial.Controls.Add(Me.Label9)
        Me.Pn_Inicial.Controls.Add(Me.Dtp_Fecha)
        Me.Pn_Inicial.Controls.Add(Me.Cu_CentroCosto1)
        Me.Pn_Inicial.Controls.Add(Me.LinkLabel2)
        Me.Pn_Inicial.Controls.Add(Me.LinkLabel1)
        Me.Pn_Inicial.Controls.Add(Me.Cb_AcepatadaPor)
        Me.Pn_Inicial.Controls.Add(Me.Label23)
        Me.Pn_Inicial.Controls.Add(Me.Cb_TipoMoneda)
        Me.Pn_Inicial.Controls.Add(Label22)
        Me.Pn_Inicial.Controls.Add(Me.Label21)
        Me.Pn_Inicial.Controls.Add(Me.Tx_DigVerificación)
        Me.Pn_Inicial.Controls.Add(Me.Label20)
        Me.Pn_Inicial.Controls.Add(Me.Tx_Contratista)
        Me.Pn_Inicial.Controls.Add(Me.Cu_AsociarPersonaSolicitado)
        Me.Pn_Inicial.Controls.Add(Me.Cu_AsociarPersonaAceptada)
        Me.Pn_Inicial.Controls.Add(Me.Cu_Aceptada)
        Me.Pn_Inicial.Controls.Add(Me.Bt_BuscarDeContratista)
        Me.Pn_Inicial.Controls.Add(Me.Tx_ValorFactura)
        Me.Pn_Inicial.Controls.Add(Me.Label11)
        Me.Pn_Inicial.Controls.Add(Me.Cu_Solicitada)
        Me.Pn_Inicial.Controls.Add(Me.Tx_Descripción)
        Me.Pn_Inicial.Controls.Add(Me.Label7)
        Me.Pn_Inicial.Controls.Add(Me.Cb_Base)
        Me.Pn_Inicial.Controls.Add(Me.Label3)
        Me.Pn_Inicial.Controls.Add(Me.Cb_Dependencia)
        Me.Pn_Inicial.Controls.Add(Me.Label5)
        Me.Pn_Inicial.Controls.Add(Me.Cu_Ciudad)
        Me.Pn_Inicial.Controls.Add(Me.Label6)
        Me.Pn_Inicial.Controls.Add(Me.Label2)
        Me.Pn_Inicial.Controls.Add(Me.Tx_NombreContratista)
        Me.Pn_Inicial.Controls.Add(Me.Label4)
        Me.Pn_Inicial.Controls.Add(Me.Tx_Dirección)
        Me.Pn_Inicial.Controls.Add(Me.Label1)
        Me.Pn_Inicial.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Inicial.Location = New System.Drawing.Point(0, 30)
        Me.Pn_Inicial.Name = "Pn_Inicial"
        Me.Pn_Inicial.Size = New System.Drawing.Size(855, 305)
        Me.Pn_Inicial.TabIndex = 2
        '
        'AOT
        '
        Me.AOT.Location = New System.Drawing.Point(547, 286)
        Me.AOT.Name = "AOT"
        Me.AOT.Size = New System.Drawing.Size(219, 13)
        Me.AOT.TabIndex = 92
        Me.AOT.Tipo = "OT"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(385, 286)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(164, 13)
        Me.Label13.TabIndex = 91
        Me.Label13.Text = "Asociar Orden de Mantenimiento:"
        '
        'AOC
        '
        Me.AOC.Location = New System.Drawing.Point(142, 286)
        Me.AOC.Name = "AOC"
        Me.AOC.Size = New System.Drawing.Size(219, 15)
        Me.AOC.TabIndex = 90
        Me.AOC.Tipo = "OC"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 286)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(131, 13)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "Asociar Orden de Compra:"
        '
        'Dtp_Fecha
        '
        Me.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha.Location = New System.Drawing.Point(385, 78)
        Me.Dtp_Fecha.Name = "Dtp_Fecha"
        Me.Dtp_Fecha.Size = New System.Drawing.Size(97, 20)
        Me.Dtp_Fecha.TabIndex = 88
        '
        'Cu_CentroCosto1
        '
        Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto1.Location = New System.Drawing.Point(542, 229)
        Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
        Me.Cu_CentroCosto1.Size = New System.Drawing.Size(295, 38)
        Me.Cu_CentroCosto1.TabIndex = 87
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(7, 234)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel2.TabIndex = 86
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = "Persona de ISMOCOL que esta solicitando el servicio, debe coincidir con la Firma " & _
    "Autorizada en el documento impreso"
        Me.LinkLabel2.Text = "Solicitado por:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(7, 209)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel1.TabIndex = 85
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = resources.GetString("LinkLabel1.Tag")
        Me.LinkLabel1.Text = "Aceptada por:"
        '
        'Cb_AcepatadaPor
        '
        Me.Cb_AcepatadaPor.AutoSize = True
        Me.Cb_AcepatadaPor.Checked = True
        Me.Cb_AcepatadaPor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_AcepatadaPor.Location = New System.Drawing.Point(83, 209)
        Me.Cb_AcepatadaPor.Name = "Cb_AcepatadaPor"
        Me.Cb_AcepatadaPor.Size = New System.Drawing.Size(15, 14)
        Me.Cb_AcepatadaPor.TabIndex = 84
        Me.Cb_AcepatadaPor.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(488, 81)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(283, 13)
        Me.Label23.TabIndex = 24
        Me.Label23.Text = "* Municipio y Fecha donde se ejecuto el servicio"
        '
        'Cb_TipoMoneda
        '
        Me.Cb_TipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoMoneda.FormattingEnabled = True
        Me.Cb_TipoMoneda.Location = New System.Drawing.Point(304, 257)
        Me.Cb_TipoMoneda.Name = "Cb_TipoMoneda"
        Me.Cb_TipoMoneda.Size = New System.Drawing.Size(126, 21)
        Me.Cb_TipoMoneda.TabIndex = 10
        Me.Cb_TipoMoneda.Tag = ""
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(537, 210)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(310, 13)
        Me.Label21.TabIndex = 77
        Me.Label21.Text = "* Persona por parte del contratista que firma la Orden"
        '
        'Tx_DigVerificación
        '
        Me.Tx_DigVerificación.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_DigVerificación.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_DigVerificación.Location = New System.Drawing.Point(276, 6)
        Me.Tx_DigVerificación.MaxLength = 1
        Me.Tx_DigVerificación.Name = "Tx_DigVerificación"
        Me.Tx_DigVerificación.ReadOnly = True
        Me.Tx_DigVerificación.Size = New System.Drawing.Size(27, 20)
        Me.Tx_DigVerificación.TabIndex = 16
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(228, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 13)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "Dig Ver:"
        '
        'Tx_Contratista
        '
        Me.Tx_Contratista.Location = New System.Drawing.Point(82, 6)
        Me.Tx_Contratista.MaxLength = 200
        Me.Tx_Contratista.Name = "Tx_Contratista"
        Me.Tx_Contratista.ReadOnly = True
        Me.Tx_Contratista.Size = New System.Drawing.Size(101, 20)
        Me.Tx_Contratista.TabIndex = 0
        '
        'Cu_AsociarPersonaSolicitado
        '
        Me.Cu_AsociarPersonaSolicitado.componenteasociado = "Cu_Solicitada"
        Me.Cu_AsociarPersonaSolicitado.CrearUsuario = True
        Me.Cu_AsociarPersonaSolicitado.Location = New System.Drawing.Point(508, 229)
        Me.Cu_AsociarPersonaSolicitado.Name = "Cu_AsociarPersonaSolicitado"
        Me.Cu_AsociarPersonaSolicitado.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaSolicitado.TabIndex = 65
        Me.Cu_AsociarPersonaSolicitado.Tag = "286"
        Me.Cu_AsociarPersonaSolicitado.TipoAsociacion = "DEP"
        Me.Cu_AsociarPersonaSolicitado.TipoBúsqueda = "P"
        '
        'Cu_AsociarPersonaAceptada
        '
        Me.Cu_AsociarPersonaAceptada.componenteasociado = "Cu_Aceptada"
        Me.Cu_AsociarPersonaAceptada.CrearUsuario = True
        Me.Cu_AsociarPersonaAceptada.Location = New System.Drawing.Point(508, 205)
        Me.Cu_AsociarPersonaAceptada.Name = "Cu_AsociarPersonaAceptada"
        Me.Cu_AsociarPersonaAceptada.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaAceptada.TabIndex = 63
        Me.Cu_AsociarPersonaAceptada.Tag = "286"
        Me.Cu_AsociarPersonaAceptada.TipoAsociacion = "DEP"
        Me.Cu_AsociarPersonaAceptada.TipoBúsqueda = "P"
        '
        'Cu_Aceptada
        '
        Me.Cu_Aceptada.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_Aceptada.Location = New System.Drawing.Point(103, 205)
        Me.Cu_Aceptada.Name = "Cu_Aceptada"
        Me.Cu_Aceptada.Size = New System.Drawing.Size(402, 23)
        Me.Cu_Aceptada.TabIndex = 7
        Me.Cu_Aceptada.Tipo = "PADEP"
        Me.Cu_Aceptada.valorcajatexto = "IDENTIFICACION"
        '
        'Bt_BuscarDeContratista
        '
        Me.Bt_BuscarDeContratista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_BuscarDeContratista.Location = New System.Drawing.Point(190, 5)
        Me.Bt_BuscarDeContratista.Name = "Bt_BuscarDeContratista"
        Me.Bt_BuscarDeContratista.Size = New System.Drawing.Size(28, 23)
        Me.Bt_BuscarDeContratista.TabIndex = 14
        Me.Bt_BuscarDeContratista.Text = "..."
        Me.Bt_BuscarDeContratista.UseVisualStyleBackColor = True
        '
        'Tx_ValorFactura
        '
        Me.Tx_ValorFactura.Location = New System.Drawing.Point(83, 256)
        Me.Tx_ValorFactura.MaxLength = 200
        Me.Tx_ValorFactura.Name = "Tx_ValorFactura"
        Me.Tx_ValorFactura.Size = New System.Drawing.Size(113, 20)
        Me.Tx_ValorFactura.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 261)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "Valor Estimado:"
        '
        'Cu_Solicitada
        '
        Me.Cu_Solicitada.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_Solicitada.Location = New System.Drawing.Point(82, 229)
        Me.Cu_Solicitada.Name = "Cu_Solicitada"
        Me.Cu_Solicitada.Size = New System.Drawing.Size(423, 23)
        Me.Cu_Solicitada.TabIndex = 8
        Me.Cu_Solicitada.Tipo = "PADEP"
        Me.Cu_Solicitada.valorcajatexto = "IDENTIFICACION"
        '
        'Tx_Descripción
        '
        Me.Tx_Descripción.Location = New System.Drawing.Point(82, 102)
        Me.Tx_Descripción.MaxLength = 400
        Me.Tx_Descripción.Multiline = True
        Me.Tx_Descripción.Name = "Tx_Descripción"
        Me.Tx_Descripción.Size = New System.Drawing.Size(754, 100)
        Me.Tx_Descripción.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Descripción:"
        '
        'Cb_Base
        '
        Me.Cb_Base.FormattingEnabled = True
        Me.Cb_Base.Location = New System.Drawing.Point(82, 54)
        Me.Cb_Base.Name = "Cb_Base"
        Me.Cb_Base.Size = New System.Drawing.Size(221, 21)
        Me.Cb_Base.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Base:"
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.Location = New System.Drawing.Point(385, 54)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(193, 21)
        Me.Cb_Dependencia.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(308, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Dependencia:"
        '
        'Cu_Ciudad
        '
        Me.Cu_Ciudad.Location = New System.Drawing.Point(82, 77)
        Me.Cu_Ciudad.Name = "Cu_Ciudad"
        Me.Cu_Ciudad.Size = New System.Drawing.Size(252, 23)
        Me.Cu_Ciudad.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Ciudad:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Contratista:"
        '
        'Tx_NombreContratista
        '
        Me.Tx_NombreContratista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_NombreContratista.Location = New System.Drawing.Point(309, 6)
        Me.Tx_NombreContratista.MaxLength = 150
        Me.Tx_NombreContratista.Name = "Tx_NombreContratista"
        Me.Tx_NombreContratista.ReadOnly = True
        Me.Tx_NombreContratista.Size = New System.Drawing.Size(527, 20)
        Me.Tx_NombreContratista.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Dirección:"
        '
        'Tx_Dirección
        '
        Me.Tx_Dirección.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_Dirección.Location = New System.Drawing.Point(82, 31)
        Me.Tx_Dirección.MaxLength = 150
        Me.Tx_Dirección.Name = "Tx_Dirección"
        Me.Tx_Dirección.Size = New System.Drawing.Size(496, 20)
        Me.Tx_Dirección.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(344, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Fecha:"
        '
        'Fr_OrdenServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 477)
        Me.Controls.Add(Me.Pn_Cierre)
        Me.Controls.Add(Me.Pn_Inicial)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Lb_Titulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_OrdenServicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de prestación de servicio"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Pn_Cierre.ResumeLayout(False)
        Me.Pn_Cierre.PerformLayout()
        Me.Pn_Inicial.ResumeLayout(False)
        Me.Pn_Inicial.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaFactura As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Tx_NroFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Tx_Observación As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Lb_Titulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Cu_Recibido As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaRecibido As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Public WithEvents Lb_Consecutivo As System.Windows.Forms.Label
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents Pn_Cierre As System.Windows.Forms.Panel
    Friend WithEvents Tx_ValorCierre As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Pn_Inicial As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Cb_AcepatadaPor As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Tx_DigVerificación As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Tx_Contratista As System.Windows.Forms.TextBox
    Friend WithEvents Cu_AsociarPersonaSolicitado As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaAceptada As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_Aceptada As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Bt_BuscarDeContratista As System.Windows.Forms.Button
    Friend WithEvents Tx_ValorFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Cu_Solicitada As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Tx_Descripción As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cb_Base As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cu_Ciudad As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tx_NombreContratista As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tx_Dirección As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
    Friend WithEvents Dtp_Fecha As Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_FechaRecibido As Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_FechaVencimiento As Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents AOT As FormulariosClasesBase.Cu_Asociar
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents AOC As FormulariosClasesBase.Cu_Asociar
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Cb_AurorizaDctoSS As System.Windows.Forms.ComboBox
End Class
