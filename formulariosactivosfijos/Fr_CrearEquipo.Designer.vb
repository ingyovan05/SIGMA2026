<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_CrearEquipo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cb_TipoArticulo = New System.Windows.Forms.ComboBox()
        Me.Cb_SubtipoArticulo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Tb_CodigoMecanico = New System.Windows.Forms.TextBox()
        Me.Tb_CodigoIsmocol = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Bt_AgregarModeloEquipo = New System.Windows.Forms.Button()
        Me.Tb_CodigoAccess = New System.Windows.Forms.TextBox()
        Me.Cb_ModeloEquipo = New System.Windows.Forms.ComboBox()
        Me.Bt_AgregarMarcaEquipo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Cb_MarcaEquipo = New System.Windows.Forms.ComboBox()
        Me.Tt_info = New System.Windows.Forms.ToolTip(Me.components)
        Me.Tb_CodigoArticulo = New System.Windows.Forms.TextBox()
        Me.Lb_BodIng = New System.Windows.Forms.Label()
        Me.Cb_BodegaIngreso = New System.Windows.Forms.ComboBox()
        Me.Lb_PerRec = New System.Windows.Forms.Label()
        Me.Tb_NomenclaturaProveedor = New System.Windows.Forms.TextBox()
        Me.Cbx_Componente = New System.Windows.Forms.CheckBox()
        Me.Btn_Articulo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Dgv_Caracteristicas = New System.Windows.Forms.DataGridView()
        Me.IDCARACTERISTICASLISTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRECARACTERISTICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCIONCARACTERISTICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDTIPOCARACTERISTICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IRREPETIBLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lbl_Descripcion = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Gb_Articulo = New System.Windows.Forms.GroupBox()
        Me.Bt_VerifiCons = New System.Windows.Forms.Button()
        Me.Tx_Consecutivo = New System.Windows.Forms.TextBox()
        Me.Lb_Consecutivo = New System.Windows.Forms.Label()
        Me.Tb_NombreArticulo = New System.Windows.Forms.TextBox()
        Me.Lb_infoproveedor = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Tb_DescripcionAdicional = New System.Windows.Forms.TextBox()
        Me.Lb_asignadaInfo = New System.Windows.Forms.Label()
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Lb_FecIng = New System.Windows.Forms.Label()
        Me.Dtp_FechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.Tx_Identificación = New System.Windows.Forms.TextBox()
        Me.Btn_BuscarProveedor = New System.Windows.Forms.Button()
        Me.Tx_NombreProveedor = New System.Windows.Forms.TextBox()
        Me.Tx_DigVerificación = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Cb_componente = New System.Windows.Forms.ComboBox()
        Me.Cu_BuscarPersonaIngreso = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaAsignada = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Dgv_Caracteristicas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gb_Articulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo de Articulo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Subtipo de Articulo"
        '
        'Cb_TipoArticulo
        '
        Me.Cb_TipoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoArticulo.FormattingEnabled = True
        Me.Cb_TipoArticulo.Location = New System.Drawing.Point(116, 40)
        Me.Cb_TipoArticulo.Name = "Cb_TipoArticulo"
        Me.Cb_TipoArticulo.Size = New System.Drawing.Size(181, 21)
        Me.Cb_TipoArticulo.TabIndex = 1
        '
        'Cb_SubtipoArticulo
        '
        Me.Cb_SubtipoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_SubtipoArticulo.FormattingEnabled = True
        Me.Cb_SubtipoArticulo.Location = New System.Drawing.Point(116, 67)
        Me.Cb_SubtipoArticulo.Name = "Cb_SubtipoArticulo"
        Me.Cb_SubtipoArticulo.Size = New System.Drawing.Size(181, 21)
        Me.Cb_SubtipoArticulo.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tb_CodigoMecanico)
        Me.GroupBox1.Controls.Add(Me.Tb_CodigoIsmocol)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Bt_AgregarModeloEquipo)
        Me.GroupBox1.Controls.Add(Me.Tb_CodigoAccess)
        Me.GroupBox1.Controls.Add(Me.Cb_ModeloEquipo)
        Me.GroupBox1.Controls.Add(Me.Bt_AgregarMarcaEquipo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Cb_MarcaEquipo)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(299, 153)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Otros Códigos, llenelos solo si aplican"
        '
        'Tb_CodigoMecanico
        '
        Me.Tb_CodigoMecanico.Location = New System.Drawing.Point(108, 71)
        Me.Tb_CodigoMecanico.Name = "Tb_CodigoMecanico"
        Me.Tb_CodigoMecanico.Size = New System.Drawing.Size(185, 20)
        Me.Tb_CodigoMecanico.TabIndex = 5
        Me.Tt_info.SetToolTip(Me.Tb_CodigoMecanico, "Codigo del sistema Access, campo opcional")
        '
        'Tb_CodigoIsmocol
        '
        Me.Tb_CodigoIsmocol.Location = New System.Drawing.Point(108, 47)
        Me.Tb_CodigoIsmocol.Name = "Tb_CodigoIsmocol"
        Me.Tb_CodigoIsmocol.Size = New System.Drawing.Size(185, 20)
        Me.Tb_CodigoIsmocol.TabIndex = 3
        Me.Tt_info.SetToolTip(Me.Tb_CodigoIsmocol, "Codigo del sistema Access, campo opcional")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Código mecánico"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Código Contable"
        '
        'Bt_AgregarModeloEquipo
        '
        Me.Bt_AgregarModeloEquipo.Location = New System.Drawing.Point(269, 123)
        Me.Bt_AgregarModeloEquipo.Name = "Bt_AgregarModeloEquipo"
        Me.Bt_AgregarModeloEquipo.Size = New System.Drawing.Size(24, 23)
        Me.Bt_AgregarModeloEquipo.TabIndex = 14
        Me.Bt_AgregarModeloEquipo.Text = "..."
        Me.Bt_AgregarModeloEquipo.UseVisualStyleBackColor = True
        '
        'Tb_CodigoAccess
        '
        Me.Tb_CodigoAccess.Location = New System.Drawing.Point(108, 23)
        Me.Tb_CodigoAccess.Name = "Tb_CodigoAccess"
        Me.Tb_CodigoAccess.Size = New System.Drawing.Size(185, 20)
        Me.Tb_CodigoAccess.TabIndex = 1
        Me.Tt_info.SetToolTip(Me.Tb_CodigoAccess, "Codigo del sistema Access, campo opcional")
        '
        'Cb_ModeloEquipo
        '
        Me.Cb_ModeloEquipo.DisplayMember = "NOMBRETIPOMODELO"
        Me.Cb_ModeloEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_ModeloEquipo.FormattingEnabled = True
        Me.Cb_ModeloEquipo.Location = New System.Drawing.Point(108, 123)
        Me.Cb_ModeloEquipo.Name = "Cb_ModeloEquipo"
        Me.Cb_ModeloEquipo.Size = New System.Drawing.Size(158, 21)
        Me.Cb_ModeloEquipo.TabIndex = 13
        Me.Cb_ModeloEquipo.ValueMember = "CODIGOTIPOMODELO"
        '
        'Bt_AgregarMarcaEquipo
        '
        Me.Bt_AgregarMarcaEquipo.Location = New System.Drawing.Point(269, 96)
        Me.Bt_AgregarMarcaEquipo.Name = "Bt_AgregarMarcaEquipo"
        Me.Bt_AgregarMarcaEquipo.Size = New System.Drawing.Size(24, 23)
        Me.Bt_AgregarMarcaEquipo.TabIndex = 11
        Me.Bt_AgregarMarcaEquipo.Text = "..."
        Me.Bt_AgregarMarcaEquipo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Modelo Equipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Código Access"
        Me.Tt_info.SetToolTip(Me.Label3, "Codigo del sistema Access, campo opcional")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Marca Equipo"
        '
        'Cb_MarcaEquipo
        '
        Me.Cb_MarcaEquipo.DisplayMember = "NOMBRETIPOMARCA"
        Me.Cb_MarcaEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_MarcaEquipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cb_MarcaEquipo.Location = New System.Drawing.Point(108, 97)
        Me.Cb_MarcaEquipo.Name = "Cb_MarcaEquipo"
        Me.Cb_MarcaEquipo.Size = New System.Drawing.Size(158, 21)
        Me.Cb_MarcaEquipo.TabIndex = 1
        Me.Cb_MarcaEquipo.ValueMember = "CODIGOTIPOMARCA"
        '
        'Tb_CodigoArticulo
        '
        Me.Tb_CodigoArticulo.Location = New System.Drawing.Point(9, 95)
        Me.Tb_CodigoArticulo.Name = "Tb_CodigoArticulo"
        Me.Tb_CodigoArticulo.Size = New System.Drawing.Size(101, 20)
        Me.Tb_CodigoArticulo.TabIndex = 5
        Me.Tt_info.SetToolTip(Me.Tb_CodigoArticulo, "Puede simplemente escribir el Código del articulo")
        '
        'Lb_BodIng
        '
        Me.Lb_BodIng.AutoSize = True
        Me.Lb_BodIng.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lb_BodIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_BodIng.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lb_BodIng.Location = New System.Drawing.Point(18, 201)
        Me.Lb_BodIng.Name = "Lb_BodIng"
        Me.Lb_BodIng.Size = New System.Drawing.Size(97, 13)
        Me.Lb_BodIng.TabIndex = 19
        Me.Lb_BodIng.Text = "Bodega de Ingreso"
        Me.Tt_info.SetToolTip(Me.Lb_BodIng, "Persona que recibio el equipo por primera vez")
        '
        'Cb_BodegaIngreso
        '
        Me.Cb_BodegaIngreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_BodegaIngreso.FormattingEnabled = True
        Me.Cb_BodegaIngreso.Location = New System.Drawing.Point(124, 196)
        Me.Cb_BodegaIngreso.Name = "Cb_BodegaIngreso"
        Me.Cb_BodegaIngreso.Size = New System.Drawing.Size(250, 21)
        Me.Cb_BodegaIngreso.TabIndex = 19
        Me.Tt_info.SetToolTip(Me.Cb_BodegaIngreso, "Bodega en la que se recibio el quipo por primera vez")
        '
        'Lb_PerRec
        '
        Me.Lb_PerRec.AutoSize = True
        Me.Lb_PerRec.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lb_PerRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_PerRec.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lb_PerRec.Location = New System.Drawing.Point(32, 226)
        Me.Lb_PerRec.Name = "Lb_PerRec"
        Me.Lb_PerRec.Size = New System.Drawing.Size(83, 13)
        Me.Lb_PerRec.TabIndex = 23
        Me.Lb_PerRec.Text = "Persona Recibe"
        Me.Tt_info.SetToolTip(Me.Lb_PerRec, "persona que recibio el equipo por primera vez")
        '
        'Tb_NomenclaturaProveedor
        '
        Me.Tb_NomenclaturaProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tb_NomenclaturaProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_NomenclaturaProveedor.Location = New System.Drawing.Point(318, 172)
        Me.Tb_NomenclaturaProveedor.MaxLength = 3
        Me.Tb_NomenclaturaProveedor.Name = "Tb_NomenclaturaProveedor"
        Me.Tb_NomenclaturaProveedor.ReadOnly = True
        Me.Tb_NomenclaturaProveedor.Size = New System.Drawing.Size(48, 20)
        Me.Tb_NomenclaturaProveedor.TabIndex = 7
        Me.Tb_NomenclaturaProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Tt_info.SetToolTip(Me.Tb_NomenclaturaProveedor, "Nomenclatura de Proveedor")
        '
        'Cbx_Componente
        '
        Me.Cbx_Componente.AutoSize = True
        Me.Cbx_Componente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cbx_Componente.Location = New System.Drawing.Point(12, 531)
        Me.Cbx_Componente.Name = "Cbx_Componente"
        Me.Cbx_Componente.Size = New System.Drawing.Size(181, 17)
        Me.Cbx_Componente.TabIndex = 31
        Me.Cbx_Componente.Text = "Es Componente de Otro Equipo?"
        Me.Tt_info.SetToolTip(Me.Cbx_Componente, "Si es componente de otro equipo marque esta casilla")
        Me.Cbx_Componente.UseVisualStyleBackColor = True
        '
        'Btn_Articulo
        '
        Me.Btn_Articulo.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_Articulo.Location = New System.Drawing.Point(303, 36)
        Me.Btn_Articulo.Name = "Btn_Articulo"
        Me.Btn_Articulo.Size = New System.Drawing.Size(82, 51)
        Me.Btn_Articulo.TabIndex = 4
        Me.Btn_Articulo.Text = "Seleccionar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Articulo"
        Me.Btn_Articulo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Location = New System.Drawing.Point(13, 290)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(703, 177)
        Me.Panel1.TabIndex = 28
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer1.Size = New System.Drawing.Size(699, 173)
        Me.SplitContainer1.SplitterDistance = 134
        Me.SplitContainer1.TabIndex = 0
        '
        'Dgv_Caracteristicas
        '
        Me.Dgv_Caracteristicas.AllowUserToAddRows = False
        Me.Dgv_Caracteristicas.AllowUserToDeleteRows = False
        Me.Dgv_Caracteristicas.AllowUserToOrderColumns = True
        Me.Dgv_Caracteristicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Caracteristicas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDCARACTERISTICASLISTA, Me.NOMBRECARACTERISTICA, Me.TIPO, Me.DESCRIPCIONCARACTERISTICA, Me.IDTIPOCARACTERISTICA, Me.VALOR, Me.IRREPETIBLE})
        Me.Dgv_Caracteristicas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Caracteristicas.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Caracteristicas.MultiSelect = False
        Me.Dgv_Caracteristicas.Name = "Dgv_Caracteristicas"
        Me.Dgv_Caracteristicas.RowHeadersVisible = False
        Me.Dgv_Caracteristicas.Size = New System.Drawing.Size(695, 130)
        Me.Dgv_Caracteristicas.TabIndex = 0
        '
        'IDCARACTERISTICASLISTA
        '
        Me.IDCARACTERISTICASLISTA.DataPropertyName = "IDCARACTERISTICA"
        Me.IDCARACTERISTICASLISTA.HeaderText = "IDCARACTERISTICASLISTA"
        Me.IDCARACTERISTICASLISTA.Name = "IDCARACTERISTICASLISTA"
        Me.IDCARACTERISTICASLISTA.ReadOnly = True
        Me.IDCARACTERISTICASLISTA.Visible = False
        '
        'NOMBRECARACTERISTICA
        '
        Me.NOMBRECARACTERISTICA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NOMBRECARACTERISTICA.DataPropertyName = "NOMBRECARACTERISTICA"
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
        '
        'IRREPETIBLE
        '
        Me.IRREPETIBLE.DataPropertyName = "IRREPETIBLE"
        Me.IRREPETIBLE.HeaderText = "IRREPETIBLE"
        Me.IRREPETIBLE.Name = "IRREPETIBLE"
        Me.IRREPETIBLE.ReadOnly = True
        '
        'Lbl_Descripcion
        '
        Me.Lbl_Descripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_Descripcion.Location = New System.Drawing.Point(0, 13)
        Me.Lbl_Descripcion.Name = "Lbl_Descripcion"
        Me.Lbl_Descripcion.Size = New System.Drawing.Size(695, 18)
        Me.Lbl_Descripcion.TabIndex = 2
        Me.Lbl_Descripcion.Text = "PROPIEDAD ASOCIADA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Descripcion:"
        '
        'Gb_Articulo
        '
        Me.Gb_Articulo.Controls.Add(Me.Bt_VerifiCons)
        Me.Gb_Articulo.Controls.Add(Me.Tx_Consecutivo)
        Me.Gb_Articulo.Controls.Add(Me.Lb_Consecutivo)
        Me.Gb_Articulo.Controls.Add(Me.Tb_NombreArticulo)
        Me.Gb_Articulo.Controls.Add(Me.Btn_Articulo)
        Me.Gb_Articulo.Controls.Add(Me.Label1)
        Me.Gb_Articulo.Controls.Add(Me.Label2)
        Me.Gb_Articulo.Controls.Add(Me.Cb_TipoArticulo)
        Me.Gb_Articulo.Controls.Add(Me.Cb_SubtipoArticulo)
        Me.Gb_Articulo.Controls.Add(Me.Tb_CodigoArticulo)
        Me.Gb_Articulo.Location = New System.Drawing.Point(321, 12)
        Me.Gb_Articulo.Name = "Gb_Articulo"
        Me.Gb_Articulo.Size = New System.Drawing.Size(394, 153)
        Me.Gb_Articulo.TabIndex = 1
        Me.Gb_Articulo.TabStop = False
        Me.Gb_Articulo.Text = "Seleccione el Tipo y el Subtipo del Articulo o escriba el Codigo correspondiente " & _
    "al Subtipo en la caja de texto"
        '
        'Bt_VerifiCons
        '
        Me.Bt_VerifiCons.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_VerifiCons.ForeColor = System.Drawing.Color.OrangeRed
        Me.Bt_VerifiCons.Location = New System.Drawing.Point(227, 121)
        Me.Bt_VerifiCons.Name = "Bt_VerifiCons"
        Me.Bt_VerifiCons.Size = New System.Drawing.Size(158, 23)
        Me.Bt_VerifiCons.TabIndex = 9
        Me.Bt_VerifiCons.Text = "Verificar Consecutivo"
        Me.Bt_VerifiCons.UseVisualStyleBackColor = True
        '
        'Tx_Consecutivo
        '
        Me.Tx_Consecutivo.Location = New System.Drawing.Point(133, 123)
        Me.Tx_Consecutivo.MaxLength = 5
        Me.Tx_Consecutivo.Name = "Tx_Consecutivo"
        Me.Tx_Consecutivo.Size = New System.Drawing.Size(88, 20)
        Me.Tx_Consecutivo.TabIndex = 8
        '
        'Lb_Consecutivo
        '
        Me.Lb_Consecutivo.AutoSize = True
        Me.Lb_Consecutivo.Location = New System.Drawing.Point(6, 126)
        Me.Lb_Consecutivo.Name = "Lb_Consecutivo"
        Me.Lb_Consecutivo.Size = New System.Drawing.Size(121, 13)
        Me.Lb_Consecutivo.TabIndex = 7
        Me.Lb_Consecutivo.Text = "Número de Consecutivo"
        '
        'Tb_NombreArticulo
        '
        Me.Tb_NombreArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_NombreArticulo.Location = New System.Drawing.Point(116, 95)
        Me.Tb_NombreArticulo.Name = "Tb_NombreArticulo"
        Me.Tb_NombreArticulo.ReadOnly = True
        Me.Tb_NombreArticulo.Size = New System.Drawing.Size(269, 20)
        Me.Tb_NombreArticulo.TabIndex = 6
        Me.Tb_NombreArticulo.Text = "Código Articulo"
        '
        'Lb_infoproveedor
        '
        Me.Lb_infoproveedor.AutoSize = True
        Me.Lb_infoproveedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lb_infoproveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_infoproveedor.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lb_infoproveedor.Location = New System.Drawing.Point(16, 174)
        Me.Lb_infoproveedor.Name = "Lb_infoproveedor"
        Me.Lb_infoproveedor.Size = New System.Drawing.Size(56, 13)
        Me.Lb_infoproveedor.TabIndex = 2
        Me.Lb_infoproveedor.Text = "Proveedor"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 274)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Caracteristicas Adicionales"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 470)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Descripción Adicional"
        '
        'Tb_DescripcionAdicional
        '
        Me.Tb_DescripcionAdicional.Location = New System.Drawing.Point(14, 487)
        Me.Tb_DescripcionAdicional.Multiline = True
        Me.Tb_DescripcionAdicional.Name = "Tb_DescripcionAdicional"
        Me.Tb_DescripcionAdicional.Size = New System.Drawing.Size(695, 38)
        Me.Tb_DescripcionAdicional.TabIndex = 30
        '
        'Lb_asignadaInfo
        '
        Me.Lb_asignadaInfo.AutoSize = True
        Me.Lb_asignadaInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lb_asignadaInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_asignadaInfo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lb_asignadaInfo.Location = New System.Drawing.Point(22, 251)
        Me.Lb_asignadaInfo.Name = "Lb_asignadaInfo"
        Me.Lb_asignadaInfo.Size = New System.Drawing.Size(93, 13)
        Me.Lb_asignadaInfo.TabIndex = 25
        Me.Lb_asignadaInfo.Text = "Persona Asignada"
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Btn_Guardar.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_Guardar.Location = New System.Drawing.Point(290, 555)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Guardar.TabIndex = 33
        Me.Btn_Guardar.Text = "Guardar"
        Me.Btn_Guardar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.Btn_Cancelar.Location = New System.Drawing.Point(373, 555)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cancelar.TabIndex = 34
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Lb_FecIng
        '
        Me.Lb_FecIng.AutoSize = True
        Me.Lb_FecIng.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lb_FecIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_FecIng.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lb_FecIng.Location = New System.Drawing.Point(384, 198)
        Me.Lb_FecIng.Name = "Lb_FecIng"
        Me.Lb_FecIng.Size = New System.Drawing.Size(90, 13)
        Me.Lb_FecIng.TabIndex = 21
        Me.Lb_FecIng.Text = "Fecha de Ingreso"
        '
        'Dtp_FechaIngreso
        '
        Me.Dtp_FechaIngreso.Checked = False
        Me.Dtp_FechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaIngreso.Location = New System.Drawing.Point(480, 198)
        Me.Dtp_FechaIngreso.MinDate = New Date(1989, 1, 1, 0, 0, 0, 0)
        Me.Dtp_FechaIngreso.Name = "Dtp_FechaIngreso"
        Me.Dtp_FechaIngreso.ShowCheckBox = True
        Me.Dtp_FechaIngreso.Size = New System.Drawing.Size(232, 20)
        Me.Dtp_FechaIngreso.TabIndex = 22
        Me.Dtp_FechaIngreso.Value = New Date(2015, 2, 18, 15, 51, 26, 0)
        '
        'Tx_Identificación
        '
        Me.Tx_Identificación.Location = New System.Drawing.Point(78, 171)
        Me.Tx_Identificación.MaxLength = 20
        Me.Tx_Identificación.Name = "Tx_Identificación"
        Me.Tx_Identificación.Size = New System.Drawing.Size(115, 20)
        Me.Tx_Identificación.TabIndex = 3
        '
        'Btn_BuscarProveedor
        '
        Me.Btn_BuscarProveedor.Location = New System.Drawing.Point(199, 169)
        Me.Btn_BuscarProveedor.Name = "Btn_BuscarProveedor"
        Me.Btn_BuscarProveedor.Size = New System.Drawing.Size(32, 23)
        Me.Btn_BuscarProveedor.TabIndex = 4
        Me.Btn_BuscarProveedor.Text = "..."
        Me.Btn_BuscarProveedor.UseVisualStyleBackColor = True
        '
        'Tx_NombreProveedor
        '
        Me.Tx_NombreProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_NombreProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_NombreProveedor.Location = New System.Drawing.Point(378, 172)
        Me.Tx_NombreProveedor.MaxLength = 150
        Me.Tx_NombreProveedor.Name = "Tx_NombreProveedor"
        Me.Tx_NombreProveedor.ReadOnly = True
        Me.Tx_NombreProveedor.Size = New System.Drawing.Size(334, 20)
        Me.Tx_NombreProveedor.TabIndex = 8
        '
        'Tx_DigVerificación
        '
        Me.Tx_DigVerificación.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_DigVerificación.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_DigVerificación.Location = New System.Drawing.Point(285, 172)
        Me.Tx_DigVerificación.MaxLength = 1
        Me.Tx_DigVerificación.Name = "Tx_DigVerificación"
        Me.Tx_DigVerificación.ReadOnly = True
        Me.Tx_DigVerificación.Size = New System.Drawing.Size(27, 20)
        Me.Tx_DigVerificación.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(237, 176)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Dig Ver:"
        '
        'Cb_componente
        '
        Me.Cb_componente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_componente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_componente.FormattingEnabled = True
        Me.Cb_componente.Location = New System.Drawing.Point(199, 529)
        Me.Cb_componente.MaxDropDownItems = 6
        Me.Cb_componente.Name = "Cb_componente"
        Me.Cb_componente.Size = New System.Drawing.Size(507, 21)
        Me.Cb_componente.TabIndex = 32
        '
        'Cu_BuscarPersonaIngreso
        '
        Me.Cu_BuscarPersonaIngreso.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaIngreso.Location = New System.Drawing.Point(121, 221)
        Me.Cu_BuscarPersonaIngreso.Name = "Cu_BuscarPersonaIngreso"
        Me.Cu_BuscarPersonaIngreso.Size = New System.Drawing.Size(591, 23)
        Me.Cu_BuscarPersonaIngreso.TabIndex = 24
        Me.Cu_BuscarPersonaIngreso.Tipo = "PABO"
        Me.Cu_BuscarPersonaIngreso.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaAsignada
        '
        Me.Cu_BuscarPersonaAsignada.Enabled = False
        Me.Cu_BuscarPersonaAsignada.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAsignada.Location = New System.Drawing.Point(121, 248)
        Me.Cu_BuscarPersonaAsignada.Name = "Cu_BuscarPersonaAsignada"
        Me.Cu_BuscarPersonaAsignada.Size = New System.Drawing.Size(591, 23)
        Me.Cu_BuscarPersonaAsignada.TabIndex = 26
        Me.Cu_BuscarPersonaAsignada.Tipo = "PABO"
        Me.Cu_BuscarPersonaAsignada.valorcajatexto = "IDENTIFICACION"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDCARACTERISTICASLISTA"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDCARACTERISTICASLISTA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
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
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "IRREPETIBLE"
        Me.DataGridViewTextBoxColumn7.HeaderText = "IRREPETIBLE"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'Fr_CrearEquipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Btn_Cancelar
        Me.ClientSize = New System.Drawing.Size(727, 590)
        Me.Controls.Add(Me.Cu_BuscarPersonaIngreso)
        Me.Controls.Add(Me.Cu_BuscarPersonaAsignada)
        Me.Controls.Add(Me.Cb_componente)
        Me.Controls.Add(Me.Cbx_Componente)
        Me.Controls.Add(Me.Tb_NomenclaturaProveedor)
        Me.Controls.Add(Me.Tx_NombreProveedor)
        Me.Controls.Add(Me.Tx_DigVerificación)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Btn_BuscarProveedor)
        Me.Controls.Add(Me.Tx_Identificación)
        Me.Controls.Add(Me.Lb_infoproveedor)
        Me.Controls.Add(Me.Dtp_FechaIngreso)
        Me.Controls.Add(Me.Lb_FecIng)
        Me.Controls.Add(Me.Lb_PerRec)
        Me.Controls.Add(Me.Cb_BodegaIngreso)
        Me.Controls.Add(Me.Lb_BodIng)
        Me.Controls.Add(Me.Btn_Cancelar)
        Me.Controls.Add(Me.Btn_Guardar)
        Me.Controls.Add(Me.Lb_asignadaInfo)
        Me.Controls.Add(Me.Tb_DescripcionAdicional)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Gb_Articulo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Fr_CrearEquipo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar nuevo Equipo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Dgv_Caracteristicas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gb_Articulo.ResumeLayout(False)
        Me.Gb_Articulo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_SubtipoArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tt_info As System.Windows.Forms.ToolTip
    Friend WithEvents Tb_CodigoAccess As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Articulo As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Tb_CodigoMecanico As System.Windows.Forms.TextBox
    Friend WithEvents Tb_CodigoIsmocol As System.Windows.Forms.TextBox
    Friend WithEvents Tb_CodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Dgv_Caracteristicas As System.Windows.Forms.DataGridView
    Friend WithEvents Lbl_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Gb_Articulo As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Tb_DescripcionAdicional As System.Windows.Forms.TextBox
    Friend WithEvents Lb_asignadaInfo As System.Windows.Forms.Label
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Lb_infoproveedor As System.Windows.Forms.Label
    Friend WithEvents Lb_BodIng As System.Windows.Forms.Label
    Friend WithEvents Cb_BodegaIngreso As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_PerRec As System.Windows.Forms.Label
    Friend WithEvents Lb_FecIng As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tx_Identificación As System.Windows.Forms.TextBox
    Friend WithEvents Btn_BuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Tx_NombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Tx_DigVerificación As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Tb_NomenclaturaProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Tb_NombreArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Bt_AgregarModeloEquipo As System.Windows.Forms.Button
    Friend WithEvents Bt_AgregarMarcaEquipo As System.Windows.Forms.Button
    Friend WithEvents Cb_ModeloEquipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cb_MarcaEquipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Cbx_Componente As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_componente As System.Windows.Forms.ComboBox
    Friend WithEvents Cu_BuscarPersonaAsignada As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BuscarPersonaIngreso As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bt_VerifiCons As System.Windows.Forms.Button
    Friend WithEvents Tx_Consecutivo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Consecutivo As System.Windows.Forms.Label
    Friend WithEvents IDCARACTERISTICASLISTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRECARACTERISTICA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCIONCARACTERISTICA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDTIPOCARACTERISTICA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IRREPETIBLE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
