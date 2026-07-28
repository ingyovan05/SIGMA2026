<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_UsuarioDependencia
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Lb_NombreUsuario = New System.Windows.Forms.Label()
        Me.Bt_CargarDependencias = New System.Windows.Forms.Button()
        Me.Lb_TextoBase = New System.Windows.Forms.Label()
        Me.Cb_Dependencias = New System.Windows.Forms.ComboBox()
        Me.Bt_CargarUsuarios = New System.Windows.Forms.Button()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Dgv_Pertenencia = New System.Windows.Forms.DataGridView()
        Me.Col_IdPersona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdDependencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Base = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Dependencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Asociado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Col_EsBasePrincipal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Tlp_Botones = New System.Windows.Forms.TableLayoutPanel()
        Me.Pn_Estado = New System.Windows.Forms.Panel()
        Me.Lb_Estado = New System.Windows.Forms.Label()
        Me.Tlp_Controles = New System.Windows.Forms.TableLayoutPanel()
        Me.CuBP_Usuario = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_TextoDependencia = New System.Windows.Forms.Label()
        Me.Cb_Bases = New System.Windows.Forms.ComboBox()
        Me.Cms_opciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MarcarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.DemarcarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Flp_Botones.SuspendLayout()
        CType(Me.Dgv_Pertenencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tlp_Botones.SuspendLayout()
        Me.Pn_Estado.SuspendLayout()
        Me.Tlp_Controles.SuspendLayout()
        Me.Cms_opciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lb_NombreUsuario
        '
        Me.Lb_NombreUsuario.AutoSize = True
        Me.Lb_NombreUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_NombreUsuario.Location = New System.Drawing.Point(3, 0)
        Me.Lb_NombreUsuario.Name = "Lb_NombreUsuario"
        Me.Lb_NombreUsuario.Size = New System.Drawing.Size(101, 29)
        Me.Lb_NombreUsuario.TabIndex = 0
        Me.Lb_NombreUsuario.Text = "Nombre del usuario:"
        Me.Lb_NombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Bt_CargarDependencias
        '
        Me.Bt_CargarDependencias.Location = New System.Drawing.Point(608, 3)
        Me.Bt_CargarDependencias.Name = "Bt_CargarDependencias"
        Me.Bt_CargarDependencias.Size = New System.Drawing.Size(120, 23)
        Me.Bt_CargarDependencias.TabIndex = 4
        Me.Bt_CargarDependencias.Text = "Cargar dependencias"
        Me.Bt_CargarDependencias.UseVisualStyleBackColor = True
        '
        'Lb_TextoBase
        '
        Me.Lb_TextoBase.AutoSize = True
        Me.Lb_TextoBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoBase.Location = New System.Drawing.Point(3, 29)
        Me.Lb_TextoBase.Name = "Lb_TextoBase"
        Me.Lb_TextoBase.Size = New System.Drawing.Size(101, 29)
        Me.Lb_TextoBase.TabIndex = 5
        Me.Lb_TextoBase.Text = "Base:"
        Me.Lb_TextoBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cb_Dependencias
        '
        Me.Cb_Dependencias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Dependencias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Cb_Dependencias.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_Dependencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Dependencias.FormattingEnabled = True
        Me.Cb_Dependencias.Location = New System.Drawing.Point(399, 32)
        Me.Cb_Dependencias.Name = "Cb_Dependencias"
        Me.Cb_Dependencias.Size = New System.Drawing.Size(203, 21)
        Me.Cb_Dependencias.TabIndex = 6
        Me.Cb_Dependencias.ValueMember = "IDDEPENDENCIA"
        '
        'Bt_CargarUsuarios
        '
        Me.Bt_CargarUsuarios.Location = New System.Drawing.Point(608, 32)
        Me.Bt_CargarUsuarios.Name = "Bt_CargarUsuarios"
        Me.Bt_CargarUsuarios.Size = New System.Drawing.Size(120, 23)
        Me.Bt_CargarUsuarios.TabIndex = 7
        Me.Bt_CargarUsuarios.Text = "Cargar usuarios"
        Me.Bt_CargarUsuarios.UseVisualStyleBackColor = True
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cerrar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(200, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(532, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(454, 3)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 2
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Enabled = False
        Me.Bt_Cancelar.Location = New System.Drawing.Point(373, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Enabled = False
        Me.Bt_Guardar.Location = New System.Drawing.Point(292, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Dgv_Pertenencia
        '
        Me.Dgv_Pertenencia.AllowUserToAddRows = False
        Me.Dgv_Pertenencia.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan
        Me.Dgv_Pertenencia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Pertenencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_Pertenencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Pertenencia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_IdPersona, Me.Col_IdDependencia, Me.Col_Base, Me.Col_Dependencia, Me.Col_Nombre, Me.Col_Asociado, Me.Col_EsBasePrincipal})
        Me.Dgv_Pertenencia.ContextMenuStrip = Me.Cms_opciones
        Me.Dgv_Pertenencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Pertenencia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Pertenencia.Enabled = False
        Me.Dgv_Pertenencia.Location = New System.Drawing.Point(0, 58)
        Me.Dgv_Pertenencia.Name = "Dgv_Pertenencia"
        Me.Dgv_Pertenencia.RowHeadersVisible = False
        Me.Dgv_Pertenencia.Size = New System.Drawing.Size(732, 331)
        Me.Dgv_Pertenencia.TabIndex = 1
        '
        'Col_IdPersona
        '
        Me.Col_IdPersona.DataPropertyName = "IDPERSONA"
        Me.Col_IdPersona.HeaderText = "IDPERSONA"
        Me.Col_IdPersona.Name = "Col_IdPersona"
        Me.Col_IdPersona.ReadOnly = True
        Me.Col_IdPersona.Visible = False
        Me.Col_IdPersona.Width = 76
        '
        'Col_IdDependencia
        '
        Me.Col_IdDependencia.DataPropertyName = "IDDEPENDENCIA"
        Me.Col_IdDependencia.HeaderText = "IDDEPENDENCIA"
        Me.Col_IdDependencia.Name = "Col_IdDependencia"
        Me.Col_IdDependencia.ReadOnly = True
        Me.Col_IdDependencia.Visible = False
        Me.Col_IdDependencia.Width = 101
        '
        'Col_Base
        '
        Me.Col_Base.DataPropertyName = "BASE"
        Me.Col_Base.FillWeight = 400.0!
        Me.Col_Base.HeaderText = "Base"
        Me.Col_Base.Name = "Col_Base"
        Me.Col_Base.ReadOnly = True
        Me.Col_Base.Width = 56
        '
        'Col_Dependencia
        '
        Me.Col_Dependencia.DataPropertyName = "DEPENDENCIA"
        Me.Col_Dependencia.FillWeight = 400.0!
        Me.Col_Dependencia.HeaderText = "Dependencia"
        Me.Col_Dependencia.Name = "Col_Dependencia"
        Me.Col_Dependencia.ReadOnly = True
        Me.Col_Dependencia.Width = 96
        '
        'Col_Nombre
        '
        Me.Col_Nombre.DataPropertyName = "NOMBRE"
        Me.Col_Nombre.FillWeight = 400.0!
        Me.Col_Nombre.HeaderText = "Nombre"
        Me.Col_Nombre.Name = "Col_Nombre"
        Me.Col_Nombre.ReadOnly = True
        Me.Col_Nombre.Width = 69
        '
        'Col_Asociado
        '
        Me.Col_Asociado.DataPropertyName = "ASOCIADO"
        Me.Col_Asociado.FalseValue = "N"
        Me.Col_Asociado.HeaderText = "Asociado"
        Me.Col_Asociado.Name = "Col_Asociado"
        Me.Col_Asociado.TrueValue = "S"
        Me.Col_Asociado.Width = 57
        '
        'Col_EsBasePrincipal
        '
        Me.Col_EsBasePrincipal.DataPropertyName = "USUARIO"
        Me.Col_EsBasePrincipal.FalseValue = "N"
        Me.Col_EsBasePrincipal.HeaderText = "Base principal"
        Me.Col_EsBasePrincipal.Name = "Col_EsBasePrincipal"
        Me.Col_EsBasePrincipal.TrueValue = "S"
        Me.Col_EsBasePrincipal.Width = 79
        '
        'Tlp_Botones
        '
        Me.Tlp_Botones.ColumnCount = 2
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Botones.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_Botones.Controls.Add(Me.Pn_Estado, 0, 0)
        Me.Tlp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_Botones.Location = New System.Drawing.Point(0, 389)
        Me.Tlp_Botones.Name = "Tlp_Botones"
        Me.Tlp_Botones.RowCount = 1
        Me.Tlp_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Botones.Size = New System.Drawing.Size(732, 30)
        Me.Tlp_Botones.TabIndex = 2
        '
        'Pn_Estado
        '
        Me.Pn_Estado.Controls.Add(Me.Lb_Estado)
        Me.Pn_Estado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Estado.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Estado.Margin = New System.Windows.Forms.Padding(0)
        Me.Pn_Estado.Name = "Pn_Estado"
        Me.Pn_Estado.Size = New System.Drawing.Size(200, 30)
        Me.Pn_Estado.TabIndex = 1
        '
        'Lb_Estado
        '
        Me.Lb_Estado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Estado.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Estado.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Estado.Name = "Lb_Estado"
        Me.Lb_Estado.Size = New System.Drawing.Size(200, 30)
        Me.Lb_Estado.TabIndex = 0
        Me.Lb_Estado.Text = "Label"
        Me.Lb_Estado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lb_Estado.Visible = False
        '
        'Tlp_Controles
        '
        Me.Tlp_Controles.ColumnCount = 5
        Me.Tlp_Controles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Controles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Controles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Controles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Controles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Controles.Controls.Add(Me.Lb_NombreUsuario, 0, 0)
        Me.Tlp_Controles.Controls.Add(Me.Lb_TextoBase, 0, 1)
        Me.Tlp_Controles.Controls.Add(Me.CuBP_Usuario, 1, 0)
        Me.Tlp_Controles.Controls.Add(Me.Lb_TextoDependencia, 2, 1)
        Me.Tlp_Controles.Controls.Add(Me.Cb_Bases, 1, 1)
        Me.Tlp_Controles.Controls.Add(Me.Bt_CargarDependencias, 4, 0)
        Me.Tlp_Controles.Controls.Add(Me.Bt_CargarUsuarios, 4, 1)
        Me.Tlp_Controles.Controls.Add(Me.Cb_Dependencias, 3, 1)
        Me.Tlp_Controles.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tlp_Controles.Location = New System.Drawing.Point(0, 0)
        Me.Tlp_Controles.Name = "Tlp_Controles"
        Me.Tlp_Controles.RowCount = 2
        Me.Tlp_Controles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Controles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Controles.Size = New System.Drawing.Size(732, 58)
        Me.Tlp_Controles.TabIndex = 8
        '
        'CuBP_Usuario
        '
        Me.CuBP_Usuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tlp_Controles.SetColumnSpan(Me.CuBP_Usuario, 3)
        Me.CuBP_Usuario.FechaReporteDiario = New Date(CType(0, Long))
        Me.CuBP_Usuario.Location = New System.Drawing.Point(110, 3)
        Me.CuBP_Usuario.Name = "CuBP_Usuario"
        Me.CuBP_Usuario.Size = New System.Drawing.Size(492, 23)
        Me.CuBP_Usuario.TabIndex = 8
        Me.CuBP_Usuario.Tipo = "PUACB"
        Me.CuBP_Usuario.valorcajatexto = "IDENTIFICACION"
        '
        'Lb_TextoDependencia
        '
        Me.Lb_TextoDependencia.AutoSize = True
        Me.Lb_TextoDependencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoDependencia.Location = New System.Drawing.Point(319, 29)
        Me.Lb_TextoDependencia.Name = "Lb_TextoDependencia"
        Me.Lb_TextoDependencia.Size = New System.Drawing.Size(74, 29)
        Me.Lb_TextoDependencia.TabIndex = 6
        Me.Lb_TextoDependencia.Text = "Dependencia:"
        Me.Lb_TextoDependencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cb_Bases
        '
        Me.Cb_Bases.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Bases.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Cb_Bases.DisplayMember = "BASE"
        Me.Cb_Bases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Bases.FormattingEnabled = True
        Me.Cb_Bases.Location = New System.Drawing.Point(112, 32)
        Me.Cb_Bases.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.Cb_Bases.Name = "Cb_Bases"
        Me.Cb_Bases.Size = New System.Drawing.Size(201, 21)
        Me.Cb_Bases.TabIndex = 7
        Me.Cb_Bases.ValueMember = "IDBASESISCONTROL"
        '
        'Cms_opciones
        '
        Me.Cms_opciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MarcarTodas, Me.DemarcarTodas})
        Me.Cms_opciones.Name = "ContextMenuStrip1"
        Me.Cms_opciones.Size = New System.Drawing.Size(165, 48)
        '
        'MarcarTodas
        '
        Me.MarcarTodas.Name = "MarcarTodas"
        Me.MarcarTodas.Size = New System.Drawing.Size(164, 22)
        Me.MarcarTodas.Text = "Marcar Todas"
        '
        'DemarcarTodas
        '
        Me.DemarcarTodas.Name = "DemarcarTodas"
        Me.DemarcarTodas.Size = New System.Drawing.Size(164, 22)
        Me.DemarcarTodas.Text = "Desmarcar Todas"
        '
        'Fr_UsuarioDependencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 419)
        Me.Controls.Add(Me.Dgv_Pertenencia)
        Me.Controls.Add(Me.Tlp_Controles)
        Me.Controls.Add(Me.Tlp_Botones)
        Me.Name = "Fr_UsuarioDependencia"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Asociar Usuarios a Dependencia"
        Me.Flp_Botones.ResumeLayout(False)
        CType(Me.Dgv_Pertenencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tlp_Botones.ResumeLayout(False)
        Me.Pn_Estado.ResumeLayout(False)
        Me.Tlp_Controles.ResumeLayout(False)
        Me.Tlp_Controles.PerformLayout()
        Me.Cms_opciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bt_CargarUsuarios As System.Windows.Forms.Button
    Friend WithEvents Lb_TextoBase As System.Windows.Forms.Label
    Friend WithEvents Lb_NombreUsuario As System.Windows.Forms.Label
    Friend WithEvents Bt_CargarDependencias As System.Windows.Forms.Button
    Friend WithEvents Cb_Dependencias As System.Windows.Forms.ComboBox
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Dgv_Pertenencia As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Tlp_Botones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lb_Estado As System.Windows.Forms.Label
    Friend WithEvents Pn_Estado As System.Windows.Forms.Panel
    Friend WithEvents Tlp_Controles As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CuBP_Usuario As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cb_Bases As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoDependencia As System.Windows.Forms.Label
    Friend WithEvents Col_IdPersona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdDependencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Dependencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Asociado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Col_EsBasePrincipal As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cms_opciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MarcarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DemarcarTodas As System.Windows.Forms.ToolStripMenuItem

End Class
