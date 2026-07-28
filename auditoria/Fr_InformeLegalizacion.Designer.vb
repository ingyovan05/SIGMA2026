<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_InformeLegalizacion
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
    Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Dgv_InformeLegalizaicon = New System.Windows.Forms.DataGridView()
    Me.Btn_ExportarExcel_Informe = New System.Windows.Forms.Button()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Bt_Cerrar = New System.Windows.Forms.Button()
    Me.BindingSourceInformeLegalizacion = New System.Windows.Forms.BindingSource(Me.components)
    Me.Ds_Auditoria = New DatosAuditoria.Ds_Auditoria()
    Me.InformeAuditoriaMaestroTableAdapter = New DatosAuditoria.Ds_AuditoriaTableAdapters.InformeAuditoriaMaestroTableAdapter()
    Me.ConsecutivoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.IdentificaciónDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.NombreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.EstadoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.TIPOLEGALIZACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.NOMBRECENTROCOSTOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ViaticoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.VALORALIMENTACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.VALORALOJAMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.VALORINCIDENTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.SALDOFAVORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.SALDOCARGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.SALDOFAVOROTROSANTICIPOSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.SALDOCARGOOTROSANTICIPOSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.COMPROBANTES = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.días_Prima_Tec_mont_y_mante = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.PrimaTecmontymanteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Prima_Admin_y_Gestión = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.días_Prima_Admin_y_Gestión = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.PrimaTecdeperforacionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.días_Prima_Tec_de_perforacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.PrimaTecMTTOPozosDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.días_Prima_Tec_MTTO_Pozos = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.PrimaTecopecampetDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.días_Prima_Tec_ope_cam_pet = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.BonoCampamentoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.días_Bono_Campamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.BonoHorasdevueloDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.días_Bono_Horas_de_vuelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.AlquilerHerramientasDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.días_Alquiler_Herramientas = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.TiquetesEmplVenTEspDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.días_Tiquetes_Empl_Ven_T_Esp = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.CODIGOSUBCENTROCOSTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.NOMBRESUBCENTROCOSTOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
    CType(Me.Dgv_InformeLegalizaicon, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    CType(Me.BindingSourceInformeLegalizacion, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Ds_Auditoria, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Dgv_InformeLegalizaicon
    '
    Me.Dgv_InformeLegalizaicon.AllowUserToAddRows = False
    Me.Dgv_InformeLegalizaicon.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.Dgv_InformeLegalizaicon.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.Dgv_InformeLegalizaicon.AutoGenerateColumns = False
    Me.Dgv_InformeLegalizaicon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.Dgv_InformeLegalizaicon.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ConsecutivoDataGridViewTextBoxColumn, Me.IdentificaciónDataGridViewTextBoxColumn, Me.NombreDataGridViewTextBoxColumn, Me.EstadoDataGridViewTextBoxColumn, Me.TIPOLEGALIZACION, Me.NOMBRECENTROCOSTOS, Me.ViaticoDataGridViewTextBoxColumn, Me.VALORALIMENTACION, Me.VALORALOJAMIENTO, Me.VALORINCIDENTAL, Me.SALDOFAVORDataGridViewTextBoxColumn, Me.SALDOCARGODataGridViewTextBoxColumn, Me.SALDOFAVOROTROSANTICIPOSDataGridViewTextBoxColumn, Me.SALDOCARGOOTROSANTICIPOSDataGridViewTextBoxColumn, Me.COMPROBANTES, Me.días_Prima_Tec_mont_y_mante, Me.PrimaTecmontymanteDataGridViewTextBoxColumn, Me.Prima_Admin_y_Gestión, Me.días_Prima_Admin_y_Gestión, Me.PrimaTecdeperforacionDataGridViewTextBoxColumn, Me.días_Prima_Tec_de_perforacion, Me.PrimaTecMTTOPozosDataGridViewTextBoxColumn, Me.días_Prima_Tec_MTTO_Pozos, Me.PrimaTecopecampetDataGridViewTextBoxColumn, Me.días_Prima_Tec_ope_cam_pet, Me.BonoCampamentoDataGridViewTextBoxColumn, Me.días_Bono_Campamento, Me.BonoHorasdevueloDataGridViewTextBoxColumn, Me.días_Bono_Horas_de_vuelo, Me.AlquilerHerramientasDataGridViewTextBoxColumn, Me.días_Alquiler_Herramientas, Me.TiquetesEmplVenTEspDataGridViewTextBoxColumn, Me.días_Tiquetes_Empl_Ven_T_Esp, Me.CODIGOSUBCENTROCOSTO, Me.NOMBRESUBCENTROCOSTOS})
    Me.Dgv_InformeLegalizaicon.DataSource = Me.BindingSourceInformeLegalizacion
    Me.Dgv_InformeLegalizaicon.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Dgv_InformeLegalizaicon.Location = New System.Drawing.Point(0, 0)
    Me.Dgv_InformeLegalizaicon.Name = "Dgv_InformeLegalizaicon"
    Me.Dgv_InformeLegalizaicon.Size = New System.Drawing.Size(1160, 525)
    Me.Dgv_InformeLegalizaicon.TabIndex = 1
    '
    'Btn_ExportarExcel_Informe
    '
    Me.Btn_ExportarExcel_Informe.Location = New System.Drawing.Point(965, 7)
    Me.Btn_ExportarExcel_Informe.Name = "Btn_ExportarExcel_Informe"
    Me.Btn_ExportarExcel_Informe.Size = New System.Drawing.Size(94, 23)
    Me.Btn_ExportarExcel_Informe.TabIndex = 0
    Me.Btn_ExportarExcel_Informe.Text = "Exportar Excel"
    Me.Btn_ExportarExcel_Informe.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
    Me.Panel1.Controls.Add(Me.Bt_Cerrar)
    Me.Panel1.Controls.Add(Me.Btn_ExportarExcel_Informe)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel1.ImeMode = System.Windows.Forms.ImeMode.[On]
    Me.Panel1.Location = New System.Drawing.Point(0, 525)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1160, 37)
    Me.Panel1.TabIndex = 2
    '
    'Bt_Cerrar
    '
    Me.Bt_Cerrar.Location = New System.Drawing.Point(1066, 7)
    Me.Bt_Cerrar.Name = "Bt_Cerrar"
    Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
    Me.Bt_Cerrar.TabIndex = 1
    Me.Bt_Cerrar.Text = "Cerrar"
    Me.Bt_Cerrar.UseVisualStyleBackColor = True
    '
    'BindingSourceInformeLegalizacion
    '
    Me.BindingSourceInformeLegalizacion.DataMember = "InformeAuditoriaMaestro"
    Me.BindingSourceInformeLegalizacion.DataSource = Me.Ds_Auditoria
    '
    'Ds_Auditoria
    '
    Me.Ds_Auditoria.DataSetName = "Ds_Auditoria"
    Me.Ds_Auditoria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
    '
    'InformeAuditoriaMaestroTableAdapter
    '
    Me.InformeAuditoriaMaestroTableAdapter.ClearBeforeFill = True
    '
    'ConsecutivoDataGridViewTextBoxColumn
    '
    Me.ConsecutivoDataGridViewTextBoxColumn.DataPropertyName = "Consecutivo"
    Me.ConsecutivoDataGridViewTextBoxColumn.HeaderText = "Consecutivo"
    Me.ConsecutivoDataGridViewTextBoxColumn.Name = "ConsecutivoDataGridViewTextBoxColumn"
    Me.ConsecutivoDataGridViewTextBoxColumn.ReadOnly = True
    '
    'IdentificaciónDataGridViewTextBoxColumn
    '
    Me.IdentificaciónDataGridViewTextBoxColumn.DataPropertyName = "Identificación"
    DataGridViewCellStyle2.Format = "N0"
    DataGridViewCellStyle2.NullValue = Nothing
    Me.IdentificaciónDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
    Me.IdentificaciónDataGridViewTextBoxColumn.HeaderText = "Identificación"
    Me.IdentificaciónDataGridViewTextBoxColumn.Name = "IdentificaciónDataGridViewTextBoxColumn"
    Me.IdentificaciónDataGridViewTextBoxColumn.ReadOnly = True
    '
    'NombreDataGridViewTextBoxColumn
    '
    Me.NombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre"
    Me.NombreDataGridViewTextBoxColumn.HeaderText = "Nombre"
    Me.NombreDataGridViewTextBoxColumn.Name = "NombreDataGridViewTextBoxColumn"
    Me.NombreDataGridViewTextBoxColumn.ReadOnly = True
    '
    'EstadoDataGridViewTextBoxColumn
    '
    Me.EstadoDataGridViewTextBoxColumn.DataPropertyName = "Estado"
    Me.EstadoDataGridViewTextBoxColumn.HeaderText = "Estado"
    Me.EstadoDataGridViewTextBoxColumn.Name = "EstadoDataGridViewTextBoxColumn"
    Me.EstadoDataGridViewTextBoxColumn.ReadOnly = True
    '
    'TIPOLEGALIZACION
    '
    Me.TIPOLEGALIZACION.DataPropertyName = "TIPOLEGALIZACION"
    Me.TIPOLEGALIZACION.HeaderText = "Tipo Legalizacion"
    Me.TIPOLEGALIZACION.Name = "TIPOLEGALIZACION"
    Me.TIPOLEGALIZACION.ReadOnly = True
    '
    'NOMBRECENTROCOSTOS
    '
    Me.NOMBRECENTROCOSTOS.DataPropertyName = "CENTROCOSTO"
    Me.NOMBRECENTROCOSTOS.HeaderText = "Centro de costos"
    Me.NOMBRECENTROCOSTOS.Name = "NOMBRECENTROCOSTOS"
    '
    'ViaticoDataGridViewTextBoxColumn
    '
    Me.ViaticoDataGridViewTextBoxColumn.DataPropertyName = "Viatico"
    DataGridViewCellStyle3.Format = "C0"
    DataGridViewCellStyle3.NullValue = Nothing
    Me.ViaticoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
    Me.ViaticoDataGridViewTextBoxColumn.HeaderText = "Viatico"
    Me.ViaticoDataGridViewTextBoxColumn.Name = "ViaticoDataGridViewTextBoxColumn"
    Me.ViaticoDataGridViewTextBoxColumn.ReadOnly = True
    '
    'VALORALIMENTACION
    '
    Me.VALORALIMENTACION.DataPropertyName = "VALORALIMENTACION"
    Me.VALORALIMENTACION.HeaderText = "Valor Alimentacion"
    Me.VALORALIMENTACION.Name = "VALORALIMENTACION"
    Me.VALORALIMENTACION.ReadOnly = True
    '
    'VALORALOJAMIENTO
    '
    Me.VALORALOJAMIENTO.DataPropertyName = "VALORALOJAMIENTO"
    Me.VALORALOJAMIENTO.HeaderText = "Valor Alojamiento"
    Me.VALORALOJAMIENTO.Name = "VALORALOJAMIENTO"
    Me.VALORALOJAMIENTO.ReadOnly = True
    '
    'VALORINCIDENTAL
    '
    Me.VALORINCIDENTAL.DataPropertyName = "VALORINCIDENTAL"
    Me.VALORINCIDENTAL.HeaderText = "Valor Incidental"
    Me.VALORINCIDENTAL.Name = "VALORINCIDENTAL"
    Me.VALORINCIDENTAL.ReadOnly = True
    '
    'SALDOFAVORDataGridViewTextBoxColumn
    '
    Me.SALDOFAVORDataGridViewTextBoxColumn.DataPropertyName = "SALDO_FAVOR"
    DataGridViewCellStyle4.Format = "C0"
    DataGridViewCellStyle4.NullValue = Nothing
    Me.SALDOFAVORDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
    Me.SALDOFAVORDataGridViewTextBoxColumn.HeaderText = "Saldo favor"
    Me.SALDOFAVORDataGridViewTextBoxColumn.Name = "SALDOFAVORDataGridViewTextBoxColumn"
    Me.SALDOFAVORDataGridViewTextBoxColumn.ReadOnly = True
    '
    'SALDOCARGODataGridViewTextBoxColumn
    '
    Me.SALDOCARGODataGridViewTextBoxColumn.DataPropertyName = "SALDO_CARGO"
    DataGridViewCellStyle5.Format = "C0"
    DataGridViewCellStyle5.NullValue = Nothing
    Me.SALDOCARGODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
    Me.SALDOCARGODataGridViewTextBoxColumn.HeaderText = "Saldo cargo"
    Me.SALDOCARGODataGridViewTextBoxColumn.Name = "SALDOCARGODataGridViewTextBoxColumn"
    Me.SALDOCARGODataGridViewTextBoxColumn.ReadOnly = True
    '
    'SALDOFAVOROTROSANTICIPOSDataGridViewTextBoxColumn
    '
    Me.SALDOFAVOROTROSANTICIPOSDataGridViewTextBoxColumn.DataPropertyName = "SALDO_FAVOR_OTROS_ANTICIPOS"
    DataGridViewCellStyle6.Format = "C0"
    DataGridViewCellStyle6.NullValue = Nothing
    Me.SALDOFAVOROTROSANTICIPOSDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
    Me.SALDOFAVOROTROSANTICIPOSDataGridViewTextBoxColumn.HeaderText = "Saldo favor otros anticipos"
    Me.SALDOFAVOROTROSANTICIPOSDataGridViewTextBoxColumn.Name = "SALDOFAVOROTROSANTICIPOSDataGridViewTextBoxColumn"
    Me.SALDOFAVOROTROSANTICIPOSDataGridViewTextBoxColumn.ReadOnly = True
    '
    'SALDOCARGOOTROSANTICIPOSDataGridViewTextBoxColumn
    '
    Me.SALDOCARGOOTROSANTICIPOSDataGridViewTextBoxColumn.DataPropertyName = "SALDO_CARGO_OTROS_ANTICIPOS"
    DataGridViewCellStyle7.Format = "C0"
    DataGridViewCellStyle7.NullValue = Nothing
    Me.SALDOCARGOOTROSANTICIPOSDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
    Me.SALDOCARGOOTROSANTICIPOSDataGridViewTextBoxColumn.HeaderText = "Saldo cargo otros anticipos"
    Me.SALDOCARGOOTROSANTICIPOSDataGridViewTextBoxColumn.Name = "SALDOCARGOOTROSANTICIPOSDataGridViewTextBoxColumn"
    Me.SALDOCARGOOTROSANTICIPOSDataGridViewTextBoxColumn.ReadOnly = True
    '
    'COMPROBANTES
    '
    Me.COMPROBANTES.DataPropertyName = "COMPROBANTES"
    Me.COMPROBANTES.HeaderText = "COMPROBANTES"
    Me.COMPROBANTES.Name = "COMPROBANTES"
    Me.COMPROBANTES.ReadOnly = True
    '
    'días_Prima_Tec_mont_y_mante
    '
    Me.días_Prima_Tec_mont_y_mante.DataPropertyName = "días_Prima_Tec_mont_y_mante"
    Me.días_Prima_Tec_mont_y_mante.HeaderText = "Días_Prima_Tec_mont_y_mante"
    Me.días_Prima_Tec_mont_y_mante.Name = "días_Prima_Tec_mont_y_mante"
    Me.días_Prima_Tec_mont_y_mante.ReadOnly = True
    '
    'PrimaTecmontymanteDataGridViewTextBoxColumn
    '
    Me.PrimaTecmontymanteDataGridViewTextBoxColumn.DataPropertyName = "Prima_Tec_mont_y_mante"
    DataGridViewCellStyle8.Format = "C0"
    DataGridViewCellStyle8.NullValue = Nothing
    Me.PrimaTecmontymanteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
    Me.PrimaTecmontymanteDataGridViewTextBoxColumn.HeaderText = "Prima_Tec_mont_y_mante"
    Me.PrimaTecmontymanteDataGridViewTextBoxColumn.Name = "PrimaTecmontymanteDataGridViewTextBoxColumn"
    Me.PrimaTecmontymanteDataGridViewTextBoxColumn.ReadOnly = True
    '
    'Prima_Admin_y_Gestión
    '
    Me.Prima_Admin_y_Gestión.DataPropertyName = "Prima_Admin_y_Gestión"
    Me.Prima_Admin_y_Gestión.HeaderText = "Prima_Admin_y_Gestión"
    Me.Prima_Admin_y_Gestión.Name = "Prima_Admin_y_Gestión"
    '
    'días_Prima_Admin_y_Gestión
    '
    Me.días_Prima_Admin_y_Gestión.DataPropertyName = "días_Prima_Admin_y_Gestión"
    Me.días_Prima_Admin_y_Gestión.HeaderText = "días_Prima_Admin_y_Gestión"
    Me.días_Prima_Admin_y_Gestión.Name = "días_Prima_Admin_y_Gestión"
    '
    'PrimaTecdeperforacionDataGridViewTextBoxColumn
    '
    Me.PrimaTecdeperforacionDataGridViewTextBoxColumn.DataPropertyName = "Prima_Tec_de_perforacion"
    DataGridViewCellStyle9.Format = "C0"
    DataGridViewCellStyle9.NullValue = Nothing
    Me.PrimaTecdeperforacionDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
    Me.PrimaTecdeperforacionDataGridViewTextBoxColumn.HeaderText = "Prima_Tec_de_perforacion"
    Me.PrimaTecdeperforacionDataGridViewTextBoxColumn.Name = "PrimaTecdeperforacionDataGridViewTextBoxColumn"
    Me.PrimaTecdeperforacionDataGridViewTextBoxColumn.ReadOnly = True
    '
    'días_Prima_Tec_de_perforacion
    '
    Me.días_Prima_Tec_de_perforacion.DataPropertyName = "días_Prima_Tec_de_perforacion"
    Me.días_Prima_Tec_de_perforacion.HeaderText = "días_Prima_Tec_de_perforacion"
    Me.días_Prima_Tec_de_perforacion.Name = "días_Prima_Tec_de_perforacion"
    Me.días_Prima_Tec_de_perforacion.ReadOnly = True
    '
    'PrimaTecMTTOPozosDataGridViewTextBoxColumn
    '
    Me.PrimaTecMTTOPozosDataGridViewTextBoxColumn.DataPropertyName = "Prima_Tec_MTTO_Pozos"
    DataGridViewCellStyle10.Format = "C0"
    DataGridViewCellStyle10.NullValue = Nothing
    Me.PrimaTecMTTOPozosDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
    Me.PrimaTecMTTOPozosDataGridViewTextBoxColumn.HeaderText = "Prima_Tec_MTTO_Pozos"
    Me.PrimaTecMTTOPozosDataGridViewTextBoxColumn.Name = "PrimaTecMTTOPozosDataGridViewTextBoxColumn"
    Me.PrimaTecMTTOPozosDataGridViewTextBoxColumn.ReadOnly = True
    '
    'días_Prima_Tec_MTTO_Pozos
    '
    Me.días_Prima_Tec_MTTO_Pozos.DataPropertyName = "días_Prima_Tec_MTTO_Pozos"
    Me.días_Prima_Tec_MTTO_Pozos.HeaderText = "días_Prima_Tec_MTTO_Pozos"
    Me.días_Prima_Tec_MTTO_Pozos.Name = "días_Prima_Tec_MTTO_Pozos"
    Me.días_Prima_Tec_MTTO_Pozos.ReadOnly = True
    '
    'PrimaTecopecampetDataGridViewTextBoxColumn
    '
    Me.PrimaTecopecampetDataGridViewTextBoxColumn.DataPropertyName = "Prima_Tec_ope_cam_pet"
    DataGridViewCellStyle11.Format = "C0"
    DataGridViewCellStyle11.NullValue = Nothing
    Me.PrimaTecopecampetDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
    Me.PrimaTecopecampetDataGridViewTextBoxColumn.HeaderText = "Prima_Tec_ope_cam_pet"
    Me.PrimaTecopecampetDataGridViewTextBoxColumn.Name = "PrimaTecopecampetDataGridViewTextBoxColumn"
    Me.PrimaTecopecampetDataGridViewTextBoxColumn.ReadOnly = True
    '
    'días_Prima_Tec_ope_cam_pet
    '
    Me.días_Prima_Tec_ope_cam_pet.DataPropertyName = "días_Prima_Tec_ope_cam_pet"
    Me.días_Prima_Tec_ope_cam_pet.HeaderText = "días_Prima_Tec_ope_cam_pet"
    Me.días_Prima_Tec_ope_cam_pet.Name = "días_Prima_Tec_ope_cam_pet"
    Me.días_Prima_Tec_ope_cam_pet.ReadOnly = True
    '
    'BonoCampamentoDataGridViewTextBoxColumn
    '
    Me.BonoCampamentoDataGridViewTextBoxColumn.DataPropertyName = "Bono_Campamento"
    DataGridViewCellStyle12.Format = "C0"
    DataGridViewCellStyle12.NullValue = Nothing
    Me.BonoCampamentoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
    Me.BonoCampamentoDataGridViewTextBoxColumn.HeaderText = "Bono_Campamento"
    Me.BonoCampamentoDataGridViewTextBoxColumn.Name = "BonoCampamentoDataGridViewTextBoxColumn"
    Me.BonoCampamentoDataGridViewTextBoxColumn.ReadOnly = True
    '
    'días_Bono_Campamento
    '
    Me.días_Bono_Campamento.DataPropertyName = "días_Bono_Campamento"
    Me.días_Bono_Campamento.HeaderText = "días_Bono_Campamento"
    Me.días_Bono_Campamento.Name = "días_Bono_Campamento"
    Me.días_Bono_Campamento.ReadOnly = True
    '
    'BonoHorasdevueloDataGridViewTextBoxColumn
    '
    Me.BonoHorasdevueloDataGridViewTextBoxColumn.DataPropertyName = "Bono_Horas_de_vuelo"
    DataGridViewCellStyle13.Format = "C0"
    DataGridViewCellStyle13.NullValue = Nothing
    Me.BonoHorasdevueloDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle13
    Me.BonoHorasdevueloDataGridViewTextBoxColumn.HeaderText = "Bono_Horas_de_vuelo"
    Me.BonoHorasdevueloDataGridViewTextBoxColumn.Name = "BonoHorasdevueloDataGridViewTextBoxColumn"
    Me.BonoHorasdevueloDataGridViewTextBoxColumn.ReadOnly = True
    '
    'días_Bono_Horas_de_vuelo
    '
    Me.días_Bono_Horas_de_vuelo.DataPropertyName = "días_Bono_Horas_de_vuelo"
    Me.días_Bono_Horas_de_vuelo.HeaderText = "días_Bono_Horas_de_vuelo"
    Me.días_Bono_Horas_de_vuelo.Name = "días_Bono_Horas_de_vuelo"
    Me.días_Bono_Horas_de_vuelo.ReadOnly = True
    '
    'AlquilerHerramientasDataGridViewTextBoxColumn
    '
    Me.AlquilerHerramientasDataGridViewTextBoxColumn.DataPropertyName = "Alquiler_Herramientas"
    DataGridViewCellStyle14.Format = "C0"
    DataGridViewCellStyle14.NullValue = Nothing
    Me.AlquilerHerramientasDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle14
    Me.AlquilerHerramientasDataGridViewTextBoxColumn.HeaderText = "Alquiler_Herramientas"
    Me.AlquilerHerramientasDataGridViewTextBoxColumn.Name = "AlquilerHerramientasDataGridViewTextBoxColumn"
    Me.AlquilerHerramientasDataGridViewTextBoxColumn.ReadOnly = True
    '
    'días_Alquiler_Herramientas
    '
    Me.días_Alquiler_Herramientas.DataPropertyName = "días_Alquiler_Herramientas"
    Me.días_Alquiler_Herramientas.HeaderText = "días_Alquiler_Herramientas"
    Me.días_Alquiler_Herramientas.Name = "días_Alquiler_Herramientas"
    Me.días_Alquiler_Herramientas.ReadOnly = True
    '
    'TiquetesEmplVenTEspDataGridViewTextBoxColumn
    '
    Me.TiquetesEmplVenTEspDataGridViewTextBoxColumn.DataPropertyName = "Tiquetes_Empl_Ven_T_Esp"
    DataGridViewCellStyle15.Format = "C0"
    DataGridViewCellStyle15.NullValue = Nothing
    Me.TiquetesEmplVenTEspDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle15
    Me.TiquetesEmplVenTEspDataGridViewTextBoxColumn.HeaderText = "Tiquetes_Empl_Ven_T_Esp"
    Me.TiquetesEmplVenTEspDataGridViewTextBoxColumn.Name = "TiquetesEmplVenTEspDataGridViewTextBoxColumn"
    Me.TiquetesEmplVenTEspDataGridViewTextBoxColumn.ReadOnly = True
    '
    'días_Tiquetes_Empl_Ven_T_Esp
    '
    Me.días_Tiquetes_Empl_Ven_T_Esp.DataPropertyName = "días_Tiquetes_Empl_Ven_T_Esp"
    Me.días_Tiquetes_Empl_Ven_T_Esp.HeaderText = "días_Tiquetes_Empl_Ven_T_Esp"
    Me.días_Tiquetes_Empl_Ven_T_Esp.Name = "días_Tiquetes_Empl_Ven_T_Esp"
    Me.días_Tiquetes_Empl_Ven_T_Esp.ReadOnly = True
    '
    'CODIGOSUBCENTROCOSTO
    '
    Me.CODIGOSUBCENTROCOSTO.DataPropertyName = "CODIGOSUBCENTROCOSTO"
    Me.CODIGOSUBCENTROCOSTO.HeaderText = "Codigo"
    Me.CODIGOSUBCENTROCOSTO.Name = "CODIGOSUBCENTROCOSTO"
    '
    'NOMBRESUBCENTROCOSTOS
    '
    Me.NOMBRESUBCENTROCOSTOS.DataPropertyName = "NOMBRESUBCENTROCOSTOS"
    Me.NOMBRESUBCENTROCOSTOS.HeaderText = "Sub Centro de costos"
    Me.NOMBRESUBCENTROCOSTOS.Name = "NOMBRESUBCENTROCOSTOS"
    Me.NOMBRESUBCENTROCOSTOS.Visible = False
    '
    'Fr_InformeLegalizacion
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1160, 562)
    Me.Controls.Add(Me.Dgv_InformeLegalizaicon)
    Me.Controls.Add(Me.Panel1)
    Me.Name = "Fr_InformeLegalizacion"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Informe Legalización"
    CType(Me.Dgv_InformeLegalizaicon, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    CType(Me.BindingSourceInformeLegalizacion, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Ds_Auditoria, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Dgv_InformeLegalizaicon As System.Windows.Forms.DataGridView
    Friend WithEvents Ds_Auditoria As DatosAuditoria.Ds_Auditoria
    Friend WithEvents BindingSourceInformeLegalizacion As System.Windows.Forms.BindingSource
    Friend WithEvents InformeAuditoriaMaestroTableAdapter As DatosAuditoria.Ds_AuditoriaTableAdapters.InformeAuditoriaMaestroTableAdapter
    Friend WithEvents Btn_ExportarExcel_Informe As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
  Friend WithEvents ConsecutivoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents IdentificaciónDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents NombreDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents EstadoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TIPOLEGALIZACION As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents NOMBRECENTROCOSTOS As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ViaticoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents VALORALIMENTACION As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents VALORALOJAMIENTO As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents VALORINCIDENTAL As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SALDOFAVORDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SALDOCARGODataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SALDOFAVOROTROSANTICIPOSDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SALDOCARGOOTROSANTICIPOSDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents COMPROBANTES As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents días_Prima_Tec_mont_y_mante As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents PrimaTecmontymanteDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Prima_Admin_y_Gestión As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents días_Prima_Admin_y_Gestión As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents PrimaTecdeperforacionDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents días_Prima_Tec_de_perforacion As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents PrimaTecMTTOPozosDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents días_Prima_Tec_MTTO_Pozos As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents PrimaTecopecampetDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents días_Prima_Tec_ope_cam_pet As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents BonoCampamentoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents días_Bono_Campamento As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents BonoHorasdevueloDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents días_Bono_Horas_de_vuelo As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents AlquilerHerramientasDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents días_Alquiler_Herramientas As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TiquetesEmplVenTEspDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents días_Tiquetes_Empl_Ven_T_Esp As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents CODIGOSUBCENTROCOSTO As Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents NOMBRESUBCENTROCOSTOS As Windows.Forms.DataGridViewTextBoxColumn
End Class
