<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_BuscarEnfermedades
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
        Me.Dgv_Enfermedades = New System.Windows.Forms.DataGridView()
        Me.DGVT_IDENFERMEDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_CODIGOENFERMEDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_NOMBREENFERMEDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_GRUPOENFERMEDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_USADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aceptar = New System.Windows.Forms.Button()
        Me.Cancelar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Gb_BuscarVacunas = New System.Windows.Forms.GroupBox()
        Me.Cb_Busqueda = New System.Windows.Forms.ComboBox()
        Me.Tb_busqueda = New System.Windows.Forms.TextBox()
        Me.Cms_AsignarGrupoEnfermedad = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AsignarGrupoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Dgv_Enfermedades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Gb_BuscarVacunas.SuspendLayout()
        Me.Cms_AsignarGrupoEnfermedad.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_Enfermedades
        '
        Me.Dgv_Enfermedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Enfermedades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVT_IDENFERMEDAD, Me.DGVT_CODIGOENFERMEDAD, Me.DGVT_NOMBREENFERMEDAD, Me.DGVT_GRUPOENFERMEDAD, Me.DGVT_USADO})
        Me.Dgv_Enfermedades.Location = New System.Drawing.Point(5, 71)
        Me.Dgv_Enfermedades.Name = "Dgv_Enfermedades"
        Me.Dgv_Enfermedades.Size = New System.Drawing.Size(878, 273)
        Me.Dgv_Enfermedades.TabIndex = 3
        '
        'DGVT_IDENFERMEDAD
        '
        Me.DGVT_IDENFERMEDAD.DataPropertyName = "IDENFERMEDAD"
        Me.DGVT_IDENFERMEDAD.HeaderText = "Id"
        Me.DGVT_IDENFERMEDAD.Name = "DGVT_IDENFERMEDAD"
        '
        'DGVT_CODIGOENFERMEDAD
        '
        Me.DGVT_CODIGOENFERMEDAD.DataPropertyName = "CODIGOENFERMEDAD"
        Me.DGVT_CODIGOENFERMEDAD.HeaderText = "Codigo"
        Me.DGVT_CODIGOENFERMEDAD.Name = "DGVT_CODIGOENFERMEDAD"
        '
        'DGVT_NOMBREENFERMEDAD
        '
        Me.DGVT_NOMBREENFERMEDAD.DataPropertyName = "NOMBREENFERMEDAD"
        Me.DGVT_NOMBREENFERMEDAD.HeaderText = "Enfermedad"
        Me.DGVT_NOMBREENFERMEDAD.Name = "DGVT_NOMBREENFERMEDAD"
        Me.DGVT_NOMBREENFERMEDAD.Width = 300
        '
        'DGVT_GRUPOENFERMEDAD
        '
        Me.DGVT_GRUPOENFERMEDAD.DataPropertyName = "GRUPOENFERMEDAD"
        Me.DGVT_GRUPOENFERMEDAD.HeaderText = "Grupo"
        Me.DGVT_GRUPOENFERMEDAD.Name = "DGVT_GRUPOENFERMEDAD"
        Me.DGVT_GRUPOENFERMEDAD.Width = 200
        '
        'DGVT_USADO
        '
        Me.DGVT_USADO.DataPropertyName = "USADO"
        Me.DGVT_USADO.HeaderText = "USADO"
        Me.DGVT_USADO.Name = "DGVT_USADO"
        '
        'Aceptar
        '
        Me.Aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Aceptar.Location = New System.Drawing.Point(720, 3)
        Me.Aceptar.MinimumSize = New System.Drawing.Size(75, 23)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Aceptar.TabIndex = 4
        Me.Aceptar.Text = "Aceptar"
        Me.Aceptar.UseVisualStyleBackColor = True
        '
        'Cancelar
        '
        Me.Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancelar.Location = New System.Drawing.Point(806, 3)
        Me.Cancelar.MinimumSize = New System.Drawing.Size(75, 23)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Cancelar.TabIndex = 5
        Me.Cancelar.Text = "Cancelar"
        Me.Cancelar.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Grupo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Enfermedad"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.4015!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5985!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Cancelar, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Aceptar, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 350)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(884, 30)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'Gb_BuscarVacunas
        '
        Me.Gb_BuscarVacunas.AutoSize = True
        Me.Gb_BuscarVacunas.Controls.Add(Me.Cb_Busqueda)
        Me.Gb_BuscarVacunas.Controls.Add(Me.Tb_busqueda)
        Me.Gb_BuscarVacunas.Location = New System.Drawing.Point(5, 5)
        Me.Gb_BuscarVacunas.Name = "Gb_BuscarVacunas"
        Me.Gb_BuscarVacunas.Size = New System.Drawing.Size(878, 64)
        Me.Gb_BuscarVacunas.TabIndex = 6
        Me.Gb_BuscarVacunas.TabStop = False
        Me.Gb_BuscarVacunas.Text = "Busqueda"
        '
        'Cb_Busqueda
        '
        Me.Cb_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cb_Busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Busqueda.FormattingEnabled = True
        Me.Cb_Busqueda.Location = New System.Drawing.Point(6, 24)
        Me.Cb_Busqueda.MinimumSize = New System.Drawing.Size(125, 0)
        Me.Cb_Busqueda.Name = "Cb_Busqueda"
        Me.Cb_Busqueda.Size = New System.Drawing.Size(146, 21)
        Me.Cb_Busqueda.TabIndex = 1
        '
        'Tb_busqueda
        '
        Me.Tb_busqueda.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Tb_busqueda.Location = New System.Drawing.Point(170, 24)
        Me.Tb_busqueda.MinimumSize = New System.Drawing.Size(701, 20)
        Me.Tb_busqueda.Name = "Tb_busqueda"
        Me.Tb_busqueda.Size = New System.Drawing.Size(701, 20)
        Me.Tb_busqueda.TabIndex = 2
        '
        'Cms_AsignarGrupoEnfermedad
        '
        Me.Cms_AsignarGrupoEnfermedad.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsignarGrupoToolStripMenuItem})
        Me.Cms_AsignarGrupoEnfermedad.Name = "Cms_AsignarGrupoEnfermedad"
        Me.Cms_AsignarGrupoEnfermedad.Size = New System.Drawing.Size(151, 26)
        '
        'AsignarGrupoToolStripMenuItem
        '
        Me.AsignarGrupoToolStripMenuItem.Name = "AsignarGrupoToolStripMenuItem"
        Me.AsignarGrupoToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.AsignarGrupoToolStripMenuItem.Text = "Asignar Grupo"
        '
        'Fr_BuscarEnfermedades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 378)
        Me.Controls.Add(Me.Dgv_Enfermedades)
        Me.Controls.Add(Me.Gb_BuscarVacunas)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.MaximumSize = New System.Drawing.Size(904, 417)
        Me.MinimumSize = New System.Drawing.Size(904, 417)
        Me.Name = "Fr_BuscarEnfermedades"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de enfermedades"
        CType(Me.Dgv_Enfermedades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Gb_BuscarVacunas.ResumeLayout(False)
        Me.Gb_BuscarVacunas.PerformLayout()
        Me.Cms_AsignarGrupoEnfermedad.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dgv_Enfermedades As System.Windows.Forms.DataGridView
    Friend WithEvents Aceptar As System.Windows.Forms.Button
    Friend WithEvents Cancelar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_IDENFERMEDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_CODIGOENFERMEDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_NOMBREENFERMEDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_GRUPOENFERMEDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_USADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Gb_BuscarVacunas As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_Busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents Tb_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents Cms_AsignarGrupoEnfermedad As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AsignarGrupoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
