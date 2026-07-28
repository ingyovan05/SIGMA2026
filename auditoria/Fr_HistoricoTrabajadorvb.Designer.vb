<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_HistoricoTrabajadorvb
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cb_Año = New System.Windows.Forms.ComboBox()
        Me.Bt_CargarHistorico = New System.Windows.Forms.Button()
        Me.Tb_Identificacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dgv_Historico = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Btn_ExportarHistorico = New System.Windows.Forms.Button()
        Me.DgvTx_IDPERSONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_AbreviaturaTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_Consecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_FechaDesde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_FechaHasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_Identificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_ValorViatico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_NombreTipoSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_ValorSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_TipoConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_NombreConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_ValorConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvTx_CantidadDias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Dgv_Historico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lb_Nombre)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Cb_Año)
        Me.GroupBox1.Controls.Add(Me.Bt_CargarHistorico)
        Me.GroupBox1.Controls.Add(Me.Tb_Identificacion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1205, 60)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.Location = New System.Drawing.Point(750, 23)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(67, 16)
        Me.Lb_Nombre.TabIndex = 8
        Me.Lb_Nombre.Text = "Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(532, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Año"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(277, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Identificación"
        '
        'Cb_Año
        '
        Me.Cb_Año.FormattingEnabled = True
        Me.Cb_Año.Location = New System.Drawing.Point(564, 21)
        Me.Cb_Año.Name = "Cb_Año"
        Me.Cb_Año.Size = New System.Drawing.Size(92, 21)
        Me.Cb_Año.TabIndex = 1
        '
        'Bt_CargarHistorico
        '
        Me.Bt_CargarHistorico.Location = New System.Drawing.Point(662, 20)
        Me.Bt_CargarHistorico.Name = "Bt_CargarHistorico"
        Me.Bt_CargarHistorico.Size = New System.Drawing.Size(75, 23)
        Me.Bt_CargarHistorico.TabIndex = 2
        Me.Bt_CargarHistorico.Text = "Cargar"
        Me.Bt_CargarHistorico.UseVisualStyleBackColor = True
        '
        'Tb_Identificacion
        '
        Me.Tb_Identificacion.Location = New System.Drawing.Point(353, 21)
        Me.Tb_Identificacion.Name = "Tb_Identificacion"
        Me.Tb_Identificacion.Size = New System.Drawing.Size(173, 20)
        Me.Tb_Identificacion.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(258, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Historico del trabajador"
        '
        'Dgv_Historico
        '
        Me.Dgv_Historico.AllowUserToAddRows = False
        Me.Dgv_Historico.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Dgv_Historico.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Historico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Historico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DgvTx_IDPERSONA, Me.DgvTx_AbreviaturaTipoComprobante, Me.DgvTx_NumeroComprobante, Me.DgvTx_Consecutivo, Me.DgvTx_FechaDesde, Me.DgvTx_FechaHasta, Me.DgvTx_Identificacion, Me.DgvTx_Nombre, Me.DgvTx_ValorViatico, Me.DgvTx_Estado, Me.DgvTx_NombreTipoSaldo, Me.DgvTx_ValorSaldo, Me.DgvTx_TipoConcepto, Me.DgvTx_NombreConcepto, Me.DgvTx_ValorConcepto, Me.DgvTx_CantidadDias})
        Me.Dgv_Historico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Historico.Location = New System.Drawing.Point(0, 60)
        Me.Dgv_Historico.Name = "Dgv_Historico"
        Me.Dgv_Historico.Size = New System.Drawing.Size(1205, 408)
        Me.Dgv_Historico.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.Controls.Add(Me.Bt_Cerrar)
        Me.Panel1.Controls.Add(Me.Btn_ExportarHistorico)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 468)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1205, 41)
        Me.Panel1.TabIndex = 2
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(1123, 10)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 1
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Btn_ExportarHistorico
        '
        Me.Btn_ExportarHistorico.Location = New System.Drawing.Point(1036, 10)
        Me.Btn_ExportarHistorico.Name = "Btn_ExportarHistorico"
        Me.Btn_ExportarHistorico.Size = New System.Drawing.Size(75, 23)
        Me.Btn_ExportarHistorico.TabIndex = 0
        Me.Btn_ExportarHistorico.Text = "Exportar Excel"
        Me.Btn_ExportarHistorico.UseVisualStyleBackColor = True
        '
        'DgvTx_IDPERSONA
        '
        Me.DgvTx_IDPERSONA.DataPropertyName = "IDPERSONA"
        Me.DgvTx_IDPERSONA.HeaderText = "Id. Persona"
        Me.DgvTx_IDPERSONA.Name = "DgvTx_IDPERSONA"
        Me.DgvTx_IDPERSONA.ReadOnly = True
        Me.DgvTx_IDPERSONA.ToolTipText = "Id. Persona"
        Me.DgvTx_IDPERSONA.Visible = False
        Me.DgvTx_IDPERSONA.Width = 86
        '
        'DgvTx_AbreviaturaTipoComprobante
        '
        Me.DgvTx_AbreviaturaTipoComprobante.DataPropertyName = "ABREVIATURATIPOCOMPROBANTE"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgvTx_AbreviaturaTipoComprobante.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvTx_AbreviaturaTipoComprobante.HeaderText = "Comprob."
        Me.DgvTx_AbreviaturaTipoComprobante.Name = "DgvTx_AbreviaturaTipoComprobante"
        Me.DgvTx_AbreviaturaTipoComprobante.ReadOnly = True
        Me.DgvTx_AbreviaturaTipoComprobante.ToolTipText = "Comprobante"
        Me.DgvTx_AbreviaturaTipoComprobante.Width = 77
        '
        'DgvTx_NumeroComprobante
        '
        Me.DgvTx_NumeroComprobante.DataPropertyName = "NUMEROCOMPROBANTE"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DgvTx_NumeroComprobante.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvTx_NumeroComprobante.HeaderText = "Nro. comprob."
        Me.DgvTx_NumeroComprobante.Name = "DgvTx_NumeroComprobante"
        Me.DgvTx_NumeroComprobante.ReadOnly = True
        Me.DgvTx_NumeroComprobante.ToolTipText = "Número de comprobante"
        Me.DgvTx_NumeroComprobante.Width = 99
        '
        'DgvTx_Consecutivo
        '
        Me.DgvTx_Consecutivo.DataPropertyName = "CONSECUTIVO"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DgvTx_Consecutivo.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgvTx_Consecutivo.HeaderText = "Consec."
        Me.DgvTx_Consecutivo.Name = "DgvTx_Consecutivo"
        Me.DgvTx_Consecutivo.ReadOnly = True
        Me.DgvTx_Consecutivo.ToolTipText = "Consecutivo"
        Me.DgvTx_Consecutivo.Width = 71
        '
        'DgvTx_FechaDesde
        '
        Me.DgvTx_FechaDesde.DataPropertyName = "FECHADESDE"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgvTx_FechaDesde.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgvTx_FechaDesde.HeaderText = "Fecha desde"
        Me.DgvTx_FechaDesde.Name = "DgvTx_FechaDesde"
        Me.DgvTx_FechaDesde.ReadOnly = True
        Me.DgvTx_FechaDesde.ToolTipText = "Fecha desde"
        Me.DgvTx_FechaDesde.Width = 94
        '
        'DgvTx_FechaHasta
        '
        Me.DgvTx_FechaHasta.DataPropertyName = "FECHAHASTA"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgvTx_FechaHasta.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgvTx_FechaHasta.HeaderText = "Fecha hasta"
        Me.DgvTx_FechaHasta.Name = "DgvTx_FechaHasta"
        Me.DgvTx_FechaHasta.ReadOnly = True
        Me.DgvTx_FechaHasta.ToolTipText = "Fecha hasta"
        Me.DgvTx_FechaHasta.Width = 91
        '
        'DgvTx_Identificacion
        '
        Me.DgvTx_Identificacion.DataPropertyName = "IDENTIFICACION"
        Me.DgvTx_Identificacion.HeaderText = "Identificación"
        Me.DgvTx_Identificacion.Name = "DgvTx_Identificacion"
        Me.DgvTx_Identificacion.ReadOnly = True
        Me.DgvTx_Identificacion.ToolTipText = "Identificación"
        Me.DgvTx_Identificacion.Visible = False
        Me.DgvTx_Identificacion.Width = 95
        '
        'DgvTx_Nombre
        '
        Me.DgvTx_Nombre.DataPropertyName = "NOMBRE"
        Me.DgvTx_Nombre.HeaderText = "Nombre"
        Me.DgvTx_Nombre.Name = "DgvTx_Nombre"
        Me.DgvTx_Nombre.ReadOnly = True
        Me.DgvTx_Nombre.ToolTipText = "Nombre"
        Me.DgvTx_Nombre.Visible = False
        Me.DgvTx_Nombre.Width = 69
        '
        'DgvTx_ValorViatico
        '
        Me.DgvTx_ValorViatico.DataPropertyName = "VALORVIATICO"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DgvTx_ValorViatico.DefaultCellStyle = DataGridViewCellStyle7
        Me.DgvTx_ValorViatico.HeaderText = "Valor"
        Me.DgvTx_ValorViatico.Name = "DgvTx_ValorViatico"
        Me.DgvTx_ValorViatico.ReadOnly = True
        Me.DgvTx_ValorViatico.ToolTipText = "Valor"
        Me.DgvTx_ValorViatico.Width = 56
        '
        'DgvTx_Estado
        '
        Me.DgvTx_Estado.DataPropertyName = "ESTADO"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgvTx_Estado.DefaultCellStyle = DataGridViewCellStyle8
        Me.DgvTx_Estado.HeaderText = "Estado"
        Me.DgvTx_Estado.Name = "DgvTx_Estado"
        Me.DgvTx_Estado.ReadOnly = True
        Me.DgvTx_Estado.ToolTipText = "Estado"
        Me.DgvTx_Estado.Width = 65
        '
        'DgvTx_NombreTipoSaldo
        '
        Me.DgvTx_NombreTipoSaldo.DataPropertyName = "NOMBRETIPOSALDO"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgvTx_NombreTipoSaldo.DefaultCellStyle = DataGridViewCellStyle9
        Me.DgvTx_NombreTipoSaldo.HeaderText = "Saldo"
        Me.DgvTx_NombreTipoSaldo.Name = "DgvTx_NombreTipoSaldo"
        Me.DgvTx_NombreTipoSaldo.ReadOnly = True
        Me.DgvTx_NombreTipoSaldo.ToolTipText = "Saldo"
        Me.DgvTx_NombreTipoSaldo.Width = 59
        '
        'DgvTx_ValorSaldo
        '
        Me.DgvTx_ValorSaldo.DataPropertyName = "VALORSALDO"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "C0"
        Me.DgvTx_ValorSaldo.DefaultCellStyle = DataGridViewCellStyle10
        Me.DgvTx_ValorSaldo.HeaderText = "Valor saldo"
        Me.DgvTx_ValorSaldo.Name = "DgvTx_ValorSaldo"
        Me.DgvTx_ValorSaldo.ReadOnly = True
        Me.DgvTx_ValorSaldo.ToolTipText = "Valor saldo"
        Me.DgvTx_ValorSaldo.Width = 84
        '
        'DgvTx_TipoConcepto
        '
        Me.DgvTx_TipoConcepto.DataPropertyName = "TIPOCONCEPTO"
        Me.DgvTx_TipoConcepto.HeaderText = "Tipo concep."
        Me.DgvTx_TipoConcepto.Name = "DgvTx_TipoConcepto"
        Me.DgvTx_TipoConcepto.ReadOnly = True
        Me.DgvTx_TipoConcepto.ToolTipText = "Tipo concepto"
        Me.DgvTx_TipoConcepto.Width = 95
        '
        'DgvTx_NombreConcepto
        '
        Me.DgvTx_NombreConcepto.DataPropertyName = "NOMBRECONCEPTO"
        Me.DgvTx_NombreConcepto.HeaderText = "Concepto"
        Me.DgvTx_NombreConcepto.Name = "DgvTx_NombreConcepto"
        Me.DgvTx_NombreConcepto.ReadOnly = True
        Me.DgvTx_NombreConcepto.ToolTipText = "Concepto"
        Me.DgvTx_NombreConcepto.Width = 78
        '
        'DgvTx_ValorConcepto
        '
        Me.DgvTx_ValorConcepto.DataPropertyName = "VALORCONCEPTO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C0"
        Me.DgvTx_ValorConcepto.DefaultCellStyle = DataGridViewCellStyle11
        Me.DgvTx_ValorConcepto.HeaderText = "Valor concep."
        Me.DgvTx_ValorConcepto.Name = "DgvTx_ValorConcepto"
        Me.DgvTx_ValorConcepto.ReadOnly = True
        Me.DgvTx_ValorConcepto.ToolTipText = "Valor concepto"
        Me.DgvTx_ValorConcepto.Width = 98
        '
        'DgvTx_CantidadDias
        '
        Me.DgvTx_CantidadDias.DataPropertyName = "CANTIDADDIAS"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DgvTx_CantidadDias.DefaultCellStyle = DataGridViewCellStyle12
        Me.DgvTx_CantidadDias.HeaderText = "Cant. días"
        Me.DgvTx_CantidadDias.Name = "DgvTx_CantidadDias"
        Me.DgvTx_CantidadDias.ReadOnly = True
        Me.DgvTx_CantidadDias.ToolTipText = "Cantidad días"
        Me.DgvTx_CantidadDias.Width = 81
        '
        'Fr_HistoricoTrabajadorvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1205, 509)
        Me.Controls.Add(Me.Dgv_Historico)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Fr_HistoricoTrabajadorvb"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Histórico del Trabajador"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Dgv_Historico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Bt_CargarHistorico As System.Windows.Forms.Button
    Friend WithEvents Tb_Identificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dgv_Historico As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btn_ExportarHistorico As System.Windows.Forms.Button
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Cb_Año As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents DgvTx_IDPERSONA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_AbreviaturaTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_Consecutivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_FechaDesde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_FechaHasta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_Identificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_ValorViatico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_NombreTipoSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_ValorSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_TipoConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_NombreConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_ValorConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvTx_CantidadDias As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
