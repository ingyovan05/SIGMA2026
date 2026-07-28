<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ExamenMedicoPeriodico
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
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.TP_ImpresionDiagnostica = New System.Windows.Forms.TabPage()
        Me.Dgv_ImpresionDiagnosticaFinal = New System.Windows.Forms.DataGridView()
        Me.DGVT_IDENFERMEDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_CODIGOENFERMEDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_NOMBREENFERMEDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_ImpresionDiagnostica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_ImpresionDiagnosticaFinal = New System.Windows.Forms.Panel()
        Me.Bt_AgregarImpresionDiagnosticaFinal = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Gb_ComentariosFinales = New System.Windows.Forms.GroupBox()
        Me.Tb_ComentariosFinales = New System.Windows.Forms.TextBox()
        Me.Gb_EstudiosFinales = New System.Windows.Forms.GroupBox()
        Me.Tb_EstudiosFinales = New System.Windows.Forms.TextBox()
        Me.TP_ExamenAuditivo = New System.Windows.Forms.TabPage()
        Me.Gb_Auditivo = New System.Windows.Forms.GroupBox()
        Me.Tb_Detalle025 = New System.Windows.Forms.TextBox()
        Me.Cb_ViaComprometida025 = New System.Windows.Forms.ComboBox()
        Me.Num_OD_025 = New System.Windows.Forms.NumericUpDown()
        Me.Num_OI_025 = New System.Windows.Forms.NumericUpDown()
        Me.Tb_Detalle05 = New System.Windows.Forms.TextBox()
        Me.Cb_ViaComprometida05 = New System.Windows.Forms.ComboBox()
        Me.Num_OD_05 = New System.Windows.Forms.NumericUpDown()
        Me.Num_OI_05 = New System.Windows.Forms.NumericUpDown()
        Me.Tb_Detalle1000 = New System.Windows.Forms.TextBox()
        Me.Cb_ViaComprometida1000 = New System.Windows.Forms.ComboBox()
        Me.Num_OD_1000 = New System.Windows.Forms.NumericUpDown()
        Me.Num_OI_1000 = New System.Windows.Forms.NumericUpDown()
        Me.Tb_Detalle2000 = New System.Windows.Forms.TextBox()
        Me.Cb_ViaComprometida2000 = New System.Windows.Forms.ComboBox()
        Me.Num_OD_2000 = New System.Windows.Forms.NumericUpDown()
        Me.Num_OI_2000 = New System.Windows.Forms.NumericUpDown()
        Me.Tb_Detalle3000 = New System.Windows.Forms.TextBox()
        Me.Cb_ViaComprometida3000 = New System.Windows.Forms.ComboBox()
        Me.Num_OD_3000 = New System.Windows.Forms.NumericUpDown()
        Me.Num_OI_3000 = New System.Windows.Forms.NumericUpDown()
        Me.Tb_Detalle6000 = New System.Windows.Forms.TextBox()
        Me.Cb_ViaComprometida6000 = New System.Windows.Forms.ComboBox()
        Me.Num_OD_6000 = New System.Windows.Forms.NumericUpDown()
        Me.Num_OI_6000 = New System.Windows.Forms.NumericUpDown()
        Me.Tb_Detalle8000 = New System.Windows.Forms.TextBox()
        Me.Cb_ViaComprometida8000 = New System.Windows.Forms.ComboBox()
        Me.Num_OD_8000 = New System.Windows.Forms.NumericUpDown()
        Me.Num_OI_8000 = New System.Windows.Forms.NumericUpDown()
        Me.Lb_Detalle = New System.Windows.Forms.Label()
        Me.Lb_ViaComprometida = New System.Windows.Forms.Label()
        Me.Lb_OD = New System.Windows.Forms.Label()
        Me.Lb_OI = New System.Windows.Forms.Label()
        Me.Lb_025 = New System.Windows.Forms.Label()
        Me.Lb_6000 = New System.Windows.Forms.Label()
        Me.Lb_3000 = New System.Windows.Forms.Label()
        Me.Lb_2000 = New System.Windows.Forms.Label()
        Me.Lb_1000 = New System.Windows.Forms.Label()
        Me.Lb_05 = New System.Windows.Forms.Label()
        Me.Lb_8000 = New System.Windows.Forms.Label()
        Me.TP_ExamenFisico5 = New System.Windows.Forms.TabPage()
        Me.Gb_Laboratorios = New System.Windows.Forms.GroupBox()
        Me.Rb_NoExComplementario = New System.Windows.Forms.RadioButton()
        Me.Rb_SiExComplementario = New System.Windows.Forms.RadioButton()
        Me.Gb_ValoracionAuditiva = New System.Windows.Forms.GroupBox()
        Me.Rb_AuditivaNo = New System.Windows.Forms.RadioButton()
        Me.Rb_AuditivaSi = New System.Windows.Forms.RadioButton()
        Me.Gb_MiembrosInferiores2 = New System.Windows.Forms.GroupBox()
        Me.Gb_ComentariosMiembrosInferiores = New System.Windows.Forms.GroupBox()
        Me.Tb_ComentariosMiembrosInferiores = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Tb_Marcha = New System.Windows.Forms.TextBox()
        Me.Lb_Marcha = New System.Windows.Forms.Label()
        Me.Tb_FaseBalanceoPieIzquierdo = New System.Windows.Forms.TextBox()
        Me.Lb_MarchaPieIzquierdo = New System.Windows.Forms.Label()
        Me.Tb_FaseApoyoPieIzquierdo = New System.Windows.Forms.TextBox()
        Me.Lb_MarchaPieDerecho = New System.Windows.Forms.Label()
        Me.Tb_FaseBalanceoPieDerecho = New System.Windows.Forms.TextBox()
        Me.Lb_FaseBalanceo = New System.Windows.Forms.Label()
        Me.Tb_FaseApoyoPieDerecho = New System.Windows.Forms.TextBox()
        Me.Lb_FaseApoyo = New System.Windows.Forms.Label()
        Me.Gb_Pies = New System.Windows.Forms.GroupBox()
        Me.Tb_PieIzquierdo = New System.Windows.Forms.TextBox()
        Me.Lb_PieIzquierdo = New System.Windows.Forms.Label()
        Me.Tb_PieDerecho = New System.Windows.Forms.TextBox()
        Me.Lb_PieDerecho = New System.Windows.Forms.Label()
        Me.Gb_Tobillos = New System.Windows.Forms.GroupBox()
        Me.Tb_TobilloIzquierdo = New System.Windows.Forms.TextBox()
        Me.Lb_TobilloIzquierdo = New System.Windows.Forms.Label()
        Me.Tb_TobilloDerecho = New System.Windows.Forms.TextBox()
        Me.Lb_TobilloDerecho = New System.Windows.Forms.Label()
        Me.TP_ExamenFisico4 = New System.Windows.Forms.TabPage()
        Me.Gb_MiembrosInferiores = New System.Windows.Forms.GroupBox()
        Me.Gb_Rodillas = New System.Windows.Forms.GroupBox()
        Me.Tb_RodillaIzquierda = New System.Windows.Forms.TextBox()
        Me.Lb_RodillaIzquierda = New System.Windows.Forms.Label()
        Me.Tb_RodillaDerecha = New System.Windows.Forms.TextBox()
        Me.Lb_RodillaDerecha = New System.Windows.Forms.Label()
        Me.Gb_Caderas = New System.Windows.Forms.GroupBox()
        Me.Tb_CaderasIzquierda = New System.Windows.Forms.TextBox()
        Me.Lb_CaderasIzquierda = New System.Windows.Forms.Label()
        Me.Tb_CaderasDerecha = New System.Windows.Forms.TextBox()
        Me.Lb_CaderasDerecha = New System.Windows.Forms.Label()
        Me.Gb_ValoracionMiembrosSuperiores3 = New System.Windows.Forms.GroupBox()
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores = New System.Windows.Forms.GroupBox()
        Me.Tb_ComentariosMiembrosSuperiores = New System.Windows.Forms.TextBox()
        Me.Gb_DedosManoIzquierda = New System.Windows.Forms.GroupBox()
        Me.Tb_DedoIzquierdo5 = New System.Windows.Forms.TextBox()
        Me.Lb_DedoIzquierdo5 = New System.Windows.Forms.Label()
        Me.Tb_DedoIzquierdo4 = New System.Windows.Forms.TextBox()
        Me.Lb_DedoIzquierdo4 = New System.Windows.Forms.Label()
        Me.Tb_DedoIzquierdo3 = New System.Windows.Forms.TextBox()
        Me.Lb_DedoIzquierdo3 = New System.Windows.Forms.Label()
        Me.Tb_DedoIzquierdo2 = New System.Windows.Forms.TextBox()
        Me.Lb_DedoIzquierdo2 = New System.Windows.Forms.Label()
        Me.Tb_DedoIzquierdo1 = New System.Windows.Forms.TextBox()
        Me.Lb_DedoIzquierdo1 = New System.Windows.Forms.Label()
        Me.TP_ExamenFisico3 = New System.Windows.Forms.TabPage()
        Me.Gb_ValoracionMiembrosSuperiores2 = New System.Windows.Forms.GroupBox()
        Me.Gb_DedosManoDerecha = New System.Windows.Forms.GroupBox()
        Me.Tb_DedoDerecho5 = New System.Windows.Forms.TextBox()
        Me.Lb_DedoDerecho5 = New System.Windows.Forms.Label()
        Me.Tb_DedoDerecho4 = New System.Windows.Forms.TextBox()
        Me.Lb_DedoDerecho4 = New System.Windows.Forms.Label()
        Me.Tb_DedoDerecho3 = New System.Windows.Forms.TextBox()
        Me.Lb_DedoDerecho3 = New System.Windows.Forms.Label()
        Me.Tb_DedoDerecho2 = New System.Windows.Forms.TextBox()
        Me._DedoDerecho2 = New System.Windows.Forms.Label()
        Me.Tb_DedoDerecho1 = New System.Windows.Forms.TextBox()
        Me.Lb_DedoDerecho1 = New System.Windows.Forms.Label()
        Me.Gb_Manos = New System.Windows.Forms.GroupBox()
        Me.Tb_ManoIzquierda = New System.Windows.Forms.TextBox()
        Me.Lb_ManoIzquierda = New System.Windows.Forms.Label()
        Me.Tb_ManoDerecha = New System.Windows.Forms.TextBox()
        Me.Lb_ManoDerecha = New System.Windows.Forms.Label()
        Me.Gb_Muñecas = New System.Windows.Forms.GroupBox()
        Me.Tb_MuñecaIzquierda = New System.Windows.Forms.TextBox()
        Me.Lb_MuñecaIzquierda = New System.Windows.Forms.Label()
        Me.Tb_MuñecaDerecha = New System.Windows.Forms.TextBox()
        Me.Lb_MuñecaDerecha = New System.Windows.Forms.Label()
        Me.Gb_Codos = New System.Windows.Forms.GroupBox()
        Me.Tb_CodoIzquierdo = New System.Windows.Forms.TextBox()
        Me.Lb_CodoIzquierdo = New System.Windows.Forms.Label()
        Me.Tb_CodoDerecho = New System.Windows.Forms.TextBox()
        Me.Lb_CodoDerecho = New System.Windows.Forms.Label()
        Me.Gb_Hombros = New System.Windows.Forms.GroupBox()
        Me.Tb_HombroIzquierdo = New System.Windows.Forms.TextBox()
        Me.Lb_HombroIzquierdo = New System.Windows.Forms.Label()
        Me.Tb_HombroDerecho = New System.Windows.Forms.TextBox()
        Me.Lb_HombroDerecho = New System.Windows.Forms.Label()
        Me.Tb_FlexoExtension = New System.Windows.Forms.TextBox()
        Me.Lb_FlexoExtension = New System.Windows.Forms.Label()
        Me.Tb_RotacionExterna = New System.Windows.Forms.TextBox()
        Me.Lb_RotacionExterna = New System.Windows.Forms.Label()
        Me.TP_ExamenFisico2 = New System.Windows.Forms.TabPage()
        Me.Gb_ValoracionMiembrosSuperiores = New System.Windows.Forms.GroupBox()
        Me.Tb_Aduccion = New System.Windows.Forms.TextBox()
        Me.Lb_Aduccion = New System.Windows.Forms.Label()
        Me.Tb_AbduccionElevacion = New System.Windows.Forms.TextBox()
        Me.Lb_AbduccionElevacion = New System.Windows.Forms.Label()
        Me.Tb_Circunduccion = New System.Windows.Forms.TextBox()
        Me.Lb_Circunduccion = New System.Windows.Forms.Label()
        Me.Tb_EjeLongitudinal = New System.Windows.Forms.TextBox()
        Me.Lb_EjeLongitudinal = New System.Windows.Forms.Label()
        Me.Tb_EjeTransversal = New System.Windows.Forms.TextBox()
        Me.Lb_EjeTransversal = New System.Windows.Forms.Label()
        Me.Tb_EjeAnteroposterior = New System.Windows.Forms.TextBox()
        Me.Lb_EjeAnteroposterior = New System.Windows.Forms.Label()
        Me.Tb_Subdeltoidea = New System.Windows.Forms.TextBox()
        Me.Lb_ArtSubdeltoidea = New System.Windows.Forms.Label()
        Me.Tb_ArtEscapulotorácica = New System.Windows.Forms.TextBox()
        Me.Lb_ArtEscapulotorácica = New System.Windows.Forms.Label()
        Me.Tb_ArtAcromioclavicular = New System.Windows.Forms.TextBox()
        Me.Lb_ArtAcromioclavicular = New System.Windows.Forms.Label()
        Me.Tb_ArtEscapulohumeral = New System.Windows.Forms.TextBox()
        Me.Lb_ArtEscapulohumeral = New System.Windows.Forms.Label()
        Me.Gb_ExamenColumna2 = New System.Windows.Forms.GroupBox()
        Me.Gb_TestWells = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Rb_MuyPobre = New System.Windows.Forms.RadioButton()
        Me.Rb_Pobre = New System.Windows.Forms.RadioButton()
        Me.Rb_Deficiente = New System.Windows.Forms.RadioButton()
        Me.Rb_Promedio = New System.Windows.Forms.RadioButton()
        Me.Rb_Bueno = New System.Windows.Forms.RadioButton()
        Me.Rb_Excelente = New System.Windows.Forms.RadioButton()
        Me.Rb_Superior = New System.Windows.Forms.RadioButton()
        Me.Gb_SignoLasegue = New System.Windows.Forms.GroupBox()
        Me.Rb_Negativo = New System.Windows.Forms.RadioButton()
        Me.Rb_Positivo = New System.Windows.Forms.RadioButton()
        Me.Tb_Lasegue = New System.Windows.Forms.TextBox()
        Me.Gb_TestSchober = New System.Windows.Forms.GroupBox()
        Me.Rb_Menor5cm = New System.Windows.Forms.RadioButton()
        Me.Rb_Mayor5cm = New System.Windows.Forms.RadioButton()
        Me.TP_ExamenFisico1 = New System.Windows.Forms.TabPage()
        Me.Gb_ExamenColumna = New System.Windows.Forms.GroupBox()
        Me.Gb_Movilidad = New System.Windows.Forms.GroupBox()
        Me.Tb_Rotacion = New System.Windows.Forms.TextBox()
        Me.Lb_Rotacion = New System.Windows.Forms.Label()
        Me.Tb_FlexionLateral = New System.Windows.Forms.TextBox()
        Me.Lb_FlexionLateral = New System.Windows.Forms.Label()
        Me.Tb_Extension = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tb_Flexion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Gb_Palpacion = New System.Windows.Forms.GroupBox()
        Me.Tb_Espasmo = New System.Windows.Forms.TextBox()
        Me.Lb_Espasmo = New System.Windows.Forms.Label()
        Me.Tb_Dolor = New System.Windows.Forms.TextBox()
        Me.Lb_Dolor = New System.Windows.Forms.Label()
        Me.Gb_Inspeccion = New System.Windows.Forms.GroupBox()
        Me.Tb_Curvatura = New System.Windows.Forms.TextBox()
        Me.Lb_Curvatura = New System.Windows.Forms.Label()
        Me.Tb_Simetria = New System.Windows.Forms.TextBox()
        Me.Lb_Simetria = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Tb_EvidenciasClinicas = New System.Windows.Forms.TextBox()
        Me.Gb_SignosVitales = New System.Windows.Forms.GroupBox()
        Me.Num_PerimetroAbdomen = New System.Windows.Forms.NumericUpDown()
        Me.Num_SO2 = New System.Windows.Forms.NumericUpDown()
        Me.Num_FR = New System.Windows.Forms.NumericUpDown()
        Me.Num_FC = New System.Windows.Forms.NumericUpDown()
        Me.Num_TaDiast = New System.Windows.Forms.NumericUpDown()
        Me.Num_TaSist = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tb_IMC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tb_Talla = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tb_Peso = New System.Windows.Forms.TextBox()
        Me.Lb_Peso = New System.Windows.Forms.Label()
        Me.Lb_SO2 = New System.Windows.Forms.Label()
        Me.Lb_FR = New System.Windows.Forms.Label()
        Me.Lb_FC = New System.Windows.Forms.Label()
        Me.Lb_TaDiast = New System.Windows.Forms.Label()
        Me.Lb_TaSist = New System.Windows.Forms.Label()
        Me.TP_AntecedentesPatologicos = New System.Windows.Forms.TabPage()
        Me.Gb_RevisionSistemas = New System.Windows.Forms.GroupBox()
        Me.Tb_RevisionSistemas = New System.Windows.Forms.TextBox()
        Me.Dgv_Habitos = New System.Windows.Forms.DataGridView()
        Me.DGVC_Habitos = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVCB_Aplica = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVCT_NumTiempo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_TIEMPO = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVC_FrecuenciaHabitos = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVC_Intensidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_AbandonoHabito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_Habitos = New System.Windows.Forms.Panel()
        Me.Bt_AgregarHabito = New System.Windows.Forms.Button()
        Me.Lb_Habitos = New System.Windows.Forms.Label()
        Me.Dgv_Antecedentes = New System.Windows.Forms.DataGridView()
        Me.DGVC_Antecedentes = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVC_DescripcionAntecedentes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_Antecedentes = New System.Windows.Forms.Panel()
        Me.Bt_AgregarAntecedente = New System.Windows.Forms.Button()
        Me.Lb_Antecedentes = New System.Windows.Forms.Label()
        Me.TP_Antecedentes = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarEnfermedades = New System.Windows.Forms.Button()
        Me.Lb_Enfermedades = New System.Windows.Forms.Label()
        Me.Dgv_Enfermedades = New System.Windows.Forms.DataGridView()
        Me.DGTB_IDENFERMEDADANTECEDENTES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGTB_CODIGOENFERMEDADANTECEDENTES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_Enfermedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_OrigenEnfermedad = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVC_SecuelaEnfermedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_TIPODGVENFERMEDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dgv_Accidente = New System.Windows.Forms.DataGridView()
        Me.DGVT_IdDgvAccidente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_CodigoDgvAccidente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_Accidente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_OrigenAccidente = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVT_SecuelaAccidente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_TIPOACCIDENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarAccidente = New System.Windows.Forms.Button()
        Me.Lb_Accidente = New System.Windows.Forms.Label()
        Me.TP_DescripcionCargo = New System.Windows.Forms.TabPage()
        Me.Dgv_AntecedenteLaborales = New System.Windows.Forms.DataGridView()
        Me.DGVT_NroItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_NOMBREEMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_TiempoTrabajadoMeses = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_TiempoTrabajadoAños = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_ARL = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVCK_Incapacidad = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DGVC_Origen = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVT_DiasIncapacidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_Secuela = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_Jornada = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVT_Turno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_Cargo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Bt_Riesgos = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Dgv_Higiene = New System.Windows.Forms.DataGridView()
        Me.DGVC_HigieneIndustrial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_TLVs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_Alteracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_OrganoBlanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_Efecto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarHigieneIndustrial = New System.Windows.Forms.Button()
        Me.Lb_HigieneIndustrial = New System.Windows.Forms.Label()
        Me.Dgv_Tareas = New System.Windows.Forms.DataGridView()
        Me.DGVT_Tarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_Agente = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVC_Magnitud = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVT_Frecuencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarTarea = New System.Windows.Forms.Button()
        Me.Lb_Tarea = New System.Windows.Forms.Label()
        Me.TP_DatosPersonales = New System.Windows.Forms.TabPage()
        Me.Gb_TipoExamen = New System.Windows.Forms.GroupBox()
        Me.Rb_ExamenPeriodico = New System.Windows.Forms.RadioButton()
        Me.Rb_ExamenEgreso = New System.Windows.Forms.RadioButton()
        Me.Rb_ExamenIngreso = New System.Windows.Forms.RadioButton()
        Me.Gb_DatosPersonales = New System.Windows.Forms.GroupBox()
        Me.Lb_MunicipioContrato = New System.Windows.Forms.Label()
        Me.Gb_Riesgo = New System.Windows.Forms.GroupBox()
        Me.Cb_Locativo = New System.Windows.Forms.CheckBox()
        Me.Cb_Natural = New System.Windows.Forms.CheckBox()
        Me.Cb_Quimico = New System.Windows.Forms.CheckBox()
        Me.Cb_Fisico = New System.Windows.Forms.CheckBox()
        Me.Cb_Seguridad = New System.Windows.Forms.CheckBox()
        Me.Cb_Biológico = New System.Windows.Forms.CheckBox()
        Me.Cb_Psicosocial = New System.Windows.Forms.CheckBox()
        Me.Cb_Biomecanico = New System.Windows.Forms.CheckBox()
        Me.Cb_TipoCargo = New System.Windows.Forms.ComboBox()
        Me.Cb_Cargo = New System.Windows.Forms.ComboBox()
        Me.Num_Turnos = New System.Windows.Forms.NumericUpDown()
        Me.Cb_EPS = New System.Windows.Forms.ComboBox()
        Me.Lb_EPS = New System.Windows.Forms.Label()
        Me.Cb_AFP = New System.Windows.Forms.ComboBox()
        Me.Lb_FondoPensiones = New System.Windows.Forms.Label()
        Me.Cb_GrupoSanguineo = New System.Windows.Forms.ComboBox()
        Me.Lb_TipoSangre = New System.Windows.Forms.Label()
        Me.Lb_Turnos = New System.Windows.Forms.Label()
        Me.Cb_Jornada = New System.Windows.Forms.ComboBox()
        Me.Lb_Jornada = New System.Windows.Forms.Label()
        Me.Num_CargoMeses = New System.Windows.Forms.NumericUpDown()
        Me.Lb_TiempoCargoMeses = New System.Windows.Forms.Label()
        Me.Num_CargoAños = New System.Windows.Forms.NumericUpDown()
        Me.Lb_TiempoCargoAños = New System.Windows.Forms.Label()
        Me.Dtp_FechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaIngreso = New System.Windows.Forms.Label()
        Me.Lb_TipoCargo = New System.Windows.Forms.Label()
        Me.Lb_Cargo = New System.Windows.Forms.Label()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Lb_Dependencia = New System.Windows.Forms.Label()
        Me.Cb_Base = New System.Windows.Forms.ComboBox()
        Me.Lb_Base = New System.Windows.Forms.Label()
        Me.Cb_Proyecto = New System.Windows.Forms.ComboBox()
        Me.Lb_Proyecto = New System.Windows.Forms.Label()
        Me.Cb_Dominancia = New System.Windows.Forms.ComboBox()
        Me.Lb_Dominancia = New System.Windows.Forms.Label()
        Me.Cb_EstadoCivil = New System.Windows.Forms.ComboBox()
        Me.Lb_EstadoCivil = New System.Windows.Forms.Label()
        Me.Cb_NivelAcademico = New System.Windows.Forms.ComboBox()
        Me.Lb_NivelAcademico = New System.Windows.Forms.Label()
        Me.Tb_Edad = New System.Windows.Forms.TextBox()
        Me.Gb_Genero = New System.Windows.Forms.GroupBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Rb_Femenino = New System.Windows.Forms.RadioButton()
        Me.Rb_Masculino = New System.Windows.Forms.RadioButton()
        Me.Lb_Edad = New System.Windows.Forms.Label()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.TC_ExamenMedicoPeriodico = New System.Windows.Forms.TabControl()
        Me.TP_ExamenComplementario = New System.Windows.Forms.TabPage()
        Me.Gb_ExamenesComplementarios = New System.Windows.Forms.GroupBox()
        Me.Lb_ObsFR = New System.Windows.Forms.Label()
        Me.Lb_ObsGlicemia = New System.Windows.Forms.Label()
        Me.Gb_FuncionHepatica = New System.Windows.Forms.GroupBox()
        Me.Lb_ObsFH = New System.Windows.Forms.Label()
        Me.Lb_ALT = New System.Windows.Forms.Label()
        Me.Tb_FuncionHepaticaALT = New System.Windows.Forms.TextBox()
        Me.Lb_AST = New System.Windows.Forms.Label()
        Me.Tb_FuncionHepaticaAST = New System.Windows.Forms.TextBox()
        Me.Tb_FuncionHepaticaConcepto = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Tb_EKGConclusion = New System.Windows.Forms.TextBox()
        Me.Tb_FuncionRenalConcepto = New System.Windows.Forms.TextBox()
        Me.Tb_GlicemiaConcepto = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Tb_ImagenesDiagnosticas = New System.Windows.Forms.TextBox()
        Me.Tb_Glicemia = New System.Windows.Forms.TextBox()
        Me.Gb_Visiometria = New System.Windows.Forms.GroupBox()
        Me.Tb_OtrasAlteracionesVisuales = New System.Windows.Forms.TextBox()
        Me.Lb_OtrasAlt = New System.Windows.Forms.Label()
        Me.Ck_VConjuntiva = New System.Windows.Forms.CheckBox()
        Me.Ck_VParpados = New System.Windows.Forms.CheckBox()
        Me.Ck_VMovilidad = New System.Windows.Forms.CheckBox()
        Me.Ck_VLejos = New System.Windows.Forms.CheckBox()
        Me.Ck_VCerca = New System.Windows.Forms.CheckBox()
        Me.Ck_VNormal = New System.Windows.Forms.CheckBox()
        Me.Gb_Psicofarmacos = New System.Windows.Forms.GroupBox()
        Me.Ck_PsCocaina = New System.Windows.Forms.CheckBox()
        Me.Ck_PsMarihuana = New System.Windows.Forms.CheckBox()
        Me.Ck_PsNegativo = New System.Windows.Forms.CheckBox()
        Me.Tb_FuncionRenal = New System.Windows.Forms.TextBox()
        Me.Gb_ParcialOrina = New System.Windows.Forms.GroupBox()
        Me.Ck_POCreatinuria = New System.Windows.Forms.CheckBox()
        Me.Ck_POEritocitocis = New System.Windows.Forms.CheckBox()
        Me.Ck_POAlbumina = New System.Windows.Forms.CheckBox()
        Me.Ck_POSangre = New System.Windows.Forms.CheckBox()
        Me.Ck_POCalcio = New System.Windows.Forms.CheckBox()
        Me.Ck_POGlucosuria = New System.Windows.Forms.CheckBox()
        Me.Ck_POProteinura = New System.Windows.Forms.CheckBox()
        Me.Ck_POBacterias = New System.Windows.Forms.CheckBox()
        Me.Ck_PONormal = New System.Windows.Forms.CheckBox()
        Me.Gb_Quimica = New System.Windows.Forms.GroupBox()
        Me.Tb_Quimica = New System.Windows.Forms.TextBox()
        Me.Tb_HDL = New System.Windows.Forms.TextBox()
        Me.Lb_ObsQuimica = New System.Windows.Forms.Label()
        Me.Lb_HDL = New System.Windows.Forms.Label()
        Me.Tb_LDL = New System.Windows.Forms.TextBox()
        Me.Lb_LDL = New System.Windows.Forms.Label()
        Me.Tb_Colesterol = New System.Windows.Forms.TextBox()
        Me.Lb_Colesterol = New System.Windows.Forms.Label()
        Me.Tb_Triglicerios = New System.Windows.Forms.TextBox()
        Me.Lb_Triglicerios = New System.Windows.Forms.Label()
        Me.Gb_CuadroHematico = New System.Windows.Forms.GroupBox()
        Me.Tb_CuadroHematico = New System.Windows.Forms.TextBox()
        Me.Lb_ObsCH = New System.Windows.Forms.Label()
        Me.Tb_Plaquetas = New System.Windows.Forms.TextBox()
        Me.Lb_Plaquetas = New System.Windows.Forms.Label()
        Me.Tb_LineaBlanca = New System.Windows.Forms.TextBox()
        Me.Lb_LineaBlanca = New System.Windows.Forms.Label()
        Me.Tb_LineaRoja = New System.Windows.Forms.TextBox()
        Me.Lb_LineaRoja = New System.Windows.Forms.Label()
        Me.Cb_EKG = New System.Windows.Forms.ComboBox()
        Me.Cb_Espirometria = New System.Windows.Forms.ComboBox()
        Me.Lb_Glicemia = New System.Windows.Forms.Label()
        Me.Cb_Audiometria = New System.Windows.Forms.ComboBox()
        Me.Lb_FuncionRenal = New System.Windows.Forms.Label()
        Me.Lb_Audiometria = New System.Windows.Forms.Label()
        Me.Lb_Espirometría = New System.Windows.Forms.Label()
        Me.Lb_EKG = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Cu_CiudadContrato = New FormulariosClasesBase.Cu_Ciudad()
        Me.Cu_AsociarPersonaReporte = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaExamenMedico = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_Vacuna1 = New FormulariosClasesBase.Cu_Vacuna()
        Me.Pn_Botones.SuspendLayout()
        Me.TP_ImpresionDiagnostica.SuspendLayout()
        CType(Me.Dgv_ImpresionDiagnosticaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_ImpresionDiagnosticaFinal.SuspendLayout()
        Me.Gb_ComentariosFinales.SuspendLayout()
        Me.Gb_EstudiosFinales.SuspendLayout()
        Me.TP_ExamenAuditivo.SuspendLayout()
        Me.Gb_Auditivo.SuspendLayout()
        CType(Me.Num_OD_025, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OI_025, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OD_05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OI_05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OD_1000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OI_1000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OD_2000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OI_2000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OD_3000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OI_3000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OD_6000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OI_6000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OD_8000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_OI_8000, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP_ExamenFisico5.SuspendLayout()
        Me.Gb_Laboratorios.SuspendLayout()
        Me.Gb_ValoracionAuditiva.SuspendLayout()
        Me.Gb_MiembrosInferiores2.SuspendLayout()
        Me.Gb_ComentariosMiembrosInferiores.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Gb_Pies.SuspendLayout()
        Me.Gb_Tobillos.SuspendLayout()
        Me.TP_ExamenFisico4.SuspendLayout()
        Me.Gb_MiembrosInferiores.SuspendLayout()
        Me.Gb_Rodillas.SuspendLayout()
        Me.Gb_Caderas.SuspendLayout()
        Me.Gb_ValoracionMiembrosSuperiores3.SuspendLayout()
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores.SuspendLayout()
        Me.Gb_DedosManoIzquierda.SuspendLayout()
        Me.TP_ExamenFisico3.SuspendLayout()
        Me.Gb_ValoracionMiembrosSuperiores2.SuspendLayout()
        Me.Gb_DedosManoDerecha.SuspendLayout()
        Me.Gb_Manos.SuspendLayout()
        Me.Gb_Muñecas.SuspendLayout()
        Me.Gb_Codos.SuspendLayout()
        Me.Gb_Hombros.SuspendLayout()
        Me.TP_ExamenFisico2.SuspendLayout()
        Me.Gb_ValoracionMiembrosSuperiores.SuspendLayout()
        Me.Gb_ExamenColumna2.SuspendLayout()
        Me.Gb_TestWells.SuspendLayout()
        Me.Gb_SignoLasegue.SuspendLayout()
        Me.Gb_TestSchober.SuspendLayout()
        Me.TP_ExamenFisico1.SuspendLayout()
        Me.Gb_ExamenColumna.SuspendLayout()
        Me.Gb_Movilidad.SuspendLayout()
        Me.Gb_Palpacion.SuspendLayout()
        Me.Gb_Inspeccion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Gb_SignosVitales.SuspendLayout()
        CType(Me.Num_PerimetroAbdomen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_SO2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_FR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_FC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_TaDiast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_TaSist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP_AntecedentesPatologicos.SuspendLayout()
        Me.Gb_RevisionSistemas.SuspendLayout()
        CType(Me.Dgv_Habitos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Habitos.SuspendLayout()
        CType(Me.Dgv_Antecedentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Antecedentes.SuspendLayout()
        Me.TP_Antecedentes.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Dgv_Enfermedades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_Accidente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.TP_DescripcionCargo.SuspendLayout()
        CType(Me.Dgv_AntecedenteLaborales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_Higiene, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Dgv_Tareas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TP_DatosPersonales.SuspendLayout()
        Me.Gb_TipoExamen.SuspendLayout()
        Me.Gb_DatosPersonales.SuspendLayout()
        Me.Gb_Riesgo.SuspendLayout()
        CType(Me.Num_Turnos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_CargoMeses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_CargoAños, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gb_Genero.SuspendLayout()
        Me.TC_ExamenMedicoPeriodico.SuspendLayout()
        Me.TP_ExamenComplementario.SuspendLayout()
        Me.Gb_ExamenesComplementarios.SuspendLayout()
        Me.Gb_FuncionHepatica.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Gb_Visiometria.SuspendLayout()
        Me.Gb_Psicofarmacos.SuspendLayout()
        Me.Gb_ParcialOrina.SuspendLayout()
        Me.Gb_Quimica.SuspendLayout()
        Me.Gb_CuadroHematico.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.Color.Silver
        Me.Pn_Botones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Pn_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 453)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(808, 34)
        Me.Pn_Botones.TabIndex = 5
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(644, 4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 148
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(725, 4)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 149
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'TP_ImpresionDiagnostica
        '
        Me.TP_ImpresionDiagnostica.Controls.Add(Me.Dgv_ImpresionDiagnosticaFinal)
        Me.TP_ImpresionDiagnostica.Controls.Add(Me.Pn_ImpresionDiagnosticaFinal)
        Me.TP_ImpresionDiagnostica.Controls.Add(Me.Gb_ComentariosFinales)
        Me.TP_ImpresionDiagnostica.Controls.Add(Me.Gb_EstudiosFinales)
        Me.TP_ImpresionDiagnostica.Location = New System.Drawing.Point(4, 22)
        Me.TP_ImpresionDiagnostica.Name = "TP_ImpresionDiagnostica"
        Me.TP_ImpresionDiagnostica.Size = New System.Drawing.Size(798, 427)
        Me.TP_ImpresionDiagnostica.TabIndex = 9
        Me.TP_ImpresionDiagnostica.Text = "Dx"
        Me.TP_ImpresionDiagnostica.UseVisualStyleBackColor = True
        '
        'Dgv_ImpresionDiagnosticaFinal
        '
        Me.Dgv_ImpresionDiagnosticaFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ImpresionDiagnosticaFinal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVT_IDENFERMEDAD, Me.DGVT_CODIGOENFERMEDAD, Me.DGVT_NOMBREENFERMEDAD, Me.DGVC_ImpresionDiagnostica})
        Me.Dgv_ImpresionDiagnosticaFinal.Location = New System.Drawing.Point(0, 159)
        Me.Dgv_ImpresionDiagnosticaFinal.Name = "Dgv_ImpresionDiagnosticaFinal"
        Me.Dgv_ImpresionDiagnosticaFinal.Size = New System.Drawing.Size(796, 170)
        Me.Dgv_ImpresionDiagnosticaFinal.TabIndex = 4
        '
        'DGVT_IDENFERMEDAD
        '
        Me.DGVT_IDENFERMEDAD.DataPropertyName = "IDENFERMEDAD"
        Me.DGVT_IDENFERMEDAD.HeaderText = "Id"
        Me.DGVT_IDENFERMEDAD.Name = "DGVT_IDENFERMEDAD"
        Me.DGVT_IDENFERMEDAD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_IDENFERMEDAD.Width = 50
        '
        'DGVT_CODIGOENFERMEDAD
        '
        Me.DGVT_CODIGOENFERMEDAD.DataPropertyName = "CODIGOENFERMEDAD"
        Me.DGVT_CODIGOENFERMEDAD.HeaderText = "Cod"
        Me.DGVT_CODIGOENFERMEDAD.MaxInputLength = 4
        Me.DGVT_CODIGOENFERMEDAD.Name = "DGVT_CODIGOENFERMEDAD"
        Me.DGVT_CODIGOENFERMEDAD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_CODIGOENFERMEDAD.Width = 50
        '
        'DGVT_NOMBREENFERMEDAD
        '
        Me.DGVT_NOMBREENFERMEDAD.DataPropertyName = "NOMBREENFERMEDAD"
        Me.DGVT_NOMBREENFERMEDAD.HeaderText = "Enfermedad"
        Me.DGVT_NOMBREENFERMEDAD.Name = "DGVT_NOMBREENFERMEDAD"
        Me.DGVT_NOMBREENFERMEDAD.ReadOnly = True
        Me.DGVT_NOMBREENFERMEDAD.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVT_NOMBREENFERMEDAD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_NOMBREENFERMEDAD.Width = 150
        '
        'DGVC_ImpresionDiagnostica
        '
        Me.DGVC_ImpresionDiagnostica.DataPropertyName = "DESCRIPCIONENFERMEDAD"
        Me.DGVC_ImpresionDiagnostica.HeaderText = "Impresión Diagnóstica"
        Me.DGVC_ImpresionDiagnostica.MaxInputLength = 150
        Me.DGVC_ImpresionDiagnostica.Name = "DGVC_ImpresionDiagnostica"
        Me.DGVC_ImpresionDiagnostica.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_ImpresionDiagnostica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVC_ImpresionDiagnostica.Width = 500
        '
        'Pn_ImpresionDiagnosticaFinal
        '
        Me.Pn_ImpresionDiagnosticaFinal.BackColor = System.Drawing.Color.Gainsboro
        Me.Pn_ImpresionDiagnosticaFinal.Controls.Add(Me.Bt_AgregarImpresionDiagnosticaFinal)
        Me.Pn_ImpresionDiagnosticaFinal.Controls.Add(Me.Label20)
        Me.Pn_ImpresionDiagnosticaFinal.Location = New System.Drawing.Point(0, 133)
        Me.Pn_ImpresionDiagnosticaFinal.Name = "Pn_ImpresionDiagnosticaFinal"
        Me.Pn_ImpresionDiagnosticaFinal.Size = New System.Drawing.Size(796, 26)
        Me.Pn_ImpresionDiagnosticaFinal.TabIndex = 137
        '
        'Bt_AgregarImpresionDiagnosticaFinal
        '
        Me.Bt_AgregarImpresionDiagnosticaFinal.Location = New System.Drawing.Point(172, 2)
        Me.Bt_AgregarImpresionDiagnosticaFinal.Name = "Bt_AgregarImpresionDiagnosticaFinal"
        Me.Bt_AgregarImpresionDiagnosticaFinal.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarImpresionDiagnosticaFinal.TabIndex = 3
        Me.Bt_AgregarImpresionDiagnosticaFinal.Text = "Agregar"
        Me.Bt_AgregarImpresionDiagnosticaFinal.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(3, 4)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(163, 16)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Impresión Diagnóstica"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Gb_ComentariosFinales
        '
        Me.Gb_ComentariosFinales.Controls.Add(Me.Tb_ComentariosFinales)
        Me.Gb_ComentariosFinales.Location = New System.Drawing.Point(5, 5)
        Me.Gb_ComentariosFinales.Name = "Gb_ComentariosFinales"
        Me.Gb_ComentariosFinales.Size = New System.Drawing.Size(786, 122)
        Me.Gb_ComentariosFinales.TabIndex = 1
        Me.Gb_ComentariosFinales.TabStop = False
        Me.Gb_ComentariosFinales.Text = "Análisis De Las Evidencias Finales"
        '
        'Tb_ComentariosFinales
        '
        Me.Tb_ComentariosFinales.Location = New System.Drawing.Point(9, 19)
        Me.Tb_ComentariosFinales.MaxLength = 700
        Me.Tb_ComentariosFinales.Multiline = True
        Me.Tb_ComentariosFinales.Name = "Tb_ComentariosFinales"
        Me.Tb_ComentariosFinales.Size = New System.Drawing.Size(766, 97)
        Me.Tb_ComentariosFinales.TabIndex = 2
        '
        'Gb_EstudiosFinales
        '
        Me.Gb_EstudiosFinales.Controls.Add(Me.Tb_EstudiosFinales)
        Me.Gb_EstudiosFinales.Location = New System.Drawing.Point(6, 337)
        Me.Gb_EstudiosFinales.Name = "Gb_EstudiosFinales"
        Me.Gb_EstudiosFinales.Size = New System.Drawing.Size(786, 85)
        Me.Gb_EstudiosFinales.TabIndex = 5
        Me.Gb_EstudiosFinales.TabStop = False
        Me.Gb_EstudiosFinales.Text = "Estudios Finales"
        '
        'Tb_EstudiosFinales
        '
        Me.Tb_EstudiosFinales.Location = New System.Drawing.Point(9, 19)
        Me.Tb_EstudiosFinales.MaxLength = 100
        Me.Tb_EstudiosFinales.Multiline = True
        Me.Tb_EstudiosFinales.Name = "Tb_EstudiosFinales"
        Me.Tb_EstudiosFinales.Size = New System.Drawing.Size(766, 60)
        Me.Tb_EstudiosFinales.TabIndex = 6
        '
        'TP_ExamenAuditivo
        '
        Me.TP_ExamenAuditivo.Controls.Add(Me.Gb_Auditivo)
        Me.TP_ExamenAuditivo.Location = New System.Drawing.Point(4, 22)
        Me.TP_ExamenAuditivo.Name = "TP_ExamenAuditivo"
        Me.TP_ExamenAuditivo.Size = New System.Drawing.Size(798, 427)
        Me.TP_ExamenAuditivo.TabIndex = 8
        Me.TP_ExamenAuditivo.Text = "Ex. Auditivo"
        Me.TP_ExamenAuditivo.UseVisualStyleBackColor = True
        '
        'Gb_Auditivo
        '
        Me.Gb_Auditivo.Controls.Add(Me.Tb_Detalle025)
        Me.Gb_Auditivo.Controls.Add(Me.Cb_ViaComprometida025)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OD_025)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OI_025)
        Me.Gb_Auditivo.Controls.Add(Me.Tb_Detalle05)
        Me.Gb_Auditivo.Controls.Add(Me.Cb_ViaComprometida05)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OD_05)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OI_05)
        Me.Gb_Auditivo.Controls.Add(Me.Tb_Detalle1000)
        Me.Gb_Auditivo.Controls.Add(Me.Cb_ViaComprometida1000)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OD_1000)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OI_1000)
        Me.Gb_Auditivo.Controls.Add(Me.Tb_Detalle2000)
        Me.Gb_Auditivo.Controls.Add(Me.Cb_ViaComprometida2000)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OD_2000)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OI_2000)
        Me.Gb_Auditivo.Controls.Add(Me.Tb_Detalle3000)
        Me.Gb_Auditivo.Controls.Add(Me.Cb_ViaComprometida3000)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OD_3000)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OI_3000)
        Me.Gb_Auditivo.Controls.Add(Me.Tb_Detalle6000)
        Me.Gb_Auditivo.Controls.Add(Me.Cb_ViaComprometida6000)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OD_6000)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OI_6000)
        Me.Gb_Auditivo.Controls.Add(Me.Tb_Detalle8000)
        Me.Gb_Auditivo.Controls.Add(Me.Cb_ViaComprometida8000)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OD_8000)
        Me.Gb_Auditivo.Controls.Add(Me.Num_OI_8000)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_Detalle)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_ViaComprometida)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_OD)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_OI)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_025)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_6000)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_3000)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_2000)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_1000)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_05)
        Me.Gb_Auditivo.Controls.Add(Me.Lb_8000)
        Me.Gb_Auditivo.Location = New System.Drawing.Point(5, 5)
        Me.Gb_Auditivo.Name = "Gb_Auditivo"
        Me.Gb_Auditivo.Size = New System.Drawing.Size(786, 348)
        Me.Gb_Auditivo.TabIndex = 1
        Me.Gb_Auditivo.TabStop = False
        Me.Gb_Auditivo.Text = "Auditivo"
        '
        'Tb_Detalle025
        '
        Me.Tb_Detalle025.Location = New System.Drawing.Point(470, 305)
        Me.Tb_Detalle025.MaxLength = 100
        Me.Tb_Detalle025.Multiline = True
        Me.Tb_Detalle025.Name = "Tb_Detalle025"
        Me.Tb_Detalle025.Size = New System.Drawing.Size(294, 35)
        Me.Tb_Detalle025.TabIndex = 29
        '
        'Cb_ViaComprometida025
        '
        Me.Cb_ViaComprometida025.FormattingEnabled = True
        Me.Cb_ViaComprometida025.Location = New System.Drawing.Point(300, 305)
        Me.Cb_ViaComprometida025.Name = "Cb_ViaComprometida025"
        Me.Cb_ViaComprometida025.Size = New System.Drawing.Size(121, 21)
        Me.Cb_ViaComprometida025.TabIndex = 28
        '
        'Num_OD_025
        '
        Me.Num_OD_025.Location = New System.Drawing.Point(193, 305)
        Me.Num_OD_025.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OD_025.Name = "Num_OD_025"
        Me.Num_OD_025.Size = New System.Drawing.Size(58, 20)
        Me.Num_OD_025.TabIndex = 27
        '
        'Num_OI_025
        '
        Me.Num_OI_025.Location = New System.Drawing.Point(86, 305)
        Me.Num_OI_025.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OI_025.Name = "Num_OI_025"
        Me.Num_OI_025.Size = New System.Drawing.Size(58, 20)
        Me.Num_OI_025.TabIndex = 26
        '
        'Tb_Detalle05
        '
        Me.Tb_Detalle05.Location = New System.Drawing.Point(470, 260)
        Me.Tb_Detalle05.MaxLength = 100
        Me.Tb_Detalle05.Multiline = True
        Me.Tb_Detalle05.Name = "Tb_Detalle05"
        Me.Tb_Detalle05.Size = New System.Drawing.Size(294, 35)
        Me.Tb_Detalle05.TabIndex = 25
        '
        'Cb_ViaComprometida05
        '
        Me.Cb_ViaComprometida05.FormattingEnabled = True
        Me.Cb_ViaComprometida05.Location = New System.Drawing.Point(300, 260)
        Me.Cb_ViaComprometida05.Name = "Cb_ViaComprometida05"
        Me.Cb_ViaComprometida05.Size = New System.Drawing.Size(121, 21)
        Me.Cb_ViaComprometida05.TabIndex = 24
        '
        'Num_OD_05
        '
        Me.Num_OD_05.Location = New System.Drawing.Point(193, 260)
        Me.Num_OD_05.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OD_05.Name = "Num_OD_05"
        Me.Num_OD_05.Size = New System.Drawing.Size(58, 20)
        Me.Num_OD_05.TabIndex = 23
        '
        'Num_OI_05
        '
        Me.Num_OI_05.Location = New System.Drawing.Point(86, 260)
        Me.Num_OI_05.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OI_05.Name = "Num_OI_05"
        Me.Num_OI_05.Size = New System.Drawing.Size(58, 20)
        Me.Num_OI_05.TabIndex = 22
        '
        'Tb_Detalle1000
        '
        Me.Tb_Detalle1000.Location = New System.Drawing.Point(470, 215)
        Me.Tb_Detalle1000.MaxLength = 100
        Me.Tb_Detalle1000.Multiline = True
        Me.Tb_Detalle1000.Name = "Tb_Detalle1000"
        Me.Tb_Detalle1000.Size = New System.Drawing.Size(294, 35)
        Me.Tb_Detalle1000.TabIndex = 21
        '
        'Cb_ViaComprometida1000
        '
        Me.Cb_ViaComprometida1000.FormattingEnabled = True
        Me.Cb_ViaComprometida1000.Location = New System.Drawing.Point(300, 215)
        Me.Cb_ViaComprometida1000.Name = "Cb_ViaComprometida1000"
        Me.Cb_ViaComprometida1000.Size = New System.Drawing.Size(121, 21)
        Me.Cb_ViaComprometida1000.TabIndex = 20
        '
        'Num_OD_1000
        '
        Me.Num_OD_1000.Location = New System.Drawing.Point(193, 215)
        Me.Num_OD_1000.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OD_1000.Name = "Num_OD_1000"
        Me.Num_OD_1000.Size = New System.Drawing.Size(58, 20)
        Me.Num_OD_1000.TabIndex = 19
        '
        'Num_OI_1000
        '
        Me.Num_OI_1000.Location = New System.Drawing.Point(86, 215)
        Me.Num_OI_1000.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OI_1000.Name = "Num_OI_1000"
        Me.Num_OI_1000.Size = New System.Drawing.Size(58, 20)
        Me.Num_OI_1000.TabIndex = 18
        '
        'Tb_Detalle2000
        '
        Me.Tb_Detalle2000.Location = New System.Drawing.Point(470, 170)
        Me.Tb_Detalle2000.MaxLength = 100
        Me.Tb_Detalle2000.Multiline = True
        Me.Tb_Detalle2000.Name = "Tb_Detalle2000"
        Me.Tb_Detalle2000.Size = New System.Drawing.Size(294, 35)
        Me.Tb_Detalle2000.TabIndex = 17
        '
        'Cb_ViaComprometida2000
        '
        Me.Cb_ViaComprometida2000.FormattingEnabled = True
        Me.Cb_ViaComprometida2000.Location = New System.Drawing.Point(300, 170)
        Me.Cb_ViaComprometida2000.Name = "Cb_ViaComprometida2000"
        Me.Cb_ViaComprometida2000.Size = New System.Drawing.Size(121, 21)
        Me.Cb_ViaComprometida2000.TabIndex = 16
        '
        'Num_OD_2000
        '
        Me.Num_OD_2000.Location = New System.Drawing.Point(193, 170)
        Me.Num_OD_2000.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OD_2000.Name = "Num_OD_2000"
        Me.Num_OD_2000.Size = New System.Drawing.Size(58, 20)
        Me.Num_OD_2000.TabIndex = 15
        '
        'Num_OI_2000
        '
        Me.Num_OI_2000.Location = New System.Drawing.Point(86, 170)
        Me.Num_OI_2000.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OI_2000.Name = "Num_OI_2000"
        Me.Num_OI_2000.Size = New System.Drawing.Size(58, 20)
        Me.Num_OI_2000.TabIndex = 14
        '
        'Tb_Detalle3000
        '
        Me.Tb_Detalle3000.Location = New System.Drawing.Point(470, 125)
        Me.Tb_Detalle3000.MaxLength = 100
        Me.Tb_Detalle3000.Multiline = True
        Me.Tb_Detalle3000.Name = "Tb_Detalle3000"
        Me.Tb_Detalle3000.Size = New System.Drawing.Size(294, 35)
        Me.Tb_Detalle3000.TabIndex = 13
        '
        'Cb_ViaComprometida3000
        '
        Me.Cb_ViaComprometida3000.FormattingEnabled = True
        Me.Cb_ViaComprometida3000.ItemHeight = 13
        Me.Cb_ViaComprometida3000.Location = New System.Drawing.Point(300, 125)
        Me.Cb_ViaComprometida3000.Name = "Cb_ViaComprometida3000"
        Me.Cb_ViaComprometida3000.Size = New System.Drawing.Size(121, 21)
        Me.Cb_ViaComprometida3000.TabIndex = 12
        '
        'Num_OD_3000
        '
        Me.Num_OD_3000.Location = New System.Drawing.Point(193, 125)
        Me.Num_OD_3000.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OD_3000.Name = "Num_OD_3000"
        Me.Num_OD_3000.Size = New System.Drawing.Size(58, 20)
        Me.Num_OD_3000.TabIndex = 11
        '
        'Num_OI_3000
        '
        Me.Num_OI_3000.Location = New System.Drawing.Point(86, 125)
        Me.Num_OI_3000.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OI_3000.Name = "Num_OI_3000"
        Me.Num_OI_3000.Size = New System.Drawing.Size(58, 20)
        Me.Num_OI_3000.TabIndex = 10
        '
        'Tb_Detalle6000
        '
        Me.Tb_Detalle6000.Location = New System.Drawing.Point(470, 80)
        Me.Tb_Detalle6000.MaxLength = 100
        Me.Tb_Detalle6000.Multiline = True
        Me.Tb_Detalle6000.Name = "Tb_Detalle6000"
        Me.Tb_Detalle6000.Size = New System.Drawing.Size(294, 35)
        Me.Tb_Detalle6000.TabIndex = 9
        '
        'Cb_ViaComprometida6000
        '
        Me.Cb_ViaComprometida6000.FormattingEnabled = True
        Me.Cb_ViaComprometida6000.Location = New System.Drawing.Point(300, 80)
        Me.Cb_ViaComprometida6000.Name = "Cb_ViaComprometida6000"
        Me.Cb_ViaComprometida6000.Size = New System.Drawing.Size(121, 21)
        Me.Cb_ViaComprometida6000.TabIndex = 8
        '
        'Num_OD_6000
        '
        Me.Num_OD_6000.Location = New System.Drawing.Point(193, 80)
        Me.Num_OD_6000.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OD_6000.Name = "Num_OD_6000"
        Me.Num_OD_6000.Size = New System.Drawing.Size(58, 20)
        Me.Num_OD_6000.TabIndex = 7
        '
        'Num_OI_6000
        '
        Me.Num_OI_6000.Location = New System.Drawing.Point(86, 80)
        Me.Num_OI_6000.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OI_6000.Name = "Num_OI_6000"
        Me.Num_OI_6000.Size = New System.Drawing.Size(58, 20)
        Me.Num_OI_6000.TabIndex = 6
        '
        'Tb_Detalle8000
        '
        Me.Tb_Detalle8000.Location = New System.Drawing.Point(470, 35)
        Me.Tb_Detalle8000.MaxLength = 100
        Me.Tb_Detalle8000.Multiline = True
        Me.Tb_Detalle8000.Name = "Tb_Detalle8000"
        Me.Tb_Detalle8000.Size = New System.Drawing.Size(294, 35)
        Me.Tb_Detalle8000.TabIndex = 5
        '
        'Cb_ViaComprometida8000
        '
        Me.Cb_ViaComprometida8000.FormattingEnabled = True
        Me.Cb_ViaComprometida8000.Location = New System.Drawing.Point(300, 35)
        Me.Cb_ViaComprometida8000.Name = "Cb_ViaComprometida8000"
        Me.Cb_ViaComprometida8000.Size = New System.Drawing.Size(121, 21)
        Me.Cb_ViaComprometida8000.TabIndex = 4
        '
        'Num_OD_8000
        '
        Me.Num_OD_8000.Location = New System.Drawing.Point(193, 35)
        Me.Num_OD_8000.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OD_8000.Name = "Num_OD_8000"
        Me.Num_OD_8000.Size = New System.Drawing.Size(58, 20)
        Me.Num_OD_8000.TabIndex = 3
        '
        'Num_OI_8000
        '
        Me.Num_OI_8000.Location = New System.Drawing.Point(86, 35)
        Me.Num_OI_8000.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Num_OI_8000.Name = "Num_OI_8000"
        Me.Num_OI_8000.Size = New System.Drawing.Size(58, 20)
        Me.Num_OI_8000.TabIndex = 2
        '
        'Lb_Detalle
        '
        Me.Lb_Detalle.AutoSize = True
        Me.Lb_Detalle.Location = New System.Drawing.Point(467, 14)
        Me.Lb_Detalle.Name = "Lb_Detalle"
        Me.Lb_Detalle.Size = New System.Drawing.Size(40, 13)
        Me.Lb_Detalle.TabIndex = 10
        Me.Lb_Detalle.Text = "Detalle"
        '
        'Lb_ViaComprometida
        '
        Me.Lb_ViaComprometida.AutoSize = True
        Me.Lb_ViaComprometida.Location = New System.Drawing.Point(297, 14)
        Me.Lb_ViaComprometida.Name = "Lb_ViaComprometida"
        Me.Lb_ViaComprometida.Size = New System.Drawing.Size(92, 13)
        Me.Lb_ViaComprometida.TabIndex = 9
        Me.Lb_ViaComprometida.Text = "Via Comprometida"
        '
        'Lb_OD
        '
        Me.Lb_OD.AutoSize = True
        Me.Lb_OD.Location = New System.Drawing.Point(190, 14)
        Me.Lb_OD.Name = "Lb_OD"
        Me.Lb_OD.Size = New System.Drawing.Size(23, 13)
        Me.Lb_OD.TabIndex = 8
        Me.Lb_OD.Text = "OD"
        '
        'Lb_OI
        '
        Me.Lb_OI.AutoSize = True
        Me.Lb_OI.Location = New System.Drawing.Point(83, 14)
        Me.Lb_OI.Name = "Lb_OI"
        Me.Lb_OI.Size = New System.Drawing.Size(18, 13)
        Me.Lb_OI.TabIndex = 7
        Me.Lb_OI.Text = "OI"
        '
        'Lb_025
        '
        Me.Lb_025.AutoSize = True
        Me.Lb_025.Location = New System.Drawing.Point(9, 307)
        Me.Lb_025.Name = "Lb_025"
        Me.Lb_025.Size = New System.Drawing.Size(28, 13)
        Me.Lb_025.TabIndex = 6
        Me.Lb_025.Text = "0,25"
        '
        'Lb_6000
        '
        Me.Lb_6000.AutoSize = True
        Me.Lb_6000.Location = New System.Drawing.Point(6, 84)
        Me.Lb_6000.Name = "Lb_6000"
        Me.Lb_6000.Size = New System.Drawing.Size(31, 13)
        Me.Lb_6000.TabIndex = 5
        Me.Lb_6000.Text = "6000"
        '
        'Lb_3000
        '
        Me.Lb_3000.AutoSize = True
        Me.Lb_3000.Location = New System.Drawing.Point(6, 129)
        Me.Lb_3000.Name = "Lb_3000"
        Me.Lb_3000.Size = New System.Drawing.Size(31, 13)
        Me.Lb_3000.TabIndex = 4
        Me.Lb_3000.Text = "3000"
        '
        'Lb_2000
        '
        Me.Lb_2000.AutoSize = True
        Me.Lb_2000.Location = New System.Drawing.Point(6, 174)
        Me.Lb_2000.Name = "Lb_2000"
        Me.Lb_2000.Size = New System.Drawing.Size(31, 13)
        Me.Lb_2000.TabIndex = 3
        Me.Lb_2000.Text = "2000"
        '
        'Lb_1000
        '
        Me.Lb_1000.AutoSize = True
        Me.Lb_1000.Location = New System.Drawing.Point(6, 219)
        Me.Lb_1000.Name = "Lb_1000"
        Me.Lb_1000.Size = New System.Drawing.Size(31, 13)
        Me.Lb_1000.TabIndex = 2
        Me.Lb_1000.Text = "1000"
        '
        'Lb_05
        '
        Me.Lb_05.AutoSize = True
        Me.Lb_05.Location = New System.Drawing.Point(15, 262)
        Me.Lb_05.Name = "Lb_05"
        Me.Lb_05.Size = New System.Drawing.Size(22, 13)
        Me.Lb_05.TabIndex = 1
        Me.Lb_05.Text = "0,5"
        '
        'Lb_8000
        '
        Me.Lb_8000.AutoSize = True
        Me.Lb_8000.Location = New System.Drawing.Point(6, 39)
        Me.Lb_8000.Name = "Lb_8000"
        Me.Lb_8000.Size = New System.Drawing.Size(31, 13)
        Me.Lb_8000.TabIndex = 0
        Me.Lb_8000.Text = "8000"
        '
        'TP_ExamenFisico5
        '
        Me.TP_ExamenFisico5.Controls.Add(Me.Gb_Laboratorios)
        Me.TP_ExamenFisico5.Controls.Add(Me.Gb_ValoracionAuditiva)
        Me.TP_ExamenFisico5.Controls.Add(Me.Gb_MiembrosInferiores2)
        Me.TP_ExamenFisico5.Location = New System.Drawing.Point(4, 22)
        Me.TP_ExamenFisico5.Name = "TP_ExamenFisico5"
        Me.TP_ExamenFisico5.Size = New System.Drawing.Size(798, 427)
        Me.TP_ExamenFisico5.TabIndex = 7
        Me.TP_ExamenFisico5.Text = "Ex. Físico"
        Me.TP_ExamenFisico5.UseVisualStyleBackColor = True
        '
        'Gb_Laboratorios
        '
        Me.Gb_Laboratorios.Controls.Add(Me.Rb_NoExComplementario)
        Me.Gb_Laboratorios.Controls.Add(Me.Rb_SiExComplementario)
        Me.Gb_Laboratorios.Location = New System.Drawing.Point(127, 385)
        Me.Gb_Laboratorios.Name = "Gb_Laboratorios"
        Me.Gb_Laboratorios.Size = New System.Drawing.Size(154, 38)
        Me.Gb_Laboratorios.TabIndex = 21
        Me.Gb_Laboratorios.TabStop = False
        Me.Gb_Laboratorios.Text = "Exámenes Complementarios"
        '
        'Rb_NoExComplementario
        '
        Me.Rb_NoExComplementario.AutoSize = True
        Me.Rb_NoExComplementario.Location = New System.Drawing.Point(56, 14)
        Me.Rb_NoExComplementario.Name = "Rb_NoExComplementario"
        Me.Rb_NoExComplementario.Size = New System.Drawing.Size(39, 17)
        Me.Rb_NoExComplementario.TabIndex = 20
        Me.Rb_NoExComplementario.TabStop = True
        Me.Rb_NoExComplementario.Text = "No"
        Me.Rb_NoExComplementario.UseVisualStyleBackColor = True
        '
        'Rb_SiExComplementario
        '
        Me.Rb_SiExComplementario.AutoSize = True
        Me.Rb_SiExComplementario.Location = New System.Drawing.Point(16, 14)
        Me.Rb_SiExComplementario.Name = "Rb_SiExComplementario"
        Me.Rb_SiExComplementario.Size = New System.Drawing.Size(34, 17)
        Me.Rb_SiExComplementario.TabIndex = 19
        Me.Rb_SiExComplementario.TabStop = True
        Me.Rb_SiExComplementario.Text = "Si"
        Me.Rb_SiExComplementario.UseVisualStyleBackColor = True
        '
        'Gb_ValoracionAuditiva
        '
        Me.Gb_ValoracionAuditiva.Controls.Add(Me.Rb_AuditivaNo)
        Me.Gb_ValoracionAuditiva.Controls.Add(Me.Rb_AuditivaSi)
        Me.Gb_ValoracionAuditiva.Location = New System.Drawing.Point(5, 385)
        Me.Gb_ValoracionAuditiva.Name = "Gb_ValoracionAuditiva"
        Me.Gb_ValoracionAuditiva.Size = New System.Drawing.Size(116, 38)
        Me.Gb_ValoracionAuditiva.TabIndex = 18
        Me.Gb_ValoracionAuditiva.TabStop = False
        Me.Gb_ValoracionAuditiva.Text = "Valoración Auditiva"
        '
        'Rb_AuditivaNo
        '
        Me.Rb_AuditivaNo.AutoSize = True
        Me.Rb_AuditivaNo.Location = New System.Drawing.Point(56, 14)
        Me.Rb_AuditivaNo.Name = "Rb_AuditivaNo"
        Me.Rb_AuditivaNo.Size = New System.Drawing.Size(39, 17)
        Me.Rb_AuditivaNo.TabIndex = 20
        Me.Rb_AuditivaNo.TabStop = True
        Me.Rb_AuditivaNo.Text = "No"
        Me.Rb_AuditivaNo.UseVisualStyleBackColor = True
        '
        'Rb_AuditivaSi
        '
        Me.Rb_AuditivaSi.AutoSize = True
        Me.Rb_AuditivaSi.Location = New System.Drawing.Point(16, 14)
        Me.Rb_AuditivaSi.Name = "Rb_AuditivaSi"
        Me.Rb_AuditivaSi.Size = New System.Drawing.Size(34, 17)
        Me.Rb_AuditivaSi.TabIndex = 19
        Me.Rb_AuditivaSi.TabStop = True
        Me.Rb_AuditivaSi.Text = "Si"
        Me.Rb_AuditivaSi.UseVisualStyleBackColor = True
        '
        'Gb_MiembrosInferiores2
        '
        Me.Gb_MiembrosInferiores2.Controls.Add(Me.Gb_ComentariosMiembrosInferiores)
        Me.Gb_MiembrosInferiores2.Controls.Add(Me.GroupBox5)
        Me.Gb_MiembrosInferiores2.Controls.Add(Me.Gb_Pies)
        Me.Gb_MiembrosInferiores2.Controls.Add(Me.Gb_Tobillos)
        Me.Gb_MiembrosInferiores2.Location = New System.Drawing.Point(5, 5)
        Me.Gb_MiembrosInferiores2.Name = "Gb_MiembrosInferiores2"
        Me.Gb_MiembrosInferiores2.Size = New System.Drawing.Size(786, 378)
        Me.Gb_MiembrosInferiores2.TabIndex = 1
        Me.Gb_MiembrosInferiores2.TabStop = False
        Me.Gb_MiembrosInferiores2.Text = "Valoración Miembros Inferiores"
        '
        'Gb_ComentariosMiembrosInferiores
        '
        Me.Gb_ComentariosMiembrosInferiores.Controls.Add(Me.Tb_ComentariosMiembrosInferiores)
        Me.Gb_ComentariosMiembrosInferiores.Location = New System.Drawing.Point(5, 271)
        Me.Gb_ComentariosMiembrosInferiores.Name = "Gb_ComentariosMiembrosInferiores"
        Me.Gb_ComentariosMiembrosInferiores.Size = New System.Drawing.Size(773, 101)
        Me.Gb_ComentariosMiembrosInferiores.TabIndex = 14
        Me.Gb_ComentariosMiembrosInferiores.TabStop = False
        Me.Gb_ComentariosMiembrosInferiores.Text = "Comentarios De Las Evidencias"
        '
        'Tb_ComentariosMiembrosInferiores
        '
        Me.Tb_ComentariosMiembrosInferiores.Location = New System.Drawing.Point(9, 19)
        Me.Tb_ComentariosMiembrosInferiores.MaxLength = 500
        Me.Tb_ComentariosMiembrosInferiores.Multiline = True
        Me.Tb_ComentariosMiembrosInferiores.Name = "Tb_ComentariosMiembrosInferiores"
        Me.Tb_ComentariosMiembrosInferiores.Size = New System.Drawing.Size(755, 76)
        Me.Tb_ComentariosMiembrosInferiores.TabIndex = 15
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Tb_Marcha)
        Me.GroupBox5.Controls.Add(Me.Lb_Marcha)
        Me.GroupBox5.Controls.Add(Me.Tb_FaseBalanceoPieIzquierdo)
        Me.GroupBox5.Controls.Add(Me.Lb_MarchaPieIzquierdo)
        Me.GroupBox5.Controls.Add(Me.Tb_FaseApoyoPieIzquierdo)
        Me.GroupBox5.Controls.Add(Me.Lb_MarchaPieDerecho)
        Me.GroupBox5.Controls.Add(Me.Tb_FaseBalanceoPieDerecho)
        Me.GroupBox5.Controls.Add(Me.Lb_FaseBalanceo)
        Me.GroupBox5.Controls.Add(Me.Tb_FaseApoyoPieDerecho)
        Me.GroupBox5.Controls.Add(Me.Lb_FaseApoyo)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 133)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(773, 135)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Marcha"
        '
        'Tb_Marcha
        '
        Me.Tb_Marcha.Location = New System.Drawing.Point(552, 30)
        Me.Tb_Marcha.MaxLength = 100
        Me.Tb_Marcha.Multiline = True
        Me.Tb_Marcha.Name = "Tb_Marcha"
        Me.Tb_Marcha.Size = New System.Drawing.Size(215, 96)
        Me.Tb_Marcha.TabIndex = 13
        '
        'Lb_Marcha
        '
        Me.Lb_Marcha.AutoSize = True
        Me.Lb_Marcha.Location = New System.Drawing.Point(549, 11)
        Me.Lb_Marcha.Name = "Lb_Marcha"
        Me.Lb_Marcha.Size = New System.Drawing.Size(43, 13)
        Me.Lb_Marcha.TabIndex = 8
        Me.Lb_Marcha.Text = "Marcha"
        '
        'Tb_FaseBalanceoPieIzquierdo
        '
        Me.Tb_FaseBalanceoPieIzquierdo.Location = New System.Drawing.Point(331, 81)
        Me.Tb_FaseBalanceoPieIzquierdo.MaxLength = 100
        Me.Tb_FaseBalanceoPieIzquierdo.Multiline = True
        Me.Tb_FaseBalanceoPieIzquierdo.Name = "Tb_FaseBalanceoPieIzquierdo"
        Me.Tb_FaseBalanceoPieIzquierdo.Size = New System.Drawing.Size(215, 45)
        Me.Tb_FaseBalanceoPieIzquierdo.TabIndex = 12
        '
        'Lb_MarchaPieIzquierdo
        '
        Me.Lb_MarchaPieIzquierdo.AutoSize = True
        Me.Lb_MarchaPieIzquierdo.Location = New System.Drawing.Point(328, 11)
        Me.Lb_MarchaPieIzquierdo.Name = "Lb_MarchaPieIzquierdo"
        Me.Lb_MarchaPieIzquierdo.Size = New System.Drawing.Size(68, 13)
        Me.Lb_MarchaPieIzquierdo.TabIndex = 6
        Me.Lb_MarchaPieIzquierdo.Text = "Pie Izquierdo"
        '
        'Tb_FaseApoyoPieIzquierdo
        '
        Me.Tb_FaseApoyoPieIzquierdo.Location = New System.Drawing.Point(331, 30)
        Me.Tb_FaseApoyoPieIzquierdo.MaxLength = 100
        Me.Tb_FaseApoyoPieIzquierdo.Multiline = True
        Me.Tb_FaseApoyoPieIzquierdo.Name = "Tb_FaseApoyoPieIzquierdo"
        Me.Tb_FaseApoyoPieIzquierdo.Size = New System.Drawing.Size(215, 45)
        Me.Tb_FaseApoyoPieIzquierdo.TabIndex = 10
        '
        'Lb_MarchaPieDerecho
        '
        Me.Lb_MarchaPieDerecho.AutoSize = True
        Me.Lb_MarchaPieDerecho.Location = New System.Drawing.Point(107, 11)
        Me.Lb_MarchaPieDerecho.Name = "Lb_MarchaPieDerecho"
        Me.Lb_MarchaPieDerecho.Size = New System.Drawing.Size(66, 13)
        Me.Lb_MarchaPieDerecho.TabIndex = 4
        Me.Lb_MarchaPieDerecho.Text = "Pie Derecho"
        '
        'Tb_FaseBalanceoPieDerecho
        '
        Me.Tb_FaseBalanceoPieDerecho.Location = New System.Drawing.Point(110, 81)
        Me.Tb_FaseBalanceoPieDerecho.MaxLength = 100
        Me.Tb_FaseBalanceoPieDerecho.Multiline = True
        Me.Tb_FaseBalanceoPieDerecho.Name = "Tb_FaseBalanceoPieDerecho"
        Me.Tb_FaseBalanceoPieDerecho.Size = New System.Drawing.Size(215, 45)
        Me.Tb_FaseBalanceoPieDerecho.TabIndex = 11
        '
        'Lb_FaseBalanceo
        '
        Me.Lb_FaseBalanceo.AutoSize = True
        Me.Lb_FaseBalanceo.Location = New System.Drawing.Point(6, 80)
        Me.Lb_FaseBalanceo.Name = "Lb_FaseBalanceo"
        Me.Lb_FaseBalanceo.Size = New System.Drawing.Size(98, 13)
        Me.Lb_FaseBalanceo.TabIndex = 2
        Me.Lb_FaseBalanceo.Text = "Fase De Balanceo:"
        '
        'Tb_FaseApoyoPieDerecho
        '
        Me.Tb_FaseApoyoPieDerecho.Location = New System.Drawing.Point(110, 30)
        Me.Tb_FaseApoyoPieDerecho.MaxLength = 100
        Me.Tb_FaseApoyoPieDerecho.Multiline = True
        Me.Tb_FaseApoyoPieDerecho.Name = "Tb_FaseApoyoPieDerecho"
        Me.Tb_FaseApoyoPieDerecho.Size = New System.Drawing.Size(215, 45)
        Me.Tb_FaseApoyoPieDerecho.TabIndex = 9
        '
        'Lb_FaseApoyo
        '
        Me.Lb_FaseApoyo.AutoSize = True
        Me.Lb_FaseApoyo.Location = New System.Drawing.Point(21, 32)
        Me.Lb_FaseApoyo.Name = "Lb_FaseApoyo"
        Me.Lb_FaseApoyo.Size = New System.Drawing.Size(83, 13)
        Me.Lb_FaseApoyo.TabIndex = 0
        Me.Lb_FaseApoyo.Text = "Fase De Apoyo:"
        '
        'Gb_Pies
        '
        Me.Gb_Pies.Controls.Add(Me.Tb_PieIzquierdo)
        Me.Gb_Pies.Controls.Add(Me.Lb_PieIzquierdo)
        Me.Gb_Pies.Controls.Add(Me.Tb_PieDerecho)
        Me.Gb_Pies.Controls.Add(Me.Lb_PieDerecho)
        Me.Gb_Pies.Location = New System.Drawing.Point(5, 76)
        Me.Gb_Pies.Name = "Gb_Pies"
        Me.Gb_Pies.Size = New System.Drawing.Size(773, 55)
        Me.Gb_Pies.TabIndex = 5
        Me.Gb_Pies.TabStop = False
        Me.Gb_Pies.Text = "Pies"
        '
        'Tb_PieIzquierdo
        '
        Me.Tb_PieIzquierdo.Location = New System.Drawing.Point(452, 13)
        Me.Tb_PieIzquierdo.MaxLength = 100
        Me.Tb_PieIzquierdo.Multiline = True
        Me.Tb_PieIzquierdo.Name = "Tb_PieIzquierdo"
        Me.Tb_PieIzquierdo.Size = New System.Drawing.Size(300, 35)
        Me.Tb_PieIzquierdo.TabIndex = 7
        '
        'Lb_PieIzquierdo
        '
        Me.Lb_PieIzquierdo.AutoSize = True
        Me.Lb_PieIzquierdo.Location = New System.Drawing.Point(385, 16)
        Me.Lb_PieIzquierdo.Name = "Lb_PieIzquierdo"
        Me.Lb_PieIzquierdo.Size = New System.Drawing.Size(53, 13)
        Me.Lb_PieIzquierdo.TabIndex = 2
        Me.Lb_PieIzquierdo.Text = "Izquierdo:"
        '
        'Tb_PieDerecho
        '
        Me.Tb_PieDerecho.Location = New System.Drawing.Point(71, 13)
        Me.Tb_PieDerecho.MaxLength = 100
        Me.Tb_PieDerecho.Multiline = True
        Me.Tb_PieDerecho.Name = "Tb_PieDerecho"
        Me.Tb_PieDerecho.Size = New System.Drawing.Size(300, 35)
        Me.Tb_PieDerecho.TabIndex = 6
        '
        'Lb_PieDerecho
        '
        Me.Lb_PieDerecho.AutoSize = True
        Me.Lb_PieDerecho.Location = New System.Drawing.Point(6, 16)
        Me.Lb_PieDerecho.Name = "Lb_PieDerecho"
        Me.Lb_PieDerecho.Size = New System.Drawing.Size(51, 13)
        Me.Lb_PieDerecho.TabIndex = 0
        Me.Lb_PieDerecho.Text = "Derecho:"
        '
        'Gb_Tobillos
        '
        Me.Gb_Tobillos.Controls.Add(Me.Tb_TobilloIzquierdo)
        Me.Gb_Tobillos.Controls.Add(Me.Lb_TobilloIzquierdo)
        Me.Gb_Tobillos.Controls.Add(Me.Tb_TobilloDerecho)
        Me.Gb_Tobillos.Controls.Add(Me.Lb_TobilloDerecho)
        Me.Gb_Tobillos.Location = New System.Drawing.Point(5, 15)
        Me.Gb_Tobillos.Name = "Gb_Tobillos"
        Me.Gb_Tobillos.Size = New System.Drawing.Size(773, 55)
        Me.Gb_Tobillos.TabIndex = 2
        Me.Gb_Tobillos.TabStop = False
        Me.Gb_Tobillos.Text = "Tobillos"
        '
        'Tb_TobilloIzquierdo
        '
        Me.Tb_TobilloIzquierdo.Location = New System.Drawing.Point(452, 13)
        Me.Tb_TobilloIzquierdo.MaxLength = 100
        Me.Tb_TobilloIzquierdo.Multiline = True
        Me.Tb_TobilloIzquierdo.Name = "Tb_TobilloIzquierdo"
        Me.Tb_TobilloIzquierdo.Size = New System.Drawing.Size(300, 35)
        Me.Tb_TobilloIzquierdo.TabIndex = 4
        '
        'Lb_TobilloIzquierdo
        '
        Me.Lb_TobilloIzquierdo.AutoSize = True
        Me.Lb_TobilloIzquierdo.Location = New System.Drawing.Point(385, 16)
        Me.Lb_TobilloIzquierdo.Name = "Lb_TobilloIzquierdo"
        Me.Lb_TobilloIzquierdo.Size = New System.Drawing.Size(53, 13)
        Me.Lb_TobilloIzquierdo.TabIndex = 2
        Me.Lb_TobilloIzquierdo.Text = "Izquierdo:"
        '
        'Tb_TobilloDerecho
        '
        Me.Tb_TobilloDerecho.Location = New System.Drawing.Point(71, 13)
        Me.Tb_TobilloDerecho.MaxLength = 100
        Me.Tb_TobilloDerecho.Multiline = True
        Me.Tb_TobilloDerecho.Name = "Tb_TobilloDerecho"
        Me.Tb_TobilloDerecho.Size = New System.Drawing.Size(300, 35)
        Me.Tb_TobilloDerecho.TabIndex = 3
        '
        'Lb_TobilloDerecho
        '
        Me.Lb_TobilloDerecho.AutoSize = True
        Me.Lb_TobilloDerecho.Location = New System.Drawing.Point(6, 16)
        Me.Lb_TobilloDerecho.Name = "Lb_TobilloDerecho"
        Me.Lb_TobilloDerecho.Size = New System.Drawing.Size(51, 13)
        Me.Lb_TobilloDerecho.TabIndex = 0
        Me.Lb_TobilloDerecho.Text = "Derecho:"
        '
        'TP_ExamenFisico4
        '
        Me.TP_ExamenFisico4.Controls.Add(Me.Gb_MiembrosInferiores)
        Me.TP_ExamenFisico4.Controls.Add(Me.Gb_ValoracionMiembrosSuperiores3)
        Me.TP_ExamenFisico4.Location = New System.Drawing.Point(4, 22)
        Me.TP_ExamenFisico4.Name = "TP_ExamenFisico4"
        Me.TP_ExamenFisico4.Size = New System.Drawing.Size(798, 427)
        Me.TP_ExamenFisico4.TabIndex = 6
        Me.TP_ExamenFisico4.Text = "Ex. Físico"
        Me.TP_ExamenFisico4.UseVisualStyleBackColor = True
        '
        'Gb_MiembrosInferiores
        '
        Me.Gb_MiembrosInferiores.Controls.Add(Me.Gb_Rodillas)
        Me.Gb_MiembrosInferiores.Controls.Add(Me.Gb_Caderas)
        Me.Gb_MiembrosInferiores.Location = New System.Drawing.Point(5, 293)
        Me.Gb_MiembrosInferiores.Name = "Gb_MiembrosInferiores"
        Me.Gb_MiembrosInferiores.Size = New System.Drawing.Size(786, 129)
        Me.Gb_MiembrosInferiores.TabIndex = 12
        Me.Gb_MiembrosInferiores.TabStop = False
        Me.Gb_MiembrosInferiores.Text = "Valoración Miembros Inferiores"
        '
        'Gb_Rodillas
        '
        Me.Gb_Rodillas.Controls.Add(Me.Tb_RodillaIzquierda)
        Me.Gb_Rodillas.Controls.Add(Me.Lb_RodillaIzquierda)
        Me.Gb_Rodillas.Controls.Add(Me.Tb_RodillaDerecha)
        Me.Gb_Rodillas.Controls.Add(Me.Lb_RodillaDerecha)
        Me.Gb_Rodillas.Location = New System.Drawing.Point(5, 69)
        Me.Gb_Rodillas.Name = "Gb_Rodillas"
        Me.Gb_Rodillas.Size = New System.Drawing.Size(769, 55)
        Me.Gb_Rodillas.TabIndex = 16
        Me.Gb_Rodillas.TabStop = False
        Me.Gb_Rodillas.Text = "Rodillas"
        '
        'Tb_RodillaIzquierda
        '
        Me.Tb_RodillaIzquierda.Location = New System.Drawing.Point(449, 13)
        Me.Tb_RodillaIzquierda.MaxLength = 100
        Me.Tb_RodillaIzquierda.Multiline = True
        Me.Tb_RodillaIzquierda.Name = "Tb_RodillaIzquierda"
        Me.Tb_RodillaIzquierda.Size = New System.Drawing.Size(300, 35)
        Me.Tb_RodillaIzquierda.TabIndex = 18
        '
        'Lb_RodillaIzquierda
        '
        Me.Lb_RodillaIzquierda.AutoSize = True
        Me.Lb_RodillaIzquierda.Location = New System.Drawing.Point(383, 16)
        Me.Lb_RodillaIzquierda.Name = "Lb_RodillaIzquierda"
        Me.Lb_RodillaIzquierda.Size = New System.Drawing.Size(53, 13)
        Me.Lb_RodillaIzquierda.TabIndex = 2
        Me.Lb_RodillaIzquierda.Text = "Izquierda:"
        '
        'Tb_RodillaDerecha
        '
        Me.Tb_RodillaDerecha.Location = New System.Drawing.Point(70, 13)
        Me.Tb_RodillaDerecha.MaxLength = 100
        Me.Tb_RodillaDerecha.Multiline = True
        Me.Tb_RodillaDerecha.Name = "Tb_RodillaDerecha"
        Me.Tb_RodillaDerecha.Size = New System.Drawing.Size(300, 35)
        Me.Tb_RodillaDerecha.TabIndex = 17
        '
        'Lb_RodillaDerecha
        '
        Me.Lb_RodillaDerecha.AutoSize = True
        Me.Lb_RodillaDerecha.Location = New System.Drawing.Point(6, 16)
        Me.Lb_RodillaDerecha.Name = "Lb_RodillaDerecha"
        Me.Lb_RodillaDerecha.Size = New System.Drawing.Size(51, 13)
        Me.Lb_RodillaDerecha.TabIndex = 0
        Me.Lb_RodillaDerecha.Text = "Derecha:"
        '
        'Gb_Caderas
        '
        Me.Gb_Caderas.Controls.Add(Me.Tb_CaderasIzquierda)
        Me.Gb_Caderas.Controls.Add(Me.Lb_CaderasIzquierda)
        Me.Gb_Caderas.Controls.Add(Me.Tb_CaderasDerecha)
        Me.Gb_Caderas.Controls.Add(Me.Lb_CaderasDerecha)
        Me.Gb_Caderas.Location = New System.Drawing.Point(5, 13)
        Me.Gb_Caderas.Name = "Gb_Caderas"
        Me.Gb_Caderas.Size = New System.Drawing.Size(769, 55)
        Me.Gb_Caderas.TabIndex = 13
        Me.Gb_Caderas.TabStop = False
        Me.Gb_Caderas.Text = "Caderas"
        '
        'Tb_CaderasIzquierda
        '
        Me.Tb_CaderasIzquierda.Location = New System.Drawing.Point(452, 13)
        Me.Tb_CaderasIzquierda.MaxLength = 100
        Me.Tb_CaderasIzquierda.Multiline = True
        Me.Tb_CaderasIzquierda.Name = "Tb_CaderasIzquierda"
        Me.Tb_CaderasIzquierda.Size = New System.Drawing.Size(300, 35)
        Me.Tb_CaderasIzquierda.TabIndex = 15
        '
        'Lb_CaderasIzquierda
        '
        Me.Lb_CaderasIzquierda.AutoSize = True
        Me.Lb_CaderasIzquierda.Location = New System.Drawing.Point(385, 16)
        Me.Lb_CaderasIzquierda.Name = "Lb_CaderasIzquierda"
        Me.Lb_CaderasIzquierda.Size = New System.Drawing.Size(53, 13)
        Me.Lb_CaderasIzquierda.TabIndex = 2
        Me.Lb_CaderasIzquierda.Text = "Izquierda:"
        '
        'Tb_CaderasDerecha
        '
        Me.Tb_CaderasDerecha.Location = New System.Drawing.Point(71, 13)
        Me.Tb_CaderasDerecha.MaxLength = 100
        Me.Tb_CaderasDerecha.Multiline = True
        Me.Tb_CaderasDerecha.Name = "Tb_CaderasDerecha"
        Me.Tb_CaderasDerecha.Size = New System.Drawing.Size(300, 35)
        Me.Tb_CaderasDerecha.TabIndex = 14
        '
        'Lb_CaderasDerecha
        '
        Me.Lb_CaderasDerecha.AutoSize = True
        Me.Lb_CaderasDerecha.Location = New System.Drawing.Point(6, 16)
        Me.Lb_CaderasDerecha.Name = "Lb_CaderasDerecha"
        Me.Lb_CaderasDerecha.Size = New System.Drawing.Size(51, 13)
        Me.Lb_CaderasDerecha.TabIndex = 0
        Me.Lb_CaderasDerecha.Text = "Derecha:"
        '
        'Gb_ValoracionMiembrosSuperiores3
        '
        Me.Gb_ValoracionMiembrosSuperiores3.Controls.Add(Me.Gb_ComentariosEvidenciasMiembrosSuperiores)
        Me.Gb_ValoracionMiembrosSuperiores3.Controls.Add(Me.Gb_DedosManoIzquierda)
        Me.Gb_ValoracionMiembrosSuperiores3.Location = New System.Drawing.Point(5, 5)
        Me.Gb_ValoracionMiembrosSuperiores3.Name = "Gb_ValoracionMiembrosSuperiores3"
        Me.Gb_ValoracionMiembrosSuperiores3.Size = New System.Drawing.Size(786, 287)
        Me.Gb_ValoracionMiembrosSuperiores3.TabIndex = 1
        Me.Gb_ValoracionMiembrosSuperiores3.TabStop = False
        Me.Gb_ValoracionMiembrosSuperiores3.Text = "Valoración Miembros Superiores"
        '
        'Gb_ComentariosEvidenciasMiembrosSuperiores
        '
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores.Controls.Add(Me.Tb_ComentariosMiembrosSuperiores)
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores.Location = New System.Drawing.Point(5, 159)
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores.Name = "Gb_ComentariosEvidenciasMiembrosSuperiores"
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores.Size = New System.Drawing.Size(769, 116)
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores.TabIndex = 8
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores.TabStop = False
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores.Text = "Comentarios De Las Evidencias"
        '
        'Tb_ComentariosMiembrosSuperiores
        '
        Me.Tb_ComentariosMiembrosSuperiores.Location = New System.Drawing.Point(9, 16)
        Me.Tb_ComentariosMiembrosSuperiores.MaxLength = 1000
        Me.Tb_ComentariosMiembrosSuperiores.Multiline = True
        Me.Tb_ComentariosMiembrosSuperiores.Name = "Tb_ComentariosMiembrosSuperiores"
        Me.Tb_ComentariosMiembrosSuperiores.Size = New System.Drawing.Size(750, 94)
        Me.Tb_ComentariosMiembrosSuperiores.TabIndex = 9
        '
        'Gb_DedosManoIzquierda
        '
        Me.Gb_DedosManoIzquierda.Controls.Add(Me.Tb_DedoIzquierdo5)
        Me.Gb_DedosManoIzquierda.Controls.Add(Me.Lb_DedoIzquierdo5)
        Me.Gb_DedosManoIzquierda.Controls.Add(Me.Tb_DedoIzquierdo4)
        Me.Gb_DedosManoIzquierda.Controls.Add(Me.Lb_DedoIzquierdo4)
        Me.Gb_DedosManoIzquierda.Controls.Add(Me.Tb_DedoIzquierdo3)
        Me.Gb_DedosManoIzquierda.Controls.Add(Me.Lb_DedoIzquierdo3)
        Me.Gb_DedosManoIzquierda.Controls.Add(Me.Tb_DedoIzquierdo2)
        Me.Gb_DedosManoIzquierda.Controls.Add(Me.Lb_DedoIzquierdo2)
        Me.Gb_DedosManoIzquierda.Controls.Add(Me.Tb_DedoIzquierdo1)
        Me.Gb_DedosManoIzquierda.Controls.Add(Me.Lb_DedoIzquierdo1)
        Me.Gb_DedosManoIzquierda.Location = New System.Drawing.Point(5, 14)
        Me.Gb_DedosManoIzquierda.Name = "Gb_DedosManoIzquierda"
        Me.Gb_DedosManoIzquierda.Size = New System.Drawing.Size(769, 143)
        Me.Gb_DedosManoIzquierda.TabIndex = 2
        Me.Gb_DedosManoIzquierda.TabStop = False
        Me.Gb_DedosManoIzquierda.Text = "Dedos Mano Izquierda"
        '
        'Tb_DedoIzquierdo5
        '
        Me.Tb_DedoIzquierdo5.Location = New System.Drawing.Point(70, 116)
        Me.Tb_DedoIzquierdo5.MaxLength = 100
        Me.Tb_DedoIzquierdo5.Name = "Tb_DedoIzquierdo5"
        Me.Tb_DedoIzquierdo5.Size = New System.Drawing.Size(684, 20)
        Me.Tb_DedoIzquierdo5.TabIndex = 7
        '
        'Lb_DedoIzquierdo5
        '
        Me.Lb_DedoIzquierdo5.AutoSize = True
        Me.Lb_DedoIzquierdo5.Location = New System.Drawing.Point(6, 120)
        Me.Lb_DedoIzquierdo5.Name = "Lb_DedoIzquierdo5"
        Me.Lb_DedoIzquierdo5.Size = New System.Drawing.Size(45, 13)
        Me.Lb_DedoIzquierdo5.TabIndex = 8
        Me.Lb_DedoIzquierdo5.Text = "Dedo 5:"
        '
        'Tb_DedoIzquierdo4
        '
        Me.Tb_DedoIzquierdo4.Location = New System.Drawing.Point(70, 91)
        Me.Tb_DedoIzquierdo4.MaxLength = 100
        Me.Tb_DedoIzquierdo4.Name = "Tb_DedoIzquierdo4"
        Me.Tb_DedoIzquierdo4.Size = New System.Drawing.Size(684, 20)
        Me.Tb_DedoIzquierdo4.TabIndex = 6
        '
        'Lb_DedoIzquierdo4
        '
        Me.Lb_DedoIzquierdo4.AutoSize = True
        Me.Lb_DedoIzquierdo4.Location = New System.Drawing.Point(6, 95)
        Me.Lb_DedoIzquierdo4.Name = "Lb_DedoIzquierdo4"
        Me.Lb_DedoIzquierdo4.Size = New System.Drawing.Size(45, 13)
        Me.Lb_DedoIzquierdo4.TabIndex = 6
        Me.Lb_DedoIzquierdo4.Text = "Dedo 4:"
        '
        'Tb_DedoIzquierdo3
        '
        Me.Tb_DedoIzquierdo3.Location = New System.Drawing.Point(70, 66)
        Me.Tb_DedoIzquierdo3.MaxLength = 100
        Me.Tb_DedoIzquierdo3.Name = "Tb_DedoIzquierdo3"
        Me.Tb_DedoIzquierdo3.Size = New System.Drawing.Size(684, 20)
        Me.Tb_DedoIzquierdo3.TabIndex = 5
        '
        'Lb_DedoIzquierdo3
        '
        Me.Lb_DedoIzquierdo3.AutoSize = True
        Me.Lb_DedoIzquierdo3.Location = New System.Drawing.Point(6, 70)
        Me.Lb_DedoIzquierdo3.Name = "Lb_DedoIzquierdo3"
        Me.Lb_DedoIzquierdo3.Size = New System.Drawing.Size(45, 13)
        Me.Lb_DedoIzquierdo3.TabIndex = 4
        Me.Lb_DedoIzquierdo3.Text = "Dedo 3:"
        '
        'Tb_DedoIzquierdo2
        '
        Me.Tb_DedoIzquierdo2.Location = New System.Drawing.Point(70, 41)
        Me.Tb_DedoIzquierdo2.MaxLength = 100
        Me.Tb_DedoIzquierdo2.Name = "Tb_DedoIzquierdo2"
        Me.Tb_DedoIzquierdo2.Size = New System.Drawing.Size(684, 20)
        Me.Tb_DedoIzquierdo2.TabIndex = 4
        '
        'Lb_DedoIzquierdo2
        '
        Me.Lb_DedoIzquierdo2.AutoSize = True
        Me.Lb_DedoIzquierdo2.Location = New System.Drawing.Point(6, 45)
        Me.Lb_DedoIzquierdo2.Name = "Lb_DedoIzquierdo2"
        Me.Lb_DedoIzquierdo2.Size = New System.Drawing.Size(45, 13)
        Me.Lb_DedoIzquierdo2.TabIndex = 2
        Me.Lb_DedoIzquierdo2.Text = "Dedo 2:"
        '
        'Tb_DedoIzquierdo1
        '
        Me.Tb_DedoIzquierdo1.Location = New System.Drawing.Point(70, 16)
        Me.Tb_DedoIzquierdo1.MaxLength = 100
        Me.Tb_DedoIzquierdo1.Name = "Tb_DedoIzquierdo1"
        Me.Tb_DedoIzquierdo1.Size = New System.Drawing.Size(684, 20)
        Me.Tb_DedoIzquierdo1.TabIndex = 3
        '
        'Lb_DedoIzquierdo1
        '
        Me.Lb_DedoIzquierdo1.AutoSize = True
        Me.Lb_DedoIzquierdo1.Location = New System.Drawing.Point(6, 20)
        Me.Lb_DedoIzquierdo1.Name = "Lb_DedoIzquierdo1"
        Me.Lb_DedoIzquierdo1.Size = New System.Drawing.Size(45, 13)
        Me.Lb_DedoIzquierdo1.TabIndex = 0
        Me.Lb_DedoIzquierdo1.Text = "Dedo 1:"
        '
        'TP_ExamenFisico3
        '
        Me.TP_ExamenFisico3.Controls.Add(Me.Gb_ValoracionMiembrosSuperiores2)
        Me.TP_ExamenFisico3.Location = New System.Drawing.Point(4, 22)
        Me.TP_ExamenFisico3.Name = "TP_ExamenFisico3"
        Me.TP_ExamenFisico3.Size = New System.Drawing.Size(798, 427)
        Me.TP_ExamenFisico3.TabIndex = 10
        Me.TP_ExamenFisico3.Text = "Ex. Físico"
        Me.TP_ExamenFisico3.UseVisualStyleBackColor = True
        '
        'Gb_ValoracionMiembrosSuperiores2
        '
        Me.Gb_ValoracionMiembrosSuperiores2.Controls.Add(Me.Gb_DedosManoDerecha)
        Me.Gb_ValoracionMiembrosSuperiores2.Controls.Add(Me.Gb_Manos)
        Me.Gb_ValoracionMiembrosSuperiores2.Controls.Add(Me.Gb_Muñecas)
        Me.Gb_ValoracionMiembrosSuperiores2.Controls.Add(Me.Gb_Codos)
        Me.Gb_ValoracionMiembrosSuperiores2.Controls.Add(Me.Gb_Hombros)
        Me.Gb_ValoracionMiembrosSuperiores2.Controls.Add(Me.Tb_FlexoExtension)
        Me.Gb_ValoracionMiembrosSuperiores2.Controls.Add(Me.Lb_FlexoExtension)
        Me.Gb_ValoracionMiembrosSuperiores2.Controls.Add(Me.Tb_RotacionExterna)
        Me.Gb_ValoracionMiembrosSuperiores2.Controls.Add(Me.Lb_RotacionExterna)
        Me.Gb_ValoracionMiembrosSuperiores2.Location = New System.Drawing.Point(5, 5)
        Me.Gb_ValoracionMiembrosSuperiores2.Name = "Gb_ValoracionMiembrosSuperiores2"
        Me.Gb_ValoracionMiembrosSuperiores2.Size = New System.Drawing.Size(786, 418)
        Me.Gb_ValoracionMiembrosSuperiores2.TabIndex = 1
        Me.Gb_ValoracionMiembrosSuperiores2.TabStop = False
        Me.Gb_ValoracionMiembrosSuperiores2.Text = "Valoración Miembros Superiores"
        '
        'Gb_DedosManoDerecha
        '
        Me.Gb_DedosManoDerecha.Controls.Add(Me.Tb_DedoDerecho5)
        Me.Gb_DedosManoDerecha.Controls.Add(Me.Lb_DedoDerecho5)
        Me.Gb_DedosManoDerecha.Controls.Add(Me.Tb_DedoDerecho4)
        Me.Gb_DedosManoDerecha.Controls.Add(Me.Lb_DedoDerecho4)
        Me.Gb_DedosManoDerecha.Controls.Add(Me.Tb_DedoDerecho3)
        Me.Gb_DedosManoDerecha.Controls.Add(Me.Lb_DedoDerecho3)
        Me.Gb_DedosManoDerecha.Controls.Add(Me.Tb_DedoDerecho2)
        Me.Gb_DedosManoDerecha.Controls.Add(Me._DedoDerecho2)
        Me.Gb_DedosManoDerecha.Controls.Add(Me.Tb_DedoDerecho1)
        Me.Gb_DedosManoDerecha.Controls.Add(Me.Lb_DedoDerecho1)
        Me.Gb_DedosManoDerecha.Location = New System.Drawing.Point(5, 279)
        Me.Gb_DedosManoDerecha.Name = "Gb_DedosManoDerecha"
        Me.Gb_DedosManoDerecha.Size = New System.Drawing.Size(773, 134)
        Me.Gb_DedosManoDerecha.TabIndex = 16
        Me.Gb_DedosManoDerecha.TabStop = False
        Me.Gb_DedosManoDerecha.Text = "Dedos Mano Derecha"
        '
        'Tb_DedoDerecho5
        '
        Me.Tb_DedoDerecho5.Location = New System.Drawing.Point(70, 108)
        Me.Tb_DedoDerecho5.MaxLength = 100
        Me.Tb_DedoDerecho5.Name = "Tb_DedoDerecho5"
        Me.Tb_DedoDerecho5.Size = New System.Drawing.Size(697, 20)
        Me.Tb_DedoDerecho5.TabIndex = 21
        '
        'Lb_DedoDerecho5
        '
        Me.Lb_DedoDerecho5.AutoSize = True
        Me.Lb_DedoDerecho5.Location = New System.Drawing.Point(6, 112)
        Me.Lb_DedoDerecho5.Name = "Lb_DedoDerecho5"
        Me.Lb_DedoDerecho5.Size = New System.Drawing.Size(45, 13)
        Me.Lb_DedoDerecho5.TabIndex = 8
        Me.Lb_DedoDerecho5.Text = "Dedo 5:"
        '
        'Tb_DedoDerecho4
        '
        Me.Tb_DedoDerecho4.Location = New System.Drawing.Point(70, 85)
        Me.Tb_DedoDerecho4.MaxLength = 100
        Me.Tb_DedoDerecho4.Name = "Tb_DedoDerecho4"
        Me.Tb_DedoDerecho4.Size = New System.Drawing.Size(697, 20)
        Me.Tb_DedoDerecho4.TabIndex = 20
        '
        'Lb_DedoDerecho4
        '
        Me.Lb_DedoDerecho4.AutoSize = True
        Me.Lb_DedoDerecho4.Location = New System.Drawing.Point(6, 89)
        Me.Lb_DedoDerecho4.Name = "Lb_DedoDerecho4"
        Me.Lb_DedoDerecho4.Size = New System.Drawing.Size(45, 13)
        Me.Lb_DedoDerecho4.TabIndex = 6
        Me.Lb_DedoDerecho4.Text = "Dedo 4:"
        '
        'Tb_DedoDerecho3
        '
        Me.Tb_DedoDerecho3.Location = New System.Drawing.Point(70, 62)
        Me.Tb_DedoDerecho3.MaxLength = 100
        Me.Tb_DedoDerecho3.Name = "Tb_DedoDerecho3"
        Me.Tb_DedoDerecho3.Size = New System.Drawing.Size(697, 20)
        Me.Tb_DedoDerecho3.TabIndex = 19
        '
        'Lb_DedoDerecho3
        '
        Me.Lb_DedoDerecho3.AutoSize = True
        Me.Lb_DedoDerecho3.Location = New System.Drawing.Point(6, 66)
        Me.Lb_DedoDerecho3.Name = "Lb_DedoDerecho3"
        Me.Lb_DedoDerecho3.Size = New System.Drawing.Size(45, 13)
        Me.Lb_DedoDerecho3.TabIndex = 4
        Me.Lb_DedoDerecho3.Text = "Dedo 3:"
        '
        'Tb_DedoDerecho2
        '
        Me.Tb_DedoDerecho2.Location = New System.Drawing.Point(70, 39)
        Me.Tb_DedoDerecho2.MaxLength = 100
        Me.Tb_DedoDerecho2.Name = "Tb_DedoDerecho2"
        Me.Tb_DedoDerecho2.Size = New System.Drawing.Size(697, 20)
        Me.Tb_DedoDerecho2.TabIndex = 18
        '
        '_DedoDerecho2
        '
        Me._DedoDerecho2.AutoSize = True
        Me._DedoDerecho2.Location = New System.Drawing.Point(6, 43)
        Me._DedoDerecho2.Name = "_DedoDerecho2"
        Me._DedoDerecho2.Size = New System.Drawing.Size(45, 13)
        Me._DedoDerecho2.TabIndex = 2
        Me._DedoDerecho2.Text = "Dedo 2:"
        '
        'Tb_DedoDerecho1
        '
        Me.Tb_DedoDerecho1.Location = New System.Drawing.Point(70, 16)
        Me.Tb_DedoDerecho1.MaxLength = 100
        Me.Tb_DedoDerecho1.Name = "Tb_DedoDerecho1"
        Me.Tb_DedoDerecho1.Size = New System.Drawing.Size(697, 20)
        Me.Tb_DedoDerecho1.TabIndex = 17
        '
        'Lb_DedoDerecho1
        '
        Me.Lb_DedoDerecho1.AutoSize = True
        Me.Lb_DedoDerecho1.Location = New System.Drawing.Point(6, 20)
        Me.Lb_DedoDerecho1.Name = "Lb_DedoDerecho1"
        Me.Lb_DedoDerecho1.Size = New System.Drawing.Size(45, 13)
        Me.Lb_DedoDerecho1.TabIndex = 0
        Me.Lb_DedoDerecho1.Text = "Dedo 1:"
        '
        'Gb_Manos
        '
        Me.Gb_Manos.Controls.Add(Me.Tb_ManoIzquierda)
        Me.Gb_Manos.Controls.Add(Me.Lb_ManoIzquierda)
        Me.Gb_Manos.Controls.Add(Me.Tb_ManoDerecha)
        Me.Gb_Manos.Controls.Add(Me.Lb_ManoDerecha)
        Me.Gb_Manos.Location = New System.Drawing.Point(5, 221)
        Me.Gb_Manos.Name = "Gb_Manos"
        Me.Gb_Manos.Size = New System.Drawing.Size(773, 55)
        Me.Gb_Manos.TabIndex = 13
        Me.Gb_Manos.TabStop = False
        Me.Gb_Manos.Text = "Manos"
        '
        'Tb_ManoIzquierda
        '
        Me.Tb_ManoIzquierda.Location = New System.Drawing.Point(467, 13)
        Me.Tb_ManoIzquierda.MaxLength = 100
        Me.Tb_ManoIzquierda.Multiline = True
        Me.Tb_ManoIzquierda.Name = "Tb_ManoIzquierda"
        Me.Tb_ManoIzquierda.Size = New System.Drawing.Size(300, 35)
        Me.Tb_ManoIzquierda.TabIndex = 15
        '
        'Lb_ManoIzquierda
        '
        Me.Lb_ManoIzquierda.AutoSize = True
        Me.Lb_ManoIzquierda.Location = New System.Drawing.Point(401, 17)
        Me.Lb_ManoIzquierda.Name = "Lb_ManoIzquierda"
        Me.Lb_ManoIzquierda.Size = New System.Drawing.Size(53, 13)
        Me.Lb_ManoIzquierda.TabIndex = 2
        Me.Lb_ManoIzquierda.Text = "Izquierda:"
        '
        'Tb_ManoDerecha
        '
        Me.Tb_ManoDerecha.Location = New System.Drawing.Point(70, 13)
        Me.Tb_ManoDerecha.MaxLength = 100
        Me.Tb_ManoDerecha.Multiline = True
        Me.Tb_ManoDerecha.Name = "Tb_ManoDerecha"
        Me.Tb_ManoDerecha.Size = New System.Drawing.Size(300, 35)
        Me.Tb_ManoDerecha.TabIndex = 14
        '
        'Lb_ManoDerecha
        '
        Me.Lb_ManoDerecha.AutoSize = True
        Me.Lb_ManoDerecha.Location = New System.Drawing.Point(6, 17)
        Me.Lb_ManoDerecha.Name = "Lb_ManoDerecha"
        Me.Lb_ManoDerecha.Size = New System.Drawing.Size(51, 13)
        Me.Lb_ManoDerecha.TabIndex = 0
        Me.Lb_ManoDerecha.Text = "Derecha:"
        '
        'Gb_Muñecas
        '
        Me.Gb_Muñecas.Controls.Add(Me.Tb_MuñecaIzquierda)
        Me.Gb_Muñecas.Controls.Add(Me.Lb_MuñecaIzquierda)
        Me.Gb_Muñecas.Controls.Add(Me.Tb_MuñecaDerecha)
        Me.Gb_Muñecas.Controls.Add(Me.Lb_MuñecaDerecha)
        Me.Gb_Muñecas.Location = New System.Drawing.Point(5, 164)
        Me.Gb_Muñecas.Name = "Gb_Muñecas"
        Me.Gb_Muñecas.Size = New System.Drawing.Size(773, 55)
        Me.Gb_Muñecas.TabIndex = 10
        Me.Gb_Muñecas.TabStop = False
        Me.Gb_Muñecas.Text = "Muñecas"
        '
        'Tb_MuñecaIzquierda
        '
        Me.Tb_MuñecaIzquierda.Location = New System.Drawing.Point(467, 13)
        Me.Tb_MuñecaIzquierda.MaxLength = 100
        Me.Tb_MuñecaIzquierda.Multiline = True
        Me.Tb_MuñecaIzquierda.Name = "Tb_MuñecaIzquierda"
        Me.Tb_MuñecaIzquierda.Size = New System.Drawing.Size(300, 35)
        Me.Tb_MuñecaIzquierda.TabIndex = 12
        '
        'Lb_MuñecaIzquierda
        '
        Me.Lb_MuñecaIzquierda.AutoSize = True
        Me.Lb_MuñecaIzquierda.Location = New System.Drawing.Point(401, 17)
        Me.Lb_MuñecaIzquierda.Name = "Lb_MuñecaIzquierda"
        Me.Lb_MuñecaIzquierda.Size = New System.Drawing.Size(53, 13)
        Me.Lb_MuñecaIzquierda.TabIndex = 2
        Me.Lb_MuñecaIzquierda.Text = "Izquierda:"
        '
        'Tb_MuñecaDerecha
        '
        Me.Tb_MuñecaDerecha.Location = New System.Drawing.Point(70, 13)
        Me.Tb_MuñecaDerecha.MaxLength = 100
        Me.Tb_MuñecaDerecha.Multiline = True
        Me.Tb_MuñecaDerecha.Name = "Tb_MuñecaDerecha"
        Me.Tb_MuñecaDerecha.Size = New System.Drawing.Size(300, 35)
        Me.Tb_MuñecaDerecha.TabIndex = 11
        '
        'Lb_MuñecaDerecha
        '
        Me.Lb_MuñecaDerecha.AutoSize = True
        Me.Lb_MuñecaDerecha.Location = New System.Drawing.Point(6, 17)
        Me.Lb_MuñecaDerecha.Name = "Lb_MuñecaDerecha"
        Me.Lb_MuñecaDerecha.Size = New System.Drawing.Size(51, 13)
        Me.Lb_MuñecaDerecha.TabIndex = 0
        Me.Lb_MuñecaDerecha.Text = "Derecha:"
        '
        'Gb_Codos
        '
        Me.Gb_Codos.Controls.Add(Me.Tb_CodoIzquierdo)
        Me.Gb_Codos.Controls.Add(Me.Lb_CodoIzquierdo)
        Me.Gb_Codos.Controls.Add(Me.Tb_CodoDerecho)
        Me.Gb_Codos.Controls.Add(Me.Lb_CodoDerecho)
        Me.Gb_Codos.Location = New System.Drawing.Point(5, 108)
        Me.Gb_Codos.Name = "Gb_Codos"
        Me.Gb_Codos.Size = New System.Drawing.Size(773, 55)
        Me.Gb_Codos.TabIndex = 7
        Me.Gb_Codos.TabStop = False
        Me.Gb_Codos.Text = "Codos"
        '
        'Tb_CodoIzquierdo
        '
        Me.Tb_CodoIzquierdo.Location = New System.Drawing.Point(467, 13)
        Me.Tb_CodoIzquierdo.MaxLength = 100
        Me.Tb_CodoIzquierdo.Multiline = True
        Me.Tb_CodoIzquierdo.Name = "Tb_CodoIzquierdo"
        Me.Tb_CodoIzquierdo.Size = New System.Drawing.Size(300, 35)
        Me.Tb_CodoIzquierdo.TabIndex = 9
        '
        'Lb_CodoIzquierdo
        '
        Me.Lb_CodoIzquierdo.AutoSize = True
        Me.Lb_CodoIzquierdo.Location = New System.Drawing.Point(401, 17)
        Me.Lb_CodoIzquierdo.Name = "Lb_CodoIzquierdo"
        Me.Lb_CodoIzquierdo.Size = New System.Drawing.Size(53, 13)
        Me.Lb_CodoIzquierdo.TabIndex = 2
        Me.Lb_CodoIzquierdo.Text = "Izquierdo:"
        '
        'Tb_CodoDerecho
        '
        Me.Tb_CodoDerecho.Location = New System.Drawing.Point(70, 13)
        Me.Tb_CodoDerecho.MaxLength = 100
        Me.Tb_CodoDerecho.Multiline = True
        Me.Tb_CodoDerecho.Name = "Tb_CodoDerecho"
        Me.Tb_CodoDerecho.Size = New System.Drawing.Size(300, 35)
        Me.Tb_CodoDerecho.TabIndex = 8
        '
        'Lb_CodoDerecho
        '
        Me.Lb_CodoDerecho.AutoSize = True
        Me.Lb_CodoDerecho.Location = New System.Drawing.Point(6, 17)
        Me.Lb_CodoDerecho.Name = "Lb_CodoDerecho"
        Me.Lb_CodoDerecho.Size = New System.Drawing.Size(51, 13)
        Me.Lb_CodoDerecho.TabIndex = 0
        Me.Lb_CodoDerecho.Text = "Derecho:"
        '
        'Gb_Hombros
        '
        Me.Gb_Hombros.Controls.Add(Me.Tb_HombroIzquierdo)
        Me.Gb_Hombros.Controls.Add(Me.Lb_HombroIzquierdo)
        Me.Gb_Hombros.Controls.Add(Me.Tb_HombroDerecho)
        Me.Gb_Hombros.Controls.Add(Me.Lb_HombroDerecho)
        Me.Gb_Hombros.Location = New System.Drawing.Point(5, 52)
        Me.Gb_Hombros.Name = "Gb_Hombros"
        Me.Gb_Hombros.Size = New System.Drawing.Size(773, 55)
        Me.Gb_Hombros.TabIndex = 4
        Me.Gb_Hombros.TabStop = False
        Me.Gb_Hombros.Text = "Hombros"
        '
        'Tb_HombroIzquierdo
        '
        Me.Tb_HombroIzquierdo.Location = New System.Drawing.Point(467, 13)
        Me.Tb_HombroIzquierdo.MaxLength = 100
        Me.Tb_HombroIzquierdo.Multiline = True
        Me.Tb_HombroIzquierdo.Name = "Tb_HombroIzquierdo"
        Me.Tb_HombroIzquierdo.Size = New System.Drawing.Size(300, 35)
        Me.Tb_HombroIzquierdo.TabIndex = 6
        '
        'Lb_HombroIzquierdo
        '
        Me.Lb_HombroIzquierdo.AutoSize = True
        Me.Lb_HombroIzquierdo.Location = New System.Drawing.Point(401, 17)
        Me.Lb_HombroIzquierdo.Name = "Lb_HombroIzquierdo"
        Me.Lb_HombroIzquierdo.Size = New System.Drawing.Size(53, 13)
        Me.Lb_HombroIzquierdo.TabIndex = 2
        Me.Lb_HombroIzquierdo.Text = "Izquierdo:"
        '
        'Tb_HombroDerecho
        '
        Me.Tb_HombroDerecho.Location = New System.Drawing.Point(70, 13)
        Me.Tb_HombroDerecho.MaxLength = 100
        Me.Tb_HombroDerecho.Multiline = True
        Me.Tb_HombroDerecho.Name = "Tb_HombroDerecho"
        Me.Tb_HombroDerecho.Size = New System.Drawing.Size(300, 35)
        Me.Tb_HombroDerecho.TabIndex = 5
        '
        'Lb_HombroDerecho
        '
        Me.Lb_HombroDerecho.AutoSize = True
        Me.Lb_HombroDerecho.Location = New System.Drawing.Point(6, 17)
        Me.Lb_HombroDerecho.Name = "Lb_HombroDerecho"
        Me.Lb_HombroDerecho.Size = New System.Drawing.Size(51, 13)
        Me.Lb_HombroDerecho.TabIndex = 0
        Me.Lb_HombroDerecho.Text = "Derecho:"
        '
        'Tb_FlexoExtension
        '
        Me.Tb_FlexoExtension.Location = New System.Drawing.Point(493, 17)
        Me.Tb_FlexoExtension.MaxLength = 100
        Me.Tb_FlexoExtension.Multiline = True
        Me.Tb_FlexoExtension.Name = "Tb_FlexoExtension"
        Me.Tb_FlexoExtension.Size = New System.Drawing.Size(260, 35)
        Me.Tb_FlexoExtension.TabIndex = 3
        '
        'Lb_FlexoExtension
        '
        Me.Lb_FlexoExtension.AutoSize = True
        Me.Lb_FlexoExtension.Location = New System.Drawing.Point(403, 21)
        Me.Lb_FlexoExtension.Name = "Lb_FlexoExtension"
        Me.Lb_FlexoExtension.Size = New System.Drawing.Size(84, 13)
        Me.Lb_FlexoExtension.TabIndex = 26
        Me.Lb_FlexoExtension.Text = "Flexo Extensión:"
        '
        'Tb_RotacionExterna
        '
        Me.Tb_RotacionExterna.Location = New System.Drawing.Point(110, 17)
        Me.Tb_RotacionExterna.MaxLength = 100
        Me.Tb_RotacionExterna.Multiline = True
        Me.Tb_RotacionExterna.Name = "Tb_RotacionExterna"
        Me.Tb_RotacionExterna.Size = New System.Drawing.Size(260, 35)
        Me.Tb_RotacionExterna.TabIndex = 2
        '
        'Lb_RotacionExterna
        '
        Me.Lb_RotacionExterna.AutoSize = True
        Me.Lb_RotacionExterna.Location = New System.Drawing.Point(12, 21)
        Me.Lb_RotacionExterna.Name = "Lb_RotacionExterna"
        Me.Lb_RotacionExterna.Size = New System.Drawing.Size(92, 13)
        Me.Lb_RotacionExterna.TabIndex = 24
        Me.Lb_RotacionExterna.Text = "Rotación Externa:"
        '
        'TP_ExamenFisico2
        '
        Me.TP_ExamenFisico2.Controls.Add(Me.Gb_ValoracionMiembrosSuperiores)
        Me.TP_ExamenFisico2.Controls.Add(Me.Gb_ExamenColumna2)
        Me.TP_ExamenFisico2.Location = New System.Drawing.Point(4, 22)
        Me.TP_ExamenFisico2.Name = "TP_ExamenFisico2"
        Me.TP_ExamenFisico2.Size = New System.Drawing.Size(798, 427)
        Me.TP_ExamenFisico2.TabIndex = 5
        Me.TP_ExamenFisico2.Text = "Ex. Físico"
        Me.TP_ExamenFisico2.UseVisualStyleBackColor = True
        '
        'Gb_ValoracionMiembrosSuperiores
        '
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Tb_Aduccion)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Lb_Aduccion)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Tb_AbduccionElevacion)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Lb_AbduccionElevacion)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Tb_Circunduccion)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Lb_Circunduccion)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Tb_EjeLongitudinal)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Lb_EjeLongitudinal)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Tb_EjeTransversal)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Lb_EjeTransversal)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Tb_EjeAnteroposterior)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Lb_EjeAnteroposterior)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Tb_Subdeltoidea)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Lb_ArtSubdeltoidea)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Tb_ArtEscapulotorácica)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Lb_ArtEscapulotorácica)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Tb_ArtAcromioclavicular)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Lb_ArtAcromioclavicular)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Tb_ArtEscapulohumeral)
        Me.Gb_ValoracionMiembrosSuperiores.Controls.Add(Me.Lb_ArtEscapulohumeral)
        Me.Gb_ValoracionMiembrosSuperiores.Location = New System.Drawing.Point(5, 178)
        Me.Gb_ValoracionMiembrosSuperiores.Name = "Gb_ValoracionMiembrosSuperiores"
        Me.Gb_ValoracionMiembrosSuperiores.Size = New System.Drawing.Size(786, 243)
        Me.Gb_ValoracionMiembrosSuperiores.TabIndex = 17
        Me.Gb_ValoracionMiembrosSuperiores.TabStop = False
        Me.Gb_ValoracionMiembrosSuperiores.Text = "Valoración Miembros Superiores"
        '
        'Tb_Aduccion
        '
        Me.Tb_Aduccion.Location = New System.Drawing.Point(515, 200)
        Me.Tb_Aduccion.MaxLength = 100
        Me.Tb_Aduccion.Multiline = True
        Me.Tb_Aduccion.Name = "Tb_Aduccion"
        Me.Tb_Aduccion.Size = New System.Drawing.Size(250, 35)
        Me.Tb_Aduccion.TabIndex = 27
        '
        'Lb_Aduccion
        '
        Me.Lb_Aduccion.AutoSize = True
        Me.Lb_Aduccion.Location = New System.Drawing.Point(454, 204)
        Me.Lb_Aduccion.Name = "Lb_Aduccion"
        Me.Lb_Aduccion.Size = New System.Drawing.Size(55, 13)
        Me.Lb_Aduccion.TabIndex = 30
        Me.Lb_Aduccion.Text = "Aducción:"
        '
        'Tb_AbduccionElevacion
        '
        Me.Tb_AbduccionElevacion.Location = New System.Drawing.Point(132, 200)
        Me.Tb_AbduccionElevacion.MaxLength = 100
        Me.Tb_AbduccionElevacion.Multiline = True
        Me.Tb_AbduccionElevacion.Name = "Tb_AbduccionElevacion"
        Me.Tb_AbduccionElevacion.Size = New System.Drawing.Size(250, 35)
        Me.Tb_AbduccionElevacion.TabIndex = 26
        '
        'Lb_AbduccionElevacion
        '
        Me.Lb_AbduccionElevacion.AutoSize = True
        Me.Lb_AbduccionElevacion.Location = New System.Drawing.Point(15, 204)
        Me.Lb_AbduccionElevacion.Name = "Lb_AbduccionElevacion"
        Me.Lb_AbduccionElevacion.Size = New System.Drawing.Size(111, 13)
        Me.Lb_AbduccionElevacion.TabIndex = 28
        Me.Lb_AbduccionElevacion.Text = "Abducción Elevación:"
        '
        'Tb_Circunduccion
        '
        Me.Tb_Circunduccion.Location = New System.Drawing.Point(515, 154)
        Me.Tb_Circunduccion.MaxLength = 100
        Me.Tb_Circunduccion.Multiline = True
        Me.Tb_Circunduccion.Name = "Tb_Circunduccion"
        Me.Tb_Circunduccion.Size = New System.Drawing.Size(250, 35)
        Me.Tb_Circunduccion.TabIndex = 25
        '
        'Lb_Circunduccion
        '
        Me.Lb_Circunduccion.AutoSize = True
        Me.Lb_Circunduccion.Location = New System.Drawing.Point(431, 158)
        Me.Lb_Circunduccion.Name = "Lb_Circunduccion"
        Me.Lb_Circunduccion.Size = New System.Drawing.Size(78, 13)
        Me.Lb_Circunduccion.TabIndex = 26
        Me.Lb_Circunduccion.Text = "Circunducción:"
        '
        'Tb_EjeLongitudinal
        '
        Me.Tb_EjeLongitudinal.Location = New System.Drawing.Point(132, 154)
        Me.Tb_EjeLongitudinal.MaxLength = 100
        Me.Tb_EjeLongitudinal.Multiline = True
        Me.Tb_EjeLongitudinal.Name = "Tb_EjeLongitudinal"
        Me.Tb_EjeLongitudinal.Size = New System.Drawing.Size(250, 35)
        Me.Tb_EjeLongitudinal.TabIndex = 24
        '
        'Lb_EjeLongitudinal
        '
        Me.Lb_EjeLongitudinal.AutoSize = True
        Me.Lb_EjeLongitudinal.Location = New System.Drawing.Point(41, 158)
        Me.Lb_EjeLongitudinal.Name = "Lb_EjeLongitudinal"
        Me.Lb_EjeLongitudinal.Size = New System.Drawing.Size(85, 13)
        Me.Lb_EjeLongitudinal.TabIndex = 24
        Me.Lb_EjeLongitudinal.Text = "Eje Longitudinal:"
        '
        'Tb_EjeTransversal
        '
        Me.Tb_EjeTransversal.Location = New System.Drawing.Point(515, 109)
        Me.Tb_EjeTransversal.MaxLength = 100
        Me.Tb_EjeTransversal.Multiline = True
        Me.Tb_EjeTransversal.Name = "Tb_EjeTransversal"
        Me.Tb_EjeTransversal.Size = New System.Drawing.Size(250, 35)
        Me.Tb_EjeTransversal.TabIndex = 23
        '
        'Lb_EjeTransversal
        '
        Me.Lb_EjeTransversal.AutoSize = True
        Me.Lb_EjeTransversal.Location = New System.Drawing.Point(426, 113)
        Me.Lb_EjeTransversal.Name = "Lb_EjeTransversal"
        Me.Lb_EjeTransversal.Size = New System.Drawing.Size(83, 13)
        Me.Lb_EjeTransversal.TabIndex = 22
        Me.Lb_EjeTransversal.Text = "Eje Transversal:"
        '
        'Tb_EjeAnteroposterior
        '
        Me.Tb_EjeAnteroposterior.Location = New System.Drawing.Point(132, 109)
        Me.Tb_EjeAnteroposterior.MaxLength = 100
        Me.Tb_EjeAnteroposterior.Multiline = True
        Me.Tb_EjeAnteroposterior.Name = "Tb_EjeAnteroposterior"
        Me.Tb_EjeAnteroposterior.Size = New System.Drawing.Size(250, 35)
        Me.Tb_EjeAnteroposterior.TabIndex = 22
        '
        'Lb_EjeAnteroposterior
        '
        Me.Lb_EjeAnteroposterior.AutoSize = True
        Me.Lb_EjeAnteroposterior.Location = New System.Drawing.Point(27, 113)
        Me.Lb_EjeAnteroposterior.Name = "Lb_EjeAnteroposterior"
        Me.Lb_EjeAnteroposterior.Size = New System.Drawing.Size(99, 13)
        Me.Lb_EjeAnteroposterior.TabIndex = 20
        Me.Lb_EjeAnteroposterior.Text = "Eje Anteroposterior:"
        '
        'Tb_Subdeltoidea
        '
        Me.Tb_Subdeltoidea.Location = New System.Drawing.Point(515, 63)
        Me.Tb_Subdeltoidea.MaxLength = 100
        Me.Tb_Subdeltoidea.Multiline = True
        Me.Tb_Subdeltoidea.Name = "Tb_Subdeltoidea"
        Me.Tb_Subdeltoidea.Size = New System.Drawing.Size(250, 35)
        Me.Tb_Subdeltoidea.TabIndex = 21
        '
        'Lb_ArtSubdeltoidea
        '
        Me.Lb_ArtSubdeltoidea.AutoSize = True
        Me.Lb_ArtSubdeltoidea.Location = New System.Drawing.Point(418, 67)
        Me.Lb_ArtSubdeltoidea.Name = "Lb_ArtSubdeltoidea"
        Me.Lb_ArtSubdeltoidea.Size = New System.Drawing.Size(91, 13)
        Me.Lb_ArtSubdeltoidea.TabIndex = 18
        Me.Lb_ArtSubdeltoidea.Text = "Art. Subdeltoidea:"
        '
        'Tb_ArtEscapulotorácica
        '
        Me.Tb_ArtEscapulotorácica.Location = New System.Drawing.Point(132, 63)
        Me.Tb_ArtEscapulotorácica.MaxLength = 100
        Me.Tb_ArtEscapulotorácica.Multiline = True
        Me.Tb_ArtEscapulotorácica.Name = "Tb_ArtEscapulotorácica"
        Me.Tb_ArtEscapulotorácica.Size = New System.Drawing.Size(250, 35)
        Me.Tb_ArtEscapulotorácica.TabIndex = 20
        '
        'Lb_ArtEscapulotorácica
        '
        Me.Lb_ArtEscapulotorácica.AutoSize = True
        Me.Lb_ArtEscapulotorácica.Location = New System.Drawing.Point(15, 67)
        Me.Lb_ArtEscapulotorácica.Name = "Lb_ArtEscapulotorácica"
        Me.Lb_ArtEscapulotorácica.Size = New System.Drawing.Size(111, 13)
        Me.Lb_ArtEscapulotorácica.TabIndex = 16
        Me.Lb_ArtEscapulotorácica.Text = "Art. Escapulotorácica:"
        '
        'Tb_ArtAcromioclavicular
        '
        Me.Tb_ArtAcromioclavicular.Location = New System.Drawing.Point(515, 17)
        Me.Tb_ArtAcromioclavicular.MaxLength = 100
        Me.Tb_ArtAcromioclavicular.Multiline = True
        Me.Tb_ArtAcromioclavicular.Name = "Tb_ArtAcromioclavicular"
        Me.Tb_ArtAcromioclavicular.Size = New System.Drawing.Size(250, 35)
        Me.Tb_ArtAcromioclavicular.TabIndex = 19
        '
        'Lb_ArtAcromioclavicular
        '
        Me.Lb_ArtAcromioclavicular.AutoSize = True
        Me.Lb_ArtAcromioclavicular.Location = New System.Drawing.Point(403, 21)
        Me.Lb_ArtAcromioclavicular.Name = "Lb_ArtAcromioclavicular"
        Me.Lb_ArtAcromioclavicular.Size = New System.Drawing.Size(112, 13)
        Me.Lb_ArtAcromioclavicular.TabIndex = 14
        Me.Lb_ArtAcromioclavicular.Text = "Art. Acromioclavicular:"
        '
        'Tb_ArtEscapulohumeral
        '
        Me.Tb_ArtEscapulohumeral.Location = New System.Drawing.Point(132, 17)
        Me.Tb_ArtEscapulohumeral.MaxLength = 100
        Me.Tb_ArtEscapulohumeral.Multiline = True
        Me.Tb_ArtEscapulohumeral.Name = "Tb_ArtEscapulohumeral"
        Me.Tb_ArtEscapulohumeral.Size = New System.Drawing.Size(250, 35)
        Me.Tb_ArtEscapulohumeral.TabIndex = 18
        '
        'Lb_ArtEscapulohumeral
        '
        Me.Lb_ArtEscapulohumeral.AutoSize = True
        Me.Lb_ArtEscapulohumeral.Location = New System.Drawing.Point(16, 21)
        Me.Lb_ArtEscapulohumeral.Name = "Lb_ArtEscapulohumeral"
        Me.Lb_ArtEscapulohumeral.Size = New System.Drawing.Size(110, 13)
        Me.Lb_ArtEscapulohumeral.TabIndex = 12
        Me.Lb_ArtEscapulohumeral.Text = "Art. Escapulohumeral:"
        '
        'Gb_ExamenColumna2
        '
        Me.Gb_ExamenColumna2.Controls.Add(Me.Gb_TestWells)
        Me.Gb_ExamenColumna2.Controls.Add(Me.Gb_SignoLasegue)
        Me.Gb_ExamenColumna2.Controls.Add(Me.Gb_TestSchober)
        Me.Gb_ExamenColumna2.Location = New System.Drawing.Point(5, 5)
        Me.Gb_ExamenColumna2.Name = "Gb_ExamenColumna2"
        Me.Gb_ExamenColumna2.Size = New System.Drawing.Size(786, 172)
        Me.Gb_ExamenColumna2.TabIndex = 1
        Me.Gb_ExamenColumna2.TabStop = False
        Me.Gb_ExamenColumna2.Text = "Examen De Columna"
        '
        'Gb_TestWells
        '
        Me.Gb_TestWells.Controls.Add(Me.Label13)
        Me.Gb_TestWells.Controls.Add(Me.Label14)
        Me.Gb_TestWells.Controls.Add(Me.Label15)
        Me.Gb_TestWells.Controls.Add(Me.Label16)
        Me.Gb_TestWells.Controls.Add(Me.Label17)
        Me.Gb_TestWells.Controls.Add(Me.Label18)
        Me.Gb_TestWells.Controls.Add(Me.Label19)
        Me.Gb_TestWells.Controls.Add(Me.Label12)
        Me.Gb_TestWells.Controls.Add(Me.Label11)
        Me.Gb_TestWells.Controls.Add(Me.Label10)
        Me.Gb_TestWells.Controls.Add(Me.Label9)
        Me.Gb_TestWells.Controls.Add(Me.Label8)
        Me.Gb_TestWells.Controls.Add(Me.Label7)
        Me.Gb_TestWells.Controls.Add(Me.Label2)
        Me.Gb_TestWells.Controls.Add(Me.Rb_MuyPobre)
        Me.Gb_TestWells.Controls.Add(Me.Rb_Pobre)
        Me.Gb_TestWells.Controls.Add(Me.Rb_Deficiente)
        Me.Gb_TestWells.Controls.Add(Me.Rb_Promedio)
        Me.Gb_TestWells.Controls.Add(Me.Rb_Bueno)
        Me.Gb_TestWells.Controls.Add(Me.Rb_Excelente)
        Me.Gb_TestWells.Controls.Add(Me.Rb_Superior)
        Me.Gb_TestWells.Location = New System.Drawing.Point(5, 100)
        Me.Gb_TestWells.Name = "Gb_TestWells"
        Me.Gb_TestWells.Size = New System.Drawing.Size(775, 67)
        Me.Gb_TestWells.TabIndex = 9
        Me.Gb_TestWells.TabStop = False
        Me.Gb_TestWells.Text = "Test Wells"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(646, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "M: menor -15"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(534, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "M:0 a  -14"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(441, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "M:0 a -7"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(343, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "M:10 a -1"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(236, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 13)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "M:20 a -11"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(119, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 13)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "M:30 a -21"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(27, 48)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(37, 13)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "M:+30"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(646, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "H: menor -20"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(534, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "H:-9 a  -19"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(441, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "H:-1 a -8"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(343, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "H:5 a -0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(236, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "H:16 a -6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(119, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "H:27 a -17"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "H:+27"
        '
        'Rb_MuyPobre
        '
        Me.Rb_MuyPobre.AutoSize = True
        Me.Rb_MuyPobre.Location = New System.Drawing.Point(630, 19)
        Me.Rb_MuyPobre.Name = "Rb_MuyPobre"
        Me.Rb_MuyPobre.Size = New System.Drawing.Size(76, 17)
        Me.Rb_MuyPobre.TabIndex = 16
        Me.Rb_MuyPobre.TabStop = True
        Me.Rb_MuyPobre.Text = "Muy Pobre"
        Me.Rb_MuyPobre.UseVisualStyleBackColor = True
        '
        'Rb_Pobre
        '
        Me.Rb_Pobre.AutoSize = True
        Me.Rb_Pobre.Location = New System.Drawing.Point(518, 19)
        Me.Rb_Pobre.Name = "Rb_Pobre"
        Me.Rb_Pobre.Size = New System.Drawing.Size(53, 17)
        Me.Rb_Pobre.TabIndex = 15
        Me.Rb_Pobre.TabStop = True
        Me.Rb_Pobre.Text = "Pobre"
        Me.Rb_Pobre.UseVisualStyleBackColor = True
        '
        'Rb_Deficiente
        '
        Me.Rb_Deficiente.AutoSize = True
        Me.Rb_Deficiente.Location = New System.Drawing.Point(424, 19)
        Me.Rb_Deficiente.Name = "Rb_Deficiente"
        Me.Rb_Deficiente.Size = New System.Drawing.Size(73, 17)
        Me.Rb_Deficiente.TabIndex = 14
        Me.Rb_Deficiente.TabStop = True
        Me.Rb_Deficiente.Text = "Deficiente"
        Me.Rb_Deficiente.UseVisualStyleBackColor = True
        '
        'Rb_Promedio
        '
        Me.Rb_Promedio.AutoSize = True
        Me.Rb_Promedio.Location = New System.Drawing.Point(327, 19)
        Me.Rb_Promedio.Name = "Rb_Promedio"
        Me.Rb_Promedio.Size = New System.Drawing.Size(69, 17)
        Me.Rb_Promedio.TabIndex = 13
        Me.Rb_Promedio.TabStop = True
        Me.Rb_Promedio.Text = "Promedio"
        Me.Rb_Promedio.UseVisualStyleBackColor = True
        '
        'Rb_Bueno
        '
        Me.Rb_Bueno.AutoSize = True
        Me.Rb_Bueno.Location = New System.Drawing.Point(219, 19)
        Me.Rb_Bueno.Name = "Rb_Bueno"
        Me.Rb_Bueno.Size = New System.Drawing.Size(56, 17)
        Me.Rb_Bueno.TabIndex = 12
        Me.Rb_Bueno.TabStop = True
        Me.Rb_Bueno.Text = "Bueno"
        Me.Rb_Bueno.UseVisualStyleBackColor = True
        '
        'Rb_Excelente
        '
        Me.Rb_Excelente.AutoSize = True
        Me.Rb_Excelente.Location = New System.Drawing.Point(103, 19)
        Me.Rb_Excelente.Name = "Rb_Excelente"
        Me.Rb_Excelente.Size = New System.Drawing.Size(72, 17)
        Me.Rb_Excelente.TabIndex = 11
        Me.Rb_Excelente.TabStop = True
        Me.Rb_Excelente.Text = "Excelente"
        Me.Rb_Excelente.UseVisualStyleBackColor = True
        '
        'Rb_Superior
        '
        Me.Rb_Superior.AutoSize = True
        Me.Rb_Superior.Location = New System.Drawing.Point(9, 19)
        Me.Rb_Superior.Name = "Rb_Superior"
        Me.Rb_Superior.Size = New System.Drawing.Size(64, 17)
        Me.Rb_Superior.TabIndex = 10
        Me.Rb_Superior.TabStop = True
        Me.Rb_Superior.Text = "Superior"
        Me.Rb_Superior.UseVisualStyleBackColor = True
        '
        'Gb_SignoLasegue
        '
        Me.Gb_SignoLasegue.Controls.Add(Me.Rb_Negativo)
        Me.Gb_SignoLasegue.Controls.Add(Me.Rb_Positivo)
        Me.Gb_SignoLasegue.Controls.Add(Me.Tb_Lasegue)
        Me.Gb_SignoLasegue.Location = New System.Drawing.Point(5, 55)
        Me.Gb_SignoLasegue.Name = "Gb_SignoLasegue"
        Me.Gb_SignoLasegue.Size = New System.Drawing.Size(774, 44)
        Me.Gb_SignoLasegue.TabIndex = 5
        Me.Gb_SignoLasegue.TabStop = False
        Me.Gb_SignoLasegue.Text = "Signo Lasegue"
        '
        'Rb_Negativo
        '
        Me.Rb_Negativo.AutoSize = True
        Me.Rb_Negativo.Location = New System.Drawing.Point(95, 16)
        Me.Rb_Negativo.Name = "Rb_Negativo"
        Me.Rb_Negativo.Size = New System.Drawing.Size(68, 17)
        Me.Rb_Negativo.TabIndex = 7
        Me.Rb_Negativo.TabStop = True
        Me.Rb_Negativo.Text = "Negativo"
        Me.Rb_Negativo.UseVisualStyleBackColor = True
        '
        'Rb_Positivo
        '
        Me.Rb_Positivo.AutoSize = True
        Me.Rb_Positivo.Location = New System.Drawing.Point(9, 16)
        Me.Rb_Positivo.Name = "Rb_Positivo"
        Me.Rb_Positivo.Size = New System.Drawing.Size(62, 17)
        Me.Rb_Positivo.TabIndex = 6
        Me.Rb_Positivo.TabStop = True
        Me.Rb_Positivo.Text = "Positivo"
        Me.Rb_Positivo.UseVisualStyleBackColor = True
        '
        'Tb_Lasegue
        '
        Me.Tb_Lasegue.Location = New System.Drawing.Point(182, 15)
        Me.Tb_Lasegue.MaxLength = 100
        Me.Tb_Lasegue.Name = "Tb_Lasegue"
        Me.Tb_Lasegue.Size = New System.Drawing.Size(581, 20)
        Me.Tb_Lasegue.TabIndex = 8
        '
        'Gb_TestSchober
        '
        Me.Gb_TestSchober.Controls.Add(Me.Rb_Menor5cm)
        Me.Gb_TestSchober.Controls.Add(Me.Rb_Mayor5cm)
        Me.Gb_TestSchober.Location = New System.Drawing.Point(5, 15)
        Me.Gb_TestSchober.Name = "Gb_TestSchober"
        Me.Gb_TestSchober.Size = New System.Drawing.Size(175, 39)
        Me.Gb_TestSchober.TabIndex = 2
        Me.Gb_TestSchober.TabStop = False
        Me.Gb_TestSchober.Text = "Test Schober"
        '
        'Rb_Menor5cm
        '
        Me.Rb_Menor5cm.AutoSize = True
        Me.Rb_Menor5cm.Location = New System.Drawing.Point(95, 15)
        Me.Rb_Menor5cm.Name = "Rb_Menor5cm"
        Me.Rb_Menor5cm.Size = New System.Drawing.Size(81, 17)
        Me.Rb_Menor5cm.TabIndex = 4
        Me.Rb_Menor5cm.TabStop = True
        Me.Rb_Menor5cm.Text = "Menor 5 cm"
        Me.Rb_Menor5cm.UseVisualStyleBackColor = True
        '
        'Rb_Mayor5cm
        '
        Me.Rb_Mayor5cm.AutoSize = True
        Me.Rb_Mayor5cm.Location = New System.Drawing.Point(9, 15)
        Me.Rb_Mayor5cm.Name = "Rb_Mayor5cm"
        Me.Rb_Mayor5cm.Size = New System.Drawing.Size(80, 17)
        Me.Rb_Mayor5cm.TabIndex = 3
        Me.Rb_Mayor5cm.TabStop = True
        Me.Rb_Mayor5cm.Text = "Mayor 5 cm"
        Me.Rb_Mayor5cm.UseVisualStyleBackColor = True
        '
        'TP_ExamenFisico1
        '
        Me.TP_ExamenFisico1.Controls.Add(Me.Gb_ExamenColumna)
        Me.TP_ExamenFisico1.Controls.Add(Me.GroupBox1)
        Me.TP_ExamenFisico1.Controls.Add(Me.Gb_SignosVitales)
        Me.TP_ExamenFisico1.Location = New System.Drawing.Point(4, 22)
        Me.TP_ExamenFisico1.Name = "TP_ExamenFisico1"
        Me.TP_ExamenFisico1.Size = New System.Drawing.Size(798, 427)
        Me.TP_ExamenFisico1.TabIndex = 4
        Me.TP_ExamenFisico1.Text = "Ex. Físico"
        Me.TP_ExamenFisico1.UseVisualStyleBackColor = True
        '
        'Gb_ExamenColumna
        '
        Me.Gb_ExamenColumna.Controls.Add(Me.Gb_Movilidad)
        Me.Gb_ExamenColumna.Controls.Add(Me.Gb_Palpacion)
        Me.Gb_ExamenColumna.Controls.Add(Me.Gb_Inspeccion)
        Me.Gb_ExamenColumna.Location = New System.Drawing.Point(5, 171)
        Me.Gb_ExamenColumna.Name = "Gb_ExamenColumna"
        Me.Gb_ExamenColumna.Size = New System.Drawing.Size(786, 253)
        Me.Gb_ExamenColumna.TabIndex = 13
        Me.Gb_ExamenColumna.TabStop = False
        Me.Gb_ExamenColumna.Text = "ExamenColumna"
        '
        'Gb_Movilidad
        '
        Me.Gb_Movilidad.Controls.Add(Me.Tb_Rotacion)
        Me.Gb_Movilidad.Controls.Add(Me.Lb_Rotacion)
        Me.Gb_Movilidad.Controls.Add(Me.Tb_FlexionLateral)
        Me.Gb_Movilidad.Controls.Add(Me.Lb_FlexionLateral)
        Me.Gb_Movilidad.Controls.Add(Me.Tb_Extension)
        Me.Gb_Movilidad.Controls.Add(Me.Label5)
        Me.Gb_Movilidad.Controls.Add(Me.Tb_Flexion)
        Me.Gb_Movilidad.Controls.Add(Me.Label6)
        Me.Gb_Movilidad.Location = New System.Drawing.Point(7, 140)
        Me.Gb_Movilidad.Name = "Gb_Movilidad"
        Me.Gb_Movilidad.Size = New System.Drawing.Size(773, 106)
        Me.Gb_Movilidad.TabIndex = 20
        Me.Gb_Movilidad.TabStop = False
        Me.Gb_Movilidad.Text = "Movilidad"
        '
        'Tb_Rotacion
        '
        Me.Tb_Rotacion.Location = New System.Drawing.Point(467, 59)
        Me.Tb_Rotacion.MaxLength = 100
        Me.Tb_Rotacion.Multiline = True
        Me.Tb_Rotacion.Name = "Tb_Rotacion"
        Me.Tb_Rotacion.Size = New System.Drawing.Size(300, 35)
        Me.Tb_Rotacion.TabIndex = 24
        '
        'Lb_Rotacion
        '
        Me.Lb_Rotacion.AutoSize = True
        Me.Lb_Rotacion.Location = New System.Drawing.Point(408, 63)
        Me.Lb_Rotacion.Name = "Lb_Rotacion"
        Me.Lb_Rotacion.Size = New System.Drawing.Size(53, 13)
        Me.Lb_Rotacion.TabIndex = 6
        Me.Lb_Rotacion.Text = "Rotación:"
        '
        'Tb_FlexionLateral
        '
        Me.Tb_FlexionLateral.Location = New System.Drawing.Point(88, 59)
        Me.Tb_FlexionLateral.MaxLength = 100
        Me.Tb_FlexionLateral.Multiline = True
        Me.Tb_FlexionLateral.Name = "Tb_FlexionLateral"
        Me.Tb_FlexionLateral.Size = New System.Drawing.Size(300, 35)
        Me.Tb_FlexionLateral.TabIndex = 23
        '
        'Lb_FlexionLateral
        '
        Me.Lb_FlexionLateral.AutoSize = True
        Me.Lb_FlexionLateral.Location = New System.Drawing.Point(6, 62)
        Me.Lb_FlexionLateral.Name = "Lb_FlexionLateral"
        Me.Lb_FlexionLateral.Size = New System.Drawing.Size(78, 13)
        Me.Lb_FlexionLateral.TabIndex = 4
        Me.Lb_FlexionLateral.Text = "Flexión Lateral:"
        '
        'Tb_Extension
        '
        Me.Tb_Extension.Location = New System.Drawing.Point(467, 13)
        Me.Tb_Extension.MaxLength = 100
        Me.Tb_Extension.Multiline = True
        Me.Tb_Extension.Name = "Tb_Extension"
        Me.Tb_Extension.Size = New System.Drawing.Size(300, 35)
        Me.Tb_Extension.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(405, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Extensión:"
        '
        'Tb_Flexion
        '
        Me.Tb_Flexion.Location = New System.Drawing.Point(88, 13)
        Me.Tb_Flexion.MaxLength = 100
        Me.Tb_Flexion.Multiline = True
        Me.Tb_Flexion.Name = "Tb_Flexion"
        Me.Tb_Flexion.Size = New System.Drawing.Size(300, 35)
        Me.Tb_Flexion.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Flexión:"
        '
        'Gb_Palpacion
        '
        Me.Gb_Palpacion.Controls.Add(Me.Tb_Espasmo)
        Me.Gb_Palpacion.Controls.Add(Me.Lb_Espasmo)
        Me.Gb_Palpacion.Controls.Add(Me.Tb_Dolor)
        Me.Gb_Palpacion.Controls.Add(Me.Lb_Dolor)
        Me.Gb_Palpacion.Location = New System.Drawing.Point(7, 79)
        Me.Gb_Palpacion.Name = "Gb_Palpacion"
        Me.Gb_Palpacion.Size = New System.Drawing.Size(773, 60)
        Me.Gb_Palpacion.TabIndex = 17
        Me.Gb_Palpacion.TabStop = False
        Me.Gb_Palpacion.Text = "Palpación"
        '
        'Tb_Espasmo
        '
        Me.Tb_Espasmo.Location = New System.Drawing.Point(467, 13)
        Me.Tb_Espasmo.MaxLength = 100
        Me.Tb_Espasmo.Multiline = True
        Me.Tb_Espasmo.Name = "Tb_Espasmo"
        Me.Tb_Espasmo.Size = New System.Drawing.Size(300, 35)
        Me.Tb_Espasmo.TabIndex = 19
        '
        'Lb_Espasmo
        '
        Me.Lb_Espasmo.AutoSize = True
        Me.Lb_Espasmo.Location = New System.Drawing.Point(408, 16)
        Me.Lb_Espasmo.Name = "Lb_Espasmo"
        Me.Lb_Espasmo.Size = New System.Drawing.Size(53, 13)
        Me.Lb_Espasmo.TabIndex = 2
        Me.Lb_Espasmo.Text = "Espasmo:"
        '
        'Tb_Dolor
        '
        Me.Tb_Dolor.Location = New System.Drawing.Point(88, 13)
        Me.Tb_Dolor.MaxLength = 100
        Me.Tb_Dolor.Multiline = True
        Me.Tb_Dolor.Name = "Tb_Dolor"
        Me.Tb_Dolor.Size = New System.Drawing.Size(300, 35)
        Me.Tb_Dolor.TabIndex = 18
        '
        'Lb_Dolor
        '
        Me.Lb_Dolor.AutoSize = True
        Me.Lb_Dolor.Location = New System.Drawing.Point(49, 16)
        Me.Lb_Dolor.Name = "Lb_Dolor"
        Me.Lb_Dolor.Size = New System.Drawing.Size(35, 13)
        Me.Lb_Dolor.TabIndex = 0
        Me.Lb_Dolor.Text = "Dolor:"
        '
        'Gb_Inspeccion
        '
        Me.Gb_Inspeccion.Controls.Add(Me.Tb_Curvatura)
        Me.Gb_Inspeccion.Controls.Add(Me.Lb_Curvatura)
        Me.Gb_Inspeccion.Controls.Add(Me.Tb_Simetria)
        Me.Gb_Inspeccion.Controls.Add(Me.Lb_Simetria)
        Me.Gb_Inspeccion.Location = New System.Drawing.Point(6, 19)
        Me.Gb_Inspeccion.Name = "Gb_Inspeccion"
        Me.Gb_Inspeccion.Size = New System.Drawing.Size(774, 60)
        Me.Gb_Inspeccion.TabIndex = 14
        Me.Gb_Inspeccion.TabStop = False
        Me.Gb_Inspeccion.Text = "Inspección"
        '
        'Tb_Curvatura
        '
        Me.Tb_Curvatura.Location = New System.Drawing.Point(468, 13)
        Me.Tb_Curvatura.MaxLength = 100
        Me.Tb_Curvatura.Multiline = True
        Me.Tb_Curvatura.Name = "Tb_Curvatura"
        Me.Tb_Curvatura.Size = New System.Drawing.Size(300, 35)
        Me.Tb_Curvatura.TabIndex = 16
        '
        'Lb_Curvatura
        '
        Me.Lb_Curvatura.AutoSize = True
        Me.Lb_Curvatura.Location = New System.Drawing.Point(407, 16)
        Me.Lb_Curvatura.Name = "Lb_Curvatura"
        Me.Lb_Curvatura.Size = New System.Drawing.Size(56, 13)
        Me.Lb_Curvatura.TabIndex = 2
        Me.Lb_Curvatura.Text = "Curvatura:"
        '
        'Tb_Simetria
        '
        Me.Tb_Simetria.Location = New System.Drawing.Point(89, 13)
        Me.Tb_Simetria.MaxLength = 100
        Me.Tb_Simetria.Multiline = True
        Me.Tb_Simetria.Name = "Tb_Simetria"
        Me.Tb_Simetria.Size = New System.Drawing.Size(300, 35)
        Me.Tb_Simetria.TabIndex = 15
        '
        'Lb_Simetria
        '
        Me.Lb_Simetria.AutoSize = True
        Me.Lb_Simetria.Location = New System.Drawing.Point(38, 16)
        Me.Lb_Simetria.Name = "Lb_Simetria"
        Me.Lb_Simetria.Size = New System.Drawing.Size(47, 13)
        Me.Lb_Simetria.TabIndex = 0
        Me.Lb_Simetria.Text = "Simetria:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tb_EvidenciasClinicas)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(786, 98)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Evidencias Clinicas"
        '
        'Tb_EvidenciasClinicas
        '
        Me.Tb_EvidenciasClinicas.Location = New System.Drawing.Point(7, 19)
        Me.Tb_EvidenciasClinicas.MaxLength = 700
        Me.Tb_EvidenciasClinicas.Multiline = True
        Me.Tb_EvidenciasClinicas.Name = "Tb_EvidenciasClinicas"
        Me.Tb_EvidenciasClinicas.Size = New System.Drawing.Size(773, 73)
        Me.Tb_EvidenciasClinicas.TabIndex = 12
        '
        'Gb_SignosVitales
        '
        Me.Gb_SignosVitales.Controls.Add(Me.Num_PerimetroAbdomen)
        Me.Gb_SignosVitales.Controls.Add(Me.Num_SO2)
        Me.Gb_SignosVitales.Controls.Add(Me.Num_FR)
        Me.Gb_SignosVitales.Controls.Add(Me.Num_FC)
        Me.Gb_SignosVitales.Controls.Add(Me.Num_TaDiast)
        Me.Gb_SignosVitales.Controls.Add(Me.Num_TaSist)
        Me.Gb_SignosVitales.Controls.Add(Me.Label1)
        Me.Gb_SignosVitales.Controls.Add(Me.Tb_IMC)
        Me.Gb_SignosVitales.Controls.Add(Me.Label3)
        Me.Gb_SignosVitales.Controls.Add(Me.Tb_Talla)
        Me.Gb_SignosVitales.Controls.Add(Me.Label4)
        Me.Gb_SignosVitales.Controls.Add(Me.Tb_Peso)
        Me.Gb_SignosVitales.Controls.Add(Me.Lb_Peso)
        Me.Gb_SignosVitales.Controls.Add(Me.Lb_SO2)
        Me.Gb_SignosVitales.Controls.Add(Me.Lb_FR)
        Me.Gb_SignosVitales.Controls.Add(Me.Lb_FC)
        Me.Gb_SignosVitales.Controls.Add(Me.Lb_TaDiast)
        Me.Gb_SignosVitales.Controls.Add(Me.Lb_TaSist)
        Me.Gb_SignosVitales.Location = New System.Drawing.Point(5, 5)
        Me.Gb_SignosVitales.Name = "Gb_SignosVitales"
        Me.Gb_SignosVitales.Size = New System.Drawing.Size(786, 65)
        Me.Gb_SignosVitales.TabIndex = 1
        Me.Gb_SignosVitales.TabStop = False
        Me.Gb_SignosVitales.Text = "Signos Vitales"
        '
        'Num_PerimetroAbdomen
        '
        Me.Num_PerimetroAbdomen.Location = New System.Drawing.Point(135, 38)
        Me.Num_PerimetroAbdomen.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.Num_PerimetroAbdomen.Name = "Num_PerimetroAbdomen"
        Me.Num_PerimetroAbdomen.Size = New System.Drawing.Size(40, 20)
        Me.Num_PerimetroAbdomen.TabIndex = 10
        '
        'Num_SO2
        '
        Me.Num_SO2.Location = New System.Drawing.Point(396, 13)
        Me.Num_SO2.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.Num_SO2.Name = "Num_SO2"
        Me.Num_SO2.Size = New System.Drawing.Size(40, 20)
        Me.Num_SO2.TabIndex = 6
        '
        'Num_FR
        '
        Me.Num_FR.Location = New System.Drawing.Point(315, 13)
        Me.Num_FR.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Num_FR.Name = "Num_FR"
        Me.Num_FR.Size = New System.Drawing.Size(40, 20)
        Me.Num_FR.TabIndex = 5
        '
        'Num_FC
        '
        Me.Num_FC.Location = New System.Drawing.Point(241, 13)
        Me.Num_FC.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.Num_FC.Name = "Num_FC"
        Me.Num_FC.Size = New System.Drawing.Size(40, 20)
        Me.Num_FC.TabIndex = 4
        '
        'Num_TaDiast
        '
        Me.Num_TaDiast.Location = New System.Drawing.Point(168, 13)
        Me.Num_TaDiast.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.Num_TaDiast.Name = "Num_TaDiast"
        Me.Num_TaDiast.Size = New System.Drawing.Size(40, 20)
        Me.Num_TaDiast.TabIndex = 3
        '
        'Num_TaSist
        '
        Me.Num_TaSist.Location = New System.Drawing.Point(61, 13)
        Me.Num_TaSist.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.Num_TaSist.Name = "Num_TaSist"
        Me.Num_TaSist.Size = New System.Drawing.Size(40, 20)
        Me.Num_TaSist.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Perimetro Abdomen (cm):"
        '
        'Tb_IMC
        '
        Me.Tb_IMC.Location = New System.Drawing.Point(674, 13)
        Me.Tb_IMC.Name = "Tb_IMC"
        Me.Tb_IMC.ReadOnly = True
        Me.Tb_IMC.Size = New System.Drawing.Size(40, 20)
        Me.Tb_IMC.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(640, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "IMC:"
        '
        'Tb_Talla
        '
        Me.Tb_Talla.Location = New System.Drawing.Point(595, 13)
        Me.Tb_Talla.MaxLength = 4
        Me.Tb_Talla.Name = "Tb_Talla"
        Me.Tb_Talla.Size = New System.Drawing.Size(40, 20)
        Me.Tb_Talla.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(543, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Talla(m):"
        '
        'Tb_Peso
        '
        Me.Tb_Peso.Location = New System.Drawing.Point(498, 13)
        Me.Tb_Peso.MaxLength = 6
        Me.Tb_Peso.Name = "Tb_Peso"
        Me.Tb_Peso.Size = New System.Drawing.Size(40, 20)
        Me.Tb_Peso.TabIndex = 7
        '
        'Lb_Peso
        '
        Me.Lb_Peso.AutoSize = True
        Me.Lb_Peso.Location = New System.Drawing.Point(441, 16)
        Me.Lb_Peso.Name = "Lb_Peso"
        Me.Lb_Peso.Size = New System.Drawing.Size(52, 13)
        Me.Lb_Peso.TabIndex = 10
        Me.Lb_Peso.Text = "Peso(kg):"
        '
        'Lb_SO2
        '
        Me.Lb_SO2.AutoSize = True
        Me.Lb_SO2.Location = New System.Drawing.Point(360, 16)
        Me.Lb_SO2.Name = "Lb_SO2"
        Me.Lb_SO2.Size = New System.Drawing.Size(31, 13)
        Me.Lb_SO2.TabIndex = 8
        Me.Lb_SO2.Text = "SO2:"
        '
        'Lb_FR
        '
        Me.Lb_FR.AutoSize = True
        Me.Lb_FR.Location = New System.Drawing.Point(286, 16)
        Me.Lb_FR.Name = "Lb_FR"
        Me.Lb_FR.Size = New System.Drawing.Size(24, 13)
        Me.Lb_FR.TabIndex = 6
        Me.Lb_FR.Text = "FR:"
        '
        'Lb_FC
        '
        Me.Lb_FC.AutoSize = True
        Me.Lb_FC.Location = New System.Drawing.Point(213, 16)
        Me.Lb_FC.Name = "Lb_FC"
        Me.Lb_FC.Size = New System.Drawing.Size(23, 13)
        Me.Lb_FC.TabIndex = 4
        Me.Lb_FC.Text = "FC:"
        '
        'Lb_TaDiast
        '
        Me.Lb_TaDiast.AutoSize = True
        Me.Lb_TaDiast.Location = New System.Drawing.Point(106, 16)
        Me.Lb_TaDiast.Name = "Lb_TaDiast"
        Me.Lb_TaDiast.Size = New System.Drawing.Size(57, 13)
        Me.Lb_TaDiast.TabIndex = 2
        Me.Lb_TaDiast.Text = "T.A. Diast:"
        '
        'Lb_TaSist
        '
        Me.Lb_TaSist.AutoSize = True
        Me.Lb_TaSist.Location = New System.Drawing.Point(6, 16)
        Me.Lb_TaSist.Name = "Lb_TaSist"
        Me.Lb_TaSist.Size = New System.Drawing.Size(50, 13)
        Me.Lb_TaSist.TabIndex = 0
        Me.Lb_TaSist.Text = "T.A. Sist:"
        '
        'TP_AntecedentesPatologicos
        '
        Me.TP_AntecedentesPatologicos.Controls.Add(Me.Gb_RevisionSistemas)
        Me.TP_AntecedentesPatologicos.Controls.Add(Me.Dgv_Habitos)
        Me.TP_AntecedentesPatologicos.Controls.Add(Me.Pn_Habitos)
        Me.TP_AntecedentesPatologicos.Controls.Add(Me.Dgv_Antecedentes)
        Me.TP_AntecedentesPatologicos.Controls.Add(Me.Pn_Antecedentes)
        Me.TP_AntecedentesPatologicos.Location = New System.Drawing.Point(4, 22)
        Me.TP_AntecedentesPatologicos.Name = "TP_AntecedentesPatologicos"
        Me.TP_AntecedentesPatologicos.Size = New System.Drawing.Size(798, 427)
        Me.TP_AntecedentesPatologicos.TabIndex = 3
        Me.TP_AntecedentesPatologicos.Text = "Ante. Patológicos"
        Me.TP_AntecedentesPatologicos.UseVisualStyleBackColor = True
        '
        'Gb_RevisionSistemas
        '
        Me.Gb_RevisionSistemas.Controls.Add(Me.Tb_RevisionSistemas)
        Me.Gb_RevisionSistemas.Location = New System.Drawing.Point(8, 367)
        Me.Gb_RevisionSistemas.Name = "Gb_RevisionSistemas"
        Me.Gb_RevisionSistemas.Size = New System.Drawing.Size(784, 57)
        Me.Gb_RevisionSistemas.TabIndex = 142
        Me.Gb_RevisionSistemas.TabStop = False
        Me.Gb_RevisionSistemas.Text = "Revisión Por Sistemas"
        '
        'Tb_RevisionSistemas
        '
        Me.Tb_RevisionSistemas.Location = New System.Drawing.Point(6, 16)
        Me.Tb_RevisionSistemas.MaxLength = 300
        Me.Tb_RevisionSistemas.Multiline = True
        Me.Tb_RevisionSistemas.Name = "Tb_RevisionSistemas"
        Me.Tb_RevisionSistemas.Size = New System.Drawing.Size(772, 35)
        Me.Tb_RevisionSistemas.TabIndex = 0
        '
        'Dgv_Habitos
        '
        Me.Dgv_Habitos.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Dgv_Habitos.AllowUserToAddRows = False
        Me.Dgv_Habitos.AllowUserToDeleteRows = False
        Me.Dgv_Habitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Habitos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVC_Habitos, Me.DGVCB_Aplica, Me.DGVCT_NumTiempo, Me.DGVC_TIEMPO, Me.DGVC_FrecuenciaHabitos, Me.DGVC_Intensidad, Me.DGVC_AbandonoHabito})
        Me.Dgv_Habitos.Location = New System.Drawing.Point(0, 28)
        Me.Dgv_Habitos.Name = "Dgv_Habitos"
        Me.Dgv_Habitos.Size = New System.Drawing.Size(796, 135)
        Me.Dgv_Habitos.TabIndex = 2
        '
        'DGVC_Habitos
        '
        Me.DGVC_Habitos.DataPropertyName = "IDHABITO"
        Me.DGVC_Habitos.HeaderText = "Habitos"
        Me.DGVC_Habitos.Name = "DGVC_Habitos"
        Me.DGVC_Habitos.ReadOnly = True
        Me.DGVC_Habitos.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_Habitos.Width = 95
        '
        'DGVCB_Aplica
        '
        Me.DGVCB_Aplica.DataPropertyName = "APLICA"
        Me.DGVCB_Aplica.HeaderText = "Aplica"
        Me.DGVCB_Aplica.Name = "DGVCB_Aplica"
        Me.DGVCB_Aplica.Width = 75
        '
        'DGVCT_NumTiempo
        '
        Me.DGVCT_NumTiempo.DataPropertyName = "NUMTIEMPO"
        Me.DGVCT_NumTiempo.HeaderText = "Num Tiempo"
        Me.DGVCT_NumTiempo.Name = "DGVCT_NumTiempo"
        Me.DGVCT_NumTiempo.Width = 90
        '
        'DGVC_TIEMPO
        '
        Me.DGVC_TIEMPO.DataPropertyName = "TIEMPO"
        Me.DGVC_TIEMPO.HeaderText = "Tiempo"
        Me.DGVC_TIEMPO.Name = "DGVC_TIEMPO"
        Me.DGVC_TIEMPO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_TIEMPO.Width = 60
        '
        'DGVC_FrecuenciaHabitos
        '
        Me.DGVC_FrecuenciaHabitos.DataPropertyName = "FRECUENCIA"
        Me.DGVC_FrecuenciaHabitos.HeaderText = "Frecuencia"
        Me.DGVC_FrecuenciaHabitos.Name = "DGVC_FrecuenciaHabitos"
        Me.DGVC_FrecuenciaHabitos.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_FrecuenciaHabitos.Width = 70
        '
        'DGVC_Intensidad
        '
        Me.DGVC_Intensidad.DataPropertyName = "INTENSIDAD"
        Me.DGVC_Intensidad.HeaderText = "Intensidad"
        Me.DGVC_Intensidad.Name = "DGVC_Intensidad"
        Me.DGVC_Intensidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVC_Intensidad.Width = 70
        '
        'DGVC_AbandonoHabito
        '
        Me.DGVC_AbandonoHabito.DataPropertyName = "ABANDONOHABITO"
        Me.DGVC_AbandonoHabito.HeaderText = "Descripción"
        Me.DGVC_AbandonoHabito.MaxInputLength = 50
        Me.DGVC_AbandonoHabito.Name = "DGVC_AbandonoHabito"
        Me.DGVC_AbandonoHabito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVC_AbandonoHabito.Width = 290
        '
        'Pn_Habitos
        '
        Me.Pn_Habitos.BackColor = System.Drawing.Color.Gainsboro
        Me.Pn_Habitos.Controls.Add(Me.Bt_AgregarHabito)
        Me.Pn_Habitos.Controls.Add(Me.Lb_Habitos)
        Me.Pn_Habitos.Location = New System.Drawing.Point(0, 1)
        Me.Pn_Habitos.Name = "Pn_Habitos"
        Me.Pn_Habitos.Size = New System.Drawing.Size(796, 26)
        Me.Pn_Habitos.TabIndex = 141
        '
        'Bt_AgregarHabito
        '
        Me.Bt_AgregarHabito.Location = New System.Drawing.Point(71, 3)
        Me.Bt_AgregarHabito.Name = "Bt_AgregarHabito"
        Me.Bt_AgregarHabito.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarHabito.TabIndex = 1
        Me.Bt_AgregarHabito.Text = "Agregar"
        Me.Bt_AgregarHabito.UseVisualStyleBackColor = True
        '
        'Lb_Habitos
        '
        Me.Lb_Habitos.AutoSize = True
        Me.Lb_Habitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Habitos.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Habitos.Location = New System.Drawing.Point(3, 4)
        Me.Lb_Habitos.Name = "Lb_Habitos"
        Me.Lb_Habitos.Size = New System.Drawing.Size(62, 16)
        Me.Lb_Habitos.TabIndex = 0
        Me.Lb_Habitos.Text = "Habitos"
        Me.Lb_Habitos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_Antecedentes
        '
        Me.Dgv_Antecedentes.AllowUserToAddRows = False
        Me.Dgv_Antecedentes.AllowUserToDeleteRows = False
        Me.Dgv_Antecedentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Antecedentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVC_Antecedentes, Me.DGVC_DescripcionAntecedentes})
        Me.Dgv_Antecedentes.Location = New System.Drawing.Point(0, 191)
        Me.Dgv_Antecedentes.Name = "Dgv_Antecedentes"
        Me.Dgv_Antecedentes.Size = New System.Drawing.Size(796, 170)
        Me.Dgv_Antecedentes.TabIndex = 4
        '
        'DGVC_Antecedentes
        '
        Me.DGVC_Antecedentes.DataPropertyName = "IDANTECEDENTE"
        Me.DGVC_Antecedentes.HeaderText = "Antecedentes"
        Me.DGVC_Antecedentes.Name = "DGVC_Antecedentes"
        Me.DGVC_Antecedentes.ReadOnly = True
        Me.DGVC_Antecedentes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_Antecedentes.Width = 120
        '
        'DGVC_DescripcionAntecedentes
        '
        Me.DGVC_DescripcionAntecedentes.DataPropertyName = "DESCRIPCIONANTECEDENTE"
        Me.DGVC_DescripcionAntecedentes.HeaderText = "Descripcion"
        Me.DGVC_DescripcionAntecedentes.MaxInputLength = 50
        Me.DGVC_DescripcionAntecedentes.Name = "DGVC_DescripcionAntecedentes"
        Me.DGVC_DescripcionAntecedentes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVC_DescripcionAntecedentes.Width = 600
        '
        'Pn_Antecedentes
        '
        Me.Pn_Antecedentes.BackColor = System.Drawing.Color.Gainsboro
        Me.Pn_Antecedentes.Controls.Add(Me.Bt_AgregarAntecedente)
        Me.Pn_Antecedentes.Controls.Add(Me.Lb_Antecedentes)
        Me.Pn_Antecedentes.Location = New System.Drawing.Point(0, 164)
        Me.Pn_Antecedentes.Name = "Pn_Antecedentes"
        Me.Pn_Antecedentes.Size = New System.Drawing.Size(796, 26)
        Me.Pn_Antecedentes.TabIndex = 139
        '
        'Bt_AgregarAntecedente
        '
        Me.Bt_AgregarAntecedente.Location = New System.Drawing.Point(112, 3)
        Me.Bt_AgregarAntecedente.Name = "Bt_AgregarAntecedente"
        Me.Bt_AgregarAntecedente.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarAntecedente.TabIndex = 3
        Me.Bt_AgregarAntecedente.Text = "Agregar"
        Me.Bt_AgregarAntecedente.UseVisualStyleBackColor = True
        '
        'Lb_Antecedentes
        '
        Me.Lb_Antecedentes.AutoSize = True
        Me.Lb_Antecedentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Antecedentes.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Antecedentes.Location = New System.Drawing.Point(3, 4)
        Me.Lb_Antecedentes.Name = "Lb_Antecedentes"
        Me.Lb_Antecedentes.Size = New System.Drawing.Size(103, 16)
        Me.Lb_Antecedentes.TabIndex = 0
        Me.Lb_Antecedentes.Text = "Antecedentes"
        Me.Lb_Antecedentes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TP_Antecedentes
        '
        Me.TP_Antecedentes.Controls.Add(Me.Panel3)
        Me.TP_Antecedentes.Controls.Add(Me.Dgv_Enfermedades)
        Me.TP_Antecedentes.Controls.Add(Me.Dgv_Accidente)
        Me.TP_Antecedentes.Controls.Add(Me.Panel4)
        Me.TP_Antecedentes.Location = New System.Drawing.Point(4, 22)
        Me.TP_Antecedentes.Name = "TP_Antecedentes"
        Me.TP_Antecedentes.Size = New System.Drawing.Size(798, 427)
        Me.TP_Antecedentes.TabIndex = 2
        Me.TP_Antecedentes.Text = "Antecedentes"
        Me.TP_Antecedentes.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.Bt_AgregarEnfermedades)
        Me.Panel3.Controls.Add(Me.Lb_Enfermedades)
        Me.Panel3.Location = New System.Drawing.Point(0, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(796, 26)
        Me.Panel3.TabIndex = 141
        '
        'Bt_AgregarEnfermedades
        '
        Me.Bt_AgregarEnfermedades.Location = New System.Drawing.Point(118, 2)
        Me.Bt_AgregarEnfermedades.Name = "Bt_AgregarEnfermedades"
        Me.Bt_AgregarEnfermedades.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarEnfermedades.TabIndex = 1
        Me.Bt_AgregarEnfermedades.Text = "Agregar"
        Me.Bt_AgregarEnfermedades.UseVisualStyleBackColor = True
        '
        'Lb_Enfermedades
        '
        Me.Lb_Enfermedades.AutoSize = True
        Me.Lb_Enfermedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Enfermedades.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Enfermedades.Location = New System.Drawing.Point(3, 4)
        Me.Lb_Enfermedades.Name = "Lb_Enfermedades"
        Me.Lb_Enfermedades.Size = New System.Drawing.Size(109, 16)
        Me.Lb_Enfermedades.TabIndex = 0
        Me.Lb_Enfermedades.Text = "Enfermedades"
        Me.Lb_Enfermedades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_Enfermedades
        '
        Me.Dgv_Enfermedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Enfermedades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGTB_IDENFERMEDADANTECEDENTES, Me.DGTB_CODIGOENFERMEDADANTECEDENTES, Me.DGVC_Enfermedad, Me.DGVC_OrigenEnfermedad, Me.DGVC_SecuelaEnfermedad, Me.DGVT_TIPODGVENFERMEDAD})
        Me.Dgv_Enfermedades.Location = New System.Drawing.Point(0, 28)
        Me.Dgv_Enfermedades.Name = "Dgv_Enfermedades"
        Me.Dgv_Enfermedades.Size = New System.Drawing.Size(796, 184)
        Me.Dgv_Enfermedades.TabIndex = 2
        '
        'DGTB_IDENFERMEDADANTECEDENTES
        '
        Me.DGTB_IDENFERMEDADANTECEDENTES.DataPropertyName = "IDENFERMEDAD"
        Me.DGTB_IDENFERMEDADANTECEDENTES.HeaderText = "Id"
        Me.DGTB_IDENFERMEDADANTECEDENTES.Name = "DGTB_IDENFERMEDADANTECEDENTES"
        Me.DGTB_IDENFERMEDADANTECEDENTES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGTB_IDENFERMEDADANTECEDENTES.Width = 50
        '
        'DGTB_CODIGOENFERMEDADANTECEDENTES
        '
        Me.DGTB_CODIGOENFERMEDADANTECEDENTES.DataPropertyName = "CODIGOENFERMEDAD"
        Me.DGTB_CODIGOENFERMEDADANTECEDENTES.HeaderText = "Codigo"
        Me.DGTB_CODIGOENFERMEDADANTECEDENTES.MaxInputLength = 4
        Me.DGTB_CODIGOENFERMEDADANTECEDENTES.Name = "DGTB_CODIGOENFERMEDADANTECEDENTES"
        Me.DGTB_CODIGOENFERMEDADANTECEDENTES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGTB_CODIGOENFERMEDADANTECEDENTES.Width = 50
        '
        'DGVC_Enfermedad
        '
        Me.DGVC_Enfermedad.DataPropertyName = "NOMBREENFERMEDAD"
        Me.DGVC_Enfermedad.HeaderText = "Enfermedad"
        Me.DGVC_Enfermedad.MaxInputLength = 150
        Me.DGVC_Enfermedad.Name = "DGVC_Enfermedad"
        Me.DGVC_Enfermedad.ReadOnly = True
        Me.DGVC_Enfermedad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_Enfermedad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVC_Enfermedad.Width = 250
        '
        'DGVC_OrigenEnfermedad
        '
        Me.DGVC_OrigenEnfermedad.DataPropertyName = "ORIGEN"
        Me.DGVC_OrigenEnfermedad.HeaderText = "Origen"
        Me.DGVC_OrigenEnfermedad.Name = "DGVC_OrigenEnfermedad"
        Me.DGVC_OrigenEnfermedad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_OrigenEnfermedad.Width = 80
        '
        'DGVC_SecuelaEnfermedad
        '
        Me.DGVC_SecuelaEnfermedad.DataPropertyName = "SECUELA"
        Me.DGVC_SecuelaEnfermedad.HeaderText = "Secuela"
        Me.DGVC_SecuelaEnfermedad.MaxInputLength = 50
        Me.DGVC_SecuelaEnfermedad.Name = "DGVC_SecuelaEnfermedad"
        Me.DGVC_SecuelaEnfermedad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVC_SecuelaEnfermedad.Width = 320
        '
        'DGVT_TIPODGVENFERMEDAD
        '
        Me.DGVT_TIPODGVENFERMEDAD.DataPropertyName = "TIPO"
        Me.DGVT_TIPODGVENFERMEDAD.HeaderText = "TIPO"
        Me.DGVT_TIPODGVENFERMEDAD.Name = "DGVT_TIPODGVENFERMEDAD"
        Me.DGVT_TIPODGVENFERMEDAD.Visible = False
        '
        'Dgv_Accidente
        '
        Me.Dgv_Accidente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Accidente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVT_IdDgvAccidente, Me.DGVT_CodigoDgvAccidente, Me.DGVC_Accidente, Me.DGVC_OrigenAccidente, Me.DGVT_SecuelaAccidente, Me.DGVT_TIPOACCIDENTE})
        Me.Dgv_Accidente.Location = New System.Drawing.Point(0, 240)
        Me.Dgv_Accidente.Name = "Dgv_Accidente"
        Me.Dgv_Accidente.Size = New System.Drawing.Size(796, 184)
        Me.Dgv_Accidente.TabIndex = 4
        '
        'DGVT_IdDgvAccidente
        '
        Me.DGVT_IdDgvAccidente.DataPropertyName = "IDENFERMEDAD"
        Me.DGVT_IdDgvAccidente.HeaderText = "Id"
        Me.DGVT_IdDgvAccidente.Name = "DGVT_IdDgvAccidente"
        Me.DGVT_IdDgvAccidente.Width = 50
        '
        'DGVT_CodigoDgvAccidente
        '
        Me.DGVT_CodigoDgvAccidente.DataPropertyName = "CODIGOENFERMEDAD"
        Me.DGVT_CodigoDgvAccidente.HeaderText = "Codigo"
        Me.DGVT_CodigoDgvAccidente.MaxInputLength = 4
        Me.DGVT_CodigoDgvAccidente.Name = "DGVT_CodigoDgvAccidente"
        Me.DGVT_CodigoDgvAccidente.Width = 50
        '
        'DGVC_Accidente
        '
        Me.DGVC_Accidente.DataPropertyName = "NOMBREENFERMEDAD"
        Me.DGVC_Accidente.HeaderText = "Accidente"
        Me.DGVC_Accidente.MaxInputLength = 50
        Me.DGVC_Accidente.Name = "DGVC_Accidente"
        Me.DGVC_Accidente.ReadOnly = True
        Me.DGVC_Accidente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_Accidente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVC_Accidente.Width = 250
        '
        'DGVC_OrigenAccidente
        '
        Me.DGVC_OrigenAccidente.DataPropertyName = "ORIGEN"
        Me.DGVC_OrigenAccidente.HeaderText = "Origen"
        Me.DGVC_OrigenAccidente.Name = "DGVC_OrigenAccidente"
        Me.DGVC_OrigenAccidente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_OrigenAccidente.Width = 80
        '
        'DGVT_SecuelaAccidente
        '
        Me.DGVT_SecuelaAccidente.DataPropertyName = "SECUELA"
        Me.DGVT_SecuelaAccidente.HeaderText = "Secuela"
        Me.DGVT_SecuelaAccidente.MaxInputLength = 50
        Me.DGVT_SecuelaAccidente.Name = "DGVT_SecuelaAccidente"
        Me.DGVT_SecuelaAccidente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_SecuelaAccidente.Width = 320
        '
        'DGVT_TIPOACCIDENTE
        '
        Me.DGVT_TIPOACCIDENTE.DataPropertyName = "TIPO"
        Me.DGVT_TIPOACCIDENTE.HeaderText = "Tipo"
        Me.DGVT_TIPOACCIDENTE.Name = "DGVT_TIPOACCIDENTE"
        Me.DGVT_TIPOACCIDENTE.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.Bt_AgregarAccidente)
        Me.Panel4.Controls.Add(Me.Lb_Accidente)
        Me.Panel4.Location = New System.Drawing.Point(0, 213)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(796, 26)
        Me.Panel4.TabIndex = 137
        '
        'Bt_AgregarAccidente
        '
        Me.Bt_AgregarAccidente.Location = New System.Drawing.Point(86, 2)
        Me.Bt_AgregarAccidente.Name = "Bt_AgregarAccidente"
        Me.Bt_AgregarAccidente.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarAccidente.TabIndex = 3
        Me.Bt_AgregarAccidente.Text = "Agregar"
        Me.Bt_AgregarAccidente.UseVisualStyleBackColor = True
        '
        'Lb_Accidente
        '
        Me.Lb_Accidente.AutoSize = True
        Me.Lb_Accidente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Accidente.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Accidente.Location = New System.Drawing.Point(3, 4)
        Me.Lb_Accidente.Name = "Lb_Accidente"
        Me.Lb_Accidente.Size = New System.Drawing.Size(77, 16)
        Me.Lb_Accidente.TabIndex = 0
        Me.Lb_Accidente.Text = "Accidente"
        Me.Lb_Accidente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TP_DescripcionCargo
        '
        Me.TP_DescripcionCargo.Controls.Add(Me.Dgv_AntecedenteLaborales)
        Me.TP_DescripcionCargo.Controls.Add(Me.Dgv_Higiene)
        Me.TP_DescripcionCargo.Controls.Add(Me.Panel2)
        Me.TP_DescripcionCargo.Controls.Add(Me.Dgv_Tareas)
        Me.TP_DescripcionCargo.Controls.Add(Me.Panel1)
        Me.TP_DescripcionCargo.Location = New System.Drawing.Point(4, 22)
        Me.TP_DescripcionCargo.Name = "TP_DescripcionCargo"
        Me.TP_DescripcionCargo.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_DescripcionCargo.Size = New System.Drawing.Size(798, 427)
        Me.TP_DescripcionCargo.TabIndex = 1
        Me.TP_DescripcionCargo.Text = "Desc. Cargo"
        Me.TP_DescripcionCargo.UseVisualStyleBackColor = True
        '
        'Dgv_AntecedenteLaborales
        '
        Me.Dgv_AntecedenteLaborales.AllowUserToAddRows = False
        Me.Dgv_AntecedenteLaborales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_AntecedenteLaborales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVT_NroItem, Me.DGVT_NOMBREEMPRESA, Me.DGVT_TiempoTrabajadoMeses, Me.DGVT_TiempoTrabajadoAños, Me.DGVC_ARL, Me.DGVCK_Incapacidad, Me.DGVC_Origen, Me.DGVT_DiasIncapacidad, Me.DGVT_Secuela, Me.DGVC_Jornada, Me.DGVT_Turno, Me.DGVC_Cargo, Me.Bt_Riesgos})
        Me.Dgv_AntecedenteLaborales.Location = New System.Drawing.Point(0, 240)
        Me.Dgv_AntecedenteLaborales.Name = "Dgv_AntecedenteLaborales"
        Me.Dgv_AntecedenteLaborales.Size = New System.Drawing.Size(796, 184)
        Me.Dgv_AntecedenteLaborales.TabIndex = 142
        '
        'DGVT_NroItem
        '
        Me.DGVT_NroItem.DataPropertyName = "NROITEM"
        Me.DGVT_NroItem.HeaderText = "Item"
        Me.DGVT_NroItem.MaxInputLength = 100
        Me.DGVT_NroItem.Name = "DGVT_NroItem"
        Me.DGVT_NroItem.ReadOnly = True
        Me.DGVT_NroItem.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVT_NroItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_NroItem.Visible = False
        Me.DGVT_NroItem.Width = 40
        '
        'DGVT_NOMBREEMPRESA
        '
        Me.DGVT_NOMBREEMPRESA.DataPropertyName = "NOMBREEMPRESA"
        Me.DGVT_NOMBREEMPRESA.HeaderText = "Nombre Empresa"
        Me.DGVT_NOMBREEMPRESA.MaxInputLength = 50
        Me.DGVT_NOMBREEMPRESA.Name = "DGVT_NOMBREEMPRESA"
        Me.DGVT_NOMBREEMPRESA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DGVT_TiempoTrabajadoMeses
        '
        Me.DGVT_TiempoTrabajadoMeses.DataPropertyName = "TIEMPOTRABAJADOMESES"
        Me.DGVT_TiempoTrabajadoMeses.HeaderText = "T. T. Meses"
        Me.DGVT_TiempoTrabajadoMeses.MaxInputLength = 2
        Me.DGVT_TiempoTrabajadoMeses.Name = "DGVT_TiempoTrabajadoMeses"
        Me.DGVT_TiempoTrabajadoMeses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_TiempoTrabajadoMeses.ToolTipText = "Tiempo Trabajado Meses"
        Me.DGVT_TiempoTrabajadoMeses.Width = 80
        '
        'DGVT_TiempoTrabajadoAños
        '
        Me.DGVT_TiempoTrabajadoAños.DataPropertyName = "TIEMPOTRABAJADOANOS"
        Me.DGVT_TiempoTrabajadoAños.HeaderText = "T. T. Años"
        Me.DGVT_TiempoTrabajadoAños.MaxInputLength = 2
        Me.DGVT_TiempoTrabajadoAños.Name = "DGVT_TiempoTrabajadoAños"
        Me.DGVT_TiempoTrabajadoAños.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_TiempoTrabajadoAños.ToolTipText = "Tiempo Trabajado Años"
        Me.DGVT_TiempoTrabajadoAños.Width = 80
        '
        'DGVC_ARL
        '
        Me.DGVC_ARL.DataPropertyName = "ARL"
        Me.DGVC_ARL.HeaderText = "ARL"
        Me.DGVC_ARL.Name = "DGVC_ARL"
        Me.DGVC_ARL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DGVCK_Incapacidad
        '
        Me.DGVCK_Incapacidad.DataPropertyName = "INCAPACIDAD"
        Me.DGVCK_Incapacidad.FalseValue = "N"
        Me.DGVCK_Incapacidad.HeaderText = "IT"
        Me.DGVCK_Incapacidad.Name = "DGVCK_Incapacidad"
        Me.DGVCK_Incapacidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVCK_Incapacidad.TrueValue = "S"
        Me.DGVCK_Incapacidad.Width = 50
        '
        'DGVC_Origen
        '
        Me.DGVC_Origen.DataPropertyName = "ORIGEN"
        Me.DGVC_Origen.HeaderText = "Origen"
        Me.DGVC_Origen.Name = "DGVC_Origen"
        '
        'DGVT_DiasIncapacidad
        '
        Me.DGVT_DiasIncapacidad.DataPropertyName = "DIASINCAPACIDAD"
        Me.DGVT_DiasIncapacidad.HeaderText = "Días IT"
        Me.DGVT_DiasIncapacidad.MaxInputLength = 5
        Me.DGVT_DiasIncapacidad.Name = "DGVT_DiasIncapacidad"
        Me.DGVT_DiasIncapacidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVT_DiasIncapacidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_DiasIncapacidad.Width = 60
        '
        'DGVT_Secuela
        '
        Me.DGVT_Secuela.DataPropertyName = "SECUELA"
        Me.DGVT_Secuela.HeaderText = "Secuela"
        Me.DGVT_Secuela.MaxInputLength = 50
        Me.DGVT_Secuela.Name = "DGVT_Secuela"
        Me.DGVT_Secuela.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DGVC_Jornada
        '
        Me.DGVC_Jornada.DataPropertyName = "JORNADA"
        Me.DGVC_Jornada.HeaderText = "Jornada"
        Me.DGVC_Jornada.Name = "DGVC_Jornada"
        Me.DGVC_Jornada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DGVT_Turno
        '
        Me.DGVT_Turno.DataPropertyName = "TURNO"
        Me.DGVT_Turno.HeaderText = "Turno"
        Me.DGVT_Turno.MaxInputLength = 2
        Me.DGVT_Turno.Name = "DGVT_Turno"
        Me.DGVT_Turno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_Turno.Width = 50
        '
        'DGVC_Cargo
        '
        Me.DGVC_Cargo.DataPropertyName = "CARGO"
        Me.DGVC_Cargo.HeaderText = "Cargo"
        Me.DGVC_Cargo.Name = "DGVC_Cargo"
        '
        'Bt_Riesgos
        '
        Me.Bt_Riesgos.HeaderText = "Riesgos"
        Me.Bt_Riesgos.Name = "Bt_Riesgos"
        Me.Bt_Riesgos.Text = "Agregar"
        Me.Bt_Riesgos.Width = 50
        '
        'Dgv_Higiene
        '
        Me.Dgv_Higiene.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Higiene.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVC_HigieneIndustrial, Me.DGVC_TLVs, Me.DGVC_Alteracion, Me.DGVC_OrganoBlanco, Me.DGVC_Efecto})
        Me.Dgv_Higiene.Location = New System.Drawing.Point(0, 240)
        Me.Dgv_Higiene.Name = "Dgv_Higiene"
        Me.Dgv_Higiene.Size = New System.Drawing.Size(796, 184)
        Me.Dgv_Higiene.TabIndex = 4
        '
        'DGVC_HigieneIndustrial
        '
        Me.DGVC_HigieneIndustrial.DataPropertyName = "HIGIENE"
        Me.DGVC_HigieneIndustrial.HeaderText = "Higiene Industrial"
        Me.DGVC_HigieneIndustrial.MaxInputLength = 100
        Me.DGVC_HigieneIndustrial.Name = "DGVC_HigieneIndustrial"
        Me.DGVC_HigieneIndustrial.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_HigieneIndustrial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVC_HigieneIndustrial.Width = 300
        '
        'DGVC_TLVs
        '
        Me.DGVC_TLVs.DataPropertyName = "TLVS"
        Me.DGVC_TLVs.HeaderText = "TLV's"
        Me.DGVC_TLVs.MaxInputLength = 10
        Me.DGVC_TLVs.Name = "DGVC_TLVs"
        Me.DGVC_TLVs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DGVC_Alteracion
        '
        Me.DGVC_Alteracion.DataPropertyName = "ALTERACION"
        Me.DGVC_Alteracion.HeaderText = "Alteración"
        Me.DGVC_Alteracion.MaxInputLength = 50
        Me.DGVC_Alteracion.Name = "DGVC_Alteracion"
        Me.DGVC_Alteracion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DGVC_OrganoBlanco
        '
        Me.DGVC_OrganoBlanco.DataPropertyName = "ORGANOBLANCO"
        Me.DGVC_OrganoBlanco.HeaderText = "Órgano Blanco"
        Me.DGVC_OrganoBlanco.MaxInputLength = 50
        Me.DGVC_OrganoBlanco.Name = "DGVC_OrganoBlanco"
        Me.DGVC_OrganoBlanco.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DGVC_Efecto
        '
        Me.DGVC_Efecto.DataPropertyName = "EFECTO"
        Me.DGVC_Efecto.HeaderText = "Efecto"
        Me.DGVC_Efecto.MaxInputLength = 50
        Me.DGVC_Efecto.Name = "DGVC_Efecto"
        Me.DGVC_Efecto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.Bt_AgregarHigieneIndustrial)
        Me.Panel2.Controls.Add(Me.Lb_HigieneIndustrial)
        Me.Panel2.Location = New System.Drawing.Point(0, 213)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(796, 26)
        Me.Panel2.TabIndex = 141
        '
        'Bt_AgregarHigieneIndustrial
        '
        Me.Bt_AgregarHigieneIndustrial.Location = New System.Drawing.Point(138, 2)
        Me.Bt_AgregarHigieneIndustrial.Name = "Bt_AgregarHigieneIndustrial"
        Me.Bt_AgregarHigieneIndustrial.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarHigieneIndustrial.TabIndex = 3
        Me.Bt_AgregarHigieneIndustrial.Text = "Agregar"
        Me.Bt_AgregarHigieneIndustrial.UseVisualStyleBackColor = True
        '
        'Lb_HigieneIndustrial
        '
        Me.Lb_HigieneIndustrial.AutoSize = True
        Me.Lb_HigieneIndustrial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_HigieneIndustrial.ForeColor = System.Drawing.Color.Blue
        Me.Lb_HigieneIndustrial.Location = New System.Drawing.Point(3, 4)
        Me.Lb_HigieneIndustrial.Name = "Lb_HigieneIndustrial"
        Me.Lb_HigieneIndustrial.Size = New System.Drawing.Size(129, 16)
        Me.Lb_HigieneIndustrial.TabIndex = 0
        Me.Lb_HigieneIndustrial.Text = "Higiene Industrial"
        Me.Lb_HigieneIndustrial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_Tareas
        '
        Me.Dgv_Tareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Tareas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVT_Tarea, Me.DGVC_Agente, Me.DGVC_Magnitud, Me.DGVT_Frecuencia})
        Me.Dgv_Tareas.Location = New System.Drawing.Point(0, 27)
        Me.Dgv_Tareas.Name = "Dgv_Tareas"
        Me.Dgv_Tareas.Size = New System.Drawing.Size(796, 184)
        Me.Dgv_Tareas.TabIndex = 2
        '
        'DGVT_Tarea
        '
        Me.DGVT_Tarea.DataPropertyName = "TAREA"
        Me.DGVT_Tarea.HeaderText = "Tarea"
        Me.DGVT_Tarea.MaxInputLength = 100
        Me.DGVT_Tarea.Name = "DGVT_Tarea"
        Me.DGVT_Tarea.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVT_Tarea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_Tarea.Width = 300
        '
        'DGVC_Agente
        '
        Me.DGVC_Agente.DataPropertyName = "AGENTE"
        Me.DGVC_Agente.HeaderText = "Agente"
        Me.DGVC_Agente.Name = "DGVC_Agente"
        Me.DGVC_Agente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_Agente.Width = 250
        '
        'DGVC_Magnitud
        '
        Me.DGVC_Magnitud.DataPropertyName = "MAGNITUD"
        Me.DGVC_Magnitud.HeaderText = "Magnitud"
        Me.DGVC_Magnitud.Name = "DGVC_Magnitud"
        Me.DGVC_Magnitud.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DGVT_Frecuencia
        '
        Me.DGVT_Frecuencia.DataPropertyName = "FRECUENCIA"
        Me.DGVT_Frecuencia.HeaderText = "Frecuencia"
        Me.DGVT_Frecuencia.MaxInputLength = 10
        Me.DGVT_Frecuencia.Name = "DGVT_Frecuencia"
        Me.DGVT_Frecuencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.Bt_AgregarTarea)
        Me.Panel1.Controls.Add(Me.Lb_Tarea)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(796, 25)
        Me.Panel1.TabIndex = 139
        '
        'Bt_AgregarTarea
        '
        Me.Bt_AgregarTarea.Location = New System.Drawing.Point(59, 2)
        Me.Bt_AgregarTarea.Name = "Bt_AgregarTarea"
        Me.Bt_AgregarTarea.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarTarea.TabIndex = 1
        Me.Bt_AgregarTarea.Text = "Agregar"
        Me.Bt_AgregarTarea.UseVisualStyleBackColor = True
        '
        'Lb_Tarea
        '
        Me.Lb_Tarea.AutoSize = True
        Me.Lb_Tarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Tarea.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Tarea.Location = New System.Drawing.Point(3, 4)
        Me.Lb_Tarea.Name = "Lb_Tarea"
        Me.Lb_Tarea.Size = New System.Drawing.Size(50, 16)
        Me.Lb_Tarea.TabIndex = 0
        Me.Lb_Tarea.Text = "Tarea"
        Me.Lb_Tarea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TP_DatosPersonales
        '
        Me.TP_DatosPersonales.Controls.Add(Me.Gb_TipoExamen)
        Me.TP_DatosPersonales.Controls.Add(Me.Gb_DatosPersonales)
        Me.TP_DatosPersonales.Controls.Add(Me.Cu_Vacuna1)
        Me.TP_DatosPersonales.Location = New System.Drawing.Point(4, 22)
        Me.TP_DatosPersonales.Name = "TP_DatosPersonales"
        Me.TP_DatosPersonales.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_DatosPersonales.Size = New System.Drawing.Size(798, 427)
        Me.TP_DatosPersonales.TabIndex = 0
        Me.TP_DatosPersonales.Text = "Datos Personales"
        Me.TP_DatosPersonales.UseVisualStyleBackColor = True
        '
        'Gb_TipoExamen
        '
        Me.Gb_TipoExamen.Controls.Add(Me.Rb_ExamenPeriodico)
        Me.Gb_TipoExamen.Controls.Add(Me.Rb_ExamenEgreso)
        Me.Gb_TipoExamen.Controls.Add(Me.Rb_ExamenIngreso)
        Me.Gb_TipoExamen.Location = New System.Drawing.Point(6, 4)
        Me.Gb_TipoExamen.Name = "Gb_TipoExamen"
        Me.Gb_TipoExamen.Size = New System.Drawing.Size(231, 36)
        Me.Gb_TipoExamen.TabIndex = 1
        Me.Gb_TipoExamen.TabStop = False
        Me.Gb_TipoExamen.Text = "Tipo De Examen"
        '
        'Rb_ExamenPeriodico
        '
        Me.Rb_ExamenPeriodico.AutoSize = True
        Me.Rb_ExamenPeriodico.Location = New System.Drawing.Point(154, 13)
        Me.Rb_ExamenPeriodico.Name = "Rb_ExamenPeriodico"
        Me.Rb_ExamenPeriodico.Size = New System.Drawing.Size(69, 17)
        Me.Rb_ExamenPeriodico.TabIndex = 4
        Me.Rb_ExamenPeriodico.TabStop = True
        Me.Rb_ExamenPeriodico.Text = "Periódico"
        Me.Rb_ExamenPeriodico.UseVisualStyleBackColor = True
        '
        'Rb_ExamenEgreso
        '
        Me.Rb_ExamenEgreso.AutoSize = True
        Me.Rb_ExamenEgreso.Location = New System.Drawing.Point(81, 14)
        Me.Rb_ExamenEgreso.Name = "Rb_ExamenEgreso"
        Me.Rb_ExamenEgreso.Size = New System.Drawing.Size(58, 17)
        Me.Rb_ExamenEgreso.TabIndex = 3
        Me.Rb_ExamenEgreso.TabStop = True
        Me.Rb_ExamenEgreso.Text = "Egreso"
        Me.Rb_ExamenEgreso.UseVisualStyleBackColor = True
        '
        'Rb_ExamenIngreso
        '
        Me.Rb_ExamenIngreso.AutoSize = True
        Me.Rb_ExamenIngreso.Location = New System.Drawing.Point(6, 14)
        Me.Rb_ExamenIngreso.Name = "Rb_ExamenIngreso"
        Me.Rb_ExamenIngreso.Size = New System.Drawing.Size(60, 17)
        Me.Rb_ExamenIngreso.TabIndex = 2
        Me.Rb_ExamenIngreso.TabStop = True
        Me.Rb_ExamenIngreso.Text = "Ingreso"
        Me.Rb_ExamenIngreso.UseVisualStyleBackColor = True
        '
        'Gb_DatosPersonales
        '
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_MunicipioContrato)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cu_CiudadContrato)
        Me.Gb_DatosPersonales.Controls.Add(Me.Gb_Riesgo)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_TipoCargo)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_Cargo)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cu_AsociarPersonaReporte)
        Me.Gb_DatosPersonales.Controls.Add(Me.Num_Turnos)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cu_BuscarPersonaExamenMedico)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_EPS)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_EPS)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_AFP)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_FondoPensiones)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_GrupoSanguineo)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_TipoSangre)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_Turnos)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_Jornada)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_Jornada)
        Me.Gb_DatosPersonales.Controls.Add(Me.Num_CargoMeses)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_TiempoCargoMeses)
        Me.Gb_DatosPersonales.Controls.Add(Me.Num_CargoAños)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_TiempoCargoAños)
        Me.Gb_DatosPersonales.Controls.Add(Me.Dtp_FechaIngreso)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_FechaIngreso)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_TipoCargo)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_Cargo)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_Dependencia)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_Dependencia)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_Base)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_Base)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_Proyecto)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_Proyecto)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_Dominancia)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_Dominancia)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_EstadoCivil)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_EstadoCivil)
        Me.Gb_DatosPersonales.Controls.Add(Me.Cb_NivelAcademico)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_NivelAcademico)
        Me.Gb_DatosPersonales.Controls.Add(Me.Tb_Edad)
        Me.Gb_DatosPersonales.Controls.Add(Me.Gb_Genero)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_Edad)
        Me.Gb_DatosPersonales.Controls.Add(Me.Lb_Nombre)
        Me.Gb_DatosPersonales.Location = New System.Drawing.Point(6, 46)
        Me.Gb_DatosPersonales.Name = "Gb_DatosPersonales"
        Me.Gb_DatosPersonales.Size = New System.Drawing.Size(786, 210)
        Me.Gb_DatosPersonales.TabIndex = 5
        Me.Gb_DatosPersonales.TabStop = False
        Me.Gb_DatosPersonales.Text = "Datos Personales"
        '
        'Lb_MunicipioContrato
        '
        Me.Lb_MunicipioContrato.AutoSize = True
        Me.Lb_MunicipioContrato.Location = New System.Drawing.Point(9, 123)
        Me.Lb_MunicipioContrato.Name = "Lb_MunicipioContrato"
        Me.Lb_MunicipioContrato.Size = New System.Drawing.Size(103, 13)
        Me.Lb_MunicipioContrato.TabIndex = 112
        Me.Lb_MunicipioContrato.Text = "Ciudad De Contrato:"
        '
        'Gb_Riesgo
        '
        Me.Gb_Riesgo.Controls.Add(Me.Cb_Locativo)
        Me.Gb_Riesgo.Controls.Add(Me.Cb_Natural)
        Me.Gb_Riesgo.Controls.Add(Me.Cb_Quimico)
        Me.Gb_Riesgo.Controls.Add(Me.Cb_Fisico)
        Me.Gb_Riesgo.Controls.Add(Me.Cb_Seguridad)
        Me.Gb_Riesgo.Controls.Add(Me.Cb_Biológico)
        Me.Gb_Riesgo.Controls.Add(Me.Cb_Psicosocial)
        Me.Gb_Riesgo.Controls.Add(Me.Cb_Biomecanico)
        Me.Gb_Riesgo.Location = New System.Drawing.Point(9, 167)
        Me.Gb_Riesgo.Name = "Gb_Riesgo"
        Me.Gb_Riesgo.Size = New System.Drawing.Size(771, 38)
        Me.Gb_Riesgo.TabIndex = 29
        Me.Gb_Riesgo.TabStop = False
        Me.Gb_Riesgo.Text = "Riesgo"
        '
        'Cb_Locativo
        '
        Me.Cb_Locativo.AutoSize = True
        Me.Cb_Locativo.Checked = True
        Me.Cb_Locativo.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Cb_Locativo.Location = New System.Drawing.Point(698, 15)
        Me.Cb_Locativo.Name = "Cb_Locativo"
        Me.Cb_Locativo.Size = New System.Drawing.Size(67, 17)
        Me.Cb_Locativo.TabIndex = 37
        Me.Cb_Locativo.Text = "Locativo"
        Me.Cb_Locativo.UseVisualStyleBackColor = True
        '
        'Cb_Natural
        '
        Me.Cb_Natural.AutoSize = True
        Me.Cb_Natural.Checked = True
        Me.Cb_Natural.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Cb_Natural.Location = New System.Drawing.Point(609, 15)
        Me.Cb_Natural.Name = "Cb_Natural"
        Me.Cb_Natural.Size = New System.Drawing.Size(60, 17)
        Me.Cb_Natural.TabIndex = 36
        Me.Cb_Natural.Text = "Natural"
        Me.Cb_Natural.UseVisualStyleBackColor = True
        '
        'Cb_Quimico
        '
        Me.Cb_Quimico.AutoSize = True
        Me.Cb_Quimico.Checked = True
        Me.Cb_Quimico.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Cb_Quimico.Location = New System.Drawing.Point(516, 15)
        Me.Cb_Quimico.Name = "Cb_Quimico"
        Me.Cb_Quimico.Size = New System.Drawing.Size(66, 17)
        Me.Cb_Quimico.TabIndex = 35
        Me.Cb_Quimico.Text = "Químico"
        Me.Cb_Quimico.UseVisualStyleBackColor = True
        '
        'Cb_Fisico
        '
        Me.Cb_Fisico.AutoSize = True
        Me.Cb_Fisico.Checked = True
        Me.Cb_Fisico.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Cb_Fisico.Location = New System.Drawing.Point(434, 15)
        Me.Cb_Fisico.Name = "Cb_Fisico"
        Me.Cb_Fisico.Size = New System.Drawing.Size(55, 17)
        Me.Cb_Fisico.TabIndex = 34
        Me.Cb_Fisico.Text = "Físico"
        Me.Cb_Fisico.UseVisualStyleBackColor = True
        '
        'Cb_Seguridad
        '
        Me.Cb_Seguridad.AutoSize = True
        Me.Cb_Seguridad.Checked = True
        Me.Cb_Seguridad.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Cb_Seguridad.Location = New System.Drawing.Point(331, 15)
        Me.Cb_Seguridad.Name = "Cb_Seguridad"
        Me.Cb_Seguridad.Size = New System.Drawing.Size(74, 17)
        Me.Cb_Seguridad.TabIndex = 33
        Me.Cb_Seguridad.Text = "Seguridad"
        Me.Cb_Seguridad.UseVisualStyleBackColor = True
        '
        'Cb_Biológico
        '
        Me.Cb_Biológico.AutoSize = True
        Me.Cb_Biológico.Checked = True
        Me.Cb_Biológico.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Cb_Biológico.Location = New System.Drawing.Point(233, 15)
        Me.Cb_Biológico.Name = "Cb_Biológico"
        Me.Cb_Biológico.Size = New System.Drawing.Size(69, 17)
        Me.Cb_Biológico.TabIndex = 32
        Me.Cb_Biológico.Text = "Biológico"
        Me.Cb_Biológico.UseVisualStyleBackColor = True
        '
        'Cb_Psicosocial
        '
        Me.Cb_Psicosocial.AutoSize = True
        Me.Cb_Psicosocial.Checked = True
        Me.Cb_Psicosocial.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Cb_Psicosocial.Location = New System.Drawing.Point(125, 15)
        Me.Cb_Psicosocial.Name = "Cb_Psicosocial"
        Me.Cb_Psicosocial.Size = New System.Drawing.Size(79, 17)
        Me.Cb_Psicosocial.TabIndex = 31
        Me.Cb_Psicosocial.Text = "Psicosocial"
        Me.Cb_Psicosocial.UseVisualStyleBackColor = True
        '
        'Cb_Biomecanico
        '
        Me.Cb_Biomecanico.AutoSize = True
        Me.Cb_Biomecanico.Checked = True
        Me.Cb_Biomecanico.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Cb_Biomecanico.Location = New System.Drawing.Point(9, 15)
        Me.Cb_Biomecanico.Name = "Cb_Biomecanico"
        Me.Cb_Biomecanico.Size = New System.Drawing.Size(87, 17)
        Me.Cb_Biomecanico.TabIndex = 30
        Me.Cb_Biomecanico.Text = "Biomecánico"
        Me.Cb_Biomecanico.UseVisualStyleBackColor = True
        '
        'Cb_TipoCargo
        '
        Me.Cb_TipoCargo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoCargo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoCargo.FormattingEnabled = True
        Me.Cb_TipoCargo.Location = New System.Drawing.Point(442, 92)
        Me.Cb_TipoCargo.Name = "Cb_TipoCargo"
        Me.Cb_TipoCargo.Size = New System.Drawing.Size(119, 21)
        Me.Cb_TipoCargo.TabIndex = 19
        '
        'Cb_Cargo
        '
        Me.Cb_Cargo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Cargo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Cargo.FormattingEnabled = True
        Me.Cb_Cargo.Location = New System.Drawing.Point(116, 92)
        Me.Cb_Cargo.Name = "Cb_Cargo"
        Me.Cb_Cargo.Size = New System.Drawing.Size(241, 21)
        Me.Cb_Cargo.TabIndex = 18
        '
        'Num_Turnos
        '
        Me.Num_Turnos.Location = New System.Drawing.Point(274, 146)
        Me.Num_Turnos.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.Num_Turnos.Minimum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.Num_Turnos.Name = "Num_Turnos"
        Me.Num_Turnos.Size = New System.Drawing.Size(44, 20)
        Me.Num_Turnos.TabIndex = 25
        Me.Num_Turnos.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Cb_EPS
        '
        Me.Cb_EPS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_EPS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_EPS.FormattingEnabled = True
        Me.Cb_EPS.Location = New System.Drawing.Point(645, 146)
        Me.Cb_EPS.Name = "Cb_EPS"
        Me.Cb_EPS.Size = New System.Drawing.Size(133, 21)
        Me.Cb_EPS.TabIndex = 28
        '
        'Lb_EPS
        '
        Me.Lb_EPS.AutoSize = True
        Me.Lb_EPS.Location = New System.Drawing.Point(606, 150)
        Me.Lb_EPS.Name = "Lb_EPS"
        Me.Lb_EPS.Size = New System.Drawing.Size(31, 13)
        Me.Lb_EPS.TabIndex = 110
        Me.Lb_EPS.Text = "EPS:"
        '
        'Cb_AFP
        '
        Me.Cb_AFP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_AFP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_AFP.FormattingEnabled = True
        Me.Cb_AFP.Location = New System.Drawing.Point(479, 146)
        Me.Cb_AFP.Name = "Cb_AFP"
        Me.Cb_AFP.Size = New System.Drawing.Size(119, 21)
        Me.Cb_AFP.TabIndex = 27
        '
        'Lb_FondoPensiones
        '
        Me.Lb_FondoPensiones.AutoSize = True
        Me.Lb_FondoPensiones.Location = New System.Drawing.Point(412, 150)
        Me.Lb_FondoPensiones.Name = "Lb_FondoPensiones"
        Me.Lb_FondoPensiones.Size = New System.Drawing.Size(59, 13)
        Me.Lb_FondoPensiones.TabIndex = 108
        Me.Lb_FondoPensiones.Text = "Pensiones:"
        '
        'Cb_GrupoSanguineo
        '
        Me.Cb_GrupoSanguineo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_GrupoSanguineo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_GrupoSanguineo.FormattingEnabled = True
        Me.Cb_GrupoSanguineo.Location = New System.Drawing.Point(360, 146)
        Me.Cb_GrupoSanguineo.Name = "Cb_GrupoSanguineo"
        Me.Cb_GrupoSanguineo.Size = New System.Drawing.Size(44, 21)
        Me.Cb_GrupoSanguineo.TabIndex = 26
        '
        'Lb_TipoSangre
        '
        Me.Lb_TipoSangre.AutoSize = True
        Me.Lb_TipoSangre.Location = New System.Drawing.Point(326, 150)
        Me.Lb_TipoSangre.Name = "Lb_TipoSangre"
        Me.Lb_TipoSangre.Size = New System.Drawing.Size(26, 13)
        Me.Lb_TipoSangre.TabIndex = 106
        Me.Lb_TipoSangre.Text = "RH:"
        '
        'Lb_Turnos
        '
        Me.Lb_Turnos.AutoSize = True
        Me.Lb_Turnos.Location = New System.Drawing.Point(198, 150)
        Me.Lb_Turnos.Name = "Lb_Turnos"
        Me.Lb_Turnos.Size = New System.Drawing.Size(68, 13)
        Me.Lb_Turnos.TabIndex = 104
        Me.Lb_Turnos.Text = "Turnos (Hrs):"
        '
        'Cb_Jornada
        '
        Me.Cb_Jornada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Jornada.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Jornada.FormattingEnabled = True
        Me.Cb_Jornada.Location = New System.Drawing.Point(71, 146)
        Me.Cb_Jornada.Name = "Cb_Jornada"
        Me.Cb_Jornada.Size = New System.Drawing.Size(119, 21)
        Me.Cb_Jornada.TabIndex = 24
        '
        'Lb_Jornada
        '
        Me.Lb_Jornada.AutoSize = True
        Me.Lb_Jornada.Location = New System.Drawing.Point(15, 150)
        Me.Lb_Jornada.Name = "Lb_Jornada"
        Me.Lb_Jornada.Size = New System.Drawing.Size(48, 13)
        Me.Lb_Jornada.TabIndex = 102
        Me.Lb_Jornada.Text = "Jornada:"
        '
        'Num_CargoMeses
        '
        Me.Num_CargoMeses.Location = New System.Drawing.Point(736, 119)
        Me.Num_CargoMeses.Maximum = New Decimal(New Integer() {11, 0, 0, 0})
        Me.Num_CargoMeses.Name = "Num_CargoMeses"
        Me.Num_CargoMeses.Size = New System.Drawing.Size(44, 20)
        Me.Num_CargoMeses.TabIndex = 23
        '
        'Lb_TiempoCargoMeses
        '
        Me.Lb_TiempoCargoMeses.AutoSize = True
        Me.Lb_TiempoCargoMeses.Location = New System.Drawing.Point(618, 123)
        Me.Lb_TiempoCargoMeses.Name = "Lb_TiempoCargoMeses"
        Me.Lb_TiempoCargoMeses.Size = New System.Drawing.Size(114, 13)
        Me.Lb_TiempoCargoMeses.TabIndex = 100
        Me.Lb_TiempoCargoMeses.Text = "Tiempo cargo (meses):"
        '
        'Num_CargoAños
        '
        Me.Num_CargoAños.Location = New System.Drawing.Point(517, 119)
        Me.Num_CargoAños.Name = "Num_CargoAños"
        Me.Num_CargoAños.Size = New System.Drawing.Size(44, 20)
        Me.Num_CargoAños.TabIndex = 22
        '
        'Lb_TiempoCargoAños
        '
        Me.Lb_TiempoCargoAños.AutoSize = True
        Me.Lb_TiempoCargoAños.Location = New System.Drawing.Point(406, 123)
        Me.Lb_TiempoCargoAños.Name = "Lb_TiempoCargoAños"
        Me.Lb_TiempoCargoAños.Size = New System.Drawing.Size(107, 13)
        Me.Lb_TiempoCargoAños.TabIndex = 98
        Me.Lb_TiempoCargoAños.Text = "Tiempo cargo (años):"
        '
        'Dtp_FechaIngreso
        '
        Me.Dtp_FechaIngreso.Checked = False
        Me.Dtp_FechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaIngreso.Location = New System.Drawing.Point(646, 92)
        Me.Dtp_FechaIngreso.Name = "Dtp_FechaIngreso"
        Me.Dtp_FechaIngreso.ShowCheckBox = True
        Me.Dtp_FechaIngreso.Size = New System.Drawing.Size(133, 20)
        Me.Dtp_FechaIngreso.TabIndex = 20
        '
        'Lb_FechaIngreso
        '
        Me.Lb_FechaIngreso.AutoSize = True
        Me.Lb_FechaIngreso.Location = New System.Drawing.Point(564, 96)
        Me.Lb_FechaIngreso.Name = "Lb_FechaIngreso"
        Me.Lb_FechaIngreso.Size = New System.Drawing.Size(78, 13)
        Me.Lb_FechaIngreso.TabIndex = 96
        Me.Lb_FechaIngreso.Text = "Fecha Ingreso:"
        '
        'Lb_TipoCargo
        '
        Me.Lb_TipoCargo.AutoSize = True
        Me.Lb_TipoCargo.Location = New System.Drawing.Point(375, 96)
        Me.Lb_TipoCargo.Name = "Lb_TipoCargo"
        Me.Lb_TipoCargo.Size = New System.Drawing.Size(62, 13)
        Me.Lb_TipoCargo.TabIndex = 94
        Me.Lb_TipoCargo.Text = "Tipo Cargo:"
        '
        'Lb_Cargo
        '
        Me.Lb_Cargo.AutoSize = True
        Me.Lb_Cargo.Location = New System.Drawing.Point(74, 96)
        Me.Lb_Cargo.Name = "Lb_Cargo"
        Me.Lb_Cargo.Size = New System.Drawing.Size(38, 13)
        Me.Lb_Cargo.TabIndex = 92
        Me.Lb_Cargo.Text = "Cargo:"
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Dependencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.ItemHeight = 13
        Me.Cb_Dependencia.Location = New System.Drawing.Point(646, 65)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(133, 21)
        Me.Cb_Dependencia.TabIndex = 17
        '
        'Lb_Dependencia
        '
        Me.Lb_Dependencia.AutoSize = True
        Me.Lb_Dependencia.Location = New System.Drawing.Point(568, 69)
        Me.Lb_Dependencia.Name = "Lb_Dependencia"
        Me.Lb_Dependencia.Size = New System.Drawing.Size(74, 13)
        Me.Lb_Dependencia.TabIndex = 90
        Me.Lb_Dependencia.Text = "Dependencia:"
        '
        'Cb_Base
        '
        Me.Cb_Base.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Base.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Base.FormattingEnabled = True
        Me.Cb_Base.Location = New System.Drawing.Point(116, 65)
        Me.Cb_Base.Name = "Cb_Base"
        Me.Cb_Base.Size = New System.Drawing.Size(241, 21)
        Me.Cb_Base.TabIndex = 15
        '
        'Lb_Base
        '
        Me.Lb_Base.AutoSize = True
        Me.Lb_Base.Location = New System.Drawing.Point(78, 69)
        Me.Lb_Base.Name = "Lb_Base"
        Me.Lb_Base.Size = New System.Drawing.Size(34, 13)
        Me.Lb_Base.TabIndex = 88
        Me.Lb_Base.Text = "Base:"
        '
        'Cb_Proyecto
        '
        Me.Cb_Proyecto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Proyecto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Proyecto.FormattingEnabled = True
        Me.Cb_Proyecto.Location = New System.Drawing.Point(441, 65)
        Me.Cb_Proyecto.Name = "Cb_Proyecto"
        Me.Cb_Proyecto.Size = New System.Drawing.Size(119, 21)
        Me.Cb_Proyecto.TabIndex = 16
        '
        'Lb_Proyecto
        '
        Me.Lb_Proyecto.AutoSize = True
        Me.Lb_Proyecto.Location = New System.Drawing.Point(385, 69)
        Me.Lb_Proyecto.Name = "Lb_Proyecto"
        Me.Lb_Proyecto.Size = New System.Drawing.Size(52, 13)
        Me.Lb_Proyecto.TabIndex = 86
        Me.Lb_Proyecto.Text = "Proyecto:"
        '
        'Cb_Dominancia
        '
        Me.Cb_Dominancia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Dominancia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Dominancia.FormattingEnabled = True
        Me.Cb_Dominancia.Location = New System.Drawing.Point(646, 39)
        Me.Cb_Dominancia.Name = "Cb_Dominancia"
        Me.Cb_Dominancia.Size = New System.Drawing.Size(133, 21)
        Me.Cb_Dominancia.TabIndex = 14
        '
        'Lb_Dominancia
        '
        Me.Lb_Dominancia.AutoSize = True
        Me.Lb_Dominancia.Location = New System.Drawing.Point(576, 43)
        Me.Lb_Dominancia.Name = "Lb_Dominancia"
        Me.Lb_Dominancia.Size = New System.Drawing.Size(66, 13)
        Me.Lb_Dominancia.TabIndex = 84
        Me.Lb_Dominancia.Text = "Dominancia:"
        '
        'Cb_EstadoCivil
        '
        Me.Cb_EstadoCivil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_EstadoCivil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_EstadoCivil.FormattingEnabled = True
        Me.Cb_EstadoCivil.Location = New System.Drawing.Point(441, 39)
        Me.Cb_EstadoCivil.Name = "Cb_EstadoCivil"
        Me.Cb_EstadoCivil.Size = New System.Drawing.Size(119, 21)
        Me.Cb_EstadoCivil.TabIndex = 13
        '
        'Lb_EstadoCivil
        '
        Me.Lb_EstadoCivil.AutoSize = True
        Me.Lb_EstadoCivil.Location = New System.Drawing.Point(372, 43)
        Me.Lb_EstadoCivil.Name = "Lb_EstadoCivil"
        Me.Lb_EstadoCivil.Size = New System.Drawing.Size(65, 13)
        Me.Lb_EstadoCivil.TabIndex = 82
        Me.Lb_EstadoCivil.Text = "Estado Civil:"
        '
        'Cb_NivelAcademico
        '
        Me.Cb_NivelAcademico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_NivelAcademico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_NivelAcademico.FormattingEnabled = True
        Me.Cb_NivelAcademico.ItemHeight = 13
        Me.Cb_NivelAcademico.Location = New System.Drawing.Point(116, 39)
        Me.Cb_NivelAcademico.Name = "Cb_NivelAcademico"
        Me.Cb_NivelAcademico.Size = New System.Drawing.Size(241, 21)
        Me.Cb_NivelAcademico.TabIndex = 12
        '
        'Lb_NivelAcademico
        '
        Me.Lb_NivelAcademico.AutoSize = True
        Me.Lb_NivelAcademico.Location = New System.Drawing.Point(22, 43)
        Me.Lb_NivelAcademico.Name = "Lb_NivelAcademico"
        Me.Lb_NivelAcademico.Size = New System.Drawing.Size(90, 13)
        Me.Lb_NivelAcademico.TabIndex = 80
        Me.Lb_NivelAcademico.Text = "Nivel Académico:"
        '
        'Tb_Edad
        '
        Me.Tb_Edad.Location = New System.Drawing.Point(518, 13)
        Me.Tb_Edad.MaxLength = 3
        Me.Tb_Edad.Name = "Tb_Edad"
        Me.Tb_Edad.Size = New System.Drawing.Size(42, 20)
        Me.Tb_Edad.TabIndex = 8
        '
        'Gb_Genero
        '
        Me.Gb_Genero.Controls.Add(Me.Label60)
        Me.Gb_Genero.Controls.Add(Me.Rb_Femenino)
        Me.Gb_Genero.Controls.Add(Me.Rb_Masculino)
        Me.Gb_Genero.Location = New System.Drawing.Point(577, 5)
        Me.Gb_Genero.Name = "Gb_Genero"
        Me.Gb_Genero.Size = New System.Drawing.Size(203, 31)
        Me.Gb_Genero.TabIndex = 9
        Me.Gb_Genero.TabStop = False
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(3, 12)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(45, 13)
        Me.Label60.TabIndex = 79
        Me.Label60.Text = "Genero:"
        '
        'Rb_Femenino
        '
        Me.Rb_Femenino.AutoSize = True
        Me.Rb_Femenino.Location = New System.Drawing.Point(131, 10)
        Me.Rb_Femenino.Name = "Rb_Femenino"
        Me.Rb_Femenino.Size = New System.Drawing.Size(71, 17)
        Me.Rb_Femenino.TabIndex = 11
        Me.Rb_Femenino.TabStop = True
        Me.Rb_Femenino.Text = "Femenino"
        Me.Rb_Femenino.UseVisualStyleBackColor = True
        '
        'Rb_Masculino
        '
        Me.Rb_Masculino.AutoSize = True
        Me.Rb_Masculino.Location = New System.Drawing.Point(55, 10)
        Me.Rb_Masculino.Name = "Rb_Masculino"
        Me.Rb_Masculino.Size = New System.Drawing.Size(73, 17)
        Me.Rb_Masculino.TabIndex = 10
        Me.Rb_Masculino.TabStop = True
        Me.Rb_Masculino.Text = "Masculino"
        Me.Rb_Masculino.UseVisualStyleBackColor = True
        '
        'Lb_Edad
        '
        Me.Lb_Edad.AutoSize = True
        Me.Lb_Edad.Location = New System.Drawing.Point(478, 17)
        Me.Lb_Edad.Name = "Lb_Edad"
        Me.Lb_Edad.Size = New System.Drawing.Size(35, 13)
        Me.Lb_Edad.TabIndex = 2
        Me.Lb_Edad.Text = "Edad:"
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Location = New System.Drawing.Point(65, 18)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(47, 13)
        Me.Lb_Nombre.TabIndex = 0
        Me.Lb_Nombre.Text = "Nombre:"
        '
        'TC_ExamenMedicoPeriodico
        '
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_DatosPersonales)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_DescripcionCargo)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_Antecedentes)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_AntecedentesPatologicos)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_ExamenFisico1)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_ExamenFisico2)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_ExamenFisico3)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_ExamenFisico4)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_ExamenFisico5)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_ExamenAuditivo)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_ExamenComplementario)
        Me.TC_ExamenMedicoPeriodico.Controls.Add(Me.TP_ImpresionDiagnostica)
        Me.TC_ExamenMedicoPeriodico.Location = New System.Drawing.Point(0, -1)
        Me.TC_ExamenMedicoPeriodico.Name = "TC_ExamenMedicoPeriodico"
        Me.TC_ExamenMedicoPeriodico.SelectedIndex = 0
        Me.TC_ExamenMedicoPeriodico.Size = New System.Drawing.Size(806, 453)
        Me.TC_ExamenMedicoPeriodico.TabIndex = 0
        '
        'TP_ExamenComplementario
        '
        Me.TP_ExamenComplementario.Controls.Add(Me.Gb_ExamenesComplementarios)
        Me.TP_ExamenComplementario.Location = New System.Drawing.Point(4, 22)
        Me.TP_ExamenComplementario.Name = "TP_ExamenComplementario"
        Me.TP_ExamenComplementario.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_ExamenComplementario.Size = New System.Drawing.Size(798, 427)
        Me.TP_ExamenComplementario.TabIndex = 11
        Me.TP_ExamenComplementario.Text = "Ex. Comp."
        Me.TP_ExamenComplementario.UseVisualStyleBackColor = True
        '
        'Gb_ExamenesComplementarios
        '
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Lb_ObsFR)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Lb_ObsGlicemia)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Gb_FuncionHepatica)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Label24)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Tb_EKGConclusion)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Tb_FuncionRenalConcepto)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Tb_GlicemiaConcepto)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.GroupBox3)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Tb_Glicemia)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Gb_Visiometria)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Gb_Psicofarmacos)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Tb_FuncionRenal)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Gb_ParcialOrina)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Gb_Quimica)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Gb_CuadroHematico)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Cb_EKG)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Cb_Espirometria)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Lb_Glicemia)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Cb_Audiometria)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Lb_FuncionRenal)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Lb_Audiometria)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Lb_Espirometría)
        Me.Gb_ExamenesComplementarios.Controls.Add(Me.Lb_EKG)
        Me.Gb_ExamenesComplementarios.Location = New System.Drawing.Point(8, 6)
        Me.Gb_ExamenesComplementarios.Name = "Gb_ExamenesComplementarios"
        Me.Gb_ExamenesComplementarios.Size = New System.Drawing.Size(784, 415)
        Me.Gb_ExamenesComplementarios.TabIndex = 25
        Me.Gb_ExamenesComplementarios.TabStop = False
        Me.Gb_ExamenesComplementarios.Text = "Estudios clínicos y paraclinicos"
        '
        'Lb_ObsFR
        '
        Me.Lb_ObsFR.AutoSize = True
        Me.Lb_ObsFR.Location = New System.Drawing.Point(533, 116)
        Me.Lb_ObsFR.Name = "Lb_ObsFR"
        Me.Lb_ObsFR.Size = New System.Drawing.Size(70, 13)
        Me.Lb_ObsFR.TabIndex = 66
        Me.Lb_ObsFR.Text = "Observacion:"
        '
        'Lb_ObsGlicemia
        '
        Me.Lb_ObsGlicemia.AutoSize = True
        Me.Lb_ObsGlicemia.Location = New System.Drawing.Point(136, 117)
        Me.Lb_ObsGlicemia.Name = "Lb_ObsGlicemia"
        Me.Lb_ObsGlicemia.Size = New System.Drawing.Size(70, 13)
        Me.Lb_ObsGlicemia.TabIndex = 65
        Me.Lb_ObsGlicemia.Text = "Observacion:"
        '
        'Gb_FuncionHepatica
        '
        Me.Gb_FuncionHepatica.Controls.Add(Me.Lb_ObsFH)
        Me.Gb_FuncionHepatica.Controls.Add(Me.Lb_ALT)
        Me.Gb_FuncionHepatica.Controls.Add(Me.Tb_FuncionHepaticaALT)
        Me.Gb_FuncionHepatica.Controls.Add(Me.Lb_AST)
        Me.Gb_FuncionHepatica.Controls.Add(Me.Tb_FuncionHepaticaAST)
        Me.Gb_FuncionHepatica.Controls.Add(Me.Tb_FuncionHepaticaConcepto)
        Me.Gb_FuncionHepatica.Location = New System.Drawing.Point(6, 136)
        Me.Gb_FuncionHepatica.Name = "Gb_FuncionHepatica"
        Me.Gb_FuncionHepatica.Size = New System.Drawing.Size(511, 41)
        Me.Gb_FuncionHepatica.TabIndex = 27
        Me.Gb_FuncionHepatica.TabStop = False
        Me.Gb_FuncionHepatica.Text = "Función Hepática"
        '
        'Lb_ObsFH
        '
        Me.Lb_ObsFH.AutoSize = True
        Me.Lb_ObsFH.Location = New System.Drawing.Point(268, 19)
        Me.Lb_ObsFH.Name = "Lb_ObsFH"
        Me.Lb_ObsFH.Size = New System.Drawing.Size(70, 13)
        Me.Lb_ObsFH.TabIndex = 67
        Me.Lb_ObsFH.Text = "Observacion:"
        '
        'Lb_ALT
        '
        Me.Lb_ALT.AutoSize = True
        Me.Lb_ALT.Location = New System.Drawing.Point(139, 18)
        Me.Lb_ALT.Name = "Lb_ALT"
        Me.Lb_ALT.Size = New System.Drawing.Size(57, 13)
        Me.Lb_ALT.TabIndex = 32
        Me.Lb_ALT.Text = "ALT/GPT:"
        '
        'Tb_FuncionHepaticaALT
        '
        Me.Tb_FuncionHepaticaALT.Location = New System.Drawing.Point(207, 15)
        Me.Tb_FuncionHepaticaALT.MaxLength = 20
        Me.Tb_FuncionHepaticaALT.Name = "Tb_FuncionHepaticaALT"
        Me.Tb_FuncionHepaticaALT.Size = New System.Drawing.Size(50, 20)
        Me.Tb_FuncionHepaticaALT.TabIndex = 29
        '
        'Lb_AST
        '
        Me.Lb_AST.AutoSize = True
        Me.Lb_AST.Location = New System.Drawing.Point(8, 19)
        Me.Lb_AST.Name = "Lb_AST"
        Me.Lb_AST.Size = New System.Drawing.Size(59, 13)
        Me.Lb_AST.TabIndex = 30
        Me.Lb_AST.Text = "AST/GOT:"
        '
        'Tb_FuncionHepaticaAST
        '
        Me.Tb_FuncionHepaticaAST.Location = New System.Drawing.Point(78, 15)
        Me.Tb_FuncionHepaticaAST.MaxLength = 20
        Me.Tb_FuncionHepaticaAST.Name = "Tb_FuncionHepaticaAST"
        Me.Tb_FuncionHepaticaAST.Size = New System.Drawing.Size(50, 20)
        Me.Tb_FuncionHepaticaAST.TabIndex = 28
        '
        'Tb_FuncionHepaticaConcepto
        '
        Me.Tb_FuncionHepaticaConcepto.Location = New System.Drawing.Point(349, 15)
        Me.Tb_FuncionHepaticaConcepto.MaxLength = 50
        Me.Tb_FuncionHepaticaConcepto.Name = "Tb_FuncionHepaticaConcepto"
        Me.Tb_FuncionHepaticaConcepto.Size = New System.Drawing.Size(150, 20)
        Me.Tb_FuncionHepaticaConcepto.TabIndex = 30
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(273, 323)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(87, 13)
        Me.Label24.TabIndex = 61
        Me.Label24.Text = "Conclusion EKG:"
        '
        'Tb_EKGConclusion
        '
        Me.Tb_EKGConclusion.Location = New System.Drawing.Point(367, 319)
        Me.Tb_EKGConclusion.MaxLength = 50
        Me.Tb_EKGConclusion.Name = "Tb_EKGConclusion"
        Me.Tb_EKGConclusion.Size = New System.Drawing.Size(309, 20)
        Me.Tb_EKGConclusion.TabIndex = 62
        '
        'Tb_FuncionRenalConcepto
        '
        Me.Tb_FuncionRenalConcepto.Location = New System.Drawing.Point(615, 112)
        Me.Tb_FuncionRenalConcepto.MaxLength = 50
        Me.Tb_FuncionRenalConcepto.Name = "Tb_FuncionRenalConcepto"
        Me.Tb_FuncionRenalConcepto.Size = New System.Drawing.Size(150, 20)
        Me.Tb_FuncionRenalConcepto.TabIndex = 26
        '
        'Tb_GlicemiaConcepto
        '
        Me.Tb_GlicemiaConcepto.Location = New System.Drawing.Point(218, 113)
        Me.Tb_GlicemiaConcepto.MaxLength = 50
        Me.Tb_GlicemiaConcepto.Name = "Tb_GlicemiaConcepto"
        Me.Tb_GlicemiaConcepto.Size = New System.Drawing.Size(150, 20)
        Me.Tb_GlicemiaConcepto.TabIndex = 23
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Tb_ImagenesDiagnosticas)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 345)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(769, 65)
        Me.GroupBox3.TabIndex = 63
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Imágenes Diagnósticas"
        '
        'Tb_ImagenesDiagnosticas
        '
        Me.Tb_ImagenesDiagnosticas.Location = New System.Drawing.Point(6, 15)
        Me.Tb_ImagenesDiagnosticas.MaxLength = 500
        Me.Tb_ImagenesDiagnosticas.Multiline = True
        Me.Tb_ImagenesDiagnosticas.Name = "Tb_ImagenesDiagnosticas"
        Me.Tb_ImagenesDiagnosticas.Size = New System.Drawing.Size(757, 45)
        Me.Tb_ImagenesDiagnosticas.TabIndex = 64
        '
        'Tb_Glicemia
        '
        Me.Tb_Glicemia.Location = New System.Drawing.Point(74, 113)
        Me.Tb_Glicemia.MaxLength = 20
        Me.Tb_Glicemia.Name = "Tb_Glicemia"
        Me.Tb_Glicemia.Size = New System.Drawing.Size(50, 20)
        Me.Tb_Glicemia.TabIndex = 22
        '
        'Gb_Visiometria
        '
        Me.Gb_Visiometria.Controls.Add(Me.Tb_OtrasAlteracionesVisuales)
        Me.Gb_Visiometria.Controls.Add(Me.Lb_OtrasAlt)
        Me.Gb_Visiometria.Controls.Add(Me.Ck_VConjuntiva)
        Me.Gb_Visiometria.Controls.Add(Me.Ck_VParpados)
        Me.Gb_Visiometria.Controls.Add(Me.Ck_VMovilidad)
        Me.Gb_Visiometria.Controls.Add(Me.Ck_VLejos)
        Me.Gb_Visiometria.Controls.Add(Me.Ck_VCerca)
        Me.Gb_Visiometria.Controls.Add(Me.Ck_VNormal)
        Me.Gb_Visiometria.Location = New System.Drawing.Point(274, 224)
        Me.Gb_Visiometria.Name = "Gb_Visiometria"
        Me.Gb_Visiometria.Size = New System.Drawing.Size(504, 63)
        Me.Gb_Visiometria.TabIndex = 46
        Me.Gb_Visiometria.TabStop = False
        Me.Gb_Visiometria.Text = "Visiometria"
        '
        'Tb_OtrasAlteracionesVisuales
        '
        Me.Tb_OtrasAlteracionesVisuales.Location = New System.Drawing.Point(113, 38)
        Me.Tb_OtrasAlteracionesVisuales.MaxLength = 50
        Me.Tb_OtrasAlteracionesVisuales.Name = "Tb_OtrasAlteracionesVisuales"
        Me.Tb_OtrasAlteracionesVisuales.Size = New System.Drawing.Size(382, 20)
        Me.Tb_OtrasAlteracionesVisuales.TabIndex = 54
        '
        'Lb_OtrasAlt
        '
        Me.Lb_OtrasAlt.AutoSize = True
        Me.Lb_OtrasAlt.Location = New System.Drawing.Point(11, 41)
        Me.Lb_OtrasAlt.Name = "Lb_OtrasAlt"
        Me.Lb_OtrasAlt.Size = New System.Drawing.Size(96, 13)
        Me.Lb_OtrasAlt.TabIndex = 53
        Me.Lb_OtrasAlt.Text = "Otras Alteraciones:"
        '
        'Ck_VConjuntiva
        '
        Me.Ck_VConjuntiva.AutoSize = True
        Me.Ck_VConjuntiva.Checked = True
        Me.Ck_VConjuntiva.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_VConjuntiva.Location = New System.Drawing.Point(412, 19)
        Me.Ck_VConjuntiva.Name = "Ck_VConjuntiva"
        Me.Ck_VConjuntiva.Size = New System.Drawing.Size(91, 17)
        Me.Ck_VConjuntiva.TabIndex = 52
        Me.Ck_VConjuntiva.Text = "Alt Conjuntiva"
        Me.Ck_VConjuntiva.UseVisualStyleBackColor = True
        '
        'Ck_VParpados
        '
        Me.Ck_VParpados.AutoSize = True
        Me.Ck_VParpados.Checked = True
        Me.Ck_VParpados.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_VParpados.Location = New System.Drawing.Point(323, 19)
        Me.Ck_VParpados.Name = "Ck_VParpados"
        Me.Ck_VParpados.Size = New System.Drawing.Size(86, 17)
        Me.Ck_VParpados.TabIndex = 51
        Me.Ck_VParpados.Text = "Alt Parpados"
        Me.Ck_VParpados.UseVisualStyleBackColor = True
        '
        'Ck_VMovilidad
        '
        Me.Ck_VMovilidad.AutoSize = True
        Me.Ck_VMovilidad.Checked = True
        Me.Ck_VMovilidad.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_VMovilidad.Location = New System.Drawing.Point(234, 19)
        Me.Ck_VMovilidad.Name = "Ck_VMovilidad"
        Me.Ck_VMovilidad.Size = New System.Drawing.Size(86, 17)
        Me.Ck_VMovilidad.TabIndex = 50
        Me.Ck_VMovilidad.Text = "Alt Movilidad"
        Me.Ck_VMovilidad.UseVisualStyleBackColor = True
        '
        'Ck_VLejos
        '
        Me.Ck_VLejos.AutoSize = True
        Me.Ck_VLejos.Checked = True
        Me.Ck_VLejos.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_VLejos.Location = New System.Drawing.Point(155, 19)
        Me.Ck_VLejos.Name = "Ck_VLejos"
        Me.Ck_VLejos.Size = New System.Drawing.Size(76, 17)
        Me.Ck_VLejos.TabIndex = 49
        Me.Ck_VLejos.Text = "Alt V Lejos"
        Me.Ck_VLejos.UseVisualStyleBackColor = True
        '
        'Ck_VCerca
        '
        Me.Ck_VCerca.AutoSize = True
        Me.Ck_VCerca.Checked = True
        Me.Ck_VCerca.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_VCerca.Location = New System.Drawing.Point(73, 19)
        Me.Ck_VCerca.Name = "Ck_VCerca"
        Me.Ck_VCerca.Size = New System.Drawing.Size(79, 17)
        Me.Ck_VCerca.TabIndex = 48
        Me.Ck_VCerca.Text = "Alt V Cerca"
        Me.Ck_VCerca.UseVisualStyleBackColor = True
        '
        'Ck_VNormal
        '
        Me.Ck_VNormal.AutoSize = True
        Me.Ck_VNormal.Checked = True
        Me.Ck_VNormal.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_VNormal.Location = New System.Drawing.Point(11, 19)
        Me.Ck_VNormal.Name = "Ck_VNormal"
        Me.Ck_VNormal.Size = New System.Drawing.Size(59, 17)
        Me.Ck_VNormal.TabIndex = 47
        Me.Ck_VNormal.Text = "Normal"
        Me.Ck_VNormal.UseVisualStyleBackColor = True
        '
        'Gb_Psicofarmacos
        '
        Me.Gb_Psicofarmacos.Controls.Add(Me.Ck_PsCocaina)
        Me.Gb_Psicofarmacos.Controls.Add(Me.Ck_PsMarihuana)
        Me.Gb_Psicofarmacos.Controls.Add(Me.Ck_PsNegativo)
        Me.Gb_Psicofarmacos.Location = New System.Drawing.Point(6, 224)
        Me.Gb_Psicofarmacos.Name = "Gb_Psicofarmacos"
        Me.Gb_Psicofarmacos.Size = New System.Drawing.Size(251, 46)
        Me.Gb_Psicofarmacos.TabIndex = 42
        Me.Gb_Psicofarmacos.TabStop = False
        Me.Gb_Psicofarmacos.Text = "Psicofarmacos"
        '
        'Ck_PsCocaina
        '
        Me.Ck_PsCocaina.AutoSize = True
        Me.Ck_PsCocaina.Checked = True
        Me.Ck_PsCocaina.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_PsCocaina.Location = New System.Drawing.Point(175, 18)
        Me.Ck_PsCocaina.Name = "Ck_PsCocaina"
        Me.Ck_PsCocaina.Size = New System.Drawing.Size(77, 17)
        Me.Ck_PsCocaina.TabIndex = 45
        Me.Ck_PsCocaina.Text = "Cocaina(+)"
        Me.Ck_PsCocaina.UseVisualStyleBackColor = True
        '
        'Ck_PsMarihuana
        '
        Me.Ck_PsMarihuana.AutoSize = True
        Me.Ck_PsMarihuana.Checked = True
        Me.Ck_PsMarihuana.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_PsMarihuana.Location = New System.Drawing.Point(81, 18)
        Me.Ck_PsMarihuana.Name = "Ck_PsMarihuana"
        Me.Ck_PsMarihuana.Size = New System.Drawing.Size(88, 17)
        Me.Ck_PsMarihuana.TabIndex = 44
        Me.Ck_PsMarihuana.Text = "Marihuana(+)"
        Me.Ck_PsMarihuana.UseVisualStyleBackColor = True
        '
        'Ck_PsNegativo
        '
        Me.Ck_PsNegativo.AutoSize = True
        Me.Ck_PsNegativo.Checked = True
        Me.Ck_PsNegativo.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_PsNegativo.Location = New System.Drawing.Point(6, 18)
        Me.Ck_PsNegativo.Name = "Ck_PsNegativo"
        Me.Ck_PsNegativo.Size = New System.Drawing.Size(69, 17)
        Me.Ck_PsNegativo.TabIndex = 43
        Me.Ck_PsNegativo.Text = "Negativo"
        Me.Ck_PsNegativo.UseVisualStyleBackColor = True
        '
        'Tb_FuncionRenal
        '
        Me.Tb_FuncionRenal.Location = New System.Drawing.Point(471, 112)
        Me.Tb_FuncionRenal.MaxLength = 20
        Me.Tb_FuncionRenal.Name = "Tb_FuncionRenal"
        Me.Tb_FuncionRenal.Size = New System.Drawing.Size(50, 20)
        Me.Tb_FuncionRenal.TabIndex = 25
        '
        'Gb_ParcialOrina
        '
        Me.Gb_ParcialOrina.Controls.Add(Me.Ck_POCreatinuria)
        Me.Gb_ParcialOrina.Controls.Add(Me.Ck_POEritocitocis)
        Me.Gb_ParcialOrina.Controls.Add(Me.Ck_POAlbumina)
        Me.Gb_ParcialOrina.Controls.Add(Me.Ck_POSangre)
        Me.Gb_ParcialOrina.Controls.Add(Me.Ck_POCalcio)
        Me.Gb_ParcialOrina.Controls.Add(Me.Ck_POGlucosuria)
        Me.Gb_ParcialOrina.Controls.Add(Me.Ck_POProteinura)
        Me.Gb_ParcialOrina.Controls.Add(Me.Ck_POBacterias)
        Me.Gb_ParcialOrina.Controls.Add(Me.Ck_PONormal)
        Me.Gb_ParcialOrina.Location = New System.Drawing.Point(6, 177)
        Me.Gb_ParcialOrina.Name = "Gb_ParcialOrina"
        Me.Gb_ParcialOrina.Size = New System.Drawing.Size(772, 45)
        Me.Gb_ParcialOrina.TabIndex = 31
        Me.Gb_ParcialOrina.TabStop = False
        Me.Gb_ParcialOrina.Text = "Parcial de Orina"
        '
        'Ck_POCreatinuria
        '
        Me.Ck_POCreatinuria.AutoSize = True
        Me.Ck_POCreatinuria.Checked = True
        Me.Ck_POCreatinuria.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_POCreatinuria.Location = New System.Drawing.Point(686, 19)
        Me.Ck_POCreatinuria.Name = "Ck_POCreatinuria"
        Me.Ck_POCreatinuria.Size = New System.Drawing.Size(76, 17)
        Me.Ck_POCreatinuria.TabIndex = 40
        Me.Ck_POCreatinuria.Text = "Creatinuria"
        Me.Ck_POCreatinuria.UseVisualStyleBackColor = True
        '
        'Ck_POEritocitocis
        '
        Me.Ck_POEritocitocis.AutoSize = True
        Me.Ck_POEritocitocis.Checked = True
        Me.Ck_POEritocitocis.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_POEritocitocis.Location = New System.Drawing.Point(596, 19)
        Me.Ck_POEritocitocis.Name = "Ck_POEritocitocis"
        Me.Ck_POEritocitocis.Size = New System.Drawing.Size(77, 17)
        Me.Ck_POEritocitocis.TabIndex = 39
        Me.Ck_POEritocitocis.Text = "Eritocitocis"
        Me.Ck_POEritocitocis.UseVisualStyleBackColor = True
        '
        'Ck_POAlbumina
        '
        Me.Ck_POAlbumina.AutoSize = True
        Me.Ck_POAlbumina.Checked = True
        Me.Ck_POAlbumina.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_POAlbumina.Location = New System.Drawing.Point(514, 19)
        Me.Ck_POAlbumina.Name = "Ck_POAlbumina"
        Me.Ck_POAlbumina.Size = New System.Drawing.Size(69, 17)
        Me.Ck_POAlbumina.TabIndex = 38
        Me.Ck_POAlbumina.Text = "Albúmina"
        Me.Ck_POAlbumina.UseVisualStyleBackColor = True
        '
        'Ck_POSangre
        '
        Me.Ck_POSangre.AutoSize = True
        Me.Ck_POSangre.Checked = True
        Me.Ck_POSangre.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_POSangre.Location = New System.Drawing.Point(423, 19)
        Me.Ck_POSangre.Name = "Ck_POSangre"
        Me.Ck_POSangre.Size = New System.Drawing.Size(78, 17)
        Me.Ck_POSangre.TabIndex = 37
        Me.Ck_POSangre.Text = "Sangre+++"
        Me.Ck_POSangre.UseVisualStyleBackColor = True
        '
        'Ck_POCalcio
        '
        Me.Ck_POCalcio.AutoSize = True
        Me.Ck_POCalcio.Checked = True
        Me.Ck_POCalcio.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_POCalcio.Location = New System.Drawing.Point(337, 19)
        Me.Ck_POCalcio.Name = "Ck_POCalcio"
        Me.Ck_POCalcio.Size = New System.Drawing.Size(73, 17)
        Me.Ck_POCalcio.TabIndex = 36
        Me.Ck_POCalcio.Text = "Calcio+++"
        Me.Ck_POCalcio.UseVisualStyleBackColor = True
        '
        'Ck_POGlucosuria
        '
        Me.Ck_POGlucosuria.AutoSize = True
        Me.Ck_POGlucosuria.Checked = True
        Me.Ck_POGlucosuria.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_POGlucosuria.Location = New System.Drawing.Point(248, 19)
        Me.Ck_POGlucosuria.Name = "Ck_POGlucosuria"
        Me.Ck_POGlucosuria.Size = New System.Drawing.Size(76, 17)
        Me.Ck_POGlucosuria.TabIndex = 35
        Me.Ck_POGlucosuria.Text = "Glucosuria"
        Me.Ck_POGlucosuria.UseVisualStyleBackColor = True
        '
        'Ck_POProteinura
        '
        Me.Ck_POProteinura.AutoSize = True
        Me.Ck_POProteinura.Checked = True
        Me.Ck_POProteinura.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_POProteinura.Location = New System.Drawing.Point(161, 19)
        Me.Ck_POProteinura.Name = "Ck_POProteinura"
        Me.Ck_POProteinura.Size = New System.Drawing.Size(74, 17)
        Me.Ck_POProteinura.TabIndex = 34
        Me.Ck_POProteinura.Text = "Proteinura"
        Me.Ck_POProteinura.UseVisualStyleBackColor = True
        '
        'Ck_POBacterias
        '
        Me.Ck_POBacterias.AutoSize = True
        Me.Ck_POBacterias.Checked = True
        Me.Ck_POBacterias.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_POBacterias.Location = New System.Drawing.Point(78, 19)
        Me.Ck_POBacterias.Name = "Ck_POBacterias"
        Me.Ck_POBacterias.Size = New System.Drawing.Size(70, 17)
        Me.Ck_POBacterias.TabIndex = 33
        Me.Ck_POBacterias.Text = "Bacterias"
        Me.Ck_POBacterias.UseVisualStyleBackColor = True
        '
        'Ck_PONormal
        '
        Me.Ck_PONormal.AutoSize = True
        Me.Ck_PONormal.Checked = True
        Me.Ck_PONormal.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_PONormal.Location = New System.Drawing.Point(6, 19)
        Me.Ck_PONormal.Name = "Ck_PONormal"
        Me.Ck_PONormal.Size = New System.Drawing.Size(59, 17)
        Me.Ck_PONormal.TabIndex = 32
        Me.Ck_PONormal.Text = "Normal"
        Me.Ck_PONormal.UseVisualStyleBackColor = True
        '
        'Gb_Quimica
        '
        Me.Gb_Quimica.Controls.Add(Me.Tb_Quimica)
        Me.Gb_Quimica.Controls.Add(Me.Tb_HDL)
        Me.Gb_Quimica.Controls.Add(Me.Lb_ObsQuimica)
        Me.Gb_Quimica.Controls.Add(Me.Lb_HDL)
        Me.Gb_Quimica.Controls.Add(Me.Tb_LDL)
        Me.Gb_Quimica.Controls.Add(Me.Lb_LDL)
        Me.Gb_Quimica.Controls.Add(Me.Tb_Colesterol)
        Me.Gb_Quimica.Controls.Add(Me.Lb_Colesterol)
        Me.Gb_Quimica.Controls.Add(Me.Tb_Triglicerios)
        Me.Gb_Quimica.Controls.Add(Me.Lb_Triglicerios)
        Me.Gb_Quimica.Location = New System.Drawing.Point(6, 66)
        Me.Gb_Quimica.Name = "Gb_Quimica"
        Me.Gb_Quimica.Size = New System.Drawing.Size(772, 42)
        Me.Gb_Quimica.TabIndex = 10
        Me.Gb_Quimica.TabStop = False
        Me.Gb_Quimica.Text = "Química"
        '
        'Tb_Quimica
        '
        Me.Tb_Quimica.Location = New System.Drawing.Point(457, 11)
        Me.Tb_Quimica.MaxLength = 50
        Me.Tb_Quimica.Name = "Tb_Quimica"
        Me.Tb_Quimica.Size = New System.Drawing.Size(309, 20)
        Me.Tb_Quimica.TabIndex = 20
        '
        'Tb_HDL
        '
        Me.Tb_HDL.Location = New System.Drawing.Point(249, 11)
        Me.Tb_HDL.MaxLength = 20
        Me.Tb_HDL.Name = "Tb_HDL"
        Me.Tb_HDL.Size = New System.Drawing.Size(40, 20)
        Me.Tb_HDL.TabIndex = 16
        '
        'Lb_ObsQuimica
        '
        Me.Lb_ObsQuimica.AutoSize = True
        Me.Lb_ObsQuimica.Location = New System.Drawing.Point(369, 15)
        Me.Lb_ObsQuimica.Name = "Lb_ObsQuimica"
        Me.Lb_ObsQuimica.Size = New System.Drawing.Size(81, 13)
        Me.Lb_ObsQuimica.TabIndex = 19
        Me.Lb_ObsQuimica.Text = "Observaciones:"
        '
        'Lb_HDL
        '
        Me.Lb_HDL.AutoSize = True
        Me.Lb_HDL.Location = New System.Drawing.Point(214, 15)
        Me.Lb_HDL.Name = "Lb_HDL"
        Me.Lb_HDL.Size = New System.Drawing.Size(32, 13)
        Me.Lb_HDL.TabIndex = 15
        Me.Lb_HDL.Text = "HDL:"
        '
        'Tb_LDL
        '
        Me.Tb_LDL.Location = New System.Drawing.Point(325, 11)
        Me.Tb_LDL.MaxLength = 20
        Me.Tb_LDL.Name = "Tb_LDL"
        Me.Tb_LDL.Size = New System.Drawing.Size(40, 20)
        Me.Tb_LDL.TabIndex = 18
        '
        'Lb_LDL
        '
        Me.Lb_LDL.AutoSize = True
        Me.Lb_LDL.Location = New System.Drawing.Point(292, 15)
        Me.Lb_LDL.Name = "Lb_LDL"
        Me.Lb_LDL.Size = New System.Drawing.Size(30, 13)
        Me.Lb_LDL.TabIndex = 17
        Me.Lb_LDL.Text = "LDL:"
        '
        'Tb_Colesterol
        '
        Me.Tb_Colesterol.Location = New System.Drawing.Point(171, 11)
        Me.Tb_Colesterol.MaxLength = 20
        Me.Tb_Colesterol.Name = "Tb_Colesterol"
        Me.Tb_Colesterol.Size = New System.Drawing.Size(40, 20)
        Me.Tb_Colesterol.TabIndex = 14
        '
        'Lb_Colesterol
        '
        Me.Lb_Colesterol.AutoSize = True
        Me.Lb_Colesterol.Location = New System.Drawing.Point(112, 15)
        Me.Lb_Colesterol.Name = "Lb_Colesterol"
        Me.Lb_Colesterol.Size = New System.Drawing.Size(56, 13)
        Me.Lb_Colesterol.TabIndex = 13
        Me.Lb_Colesterol.Text = "Colesterol:"
        '
        'Tb_Triglicerios
        '
        Me.Tb_Triglicerios.Location = New System.Drawing.Point(69, 11)
        Me.Tb_Triglicerios.MaxLength = 20
        Me.Tb_Triglicerios.Name = "Tb_Triglicerios"
        Me.Tb_Triglicerios.Size = New System.Drawing.Size(40, 20)
        Me.Tb_Triglicerios.TabIndex = 12
        '
        'Lb_Triglicerios
        '
        Me.Lb_Triglicerios.AutoSize = True
        Me.Lb_Triglicerios.Location = New System.Drawing.Point(6, 15)
        Me.Lb_Triglicerios.Name = "Lb_Triglicerios"
        Me.Lb_Triglicerios.Size = New System.Drawing.Size(60, 13)
        Me.Lb_Triglicerios.TabIndex = 11
        Me.Lb_Triglicerios.Text = "Triglicerios:"
        '
        'Gb_CuadroHematico
        '
        Me.Gb_CuadroHematico.Controls.Add(Me.Tb_CuadroHematico)
        Me.Gb_CuadroHematico.Controls.Add(Me.Lb_ObsCH)
        Me.Gb_CuadroHematico.Controls.Add(Me.Tb_Plaquetas)
        Me.Gb_CuadroHematico.Controls.Add(Me.Lb_Plaquetas)
        Me.Gb_CuadroHematico.Controls.Add(Me.Tb_LineaBlanca)
        Me.Gb_CuadroHematico.Controls.Add(Me.Lb_LineaBlanca)
        Me.Gb_CuadroHematico.Controls.Add(Me.Tb_LineaRoja)
        Me.Gb_CuadroHematico.Controls.Add(Me.Lb_LineaRoja)
        Me.Gb_CuadroHematico.Location = New System.Drawing.Point(6, 16)
        Me.Gb_CuadroHematico.Name = "Gb_CuadroHematico"
        Me.Gb_CuadroHematico.Size = New System.Drawing.Size(772, 48)
        Me.Gb_CuadroHematico.TabIndex = 1
        Me.Gb_CuadroHematico.TabStop = False
        Me.Gb_CuadroHematico.Text = "Cuadro Hemático"
        '
        'Tb_CuadroHematico
        '
        Me.Tb_CuadroHematico.Location = New System.Drawing.Point(457, 17)
        Me.Tb_CuadroHematico.MaxLength = 50
        Me.Tb_CuadroHematico.Name = "Tb_CuadroHematico"
        Me.Tb_CuadroHematico.Size = New System.Drawing.Size(309, 20)
        Me.Tb_CuadroHematico.TabIndex = 9
        '
        'Lb_ObsCH
        '
        Me.Lb_ObsCH.AutoSize = True
        Me.Lb_ObsCH.Location = New System.Drawing.Point(369, 21)
        Me.Lb_ObsCH.Name = "Lb_ObsCH"
        Me.Lb_ObsCH.Size = New System.Drawing.Size(81, 13)
        Me.Lb_ObsCH.TabIndex = 8
        Me.Lb_ObsCH.Text = "Observaciones:"
        '
        'Tb_Plaquetas
        '
        Me.Tb_Plaquetas.Location = New System.Drawing.Point(313, 17)
        Me.Tb_Plaquetas.MaxLength = 20
        Me.Tb_Plaquetas.Name = "Tb_Plaquetas"
        Me.Tb_Plaquetas.Size = New System.Drawing.Size(50, 20)
        Me.Tb_Plaquetas.TabIndex = 7
        '
        'Lb_Plaquetas
        '
        Me.Lb_Plaquetas.AutoSize = True
        Me.Lb_Plaquetas.Location = New System.Drawing.Point(253, 21)
        Me.Lb_Plaquetas.Name = "Lb_Plaquetas"
        Me.Lb_Plaquetas.Size = New System.Drawing.Size(57, 13)
        Me.Lb_Plaquetas.TabIndex = 6
        Me.Lb_Plaquetas.Text = "Plaquetas:"
        '
        'Tb_LineaBlanca
        '
        Me.Tb_LineaBlanca.Location = New System.Drawing.Point(200, 17)
        Me.Tb_LineaBlanca.MaxLength = 20
        Me.Tb_LineaBlanca.Name = "Tb_LineaBlanca"
        Me.Tb_LineaBlanca.Size = New System.Drawing.Size(50, 20)
        Me.Tb_LineaBlanca.TabIndex = 5
        '
        'Lb_LineaBlanca
        '
        Me.Lb_LineaBlanca.AutoSize = True
        Me.Lb_LineaBlanca.Location = New System.Drawing.Point(125, 21)
        Me.Lb_LineaBlanca.Name = "Lb_LineaBlanca"
        Me.Lb_LineaBlanca.Size = New System.Drawing.Size(72, 13)
        Me.Lb_LineaBlanca.TabIndex = 4
        Me.Lb_LineaBlanca.Text = "Linea Blanca:"
        '
        'Tb_LineaRoja
        '
        Me.Tb_LineaRoja.Location = New System.Drawing.Point(72, 17)
        Me.Tb_LineaRoja.MaxLength = 20
        Me.Tb_LineaRoja.Name = "Tb_LineaRoja"
        Me.Tb_LineaRoja.Size = New System.Drawing.Size(50, 20)
        Me.Tb_LineaRoja.TabIndex = 3
        '
        'Lb_LineaRoja
        '
        Me.Lb_LineaRoja.AutoSize = True
        Me.Lb_LineaRoja.Location = New System.Drawing.Point(8, 21)
        Me.Lb_LineaRoja.Name = "Lb_LineaRoja"
        Me.Lb_LineaRoja.Size = New System.Drawing.Size(61, 13)
        Me.Lb_LineaRoja.TabIndex = 2
        Me.Lb_LineaRoja.Text = "Linea Roja:"
        '
        'Cb_EKG
        '
        Me.Cb_EKG.FormattingEnabled = True
        Me.Cb_EKG.Location = New System.Drawing.Point(108, 320)
        Me.Cb_EKG.Name = "Cb_EKG"
        Me.Cb_EKG.Size = New System.Drawing.Size(150, 21)
        Me.Cb_EKG.TabIndex = 60
        '
        'Cb_Espirometria
        '
        Me.Cb_Espirometria.FormattingEnabled = True
        Me.Cb_Espirometria.Location = New System.Drawing.Point(107, 293)
        Me.Cb_Espirometria.Name = "Cb_Espirometria"
        Me.Cb_Espirometria.Size = New System.Drawing.Size(150, 21)
        Me.Cb_Espirometria.TabIndex = 56
        '
        'Lb_Glicemia
        '
        Me.Lb_Glicemia.AutoSize = True
        Me.Lb_Glicemia.Location = New System.Drawing.Point(12, 117)
        Me.Lb_Glicemia.Name = "Lb_Glicemia"
        Me.Lb_Glicemia.Size = New System.Drawing.Size(50, 13)
        Me.Lb_Glicemia.TabIndex = 21
        Me.Lb_Glicemia.Text = "Glicemia:"
        '
        'Cb_Audiometria
        '
        Me.Cb_Audiometria.FormattingEnabled = True
        Me.Cb_Audiometria.Location = New System.Drawing.Point(367, 292)
        Me.Cb_Audiometria.Name = "Cb_Audiometria"
        Me.Cb_Audiometria.Size = New System.Drawing.Size(150, 21)
        Me.Cb_Audiometria.TabIndex = 58
        '
        'Lb_FuncionRenal
        '
        Me.Lb_FuncionRenal.AutoSize = True
        Me.Lb_FuncionRenal.Location = New System.Drawing.Point(380, 116)
        Me.Lb_FuncionRenal.Name = "Lb_FuncionRenal"
        Me.Lb_FuncionRenal.Size = New System.Drawing.Size(79, 13)
        Me.Lb_FuncionRenal.TabIndex = 24
        Me.Lb_FuncionRenal.Text = "Función Renal:"
        '
        'Lb_Audiometria
        '
        Me.Lb_Audiometria.AutoSize = True
        Me.Lb_Audiometria.Location = New System.Drawing.Point(271, 296)
        Me.Lb_Audiometria.Name = "Lb_Audiometria"
        Me.Lb_Audiometria.Size = New System.Drawing.Size(67, 13)
        Me.Lb_Audiometria.TabIndex = 57
        Me.Lb_Audiometria.Text = "Audiometría:"
        '
        'Lb_Espirometría
        '
        Me.Lb_Espirometría.AutoSize = True
        Me.Lb_Espirometría.Location = New System.Drawing.Point(12, 297)
        Me.Lb_Espirometría.Name = "Lb_Espirometría"
        Me.Lb_Espirometría.Size = New System.Drawing.Size(69, 13)
        Me.Lb_Espirometría.TabIndex = 55
        Me.Lb_Espirometría.Text = "Espirometría:"
        '
        'Lb_EKG
        '
        Me.Lb_EKG.AutoSize = True
        Me.Lb_EKG.Location = New System.Drawing.Point(12, 324)
        Me.Lb_EKG.Name = "Lb_EKG"
        Me.Lb_EKG.Size = New System.Drawing.Size(32, 13)
        Me.Lb_EKG.TabIndex = 59
        Me.Lb_EKG.Text = "EKG:"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "HIGIENEINDUSTRIAL"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Higiene Industrial"
        Me.DataGridViewTextBoxColumn1.MaxInputLength = 250
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 300
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CANMAGNITUD"
        Me.DataGridViewTextBoxColumn2.HeaderText = "TLV's"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 10
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "FRECUENCIA"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Alteración"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 100
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 190
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "SECUELA"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Órgano Blanco"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 320
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "HIGIENEINDUSTRIAL"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Efecto"
        Me.DataGridViewTextBoxColumn5.MaxInputLength = 250
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 300
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "TAREA"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Tarea"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 250
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 300
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "FRECUENCIA"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Magnitud"
        Me.DataGridViewTextBoxColumn7.MaxInputLength = 10
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "DESCRIPCIONENFERMEDAD"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Frecuencia"
        Me.DataGridViewTextBoxColumn8.MaxInputLength = 150
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 320
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "SECUELA"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Secuela"
        Me.DataGridViewTextBoxColumn9.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 320
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "ACCIDENTE"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Accidente"
        Me.DataGridViewTextBoxColumn10.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 300
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "SECUELA"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Secuela"
        Me.DataGridViewTextBoxColumn11.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 350
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "ACCIDENTE"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Intensidad"
        Me.DataGridViewTextBoxColumn12.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn12.Visible = False
        Me.DataGridViewTextBoxColumn12.Width = 320
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "SECUELA"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Abandono Habito"
        Me.DataGridViewTextBoxColumn13.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn13.Width = 320
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "DESCRIPCION"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn14.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn14.Width = 300
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "NUMERODOSIS"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn15.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn15.Width = 550
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "MODULOCREACION"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Creacion"
        Me.DataGridViewTextBoxColumn16.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn16.Width = 750
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "DESCRIPCIONANTECEDENTE"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn17.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 550
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "CODIGOENFERMEDAD"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Impresión Diagnóstica"
        Me.DataGridViewTextBoxColumn18.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn18.Width = 750
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "CODIGOENFERMEDAD"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Impresión Diagnóstica"
        Me.DataGridViewTextBoxColumn19.MaxInputLength = 4
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn19.Width = 750
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "ABANDONOHABITO"
        Me.DataGridViewTextBoxColumn20.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn20.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn20.Width = 350
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "DESCRIPCIONANTECEDENTE"
        Me.DataGridViewTextBoxColumn21.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn21.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn21.Width = 550
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "IDENFERMEDAD"
        Me.DataGridViewTextBoxColumn22.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn22.Visible = False
        Me.DataGridViewTextBoxColumn22.Width = 50
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "CODIGOENFERMEDAD"
        Me.DataGridViewTextBoxColumn23.HeaderText = "Cod"
        Me.DataGridViewTextBoxColumn23.MaxInputLength = 4
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn23.Width = 50
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "NOMBREENFERMEDAD"
        Me.DataGridViewTextBoxColumn24.HeaderText = "Enfermedad"
        Me.DataGridViewTextBoxColumn24.MaxInputLength = 4
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn24.Width = 150
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "DESCRIPCIONENFERMEDAD"
        Me.DataGridViewTextBoxColumn25.HeaderText = "Impresión Diagnóstica"
        Me.DataGridViewTextBoxColumn25.MaxInputLength = 150
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn25.Width = 500
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "SECUELA"
        Me.DataGridViewTextBoxColumn26.HeaderText = "Secuela"
        Me.DataGridViewTextBoxColumn26.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn26.Width = 320
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "TIPO"
        Me.DataGridViewTextBoxColumn27.HeaderText = "Tipo"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.Visible = False
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "NUMTIEMPO"
        Me.DataGridViewTextBoxColumn28.HeaderText = "Num Tiempo"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.Width = 90
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "INTENSIDAD"
        Me.DataGridViewTextBoxColumn29.HeaderText = "Intensidad"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn29.Width = 80
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "ABANDONOHABITO"
        Me.DataGridViewTextBoxColumn30.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn30.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn30.Width = 300
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "DESCRIPCIONANTECEDENTE"
        Me.DataGridViewTextBoxColumn31.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn31.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn31.Width = 600
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "IDENFERMEDAD"
        Me.DataGridViewTextBoxColumn32.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn32.Width = 50
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "CODIGOENFERMEDAD"
        Me.DataGridViewTextBoxColumn33.HeaderText = "Cod"
        Me.DataGridViewTextBoxColumn33.MaxInputLength = 4
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn33.Width = 50
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "NOMBREENFERMEDAD"
        Me.DataGridViewTextBoxColumn34.HeaderText = "Enfermedad"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        Me.DataGridViewTextBoxColumn34.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn34.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn34.Width = 150
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "DESCRIPCIONENFERMEDAD"
        Me.DataGridViewTextBoxColumn35.HeaderText = "Impresión Diagnóstica"
        Me.DataGridViewTextBoxColumn35.MaxInputLength = 150
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn35.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn35.Width = 500
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Cu_CiudadContrato
        '
        Me.Cu_CiudadContrato.Location = New System.Drawing.Point(114, 118)
        Me.Cu_CiudadContrato.Name = "Cu_CiudadContrato"
        Me.Cu_CiudadContrato.Size = New System.Drawing.Size(278, 23)
        Me.Cu_CiudadContrato.TabIndex = 21
        '
        'Cu_AsociarPersonaReporte
        '
        Me.Cu_AsociarPersonaReporte.componenteasociado = Nothing
        Me.Cu_AsociarPersonaReporte.CrearUsuario = False
        Me.Cu_AsociarPersonaReporte.Location = New System.Drawing.Point(431, 14)
        Me.Cu_AsociarPersonaReporte.Name = "Cu_AsociarPersonaReporte"
        Me.Cu_AsociarPersonaReporte.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaReporte.TabIndex = 7
        Me.Cu_AsociarPersonaReporte.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaReporte.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaExamenMedico
        '
        Me.Cu_BuscarPersonaExamenMedico.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaExamenMedico.Location = New System.Drawing.Point(114, 13)
        Me.Cu_BuscarPersonaExamenMedico.Name = "Cu_BuscarPersonaExamenMedico"
        Me.Cu_BuscarPersonaExamenMedico.Size = New System.Drawing.Size(318, 23)
        Me.Cu_BuscarPersonaExamenMedico.TabIndex = 6
        Me.Cu_BuscarPersonaExamenMedico.Tipo = "PABO"
        Me.Cu_BuscarPersonaExamenMedico.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_Vacuna1
        '
        Me.Cu_Vacuna1.AutoSize = True
        Me.Cu_Vacuna1.Location = New System.Drawing.Point(6, 261)
        Me.Cu_Vacuna1.Name = "Cu_Vacuna1"
        Me.Cu_Vacuna1.Size = New System.Drawing.Size(789, 160)
        Me.Cu_Vacuna1.TabIndex = 38
        '
        'Fr_ExamenMedicoPeriodico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 487)
        Me.Controls.Add(Me.Pn_Botones)
        Me.Controls.Add(Me.TC_ExamenMedicoPeriodico)
        Me.MaximumSize = New System.Drawing.Size(824, 526)
        Me.MinimumSize = New System.Drawing.Size(824, 526)
        Me.Name = "Fr_ExamenMedicoPeriodico"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Examen Médico"
        Me.Pn_Botones.ResumeLayout(False)
        Me.TP_ImpresionDiagnostica.ResumeLayout(False)
        CType(Me.Dgv_ImpresionDiagnosticaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_ImpresionDiagnosticaFinal.ResumeLayout(False)
        Me.Pn_ImpresionDiagnosticaFinal.PerformLayout()
        Me.Gb_ComentariosFinales.ResumeLayout(False)
        Me.Gb_ComentariosFinales.PerformLayout()
        Me.Gb_EstudiosFinales.ResumeLayout(False)
        Me.Gb_EstudiosFinales.PerformLayout()
        Me.TP_ExamenAuditivo.ResumeLayout(False)
        Me.Gb_Auditivo.ResumeLayout(False)
        Me.Gb_Auditivo.PerformLayout()
        CType(Me.Num_OD_025, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OI_025, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OD_05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OI_05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OD_1000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OI_1000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OD_2000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OI_2000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OD_3000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OI_3000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OD_6000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OI_6000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OD_8000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_OI_8000, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP_ExamenFisico5.ResumeLayout(False)
        Me.Gb_Laboratorios.ResumeLayout(False)
        Me.Gb_Laboratorios.PerformLayout()
        Me.Gb_ValoracionAuditiva.ResumeLayout(False)
        Me.Gb_ValoracionAuditiva.PerformLayout()
        Me.Gb_MiembrosInferiores2.ResumeLayout(False)
        Me.Gb_ComentariosMiembrosInferiores.ResumeLayout(False)
        Me.Gb_ComentariosMiembrosInferiores.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Gb_Pies.ResumeLayout(False)
        Me.Gb_Pies.PerformLayout()
        Me.Gb_Tobillos.ResumeLayout(False)
        Me.Gb_Tobillos.PerformLayout()
        Me.TP_ExamenFisico4.ResumeLayout(False)
        Me.Gb_MiembrosInferiores.ResumeLayout(False)
        Me.Gb_Rodillas.ResumeLayout(False)
        Me.Gb_Rodillas.PerformLayout()
        Me.Gb_Caderas.ResumeLayout(False)
        Me.Gb_Caderas.PerformLayout()
        Me.Gb_ValoracionMiembrosSuperiores3.ResumeLayout(False)
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores.ResumeLayout(False)
        Me.Gb_ComentariosEvidenciasMiembrosSuperiores.PerformLayout()
        Me.Gb_DedosManoIzquierda.ResumeLayout(False)
        Me.Gb_DedosManoIzquierda.PerformLayout()
        Me.TP_ExamenFisico3.ResumeLayout(False)
        Me.Gb_ValoracionMiembrosSuperiores2.ResumeLayout(False)
        Me.Gb_ValoracionMiembrosSuperiores2.PerformLayout()
        Me.Gb_DedosManoDerecha.ResumeLayout(False)
        Me.Gb_DedosManoDerecha.PerformLayout()
        Me.Gb_Manos.ResumeLayout(False)
        Me.Gb_Manos.PerformLayout()
        Me.Gb_Muñecas.ResumeLayout(False)
        Me.Gb_Muñecas.PerformLayout()
        Me.Gb_Codos.ResumeLayout(False)
        Me.Gb_Codos.PerformLayout()
        Me.Gb_Hombros.ResumeLayout(False)
        Me.Gb_Hombros.PerformLayout()
        Me.TP_ExamenFisico2.ResumeLayout(False)
        Me.Gb_ValoracionMiembrosSuperiores.ResumeLayout(False)
        Me.Gb_ValoracionMiembrosSuperiores.PerformLayout()
        Me.Gb_ExamenColumna2.ResumeLayout(False)
        Me.Gb_TestWells.ResumeLayout(False)
        Me.Gb_TestWells.PerformLayout()
        Me.Gb_SignoLasegue.ResumeLayout(False)
        Me.Gb_SignoLasegue.PerformLayout()
        Me.Gb_TestSchober.ResumeLayout(False)
        Me.Gb_TestSchober.PerformLayout()
        Me.TP_ExamenFisico1.ResumeLayout(False)
        Me.Gb_ExamenColumna.ResumeLayout(False)
        Me.Gb_Movilidad.ResumeLayout(False)
        Me.Gb_Movilidad.PerformLayout()
        Me.Gb_Palpacion.ResumeLayout(False)
        Me.Gb_Palpacion.PerformLayout()
        Me.Gb_Inspeccion.ResumeLayout(False)
        Me.Gb_Inspeccion.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Gb_SignosVitales.ResumeLayout(False)
        Me.Gb_SignosVitales.PerformLayout()
        CType(Me.Num_PerimetroAbdomen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_SO2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_FR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_FC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_TaDiast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_TaSist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP_AntecedentesPatologicos.ResumeLayout(False)
        Me.Gb_RevisionSistemas.ResumeLayout(False)
        Me.Gb_RevisionSistemas.PerformLayout()
        CType(Me.Dgv_Habitos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Habitos.ResumeLayout(False)
        Me.Pn_Habitos.PerformLayout()
        CType(Me.Dgv_Antecedentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Antecedentes.ResumeLayout(False)
        Me.Pn_Antecedentes.PerformLayout()
        Me.TP_Antecedentes.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Dgv_Enfermedades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_Accidente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TP_DescripcionCargo.ResumeLayout(False)
        CType(Me.Dgv_AntecedenteLaborales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_Higiene, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Dgv_Tareas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TP_DatosPersonales.ResumeLayout(False)
        Me.TP_DatosPersonales.PerformLayout()
        Me.Gb_TipoExamen.ResumeLayout(False)
        Me.Gb_TipoExamen.PerformLayout()
        Me.Gb_DatosPersonales.ResumeLayout(False)
        Me.Gb_DatosPersonales.PerformLayout()
        Me.Gb_Riesgo.ResumeLayout(False)
        Me.Gb_Riesgo.PerformLayout()
        CType(Me.Num_Turnos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_CargoMeses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_CargoAños, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gb_Genero.ResumeLayout(False)
        Me.Gb_Genero.PerformLayout()
        Me.TC_ExamenMedicoPeriodico.ResumeLayout(False)
        Me.TP_ExamenComplementario.ResumeLayout(False)
        Me.Gb_ExamenesComplementarios.ResumeLayout(False)
        Me.Gb_ExamenesComplementarios.PerformLayout()
        Me.Gb_FuncionHepatica.ResumeLayout(False)
        Me.Gb_FuncionHepatica.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Gb_Visiometria.ResumeLayout(False)
        Me.Gb_Visiometria.PerformLayout()
        Me.Gb_Psicofarmacos.ResumeLayout(False)
        Me.Gb_Psicofarmacos.PerformLayout()
        Me.Gb_ParcialOrina.ResumeLayout(False)
        Me.Gb_ParcialOrina.PerformLayout()
        Me.Gb_Quimica.ResumeLayout(False)
        Me.Gb_Quimica.PerformLayout()
        Me.Gb_CuadroHematico.ResumeLayout(False)
        Me.Gb_CuadroHematico.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cu_Vacuna1 As FormulariosClasesBase.Cu_Vacuna
    Friend WithEvents TP_ImpresionDiagnostica As System.Windows.Forms.TabPage
    Friend WithEvents Dgv_ImpresionDiagnosticaFinal As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_ImpresionDiagnosticaFinal As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarImpresionDiagnosticaFinal As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Gb_ComentariosFinales As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_ComentariosFinales As System.Windows.Forms.TextBox
    Friend WithEvents Gb_EstudiosFinales As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_EstudiosFinales As System.Windows.Forms.TextBox
    Friend WithEvents TP_ExamenAuditivo As System.Windows.Forms.TabPage
    Friend WithEvents Gb_Auditivo As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Detalle025 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_ViaComprometida025 As System.Windows.Forms.ComboBox
    Friend WithEvents Num_OD_025 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_OI_025 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Tb_Detalle05 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_ViaComprometida05 As System.Windows.Forms.ComboBox
    Friend WithEvents Num_OD_05 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_OI_05 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Tb_Detalle1000 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_ViaComprometida1000 As System.Windows.Forms.ComboBox
    Friend WithEvents Num_OD_1000 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_OI_1000 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Tb_Detalle2000 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_ViaComprometida2000 As System.Windows.Forms.ComboBox
    Friend WithEvents Num_OD_2000 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_OI_2000 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Tb_Detalle3000 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_ViaComprometida3000 As System.Windows.Forms.ComboBox
    Friend WithEvents Num_OD_3000 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_OI_3000 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Tb_Detalle6000 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_ViaComprometida6000 As System.Windows.Forms.ComboBox
    Friend WithEvents Num_OD_6000 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_OI_6000 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Tb_Detalle8000 As System.Windows.Forms.TextBox
    Friend WithEvents Cb_ViaComprometida8000 As System.Windows.Forms.ComboBox
    Friend WithEvents Num_OD_8000 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_OI_8000 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lb_Detalle As System.Windows.Forms.Label
    Friend WithEvents Lb_ViaComprometida As System.Windows.Forms.Label
    Friend WithEvents Lb_OD As System.Windows.Forms.Label
    Friend WithEvents Lb_OI As System.Windows.Forms.Label
    Friend WithEvents Lb_025 As System.Windows.Forms.Label
    Friend WithEvents Lb_6000 As System.Windows.Forms.Label
    Friend WithEvents Lb_3000 As System.Windows.Forms.Label
    Friend WithEvents Lb_2000 As System.Windows.Forms.Label
    Friend WithEvents Lb_1000 As System.Windows.Forms.Label
    Friend WithEvents Lb_05 As System.Windows.Forms.Label
    Friend WithEvents Lb_8000 As System.Windows.Forms.Label
    Friend WithEvents TP_ExamenFisico5 As System.Windows.Forms.TabPage
    Friend WithEvents Gb_ValoracionAuditiva As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_AuditivaNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_AuditivaSi As System.Windows.Forms.RadioButton
    Friend WithEvents Gb_MiembrosInferiores2 As System.Windows.Forms.GroupBox
    Friend WithEvents Gb_ComentariosMiembrosInferiores As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_ComentariosMiembrosInferiores As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Marcha As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Marcha As System.Windows.Forms.Label
    Friend WithEvents Tb_FaseBalanceoPieIzquierdo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_MarchaPieIzquierdo As System.Windows.Forms.Label
    Friend WithEvents Tb_FaseApoyoPieIzquierdo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_MarchaPieDerecho As System.Windows.Forms.Label
    Friend WithEvents Tb_FaseBalanceoPieDerecho As System.Windows.Forms.TextBox
    Friend WithEvents Lb_FaseBalanceo As System.Windows.Forms.Label
    Friend WithEvents Tb_FaseApoyoPieDerecho As System.Windows.Forms.TextBox
    Friend WithEvents Lb_FaseApoyo As System.Windows.Forms.Label
    Friend WithEvents Gb_Pies As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_PieIzquierdo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_PieIzquierdo As System.Windows.Forms.Label
    Friend WithEvents Tb_PieDerecho As System.Windows.Forms.TextBox
    Friend WithEvents Lb_PieDerecho As System.Windows.Forms.Label
    Friend WithEvents Gb_Tobillos As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_TobilloIzquierdo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TobilloIzquierdo As System.Windows.Forms.Label
    Friend WithEvents Tb_TobilloDerecho As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TobilloDerecho As System.Windows.Forms.Label
    Friend WithEvents TP_ExamenFisico4 As System.Windows.Forms.TabPage
    Friend WithEvents Gb_MiembrosInferiores As System.Windows.Forms.GroupBox
    Friend WithEvents Gb_Rodillas As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_RodillaIzquierda As System.Windows.Forms.TextBox
    Friend WithEvents Lb_RodillaIzquierda As System.Windows.Forms.Label
    Friend WithEvents Tb_RodillaDerecha As System.Windows.Forms.TextBox
    Friend WithEvents Lb_RodillaDerecha As System.Windows.Forms.Label
    Friend WithEvents Gb_Caderas As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_CaderasIzquierda As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CaderasIzquierda As System.Windows.Forms.Label
    Friend WithEvents Tb_CaderasDerecha As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CaderasDerecha As System.Windows.Forms.Label
    Friend WithEvents Gb_ValoracionMiembrosSuperiores3 As System.Windows.Forms.GroupBox
    Friend WithEvents Gb_ComentariosEvidenciasMiembrosSuperiores As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_ComentariosMiembrosSuperiores As System.Windows.Forms.TextBox
    Friend WithEvents Gb_DedosManoIzquierda As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_DedoIzquierdo5 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DedoIzquierdo5 As System.Windows.Forms.Label
    Friend WithEvents Tb_DedoIzquierdo4 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DedoIzquierdo4 As System.Windows.Forms.Label
    Friend WithEvents Tb_DedoIzquierdo3 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DedoIzquierdo3 As System.Windows.Forms.Label
    Friend WithEvents Tb_DedoIzquierdo2 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DedoIzquierdo2 As System.Windows.Forms.Label
    Friend WithEvents Tb_DedoIzquierdo1 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DedoIzquierdo1 As System.Windows.Forms.Label
    Friend WithEvents TP_ExamenFisico3 As System.Windows.Forms.TabPage
    Friend WithEvents Gb_ValoracionMiembrosSuperiores2 As System.Windows.Forms.GroupBox
    Friend WithEvents Gb_DedosManoDerecha As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_DedoDerecho5 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DedoDerecho5 As System.Windows.Forms.Label
    Friend WithEvents Tb_DedoDerecho4 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DedoDerecho4 As System.Windows.Forms.Label
    Friend WithEvents Tb_DedoDerecho3 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DedoDerecho3 As System.Windows.Forms.Label
    Friend WithEvents Tb_DedoDerecho2 As System.Windows.Forms.TextBox
    Friend WithEvents _DedoDerecho2 As System.Windows.Forms.Label
    Friend WithEvents Tb_DedoDerecho1 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DedoDerecho1 As System.Windows.Forms.Label
    Friend WithEvents Gb_Manos As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_ManoIzquierda As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ManoIzquierda As System.Windows.Forms.Label
    Friend WithEvents Tb_ManoDerecha As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ManoDerecha As System.Windows.Forms.Label
    Friend WithEvents Gb_Muñecas As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_MuñecaIzquierda As System.Windows.Forms.TextBox
    Friend WithEvents Lb_MuñecaIzquierda As System.Windows.Forms.Label
    Friend WithEvents Tb_MuñecaDerecha As System.Windows.Forms.TextBox
    Friend WithEvents Lb_MuñecaDerecha As System.Windows.Forms.Label
    Friend WithEvents Gb_Codos As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_CodoIzquierdo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CodoIzquierdo As System.Windows.Forms.Label
    Friend WithEvents Tb_CodoDerecho As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CodoDerecho As System.Windows.Forms.Label
    Friend WithEvents Gb_Hombros As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_HombroIzquierdo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_HombroIzquierdo As System.Windows.Forms.Label
    Friend WithEvents Tb_HombroDerecho As System.Windows.Forms.TextBox
    Friend WithEvents Lb_HombroDerecho As System.Windows.Forms.Label
    Friend WithEvents Tb_FlexoExtension As System.Windows.Forms.TextBox
    Friend WithEvents Lb_FlexoExtension As System.Windows.Forms.Label
    Friend WithEvents Tb_RotacionExterna As System.Windows.Forms.TextBox
    Friend WithEvents Lb_RotacionExterna As System.Windows.Forms.Label
    Friend WithEvents TP_ExamenFisico2 As System.Windows.Forms.TabPage
    Friend WithEvents Gb_ValoracionMiembrosSuperiores As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Aduccion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Aduccion As System.Windows.Forms.Label
    Friend WithEvents Tb_AbduccionElevacion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_AbduccionElevacion As System.Windows.Forms.Label
    Friend WithEvents Tb_Circunduccion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Circunduccion As System.Windows.Forms.Label
    Friend WithEvents Tb_EjeLongitudinal As System.Windows.Forms.TextBox
    Friend WithEvents Lb_EjeLongitudinal As System.Windows.Forms.Label
    Friend WithEvents Tb_EjeTransversal As System.Windows.Forms.TextBox
    Friend WithEvents Lb_EjeTransversal As System.Windows.Forms.Label
    Friend WithEvents Tb_EjeAnteroposterior As System.Windows.Forms.TextBox
    Friend WithEvents Lb_EjeAnteroposterior As System.Windows.Forms.Label
    Friend WithEvents Tb_Subdeltoidea As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ArtSubdeltoidea As System.Windows.Forms.Label
    Friend WithEvents Tb_ArtEscapulotorácica As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ArtEscapulotorácica As System.Windows.Forms.Label
    Friend WithEvents Tb_ArtAcromioclavicular As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ArtAcromioclavicular As System.Windows.Forms.Label
    Friend WithEvents Tb_ArtEscapulohumeral As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ArtEscapulohumeral As System.Windows.Forms.Label
    Friend WithEvents Gb_ExamenColumna2 As System.Windows.Forms.GroupBox
    Friend WithEvents Gb_TestWells As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Rb_MuyPobre As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Pobre As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Deficiente As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Promedio As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Bueno As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Excelente As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Superior As System.Windows.Forms.RadioButton
    Friend WithEvents Gb_SignoLasegue As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_Negativo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Positivo As System.Windows.Forms.RadioButton
    Friend WithEvents Tb_Lasegue As System.Windows.Forms.TextBox
    Friend WithEvents Gb_TestSchober As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_Menor5cm As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Mayor5cm As System.Windows.Forms.RadioButton
    Friend WithEvents TP_ExamenFisico1 As System.Windows.Forms.TabPage
    Friend WithEvents Gb_ExamenColumna As System.Windows.Forms.GroupBox
    Friend WithEvents Gb_Movilidad As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Rotacion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Rotacion As System.Windows.Forms.Label
    Friend WithEvents Tb_FlexionLateral As System.Windows.Forms.TextBox
    Friend WithEvents Lb_FlexionLateral As System.Windows.Forms.Label
    Friend WithEvents Tb_Extension As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Tb_Flexion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Gb_Palpacion As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Espasmo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Espasmo As System.Windows.Forms.Label
    Friend WithEvents Tb_Dolor As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Dolor As System.Windows.Forms.Label
    Friend WithEvents Gb_Inspeccion As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Curvatura As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Curvatura As System.Windows.Forms.Label
    Friend WithEvents Tb_Simetria As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Simetria As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_EvidenciasClinicas As System.Windows.Forms.TextBox
    Friend WithEvents Gb_SignosVitales As System.Windows.Forms.GroupBox
    Friend WithEvents Num_PerimetroAbdomen As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_SO2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_FR As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_FC As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_TaDiast As System.Windows.Forms.NumericUpDown
    Friend WithEvents Num_TaSist As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tb_IMC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tb_Talla As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tb_Peso As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Peso As System.Windows.Forms.Label
    Friend WithEvents Lb_SO2 As System.Windows.Forms.Label
    Friend WithEvents Lb_FR As System.Windows.Forms.Label
    Friend WithEvents Lb_FC As System.Windows.Forms.Label
    Friend WithEvents Lb_TaDiast As System.Windows.Forms.Label
    Friend WithEvents Lb_TaSist As System.Windows.Forms.Label
    Friend WithEvents TP_AntecedentesPatologicos As System.Windows.Forms.TabPage
    Friend WithEvents Dgv_Habitos As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Habitos As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarHabito As System.Windows.Forms.Button
    Friend WithEvents Lb_Habitos As System.Windows.Forms.Label
    Friend WithEvents Dgv_Antecedentes As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Antecedentes As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarAntecedente As System.Windows.Forms.Button
    Friend WithEvents Lb_Antecedentes As System.Windows.Forms.Label
    Friend WithEvents TP_Antecedentes As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarEnfermedades As System.Windows.Forms.Button
    Friend WithEvents Lb_Enfermedades As System.Windows.Forms.Label
    Friend WithEvents Dgv_Enfermedades As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv_Accidente As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarAccidente As System.Windows.Forms.Button
    Friend WithEvents Lb_Accidente As System.Windows.Forms.Label
    Friend WithEvents TP_DescripcionCargo As System.Windows.Forms.TabPage
    Friend WithEvents Dgv_Higiene As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarHigieneIndustrial As System.Windows.Forms.Button
    Friend WithEvents Lb_HigieneIndustrial As System.Windows.Forms.Label
    Friend WithEvents Dgv_Tareas As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarTarea As System.Windows.Forms.Button
    Friend WithEvents Lb_Tarea As System.Windows.Forms.Label
    Friend WithEvents TP_DatosPersonales As System.Windows.Forms.TabPage
    Friend WithEvents TC_ExamenMedicoPeriodico As System.Windows.Forms.TabControl
    Friend WithEvents DGVC_HigieneIndustrial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_TLVs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_Alteracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_OrganoBlanco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_Efecto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_Tarea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_Agente As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVC_Magnitud As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVT_Frecuencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gb_DatosPersonales As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_TipoCargo As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_Cargo As System.Windows.Forms.ComboBox
    Friend WithEvents Cu_AsociarPersonaReporte As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Num_Turnos As System.Windows.Forms.NumericUpDown
    Friend WithEvents Cu_BuscarPersonaExamenMedico As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cb_EPS As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_EPS As System.Windows.Forms.Label
    Friend WithEvents Cb_AFP As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_FondoPensiones As System.Windows.Forms.Label
    Friend WithEvents Cb_GrupoSanguineo As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TipoSangre As System.Windows.Forms.Label
    Friend WithEvents Lb_Turnos As System.Windows.Forms.Label
    Friend WithEvents Cb_Jornada As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Jornada As System.Windows.Forms.Label
    Friend WithEvents Num_CargoMeses As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lb_TiempoCargoMeses As System.Windows.Forms.Label
    Friend WithEvents Num_CargoAños As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lb_TiempoCargoAños As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaIngreso As System.Windows.Forms.Label
    Friend WithEvents Lb_TipoCargo As System.Windows.Forms.Label
    Friend WithEvents Lb_Cargo As System.Windows.Forms.Label
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Dependencia As System.Windows.Forms.Label
    Friend WithEvents Cb_Base As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Base As System.Windows.Forms.Label
    Friend WithEvents Cb_Proyecto As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Proyecto As System.Windows.Forms.Label
    Friend WithEvents Cb_Dominancia As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Dominancia As System.Windows.Forms.Label
    Friend WithEvents Cb_EstadoCivil As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_EstadoCivil As System.Windows.Forms.Label
    Friend WithEvents Cb_NivelAcademico As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_NivelAcademico As System.Windows.Forms.Label
    Friend WithEvents Tb_Edad As System.Windows.Forms.TextBox
    Friend WithEvents Gb_Genero As System.Windows.Forms.GroupBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Rb_Femenino As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Masculino As System.Windows.Forms.RadioButton
    Friend WithEvents Lb_Edad As System.Windows.Forms.Label
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Gb_Riesgo As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_Locativo As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Natural As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Quimico As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Fisico As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Seguridad As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Biológico As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Psicosocial As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Biomecanico As System.Windows.Forms.CheckBox
    Friend WithEvents DGVT_IDENFERMEDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_CODIGOENFERMEDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_NOMBREENFERMEDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_ImpresionDiagnostica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGTB_IDENFERMEDADANTECEDENTES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGTB_CODIGOENFERMEDADANTECEDENTES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_Enfermedad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_OrigenEnfermedad As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVC_SecuelaEnfermedad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_TIPODGVENFERMEDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_IdDgvAccidente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_CodigoDgvAccidente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_Accidente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_OrigenAccidente As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVT_SecuelaAccidente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_TIPOACCIDENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gb_TipoExamen As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_ExamenIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_ExamenPeriodico As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_ExamenEgreso As System.Windows.Forms.RadioButton
    Friend WithEvents Gb_Laboratorios As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_NoExComplementario As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_SiExComplementario As System.Windows.Forms.RadioButton
    Friend WithEvents TP_ExamenComplementario As System.Windows.Forms.TabPage
    Friend WithEvents Gb_ExamenesComplementarios As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_ImagenesDiagnosticas As System.Windows.Forms.TextBox
    Friend WithEvents Cb_EKG As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Triglicerios As System.Windows.Forms.Label
    Friend WithEvents Cb_Espirometria As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Glicemia As System.Windows.Forms.Label
    Friend WithEvents Cb_Audiometria As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_FuncionRenal As System.Windows.Forms.Label
    Friend WithEvents Lb_Audiometria As System.Windows.Forms.Label
    Friend WithEvents Lb_Espirometría As System.Windows.Forms.Label
    Friend WithEvents Lb_EKG As System.Windows.Forms.Label
    Friend WithEvents Gb_CuadroHematico As System.Windows.Forms.GroupBox
    Friend WithEvents Lb_LineaRoja As System.Windows.Forms.Label
    Friend WithEvents Tb_Plaquetas As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Plaquetas As System.Windows.Forms.Label
    Friend WithEvents Tb_LineaBlanca As System.Windows.Forms.TextBox
    Friend WithEvents Lb_LineaBlanca As System.Windows.Forms.Label
    Friend WithEvents Tb_LineaRoja As System.Windows.Forms.TextBox
    Friend WithEvents Gb_Quimica As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Triglicerios As System.Windows.Forms.TextBox
    Friend WithEvents Tb_HDL As System.Windows.Forms.TextBox
    Friend WithEvents Lb_HDL As System.Windows.Forms.Label
    Friend WithEvents Tb_LDL As System.Windows.Forms.TextBox
    Friend WithEvents Lb_LDL As System.Windows.Forms.Label
    Friend WithEvents Tb_Colesterol As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Colesterol As System.Windows.Forms.Label
    Friend WithEvents Tb_Glicemia As System.Windows.Forms.TextBox
    Friend WithEvents Gb_Visiometria As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_OtrasAlteracionesVisuales As System.Windows.Forms.TextBox
    Friend WithEvents Lb_OtrasAlt As System.Windows.Forms.Label
    Friend WithEvents Ck_VConjuntiva As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_VParpados As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_VMovilidad As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_VLejos As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_VCerca As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_VNormal As System.Windows.Forms.CheckBox
    Friend WithEvents Gb_Psicofarmacos As System.Windows.Forms.GroupBox
    Friend WithEvents Ck_PsCocaina As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_PsMarihuana As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_PsNegativo As System.Windows.Forms.CheckBox
    Friend WithEvents Tb_FuncionHepaticaAST As System.Windows.Forms.TextBox
    Friend WithEvents Tb_FuncionRenal As System.Windows.Forms.TextBox
    Friend WithEvents Gb_ParcialOrina As System.Windows.Forms.GroupBox
    Friend WithEvents Ck_POCreatinuria As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_POEritocitocis As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_POAlbumina As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_POSangre As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_POCalcio As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_POGlucosuria As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_POProteinura As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_POBacterias As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_PONormal As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Tb_EKGConclusion As System.Windows.Forms.TextBox
    Friend WithEvents Tb_FuncionHepaticaConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Tb_FuncionRenalConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Tb_GlicemiaConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Tb_Quimica As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ObsQuimica As System.Windows.Forms.Label
    Friend WithEvents Tb_CuadroHematico As System.Windows.Forms.TextBox
    Friend WithEvents Lb_ObsCH As System.Windows.Forms.Label
    Friend WithEvents Lb_ObsFR As System.Windows.Forms.Label
    Friend WithEvents Lb_ObsGlicemia As System.Windows.Forms.Label
    Friend WithEvents Gb_FuncionHepatica As System.Windows.Forms.GroupBox
    Friend WithEvents Lb_ALT As System.Windows.Forms.Label
    Friend WithEvents Tb_FuncionHepaticaALT As System.Windows.Forms.TextBox
    Friend WithEvents Lb_AST As System.Windows.Forms.Label
    Friend WithEvents Lb_ObsFH As System.Windows.Forms.Label
    Friend WithEvents Lb_MunicipioContrato As System.Windows.Forms.Label
    Friend WithEvents Cu_CiudadContrato As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Dgv_AntecedenteLaborales As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gb_RevisionSistemas As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_RevisionSistemas As System.Windows.Forms.TextBox
    Friend WithEvents DGVC_Antecedentes As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVC_DescripcionAntecedentes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DGVC_Habitos As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVCB_Aplica As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVCT_NumTiempo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_TIEMPO As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVC_FrecuenciaHabitos As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVC_Intensidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_AbandonoHabito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_NroItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_NOMBREEMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_TiempoTrabajadoMeses As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_TiempoTrabajadoAños As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_ARL As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVCK_Incapacidad As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DGVC_Origen As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVT_DiasIncapacidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_Secuela As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_Jornada As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVT_Turno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_Cargo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Bt_Riesgos As System.Windows.Forms.DataGridViewButtonColumn
End Class
