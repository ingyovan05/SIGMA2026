<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Bienvenida
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
        Me.components = New System.ComponentModel.Container()
        Me.Gb_Noticias = New System.Windows.Forms.GroupBox()
        Me.Wb_Noticias = New System.Windows.Forms.WebBrowser()
        Me.Pn_Noticias = New System.Windows.Forms.Panel()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Ck_MostrarSiempre = New System.Windows.Forms.CheckBox()
        Me.Tlp_Opciones = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_Opciones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Lb_TextoBienvenido = New System.Windows.Forms.Label()
        Me.Gb_Contacto = New System.Windows.Forms.GroupBox()
        Me.Bt_ActualizarContacto = New System.Windows.Forms.Button()
        Me.Tx_MovilCorporativo = New System.Windows.Forms.TextBox()
        Me.Lb_MovilCorporativo = New System.Windows.Forms.Label()
        Me.Tx_EmailCorporativo = New System.Windows.Forms.TextBox()
        Me.Lb_EmailCorporativo = New System.Windows.Forms.Label()
        Me.Tt_Bienvenida = New System.Windows.Forms.ToolTip(Me.components)
        Me.Tlp_DatosInicio = New System.Windows.Forms.TableLayoutPanel()
        Me.Gb_Proyecto = New System.Windows.Forms.GroupBox()
        Me.Cb_Proyecto = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoProyecto = New System.Windows.Forms.Label()
        Me.Flp_Usuario = New System.Windows.Forms.FlowLayoutPanel()
        Me.Gb_Noticias.SuspendLayout()
        Me.Pn_Noticias.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.Tlp_Opciones.SuspendLayout()
        Me.Flp_Opciones.SuspendLayout()
        Me.Gb_Contacto.SuspendLayout()
        Me.Tlp_DatosInicio.SuspendLayout()
        Me.Gb_Proyecto.SuspendLayout()
        Me.Flp_Usuario.SuspendLayout()
        Me.SuspendLayout()
        '
        'Gb_Noticias
        '
        Me.Gb_Noticias.Controls.Add(Me.Wb_Noticias)
        Me.Gb_Noticias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gb_Noticias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gb_Noticias.Location = New System.Drawing.Point(5, 5)
        Me.Gb_Noticias.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Gb_Noticias.Name = "Gb_Noticias"
        Me.Gb_Noticias.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Gb_Noticias.Size = New System.Drawing.Size(995, 353)
        Me.Gb_Noticias.TabIndex = 0
        Me.Gb_Noticias.TabStop = False
        Me.Gb_Noticias.Text = "Noticias y actualizaciones"
        '
        'Wb_Noticias
        '
        Me.Wb_Noticias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Wb_Noticias.IsWebBrowserContextMenuEnabled = False
        Me.Wb_Noticias.Location = New System.Drawing.Point(8, 24)
        Me.Wb_Noticias.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Wb_Noticias.MinimumSize = New System.Drawing.Size(27, 25)
        Me.Wb_Noticias.Name = "Wb_Noticias"
        Me.Wb_Noticias.Size = New System.Drawing.Size(979, 322)
        Me.Wb_Noticias.TabIndex = 0
        Me.Wb_Noticias.WebBrowserShortcutsEnabled = False
        '
        'Pn_Noticias
        '
        Me.Pn_Noticias.Controls.Add(Me.Gb_Noticias)
        Me.Pn_Noticias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Noticias.Location = New System.Drawing.Point(0, 143)
        Me.Pn_Noticias.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Pn_Noticias.Name = "Pn_Noticias"
        Me.Pn_Noticias.Padding = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Pn_Noticias.Size = New System.Drawing.Size(1005, 363)
        Me.Pn_Noticias.TabIndex = 3
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(332, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(673, 37)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Bt_Aceptar.Location = New System.Drawing.Point(569, 4)
        Me.Bt_Aceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Ck_MostrarSiempre
        '
        Me.Ck_MostrarSiempre.AutoSize = True
        Me.Ck_MostrarSiempre.Checked = True
        Me.Ck_MostrarSiempre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_MostrarSiempre.Location = New System.Drawing.Point(9, 9)
        Me.Ck_MostrarSiempre.Margin = New System.Windows.Forms.Padding(4, 9, 4, 4)
        Me.Ck_MostrarSiempre.Name = "Ck_MostrarSiempre"
        Me.Ck_MostrarSiempre.Size = New System.Drawing.Size(319, 21)
        Me.Ck_MostrarSiempre.TabIndex = 0
        Me.Ck_MostrarSiempre.Text = "Mostrar siempre esta ventana al iniciar sesión"
        Me.Tt_Bienvenida.SetToolTip(Me.Ck_MostrarSiempre, "Abrir esta ventana ")
        Me.Ck_MostrarSiempre.UseVisualStyleBackColor = True
        '
        'Tlp_Opciones
        '
        Me.Tlp_Opciones.ColumnCount = 2
        Me.Tlp_Opciones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Opciones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Opciones.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_Opciones.Controls.Add(Me.Flp_Opciones, 0, 0)
        Me.Tlp_Opciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_Opciones.Location = New System.Drawing.Point(0, 506)
        Me.Tlp_Opciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tlp_Opciones.Name = "Tlp_Opciones"
        Me.Tlp_Opciones.RowCount = 1
        Me.Tlp_Opciones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Opciones.Size = New System.Drawing.Size(1005, 37)
        Me.Tlp_Opciones.TabIndex = 4
        '
        'Flp_Opciones
        '
        Me.Flp_Opciones.AutoSize = True
        Me.Flp_Opciones.Controls.Add(Me.Ck_MostrarSiempre)
        Me.Flp_Opciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Opciones.Location = New System.Drawing.Point(0, 0)
        Me.Flp_Opciones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Opciones.Name = "Flp_Opciones"
        Me.Flp_Opciones.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Flp_Opciones.Size = New System.Drawing.Size(332, 37)
        Me.Flp_Opciones.TabIndex = 0
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.Location = New System.Drawing.Point(120, 9)
        Me.Lb_Nombre.Margin = New System.Windows.Forms.Padding(4, 9, 4, 0)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(64, 17)
        Me.Lb_Nombre.TabIndex = 1
        Me.Lb_Nombre.Text = "Nombre"
        '
        'Lb_TextoBienvenido
        '
        Me.Lb_TextoBienvenido.AutoSize = True
        Me.Lb_TextoBienvenido.Location = New System.Drawing.Point(12, 9)
        Me.Lb_TextoBienvenido.Margin = New System.Windows.Forms.Padding(4, 9, 4, 0)
        Me.Lb_TextoBienvenido.Name = "Lb_TextoBienvenido"
        Me.Lb_TextoBienvenido.Size = New System.Drawing.Size(100, 17)
        Me.Lb_TextoBienvenido.TabIndex = 0
        Me.Lb_TextoBienvenido.Text = "Bienvenido(a),"
        '
        'Gb_Contacto
        '
        Me.Gb_Contacto.Controls.Add(Me.Bt_ActualizarContacto)
        Me.Gb_Contacto.Controls.Add(Me.Tx_MovilCorporativo)
        Me.Gb_Contacto.Controls.Add(Me.Lb_MovilCorporativo)
        Me.Gb_Contacto.Controls.Add(Me.Tx_EmailCorporativo)
        Me.Gb_Contacto.Controls.Add(Me.Lb_EmailCorporativo)
        Me.Gb_Contacto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gb_Contacto.Location = New System.Drawing.Point(511, 9)
        Me.Gb_Contacto.Margin = New System.Windows.Forms.Padding(9, 9, 9, 9)
        Me.Gb_Contacto.Name = "Gb_Contacto"
        Me.Gb_Contacto.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Gb_Contacto.Size = New System.Drawing.Size(485, 93)
        Me.Gb_Contacto.TabIndex = 1
        Me.Gb_Contacto.TabStop = False
        Me.Gb_Contacto.Text = "Actualizar datos de contacto"
        '
        'Bt_ActualizarContacto
        '
        Me.Bt_ActualizarContacto.Location = New System.Drawing.Point(355, 55)
        Me.Bt_ActualizarContacto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bt_ActualizarContacto.Name = "Bt_ActualizarContacto"
        Me.Bt_ActualizarContacto.Size = New System.Drawing.Size(100, 28)
        Me.Bt_ActualizarContacto.TabIndex = 7
        Me.Bt_ActualizarContacto.Text = "Actualizar"
        Me.Bt_ActualizarContacto.UseVisualStyleBackColor = True
        '
        'Tx_MovilCorporativo
        '
        Me.Tx_MovilCorporativo.Location = New System.Drawing.Point(215, 57)
        Me.Tx_MovilCorporativo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tx_MovilCorporativo.Name = "Tx_MovilCorporativo"
        Me.Tx_MovilCorporativo.Size = New System.Drawing.Size(105, 22)
        Me.Tx_MovilCorporativo.TabIndex = 6
        '
        'Lb_MovilCorporativo
        '
        Me.Lb_MovilCorporativo.AutoSize = True
        Me.Lb_MovilCorporativo.Location = New System.Drawing.Point(31, 60)
        Me.Lb_MovilCorporativo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_MovilCorporativo.Name = "Lb_MovilCorporativo"
        Me.Lb_MovilCorporativo.Size = New System.Drawing.Size(179, 17)
        Me.Lb_MovilCorporativo.TabIndex = 5
        Me.Lb_MovilCorporativo.Text = "Teléfono móvil corporativo:"
        '
        'Tx_EmailCorporativo
        '
        Me.Tx_EmailCorporativo.Location = New System.Drawing.Point(215, 25)
        Me.Tx_EmailCorporativo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tx_EmailCorporativo.Name = "Tx_EmailCorporativo"
        Me.Tx_EmailCorporativo.Size = New System.Drawing.Size(239, 22)
        Me.Tx_EmailCorporativo.TabIndex = 1
        '
        'Lb_EmailCorporativo
        '
        Me.Lb_EmailCorporativo.AutoSize = True
        Me.Lb_EmailCorporativo.Location = New System.Drawing.Point(8, 28)
        Me.Lb_EmailCorporativo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_EmailCorporativo.Name = "Lb_EmailCorporativo"
        Me.Lb_EmailCorporativo.Size = New System.Drawing.Size(203, 17)
        Me.Lb_EmailCorporativo.TabIndex = 0
        Me.Lb_EmailCorporativo.Text = "Correo electrónico corporativo:"
        '
        'Tlp_DatosInicio
        '
        Me.Tlp_DatosInicio.ColumnCount = 2
        Me.Tlp_DatosInicio.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_DatosInicio.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_DatosInicio.Controls.Add(Me.Gb_Contacto, 1, 0)
        Me.Tlp_DatosInicio.Controls.Add(Me.Gb_Proyecto, 0, 0)
        Me.Tlp_DatosInicio.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tlp_DatosInicio.Location = New System.Drawing.Point(0, 32)
        Me.Tlp_DatosInicio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tlp_DatosInicio.Name = "Tlp_DatosInicio"
        Me.Tlp_DatosInicio.RowCount = 1
        Me.Tlp_DatosInicio.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_DatosInicio.Size = New System.Drawing.Size(1005, 111)
        Me.Tlp_DatosInicio.TabIndex = 1
        '
        'Gb_Proyecto
        '
        Me.Gb_Proyecto.Controls.Add(Me.Cb_Proyecto)
        Me.Gb_Proyecto.Controls.Add(Me.Lb_TextoProyecto)
        Me.Gb_Proyecto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gb_Proyecto.Location = New System.Drawing.Point(9, 9)
        Me.Gb_Proyecto.Margin = New System.Windows.Forms.Padding(9, 9, 9, 9)
        Me.Gb_Proyecto.Name = "Gb_Proyecto"
        Me.Gb_Proyecto.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Gb_Proyecto.Size = New System.Drawing.Size(484, 93)
        Me.Gb_Proyecto.TabIndex = 0
        Me.Gb_Proyecto.TabStop = False
        Me.Gb_Proyecto.Text = "Seleccionar proyecto"
        '
        'Cb_Proyecto
        '
        Me.Cb_Proyecto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.Cb_Proyecto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Proyecto.DisplayMember = "PROYECTO"
        Me.Cb_Proyecto.FormattingEnabled = True
        Me.Cb_Proyecto.Location = New System.Drawing.Point(81, 25)
        Me.Cb_Proyecto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cb_Proyecto.Name = "Cb_Proyecto"
        Me.Cb_Proyecto.Size = New System.Drawing.Size(372, 24)
        Me.Cb_Proyecto.TabIndex = 3
        Me.Cb_Proyecto.ValueMember = "IDPROYECTO"
        '
        'Lb_TextoProyecto
        '
        Me.Lb_TextoProyecto.AutoSize = True
        Me.Lb_TextoProyecto.Location = New System.Drawing.Point(8, 30)
        Me.Lb_TextoProyecto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_TextoProyecto.Name = "Lb_TextoProyecto"
        Me.Lb_TextoProyecto.Size = New System.Drawing.Size(68, 17)
        Me.Lb_TextoProyecto.TabIndex = 2
        Me.Lb_TextoProyecto.Text = "Proyecto:"
        '
        'Flp_Usuario
        '
        Me.Flp_Usuario.Controls.Add(Me.Lb_TextoBienvenido)
        Me.Flp_Usuario.Controls.Add(Me.Lb_Nombre)
        Me.Flp_Usuario.Dock = System.Windows.Forms.DockStyle.Top
        Me.Flp_Usuario.Location = New System.Drawing.Point(0, 0)
        Me.Flp_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Usuario.Name = "Flp_Usuario"
        Me.Flp_Usuario.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.Flp_Usuario.Size = New System.Drawing.Size(1005, 32)
        Me.Flp_Usuario.TabIndex = 0
        '
        'Fr_Bienvenida
        '
        Me.AcceptButton = Me.Bt_Aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 543)
        Me.Controls.Add(Me.Pn_Noticias)
        Me.Controls.Add(Me.Tlp_DatosInicio)
        Me.Controls.Add(Me.Flp_Usuario)
        Me.Controls.Add(Me.Tlp_Opciones)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_Bienvenida"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mensaje de bienvenida"
        Me.Gb_Noticias.ResumeLayout(False)
        Me.Pn_Noticias.ResumeLayout(False)
        Me.Flp_Botones.ResumeLayout(False)
        Me.Tlp_Opciones.ResumeLayout(False)
        Me.Tlp_Opciones.PerformLayout()
        Me.Flp_Opciones.ResumeLayout(False)
        Me.Flp_Opciones.PerformLayout()
        Me.Gb_Contacto.ResumeLayout(False)
        Me.Gb_Contacto.PerformLayout()
        Me.Tlp_DatosInicio.ResumeLayout(False)
        Me.Gb_Proyecto.ResumeLayout(False)
        Me.Gb_Proyecto.PerformLayout()
        Me.Flp_Usuario.ResumeLayout(False)
        Me.Flp_Usuario.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Gb_Noticias As System.Windows.Forms.GroupBox
    Friend WithEvents Pn_Noticias As System.Windows.Forms.Panel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Ck_MostrarSiempre As System.Windows.Forms.CheckBox
    Friend WithEvents Tlp_Opciones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Flp_Opciones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Gb_Contacto As System.Windows.Forms.GroupBox
    Friend WithEvents Tx_MovilCorporativo As System.Windows.Forms.TextBox
    Friend WithEvents Tx_EmailCorporativo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_MovilCorporativo As System.Windows.Forms.Label
    Friend WithEvents Lb_EmailCorporativo As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoBienvenido As System.Windows.Forms.Label
    Friend WithEvents Wb_Noticias As System.Windows.Forms.WebBrowser
    Friend WithEvents Tt_Bienvenida As System.Windows.Forms.ToolTip
    Friend WithEvents Tlp_DatosInicio As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Bt_ActualizarContacto As System.Windows.Forms.Button
    Friend WithEvents Gb_Proyecto As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_Proyecto As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoProyecto As System.Windows.Forms.Label
    Friend WithEvents Flp_Usuario As System.Windows.Forms.FlowLayoutPanel
End Class
