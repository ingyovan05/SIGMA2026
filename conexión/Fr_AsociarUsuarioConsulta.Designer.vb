<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AsociarUsuarioConsulta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_AsociarUsuarioConsulta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Pn_BusquedaUsuario = New System.Windows.Forms.Panel()
        Me.Bt_CargarConsultas = New System.Windows.Forms.Button()
        Me.Cu_BuscarPersona = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_NombreUsuario = New System.Windows.Forms.Label()
        Me.Dgv_PermisosConsultas = New System.Windows.Forms.DataGridView()
        Me.IDCONSULTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONSULTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIENEPERMISO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Pn_NombreConsulta = New System.Windows.Forms.Panel()
        Me.Tx_NombreConsulta = New System.Windows.Forms.TextBox()
        Me.Tsmi_MarcarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_DemarcarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_opciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_BusquedaUsuario.SuspendLayout()
        CType(Me.Dgv_PermisosConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_NombreConsulta.SuspendLayout()
        Me.Cms_opciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Flp_Botones.Controls.Add(Me.Bt_Cerrar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 412)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(664, 30)
        Me.Flp_Botones.TabIndex = 0
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.AutoSize = True
        Me.Bt_Cerrar.Location = New System.Drawing.Point(586, 3)
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
        Me.Bt_Cancelar.Location = New System.Drawing.Point(505, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.AutoSize = True
        Me.Bt_Guardar.Enabled = False
        Me.Bt_Guardar.Location = New System.Drawing.Point(424, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 1
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Pn_BusquedaUsuario
        '
        Me.Pn_BusquedaUsuario.Controls.Add(Me.Bt_CargarConsultas)
        Me.Pn_BusquedaUsuario.Controls.Add(Me.Cu_BuscarPersona)
        Me.Pn_BusquedaUsuario.Controls.Add(Me.Lb_NombreUsuario)
        Me.Pn_BusquedaUsuario.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_BusquedaUsuario.Location = New System.Drawing.Point(0, 0)
        Me.Pn_BusquedaUsuario.Name = "Pn_BusquedaUsuario"
        Me.Pn_BusquedaUsuario.Size = New System.Drawing.Size(664, 40)
        Me.Pn_BusquedaUsuario.TabIndex = 1
        '
        'Bt_CargarConsultas
        '
        Me.Bt_CargarConsultas.AutoSize = True
        Me.Bt_CargarConsultas.Location = New System.Drawing.Point(515, 9)
        Me.Bt_CargarConsultas.Name = "Bt_CargarConsultas"
        Me.Bt_CargarConsultas.Size = New System.Drawing.Size(97, 23)
        Me.Bt_CargarConsultas.TabIndex = 2
        Me.Bt_CargarConsultas.Text = "Cargar Consultas"
        Me.Bt_CargarConsultas.UseVisualStyleBackColor = True
        '
        'Cu_BuscarPersona
        '
        Me.Cu_BuscarPersona.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersona.Location = New System.Drawing.Point(65, 9)
        Me.Cu_BuscarPersona.Name = "Cu_BuscarPersona"
        Me.Cu_BuscarPersona.Size = New System.Drawing.Size(444, 23)
        Me.Cu_BuscarPersona.TabIndex = 1
        Me.Cu_BuscarPersona.Tipo = "PUACB"
        Me.Cu_BuscarPersona.valorcajatexto = Nothing
        '
        'Lb_NombreUsuario
        '
        Me.Lb_NombreUsuario.AutoSize = True
        Me.Lb_NombreUsuario.Location = New System.Drawing.Point(12, 14)
        Me.Lb_NombreUsuario.Name = "Lb_NombreUsuario"
        Me.Lb_NombreUsuario.Size = New System.Drawing.Size(47, 13)
        Me.Lb_NombreUsuario.TabIndex = 0
        Me.Lb_NombreUsuario.Text = "Nombre:"
        '
        'Dgv_PermisosConsultas
        '
        Me.Dgv_PermisosConsultas.AllowUserToAddRows = False
        Me.Dgv_PermisosConsultas.AllowUserToDeleteRows = False
        Me.Dgv_PermisosConsultas.AllowUserToOrderColumns = True
        Me.Dgv_PermisosConsultas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_PermisosConsultas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_PermisosConsultas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.Dgv_PermisosConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_PermisosConsultas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDCONSULTA, Me.CONSULTA, Me.MODULO, Me.TIENEPERMISO})
        Me.Dgv_PermisosConsultas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_PermisosConsultas.Location = New System.Drawing.Point(0, 40)
        Me.Dgv_PermisosConsultas.MultiSelect = False
        Me.Dgv_PermisosConsultas.Name = "Dgv_PermisosConsultas"
        Me.Dgv_PermisosConsultas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_PermisosConsultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_PermisosConsultas.Size = New System.Drawing.Size(664, 312)
        Me.Dgv_PermisosConsultas.TabIndex = 0
        '
        'IDCONSULTA
        '
        Me.IDCONSULTA.DataPropertyName = "IDCONSULTA"
        Me.IDCONSULTA.HeaderText = "IdConsulta"
        Me.IDCONSULTA.Name = "IDCONSULTA"
        Me.IDCONSULTA.ReadOnly = True
        Me.IDCONSULTA.Visible = False
        '
        'CONSULTA
        '
        Me.CONSULTA.DataPropertyName = "CONSULTA"
        Me.CONSULTA.HeaderText = "Consulta"
        Me.CONSULTA.Name = "CONSULTA"
        Me.CONSULTA.ReadOnly = True
        Me.CONSULTA.ToolTipText = "Nombre de la consulta"
        Me.CONSULTA.Width = 300
        '
        'MODULO
        '
        Me.MODULO.DataPropertyName = "MODULO"
        Me.MODULO.HeaderText = "Módulo"
        Me.MODULO.Name = "MODULO"
        Me.MODULO.ReadOnly = True
        Me.MODULO.ToolTipText = "Módulo de SIGMA al cual pertenece la consulta"
        Me.MODULO.Width = 200
        '
        'TIENEPERMISO
        '
        Me.TIENEPERMISO.DataPropertyName = "TIENEPERMISO"
        Me.TIENEPERMISO.HeaderText = "Permiso"
        Me.TIENEPERMISO.Name = "TIENEPERMISO"
        Me.TIENEPERMISO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TIENEPERMISO.ToolTipText = "El usuario tiene permiso para visualizar el informe"
        '
        'Pn_NombreConsulta
        '
        Me.Pn_NombreConsulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pn_NombreConsulta.Controls.Add(Me.Tx_NombreConsulta)
        Me.Pn_NombreConsulta.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_NombreConsulta.Location = New System.Drawing.Point(0, 352)
        Me.Pn_NombreConsulta.Name = "Pn_NombreConsulta"
        Me.Pn_NombreConsulta.Size = New System.Drawing.Size(664, 60)
        Me.Pn_NombreConsulta.TabIndex = 2
        '
        'Tx_NombreConsulta
        '
        Me.Tx_NombreConsulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tx_NombreConsulta.Location = New System.Drawing.Point(0, 0)
        Me.Tx_NombreConsulta.Multiline = True
        Me.Tx_NombreConsulta.Name = "Tx_NombreConsulta"
        Me.Tx_NombreConsulta.ReadOnly = True
        Me.Tx_NombreConsulta.Size = New System.Drawing.Size(660, 56)
        Me.Tx_NombreConsulta.TabIndex = 0
        Me.Tx_NombreConsulta.TabStop = False
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
        'Cms_opciones
        '
        Me.Cms_opciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_MarcarTodas, Me.Tsmi_DemarcarTodas})
        Me.Cms_opciones.Name = "Cms_opciones"
        Me.Cms_opciones.Size = New System.Drawing.Size(158, 48)
        Me.Cms_opciones.Text = "Cms_opciones"
        '
        'Fr_AsociarUsuarioConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(664, 442)
        Me.Controls.Add(Me.Dgv_PermisosConsultas)
        Me.Controls.Add(Me.Pn_NombreConsulta)
        Me.Controls.Add(Me.Pn_BusquedaUsuario)
        Me.Controls.Add(Me.Flp_Botones)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "Fr_AsociarUsuarioConsulta"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Permisos Consultas"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Flp_Botones.PerformLayout()
        Me.Pn_BusquedaUsuario.ResumeLayout(False)
        Me.Pn_BusquedaUsuario.PerformLayout()
        CType(Me.Dgv_PermisosConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_NombreConsulta.ResumeLayout(False)
        Me.Pn_NombreConsulta.PerformLayout()
        Me.Cms_opciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Pn_BusquedaUsuario As System.Windows.Forms.Panel
    Friend WithEvents Dgv_PermisosConsultas As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Lb_NombreUsuario As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersona As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Bt_CargarConsultas As System.Windows.Forms.Button
    Friend WithEvents IDCONSULTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONSULTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIENEPERMISO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Pn_NombreConsulta As System.Windows.Forms.Panel
    Friend WithEvents Tx_NombreConsulta As System.Windows.Forms.TextBox
    Friend WithEvents Tsmi_MarcarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_DemarcarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cms_opciones As System.Windows.Forms.ContextMenuStrip

End Class