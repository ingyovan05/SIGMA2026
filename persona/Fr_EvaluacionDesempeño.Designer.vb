<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_EvaluacionDesempeño
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Tx_CorreoEvaluador = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tx_CargoEvaluador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tx_Proyecto = New System.Windows.Forms.TextBox()
        Me.Tx_Periodo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cb_Estado = New System.Windows.Forms.ComboBox()
        Me.Lb_Correo = New System.Windows.Forms.Label()
        Me.Lb_TextoOtros = New System.Windows.Forms.Label()
        Me.Lb_estado = New System.Windows.Forms.Label()
        Me.Tx_CargoEvaluado = New System.Windows.Forms.TextBox()
        Me.Cu_BuscarEvaluado = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_AsociarPersonaEvaluada = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarEvaluador = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_AsociarPersonaEvalua = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel2.Controls.Add(Me.Bt_Guardar)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 225)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(570, 33)
        Me.Panel2.TabIndex = 14
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(423, 4)
        Me.Bt_Guardar.Margin = New System.Windows.Forms.Padding(2)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(68, 23)
        Me.Bt_Guardar.TabIndex = 16
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(495, 4)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel1.Controls.Add(Me.Tx_CorreoEvaluador)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Tx_CargoEvaluador)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Cu_BuscarEvaluado)
        Me.Panel1.Controls.Add(Me.Cu_AsociarPersonaEvaluada)
        Me.Panel1.Controls.Add(Me.Cu_BuscarEvaluador)
        Me.Panel1.Controls.Add(Me.Cu_AsociarPersonaEvalua)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Tx_Proyecto)
        Me.Panel1.Controls.Add(Me.Tx_Periodo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Cb_Estado)
        Me.Panel1.Controls.Add(Me.Lb_Correo)
        Me.Panel1.Controls.Add(Me.Lb_TextoOtros)
        Me.Panel1.Controls.Add(Me.Lb_estado)
        Me.Panel1.Controls.Add(Me.Tx_CargoEvaluado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(570, 225)
        Me.Panel1.TabIndex = 15
        '
        'Tx_CorreoEvaluador
        '
        Me.Tx_CorreoEvaluador.Location = New System.Drawing.Point(111, 169)
        Me.Tx_CorreoEvaluador.MaxLength = 50
        Me.Tx_CorreoEvaluador.Name = "Tx_CorreoEvaluador"
        Me.Tx_CorreoEvaluador.Size = New System.Drawing.Size(391, 20)
        Me.Tx_CorreoEvaluador.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(72, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Cargo:"
        '
        'Tx_CargoEvaluador
        '
        Me.Tx_CargoEvaluador.Location = New System.Drawing.Point(111, 141)
        Me.Tx_CargoEvaluador.MaxLength = 100
        Me.Tx_CargoEvaluador.Name = "Tx_CargoEvaluador"
        Me.Tx_CargoEvaluador.Size = New System.Drawing.Size(391, 20)
        Me.Tx_CargoEvaluador.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Evaluador:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Trabajador Evaluado:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Proyecto:"
        '
        'Tx_Proyecto
        '
        Me.Tx_Proyecto.Location = New System.Drawing.Point(111, 60)
        Me.Tx_Proyecto.MaxLength = 50
        Me.Tx_Proyecto.Name = "Tx_Proyecto"
        Me.Tx_Proyecto.Size = New System.Drawing.Size(204, 20)
        Me.Tx_Proyecto.TabIndex = 0
        '
        'Tx_Periodo
        '
        Me.Tx_Periodo.Location = New System.Drawing.Point(111, 86)
        Me.Tx_Periodo.MaxLength = 100
        Me.Tx_Periodo.Name = "Tx_Periodo"
        Me.Tx_Periodo.Size = New System.Drawing.Size(332, 20)
        Me.Tx_Periodo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(64, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Periodo:"
        '
        'Cb_Estado
        '
        Me.Cb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Estado.FormattingEnabled = True
        Me.Cb_Estado.Location = New System.Drawing.Point(111, 195)
        Me.Cb_Estado.Name = "Cb_Estado"
        Me.Cb_Estado.Size = New System.Drawing.Size(144, 21)
        Me.Cb_Estado.TabIndex = 1
        '
        'Lb_Correo
        '
        Me.Lb_Correo.AutoSize = True
        Me.Lb_Correo.Location = New System.Drawing.Point(18, 169)
        Me.Lb_Correo.Name = "Lb_Correo"
        Me.Lb_Correo.Size = New System.Drawing.Size(92, 13)
        Me.Lb_Correo.TabIndex = 4
        Me.Lb_Correo.Text = "Correo Evaluador:"
        '
        'Lb_TextoOtros
        '
        Me.Lb_TextoOtros.AutoSize = True
        Me.Lb_TextoOtros.Location = New System.Drawing.Point(72, 39)
        Me.Lb_TextoOtros.Name = "Lb_TextoOtros"
        Me.Lb_TextoOtros.Size = New System.Drawing.Size(38, 13)
        Me.Lb_TextoOtros.TabIndex = 8
        Me.Lb_TextoOtros.Text = "Cargo:"
        '
        'Lb_estado
        '
        Me.Lb_estado.AutoSize = True
        Me.Lb_estado.Location = New System.Drawing.Point(67, 195)
        Me.Lb_estado.Name = "Lb_estado"
        Me.Lb_estado.Size = New System.Drawing.Size(43, 13)
        Me.Lb_estado.TabIndex = 6
        Me.Lb_estado.Text = "Estado:"
        '
        'Tx_CargoEvaluado
        '
        Me.Tx_CargoEvaluado.Location = New System.Drawing.Point(111, 37)
        Me.Tx_CargoEvaluado.MaxLength = 100
        Me.Tx_CargoEvaluado.Name = "Tx_CargoEvaluado"
        Me.Tx_CargoEvaluado.Size = New System.Drawing.Size(391, 20)
        Me.Tx_CargoEvaluado.TabIndex = 2
        '
        'Cu_BuscarEvaluado
        '
        Me.Cu_BuscarEvaluado.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarEvaluado.Location = New System.Drawing.Point(111, 12)
        Me.Cu_BuscarEvaluado.Name = "Cu_BuscarEvaluado"
        Me.Cu_BuscarEvaluado.Size = New System.Drawing.Size(423, 23)
        Me.Cu_BuscarEvaluado.TabIndex = 20
        Me.Cu_BuscarEvaluado.Tipo = "PADEP"
        Me.Cu_BuscarEvaluado.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_AsociarPersonaEvaluada
        '
        Me.Cu_AsociarPersonaEvaluada.componenteasociado = "Cu_Recibido"
        Me.Cu_AsociarPersonaEvaluada.CrearUsuario = True
        Me.Cu_AsociarPersonaEvaluada.Location = New System.Drawing.Point(538, 12)
        Me.Cu_AsociarPersonaEvaluada.Name = "Cu_AsociarPersonaEvaluada"
        Me.Cu_AsociarPersonaEvaluada.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaEvaluada.TabIndex = 21
        Me.Cu_AsociarPersonaEvaluada.Tag = "286"
        Me.Cu_AsociarPersonaEvaluada.TipoAsociacion = "DEP"
        Me.Cu_AsociarPersonaEvaluada.TipoBúsqueda = "P"
        '
        'Cu_BuscarEvaluador
        '
        Me.Cu_BuscarEvaluador.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarEvaluador.Location = New System.Drawing.Point(111, 112)
        Me.Cu_BuscarEvaluador.Name = "Cu_BuscarEvaluador"
        Me.Cu_BuscarEvaluador.Size = New System.Drawing.Size(430, 23)
        Me.Cu_BuscarEvaluador.TabIndex = 18
        Me.Cu_BuscarEvaluador.Tipo = "PADEP"
        Me.Cu_BuscarEvaluador.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_AsociarPersonaEvalua
        '
        Me.Cu_AsociarPersonaEvalua.componenteasociado = "Cu_Recibido"
        Me.Cu_AsociarPersonaEvalua.CrearUsuario = True
        Me.Cu_AsociarPersonaEvalua.Location = New System.Drawing.Point(536, 112)
        Me.Cu_AsociarPersonaEvalua.Name = "Cu_AsociarPersonaEvalua"
        Me.Cu_AsociarPersonaEvalua.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaEvalua.TabIndex = 19
        Me.Cu_AsociarPersonaEvalua.Tag = "286"
        Me.Cu_AsociarPersonaEvalua.TipoAsociacion = "DEP"
        Me.Cu_AsociarPersonaEvalua.TipoBúsqueda = "P"
        '
        'Fr_EvaluacionDesempeño
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 258)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(586, 297)
        Me.MinimumSize = New System.Drawing.Size(586, 297)
        Me.Name = "Fr_EvaluacionDesempeño"
        Me.Text = "Evaluación Desempeño"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tx_Proyecto As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Periodo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cb_Estado As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Correo As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoOtros As System.Windows.Forms.Label
    Friend WithEvents Lb_estado As System.Windows.Forms.Label
    Friend WithEvents Tx_CargoEvaluado As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Tx_CargoEvaluador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarEvaluado As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_AsociarPersonaEvaluada As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarEvaluador As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_AsociarPersonaEvalua As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Tx_CorreoEvaluador As System.Windows.Forms.TextBox
End Class
