<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_GestiónCuadrillas
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Bt_salir = New System.Windows.Forms.Button()
        Me.OK_Guardar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Ll_Agregardesdeportapapeles = New System.Windows.Forms.LinkLabel()
        Me.Cb_Activo = New System.Windows.Forms.CheckBox()
        Me.Tx_NombreCuadrilla = New System.Windows.Forms.TextBox()
        Me.Dgv_Integrantes = New System.Windows.Forms.DataGridView()
        Me.DGVTBC_IDCUADRILLA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_ORDEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_IDPERSONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_IDCONTRATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_CODIGOCONTRATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_NOMBREPERSONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_IDTIPORECURSO = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Cms_opciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_CopiarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_LimpiarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Dgv_Integrantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_opciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre Cuadrilla:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 451)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(712, 39)
        Me.Panel1.TabIndex = 3
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Bt_salir, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Guardar, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(560, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Bt_salir
        '
        Me.Bt_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_salir.Location = New System.Drawing.Point(76, 3)
        Me.Bt_salir.Name = "Bt_salir"
        Me.Bt_salir.Size = New System.Drawing.Size(67, 23)
        Me.Bt_salir.TabIndex = 1
        Me.Bt_salir.Text = "Salir"
        Me.Bt_salir.UseVisualStyleBackColor = True
        '
        'OK_Guardar
        '
        Me.OK_Guardar.Location = New System.Drawing.Point(3, 3)
        Me.OK_Guardar.Name = "OK_Guardar"
        Me.OK_Guardar.Size = New System.Drawing.Size(67, 23)
        Me.OK_Guardar.TabIndex = 0
        Me.OK_Guardar.Text = "Guardar"
        Me.OK_Guardar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Ll_Agregardesdeportapapeles)
        Me.Panel2.Controls.Add(Me.Cb_Activo)
        Me.Panel2.Controls.Add(Me.Tx_NombreCuadrilla)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(712, 57)
        Me.Panel2.TabIndex = 5
        '
        'Ll_Agregardesdeportapapeles
        '
        Me.Ll_Agregardesdeportapapeles.AutoSize = True
        Me.Ll_Agregardesdeportapapeles.Location = New System.Drawing.Point(10, 34)
        Me.Ll_Agregardesdeportapapeles.Name = "Ll_Agregardesdeportapapeles"
        Me.Ll_Agregardesdeportapapeles.Size = New System.Drawing.Size(140, 13)
        Me.Ll_Agregardesdeportapapeles.TabIndex = 20
        Me.Ll_Agregardesdeportapapeles.TabStop = True
        Me.Ll_Agregardesdeportapapeles.Text = "Agregar desde portapapeles"
        '
        'Cb_Activo
        '
        Me.Cb_Activo.AutoSize = True
        Me.Cb_Activo.Location = New System.Drawing.Point(651, 11)
        Me.Cb_Activo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Cb_Activo.Name = "Cb_Activo"
        Me.Cb_Activo.Size = New System.Drawing.Size(56, 17)
        Me.Cb_Activo.TabIndex = 5
        Me.Cb_Activo.Text = "Activa"
        Me.Cb_Activo.UseVisualStyleBackColor = True
        '
        'Tx_NombreCuadrilla
        '
        Me.Tx_NombreCuadrilla.Location = New System.Drawing.Point(115, 10)
        Me.Tx_NombreCuadrilla.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Tx_NombreCuadrilla.MaxLength = 100
        Me.Tx_NombreCuadrilla.Name = "Tx_NombreCuadrilla"
        Me.Tx_NombreCuadrilla.Size = New System.Drawing.Size(533, 20)
        Me.Tx_NombreCuadrilla.TabIndex = 4
        '
        'Dgv_Integrantes
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Integrantes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Integrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Integrantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBC_IDCUADRILLA, Me.DGVTBC_ORDEN, Me.DGVTBC_IDPERSONA, Me.DGVTBC_IDCONTRATO, Me.DGVTBC_CODIGOCONTRATO, Me.DGVTBC_NOMBREPERSONA, Me.DGVTBC_IDTIPORECURSO})
        Me.Dgv_Integrantes.ContextMenuStrip = Me.Cms_opciones
        Me.Dgv_Integrantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Integrantes.Location = New System.Drawing.Point(0, 81)
        Me.Dgv_Integrantes.Name = "Dgv_Integrantes"
        Me.Dgv_Integrantes.Size = New System.Drawing.Size(712, 370)
        Me.Dgv_Integrantes.TabIndex = 6
        '
        'DGVTBC_IDCUADRILLA
        '
        Me.DGVTBC_IDCUADRILLA.DataPropertyName = "IDCUADRILLA"
        Me.DGVTBC_IDCUADRILLA.HeaderText = "IDCUADRILLA"
        Me.DGVTBC_IDCUADRILLA.Name = "DGVTBC_IDCUADRILLA"
        Me.DGVTBC_IDCUADRILLA.Visible = False
        '
        'DGVTBC_ORDEN
        '
        Me.DGVTBC_ORDEN.DataPropertyName = "ORDEN"
        Me.DGVTBC_ORDEN.HeaderText = "Orden"
        Me.DGVTBC_ORDEN.Name = "DGVTBC_ORDEN"
        '
        'DGVTBC_IDPERSONA
        '
        Me.DGVTBC_IDPERSONA.DataPropertyName = "IDPERSONA"
        Me.DGVTBC_IDPERSONA.HeaderText = "IDPERSONA"
        Me.DGVTBC_IDPERSONA.Name = "DGVTBC_IDPERSONA"
        Me.DGVTBC_IDPERSONA.Visible = False
        '
        'DGVTBC_IDCONTRATO
        '
        Me.DGVTBC_IDCONTRATO.DataPropertyName = "IDCONTRATO"
        Me.DGVTBC_IDCONTRATO.HeaderText = "IDCONTRATO"
        Me.DGVTBC_IDCONTRATO.Name = "DGVTBC_IDCONTRATO"
        Me.DGVTBC_IDCONTRATO.Visible = False
        '
        'DGVTBC_CODIGOCONTRATO
        '
        Me.DGVTBC_CODIGOCONTRATO.DataPropertyName = "CODIGOCONTRATO"
        Me.DGVTBC_CODIGOCONTRATO.HeaderText = "Cód Contrato"
        Me.DGVTBC_CODIGOCONTRATO.Name = "DGVTBC_CODIGOCONTRATO"
        '
        'DGVTBC_NOMBREPERSONA
        '
        Me.DGVTBC_NOMBREPERSONA.DataPropertyName = "NOMBREPERSONA"
        Me.DGVTBC_NOMBREPERSONA.HeaderText = "Nombre Completo"
        Me.DGVTBC_NOMBREPERSONA.Name = "DGVTBC_NOMBREPERSONA"
        Me.DGVTBC_NOMBREPERSONA.Width = 250
        '
        'DGVTBC_IDTIPORECURSO
        '
        Me.DGVTBC_IDTIPORECURSO.DataPropertyName = "IDTIPORECURSO"
        Me.DGVTBC_IDTIPORECURSO.HeaderText = "Tipo Recurso"
        Me.DGVTBC_IDTIPORECURSO.Name = "DGVTBC_IDTIPORECURSO"
        Me.DGVTBC_IDTIPORECURSO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVTBC_IDTIPORECURSO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVTBC_IDTIPORECURSO.Width = 200
        '
        'Cms_opciones
        '
        Me.Cms_opciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_opciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_CopiarTodas, Me.TSMI_LimpiarTodas})
        Me.Cms_opciones.Name = "ContextMenuStrip1"
        Me.Cms_opciones.Size = New System.Drawing.Size(213, 48)
        '
        'TSMI_CopiarTodas
        '
        Me.TSMI_CopiarTodas.Name = "TSMI_CopiarTodas"
        Me.TSMI_CopiarTodas.Size = New System.Drawing.Size(212, 22)
        Me.TSMI_CopiarTodas.Text = "Copiar en todas las Celdas"
        '
        'TSMI_LimpiarTodas
        '
        Me.TSMI_LimpiarTodas.Name = "TSMI_LimpiarTodas"
        Me.TSMI_LimpiarTodas.Size = New System.Drawing.Size(212, 22)
        Me.TSMI_LimpiarTodas.Text = "Limpiar todas"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Info
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(712, 24)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "INTEGRANTES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Fr_GestiónCuadrillas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 490)
        Me.Controls.Add(Me.Dgv_Integrantes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Fr_GestiónCuadrillas"
        Me.Text = "Gestión Cuadrillas"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Dgv_Integrantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_opciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Integrantes As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Bt_salir As System.Windows.Forms.Button
    Friend WithEvents OK_Guardar As System.Windows.Forms.Button
    Friend WithEvents Tx_NombreCuadrilla As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cb_Activo As System.Windows.Forms.CheckBox
    Friend WithEvents Ll_Agregardesdeportapapeles As System.Windows.Forms.LinkLabel
    Friend WithEvents Cms_opciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMI_CopiarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_LimpiarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DGVTBC_IDCUADRILLA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_ORDEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_IDPERSONA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_IDCONTRATO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_CODIGOCONTRATO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_NOMBREPERSONA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_IDTIPORECURSO As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
