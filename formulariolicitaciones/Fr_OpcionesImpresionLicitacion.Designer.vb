<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_OpcionesImpresionLicitacion
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
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Imprimir = New System.Windows.Forms.Button()
        Me.Bt_Exportar = New System.Windows.Forms.Button()
        Me.Pn_Controles = New System.Windows.Forms.Panel()
        Me.Cb_Resumen = New System.Windows.Forms.ComboBox()
        Me.Lb_Resumen = New System.Windows.Forms.Label()
        Me.Rb_ValoresConAIU = New System.Windows.Forms.RadioButton()
        Me.Rb_ValoresSinAIU = New System.Windows.Forms.RadioButton()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Controles.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Imprimir)
        Me.Flp_Botones.Controls.Add(Me.Bt_Exportar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 131)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(384, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(306, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Imprimir
        '
        Me.Bt_Imprimir.Location = New System.Drawing.Point(225, 3)
        Me.Bt_Imprimir.Name = "Bt_Imprimir"
        Me.Bt_Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Imprimir.TabIndex = 1
        Me.Bt_Imprimir.Text = "Imprimir"
        Me.Bt_Imprimir.UseVisualStyleBackColor = True
        '
        'Bt_Exportar
        '
        Me.Bt_Exportar.AutoSize = True
        Me.Bt_Exportar.Location = New System.Drawing.Point(131, 3)
        Me.Bt_Exportar.Name = "Bt_Exportar"
        Me.Bt_Exportar.Size = New System.Drawing.Size(88, 23)
        Me.Bt_Exportar.TabIndex = 2
        Me.Bt_Exportar.Text = "Exportar a XLS"
        Me.Bt_Exportar.UseVisualStyleBackColor = True
        '
        'Pn_Controles
        '
        Me.Pn_Controles.Controls.Add(Me.Cb_Resumen)
        Me.Pn_Controles.Controls.Add(Me.Lb_Resumen)
        Me.Pn_Controles.Controls.Add(Me.Rb_ValoresConAIU)
        Me.Pn_Controles.Controls.Add(Me.Rb_ValoresSinAIU)
        Me.Pn_Controles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Controles.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Controles.Name = "Pn_Controles"
        Me.Pn_Controles.Size = New System.Drawing.Size(384, 131)
        Me.Pn_Controles.TabIndex = 0
        '
        'Cb_Resumen
        '
        Me.Cb_Resumen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Resumen.FormattingEnabled = True
        Me.Cb_Resumen.Location = New System.Drawing.Point(68, 17)
        Me.Cb_Resumen.Name = "Cb_Resumen"
        Me.Cb_Resumen.Size = New System.Drawing.Size(304, 21)
        Me.Cb_Resumen.TabIndex = 3
        '
        'Lb_Resumen
        '
        Me.Lb_Resumen.AutoSize = True
        Me.Lb_Resumen.Location = New System.Drawing.Point(10, 20)
        Me.Lb_Resumen.Name = "Lb_Resumen"
        Me.Lb_Resumen.Size = New System.Drawing.Size(55, 13)
        Me.Lb_Resumen.TabIndex = 2
        Me.Lb_Resumen.Text = "Resumen:"
        '
        'Rb_ValoresConAIU
        '
        Me.Rb_ValoresConAIU.AutoSize = True
        Me.Rb_ValoresConAIU.Enabled = False
        Me.Rb_ValoresConAIU.Location = New System.Drawing.Point(68, 67)
        Me.Rb_ValoresConAIU.Name = "Rb_ValoresConAIU"
        Me.Rb_ValoresConAIU.Size = New System.Drawing.Size(111, 17)
        Me.Rb_ValoresConAIU.TabIndex = 1
        Me.Rb_ValoresConAIU.Text = "Valores con A.I.U."
        Me.Rb_ValoresConAIU.UseVisualStyleBackColor = True
        '
        'Rb_ValoresSinAIU
        '
        Me.Rb_ValoresSinAIU.AutoSize = True
        Me.Rb_ValoresSinAIU.Checked = True
        Me.Rb_ValoresSinAIU.Enabled = False
        Me.Rb_ValoresSinAIU.Location = New System.Drawing.Point(68, 44)
        Me.Rb_ValoresSinAIU.Name = "Rb_ValoresSinAIU"
        Me.Rb_ValoresSinAIU.Size = New System.Drawing.Size(106, 17)
        Me.Rb_ValoresSinAIU.TabIndex = 0
        Me.Rb_ValoresSinAIU.TabStop = True
        Me.Rb_ValoresSinAIU.Text = "Valores sin A.I.U."
        Me.Rb_ValoresSinAIU.UseVisualStyleBackColor = True
        '
        'Fr_OpcionesImpresionLicitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 161)
        Me.Controls.Add(Me.Pn_Controles)
        Me.Controls.Add(Me.Flp_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_OpcionesImpresionLicitacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Opciones de Impresión de Licitaciones"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Flp_Botones.PerformLayout()
        Me.Pn_Controles.ResumeLayout(False)
        Me.Pn_Controles.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Pn_Controles As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Bt_Exportar As System.Windows.Forms.Button
    Friend WithEvents Cb_Resumen As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Resumen As System.Windows.Forms.Label
    Friend WithEvents Rb_ValoresConAIU As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_ValoresSinAIU As System.Windows.Forms.RadioButton
End Class
