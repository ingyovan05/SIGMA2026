<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_AsociarActivoFijo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Ll_ActivoFijo = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Lb_horakilometro = New System.Windows.Forms.Label()
        Me.LL_odometro = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "ACTIVO FIJO - EQUIPO"
        '
        'Ll_ActivoFijo
        '
        Me.Ll_ActivoFijo.AutoSize = True
        Me.Ll_ActivoFijo.Location = New System.Drawing.Point(2, 20)
        Me.Ll_ActivoFijo.Name = "Ll_ActivoFijo"
        Me.Ll_ActivoFijo.Size = New System.Drawing.Size(75, 13)
        Me.Ll_ActivoFijo.TabIndex = 69
        Me.Ll_ActivoFijo.TabStop = True
        Me.Ll_ActivoFijo.Text = "SIN ASOCIAR"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(171, 2)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(35, 13)
        Me.LinkLabel1.TabIndex = 71
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Quitar"
        '
        'Lb_horakilometro
        '
        Me.Lb_horakilometro.AutoSize = True
        Me.Lb_horakilometro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_horakilometro.Location = New System.Drawing.Point(116, 21)
        Me.Lb_horakilometro.Name = "Lb_horakilometro"
        Me.Lb_horakilometro.Size = New System.Drawing.Size(58, 12)
        Me.Lb_horakilometro.TabIndex = 76
        Me.Lb_horakilometro.Text = "Km/Hs /Pag:"
        '
        'LL_odometro
        '
        Me.LL_odometro.AutoSize = True
        Me.LL_odometro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LL_odometro.Location = New System.Drawing.Point(170, 21)
        Me.LL_odometro.Name = "LL_odometro"
        Me.LL_odometro.Size = New System.Drawing.Size(20, 12)
        Me.LL_odometro.TabIndex = 75
        Me.LL_odometro.TabStop = True
        Me.LL_odometro.Text = "###"
        '
        'Cu_AsociarActivoFijo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LL_odometro)
        Me.Controls.Add(Me.Lb_horakilometro)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Ll_ActivoFijo)
        Me.Name = "Cu_AsociarActivoFijo"
        Me.Size = New System.Drawing.Size(215, 38)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Ll_ActivoFijo As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Lb_horakilometro As System.Windows.Forms.Label
    Public WithEvents LL_odometro As System.Windows.Forms.LinkLabel

End Class
