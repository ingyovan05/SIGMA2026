<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_NumeroAprobacion
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
        Me.Pn_Contenido = New System.Windows.Forms.Panel()
        Me.Gl_Comentario = New FormulariosSisControl.GrowLabel()
        Me.Lb_Notificacion = New System.Windows.Forms.Label()
        Me.Ll_NumAprobacion = New System.Windows.Forms.LinkLabel()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Bt_Copiar = New System.Windows.Forms.Button()
        Me.Pn_Contenido.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Contenido
        '
        Me.Pn_Contenido.Controls.Add(Me.Gl_Comentario)
        Me.Pn_Contenido.Controls.Add(Me.Lb_Notificacion)
        Me.Pn_Contenido.Controls.Add(Me.Ll_NumAprobacion)
        Me.Pn_Contenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Contenido.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Contenido.Name = "Pn_Contenido"
        Me.Pn_Contenido.Size = New System.Drawing.Size(344, 131)
        Me.Pn_Contenido.TabIndex = 0
        '
        'Gl_Comentario
        '
        Me.Gl_Comentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gl_Comentario.Location = New System.Drawing.Point(10, 90)
        Me.Gl_Comentario.Name = "Gl_Comentario"
        Me.Gl_Comentario.Size = New System.Drawing.Size(322, 26)
        Me.Gl_Comentario.TabIndex = 3
        Me.Gl_Comentario.Text = "Notificar al proveedor para que sea incluído en las observaciones de la Factura E" & _
    "lectrónica."
        '
        'Lb_Notificacion
        '
        Me.Lb_Notificacion.AutoSize = True
        Me.Lb_Notificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Notificacion.Location = New System.Drawing.Point(10, 14)
        Me.Lb_Notificacion.Name = "Lb_Notificacion"
        Me.Lb_Notificacion.Size = New System.Drawing.Size(211, 20)
        Me.Lb_Notificacion.TabIndex = 0
        Me.Lb_Notificacion.Text = "El número de aprobación es:"
        '
        'Ll_NumAprobacion
        '
        Me.Ll_NumAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_NumAprobacion.Location = New System.Drawing.Point(12, 50)
        Me.Ll_NumAprobacion.Name = "Ll_NumAprobacion"
        Me.Ll_NumAprobacion.Size = New System.Drawing.Size(320, 25)
        Me.Ll_NumAprobacion.TabIndex = 1
        Me.Ll_NumAprobacion.TabStop = True
        Me.Ll_NumAprobacion.Text = "00000000"
        Me.Ll_NumAprobacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Copiar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 131)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(344, 30)
        Me.Flp_Botones.TabIndex = 0
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(266, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Bt_Copiar
        '
        Me.Bt_Copiar.AutoSize = True
        Me.Bt_Copiar.Location = New System.Drawing.Point(137, 3)
        Me.Bt_Copiar.Name = "Bt_Copiar"
        Me.Bt_Copiar.Size = New System.Drawing.Size(123, 23)
        Me.Bt_Copiar.TabIndex = 1
        Me.Bt_Copiar.Text = "Copiar al Portapapeles"
        Me.Bt_Copiar.UseVisualStyleBackColor = True
        '
        'Fr_NumeroAprobacion
        '
        Me.AcceptButton = Me.Bt_Aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 161)
        Me.Controls.Add(Me.Pn_Contenido)
        Me.Controls.Add(Me.Flp_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_NumeroAprobacion"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aprobación guardada"
        Me.Pn_Contenido.ResumeLayout(False)
        Me.Pn_Contenido.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.Flp_Botones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Contenido As System.Windows.Forms.Panel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Ll_NumAprobacion As System.Windows.Forms.LinkLabel
    Friend WithEvents Lb_Notificacion As System.Windows.Forms.Label
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Bt_Copiar As System.Windows.Forms.Button
    Friend WithEvents Gl_Comentario As FormulariosSisControl.GrowLabel
End Class
