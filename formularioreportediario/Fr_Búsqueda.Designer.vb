<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Búsqueda
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Gb_Filtro = New System.Windows.Forms.GroupBox()
        Me.Cb_Filtrar = New System.Windows.Forms.CheckBox()
        Me.Tb_Descripción = New System.Windows.Forms.TextBox()
        Me.ComboBox_Filtrar = New System.Windows.Forms.ComboBox()
        Me.Pn_BotonesInferiores = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Dgv_Buscar = New System.Windows.Forms.DataGridView()
        Me.Pn_superior = New System.Windows.Forms.Panel()
        Me.Cb_Unidad = New System.Windows.Forms.ComboBox()
        Me.Lb_Unidad = New System.Windows.Forms.Label()
        Me.Lb_Letrero = New System.Windows.Forms.Label()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Tx_Total = New System.Windows.Forms.TextBox()
        Me.Lb_Total = New System.Windows.Forms.Label()
        Me.Tx_Cantidad = New System.Windows.Forms.TextBox()
        Me.Tx_ValorUnitario = New System.Windows.Forms.TextBox()
        Me.AOT = New FormulariosClasesBase.Cu_Asociar()
        Me.Lb_Orden = New System.Windows.Forms.Label()
        Me.Lb_Cantidad = New System.Windows.Forms.Label()
        Me.Lb_ValorUnitario = New System.Windows.Forms.Label()
        Me.Lb_Costo = New System.Windows.Forms.Label()
        Me.Tx_CostoDirecto = New System.Windows.Forms.TextBox()
        Me.Ll_AgregarCostoDirecto = New System.Windows.Forms.LinkLabel()
        Me.Gb_Filtro.SuspendLayout()
        Me.Pn_BotonesInferiores.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_superior.SuspendLayout()
        Me.SuspendLayout()
        '
        'Gb_Filtro
        '
        Me.Gb_Filtro.Controls.Add(Me.Cb_Filtrar)
        Me.Gb_Filtro.Controls.Add(Me.Tb_Descripción)
        Me.Gb_Filtro.Controls.Add(Me.ComboBox_Filtrar)
        Me.Gb_Filtro.Location = New System.Drawing.Point(3, 3)
        Me.Gb_Filtro.Name = "Gb_Filtro"
        Me.Gb_Filtro.Size = New System.Drawing.Size(746, 46)
        Me.Gb_Filtro.TabIndex = 0
        Me.Gb_Filtro.TabStop = False
        Me.Gb_Filtro.Text = "Filtro"
        '
        'Cb_Filtrar
        '
        Me.Cb_Filtrar.AutoSize = True
        Me.Cb_Filtrar.Checked = True
        Me.Cb_Filtrar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_Filtrar.Location = New System.Drawing.Point(13, 19)
        Me.Cb_Filtrar.Name = "Cb_Filtrar"
        Me.Cb_Filtrar.Size = New System.Drawing.Size(15, 14)
        Me.Cb_Filtrar.TabIndex = 1
        Me.Cb_Filtrar.UseVisualStyleBackColor = True
        '
        'Tb_Descripción
        '
        Me.Tb_Descripción.Location = New System.Drawing.Point(255, 17)
        Me.Tb_Descripción.Name = "Tb_Descripción"
        Me.Tb_Descripción.Size = New System.Drawing.Size(485, 20)
        Me.Tb_Descripción.TabIndex = 1
        '
        'ComboBox_Filtrar
        '
        Me.ComboBox_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Filtrar.FormattingEnabled = True
        Me.ComboBox_Filtrar.Location = New System.Drawing.Point(34, 16)
        Me.ComboBox_Filtrar.Name = "ComboBox_Filtrar"
        Me.ComboBox_Filtrar.Size = New System.Drawing.Size(210, 21)
        Me.ComboBox_Filtrar.TabIndex = 0
        '
        'Pn_BotonesInferiores
        '
        Me.Pn_BotonesInferiores.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Pn_BotonesInferiores.Controls.Add(Me.TableLayoutPanel1)
        Me.Pn_BotonesInferiores.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_BotonesInferiores.Location = New System.Drawing.Point(0, 288)
        Me.Pn_BotonesInferiores.Name = "Pn_BotonesInferiores"
        Me.Pn_BotonesInferiores.Size = New System.Drawing.Size(758, 33)
        Me.Pn_BotonesInferiores.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(609, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Dgv_Buscar
        '
        Me.Dgv_Buscar.AllowUserToAddRows = False
        Me.Dgv_Buscar.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Buscar.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Buscar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Buscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Buscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Buscar.Location = New System.Drawing.Point(0, 76)
        Me.Dgv_Buscar.MultiSelect = False
        Me.Dgv_Buscar.Name = "Dgv_Buscar"
        Me.Dgv_Buscar.ReadOnly = True
        Me.Dgv_Buscar.Size = New System.Drawing.Size(758, 212)
        Me.Dgv_Buscar.TabIndex = 1
        '
        'Pn_superior
        '
        Me.Pn_superior.Controls.Add(Me.Cb_Unidad)
        Me.Pn_superior.Controls.Add(Me.Lb_Unidad)
        Me.Pn_superior.Controls.Add(Me.Lb_Letrero)
        Me.Pn_superior.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_superior.Controls.Add(Me.Bt_Guardar)
        Me.Pn_superior.Controls.Add(Me.Tx_Total)
        Me.Pn_superior.Controls.Add(Me.Lb_Total)
        Me.Pn_superior.Controls.Add(Me.Tx_Cantidad)
        Me.Pn_superior.Controls.Add(Me.Tx_ValorUnitario)
        Me.Pn_superior.Controls.Add(Me.AOT)
        Me.Pn_superior.Controls.Add(Me.Lb_Orden)
        Me.Pn_superior.Controls.Add(Me.Lb_Cantidad)
        Me.Pn_superior.Controls.Add(Me.Lb_ValorUnitario)
        Me.Pn_superior.Controls.Add(Me.Lb_Costo)
        Me.Pn_superior.Controls.Add(Me.Tx_CostoDirecto)
        Me.Pn_superior.Controls.Add(Me.Ll_AgregarCostoDirecto)
        Me.Pn_superior.Controls.Add(Me.Gb_Filtro)
        Me.Pn_superior.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_superior.Location = New System.Drawing.Point(0, 0)
        Me.Pn_superior.Name = "Pn_superior"
        Me.Pn_superior.Size = New System.Drawing.Size(758, 76)
        Me.Pn_superior.TabIndex = 0
        '
        'Cb_Unidad
        '
        Me.Cb_Unidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Unidad.FormattingEnabled = True
        Me.Cb_Unidad.Location = New System.Drawing.Point(95, 132)
        Me.Cb_Unidad.Name = "Cb_Unidad"
        Me.Cb_Unidad.Size = New System.Drawing.Size(152, 21)
        Me.Cb_Unidad.TabIndex = 43
        '
        'Lb_Unidad
        '
        Me.Lb_Unidad.AutoSize = True
        Me.Lb_Unidad.Location = New System.Drawing.Point(50, 134)
        Me.Lb_Unidad.Name = "Lb_Unidad"
        Me.Lb_Unidad.Size = New System.Drawing.Size(44, 13)
        Me.Lb_Unidad.TabIndex = 42
        Me.Lb_Unidad.Text = "Unidad:"
        Me.Lb_Unidad.Visible = False
        '
        'Lb_Letrero
        '
        Me.Lb_Letrero.AutoSize = True
        Me.Lb_Letrero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Letrero.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Letrero.Location = New System.Drawing.Point(229, 52)
        Me.Lb_Letrero.Name = "Lb_Letrero"
        Me.Lb_Letrero.Size = New System.Drawing.Size(264, 15)
        Me.Lb_Letrero.TabIndex = 41
        Me.Lb_Letrero.Text = "AGREGAR SERVICIO NO PROGRAMADO"
        Me.Lb_Letrero.Visible = False
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(682, 134)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(67, 23)
        Me.Bt_Cancelar.TabIndex = 8
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(610, 134)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(67, 23)
        Me.Bt_Guardar.TabIndex = 7
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.Visible = False
        '
        'Tx_Total
        '
        Me.Tx_Total.Enabled = False
        Me.Tx_Total.Location = New System.Drawing.Point(331, 108)
        Me.Tx_Total.MaxLength = 100
        Me.Tx_Total.Name = "Tx_Total"
        Me.Tx_Total.Size = New System.Drawing.Size(84, 20)
        Me.Tx_Total.TabIndex = 5
        Me.Tx_Total.Visible = False
        '
        'Lb_Total
        '
        Me.Lb_Total.AutoSize = True
        Me.Lb_Total.Location = New System.Drawing.Point(294, 111)
        Me.Lb_Total.Name = "Lb_Total"
        Me.Lb_Total.Size = New System.Drawing.Size(34, 13)
        Me.Lb_Total.TabIndex = 37
        Me.Lb_Total.Text = "Total:"
        Me.Lb_Total.Visible = False
        '
        'Tx_Cantidad
        '
        Me.Tx_Cantidad.Location = New System.Drawing.Point(244, 108)
        Me.Tx_Cantidad.MaxLength = 3
        Me.Tx_Cantidad.Name = "Tx_Cantidad"
        Me.Tx_Cantidad.Size = New System.Drawing.Size(42, 20)
        Me.Tx_Cantidad.TabIndex = 4
        Me.Tx_Cantidad.Visible = False
        '
        'Tx_ValorUnitario
        '
        Me.Tx_ValorUnitario.Location = New System.Drawing.Point(95, 108)
        Me.Tx_ValorUnitario.MaxLength = 10
        Me.Tx_ValorUnitario.Name = "Tx_ValorUnitario"
        Me.Tx_ValorUnitario.Size = New System.Drawing.Size(88, 20)
        Me.Tx_ValorUnitario.TabIndex = 3
        Me.Tx_ValorUnitario.Visible = False
        '
        'AOT
        '
        Me.AOT.Location = New System.Drawing.Point(534, 111)
        Me.AOT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.AOT.Name = "AOT"
        Me.AOT.Size = New System.Drawing.Size(219, 20)
        Me.AOT.TabIndex = 6
        Me.AOT.Tipo = "OT"
        Me.AOT.Visible = False
        '
        'Lb_Orden
        '
        Me.Lb_Orden.AutoSize = True
        Me.Lb_Orden.Location = New System.Drawing.Point(421, 111)
        Me.Lb_Orden.Name = "Lb_Orden"
        Me.Lb_Orden.Size = New System.Drawing.Size(111, 13)
        Me.Lb_Orden.TabIndex = 33
        Me.Lb_Orden.Text = "Orden Mantenimiento:"
        Me.Lb_Orden.Visible = False
        '
        'Lb_Cantidad
        '
        Me.Lb_Cantidad.AutoSize = True
        Me.Lb_Cantidad.Location = New System.Drawing.Point(189, 111)
        Me.Lb_Cantidad.Name = "Lb_Cantidad"
        Me.Lb_Cantidad.Size = New System.Drawing.Size(52, 13)
        Me.Lb_Cantidad.TabIndex = 18
        Me.Lb_Cantidad.Text = "Cantidad:"
        Me.Lb_Cantidad.Visible = False
        '
        'Lb_ValorUnitario
        '
        Me.Lb_ValorUnitario.AutoSize = True
        Me.Lb_ValorUnitario.Location = New System.Drawing.Point(19, 111)
        Me.Lb_ValorUnitario.Name = "Lb_ValorUnitario"
        Me.Lb_ValorUnitario.Size = New System.Drawing.Size(73, 13)
        Me.Lb_ValorUnitario.TabIndex = 17
        Me.Lb_ValorUnitario.Text = "Valor Unitario:"
        Me.Lb_ValorUnitario.Visible = False
        '
        'Lb_Costo
        '
        Me.Lb_Costo.AutoSize = True
        Me.Lb_Costo.Location = New System.Drawing.Point(18, 85)
        Me.Lb_Costo.Name = "Lb_Costo"
        Me.Lb_Costo.Size = New System.Drawing.Size(74, 13)
        Me.Lb_Costo.TabIndex = 16
        Me.Lb_Costo.Text = "Costo Directo:"
        Me.Lb_Costo.Visible = False
        '
        'Tx_CostoDirecto
        '
        Me.Tx_CostoDirecto.Location = New System.Drawing.Point(95, 82)
        Me.Tx_CostoDirecto.MaxLength = 100
        Me.Tx_CostoDirecto.Name = "Tx_CostoDirecto"
        Me.Tx_CostoDirecto.Size = New System.Drawing.Size(654, 20)
        Me.Tx_CostoDirecto.TabIndex = 2
        Me.Tx_CostoDirecto.Visible = False
        '
        'Ll_AgregarCostoDirecto
        '
        Me.Ll_AgregarCostoDirecto.AutoSize = True
        Me.Ll_AgregarCostoDirecto.Location = New System.Drawing.Point(12, 55)
        Me.Ll_AgregarCostoDirecto.Name = "Ll_AgregarCostoDirecto"
        Me.Ll_AgregarCostoDirecto.Size = New System.Drawing.Size(282, 13)
        Me.Ll_AgregarCostoDirecto.TabIndex = 1
        Me.Ll_AgregarCostoDirecto.TabStop = True
        Me.Ll_AgregarCostoDirecto.Text = "Agregar Costo Directo - Orden de Servicio No Programado"
        '
        'Fr_Búsqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 321)
        Me.Controls.Add(Me.Dgv_Buscar)
        Me.Controls.Add(Me.Pn_BotonesInferiores)
        Me.Controls.Add(Me.Pn_superior)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(774, 366)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(774, 201)
        Me.Name = "Fr_Búsqueda"
        Me.Text = "Búsqueda"
        Me.Gb_Filtro.ResumeLayout(False)
        Me.Gb_Filtro.PerformLayout()
        Me.Pn_BotonesInferiores.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_superior.ResumeLayout(False)
        Me.Pn_superior.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Gb_Filtro As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_Filtrar As System.Windows.Forms.CheckBox
    Friend WithEvents Tb_Descripción As System.Windows.Forms.TextBox
    Friend WithEvents Pn_BotonesInferiores As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Dgv_Buscar As System.Windows.Forms.DataGridView
    Public WithEvents ComboBox_Filtrar As System.Windows.Forms.ComboBox
    Friend WithEvents Pn_superior As System.Windows.Forms.Panel
    Friend WithEvents Ll_AgregarCostoDirecto As System.Windows.Forms.LinkLabel
    Friend WithEvents Lb_Cantidad As System.Windows.Forms.Label
    Friend WithEvents Lb_ValorUnitario As System.Windows.Forms.Label
    Friend WithEvents Lb_Costo As System.Windows.Forms.Label
    Friend WithEvents Tx_CostoDirecto As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Total As System.Windows.Forms.Label
    Friend WithEvents Tx_Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Tx_ValorUnitario As System.Windows.Forms.TextBox
    Friend WithEvents AOT As FormulariosClasesBase.Cu_Asociar
    Friend WithEvents Lb_Orden As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Tx_Total As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Letrero As System.Windows.Forms.Label
    Public WithEvents Cb_Unidad As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Unidad As System.Windows.Forms.Label
End Class
