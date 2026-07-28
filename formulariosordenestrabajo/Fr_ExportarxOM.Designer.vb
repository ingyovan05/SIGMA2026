<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ExportarxOM
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Dgv_OrdenSap = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Bt_AgregarDesdeReportes = New System.Windows.Forms.Button()
        Me.Bt_AgregarOMPortapapeles = New System.Windows.Forms.Button()
        Me.Pn_bases = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_Mes = New System.Windows.Forms.ComboBox()
        Me.Rb_TodasBases = New System.Windows.Forms.RadioButton()
        Me.cb_Año = New System.Windows.Forms.ComboBox()
        Me.Rb_BaseActual = New System.Windows.Forms.RadioButton()
        Me.Ck_Fechas = New System.Windows.Forms.CheckBox()
        Me.Dtp_FechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dtp_FechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_LimpiarTabla = New System.Windows.Forms.Button()
        Me.Lb_TotalSAP = New System.Windows.Forms.Label()
        Me.Cb_EstadoSAP = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_OrdenSap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Pn_bases.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Dgv_OrdenSap)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 349)
        Me.Panel1.TabIndex = 0
        '
        'Dgv_OrdenSap
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_OrdenSap.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_OrdenSap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_OrdenSap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_OrdenSap.Location = New System.Drawing.Point(0, 27)
        Me.Dgv_OrdenSap.Name = "Dgv_OrdenSap"
        Me.Dgv_OrdenSap.Size = New System.Drawing.Size(184, 322)
        Me.Dgv_OrdenSap.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(184, 27)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Info
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lista Ordenes SAP"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bt_AgregarDesdeReportes
        '
        Me.Bt_AgregarDesdeReportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Bt_AgregarDesdeReportes.Location = New System.Drawing.Point(191, 208)
        Me.Bt_AgregarDesdeReportes.Name = "Bt_AgregarDesdeReportes"
        Me.Bt_AgregarDesdeReportes.Size = New System.Drawing.Size(166, 23)
        Me.Bt_AgregarDesdeReportes.TabIndex = 2
        Me.Bt_AgregarDesdeReportes.Text = "<-- Agregar Desde Reportes"
        Me.Bt_AgregarDesdeReportes.UseVisualStyleBackColor = True
        '
        'Bt_AgregarOMPortapapeles
        '
        Me.Bt_AgregarOMPortapapeles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Bt_AgregarOMPortapapeles.Location = New System.Drawing.Point(191, 179)
        Me.Bt_AgregarOMPortapapeles.Name = "Bt_AgregarOMPortapapeles"
        Me.Bt_AgregarOMPortapapeles.Size = New System.Drawing.Size(167, 23)
        Me.Bt_AgregarOMPortapapeles.TabIndex = 1
        Me.Bt_AgregarOMPortapapeles.Text = "<-- Agregar desde portapapeles"
        Me.Bt_AgregarOMPortapapeles.UseVisualStyleBackColor = True
        '
        'Pn_bases
        '
        Me.Pn_bases.Controls.Add(Me.Label5)
        Me.Pn_bases.Controls.Add(Me.Label4)
        Me.Pn_bases.Controls.Add(Me.cb_Mes)
        Me.Pn_bases.Controls.Add(Me.Rb_TodasBases)
        Me.Pn_bases.Controls.Add(Me.cb_Año)
        Me.Pn_bases.Controls.Add(Me.Rb_BaseActual)
        Me.Pn_bases.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_bases.Location = New System.Drawing.Point(184, 0)
        Me.Pn_bases.Name = "Pn_bases"
        Me.Pn_bases.Size = New System.Drawing.Size(186, 68)
        Me.Pn_bases.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Mes:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Año:"
        '
        'cb_Mes
        '
        Me.cb_Mes.FormattingEnabled = True
        Me.cb_Mes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cb_Mes.Location = New System.Drawing.Point(62, 40)
        Me.cb_Mes.Name = "cb_Mes"
        Me.cb_Mes.Size = New System.Drawing.Size(68, 21)
        Me.cb_Mes.TabIndex = 8
        '
        'Rb_TodasBases
        '
        Me.Rb_TodasBases.AutoSize = True
        Me.Rb_TodasBases.Location = New System.Drawing.Point(34, 36)
        Me.Rb_TodasBases.Name = "Rb_TodasBases"
        Me.Rb_TodasBases.Size = New System.Drawing.Size(113, 17)
        Me.Rb_TodasBases.TabIndex = 1
        Me.Rb_TodasBases.Text = "Todas Bases CMC"
        Me.Rb_TodasBases.UseVisualStyleBackColor = True
        '
        'cb_Año
        '
        Me.cb_Año.FormattingEnabled = True
        Me.cb_Año.Items.AddRange(New Object() {"2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029"})
        Me.cb_Año.Location = New System.Drawing.Point(62, 13)
        Me.cb_Año.Name = "cb_Año"
        Me.cb_Año.Size = New System.Drawing.Size(68, 21)
        Me.cb_Año.TabIndex = 7
        '
        'Rb_BaseActual
        '
        Me.Rb_BaseActual.AutoSize = True
        Me.Rb_BaseActual.Checked = True
        Me.Rb_BaseActual.Location = New System.Drawing.Point(34, 13)
        Me.Rb_BaseActual.Name = "Rb_BaseActual"
        Me.Rb_BaseActual.Size = New System.Drawing.Size(82, 17)
        Me.Rb_BaseActual.TabIndex = 0
        Me.Rb_BaseActual.TabStop = True
        Me.Rb_BaseActual.Text = "Base Actual"
        Me.Rb_BaseActual.UseVisualStyleBackColor = True
        '
        'Ck_Fechas
        '
        Me.Ck_Fechas.AutoSize = True
        Me.Ck_Fechas.Checked = True
        Me.Ck_Fechas.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_Fechas.Location = New System.Drawing.Point(14, 10)
        Me.Ck_Fechas.Name = "Ck_Fechas"
        Me.Ck_Fechas.Size = New System.Drawing.Size(107, 17)
        Me.Ck_Fechas.TabIndex = 2
        Me.Ck_Fechas.Text = "Filtrar por Fechas"
        Me.Ck_Fechas.UseVisualStyleBackColor = True
        '
        'Dtp_FechaInicial
        '
        Me.Dtp_FechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaInicial.Location = New System.Drawing.Point(84, 33)
        Me.Dtp_FechaInicial.Name = "Dtp_FechaInicial"
        Me.Dtp_FechaInicial.Size = New System.Drawing.Size(86, 20)
        Me.Dtp_FechaInicial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Inicial:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha Final:"
        '
        'Dtp_FechaFinal
        '
        Me.Dtp_FechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaFinal.Location = New System.Drawing.Point(84, 64)
        Me.Dtp_FechaFinal.Name = "Dtp_FechaFinal"
        Me.Dtp_FechaFinal.Size = New System.Drawing.Size(86, 20)
        Me.Dtp_FechaFinal.TabIndex = 6
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Cb_EstadoSAP)
        Me.Panel3.Controls.Add(Me.Ck_Fechas)
        Me.Panel3.Controls.Add(Me.Dtp_FechaFinal)
        Me.Panel3.Controls.Add(Me.Dtp_FechaInicial)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(184, 68)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(186, 100)
        Me.Panel3.TabIndex = 7
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(200, 316)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 8
        Me.Bt_Aceptar.Text = "Exportar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(280, 316)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 9
        Me.Bt_Cancelar.Text = "Cerrar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_LimpiarTabla
        '
        Me.Bt_LimpiarTabla.Location = New System.Drawing.Point(192, 237)
        Me.Bt_LimpiarTabla.Name = "Bt_LimpiarTabla"
        Me.Bt_LimpiarTabla.Size = New System.Drawing.Size(166, 23)
        Me.Bt_LimpiarTabla.TabIndex = 10
        Me.Bt_LimpiarTabla.Text = "Limpiar Tabla"
        Me.Bt_LimpiarTabla.UseVisualStyleBackColor = True
        '
        'Lb_TotalSAP
        '
        Me.Lb_TotalSAP.AutoSize = True
        Me.Lb_TotalSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TotalSAP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Lb_TotalSAP.Location = New System.Drawing.Point(212, 275)
        Me.Lb_TotalSAP.Name = "Lb_TotalSAP"
        Me.Lb_TotalSAP.Size = New System.Drawing.Size(91, 13)
        Me.Lb_TotalSAP.TabIndex = 11
        Me.Lb_TotalSAP.Text = "Total Ordenes:"
        '
        'Cb_EstadoSAP
        '
        Me.Cb_EstadoSAP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_EstadoSAP.FormattingEnabled = True
        Me.Cb_EstadoSAP.Location = New System.Drawing.Point(62, 62)
        Me.Cb_EstadoSAP.Name = "Cb_EstadoSAP"
        Me.Cb_EstadoSAP.Size = New System.Drawing.Size(112, 21)
        Me.Cb_EstadoSAP.TabIndex = 18
        '
        'Fr_ExportarxOM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 349)
        Me.Controls.Add(Me.Lb_TotalSAP)
        Me.Controls.Add(Me.Bt_AgregarDesdeReportes)
        Me.Controls.Add(Me.Bt_LimpiarTabla)
        Me.Controls.Add(Me.Bt_AgregarOMPortapapeles)
        Me.Controls.Add(Me.Bt_Cancelar)
        Me.Controls.Add(Me.Bt_Aceptar)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Pn_bases)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(386, 388)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(386, 388)
        Me.Name = "Fr_ExportarxOM"
        Me.Text = "Exportar x OM"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Dgv_OrdenSap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Pn_bases.ResumeLayout(False)
        Me.Pn_bases.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_OrdenSap As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarDesdeReportes As System.Windows.Forms.Button
    Friend WithEvents Bt_AgregarOMPortapapeles As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pn_bases As System.Windows.Forms.Panel
    Friend WithEvents Rb_TodasBases As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_BaseActual As System.Windows.Forms.RadioButton
    Friend WithEvents Ck_Fechas As System.Windows.Forms.CheckBox
    Friend WithEvents Dtp_FechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_LimpiarTabla As System.Windows.Forms.Button
    Friend WithEvents Lb_TotalSAP As System.Windows.Forms.Label
    Friend WithEvents cb_Mes As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Año As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cb_EstadoSAP As System.Windows.Forms.ComboBox
End Class
