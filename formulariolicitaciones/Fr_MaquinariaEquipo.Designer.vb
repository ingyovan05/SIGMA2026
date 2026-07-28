<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_MaquinariaEquipo
    Inherits Form

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
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Pn_Datos = New System.Windows.Forms.Panel()
        Me.Lb_Codigo = New System.Windows.Forms.Label()
        Me.Tx_Codigo = New System.Windows.Forms.TextBox()
        Me.Lb_IdArticulo = New System.Windows.Forms.Label()
        Me.Tx_IdArticulo = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarArticulo = New System.Windows.Forms.Button()
        Me.Lb_Descripcion = New System.Windows.Forms.Label()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Lb_Combustible = New System.Windows.Forms.Label()
        Me.Lb_CombustiblexHora = New System.Windows.Forms.Label()
        Me.Lb_TarifaIsmocol = New System.Windows.Forms.Label()
        Me.Lb_TarifaIsmxHora = New System.Windows.Forms.Label()
        Me.Lb_TarifaComercial = New System.Windows.Forms.Label()
        Me.Lb_TarifaComxHora = New System.Windows.Forms.Label()
        Me.Ck_Activo = New System.Windows.Forms.CheckBox()
        Me.Dgv_ManoDeObra = New System.Windows.Forms.DataGridView()
        Me.IdManoDeObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionMO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadMO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActivoMO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TarifaIsmocol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TarifaComercial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRegistroMO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUsuarioRegistroMO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaModificacionMO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUsuarioModificaMO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_TituloManoObra = New System.Windows.Forms.Panel()
        Me.Lb_ManoDeObra = New System.Windows.Forms.Label()
        Me.Tc_Recursos = New System.Windows.Forms.TabControl()
        Me.Tp_Material = New System.Windows.Forms.TabPage()
        Me.Dgv_Material = New System.Windows.Forms.DataGridView()
        Me.IdMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionMA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadMA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActivoMA = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ValorIsmocol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorComercial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRegistroMA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUsuarioRegistroMA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaModificacionMA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUsuarioModificaMA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tp_ManoDeObra = New System.Windows.Forms.TabPage()
        Me.CuTx_TarifaIsmocol = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.CuTx_TarifaComercial = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.CuTx_Combustible = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Datos.SuspendLayout()
        CType(Me.Dgv_ManoDeObra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_TituloManoObra.SuspendLayout()
        Me.Tc_Recursos.SuspendLayout()
        Me.Tp_Material.SuspendLayout()
        CType(Me.Dgv_Material, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tp_ManoDeObra.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 533)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(624, 30)
        Me.Flp_Botones.TabIndex = 3
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(546, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(465, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Pn_Datos
        '
        Me.Pn_Datos.Controls.Add(Me.CuTx_Combustible)
        Me.Pn_Datos.Controls.Add(Me.CuTx_TarifaComercial)
        Me.Pn_Datos.Controls.Add(Me.CuTx_TarifaIsmocol)
        Me.Pn_Datos.Controls.Add(Me.Lb_Codigo)
        Me.Pn_Datos.Controls.Add(Me.Tx_Codigo)
        Me.Pn_Datos.Controls.Add(Me.Lb_IdArticulo)
        Me.Pn_Datos.Controls.Add(Me.Tx_IdArticulo)
        Me.Pn_Datos.Controls.Add(Me.Bt_BuscarArticulo)
        Me.Pn_Datos.Controls.Add(Me.Lb_Descripcion)
        Me.Pn_Datos.Controls.Add(Me.Tx_Descripcion)
        Me.Pn_Datos.Controls.Add(Me.Lb_Combustible)
        Me.Pn_Datos.Controls.Add(Me.Lb_CombustiblexHora)
        Me.Pn_Datos.Controls.Add(Me.Lb_TarifaIsmocol)
        Me.Pn_Datos.Controls.Add(Me.Lb_TarifaIsmxHora)
        Me.Pn_Datos.Controls.Add(Me.Lb_TarifaComercial)
        Me.Pn_Datos.Controls.Add(Me.Lb_TarifaComxHora)
        Me.Pn_Datos.Controls.Add(Me.Ck_Activo)
        Me.Pn_Datos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Datos.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Datos.Name = "Pn_Datos"
        Me.Pn_Datos.Size = New System.Drawing.Size(624, 175)
        Me.Pn_Datos.TabIndex = 0
        '
        'Lb_Codigo
        '
        Me.Lb_Codigo.AutoSize = True
        Me.Lb_Codigo.Location = New System.Drawing.Point(45, 23)
        Me.Lb_Codigo.Name = "Lb_Codigo"
        Me.Lb_Codigo.Size = New System.Drawing.Size(43, 13)
        Me.Lb_Codigo.TabIndex = 0
        Me.Lb_Codigo.Text = "Código:"
        '
        'Tx_Codigo
        '
        Me.Tx_Codigo.Enabled = False
        Me.Tx_Codigo.Location = New System.Drawing.Point(91, 20)
        Me.Tx_Codigo.Name = "Tx_Codigo"
        Me.Tx_Codigo.ReadOnly = True
        Me.Tx_Codigo.Size = New System.Drawing.Size(100, 20)
        Me.Tx_Codigo.TabIndex = 1
        '
        'Lb_IdArticulo
        '
        Me.Lb_IdArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_IdArticulo.AutoSize = True
        Me.Lb_IdArticulo.Location = New System.Drawing.Point(333, 23)
        Me.Lb_IdArticulo.Name = "Lb_IdArticulo"
        Me.Lb_IdArticulo.Size = New System.Drawing.Size(59, 13)
        Me.Lb_IdArticulo.TabIndex = 2
        Me.Lb_IdArticulo.Text = "Id Artículo:"
        '
        'Tx_IdArticulo
        '
        Me.Tx_IdArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_IdArticulo.Location = New System.Drawing.Point(395, 20)
        Me.Tx_IdArticulo.MaxLength = 10
        Me.Tx_IdArticulo.Name = "Tx_IdArticulo"
        Me.Tx_IdArticulo.Size = New System.Drawing.Size(100, 20)
        Me.Tx_IdArticulo.TabIndex = 3
        '
        'Bt_BuscarArticulo
        '
        Me.Bt_BuscarArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_BuscarArticulo.AutoSize = True
        Me.Bt_BuscarArticulo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_BuscarArticulo.Location = New System.Drawing.Point(501, 18)
        Me.Bt_BuscarArticulo.Name = "Bt_BuscarArticulo"
        Me.Bt_BuscarArticulo.Size = New System.Drawing.Size(26, 23)
        Me.Bt_BuscarArticulo.TabIndex = 4
        Me.Bt_BuscarArticulo.Text = "..."
        Me.Bt_BuscarArticulo.UseVisualStyleBackColor = True
        '
        'Lb_Descripcion
        '
        Me.Lb_Descripcion.AutoSize = True
        Me.Lb_Descripcion.Location = New System.Drawing.Point(22, 49)
        Me.Lb_Descripcion.Name = "Lb_Descripcion"
        Me.Lb_Descripcion.Size = New System.Drawing.Size(66, 13)
        Me.Lb_Descripcion.TabIndex = 5
        Me.Lb_Descripcion.Text = "Descripción:"
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Descripcion.Location = New System.Drawing.Point(91, 46)
        Me.Tx_Descripcion.MaxLength = 200
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(521, 40)
        Me.Tx_Descripcion.TabIndex = 6
        '
        'Lb_Combustible
        '
        Me.Lb_Combustible.AutoSize = True
        Me.Lb_Combustible.Location = New System.Drawing.Point(21, 95)
        Me.Lb_Combustible.Name = "Lb_Combustible"
        Me.Lb_Combustible.Size = New System.Drawing.Size(67, 13)
        Me.Lb_Combustible.TabIndex = 7
        Me.Lb_Combustible.Text = "Combustible:"
        '
        'Lb_CombustiblexHora
        '
        Me.Lb_CombustiblexHora.AutoSize = True
        Me.Lb_CombustiblexHora.Location = New System.Drawing.Point(197, 95)
        Me.Lb_CombustiblexHora.Name = "Lb_CombustiblexHora"
        Me.Lb_CombustiblexHora.Size = New System.Drawing.Size(38, 13)
        Me.Lb_CombustiblexHora.TabIndex = 9
        Me.Lb_CombustiblexHora.Text = "/ Hora"
        '
        'Lb_TarifaIsmocol
        '
        Me.Lb_TarifaIsmocol.AutoSize = True
        Me.Lb_TarifaIsmocol.Location = New System.Drawing.Point(12, 122)
        Me.Lb_TarifaIsmocol.Name = "Lb_TarifaIsmocol"
        Me.Lb_TarifaIsmocol.Size = New System.Drawing.Size(76, 13)
        Me.Lb_TarifaIsmocol.TabIndex = 10
        Me.Lb_TarifaIsmocol.Text = "Tarifa Ismocol:"
        '
        'Lb_TarifaIsmxHora
        '
        Me.Lb_TarifaIsmxHora.AutoSize = True
        Me.Lb_TarifaIsmxHora.Location = New System.Drawing.Point(197, 122)
        Me.Lb_TarifaIsmxHora.Name = "Lb_TarifaIsmxHora"
        Me.Lb_TarifaIsmxHora.Size = New System.Drawing.Size(38, 13)
        Me.Lb_TarifaIsmxHora.TabIndex = 12
        Me.Lb_TarifaIsmxHora.Text = "/ Hora"
        '
        'Lb_TarifaComercial
        '
        Me.Lb_TarifaComercial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_TarifaComercial.AutoSize = True
        Me.Lb_TarifaComercial.Location = New System.Drawing.Point(306, 122)
        Me.Lb_TarifaComercial.Name = "Lb_TarifaComercial"
        Me.Lb_TarifaComercial.Size = New System.Drawing.Size(86, 13)
        Me.Lb_TarifaComercial.TabIndex = 13
        Me.Lb_TarifaComercial.Text = "Tarifa Comercial:"
        '
        'Lb_TarifaComxHora
        '
        Me.Lb_TarifaComxHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_TarifaComxHora.AutoSize = True
        Me.Lb_TarifaComxHora.Location = New System.Drawing.Point(501, 122)
        Me.Lb_TarifaComxHora.Name = "Lb_TarifaComxHora"
        Me.Lb_TarifaComxHora.Size = New System.Drawing.Size(38, 13)
        Me.Lb_TarifaComxHora.TabIndex = 15
        Me.Lb_TarifaComxHora.Text = "/ Hora"
        '
        'Ck_Activo
        '
        Me.Ck_Activo.AutoSize = True
        Me.Ck_Activo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_Activo.Checked = True
        Me.Ck_Activo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_Activo.Location = New System.Drawing.Point(46, 145)
        Me.Ck_Activo.Name = "Ck_Activo"
        Me.Ck_Activo.Size = New System.Drawing.Size(59, 17)
        Me.Ck_Activo.TabIndex = 16
        Me.Ck_Activo.Text = "Activo:"
        Me.Ck_Activo.ThreeState = True
        Me.Ck_Activo.UseVisualStyleBackColor = True
        '
        'Dgv_ManoDeObra
        '
        Me.Dgv_ManoDeObra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_ManoDeObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_ManoDeObra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdManoDeObra, Me.DescripcionMO, Me.CantidadMO, Me.ActivoMO, Me.TarifaIsmocol, Me.TarifaComercial, Me.FechaRegistroMO, Me.IdUsuarioRegistroMO, Me.FechaModificacionMO, Me.IdUsuarioModificaMO})
        Me.Dgv_ManoDeObra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ManoDeObra.Location = New System.Drawing.Point(3, 3)
        Me.Dgv_ManoDeObra.Name = "Dgv_ManoDeObra"
        Me.Dgv_ManoDeObra.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_ManoDeObra.Size = New System.Drawing.Size(610, 302)
        Me.Dgv_ManoDeObra.TabIndex = 0
        '
        'IdManoDeObra
        '
        Me.IdManoDeObra.DataPropertyName = "IDMANODEOBRA"
        Me.IdManoDeObra.FillWeight = 70.0!
        Me.IdManoDeObra.HeaderText = "Código"
        Me.IdManoDeObra.MaxInputLength = 10
        Me.IdManoDeObra.Name = "IdManoDeObra"
        '
        'DescripcionMO
        '
        Me.DescripcionMO.DataPropertyName = "DESCRIPCION"
        Me.DescripcionMO.FillWeight = 300.0!
        Me.DescripcionMO.HeaderText = "Descripción"
        Me.DescripcionMO.MaxInputLength = 100
        Me.DescripcionMO.Name = "DescripcionMO"
        Me.DescripcionMO.ReadOnly = True
        '
        'CantidadMO
        '
        Me.CantidadMO.DataPropertyName = "CANTIDAD"
        Me.CantidadMO.FillWeight = 70.0!
        Me.CantidadMO.HeaderText = "Cantidad"
        Me.CantidadMO.MaxInputLength = 2
        Me.CantidadMO.Name = "CantidadMO"
        '
        'ActivoMO
        '
        Me.ActivoMO.DataPropertyName = "ACTIVO"
        Me.ActivoMO.FalseValue = "N"
        Me.ActivoMO.HeaderText = "Activo"
        Me.ActivoMO.Name = "ActivoMO"
        Me.ActivoMO.ReadOnly = True
        Me.ActivoMO.TrueValue = "S"
        Me.ActivoMO.Visible = False
        '
        'TarifaIsmocol
        '
        Me.TarifaIsmocol.DataPropertyName = "TARIFAISMOCOLXHORAHOMBRE"
        Me.TarifaIsmocol.HeaderText = "Tarifa Ismocol"
        Me.TarifaIsmocol.MaxInputLength = 18
        Me.TarifaIsmocol.Name = "TarifaIsmocol"
        Me.TarifaIsmocol.ReadOnly = True
        Me.TarifaIsmocol.Visible = False
        '
        'TarifaComercial
        '
        Me.TarifaComercial.DataPropertyName = "TARIFACOMERCIALXHORAHOMBRE"
        Me.TarifaComercial.HeaderText = "Tarifa Comercial"
        Me.TarifaComercial.MaxInputLength = 18
        Me.TarifaComercial.Name = "TarifaComercial"
        Me.TarifaComercial.ReadOnly = True
        Me.TarifaComercial.Visible = False
        '
        'FechaRegistroMO
        '
        Me.FechaRegistroMO.DataPropertyName = "FECHAREGISTRO"
        Me.FechaRegistroMO.HeaderText = "Fecha Registro"
        Me.FechaRegistroMO.Name = "FechaRegistroMO"
        Me.FechaRegistroMO.ReadOnly = True
        Me.FechaRegistroMO.Visible = False
        '
        'IdUsuarioRegistroMO
        '
        Me.IdUsuarioRegistroMO.DataPropertyName = "IDUSUARIOREGISTRO"
        Me.IdUsuarioRegistroMO.HeaderText = "Id. Usuario Registro"
        Me.IdUsuarioRegistroMO.Name = "IdUsuarioRegistroMO"
        Me.IdUsuarioRegistroMO.ReadOnly = True
        Me.IdUsuarioRegistroMO.Visible = False
        '
        'FechaModificacionMO
        '
        Me.FechaModificacionMO.DataPropertyName = "FECHAMODIFICACION"
        Me.FechaModificacionMO.HeaderText = "Fecha Modificación"
        Me.FechaModificacionMO.Name = "FechaModificacionMO"
        Me.FechaModificacionMO.ReadOnly = True
        Me.FechaModificacionMO.Visible = False
        '
        'IdUsuarioModificaMO
        '
        Me.IdUsuarioModificaMO.DataPropertyName = "IDUSUARIOMODIFICA"
        Me.IdUsuarioModificaMO.HeaderText = "Id. Usuario Modifica"
        Me.IdUsuarioModificaMO.Name = "IdUsuarioModificaMO"
        Me.IdUsuarioModificaMO.ReadOnly = True
        Me.IdUsuarioModificaMO.Visible = False
        '
        'Pn_TituloManoObra
        '
        Me.Pn_TituloManoObra.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Pn_TituloManoObra.Controls.Add(Me.Lb_ManoDeObra)
        Me.Pn_TituloManoObra.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloManoObra.Location = New System.Drawing.Point(0, 175)
        Me.Pn_TituloManoObra.Name = "Pn_TituloManoObra"
        Me.Pn_TituloManoObra.Size = New System.Drawing.Size(624, 24)
        Me.Pn_TituloManoObra.TabIndex = 1
        '
        'Lb_ManoDeObra
        '
        Me.Lb_ManoDeObra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_ManoDeObra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_ManoDeObra.Location = New System.Drawing.Point(0, 0)
        Me.Lb_ManoDeObra.Name = "Lb_ManoDeObra"
        Me.Lb_ManoDeObra.Size = New System.Drawing.Size(624, 24)
        Me.Lb_ManoDeObra.TabIndex = 0
        Me.Lb_ManoDeObra.Text = "Recursos asociados"
        Me.Lb_ManoDeObra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tc_Recursos
        '
        Me.Tc_Recursos.Controls.Add(Me.Tp_Material)
        Me.Tc_Recursos.Controls.Add(Me.Tp_ManoDeObra)
        Me.Tc_Recursos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tc_Recursos.Location = New System.Drawing.Point(0, 199)
        Me.Tc_Recursos.Name = "Tc_Recursos"
        Me.Tc_Recursos.SelectedIndex = 0
        Me.Tc_Recursos.Size = New System.Drawing.Size(624, 334)
        Me.Tc_Recursos.TabIndex = 2
        '
        'Tp_Material
        '
        Me.Tp_Material.Controls.Add(Me.Dgv_Material)
        Me.Tp_Material.Location = New System.Drawing.Point(4, 22)
        Me.Tp_Material.Name = "Tp_Material"
        Me.Tp_Material.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_Material.Size = New System.Drawing.Size(616, 308)
        Me.Tp_Material.TabIndex = 0
        Me.Tp_Material.Text = "Materiales"
        Me.Tp_Material.UseVisualStyleBackColor = True
        '
        'Dgv_Material
        '
        Me.Dgv_Material.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Material.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Material.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdMaterial, Me.DescripcionMA, Me.TipoUnidad, Me.Articulo, Me.CantidadMA, Me.ActivoMA, Me.ValorIsmocol, Me.ValorComercial, Me.FechaRegistroMA, Me.IdUsuarioRegistroMA, Me.FechaModificacionMA, Me.IdUsuarioModificaMA})
        Me.Dgv_Material.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Material.Location = New System.Drawing.Point(3, 3)
        Me.Dgv_Material.Name = "Dgv_Material"
        Me.Dgv_Material.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Material.Size = New System.Drawing.Size(610, 302)
        Me.Dgv_Material.TabIndex = 0
        '
        'IdMaterial
        '
        Me.IdMaterial.DataPropertyName = "IDMATERIAL"
        Me.IdMaterial.FillWeight = 60.0!
        Me.IdMaterial.HeaderText = "Código"
        Me.IdMaterial.MaxInputLength = 10
        Me.IdMaterial.Name = "IdMaterial"
        '
        'DescripcionMA
        '
        Me.DescripcionMA.DataPropertyName = "DESCRIPCION"
        Me.DescripcionMA.FillWeight = 300.0!
        Me.DescripcionMA.HeaderText = "Descripción"
        Me.DescripcionMA.MaxInputLength = 100
        Me.DescripcionMA.Name = "DescripcionMA"
        Me.DescripcionMA.ReadOnly = True
        '
        'TipoUnidad
        '
        Me.TipoUnidad.DataPropertyName = "ABREVIATURA"
        Me.TipoUnidad.FillWeight = 60.0!
        Me.TipoUnidad.HeaderText = "Unidad"
        Me.TipoUnidad.Name = "TipoUnidad"
        Me.TipoUnidad.ReadOnly = True
        '
        'Articulo
        '
        Me.Articulo.DataPropertyName = "NOMBREDESCRIPTIVO"
        Me.Articulo.FillWeight = 200.0!
        Me.Articulo.HeaderText = "Artículo"
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        '
        'CantidadMA
        '
        Me.CantidadMA.DataPropertyName = "CANTIDAD"
        Me.CantidadMA.FillWeight = 70.0!
        Me.CantidadMA.HeaderText = "Cantidad"
        Me.CantidadMA.MaxInputLength = 2
        Me.CantidadMA.Name = "CantidadMA"
        '
        'ActivoMA
        '
        Me.ActivoMA.DataPropertyName = "ACTIVO"
        Me.ActivoMA.FalseValue = "N"
        Me.ActivoMA.HeaderText = "Activo"
        Me.ActivoMA.Name = "ActivoMA"
        Me.ActivoMA.ReadOnly = True
        Me.ActivoMA.TrueValue = "S"
        Me.ActivoMA.Visible = False
        '
        'ValorIsmocol
        '
        Me.ValorIsmocol.DataPropertyName = "VALORISMOCOL"
        Me.ValorIsmocol.HeaderText = "Valor Ismocol"
        Me.ValorIsmocol.MaxInputLength = 18
        Me.ValorIsmocol.Name = "ValorIsmocol"
        Me.ValorIsmocol.ReadOnly = True
        Me.ValorIsmocol.Visible = False
        '
        'ValorComercial
        '
        Me.ValorComercial.DataPropertyName = "VALORCOMERCIAL"
        Me.ValorComercial.HeaderText = "Valor Comercial"
        Me.ValorComercial.MaxInputLength = 18
        Me.ValorComercial.Name = "ValorComercial"
        Me.ValorComercial.ReadOnly = True
        Me.ValorComercial.Visible = False
        '
        'FechaRegistroMA
        '
        Me.FechaRegistroMA.DataPropertyName = "FECHAREGISTRO"
        Me.FechaRegistroMA.HeaderText = "Fecha Registro"
        Me.FechaRegistroMA.Name = "FechaRegistroMA"
        Me.FechaRegistroMA.ReadOnly = True
        Me.FechaRegistroMA.Visible = False
        '
        'IdUsuarioRegistroMA
        '
        Me.IdUsuarioRegistroMA.DataPropertyName = "IDUSUARIOREGISTRO"
        Me.IdUsuarioRegistroMA.HeaderText = "Id. Usuario Registro"
        Me.IdUsuarioRegistroMA.Name = "IdUsuarioRegistroMA"
        Me.IdUsuarioRegistroMA.ReadOnly = True
        Me.IdUsuarioRegistroMA.Visible = False
        '
        'FechaModificacionMA
        '
        Me.FechaModificacionMA.DataPropertyName = "FECHAMODIFICACION"
        Me.FechaModificacionMA.HeaderText = "Fecha Modificación"
        Me.FechaModificacionMA.Name = "FechaModificacionMA"
        Me.FechaModificacionMA.ReadOnly = True
        Me.FechaModificacionMA.Visible = False
        '
        'IdUsuarioModificaMA
        '
        Me.IdUsuarioModificaMA.DataPropertyName = "IDUSUARIOMODIFICA"
        Me.IdUsuarioModificaMA.HeaderText = "Id. Usuario Modifica"
        Me.IdUsuarioModificaMA.Name = "IdUsuarioModificaMA"
        Me.IdUsuarioModificaMA.ReadOnly = True
        Me.IdUsuarioModificaMA.Visible = False
        '
        'Tp_ManoDeObra
        '
        Me.Tp_ManoDeObra.Controls.Add(Me.Dgv_ManoDeObra)
        Me.Tp_ManoDeObra.Location = New System.Drawing.Point(4, 22)
        Me.Tp_ManoDeObra.Name = "Tp_ManoDeObra"
        Me.Tp_ManoDeObra.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_ManoDeObra.Size = New System.Drawing.Size(616, 308)
        Me.Tp_ManoDeObra.TabIndex = 1
        Me.Tp_ManoDeObra.Text = "Mano de Obra"
        Me.Tp_ManoDeObra.UseVisualStyleBackColor = True
        '
        'CuTx_TarifaIsmocol
        '
        Me.CuTx_TarifaIsmocol.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(67)
        Me.CuTx_TarifaIsmocol.Location = New System.Drawing.Point(91, 119)
        Me.CuTx_TarifaIsmocol.MaxLongitudTexto = 18
        Me.CuTx_TarifaIsmocol.Name = "CuTx_TarifaIsmocol"
        Me.CuTx_TarifaIsmocol.PosicionesDecimales = CType(0US, UShort)
        Me.CuTx_TarifaIsmocol.Size = New System.Drawing.Size(100, 20)
        Me.CuTx_TarifaIsmocol.SoloLectura = False
        Me.CuTx_TarifaIsmocol.TabIndex = 11
        Me.CuTx_TarifaIsmocol.Tag = "633"
        Me.CuTx_TarifaIsmocol.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'CuTx_TarifaComercial
        '
        Me.CuTx_TarifaComercial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CuTx_TarifaComercial.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(67)
        Me.CuTx_TarifaComercial.Location = New System.Drawing.Point(395, 119)
        Me.CuTx_TarifaComercial.MaxLongitudTexto = 18
        Me.CuTx_TarifaComercial.Name = "CuTx_TarifaComercial"
        Me.CuTx_TarifaComercial.PosicionesDecimales = CType(0US, UShort)
        Me.CuTx_TarifaComercial.Size = New System.Drawing.Size(100, 20)
        Me.CuTx_TarifaComercial.SoloLectura = False
        Me.CuTx_TarifaComercial.TabIndex = 14
        Me.CuTx_TarifaComercial.Tag = "633"
        Me.CuTx_TarifaComercial.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'CuTx_Combustible
        '
        Me.CuTx_Combustible.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(78)
        Me.CuTx_Combustible.Location = New System.Drawing.Point(91, 92)
        Me.CuTx_Combustible.MaxLongitudTexto = 16
        Me.CuTx_Combustible.Name = "CuTx_Combustible"
        Me.CuTx_Combustible.PosicionesDecimales = CType(4US, UShort)
        Me.CuTx_Combustible.Size = New System.Drawing.Size(100, 20)
        Me.CuTx_Combustible.SoloLectura = False
        Me.CuTx_Combustible.TabIndex = 8
        Me.CuTx_Combustible.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Fr_MaquinariaEquipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 563)
        Me.Controls.Add(Me.Tc_Recursos)
        Me.Controls.Add(Me.Pn_TituloManoObra)
        Me.Controls.Add(Me.Pn_Datos)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Name = "Fr_MaquinariaEquipo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionando Maquinaria y Equipos"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Datos.ResumeLayout(False)
        Me.Pn_Datos.PerformLayout()
        CType(Me.Dgv_ManoDeObra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_TituloManoObra.ResumeLayout(False)
        Me.Tc_Recursos.ResumeLayout(False)
        Me.Tp_Material.ResumeLayout(False)
        CType(Me.Dgv_Material, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tp_ManoDeObra.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Pn_Datos As System.Windows.Forms.Panel
    Friend WithEvents Ck_Activo As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Tx_IdArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TarifaComercial As System.Windows.Forms.Label
    Friend WithEvents Lb_TarifaIsmocol As System.Windows.Forms.Label
    Friend WithEvents Lb_Combustible As System.Windows.Forms.Label
    Friend WithEvents Lb_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Lb_IdArticulo As System.Windows.Forms.Label
    Friend WithEvents Lb_Codigo As System.Windows.Forms.Label
    Friend WithEvents Lb_TarifaComxHora As System.Windows.Forms.Label
    Friend WithEvents Lb_TarifaIsmxHora As System.Windows.Forms.Label
    Friend WithEvents Lb_CombustiblexHora As System.Windows.Forms.Label
    Friend WithEvents Bt_BuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents Dgv_ManoDeObra As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_TituloManoObra As System.Windows.Forms.Panel
    Friend WithEvents Lb_ManoDeObra As System.Windows.Forms.Label
    Friend WithEvents Tc_Recursos As System.Windows.Forms.TabControl
    Friend WithEvents Tp_Material As System.Windows.Forms.TabPage
    Friend WithEvents Dgv_Material As System.Windows.Forms.DataGridView
    Friend WithEvents Tp_ManoDeObra As System.Windows.Forms.TabPage
    Friend WithEvents IdManoDeObra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionMO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadMO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivoMO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TarifaIsmocol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TarifaComercial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRegistroMO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdUsuarioRegistroMO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaModificacionMO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdUsuarioModificaMO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionMA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Articulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadMA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivoMA As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ValorIsmocol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorComercial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRegistroMA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdUsuarioRegistroMA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaModificacionMA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdUsuarioModificaMA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuTx_TarifaComercial As FormulariosClasesBase.Cu_TextBoxDecimal
    Friend WithEvents CuTx_TarifaIsmocol As FormulariosClasesBase.Cu_TextBoxDecimal
    Friend WithEvents CuTx_Combustible As FormulariosClasesBase.Cu_TextBoxDecimal
End Class
