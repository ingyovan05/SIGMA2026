<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Legalización
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dtp_FechaLegalización = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Cb_Categoría = New System.Windows.Forms.ComboBox()
        Me.MATIPOCATEGORIABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_Auditoria = New DatosAuditoria.Ds_Auditoria()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cb_Cargo = New System.Windows.Forms.ComboBox()
        Me.MATIPOCARGOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cb_Grupo = New System.Windows.Forms.ComboBox()
        Me.MATIPOGRUPOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cb_TipoLegalización = New System.Windows.Forms.ComboBox()
        Me.MATIPOLEGALIZACIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tx_ValorViatico = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Cb_TipoSaldo = New System.Windows.Forms.ComboBox()
        Me.MATIPOSALDOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tx_ValorSaldo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Cb_Estado = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Tx_Descripción = New System.Windows.Forms.TextBox()
        Me.Tx_Observación = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Tb_Dias = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Bt_AgregarConcepto = New System.Windows.Forms.Button()
        Me.Bt_EliminarConcepto = New System.Windows.Forms.Button()
        Me.Tx_ValorConcepto = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Cb_Concepto = New System.Windows.Forms.ComboBox()
        Me.MACONCEPTOADICIONALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Cb_TipoConcepto = New System.Windows.Forms.ComboBox()
        Me.MATIPOCONCEPTOADICIONALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Dgv_Conceptos = New System.Windows.Forms.DataGridView()
        Me.CODIGOCONCEPTOADICIONALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOTIPOCONCEPTOADICIONALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRETIPOCONCEPTOADICIONALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRECONCEPTOADICIONALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONCEPTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Cb_NombreComprobante = New System.Windows.Forms.ComboBox()
        Me.MATIPOCOMPROBANTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Bt_AgregarComprobante = New System.Windows.Forms.Button()
        Me.Bt_EliminarComprobante = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Cb_TipoComprobante = New System.Windows.Forms.ComboBox()
        Me.Tx_NumeroComprobante = New System.Windows.Forms.TextBox()
        Me.Dgv_Comprobante = New System.Windows.Forms.DataGridView()
        Me.CODIGOTIPOCOMPROBANTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRETIPOCOMPROBANTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMEROCOMPROBANTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPROBANTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tx_IdentificaciónPersona = New System.Windows.Forms.TextBox()
        Me.Tx_NombrePersona = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarPersona = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Bt_AgregarCargo = New System.Windows.Forms.Button()
        Me.Lb_Consecutivo = New System.Windows.Forms.Label()
        Me.MA_TIPOCATEGORIATableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOCATEGORIATableAdapter()
        Me.MA_TIPOCARGOTableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOCARGOTableAdapter()
        Me.MA_TIPOGRUPOTableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOGRUPOTableAdapter()
        Me.MA_TIPOLEGALIZACIONTableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOLEGALIZACIONTableAdapter()
        Me.MA_TIPOSALDOTableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOSALDOTableAdapter()
        Me.MA_TIPOCOMPROBANTETableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOCOMPROBANTETableAdapter()
        Me.MA_TIPOCONCEPTOADICIONALTableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOCONCEPTOADICIONALTableAdapter()
        Me.MA_CONCEPTOADICIONALTableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.MA_CONCEPTOADICIONALTableAdapter()
        Me.SC_CONCEPTOADICIONALLEGALIZACIONTableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.SC_CONCEPTOADICIONALLEGALIZACIONTableAdapter()
        Me.ContratoTableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.CONTRATOTableAdapter()
        Me.SC_LEGALIZACIONTableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.SC_LEGALIZACIONTableAdapter()
        Me.DTP_FechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.DTP_FechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Bt_BusPersona = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Tx_Incidental = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Tx_Alojamiento = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Tx_Alimentacion = New System.Windows.Forms.TextBox()
        CType(Me.MATIPOCATEGORIABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Auditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MATIPOCARGOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MATIPOGRUPOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MATIPOLEGALIZACIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MATIPOSALDOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.MACONCEPTOADICIONALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MATIPOCONCEPTOADICIONALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_Conceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CONCEPTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.MATIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_Comprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha:"
        '
        'Dtp_FechaLegalización
        '
        Me.Dtp_FechaLegalización.Enabled = False
        Me.Dtp_FechaLegalización.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaLegalización.Location = New System.Drawing.Point(115, 12)
        Me.Dtp_FechaLegalización.Name = "Dtp_FechaLegalización"
        Me.Dtp_FechaLegalización.Size = New System.Drawing.Size(128, 20)
        Me.Dtp_FechaLegalización.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Persona:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(52, 69)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 13)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Categoría:"
        '
        'Cb_Categoría
        '
        Me.Cb_Categoría.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Categoría.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Categoría.DataSource = Me.MATIPOCATEGORIABindingSource
        Me.Cb_Categoría.DisplayMember = "NOMBRETIPOCATEGORIA"
        Me.Cb_Categoría.FormattingEnabled = True
        Me.Cb_Categoría.Location = New System.Drawing.Point(117, 64)
        Me.Cb_Categoría.Name = "Cb_Categoría"
        Me.Cb_Categoría.Size = New System.Drawing.Size(79, 21)
        Me.Cb_Categoría.TabIndex = 26
        Me.Cb_Categoría.ValueMember = "CODIGOTIPOCATEGORIA"
        '
        'MATIPOCATEGORIABindingSource
        '
        Me.MATIPOCATEGORIABindingSource.DataMember = "MA_TIPOCATEGORIA"
        Me.MATIPOCATEGORIABindingSource.DataSource = Me.Ds_Auditoria
        '
        'Ds_Auditoria
        '
        Me.Ds_Auditoria.DataSetName = "Ds_Auditoria"
        Me.Ds_Auditoria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(205, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Cargo:"
        '
        'Cb_Cargo
        '
        Me.Cb_Cargo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Cargo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Cargo.DataSource = Me.MATIPOCARGOBindingSource
        Me.Cb_Cargo.DisplayMember = "NOMBRETIPOCARGO"
        Me.Cb_Cargo.FormattingEnabled = True
        Me.Cb_Cargo.Location = New System.Drawing.Point(255, 64)
        Me.Cb_Cargo.Name = "Cb_Cargo"
        Me.Cb_Cargo.Size = New System.Drawing.Size(389, 21)
        Me.Cb_Cargo.TabIndex = 27
        Me.Cb_Cargo.ValueMember = "CODIGOTIPOCARGO"
        '
        'MATIPOCARGOBindingSource
        '
        Me.MATIPOCARGOBindingSource.DataMember = "MA_TIPOCARGO"
        Me.MATIPOCARGOBindingSource.DataSource = Me.Ds_Auditoria
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(722, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Grupo:"
        '
        'Cb_Grupo
        '
        Me.Cb_Grupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Grupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Grupo.DataSource = Me.MATIPOGRUPOBindingSource
        Me.Cb_Grupo.DisplayMember = "NOMRETIPOGRUPO"
        Me.Cb_Grupo.FormattingEnabled = True
        Me.Cb_Grupo.Location = New System.Drawing.Point(767, 64)
        Me.Cb_Grupo.Name = "Cb_Grupo"
        Me.Cb_Grupo.Size = New System.Drawing.Size(46, 21)
        Me.Cb_Grupo.TabIndex = 28
        Me.Cb_Grupo.ValueMember = "CODIGOTIPOGRUPO"
        '
        'MATIPOGRUPOBindingSource
        '
        Me.MATIPOGRUPOBindingSource.DataMember = "MA_TIPOGRUPO"
        Me.MATIPOGRUPOBindingSource.DataSource = Me.Ds_Auditoria
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(78, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Tipo:"
        '
        'Cb_TipoLegalización
        '
        Me.Cb_TipoLegalización.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoLegalización.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoLegalización.DataSource = Me.MATIPOLEGALIZACIONBindingSource
        Me.Cb_TipoLegalización.DisplayMember = "NOMBRETIPOLEGALIZACION"
        Me.Cb_TipoLegalización.FormattingEnabled = True
        Me.Cb_TipoLegalización.Location = New System.Drawing.Point(115, 91)
        Me.Cb_TipoLegalización.Name = "Cb_TipoLegalización"
        Me.Cb_TipoLegalización.Size = New System.Drawing.Size(251, 21)
        Me.Cb_TipoLegalización.TabIndex = 29
        Me.Cb_TipoLegalización.ValueMember = "CODIGOTIPOLEGALIZACION"
        '
        'MATIPOLEGALIZACIONBindingSource
        '
        Me.MATIPOLEGALIZACIONBindingSource.DataMember = "MA_TIPOLEGALIZACION"
        Me.MATIPOLEGALIZACIONBindingSource.DataSource = Me.Ds_Auditoria
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(398, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Valor Viatico:"
        '
        'Tx_ValorViatico
        '
        Me.Tx_ValorViatico.Enabled = False
        Me.Tx_ValorViatico.Location = New System.Drawing.Point(473, 93)
        Me.Tx_ValorViatico.MaxLength = 13
        Me.Tx_ValorViatico.Name = "Tx_ValorViatico"
        Me.Tx_ValorViatico.Size = New System.Drawing.Size(159, 20)
        Me.Tx_ValorViatico.TabIndex = 30
        Me.Tx_ValorViatico.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Fecha Desde:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(301, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Fecha Hasta:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(48, 185)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Tipo Saldo:"
        '
        'Cb_TipoSaldo
        '
        Me.Cb_TipoSaldo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoSaldo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoSaldo.DataSource = Me.MATIPOSALDOBindingSource
        Me.Cb_TipoSaldo.DisplayMember = "NOMBRETIPOSALDO"
        Me.Cb_TipoSaldo.FormattingEnabled = True
        Me.Cb_TipoSaldo.Location = New System.Drawing.Point(115, 182)
        Me.Cb_TipoSaldo.Name = "Cb_TipoSaldo"
        Me.Cb_TipoSaldo.Size = New System.Drawing.Size(143, 21)
        Me.Cb_TipoSaldo.TabIndex = 37
        Me.Cb_TipoSaldo.ValueMember = "CODIGOTIPOSALDO"
        '
        'MATIPOSALDOBindingSource
        '
        Me.MATIPOSALDOBindingSource.DataMember = "MA_TIPOSALDO"
        Me.MATIPOSALDOBindingSource.DataSource = Me.Ds_Auditoria
        '
        'Tx_ValorSaldo
        '
        Me.Tx_ValorSaldo.Location = New System.Drawing.Point(376, 185)
        Me.Tx_ValorSaldo.MaxLength = 13
        Me.Tx_ValorSaldo.Name = "Tx_ValorSaldo"
        Me.Tx_ValorSaldo.Size = New System.Drawing.Size(156, 20)
        Me.Tx_ValorSaldo.TabIndex = 38
        Me.Tx_ValorSaldo.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(308, 189)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Valor Saldo:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(652, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Estado:"
        '
        'Cb_Estado
        '
        Me.Cb_Estado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Estado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Estado.DisplayMember = "NOMBRETIPOCATEGORIA"
        Me.Cb_Estado.FormattingEnabled = True
        Me.Cb_Estado.Items.AddRange(New Object() {"ACTIVO", "LIQUIDADO", "VACACIONES"})
        Me.Cb_Estado.Location = New System.Drawing.Point(702, 93)
        Me.Cb_Estado.Name = "Cb_Estado"
        Me.Cb_Estado.Size = New System.Drawing.Size(111, 21)
        Me.Cb_Estado.TabIndex = 31
        Me.Cb_Estado.ValueMember = "CODIGOTIPOCATEGORIA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(43, 212)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Descripción:"
        '
        'Tx_Descripción
        '
        Me.Tx_Descripción.Location = New System.Drawing.Point(115, 211)
        Me.Tx_Descripción.MaxLength = 100
        Me.Tx_Descripción.Multiline = True
        Me.Tx_Descripción.Name = "Tx_Descripción"
        Me.Tx_Descripción.Size = New System.Drawing.Size(705, 38)
        Me.Tx_Descripción.TabIndex = 43
        '
        'Tx_Observación
        '
        Me.Tx_Observación.Location = New System.Drawing.Point(115, 255)
        Me.Tx_Observación.MaxLength = 100
        Me.Tx_Observación.Multiline = True
        Me.Tx_Observación.Name = "Tx_Observación"
        Me.Tx_Observación.Size = New System.Drawing.Size(705, 41)
        Me.Tx_Observación.TabIndex = 44
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(44, 256)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Obervación:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel3.Controls.Add(Me.Button_Cancelar)
        Me.Panel3.Controls.Add(Me.Button_Aceptar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 512)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(854, 30)
        Me.Panel3.TabIndex = 3
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancelar.Location = New System.Drawing.Point(761, 4)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cancelar.TabIndex = 1
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(680, 4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Aceptar.TabIndex = 0
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Tb_Dias)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Bt_AgregarConcepto)
        Me.GroupBox2.Controls.Add(Me.Bt_EliminarConcepto)
        Me.GroupBox2.Controls.Add(Me.Tx_ValorConcepto)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Cb_Concepto)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Cb_TipoConcepto)
        Me.GroupBox2.Controls.Add(Me.Dgv_Conceptos)
        Me.GroupBox2.Location = New System.Drawing.Point(391, 317)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(452, 188)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Conceptos"
        '
        'Tb_Dias
        '
        Me.Tb_Dias.Location = New System.Drawing.Point(226, 46)
        Me.Tb_Dias.MaxLength = 10
        Me.Tb_Dias.Name = "Tb_Dias"
        Me.Tb_Dias.Size = New System.Drawing.Size(38, 20)
        Me.Tb_Dias.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(189, 50)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 13)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "Dias:"
        '
        'Bt_AgregarConcepto
        '
        Me.Bt_AgregarConcepto.Location = New System.Drawing.Point(384, 50)
        Me.Bt_AgregarConcepto.Name = "Bt_AgregarConcepto"
        Me.Bt_AgregarConcepto.Size = New System.Drawing.Size(26, 23)
        Me.Bt_AgregarConcepto.TabIndex = 9
        Me.Bt_AgregarConcepto.Text = "+"
        Me.Bt_AgregarConcepto.UseVisualStyleBackColor = True
        '
        'Bt_EliminarConcepto
        '
        Me.Bt_EliminarConcepto.Location = New System.Drawing.Point(416, 50)
        Me.Bt_EliminarConcepto.Name = "Bt_EliminarConcepto"
        Me.Bt_EliminarConcepto.Size = New System.Drawing.Size(26, 23)
        Me.Bt_EliminarConcepto.TabIndex = 10
        Me.Bt_EliminarConcepto.Text = "-"
        Me.Bt_EliminarConcepto.UseVisualStyleBackColor = True
        '
        'Tx_ValorConcepto
        '
        Me.Tx_ValorConcepto.Location = New System.Drawing.Point(47, 46)
        Me.Tx_ValorConcepto.MaxLength = 13
        Me.Tx_ValorConcepto.Name = "Tx_ValorConcepto"
        Me.Tx_ValorConcepto.Size = New System.Drawing.Size(79, 20)
        Me.Tx_ValorConcepto.TabIndex = 2
        Me.Tx_ValorConcepto.Text = "0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 50)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 13)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Valor:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(168, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 13)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "Concepto:"
        '
        'Cb_Concepto
        '
        Me.Cb_Concepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Concepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Concepto.DataSource = Me.MACONCEPTOADICIONALBindingSource
        Me.Cb_Concepto.DisplayMember = "NOMBRECONCEPTOADICIONAL"
        Me.Cb_Concepto.FormattingEnabled = True
        Me.Cb_Concepto.Location = New System.Drawing.Point(226, 17)
        Me.Cb_Concepto.Name = "Cb_Concepto"
        Me.Cb_Concepto.Size = New System.Drawing.Size(155, 21)
        Me.Cb_Concepto.TabIndex = 1
        Me.Cb_Concepto.ValueMember = "CODIGOCONCEPTOADICIONAL"
        '
        'MACONCEPTOADICIONALBindingSource
        '
        Me.MACONCEPTOADICIONALBindingSource.DataMember = "MA_CONCEPTOADICIONAL"
        Me.MACONCEPTOADICIONALBindingSource.DataSource = Me.Ds_Auditoria
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(31, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Tipo:"
        '
        'Cb_TipoConcepto
        '
        Me.Cb_TipoConcepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoConcepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoConcepto.DataSource = Me.MATIPOCONCEPTOADICIONALBindingSource
        Me.Cb_TipoConcepto.DisplayMember = "NOMBRETIPOCONCEPTOADICIONAL"
        Me.Cb_TipoConcepto.FormattingEnabled = True
        Me.Cb_TipoConcepto.Location = New System.Drawing.Point(47, 18)
        Me.Cb_TipoConcepto.Name = "Cb_TipoConcepto"
        Me.Cb_TipoConcepto.Size = New System.Drawing.Size(110, 21)
        Me.Cb_TipoConcepto.TabIndex = 0
        Me.Cb_TipoConcepto.ValueMember = "CODIGOTIPOCONCEPTOADICIONAL"
        '
        'MATIPOCONCEPTOADICIONALBindingSource
        '
        Me.MATIPOCONCEPTOADICIONALBindingSource.DataMember = "MA_TIPOCONCEPTOADICIONAL"
        Me.MATIPOCONCEPTOADICIONALBindingSource.DataSource = Me.Ds_Auditoria
        '
        'Dgv_Conceptos
        '
        Me.Dgv_Conceptos.AllowUserToAddRows = False
        Me.Dgv_Conceptos.AutoGenerateColumns = False
        Me.Dgv_Conceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Conceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGOCONCEPTOADICIONALDataGridViewTextBoxColumn, Me.CODIGOTIPOCONCEPTOADICIONALDataGridViewTextBoxColumn, Me.NOMBRETIPOCONCEPTOADICIONALDataGridViewTextBoxColumn, Me.NOMBRECONCEPTOADICIONALDataGridViewTextBoxColumn, Me.VALORDataGridViewTextBoxColumn, Me.CANTIDADDIAS})
        Me.Dgv_Conceptos.DataSource = Me.CONCEPTOBindingSource
        Me.Dgv_Conceptos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Dgv_Conceptos.Location = New System.Drawing.Point(3, 78)
        Me.Dgv_Conceptos.MultiSelect = False
        Me.Dgv_Conceptos.Name = "Dgv_Conceptos"
        Me.Dgv_Conceptos.Size = New System.Drawing.Size(446, 107)
        Me.Dgv_Conceptos.TabIndex = 6
        '
        'CODIGOCONCEPTOADICIONALDataGridViewTextBoxColumn
        '
        Me.CODIGOCONCEPTOADICIONALDataGridViewTextBoxColumn.DataPropertyName = "CODIGOCONCEPTOADICIONAL"
        Me.CODIGOCONCEPTOADICIONALDataGridViewTextBoxColumn.HeaderText = "CODIGOCONCEPTOADICIONAL"
        Me.CODIGOCONCEPTOADICIONALDataGridViewTextBoxColumn.Name = "CODIGOCONCEPTOADICIONALDataGridViewTextBoxColumn"
        Me.CODIGOCONCEPTOADICIONALDataGridViewTextBoxColumn.Visible = False
        '
        'CODIGOTIPOCONCEPTOADICIONALDataGridViewTextBoxColumn
        '
        Me.CODIGOTIPOCONCEPTOADICIONALDataGridViewTextBoxColumn.DataPropertyName = "CODIGOTIPOCONCEPTOADICIONAL"
        Me.CODIGOTIPOCONCEPTOADICIONALDataGridViewTextBoxColumn.HeaderText = "CODIGOTIPOCONCEPTOADICIONAL"
        Me.CODIGOTIPOCONCEPTOADICIONALDataGridViewTextBoxColumn.Name = "CODIGOTIPOCONCEPTOADICIONALDataGridViewTextBoxColumn"
        Me.CODIGOTIPOCONCEPTOADICIONALDataGridViewTextBoxColumn.Visible = False
        '
        'NOMBRETIPOCONCEPTOADICIONALDataGridViewTextBoxColumn
        '
        Me.NOMBRETIPOCONCEPTOADICIONALDataGridViewTextBoxColumn.DataPropertyName = "NOMBRETIPOCONCEPTOADICIONAL"
        Me.NOMBRETIPOCONCEPTOADICIONALDataGridViewTextBoxColumn.HeaderText = "Tipo"
        Me.NOMBRETIPOCONCEPTOADICIONALDataGridViewTextBoxColumn.Name = "NOMBRETIPOCONCEPTOADICIONALDataGridViewTextBoxColumn"
        Me.NOMBRETIPOCONCEPTOADICIONALDataGridViewTextBoxColumn.ReadOnly = True
        Me.NOMBRETIPOCONCEPTOADICIONALDataGridViewTextBoxColumn.Width = 125
        '
        'NOMBRECONCEPTOADICIONALDataGridViewTextBoxColumn
        '
        Me.NOMBRECONCEPTOADICIONALDataGridViewTextBoxColumn.DataPropertyName = "NOMBRECONCEPTOADICIONAL"
        Me.NOMBRECONCEPTOADICIONALDataGridViewTextBoxColumn.HeaderText = "Concepto"
        Me.NOMBRECONCEPTOADICIONALDataGridViewTextBoxColumn.Name = "NOMBRECONCEPTOADICIONALDataGridViewTextBoxColumn"
        Me.NOMBRECONCEPTOADICIONALDataGridViewTextBoxColumn.ReadOnly = True
        Me.NOMBRECONCEPTOADICIONALDataGridViewTextBoxColumn.Width = 125
        '
        'VALORDataGridViewTextBoxColumn
        '
        Me.VALORDataGridViewTextBoxColumn.DataPropertyName = "VALOR"
        DataGridViewCellStyle1.Format = "C0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.VALORDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.VALORDataGridViewTextBoxColumn.HeaderText = "Valor"
        Me.VALORDataGridViewTextBoxColumn.Name = "VALORDataGridViewTextBoxColumn"
        '
        'CANTIDADDIAS
        '
        Me.CANTIDADDIAS.DataPropertyName = "CANTIDADDIAS"
        Me.CANTIDADDIAS.HeaderText = "Dias"
        Me.CANTIDADDIAS.Name = "CANTIDADDIAS"
        Me.CANTIDADDIAS.Width = 50
        '
        'CONCEPTOBindingSource
        '
        Me.CONCEPTOBindingSource.DataMember = "CONCEPTO"
        Me.CONCEPTOBindingSource.DataSource = Me.Ds_Auditoria
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Cb_NombreComprobante)
        Me.GroupBox1.Controls.Add(Me.Bt_AgregarComprobante)
        Me.GroupBox1.Controls.Add(Me.Bt_EliminarComprobante)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Cb_TipoComprobante)
        Me.GroupBox1.Controls.Add(Me.Tx_NumeroComprobante)
        Me.GroupBox1.Controls.Add(Me.Dgv_Comprobante)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 317)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 188)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Comprobantes"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(16, 52)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(47, 13)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "Nombre:"
        '
        'Cb_NombreComprobante
        '
        Me.Cb_NombreComprobante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_NombreComprobante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_NombreComprobante.DataSource = Me.MATIPOCOMPROBANTEBindingSource
        Me.Cb_NombreComprobante.DisplayMember = "NOMBRETIPOCOMPROBANTE"
        Me.Cb_NombreComprobante.FormattingEnabled = True
        Me.Cb_NombreComprobante.Location = New System.Drawing.Point(70, 48)
        Me.Cb_NombreComprobante.Name = "Cb_NombreComprobante"
        Me.Cb_NombreComprobante.Size = New System.Drawing.Size(233, 21)
        Me.Cb_NombreComprobante.TabIndex = 2
        Me.Cb_NombreComprobante.ValueMember = "CODIGOTIPOCOMPROBANTE"
        '
        'MATIPOCOMPROBANTEBindingSource
        '
        Me.MATIPOCOMPROBANTEBindingSource.DataMember = "MA_TIPOCOMPROBANTE"
        Me.MATIPOCOMPROBANTEBindingSource.DataSource = Me.Ds_Auditoria
        '
        'Bt_AgregarComprobante
        '
        Me.Bt_AgregarComprobante.Location = New System.Drawing.Point(309, 49)
        Me.Bt_AgregarComprobante.Name = "Bt_AgregarComprobante"
        Me.Bt_AgregarComprobante.Size = New System.Drawing.Size(24, 23)
        Me.Bt_AgregarComprobante.TabIndex = 3
        Me.Bt_AgregarComprobante.Text = "+"
        Me.Bt_AgregarComprobante.UseVisualStyleBackColor = True
        '
        'Bt_EliminarComprobante
        '
        Me.Bt_EliminarComprobante.Location = New System.Drawing.Point(339, 49)
        Me.Bt_EliminarComprobante.Name = "Bt_EliminarComprobante"
        Me.Bt_EliminarComprobante.Size = New System.Drawing.Size(24, 23)
        Me.Bt_EliminarComprobante.TabIndex = 4
        Me.Bt_EliminarComprobante.Text = "-"
        Me.Bt_EliminarComprobante.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(186, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Numero:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(33, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 13)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Tipo:"
        '
        'Cb_TipoComprobante
        '
        Me.Cb_TipoComprobante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoComprobante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoComprobante.DataSource = Me.MATIPOCOMPROBANTEBindingSource
        Me.Cb_TipoComprobante.DisplayMember = "ABREVIATURATIPOCOMPROBANTE"
        Me.Cb_TipoComprobante.FormattingEnabled = True
        Me.Cb_TipoComprobante.Location = New System.Drawing.Point(70, 21)
        Me.Cb_TipoComprobante.Name = "Cb_TipoComprobante"
        Me.Cb_TipoComprobante.Size = New System.Drawing.Size(101, 21)
        Me.Cb_TipoComprobante.TabIndex = 0
        Me.Cb_TipoComprobante.ValueMember = "CODIGOTIPOCOMPROBANTE"
        '
        'Tx_NumeroComprobante
        '
        Me.Tx_NumeroComprobante.Location = New System.Drawing.Point(239, 22)
        Me.Tx_NumeroComprobante.MaxLength = 9
        Me.Tx_NumeroComprobante.Name = "Tx_NumeroComprobante"
        Me.Tx_NumeroComprobante.Size = New System.Drawing.Size(64, 20)
        Me.Tx_NumeroComprobante.TabIndex = 1
        '
        'Dgv_Comprobante
        '
        Me.Dgv_Comprobante.AllowUserToAddRows = False
        Me.Dgv_Comprobante.AutoGenerateColumns = False
        Me.Dgv_Comprobante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Comprobante.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGOTIPOCOMPROBANTEDataGridViewTextBoxColumn, Me.ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn, Me.NOMBRETIPOCOMPROBANTE, Me.NUMEROCOMPROBANTEDataGridViewTextBoxColumn})
        Me.Dgv_Comprobante.DataSource = Me.COMPROBANTEBindingSource
        Me.Dgv_Comprobante.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Dgv_Comprobante.Location = New System.Drawing.Point(3, 78)
        Me.Dgv_Comprobante.MultiSelect = False
        Me.Dgv_Comprobante.Name = "Dgv_Comprobante"
        Me.Dgv_Comprobante.Size = New System.Drawing.Size(363, 107)
        Me.Dgv_Comprobante.TabIndex = 8
        '
        'CODIGOTIPOCOMPROBANTEDataGridViewTextBoxColumn
        '
        Me.CODIGOTIPOCOMPROBANTEDataGridViewTextBoxColumn.DataPropertyName = "CODIGOTIPOCOMPROBANTE"
        Me.CODIGOTIPOCOMPROBANTEDataGridViewTextBoxColumn.HeaderText = "CODIGOTIPOCOMPROBANTE"
        Me.CODIGOTIPOCOMPROBANTEDataGridViewTextBoxColumn.Name = "CODIGOTIPOCOMPROBANTEDataGridViewTextBoxColumn"
        Me.CODIGOTIPOCOMPROBANTEDataGridViewTextBoxColumn.Visible = False
        '
        'ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn
        '
        Me.ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn.DataPropertyName = "ABREVIATURATIPOCOMPROBANTE"
        Me.ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn.HeaderText = "Tipo"
        Me.ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn.Name = "ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn"
        Me.ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn.Width = 50
        '
        'NOMBRETIPOCOMPROBANTE
        '
        Me.NOMBRETIPOCOMPROBANTE.DataPropertyName = "NOMBRETIPOCOMPROBANTE"
        Me.NOMBRETIPOCOMPROBANTE.HeaderText = "Nombre"
        Me.NOMBRETIPOCOMPROBANTE.Name = "NOMBRETIPOCOMPROBANTE"
        Me.NOMBRETIPOCOMPROBANTE.ReadOnly = True
        Me.NOMBRETIPOCOMPROBANTE.Width = 200
        '
        'NUMEROCOMPROBANTEDataGridViewTextBoxColumn
        '
        Me.NUMEROCOMPROBANTEDataGridViewTextBoxColumn.DataPropertyName = "NUMEROCOMPROBANTE"
        Me.NUMEROCOMPROBANTEDataGridViewTextBoxColumn.HeaderText = "Numero"
        Me.NUMEROCOMPROBANTEDataGridViewTextBoxColumn.Name = "NUMEROCOMPROBANTEDataGridViewTextBoxColumn"
        Me.NUMEROCOMPROBANTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMEROCOMPROBANTEDataGridViewTextBoxColumn.Width = 50
        '
        'COMPROBANTEBindingSource
        '
        Me.COMPROBANTEBindingSource.DataMember = "COMPROBANTE"
        Me.COMPROBANTEBindingSource.DataSource = Me.Ds_Auditoria
        '
        'Tx_IdentificaciónPersona
        '
        Me.Tx_IdentificaciónPersona.Location = New System.Drawing.Point(115, 38)
        Me.Tx_IdentificaciónPersona.MaxLength = 20
        Me.Tx_IdentificaciónPersona.Name = "Tx_IdentificaciónPersona"
        Me.Tx_IdentificaciónPersona.Size = New System.Drawing.Size(128, 20)
        Me.Tx_IdentificaciónPersona.TabIndex = 24
        '
        'Tx_NombrePersona
        '
        Me.Tx_NombrePersona.Location = New System.Drawing.Point(255, 37)
        Me.Tx_NombrePersona.Name = "Tx_NombrePersona"
        Me.Tx_NombrePersona.ReadOnly = True
        Me.Tx_NombrePersona.Size = New System.Drawing.Size(389, 20)
        Me.Tx_NombrePersona.TabIndex = 25
        '
        'Bt_BuscarPersona
        '
        Me.Bt_BuscarPersona.Location = New System.Drawing.Point(650, 36)
        Me.Bt_BuscarPersona.Name = "Bt_BuscarPersona"
        Me.Bt_BuscarPersona.Size = New System.Drawing.Size(26, 23)
        Me.Bt_BuscarPersona.TabIndex = 18
        Me.Bt_BuscarPersona.Text = "..."
        Me.Bt_BuscarPersona.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(650, 63)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(26, 23)
        Me.Button7.TabIndex = 21
        Me.Button7.Text = "..."
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Bt_AgregarCargo
        '
        Me.Bt_AgregarCargo.Location = New System.Drawing.Point(684, 63)
        Me.Bt_AgregarCargo.Name = "Bt_AgregarCargo"
        Me.Bt_AgregarCargo.Size = New System.Drawing.Size(26, 23)
        Me.Bt_AgregarCargo.TabIndex = 20
        Me.Bt_AgregarCargo.Text = "+"
        Me.Bt_AgregarCargo.UseVisualStyleBackColor = True
        Me.Bt_AgregarCargo.Visible = False
        '
        'Lb_Consecutivo
        '
        Me.Lb_Consecutivo.AutoSize = True
        Me.Lb_Consecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Consecutivo.Location = New System.Drawing.Point(579, 11)
        Me.Lb_Consecutivo.Name = "Lb_Consecutivo"
        Me.Lb_Consecutivo.Size = New System.Drawing.Size(0, 20)
        Me.Lb_Consecutivo.TabIndex = 15
        '
        'MA_TIPOCATEGORIATableAdapter
        '
        Me.MA_TIPOCATEGORIATableAdapter.ClearBeforeFill = True
        '
        'MA_TIPOCARGOTableAdapter
        '
        Me.MA_TIPOCARGOTableAdapter.ClearBeforeFill = True
        '
        'MA_TIPOGRUPOTableAdapter
        '
        Me.MA_TIPOGRUPOTableAdapter.ClearBeforeFill = True
        '
        'MA_TIPOLEGALIZACIONTableAdapter
        '
        Me.MA_TIPOLEGALIZACIONTableAdapter.ClearBeforeFill = True
        '
        'MA_TIPOSALDOTableAdapter
        '
        Me.MA_TIPOSALDOTableAdapter.ClearBeforeFill = True
        '
        'MA_TIPOCOMPROBANTETableAdapter
        '
        Me.MA_TIPOCOMPROBANTETableAdapter.ClearBeforeFill = True
        '
        'MA_TIPOCONCEPTOADICIONALTableAdapter
        '
        Me.MA_TIPOCONCEPTOADICIONALTableAdapter.ClearBeforeFill = True
        '
        'MA_CONCEPTOADICIONALTableAdapter
        '
        Me.MA_CONCEPTOADICIONALTableAdapter.ClearBeforeFill = True
        '
        'SC_CONCEPTOADICIONALLEGALIZACIONTableAdapter
        '
        Me.SC_CONCEPTOADICIONALLEGALIZACIONTableAdapter.ClearBeforeFill = True
        '
        'ContratoTableAdapter
        '
        Me.ContratoTableAdapter.ClearBeforeFill = True
        '
        'SC_LEGALIZACIONTableAdapter
        '
        Me.SC_LEGALIZACIONTableAdapter.ClearBeforeFill = True
        '
        'DTP_FechaDesde
        '
        Me.DTP_FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaDesde.Location = New System.Drawing.Point(117, 157)
        Me.DTP_FechaDesde.Name = "DTP_FechaDesde"
        Me.DTP_FechaDesde.Size = New System.Drawing.Size(141, 20)
        Me.DTP_FechaDesde.TabIndex = 35
        '
        'DTP_FechaHasta
        '
        Me.DTP_FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaHasta.Location = New System.Drawing.Point(375, 159)
        Me.DTP_FechaHasta.Name = "DTP_FechaHasta"
        Me.DTP_FechaHasta.Size = New System.Drawing.Size(157, 20)
        Me.DTP_FechaHasta.TabIndex = 36
        '
        'Bt_BusPersona
        '
        Me.Bt_BusPersona.Enabled = False
        Me.Bt_BusPersona.Location = New System.Drawing.Point(684, 36)
        Me.Bt_BusPersona.Name = "Bt_BusPersona"
        Me.Bt_BusPersona.Size = New System.Drawing.Size(26, 23)
        Me.Bt_BusPersona.TabIndex = 19
        Me.Bt_BusPersona.Text = "+"
        Me.Bt_BusPersona.UseVisualStyleBackColor = True
        Me.Bt_BusPersona.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Cu_CentroCosto1)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Tx_Incidental)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Tx_Alojamiento)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Tx_Alimentacion)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Dtp_FechaLegalización)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Bt_BusPersona)
        Me.GroupBox3.Controls.Add(Me.Cb_Categoría)
        Me.GroupBox3.Controls.Add(Me.DTP_FechaHasta)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.DTP_FechaDesde)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Lb_Consecutivo)
        Me.GroupBox3.Controls.Add(Me.Cb_Cargo)
        Me.GroupBox3.Controls.Add(Me.Bt_AgregarCargo)
        Me.GroupBox3.Controls.Add(Me.Cb_Grupo)
        Me.GroupBox3.Controls.Add(Me.Button7)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Bt_BuscarPersona)
        Me.GroupBox3.Controls.Add(Me.Cb_TipoLegalización)
        Me.GroupBox3.Controls.Add(Me.Tx_NombrePersona)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Tx_IdentificaciónPersona)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Tx_ValorViatico)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Tx_Observación)
        Me.GroupBox3.Controls.Add(Me.Cb_TipoSaldo)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Tx_Descripción)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Tx_ValorSaldo)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Cb_Estado)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(827, 306)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Legalización"
        '
        'Cu_CentroCosto1
        '
        Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto1.Location = New System.Drawing.Point(562, 159)
        Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
        Me.Cu_CentroCosto1.Size = New System.Drawing.Size(255, 38)
        Me.Cu_CentroCosto1.TabIndex = 45
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(579, 129)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 13)
        Me.Label26.TabIndex = 17
        Me.Label26.Text = "Incidental:"
        '
        'Tx_Incidental
        '
        Me.Tx_Incidental.Enabled = False
        Me.Tx_Incidental.Location = New System.Drawing.Point(641, 126)
        Me.Tx_Incidental.MaxLength = 13
        Me.Tx_Incidental.Name = "Tx_Incidental"
        Me.Tx_Incidental.Size = New System.Drawing.Size(172, 20)
        Me.Tx_Incidental.TabIndex = 34
        Me.Tx_Incidental.Text = "0"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(308, 129)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 11
        Me.Label25.Text = "Alojamiento:"
        '
        'Tx_Alojamiento
        '
        Me.Tx_Alojamiento.Enabled = False
        Me.Tx_Alojamiento.Location = New System.Drawing.Point(376, 126)
        Me.Tx_Alojamiento.MaxLength = 13
        Me.Tx_Alojamiento.Name = "Tx_Alojamiento"
        Me.Tx_Alojamiento.Size = New System.Drawing.Size(159, 20)
        Me.Tx_Alojamiento.TabIndex = 33
        Me.Tx_Alojamiento.Text = "0"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(39, 129)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 13)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Alimentación:"
        '
        'Tx_Alimentacion
        '
        Me.Tx_Alimentacion.Enabled = False
        Me.Tx_Alimentacion.Location = New System.Drawing.Point(118, 126)
        Me.Tx_Alimentacion.MaxLength = 13
        Me.Tx_Alimentacion.Name = "Tx_Alimentacion"
        Me.Tx_Alimentacion.Size = New System.Drawing.Size(140, 20)
        Me.Tx_Alimentacion.TabIndex = 32
        Me.Tx_Alimentacion.Text = "0"
        '
        'Fr_Legalización
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button_Cancelar
        Me.ClientSize = New System.Drawing.Size(854, 542)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_Legalización"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Legalización"
        CType(Me.MATIPOCATEGORIABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Auditoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MATIPOCARGOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MATIPOGRUPOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MATIPOLEGALIZACIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MATIPOSALDOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.MACONCEPTOADICIONALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MATIPOCONCEPTOADICIONALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_Conceptos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CONCEPTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.MATIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_Comprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
  Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaLegalización As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Cb_Categoría As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cb_Cargo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cb_Grupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoLegalización As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Tx_ValorViatico As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoSaldo As System.Windows.Forms.ComboBox
    Friend WithEvents Tx_ValorSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Cb_Estado As System.Windows.Forms.ComboBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Tx_Descripción As System.Windows.Forms.TextBox
  Friend WithEvents Tx_Observación As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents Button_Cancelar As System.Windows.Forms.Button
  Public WithEvents Button_Aceptar As System.Windows.Forms.Button
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Dgv_Conceptos As System.Windows.Forms.DataGridView
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Tx_NumeroComprobante As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents Cb_TipoComprobante As System.Windows.Forms.ComboBox
  Friend WithEvents Dgv_Comprobante As System.Windows.Forms.DataGridView
  Friend WithEvents Bt_AgregarComprobante As System.Windows.Forms.Button
  Friend WithEvents Bt_EliminarComprobante As System.Windows.Forms.Button
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Cb_Concepto As System.Windows.Forms.ComboBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Cb_TipoConcepto As System.Windows.Forms.ComboBox
  Friend WithEvents Bt_AgregarConcepto As System.Windows.Forms.Button
  Friend WithEvents Bt_EliminarConcepto As System.Windows.Forms.Button
  Friend WithEvents Tx_ValorConcepto As System.Windows.Forms.TextBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Ds_Auditoria As DatosAuditoria.Ds_Auditoria
  Friend WithEvents MATIPOCATEGORIABindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents MA_TIPOCATEGORIATableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOCATEGORIATableAdapter
  Friend WithEvents MATIPOCARGOBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents MA_TIPOCARGOTableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOCARGOTableAdapter
  Friend WithEvents MATIPOGRUPOBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents MA_TIPOGRUPOTableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOGRUPOTableAdapter
  Friend WithEvents MATIPOLEGALIZACIONBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents MA_TIPOLEGALIZACIONTableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOLEGALIZACIONTableAdapter
  Friend WithEvents MATIPOSALDOBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents MA_TIPOSALDOTableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOSALDOTableAdapter
  Friend WithEvents MATIPOCOMPROBANTEBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents MA_TIPOCOMPROBANTETableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOCOMPROBANTETableAdapter
  Friend WithEvents MATIPOCONCEPTOADICIONALBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents MA_TIPOCONCEPTOADICIONALTableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.MA_TIPOCONCEPTOADICIONALTableAdapter
  Friend WithEvents MACONCEPTOADICIONALBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents MA_CONCEPTOADICIONALTableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.MA_CONCEPTOADICIONALTableAdapter
  Friend WithEvents Tx_IdentificaciónPersona As System.Windows.Forms.TextBox
  Friend WithEvents Tx_NombrePersona As System.Windows.Forms.TextBox
  Friend WithEvents Bt_BuscarPersona As System.Windows.Forms.Button
  Friend WithEvents Button7 As System.Windows.Forms.Button
  Friend WithEvents Bt_AgregarCargo As System.Windows.Forms.Button
  Friend WithEvents COMPROBANTEBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents CONCEPTOBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents Lb_Consecutivo As System.Windows.Forms.Label
  Friend WithEvents SC_CONCEPTOADICIONALLEGALIZACIONTableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.SC_CONCEPTOADICIONALLEGALIZACIONTableAdapter
  Friend WithEvents Tb_Dias As System.Windows.Forms.TextBox
  Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ContratoTableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.CONTRATOTableAdapter
  Friend WithEvents SC_LEGALIZACIONTableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.SC_LEGALIZACIONTableAdapter
  Friend WithEvents DTP_FechaDesde As System.Windows.Forms.DateTimePicker
  Friend WithEvents DTP_FechaHasta As System.Windows.Forms.DateTimePicker
  Friend WithEvents Bt_BusPersona As System.Windows.Forms.Button
  Friend WithEvents Cb_NombreComprobante As System.Windows.Forms.ComboBox
  Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CODIGOCONCEPTOADICIONALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOTIPOCONCEPTOADICIONALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRETIPOCONCEPTOADICIONALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRECONCEPTOADICIONALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOTIPOCOMPROBANTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRETIPOCOMPROBANTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMEROCOMPROBANTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Tx_Incidental As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Tx_Alojamiento As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Tx_Alimentacion As System.Windows.Forms.TextBox
  Friend WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
End Class
