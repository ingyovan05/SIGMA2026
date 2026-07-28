<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AgregarModeloMarca
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
        Me.Lb_Info = New System.Windows.Forms.Label()
        Me.Tb_ModeloMarca = New System.Windows.Forms.TextBox()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Lb_Info
        '
        Me.Lb_Info.AutoSize = True
        Me.Lb_Info.Location = New System.Drawing.Point(12, 9)
        Me.Lb_Info.Name = "Lb_Info"
        Me.Lb_Info.Size = New System.Drawing.Size(418, 13)
        Me.Lb_Info.TabIndex = 0
        Me.Lb_Info.Text = "Escriba el Nombre del Modelo / Marca que desea agregar, Asegurese de que no exist" & _
            "a"
        '
        'Tb_ModeloMarca
        '
        Me.Tb_ModeloMarca.Location = New System.Drawing.Point(15, 25)
        Me.Tb_ModeloMarca.Name = "Tb_ModeloMarca"
        Me.Tb_ModeloMarca.Size = New System.Drawing.Size(520, 20)
        Me.Tb_ModeloMarca.TabIndex = 1
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.ForeColor = System.Drawing.Color.ForestGreen
        Me.Bt_Aceptar.Location = New System.Drawing.Point(188, 51)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 2
        Me.Bt_Aceptar.Text = "Agregar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.Bt_Cancelar.Location = New System.Drawing.Point(282, 51)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 3
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Fr_AgregarModeloMarca
        '
        Me.AcceptButton = Me.Bt_Aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Bt_Cancelar
        Me.ClientSize = New System.Drawing.Size(544, 86)
        Me.Controls.Add(Me.Bt_Cancelar)
        Me.Controls.Add(Me.Bt_Aceptar)
        Me.Controls.Add(Me.Tb_ModeloMarca)
        Me.Controls.Add(Me.Lb_Info)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_AgregarModeloMarca"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Marca / Modelo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lb_Info As System.Windows.Forms.Label
    Friend WithEvents Tb_ModeloMarca As System.Windows.Forms.TextBox
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
End Class
