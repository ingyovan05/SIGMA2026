<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_SalidaAlmacen
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cb_TipoSalida = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tb_Observaciones = New System.Windows.Forms.TextBox()
        Me.Bt_CancelarSalida = New System.Windows.Forms.Button()
        Me.Bt_GuardarSalida = New System.Windows.Forms.Button()
        Me.Pn_Encabezado = New System.Windows.Forms.Panel()
        Me.Tx_lectora = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cu_AsociarOT = New FormulariosClasesBase.Cu_Asociar()
        Me.Lb_TipoEnvio = New System.Windows.Forms.Label()
        Me.Bt_GestionarActividades = New System.Windows.Forms.Button()
        Me.Cb_TipoEnvio = New System.Windows.Forms.ComboBox()
        Me.Tx_Guía = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Bt_BuscarPlaca = New System.Windows.Forms.Button()
        Me.Tx_PlacaVehiculo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Cu_AsociarActivoFijo1 = New FormulariosClasesBase.Cu_AsociarActivoFijo()
        Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Bt_AgregarOC = New System.Windows.Forms.Button()
        Me.Cb_OrdenCompra = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Bt_AsociarRq = New System.Windows.Forms.Button()
        Me.Cb_AsociarRq = New System.Windows.Forms.ComboBox()
        Me.Lb_AsociarRq = New System.Windows.Forms.Label()
        Me.Bt_AgregarActividad = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cb_Actividad = New System.Windows.Forms.ComboBox()
        Me.Dtp_FechaDespacho = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tx_RecibeTransportador = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tx_Transportador = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Bt_Agregar = New System.Windows.Forms.Button()
        Me.Cb_Relación = New System.Windows.Forms.ComboBox()
        Me.Lb_Relación = New System.Windows.Forms.Label()
        Me.Tx_Destino = New System.Windows.Forms.TextBox()
        Me.Dgv_item = New System.Windows.Forms.DataGridView()
        Me.ItemDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CódigoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UndDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripciónDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Existencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdenCompraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemOCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequisiciónDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemRQDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDREQUISICIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDREMISIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDORDENCOMPRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValidarCant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LISTAITEMSALIDAALMACENBindingSource = New System.Windows.Forms.BindingSource()
        Me.Ds_SalidaAlmacén = New DatosSalidaAlmacén.Ds_SalidaAlmacén()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Cbx_VerificacionEquipos = New System.Windows.Forms.CheckBox()
        Me.Bt_SeleccionarEquipos = New System.Windows.Forms.Button()
        Me.Ll_ActualizarContacto = New System.Windows.Forms.LinkLabel()
        Me.Pn_Personas = New System.Windows.Forms.Panel()
        Me.Cu_APB_Recibe = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaRecibe = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cu_APB_Autoriza = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_APB_Despacha = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaDespacha = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersonaAutoriza = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Pn_item = New System.Windows.Forms.Panel()
        Me.Pn_TituloItemRequisición = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
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
        'Me.LISTAITEMSALIDAALMACENTableAdapter = New DatosSalidaAlmacén.Ds_SalidaAlmacénTableAdapters.LISTAITEMSALIDAALMACENTableAdapter()
        Me.Pn_Encabezado.SuspendLayout()
        CType(Me.Dgv_item, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LISTAITEMSALIDAALMACENBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_SalidaAlmacén, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Botones.SuspendLayout()
        Me.Pn_Personas.SuspendLayout()
        Me.Pn_item.SuspendLayout()
        Me.Pn_TituloItemRequisición.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo de Salida:"
        '
        'Cb_TipoSalida
        '
        Me.Cb_TipoSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoSalida.FormattingEnabled = True
        Me.Cb_TipoSalida.Location = New System.Drawing.Point(109, 7)
        Me.Cb_TipoSalida.Name = "Cb_TipoSalida"
        Me.Cb_TipoSalida.Size = New System.Drawing.Size(140, 21)
        Me.Cb_TipoSalida.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(62, 92)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Destino:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Observaciones:"
        '
        'Tb_Observaciones
        '
        Me.Tb_Observaciones.Location = New System.Drawing.Point(109, 137)
        Me.Tb_Observaciones.MaxLength = 200
        Me.Tb_Observaciones.Multiline = True
        Me.Tb_Observaciones.Name = "Tb_Observaciones"
        Me.Tb_Observaciones.Size = New System.Drawing.Size(807, 39)
        Me.Tb_Observaciones.TabIndex = 31
        '
        'Bt_CancelarSalida
        '
        Me.Bt_CancelarSalida.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_CancelarSalida.Location = New System.Drawing.Point(844, 4)
        Me.Bt_CancelarSalida.Name = "Bt_CancelarSalida"
        Me.Bt_CancelarSalida.Size = New System.Drawing.Size(75, 23)
        Me.Bt_CancelarSalida.TabIndex = 4
        Me.Bt_CancelarSalida.Text = "Cancelar"
        Me.Bt_CancelarSalida.UseVisualStyleBackColor = True
        '
        'Bt_GuardarSalida
        '
        Me.Bt_GuardarSalida.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_GuardarSalida.Location = New System.Drawing.Point(763, 4)
        Me.Bt_GuardarSalida.Name = "Bt_GuardarSalida"
        Me.Bt_GuardarSalida.Size = New System.Drawing.Size(75, 23)
        Me.Bt_GuardarSalida.TabIndex = 3
        Me.Bt_GuardarSalida.Text = "Guardar"
        Me.Bt_GuardarSalida.UseVisualStyleBackColor = True
        '
        'Pn_Encabezado
        '
        Me.Pn_Encabezado.AutoSize = True
        Me.Pn_Encabezado.Controls.Add(Me.Tx_lectora)
        Me.Pn_Encabezado.Controls.Add(Me.Label15)
        Me.Pn_Encabezado.Controls.Add(Me.Label14)
        Me.Pn_Encabezado.Controls.Add(Me.Cu_AsociarOT)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_TipoEnvio)
        Me.Pn_Encabezado.Controls.Add(Me.Bt_GestionarActividades)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_TipoEnvio)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_Guía)
        Me.Pn_Encabezado.Controls.Add(Me.Label11)
        Me.Pn_Encabezado.Controls.Add(Me.Bt_BuscarPlaca)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_PlacaVehiculo)
        Me.Pn_Encabezado.Controls.Add(Me.Label9)
        Me.Pn_Encabezado.Controls.Add(Me.Cu_AsociarActivoFijo1)
        Me.Pn_Encabezado.Controls.Add(Me.Cu_CentroCosto1)
        Me.Pn_Encabezado.Controls.Add(Me.Bt_AgregarOC)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_OrdenCompra)
        Me.Pn_Encabezado.Controls.Add(Me.Label12)
        Me.Pn_Encabezado.Controls.Add(Me.Bt_AsociarRq)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_AsociarRq)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_AsociarRq)
        Me.Pn_Encabezado.Controls.Add(Me.Bt_AgregarActividad)
        Me.Pn_Encabezado.Controls.Add(Me.Label6)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_Actividad)
        Me.Pn_Encabezado.Controls.Add(Me.Dtp_FechaDespacho)
        Me.Pn_Encabezado.Controls.Add(Me.Label1)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_RecibeTransportador)
        Me.Pn_Encabezado.Controls.Add(Me.Label7)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_Transportador)
        Me.Pn_Encabezado.Controls.Add(Me.Label8)
        Me.Pn_Encabezado.Controls.Add(Me.Bt_Agregar)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_Relación)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_Relación)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_Destino)
        Me.Pn_Encabezado.Controls.Add(Me.Label2)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_TipoSalida)
        Me.Pn_Encabezado.Controls.Add(Me.Label13)
        Me.Pn_Encabezado.Controls.Add(Me.Tb_Observaciones)
        Me.Pn_Encabezado.Controls.Add(Me.Label3)
        Me.Pn_Encabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Encabezado.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Encabezado.Name = "Pn_Encabezado"
        Me.Pn_Encabezado.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Pn_Encabezado.Size = New System.Drawing.Size(922, 209)
        Me.Pn_Encabezado.TabIndex = 0
        '
        'Tx_lectora
        '
        Me.Tx_lectora.Location = New System.Drawing.Point(818, 181)
        Me.Tx_lectora.MaxLength = 7
        Me.Tx_lectora.Name = "Tx_lectora"
        Me.Tx_lectora.Size = New System.Drawing.Size(98, 20)
        Me.Tx_lectora.TabIndex = 37
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(725, 184)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Capturar Lectora:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(270, 185)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(164, 13)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Asociar Orden de Mantenimiento:"
        '
        'Cu_AsociarOT
        '
        Me.Cu_AsociarOT.Location = New System.Drawing.Point(437, 183)
        Me.Cu_AsociarOT.Name = "Cu_AsociarOT"
        Me.Cu_AsociarOT.Size = New System.Drawing.Size(219, 20)
        Me.Cu_AsociarOT.TabIndex = 34
        Me.Cu_AsociarOT.Tipo = "OT"
        '
        'Lb_TipoEnvio
        '
        Me.Lb_TipoEnvio.AutoSize = True
        Me.Lb_TipoEnvio.Location = New System.Drawing.Point(29, 186)
        Me.Lb_TipoEnvio.Name = "Lb_TipoEnvio"
        Me.Lb_TipoEnvio.Size = New System.Drawing.Size(78, 13)
        Me.Lb_TipoEnvio.TabIndex = 32
        Me.Lb_TipoEnvio.Text = "Tipo de Envío:"
        '
        'Bt_GestionarActividades
        '
        Me.Bt_GestionarActividades.Location = New System.Drawing.Point(660, 59)
        Me.Bt_GestionarActividades.Name = "Bt_GestionarActividades"
        Me.Bt_GestionarActividades.Size = New System.Drawing.Size(29, 23)
        Me.Bt_GestionarActividades.TabIndex = 16
        Me.Bt_GestionarActividades.Text = "..."
        Me.Bt_GestionarActividades.UseVisualStyleBackColor = True
        '
        'Cb_TipoEnvio
        '
        Me.Cb_TipoEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoEnvio.FormattingEnabled = True
        Me.Cb_TipoEnvio.Location = New System.Drawing.Point(109, 182)
        Me.Cb_TipoEnvio.Name = "Cb_TipoEnvio"
        Me.Cb_TipoEnvio.Size = New System.Drawing.Size(140, 21)
        Me.Cb_TipoEnvio.TabIndex = 33
        Me.Cb_TipoEnvio.Tag = "565"
        '
        'Tx_Guía
        '
        Me.Tx_Guía.Location = New System.Drawing.Point(727, 89)
        Me.Tx_Guía.MaxLength = 20
        Me.Tx_Guía.Name = "Tx_Guía"
        Me.Tx_Guía.Size = New System.Drawing.Size(188, 20)
        Me.Tx_Guía.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(694, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Guía:"
        '
        'Bt_BuscarPlaca
        '
        Me.Bt_BuscarPlaca.Location = New System.Drawing.Point(436, 112)
        Me.Bt_BuscarPlaca.Name = "Bt_BuscarPlaca"
        Me.Bt_BuscarPlaca.Size = New System.Drawing.Size(29, 22)
        Me.Bt_BuscarPlaca.TabIndex = 27
        Me.Bt_BuscarPlaca.Text = "..."
        '
        'Tx_PlacaVehiculo
        '
        Me.Tx_PlacaVehiculo.Location = New System.Drawing.Point(364, 113)
        Me.Tx_PlacaVehiculo.MaxLength = 7
        Me.Tx_PlacaVehiculo.Name = "Tx_PlacaVehiculo"
        Me.Tx_PlacaVehiculo.Size = New System.Drawing.Size(70, 20)
        Me.Tx_PlacaVehiculo.TabIndex = 26
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(283, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Placa Vehículo:"
        '
        'Cu_AsociarActivoFijo1
        '
        Me.Cu_AsociarActivoFijo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_AsociarActivoFijo1.Location = New System.Drawing.Point(695, 44)
        Me.Cu_AsociarActivoFijo1.Name = "Cu_AsociarActivoFijo1"
        Me.Cu_AsociarActivoFijo1.Size = New System.Drawing.Size(221, 38)
        Me.Cu_AsociarActivoFijo1.TabIndex = 12
        '
        'Cu_CentroCosto1
        '
        Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto1.Location = New System.Drawing.Point(696, 4)
        Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
        Me.Cu_CentroCosto1.Size = New System.Drawing.Size(221, 38)
        Me.Cu_CentroCosto1.TabIndex = 5
        '
        'Bt_AgregarOC
        '
        Me.Bt_AgregarOC.Location = New System.Drawing.Point(660, 33)
        Me.Bt_AgregarOC.Name = "Bt_AgregarOC"
        Me.Bt_AgregarOC.Size = New System.Drawing.Size(29, 23)
        Me.Bt_AgregarOC.TabIndex = 11
        Me.Bt_AgregarOC.Text = "+"
        Me.Bt_AgregarOC.UseVisualStyleBackColor = True
        '
        'Cb_OrdenCompra
        '
        Me.Cb_OrdenCompra.FormattingEnabled = True
        Me.Cb_OrdenCompra.Location = New System.Drawing.Point(489, 35)
        Me.Cb_OrdenCompra.Name = "Cb_OrdenCompra"
        Me.Cb_OrdenCompra.Size = New System.Drawing.Size(165, 21)
        Me.Cb_OrdenCompra.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(290, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(197, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Enviar Artículos de la Orden de Compra:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bt_AsociarRq
        '
        Me.Bt_AsociarRq.Location = New System.Drawing.Point(253, 33)
        Me.Bt_AsociarRq.Name = "Bt_AsociarRq"
        Me.Bt_AsociarRq.Size = New System.Drawing.Size(29, 23)
        Me.Bt_AsociarRq.TabIndex = 8
        Me.Bt_AsociarRq.Text = "+"
        Me.Bt_AsociarRq.UseVisualStyleBackColor = True
        '
        'Cb_AsociarRq
        '
        Me.Cb_AsociarRq.FormattingEnabled = True
        Me.Cb_AsociarRq.Location = New System.Drawing.Point(109, 34)
        Me.Cb_AsociarRq.Name = "Cb_AsociarRq"
        Me.Cb_AsociarRq.Size = New System.Drawing.Size(140, 21)
        Me.Cb_AsociarRq.TabIndex = 7
        '
        'Lb_AsociarRq
        '
        Me.Lb_AsociarRq.AutoSize = True
        Me.Lb_AsociarRq.Location = New System.Drawing.Point(1, 38)
        Me.Lb_AsociarRq.Name = "Lb_AsociarRq"
        Me.Lb_AsociarRq.Size = New System.Drawing.Size(107, 13)
        Me.Lb_AsociarRq.TabIndex = 6
        Me.Lb_AsociarRq.Text = "Asociar a requisición:"
        Me.Lb_AsociarRq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bt_AgregarActividad
        '
        Me.Bt_AgregarActividad.Location = New System.Drawing.Point(625, 59)
        Me.Bt_AgregarActividad.Name = "Bt_AgregarActividad"
        Me.Bt_AgregarActividad.Size = New System.Drawing.Size(29, 23)
        Me.Bt_AgregarActividad.TabIndex = 15
        Me.Bt_AgregarActividad.Text = "+"
        Me.Bt_AgregarActividad.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(54, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Actividad:"
        '
        'Cb_Actividad
        '
        Me.Cb_Actividad.FormattingEnabled = True
        Me.Cb_Actividad.Location = New System.Drawing.Point(109, 61)
        Me.Cb_Actividad.Name = "Cb_Actividad"
        Me.Cb_Actividad.Size = New System.Drawing.Size(510, 21)
        Me.Cb_Actividad.TabIndex = 14
        '
        'Dtp_FechaDespacho
        '
        Me.Dtp_FechaDespacho.Checked = False
        Me.Dtp_FechaDespacho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaDespacho.Location = New System.Drawing.Point(573, 88)
        Me.Dtp_FechaDespacho.Name = "Dtp_FechaDespacho"
        Me.Dtp_FechaDespacho.ShowCheckBox = True
        Me.Dtp_FechaDespacho.Size = New System.Drawing.Size(116, 20)
        Me.Dtp_FechaDespacho.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(479, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Fecha Despacho:"
        '
        'Tx_RecibeTransportador
        '
        Me.Tx_RecibeTransportador.Location = New System.Drawing.Point(573, 113)
        Me.Tx_RecibeTransportador.MaxLength = 50
        Me.Tx_RecibeTransportador.Name = "Tx_RecibeTransportador"
        Me.Tx_RecibeTransportador.Size = New System.Drawing.Size(343, 20)
        Me.Tx_RecibeTransportador.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(495, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Transportador:"
        '
        'Tx_Transportador
        '
        Me.Tx_Transportador.Location = New System.Drawing.Point(109, 113)
        Me.Tx_Transportador.MaxLength = 50
        Me.Tx_Transportador.Name = "Tx_Transportador"
        Me.Tx_Transportador.Size = New System.Drawing.Size(170, 20)
        Me.Tx_Transportador.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Empresa Transporta:"
        '
        'Bt_Agregar
        '
        Me.Bt_Agregar.Location = New System.Drawing.Point(539, 7)
        Me.Bt_Agregar.Name = "Bt_Agregar"
        Me.Bt_Agregar.Size = New System.Drawing.Size(29, 23)
        Me.Bt_Agregar.TabIndex = 4
        Me.Bt_Agregar.Text = "+"
        Me.Bt_Agregar.UseVisualStyleBackColor = True
        Me.Bt_Agregar.Visible = False
        '
        'Cb_Relación
        '
        Me.Cb_Relación.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Relación.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Relación.FormattingEnabled = True
        Me.Cb_Relación.Location = New System.Drawing.Point(350, 8)
        Me.Cb_Relación.Name = "Cb_Relación"
        Me.Cb_Relación.Size = New System.Drawing.Size(183, 21)
        Me.Cb_Relación.TabIndex = 3
        '
        'Lb_Relación
        '
        Me.Lb_Relación.Location = New System.Drawing.Point(253, 12)
        Me.Lb_Relación.Name = "Lb_Relación"
        Me.Lb_Relación.Size = New System.Drawing.Size(96, 13)
        Me.Lb_Relación.TabIndex = 2
        Me.Lb_Relación.Text = "Relación:"
        Me.Lb_Relación.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Tx_Destino
        '
        Me.Tx_Destino.Location = New System.Drawing.Point(109, 88)
        Me.Tx_Destino.MaxLength = 100
        Me.Tx_Destino.Name = "Tx_Destino"
        Me.Tx_Destino.Size = New System.Drawing.Size(356, 20)
        Me.Tx_Destino.TabIndex = 18
        '
        'Dgv_item
        '
        Me.Dgv_item.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_item.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_item.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemDataGridViewTextBoxColumn, Me.CódigoDataGridViewTextBoxColumn, Me.UndDataGridViewTextBoxColumn, Me.DescripciónDataGridViewTextBoxColumn, Me.CantDataGridViewTextBoxColumn, Me.Existencia, Me.OrdenCompraDataGridViewTextBoxColumn, Me.ItemOCDataGridViewTextBoxColumn, Me.RequisiciónDataGridViewTextBoxColumn, Me.ItemRQDataGridViewTextBoxColumn, Me.IDREQUISICIONDataGridViewTextBoxColumn, Me.IDREMISIONDataGridViewTextBoxColumn, Me.IDORDENCOMPRADataGridViewTextBoxColumn, Me.ValidarCant})
        Me.Dgv_item.DataSource = Me.LISTAITEMSALIDAALMACENBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv_item.DefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_item.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_item.Location = New System.Drawing.Point(0, 24)
        Me.Dgv_item.Name = "Dgv_item"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_item.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_item.Size = New System.Drawing.Size(922, 199)
        Me.Dgv_item.TabIndex = 1
        '
        'ItemDataGridViewTextBoxColumn
        '
        Me.ItemDataGridViewTextBoxColumn.DataPropertyName = "Item"
        Me.ItemDataGridViewTextBoxColumn.HeaderText = "Item"
        Me.ItemDataGridViewTextBoxColumn.Name = "ItemDataGridViewTextBoxColumn"
        Me.ItemDataGridViewTextBoxColumn.Width = 50
        '
        'CódigoDataGridViewTextBoxColumn
        '
        Me.CódigoDataGridViewTextBoxColumn.DataPropertyName = "Código"
        Me.CódigoDataGridViewTextBoxColumn.HeaderText = "Código"
        Me.CódigoDataGridViewTextBoxColumn.Name = "CódigoDataGridViewTextBoxColumn"
        Me.CódigoDataGridViewTextBoxColumn.Width = 50
        '
        'UndDataGridViewTextBoxColumn
        '
        Me.UndDataGridViewTextBoxColumn.DataPropertyName = "Und"
        Me.UndDataGridViewTextBoxColumn.HeaderText = "Und"
        Me.UndDataGridViewTextBoxColumn.Name = "UndDataGridViewTextBoxColumn"
        Me.UndDataGridViewTextBoxColumn.ReadOnly = True
        Me.UndDataGridViewTextBoxColumn.Width = 40
        '
        'DescripciónDataGridViewTextBoxColumn
        '
        Me.DescripciónDataGridViewTextBoxColumn.DataPropertyName = "Descripción"
        Me.DescripciónDataGridViewTextBoxColumn.HeaderText = "Descripción"
        Me.DescripciónDataGridViewTextBoxColumn.Name = "DescripciónDataGridViewTextBoxColumn"
        Me.DescripciónDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescripciónDataGridViewTextBoxColumn.Width = 260
        '
        'CantDataGridViewTextBoxColumn
        '
        Me.CantDataGridViewTextBoxColumn.DataPropertyName = "Cant"
        Me.CantDataGridViewTextBoxColumn.HeaderText = "Cant"
        Me.CantDataGridViewTextBoxColumn.Name = "CantDataGridViewTextBoxColumn"
        Me.CantDataGridViewTextBoxColumn.Width = 50
        '
        'Existencia
        '
        Me.Existencia.DataPropertyName = "Existencia"
        Me.Existencia.HeaderText = "Exist"
        Me.Existencia.Name = "Existencia"
        Me.Existencia.ReadOnly = True
        '
        'OrdenCompraDataGridViewTextBoxColumn
        '
        Me.OrdenCompraDataGridViewTextBoxColumn.DataPropertyName = "Orden Compra"
        Me.OrdenCompraDataGridViewTextBoxColumn.HeaderText = "Orden Compra"
        Me.OrdenCompraDataGridViewTextBoxColumn.Name = "OrdenCompraDataGridViewTextBoxColumn"
        Me.OrdenCompraDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrdenCompraDataGridViewTextBoxColumn.Width = 110
        '
        'ItemOCDataGridViewTextBoxColumn
        '
        Me.ItemOCDataGridViewTextBoxColumn.DataPropertyName = "Item OC"
        Me.ItemOCDataGridViewTextBoxColumn.HeaderText = "Item OC"
        Me.ItemOCDataGridViewTextBoxColumn.Name = "ItemOCDataGridViewTextBoxColumn"
        Me.ItemOCDataGridViewTextBoxColumn.ReadOnly = True
        Me.ItemOCDataGridViewTextBoxColumn.Width = 40
        '
        'RequisiciónDataGridViewTextBoxColumn
        '
        Me.RequisiciónDataGridViewTextBoxColumn.DataPropertyName = "Requisición"
        Me.RequisiciónDataGridViewTextBoxColumn.HeaderText = "Requisición"
        Me.RequisiciónDataGridViewTextBoxColumn.Name = "RequisiciónDataGridViewTextBoxColumn"
        Me.RequisiciónDataGridViewTextBoxColumn.ReadOnly = True
        Me.RequisiciónDataGridViewTextBoxColumn.Width = 110
        '
        'ItemRQDataGridViewTextBoxColumn
        '
        Me.ItemRQDataGridViewTextBoxColumn.DataPropertyName = "Item RQ"
        Me.ItemRQDataGridViewTextBoxColumn.HeaderText = "Item RQ"
        Me.ItemRQDataGridViewTextBoxColumn.Name = "ItemRQDataGridViewTextBoxColumn"
        Me.ItemRQDataGridViewTextBoxColumn.ReadOnly = True
        Me.ItemRQDataGridViewTextBoxColumn.Width = 40
        '
        'IDREQUISICIONDataGridViewTextBoxColumn
        '
        Me.IDREQUISICIONDataGridViewTextBoxColumn.DataPropertyName = "IDREQUISICION"
        Me.IDREQUISICIONDataGridViewTextBoxColumn.HeaderText = "IDREQUISICION"
        Me.IDREQUISICIONDataGridViewTextBoxColumn.Name = "IDREQUISICIONDataGridViewTextBoxColumn"
        Me.IDREQUISICIONDataGridViewTextBoxColumn.Visible = False
        '
        'IDREMISIONDataGridViewTextBoxColumn
        '
        Me.IDREMISIONDataGridViewTextBoxColumn.DataPropertyName = "IDREMISION"
        Me.IDREMISIONDataGridViewTextBoxColumn.HeaderText = "IDREMISION"
        Me.IDREMISIONDataGridViewTextBoxColumn.Name = "IDREMISIONDataGridViewTextBoxColumn"
        Me.IDREMISIONDataGridViewTextBoxColumn.Visible = False
        '
        'IDORDENCOMPRADataGridViewTextBoxColumn
        '
        Me.IDORDENCOMPRADataGridViewTextBoxColumn.DataPropertyName = "IDORDENCOMPRA"
        Me.IDORDENCOMPRADataGridViewTextBoxColumn.HeaderText = "IDORDENCOMPRA"
        Me.IDORDENCOMPRADataGridViewTextBoxColumn.Name = "IDORDENCOMPRADataGridViewTextBoxColumn"
        Me.IDORDENCOMPRADataGridViewTextBoxColumn.Visible = False
        '
        'ValidarCant
        '
        Me.ValidarCant.DataPropertyName = "ValidarCant"
        Me.ValidarCant.HeaderText = "ValidarCant"
        Me.ValidarCant.Name = "ValidarCant"
        Me.ValidarCant.Visible = False
        '
        'LISTAITEMSALIDAALMACENBindingSource
        '
        Me.LISTAITEMSALIDAALMACENBindingSource.DataMember = "LISTAITEMSALIDAALMACEN"
        Me.LISTAITEMSALIDAALMACENBindingSource.DataSource = Me.Ds_SalidaAlmacén
        '
        'Ds_SalidaAlmacén
        '
        Me.Ds_SalidaAlmacén.DataSetName = "Ds_SalidaAlmacén"
        Me.Ds_SalidaAlmacén.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.Color.Silver
        Me.Pn_Botones.Controls.Add(Me.Cbx_VerificacionEquipos)
        Me.Pn_Botones.Controls.Add(Me.Bt_SeleccionarEquipos)
        Me.Pn_Botones.Controls.Add(Me.Ll_ActualizarContacto)
        Me.Pn_Botones.Controls.Add(Me.Bt_GuardarSalida)
        Me.Pn_Botones.Controls.Add(Me.Bt_CancelarSalida)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 488)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(922, 30)
        Me.Pn_Botones.TabIndex = 3
        '
        'Cbx_VerificacionEquipos
        '
        Me.Cbx_VerificacionEquipos.AutoSize = True
        Me.Cbx_VerificacionEquipos.Checked = True
        Me.Cbx_VerificacionEquipos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cbx_VerificacionEquipos.Enabled = False
        Me.Cbx_VerificacionEquipos.Location = New System.Drawing.Point(594, 9)
        Me.Cbx_VerificacionEquipos.Name = "Cbx_VerificacionEquipos"
        Me.Cbx_VerificacionEquipos.Size = New System.Drawing.Size(15, 14)
        Me.Cbx_VerificacionEquipos.TabIndex = 1
        Me.Cbx_VerificacionEquipos.UseVisualStyleBackColor = True
        '
        'Bt_SeleccionarEquipos
        '
        Me.Bt_SeleccionarEquipos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_SeleccionarEquipos.Enabled = False
        Me.Bt_SeleccionarEquipos.Location = New System.Drawing.Point(622, 4)
        Me.Bt_SeleccionarEquipos.Name = "Bt_SeleccionarEquipos"
        Me.Bt_SeleccionarEquipos.Size = New System.Drawing.Size(135, 23)
        Me.Bt_SeleccionarEquipos.TabIndex = 2
        Me.Bt_SeleccionarEquipos.Text = "Seleccionar/Ver Equipos"
        Me.Bt_SeleccionarEquipos.UseVisualStyleBackColor = True
        '
        'Ll_ActualizarContacto
        '
        Me.Ll_ActualizarContacto.AutoSize = True
        Me.Ll_ActualizarContacto.Location = New System.Drawing.Point(446, 9)
        Me.Ll_ActualizarContacto.Name = "Ll_ActualizarContacto"
        Me.Ll_ActualizarContacto.Size = New System.Drawing.Size(125, 13)
        Me.Ll_ActualizarContacto.TabIndex = 0
        Me.Ll_ActualizarContacto.TabStop = True
        Me.Ll_ActualizarContacto.Text = "Ver/Actualizar Contactos"
        '
        'Pn_Personas
        '
        Me.Pn_Personas.Controls.Add(Me.Cu_APB_Recibe)
        Me.Pn_Personas.Controls.Add(Me.Cu_BuscarPersonaRecibe)
        Me.Pn_Personas.Controls.Add(Me.Label4)
        Me.Pn_Personas.Controls.Add(Me.Cu_APB_Autoriza)
        Me.Pn_Personas.Controls.Add(Me.Cu_APB_Despacha)
        Me.Pn_Personas.Controls.Add(Me.Cu_BuscarPersonaDespacha)
        Me.Pn_Personas.Controls.Add(Me.Label10)
        Me.Pn_Personas.Controls.Add(Me.Label5)
        Me.Pn_Personas.Controls.Add(Me.Cu_BuscarPersonaAutoriza)
        Me.Pn_Personas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Personas.Location = New System.Drawing.Point(0, 432)
        Me.Pn_Personas.Name = "Pn_Personas"
        Me.Pn_Personas.Size = New System.Drawing.Size(922, 56)
        Me.Pn_Personas.TabIndex = 2
        '
        'Cu_APB_Recibe
        '
        Me.Cu_APB_Recibe.componenteasociado = "Cu_BuscarPersonaRecibe"
        Me.Cu_APB_Recibe.CrearUsuario = False
        Me.Cu_APB_Recibe.Location = New System.Drawing.Point(437, 30)
        Me.Cu_APB_Recibe.Name = "Cu_APB_Recibe"
        Me.Cu_APB_Recibe.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_Recibe.TabIndex = 8
        Me.Cu_APB_Recibe.Tag = "331"
        Me.Cu_APB_Recibe.TipoAsociacion = "BOD"
        Me.Cu_APB_Recibe.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaRecibe
        '
        Me.Cu_BuscarPersonaRecibe.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaRecibe.Location = New System.Drawing.Point(62, 30)
        Me.Cu_BuscarPersonaRecibe.Name = "Cu_BuscarPersonaRecibe"
        Me.Cu_BuscarPersonaRecibe.Size = New System.Drawing.Size(369, 23)
        Me.Cu_BuscarPersonaRecibe.TabIndex = 7
        Me.Cu_BuscarPersonaRecibe.Tipo = "PABO"
        Me.Cu_BuscarPersonaRecibe.valorcajatexto = "IDENTIFICACION"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Recibe:"
        '
        'Cu_APB_Autoriza
        '
        Me.Cu_APB_Autoriza.componenteasociado = "Cu_BuscarPersonaAutoriza"
        Me.Cu_APB_Autoriza.CrearUsuario = True
        Me.Cu_APB_Autoriza.Location = New System.Drawing.Point(890, 6)
        Me.Cu_APB_Autoriza.Name = "Cu_APB_Autoriza"
        Me.Cu_APB_Autoriza.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_Autoriza.TabIndex = 5
        Me.Cu_APB_Autoriza.Tag = "330"
        Me.Cu_APB_Autoriza.TipoAsociacion = "BOD"
        Me.Cu_APB_Autoriza.TipoBúsqueda = "P"
        '
        'Cu_APB_Despacha
        '
        Me.Cu_APB_Despacha.componenteasociado = "Cu_BuscarPersonaDespacha"
        Me.Cu_APB_Despacha.CrearUsuario = True
        Me.Cu_APB_Despacha.Location = New System.Drawing.Point(437, 6)
        Me.Cu_APB_Despacha.Name = "Cu_APB_Despacha"
        Me.Cu_APB_Despacha.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_Despacha.TabIndex = 2
        Me.Cu_APB_Despacha.Tag = "329"
        Me.Cu_APB_Despacha.TipoAsociacion = "BOD"
        Me.Cu_APB_Despacha.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaDespacha
        '
        Me.Cu_BuscarPersonaDespacha.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaDespacha.Location = New System.Drawing.Point(62, 6)
        Me.Cu_BuscarPersonaDespacha.Name = "Cu_BuscarPersonaDespacha"
        Me.Cu_BuscarPersonaDespacha.Size = New System.Drawing.Size(369, 23)
        Me.Cu_BuscarPersonaDespacha.TabIndex = 1
        Me.Cu_BuscarPersonaDespacha.Tipo = "PUABO"
        Me.Cu_BuscarPersonaDespacha.valorcajatexto = "IDENTIFICACION"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Despacha:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(476, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Autoriza:"
        '
        'Cu_BuscarPersonaAutoriza
        '
        Me.Cu_BuscarPersonaAutoriza.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAutoriza.Location = New System.Drawing.Point(524, 6)
        Me.Cu_BuscarPersonaAutoriza.Name = "Cu_BuscarPersonaAutoriza"
        Me.Cu_BuscarPersonaAutoriza.Size = New System.Drawing.Size(365, 23)
        Me.Cu_BuscarPersonaAutoriza.TabIndex = 4
        Me.Cu_BuscarPersonaAutoriza.Tipo = "PUABO"
        Me.Cu_BuscarPersonaAutoriza.valorcajatexto = "IDENTIFICACION"
        '
        'Pn_item
        '
        Me.Pn_item.Controls.Add(Me.Dgv_item)
        Me.Pn_item.Controls.Add(Me.Pn_TituloItemRequisición)
        Me.Pn_item.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_item.Location = New System.Drawing.Point(0, 209)
        Me.Pn_item.Name = "Pn_item"
        Me.Pn_item.Size = New System.Drawing.Size(922, 223)
        Me.Pn_item.TabIndex = 1
        '
        'Pn_TituloItemRequisición
        '
        Me.Pn_TituloItemRequisición.Controls.Add(Me.Label31)
        Me.Pn_TituloItemRequisición.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloItemRequisición.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloItemRequisición.Name = "Pn_TituloItemRequisición"
        Me.Pn_TituloItemRequisición.Size = New System.Drawing.Size(922, 24)
        Me.Pn_TituloItemRequisición.TabIndex = 0
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label31.Location = New System.Drawing.Point(0, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(922, 24)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "ITEM'S SALIDA DE ALMACEN"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Item"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Item"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Código"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Und"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Und"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 40
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Descripción"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 260
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Cant"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cant"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 50
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Existencia"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Exist"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Orden Compra"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Orden Compra"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Item OC"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Item OC"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 40
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Requisición"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Requisición"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Item RQ"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Item RQ"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 40
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "IDREQUISICION"
        Me.DataGridViewTextBoxColumn11.HeaderText = "IDREQUISICION"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "IDREMISION"
        Me.DataGridViewTextBoxColumn12.HeaderText = "IDREMISION"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "IDORDENCOMPRA"
        Me.DataGridViewTextBoxColumn13.HeaderText = "IDORDENCOMPRA"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "ValidarCant"
        Me.DataGridViewTextBoxColumn14.HeaderText = "ValidarCant"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'LISTAITEMSALIDAALMACENTableAdapter
        '
        'Me.LISTAITEMSALIDAALMACENTableAdapter.ClearBeforeFill = True
        '
        'Fr_SalidaAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 518)
        Me.Controls.Add(Me.Pn_item)
        Me.Controls.Add(Me.Pn_Personas)
        Me.Controls.Add(Me.Pn_Botones)
        Me.Controls.Add(Me.Pn_Encabezado)
        Me.Name = "Fr_SalidaAlmacen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Salida Almacén"
        Me.Pn_Encabezado.ResumeLayout(False)
        Me.Pn_Encabezado.PerformLayout()
        CType(Me.Dgv_item, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LISTAITEMSALIDAALMACENBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Ds_SalidaAlmacén, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Botones.ResumeLayout(False)
        Me.Pn_Botones.PerformLayout()
        Me.Pn_Personas.ResumeLayout(False)
        Me.Pn_Personas.PerformLayout()
        Me.Pn_item.ResumeLayout(False)
        Me.Pn_TituloItemRequisición.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoSalida As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tb_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Bt_CancelarSalida As System.Windows.Forms.Button
    Friend WithEvents Pn_Encabezado As System.Windows.Forms.Panel
    Friend WithEvents Dgv_item As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents Pn_Personas As System.Windows.Forms.Panel
    Friend WithEvents Cu_APB_Autoriza As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_APB_Despacha As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaDespacha As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaAutoriza As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Tx_Destino As System.Windows.Forms.TextBox
    Friend WithEvents Pn_item As System.Windows.Forms.Panel
    Friend WithEvents Pn_TituloItemRequisición As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaDespacho As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tx_RecibeTransportador As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Tx_Transportador As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Bt_Agregar As System.Windows.Forms.Button
    Friend WithEvents Cb_Relación As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Relación As System.Windows.Forms.Label
    Friend WithEvents Cu_APB_Recibe As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaRecibe As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cb_Actividad As System.Windows.Forms.ComboBox
    Friend WithEvents Bt_AgregarActividad As System.Windows.Forms.Button
    Friend WithEvents Bt_AsociarRq As System.Windows.Forms.Button
    Friend WithEvents Cb_AsociarRq As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_AsociarRq As System.Windows.Forms.Label
    Friend WithEvents Bt_AgregarOC As System.Windows.Forms.Button
    Friend WithEvents Cb_OrdenCompra As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LISTAITEMSALIDAALMACENBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_SalidaAlmacén As DatosSalidaAlmacén.Ds_SalidaAlmacén
    'Friend WithEvents LISTAITEMSALIDAALMACENTableAdapter As DatosSalidaAlmacén.Ds_SalidaAlmacénTableAdapters.LISTAITEMSALIDAALMACENTableAdapter
    Friend WithEvents Ll_ActualizarContacto As System.Windows.Forms.LinkLabel
    Public WithEvents Bt_GuardarSalida As System.Windows.Forms.Button
    Public WithEvents Bt_SeleccionarEquipos As System.Windows.Forms.Button
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
    Friend WithEvents Cbx_VerificacionEquipos As System.Windows.Forms.CheckBox
    Friend WithEvents ItemDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CódigoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UndDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripciónDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Existencia As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdenCompraDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemOCDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequisiciónDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemRQDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDREQUISICIONDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDREMISIONDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDORDENCOMPRADataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValidarCant As Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
    Friend WithEvents Cu_AsociarActivoFijo1 As FormulariosClasesBase.Cu_AsociarActivoFijo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Bt_BuscarPlaca As System.Windows.Forms.Button
    Friend WithEvents Tx_PlacaVehiculo As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Guía As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Bt_GestionarActividades As System.Windows.Forms.Button
    Friend WithEvents Lb_TipoEnvio As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarOT As FormulariosClasesBase.Cu_Asociar
    Friend WithEvents Tx_lectora As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
