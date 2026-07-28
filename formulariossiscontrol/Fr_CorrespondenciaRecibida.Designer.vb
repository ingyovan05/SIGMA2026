<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_CorrespondenciaRecibida
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
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.Lb_Estado = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Lb_Fecha = New System.Windows.Forms.Label()
        Me.Lb_Funcionario = New System.Windows.Forms.Label()
        Me.Lb_Dependencia = New System.Windows.Forms.Label()
        Me.Bt_BuscarDe = New System.Windows.Forms.Button()
        Me.Tx_De = New System.Windows.Forms.TextBox()
        Me.Lb_Nit = New System.Windows.Forms.Label()
        Me.Tx_NroRadicado = New System.Windows.Forms.TextBox()
        Me.Lb_NroRadicado = New System.Windows.Forms.Label()
        Me.Ck_Automatico = New System.Windows.Forms.CheckBox()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Lb_Descripcion = New System.Windows.Forms.Label()
        Me.Tx_NroDocumento = New System.Windows.Forms.TextBox()
        Me.Lb_NroDocumento = New System.Windows.Forms.Label()
        Me.Dtp_FechaDocumento = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaDocumento = New System.Windows.Forms.Label()
        Me.Dtp_FechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaVencimiento = New System.Windows.Forms.Label()
        Me.Lb_ValorDocumento = New System.Windows.Forms.Label()
        Me.Lb_TipoDocumento = New System.Windows.Forms.Label()
        Me.Cb_TipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Lb_De = New System.Windows.Forms.Label()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Cu_AsociarPersonaBodega1 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaFuncionario = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Tx_Memo = New System.Windows.Forms.TextBox()
        Me.Lb_Memo = New System.Windows.Forms.Label()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Tlp_BarraInferior = New System.Windows.Forms.TableLayoutPanel()
        Me.CuTx_ValorDocumento = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.Tx_Nit = New System.Windows.Forms.TextBox()
        Me.Cb_Base = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoSticker = New System.Windows.Forms.Label()
        Me.Tt_InfoRecepcion = New System.Windows.Forms.ToolTip(Me.components)
        Me.Tx_Sticker = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarSticker = New System.Windows.Forms.Button()
        Me.Flp_Botones.SuspendLayout()
        Me.Tlp_BarraInferior.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(662, 30)
        Me.Lb_Titulo.TabIndex = 0
        Me.Lb_Titulo.Text = "CORRESPONDENCIA"
        Me.Lb_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_Estado
        '
        Me.Lb_Estado.AutoSize = True
        Me.Lb_Estado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Estado.ForeColor = System.Drawing.Color.Red
        Me.Lb_Estado.Location = New System.Drawing.Point(3, 0)
        Me.Lb_Estado.Name = "Lb_Estado"
        Me.Lb_Estado.Size = New System.Drawing.Size(67, 30)
        Me.Lb_Estado.TabIndex = 0
        Me.Lb_Estado.Text = "Lb_Estado"
        Me.Lb_Estado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lb_Estado.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(430, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(511, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Dtp_Fecha
        '
        Me.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha.Location = New System.Drawing.Point(125, 33)
        Me.Dtp_Fecha.Name = "Dtp_Fecha"
        Me.Dtp_Fecha.Size = New System.Drawing.Size(100, 20)
        Me.Dtp_Fecha.TabIndex = 2
        '
        'Lb_Fecha
        '
        Me.Lb_Fecha.AutoSize = True
        Me.Lb_Fecha.Location = New System.Drawing.Point(82, 36)
        Me.Lb_Fecha.Name = "Lb_Fecha"
        Me.Lb_Fecha.Size = New System.Drawing.Size(40, 13)
        Me.Lb_Fecha.TabIndex = 1
        Me.Lb_Fecha.Text = "Fecha:"
        '
        'Lb_Funcionario
        '
        Me.Lb_Funcionario.AutoSize = True
        Me.Lb_Funcionario.Location = New System.Drawing.Point(18, 90)
        Me.Lb_Funcionario.Name = "Lb_Funcionario"
        Me.Lb_Funcionario.Size = New System.Drawing.Size(104, 13)
        Me.Lb_Funcionario.TabIndex = 8
        Me.Lb_Funcionario.Text = "Funcionario Ismocol:"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_Funcionario, "Funcionario de la compañía a quien se dirige el documento")
        '
        'Lb_Dependencia
        '
        Me.Lb_Dependencia.AutoSize = True
        Me.Lb_Dependencia.Location = New System.Drawing.Point(51, 62)
        Me.Lb_Dependencia.Name = "Lb_Dependencia"
        Me.Lb_Dependencia.Size = New System.Drawing.Size(71, 13)
        Me.Lb_Dependencia.TabIndex = 5
        Me.Lb_Dependencia.Text = "Destino Final:"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_Dependencia, "Base y dependencia a la cual se dirige el documento")
        '
        'Bt_BuscarDe
        '
        Me.Bt_BuscarDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_BuscarDe.Location = New System.Drawing.Point(552, 114)
        Me.Bt_BuscarDe.Name = "Bt_BuscarDe"
        Me.Bt_BuscarDe.Size = New System.Drawing.Size(29, 23)
        Me.Bt_BuscarDe.TabIndex = 15
        Me.Bt_BuscarDe.Text = "..."
        Me.Bt_BuscarDe.UseVisualStyleBackColor = True
        '
        'Tx_De
        '
        Me.Tx_De.Location = New System.Drawing.Point(234, 115)
        Me.Tx_De.MaxLength = 200
        Me.Tx_De.Name = "Tx_De"
        Me.Tx_De.Size = New System.Drawing.Size(317, 20)
        Me.Tx_De.TabIndex = 14
        Me.Tt_InfoRecepcion.SetToolTip(Me.Tx_De, "Remitente del documento")
        '
        'Lb_Nit
        '
        Me.Lb_Nit.AutoSize = True
        Me.Lb_Nit.Location = New System.Drawing.Point(94, 118)
        Me.Lb_Nit.Name = "Lb_Nit"
        Me.Lb_Nit.Size = New System.Drawing.Size(28, 13)
        Me.Lb_Nit.TabIndex = 11
        Me.Lb_Nit.Text = "NIT:"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_Nit, "NIT del proveedor o tercero")
        '
        'Tx_NroRadicado
        '
        Me.Tx_NroRadicado.Location = New System.Drawing.Point(125, 141)
        Me.Tx_NroRadicado.MaxLength = 200
        Me.Tx_NroRadicado.Name = "Tx_NroRadicado"
        Me.Tx_NroRadicado.Size = New System.Drawing.Size(80, 20)
        Me.Tx_NroRadicado.TabIndex = 17
        Me.Tt_InfoRecepcion.SetToolTip(Me.Tx_NroRadicado, "Número de radicado de recepción")
        '
        'Lb_NroRadicado
        '
        Me.Lb_NroRadicado.AutoSize = True
        Me.Lb_NroRadicado.Location = New System.Drawing.Point(49, 144)
        Me.Lb_NroRadicado.Name = "Lb_NroRadicado"
        Me.Lb_NroRadicado.Size = New System.Drawing.Size(73, 13)
        Me.Lb_NroRadicado.TabIndex = 16
        Me.Lb_NroRadicado.Text = "Radicado No."
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_NroRadicado, "Número de radicado de recepción")
        '
        'Ck_Automatico
        '
        Me.Ck_Automatico.AutoSize = True
        Me.Ck_Automatico.Location = New System.Drawing.Point(212, 143)
        Me.Ck_Automatico.Name = "Ck_Automatico"
        Me.Ck_Automatico.Size = New System.Drawing.Size(120, 17)
        Me.Ck_Automatico.TabIndex = 18
        Me.Ck_Automatico.Text = "Automático x sesión"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Ck_Automatico, "Asignar radicado consecutivo para los documentos generados después de este regist" & _
        "ro")
        Me.Ck_Automatico.UseVisualStyleBackColor = True
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Location = New System.Drawing.Point(125, 166)
        Me.Tx_Descripcion.MaxLength = 80
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(526, 40)
        Me.Tx_Descripcion.TabIndex = 20
        Me.Tt_InfoRecepcion.SetToolTip(Me.Tx_Descripcion, "Descripción del documento")
        '
        'Lb_Descripcion
        '
        Me.Lb_Descripcion.AutoSize = True
        Me.Lb_Descripcion.Location = New System.Drawing.Point(56, 169)
        Me.Lb_Descripcion.Name = "Lb_Descripcion"
        Me.Lb_Descripcion.Size = New System.Drawing.Size(66, 13)
        Me.Lb_Descripcion.TabIndex = 19
        Me.Lb_Descripcion.Text = "Descripción:"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_Descripcion, "Descripción del documento")
        '
        'Tx_NroDocumento
        '
        Me.Tx_NroDocumento.Location = New System.Drawing.Point(125, 212)
        Me.Tx_NroDocumento.MaxLength = 200
        Me.Tx_NroDocumento.Name = "Tx_NroDocumento"
        Me.Tx_NroDocumento.Size = New System.Drawing.Size(80, 20)
        Me.Tx_NroDocumento.TabIndex = 22
        Me.Tt_InfoRecepcion.SetToolTip(Me.Tx_NroDocumento, "Número consecutivo del documento")
        '
        'Lb_NroDocumento
        '
        Me.Lb_NroDocumento.AutoSize = True
        Me.Lb_NroDocumento.Location = New System.Drawing.Point(37, 215)
        Me.Lb_NroDocumento.Name = "Lb_NroDocumento"
        Me.Lb_NroDocumento.Size = New System.Drawing.Size(85, 13)
        Me.Lb_NroDocumento.TabIndex = 21
        Me.Lb_NroDocumento.Text = "Nro Documento:"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_NroDocumento, "Número consecutivo del documento")
        '
        'Dtp_FechaDocumento
        '
        Me.Dtp_FechaDocumento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaDocumento.Location = New System.Drawing.Point(310, 212)
        Me.Dtp_FechaDocumento.Name = "Dtp_FechaDocumento"
        Me.Dtp_FechaDocumento.ShowCheckBox = True
        Me.Dtp_FechaDocumento.Size = New System.Drawing.Size(116, 20)
        Me.Dtp_FechaDocumento.TabIndex = 24
        Me.Tt_InfoRecepcion.SetToolTip(Me.Dtp_FechaDocumento, "Fecha indicada en el documento")
        '
        'Lb_FechaDocumento
        '
        Me.Lb_FechaDocumento.AutoSize = True
        Me.Lb_FechaDocumento.Location = New System.Drawing.Point(209, 215)
        Me.Lb_FechaDocumento.Name = "Lb_FechaDocumento"
        Me.Lb_FechaDocumento.Size = New System.Drawing.Size(98, 13)
        Me.Lb_FechaDocumento.TabIndex = 23
        Me.Lb_FechaDocumento.Text = "Fecha Documento:"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_FechaDocumento, "Fecha indicada en el documento")
        '
        'Dtp_FechaVencimiento
        '
        Me.Dtp_FechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaVencimiento.Location = New System.Drawing.Point(535, 212)
        Me.Dtp_FechaVencimiento.Name = "Dtp_FechaVencimiento"
        Me.Dtp_FechaVencimiento.ShowCheckBox = True
        Me.Dtp_FechaVencimiento.Size = New System.Drawing.Size(116, 20)
        Me.Dtp_FechaVencimiento.TabIndex = 26
        '
        'Lb_FechaVencimiento
        '
        Me.Lb_FechaVencimiento.AutoSize = True
        Me.Lb_FechaVencimiento.Location = New System.Drawing.Point(431, 215)
        Me.Lb_FechaVencimiento.Name = "Lb_FechaVencimiento"
        Me.Lb_FechaVencimiento.Size = New System.Drawing.Size(101, 13)
        Me.Lb_FechaVencimiento.TabIndex = 25
        Me.Lb_FechaVencimiento.Text = "Fecha Vencimiento:"
        '
        'Lb_ValorDocumento
        '
        Me.Lb_ValorDocumento.AutoSize = True
        Me.Lb_ValorDocumento.Location = New System.Drawing.Point(88, 241)
        Me.Lb_ValorDocumento.Name = "Lb_ValorDocumento"
        Me.Lb_ValorDocumento.Size = New System.Drawing.Size(34, 13)
        Me.Lb_ValorDocumento.TabIndex = 27
        Me.Lb_ValorDocumento.Text = "Valor:"
        '
        'Lb_TipoDocumento
        '
        Me.Lb_TipoDocumento.AutoSize = True
        Me.Lb_TipoDocumento.Location = New System.Drawing.Point(279, 35)
        Me.Lb_TipoDocumento.Name = "Lb_TipoDocumento"
        Me.Lb_TipoDocumento.Size = New System.Drawing.Size(31, 13)
        Me.Lb_TipoDocumento.TabIndex = 3
        Me.Lb_TipoDocumento.Text = "Tipo:"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_TipoDocumento, "Tipo de documento a registrar")
        '
        'Cb_TipoDocumento
        '
        Me.Cb_TipoDocumento.DisplayMember = "NOMBRE"
        Me.Cb_TipoDocumento.FormattingEnabled = True
        Me.Cb_TipoDocumento.Location = New System.Drawing.Point(313, 32)
        Me.Cb_TipoDocumento.Name = "Cb_TipoDocumento"
        Me.Cb_TipoDocumento.Size = New System.Drawing.Size(238, 21)
        Me.Cb_TipoDocumento.TabIndex = 4
        Me.Tt_InfoRecepcion.SetToolTip(Me.Cb_TipoDocumento, "Tipo de documento a registrar")
        Me.Cb_TipoDocumento.ValueMember = "IDDOCUMENTO"
        '
        'Lb_De
        '
        Me.Lb_De.AutoSize = True
        Me.Lb_De.Location = New System.Drawing.Point(207, 118)
        Me.Lb_De.Name = "Lb_De"
        Me.Lb_De.Size = New System.Drawing.Size(24, 13)
        Me.Lb_De.TabIndex = 13
        Me.Lb_De.Text = "De:"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_De, "Remitente del documento")
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.Location = New System.Drawing.Point(313, 59)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(238, 21)
        Me.Cb_Dependencia.TabIndex = 7
        Me.Tt_InfoRecepcion.SetToolTip(Me.Cb_Dependencia, "Dependencia a la que se dirige el documento")
        Me.Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
        '
        'Cu_AsociarPersonaBodega1
        '
        Me.Cu_AsociarPersonaBodega1.componenteasociado = "Cu_BuscarPersonaFuncionario"
        Me.Cu_AsociarPersonaBodega1.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega1.Location = New System.Drawing.Point(584, 87)
        Me.Cu_AsociarPersonaBodega1.Name = "Cu_AsociarPersonaBodega1"
        Me.Cu_AsociarPersonaBodega1.Size = New System.Drawing.Size(29, 23)
        Me.Cu_AsociarPersonaBodega1.TabIndex = 10
        Me.Cu_AsociarPersonaBodega1.TipoAsociacion = "DEP"
        Me.Cu_AsociarPersonaBodega1.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaFuncionario
        '
        Me.Cu_BuscarPersonaFuncionario.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaFuncionario.Location = New System.Drawing.Point(123, 86)
        Me.Cu_BuscarPersonaFuncionario.Name = "Cu_BuscarPersonaFuncionario"
        Me.Cu_BuscarPersonaFuncionario.Size = New System.Drawing.Size(462, 23)
        Me.Cu_BuscarPersonaFuncionario.TabIndex = 9
        Me.Cu_BuscarPersonaFuncionario.Tipo = "PADEP"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Cu_BuscarPersonaFuncionario, "Funcionario de la compañía a quien se dirige el documento")
        Me.Cu_BuscarPersonaFuncionario.valorcajatexto = "IDENTIFICACION"
        '
        'Tx_Memo
        '
        Me.Tx_Memo.Location = New System.Drawing.Point(257, 238)
        Me.Tx_Memo.MaxLength = 49
        Me.Tx_Memo.Name = "Tx_Memo"
        Me.Tx_Memo.Size = New System.Drawing.Size(169, 20)
        Me.Tx_Memo.TabIndex = 30
        Me.Tt_InfoRecepcion.SetToolTip(Me.Tx_Memo, "Consecutivo del memorando")
        '
        'Lb_Memo
        '
        Me.Lb_Memo.AutoSize = True
        Me.Lb_Memo.Location = New System.Drawing.Point(215, 241)
        Me.Lb_Memo.Name = "Lb_Memo"
        Me.Lb_Memo.Size = New System.Drawing.Size(39, 13)
        Me.Lb_Memo.TabIndex = 29
        Me.Lb_Memo.Text = "Memo:"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_Memo, "Consecutivo del memorando")
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(73, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(589, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Tlp_BarraInferior
        '
        Me.Tlp_BarraInferior.BackColor = System.Drawing.Color.DarkGray
        Me.Tlp_BarraInferior.ColumnCount = 2
        Me.Tlp_BarraInferior.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_BarraInferior.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_BarraInferior.Controls.Add(Me.Lb_Estado, 0, 0)
        Me.Tlp_BarraInferior.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_BarraInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_BarraInferior.Location = New System.Drawing.Point(0, 267)
        Me.Tlp_BarraInferior.Name = "Tlp_BarraInferior"
        Me.Tlp_BarraInferior.RowCount = 1
        Me.Tlp_BarraInferior.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_BarraInferior.Size = New System.Drawing.Size(662, 30)
        Me.Tlp_BarraInferior.TabIndex = 34
        '
        'CuTx_ValorDocumento
        '
        Me.CuTx_ValorDocumento.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(67)
        Me.CuTx_ValorDocumento.Location = New System.Drawing.Point(125, 238)
        Me.CuTx_ValorDocumento.MaxLongitudTexto = 20
        Me.CuTx_ValorDocumento.Name = "CuTx_ValorDocumento"
        Me.CuTx_ValorDocumento.PosicionesDecimales = CType(0US, UShort)
        Me.CuTx_ValorDocumento.Size = New System.Drawing.Size(80, 20)
        Me.CuTx_ValorDocumento.SoloLectura = False
        Me.CuTx_ValorDocumento.TabIndex = 28
        Me.CuTx_ValorDocumento.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Tx_Nit
        '
        Me.Tx_Nit.Location = New System.Drawing.Point(125, 115)
        Me.Tx_Nit.MaxLength = 20
        Me.Tx_Nit.Name = "Tx_Nit"
        Me.Tx_Nit.Size = New System.Drawing.Size(80, 20)
        Me.Tx_Nit.TabIndex = 12
        Me.Tt_InfoRecepcion.SetToolTip(Me.Tx_Nit, "NIT del proveedor o tercero")
        '
        'Cb_Base
        '
        Me.Cb_Base.DisplayMember = "BASE"
        Me.Cb_Base.FormattingEnabled = True
        Me.Cb_Base.Location = New System.Drawing.Point(125, 59)
        Me.Cb_Base.Name = "Cb_Base"
        Me.Cb_Base.Size = New System.Drawing.Size(182, 21)
        Me.Cb_Base.TabIndex = 6
        Me.Tt_InfoRecepcion.SetToolTip(Me.Cb_Base, "Base a la cual se dirige el documento")
        Me.Cb_Base.ValueMember = "IDBASESISCONTROL"
        '
        'Lb_TextoSticker
        '
        Me.Lb_TextoSticker.AutoSize = True
        Me.Lb_TextoSticker.Location = New System.Drawing.Point(489, 241)
        Me.Lb_TextoSticker.Name = "Lb_TextoSticker"
        Me.Lb_TextoSticker.Size = New System.Drawing.Size(43, 13)
        Me.Lb_TextoSticker.TabIndex = 31
        Me.Lb_TextoSticker.Text = "Sticker:"
        Me.Tt_InfoRecepcion.SetToolTip(Me.Lb_TextoSticker, "Número del sticker asignado al documento")
        '
        'Tx_Sticker
        '
        Me.Tx_Sticker.Location = New System.Drawing.Point(535, 238)
        Me.Tx_Sticker.Name = "Tx_Sticker"
        Me.Tx_Sticker.Size = New System.Drawing.Size(87, 20)
        Me.Tx_Sticker.TabIndex = 32
        Me.Tt_InfoRecepcion.SetToolTip(Me.Tx_Sticker, "Número del sticker asignado al documento")
        '
        'Bt_BuscarSticker
        '
        Me.Bt_BuscarSticker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_BuscarSticker.Location = New System.Drawing.Point(623, 237)
        Me.Bt_BuscarSticker.Name = "Bt_BuscarSticker"
        Me.Bt_BuscarSticker.Size = New System.Drawing.Size(29, 23)
        Me.Bt_BuscarSticker.TabIndex = 33
        Me.Bt_BuscarSticker.Text = "..."
        Me.Bt_BuscarSticker.UseVisualStyleBackColor = True
        '
        'Fr_CorrespondenciaRecibida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 297)
        Me.Controls.Add(Me.Tx_Sticker)
        Me.Controls.Add(Me.Bt_BuscarSticker)
        Me.Controls.Add(Me.Lb_Titulo)
        Me.Controls.Add(Me.Lb_Fecha)
        Me.Controls.Add(Me.Dtp_Fecha)
        Me.Controls.Add(Me.Lb_TipoDocumento)
        Me.Controls.Add(Me.Cb_TipoDocumento)
        Me.Controls.Add(Me.Lb_Dependencia)
        Me.Controls.Add(Me.Cb_Base)
        Me.Controls.Add(Me.Cb_Dependencia)
        Me.Controls.Add(Me.Lb_Funcionario)
        Me.Controls.Add(Me.Cu_BuscarPersonaFuncionario)
        Me.Controls.Add(Me.Cu_AsociarPersonaBodega1)
        Me.Controls.Add(Me.Lb_Nit)
        Me.Controls.Add(Me.Tx_Nit)
        Me.Controls.Add(Me.Lb_De)
        Me.Controls.Add(Me.Tx_De)
        Me.Controls.Add(Me.Bt_BuscarDe)
        Me.Controls.Add(Me.Lb_NroRadicado)
        Me.Controls.Add(Me.Tx_NroRadicado)
        Me.Controls.Add(Me.Ck_Automatico)
        Me.Controls.Add(Me.Lb_Descripcion)
        Me.Controls.Add(Me.Tx_Descripcion)
        Me.Controls.Add(Me.Lb_NroDocumento)
        Me.Controls.Add(Me.Tx_NroDocumento)
        Me.Controls.Add(Me.Lb_FechaDocumento)
        Me.Controls.Add(Me.Dtp_FechaDocumento)
        Me.Controls.Add(Me.Lb_FechaVencimiento)
        Me.Controls.Add(Me.Dtp_FechaVencimiento)
        Me.Controls.Add(Me.Lb_ValorDocumento)
        Me.Controls.Add(Me.CuTx_ValorDocumento)
        Me.Controls.Add(Me.Lb_Memo)
        Me.Controls.Add(Me.Tx_Memo)
        Me.Controls.Add(Me.Lb_TextoSticker)
        Me.Controls.Add(Me.Tlp_BarraInferior)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_CorrespondenciaRecibida"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Correspondencia"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Tlp_BarraInferior.ResumeLayout(False)
        Me.Tlp_BarraInferior.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lb_Titulo As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_Fecha As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaFuncionario As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_Funcionario As System.Windows.Forms.Label
    Friend WithEvents Lb_Dependencia As System.Windows.Forms.Label
    Friend WithEvents Bt_BuscarDe As System.Windows.Forms.Button
    Friend WithEvents Tx_De As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Nit As System.Windows.Forms.Label
    Friend WithEvents Tx_NroRadicado As System.Windows.Forms.TextBox
    Friend WithEvents Lb_NroRadicado As System.Windows.Forms.Label
    Friend WithEvents Ck_Automatico As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Tx_NroDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Lb_NroDocumento As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaDocumento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaDocumento As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaVencimiento As System.Windows.Forms.Label
    Friend WithEvents Lb_ValorDocumento As System.Windows.Forms.Label
    Friend WithEvents Lb_TipoDocumento As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_De As System.Windows.Forms.Label
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Public WithEvents Lb_Estado As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaBodega1 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Tx_Memo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Memo As System.Windows.Forms.Label
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Tlp_BarraInferior As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CuTx_ValorDocumento As FormulariosClasesBase.Cu_TextBoxDecimal
    Friend WithEvents Tx_Nit As System.Windows.Forms.TextBox
    Friend WithEvents Cb_Base As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoSticker As System.Windows.Forms.Label
    Friend WithEvents Tt_InfoRecepcion As System.Windows.Forms.ToolTip
    Friend WithEvents Bt_BuscarSticker As System.Windows.Forms.Button
    Friend WithEvents Tx_Sticker As System.Windows.Forms.TextBox
End Class
