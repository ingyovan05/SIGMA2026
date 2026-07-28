<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_GestionarCalificaciones
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Lb_Persona = New System.Windows.Forms.Label()
        Me.Bt_Imprimir = New System.Windows.Forms.Button()
        Me.Bt_Editar = New System.Windows.Forms.Button()
        Me.Bt_Eliminar = New System.Windows.Forms.Button()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Dgv_ListaCalificaciones = New System.Windows.Forms.DataGridView()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2.SuspendLayout()
        CType(Me.Dgv_ListaCalificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Info
        Me.Panel2.Controls.Add(Me.Lb_Persona)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(944, 34)
        Me.Panel2.TabIndex = 3
        '
        'Lb_Persona
        '
        Me.Lb_Persona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Persona.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Persona.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Persona.Name = "Lb_Persona"
        Me.Lb_Persona.Size = New System.Drawing.Size(944, 34)
        Me.Lb_Persona.TabIndex = 0
        Me.Lb_Persona.Text = "Label1"
        Me.Lb_Persona.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bt_Imprimir
        '
        Me.Bt_Imprimir.Location = New System.Drawing.Point(623, 3)
        Me.Bt_Imprimir.Name = "Bt_Imprimir"
        Me.Bt_Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Imprimir.TabIndex = 4
        Me.Bt_Imprimir.Text = "Imprimir"
        Me.Bt_Imprimir.UseVisualStyleBackColor = True
        '
        'Bt_Editar
        '
        Me.Bt_Editar.Location = New System.Drawing.Point(704, 3)
        Me.Bt_Editar.Name = "Bt_Editar"
        Me.Bt_Editar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Editar.TabIndex = 3
        Me.Bt_Editar.Text = "Editar"
        Me.Bt_Editar.UseVisualStyleBackColor = True
        '
        'Bt_Eliminar
        '
        Me.Bt_Eliminar.Location = New System.Drawing.Point(785, 3)
        Me.Bt_Eliminar.Name = "Bt_Eliminar"
        Me.Bt_Eliminar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Eliminar.TabIndex = 2
        Me.Bt_Eliminar.Text = "Eliminar"
        Me.Bt_Eliminar.UseVisualStyleBackColor = True
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(866, 3)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 1
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Dgv_ListaCalificaciones
        '
        Me.Dgv_ListaCalificaciones.AllowUserToAddRows = False
        Me.Dgv_ListaCalificaciones.AllowUserToDeleteRows = False
        Me.Dgv_ListaCalificaciones.AllowUserToResizeRows = False
        Me.Dgv_ListaCalificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ListaCalificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaCalificaciones.Location = New System.Drawing.Point(0, 34)
        Me.Dgv_ListaCalificaciones.MultiSelect = False
        Me.Dgv_ListaCalificaciones.Name = "Dgv_ListaCalificaciones"
        Me.Dgv_ListaCalificaciones.ReadOnly = True
        Me.Dgv_ListaCalificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_ListaCalificaciones.Size = New System.Drawing.Size(944, 307)
        Me.Dgv_ListaCalificaciones.TabIndex = 5
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro
        Me.FlowLayoutPanel1.Controls.Add(Me.Bt_Cerrar)
        Me.FlowLayoutPanel1.Controls.Add(Me.Bt_Eliminar)
        Me.FlowLayoutPanel1.Controls.Add(Me.Bt_Editar)
        Me.FlowLayoutPanel1.Controls.Add(Me.Bt_Imprimir)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 341)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(944, 30)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'Fr_GestionarCalificaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 371)
        Me.Controls.Add(Me.Dgv_ListaCalificaciones)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "Fr_GestionarCalificaciones"
        Me.Text = "Gestionar Calificaciones"
        Me.Panel2.ResumeLayout(False)
        CType(Me.Dgv_ListaCalificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Lb_Persona As System.Windows.Forms.Label
    Friend WithEvents Bt_Editar As System.Windows.Forms.Button
    Friend WithEvents Bt_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Dgv_ListaCalificaciones As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_Imprimir As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
End Class
