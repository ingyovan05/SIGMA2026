<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_EnvioMantenimientoExterno
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
        Dim Lb_TipoMoneda As System.Windows.Forms.Label
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.Tx_DigitoVerificacion = New System.Windows.Forms.TextBox()
        Me.Lb_DigitoVerificacion = New System.Windows.Forms.Label()
        Me.Tx_Contratista = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarDeContratista = New System.Windows.Forms.Button()
        Me.Lb_Contratista = New System.Windows.Forms.Label()
        Me.Tx_NombreContratista = New System.Windows.Forms.TextBox()
        Me.Cb_TipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Tx_ValorEstimado = New System.Windows.Forms.TextBox()
        Me.Lb_ValorEstimado = New System.Windows.Forms.Label()
        Me.Ll_SolicitadoPor = New System.Windows.Forms.LinkLabel()
        Me.Dtp_FechaEnvio = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaEnvio = New System.Windows.Forms.Label()
        Me.Lb_TipoMantenimiento = New System.Windows.Forms.Label()
        Me.Cb_TipoMantenimiento = New System.Windows.Forms.ComboBox()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Lb_Descripcion = New System.Windows.Forms.Label()
        Me.Lb_Direccion = New System.Windows.Forms.Label()
        Me.Tx_Direccion = New System.Windows.Forms.TextBox()
        Me.Lb_Consecutivo = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Lb_FechaRecibido = New System.Windows.Forms.Label()
        Me.Lb_Observacion = New System.Windows.Forms.Label()
        Me.Tx_Observacion = New System.Windows.Forms.TextBox()
        Me.Ll_RecibidoPor = New System.Windows.Forms.LinkLabel()
        Me.Lb_ValorCierre = New System.Windows.Forms.Label()
        Me.Tx_ValorCierre = New System.Windows.Forms.TextBox()
        Me.Dtp_FechaRecibido = New System.Windows.Forms.DateTimePicker()
        Me.Pn_Cierre = New System.Windows.Forms.Panel()
        Me.Cb_EstadoUsoDespues = New System.Windows.Forms.ComboBox()
        Me.Lb_EstadoUsoDespues = New System.Windows.Forms.Label()
        Me.Cu_Recibido = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_Ciudad = New System.Windows.Forms.Label()
        Me.Tx_ValorAseguradora = New System.Windows.Forms.TextBox()
        Me.Lb_ValorAseguradora = New System.Windows.Forms.Label()
        Me.Ll_AprobadoPor = New System.Windows.Forms.LinkLabel()
        Me.Lb_TipoEnvio = New System.Windows.Forms.Label()
        Me.Cb_TipoEnvio = New System.Windows.Forms.ComboBox()
        Me.Pn_Mantenimiento = New System.Windows.Forms.Panel()
        Me.Lb_NombreResponsable = New System.Windows.Forms.Label()
        Me.Tx_NombreResponsable = New System.Windows.Forms.TextBox()
        Me.Lb_Guia = New System.Windows.Forms.Label()
        Me.Tx_Guia = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarPlaca = New System.Windows.Forms.Button()
        Me.Lb_PlacaVehiculo = New System.Windows.Forms.Label()
        Me.Tx_PlacaVehiculo = New System.Windows.Forms.TextBox()
        Me.Lb_CelularTransportador = New System.Windows.Forms.Label()
        Me.Tx_CelularTransportador = New System.Windows.Forms.TextBox()
        Me.Lb_EmpresaTransporta = New System.Windows.Forms.Label()
        Me.Tx_EmpresaTransporta = New System.Windows.Forms.TextBox()
        Me.Lb_NombreTransportador = New System.Windows.Forms.Label()
        Me.Tx_NombreTransportador = New System.Windows.Forms.TextBox()
        Me.Dtp_FechaDespacho = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaDespacho = New System.Windows.Forms.Label()
        Me.Cu_AsociarPersonaAprobado = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_Aprobada = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_Ciudad = New FormulariosClasesBase.Cu_Ciudad()
        Me.Cu_AsociarPersonaSolicitado = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_Solicitada = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Pn_TipoEnvio = New System.Windows.Forms.Panel()
        Me.Tlp_Estado = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dtp_FechaMantenimientoExt = New System.Windows.Forms.DateTimePicker()
        Lb_TipoMoneda = New System.Windows.Forms.Label()
        Me.Pn_Cierre.SuspendLayout()
        Me.Pn_Mantenimiento.SuspendLayout()
        Me.Pn_TipoEnvio.SuspendLayout()
        Me.Tlp_Estado.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lb_TipoMoneda
        '
        Lb_TipoMoneda.AutoSize = True
        Lb_TipoMoneda.Location = New System.Drawing.Point(212, 88)
        Lb_TipoMoneda.Name = "Lb_TipoMoneda"
        Lb_TipoMoneda.Size = New System.Drawing.Size(73, 13)
        Lb_TipoMoneda.TabIndex = 15
        Lb_TipoMoneda.Text = "Tipo Moneda:"
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(764, 30)
        Me.Lb_Titulo.TabIndex = 0
        Me.Lb_Titulo.Text = "ENVÍO DE EQUIPO A PROVEEDOR PARA SERVICIO"
        Me.Lb_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tx_DigitoVerificacion
        '
        Me.Tx_DigitoVerificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_DigitoVerificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_DigitoVerificacion.Location = New System.Drawing.Point(288, 33)
        Me.Tx_DigitoVerificacion.MaxLength = 1
        Me.Tx_DigitoVerificacion.Name = "Tx_DigitoVerificacion"
        Me.Tx_DigitoVerificacion.ReadOnly = True
        Me.Tx_DigitoVerificacion.Size = New System.Drawing.Size(27, 20)
        Me.Tx_DigitoVerificacion.TabIndex = 7
        '
        'Lb_DigitoVerificacion
        '
        Me.Lb_DigitoVerificacion.AutoSize = True
        Me.Lb_DigitoVerificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_DigitoVerificacion.Location = New System.Drawing.Point(240, 36)
        Me.Lb_DigitoVerificacion.Name = "Lb_DigitoVerificacion"
        Me.Lb_DigitoVerificacion.Size = New System.Drawing.Size(45, 13)
        Me.Lb_DigitoVerificacion.TabIndex = 6
        Me.Lb_DigitoVerificacion.Text = "Dig Ver:"
        '
        'Tx_Contratista
        '
        Me.Tx_Contratista.Location = New System.Drawing.Point(94, 33)
        Me.Tx_Contratista.MaxLength = 200
        Me.Tx_Contratista.Name = "Tx_Contratista"
        Me.Tx_Contratista.ReadOnly = True
        Me.Tx_Contratista.Size = New System.Drawing.Size(102, 20)
        Me.Tx_Contratista.TabIndex = 4
        '
        'Bt_BuscarDeContratista
        '
        Me.Bt_BuscarDeContratista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_BuscarDeContratista.Location = New System.Drawing.Point(203, 32)
        Me.Bt_BuscarDeContratista.Name = "Bt_BuscarDeContratista"
        Me.Bt_BuscarDeContratista.Size = New System.Drawing.Size(28, 22)
        Me.Bt_BuscarDeContratista.TabIndex = 5
        Me.Bt_BuscarDeContratista.Text = "..."
        Me.Bt_BuscarDeContratista.UseVisualStyleBackColor = True
        '
        'Lb_Contratista
        '
        Me.Lb_Contratista.AutoSize = True
        Me.Lb_Contratista.Location = New System.Drawing.Point(31, 36)
        Me.Lb_Contratista.Name = "Lb_Contratista"
        Me.Lb_Contratista.Size = New System.Drawing.Size(60, 13)
        Me.Lb_Contratista.TabIndex = 3
        Me.Lb_Contratista.Text = "Contratista:"
        '
        'Tx_NombreContratista
        '
        Me.Tx_NombreContratista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_NombreContratista.Location = New System.Drawing.Point(321, 33)
        Me.Tx_NombreContratista.MaxLength = 150
        Me.Tx_NombreContratista.Name = "Tx_NombreContratista"
        Me.Tx_NombreContratista.ReadOnly = True
        Me.Tx_NombreContratista.Size = New System.Drawing.Size(434, 20)
        Me.Tx_NombreContratista.TabIndex = 8
        '
        'Cb_TipoMoneda
        '
        Me.Cb_TipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoMoneda.FormattingEnabled = True
        Me.Cb_TipoMoneda.Location = New System.Drawing.Point(288, 85)
        Me.Cb_TipoMoneda.Name = "Cb_TipoMoneda"
        Me.Cb_TipoMoneda.Size = New System.Drawing.Size(126, 21)
        Me.Cb_TipoMoneda.TabIndex = 16
        Me.Cb_TipoMoneda.Tag = ""
        '
        'Tx_ValorEstimado
        '
        Me.Tx_ValorEstimado.Location = New System.Drawing.Point(94, 85)
        Me.Tx_ValorEstimado.MaxLength = 200
        Me.Tx_ValorEstimado.Name = "Tx_ValorEstimado"
        Me.Tx_ValorEstimado.Size = New System.Drawing.Size(102, 20)
        Me.Tx_ValorEstimado.TabIndex = 14
        '
        'Lb_ValorEstimado
        '
        Me.Lb_ValorEstimado.AutoSize = True
        Me.Lb_ValorEstimado.Location = New System.Drawing.Point(11, 88)
        Me.Lb_ValorEstimado.Name = "Lb_ValorEstimado"
        Me.Lb_ValorEstimado.Size = New System.Drawing.Size(80, 13)
        Me.Lb_ValorEstimado.TabIndex = 13
        Me.Lb_ValorEstimado.Text = "Valor Estimado:"
        '
        'Ll_SolicitadoPor
        '
        Me.Ll_SolicitadoPor.AutoSize = True
        Me.Ll_SolicitadoPor.Location = New System.Drawing.Point(17, 115)
        Me.Ll_SolicitadoPor.Name = "Ll_SolicitadoPor"
        Me.Ll_SolicitadoPor.Size = New System.Drawing.Size(74, 13)
        Me.Ll_SolicitadoPor.TabIndex = 19
        Me.Ll_SolicitadoPor.TabStop = True
        Me.Ll_SolicitadoPor.Tag = "Persona de ISMOCOL que esta solicitando el servicio, debe coincidir con la Firma " & _
    "Autorizada en el documento impreso"
        Me.Ll_SolicitadoPor.Text = "Solicitado por:"
        '
        'Dtp_FechaEnvio
        '
        Me.Dtp_FechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaEnvio.Location = New System.Drawing.Point(661, 112)
        Me.Dtp_FechaEnvio.Name = "Dtp_FechaEnvio"
        Me.Dtp_FechaEnvio.Size = New System.Drawing.Size(94, 20)
        Me.Dtp_FechaEnvio.TabIndex = 23
        '
        'Lb_FechaEnvio
        '
        Me.Lb_FechaEnvio.AutoSize = True
        Me.Lb_FechaEnvio.Location = New System.Drawing.Point(586, 115)
        Me.Lb_FechaEnvio.Name = "Lb_FechaEnvio"
        Me.Lb_FechaEnvio.Size = New System.Drawing.Size(72, 13)
        Me.Lb_FechaEnvio.TabIndex = 22
        Me.Lb_FechaEnvio.Text = "Fecha Envío:"
        '
        'Lb_TipoMantenimiento
        '
        Me.Lb_TipoMantenimiento.AutoSize = True
        Me.Lb_TipoMantenimiento.Location = New System.Drawing.Point(60, 9)
        Me.Lb_TipoMantenimiento.Name = "Lb_TipoMantenimiento"
        Me.Lb_TipoMantenimiento.Size = New System.Drawing.Size(31, 13)
        Me.Lb_TipoMantenimiento.TabIndex = 1
        Me.Lb_TipoMantenimiento.Text = "Tipo:"
        '
        'Cb_TipoMantenimiento
        '
        Me.Cb_TipoMantenimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoMantenimiento.FormattingEnabled = True
        Me.Cb_TipoMantenimiento.Items.AddRange(New Object() {"MANTENIMIENTO", "EN GARANTIA", "CALIBRACION", "REPARACION"})
        Me.Cb_TipoMantenimiento.Location = New System.Drawing.Point(94, 6)
        Me.Cb_TipoMantenimiento.Name = "Cb_TipoMantenimiento"
        Me.Cb_TipoMantenimiento.Size = New System.Drawing.Size(136, 21)
        Me.Cb_TipoMantenimiento.TabIndex = 2
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Location = New System.Drawing.Point(94, 140)
        Me.Tx_Descripcion.MaxLength = 400
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(661, 77)
        Me.Tx_Descripcion.TabIndex = 25
        '
        'Lb_Descripcion
        '
        Me.Lb_Descripcion.AutoSize = True
        Me.Lb_Descripcion.Location = New System.Drawing.Point(25, 143)
        Me.Lb_Descripcion.Name = "Lb_Descripcion"
        Me.Lb_Descripcion.Size = New System.Drawing.Size(66, 13)
        Me.Lb_Descripcion.TabIndex = 24
        Me.Lb_Descripcion.Text = "Descripción:"
        '
        'Lb_Direccion
        '
        Me.Lb_Direccion.AutoSize = True
        Me.Lb_Direccion.Location = New System.Drawing.Point(4, 62)
        Me.Lb_Direccion.Name = "Lb_Direccion"
        Me.Lb_Direccion.Size = New System.Drawing.Size(87, 13)
        Me.Lb_Direccion.TabIndex = 9
        Me.Lb_Direccion.Text = "Dirección Envío:"
        '
        'Tx_Direccion
        '
        Me.Tx_Direccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_Direccion.Location = New System.Drawing.Point(94, 59)
        Me.Tx_Direccion.MaxLength = 150
        Me.Tx_Direccion.Name = "Tx_Direccion"
        Me.Tx_Direccion.Size = New System.Drawing.Size(359, 20)
        Me.Tx_Direccion.TabIndex = 10
        '
        'Lb_Consecutivo
        '
        Me.Lb_Consecutivo.AutoSize = True
        Me.Lb_Consecutivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Consecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Consecutivo.ForeColor = System.Drawing.Color.Red
        Me.Lb_Consecutivo.Location = New System.Drawing.Point(11, 0)
        Me.Lb_Consecutivo.Margin = New System.Windows.Forms.Padding(11, 0, 3, 0)
        Me.Lb_Consecutivo.Name = "Lb_Consecutivo"
        Me.Lb_Consecutivo.Size = New System.Drawing.Size(368, 30)
        Me.Lb_Consecutivo.TabIndex = 0
        Me.Lb_Consecutivo.Text = "Label13"
        Me.Lb_Consecutivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lb_Consecutivo.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(223, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(304, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Lb_FechaRecibido
        '
        Me.Lb_FechaRecibido.AutoSize = True
        Me.Lb_FechaRecibido.Location = New System.Drawing.Point(569, 7)
        Me.Lb_FechaRecibido.Name = "Lb_FechaRecibido"
        Me.Lb_FechaRecibido.Size = New System.Drawing.Size(85, 13)
        Me.Lb_FechaRecibido.TabIndex = 2
        Me.Lb_FechaRecibido.Text = "Fecha Recibido:"
        '
        'Lb_Observacion
        '
        Me.Lb_Observacion.AutoSize = True
        Me.Lb_Observacion.Location = New System.Drawing.Point(21, 55)
        Me.Lb_Observacion.Name = "Lb_Observacion"
        Me.Lb_Observacion.Size = New System.Drawing.Size(70, 13)
        Me.Lb_Observacion.TabIndex = 8
        Me.Lb_Observacion.Text = "Observación:"
        '
        'Tx_Observacion
        '
        Me.Tx_Observacion.Location = New System.Drawing.Point(94, 52)
        Me.Tx_Observacion.MaxLength = 100
        Me.Tx_Observacion.Name = "Tx_Observacion"
        Me.Tx_Observacion.Size = New System.Drawing.Size(661, 20)
        Me.Tx_Observacion.TabIndex = 9
        '
        'Ll_RecibidoPor
        '
        Me.Ll_RecibidoPor.AutoSize = True
        Me.Ll_RecibidoPor.Location = New System.Drawing.Point(21, 7)
        Me.Ll_RecibidoPor.Name = "Ll_RecibidoPor"
        Me.Ll_RecibidoPor.Size = New System.Drawing.Size(70, 13)
        Me.Ll_RecibidoPor.TabIndex = 0
        Me.Ll_RecibidoPor.TabStop = True
        Me.Ll_RecibidoPor.Tag = "Persona por parte de ISMOCOL que certifica la prestación del servicio"
        Me.Ll_RecibidoPor.Text = "Recibido por:"
        '
        'Lb_ValorCierre
        '
        Me.Lb_ValorCierre.AutoSize = True
        Me.Lb_ValorCierre.Location = New System.Drawing.Point(27, 31)
        Me.Lb_ValorCierre.Name = "Lb_ValorCierre"
        Me.Lb_ValorCierre.Size = New System.Drawing.Size(64, 13)
        Me.Lb_ValorCierre.TabIndex = 4
        Me.Lb_ValorCierre.Text = "Valor Cierre:"
        '
        'Tx_ValorCierre
        '
        Me.Tx_ValorCierre.Location = New System.Drawing.Point(94, 28)
        Me.Tx_ValorCierre.MaxLength = 200
        Me.Tx_ValorCierre.Name = "Tx_ValorCierre"
        Me.Tx_ValorCierre.Size = New System.Drawing.Size(102, 20)
        Me.Tx_ValorCierre.TabIndex = 5
        '
        'Dtp_FechaRecibido
        '
        Me.Dtp_FechaRecibido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaRecibido.Location = New System.Drawing.Point(657, 4)
        Me.Dtp_FechaRecibido.Name = "Dtp_FechaRecibido"
        Me.Dtp_FechaRecibido.Size = New System.Drawing.Size(98, 20)
        Me.Dtp_FechaRecibido.TabIndex = 3
        '
        'Pn_Cierre
        '
        Me.Pn_Cierre.AutoSize = True
        Me.Pn_Cierre.Controls.Add(Me.Dtp_FechaMantenimientoExt)
        Me.Pn_Cierre.Controls.Add(Me.Label1)
        Me.Pn_Cierre.Controls.Add(Me.Cb_EstadoUsoDespues)
        Me.Pn_Cierre.Controls.Add(Me.Lb_EstadoUsoDespues)
        Me.Pn_Cierre.Controls.Add(Me.Dtp_FechaRecibido)
        Me.Pn_Cierre.Controls.Add(Me.Tx_ValorCierre)
        Me.Pn_Cierre.Controls.Add(Me.Lb_ValorCierre)
        Me.Pn_Cierre.Controls.Add(Me.Ll_RecibidoPor)
        Me.Pn_Cierre.Controls.Add(Me.Tx_Observacion)
        Me.Pn_Cierre.Controls.Add(Me.Lb_Observacion)
        Me.Pn_Cierre.Controls.Add(Me.Cu_Recibido)
        Me.Pn_Cierre.Controls.Add(Me.Lb_FechaRecibido)
        Me.Pn_Cierre.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Cierre.Location = New System.Drawing.Point(0, 389)
        Me.Pn_Cierre.Name = "Pn_Cierre"
        Me.Pn_Cierre.Padding = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.Pn_Cierre.Size = New System.Drawing.Size(764, 78)
        Me.Pn_Cierre.TabIndex = 3
        '
        'Cb_EstadoUsoDespues
        '
        Me.Cb_EstadoUsoDespues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_EstadoUsoDespues.FormattingEnabled = True
        Me.Cb_EstadoUsoDespues.Items.AddRange(New Object() {"MANTENIMIENTO", "EN GARANTIA", "CALIBRACION", "REPARACION"})
        Me.Cb_EstadoUsoDespues.Location = New System.Drawing.Point(382, 28)
        Me.Cb_EstadoUsoDespues.Name = "Cb_EstadoUsoDespues"
        Me.Cb_EstadoUsoDespues.Size = New System.Drawing.Size(163, 21)
        Me.Cb_EstadoUsoDespues.TabIndex = 7
        '
        'Lb_EstadoUsoDespues
        '
        Me.Lb_EstadoUsoDespues.AutoSize = True
        Me.Lb_EstadoUsoDespues.Location = New System.Drawing.Point(202, 31)
        Me.Lb_EstadoUsoDespues.Name = "Lb_EstadoUsoDespues"
        Me.Lb_EstadoUsoDespues.Size = New System.Drawing.Size(177, 13)
        Me.Lb_EstadoUsoDespues.TabIndex = 6
        Me.Lb_EstadoUsoDespues.Text = "Estado de uso después del servicio:"
        '
        'Cu_Recibido
        '
        Me.Cu_Recibido.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_Recibido.Location = New System.Drawing.Point(92, 3)
        Me.Cu_Recibido.Name = "Cu_Recibido"
        Me.Cu_Recibido.Size = New System.Drawing.Size(453, 23)
        Me.Cu_Recibido.TabIndex = 1
        Me.Cu_Recibido.Tipo = "PUABO"
        Me.Cu_Recibido.valorcajatexto = "IDENTIFICACION"
        '
        'Lb_Ciudad
        '
        Me.Lb_Ciudad.AutoSize = True
        Me.Lb_Ciudad.Location = New System.Drawing.Point(459, 62)
        Me.Lb_Ciudad.Name = "Lb_Ciudad"
        Me.Lb_Ciudad.Size = New System.Drawing.Size(43, 13)
        Me.Lb_Ciudad.TabIndex = 11
        Me.Lb_Ciudad.Text = "Ciudad:"
        '
        'Tx_ValorAseguradora
        '
        Me.Tx_ValorAseguradora.Location = New System.Drawing.Point(632, 85)
        Me.Tx_ValorAseguradora.MaxLength = 10
        Me.Tx_ValorAseguradora.Name = "Tx_ValorAseguradora"
        Me.Tx_ValorAseguradora.Size = New System.Drawing.Size(123, 20)
        Me.Tx_ValorAseguradora.TabIndex = 18
        '
        'Lb_ValorAseguradora
        '
        Me.Lb_ValorAseguradora.AutoSize = True
        Me.Lb_ValorAseguradora.Location = New System.Drawing.Point(444, 88)
        Me.Lb_ValorAseguradora.Name = "Lb_ValorAseguradora"
        Me.Lb_ValorAseguradora.Size = New System.Drawing.Size(185, 13)
        Me.Lb_ValorAseguradora.TabIndex = 17
        Me.Lb_ValorAseguradora.Text = "Valor del Equipo para la Aseguradora:"
        '
        'Ll_AprobadoPor
        '
        Me.Ll_AprobadoPor.AutoSize = True
        Me.Ll_AprobadoPor.Location = New System.Drawing.Point(17, 228)
        Me.Ll_AprobadoPor.Name = "Ll_AprobadoPor"
        Me.Ll_AprobadoPor.Size = New System.Drawing.Size(74, 13)
        Me.Ll_AprobadoPor.TabIndex = 26
        Me.Ll_AprobadoPor.TabStop = True
        Me.Ll_AprobadoPor.Tag = "Persona de ISMOCOL que aprueba el servicio"
        Me.Ll_AprobadoPor.Text = "Aprobado por:"
        '
        'Lb_TipoEnvio
        '
        Me.Lb_TipoEnvio.AutoSize = True
        Me.Lb_TipoEnvio.Location = New System.Drawing.Point(14, 8)
        Me.Lb_TipoEnvio.Name = "Lb_TipoEnvio"
        Me.Lb_TipoEnvio.Size = New System.Drawing.Size(78, 13)
        Me.Lb_TipoEnvio.TabIndex = 0
        Me.Lb_TipoEnvio.Text = "Tipo de Envío:"
        '
        'Cb_TipoEnvio
        '
        Me.Cb_TipoEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoEnvio.FormattingEnabled = True
        Me.Cb_TipoEnvio.Location = New System.Drawing.Point(94, 4)
        Me.Cb_TipoEnvio.Name = "Cb_TipoEnvio"
        Me.Cb_TipoEnvio.Size = New System.Drawing.Size(140, 21)
        Me.Cb_TipoEnvio.TabIndex = 1
        Me.Cb_TipoEnvio.Tag = "566"
        '
        'Pn_Mantenimiento
        '
        Me.Pn_Mantenimiento.AutoSize = True
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_NombreResponsable)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_NombreResponsable)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_Guia)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_Guia)
        Me.Pn_Mantenimiento.Controls.Add(Me.Bt_BuscarPlaca)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_PlacaVehiculo)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_PlacaVehiculo)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_CelularTransportador)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_CelularTransportador)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_EmpresaTransporta)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_EmpresaTransporta)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_NombreTransportador)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_NombreTransportador)
        Me.Pn_Mantenimiento.Controls.Add(Me.Dtp_FechaDespacho)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_FechaDespacho)
        Me.Pn_Mantenimiento.Controls.Add(Me.Ll_AprobadoPor)
        Me.Pn_Mantenimiento.Controls.Add(Me.Cu_AsociarPersonaAprobado)
        Me.Pn_Mantenimiento.Controls.Add(Me.Cu_Aprobada)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_ValorAseguradora)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_ValorAseguradora)
        Me.Pn_Mantenimiento.Controls.Add(Me.Cu_Ciudad)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_Ciudad)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_Direccion)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_Direccion)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_Descripcion)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_Descripcion)
        Me.Pn_Mantenimiento.Controls.Add(Me.Cb_TipoMantenimiento)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_TipoMantenimiento)
        Me.Pn_Mantenimiento.Controls.Add(Me.Dtp_FechaEnvio)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_FechaEnvio)
        Me.Pn_Mantenimiento.Controls.Add(Me.Ll_SolicitadoPor)
        Me.Pn_Mantenimiento.Controls.Add(Me.Cu_AsociarPersonaSolicitado)
        Me.Pn_Mantenimiento.Controls.Add(Me.Cu_Solicitada)
        Me.Pn_Mantenimiento.Controls.Add(Me.Cb_TipoMoneda)
        Me.Pn_Mantenimiento.Controls.Add(Lb_TipoMoneda)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_ValorEstimado)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_ValorEstimado)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_DigitoVerificacion)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_DigitoVerificacion)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_Contratista)
        Me.Pn_Mantenimiento.Controls.Add(Me.Bt_BuscarDeContratista)
        Me.Pn_Mantenimiento.Controls.Add(Me.Lb_Contratista)
        Me.Pn_Mantenimiento.Controls.Add(Me.Tx_NombreContratista)
        Me.Pn_Mantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Mantenimiento.Location = New System.Drawing.Point(0, 30)
        Me.Pn_Mantenimiento.Name = "Pn_Mantenimiento"
        Me.Pn_Mantenimiento.Padding = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.Pn_Mantenimiento.Size = New System.Drawing.Size(764, 328)
        Me.Pn_Mantenimiento.TabIndex = 0
        '
        'Lb_NombreResponsable
        '
        Me.Lb_NombreResponsable.AutoSize = True
        Me.Lb_NombreResponsable.Location = New System.Drawing.Point(373, 308)
        Me.Lb_NombreResponsable.Name = "Lb_NombreResponsable"
        Me.Lb_NombreResponsable.Size = New System.Drawing.Size(129, 13)
        Me.Lb_NombreResponsable.TabIndex = 42
        Me.Lb_NombreResponsable.Text = "Nombre del Responsable:"
        '
        'Tx_NombreResponsable
        '
        Me.Tx_NombreResponsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_NombreResponsable.Location = New System.Drawing.Point(505, 305)
        Me.Tx_NombreResponsable.MaxLength = 50
        Me.Tx_NombreResponsable.Name = "Tx_NombreResponsable"
        Me.Tx_NombreResponsable.Size = New System.Drawing.Size(250, 20)
        Me.Tx_NombreResponsable.TabIndex = 43
        '
        'Lb_Guia
        '
        Me.Lb_Guia.AutoSize = True
        Me.Lb_Guia.Location = New System.Drawing.Point(468, 282)
        Me.Lb_Guia.Name = "Lb_Guia"
        Me.Lb_Guia.Size = New System.Drawing.Size(34, 13)
        Me.Lb_Guia.TabIndex = 38
        Me.Lb_Guia.Text = "Guía:"
        '
        'Tx_Guia
        '
        Me.Tx_Guia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_Guia.Location = New System.Drawing.Point(505, 279)
        Me.Tx_Guia.MaxLength = 50
        Me.Tx_Guia.Name = "Tx_Guia"
        Me.Tx_Guia.Size = New System.Drawing.Size(250, 20)
        Me.Tx_Guia.TabIndex = 39
        '
        'Bt_BuscarPlaca
        '
        Me.Bt_BuscarPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_BuscarPlaca.Location = New System.Drawing.Point(397, 278)
        Me.Bt_BuscarPlaca.Name = "Bt_BuscarPlaca"
        Me.Bt_BuscarPlaca.Size = New System.Drawing.Size(28, 21)
        Me.Bt_BuscarPlaca.TabIndex = 37
        Me.Bt_BuscarPlaca.Text = "..."
        Me.Bt_BuscarPlaca.UseVisualStyleBackColor = True
        '
        'Lb_PlacaVehiculo
        '
        Me.Lb_PlacaVehiculo.AutoSize = True
        Me.Lb_PlacaVehiculo.Location = New System.Drawing.Point(203, 282)
        Me.Lb_PlacaVehiculo.Name = "Lb_PlacaVehiculo"
        Me.Lb_PlacaVehiculo.Size = New System.Drawing.Size(82, 13)
        Me.Lb_PlacaVehiculo.TabIndex = 35
        Me.Lb_PlacaVehiculo.Text = "Placa vehículo:"
        '
        'Tx_PlacaVehiculo
        '
        Me.Tx_PlacaVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_PlacaVehiculo.Location = New System.Drawing.Point(288, 279)
        Me.Tx_PlacaVehiculo.MaxLength = 10
        Me.Tx_PlacaVehiculo.Name = "Tx_PlacaVehiculo"
        Me.Tx_PlacaVehiculo.Size = New System.Drawing.Size(102, 20)
        Me.Tx_PlacaVehiculo.TabIndex = 36
        '
        'Lb_CelularTransportador
        '
        Me.Lb_CelularTransportador.AutoSize = True
        Me.Lb_CelularTransportador.Location = New System.Drawing.Point(49, 282)
        Me.Lb_CelularTransportador.Name = "Lb_CelularTransportador"
        Me.Lb_CelularTransportador.Size = New System.Drawing.Size(42, 13)
        Me.Lb_CelularTransportador.TabIndex = 33
        Me.Lb_CelularTransportador.Text = "Celular:"
        '
        'Tx_CelularTransportador
        '
        Me.Tx_CelularTransportador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_CelularTransportador.Location = New System.Drawing.Point(94, 279)
        Me.Tx_CelularTransportador.MaxLength = 10
        Me.Tx_CelularTransportador.Name = "Tx_CelularTransportador"
        Me.Tx_CelularTransportador.Size = New System.Drawing.Size(102, 20)
        Me.Tx_CelularTransportador.TabIndex = 34
        '
        'Lb_EmpresaTransporta
        '
        Me.Lb_EmpresaTransporta.AutoSize = True
        Me.Lb_EmpresaTransporta.Location = New System.Drawing.Point(380, 256)
        Me.Lb_EmpresaTransporta.Name = "Lb_EmpresaTransporta"
        Me.Lb_EmpresaTransporta.Size = New System.Drawing.Size(122, 13)
        Me.Lb_EmpresaTransporta.TabIndex = 31
        Me.Lb_EmpresaTransporta.Text = "Empresa transportadora:"
        '
        'Tx_EmpresaTransporta
        '
        Me.Tx_EmpresaTransporta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_EmpresaTransporta.Location = New System.Drawing.Point(505, 253)
        Me.Tx_EmpresaTransporta.MaxLength = 50
        Me.Tx_EmpresaTransporta.Name = "Tx_EmpresaTransporta"
        Me.Tx_EmpresaTransporta.Size = New System.Drawing.Size(250, 20)
        Me.Tx_EmpresaTransporta.TabIndex = 32
        '
        'Lb_NombreTransportador
        '
        Me.Lb_NombreTransportador.AutoSize = True
        Me.Lb_NombreTransportador.Location = New System.Drawing.Point(15, 256)
        Me.Lb_NombreTransportador.Name = "Lb_NombreTransportador"
        Me.Lb_NombreTransportador.Size = New System.Drawing.Size(76, 13)
        Me.Lb_NombreTransportador.TabIndex = 29
        Me.Lb_NombreTransportador.Text = "Transportador:"
        '
        'Tx_NombreTransportador
        '
        Me.Tx_NombreTransportador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_NombreTransportador.Location = New System.Drawing.Point(94, 253)
        Me.Tx_NombreTransportador.MaxLength = 50
        Me.Tx_NombreTransportador.Name = "Tx_NombreTransportador"
        Me.Tx_NombreTransportador.Size = New System.Drawing.Size(250, 20)
        Me.Tx_NombreTransportador.TabIndex = 30
        '
        'Dtp_FechaDespacho
        '
        Me.Dtp_FechaDespacho.Checked = False
        Me.Dtp_FechaDespacho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaDespacho.Location = New System.Drawing.Point(94, 305)
        Me.Dtp_FechaDespacho.Name = "Dtp_FechaDespacho"
        Me.Dtp_FechaDespacho.ShowCheckBox = True
        Me.Dtp_FechaDespacho.Size = New System.Drawing.Size(102, 20)
        Me.Dtp_FechaDespacho.TabIndex = 41
        '
        'Lb_FechaDespacho
        '
        Me.Lb_FechaDespacho.AutoSize = True
        Me.Lb_FechaDespacho.Location = New System.Drawing.Point(20, 308)
        Me.Lb_FechaDespacho.Name = "Lb_FechaDespacho"
        Me.Lb_FechaDespacho.Size = New System.Drawing.Size(71, 13)
        Me.Lb_FechaDespacho.TabIndex = 40
        Me.Lb_FechaDespacho.Text = "Despachado:"
        '
        'Cu_AsociarPersonaAprobado
        '
        Me.Cu_AsociarPersonaAprobado.componenteasociado = "Cu_Aprobada"
        Me.Cu_AsociarPersonaAprobado.CrearUsuario = True
        Me.Cu_AsociarPersonaAprobado.Location = New System.Drawing.Point(551, 224)
        Me.Cu_AsociarPersonaAprobado.Name = "Cu_AsociarPersonaAprobado"
        Me.Cu_AsociarPersonaAprobado.Size = New System.Drawing.Size(27, 22)
        Me.Cu_AsociarPersonaAprobado.TabIndex = 28
        Me.Cu_AsociarPersonaAprobado.Tag = "286"
        Me.Cu_AsociarPersonaAprobado.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaAprobado.TipoBúsqueda = "P"
        '
        'Cu_Aprobada
        '
        Me.Cu_Aprobada.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_Aprobada.Location = New System.Drawing.Point(92, 224)
        Me.Cu_Aprobada.Name = "Cu_Aprobada"
        Me.Cu_Aprobada.Size = New System.Drawing.Size(453, 22)
        Me.Cu_Aprobada.TabIndex = 27
        Me.Cu_Aprobada.Tipo = "PUABO"
        Me.Cu_Aprobada.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_Ciudad
        '
        Me.Cu_Ciudad.Location = New System.Drawing.Point(503, 58)
        Me.Cu_Ciudad.Name = "Cu_Ciudad"
        Me.Cu_Ciudad.Size = New System.Drawing.Size(256, 22)
        Me.Cu_Ciudad.TabIndex = 12
        '
        'Cu_AsociarPersonaSolicitado
        '
        Me.Cu_AsociarPersonaSolicitado.componenteasociado = "Cu_Solicitada"
        Me.Cu_AsociarPersonaSolicitado.CrearUsuario = True
        Me.Cu_AsociarPersonaSolicitado.Location = New System.Drawing.Point(551, 111)
        Me.Cu_AsociarPersonaSolicitado.Name = "Cu_AsociarPersonaSolicitado"
        Me.Cu_AsociarPersonaSolicitado.Size = New System.Drawing.Size(27, 22)
        Me.Cu_AsociarPersonaSolicitado.TabIndex = 21
        Me.Cu_AsociarPersonaSolicitado.Tag = "286"
        Me.Cu_AsociarPersonaSolicitado.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaSolicitado.TipoBúsqueda = "P"
        '
        'Cu_Solicitada
        '
        Me.Cu_Solicitada.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_Solicitada.Location = New System.Drawing.Point(92, 111)
        Me.Cu_Solicitada.Name = "Cu_Solicitada"
        Me.Cu_Solicitada.Size = New System.Drawing.Size(453, 22)
        Me.Cu_Solicitada.TabIndex = 20
        Me.Cu_Solicitada.Tipo = "PUABO"
        Me.Cu_Solicitada.valorcajatexto = "IDENTIFICACION"
        '
        'Pn_TipoEnvio
        '
        Me.Pn_TipoEnvio.AutoSize = True
        Me.Pn_TipoEnvio.Controls.Add(Me.Cb_TipoEnvio)
        Me.Pn_TipoEnvio.Controls.Add(Me.Lb_TipoEnvio)
        Me.Pn_TipoEnvio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_TipoEnvio.Location = New System.Drawing.Point(0, 358)
        Me.Pn_TipoEnvio.Name = "Pn_TipoEnvio"
        Me.Pn_TipoEnvio.Padding = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.Pn_TipoEnvio.Size = New System.Drawing.Size(764, 31)
        Me.Pn_TipoEnvio.TabIndex = 1
        '
        'Tlp_Estado
        '
        Me.Tlp_Estado.BackColor = System.Drawing.Color.DarkGray
        Me.Tlp_Estado.ColumnCount = 2
        Me.Tlp_Estado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Estado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Estado.Controls.Add(Me.Lb_Consecutivo, 0, 0)
        Me.Tlp_Estado.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_Estado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_Estado.Location = New System.Drawing.Point(0, 467)
        Me.Tlp_Estado.Name = "Tlp_Estado"
        Me.Tlp_Estado.RowCount = 1
        Me.Tlp_Estado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Estado.Size = New System.Drawing.Size(764, 30)
        Me.Tlp_Estado.TabIndex = 0
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(382, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(382, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(563, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Fecha Mant. Ext.:"
        '
        'Dtp_FechaMantenimientoExt
        '
        Me.Dtp_FechaMantenimientoExt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaMantenimientoExt.Location = New System.Drawing.Point(657, 28)
        Me.Dtp_FechaMantenimientoExt.Name = "Dtp_FechaMantenimientoExt"
        Me.Dtp_FechaMantenimientoExt.Size = New System.Drawing.Size(98, 20)
        Me.Dtp_FechaMantenimientoExt.TabIndex = 11
        '
        'Fr_EnvioMantenimientoExterno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(764, 497)
        Me.Controls.Add(Me.Pn_Mantenimiento)
        Me.Controls.Add(Me.Lb_Titulo)
        Me.Controls.Add(Me.Pn_TipoEnvio)
        Me.Controls.Add(Me.Pn_Cierre)
        Me.Controls.Add(Me.Tlp_Estado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_EnvioMantenimientoExterno"
        Me.ShowIcon = False
        Me.Text = "Enviar a Mantenimiento / Calibración / Reparación"
        Me.Pn_Cierre.ResumeLayout(False)
        Me.Pn_Cierre.PerformLayout()
        Me.Pn_Mantenimiento.ResumeLayout(False)
        Me.Pn_Mantenimiento.PerformLayout()
        Me.Pn_TipoEnvio.ResumeLayout(False)
        Me.Pn_TipoEnvio.PerformLayout()
        Me.Tlp_Estado.ResumeLayout(False)
        Me.Tlp_Estado.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lb_Titulo As System.Windows.Forms.Label
    Friend WithEvents Tx_DigitoVerificacion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DigitoVerificacion As System.Windows.Forms.Label
    Friend WithEvents Lb_Contratista As System.Windows.Forms.Label
    Friend WithEvents Tx_NombreContratista As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ValorEstimado As System.Windows.Forms.Label
    Friend WithEvents Ll_SolicitadoPor As System.Windows.Forms.LinkLabel
    Friend WithEvents Lb_FechaEnvio As System.Windows.Forms.Label
    Friend WithEvents Lb_TipoMantenimiento As System.Windows.Forms.Label
    Friend WithEvents Lb_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Lb_Direccion As System.Windows.Forms.Label
    Public WithEvents Lb_Consecutivo As System.Windows.Forms.Label
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Lb_FechaRecibido As System.Windows.Forms.Label
    Friend WithEvents Cu_Recibido As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_Observacion As System.Windows.Forms.Label
    Friend WithEvents Tx_Observacion As System.Windows.Forms.TextBox
    Friend WithEvents Ll_RecibidoPor As System.Windows.Forms.LinkLabel
    Friend WithEvents Lb_ValorCierre As System.Windows.Forms.Label
    Friend WithEvents Tx_ValorCierre As System.Windows.Forms.TextBox
    Friend WithEvents Dtp_FechaRecibido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Pn_Cierre As System.Windows.Forms.Panel
    Friend WithEvents Cb_EstadoUsoDespues As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_EstadoUsoDespues As System.Windows.Forms.Label
    Friend WithEvents Lb_Ciudad As System.Windows.Forms.Label
    Public WithEvents Tx_Contratista As System.Windows.Forms.TextBox
    Public WithEvents Bt_BuscarDeContratista As System.Windows.Forms.Button
    Public WithEvents Cb_TipoMoneda As System.Windows.Forms.ComboBox
    Public WithEvents Tx_ValorEstimado As System.Windows.Forms.TextBox
    Public WithEvents Cu_Solicitada As FormulariosClasesBase.Cu_BuscarPersona
    Public WithEvents Dtp_FechaEnvio As System.Windows.Forms.DateTimePicker
    Public WithEvents Cb_TipoMantenimiento As System.Windows.Forms.ComboBox
    Public WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Public WithEvents Tx_Direccion As System.Windows.Forms.TextBox
    Public WithEvents Cu_Ciudad As FormulariosClasesBase.Cu_Ciudad
    Public WithEvents Cu_AsociarPersonaSolicitado As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Public WithEvents Tx_ValorAseguradora As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ValorAseguradora As System.Windows.Forms.Label
    Friend WithEvents Ll_AprobadoPor As System.Windows.Forms.LinkLabel
    Public WithEvents Cu_AsociarPersonaAprobado As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Public WithEvents Cu_Aprobada As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_TipoEnvio As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents Pn_Mantenimiento As System.Windows.Forms.Panel
    Friend WithEvents Pn_TipoEnvio As System.Windows.Forms.Panel
    Friend WithEvents Tlp_Estado As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_NombreTransportador As System.Windows.Forms.Label
    Public WithEvents Tx_NombreTransportador As System.Windows.Forms.TextBox
    Public WithEvents Dtp_FechaDespacho As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaDespacho As System.Windows.Forms.Label
    Friend WithEvents Lb_EmpresaTransporta As System.Windows.Forms.Label
    Public WithEvents Tx_EmpresaTransporta As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CelularTransportador As System.Windows.Forms.Label
    Public WithEvents Tx_CelularTransportador As System.Windows.Forms.TextBox
    Friend WithEvents Lb_PlacaVehiculo As System.Windows.Forms.Label
    Public WithEvents Tx_PlacaVehiculo As System.Windows.Forms.TextBox
    Public WithEvents Bt_BuscarPlaca As System.Windows.Forms.Button
    Friend WithEvents Lb_Guia As System.Windows.Forms.Label
    Public WithEvents Tx_Guia As System.Windows.Forms.TextBox
    Friend WithEvents Lb_NombreResponsable As System.Windows.Forms.Label
    Public WithEvents Tx_NombreResponsable As System.Windows.Forms.TextBox
    Friend WithEvents Dtp_FechaMantenimientoExt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
