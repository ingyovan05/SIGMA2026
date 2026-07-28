<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Visitante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Visitante))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_ConsecutivoVisita = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Bt_BuscarProveedor = New System.Windows.Forms.Button()
        Me.Tx_Proveedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button_Cargar_Foto_Persona = New System.Windows.Forms.Button()
        Me.PictureBox_Foto_Persona = New System.Windows.Forms.PictureBox()
        Me.Tx_Visitante = New System.Windows.Forms.TextBox()
        Me.Tx_Identificacion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tx_EPS = New System.Windows.Forms.TextBox()
        Me.Ck_RevisoVideo = New System.Windows.Forms.CheckBox()
        Me.Ck_AceptoPolitica = New System.Windows.Forms.CheckBox()
        Me.Cu_AsociarPersonaBodega1 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaFuncionario = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tx_Observacion = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox_Foto_Persona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Info
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(732, 30)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "VISITANTE"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lb_ConsecutivoVisita)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 287)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(732, 30)
        Me.Panel1.TabIndex = 15
        '
        'Lb_ConsecutivoVisita
        '
        Me.Lb_ConsecutivoVisita.AutoSize = True
        Me.Lb_ConsecutivoVisita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_ConsecutivoVisita.ForeColor = System.Drawing.Color.Red
        Me.Lb_ConsecutivoVisita.Location = New System.Drawing.Point(11, 8)
        Me.Lb_ConsecutivoVisita.Name = "Lb_ConsecutivoVisita"
        Me.Lb_ConsecutivoVisita.Size = New System.Drawing.Size(52, 13)
        Me.Lb_ConsecutivoVisita.TabIndex = 2
        Me.Lb_ConsecutivoVisita.Text = "Label13"
        Me.Lb_ConsecutivoVisita.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(562, 4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(643, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(2, 67)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Nombre Visitante:"
        '
        'Bt_BuscarProveedor
        '
        Me.Bt_BuscarProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_BuscarProveedor.Location = New System.Drawing.Point(520, 86)
        Me.Bt_BuscarProveedor.Name = "Bt_BuscarProveedor"
        Me.Bt_BuscarProveedor.Size = New System.Drawing.Size(28, 23)
        Me.Bt_BuscarProveedor.TabIndex = 4
        Me.Bt_BuscarProveedor.Text = "..."
        Me.Bt_BuscarProveedor.UseVisualStyleBackColor = True
        '
        'Tx_Proveedor
        '
        Me.Tx_Proveedor.Location = New System.Drawing.Point(94, 89)
        Me.Tx_Proveedor.MaxLength = 200
        Me.Tx_Proveedor.Name = "Tx_Proveedor"
        Me.Tx_Proveedor.Size = New System.Drawing.Size(423, 20)
        Me.Tx_Proveedor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Empresa:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(220, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Dependencia:"
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.Location = New System.Drawing.Point(296, 115)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(221, 21)
        Me.Cb_Dependencia.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Funcionario:"
        '
        'Button_Cargar_Foto_Persona
        '
        Me.Button_Cargar_Foto_Persona.Location = New System.Drawing.Point(595, 162)
        Me.Button_Cargar_Foto_Persona.Name = "Button_Cargar_Foto_Persona"
        Me.Button_Cargar_Foto_Persona.Size = New System.Drawing.Size(100, 23)
        Me.Button_Cargar_Foto_Persona.TabIndex = 11
        Me.Button_Cargar_Foto_Persona.Text = "Tomar Foto"
        Me.Button_Cargar_Foto_Persona.UseVisualStyleBackColor = True
        '
        'PictureBox_Foto_Persona
        '
        Me.PictureBox_Foto_Persona.BackColor = System.Drawing.Color.White
        Me.PictureBox_Foto_Persona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox_Foto_Persona.ErrorImage = CType(resources.GetObject("PictureBox_Foto_Persona.ErrorImage"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.Image = CType(resources.GetObject("PictureBox_Foto_Persona.Image"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.InitialImage = CType(resources.GetObject("PictureBox_Foto_Persona.InitialImage"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.Location = New System.Drawing.Point(564, 36)
        Me.PictureBox_Foto_Persona.Name = "PictureBox_Foto_Persona"
        Me.PictureBox_Foto_Persona.Size = New System.Drawing.Size(160, 120)
        Me.PictureBox_Foto_Persona.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Foto_Persona.TabIndex = 61
        Me.PictureBox_Foto_Persona.TabStop = False
        '
        'Tx_Visitante
        '
        Me.Tx_Visitante.Location = New System.Drawing.Point(94, 64)
        Me.Tx_Visitante.MaxLength = 200
        Me.Tx_Visitante.Name = "Tx_Visitante"
        Me.Tx_Visitante.Size = New System.Drawing.Size(423, 20)
        Me.Tx_Visitante.TabIndex = 2
        '
        'Tx_Identificacion
        '
        Me.Tx_Identificacion.Location = New System.Drawing.Point(94, 39)
        Me.Tx_Identificacion.MaxLength = 15
        Me.Tx_Identificacion.Name = "Tx_Identificacion"
        Me.Tx_Identificacion.Size = New System.Drawing.Size(116, 20)
        Me.Tx_Identificacion.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Identificación:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(52, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "E.P.S.:"
        '
        'Tx_EPS
        '
        Me.Tx_EPS.Location = New System.Drawing.Point(94, 114)
        Me.Tx_EPS.MaxLength = 30
        Me.Tx_EPS.Name = "Tx_EPS"
        Me.Tx_EPS.Size = New System.Drawing.Size(116, 20)
        Me.Tx_EPS.TabIndex = 5
        '
        'Ck_RevisoVideo
        '
        Me.Ck_RevisoVideo.AutoSize = True
        Me.Ck_RevisoVideo.Location = New System.Drawing.Point(93, 241)
        Me.Ck_RevisoVideo.Name = "Ck_RevisoVideo"
        Me.Ck_RevisoVideo.Size = New System.Drawing.Size(227, 17)
        Me.Ck_RevisoVideo.TabIndex = 13
        Me.Ck_RevisoVideo.Text = "Observó el Video de Seguridad del Edificio"
        Me.Ck_RevisoVideo.UseVisualStyleBackColor = True
        '
        'Ck_AceptoPolitica
        '
        Me.Ck_AceptoPolitica.AutoSize = True
        Me.Ck_AceptoPolitica.Location = New System.Drawing.Point(92, 263)
        Me.Ck_AceptoPolitica.Name = "Ck_AceptoPolitica"
        Me.Ck_AceptoPolitica.Size = New System.Drawing.Size(460, 17)
        Me.Ck_AceptoPolitica.TabIndex = 14
        Me.Ck_AceptoPolitica.Text = "Leyó y aceptó la Política de Seguridad y Privacidad de Datos Personales de ISMOCO" & _
    "L S.A."
        Me.Ck_AceptoPolitica.UseVisualStyleBackColor = True
        '
        'Cu_AsociarPersonaBodega1
        '
        Me.Cu_AsociarPersonaBodega1.componenteasociado = "Cu_BuscarPersonaFuncionario"
        Me.Cu_AsociarPersonaBodega1.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega1.Location = New System.Drawing.Point(520, 142)
        Me.Cu_AsociarPersonaBodega1.Name = "Cu_AsociarPersonaBodega1"
        Me.Cu_AsociarPersonaBodega1.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega1.TabIndex = 10
        Me.Cu_AsociarPersonaBodega1.TipoAsociacion = "DEP"
        '
        'Cu_BuscarPersonaFuncionario
        '
        Me.Cu_BuscarPersonaFuncionario.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaFuncionario.Location = New System.Drawing.Point(90, 142)
        Me.Cu_BuscarPersonaFuncionario.Name = "Cu_BuscarPersonaFuncionario"
        Me.Cu_BuscarPersonaFuncionario.Size = New System.Drawing.Size(427, 23)
        Me.Cu_BuscarPersonaFuncionario.TabIndex = 9
        Me.Cu_BuscarPersonaFuncionario.Tipo = "PADEP"
        Me.Cu_BuscarPersonaFuncionario.valorcajatexto = "IDENTIFICACION"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Observaciones:"
        '
        'Tx_Observacion
        '
        Me.Tx_Observacion.Location = New System.Drawing.Point(93, 171)
        Me.Tx_Observacion.MaxLength = 200
        Me.Tx_Observacion.Multiline = True
        Me.Tx_Observacion.Name = "Tx_Observacion"
        Me.Tx_Observacion.Size = New System.Drawing.Size(423, 60)
        Me.Tx_Observacion.TabIndex = 12
        '
        'Fr_Visitante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 317)
        Me.Controls.Add(Me.Tx_Observacion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Ck_AceptoPolitica)
        Me.Controls.Add(Me.Ck_RevisoVideo)
        Me.Controls.Add(Me.Tx_EPS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Cu_AsociarPersonaBodega1)
        Me.Controls.Add(Me.Tx_Identificacion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Tx_Visitante)
        Me.Controls.Add(Me.Button_Cargar_Foto_Persona)
        Me.Controls.Add(Me.PictureBox_Foto_Persona)
        Me.Controls.Add(Me.Cu_BuscarPersonaFuncionario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Cb_Dependencia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Bt_BuscarProveedor)
        Me.Controls.Add(Me.Tx_Proveedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_Visitante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visitante"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox_Foto_Persona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Bt_BuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Tx_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaFuncionario As FormulariosClasesBase.Cu_BuscarPersona
    Public WithEvents Button_Cargar_Foto_Persona As System.Windows.Forms.Button
    Friend WithEvents PictureBox_Foto_Persona As System.Windows.Forms.PictureBox
    Friend WithEvents Tx_Visitante As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Identificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Public WithEvents Lb_ConsecutivoVisita As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaBodega1 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Tx_EPS As System.Windows.Forms.TextBox
    Friend WithEvents Ck_RevisoVideo As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_AceptoPolitica As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tx_Observacion As System.Windows.Forms.TextBox
End Class
