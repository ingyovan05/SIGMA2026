<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_CambiarBodega
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
        Me.Btn_AceptarCambio = New System.Windows.Forms.Button()
        Me.Btn_CancelarCambio = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lb_BodegaActual = New System.Windows.Forms.Label()
        Me.Cb_NombreBodega = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_AceptarCambio
        '
        Me.Btn_AceptarCambio.Location = New System.Drawing.Point(243, 4)
        Me.Btn_AceptarCambio.Name = "Btn_AceptarCambio"
        Me.Btn_AceptarCambio.Size = New System.Drawing.Size(75, 23)
        Me.Btn_AceptarCambio.TabIndex = 1
        Me.Btn_AceptarCambio.Text = "Aceptar"
        Me.Btn_AceptarCambio.UseVisualStyleBackColor = True
        '
        'Btn_CancelarCambio
        '
        Me.Btn_CancelarCambio.Location = New System.Drawing.Point(333, 4)
        Me.Btn_CancelarCambio.Name = "Btn_CancelarCambio"
        Me.Btn_CancelarCambio.Size = New System.Drawing.Size(75, 23)
        Me.Btn_CancelarCambio.TabIndex = 0
        Me.Btn_CancelarCambio.Text = "Cancelar"
        Me.Btn_CancelarCambio.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Bodega Actual:"
        '
        'Lb_BodegaActual
        '
        Me.Lb_BodegaActual.AutoSize = True
        Me.Lb_BodegaActual.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Lb_BodegaActual.Location = New System.Drawing.Point(116, 9)
        Me.Lb_BodegaActual.Name = "Lb_BodegaActual"
        Me.Lb_BodegaActual.Size = New System.Drawing.Size(50, 16)
        Me.Lb_BodegaActual.TabIndex = 3
        Me.Lb_BodegaActual.Text = "Label3"
        '
        'Cb_NombreBodega
        '
        Me.Cb_NombreBodega.FormattingEnabled = True
        Me.Cb_NombreBodega.Location = New System.Drawing.Point(63, 19)
        Me.Cb_NombreBodega.Name = "Cb_NombreBodega"
        Me.Cb_NombreBodega.Size = New System.Drawing.Size(324, 21)
        Me.Cb_NombreBodega.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(13, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Nombre:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.Controls.Add(Me.Btn_AceptarCambio)
        Me.Panel1.Controls.Add(Me.Btn_CancelarCambio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 91)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 30)
        Me.Panel1.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cb_NombreBodega)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(3, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(407, 50)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cambiar a"
        '
        'Fr_CambiarBodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 121)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Lb_BodegaActual)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_CambiarBodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Bodega"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_AceptarCambio As System.Windows.Forms.Button
    Friend WithEvents Btn_CancelarCambio As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lb_BodegaActual As System.Windows.Forms.Label
    Friend WithEvents Cb_NombreBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
