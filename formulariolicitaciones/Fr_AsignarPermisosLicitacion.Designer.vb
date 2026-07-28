<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AsignarPermisosLicitacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_AsignarPermisosLicitacion))
        Me.Pn_Filtro = New System.Windows.Forms.Panel()
        Me.Bt_CargarLicitacionesPorUsuario = New System.Windows.Forms.Button()
        Me.Bt_CargarUsuariosPorLicitacion = New System.Windows.Forms.Button()
        Me.Cb_LicitacionNumero = New System.Windows.Forms.ComboBox()
        Me.Lb_Licitacion = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersona = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Cb_Licitacion = New System.Windows.Forms.ComboBox()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Dgv_Permisos = New System.Windows.Forms.DataGridView()
        Me.Tx_Dgv_IdLicitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tx_Dgv_NroLicitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tx_Dgv_Proyecto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tx_Dgv_IdPersona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tx_Dgv_Persona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cb_Dgv_TipoPermiso = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lb_CantidadRegistros = New System.Windows.Forms.Label()
        Me.Pn_Filtro.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        CType(Me.Dgv_Permisos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Filtro
        '
        Me.Pn_Filtro.Controls.Add(Me.Lb_Nombre)
        Me.Pn_Filtro.Controls.Add(Me.Cu_BuscarPersona)
        Me.Pn_Filtro.Controls.Add(Me.Bt_CargarLicitacionesPorUsuario)
        Me.Pn_Filtro.Controls.Add(Me.Lb_Licitacion)
        Me.Pn_Filtro.Controls.Add(Me.Cb_LicitacionNumero)
        Me.Pn_Filtro.Controls.Add(Me.Cb_Licitacion)
        Me.Pn_Filtro.Controls.Add(Me.Bt_CargarUsuariosPorLicitacion)
        Me.Pn_Filtro.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Filtro.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Filtro.Name = "Pn_Filtro"
        Me.Pn_Filtro.Size = New System.Drawing.Size(734, 60)
        Me.Pn_Filtro.TabIndex = 0
        '
        'Bt_CargarLicitacionesPorUsuario
        '
        Me.Bt_CargarLicitacionesPorUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_CargarLicitacionesPorUsuario.AutoSize = True
        Me.Bt_CargarLicitacionesPorUsuario.Location = New System.Drawing.Point(565, 5)
        Me.Bt_CargarLicitacionesPorUsuario.Name = "Bt_CargarLicitacionesPorUsuario"
        Me.Bt_CargarLicitacionesPorUsuario.Size = New System.Drawing.Size(154, 23)
        Me.Bt_CargarLicitacionesPorUsuario.TabIndex = 2
        Me.Bt_CargarLicitacionesPorUsuario.Text = "Cargar Licitaciones x Usuario"
        Me.Bt_CargarLicitacionesPorUsuario.UseVisualStyleBackColor = True
        '
        'Bt_CargarUsuariosPorLicitacion
        '
        Me.Bt_CargarUsuariosPorLicitacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_CargarUsuariosPorLicitacion.AutoSize = True
        Me.Bt_CargarUsuariosPorLicitacion.Location = New System.Drawing.Point(565, 30)
        Me.Bt_CargarUsuariosPorLicitacion.Name = "Bt_CargarUsuariosPorLicitacion"
        Me.Bt_CargarUsuariosPorLicitacion.Size = New System.Drawing.Size(154, 23)
        Me.Bt_CargarUsuariosPorLicitacion.TabIndex = 6
        Me.Bt_CargarUsuariosPorLicitacion.Text = "Cargar Usuarios x Licitación"
        Me.Bt_CargarUsuariosPorLicitacion.UseVisualStyleBackColor = True
        '
        'Cb_LicitacionNumero
        '
        Me.Cb_LicitacionNumero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_LicitacionNumero.FormattingEnabled = True
        Me.Cb_LicitacionNumero.Location = New System.Drawing.Point(65, 31)
        Me.Cb_LicitacionNumero.Name = "Cb_LicitacionNumero"
        Me.Cb_LicitacionNumero.Size = New System.Drawing.Size(113, 21)
        Me.Cb_LicitacionNumero.TabIndex = 4
        '
        'Lb_Licitacion
        '
        Me.Lb_Licitacion.AutoSize = True
        Me.Lb_Licitacion.Location = New System.Drawing.Point(6, 35)
        Me.Lb_Licitacion.Name = "Lb_Licitacion"
        Me.Lb_Licitacion.Size = New System.Drawing.Size(55, 13)
        Me.Lb_Licitacion.TabIndex = 3
        Me.Lb_Licitacion.Text = "Licitación:"
        '
        'Cu_BuscarPersona
        '
        Me.Cu_BuscarPersona.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cu_BuscarPersona.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersona.Location = New System.Drawing.Point(62, 5)
        Me.Cu_BuscarPersona.Name = "Cu_BuscarPersona"
        Me.Cu_BuscarPersona.Size = New System.Drawing.Size(498, 23)
        Me.Cu_BuscarPersona.TabIndex = 0
        Me.Cu_BuscarPersona.Tipo = "PUACB"
        Me.Cu_BuscarPersona.valorcajatexto = "IDENTIFICACION"
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Location = New System.Drawing.Point(14, 10)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(47, 13)
        Me.Lb_Nombre.TabIndex = 1
        Me.Lb_Nombre.Text = "Nombre:"
        '
        'Cb_Licitacion
        '
        Me.Cb_Licitacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Licitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Licitacion.FormattingEnabled = True
        Me.Cb_Licitacion.Location = New System.Drawing.Point(184, 31)
        Me.Cb_Licitacion.Name = "Cb_Licitacion"
        Me.Cb_Licitacion.Size = New System.Drawing.Size(375, 21)
        Me.Cb_Licitacion.TabIndex = 5
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cerrar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(126, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(608, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(530, 3)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 2
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Enabled = False
        Me.Bt_Cancelar.Location = New System.Drawing.Point(449, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Enabled = False
        Me.Bt_Guardar.Location = New System.Drawing.Point(368, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Dgv_Permisos
        '
        Me.Dgv_Permisos.AllowUserToAddRows = False
        Me.Dgv_Permisos.AllowUserToDeleteRows = False
        Me.Dgv_Permisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Permisos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Permisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Permisos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tx_Dgv_IdLicitacion, Me.Tx_Dgv_NroLicitacion, Me.Tx_Dgv_Proyecto, Me.Tx_Dgv_IdPersona, Me.Tx_Dgv_Persona, Me.Cb_Dgv_TipoPermiso})
        Me.Dgv_Permisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Permisos.Location = New System.Drawing.Point(0, 60)
        Me.Dgv_Permisos.MultiSelect = False
        Me.Dgv_Permisos.Name = "Dgv_Permisos"
        Me.Dgv_Permisos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Permisos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Permisos.Size = New System.Drawing.Size(734, 431)
        Me.Dgv_Permisos.TabIndex = 1
        '
        'Tx_Dgv_IdLicitacion
        '
        Me.Tx_Dgv_IdLicitacion.DataPropertyName = "IDLICITACION"
        Me.Tx_Dgv_IdLicitacion.HeaderText = "Id. Licitación"
        Me.Tx_Dgv_IdLicitacion.Name = "Tx_Dgv_IdLicitacion"
        Me.Tx_Dgv_IdLicitacion.ReadOnly = True
        Me.Tx_Dgv_IdLicitacion.Visible = False
        '
        'Tx_Dgv_NroLicitacion
        '
        Me.Tx_Dgv_NroLicitacion.DataPropertyName = "NROLICITACION"
        Me.Tx_Dgv_NroLicitacion.HeaderText = "Nro. Licitación"
        Me.Tx_Dgv_NroLicitacion.Name = "Tx_Dgv_NroLicitacion"
        Me.Tx_Dgv_NroLicitacion.ReadOnly = True
        '
        'Tx_Dgv_Proyecto
        '
        Me.Tx_Dgv_Proyecto.DataPropertyName = "PROYECTO"
        Me.Tx_Dgv_Proyecto.FillWeight = 200.0!
        Me.Tx_Dgv_Proyecto.HeaderText = "Proyecto"
        Me.Tx_Dgv_Proyecto.Name = "Tx_Dgv_Proyecto"
        Me.Tx_Dgv_Proyecto.ReadOnly = True
        '
        'Tx_Dgv_IdPersona
        '
        Me.Tx_Dgv_IdPersona.DataPropertyName = "IDPERSONA"
        Me.Tx_Dgv_IdPersona.HeaderText = "Id. Persona"
        Me.Tx_Dgv_IdPersona.Name = "Tx_Dgv_IdPersona"
        Me.Tx_Dgv_IdPersona.ReadOnly = True
        Me.Tx_Dgv_IdPersona.Visible = False
        '
        'Tx_Dgv_Persona
        '
        Me.Tx_Dgv_Persona.DataPropertyName = "PERSONA"
        Me.Tx_Dgv_Persona.FillWeight = 300.0!
        Me.Tx_Dgv_Persona.HeaderText = "Persona"
        Me.Tx_Dgv_Persona.Name = "Tx_Dgv_Persona"
        Me.Tx_Dgv_Persona.ReadOnly = True
        '
        'Cb_Dgv_TipoPermiso
        '
        Me.Cb_Dgv_TipoPermiso.DataPropertyName = "TIPOPERMISO"
        Me.Cb_Dgv_TipoPermiso.HeaderText = "Tipo Permiso"
        Me.Cb_Dgv_TipoPermiso.Items.AddRange(New Object() {"Ninguno", "Lectura", "Escritura"})
        Me.Cb_Dgv_TipoPermiso.Name = "Cb_Dgv_TipoPermiso"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Lb_CantidadRegistros, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 491)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 30)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Lb_CantidadRegistros
        '
        Me.Lb_CantidadRegistros.AutoSize = True
        Me.Lb_CantidadRegistros.Location = New System.Drawing.Point(3, 3)
        Me.Lb_CantidadRegistros.Margin = New System.Windows.Forms.Padding(3)
        Me.Lb_CantidadRegistros.Name = "Lb_CantidadRegistros"
        Me.Lb_CantidadRegistros.Padding = New System.Windows.Forms.Padding(3)
        Me.Lb_CantidadRegistros.Size = New System.Drawing.Size(120, 19)
        Me.Lb_CantidadRegistros.TabIndex = 0
        Me.Lb_CantidadRegistros.Text = "Cantidad de Registros:"
        Me.Lb_CantidadRegistros.Visible = False
        '
        'Fr_AsignarPermisosLicitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 521)
        Me.Controls.Add(Me.Dgv_Permisos)
        Me.Controls.Add(Me.Pn_Filtro)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Fr_AsignarPermisosLicitacion"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Asignar Permisos Licitaciones"
        Me.Pn_Filtro.ResumeLayout(False)
        Me.Pn_Filtro.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        CType(Me.Dgv_Permisos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Filtro As System.Windows.Forms.Panel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Dgv_Permisos As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_CargarLicitacionesPorUsuario As System.Windows.Forms.Button
    Friend WithEvents Bt_CargarUsuariosPorLicitacion As System.Windows.Forms.Button
    Friend WithEvents Cb_LicitacionNumero As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Licitacion As System.Windows.Forms.Label
    Public WithEvents Cu_BuscarPersona As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Cb_Licitacion As System.Windows.Forms.ComboBox
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lb_CantidadRegistros As System.Windows.Forms.Label
    Friend WithEvents Tx_Dgv_IdLicitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tx_Dgv_NroLicitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tx_Dgv_Proyecto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tx_Dgv_IdPersona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tx_Dgv_Persona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cb_Dgv_TipoPermiso As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
