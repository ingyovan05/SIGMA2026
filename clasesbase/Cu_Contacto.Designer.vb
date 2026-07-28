<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Contacto
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.Lb_TeléfonoMóvilCorporativo = New System.Windows.Forms.Label()
        Me.Tx_TeléfonoMóvilCorporativo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tx_EmailCorporativo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tx_TeléfonoMóvilPersonal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tx_EmailPersonal = New System.Windows.Forms.TextBox()
        Me.Gb_Contacto = New System.Windows.Forms.GroupBox()
        Me.Gb_Contacto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lb_TeléfonoMóvilCorporativo
        '
        Me.Lb_TeléfonoMóvilCorporativo.AutoSize = True
        Me.Lb_TeléfonoMóvilCorporativo.ForeColor = System.Drawing.Color.Black
        Me.Lb_TeléfonoMóvilCorporativo.Location = New System.Drawing.Point(27, 47)
        Me.Lb_TeléfonoMóvilCorporativo.Name = "Lb_TeléfonoMóvilCorporativo"
        Me.Lb_TeléfonoMóvilCorporativo.Size = New System.Drawing.Size(137, 13)
        Me.Lb_TeléfonoMóvilCorporativo.TabIndex = 98
        Me.Lb_TeléfonoMóvilCorporativo.Text = "Teléfono Móvil Corporativo:"
        '
        'Tx_TeléfonoMóvilCorporativo
        '
        Me.Tx_TeléfonoMóvilCorporativo.Location = New System.Drawing.Point(166, 44)
        Me.Tx_TeléfonoMóvilCorporativo.MaxLength = 10
        Me.Tx_TeléfonoMóvilCorporativo.Name = "Tx_TeléfonoMóvilCorporativo"
        Me.Tx_TeléfonoMóvilCorporativo.Size = New System.Drawing.Size(131, 20)
        Me.Tx_TeléfonoMóvilCorporativo.TabIndex = 97
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Correo Electrónico Corporativo:"
        '
        'Tx_EmailCorporativo
        '
        Me.Tx_EmailCorporativo.Location = New System.Drawing.Point(164, 18)
        Me.Tx_EmailCorporativo.MaxLength = 100
        Me.Tx_EmailCorporativo.Name = "Tx_EmailCorporativo"
        Me.Tx_EmailCorporativo.Size = New System.Drawing.Size(191, 20)
        Me.Tx_EmailCorporativo.TabIndex = 100
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(375, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 13)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Teléfono Móvil Personal:"
        '
        'Tx_TeléfonoMóvilPersonal
        '
        Me.Tx_TeléfonoMóvilPersonal.Location = New System.Drawing.Point(502, 44)
        Me.Tx_TeléfonoMóvilPersonal.MaxLength = 10
        Me.Tx_TeléfonoMóvilPersonal.Name = "Tx_TeléfonoMóvilPersonal"
        Me.Tx_TeléfonoMóvilPersonal.Size = New System.Drawing.Size(131, 20)
        Me.Tx_TeléfonoMóvilPersonal.TabIndex = 101
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(359, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Correo Electrónico Personal:"
        '
        'Tx_EmailPersonal
        '
        Me.Tx_EmailPersonal.Location = New System.Drawing.Point(502, 18)
        Me.Tx_EmailPersonal.MaxLength = 40
        Me.Tx_EmailPersonal.Name = "Tx_EmailPersonal"
        Me.Tx_EmailPersonal.Size = New System.Drawing.Size(191, 20)
        Me.Tx_EmailPersonal.TabIndex = 104
        '
        'Gb_Contacto
        '
        Me.Gb_Contacto.Controls.Add(Me.Tx_EmailPersonal)
        Me.Gb_Contacto.Controls.Add(Me.Label2)
        Me.Gb_Contacto.Controls.Add(Me.Tx_TeléfonoMóvilPersonal)
        Me.Gb_Contacto.Controls.Add(Me.Label3)
        Me.Gb_Contacto.Controls.Add(Me.Tx_EmailCorporativo)
        Me.Gb_Contacto.Controls.Add(Me.Label1)
        Me.Gb_Contacto.Controls.Add(Me.Tx_TeléfonoMóvilCorporativo)
        Me.Gb_Contacto.Controls.Add(Me.Lb_TeléfonoMóvilCorporativo)
        Me.Gb_Contacto.ForeColor = System.Drawing.Color.Blue
        Me.Gb_Contacto.Location = New System.Drawing.Point(4, 5)
        Me.Gb_Contacto.Name = "Gb_Contacto"
        Me.Gb_Contacto.Size = New System.Drawing.Size(704, 70)
        Me.Gb_Contacto.TabIndex = 2
        Me.Gb_Contacto.TabStop = False
        Me.Gb_Contacto.Text = "Contacto"
        '
        'Cu_Contacto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Gb_Contacto)
        Me.Name = "Cu_Contacto"
        Me.Size = New System.Drawing.Size(713, 82)
        Me.Gb_Contacto.ResumeLayout(False)
        Me.Gb_Contacto.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lb_TeléfonoMóvilCorporativo As System.Windows.Forms.Label
    Friend WithEvents Tx_TeléfonoMóvilCorporativo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tx_EmailCorporativo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tx_TeléfonoMóvilPersonal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tx_EmailPersonal As System.Windows.Forms.TextBox
    Public WithEvents Gb_Contacto As System.Windows.Forms.GroupBox

End Class
