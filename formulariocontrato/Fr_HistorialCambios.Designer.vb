<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_HistorialCambios
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Lb_Estado = New System.Windows.Forms.Label()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label_Nombre = New System.Windows.Forms.Label()
        Me.Label_Cedula = New System.Windows.Forms.Label()
        Me.Dgv_HistorialCambios = New System.Windows.Forms.DataGridView()
        Me.DGVHC_ObservacionAuditoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVHC_Registra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVHC_FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVHC_Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVHC_CodigoAuditoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVHC_Modifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Dgv_DetalleCambios = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Lb_TituloDetalles = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_Botones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_HistorialCambios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_DetalleCambios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Pn_Botones.Controls.Add(Me.Lb_Estado)
        Me.Pn_Botones.Controls.Add(Me.Button_Cancelar)
        Me.Pn_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 431)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(833, 30)
        Me.Pn_Botones.TabIndex = 3
        '
        'Lb_Estado
        '
        Me.Lb_Estado.AutoSize = True
        Me.Lb_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Estado.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Estado.Location = New System.Drawing.Point(18, 5)
        Me.Lb_Estado.Name = "Lb_Estado"
        Me.Lb_Estado.Size = New System.Drawing.Size(71, 20)
        Me.Lb_Estado.TabIndex = 0
        Me.Lb_Estado.Text = "Estado:"
        Me.Lb_Estado.Visible = False
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Cancelar.Location = New System.Drawing.Point(749, 3)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cancelar.TabIndex = 2
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Aceptar.Location = New System.Drawing.Point(664, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 1
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label_Nombre)
        Me.Panel1.Controls.Add(Me.Label_Cedula)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(833, 41)
        Me.Panel1.TabIndex = 4
        '
        'Label_Nombre
        '
        Me.Label_Nombre.AutoSize = True
        Me.Label_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Nombre.Location = New System.Drawing.Point(18, 12)
        Me.Label_Nombre.Name = "Label_Nombre"
        Me.Label_Nombre.Size = New System.Drawing.Size(71, 16)
        Me.Label_Nombre.TabIndex = 0
        Me.Label_Nombre.Text = "Nombre: "
        '
        'Label_Cedula
        '
        Me.Label_Cedula.AutoSize = True
        Me.Label_Cedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Cedula.Location = New System.Drawing.Point(447, 12)
        Me.Label_Cedula.Name = "Label_Cedula"
        Me.Label_Cedula.Size = New System.Drawing.Size(108, 16)
        Me.Label_Cedula.TabIndex = 1
        Me.Label_Cedula.Text = "Identificación: "
        '
        'Dgv_HistorialCambios
        '
        Me.Dgv_HistorialCambios.AllowUserToAddRows = False
        Me.Dgv_HistorialCambios.AllowUserToDeleteRows = False
        Me.Dgv_HistorialCambios.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_HistorialCambios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_HistorialCambios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_HistorialCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_HistorialCambios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVHC_ObservacionAuditoria, Me.DGVHC_Registra, Me.DGVHC_FechaRegistro, Me.DGVHC_Fecha, Me.DGVHC_CodigoAuditoria, Me.DGVHC_Modifica})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv_HistorialCambios.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_HistorialCambios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_HistorialCambios.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_HistorialCambios.Name = "Dgv_HistorialCambios"
        Me.Dgv_HistorialCambios.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_HistorialCambios.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_HistorialCambios.Size = New System.Drawing.Size(833, 195)
        Me.Dgv_HistorialCambios.TabIndex = 5
        '
        'DGVHC_ObservacionAuditoria
        '
        Me.DGVHC_ObservacionAuditoria.DataPropertyName = "ID"
        Me.DGVHC_ObservacionAuditoria.HeaderText = "ID"
        Me.DGVHC_ObservacionAuditoria.Name = "DGVHC_ObservacionAuditoria"
        Me.DGVHC_ObservacionAuditoria.ReadOnly = True
        '
        'DGVHC_Registra
        '
        Me.DGVHC_Registra.DataPropertyName = "NOMBREREGISTRA"
        Me.DGVHC_Registra.HeaderText = "Creado por"
        Me.DGVHC_Registra.Name = "DGVHC_Registra"
        Me.DGVHC_Registra.ReadOnly = True
        '
        'DGVHC_FechaRegistro
        '
        Me.DGVHC_FechaRegistro.DataPropertyName = "FECHAREGISTRO"
        Me.DGVHC_FechaRegistro.HeaderText = "Fecha Creación"
        Me.DGVHC_FechaRegistro.Name = "DGVHC_FechaRegistro"
        Me.DGVHC_FechaRegistro.ReadOnly = True
        '
        'DGVHC_Fecha
        '
        Me.DGVHC_Fecha.DataPropertyName = "FECHAAUDITORIA"
        Me.DGVHC_Fecha.HeaderText = "Fecha de Cambio"
        Me.DGVHC_Fecha.Name = "DGVHC_Fecha"
        Me.DGVHC_Fecha.ReadOnly = True
        '
        'DGVHC_CodigoAuditoria
        '
        Me.DGVHC_CodigoAuditoria.DataPropertyName = "TIPO"
        Me.DGVHC_CodigoAuditoria.HeaderText = "Tipo de Cambio"
        Me.DGVHC_CodigoAuditoria.Name = "DGVHC_CodigoAuditoria"
        Me.DGVHC_CodigoAuditoria.ReadOnly = True
        '
        'DGVHC_Modifica
        '
        Me.DGVHC_Modifica.DataPropertyName = "NOMBREMODIFICA"
        Me.DGVHC_Modifica.HeaderText = "Modificado por"
        Me.DGVHC_Modifica.Name = "DGVHC_Modifica"
        Me.DGVHC_Modifica.ReadOnly = True
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 19
        Me.ListBox1.Location = New System.Drawing.Point(450, 17)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(329, 118)
        Me.ListBox1.TabIndex = 6
        Me.ListBox1.Visible = False
        '
        'Dgv_DetalleCambios
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_DetalleCambios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Dgv_DetalleCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_DetalleCambios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column2})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv_DetalleCambios.DefaultCellStyle = DataGridViewCellStyle6
        Me.Dgv_DetalleCambios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_DetalleCambios.Location = New System.Drawing.Point(0, 18)
        Me.Dgv_DetalleCambios.Name = "Dgv_DetalleCambios"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_DetalleCambios.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Dgv_DetalleCambios.Size = New System.Drawing.Size(833, 173)
        Me.Dgv_DetalleCambios.TabIndex = 7
        '
        'Column1
        '
        Me.Column1.HeaderText = "Modificación"
        Me.Column1.Name = "Column1"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Registro Posterior"
        Me.Column3.Name = "Column3"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Registro Anterior"
        Me.Column2.Name = "Column2"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Dgv_HistorialCambios)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(833, 195)
        Me.Panel2.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ListBox1)
        Me.Panel3.Controls.Add(Me.Dgv_DetalleCambios)
        Me.Panel3.Controls.Add(Me.Lb_TituloDetalles)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(833, 191)
        Me.Panel3.TabIndex = 11
        '
        'Lb_TituloDetalles
        '
        Me.Lb_TituloDetalles.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Lb_TituloDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_TituloDetalles.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_TituloDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TituloDetalles.ForeColor = System.Drawing.Color.Black
        Me.Lb_TituloDetalles.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TituloDetalles.Name = "Lb_TituloDetalles"
        Me.Lb_TituloDetalles.Size = New System.Drawing.Size(833, 18)
        Me.Lb_TituloDetalles.TabIndex = 8
        Me.Lb_TituloDetalles.Text = "Detalle Cambios Realizados "
        Me.Lb_TituloDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 41)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Size = New System.Drawing.Size(833, 390)
        Me.SplitContainer1.SplitterDistance = 195
        Me.SplitContainer1.TabIndex = 12
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDAUDITORIA"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 30
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CODIGOTIPOAUDITORIA"
        Me.DataGridViewTextBoxColumn2.HeaderText = "FECHAAUDITORIA"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "IDUSUARIOAUDITORIA"
        Me.DataGridViewTextBoxColumn3.HeaderText = "OBSERVACIONAUDITORIA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "MODIFICA"
        Me.DataGridViewTextBoxColumn4.HeaderText = "CODIGOTIPOAUDITORIA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "FECHAAUDITORIA"
        Me.DataGridViewTextBoxColumn5.HeaderText = "IDAUDITORIA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "NOMBREMODIFICA"
        Me.DataGridViewTextBoxColumn6.HeaderText = "IDUSUARIOAUDITORIA"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Column2"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Column3"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Registro Anterior"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'Fr_HistorialCambios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 461)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pn_Botones)
        Me.MaximumSize = New System.Drawing.Size(849, 500)
        Me.MinimumSize = New System.Drawing.Size(849, 500)
        Me.Name = "Fr_HistorialCambios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambios Realizados Contrato"
        Me.Pn_Botones.ResumeLayout(False)
        Me.Pn_Botones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Dgv_HistorialCambios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_DetalleCambios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents Lb_Estado As System.Windows.Forms.Label
    Friend WithEvents Button_Cancelar As System.Windows.Forms.Button
    Public WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Public WithEvents Label_Nombre As System.Windows.Forms.Label
    Public WithEvents Label_Cedula As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dgv_HistorialCambios As System.Windows.Forms.DataGridView
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Dgv_DetalleCambios As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Lb_TituloDetalles As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVHC_ObservacionAuditoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVHC_Registra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVHC_FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVHC_Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVHC_CodigoAuditoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVHC_Modifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
