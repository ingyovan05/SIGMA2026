<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_EditarCaracteristica
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lbl_subtipo = New System.Windows.Forms.Label()
        Me.Lbl_Tipo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tb_Nombre = New System.Windows.Forms.TextBox()
        Me.Tb_Descripcion = New System.Windows.Forms.TextBox()
        Me.Cb_tipo = New System.Windows.Forms.ComboBox()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Eliminar = New System.Windows.Forms.Button()
        Me.Cbx_Irrepetible = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(144, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Subtipo de Articulo:"
        '
        'Lbl_subtipo
        '
        Me.Lbl_subtipo.AutoSize = True
        Me.Lbl_subtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_subtipo.Location = New System.Drawing.Point(251, 31)
        Me.Lbl_subtipo.Name = "Lbl_subtipo"
        Me.Lbl_subtipo.Size = New System.Drawing.Size(122, 13)
        Me.Lbl_subtipo.TabIndex = 1
        Me.Lbl_subtipo.Text = "[nombre del subtipo]"
        '
        'Lbl_Tipo
        '
        Me.Lbl_Tipo.AutoSize = True
        Me.Lbl_Tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Tipo.Location = New System.Drawing.Point(251, 9)
        Me.Lbl_Tipo.Name = "Lbl_Tipo"
        Me.Lbl_Tipo.Size = New System.Drawing.Size(102, 13)
        Me.Lbl_Tipo.TabIndex = 3
        Me.Lbl_Tipo.Text = "[nombre del tipo]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(159, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tipo de Articulo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Nombre de la caracteristica"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Descripción de la caracteristica"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(97, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Tipo deDato"
        '
        'Tb_Nombre
        '
        Me.Tb_Nombre.Location = New System.Drawing.Point(169, 66)
        Me.Tb_Nombre.MaxLength = 50
        Me.Tb_Nombre.Name = "Tb_Nombre"
        Me.Tb_Nombre.Size = New System.Drawing.Size(336, 20)
        Me.Tb_Nombre.TabIndex = 7
        '
        'Tb_Descripcion
        '
        Me.Tb_Descripcion.Location = New System.Drawing.Point(169, 90)
        Me.Tb_Descripcion.MaxLength = 150
        Me.Tb_Descripcion.Multiline = True
        Me.Tb_Descripcion.Name = "Tb_Descripcion"
        Me.Tb_Descripcion.Size = New System.Drawing.Size(336, 62)
        Me.Tb_Descripcion.TabIndex = 8
        '
        'Cb_tipo
        '
        Me.Cb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_tipo.FormattingEnabled = True
        Me.Cb_tipo.Location = New System.Drawing.Point(169, 158)
        Me.Cb_tipo.Name = "Cb_tipo"
        Me.Cb_tipo.Size = New System.Drawing.Size(336, 21)
        Me.Cb_tipo.TabIndex = 9
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_Aceptar.Location = New System.Drawing.Point(122, 3)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Aceptar.TabIndex = 10
        Me.Btn_Aceptar.Text = "Aceptar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.Btn_Cancelar.Location = New System.Drawing.Point(221, 3)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cancelar.TabIndex = 11
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Btn_Eliminar.Enabled = False
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Btn_Eliminar.Location = New System.Drawing.Point(320, 3)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Eliminar.TabIndex = 12
        Me.Btn_Eliminar.Text = "Eliminar"
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        '
        'Cbx_Irrepetible
        '
        Me.Cbx_Irrepetible.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Cbx_Irrepetible.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cbx_Irrepetible.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cbx_Irrepetible.Location = New System.Drawing.Point(11, 185)
        Me.Cbx_Irrepetible.Name = "Cbx_Irrepetible"
        Me.Cbx_Irrepetible.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Cbx_Irrepetible.Size = New System.Drawing.Size(494, 22)
        Me.Cbx_Irrepetible.TabIndex = 13
        Me.Cbx_Irrepetible.Text = "Campo Único? (no se repite en la misma marca y modelo)"
        Me.Cbx_Irrepetible.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.Btn_Eliminar)
        Me.Panel1.Controls.Add(Me.Btn_Aceptar)
        Me.Panel1.Controls.Add(Me.Btn_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 214)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(517, 29)
        Me.Panel1.TabIndex = 14
        '
        'Fr_EditarCaracteristica
        '
        Me.AcceptButton = Me.Btn_Aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Btn_Cancelar
        Me.ClientSize = New System.Drawing.Size(517, 243)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Cbx_Irrepetible)
        Me.Controls.Add(Me.Cb_tipo)
        Me.Controls.Add(Me.Tb_Descripcion)
        Me.Controls.Add(Me.Tb_Nombre)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Lbl_Tipo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Lbl_subtipo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_EditarCaracteristica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar/Crear Caracterisitca"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lbl_subtipo As System.Windows.Forms.Label
    Friend WithEvents Lbl_Tipo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Tb_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Tb_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Cb_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Cbx_Irrepetible As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
