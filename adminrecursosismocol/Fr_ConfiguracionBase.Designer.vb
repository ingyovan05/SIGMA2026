<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ConfiguracionBase
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
        Me.Lb_TextoCiudadContratacion = New System.Windows.Forms.Label()
        Me.Lb_TextoMedicoBase = New System.Windows.Forms.Label()
        Me.Tx_LugarEntregaDotacion = New System.Windows.Forms.TextBox()
        Me.Lb_TextoLugarEntregaDotacion = New System.Windows.Forms.Label()
        Me.Lb_TextoJefePersonal = New System.Windows.Forms.Label()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Cu_CiudadContratacion = New FormulariosClasesBase.Cu_Ciudad()
        Me.Cu_BPMedicoBase = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BPJefePersonal = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_TextoCoordinadorHSE = New System.Windows.Forms.Label()
        Me.Cu_BPCoordinadorHSE = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_TextoCodigoContrato = New System.Windows.Forms.Label()
        Me.Tx_CodigoContrato = New System.Windows.Forms.TextBox()
        Me.Cu_CentroCostoBase = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Pn_Contenido = New System.Windows.Forms.Panel()
        Me.Lb_TextoCoordinadorQAQC = New System.Windows.Forms.Label()
        Me.Cu_BPCoordinadorQAQC = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_APB_CoordinadorQAQC = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_ABP_CoordinadorHSE = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_APBMedicoBase = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Lb_TextoResidente = New System.Windows.Forms.Label()
        Me.Cu_BPResidente = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_APB_Residente = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_APB_JefePersonal = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Lb_TextoAdministrador = New System.Windows.Forms.Label()
        Me.Cu_BPAdministrador = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_APB_Administrador = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TextoJefeBodega = New System.Windows.Forms.Label()
        Me.Cu_BPJefeBodega = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_APB_JefeBodega = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Pn_Contenido.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lb_TextoCiudadContratacion
        '
        Me.Lb_TextoCiudadContratacion.AutoSize = True
        Me.Lb_TextoCiudadContratacion.Location = New System.Drawing.Point(22, 52)
        Me.Lb_TextoCiudadContratacion.Name = "Lb_TextoCiudadContratacion"
        Me.Lb_TextoCiudadContratacion.Size = New System.Drawing.Size(115, 13)
        Me.Lb_TextoCiudadContratacion.TabIndex = 3
        Me.Lb_TextoCiudadContratacion.Text = "Lugar de Contratación:"
        '
        'Lb_TextoMedicoBase
        '
        Me.Lb_TextoMedicoBase.AutoSize = True
        Me.Lb_TextoMedicoBase.Location = New System.Drawing.Point(39, 139)
        Me.Lb_TextoMedicoBase.Name = "Lb_TextoMedicoBase"
        Me.Lb_TextoMedicoBase.Size = New System.Drawing.Size(98, 13)
        Me.Lb_TextoMedicoBase.TabIndex = 11
        Me.Lb_TextoMedicoBase.Text = "Médico de la Base:"
        '
        'Tx_LugarEntregaDotacion
        '
        Me.Tx_LugarEntregaDotacion.Location = New System.Drawing.Point(140, 280)
        Me.Tx_LugarEntregaDotacion.MaxLength = 100
        Me.Tx_LugarEntregaDotacion.Multiline = True
        Me.Tx_LugarEntregaDotacion.Name = "Tx_LugarEntregaDotacion"
        Me.Tx_LugarEntregaDotacion.Size = New System.Drawing.Size(529, 44)
        Me.Tx_LugarEntregaDotacion.TabIndex = 27
        '
        'Lb_TextoLugarEntregaDotacion
        '
        Me.Lb_TextoLugarEntregaDotacion.AutoSize = True
        Me.Lb_TextoLugarEntregaDotacion.Location = New System.Drawing.Point(15, 283)
        Me.Lb_TextoLugarEntregaDotacion.Name = "Lb_TextoLugarEntregaDotacion"
        Me.Lb_TextoLugarEntregaDotacion.Size = New System.Drawing.Size(122, 13)
        Me.Lb_TextoLugarEntregaDotacion.TabIndex = 26
        Me.Lb_TextoLugarEntregaDotacion.Text = "Lugar entrega Dotación:"
        '
        'Lb_TextoJefePersonal
        '
        Me.Lb_TextoJefePersonal.AutoSize = True
        Me.Lb_TextoJefePersonal.Location = New System.Drawing.Point(48, 197)
        Me.Lb_TextoJefePersonal.Name = "Lb_TextoJefePersonal"
        Me.Lb_TextoJefePersonal.Size = New System.Drawing.Size(89, 13)
        Me.Lb_TextoJefePersonal.TabIndex = 17
        Me.Lb_TextoJefePersonal.Text = "Jefe de Personal:"
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(606, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cerrar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(525, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Cu_CiudadContratacion
        '
        Me.Cu_CiudadContratacion.Location = New System.Drawing.Point(138, 48)
        Me.Cu_CiudadContratacion.Name = "Cu_CiudadContratacion"
        Me.Cu_CiudadContratacion.Size = New System.Drawing.Size(325, 23)
        Me.Cu_CiudadContratacion.TabIndex = 4
        '
        'Cu_BPMedicoBase
        '
        Me.Cu_BPMedicoBase.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BPMedicoBase.Location = New System.Drawing.Point(138, 135)
        Me.Cu_BPMedicoBase.Name = "Cu_BPMedicoBase"
        Me.Cu_BPMedicoBase.Size = New System.Drawing.Size(506, 23)
        Me.Cu_BPMedicoBase.TabIndex = 12
        Me.Cu_BPMedicoBase.Tipo = "PADEP"
        Me.Cu_BPMedicoBase.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BPJefePersonal
        '
        Me.Cu_BPJefePersonal.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BPJefePersonal.Location = New System.Drawing.Point(138, 193)
        Me.Cu_BPJefePersonal.Name = "Cu_BPJefePersonal"
        Me.Cu_BPJefePersonal.Size = New System.Drawing.Size(506, 23)
        Me.Cu_BPJefePersonal.TabIndex = 18
        Me.Cu_BPJefePersonal.Tipo = "PADEP"
        Me.Cu_BPJefePersonal.valorcajatexto = "IDENTIFICACION"
        '
        'Lb_TextoCoordinadorHSE
        '
        Me.Lb_TextoCoordinadorHSE.AutoSize = True
        Me.Lb_TextoCoordinadorHSE.Location = New System.Drawing.Point(45, 110)
        Me.Lb_TextoCoordinadorHSE.Name = "Lb_TextoCoordinadorHSE"
        Me.Lb_TextoCoordinadorHSE.Size = New System.Drawing.Size(92, 13)
        Me.Lb_TextoCoordinadorHSE.TabIndex = 8
        Me.Lb_TextoCoordinadorHSE.Text = "Coordinador HSE:"
        '
        'Cu_BPCoordinadorHSE
        '
        Me.Cu_BPCoordinadorHSE.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BPCoordinadorHSE.Location = New System.Drawing.Point(138, 106)
        Me.Cu_BPCoordinadorHSE.Name = "Cu_BPCoordinadorHSE"
        Me.Cu_BPCoordinadorHSE.Size = New System.Drawing.Size(506, 23)
        Me.Cu_BPCoordinadorHSE.TabIndex = 9
        Me.Cu_BPCoordinadorHSE.Tipo = "PADEP"
        Me.Cu_BPCoordinadorHSE.valorcajatexto = "IDENTIFICACION"
        '
        'Lb_TextoCodigoContrato
        '
        Me.Lb_TextoCodigoContrato.AutoSize = True
        Me.Lb_TextoCodigoContrato.Location = New System.Drawing.Point(34, 13)
        Me.Lb_TextoCodigoContrato.Name = "Lb_TextoCodigoContrato"
        Me.Lb_TextoCodigoContrato.Size = New System.Drawing.Size(103, 13)
        Me.Lb_TextoCodigoContrato.TabIndex = 0
        Me.Lb_TextoCodigoContrato.Text = "Código del Contrato:"
        '
        'Tx_CodigoContrato
        '
        Me.Tx_CodigoContrato.Location = New System.Drawing.Point(140, 10)
        Me.Tx_CodigoContrato.MaxLength = 50
        Me.Tx_CodigoContrato.Multiline = True
        Me.Tx_CodigoContrato.Name = "Tx_CodigoContrato"
        Me.Tx_CodigoContrato.Size = New System.Drawing.Size(320, 32)
        Me.Tx_CodigoContrato.TabIndex = 1
        '
        'Cu_CentroCostoBase
        '
        Me.Cu_CentroCostoBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCostoBase.Location = New System.Drawing.Point(470, 10)
        Me.Cu_CentroCostoBase.Name = "Cu_CentroCostoBase"
        Me.Cu_CentroCostoBase.Size = New System.Drawing.Size(199, 38)
        Me.Cu_CentroCostoBase.TabIndex = 2
        Me.Cu_CentroCostoBase.Visible = False
        '
        'Pn_Contenido
        '
        Me.Pn_Contenido.Controls.Add(Me.Lb_TextoJefeBodega)
        Me.Pn_Contenido.Controls.Add(Me.Cu_BPJefeBodega)
        Me.Pn_Contenido.Controls.Add(Me.Cu_APB_JefeBodega)
        Me.Pn_Contenido.Controls.Add(Me.Lb_TextoCodigoContrato)
        Me.Pn_Contenido.Controls.Add(Me.Tx_CodigoContrato)
        Me.Pn_Contenido.Controls.Add(Me.Cu_CentroCostoBase)
        Me.Pn_Contenido.Controls.Add(Me.Lb_TextoCiudadContratacion)
        Me.Pn_Contenido.Controls.Add(Me.Cu_CiudadContratacion)
        Me.Pn_Contenido.Controls.Add(Me.Lb_TextoCoordinadorQAQC)
        Me.Pn_Contenido.Controls.Add(Me.Cu_BPCoordinadorQAQC)
        Me.Pn_Contenido.Controls.Add(Me.Cu_APB_CoordinadorQAQC)
        Me.Pn_Contenido.Controls.Add(Me.Lb_TextoCoordinadorHSE)
        Me.Pn_Contenido.Controls.Add(Me.Cu_BPCoordinadorHSE)
        Me.Pn_Contenido.Controls.Add(Me.Cu_ABP_CoordinadorHSE)
        Me.Pn_Contenido.Controls.Add(Me.Lb_TextoMedicoBase)
        Me.Pn_Contenido.Controls.Add(Me.Cu_BPMedicoBase)
        Me.Pn_Contenido.Controls.Add(Me.Cu_APBMedicoBase)
        Me.Pn_Contenido.Controls.Add(Me.Lb_TextoResidente)
        Me.Pn_Contenido.Controls.Add(Me.Cu_BPResidente)
        Me.Pn_Contenido.Controls.Add(Me.Cu_APB_Residente)
        Me.Pn_Contenido.Controls.Add(Me.Lb_TextoJefePersonal)
        Me.Pn_Contenido.Controls.Add(Me.Cu_BPJefePersonal)
        Me.Pn_Contenido.Controls.Add(Me.Cu_APB_JefePersonal)
        Me.Pn_Contenido.Controls.Add(Me.Lb_TextoAdministrador)
        Me.Pn_Contenido.Controls.Add(Me.Cu_BPAdministrador)
        Me.Pn_Contenido.Controls.Add(Me.Cu_APB_Administrador)
        Me.Pn_Contenido.Controls.Add(Me.Lb_TextoLugarEntregaDotacion)
        Me.Pn_Contenido.Controls.Add(Me.Tx_LugarEntregaDotacion)
        Me.Pn_Contenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Contenido.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Contenido.Name = "Pn_Contenido"
        Me.Pn_Contenido.Size = New System.Drawing.Size(684, 337)
        Me.Pn_Contenido.TabIndex = 0
        '
        'Lb_TextoCoordinadorQAQC
        '
        Me.Lb_TextoCoordinadorQAQC.AutoSize = True
        Me.Lb_TextoCoordinadorQAQC.Location = New System.Drawing.Point(37, 81)
        Me.Lb_TextoCoordinadorQAQC.Name = "Lb_TextoCoordinadorQAQC"
        Me.Lb_TextoCoordinadorQAQC.Size = New System.Drawing.Size(100, 13)
        Me.Lb_TextoCoordinadorQAQC.TabIndex = 5
        Me.Lb_TextoCoordinadorQAQC.Text = "Coordinador QAQC:"
        '
        'Cu_BPCoordinadorQAQC
        '
        Me.Cu_BPCoordinadorQAQC.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BPCoordinadorQAQC.Location = New System.Drawing.Point(138, 77)
        Me.Cu_BPCoordinadorQAQC.Name = "Cu_BPCoordinadorQAQC"
        Me.Cu_BPCoordinadorQAQC.Size = New System.Drawing.Size(506, 23)
        Me.Cu_BPCoordinadorQAQC.TabIndex = 6
        Me.Cu_BPCoordinadorQAQC.Tipo = "PADEP"
        Me.Cu_BPCoordinadorQAQC.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_APB_CoordinadorQAQC
        '
        Me.Cu_APB_CoordinadorQAQC.componenteasociado = "Cu_BPCoordinadorQAQC"
        Me.Cu_APB_CoordinadorQAQC.CrearUsuario = False
        Me.Cu_APB_CoordinadorQAQC.Location = New System.Drawing.Point(643, 78)
        Me.Cu_APB_CoordinadorQAQC.Name = "Cu_APB_CoordinadorQAQC"
        Me.Cu_APB_CoordinadorQAQC.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_CoordinadorQAQC.TabIndex = 7
        Me.Cu_APB_CoordinadorQAQC.TipoAsociacion = "DEP"
        Me.Cu_APB_CoordinadorQAQC.TipoBúsqueda = "P"
        '
        'Cu_ABP_CoordinadorHSE
        '
        Me.Cu_ABP_CoordinadorHSE.componenteasociado = "Cu_BPCoordinadorHSE"
        Me.Cu_ABP_CoordinadorHSE.CrearUsuario = False
        Me.Cu_ABP_CoordinadorHSE.Location = New System.Drawing.Point(643, 107)
        Me.Cu_ABP_CoordinadorHSE.Name = "Cu_ABP_CoordinadorHSE"
        Me.Cu_ABP_CoordinadorHSE.Size = New System.Drawing.Size(27, 23)
        Me.Cu_ABP_CoordinadorHSE.TabIndex = 10
        Me.Cu_ABP_CoordinadorHSE.TipoAsociacion = "DEP"
        Me.Cu_ABP_CoordinadorHSE.TipoBúsqueda = "P"
        '
        'Cu_APBMedicoBase
        '
        Me.Cu_APBMedicoBase.componenteasociado = "Cu_BPMedicoBase"
        Me.Cu_APBMedicoBase.CrearUsuario = False
        Me.Cu_APBMedicoBase.Location = New System.Drawing.Point(643, 136)
        Me.Cu_APBMedicoBase.Name = "Cu_APBMedicoBase"
        Me.Cu_APBMedicoBase.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APBMedicoBase.TabIndex = 13
        Me.Cu_APBMedicoBase.TipoAsociacion = "DEP"
        Me.Cu_APBMedicoBase.TipoBúsqueda = "P"
        '
        'Lb_TextoResidente
        '
        Me.Lb_TextoResidente.AutoSize = True
        Me.Lb_TextoResidente.Location = New System.Drawing.Point(79, 168)
        Me.Lb_TextoResidente.Name = "Lb_TextoResidente"
        Me.Lb_TextoResidente.Size = New System.Drawing.Size(58, 13)
        Me.Lb_TextoResidente.TabIndex = 14
        Me.Lb_TextoResidente.Text = "Residente:"
        '
        'Cu_BPResidente
        '
        Me.Cu_BPResidente.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BPResidente.Location = New System.Drawing.Point(138, 164)
        Me.Cu_BPResidente.Name = "Cu_BPResidente"
        Me.Cu_BPResidente.Size = New System.Drawing.Size(506, 23)
        Me.Cu_BPResidente.TabIndex = 15
        Me.Cu_BPResidente.Tipo = "PADEP"
        Me.Cu_BPResidente.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_APB_Residente
        '
        Me.Cu_APB_Residente.componenteasociado = "Cu_BPResidente"
        Me.Cu_APB_Residente.CrearUsuario = False
        Me.Cu_APB_Residente.Location = New System.Drawing.Point(643, 165)
        Me.Cu_APB_Residente.Name = "Cu_APB_Residente"
        Me.Cu_APB_Residente.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_Residente.TabIndex = 16
        Me.Cu_APB_Residente.TipoAsociacion = "DEP"
        Me.Cu_APB_Residente.TipoBúsqueda = "P"
        '
        'Cu_APB_JefePersonal
        '
        Me.Cu_APB_JefePersonal.componenteasociado = "Cu_BPJefePersonal"
        Me.Cu_APB_JefePersonal.CrearUsuario = False
        Me.Cu_APB_JefePersonal.Location = New System.Drawing.Point(643, 194)
        Me.Cu_APB_JefePersonal.Name = "Cu_APB_JefePersonal"
        Me.Cu_APB_JefePersonal.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_JefePersonal.TabIndex = 19
        Me.Cu_APB_JefePersonal.TipoAsociacion = "DEP"
        Me.Cu_APB_JefePersonal.TipoBúsqueda = "P"
        '
        'Lb_TextoAdministrador
        '
        Me.Lb_TextoAdministrador.AutoSize = True
        Me.Lb_TextoAdministrador.Location = New System.Drawing.Point(64, 226)
        Me.Lb_TextoAdministrador.Name = "Lb_TextoAdministrador"
        Me.Lb_TextoAdministrador.Size = New System.Drawing.Size(73, 13)
        Me.Lb_TextoAdministrador.TabIndex = 20
        Me.Lb_TextoAdministrador.Text = "Administrador:"
        '
        'Cu_BPAdministrador
        '
        Me.Cu_BPAdministrador.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BPAdministrador.Location = New System.Drawing.Point(138, 222)
        Me.Cu_BPAdministrador.Name = "Cu_BPAdministrador"
        Me.Cu_BPAdministrador.Size = New System.Drawing.Size(506, 23)
        Me.Cu_BPAdministrador.TabIndex = 21
        Me.Cu_BPAdministrador.Tipo = "PADEP"
        Me.Cu_BPAdministrador.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_APB_Administrador
        '
        Me.Cu_APB_Administrador.componenteasociado = "Cu_BPAdministrador"
        Me.Cu_APB_Administrador.CrearUsuario = False
        Me.Cu_APB_Administrador.Location = New System.Drawing.Point(643, 223)
        Me.Cu_APB_Administrador.Name = "Cu_APB_Administrador"
        Me.Cu_APB_Administrador.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_Administrador.TabIndex = 22
        Me.Cu_APB_Administrador.TipoAsociacion = "DEP"
        Me.Cu_APB_Administrador.TipoBúsqueda = "P"
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 337)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(684, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Lb_TextoJefeBodega
        '
        Me.Lb_TextoJefeBodega.AutoSize = True
        Me.Lb_TextoJefeBodega.Location = New System.Drawing.Point(52, 255)
        Me.Lb_TextoJefeBodega.Name = "Lb_TextoJefeBodega"
        Me.Lb_TextoJefeBodega.Size = New System.Drawing.Size(85, 13)
        Me.Lb_TextoJefeBodega.TabIndex = 23
        Me.Lb_TextoJefeBodega.Text = "Jefe de Bodega:"
        '
        'Cu_BPJefeBodega
        '
        Me.Cu_BPJefeBodega.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BPJefeBodega.Location = New System.Drawing.Point(138, 251)
        Me.Cu_BPJefeBodega.Name = "Cu_BPJefeBodega"
        Me.Cu_BPJefeBodega.Size = New System.Drawing.Size(506, 23)
        Me.Cu_BPJefeBodega.TabIndex = 24
        Me.Cu_BPJefeBodega.Tipo = "PUABO"
        Me.Cu_BPJefeBodega.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_APB_JefeBodega
        '
        Me.Cu_APB_JefeBodega.componenteasociado = "Cu_BPJefeBodega"
        Me.Cu_APB_JefeBodega.CrearUsuario = False
        Me.Cu_APB_JefeBodega.Location = New System.Drawing.Point(643, 252)
        Me.Cu_APB_JefeBodega.Name = "Cu_APB_JefeBodega"
        Me.Cu_APB_JefeBodega.Size = New System.Drawing.Size(27, 23)
        Me.Cu_APB_JefeBodega.TabIndex = 25
        Me.Cu_APB_JefeBodega.TipoAsociacion = "BOD"
        Me.Cu_APB_JefeBodega.TipoBúsqueda = "P"
        '
        'Fr_ConfiguracionBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 367)
        Me.Controls.Add(Me.Pn_Contenido)
        Me.Controls.Add(Me.Flp_Botones)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_ConfiguracionBase"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configurar Base"
        Me.Pn_Contenido.ResumeLayout(False)
        Me.Pn_Contenido.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lb_TextoCiudadContratacion As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoMedicoBase As System.Windows.Forms.Label
    Friend WithEvents Tx_LugarEntregaDotacion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoLugarEntregaDotacion As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoJefePersonal As System.Windows.Forms.Label
    Friend WithEvents Cu_CiudadContratacion As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Cu_BPMedicoBase As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BPJefePersonal As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Lb_TextoCoordinadorHSE As System.Windows.Forms.Label
    Friend WithEvents Cu_BPCoordinadorHSE As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_TextoCodigoContrato As System.Windows.Forms.Label
    Friend WithEvents Tx_CodigoContrato As System.Windows.Forms.TextBox
    Friend WithEvents Cu_CentroCostoBase As FormulariosClasesBase.Cu_CentroCosto
    Friend WithEvents Pn_Contenido As System.Windows.Forms.Panel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_TextoResidente As System.Windows.Forms.Label
    Friend WithEvents Cu_BPResidente As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_TextoAdministrador As System.Windows.Forms.Label
    Friend WithEvents Cu_BPAdministrador As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_APB_Administrador As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_APB_JefePersonal As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_APB_Residente As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_APBMedicoBase As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_ABP_CoordinadorHSE As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_APB_CoordinadorQAQC As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Lb_TextoCoordinadorQAQC As System.Windows.Forms.Label
    Friend WithEvents Cu_BPCoordinadorQAQC As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_TextoJefeBodega As System.Windows.Forms.Label
    Friend WithEvents Cu_BPJefeBodega As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_APB_JefeBodega As FormulariosClasesBase.Cu_AsociarPersonaBodega
End Class