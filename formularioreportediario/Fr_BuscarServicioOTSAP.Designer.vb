<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_BuscarServicioOTSAP
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cb_Filtrar = New System.Windows.Forms.CheckBox()
        Me.Tb_Descripción = New System.Windows.Forms.TextBox()
        Me.ComboBox_Filtrar = New System.Windows.Forms.ComboBox()
        Me.Dgv_Buscar = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DGVTBC_IDOTSERVICIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_IDSERVICIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BASE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_IDORDENTRABAJO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_NROORDENSAP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_CODIGOORDENCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_OBJETOOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_CODIGOSERVICIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_NOMBRESERVICIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_CODIGOTIPOUNIDAD = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVTBC_CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_SERVICIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_CODIGOPOBLACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_IDCLASEATENCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1077, 60)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cb_Filtrar)
        Me.GroupBox1.Controls.Add(Me.Tb_Descripción)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Filtrar)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(580, 46)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro"
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
        Me.Tb_Descripción.Size = New System.Drawing.Size(317, 20)
        Me.Tb_Descripción.TabIndex = 0
        '
        'ComboBox_Filtrar
        '
        Me.ComboBox_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Filtrar.FormattingEnabled = True
        Me.ComboBox_Filtrar.Items.AddRange(New Object() {"Orden de Trabajo", "Objeto Orden de Trabajo", "Codigo del servicio", "Nombre Servicio", "Base de la OT", "Código Ismocol"})
        Me.ComboBox_Filtrar.Location = New System.Drawing.Point(34, 16)
        Me.ComboBox_Filtrar.Name = "ComboBox_Filtrar"
        Me.ComboBox_Filtrar.Size = New System.Drawing.Size(210, 21)
        Me.ComboBox_Filtrar.TabIndex = 2
        '
        'Dgv_Buscar
        '
        Me.Dgv_Buscar.AllowUserToAddRows = False
        Me.Dgv_Buscar.AllowUserToDeleteRows = False
        Me.Dgv_Buscar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Buscar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Buscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Buscar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBC_IDOTSERVICIO, Me.DGVTBC_IDSERVICIO, Me.BASE, Me.DGVTBC_IDORDENTRABAJO, Me.DGVTBC_NROORDENSAP, Me.DGVTBC_CODIGOORDENCLIENTE, Me.DGVTBC_OBJETOOT, Me.DGVTBC_CODIGOSERVICIO, Me.DGVTBC_NOMBRESERVICIO, Me.DGVTBC_CODIGOTIPOUNIDAD, Me.DGVTBC_CANTIDAD, Me.DGVTBC_SERVICIO, Me.DGVTBC_CODIGOPOBLACION, Me.DGVTBC_IDCLASEATENCION})
        Me.Dgv_Buscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Buscar.Location = New System.Drawing.Point(0, 60)
        Me.Dgv_Buscar.Name = "Dgv_Buscar"
        Me.Dgv_Buscar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Buscar.Size = New System.Drawing.Size(1077, 325)
        Me.Dgv_Buscar.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 385)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1077, 33)
        Me.Panel2.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(928, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'DGVTBC_IDOTSERVICIO
        '
        Me.DGVTBC_IDOTSERVICIO.DataPropertyName = "IDOTSERVICIO"
        Me.DGVTBC_IDOTSERVICIO.HeaderText = "IDOTSERVICIO"
        Me.DGVTBC_IDOTSERVICIO.Name = "DGVTBC_IDOTSERVICIO"
        Me.DGVTBC_IDOTSERVICIO.Visible = False
        '
        'DGVTBC_IDSERVICIO
        '
        Me.DGVTBC_IDSERVICIO.DataPropertyName = "IDSERVICIO"
        Me.DGVTBC_IDSERVICIO.HeaderText = "IDSERVICIO"
        Me.DGVTBC_IDSERVICIO.Name = "DGVTBC_IDSERVICIO"
        Me.DGVTBC_IDSERVICIO.ReadOnly = True
        Me.DGVTBC_IDSERVICIO.Visible = False
        '
        'BASE
        '
        Me.BASE.DataPropertyName = "NOMBREBASE"
        Me.BASE.HeaderText = "Base Ejecución"
        Me.BASE.Name = "BASE"
        '
        'DGVTBC_IDORDENTRABAJO
        '
        Me.DGVTBC_IDORDENTRABAJO.DataPropertyName = "IDORDENTRABAJO"
        Me.DGVTBC_IDORDENTRABAJO.HeaderText = "IDORDENTRABAJO"
        Me.DGVTBC_IDORDENTRABAJO.Name = "DGVTBC_IDORDENTRABAJO"
        Me.DGVTBC_IDORDENTRABAJO.Visible = False
        '
        'DGVTBC_NROORDENSAP
        '
        Me.DGVTBC_NROORDENSAP.DataPropertyName = "NROORDENSAP"
        Me.DGVTBC_NROORDENSAP.HeaderText = "Orden Trabajo"
        Me.DGVTBC_NROORDENSAP.Name = "DGVTBC_NROORDENSAP"
        '
        'DGVTBC_CODIGOORDENCLIENTE
        '
        Me.DGVTBC_CODIGOORDENCLIENTE.DataPropertyName = "CODIGOORDENCLIENTE"
        Me.DGVTBC_CODIGOORDENCLIENTE.HeaderText = "Cod. Ismocol"
        Me.DGVTBC_CODIGOORDENCLIENTE.Name = "DGVTBC_CODIGOORDENCLIENTE"
        Me.DGVTBC_CODIGOORDENCLIENTE.Visible = False
        '
        'DGVTBC_OBJETOOT
        '
        Me.DGVTBC_OBJETOOT.DataPropertyName = "OBJETO"
        Me.DGVTBC_OBJETOOT.HeaderText = "Objeto OT"
        Me.DGVTBC_OBJETOOT.Name = "DGVTBC_OBJETOOT"
        Me.DGVTBC_OBJETOOT.Width = 240
        '
        'DGVTBC_CODIGOSERVICIO
        '
        Me.DGVTBC_CODIGOSERVICIO.DataPropertyName = "CODIGOSERVICIO"
        Me.DGVTBC_CODIGOSERVICIO.HeaderText = "Cód Servicio"
        Me.DGVTBC_CODIGOSERVICIO.Name = "DGVTBC_CODIGOSERVICIO"
        Me.DGVTBC_CODIGOSERVICIO.ReadOnly = True
        '
        'DGVTBC_NOMBRESERVICIO
        '
        Me.DGVTBC_NOMBRESERVICIO.DataPropertyName = "NOMBRESERVICIO"
        Me.DGVTBC_NOMBRESERVICIO.HeaderText = "Nombre Servicio"
        Me.DGVTBC_NOMBRESERVICIO.Name = "DGVTBC_NOMBRESERVICIO"
        Me.DGVTBC_NOMBRESERVICIO.ReadOnly = True
        Me.DGVTBC_NOMBRESERVICIO.Width = 350
        '
        'DGVTBC_CODIGOTIPOUNIDAD
        '
        Me.DGVTBC_CODIGOTIPOUNIDAD.DataPropertyName = "CODIGOTIPOUNIDAD"
        Me.DGVTBC_CODIGOTIPOUNIDAD.HeaderText = "Und"
        Me.DGVTBC_CODIGOTIPOUNIDAD.Name = "DGVTBC_CODIGOTIPOUNIDAD"
        Me.DGVTBC_CODIGOTIPOUNIDAD.ReadOnly = True
        Me.DGVTBC_CODIGOTIPOUNIDAD.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVTBC_CODIGOTIPOUNIDAD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGVTBC_CODIGOTIPOUNIDAD.Width = 60
        '
        'DGVTBC_CANTIDAD
        '
        Me.DGVTBC_CANTIDAD.DataPropertyName = "CANTIDAD"
        Me.DGVTBC_CANTIDAD.HeaderText = "Cant"
        Me.DGVTBC_CANTIDAD.Name = "DGVTBC_CANTIDAD"
        Me.DGVTBC_CANTIDAD.ReadOnly = True
        Me.DGVTBC_CANTIDAD.Width = 60
        '
        'DGVTBC_SERVICIO
        '
        Me.DGVTBC_SERVICIO.DataPropertyName = "SERVICIO"
        Me.DGVTBC_SERVICIO.HeaderText = "SERVICIO"
        Me.DGVTBC_SERVICIO.Name = "DGVTBC_SERVICIO"
        Me.DGVTBC_SERVICIO.Visible = False
        '
        'DGVTBC_CODIGOPOBLACION
        '
        Me.DGVTBC_CODIGOPOBLACION.DataPropertyName = "CODIGOPOBLACION"
        Me.DGVTBC_CODIGOPOBLACION.HeaderText = "CODIGOPOBLACION"
        Me.DGVTBC_CODIGOPOBLACION.Name = "DGVTBC_CODIGOPOBLACION"
        Me.DGVTBC_CODIGOPOBLACION.Visible = False
        '
        'DGVTBC_IDCLASEATENCION
        '
        Me.DGVTBC_IDCLASEATENCION.DataPropertyName = "IDCLASEATENCION"
        Me.DGVTBC_IDCLASEATENCION.HeaderText = "IDCLASEATENCION"
        Me.DGVTBC_IDCLASEATENCION.Name = "DGVTBC_IDCLASEATENCION"
        Me.DGVTBC_IDCLASEATENCION.Visible = False
        '
        'Fr_BuscarServicioOTSAP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 418)
        Me.Controls.Add(Me.Dgv_Buscar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Fr_BuscarServicioOTSAP"
        Me.Text = "Buscar Servicio OT SAP"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_Filtrar As System.Windows.Forms.CheckBox
    Friend WithEvents Tb_Descripción As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox_Filtrar As System.Windows.Forms.ComboBox
    Friend WithEvents Dgv_Buscar As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DGVTBC_IDOTSERVICIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_IDSERVICIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BASE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_IDORDENTRABAJO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_NROORDENSAP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_OBJETOOT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_CODIGOSERVICIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_NOMBRESERVICIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_CODIGOTIPOUNIDAD As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVTBC_CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_SERVICIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_CODIGOPOBLACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_IDCLASEATENCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents DGVTBC_CODIGOORDENCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
