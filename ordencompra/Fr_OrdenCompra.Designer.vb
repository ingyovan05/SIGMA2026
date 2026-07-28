<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_OrdenCompra
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
        Dim CODIGOCONDICIONPAGOLabel As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Tx_FaxProveedor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tx_TelefonoProveedor = New System.Windows.Forms.TextBox()
        Me.Tx_DirecciónProveedor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tx_Identificación = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tx_Encabezado = New System.Windows.Forms.TextBox()
        Me.Tx_Observación = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Pn_Encabezado = New System.Windows.Forms.Panel()
        Me.Bt_PersonalizarCondicionPago = New System.Windows.Forms.Button()
        Me.Tx_TRM = New System.Windows.Forms.TextBox()
        Me.Ck_ValorIncluyeArancel = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Tx_CondiciónPago = New System.Windows.Forms.TextBox()
        Me.Tx_DespacharA = New System.Windows.Forms.TextBox()
        Me.Cms_Direcciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Cb_TipoOrdenCompra = New System.Windows.Forms.ComboBox()
        Me.Dtp_FechaDespacho = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cb_TipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Tx_Cotización = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Gb_Proveedor = New System.Windows.Forms.GroupBox()
        Me.Tx_CorreoNotificacion = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Tx_PersonaContacto = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Tx_DireccionNotificacion = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Cu_CiudadDirección = New FormulariosClasesBase.Cu_Ciudad()
        Me.Bt_BuscarProveedor = New System.Windows.Forms.Button()
        Me.Tx_CelularProveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Tx_NombreProveedor = New System.Windows.Forms.TextBox()
        Me.Tx_DigVerificación = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cms_CondiciónPago = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Lb_Requisición = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Cb_TipoDescuento = New System.Windows.Forms.ComboBox()
        Me.Tx_ValorDescuento = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Pn_Item = New System.Windows.Forms.Panel()
        Me.Dgv_Item = New System.Windows.Forms.DataGridView()
        Me.IDITEMORDENCOMPRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDITEMREQUISICIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDARTICULODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PORCENTAJEIVADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.CANTIDADPENDIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALORUNITARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPODESCUENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.VALORDESCUENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALORTOTALITEMDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDORDENCOMPRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDREQUISICIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LISTAITEMREQUISICIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_OrdenCompra = New DatosOrdenCompra.Ds_OrdenCompra()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Ll_ActualizarContacto = New System.Windows.Forms.LinkLabel()
        Me.Lb_TotalOC = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Pn_Personas = New System.Windows.Forms.Panel()
        Me.Bt_Aplicar = New System.Windows.Forms.Button()
        Me.Cu_ApbGerencia = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_ApbRevisa = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_ApbAprueba = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_ApbAutoriza = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaGerencia = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaRevisa = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaAutoriza = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaAprueba = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.LISTAITEMREQUISICIONTableAdapter = New DatosOrdenCompra.Ds_OrdenCompraTableAdapters.LISTAITEMREQUISICIONTableAdapter()
        Me.ToolTipOrdenCompra = New System.Windows.Forms.ToolTip(Me.components)
        CODIGOCONDICIONPAGOLabel = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Me.Pn_Encabezado.SuspendLayout()
        Me.Gb_Proveedor.SuspendLayout()
        Me.Pn_Item.SuspendLayout()
        CType(Me.Dgv_Item, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LISTAITEMREQUISICIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_OrdenCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Botones.SuspendLayout()
        Me.Pn_Personas.SuspendLayout()
        Me.SuspendLayout()
        '
        'CODIGOCONDICIONPAGOLabel
        '
        CODIGOCONDICIONPAGOLabel.AutoSize = True
        CODIGOCONDICIONPAGOLabel.Location = New System.Drawing.Point(238, 167)
        CODIGOCONDICIONPAGOLabel.Name = "CODIGOCONDICIONPAGOLabel"
        CODIGOCONDICIONPAGOLabel.Size = New System.Drawing.Size(85, 13)
        CODIGOCONDICIONPAGOLabel.TabIndex = 10
        CODIGOCONDICIONPAGOLabel.Text = "Condición Pago:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(32, 167)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(73, 13)
        Label11.TabIndex = 8
        Label11.Text = "Tipo Moneda:"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(3, 141)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(102, 13)
        Label15.TabIndex = 1
        Label15.Text = "Tipo Orden Compra:"
        '
        'Tx_FaxProveedor
        '
        Me.Tx_FaxProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_FaxProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_FaxProveedor.Location = New System.Drawing.Point(563, 59)
        Me.Tx_FaxProveedor.MaxLength = 10
        Me.Tx_FaxProveedor.Name = "Tx_FaxProveedor"
        Me.Tx_FaxProveedor.Size = New System.Drawing.Size(82, 20)
        Me.Tx_FaxProveedor.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(533, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Fax:"
        '
        'Tx_TelefonoProveedor
        '
        Me.Tx_TelefonoProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_TelefonoProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_TelefonoProveedor.Location = New System.Drawing.Point(439, 59)
        Me.Tx_TelefonoProveedor.MaxLength = 10
        Me.Tx_TelefonoProveedor.Name = "Tx_TelefonoProveedor"
        Me.Tx_TelefonoProveedor.Size = New System.Drawing.Size(85, 20)
        Me.Tx_TelefonoProveedor.TabIndex = 11
        '
        'Tx_DirecciónProveedor
        '
        Me.Tx_DirecciónProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_DirecciónProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_DirecciónProveedor.Location = New System.Drawing.Point(102, 36)
        Me.Tx_DirecciónProveedor.MaxLength = 100
        Me.Tx_DirecciónProveedor.Name = "Tx_DirecciónProveedor"
        Me.Tx_DirecciónProveedor.Size = New System.Drawing.Size(681, 20)
        Me.Tx_DirecciónProveedor.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(44, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Dirección:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(384, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Teléfono:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ciudad:"
        '
        'Tx_Identificación
        '
        Me.Tx_Identificación.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_Identificación.Location = New System.Drawing.Point(102, 14)
        Me.Tx_Identificación.MaxLength = 15
        Me.Tx_Identificación.Name = "Tx_Identificación"
        Me.Tx_Identificación.Size = New System.Drawing.Size(95, 20)
        Me.Tx_Identificación.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Identificación:"
        '
        'Tx_Encabezado
        '
        Me.Tx_Encabezado.Location = New System.Drawing.Point(15, 254)
        Me.Tx_Encabezado.MaxLength = 300
        Me.Tx_Encabezado.Multiline = True
        Me.Tx_Encabezado.Name = "Tx_Encabezado"
        Me.Tx_Encabezado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tx_Encabezado.Size = New System.Drawing.Size(380, 63)
        Me.Tx_Encabezado.TabIndex = 19
        '
        'Tx_Observación
        '
        Me.Tx_Observación.Location = New System.Drawing.Point(408, 254)
        Me.Tx_Observación.MaxLength = 200
        Me.Tx_Observación.Multiline = True
        Me.Tx_Observación.Name = "Tx_Observación"
        Me.Tx_Observación.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tx_Observación.Size = New System.Drawing.Size(380, 63)
        Me.Tx_Observación.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 238)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Encabezado:"
        '
        'Pn_Encabezado
        '
        Me.Pn_Encabezado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Pn_Encabezado.Controls.Add(Me.Bt_PersonalizarCondicionPago)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_TRM)
        Me.Pn_Encabezado.Controls.Add(Me.Ck_ValorIncluyeArancel)
        Me.Pn_Encabezado.Controls.Add(Me.Label12)
        Me.Pn_Encabezado.Controls.Add(Me.Cu_CentroCosto1)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_CondiciónPago)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_DespacharA)
        Me.Pn_Encabezado.Controls.Add(Me.Label22)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_TipoOrdenCompra)
        Me.Pn_Encabezado.Controls.Add(Label15)
        Me.Pn_Encabezado.Controls.Add(Me.Dtp_FechaDespacho)
        Me.Pn_Encabezado.Controls.Add(Me.Label14)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_TipoMoneda)
        Me.Pn_Encabezado.Controls.Add(Label11)
        Me.Pn_Encabezado.Controls.Add(CODIGOCONDICIONPAGOLabel)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_Cotización)
        Me.Pn_Encabezado.Controls.Add(Me.Label10)
        Me.Pn_Encabezado.Controls.Add(Me.Label9)
        Me.Pn_Encabezado.Controls.Add(Me.Gb_Proveedor)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_Observación)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_Encabezado)
        Me.Pn_Encabezado.Controls.Add(Me.Label2)
        Me.Pn_Encabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Encabezado.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Encabezado.Name = "Pn_Encabezado"
        Me.Pn_Encabezado.Size = New System.Drawing.Size(804, 324)
        Me.Pn_Encabezado.TabIndex = 0
        '
        'Bt_PersonalizarCondicionPago
        '
        Me.Bt_PersonalizarCondicionPago.Location = New System.Drawing.Point(537, 163)
        Me.Bt_PersonalizarCondicionPago.Name = "Bt_PersonalizarCondicionPago"
        Me.Bt_PersonalizarCondicionPago.Size = New System.Drawing.Size(28, 23)
        Me.Bt_PersonalizarCondicionPago.TabIndex = 12
        Me.Bt_PersonalizarCondicionPago.Text = "..."
        Me.Bt_PersonalizarCondicionPago.UseVisualStyleBackColor = True
        '
        'Tx_TRM
        '
        Me.Tx_TRM.Location = New System.Drawing.Point(108, 189)
        Me.Tx_TRM.MaxLength = 10
        Me.Tx_TRM.Name = "Tx_TRM"
        Me.Tx_TRM.Size = New System.Drawing.Size(60, 20)
        Me.Tx_TRM.TabIndex = 14
        Me.Tx_TRM.Text = "1"
        '
        'Ck_ValorIncluyeArancel
        '
        Me.Ck_ValorIncluyeArancel.AutoSize = True
        Me.Ck_ValorIncluyeArancel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_ValorIncluyeArancel.Checked = True
        Me.Ck_ValorIncluyeArancel.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_ValorIncluyeArancel.Enabled = False
        Me.Ck_ValorIncluyeArancel.Location = New System.Drawing.Point(173, 191)
        Me.Ck_ValorIncluyeArancel.Name = "Ck_ValorIncluyeArancel"
        Me.Ck_ValorIncluyeArancel.Size = New System.Drawing.Size(185, 17)
        Me.Ck_ValorIncluyeArancel.TabIndex = 15
        Me.Ck_ValorIncluyeArancel.Text = "Valores Incluyen Nacionalización:"
        Me.Ck_ValorIncluyeArancel.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Enabled = False
        Me.Label12.Location = New System.Drawing.Point(62, 192)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "T.R.M.:"
        Me.ToolTipOrdenCompra.SetToolTip(Me.Label12, "Tasa Representativa del Mercado")
        '
        'Cu_CentroCosto1
        '
        Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto1.Location = New System.Drawing.Point(573, 138)
        Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
        Me.Cu_CentroCosto1.Size = New System.Drawing.Size(216, 38)
        Me.Cu_CentroCosto1.TabIndex = 7
        '
        'Tx_CondiciónPago
        '
        Me.Tx_CondiciónPago.Location = New System.Drawing.Point(326, 164)
        Me.Tx_CondiciónPago.MaxLength = 100
        Me.Tx_CondiciónPago.Name = "Tx_CondiciónPago"
        Me.Tx_CondiciónPago.ReadOnly = True
        Me.Tx_CondiciónPago.Size = New System.Drawing.Size(206, 20)
        Me.Tx_CondiciónPago.TabIndex = 11
        Me.Tx_CondiciónPago.Tag = "10"
        '
        'Tx_DespacharA
        '
        Me.Tx_DespacharA.ContextMenuStrip = Me.Cms_Direcciones
        Me.Tx_DespacharA.Location = New System.Drawing.Point(108, 213)
        Me.Tx_DespacharA.MaxLength = 200
        Me.Tx_DespacharA.Name = "Tx_DespacharA"
        Me.Tx_DespacharA.Size = New System.Drawing.Size(681, 20)
        Me.Tx_DespacharA.TabIndex = 17
        '
        'Cms_Direcciones
        '
        Me.Cms_Direcciones.Name = "Cms_Direcciones"
        Me.Cms_Direcciones.Size = New System.Drawing.Size(61, 4)
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(34, 216)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 13)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "Despachar A:"
        '
        'Cb_TipoOrdenCompra
        '
        Me.Cb_TipoOrdenCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoOrdenCompra.FormattingEnabled = True
        Me.Cb_TipoOrdenCompra.Location = New System.Drawing.Point(108, 138)
        Me.Cb_TipoOrdenCompra.Name = "Cb_TipoOrdenCompra"
        Me.Cb_TipoOrdenCompra.Size = New System.Drawing.Size(126, 21)
        Me.Cb_TipoOrdenCompra.TabIndex = 2
        '
        'Dtp_FechaDespacho
        '
        Me.Dtp_FechaDespacho.Checked = False
        Me.Dtp_FechaDespacho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaDespacho.Location = New System.Drawing.Point(463, 138)
        Me.Dtp_FechaDespacho.Name = "Dtp_FechaDespacho"
        Me.Dtp_FechaDespacho.ShowCheckBox = True
        Me.Dtp_FechaDespacho.Size = New System.Drawing.Size(101, 20)
        Me.Dtp_FechaDespacho.TabIndex = 6
        Me.Dtp_FechaDespacho.Tag = "11"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(380, 141)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Fecha Entrega:"
        '
        'Cb_TipoMoneda
        '
        Me.Cb_TipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoMoneda.FormattingEnabled = True
        Me.Cb_TipoMoneda.Location = New System.Drawing.Point(108, 164)
        Me.Cb_TipoMoneda.Name = "Cb_TipoMoneda"
        Me.Cb_TipoMoneda.Size = New System.Drawing.Size(126, 21)
        Me.Cb_TipoMoneda.TabIndex = 9
        Me.Cb_TipoMoneda.Tag = ""
        '
        'Tx_Cotización
        '
        Me.Tx_Cotización.Location = New System.Drawing.Point(300, 138)
        Me.Tx_Cotización.MaxLength = 20
        Me.Tx_Cotización.Name = "Tx_Cotización"
        Me.Tx_Cotización.Size = New System.Drawing.Size(74, 20)
        Me.Tx_Cotización.TabIndex = 4
        Me.Tx_Cotización.Tag = "10"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(238, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Cotización:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(411, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Observación:"
        '
        'Gb_Proveedor
        '
        Me.Gb_Proveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Gb_Proveedor.Controls.Add(Me.Tx_CorreoNotificacion)
        Me.Gb_Proveedor.Controls.Add(Me.Label13)
        Me.Gb_Proveedor.Controls.Add(Me.Tx_PersonaContacto)
        Me.Gb_Proveedor.Controls.Add(Me.Label23)
        Me.Gb_Proveedor.Controls.Add(Me.Tx_DireccionNotificacion)
        Me.Gb_Proveedor.Controls.Add(Me.Label24)
        Me.Gb_Proveedor.Controls.Add(Me.Cu_CiudadDirección)
        Me.Gb_Proveedor.Controls.Add(Me.Bt_BuscarProveedor)
        Me.Gb_Proveedor.Controls.Add(Me.Tx_CelularProveedor)
        Me.Gb_Proveedor.Controls.Add(Me.Label8)
        Me.Gb_Proveedor.Controls.Add(Me.Tx_NombreProveedor)
        Me.Gb_Proveedor.Controls.Add(Me.Tx_DigVerificación)
        Me.Gb_Proveedor.Controls.Add(Me.Label1)
        Me.Gb_Proveedor.Controls.Add(Me.Label3)
        Me.Gb_Proveedor.Controls.Add(Me.Tx_FaxProveedor)
        Me.Gb_Proveedor.Controls.Add(Me.Label4)
        Me.Gb_Proveedor.Controls.Add(Me.Tx_DirecciónProveedor)
        Me.Gb_Proveedor.Controls.Add(Me.Label6)
        Me.Gb_Proveedor.Controls.Add(Me.Label7)
        Me.Gb_Proveedor.Controls.Add(Me.Tx_Identificación)
        Me.Gb_Proveedor.Controls.Add(Me.Tx_TelefonoProveedor)
        Me.Gb_Proveedor.Controls.Add(Me.Label5)
        Me.Gb_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gb_Proveedor.Location = New System.Drawing.Point(6, 3)
        Me.Gb_Proveedor.Name = "Gb_Proveedor"
        Me.Gb_Proveedor.Size = New System.Drawing.Size(792, 130)
        Me.Gb_Proveedor.TabIndex = 0
        Me.Gb_Proveedor.TabStop = False
        Me.Gb_Proveedor.Text = "Proveedor"
        '
        'Tx_CorreoNotificacion
        '
        Me.Tx_CorreoNotificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_CorreoNotificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_CorreoNotificacion.Location = New System.Drawing.Point(102, 105)
        Me.Tx_CorreoNotificacion.MaxLength = 60
        Me.Tx_CorreoNotificacion.Name = "Tx_CorreoNotificacion"
        Me.Tx_CorreoNotificacion.Size = New System.Drawing.Size(228, 20)
        Me.Tx_CorreoNotificacion.TabIndex = 19
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(341, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Persona Contacto:"
        '
        'Tx_PersonaContacto
        '
        Me.Tx_PersonaContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_PersonaContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_PersonaContacto.Location = New System.Drawing.Point(439, 105)
        Me.Tx_PersonaContacto.MaxLength = 100
        Me.Tx_PersonaContacto.Name = "Tx_PersonaContacto"
        Me.Tx_PersonaContacto.Size = New System.Drawing.Size(344, 20)
        Me.Tx_PersonaContacto.TabIndex = 21
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(16, 108)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 13)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "Correo Notifica.:"
        Me.ToolTipOrdenCompra.SetToolTip(Me.Label23, "Correo electrónico de notificación")
        '
        'Tx_DireccionNotificacion
        '
        Me.Tx_DireccionNotificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_DireccionNotificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_DireccionNotificacion.Location = New System.Drawing.Point(102, 82)
        Me.Tx_DireccionNotificacion.MaxLength = 100
        Me.Tx_DireccionNotificacion.Name = "Tx_DireccionNotificacion"
        Me.Tx_DireccionNotificacion.Size = New System.Drawing.Size(681, 20)
        Me.Tx_DireccionNotificacion.TabIndex = 17
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(2, 85)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(97, 13)
        Me.Label24.TabIndex = 16
        Me.Label24.Text = "Dirección Notifica.:"
        Me.ToolTipOrdenCompra.SetToolTip(Me.Label24, "Dirección de notificación")
        '
        'Cu_CiudadDirección
        '
        Me.Cu_CiudadDirección.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cu_CiudadDirección.Location = New System.Drawing.Point(100, 58)
        Me.Cu_CiudadDirección.Name = "Cu_CiudadDirección"
        Me.Cu_CiudadDirección.Size = New System.Drawing.Size(265, 23)
        Me.Cu_CiudadDirección.TabIndex = 9
        '
        'Bt_BuscarProveedor
        '
        Me.Bt_BuscarProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_BuscarProveedor.Location = New System.Drawing.Point(203, 13)
        Me.Bt_BuscarProveedor.Name = "Bt_BuscarProveedor"
        Me.Bt_BuscarProveedor.Size = New System.Drawing.Size(28, 23)
        Me.Bt_BuscarProveedor.TabIndex = 2
        Me.Bt_BuscarProveedor.Text = "..."
        Me.Bt_BuscarProveedor.UseVisualStyleBackColor = True
        '
        'Tx_CelularProveedor
        '
        Me.Tx_CelularProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_CelularProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_CelularProveedor.Location = New System.Drawing.Point(699, 59)
        Me.Tx_CelularProveedor.MaxLength = 10
        Me.Tx_CelularProveedor.Name = "Tx_CelularProveedor"
        Me.Tx_CelularProveedor.Size = New System.Drawing.Size(84, 20)
        Me.Tx_CelularProveedor.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(654, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Celular:"
        '
        'Tx_NombreProveedor
        '
        Me.Tx_NombreProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_NombreProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_NombreProveedor.Location = New System.Drawing.Point(318, 14)
        Me.Tx_NombreProveedor.MaxLength = 150
        Me.Tx_NombreProveedor.Name = "Tx_NombreProveedor"
        Me.Tx_NombreProveedor.ReadOnly = True
        Me.Tx_NombreProveedor.Size = New System.Drawing.Size(465, 20)
        Me.Tx_NombreProveedor.TabIndex = 5
        '
        'Tx_DigVerificación
        '
        Me.Tx_DigVerificación.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_DigVerificación.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_DigVerificación.Location = New System.Drawing.Point(285, 14)
        Me.Tx_DigVerificación.MaxLength = 1
        Me.Tx_DigVerificación.Name = "Tx_DigVerificación"
        Me.Tx_DigVerificación.ReadOnly = True
        Me.Tx_DigVerificación.Size = New System.Drawing.Size(27, 20)
        Me.Tx_DigVerificación.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(237, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Dig Ver:"
        '
        'Cms_CondiciónPago
        '
        Me.Cms_CondiciónPago.Name = "Cms_CondiciónPago"
        Me.Cms_CondiciónPago.Size = New System.Drawing.Size(61, 4)
        '
        'Lb_Requisición
        '
        Me.Lb_Requisición.AutoSize = True
        Me.Lb_Requisición.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Requisición.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Lb_Requisición.Location = New System.Drawing.Point(437, 8)
        Me.Lb_Requisición.Name = "Lb_Requisición"
        Me.Lb_Requisición.Size = New System.Drawing.Size(44, 12)
        Me.Lb_Requisición.TabIndex = 5
        Me.Lb_Requisición.Text = "Label13"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(256, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 13)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Valor:"
        '
        'Cb_TipoDescuento
        '
        Me.Cb_TipoDescuento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoDescuento.FormattingEnabled = True
        Me.Cb_TipoDescuento.Items.AddRange(New Object() {"No tiene", "Valor Total", "Porcentaje"})
        Me.Cb_TipoDescuento.Location = New System.Drawing.Point(144, 5)
        Me.Cb_TipoDescuento.Name = "Cb_TipoDescuento"
        Me.Cb_TipoDescuento.Size = New System.Drawing.Size(106, 21)
        Me.Cb_TipoDescuento.TabIndex = 1
        '
        'Tx_ValorDescuento
        '
        Me.Tx_ValorDescuento.Location = New System.Drawing.Point(293, 5)
        Me.Tx_ValorDescuento.MaxLength = 18
        Me.Tx_ValorDescuento.Name = "Tx_ValorDescuento"
        Me.Tx_ValorDescuento.Size = New System.Drawing.Size(70, 20)
        Me.Tx_ValorDescuento.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(133, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Descuento pie de Factura:"
        '
        'Pn_Item
        '
        Me.Pn_Item.Controls.Add(Me.Dgv_Item)
        Me.Pn_Item.Controls.Add(Me.Label31)
        Me.Pn_Item.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Item.Location = New System.Drawing.Point(0, 324)
        Me.Pn_Item.Name = "Pn_Item"
        Me.Pn_Item.Size = New System.Drawing.Size(804, 300)
        Me.Pn_Item.TabIndex = 1
        '
        'Dgv_Item
        '
        Me.Dgv_Item.AllowUserToAddRows = False
        Me.Dgv_Item.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_Item.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Item.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDITEMORDENCOMPRADataGridViewTextBoxColumn, Me.IDITEMREQUISICIONDataGridViewTextBoxColumn, Me.IDARTICULODataGridViewTextBoxColumn, Me.DESCRIPCIONDataGridViewTextBoxColumn, Me.UNIDADDataGridViewTextBoxColumn, Me.PORCENTAJEIVADataGridViewTextBoxColumn, Me.CANTIDADPENDIENTEDataGridViewTextBoxColumn, Me.CANTIDADDataGridViewTextBoxColumn, Me.VALORUNITARIODataGridViewTextBoxColumn, Me.TIPODESCUENTODataGridViewTextBoxColumn, Me.VALORDESCUENTODataGridViewTextBoxColumn, Me.VALORTOTALITEMDataGridViewTextBoxColumn, Me.IDORDENCOMPRADataGridViewTextBoxColumn, Me.IDREQUISICIONDataGridViewTextBoxColumn})
        Me.Dgv_Item.DataSource = Me.LISTAITEMREQUISICIONBindingSource
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv_Item.DefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_Item.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Item.Location = New System.Drawing.Point(0, 20)
        Me.Dgv_Item.Name = "Dgv_Item"
        Me.Dgv_Item.Size = New System.Drawing.Size(804, 280)
        Me.Dgv_Item.TabIndex = 1
        '
        'IDITEMORDENCOMPRADataGridViewTextBoxColumn
        '
        Me.IDITEMORDENCOMPRADataGridViewTextBoxColumn.DataPropertyName = "IDITEMORDENCOMPRA"
        Me.IDITEMORDENCOMPRADataGridViewTextBoxColumn.HeaderText = "Item"
        Me.IDITEMORDENCOMPRADataGridViewTextBoxColumn.Name = "IDITEMORDENCOMPRADataGridViewTextBoxColumn"
        Me.IDITEMORDENCOMPRADataGridViewTextBoxColumn.ReadOnly = True
        Me.IDITEMORDENCOMPRADataGridViewTextBoxColumn.Width = 36
        '
        'IDITEMREQUISICIONDataGridViewTextBoxColumn
        '
        Me.IDITEMREQUISICIONDataGridViewTextBoxColumn.DataPropertyName = "IDITEMREQUISICION"
        Me.IDITEMREQUISICIONDataGridViewTextBoxColumn.HeaderText = "Item RQ"
        Me.IDITEMREQUISICIONDataGridViewTextBoxColumn.Name = "IDITEMREQUISICIONDataGridViewTextBoxColumn"
        Me.IDITEMREQUISICIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDITEMREQUISICIONDataGridViewTextBoxColumn.Width = 36
        '
        'IDARTICULODataGridViewTextBoxColumn
        '
        Me.IDARTICULODataGridViewTextBoxColumn.DataPropertyName = "IDARTICULO"
        Me.IDARTICULODataGridViewTextBoxColumn.HeaderText = "Código"
        Me.IDARTICULODataGridViewTextBoxColumn.Name = "IDARTICULODataGridViewTextBoxColumn"
        Me.IDARTICULODataGridViewTextBoxColumn.Width = 48
        '
        'DESCRIPCIONDataGridViewTextBoxColumn
        '
        Me.DESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "Descripción"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.Name = "DESCRIPCIONDataGridViewTextBoxColumn"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESCRIPCIONDataGridViewTextBoxColumn.Width = 130
        '
        'UNIDADDataGridViewTextBoxColumn
        '
        Me.UNIDADDataGridViewTextBoxColumn.DataPropertyName = "UNIDAD"
        Me.UNIDADDataGridViewTextBoxColumn.HeaderText = "Und"
        Me.UNIDADDataGridViewTextBoxColumn.Name = "UNIDADDataGridViewTextBoxColumn"
        Me.UNIDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.UNIDADDataGridViewTextBoxColumn.Width = 40
        '
        'PORCENTAJEIVADataGridViewTextBoxColumn
        '
        Me.PORCENTAJEIVADataGridViewTextBoxColumn.DataPropertyName = "PORCENTAJEIVA"
        Me.PORCENTAJEIVADataGridViewTextBoxColumn.HeaderText = "IVA"
        Me.PORCENTAJEIVADataGridViewTextBoxColumn.Items.AddRange(New Object() {"0", "5", "16", "19"})
        Me.PORCENTAJEIVADataGridViewTextBoxColumn.Name = "PORCENTAJEIVADataGridViewTextBoxColumn"
        Me.PORCENTAJEIVADataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PORCENTAJEIVADataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PORCENTAJEIVADataGridViewTextBoxColumn.Width = 44
        '
        'CANTIDADPENDIENTEDataGridViewTextBoxColumn
        '
        Me.CANTIDADPENDIENTEDataGridViewTextBoxColumn.DataPropertyName = "CANTIDADPENDIENTE"
        Me.CANTIDADPENDIENTEDataGridViewTextBoxColumn.HeaderText = "Cant Pend"
        Me.CANTIDADPENDIENTEDataGridViewTextBoxColumn.Name = "CANTIDADPENDIENTEDataGridViewTextBoxColumn"
        Me.CANTIDADPENDIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CANTIDADPENDIENTEDataGridViewTextBoxColumn.Width = 46
        '
        'CANTIDADDataGridViewTextBoxColumn
        '
        Me.CANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.HeaderText = "Cant Comprar"
        Me.CANTIDADDataGridViewTextBoxColumn.Name = "CANTIDADDataGridViewTextBoxColumn"
        Me.CANTIDADDataGridViewTextBoxColumn.Width = 52
        '
        'VALORUNITARIODataGridViewTextBoxColumn
        '
        Me.VALORUNITARIODataGridViewTextBoxColumn.DataPropertyName = "VALORUNITARIO"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.VALORUNITARIODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.VALORUNITARIODataGridViewTextBoxColumn.HeaderText = "Valor Unitario"
        Me.VALORUNITARIODataGridViewTextBoxColumn.Name = "VALORUNITARIODataGridViewTextBoxColumn"
        Me.VALORUNITARIODataGridViewTextBoxColumn.Width = 86
        '
        'TIPODESCUENTODataGridViewTextBoxColumn
        '
        Me.TIPODESCUENTODataGridViewTextBoxColumn.DataPropertyName = "TIPODESCUENTO"
        Me.TIPODESCUENTODataGridViewTextBoxColumn.HeaderText = "Tipo Desc"
        Me.TIPODESCUENTODataGridViewTextBoxColumn.Items.AddRange(New Object() {"No tiene", "Valor Total", "Porcentaje", "Por Unidad"})
        Me.TIPODESCUENTODataGridViewTextBoxColumn.Name = "TIPODESCUENTODataGridViewTextBoxColumn"
        Me.TIPODESCUENTODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TIPODESCUENTODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TIPODESCUENTODataGridViewTextBoxColumn.Width = 80
        '
        'VALORDESCUENTODataGridViewTextBoxColumn
        '
        Me.VALORDESCUENTODataGridViewTextBoxColumn.DataPropertyName = "VALORDESCUENTO"
        Me.VALORDESCUENTODataGridViewTextBoxColumn.HeaderText = "Valor Desc"
        Me.VALORDESCUENTODataGridViewTextBoxColumn.Name = "VALORDESCUENTODataGridViewTextBoxColumn"
        Me.VALORDESCUENTODataGridViewTextBoxColumn.Width = 70
        '
        'VALORTOTALITEMDataGridViewTextBoxColumn
        '
        Me.VALORTOTALITEMDataGridViewTextBoxColumn.DataPropertyName = "VALORTOTALITEM"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.VALORTOTALITEMDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.VALORTOTALITEMDataGridViewTextBoxColumn.HeaderText = "Valor Total Item"
        Me.VALORTOTALITEMDataGridViewTextBoxColumn.Name = "VALORTOTALITEMDataGridViewTextBoxColumn"
        Me.VALORTOTALITEMDataGridViewTextBoxColumn.ReadOnly = True
        Me.VALORTOTALITEMDataGridViewTextBoxColumn.Width = 90
        '
        'IDORDENCOMPRADataGridViewTextBoxColumn
        '
        Me.IDORDENCOMPRADataGridViewTextBoxColumn.DataPropertyName = "IDORDENCOMPRA"
        Me.IDORDENCOMPRADataGridViewTextBoxColumn.HeaderText = "IDORDENCOMPRA"
        Me.IDORDENCOMPRADataGridViewTextBoxColumn.Name = "IDORDENCOMPRADataGridViewTextBoxColumn"
        Me.IDORDENCOMPRADataGridViewTextBoxColumn.Visible = False
        '
        'IDREQUISICIONDataGridViewTextBoxColumn
        '
        Me.IDREQUISICIONDataGridViewTextBoxColumn.DataPropertyName = "IDREQUISICION"
        Me.IDREQUISICIONDataGridViewTextBoxColumn.HeaderText = "IDREQUISICION"
        Me.IDREQUISICIONDataGridViewTextBoxColumn.Name = "IDREQUISICIONDataGridViewTextBoxColumn"
        Me.IDREQUISICIONDataGridViewTextBoxColumn.Visible = False
        '
        'LISTAITEMREQUISICIONBindingSource
        '
        Me.LISTAITEMREQUISICIONBindingSource.DataMember = "LISTAITEMREQUISICION"
        Me.LISTAITEMREQUISICIONBindingSource.DataSource = Me.Ds_OrdenCompra
        '
        'Ds_OrdenCompra
        '
        Me.Ds_OrdenCompra.DataSetName = "Ds_OrdenCompra"
        Me.Ds_OrdenCompra.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label31.Location = New System.Drawing.Point(0, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(804, 20)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "ITEM'S DE LA ORDEN DE COMPRA"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.Color.Silver
        Me.Pn_Botones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Botones.Controls.Add(Me.Ll_ActualizarContacto)
        Me.Pn_Botones.Controls.Add(Me.Lb_TotalOC)
        Me.Pn_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Pn_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 711)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(804, 30)
        Me.Pn_Botones.TabIndex = 3
        '
        'Ll_ActualizarContacto
        '
        Me.Ll_ActualizarContacto.AutoSize = True
        Me.Ll_ActualizarContacto.Location = New System.Drawing.Point(509, 9)
        Me.Ll_ActualizarContacto.Name = "Ll_ActualizarContacto"
        Me.Ll_ActualizarContacto.Size = New System.Drawing.Size(125, 13)
        Me.Ll_ActualizarContacto.TabIndex = 1
        Me.Ll_ActualizarContacto.TabStop = True
        Me.Ll_ActualizarContacto.Text = "Ver/Actualizar Contactos"
        '
        'Lb_TotalOC
        '
        Me.Lb_TotalOC.AutoSize = True
        Me.Lb_TotalOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TotalOC.ForeColor = System.Drawing.Color.Red
        Me.Lb_TotalOC.Location = New System.Drawing.Point(11, 8)
        Me.Lb_TotalOC.Name = "Lb_TotalOC"
        Me.Lb_TotalOC.Size = New System.Drawing.Size(52, 13)
        Me.Lb_TotalOC.TabIndex = 0
        Me.Lb_TotalOC.Text = "Label13"
        Me.Lb_TotalOC.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(640, 4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 2
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(721, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 3
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Revisa:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(2, 62)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Aprueba:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(404, 35)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 13)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Autoriza:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(399, 62)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 13)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "Gerencia:"
        '
        'Pn_Personas
        '
        Me.Pn_Personas.Controls.Add(Me.Bt_Aplicar)
        Me.Pn_Personas.Controls.Add(Me.Lb_Requisición)
        Me.Pn_Personas.Controls.Add(Me.Cu_ApbGerencia)
        Me.Pn_Personas.Controls.Add(Me.Cu_ApbRevisa)
        Me.Pn_Personas.Controls.Add(Me.Cu_ApbAprueba)
        Me.Pn_Personas.Controls.Add(Me.Label21)
        Me.Pn_Personas.Controls.Add(Me.Cu_ApbAutoriza)
        Me.Pn_Personas.Controls.Add(Me.Cb_TipoDescuento)
        Me.Pn_Personas.Controls.Add(Me.Tx_ValorDescuento)
        Me.Pn_Personas.Controls.Add(Me.Label19)
        Me.Pn_Personas.Controls.Add(Me.Label20)
        Me.Pn_Personas.Controls.Add(Me.Label16)
        Me.Pn_Personas.Controls.Add(Me.Cu_BuscarPersonaGerencia)
        Me.Pn_Personas.Controls.Add(Me.Cu_BuscarPersonaRevisa)
        Me.Pn_Personas.Controls.Add(Me.Cu_BuscarPersonaAutoriza)
        Me.Pn_Personas.Controls.Add(Me.Label17)
        Me.Pn_Personas.Controls.Add(Me.Cu_BuscarPersonaAprueba)
        Me.Pn_Personas.Controls.Add(Me.Label18)
        Me.Pn_Personas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Personas.Location = New System.Drawing.Point(0, 624)
        Me.Pn_Personas.Name = "Pn_Personas"
        Me.Pn_Personas.Size = New System.Drawing.Size(804, 87)
        Me.Pn_Personas.TabIndex = 2
        '
        'Bt_Aplicar
        '
        Me.Bt_Aplicar.Location = New System.Drawing.Point(366, 3)
        Me.Bt_Aplicar.Name = "Bt_Aplicar"
        Me.Bt_Aplicar.Size = New System.Drawing.Size(60, 23)
        Me.Bt_Aplicar.TabIndex = 4
        Me.Bt_Aplicar.Text = "Aplicar"
        Me.Bt_Aplicar.UseVisualStyleBackColor = True
        '
        'Cu_ApbGerencia
        '
        Me.Cu_ApbGerencia.componenteasociado = "Cu_BuscarPersonaGerencia"
        Me.Cu_ApbGerencia.CrearUsuario = True
        Me.Cu_ApbGerencia.Location = New System.Drawing.Point(771, 58)
        Me.Cu_ApbGerencia.Name = "Cu_ApbGerencia"
        Me.Cu_ApbGerencia.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ApbGerencia.TabIndex = 17
        Me.Cu_ApbGerencia.Tag = "289"
        Me.Cu_ApbGerencia.TipoAsociacion = "BOD"
        Me.Cu_ApbGerencia.TipoBúsqueda = "P"
        '
        'Cu_ApbRevisa
        '
        Me.Cu_ApbRevisa.componenteasociado = "Cu_BuscarPersonaRevisa"
        Me.Cu_ApbRevisa.CrearUsuario = True
        Me.Cu_ApbRevisa.Location = New System.Drawing.Point(372, 31)
        Me.Cu_ApbRevisa.Name = "Cu_ApbRevisa"
        Me.Cu_ApbRevisa.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ApbRevisa.TabIndex = 8
        Me.Cu_ApbRevisa.Tag = "286"
        Me.Cu_ApbRevisa.TipoAsociacion = "BOD"
        Me.Cu_ApbRevisa.TipoBúsqueda = "P"
        '
        'Cu_ApbAprueba
        '
        Me.Cu_ApbAprueba.componenteasociado = "Cu_BuscarPersonaAprueba"
        Me.Cu_ApbAprueba.CrearUsuario = True
        Me.Cu_ApbAprueba.Location = New System.Drawing.Point(372, 58)
        Me.Cu_ApbAprueba.Name = "Cu_ApbAprueba"
        Me.Cu_ApbAprueba.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ApbAprueba.TabIndex = 14
        Me.Cu_ApbAprueba.Tag = "288"
        Me.Cu_ApbAprueba.TipoAsociacion = "BOD"
        Me.Cu_ApbAprueba.TipoBúsqueda = "P"
        '
        'Cu_ApbAutoriza
        '
        Me.Cu_ApbAutoriza.componenteasociado = "Cu_BuscarPersonaAutoriza"
        Me.Cu_ApbAutoriza.CrearUsuario = True
        Me.Cu_ApbAutoriza.Location = New System.Drawing.Point(771, 31)
        Me.Cu_ApbAutoriza.Name = "Cu_ApbAutoriza"
        Me.Cu_ApbAutoriza.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ApbAutoriza.TabIndex = 11
        Me.Cu_ApbAutoriza.Tag = "287"
        Me.Cu_ApbAutoriza.TipoAsociacion = "BOD"
        Me.Cu_ApbAutoriza.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaGerencia
        '
        Me.Cu_BuscarPersonaGerencia.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaGerencia.Location = New System.Drawing.Point(453, 58)
        Me.Cu_BuscarPersonaGerencia.Name = "Cu_BuscarPersonaGerencia"
        Me.Cu_BuscarPersonaGerencia.Size = New System.Drawing.Size(316, 23)
        Me.Cu_BuscarPersonaGerencia.TabIndex = 16
        Me.Cu_BuscarPersonaGerencia.Tipo = "PUABO"
        Me.Cu_BuscarPersonaGerencia.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaRevisa
        '
        Me.Cu_BuscarPersonaRevisa.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaRevisa.Location = New System.Drawing.Point(53, 30)
        Me.Cu_BuscarPersonaRevisa.Name = "Cu_BuscarPersonaRevisa"
        Me.Cu_BuscarPersonaRevisa.Size = New System.Drawing.Size(316, 23)
        Me.Cu_BuscarPersonaRevisa.TabIndex = 7
        Me.Cu_BuscarPersonaRevisa.Tipo = "PUABO"
        Me.Cu_BuscarPersonaRevisa.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaAutoriza
        '
        Me.Cu_BuscarPersonaAutoriza.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAutoriza.Location = New System.Drawing.Point(453, 31)
        Me.Cu_BuscarPersonaAutoriza.Name = "Cu_BuscarPersonaAutoriza"
        Me.Cu_BuscarPersonaAutoriza.Size = New System.Drawing.Size(316, 23)
        Me.Cu_BuscarPersonaAutoriza.TabIndex = 10
        Me.Cu_BuscarPersonaAutoriza.Tipo = "PUABO"
        Me.Cu_BuscarPersonaAutoriza.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaAprueba
        '
        Me.Cu_BuscarPersonaAprueba.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAprueba.Location = New System.Drawing.Point(53, 58)
        Me.Cu_BuscarPersonaAprueba.Name = "Cu_BuscarPersonaAprueba"
        Me.Cu_BuscarPersonaAprueba.Size = New System.Drawing.Size(316, 23)
        Me.Cu_BuscarPersonaAprueba.TabIndex = 13
        Me.Cu_BuscarPersonaAprueba.Tipo = "PUABO"
        Me.Cu_BuscarPersonaAprueba.valorcajatexto = "IDENTIFICACION"
        '
        'LISTAITEMREQUISICIONTableAdapter
        '
        Me.LISTAITEMREQUISICIONTableAdapter.ClearBeforeFill = True
        '
        'Fr_OrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 741)
        Me.Controls.Add(Me.Pn_Item)
        Me.Controls.Add(Me.Pn_Encabezado)
        Me.Controls.Add(Me.Pn_Personas)
        Me.Controls.Add(Me.Pn_Botones)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_OrdenCompra"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden Compra"
        Me.Pn_Encabezado.ResumeLayout(False)
        Me.Pn_Encabezado.PerformLayout()
        Me.Gb_Proveedor.ResumeLayout(False)
        Me.Gb_Proveedor.PerformLayout()
        Me.Pn_Item.ResumeLayout(False)
        CType(Me.Dgv_Item, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LISTAITEMREQUISICIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_OrdenCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Botones.ResumeLayout(False)
        Me.Pn_Botones.PerformLayout()
        Me.Pn_Personas.ResumeLayout(False)
        Me.Pn_Personas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tx_DirecciónProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tx_Identificación As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tx_FaxProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Tx_TelefonoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Encabezado As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Observación As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pn_Encabezado As System.Windows.Forms.Panel
    Friend WithEvents Pn_Item As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Item As System.Windows.Forms.DataGridView
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents Lb_TotalOC As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Gb_Proveedor As System.Windows.Forms.GroupBox
    Friend WithEvents Tx_CelularProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Tx_NombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Tx_DigVerificación As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bt_BuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Tx_Cotización As System.Windows.Forms.TextBox
    Friend WithEvents Cb_TipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Dtp_FechaDespacho As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoOrdenCompra As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaRevisa As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaAprueba As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaAutoriza As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaGerencia As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Pn_Personas As System.Windows.Forms.Panel
    Friend WithEvents Cu_ApbGerencia As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_ApbRevisa As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_ApbAprueba As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_ApbAutoriza As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Tx_ValorDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoDescuento As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Cu_CiudadDirección As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Tx_DespacharA As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Lb_Requisición As System.Windows.Forms.Label
    Friend WithEvents LISTAITEMREQUISICIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_OrdenCompra As DatosOrdenCompra.Ds_OrdenCompra
    Friend WithEvents LISTAITEMREQUISICIONTableAdapter As DatosOrdenCompra.Ds_OrdenCompraTableAdapters.LISTAITEMREQUISICIONTableAdapter
    Friend WithEvents APLICADESCUENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Bt_Aplicar As System.Windows.Forms.Button
    Friend WithEvents Tx_CondiciónPago As System.Windows.Forms.TextBox
    Friend WithEvents Cms_Direcciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Ll_ActualizarContacto As System.Windows.Forms.LinkLabel
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Public WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Ck_ValorIncluyeArancel As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_TRM As System.Windows.Forms.TextBox
    Friend WithEvents IDITEMORDENCOMPRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDITEMREQUISICIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDARTICULODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PORCENTAJEIVADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents CANTIDADPENDIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALORUNITARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPODESCUENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents VALORDESCUENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALORTOTALITEMDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDORDENCOMPRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDREQUISICIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bt_PersonalizarCondicionPago As System.Windows.Forms.Button
    Friend WithEvents Cms_CondiciónPago As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tx_CorreoNotificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Tx_PersonaContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Tx_DireccionNotificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ToolTipOrdenCompra As System.Windows.Forms.ToolTip
End Class
