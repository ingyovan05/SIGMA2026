<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_TiposArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_TiposArticulos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cb_Tipo = New System.Windows.Forms.ComboBox()
        Me.Cb_Subtipo = New System.Windows.Forms.ComboBox()
        Me.Btn_Agregartipo = New System.Windows.Forms.Button()
        Me.Btn_EliminarTipo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_AgregarSubtipo = New System.Windows.Forms.Button()
        Me.Btn_EliminarSubtipo = New System.Windows.Forms.Button()
        Me.Btn_Editartipo = New System.Windows.Forms.Button()
        Me.Btn_EditarSubtipo = New System.Windows.Forms.Button()
        Me.Dgv_Caracteristicas = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IRREPETIBLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btn_AgregarCaracteristica = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Bt_OrdenarSubTipos = New System.Windows.Forms.Button()
        Me.Bt_OrdenarTipo = New System.Windows.Forms.Button()
        Me.Tb_NomSubtipo = New System.Windows.Forms.TextBox()
        Me.Tb_NomTipo = New System.Windows.Forms.TextBox()
        Me.Lbl_Subtipo = New System.Windows.Forms.Label()
        Me.Lbl_Tipo = New System.Windows.Forms.Label()
        CType(Me.Dgv_Caracteristicas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(90, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(433, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Aquí se listan los tipos de articulos y sus correspondientes subtipos con sus car" & _
    "acteristicas"
        '
        'Cb_Tipo
        '
        Me.Cb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Tipo.FormattingEnabled = True
        Me.Cb_Tipo.Location = New System.Drawing.Point(63, 40)
        Me.Cb_Tipo.Name = "Cb_Tipo"
        Me.Cb_Tipo.Size = New System.Drawing.Size(262, 21)
        Me.Cb_Tipo.TabIndex = 1
        '
        'Cb_Subtipo
        '
        Me.Cb_Subtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Subtipo.FormattingEnabled = True
        Me.Cb_Subtipo.Location = New System.Drawing.Point(63, 68)
        Me.Cb_Subtipo.Name = "Cb_Subtipo"
        Me.Cb_Subtipo.Size = New System.Drawing.Size(262, 21)
        Me.Cb_Subtipo.TabIndex = 2
        '
        'Btn_Agregartipo
        '
        Me.Btn_Agregartipo.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_Agregartipo.Location = New System.Drawing.Point(436, 39)
        Me.Btn_Agregartipo.Name = "Btn_Agregartipo"
        Me.Btn_Agregartipo.Size = New System.Drawing.Size(97, 23)
        Me.Btn_Agregartipo.TabIndex = 3
        Me.Btn_Agregartipo.Text = "Agregar Nuevo"
        Me.Btn_Agregartipo.UseVisualStyleBackColor = True
        '
        'Btn_EliminarTipo
        '
        Me.Btn_EliminarTipo.ForeColor = System.Drawing.Color.Maroon
        Me.Btn_EliminarTipo.Location = New System.Drawing.Point(630, 39)
        Me.Btn_EliminarTipo.Name = "Btn_EliminarTipo"
        Me.Btn_EliminarTipo.Size = New System.Drawing.Size(85, 23)
        Me.Btn_EliminarTipo.TabIndex = 4
        Me.Btn_EliminarTipo.Text = "Eliminar"
        Me.Btn_EliminarTipo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-226, -54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-241, -26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Subtipo"
        '
        'Btn_AgregarSubtipo
        '
        Me.Btn_AgregarSubtipo.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_AgregarSubtipo.Location = New System.Drawing.Point(436, 67)
        Me.Btn_AgregarSubtipo.Name = "Btn_AgregarSubtipo"
        Me.Btn_AgregarSubtipo.Size = New System.Drawing.Size(97, 23)
        Me.Btn_AgregarSubtipo.TabIndex = 9
        Me.Btn_AgregarSubtipo.Text = "Agregar Nuevo"
        Me.Btn_AgregarSubtipo.UseVisualStyleBackColor = True
        '
        'Btn_EliminarSubtipo
        '
        Me.Btn_EliminarSubtipo.ForeColor = System.Drawing.Color.Maroon
        Me.Btn_EliminarSubtipo.Location = New System.Drawing.Point(630, 67)
        Me.Btn_EliminarSubtipo.Name = "Btn_EliminarSubtipo"
        Me.Btn_EliminarSubtipo.Size = New System.Drawing.Size(85, 23)
        Me.Btn_EliminarSubtipo.TabIndex = 10
        Me.Btn_EliminarSubtipo.Text = "Eliminar"
        Me.Btn_EliminarSubtipo.UseVisualStyleBackColor = True
        '
        'Btn_Editartipo
        '
        Me.Btn_Editartipo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn_Editartipo.Location = New System.Drawing.Point(539, 39)
        Me.Btn_Editartipo.Name = "Btn_Editartipo"
        Me.Btn_Editartipo.Size = New System.Drawing.Size(85, 23)
        Me.Btn_Editartipo.TabIndex = 11
        Me.Btn_Editartipo.Text = "Editar"
        Me.Btn_Editartipo.UseVisualStyleBackColor = True
        '
        'Btn_EditarSubtipo
        '
        Me.Btn_EditarSubtipo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn_EditarSubtipo.Location = New System.Drawing.Point(539, 67)
        Me.Btn_EditarSubtipo.Name = "Btn_EditarSubtipo"
        Me.Btn_EditarSubtipo.Size = New System.Drawing.Size(85, 23)
        Me.Btn_EditarSubtipo.TabIndex = 12
        Me.Btn_EditarSubtipo.Text = "Editar"
        Me.Btn_EditarSubtipo.UseVisualStyleBackColor = True
        '
        'Dgv_Caracteristicas
        '
        Me.Dgv_Caracteristicas.AllowUserToAddRows = False
        Me.Dgv_Caracteristicas.AllowUserToDeleteRows = False
        Me.Dgv_Caracteristicas.AllowUserToOrderColumns = True
        Me.Dgv_Caracteristicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Caracteristicas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.ID, Me.IRREPETIBLE})
        Me.Dgv_Caracteristicas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Caracteristicas.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Caracteristicas.MultiSelect = False
        Me.Dgv_Caracteristicas.Name = "Dgv_Caracteristicas"
        Me.Dgv_Caracteristicas.ReadOnly = True
        Me.Dgv_Caracteristicas.Size = New System.Drawing.Size(720, 385)
        Me.Dgv_Caracteristicas.TabIndex = 13
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "NOMBRECARACTERISTICA"
        Me.Column1.HeaderText = "Nombre Caracterisitca"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 200
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "DESCRIPCIONCARACTERISTICA"
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.DataPropertyName = "TIPO"
        Me.Column3.FillWeight = 120.0!
        Me.Column3.HeaderText = "Tipo de Dato"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.Width = 87
        '
        'ID
        '
        Me.ID.DataPropertyName = "IDCARACTERISTICASLISTA"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'IRREPETIBLE
        '
        Me.IRREPETIBLE.DataPropertyName = "IRREPETIBLE"
        Me.IRREPETIBLE.HeaderText = "Unico Tipo/Subtipo"
        Me.IRREPETIBLE.Name = "IRREPETIBLE"
        Me.IRREPETIBLE.ReadOnly = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(244, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Caracteristicas del articulo (Editar con Doble Click)"
        '
        'Btn_AgregarCaracteristica
        '
        Me.Btn_AgregarCaracteristica.ForeColor = System.Drawing.Color.DarkGreen
        Me.Btn_AgregarCaracteristica.Location = New System.Drawing.Point(583, 123)
        Me.Btn_AgregarCaracteristica.Name = "Btn_AgregarCaracteristica"
        Me.Btn_AgregarCaracteristica.Size = New System.Drawing.Size(132, 23)
        Me.Btn_AgregarCaracteristica.TabIndex = 15
        Me.Btn_AgregarCaracteristica.Text = "Agregar Caracteristica"
        Me.Btn_AgregarCaracteristica.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Maroon
        Me.Btn_Salir.Location = New System.Drawing.Point(0, 534)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(720, 27)
        Me.Btn_Salir.TabIndex = 18
        Me.Btn_Salir.Text = "Salir"
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Dgv_Caracteristicas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 149)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(720, 385)
        Me.Panel1.TabIndex = 19
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Bt_OrdenarSubTipos)
        Me.Panel2.Controls.Add(Me.Bt_OrdenarTipo)
        Me.Panel2.Controls.Add(Me.Tb_NomSubtipo)
        Me.Panel2.Controls.Add(Me.Tb_NomTipo)
        Me.Panel2.Controls.Add(Me.Lbl_Subtipo)
        Me.Panel2.Controls.Add(Me.Lbl_Tipo)
        Me.Panel2.Controls.Add(Me.Btn_AgregarCaracteristica)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Cb_Tipo)
        Me.Panel2.Controls.Add(Me.Cb_Subtipo)
        Me.Panel2.Controls.Add(Me.Btn_Agregartipo)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Btn_EliminarTipo)
        Me.Panel2.Controls.Add(Me.Btn_EditarSubtipo)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Btn_Editartipo)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Btn_EliminarSubtipo)
        Me.Panel2.Controls.Add(Me.Btn_AgregarSubtipo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(720, 149)
        Me.Panel2.TabIndex = 20
        '
        'Bt_OrdenarSubTipos
        '
        Me.Bt_OrdenarSubTipos.Image = CType(resources.GetObject("Bt_OrdenarSubTipos.Image"), System.Drawing.Image)
        Me.Bt_OrdenarSubTipos.Location = New System.Drawing.Point(400, 67)
        Me.Bt_OrdenarSubTipos.Name = "Bt_OrdenarSubTipos"
        Me.Bt_OrdenarSubTipos.Size = New System.Drawing.Size(30, 22)
        Me.Bt_OrdenarSubTipos.TabIndex = 23
        Me.Bt_OrdenarSubTipos.UseVisualStyleBackColor = True
        '
        'Bt_OrdenarTipo
        '
        Me.Bt_OrdenarTipo.Image = CType(resources.GetObject("Bt_OrdenarTipo.Image"), System.Drawing.Image)
        Me.Bt_OrdenarTipo.Location = New System.Drawing.Point(400, 39)
        Me.Bt_OrdenarTipo.Name = "Bt_OrdenarTipo"
        Me.Bt_OrdenarTipo.Size = New System.Drawing.Size(30, 22)
        Me.Bt_OrdenarTipo.TabIndex = 22
        Me.Bt_OrdenarTipo.UseVisualStyleBackColor = True
        '
        'Tb_NomSubtipo
        '
        Me.Tb_NomSubtipo.Location = New System.Drawing.Point(331, 68)
        Me.Tb_NomSubtipo.MaxLength = 3
        Me.Tb_NomSubtipo.Name = "Tb_NomSubtipo"
        Me.Tb_NomSubtipo.ReadOnly = True
        Me.Tb_NomSubtipo.Size = New System.Drawing.Size(62, 20)
        Me.Tb_NomSubtipo.TabIndex = 21
        '
        'Tb_NomTipo
        '
        Me.Tb_NomTipo.Location = New System.Drawing.Point(331, 40)
        Me.Tb_NomTipo.MaxLength = 3
        Me.Tb_NomTipo.Name = "Tb_NomTipo"
        Me.Tb_NomTipo.ReadOnly = True
        Me.Tb_NomTipo.Size = New System.Drawing.Size(62, 20)
        Me.Tb_NomTipo.TabIndex = 20
        '
        'Lbl_Subtipo
        '
        Me.Lbl_Subtipo.AutoSize = True
        Me.Lbl_Subtipo.Location = New System.Drawing.Point(12, 71)
        Me.Lbl_Subtipo.Name = "Lbl_Subtipo"
        Me.Lbl_Subtipo.Size = New System.Drawing.Size(43, 13)
        Me.Lbl_Subtipo.TabIndex = 19
        Me.Lbl_Subtipo.Text = "Subtipo"
        '
        'Lbl_Tipo
        '
        Me.Lbl_Tipo.AutoSize = True
        Me.Lbl_Tipo.Location = New System.Drawing.Point(27, 43)
        Me.Lbl_Tipo.Name = "Lbl_Tipo"
        Me.Lbl_Tipo.Size = New System.Drawing.Size(28, 13)
        Me.Lbl_Tipo.TabIndex = 18
        Me.Lbl_Tipo.Text = "Tipo"
        '
        'Fr_TiposArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 561)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Btn_Salir)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(736, 600)
        Me.MinimumSize = New System.Drawing.Size(736, 600)
        Me.Name = "Fr_TiposArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Tipos De Articulo"
        CType(Me.Dgv_Caracteristicas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cb_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_Subtipo As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_Agregartipo As System.Windows.Forms.Button
    Friend WithEvents Btn_EliminarTipo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Btn_AgregarSubtipo As System.Windows.Forms.Button
    Friend WithEvents Btn_EliminarSubtipo As System.Windows.Forms.Button
    Friend WithEvents Btn_Editartipo As System.Windows.Forms.Button
    Friend WithEvents Btn_EditarSubtipo As System.Windows.Forms.Button
    Friend WithEvents Dgv_Caracteristicas As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Btn_AgregarCaracteristica As System.Windows.Forms.Button
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Subtipo As System.Windows.Forms.Label
    Friend WithEvents Lbl_Tipo As System.Windows.Forms.Label
    Friend WithEvents Tb_NomSubtipo As System.Windows.Forms.TextBox
    Friend WithEvents Tb_NomTipo As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IRREPETIBLE As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bt_OrdenarSubTipos As System.Windows.Forms.Button
    Friend WithEvents Bt_OrdenarTipo As System.Windows.Forms.Button
End Class
