<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_HistorialArchivos
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
        Me.Dgv_Archivos = New System.Windows.Forms.DataGridView()
        Me.Bt_Todos = New System.Windows.Forms.Button()
        Me.Bt_Ninguno = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.Lb_ArchivosDescargados = New System.Windows.Forms.Label()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Descargar = New System.Windows.Forms.Button()
        Me.Pb_ArchivosDescargados = New System.Windows.Forms.ProgressBar()
        Me.Bgw_ArchivosDescargados = New System.ComponentModel.BackgroundWorker()
        Me.IdArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descargar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.Dgv_Archivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_Archivos
        '
        Me.Dgv_Archivos.AllowUserToAddRows = False
        Me.Dgv_Archivos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Archivos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Archivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Archivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdArchivo, Me.Nombre, Me.FechaCreacion, Me.Descripcion, Me.Descargar})
        Me.Dgv_Archivos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Archivos.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Archivos.Name = "Dgv_Archivos"
        Me.Dgv_Archivos.Size = New System.Drawing.Size(673, 185)
        Me.Dgv_Archivos.TabIndex = 0
        '
        'Bt_Todos
        '
        Me.Bt_Todos.Location = New System.Drawing.Point(3, 4)
        Me.Bt_Todos.Name = "Bt_Todos"
        Me.Bt_Todos.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Todos.TabIndex = 1
        Me.Bt_Todos.Text = "Todos"
        Me.Bt_Todos.UseVisualStyleBackColor = True
        '
        'Bt_Ninguno
        '
        Me.Bt_Ninguno.Location = New System.Drawing.Point(84, 4)
        Me.Bt_Ninguno.Name = "Bt_Ninguno"
        Me.Bt_Ninguno.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Ninguno.TabIndex = 2
        Me.Bt_Ninguno.Text = "Ninguno"
        Me.Bt_Ninguno.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Dgv_Archivos)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(673, 252)
        Me.SplitContainer1.SplitterDistance = 185
        Me.SplitContainer1.TabIndex = 3
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Pb_ArchivosDescargados)
        Me.SplitContainer2.Size = New System.Drawing.Size(673, 63)
        Me.SplitContainer2.SplitterDistance = 29
        Me.SplitContainer2.TabIndex = 6
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Bt_Todos)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Bt_Ninguno)
        Me.SplitContainer3.Panel1MinSize = 165
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer3.Size = New System.Drawing.Size(673, 29)
        Me.SplitContainer3.SplitterDistance = 165
        Me.SplitContainer3.TabIndex = 0
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.IsSplitterFixed = True
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.Lb_ArchivosDescargados)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.Bt_Cancelar)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Bt_Descargar)
        Me.SplitContainer4.Panel2MinSize = 165
        Me.SplitContainer4.Size = New System.Drawing.Size(504, 29)
        Me.SplitContainer4.SplitterDistance = 335
        Me.SplitContainer4.TabIndex = 6
        '
        'Lb_ArchivosDescargados
        '
        Me.Lb_ArchivosDescargados.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Lb_ArchivosDescargados.AutoSize = True
        Me.Lb_ArchivosDescargados.Location = New System.Drawing.Point(111, 9)
        Me.Lb_ArchivosDescargados.Name = "Lb_ArchivosDescargados"
        Me.Lb_ArchivosDescargados.Size = New System.Drawing.Size(121, 13)
        Me.Lb_ArchivosDescargados.TabIndex = 0
        Me.Lb_ArchivosDescargados.Text = "Archivos descargados:  "
        Me.Lb_ArchivosDescargados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Cancelar.Location = New System.Drawing.Point(87, 4)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Descargar
        '
        Me.Bt_Descargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Descargar.Location = New System.Drawing.Point(6, 4)
        Me.Bt_Descargar.Name = "Bt_Descargar"
        Me.Bt_Descargar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Descargar.TabIndex = 5
        Me.Bt_Descargar.Text = "Descargar"
        Me.Bt_Descargar.UseVisualStyleBackColor = True
        '
        'Pb_ArchivosDescargados
        '
        Me.Pb_ArchivosDescargados.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pb_ArchivosDescargados.Location = New System.Drawing.Point(0, 0)
        Me.Pb_ArchivosDescargados.Name = "Pb_ArchivosDescargados"
        Me.Pb_ArchivosDescargados.Size = New System.Drawing.Size(673, 23)
        Me.Pb_ArchivosDescargados.TabIndex = 0
        '
        'Bgw_ArchivosDescargados
        '
        Me.Bgw_ArchivosDescargados.WorkerReportsProgress = True
        Me.Bgw_ArchivosDescargados.WorkerSupportsCancellation = True
        '
        'IdArchivo
        '
        Me.IdArchivo.DataPropertyName = "IdArchivo"
        Me.IdArchivo.HeaderText = "Id Archivo"
        Me.IdArchivo.Name = "IdArchivo"
        Me.IdArchivo.ReadOnly = True
        Me.IdArchivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IdArchivo.Visible = False
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Nombre.Width = 200
        '
        'FechaCreacion
        '
        Me.FechaCreacion.DataPropertyName = "FechaCreacion"
        Me.FechaCreacion.HeaderText = "Fecha de creación"
        Me.FechaCreacion.Name = "FechaCreacion"
        Me.FechaCreacion.ReadOnly = True
        Me.FechaCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaCreacion.Width = 150
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Subido Por"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 200
        '
        'Descargar
        '
        Me.Descargar.DataPropertyName = "Descargar"
        Me.Descargar.HeaderText = "Descargar"
        Me.Descargar.Name = "Descargar"
        Me.Descargar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descargar.Width = 75
        '
        'Fr_HistorialArchivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 252)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(689, 291)
        Me.MinimumSize = New System.Drawing.Size(689, 291)
        Me.Name = "Fr_HistorialArchivos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Historial Archivos"
        CType(Me.Dgv_Archivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv_Archivos As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_Todos As System.Windows.Forms.Button
    Friend WithEvents Bt_Ninguno As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Bt_Descargar As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents Pb_ArchivosDescargados As System.Windows.Forms.ProgressBar
    Friend WithEvents Bgw_ArchivosDescargados As System.ComponentModel.BackgroundWorker
    Friend WithEvents Lb_ArchivosDescargados As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents IdArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descargar As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
