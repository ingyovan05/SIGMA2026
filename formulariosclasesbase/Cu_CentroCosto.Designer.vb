<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_CentroCosto
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
    Me.Ll_CentroCostos = New System.Windows.Forms.LinkLabel()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'Ll_CentroCostos
    '
    Me.Ll_CentroCostos.AutoSize = True
    Me.Ll_CentroCostos.Location = New System.Drawing.Point(2, 20)
    Me.Ll_CentroCostos.Name = "Ll_CentroCostos"
    Me.Ll_CentroCostos.Size = New System.Drawing.Size(174, 13)
    Me.Ll_CentroCostos.TabIndex = 67
    Me.Ll_CentroCostos.TabStop = True
    Me.Ll_CentroCostos.Text = "XXX-XXXXXXXXXXXXXXX-XXXXX"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(2, 2)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(117, 13)
    Me.Label1.TabIndex = 68
    Me.Label1.Text = "CENTRO DE COSTOS"
    '
    'Cu_CentroCosto
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Ll_CentroCostos)
    Me.Name = "Cu_CentroCosto"
    Me.Size = New System.Drawing.Size(199, 38)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As Windows.Forms.Label
  Public WithEvents Ll_CentroCostos As Windows.Forms.LinkLabel
End Class
