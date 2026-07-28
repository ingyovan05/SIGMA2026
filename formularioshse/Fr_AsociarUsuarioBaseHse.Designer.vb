<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AsociarUsuarioBaseHse
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
        Me.Dgv_Pertenencia = New System.Windows.Forms.DataGridView()
        Me.Col_IdPersona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDBASE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Base = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Asociado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cms_opciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MarcarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.DemarcarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tlp_Controles = New System.Windows.Forms.TableLayoutPanel()
        Me.Lb_NombreUsuario = New System.Windows.Forms.Label()
        Me.Lb_TextoBase = New System.Windows.Forms.Label()
        Me.CuBP_Usuario = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cb_Bases = New System.Windows.Forms.ComboBox()
        Me.Bt_CargarBases = New System.Windows.Forms.Button()
        Me.Bt_CargarUsuarios = New System.Windows.Forms.Button()
        Me.Tlp_Botones = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Pn_Estado = New System.Windows.Forms.Panel()
        Me.Lb_Estado = New System.Windows.Forms.Label()
        CType(Me.Dgv_Pertenencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_opciones.SuspendLayout()
        Me.Tlp_Controles.SuspendLayout()
        Me.Tlp_Botones.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Estado.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_Pertenencia
        '
        Me.Dgv_Pertenencia.AllowUserToAddRows = False
        Me.Dgv_Pertenencia.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan
        Me.Dgv_Pertenencia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Pertenencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_Pertenencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Pertenencia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_IdPersona, Me.IDBASE, Me.Col_Base, Me.Col_Nombre, Me.Col_Asociado})
        Me.Dgv_Pertenencia.ContextMenuStrip = Me.Cms_opciones
        Me.Dgv_Pertenencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Pertenencia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Pertenencia.Enabled = False
        Me.Dgv_Pertenencia.Location = New System.Drawing.Point(0, 58)
        Me.Dgv_Pertenencia.Name = "Dgv_Pertenencia"
        Me.Dgv_Pertenencia.RowHeadersVisible = False
        Me.Dgv_Pertenencia.Size = New System.Drawing.Size(696, 250)
        Me.Dgv_Pertenencia.TabIndex = 2
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
        'IDBASE
        '
        Me.IDBASE.DataPropertyName = "IDBASE"
        Me.IDBASE.HeaderText = "IDBASE"
        Me.IDBASE.Name = "IDBASE"
        Me.IDBASE.Visible = False
        Me.IDBASE.Width = 52
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
        'Cms_opciones
        '
        Me.Cms_opciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MarcarTodas, Me.DemarcarTodas})
        Me.Cms_opciones.Name = "ContextMenuStrip1"
        Me.Cms_opciones.Size = New System.Drawing.Size(164, 48)
        '
        'MarcarTodas
        '
        Me.MarcarTodas.Name = "MarcarTodas"
        Me.MarcarTodas.Size = New System.Drawing.Size(163, 22)
        Me.MarcarTodas.Text = "Marcar Todas"
        '
        'DemarcarTodas
        '
        Me.DemarcarTodas.Name = "DemarcarTodas"
        Me.DemarcarTodas.Size = New System.Drawing.Size(163, 22)
        Me.DemarcarTodas.Text = "Desmarcar Todas"
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
        Me.Tlp_Controles.Controls.Add(Me.Cb_Bases, 1, 1)
        Me.Tlp_Controles.Controls.Add(Me.Bt_CargarBases, 4, 0)
        Me.Tlp_Controles.Controls.Add(Me.Bt_CargarUsuarios, 4, 1)
        Me.Tlp_Controles.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tlp_Controles.Location = New System.Drawing.Point(0, 0)
        Me.Tlp_Controles.Name = "Tlp_Controles"
        Me.Tlp_Controles.RowCount = 2
        Me.Tlp_Controles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Controles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Controles.Size = New System.Drawing.Size(696, 58)
        Me.Tlp_Controles.TabIndex = 9
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
        'CuBP_Usuario
        '
        Me.CuBP_Usuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tlp_Controles.SetColumnSpan(Me.CuBP_Usuario, 3)
        Me.CuBP_Usuario.FechaReporteDiario = New Date(CType(0, Long))
        Me.CuBP_Usuario.Location = New System.Drawing.Point(110, 3)
        Me.CuBP_Usuario.Name = "CuBP_Usuario"
        Me.CuBP_Usuario.Size = New System.Drawing.Size(456, 23)
        Me.CuBP_Usuario.TabIndex = 8
        Me.CuBP_Usuario.Tipo = "PUACB"
        Me.CuBP_Usuario.valorcajatexto = "IDENTIFICACION"
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
        Me.Cb_Bases.Size = New System.Drawing.Size(146, 21)
        Me.Cb_Bases.TabIndex = 7
        Me.Cb_Bases.ValueMember = "IDBASESISCONTROL"
        '
        'Bt_CargarBases
        '
        Me.Bt_CargarBases.Location = New System.Drawing.Point(572, 3)
        Me.Bt_CargarBases.Name = "Bt_CargarBases"
        Me.Bt_CargarBases.Size = New System.Drawing.Size(120, 23)
        Me.Bt_CargarBases.TabIndex = 4
        Me.Bt_CargarBases.Text = "Cargar bases"
        Me.Bt_CargarBases.UseVisualStyleBackColor = True
        '
        'Bt_CargarUsuarios
        '
        Me.Bt_CargarUsuarios.Location = New System.Drawing.Point(572, 32)
        Me.Bt_CargarUsuarios.Name = "Bt_CargarUsuarios"
        Me.Bt_CargarUsuarios.Size = New System.Drawing.Size(120, 23)
        Me.Bt_CargarUsuarios.TabIndex = 7
        Me.Bt_CargarUsuarios.Text = "Cargar usuarios"
        Me.Bt_CargarUsuarios.UseVisualStyleBackColor = True
        '
        'Tlp_Botones
        '
        Me.Tlp_Botones.ColumnCount = 2
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Botones.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_Botones.Controls.Add(Me.Pn_Estado, 0, 0)
        Me.Tlp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_Botones.Location = New System.Drawing.Point(0, 278)
        Me.Tlp_Botones.Name = "Tlp_Botones"
        Me.Tlp_Botones.RowCount = 1
        Me.Tlp_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Botones.Size = New System.Drawing.Size(696, 30)
        Me.Tlp_Botones.TabIndex = 10
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
        Me.Flp_Botones.Size = New System.Drawing.Size(496, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(418, 3)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 2
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Enabled = False
        Me.Bt_Cancelar.Location = New System.Drawing.Point(337, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Enabled = False
        Me.Bt_Guardar.Location = New System.Drawing.Point(256, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
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
        'Fr_AsociarUsuarioBaseHse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 308)
        Me.Controls.Add(Me.Tlp_Botones)
        Me.Controls.Add(Me.Dgv_Pertenencia)
        Me.Controls.Add(Me.Tlp_Controles)
        Me.MaximumSize = New System.Drawing.Size(712, 347)
        Me.MinimumSize = New System.Drawing.Size(712, 347)
        Me.Name = "Fr_AsociarUsuarioBaseHse"
        Me.ShowIcon = False
        Me.Text = "Asociar Usuario A Base Hse"
        CType(Me.Dgv_Pertenencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_opciones.ResumeLayout(False)
        Me.Tlp_Controles.ResumeLayout(False)
        Me.Tlp_Controles.PerformLayout()
        Me.Tlp_Botones.ResumeLayout(False)
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Estado.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv_Pertenencia As System.Windows.Forms.DataGridView
    Friend WithEvents Tlp_Controles As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lb_NombreUsuario As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoBase As System.Windows.Forms.Label
    Friend WithEvents CuBP_Usuario As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cb_Bases As System.Windows.Forms.ComboBox
    Friend WithEvents Bt_CargarBases As System.Windows.Forms.Button
    Friend WithEvents Bt_CargarUsuarios As System.Windows.Forms.Button
    Friend WithEvents Tlp_Botones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Pn_Estado As System.Windows.Forms.Panel
    Friend WithEvents Lb_Estado As System.Windows.Forms.Label
    Friend WithEvents Cms_opciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MarcarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DemarcarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Col_IdPersona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDBASE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Asociado As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
