<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_CrearReportesDiario
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Dgv_CuadrillasCrearReporte = New System.Windows.Forms.DataGridView()
        Me.CREARDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IDFRENTETRABAJODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOFRENTETRABAJODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREFRENTETRABAJODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERSONACARGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRETIPODISCIPLINADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOTIPODISCIPLINADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPROYECTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LISTAFRENTECREARREPORTEBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Gb_opciones = New System.Windows.Forms.GroupBox()
        Me.Cb_DobleCara = New System.Windows.Forms.CheckBox()
        Me.Cb_VistaPrevia = New System.Windows.Forms.CheckBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Ck_IncluirFrentesSinIntegrates = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Mc_FechaReporte = New System.Windows.Forms.MonthCalendar()
        Me.LISTAFRENTECREARREPORTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LISTAFRENTECREARREPORTEBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_CuadrillasCrearReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LISTAFRENTECREARREPORTEBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Gb_opciones.SuspendLayout()
        CType(Me.LISTAFRENTECREARREPORTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LISTAFRENTECREARREPORTEBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Dgv_CuadrillasCrearReporte)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(568, 352)
        Me.Panel1.TabIndex = 0
        '
        'Dgv_CuadrillasCrearReporte
        '
        Me.Dgv_CuadrillasCrearReporte.AllowUserToAddRows = False
        Me.Dgv_CuadrillasCrearReporte.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_CuadrillasCrearReporte.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_CuadrillasCrearReporte.AutoGenerateColumns = False
        Me.Dgv_CuadrillasCrearReporte.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_CuadrillasCrearReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_CuadrillasCrearReporte.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CREARDataGridViewCheckBoxColumn, Me.IDFRENTETRABAJODataGridViewTextBoxColumn, Me.CODIGOFRENTETRABAJODataGridViewTextBoxColumn, Me.NOMBREFRENTETRABAJODataGridViewTextBoxColumn, Me.PERSONACARGODataGridViewTextBoxColumn, Me.NOMBRETIPODISCIPLINADataGridViewTextBoxColumn, Me.CODIGOTIPODISCIPLINADataGridViewTextBoxColumn, Me.IDPROYECTODataGridViewTextBoxColumn})
        Me.Dgv_CuadrillasCrearReporte.DataSource = Me.LISTAFRENTECREARREPORTEBindingSource2
        Me.Dgv_CuadrillasCrearReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_CuadrillasCrearReporte.Location = New System.Drawing.Point(0, 16)
        Me.Dgv_CuadrillasCrearReporte.MultiSelect = False
        Me.Dgv_CuadrillasCrearReporte.Name = "Dgv_CuadrillasCrearReporte"
        Me.Dgv_CuadrillasCrearReporte.Size = New System.Drawing.Size(568, 336)
        Me.Dgv_CuadrillasCrearReporte.TabIndex = 0
        '
        'CREARDataGridViewCheckBoxColumn
        '
        Me.CREARDataGridViewCheckBoxColumn.DataPropertyName = "CREAR"
        Me.CREARDataGridViewCheckBoxColumn.FalseValue = "N"
        Me.CREARDataGridViewCheckBoxColumn.HeaderText = "Crear"
        Me.CREARDataGridViewCheckBoxColumn.Name = "CREARDataGridViewCheckBoxColumn"
        Me.CREARDataGridViewCheckBoxColumn.ReadOnly = True
        Me.CREARDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CREARDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CREARDataGridViewCheckBoxColumn.TrueValue = "S"
        Me.CREARDataGridViewCheckBoxColumn.Width = 40
        '
        'IDFRENTETRABAJODataGridViewTextBoxColumn
        '
        Me.IDFRENTETRABAJODataGridViewTextBoxColumn.DataPropertyName = "IDFRENTETRABAJO"
        Me.IDFRENTETRABAJODataGridViewTextBoxColumn.HeaderText = "IDFRENTETRABAJO"
        Me.IDFRENTETRABAJODataGridViewTextBoxColumn.Name = "IDFRENTETRABAJODataGridViewTextBoxColumn"
        Me.IDFRENTETRABAJODataGridViewTextBoxColumn.ReadOnly = True
        Me.IDFRENTETRABAJODataGridViewTextBoxColumn.Visible = False
        '
        'CODIGOFRENTETRABAJODataGridViewTextBoxColumn
        '
        Me.CODIGOFRENTETRABAJODataGridViewTextBoxColumn.DataPropertyName = "CODIGOFRENTETRABAJO"
        Me.CODIGOFRENTETRABAJODataGridViewTextBoxColumn.HeaderText = "Código"
        Me.CODIGOFRENTETRABAJODataGridViewTextBoxColumn.Name = "CODIGOFRENTETRABAJODataGridViewTextBoxColumn"
        Me.CODIGOFRENTETRABAJODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODIGOFRENTETRABAJODataGridViewTextBoxColumn.Width = 70
        '
        'NOMBREFRENTETRABAJODataGridViewTextBoxColumn
        '
        Me.NOMBREFRENTETRABAJODataGridViewTextBoxColumn.DataPropertyName = "NOMBREFRENTETRABAJO"
        Me.NOMBREFRENTETRABAJODataGridViewTextBoxColumn.HeaderText = "Nombre"
        Me.NOMBREFRENTETRABAJODataGridViewTextBoxColumn.Name = "NOMBREFRENTETRABAJODataGridViewTextBoxColumn"
        Me.NOMBREFRENTETRABAJODataGridViewTextBoxColumn.ReadOnly = True
        Me.NOMBREFRENTETRABAJODataGridViewTextBoxColumn.Width = 80
        '
        'PERSONACARGODataGridViewTextBoxColumn
        '
        Me.PERSONACARGODataGridViewTextBoxColumn.DataPropertyName = "PERSONACARGO"
        Me.PERSONACARGODataGridViewTextBoxColumn.HeaderText = "Persona a Cargo"
        Me.PERSONACARGODataGridViewTextBoxColumn.Name = "PERSONACARGODataGridViewTextBoxColumn"
        Me.PERSONACARGODataGridViewTextBoxColumn.ReadOnly = True
        Me.PERSONACARGODataGridViewTextBoxColumn.Width = 160
        '
        'NOMBRETIPODISCIPLINADataGridViewTextBoxColumn
        '
        Me.NOMBRETIPODISCIPLINADataGridViewTextBoxColumn.DataPropertyName = "NOMBRETIPODISCIPLINA"
        Me.NOMBRETIPODISCIPLINADataGridViewTextBoxColumn.HeaderText = "Disciplina"
        Me.NOMBRETIPODISCIPLINADataGridViewTextBoxColumn.Name = "NOMBRETIPODISCIPLINADataGridViewTextBoxColumn"
        Me.NOMBRETIPODISCIPLINADataGridViewTextBoxColumn.ReadOnly = True
        Me.NOMBRETIPODISCIPLINADataGridViewTextBoxColumn.Width = 140
        '
        'CODIGOTIPODISCIPLINADataGridViewTextBoxColumn
        '
        Me.CODIGOTIPODISCIPLINADataGridViewTextBoxColumn.DataPropertyName = "CODIGOTIPODISCIPLINA"
        Me.CODIGOTIPODISCIPLINADataGridViewTextBoxColumn.HeaderText = "CODIGOTIPODISCIPLINA"
        Me.CODIGOTIPODISCIPLINADataGridViewTextBoxColumn.Name = "CODIGOTIPODISCIPLINADataGridViewTextBoxColumn"
        Me.CODIGOTIPODISCIPLINADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODIGOTIPODISCIPLINADataGridViewTextBoxColumn.Visible = False
        '
        'IDPROYECTODataGridViewTextBoxColumn
        '
        Me.IDPROYECTODataGridViewTextBoxColumn.DataPropertyName = "IDPROYECTO"
        Me.IDPROYECTODataGridViewTextBoxColumn.HeaderText = "IDPROYECTO"
        Me.IDPROYECTODataGridViewTextBoxColumn.Name = "IDPROYECTODataGridViewTextBoxColumn"
        Me.IDPROYECTODataGridViewTextBoxColumn.ReadOnly = True
        Me.IDPROYECTODataGridViewTextBoxColumn.Visible = False

        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Info
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(568, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Lista de Cuadrillas Activas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Gb_opciones)
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Ck_IncluirFrentesSinIntegrates)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Mc_FechaReporte)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(568, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(240, 352)
        Me.Panel2.TabIndex = 1
        '
        'Gb_opciones
        '
        Me.Gb_opciones.Controls.Add(Me.Cb_DobleCara)
        Me.Gb_opciones.Controls.Add(Me.Cb_VistaPrevia)
        Me.Gb_opciones.Location = New System.Drawing.Point(8, 286)
        Me.Gb_opciones.Name = "Gb_opciones"
        Me.Gb_opciones.Size = New System.Drawing.Size(140, 63)
        Me.Gb_opciones.TabIndex = 7
        Me.Gb_opciones.TabStop = False
        Me.Gb_opciones.Text = "Opciones Impresión"
        '
        'Cb_DobleCara
        '
        Me.Cb_DobleCara.AutoSize = True
        Me.Cb_DobleCara.Location = New System.Drawing.Point(14, 37)
        Me.Cb_DobleCara.Name = "Cb_DobleCara"
        Me.Cb_DobleCara.Size = New System.Drawing.Size(117, 17)
        Me.Cb_DobleCara.TabIndex = 5
        Me.Cb_DobleCara.Text = "Imprimir Doble Cara"
        Me.Cb_DobleCara.UseVisualStyleBackColor = True
        '
        'Cb_VistaPrevia
        '
        Me.Cb_VistaPrevia.AutoSize = True
        Me.Cb_VistaPrevia.Checked = True
        Me.Cb_VistaPrevia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_VistaPrevia.Location = New System.Drawing.Point(14, 18)
        Me.Cb_VistaPrevia.Name = "Cb_VistaPrevia"
        Me.Cb_VistaPrevia.Size = New System.Drawing.Size(99, 17)
        Me.Cb_VistaPrevia.TabIndex = 4
        Me.Cb_VistaPrevia.Text = "Ver vista previa"
        Me.Cb_VistaPrevia.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(125, 239)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(47, 13)
        Me.LinkLabel2.TabIndex = 6
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Ninguno"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(82, 239)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(37, 13)
        Me.LinkLabel1.TabIndex = 5
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Todos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Seleccionar"
        '
        'Ck_IncluirFrentesSinIntegrates
        '
        Me.Ck_IncluirFrentesSinIntegrates.AutoSize = True
        Me.Ck_IncluirFrentesSinIntegrates.Location = New System.Drawing.Point(13, 263)
        Me.Ck_IncluirFrentesSinIntegrates.Name = "Ck_IncluirFrentesSinIntegrates"
        Me.Ck_IncluirFrentesSinIntegrates.Size = New System.Drawing.Size(155, 17)
        Me.Ck_IncluirFrentesSinIntegrates.TabIndex = 3
        Me.Ck_IncluirFrentesSinIntegrates.Text = "Incluir frente sin integrantes"
        Me.Ck_IncluirFrentesSinIntegrates.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(123, 205)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 205)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Crear Reportes"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccionar la Fecha del Reporte"
        '
        'Mc_FechaReporte
        '
        Me.Mc_FechaReporte.Location = New System.Drawing.Point(4, 31)
        Me.Mc_FechaReporte.Name = "Mc_FechaReporte"
        Me.Mc_FechaReporte.TabIndex = 0
        '
        'Fr_CrearReportesDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 352)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_CrearReportesDiario"
        Me.Text = "Crear Reportes Diarios"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Dgv_CuadrillasCrearReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LISTAFRENTECREARREPORTEBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Gb_opciones.ResumeLayout(False)
        Me.Gb_opciones.PerformLayout()
        CType(Me.LISTAFRENTECREARREPORTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LISTAFRENTECREARREPORTEBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_CuadrillasCrearReporte As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Mc_FechaReporte As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LISTAFRENTECREARREPORTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LISTAFRENTECREARREPORTEBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents LISTAFRENTECREARREPORTEBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents CREARDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IDFRENTETRABAJODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOFRENTETRABAJODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREFRENTETRABAJODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERSONACARGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRETIPODISCIPLINADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOTIPODISCIPLINADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPROYECTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ck_IncluirFrentesSinIntegrates As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Gb_opciones As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_DobleCara As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_VistaPrevia As System.Windows.Forms.CheckBox
End Class
