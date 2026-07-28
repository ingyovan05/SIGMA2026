<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Fecha
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.Gb_Fecha = New System.Windows.Forms.GroupBox
    Me.Lb_Fecha = New System.Windows.Forms.Label
    Me.Gb_Fecha.SuspendLayout()
    Me.SuspendLayout()
    '
    'Gb_Fecha
    '
    Me.Gb_Fecha.BackColor = System.Drawing.Color.Transparent
    Me.Gb_Fecha.Controls.Add(Me.Lb_Fecha)
    Me.Gb_Fecha.Location = New System.Drawing.Point(3, 3)
    Me.Gb_Fecha.Name = "Gb_Fecha"
    Me.Gb_Fecha.Size = New System.Drawing.Size(145, 58)
    Me.Gb_Fecha.TabIndex = 0
    Me.Gb_Fecha.TabStop = False
    Me.Gb_Fecha.Text = "Hoy"
    '
    'Lb_Fecha
    '
    Me.Lb_Fecha.Location = New System.Drawing.Point(6, 14)
    Me.Lb_Fecha.Name = "Lb_Fecha"
    Me.Lb_Fecha.Size = New System.Drawing.Size(123, 39)
    Me.Lb_Fecha.TabIndex = 0
    Me.Lb_Fecha.Text = "Label1"
    Me.Lb_Fecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Cu_Fecha
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Transparent
    Me.Controls.Add(Me.Gb_Fecha)
    Me.Name = "Cu_Fecha"
    Me.Size = New System.Drawing.Size(135, 65)
    Me.Gb_Fecha.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Gb_Fecha As System.Windows.Forms.GroupBox
  Friend WithEvents Lb_Fecha As System.Windows.Forms.Label

End Class
