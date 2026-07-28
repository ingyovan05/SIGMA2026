<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Asociar
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.Ll_Asociar = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Ll_Asociar
        '
        Me.Ll_Asociar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ll_Asociar.Location = New System.Drawing.Point(0, 0)
        Me.Ll_Asociar.Name = "Ll_Asociar"
        Me.Ll_Asociar.Size = New System.Drawing.Size(219, 20)
        Me.Ll_Asociar.TabIndex = 70
        Me.Ll_Asociar.TabStop = True
        Me.Ll_Asociar.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'Cu_Asociar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Ll_Asociar)
        Me.Name = "Cu_Asociar"
        Me.Size = New System.Drawing.Size(219, 20)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Ll_Asociar As System.Windows.Forms.LinkLabel

End Class
