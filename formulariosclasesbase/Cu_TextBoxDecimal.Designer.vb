<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_TextBoxDecimal
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
        Me.components = New System.ComponentModel.Container()
        Me.Ep_ErrorDecimal = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Tx_ValorDecimal = New System.Windows.Forms.TextBox()
        CType(Me.Ep_ErrorDecimal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ep_ErrorDecimal
        '
        Me.Ep_ErrorDecimal.ContainerControl = Me
        '
        'Tx_ValorDecimal
        '
        Me.Tx_ValorDecimal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ep_ErrorDecimal.SetIconAlignment(Me.Tx_ValorDecimal, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.Ep_ErrorDecimal.SetIconPadding(Me.Tx_ValorDecimal, -18)
        Me.Tx_ValorDecimal.Location = New System.Drawing.Point(0, 0)
        Me.Tx_ValorDecimal.Margin = New System.Windows.Forms.Padding(0)
        Me.Tx_ValorDecimal.MaxLength = 20
        Me.Tx_ValorDecimal.Name = "Tx_ValorDecimal"
        Me.Tx_ValorDecimal.Size = New System.Drawing.Size(100, 20)
        Me.Tx_ValorDecimal.TabIndex = 0
        Me.Tx_ValorDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cu_TextBoxDecimal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Tx_ValorDecimal)
        Me.Name = "Cu_TextBoxDecimal"
        Me.Size = New System.Drawing.Size(100, 20)
        CType(Me.Ep_ErrorDecimal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ep_ErrorDecimal As System.Windows.Forms.ErrorProvider
    Friend WithEvents Tx_ValorDecimal As System.Windows.Forms.TextBox

End Class
