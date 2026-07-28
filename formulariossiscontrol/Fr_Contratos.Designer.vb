<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Contratos
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
        Me.Tx_Proveedor = New System.Windows.Forms.TextBox()
        Me.Tx_IdentificacionNIT = New System.Windows.Forms.TextBox()
        Me.Cb_AurorizaDctoSS = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Tb_NroContrato = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tb_NroFactura = New System.Windows.Forms.TextBox()
        Me.Tb_ValorFactura = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bt_BuscarProveedor
        '
        Me.Bt_BuscarProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_BuscarProveedor.Location = New System.Drawing.Point(502, 61)
        Me.Bt_BuscarProveedor.Name = "Bt_BuscarProveedor"
        Me.Bt_BuscarProveedor.Size = New System.Drawing.Size(28, 23)
        Me.Bt_BuscarProveedor.TabIndex = 4
        Me.Bt_BuscarProveedor.Text = "..."
        Me.Bt_BuscarProveedor.UseVisualStyleBackColor = True
        '
        'Tx_Proveedor
        '
        Me.Tx_Proveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Proveedor.Location = New System.Drawing.Point(184, 63)
        Me.Tx_Proveedor.Name = "Tx_Proveedor"
        Me.Tx_Proveedor.ReadOnly = True
        Me.Tx_Proveedor.Size = New System.Drawing.Size(312, 20)
        Me.Tx_Proveedor.TabIndex = 3
        '
        'Tx_IdentificacionNIT
        '
        Me.Tx_IdentificacionNIT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_IdentificacionNIT.Location = New System.Drawing.Point(84, 63)
        Me.Tx_IdentificacionNIT.Name = "Tx_IdentificacionNIT"
        Me.Tx_IdentificacionNIT.ReadOnly = True
        Me.Tx_IdentificacionNIT.Size = New System.Drawing.Size(94, 20)
        Me.Tx_IdentificacionNIT.TabIndex = 2
        '
        'Cb_AurorizaDctoSS
        '
        Me.Cb_AurorizaDctoSS.FormattingEnabled = True
        Me.Cb_AurorizaDctoSS.Location = New System.Drawing.Point(351, 89)
        Me.Cb_AurorizaDctoSS.Name = "Cb_AurorizaDctoSS"
        Me.Cb_AurorizaDctoSS.Size = New System.Drawing.Size(179, 21)
        Me.Cb_AurorizaDctoSS.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(256, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Autoriza Dcto SS:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 149)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(538, 30)
        Me.Panel1.TabIndex = 49
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(375, 4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(456, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Tb_NroContrato
        '
        Me.Tb_NroContrato.Location = New System.Drawing.Point(84, 90)
        Me.Tb_NroContrato.MaxLength = 30
        Me.Tb_NroContrato.Name = "Tb_NroContrato"
        Me.Tb_NroContrato.Size = New System.Drawing.Size(150, 20)
        Me.Tb_NroContrato.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(274, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "Valor Factura:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Proveedor:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Fecha:"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Info
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(538, 30)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "CONTRATOS"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dtp_Fecha
        '
        Me.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha.Location = New System.Drawing.Point(84, 37)
        Me.Dtp_Fecha.Name = "Dtp_Fecha"
        Me.Dtp_Fecha.ShowCheckBox = True
        Me.Dtp_Fecha.Size = New System.Drawing.Size(116, 20)
        Me.Dtp_Fecha.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Nro. Contrato:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Nro. Factura:"
        '
        'Tb_NroFactura
        '
        Me.Tb_NroFactura.Location = New System.Drawing.Point(84, 116)
        Me.Tb_NroFactura.MaxLength = 20
        Me.Tb_NroFactura.Name = "Tb_NroFactura"
        Me.Tb_NroFactura.Size = New System.Drawing.Size(150, 20)
        Me.Tb_NroFactura.TabIndex = 7
        '
        'Tb_ValorFactura
        '
        Me.Tb_ValorFactura.Location = New System.Drawing.Point(351, 116)
        Me.Tb_ValorFactura.MaxLength = 200
        Me.Tb_ValorFactura.Name = "Tb_ValorFactura"
        Me.Tb_ValorFactura.Size = New System.Drawing.Size(179, 20)
        Me.Tb_ValorFactura.TabIndex = 8
        '
        'Fr_Contratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 179)
        Me.Controls.Add(Me.Tb_ValorFactura)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Tb_NroFactura)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Dtp_Fecha)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Tb_NroContrato)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cb_AurorizaDctoSS)
        Me.Controls.Add(Me.Tx_IdentificacionNIT)
        Me.Controls.Add(Me.Tx_Proveedor)
        Me.Controls.Add(Me.Bt_BuscarProveedor)
        Me.MaximumSize = New System.Drawing.Size(554, 218)
        Me.MinimumSize = New System.Drawing.Size(554, 218)
        Me.Name = "Fr_Contratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contratos"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bt_BuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Tx_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Tx_IdentificacionNIT As System.Windows.Forms.TextBox
    Friend WithEvents Cb_AurorizaDctoSS As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Tb_NroContrato As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tb_NroFactura As System.Windows.Forms.TextBox
    Friend WithEvents Tb_ValorFactura As System.Windows.Forms.TextBox
End Class
