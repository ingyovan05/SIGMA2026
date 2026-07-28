<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_DocumentoEquivalente
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tx_Concepto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Tx_ValorDocumento = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Dtp_FechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_Consecutivo = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cb_TipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cb_TipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Cu_BuscarPersonaResponsable = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_AsociarPersonaBodega2 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Tx_IdentificacionNIT = New System.Windows.Forms.TextBox()
        Me.Tx_Proveedor = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarProveedor = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cb_AurorizaDctoSS = New System.Windows.Forms.ComboBox()
        Me.Ll_ValorAcumuladoProveedor = New System.Windows.Forms.LinkLabel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Info
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(562, 30)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "DOCUMENTO SOPORTE"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Fecha:"
        '
        'Dtp_Fecha
        '
        Me.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha.Location = New System.Drawing.Point(97, 36)
        Me.Dtp_Fecha.Name = "Dtp_Fecha"
        Me.Dtp_Fecha.ShowCheckBox = True
        Me.Dtp_Fecha.Size = New System.Drawing.Size(116, 20)
        Me.Dtp_Fecha.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Proveedor:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Concepto:"
        '
        'Tx_Concepto
        '
        Me.Tx_Concepto.Location = New System.Drawing.Point(95, 106)
        Me.Tx_Concepto.MaxLength = 800
        Me.Tx_Concepto.Multiline = True
        Me.Tx_Concepto.Name = "Tx_Concepto"
        Me.Tx_Concepto.Size = New System.Drawing.Size(458, 40)
        Me.Tx_Concepto.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(61, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Valor:"
        '
        'Tx_ValorDocumento
        '
        Me.Tx_ValorDocumento.Location = New System.Drawing.Point(95, 151)
        Me.Tx_ValorDocumento.MaxLength = 200
        Me.Tx_ValorDocumento.Name = "Tx_ValorDocumento"
        Me.Tx_ValorDocumento.Size = New System.Drawing.Size(80, 20)
        Me.Tx_ValorDocumento.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(295, 203)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Fecha Vencimiento:"
        '
        'Dtp_FechaVencimiento
        '
        Me.Dtp_FechaVencimiento.Checked = False
        Me.Dtp_FechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaVencimiento.Location = New System.Drawing.Point(399, 201)
        Me.Dtp_FechaVencimiento.Name = "Dtp_FechaVencimiento"
        Me.Dtp_FechaVencimiento.ShowCheckBox = True
        Me.Dtp_FechaVencimiento.Size = New System.Drawing.Size(116, 20)
        Me.Dtp_FechaVencimiento.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Responsable ISM:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lb_Consecutivo)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 251)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(562, 30)
        Me.Panel1.TabIndex = 35
        '
        'Lb_Consecutivo
        '
        Me.Lb_Consecutivo.AutoSize = True
        Me.Lb_Consecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Consecutivo.ForeColor = System.Drawing.Color.Red
        Me.Lb_Consecutivo.Location = New System.Drawing.Point(11, 8)
        Me.Lb_Consecutivo.Name = "Lb_Consecutivo"
        Me.Lb_Consecutivo.Size = New System.Drawing.Size(52, 13)
        Me.Lb_Consecutivo.TabIndex = 2
        Me.Lb_Consecutivo.Text = "Label13"
        Me.Lb_Consecutivo.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(397, 4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(478, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(309, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Tipo Documento:"
        '
        'Cb_TipoDocumento
        '
        Me.Cb_TipoDocumento.FormattingEnabled = True
        Me.Cb_TipoDocumento.Location = New System.Drawing.Point(398, 36)
        Me.Cb_TipoDocumento.Name = "Cb_TipoDocumento"
        Me.Cb_TipoDocumento.Size = New System.Drawing.Size(155, 21)
        Me.Cb_TipoDocumento.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(340, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Moneda:"
        '
        'Cb_TipoMoneda
        '
        Me.Cb_TipoMoneda.FormattingEnabled = True
        Me.Cb_TipoMoneda.Location = New System.Drawing.Point(398, 150)
        Me.Cb_TipoMoneda.Name = "Cb_TipoMoneda"
        Me.Cb_TipoMoneda.Size = New System.Drawing.Size(154, 21)
        Me.Cb_TipoMoneda.TabIndex = 8
        '
        'Cu_BuscarPersonaResponsable
        '
        Me.Cu_BuscarPersonaResponsable.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaResponsable.Location = New System.Drawing.Point(93, 174)
        Me.Cu_BuscarPersonaResponsable.Name = "Cu_BuscarPersonaResponsable"
        Me.Cu_BuscarPersonaResponsable.Size = New System.Drawing.Size(435, 23)
        Me.Cu_BuscarPersonaResponsable.TabIndex = 9
        Me.Cu_BuscarPersonaResponsable.Tipo = "PADEP"
        Me.Cu_BuscarPersonaResponsable.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_AsociarPersonaBodega2
        '
        Me.Cu_AsociarPersonaBodega2.componenteasociado = "Cu_BuscarPersonaResponsable"
        Me.Cu_AsociarPersonaBodega2.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega2.Location = New System.Drawing.Point(527, 175)
        Me.Cu_AsociarPersonaBodega2.Name = "Cu_AsociarPersonaBodega2"
        Me.Cu_AsociarPersonaBodega2.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega2.TabIndex = 10
        Me.Cu_AsociarPersonaBodega2.TipoAsociacion = "DEP"
        Me.Cu_AsociarPersonaBodega2.TipoBúsqueda = "P"
        '
        'Cu_CentroCosto1
        '
        Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto1.Location = New System.Drawing.Point(95, 200)
        Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
        Me.Cu_CentroCosto1.Size = New System.Drawing.Size(185, 47)
        Me.Cu_CentroCosto1.TabIndex = 11
        '
        'Tx_IdentificacionNIT
        '
        Me.Tx_IdentificacionNIT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_IdentificacionNIT.Location = New System.Drawing.Point(97, 61)
        Me.Tx_IdentificacionNIT.Name = "Tx_IdentificacionNIT"
        Me.Tx_IdentificacionNIT.ReadOnly = True
        Me.Tx_IdentificacionNIT.Size = New System.Drawing.Size(76, 20)
        Me.Tx_IdentificacionNIT.TabIndex = 3
        '
        'Tx_Proveedor
        '
        Me.Tx_Proveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Proveedor.Location = New System.Drawing.Point(176, 61)
        Me.Tx_Proveedor.Name = "Tx_Proveedor"
        Me.Tx_Proveedor.ReadOnly = True
        Me.Tx_Proveedor.Size = New System.Drawing.Size(348, 20)
        Me.Tx_Proveedor.TabIndex = 4
        '
        'Bt_BuscarProveedor
        '
        Me.Bt_BuscarProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_BuscarProveedor.Location = New System.Drawing.Point(527, 60)
        Me.Bt_BuscarProveedor.Name = "Bt_BuscarProveedor"
        Me.Bt_BuscarProveedor.Size = New System.Drawing.Size(26, 23)
        Me.Bt_BuscarProveedor.TabIndex = 5
        Me.Bt_BuscarProveedor.Text = "..."
        Me.Bt_BuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(305, 228)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Autoriza Dcto SS:"
        '
        'Cb_AurorizaDctoSS
        '
        Me.Cb_AurorizaDctoSS.FormattingEnabled = True
        Me.Cb_AurorizaDctoSS.Location = New System.Drawing.Point(398, 224)
        Me.Cb_AurorizaDctoSS.Name = "Cb_AurorizaDctoSS"
        Me.Cb_AurorizaDctoSS.Size = New System.Drawing.Size(155, 21)
        Me.Cb_AurorizaDctoSS.TabIndex = 13
        '
        'Ll_ValorAcumuladoProveedor
        '
        Me.Ll_ValorAcumuladoProveedor.AutoSize = True
        Me.Ll_ValorAcumuladoProveedor.Location = New System.Drawing.Point(184, 87)
        Me.Ll_ValorAcumuladoProveedor.Name = "Ll_ValorAcumuladoProveedor"
        Me.Ll_ValorAcumuladoProveedor.Size = New System.Drawing.Size(0, 13)
        Me.Ll_ValorAcumuladoProveedor.TabIndex = 50
        '
        'Fr_DocumentoEquivalente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 281)
        Me.Controls.Add(Me.Ll_ValorAcumuladoProveedor)
        Me.Controls.Add(Me.Cu_AsociarPersonaBodega2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cb_AurorizaDctoSS)
        Me.Controls.Add(Me.Bt_BuscarProveedor)
        Me.Controls.Add(Me.Tx_Proveedor)
        Me.Controls.Add(Me.Tx_IdentificacionNIT)
        Me.Controls.Add(Me.Cb_TipoMoneda)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cb_TipoDocumento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Cu_BuscarPersonaResponsable)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Dtp_FechaVencimiento)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Tx_ValorDocumento)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Tx_Concepto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Dtp_Fecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Cu_CentroCosto1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(578, 320)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(578, 320)
        Me.Name = "Fr_DocumentoEquivalente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documento Soporte"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
    Friend WithEvents Cu_AsociarPersonaBodega2 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Tx_Concepto As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Tx_ValorDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaResponsable As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Lb_Consecutivo As System.Windows.Forms.Label
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Tx_IdentificacionNIT As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Bt_BuscarProveedor As System.Windows.Forms.Button
    Public WithEvents Dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cb_AurorizaDctoSS As System.Windows.Forms.ComboBox
    Friend WithEvents Ll_ValorAcumuladoProveedor As System.Windows.Forms.LinkLabel
End Class
