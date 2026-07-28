<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AgregarContratista
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
        Me.Tb_Identificacion = New System.Windows.Forms.TextBox()
        Me.Tb_Nombre = New System.Windows.Forms.TextBox()
        Me.Tb_Dirrecion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tb_Telefono = New System.Windows.Forms.TextBox()
        Me.Tb_DigitoVerificacion = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tb_Identificacion
        '
        Me.Tb_Identificacion.Location = New System.Drawing.Point(89, 11)
        Me.Tb_Identificacion.MaxLength = 15
        Me.Tb_Identificacion.Name = "Tb_Identificacion"
        Me.Tb_Identificacion.Size = New System.Drawing.Size(150, 20)
        Me.Tb_Identificacion.TabIndex = 0
        '
        'Tb_Nombre
        '
        Me.Tb_Nombre.Location = New System.Drawing.Point(89, 38)
        Me.Tb_Nombre.MaxLength = 100
        Me.Tb_Nombre.Name = "Tb_Nombre"
        Me.Tb_Nombre.Size = New System.Drawing.Size(484, 20)
        Me.Tb_Nombre.TabIndex = 2
        '
        'Tb_Dirrecion
        '
        Me.Tb_Dirrecion.Location = New System.Drawing.Point(89, 67)
        Me.Tb_Dirrecion.MaxLength = 100
        Me.Tb_Dirrecion.Name = "Tb_Dirrecion"
        Me.Tb_Dirrecion.Size = New System.Drawing.Size(484, 20)
        Me.Tb_Dirrecion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Identificación:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(245, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Dig Ver:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Dirreción:"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Location = New System.Drawing.Point(504, 6)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cancelar.TabIndex = 1
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Location = New System.Drawing.Point(424, 6)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Aceptar.TabIndex = 0
        Me.Btn_Aceptar.Text = "Aceptar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.Btn_Cancelar)
        Me.Panel1.Controls.Add(Me.Btn_Aceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 130)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(585, 32)
        Me.Panel1.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Teléfono:"
        '
        'Tb_Telefono
        '
        Me.Tb_Telefono.Location = New System.Drawing.Point(89, 96)
        Me.Tb_Telefono.MaxLength = 10
        Me.Tb_Telefono.Name = "Tb_Telefono"
        Me.Tb_Telefono.Size = New System.Drawing.Size(150, 20)
        Me.Tb_Telefono.TabIndex = 4
        '
        'Tb_DigitoVerificacion
        '
        Me.Tb_DigitoVerificacion.Location = New System.Drawing.Point(296, 11)
        Me.Tb_DigitoVerificacion.MaxLength = 1
        Me.Tb_DigitoVerificacion.Name = "Tb_DigitoVerificacion"
        Me.Tb_DigitoVerificacion.Size = New System.Drawing.Size(27, 20)
        Me.Tb_DigitoVerificacion.TabIndex = 1
        '
        'Fr_AgregarContratista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 162)
        Me.Controls.Add(Me.Tb_DigitoVerificacion)
        Me.Controls.Add(Me.Tb_Telefono)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tb_Dirrecion)
        Me.Controls.Add(Me.Tb_Nombre)
        Me.Controls.Add(Me.Tb_Identificacion)
        Me.MaximumSize = New System.Drawing.Size(601, 201)
        Me.MinimumSize = New System.Drawing.Size(601, 201)
        Me.Name = "Fr_AgregarContratista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Contratista"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tb_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Tb_Dirrecion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Tb_Telefono As System.Windows.Forms.TextBox
    Friend WithEvents Tb_DigitoVerificacion As System.Windows.Forms.TextBox
    Public WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Public WithEvents Tb_Identificacion As System.Windows.Forms.TextBox
End Class
