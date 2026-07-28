<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dg_Formatos
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Ck_PAZYSALVO = New System.Windows.Forms.CheckBox()
        Me.Ck_RECIBIDOORDEN = New System.Windows.Forms.CheckBox()
        Me.Ck_CartaTerminación = New System.Windows.Forms.CheckBox()
        Me.Ck_Suspensión = New System.Windows.Forms.CheckBox()
        Me.NUD_ConsecutivoInicial = New System.Windows.Forms.NumericUpDown()
        Me.ck_CARATURASOBRECARTASUSPENSION = New System.Windows.Forms.CheckBox()
        Me.Ck_PrimeraParteContrato = New System.Windows.Forms.CheckBox()
        Me.NUD_ConsecutivoInicialReanudacion = New System.Windows.Forms.NumericUpDown()
        Me.Ck_Reanudación = New System.Windows.Forms.CheckBox()
        Me.Dtp_FechaReanudación = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_FechaImpresión = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.NUD_ConsecutivoInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_ConsecutivoInicialReanudacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(631, 207)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccione los formatos a imprimir"
        '
        'Ck_PAZYSALVO
        '
        Me.Ck_PAZYSALVO.AccessibleDescription = "k"
        Me.Ck_PAZYSALVO.AutoSize = True
        Me.Ck_PAZYSALVO.Location = New System.Drawing.Point(15, 34)
        Me.Ck_PAZYSALVO.Name = "Ck_PAZYSALVO"
        Me.Ck_PAZYSALVO.Size = New System.Drawing.Size(95, 17)
        Me.Ck_PAZYSALVO.TabIndex = 2
        Me.Ck_PAZYSALVO.Text = "PAZ Y SALVO"
        Me.Ck_PAZYSALVO.UseVisualStyleBackColor = True
        '
        'Ck_RECIBIDOORDEN
        '
        Me.Ck_RECIBIDOORDEN.AutoSize = True
        Me.Ck_RECIBIDOORDEN.Location = New System.Drawing.Point(15, 57)
        Me.Ck_RECIBIDOORDEN.Name = "Ck_RECIBIDOORDEN"
        Me.Ck_RECIBIDOORDEN.Size = New System.Drawing.Size(306, 17)
        Me.Ck_RECIBIDOORDEN.TabIndex = 3
        Me.Ck_RECIBIDOORDEN.Text = "RECIBIDO ORDEN PARA EXAMEN MEDICO DE RETIRO"
        Me.Ck_RECIBIDOORDEN.UseVisualStyleBackColor = True
        '
        'Ck_CartaTerminación
        '
        Me.Ck_CartaTerminación.AutoSize = True
        Me.Ck_CartaTerminación.Location = New System.Drawing.Point(15, 80)
        Me.Ck_CartaTerminación.Name = "Ck_CartaTerminación"
        Me.Ck_CartaTerminación.Size = New System.Drawing.Size(508, 17)
        Me.Ck_CartaTerminación.TabIndex = 4
        Me.Ck_CartaTerminación.Text = "CARTA DE TERMINACION DE CONTRATO POR DURACION DE OBRA O LABOR DETERMINADA"
        Me.Ck_CartaTerminación.UseVisualStyleBackColor = True
        '
        'Ck_Suspensión
        '
        Me.Ck_Suspensión.AutoSize = True
        Me.Ck_Suspensión.Location = New System.Drawing.Point(15, 103)
        Me.Ck_Suspensión.Name = "Ck_Suspensión"
        Me.Ck_Suspensión.Size = New System.Drawing.Size(249, 17)
        Me.Ck_Suspensión.TabIndex = 5
        Me.Ck_Suspensión.Text = "CARTA SUSPENSION        Consecutivo Incial:"
        Me.Ck_Suspensión.UseVisualStyleBackColor = True
        '
        'NUD_ConsecutivoInicial
        '
        Me.NUD_ConsecutivoInicial.Location = New System.Drawing.Point(273, 103)
        Me.NUD_ConsecutivoInicial.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NUD_ConsecutivoInicial.Name = "NUD_ConsecutivoInicial"
        Me.NUD_ConsecutivoInicial.Size = New System.Drawing.Size(65, 20)
        Me.NUD_ConsecutivoInicial.TabIndex = 6
        Me.NUD_ConsecutivoInicial.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ck_CARATURASOBRECARTASUSPENSION
        '
        Me.ck_CARATURASOBRECARTASUSPENSION.AutoSize = True
        Me.ck_CARATURASOBRECARTASUSPENSION.Location = New System.Drawing.Point(15, 126)
        Me.ck_CARATURASOBRECARTASUSPENSION.Name = "ck_CARATURASOBRECARTASUSPENSION"
        Me.ck_CARATURASOBRECARTASUSPENSION.Size = New System.Drawing.Size(119, 17)
        Me.ck_CARATURASOBRECARTASUSPENSION.TabIndex = 7
        Me.ck_CARATURASOBRECARTASUSPENSION.Text = "SOBRE REMISION"
        Me.ck_CARATURASOBRECARTASUSPENSION.UseVisualStyleBackColor = True
        '
        'Ck_PrimeraParteContrato
        '
        Me.Ck_PrimeraParteContrato.AutoSize = True
        Me.Ck_PrimeraParteContrato.Location = New System.Drawing.Point(15, 149)
        Me.Ck_PrimeraParteContrato.Name = "Ck_PrimeraParteContrato"
        Me.Ck_PrimeraParteContrato.Size = New System.Drawing.Size(216, 17)
        Me.Ck_PrimeraParteContrato.TabIndex = 8
        Me.Ck_PrimeraParteContrato.Text = "PRIMERA PARTE CONTRATO LABOR"
        Me.Ck_PrimeraParteContrato.UseVisualStyleBackColor = True
        '
        'NUD_ConsecutivoInicialReanudacion
        '
        Me.NUD_ConsecutivoInicialReanudacion.Location = New System.Drawing.Point(338, 172)
        Me.NUD_ConsecutivoInicialReanudacion.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NUD_ConsecutivoInicialReanudacion.Name = "NUD_ConsecutivoInicialReanudacion"
        Me.NUD_ConsecutivoInicialReanudacion.Size = New System.Drawing.Size(65, 20)
        Me.NUD_ConsecutivoInicialReanudacion.TabIndex = 10
        Me.NUD_ConsecutivoInicialReanudacion.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Ck_Reanudación
        '
        Me.Ck_Reanudación.AutoSize = True
        Me.Ck_Reanudación.Location = New System.Drawing.Point(15, 174)
        Me.Ck_Reanudación.Name = "Ck_Reanudación"
        Me.Ck_Reanudación.Size = New System.Drawing.Size(681, 17)
        Me.Ck_Reanudación.TabIndex = 9
        Me.Ck_Reanudación.Text = "CARTA REANUDACION ACTIVIDADES   Consecutivo Incial:                              " & _
            "Fecha Impresión:                               Fecha Reanudación:"
        Me.Ck_Reanudación.UseVisualStyleBackColor = True
        '
        'Dtp_FechaReanudación
        '
        Me.Dtp_FechaReanudación.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaReanudación.Location = New System.Drawing.Point(695, 172)
        Me.Dtp_FechaReanudación.Name = "Dtp_FechaReanudación"
        Me.Dtp_FechaReanudación.Size = New System.Drawing.Size(79, 20)
        Me.Dtp_FechaReanudación.TabIndex = 11
        '
        'Dtp_FechaImpresión
        '
        Me.Dtp_FechaImpresión.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaImpresión.Location = New System.Drawing.Point(506, 172)
        Me.Dtp_FechaImpresión.Name = "Dtp_FechaImpresión"
        Me.Dtp_FechaImpresión.Size = New System.Drawing.Size(79, 20)
        Me.Dtp_FechaImpresión.TabIndex = 12
        '
        'Dg_Formatos
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(789, 248)
        Me.Controls.Add(Me.Dtp_FechaImpresión)
        Me.Controls.Add(Me.Dtp_FechaReanudación)
        Me.Controls.Add(Me.NUD_ConsecutivoInicialReanudacion)
        Me.Controls.Add(Me.Ck_Reanudación)
        Me.Controls.Add(Me.Ck_PrimeraParteContrato)
        Me.Controls.Add(Me.ck_CARATURASOBRECARTASUSPENSION)
        Me.Controls.Add(Me.NUD_ConsecutivoInicial)
        Me.Controls.Add(Me.Ck_Suspensión)
        Me.Controls.Add(Me.Ck_CartaTerminación)
        Me.Controls.Add(Me.Ck_RECIBIDOORDEN)
        Me.Controls.Add(Me.Ck_PAZYSALVO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dg_Formatos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Formatos para Imprimir"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.NUD_ConsecutivoInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_ConsecutivoInicialReanudacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Ck_PAZYSALVO As System.Windows.Forms.CheckBox
    Public WithEvents Ck_RECIBIDOORDEN As System.Windows.Forms.CheckBox
    Public WithEvents Ck_CartaTerminación As System.Windows.Forms.CheckBox
    Public WithEvents Ck_Suspensión As System.Windows.Forms.CheckBox
    Public WithEvents NUD_ConsecutivoInicial As System.Windows.Forms.NumericUpDown
    Public WithEvents ck_CARATURASOBRECARTASUSPENSION As System.Windows.Forms.CheckBox
    Public WithEvents Ck_PrimeraParteContrato As System.Windows.Forms.CheckBox
    Public WithEvents NUD_ConsecutivoInicialReanudacion As System.Windows.Forms.NumericUpDown
    Public WithEvents Ck_Reanudación As System.Windows.Forms.CheckBox
    Public WithEvents Dtp_FechaReanudación As System.Windows.Forms.DateTimePicker
    Public WithEvents Dtp_FechaImpresión As System.Windows.Forms.DateTimePicker

End Class
