<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_CuentaCobro
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
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_CuentaCobro))
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Lb_Consecutivo = New System.Windows.Forms.Label()
    Me.Bt_Guardar = New System.Windows.Forms.Button()
    Me.Bt_Cancelar = New System.Windows.Forms.Button()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.Tx_ValorDocumento = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Dtp_FechaVencimiento = New System.Windows.Forms.DateTimePicker()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Tx_Concepto = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Dtp_Fecha = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Tx_IvaAsumido = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Cu_AsociarPersonaBodega2 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
    Me.Cu_AsociarPersonaBodega1 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
    Me.Cu_BuscarPersonaNombre = New FormulariosClasesBase.Cu_BuscarPersona()
    Me.Cu_BuscarPersonaResponsable = New FormulariosClasesBase.Cu_BuscarPersona()
    Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.DarkGray
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Controls.Add(Me.Lb_Consecutivo)
    Me.Panel1.Controls.Add(Me.Bt_Guardar)
    Me.Panel1.Controls.Add(Me.Bt_Cancelar)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel1.Location = New System.Drawing.Point(0, 225)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(574, 30)
    Me.Panel1.TabIndex = 13
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
    Me.Bt_Guardar.Location = New System.Drawing.Point(388, 4)
    Me.Bt_Guardar.Name = "Bt_Guardar"
    Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
    Me.Bt_Guardar.TabIndex = 0
    Me.Bt_Guardar.Text = "Guardar"
    Me.Bt_Guardar.UseVisualStyleBackColor = True
    '
    'Bt_Cancelar
    '
    Me.Bt_Cancelar.Location = New System.Drawing.Point(469, 3)
    Me.Bt_Cancelar.Name = "Bt_Cancelar"
    Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
    Me.Bt_Cancelar.TabIndex = 1
    Me.Bt_Cancelar.Text = "Cancelar"
    Me.Bt_Cancelar.UseVisualStyleBackColor = True
    '
    'Label16
    '
    Me.Label16.BackColor = System.Drawing.SystemColors.Info
    Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(0, 0)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(574, 30)
    Me.Label16.TabIndex = 8
    Me.Label16.Text = "CUENTA DE COBRO"
    Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Tx_ValorDocumento
    '
    Me.Tx_ValorDocumento.Location = New System.Drawing.Point(110, 131)
    Me.Tx_ValorDocumento.MaxLength = 200
    Me.Tx_ValorDocumento.Name = "Tx_ValorDocumento"
    Me.Tx_ValorDocumento.Size = New System.Drawing.Size(80, 20)
    Me.Tx_ValorDocumento.TabIndex = 4
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(73, 134)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(34, 13)
    Me.Label11.TabIndex = 12
    Me.Label11.Text = "Valor:"
    '
    'Dtp_FechaVencimiento
    '
    Me.Dtp_FechaVencimiento.Checked = False
    Me.Dtp_FechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.Dtp_FechaVencimiento.Location = New System.Drawing.Point(449, 131)
    Me.Dtp_FechaVencimiento.Name = "Dtp_FechaVencimiento"
    Me.Dtp_FechaVencimiento.ShowCheckBox = True
    Me.Dtp_FechaVencimiento.Size = New System.Drawing.Size(116, 20)
    Me.Dtp_FechaVencimiento.TabIndex = 6
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(342, 134)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(101, 13)
    Me.Label10.TabIndex = 15
    Me.Label10.Text = "Fecha Vencimiento:"
    '
    'Tx_Concepto
    '
    Me.Tx_Concepto.Location = New System.Drawing.Point(110, 85)
    Me.Tx_Concepto.MaxLength = 200
    Me.Tx_Concepto.Multiline = True
    Me.Tx_Concepto.Name = "Tx_Concepto"
    Me.Tx_Concepto.Size = New System.Drawing.Size(455, 40)
    Me.Tx_Concepto.TabIndex = 3
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(51, 88)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(56, 13)
    Me.Label7.TabIndex = 11
    Me.Label7.Text = "Concepto:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(60, 62)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(47, 13)
    Me.Label2.TabIndex = 10
    Me.Label2.Text = "Nombre:"
    '
    'Dtp_Fecha
    '
    Me.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.Dtp_Fecha.Location = New System.Drawing.Point(110, 33)
    Me.Dtp_Fecha.Name = "Dtp_Fecha"
    Me.Dtp_Fecha.ShowCheckBox = True
    Me.Dtp_Fecha.Size = New System.Drawing.Size(116, 20)
    Me.Dtp_Fecha.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(67, 36)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 13)
    Me.Label1.TabIndex = 9
    Me.Label1.Text = "Fecha:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(35, 160)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(72, 13)
    Me.Label4.TabIndex = 13
    Me.Label4.Text = "Responsable:"
    '
    'Tx_IvaAsumido
    '
    Me.Tx_IvaAsumido.Location = New System.Drawing.Point(231, 131)
    Me.Tx_IvaAsumido.MaxLength = 200
    Me.Tx_IvaAsumido.Name = "Tx_IvaAsumido"
    Me.Tx_IvaAsumido.Size = New System.Drawing.Size(105, 20)
    Me.Tx_IvaAsumido.TabIndex = 5
    Me.Tx_IvaAsumido.Text = "0"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(200, 134)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(25, 13)
    Me.Label3.TabIndex = 14
    Me.Label3.Text = "Iva:"
    '
    'Cu_AsociarPersonaBodega2
    '
    Me.Cu_AsociarPersonaBodega2.componenteasociado = "Cu_BuscarPersonaResponsable"
    Me.Cu_AsociarPersonaBodega2.CrearUsuario = False
    Me.Cu_AsociarPersonaBodega2.Location = New System.Drawing.Point(537, 157)
    Me.Cu_AsociarPersonaBodega2.Name = "Cu_AsociarPersonaBodega2"
    Me.Cu_AsociarPersonaBodega2.Size = New System.Drawing.Size(27, 23)
    Me.Cu_AsociarPersonaBodega2.TabIndex = 10
    Me.Cu_AsociarPersonaBodega2.TipoAsociacion = "DEP"
    '
    'Cu_AsociarPersonaBodega1
    '
    Me.Cu_AsociarPersonaBodega1.componenteasociado = "Cu_BuscarPersonaNombre"
    Me.Cu_AsociarPersonaBodega1.CrearUsuario = False
    Me.Cu_AsociarPersonaBodega1.Location = New System.Drawing.Point(537, 58)
    Me.Cu_AsociarPersonaBodega1.Name = "Cu_AsociarPersonaBodega1"
    Me.Cu_AsociarPersonaBodega1.Size = New System.Drawing.Size(27, 23)
    Me.Cu_AsociarPersonaBodega1.TabIndex = 2
    Me.Cu_AsociarPersonaBodega1.TipoAsociacion = "DEP"
    '
    'Cu_BuscarPersonaNombre
    '
    Me.Cu_BuscarPersonaNombre.FechaReporteDiario = New Date(CType(0, Long))
    Me.Cu_BuscarPersonaNombre.Location = New System.Drawing.Point(107, 58)
    Me.Cu_BuscarPersonaNombre.Name = "Cu_BuscarPersonaNombre"
    Me.Cu_BuscarPersonaNombre.Size = New System.Drawing.Size(424, 23)
    Me.Cu_BuscarPersonaNombre.TabIndex = 1
    Me.Cu_BuscarPersonaNombre.Tipo = "PADEP"
    Me.Cu_BuscarPersonaNombre.valorcajatexto = "IDENTIFICACION"
    '
    'Cu_BuscarPersonaResponsable
    '
    Me.Cu_BuscarPersonaResponsable.FechaReporteDiario = New Date(CType(0, Long))
    Me.Cu_BuscarPersonaResponsable.Location = New System.Drawing.Point(108, 157)
    Me.Cu_BuscarPersonaResponsable.Name = "Cu_BuscarPersonaResponsable"
    Me.Cu_BuscarPersonaResponsable.Size = New System.Drawing.Size(423, 23)
    Me.Cu_BuscarPersonaResponsable.TabIndex = 9
    Me.Cu_BuscarPersonaResponsable.Tipo = "PADEP"
    Me.Cu_BuscarPersonaResponsable.valorcajatexto = "IDENTIFICACION"
    '
    'Cu_CentroCosto1
    '
    Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Cu_CentroCosto1.Location = New System.Drawing.Point(110, 183)
    Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
    Me.Cu_CentroCosto1.Size = New System.Drawing.Size(199, 38)
    Me.Cu_CentroCosto1.TabIndex = 16
    '
    'Fr_CuentaCobro
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(574, 255)
    Me.Controls.Add(Me.Cu_CentroCosto1)
    Me.Controls.Add(Me.Cu_AsociarPersonaBodega2)
    Me.Controls.Add(Me.Cu_AsociarPersonaBodega1)
    Me.Controls.Add(Me.Cu_BuscarPersonaNombre)
    Me.Controls.Add(Me.Tx_IvaAsumido)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Cu_BuscarPersonaResponsable)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Tx_ValorDocumento)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.Dtp_FechaVencimiento)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Tx_Concepto)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Dtp_Fecha)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.Label16)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Fr_CuentaCobro"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Cuenta Cobro"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Tx_ValorDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Tx_Concepto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaResponsable As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tx_IvaAsumido As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaNombre As FormulariosClasesBase.Cu_BuscarPersona
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Public WithEvents Lb_Consecutivo As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaBodega1 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaBodega2 As FormulariosClasesBase.Cu_AsociarPersonaBodega
  Friend WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
End Class
