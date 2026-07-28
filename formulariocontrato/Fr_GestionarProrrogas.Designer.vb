<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_GestionarProrrogas
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
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Lb_Codigo = New System.Windows.Forms.Label()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Lb_TextoCodigo = New System.Windows.Forms.Label()
        Me.Lb_TextoNombre = New System.Windows.Forms.Label()
        Me.Dgv_Prorrogas = New System.Windows.Forms.DataGridView()
        Me.Col_IdContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdContratoProrroga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Consecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaInicio = New FormularioContrato.CalendarColumn()
        Me.Col_FechaFin = New FormularioContrato.CalendarColumn()
        Me.Col_FechaFirma = New FormularioContrato.CalendarColumn()
        Me.Col_Duracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_TipoDuracion = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Col_UsuarioRegistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdUsuarioRegistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_UsuarioModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdUsuarioModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_EstadoProrroga = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalendarColumn1 = New FormularioContrato.CalendarColumn()
        Me.CalendarColumn2 = New FormularioContrato.CalendarColumn()
        Me.CalendarColumn3 = New FormularioContrato.CalendarColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tlp_Encabezado = New System.Windows.Forms.TableLayoutPanel()
        Me.Lb_TextoFechaFirmaInicial = New System.Windows.Forms.Label()
        Me.Dtp_FechaFirmaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Lb_TextoFechaInicioContrato = New System.Windows.Forms.Label()
        Me.Lb_TextoFechaFinContrato = New System.Windows.Forms.Label()
        Me.Lb_TextoDuracionInicial = New System.Windows.Forms.Label()
        Me.Dtp_FechaTerminacionInicial = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_FechaInicioContrato = New System.Windows.Forms.DateTimePicker()
        Me.Flp_Duracion = New System.Windows.Forms.FlowLayoutPanel()
        Me.Nud_DuracionInicial = New System.Windows.Forms.NumericUpDown()
        Me.Cb_TipoDuracionInicial = New System.Windows.Forms.ComboBox()
        Me.Bt_EliminarUltimaProrroga = New System.Windows.Forms.Button()
        Me.Tlp_Acciones = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_Botones.SuspendLayout()
        CType(Me.Dgv_Prorrogas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tlp_Encabezado.SuspendLayout()
        Me.Flp_Duracion.SuspendLayout()
        CType(Me.Nud_DuracionInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tlp_Acciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(131, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(753, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(675, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(594, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Lb_Codigo
        '
        Me.Lb_Codigo.AutoSize = True
        Me.Lb_Codigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Codigo.Location = New System.Drawing.Point(534, 0)
        Me.Lb_Codigo.Name = "Lb_Codigo"
        Me.Lb_Codigo.Size = New System.Drawing.Size(347, 23)
        Me.Lb_Codigo.TabIndex = 3
        Me.Lb_Codigo.Text = "Lb_Codigo"
        Me.Lb_Codigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.Location = New System.Drawing.Point(152, 0)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(199, 23)
        Me.Lb_Nombre.TabIndex = 1
        Me.Lb_Nombre.Text = "Lb_Nombre"
        Me.Lb_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_TextoCodigo
        '
        Me.Lb_TextoCodigo.AutoSize = True
        Me.Lb_TextoCodigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoCodigo.Location = New System.Drawing.Point(357, 0)
        Me.Lb_TextoCodigo.Name = "Lb_TextoCodigo"
        Me.Lb_TextoCodigo.Size = New System.Drawing.Size(171, 23)
        Me.Lb_TextoCodigo.TabIndex = 2
        Me.Lb_TextoCodigo.Text = "Código:"
        Me.Lb_TextoCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_TextoNombre
        '
        Me.Lb_TextoNombre.AutoSize = True
        Me.Lb_TextoNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoNombre.Location = New System.Drawing.Point(3, 0)
        Me.Lb_TextoNombre.Name = "Lb_TextoNombre"
        Me.Lb_TextoNombre.Size = New System.Drawing.Size(143, 23)
        Me.Lb_TextoNombre.TabIndex = 0
        Me.Lb_TextoNombre.Text = "Nombre:"
        Me.Lb_TextoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dgv_Prorrogas
        '
        Me.Dgv_Prorrogas.AllowUserToAddRows = False
        Me.Dgv_Prorrogas.AllowUserToDeleteRows = False
        Me.Dgv_Prorrogas.AllowUserToResizeRows = False
        Me.Dgv_Prorrogas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Prorrogas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Prorrogas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Dgv_Prorrogas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Prorrogas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_IdContrato, Me.Col_IdContratoProrroga, Me.Col_Consecutivo, Me.Col_FechaInicio, Me.Col_FechaFin, Me.Col_FechaFirma, Me.Col_Duracion, Me.Col_TipoDuracion, Me.Col_UsuarioRegistra, Me.Col_IdUsuarioRegistra, Me.Col_FechaRegistro, Me.Col_UsuarioModifica, Me.Col_IdUsuarioModifica, Me.Col_FechaModificacion, Me.Col_EstadoProrroga})
        Me.Dgv_Prorrogas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Prorrogas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Prorrogas.Location = New System.Drawing.Point(0, 70)
        Me.Dgv_Prorrogas.Name = "Dgv_Prorrogas"
        Me.Dgv_Prorrogas.Size = New System.Drawing.Size(884, 121)
        Me.Dgv_Prorrogas.TabIndex = 1
        '
        'Col_IdContrato
        '
        Me.Col_IdContrato.DataPropertyName = "IDCONTRATO"
        Me.Col_IdContrato.HeaderText = "IDCONTRATO"
        Me.Col_IdContrato.Name = "Col_IdContrato"
        Me.Col_IdContrato.ReadOnly = True
        Me.Col_IdContrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_IdContrato.Visible = False
        '
        'Col_IdContratoProrroga
        '
        Me.Col_IdContratoProrroga.DataPropertyName = "IDCONTRATOPRORROGA"
        Me.Col_IdContratoProrroga.HeaderText = "IDCONTRATOPRORROGA"
        Me.Col_IdContratoProrroga.Name = "Col_IdContratoProrroga"
        Me.Col_IdContratoProrroga.ReadOnly = True
        Me.Col_IdContratoProrroga.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_IdContratoProrroga.Visible = False
        '
        'Col_Consecutivo
        '
        Me.Col_Consecutivo.DataPropertyName = "CONSECUTIVOPRORROGA"
        Me.Col_Consecutivo.HeaderText = "Consec."
        Me.Col_Consecutivo.Name = "Col_Consecutivo"
        Me.Col_Consecutivo.ReadOnly = True
        Me.Col_Consecutivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_Consecutivo.ToolTipText = "Consecutivo"
        '
        'Col_FechaInicio
        '
        Me.Col_FechaInicio.DataPropertyName = "FECHAINICIO"
        Me.Col_FechaInicio.HeaderText = "Fecha Inicio"
        Me.Col_FechaInicio.Name = "Col_FechaInicio"
        Me.Col_FechaInicio.ReadOnly = True
        Me.Col_FechaInicio.ToolTipText = "Fecha de inicio"
        '
        'Col_FechaFin
        '
        Me.Col_FechaFin.DataPropertyName = "FECHAFIN"
        Me.Col_FechaFin.HeaderText = "Fecha Fin"
        Me.Col_FechaFin.Name = "Col_FechaFin"
        Me.Col_FechaFin.ReadOnly = True
        Me.Col_FechaFin.ToolTipText = "Fecha de finalización"
        '
        'Col_FechaFirma
        '
        Me.Col_FechaFirma.DataPropertyName = "FECHAFIRMA"
        Me.Col_FechaFirma.HeaderText = "Fecha Firma"
        Me.Col_FechaFirma.Name = "Col_FechaFirma"
        Me.Col_FechaFirma.ToolTipText = "Fecha de firma"
        '
        'Col_Duracion
        '
        Me.Col_Duracion.DataPropertyName = "DURACION"
        Me.Col_Duracion.HeaderText = "Duración"
        Me.Col_Duracion.Name = "Col_Duracion"
        Me.Col_Duracion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_Duracion.ToolTipText = "Duración"
        '
        'Col_TipoDuracion
        '
        Me.Col_TipoDuracion.DataPropertyName = "CODIGOTIPODURACION"
        Me.Col_TipoDuracion.HeaderText = "Tipo Duración"
        Me.Col_TipoDuracion.Name = "Col_TipoDuracion"
        Me.Col_TipoDuracion.ToolTipText = "Tipo de duración"
        '
        'Col_UsuarioRegistra
        '
        Me.Col_UsuarioRegistra.DataPropertyName = "USUARIOREGISTRA"
        Me.Col_UsuarioRegistra.HeaderText = "USUARIOREGISTRA"
        Me.Col_UsuarioRegistra.Name = "Col_UsuarioRegistra"
        Me.Col_UsuarioRegistra.ReadOnly = True
        Me.Col_UsuarioRegistra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_UsuarioRegistra.Visible = False
        '
        'Col_IdUsuarioRegistra
        '
        Me.Col_IdUsuarioRegistra.DataPropertyName = "IDUSUARIOREGISTRA"
        Me.Col_IdUsuarioRegistra.HeaderText = "IDUSUARIOREGISTRA"
        Me.Col_IdUsuarioRegistra.Name = "Col_IdUsuarioRegistra"
        Me.Col_IdUsuarioRegistra.ReadOnly = True
        Me.Col_IdUsuarioRegistra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_IdUsuarioRegistra.Visible = False
        '
        'Col_FechaRegistro
        '
        Me.Col_FechaRegistro.DataPropertyName = "FECHAREGISTRO"
        Me.Col_FechaRegistro.HeaderText = "FECHAREGISTRO"
        Me.Col_FechaRegistro.Name = "Col_FechaRegistro"
        Me.Col_FechaRegistro.ReadOnly = True
        Me.Col_FechaRegistro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_FechaRegistro.Visible = False
        '
        'Col_UsuarioModifica
        '
        Me.Col_UsuarioModifica.DataPropertyName = "USUARIOMODIFICA"
        Me.Col_UsuarioModifica.HeaderText = "Usuario Modifica"
        Me.Col_UsuarioModifica.Name = "Col_UsuarioModifica"
        Me.Col_UsuarioModifica.ReadOnly = True
        Me.Col_UsuarioModifica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_UsuarioModifica.ToolTipText = "Usuario que modificó"
        '
        'Col_IdUsuarioModifica
        '
        Me.Col_IdUsuarioModifica.DataPropertyName = "IDUSUARIOMODIFICA"
        Me.Col_IdUsuarioModifica.HeaderText = "IDUSUARIOMODIFICA"
        Me.Col_IdUsuarioModifica.Name = "Col_IdUsuarioModifica"
        Me.Col_IdUsuarioModifica.ReadOnly = True
        Me.Col_IdUsuarioModifica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_IdUsuarioModifica.Visible = False
        '
        'Col_FechaModificacion
        '
        Me.Col_FechaModificacion.DataPropertyName = "FECHAMODIFICACION"
        Me.Col_FechaModificacion.HeaderText = "Fecha Modificiación"
        Me.Col_FechaModificacion.Name = "Col_FechaModificacion"
        Me.Col_FechaModificacion.ReadOnly = True
        Me.Col_FechaModificacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_FechaModificacion.ToolTipText = "Fecha de modificación"
        '
        'Col_EstadoProrroga
        '
        Me.Col_EstadoProrroga.DataPropertyName = "ESTADOPRORROGA"
        Me.Col_EstadoProrroga.FalseValue = "I"
        Me.Col_EstadoProrroga.HeaderText = "Estado"
        Me.Col_EstadoProrroga.Name = "Col_EstadoProrroga"
        Me.Col_EstadoProrroga.ReadOnly = True
        Me.Col_EstadoProrroga.ToolTipText = "Estado"
        Me.Col_EstadoProrroga.TrueValue = "A"
        Me.Col_EstadoProrroga.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDCONTRATO"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDCONTRATO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IDCONTRATOPRORROGA"
        Me.DataGridViewTextBoxColumn2.HeaderText = "IDCONTRATOPRORROGA"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CONSECUTIVOPRORROGA"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Consecutivo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'CalendarColumn1
        '
        Me.CalendarColumn1.DataPropertyName = "FECHAINICIO"
        Me.CalendarColumn1.HeaderText = "Fecha Inicio"
        Me.CalendarColumn1.Name = "CalendarColumn1"
        '
        'CalendarColumn2
        '
        Me.CalendarColumn2.DataPropertyName = "FECHAFIN"
        Me.CalendarColumn2.HeaderText = "Fecha Fin"
        Me.CalendarColumn2.Name = "CalendarColumn2"
        '
        'CalendarColumn3
        '
        Me.CalendarColumn3.DataPropertyName = "FECHAFIRMA"
        Me.CalendarColumn3.HeaderText = "Fecha Firma"
        Me.CalendarColumn3.Name = "CalendarColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DURACION"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Duración"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "IDUSUARIOREGISTRA"
        Me.DataGridViewTextBoxColumn5.HeaderText = "IDUSUARIOREGISTRA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "FECHAREGISTRO"
        Me.DataGridViewTextBoxColumn6.HeaderText = "FECHAREGISTRO"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "USUARIOMODIFICA"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Usuario Modifica"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "FECHAMODIFICACION"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Fecha Modificiación"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'Tlp_Encabezado
        '
        Me.Tlp_Encabezado.ColumnCount = 4
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_TextoFechaFirmaInicial, 0, 2)
        Me.Tlp_Encabezado.Controls.Add(Me.Dtp_FechaFirmaInicial, 1, 2)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_TextoNombre, 0, 0)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_Codigo, 3, 0)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_TextoFechaInicioContrato, 0, 1)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_Nombre, 1, 0)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_TextoCodigo, 2, 0)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_TextoFechaFinContrato, 2, 1)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_TextoDuracionInicial, 2, 2)
        Me.Tlp_Encabezado.Controls.Add(Me.Dtp_FechaTerminacionInicial, 3, 1)
        Me.Tlp_Encabezado.Controls.Add(Me.Dtp_FechaInicioContrato, 1, 1)
        Me.Tlp_Encabezado.Controls.Add(Me.Flp_Duracion, 3, 2)
        Me.Tlp_Encabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tlp_Encabezado.Location = New System.Drawing.Point(0, 0)
        Me.Tlp_Encabezado.Name = "Tlp_Encabezado"
        Me.Tlp_Encabezado.RowCount = 3
        Me.Tlp_Encabezado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Tlp_Encabezado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.Tlp_Encabezado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.Tlp_Encabezado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp_Encabezado.Size = New System.Drawing.Size(884, 70)
        Me.Tlp_Encabezado.TabIndex = 0
        '
        'Lb_TextoFechaFirmaInicial
        '
        Me.Lb_TextoFechaFirmaInicial.AutoSize = True
        Me.Lb_TextoFechaFirmaInicial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoFechaFirmaInicial.Location = New System.Drawing.Point(3, 46)
        Me.Lb_TextoFechaFirmaInicial.Name = "Lb_TextoFechaFirmaInicial"
        Me.Lb_TextoFechaFirmaInicial.Size = New System.Drawing.Size(143, 24)
        Me.Lb_TextoFechaFirmaInicial.TabIndex = 8
        Me.Lb_TextoFechaFirmaInicial.Text = "Fecha de Firma:"
        Me.Lb_TextoFechaFirmaInicial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dtp_FechaFirmaInicial
        '
        Me.Dtp_FechaFirmaInicial.Enabled = False
        Me.Dtp_FechaFirmaInicial.Location = New System.Drawing.Point(150, 47)
        Me.Dtp_FechaFirmaInicial.Margin = New System.Windows.Forms.Padding(1)
        Me.Dtp_FechaFirmaInicial.Name = "Dtp_FechaFirmaInicial"
        Me.Dtp_FechaFirmaInicial.Size = New System.Drawing.Size(203, 20)
        Me.Dtp_FechaFirmaInicial.TabIndex = 9
        '
        'Lb_TextoFechaInicioContrato
        '
        Me.Lb_TextoFechaInicioContrato.AutoSize = True
        Me.Lb_TextoFechaInicioContrato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoFechaInicioContrato.Location = New System.Drawing.Point(3, 23)
        Me.Lb_TextoFechaInicioContrato.Name = "Lb_TextoFechaInicioContrato"
        Me.Lb_TextoFechaInicioContrato.Size = New System.Drawing.Size(143, 23)
        Me.Lb_TextoFechaInicioContrato.TabIndex = 4
        Me.Lb_TextoFechaInicioContrato.Text = "Fecha de Inicio del Contrato:"
        Me.Lb_TextoFechaInicioContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_TextoFechaFinContrato
        '
        Me.Lb_TextoFechaFinContrato.AutoSize = True
        Me.Lb_TextoFechaFinContrato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoFechaFinContrato.Location = New System.Drawing.Point(357, 23)
        Me.Lb_TextoFechaFinContrato.Name = "Lb_TextoFechaFinContrato"
        Me.Lb_TextoFechaFinContrato.Size = New System.Drawing.Size(171, 23)
        Me.Lb_TextoFechaFinContrato.TabIndex = 6
        Me.Lb_TextoFechaFinContrato.Text = "Fecha Finalización Contrato Inicial:"
        Me.Lb_TextoFechaFinContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_TextoDuracionInicial
        '
        Me.Lb_TextoDuracionInicial.AutoSize = True
        Me.Lb_TextoDuracionInicial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoDuracionInicial.Location = New System.Drawing.Point(357, 46)
        Me.Lb_TextoDuracionInicial.Name = "Lb_TextoDuracionInicial"
        Me.Lb_TextoDuracionInicial.Size = New System.Drawing.Size(171, 24)
        Me.Lb_TextoDuracionInicial.TabIndex = 10
        Me.Lb_TextoDuracionInicial.Text = "Duración:"
        Me.Lb_TextoDuracionInicial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dtp_FechaTerminacionInicial
        '
        Me.Dtp_FechaTerminacionInicial.Enabled = False
        Me.Dtp_FechaTerminacionInicial.Location = New System.Drawing.Point(532, 24)
        Me.Dtp_FechaTerminacionInicial.Margin = New System.Windows.Forms.Padding(1)
        Me.Dtp_FechaTerminacionInicial.Name = "Dtp_FechaTerminacionInicial"
        Me.Dtp_FechaTerminacionInicial.Size = New System.Drawing.Size(203, 20)
        Me.Dtp_FechaTerminacionInicial.TabIndex = 7
        '
        'Dtp_FechaInicioContrato
        '
        Me.Dtp_FechaInicioContrato.Enabled = False
        Me.Dtp_FechaInicioContrato.Location = New System.Drawing.Point(150, 24)
        Me.Dtp_FechaInicioContrato.Margin = New System.Windows.Forms.Padding(1)
        Me.Dtp_FechaInicioContrato.Name = "Dtp_FechaInicioContrato"
        Me.Dtp_FechaInicioContrato.Size = New System.Drawing.Size(203, 20)
        Me.Dtp_FechaInicioContrato.TabIndex = 5
        '
        'Flp_Duracion
        '
        Me.Flp_Duracion.Controls.Add(Me.Nud_DuracionInicial)
        Me.Flp_Duracion.Controls.Add(Me.Cb_TipoDuracionInicial)
        Me.Flp_Duracion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Duracion.Location = New System.Drawing.Point(531, 46)
        Me.Flp_Duracion.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Duracion.Name = "Flp_Duracion"
        Me.Flp_Duracion.Size = New System.Drawing.Size(353, 24)
        Me.Flp_Duracion.TabIndex = 11
        '
        'Nud_DuracionInicial
        '
        Me.Nud_DuracionInicial.Location = New System.Drawing.Point(1, 1)
        Me.Nud_DuracionInicial.Margin = New System.Windows.Forms.Padding(1)
        Me.Nud_DuracionInicial.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.Nud_DuracionInicial.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_DuracionInicial.Name = "Nud_DuracionInicial"
        Me.Nud_DuracionInicial.Size = New System.Drawing.Size(48, 20)
        Me.Nud_DuracionInicial.TabIndex = 0
        Me.Nud_DuracionInicial.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Cb_TipoDuracionInicial
        '
        Me.Cb_TipoDuracionInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoDuracionInicial.FormattingEnabled = True
        Me.Cb_TipoDuracionInicial.Location = New System.Drawing.Point(58, 1)
        Me.Cb_TipoDuracionInicial.Margin = New System.Windows.Forms.Padding(8, 1, 1, 1)
        Me.Cb_TipoDuracionInicial.Name = "Cb_TipoDuracionInicial"
        Me.Cb_TipoDuracionInicial.Size = New System.Drawing.Size(59, 21)
        Me.Cb_TipoDuracionInicial.TabIndex = 1
        '
        'Bt_EliminarUltimaProrroga
        '
        Me.Bt_EliminarUltimaProrroga.AutoSize = True
        Me.Bt_EliminarUltimaProrroga.Enabled = False
        Me.Bt_EliminarUltimaProrroga.Location = New System.Drawing.Point(3, 3)
        Me.Bt_EliminarUltimaProrroga.Name = "Bt_EliminarUltimaProrroga"
        Me.Bt_EliminarUltimaProrroga.Size = New System.Drawing.Size(125, 23)
        Me.Bt_EliminarUltimaProrroga.TabIndex = 0
        Me.Bt_EliminarUltimaProrroga.Text = "Eliminar última prórroga"
        Me.Bt_EliminarUltimaProrroga.UseVisualStyleBackColor = True
        '
        'Tlp_Acciones
        '
        Me.Tlp_Acciones.ColumnCount = 2
        Me.Tlp_Acciones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Acciones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Acciones.Controls.Add(Me.Bt_EliminarUltimaProrroga, 0, 0)
        Me.Tlp_Acciones.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_Acciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_Acciones.Location = New System.Drawing.Point(0, 191)
        Me.Tlp_Acciones.Name = "Tlp_Acciones"
        Me.Tlp_Acciones.RowCount = 1
        Me.Tlp_Acciones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Acciones.Size = New System.Drawing.Size(884, 30)
        Me.Tlp_Acciones.TabIndex = 2
        '
        'Fr_GestionarProrrogas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 221)
        Me.Controls.Add(Me.Dgv_Prorrogas)
        Me.Controls.Add(Me.Tlp_Encabezado)
        Me.Controls.Add(Me.Tlp_Acciones)
        Me.Name = "Fr_GestionarProrrogas"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionar prórrogas"
        Me.Flp_Botones.ResumeLayout(False)
        CType(Me.Dgv_Prorrogas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tlp_Encabezado.ResumeLayout(False)
        Me.Tlp_Encabezado.PerformLayout()
        Me.Flp_Duracion.ResumeLayout(False)
        CType(Me.Nud_DuracionInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tlp_Acciones.ResumeLayout(False)
        Me.Tlp_Acciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Lb_Codigo As System.Windows.Forms.Label
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCodigo As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoNombre As System.Windows.Forms.Label
    Friend WithEvents Dgv_Prorrogas As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalendarColumn1 As FormularioContrato.CalendarColumn
    Friend WithEvents CalendarColumn2 As FormularioContrato.CalendarColumn
    Friend WithEvents CalendarColumn3 As FormularioContrato.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tlp_Encabezado As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lb_TextoFechaInicioContrato As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoFechaFinContrato As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoDuracionInicial As System.Windows.Forms.Label
    Friend WithEvents Bt_EliminarUltimaProrroga As System.Windows.Forms.Button
    Friend WithEvents Tlp_Acciones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Col_IdContrato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdContratoProrroga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Consecutivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaInicio As FormularioContrato.CalendarColumn
    Friend WithEvents Col_FechaFin As FormularioContrato.CalendarColumn
    Friend WithEvents Col_FechaFirma As FormularioContrato.CalendarColumn
    Friend WithEvents Col_Duracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_TipoDuracion As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Col_UsuarioRegistra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdUsuarioRegistra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_UsuarioModifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdUsuarioModifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaModificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_EstadoProrroga As System.Windows.Forms.DataGridViewCheckBoxColumn
    Public WithEvents Nud_DuracionInicial As System.Windows.Forms.NumericUpDown
    Public WithEvents Cb_TipoDuracionInicial As System.Windows.Forms.ComboBox
    Public WithEvents Dtp_FechaInicioContrato As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_FechaTerminacionInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_TextoFechaFirmaInicial As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaFirmaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Flp_Duracion As System.Windows.Forms.FlowLayoutPanel

End Class
