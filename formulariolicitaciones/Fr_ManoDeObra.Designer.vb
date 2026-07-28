<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ManoDeObra
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
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Ck_Activo = New System.Windows.Forms.CheckBox()
        Me.Tx_Codigo = New System.Windows.Forms.TextBox()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Lb_Descripcion = New System.Windows.Forms.Label()
        Me.Lb_Codigo = New System.Windows.Forms.Label()
        Me.Pn_Datos = New System.Windows.Forms.Panel()
        Me.CuTx_TarifaIsmocol = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Lb_TarifaIsmocol = New System.Windows.Forms.Label()
        Me.Lb_HHTarifaIsm = New System.Windows.Forms.Label()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Datos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(465, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Ck_Activo
        '
        Me.Ck_Activo.AutoSize = True
        Me.Ck_Activo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_Activo.Checked = True
        Me.Ck_Activo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_Activo.Location = New System.Drawing.Point(46, 99)
        Me.Ck_Activo.Name = "Ck_Activo"
        Me.Ck_Activo.Size = New System.Drawing.Size(59, 17)
        Me.Ck_Activo.TabIndex = 7
        Me.Ck_Activo.Text = "Activo:"
        Me.Ck_Activo.ThreeState = True
        Me.Ck_Activo.UseVisualStyleBackColor = True
        '
        'Tx_Codigo
        '
        Me.Tx_Codigo.Enabled = False
        Me.Tx_Codigo.Location = New System.Drawing.Point(91, 20)
        Me.Tx_Codigo.Name = "Tx_Codigo"
        Me.Tx_Codigo.ReadOnly = True
        Me.Tx_Codigo.Size = New System.Drawing.Size(100, 20)
        Me.Tx_Codigo.TabIndex = 1
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 128)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(624, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(546, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Lb_Descripcion
        '
        Me.Lb_Descripcion.AutoSize = True
        Me.Lb_Descripcion.Location = New System.Drawing.Point(22, 49)
        Me.Lb_Descripcion.Name = "Lb_Descripcion"
        Me.Lb_Descripcion.Size = New System.Drawing.Size(66, 13)
        Me.Lb_Descripcion.TabIndex = 2
        Me.Lb_Descripcion.Text = "Descripción:"
        '
        'Lb_Codigo
        '
        Me.Lb_Codigo.AutoSize = True
        Me.Lb_Codigo.Location = New System.Drawing.Point(45, 23)
        Me.Lb_Codigo.Name = "Lb_Codigo"
        Me.Lb_Codigo.Size = New System.Drawing.Size(43, 13)
        Me.Lb_Codigo.TabIndex = 0
        Me.Lb_Codigo.Text = "Código:"
        '
        'Pn_Datos
        '
        Me.Pn_Datos.Controls.Add(Me.CuTx_TarifaIsmocol)
        Me.Pn_Datos.Controls.Add(Me.Lb_Codigo)
        Me.Pn_Datos.Controls.Add(Me.Tx_Codigo)
        Me.Pn_Datos.Controls.Add(Me.Lb_Descripcion)
        Me.Pn_Datos.Controls.Add(Me.Tx_Descripcion)
        Me.Pn_Datos.Controls.Add(Me.Lb_TarifaIsmocol)
        Me.Pn_Datos.Controls.Add(Me.Lb_HHTarifaIsm)
        Me.Pn_Datos.Controls.Add(Me.Ck_Activo)
        Me.Pn_Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Datos.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Datos.Name = "Pn_Datos"
        Me.Pn_Datos.Size = New System.Drawing.Size(624, 128)
        Me.Pn_Datos.TabIndex = 0
        '
        'CuTx_TarifaIsmocol
        '
        Me.CuTx_TarifaIsmocol.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(67)
        Me.CuTx_TarifaIsmocol.Location = New System.Drawing.Point(91, 73)
        Me.CuTx_TarifaIsmocol.MaxLongitudTexto = 18
        Me.CuTx_TarifaIsmocol.Name = "CuTx_TarifaIsmocol"
        Me.CuTx_TarifaIsmocol.PosicionesDecimales = CType(0US, UShort)
        Me.CuTx_TarifaIsmocol.Size = New System.Drawing.Size(100, 20)
        Me.CuTx_TarifaIsmocol.SoloLectura = False
        Me.CuTx_TarifaIsmocol.TabIndex = 5
        Me.CuTx_TarifaIsmocol.Tag = "633"
        Me.CuTx_TarifaIsmocol.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Descripcion.Location = New System.Drawing.Point(91, 46)
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(490, 20)
        Me.Tx_Descripcion.TabIndex = 3
        '
        'Lb_TarifaIsmocol
        '
        Me.Lb_TarifaIsmocol.AutoSize = True
        Me.Lb_TarifaIsmocol.Location = New System.Drawing.Point(12, 76)
        Me.Lb_TarifaIsmocol.Name = "Lb_TarifaIsmocol"
        Me.Lb_TarifaIsmocol.Size = New System.Drawing.Size(76, 13)
        Me.Lb_TarifaIsmocol.TabIndex = 4
        Me.Lb_TarifaIsmocol.Text = "Tarifa Ismocol:"
        '
        'Lb_HHTarifaIsm
        '
        Me.Lb_HHTarifaIsm.AutoSize = True
        Me.Lb_HHTarifaIsm.Location = New System.Drawing.Point(197, 76)
        Me.Lb_HHTarifaIsm.Name = "Lb_HHTarifaIsm"
        Me.Lb_HHTarifaIsm.Size = New System.Drawing.Size(78, 13)
        Me.Lb_HHTarifaIsm.TabIndex = 6
        Me.Lb_HHTarifaIsm.Text = "/ Hora Hombre"
        '
        'Fr_ManoDeObra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 158)
        Me.Controls.Add(Me.Pn_Datos)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Name = "Fr_ManoDeObra"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestionando Mano de Obra"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Datos.ResumeLayout(False)
        Me.Pn_Datos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Ck_Activo As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Lb_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Lb_Codigo As System.Windows.Forms.Label
    Friend WithEvents Pn_Datos As System.Windows.Forms.Panel
    Friend WithEvents Lb_HHTarifaIsm As System.Windows.Forms.Label
    Friend WithEvents Lb_TarifaIsmocol As System.Windows.Forms.Label
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents CuTx_TarifaIsmocol As FormulariosClasesBase.Cu_TextBoxDecimal
End Class
