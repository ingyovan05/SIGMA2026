<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_NovedadesPersona
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Eliminar = New System.Windows.Forms.Button()
        Me.Lb_errores_integrantes = New System.Windows.Forms.Label()
        Me.Bt_Imprimir = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Dgv_Novedades = New System.Windows.Forms.DataGridView()
        Me.REPORTENOVEDADBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdReporteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOCONTRATODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CargoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HNDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RNDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Registro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_Novedades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTENOVEDADBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Location = New System.Drawing.Point(0, 396)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(973, 30)
        Me.Panel1.TabIndex = 2
        '
        'Bt_Eliminar
        '
        Me.Bt_Eliminar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Eliminar.Location = New System.Drawing.Point(724, 3)
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
        Me.Bt_Imprimir.Location = New System.Drawing.Point(805, 3)
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
        Me.Bt_Cancelar.Location = New System.Drawing.Point(886, 2)
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
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Novedades.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Novedades.AutoGenerateColumns = False
        Me.Dgv_Novedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Novedades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdReporteDataGridViewTextBoxColumn, Me.FechaDataGridViewTextBoxColumn, Me.CODIGOCONTRATODataGridViewTextBoxColumn, Me.NombreDataGridViewTextBoxColumn, Me.CatDataGridViewTextBoxColumn, Me.CargoDataGridViewTextBoxColumn, Me.Total, Me.HNDataGridViewTextBoxColumn, Me.EDDataGridViewTextBoxColumn, Me.ENDataGridViewTextBoxColumn, Me.RNDataGridViewTextBoxColumn, Me.Registro, Me.Frente})
        Me.Dgv_Novedades.DataSource = Me.REPORTENOVEDADBindingSource
        Me.Dgv_Novedades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Novedades.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Novedades.Name = "Dgv_Novedades"
        Me.Dgv_Novedades.Size = New System.Drawing.Size(973, 396)
        Me.Dgv_Novedades.TabIndex = 3
        '
        'IdReporteDataGridViewTextBoxColumn
        '
        Me.IdReporteDataGridViewTextBoxColumn.DataPropertyName = "IdReporte"
        Me.IdReporteDataGridViewTextBoxColumn.HeaderText = "Nro. Reporte"
        Me.IdReporteDataGridViewTextBoxColumn.Name = "IdReporteDataGridViewTextBoxColumn"
        Me.IdReporteDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdReporteDataGridViewTextBoxColumn.Width = 93
        '
        'FechaDataGridViewTextBoxColumn
        '
        Me.FechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha"
        Me.FechaDataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FechaDataGridViewTextBoxColumn.Name = "FechaDataGridViewTextBoxColumn"
        Me.FechaDataGridViewTextBoxColumn.ReadOnly = True
        Me.FechaDataGridViewTextBoxColumn.Width = 62
        '
        'CODIGOCONTRATODataGridViewTextBoxColumn
        '
        Me.CODIGOCONTRATODataGridViewTextBoxColumn.DataPropertyName = "CODIGOCONTRATO"
        Me.CODIGOCONTRATODataGridViewTextBoxColumn.HeaderText = "Cód. Contrato"
        Me.CODIGOCONTRATODataGridViewTextBoxColumn.Name = "CODIGOCONTRATODataGridViewTextBoxColumn"
        Me.CODIGOCONTRATODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODIGOCONTRATODataGridViewTextBoxColumn.Width = 97
        '
        'NombreDataGridViewTextBoxColumn
        '
        Me.NombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre"
        Me.NombreDataGridViewTextBoxColumn.HeaderText = "Nombre"
        Me.NombreDataGridViewTextBoxColumn.Name = "NombreDataGridViewTextBoxColumn"
        Me.NombreDataGridViewTextBoxColumn.ReadOnly = True
        Me.NombreDataGridViewTextBoxColumn.Width = 69
        '
        'CatDataGridViewTextBoxColumn
        '
        Me.CatDataGridViewTextBoxColumn.DataPropertyName = "Cat"
        Me.CatDataGridViewTextBoxColumn.HeaderText = "Cat"
        Me.CatDataGridViewTextBoxColumn.Name = "CatDataGridViewTextBoxColumn"
        Me.CatDataGridViewTextBoxColumn.ReadOnly = True
        Me.CatDataGridViewTextBoxColumn.Width = 48
        '
        'CargoDataGridViewTextBoxColumn
        '
        Me.CargoDataGridViewTextBoxColumn.DataPropertyName = "Cargo"
        Me.CargoDataGridViewTextBoxColumn.HeaderText = "Cargo"
        Me.CargoDataGridViewTextBoxColumn.Name = "CargoDataGridViewTextBoxColumn"
        Me.CargoDataGridViewTextBoxColumn.ReadOnly = True
        Me.CargoDataGridViewTextBoxColumn.Width = 60
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 56
        '
        'HNDataGridViewTextBoxColumn
        '
        Me.HNDataGridViewTextBoxColumn.DataPropertyName = "HN"
        Me.HNDataGridViewTextBoxColumn.HeaderText = "HN"
        Me.HNDataGridViewTextBoxColumn.Name = "HNDataGridViewTextBoxColumn"
        Me.HNDataGridViewTextBoxColumn.ReadOnly = True
        Me.HNDataGridViewTextBoxColumn.Width = 48
        '
        'EDDataGridViewTextBoxColumn
        '
        Me.EDDataGridViewTextBoxColumn.DataPropertyName = "ED"
        Me.EDDataGridViewTextBoxColumn.HeaderText = "ED"
        Me.EDDataGridViewTextBoxColumn.Name = "EDDataGridViewTextBoxColumn"
        Me.EDDataGridViewTextBoxColumn.ReadOnly = True
        Me.EDDataGridViewTextBoxColumn.Width = 47
        '
        'ENDataGridViewTextBoxColumn
        '
        Me.ENDataGridViewTextBoxColumn.DataPropertyName = "EN"
        Me.ENDataGridViewTextBoxColumn.HeaderText = "EN"
        Me.ENDataGridViewTextBoxColumn.Name = "ENDataGridViewTextBoxColumn"
        Me.ENDataGridViewTextBoxColumn.ReadOnly = True
        Me.ENDataGridViewTextBoxColumn.Width = 47
        '
        'RNDataGridViewTextBoxColumn
        '
        Me.RNDataGridViewTextBoxColumn.DataPropertyName = "RN"
        Me.RNDataGridViewTextBoxColumn.HeaderText = "RN"
        Me.RNDataGridViewTextBoxColumn.Name = "RNDataGridViewTextBoxColumn"
        Me.RNDataGridViewTextBoxColumn.ReadOnly = True
        Me.RNDataGridViewTextBoxColumn.Width = 48
        '
        'Registro
        '
        Me.Registro.DataPropertyName = "Registro"
        Me.Registro.HeaderText = "Registro"
        Me.Registro.Name = "Registro"
        Me.Registro.ReadOnly = True
        Me.Registro.Width = 71
        '
        'Frente
        '
        Me.Frente.DataPropertyName = "Frente"
        Me.Frente.HeaderText = "Frente"
        Me.Frente.Name = "Frente"
        Me.Frente.ReadOnly = True
        '
        'Fr_NovedadesPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 426)
        Me.Controls.Add(Me.Dgv_Novedades)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(989, 464)
        Me.Name = "Fr_NovedadesPersona"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Novedades Persona"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Dgv_Novedades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTENOVEDADBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lb_errores_integrantes As System.Windows.Forms.Label
    Friend WithEvents Bt_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Dgv_Novedades As System.Windows.Forms.DataGridView
    Friend WithEvents NOMBRETIPOCATEGORIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRETIPOCARGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORASEXTRASDIURNASDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDREPORTEDIARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REPORTENOVEDADBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Bt_Eliminar As System.Windows.Forms.Button
    Friend WithEvents IdReporteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOCONTRATODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CargoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HNDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RNDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Registro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frente As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
