<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Material
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
        Me.Pn_Datos = New System.Windows.Forms.Panel()
        Me.CuTx_ValorComercial = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.CuTx_ValorIsmocol = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.Bt_BuscarArticulo = New System.Windows.Forms.Button()
        Me.Ck_Activo = New System.Windows.Forms.CheckBox()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Tx_IdArticulo = New System.Windows.Forms.TextBox()
        Me.Tx_Codigo = New System.Windows.Forms.TextBox()
        Me.Cb_TipoUnidad = New System.Windows.Forms.ComboBox()
        Me.Lb_ValorComercial = New System.Windows.Forms.Label()
        Me.Lb_ValorIsmocol = New System.Windows.Forms.Label()
        Me.Lb_Unidad = New System.Windows.Forms.Label()
        Me.Lb_Descripcion = New System.Windows.Forms.Label()
        Me.Lb_IdArticulo = New System.Windows.Forms.Label()
        Me.Lb_Codigo = New System.Windows.Forms.Label()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Pn_Datos.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Datos
        '
        Me.Pn_Datos.Controls.Add(Me.CuTx_ValorComercial)
        Me.Pn_Datos.Controls.Add(Me.CuTx_ValorIsmocol)
        Me.Pn_Datos.Controls.Add(Me.Bt_BuscarArticulo)
        Me.Pn_Datos.Controls.Add(Me.Ck_Activo)
        Me.Pn_Datos.Controls.Add(Me.Tx_Descripcion)
        Me.Pn_Datos.Controls.Add(Me.Tx_IdArticulo)
        Me.Pn_Datos.Controls.Add(Me.Tx_Codigo)
        Me.Pn_Datos.Controls.Add(Me.Cb_TipoUnidad)
        Me.Pn_Datos.Controls.Add(Me.Lb_ValorComercial)
        Me.Pn_Datos.Controls.Add(Me.Lb_ValorIsmocol)
        Me.Pn_Datos.Controls.Add(Me.Lb_Unidad)
        Me.Pn_Datos.Controls.Add(Me.Lb_Descripcion)
        Me.Pn_Datos.Controls.Add(Me.Lb_IdArticulo)
        Me.Pn_Datos.Controls.Add(Me.Lb_Codigo)
        Me.Pn_Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Datos.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Datos.Name = "Pn_Datos"
        Me.Pn_Datos.Size = New System.Drawing.Size(624, 171)
        Me.Pn_Datos.TabIndex = 0
        '
        'CuTx_ValorComercial
        '
        Me.CuTx_ValorComercial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CuTx_ValorComercial.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(67)
        Me.CuTx_ValorComercial.Location = New System.Drawing.Point(395, 119)
        Me.CuTx_ValorComercial.MaxLongitudTexto = 18
        Me.CuTx_ValorComercial.Name = "CuTx_ValorComercial"
        Me.CuTx_ValorComercial.PosicionesDecimales = CType(0US, UShort)
        Me.CuTx_ValorComercial.Size = New System.Drawing.Size(100, 20)
        Me.CuTx_ValorComercial.SoloLectura = False
        Me.CuTx_ValorComercial.TabIndex = 12
        Me.CuTx_ValorComercial.Tag = "633"
        Me.CuTx_ValorComercial.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'CuTx_ValorIsmocol
        '
        Me.CuTx_ValorIsmocol.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(67)
        Me.CuTx_ValorIsmocol.Location = New System.Drawing.Point(91, 119)
        Me.CuTx_ValorIsmocol.MaxLongitudTexto = 18
        Me.CuTx_ValorIsmocol.Name = "CuTx_ValorIsmocol"
        Me.CuTx_ValorIsmocol.PosicionesDecimales = CType(0US, UShort)
        Me.CuTx_ValorIsmocol.Size = New System.Drawing.Size(100, 20)
        Me.CuTx_ValorIsmocol.SoloLectura = False
        Me.CuTx_ValorIsmocol.TabIndex = 10
        Me.CuTx_ValorIsmocol.Tag = "633"
        Me.CuTx_ValorIsmocol.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Bt_BuscarArticulo
        '
        Me.Bt_BuscarArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_BuscarArticulo.AutoSize = True
        Me.Bt_BuscarArticulo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_BuscarArticulo.Location = New System.Drawing.Point(501, 18)
        Me.Bt_BuscarArticulo.Name = "Bt_BuscarArticulo"
        Me.Bt_BuscarArticulo.Size = New System.Drawing.Size(26, 23)
        Me.Bt_BuscarArticulo.TabIndex = 4
        Me.Bt_BuscarArticulo.Text = "..."
        Me.Bt_BuscarArticulo.UseVisualStyleBackColor = True
        '
        'Ck_Activo
        '
        Me.Ck_Activo.AutoSize = True
        Me.Ck_Activo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_Activo.Checked = True
        Me.Ck_Activo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_Activo.Location = New System.Drawing.Point(46, 145)
        Me.Ck_Activo.Name = "Ck_Activo"
        Me.Ck_Activo.Size = New System.Drawing.Size(59, 17)
        Me.Ck_Activo.TabIndex = 13
        Me.Ck_Activo.Text = "Activo:"
        Me.Ck_Activo.ThreeState = True
        Me.Ck_Activo.UseVisualStyleBackColor = True
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Descripcion.Location = New System.Drawing.Point(91, 46)
        Me.Tx_Descripcion.MaxLength = 200
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(521, 40)
        Me.Tx_Descripcion.TabIndex = 6
        '
        'Tx_IdArticulo
        '
        Me.Tx_IdArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_IdArticulo.Location = New System.Drawing.Point(395, 20)
        Me.Tx_IdArticulo.MaxLength = 10
        Me.Tx_IdArticulo.Name = "Tx_IdArticulo"
        Me.Tx_IdArticulo.Size = New System.Drawing.Size(100, 20)
        Me.Tx_IdArticulo.TabIndex = 3
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
        'Cb_TipoUnidad
        '
        Me.Cb_TipoUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoUnidad.FormattingEnabled = True
        Me.Cb_TipoUnidad.Location = New System.Drawing.Point(91, 92)
        Me.Cb_TipoUnidad.Name = "Cb_TipoUnidad"
        Me.Cb_TipoUnidad.Size = New System.Drawing.Size(121, 21)
        Me.Cb_TipoUnidad.TabIndex = 8
        '
        'Lb_ValorComercial
        '
        Me.Lb_ValorComercial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_ValorComercial.AutoSize = True
        Me.Lb_ValorComercial.Location = New System.Drawing.Point(309, 122)
        Me.Lb_ValorComercial.Name = "Lb_ValorComercial"
        Me.Lb_ValorComercial.Size = New System.Drawing.Size(83, 13)
        Me.Lb_ValorComercial.TabIndex = 11
        Me.Lb_ValorComercial.Text = "Valor Comercial:"
        '
        'Lb_ValorIsmocol
        '
        Me.Lb_ValorIsmocol.AutoSize = True
        Me.Lb_ValorIsmocol.Location = New System.Drawing.Point(15, 122)
        Me.Lb_ValorIsmocol.Name = "Lb_ValorIsmocol"
        Me.Lb_ValorIsmocol.Size = New System.Drawing.Size(73, 13)
        Me.Lb_ValorIsmocol.TabIndex = 9
        Me.Lb_ValorIsmocol.Text = "Valor Ismocol:"
        '
        'Lb_Unidad
        '
        Me.Lb_Unidad.AutoSize = True
        Me.Lb_Unidad.Location = New System.Drawing.Point(44, 95)
        Me.Lb_Unidad.Name = "Lb_Unidad"
        Me.Lb_Unidad.Size = New System.Drawing.Size(44, 13)
        Me.Lb_Unidad.TabIndex = 7
        Me.Lb_Unidad.Text = "Unidad:"
        '
        'Lb_Descripcion
        '
        Me.Lb_Descripcion.AutoSize = True
        Me.Lb_Descripcion.Location = New System.Drawing.Point(22, 49)
        Me.Lb_Descripcion.Name = "Lb_Descripcion"
        Me.Lb_Descripcion.Size = New System.Drawing.Size(66, 13)
        Me.Lb_Descripcion.TabIndex = 5
        Me.Lb_Descripcion.Text = "Descripción:"
        '
        'Lb_IdArticulo
        '
        Me.Lb_IdArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_IdArticulo.AutoSize = True
        Me.Lb_IdArticulo.Location = New System.Drawing.Point(333, 23)
        Me.Lb_IdArticulo.Name = "Lb_IdArticulo"
        Me.Lb_IdArticulo.Size = New System.Drawing.Size(59, 13)
        Me.Lb_IdArticulo.TabIndex = 2
        Me.Lb_IdArticulo.Text = "Id Artículo:"
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
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 171)
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
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(465, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Fr_Material
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 201)
        Me.Controls.Add(Me.Pn_Datos)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Name = "Fr_Material"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionando Materiales"
        Me.Pn_Datos.ResumeLayout(False)
        Me.Pn_Datos.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Datos As System.Windows.Forms.Panel
    Friend WithEvents Lb_ValorComercial As System.Windows.Forms.Label
    Friend WithEvents Lb_ValorIsmocol As System.Windows.Forms.Label
    Friend WithEvents Lb_Unidad As System.Windows.Forms.Label
    Friend WithEvents Lb_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Lb_IdArticulo As System.Windows.Forms.Label
    Friend WithEvents Lb_Codigo As System.Windows.Forms.Label
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Cb_TipoUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Tx_IdArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Ck_Activo As System.Windows.Forms.CheckBox
    Friend WithEvents Bt_BuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents CuTx_ValorIsmocol As FormulariosClasesBase.Cu_TextBoxDecimal
    Friend WithEvents CuTx_ValorComercial As FormulariosClasesBase.Cu_TextBoxDecimal
End Class
