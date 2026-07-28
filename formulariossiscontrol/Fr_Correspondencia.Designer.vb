<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Correspondencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Correspondencia))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tx_Empresa = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarProveedor = New System.Windows.Forms.Button()
        Me.Tx_DirigidoA = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Bt_BuscarPersona = New System.Windows.Forms.Button()
        Me.Tx_Dirección = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tx_Asunto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_CódigoArtículo = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersonaFirma = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaElabora = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_CiudadDirección = New FormulariosClasesBase.Cu_Ciudad()
        Me.Cu_AsociarPersonaBodega1 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaBodega2 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Fecha:"
        '
        'Dtp_Fecha
        '
        Me.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha.Location = New System.Drawing.Point(89, 36)
        Me.Dtp_Fecha.Name = "Dtp_Fecha"
        Me.Dtp_Fecha.ShowCheckBox = True
        Me.Dtp_Fecha.Size = New System.Drawing.Size(116, 20)
        Me.Dtp_Fecha.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Empresa:"
        '
        'Tx_Empresa
        '
        Me.Tx_Empresa.Location = New System.Drawing.Point(89, 62)
        Me.Tx_Empresa.MaxLength = 100
        Me.Tx_Empresa.Name = "Tx_Empresa"
        Me.Tx_Empresa.Size = New System.Drawing.Size(515, 20)
        Me.Tx_Empresa.TabIndex = 1
        '
        'Bt_BuscarProveedor
        '
        Me.Bt_BuscarProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_BuscarProveedor.Location = New System.Drawing.Point(610, 60)
        Me.Bt_BuscarProveedor.Name = "Bt_BuscarProveedor"
        Me.Bt_BuscarProveedor.Size = New System.Drawing.Size(28, 23)
        Me.Bt_BuscarProveedor.TabIndex = 2
        Me.Bt_BuscarProveedor.Text = "..."
        Me.Bt_BuscarProveedor.UseVisualStyleBackColor = True
        '
        'Tx_DirigidoA
        '
        Me.Tx_DirigidoA.Location = New System.Drawing.Point(89, 88)
        Me.Tx_DirigidoA.MaxLength = 100
        Me.Tx_DirigidoA.Name = "Tx_DirigidoA"
        Me.Tx_DirigidoA.Size = New System.Drawing.Size(515, 20)
        Me.Tx_DirigidoA.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Dirigido A:"
        '
        'Bt_BuscarPersona
        '
        Me.Bt_BuscarPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_BuscarPersona.Location = New System.Drawing.Point(610, 86)
        Me.Bt_BuscarPersona.Name = "Bt_BuscarPersona"
        Me.Bt_BuscarPersona.Size = New System.Drawing.Size(28, 23)
        Me.Bt_BuscarPersona.TabIndex = 4
        Me.Bt_BuscarPersona.Text = "..."
        Me.Bt_BuscarPersona.UseVisualStyleBackColor = True
        '
        'Tx_Dirección
        '
        Me.Tx_Dirección.Location = New System.Drawing.Point(89, 114)
        Me.Tx_Dirección.MaxLength = 100
        Me.Tx_Dirección.Name = "Tx_Dirección"
        Me.Tx_Dirección.Size = New System.Drawing.Size(549, 20)
        Me.Tx_Dirección.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Ciudad Envío:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Dirección Envío:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Asunto:"
        '
        'Tx_Asunto
        '
        Me.Tx_Asunto.Location = New System.Drawing.Point(89, 168)
        Me.Tx_Asunto.MaxLength = 150
        Me.Tx_Asunto.Multiline = True
        Me.Tx_Asunto.Name = "Tx_Asunto"
        Me.Tx_Asunto.Size = New System.Drawing.Size(549, 40)
        Me.Tx_Asunto.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 218)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Elaborado por:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 242)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Firmado por:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lb_CódigoArtículo)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 267)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(644, 30)
        Me.Panel1.TabIndex = 14
        '
        'Lb_CódigoArtículo
        '
        Me.Lb_CódigoArtículo.AutoSize = True
        Me.Lb_CódigoArtículo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CódigoArtículo.ForeColor = System.Drawing.Color.Red
        Me.Lb_CódigoArtículo.Location = New System.Drawing.Point(11, 8)
        Me.Lb_CódigoArtículo.Name = "Lb_CódigoArtículo"
        Me.Lb_CódigoArtículo.Size = New System.Drawing.Size(52, 13)
        Me.Lb_CódigoArtículo.TabIndex = 2
        Me.Lb_CódigoArtículo.Text = "Label13"
        Me.Lb_CódigoArtículo.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(451, 4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 15
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(532, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 16
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(644, 30)
        Me.Lb_Titulo.TabIndex = 9
        Me.Lb_Titulo.Text = "TITULO"
        Me.Lb_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cu_BuscarPersonaFirma
        '
        Me.Cu_BuscarPersonaFirma.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaFirma.Location = New System.Drawing.Point(89, 238)
        Me.Cu_BuscarPersonaFirma.Name = "Cu_BuscarPersonaFirma"
        Me.Cu_BuscarPersonaFirma.Size = New System.Drawing.Size(311, 23)
        Me.Cu_BuscarPersonaFirma.TabIndex = 12
        Me.Cu_BuscarPersonaFirma.Tipo = "PADEP"
        Me.Cu_BuscarPersonaFirma.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaElabora
        '
        Me.Cu_BuscarPersonaElabora.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaElabora.Location = New System.Drawing.Point(89, 214)
        Me.Cu_BuscarPersonaElabora.Name = "Cu_BuscarPersonaElabora"
        Me.Cu_BuscarPersonaElabora.Size = New System.Drawing.Size(311, 23)
        Me.Cu_BuscarPersonaElabora.TabIndex = 10
        Me.Cu_BuscarPersonaElabora.Tipo = "PADEP"
        Me.Cu_BuscarPersonaElabora.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_CiudadDirección
        '
        Me.Cu_CiudadDirección.Location = New System.Drawing.Point(89, 140)
        Me.Cu_CiudadDirección.Name = "Cu_CiudadDirección"
        Me.Cu_CiudadDirección.Size = New System.Drawing.Size(266, 23)
        Me.Cu_CiudadDirección.TabIndex = 6
        '
        'Cu_AsociarPersonaBodega1
        '
        Me.Cu_AsociarPersonaBodega1.componenteasociado = "Cu_BuscarPersonaElabora"
        Me.Cu_AsociarPersonaBodega1.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega1.Location = New System.Drawing.Point(406, 214)
        Me.Cu_AsociarPersonaBodega1.Name = "Cu_AsociarPersonaBodega1"
        Me.Cu_AsociarPersonaBodega1.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega1.TabIndex = 11
        Me.Cu_AsociarPersonaBodega1.TipoAsociacion = "DEP"
        '
        'Cu_AsociarPersonaBodega2
        '
        Me.Cu_AsociarPersonaBodega2.componenteasociado = "Cu_BuscarPersonaFirma"
        Me.Cu_AsociarPersonaBodega2.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega2.Location = New System.Drawing.Point(406, 238)
        Me.Cu_AsociarPersonaBodega2.Name = "Cu_AsociarPersonaBodega2"
        Me.Cu_AsociarPersonaBodega2.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega2.TabIndex = 13
        Me.Cu_AsociarPersonaBodega2.TipoAsociacion = "DEP"
        '
        'Cu_CentroCosto1
        '
        Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto1.Location = New System.Drawing.Point(439, 214)
        Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
        Me.Cu_CentroCosto1.Size = New System.Drawing.Size(199, 38)
        Me.Cu_CentroCosto1.TabIndex = 18
        '
        'Fr_Correspondencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 297)
        Me.Controls.Add(Me.Cu_CentroCosto1)
        Me.Controls.Add(Me.Cu_AsociarPersonaBodega2)
        Me.Controls.Add(Me.Cu_AsociarPersonaBodega1)
        Me.Controls.Add(Me.Cu_BuscarPersonaFirma)
        Me.Controls.Add(Me.Cu_BuscarPersonaElabora)
        Me.Controls.Add(Me.Lb_Titulo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Tx_Asunto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Cu_CiudadDirección)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Tx_Dirección)
        Me.Controls.Add(Me.Bt_BuscarPersona)
        Me.Controls.Add(Me.Tx_DirigidoA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Bt_BuscarProveedor)
        Me.Controls.Add(Me.Tx_Empresa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Dtp_Fecha)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_Correspondencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Titulo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tx_Empresa As System.Windows.Forms.TextBox
    Friend WithEvents Bt_BuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Tx_DirigidoA As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Bt_BuscarPersona As System.Windows.Forms.Button
    Friend WithEvents Cu_CiudadDirección As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Tx_Dirección As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Cu_BuscarPersonaElabora As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BuscarPersonaFirma As FormulariosClasesBase.Cu_BuscarPersona
    Public WithEvents Lb_Titulo As System.Windows.Forms.Label
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Public WithEvents Tx_Asunto As System.Windows.Forms.TextBox
    Public WithEvents Lb_CódigoArtículo As System.Windows.Forms.Label
    Public WithEvents Dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cu_AsociarPersonaBodega1 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaBodega2 As FormulariosClasesBase.Cu_AsociarPersonaBodega
  Friend WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
End Class
