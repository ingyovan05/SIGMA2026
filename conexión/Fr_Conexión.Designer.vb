<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Conexión
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Conexión))
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_ProbarTodas = New System.Windows.Forms.Button()
        Me.Ts_Acciones = New System.Windows.Forms.ToolStrip()
        Me.Tsb_AgregarFila = New System.Windows.Forms.ToolStripButton()
        Me.Tsb_EliminarFila = New System.Windows.Forms.ToolStripButton()
        Me.Tss_Separador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Tsb_EditarConexion = New System.Windows.Forms.ToolStripButton()
        Me.Tss_Separador2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Tsb_SubirFila = New System.Windows.Forms.ToolStripButton()
        Me.Tsb_BajarFila = New System.Windows.Forms.ToolStripButton()
        Me.Dgv_Servidores = New System.Windows.Forms.DataGridView()
        Me.Col_Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Servidor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Contrasena = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_BaseDatos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_ProbarSeleccionada = New System.Windows.Forms.Button()
        Me.Flp_Botones.SuspendLayout()
        Me.Ts_Acciones.SuspendLayout()
        CType(Me.Dgv_Servidores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(324, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(170, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.Location = New System.Drawing.Point(92, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Bt_Guardar.Location = New System.Drawing.Point(11, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_ProbarTodas
        '
        Me.Bt_ProbarTodas.AutoSize = True
        Me.Bt_ProbarTodas.Location = New System.Drawing.Point(104, 3)
        Me.Bt_ProbarTodas.Name = "Bt_ProbarTodas"
        Me.Bt_ProbarTodas.Size = New System.Drawing.Size(151, 23)
        Me.Bt_ProbarTodas.TabIndex = 0
        Me.Bt_ProbarTodas.Text = "Probar todas las Conexiones"
        Me.Bt_ProbarTodas.UseVisualStyleBackColor = True
        '
        'Ts_Acciones
        '
        Me.Ts_Acciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsb_AgregarFila, Me.Tsb_EliminarFila, Me.Tss_Separador1, Me.Tsb_EditarConexion, Me.Tss_Separador2, Me.Tsb_SubirFila, Me.Tsb_BajarFila})
        Me.Ts_Acciones.Location = New System.Drawing.Point(0, 0)
        Me.Ts_Acciones.Name = "Ts_Acciones"
        Me.Ts_Acciones.Size = New System.Drawing.Size(494, 27)
        Me.Ts_Acciones.TabIndex = 0
        Me.Ts_Acciones.Text = "ToolStrip1"
        '
        'Tsb_AgregarFila
        '
        Me.Tsb_AgregarFila.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Tsb_AgregarFila.Font = New System.Drawing.Font("Segoe UI Emoji", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsb_AgregarFila.Image = CType(resources.GetObject("Tsb_AgregarFila.Image"), System.Drawing.Image)
        Me.Tsb_AgregarFila.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsb_AgregarFila.Name = "Tsb_AgregarFila"
        Me.Tsb_AgregarFila.Size = New System.Drawing.Size(28, 24)
        Me.Tsb_AgregarFila.Text = "➕"
        Me.Tsb_AgregarFila.ToolTipText = "Agregar fila"
        '
        'Tsb_EliminarFila
        '
        Me.Tsb_EliminarFila.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Tsb_EliminarFila.Font = New System.Drawing.Font("Segoe UI Emoji", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsb_EliminarFila.Image = CType(resources.GetObject("Tsb_EliminarFila.Image"), System.Drawing.Image)
        Me.Tsb_EliminarFila.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsb_EliminarFila.Name = "Tsb_EliminarFila"
        Me.Tsb_EliminarFila.Size = New System.Drawing.Size(28, 24)
        Me.Tsb_EliminarFila.Text = "➖"
        Me.Tsb_EliminarFila.ToolTipText = "Eliminar fila"
        '
        'Tss_Separador1
        '
        Me.Tss_Separador1.Name = "Tss_Separador1"
        Me.Tss_Separador1.Size = New System.Drawing.Size(6, 27)
        '
        'Tsb_EditarConexion
        '
        Me.Tsb_EditarConexion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Tsb_EditarConexion.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsb_EditarConexion.Image = CType(resources.GetObject("Tsb_EditarConexion.Image"), System.Drawing.Image)
        Me.Tsb_EditarConexion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsb_EditarConexion.Name = "Tsb_EditarConexion"
        Me.Tsb_EditarConexion.Size = New System.Drawing.Size(30, 24)
        Me.Tsb_EditarConexion.Text = "📝"
        Me.Tsb_EditarConexion.ToolTipText = "Editar conexión"
        '
        'Tss_Separador2
        '
        Me.Tss_Separador2.Name = "Tss_Separador2"
        Me.Tss_Separador2.Size = New System.Drawing.Size(6, 27)
        '
        'Tsb_SubirFila
        '
        Me.Tsb_SubirFila.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Tsb_SubirFila.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsb_SubirFila.Image = CType(resources.GetObject("Tsb_SubirFila.Image"), System.Drawing.Image)
        Me.Tsb_SubirFila.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsb_SubirFila.Name = "Tsb_SubirFila"
        Me.Tsb_SubirFila.Size = New System.Drawing.Size(27, 24)
        Me.Tsb_SubirFila.Text = "🠉"
        Me.Tsb_SubirFila.ToolTipText = "Subir fila"
        '
        'Tsb_BajarFila
        '
        Me.Tsb_BajarFila.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Tsb_BajarFila.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsb_BajarFila.Image = CType(resources.GetObject("Tsb_BajarFila.Image"), System.Drawing.Image)
        Me.Tsb_BajarFila.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsb_BajarFila.Name = "Tsb_BajarFila"
        Me.Tsb_BajarFila.Size = New System.Drawing.Size(27, 24)
        Me.Tsb_BajarFila.Text = "🠋"
        Me.Tsb_BajarFila.ToolTipText = "Bajar fila"
        '
        'Dgv_Servidores
        '
        Me.Dgv_Servidores.AllowUserToAddRows = False
        Me.Dgv_Servidores.AllowUserToDeleteRows = False
        Me.Dgv_Servidores.AllowUserToOrderColumns = True
        Me.Dgv_Servidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Servidores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_Orden, Me.Col_Descripcion, Me.Col_Servidor, Me.Col_Usuario, Me.Col_Contrasena, Me.Col_BaseDatos})
        Me.Dgv_Servidores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Servidores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Servidores.Location = New System.Drawing.Point(0, 27)
        Me.Dgv_Servidores.Name = "Dgv_Servidores"
        Me.Dgv_Servidores.Size = New System.Drawing.Size(494, 316)
        Me.Dgv_Servidores.TabIndex = 1
        '
        'Col_Orden
        '
        Me.Col_Orden.DataPropertyName = "ORDEN"
        Me.Col_Orden.HeaderText = "Orden"
        Me.Col_Orden.Name = "Col_Orden"
        Me.Col_Orden.ReadOnly = True
        Me.Col_Orden.ToolTipText = "Orden"
        Me.Col_Orden.Width = 50
        '
        'Col_Descripcion
        '
        Me.Col_Descripcion.DataPropertyName = "DESCRIPCION"
        Me.Col_Descripcion.HeaderText = "Descripción"
        Me.Col_Descripcion.Name = "Col_Descripcion"
        Me.Col_Descripcion.ToolTipText = "Descripción"
        Me.Col_Descripcion.Width = 150
        '
        'Col_Servidor
        '
        Me.Col_Servidor.DataPropertyName = "SERVIDOR"
        Me.Col_Servidor.HeaderText = "Servidor"
        Me.Col_Servidor.Name = "Col_Servidor"
        Me.Col_Servidor.ToolTipText = "Dirección IP del servidor"
        '
        'Col_Usuario
        '
        Me.Col_Usuario.DataPropertyName = "NOMBREUSUARIO"
        Me.Col_Usuario.HeaderText = "Usuario"
        Me.Col_Usuario.Name = "Col_Usuario"
        Me.Col_Usuario.ReadOnly = True
        Me.Col_Usuario.ToolTipText = "Nombre de usuario"
        Me.Col_Usuario.Visible = False
        '
        'Col_Contrasena
        '
        Me.Col_Contrasena.DataPropertyName = "CONTRASENA"
        Me.Col_Contrasena.HeaderText = "Contraseña"
        Me.Col_Contrasena.Name = "Col_Contrasena"
        Me.Col_Contrasena.ReadOnly = True
        Me.Col_Contrasena.ToolTipText = "Contraseña"
        Me.Col_Contrasena.Visible = False
        '
        'Col_BaseDatos
        '
        Me.Col_BaseDatos.DataPropertyName = "NOMBREBASEDATOS"
        Me.Col_BaseDatos.HeaderText = "Base de datos"
        Me.Col_BaseDatos.Name = "Col_BaseDatos"
        Me.Col_BaseDatos.ToolTipText = "Nombre de la base de datos"
        Me.Col_BaseDatos.Width = 150
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 313)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(494, 30)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Bt_ProbarSeleccionada)
        Me.FlowLayoutPanel1.Controls.Add(Me.Bt_ProbarTodas)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(324, 30)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'Bt_ProbarSeleccionada
        '
        Me.Bt_ProbarSeleccionada.AutoSize = True
        Me.Bt_ProbarSeleccionada.Location = New System.Drawing.Point(3, 3)
        Me.Bt_ProbarSeleccionada.Name = "Bt_ProbarSeleccionada"
        Me.Bt_ProbarSeleccionada.Size = New System.Drawing.Size(95, 23)
        Me.Bt_ProbarSeleccionada.TabIndex = 1
        Me.Bt_ProbarSeleccionada.Text = "Probar Conexión"
        Me.Bt_ProbarSeleccionada.UseVisualStyleBackColor = True
        '
        'Fr_Conexión
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 343)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Dgv_Servidores)
        Me.Controls.Add(Me.Ts_Acciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_Conexión"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Conexión al Servidor SQL SERVER"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Ts_Acciones.ResumeLayout(False)
        Me.Ts_Acciones.PerformLayout()
        CType(Me.Dgv_Servidores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_ProbarTodas As System.Windows.Forms.Button
    Friend WithEvents Ts_Acciones As System.Windows.Forms.ToolStrip
    Friend WithEvents Tsb_AgregarFila As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsb_EliminarFila As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss_Separador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Tsb_EditarConexion As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tss_Separador2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Tsb_SubirFila As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsb_BajarFila As System.Windows.Forms.ToolStripButton
    Friend WithEvents Dgv_Servidores As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Col_Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Servidor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Contrasena As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_BaseDatos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_ProbarSeleccionada As System.Windows.Forms.Button
End Class
