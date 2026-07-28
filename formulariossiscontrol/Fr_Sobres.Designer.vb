<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Sobres
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Sobres))
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Dtp_Fecha = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Lb_CódigoArtículo = New System.Windows.Forms.Label()
    Me.Bt_Guardar = New System.Windows.Forms.Button()
    Me.Bt_Cancelar = New System.Windows.Forms.Button()
    Me.Tb_Descripción = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Cu_BuscarDeFuncionario = New FormulariosClasesBase.Cu_BuscarPersona()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Cb_DeDependencia = New System.Windows.Forms.ComboBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Gb_Despacho = New System.Windows.Forms.GroupBox()
    Me.Btn_AgregarTransportadora = New System.Windows.Forms.Button()
    Me.Dtp_Fechadespacho = New System.Windows.Forms.DateTimePicker()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Tb_Guia = New System.Windows.Forms.TextBox()
    Me.Cb_Empresa = New System.Windows.Forms.ComboBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Tb_Entidad = New System.Windows.Forms.TextBox()
    Me.Cms_Base = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Tb_CargoDe = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Cu_AsociarPersonaBodega1 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.TB_Telefono = New System.Windows.Forms.TextBox()
    Me.Bt_BuscarPersona = New System.Windows.Forms.Button()
    Me.Tx_DirigidoA = New System.Windows.Forms.TextBox()
    Me.Tb_CargoPara = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.Cu_CiudadPara = New FormulariosClasesBase.Cu_Ciudad()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Tb_DirrecionPara = New System.Windows.Forms.TextBox()
    Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
    Me.Panel1.SuspendLayout()
    Me.Gb_Despacho.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(28, 46)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(90, 13)
    Me.Label4.TabIndex = 10
    Me.Label4.Text = "Para Funcionario:"
    '
    'Dtp_Fecha
    '
    Me.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.Dtp_Fecha.Location = New System.Drawing.Point(116, 33)
    Me.Dtp_Fecha.Name = "Dtp_Fecha"
    Me.Dtp_Fecha.ShowCheckBox = True
    Me.Dtp_Fecha.Size = New System.Drawing.Size(116, 20)
    Me.Dtp_Fecha.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(72, 36)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Fecha:"
    '
    'Label9
    '
    Me.Label9.BackColor = System.Drawing.SystemColors.Info
    Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(0, 0)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(672, 30)
    Me.Label9.TabIndex = 0
    Me.Label9.Text = "SOBRES"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.DarkGray
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Controls.Add(Me.Lb_CódigoArtículo)
    Me.Panel1.Controls.Add(Me.Bt_Guardar)
    Me.Panel1.Controls.Add(Me.Bt_Cancelar)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel1.Location = New System.Drawing.Point(0, 431)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(672, 30)
    Me.Panel1.TabIndex = 9
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
    Me.Bt_Guardar.Location = New System.Drawing.Point(519, 3)
    Me.Bt_Guardar.Name = "Bt_Guardar"
    Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
    Me.Bt_Guardar.TabIndex = 0
    Me.Bt_Guardar.Text = "Guardar"
    Me.Bt_Guardar.UseVisualStyleBackColor = True
    '
    'Bt_Cancelar
    '
    Me.Bt_Cancelar.Location = New System.Drawing.Point(600, 2)
    Me.Bt_Cancelar.Name = "Bt_Cancelar"
    Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
    Me.Bt_Cancelar.TabIndex = 1
    Me.Bt_Cancelar.Text = "Cancelar"
    Me.Bt_Cancelar.UseVisualStyleBackColor = True
    '
    'Tb_Descripción
    '
    Me.Tb_Descripción.Location = New System.Drawing.Point(123, 339)
    Me.Tb_Descripción.MaxLength = 200
    Me.Tb_Descripción.Multiline = True
    Me.Tb_Descripción.Name = "Tb_Descripción"
    Me.Tb_Descripción.Size = New System.Drawing.Size(530, 40)
    Me.Tb_Descripción.TabIndex = 6
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(53, 343)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(66, 13)
    Me.Label6.TabIndex = 0
    Me.Label6.Text = "Descripción:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(13, 22)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(106, 13)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "Para Entidad / Base:"
    '
    'Cu_BuscarDeFuncionario
    '
    Me.Cu_BuscarDeFuncionario.FechaReporteDiario = New Date(CType(0, Long))
    Me.Cu_BuscarDeFuncionario.Location = New System.Drawing.Point(140, 95)
    Me.Cu_BuscarDeFuncionario.Name = "Cu_BuscarDeFuncionario"
    Me.Cu_BuscarDeFuncionario.Size = New System.Drawing.Size(457, 23)
    Me.Cu_BuscarDeFuncionario.TabIndex = 1
    Me.Cu_BuscarDeFuncionario.Tipo = "PADEP"
    Me.Cu_BuscarDeFuncionario.valorcajatexto = "IDENTIFICACION"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(55, 98)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(82, 13)
    Me.Label5.TabIndex = 5
    Me.Label5.Text = "De Funcionario:"
    '
    'Cb_DeDependencia
    '
    Me.Cb_DeDependencia.FormattingEnabled = True
    Me.Cb_DeDependencia.Location = New System.Drawing.Point(140, 68)
    Me.Cb_DeDependencia.Name = "Cb_DeDependencia"
    Me.Cb_DeDependencia.Size = New System.Drawing.Size(427, 21)
    Me.Cb_DeDependencia.TabIndex = 0
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(46, 71)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(91, 13)
    Me.Label7.TabIndex = 4
    Me.Label7.Text = "De Dependencia:"
    '
    'Gb_Despacho
    '
    Me.Gb_Despacho.Controls.Add(Me.Btn_AgregarTransportadora)
    Me.Gb_Despacho.Controls.Add(Me.Dtp_Fechadespacho)
    Me.Gb_Despacho.Controls.Add(Me.Label11)
    Me.Gb_Despacho.Controls.Add(Me.Tb_Guia)
    Me.Gb_Despacho.Controls.Add(Me.Cb_Empresa)
    Me.Gb_Despacho.Controls.Add(Me.Label10)
    Me.Gb_Despacho.Controls.Add(Me.Label8)
    Me.Gb_Despacho.Location = New System.Drawing.Point(11, 380)
    Me.Gb_Despacho.Name = "Gb_Despacho"
    Me.Gb_Despacho.Size = New System.Drawing.Size(640, 44)
    Me.Gb_Despacho.TabIndex = 7
    Me.Gb_Despacho.TabStop = False
    Me.Gb_Despacho.Text = "Despacho"
    '
    'Btn_AgregarTransportadora
    '
    Me.Btn_AgregarTransportadora.Location = New System.Drawing.Point(274, 15)
    Me.Btn_AgregarTransportadora.Name = "Btn_AgregarTransportadora"
    Me.Btn_AgregarTransportadora.Size = New System.Drawing.Size(24, 23)
    Me.Btn_AgregarTransportadora.TabIndex = 1
    Me.Btn_AgregarTransportadora.Text = "+"
    Me.Btn_AgregarTransportadora.UseVisualStyleBackColor = True
    '
    'Dtp_Fechadespacho
    '
    Me.Dtp_Fechadespacho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.Dtp_Fechadespacho.Location = New System.Drawing.Point(509, 17)
    Me.Dtp_Fechadespacho.Name = "Dtp_Fechadespacho"
    Me.Dtp_Fechadespacho.ShowCheckBox = True
    Me.Dtp_Fechadespacho.Size = New System.Drawing.Size(125, 20)
    Me.Dtp_Fechadespacho.TabIndex = 3
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(465, 20)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(40, 13)
    Me.Label11.TabIndex = 6
    Me.Label11.Text = "Fecha:"
    '
    'Tb_Guia
    '
    Me.Tb_Guia.Location = New System.Drawing.Point(342, 17)
    Me.Tb_Guia.Name = "Tb_Guia"
    Me.Tb_Guia.Size = New System.Drawing.Size(118, 20)
    Me.Tb_Guia.TabIndex = 2
    '
    'Cb_Empresa
    '
    Me.Cb_Empresa.FormattingEnabled = True
    Me.Cb_Empresa.Location = New System.Drawing.Point(63, 17)
    Me.Cb_Empresa.Name = "Cb_Empresa"
    Me.Cb_Empresa.Size = New System.Drawing.Size(204, 21)
    Me.Cb_Empresa.TabIndex = 0
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(304, 21)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(32, 13)
    Me.Label10.TabIndex = 5
    Me.Label10.Text = "Guia:"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(9, 21)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(51, 13)
    Me.Label8.TabIndex = 4
    Me.Label8.Text = "Empresa:"
    '
    'Tb_Entidad
    '
    Me.Tb_Entidad.ContextMenuStrip = Me.Cms_Base
    Me.Tb_Entidad.Location = New System.Drawing.Point(122, 19)
    Me.Tb_Entidad.MaxLength = 100
    Me.Tb_Entidad.Name = "Tb_Entidad"
    Me.Tb_Entidad.Size = New System.Drawing.Size(470, 20)
    Me.Tb_Entidad.TabIndex = 0
    '
    'Cms_Base
    '
    Me.Cms_Base.Name = "Cms_Base"
    Me.Cms_Base.Size = New System.Drawing.Size(61, 4)
    '
    'GroupBox1
    '
    Me.GroupBox1.Location = New System.Drawing.Point(7, 52)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(648, 98)
    Me.GroupBox1.TabIndex = 3
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "De:"
    '
    'Tb_CargoDe
    '
    Me.Tb_CargoDe.Location = New System.Drawing.Point(141, 124)
    Me.Tb_CargoDe.MaxLength = 100
    Me.Tb_CargoDe.Name = "Tb_CargoDe"
    Me.Tb_CargoDe.Size = New System.Drawing.Size(286, 20)
    Me.Tb_CargoDe.TabIndex = 3
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Location = New System.Drawing.Point(94, 127)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(38, 13)
    Me.Label17.TabIndex = 6
    Me.Label17.Text = "Cargo:"
    '
    'Cu_AsociarPersonaBodega1
    '
    Me.Cu_AsociarPersonaBodega1.componenteasociado = "Cu_BuscarDeFuncionario"
    Me.Cu_AsociarPersonaBodega1.CrearUsuario = False
    Me.Cu_AsociarPersonaBodega1.Location = New System.Drawing.Point(604, 95)
    Me.Cu_AsociarPersonaBodega1.Name = "Cu_AsociarPersonaBodega1"
    Me.Cu_AsociarPersonaBodega1.Size = New System.Drawing.Size(27, 23)
    Me.Cu_AsociarPersonaBodega1.TabIndex = 2
    Me.Cu_AsociarPersonaBodega1.TipoAsociacion = "DEP"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.Cu_CentroCosto1)
    Me.GroupBox2.Controls.Add(Me.Label19)
    Me.GroupBox2.Controls.Add(Me.TB_Telefono)
    Me.GroupBox2.Controls.Add(Me.Bt_BuscarPersona)
    Me.GroupBox2.Controls.Add(Me.Tx_DirigidoA)
    Me.GroupBox2.Controls.Add(Me.Tb_CargoPara)
    Me.GroupBox2.Controls.Add(Me.Label16)
    Me.GroupBox2.Controls.Add(Me.Label15)
    Me.GroupBox2.Controls.Add(Me.Cu_CiudadPara)
    Me.GroupBox2.Controls.Add(Me.Label14)
    Me.GroupBox2.Controls.Add(Me.Tb_DirrecionPara)
    Me.GroupBox2.Controls.Add(Me.Label4)
    Me.GroupBox2.Controls.Add(Me.Tb_Entidad)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Location = New System.Drawing.Point(8, 154)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(648, 179)
    Me.GroupBox2.TabIndex = 5
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Para:"
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Location = New System.Drawing.Point(69, 152)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(52, 13)
    Me.Label19.TabIndex = 14
    Me.Label19.Text = "Telefono:"
    '
    'TB_Telefono
    '
    Me.TB_Telefono.Location = New System.Drawing.Point(125, 150)
    Me.TB_Telefono.MaxLength = 25
    Me.TB_Telefono.Name = "TB_Telefono"
    Me.TB_Telefono.Size = New System.Drawing.Size(158, 20)
    Me.TB_Telefono.TabIndex = 6
    '
    'Bt_BuscarPersona
    '
    Me.Bt_BuscarPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Bt_BuscarPersona.Location = New System.Drawing.Point(599, 43)
    Me.Bt_BuscarPersona.Name = "Bt_BuscarPersona"
    Me.Bt_BuscarPersona.Size = New System.Drawing.Size(28, 23)
    Me.Bt_BuscarPersona.TabIndex = 2
    Me.Bt_BuscarPersona.Text = "..."
    Me.Bt_BuscarPersona.UseVisualStyleBackColor = True
    '
    'Tx_DirigidoA
    '
    Me.Tx_DirigidoA.Location = New System.Drawing.Point(125, 44)
    Me.Tx_DirigidoA.MaxLength = 100
    Me.Tx_DirigidoA.Name = "Tx_DirigidoA"
    Me.Tx_DirigidoA.Size = New System.Drawing.Size(467, 20)
    Me.Tx_DirigidoA.TabIndex = 1
    '
    'Tb_CargoPara
    '
    Me.Tb_CargoPara.Location = New System.Drawing.Point(124, 70)
    Me.Tb_CargoPara.MaxLength = 100
    Me.Tb_CargoPara.Name = "Tb_CargoPara"
    Me.Tb_CargoPara.Size = New System.Drawing.Size(286, 20)
    Me.Tb_CargoPara.TabIndex = 3
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(79, 75)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(38, 13)
    Me.Label16.TabIndex = 11
    Me.Label16.Text = "Cargo:"
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(74, 101)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(43, 13)
    Me.Label15.TabIndex = 12
    Me.Label15.Text = "Ciudad:"
    '
    'Cu_CiudadPara
    '
    Me.Cu_CiudadPara.Location = New System.Drawing.Point(124, 97)
    Me.Cu_CiudadPara.Name = "Cu_CiudadPara"
    Me.Cu_CiudadPara.Size = New System.Drawing.Size(286, 23)
    Me.Cu_CiudadPara.TabIndex = 4
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(68, 127)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(52, 13)
    Me.Label14.TabIndex = 13
    Me.Label14.Text = "Dirreción:"
    '
    'Tb_DirrecionPara
    '
    Me.Tb_DirrecionPara.Location = New System.Drawing.Point(125, 127)
    Me.Tb_DirrecionPara.MaxLength = 200
    Me.Tb_DirrecionPara.Name = "Tb_DirrecionPara"
    Me.Tb_DirrecionPara.Size = New System.Drawing.Size(287, 20)
    Me.Tb_DirrecionPara.TabIndex = 5
    '
    'Cu_CentroCosto1
    '
    Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Cu_CentroCosto1.Location = New System.Drawing.Point(428, 127)
    Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
    Me.Cu_CentroCosto1.Size = New System.Drawing.Size(209, 38)
    Me.Cu_CentroCosto1.TabIndex = 15
    '
    'Fr_Sobres
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(672, 461)
    Me.Controls.Add(Me.Tb_CargoDe)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.Cu_AsociarPersonaBodega1)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Cb_DeDependencia)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Cu_BuscarDeFuncionario)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Gb_Despacho)
    Me.Controls.Add(Me.Tb_Descripción)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.Dtp_Fecha)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Fr_Sobres"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Sobres"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.Gb_Despacho.ResumeLayout(False)
    Me.Gb_Despacho.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Tb_Descripción As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarDeFuncionario As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cb_DeDependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Gb_Despacho As System.Windows.Forms.GroupBox
    Friend WithEvents Dtp_Fechadespacho As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Tb_Guia As System.Windows.Forms.TextBox
    Friend WithEvents Cb_Empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Btn_AgregarTransportadora As System.Windows.Forms.Button
    Friend WithEvents Tb_Entidad As System.Windows.Forms.TextBox
    Friend WithEvents Cms_Base As System.Windows.Forms.ContextMenuStrip
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Cu_CiudadPara As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Tb_DirrecionPara As System.Windows.Forms.TextBox
    Public WithEvents Lb_CódigoArtículo As System.Windows.Forms.Label
    Friend WithEvents Cu_AsociarPersonaBodega1 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Tb_CargoDe As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Tb_CargoPara As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Bt_BuscarPersona As System.Windows.Forms.Button
    Friend WithEvents Tx_DirigidoA As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents TB_Telefono As System.Windows.Forms.TextBox
  Friend WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
End Class
