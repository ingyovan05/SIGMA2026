<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_RegistrarTemperatura
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_Base = New System.Windows.Forms.Label()
        Me.Lb_FechaRegistro = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Tb_Temperatura = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(101, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Temperatura:"
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.ForeColor = System.Drawing.Color.Black
        Me.Lb_Nombre.Location = New System.Drawing.Point(50, 11)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(62, 15)
        Me.Lb_Nombre.TabIndex = 0
        Me.Lb_Nombre.Text = "Nombre:"
        Me.Lb_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(239, 6)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 3
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(320, 6)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 4
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel1.Controls.Add(Me.Lb_Base)
        Me.Panel1.Controls.Add(Me.Lb_FechaRegistro)
        Me.Panel1.Controls.Add(Me.Lb_Nombre)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(409, 81)
        Me.Panel1.TabIndex = 5
        '
        'Lb_Base
        '
        Me.Lb_Base.AutoSize = True
        Me.Lb_Base.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Base.Location = New System.Drawing.Point(69, 35)
        Me.Lb_Base.Name = "Lb_Base"
        Me.Lb_Base.Size = New System.Drawing.Size(43, 15)
        Me.Lb_Base.TabIndex = 6
        Me.Lb_Base.Text = "Base:"
        '
        'Lb_FechaRegistro
        '
        Me.Lb_FechaRegistro.AutoSize = True
        Me.Lb_FechaRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_FechaRegistro.Location = New System.Drawing.Point(4, 59)
        Me.Lb_FechaRegistro.Name = "Lb_FechaRegistro"
        Me.Lb_FechaRegistro.Size = New System.Drawing.Size(108, 15)
        Me.Lb_FechaRegistro.TabIndex = 5
        Me.Lb_FechaRegistro.Text = "Fecha Registro:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel2.Controls.Add(Me.Bt_Cerrar)
        Me.Panel2.Controls.Add(Me.Bt_Guardar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 139)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(409, 32)
        Me.Panel2.TabIndex = 6
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.Tb_Temperatura)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 81)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(409, 58)
        Me.Panel3.TabIndex = 7
        '
        'Tb_Temperatura
        '
        Me.Tb_Temperatura.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_Temperatura.Location = New System.Drawing.Point(203, 9)
        Me.Tb_Temperatura.MaxLength = 4
        Me.Tb_Temperatura.Name = "Tb_Temperatura"
        Me.Tb_Temperatura.Size = New System.Drawing.Size(79, 38)
        Me.Tb_Temperatura.TabIndex = 2
        '
        'Fr_RegistrarTemperatura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 171)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximumSize = New System.Drawing.Size(425, 210)
        Me.MinimumSize = New System.Drawing.Size(425, 210)
        Me.Name = "Fr_RegistrarTemperatura"
        Me.Text = "Registrar Temperatura"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Lb_FechaRegistro As System.Windows.Forms.Label
    Friend WithEvents Tb_Temperatura As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Base As System.Windows.Forms.Label
End Class
