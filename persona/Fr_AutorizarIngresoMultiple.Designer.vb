<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AutorizarIngresoMultiple
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
        Me.PanelConceptoMedico = New System.Windows.Forms.Panel()
        Me.PanelDatos = New System.Windows.Forms.Panel()
        Me.Label_NroPregunta = New System.Windows.Forms.Label()
        Me.Cb_NroPregunta = New System.Windows.Forms.ComboBox()
        Me.LabelPregunta = New System.Windows.Forms.Label()
        Me.Tb_Pregunta = New System.Windows.Forms.TextBox()
        Me.LabelFechaI = New System.Windows.Forms.Label()
        Me.Dtp_FechaI = New System.Windows.Forms.DateTimePicker()
        Me.LabelFechaF = New System.Windows.Forms.Label()
        Me.Dtp_FechaF = New System.Windows.Forms.DateTimePicker()
        Me.LabelConceptoMedico = New System.Windows.Forms.Label()
        Me.Tb_ConceptoMedico = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Label_Cedula = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label_Nombre = New System.Windows.Forms.Label()
        Me.PanelConceptoMedico.SuspendLayout()
        Me.PanelDatos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelConceptoMedico
        '
        Me.PanelConceptoMedico.BackColor = System.Drawing.SystemColors.Control
        Me.PanelConceptoMedico.Controls.Add(Me.PanelDatos)
        Me.PanelConceptoMedico.Controls.Add(Me.Panel2)
        Me.PanelConceptoMedico.Controls.Add(Me.Panel1)
        Me.PanelConceptoMedico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelConceptoMedico.Location = New System.Drawing.Point(0, 0)
        Me.PanelConceptoMedico.Name = "PanelConceptoMedico"
        Me.PanelConceptoMedico.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelConceptoMedico.Size = New System.Drawing.Size(554, 299)
        Me.PanelConceptoMedico.TabIndex = 0
        '
        'PanelDatos
        '
        Me.PanelDatos.BackColor = System.Drawing.Color.Transparent
        Me.PanelDatos.Controls.Add(Me.Label_NroPregunta)
        Me.PanelDatos.Controls.Add(Me.Cb_NroPregunta)
        Me.PanelDatos.Controls.Add(Me.LabelPregunta)
        Me.PanelDatos.Controls.Add(Me.Tb_Pregunta)
        Me.PanelDatos.Controls.Add(Me.LabelFechaI)
        Me.PanelDatos.Controls.Add(Me.Dtp_FechaI)
        Me.PanelDatos.Controls.Add(Me.LabelFechaF)
        Me.PanelDatos.Controls.Add(Me.Dtp_FechaF)
        Me.PanelDatos.Controls.Add(Me.LabelConceptoMedico)
        Me.PanelDatos.Controls.Add(Me.Tb_ConceptoMedico)
        Me.PanelDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDatos.Location = New System.Drawing.Point(2, 31)
        Me.PanelDatos.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelDatos.Name = "PanelDatos"
        Me.PanelDatos.Padding = New System.Windows.Forms.Padding(1)
        Me.PanelDatos.Size = New System.Drawing.Size(550, 232)
        Me.PanelDatos.TabIndex = 15
        '
        'Label_NroPregunta
        '
        Me.Label_NroPregunta.AutoSize = True
        Me.Label_NroPregunta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_NroPregunta.Location = New System.Drawing.Point(28, 7)
        Me.Label_NroPregunta.Name = "Label_NroPregunta"
        Me.Label_NroPregunta.Size = New System.Drawing.Size(83, 15)
        Me.Label_NroPregunta.TabIndex = 2
        Me.Label_NroPregunta.Text = "Nro Pregunta:"
        '
        'Cb_NroPregunta
        '
        Me.Cb_NroPregunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_NroPregunta.FormattingEnabled = True
        Me.Cb_NroPregunta.Location = New System.Drawing.Point(114, 4)
        Me.Cb_NroPregunta.Name = "Cb_NroPregunta"
        Me.Cb_NroPregunta.Size = New System.Drawing.Size(52, 21)
        Me.Cb_NroPregunta.TabIndex = 1
        '
        'LabelPregunta
        '
        Me.LabelPregunta.AutoSize = True
        Me.LabelPregunta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPregunta.Location = New System.Drawing.Point(52, 33)
        Me.LabelPregunta.Name = "LabelPregunta"
        Me.LabelPregunta.Size = New System.Drawing.Size(60, 15)
        Me.LabelPregunta.TabIndex = 4
        Me.LabelPregunta.Text = "Pregunta:"
        '
        'Tb_Pregunta
        '
        Me.Tb_Pregunta.Location = New System.Drawing.Point(114, 30)
        Me.Tb_Pregunta.Multiline = True
        Me.Tb_Pregunta.Name = "Tb_Pregunta"
        Me.Tb_Pregunta.Size = New System.Drawing.Size(429, 48)
        Me.Tb_Pregunta.TabIndex = 5
        '
        'LabelFechaI
        '
        Me.LabelFechaI.AutoSize = True
        Me.LabelFechaI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFechaI.Location = New System.Drawing.Point(32, 86)
        Me.LabelFechaI.Name = "LabelFechaI"
        Me.LabelFechaI.Size = New System.Drawing.Size(79, 15)
        Me.LabelFechaI.TabIndex = 6
        Me.LabelFechaI.Text = "Fecha Inicial:"
        '
        'Dtp_FechaI
        '
        Me.Dtp_FechaI.Location = New System.Drawing.Point(114, 83)
        Me.Dtp_FechaI.MinDate = New Date(2020, 5, 1, 0, 0, 0, 0)
        Me.Dtp_FechaI.Name = "Dtp_FechaI"
        Me.Dtp_FechaI.Size = New System.Drawing.Size(200, 20)
        Me.Dtp_FechaI.TabIndex = 7
        '
        'LabelFechaF
        '
        Me.LabelFechaF.AutoSize = True
        Me.LabelFechaF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFechaF.Location = New System.Drawing.Point(37, 111)
        Me.LabelFechaF.Name = "LabelFechaF"
        Me.LabelFechaF.Size = New System.Drawing.Size(74, 15)
        Me.LabelFechaF.TabIndex = 8
        Me.LabelFechaF.Text = "Fecha Final:"
        '
        'Dtp_FechaF
        '
        Me.Dtp_FechaF.Location = New System.Drawing.Point(114, 108)
        Me.Dtp_FechaF.MinDate = New Date(2020, 5, 26, 0, 0, 0, 0)
        Me.Dtp_FechaF.Name = "Dtp_FechaF"
        Me.Dtp_FechaF.Size = New System.Drawing.Size(200, 20)
        Me.Dtp_FechaF.TabIndex = 9
        '
        'LabelConceptoMedico
        '
        Me.LabelConceptoMedico.AutoSize = True
        Me.LabelConceptoMedico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConceptoMedico.Location = New System.Drawing.Point(5, 136)
        Me.LabelConceptoMedico.Name = "LabelConceptoMedico"
        Me.LabelConceptoMedico.Size = New System.Drawing.Size(106, 15)
        Me.LabelConceptoMedico.TabIndex = 10
        Me.LabelConceptoMedico.Text = "Concepto Médico:"
        '
        'Tb_ConceptoMedico
        '
        Me.Tb_ConceptoMedico.Location = New System.Drawing.Point(114, 133)
        Me.Tb_ConceptoMedico.MaxLength = 300
        Me.Tb_ConceptoMedico.Multiline = True
        Me.Tb_ConceptoMedico.Name = "Tb_ConceptoMedico"
        Me.Tb_ConceptoMedico.Size = New System.Drawing.Size(429, 90)
        Me.Tb_ConceptoMedico.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel2.Controls.Add(Me.Bt_Cerrar)
        Me.Panel2.Controls.Add(Me.Label_Cedula)
        Me.Panel2.Controls.Add(Me.Bt_Guardar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(2, 263)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(550, 34)
        Me.Panel2.TabIndex = 17
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(468, 6)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 13
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Label_Cedula
        '
        Me.Label_Cedula.AutoSize = True
        Me.Label_Cedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Cedula.Location = New System.Drawing.Point(10, 9)
        Me.Label_Cedula.Name = "Label_Cedula"
        Me.Label_Cedula.Size = New System.Drawing.Size(97, 15)
        Me.Label_Cedula.TabIndex = 1
        Me.Label_Cedula.Text = "Identificación:"
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(387, 6)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 12
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel1.Controls.Add(Me.Label_Nombre)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 29)
        Me.Panel1.TabIndex = 16
        '
        'Label_Nombre
        '
        Me.Label_Nombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Nombre.ForeColor = System.Drawing.Color.Black
        Me.Label_Nombre.Location = New System.Drawing.Point(0, 0)
        Me.Label_Nombre.Name = "Label_Nombre"
        Me.Label_Nombre.Size = New System.Drawing.Size(550, 27)
        Me.Label_Nombre.TabIndex = 0
        Me.Label_Nombre.Text = "XXXXXXXXXX XXXXXXXXXX XXXXXXXXXX XXXXXXXXXX"
        Me.Label_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Fr_AutorizarIngresoMultiple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 299)
        Me.Controls.Add(Me.PanelConceptoMedico)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(570, 338)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(570, 338)
        Me.Name = "Fr_AutorizarIngresoMultiple"
        Me.Text = "Autorizar Ingreso Multiple"
        Me.PanelConceptoMedico.ResumeLayout(False)
        Me.PanelDatos.ResumeLayout(False)
        Me.PanelDatos.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelConceptoMedico As System.Windows.Forms.Panel
    Friend WithEvents Label_Nombre As System.Windows.Forms.Label
    Friend WithEvents Label_NroPregunta As System.Windows.Forms.Label
    Friend WithEvents Label_Cedula As System.Windows.Forms.Label
    Friend WithEvents Tb_Pregunta As System.Windows.Forms.TextBox
    Friend WithEvents LabelPregunta As System.Windows.Forms.Label
    Friend WithEvents Cb_NroPregunta As System.Windows.Forms.ComboBox
    Friend WithEvents LabelFechaF As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaI As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelFechaI As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaF As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelConceptoMedico As System.Windows.Forms.Label
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Tb_ConceptoMedico As System.Windows.Forms.TextBox
    Friend WithEvents PanelDatos As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
