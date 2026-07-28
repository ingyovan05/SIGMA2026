<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_EntradaAlmacen
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
        Me.Dgv_item = New System.Windows.Forms.DataGridView()
        Me.ItemDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CódigoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UndDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripciónDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequisiciónDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemRQDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdenCompraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemOCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FacturaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDORDENCOMPRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDREQUISICIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Validar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LISTAITEMENTRADAALMACENBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_EntradaAlmacén = New DatosEntradaAlmacén.Ds_EntradaAlmacén()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Cbx_ImpSticker = New System.Windows.Forms.CheckBox()
        Me.Cbx_VerificacionEquipos = New System.Windows.Forms.CheckBox()
        Me.Bt_SeleccionarEquipos = New System.Windows.Forms.Button()
        Me.Ll_ActualizarContacto = New System.Windows.Forms.LinkLabel()
        Me.Lb_TotalOC = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Cu_BpEntregaABodega = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_APB_EntregaABodega = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BPRecibio = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BpVerifico = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BpAprobo = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_APB_Aprueba = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_APB_Verifica = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_APB_Recibido = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.PnEncabezado = New System.Windows.Forms.Panel()
        Me.Tx_lectora = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Dtp_FechaRecibido = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tx_Entrega = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tx_Transportador = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dtp_FechaRemisión = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Bt_Agregar = New System.Windows.Forms.Button()
        Me.Tx_Remisión = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tx_NroFactura = New System.Windows.Forms.TextBox()
        Me.Lb_Factura = New System.Windows.Forms.Label()
        Me.Cb_Relación = New System.Windows.Forms.ComboBox()
        Me.Lb_Relación = New System.Windows.Forms.Label()
        Me.Cb_TipoEntrada = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tx_Observacion_AI = New System.Windows.Forms.TextBox()
        Me.Pn_Item = New System.Windows.Forms.Panel()
        Me.Pn_TituloItemRequisición = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LISTAITEMENTRADAALMACENTableAdapter = New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.LISTAITEMENTRADAALMACENTableAdapter()
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
        CType(Me.Dgv_item, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LISTAITEMENTRADAALMACENBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_EntradaAlmacén, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.PnEncabezado.SuspendLayout()
        Me.Pn_Item.SuspendLayout()
        Me.Pn_TituloItemRequisición.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_item
        '
        Me.Dgv_item.AutoGenerateColumns = False
        Me.Dgv_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_item.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemDataGridViewTextBoxColumn, Me.CódigoDataGridViewTextBoxColumn, Me.UndDataGridViewTextBoxColumn, Me.DescripciónDataGridViewTextBoxColumn, Me.CantDataGridViewTextBoxColumn, Me.RequisiciónDataGridViewTextBoxColumn, Me.ItemRQDataGridViewTextBoxColumn, Me.OrdenCompraDataGridViewTextBoxColumn, Me.ItemOCDataGridViewTextBoxColumn, Me.FacturaDataGridViewTextBoxColumn, Me.IDORDENCOMPRADataGridViewTextBoxColumn, Me.IDREQUISICIONDataGridViewTextBoxColumn, Me.Validar})
        Me.Dgv_item.DataSource = Me.LISTAITEMENTRADAALMACENBindingSource
        Me.Dgv_item.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_item.Location = New System.Drawing.Point(0, 24)
        Me.Dgv_item.Name = "Dgv_item"
        Me.Dgv_item.Size = New System.Drawing.Size(922, 279)
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
        Me.DescripciónDataGridViewTextBoxColumn.Width = 200
        '
        'CantDataGridViewTextBoxColumn
        '
        Me.CantDataGridViewTextBoxColumn.DataPropertyName = "Cant"
        Me.CantDataGridViewTextBoxColumn.HeaderText = "Cant"
        Me.CantDataGridViewTextBoxColumn.Name = "CantDataGridViewTextBoxColumn"
        Me.CantDataGridViewTextBoxColumn.Width = 50
        '
        'RequisiciónDataGridViewTextBoxColumn
        '
        Me.RequisiciónDataGridViewTextBoxColumn.DataPropertyName = "Requisición"
        Me.RequisiciónDataGridViewTextBoxColumn.HeaderText = "Requisición"
        Me.RequisiciónDataGridViewTextBoxColumn.Name = "RequisiciónDataGridViewTextBoxColumn"
        Me.RequisiciónDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ItemRQDataGridViewTextBoxColumn
        '
        Me.ItemRQDataGridViewTextBoxColumn.DataPropertyName = "Item RQ"
        Me.ItemRQDataGridViewTextBoxColumn.HeaderText = "Item RQ"
        Me.ItemRQDataGridViewTextBoxColumn.Name = "ItemRQDataGridViewTextBoxColumn"
        Me.ItemRQDataGridViewTextBoxColumn.Width = 40
        '
        'OrdenCompraDataGridViewTextBoxColumn
        '
        Me.OrdenCompraDataGridViewTextBoxColumn.DataPropertyName = "Orden Compra"
        Me.OrdenCompraDataGridViewTextBoxColumn.HeaderText = "Orden Compra"
        Me.OrdenCompraDataGridViewTextBoxColumn.Name = "OrdenCompraDataGridViewTextBoxColumn"
        Me.OrdenCompraDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ItemOCDataGridViewTextBoxColumn
        '
        Me.ItemOCDataGridViewTextBoxColumn.DataPropertyName = "Item OC"
        Me.ItemOCDataGridViewTextBoxColumn.HeaderText = "Item OC"
        Me.ItemOCDataGridViewTextBoxColumn.Name = "ItemOCDataGridViewTextBoxColumn"
        Me.ItemOCDataGridViewTextBoxColumn.Width = 40
        '
        'FacturaDataGridViewTextBoxColumn
        '
        Me.FacturaDataGridViewTextBoxColumn.DataPropertyName = "Factura"
        Me.FacturaDataGridViewTextBoxColumn.HeaderText = "Factura"
        Me.FacturaDataGridViewTextBoxColumn.Name = "FacturaDataGridViewTextBoxColumn"
        Me.FacturaDataGridViewTextBoxColumn.Width = 60
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
        'Validar
        '
        Me.Validar.DataPropertyName = "Cant"
        Me.Validar.HeaderText = "Validar"
        Me.Validar.Name = "Validar"
        Me.Validar.ReadOnly = True
        Me.Validar.Visible = False
        '
        'LISTAITEMENTRADAALMACENBindingSource
        '
        Me.LISTAITEMENTRADAALMACENBindingSource.DataMember = "LISTAITEMENTRADAALMACEN"
        Me.LISTAITEMENTRADAALMACENBindingSource.DataSource = Me.Ds_EntradaAlmacén
        '
        'Ds_EntradaAlmacén
        '
        Me.Ds_EntradaAlmacén.DataSetName = "Ds_EntradaAlmacén"
        Me.Ds_EntradaAlmacén.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(761, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 4
        Me.Bt_Guardar.Text = "Aceptar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(842, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 5
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(16, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Recibió:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(479, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 13)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Verifica:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(11, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Aprueba:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Cbx_ImpSticker)
        Me.Panel3.Controls.Add(Me.Cbx_VerificacionEquipos)
        Me.Panel3.Controls.Add(Me.Bt_SeleccionarEquipos)
        Me.Panel3.Controls.Add(Me.Ll_ActualizarContacto)
        Me.Panel3.Controls.Add(Me.Lb_TotalOC)
        Me.Panel3.Controls.Add(Me.Bt_Cancelar)
        Me.Panel3.Controls.Add(Me.Bt_Guardar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 515)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(922, 30)
        Me.Panel3.TabIndex = 3
        '
        'Cbx_ImpSticker
        '
        Me.Cbx_ImpSticker.AutoSize = True
        Me.Cbx_ImpSticker.Location = New System.Drawing.Point(350, 7)
        Me.Cbx_ImpSticker.Name = "Cbx_ImpSticker"
        Me.Cbx_ImpSticker.Size = New System.Drawing.Size(97, 17)
        Me.Cbx_ImpSticker.TabIndex = 6
        Me.Cbx_ImpSticker.Text = "Imprimir Sticker"
        Me.Cbx_ImpSticker.UseVisualStyleBackColor = True
        '
        'Cbx_VerificacionEquipos
        '
        Me.Cbx_VerificacionEquipos.AutoSize = True
        Me.Cbx_VerificacionEquipos.Location = New System.Drawing.Point(606, 8)
        Me.Cbx_VerificacionEquipos.Name = "Cbx_VerificacionEquipos"
        Me.Cbx_VerificacionEquipos.Size = New System.Drawing.Size(15, 14)
        Me.Cbx_VerificacionEquipos.TabIndex = 2
        Me.Cbx_VerificacionEquipos.UseVisualStyleBackColor = True
        '
        'Bt_SeleccionarEquipos
        '
        Me.Bt_SeleccionarEquipos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_SeleccionarEquipos.Enabled = False
        Me.Bt_SeleccionarEquipos.Location = New System.Drawing.Point(620, 3)
        Me.Bt_SeleccionarEquipos.Name = "Bt_SeleccionarEquipos"
        Me.Bt_SeleccionarEquipos.Size = New System.Drawing.Size(135, 23)
        Me.Bt_SeleccionarEquipos.TabIndex = 3
        Me.Bt_SeleccionarEquipos.Text = "Seleccionar/Ver Equipos"
        Me.Bt_SeleccionarEquipos.UseVisualStyleBackColor = True
        '
        'Ll_ActualizarContacto
        '
        Me.Ll_ActualizarContacto.AutoSize = True
        Me.Ll_ActualizarContacto.Location = New System.Drawing.Point(465, 8)
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
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Cu_BpEntregaABodega)
        Me.Panel4.Controls.Add(Me.Cu_APB_EntregaABodega)
        Me.Panel4.Controls.Add(Me.Cu_BPRecibio)
        Me.Panel4.Controls.Add(Me.Cu_BpVerifico)
        Me.Panel4.Controls.Add(Me.Cu_BpAprobo)
        Me.Panel4.Controls.Add(Me.Cu_APB_Aprueba)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Cu_APB_Verifica)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.Cu_APB_Recibido)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 456)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(922, 59)
        Me.Panel4.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(477, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Entrega:"
        '
        'Cu_BpEntregaABodega
        '
        Me.Cu_BpEntregaABodega.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BpEntregaABodega.Location = New System.Drawing.Point(524, 30)
        Me.Cu_BpEntregaABodega.Name = "Cu_BpEntregaABodega"
        Me.Cu_BpEntregaABodega.Size = New System.Drawing.Size(365, 23)
        Me.Cu_BpEntregaABodega.TabIndex = 10
        Me.Cu_BpEntregaABodega.Tipo = "PABO"
        Me.Cu_BpEntregaABodega.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_APB_EntregaABodega
        '
        Me.Cu_APB_EntregaABodega.componenteasociado = "Cu_BpEntregaABodega"
        Me.Cu_APB_EntregaABodega.CrearUsuario = True
        Me.Cu_APB_EntregaABodega.Location = New System.Drawing.Point(890, 30)
        Me.Cu_APB_EntregaABodega.Name = "Cu_APB_EntregaABodega"
        Me.Cu_APB_EntregaABodega.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_EntregaABodega.TabIndex = 11
        Me.Cu_APB_EntregaABodega.Tag = "327"
        Me.Cu_APB_EntregaABodega.TipoAsociacion = "BOD"
        Me.Cu_APB_EntregaABodega.TipoBúsqueda = "P"
        '
        'Cu_BPRecibio
        '
        Me.Cu_BPRecibio.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BPRecibio.Location = New System.Drawing.Point(62, 5)
        Me.Cu_BPRecibio.Name = "Cu_BPRecibio"
        Me.Cu_BPRecibio.Size = New System.Drawing.Size(369, 23)
        Me.Cu_BPRecibio.TabIndex = 1
        Me.Cu_BPRecibio.Tipo = "PABO"
        Me.Cu_BPRecibio.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BpVerifico
        '
        Me.Cu_BpVerifico.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BpVerifico.Location = New System.Drawing.Point(524, 5)
        Me.Cu_BpVerifico.Name = "Cu_BpVerifico"
        Me.Cu_BpVerifico.Size = New System.Drawing.Size(365, 23)
        Me.Cu_BpVerifico.TabIndex = 4
        Me.Cu_BpVerifico.Tipo = "PUABO"
        Me.Cu_BpVerifico.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BpAprobo
        '
        Me.Cu_BpAprobo.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BpAprobo.Location = New System.Drawing.Point(62, 30)
        Me.Cu_BpAprobo.Name = "Cu_BpAprobo"
        Me.Cu_BpAprobo.Size = New System.Drawing.Size(369, 23)
        Me.Cu_BpAprobo.TabIndex = 7
        Me.Cu_BpAprobo.Tipo = "PUABO"
        Me.Cu_BpAprobo.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_APB_Aprueba
        '
        Me.Cu_APB_Aprueba.componenteasociado = "Cu_BpAprobo"
        Me.Cu_APB_Aprueba.CrearUsuario = True
        Me.Cu_APB_Aprueba.Location = New System.Drawing.Point(437, 30)
        Me.Cu_APB_Aprueba.Name = "Cu_APB_Aprueba"
        Me.Cu_APB_Aprueba.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_Aprueba.TabIndex = 8
        Me.Cu_APB_Aprueba.Tag = "328"
        Me.Cu_APB_Aprueba.TipoAsociacion = "BOD"
        Me.Cu_APB_Aprueba.TipoBúsqueda = "P"
        '
        'Cu_APB_Verifica
        '
        Me.Cu_APB_Verifica.componenteasociado = "Cu_BpVerifico"
        Me.Cu_APB_Verifica.CrearUsuario = True
        Me.Cu_APB_Verifica.Location = New System.Drawing.Point(890, 5)
        Me.Cu_APB_Verifica.Name = "Cu_APB_Verifica"
        Me.Cu_APB_Verifica.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_Verifica.TabIndex = 5
        Me.Cu_APB_Verifica.Tag = "327"
        Me.Cu_APB_Verifica.TipoAsociacion = "BOD"
        Me.Cu_APB_Verifica.TipoBúsqueda = "P"
        '
        'Cu_APB_Recibido
        '
        Me.Cu_APB_Recibido.componenteasociado = "Cu_BPRecibio"
        Me.Cu_APB_Recibido.CrearUsuario = False
        Me.Cu_APB_Recibido.Location = New System.Drawing.Point(437, 5)
        Me.Cu_APB_Recibido.Name = "Cu_APB_Recibido"
        Me.Cu_APB_Recibido.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_Recibido.TabIndex = 2
        Me.Cu_APB_Recibido.Tag = "326"
        Me.Cu_APB_Recibido.TipoAsociacion = "BOD"
        Me.Cu_APB_Recibido.TipoBúsqueda = "P"
        '
        'PnEncabezado
        '
        Me.PnEncabezado.Controls.Add(Me.Tx_lectora)
        Me.PnEncabezado.Controls.Add(Me.Label15)
        Me.PnEncabezado.Controls.Add(Me.Dtp_FechaRecibido)
        Me.PnEncabezado.Controls.Add(Me.Label3)
        Me.PnEncabezado.Controls.Add(Me.Tx_Entrega)
        Me.PnEncabezado.Controls.Add(Me.Label7)
        Me.PnEncabezado.Controls.Add(Me.Tx_Transportador)
        Me.PnEncabezado.Controls.Add(Me.Label6)
        Me.PnEncabezado.Controls.Add(Me.Label1)
        Me.PnEncabezado.Controls.Add(Me.Dtp_FechaRemisión)
        Me.PnEncabezado.Controls.Add(Me.Label5)
        Me.PnEncabezado.Controls.Add(Me.Bt_Agregar)
        Me.PnEncabezado.Controls.Add(Me.Tx_Remisión)
        Me.PnEncabezado.Controls.Add(Me.Label4)
        Me.PnEncabezado.Controls.Add(Me.Tx_NroFactura)
        Me.PnEncabezado.Controls.Add(Me.Lb_Factura)
        Me.PnEncabezado.Controls.Add(Me.Cb_Relación)
        Me.PnEncabezado.Controls.Add(Me.Lb_Relación)
        Me.PnEncabezado.Controls.Add(Me.Cb_TipoEntrada)
        Me.PnEncabezado.Controls.Add(Me.Label2)
        Me.PnEncabezado.Controls.Add(Me.Tx_Observacion_AI)
        Me.PnEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.PnEncabezado.Name = "PnEncabezado"
        Me.PnEncabezado.Size = New System.Drawing.Size(922, 153)
        Me.PnEncabezado.TabIndex = 0
        '
        'Tx_lectora
        '
        Me.Tx_lectora.Location = New System.Drawing.Point(819, 127)
        Me.Tx_lectora.MaxLength = 7
        Me.Tx_lectora.Name = "Tx_lectora"
        Me.Tx_lectora.Size = New System.Drawing.Size(98, 20)
        Me.Tx_lectora.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(726, 130)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Capturar Lectora:"
        '
        'Dtp_FechaRecibido
        '
        Me.Dtp_FechaRecibido.Checked = False
        Me.Dtp_FechaRecibido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaRecibido.Location = New System.Drawing.Point(615, 32)
        Me.Dtp_FechaRecibido.Name = "Dtp_FechaRecibido"
        Me.Dtp_FechaRecibido.ShowCheckBox = True
        Me.Dtp_FechaRecibido.Size = New System.Drawing.Size(116, 20)
        Me.Dtp_FechaRecibido.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(527, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Fecha Recibido:"
        '
        'Tx_Entrega
        '
        Me.Tx_Entrega.Location = New System.Drawing.Point(615, 57)
        Me.Tx_Entrega.MaxLength = 50
        Me.Tx_Entrega.Name = "Tx_Entrega"
        Me.Tx_Entrega.Size = New System.Drawing.Size(302, 20)
        Me.Tx_Entrega.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(536, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Transportador:"
        '
        'Tx_Transportador
        '
        Me.Tx_Transportador.Location = New System.Drawing.Point(88, 57)
        Me.Tx_Transportador.MaxLength = 50
        Me.Tx_Transportador.Name = "Tx_Transportador"
        Me.Tx_Transportador.Size = New System.Drawing.Size(428, 20)
        Me.Tx_Transportador.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Empresa Trans:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Observación:"
        '
        'Dtp_FechaRemisión
        '
        Me.Dtp_FechaRemisión.Checked = False
        Me.Dtp_FechaRemisión.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaRemisión.Location = New System.Drawing.Point(336, 32)
        Me.Dtp_FechaRemisión.Name = "Dtp_FechaRemisión"
        Me.Dtp_FechaRemisión.ShowCheckBox = True
        Me.Dtp_FechaRemisión.Size = New System.Drawing.Size(130, 20)
        Me.Dtp_FechaRemisión.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(247, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fecha Remisión:"
        '
        'Bt_Agregar
        '
        Me.Bt_Agregar.Location = New System.Drawing.Point(522, 6)
        Me.Bt_Agregar.Name = "Bt_Agregar"
        Me.Bt_Agregar.Size = New System.Drawing.Size(29, 23)
        Me.Bt_Agregar.TabIndex = 4
        Me.Bt_Agregar.Text = "+"
        Me.Bt_Agregar.UseVisualStyleBackColor = True
        Me.Bt_Agregar.Visible = False
        '
        'Tx_Remisión
        '
        Me.Tx_Remisión.Location = New System.Drawing.Point(88, 32)
        Me.Tx_Remisión.MaxLength = 20
        Me.Tx_Remisión.Name = "Tx_Remisión"
        Me.Tx_Remisión.Size = New System.Drawing.Size(154, 20)
        Me.Tx_Remisión.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Remisión:"
        '
        'Tx_NroFactura
        '
        Me.Tx_NroFactura.Location = New System.Drawing.Point(615, 6)
        Me.Tx_NroFactura.MaxLength = 20
        Me.Tx_NroFactura.Name = "Tx_NroFactura"
        Me.Tx_NroFactura.Size = New System.Drawing.Size(116, 20)
        Me.Tx_NroFactura.TabIndex = 6
        Me.Tx_NroFactura.Visible = False
        '
        'Lb_Factura
        '
        Me.Lb_Factura.AutoSize = True
        Me.Lb_Factura.Location = New System.Drawing.Point(567, 10)
        Me.Lb_Factura.Name = "Lb_Factura"
        Me.Lb_Factura.Size = New System.Drawing.Size(46, 13)
        Me.Lb_Factura.TabIndex = 5
        Me.Lb_Factura.Text = "Factura:"
        Me.Lb_Factura.Visible = False
        '
        'Cb_Relación
        '
        Me.Cb_Relación.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Relación.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Relación.FormattingEnabled = True
        Me.Cb_Relación.Location = New System.Drawing.Point(336, 7)
        Me.Cb_Relación.Name = "Cb_Relación"
        Me.Cb_Relación.Size = New System.Drawing.Size(180, 21)
        Me.Cb_Relación.TabIndex = 3
        '
        'Lb_Relación
        '
        Me.Lb_Relación.Location = New System.Drawing.Point(254, 10)
        Me.Lb_Relación.Name = "Lb_Relación"
        Me.Lb_Relación.Size = New System.Drawing.Size(80, 13)
        Me.Lb_Relación.TabIndex = 2
        Me.Lb_Relación.Text = "Relación:"
        Me.Lb_Relación.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Cb_TipoEntrada
        '
        Me.Cb_TipoEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoEntrada.FormattingEnabled = True
        Me.Cb_TipoEntrada.Location = New System.Drawing.Point(88, 7)
        Me.Cb_TipoEntrada.Name = "Cb_TipoEntrada"
        Me.Cb_TipoEntrada.Size = New System.Drawing.Size(154, 21)
        Me.Cb_TipoEntrada.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo Entrada:"
        '
        'Tx_Observacion_AI
        '
        Me.Tx_Observacion_AI.Location = New System.Drawing.Point(88, 83)
        Me.Tx_Observacion_AI.MaxLength = 200
        Me.Tx_Observacion_AI.Multiline = True
        Me.Tx_Observacion_AI.Name = "Tx_Observacion_AI"
        Me.Tx_Observacion_AI.Size = New System.Drawing.Size(829, 38)
        Me.Tx_Observacion_AI.TabIndex = 18
        '
        'Pn_Item
        '
        Me.Pn_Item.Controls.Add(Me.Dgv_item)
        Me.Pn_Item.Controls.Add(Me.Pn_TituloItemRequisición)
        Me.Pn_Item.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Item.Location = New System.Drawing.Point(0, 153)
        Me.Pn_Item.Name = "Pn_Item"
        Me.Pn_Item.Size = New System.Drawing.Size(922, 303)
        Me.Pn_Item.TabIndex = 1
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
        Me.Label31.Text = "ITEM'S ENTRADA DE ALMACEN"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LISTAITEMENTRADAALMACENTableAdapter
        '
        Me.LISTAITEMENTRADAALMACENTableAdapter.ClearBeforeFill = True
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
        Me.DataGridViewTextBoxColumn4.Width = 200
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
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Requisición"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Requisición"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Item RQ"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Item RQ"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 40
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Orden Compra"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Orden Compra"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Item OC"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Item OC"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 40
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Factura"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Factura"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 60
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "IDORDENCOMPRA"
        Me.DataGridViewTextBoxColumn11.HeaderText = "IDORDENCOMPRA"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "IDREQUISICION"
        Me.DataGridViewTextBoxColumn12.HeaderText = "IDREQUISICION"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Cant"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Validar"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'Fr_EntradaAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 545)
        Me.Controls.Add(Me.Pn_Item)
        Me.Controls.Add(Me.PnEncabezado)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(938, 556)
        Me.Name = "Fr_EntradaAlmacen"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entrada de Almacén"
        CType(Me.Dgv_item, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LISTAITEMENTRADAALMACENBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_EntradaAlmacén, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.PnEncabezado.ResumeLayout(False)
        Me.PnEncabezado.PerformLayout()
        Me.Pn_Item.ResumeLayout(False)
        Me.Pn_TituloItemRequisición.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv_item As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Cu_BPRecibio As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BpVerifico As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BpAprobo As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Cu_APB_Recibido As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_APB_Verifica As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_APB_Aprueba As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Lb_TotalOC As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PnEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Tx_Observacion_AI As System.Windows.Forms.TextBox
    Friend WithEvents Pn_Item As System.Windows.Forms.Panel
    Friend WithEvents Pn_TituloItemRequisición As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoEntrada As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tx_NroFactura As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Factura As System.Windows.Forms.Label
    Friend WithEvents Cb_Relación As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Relación As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaRemisión As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Bt_Agregar As System.Windows.Forms.Button
    Friend WithEvents Tx_Remisión As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tx_Entrega As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Tx_Transportador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaRecibido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LISTAITEMENTRADAALMACENBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_EntradaAlmacén As DatosEntradaAlmacén.Ds_EntradaAlmacén
    Friend WithEvents LISTAITEMENTRADAALMACENTableAdapter As DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.LISTAITEMENTRADAALMACENTableAdapter
    Friend WithEvents Ll_ActualizarContacto As System.Windows.Forms.LinkLabel
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents ItemDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CódigoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UndDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripciónDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequisiciónDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemRQDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdenCompraDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemOCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FacturaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDORDENCOMPRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDREQUISICIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Validar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cbx_VerificacionEquipos As System.Windows.Forms.CheckBox
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Cu_BpEntregaABodega As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_APB_EntregaABodega As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Tx_lectora As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Cbx_ImpSticker As System.Windows.Forms.CheckBox
End Class
