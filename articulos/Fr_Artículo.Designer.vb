<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Artículo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Artículo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tx_NombreCategoría = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tx_NombreArtículo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tx_DescripciónArtículo = New System.Windows.Forms.TextBox()
        Me.Tx_CódigoBarra = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Ck_Activo = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cb_TipoMedida = New System.Windows.Forms.ComboBox()
        Me.Cb_Unidad = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_CódigoArtículo = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Cb_IVA = New System.Windows.Forms.ComboBox()
        Me.Lb_Advertencia = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Dgv_Caracteristicas = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRECARACTERISTICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCIONCARACTERISTICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDTIPOCARACTERISTICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IRREPETIBLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lbl_Descripcion = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cb_SubtipoArticulo = New System.Windows.Forms.ComboBox()
        Me.Cb_TipoArticulo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Tb_NomSubtipo = New System.Windows.Forms.TextBox()
        Me.Tb_NomTipo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button_Sin_Imagen = New System.Windows.Forms.Button()
        Me.Bt_CargarFoto = New System.Windows.Forms.Button()
        Me.Pb_FotoArticulo = New System.Windows.Forms.PictureBox()
        Me.Tx_UsuarioModificaValorRef = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Tx_ValorReferencia = New System.Windows.Forms.TextBox()
        Me.MA_TIPOMEDIDATableAdapter1 = New DatosArticulos.Ds_ArtículosTableAdapters.MA_TIPOMEDIDATableAdapter()
        Me.MA_TIPOUNIDADTableAdapter1 = New DatosArticulos.Ds_ArtículosTableAdapters.MA_TIPOUNIDADTableAdapter()
        Me.Im_Defecto = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Dgv_Caracteristicas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.Pb_FotoArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Categoría:"
        '
        'Tx_NombreCategoría
        '
        Me.Tx_NombreCategoría.Location = New System.Drawing.Point(83, 7)
        Me.Tx_NombreCategoría.Multiline = True
        Me.Tx_NombreCategoría.Name = "Tx_NombreCategoría"
        Me.Tx_NombreCategoría.ReadOnly = True
        Me.Tx_NombreCategoría.Size = New System.Drawing.Size(430, 40)
        Me.Tx_NombreCategoría.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre:"
        '
        'Tx_NombreArtículo
        '
        Me.Tx_NombreArtículo.Location = New System.Drawing.Point(83, 53)
        Me.Tx_NombreArtículo.MaxLength = 50
        Me.Tx_NombreArtículo.Name = "Tx_NombreArtículo"
        Me.Tx_NombreArtículo.Size = New System.Drawing.Size(430, 20)
        Me.Tx_NombreArtículo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Descripción:"
        '
        'Tx_DescripciónArtículo
        '
        Me.Tx_DescripciónArtículo.Location = New System.Drawing.Point(83, 79)
        Me.Tx_DescripciónArtículo.MaxLength = 200
        Me.Tx_DescripciónArtículo.Multiline = True
        Me.Tx_DescripciónArtículo.Name = "Tx_DescripciónArtículo"
        Me.Tx_DescripciónArtículo.Size = New System.Drawing.Size(430, 60)
        Me.Tx_DescripciónArtículo.TabIndex = 5
        '
        'Tx_CódigoBarra
        '
        Me.Tx_CódigoBarra.Location = New System.Drawing.Point(83, 145)
        Me.Tx_CódigoBarra.MaxLength = 100
        Me.Tx_CódigoBarra.Name = "Tx_CódigoBarra"
        Me.Tx_CódigoBarra.Size = New System.Drawing.Size(161, 20)
        Me.Tx_CódigoBarra.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Código Barras:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Tarifa IVA%:"
        '
        'Ck_Activo
        '
        Me.Ck_Activo.AutoSize = True
        Me.Ck_Activo.Checked = True
        Me.Ck_Activo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_Activo.Location = New System.Drawing.Point(83, 171)
        Me.Ck_Activo.Name = "Ck_Activo"
        Me.Ck_Activo.Size = New System.Drawing.Size(146, 17)
        Me.Ck_Activo.TabIndex = 10
        Me.Ck_Activo.Tag = "844"
        Me.Ck_Activo.Text = "Artículo en estado Activo"
        Me.Ck_Activo.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(274, 172)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Tipo de Medida:"
        '
        'Cb_TipoMedida
        '
        Me.Cb_TipoMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoMedida.FormattingEnabled = True
        Me.Cb_TipoMedida.Location = New System.Drawing.Point(360, 169)
        Me.Cb_TipoMedida.Name = "Cb_TipoMedida"
        Me.Cb_TipoMedida.Size = New System.Drawing.Size(132, 21)
        Me.Cb_TipoMedida.TabIndex = 12
        '
        'Cb_Unidad
        '
        Me.Cb_Unidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Unidad.FormattingEnabled = True
        Me.Cb_Unidad.Location = New System.Drawing.Point(543, 169)
        Me.Cb_Unidad.Name = "Cb_Unidad"
        Me.Cb_Unidad.Size = New System.Drawing.Size(136, 21)
        Me.Cb_Unidad.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(497, 172)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Unidad:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lb_CódigoArtículo)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 572)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(692, 30)
        Me.Panel1.TabIndex = 2
        '
        'Lb_CódigoArtículo
        '
        Me.Lb_CódigoArtículo.AutoSize = True
        Me.Lb_CódigoArtículo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CódigoArtículo.ForeColor = System.Drawing.Color.Red
        Me.Lb_CódigoArtículo.Location = New System.Drawing.Point(11, 8)
        Me.Lb_CódigoArtículo.Name = "Lb_CódigoArtículo"
        Me.Lb_CódigoArtículo.Size = New System.Drawing.Size(52, 13)
        Me.Lb_CódigoArtículo.TabIndex = 2
        Me.Lb_CódigoArtículo.Text = "Label13"
        Me.Lb_CódigoArtículo.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(531, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(612, 2)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Cb_IVA
        '
        Me.Cb_IVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_IVA.FormattingEnabled = True
        Me.Cb_IVA.Items.AddRange(New Object() {"0", "5", "16", "19"})
        Me.Cb_IVA.Location = New System.Drawing.Point(83, 196)
        Me.Cb_IVA.Name = "Cb_IVA"
        Me.Cb_IVA.Size = New System.Drawing.Size(52, 21)
        Me.Cb_IVA.TabIndex = 16
        '
        'Lb_Advertencia
        '
        Me.Lb_Advertencia.AutoSize = True
        Me.Lb_Advertencia.ForeColor = System.Drawing.Color.Red
        Me.Lb_Advertencia.Location = New System.Drawing.Point(36, 74)
        Me.Lb_Advertencia.Name = "Lb_Advertencia"
        Me.Lb_Advertencia.Size = New System.Drawing.Size(606, 26)
        Me.Lb_Advertencia.TabIndex = 7
        Me.Lb_Advertencia.Text = resources.GetString("Lb_Advertencia.Text")
        Me.Lb_Advertencia.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Lb_Advertencia.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 119)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(690, 221)
        Me.Panel2.TabIndex = 9
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Dgv_Caracteristicas)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Lbl_Descripcion)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer1.Size = New System.Drawing.Size(686, 217)
        Me.SplitContainer1.SplitterDistance = 163
        Me.SplitContainer1.TabIndex = 0
        '
        'Dgv_Caracteristicas
        '
        Me.Dgv_Caracteristicas.AllowUserToAddRows = False
        Me.Dgv_Caracteristicas.AllowUserToDeleteRows = False
        Me.Dgv_Caracteristicas.AllowUserToOrderColumns = True
        Me.Dgv_Caracteristicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Caracteristicas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.NOMBRECARACTERISTICA, Me.TIPO, Me.DESCRIPCIONCARACTERISTICA, Me.IDTIPOCARACTERISTICA, Me.VALOR, Me.IRREPETIBLE})
        Me.Dgv_Caracteristicas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Caracteristicas.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Caracteristicas.MultiSelect = False
        Me.Dgv_Caracteristicas.Name = "Dgv_Caracteristicas"
        Me.Dgv_Caracteristicas.ReadOnly = True
        Me.Dgv_Caracteristicas.RowHeadersVisible = False
        Me.Dgv_Caracteristicas.Size = New System.Drawing.Size(682, 159)
        Me.Dgv_Caracteristicas.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "IDCARACTERISTICASLISTA"
        Me.Column1.HeaderText = "IDCARACTERISTICASLISTA"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'NOMBRECARACTERISTICA
        '
        Me.NOMBRECARACTERISTICA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NOMBRECARACTERISTICA.DataPropertyName = "CARACTERISTICA"
        Me.NOMBRECARACTERISTICA.HeaderText = "CARACTERISTICA"
        Me.NOMBRECARACTERISTICA.Name = "NOMBRECARACTERISTICA"
        Me.NOMBRECARACTERISTICA.ReadOnly = True
        '
        'TIPO
        '
        Me.TIPO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TIPO.DataPropertyName = "TIPO"
        Me.TIPO.HeaderText = "TIPO DE VALOR"
        Me.TIPO.Name = "TIPO"
        Me.TIPO.ReadOnly = True
        Me.TIPO.Width = 105
        '
        'DESCRIPCIONCARACTERISTICA
        '
        Me.DESCRIPCIONCARACTERISTICA.DataPropertyName = "DESCRIPCIONCARACTERISTICA"
        Me.DESCRIPCIONCARACTERISTICA.HeaderText = "DESCRIPCION"
        Me.DESCRIPCIONCARACTERISTICA.Name = "DESCRIPCIONCARACTERISTICA"
        Me.DESCRIPCIONCARACTERISTICA.ReadOnly = True
        Me.DESCRIPCIONCARACTERISTICA.Visible = False
        '
        'IDTIPOCARACTERISTICA
        '
        Me.IDTIPOCARACTERISTICA.DataPropertyName = "IDTIPOCARACTERISTICA"
        Me.IDTIPOCARACTERISTICA.HeaderText = "TIPOVALOR"
        Me.IDTIPOCARACTERISTICA.Name = "IDTIPOCARACTERISTICA"
        Me.IDTIPOCARACTERISTICA.ReadOnly = True
        Me.IDTIPOCARACTERISTICA.Visible = False
        '
        'VALOR
        '
        Me.VALOR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.VALOR.HeaderText = "VALOR"
        Me.VALOR.Name = "VALOR"
        Me.VALOR.ReadOnly = True
        Me.VALOR.Visible = False
        '
        'IRREPETIBLE
        '
        Me.IRREPETIBLE.DataPropertyName = "IRREPETIBLE"
        Me.IRREPETIBLE.HeaderText = "IRREPETIBLE?"
        Me.IRREPETIBLE.Name = "IRREPETIBLE"
        Me.IRREPETIBLE.ReadOnly = True
        '
        'Lbl_Descripcion
        '
        Me.Lbl_Descripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_Descripcion.Location = New System.Drawing.Point(0, 13)
        Me.Lbl_Descripcion.Name = "Lbl_Descripcion"
        Me.Lbl_Descripcion.Size = New System.Drawing.Size(682, 33)
        Me.Lbl_Descripcion.TabIndex = 1
        Me.Lbl_Descripcion.Text = "PROPIEDAD ASOCIADA"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Descripción:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Características Adicionales"
        '
        'Cb_SubtipoArticulo
        '
        Me.Cb_SubtipoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_SubtipoArticulo.FormattingEnabled = True
        Me.Cb_SubtipoArticulo.Location = New System.Drawing.Point(113, 49)
        Me.Cb_SubtipoArticulo.Name = "Cb_SubtipoArticulo"
        Me.Cb_SubtipoArticulo.Size = New System.Drawing.Size(493, 21)
        Me.Cb_SubtipoArticulo.TabIndex = 5
        '
        'Cb_TipoArticulo
        '
        Me.Cb_TipoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoArticulo.FormattingEnabled = True
        Me.Cb_TipoArticulo.Location = New System.Drawing.Point(113, 23)
        Me.Cb_TipoArticulo.Name = "Cb_TipoArticulo"
        Me.Cb_TipoArticulo.Size = New System.Drawing.Size(493, 21)
        Me.Cb_TipoArticulo.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Subtipo de Artículo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Tipo de Artículo"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDCARACTERISTICASLISTA"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDCARACTERISTICASLISTA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CARACTERISTICA"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CARACTERISTICA"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "TIPO"
        Me.DataGridViewTextBoxColumn3.HeaderText = "TIPO DE VALOR"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DESCRIPCIONCARACTERISTICA"
        Me.DataGridViewTextBoxColumn4.HeaderText = "DESCRIPCION"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "IDTIPOCARACTERISTICA"
        Me.DataGridViewTextBoxColumn5.HeaderText = "TIPOVALOR"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = "VALOR"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Tb_NomSubtipo)
        Me.Panel3.Controls.Add(Me.Tb_NomTipo)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Lb_Advertencia)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Cb_TipoArticulo)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Cb_SubtipoArticulo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 230)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(692, 342)
        Me.Panel3.TabIndex = 1
        '
        'Tb_NomSubtipo
        '
        Me.Tb_NomSubtipo.Location = New System.Drawing.Point(612, 49)
        Me.Tb_NomSubtipo.Name = "Tb_NomSubtipo"
        Me.Tb_NomSubtipo.ReadOnly = True
        Me.Tb_NomSubtipo.Size = New System.Drawing.Size(74, 20)
        Me.Tb_NomSubtipo.TabIndex = 6
        '
        'Tb_NomTipo
        '
        Me.Tb_NomTipo.Location = New System.Drawing.Point(612, 23)
        Me.Tb_NomTipo.Name = "Tb_NomTipo"
        Me.Tb_NomTipo.ReadOnly = True
        Me.Tb_NomTipo.Size = New System.Drawing.Size(74, 20)
        Me.Tb_NomTipo.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Info
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(690, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Para Uso de Control de Equipos y Activos Fijos"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Button_Sin_Imagen)
        Me.Panel4.Controls.Add(Me.Bt_CargarFoto)
        Me.Panel4.Controls.Add(Me.Pb_FotoArticulo)
        Me.Panel4.Controls.Add(Me.Tx_UsuarioModificaValorRef)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Tx_ValorReferencia)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Tx_NombreCategoría)
        Me.Panel4.Controls.Add(Me.Cb_IVA)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Tx_NombreArtículo)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Tx_DescripciónArtículo)
        Me.Panel4.Controls.Add(Me.Cb_Unidad)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Tx_CódigoBarra)
        Me.Panel4.Controls.Add(Me.Cb_TipoMedida)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Ck_Activo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(692, 230)
        Me.Panel4.TabIndex = 0
        '
        'Button_Sin_Imagen
        '
        Me.Button_Sin_Imagen.Location = New System.Drawing.Point(604, 133)
        Me.Button_Sin_Imagen.Name = "Button_Sin_Imagen"
        Me.Button_Sin_Imagen.Size = New System.Drawing.Size(75, 23)
        Me.Button_Sin_Imagen.TabIndex = 36
        Me.Button_Sin_Imagen.Text = "Sin Imagen"
        Me.Button_Sin_Imagen.UseVisualStyleBackColor = True
        '
        'Bt_CargarFoto
        '
        Me.Bt_CargarFoto.Location = New System.Drawing.Point(519, 133)
        Me.Bt_CargarFoto.Name = "Bt_CargarFoto"
        Me.Bt_CargarFoto.Size = New System.Drawing.Size(75, 23)
        Me.Bt_CargarFoto.TabIndex = 21
        Me.Bt_CargarFoto.Tag = "556"
        Me.Bt_CargarFoto.Text = "Cargar Foto"
        Me.Bt_CargarFoto.UseVisualStyleBackColor = True
        '
        'Pb_FotoArticulo
        '
        Me.Pb_FotoArticulo.BackColor = System.Drawing.Color.White
        Me.Pb_FotoArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pb_FotoArticulo.Image = CType(resources.GetObject("Pb_FotoArticulo.Image"), System.Drawing.Image)
        Me.Pb_FotoArticulo.Location = New System.Drawing.Point(519, 7)
        Me.Pb_FotoArticulo.Name = "Pb_FotoArticulo"
        Me.Pb_FotoArticulo.Size = New System.Drawing.Size(160, 120)
        Me.Pb_FotoArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pb_FotoArticulo.TabIndex = 34
        Me.Pb_FotoArticulo.TabStop = False
        '
        'Tx_UsuarioModificaValorRef
        '
        Me.Tx_UsuarioModificaValorRef.Enabled = False
        Me.Tx_UsuarioModificaValorRef.Location = New System.Drawing.Point(502, 196)
        Me.Tx_UsuarioModificaValorRef.Name = "Tx_UsuarioModificaValorRef"
        Me.Tx_UsuarioModificaValorRef.ReadOnly = True
        Me.Tx_UsuarioModificaValorRef.Size = New System.Drawing.Size(177, 20)
        Me.Tx_UsuarioModificaValorRef.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(420, 199)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Modificado por:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(154, 199)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Valor de Referencia:"
        '
        'Tx_ValorReferencia
        '
        Me.Tx_ValorReferencia.Location = New System.Drawing.Point(260, 196)
        Me.Tx_ValorReferencia.MaxLength = 16
        Me.Tx_ValorReferencia.Name = "Tx_ValorReferencia"
        Me.Tx_ValorReferencia.Size = New System.Drawing.Size(137, 20)
        Me.Tx_ValorReferencia.TabIndex = 18
        '
        'MA_TIPOMEDIDATableAdapter1
        '
        Me.MA_TIPOMEDIDATableAdapter1.ClearBeforeFill = True
        '
        'MA_TIPOUNIDADTableAdapter1
        '
        Me.MA_TIPOUNIDADTableAdapter1.ClearBeforeFill = True
        '
        'Im_Defecto
        '
        Me.Im_Defecto.ImageStream = CType(resources.GetObject("Im_Defecto.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Im_Defecto.TransparentColor = System.Drawing.Color.Transparent
        Me.Im_Defecto.Images.SetKeyName(0, "defecto.jpg")
        '
        'Fr_Artículo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 602)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Fr_Artículo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Artículo"
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.Panel2.ResumeLayout(false)
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        Me.SplitContainer1.Panel2.PerformLayout
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.Dgv_Caracteristicas,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.Panel4.ResumeLayout(false)
        Me.Panel4.PerformLayout
        CType(Me.Pb_FotoArticulo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tx_NombreCategoría As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tx_NombreArtículo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tx_DescripciónArtículo As System.Windows.Forms.TextBox
    Friend WithEvents Tx_CódigoBarra As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Ck_Activo As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoMedida As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_Unidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lb_CódigoArtículo As System.Windows.Forms.Label
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents MA_TIPOMEDIDATableAdapter1 As DatosArticulos.Ds_ArtículosTableAdapters.MA_TIPOMEDIDATableAdapter
    Friend WithEvents MA_TIPOUNIDADTableAdapter1 As DatosArticulos.Ds_ArtículosTableAdapters.MA_TIPOUNIDADTableAdapter
    Friend WithEvents Cb_IVA As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Advertencia As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Dgv_Caracteristicas As System.Windows.Forms.DataGridView
    Friend WithEvents Lbl_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cb_SubtipoArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_TipoArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Tb_NomSubtipo As System.Windows.Forms.TextBox
    Friend WithEvents Tb_NomTipo As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRECARACTERISTICA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCIONCARACTERISTICA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDTIPOCARACTERISTICA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IRREPETIBLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Tx_ValorReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Tx_UsuarioModificaValorRef As System.Windows.Forms.TextBox
    Friend WithEvents Pb_FotoArticulo As System.Windows.Forms.PictureBox
    Friend WithEvents Bt_CargarFoto As System.Windows.Forms.Button
    Friend WithEvents Button_Sin_Imagen As System.Windows.Forms.Button
    Friend WithEvents Im_Defecto As System.Windows.Forms.ImageList
End Class
