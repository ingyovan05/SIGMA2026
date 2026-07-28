<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_TomarFoto
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
        Me.foto = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.iniciar = New System.Windows.Forms.Button()
        Me.imagen = New System.Windows.Forms.PictureBox()
        Me.Forma = New System.Windows.Forms.Button()
        CType(Me.foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'foto
        '
        Me.foto.BackColor = System.Drawing.Color.White
        Me.foto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.foto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.foto.Location = New System.Drawing.Point(0, 0)
        Me.foto.Name = "foto"
        Me.foto.Size = New System.Drawing.Size(320, 240)
        Me.foto.TabIndex = 10
        Me.foto.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.foto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 240)
        Me.Panel1.TabIndex = 11
        '
        'guardar
        '
        Me.guardar.Location = New System.Drawing.Point(75, 4)
        Me.guardar.Name = "guardar"
        Me.guardar.Size = New System.Drawing.Size(75, 23)
        Me.guardar.TabIndex = 12
        Me.guardar.Text = "Capturar"
        Me.guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(156, 4)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 13
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel2.Controls.Add(Me.iniciar)
        Me.Panel2.Controls.Add(Me.imagen)
        Me.Panel2.Controls.Add(Me.Forma)
        Me.Panel2.Controls.Add(Me.guardar)
        Me.Panel2.Controls.Add(Me.Bt_Cancelar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 240)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(320, 32)
        Me.Panel2.TabIndex = 14
        '
        'iniciar
        '
        Me.iniciar.Location = New System.Drawing.Point(3, 3)
        Me.iniciar.Name = "iniciar"
        Me.iniciar.Size = New System.Drawing.Size(20, 23)
        Me.iniciar.TabIndex = 16
        Me.iniciar.Text = "iniciar"
        Me.iniciar.UseVisualStyleBackColor = True
        Me.iniciar.Visible = False
        '
        'imagen
        '
        Me.imagen.Location = New System.Drawing.Point(239, 3)
        Me.imagen.Name = "imagen"
        Me.imagen.Size = New System.Drawing.Size(69, 22)
        Me.imagen.TabIndex = 15
        Me.imagen.TabStop = False
        Me.imagen.Visible = False
        '
        'Forma
        '
        Me.Forma.Location = New System.Drawing.Point(29, 4)
        Me.Forma.Name = "Forma"
        Me.Forma.Size = New System.Drawing.Size(20, 23)
        Me.Forma.TabIndex = 14
        Me.Forma.Text = "Forma"
        Me.Forma.UseVisualStyleBackColor = True
        Me.Forma.Visible = False
        '
        'Fr_TomarFoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 272)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(336, 311)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(336, 311)
        Me.Name = "Fr_TomarFoto"
        Me.Text = "Tomar Foto"
        CType(Me.foto,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel2.ResumeLayout(false)
        CType(Me.imagen,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents foto As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Forma As System.Windows.Forms.Button
    Friend WithEvents iniciar As System.Windows.Forms.Button
    Public WithEvents imagen As System.Windows.Forms.PictureBox
End Class
