<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Encuesta
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Tlp_DatosPersona = New System.Windows.Forms.TableLayoutPanel()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Flp_Identificacion = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_TextoIdentificacion = New System.Windows.Forms.Label()
        Me.Lb_Identificacion = New System.Windows.Forms.Label()
        Me.Lb_TextoFechaEnvio = New System.Windows.Forms.Label()
        Me.Dtp_Encuesta = New System.Windows.Forms.DateTimePicker()
        Me.Lb_TextoMotivo = New System.Windows.Forms.Label()
        Me.Cb_Base = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoOtros = New System.Windows.Forms.Label()
        Me.Tx_Cargo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NUD_Edad = New System.Windows.Forms.NumericUpDown()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tx_Proyecto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Bt_CrearyEnviar = New System.Windows.Forms.Button()
        Me.Tx_CorreoElectrónico = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dgv_Encuesta = New System.Windows.Forms.DataGridView()
        Me.DGVTBX_IDPREGUNTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_PREGUNTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_SI = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DGVTBC_NO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DGVTBC_ORDEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tlp_DatosPersona.SuspendLayout()
        Me.Flp_Identificacion.SuspendLayout()
        CType(Me.NUD_Edad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_Encuesta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tlp_DatosPersona
        '
        Me.Tlp_DatosPersona.ColumnCount = 2
        Me.Tlp_DatosPersona.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.35699!))
        Me.Tlp_DatosPersona.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.643!))
        Me.Tlp_DatosPersona.Controls.Add(Me.Lb_Nombre, 0, 0)
        Me.Tlp_DatosPersona.Controls.Add(Me.Flp_Identificacion, 1, 0)
        Me.Tlp_DatosPersona.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tlp_DatosPersona.Location = New System.Drawing.Point(0, 0)
        Me.Tlp_DatosPersona.Name = "Tlp_DatosPersona"
        Me.Tlp_DatosPersona.RowCount = 1
        Me.Tlp_DatosPersona.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_DatosPersona.Size = New System.Drawing.Size(640, 30)
        Me.Tlp_DatosPersona.TabIndex = 1
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Nombre.Location = New System.Drawing.Point(3, 0)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(431, 30)
        Me.Lb_Nombre.TabIndex = 0
        Me.Lb_Nombre.Text = "XXXXXXXXXX XXXXXXXXXX XXXXXXXXXX XXXXXXXXXX"
        Me.Lb_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Flp_Identificacion
        '
        Me.Flp_Identificacion.Controls.Add(Me.Lb_TextoIdentificacion)
        Me.Flp_Identificacion.Controls.Add(Me.Lb_Identificacion)
        Me.Flp_Identificacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.Flp_Identificacion.Location = New System.Drawing.Point(438, 0)
        Me.Flp_Identificacion.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Identificacion.Name = "Flp_Identificacion"
        Me.Flp_Identificacion.Padding = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.Flp_Identificacion.Size = New System.Drawing.Size(202, 30)
        Me.Flp_Identificacion.TabIndex = 1
        '
        'Lb_TextoIdentificacion
        '
        Me.Lb_TextoIdentificacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_TextoIdentificacion.AutoSize = True
        Me.Lb_TextoIdentificacion.Location = New System.Drawing.Point(3, 4)
        Me.Lb_TextoIdentificacion.Name = "Lb_TextoIdentificacion"
        Me.Lb_TextoIdentificacion.Size = New System.Drawing.Size(73, 20)
        Me.Lb_TextoIdentificacion.TabIndex = 0
        Me.Lb_TextoIdentificacion.Text = "Identificación:"
        Me.Lb_TextoIdentificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_Identificacion
        '
        Me.Lb_Identificacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_Identificacion.AutoSize = True
        Me.Lb_Identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Identificacion.Location = New System.Drawing.Point(82, 4)
        Me.Lb_Identificacion.Name = "Lb_Identificacion"
        Me.Lb_Identificacion.Size = New System.Drawing.Size(111, 20)
        Me.Lb_Identificacion.TabIndex = 1
        Me.Lb_Identificacion.Text = "8.888.888.888"
        Me.Lb_Identificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_TextoFechaEnvio
        '
        Me.Lb_TextoFechaEnvio.AutoSize = True
        Me.Lb_TextoFechaEnvio.Location = New System.Drawing.Point(6, 50)
        Me.Lb_TextoFechaEnvio.Name = "Lb_TextoFechaEnvio"
        Me.Lb_TextoFechaEnvio.Size = New System.Drawing.Size(103, 13)
        Me.Lb_TextoFechaEnvio.TabIndex = 4
        Me.Lb_TextoFechaEnvio.Text = "Fecha de Encuesta:"
        '
        'Dtp_Encuesta
        '
        Me.Dtp_Encuesta.Enabled = False
        Me.Dtp_Encuesta.Location = New System.Drawing.Point(110, 47)
        Me.Dtp_Encuesta.Name = "Dtp_Encuesta"
        Me.Dtp_Encuesta.Size = New System.Drawing.Size(204, 20)
        Me.Dtp_Encuesta.TabIndex = 3
        '
        'Lb_TextoMotivo
        '
        Me.Lb_TextoMotivo.AutoSize = True
        Me.Lb_TextoMotivo.Location = New System.Drawing.Point(323, 6)
        Me.Lb_TextoMotivo.Name = "Lb_TextoMotivo"
        Me.Lb_TextoMotivo.Size = New System.Drawing.Size(34, 13)
        Me.Lb_TextoMotivo.TabIndex = 6
        Me.Lb_TextoMotivo.Text = "Base:"
        '
        'Cb_Base
        '
        Me.Cb_Base.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Base.FormattingEnabled = True
        Me.Cb_Base.Location = New System.Drawing.Point(358, 3)
        Me.Cb_Base.Name = "Cb_Base"
        Me.Cb_Base.Size = New System.Drawing.Size(144, 21)
        Me.Cb_Base.TabIndex = 1
        '
        'Lb_TextoOtros
        '
        Me.Lb_TextoOtros.AutoSize = True
        Me.Lb_TextoOtros.Location = New System.Drawing.Point(70, 28)
        Me.Lb_TextoOtros.Name = "Lb_TextoOtros"
        Me.Lb_TextoOtros.Size = New System.Drawing.Size(38, 13)
        Me.Lb_TextoOtros.TabIndex = 8
        Me.Lb_TextoOtros.Text = "Cargo:"
        '
        'Tx_Cargo
        '
        Me.Tx_Cargo.Location = New System.Drawing.Point(110, 26)
        Me.Tx_Cargo.MaxLength = 100
        Me.Tx_Cargo.Name = "Tx_Cargo"
        Me.Tx_Cargo.Size = New System.Drawing.Size(392, 20)
        Me.Tx_Cargo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(367, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Edad:"
        '
        'NUD_Edad
        '
        Me.NUD_Edad.Location = New System.Drawing.Point(406, 48)
        Me.NUD_Edad.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.NUD_Edad.Minimum = New Decimal(New Integer() {18, 0, 0, 0})
        Me.NUD_Edad.Name = "NUD_Edad"
        Me.NUD_Edad.Size = New System.Drawing.Size(34, 20)
        Me.NUD_Edad.TabIndex = 11
        Me.NUD_Edad.Value = New Decimal(New Integer() {18, 0, 0, 0})
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Tx_Proyecto)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Bt_CrearyEnviar)
        Me.Panel1.Controls.Add(Me.Tx_CorreoElectrónico)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Cb_Base)
        Me.Panel1.Controls.Add(Me.NUD_Edad)
        Me.Panel1.Controls.Add(Me.Dtp_Encuesta)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Lb_TextoFechaEnvio)
        Me.Panel1.Controls.Add(Me.Lb_TextoOtros)
        Me.Panel1.Controls.Add(Me.Lb_TextoMotivo)
        Me.Panel1.Controls.Add(Me.Tx_Cargo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 125)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Proyecto:"
        '
        'Tx_Proyecto
        '
        Me.Tx_Proyecto.Location = New System.Drawing.Point(110, 3)
        Me.Tx_Proyecto.MaxLength = 50
        Me.Tx_Proyecto.Name = "Tx_Proyecto"
        Me.Tx_Proyecto.Size = New System.Drawing.Size(204, 20)
        Me.Tx_Proyecto.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Info
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label3.Location = New System.Drawing.Point(0, 93)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(640, 32)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "La encuesta es adelantada por personal de salud de ISMOCOL S.A y la movilidad es " & _
    "aprobada únicamente por la Coordinación Médica  y comunicada a la Alta Gerencia." & _
    ""
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bt_CrearyEnviar
        '
        Me.Bt_CrearyEnviar.Location = New System.Drawing.Point(448, 65)
        Me.Bt_CrearyEnviar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_CrearyEnviar.Name = "Bt_CrearyEnviar"
        Me.Bt_CrearyEnviar.Size = New System.Drawing.Size(91, 23)
        Me.Bt_CrearyEnviar.TabIndex = 5
        Me.Bt_CrearyEnviar.Text = "Crear y Enviar"
        Me.Bt_CrearyEnviar.UseVisualStyleBackColor = True
        Me.Bt_CrearyEnviar.Visible = False
        '
        'Tx_CorreoElectrónico
        '
        Me.Tx_CorreoElectrónico.Location = New System.Drawing.Point(110, 68)
        Me.Tx_CorreoElectrónico.MaxLength = 100
        Me.Tx_CorreoElectrónico.Name = "Tx_CorreoElectrónico"
        Me.Tx_CorreoElectrónico.Size = New System.Drawing.Size(332, 20)
        Me.Tx_CorreoElectrónico.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Correo Electrónico:"
        '
        'Dgv_Encuesta
        '
        Me.Dgv_Encuesta.AllowUserToAddRows = False
        Me.Dgv_Encuesta.AllowUserToDeleteRows = False
        Me.Dgv_Encuesta.AllowUserToResizeColumns = False
        Me.Dgv_Encuesta.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Encuesta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Encuesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Encuesta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBX_IDPREGUNTA, Me.DGVTBC_PREGUNTA, Me.DGVTBC_SI, Me.DGVTBC_NO, Me.DGVTBC_ORDEN})
        Me.Dgv_Encuesta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Encuesta.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Encuesta.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Dgv_Encuesta.Name = "Dgv_Encuesta"
        Me.Dgv_Encuesta.RowTemplate.Height = 24
        Me.Dgv_Encuesta.Size = New System.Drawing.Size(640, 335)
        Me.Dgv_Encuesta.TabIndex = 0
        '
        'DGVTBX_IDPREGUNTA
        '
        Me.DGVTBX_IDPREGUNTA.DataPropertyName = "idpregunta"
        Me.DGVTBX_IDPREGUNTA.HeaderText = "Id"
        Me.DGVTBX_IDPREGUNTA.Name = "DGVTBX_IDPREGUNTA"
        Me.DGVTBX_IDPREGUNTA.Visible = False
        Me.DGVTBX_IDPREGUNTA.Width = 48
        '
        'DGVTBC_PREGUNTA
        '
        Me.DGVTBC_PREGUNTA.DataPropertyName = "pregunta"
        Me.DGVTBC_PREGUNTA.FillWeight = 176.7391!
        Me.DGVTBC_PREGUNTA.HeaderText = "Pregunta"
        Me.DGVTBC_PREGUNTA.Name = "DGVTBC_PREGUNTA"
        '
        'DGVTBC_SI
        '
        Me.DGVTBC_SI.DataPropertyName = "OPCION_SI"
        Me.DGVTBC_SI.FalseValue = ""
        Me.DGVTBC_SI.FillWeight = 62.34723!
        Me.DGVTBC_SI.HeaderText = "SI"
        Me.DGVTBC_SI.Name = "DGVTBC_SI"
        Me.DGVTBC_SI.TrueValue = "X"
        Me.DGVTBC_SI.Width = 40
        '
        'DGVTBC_NO
        '
        Me.DGVTBC_NO.DataPropertyName = "OPCION_NO"
        Me.DGVTBC_NO.FalseValue = ""
        Me.DGVTBC_NO.FillWeight = 60.9137!
        Me.DGVTBC_NO.HeaderText = "NO"
        Me.DGVTBC_NO.Name = "DGVTBC_NO"
        Me.DGVTBC_NO.TrueValue = "X"
        Me.DGVTBC_NO.Width = 40
        '
        'DGVTBC_ORDEN
        '
        Me.DGVTBC_ORDEN.DataPropertyName = "orden"
        Me.DGVTBC_ORDEN.HeaderText = "orden"
        Me.DGVTBC_ORDEN.Name = "DGVTBC_ORDEN"
        Me.DGVTBC_ORDEN.Visible = False
        Me.DGVTBC_ORDEN.Width = 74
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel2.Controls.Add(Me.Bt_Guardar)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 490)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(640, 33)
        Me.Panel2.TabIndex = 13
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(490, 5)
        Me.Bt_Guardar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(68, 23)
        Me.Bt_Guardar.TabIndex = 16
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(562, 5)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.Dgv_Encuesta)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 155)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(640, 335)
        Me.Panel3.TabIndex = 14
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "idpregunta"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 48
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "pregunta"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Pregunta"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 24
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "orden"
        Me.DataGridViewTextBoxColumn3.HeaderText = "orden"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 74
        '
        'Fr_Encuesta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 523)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Tlp_DatosPersona)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximumSize = New System.Drawing.Size(656, 569)
        Me.MinimumSize = New System.Drawing.Size(656, 557)
        Me.Name = "Fr_Encuesta"
        Me.Text = "APLICACIÓN PREVENTIVA PARA EVITAR CONTAGIO CON COVID-19"
        Me.Tlp_DatosPersona.ResumeLayout(False)
        Me.Tlp_DatosPersona.PerformLayout()
        Me.Flp_Identificacion.ResumeLayout(False)
        Me.Flp_Identificacion.PerformLayout()
        CType(Me.NUD_Edad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Dgv_Encuesta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tlp_DatosPersona As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Flp_Identificacion As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_TextoIdentificacion As System.Windows.Forms.Label
    Friend WithEvents Lb_Identificacion As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoFechaEnvio As System.Windows.Forms.Label
    Friend WithEvents Dtp_Encuesta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_TextoMotivo As System.Windows.Forms.Label
    Friend WithEvents Cb_Base As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoOtros As System.Windows.Forms.Label
    Friend WithEvents Tx_Cargo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NUD_Edad As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_CrearyEnviar As System.Windows.Forms.Button
    Friend WithEvents Tx_CorreoElectrónico As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Encuesta As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGVTBX_IDPREGUNTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_PREGUNTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_SI As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DGVTBC_NO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DGVTBC_ORDEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tx_Proyecto As System.Windows.Forms.TextBox
End Class
