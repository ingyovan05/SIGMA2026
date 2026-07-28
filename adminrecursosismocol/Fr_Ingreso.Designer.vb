<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Ingreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Ingreso))
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Tx_Password = New System.Windows.Forms.TextBox()
        Me.Tx_Usuario = New System.Windows.Forms.TextBox()
        Me.Lb_Password = New System.Windows.Forms.Label()
        Me.Lb_Usuario = New System.Windows.Forms.Label()
        Me.UsuarioTableAdapter1 = New DatosClasesBase.Ds_UsuarioTableAdapters.USUARIOTableAdapter()
        Me.Ds_Usuario1 = New DatosClasesBase.Ds_Usuario()
        Me.Lb_Version = New System.Windows.Forms.Label()
        Me.Pb_Logo = New System.Windows.Forms.PictureBox()
        Me.Ll_AcercaDe = New System.Windows.Forms.LinkLabel()
        Me.Ll_AccesoRemoto = New System.Windows.Forms.LinkLabel()
        Me.Lb_Conexion = New System.Windows.Forms.Label()
        Me.Cb_Conexion = New System.Windows.Forms.ComboBox()
        Me.Pn_Principal = New System.Windows.Forms.Panel()
        CType(Me.Ds_Usuario1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pb_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Principal.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Bt_Cancelar.Location = New System.Drawing.Point(132, 208)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(73, 23)
        Me.Bt_Cancelar.TabIndex = 7
        Me.Bt_Cancelar.Text = "&Cancelar"
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Bt_Aceptar.Location = New System.Drawing.Point(51, 208)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(73, 23)
        Me.Bt_Aceptar.TabIndex = 6
        Me.Bt_Aceptar.Text = "&Aceptar"
        '
        'Tx_Password
        '
        Me.Tx_Password.Location = New System.Drawing.Point(98, 171)
        Me.Tx_Password.Name = "Tx_Password"
        Me.Tx_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Tx_Password.Size = New System.Drawing.Size(135, 20)
        Me.Tx_Password.TabIndex = 5
        '
        'Tx_Usuario
        '
        Me.Tx_Usuario.Location = New System.Drawing.Point(98, 145)
        Me.Tx_Usuario.Name = "Tx_Usuario"
        Me.Tx_Usuario.Size = New System.Drawing.Size(135, 20)
        Me.Tx_Usuario.TabIndex = 3
        '
        'Lb_Password
        '
        Me.Lb_Password.AutoSize = True
        Me.Lb_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Password.ForeColor = System.Drawing.Color.Black
        Me.Lb_Password.Location = New System.Drawing.Point(18, 173)
        Me.Lb_Password.Name = "Lb_Password"
        Me.Lb_Password.Size = New System.Drawing.Size(77, 16)
        Me.Lb_Password.TabIndex = 4
        Me.Lb_Password.Text = "Contraseña"
        Me.Lb_Password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_Usuario
        '
        Me.Lb_Usuario.AutoSize = True
        Me.Lb_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Lb_Usuario.Location = New System.Drawing.Point(40, 147)
        Me.Lb_Usuario.Name = "Lb_Usuario"
        Me.Lb_Usuario.Size = New System.Drawing.Size(55, 16)
        Me.Lb_Usuario.TabIndex = 2
        Me.Lb_Usuario.Text = "Usuario"
        Me.Lb_Usuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsuarioTableAdapter1
        '
        Me.UsuarioTableAdapter1.ClearBeforeFill = True
        '
        'Ds_Usuario1
        '
        Me.Ds_Usuario1.DataSetName = "Ds_Usuario"
        Me.Ds_Usuario1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Lb_Version
        '
        Me.Lb_Version.BackColor = System.Drawing.Color.Black
        Me.Lb_Version.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Lb_Version.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Version.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Lb_Version.Location = New System.Drawing.Point(0, 252)
        Me.Lb_Version.Name = "Lb_Version"
        Me.Lb_Version.Size = New System.Drawing.Size(256, 13)
        Me.Lb_Version.TabIndex = 1
        Me.Lb_Version.Text = "Versión 5.0 Septiembre 2 de 2021 6:00 pm"
        Me.Lb_Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pb_Logo
        '
        Me.Pb_Logo.Image = CType(resources.GetObject("Pb_Logo.Image"), System.Drawing.Image)
        Me.Pb_Logo.Location = New System.Drawing.Point(72, 4)
        Me.Pb_Logo.Name = "Pb_Logo"
        Me.Pb_Logo.Size = New System.Drawing.Size(128, 108)
        Me.Pb_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pb_Logo.TabIndex = 12
        Me.Pb_Logo.TabStop = False
        '
        'Ll_AcercaDe
        '
        Me.Ll_AcercaDe.AutoSize = True
        Me.Ll_AcercaDe.Location = New System.Drawing.Point(43, 234)
        Me.Ll_AcercaDe.Name = "Ll_AcercaDe"
        Me.Ll_AcercaDe.Size = New System.Drawing.Size(81, 13)
        Me.Ll_AcercaDe.TabIndex = 8
        Me.Ll_AcercaDe.TabStop = True
        Me.Ll_AcercaDe.Text = "Soporte SIGMA"
        '
        'Ll_AccesoRemoto
        '
        Me.Ll_AccesoRemoto.AutoSize = True
        Me.Ll_AccesoRemoto.Location = New System.Drawing.Point(134, 234)
        Me.Ll_AccesoRemoto.Name = "Ll_AccesoRemoto"
        Me.Ll_AccesoRemoto.Size = New System.Drawing.Size(83, 13)
        Me.Ll_AccesoRemoto.TabIndex = 9
        Me.Ll_AccesoRemoto.TabStop = True
        Me.Ll_AccesoRemoto.Text = "Acceso Remoto"
        '
        'Lb_Conexion
        '
        Me.Lb_Conexion.AutoSize = True
        Me.Lb_Conexion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Conexion.ForeColor = System.Drawing.Color.Black
        Me.Lb_Conexion.Location = New System.Drawing.Point(31, 120)
        Me.Lb_Conexion.Name = "Lb_Conexion"
        Me.Lb_Conexion.Size = New System.Drawing.Size(64, 16)
        Me.Lb_Conexion.TabIndex = 0
        Me.Lb_Conexion.Text = "Conexión"
        Me.Lb_Conexion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cb_Conexion
        '
        Me.Cb_Conexion.DisplayMember = "DESCRIPCION"
        Me.Cb_Conexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Conexion.FormattingEnabled = True
        Me.Cb_Conexion.Location = New System.Drawing.Point(98, 118)
        Me.Cb_Conexion.Name = "Cb_Conexion"
        Me.Cb_Conexion.Size = New System.Drawing.Size(135, 21)
        Me.Cb_Conexion.TabIndex = 1
        Me.Cb_Conexion.ValueMember = "ORDEN"
        '
        'Pn_Principal
        '
        Me.Pn_Principal.Controls.Add(Me.Pb_Logo)
        Me.Pn_Principal.Controls.Add(Me.Lb_Conexion)
        Me.Pn_Principal.Controls.Add(Me.Cb_Conexion)
        Me.Pn_Principal.Controls.Add(Me.Lb_Usuario)
        Me.Pn_Principal.Controls.Add(Me.Tx_Usuario)
        Me.Pn_Principal.Controls.Add(Me.Lb_Password)
        Me.Pn_Principal.Controls.Add(Me.Tx_Password)
        Me.Pn_Principal.Controls.Add(Me.Bt_Aceptar)
        Me.Pn_Principal.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_Principal.Controls.Add(Me.Ll_AcercaDe)
        Me.Pn_Principal.Controls.Add(Me.Ll_AccesoRemoto)
        Me.Pn_Principal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Principal.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Principal.Name = "Pn_Principal"
        Me.Pn_Principal.Size = New System.Drawing.Size(256, 252)
        Me.Pn_Principal.TabIndex = 0
        '
        'Fr_Ingreso
        '
        Me.AcceptButton = Me.Bt_Aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Bt_Cancelar
        Me.ClientSize = New System.Drawing.Size(256, 265)
        Me.Controls.Add(Me.Pn_Principal)
        Me.Controls.Add(Me.Lb_Version)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_Ingreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SIGMA"
        CType(Me.Ds_Usuario1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pb_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Principal.ResumeLayout(False)
        Me.Pn_Principal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Tx_Password As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Usuario As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Password As System.Windows.Forms.Label
    Friend WithEvents Lb_Usuario As System.Windows.Forms.Label
    Friend WithEvents Pb_Logo As System.Windows.Forms.PictureBox
    Friend WithEvents UsuarioTableAdapter1 As DatosClasesBase.Ds_UsuarioTableAdapters.USUARIOTableAdapter
    Friend WithEvents Ds_Usuario1 As DatosClasesBase.Ds_Usuario
    Friend WithEvents Lb_Version As System.Windows.Forms.Label
    Friend WithEvents Ll_AcercaDe As System.Windows.Forms.LinkLabel
    Friend WithEvents Ll_AccesoRemoto As System.Windows.Forms.LinkLabel
    Friend WithEvents Lb_Conexion As System.Windows.Forms.Label
    Friend WithEvents Cb_Conexion As System.Windows.Forms.ComboBox
    Friend WithEvents Pn_Principal As System.Windows.Forms.Panel
End Class
