<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_EnviarCorreosNomina
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
        Me.Ofd_AbrirExcel = New System.Windows.Forms.OpenFileDialog()
        Me.Bt_Abrir = New System.Windows.Forms.Button()
        Me.Lb_NombreArchivo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Dgv_CorreosEnviados = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn52 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn53 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn54 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn57 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn58 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn59 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn60 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn61 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn62 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn63 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn64 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn65 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn67 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn68 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bt_ExportarEnviados = New System.Windows.Forms.Button()
        Me.Lb_CorreosEnviados = New System.Windows.Forms.Label()
        Me.Dgv_CorreosSinEnviar = New System.Windows.Forms.DataGridView()
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
        Me.Bt_ExportarNoEnviados = New System.Windows.Forms.Button()
        Me.Lb_CorreosSinEnviar = New System.Windows.Forms.Label()
        Me.Bt_EnviarCorreos = New System.Windows.Forms.Button()
        Me.Dgv_Datos = New System.Windows.Forms.DataGridView()
        Me.NRO1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEDULA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CARGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FRENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.N_FRENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F_INGRESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.S_BASICO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONCEPTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE_CONCEPTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VQLOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DETALLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CORREO_ELECTRONICO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ERRORES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lb_ConteoRegistros = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Pb_carga = New System.Windows.Forms.ProgressBar()
        Me.Lb_Progreso = New System.Windows.Forms.Label()
        Me.Bt_DescargarFormato = New System.Windows.Forms.Button()
        Me.Sfd_GuardarExcel = New System.Windows.Forms.SaveFileDialog()
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
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn43 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn46 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn47 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn48 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn49 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn50 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn51 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bgw_correos = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Dgv_CorreosEnviados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_CorreosSinEnviar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_Datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ofd_AbrirExcel
        '
        Me.Ofd_AbrirExcel.Filter = "Archivo de Excel|*.xls;*.xlsx;*"
        Me.Ofd_AbrirExcel.Title = "Abrir Excel"
        '
        'Bt_Abrir
        '
        Me.Bt_Abrir.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_Abrir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_Abrir.ForeColor = System.Drawing.Color.Green
        Me.Bt_Abrir.Location = New System.Drawing.Point(15, 40)
        Me.Bt_Abrir.Name = "Bt_Abrir"
        Me.Bt_Abrir.Size = New System.Drawing.Size(1142, 33)
        Me.Bt_Abrir.TabIndex = 0
        Me.Bt_Abrir.Text = "Seleccionar Archivo de Excel"
        Me.Bt_Abrir.UseVisualStyleBackColor = True
        '
        'Lb_NombreArchivo
        '
        Me.Lb_NombreArchivo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_NombreArchivo.Location = New System.Drawing.Point(15, 73)
        Me.Lb_NombreArchivo.Name = "Lb_NombreArchivo"
        Me.Lb_NombreArchivo.Size = New System.Drawing.Size(1142, 18)
        Me.Lb_NombreArchivo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Info
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1172, 50)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Seleccione un archivo de excel con el formato correcto y luego haga click en el b" & _
    "oton ENVIAR CORREOS, si hay correos que no pueden ser enviados se listaran para " & _
    "que los corrija"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Bt_EnviarCorreos)
        Me.Panel1.Controls.Add(Me.Dgv_Datos)
        Me.Panel1.Controls.Add(Me.Lb_ConteoRegistros)
        Me.Panel1.Controls.Add(Me.Lb_NombreArchivo)
        Me.Panel1.Controls.Add(Me.Bt_Abrir)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(15)
        Me.Panel1.Size = New System.Drawing.Size(1172, 630)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(15, 404)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1142, 211)
        Me.Panel2.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Dgv_CorreosEnviados)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Bt_ExportarEnviados)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Lb_CorreosEnviados)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Dgv_CorreosSinEnviar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Bt_ExportarNoEnviados)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Lb_CorreosSinEnviar)
        Me.SplitContainer1.Size = New System.Drawing.Size(1142, 211)
        Me.SplitContainer1.SplitterDistance = 557
        Me.SplitContainer1.TabIndex = 0
        '
        'Dgv_CorreosEnviados
        '
        Me.Dgv_CorreosEnviados.AllowUserToAddRows = False
        Me.Dgv_CorreosEnviados.AllowUserToDeleteRows = False
        Me.Dgv_CorreosEnviados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_CorreosEnviados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn52, Me.DataGridViewTextBoxColumn53, Me.DataGridViewTextBoxColumn54, Me.DataGridViewTextBoxColumn55, Me.DataGridViewTextBoxColumn56, Me.DataGridViewTextBoxColumn57, Me.DataGridViewTextBoxColumn58, Me.DataGridViewTextBoxColumn59, Me.DataGridViewTextBoxColumn60, Me.DataGridViewTextBoxColumn61, Me.DataGridViewTextBoxColumn62, Me.DataGridViewTextBoxColumn63, Me.DataGridViewTextBoxColumn64, Me.DataGridViewTextBoxColumn65, Me.DataGridViewTextBoxColumn66, Me.DataGridViewTextBoxColumn67, Me.DataGridViewTextBoxColumn68})
        Me.Dgv_CorreosEnviados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_CorreosEnviados.Location = New System.Drawing.Point(0, 23)
        Me.Dgv_CorreosEnviados.Name = "Dgv_CorreosEnviados"
        Me.Dgv_CorreosEnviados.ReadOnly = True
        Me.Dgv_CorreosEnviados.Size = New System.Drawing.Size(553, 157)
        Me.Dgv_CorreosEnviados.TabIndex = 8
        '
        'DataGridViewTextBoxColumn52
        '
        Me.DataGridViewTextBoxColumn52.DataPropertyName = "NRO"
        Me.DataGridViewTextBoxColumn52.HeaderText = "NRO"
        Me.DataGridViewTextBoxColumn52.Name = "DataGridViewTextBoxColumn52"
        Me.DataGridViewTextBoxColumn52.ReadOnly = True
        Me.DataGridViewTextBoxColumn52.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn53
        '
        Me.DataGridViewTextBoxColumn53.DataPropertyName = "CODIGO"
        Me.DataGridViewTextBoxColumn53.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
        Me.DataGridViewTextBoxColumn53.ReadOnly = True
        Me.DataGridViewTextBoxColumn53.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn54
        '
        Me.DataGridViewTextBoxColumn54.DataPropertyName = "CEDULA"
        Me.DataGridViewTextBoxColumn54.HeaderText = "CEDULA"
        Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
        Me.DataGridViewTextBoxColumn54.ReadOnly = True
        Me.DataGridViewTextBoxColumn54.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn55
        '
        Me.DataGridViewTextBoxColumn55.DataPropertyName = "CARGO"
        Me.DataGridViewTextBoxColumn55.HeaderText = "CARGO"
        Me.DataGridViewTextBoxColumn55.Name = "DataGridViewTextBoxColumn55"
        Me.DataGridViewTextBoxColumn55.ReadOnly = True
        Me.DataGridViewTextBoxColumn55.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn56
        '
        Me.DataGridViewTextBoxColumn56.DataPropertyName = "FRENTE"
        Me.DataGridViewTextBoxColumn56.HeaderText = "FRENTE"
        Me.DataGridViewTextBoxColumn56.Name = "DataGridViewTextBoxColumn56"
        Me.DataGridViewTextBoxColumn56.ReadOnly = True
        Me.DataGridViewTextBoxColumn56.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn57
        '
        Me.DataGridViewTextBoxColumn57.DataPropertyName = "N#FRENTE"
        Me.DataGridViewTextBoxColumn57.HeaderText = "N.FRENTE"
        Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
        Me.DataGridViewTextBoxColumn57.ReadOnly = True
        Me.DataGridViewTextBoxColumn57.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn58
        '
        Me.DataGridViewTextBoxColumn58.DataPropertyName = "APELLIDOS"
        Me.DataGridViewTextBoxColumn58.HeaderText = "APELLIDOS"
        Me.DataGridViewTextBoxColumn58.Name = "DataGridViewTextBoxColumn58"
        Me.DataGridViewTextBoxColumn58.ReadOnly = True
        Me.DataGridViewTextBoxColumn58.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn59
        '
        Me.DataGridViewTextBoxColumn59.DataPropertyName = "NOMBRES"
        Me.DataGridViewTextBoxColumn59.HeaderText = "NOMBRES"
        Me.DataGridViewTextBoxColumn59.Name = "DataGridViewTextBoxColumn59"
        Me.DataGridViewTextBoxColumn59.ReadOnly = True
        Me.DataGridViewTextBoxColumn59.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn60
        '
        Me.DataGridViewTextBoxColumn60.DataPropertyName = "F#INGRESO"
        Me.DataGridViewTextBoxColumn60.HeaderText = "F.INGRESO"
        Me.DataGridViewTextBoxColumn60.Name = "DataGridViewTextBoxColumn60"
        Me.DataGridViewTextBoxColumn60.ReadOnly = True
        Me.DataGridViewTextBoxColumn60.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn61
        '
        Me.DataGridViewTextBoxColumn61.DataPropertyName = "S#BASICO"
        Me.DataGridViewTextBoxColumn61.HeaderText = "S.BASICO"
        Me.DataGridViewTextBoxColumn61.Name = "DataGridViewTextBoxColumn61"
        Me.DataGridViewTextBoxColumn61.ReadOnly = True
        Me.DataGridViewTextBoxColumn61.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn62
        '
        Me.DataGridViewTextBoxColumn62.DataPropertyName = "CONCEPTO"
        Me.DataGridViewTextBoxColumn62.HeaderText = "CONCEPTO"
        Me.DataGridViewTextBoxColumn62.Name = "DataGridViewTextBoxColumn62"
        Me.DataGridViewTextBoxColumn62.ReadOnly = True
        Me.DataGridViewTextBoxColumn62.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn63
        '
        Me.DataGridViewTextBoxColumn63.DataPropertyName = "NOMBRE DEL CONCEPTO"
        Me.DataGridViewTextBoxColumn63.HeaderText = "NOMBRE DEL CONCEPTO"
        Me.DataGridViewTextBoxColumn63.Name = "DataGridViewTextBoxColumn63"
        Me.DataGridViewTextBoxColumn63.ReadOnly = True
        Me.DataGridViewTextBoxColumn63.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn64
        '
        Me.DataGridViewTextBoxColumn64.DataPropertyName = "CANT"
        Me.DataGridViewTextBoxColumn64.HeaderText = "CANT"
        Me.DataGridViewTextBoxColumn64.Name = "DataGridViewTextBoxColumn64"
        Me.DataGridViewTextBoxColumn64.ReadOnly = True
        '
        'DataGridViewTextBoxColumn65
        '
        Me.DataGridViewTextBoxColumn65.DataPropertyName = "VALOR"
        Me.DataGridViewTextBoxColumn65.HeaderText = "VALOR"
        Me.DataGridViewTextBoxColumn65.Name = "DataGridViewTextBoxColumn65"
        Me.DataGridViewTextBoxColumn65.ReadOnly = True
        Me.DataGridViewTextBoxColumn65.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn66
        '
        Me.DataGridViewTextBoxColumn66.DataPropertyName = "DETALLE"
        Me.DataGridViewTextBoxColumn66.HeaderText = "DETALLE"
        Me.DataGridViewTextBoxColumn66.Name = "DataGridViewTextBoxColumn66"
        Me.DataGridViewTextBoxColumn66.ReadOnly = True
        Me.DataGridViewTextBoxColumn66.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn67
        '
        Me.DataGridViewTextBoxColumn67.DataPropertyName = "CORREO ELECTRONICO"
        Me.DataGridViewTextBoxColumn67.HeaderText = "CORREO ELECTRONICO"
        Me.DataGridViewTextBoxColumn67.Name = "DataGridViewTextBoxColumn67"
        Me.DataGridViewTextBoxColumn67.ReadOnly = True
        Me.DataGridViewTextBoxColumn67.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn68
        '
        Me.DataGridViewTextBoxColumn68.DataPropertyName = "ERRORES"
        Me.DataGridViewTextBoxColumn68.HeaderText = "ERRORES"
        Me.DataGridViewTextBoxColumn68.Name = "DataGridViewTextBoxColumn68"
        Me.DataGridViewTextBoxColumn68.ReadOnly = True
        Me.DataGridViewTextBoxColumn68.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Bt_ExportarEnviados
        '
        Me.Bt_ExportarEnviados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bt_ExportarEnviados.Enabled = False
        Me.Bt_ExportarEnviados.ForeColor = System.Drawing.Color.DarkGreen
        Me.Bt_ExportarEnviados.Location = New System.Drawing.Point(0, 180)
        Me.Bt_ExportarEnviados.Name = "Bt_ExportarEnviados"
        Me.Bt_ExportarEnviados.Size = New System.Drawing.Size(553, 27)
        Me.Bt_ExportarEnviados.TabIndex = 7
        Me.Bt_ExportarEnviados.Text = "Exportar a Excel"
        Me.Bt_ExportarEnviados.UseVisualStyleBackColor = True
        '
        'Lb_CorreosEnviados
        '
        Me.Lb_CorreosEnviados.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Lb_CorreosEnviados.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_CorreosEnviados.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CorreosEnviados.Name = "Lb_CorreosEnviados"
        Me.Lb_CorreosEnviados.Size = New System.Drawing.Size(553, 23)
        Me.Lb_CorreosEnviados.TabIndex = 0
        Me.Lb_CorreosEnviados.Text = "Correos Enviados"
        Me.Lb_CorreosEnviados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_CorreosSinEnviar
        '
        Me.Dgv_CorreosSinEnviar.AllowUserToAddRows = False
        Me.Dgv_CorreosSinEnviar.AllowUserToDeleteRows = False
        Me.Dgv_CorreosSinEnviar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_CorreosSinEnviar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17})
        Me.Dgv_CorreosSinEnviar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_CorreosSinEnviar.Location = New System.Drawing.Point(0, 23)
        Me.Dgv_CorreosSinEnviar.Name = "Dgv_CorreosSinEnviar"
        Me.Dgv_CorreosSinEnviar.ReadOnly = True
        Me.Dgv_CorreosSinEnviar.Size = New System.Drawing.Size(577, 157)
        Me.Dgv_CorreosSinEnviar.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "NRO"
        Me.DataGridViewTextBoxColumn1.HeaderText = "NRO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CODIGO"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CEDULA"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CEDULA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "CARGO"
        Me.DataGridViewTextBoxColumn4.HeaderText = "CARGO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "FRENTE"
        Me.DataGridViewTextBoxColumn5.HeaderText = "FRENTE"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "N#FRENTE"
        Me.DataGridViewTextBoxColumn6.HeaderText = "N.FRENTE"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "APELLIDOS"
        Me.DataGridViewTextBoxColumn7.HeaderText = "APELLIDOS"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "NOMBRES"
        Me.DataGridViewTextBoxColumn8.HeaderText = "NOMBRES"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "F#INGRESO"
        Me.DataGridViewTextBoxColumn9.HeaderText = "F.INGRESO"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "S#BASICO"
        Me.DataGridViewTextBoxColumn10.HeaderText = "S.BASICO"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "CONCEPTO"
        Me.DataGridViewTextBoxColumn11.HeaderText = "CONCEPTO"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "NOMBRE DEL CONCEPTO"
        Me.DataGridViewTextBoxColumn12.HeaderText = "NOMBRE DEL CONCEPTO"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "CANT"
        Me.DataGridViewTextBoxColumn13.HeaderText = "CANT"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "VALOR"
        Me.DataGridViewTextBoxColumn14.HeaderText = "VALOR"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "DETALLE"
        Me.DataGridViewTextBoxColumn15.HeaderText = "DETALLE"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "CORREO ELECTRONICO"
        Me.DataGridViewTextBoxColumn16.HeaderText = "CORREO ELECTRONICO"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "ERRORES"
        Me.DataGridViewTextBoxColumn17.HeaderText = "ERRORES"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Bt_ExportarNoEnviados
        '
        Me.Bt_ExportarNoEnviados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bt_ExportarNoEnviados.Enabled = False
        Me.Bt_ExportarNoEnviados.ForeColor = System.Drawing.Color.DarkGreen
        Me.Bt_ExportarNoEnviados.Location = New System.Drawing.Point(0, 180)
        Me.Bt_ExportarNoEnviados.Name = "Bt_ExportarNoEnviados"
        Me.Bt_ExportarNoEnviados.Size = New System.Drawing.Size(577, 27)
        Me.Bt_ExportarNoEnviados.TabIndex = 2
        Me.Bt_ExportarNoEnviados.Text = "Exportar a Excel"
        Me.Bt_ExportarNoEnviados.UseVisualStyleBackColor = True
        '
        'Lb_CorreosSinEnviar
        '
        Me.Lb_CorreosSinEnviar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Lb_CorreosSinEnviar.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_CorreosSinEnviar.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CorreosSinEnviar.Name = "Lb_CorreosSinEnviar"
        Me.Lb_CorreosSinEnviar.Size = New System.Drawing.Size(577, 23)
        Me.Lb_CorreosSinEnviar.TabIndex = 1
        Me.Lb_CorreosSinEnviar.Text = "Correos Sin Enviar"
        Me.Lb_CorreosSinEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bt_EnviarCorreos
        '
        Me.Bt_EnviarCorreos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_EnviarCorreos.Enabled = False
        Me.Bt_EnviarCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_EnviarCorreos.ForeColor = System.Drawing.Color.DarkGreen
        Me.Bt_EnviarCorreos.Location = New System.Drawing.Point(15, 374)
        Me.Bt_EnviarCorreos.Name = "Bt_EnviarCorreos"
        Me.Bt_EnviarCorreos.Size = New System.Drawing.Size(1142, 30)
        Me.Bt_EnviarCorreos.TabIndex = 2
        Me.Bt_EnviarCorreos.Text = "Enviar Correos"
        Me.Bt_EnviarCorreos.UseVisualStyleBackColor = True
        '
        'Dgv_Datos
        '
        Me.Dgv_Datos.AllowUserToAddRows = False
        Me.Dgv_Datos.AllowUserToDeleteRows = False
        Me.Dgv_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NRO1, Me.CODIGO, Me.CEDULA, Me.CARGO, Me.FRENTE, Me.N_FRENTE, Me.APELLIDOS, Me.NOMBRES, Me.F_INGRESO, Me.S_BASICO, Me.CONCEPTO, Me.NOMBRE_CONCEPTO, Me.CANT, Me.VQLOR, Me.DETALLE, Me.CORREO_ELECTRONICO, Me.ERRORES})
        Me.Dgv_Datos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Dgv_Datos.Location = New System.Drawing.Point(15, 114)
        Me.Dgv_Datos.Name = "Dgv_Datos"
        Me.Dgv_Datos.ReadOnly = True
        Me.Dgv_Datos.Size = New System.Drawing.Size(1142, 260)
        Me.Dgv_Datos.TabIndex = 4
        '
        'NRO1
        '
        Me.NRO1.DataPropertyName = "NRO"
        Me.NRO1.HeaderText = "NRO"
        Me.NRO1.Name = "NRO1"
        Me.NRO1.ReadOnly = True
        Me.NRO1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CEDULA
        '
        Me.CEDULA.DataPropertyName = "CEDULA"
        Me.CEDULA.HeaderText = "CEDULA"
        Me.CEDULA.Name = "CEDULA"
        Me.CEDULA.ReadOnly = True
        Me.CEDULA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CARGO
        '
        Me.CARGO.DataPropertyName = "CARGO"
        Me.CARGO.HeaderText = "CARGO"
        Me.CARGO.Name = "CARGO"
        Me.CARGO.ReadOnly = True
        Me.CARGO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FRENTE
        '
        Me.FRENTE.DataPropertyName = "FRENTE"
        Me.FRENTE.HeaderText = "FRENTE"
        Me.FRENTE.Name = "FRENTE"
        Me.FRENTE.ReadOnly = True
        Me.FRENTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'N_FRENTE
        '
        Me.N_FRENTE.DataPropertyName = "N#FRENTE"
        Me.N_FRENTE.HeaderText = "N.FRENTE"
        Me.N_FRENTE.Name = "N_FRENTE"
        Me.N_FRENTE.ReadOnly = True
        Me.N_FRENTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'APELLIDOS
        '
        Me.APELLIDOS.DataPropertyName = "APELLIDOS"
        Me.APELLIDOS.HeaderText = "APELLIDOS"
        Me.APELLIDOS.Name = "APELLIDOS"
        Me.APELLIDOS.ReadOnly = True
        Me.APELLIDOS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NOMBRES
        '
        Me.NOMBRES.DataPropertyName = "NOMBRES"
        Me.NOMBRES.HeaderText = "NOMBRES"
        Me.NOMBRES.Name = "NOMBRES"
        Me.NOMBRES.ReadOnly = True
        Me.NOMBRES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'F_INGRESO
        '
        Me.F_INGRESO.DataPropertyName = "F#INGRESO"
        Me.F_INGRESO.HeaderText = "F.INGRESO"
        Me.F_INGRESO.Name = "F_INGRESO"
        Me.F_INGRESO.ReadOnly = True
        Me.F_INGRESO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'S_BASICO
        '
        Me.S_BASICO.DataPropertyName = "S#BASICO"
        Me.S_BASICO.HeaderText = "S.BASICO"
        Me.S_BASICO.Name = "S_BASICO"
        Me.S_BASICO.ReadOnly = True
        Me.S_BASICO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CONCEPTO
        '
        Me.CONCEPTO.DataPropertyName = "CONCEPTO"
        Me.CONCEPTO.HeaderText = "CONCEPTO"
        Me.CONCEPTO.Name = "CONCEPTO"
        Me.CONCEPTO.ReadOnly = True
        Me.CONCEPTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NOMBRE_CONCEPTO
        '
        Me.NOMBRE_CONCEPTO.DataPropertyName = "NOMBRE DEL CONCEPTO"
        Me.NOMBRE_CONCEPTO.HeaderText = "NOMBRE DEL CONCEPTO"
        Me.NOMBRE_CONCEPTO.Name = "NOMBRE_CONCEPTO"
        Me.NOMBRE_CONCEPTO.ReadOnly = True
        Me.NOMBRE_CONCEPTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CANT
        '
        Me.CANT.DataPropertyName = "CANT"
        Me.CANT.HeaderText = "CANT"
        Me.CANT.Name = "CANT"
        Me.CANT.ReadOnly = True
        '
        'VQLOR
        '
        Me.VQLOR.DataPropertyName = "VALOR"
        Me.VQLOR.HeaderText = "VALOR"
        Me.VQLOR.Name = "VQLOR"
        Me.VQLOR.ReadOnly = True
        Me.VQLOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DETALLE
        '
        Me.DETALLE.DataPropertyName = "DETALLE"
        Me.DETALLE.HeaderText = "DETALLE"
        Me.DETALLE.Name = "DETALLE"
        Me.DETALLE.ReadOnly = True
        Me.DETALLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CORREO_ELECTRONICO
        '
        Me.CORREO_ELECTRONICO.DataPropertyName = "CORREO ELECTRONICO"
        Me.CORREO_ELECTRONICO.HeaderText = "CORREO ELECTRONICO"
        Me.CORREO_ELECTRONICO.Name = "CORREO_ELECTRONICO"
        Me.CORREO_ELECTRONICO.ReadOnly = True
        Me.CORREO_ELECTRONICO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ERRORES
        '
        Me.ERRORES.DataPropertyName = "ERRORES"
        Me.ERRORES.HeaderText = "ERRORES"
        Me.ERRORES.Name = "ERRORES"
        Me.ERRORES.ReadOnly = True
        Me.ERRORES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Lb_ConteoRegistros
        '
        Me.Lb_ConteoRegistros.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Lb_ConteoRegistros.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_ConteoRegistros.Location = New System.Drawing.Point(15, 91)
        Me.Lb_ConteoRegistros.Name = "Lb_ConteoRegistros"
        Me.Lb_ConteoRegistros.Size = New System.Drawing.Size(1142, 23)
        Me.Lb_ConteoRegistros.TabIndex = 5
        Me.Lb_ConteoRegistros.Text = "Cantidad de Registros: 0"
        Me.Lb_ConteoRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Pb_carga)
        Me.Panel3.Controls.Add(Me.Lb_Progreso)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(15, 15)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1142, 25)
        Me.Panel3.TabIndex = 6
        '
        'Pb_carga
        '
        Me.Pb_carga.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pb_carga.Location = New System.Drawing.Point(0, 0)
        Me.Pb_carga.Name = "Pb_carga"
        Me.Pb_carga.Size = New System.Drawing.Size(599, 25)
        Me.Pb_carga.TabIndex = 7
        '
        'Lb_Progreso
        '
        Me.Lb_Progreso.Dock = System.Windows.Forms.DockStyle.Right
        Me.Lb_Progreso.Location = New System.Drawing.Point(599, 0)
        Me.Lb_Progreso.Name = "Lb_Progreso"
        Me.Lb_Progreso.Size = New System.Drawing.Size(543, 25)
        Me.Lb_Progreso.TabIndex = 0
        Me.Lb_Progreso.Text = "Progresos"
        Me.Lb_Progreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bt_DescargarFormato
        '
        Me.Bt_DescargarFormato.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bt_DescargarFormato.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Bt_DescargarFormato.Location = New System.Drawing.Point(5, 55)
        Me.Bt_DescargarFormato.Name = "Bt_DescargarFormato"
        Me.Bt_DescargarFormato.Size = New System.Drawing.Size(1172, 28)
        Me.Bt_DescargarFormato.TabIndex = 5
        Me.Bt_DescargarFormato.Text = "Descargar Formato Ejemplo"
        Me.Bt_DescargarFormato.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "NRO"
        Me.DataGridViewTextBoxColumn18.HeaderText = "NRO"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "CODIGO"
        Me.DataGridViewTextBoxColumn19.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "CEDULA"
        Me.DataGridViewTextBoxColumn20.HeaderText = "CEDULA"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "CARGO"
        Me.DataGridViewTextBoxColumn21.HeaderText = "CARGO"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "FRENTE"
        Me.DataGridViewTextBoxColumn22.HeaderText = "FRENTE"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "N#FRENTE"
        Me.DataGridViewTextBoxColumn23.HeaderText = "N.FRENTE"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "APELLIDOS"
        Me.DataGridViewTextBoxColumn24.HeaderText = "APELLIDOS"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "NOMBRES"
        Me.DataGridViewTextBoxColumn25.HeaderText = "NOMBRES"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "F#INGRESO"
        Me.DataGridViewTextBoxColumn26.HeaderText = "F.INGRESO"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "S#BASICO"
        Me.DataGridViewTextBoxColumn27.HeaderText = "S.BASICO"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "CONCEPTO"
        Me.DataGridViewTextBoxColumn28.HeaderText = "CONCEPTO"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        Me.DataGridViewTextBoxColumn28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "NOMBRE DEL CONCEPTO"
        Me.DataGridViewTextBoxColumn29.HeaderText = "NOMBRE DEL CONCEPTO"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        Me.DataGridViewTextBoxColumn29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "CANT"
        Me.DataGridViewTextBoxColumn30.HeaderText = "CANT"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "VALOR"
        Me.DataGridViewTextBoxColumn31.HeaderText = "VALOR"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        Me.DataGridViewTextBoxColumn31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "DETALLE"
        Me.DataGridViewTextBoxColumn32.HeaderText = "DETALLE"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        Me.DataGridViewTextBoxColumn32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "CORREO ELECTRONICO"
        Me.DataGridViewTextBoxColumn33.HeaderText = "CORREO ELECTRONICO"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        Me.DataGridViewTextBoxColumn33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "ERRORES"
        Me.DataGridViewTextBoxColumn34.HeaderText = "ERRORES"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        Me.DataGridViewTextBoxColumn34.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "NRO"
        Me.DataGridViewTextBoxColumn35.HeaderText = "NRO"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "CODIGO"
        Me.DataGridViewTextBoxColumn36.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "CEDULA"
        Me.DataGridViewTextBoxColumn37.HeaderText = "CEDULA"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "CARGO"
        Me.DataGridViewTextBoxColumn38.HeaderText = "CARGO"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.DataPropertyName = "FRENTE"
        Me.DataGridViewTextBoxColumn39.HeaderText = "FRENTE"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.DataPropertyName = "N#FRENTE"
        Me.DataGridViewTextBoxColumn40.HeaderText = "N.FRENTE"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        Me.DataGridViewTextBoxColumn40.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.DataPropertyName = "APELLIDOS"
        Me.DataGridViewTextBoxColumn41.HeaderText = "APELLIDOS"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        Me.DataGridViewTextBoxColumn41.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.DataPropertyName = "NOMBRES"
        Me.DataGridViewTextBoxColumn42.HeaderText = "NOMBRES"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        Me.DataGridViewTextBoxColumn42.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn43
        '
        Me.DataGridViewTextBoxColumn43.DataPropertyName = "F#INGRESO"
        Me.DataGridViewTextBoxColumn43.HeaderText = "F.INGRESO"
        Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
        Me.DataGridViewTextBoxColumn43.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.DataPropertyName = "S#BASICO"
        Me.DataGridViewTextBoxColumn44.HeaderText = "S.BASICO"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        Me.DataGridViewTextBoxColumn44.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn45
        '
        Me.DataGridViewTextBoxColumn45.DataPropertyName = "CONCEPTO"
        Me.DataGridViewTextBoxColumn45.HeaderText = "CONCEPTO"
        Me.DataGridViewTextBoxColumn45.Name = "DataGridViewTextBoxColumn45"
        Me.DataGridViewTextBoxColumn45.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn46
        '
        Me.DataGridViewTextBoxColumn46.DataPropertyName = "NOMBRE DEL CONCEPTO"
        Me.DataGridViewTextBoxColumn46.HeaderText = "NOMBRE DEL CONCEPTO"
        Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
        Me.DataGridViewTextBoxColumn46.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn47
        '
        Me.DataGridViewTextBoxColumn47.DataPropertyName = "CANT"
        Me.DataGridViewTextBoxColumn47.HeaderText = "CANT"
        Me.DataGridViewTextBoxColumn47.Name = "DataGridViewTextBoxColumn47"
        '
        'DataGridViewTextBoxColumn48
        '
        Me.DataGridViewTextBoxColumn48.DataPropertyName = "VALOR"
        Me.DataGridViewTextBoxColumn48.HeaderText = "VALOR"
        Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
        Me.DataGridViewTextBoxColumn48.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn49
        '
        Me.DataGridViewTextBoxColumn49.DataPropertyName = "DETALLE"
        Me.DataGridViewTextBoxColumn49.HeaderText = "DETALLE"
        Me.DataGridViewTextBoxColumn49.Name = "DataGridViewTextBoxColumn49"
        Me.DataGridViewTextBoxColumn49.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn50
        '
        Me.DataGridViewTextBoxColumn50.DataPropertyName = "CORREO ELECTRONICO"
        Me.DataGridViewTextBoxColumn50.HeaderText = "CORREO ELECTRONICO"
        Me.DataGridViewTextBoxColumn50.Name = "DataGridViewTextBoxColumn50"
        Me.DataGridViewTextBoxColumn50.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn51
        '
        Me.DataGridViewTextBoxColumn51.DataPropertyName = "ERRORES"
        Me.DataGridViewTextBoxColumn51.HeaderText = "ERRORES"
        Me.DataGridViewTextBoxColumn51.Name = "DataGridViewTextBoxColumn51"
        Me.DataGridViewTextBoxColumn51.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'bgw_correos
        '
        Me.bgw_correos.WorkerReportsProgress = True
        '
        'Fr_EnviarCorreosNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 718)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Bt_DescargarFormato)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Fr_EnviarCorreosNomina"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Correos Nomina"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Dgv_CorreosEnviados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_CorreosSinEnviar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_Datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ofd_AbrirExcel As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Bt_Abrir As System.Windows.Forms.Button
    Friend WithEvents Lb_NombreArchivo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_DescargarFormato As System.Windows.Forms.Button
    Friend WithEvents Bt_EnviarCorreos As System.Windows.Forms.Button
    Friend WithEvents Sfd_GuardarExcel As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Lb_CorreosEnviados As System.Windows.Forms.Label
    Friend WithEvents Bt_ExportarNoEnviados As System.Windows.Forms.Button
    Friend WithEvents Lb_CorreosSinEnviar As System.Windows.Forms.Label
    Friend WithEvents Dgv_Datos As System.Windows.Forms.DataGridView
    Friend WithEvents Lb_ConteoRegistros As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Pb_carga As System.Windows.Forms.ProgressBar
    Friend WithEvents Lb_Progreso As System.Windows.Forms.Label
    Friend WithEvents Dgv_CorreosSinEnviar As System.Windows.Forms.DataGridView
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
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bt_ExportarEnviados As System.Windows.Forms.Button
    Friend WithEvents NRO1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEDULA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CARGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FRENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents N_FRENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APELLIDOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F_INGRESO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents S_BASICO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONCEPTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE_CONCEPTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VQLOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DETALLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CORREO_ELECTRONICO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ERRORES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn41 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn43 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn44 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn46 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn47 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn48 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn49 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn50 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn51 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dgv_CorreosEnviados As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn52 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn53 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn54 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn56 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn57 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn58 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn59 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn60 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn61 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn62 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn63 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn64 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn65 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn67 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn68 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bgw_correos As System.ComponentModel.BackgroundWorker
End Class
