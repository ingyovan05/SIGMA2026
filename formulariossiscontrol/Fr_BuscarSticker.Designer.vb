<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_BuscarSticker
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Dgv_Buscar = New System.Windows.Forms.DataGridView()
        Me.Pn_Controles = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Ck_Filtrar = New System.Windows.Forms.CheckBox()
        Me.Cb_Filtrar = New System.Windows.Forms.ComboBox()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Tm_Temporizador = New System.Windows.Forms.Timer(Me.components)
        Me.Col_IdSticker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Hoja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NumeroSticker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdDependencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Consecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdUsuarioRegistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Controles.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_Buscar
        '
        Me.Dgv_Buscar.AllowUserToAddRows = False
        Me.Dgv_Buscar.AllowUserToDeleteRows = False
        Me.Dgv_Buscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Buscar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_IdSticker, Me.Col_Grupo, Me.Col_Hoja, Me.Col_Item, Me.Col_NumeroSticker, Me.Col_IdDependencia, Me.Col_Consecutivo, Me.Col_FechaRegistro, Me.Col_IdUsuarioRegistra})
        Me.Dgv_Buscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Buscar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Buscar.Location = New System.Drawing.Point(0, 48)
        Me.Dgv_Buscar.MultiSelect = False
        Me.Dgv_Buscar.Name = "Dgv_Buscar"
        Me.Dgv_Buscar.ReadOnly = True
        Me.Dgv_Buscar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Buscar.Size = New System.Drawing.Size(574, 363)
        Me.Dgv_Buscar.TabIndex = 0
        '
        'Pn_Controles
        '
        Me.Pn_Controles.AutoSize = True
        Me.Pn_Controles.Controls.Add(Me.GroupBox1)
        Me.Pn_Controles.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Controles.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Controles.Name = "Pn_Controles"
        Me.Pn_Controles.Padding = New System.Windows.Forms.Padding(4)
        Me.Pn_Controles.Size = New System.Drawing.Size(574, 48)
        Me.Pn_Controles.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.GroupBox1.Size = New System.Drawing.Size(566, 40)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Ck_Filtrar)
        Me.FlowLayoutPanel1.Controls.Add(Me.Cb_Filtrar)
        Me.FlowLayoutPanel1.Controls.Add(Me.Tx_Descripcion)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(10, 13)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(546, 27)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'Ck_Filtrar
        '
        Me.Ck_Filtrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ck_Filtrar.AutoSize = True
        Me.Ck_Filtrar.Checked = True
        Me.Ck_Filtrar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_Filtrar.Location = New System.Drawing.Point(3, 3)
        Me.Ck_Filtrar.Name = "Ck_Filtrar"
        Me.Ck_Filtrar.Size = New System.Drawing.Size(15, 21)
        Me.Ck_Filtrar.TabIndex = 0
        Me.Ck_Filtrar.UseVisualStyleBackColor = True
        '
        'Cb_Filtrar
        '
        Me.Cb_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Filtrar.FormattingEnabled = True
        Me.Cb_Filtrar.Location = New System.Drawing.Point(24, 3)
        Me.Cb_Filtrar.Name = "Cb_Filtrar"
        Me.Cb_Filtrar.Size = New System.Drawing.Size(160, 21)
        Me.Cb_Filtrar.TabIndex = 1
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Location = New System.Drawing.Point(190, 3)
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(350, 20)
        Me.Tx_Descripcion.TabIndex = 2
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 411)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(574, 30)
        Me.Flp_Botones.TabIndex = 0
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(496, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(415, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 1
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Tm_Temporizador
        '
        Me.Tm_Temporizador.Interval = 500
        '
        'Col_IdSticker
        '
        Me.Col_IdSticker.DataPropertyName = "IDSTICKER"
        Me.Col_IdSticker.HeaderText = "IDSTICKER"
        Me.Col_IdSticker.Name = "Col_IdSticker"
        Me.Col_IdSticker.ReadOnly = True
        Me.Col_IdSticker.ToolTipText = "IDSTICKER"
        Me.Col_IdSticker.Visible = False
        '
        'Col_Grupo
        '
        Me.Col_Grupo.DataPropertyName = "GRUPO"
        Me.Col_Grupo.HeaderText = "Grupo"
        Me.Col_Grupo.Name = "Col_Grupo"
        Me.Col_Grupo.ReadOnly = True
        Me.Col_Grupo.ToolTipText = "Número del grupo de impresión"
        Me.Col_Grupo.Width = 60
        '
        'Col_Hoja
        '
        Me.Col_Hoja.DataPropertyName = "HOJA"
        Me.Col_Hoja.HeaderText = "Hoja"
        Me.Col_Hoja.Name = "Col_Hoja"
        Me.Col_Hoja.ReadOnly = True
        Me.Col_Hoja.ToolTipText = "Número de la hoja impresa"
        Me.Col_Hoja.Width = 60
        '
        'Col_Item
        '
        Me.Col_Item.DataPropertyName = "ITEM"
        Me.Col_Item.HeaderText = "Ítem"
        Me.Col_Item.Name = "Col_Item"
        Me.Col_Item.ReadOnly = True
        Me.Col_Item.ToolTipText = "Posición del sticker en la hoja"
        Me.Col_Item.Width = 60
        '
        'Col_NumeroSticker
        '
        Me.Col_NumeroSticker.DataPropertyName = "NUMEROSTICKER"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Col_NumeroSticker.DefaultCellStyle = DataGridViewCellStyle4
        Me.Col_NumeroSticker.HeaderText = "Número Sticker"
        Me.Col_NumeroSticker.Name = "Col_NumeroSticker"
        Me.Col_NumeroSticker.ReadOnly = True
        Me.Col_NumeroSticker.ToolTipText = "Parte numérica del sticker"
        Me.Col_NumeroSticker.Width = 140
        '
        'Col_IdDependencia
        '
        Me.Col_IdDependencia.DataPropertyName = "IDDEPENDENCIA"
        Me.Col_IdDependencia.HeaderText = "IDDEPENDENCIA"
        Me.Col_IdDependencia.Name = "Col_IdDependencia"
        Me.Col_IdDependencia.ReadOnly = True
        Me.Col_IdDependencia.ToolTipText = "IDDEPENDENCIA"
        Me.Col_IdDependencia.Visible = False
        '
        'Col_Consecutivo
        '
        Me.Col_Consecutivo.DataPropertyName = "ETIQUETA"
        Me.Col_Consecutivo.HeaderText = "CONSECUTIVO"
        Me.Col_Consecutivo.Name = "Col_Consecutivo"
        Me.Col_Consecutivo.ReadOnly = True
        Me.Col_Consecutivo.ToolTipText = "CONSECUTIVO"
        Me.Col_Consecutivo.Visible = False
        '
        'Col_FechaRegistro
        '
        Me.Col_FechaRegistro.DataPropertyName = "FECHAREGISTRO"
        Me.Col_FechaRegistro.HeaderText = "FECHAREGISTRO"
        Me.Col_FechaRegistro.Name = "Col_FechaRegistro"
        Me.Col_FechaRegistro.ReadOnly = True
        Me.Col_FechaRegistro.ToolTipText = "FECHAREGISTRO"
        Me.Col_FechaRegistro.Visible = False
        '
        'Col_IdUsuarioRegistra
        '
        Me.Col_IdUsuarioRegistra.DataPropertyName = "IDUSUARIOREGISTRA"
        Me.Col_IdUsuarioRegistra.HeaderText = "IDUSUARIOREGISTRA"
        Me.Col_IdUsuarioRegistra.Name = "Col_IdUsuarioRegistra"
        Me.Col_IdUsuarioRegistra.ReadOnly = True
        Me.Col_IdUsuarioRegistra.ToolTipText = "IDUSUARIOREGISTRA"
        Me.Col_IdUsuarioRegistra.Visible = False
        '
        'Fr_BuscarSticker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 441)
        Me.Controls.Add(Me.Dgv_Buscar)
        Me.Controls.Add(Me.Pn_Controles)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Name = "Fr_BuscarSticker"
        Me.ShowIcon = False
        Me.Text = "Buscar Sticker"
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Controles.ResumeLayout(False)
        Me.Pn_Controles.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dgv_Buscar As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Controles As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Ck_Filtrar As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Filtrar As System.Windows.Forms.ComboBox
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Tm_Temporizador As System.Windows.Forms.Timer
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Col_IdSticker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Hoja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NumeroSticker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdDependencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Consecutivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdUsuarioRegistra As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
