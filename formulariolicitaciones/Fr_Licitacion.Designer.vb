<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Licitacion
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
        Me.Tx_HorasDiarias = New System.Windows.Forms.TextBox()
        Me.Lb_HorasDiarias = New System.Windows.Forms.Label()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.TlpBotones = New System.Windows.Forms.TableLayoutPanel()
        Me.Bt_SeleccionarLicitacion = New System.Windows.Forms.Button()
        Me.Lb_NroLicitacion = New System.Windows.Forms.Label()
        Me.Tx_NroLicitacion = New System.Windows.Forms.TextBox()
        Me.Lb_Proyecto = New System.Windows.Forms.Label()
        Me.Tx_Proyecto = New System.Windows.Forms.TextBox()
        Me.Lb_Cliente = New System.Windows.Forms.Label()
        Me.Tx_Cliente = New System.Windows.Forms.TextBox()
        Me.Lb_Gerencia = New System.Windows.Forms.Label()
        Me.Cb_Gerencia = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CuTx_Administracion = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.CuTx_Utilidad = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.CuTx_Imprevistos = New FormulariosClasesBase.Cu_TextBoxDecimal()
        Me.Lb_Contratista = New System.Windows.Forms.Label()
        Me.Tx_Contratista = New System.Windows.Forms.TextBox()
        Me.Ck_Activa = New System.Windows.Forms.CheckBox()
        Me.Lb_Administracion = New System.Windows.Forms.Label()
        Me.Lb_Imprevistos = New System.Windows.Forms.Label()
        Me.Lb_Utilidad = New System.Windows.Forms.Label()
        Me.Flp_Botones.SuspendLayout()
        Me.TlpBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tx_HorasDiarias
        '
        Me.Tx_HorasDiarias.Location = New System.Drawing.Point(87, 181)
        Me.Tx_HorasDiarias.MaxLength = 2
        Me.Tx_HorasDiarias.Name = "Tx_HorasDiarias"
        Me.Tx_HorasDiarias.Size = New System.Drawing.Size(60, 20)
        Me.Tx_HorasDiarias.TabIndex = 12
        '
        'Lb_HorasDiarias
        '
        Me.Lb_HorasDiarias.AutoSize = True
        Me.Lb_HorasDiarias.Location = New System.Drawing.Point(13, 184)
        Me.Lb_HorasDiarias.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Lb_HorasDiarias.Name = "Lb_HorasDiarias"
        Me.Lb_HorasDiarias.Size = New System.Drawing.Size(71, 13)
        Me.Lb_HorasDiarias.TabIndex = 11
        Me.Lb_HorasDiarias.Text = "Horas diarias:"
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(127, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(477, 30)
        Me.Flp_Botones.TabIndex = 0
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.Location = New System.Drawing.Point(399, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(318, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'TlpBotones
        '
        Me.TlpBotones.BackColor = System.Drawing.Color.Silver
        Me.TlpBotones.ColumnCount = 2
        Me.TlpBotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TlpBotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlpBotones.Controls.Add(Me.Bt_SeleccionarLicitacion, 0, 0)
        Me.TlpBotones.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.TlpBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TlpBotones.Location = New System.Drawing.Point(0, 207)
        Me.TlpBotones.Name = "TlpBotones"
        Me.TlpBotones.RowCount = 1
        Me.TlpBotones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlpBotones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TlpBotones.Size = New System.Drawing.Size(604, 30)
        Me.TlpBotones.TabIndex = 1
        '
        'Bt_SeleccionarLicitacion
        '
        Me.Bt_SeleccionarLicitacion.AutoSize = True
        Me.Bt_SeleccionarLicitacion.Location = New System.Drawing.Point(3, 3)
        Me.Bt_SeleccionarLicitacion.Name = "Bt_SeleccionarLicitacion"
        Me.Bt_SeleccionarLicitacion.Size = New System.Drawing.Size(121, 23)
        Me.Bt_SeleccionarLicitacion.TabIndex = 0
        Me.Bt_SeleccionarLicitacion.Text = "Seleccionar Licitación"
        Me.Bt_SeleccionarLicitacion.UseVisualStyleBackColor = True
        Me.Bt_SeleccionarLicitacion.Visible = False
        '
        'Lb_NroLicitacion
        '
        Me.Lb_NroLicitacion.AutoSize = True
        Me.Lb_NroLicitacion.Location = New System.Drawing.Point(6, 13)
        Me.Lb_NroLicitacion.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Lb_NroLicitacion.Name = "Lb_NroLicitacion"
        Me.Lb_NroLicitacion.Size = New System.Drawing.Size(78, 13)
        Me.Lb_NroLicitacion.TabIndex = 0
        Me.Lb_NroLicitacion.Text = "Licitación Nro.:"
        '
        'Tx_NroLicitacion
        '
        Me.Tx_NroLicitacion.Location = New System.Drawing.Point(87, 10)
        Me.Tx_NroLicitacion.MaxLength = 100
        Me.Tx_NroLicitacion.Name = "Tx_NroLicitacion"
        Me.Tx_NroLicitacion.Size = New System.Drawing.Size(224, 20)
        Me.Tx_NroLicitacion.TabIndex = 1
        '
        'Lb_Proyecto
        '
        Me.Lb_Proyecto.AutoSize = True
        Me.Lb_Proyecto.Location = New System.Drawing.Point(32, 39)
        Me.Lb_Proyecto.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Lb_Proyecto.Name = "Lb_Proyecto"
        Me.Lb_Proyecto.Size = New System.Drawing.Size(52, 13)
        Me.Lb_Proyecto.TabIndex = 2
        Me.Lb_Proyecto.Text = "Proyecto:"
        '
        'Tx_Proyecto
        '
        Me.Tx_Proyecto.Location = New System.Drawing.Point(87, 36)
        Me.Tx_Proyecto.Margin = New System.Windows.Forms.Padding(3, 3, 6, 3)
        Me.Tx_Proyecto.MaxLength = 200
        Me.Tx_Proyecto.Multiline = True
        Me.Tx_Proyecto.Name = "Tx_Proyecto"
        Me.Tx_Proyecto.Size = New System.Drawing.Size(510, 60)
        Me.Tx_Proyecto.TabIndex = 3
        '
        'Lb_Cliente
        '
        Me.Lb_Cliente.AutoSize = True
        Me.Lb_Cliente.Location = New System.Drawing.Point(42, 131)
        Me.Lb_Cliente.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Lb_Cliente.Name = "Lb_Cliente"
        Me.Lb_Cliente.Size = New System.Drawing.Size(42, 13)
        Me.Lb_Cliente.TabIndex = 6
        Me.Lb_Cliente.Text = "Cliente:"
        '
        'Tx_Cliente
        '
        Me.Tx_Cliente.Location = New System.Drawing.Point(87, 128)
        Me.Tx_Cliente.Margin = New System.Windows.Forms.Padding(3, 3, 6, 3)
        Me.Tx_Cliente.MaxLength = 100
        Me.Tx_Cliente.Name = "Tx_Cliente"
        Me.Tx_Cliente.Size = New System.Drawing.Size(510, 20)
        Me.Tx_Cliente.TabIndex = 7
        '
        'Lb_Gerencia
        '
        Me.Lb_Gerencia.AutoSize = True
        Me.Lb_Gerencia.Location = New System.Drawing.Point(31, 157)
        Me.Lb_Gerencia.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Lb_Gerencia.Name = "Lb_Gerencia"
        Me.Lb_Gerencia.Size = New System.Drawing.Size(53, 13)
        Me.Lb_Gerencia.TabIndex = 8
        Me.Lb_Gerencia.Text = "Gerencia:"
        Me.Lb_Gerencia.Visible = False
        '
        'Cb_Gerencia
        '
        Me.Cb_Gerencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Gerencia.FormattingEnabled = True
        Me.Cb_Gerencia.Location = New System.Drawing.Point(87, 154)
        Me.Cb_Gerencia.Name = "Cb_Gerencia"
        Me.Cb_Gerencia.Size = New System.Drawing.Size(224, 21)
        Me.Cb_Gerencia.TabIndex = 9
        Me.Cb_Gerencia.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CuTx_Administracion)
        Me.Panel1.Controls.Add(Me.CuTx_Utilidad)
        Me.Panel1.Controls.Add(Me.CuTx_Imprevistos)
        Me.Panel1.Controls.Add(Me.Lb_NroLicitacion)
        Me.Panel1.Controls.Add(Me.Tx_NroLicitacion)
        Me.Panel1.Controls.Add(Me.Lb_Proyecto)
        Me.Panel1.Controls.Add(Me.Tx_Proyecto)
        Me.Panel1.Controls.Add(Me.Lb_Contratista)
        Me.Panel1.Controls.Add(Me.Tx_Contratista)
        Me.Panel1.Controls.Add(Me.Lb_Cliente)
        Me.Panel1.Controls.Add(Me.Tx_Cliente)
        Me.Panel1.Controls.Add(Me.Lb_Gerencia)
        Me.Panel1.Controls.Add(Me.Cb_Gerencia)
        Me.Panel1.Controls.Add(Me.Ck_Activa)
        Me.Panel1.Controls.Add(Me.Lb_HorasDiarias)
        Me.Panel1.Controls.Add(Me.Tx_HorasDiarias)
        Me.Panel1.Controls.Add(Me.Lb_Administracion)
        Me.Panel1.Controls.Add(Me.Lb_Imprevistos)
        Me.Panel1.Controls.Add(Me.Lb_Utilidad)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(604, 207)
        Me.Panel1.TabIndex = 0
        '
        'CuTx_Administracion
        '
        Me.CuTx_Administracion.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(80)
        Me.CuTx_Administracion.Location = New System.Drawing.Point(251, 181)
        Me.CuTx_Administracion.MaxLongitudTexto = 3
        Me.CuTx_Administracion.Name = "CuTx_Administracion"
        Me.CuTx_Administracion.PosicionesDecimales = CType(0US, UShort)
        Me.CuTx_Administracion.Size = New System.Drawing.Size(60, 20)
        Me.CuTx_Administracion.SoloLectura = False
        Me.CuTx_Administracion.TabIndex = 14
        Me.CuTx_Administracion.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'CuTx_Utilidad
        '
        Me.CuTx_Utilidad.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(80)
        Me.CuTx_Utilidad.Location = New System.Drawing.Point(537, 181)
        Me.CuTx_Utilidad.MaxLongitudTexto = 3
        Me.CuTx_Utilidad.Name = "CuTx_Utilidad"
        Me.CuTx_Utilidad.PosicionesDecimales = CType(0US, UShort)
        Me.CuTx_Utilidad.Size = New System.Drawing.Size(60, 20)
        Me.CuTx_Utilidad.SoloLectura = False
        Me.CuTx_Utilidad.TabIndex = 18
        Me.CuTx_Utilidad.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'CuTx_Imprevistos
        '
        Me.CuTx_Imprevistos.FormatoDeDatos = Global.Microsoft.VisualBasic.ChrW(80)
        Me.CuTx_Imprevistos.Location = New System.Drawing.Point(399, 181)
        Me.CuTx_Imprevistos.MaxLongitudTexto = 3
        Me.CuTx_Imprevistos.Name = "CuTx_Imprevistos"
        Me.CuTx_Imprevistos.PosicionesDecimales = CType(0US, UShort)
        Me.CuTx_Imprevistos.Size = New System.Drawing.Size(60, 20)
        Me.CuTx_Imprevistos.SoloLectura = False
        Me.CuTx_Imprevistos.TabIndex = 16
        Me.CuTx_Imprevistos.Valor = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Lb_Contratista
        '
        Me.Lb_Contratista.AutoSize = True
        Me.Lb_Contratista.Location = New System.Drawing.Point(24, 105)
        Me.Lb_Contratista.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Lb_Contratista.Name = "Lb_Contratista"
        Me.Lb_Contratista.Size = New System.Drawing.Size(60, 13)
        Me.Lb_Contratista.TabIndex = 4
        Me.Lb_Contratista.Text = "Contratista:"
        '
        'Tx_Contratista
        '
        Me.Tx_Contratista.Location = New System.Drawing.Point(87, 102)
        Me.Tx_Contratista.Margin = New System.Windows.Forms.Padding(3, 3, 6, 3)
        Me.Tx_Contratista.MaxLength = 100
        Me.Tx_Contratista.Name = "Tx_Contratista"
        Me.Tx_Contratista.Size = New System.Drawing.Size(510, 20)
        Me.Tx_Contratista.TabIndex = 5
        '
        'Ck_Activa
        '
        Me.Ck_Activa.AutoSize = True
        Me.Ck_Activa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_Activa.Checked = True
        Me.Ck_Activa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_Activa.Location = New System.Drawing.Point(490, 157)
        Me.Ck_Activa.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.Ck_Activa.Name = "Ck_Activa"
        Me.Ck_Activa.Size = New System.Drawing.Size(107, 17)
        Me.Ck_Activa.TabIndex = 10
        Me.Ck_Activa.Text = "Licitación Activa:"
        Me.Ck_Activa.UseVisualStyleBackColor = True
        '
        'Lb_Administracion
        '
        Me.Lb_Administracion.AutoSize = True
        Me.Lb_Administracion.Location = New System.Drawing.Point(167, 184)
        Me.Lb_Administracion.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Lb_Administracion.Name = "Lb_Administracion"
        Me.Lb_Administracion.Size = New System.Drawing.Size(78, 13)
        Me.Lb_Administracion.TabIndex = 13
        Me.Lb_Administracion.Text = "Administración:"
        '
        'Lb_Imprevistos
        '
        Me.Lb_Imprevistos.AutoSize = True
        Me.Lb_Imprevistos.Location = New System.Drawing.Point(330, 184)
        Me.Lb_Imprevistos.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Lb_Imprevistos.Name = "Lb_Imprevistos"
        Me.Lb_Imprevistos.Size = New System.Drawing.Size(63, 13)
        Me.Lb_Imprevistos.TabIndex = 15
        Me.Lb_Imprevistos.Text = "Imprevistos:"
        '
        'Lb_Utilidad
        '
        Me.Lb_Utilidad.AutoSize = True
        Me.Lb_Utilidad.Location = New System.Drawing.Point(486, 184)
        Me.Lb_Utilidad.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Lb_Utilidad.Name = "Lb_Utilidad"
        Me.Lb_Utilidad.Size = New System.Drawing.Size(45, 13)
        Me.Lb_Utilidad.TabIndex = 17
        Me.Lb_Utilidad.Text = "Utilidad:"
        '
        'Fr_Licitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Bt_Cancelar
        Me.ClientSize = New System.Drawing.Size(604, 237)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TlpBotones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Fr_Licitacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionando Licitación"
        Me.Flp_Botones.ResumeLayout(False)
        Me.TlpBotones.ResumeLayout(False)
        Me.TlpBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_HorasDiarias As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Tx_HorasDiarias As System.Windows.Forms.TextBox
    Friend WithEvents TlpBotones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Bt_SeleccionarLicitacion As System.Windows.Forms.Button
    Friend WithEvents Tx_Proyecto As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Proyecto As System.Windows.Forms.Label
    Friend WithEvents Tx_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Cliente As System.Windows.Forms.Label
    Friend WithEvents Tx_NroLicitacion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_NroLicitacion As System.Windows.Forms.Label
    Friend WithEvents Cb_Gerencia As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Gerencia As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lb_Contratista As System.Windows.Forms.Label
    Friend WithEvents Tx_Contratista As System.Windows.Forms.TextBox
    Friend WithEvents Ck_Activa As System.Windows.Forms.CheckBox
    Friend WithEvents Lb_Administracion As System.Windows.Forms.Label
    Friend WithEvents Lb_Imprevistos As System.Windows.Forms.Label
    Friend WithEvents Lb_Utilidad As System.Windows.Forms.Label
    Friend WithEvents CuTx_Administracion As FormulariosClasesBase.Cu_TextBoxDecimal
    Friend WithEvents CuTx_Utilidad As FormulariosClasesBase.Cu_TextBoxDecimal
    Friend WithEvents CuTx_Imprevistos As FormulariosClasesBase.Cu_TextBoxDecimal
End Class
