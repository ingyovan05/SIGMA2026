<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_CondicionPago
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Dgv_Condiciones = New System.Windows.Forms.DataGridView()
        Me.Rb_FechaFactura = New System.Windows.Forms.RadioButton()
        Me.Rb_FechaRadicado = New System.Windows.Forms.RadioButton()
        Me.Flp_FechaCredito = New System.Windows.Forms.FlowLayoutPanel()
        Me.Ck_AplicaDctoFinanciero = New System.Windows.Forms.CheckBox()
        Me.Gb_FechaCredito = New System.Windows.Forms.GroupBox()
        Me.Flp_DctoFinanciero = New System.Windows.Forms.FlowLayoutPanel()
        Me.Pn_FechaCredito = New System.Windows.Forms.Panel()
        Me.DgvTx_Porcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvCb_Modalidad = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DgvTx_Dias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Flp_Botones.SuspendLayout()
        CType(Me.Dgv_Condiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flp_FechaCredito.SuspendLayout()
        Me.Gb_FechaCredito.SuspendLayout()
        Me.Flp_DctoFinanciero.SuspendLayout()
        Me.Pn_FechaCredito.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 231)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(284, 30)
        Me.Flp_Botones.TabIndex = 2
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.Location = New System.Drawing.Point(206, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(125, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 1
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Dgv_Condiciones
        '
        Me.Dgv_Condiciones.AllowUserToResizeRows = False
        Me.Dgv_Condiciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Condiciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Condiciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DgvTx_Porcentaje, Me.DgvCb_Modalidad, Me.DgvTx_Dias})
        Me.Dgv_Condiciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Condiciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Condiciones.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Condiciones.Name = "Dgv_Condiciones"
        Me.Dgv_Condiciones.RowHeadersWidth = 25
        Me.Dgv_Condiciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Condiciones.Size = New System.Drawing.Size(284, 131)
        Me.Dgv_Condiciones.TabIndex = 0
        '
        'Rb_FechaFactura
        '
        Me.Rb_FechaFactura.AutoSize = True
        Me.Rb_FechaFactura.Location = New System.Drawing.Point(10, 5)
        Me.Rb_FechaFactura.Name = "Rb_FechaFactura"
        Me.Rb_FechaFactura.Size = New System.Drawing.Size(109, 17)
        Me.Rb_FechaFactura.TabIndex = 0
        Me.Rb_FechaFactura.Text = "Fecha de Factura"
        Me.Rb_FechaFactura.UseVisualStyleBackColor = True
        '
        'Rb_FechaRadicado
        '
        Me.Rb_FechaRadicado.AutoSize = True
        Me.Rb_FechaRadicado.Checked = True
        Me.Rb_FechaRadicado.Location = New System.Drawing.Point(10, 28)
        Me.Rb_FechaRadicado.Name = "Rb_FechaRadicado"
        Me.Rb_FechaRadicado.Size = New System.Drawing.Size(151, 17)
        Me.Rb_FechaRadicado.TabIndex = 1
        Me.Rb_FechaRadicado.TabStop = True
        Me.Rb_FechaRadicado.Text = "Fecha Radicación Factura"
        Me.Rb_FechaRadicado.UseVisualStyleBackColor = True
        '
        'Flp_FechaCredito
        '
        Me.Flp_FechaCredito.Controls.Add(Me.Rb_FechaFactura)
        Me.Flp_FechaCredito.Controls.Add(Me.Rb_FechaRadicado)
        Me.Flp_FechaCredito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_FechaCredito.Location = New System.Drawing.Point(3, 16)
        Me.Flp_FechaCredito.Name = "Flp_FechaCredito"
        Me.Flp_FechaCredito.Padding = New System.Windows.Forms.Padding(7, 2, 0, 0)
        Me.Flp_FechaCredito.Size = New System.Drawing.Size(268, 51)
        Me.Flp_FechaCredito.TabIndex = 0
        '
        'Ck_AplicaDctoFinanciero
        '
        Me.Ck_AplicaDctoFinanciero.AutoSize = True
        Me.Ck_AplicaDctoFinanciero.Location = New System.Drawing.Point(8, 6)
        Me.Ck_AplicaDctoFinanciero.Name = "Ck_AplicaDctoFinanciero"
        Me.Ck_AplicaDctoFinanciero.Size = New System.Drawing.Size(162, 17)
        Me.Ck_AplicaDctoFinanciero.TabIndex = 0
        Me.Ck_AplicaDctoFinanciero.Text = "Aplica Descuento Financiero"
        Me.Ck_AplicaDctoFinanciero.UseVisualStyleBackColor = True
        '
        'Gb_FechaCredito
        '
        Me.Gb_FechaCredito.Controls.Add(Me.Flp_FechaCredito)
        Me.Gb_FechaCredito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gb_FechaCredito.Enabled = False
        Me.Gb_FechaCredito.Location = New System.Drawing.Point(5, 0)
        Me.Gb_FechaCredito.Name = "Gb_FechaCredito"
        Me.Gb_FechaCredito.Size = New System.Drawing.Size(274, 70)
        Me.Gb_FechaCredito.TabIndex = 0
        Me.Gb_FechaCredito.TabStop = False
        Me.Gb_FechaCredito.Text = "Fecha de inicio del Crédito"
        '
        'Flp_DctoFinanciero
        '
        Me.Flp_DctoFinanciero.Controls.Add(Me.Ck_AplicaDctoFinanciero)
        Me.Flp_DctoFinanciero.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_DctoFinanciero.Location = New System.Drawing.Point(0, 201)
        Me.Flp_DctoFinanciero.Name = "Flp_DctoFinanciero"
        Me.Flp_DctoFinanciero.Padding = New System.Windows.Forms.Padding(5, 3, 0, 0)
        Me.Flp_DctoFinanciero.Size = New System.Drawing.Size(284, 30)
        Me.Flp_DctoFinanciero.TabIndex = 1
        '
        'Pn_FechaCredito
        '
        Me.Pn_FechaCredito.Controls.Add(Me.Gb_FechaCredito)
        Me.Pn_FechaCredito.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_FechaCredito.Location = New System.Drawing.Point(0, 131)
        Me.Pn_FechaCredito.Name = "Pn_FechaCredito"
        Me.Pn_FechaCredito.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Pn_FechaCredito.Size = New System.Drawing.Size(284, 70)
        Me.Pn_FechaCredito.TabIndex = 1
        '
        'DgvTx_Porcentaje
        '
        Me.DgvTx_Porcentaje.DataPropertyName = "PORCENTAJE"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DgvTx_Porcentaje.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvTx_Porcentaje.FillWeight = 20.0!
        Me.DgvTx_Porcentaje.HeaderText = "%"
        Me.DgvTx_Porcentaje.MaxInputLength = 3
        Me.DgvTx_Porcentaje.Name = "DgvTx_Porcentaje"
        Me.DgvTx_Porcentaje.ToolTipText = "Porcentaje del pago"
        '
        'DgvCb_Modalidad
        '
        Me.DgvCb_Modalidad.DataPropertyName = "MODALIDAD"
        Me.DgvCb_Modalidad.FillWeight = 60.0!
        Me.DgvCb_Modalidad.HeaderText = "Modalidad"
        Me.DgvCb_Modalidad.Name = "DgvCb_Modalidad"
        Me.DgvCb_Modalidad.Sorted = True
        Me.DgvCb_Modalidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DgvCb_Modalidad.ToolTipText = "Formas en que se efectúa(n) el(los) pago(s)"
        '
        'DgvTx_Dias
        '
        Me.DgvTx_Dias.DataPropertyName = "DIAS"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DgvTx_Dias.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgvTx_Dias.FillWeight = 20.0!
        Me.DgvTx_Dias.HeaderText = "Días"
        Me.DgvTx_Dias.MaxInputLength = 2
        Me.DgvTx_Dias.Name = "DgvTx_Dias"
        Me.DgvTx_Dias.ReadOnly = True
        Me.DgvTx_Dias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DgvTx_Dias.ToolTipText = "Cantidad de días a los que se efectúa el pago a crédito."
        '
        'Fr_CondicionPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Bt_Cancelar
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Dgv_Condiciones)
        Me.Controls.Add(Me.Pn_FechaCredito)
        Me.Controls.Add(Me.Flp_DctoFinanciero)
        Me.Controls.Add(Me.Flp_Botones)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "Fr_CondicionPago"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Definir Condición de Pago"
        Me.Flp_Botones.ResumeLayout(False)
        CType(Me.Dgv_Condiciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flp_FechaCredito.ResumeLayout(False)
        Me.Flp_FechaCredito.PerformLayout()
        Me.Gb_FechaCredito.ResumeLayout(False)
        Me.Flp_DctoFinanciero.ResumeLayout(False)
        Me.Flp_DctoFinanciero.PerformLayout()
        Me.Pn_FechaCredito.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Dgv_Condiciones As System.Windows.Forms.DataGridView
    Friend WithEvents Flp_FechaCredito As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Rb_FechaFactura As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_FechaRadicado As System.Windows.Forms.RadioButton
    Friend WithEvents Ck_AplicaDctoFinanciero As System.Windows.Forms.CheckBox
    Friend WithEvents Gb_FechaCredito As System.Windows.Forms.GroupBox
    Friend WithEvents Flp_DctoFinanciero As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Pn_FechaCredito As System.Windows.Forms.Panel
    Friend WithEvents DgvTx_Porcentaje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvCb_Modalidad As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DgvTx_Dias As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
