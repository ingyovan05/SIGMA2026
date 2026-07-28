<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ImprimirStickers
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
        Me.Bt_ImprimirContinua = New System.Windows.Forms.Button()
        Me.Dgv_Consecutivos = New System.Windows.Forms.DataGridView()
        Me.Col_IdSticker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Hoja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoL_NumeroSticker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdDependencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdUsuarioRegistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_TituloConsecutivos = New System.Windows.Forms.Panel()
        Me.Lb_TituloConsecutivos = New System.Windows.Forms.Label()
        Me.Lb_TextoGrupo = New System.Windows.Forms.Label()
        Me.Cb_Grupo = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoHojaDesde = New System.Windows.Forms.Label()
        Me.Nud_HojaDesde = New System.Windows.Forms.NumericUpDown()
        Me.Lb_HojaHasta = New System.Windows.Forms.Label()
        Me.Nud_HojaHasta = New System.Windows.Forms.NumericUpDown()
        Me.Lb_TextoFechaRegistro = New System.Windows.Forms.Label()
        Me.Lb_FechaRegistro = New System.Windows.Forms.Label()
        Me.Lb_TextoUsuarioRegistra = New System.Windows.Forms.Label()
        Me.Lb_UsuarioRegistra = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lb_TextoBase = New System.Windows.Forms.Label()
        Me.Cb_Base = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoDependencia = New System.Windows.Forms.Label()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Pn_Controles = New System.Windows.Forms.Panel()
        Me.Lb_TextoAdicionarSticker = New System.Windows.Forms.Label()
        Me.Tx_AdicionarSticker = New System.Windows.Forms.TextBox()
        Me.Bt_AdicionarSticker = New System.Windows.Forms.Button()
        Me.Gb_Auditoria = New System.Windows.Forms.GroupBox()
        Me.Flp_Auditoria = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_GenerarStickers = New System.Windows.Forms.Button()
        Me.Tlp_BarraEstado = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_Estado = New System.Windows.Forms.FlowLayoutPanel()
        Me.Flp_Botones.SuspendLayout()
        CType(Me.Dgv_Consecutivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_TituloConsecutivos.SuspendLayout()
        CType(Me.Nud_HojaDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_HojaHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Controles.SuspendLayout()
        Me.Gb_Auditoria.SuspendLayout()
        Me.Flp_Auditoria.SuspendLayout()
        Me.Tlp_BarraEstado.SuspendLayout()
        Me.Flp_Estado.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Controls.Add(Me.Bt_ImprimirContinua)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(412, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(412, 30)
        Me.Flp_Botones.TabIndex = 3
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.AutoSize = True
        Me.Bt_Cancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_Cancelar.Location = New System.Drawing.Point(350, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(59, 23)
        Me.Bt_Cancelar.TabIndex = 2
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.AutoSize = True
        Me.Bt_Aceptar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_Aceptar.Enabled = False
        Me.Bt_Aceptar.Location = New System.Drawing.Point(292, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(52, 23)
        Me.Bt_Aceptar.TabIndex = 1
        Me.Bt_Aceptar.Text = "Imprimir"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Bt_ImprimirContinua
        '
        Me.Bt_ImprimirContinua.AutoSize = True
        Me.Bt_ImprimirContinua.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_ImprimirContinua.Location = New System.Drawing.Point(180, 3)
        Me.Bt_ImprimirContinua.Name = "Bt_ImprimirContinua"
        Me.Bt_ImprimirContinua.Size = New System.Drawing.Size(106, 23)
        Me.Bt_ImprimirContinua.TabIndex = 0
        Me.Bt_ImprimirContinua.Tag = "766"
        Me.Bt_ImprimirContinua.Text = "Impresión continua"
        Me.Bt_ImprimirContinua.UseVisualStyleBackColor = True
        '
        'Dgv_Consecutivos
        '
        Me.Dgv_Consecutivos.AllowUserToAddRows = False
        Me.Dgv_Consecutivos.AllowUserToDeleteRows = False
        Me.Dgv_Consecutivos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Consecutivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Consecutivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_IdSticker, Me.Col_Grupo, Me.Col_Hoja, Me.Col_Item, Me.CoL_NumeroSticker, Me.Col_Numero, Me.Col_IdDependencia, Me.Col_FechaRegistro, Me.Col_IdUsuarioRegistra})
        Me.Dgv_Consecutivos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Consecutivos.Location = New System.Drawing.Point(0, 130)
        Me.Dgv_Consecutivos.Name = "Dgv_Consecutivos"
        Me.Dgv_Consecutivos.ReadOnly = True
        Me.Dgv_Consecutivos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Consecutivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Dgv_Consecutivos.Size = New System.Drawing.Size(824, 461)
        Me.Dgv_Consecutivos.TabIndex = 2
        '
        'Col_IdSticker
        '
        Me.Col_IdSticker.DataPropertyName = "IDSTICKER"
        Me.Col_IdSticker.HeaderText = "IDSTICKER"
        Me.Col_IdSticker.Name = "Col_IdSticker"
        Me.Col_IdSticker.ReadOnly = True
        Me.Col_IdSticker.Visible = False
        '
        'Col_Grupo
        '
        Me.Col_Grupo.DataPropertyName = "GRUPO"
        Me.Col_Grupo.HeaderText = "GRUPO"
        Me.Col_Grupo.Name = "Col_Grupo"
        Me.Col_Grupo.ReadOnly = True
        Me.Col_Grupo.Visible = False
        '
        'Col_Hoja
        '
        Me.Col_Hoja.DataPropertyName = "HOJA"
        Me.Col_Hoja.HeaderText = "Hoja"
        Me.Col_Hoja.Name = "Col_Hoja"
        Me.Col_Hoja.ReadOnly = True
        Me.Col_Hoja.Width = 60
        '
        'Col_Item
        '
        Me.Col_Item.DataPropertyName = "ITEM"
        Me.Col_Item.HeaderText = "Ítem"
        Me.Col_Item.Name = "Col_Item"
        Me.Col_Item.ReadOnly = True
        Me.Col_Item.Width = 60
        '
        'CoL_NumeroSticker
        '
        Me.CoL_NumeroSticker.DataPropertyName = "NUMEROSTICKER"
        Me.CoL_NumeroSticker.HeaderText = "NUMEROSTICKER"
        Me.CoL_NumeroSticker.Name = "CoL_NumeroSticker"
        Me.CoL_NumeroSticker.ReadOnly = True
        Me.CoL_NumeroSticker.Visible = False
        '
        'Col_Numero
        '
        Me.Col_Numero.DataPropertyName = "ETIQUETA"
        Me.Col_Numero.HeaderText = "Consecutivo"
        Me.Col_Numero.Name = "Col_Numero"
        Me.Col_Numero.ReadOnly = True
        Me.Col_Numero.Width = 400
        '
        'Col_IdDependencia
        '
        Me.Col_IdDependencia.DataPropertyName = "IDDEPENDENCIA"
        Me.Col_IdDependencia.HeaderText = "IDDEPENDENCIA"
        Me.Col_IdDependencia.Name = "Col_IdDependencia"
        Me.Col_IdDependencia.ReadOnly = True
        Me.Col_IdDependencia.Visible = False
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
        'Pn_TituloConsecutivos
        '
        Me.Pn_TituloConsecutivos.Controls.Add(Me.Lb_TituloConsecutivos)
        Me.Pn_TituloConsecutivos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloConsecutivos.Location = New System.Drawing.Point(0, 110)
        Me.Pn_TituloConsecutivos.Name = "Pn_TituloConsecutivos"
        Me.Pn_TituloConsecutivos.Size = New System.Drawing.Size(824, 20)
        Me.Pn_TituloConsecutivos.TabIndex = 1
        '
        'Lb_TituloConsecutivos
        '
        Me.Lb_TituloConsecutivos.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Lb_TituloConsecutivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_TituloConsecutivos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TituloConsecutivos.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TituloConsecutivos.Name = "Lb_TituloConsecutivos"
        Me.Lb_TituloConsecutivos.Size = New System.Drawing.Size(824, 20)
        Me.Lb_TituloConsecutivos.TabIndex = 0
        Me.Lb_TituloConsecutivos.Text = "CONSECUTIVOS"
        Me.Lb_TituloConsecutivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_TextoGrupo
        '
        Me.Lb_TextoGrupo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_TextoGrupo.AutoSize = True
        Me.Lb_TextoGrupo.Location = New System.Drawing.Point(10, 43)
        Me.Lb_TextoGrupo.Name = "Lb_TextoGrupo"
        Me.Lb_TextoGrupo.Size = New System.Drawing.Size(39, 13)
        Me.Lb_TextoGrupo.TabIndex = 4
        Me.Lb_TextoGrupo.Text = "Grupo:"
        Me.Lb_TextoGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cb_Grupo
        '
        Me.Cb_Grupo.DisplayMember = "GRUPO"
        Me.Cb_Grupo.FormattingEnabled = True
        Me.Cb_Grupo.Location = New System.Drawing.Point(52, 40)
        Me.Cb_Grupo.Name = "Cb_Grupo"
        Me.Cb_Grupo.Size = New System.Drawing.Size(70, 21)
        Me.Cb_Grupo.TabIndex = 5
        Me.Cb_Grupo.ValueMember = "GRUPO"
        '
        'Lb_TextoHojaDesde
        '
        Me.Lb_TextoHojaDesde.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_TextoHojaDesde.AutoSize = True
        Me.Lb_TextoHojaDesde.Location = New System.Drawing.Point(128, 43)
        Me.Lb_TextoHojaDesde.Name = "Lb_TextoHojaDesde"
        Me.Lb_TextoHojaDesde.Size = New System.Drawing.Size(64, 13)
        Me.Lb_TextoHojaDesde.TabIndex = 6
        Me.Lb_TextoHojaDesde.Text = "Hoja desde:"
        Me.Lb_TextoHojaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Nud_HojaDesde
        '
        Me.Nud_HojaDesde.Location = New System.Drawing.Point(195, 40)
        Me.Nud_HojaDesde.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.Nud_HojaDesde.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_HojaDesde.Name = "Nud_HojaDesde"
        Me.Nud_HojaDesde.Size = New System.Drawing.Size(40, 20)
        Me.Nud_HojaDesde.TabIndex = 7
        Me.Nud_HojaDesde.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Lb_HojaHasta
        '
        Me.Lb_HojaHasta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_HojaHasta.AutoSize = True
        Me.Lb_HojaHasta.Location = New System.Drawing.Point(241, 43)
        Me.Lb_HojaHasta.Name = "Lb_HojaHasta"
        Me.Lb_HojaHasta.Size = New System.Drawing.Size(36, 13)
        Me.Lb_HojaHasta.TabIndex = 8
        Me.Lb_HojaHasta.Text = "hasta:"
        Me.Lb_HojaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Nud_HojaHasta
        '
        Me.Nud_HojaHasta.Location = New System.Drawing.Point(280, 40)
        Me.Nud_HojaHasta.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.Nud_HojaHasta.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_HojaHasta.Name = "Nud_HojaHasta"
        Me.Nud_HojaHasta.Size = New System.Drawing.Size(40, 20)
        Me.Nud_HojaHasta.TabIndex = 9
        Me.Nud_HojaHasta.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Lb_TextoFechaRegistro
        '
        Me.Lb_TextoFechaRegistro.AutoSize = True
        Me.Lb_TextoFechaRegistro.Location = New System.Drawing.Point(3, 0)
        Me.Lb_TextoFechaRegistro.Name = "Lb_TextoFechaRegistro"
        Me.Lb_TextoFechaRegistro.Size = New System.Drawing.Size(92, 13)
        Me.Lb_TextoFechaRegistro.TabIndex = 0
        Me.Lb_TextoFechaRegistro.Text = "Fecha de registro:"
        Me.Lb_TextoFechaRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_FechaRegistro
        '
        Me.Lb_FechaRegistro.AutoSize = True
        Me.Lb_FechaRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_FechaRegistro.Location = New System.Drawing.Point(310, 0)
        Me.Lb_FechaRegistro.Name = "Lb_FechaRegistro"
        Me.Lb_FechaRegistro.Size = New System.Drawing.Size(110, 13)
        Me.Lb_FechaRegistro.TabIndex = 3
        Me.Lb_FechaRegistro.Text = "Lb_FechaRegistro"
        Me.Lb_FechaRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_TextoUsuarioRegistra
        '
        Me.Lb_TextoUsuarioRegistra.AutoSize = True
        Me.Lb_TextoUsuarioRegistra.Location = New System.Drawing.Point(225, 0)
        Me.Lb_TextoUsuarioRegistra.Name = "Lb_TextoUsuarioRegistra"
        Me.Lb_TextoUsuarioRegistra.Size = New System.Drawing.Size(79, 13)
        Me.Lb_TextoUsuarioRegistra.TabIndex = 2
        Me.Lb_TextoUsuarioRegistra.Text = "Registrado por:"
        Me.Lb_TextoUsuarioRegistra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_UsuarioRegistra
        '
        Me.Lb_UsuarioRegistra.AutoSize = True
        Me.Lb_UsuarioRegistra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_UsuarioRegistra.Location = New System.Drawing.Point(101, 0)
        Me.Lb_UsuarioRegistra.Name = "Lb_UsuarioRegistra"
        Me.Lb_UsuarioRegistra.Size = New System.Drawing.Size(118, 13)
        Me.Lb_UsuarioRegistra.TabIndex = 1
        Me.Lb_UsuarioRegistra.Text = "Lb_UsuarioRegistra"
        Me.Lb_UsuarioRegistra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 10.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Ítem"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 52
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 90.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Consecutivo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 471
        '
        'Lb_TextoBase
        '
        Me.Lb_TextoBase.AutoSize = True
        Me.Lb_TextoBase.Location = New System.Drawing.Point(15, 13)
        Me.Lb_TextoBase.Name = "Lb_TextoBase"
        Me.Lb_TextoBase.Size = New System.Drawing.Size(34, 13)
        Me.Lb_TextoBase.TabIndex = 0
        Me.Lb_TextoBase.Text = "Base:"
        Me.Lb_TextoBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cb_Base
        '
        Me.Cb_Base.DisplayMember = "BASE"
        Me.Cb_Base.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Base.FormattingEnabled = True
        Me.Cb_Base.Location = New System.Drawing.Point(52, 10)
        Me.Cb_Base.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
        Me.Cb_Base.Name = "Cb_Base"
        Me.Cb_Base.Size = New System.Drawing.Size(268, 21)
        Me.Cb_Base.TabIndex = 1
        Me.Cb_Base.ValueMember = "IDBASESISCONTROL"
        '
        'Lb_TextoDependencia
        '
        Me.Lb_TextoDependencia.AutoSize = True
        Me.Lb_TextoDependencia.Location = New System.Drawing.Point(326, 13)
        Me.Lb_TextoDependencia.Name = "Lb_TextoDependencia"
        Me.Lb_TextoDependencia.Size = New System.Drawing.Size(74, 13)
        Me.Lb_TextoDependencia.TabIndex = 2
        Me.Lb_TextoDependencia.Text = "Dependencia:"
        Me.Lb_TextoDependencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_Dependencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.Location = New System.Drawing.Point(403, 10)
        Me.Cb_Dependencia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(200, 21)
        Me.Cb_Dependencia.TabIndex = 3
        Me.Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
        '
        'Pn_Controles
        '
        Me.Pn_Controles.Controls.Add(Me.Lb_TextoBase)
        Me.Pn_Controles.Controls.Add(Me.Cb_Base)
        Me.Pn_Controles.Controls.Add(Me.Lb_TextoDependencia)
        Me.Pn_Controles.Controls.Add(Me.Cb_Dependencia)
        Me.Pn_Controles.Controls.Add(Me.Lb_TextoGrupo)
        Me.Pn_Controles.Controls.Add(Me.Cb_Grupo)
        Me.Pn_Controles.Controls.Add(Me.Lb_TextoHojaDesde)
        Me.Pn_Controles.Controls.Add(Me.Nud_HojaDesde)
        Me.Pn_Controles.Controls.Add(Me.Lb_HojaHasta)
        Me.Pn_Controles.Controls.Add(Me.Nud_HojaHasta)
        Me.Pn_Controles.Controls.Add(Me.Lb_TextoAdicionarSticker)
        Me.Pn_Controles.Controls.Add(Me.Tx_AdicionarSticker)
        Me.Pn_Controles.Controls.Add(Me.Bt_AdicionarSticker)
        Me.Pn_Controles.Controls.Add(Me.Gb_Auditoria)
        Me.Pn_Controles.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Controles.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Controles.Name = "Pn_Controles"
        Me.Pn_Controles.Size = New System.Drawing.Size(824, 110)
        Me.Pn_Controles.TabIndex = 0
        '
        'Lb_TextoAdicionarSticker
        '
        Me.Lb_TextoAdicionarSticker.AutoSize = True
        Me.Lb_TextoAdicionarSticker.Location = New System.Drawing.Point(383, 43)
        Me.Lb_TextoAdicionarSticker.Name = "Lb_TextoAdicionarSticker"
        Me.Lb_TextoAdicionarSticker.Size = New System.Drawing.Size(90, 13)
        Me.Lb_TextoAdicionarSticker.TabIndex = 10
        Me.Lb_TextoAdicionarSticker.Text = "Adicionar Sticker:"
        Me.Lb_TextoAdicionarSticker.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Tx_AdicionarSticker
        '
        Me.Tx_AdicionarSticker.Location = New System.Drawing.Point(476, 40)
        Me.Tx_AdicionarSticker.Name = "Tx_AdicionarSticker"
        Me.Tx_AdicionarSticker.Size = New System.Drawing.Size(100, 20)
        Me.Tx_AdicionarSticker.TabIndex = 11
        '
        'Bt_AdicionarSticker
        '
        Me.Bt_AdicionarSticker.Location = New System.Drawing.Point(582, 39)
        Me.Bt_AdicionarSticker.Name = "Bt_AdicionarSticker"
        Me.Bt_AdicionarSticker.Size = New System.Drawing.Size(22, 22)
        Me.Bt_AdicionarSticker.TabIndex = 12
        Me.Bt_AdicionarSticker.Text = "+"
        Me.Bt_AdicionarSticker.UseVisualStyleBackColor = True
        '
        'Gb_Auditoria
        '
        Me.Gb_Auditoria.Controls.Add(Me.Flp_Auditoria)
        Me.Gb_Auditoria.Location = New System.Drawing.Point(12, 67)
        Me.Gb_Auditoria.Name = "Gb_Auditoria"
        Me.Gb_Auditoria.Size = New System.Drawing.Size(800, 40)
        Me.Gb_Auditoria.TabIndex = 13
        Me.Gb_Auditoria.TabStop = False
        Me.Gb_Auditoria.Text = "Auditoría"
        '
        'Flp_Auditoria
        '
        Me.Flp_Auditoria.Controls.Add(Me.Lb_TextoFechaRegistro)
        Me.Flp_Auditoria.Controls.Add(Me.Lb_UsuarioRegistra)
        Me.Flp_Auditoria.Controls.Add(Me.Lb_TextoUsuarioRegistra)
        Me.Flp_Auditoria.Controls.Add(Me.Lb_FechaRegistro)
        Me.Flp_Auditoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Auditoria.Location = New System.Drawing.Point(3, 16)
        Me.Flp_Auditoria.Name = "Flp_Auditoria"
        Me.Flp_Auditoria.Size = New System.Drawing.Size(794, 21)
        Me.Flp_Auditoria.TabIndex = 0
        '
        'Bt_GenerarStickers
        '
        Me.Bt_GenerarStickers.AutoSize = True
        Me.Bt_GenerarStickers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_GenerarStickers.Location = New System.Drawing.Point(3, 3)
        Me.Bt_GenerarStickers.Name = "Bt_GenerarStickers"
        Me.Bt_GenerarStickers.Size = New System.Drawing.Size(94, 23)
        Me.Bt_GenerarStickers.TabIndex = 3
        Me.Bt_GenerarStickers.Text = "Generar stickers"
        Me.Bt_GenerarStickers.UseVisualStyleBackColor = True
        '
        'Tlp_BarraEstado
        '
        Me.Tlp_BarraEstado.ColumnCount = 2
        Me.Tlp_BarraEstado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_BarraEstado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_BarraEstado.Controls.Add(Me.Flp_Estado, 0, 0)
        Me.Tlp_BarraEstado.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_BarraEstado.Location = New System.Drawing.Point(0, 591)
        Me.Tlp_BarraEstado.Name = "Tlp_BarraEstado"
        Me.Tlp_BarraEstado.RowCount = 1
        Me.Tlp_BarraEstado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_BarraEstado.Size = New System.Drawing.Size(824, 30)
        Me.Tlp_BarraEstado.TabIndex = 4
        '
        'Flp_Estado
        '
        Me.Flp_Estado.Controls.Add(Me.Bt_GenerarStickers)
        Me.Flp_Estado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Estado.Location = New System.Drawing.Point(0, 0)
        Me.Flp_Estado.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Estado.Name = "Flp_Estado"
        Me.Flp_Estado.Size = New System.Drawing.Size(412, 30)
        Me.Flp_Estado.TabIndex = 0
        '
        'Fr_ImprimirStickers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 621)
        Me.Controls.Add(Me.Dgv_Consecutivos)
        Me.Controls.Add(Me.Pn_TituloConsecutivos)
        Me.Controls.Add(Me.Pn_Controles)
        Me.Controls.Add(Me.Tlp_BarraEstado)
        Me.Name = "Fr_ImprimirStickers"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Imprimir Stickers de Documentos"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Flp_Botones.PerformLayout()
        CType(Me.Dgv_Consecutivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_TituloConsecutivos.ResumeLayout(False)
        CType(Me.Nud_HojaDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_HojaHasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Controles.ResumeLayout(False)
        Me.Pn_Controles.PerformLayout()
        Me.Gb_Auditoria.ResumeLayout(False)
        Me.Flp_Auditoria.ResumeLayout(False)
        Me.Flp_Auditoria.PerformLayout()
        Me.Tlp_BarraEstado.ResumeLayout(False)
        Me.Flp_Estado.ResumeLayout(False)
        Me.Flp_Estado.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Dgv_Consecutivos As System.Windows.Forms.DataGridView
    Friend WithEvents Lb_TextoHojaDesde As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoGrupo As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoUsuarioRegistra As System.Windows.Forms.Label
    Friend WithEvents Lb_UsuarioRegistra As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoFechaRegistro As System.Windows.Forms.Label
    Friend WithEvents Lb_FechaRegistro As System.Windows.Forms.Label
    Friend WithEvents Pn_TituloConsecutivos As System.Windows.Forms.Panel
    Friend WithEvents Lb_TituloConsecutivos As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cb_Grupo As System.Windows.Forms.ComboBox
    Friend WithEvents Nud_HojaDesde As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lb_HojaHasta As System.Windows.Forms.Label
    Friend WithEvents Nud_HojaHasta As System.Windows.Forms.NumericUpDown
    Friend WithEvents Col_IdSticker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Hoja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoL_NumeroSticker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdDependencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdUsuarioRegistra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lb_TextoBase As System.Windows.Forms.Label
    Friend WithEvents Cb_Base As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoDependencia As System.Windows.Forms.Label
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Bt_ImprimirContinua As System.Windows.Forms.Button
    Friend WithEvents Pn_Controles As System.Windows.Forms.Panel
    Friend WithEvents Gb_Auditoria As System.Windows.Forms.GroupBox
    Friend WithEvents Flp_Auditoria As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_AdicionarSticker As System.Windows.Forms.Button
    Friend WithEvents Tx_AdicionarSticker As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoAdicionarSticker As System.Windows.Forms.Label
    Friend WithEvents Bt_GenerarStickers As System.Windows.Forms.Button
    Friend WithEvents Tlp_BarraEstado As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Flp_Estado As System.Windows.Forms.FlowLayoutPanel
End Class
