<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_FacturaElectronica
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
        Me.Tlp_PieDePagina = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_Estado = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_Estado = New System.Windows.Forms.Label()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Pn_Datos = New System.Windows.Forms.Panel()
        Me.Lb_Dependencia = New System.Windows.Forms.Label()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Lb_Subgerencia = New System.Windows.Forms.Label()
        Me.Cb_Subgerencia = New System.Windows.Forms.ComboBox()
        Me.Lb_TipoAprobacion = New System.Windows.Forms.Label()
        Me.Cb_TipoAprobacion = New System.Windows.Forms.ComboBox()
        Me.Bt_AgregarTipoAprobacion = New System.Windows.Forms.Button()
        Me.Lb_Consecutivo = New System.Windows.Forms.Label()
        Me.Cb_Consecutivo = New System.Windows.Forms.ComboBox()
        Me.Lb_NIT = New System.Windows.Forms.Label()
        Me.Tx_IdentificacionNIT = New System.Windows.Forms.TextBox()
        Me.Tx_Proveedor = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarProveedor = New System.Windows.Forms.Button()
        Me.Lb_Descripcion = New System.Windows.Forms.Label()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Lb_PersonaAprueba = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersonaAprueba = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_Valor = New System.Windows.Forms.Label()
        Me.CuTx_Valor = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.Lb_TipoMoneda = New System.Windows.Forms.Label()
        Me.Cb_TipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Tlp_PieDePagina.SuspendLayout()
        Me.Flp_Estado.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Datos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tlp_PieDePagina
        '
        Me.Tlp_PieDePagina.BackColor = System.Drawing.Color.Silver
        Me.Tlp_PieDePagina.ColumnCount = 2
        Me.Tlp_PieDePagina.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_PieDePagina.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_PieDePagina.Controls.Add(Me.Flp_Estado, 0, 0)
        Me.Tlp_PieDePagina.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_PieDePagina.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_PieDePagina.Location = New System.Drawing.Point(0, 231)
        Me.Tlp_PieDePagina.Name = "Tlp_PieDePagina"
        Me.Tlp_PieDePagina.RowCount = 1
        Me.Tlp_PieDePagina.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_PieDePagina.Size = New System.Drawing.Size(484, 30)
        Me.Tlp_PieDePagina.TabIndex = 1
        '
        'Flp_Estado
        '
        Me.Flp_Estado.AutoSize = True
        Me.Flp_Estado.Controls.Add(Me.Lb_Estado)
        Me.Flp_Estado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Estado.Location = New System.Drawing.Point(0, 0)
        Me.Flp_Estado.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Estado.Name = "Flp_Estado"
        Me.Flp_Estado.Padding = New System.Windows.Forms.Padding(8, 8, 8, 0)
        Me.Flp_Estado.Size = New System.Drawing.Size(60, 30)
        Me.Flp_Estado.TabIndex = 0
        '
        'Lb_Estado
        '
        Me.Lb_Estado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_Estado.AutoSize = True
        Me.Lb_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Estado.ForeColor = System.Drawing.Color.Red
        Me.Lb_Estado.Location = New System.Drawing.Point(11, 8)
        Me.Lb_Estado.Name = "Lb_Estado"
        Me.Lb_Estado.Size = New System.Drawing.Size(38, 13)
        Me.Lb_Estado.TabIndex = 0
        Me.Lb_Estado.Text = "Label"
        Me.Lb_Estado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lb_Estado.Visible = False
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(60, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(424, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(346, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(265, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Pn_Datos
        '
        Me.Pn_Datos.Controls.Add(Me.Lb_Dependencia)
        Me.Pn_Datos.Controls.Add(Me.Cb_Dependencia)
        Me.Pn_Datos.Controls.Add(Me.Lb_Subgerencia)
        Me.Pn_Datos.Controls.Add(Me.Cb_Subgerencia)
        Me.Pn_Datos.Controls.Add(Me.Lb_TipoAprobacion)
        Me.Pn_Datos.Controls.Add(Me.Cb_TipoAprobacion)
        Me.Pn_Datos.Controls.Add(Me.Bt_AgregarTipoAprobacion)
        Me.Pn_Datos.Controls.Add(Me.Lb_Consecutivo)
        Me.Pn_Datos.Controls.Add(Me.Cb_Consecutivo)
        Me.Pn_Datos.Controls.Add(Me.Lb_NIT)
        Me.Pn_Datos.Controls.Add(Me.Tx_IdentificacionNIT)
        Me.Pn_Datos.Controls.Add(Me.Tx_Proveedor)
        Me.Pn_Datos.Controls.Add(Me.Bt_BuscarProveedor)
        Me.Pn_Datos.Controls.Add(Me.Lb_Descripcion)
        Me.Pn_Datos.Controls.Add(Me.Tx_Descripcion)
        Me.Pn_Datos.Controls.Add(Me.Lb_PersonaAprueba)
        Me.Pn_Datos.Controls.Add(Me.Cu_BuscarPersonaAprueba)
        Me.Pn_Datos.Controls.Add(Me.Lb_Valor)
        Me.Pn_Datos.Controls.Add(Me.CuTx_Valor)
        Me.Pn_Datos.Controls.Add(Me.Lb_TipoMoneda)
        Me.Pn_Datos.Controls.Add(Me.Cb_TipoMoneda)
        Me.Pn_Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Datos.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Datos.Name = "Pn_Datos"
        Me.Pn_Datos.Size = New System.Drawing.Size(484, 231)
        Me.Pn_Datos.TabIndex = 0
        '
        'Lb_Dependencia
        '
        Me.Lb_Dependencia.AutoSize = True
        Me.Lb_Dependencia.Location = New System.Drawing.Point(10, 19)
        Me.Lb_Dependencia.Name = "Lb_Dependencia"
        Me.Lb_Dependencia.Size = New System.Drawing.Size(74, 13)
        Me.Lb_Dependencia.TabIndex = 0
        Me.Lb_Dependencia.Text = "Dependencia:"
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Dependencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.Location = New System.Drawing.Point(87, 16)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(385, 21)
        Me.Cb_Dependencia.TabIndex = 1
        '
        'Lb_Subgerencia
        '
        Me.Lb_Subgerencia.AutoSize = True
        Me.Lb_Subgerencia.Location = New System.Drawing.Point(14, 46)
        Me.Lb_Subgerencia.Name = "Lb_Subgerencia"
        Me.Lb_Subgerencia.Size = New System.Drawing.Size(70, 13)
        Me.Lb_Subgerencia.TabIndex = 2
        Me.Lb_Subgerencia.Text = "Subgerencia:"
        '
        'Cb_Subgerencia
        '
        Me.Cb_Subgerencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Subgerencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Subgerencia.FormattingEnabled = True
        Me.Cb_Subgerencia.Location = New System.Drawing.Point(87, 43)
        Me.Cb_Subgerencia.Name = "Cb_Subgerencia"
        Me.Cb_Subgerencia.Size = New System.Drawing.Size(385, 21)
        Me.Cb_Subgerencia.TabIndex = 3
        '
        'Lb_TipoAprobacion
        '
        Me.Lb_TipoAprobacion.AutoSize = True
        Me.Lb_TipoAprobacion.Location = New System.Drawing.Point(53, 73)
        Me.Lb_TipoAprobacion.Name = "Lb_TipoAprobacion"
        Me.Lb_TipoAprobacion.Size = New System.Drawing.Size(31, 13)
        Me.Lb_TipoAprobacion.TabIndex = 4
        Me.Lb_TipoAprobacion.Text = "Tipo:"
        '
        'Cb_TipoAprobacion
        '
        Me.Cb_TipoAprobacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoAprobacion.FormattingEnabled = True
        Me.Cb_TipoAprobacion.Location = New System.Drawing.Point(87, 70)
        Me.Cb_TipoAprobacion.Name = "Cb_TipoAprobacion"
        Me.Cb_TipoAprobacion.Size = New System.Drawing.Size(130, 21)
        Me.Cb_TipoAprobacion.TabIndex = 5
        '
        'Bt_AgregarTipoAprobacion
        '
        Me.Bt_AgregarTipoAprobacion.AutoSize = True
        Me.Bt_AgregarTipoAprobacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_AgregarTipoAprobacion.Location = New System.Drawing.Point(223, 69)
        Me.Bt_AgregarTipoAprobacion.Name = "Bt_AgregarTipoAprobacion"
        Me.Bt_AgregarTipoAprobacion.Size = New System.Drawing.Size(50, 23)
        Me.Bt_AgregarTipoAprobacion.TabIndex = 6
        Me.Bt_AgregarTipoAprobacion.Text = "Buscar"
        Me.Bt_AgregarTipoAprobacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Bt_AgregarTipoAprobacion.UseVisualStyleBackColor = True
        '
        'Lb_Consecutivo
        '
        Me.Lb_Consecutivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_Consecutivo.AutoSize = True
        Me.Lb_Consecutivo.Enabled = False
        Me.Lb_Consecutivo.Location = New System.Drawing.Point(279, 73)
        Me.Lb_Consecutivo.Name = "Lb_Consecutivo"
        Me.Lb_Consecutivo.Size = New System.Drawing.Size(69, 13)
        Me.Lb_Consecutivo.TabIndex = 7
        Me.Lb_Consecutivo.Text = "Consecutivo:"
        Me.Lb_Consecutivo.Visible = False
        '
        'Cb_Consecutivo
        '
        Me.Cb_Consecutivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Consecutivo.Enabled = False
        Me.Cb_Consecutivo.FormattingEnabled = True
        Me.Cb_Consecutivo.Location = New System.Drawing.Point(351, 70)
        Me.Cb_Consecutivo.Name = "Cb_Consecutivo"
        Me.Cb_Consecutivo.Size = New System.Drawing.Size(121, 21)
        Me.Cb_Consecutivo.TabIndex = 8
        Me.Cb_Consecutivo.Visible = False
        '
        'Lb_NIT
        '
        Me.Lb_NIT.AutoSize = True
        Me.Lb_NIT.Location = New System.Drawing.Point(25, 100)
        Me.Lb_NIT.Name = "Lb_NIT"
        Me.Lb_NIT.Size = New System.Drawing.Size(59, 13)
        Me.Lb_NIT.TabIndex = 9
        Me.Lb_NIT.Text = "Proveedor:"
        '
        'Tx_IdentificacionNIT
        '
        Me.Tx_IdentificacionNIT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_IdentificacionNIT.Location = New System.Drawing.Point(87, 97)
        Me.Tx_IdentificacionNIT.Name = "Tx_IdentificacionNIT"
        Me.Tx_IdentificacionNIT.ReadOnly = True
        Me.Tx_IdentificacionNIT.Size = New System.Drawing.Size(76, 20)
        Me.Tx_IdentificacionNIT.TabIndex = 10
        '
        'Tx_Proveedor
        '
        Me.Tx_Proveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Proveedor.Location = New System.Drawing.Point(169, 97)
        Me.Tx_Proveedor.Name = "Tx_Proveedor"
        Me.Tx_Proveedor.ReadOnly = True
        Me.Tx_Proveedor.Size = New System.Drawing.Size(273, 20)
        Me.Tx_Proveedor.TabIndex = 11
        '
        'Bt_BuscarProveedor
        '
        Me.Bt_BuscarProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_BuscarProveedor.Location = New System.Drawing.Point(445, 96)
        Me.Bt_BuscarProveedor.Name = "Bt_BuscarProveedor"
        Me.Bt_BuscarProveedor.Size = New System.Drawing.Size(28, 23)
        Me.Bt_BuscarProveedor.TabIndex = 12
        Me.Bt_BuscarProveedor.Text = "..."
        Me.Bt_BuscarProveedor.UseVisualStyleBackColor = True
        '
        'Lb_Descripcion
        '
        Me.Lb_Descripcion.AutoSize = True
        Me.Lb_Descripcion.Location = New System.Drawing.Point(18, 126)
        Me.Lb_Descripcion.Name = "Lb_Descripcion"
        Me.Lb_Descripcion.Size = New System.Drawing.Size(66, 13)
        Me.Lb_Descripcion.TabIndex = 13
        Me.Lb_Descripcion.Text = "Descripción:"
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Descripcion.Location = New System.Drawing.Point(87, 123)
        Me.Tx_Descripcion.MaxLength = 200
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(385, 40)
        Me.Tx_Descripcion.TabIndex = 14
        '
        'Lb_PersonaAprueba
        '
        Me.Lb_PersonaAprueba.AutoSize = True
        Me.Lb_PersonaAprueba.Location = New System.Drawing.Point(10, 173)
        Me.Lb_PersonaAprueba.Name = "Lb_PersonaAprueba"
        Me.Lb_PersonaAprueba.Size = New System.Drawing.Size(74, 13)
        Me.Lb_PersonaAprueba.TabIndex = 15
        Me.Lb_PersonaAprueba.Text = "Aprobado por:"
        '
        'Cu_BuscarPersonaAprueba
        '
        Me.Cu_BuscarPersonaAprueba.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cu_BuscarPersonaAprueba.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaAprueba.Location = New System.Drawing.Point(84, 169)
        Me.Cu_BuscarPersonaAprueba.Name = "Cu_BuscarPersonaAprueba"
        Me.Cu_BuscarPersonaAprueba.Size = New System.Drawing.Size(389, 23)
        Me.Cu_BuscarPersonaAprueba.TabIndex = 16
        Me.Cu_BuscarPersonaAprueba.Tipo = "PADEP"
        Me.Cu_BuscarPersonaAprueba.valorcajatexto = "IDENTIFICACION"
        '
        'Lb_Valor
        '
        Me.Lb_Valor.AutoSize = True
        Me.Lb_Valor.Location = New System.Drawing.Point(50, 201)
        Me.Lb_Valor.Name = "Lb_Valor"
        Me.Lb_Valor.Size = New System.Drawing.Size(34, 13)
        Me.Lb_Valor.TabIndex = 17
        Me.Lb_Valor.Text = "Valor:"
        '
        'CuTx_Valor
        '
        Me.CuTx_Valor.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(67)
        Me.CuTx_Valor.Location = New System.Drawing.Point(87, 198)
        Me.CuTx_Valor.MaxLongitudTexto = 18
        Me.CuTx_Valor.Name = "CuTx_Valor"
        Me.CuTx_Valor.PosicionesDecimales = CType(0US, UShort)
        Me.CuTx_Valor.Size = New System.Drawing.Size(130, 20)
        Me.CuTx_Valor.SoloLectura = False
        Me.CuTx_Valor.TabIndex = 18
        Me.CuTx_Valor.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Lb_TipoMoneda
        '
        Me.Lb_TipoMoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_TipoMoneda.AutoSize = True
        Me.Lb_TipoMoneda.Location = New System.Drawing.Point(275, 201)
        Me.Lb_TipoMoneda.Name = "Lb_TipoMoneda"
        Me.Lb_TipoMoneda.Size = New System.Drawing.Size(73, 13)
        Me.Lb_TipoMoneda.TabIndex = 19
        Me.Lb_TipoMoneda.Text = "Tipo Moneda:"
        '
        'Cb_TipoMoneda
        '
        Me.Cb_TipoMoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_TipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoMoneda.FormattingEnabled = True
        Me.Cb_TipoMoneda.Location = New System.Drawing.Point(351, 198)
        Me.Cb_TipoMoneda.Name = "Cb_TipoMoneda"
        Me.Cb_TipoMoneda.Size = New System.Drawing.Size(121, 21)
        Me.Cb_TipoMoneda.TabIndex = 20
        '
        'Fr_FacturaElectronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 261)
        Me.Controls.Add(Me.Pn_Datos)
        Me.Controls.Add(Me.Tlp_PieDePagina)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_FacturaElectronica"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionar Aprobación"
        Me.Tlp_PieDePagina.ResumeLayout(False)
        Me.Tlp_PieDePagina.PerformLayout()
        Me.Flp_Estado.ResumeLayout(False)
        Me.Flp_Estado.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Datos.ResumeLayout(False)
        Me.Pn_Datos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tlp_PieDePagina As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Pn_Datos As System.Windows.Forms.Panel
    Friend WithEvents Tx_IdentificacionNIT As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Cb_Consecutivo As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_TipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_TipoAprobacion As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Bt_BuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Lb_Consecutivo As System.Windows.Forms.Label
    Friend WithEvents Lb_TipoMoneda As System.Windows.Forms.Label
    Friend WithEvents Lb_Valor As System.Windows.Forms.Label
    Friend WithEvents Lb_PersonaAprueba As System.Windows.Forms.Label
    Friend WithEvents Lb_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Lb_NIT As System.Windows.Forms.Label
    Friend WithEvents Lb_TipoAprobacion As System.Windows.Forms.Label
    Friend WithEvents Lb_Dependencia As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaAprueba As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents CuTx_Valor As FormulariosClasesBase.Cu_TextBoxDecimal
    Friend WithEvents Bt_AgregarTipoAprobacion As System.Windows.Forms.Button
    Friend WithEvents Tx_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Subgerencia As System.Windows.Forms.Label
    Friend WithEvents Cb_Subgerencia As System.Windows.Forms.ComboBox
    Friend WithEvents Flp_Estado As System.Windows.Forms.FlowLayoutPanel
    Public WithEvents Lb_Estado As System.Windows.Forms.Label
End Class
