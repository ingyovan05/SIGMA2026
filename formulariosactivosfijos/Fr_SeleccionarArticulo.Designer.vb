<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_SeleccionarArticulo
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
        Me.Cb_Filtrar = New System.Windows.Forms.CheckBox()
        Me.Tb_Filtro = New System.Windows.Forms.TextBox()
        Me.Cb_Filtro = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tb_Tipo = New System.Windows.Forms.TextBox()
        Me.Tb_Subtipo = New System.Windows.Forms.TextBox()
        Me.Dgv_Articulos = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBTIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPONOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBTIPONOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_descripcion = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Dgv_Articulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cb_Filtrar
        '
        Me.Cb_Filtrar.AutoSize = True
        Me.Cb_Filtrar.Location = New System.Drawing.Point(249, 45)
        Me.Cb_Filtrar.Name = "Cb_Filtrar"
        Me.Cb_Filtrar.Size = New System.Drawing.Size(209, 17)
        Me.Cb_Filtrar.TabIndex = 4
        Me.Cb_Filtrar.Text = "Buscar En Todos Los Tipos y Subtipos"
        Me.Cb_Filtrar.UseVisualStyleBackColor = True
        '
        'Tb_Filtro
        '
        Me.Tb_Filtro.Location = New System.Drawing.Point(249, 19)
        Me.Tb_Filtro.Name = "Tb_Filtro"
        Me.Tb_Filtro.Size = New System.Drawing.Size(451, 20)
        Me.Tb_Filtro.TabIndex = 3
        '
        'Cb_Filtro
        '
        Me.Cb_Filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Filtro.FormattingEnabled = True
        Me.Cb_Filtro.Items.AddRange(New Object() {"Descripción", "NOMBRE"})
        Me.Cb_Filtro.Location = New System.Drawing.Point(33, 19)
        Me.Cb_Filtro.Name = "Cb_Filtro"
        Me.Cb_Filtro.Size = New System.Drawing.Size(198, 21)
        Me.Cb_Filtro.Sorted = True
        Me.Cb_Filtro.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cb_Filtro)
        Me.GroupBox1.Controls.Add(Me.Cb_Filtrar)
        Me.GroupBox1.Controls.Add(Me.Tb_Filtro)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(710, 67)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Tipo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(382, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Subtipo"
        '
        'Tb_Tipo
        '
        Me.Tb_Tipo.Location = New System.Drawing.Point(43, 80)
        Me.Tb_Tipo.Name = "Tb_Tipo"
        Me.Tb_Tipo.ReadOnly = True
        Me.Tb_Tipo.Size = New System.Drawing.Size(333, 20)
        Me.Tb_Tipo.TabIndex = 9
        '
        'Tb_Subtipo
        '
        Me.Tb_Subtipo.Location = New System.Drawing.Point(431, 80)
        Me.Tb_Subtipo.Name = "Tb_Subtipo"
        Me.Tb_Subtipo.ReadOnly = True
        Me.Tb_Subtipo.Size = New System.Drawing.Size(279, 20)
        Me.Tb_Subtipo.TabIndex = 10
        '
        'Dgv_Articulos
        '
        Me.Dgv_Articulos.AllowUserToAddRows = False
        Me.Dgv_Articulos.AllowUserToDeleteRows = False
        Me.Dgv_Articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Articulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.NOMBRE, Me.DESCRIPCION, Me.TIPO, Me.SUBTIPO, Me.TIPONOMBRE, Me.SUBTIPONOMBRE})
        Me.Dgv_Articulos.Location = New System.Drawing.Point(10, 122)
        Me.Dgv_Articulos.MultiSelect = False
        Me.Dgv_Articulos.Name = "Dgv_Articulos"
        Me.Dgv_Articulos.ReadOnly = True
        Me.Dgv_Articulos.Size = New System.Drawing.Size(706, 226)
        Me.Dgv_Articulos.TabIndex = 11
        '
        'ID
        '
        Me.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ID.DataPropertyName = "IDARTICULO"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 43
        '
        'NOMBRE
        '
        Me.NOMBRE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NOMBRE.DataPropertyName = "NOMBRE"
        Me.NOMBRE.HeaderText = "NOMBRE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DESCRIPCION.DataPropertyName = "NOMBREDESCRIPTIVO"
        Me.DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Visible = False
        '
        'TIPO
        '
        Me.TIPO.DataPropertyName = "IDTIPO"
        Me.TIPO.HeaderText = "ID TIPO"
        Me.TIPO.Name = "TIPO"
        Me.TIPO.ReadOnly = True
        Me.TIPO.Visible = False
        '
        'SUBTIPO
        '
        Me.SUBTIPO.DataPropertyName = "IDSUBTIPO"
        Me.SUBTIPO.HeaderText = "ID SUBTIPO"
        Me.SUBTIPO.Name = "SUBTIPO"
        Me.SUBTIPO.ReadOnly = True
        Me.SUBTIPO.Visible = False
        '
        'TIPONOMBRE
        '
        Me.TIPONOMBRE.DataPropertyName = "NOMBRETIPO"
        Me.TIPONOMBRE.HeaderText = "TIPO"
        Me.TIPONOMBRE.Name = "TIPONOMBRE"
        Me.TIPONOMBRE.ReadOnly = True
        '
        'SUBTIPONOMBRE
        '
        Me.SUBTIPONOMBRE.DataPropertyName = "NOMBRESUBTIPO"
        Me.SUBTIPONOMBRE.HeaderText = "SUBTIPO"
        Me.SUBTIPONOMBRE.Name = "SUBTIPONOMBRE"
        Me.SUBTIPONOMBRE.ReadOnly = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(227, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Seleccione el articulo o haga doble click en el."
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.Btn_Cancelar.Location = New System.Drawing.Point(368, 400)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(115, 23)
        Me.Btn_Cancelar.TabIndex = 14
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_Aceptar.Location = New System.Drawing.Point(247, 400)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(115, 23)
        Me.Btn_Aceptar.TabIndex = 13
        Me.Btn_Aceptar.Text = "Aceptar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Lb_descripcion)
        Me.Panel1.Location = New System.Drawing.Point(10, 349)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(706, 40)
        Me.Panel1.TabIndex = 15
        '
        'Lb_descripcion
        '
        Me.Lb_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_descripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_descripcion.Location = New System.Drawing.Point(0, 0)
        Me.Lb_descripcion.Name = "Lb_descripcion"
        Me.Lb_descripcion.Size = New System.Drawing.Size(706, 40)
        Me.Lb_descripcion.TabIndex = 0
        Me.Lb_descripcion.Text = "DESCRIPCION"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDARTICULO"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "NOMBRE"
        Me.DataGridViewTextBoxColumn2.HeaderText = "NOMBRE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NOMBREDESCRIPTIVO"
        Me.DataGridViewTextBoxColumn3.HeaderText = "DESCRIPCION"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "IDTIPO"
        Me.DataGridViewTextBoxColumn4.HeaderText = "TIPO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "IDSUBTIPO"
        Me.DataGridViewTextBoxColumn5.HeaderText = "SUBTIPO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "NOMBRETIPO"
        Me.DataGridViewTextBoxColumn6.HeaderText = "TIPO"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "NOMBRESUBTIPO"
        Me.DataGridViewTextBoxColumn7.HeaderText = "SUBTIPO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'Fr_SeleccionarArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Btn_Cancelar
        Me.ClientSize = New System.Drawing.Size(730, 434)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Btn_Cancelar)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Dgv_Articulos)
        Me.Controls.Add(Me.Tb_Subtipo)
        Me.Controls.Add(Me.Tb_Tipo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Fr_SeleccionarArticulo"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fr_SeleccionarArticulo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Dgv_Articulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cb_Filtrar As System.Windows.Forms.CheckBox
    Friend WithEvents Tb_Filtro As System.Windows.Forms.TextBox
    Friend WithEvents Cb_Filtro As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tb_Tipo As System.Windows.Forms.TextBox
    Friend WithEvents Tb_Subtipo As System.Windows.Forms.TextBox
    Friend WithEvents Dgv_Articulos As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lb_descripcion As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUBTIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPONOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUBTIPONOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
