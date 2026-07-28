<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_PersonaSeguridad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_PersonaSeguridad))
        Me.Tx_PrimerNombre = New System.Windows.Forms.TextBox()
        Me.Lb_PrimerNombre = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CB_TipoIdentificación = New System.Windows.Forms.ComboBox()
        Me.Tx_SegundoNombre = New System.Windows.Forms.TextBox()
        Me.Tx_Identificacion = New System.Windows.Forms.TextBox()
        Me.Tx_PrimerApellido = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Tx_SegundoApellido = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel_Botones = New System.Windows.Forms.Panel()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.GroupBox_Genero = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RadioButton_Femenino = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Masculino = New System.Windows.Forms.RadioButton()
        Me.PictureBox_Foto_Persona = New System.Windows.Forms.PictureBox()
        Me.Panel_Botones.SuspendLayout()
        Me.GroupBox_Genero.SuspendLayout()
        CType(Me.PictureBox_Foto_Persona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tx_PrimerNombre
        '
        Me.Tx_PrimerNombre.BackColor = System.Drawing.Color.White
        Me.Tx_PrimerNombre.Location = New System.Drawing.Point(103, 31)
        Me.Tx_PrimerNombre.MaxLength = 30
        Me.Tx_PrimerNombre.Name = "Tx_PrimerNombre"
        Me.Tx_PrimerNombre.Size = New System.Drawing.Size(200, 20)
        Me.Tx_PrimerNombre.TabIndex = 2
        '
        'Lb_PrimerNombre
        '
        Me.Lb_PrimerNombre.AutoSize = True
        Me.Lb_PrimerNombre.Location = New System.Drawing.Point(21, 34)
        Me.Lb_PrimerNombre.Name = "Lb_PrimerNombre"
        Me.Lb_PrimerNombre.Size = New System.Drawing.Size(79, 13)
        Me.Lb_PrimerNombre.TabIndex = 12
        Me.Lb_PrimerNombre.Text = "Primer Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(315, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Segundo Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Primer Apellido:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(315, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Segundo Apellido:"
        '
        'CB_TipoIdentificación
        '
        Me.CB_TipoIdentificación.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CB_TipoIdentificación.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CB_TipoIdentificación.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TipoIdentificación.FormattingEnabled = True
        Me.CB_TipoIdentificación.Location = New System.Drawing.Point(103, 6)
        Me.CB_TipoIdentificación.Name = "CB_TipoIdentificación"
        Me.CB_TipoIdentificación.Size = New System.Drawing.Size(200, 21)
        Me.CB_TipoIdentificación.TabIndex = 0
        '
        'Tx_SegundoNombre
        '
        Me.Tx_SegundoNombre.Location = New System.Drawing.Point(411, 31)
        Me.Tx_SegundoNombre.MaxLength = 30
        Me.Tx_SegundoNombre.Name = "Tx_SegundoNombre"
        Me.Tx_SegundoNombre.Size = New System.Drawing.Size(201, 20)
        Me.Tx_SegundoNombre.TabIndex = 3
        '
        'Tx_Identificacion
        '
        Me.Tx_Identificacion.Location = New System.Drawing.Point(411, 6)
        Me.Tx_Identificacion.MaxLength = 15
        Me.Tx_Identificacion.Name = "Tx_Identificacion"
        Me.Tx_Identificacion.Size = New System.Drawing.Size(201, 20)
        Me.Tx_Identificacion.TabIndex = 1
        '
        'Tx_PrimerApellido
        '
        Me.Tx_PrimerApellido.Location = New System.Drawing.Point(103, 55)
        Me.Tx_PrimerApellido.MaxLength = 30
        Me.Tx_PrimerApellido.Name = "Tx_PrimerApellido"
        Me.Tx_PrimerApellido.Size = New System.Drawing.Size(200, 20)
        Me.Tx_PrimerApellido.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(335, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 13)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Identificación:"
        '
        'Tx_SegundoApellido
        '
        Me.Tx_SegundoApellido.Location = New System.Drawing.Point(411, 55)
        Me.Tx_SegundoApellido.MaxLength = 30
        Me.Tx_SegundoApellido.Name = "Tx_SegundoApellido"
        Me.Tx_SegundoApellido.Size = New System.Drawing.Size(201, 20)
        Me.Tx_SegundoApellido.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 10)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(97, 13)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Tipo Identificación:"
        '
        'Panel_Botones
        '
        Me.Panel_Botones.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel_Botones.Controls.Add(Me.Button_Cancelar)
        Me.Panel_Botones.Controls.Add(Me.Button_Aceptar)
        Me.Panel_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel_Botones.Location = New System.Drawing.Point(0, 114)
        Me.Panel_Botones.Name = "Panel_Botones"
        Me.Panel_Botones.Size = New System.Drawing.Size(620, 30)
        Me.Panel_Botones.TabIndex = 7
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancelar.Location = New System.Drawing.Point(537, 3)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cancelar.TabIndex = 1
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(456, 4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Aceptar.TabIndex = 0
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'GroupBox_Genero
        '
        Me.GroupBox_Genero.Controls.Add(Me.Label7)
        Me.GroupBox_Genero.Controls.Add(Me.RadioButton_Femenino)
        Me.GroupBox_Genero.Controls.Add(Me.RadioButton_Masculino)
        Me.GroupBox_Genero.Location = New System.Drawing.Point(52, 75)
        Me.GroupBox_Genero.Name = "GroupBox_Genero"
        Me.GroupBox_Genero.Size = New System.Drawing.Size(205, 33)
        Me.GroupBox_Genero.TabIndex = 6
        Me.GroupBox_Genero.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Genero:"
        '
        'RadioButton_Femenino
        '
        Me.RadioButton_Femenino.AutoSize = True
        Me.RadioButton_Femenino.Location = New System.Drawing.Point(129, 11)
        Me.RadioButton_Femenino.Name = "RadioButton_Femenino"
        Me.RadioButton_Femenino.Size = New System.Drawing.Size(71, 17)
        Me.RadioButton_Femenino.TabIndex = 1
        Me.RadioButton_Femenino.TabStop = True
        Me.RadioButton_Femenino.Text = "Femenino"
        Me.RadioButton_Femenino.UseVisualStyleBackColor = True
        '
        'RadioButton_Masculino
        '
        Me.RadioButton_Masculino.AutoSize = True
        Me.RadioButton_Masculino.Location = New System.Drawing.Point(50, 12)
        Me.RadioButton_Masculino.Name = "RadioButton_Masculino"
        Me.RadioButton_Masculino.Size = New System.Drawing.Size(73, 17)
        Me.RadioButton_Masculino.TabIndex = 0
        Me.RadioButton_Masculino.TabStop = True
        Me.RadioButton_Masculino.Text = "Masculino"
        Me.RadioButton_Masculino.UseVisualStyleBackColor = True
        '
        'PictureBox_Foto_Persona
        '
        Me.PictureBox_Foto_Persona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox_Foto_Persona.ErrorImage = CType(resources.GetObject("PictureBox_Foto_Persona.ErrorImage"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.Image = CType(resources.GetObject("PictureBox_Foto_Persona.Image"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.InitialImage = CType(resources.GetObject("PictureBox_Foto_Persona.InitialImage"), System.Drawing.Image)
        Me.PictureBox_Foto_Persona.Location = New System.Drawing.Point(250, 167)
        Me.PictureBox_Foto_Persona.Name = "PictureBox_Foto_Persona"
        Me.PictureBox_Foto_Persona.Size = New System.Drawing.Size(120, 135)
        Me.PictureBox_Foto_Persona.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_Foto_Persona.TabIndex = 43
        Me.PictureBox_Foto_Persona.TabStop = False
        '
        'Fr_PersonaSeguridad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 144)
        Me.Controls.Add(Me.PictureBox_Foto_Persona)
        Me.Controls.Add(Me.GroupBox_Genero)
        Me.Controls.Add(Me.Panel_Botones)
        Me.Controls.Add(Me.Tx_PrimerNombre)
        Me.Controls.Add(Me.Lb_PrimerNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CB_TipoIdentificación)
        Me.Controls.Add(Me.Tx_SegundoNombre)
        Me.Controls.Add(Me.Tx_Identificacion)
        Me.Controls.Add(Me.Tx_PrimerApellido)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Tx_SegundoApellido)
        Me.Controls.Add(Me.Label19)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(636, 183)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(636, 183)
        Me.Name = "Fr_PersonaSeguridad"
        Me.Text = "Persona Seguridad"
        Me.Panel_Botones.ResumeLayout(False)
        Me.GroupBox_Genero.ResumeLayout(False)
        Me.GroupBox_Genero.PerformLayout()
        CType(Me.PictureBox_Foto_Persona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tx_PrimerNombre As System.Windows.Forms.TextBox
    Friend WithEvents Lb_PrimerNombre As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CB_TipoIdentificación As System.Windows.Forms.ComboBox
    Friend WithEvents Tx_SegundoNombre As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Identificacion As System.Windows.Forms.TextBox
    Friend WithEvents Tx_PrimerApellido As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Tx_SegundoApellido As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel_Botones As System.Windows.Forms.Panel
    Friend WithEvents Button_Cancelar As System.Windows.Forms.Button
    Public WithEvents Button_Aceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox_Genero As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RadioButton_Femenino As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_Masculino As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox_Foto_Persona As System.Windows.Forms.PictureBox
End Class
