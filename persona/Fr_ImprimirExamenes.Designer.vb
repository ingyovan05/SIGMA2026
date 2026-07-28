<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ImprimirExamenes
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
        Me.Pn_Encabezado = New System.Windows.Forms.Panel()
        Me.Cu_CentroCostoExamenes = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Ck_Alturas = New System.Windows.Forms.CheckBox()
        Me.Ck_Inmersiones = New System.Windows.Forms.CheckBox()
        Me.Ck_EspaciosConfinados = New System.Windows.Forms.CheckBox()
        Me.Lb_TextoFechaEnvio = New System.Windows.Forms.Label()
        Me.Dtp_FechaEnvio = New System.Windows.Forms.DateTimePicker()
        Me.Bt_BuscarCentroClinico = New System.Windows.Forms.Button()
        Me.Lb_TextoMotivo = New System.Windows.Forms.Label()
        Me.Cb_MotivoConsulta = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoCargo = New System.Windows.Forms.Label()
        Me.Cb_TipoCargo = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoEdad = New System.Windows.Forms.Label()
        Me.Tx_Edad = New System.Windows.Forms.TextBox()
        Me.Lb_TextoIPS = New System.Windows.Forms.Label()
        Me.Cb_CentroClinico = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoPeso = New System.Windows.Forms.Label()
        Me.Tx_Peso = New System.Windows.Forms.TextBox()
        Me.Flp_ImprFormatosAdicion = New System.Windows.Forms.FlowLayoutPanel()
        Me.Ck_ImprFormatoDatosPersonal = New System.Windows.Forms.CheckBox()
        Me.Ck_ImprListadoDocumentos = New System.Windows.Forms.CheckBox()
        Me.Ck_ImprConsentimientoInformado = New System.Windows.Forms.CheckBox()
        Me.Ck_ImprTratamientoDatos = New System.Windows.Forms.CheckBox()
        Me.Ck_ImprPensionYSalud = New System.Windows.Forms.CheckBox()
        Me.Dgv_Examenes = New System.Windows.Forms.DataGridView()
        Me.DGVTBC_Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_CodExamen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NombreExamen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Practicar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Bt_Imprimir = New System.Windows.Forms.Button()
        Me.Pn_Examenes = New System.Windows.Forms.Panel()
        Me.Pn_TituloExamenes = New System.Windows.Forms.Panel()
        Me.Lb_TituloExamenes = New System.Windows.Forms.Label()
        Me.Lb_Identificacion = New System.Windows.Forms.Label()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Lb_TextoIdentificacion = New System.Windows.Forms.Label()
        Me.Flp_Identificacion = New System.Windows.Forms.FlowLayoutPanel()
        Me.Tlp_DatosPersona = New System.Windows.Forms.TableLayoutPanel()
        Me.Pn_ConceptoMedico = New System.Windows.Forms.Panel()
        Me.Tx_ConceptoMedico = New System.Windows.Forms.TextBox()
        Me.Cms_ConceptoMedico = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Pn_ContinuaProceso = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dtp_FechaConcepto = New System.Windows.Forms.DateTimePicker()
        Me.Rb_ConceptoNo = New System.Windows.Forms.RadioButton()
        Me.Rb_ConceptoSi = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lb_TituloConcepto = New System.Windows.Forms.Label()
        Me.Pn_Adicionales = New System.Windows.Forms.Panel()
        Me.Lb_TextoObservaciones = New System.Windows.Forms.Label()
        Me.Tx_Observaciones = New System.Windows.Forms.TextBox()
        Me.Cms_Observaciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Tsmi_PARAFACTURARAISMOCOLGENERAL = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tt_ImprFormatosAdicionales = New System.Windows.Forms.ToolTip(Me.components)
        Me.Tlp_ImprFormatosAdicion = New System.Windows.Forms.TableLayoutPanel()
        Me.Lc_ImprFormatosAdicion = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_Encabezado.SuspendLayout()
        Me.Flp_ImprFormatosAdicion.SuspendLayout()
        CType(Me.Dgv_Examenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Examenes.SuspendLayout()
        Me.Pn_TituloExamenes.SuspendLayout()
        Me.Flp_Identificacion.SuspendLayout()
        Me.Tlp_DatosPersona.SuspendLayout()
        Me.Pn_ConceptoMedico.SuspendLayout()
        Me.Pn_ContinuaProceso.SuspendLayout()
        Me.Pn_Adicionales.SuspendLayout()
        Me.Cms_Observaciones.SuspendLayout()
        Me.Tlp_ImprFormatosAdicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Encabezado
        '
        Me.Pn_Encabezado.Controls.Add(Me.Cu_CentroCostoExamenes)
        Me.Pn_Encabezado.Controls.Add(Me.Label3)
        Me.Pn_Encabezado.Controls.Add(Me.Ck_Alturas)
        Me.Pn_Encabezado.Controls.Add(Me.Ck_Inmersiones)
        Me.Pn_Encabezado.Controls.Add(Me.Ck_EspaciosConfinados)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_TextoFechaEnvio)
        Me.Pn_Encabezado.Controls.Add(Me.Dtp_FechaEnvio)
        Me.Pn_Encabezado.Controls.Add(Me.Bt_BuscarCentroClinico)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_TextoMotivo)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_MotivoConsulta)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_TextoCargo)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_TipoCargo)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_TextoEdad)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_Edad)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_TextoIPS)
        Me.Pn_Encabezado.Controls.Add(Me.Cb_CentroClinico)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_TextoPeso)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_Peso)
        Me.Pn_Encabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Encabezado.Location = New System.Drawing.Point(0, 30)
        Me.Pn_Encabezado.Name = "Pn_Encabezado"
        Me.Pn_Encabezado.Size = New System.Drawing.Size(678, 139)
        Me.Pn_Encabezado.TabIndex = 1
        '
        'Cu_CentroCostoExamenes
        '
        Me.Cu_CentroCostoExamenes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCostoExamenes.Location = New System.Drawing.Point(471, 95)
        Me.Cu_CentroCostoExamenes.Name = "Cu_CentroCostoExamenes"
        Me.Cu_CentroCostoExamenes.Size = New System.Drawing.Size(199, 38)
        Me.Cu_CentroCostoExamenes.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Tareas Críticas:"
        '
        'Ck_Alturas
        '
        Me.Ck_Alturas.AutoSize = True
        Me.Ck_Alturas.Location = New System.Drawing.Point(100, 91)
        Me.Ck_Alturas.Margin = New System.Windows.Forms.Padding(2)
        Me.Ck_Alturas.Name = "Ck_Alturas"
        Me.Ck_Alturas.Size = New System.Drawing.Size(58, 17)
        Me.Ck_Alturas.TabIndex = 14
        Me.Ck_Alturas.Text = "Alturas"
        Me.Ck_Alturas.UseVisualStyleBackColor = True
        '
        'Ck_Inmersiones
        '
        Me.Ck_Inmersiones.AutoSize = True
        Me.Ck_Inmersiones.Location = New System.Drawing.Point(317, 91)
        Me.Ck_Inmersiones.Margin = New System.Windows.Forms.Padding(2)
        Me.Ck_Inmersiones.Name = "Ck_Inmersiones"
        Me.Ck_Inmersiones.Size = New System.Drawing.Size(82, 17)
        Me.Ck_Inmersiones.TabIndex = 16
        Me.Ck_Inmersiones.Text = "Inmersiones"
        Me.Ck_Inmersiones.UseVisualStyleBackColor = True
        '
        'Ck_EspaciosConfinados
        '
        Me.Ck_EspaciosConfinados.AutoSize = True
        Me.Ck_EspaciosConfinados.Location = New System.Drawing.Point(176, 91)
        Me.Ck_EspaciosConfinados.Margin = New System.Windows.Forms.Padding(2)
        Me.Ck_EspaciosConfinados.Name = "Ck_EspaciosConfinados"
        Me.Ck_EspaciosConfinados.Size = New System.Drawing.Size(125, 17)
        Me.Ck_EspaciosConfinados.TabIndex = 15
        Me.Ck_EspaciosConfinados.Text = "Espacios Confinados"
        Me.Ck_EspaciosConfinados.UseVisualStyleBackColor = True
        '
        'Lb_TextoFechaEnvio
        '
        Me.Lb_TextoFechaEnvio.AutoSize = True
        Me.Lb_TextoFechaEnvio.Location = New System.Drawing.Point(499, 15)
        Me.Lb_TextoFechaEnvio.Name = "Lb_TextoFechaEnvio"
        Me.Lb_TextoFechaEnvio.Size = New System.Drawing.Size(86, 13)
        Me.Lb_TextoFechaEnvio.TabIndex = 2
        Me.Lb_TextoFechaEnvio.Text = "Fecha de envío:"
        '
        'Dtp_FechaEnvio
        '
        Me.Dtp_FechaEnvio.Checked = False
        Me.Dtp_FechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaEnvio.Location = New System.Drawing.Point(592, 13)
        Me.Dtp_FechaEnvio.Name = "Dtp_FechaEnvio"
        Me.Dtp_FechaEnvio.Size = New System.Drawing.Size(78, 20)
        Me.Dtp_FechaEnvio.TabIndex = 3
        '
        'Bt_BuscarCentroClinico
        '
        Me.Bt_BuscarCentroClinico.AutoSize = True
        Me.Bt_BuscarCentroClinico.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_BuscarCentroClinico.Location = New System.Drawing.Point(470, 63)
        Me.Bt_BuscarCentroClinico.Name = "Bt_BuscarCentroClinico"
        Me.Bt_BuscarCentroClinico.Size = New System.Drawing.Size(26, 23)
        Me.Bt_BuscarCentroClinico.TabIndex = 10
        Me.Bt_BuscarCentroClinico.Text = "..."
        Me.Bt_BuscarCentroClinico.UseVisualStyleBackColor = True
        Me.Bt_BuscarCentroClinico.Visible = False
        '
        'Lb_TextoMotivo
        '
        Me.Lb_TextoMotivo.AutoSize = True
        Me.Lb_TextoMotivo.Location = New System.Drawing.Point(56, 13)
        Me.Lb_TextoMotivo.Name = "Lb_TextoMotivo"
        Me.Lb_TextoMotivo.Size = New System.Drawing.Size(42, 13)
        Me.Lb_TextoMotivo.TabIndex = 0
        Me.Lb_TextoMotivo.Text = "Motivo:"
        '
        'Cb_MotivoConsulta
        '
        Me.Cb_MotivoConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_MotivoConsulta.FormattingEnabled = True
        Me.Cb_MotivoConsulta.Location = New System.Drawing.Point(100, 10)
        Me.Cb_MotivoConsulta.Name = "Cb_MotivoConsulta"
        Me.Cb_MotivoConsulta.Size = New System.Drawing.Size(366, 21)
        Me.Cb_MotivoConsulta.TabIndex = 1
        '
        'Lb_TextoCargo
        '
        Me.Lb_TextoCargo.AutoSize = True
        Me.Lb_TextoCargo.Location = New System.Drawing.Point(60, 40)
        Me.Lb_TextoCargo.Name = "Lb_TextoCargo"
        Me.Lb_TextoCargo.Size = New System.Drawing.Size(38, 13)
        Me.Lb_TextoCargo.TabIndex = 4
        Me.Lb_TextoCargo.Text = "Cargo:"
        '
        'Cb_TipoCargo
        '
        Me.Cb_TipoCargo.DisplayMember = "NOMBRETIPOCARGO"
        Me.Cb_TipoCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoCargo.FormattingEnabled = True
        Me.Cb_TipoCargo.Location = New System.Drawing.Point(100, 37)
        Me.Cb_TipoCargo.Name = "Cb_TipoCargo"
        Me.Cb_TipoCargo.Size = New System.Drawing.Size(366, 21)
        Me.Cb_TipoCargo.TabIndex = 5
        Me.Cb_TipoCargo.ValueMember = "CODIGOTIPOCARGO"
        '
        'Lb_TextoEdad
        '
        Me.Lb_TextoEdad.AutoSize = True
        Me.Lb_TextoEdad.Location = New System.Drawing.Point(595, 41)
        Me.Lb_TextoEdad.Name = "Lb_TextoEdad"
        Me.Lb_TextoEdad.Size = New System.Drawing.Size(35, 13)
        Me.Lb_TextoEdad.TabIndex = 6
        Me.Lb_TextoEdad.Text = "Edad:"
        '
        'Tx_Edad
        '
        Me.Tx_Edad.Enabled = False
        Me.Tx_Edad.Location = New System.Drawing.Point(636, 39)
        Me.Tx_Edad.Name = "Tx_Edad"
        Me.Tx_Edad.ReadOnly = True
        Me.Tx_Edad.Size = New System.Drawing.Size(33, 20)
        Me.Tx_Edad.TabIndex = 7
        Me.Tx_Edad.Text = "0"
        Me.Tx_Edad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lb_TextoIPS
        '
        Me.Lb_TextoIPS.AutoSize = True
        Me.Lb_TextoIPS.Location = New System.Drawing.Point(7, 67)
        Me.Lb_TextoIPS.Name = "Lb_TextoIPS"
        Me.Lb_TextoIPS.Size = New System.Drawing.Size(90, 13)
        Me.Lb_TextoIPS.TabIndex = 8
        Me.Lb_TextoIPS.Text = "IPS / CRC - CEA:"
        '
        'Cb_CentroClinico
        '
        Me.Cb_CentroClinico.DisplayMember = "NOMBRECENTROCLINICO"
        Me.Cb_CentroClinico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_CentroClinico.FormattingEnabled = True
        Me.Cb_CentroClinico.Location = New System.Drawing.Point(100, 64)
        Me.Cb_CentroClinico.Name = "Cb_CentroClinico"
        Me.Cb_CentroClinico.Size = New System.Drawing.Size(366, 21)
        Me.Cb_CentroClinico.TabIndex = 9
        Me.Cb_CentroClinico.ValueMember = "CODIGOCENTROCLINICO"
        '
        'Lb_TextoPeso
        '
        Me.Lb_TextoPeso.AutoSize = True
        Me.Lb_TextoPeso.Location = New System.Drawing.Point(574, 67)
        Me.Lb_TextoPeso.Name = "Lb_TextoPeso"
        Me.Lb_TextoPeso.Size = New System.Drawing.Size(56, 13)
        Me.Lb_TextoPeso.TabIndex = 11
        Me.Lb_TextoPeso.Text = "Peso (Kg):"
        '
        'Tx_Peso
        '
        Me.Tx_Peso.Enabled = False
        Me.Tx_Peso.Location = New System.Drawing.Point(636, 65)
        Me.Tx_Peso.Name = "Tx_Peso"
        Me.Tx_Peso.ReadOnly = True
        Me.Tx_Peso.Size = New System.Drawing.Size(34, 20)
        Me.Tx_Peso.TabIndex = 12
        Me.Tx_Peso.Text = "0"
        Me.Tx_Peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Flp_ImprFormatosAdicion
        '
        Me.Flp_ImprFormatosAdicion.Controls.Add(Me.Ck_ImprFormatoDatosPersonal)
        Me.Flp_ImprFormatosAdicion.Controls.Add(Me.Ck_ImprListadoDocumentos)
        Me.Flp_ImprFormatosAdicion.Controls.Add(Me.Ck_ImprConsentimientoInformado)
        Me.Flp_ImprFormatosAdicion.Controls.Add(Me.Ck_ImprTratamientoDatos)
        Me.Flp_ImprFormatosAdicion.Controls.Add(Me.Ck_ImprPensionYSalud)
        Me.Flp_ImprFormatosAdicion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_ImprFormatosAdicion.Location = New System.Drawing.Point(116, 0)
        Me.Flp_ImprFormatosAdicion.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_ImprFormatosAdicion.Name = "Flp_ImprFormatosAdicion"
        Me.Flp_ImprFormatosAdicion.Padding = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.Flp_ImprFormatosAdicion.Size = New System.Drawing.Size(562, 28)
        Me.Flp_ImprFormatosAdicion.TabIndex = 0
        '
        'Ck_ImprFormatoDatosPersonal
        '
        Me.Ck_ImprFormatoDatosPersonal.AutoSize = True
        Me.Ck_ImprFormatoDatosPersonal.Location = New System.Drawing.Point(7, 7)
        Me.Ck_ImprFormatoDatosPersonal.Margin = New System.Windows.Forms.Padding(7, 3, 3, 3)
        Me.Ck_ImprFormatoDatosPersonal.Name = "Ck_ImprFormatoDatosPersonal"
        Me.Ck_ImprFormatoDatosPersonal.Size = New System.Drawing.Size(99, 17)
        Me.Ck_ImprFormatoDatosPersonal.TabIndex = 0
        Me.Ck_ImprFormatoDatosPersonal.Text = "ICA-GRAL-F-97"
        Me.Tt_ImprFormatosAdicionales.SetToolTip(Me.Ck_ImprFormatoDatosPersonal, "Imprimir el formato ""REGISTRO DE DATOS PERSONALES""")
        Me.Ck_ImprFormatoDatosPersonal.UseVisualStyleBackColor = True
        '
        'Ck_ImprListadoDocumentos
        '
        Me.Ck_ImprListadoDocumentos.AutoSize = True
        Me.Ck_ImprListadoDocumentos.Location = New System.Drawing.Point(116, 7)
        Me.Ck_ImprListadoDocumentos.Margin = New System.Windows.Forms.Padding(7, 3, 3, 3)
        Me.Ck_ImprListadoDocumentos.Name = "Ck_ImprListadoDocumentos"
        Me.Ck_ImprListadoDocumentos.Size = New System.Drawing.Size(99, 17)
        Me.Ck_ImprListadoDocumentos.TabIndex = 1
        Me.Ck_ImprListadoDocumentos.Text = "ICA-GRAL-F-68"
        Me.Tt_ImprFormatosAdicionales.SetToolTip(Me.Ck_ImprListadoDocumentos, "Imprimir el formato ""DOCUMENTOS Y TRÁMITE PARA VINCULACIÓN DE NUEVOS EMPLEADOS""")
        Me.Ck_ImprListadoDocumentos.UseVisualStyleBackColor = True
        '
        'Ck_ImprConsentimientoInformado
        '
        Me.Ck_ImprConsentimientoInformado.AutoSize = True
        Me.Ck_ImprConsentimientoInformado.Location = New System.Drawing.Point(225, 7)
        Me.Ck_ImprConsentimientoInformado.Margin = New System.Windows.Forms.Padding(7, 3, 3, 3)
        Me.Ck_ImprConsentimientoInformado.Name = "Ck_ImprConsentimientoInformado"
        Me.Ck_ImprConsentimientoInformado.Size = New System.Drawing.Size(106, 17)
        Me.Ck_ImprConsentimientoInformado.TabIndex = 2
        Me.Ck_ImprConsentimientoInformado.Text = "ICH-GRAL-F-357"
        Me.Tt_ImprFormatosAdicionales.SetToolTip(Me.Ck_ImprConsentimientoInformado, "Imprimir el formato ""CONSENTIMIENTO INFORMADO""")
        Me.Ck_ImprConsentimientoInformado.UseVisualStyleBackColor = True
        '
        'Ck_ImprTratamientoDatos
        '
        Me.Ck_ImprTratamientoDatos.AutoSize = True
        Me.Ck_ImprTratamientoDatos.Location = New System.Drawing.Point(337, 7)
        Me.Ck_ImprTratamientoDatos.Name = "Ck_ImprTratamientoDatos"
        Me.Ck_ImprTratamientoDatos.Size = New System.Drawing.Size(105, 17)
        Me.Ck_ImprTratamientoDatos.TabIndex = 3
        Me.Ck_ImprTratamientoDatos.Text = "ICA GRAL-F-153"
        Me.Tt_ImprFormatosAdicionales.SetToolTip(Me.Ck_ImprTratamientoDatos, "Imprimir el formato ""AUTORIZACIÓN PARA EL TRATAMIENTO DE DATOS PERSONALES""")
        Me.Ck_ImprTratamientoDatos.UseVisualStyleBackColor = True
        '
        'Ck_ImprPensionYSalud
        '
        Me.Ck_ImprPensionYSalud.AutoSize = True
        Me.Ck_ImprPensionYSalud.Location = New System.Drawing.Point(452, 7)
        Me.Ck_ImprPensionYSalud.Margin = New System.Windows.Forms.Padding(7, 3, 3, 3)
        Me.Ck_ImprPensionYSalud.Name = "Ck_ImprPensionYSalud"
        Me.Ck_ImprPensionYSalud.Size = New System.Drawing.Size(105, 17)
        Me.Ck_ImprPensionYSalud.TabIndex = 4
        Me.Ck_ImprPensionYSalud.Text = "ICA GRAL-F-044"
        Me.Tt_ImprFormatosAdicionales.SetToolTip(Me.Ck_ImprPensionYSalud, "Imprimir el formato ""SELECCIÓN DE ADMINISTRADORA EN LOS SISTEMAS DE PENSIÓN Y SAL" & _
        "UD """)
        Me.Ck_ImprPensionYSalud.UseVisualStyleBackColor = True
        '
        'Dgv_Examenes
        '
        Me.Dgv_Examenes.AllowUserToAddRows = False
        Me.Dgv_Examenes.AllowUserToDeleteRows = False
        Me.Dgv_Examenes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan
        Me.Dgv_Examenes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Examenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_Examenes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Examenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Examenes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBC_Tipo, Me.Col_CodExamen, Me.Col_NombreExamen, Me.Col_Practicar})
        Me.Dgv_Examenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Examenes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Examenes.Location = New System.Drawing.Point(0, 24)
        Me.Dgv_Examenes.MultiSelect = False
        Me.Dgv_Examenes.Name = "Dgv_Examenes"
        Me.Dgv_Examenes.RowHeadersVisible = False
        Me.Dgv_Examenes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Examenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Examenes.Size = New System.Drawing.Size(678, 222)
        Me.Dgv_Examenes.TabIndex = 1
        '
        'DGVTBC_Tipo
        '
        Me.DGVTBC_Tipo.DataPropertyName = "TIPO"
        Me.DGVTBC_Tipo.FillWeight = 45.68528!
        Me.DGVTBC_Tipo.HeaderText = "Tipo"
        Me.DGVTBC_Tipo.Name = "DGVTBC_Tipo"
        Me.DGVTBC_Tipo.ReadOnly = True
        '
        'Col_CodExamen
        '
        Me.Col_CodExamen.DataPropertyName = "CODIGOEXAMENPREOCUPACIONAL"
        Me.Col_CodExamen.HeaderText = "CODIGOEXAMENPREOCUPACIONAL"
        Me.Col_CodExamen.Name = "Col_CodExamen"
        Me.Col_CodExamen.ReadOnly = True
        Me.Col_CodExamen.Visible = False
        '
        'Col_NombreExamen
        '
        Me.Col_NombreExamen.DataPropertyName = "NOMBREEXAMENPREOCUPACIONAL"
        Me.Col_NombreExamen.FillWeight = 494.6821!
        Me.Col_NombreExamen.HeaderText = "Examen"
        Me.Col_NombreExamen.Name = "Col_NombreExamen"
        Me.Col_NombreExamen.ReadOnly = True
        '
        'Col_Practicar
        '
        Me.Col_Practicar.DataPropertyName = "PRACTICAR"
        Me.Col_Practicar.FalseValue = "N"
        Me.Col_Practicar.FillWeight = 59.63267!
        Me.Col_Practicar.HeaderText = "Practicar"
        Me.Col_Practicar.Name = "Col_Practicar"
        Me.Col_Practicar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_Practicar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Col_Practicar.TrueValue = "S"
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cerrar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Imprimir)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 562)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(678, 29)
        Me.Flp_Botones.TabIndex = 6
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(600, 3)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 1
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Bt_Imprimir
        '
        Me.Bt_Imprimir.Location = New System.Drawing.Point(519, 3)
        Me.Bt_Imprimir.Name = "Bt_Imprimir"
        Me.Bt_Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Imprimir.TabIndex = 0
        Me.Bt_Imprimir.Text = "Imprimir"
        Me.Bt_Imprimir.UseVisualStyleBackColor = True
        '
        'Pn_Examenes
        '
        Me.Pn_Examenes.Controls.Add(Me.Dgv_Examenes)
        Me.Pn_Examenes.Controls.Add(Me.Pn_TituloExamenes)
        Me.Pn_Examenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Examenes.Location = New System.Drawing.Point(0, 169)
        Me.Pn_Examenes.Name = "Pn_Examenes"
        Me.Pn_Examenes.Size = New System.Drawing.Size(678, 246)
        Me.Pn_Examenes.TabIndex = 2
        '
        'Pn_TituloExamenes
        '
        Me.Pn_TituloExamenes.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Pn_TituloExamenes.Controls.Add(Me.Lb_TituloExamenes)
        Me.Pn_TituloExamenes.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloExamenes.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloExamenes.Name = "Pn_TituloExamenes"
        Me.Pn_TituloExamenes.Size = New System.Drawing.Size(678, 24)
        Me.Pn_TituloExamenes.TabIndex = 0
        '
        'Lb_TituloExamenes
        '
        Me.Lb_TituloExamenes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_TituloExamenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TituloExamenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TituloExamenes.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TituloExamenes.Name = "Lb_TituloExamenes"
        Me.Lb_TituloExamenes.Size = New System.Drawing.Size(678, 24)
        Me.Lb_TituloExamenes.TabIndex = 0
        Me.Lb_TituloExamenes.Text = "EXÁMENES"
        Me.Lb_TituloExamenes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_Identificacion
        '
        Me.Lb_Identificacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_Identificacion.AutoSize = True
        Me.Lb_Identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Identificacion.Location = New System.Drawing.Point(82, 4)
        Me.Lb_Identificacion.Name = "Lb_Identificacion"
        Me.Lb_Identificacion.Size = New System.Drawing.Size(111, 20)
        Me.Lb_Identificacion.TabIndex = 1
        Me.Lb_Identificacion.Text = "8.888.888.888"
        Me.Lb_Identificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Nombre.Location = New System.Drawing.Point(3, 0)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(434, 30)
        Me.Lb_Nombre.TabIndex = 0
        Me.Lb_Nombre.Text = "XXXXXXXXXX XXXXXXXXXX XXXXXXXXXX XXXXXXXXXX"
        Me.Lb_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_TextoIdentificacion
        '
        Me.Lb_TextoIdentificacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_TextoIdentificacion.AutoSize = True
        Me.Lb_TextoIdentificacion.Location = New System.Drawing.Point(3, 4)
        Me.Lb_TextoIdentificacion.Name = "Lb_TextoIdentificacion"
        Me.Lb_TextoIdentificacion.Size = New System.Drawing.Size(73, 20)
        Me.Lb_TextoIdentificacion.TabIndex = 0
        Me.Lb_TextoIdentificacion.Text = "Identificación:"
        Me.Lb_TextoIdentificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Flp_Identificacion
        '
        Me.Flp_Identificacion.Controls.Add(Me.Lb_TextoIdentificacion)
        Me.Flp_Identificacion.Controls.Add(Me.Lb_Identificacion)
        Me.Flp_Identificacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Identificacion.Location = New System.Drawing.Point(440, 0)
        Me.Flp_Identificacion.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Identificacion.Name = "Flp_Identificacion"
        Me.Flp_Identificacion.Padding = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.Flp_Identificacion.Size = New System.Drawing.Size(238, 30)
        Me.Flp_Identificacion.TabIndex = 1
        '
        'Tlp_DatosPersona
        '
        Me.Tlp_DatosPersona.ColumnCount = 2
        Me.Tlp_DatosPersona.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.Tlp_DatosPersona.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.Tlp_DatosPersona.Controls.Add(Me.Lb_Nombre, 0, 0)
        Me.Tlp_DatosPersona.Controls.Add(Me.Flp_Identificacion, 1, 0)
        Me.Tlp_DatosPersona.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tlp_DatosPersona.Location = New System.Drawing.Point(0, 0)
        Me.Tlp_DatosPersona.Name = "Tlp_DatosPersona"
        Me.Tlp_DatosPersona.RowCount = 1
        Me.Tlp_DatosPersona.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_DatosPersona.Size = New System.Drawing.Size(678, 30)
        Me.Tlp_DatosPersona.TabIndex = 0
        '
        'Pn_ConceptoMedico
        '
        Me.Pn_ConceptoMedico.Controls.Add(Me.Tx_ConceptoMedico)
        Me.Pn_ConceptoMedico.Controls.Add(Me.Pn_ContinuaProceso)
        Me.Pn_ConceptoMedico.Controls.Add(Me.Lb_TituloConcepto)
        Me.Pn_ConceptoMedico.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_ConceptoMedico.Location = New System.Drawing.Point(0, 447)
        Me.Pn_ConceptoMedico.Name = "Pn_ConceptoMedico"
        Me.Pn_ConceptoMedico.Size = New System.Drawing.Size(678, 87)
        Me.Pn_ConceptoMedico.TabIndex = 4
        '
        'Tx_ConceptoMedico
        '
        Me.Tx_ConceptoMedico.BackColor = System.Drawing.SystemColors.Window
        Me.Tx_ConceptoMedico.ContextMenuStrip = Me.Cms_ConceptoMedico
        Me.Tx_ConceptoMedico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tx_ConceptoMedico.Location = New System.Drawing.Point(202, 24)
        Me.Tx_ConceptoMedico.MaxLength = 200
        Me.Tx_ConceptoMedico.Multiline = True
        Me.Tx_ConceptoMedico.Name = "Tx_ConceptoMedico"
        Me.Tx_ConceptoMedico.Size = New System.Drawing.Size(476, 63)
        Me.Tx_ConceptoMedico.TabIndex = 1
        '
        'Cms_ConceptoMedico
        '
        Me.Cms_ConceptoMedico.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_ConceptoMedico.Name = "Cms_ConceptoMedico"
        Me.Cms_ConceptoMedico.Size = New System.Drawing.Size(61, 4)
        '
        'Pn_ContinuaProceso
        '
        Me.Pn_ContinuaProceso.BackColor = System.Drawing.SystemColors.Info
        Me.Pn_ContinuaProceso.Controls.Add(Me.Label1)
        Me.Pn_ContinuaProceso.Controls.Add(Me.Dtp_FechaConcepto)
        Me.Pn_ContinuaProceso.Controls.Add(Me.Rb_ConceptoNo)
        Me.Pn_ContinuaProceso.Controls.Add(Me.Rb_ConceptoSi)
        Me.Pn_ContinuaProceso.Controls.Add(Me.Label2)
        Me.Pn_ContinuaProceso.Dock = System.Windows.Forms.DockStyle.Left
        Me.Pn_ContinuaProceso.Location = New System.Drawing.Point(0, 24)
        Me.Pn_ContinuaProceso.Margin = New System.Windows.Forms.Padding(2)
        Me.Pn_ContinuaProceso.Name = "Pn_ContinuaProceso"
        Me.Pn_ContinuaProceso.Size = New System.Drawing.Size(202, 63)
        Me.Pn_ContinuaProceso.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Fecha Concepto:"
        '
        'Dtp_FechaConcepto
        '
        Me.Dtp_FechaConcepto.Checked = False
        Me.Dtp_FechaConcepto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaConcepto.Location = New System.Drawing.Point(100, 40)
        Me.Dtp_FechaConcepto.Name = "Dtp_FechaConcepto"
        Me.Dtp_FechaConcepto.ShowCheckBox = True
        Me.Dtp_FechaConcepto.Size = New System.Drawing.Size(88, 20)
        Me.Dtp_FechaConcepto.TabIndex = 18
        '
        'Rb_ConceptoNo
        '
        Me.Rb_ConceptoNo.AutoSize = True
        Me.Rb_ConceptoNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_ConceptoNo.Location = New System.Drawing.Point(93, 19)
        Me.Rb_ConceptoNo.Margin = New System.Windows.Forms.Padding(2)
        Me.Rb_ConceptoNo.Name = "Rb_ConceptoNo"
        Me.Rb_ConceptoNo.Size = New System.Drawing.Size(43, 17)
        Me.Rb_ConceptoNo.TabIndex = 16
        Me.Rb_ConceptoNo.TabStop = True
        Me.Rb_ConceptoNo.Text = "NO"
        Me.Rb_ConceptoNo.UseVisualStyleBackColor = True
        '
        'Rb_ConceptoSi
        '
        Me.Rb_ConceptoSi.AutoSize = True
        Me.Rb_ConceptoSi.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_ConceptoSi.Location = New System.Drawing.Point(51, 19)
        Me.Rb_ConceptoSi.Margin = New System.Windows.Forms.Padding(2)
        Me.Rb_ConceptoSi.Name = "Rb_ConceptoSi"
        Me.Rb_ConceptoSi.Size = New System.Drawing.Size(37, 17)
        Me.Rb_ConceptoSi.TabIndex = 15
        Me.Rb_ConceptoSi.TabStop = True
        Me.Rb_ConceptoSi.Text = "SI"
        Me.Rb_ConceptoSi.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Info
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 14)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "¿Continuar Proceso?"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_TituloConcepto
        '
        Me.Lb_TituloConcepto.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Lb_TituloConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_TituloConcepto.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_TituloConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TituloConcepto.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TituloConcepto.Name = "Lb_TituloConcepto"
        Me.Lb_TituloConcepto.Size = New System.Drawing.Size(678, 24)
        Me.Lb_TituloConcepto.TabIndex = 0
        Me.Lb_TituloConcepto.Text = "CONCEPTO"
        Me.Lb_TituloConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pn_Adicionales
        '
        Me.Pn_Adicionales.Controls.Add(Me.Lb_TextoObservaciones)
        Me.Pn_Adicionales.Controls.Add(Me.Tx_Observaciones)
        Me.Pn_Adicionales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Adicionales.Location = New System.Drawing.Point(0, 415)
        Me.Pn_Adicionales.Name = "Pn_Adicionales"
        Me.Pn_Adicionales.Size = New System.Drawing.Size(678, 32)
        Me.Pn_Adicionales.TabIndex = 3
        '
        'Lb_TextoObservaciones
        '
        Me.Lb_TextoObservaciones.AutoSize = True
        Me.Lb_TextoObservaciones.Location = New System.Drawing.Point(6, 9)
        Me.Lb_TextoObservaciones.Name = "Lb_TextoObservaciones"
        Me.Lb_TextoObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.Lb_TextoObservaciones.TabIndex = 2
        Me.Lb_TextoObservaciones.Text = "Observaciones:"
        '
        'Tx_Observaciones
        '
        Me.Tx_Observaciones.Location = New System.Drawing.Point(89, 6)
        Me.Tx_Observaciones.MaxLength = 200
        Me.Tx_Observaciones.Name = "Tx_Observaciones"
        Me.Tx_Observaciones.Size = New System.Drawing.Size(526, 20)
        Me.Tx_Observaciones.TabIndex = 3
        '
        'Cms_Observaciones
        '
        Me.Cms_Observaciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Cms_Observaciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsmi_PARAFACTURARAISMOCOLGENERAL, Me.Tsmi_PARAFACTURARAISMOCOLLOOP1, Me.Tsmi_PARAFACTURARAISMOCOLLOOP2, Me.Tsmi_PARAFACTURARAISMOCOLLOOP3})
        Me.Cms_Observaciones.Name = "Cms_ConceptoMedico"
        Me.Cms_Observaciones.Size = New System.Drawing.Size(286, 92)
        '
        'Tsmi_PARAFACTURARAISMOCOLGENERAL
        '
        Me.Tsmi_PARAFACTURARAISMOCOLGENERAL.Name = "Tsmi_PARAFACTURARAISMOCOLGENERAL"
        Me.Tsmi_PARAFACTURARAISMOCOLGENERAL.Size = New System.Drawing.Size(285, 22)
        Me.Tsmi_PARAFACTURARAISMOCOLGENERAL.Text = "PARA FACTURAR A: ISMOCOL GENERAL"
        '
        'Tsmi_PARAFACTURARAISMOCOLLOOP1
        '
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP1.Name = "Tsmi_PARAFACTURARAISMOCOLLOOP1"
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP1.Size = New System.Drawing.Size(285, 22)
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP1.Text = "PARA FACTURAR A: ISMOCOL LOOP1"
        '
        'Tsmi_PARAFACTURARAISMOCOLLOOP2
        '
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP2.Name = "Tsmi_PARAFACTURARAISMOCOLLOOP2"
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP2.Size = New System.Drawing.Size(285, 22)
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP2.Text = "PARA FACTURAR A: ISMOCOL LOOP2"
        '
        'Tsmi_PARAFACTURARAISMOCOLLOOP3
        '
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP3.Name = "Tsmi_PARAFACTURARAISMOCOLLOOP3"
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP3.Size = New System.Drawing.Size(285, 22)
        Me.Tsmi_PARAFACTURARAISMOCOLLOOP3.Text = "PARA FACTURAR A: ISMOCOL LOOP3"
        '
        'Tlp_ImprFormatosAdicion
        '
        Me.Tlp_ImprFormatosAdicion.ColumnCount = 2
        Me.Tlp_ImprFormatosAdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_ImprFormatosAdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_ImprFormatosAdicion.Controls.Add(Me.Lc_ImprFormatosAdicion, 0, 0)
        Me.Tlp_ImprFormatosAdicion.Controls.Add(Me.Flp_ImprFormatosAdicion, 1, 0)
        Me.Tlp_ImprFormatosAdicion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_ImprFormatosAdicion.Location = New System.Drawing.Point(0, 534)
        Me.Tlp_ImprFormatosAdicion.Name = "Tlp_ImprFormatosAdicion"
        Me.Tlp_ImprFormatosAdicion.RowCount = 1
        Me.Tlp_ImprFormatosAdicion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_ImprFormatosAdicion.Size = New System.Drawing.Size(678, 28)
        Me.Tlp_ImprFormatosAdicion.TabIndex = 5
        '
        'Lc_ImprFormatosAdicion
        '
        Me.Lc_ImprFormatosAdicion.AutoSize = True
        Me.Lc_ImprFormatosAdicion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lc_ImprFormatosAdicion.Location = New System.Drawing.Point(3, 0)
        Me.Lc_ImprFormatosAdicion.Name = "Lc_ImprFormatosAdicion"
        Me.Lc_ImprFormatosAdicion.Size = New System.Drawing.Size(110, 28)
        Me.Lc_ImprFormatosAdicion.TabIndex = 0
        Me.Lc_ImprFormatosAdicion.Text = "Formatos Adicionales:"
        Me.Lc_ImprFormatosAdicion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "TIPO"
        Me.DataGridViewTextBoxColumn1.FillWeight = 33.77734!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tipo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 59
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CODIGOEXAMENPREOCUPACIONAL"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CODIGOEXAMENPREOCUPACIONAL"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NOMBREEXAMENPREOCUPACIONAL"
        Me.DataGridViewTextBoxColumn3.FillWeight = 505.309!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Examen"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 879
        '
        'Fr_ImprimirExamenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 591)
        Me.Controls.Add(Me.Pn_Examenes)
        Me.Controls.Add(Me.Pn_Encabezado)
        Me.Controls.Add(Me.Tlp_DatosPersona)
        Me.Controls.Add(Me.Pn_Adicionales)
        Me.Controls.Add(Me.Pn_ConceptoMedico)
        Me.Controls.Add(Me.Tlp_ImprFormatosAdicion)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Name = "Fr_ImprimirExamenes"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Imprimir Exámenes"
        Me.Pn_Encabezado.ResumeLayout(False)
        Me.Pn_Encabezado.PerformLayout()
        Me.Flp_ImprFormatosAdicion.ResumeLayout(False)
        Me.Flp_ImprFormatosAdicion.PerformLayout()
        CType(Me.Dgv_Examenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Examenes.ResumeLayout(False)
        Me.Pn_TituloExamenes.ResumeLayout(False)
        Me.Flp_Identificacion.ResumeLayout(False)
        Me.Flp_Identificacion.PerformLayout()
        Me.Tlp_DatosPersona.ResumeLayout(False)
        Me.Tlp_DatosPersona.PerformLayout()
        Me.Pn_ConceptoMedico.ResumeLayout(False)
        Me.Pn_ConceptoMedico.PerformLayout()
        Me.Pn_ContinuaProceso.ResumeLayout(False)
        Me.Pn_ContinuaProceso.PerformLayout()
        Me.Pn_Adicionales.ResumeLayout(False)
        Me.Pn_Adicionales.PerformLayout()
        Me.Cms_Observaciones.ResumeLayout(False)
        Me.Tlp_ImprFormatosAdicion.ResumeLayout(False)
        Me.Tlp_ImprFormatosAdicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Encabezado As System.Windows.Forms.Panel
    Friend WithEvents Flp_ImprFormatosAdicion As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Ck_ImprFormatoDatosPersonal As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_ImprListadoDocumentos As System.Windows.Forms.CheckBox
    Friend WithEvents Dgv_Examenes As System.Windows.Forms.DataGridView
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Bt_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Pn_Examenes As System.Windows.Forms.Panel
    Friend WithEvents Pn_TituloExamenes As System.Windows.Forms.Panel
    Friend WithEvents Lb_TextoPeso As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoEdad As System.Windows.Forms.Label
    Friend WithEvents Lb_Identificacion As System.Windows.Forms.Label
    Friend WithEvents Lb_TituloExamenes As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoIPS As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCargo As System.Windows.Forms.Label
    Friend WithEvents Tx_Peso As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Edad As System.Windows.Forms.TextBox
    Friend WithEvents Cb_CentroClinico As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_TipoCargo As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoIdentificacion As System.Windows.Forms.Label
    Friend WithEvents Flp_Identificacion As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Tlp_DatosPersona As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Pn_ConceptoMedico As System.Windows.Forms.Panel
    Friend WithEvents Lb_TituloConcepto As System.Windows.Forms.Label
    Friend WithEvents Tx_ConceptoMedico As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoMotivo As System.Windows.Forms.Label
    Friend WithEvents Cb_MotivoConsulta As System.Windows.Forms.ComboBox
    Friend WithEvents Bt_BuscarCentroClinico As System.Windows.Forms.Button
    Friend WithEvents Pn_Adicionales As System.Windows.Forms.Panel
    Friend WithEvents Tx_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoObservaciones As System.Windows.Forms.Label
    Friend WithEvents Cms_ConceptoMedico As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Lb_TextoFechaEnvio As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaEnvio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Ck_ImprConsentimientoInformado As System.Windows.Forms.CheckBox
    Friend WithEvents Tt_ImprFormatosAdicionales As System.Windows.Forms.ToolTip
    Friend WithEvents Ck_ImprTratamientoDatos As System.Windows.Forms.CheckBox
    Friend WithEvents Tlp_ImprFormatosAdicion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lc_ImprFormatosAdicion As System.Windows.Forms.Label
    Friend WithEvents Ck_ImprPensionYSalud As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_Inmersiones As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_EspaciosConfinados As System.Windows.Forms.CheckBox
    Friend WithEvents Ck_Alturas As System.Windows.Forms.CheckBox
    Friend WithEvents Pn_ContinuaProceso As System.Windows.Forms.Panel
    Friend WithEvents Rb_ConceptoNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_ConceptoSi As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaConcepto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cms_Observaciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Tsmi_PARAFACTURARAISMOCOLGENERAL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_PARAFACTURARAISMOCOLLOOP1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_PARAFACTURARAISMOCOLLOOP2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_PARAFACTURARAISMOCOLLOOP3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DGVTBC_Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_CodExamen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NombreExamen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Practicar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cu_CentroCostoExamenes As FormulariosClasesBase.Cu_CentroCosto
End Class
