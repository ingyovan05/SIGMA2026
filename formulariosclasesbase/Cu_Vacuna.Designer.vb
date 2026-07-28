<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Vacuna
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Dgv_VacunasPersona = New System.Windows.Forms.DataGridView()
        Me.DGVVP_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVVP_FechaVacuna = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVVP_MODULOCREACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVVP_PERSONAREGISTRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVVP_FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Agregar = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Dgv_VacunasPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 30)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Dgv_VacunasPersona)
        Me.SplitContainer2.Panel2Collapsed = True
        Me.SplitContainer2.Panel2MinSize = 0
        Me.SplitContainer2.Size = New System.Drawing.Size(1149, 238)
        Me.SplitContainer2.SplitterDistance = 209
        Me.SplitContainer2.TabIndex = 75
        '
        'Dgv_VacunasPersona
        '
        Me.Dgv_VacunasPersona.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_VacunasPersona.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_VacunasPersona.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_VacunasPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_VacunasPersona.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVVP_NOMBRE, Me.DGVVP_FechaVacuna, Me.DGVVP_MODULOCREACION, Me.DGVVP_PERSONAREGISTRA, Me.DGVVP_FechaRegistro})
        Me.Dgv_VacunasPersona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_VacunasPersona.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_VacunasPersona.MultiSelect = False
        Me.Dgv_VacunasPersona.Name = "Dgv_VacunasPersona"
        Me.Dgv_VacunasPersona.ReadOnly = True
        Me.Dgv_VacunasPersona.Size = New System.Drawing.Size(1149, 238)
        Me.Dgv_VacunasPersona.TabIndex = 4
        '
        'DGVVP_NOMBRE
        '
        Me.DGVVP_NOMBRE.DataPropertyName = "NOMBREVACUNA"
        Me.DGVVP_NOMBRE.HeaderText = "NOMBRE"
        Me.DGVVP_NOMBRE.Name = "DGVVP_NOMBRE"
        Me.DGVVP_NOMBRE.ReadOnly = True
        Me.DGVVP_NOMBRE.Width = 76
        '
        'DGVVP_FechaVacuna
        '
        Me.DGVVP_FechaVacuna.DataPropertyName = "FECHAVACUNA"
        Me.DGVVP_FechaVacuna.HeaderText = "Fecha Vacuna"
        Me.DGVVP_FechaVacuna.Name = "DGVVP_FechaVacuna"
        Me.DGVVP_FechaVacuna.ReadOnly = True
        Me.DGVVP_FechaVacuna.Width = 76
        '
        'DGVVP_MODULOCREACION
        '
        Me.DGVVP_MODULOCREACION.DataPropertyName = "MODULOCREACION"
        Me.DGVVP_MODULOCREACION.HeaderText = "Mod. Creación"
        Me.DGVVP_MODULOCREACION.Name = "DGVVP_MODULOCREACION"
        Me.DGVVP_MODULOCREACION.ReadOnly = True
        Me.DGVVP_MODULOCREACION.Width = 76
        '
        'DGVVP_PERSONAREGISTRA
        '
        Me.DGVVP_PERSONAREGISTRA.DataPropertyName = "NOMPERSONAREGISTRO"
        Me.DGVVP_PERSONAREGISTRA.HeaderText = "Persona Registró"
        Me.DGVVP_PERSONAREGISTRA.Name = "DGVVP_PERSONAREGISTRA"
        Me.DGVVP_PERSONAREGISTRA.ReadOnly = True
        Me.DGVVP_PERSONAREGISTRA.Width = 76
        '
        'DGVVP_FechaRegistro
        '
        Me.DGVVP_FechaRegistro.DataPropertyName = "FECHAREGISTRO"
        DataGridViewCellStyle3.Format = "g"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DGVVP_FechaRegistro.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGVVP_FechaRegistro.HeaderText = "Fecha Registro"
        Me.DGVVP_FechaRegistro.Name = "DGVVP_FechaRegistro"
        Me.DGVVP_FechaRegistro.ReadOnly = True
        Me.DGVVP_FechaRegistro.Width = 80
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Bt_Agregar)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1149, 30)
        Me.Panel1.TabIndex = 76
        '
        'Bt_Agregar
        '
        Me.Bt_Agregar.Location = New System.Drawing.Point(156, 3)
        Me.Bt_Agregar.Name = "Bt_Agregar"
        Me.Bt_Agregar.Size = New System.Drawing.Size(60, 24)
        Me.Bt_Agregar.TabIndex = 76
        Me.Bt_Agregar.Text = "Agregar"
        Me.Bt_Agregar.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(5, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(145, 20)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Información Vacunación"
        '
        'Cu_Vacuna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Cu_Vacuna"
        Me.Size = New System.Drawing.Size(1149, 268)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Dgv_VacunasPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Bt_Agregar As System.Windows.Forms.Button
    Friend WithEvents Dgv_VacunasPersona As System.Windows.Forms.DataGridView
    Friend WithEvents DGVVP_NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVVP_FechaVacuna As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVVP_MODULOCREACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVVP_PERSONAREGISTRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVVP_FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
