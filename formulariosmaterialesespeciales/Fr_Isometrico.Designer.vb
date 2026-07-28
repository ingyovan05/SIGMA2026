<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Isometrico
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
        Me.Dgv_ItemIsometrico = New System.Windows.Forms.DataGridView()
        Me.Lb_Isometrico = New System.Windows.Forms.Label()
        Me.Lb_Descripcion = New System.Windows.Forms.Label()
        Me.Lb_Revision = New System.Windows.Forms.Label()
        Me.Tlp_ControlesInferior = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Pn_TituloItems = New System.Windows.Forms.Panel()
        Me.Lb_TituloItems = New System.Windows.Forms.Label()
        Me.Pn_ControlesSuperior = New System.Windows.Forms.Panel()
        Me.Cb_Estado = New System.Windows.Forms.ComboBox()
        Me.Cb_NroHoja = New System.Windows.Forms.ComboBox()
        Me.Lb_NroHoja = New System.Windows.Forms.Label()
        Me.Tx_Ubicacion = New System.Windows.Forms.TextBox()
        Me.Lb_Ubicacion = New System.Windows.Forms.Label()
        Me.Lb_Estado = New System.Windows.Forms.Label()
        Me.Tx_Nombre = New System.Windows.Forms.TextBox()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Cb_Linea = New System.Windows.Forms.ComboBox()
        Me.Lb_Linea = New System.Windows.Forms.Label()
        Me.Cb_Proyecto = New System.Windows.Forms.ComboBox()
        Me.Lb_Proyecto = New System.Windows.Forms.Label()
        Me.Tx_Revision = New System.Windows.Forms.TextBox()
        Me.Tx_Abreviatura = New System.Windows.Forms.TextBox()
        Me.Lb_Abreviatura = New System.Windows.Forms.Label()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Bt_AgregarItemsSpool = New System.Windows.Forms.Button()
        Me.Cb_Isometrico = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.Dgv_ItemIsometrico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tlp_ControlesInferior.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_TituloItems.SuspendLayout()
        Me.Pn_ControlesSuperior.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_ItemIsometrico
        '
        Me.Dgv_ItemIsometrico.AllowUserToResizeRows = False
        Me.Dgv_ItemIsometrico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ItemIsometrico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ItemIsometrico.Location = New System.Drawing.Point(0, 227)
        Me.Dgv_ItemIsometrico.Name = "Dgv_ItemIsometrico"
        Me.Dgv_ItemIsometrico.Size = New System.Drawing.Size(784, 255)
        Me.Dgv_ItemIsometrico.TabIndex = 1
        '
        'Lb_Isometrico
        '
        Me.Lb_Isometrico.AutoSize = True
        Me.Lb_Isometrico.Location = New System.Drawing.Point(19, 42)
        Me.Lb_Isometrico.Name = "Lb_Isometrico"
        Me.Lb_Isometrico.Size = New System.Drawing.Size(58, 13)
        Me.Lb_Isometrico.TabIndex = 4
        Me.Lb_Isometrico.Text = "Isométrico:"
        '
        'Lb_Descripcion
        '
        Me.Lb_Descripcion.AutoSize = True
        Me.Lb_Descripcion.Location = New System.Drawing.Point(11, 95)
        Me.Lb_Descripcion.Name = "Lb_Descripcion"
        Me.Lb_Descripcion.Size = New System.Drawing.Size(66, 13)
        Me.Lb_Descripcion.TabIndex = 15
        Me.Lb_Descripcion.Text = "Descripción:"
        '
        'Lb_Revision
        '
        Me.Lb_Revision.AutoSize = True
        Me.Lb_Revision.Location = New System.Drawing.Point(638, 42)
        Me.Lb_Revision.Name = "Lb_Revision"
        Me.Lb_Revision.Size = New System.Drawing.Size(51, 13)
        Me.Lb_Revision.TabIndex = 9
        Me.Lb_Revision.Text = "Revisión:"
        '
        'Tlp_ControlesInferior
        '
        Me.Tlp_ControlesInferior.BackColor = System.Drawing.Color.Silver
        Me.Tlp_ControlesInferior.ColumnCount = 2
        Me.Tlp_ControlesInferior.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Tlp_ControlesInferior.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.Tlp_ControlesInferior.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_ControlesInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_ControlesInferior.Location = New System.Drawing.Point(0, 530)
        Me.Tlp_ControlesInferior.Name = "Tlp_ControlesInferior"
        Me.Tlp_ControlesInferior.RowCount = 1
        Me.Tlp_ControlesInferior.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_ControlesInferior.Size = New System.Drawing.Size(784, 32)
        Me.Tlp_ControlesInferior.TabIndex = 3
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(156, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(628, 32)
        Me.Flp_Botones.TabIndex = 0
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.AutoSize = True
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.Location = New System.Drawing.Point(550, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(469, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Pn_TituloItems
        '
        Me.Pn_TituloItems.Controls.Add(Me.Lb_TituloItems)
        Me.Pn_TituloItems.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloItems.Location = New System.Drawing.Point(0, 203)
        Me.Pn_TituloItems.Name = "Pn_TituloItems"
        Me.Pn_TituloItems.Size = New System.Drawing.Size(784, 24)
        Me.Pn_TituloItems.TabIndex = 6
        '
        'Lb_TituloItems
        '
        Me.Lb_TituloItems.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Lb_TituloItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_TituloItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TituloItems.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TituloItems.Name = "Lb_TituloItems"
        Me.Lb_TituloItems.Size = New System.Drawing.Size(784, 24)
        Me.Lb_TituloItems.TabIndex = 0
        Me.Lb_TituloItems.Text = "ÍTEMS ISOMÉTRICO"
        Me.Lb_TituloItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pn_ControlesSuperior
        '
        Me.Pn_ControlesSuperior.AutoSize = True
        Me.Pn_ControlesSuperior.Controls.Add(Me.Cb_Estado)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Cb_NroHoja)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Lb_NroHoja)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Tx_Ubicacion)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Lb_Ubicacion)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Lb_Estado)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Tx_Nombre)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Lb_Nombre)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Cb_Linea)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Lb_Linea)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Cb_Proyecto)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Lb_Proyecto)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Tx_Revision)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Lb_Revision)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Tx_Abreviatura)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Lb_Abreviatura)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Tx_Descripcion)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Bt_AgregarItemsSpool)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Cb_Isometrico)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Lb_Isometrico)
        Me.Pn_ControlesSuperior.Controls.Add(Me.Lb_Descripcion)
        Me.Pn_ControlesSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_ControlesSuperior.Location = New System.Drawing.Point(0, 0)
        Me.Pn_ControlesSuperior.Name = "Pn_ControlesSuperior"
        Me.Pn_ControlesSuperior.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.Pn_ControlesSuperior.Size = New System.Drawing.Size(784, 203)
        Me.Pn_ControlesSuperior.TabIndex = 0
        '
        'Cb_Estado
        '
        Me.Cb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Estado.FormattingEnabled = True
        Me.Cb_Estado.Location = New System.Drawing.Point(472, 177)
        Me.Cb_Estado.Name = "Cb_Estado"
        Me.Cb_Estado.Size = New System.Drawing.Size(80, 21)
        Me.Cb_Estado.TabIndex = 20
        '
        'Cb_NroHoja
        '
        Me.Cb_NroHoja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_NroHoja.FormattingEnabled = True
        Me.Cb_NroHoja.Location = New System.Drawing.Point(472, 39)
        Me.Cb_NroHoja.Name = "Cb_NroHoja"
        Me.Cb_NroHoja.Size = New System.Drawing.Size(80, 21)
        Me.Cb_NroHoja.TabIndex = 8
        '
        'Lb_NroHoja
        '
        Me.Lb_NroHoja.AutoSize = True
        Me.Lb_NroHoja.Location = New System.Drawing.Point(414, 42)
        Me.Lb_NroHoja.Name = "Lb_NroHoja"
        Me.Lb_NroHoja.Size = New System.Drawing.Size(55, 13)
        Me.Lb_NroHoja.TabIndex = 7
        Me.Lb_NroHoja.Text = "Nro. Hoja:"
        '
        'Tx_Ubicacion
        '
        Me.Tx_Ubicacion.Location = New System.Drawing.Point(80, 177)
        Me.Tx_Ubicacion.MaxLength = 99
        Me.Tx_Ubicacion.Name = "Tx_Ubicacion"
        Me.Tx_Ubicacion.Size = New System.Drawing.Size(200, 20)
        Me.Tx_Ubicacion.TabIndex = 18
        '
        'Lb_Ubicacion
        '
        Me.Lb_Ubicacion.AutoSize = True
        Me.Lb_Ubicacion.Location = New System.Drawing.Point(19, 180)
        Me.Lb_Ubicacion.Name = "Lb_Ubicacion"
        Me.Lb_Ubicacion.Size = New System.Drawing.Size(58, 13)
        Me.Lb_Ubicacion.TabIndex = 17
        Me.Lb_Ubicacion.Text = "Ubicación:"
        '
        'Lb_Estado
        '
        Me.Lb_Estado.AutoSize = True
        Me.Lb_Estado.Location = New System.Drawing.Point(426, 180)
        Me.Lb_Estado.Name = "Lb_Estado"
        Me.Lb_Estado.Size = New System.Drawing.Size(43, 13)
        Me.Lb_Estado.TabIndex = 19
        Me.Lb_Estado.Text = "Estado:"
        '
        'Tx_Nombre
        '
        Me.Tx_Nombre.Location = New System.Drawing.Point(80, 66)
        Me.Tx_Nombre.MaxLength = 49
        Me.Tx_Nombre.Name = "Tx_Nombre"
        Me.Tx_Nombre.Size = New System.Drawing.Size(300, 20)
        Me.Tx_Nombre.TabIndex = 12
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Location = New System.Drawing.Point(30, 69)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(47, 13)
        Me.Lb_Nombre.TabIndex = 11
        Me.Lb_Nombre.Text = "Nombre:"
        '
        'Cb_Linea
        '
        Me.Cb_Linea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Linea.FormattingEnabled = True
        Me.Cb_Linea.Location = New System.Drawing.Point(472, 12)
        Me.Cb_Linea.Name = "Cb_Linea"
        Me.Cb_Linea.Size = New System.Drawing.Size(300, 21)
        Me.Cb_Linea.TabIndex = 3
        '
        'Lb_Linea
        '
        Me.Lb_Linea.AutoSize = True
        Me.Lb_Linea.Location = New System.Drawing.Point(431, 15)
        Me.Lb_Linea.Name = "Lb_Linea"
        Me.Lb_Linea.Size = New System.Drawing.Size(38, 13)
        Me.Lb_Linea.TabIndex = 2
        Me.Lb_Linea.Text = "Línea:"
        '
        'Cb_Proyecto
        '
        Me.Cb_Proyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Proyecto.FormattingEnabled = True
        Me.Cb_Proyecto.Location = New System.Drawing.Point(80, 12)
        Me.Cb_Proyecto.Name = "Cb_Proyecto"
        Me.Cb_Proyecto.Size = New System.Drawing.Size(300, 21)
        Me.Cb_Proyecto.TabIndex = 1
        '
        'Lb_Proyecto
        '
        Me.Lb_Proyecto.AutoSize = True
        Me.Lb_Proyecto.Location = New System.Drawing.Point(25, 15)
        Me.Lb_Proyecto.Name = "Lb_Proyecto"
        Me.Lb_Proyecto.Size = New System.Drawing.Size(52, 13)
        Me.Lb_Proyecto.TabIndex = 0
        Me.Lb_Proyecto.Text = "Proyecto:"
        '
        'Tx_Revision
        '
        Me.Tx_Revision.Location = New System.Drawing.Point(692, 39)
        Me.Tx_Revision.Name = "Tx_Revision"
        Me.Tx_Revision.Size = New System.Drawing.Size(80, 20)
        Me.Tx_Revision.TabIndex = 10
        '
        'Tx_Abreviatura
        '
        Me.Tx_Abreviatura.Location = New System.Drawing.Point(472, 66)
        Me.Tx_Abreviatura.MaxLength = 9
        Me.Tx_Abreviatura.Name = "Tx_Abreviatura"
        Me.Tx_Abreviatura.Size = New System.Drawing.Size(80, 20)
        Me.Tx_Abreviatura.TabIndex = 14
        '
        'Lb_Abreviatura
        '
        Me.Lb_Abreviatura.AutoSize = True
        Me.Lb_Abreviatura.Location = New System.Drawing.Point(405, 69)
        Me.Lb_Abreviatura.Name = "Lb_Abreviatura"
        Me.Lb_Abreviatura.Size = New System.Drawing.Size(64, 13)
        Me.Lb_Abreviatura.TabIndex = 13
        Me.Lb_Abreviatura.Text = "Abreviatura:"
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Location = New System.Drawing.Point(80, 92)
        Me.Tx_Descripcion.MaxLength = 199
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(692, 79)
        Me.Tx_Descripcion.TabIndex = 16
        '
        'Bt_AgregarItemsSpool
        '
        Me.Bt_AgregarItemsSpool.Location = New System.Drawing.Point(357, 37)
        Me.Bt_AgregarItemsSpool.Name = "Bt_AgregarItemsSpool"
        Me.Bt_AgregarItemsSpool.Size = New System.Drawing.Size(23, 23)
        Me.Bt_AgregarItemsSpool.TabIndex = 6
        Me.Bt_AgregarItemsSpool.Text = "+"
        Me.Bt_AgregarItemsSpool.UseVisualStyleBackColor = True
        '
        'Cb_Isometrico
        '
        Me.Cb_Isometrico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Isometrico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Isometrico.FormattingEnabled = True
        Me.Cb_Isometrico.Location = New System.Drawing.Point(80, 39)
        Me.Cb_Isometrico.Name = "Cb_Isometrico"
        Me.Cb_Isometrico.Size = New System.Drawing.Size(271, 21)
        Me.Cb_Isometrico.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 482)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 48)
        Me.Panel1.TabIndex = 2
        '
        'Fr_Isometrico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Bt_Cancelar
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.Dgv_ItemIsometrico)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pn_TituloItems)
        Me.Controls.Add(Me.Tlp_ControlesInferior)
        Me.Controls.Add(Me.Pn_ControlesSuperior)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_Isometrico"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Isométrico"
        CType(Me.Dgv_ItemIsometrico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tlp_ControlesInferior.ResumeLayout(False)
        Me.Flp_Botones.ResumeLayout(False)
        Me.Flp_Botones.PerformLayout()
        Me.Pn_TituloItems.ResumeLayout(False)
        Me.Pn_ControlesSuperior.ResumeLayout(False)
        Me.Pn_ControlesSuperior.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dgv_ItemIsometrico As System.Windows.Forms.DataGridView
    Friend WithEvents Lb_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Lb_Isometrico As System.Windows.Forms.Label
    Friend WithEvents Lb_Revision As System.Windows.Forms.Label
    Friend WithEvents Tlp_ControlesInferior As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Pn_TituloItems As System.Windows.Forms.Panel
    Friend WithEvents Lb_TituloItems As System.Windows.Forms.Label
    Friend WithEvents Pn_ControlesSuperior As System.Windows.Forms.Panel
    Friend WithEvents Cb_Isometrico As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarItemsSpool As System.Windows.Forms.Button
    Friend WithEvents Tx_Revision As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Abreviatura As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Abreviatura As System.Windows.Forms.Label
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Cb_Linea As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Linea As System.Windows.Forms.Label
    Friend WithEvents Cb_Proyecto As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Proyecto As System.Windows.Forms.Label
    Friend WithEvents Tx_Ubicacion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Ubicacion As System.Windows.Forms.Label
    Friend WithEvents Lb_Estado As System.Windows.Forms.Label
    Friend WithEvents Tx_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Cb_NroHoja As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_NroHoja As System.Windows.Forms.Label
    Friend WithEvents Cb_Estado As System.Windows.Forms.ComboBox
End Class
