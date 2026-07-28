<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dia_ProrrogarContrato
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
        Me.Tlp_Botones = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Pn_Titulo = New System.Windows.Forms.Panel()
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.Lb_TextoConfirmacion = New System.Windows.Forms.Label()
        Me.Lb_Aviso = New System.Windows.Forms.Label()
        Me.Lb_Codigo = New System.Windows.Forms.Label()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Lb_TextoFechaInicio = New System.Windows.Forms.Label()
        Me.Lb_TextoFechaTerminacion = New System.Windows.Forms.Label()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Cb_TipoDuracion = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoDuracion = New System.Windows.Forms.Label()
        Me.Nud_Duracion = New System.Windows.Forms.NumericUpDown()
        Me.Dtp_FechaTerminacion = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_FechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_FechaFirma = New System.Windows.Forms.DateTimePicker()
        Me.Lb_TextoFechaFirma = New System.Windows.Forms.Label()
        Me.Lb_TextoFechasAnterior = New System.Windows.Forms.Label()
        Me.Tx_FechasAnterior = New System.Windows.Forms.TextBox()
        Me.Lb_AvisoComplemento = New System.Windows.Forms.Label()
        Me.Lb_NombreComplemento = New System.Windows.Forms.Label()
        Me.Tlp_Botones.SuspendLayout()
        Me.Pn_Titulo.SuspendLayout()
        Me.Pn_Botones.SuspendLayout()
        CType(Me.Nud_Duracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tlp_Botones
        '
        Me.Tlp_Botones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tlp_Botones.ColumnCount = 2
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Botones.Controls.Add(Me.OK_Button, 0, 0)
        Me.Tlp_Botones.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.Tlp_Botones.Location = New System.Drawing.Point(423, 3)
        Me.Tlp_Botones.Name = "Tlp_Botones"
        Me.Tlp_Botones.RowCount = 1
        Me.Tlp_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Botones.Size = New System.Drawing.Size(146, 29)
        Me.Tlp_Botones.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Si"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "No"
        '
        'Pn_Titulo
        '
        Me.Pn_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Titulo.Controls.Add(Me.Lb_Titulo)
        Me.Pn_Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Titulo.Name = "Pn_Titulo"
        Me.Pn_Titulo.Size = New System.Drawing.Size(572, 20)
        Me.Pn_Titulo.TabIndex = 0
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_Titulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(570, 18)
        Me.Lb_Titulo.TabIndex = 0
        Me.Lb_Titulo.Text = "PRORROGA DE CONTRATOS"
        Me.Lb_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_TextoConfirmacion
        '
        Me.Lb_TextoConfirmacion.AutoSize = True
        Me.Lb_TextoConfirmacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoConfirmacion.Location = New System.Drawing.Point(295, 10)
        Me.Lb_TextoConfirmacion.Name = "Lb_TextoConfirmacion"
        Me.Lb_TextoConfirmacion.Size = New System.Drawing.Size(122, 16)
        Me.Lb_TextoConfirmacion.TabIndex = 12
        Me.Lb_TextoConfirmacion.Text = "¿Desea Continuar?"
        '
        'Lb_Aviso
        '
        Me.Lb_Aviso.AutoSize = True
        Me.Lb_Aviso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Aviso.Location = New System.Drawing.Point(13, 33)
        Me.Lb_Aviso.Name = "Lb_Aviso"
        Me.Lb_Aviso.Size = New System.Drawing.Size(370, 16)
        Me.Lb_Aviso.TabIndex = 10
        Me.Lb_Aviso.Text = "Se registrara la xxxx Prorroga  con los siguientes parametros:"
        '
        'Lb_Codigo
        '
        Me.Lb_Codigo.AutoSize = True
        Me.Lb_Codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Codigo.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Codigo.Location = New System.Drawing.Point(12, 91)
        Me.Lb_Codigo.Name = "Lb_Codigo"
        Me.Lb_Codigo.Size = New System.Drawing.Size(167, 24)
        Me.Lb_Codigo.TabIndex = 9
        Me.Lb_Codigo.Text = "Código Contrato:"
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.Location = New System.Drawing.Point(13, 62)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(63, 16)
        Me.Lb_Nombre.TabIndex = 7
        Me.Lb_Nombre.Text = "Nombre"
        '
        'Lb_TextoFechaInicio
        '
        Me.Lb_TextoFechaInicio.AutoSize = True
        Me.Lb_TextoFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.Lb_TextoFechaInicio.Location = New System.Drawing.Point(14, 152)
        Me.Lb_TextoFechaInicio.Name = "Lb_TextoFechaInicio"
        Me.Lb_TextoFechaInicio.Size = New System.Drawing.Size(161, 16)
        Me.Lb_TextoFechaInicio.TabIndex = 13
        Me.Lb_TextoFechaInicio.Text = "Fecha Inicio Prorroga:"
        '
        'Lb_TextoFechaTerminacion
        '
        Me.Lb_TextoFechaTerminacion.AutoSize = True
        Me.Lb_TextoFechaTerminacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoFechaTerminacion.ForeColor = System.Drawing.Color.Black
        Me.Lb_TextoFechaTerminacion.Location = New System.Drawing.Point(17, 176)
        Me.Lb_TextoFechaTerminacion.Name = "Lb_TextoFechaTerminacion"
        Me.Lb_TextoFechaTerminacion.Size = New System.Drawing.Size(158, 16)
        Me.Lb_TextoFechaTerminacion.TabIndex = 14
        Me.Lb_TextoFechaTerminacion.Text = "Fecha Final Prorroga:"
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Pn_Botones.Controls.Add(Me.Tlp_Botones)
        Me.Pn_Botones.Controls.Add(Me.Lb_TextoConfirmacion)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 238)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(572, 35)
        Me.Pn_Botones.TabIndex = 15
        '
        'Cb_TipoDuracion
        '
        Me.Cb_TipoDuracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoDuracion.FormattingEnabled = True
        Me.Cb_TipoDuracion.Location = New System.Drawing.Point(499, 150)
        Me.Cb_TipoDuracion.Name = "Cb_TipoDuracion"
        Me.Cb_TipoDuracion.Size = New System.Drawing.Size(59, 21)
        Me.Cb_TipoDuracion.TabIndex = 60
        '
        'Lb_TextoDuracion
        '
        Me.Lb_TextoDuracion.AutoSize = True
        Me.Lb_TextoDuracion.Location = New System.Drawing.Point(389, 154)
        Me.Lb_TextoDuracion.Name = "Lb_TextoDuracion"
        Me.Lb_TextoDuracion.Size = New System.Drawing.Size(53, 13)
        Me.Lb_TextoDuracion.TabIndex = 62
        Me.Lb_TextoDuracion.Text = "Duración:"
        '
        'Nud_Duracion
        '
        Me.Nud_Duracion.Location = New System.Drawing.Point(445, 150)
        Me.Nud_Duracion.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.Nud_Duracion.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_Duracion.Name = "Nud_Duracion"
        Me.Nud_Duracion.Size = New System.Drawing.Size(48, 20)
        Me.Nud_Duracion.TabIndex = 59
        Me.Nud_Duracion.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Dtp_FechaTerminacion
        '
        Me.Dtp_FechaTerminacion.Enabled = False
        Me.Dtp_FechaTerminacion.Location = New System.Drawing.Point(176, 176)
        Me.Dtp_FechaTerminacion.Name = "Dtp_FechaTerminacion"
        Me.Dtp_FechaTerminacion.Size = New System.Drawing.Size(203, 20)
        Me.Dtp_FechaTerminacion.TabIndex = 61
        '
        'Dtp_FechaInicio
        '
        Me.Dtp_FechaInicio.Enabled = False
        Me.Dtp_FechaInicio.Location = New System.Drawing.Point(176, 150)
        Me.Dtp_FechaInicio.Name = "Dtp_FechaInicio"
        Me.Dtp_FechaInicio.Size = New System.Drawing.Size(203, 20)
        Me.Dtp_FechaInicio.TabIndex = 63
        '
        'Dtp_FechaFirma
        '
        Me.Dtp_FechaFirma.Location = New System.Drawing.Point(176, 202)
        Me.Dtp_FechaFirma.Name = "Dtp_FechaFirma"
        Me.Dtp_FechaFirma.Size = New System.Drawing.Size(203, 20)
        Me.Dtp_FechaFirma.TabIndex = 65
        '
        'Lb_TextoFechaFirma
        '
        Me.Lb_TextoFechaFirma.AutoSize = True
        Me.Lb_TextoFechaFirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoFechaFirma.ForeColor = System.Drawing.Color.Black
        Me.Lb_TextoFechaFirma.Location = New System.Drawing.Point(12, 202)
        Me.Lb_TextoFechaFirma.Name = "Lb_TextoFechaFirma"
        Me.Lb_TextoFechaFirma.Size = New System.Drawing.Size(163, 16)
        Me.Lb_TextoFechaFirma.TabIndex = 64
        Me.Lb_TextoFechaFirma.Text = "Fecha Firma Prorroga:"
        '
        'Lb_TextoFechasAnterior
        '
        Me.Lb_TextoFechasAnterior.AutoSize = True
        Me.Lb_TextoFechasAnterior.Location = New System.Drawing.Point(53, 127)
        Me.Lb_TextoFechasAnterior.Name = "Lb_TextoFechasAnterior"
        Me.Lb_TextoFechasAnterior.Size = New System.Drawing.Size(120, 13)
        Me.Lb_TextoFechasAnterior.TabIndex = 66
        Me.Lb_TextoFechasAnterior.Text = "Fecha prórroga anterior:"
        '
        'Tx_FechasAnterior
        '
        Me.Tx_FechasAnterior.Enabled = False
        Me.Tx_FechasAnterior.Location = New System.Drawing.Point(176, 124)
        Me.Tx_FechasAnterior.Name = "Tx_FechasAnterior"
        Me.Tx_FechasAnterior.Size = New System.Drawing.Size(203, 20)
        Me.Tx_FechasAnterior.TabIndex = 67
        '
        'Lb_AvisoComplemento
        '
        Me.Lb_AvisoComplemento.AutoSize = True
        Me.Lb_AvisoComplemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_AvisoComplemento.Location = New System.Drawing.Point(108, 33)
        Me.Lb_AvisoComplemento.Name = "Lb_AvisoComplemento"
        Me.Lb_AvisoComplemento.Size = New System.Drawing.Size(44, 16)
        Me.Lb_AvisoComplemento.TabIndex = 69
        Me.Lb_AvisoComplemento.Text = " xxxx "
        '
        'Lb_NombreComplemento
        '
        Me.Lb_NombreComplemento.AutoSize = True
        Me.Lb_NombreComplemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_NombreComplemento.Location = New System.Drawing.Point(82, 58)
        Me.Lb_NombreComplemento.Name = "Lb_NombreComplemento"
        Me.Lb_NombreComplemento.Size = New System.Drawing.Size(65, 20)
        Me.Lb_NombreComplemento.TabIndex = 70
        Me.Lb_NombreComplemento.Text = "Nombre"
        '
        'Dia_ProrrogarContrato
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(572, 273)
        Me.Controls.Add(Me.Lb_NombreComplemento)
        Me.Controls.Add(Me.Lb_AvisoComplemento)
        Me.Controls.Add(Me.Pn_Titulo)
        Me.Controls.Add(Me.Lb_Aviso)
        Me.Controls.Add(Me.Lb_Nombre)
        Me.Controls.Add(Me.Lb_Codigo)
        Me.Controls.Add(Me.Lb_TextoFechasAnterior)
        Me.Controls.Add(Me.Tx_FechasAnterior)
        Me.Controls.Add(Me.Lb_TextoFechaInicio)
        Me.Controls.Add(Me.Dtp_FechaInicio)
        Me.Controls.Add(Me.Lb_TextoDuracion)
        Me.Controls.Add(Me.Nud_Duracion)
        Me.Controls.Add(Me.Cb_TipoDuracion)
        Me.Controls.Add(Me.Lb_TextoFechaTerminacion)
        Me.Controls.Add(Me.Dtp_FechaTerminacion)
        Me.Controls.Add(Me.Lb_TextoFechaFirma)
        Me.Controls.Add(Me.Dtp_FechaFirma)
        Me.Controls.Add(Me.Pn_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dia_ProrrogarContrato"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Prorrogar Contrato"
        Me.Tlp_Botones.ResumeLayout(False)
        Me.Pn_Titulo.ResumeLayout(False)
        Me.Pn_Botones.ResumeLayout(False)
        Me.Pn_Botones.PerformLayout()
        CType(Me.Nud_Duracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tlp_Botones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Pn_Titulo As System.Windows.Forms.Panel
    Friend WithEvents Lb_Titulo As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoConfirmacion As System.Windows.Forms.Label
    Friend WithEvents Lb_Aviso As System.Windows.Forms.Label
    Public WithEvents Lb_Codigo As System.Windows.Forms.Label
    Public WithEvents Lb_Nombre As System.Windows.Forms.Label
    Public WithEvents Lb_TextoFechaInicio As System.Windows.Forms.Label
    Public WithEvents Lb_TextoFechaTerminacion As System.Windows.Forms.Label
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents Lb_TextoDuracion As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaTerminacion As System.Windows.Forms.DateTimePicker
    Public WithEvents Cb_TipoDuracion As System.Windows.Forms.ComboBox
    Public WithEvents Nud_Duracion As System.Windows.Forms.NumericUpDown
    Public WithEvents Dtp_FechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_FechaFirma As System.Windows.Forms.DateTimePicker
    Public WithEvents Lb_TextoFechaFirma As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoFechasAnterior As System.Windows.Forms.Label
    Friend WithEvents Tx_FechasAnterior As System.Windows.Forms.TextBox
    Friend WithEvents Lb_AvisoComplemento As System.Windows.Forms.Label
    Public WithEvents Lb_NombreComplemento As System.Windows.Forms.Label

End Class
