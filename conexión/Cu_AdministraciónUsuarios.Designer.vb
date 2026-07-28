<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_AdministraciónUsuarios
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cu_AdministraciónUsuarios))
        Me.ComboBox_Filtrar = New System.Windows.Forms.ComboBox()
        Me.Cb_Filtrar = New System.Windows.Forms.CheckBox()
        Me.Tb_Descripción = New System.Windows.Forms.TextBox()
        Me.NOMBRESUBCONTRATISTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDENTIFICACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRECOMPLETODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CARGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREPROYECTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDCONTRATOSUBCONTRATISTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADOCONTRATODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CARNET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.EliminarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_EntradasSalidas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Pn_TituloSuperior = New System.Windows.Forms.Panel()
        Me.Ll_AjustarTabla = New System.Windows.Forms.LinkLabel()
        Me.Lb_CantidadUsuario = New System.Windows.Forms.Label()
        Me.Dgv_Usuarios = New System.Windows.Forms.DataGridView()
        Me.LISTAUSUARIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_Usuario1 = New Conexión.Ds_Usuario()
        Me.Pn_Superior = New System.Windows.Forms.Panel()
        Me.PictureBox_Foto_Persona = New System.Windows.Forms.PictureBox()
        Me.Pn_TituloUsuario = New System.Windows.Forms.Panel()
        Me.Cu_BuscarPersona1 = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.GroupBox_DatosUsuario = New System.Windows.Forms.GroupBox()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Lb_dependencia = New System.Windows.Forms.Label()
        Me.Cb_Base = New System.Windows.Forms.ComboBox()
        Me.Lb_Base = New System.Windows.Forms.Label()
        Me.TextBox_CorreoElectrónico = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox_TeléfonoMóvil = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Cb_Bodega = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Bt_GuardarPermisosTipoUsuario = New System.Windows.Forms.Button()
        Me.Bt_Asignar = New System.Windows.Forms.Button()
        Me.Bt_Adicionar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Cb_TipoUsuario = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox_Contraseña = New System.Windows.Forms.TextBox()
        Me.TextBox_NombreUsuario = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.RadioButton_UsuarioNo = New System.Windows.Forms.RadioButton()
        Me.RadioButton_UsuarioSi = New System.Windows.Forms.RadioButton()
        Me.MATIPOUSUARIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Pn_Inferior = New System.Windows.Forms.Panel()
        Me.Splitter3 = New System.Windows.Forms.Splitter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Tv_Permisos = New System.Windows.Forms.TreeView()
        Me.Pn_TituloArbol = New System.Windows.Forms.Panel()
        Me.Ll_Expandir = New System.Windows.Forms.LinkLabel()
        Me.Lb_Contraer = New System.Windows.Forms.LinkLabel()
        Me.Ll_Pegar = New System.Windows.Forms.LinkLabel()
        Me.Ll_CopiarPermisos = New System.Windows.Forms.LinkLabel()
        Me.Ll_Ninguno = New System.Windows.Forms.LinkLabel()
        Me.Ll_Todos = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Nbc_Usuario = New NetBarControl.NetBarControl()
        Me.Nbg_Filtro = New NetBarControl.NetBarGroup()
        Me.NBGCC_Filtro = New NetBarControl.NetBarGroupControlContainer()
        Me.Nbg_Usuario = New NetBarControl.NetBarGroup()
        Me.Nbi_Cargar = New NetBarControl.NetBarItem()
        Me.Nbi_NuevoUsuario = New NetBarControl.NetBarItem()
        Me.Nbi_EditarUsuario = New NetBarControl.NetBarItem()
        Me.Nbi_Desactivar = New NetBarControl.NetBarItem()
        Me.Nbi_Buscar = New NetBarControl.NetBarItem()
        Me.Pn_Contenedor = New System.Windows.Forms.Panel()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.LISTAUSUARIOTableAdapter = New Conexión.Ds_UsuarioTableAdapters.LISTAUSUARIOTableAdapter()
        Me.Cm_MarcarDesmarcarTodos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MarcarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesmarcarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_EntradasSalidas.SuspendLayout()
        Me.Pn_TituloSuperior.SuspendLayout()
        CType(Me.Dgv_Usuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LISTAUSUARIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Usuario1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Superior.SuspendLayout()
        CType(Me.PictureBox_Foto_Persona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_TituloUsuario.SuspendLayout()
        Me.GroupBox_DatosUsuario.SuspendLayout()
        CType(Me.MATIPOUSUARIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Inferior.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Pn_TituloArbol.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Nbc_Usuario.SuspendLayout()
        Me.NBGCC_Filtro.SuspendLayout()
        Me.Pn_Contenedor.SuspendLayout()
        Me.Cm_MarcarDesmarcarTodos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox_Filtrar
        '
        Me.ComboBox_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Filtrar.FormattingEnabled = True
        Me.ComboBox_Filtrar.Items.AddRange(New Object() {"Nombre o Apellidos", "Identificación", "Tipo Usuario"})
        Me.ComboBox_Filtrar.Location = New System.Drawing.Point(28, 3)
        Me.ComboBox_Filtrar.Name = "ComboBox_Filtrar"
        Me.ComboBox_Filtrar.Size = New System.Drawing.Size(151, 21)
        Me.ComboBox_Filtrar.TabIndex = 2
        '
        'Cb_Filtrar
        '
        Me.Cb_Filtrar.AutoSize = True
        Me.Cb_Filtrar.Location = New System.Drawing.Point(10, 6)
        Me.Cb_Filtrar.Name = "Cb_Filtrar"
        Me.Cb_Filtrar.Size = New System.Drawing.Size(15, 14)
        Me.Cb_Filtrar.TabIndex = 1
        Me.Cb_Filtrar.UseVisualStyleBackColor = True
        '
        'Tb_Descripción
        '
        Me.Tb_Descripción.Location = New System.Drawing.Point(10, 28)
        Me.Tb_Descripción.Name = "Tb_Descripción"
        Me.Tb_Descripción.Size = New System.Drawing.Size(169, 20)
        Me.Tb_Descripción.TabIndex = 0
        '
        'NOMBRESUBCONTRATISTADataGridViewTextBoxColumn
        '
        Me.NOMBRESUBCONTRATISTADataGridViewTextBoxColumn.DataPropertyName = "NOMBRESUBCONTRATISTA"
        Me.NOMBRESUBCONTRATISTADataGridViewTextBoxColumn.HeaderText = "Subcontratista"
        Me.NOMBRESUBCONTRATISTADataGridViewTextBoxColumn.Name = "NOMBRESUBCONTRATISTADataGridViewTextBoxColumn"
        '
        'IDENTIFICACION
        '
        Me.IDENTIFICACION.DataPropertyName = "IDENTIFICACION"
        Me.IDENTIFICACION.HeaderText = "Identificación"
        Me.IDENTIFICACION.Name = "IDENTIFICACION"
        Me.IDENTIFICACION.ReadOnly = True
        Me.IDENTIFICACION.Width = 95
        '
        'NOMBRECOMPLETODataGridViewTextBoxColumn
        '
        Me.NOMBRECOMPLETODataGridViewTextBoxColumn.DataPropertyName = "NOMBRECOMPLETO"
        Me.NOMBRECOMPLETODataGridViewTextBoxColumn.HeaderText = "Nombre"
        Me.NOMBRECOMPLETODataGridViewTextBoxColumn.Name = "NOMBRECOMPLETODataGridViewTextBoxColumn"
        Me.NOMBRECOMPLETODataGridViewTextBoxColumn.ReadOnly = True
        Me.NOMBRECOMPLETODataGridViewTextBoxColumn.Width = 69
        '
        'CARGODataGridViewTextBoxColumn
        '
        Me.CARGODataGridViewTextBoxColumn.DataPropertyName = "CARGO"
        Me.CARGODataGridViewTextBoxColumn.HeaderText = "Cargo"
        Me.CARGODataGridViewTextBoxColumn.Name = "CARGODataGridViewTextBoxColumn"
        Me.CARGODataGridViewTextBoxColumn.Width = 60
        '
        'NOMBREPROYECTODataGridViewTextBoxColumn
        '
        Me.NOMBREPROYECTODataGridViewTextBoxColumn.DataPropertyName = "NOMBREPROYECTO"
        Me.NOMBREPROYECTODataGridViewTextBoxColumn.HeaderText = "Proyecto"
        Me.NOMBREPROYECTODataGridViewTextBoxColumn.Name = "NOMBREPROYECTODataGridViewTextBoxColumn"
        Me.NOMBREPROYECTODataGridViewTextBoxColumn.Width = 74
        '
        'IDCONTRATOSUBCONTRATISTADataGridViewTextBoxColumn
        '
        Me.IDCONTRATOSUBCONTRATISTADataGridViewTextBoxColumn.DataPropertyName = "IDCONTRATOSUBCONTRATISTA"
        Me.IDCONTRATOSUBCONTRATISTADataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IDCONTRATOSUBCONTRATISTADataGridViewTextBoxColumn.Name = "IDCONTRATOSUBCONTRATISTADataGridViewTextBoxColumn"
        Me.IDCONTRATOSUBCONTRATISTADataGridViewTextBoxColumn.ReadOnly = True
        Me.IDCONTRATOSUBCONTRATISTADataGridViewTextBoxColumn.Width = 41
        '
        'ESTADOCONTRATODataGridViewTextBoxColumn
        '
        Me.ESTADOCONTRATODataGridViewTextBoxColumn.DataPropertyName = "ESTADOCONTRATO"
        Me.ESTADOCONTRATODataGridViewTextBoxColumn.HeaderText = "ESTADOCONTRATO"
        Me.ESTADOCONTRATODataGridViewTextBoxColumn.Name = "ESTADOCONTRATODataGridViewTextBoxColumn"
        Me.ESTADOCONTRATODataGridViewTextBoxColumn.Visible = False
        Me.ESTADOCONTRATODataGridViewTextBoxColumn.Width = 136
        '
        'CARNET
        '
        Me.CARNET.DataPropertyName = "CARNET"
        Me.CARNET.HeaderText = "CARNET"
        Me.CARNET.Name = "CARNET"
        Me.CARNET.ReadOnly = True
        '
        'SAI
        '
        Me.SAI.DataPropertyName = "SAI"
        Me.SAI.HeaderText = "SAI"
        Me.SAI.Name = "SAI"
        Me.SAI.ReadOnly = True
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1062, 3)
        Me.Splitter1.TabIndex = 18
        Me.Splitter1.TabStop = False
        '
        'EliminarRegistroToolStripMenuItem
        '
        Me.EliminarRegistroToolStripMenuItem.Name = "EliminarRegistroToolStripMenuItem"
        Me.EliminarRegistroToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.EliminarRegistroToolStripMenuItem.Text = "Eliminar Registro"
        '
        'CMS_EntradasSalidas
        '
        Me.CMS_EntradasSalidas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarRegistroToolStripMenuItem})
        Me.CMS_EntradasSalidas.Name = "CMS_EntradasSalidas"
        Me.CMS_EntradasSalidas.Size = New System.Drawing.Size(164, 26)
        '
        'Timer1
        '
        '
        'Pn_TituloSuperior
        '
        Me.Pn_TituloSuperior.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_TituloSuperior.Controls.Add(Me.Ll_AjustarTabla)
        Me.Pn_TituloSuperior.Controls.Add(Me.Lb_CantidadUsuario)
        Me.Pn_TituloSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloSuperior.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloSuperior.Name = "Pn_TituloSuperior"
        Me.Pn_TituloSuperior.Size = New System.Drawing.Size(872, 22)
        Me.Pn_TituloSuperior.TabIndex = 10
        '
        'Ll_AjustarTabla
        '
        Me.Ll_AjustarTabla.AutoSize = True
        Me.Ll_AjustarTabla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_AjustarTabla.LinkColor = System.Drawing.Color.DarkViolet
        Me.Ll_AjustarTabla.Location = New System.Drawing.Point(4, 4)
        Me.Ll_AjustarTabla.Name = "Ll_AjustarTabla"
        Me.Ll_AjustarTabla.Size = New System.Drawing.Size(82, 13)
        Me.Ll_AjustarTabla.TabIndex = 1
        Me.Ll_AjustarTabla.TabStop = True
        Me.Ll_AjustarTabla.Text = "Ajustar Tabla"
        '
        'Lb_CantidadUsuario
        '
        Me.Lb_CantidadUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadUsuario.ForeColor = System.Drawing.Color.Black
        Me.Lb_CantidadUsuario.Location = New System.Drawing.Point(94, 0)
        Me.Lb_CantidadUsuario.Name = "Lb_CantidadUsuario"
        Me.Lb_CantidadUsuario.Size = New System.Drawing.Size(349, 22)
        Me.Lb_CantidadUsuario.TabIndex = 0
        Me.Lb_CantidadUsuario.Text = "Cantidad de Usuarios:"
        Me.Lb_CantidadUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Dgv_Usuarios
        '
        Me.Dgv_Usuarios.AllowUserToAddRows = False
        Me.Dgv_Usuarios.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Usuarios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Usuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Usuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Usuarios.Location = New System.Drawing.Point(0, 22)
        Me.Dgv_Usuarios.Name = "Dgv_Usuarios"
        Me.Dgv_Usuarios.ReadOnly = True
        Me.Dgv_Usuarios.Size = New System.Drawing.Size(872, 290)
        Me.Dgv_Usuarios.TabIndex = 11
        '
        'LISTAUSUARIOBindingSource
        '
        Me.LISTAUSUARIOBindingSource.DataMember = "LISTAUSUARIO"
        Me.LISTAUSUARIOBindingSource.DataSource = Me.Ds_Usuario1
        '
        'Ds_Usuario1
        '
        Me.Ds_Usuario1.DataSetName = "Ds_Usuario"
        Me.Ds_Usuario1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Pn_Superior
        '
        Me.Pn_Superior.Controls.Add(Me.Dgv_Usuarios)
        Me.Pn_Superior.Controls.Add(Me.Pn_TituloSuperior)
        Me.Pn_Superior.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Superior.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Superior.Name = "Pn_Superior"
        Me.Pn_Superior.Size = New System.Drawing.Size(872, 312)
        Me.Pn_Superior.TabIndex = 16
        '
        'PictureBox_Foto_Persona
        '
        Me.PictureBox_Foto_Persona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox_Foto_Persona.ErrorImage = CType(resources.GetObject("PictureBox_Foto_Persona.ErrorImage"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.Image = CType(resources.GetObject("PictureBox_Foto_Persona.Image"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.InitialImage = CType(resources.GetObject("PictureBox_Foto_Persona.InitialImage"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.Location = New System.Drawing.Point(477, 16)
        Me.PictureBox_Foto_Persona.Name = "PictureBox_Foto_Persona"
        Me.PictureBox_Foto_Persona.Size = New System.Drawing.Size(120, 135)
        Me.PictureBox_Foto_Persona.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_Foto_Persona.TabIndex = 43
        Me.PictureBox_Foto_Persona.TabStop = False
        '
        'Pn_TituloUsuario
        '
        Me.Pn_TituloUsuario.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_TituloUsuario.Controls.Add(Me.Cu_BuscarPersona1)
        Me.Pn_TituloUsuario.Controls.Add(Me.Lb_Nombre)
        Me.Pn_TituloUsuario.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloUsuario.Enabled = False
        Me.Pn_TituloUsuario.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloUsuario.Name = "Pn_TituloUsuario"
        Me.Pn_TituloUsuario.Size = New System.Drawing.Size(619, 24)
        Me.Pn_TituloUsuario.TabIndex = 32
        '
        'Cu_BuscarPersona1
        '
        Me.Cu_BuscarPersona1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cu_BuscarPersona1.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersona1.Location = New System.Drawing.Point(0, 0)
        Me.Cu_BuscarPersona1.Name = "Cu_BuscarPersona1"
        Me.Cu_BuscarPersona1.Size = New System.Drawing.Size(619, 24)
        Me.Cu_BuscarPersona1.TabIndex = 2
        Me.Cu_BuscarPersona1.Tipo = "PNUS"
        Me.Cu_BuscarPersona1.valorcajatexto = "IDENTIFICACION"
        Me.Cu_BuscarPersona1.Visible = False
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.ForeColor = System.Drawing.Color.Black
        Me.Lb_Nombre.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(619, 24)
        Me.Lb_Nombre.TabIndex = 1
        Me.Lb_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.BackColor = System.Drawing.SystemColors.Control
        Me.Bt_Cancelar.Location = New System.Drawing.Point(517, 194)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(96, 23)
        Me.Bt_Cancelar.TabIndex = 31
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.BackColor = System.Drawing.SystemColors.Control
        Me.Bt_Guardar.Location = New System.Drawing.Point(415, 194)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(96, 23)
        Me.Bt_Guardar.TabIndex = 30
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = False
        '
        'GroupBox_DatosUsuario
        '
        Me.GroupBox_DatosUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Cb_Dependencia)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Lb_dependencia)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Cb_Base)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Lb_Base)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.TextBox_CorreoElectrónico)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Label10)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.TextBox_TeléfonoMóvil)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Label8)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Cb_Bodega)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.PictureBox_Foto_Persona)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Label2)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Bt_GuardarPermisosTipoUsuario)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Bt_Asignar)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Bt_Adicionar)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Label1)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Label18)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Cb_TipoUsuario)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Label17)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.TextBox_Contraseña)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.TextBox_NombreUsuario)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Label15)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.Label16)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.RadioButton_UsuarioNo)
        Me.GroupBox_DatosUsuario.Controls.Add(Me.RadioButton_UsuarioSi)
        Me.GroupBox_DatosUsuario.Location = New System.Drawing.Point(7, 22)
        Me.GroupBox_DatosUsuario.Name = "GroupBox_DatosUsuario"
        Me.GroupBox_DatosUsuario.Size = New System.Drawing.Size(604, 166)
        Me.GroupBox_DatosUsuario.TabIndex = 29
        Me.GroupBox_DatosUsuario.TabStop = False
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Dependencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Dependencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Dependencia.DisplayMember = "CODIGOTIPOUSUARIO"
        Me.Cb_Dependencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.Location = New System.Drawing.Point(349, 112)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(122, 21)
        Me.Cb_Dependencia.TabIndex = 50
        Me.Cb_Dependencia.ValueMember = "CODIGOTIPOUSUARIO"
        '
        'Lb_dependencia
        '
        Me.Lb_dependencia.AutoSize = True
        Me.Lb_dependencia.Location = New System.Drawing.Point(270, 116)
        Me.Lb_dependencia.Name = "Lb_dependencia"
        Me.Lb_dependencia.Size = New System.Drawing.Size(74, 13)
        Me.Lb_dependencia.TabIndex = 51
        Me.Lb_dependencia.Text = "Dependencia:"
        '
        'Cb_Base
        '
        Me.Cb_Base.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Base.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Base.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Base.DisplayMember = "CODIGOTIPOUSUARIO"
        Me.Cb_Base.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Base.FormattingEnabled = True
        Me.Cb_Base.Location = New System.Drawing.Point(84, 112)
        Me.Cb_Base.Name = "Cb_Base"
        Me.Cb_Base.Size = New System.Drawing.Size(180, 21)
        Me.Cb_Base.TabIndex = 48
        Me.Cb_Base.ValueMember = "CODIGOTIPOUSUARIO"
        '
        'Lb_Base
        '
        Me.Lb_Base.AutoSize = True
        Me.Lb_Base.Location = New System.Drawing.Point(50, 116)
        Me.Lb_Base.Name = "Lb_Base"
        Me.Lb_Base.Size = New System.Drawing.Size(34, 13)
        Me.Lb_Base.TabIndex = 49
        Me.Lb_Base.Text = "Base:"
        '
        'TextBox_CorreoElectrónico
        '
        Me.TextBox_CorreoElectrónico.Location = New System.Drawing.Point(105, 139)
        Me.TextBox_CorreoElectrónico.MaxLength = 100
        Me.TextBox_CorreoElectrónico.Name = "TextBox_CorreoElectrónico"
        Me.TextBox_CorreoElectrónico.Size = New System.Drawing.Size(196, 20)
        Me.TextBox_CorreoElectrónico.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 143)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Correo Electrónico:"
        '
        'TextBox_TeléfonoMóvil
        '
        Me.TextBox_TeléfonoMóvil.Location = New System.Drawing.Point(305, 86)
        Me.TextBox_TeléfonoMóvil.MaxLength = 10
        Me.TextBox_TeléfonoMóvil.Name = "TextBox_TeléfonoMóvil"
        Me.TextBox_TeléfonoMóvil.Size = New System.Drawing.Size(166, 20)
        Me.TextBox_TeléfonoMóvil.TabIndex = 45
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(223, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Teléfono Móvil:"
        '
        'Cb_Bodega
        '
        Me.Cb_Bodega.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Bodega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Bodega.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Bodega.DisplayMember = "CODIGOTIPOUSUARIO"
        Me.Cb_Bodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Bodega.FormattingEnabled = True
        Me.Cb_Bodega.Location = New System.Drawing.Point(305, 61)
        Me.Cb_Bodega.Name = "Cb_Bodega"
        Me.Cb_Bodega.Size = New System.Drawing.Size(166, 21)
        Me.Cb_Bodega.TabIndex = 12
        Me.Cb_Bodega.ValueMember = "CODIGOTIPOUSUARIO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(255, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Bodega:"
        '
        'Bt_GuardarPermisosTipoUsuario
        '
        Me.Bt_GuardarPermisosTipoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_GuardarPermisosTipoUsuario.ForeColor = System.Drawing.Color.Red
        Me.Bt_GuardarPermisosTipoUsuario.Location = New System.Drawing.Point(385, 36)
        Me.Bt_GuardarPermisosTipoUsuario.Name = "Bt_GuardarPermisosTipoUsuario"
        Me.Bt_GuardarPermisosTipoUsuario.Size = New System.Drawing.Size(29, 23)
        Me.Bt_GuardarPermisosTipoUsuario.TabIndex = 11
        Me.Bt_GuardarPermisosTipoUsuario.Tag = "208"
        Me.Bt_GuardarPermisosTipoUsuario.Text = "!"
        Me.Bt_GuardarPermisosTipoUsuario.UseVisualStyleBackColor = True
        '
        'Bt_Asignar
        '
        Me.Bt_Asignar.Location = New System.Drawing.Point(349, 36)
        Me.Bt_Asignar.Name = "Bt_Asignar"
        Me.Bt_Asignar.Size = New System.Drawing.Size(29, 23)
        Me.Bt_Asignar.TabIndex = 10
        Me.Bt_Asignar.Text = "-->"
        Me.Bt_Asignar.UseVisualStyleBackColor = True
        '
        'Bt_Adicionar
        '
        Me.Bt_Adicionar.Location = New System.Drawing.Point(313, 36)
        Me.Bt_Adicionar.Name = "Bt_Adicionar"
        Me.Bt_Adicionar.Size = New System.Drawing.Size(29, 23)
        Me.Bt_Adicionar.TabIndex = 9
        Me.Bt_Adicionar.Text = "+"
        Me.Bt_Adicionar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(229, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Permisos por tipo usuario:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Usuario Activo Sistema:"
        '
        'Cb_TipoUsuario
        '
        Me.Cb_TipoUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_TipoUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoUsuario.DisplayMember = "CODIGOTIPOUSUARIO"
        Me.Cb_TipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoUsuario.FormattingEnabled = True
        Me.Cb_TipoUsuario.Location = New System.Drawing.Point(84, 37)
        Me.Cb_TipoUsuario.Name = "Cb_TipoUsuario"
        Me.Cb_TipoUsuario.Size = New System.Drawing.Size(224, 21)
        Me.Cb_TipoUsuario.TabIndex = 2
        Me.Cb_TipoUsuario.ValueMember = "CODIGOTIPOUSUARIO"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(14, 40)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Tipo Usuario:"
        '
        'TextBox_Contraseña
        '
        Me.TextBox_Contraseña.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Contraseña.Location = New System.Drawing.Point(84, 86)
        Me.TextBox_Contraseña.MaxLength = 10
        Me.TextBox_Contraseña.Name = "TextBox_Contraseña"
        Me.TextBox_Contraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Contraseña.Size = New System.Drawing.Size(93, 20)
        Me.TextBox_Contraseña.TabIndex = 4
        '
        'TextBox_NombreUsuario
        '
        Me.TextBox_NombreUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_NombreUsuario.Location = New System.Drawing.Point(84, 61)
        Me.TextBox_NombreUsuario.MaxLength = 10
        Me.TextBox_NombreUsuario.Name = "TextBox_NombreUsuario"
        Me.TextBox_NombreUsuario.Size = New System.Drawing.Size(93, 20)
        Me.TextBox_NombreUsuario.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(20, 90)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Contraseña:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(0, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 13)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Nombre usuario:"
        '
        'RadioButton_UsuarioNo
        '
        Me.RadioButton_UsuarioNo.AutoSize = True
        Me.RadioButton_UsuarioNo.Checked = True
        Me.RadioButton_UsuarioNo.Location = New System.Drawing.Point(180, 14)
        Me.RadioButton_UsuarioNo.Name = "RadioButton_UsuarioNo"
        Me.RadioButton_UsuarioNo.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton_UsuarioNo.TabIndex = 1
        Me.RadioButton_UsuarioNo.TabStop = True
        Me.RadioButton_UsuarioNo.Text = "No"
        Me.RadioButton_UsuarioNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton_UsuarioNo.UseVisualStyleBackColor = True
        '
        'RadioButton_UsuarioSi
        '
        Me.RadioButton_UsuarioSi.AutoSize = True
        Me.RadioButton_UsuarioSi.Location = New System.Drawing.Point(134, 14)
        Me.RadioButton_UsuarioSi.Name = "RadioButton_UsuarioSi"
        Me.RadioButton_UsuarioSi.Size = New System.Drawing.Size(34, 17)
        Me.RadioButton_UsuarioSi.TabIndex = 0
        Me.RadioButton_UsuarioSi.Text = "Si"
        Me.RadioButton_UsuarioSi.UseVisualStyleBackColor = True
        '
        'Pn_Inferior
        '
        Me.Pn_Inferior.Controls.Add(Me.Splitter3)
        Me.Pn_Inferior.Controls.Add(Me.Panel2)
        Me.Pn_Inferior.Controls.Add(Me.Panel1)
        Me.Pn_Inferior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Inferior.Location = New System.Drawing.Point(0, 315)
        Me.Pn_Inferior.Name = "Pn_Inferior"
        Me.Pn_Inferior.Size = New System.Drawing.Size(872, 285)
        Me.Pn_Inferior.TabIndex = 17
        '
        'Splitter3
        '
        Me.Splitter3.Location = New System.Drawing.Point(619, 0)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(3, 285)
        Me.Splitter3.TabIndex = 20
        Me.Splitter3.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Tv_Permisos)
        Me.Panel2.Controls.Add(Me.Pn_TituloArbol)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(619, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(253, 285)
        Me.Panel2.TabIndex = 19
        '
        'Tv_Permisos
        '
        Me.Tv_Permisos.CheckBoxes = True
        Me.Tv_Permisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tv_Permisos.Location = New System.Drawing.Point(0, 22)
        Me.Tv_Permisos.Name = "Tv_Permisos"
        Me.Tv_Permisos.Size = New System.Drawing.Size(253, 263)
        Me.Tv_Permisos.TabIndex = 14
        '
        'Pn_TituloArbol
        '
        Me.Pn_TituloArbol.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Pn_TituloArbol.Controls.Add(Me.Ll_Expandir)
        Me.Pn_TituloArbol.Controls.Add(Me.Lb_Contraer)
        Me.Pn_TituloArbol.Controls.Add(Me.Ll_Pegar)
        Me.Pn_TituloArbol.Controls.Add(Me.Ll_CopiarPermisos)
        Me.Pn_TituloArbol.Controls.Add(Me.Ll_Ninguno)
        Me.Pn_TituloArbol.Controls.Add(Me.Ll_Todos)
        Me.Pn_TituloArbol.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloArbol.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloArbol.Name = "Pn_TituloArbol"
        Me.Pn_TituloArbol.Size = New System.Drawing.Size(253, 22)
        Me.Pn_TituloArbol.TabIndex = 15
        '
        'Ll_Expandir
        '
        Me.Ll_Expandir.AutoSize = True
        Me.Ll_Expandir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Expandir.LinkColor = System.Drawing.Color.DarkViolet
        Me.Ll_Expandir.Location = New System.Drawing.Point(199, 5)
        Me.Ll_Expandir.Name = "Ll_Expandir"
        Me.Ll_Expandir.Size = New System.Drawing.Size(56, 13)
        Me.Ll_Expandir.TabIndex = 5
        Me.Ll_Expandir.TabStop = True
        Me.Ll_Expandir.Text = "Expandir"
        '
        'Lb_Contraer
        '
        Me.Lb_Contraer.AutoSize = True
        Me.Lb_Contraer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Contraer.LinkColor = System.Drawing.Color.DarkViolet
        Me.Lb_Contraer.Location = New System.Drawing.Point(130, 5)
        Me.Lb_Contraer.Name = "Lb_Contraer"
        Me.Lb_Contraer.Size = New System.Drawing.Size(55, 13)
        Me.Lb_Contraer.TabIndex = 4
        Me.Lb_Contraer.TabStop = True
        Me.Lb_Contraer.Text = "Contraer"
        '
        'Ll_Pegar
        '
        Me.Ll_Pegar.AutoSize = True
        Me.Ll_Pegar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Pegar.LinkColor = System.Drawing.Color.DarkViolet
        Me.Ll_Pegar.Location = New System.Drawing.Point(326, 5)
        Me.Ll_Pegar.Name = "Ll_Pegar"
        Me.Ll_Pegar.Size = New System.Drawing.Size(40, 13)
        Me.Ll_Pegar.TabIndex = 3
        Me.Ll_Pegar.TabStop = True
        Me.Ll_Pegar.Text = "Pegar"
        '
        'Ll_CopiarPermisos
        '
        Me.Ll_CopiarPermisos.AutoSize = True
        Me.Ll_CopiarPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_CopiarPermisos.LinkColor = System.Drawing.Color.DarkViolet
        Me.Ll_CopiarPermisos.Location = New System.Drawing.Point(269, 5)
        Me.Ll_CopiarPermisos.Name = "Ll_CopiarPermisos"
        Me.Ll_CopiarPermisos.Size = New System.Drawing.Size(43, 13)
        Me.Ll_CopiarPermisos.TabIndex = 2
        Me.Ll_CopiarPermisos.TabStop = True
        Me.Ll_CopiarPermisos.Text = "Copiar"
        '
        'Ll_Ninguno
        '
        Me.Ll_Ninguno.AutoSize = True
        Me.Ll_Ninguno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Ninguno.LinkColor = System.Drawing.Color.DarkViolet
        Me.Ll_Ninguno.Location = New System.Drawing.Point(62, 5)
        Me.Ll_Ninguno.Name = "Ll_Ninguno"
        Me.Ll_Ninguno.Size = New System.Drawing.Size(54, 13)
        Me.Ll_Ninguno.TabIndex = 1
        Me.Ll_Ninguno.TabStop = True
        Me.Ll_Ninguno.Text = "Ninguno"
        '
        'Ll_Todos
        '
        Me.Ll_Todos.AutoSize = True
        Me.Ll_Todos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Todos.LinkColor = System.Drawing.Color.DarkViolet
        Me.Ll_Todos.Location = New System.Drawing.Point(6, 5)
        Me.Ll_Todos.Name = "Ll_Todos"
        Me.Ll_Todos.Size = New System.Drawing.Size(42, 13)
        Me.Ll_Todos.TabIndex = 0
        Me.Ll_Todos.TabStop = True
        Me.Ll_Todos.Text = "Todos"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Pn_TituloUsuario)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Controls.Add(Me.GroupBox_DatosUsuario)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.MinimumSize = New System.Drawing.Size(411, 213)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(619, 285)
        Me.Panel1.TabIndex = 18
        '
        'Nbc_Usuario
        '
        Me.Nbc_Usuario.ActiveGroup = Me.Nbg_Usuario
        Me.Nbc_Usuario.Controls.Add(Me.NBGCC_Filtro)
        Me.Nbc_Usuario.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbc_Usuario.Groups.AddRange(New NetBarControl.NetBarGroup() {Me.Nbg_Usuario, Me.Nbg_Filtro})
        Me.Nbc_Usuario.ItemsBackground.BackColor = System.Drawing.Color.Empty
        Me.Nbc_Usuario.ItemsBackground.BackColor2 = System.Drawing.Color.Empty
        Me.Nbc_Usuario.Location = New System.Drawing.Point(0, 3)
        Me.Nbc_Usuario.Name = "Nbc_Usuario"
        Me.Nbc_Usuario.ShowOverflowPanel = False
        Me.Nbc_Usuario.Size = New System.Drawing.Size(190, 600)
        Me.Nbc_Usuario.TabIndex = 19
        Me.Nbc_Usuario.Tag = "202"
        Me.Nbc_Usuario.Text = "NetBarControl1"
        '
        'Nbg_Filtro
        '
        Me.Nbg_Filtro.ControlContainer = Me.NBGCC_Filtro
        Me.Nbg_Filtro.Name = "Nbg_Filtro"
        Me.Nbg_Filtro.SmallImage = Global.Conexión.My.Resources.Resources.Filtrar
        Me.Nbg_Filtro.Style = NetBarControl.NetBarGroupStyle.ControlContainer
        Me.Nbg_Filtro.Tag = "204"
        Me.Nbg_Filtro.Text = "Filtro"
        '
        'NBGCC_Filtro
        '
        Me.NBGCC_Filtro.Controls.Add(Me.ComboBox_Filtrar)
        Me.NBGCC_Filtro.Controls.Add(Me.Tb_Descripción)
        Me.NBGCC_Filtro.Controls.Add(Me.Cb_Filtrar)
        Me.NBGCC_Filtro.Name = "NBGCC_Filtro"
        Me.NBGCC_Filtro.Size = New System.Drawing.Size(181, 501)
        Me.NBGCC_Filtro.TabIndex = 2
        Me.NBGCC_Filtro.Tag = "204"
        '
        'Nbg_Usuario
        '
        Me.Nbg_Usuario.Items.AddRange(New NetBarControl.NetBarItem() {Me.Nbi_Cargar, Me.Nbi_NuevoUsuario, Me.Nbi_EditarUsuario, Me.Nbi_Desactivar, Me.Nbi_Buscar})
        Me.Nbg_Usuario.Name = "Nbg_Usuario"
        Me.Nbg_Usuario.SmallImage = Global.Conexión.My.Resources.Resources.FUsuario
        Me.Nbg_Usuario.Tag = "203"
        Me.Nbg_Usuario.Text = "Usuario"
        '
        'Nbi_Cargar
        '
        Me.Nbi_Cargar.Name = "Nbi_Cargar"
        Me.Nbi_Cargar.Text = "Cargar Usuarios"
        '
        'Nbi_NuevoUsuario
        '
        Me.Nbi_NuevoUsuario.Name = "Nbi_NuevoUsuario"
        Me.Nbi_NuevoUsuario.SmallImage = Global.Conexión.My.Resources.Resources.FNuevoUsuario
        Me.Nbi_NuevoUsuario.Tag = "205"
        Me.Nbi_NuevoUsuario.Text = "Nuevo Usuario"
        '
        'Nbi_EditarUsuario
        '
        Me.Nbi_EditarUsuario.Name = "Nbi_EditarUsuario"
        Me.Nbi_EditarUsuario.SmallImage = Global.Conexión.My.Resources.Resources.FEditarUsuario
        Me.Nbi_EditarUsuario.Tag = "206"
        Me.Nbi_EditarUsuario.Text = "Editar Usuario"
        '
        'Nbi_Desactivar
        '
        Me.Nbi_Desactivar.Name = "Nbi_Desactivar"
        Me.Nbi_Desactivar.SmallImage = Global.Conexión.My.Resources.Resources.FDesactivarUsuario
        Me.Nbi_Desactivar.Tag = "207"
        Me.Nbi_Desactivar.Text = "Desactivar Usuario"
        '
        'Nbi_Buscar
        '
        Me.Nbi_Buscar.Name = "Nbi_Buscar"
        Me.Nbi_Buscar.SmallImage = Global.Conexión.My.Resources.Resources.Buscar
        Me.Nbi_Buscar.Text = "Buscar Usuario"
        '
        'Pn_Contenedor
        '
        Me.Pn_Contenedor.Controls.Add(Me.Pn_Inferior)
        Me.Pn_Contenedor.Controls.Add(Me.Splitter2)
        Me.Pn_Contenedor.Controls.Add(Me.Pn_Superior)
        Me.Pn_Contenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Contenedor.Location = New System.Drawing.Point(190, 3)
        Me.Pn_Contenedor.Name = "Pn_Contenedor"
        Me.Pn_Contenedor.Size = New System.Drawing.Size(872, 600)
        Me.Pn_Contenedor.TabIndex = 20
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Location = New System.Drawing.Point(0, 312)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(872, 3)
        Me.Splitter2.TabIndex = 18
        Me.Splitter2.TabStop = False
        '
        'LISTAUSUARIOTableAdapter
        '
        Me.LISTAUSUARIOTableAdapter.ClearBeforeFill = True
        '
        'Cm_MarcarDesmarcarTodos
        '
        Me.Cm_MarcarDesmarcarTodos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MarcarTodosToolStripMenuItem, Me.DesmarcarTodosToolStripMenuItem})
        Me.Cm_MarcarDesmarcarTodos.Name = "Cm_MarcarTodos"
        Me.Cm_MarcarDesmarcarTodos.Size = New System.Drawing.Size(255, 48)
        '
        'MarcarTodosToolStripMenuItem
        '
        Me.MarcarTodosToolStripMenuItem.Name = "MarcarTodosToolStripMenuItem"
        Me.MarcarTodosToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.MarcarTodosToolStripMenuItem.Text = "Marcar Todos Los Nodos Hijos"
        '
        'DesmarcarTodosToolStripMenuItem
        '
        Me.DesmarcarTodosToolStripMenuItem.Name = "DesmarcarTodosToolStripMenuItem"
        Me.DesmarcarTodosToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.DesmarcarTodosToolStripMenuItem.Text = "Desmarcar Todos Los Nodos Hijos"
        '
        'Cu_AdministraciónUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pn_Contenedor)
        Me.Controls.Add(Me.Nbc_Usuario)
        Me.Controls.Add(Me.Splitter1)
        Me.Name = "Cu_AdministraciónUsuarios"
        Me.Size = New System.Drawing.Size(1062, 603)
        Me.CMS_EntradasSalidas.ResumeLayout(False)
        Me.Pn_TituloSuperior.ResumeLayout(False)
        Me.Pn_TituloSuperior.PerformLayout()
        CType(Me.Dgv_Usuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LISTAUSUARIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Usuario1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Superior.ResumeLayout(False)
        CType(Me.PictureBox_Foto_Persona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_TituloUsuario.ResumeLayout(False)
        Me.GroupBox_DatosUsuario.ResumeLayout(False)
        Me.GroupBox_DatosUsuario.PerformLayout()
        CType(Me.MATIPOUSUARIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Inferior.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Pn_TituloArbol.ResumeLayout(False)
        Me.Pn_TituloArbol.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Nbc_Usuario.ResumeLayout(False)
        Me.NBGCC_Filtro.ResumeLayout(False)
        Me.NBGCC_Filtro.PerformLayout()
        Me.Pn_Contenedor.ResumeLayout(False)
        Me.Cm_MarcarDesmarcarTodos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
  Friend WithEvents ComboBox_Filtrar As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_Filtrar As System.Windows.Forms.CheckBox
    Friend WithEvents Tb_Descripción As System.Windows.Forms.TextBox
    Friend WithEvents NOMBRESUBCONTRATISTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDENTIFICACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRECOMPLETODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CARGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREPROYECTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDCONTRATOSUBCONTRATISTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADOCONTRATODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CARNET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SAI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents EliminarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_EntradasSalidas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Pn_TituloSuperior As System.Windows.Forms.Panel
    Friend WithEvents Lb_CantidadUsuario As System.Windows.Forms.Label
    Friend WithEvents Dgv_Usuarios As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Superior As System.Windows.Forms.Panel
    Friend WithEvents Pn_Inferior As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox_DatosUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Contraseña As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_NombreUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents RadioButton_UsuarioNo As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_UsuarioSi As System.Windows.Forms.RadioButton
    Friend WithEvents Nbc_Usuario As NetBarControl.NetBarControl
    Friend WithEvents Nbg_Usuario As NetBarControl.NetBarGroup
    Friend WithEvents Nbi_NuevoUsuario As NetBarControl.NetBarItem
    Friend WithEvents Nbi_EditarUsuario As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Desactivar As NetBarControl.NetBarItem
    Friend WithEvents NBGCC_Filtro As NetBarControl.NetBarGroupControlContainer
    Friend WithEvents Nbg_Filtro As NetBarControl.NetBarGroup
    Friend WithEvents Pn_Contenedor As System.Windows.Forms.Panel
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents Tv_Permisos As System.Windows.Forms.TreeView
    Friend WithEvents Pn_TituloArbol As System.Windows.Forms.Panel
    Friend WithEvents Ll_Ninguno As System.Windows.Forms.LinkLabel
    Friend WithEvents Ll_Todos As System.Windows.Forms.LinkLabel
    Friend WithEvents Ll_AjustarTabla As System.Windows.Forms.LinkLabel
    Friend WithEvents Ll_Pegar As System.Windows.Forms.LinkLabel
    Friend WithEvents Ll_CopiarPermisos As System.Windows.Forms.LinkLabel
    Friend WithEvents Pn_TituloUsuario As System.Windows.Forms.Panel
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents PictureBox_Foto_Persona As System.Windows.Forms.PictureBox
    Friend WithEvents LISTAUSUARIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_Usuario1 As Conexión.Ds_Usuario
    Friend WithEvents LISTAUSUARIOTableAdapter As Conexión.Ds_UsuarioTableAdapters.LISTAUSUARIOTableAdapter
    Friend WithEvents Ll_Expandir As System.Windows.Forms.LinkLabel
    Friend WithEvents Lb_Contraer As System.Windows.Forms.LinkLabel
    Friend WithEvents Cu_BuscarPersona1 As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents MATIPOUSUARIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Bt_Asignar As System.Windows.Forms.Button
    Friend WithEvents Bt_Adicionar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bt_GuardarPermisosTipoUsuario As System.Windows.Forms.Button
    Friend WithEvents Splitter3 As System.Windows.Forms.Splitter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cb_Bodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ESTADOCONTRATODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BASEACTUALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOTODataGridViewImageColumn As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Cm_MarcarDesmarcarTodos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MarcarTodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesmarcarTodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox_CorreoElectrónico As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox_TeléfonoMóvil As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_dependencia As System.Windows.Forms.Label
    Friend WithEvents Cb_Base As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Base As System.Windows.Forms.Label
    Friend WithEvents Nbi_Buscar As NetBarControl.NetBarItem
    Friend WithEvents Nbi_Cargar As NetBarControl.NetBarItem

End Class
