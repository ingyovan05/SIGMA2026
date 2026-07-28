<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_SolicitudMaquinaria
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_SolicitudMaquinaria))
        Me.Pn_ItemSolicitudMaquinaria = New System.Windows.Forms.Panel()
        Me.Dgv_ItemSolicitudMaquinaria = New System.Windows.Forms.DataGridView()
        Me.IdItemSolicitudMaquinaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRequiere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_TituloItemSolicitudMaquinaria = New System.Windows.Forms.Panel()
        Me.Lb_TituloItemSolicitudMaquinaria = New System.Windows.Forms.Label()
        Me.Lb_Encabezado = New System.Windows.Forms.Label()
        Me.Tb_Encabezado = New System.Windows.Forms.TextBox()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Lb_CodigoArticulo = New System.Windows.Forms.Label()
        Me.Ll_ActualizarContacto = New System.Windows.Forms.LinkLabel()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Pn_PersonasAsociadas = New System.Windows.Forms.Panel()
        Me.Cu_BuscarPersonaAutoriza = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_PersonaSolicita = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersonaSolicita = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_ApbSolicita = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Lb_PersonaAutoriza = New System.Windows.Forms.Label()
        Me.Cu_ApbAutoriza = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Lb_PersonaAprueba = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersonaAprueba = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_ApbAprueba = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Pn_Encabezado = New System.Windows.Forms.Panel()
        Me.Lb_Origen = New System.Windows.Forms.Label()
        Me.Tb_Origen = New System.Windows.Forms.TextBox()
        Me.Lb_Base = New System.Windows.Forms.Label()
        Me.Tb_Base = New System.Windows.Forms.TextBox()
        Me.LbJustificacion = New System.Windows.Forms.Label()
        Me.Tb_Justificacion = New System.Windows.Forms.TextBox()
        Me.Dtp_FechaSolicitud = New System.Windows.Forms.DateTimePicker()
        Me.Pn_Opciones = New System.Windows.Forms.Panel()
        Me.Lb_FechaSolicitud = New System.Windows.Forms.Label()
        Me.Pn_ItemSolicitudMaquinaria.SuspendLayout()
        CType(Me.Dgv_ItemSolicitudMaquinaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_TituloItemSolicitudMaquinaria.SuspendLayout()
        Me.Pn_Botones.SuspendLayout()
        Me.Pn_PersonasAsociadas.SuspendLayout()
        Me.Pn_Encabezado.SuspendLayout()
        Me.Pn_Opciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_ItemSolicitudMaquinaria
        '
        Me.Pn_ItemSolicitudMaquinaria.Controls.Add(Me.Dgv_ItemSolicitudMaquinaria)
        Me.Pn_ItemSolicitudMaquinaria.Controls.Add(Me.Pn_TituloItemSolicitudMaquinaria)
        Me.Pn_ItemSolicitudMaquinaria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_ItemSolicitudMaquinaria.Location = New System.Drawing.Point(0, 150)
        Me.Pn_ItemSolicitudMaquinaria.Name = "Pn_ItemSolicitudMaquinaria"
        Me.Pn_ItemSolicitudMaquinaria.Size = New System.Drawing.Size(804, 335)
        Me.Pn_ItemSolicitudMaquinaria.TabIndex = 4
        '
        'Dgv_ItemSolicitudMaquinaria
        '
        Me.Dgv_ItemSolicitudMaquinaria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_ItemSolicitudMaquinaria.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdItemSolicitudMaquinaria, Me.IdArticulo, Me.Descripcion, Me.Cantidad, Me.FechaRequiere})
        Me.Dgv_ItemSolicitudMaquinaria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ItemSolicitudMaquinaria.Location = New System.Drawing.Point(0, 24)
        Me.Dgv_ItemSolicitudMaquinaria.MultiSelect = False
        Me.Dgv_ItemSolicitudMaquinaria.Name = "Dgv_ItemSolicitudMaquinaria"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_ItemSolicitudMaquinaria.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_ItemSolicitudMaquinaria.Size = New System.Drawing.Size(804, 311)
        Me.Dgv_ItemSolicitudMaquinaria.TabIndex = 0
        '
        'IdItemSolicitudMaquinaria
        '
        Me.IdItemSolicitudMaquinaria.DataPropertyName = "IDITEMSOLICITUDMAQUINARIA"
        Me.IdItemSolicitudMaquinaria.HeaderText = "Ítem"
        Me.IdItemSolicitudMaquinaria.Name = "IdItemSolicitudMaquinaria"
        Me.IdItemSolicitudMaquinaria.ReadOnly = True
        Me.IdItemSolicitudMaquinaria.Width = 50
        '
        'IdArticulo
        '
        Me.IdArticulo.DataPropertyName = "IDARTICULO"
        Me.IdArticulo.HeaderText = "Referencia"
        Me.IdArticulo.Name = "IdArticulo"
        Me.IdArticulo.Width = 80
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "DESCRIPCION"
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 400
        '
        'Cantidad
        '
        Me.Cantidad.DataPropertyName = "CANTIDAD"
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 70
        '
        'FechaRequiere
        '
        Me.FechaRequiere.DataPropertyName = "FECHAREQUIERE"
        DataGridViewCellStyle1.Format = "d"
        Me.FechaRequiere.DefaultCellStyle = DataGridViewCellStyle1
        Me.FechaRequiere.HeaderText = "Fecha en que se requiere"
        Me.FechaRequiere.Name = "FechaRequiere"
        Me.FechaRequiere.Width = 160
        '
        'Pn_TituloItemSolicitudMaquinaria
        '
        Me.Pn_TituloItemSolicitudMaquinaria.Controls.Add(Me.Lb_TituloItemSolicitudMaquinaria)
        Me.Pn_TituloItemSolicitudMaquinaria.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloItemSolicitudMaquinaria.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloItemSolicitudMaquinaria.Name = "Pn_TituloItemSolicitudMaquinaria"
        Me.Pn_TituloItemSolicitudMaquinaria.Size = New System.Drawing.Size(804, 24)
        Me.Pn_TituloItemSolicitudMaquinaria.TabIndex = 1
        '
        'Lb_TituloItemSolicitudMaquinaria
        '
        Me.Lb_TituloItemSolicitudMaquinaria.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Lb_TituloItemSolicitudMaquinaria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_TituloItemSolicitudMaquinaria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TituloItemSolicitudMaquinaria.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TituloItemSolicitudMaquinaria.Name = "Lb_TituloItemSolicitudMaquinaria"
        Me.Lb_TituloItemSolicitudMaquinaria.Size = New System.Drawing.Size(804, 24)
        Me.Lb_TituloItemSolicitudMaquinaria.TabIndex = 0
        Me.Lb_TituloItemSolicitudMaquinaria.Text = "ÍTEMS SOLICITUD"
        Me.Lb_TituloItemSolicitudMaquinaria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_Encabezado
        '
        Me.Lb_Encabezado.AutoSize = True
        Me.Lb_Encabezado.Location = New System.Drawing.Point(15, 62)
        Me.Lb_Encabezado.Name = "Lb_Encabezado"
        Me.Lb_Encabezado.Size = New System.Drawing.Size(70, 13)
        Me.Lb_Encabezado.TabIndex = 6
        Me.Lb_Encabezado.Text = "Encabezado:"
        '
        'Tb_Encabezado
        '
        Me.Tb_Encabezado.Location = New System.Drawing.Point(12, 78)
        Me.Tb_Encabezado.MaxLength = 199
        Me.Tb_Encabezado.Multiline = True
        Me.Tb_Encabezado.Name = "Tb_Encabezado"
        Me.Tb_Encabezado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tb_Encabezado.Size = New System.Drawing.Size(385, 63)
        Me.Tb_Encabezado.TabIndex = 7
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.Color.Silver
        Me.Pn_Botones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Botones.Controls.Add(Me.Lb_CodigoArticulo)
        Me.Pn_Botones.Controls.Add(Me.Ll_ActualizarContacto)
        Me.Pn_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Pn_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 571)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(804, 30)
        Me.Pn_Botones.TabIndex = 3
        '
        'Lb_CodigoArticulo
        '
        Me.Lb_CodigoArticulo.AutoSize = True
        Me.Lb_CodigoArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CodigoArticulo.ForeColor = System.Drawing.Color.Red
        Me.Lb_CodigoArticulo.Location = New System.Drawing.Point(11, 8)
        Me.Lb_CodigoArticulo.Name = "Lb_CodigoArticulo"
        Me.Lb_CodigoArticulo.Size = New System.Drawing.Size(60, 13)
        Me.Lb_CodigoArticulo.TabIndex = 0
        Me.Lb_CodigoArticulo.Text = "LabelInfo"
        Me.Lb_CodigoArticulo.Visible = False
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
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_BuscarPersonaAutoriza)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Lb_PersonaSolicita)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_BuscarPersonaSolicita)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_ApbSolicita)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Lb_PersonaAutoriza)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_ApbAutoriza)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Lb_PersonaAprueba)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_BuscarPersonaAprueba)
        Me.Pn_PersonasAsociadas.Controls.Add(Me.Cu_ApbAprueba)
        Me.Pn_PersonasAsociadas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_PersonasAsociadas.Location = New System.Drawing.Point(0, 515)
        Me.Pn_PersonasAsociadas.Name = "Pn_PersonasAsociadas"
        Me.Pn_PersonasAsociadas.Size = New System.Drawing.Size(804, 56)
        Me.Pn_PersonasAsociadas.TabIndex = 2
        '
        'Cu_BuscarPersonaAutoriza
        '
        Me.Cu_BuscarPersonaAutoriza.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAutoriza.Location = New System.Drawing.Point(470, 5)
        Me.Cu_BuscarPersonaAutoriza.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_BuscarPersonaAutoriza.Name = "Cu_BuscarPersonaAutoriza"
        Me.Cu_BuscarPersonaAutoriza.Size = New System.Drawing.Size(300, 23)
        Me.Cu_BuscarPersonaAutoriza.TabIndex = 4
        Me.Cu_BuscarPersonaAutoriza.Tipo = "PUABO"
        Me.Cu_BuscarPersonaAutoriza.valorcajatexto = "IDENTIFICACION"
        '
        'Lb_PersonaSolicita
        '
        Me.Lb_PersonaSolicita.AutoSize = True
        Me.Lb_PersonaSolicita.Location = New System.Drawing.Point(26, 9)
        Me.Lb_PersonaSolicita.Name = "Lb_PersonaSolicita"
        Me.Lb_PersonaSolicita.Size = New System.Drawing.Size(47, 13)
        Me.Lb_PersonaSolicita.TabIndex = 0
        Me.Lb_PersonaSolicita.Text = "Director:"
        '
        'Cu_BuscarPersonaSolicita
        '
        Me.Cu_BuscarPersonaSolicita.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaSolicita.Location = New System.Drawing.Point(73, 5)
        Me.Cu_BuscarPersonaSolicita.Name = "Cu_BuscarPersonaSolicita"
        Me.Cu_BuscarPersonaSolicita.Size = New System.Drawing.Size(300, 23)
        Me.Cu_BuscarPersonaSolicita.TabIndex = 1
        Me.Cu_BuscarPersonaSolicita.Tipo = "PUABO"
        Me.Cu_BuscarPersonaSolicita.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_ApbSolicita
        '
        Me.Cu_ApbSolicita.componenteasociado = "Cu_BuscarPersonaSolicita"
        Me.Cu_ApbSolicita.CrearUsuario = False
        Me.Cu_ApbSolicita.Location = New System.Drawing.Point(375, 5)
        Me.Cu_ApbSolicita.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_ApbSolicita.Name = "Cu_ApbSolicita"
        Me.Cu_ApbSolicita.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ApbSolicita.TabIndex = 2
        Me.Cu_ApbSolicita.Tag = "290"
        Me.Cu_ApbSolicita.TipoAsociacion = "BOD"
        '
        'Lb_PersonaAutoriza
        '
        Me.Lb_PersonaAutoriza.AutoSize = True
        Me.Lb_PersonaAutoriza.Location = New System.Drawing.Point(422, 9)
        Me.Lb_PersonaAutoriza.Name = "Lb_PersonaAutoriza"
        Me.Lb_PersonaAutoriza.Size = New System.Drawing.Size(48, 13)
        Me.Lb_PersonaAutoriza.TabIndex = 3
        Me.Lb_PersonaAutoriza.Text = "Gerente:"
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
        '
        'Lb_PersonaAprueba
        '
        Me.Lb_PersonaAprueba.AutoSize = True
        Me.Lb_PersonaAprueba.Enabled = False
        Me.Lb_PersonaAprueba.Location = New System.Drawing.Point(3, 35)
        Me.Lb_PersonaAprueba.Name = "Lb_PersonaAprueba"
        Me.Lb_PersonaAprueba.Size = New System.Drawing.Size(70, 13)
        Me.Lb_PersonaAprueba.TabIndex = 9
        Me.Lb_PersonaAprueba.Text = "Gerente Gral:"
        '
        'Cu_BuscarPersonaAprueba
        '
        Me.Cu_BuscarPersonaAprueba.Enabled = False
        Me.Cu_BuscarPersonaAprueba.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAprueba.Location = New System.Drawing.Point(73, 31)
        Me.Cu_BuscarPersonaAprueba.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_BuscarPersonaAprueba.Name = "Cu_BuscarPersonaAprueba"
        Me.Cu_BuscarPersonaAprueba.Size = New System.Drawing.Size(697, 23)
        Me.Cu_BuscarPersonaAprueba.TabIndex = 10
        Me.Cu_BuscarPersonaAprueba.Tipo = "PUABO"
        Me.Cu_BuscarPersonaAprueba.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_ApbAprueba
        '
        Me.Cu_ApbAprueba.componenteasociado = "Cu_BuscarPersonaAprueba"
        Me.Cu_ApbAprueba.CrearUsuario = True
        Me.Cu_ApbAprueba.Enabled = False
        Me.Cu_ApbAprueba.Location = New System.Drawing.Point(772, 31)
        Me.Cu_ApbAprueba.Margin = New System.Windows.Forms.Padding(4)
        Me.Cu_ApbAprueba.Name = "Cu_ApbAprueba"
        Me.Cu_ApbAprueba.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ApbAprueba.TabIndex = 11
        Me.Cu_ApbAprueba.Tag = "293"
        Me.Cu_ApbAprueba.TipoAsociacion = "BOD"
        '
        'Pn_Encabezado
        '
        Me.Pn_Encabezado.Controls.Add(Me.Lb_Origen)
        Me.Pn_Encabezado.Controls.Add(Me.Tb_Origen)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_Base)
        Me.Pn_Encabezado.Controls.Add(Me.Tb_Base)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_Encabezado)
        Me.Pn_Encabezado.Controls.Add(Me.Tb_Encabezado)
        Me.Pn_Encabezado.Controls.Add(Me.LbJustificacion)
        Me.Pn_Encabezado.Controls.Add(Me.Tb_Justificacion)
        Me.Pn_Encabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Encabezado.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Encabezado.Name = "Pn_Encabezado"
        Me.Pn_Encabezado.Size = New System.Drawing.Size(804, 150)
        Me.Pn_Encabezado.TabIndex = 1
        '
        'Lb_Origen
        '
        Me.Lb_Origen.AutoSize = True
        Me.Lb_Origen.Location = New System.Drawing.Point(15, 10)
        Me.Lb_Origen.Name = "Lb_Origen"
        Me.Lb_Origen.Size = New System.Drawing.Size(41, 13)
        Me.Lb_Origen.TabIndex = 0
        Me.Lb_Origen.Text = "Origen:"
        '
        'Tb_Origen
        '
        Me.Tb_Origen.BackColor = System.Drawing.SystemColors.Control
        Me.Tb_Origen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tb_Origen.Enabled = False
        Me.Tb_Origen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_Origen.Location = New System.Drawing.Point(59, 7)
        Me.Tb_Origen.Name = "Tb_Origen"
        Me.Tb_Origen.Size = New System.Drawing.Size(728, 20)
        Me.Tb_Origen.TabIndex = 1
        '
        'Lb_Base
        '
        Me.Lb_Base.AutoSize = True
        Me.Lb_Base.Location = New System.Drawing.Point(22, 36)
        Me.Lb_Base.Name = "Lb_Base"
        Me.Lb_Base.Size = New System.Drawing.Size(34, 13)
        Me.Lb_Base.TabIndex = 2
        Me.Lb_Base.Text = "Base:"
        '
        'Tb_Base
        '
        Me.Tb_Base.BackColor = System.Drawing.SystemColors.Control
        Me.Tb_Base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tb_Base.Enabled = False
        Me.Tb_Base.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_Base.Location = New System.Drawing.Point(59, 33)
        Me.Tb_Base.Name = "Tb_Base"
        Me.Tb_Base.Size = New System.Drawing.Size(728, 20)
        Me.Tb_Base.TabIndex = 3
        '
        'LbJustificacion
        '
        Me.LbJustificacion.AutoSize = True
        Me.LbJustificacion.Location = New System.Drawing.Point(405, 62)
        Me.LbJustificacion.Name = "LbJustificacion"
        Me.LbJustificacion.Size = New System.Drawing.Size(68, 13)
        Me.LbJustificacion.TabIndex = 8
        Me.LbJustificacion.Text = "Justificación:"
        '
        'Tb_Justificacion
        '
        Me.Tb_Justificacion.Location = New System.Drawing.Point(402, 78)
        Me.Tb_Justificacion.MaxLength = 299
        Me.Tb_Justificacion.Multiline = True
        Me.Tb_Justificacion.Name = "Tb_Justificacion"
        Me.Tb_Justificacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tb_Justificacion.Size = New System.Drawing.Size(385, 63)
        Me.Tb_Justificacion.TabIndex = 9
        '
        'Dtp_FechaSolicitud
        '
        Me.Dtp_FechaSolicitud.Checked = False
        Me.Dtp_FechaSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaSolicitud.Location = New System.Drawing.Point(697, 4)
        Me.Dtp_FechaSolicitud.Name = "Dtp_FechaSolicitud"
        Me.Dtp_FechaSolicitud.ShowCheckBox = True
        Me.Dtp_FechaSolicitud.Size = New System.Drawing.Size(101, 20)
        Me.Dtp_FechaSolicitud.TabIndex = 5
        Me.Dtp_FechaSolicitud.Tag = "11"
        '
        'Pn_Opciones
        '
        Me.Pn_Opciones.Controls.Add(Me.Dtp_FechaSolicitud)
        Me.Pn_Opciones.Controls.Add(Me.Lb_FechaSolicitud)
        Me.Pn_Opciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Opciones.Location = New System.Drawing.Point(0, 485)
        Me.Pn_Opciones.Name = "Pn_Opciones"
        Me.Pn_Opciones.Size = New System.Drawing.Size(804, 30)
        Me.Pn_Opciones.TabIndex = 11
        '
        'Lb_FechaSolicitud
        '
        Me.Lb_FechaSolicitud.AutoSize = True
        Me.Lb_FechaSolicitud.Location = New System.Drawing.Point(494, 7)
        Me.Lb_FechaSolicitud.Name = "Lb_FechaSolicitud"
        Me.Lb_FechaSolicitud.Size = New System.Drawing.Size(200, 13)
        Me.Lb_FechaSolicitud.TabIndex = 4
        Me.Lb_FechaSolicitud.Text = "Aplicar Fecha Solicitud a todos los Ítems:"
        '
        'Fr_SolicitudMaquinaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 601)
        Me.Controls.Add(Me.Pn_ItemSolicitudMaquinaria)
        Me.Controls.Add(Me.Pn_Encabezado)
        Me.Controls.Add(Me.Pn_Opciones)
        Me.Controls.Add(Me.Pn_PersonasAsociadas)
        Me.Controls.Add(Me.Pn_Botones)
        Me.Name = "Fr_SolicitudMaquinaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Solicitud de Maquinaria y Equipo"
        Me.Pn_ItemSolicitudMaquinaria.ResumeLayout(False)
        CType(Me.Dgv_ItemSolicitudMaquinaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_TituloItemSolicitudMaquinaria.ResumeLayout(False)
        Me.Pn_Botones.ResumeLayout(False)
        Me.Pn_Botones.PerformLayout()
        Me.Pn_PersonasAsociadas.ResumeLayout(False)
        Me.Pn_PersonasAsociadas.PerformLayout()
        Me.Pn_Encabezado.ResumeLayout(False)
        Me.Pn_Encabezado.PerformLayout()
        Me.Pn_Opciones.ResumeLayout(False)
        Me.Pn_Opciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_ItemSolicitudMaquinaria As System.Windows.Forms.Panel
    Friend WithEvents Dgv_ItemSolicitudMaquinaria As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_TituloItemSolicitudMaquinaria As System.Windows.Forms.Panel
    Friend WithEvents Lb_TituloItemSolicitudMaquinaria As System.Windows.Forms.Label
    Friend WithEvents Lb_Encabezado As System.Windows.Forms.Label
    Friend WithEvents Tb_Encabezado As System.Windows.Forms.TextBox
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents Ll_ActualizarContacto As System.Windows.Forms.LinkLabel
    Friend WithEvents Lb_CodigoArticulo As System.Windows.Forms.Label
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Pn_PersonasAsociadas As System.Windows.Forms.Panel
    Friend WithEvents Cu_BuscarPersonaSolicita As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_ApbAprueba As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_ApbAutoriza As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_ApbSolicita As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Lb_PersonaSolicita As System.Windows.Forms.Label
    Friend WithEvents Lb_PersonaAutoriza As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaAprueba As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_PersonaAprueba As System.Windows.Forms.Label
    Friend WithEvents Pn_Encabezado As System.Windows.Forms.Panel
    Friend WithEvents Lb_Base As System.Windows.Forms.Label
    Friend WithEvents Lb_Origen As System.Windows.Forms.Label
    Public WithEvents Tb_Origen As System.Windows.Forms.TextBox
    Friend WithEvents LbJustificacion As System.Windows.Forms.Label
    Public WithEvents Tb_Base As System.Windows.Forms.TextBox
    Friend WithEvents Tb_Justificacion As System.Windows.Forms.TextBox
    Friend WithEvents Dtp_FechaSolicitud As System.Windows.Forms.DateTimePicker
    Friend WithEvents Pn_Opciones As System.Windows.Forms.Panel
    Friend WithEvents Lb_FechaSolicitud As System.Windows.Forms.Label
    Friend WithEvents IdItemSolicitudMaquinaria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRequiere As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cu_BuscarPersonaAutoriza As FormulariosClasesBase.Cu_BuscarPersona
End Class
