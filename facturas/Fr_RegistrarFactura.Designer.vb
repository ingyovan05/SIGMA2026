<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_RegistrarFactura
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
        Me.Bt_BuscarProveedor = New System.Windows.Forms.Button()
        Me.Tx_NombreProveedor = New System.Windows.Forms.TextBox()
        Me.Tx_DigVerificación = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tx_Identificación = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Tx_Factura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dtp_FechaDocumento = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Dtp_FechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_FechaRadicadoBase = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_FechaRadicadoPrincipal = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Tx_ValorFactura = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Tx_Observación = New System.Windows.Forms.TextBox()
        Me.Tx_Anexos = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bt_BuscarProveedor
        '
        Me.Bt_BuscarProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_BuscarProveedor.Location = New System.Drawing.Point(212, 5)
        Me.Bt_BuscarProveedor.Name = "Bt_BuscarProveedor"
        Me.Bt_BuscarProveedor.Size = New System.Drawing.Size(28, 23)
        Me.Bt_BuscarProveedor.TabIndex = 9
        Me.Bt_BuscarProveedor.Text = "..."
        Me.Bt_BuscarProveedor.UseVisualStyleBackColor = True
        '
        'Tx_NombreProveedor
        '
        Me.Tx_NombreProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_NombreProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_NombreProveedor.Location = New System.Drawing.Point(110, 34)
        Me.Tx_NombreProveedor.MaxLength = 150
        Me.Tx_NombreProveedor.Multiline = True
        Me.Tx_NombreProveedor.Name = "Tx_NombreProveedor"
        Me.Tx_NombreProveedor.ReadOnly = True
        Me.Tx_NombreProveedor.Size = New System.Drawing.Size(440, 40)
        Me.Tx_NombreProveedor.TabIndex = 12
        '
        'Tx_DigVerificación
        '
        Me.Tx_DigVerificación.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_DigVerificación.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_DigVerificación.Location = New System.Drawing.Point(77, 34)
        Me.Tx_DigVerificación.MaxLength = 1
        Me.Tx_DigVerificación.Name = "Tx_DigVerificación"
        Me.Tx_DigVerificación.ReadOnly = True
        Me.Tx_DigVerificación.Size = New System.Drawing.Size(27, 20)
        Me.Tx_DigVerificación.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Dig Ver:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Identificación:"
        '
        'Tx_Identificación
        '
        Me.Tx_Identificación.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_Identificación.Location = New System.Drawing.Point(79, 6)
        Me.Tx_Identificación.MaxLength = 15
        Me.Tx_Identificación.Name = "Tx_Identificación"
        Me.Tx_Identificación.Size = New System.Drawing.Size(127, 20)
        Me.Tx_Identificación.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Bt_BuscarProveedor)
        Me.Panel1.Controls.Add(Me.Tx_Identificación)
        Me.Panel1.Controls.Add(Me.Tx_NombreProveedor)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Tx_DigVerificación)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(555, 81)
        Me.Panel1.TabIndex = 13
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel3.Controls.Add(Me.Bt_Guardar)
        Me.Panel3.Controls.Add(Me.Bt_Cerrar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 215)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(555, 33)
        Me.Panel3.TabIndex = 14
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Guardar.Location = New System.Drawing.Point(413, 6)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(62, 23)
        Me.Bt_Guardar.TabIndex = 9
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Cerrar.Location = New System.Drawing.Point(481, 6)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(71, 23)
        Me.Bt_Cerrar.TabIndex = 8
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Tx_Factura
        '
        Me.Tx_Factura.Location = New System.Drawing.Point(137, 86)
        Me.Tx_Factura.MaxLength = 20
        Me.Tx_Factura.Name = "Tx_Factura"
        Me.Tx_Factura.Size = New System.Drawing.Size(143, 20)
        Me.Tx_Factura.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = " Factura:"
        '
        'Dtp_FechaDocumento
        '
        Me.Dtp_FechaDocumento.Checked = False
        Me.Dtp_FechaDocumento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaDocumento.Location = New System.Drawing.Point(421, 86)
        Me.Dtp_FechaDocumento.Name = "Dtp_FechaDocumento"
        Me.Dtp_FechaDocumento.ShowCheckBox = True
        Me.Dtp_FechaDocumento.Size = New System.Drawing.Size(129, 20)
        Me.Dtp_FechaDocumento.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(320, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Fecha Documento:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Fecha Vencimiento:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Fecha Radicado Base:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(286, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Fecha Radicado Principal:"
        '
        'Dtp_FechaVencimiento
        '
        Me.Dtp_FechaVencimiento.Checked = False
        Me.Dtp_FechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaVencimiento.Location = New System.Drawing.Point(137, 133)
        Me.Dtp_FechaVencimiento.Name = "Dtp_FechaVencimiento"
        Me.Dtp_FechaVencimiento.ShowCheckBox = True
        Me.Dtp_FechaVencimiento.Size = New System.Drawing.Size(143, 20)
        Me.Dtp_FechaVencimiento.TabIndex = 22
        '
        'Dtp_FechaRadicadoBase
        '
        Me.Dtp_FechaRadicadoBase.Checked = False
        Me.Dtp_FechaRadicadoBase.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaRadicadoBase.Location = New System.Drawing.Point(137, 109)
        Me.Dtp_FechaRadicadoBase.Name = "Dtp_FechaRadicadoBase"
        Me.Dtp_FechaRadicadoBase.ShowCheckBox = True
        Me.Dtp_FechaRadicadoBase.Size = New System.Drawing.Size(143, 20)
        Me.Dtp_FechaRadicadoBase.TabIndex = 23
        '
        'Dtp_FechaRadicadoPrincipal
        '
        Me.Dtp_FechaRadicadoPrincipal.Checked = False
        Me.Dtp_FechaRadicadoPrincipal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaRadicadoPrincipal.Location = New System.Drawing.Point(421, 109)
        Me.Dtp_FechaRadicadoPrincipal.Name = "Dtp_FechaRadicadoPrincipal"
        Me.Dtp_FechaRadicadoPrincipal.ShowCheckBox = True
        Me.Dtp_FechaRadicadoPrincipal.Size = New System.Drawing.Size(129, 20)
        Me.Dtp_FechaRadicadoPrincipal.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(345, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Valor Factura:"
        '
        'Tx_ValorFactura
        '
        Me.Tx_ValorFactura.Location = New System.Drawing.Point(421, 137)
        Me.Tx_ValorFactura.MaxLength = 20
        Me.Tx_ValorFactura.Name = "Tx_ValorFactura"
        Me.Tx_ValorFactura.Size = New System.Drawing.Size(129, 20)
        Me.Tx_ValorFactura.TabIndex = 26
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 166)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Observación:"
        '
        'Tx_Observación
        '
        Me.Tx_Observación.Location = New System.Drawing.Point(77, 163)
        Me.Tx_Observación.MaxLength = 100
        Me.Tx_Observación.Name = "Tx_Observación"
        Me.Tx_Observación.Size = New System.Drawing.Size(473, 20)
        Me.Tx_Observación.TabIndex = 28
        '
        'Tx_Anexos
        '
        Me.Tx_Anexos.Location = New System.Drawing.Point(77, 189)
        Me.Tx_Anexos.MaxLength = 100
        Me.Tx_Anexos.Name = "Tx_Anexos"
        Me.Tx_Anexos.Size = New System.Drawing.Size(473, 20)
        Me.Tx_Anexos.TabIndex = 30
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(30, 192)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Anexos:"
        '
        'Fr_RegistrarFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 248)
        Me.Controls.Add(Me.Tx_Anexos)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Tx_Observación)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Tx_ValorFactura)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Dtp_FechaRadicadoPrincipal)
        Me.Controls.Add(Me.Dtp_FechaRadicadoBase)
        Me.Controls.Add(Me.Dtp_FechaVencimiento)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Dtp_FechaDocumento)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Tx_Factura)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(571, 286)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(571, 286)
        Me.Name = "Fr_RegistrarFactura"
        Me.Text = "Registrar Factura"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bt_BuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Tx_NombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Tx_DigVerificación As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Tx_Identificación As System.Windows.Forms.TextBox
    Public WithEvents Tx_Factura As System.Windows.Forms.TextBox
    Public WithEvents Dtp_FechaDocumento As System.Windows.Forms.DateTimePicker
    Public WithEvents Dtp_FechaVencimiento As System.Windows.Forms.DateTimePicker
    Public WithEvents Dtp_FechaRadicadoBase As System.Windows.Forms.DateTimePicker
    Public WithEvents Dtp_FechaRadicadoPrincipal As System.Windows.Forms.DateTimePicker
    Public WithEvents Tx_ValorFactura As System.Windows.Forms.TextBox
    Public WithEvents Tx_Observación As System.Windows.Forms.TextBox
    Public WithEvents Tx_Anexos As System.Windows.Forms.TextBox
End Class
