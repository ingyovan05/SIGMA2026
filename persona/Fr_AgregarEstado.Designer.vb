<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AgregarEstado
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label_Nombre = New System.Windows.Forms.Label()
        Me.Label_Cedula = New System.Windows.Forms.Label()
        Me.Cb_TipoObservación = New System.Windows.Forms.ComboBox()
        Me.Lb_TipoRecurso = New System.Windows.Forms.Label()
        Me.Tx_Observación = New System.Windows.Forms.TextBox()
        Me.Lb_Observación = New System.Windows.Forms.Label()
        Me.Lb_CanObservación = New System.Windows.Forms.Label()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Lb_Estado = New System.Windows.Forms.Label()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Rb_Si = New System.Windows.Forms.RadioButton()
        Me.Rb_No = New System.Windows.Forms.RadioButton()
        Me.Lb_DenegarAcceso = New System.Windows.Forms.Label()
        Me.Pn_Cuerpo = New System.Windows.Forms.Panel()
        Me.Lb_ComoQuedara = New System.Windows.Forms.Label()
        Me.Lb_Mensaje = New System.Windows.Forms.Label()
        Me.Dgv_Historial = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Pn_Botones.SuspendLayout()
        Me.Pn_Cuerpo.SuspendLayout()
        CType(Me.Dgv_Historial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.Label_Nombre)
        Me.Panel1.Controls.Add(Me.Label_Cedula)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(734, 63)
        Me.Panel1.TabIndex = 1
        '
        'Label_Nombre
        '
        Me.Label_Nombre.AutoSize = True
        Me.Label_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Nombre.Location = New System.Drawing.Point(46, 12)
        Me.Label_Nombre.Name = "Label_Nombre"
        Me.Label_Nombre.Size = New System.Drawing.Size(71, 16)
        Me.Label_Nombre.TabIndex = 0
        Me.Label_Nombre.Text = "Nombre: "
        '
        'Label_Cedula
        '
        Me.Label_Cedula.AutoSize = True
        Me.Label_Cedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Cedula.Location = New System.Drawing.Point(9, 36)
        Me.Label_Cedula.Name = "Label_Cedula"
        Me.Label_Cedula.Size = New System.Drawing.Size(108, 16)
        Me.Label_Cedula.TabIndex = 1
        Me.Label_Cedula.Text = "Identificación: "
        '
        'Cb_TipoObservación
        '
        Me.Cb_TipoObservación.DisplayMember = "NOMBRETIPOTURNO"
        Me.Cb_TipoObservación.Items.AddRange(New Object() {"Seguridad Física", "Administración", "HSE", "Otro"})
        Me.Cb_TipoObservación.Location = New System.Drawing.Point(110, 5)
        Me.Cb_TipoObservación.Name = "Cb_TipoObservación"
        Me.Cb_TipoObservación.Size = New System.Drawing.Size(120, 21)
        Me.Cb_TipoObservación.TabIndex = 48
        Me.Cb_TipoObservación.ValueMember = "CODIGOTIPOTURNO"
        '
        'Lb_TipoRecurso
        '
        Me.Lb_TipoRecurso.AutoSize = True
        Me.Lb_TipoRecurso.Location = New System.Drawing.Point(13, 9)
        Me.Lb_TipoRecurso.Name = "Lb_TipoRecurso"
        Me.Lb_TipoRecurso.Size = New System.Drawing.Size(94, 13)
        Me.Lb_TipoRecurso.TabIndex = 49
        Me.Lb_TipoRecurso.Text = "Tipo Observación:"
        '
        'Tx_Observación
        '
        Me.Tx_Observación.Location = New System.Drawing.Point(110, 34)
        Me.Tx_Observación.MaxLength = 300
        Me.Tx_Observación.Multiline = True
        Me.Tx_Observación.Name = "Tx_Observación"
        Me.Tx_Observación.Size = New System.Drawing.Size(612, 44)
        Me.Tx_Observación.TabIndex = 53
        '
        'Lb_Observación
        '
        Me.Lb_Observación.AutoSize = True
        Me.Lb_Observación.Location = New System.Drawing.Point(37, 37)
        Me.Lb_Observación.Name = "Lb_Observación"
        Me.Lb_Observación.Size = New System.Drawing.Size(70, 13)
        Me.Lb_Observación.TabIndex = 51
        Me.Lb_Observación.Text = "Observación:"
        '
        'Lb_CanObservación
        '
        Me.Lb_CanObservación.AutoSize = True
        Me.Lb_CanObservación.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CanObservación.Location = New System.Drawing.Point(61, 52)
        Me.Lb_CanObservación.Name = "Lb_CanObservación"
        Me.Lb_CanObservación.Size = New System.Drawing.Size(14, 12)
        Me.Lb_CanObservación.TabIndex = 52
        Me.Lb_CanObservación.Text = "(/)"
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Pn_Botones.Controls.Add(Me.Lb_Estado)
        Me.Pn_Botones.Controls.Add(Me.Button_Cancelar)
        Me.Pn_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 157)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(734, 30)
        Me.Pn_Botones.TabIndex = 54
        '
        'Lb_Estado
        '
        Me.Lb_Estado.AutoSize = True
        Me.Lb_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Estado.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Estado.Location = New System.Drawing.Point(12, 6)
        Me.Lb_Estado.Name = "Lb_Estado"
        Me.Lb_Estado.Size = New System.Drawing.Size(127, 20)
        Me.Lb_Estado.TabIndex = 3
        Me.Lb_Estado.Text = "Estado Actual:"
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Cancelar.Location = New System.Drawing.Point(650, 3)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cancelar.TabIndex = 2
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Aceptar.Location = New System.Drawing.Point(565, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 1
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Rb_Si
        '
        Me.Rb_Si.AutoSize = True
        Me.Rb_Si.Location = New System.Drawing.Point(383, 7)
        Me.Rb_Si.Name = "Rb_Si"
        Me.Rb_Si.Size = New System.Drawing.Size(34, 17)
        Me.Rb_Si.TabIndex = 55
        Me.Rb_Si.TabStop = True
        Me.Rb_Si.Text = "Si"
        Me.Rb_Si.UseVisualStyleBackColor = True
        '
        'Rb_No
        '
        Me.Rb_No.AutoSize = True
        Me.Rb_No.Location = New System.Drawing.Point(423, 7)
        Me.Rb_No.Name = "Rb_No"
        Me.Rb_No.Size = New System.Drawing.Size(39, 17)
        Me.Rb_No.TabIndex = 56
        Me.Rb_No.TabStop = True
        Me.Rb_No.Text = "No"
        Me.Rb_No.UseVisualStyleBackColor = True
        '
        'Lb_DenegarAcceso
        '
        Me.Lb_DenegarAcceso.AutoSize = True
        Me.Lb_DenegarAcceso.Location = New System.Drawing.Point(236, 9)
        Me.Lb_DenegarAcceso.Name = "Lb_DenegarAcceso"
        Me.Lb_DenegarAcceso.Size = New System.Drawing.Size(141, 13)
        Me.Lb_DenegarAcceso.TabIndex = 57
        Me.Lb_DenegarAcceso.Text = "Denegar Acceso ISMOCOL:"
        '
        'Pn_Cuerpo
        '
        Me.Pn_Cuerpo.Controls.Add(Me.Lb_ComoQuedara)
        Me.Pn_Cuerpo.Controls.Add(Me.Lb_Mensaje)
        Me.Pn_Cuerpo.Controls.Add(Me.Dgv_Historial)
        Me.Pn_Cuerpo.Controls.Add(Me.Lb_TipoRecurso)
        Me.Pn_Cuerpo.Controls.Add(Me.Lb_DenegarAcceso)
        Me.Pn_Cuerpo.Controls.Add(Me.Cb_TipoObservación)
        Me.Pn_Cuerpo.Controls.Add(Me.Rb_No)
        Me.Pn_Cuerpo.Controls.Add(Me.Lb_CanObservación)
        Me.Pn_Cuerpo.Controls.Add(Me.Rb_Si)
        Me.Pn_Cuerpo.Controls.Add(Me.Lb_Observación)
        Me.Pn_Cuerpo.Controls.Add(Me.Tx_Observación)
        Me.Pn_Cuerpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Cuerpo.Location = New System.Drawing.Point(0, 63)
        Me.Pn_Cuerpo.Name = "Pn_Cuerpo"
        Me.Pn_Cuerpo.Size = New System.Drawing.Size(734, 94)
        Me.Pn_Cuerpo.TabIndex = 58
        '
        'Lb_ComoQuedara
        '
        Me.Lb_ComoQuedara.AutoSize = True
        Me.Lb_ComoQuedara.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_ComoQuedara.Location = New System.Drawing.Point(470, 9)
        Me.Lb_ComoQuedara.Name = "Lb_ComoQuedara"
        Me.Lb_ComoQuedara.Size = New System.Drawing.Size(0, 13)
        Me.Lb_ComoQuedara.TabIndex = 60
        Me.Lb_ComoQuedara.Visible = False
        '
        'Lb_Mensaje
        '
        Me.Lb_Mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Mensaje.ForeColor = System.Drawing.Color.Red
        Me.Lb_Mensaje.Location = New System.Drawing.Point(161, 30)
        Me.Lb_Mensaje.Name = "Lb_Mensaje"
        Me.Lb_Mensaje.Size = New System.Drawing.Size(404, 34)
        Me.Lb_Mensaje.TabIndex = 59
        Me.Lb_Mensaje.Text = "ACCESO DENEGADO"
        Me.Lb_Mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_Historial
        '
        Me.Dgv_Historial.AllowUserToAddRows = False
        Me.Dgv_Historial.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleGreen
        Me.Dgv_Historial.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_Historial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Historial.Location = New System.Drawing.Point(3, 64)
        Me.Dgv_Historial.Name = "Dgv_Historial"
        Me.Dgv_Historial.ReadOnly = True
        Me.Dgv_Historial.Size = New System.Drawing.Size(127, 46)
        Me.Dgv_Historial.TabIndex = 58
        '
        'Fr_AgregarEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 187)
        Me.Controls.Add(Me.Pn_Cuerpo)
        Me.Controls.Add(Me.Pn_Botones)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_AgregarEstado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Pn_Botones.ResumeLayout(False)
        Me.Pn_Botones.PerformLayout()
        Me.Pn_Cuerpo.ResumeLayout(False)
        Me.Pn_Cuerpo.PerformLayout()
        CType(Me.Dgv_Historial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Label_Nombre As System.Windows.Forms.Label
    Public WithEvents Label_Cedula As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoObservación As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TipoRecurso As System.Windows.Forms.Label
    Friend WithEvents Tx_Observación As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Observación As System.Windows.Forms.Label
    Friend WithEvents Lb_CanObservación As System.Windows.Forms.Label
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents Button_Cancelar As System.Windows.Forms.Button
    Public WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Lb_Estado As System.Windows.Forms.Label
    Friend WithEvents Rb_Si As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_No As System.Windows.Forms.RadioButton
    Friend WithEvents Lb_DenegarAcceso As System.Windows.Forms.Label
    Friend WithEvents Pn_Cuerpo As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Historial As System.Windows.Forms.DataGridView
    Friend WithEvents Lb_Mensaje As System.Windows.Forms.Label
    Friend WithEvents Lb_ComoQuedara As System.Windows.Forms.Label
End Class
