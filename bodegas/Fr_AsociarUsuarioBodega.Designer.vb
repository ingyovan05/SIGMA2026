<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AsociarUsuarioBodega
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
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_AsociarUsuarioBodega))
    Me.Dgv_UsuarioBodega = New System.Windows.Forms.DataGridView()
    Me.IDPERSONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.PERSONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ABREVIATURA = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.IDBODEGA = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.BODEGA = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ASOCIADO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.USUARIO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BASE = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.COMPRADOR = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.Cms_opciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.MarcarTodas = New System.Windows.Forms.ToolStripMenuItem()
    Me.DemarcarTodas = New System.Windows.Forms.ToolStripMenuItem()
    Me.Cb_Bodega = New System.Windows.Forms.ComboBox()
    Me.Btn_cerrar = New System.Windows.Forms.Button()
    Me.Pn_Encabezado = New System.Windows.Forms.Panel()
    Me.Bt_CargarBodegasxUsuario = New System.Windows.Forms.Button()
    Me.Bt_CargarUsuariosxBodega = New System.Windows.Forms.Button()
    Me.Cb_BodegaAbreviatura = New System.Windows.Forms.ComboBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Cu_BuscarPersona = New FormulariosClasesBase.Cu_BuscarPersona()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Pn_Botones = New System.Windows.Forms.Panel()
    Me.Lb_Mensaje = New System.Windows.Forms.Label()
    Me.Btn_Cancelar = New System.Windows.Forms.Button()
    Me.Btn_Guardar = New System.Windows.Forms.Button()
    CType(Me.Dgv_UsuarioBodega, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Cms_opciones.SuspendLayout()
    Me.Pn_Encabezado.SuspendLayout()
    Me.Pn_Botones.SuspendLayout()
    Me.SuspendLayout()
    '
    'Dgv_UsuarioBodega
    '
    Me.Dgv_UsuarioBodega.AllowUserToAddRows = False
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Dgv_UsuarioBodega.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
    Me.Dgv_UsuarioBodega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_UsuarioBodega.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDPERSONA, Me.PERSONA, Me.ABREVIATURA, Me.IDBODEGA, Me.BODEGA, Me.ASOCIADO, Me.USUARIO, Me.BASE, Me.ESTADO, Me.COMPRADOR})
    Me.Dgv_UsuarioBodega.ContextMenuStrip = Me.Cms_opciones
    Me.Dgv_UsuarioBodega.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Dgv_UsuarioBodega.Location = New System.Drawing.Point(0, 61)
    Me.Dgv_UsuarioBodega.Name = "Dgv_UsuarioBodega"
    Me.Dgv_UsuarioBodega.Size = New System.Drawing.Size(731, 327)
    Me.Dgv_UsuarioBodega.TabIndex = 0
    '
    'IDPERSONA
    '
    Me.IDPERSONA.DataPropertyName = "IDPERSONA"
    Me.IDPERSONA.HeaderText = "IDPERSONA"
    Me.IDPERSONA.Name = "IDPERSONA"
    Me.IDPERSONA.ReadOnly = True
    Me.IDPERSONA.Visible = False
    '
    'PERSONA
    '
    Me.PERSONA.DataPropertyName = "PERSONA"
    Me.PERSONA.HeaderText = "Persona"
    Me.PERSONA.Name = "PERSONA"
    Me.PERSONA.ReadOnly = True
    Me.PERSONA.Width = 300
    '
    'ABREVIATURA
    '
    Me.ABREVIATURA.DataPropertyName = "ABREVIATURA"
    Me.ABREVIATURA.HeaderText = "Abreviatura"
    Me.ABREVIATURA.Name = "ABREVIATURA"
    Me.ABREVIATURA.ReadOnly = True
    '
    'IDBODEGA
    '
    Me.IDBODEGA.DataPropertyName = "IDBODEGA"
    Me.IDBODEGA.HeaderText = "IDBODEGA"
    Me.IDBODEGA.Name = "IDBODEGA"
    Me.IDBODEGA.ReadOnly = True
    '
    'BODEGA
    '
    Me.BODEGA.DataPropertyName = "BODEGA"
    Me.BODEGA.HeaderText = "Bodega"
    Me.BODEGA.Name = "BODEGA"
    Me.BODEGA.ReadOnly = True
    Me.BODEGA.Width = 300
    '
    'ASOCIADO
    '
    Me.ASOCIADO.DataPropertyName = "ASOCIADO"
    Me.ASOCIADO.FalseValue = "N"
    Me.ASOCIADO.HeaderText = "Asociado"
    Me.ASOCIADO.Name = "ASOCIADO"
    Me.ASOCIADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.ASOCIADO.TrueValue = "S"
    Me.ASOCIADO.Width = 80
    '
    'USUARIO
    '
    Me.USUARIO.DataPropertyName = "USUARIO"
    Me.USUARIO.FalseValue = "N"
    Me.USUARIO.HeaderText = "Usuario"
    Me.USUARIO.Name = "USUARIO"
    Me.USUARIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.USUARIO.TrueValue = "S"
    Me.USUARIO.Width = 80
    '
    'BASE
    '
    Me.BASE.DataPropertyName = "BASE"
    Me.BASE.FalseValue = "N"
    Me.BASE.HeaderText = "Base"
    Me.BASE.Name = "BASE"
    Me.BASE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.BASE.TrueValue = "S"
    Me.BASE.Width = 80
    '
    'ESTADO
    '
    Me.ESTADO.DataPropertyName = "ESTADO"
    Me.ESTADO.FalseValue = "N"
    Me.ESTADO.HeaderText = "Estado"
    Me.ESTADO.Name = "ESTADO"
    Me.ESTADO.ReadOnly = True
    Me.ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.ESTADO.TrueValue = "S"
    Me.ESTADO.Visible = False
        Me.ESTADO.Width = 80
        '
        'COMPRADOR
        '
        Me.COMPRADOR.DataPropertyName = "COMPRADOR"
        Me.COMPRADOR.FalseValue = "N"
        Me.COMPRADOR.HeaderText = "Comprador"
        Me.COMPRADOR.Name = "COMPRADOR"
        Me.COMPRADOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.COMPRADOR.TrueValue = "S"
        Me.COMPRADOR.Visible = False
        Me.COMPRADOR.Width = 80
    '
    'Cms_opciones
    '
    Me.Cms_opciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MarcarTodas, Me.DemarcarTodas})
    Me.Cms_opciones.Name = "ContextMenuStrip1"
    Me.Cms_opciones.Size = New System.Drawing.Size(166, 48)
    '
    'MarcarTodas
    '
    Me.MarcarTodas.Name = "MarcarTodas"
    Me.MarcarTodas.Size = New System.Drawing.Size(165, 22)
    Me.MarcarTodas.Text = "Marcar Todas"
    '
    'DemarcarTodas
    '
    Me.DemarcarTodas.Name = "DemarcarTodas"
    Me.DemarcarTodas.Size = New System.Drawing.Size(165, 22)
    Me.DemarcarTodas.Text = "Desmarcar Todas"
    '
    'Cb_Bodega
    '
    Me.Cb_Bodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.Cb_Bodega.FormattingEnabled = True
    Me.Cb_Bodega.Location = New System.Drawing.Point(184, 31)
    Me.Cb_Bodega.Name = "Cb_Bodega"
    Me.Cb_Bodega.Size = New System.Drawing.Size(375, 21)
    Me.Cb_Bodega.TabIndex = 5
    '
    'Btn_cerrar
    '
    Me.Btn_cerrar.Location = New System.Drawing.Point(647, 4)
    Me.Btn_cerrar.Name = "Btn_cerrar"
    Me.Btn_cerrar.Size = New System.Drawing.Size(75, 23)
    Me.Btn_cerrar.TabIndex = 6
    Me.Btn_cerrar.Text = "Cerrar"
    Me.Btn_cerrar.UseVisualStyleBackColor = True
    '
    'Pn_Encabezado
    '
    Me.Pn_Encabezado.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Pn_Encabezado.Controls.Add(Me.Bt_CargarBodegasxUsuario)
    Me.Pn_Encabezado.Controls.Add(Me.Bt_CargarUsuariosxBodega)
    Me.Pn_Encabezado.Controls.Add(Me.Cb_BodegaAbreviatura)
    Me.Pn_Encabezado.Controls.Add(Me.Label2)
    Me.Pn_Encabezado.Controls.Add(Me.Cu_BuscarPersona)
    Me.Pn_Encabezado.Controls.Add(Me.Label1)
    Me.Pn_Encabezado.Controls.Add(Me.Cb_Bodega)
    Me.Pn_Encabezado.Dock = System.Windows.Forms.DockStyle.Top
    Me.Pn_Encabezado.Location = New System.Drawing.Point(0, 0)
    Me.Pn_Encabezado.Name = "Pn_Encabezado"
    Me.Pn_Encabezado.Size = New System.Drawing.Size(731, 61)
    Me.Pn_Encabezado.TabIndex = 8
    '
    'Bt_CargarBodegasxUsuario
    '
    Me.Bt_CargarBodegasxUsuario.Location = New System.Drawing.Point(565, 5)
    Me.Bt_CargarBodegasxUsuario.Name = "Bt_CargarBodegasxUsuario"
    Me.Bt_CargarBodegasxUsuario.Size = New System.Drawing.Size(145, 23)
    Me.Bt_CargarBodegasxUsuario.TabIndex = 11
    Me.Bt_CargarBodegasxUsuario.Text = "Cargar Bodegas x Usuario"
    Me.Bt_CargarBodegasxUsuario.UseVisualStyleBackColor = True
    '
    'Bt_CargarUsuariosxBodega
    '
    Me.Bt_CargarUsuariosxBodega.Location = New System.Drawing.Point(565, 30)
    Me.Bt_CargarUsuariosxBodega.Name = "Bt_CargarUsuariosxBodega"
    Me.Bt_CargarUsuariosxBodega.Size = New System.Drawing.Size(145, 23)
    Me.Bt_CargarUsuariosxBodega.TabIndex = 10
    Me.Bt_CargarUsuariosxBodega.Text = "Cargar Usuarios x Bodega"
    Me.Bt_CargarUsuariosxBodega.UseVisualStyleBackColor = True
    '
    'Cb_BodegaAbreviatura
    '
    Me.Cb_BodegaAbreviatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.Cb_BodegaAbreviatura.FormattingEnabled = True
    Me.Cb_BodegaAbreviatura.Location = New System.Drawing.Point(65, 31)
    Me.Cb_BodegaAbreviatura.Name = "Cb_BodegaAbreviatura"
    Me.Cb_BodegaAbreviatura.Size = New System.Drawing.Size(113, 21)
    Me.Cb_BodegaAbreviatura.TabIndex = 10
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 35)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(47, 13)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "Bodega:"
    '
    'Cu_BuscarPersona
    '
    Me.Cu_BuscarPersona.FechaReporteDiario = New Date(CType(0, Long))
    Me.Cu_BuscarPersona.Location = New System.Drawing.Point(62, 5)
    Me.Cu_BuscarPersona.Name = "Cu_BuscarPersona"
    Me.Cu_BuscarPersona.Size = New System.Drawing.Size(498, 23)
    Me.Cu_BuscarPersona.TabIndex = 7
    Me.Cu_BuscarPersona.Tipo = "PUACB"
    Me.Cu_BuscarPersona.valorcajatexto = "IDENTIFICACION"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 10)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(47, 13)
    Me.Label1.TabIndex = 6
    Me.Label1.Text = "Nombre:"
    '
    'Pn_Botones
    '
    Me.Pn_Botones.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Pn_Botones.Controls.Add(Me.Lb_Mensaje)
    Me.Pn_Botones.Controls.Add(Me.Btn_Cancelar)
    Me.Pn_Botones.Controls.Add(Me.Btn_Guardar)
    Me.Pn_Botones.Controls.Add(Me.Btn_cerrar)
    Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Pn_Botones.Location = New System.Drawing.Point(0, 388)
    Me.Pn_Botones.Name = "Pn_Botones"
    Me.Pn_Botones.Size = New System.Drawing.Size(731, 30)
    Me.Pn_Botones.TabIndex = 9
    '
    'Lb_Mensaje
    '
    Me.Lb_Mensaje.AutoSize = True
    Me.Lb_Mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Lb_Mensaje.ForeColor = System.Drawing.Color.Blue
    Me.Lb_Mensaje.Location = New System.Drawing.Point(22, 6)
    Me.Lb_Mensaje.Name = "Lb_Mensaje"
    Me.Lb_Mensaje.Size = New System.Drawing.Size(68, 17)
    Me.Lb_Mensaje.TabIndex = 12
    Me.Lb_Mensaje.Text = "Mensaje"
    Me.Lb_Mensaje.Visible = False
    '
    'Btn_Cancelar
    '
    Me.Btn_Cancelar.Enabled = False
    Me.Btn_Cancelar.Location = New System.Drawing.Point(566, 4)
    Me.Btn_Cancelar.Name = "Btn_Cancelar"
    Me.Btn_Cancelar.Size = New System.Drawing.Size(75, 23)
    Me.Btn_Cancelar.TabIndex = 9
    Me.Btn_Cancelar.Text = "Cancelar"
    Me.Btn_Cancelar.UseVisualStyleBackColor = True
    '
    'Btn_Guardar
    '
    Me.Btn_Guardar.Enabled = False
    Me.Btn_Guardar.Location = New System.Drawing.Point(485, 4)
    Me.Btn_Guardar.Name = "Btn_Guardar"
    Me.Btn_Guardar.Size = New System.Drawing.Size(75, 23)
    Me.Btn_Guardar.TabIndex = 8
    Me.Btn_Guardar.Text = "Guardar"
    Me.Btn_Guardar.UseVisualStyleBackColor = True
    '
    'Fr_AsociarUsuarioBodega
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(731, 418)
    Me.Controls.Add(Me.Dgv_UsuarioBodega)
    Me.Controls.Add(Me.Pn_Botones)
    Me.Controls.Add(Me.Pn_Encabezado)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Fr_AsociarUsuarioBodega"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Asociar Usuario Bodega"
    CType(Me.Dgv_UsuarioBodega, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Cms_opciones.ResumeLayout(False)
    Me.Pn_Encabezado.ResumeLayout(False)
    Me.Pn_Encabezado.PerformLayout()
    Me.Pn_Botones.ResumeLayout(False)
    Me.Pn_Botones.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Dgv_UsuarioBodega As System.Windows.Forms.DataGridView
  Friend WithEvents Cb_Bodega As System.Windows.Forms.ComboBox
  Friend WithEvents Btn_cerrar As System.Windows.Forms.Button
  Friend WithEvents Pn_Encabezado As System.Windows.Forms.Panel
  Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
  Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
  Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Public WithEvents Cu_BuscarPersona As FormulariosClasesBase.Cu_BuscarPersona
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Bt_CargarBodegasxUsuario As System.Windows.Forms.Button
  Friend WithEvents Bt_CargarUsuariosxBodega As System.Windows.Forms.Button
  Friend WithEvents Cb_BodegaAbreviatura As System.Windows.Forms.ComboBox
  Friend WithEvents Lb_Mensaje As System.Windows.Forms.Label
  Friend WithEvents IDPERSONA As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents PERSONA As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ABREVIATURA As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents IDBODEGA As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents BODEGA As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ASOCIADO As System.Windows.Forms.DataGridViewCheckBoxColumn
  Friend WithEvents USUARIO As System.Windows.Forms.DataGridViewCheckBoxColumn
  Friend WithEvents BASE As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents COMPRADOR As System.Windows.Forms.DataGridViewCheckBoxColumn
  Friend WithEvents Cms_opciones As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents MarcarTodas As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents DemarcarTodas As System.Windows.Forms.ToolStripMenuItem
End Class
