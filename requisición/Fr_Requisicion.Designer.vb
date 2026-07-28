<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Requisicion
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Dgv_ItemRequisicion = New System.Windows.Forms.DataGridView()
        Me.Col_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NroItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_CodUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_ExistBodLocal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_ExistBodPrincipal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_AdqBodLocal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_AdqBodPrincipal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdItemRequisicion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Pn_Encabezado = New System.Windows.Forms.Panel()
        Me.AOT = New FormulariosClasesBase.Cu_Asociar()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tb_Encabezado = New System.Windows.Forms.TextBox()
        Me.Bt_GestionarActividades = New System.Windows.Forms.Button()
        Me.Cu_AsociarActivoFijo1 = New FormulariosClasesBase.Cu_AsociarActivoFijo()
        Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Ck_RecGasto = New System.Windows.Forms.CheckBox()
        Me.Bt_AgregarActividad = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cb_Actividad = New System.Windows.Forms.ComboBox()
        Me.Ck_Stock = New System.Windows.Forms.CheckBox()
        Me.Ck_Incorporable = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Cb_TipoItem = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cb_TipoPrioridad = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tb_Origen = New System.Windows.Forms.TextBox()
        Me.Tb_Destino = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tb_Base = New System.Windows.Forms.TextBox()
        Me.Tb_Justificacion = New System.Windows.Forms.TextBox()
        Me.Cb_TipoReq = New System.Windows.Forms.ComboBox()
        Me.Pn_ItemRequisición = New System.Windows.Forms.Panel()
        Me.Pn_TituloItemRequisición = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Ll_ActualizarContacto = New System.Windows.Forms.LinkLabel()
        Me.Lb_CódigoArtículo = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Pn_PersonasAsociadas = New System.Windows.Forms.Panel()
        Me.Cu_BuscarPersonaSolicita = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_ApbAprueba = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_ApbAutoriza = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_ApbRevisa = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_ApbSolicita = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaAutoriza = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaAprueba = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaRevisa = New FormulariosClasesBase.Cu_BuscarPersona()
        CType(Me.Dgv_ItemRequisicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Encabezado.SuspendLayout()
        Me.Pn_ItemRequisición.SuspendLayout()
        Me.Pn_TituloItemRequisición.SuspendLayout()
        Me.Pn_Botones.SuspendLayout()
        Me.Pn_PersonasAsociadas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_ItemRequisicion
        '
        Me.Dgv_ItemRequisicion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_ItemRequisicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_ItemRequisicion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_Item, Me.Col_IdArticulo, Me.Col_Unidad, Me.Col_NroItem, Me.Col_CodUnidad, Me.Col_Descripcion, Me.Col_Cantidad, Me.Col_ExistBodLocal, Me.Col_ExistBodPrincipal, Me.Col_AdqBodLocal, Me.Col_AdqBodPrincipal, Me.Col_IdItemRequisicion})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv_ItemRequisicion.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_ItemRequisicion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ItemRequisicion.Location = New System.Drawing.Point(0, 24)
        Me.Dgv_ItemRequisicion.Name = "Dgv_ItemRequisicion"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_ItemRequisicion.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_ItemRequisicion.Size = New System.Drawing.Size(804, 249)
        Me.Dgv_ItemRequisicion.TabIndex = 0
        '
        'Col_Item
        '
        Me.Col_Item.DataPropertyName = "NROITEM"
        Me.Col_Item.FillWeight = 50.0!
        Me.Col_Item.HeaderText = "Ítem"
        Me.Col_Item.Name = "Col_Item"
        Me.Col_Item.ReadOnly = True
        Me.Col_Item.ToolTipText = "Número de Ítem"
        '
        'Col_IdArticulo
        '
        Me.Col_IdArticulo.DataPropertyName = "IDARTICULO"
        Me.Col_IdArticulo.HeaderText = "Código"
        Me.Col_IdArticulo.Name = "Col_IdArticulo"
        Me.Col_IdArticulo.ToolTipText = "Código de Artículo"
        '
        'Col_Unidad
        '
        Me.Col_Unidad.DataPropertyName = "ABREVIATURA"
        Me.Col_Unidad.FillWeight = 50.0!
        Me.Col_Unidad.HeaderText = "Und"
        Me.Col_Unidad.Name = "Col_Unidad"
        Me.Col_Unidad.ReadOnly = True
        Me.Col_Unidad.ToolTipText = "Tipo de Unidad"
        '
        'Col_NroItem
        '
        Me.Col_NroItem.DataPropertyName = "NROITEM"
        Me.Col_NroItem.HeaderText = "NroItem"
        Me.Col_NroItem.Name = "Col_NroItem"
        Me.Col_NroItem.ReadOnly = True
        Me.Col_NroItem.Visible = False
        '
        'Col_CodUnidad
        '
        Me.Col_CodUnidad.DataPropertyName = "CODIGOTIPOUNIDAD"
        Me.Col_CodUnidad.HeaderText = "CodTipoUnidad"
        Me.Col_CodUnidad.Name = "Col_CodUnidad"
        Me.Col_CodUnidad.ReadOnly = True
        Me.Col_CodUnidad.Visible = False
        '
        'Col_Descripcion
        '
        Me.Col_Descripcion.DataPropertyName = "NOMBREDESCRIPTIVO"
        Me.Col_Descripcion.FillWeight = 300.0!
        Me.Col_Descripcion.HeaderText = "Descripción"
        Me.Col_Descripcion.Name = "Col_Descripcion"
        Me.Col_Descripcion.ReadOnly = True
        Me.Col_Descripcion.ToolTipText = "Descripción del Artículo"
        '
        'Col_Cantidad
        '
        Me.Col_Cantidad.DataPropertyName = "CANTIDADSOLICITADA"
        Me.Col_Cantidad.FillWeight = 50.0!
        Me.Col_Cantidad.HeaderText = "Cant"
        Me.Col_Cantidad.Name = "Col_Cantidad"
        Me.Col_Cantidad.ToolTipText = "Cantidad Solicitada"
        '
        'Col_ExistBodLocal
        '
        Me.Col_ExistBodLocal.DataPropertyName = "CANTIDADEXISTENCIA"
        Me.Col_ExistBodLocal.FillWeight = 50.0!
        Me.Col_ExistBodLocal.HeaderText = "Exist L"
        Me.Col_ExistBodLocal.Name = "Col_ExistBodLocal"
        Me.Col_ExistBodLocal.ReadOnly = True
        Me.Col_ExistBodLocal.ToolTipText = "Existencias en Bodega Local"
        '
        'Col_ExistBodPrincipal
        '
        Me.Col_ExistBodPrincipal.DataPropertyName = "CANTEXISTENCIAPPAL"
        Me.Col_ExistBodPrincipal.FillWeight = 50.0!
        Me.Col_ExistBodPrincipal.HeaderText = "Exist P"
        Me.Col_ExistBodPrincipal.Name = "Col_ExistBodPrincipal"
        Me.Col_ExistBodPrincipal.ReadOnly = True
        Me.Col_ExistBodPrincipal.ToolTipText = "Existencias en Bodegas Principales"
        '
        'Col_AdqBodLocal
        '
        Me.Col_AdqBodLocal.DataPropertyName = "CANTADQUISICIONLOCAL"
        Me.Col_AdqBodLocal.FillWeight = 50.0!
        Me.Col_AdqBodLocal.HeaderText = "Adq L"
        Me.Col_AdqBodLocal.Name = "Col_AdqBodLocal"
        Me.Col_AdqBodLocal.ReadOnly = True
        Me.Col_AdqBodLocal.ToolTipText = "En proceso de Adquisición Local"
        '
        'Col_AdqBodPrincipal
        '
        Me.Col_AdqBodPrincipal.DataPropertyName = "CANTADQUISICIONPPAL"
        Me.Col_AdqBodPrincipal.FillWeight = 50.0!
        Me.Col_AdqBodPrincipal.HeaderText = "Adq P"
        Me.Col_AdqBodPrincipal.Name = "Col_AdqBodPrincipal"
        Me.Col_AdqBodPrincipal.ReadOnly = True
        Me.Col_AdqBodPrincipal.ToolTipText = "En proceso de Adquisición en las Bodegas Principales"
        '
        'Col_IdItemRequisicion
        '
        Me.Col_IdItemRequisicion.DataPropertyName = "IDITEMREQUISICION"
        Me.Col_IdItemRequisicion.HeaderText = "IdItemRequisicion"
        Me.Col_IdItemRequisicion.Name = "Col_IdItemRequisicion"
        Me.Col_IdItemRequisicion.ReadOnly = True
        Me.Col_IdItemRequisicion.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Solicita:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(405, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Autoriza:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(404, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Aprueba:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Revisa:"
        '
        'Pn_Encabezado
        '
        Me.Pn_Encabezado.Controls.Add(Me.AOT)
        Me.Pn_Encabezado.Controls.Add(Me.Label15)
        Me.Pn_Encabezado.Controls.Add(Me.Label6)
        Me.Pn_Encabezado.Controls.Add(Me.Tb_Encabezado)
        Me.Pn_Encabezado.Controls.Add(Me.Bt_GestionarActividades)
        Me.Pn_Encabezado.Controls.Add(Me.Cu_AsociarActivoFijo1)
        Me.Pn_Encabezado.Controls.Add(Me.Cu_CentroCosto1)
        Me.Pn_Encabezado.Controls.Add(Me.Label8)
        Me.Pn_Encabezado.Controls.Add(Me.Ck_RecGasto)
        Me.Pn_Encabezado.Controls.Add(Me.Bt_AgregarActividad)
        Me.Pn_Encabezado.Controls.Add(Me.Label14)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_Actividad)
        Me.Pn_Encabezado.Controls.Add(Me.Ck_Stock)
        Me.Pn_Encabezado.Controls.Add(Me.Ck_Incorporable)
        Me.Pn_Encabezado.Controls.Add(Me.Label9)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_TipoItem)
        Me.Pn_Encabezado.Controls.Add(Me.Label7)
        Me.Pn_Encabezado.Controls.Add(Me.Label1)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_TipoPrioridad)
        Me.Pn_Encabezado.Controls.Add(Me.Label2)
        Me.Pn_Encabezado.Controls.Add(Me.Label3)
        Me.Pn_Encabezado.Controls.Add(Me.Tb_Origen)
        Me.Pn_Encabezado.Controls.Add(Me.Tb_Destino)
        Me.Pn_Encabezado.Controls.Add(Me.Label4)
        Me.Pn_Encabezado.Controls.Add(Me.Tb_Base)
        Me.Pn_Encabezado.Controls.Add(Me.Tb_Justificacion)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_TipoReq)
        Me.Pn_Encabezado.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Encabezado.MaximumSize = New System.Drawing.Size(804, 240)
        Me.Pn_Encabezado.MinimumSize = New System.Drawing.Size(804, 240)
        Me.Pn_Encabezado.Name = "Pn_Encabezado"
        Me.Pn_Encabezado.Size = New System.Drawing.Size(804, 240)
        Me.Pn_Encabezado.TabIndex = 0
        '
        'AOT
        '
        Me.AOT.Location = New System.Drawing.Point(175, 132)
        Me.AOT.Name = "AOT"
        Me.AOT.Size = New System.Drawing.Size(219, 20)
        Me.AOT.TabIndex = 32
        Me.AOT.Tipo = "OT"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(20, 132)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(149, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Asociar Orden Mantenimiento:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Encabezado:"
        '
        'Tb_Encabezado
        '
        Me.Tb_Encabezado.Location = New System.Drawing.Point(17, 170)
        Me.Tb_Encabezado.MaxLength = 199
        Me.Tb_Encabezado.Multiline = True
        Me.Tb_Encabezado.Name = "Tb_Encabezado"
        Me.Tb_Encabezado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tb_Encabezado.Size = New System.Drawing.Size(385, 63)
        Me.Tb_Encabezado.TabIndex = 24
        '
        'Bt_GestionarActividades
        '
        Me.Bt_GestionarActividades.Location = New System.Drawing.Point(530, 78)
        Me.Bt_GestionarActividades.Name = "Bt_GestionarActividades"
        Me.Bt_GestionarActividades.Size = New System.Drawing.Size(29, 24)
        Me.Bt_GestionarActividades.TabIndex = 20
        Me.Bt_GestionarActividades.Text = "..."
        Me.Bt_GestionarActividades.UseVisualStyleBackColor = True
        '
        'Cu_AsociarActivoFijo1
        '
        Me.Cu_AsociarActivoFijo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_AsociarActivoFijo1.Location = New System.Drawing.Point(565, 87)
        Me.Cu_AsociarActivoFijo1.Name = "Cu_AsociarActivoFijo1"
        Me.Cu_AsociarActivoFijo1.Size = New System.Drawing.Size(228, 38)
        Me.Cu_AsociarActivoFijo1.TabIndex = 28
        '
        'Cu_CentroCosto1
        '
        Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto1.Location = New System.Drawing.Point(565, 41)
        Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
        Me.Cu_CentroCosto1.Size = New System.Drawing.Size(228, 38)
        Me.Cu_CentroCosto1.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(310, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Tipo Pago:"
        '
        'Ck_RecGasto
        '
        Me.Ck_RecGasto.AutoSize = True
        Me.Ck_RecGasto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_RecGasto.Checked = True
        Me.Ck_RecGasto.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_RecGasto.Location = New System.Drawing.Point(145, 33)
        Me.Ck_RecGasto.Name = "Ck_RecGasto"
        Me.Ck_RecGasto.Size = New System.Drawing.Size(141, 17)
        Me.Ck_RecGasto.TabIndex = 5
        Me.Ck_RecGasto.Text = "Recuperación del Gasto"
        Me.Ck_RecGasto.UseVisualStyleBackColor = True
        '
        'Bt_AgregarActividad
        '
        Me.Bt_AgregarActividad.Location = New System.Drawing.Point(495, 78)
        Me.Bt_AgregarActividad.Name = "Bt_AgregarActividad"
        Me.Bt_AgregarActividad.Size = New System.Drawing.Size(29, 24)
        Me.Bt_AgregarActividad.TabIndex = 19
        Me.Bt_AgregarActividad.Text = "+"
        Me.Bt_AgregarActividad.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(51, 81)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Actividad:"
        '
        'Cb_Actividad
        '
        Me.Cb_Actividad.FormattingEnabled = True
        Me.Cb_Actividad.Location = New System.Drawing.Point(111, 81)
        Me.Cb_Actividad.Name = "Cb_Actividad"
        Me.Cb_Actividad.Size = New System.Drawing.Size(378, 21)
        Me.Cb_Actividad.TabIndex = 18
        '
        'Ck_Stock
        '
        Me.Ck_Stock.AutoSize = True
        Me.Ck_Stock.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_Stock.Checked = True
        Me.Ck_Stock.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_Stock.Location = New System.Drawing.Point(15, 33)
        Me.Ck_Stock.Name = "Ck_Stock"
        Me.Ck_Stock.Size = New System.Drawing.Size(109, 17)
        Me.Ck_Stock.TabIndex = 4
        Me.Ck_Stock.Text = "Stock de Bodega"
        Me.Ck_Stock.UseVisualStyleBackColor = True
        '
        'Ck_Incorporable
        '
        Me.Ck_Incorporable.AutoSize = True
        Me.Ck_Incorporable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_Incorporable.Checked = True
        Me.Ck_Incorporable.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_Incorporable.Location = New System.Drawing.Point(39, 58)
        Me.Ck_Incorporable.Name = "Ck_Incorporable"
        Me.Ck_Incorporable.Size = New System.Drawing.Size(85, 17)
        Me.Ck_Incorporable.TabIndex = 8
        Me.Ck_Incorporable.Text = "Incorporable"
        Me.Ck_Incorporable.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(145, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Tipo Item:"
        '
        'Cb_TipoItem
        '
        Me.Cb_TipoItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoItem.Enabled = False
        Me.Cb_TipoItem.FormattingEnabled = True
        Me.Cb_TipoItem.Location = New System.Drawing.Point(202, 56)
        Me.Cb_TipoItem.Name = "Cb_TipoItem"
        Me.Cb_TipoItem.Size = New System.Drawing.Size(138, 21)
        Me.Cb_TipoItem.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(366, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Prioridad:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(571, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Base:"
        '
        'Cb_TipoPrioridad
        '
        Me.Cb_TipoPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoPrioridad.FormattingEnabled = True
        Me.Cb_TipoPrioridad.Location = New System.Drawing.Point(419, 56)
        Me.Cb_TipoPrioridad.Name = "Cb_TipoPrioridad"
        Me.Cb_TipoPrioridad.Size = New System.Drawing.Size(90, 21)
        Me.Cb_TipoPrioridad.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Origen:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Destino:"
        '
        'Tb_Origen
        '
        Me.Tb_Origen.BackColor = System.Drawing.SystemColors.Control
        Me.Tb_Origen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tb_Origen.Enabled = False
        Me.Tb_Origen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_Origen.Location = New System.Drawing.Point(111, 8)
        Me.Tb_Origen.Name = "Tb_Origen"
        Me.Tb_Origen.Size = New System.Drawing.Size(454, 20)
        Me.Tb_Origen.TabIndex = 1
        '
        'Tb_Destino
        '
        Me.Tb_Destino.Location = New System.Drawing.Point(111, 106)
        Me.Tb_Destino.MaxLength = 200
        Me.Tb_Destino.Name = "Tb_Destino"
        Me.Tb_Destino.Size = New System.Drawing.Size(448, 20)
        Me.Tb_Destino.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(410, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Justificación:"
        '
        'Tb_Base
        '
        Me.Tb_Base.BackColor = System.Drawing.SystemColors.Control
        Me.Tb_Base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tb_Base.Enabled = False
        Me.Tb_Base.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_Base.Location = New System.Drawing.Point(611, 8)
        Me.Tb_Base.Name = "Tb_Base"
        Me.Tb_Base.Size = New System.Drawing.Size(182, 20)
        Me.Tb_Base.TabIndex = 3
        '
        'Tb_Justificacion
        '
        Me.Tb_Justificacion.Location = New System.Drawing.Point(407, 169)
        Me.Tb_Justificacion.MaxLength = 299
        Me.Tb_Justificacion.Multiline = True
        Me.Tb_Justificacion.Name = "Tb_Justificacion"
        Me.Tb_Justificacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tb_Justificacion.Size = New System.Drawing.Size(385, 63)
        Me.Tb_Justificacion.TabIndex = 26
        '
        'Cb_TipoReq
        '
        Me.Cb_TipoReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoReq.Enabled = False
        Me.Cb_TipoReq.FormattingEnabled = True
        Me.Cb_TipoReq.Location = New System.Drawing.Point(371, 31)
        Me.Cb_TipoReq.Name = "Cb_TipoReq"
        Me.Cb_TipoReq.Size = New System.Drawing.Size(138, 21)
        Me.Cb_TipoReq.TabIndex = 7
        '
        'Pn_ItemRequisición
        '
        Me.Pn_ItemRequisición.Controls.Add(Me.Dgv_ItemRequisicion)
        Me.Pn_ItemRequisición.Controls.Add(Me.Pn_TituloItemRequisición)
        Me.Pn_ItemRequisición.Location = New System.Drawing.Point(0, 243)
        Me.Pn_ItemRequisición.Name = "Pn_ItemRequisición"
        Me.Pn_ItemRequisición.Size = New System.Drawing.Size(804, 273)
        Me.Pn_ItemRequisición.TabIndex = 1
        '
        'Pn_TituloItemRequisición
        '
        Me.Pn_TituloItemRequisición.Controls.Add(Me.Label31)
        Me.Pn_TituloItemRequisición.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloItemRequisición.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloItemRequisición.Name = "Pn_TituloItemRequisición"
        Me.Pn_TituloItemRequisición.Size = New System.Drawing.Size(804, 24)
        Me.Pn_TituloItemRequisición.TabIndex = 30
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label31.Location = New System.Drawing.Point(0, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(804, 24)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "ITEM'S REQUISICION"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.Color.Silver
        Me.Pn_Botones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Botones.Controls.Add(Me.Ll_ActualizarContacto)
        Me.Pn_Botones.Controls.Add(Me.Lb_CódigoArtículo)
        Me.Pn_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Pn_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 572)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(804, 30)
        Me.Pn_Botones.TabIndex = 2
        '
        'Ll_ActualizarContacto
        '
        Me.Ll_ActualizarContacto.AutoSize = True
        Me.Ll_ActualizarContacto.Location = New System.Drawing.Point(508, 9)
        Me.Ll_ActualizarContacto.Name = "Ll_ActualizarContacto"
        Me.Ll_ActualizarContacto.Size = New System.Drawing.Size(125, 13)
        Me.Ll_ActualizarContacto.TabIndex = 1
        Me.Ll_ActualizarContacto.TabStop = True
        Me.Ll_ActualizarContacto.Text = "Ver/Actualizar Contactos"
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
        'Bt_Guardar
        '
        Me.Bt_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Guardar.Location = New System.Drawing.Point(641, 4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 2
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Cancelar.Location = New System.Drawing.Point(722, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 3
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Pn_PersonasAsociadas
        '
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_BuscarPersonaSolicita)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_ApbAprueba)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_ApbAutoriza)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_ApbRevisa)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_ApbSolicita)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Label10)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_BuscarPersonaAutoriza)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Label11)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Label5)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_BuscarPersonaAprueba)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_BuscarPersonaRevisa)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Label12)
        Me.Pn_PersonasAsociadas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_PersonasAsociadas.Location = New System.Drawing.Point(0, 516)
        Me.Pn_PersonasAsociadas.Name = "Pn_PersonasAsociadas"
        Me.Pn_PersonasAsociadas.Size = New System.Drawing.Size(804, 56)
        Me.Pn_PersonasAsociadas.TabIndex = 1
        '
        'Cu_BuscarPersonaSolicita
        '
        Me.Cu_BuscarPersonaSolicita.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaSolicita.Location = New System.Drawing.Point(54, 4)
        Me.Cu_BuscarPersonaSolicita.Name = "Cu_BuscarPersonaSolicita"
        Me.Cu_BuscarPersonaSolicita.Size = New System.Drawing.Size(315, 23)
        Me.Cu_BuscarPersonaSolicita.TabIndex = 1
        Me.Cu_BuscarPersonaSolicita.Tipo = "PABO"
        Me.Cu_BuscarPersonaSolicita.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_ApbAprueba
        '
        Me.Cu_ApbAprueba.componenteasociado = "Cu_BuscarPersonaAprueba"
        Me.Cu_ApbAprueba.CrearUsuario = True
        Me.Cu_ApbAprueba.Location = New System.Drawing.Point(772, 31)
        Me.Cu_ApbAprueba.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_ApbAprueba.Name = "Cu_ApbAprueba"
        Me.Cu_ApbAprueba.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ApbAprueba.TabIndex = 11
        Me.Cu_ApbAprueba.Tag = "293"
        Me.Cu_ApbAprueba.TipoAsociacion = "BOD"
        Me.Cu_ApbAprueba.TipoBúsqueda = "P"
        '
        'Cu_ApbAutoriza
        '
        Me.Cu_ApbAutoriza.componenteasociado = "Cu_BuscarPersonaAutoriza"
        Me.Cu_ApbAutoriza.CrearUsuario = True
        Me.Cu_ApbAutoriza.Location = New System.Drawing.Point(772, 5)
        Me.Cu_ApbAutoriza.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_ApbAutoriza.Name = "Cu_ApbAutoriza"
        Me.Cu_ApbAutoriza.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ApbAutoriza.TabIndex = 5
        Me.Cu_ApbAutoriza.Tag = "291"
        Me.Cu_ApbAutoriza.TipoAsociacion = "BOD"
        Me.Cu_ApbAutoriza.TipoBúsqueda = "P"
        '
        'Cu_ApbRevisa
        '
        Me.Cu_ApbRevisa.componenteasociado = "Cu_BuscarPersonaRevisa"
        Me.Cu_ApbRevisa.CrearUsuario = True
        Me.Cu_ApbRevisa.Location = New System.Drawing.Point(372, 29)
        Me.Cu_ApbRevisa.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_ApbRevisa.Name = "Cu_ApbRevisa"
        Me.Cu_ApbRevisa.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ApbRevisa.TabIndex = 8
        Me.Cu_ApbRevisa.Tag = "292"
        Me.Cu_ApbRevisa.TipoAsociacion = "BOD"
        Me.Cu_ApbRevisa.TipoBúsqueda = "P"
        '
        'Cu_ApbSolicita
        '
        Me.Cu_ApbSolicita.componenteasociado = "Cu_BuscarPersonaSolicita"
        Me.Cu_ApbSolicita.CrearUsuario = False
        Me.Cu_ApbSolicita.Location = New System.Drawing.Point(372, 4)
        Me.Cu_ApbSolicita.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_ApbSolicita.Name = "Cu_ApbSolicita"
        Me.Cu_ApbSolicita.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ApbSolicita.TabIndex = 2
        Me.Cu_ApbSolicita.Tag = "290"
        Me.Cu_ApbSolicita.TipoAsociacion = "BOD"
        Me.Cu_ApbSolicita.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaAutoriza
        '
        Me.Cu_BuscarPersonaAutoriza.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAutoriza.Location = New System.Drawing.Point(453, 5)
        Me.Cu_BuscarPersonaAutoriza.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_BuscarPersonaAutoriza.Name = "Cu_BuscarPersonaAutoriza"
        Me.Cu_BuscarPersonaAutoriza.Size = New System.Drawing.Size(316, 23)
        Me.Cu_BuscarPersonaAutoriza.TabIndex = 4
        Me.Cu_BuscarPersonaAutoriza.Tipo = "PUABO"
        Me.Cu_BuscarPersonaAutoriza.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaAprueba
        '
        Me.Cu_BuscarPersonaAprueba.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAprueba.Location = New System.Drawing.Point(453, 31)
        Me.Cu_BuscarPersonaAprueba.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_BuscarPersonaAprueba.Name = "Cu_BuscarPersonaAprueba"
        Me.Cu_BuscarPersonaAprueba.Size = New System.Drawing.Size(316, 23)
        Me.Cu_BuscarPersonaAprueba.TabIndex = 10
        Me.Cu_BuscarPersonaAprueba.Tipo = "PUABO"
        Me.Cu_BuscarPersonaAprueba.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaRevisa
        '
        Me.Cu_BuscarPersonaRevisa.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaRevisa.Location = New System.Drawing.Point(53, 29)
        Me.Cu_BuscarPersonaRevisa.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_BuscarPersonaRevisa.Name = "Cu_BuscarPersonaRevisa"
        Me.Cu_BuscarPersonaRevisa.Size = New System.Drawing.Size(316, 23)
        Me.Cu_BuscarPersonaRevisa.TabIndex = 7
        Me.Cu_BuscarPersonaRevisa.Tipo = "PUABO"
        Me.Cu_BuscarPersonaRevisa.valorcajatexto = "IDENTIFICACION"
        '
        'Fr_Requisicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 602)
        Me.Controls.Add(Me.Pn_ItemRequisición)
        Me.Controls.Add(Me.Pn_PersonasAsociadas)
        Me.Controls.Add(Me.Pn_Encabezado)
        Me.Controls.Add(Me.Pn_Botones)
        Me.MaximumSize = New System.Drawing.Size(820, 728)
        Me.MinimumSize = New System.Drawing.Size(820, 640)
        Me.Name = "Fr_Requisicion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Requisición"
        CType(Me.Dgv_ItemRequisicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Encabezado.ResumeLayout(False)
        Me.Pn_Encabezado.PerformLayout()
        Me.Pn_ItemRequisición.ResumeLayout(False)
        Me.Pn_TituloItemRequisición.ResumeLayout(False)
        Me.Pn_Botones.ResumeLayout(False)
        Me.Pn_Botones.PerformLayout()
        Me.Pn_PersonasAsociadas.ResumeLayout(False)
        Me.Pn_PersonasAsociadas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv_ItemRequisicion As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaAutoriza As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaAprueba As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BuscarPersonaRevisa As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Pn_Encabezado As System.Windows.Forms.Panel
    Friend WithEvents Pn_ItemRequisición As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents Lb_CódigoArtículo As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Pn_PersonasAsociadas As System.Windows.Forms.Panel
    Friend WithEvents Cu_ApbAprueba As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_ApbAutoriza As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_ApbRevisa As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_ApbSolicita As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Pn_TituloItemRequisición As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoPrioridad As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tb_Destino As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tb_Justificacion As System.Windows.Forms.TextBox
    Friend WithEvents Cb_TipoReq As System.Windows.Forms.ComboBox
    Friend WithEvents ESTADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AUTORIZADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents Tb_Origen As System.Windows.Forms.TextBox
    Public WithEvents Tb_Base As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoItem As System.Windows.Forms.ComboBox
    Friend WithEvents Ck_Stock As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_Incorporable As System.Windows.Forms.CheckBox
    Friend WithEvents Ll_ActualizarContacto As System.Windows.Forms.LinkLabel
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_AgregarActividad As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cb_Actividad As System.Windows.Forms.ComboBox
    Friend WithEvents Cu_BuscarPersonaSolicita As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Ck_RecGasto As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
    Friend WithEvents Cu_AsociarActivoFijo1 As FormulariosClasesBase.Cu_AsociarActivoFijo
    Friend WithEvents Bt_GestionarActividades As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Tb_Encabezado As System.Windows.Forms.TextBox
    Friend WithEvents NROITEMDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDARTICULODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ABREVIATURADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDESCRIPTIVODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADSOLICITADADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADEXISTENCIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOTIPOUNIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDITEMREQUISICIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NroItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_CodUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_ExistBodLocal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_ExistBodPrincipal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_AdqBodLocal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_AdqBodPrincipal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdItemRequisicion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AOT As FormulariosClasesBase.Cu_Asociar
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
