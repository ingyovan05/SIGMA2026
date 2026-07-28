<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_BuscarPersona
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarPersona = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cb_Filtrar = New System.Windows.Forms.CheckBox()
        Me.Tb_Descripción = New System.Windows.Forms.TextBox()
        Me.ComboBox_Filtrar = New System.Windows.Forms.ComboBox()
        Me.Dgv_Buscar = New System.Windows.Forms.DataGridView()
        Me.DGVTBC_IDPERSONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_IDENTIFICACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_NOMBRECOMPLETO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_IDCONTRATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_CODIGOCONTRATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(588, 2)
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel2.Controls.Add(Me.Bt_AgregarPersona)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 286)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(737, 33)
        Me.Panel2.TabIndex = 1
        '
        'Bt_AgregarPersona
        '
        Me.Bt_AgregarPersona.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Bt_AgregarPersona.Location = New System.Drawing.Point(12, 5)
        Me.Bt_AgregarPersona.Name = "Bt_AgregarPersona"
        Me.Bt_AgregarPersona.Size = New System.Drawing.Size(105, 23)
        Me.Bt_AgregarPersona.TabIndex = 1
        Me.Bt_AgregarPersona.Tag = "39"
        Me.Bt_AgregarPersona.Text = "Agregar Persona"
        Me.Bt_AgregarPersona.UseVisualStyleBackColor = True
        Me.Bt_AgregarPersona.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(737, 60)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cb_Filtrar)
        Me.GroupBox1.Controls.Add(Me.Tb_Descripción)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Filtrar)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(728, 46)
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
        Me.Tb_Descripción.Size = New System.Drawing.Size(467, 20)
        Me.Tb_Descripción.TabIndex = 0
        '
        'ComboBox_Filtrar
        '
        Me.ComboBox_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Filtrar.FormattingEnabled = True
        Me.ComboBox_Filtrar.Items.AddRange(New Object() {"Nombre Completo", "Identificación", "Código Contrato"})
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
        Me.Dgv_Buscar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Buscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Buscar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBC_IDPERSONA, Me.DGVTBC_IDENTIFICACION, Me.DGVTBC_NOMBRECOMPLETO, Me.DGVTBC_IDCONTRATO, Me.DGVTBC_CODIGOCONTRATO})
        Me.Dgv_Buscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Buscar.Location = New System.Drawing.Point(0, 60)
        Me.Dgv_Buscar.Name = "Dgv_Buscar"
        Me.Dgv_Buscar.Size = New System.Drawing.Size(737, 226)
        Me.Dgv_Buscar.TabIndex = 3
        '
        'DGVTBC_IDPERSONA
        '
        Me.DGVTBC_IDPERSONA.DataPropertyName = "IDPERSONA"
        Me.DGVTBC_IDPERSONA.Frozen = True
        Me.DGVTBC_IDPERSONA.HeaderText = "Id Persona"
        Me.DGVTBC_IDPERSONA.Name = "DGVTBC_IDPERSONA"
        Me.DGVTBC_IDPERSONA.ReadOnly = True
        '
        'DGVTBC_IDENTIFICACION
        '
        Me.DGVTBC_IDENTIFICACION.DataPropertyName = "IDENTIFICACION"
        Me.DGVTBC_IDENTIFICACION.Frozen = True
        Me.DGVTBC_IDENTIFICACION.HeaderText = "Identificación"
        Me.DGVTBC_IDENTIFICACION.Name = "DGVTBC_IDENTIFICACION"
        Me.DGVTBC_IDENTIFICACION.ReadOnly = True
        '
        'DGVTBC_NOMBRECOMPLETO
        '
        Me.DGVTBC_NOMBRECOMPLETO.DataPropertyName = "NOMBRECOMPLETO"
        Me.DGVTBC_NOMBRECOMPLETO.Frozen = True
        Me.DGVTBC_NOMBRECOMPLETO.HeaderText = "Nombre Completo"
        Me.DGVTBC_NOMBRECOMPLETO.Name = "DGVTBC_NOMBRECOMPLETO"
        Me.DGVTBC_NOMBRECOMPLETO.ReadOnly = True
        '
        'DGVTBC_IDCONTRATO
        '
        Me.DGVTBC_IDCONTRATO.DataPropertyName = "IDCONTRATO"
        Me.DGVTBC_IDCONTRATO.Frozen = True
        Me.DGVTBC_IDCONTRATO.HeaderText = "IdContrato"
        Me.DGVTBC_IDCONTRATO.Name = "DGVTBC_IDCONTRATO"
        Me.DGVTBC_IDCONTRATO.ReadOnly = True
        Me.DGVTBC_IDCONTRATO.Visible = False
        '
        'DGVTBC_CODIGOCONTRATO
        '
        Me.DGVTBC_CODIGOCONTRATO.DataPropertyName = "CODIGOCONTRATO"
        Me.DGVTBC_CODIGOCONTRATO.Frozen = True
        Me.DGVTBC_CODIGOCONTRATO.HeaderText = "Cód Contrato"
        Me.DGVTBC_CODIGOCONTRATO.Name = "DGVTBC_CODIGOCONTRATO"
        Me.DGVTBC_CODIGOCONTRATO.ReadOnly = True
        '
        'Fr_BuscarPersona
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(737, 319)
        Me.Controls.Add(Me.Dgv_Buscar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_BuscarPersona"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Persona"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PRIMERNOMBREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SEGUNDONOMBREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents PRIMERAPELLIDODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SEGUNDOAPELLIDODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents IDCIUDADORIGENDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELEFONO1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TELEFONOMOVILDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACTIVODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents FECHAULTIMAACTUALIZACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents IDFOTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents CODIGOPROFESIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents FECHAGRADUACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ULTIMAENTIDADEDUCATIVADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents IDUSUARIOREGISTRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents FECHAREGISTRODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents CODIGOTIPOIDENTIFICACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents IDCIUDADHABITADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROFESIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TIPOIDENTIFICACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ENTIDADEDUCATIVADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents CODIGOESTADOCIVILDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ESTADOCIVILDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIUDADHABITADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox_Filtrar As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_Filtrar As System.Windows.Forms.CheckBox
    Friend WithEvents Tb_Descripción As System.Windows.Forms.TextBox
    Friend WithEvents Dgv_Buscar As System.Windows.Forms.DataGridView
    Friend WithEvents CODIGOCONTRATODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADOCONTRATODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bt_AgregarPersona As System.Windows.Forms.Button
    Friend WithEvents DGVTBC_IDPERSONA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_IDENTIFICACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_NOMBRECOMPLETO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_IDCONTRATO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_CODIGOCONTRATO As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
