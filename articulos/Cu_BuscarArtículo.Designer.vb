<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_BuscarArtículo
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
        Me.Tx_TextoCódigo = New System.Windows.Forms.TextBox()
        Me.Button_Buscar = New System.Windows.Forms.Button()
        Me.Tx_Artículo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Tx_TextoCódigo
        '
        Me.Tx_TextoCódigo.Location = New System.Drawing.Point(4, 3)
        Me.Tx_TextoCódigo.Name = "Tx_TextoCódigo"
        Me.Tx_TextoCódigo.Size = New System.Drawing.Size(56, 20)
        Me.Tx_TextoCódigo.TabIndex = 6
        '
        'Button_Buscar
        '
        Me.Button_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button_Buscar.AutoSize = True
        Me.Button_Buscar.Location = New System.Drawing.Point(253, 2)
        Me.Button_Buscar.Name = "Button_Buscar"
        Me.Button_Buscar.Size = New System.Drawing.Size(29, 23)
        Me.Button_Buscar.TabIndex = 8
        Me.Button_Buscar.Text = "..."
        Me.Button_Buscar.UseVisualStyleBackColor = True
        '
        'Tx_Artículo
        '
        Me.Tx_Artículo.Location = New System.Drawing.Point(66, 3)
        Me.Tx_Artículo.Name = "Tx_Artículo"
        Me.Tx_Artículo.Size = New System.Drawing.Size(181, 20)
        Me.Tx_Artículo.TabIndex = 9
        '
        'Cu_BuscarArtículo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Tx_Artículo)
        Me.Controls.Add(Me.Tx_TextoCódigo)
        Me.Controls.Add(Me.Button_Buscar)
        Me.Name = "Cu_BuscarArtículo"
        Me.Size = New System.Drawing.Size(285, 29)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Tx_TextoCódigo As System.Windows.Forms.TextBox
    Friend WithEvents Button_Buscar As System.Windows.Forms.Button
    Friend WithEvents Tx_Artículo As System.Windows.Forms.TextBox

End Class
