<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_EditarTipoSubtipo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tb_Tipo = New System.Windows.Forms.TextBox()
        Me.Tb_Subtipo = New System.Windows.Forms.TextBox()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Tb_Nomsubtipo = New System.Windows.Forms.TextBox()
        Me.Tb_NomTipo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(157, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingrese el nombre que desea usar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Subtipo"
        '
        'Tb_Tipo
        '
        Me.Tb_Tipo.Enabled = False
        Me.Tb_Tipo.Location = New System.Drawing.Point(62, 29)
        Me.Tb_Tipo.Name = "Tb_Tipo"
        Me.Tb_Tipo.Size = New System.Drawing.Size(356, 20)
        Me.Tb_Tipo.TabIndex = 3
        '
        'Tb_Subtipo
        '
        Me.Tb_Subtipo.Enabled = False
        Me.Tb_Subtipo.Location = New System.Drawing.Point(62, 54)
        Me.Tb_Subtipo.Name = "Tb_Subtipo"
        Me.Tb_Subtipo.Size = New System.Drawing.Size(356, 20)
        Me.Tb_Subtipo.TabIndex = 6
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_Aceptar.Location = New System.Drawing.Point(171, 86)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Aceptar.TabIndex = 8
        Me.Btn_Aceptar.Text = "Aceptar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.CausesValidation = False
        Me.Btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.Btn_Cancelar.Location = New System.Drawing.Point(260, 86)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cancelar.TabIndex = 9
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Tb_Nomsubtipo
        '
        Me.Tb_Nomsubtipo.Enabled = False
        Me.Tb_Nomsubtipo.Location = New System.Drawing.Point(424, 54)
        Me.Tb_Nomsubtipo.MaxLength = 3
        Me.Tb_Nomsubtipo.Name = "Tb_Nomsubtipo"
        Me.Tb_Nomsubtipo.Size = New System.Drawing.Size(77, 20)
        Me.Tb_Nomsubtipo.TabIndex = 7
        Me.Tb_Nomsubtipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tb_NomTipo
        '
        Me.Tb_NomTipo.Enabled = False
        Me.Tb_NomTipo.Location = New System.Drawing.Point(424, 29)
        Me.Tb_NomTipo.MaxLength = 3
        Me.Tb_NomTipo.Name = "Tb_NomTipo"
        Me.Tb_NomTipo.Size = New System.Drawing.Size(77, 20)
        Me.Tb_NomTipo.TabIndex = 4
        Me.Tb_NomTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(426, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Nomenclatura"
        '
        'Fr_EditarTipoSubtipo
        '
        Me.AcceptButton = Me.Btn_Aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Btn_Cancelar
        Me.ClientSize = New System.Drawing.Size(507, 121)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Tb_Nomsubtipo)
        Me.Controls.Add(Me.Tb_NomTipo)
        Me.Controls.Add(Me.Btn_Cancelar)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.Tb_Subtipo)
        Me.Controls.Add(Me.Tb_Tipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_EditarTipoSubtipo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fr_EditarTipoSubtipo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tb_Tipo As System.Windows.Forms.TextBox
    Friend WithEvents Tb_Subtipo As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Tb_Nomsubtipo As System.Windows.Forms.TextBox
    Friend WithEvents Tb_NomTipo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
