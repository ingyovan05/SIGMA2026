<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Maestro
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Actualizar = New System.Windows.Forms.Button()
        Me.Bt_Cargar = New System.Windows.Forms.Button()
        Me.Cb_TablaMaestra = New System.Windows.Forms.ComboBox()
        Me.MATABLAMAESTRABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_Maestros = New Dscomunes.Ds_Maestros()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cu_Fecha1 = New Clasesbase.Cu_Fecha()
        Me.Dgv_Maestra = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.MA_TABLAMAESTRATableAdapter = New Dscomunes.Ds_MaestrosTableAdapters.MA_TABLAMAESTRATableAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.MATABLAMAESTRABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Maestros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_Maestra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Bt_Actualizar)
        Me.Panel1.Controls.Add(Me.Bt_Cargar)
        Me.Panel1.Controls.Add(Me.Cb_TablaMaestra)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Cu_Fecha1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(646, 75)
        Me.Panel1.TabIndex = 0
        '
        'Bt_Actualizar
        '
        Me.Bt_Actualizar.Enabled = False
        Me.Bt_Actualizar.Location = New System.Drawing.Point(359, 44)
        Me.Bt_Actualizar.Name = "Bt_Actualizar"
        Me.Bt_Actualizar.Size = New System.Drawing.Size(120, 23)
        Me.Bt_Actualizar.TabIndex = 7
        Me.Bt_Actualizar.Text = "Guardar Cambios"
        Me.Bt_Actualizar.UseVisualStyleBackColor = True
        '
        'Bt_Cargar
        '
        Me.Bt_Cargar.Location = New System.Drawing.Point(278, 44)
        Me.Bt_Cargar.Name = "Bt_Cargar"
        Me.Bt_Cargar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cargar.TabIndex = 6
        Me.Bt_Cargar.Text = "Cargar"
        Me.Bt_Cargar.UseVisualStyleBackColor = True
        '
        'Cb_TablaMaestra
        '
        Me.Cb_TablaMaestra.DataSource = Me.MATABLAMAESTRABindingSource
        Me.Cb_TablaMaestra.DisplayMember = "DESCRIPCION"
        Me.Cb_TablaMaestra.FormattingEnabled = True
        Me.Cb_TablaMaestra.Location = New System.Drawing.Point(243, 17)
        Me.Cb_TablaMaestra.Name = "Cb_TablaMaestra"
        Me.Cb_TablaMaestra.Size = New System.Drawing.Size(236, 21)
        Me.Cb_TablaMaestra.TabIndex = 4
        Me.Cb_TablaMaestra.ValueMember = "NOMBRETABLAMAESTRA"
        '
        'MATABLAMAESTRABindingSource
        '
        Me.MATABLAMAESTRABindingSource.DataMember = "MA_TABLAMAESTRA"
        Me.MATABLAMAESTRABindingSource.DataSource = Me.Ds_Maestros
        '
        'Ds_Maestros
        '
        Me.Ds_Maestros.DataSetName = "Ds_Maestros"
        Me.Ds_Maestros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tabla Maestra:"
        '
        'Cu_Fecha1
        '
        Me.Cu_Fecha1.BackColor = System.Drawing.Color.Transparent
        Me.Cu_Fecha1.Location = New System.Drawing.Point(3, 3)
        Me.Cu_Fecha1.Name = "Cu_Fecha1"
        Me.Cu_Fecha1.Size = New System.Drawing.Size(160, 65)
        Me.Cu_Fecha1.TabIndex = 0
        '
        'Dgv_Maestra
        '
        Me.Dgv_Maestra.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Maestra.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Maestra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_Maestra.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Maestra.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Maestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize

        Me.Dgv_Maestra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Maestra.Location = New System.Drawing.Point(0, 92)
        Me.Dgv_Maestra.Name = "Dgv_Maestra"
        Me.Dgv_Maestra.Size = New System.Drawing.Size(646, 289)
        Me.Dgv_Maestra.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Info
        Me.Panel2.Controls.Add(Me.Lb_Titulo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(646, 17)
        Me.Panel2.TabIndex = 2
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_Titulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(646, 17)
        Me.Lb_Titulo.TabIndex = 0
        Me.Lb_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MA_TABLAMAESTRATableAdapter
        '
        Me.MA_TABLAMAESTRATableAdapter.ClearBeforeFill = True
        '
        'Cu_Maestro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Controls.Add(Me.Dgv_Maestra)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Cu_Maestro"
        Me.Size = New System.Drawing.Size(646, 381)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.MATABLAMAESTRABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Maestros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_Maestra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cb_TablaMaestra As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cu_Fecha1 As Cu_Fecha
    Friend WithEvents Bt_Cargar As System.Windows.Forms.Button
    Friend WithEvents Dgv_Maestra As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Lb_Titulo As System.Windows.Forms.Label
    Friend WithEvents MATABLAMAESTRABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_Maestros As Dscomunes.Ds_Maestros
    Friend WithEvents MA_TABLAMAESTRATableAdapter As Dscomunes.Ds_MaestrosTableAdapters.MA_TABLAMAESTRATableAdapter
    Friend WithEvents Bt_Actualizar As System.Windows.Forms.Button

End Class
