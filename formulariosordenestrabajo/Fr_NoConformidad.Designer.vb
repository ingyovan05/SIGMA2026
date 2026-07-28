<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_NoConformidad
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
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Pn_Cierre = New System.Windows.Forms.Panel()
        Me.Dtp_FechaCierre = New System.Windows.Forms.DateTimePicker()
        Me.Lb_TextoFechaCierre = New System.Windows.Forms.Label()
        Me.Tx_VerificacionEficacia = New System.Windows.Forms.TextBox()
        Me.Lb_TextoVerificacionEficacia = New System.Windows.Forms.Label()
        Me.Pn_DatosNC = New System.Windows.Forms.Panel()
        Me.Bt_AgregarAcciones = New System.Windows.Forms.Button()
        Me.Dgv_Acciones = New System.Windows.Forms.DataGridView()
        Me.Col_IdNoConformidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Acciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Aprueba = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaPropuesta = New FormulariosOrdenesTrabajo.CalendarColumn()
        Me.Col_Seguimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdUsuarioRegistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_UsuarioRegistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdUsuarioModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_UsuarioModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gb_AnalisisCausas = New System.Windows.Forms.GroupBox()
        Me.Bt_QuitarAnexoAC = New System.Windows.Forms.Button()
        Me.Bt_VerAnexoAC = New System.Windows.Forms.Button()
        Me.Lb_TextoAnexoAC = New System.Windows.Forms.Label()
        Me.Bt_CargarAnexoAC = New System.Windows.Forms.Button()
        Me.Tx_AnexoAC = New System.Windows.Forms.TextBox()
        Me.Ck_ExistenNC = New System.Windows.Forms.CheckBox()
        Me.Tx_RepProc = New System.Windows.Forms.TextBox()
        Me.Tx_Detector = New System.Windows.Forms.TextBox()
        Me.Tx_Contrato = New System.Windows.Forms.TextBox()
        Me.Lb_TextoOT = New System.Windows.Forms.Label()
        Me.Tx_Reaccion = New System.Windows.Forms.TextBox()
        Me.Lb_TextoReaccion = New System.Windows.Forms.Label()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Lb_TextoDescripcion = New System.Windows.Forms.Label()
        Me.Tx_Fuente = New System.Windows.Forms.TextBox()
        Me.Tx_Proceso = New System.Windows.Forms.TextBox()
        Me.Dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Tx_NumeroAuditoria = New System.Windows.Forms.TextBox()
        Me.Tx_NumeroReporte = New System.Windows.Forms.TextBox()
        Me.Lb_TextoRepProc = New System.Windows.Forms.Label()
        Me.Lb_TextoDetector = New System.Windows.Forms.Label()
        Me.Lb_TextoNumeroAuditoria = New System.Windows.Forms.Label()
        Me.Lb_TextoNumeroReporte = New System.Windows.Forms.Label()
        Me.Lb_TextoFuente = New System.Windows.Forms.Label()
        Me.Lb_TextoProceso = New System.Windows.Forms.Label()
        Me.Lb_TextoContrato = New System.Windows.Forms.Label()
        Me.Lb_TextoFecha = New System.Windows.Forms.Label()
        Me.Cb_Tipo = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoTipo = New System.Windows.Forms.Label()
        Me.Cb_Sistema = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoSistema = New System.Windows.Forms.Label()
        Me.Ofd_AnexoAnalisisCausas = New System.Windows.Forms.OpenFileDialog()
        Me.Tt_NoConformidad = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalendarColumn1 = New FormulariosOrdenesTrabajo.CalendarColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ofd_AnexoOrdenTrabajo = New System.Windows.Forms.OpenFileDialog()
        Me.Tx_OrdenTrabajo = New System.Windows.Forms.TextBox()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Cierre.SuspendLayout()
        Me.Pn_DatosNC.SuspendLayout()
        CType(Me.Dgv_Acciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gb_AnalisisCausas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 551)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(634, 30)
        Me.Flp_Botones.TabIndex = 2
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(556, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(475, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Pn_Cierre
        '
        Me.Pn_Cierre.Controls.Add(Me.Dtp_FechaCierre)
        Me.Pn_Cierre.Controls.Add(Me.Lb_TextoFechaCierre)
        Me.Pn_Cierre.Controls.Add(Me.Tx_VerificacionEficacia)
        Me.Pn_Cierre.Controls.Add(Me.Lb_TextoVerificacionEficacia)
        Me.Pn_Cierre.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Cierre.Location = New System.Drawing.Point(0, 473)
        Me.Pn_Cierre.Name = "Pn_Cierre"
        Me.Pn_Cierre.Size = New System.Drawing.Size(634, 78)
        Me.Pn_Cierre.TabIndex = 1
        '
        'Dtp_FechaCierre
        '
        Me.Dtp_FechaCierre.Checked = False
        Me.Dtp_FechaCierre.Enabled = False
        Me.Dtp_FechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaCierre.Location = New System.Drawing.Point(137, 52)
        Me.Dtp_FechaCierre.Name = "Dtp_FechaCierre"
        Me.Dtp_FechaCierre.Size = New System.Drawing.Size(95, 20)
        Me.Dtp_FechaCierre.TabIndex = 3
        '
        'Lb_TextoFechaCierre
        '
        Me.Lb_TextoFechaCierre.AutoSize = True
        Me.Lb_TextoFechaCierre.Enabled = False
        Me.Lb_TextoFechaCierre.Location = New System.Drawing.Point(49, 55)
        Me.Lb_TextoFechaCierre.Name = "Lb_TextoFechaCierre"
        Me.Lb_TextoFechaCierre.Size = New System.Drawing.Size(85, 13)
        Me.Lb_TextoFechaCierre.TabIndex = 2
        Me.Lb_TextoFechaCierre.Text = "Fecha de Cierre:"
        '
        'Tx_VerificacionEficacia
        '
        Me.Tx_VerificacionEficacia.Location = New System.Drawing.Point(137, 6)
        Me.Tx_VerificacionEficacia.MaxLength = 300
        Me.Tx_VerificacionEficacia.Multiline = True
        Me.Tx_VerificacionEficacia.Name = "Tx_VerificacionEficacia"
        Me.Tx_VerificacionEficacia.Size = New System.Drawing.Size(485, 40)
        Me.Tx_VerificacionEficacia.TabIndex = 1
        '
        'Lb_TextoVerificacionEficacia
        '
        Me.Lb_TextoVerificacionEficacia.AutoSize = True
        Me.Lb_TextoVerificacionEficacia.Location = New System.Drawing.Point(3, 9)
        Me.Lb_TextoVerificacionEficacia.Name = "Lb_TextoVerificacionEficacia"
        Me.Lb_TextoVerificacionEficacia.Size = New System.Drawing.Size(131, 13)
        Me.Lb_TextoVerificacionEficacia.TabIndex = 0
        Me.Lb_TextoVerificacionEficacia.Text = "Verificación de la eficacia:"
        '
        'Pn_DatosNC
        '
        Me.Pn_DatosNC.Controls.Add(Me.Tx_OrdenTrabajo)
        Me.Pn_DatosNC.Controls.Add(Me.Bt_AgregarAcciones)
        Me.Pn_DatosNC.Controls.Add(Me.Dgv_Acciones)
        Me.Pn_DatosNC.Controls.Add(Me.Gb_AnalisisCausas)
        Me.Pn_DatosNC.Controls.Add(Me.Tx_RepProc)
        Me.Pn_DatosNC.Controls.Add(Me.Tx_Detector)
        Me.Pn_DatosNC.Controls.Add(Me.Tx_Contrato)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoOT)
        Me.Pn_DatosNC.Controls.Add(Me.Tx_Reaccion)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoReaccion)
        Me.Pn_DatosNC.Controls.Add(Me.Tx_Descripcion)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoDescripcion)
        Me.Pn_DatosNC.Controls.Add(Me.Tx_Fuente)
        Me.Pn_DatosNC.Controls.Add(Me.Tx_Proceso)
        Me.Pn_DatosNC.Controls.Add(Me.Dtp_Fecha)
        Me.Pn_DatosNC.Controls.Add(Me.Tx_NumeroAuditoria)
        Me.Pn_DatosNC.Controls.Add(Me.Tx_NumeroReporte)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoRepProc)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoDetector)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoNumeroAuditoria)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoNumeroReporte)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoFuente)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoProceso)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoContrato)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoFecha)
        Me.Pn_DatosNC.Controls.Add(Me.Cb_Tipo)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoTipo)
        Me.Pn_DatosNC.Controls.Add(Me.Cb_Sistema)
        Me.Pn_DatosNC.Controls.Add(Me.Lb_TextoSistema)
        Me.Pn_DatosNC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_DatosNC.Location = New System.Drawing.Point(0, 0)
        Me.Pn_DatosNC.Name = "Pn_DatosNC"
        Me.Pn_DatosNC.Size = New System.Drawing.Size(634, 473)
        Me.Pn_DatosNC.TabIndex = 0
        '
        'Bt_AgregarAcciones
        '
        Me.Bt_AgregarAcciones.AutoSize = True
        Me.Bt_AgregarAcciones.Location = New System.Drawing.Point(12, 285)
        Me.Bt_AgregarAcciones.Name = "Bt_AgregarAcciones"
        Me.Bt_AgregarAcciones.Size = New System.Drawing.Size(101, 23)
        Me.Bt_AgregarAcciones.TabIndex = 30
        Me.Bt_AgregarAcciones.Text = "Agregar Acciones"
        Me.Bt_AgregarAcciones.UseVisualStyleBackColor = True
        '
        'Dgv_Acciones
        '
        Me.Dgv_Acciones.AllowUserToAddRows = False
        Me.Dgv_Acciones.AllowUserToDeleteRows = False
        Me.Dgv_Acciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Acciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Acciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Acciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_IdNoConformidad, Me.Col_Item, Me.Col_Acciones, Me.Col_Responsable, Me.Col_Aprueba, Me.Col_FechaPropuesta, Me.Col_Seguimiento, Me.Col_FechaRegistro, Me.Col_IdUsuarioRegistra, Me.Col_UsuarioRegistra, Me.Col_FechaModificacion, Me.Col_IdUsuarioModifica, Me.Col_UsuarioModifica})
        Me.Dgv_Acciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Dgv_Acciones.Location = New System.Drawing.Point(0, 313)
        Me.Dgv_Acciones.Name = "Dgv_Acciones"
        Me.Dgv_Acciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Acciones.Size = New System.Drawing.Size(634, 160)
        Me.Dgv_Acciones.TabIndex = 31
        '
        'Col_IdNoConformidad
        '
        Me.Col_IdNoConformidad.DataPropertyName = "IDNOCONFORMIDAD"
        Me.Col_IdNoConformidad.HeaderText = "IDNOCONFORMIDAD"
        Me.Col_IdNoConformidad.Name = "Col_IdNoConformidad"
        Me.Col_IdNoConformidad.ReadOnly = True
        Me.Col_IdNoConformidad.Visible = False
        '
        'Col_Item
        '
        Me.Col_Item.DataPropertyName = "ITEM"
        Me.Col_Item.HeaderText = "Ítem"
        Me.Col_Item.Name = "Col_Item"
        Me.Col_Item.ReadOnly = True
        Me.Col_Item.ToolTipText = "Orden en el listado de análisis de causas"
        Me.Col_Item.Visible = False
        '
        'Col_Acciones
        '
        Me.Col_Acciones.DataPropertyName = "ACCIONES"
        Me.Col_Acciones.HeaderText = "Acciones"
        Me.Col_Acciones.MaxInputLength = 200
        Me.Col_Acciones.Name = "Col_Acciones"
        Me.Col_Acciones.ToolTipText = "Acciones"
        '
        'Col_Responsable
        '
        Me.Col_Responsable.DataPropertyName = "RESPONSABLE"
        Me.Col_Responsable.HeaderText = "Responsable"
        Me.Col_Responsable.MaxInputLength = 100
        Me.Col_Responsable.Name = "Col_Responsable"
        Me.Col_Responsable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_Responsable.ToolTipText = "Responsable"
        '
        'Col_Aprueba
        '
        Me.Col_Aprueba.DataPropertyName = "APRUEBA"
        Me.Col_Aprueba.HeaderText = "Aprobado por"
        Me.Col_Aprueba.MaxInputLength = 100
        Me.Col_Aprueba.Name = "Col_Aprueba"
        Me.Col_Aprueba.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_Aprueba.ToolTipText = "Nombre de quien Aprueba"
        '
        'Col_FechaPropuesta
        '
        Me.Col_FechaPropuesta.DataPropertyName = "FECHA"
        Me.Col_FechaPropuesta.HeaderText = "Fecha"
        Me.Col_FechaPropuesta.Name = "Col_FechaPropuesta"
        Me.Col_FechaPropuesta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_FechaPropuesta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Col_FechaPropuesta.ToolTipText = "Fecha propuesta"
        '
        'Col_Seguimiento
        '
        Me.Col_Seguimiento.DataPropertyName = "SEGUIMIENTO"
        Me.Col_Seguimiento.HeaderText = "Seguimiento"
        Me.Col_Seguimiento.MaxInputLength = 200
        Me.Col_Seguimiento.Name = "Col_Seguimiento"
        Me.Col_Seguimiento.ToolTipText = "Seguimiento"
        '
        'Col_FechaRegistro
        '
        Me.Col_FechaRegistro.DataPropertyName = "FECHAREGISTRO"
        Me.Col_FechaRegistro.HeaderText = "FECHAREGISTRO"
        Me.Col_FechaRegistro.Name = "Col_FechaRegistro"
        Me.Col_FechaRegistro.ReadOnly = True
        Me.Col_FechaRegistro.Visible = False
        '
        'Col_IdUsuarioRegistra
        '
        Me.Col_IdUsuarioRegistra.DataPropertyName = "IDUSUARIOREGISTRA"
        Me.Col_IdUsuarioRegistra.HeaderText = "IDUSUARIOREGISTRA"
        Me.Col_IdUsuarioRegistra.Name = "Col_IdUsuarioRegistra"
        Me.Col_IdUsuarioRegistra.ReadOnly = True
        Me.Col_IdUsuarioRegistra.Visible = False
        '
        'Col_UsuarioRegistra
        '
        Me.Col_UsuarioRegistra.DataPropertyName = "USUARIOREGISTRA"
        Me.Col_UsuarioRegistra.HeaderText = "USUARIOREGISTRA"
        Me.Col_UsuarioRegistra.Name = "Col_UsuarioRegistra"
        Me.Col_UsuarioRegistra.ReadOnly = True
        Me.Col_UsuarioRegistra.Visible = False
        '
        'Col_FechaModificacion
        '
        Me.Col_FechaModificacion.DataPropertyName = "FECHAMODIFICACION"
        Me.Col_FechaModificacion.HeaderText = "FECHAMODIFICACION"
        Me.Col_FechaModificacion.Name = "Col_FechaModificacion"
        Me.Col_FechaModificacion.Visible = False
        '
        'Col_IdUsuarioModifica
        '
        Me.Col_IdUsuarioModifica.DataPropertyName = "IDUSUARIOMODIFICA"
        Me.Col_IdUsuarioModifica.HeaderText = "IDUSUARIOMODIFICA"
        Me.Col_IdUsuarioModifica.Name = "Col_IdUsuarioModifica"
        Me.Col_IdUsuarioModifica.Visible = False
        '
        'Col_UsuarioModifica
        '
        Me.Col_UsuarioModifica.DataPropertyName = "USUARIOMODIFICA"
        Me.Col_UsuarioModifica.HeaderText = "USUARIOMODIFICA"
        Me.Col_UsuarioModifica.Name = "Col_UsuarioModifica"
        Me.Col_UsuarioModifica.ReadOnly = True
        Me.Col_UsuarioModifica.Visible = False
        '
        'Gb_AnalisisCausas
        '
        Me.Gb_AnalisisCausas.Controls.Add(Me.Bt_QuitarAnexoAC)
        Me.Gb_AnalisisCausas.Controls.Add(Me.Bt_VerAnexoAC)
        Me.Gb_AnalisisCausas.Controls.Add(Me.Lb_TextoAnexoAC)
        Me.Gb_AnalisisCausas.Controls.Add(Me.Bt_CargarAnexoAC)
        Me.Gb_AnalisisCausas.Controls.Add(Me.Tx_AnexoAC)
        Me.Gb_AnalisisCausas.Controls.Add(Me.Ck_ExistenNC)
        Me.Gb_AnalisisCausas.Location = New System.Drawing.Point(4, 234)
        Me.Gb_AnalisisCausas.Name = "Gb_AnalisisCausas"
        Me.Gb_AnalisisCausas.Size = New System.Drawing.Size(626, 45)
        Me.Gb_AnalisisCausas.TabIndex = 29
        Me.Gb_AnalisisCausas.TabStop = False
        Me.Gb_AnalisisCausas.Text = "Análisis de Causas"
        '
        'Bt_QuitarAnexoAC
        '
        Me.Bt_QuitarAnexoAC.Enabled = False
        Me.Bt_QuitarAnexoAC.Location = New System.Drawing.Point(245, 16)
        Me.Bt_QuitarAnexoAC.Name = "Bt_QuitarAnexoAC"
        Me.Bt_QuitarAnexoAC.Size = New System.Drawing.Size(24, 23)
        Me.Bt_QuitarAnexoAC.TabIndex = 4
        Me.Bt_QuitarAnexoAC.Text = "❌"
        Me.Tt_NoConformidad.SetToolTip(Me.Bt_QuitarAnexoAC, "Quitar archivo")
        Me.Bt_QuitarAnexoAC.UseVisualStyleBackColor = True
        '
        'Bt_VerAnexoAC
        '
        Me.Bt_VerAnexoAC.Enabled = False
        Me.Bt_VerAnexoAC.Location = New System.Drawing.Point(220, 16)
        Me.Bt_VerAnexoAC.Name = "Bt_VerAnexoAC"
        Me.Bt_VerAnexoAC.Size = New System.Drawing.Size(24, 23)
        Me.Bt_VerAnexoAC.TabIndex = 3
        Me.Bt_VerAnexoAC.Text = "👁"
        Me.Tt_NoConformidad.SetToolTip(Me.Bt_VerAnexoAC, "Ver archivo")
        Me.Bt_VerAnexoAC.UseVisualStyleBackColor = True
        '
        'Lb_TextoAnexoAC
        '
        Me.Lb_TextoAnexoAC.AutoSize = True
        Me.Lb_TextoAnexoAC.Location = New System.Drawing.Point(25, 20)
        Me.Lb_TextoAnexoAC.Name = "Lb_TextoAnexoAC"
        Me.Lb_TextoAnexoAC.Size = New System.Drawing.Size(40, 13)
        Me.Lb_TextoAnexoAC.TabIndex = 0
        Me.Lb_TextoAnexoAC.Text = "Anexo:"
        '
        'Bt_CargarAnexoAC
        '
        Me.Bt_CargarAnexoAC.Location = New System.Drawing.Point(195, 16)
        Me.Bt_CargarAnexoAC.Name = "Bt_CargarAnexoAC"
        Me.Bt_CargarAnexoAC.Size = New System.Drawing.Size(24, 23)
        Me.Bt_CargarAnexoAC.TabIndex = 2
        Me.Bt_CargarAnexoAC.Text = "..."
        Me.Tt_NoConformidad.SetToolTip(Me.Bt_CargarAnexoAC, "Cargar archivo")
        Me.Bt_CargarAnexoAC.UseVisualStyleBackColor = True
        '
        'Tx_AnexoAC
        '
        Me.Tx_AnexoAC.Enabled = False
        Me.Tx_AnexoAC.Location = New System.Drawing.Point(68, 17)
        Me.Tx_AnexoAC.Name = "Tx_AnexoAC"
        Me.Tx_AnexoAC.ReadOnly = True
        Me.Tx_AnexoAC.Size = New System.Drawing.Size(125, 20)
        Me.Tx_AnexoAC.TabIndex = 1
        Me.Tt_NoConformidad.SetToolTip(Me.Tx_AnexoAC, "Nombre del archivo")
        '
        'Ck_ExistenNC
        '
        Me.Ck_ExistenNC.AutoSize = True
        Me.Ck_ExistenNC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_ExistenNC.Checked = True
        Me.Ck_ExistenNC.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_ExistenNC.Location = New System.Drawing.Point(323, 19)
        Me.Ck_ExistenNC.Name = "Ck_ExistenNC"
        Me.Ck_ExistenNC.Size = New System.Drawing.Size(296, 17)
        Me.Ck_ExistenNC.TabIndex = 5
        Me.Ck_ExistenNC.Text = "Existen No Conformidades similares o que puedan ocurrir:"
        Me.Ck_ExistenNC.ThreeState = True
        Me.Ck_ExistenNC.UseVisualStyleBackColor = True
        '
        'Tx_RepProc
        '
        Me.Tx_RepProc.Location = New System.Drawing.Point(422, 116)
        Me.Tx_RepProc.MaxLength = 100
        Me.Tx_RepProc.Name = "Tx_RepProc"
        Me.Tx_RepProc.Size = New System.Drawing.Size(200, 20)
        Me.Tx_RepProc.TabIndex = 24
        Me.Tt_NoConformidad.SetToolTip(Me.Tx_RepProc, "Representante del proceso")
        '
        'Tx_Detector
        '
        Me.Tx_Detector.Location = New System.Drawing.Point(422, 90)
        Me.Tx_Detector.MaxLength = 100
        Me.Tx_Detector.Name = "Tx_Detector"
        Me.Tx_Detector.Size = New System.Drawing.Size(200, 20)
        Me.Tx_Detector.TabIndex = 20
        '
        'Tx_Contrato
        '
        Me.Tx_Contrato.Location = New System.Drawing.Point(72, 64)
        Me.Tx_Contrato.MaxLength = 50
        Me.Tx_Contrato.Name = "Tx_Contrato"
        Me.Tx_Contrato.Size = New System.Drawing.Size(200, 20)
        Me.Tx_Contrato.TabIndex = 14
        '
        'Lb_TextoOT
        '
        Me.Lb_TextoOT.AutoSize = True
        Me.Lb_TextoOT.Location = New System.Drawing.Point(44, 41)
        Me.Lb_TextoOT.Name = "Lb_TextoOT"
        Me.Lb_TextoOT.Size = New System.Drawing.Size(25, 13)
        Me.Lb_TextoOT.TabIndex = 6
        Me.Lb_TextoOT.Text = "OT:"
        '
        'Tx_Reaccion
        '
        Me.Tx_Reaccion.Location = New System.Drawing.Point(72, 188)
        Me.Tx_Reaccion.MaxLength = 300
        Me.Tx_Reaccion.Multiline = True
        Me.Tx_Reaccion.Name = "Tx_Reaccion"
        Me.Tx_Reaccion.Size = New System.Drawing.Size(550, 40)
        Me.Tx_Reaccion.TabIndex = 28
        '
        'Lb_TextoReaccion
        '
        Me.Lb_TextoReaccion.AutoSize = True
        Me.Lb_TextoReaccion.Location = New System.Drawing.Point(13, 191)
        Me.Lb_TextoReaccion.Name = "Lb_TextoReaccion"
        Me.Lb_TextoReaccion.Size = New System.Drawing.Size(56, 13)
        Me.Lb_TextoReaccion.TabIndex = 27
        Me.Lb_TextoReaccion.Text = "Reacción:"
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Location = New System.Drawing.Point(72, 142)
        Me.Tx_Descripcion.MaxLength = 300
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(550, 40)
        Me.Tx_Descripcion.TabIndex = 26
        '
        'Lb_TextoDescripcion
        '
        Me.Lb_TextoDescripcion.AutoSize = True
        Me.Lb_TextoDescripcion.Location = New System.Drawing.Point(3, 145)
        Me.Lb_TextoDescripcion.Name = "Lb_TextoDescripcion"
        Me.Lb_TextoDescripcion.Size = New System.Drawing.Size(66, 13)
        Me.Lb_TextoDescripcion.TabIndex = 25
        Me.Lb_TextoDescripcion.Text = "Descripción:"
        '
        'Tx_Fuente
        '
        Me.Tx_Fuente.Location = New System.Drawing.Point(72, 116)
        Me.Tx_Fuente.MaxLength = 100
        Me.Tx_Fuente.Name = "Tx_Fuente"
        Me.Tx_Fuente.Size = New System.Drawing.Size(200, 20)
        Me.Tx_Fuente.TabIndex = 22
        '
        'Tx_Proceso
        '
        Me.Tx_Proceso.Location = New System.Drawing.Point(72, 90)
        Me.Tx_Proceso.MaxLength = 100
        Me.Tx_Proceso.Name = "Tx_Proceso"
        Me.Tx_Proceso.Size = New System.Drawing.Size(200, 20)
        Me.Tx_Proceso.TabIndex = 18
        '
        'Dtp_Fecha
        '
        Me.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha.Location = New System.Drawing.Point(502, 11)
        Me.Dtp_Fecha.Name = "Dtp_Fecha"
        Me.Dtp_Fecha.ShowCheckBox = True
        Me.Dtp_Fecha.Size = New System.Drawing.Size(120, 20)
        Me.Dtp_Fecha.TabIndex = 5
        Me.Tt_NoConformidad.SetToolTip(Me.Dtp_Fecha, "Fecha del reporte")
        '
        'Tx_NumeroAuditoria
        '
        Me.Tx_NumeroAuditoria.Location = New System.Drawing.Point(422, 64)
        Me.Tx_NumeroAuditoria.MaxLength = 50
        Me.Tx_NumeroAuditoria.Name = "Tx_NumeroAuditoria"
        Me.Tx_NumeroAuditoria.Size = New System.Drawing.Size(200, 20)
        Me.Tx_NumeroAuditoria.TabIndex = 16
        Me.Tt_NoConformidad.SetToolTip(Me.Tx_NumeroAuditoria, "Número de auditoría")
        '
        'Tx_NumeroReporte
        '
        Me.Tx_NumeroReporte.Location = New System.Drawing.Point(422, 38)
        Me.Tx_NumeroReporte.MaxLength = 50
        Me.Tx_NumeroReporte.Name = "Tx_NumeroReporte"
        Me.Tx_NumeroReporte.Size = New System.Drawing.Size(200, 20)
        Me.Tx_NumeroReporte.TabIndex = 12
        Me.Tt_NoConformidad.SetToolTip(Me.Tx_NumeroReporte, "Número de reporte")
        '
        'Lb_TextoRepProc
        '
        Me.Lb_TextoRepProc.AutoSize = True
        Me.Lb_TextoRepProc.Location = New System.Drawing.Point(342, 119)
        Me.Lb_TextoRepProc.Name = "Lb_TextoRepProc"
        Me.Lb_TextoRepProc.Size = New System.Drawing.Size(77, 13)
        Me.Lb_TextoRepProc.TabIndex = 23
        Me.Lb_TextoRepProc.Text = "Rep. del proc.:"
        '
        'Lb_TextoDetector
        '
        Me.Lb_TextoDetector.AutoSize = True
        Me.Lb_TextoDetector.Location = New System.Drawing.Point(368, 93)
        Me.Lb_TextoDetector.Name = "Lb_TextoDetector"
        Me.Lb_TextoDetector.Size = New System.Drawing.Size(51, 13)
        Me.Lb_TextoDetector.TabIndex = 19
        Me.Lb_TextoDetector.Text = "Detector:"
        '
        'Lb_TextoNumeroAuditoria
        '
        Me.Lb_TextoNumeroAuditoria.AutoSize = True
        Me.Lb_TextoNumeroAuditoria.Location = New System.Drawing.Point(346, 67)
        Me.Lb_TextoNumeroAuditoria.Name = "Lb_TextoNumeroAuditoria"
        Me.Lb_TextoNumeroAuditoria.Size = New System.Drawing.Size(73, 13)
        Me.Lb_TextoNumeroAuditoria.TabIndex = 15
        Me.Lb_TextoNumeroAuditoria.Text = "Auditoría No.:"
        '
        'Lb_TextoNumeroReporte
        '
        Me.Lb_TextoNumeroReporte.AutoSize = True
        Me.Lb_TextoNumeroReporte.Location = New System.Drawing.Point(351, 41)
        Me.Lb_TextoNumeroReporte.Name = "Lb_TextoNumeroReporte"
        Me.Lb_TextoNumeroReporte.Size = New System.Drawing.Size(68, 13)
        Me.Lb_TextoNumeroReporte.TabIndex = 11
        Me.Lb_TextoNumeroReporte.Text = "Reporte No.:"
        '
        'Lb_TextoFuente
        '
        Me.Lb_TextoFuente.AutoSize = True
        Me.Lb_TextoFuente.Location = New System.Drawing.Point(26, 119)
        Me.Lb_TextoFuente.Name = "Lb_TextoFuente"
        Me.Lb_TextoFuente.Size = New System.Drawing.Size(43, 13)
        Me.Lb_TextoFuente.TabIndex = 21
        Me.Lb_TextoFuente.Text = "Fuente:"
        '
        'Lb_TextoProceso
        '
        Me.Lb_TextoProceso.AutoSize = True
        Me.Lb_TextoProceso.Location = New System.Drawing.Point(20, 93)
        Me.Lb_TextoProceso.Name = "Lb_TextoProceso"
        Me.Lb_TextoProceso.Size = New System.Drawing.Size(49, 13)
        Me.Lb_TextoProceso.TabIndex = 17
        Me.Lb_TextoProceso.Text = "Proceso:"
        '
        'Lb_TextoContrato
        '
        Me.Lb_TextoContrato.AutoSize = True
        Me.Lb_TextoContrato.Location = New System.Drawing.Point(19, 67)
        Me.Lb_TextoContrato.Name = "Lb_TextoContrato"
        Me.Lb_TextoContrato.Size = New System.Drawing.Size(50, 13)
        Me.Lb_TextoContrato.TabIndex = 13
        Me.Lb_TextoContrato.Text = "Contrato:"
        '
        'Lb_TextoFecha
        '
        Me.Lb_TextoFecha.AutoSize = True
        Me.Lb_TextoFecha.Location = New System.Drawing.Point(459, 14)
        Me.Lb_TextoFecha.Name = "Lb_TextoFecha"
        Me.Lb_TextoFecha.Size = New System.Drawing.Size(40, 13)
        Me.Lb_TextoFecha.TabIndex = 4
        Me.Lb_TextoFecha.Text = "Fecha:"
        '
        'Cb_Tipo
        '
        Me.Cb_Tipo.DisplayMember = "NOMBRETIPO"
        Me.Cb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Tipo.FormattingEnabled = True
        Me.Cb_Tipo.Items.AddRange(New Object() {"NO CONFORMIDAD", "SALIDA NO CONFORME"})
        Me.Cb_Tipo.Location = New System.Drawing.Point(312, 11)
        Me.Cb_Tipo.Name = "Cb_Tipo"
        Me.Cb_Tipo.Size = New System.Drawing.Size(140, 21)
        Me.Cb_Tipo.TabIndex = 3
        Me.Tt_NoConformidad.SetToolTip(Me.Cb_Tipo, "Tipo de No Conformidad")
        Me.Cb_Tipo.ValueMember = "CODIGOTIPO"
        '
        'Lb_TextoTipo
        '
        Me.Lb_TextoTipo.AutoSize = True
        Me.Lb_TextoTipo.Location = New System.Drawing.Point(278, 14)
        Me.Lb_TextoTipo.Name = "Lb_TextoTipo"
        Me.Lb_TextoTipo.Size = New System.Drawing.Size(31, 13)
        Me.Lb_TextoTipo.TabIndex = 2
        Me.Lb_TextoTipo.Text = "Tipo:"
        '
        'Cb_Sistema
        '
        Me.Cb_Sistema.DisplayMember = "NOMBRESISTEMA"
        Me.Cb_Sistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Sistema.FormattingEnabled = True
        Me.Cb_Sistema.Items.AddRange(New Object() {"SGC", "SGA", "SST", "Otras"})
        Me.Cb_Sistema.Location = New System.Drawing.Point(72, 11)
        Me.Cb_Sistema.Name = "Cb_Sistema"
        Me.Cb_Sistema.Size = New System.Drawing.Size(200, 21)
        Me.Cb_Sistema.TabIndex = 1
        Me.Cb_Sistema.ValueMember = "CODIGOSISTEMA"
        '
        'Lb_TextoSistema
        '
        Me.Lb_TextoSistema.AutoSize = True
        Me.Lb_TextoSistema.Location = New System.Drawing.Point(22, 14)
        Me.Lb_TextoSistema.Name = "Lb_TextoSistema"
        Me.Lb_TextoSistema.Size = New System.Drawing.Size(47, 13)
        Me.Lb_TextoSistema.TabIndex = 0
        Me.Lb_TextoSistema.Text = "Sistema:"
        '
        'Ofd_AnexoAnalisisCausas
        '
        Me.Ofd_AnexoAnalisisCausas.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDNOCONFORMIDAD"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDNOCONFORMIDAD"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ITEM"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Ítem"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.ToolTipText = "Orden en el listado de análisis de causas"
        Me.DataGridViewTextBoxColumn2.Width = 109
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ACCIONES"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Acciones"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 200
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ToolTipText = "Acciones"
        Me.DataGridViewTextBoxColumn3.Width = 109
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "RESPONSABLE"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Responsable"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 100
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.ToolTipText = "Responsable"
        Me.DataGridViewTextBoxColumn4.Width = 109
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "APRUEBA"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Aprobado por"
        Me.DataGridViewTextBoxColumn5.MaxInputLength = 100
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.ToolTipText = "Nombre de quien Aprueba"
        Me.DataGridViewTextBoxColumn5.Width = 108
        '
        'CalendarColumn1
        '
        Me.CalendarColumn1.DataPropertyName = "FECHA"
        Me.CalendarColumn1.HeaderText = "Fecha"
        Me.CalendarColumn1.Name = "CalendarColumn1"
        Me.CalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CalendarColumn1.ToolTipText = "Fecha propuesta"
        Me.CalendarColumn1.Width = 109
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "SEGUIMIENTO"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Seguimiento"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 200
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ToolTipText = "Seguimiento"
        Me.DataGridViewTextBoxColumn6.Width = 109
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "FECHAREGISTRO"
        Me.DataGridViewTextBoxColumn7.HeaderText = "FECHAREGISTRO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "IDUSUARIOREGISTRA"
        Me.DataGridViewTextBoxColumn8.HeaderText = "IDUSUARIOREGISTRA"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "FECHAMODIFICACION"
        Me.DataGridViewTextBoxColumn9.HeaderText = "FECHAMODIFICACION"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "IDUSUARIOMODIFICA"
        Me.DataGridViewTextBoxColumn10.HeaderText = "IDUSUARIOMODIFICA"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'Ofd_AnexoOrdenTrabajo
        '
        Me.Ofd_AnexoOrdenTrabajo.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        '
        'Tx_OrdenTrabajo
        '
        Me.Tx_OrdenTrabajo.Location = New System.Drawing.Point(72, 38)
        Me.Tx_OrdenTrabajo.MaxLength = 100
        Me.Tx_OrdenTrabajo.Name = "Tx_OrdenTrabajo"
        Me.Tx_OrdenTrabajo.Size = New System.Drawing.Size(200, 20)
        Me.Tx_OrdenTrabajo.TabIndex = 7
        Me.Tt_NoConformidad.SetToolTip(Me.Tx_OrdenTrabajo, "Orden de trabajo")
        '
        'Fr_NoConformidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(634, 581)
        Me.Controls.Add(Me.Pn_DatosNC)
        Me.Controls.Add(Me.Pn_Cierre)
        Me.Controls.Add(Me.Flp_Botones)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_NoConformidad"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionar No Conformidad"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Cierre.ResumeLayout(False)
        Me.Pn_Cierre.PerformLayout()
        Me.Pn_DatosNC.ResumeLayout(False)
        Me.Pn_DatosNC.PerformLayout()
        CType(Me.Dgv_Acciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gb_AnalisisCausas.ResumeLayout(False)
        Me.Gb_AnalisisCausas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Pn_Cierre As System.Windows.Forms.Panel
    Friend WithEvents Dtp_FechaCierre As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_TextoFechaCierre As System.Windows.Forms.Label
    Friend WithEvents Tx_VerificacionEficacia As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoVerificacionEficacia As System.Windows.Forms.Label
    Friend WithEvents Pn_DatosNC As System.Windows.Forms.Panel
    Friend WithEvents Lb_TextoOT As System.Windows.Forms.Label
    Friend WithEvents Ck_ExistenNC As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_Reaccion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoReaccion As System.Windows.Forms.Label
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoDescripcion As System.Windows.Forms.Label
    Friend WithEvents Tx_Fuente As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Proceso As System.Windows.Forms.TextBox
    Friend WithEvents Dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tx_NumeroAuditoria As System.Windows.Forms.TextBox
    Friend WithEvents Tx_NumeroReporte As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoRepProc As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoDetector As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoNumeroAuditoria As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoNumeroReporte As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoFuente As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoProceso As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoContrato As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoFecha As System.Windows.Forms.Label
    Friend WithEvents Cb_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoTipo As System.Windows.Forms.Label
    Friend WithEvents Cb_Sistema As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoSistema As System.Windows.Forms.Label
    Friend WithEvents Tx_Contrato As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Detector As System.Windows.Forms.TextBox
    Friend WithEvents Tx_RepProc As System.Windows.Forms.TextBox
    Friend WithEvents Gb_AnalisisCausas As System.Windows.Forms.GroupBox
    Friend WithEvents Lb_TextoAnexoAC As System.Windows.Forms.Label
    Friend WithEvents Bt_CargarAnexoAC As System.Windows.Forms.Button
    Friend WithEvents Tx_AnexoAC As System.Windows.Forms.TextBox
    Friend WithEvents Ofd_AnexoAnalisisCausas As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Bt_VerAnexoAC As System.Windows.Forms.Button
    Friend WithEvents Bt_QuitarAnexoAC As System.Windows.Forms.Button
    Friend WithEvents Tt_NoConformidad As System.Windows.Forms.ToolTip
    Friend WithEvents Dgv_Acciones As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalendarColumn1 As FormulariosOrdenesTrabajo.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdNoConformidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Acciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Responsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Aprueba As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaPropuesta As FormulariosOrdenesTrabajo.CalendarColumn
    Friend WithEvents Col_Seguimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdUsuarioRegistra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_UsuarioRegistra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaModificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdUsuarioModifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_UsuarioModifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bt_AgregarAcciones As System.Windows.Forms.Button
    Friend WithEvents Ofd_AnexoOrdenTrabajo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Tx_OrdenTrabajo As System.Windows.Forms.TextBox
End Class
