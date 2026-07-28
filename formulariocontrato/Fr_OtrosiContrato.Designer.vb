<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_OtrosiContrato
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
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Lb_TextoDeseaContinuar = New System.Windows.Forms.Label()
        Me.TlpBotones = New System.Windows.Forms.TableLayoutPanel()
        Me.Bt_OK = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Pn_Titulo = New System.Windows.Forms.Panel()
        Me.Lb_TextoTitulo = New System.Windows.Forms.Label()
        Me.Tx_FechaOtrosiAnterior = New System.Windows.Forms.TextBox()
        Me.Lb_FechaOtrosiAnterior = New System.Windows.Forms.Label()
        Me.Dtp_FechaFirmaOtrosi = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaFirma = New System.Windows.Forms.Label()
        Me.Dtp_FechaInicioOtrosi = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaInicial = New System.Windows.Forms.Label()
        Me.Lb_AvisoOtrosi = New System.Windows.Forms.Label()
        Me.Lb_CodigoContrato = New System.Windows.Forms.Label()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Tx_LaborContratada = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Lb_LaborContratada = New System.Windows.Forms.Label()
        Me.Cu_CiudadContratación = New FormulariosClasesBase.Cu_Ciudad()
        Me.Pn_Botones.SuspendLayout()
        Me.TlpBotones.SuspendLayout()
        Me.Pn_Titulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Pn_Botones.Controls.Add(Me.Lb_TextoDeseaContinuar)
        Me.Pn_Botones.Controls.Add(Me.TlpBotones)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 286)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(572, 35)
        Me.Pn_Botones.TabIndex = 16
        '
        'Lb_TextoDeseaContinuar
        '
        Me.Lb_TextoDeseaContinuar.AutoSize = True
        Me.Lb_TextoDeseaContinuar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoDeseaContinuar.Location = New System.Drawing.Point(295, 10)
        Me.Lb_TextoDeseaContinuar.Name = "Lb_TextoDeseaContinuar"
        Me.Lb_TextoDeseaContinuar.Size = New System.Drawing.Size(122, 16)
        Me.Lb_TextoDeseaContinuar.TabIndex = 12
        Me.Lb_TextoDeseaContinuar.Text = "¿Desea Continuar?"
        '
        'TlpBotones
        '
        Me.TlpBotones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TlpBotones.ColumnCount = 2
        Me.TlpBotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TlpBotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TlpBotones.Controls.Add(Me.Bt_OK, 0, 0)
        Me.TlpBotones.Controls.Add(Me.Bt_Cancelar, 1, 0)
        Me.TlpBotones.Location = New System.Drawing.Point(423, 3)
        Me.TlpBotones.Name = "TlpBotones"
        Me.TlpBotones.RowCount = 1
        Me.TlpBotones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TlpBotones.Size = New System.Drawing.Size(146, 29)
        Me.TlpBotones.TabIndex = 0
        '
        'Bt_OK
        '
        Me.Bt_OK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Bt_OK.Location = New System.Drawing.Point(3, 3)
        Me.Bt_OK.Name = "Bt_OK"
        Me.Bt_OK.Size = New System.Drawing.Size(67, 23)
        Me.Bt_OK.TabIndex = 0
        Me.Bt_OK.Text = "Si"
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.Location = New System.Drawing.Point(76, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(67, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "No"
        '
        'Pn_Titulo
        '
        Me.Pn_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Titulo.Controls.Add(Me.Lb_TextoTitulo)
        Me.Pn_Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Titulo.Name = "Pn_Titulo"
        Me.Pn_Titulo.Size = New System.Drawing.Size(572, 20)
        Me.Pn_Titulo.TabIndex = 17
        '
        'Lb_TextoTitulo
        '
        Me.Lb_TextoTitulo.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_TextoTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoTitulo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TextoTitulo.Name = "Lb_TextoTitulo"
        Me.Lb_TextoTitulo.Size = New System.Drawing.Size(570, 18)
        Me.Lb_TextoTitulo.TabIndex = 0
        Me.Lb_TextoTitulo.Text = "OTRO SI A CONTRATO DE TRABAJO POR LABOR CONTRATADA"
        Me.Lb_TextoTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tx_FechaOtrosiAnterior
        '
        Me.Tx_FechaOtrosiAnterior.Enabled = False
        Me.Tx_FechaOtrosiAnterior.Location = New System.Drawing.Point(176, 124)
        Me.Tx_FechaOtrosiAnterior.Name = "Tx_FechaOtrosiAnterior"
        Me.Tx_FechaOtrosiAnterior.Size = New System.Drawing.Size(203, 20)
        Me.Tx_FechaOtrosiAnterior.TabIndex = 78
        '
        'Lb_FechaOtrosiAnterior
        '
        Me.Lb_FechaOtrosiAnterior.AutoSize = True
        Me.Lb_FechaOtrosiAnterior.Location = New System.Drawing.Point(65, 127)
        Me.Lb_FechaOtrosiAnterior.Name = "Lb_FechaOtrosiAnterior"
        Me.Lb_FechaOtrosiAnterior.Size = New System.Drawing.Size(108, 13)
        Me.Lb_FechaOtrosiAnterior.TabIndex = 77
        Me.Lb_FechaOtrosiAnterior.Text = "Fecha otrosí anterior:"
        '
        'Dtp_FechaFirmaOtrosi
        '
        Me.Dtp_FechaFirmaOtrosi.Location = New System.Drawing.Point(176, 176)
        Me.Dtp_FechaFirmaOtrosi.Name = "Dtp_FechaFirmaOtrosi"
        Me.Dtp_FechaFirmaOtrosi.Size = New System.Drawing.Size(203, 20)
        Me.Dtp_FechaFirmaOtrosi.TabIndex = 76
        '
        'Lb_FechaFirma
        '
        Me.Lb_FechaFirma.AutoSize = True
        Me.Lb_FechaFirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_FechaFirma.ForeColor = System.Drawing.Color.Black
        Me.Lb_FechaFirma.Location = New System.Drawing.Point(30, 178)
        Me.Lb_FechaFirma.Name = "Lb_FechaFirma"
        Me.Lb_FechaFirma.Size = New System.Drawing.Size(143, 16)
        Me.Lb_FechaFirma.TabIndex = 75
        Me.Lb_FechaFirma.Text = "Fecha Firma Otrosí:"
        '
        'Dtp_FechaInicioOtrosi
        '
        Me.Dtp_FechaInicioOtrosi.Location = New System.Drawing.Point(176, 150)
        Me.Dtp_FechaInicioOtrosi.Name = "Dtp_FechaInicioOtrosi"
        Me.Dtp_FechaInicioOtrosi.Size = New System.Drawing.Size(203, 20)
        Me.Dtp_FechaInicioOtrosi.TabIndex = 74
        '
        'Lb_FechaInicial
        '
        Me.Lb_FechaInicial.AutoSize = True
        Me.Lb_FechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_FechaInicial.ForeColor = System.Drawing.Color.Black
        Me.Lb_FechaInicial.Location = New System.Drawing.Point(32, 152)
        Me.Lb_FechaInicial.Name = "Lb_FechaInicial"
        Me.Lb_FechaInicial.Size = New System.Drawing.Size(141, 16)
        Me.Lb_FechaInicial.TabIndex = 71
        Me.Lb_FechaInicial.Text = "Fecha Inicio Otrosí:"
        '
        'Lb_AvisoOtrosi
        '
        Me.Lb_AvisoOtrosi.AutoSize = True
        Me.Lb_AvisoOtrosi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_AvisoOtrosi.Location = New System.Drawing.Point(13, 33)
        Me.Lb_AvisoOtrosi.Name = "Lb_AvisoOtrosi"
        Me.Lb_AvisoOtrosi.Size = New System.Drawing.Size(374, 16)
        Me.Lb_AvisoOtrosi.TabIndex = 70
        Me.Lb_AvisoOtrosi.Text = "Se registrara el otrosí con los siguientes parametros:"
        '
        'Lb_CodigoContrato
        '
        Me.Lb_CodigoContrato.AutoSize = True
        Me.Lb_CodigoContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CodigoContrato.ForeColor = System.Drawing.Color.Blue
        Me.Lb_CodigoContrato.Location = New System.Drawing.Point(12, 91)
        Me.Lb_CodigoContrato.Name = "Lb_CodigoContrato"
        Me.Lb_CodigoContrato.Size = New System.Drawing.Size(167, 24)
        Me.Lb_CodigoContrato.TabIndex = 69
        Me.Lb_CodigoContrato.Text = "Código Contrato:"
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.Location = New System.Drawing.Point(13, 62)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(63, 16)
        Me.Lb_Nombre.TabIndex = 68
        Me.Lb_Nombre.Text = "Nombre"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(59, 207)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 13)
        Me.Label14.TabIndex = 79
        Me.Label14.Text = "Lugar de Contratación:"
        '
        'Tx_LaborContratada
        '
        Me.Tx_LaborContratada.Location = New System.Drawing.Point(176, 231)
        Me.Tx_LaborContratada.MaxLength = 500
        Me.Tx_LaborContratada.Multiline = True
        Me.Tx_LaborContratada.Name = "Tx_LaborContratada"
        Me.Tx_LaborContratada.Size = New System.Drawing.Size(384, 44)
        Me.Tx_LaborContratada.TabIndex = 83
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(81, 234)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 13)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Labor Contratada:"
        '
        'Lb_LaborContratada
        '
        Me.Lb_LaborContratada.AutoSize = True
        Me.Lb_LaborContratada.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_LaborContratada.Location = New System.Drawing.Point(120, 250)
        Me.Lb_LaborContratada.Name = "Lb_LaborContratada"
        Me.Lb_LaborContratada.Size = New System.Drawing.Size(14, 12)
        Me.Lb_LaborContratada.TabIndex = 82
        Me.Lb_LaborContratada.Text = "(/)"
        '
        'Cu_CiudadContratación
        '
        Me.Cu_CiudadContratación.Enabled = False
        Me.Cu_CiudadContratación.Location = New System.Drawing.Point(176, 202)
        Me.Cu_CiudadContratación.Name = "Cu_CiudadContratación"
        Me.Cu_CiudadContratación.Size = New System.Drawing.Size(276, 23)
        Me.Cu_CiudadContratación.TabIndex = 80
        '
        'Fr_OtrosiContrato
        '
        Me.AcceptButton = Me.Bt_OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Bt_Cancelar
        Me.ClientSize = New System.Drawing.Size(572, 321)
        Me.Controls.Add(Me.Tx_LaborContratada)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Lb_LaborContratada)
        Me.Controls.Add(Me.Cu_CiudadContratación)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Pn_Titulo)
        Me.Controls.Add(Me.Lb_AvisoOtrosi)
        Me.Controls.Add(Me.Lb_Nombre)
        Me.Controls.Add(Me.Lb_CodigoContrato)
        Me.Controls.Add(Me.Lb_FechaOtrosiAnterior)
        Me.Controls.Add(Me.Tx_FechaOtrosiAnterior)
        Me.Controls.Add(Me.Lb_FechaInicial)
        Me.Controls.Add(Me.Dtp_FechaInicioOtrosi)
        Me.Controls.Add(Me.Lb_FechaFirma)
        Me.Controls.Add(Me.Dtp_FechaFirmaOtrosi)
        Me.Controls.Add(Me.Pn_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_OtrosiContrato"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionar Otrosí Contrato"
        Me.Pn_Botones.ResumeLayout(False)
        Me.Pn_Botones.PerformLayout()
        Me.TlpBotones.ResumeLayout(False)
        Me.Pn_Titulo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents TlpBotones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Bt_OK As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Lb_TextoDeseaContinuar As System.Windows.Forms.Label
    Friend WithEvents Pn_Titulo As System.Windows.Forms.Panel
    Friend WithEvents Lb_TextoTitulo As System.Windows.Forms.Label
    Friend WithEvents Tx_FechaOtrosiAnterior As System.Windows.Forms.TextBox
    Friend WithEvents Lb_FechaOtrosiAnterior As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaFirmaOtrosi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_AvisoOtrosi As System.Windows.Forms.Label
    Friend WithEvents Lb_FechaFirma As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaInicioOtrosi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaInicial As System.Windows.Forms.Label
    Friend WithEvents Lb_CodigoContrato As System.Windows.Forms.Label
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Cu_CiudadContratación As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Tx_LaborContratada As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Lb_LaborContratada As System.Windows.Forms.Label
End Class
