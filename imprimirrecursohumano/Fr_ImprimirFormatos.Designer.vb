<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ImprimirFormatos
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
        Me.Dgv_Formatos = New System.Windows.Forms.DataGridView()
        Me.IMPRIMIR = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IDDOCUMENTOIMPRIMIR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Formato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTIVO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOIMPRIMIR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Revision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEPENDENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPLEMENTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORDEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox_Cargo_Desempeña = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Ck_VistaPrevia = New System.Windows.Forms.CheckBox()
        Me.Bt_Desseleccionar = New System.Windows.Forms.Button()
        Me.Bt_Seleccionar = New System.Windows.Forms.Button()
        Me.Bt_Imprimir = New System.Windows.Forms.Button()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        CType(Me.Dgv_Formatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_Formatos
        '
        Me.Dgv_Formatos.AllowUserToAddRows = False
        Me.Dgv_Formatos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Formatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Formatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Formatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Formatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IMPRIMIR, Me.IDDOCUMENTOIMPRIMIR, Me.Nombre, Me.Formato, Me.ACTIVO, Me.TIPOIMPRIMIR, Me.Revision, Me.DEPENDENCIA, Me.IMPLEMENTADO, Me.ORDEN})
        Me.Dgv_Formatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Formatos.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Formatos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dgv_Formatos.Name = "Dgv_Formatos"
        Me.Dgv_Formatos.Size = New System.Drawing.Size(1140, 211)
        Me.Dgv_Formatos.TabIndex = 0
        '
        'IMPRIMIR
        '
        Me.IMPRIMIR.DataPropertyName = "IMPRIMIR"
        Me.IMPRIMIR.FalseValue = "N"
        Me.IMPRIMIR.HeaderText = "Imprimir"
        Me.IMPRIMIR.Name = "IMPRIMIR"
        Me.IMPRIMIR.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IMPRIMIR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IMPRIMIR.TrueValue = "S"
        '
        'IDDOCUMENTOIMPRIMIR
        '
        Me.IDDOCUMENTOIMPRIMIR.DataPropertyName = "IDDOCUMENTOIMPRIMIR"
        Me.IDDOCUMENTOIMPRIMIR.HeaderText = "Id"
        Me.IDDOCUMENTOIMPRIMIR.Name = "IDDOCUMENTOIMPRIMIR"
        Me.IDDOCUMENTOIMPRIMIR.Width = 30
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "NOMBREDOCUMENTO"
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 500
        '
        'Formato
        '
        Me.Formato.DataPropertyName = "NOMBREFORMATO"
        Me.Formato.HeaderText = "Formato"
        Me.Formato.Name = "Formato"
        Me.Formato.ReadOnly = True
        '
        'ACTIVO
        '
        Me.ACTIVO.DataPropertyName = "ACTIVO"
        Me.ACTIVO.HeaderText = "ACTIVO"
        Me.ACTIVO.Name = "ACTIVO"
        Me.ACTIVO.Visible = False
        '
        'TIPOIMPRIMIR
        '
        Me.TIPOIMPRIMIR.DataPropertyName = "TIPOIMPRIMIR"
        Me.TIPOIMPRIMIR.HeaderText = "TIPOIMPRIMIR"
        Me.TIPOIMPRIMIR.Name = "TIPOIMPRIMIR"
        Me.TIPOIMPRIMIR.Visible = False
        '
        'Revision
        '
        Me.Revision.DataPropertyName = "REVISION"
        Me.Revision.HeaderText = "Revisión"
        Me.Revision.Name = "Revision"
        Me.Revision.ReadOnly = True
        Me.Revision.Width = 50
        '
        'DEPENDENCIA
        '
        Me.DEPENDENCIA.DataPropertyName = "DEPENDENCIA"
        Me.DEPENDENCIA.HeaderText = "DEPENDENCIA"
        Me.DEPENDENCIA.Name = "DEPENDENCIA"
        Me.DEPENDENCIA.Visible = False
        '
        'IMPLEMENTADO
        '
        Me.IMPLEMENTADO.DataPropertyName = "IMPLEMENTADO"
        Me.IMPLEMENTADO.HeaderText = "IMPLEMENTADO"
        Me.IMPLEMENTADO.Name = "IMPLEMENTADO"
        Me.IMPLEMENTADO.Visible = False
        '
        'ORDEN
        '
        Me.ORDEN.DataPropertyName = "ORDEN"
        Me.ORDEN.HeaderText = "ORDEN"
        Me.ORDEN.Name = "ORDEN"
        Me.ORDEN.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ComboBox_Cargo_Desempeña)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Ck_VistaPrevia)
        Me.Panel1.Controls.Add(Me.Bt_Desseleccionar)
        Me.Panel1.Controls.Add(Me.Bt_Seleccionar)
        Me.Panel1.Controls.Add(Me.Bt_Imprimir)
        Me.Panel1.Controls.Add(Me.Bt_Cerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 211)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1140, 69)
        Me.Panel1.TabIndex = 1
        '
        'ComboBox_Cargo_Desempeña
        '
        Me.ComboBox_Cargo_Desempeña.FormattingEnabled = True
        Me.ComboBox_Cargo_Desempeña.Location = New System.Drawing.Point(204, 33)
        Me.ComboBox_Cargo_Desempeña.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboBox_Cargo_Desempeña.Name = "ComboBox_Cargo_Desempeña"
        Me.ComboBox_Cargo_Desempeña.Size = New System.Drawing.Size(632, 24)
        Me.ComboBox_Cargo_Desempeña.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Posible Cargo a desempeñar:"
        '
        'Ck_VistaPrevia
        '
        Me.Ck_VistaPrevia.AutoSize = True
        Me.Ck_VistaPrevia.Checked = True
        Me.Ck_VistaPrevia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_VistaPrevia.Location = New System.Drawing.Point(213, 7)
        Me.Ck_VistaPrevia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Ck_VistaPrevia.Name = "Ck_VistaPrevia"
        Me.Ck_VistaPrevia.Size = New System.Drawing.Size(105, 21)
        Me.Ck_VistaPrevia.TabIndex = 4
        Me.Ck_VistaPrevia.Text = "Vista Previa"
        Me.Ck_VistaPrevia.UseVisualStyleBackColor = True
        '
        'Bt_Desseleccionar
        '
        Me.Bt_Desseleccionar.Location = New System.Drawing.Point(109, 4)
        Me.Bt_Desseleccionar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bt_Desseleccionar.Name = "Bt_Desseleccionar"
        Me.Bt_Desseleccionar.Size = New System.Drawing.Size(81, 28)
        Me.Bt_Desseleccionar.TabIndex = 1
        Me.Bt_Desseleccionar.Text = "Ninguno"
        Me.Bt_Desseleccionar.UseVisualStyleBackColor = True
        '
        'Bt_Seleccionar
        '
        Me.Bt_Seleccionar.Location = New System.Drawing.Point(16, 4)
        Me.Bt_Seleccionar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bt_Seleccionar.Name = "Bt_Seleccionar"
        Me.Bt_Seleccionar.Size = New System.Drawing.Size(85, 28)
        Me.Bt_Seleccionar.TabIndex = 0
        Me.Bt_Seleccionar.Text = "Todos"
        Me.Bt_Seleccionar.UseVisualStyleBackColor = True
        '
        'Bt_Imprimir
        '
        Me.Bt_Imprimir.Location = New System.Drawing.Point(859, 31)
        Me.Bt_Imprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bt_Imprimir.Name = "Bt_Imprimir"
        Me.Bt_Imprimir.Size = New System.Drawing.Size(100, 28)
        Me.Bt_Imprimir.TabIndex = 2
        Me.Bt_Imprimir.Text = "Imprimir"
        Me.Bt_Imprimir.UseVisualStyleBackColor = True
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(967, 31)
        Me.Bt_Cerrar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(100, 28)
        Me.Bt_Cerrar.TabIndex = 3
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Fr_ImprimirFormatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 280)
        Me.Controls.Add(Me.Dgv_Formatos)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Fr_ImprimirFormatos"
        Me.Text = "Imprimir Formatos"
        CType(Me.Dgv_Formatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv_Formatos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Bt_Desseleccionar As System.Windows.Forms.Button
    Friend WithEvents Bt_Seleccionar As System.Windows.Forms.Button
    Friend WithEvents Ck_VistaPrevia As System.Windows.Forms.CheckBox
    Public WithEvents ComboBox_Cargo_Desempeña As System.Windows.Forms.ComboBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents IDDOCUMENTOIMPRIMIRDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDOCUMENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREFORMATODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADODOCUMENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOIMPRIMIRDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VERSIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEPENDENCIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPLEMENTADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPRIMIR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IDDOCUMENTOIMPRIMIR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Formato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACTIVO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOIMPRIMIR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Revision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEPENDENCIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPLEMENTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORDEN As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
