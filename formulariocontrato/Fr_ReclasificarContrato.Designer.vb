<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ReclasificarContrato
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
        Me.Pn_DatosReclasificacion = New System.Windows.Forms.Panel()
        Me.Lb_TextoGrupo = New System.Windows.Forms.Label()
        Me.Cb_TipoGrupo = New System.Windows.Forms.ComboBox()
        Me.Cb_TipoSalario = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoTipoSalario = New System.Windows.Forms.Label()
        Me.Lb_TextoCategoria = New System.Windows.Forms.Label()
        Me.Cb_Categoria = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoCargo = New System.Windows.Forms.Label()
        Me.Cb_Cargo_Desempeña = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoSalario = New System.Windows.Forms.Label()
        Me.Tx_Salario = New System.Windows.Forms.TextBox()
        Me.GB_Vigencia = New System.Windows.Forms.GroupBox()
        Me.Tlp_FechasVigencia = New System.Windows.Forms.TableLayoutPanel()
        Me.Lb_SalarioAnterior = New System.Windows.Forms.Label()
        Me.Lb_TipoSalarioAnterior = New System.Windows.Forms.Label()
        Me.Lb_GrupoAnterior = New System.Windows.Forms.Label()
        Me.Lb_CategoriaAnterior = New System.Windows.Forms.Label()
        Me.Lb_CargoAnterior = New System.Windows.Forms.Label()
        Me.Lb_TextoCargoAnterior = New System.Windows.Forms.Label()
        Me.Lb_TextoCategoriaAnterior = New System.Windows.Forms.Label()
        Me.Lb_TextoGrupoAnterior = New System.Windows.Forms.Label()
        Me.Lb_TextoTipoSalarioAnterior = New System.Windows.Forms.Label()
        Me.Lb_TextoSalarioAnterior = New System.Windows.Forms.Label()
        Me.Lb_FechaInicioVigencia = New System.Windows.Forms.Label()
        Me.Lb_TextoFechaInicioVigencia = New System.Windows.Forms.Label()
        Me.Lb_TextoFechaFinVigencia = New System.Windows.Forms.Label()
        Me.Dtp_FechaFinVigencia = New System.Windows.Forms.DateTimePicker()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lb_TextoNombre = New System.Windows.Forms.Label()
        Me.Lb_Codigo = New System.Windows.Forms.Label()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Lb_TextoCodigo = New System.Windows.Forms.Label()
        Me.Pn_Conceptos = New System.Windows.Forms.Panel()
        Me.Dgv_Conceptos = New System.Windows.Forms.DataGridView()
        Me.DGVCBC_CODIGOTIPOCONCEPTOCONTRATO = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVTBC_VALOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVCBC_PERIODICIDAD = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVCBC_ACTIVO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Pn_TituloConceptos = New System.Windows.Forms.Panel()
        Me.Lb_TextoConceptos = New System.Windows.Forms.Label()
        Me.Bt_AgregarConcepto = New System.Windows.Forms.Button()
        Me.Pn_Inferior = New System.Windows.Forms.Panel()
        Me.Tlp_Botones = New System.Windows.Forms.TableLayoutPanel()
        Me.Lb_Estado = New System.Windows.Forms.Label()
        Me.Tt_Reclasificar = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pn_DatosReclasificacion.SuspendLayout()
        Me.GB_Vigencia.SuspendLayout()
        Me.Tlp_FechasVigencia.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Pn_Conceptos.SuspendLayout()
        CType(Me.Dgv_Conceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_TituloConceptos.SuspendLayout()
        Me.Tlp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_DatosReclasificacion
        '
        Me.Pn_DatosReclasificacion.Controls.Add(Me.Lb_TextoGrupo)
        Me.Pn_DatosReclasificacion.Controls.Add(Me.Cb_TipoGrupo)
        Me.Pn_DatosReclasificacion.Controls.Add(Me.Cb_TipoSalario)
        Me.Pn_DatosReclasificacion.Controls.Add(Me.Lb_TextoTipoSalario)
        Me.Pn_DatosReclasificacion.Controls.Add(Me.Lb_TextoCategoria)
        Me.Pn_DatosReclasificacion.Controls.Add(Me.Cb_Categoria)
        Me.Pn_DatosReclasificacion.Controls.Add(Me.Lb_TextoCargo)
        Me.Pn_DatosReclasificacion.Controls.Add(Me.Cb_Cargo_Desempeña)
        Me.Pn_DatosReclasificacion.Controls.Add(Me.Lb_TextoSalario)
        Me.Pn_DatosReclasificacion.Controls.Add(Me.Tx_Salario)
        Me.Pn_DatosReclasificacion.Controls.Add(Me.GB_Vigencia)
        Me.Pn_DatosReclasificacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_DatosReclasificacion.Location = New System.Drawing.Point(0, 24)
        Me.Pn_DatosReclasificacion.Name = "Pn_DatosReclasificacion"
        Me.Pn_DatosReclasificacion.Size = New System.Drawing.Size(684, 240)
        Me.Pn_DatosReclasificacion.TabIndex = 1
        '
        'Lb_TextoGrupo
        '
        Me.Lb_TextoGrupo.AutoSize = True
        Me.Lb_TextoGrupo.Location = New System.Drawing.Point(192, 41)
        Me.Lb_TextoGrupo.Name = "Lb_TextoGrupo"
        Me.Lb_TextoGrupo.Size = New System.Drawing.Size(39, 13)
        Me.Lb_TextoGrupo.TabIndex = 4
        Me.Lb_TextoGrupo.Text = "Grupo:"
        '
        'Cb_TipoGrupo
        '
        Me.Cb_TipoGrupo.DisplayMember = "NOMRETIPOGRUPO"
        Me.Cb_TipoGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoGrupo.FormattingEnabled = True
        Me.Cb_TipoGrupo.Location = New System.Drawing.Point(234, 37)
        Me.Cb_TipoGrupo.Name = "Cb_TipoGrupo"
        Me.Cb_TipoGrupo.Size = New System.Drawing.Size(105, 21)
        Me.Cb_TipoGrupo.TabIndex = 5
        Me.Cb_TipoGrupo.ValueMember = "CODIGOTIPOGRUPO"
        '
        'Cb_TipoSalario
        '
        Me.Cb_TipoSalario.DisplayMember = "NOMBRETIPOSALARIO"
        Me.Cb_TipoSalario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoSalario.FormattingEnabled = True
        Me.Cb_TipoSalario.Location = New System.Drawing.Point(424, 37)
        Me.Cb_TipoSalario.Name = "Cb_TipoSalario"
        Me.Cb_TipoSalario.Size = New System.Drawing.Size(86, 21)
        Me.Cb_TipoSalario.TabIndex = 7
        Me.Cb_TipoSalario.ValueMember = "CODIGOTIPOSALARIO"
        '
        'Lb_TextoTipoSalario
        '
        Me.Lb_TextoTipoSalario.AutoSize = True
        Me.Lb_TextoTipoSalario.Location = New System.Drawing.Point(357, 41)
        Me.Lb_TextoTipoSalario.Name = "Lb_TextoTipoSalario"
        Me.Lb_TextoTipoSalario.Size = New System.Drawing.Size(64, 13)
        Me.Lb_TextoTipoSalario.TabIndex = 6
        Me.Lb_TextoTipoSalario.Text = "Tipo salario:"
        '
        'Lb_TextoCategoria
        '
        Me.Lb_TextoCategoria.AutoSize = True
        Me.Lb_TextoCategoria.Location = New System.Drawing.Point(63, 41)
        Me.Lb_TextoCategoria.Name = "Lb_TextoCategoria"
        Me.Lb_TextoCategoria.Size = New System.Drawing.Size(57, 13)
        Me.Lb_TextoCategoria.TabIndex = 2
        Me.Lb_TextoCategoria.Text = "Categoría:"
        '
        'Cb_Categoria
        '
        Me.Cb_Categoria.DisplayMember = "NOMBRETIPOCATEGORIA"
        Me.Cb_Categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Categoria.FormattingEnabled = True
        Me.Cb_Categoria.Location = New System.Drawing.Point(123, 37)
        Me.Cb_Categoria.Name = "Cb_Categoria"
        Me.Cb_Categoria.Size = New System.Drawing.Size(53, 21)
        Me.Cb_Categoria.TabIndex = 3
        Me.Cb_Categoria.ValueMember = "CODIGOTIPOCATEGORIA"
        '
        'Lb_TextoCargo
        '
        Me.Lb_TextoCargo.AutoSize = True
        Me.Lb_TextoCargo.Location = New System.Drawing.Point(12, 14)
        Me.Lb_TextoCargo.Name = "Lb_TextoCargo"
        Me.Lb_TextoCargo.Size = New System.Drawing.Size(108, 13)
        Me.Lb_TextoCargo.TabIndex = 0
        Me.Lb_TextoCargo.Text = "Cargo a desempeñar:"
        '
        'Cb_Cargo_Desempeña
        '
        Me.Cb_Cargo_Desempeña.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Cargo_Desempeña.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Cargo_Desempeña.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Cargo_Desempeña.DisplayMember = "NOMBRETIPOCARGO"
        Me.Cb_Cargo_Desempeña.FormattingEnabled = True
        Me.Cb_Cargo_Desempeña.Location = New System.Drawing.Point(123, 10)
        Me.Cb_Cargo_Desempeña.Name = "Cb_Cargo_Desempeña"
        Me.Cb_Cargo_Desempeña.Size = New System.Drawing.Size(548, 21)
        Me.Cb_Cargo_Desempeña.TabIndex = 1
        Me.Cb_Cargo_Desempeña.ValueMember = "CODIGOTIPOCARGO"
        '
        'Lb_TextoSalario
        '
        Me.Lb_TextoSalario.AutoSize = True
        Me.Lb_TextoSalario.Location = New System.Drawing.Point(516, 41)
        Me.Lb_TextoSalario.Name = "Lb_TextoSalario"
        Me.Lb_TextoSalario.Size = New System.Drawing.Size(42, 13)
        Me.Lb_TextoSalario.TabIndex = 8
        Me.Lb_TextoSalario.Text = "Salario:"
        '
        'Tx_Salario
        '
        Me.Tx_Salario.Location = New System.Drawing.Point(561, 37)
        Me.Tx_Salario.Name = "Tx_Salario"
        Me.Tx_Salario.Size = New System.Drawing.Size(100, 20)
        Me.Tx_Salario.TabIndex = 9
        '
        'GB_Vigencia
        '
        Me.GB_Vigencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Vigencia.Controls.Add(Me.Tlp_FechasVigencia)
        Me.GB_Vigencia.Location = New System.Drawing.Point(3, 64)
        Me.GB_Vigencia.Name = "GB_Vigencia"
        Me.GB_Vigencia.Size = New System.Drawing.Size(678, 172)
        Me.GB_Vigencia.TabIndex = 10
        Me.GB_Vigencia.TabStop = False
        Me.GB_Vigencia.Text = "Vigencia contrato actual"
        '
        'Tlp_FechasVigencia
        '
        Me.Tlp_FechasVigencia.ColumnCount = 2
        Me.Tlp_FechasVigencia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_FechasVigencia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_SalarioAnterior, 1, 4)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_TipoSalarioAnterior, 1, 3)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_GrupoAnterior, 1, 2)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_CategoriaAnterior, 1, 1)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_CargoAnterior, 1, 0)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_TextoCargoAnterior, 0, 0)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_TextoCategoriaAnterior, 0, 1)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_TextoGrupoAnterior, 0, 2)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_TextoTipoSalarioAnterior, 0, 3)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_TextoSalarioAnterior, 0, 4)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_FechaInicioVigencia, 1, 5)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_TextoFechaInicioVigencia, 0, 5)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Lb_TextoFechaFinVigencia, 0, 6)
        Me.Tlp_FechasVigencia.Controls.Add(Me.Dtp_FechaFinVigencia, 1, 6)
        Me.Tlp_FechasVigencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tlp_FechasVigencia.Location = New System.Drawing.Point(3, 16)
        Me.Tlp_FechasVigencia.Name = "Tlp_FechasVigencia"
        Me.Tlp_FechasVigencia.RowCount = 7
        Me.Tlp_FechasVigencia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Tlp_FechasVigencia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Tlp_FechasVigencia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Tlp_FechasVigencia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Tlp_FechasVigencia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Tlp_FechasVigencia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Tlp_FechasVigencia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.Tlp_FechasVigencia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp_FechasVigencia.Size = New System.Drawing.Size(672, 153)
        Me.Tlp_FechasVigencia.TabIndex = 0
        '
        'Lb_SalarioAnterior
        '
        Me.Lb_SalarioAnterior.AutoSize = True
        Me.Lb_SalarioAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_SalarioAnterior.Location = New System.Drawing.Point(119, 84)
        Me.Lb_SalarioAnterior.Name = "Lb_SalarioAnterior"
        Me.Lb_SalarioAnterior.Size = New System.Drawing.Size(550, 21)
        Me.Lb_SalarioAnterior.TabIndex = 9
        Me.Lb_SalarioAnterior.Text = "Lb_SalarioAnterior"
        Me.Lb_SalarioAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_TipoSalarioAnterior
        '
        Me.Lb_TipoSalarioAnterior.AutoSize = True
        Me.Lb_TipoSalarioAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TipoSalarioAnterior.Location = New System.Drawing.Point(119, 63)
        Me.Lb_TipoSalarioAnterior.Name = "Lb_TipoSalarioAnterior"
        Me.Lb_TipoSalarioAnterior.Size = New System.Drawing.Size(550, 21)
        Me.Lb_TipoSalarioAnterior.TabIndex = 7
        Me.Lb_TipoSalarioAnterior.Text = "Lb_TipoSalarioAnterior"
        Me.Lb_TipoSalarioAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_GrupoAnterior
        '
        Me.Lb_GrupoAnterior.AutoSize = True
        Me.Lb_GrupoAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_GrupoAnterior.Location = New System.Drawing.Point(119, 42)
        Me.Lb_GrupoAnterior.Name = "Lb_GrupoAnterior"
        Me.Lb_GrupoAnterior.Size = New System.Drawing.Size(550, 21)
        Me.Lb_GrupoAnterior.TabIndex = 5
        Me.Lb_GrupoAnterior.Text = "Lb_GrupoAnterior"
        Me.Lb_GrupoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_CategoriaAnterior
        '
        Me.Lb_CategoriaAnterior.AutoSize = True
        Me.Lb_CategoriaAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_CategoriaAnterior.Location = New System.Drawing.Point(119, 21)
        Me.Lb_CategoriaAnterior.Name = "Lb_CategoriaAnterior"
        Me.Lb_CategoriaAnterior.Size = New System.Drawing.Size(550, 21)
        Me.Lb_CategoriaAnterior.TabIndex = 3
        Me.Lb_CategoriaAnterior.Text = "Lb_CategoriaAnterior"
        Me.Lb_CategoriaAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_CargoAnterior
        '
        Me.Lb_CargoAnterior.AutoSize = True
        Me.Lb_CargoAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_CargoAnterior.Location = New System.Drawing.Point(119, 0)
        Me.Lb_CargoAnterior.Name = "Lb_CargoAnterior"
        Me.Lb_CargoAnterior.Size = New System.Drawing.Size(550, 21)
        Me.Lb_CargoAnterior.TabIndex = 1
        Me.Lb_CargoAnterior.Text = "Lb_CargoAnterior"
        Me.Lb_CargoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_TextoCargoAnterior
        '
        Me.Lb_TextoCargoAnterior.AutoSize = True
        Me.Lb_TextoCargoAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoCargoAnterior.Location = New System.Drawing.Point(3, 0)
        Me.Lb_TextoCargoAnterior.Name = "Lb_TextoCargoAnterior"
        Me.Lb_TextoCargoAnterior.Size = New System.Drawing.Size(110, 21)
        Me.Lb_TextoCargoAnterior.TabIndex = 0
        Me.Lb_TextoCargoAnterior.Text = "Cargo:"
        Me.Lb_TextoCargoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_TextoCategoriaAnterior
        '
        Me.Lb_TextoCategoriaAnterior.AutoSize = True
        Me.Lb_TextoCategoriaAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoCategoriaAnterior.Location = New System.Drawing.Point(3, 21)
        Me.Lb_TextoCategoriaAnterior.Name = "Lb_TextoCategoriaAnterior"
        Me.Lb_TextoCategoriaAnterior.Size = New System.Drawing.Size(110, 21)
        Me.Lb_TextoCategoriaAnterior.TabIndex = 2
        Me.Lb_TextoCategoriaAnterior.Text = "Categoría:"
        Me.Lb_TextoCategoriaAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_TextoGrupoAnterior
        '
        Me.Lb_TextoGrupoAnterior.AutoSize = True
        Me.Lb_TextoGrupoAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoGrupoAnterior.Location = New System.Drawing.Point(3, 42)
        Me.Lb_TextoGrupoAnterior.Name = "Lb_TextoGrupoAnterior"
        Me.Lb_TextoGrupoAnterior.Size = New System.Drawing.Size(110, 21)
        Me.Lb_TextoGrupoAnterior.TabIndex = 4
        Me.Lb_TextoGrupoAnterior.Text = "Grupo:"
        Me.Lb_TextoGrupoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_TextoTipoSalarioAnterior
        '
        Me.Lb_TextoTipoSalarioAnterior.AutoSize = True
        Me.Lb_TextoTipoSalarioAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoTipoSalarioAnterior.Location = New System.Drawing.Point(3, 63)
        Me.Lb_TextoTipoSalarioAnterior.Name = "Lb_TextoTipoSalarioAnterior"
        Me.Lb_TextoTipoSalarioAnterior.Size = New System.Drawing.Size(110, 21)
        Me.Lb_TextoTipoSalarioAnterior.TabIndex = 6
        Me.Lb_TextoTipoSalarioAnterior.Text = "Tipo salario:"
        Me.Lb_TextoTipoSalarioAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_TextoSalarioAnterior
        '
        Me.Lb_TextoSalarioAnterior.AutoSize = True
        Me.Lb_TextoSalarioAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoSalarioAnterior.Location = New System.Drawing.Point(3, 84)
        Me.Lb_TextoSalarioAnterior.Name = "Lb_TextoSalarioAnterior"
        Me.Lb_TextoSalarioAnterior.Size = New System.Drawing.Size(110, 21)
        Me.Lb_TextoSalarioAnterior.TabIndex = 8
        Me.Lb_TextoSalarioAnterior.Text = "Salario:"
        Me.Lb_TextoSalarioAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_FechaInicioVigencia
        '
        Me.Lb_FechaInicioVigencia.AutoSize = True
        Me.Lb_FechaInicioVigencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_FechaInicioVigencia.Location = New System.Drawing.Point(119, 105)
        Me.Lb_FechaInicioVigencia.Name = "Lb_FechaInicioVigencia"
        Me.Lb_FechaInicioVigencia.Size = New System.Drawing.Size(550, 21)
        Me.Lb_FechaInicioVigencia.TabIndex = 11
        Me.Lb_FechaInicioVigencia.Text = "Lb_FechaInicioVigencia"
        Me.Lb_FechaInicioVigencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Tt_Reclasificar.SetToolTip(Me.Lb_FechaInicioVigencia, "Fecha de inicio de la vigencia de la clasificación anterior")
        '
        'Lb_TextoFechaInicioVigencia
        '
        Me.Lb_TextoFechaInicioVigencia.AutoSize = True
        Me.Lb_TextoFechaInicioVigencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoFechaInicioVigencia.Location = New System.Drawing.Point(3, 105)
        Me.Lb_TextoFechaInicioVigencia.Name = "Lb_TextoFechaInicioVigencia"
        Me.Lb_TextoFechaInicioVigencia.Size = New System.Drawing.Size(110, 21)
        Me.Lb_TextoFechaInicioVigencia.TabIndex = 10
        Me.Lb_TextoFechaInicioVigencia.Text = "Fecha inicio vigencia:"
        Me.Lb_TextoFechaInicioVigencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Tt_Reclasificar.SetToolTip(Me.Lb_TextoFechaInicioVigencia, "Fecha de inicio de la vigencia de la clasificación anterior")
        '
        'Lb_TextoFechaFinVigencia
        '
        Me.Lb_TextoFechaFinVigencia.AutoSize = True
        Me.Lb_TextoFechaFinVigencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoFechaFinVigencia.Location = New System.Drawing.Point(3, 126)
        Me.Lb_TextoFechaFinVigencia.Name = "Lb_TextoFechaFinVigencia"
        Me.Lb_TextoFechaFinVigencia.Size = New System.Drawing.Size(110, 27)
        Me.Lb_TextoFechaFinVigencia.TabIndex = 12
        Me.Lb_TextoFechaFinVigencia.Text = "Fecha fin vigencia:"
        Me.Lb_TextoFechaFinVigencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Tt_Reclasificar.SetToolTip(Me.Lb_TextoFechaFinVigencia, "Fecha de finalización de la vigencia de la clasificación anterior")
        '
        'Dtp_FechaFinVigencia
        '
        Me.Dtp_FechaFinVigencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Dtp_FechaFinVigencia.Checked = False
        Me.Dtp_FechaFinVigencia.Location = New System.Drawing.Point(119, 129)
        Me.Dtp_FechaFinVigencia.Name = "Dtp_FechaFinVigencia"
        Me.Dtp_FechaFinVigencia.ShowCheckBox = True
        Me.Dtp_FechaFinVigencia.Size = New System.Drawing.Size(240, 20)
        Me.Dtp_FechaFinVigencia.TabIndex = 13
        Me.Tt_Reclasificar.SetToolTip(Me.Dtp_FechaFinVigencia, "Fecha de finalización de la vigencia de la clasificación anterior")
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(73, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(611, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(533, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(452, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lb_TextoNombre, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lb_Codigo, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lb_Nombre, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lb_TextoCodigo, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(684, 24)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Lb_TextoNombre
        '
        Me.Lb_TextoNombre.AutoSize = True
        Me.Lb_TextoNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoNombre.Location = New System.Drawing.Point(133, 0)
        Me.Lb_TextoNombre.Name = "Lb_TextoNombre"
        Me.Lb_TextoNombre.Size = New System.Drawing.Size(47, 24)
        Me.Lb_TextoNombre.TabIndex = 2
        Me.Lb_TextoNombre.Text = "Nombre:"
        Me.Lb_TextoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_Codigo
        '
        Me.Lb_Codigo.AutoSize = True
        Me.Lb_Codigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Codigo.Location = New System.Drawing.Point(60, 0)
        Me.Lb_Codigo.Name = "Lb_Codigo"
        Me.Lb_Codigo.Size = New System.Drawing.Size(67, 24)
        Me.Lb_Codigo.TabIndex = 1
        Me.Lb_Codigo.Text = "Lb_Codigo"
        Me.Lb_Codigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.Location = New System.Drawing.Point(186, 0)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(487, 24)
        Me.Lb_Nombre.TabIndex = 3
        Me.Lb_Nombre.Text = "Lb_Nombre"
        Me.Lb_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_TextoCodigo
        '
        Me.Lb_TextoCodigo.AutoSize = True
        Me.Lb_TextoCodigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoCodigo.Location = New System.Drawing.Point(11, 0)
        Me.Lb_TextoCodigo.Name = "Lb_TextoCodigo"
        Me.Lb_TextoCodigo.Size = New System.Drawing.Size(43, 24)
        Me.Lb_TextoCodigo.TabIndex = 0
        Me.Lb_TextoCodigo.Text = "Código:"
        Me.Lb_TextoCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pn_Conceptos
        '
        Me.Pn_Conceptos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Conceptos.Controls.Add(Me.Dgv_Conceptos)
        Me.Pn_Conceptos.Controls.Add(Me.Pn_TituloConceptos)
        Me.Pn_Conceptos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Conceptos.Location = New System.Drawing.Point(0, 264)
        Me.Pn_Conceptos.Name = "Pn_Conceptos"
        Me.Pn_Conceptos.Size = New System.Drawing.Size(684, 197)
        Me.Pn_Conceptos.TabIndex = 2
        '
        'Dgv_Conceptos
        '
        Me.Dgv_Conceptos.AllowUserToAddRows = False
        Me.Dgv_Conceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Conceptos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Conceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Conceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVCBC_CODIGOTIPOCONCEPTOCONTRATO, Me.DGVTBC_VALOR, Me.DGVCBC_PERIODICIDAD, Me.DGVCBC_ACTIVO})
        Me.Dgv_Conceptos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Conceptos.Location = New System.Drawing.Point(0, 25)
        Me.Dgv_Conceptos.Name = "Dgv_Conceptos"
        Me.Dgv_Conceptos.Size = New System.Drawing.Size(682, 170)
        Me.Dgv_Conceptos.TabIndex = 1
        '
        'DGVCBC_CODIGOTIPOCONCEPTOCONTRATO
        '
        Me.DGVCBC_CODIGOTIPOCONCEPTOCONTRATO.DataPropertyName = "CODIGOTIPOCONCEPTOCONTRATO"
        Me.DGVCBC_CODIGOTIPOCONCEPTOCONTRATO.FillWeight = 440.0!
        Me.DGVCBC_CODIGOTIPOCONCEPTOCONTRATO.HeaderText = "Tipo"
        Me.DGVCBC_CODIGOTIPOCONCEPTOCONTRATO.Name = "DGVCBC_CODIGOTIPOCONCEPTOCONTRATO"
        '
        'DGVTBC_VALOR
        '
        Me.DGVTBC_VALOR.DataPropertyName = "VALOR"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DGVTBC_VALOR.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGVTBC_VALOR.FillWeight = 120.0!
        Me.DGVTBC_VALOR.HeaderText = "Valor"
        Me.DGVTBC_VALOR.Name = "DGVTBC_VALOR"
        Me.DGVTBC_VALOR.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVTBC_VALOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DGVCBC_PERIODICIDAD
        '
        Me.DGVCBC_PERIODICIDAD.DataPropertyName = "PERIODICIDAD"
        Me.DGVCBC_PERIODICIDAD.HeaderText = "Periodicidad"
        Me.DGVCBC_PERIODICIDAD.Items.AddRange(New Object() {"Día Laborado", "Día Obra", "Día Calendario", "Mes"})
        Me.DGVCBC_PERIODICIDAD.Name = "DGVCBC_PERIODICIDAD"
        '
        'DGVCBC_ACTIVO
        '
        Me.DGVCBC_ACTIVO.DataPropertyName = "ACTIVO"
        Me.DGVCBC_ACTIVO.FalseValue = "N"
        Me.DGVCBC_ACTIVO.FillWeight = 80.0!
        Me.DGVCBC_ACTIVO.HeaderText = "Activo"
        Me.DGVCBC_ACTIVO.Name = "DGVCBC_ACTIVO"
        Me.DGVCBC_ACTIVO.TrueValue = "S"
        '
        'Pn_TituloConceptos
        '
        Me.Pn_TituloConceptos.Controls.Add(Me.Lb_TextoConceptos)
        Me.Pn_TituloConceptos.Controls.Add(Me.Bt_AgregarConcepto)
        Me.Pn_TituloConceptos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloConceptos.Location = New System.Drawing.Point(0, 0)
        Me.Pn_TituloConceptos.Name = "Pn_TituloConceptos"
        Me.Pn_TituloConceptos.Size = New System.Drawing.Size(682, 25)
        Me.Pn_TituloConceptos.TabIndex = 0
        '
        'Lb_TextoConceptos
        '
        Me.Lb_TextoConceptos.AutoSize = True
        Me.Lb_TextoConceptos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoConceptos.ForeColor = System.Drawing.Color.Blue
        Me.Lb_TextoConceptos.Location = New System.Drawing.Point(3, 4)
        Me.Lb_TextoConceptos.Name = "Lb_TextoConceptos"
        Me.Lb_TextoConceptos.Size = New System.Drawing.Size(240, 16)
        Me.Lb_TextoConceptos.TabIndex = 0
        Me.Lb_TextoConceptos.Text = "Conceptos asociados al contrato:"
        Me.Lb_TextoConceptos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bt_AgregarConcepto
        '
        Me.Bt_AgregarConcepto.Location = New System.Drawing.Point(247, 1)
        Me.Bt_AgregarConcepto.Name = "Bt_AgregarConcepto"
        Me.Bt_AgregarConcepto.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarConcepto.TabIndex = 1
        Me.Bt_AgregarConcepto.Text = "Agregar"
        Me.Bt_AgregarConcepto.UseVisualStyleBackColor = True
        '
        'Pn_Inferior
        '
        Me.Pn_Inferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Inferior.Location = New System.Drawing.Point(0, 461)
        Me.Pn_Inferior.Name = "Pn_Inferior"
        Me.Pn_Inferior.Size = New System.Drawing.Size(684, 30)
        Me.Pn_Inferior.TabIndex = 2
        '
        'Tlp_Botones
        '
        Me.Tlp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Tlp_Botones.ColumnCount = 2
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Botones.Controls.Add(Me.Lb_Estado, 0, 0)
        Me.Tlp_Botones.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_Botones.Location = New System.Drawing.Point(0, 491)
        Me.Tlp_Botones.Name = "Tlp_Botones"
        Me.Tlp_Botones.RowCount = 1
        Me.Tlp_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Botones.Size = New System.Drawing.Size(684, 30)
        Me.Tlp_Botones.TabIndex = 3
        '
        'Lb_Estado
        '
        Me.Lb_Estado.AutoSize = True
        Me.Lb_Estado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Estado.Location = New System.Drawing.Point(3, 0)
        Me.Lb_Estado.Name = "Lb_Estado"
        Me.Lb_Estado.Size = New System.Drawing.Size(67, 30)
        Me.Lb_Estado.TabIndex = 0
        Me.Lb_Estado.Text = "Lb_Estado"
        Me.Lb_Estado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lb_Estado.Visible = False
        '
        'Fr_ReclasificarContrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 521)
        Me.Controls.Add(Me.Pn_Conceptos)
        Me.Controls.Add(Me.Pn_DatosReclasificacion)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Pn_Inferior)
        Me.Controls.Add(Me.Tlp_Botones)
        Me.Name = "Fr_ReclasificarContrato"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reclasificar Contrato"
        Me.Pn_DatosReclasificacion.ResumeLayout(False)
        Me.Pn_DatosReclasificacion.PerformLayout()
        Me.GB_Vigencia.ResumeLayout(False)
        Me.Tlp_FechasVigencia.ResumeLayout(False)
        Me.Tlp_FechasVigencia.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Pn_Conceptos.ResumeLayout(False)
        CType(Me.Dgv_Conceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_TituloConceptos.ResumeLayout(False)
        Me.Pn_TituloConceptos.PerformLayout()
        Me.Tlp_Botones.ResumeLayout(False)
        Me.Tlp_Botones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_DatosReclasificacion As System.Windows.Forms.Panel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lb_TextoNombre As System.Windows.Forms.Label
    Friend WithEvents Lb_Codigo As System.Windows.Forms.Label
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCodigo As System.Windows.Forms.Label
    Friend WithEvents Cb_Cargo_Desempeña As System.Windows.Forms.ComboBox
    Friend WithEvents Tx_Salario As System.Windows.Forms.TextBox
    Friend WithEvents Dtp_FechaFinVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_TextoFechaFinVigencia As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoSalario As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCargo As System.Windows.Forms.Label
    Friend WithEvents Pn_Conceptos As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Conceptos As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_TituloConceptos As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarConcepto As System.Windows.Forms.Button
    Friend WithEvents Lb_TextoConceptos As System.Windows.Forms.Label
    Friend WithEvents Pn_Inferior As System.Windows.Forms.Panel
    Friend WithEvents Tlp_Botones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lb_Estado As System.Windows.Forms.Label
    Friend WithEvents GB_Vigencia As System.Windows.Forms.GroupBox
    Friend WithEvents Tlp_FechasVigencia As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lb_FechaInicioVigencia As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoFechaInicioVigencia As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCategoria As System.Windows.Forms.Label
    Friend WithEvents Cb_Categoria As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoGrupo As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_TipoSalario As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoTipoSalario As System.Windows.Forms.Label
    Friend WithEvents DGVCBC_CODIGOTIPOCONCEPTOCONTRATO As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVTBC_VALOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVCBC_PERIODICIDAD As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVCBC_ACTIVO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Tt_Reclasificar As System.Windows.Forms.ToolTip
    Friend WithEvents Lb_CargoAnterior As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCargoAnterior As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCategoriaAnterior As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoGrupoAnterior As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoTipoSalarioAnterior As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoSalarioAnterior As System.Windows.Forms.Label
    Friend WithEvents Lb_SalarioAnterior As System.Windows.Forms.Label
    Friend WithEvents Lb_TipoSalarioAnterior As System.Windows.Forms.Label
    Friend WithEvents Lb_GrupoAnterior As System.Windows.Forms.Label
    Friend WithEvents Lb_CategoriaAnterior As System.Windows.Forms.Label

End Class
