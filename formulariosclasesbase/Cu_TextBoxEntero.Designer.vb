<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_TextBoxEntero
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
        Me.Ep_ErrorEntero = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Tx_ValorEntero = New System.Windows.Forms.TextBox()
        CType(Me.Ep_ErrorEntero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ep_ErrorEntero
        '
        Me.Ep_ErrorEntero.ContainerControl = Me
        '
        'Tx_ValorEntero
        '
        Me.Tx_ValorEntero.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ep_ErrorEntero.SetIconAlignment(Me.Tx_ValorEntero, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.Ep_ErrorEntero.SetIconPadding(Me.Tx_ValorEntero, -18)
        Me.Tx_ValorEntero.Location = New System.Drawing.Point(0, 0)
        Me.Tx_ValorEntero.Margin = New System.Windows.Forms.Padding(0)
        Me.Tx_ValorEntero.MaxLength = 20
        Me.Tx_ValorEntero.Name = "Tx_ValorEntero"
        Me.Tx_ValorEntero.Size = New System.Drawing.Size(100, 20)
        Me.Tx_ValorEntero.TabIndex = 1
        Me.Tx_ValorEntero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cu_TextBoxEntero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Tx_ValorEntero)
        Me.Name = "Cu_TextBoxEntero"
        Me.Size = New System.Drawing.Size(100, 20)
        CType(Me.Ep_ErrorEntero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ep_ErrorEntero As System.Windows.Forms.ErrorProvider
    Friend WithEvents Tx_ValorEntero As System.Windows.Forms.TextBox

End Class
