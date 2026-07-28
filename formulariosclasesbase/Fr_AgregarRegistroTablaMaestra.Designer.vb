<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AgregarRegistroTablaMaestra
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
        Me.Bt_Actualizar = New System.Windows.Forms.Button()
        Me.Dgv_Maestra = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        CType(Me.Dgv_Maestra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bt_Actualizar
        '
        Me.Bt_Actualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Actualizar.Enabled = False
        Me.Bt_Actualizar.Location = New System.Drawing.Point(503, 6)
        Me.Bt_Actualizar.Name = "Bt_Actualizar"
        Me.Bt_Actualizar.Size = New System.Drawing.Size(120, 23)
        Me.Bt_Actualizar.TabIndex = 7
        Me.Bt_Actualizar.Text = "Guardar Cambios"
        Me.Bt_Actualizar.UseVisualStyleBackColor = True
        '
        'Dgv_Maestra
        '
        Me.Dgv_Maestra.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Maestra.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_Maestra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_Maestra.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_Maestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Maestra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Maestra.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Maestra.Name = "Dgv_Maestra"
        Me.Dgv_Maestra.Size = New System.Drawing.Size(719, 338)
        Me.Dgv_Maestra.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Controls.Add(Me.Bt_Actualizar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 338)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 33)
        Me.Panel1.TabIndex = 8
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Cancelar.Enabled = False
        Me.Bt_Cancelar.Location = New System.Drawing.Point(629, 6)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(87, 23)
        Me.Bt_Cancelar.TabIndex = 8
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Fr_AgregarRegistroTablaMaestra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 371)
        Me.Controls.Add(Me.Dgv_Maestra)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_AgregarRegistroTablaMaestra"
        Me.Text = "Agregar Registro Tabla Maestra"
        CType(Me.Dgv_Maestra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bt_Actualizar As System.Windows.Forms.Button
    Friend WithEvents Dgv_Maestra As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
End Class
