<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ImprimirPazYSalvos
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Dgv_Cedula = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Bt_AgregarCedulaPortapapeles = New System.Windows.Forms.Button()
        Me.Bt_LimpiarTabla = New System.Windows.Forms.Button()
        Me.Lb_TotalCedulla = New System.Windows.Forms.Label()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Cb_VistaPrevia = New System.Windows.Forms.CheckBox()
        Me.DGVTBC_IDENTIFICACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_Cedula, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Dgv_Cedula)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 415)
        Me.Panel1.TabIndex = 1
        '
        'Dgv_Cedula
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Cedula.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Cedula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Cedula.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBC_IDENTIFICACION, Me.Nombre})
        Me.Dgv_Cedula.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Cedula.Location = New System.Drawing.Point(0, 27)
        Me.Dgv_Cedula.Name = "Dgv_Cedula"
        Me.Dgv_Cedula.Size = New System.Drawing.Size(393, 388)
        Me.Dgv_Cedula.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(393, 27)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Info
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(393, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lista Cédulas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bt_AgregarCedulaPortapapeles
        '
        Me.Bt_AgregarCedulaPortapapeles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Bt_AgregarCedulaPortapapeles.Location = New System.Drawing.Point(399, 27)
        Me.Bt_AgregarCedulaPortapapeles.Name = "Bt_AgregarCedulaPortapapeles"
        Me.Bt_AgregarCedulaPortapapeles.Size = New System.Drawing.Size(166, 23)
        Me.Bt_AgregarCedulaPortapapeles.TabIndex = 2
        Me.Bt_AgregarCedulaPortapapeles.Text = "<-- Agregar desde portapapeles"
        Me.Bt_AgregarCedulaPortapapeles.UseVisualStyleBackColor = True
        '
        'Bt_LimpiarTabla
        '
        Me.Bt_LimpiarTabla.Location = New System.Drawing.Point(399, 56)
        Me.Bt_LimpiarTabla.Name = "Bt_LimpiarTabla"
        Me.Bt_LimpiarTabla.Size = New System.Drawing.Size(166, 23)
        Me.Bt_LimpiarTabla.TabIndex = 11
        Me.Bt_LimpiarTabla.Text = "Limpiar Tabla"
        Me.Bt_LimpiarTabla.UseVisualStyleBackColor = True
        '
        'Lb_TotalCedulla
        '
        Me.Lb_TotalCedulla.AutoSize = True
        Me.Lb_TotalCedulla.Location = New System.Drawing.Point(399, 349)
        Me.Lb_TotalCedulla.Name = "Lb_TotalCedulla"
        Me.Lb_TotalCedulla.Size = New System.Drawing.Size(75, 13)
        Me.Lb_TotalCedulla.TabIndex = 12
        Me.Lb_TotalCedulla.Text = "Total Cédulas:"
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(480, 380)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 13
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(399, 379)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 14
        Me.Bt_Cancelar.Text = "Cerrar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Cb_VistaPrevia
        '
        Me.Cb_VistaPrevia.AutoSize = True
        Me.Cb_VistaPrevia.Checked = True
        Me.Cb_VistaPrevia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_VistaPrevia.Location = New System.Drawing.Point(402, 85)
        Me.Cb_VistaPrevia.Name = "Cb_VistaPrevia"
        Me.Cb_VistaPrevia.Size = New System.Drawing.Size(101, 17)
        Me.Cb_VistaPrevia.TabIndex = 15
        Me.Cb_VistaPrevia.Text = "Ver Vista Previa"
        Me.Cb_VistaPrevia.UseVisualStyleBackColor = True
        '
        'DGVTBC_IDENTIFICACION
        '
        Me.DGVTBC_IDENTIFICACION.HeaderText = "Cédula"
        Me.DGVTBC_IDENTIFICACION.Name = "DGVTBC_IDENTIFICACION"
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "CÓDIGO"
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 220
        '
        'Fr_ImprimirPazYSalvos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 415)
        Me.Controls.Add(Me.Cb_VistaPrevia)
        Me.Controls.Add(Me.Bt_Cancelar)
        Me.Controls.Add(Me.Bt_Aceptar)
        Me.Controls.Add(Me.Lb_TotalCedulla)
        Me.Controls.Add(Me.Bt_LimpiarTabla)
        Me.Controls.Add(Me.Bt_AgregarCedulaPortapapeles)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Fr_ImprimirPazYSalvos"
        Me.Text = "Imprimir Paz y Salvos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Dgv_Cedula, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Cedula As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bt_AgregarCedulaPortapapeles As System.Windows.Forms.Button
    Friend WithEvents Bt_LimpiarTabla As System.Windows.Forms.Button
    Friend WithEvents Lb_TotalCedulla As System.Windows.Forms.Label
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Cb_VistaPrevia As System.Windows.Forms.CheckBox
    Friend WithEvents DGVTBC_IDENTIFICACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
