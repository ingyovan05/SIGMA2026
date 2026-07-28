<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Recursos
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
        Me.Pn_Filtro = New System.Windows.Forms.Panel()
        Me.Gb_Filtro = New System.Windows.Forms.GroupBox()
        Me.Ck_Filtrar = New System.Windows.Forms.CheckBox()
        Me.Cb_Filtrar = New System.Windows.Forms.ComboBox()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Dgv_Recursos = New System.Windows.Forms.DataGridView()
        Me.Tlp_Botones = New System.Windows.Forms.TableLayoutPanel()
        Me.Bt_Exportar = New System.Windows.Forms.Button()
        Me.Pn_Filtro.SuspendLayout()
        Me.Gb_Filtro.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        CType(Me.Dgv_Recursos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tlp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Filtro
        '
        Me.Pn_Filtro.Controls.Add(Me.Gb_Filtro)
        Me.Pn_Filtro.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Filtro.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Filtro.Name = "Pn_Filtro"
        Me.Pn_Filtro.Size = New System.Drawing.Size(624, 60)
        Me.Pn_Filtro.TabIndex = 0
        '
        'Gb_Filtro
        '
        Me.Gb_Filtro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Gb_Filtro.Controls.Add(Me.Ck_Filtrar)
        Me.Gb_Filtro.Controls.Add(Me.Cb_Filtrar)
        Me.Gb_Filtro.Controls.Add(Me.Tx_Descripcion)
        Me.Gb_Filtro.Location = New System.Drawing.Point(3, 3)
        Me.Gb_Filtro.Name = "Gb_Filtro"
        Me.Gb_Filtro.Size = New System.Drawing.Size(618, 51)
        Me.Gb_Filtro.TabIndex = 0
        Me.Gb_Filtro.TabStop = False
        Me.Gb_Filtro.Text = "Filtro"
        '
        'Ck_Filtrar
        '
        Me.Ck_Filtrar.AutoSize = True
        Me.Ck_Filtrar.Checked = True
        Me.Ck_Filtrar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_Filtrar.Location = New System.Drawing.Point(10, 20)
        Me.Ck_Filtrar.Name = "Ck_Filtrar"
        Me.Ck_Filtrar.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtrar.TabIndex = 0
        Me.Ck_Filtrar.UseVisualStyleBackColor = True
        '
        'Cb_Filtrar
        '
        Me.Cb_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Filtrar.FormattingEnabled = True
        Me.Cb_Filtrar.Location = New System.Drawing.Point(31, 17)
        Me.Cb_Filtrar.Name = "Cb_Filtrar"
        Me.Cb_Filtrar.Size = New System.Drawing.Size(210, 21)
        Me.Cb_Filtrar.TabIndex = 1
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Descripcion.Location = New System.Drawing.Point(247, 17)
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(362, 20)
        Me.Tx_Descripcion.TabIndex = 2
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cerrar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(81, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(543, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cerrar.Location = New System.Drawing.Point(465, 3)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 0
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Dgv_Recursos
        '
        Me.Dgv_Recursos.AllowUserToAddRows = False
        Me.Dgv_Recursos.AllowUserToDeleteRows = False
        Me.Dgv_Recursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Recursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Recursos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Recursos.Location = New System.Drawing.Point(0, 60)
        Me.Dgv_Recursos.Name = "Dgv_Recursos"
        Me.Dgv_Recursos.ReadOnly = True
        Me.Dgv_Recursos.Size = New System.Drawing.Size(624, 382)
        Me.Dgv_Recursos.TabIndex = 1
        '
        'Tlp_Botones
        '
        Me.Tlp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Tlp_Botones.ColumnCount = 2
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Botones.Controls.Add(Me.Bt_Exportar, 0, 0)
        Me.Tlp_Botones.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_Botones.Location = New System.Drawing.Point(0, 412)
        Me.Tlp_Botones.Name = "Tlp_Botones"
        Me.Tlp_Botones.RowCount = 1
        Me.Tlp_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Botones.Size = New System.Drawing.Size(624, 30)
        Me.Tlp_Botones.TabIndex = 2
        '
        'Bt_Exportar
        '
        Me.Bt_Exportar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Exportar.Location = New System.Drawing.Point(3, 3)
        Me.Bt_Exportar.Name = "Bt_Exportar"
        Me.Bt_Exportar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Exportar.TabIndex = 0
        Me.Bt_Exportar.Text = "Exportar"
        Me.Bt_Exportar.UseVisualStyleBackColor = True
        '
        'Fr_Recursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Bt_Cerrar
        Me.ClientSize = New System.Drawing.Size(624, 442)
        Me.Controls.Add(Me.Tlp_Botones)
        Me.Controls.Add(Me.Dgv_Recursos)
        Me.Controls.Add(Me.Pn_Filtro)
        Me.Name = "Fr_Recursos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ver Recursos"
        Me.Pn_Filtro.ResumeLayout(False)
        Me.Gb_Filtro.ResumeLayout(False)
        Me.Gb_Filtro.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        CType(Me.Dgv_Recursos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tlp_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Filtro As System.Windows.Forms.Panel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Dgv_Recursos As System.Windows.Forms.DataGridView
    Friend WithEvents Gb_Filtro As System.Windows.Forms.GroupBox
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Cb_Filtrar As System.Windows.Forms.ComboBox
    Friend WithEvents Ck_Filtrar As System.Windows.Forms.CheckBox
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Tlp_Botones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Bt_Exportar As System.Windows.Forms.Button
End Class
