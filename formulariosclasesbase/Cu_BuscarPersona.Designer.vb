<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_BuscarPersona
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
        Me.Cb_Persona = New System.Windows.Forms.ComboBox()
        Me.Tx_TextoCódigo = New System.Windows.Forms.TextBox()
        Me.Button_Buscar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cb_Persona
        '
        Me.Cb_Persona.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Persona.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Persona.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Persona.DisplayMember = "NOMBRECOMPLETO"
        Me.Cb_Persona.FormattingEnabled = True
        Me.Cb_Persona.Location = New System.Drawing.Point(94, 1)
        Me.Cb_Persona.Margin = New System.Windows.Forms.Padding(4)
        Me.Cb_Persona.Name = "Cb_Persona"
        Me.Cb_Persona.Size = New System.Drawing.Size(213, 24)
        Me.Cb_Persona.TabIndex = 4
        Me.Cb_Persona.ValueMember = "IDPERSONA"
        '
        'Tx_TextoCódigo
        '
        Me.Tx_TextoCódigo.Location = New System.Drawing.Point(2, 1)
        Me.Tx_TextoCódigo.Margin = New System.Windows.Forms.Padding(4)
        Me.Tx_TextoCódigo.Name = "Tx_TextoCódigo"
        Me.Tx_TextoCódigo.Size = New System.Drawing.Size(88, 22)
        Me.Tx_TextoCódigo.TabIndex = 3
        '
        'Button_Buscar
        '
        Me.Button_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button_Buscar.AutoSize = True
        Me.Button_Buscar.Location = New System.Drawing.Point(310, 1)
        Me.Button_Buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Buscar.Name = "Button_Buscar"
        Me.Button_Buscar.Size = New System.Drawing.Size(39, 28)
        Me.Button_Buscar.TabIndex = 5
        Me.Button_Buscar.Text = "..."
        Me.Button_Buscar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Tx_TextoCódigo)
        Me.Panel1.Controls.Add(Me.Button_Buscar)
        Me.Panel1.Controls.Add(Me.Cb_Persona)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(353, 28)
        Me.Panel1.TabIndex = 6
        '
        'Cu_BuscarPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Cu_BuscarPersona"
        Me.Size = New System.Drawing.Size(353, 28)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button_Buscar As System.Windows.Forms.Button
    Public WithEvents Tx_TextoCódigo As System.Windows.Forms.TextBox
    Public WithEvents Cb_Persona As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
