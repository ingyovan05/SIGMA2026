<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AgregarCalificación
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
        Me.Lb_Persona = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Lb_ActividadCapacitacion = New System.Windows.Forms.Label()
        Me.Cb_ActividadCapacitacion = New System.Windows.Forms.ComboBox()
        Me.Lb_FechaPruebaTeorica = New System.Windows.Forms.Label()
        Me.Dtp_FechaPruebaTeorica = New System.Windows.Forms.DateTimePicker()
        Me.Lb_CalificacionPruebaTeorica = New System.Windows.Forms.Label()
        Me.Tx_CalificacionPruebaTeorica = New System.Windows.Forms.TextBox()
        Me.Tx_CalificacionPruebaPractica = New System.Windows.Forms.TextBox()
        Me.Lb_CalificacionPruebaPractica = New System.Windows.Forms.Label()
        Me.Dtp_FechaPruebaPractica = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaPruebaPractica = New System.Windows.Forms.Label()
        Me.Dtp_FechaCalificacionDirecta = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaCalificacionDirecta = New System.Windows.Forms.Label()
        Me.Cb_EntidadCertificadora = New System.Windows.Forms.ComboBox()
        Me.Lb_EntidadCertificadora = New System.Windows.Forms.Label()
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.Tx_Titulo = New System.Windows.Forms.TextBox()
        Me.Tx_NroCertificado = New System.Windows.Forms.TextBox()
        Me.Lb_NroCertificado = New System.Windows.Forms.Label()
        Me.Dtp_FechaCertificacionExterna = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaCertificacionExterna = New System.Windows.Forms.Label()
        Me.Dtp_FechaValidoHasta = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaValidoHasta = New System.Windows.Forms.Label()
        Me.Tx_Observacion = New System.Windows.Forms.TextBox()
        Me.Lb_Observacion = New System.Windows.Forms.Label()
        Me.Ck_Activo = New System.Windows.Forms.CheckBox()
        Me.Lb_FechaProgramadaInicio = New System.Windows.Forms.Label()
        Me.Dtp_FechaProgramadaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_FechaProgramadaFin = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaProgramadaFin = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lb_Persona
        '
        Me.Lb_Persona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Persona.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Persona.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Persona.Name = "Lb_Persona"
        Me.Lb_Persona.Size = New System.Drawing.Size(564, 34)
        Me.Lb_Persona.TabIndex = 0
        Me.Lb_Persona.Text = "Label1"
        Me.Lb_Persona.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 317)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(564, 30)
        Me.Panel1.TabIndex = 28
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(478, 4)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(395, 4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Info
        Me.Panel2.Controls.Add(Me.Lb_Persona)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(564, 34)
        Me.Panel2.TabIndex = 0
        '
        'Lb_ActividadCapacitacion
        '
        Me.Lb_ActividadCapacitacion.AutoSize = True
        Me.Lb_ActividadCapacitacion.Location = New System.Drawing.Point(32, 42)
        Me.Lb_ActividadCapacitacion.Name = "Lb_ActividadCapacitacion"
        Me.Lb_ActividadCapacitacion.Size = New System.Drawing.Size(119, 13)
        Me.Lb_ActividadCapacitacion.TabIndex = 1
        Me.Lb_ActividadCapacitacion.Text = "Actividad Capacitación:"
        '
        'Cb_ActividadCapacitacion
        '
        Me.Cb_ActividadCapacitacion.FormattingEnabled = True
        Me.Cb_ActividadCapacitacion.Location = New System.Drawing.Point(154, 39)
        Me.Cb_ActividadCapacitacion.Name = "Cb_ActividadCapacitacion"
        Me.Cb_ActividadCapacitacion.Size = New System.Drawing.Size(404, 21)
        Me.Cb_ActividadCapacitacion.TabIndex = 2
        '
        'Lb_FechaPruebaTeorica
        '
        Me.Lb_FechaPruebaTeorica.AutoSize = True
        Me.Lb_FechaPruebaTeorica.Location = New System.Drawing.Point(35, 68)
        Me.Lb_FechaPruebaTeorica.Name = "Lb_FechaPruebaTeorica"
        Me.Lb_FechaPruebaTeorica.Size = New System.Drawing.Size(116, 13)
        Me.Lb_FechaPruebaTeorica.TabIndex = 3
        Me.Lb_FechaPruebaTeorica.Text = "Fecha Prueba Teórica:"
        '
        'Dtp_FechaPruebaTeorica
        '
        Me.Dtp_FechaPruebaTeorica.Checked = False
        Me.Dtp_FechaPruebaTeorica.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaPruebaTeorica.Location = New System.Drawing.Point(154, 65)
        Me.Dtp_FechaPruebaTeorica.Name = "Dtp_FechaPruebaTeorica"
        Me.Dtp_FechaPruebaTeorica.ShowCheckBox = True
        Me.Dtp_FechaPruebaTeorica.Size = New System.Drawing.Size(119, 20)
        Me.Dtp_FechaPruebaTeorica.TabIndex = 4
        '
        'Lb_CalificacionPruebaTeorica
        '
        Me.Lb_CalificacionPruebaTeorica.AutoSize = True
        Me.Lb_CalificacionPruebaTeorica.Location = New System.Drawing.Point(282, 68)
        Me.Lb_CalificacionPruebaTeorica.Name = "Lb_CalificacionPruebaTeorica"
        Me.Lb_CalificacionPruebaTeorica.Size = New System.Drawing.Size(64, 13)
        Me.Lb_CalificacionPruebaTeorica.TabIndex = 5
        Me.Lb_CalificacionPruebaTeorica.Text = "Calificación:"
        '
        'Tx_CalificacionPruebaTeorica
        '
        Me.Tx_CalificacionPruebaTeorica.Location = New System.Drawing.Point(354, 64)
        Me.Tx_CalificacionPruebaTeorica.MaxLength = 6
        Me.Tx_CalificacionPruebaTeorica.Name = "Tx_CalificacionPruebaTeorica"
        Me.Tx_CalificacionPruebaTeorica.Size = New System.Drawing.Size(54, 20)
        Me.Tx_CalificacionPruebaTeorica.TabIndex = 6
        '
        'Tx_CalificacionPruebaPractica
        '
        Me.Tx_CalificacionPruebaPractica.Location = New System.Drawing.Point(354, 90)
        Me.Tx_CalificacionPruebaPractica.MaxLength = 6
        Me.Tx_CalificacionPruebaPractica.Name = "Tx_CalificacionPruebaPractica"
        Me.Tx_CalificacionPruebaPractica.Size = New System.Drawing.Size(54, 20)
        Me.Tx_CalificacionPruebaPractica.TabIndex = 10
        '
        'Lb_CalificacionPruebaPractica
        '
        Me.Lb_CalificacionPruebaPractica.AutoSize = True
        Me.Lb_CalificacionPruebaPractica.Location = New System.Drawing.Point(282, 94)
        Me.Lb_CalificacionPruebaPractica.Name = "Lb_CalificacionPruebaPractica"
        Me.Lb_CalificacionPruebaPractica.Size = New System.Drawing.Size(64, 13)
        Me.Lb_CalificacionPruebaPractica.TabIndex = 9
        Me.Lb_CalificacionPruebaPractica.Text = "Calificación:"
        '
        'Dtp_FechaPruebaPractica
        '
        Me.Dtp_FechaPruebaPractica.Checked = False
        Me.Dtp_FechaPruebaPractica.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaPruebaPractica.Location = New System.Drawing.Point(154, 90)
        Me.Dtp_FechaPruebaPractica.Name = "Dtp_FechaPruebaPractica"
        Me.Dtp_FechaPruebaPractica.ShowCheckBox = True
        Me.Dtp_FechaPruebaPractica.Size = New System.Drawing.Size(119, 20)
        Me.Dtp_FechaPruebaPractica.TabIndex = 8
        '
        'Lb_FechaPruebaPractica
        '
        Me.Lb_FechaPruebaPractica.AutoSize = True
        Me.Lb_FechaPruebaPractica.Location = New System.Drawing.Point(32, 93)
        Me.Lb_FechaPruebaPractica.Name = "Lb_FechaPruebaPractica"
        Me.Lb_FechaPruebaPractica.Size = New System.Drawing.Size(119, 13)
        Me.Lb_FechaPruebaPractica.TabIndex = 7
        Me.Lb_FechaPruebaPractica.Text = "Fecha Prueba Práctica:"
        '
        'Dtp_FechaCalificacionDirecta
        '
        Me.Dtp_FechaCalificacionDirecta.Checked = False
        Me.Dtp_FechaCalificacionDirecta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaCalificacionDirecta.Location = New System.Drawing.Point(154, 115)
        Me.Dtp_FechaCalificacionDirecta.Name = "Dtp_FechaCalificacionDirecta"
        Me.Dtp_FechaCalificacionDirecta.ShowCheckBox = True
        Me.Dtp_FechaCalificacionDirecta.Size = New System.Drawing.Size(119, 20)
        Me.Dtp_FechaCalificacionDirecta.TabIndex = 12
        '
        'Lb_FechaCalificacionDirecta
        '
        Me.Lb_FechaCalificacionDirecta.AutoSize = True
        Me.Lb_FechaCalificacionDirecta.Location = New System.Drawing.Point(17, 118)
        Me.Lb_FechaCalificacionDirecta.Name = "Lb_FechaCalificacionDirecta"
        Me.Lb_FechaCalificacionDirecta.Size = New System.Drawing.Size(134, 13)
        Me.Lb_FechaCalificacionDirecta.TabIndex = 11
        Me.Lb_FechaCalificacionDirecta.Text = "Fecha Calificación Directa:"
        '
        'Cb_EntidadCertificadora
        '
        Me.Cb_EntidadCertificadora.FormattingEnabled = True
        Me.Cb_EntidadCertificadora.Location = New System.Drawing.Point(154, 140)
        Me.Cb_EntidadCertificadora.Name = "Cb_EntidadCertificadora"
        Me.Cb_EntidadCertificadora.Size = New System.Drawing.Size(254, 21)
        Me.Cb_EntidadCertificadora.TabIndex = 14
        '
        'Lb_EntidadCertificadora
        '
        Me.Lb_EntidadCertificadora.AutoSize = True
        Me.Lb_EntidadCertificadora.Location = New System.Drawing.Point(43, 143)
        Me.Lb_EntidadCertificadora.Name = "Lb_EntidadCertificadora"
        Me.Lb_EntidadCertificadora.Size = New System.Drawing.Size(108, 13)
        Me.Lb_EntidadCertificadora.TabIndex = 13
        Me.Lb_EntidadCertificadora.Text = "Entidad Certificadora:"
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.AutoSize = True
        Me.Lb_Titulo.Location = New System.Drawing.Point(115, 169)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(38, 13)
        Me.Lb_Titulo.TabIndex = 15
        Me.Lb_Titulo.Text = "Título:"
        '
        'Tx_Titulo
        '
        Me.Tx_Titulo.Location = New System.Drawing.Point(154, 166)
        Me.Tx_Titulo.MaxLength = 100
        Me.Tx_Titulo.Name = "Tx_Titulo"
        Me.Tx_Titulo.Size = New System.Drawing.Size(404, 20)
        Me.Tx_Titulo.TabIndex = 16
        '
        'Tx_NroCertificado
        '
        Me.Tx_NroCertificado.Location = New System.Drawing.Point(154, 191)
        Me.Tx_NroCertificado.MaxLength = 50
        Me.Tx_NroCertificado.Name = "Tx_NroCertificado"
        Me.Tx_NroCertificado.Size = New System.Drawing.Size(201, 20)
        Me.Tx_NroCertificado.TabIndex = 18
        '
        'Lb_NroCertificado
        '
        Me.Lb_NroCertificado.AutoSize = True
        Me.Lb_NroCertificado.Location = New System.Drawing.Point(71, 194)
        Me.Lb_NroCertificado.Name = "Lb_NroCertificado"
        Me.Lb_NroCertificado.Size = New System.Drawing.Size(80, 13)
        Me.Lb_NroCertificado.TabIndex = 17
        Me.Lb_NroCertificado.Text = "No. Certificado:"
        '
        'Dtp_FechaCertificacionExterna
        '
        Me.Dtp_FechaCertificacionExterna.Checked = False
        Me.Dtp_FechaCertificacionExterna.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaCertificacionExterna.Location = New System.Drawing.Point(154, 215)
        Me.Dtp_FechaCertificacionExterna.Name = "Dtp_FechaCertificacionExterna"
        Me.Dtp_FechaCertificacionExterna.ShowCheckBox = True
        Me.Dtp_FechaCertificacionExterna.Size = New System.Drawing.Size(119, 20)
        Me.Dtp_FechaCertificacionExterna.TabIndex = 20
        '
        'Lb_FechaCertificacionExterna
        '
        Me.Lb_FechaCertificacionExterna.AutoSize = True
        Me.Lb_FechaCertificacionExterna.Location = New System.Drawing.Point(11, 218)
        Me.Lb_FechaCertificacionExterna.Name = "Lb_FechaCertificacionExterna"
        Me.Lb_FechaCertificacionExterna.Size = New System.Drawing.Size(140, 13)
        Me.Lb_FechaCertificacionExterna.TabIndex = 19
        Me.Lb_FechaCertificacionExterna.Text = "Fecha Certificación Externa:"
        '
        'Dtp_FechaValidoHasta
        '
        Me.Dtp_FechaValidoHasta.Checked = False
        Me.Dtp_FechaValidoHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaValidoHasta.Location = New System.Drawing.Point(354, 215)
        Me.Dtp_FechaValidoHasta.Name = "Dtp_FechaValidoHasta"
        Me.Dtp_FechaValidoHasta.ShowCheckBox = True
        Me.Dtp_FechaValidoHasta.Size = New System.Drawing.Size(119, 20)
        Me.Dtp_FechaValidoHasta.TabIndex = 22
        '
        'Lb_FechaValidoHasta
        '
        Me.Lb_FechaValidoHasta.AutoSize = True
        Me.Lb_FechaValidoHasta.Location = New System.Drawing.Point(281, 218)
        Me.Lb_FechaValidoHasta.Name = "Lb_FechaValidoHasta"
        Me.Lb_FechaValidoHasta.Size = New System.Drawing.Size(70, 13)
        Me.Lb_FechaValidoHasta.TabIndex = 21
        Me.Lb_FechaValidoHasta.Text = "Válida Hasta:"
        '
        'Tx_Observacion
        '
        Me.Tx_Observacion.Location = New System.Drawing.Point(154, 241)
        Me.Tx_Observacion.MaxLength = 100
        Me.Tx_Observacion.Multiline = True
        Me.Tx_Observacion.Name = "Tx_Observacion"
        Me.Tx_Observacion.Size = New System.Drawing.Size(404, 40)
        Me.Tx_Observacion.TabIndex = 24
        '
        'Lb_Observacion
        '
        Me.Lb_Observacion.AutoSize = True
        Me.Lb_Observacion.Location = New System.Drawing.Point(81, 244)
        Me.Lb_Observacion.Name = "Lb_Observacion"
        Me.Lb_Observacion.Size = New System.Drawing.Size(70, 13)
        Me.Lb_Observacion.TabIndex = 23
        Me.Lb_Observacion.Text = "Observación:"
        '
        'Ck_Activo
        '
        Me.Ck_Activo.AutoSize = True
        Me.Ck_Activo.Checked = True
        Me.Ck_Activo.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_Activo.Location = New System.Drawing.Point(502, 289)
        Me.Ck_Activo.Name = "Ck_Activo"
        Me.Ck_Activo.Size = New System.Drawing.Size(56, 17)
        Me.Ck_Activo.TabIndex = 27
        Me.Ck_Activo.Text = "Activo"
        Me.Ck_Activo.UseVisualStyleBackColor = True
        '
        'Lb_FechaProgramadaInicio
        '
        Me.Lb_FechaProgramadaInicio.AutoSize = True
        Me.Lb_FechaProgramadaInicio.Location = New System.Drawing.Point(51, 290)
        Me.Lb_FechaProgramadaInicio.Name = "Lb_FechaProgramadaInicio"
        Me.Lb_FechaProgramadaInicio.Size = New System.Drawing.Size(100, 13)
        Me.Lb_FechaProgramadaInicio.TabIndex = 25
        Me.Lb_FechaProgramadaInicio.Text = "Fecha Programada:"
        '
        'Dtp_FechaProgramadaInicio
        '
        Me.Dtp_FechaProgramadaInicio.Checked = False
        Me.Dtp_FechaProgramadaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaProgramadaInicio.Location = New System.Drawing.Point(154, 287)
        Me.Dtp_FechaProgramadaInicio.Name = "Dtp_FechaProgramadaInicio"
        Me.Dtp_FechaProgramadaInicio.ShowCheckBox = True
        Me.Dtp_FechaProgramadaInicio.Size = New System.Drawing.Size(119, 20)
        Me.Dtp_FechaProgramadaInicio.TabIndex = 26
        '
        'Dtp_FechaProgramadaFin
        '
        Me.Dtp_FechaProgramadaFin.Checked = False
        Me.Dtp_FechaProgramadaFin.Enabled = False
        Me.Dtp_FechaProgramadaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaProgramadaFin.Location = New System.Drawing.Point(318, 287)
        Me.Dtp_FechaProgramadaFin.Name = "Dtp_FechaProgramadaFin"
        Me.Dtp_FechaProgramadaFin.ShowCheckBox = True
        Me.Dtp_FechaProgramadaFin.Size = New System.Drawing.Size(119, 20)
        Me.Dtp_FechaProgramadaFin.TabIndex = 30
        '
        'Lb_FechaProgramadaFin
        '
        Me.Lb_FechaProgramadaFin.AutoSize = True
        Me.Lb_FechaProgramadaFin.Location = New System.Drawing.Point(279, 290)
        Me.Lb_FechaProgramadaFin.Name = "Lb_FechaProgramadaFin"
        Me.Lb_FechaProgramadaFin.Size = New System.Drawing.Size(36, 13)
        Me.Lb_FechaProgramadaFin.TabIndex = 29
        Me.Lb_FechaProgramadaFin.Text = "hasta:"
        '
        'Fr_AgregarCalificación
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 347)
        Me.Controls.Add(Me.Dtp_FechaProgramadaFin)
        Me.Controls.Add(Me.Lb_FechaProgramadaFin)
        Me.Controls.Add(Me.Ck_Activo)
        Me.Controls.Add(Me.Dtp_FechaProgramadaInicio)
        Me.Controls.Add(Me.Lb_FechaProgramadaInicio)
        Me.Controls.Add(Me.Tx_Observacion)
        Me.Controls.Add(Me.Lb_Observacion)
        Me.Controls.Add(Me.Dtp_FechaValidoHasta)
        Me.Controls.Add(Me.Lb_FechaValidoHasta)
        Me.Controls.Add(Me.Dtp_FechaCertificacionExterna)
        Me.Controls.Add(Me.Lb_FechaCertificacionExterna)
        Me.Controls.Add(Me.Tx_NroCertificado)
        Me.Controls.Add(Me.Lb_NroCertificado)
        Me.Controls.Add(Me.Tx_Titulo)
        Me.Controls.Add(Me.Lb_Titulo)
        Me.Controls.Add(Me.Cb_EntidadCertificadora)
        Me.Controls.Add(Me.Lb_EntidadCertificadora)
        Me.Controls.Add(Me.Dtp_FechaCalificacionDirecta)
        Me.Controls.Add(Me.Lb_FechaCalificacionDirecta)
        Me.Controls.Add(Me.Tx_CalificacionPruebaPractica)
        Me.Controls.Add(Me.Lb_CalificacionPruebaPractica)
        Me.Controls.Add(Me.Dtp_FechaPruebaPractica)
        Me.Controls.Add(Me.Lb_FechaPruebaPractica)
        Me.Controls.Add(Me.Tx_CalificacionPruebaTeorica)
        Me.Controls.Add(Me.Lb_CalificacionPruebaTeorica)
        Me.Controls.Add(Me.Dtp_FechaPruebaTeorica)
        Me.Controls.Add(Me.Lb_FechaPruebaTeorica)
        Me.Controls.Add(Me.Cb_ActividadCapacitacion)
        Me.Controls.Add(Me.Lb_ActividadCapacitacion)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_AgregarCalificación"
        Me.ShowIcon = False
        Me.Text = "Agregar Calificación"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lb_Persona As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Lb_ActividadCapacitacion As System.Windows.Forms.Label
    Friend WithEvents Cb_ActividadCapacitacion As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_FechaPruebaTeorica As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaPruebaTeorica As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_CalificacionPruebaTeorica As System.Windows.Forms.Label
    Friend WithEvents Tx_CalificacionPruebaTeorica As System.Windows.Forms.TextBox
    Friend WithEvents Tx_CalificacionPruebaPractica As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CalificacionPruebaPractica As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaPruebaPractica As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaPruebaPractica As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaCalificacionDirecta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaCalificacionDirecta As System.Windows.Forms.Label
    Friend WithEvents Cb_EntidadCertificadora As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_EntidadCertificadora As System.Windows.Forms.Label
    Friend WithEvents Lb_Titulo As System.Windows.Forms.Label
    Friend WithEvents Tx_Titulo As System.Windows.Forms.TextBox
    Friend WithEvents Tx_NroCertificado As System.Windows.Forms.TextBox
    Friend WithEvents Lb_NroCertificado As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaCertificacionExterna As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaCertificacionExterna As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaValidoHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaValidoHasta As System.Windows.Forms.Label
    Friend WithEvents Tx_Observacion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Observacion As System.Windows.Forms.Label
    Friend WithEvents Ck_Activo As System.Windows.Forms.CheckBox
    Friend WithEvents Lb_FechaProgramadaInicio As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaProgramadaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_FechaProgramadaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaProgramadaFin As System.Windows.Forms.Label
End Class
