<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_PlanDeOptimizacion
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.Lb_PropositoMejora = New System.Windows.Forms.Label()
        Me.Lb_ArchivoOptimizacion = New System.Windows.Forms.Label()
        Me.Lb_Adjuntos = New System.Windows.Forms.Label()
        Me.Tx_PropositoMejora = New System.Windows.Forms.TextBox()
        Me.Tx_Titulo = New System.Windows.Forms.TextBox()
        Me.Dgv_Adjuntos = New System.Windows.Forms.DataGridView()
        Me.Pn_Encabezado = New System.Windows.Forms.Panel()
        Me.Tlp_ArchivoOptimizacion = New System.Windows.Forms.TableLayoutPanel()
        Me.Bt_QuitarArchivo = New System.Windows.Forms.Button()
        Me.Bt_VerArchivo = New System.Windows.Forms.Button()
        Me.Bt_CargarArchivo = New System.Windows.Forms.Button()
        Me.Tx_Archivo = New System.Windows.Forms.TextBox()
        Me.Pn_Adjuntos = New System.Windows.Forms.Panel()
        Me.Flp_AgregarAdjunto = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_AgregarAdjunto = New System.Windows.Forms.Button()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ofd_ArchivoPDO = New System.Windows.Forms.OpenFileDialog()
        Me.Tt_Info = New System.Windows.Forms.ToolTip(Me.components)
        Me.Col_CodigoTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NombreTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NombreArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Cargar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Col_Ver = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Col_Quitar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Col_IdPlanoOptimizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Archivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdUsuarioRegistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_UsuarioRegistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdUsuarioModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_UsuarioModifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Dgv_Adjuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Encabezado.SuspendLayout()
        Me.Tlp_ArchivoOptimizacion.SuspendLayout()
        Me.Pn_Adjuntos.SuspendLayout()
        Me.Flp_AgregarAdjunto.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.AutoSize = True
        Me.Lb_Titulo.Location = New System.Drawing.Point(90, 15)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(38, 13)
        Me.Lb_Titulo.TabIndex = 0
        Me.Lb_Titulo.Text = "Título:"
        '
        'Lb_PropositoMejora
        '
        Me.Lb_PropositoMejora.AutoSize = True
        Me.Lb_PropositoMejora.Location = New System.Drawing.Point(13, 41)
        Me.Lb_PropositoMejora.Name = "Lb_PropositoMejora"
        Me.Lb_PropositoMejora.Size = New System.Drawing.Size(115, 13)
        Me.Lb_PropositoMejora.TabIndex = 2
        Me.Lb_PropositoMejora.Text = "Propósito de la Mejora:"
        '
        'Lb_ArchivoOptimizacion
        '
        Me.Lb_ArchivoOptimizacion.AutoSize = True
        Me.Lb_ArchivoOptimizacion.Location = New System.Drawing.Point(4, 87)
        Me.Lb_ArchivoOptimizacion.Name = "Lb_ArchivoOptimizacion"
        Me.Lb_ArchivoOptimizacion.Size = New System.Drawing.Size(124, 13)
        Me.Lb_ArchivoOptimizacion.TabIndex = 4
        Me.Lb_ArchivoOptimizacion.Text = "Archivo de Optimización:"
        '
        'Lb_Adjuntos
        '
        Me.Lb_Adjuntos.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Lb_Adjuntos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Adjuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Adjuntos.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Adjuntos.Name = "Lb_Adjuntos"
        Me.Lb_Adjuntos.Size = New System.Drawing.Size(622, 20)
        Me.Lb_Adjuntos.TabIndex = 0
        Me.Lb_Adjuntos.Text = "ARCHIVOS ADJUNTOS"
        Me.Lb_Adjuntos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tx_PropositoMejora
        '
        Me.Tx_PropositoMejora.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_PropositoMejora.Location = New System.Drawing.Point(131, 38)
        Me.Tx_PropositoMejora.MaxLength = 200
        Me.Tx_PropositoMejora.Multiline = True
        Me.Tx_PropositoMejora.Name = "Tx_PropositoMejora"
        Me.Tx_PropositoMejora.Size = New System.Drawing.Size(481, 40)
        Me.Tx_PropositoMejora.TabIndex = 3
        '
        'Tx_Titulo
        '
        Me.Tx_Titulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Titulo.Location = New System.Drawing.Point(131, 12)
        Me.Tx_Titulo.MaxLength = 100
        Me.Tx_Titulo.Name = "Tx_Titulo"
        Me.Tx_Titulo.Size = New System.Drawing.Size(481, 20)
        Me.Tx_Titulo.TabIndex = 1
        '
        'Dgv_Adjuntos
        '
        Me.Dgv_Adjuntos.AllowUserToAddRows = False
        Me.Dgv_Adjuntos.AllowUserToDeleteRows = False
        Me.Dgv_Adjuntos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Adjuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Adjuntos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_CodigoTipo, Me.Col_NombreTipo, Me.Col_NombreArchivo, Me.Col_FechaArchivo, Me.Col_Cargar, Me.Col_Ver, Me.Col_Quitar, Me.Col_IdPlanoOptimizacion, Me.Col_Item, Me.Col_Archivo, Me.Col_FechaRegistro, Me.Col_IdUsuarioRegistra, Me.Col_UsuarioRegistra, Me.Col_FechaModificacion, Me.Col_IdUsuarioModifica, Me.Col_UsuarioModifica})
        Me.Dgv_Adjuntos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Adjuntos.Location = New System.Drawing.Point(0, 50)
        Me.Dgv_Adjuntos.MultiSelect = False
        Me.Dgv_Adjuntos.Name = "Dgv_Adjuntos"
        Me.Dgv_Adjuntos.Size = New System.Drawing.Size(622, 241)
        Me.Dgv_Adjuntos.TabIndex = 2
        '
        'Pn_Encabezado
        '
        Me.Pn_Encabezado.Controls.Add(Me.Tlp_ArchivoOptimizacion)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_ArchivoOptimizacion)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_PropositoMejora)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_PropositoMejora)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_Titulo)
        Me.Pn_Encabezado.Controls.Add(Me.Lb_Titulo)
        Me.Pn_Encabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Encabezado.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Encabezado.Name = "Pn_Encabezado"
        Me.Pn_Encabezado.Size = New System.Drawing.Size(624, 118)
        Me.Pn_Encabezado.TabIndex = 0
        '
        'Tlp_ArchivoOptimizacion
        '
        Me.Tlp_ArchivoOptimizacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tlp_ArchivoOptimizacion.ColumnCount = 4
        Me.Tlp_ArchivoOptimizacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_ArchivoOptimizacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.Tlp_ArchivoOptimizacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.Tlp_ArchivoOptimizacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.Tlp_ArchivoOptimizacion.Controls.Add(Me.Bt_QuitarArchivo, 3, 0)
        Me.Tlp_ArchivoOptimizacion.Controls.Add(Me.Bt_VerArchivo, 2, 0)
        Me.Tlp_ArchivoOptimizacion.Controls.Add(Me.Bt_CargarArchivo, 1, 0)
        Me.Tlp_ArchivoOptimizacion.Controls.Add(Me.Tx_Archivo, 0, 0)
        Me.Tlp_ArchivoOptimizacion.Location = New System.Drawing.Point(131, 83)
        Me.Tlp_ArchivoOptimizacion.Name = "Tlp_ArchivoOptimizacion"
        Me.Tlp_ArchivoOptimizacion.RowCount = 1
        Me.Tlp_ArchivoOptimizacion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_ArchivoOptimizacion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.Tlp_ArchivoOptimizacion.Size = New System.Drawing.Size(483, 22)
        Me.Tlp_ArchivoOptimizacion.TabIndex = 5
        '
        'Bt_QuitarArchivo
        '
        Me.Bt_QuitarArchivo.Enabled = False
        Me.Bt_QuitarArchivo.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_QuitarArchivo.Location = New System.Drawing.Point(458, 0)
        Me.Bt_QuitarArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.Bt_QuitarArchivo.Name = "Bt_QuitarArchivo"
        Me.Bt_QuitarArchivo.Size = New System.Drawing.Size(24, 22)
        Me.Bt_QuitarArchivo.TabIndex = 3
        Me.Bt_QuitarArchivo.Text = "❌"
        Me.Tt_Info.SetToolTip(Me.Bt_QuitarArchivo, "Quitar archivo")
        Me.Bt_QuitarArchivo.UseVisualStyleBackColor = True
        '
        'Bt_VerArchivo
        '
        Me.Bt_VerArchivo.Enabled = False
        Me.Bt_VerArchivo.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_VerArchivo.Location = New System.Drawing.Point(434, 0)
        Me.Bt_VerArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.Bt_VerArchivo.Name = "Bt_VerArchivo"
        Me.Bt_VerArchivo.Size = New System.Drawing.Size(24, 22)
        Me.Bt_VerArchivo.TabIndex = 2
        Me.Bt_VerArchivo.Text = "👁️"
        Me.Tt_Info.SetToolTip(Me.Bt_VerArchivo, "Ver archivo")
        Me.Bt_VerArchivo.UseVisualStyleBackColor = True
        '
        'Bt_CargarArchivo
        '
        Me.Bt_CargarArchivo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_CargarArchivo.Location = New System.Drawing.Point(410, 0)
        Me.Bt_CargarArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.Bt_CargarArchivo.Name = "Bt_CargarArchivo"
        Me.Bt_CargarArchivo.Size = New System.Drawing.Size(24, 22)
        Me.Bt_CargarArchivo.TabIndex = 1
        Me.Bt_CargarArchivo.Text = "..."
        Me.Tt_Info.SetToolTip(Me.Bt_CargarArchivo, "Cargar archivo")
        Me.Bt_CargarArchivo.UseVisualStyleBackColor = True
        '
        'Tx_Archivo
        '
        Me.Tx_Archivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tx_Archivo.Enabled = False
        Me.Tx_Archivo.Location = New System.Drawing.Point(0, 1)
        Me.Tx_Archivo.Margin = New System.Windows.Forms.Padding(0, 1, 1, 0)
        Me.Tx_Archivo.Name = "Tx_Archivo"
        Me.Tx_Archivo.ReadOnly = True
        Me.Tx_Archivo.Size = New System.Drawing.Size(409, 20)
        Me.Tx_Archivo.TabIndex = 0
        Me.Tx_Archivo.TabStop = False
        '
        'Pn_Adjuntos
        '
        Me.Pn_Adjuntos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Adjuntos.Controls.Add(Me.Dgv_Adjuntos)
        Me.Pn_Adjuntos.Controls.Add(Me.Flp_AgregarAdjunto)
        Me.Pn_Adjuntos.Controls.Add(Me.Lb_Adjuntos)
        Me.Pn_Adjuntos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Adjuntos.Location = New System.Drawing.Point(0, 118)
        Me.Pn_Adjuntos.Name = "Pn_Adjuntos"
        Me.Pn_Adjuntos.Size = New System.Drawing.Size(624, 293)
        Me.Pn_Adjuntos.TabIndex = 1
        '
        'Flp_AgregarAdjunto
        '
        Me.Flp_AgregarAdjunto.Controls.Add(Me.Bt_AgregarAdjunto)
        Me.Flp_AgregarAdjunto.Dock = System.Windows.Forms.DockStyle.Top
        Me.Flp_AgregarAdjunto.Location = New System.Drawing.Point(0, 20)
        Me.Flp_AgregarAdjunto.Name = "Flp_AgregarAdjunto"
        Me.Flp_AgregarAdjunto.Size = New System.Drawing.Size(622, 30)
        Me.Flp_AgregarAdjunto.TabIndex = 1
        '
        'Bt_AgregarAdjunto
        '
        Me.Bt_AgregarAdjunto.Location = New System.Drawing.Point(3, 3)
        Me.Bt_AgregarAdjunto.Name = "Bt_AgregarAdjunto"
        Me.Bt_AgregarAdjunto.Size = New System.Drawing.Size(75, 23)
        Me.Bt_AgregarAdjunto.TabIndex = 0
        Me.Bt_AgregarAdjunto.Text = "Agregar"
        Me.Bt_AgregarAdjunto.UseVisualStyleBackColor = True
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 411)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(624, 30)
        Me.Flp_Botones.TabIndex = 2
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(546, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(465, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 300
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha Archivo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "ARCHIVO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'Ofd_ArchivoPDO
        '
        Me.Ofd_ArchivoPDO.Filter = "Libro de Excel|*.xlsx;*.xls|Todos los archivos|*.*"
        '
        'Col_CodigoTipo
        '
        Me.Col_CodigoTipo.DataPropertyName = "CODIGOTIPO"
        Me.Col_CodigoTipo.HeaderText = "CODIGOTIPO"
        Me.Col_CodigoTipo.Name = "Col_CodigoTipo"
        Me.Col_CodigoTipo.ReadOnly = True
        Me.Col_CodigoTipo.Visible = False
        '
        'Col_NombreTipo
        '
        Me.Col_NombreTipo.DataPropertyName = "NOMBRETIPO"
        Me.Col_NombreTipo.HeaderText = "Tipo"
        Me.Col_NombreTipo.Name = "Col_NombreTipo"
        Me.Col_NombreTipo.ReadOnly = True
        Me.Col_NombreTipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_NombreTipo.ToolTipText = "Tipo"
        '
        'Col_NombreArchivo
        '
        Me.Col_NombreArchivo.DataPropertyName = "NOMBREARCHIVO"
        Me.Col_NombreArchivo.HeaderText = "Nombre"
        Me.Col_NombreArchivo.Name = "Col_NombreArchivo"
        Me.Col_NombreArchivo.ReadOnly = True
        Me.Col_NombreArchivo.ToolTipText = "Nombre del archivo"
        Me.Col_NombreArchivo.Width = 300
        '
        'Col_FechaArchivo
        '
        Me.Col_FechaArchivo.DataPropertyName = "FECHAARCHIVO"
        Me.Col_FechaArchivo.HeaderText = "Fecha Archivo"
        Me.Col_FechaArchivo.Name = "Col_FechaArchivo"
        Me.Col_FechaArchivo.ToolTipText = "Fecha del archivo"
        '
        'Col_Cargar
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Col_Cargar.DefaultCellStyle = DataGridViewCellStyle4
        Me.Col_Cargar.HeaderText = "Subir"
        Me.Col_Cargar.Name = "Col_Cargar"
        Me.Col_Cargar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_Cargar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Col_Cargar.Text = "..."
        Me.Col_Cargar.ToolTipText = "Cargar archivo"
        Me.Col_Cargar.UseColumnTextForButtonValue = True
        Me.Col_Cargar.Width = 40
        '
        'Col_Ver
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Col_Ver.DefaultCellStyle = DataGridViewCellStyle5
        Me.Col_Ver.HeaderText = "Ver"
        Me.Col_Ver.Name = "Col_Ver"
        Me.Col_Ver.Text = "👁"
        Me.Col_Ver.ToolTipText = "Ver archivo"
        Me.Col_Ver.UseColumnTextForButtonValue = True
        Me.Col_Ver.Width = 40
        '
        'Col_Quitar
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Col_Quitar.DefaultCellStyle = DataGridViewCellStyle6
        Me.Col_Quitar.HeaderText = "Quitar"
        Me.Col_Quitar.Name = "Col_Quitar"
        Me.Col_Quitar.Text = "❌"
        Me.Col_Quitar.ToolTipText = "Quitar archivo"
        Me.Col_Quitar.UseColumnTextForButtonValue = True
        Me.Col_Quitar.Visible = False
        Me.Col_Quitar.Width = 40
        '
        'Col_IdPlanoOptimizacion
        '
        Me.Col_IdPlanoOptimizacion.DataPropertyName = "IDPLANOPTIMIZACION"
        Me.Col_IdPlanoOptimizacion.HeaderText = "IDPLANOPTIMIZACION"
        Me.Col_IdPlanoOptimizacion.Name = "Col_IdPlanoOptimizacion"
        Me.Col_IdPlanoOptimizacion.ReadOnly = True
        Me.Col_IdPlanoOptimizacion.Visible = False
        '
        'Col_Item
        '
        Me.Col_Item.DataPropertyName = "ITEM"
        Me.Col_Item.HeaderText = "ITEM"
        Me.Col_Item.Name = "Col_Item"
        Me.Col_Item.ReadOnly = True
        Me.Col_Item.Visible = False
        '
        'Col_Archivo
        '
        Me.Col_Archivo.DataPropertyName = "ARCHIVOADJUNTO"
        Me.Col_Archivo.HeaderText = "ARCHIVOADJUNTO"
        Me.Col_Archivo.Name = "Col_Archivo"
        Me.Col_Archivo.ReadOnly = True
        Me.Col_Archivo.Visible = False
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
        Me.Col_FechaModificacion.ReadOnly = True
        Me.Col_FechaModificacion.Visible = False
        '
        'Col_IdUsuarioModifica
        '
        Me.Col_IdUsuarioModifica.DataPropertyName = "IDUSUARIOMODIFICA"
        Me.Col_IdUsuarioModifica.HeaderText = "IDUSUARIOMODIFICA"
        Me.Col_IdUsuarioModifica.Name = "Col_IdUsuarioModifica"
        Me.Col_IdUsuarioModifica.ReadOnly = True
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
        'Fr_PlanDeOptimizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 441)
        Me.Controls.Add(Me.Pn_Adjuntos)
        Me.Controls.Add(Me.Pn_Encabezado)
        Me.Controls.Add(Me.Flp_Botones)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_PlanDeOptimizacion"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionar Plan de Optimización"
        CType(Me.Dgv_Adjuntos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Encabezado.ResumeLayout(False)
        Me.Pn_Encabezado.PerformLayout()
        Me.Tlp_ArchivoOptimizacion.ResumeLayout(False)
        Me.Tlp_ArchivoOptimizacion.PerformLayout()
        Me.Pn_Adjuntos.ResumeLayout(False)
        Me.Flp_AgregarAdjunto.ResumeLayout(False)
        Me.Flp_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lb_Titulo As System.Windows.Forms.Label
    Friend WithEvents Lb_PropositoMejora As System.Windows.Forms.Label
    Friend WithEvents Lb_ArchivoOptimizacion As System.Windows.Forms.Label
    Friend WithEvents Lb_Adjuntos As System.Windows.Forms.Label
    Friend WithEvents Tx_PropositoMejora As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Titulo As System.Windows.Forms.TextBox
    Friend WithEvents Dgv_Adjuntos As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Encabezado As System.Windows.Forms.Panel
    Friend WithEvents Pn_Adjuntos As System.Windows.Forms.Panel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Bt_AgregarAdjunto As System.Windows.Forms.Button
    Friend WithEvents Flp_AgregarAdjunto As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Tlp_ArchivoOptimizacion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Bt_QuitarArchivo As System.Windows.Forms.Button
    Friend WithEvents Bt_VerArchivo As System.Windows.Forms.Button
    Friend WithEvents Bt_CargarArchivo As System.Windows.Forms.Button
    Friend WithEvents Tx_Archivo As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ofd_ArchivoPDO As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Tt_Info As System.Windows.Forms.ToolTip
    Friend WithEvents Col_CodigoTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NombreTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NombreArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Cargar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Col_Ver As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Col_Quitar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Col_IdPlanoOptimizacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Archivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdUsuarioRegistra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_UsuarioRegistra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_FechaModificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdUsuarioModifica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_UsuarioModifica As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
