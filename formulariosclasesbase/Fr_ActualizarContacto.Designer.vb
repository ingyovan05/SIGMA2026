<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ActualizarContacto
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Cu_Contacto4 = New Clasesbase.Cu_Contacto()
        Me.Cu_Contacto3 = New Clasesbase.Cu_Contacto()
        Me.Cu_Contacto2 = New Clasesbase.Cu_Contacto()
        Me.Cu_Contacto1 = New Clasesbase.Cu_Contacto()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel3.Controls.Add(Me.Bt_Cancelar)
        Me.Panel3.Controls.Add(Me.Bt_Aceptar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 327)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(705, 30)
        Me.Panel3.TabIndex = 82
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.Location = New System.Drawing.Point(627, 4)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 33
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(546, 4)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 32
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Cu_Contacto4
        '
        Me.Cu_Contacto4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Cu_Contacto4.Location = New System.Drawing.Point(0, 246)
        Me.Cu_Contacto4.Name = "Cu_Contacto4"
        Me.Cu_Contacto4.Size = New System.Drawing.Size(705, 82)
        Me.Cu_Contacto4.TabIndex = 86
        '
        'Cu_Contacto3
        '
        Me.Cu_Contacto3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Cu_Contacto3.Location = New System.Drawing.Point(0, 164)
        Me.Cu_Contacto3.Name = "Cu_Contacto3"
        Me.Cu_Contacto3.Size = New System.Drawing.Size(705, 82)
        Me.Cu_Contacto3.TabIndex = 85
        '
        'Cu_Contacto2
        '
        Me.Cu_Contacto2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Cu_Contacto2.Location = New System.Drawing.Point(0, 82)
        Me.Cu_Contacto2.Name = "Cu_Contacto2"
        Me.Cu_Contacto2.Size = New System.Drawing.Size(705, 82)
        Me.Cu_Contacto2.TabIndex = 84
        '
        'Cu_Contacto1
        '
        Me.Cu_Contacto1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Cu_Contacto1.Location = New System.Drawing.Point(0, 0)
        Me.Cu_Contacto1.Name = "Cu_Contacto1"
        Me.Cu_Contacto1.Size = New System.Drawing.Size(705, 82)
        Me.Cu_Contacto1.TabIndex = 83
        '
        'Fr_ActualizarContacto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 357)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Cu_Contacto4)
        Me.Controls.Add(Me.Cu_Contacto3)
        Me.Controls.Add(Me.Cu_Contacto2)
        Me.Controls.Add(Me.Cu_Contacto1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(721, 395)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(721, 395)
        Me.Name = "Fr_ActualizarContacto"
        Me.Text = "Actualizar Contacto"
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Public WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Public WithEvents Cu_Contacto1 As Clasesbase.Cu_Contacto
    Public WithEvents Cu_Contacto2 As Clasesbase.Cu_Contacto
    Public WithEvents Cu_Contacto3 As Clasesbase.Cu_Contacto
    Public WithEvents Cu_Contacto4 As Clasesbase.Cu_Contacto
End Class
