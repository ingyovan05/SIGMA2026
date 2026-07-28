<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_NovedadesEquipos
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Eliminar = New System.Windows.Forms.Button()
        Me.Lb_errores_integrantes = New System.Windows.Forms.Label()
        Me.Bt_Imprimir = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Dgv_Novedades = New System.Windows.Forms.DataGridView()
        Me.REPORTENOVEDADEQUIPOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdReporteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripciónDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InicialDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisponibleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VaradoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FrenteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RegistroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDEQUIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_Novedades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTENOVEDADEQUIPOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Bt_Eliminar)
        Me.Panel1.Controls.Add(Me.Lb_errores_integrantes)
        Me.Panel1.Controls.Add(Me.Bt_Imprimir)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 392)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1029, 30)
        Me.Panel1.TabIndex = 4
        '
        'Bt_Eliminar
        '
        Me.Bt_Eliminar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Eliminar.Location = New System.Drawing.Point(780, 3)
        Me.Bt_Eliminar.Name = "Bt_Eliminar"
        Me.Bt_Eliminar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Eliminar.TabIndex = 3
        Me.Bt_Eliminar.Text = "Eliminar"
        Me.Bt_Eliminar.UseVisualStyleBackColor = True
        '
        'Lb_errores_integrantes
        '
        Me.Lb_errores_integrantes.AutoSize = True
        Me.Lb_errores_integrantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_errores_integrantes.ForeColor = System.Drawing.Color.Black
        Me.Lb_errores_integrantes.Location = New System.Drawing.Point(3, 5)
        Me.Lb_errores_integrantes.Name = "Lb_errores_integrantes"
        Me.Lb_errores_integrantes.Size = New System.Drawing.Size(73, 20)
        Me.Lb_errores_integrantes.TabIndex = 2
        Me.Lb_errores_integrantes.Text = "Label13"
        '
        'Bt_Imprimir
        '
        Me.Bt_Imprimir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Imprimir.Location = New System.Drawing.Point(861, 3)
        Me.Bt_Imprimir.Name = "Bt_Imprimir"
        Me.Bt_Imprimir.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Imprimir.TabIndex = 1
        Me.Bt_Imprimir.Text = "Imprimir"
        Me.Bt_Imprimir.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Cancelar.Location = New System.Drawing.Point(942, 2)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Dgv_Novedades
        '
        Me.Dgv_Novedades.AllowUserToAddRows = False
        Me.Dgv_Novedades.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Novedades.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_Novedades.AutoGenerateColumns = False
        Me.Dgv_Novedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Novedades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdReporteDataGridViewTextBoxColumn, Me.FechaDataGridViewTextBoxColumn, Me.CODIGODataGridViewTextBoxColumn, Me.DescripciónDataGridViewTextBoxColumn, Me.TotalDataGridViewTextBoxColumn, Me.InicialDataGridViewTextBoxColumn, Me.FinalDataGridViewTextBoxColumn, Me.DisponibleDataGridViewTextBoxColumn, Me.VaradoDataGridViewTextBoxColumn, Me.FrenteDataGridViewTextBoxColumn, Me.RegistroDataGridViewTextBoxColumn, Me.IDEQUIPO})
        Me.Dgv_Novedades.DataSource = Me.REPORTENOVEDADEQUIPOBindingSource
        Me.Dgv_Novedades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Novedades.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Novedades.Name = "Dgv_Novedades"
        Me.Dgv_Novedades.Size = New System.Drawing.Size(1029, 422)
        Me.Dgv_Novedades.TabIndex = 5
        '
        'IdReporteDataGridViewTextBoxColumn
        '
        Me.IdReporteDataGridViewTextBoxColumn.DataPropertyName = "IdReporte"
        Me.IdReporteDataGridViewTextBoxColumn.HeaderText = "IdReporte"
        Me.IdReporteDataGridViewTextBoxColumn.Name = "IdReporteDataGridViewTextBoxColumn"
        '
        'FechaDataGridViewTextBoxColumn
        '
        Me.FechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha"
        Me.FechaDataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FechaDataGridViewTextBoxColumn.Name = "FechaDataGridViewTextBoxColumn"
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Código"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        '
        'DescripciónDataGridViewTextBoxColumn
        '
        Me.DescripciónDataGridViewTextBoxColumn.DataPropertyName = "Descripción"
        Me.DescripciónDataGridViewTextBoxColumn.HeaderText = "Descripción"
        Me.DescripciónDataGridViewTextBoxColumn.Name = "DescripciónDataGridViewTextBoxColumn"
        Me.DescripciónDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TotalDataGridViewTextBoxColumn
        '
        Me.TotalDataGridViewTextBoxColumn.DataPropertyName = "Total"
        Me.TotalDataGridViewTextBoxColumn.HeaderText = "Total"
        Me.TotalDataGridViewTextBoxColumn.Name = "TotalDataGridViewTextBoxColumn"
        Me.TotalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InicialDataGridViewTextBoxColumn
        '
        Me.InicialDataGridViewTextBoxColumn.DataPropertyName = "Inicial"
        Me.InicialDataGridViewTextBoxColumn.HeaderText = "Inicial"
        Me.InicialDataGridViewTextBoxColumn.Name = "InicialDataGridViewTextBoxColumn"
        Me.InicialDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FinalDataGridViewTextBoxColumn
        '
        Me.FinalDataGridViewTextBoxColumn.DataPropertyName = "Final"
        Me.FinalDataGridViewTextBoxColumn.HeaderText = "Final"
        Me.FinalDataGridViewTextBoxColumn.Name = "FinalDataGridViewTextBoxColumn"
        Me.FinalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DisponibleDataGridViewTextBoxColumn
        '
        Me.DisponibleDataGridViewTextBoxColumn.DataPropertyName = "Disponible"
        Me.DisponibleDataGridViewTextBoxColumn.HeaderText = "Dis"
        Me.DisponibleDataGridViewTextBoxColumn.Name = "DisponibleDataGridViewTextBoxColumn"
        Me.DisponibleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VaradoDataGridViewTextBoxColumn
        '
        Me.VaradoDataGridViewTextBoxColumn.DataPropertyName = "Varado"
        Me.VaradoDataGridViewTextBoxColumn.HeaderText = "Var"
        Me.VaradoDataGridViewTextBoxColumn.Name = "VaradoDataGridViewTextBoxColumn"
        Me.VaradoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FrenteDataGridViewTextBoxColumn
        '
        Me.FrenteDataGridViewTextBoxColumn.DataPropertyName = "Frente"
        Me.FrenteDataGridViewTextBoxColumn.HeaderText = "Frente"
        Me.FrenteDataGridViewTextBoxColumn.Name = "FrenteDataGridViewTextBoxColumn"
        '
        'RegistroDataGridViewTextBoxColumn
        '
        Me.RegistroDataGridViewTextBoxColumn.DataPropertyName = "Registro"
        Me.RegistroDataGridViewTextBoxColumn.HeaderText = "Registro"
        Me.RegistroDataGridViewTextBoxColumn.Name = "RegistroDataGridViewTextBoxColumn"
        Me.RegistroDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IDEQUIPO
        '
        Me.IDEQUIPO.DataPropertyName = "IDEQUIPO"
        Me.IDEQUIPO.HeaderText = "IDEQUIPO"
        Me.IDEQUIPO.Name = "IDEQUIPO"
        Me.IDEQUIPO.ReadOnly = True
        Me.IDEQUIPO.Visible = False
        '
        'Fr_NovedadesEquipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 422)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Dgv_Novedades)
        Me.Name = "Fr_NovedadesEquipos"
        Me.Text = "Novedades Equipos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Dgv_Novedades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTENOVEDADEQUIPOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Lb_errores_integrantes As System.Windows.Forms.Label
    Friend WithEvents Bt_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Dgv_Novedades As System.Windows.Forms.DataGridView
    Friend WithEvents REPORTENOVEDADEQUIPOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IdReporteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripciónDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InicialDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisponibleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VaradoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FrenteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RegistroDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDEQUIPO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
