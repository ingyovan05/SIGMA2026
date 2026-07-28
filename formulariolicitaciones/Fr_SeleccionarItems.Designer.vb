<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_SeleccionarItems
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
        Me.Cms_Opciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_MarcarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_DemarcarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tx_Seleccion = New System.Windows.Forms.TextBox()
        Me.Dgv_Lista = New System.Windows.Forms.DataGridView()
        Me.DgvTx_ItemLicitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_ItemCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_TipoUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_CantidadEstimada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvCk_Seleccionado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DgvTx_IdAPU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_IdLicitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_NroLicitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvCk_EsCapitulo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DgvTx_CodigoTipoUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_ValorSinAIU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_ValorConAIU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_Rendimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_IdUsuarioRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_UsuarioRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_IdUsuarioModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_UsuarioModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvCk_Activo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Bt_CargarItemsAPU = New System.Windows.Forms.Button()
        Me.Pn_BusquedaLicitacion = New System.Windows.Forms.Panel()
        Me.Cb_Licitaciones = New System.Windows.Forms.ComboBox()
        Me.Lb_Licitacion = New System.Windows.Forms.Label()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Pn_Seleccion = New System.Windows.Forms.Panel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.MarcarSeleccionadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_Opciones.SuspendLayout()
        CType(Me.Dgv_Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_BusquedaLicitacion.SuspendLayout()
        Me.Pn_Seleccion.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cms_Opciones
        '
        Me.Cms_Opciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_MarcarTodas, Me.MarcarSeleccionadasToolStripMenuItem, Me.Tsmi_DemarcarTodas})
        Me.Cms_Opciones.Name = "Cms_opciones"
        Me.Cms_Opciones.Size = New System.Drawing.Size(188, 92)
        Me.Cms_Opciones.Text = "Cms_opciones"
        '
        'Tsmi_MarcarTodas
        '
        Me.Tsmi_MarcarTodas.Name = "Tsmi_MarcarTodas"
        Me.Tsmi_MarcarTodas.Size = New System.Drawing.Size(157, 22)
        Me.Tsmi_MarcarTodas.Text = "Marcar todas"
        '
        'Tsmi_DemarcarTodas
        '
        Me.Tsmi_DemarcarTodas.Name = "Tsmi_DemarcarTodas"
        Me.Tsmi_DemarcarTodas.Size = New System.Drawing.Size(157, 22)
        Me.Tsmi_DemarcarTodas.Text = "Demarcar todas"
        '
        'Tx_Seleccion
        '
        Me.Tx_Seleccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tx_Seleccion.Location = New System.Drawing.Point(0, 0)
        Me.Tx_Seleccion.Multiline = True
        Me.Tx_Seleccion.Name = "Tx_Seleccion"
        Me.Tx_Seleccion.ReadOnly = True
        Me.Tx_Seleccion.Size = New System.Drawing.Size(780, 56)
        Me.Tx_Seleccion.TabIndex = 0
        Me.Tx_Seleccion.TabStop = False
        '
        'Dgv_Lista
        '
        Me.Dgv_Lista.AllowUserToAddRows = False
        Me.Dgv_Lista.AllowUserToDeleteRows = False
        Me.Dgv_Lista.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Lista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Lista.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.Dgv_Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DgvTx_ItemLicitacion, Me.DgvTx_ItemCliente, Me.DgvTx_Descripcion, Me.DgvTx_TipoUnidad, Me.DgvTx_CantidadEstimada, Me.DgvCk_Seleccionado, Me.DgvTx_IdAPU, Me.DgvTx_IdLicitacion, Me.DgvTx_NroLicitacion, Me.DgvCk_EsCapitulo, Me.DgvTx_CodigoTipoUnidad, Me.DgvTx_ValorSinAIU, Me.DgvTx_ValorConAIU, Me.DgvTx_Rendimiento, Me.DgvTx_FechaRegistro, Me.DgvTx_IdUsuarioRegistro, Me.DgvTx_UsuarioRegistro, Me.DgvTx_FechaModificacion, Me.DgvTx_IdUsuarioModifica, Me.DgvTx_UsuarioModifica, Me.DgvCk_Activo})
        Me.Dgv_Lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Lista.Location = New System.Drawing.Point(0, 40)
        Me.Dgv_Lista.Name = "Dgv_Lista"
        Me.Dgv_Lista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Lista.Size = New System.Drawing.Size(784, 431)
        Me.Dgv_Lista.TabIndex = 3
        '
        'DgvTx_ItemLicitacion
        '
        Me.DgvTx_ItemLicitacion.DataPropertyName = "NROITEMLICITACION"
        Me.DgvTx_ItemLicitacion.HeaderText = "Ítem"
        Me.DgvTx_ItemLicitacion.Name = "DgvTx_ItemLicitacion"
        Me.DgvTx_ItemLicitacion.ReadOnly = True
        Me.DgvTx_ItemLicitacion.ToolTipText = "Número del Ítem A.P.U."
        '
        'DgvTx_ItemCliente
        '
        Me.DgvTx_ItemCliente.DataPropertyName = "NROITEMCLIENTE"
        Me.DgvTx_ItemCliente.HeaderText = "Ítem Cliente"
        Me.DgvTx_ItemCliente.Name = "DgvTx_ItemCliente"
        Me.DgvTx_ItemCliente.ReadOnly = True
        '
        'DgvTx_Descripcion
        '
        Me.DgvTx_Descripcion.DataPropertyName = "DESCRIPCION"
        Me.DgvTx_Descripcion.FillWeight = 300.0!
        Me.DgvTx_Descripcion.HeaderText = "Descripción"
        Me.DgvTx_Descripcion.Name = "DgvTx_Descripcion"
        Me.DgvTx_Descripcion.ReadOnly = True
        Me.DgvTx_Descripcion.ToolTipText = "Descripción o nombre del Ítem A.P.U."
        '
        'DgvTx_TipoUnidad
        '
        Me.DgvTx_TipoUnidad.DataPropertyName = "ABREVIATURA"
        Me.DgvTx_TipoUnidad.HeaderText = "Unidad"
        Me.DgvTx_TipoUnidad.Name = "DgvTx_TipoUnidad"
        Me.DgvTx_TipoUnidad.ReadOnly = True
        '
        'DgvTx_CantidadEstimada
        '
        Me.DgvTx_CantidadEstimada.DataPropertyName = "CANTIDADESTIMADA"
        Me.DgvTx_CantidadEstimada.HeaderText = "Cantidad"
        Me.DgvTx_CantidadEstimada.Name = "DgvTx_CantidadEstimada"
        Me.DgvTx_CantidadEstimada.ReadOnly = True
        '
        'DgvCk_Seleccionado
        '
        Me.DgvCk_Seleccionado.DataPropertyName = "SELECCIONADO"
        Me.DgvCk_Seleccionado.FalseValue = "N"
        Me.DgvCk_Seleccionado.FillWeight = 60.0!
        Me.DgvCk_Seleccionado.HeaderText = ""
        Me.DgvCk_Seleccionado.IndeterminateValue = "N"
        Me.DgvCk_Seleccionado.Name = "DgvCk_Seleccionado"
        Me.DgvCk_Seleccionado.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvCk_Seleccionado.TrueValue = "S"
        '
        'DgvTx_IdAPU
        '
        Me.DgvTx_IdAPU.DataPropertyName = "IDAPU"
        Me.DgvTx_IdAPU.HeaderText = "IdAPU"
        Me.DgvTx_IdAPU.Name = "DgvTx_IdAPU"
        Me.DgvTx_IdAPU.ReadOnly = True
        Me.DgvTx_IdAPU.Visible = False
        '
        'DgvTx_IdLicitacion
        '
        Me.DgvTx_IdLicitacion.DataPropertyName = "IDLICITACION"
        Me.DgvTx_IdLicitacion.HeaderText = "Id. Licitación"
        Me.DgvTx_IdLicitacion.Name = "DgvTx_IdLicitacion"
        Me.DgvTx_IdLicitacion.ReadOnly = True
        Me.DgvTx_IdLicitacion.Visible = False
        '
        'DgvTx_NroLicitacion
        '
        Me.DgvTx_NroLicitacion.DataPropertyName = "NROLICITACION"
        Me.DgvTx_NroLicitacion.HeaderText = "Nro. Licitación"
        Me.DgvTx_NroLicitacion.Name = "DgvTx_NroLicitacion"
        Me.DgvTx_NroLicitacion.ReadOnly = True
        Me.DgvTx_NroLicitacion.Visible = False
        '
        'DgvCk_EsCapitulo
        '
        Me.DgvCk_EsCapitulo.DataPropertyName = "ESCAPITULO"
        Me.DgvCk_EsCapitulo.HeaderText = "Es capítulo"
        Me.DgvCk_EsCapitulo.Name = "DgvCk_EsCapitulo"
        Me.DgvCk_EsCapitulo.ReadOnly = True
        Me.DgvCk_EsCapitulo.Visible = False
        '
        'DgvTx_CodigoTipoUnidad
        '
        Me.DgvTx_CodigoTipoUnidad.DataPropertyName = "CODIGOTIPOUNIDAD"
        Me.DgvTx_CodigoTipoUnidad.HeaderText = "Cód. Tipo Unidad"
        Me.DgvTx_CodigoTipoUnidad.Name = "DgvTx_CodigoTipoUnidad"
        Me.DgvTx_CodigoTipoUnidad.ReadOnly = True
        Me.DgvTx_CodigoTipoUnidad.Visible = False
        '
        'DgvTx_ValorSinAIU
        '
        Me.DgvTx_ValorSinAIU.DataPropertyName = "VALORTOTALITEMSINAIU"
        Me.DgvTx_ValorSinAIU.HeaderText = "Valor Unitario sin AIU"
        Me.DgvTx_ValorSinAIU.Name = "DgvTx_ValorSinAIU"
        Me.DgvTx_ValorSinAIU.ReadOnly = True
        Me.DgvTx_ValorSinAIU.Visible = False
        '
        'DgvTx_ValorConAIU
        '
        Me.DgvTx_ValorConAIU.DataPropertyName = "VALORTOTALITEMCONAIU"
        Me.DgvTx_ValorConAIU.HeaderText = "Valor Unitario con AIU"
        Me.DgvTx_ValorConAIU.Name = "DgvTx_ValorConAIU"
        Me.DgvTx_ValorConAIU.ReadOnly = True
        Me.DgvTx_ValorConAIU.Visible = False
        '
        'DgvTx_Rendimiento
        '
        Me.DgvTx_Rendimiento.DataPropertyName = "RENDIMIENTO"
        Me.DgvTx_Rendimiento.HeaderText = "Rendimiento"
        Me.DgvTx_Rendimiento.Name = "DgvTx_Rendimiento"
        Me.DgvTx_Rendimiento.ReadOnly = True
        Me.DgvTx_Rendimiento.Visible = False
        '
        'DgvTx_FechaRegistro
        '
        Me.DgvTx_FechaRegistro.DataPropertyName = "FECHAREGISTRO"
        Me.DgvTx_FechaRegistro.HeaderText = "Fecha Registro"
        Me.DgvTx_FechaRegistro.Name = "DgvTx_FechaRegistro"
        Me.DgvTx_FechaRegistro.ReadOnly = True
        Me.DgvTx_FechaRegistro.Visible = False
        '
        'DgvTx_IdUsuarioRegistro
        '
        Me.DgvTx_IdUsuarioRegistro.DataPropertyName = "IDUSUARIOREGISTRO"
        Me.DgvTx_IdUsuarioRegistro.HeaderText = "Id. Usuario Registro"
        Me.DgvTx_IdUsuarioRegistro.Name = "DgvTx_IdUsuarioRegistro"
        Me.DgvTx_IdUsuarioRegistro.ReadOnly = True
        Me.DgvTx_IdUsuarioRegistro.Visible = False
        '
        'DgvTx_UsuarioRegistro
        '
        Me.DgvTx_UsuarioRegistro.DataPropertyName = "USUARIOREGISTRO"
        Me.DgvTx_UsuarioRegistro.HeaderText = "Usuario Registro"
        Me.DgvTx_UsuarioRegistro.Name = "DgvTx_UsuarioRegistro"
        Me.DgvTx_UsuarioRegistro.ReadOnly = True
        Me.DgvTx_UsuarioRegistro.Visible = False
        '
        'DgvTx_FechaModificacion
        '
        Me.DgvTx_FechaModificacion.DataPropertyName = "FECHAMODIFICACION"
        Me.DgvTx_FechaModificacion.HeaderText = "Fecha Modificación"
        Me.DgvTx_FechaModificacion.Name = "DgvTx_FechaModificacion"
        Me.DgvTx_FechaModificacion.ReadOnly = True
        Me.DgvTx_FechaModificacion.Visible = False
        '
        'DgvTx_IdUsuarioModifica
        '
        Me.DgvTx_IdUsuarioModifica.DataPropertyName = "IDUSUARIOMODIFICA"
        Me.DgvTx_IdUsuarioModifica.HeaderText = "Id. Usuario Modifica"
        Me.DgvTx_IdUsuarioModifica.Name = "DgvTx_IdUsuarioModifica"
        Me.DgvTx_IdUsuarioModifica.ReadOnly = True
        Me.DgvTx_IdUsuarioModifica.Visible = False
        '
        'DgvTx_UsuarioModifica
        '
        Me.DgvTx_UsuarioModifica.DataPropertyName = "USUARIOMODIFICA"
        Me.DgvTx_UsuarioModifica.HeaderText = "Usuario Modifica"
        Me.DgvTx_UsuarioModifica.Name = "DgvTx_UsuarioModifica"
        Me.DgvTx_UsuarioModifica.ReadOnly = True
        Me.DgvTx_UsuarioModifica.Visible = False
        '
        'DgvCk_Activo
        '
        Me.DgvCk_Activo.DataPropertyName = "ACTIVO"
        Me.DgvCk_Activo.FalseValue = "N"
        Me.DgvCk_Activo.HeaderText = "Activo"
        Me.DgvCk_Activo.IndeterminateValue = "N"
        Me.DgvCk_Activo.Name = "DgvCk_Activo"
        Me.DgvCk_Activo.ReadOnly = True
        Me.DgvCk_Activo.TrueValue = "S"
        Me.DgvCk_Activo.Visible = False
        '
        'Bt_CargarItemsAPU
        '
        Me.Bt_CargarItemsAPU.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_CargarItemsAPU.AutoSize = True
        Me.Bt_CargarItemsAPU.Location = New System.Drawing.Point(662, 9)
        Me.Bt_CargarItemsAPU.Name = "Bt_CargarItemsAPU"
        Me.Bt_CargarItemsAPU.Size = New System.Drawing.Size(110, 23)
        Me.Bt_CargarItemsAPU.TabIndex = 2
        Me.Bt_CargarItemsAPU.Text = "Cargar Ítems A.P.U."
        Me.Bt_CargarItemsAPU.UseVisualStyleBackColor = True
        '
        'Pn_BusquedaLicitacion
        '
        Me.Pn_BusquedaLicitacion.Controls.Add(Me.Cb_Licitaciones)
        Me.Pn_BusquedaLicitacion.Controls.Add(Me.Bt_CargarItemsAPU)
        Me.Pn_BusquedaLicitacion.Controls.Add(Me.Lb_Licitacion)
        Me.Pn_BusquedaLicitacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_BusquedaLicitacion.Location = New System.Drawing.Point(0, 0)
        Me.Pn_BusquedaLicitacion.Name = "Pn_BusquedaLicitacion"
        Me.Pn_BusquedaLicitacion.Size = New System.Drawing.Size(784, 40)
        Me.Pn_BusquedaLicitacion.TabIndex = 5
        '
        'Cb_Licitaciones
        '
        Me.Cb_Licitaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Licitaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Licitaciones.FormattingEnabled = True
        Me.Cb_Licitaciones.Location = New System.Drawing.Point(70, 10)
        Me.Cb_Licitaciones.Name = "Cb_Licitaciones"
        Me.Cb_Licitaciones.Size = New System.Drawing.Size(586, 21)
        Me.Cb_Licitaciones.TabIndex = 3
        '
        'Lb_Licitacion
        '
        Me.Lb_Licitacion.AutoSize = True
        Me.Lb_Licitacion.Location = New System.Drawing.Point(9, 13)
        Me.Lb_Licitacion.Name = "Lb_Licitacion"
        Me.Lb_Licitacion.Size = New System.Drawing.Size(55, 13)
        Me.Lb_Licitacion.TabIndex = 0
        Me.Lb_Licitacion.Text = "Licitación:"
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.AutoSize = True
        Me.Bt_Aceptar.Enabled = False
        Me.Bt_Aceptar.Location = New System.Drawing.Point(544, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 1
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Pn_Seleccion
        '
        Me.Pn_Seleccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pn_Seleccion.Controls.Add(Me.Tx_Seleccion)
        Me.Pn_Seleccion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Seleccion.Location = New System.Drawing.Point(0, 471)
        Me.Pn_Seleccion.Name = "Pn_Seleccion"
        Me.Pn_Seleccion.Size = New System.Drawing.Size(784, 60)
        Me.Pn_Seleccion.TabIndex = 6
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.AutoSize = True
        Me.Bt_Cerrar.Location = New System.Drawing.Point(706, 3)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 2
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.AutoSize = True
        Me.Bt_Cancelar.Enabled = False
        Me.Bt_Cancelar.Location = New System.Drawing.Point(625, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Flp_Botones.Controls.Add(Me.Bt_Cerrar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 531)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(784, 30)
        Me.Flp_Botones.TabIndex = 4
        '
        'MarcarSeleccionadasToolStripMenuItem
        '
        Me.MarcarSeleccionadasToolStripMenuItem.Name = "MarcarSeleccionadasToolStripMenuItem"
        Me.MarcarSeleccionadasToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.MarcarSeleccionadasToolStripMenuItem.Text = "Marcar seleccionadas"
        '
        'Fr_SeleccionarItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.Dgv_Lista)
        Me.Controls.Add(Me.Pn_BusquedaLicitacion)
        Me.Controls.Add(Me.Pn_Seleccion)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Name = "Fr_SeleccionarItems"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccionar Ítems A.P.U."
        Me.Cms_Opciones.ResumeLayout(False)
        CType(Me.Dgv_Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_BusquedaLicitacion.ResumeLayout(False)
        Me.Pn_BusquedaLicitacion.PerformLayout()
        Me.Pn_Seleccion.ResumeLayout(False)
        Me.Pn_Seleccion.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.Flp_Botones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cms_Opciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_MarcarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_DemarcarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tx_Seleccion As System.Windows.Forms.TextBox
    Friend WithEvents Dgv_Lista As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_CargarItemsAPU As System.Windows.Forms.Button
    Friend WithEvents Pn_BusquedaLicitacion As System.Windows.Forms.Panel
    Friend WithEvents Lb_Licitacion As System.Windows.Forms.Label
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Pn_Seleccion As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Cb_Licitaciones As System.Windows.Forms.ComboBox
    Friend WithEvents DgvTx_ItemLicitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_ItemCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_TipoUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_CantidadEstimada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvCk_Seleccionado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DgvTx_IdAPU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_IdLicitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_NroLicitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvCk_EsCapitulo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DgvTx_CodigoTipoUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_ValorSinAIU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_ValorConAIU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_Rendimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_IdUsuarioRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_UsuarioRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_FechaModificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_IdUsuarioModifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_UsuarioModifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvCk_Activo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MarcarSeleccionadasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
