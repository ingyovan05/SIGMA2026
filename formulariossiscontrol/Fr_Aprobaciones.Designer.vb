<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Aprobaciones
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
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_CódigoArtículo = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Pn_Datos = New System.Windows.Forms.Panel()
        Me.Tc_Datos = New System.Windows.Forms.TabControl()
        Me.Tp_Encabezado = New System.Windows.Forms.TabPage()
        Me.Tp_Requisición = New System.Windows.Forms.TabPage()
        Me.Tp_Compra = New System.Windows.Forms.TabPage()
        Me.Tp_OrdenServicio = New System.Windows.Forms.TabPage()
        Me.Lb_Fecha = New System.Windows.Forms.Label()
        Me.Dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Lb_Subgerencia = New System.Windows.Forms.Label()
        Me.Cb_Subgerencia = New System.Windows.Forms.ComboBox()
        Me.Lb_Funcionario = New System.Windows.Forms.Label()
        Me.Lb_Descripcion = New System.Windows.Forms.Label()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tx_Dirección = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cb_RolProyecto = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Dgv_ItemRequisión = New System.Windows.Forms.DataGridView()
        Me.Dgv_Compras = New System.Windows.Forms.DataGridView()
        Me.Dgv_OrdenesServicio = New System.Windows.Forms.DataGridView()
        Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Cu_AsociarPersonaBodega2 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaBodega3 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_BuscarPersonaFirma = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_BuscarPersonaElabora = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_CiudadDirección = New FormulariosClasesBase.Cu_Ciudad()
        Me.Cu_BuscarPersonaFuncionario = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cu_AsociarPersonaBodega1 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Panel1.SuspendLayout()
        Me.Pn_Datos.SuspendLayout()
        Me.Tc_Datos.SuspendLayout()
        Me.Tp_Encabezado.SuspendLayout()
        Me.Tp_Requisición.SuspendLayout()
        Me.Tp_Compra.SuspendLayout()
        Me.Tp_OrdenServicio.SuspendLayout()
        CType(Me.Dgv_ItemRequisión, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_Compras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_OrdenesServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Titulo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_Titulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(1002, 36)
        Me.Lb_Titulo.TabIndex = 15
        Me.Lb_Titulo.Text = "AUTORIZACIÓN"
        Me.Lb_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lb_CódigoArtículo)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 454)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1002, 36)
        Me.Panel1.TabIndex = 16
        '
        'Lb_CódigoArtículo
        '
        Me.Lb_CódigoArtículo.AutoSize = True
        Me.Lb_CódigoArtículo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CódigoArtículo.ForeColor = System.Drawing.Color.Red
        Me.Lb_CódigoArtículo.Location = New System.Drawing.Point(15, 10)
        Me.Lb_CódigoArtículo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_CódigoArtículo.Name = "Lb_CódigoArtículo"
        Me.Lb_CódigoArtículo.Size = New System.Drawing.Size(66, 17)
        Me.Lb_CódigoArtículo.TabIndex = 2
        Me.Lb_CódigoArtículo.Text = "Label13"
        Me.Lb_CódigoArtículo.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(781, 5)
        Me.Bt_Guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(100, 27)
        Me.Bt_Guardar.TabIndex = 15
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(889, 4)
        Me.Bt_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Bt_Cancelar.TabIndex = 16
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Pn_Datos
        '
        Me.Pn_Datos.Controls.Add(Me.Tc_Datos)
        Me.Pn_Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Datos.Location = New System.Drawing.Point(0, 36)
        Me.Pn_Datos.Name = "Pn_Datos"
        Me.Pn_Datos.Size = New System.Drawing.Size(1002, 418)
        Me.Pn_Datos.TabIndex = 17
        '
        'Tc_Datos
        '
        Me.Tc_Datos.Controls.Add(Me.Tp_Encabezado)
        Me.Tc_Datos.Controls.Add(Me.Tp_Requisición)
        Me.Tc_Datos.Controls.Add(Me.Tp_Compra)
        Me.Tc_Datos.Controls.Add(Me.Tp_OrdenServicio)
        Me.Tc_Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tc_Datos.Location = New System.Drawing.Point(0, 0)
        Me.Tc_Datos.Name = "Tc_Datos"
        Me.Tc_Datos.SelectedIndex = 0
        Me.Tc_Datos.Size = New System.Drawing.Size(1002, 418)
        Me.Tc_Datos.TabIndex = 0
        '
        'Tp_Encabezado
        '
        Me.Tp_Encabezado.Controls.Add(Me.Cb_RolProyecto)
        Me.Tp_Encabezado.Controls.Add(Me.Label35)
        Me.Tp_Encabezado.Controls.Add(Me.Cu_CentroCosto1)
        Me.Tp_Encabezado.Controls.Add(Me.Cu_AsociarPersonaBodega2)
        Me.Tp_Encabezado.Controls.Add(Me.Cu_AsociarPersonaBodega3)
        Me.Tp_Encabezado.Controls.Add(Me.Cu_BuscarPersonaFirma)
        Me.Tp_Encabezado.Controls.Add(Me.Cu_BuscarPersonaElabora)
        Me.Tp_Encabezado.Controls.Add(Me.Label8)
        Me.Tp_Encabezado.Controls.Add(Me.Label7)
        Me.Tp_Encabezado.Controls.Add(Me.Label5)
        Me.Tp_Encabezado.Controls.Add(Me.TextBox2)
        Me.Tp_Encabezado.Controls.Add(Me.Label3)
        Me.Tp_Encabezado.Controls.Add(Me.TextBox1)
        Me.Tp_Encabezado.Controls.Add(Me.DateTimePicker1)
        Me.Tp_Encabezado.Controls.Add(Me.Label2)
        Me.Tp_Encabezado.Controls.Add(Me.Label1)
        Me.Tp_Encabezado.Controls.Add(Me.Label4)
        Me.Tp_Encabezado.Controls.Add(Me.Cu_CiudadDirección)
        Me.Tp_Encabezado.Controls.Add(Me.Label6)
        Me.Tp_Encabezado.Controls.Add(Me.Tx_Dirección)
        Me.Tp_Encabezado.Controls.Add(Me.Lb_Fecha)
        Me.Tp_Encabezado.Controls.Add(Me.Dtp_Fecha)
        Me.Tp_Encabezado.Controls.Add(Me.Lb_Subgerencia)
        Me.Tp_Encabezado.Controls.Add(Me.Cb_Subgerencia)
        Me.Tp_Encabezado.Controls.Add(Me.Lb_Funcionario)
        Me.Tp_Encabezado.Controls.Add(Me.Cu_BuscarPersonaFuncionario)
        Me.Tp_Encabezado.Controls.Add(Me.Cu_AsociarPersonaBodega1)
        Me.Tp_Encabezado.Controls.Add(Me.Lb_Descripcion)
        Me.Tp_Encabezado.Controls.Add(Me.Tx_Descripcion)
        Me.Tp_Encabezado.Location = New System.Drawing.Point(4, 25)
        Me.Tp_Encabezado.Name = "Tp_Encabezado"
        Me.Tp_Encabezado.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_Encabezado.Size = New System.Drawing.Size(994, 389)
        Me.Tp_Encabezado.TabIndex = 0
        Me.Tp_Encabezado.Text = "Encabezado"
        Me.Tp_Encabezado.UseVisualStyleBackColor = True
        '
        'Tp_Requisición
        '
        Me.Tp_Requisición.Controls.Add(Me.Dgv_ItemRequisión)
        Me.Tp_Requisición.Location = New System.Drawing.Point(4, 25)
        Me.Tp_Requisición.Name = "Tp_Requisición"
        Me.Tp_Requisición.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_Requisición.Size = New System.Drawing.Size(994, 389)
        Me.Tp_Requisición.TabIndex = 1
        Me.Tp_Requisición.Text = "Requisición"
        Me.Tp_Requisición.UseVisualStyleBackColor = True
        '
        'Tp_Compra
        '
        Me.Tp_Compra.Controls.Add(Me.Dgv_Compras)
        Me.Tp_Compra.Location = New System.Drawing.Point(4, 25)
        Me.Tp_Compra.Name = "Tp_Compra"
        Me.Tp_Compra.Size = New System.Drawing.Size(994, 389)
        Me.Tp_Compra.TabIndex = 2
        Me.Tp_Compra.Text = "Compra"
        Me.Tp_Compra.UseVisualStyleBackColor = True
        '
        'Tp_OrdenServicio
        '
        Me.Tp_OrdenServicio.Controls.Add(Me.Dgv_OrdenesServicio)
        Me.Tp_OrdenServicio.Location = New System.Drawing.Point(4, 25)
        Me.Tp_OrdenServicio.Name = "Tp_OrdenServicio"
        Me.Tp_OrdenServicio.Size = New System.Drawing.Size(994, 389)
        Me.Tp_OrdenServicio.TabIndex = 3
        Me.Tp_OrdenServicio.Text = "Orden Servicio"
        Me.Tp_OrdenServicio.UseVisualStyleBackColor = True
        '
        'Lb_Fecha
        '
        Me.Lb_Fecha.AutoSize = True
        Me.Lb_Fecha.Location = New System.Drawing.Point(74, 10)
        Me.Lb_Fecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_Fecha.Name = "Lb_Fecha"
        Me.Lb_Fecha.Size = New System.Drawing.Size(51, 17)
        Me.Lb_Fecha.TabIndex = 24
        Me.Lb_Fecha.Text = "Fecha:"
        '
        'Dtp_Fecha
        '
        Me.Dtp_Fecha.CustomFormat = ""
        Me.Dtp_Fecha.Location = New System.Drawing.Point(128, 7)
        Me.Dtp_Fecha.Margin = New System.Windows.Forms.Padding(4)
        Me.Dtp_Fecha.Name = "Dtp_Fecha"
        Me.Dtp_Fecha.Size = New System.Drawing.Size(267, 22)
        Me.Dtp_Fecha.TabIndex = 25
        '
        'Lb_Subgerencia
        '
        Me.Lb_Subgerencia.AutoSize = True
        Me.Lb_Subgerencia.Location = New System.Drawing.Point(56, 36)
        Me.Lb_Subgerencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_Subgerencia.Name = "Lb_Subgerencia"
        Me.Lb_Subgerencia.Size = New System.Drawing.Size(70, 17)
        Me.Lb_Subgerencia.TabIndex = 29
        Me.Lb_Subgerencia.Text = "Gerencia:"
        '
        'Cb_Subgerencia
        '
        Me.Cb_Subgerencia.DisplayMember = "NOMBREGERENCIA"
        Me.Cb_Subgerencia.FormattingEnabled = True
        Me.Cb_Subgerencia.Location = New System.Drawing.Point(128, 33)
        Me.Cb_Subgerencia.Margin = New System.Windows.Forms.Padding(4)
        Me.Cb_Subgerencia.Name = "Cb_Subgerencia"
        Me.Cb_Subgerencia.Size = New System.Drawing.Size(523, 24)
        Me.Cb_Subgerencia.TabIndex = 30
        Me.Cb_Subgerencia.ValueMember = "IDGERENCIA"
        '
        'Lb_Funcionario
        '
        Me.Lb_Funcionario.AutoSize = True
        Me.Lb_Funcionario.Location = New System.Drawing.Point(60, 67)
        Me.Lb_Funcionario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_Funcionario.Name = "Lb_Funcionario"
        Me.Lb_Funcionario.Size = New System.Drawing.Size(64, 17)
        Me.Lb_Funcionario.TabIndex = 31
        Me.Lb_Funcionario.Text = "Autoriza:"
        '
        'Lb_Descripcion
        '
        Me.Lb_Descripcion.AutoSize = True
        Me.Lb_Descripcion.Location = New System.Drawing.Point(68, 155)
        Me.Lb_Descripcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_Descripcion.Name = "Lb_Descripcion"
        Me.Lb_Descripcion.Size = New System.Drawing.Size(56, 17)
        Me.Lb_Descripcion.TabIndex = 34
        Me.Lb_Descripcion.Text = "Asunto:"
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Location = New System.Drawing.Point(128, 152)
        Me.Tx_Descripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.Tx_Descripcion.MaxLength = 80
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(857, 48)
        Me.Tx_Descripcion.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 98)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 17)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Dirección Envío:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 124)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 17)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Ciudad Envío:"
        '
        'Tx_Dirección
        '
        Me.Tx_Dirección.Location = New System.Drawing.Point(128, 95)
        Me.Tx_Dirección.Margin = New System.Windows.Forms.Padding(4)
        Me.Tx_Dirección.MaxLength = 100
        Me.Tx_Dirección.Name = "Tx_Dirección"
        Me.Tx_Dirección.Size = New System.Drawing.Size(609, 22)
        Me.Tx_Dirección.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(742, 67)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 17)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "* Que persona decide segun proceso"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(409, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 17)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Hora:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = ""
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker1.Location = New System.Drawing.Point(455, 7)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(125, 22)
        Me.DateTimePicker1.TabIndex = 42
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 209)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 17)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Con Copia A:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(128, 206)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.MaxLength = 100
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(609, 22)
        Me.TextBox1.TabIndex = 43
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(60, 239)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Mensaje:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(128, 236)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.MaxLength = 80
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(857, 48)
        Me.TextBox2.TabIndex = 46
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 328)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 17)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Solicitado por:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 298)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Elaborado por:"
        '
        'Cb_RolProyecto
        '
        Me.Cb_RolProyecto.DisplayMember = "NOMBRETIPOROLBASE"
        Me.Cb_RolProyecto.FormattingEnabled = True
        Me.Cb_RolProyecto.Location = New System.Drawing.Point(128, 353)
        Me.Cb_RolProyecto.Margin = New System.Windows.Forms.Padding(4)
        Me.Cb_RolProyecto.Name = "Cb_RolProyecto"
        Me.Cb_RolProyecto.Size = New System.Drawing.Size(458, 24)
        Me.Cb_RolProyecto.TabIndex = 55
        Me.Cb_RolProyecto.ValueMember = "CODIGOTIPOROLBASE"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(21, 356)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(104, 17)
        Me.Label35.TabIndex = 54
        Me.Label35.Text = "Rol en la Base:"
        '
        'Dgv_ItemRequisión
        '
        Me.Dgv_ItemRequisión.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ItemRequisión.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ItemRequisión.Location = New System.Drawing.Point(3, 3)
        Me.Dgv_ItemRequisión.Name = "Dgv_ItemRequisión"
        Me.Dgv_ItemRequisión.RowTemplate.Height = 24
        Me.Dgv_ItemRequisión.Size = New System.Drawing.Size(988, 383)
        Me.Dgv_ItemRequisión.TabIndex = 0
        '
        'Dgv_Compras
        '
        Me.Dgv_Compras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Compras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Compras.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Compras.Name = "Dgv_Compras"
        Me.Dgv_Compras.RowTemplate.Height = 24
        Me.Dgv_Compras.Size = New System.Drawing.Size(994, 389)
        Me.Dgv_Compras.TabIndex = 1
        '
        'Dgv_OrdenesServicio
        '
        Me.Dgv_OrdenesServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_OrdenesServicio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_OrdenesServicio.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_OrdenesServicio.Name = "Dgv_OrdenesServicio"
        Me.Dgv_OrdenesServicio.RowTemplate.Height = 24
        Me.Dgv_OrdenesServicio.Size = New System.Drawing.Size(994, 389)
        Me.Dgv_OrdenesServicio.TabIndex = 1
        '
        'Cu_CentroCosto1
        '
        Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto1.Location = New System.Drawing.Point(594, 293)
        Me.Cu_CentroCosto1.Margin = New System.Windows.Forms.Padding(5)
        Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
        Me.Cu_CentroCosto1.Size = New System.Drawing.Size(265, 46)
        Me.Cu_CentroCosto1.TabIndex = 53
        '
        'Cu_AsociarPersonaBodega2
        '
        Me.Cu_AsociarPersonaBodega2.componenteasociado = "Cu_BuscarPersonaFirma"
        Me.Cu_AsociarPersonaBodega2.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega2.Location = New System.Drawing.Point(550, 323)
        Me.Cu_AsociarPersonaBodega2.Margin = New System.Windows.Forms.Padding(5)
        Me.Cu_AsociarPersonaBodega2.Name = "Cu_AsociarPersonaBodega2"
        Me.Cu_AsociarPersonaBodega2.Size = New System.Drawing.Size(36, 28)
        Me.Cu_AsociarPersonaBodega2.TabIndex = 50
        Me.Cu_AsociarPersonaBodega2.TipoAsociacion = "DEP"
        Me.Cu_AsociarPersonaBodega2.TipoBúsqueda = "P"
        '
        'Cu_AsociarPersonaBodega3
        '
        Me.Cu_AsociarPersonaBodega3.componenteasociado = "Cu_BuscarPersonaElabora"
        Me.Cu_AsociarPersonaBodega3.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega3.Location = New System.Drawing.Point(550, 293)
        Me.Cu_AsociarPersonaBodega3.Margin = New System.Windows.Forms.Padding(5)
        Me.Cu_AsociarPersonaBodega3.Name = "Cu_AsociarPersonaBodega3"
        Me.Cu_AsociarPersonaBodega3.Size = New System.Drawing.Size(36, 28)
        Me.Cu_AsociarPersonaBodega3.TabIndex = 48
        Me.Cu_AsociarPersonaBodega3.TipoAsociacion = "DEP"
        Me.Cu_AsociarPersonaBodega3.TipoBúsqueda = "P"
        '
        'Cu_BuscarPersonaFirma
        '
        Me.Cu_BuscarPersonaFirma.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaFirma.Location = New System.Drawing.Point(128, 323)
        Me.Cu_BuscarPersonaFirma.Margin = New System.Windows.Forms.Padding(5)
        Me.Cu_BuscarPersonaFirma.Name = "Cu_BuscarPersonaFirma"
        Me.Cu_BuscarPersonaFirma.Size = New System.Drawing.Size(415, 28)
        Me.Cu_BuscarPersonaFirma.TabIndex = 49
        Me.Cu_BuscarPersonaFirma.Tipo = "PADEP"
        Me.Cu_BuscarPersonaFirma.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_BuscarPersonaElabora
        '
        Me.Cu_BuscarPersonaElabora.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaElabora.Location = New System.Drawing.Point(128, 293)
        Me.Cu_BuscarPersonaElabora.Margin = New System.Windows.Forms.Padding(5)
        Me.Cu_BuscarPersonaElabora.Name = "Cu_BuscarPersonaElabora"
        Me.Cu_BuscarPersonaElabora.Size = New System.Drawing.Size(415, 28)
        Me.Cu_BuscarPersonaElabora.TabIndex = 47
        Me.Cu_BuscarPersonaElabora.Tipo = "PADEP"
        Me.Cu_BuscarPersonaElabora.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_CiudadDirección
        '
        Me.Cu_CiudadDirección.Location = New System.Drawing.Point(125, 120)
        Me.Cu_CiudadDirección.Margin = New System.Windows.Forms.Padding(5)
        Me.Cu_CiudadDirección.Name = "Cu_CiudadDirección"
        Me.Cu_CiudadDirección.Size = New System.Drawing.Size(526, 28)
        Me.Cu_CiudadDirección.TabIndex = 37
        '
        'Cu_BuscarPersonaFuncionario
        '
        Me.Cu_BuscarPersonaFuncionario.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaFuncionario.Location = New System.Drawing.Point(125, 63)
        Me.Cu_BuscarPersonaFuncionario.Margin = New System.Windows.Forms.Padding(5)
        Me.Cu_BuscarPersonaFuncionario.Name = "Cu_BuscarPersonaFuncionario"
        Me.Cu_BuscarPersonaFuncionario.Size = New System.Drawing.Size(573, 28)
        Me.Cu_BuscarPersonaFuncionario.TabIndex = 32
        Me.Cu_BuscarPersonaFuncionario.Tipo = "PADEP"
        Me.Cu_BuscarPersonaFuncionario.valorcajatexto = "IDENTIFICACION"
        '
        'Cu_AsociarPersonaBodega1
        '
        Me.Cu_AsociarPersonaBodega1.componenteasociado = "Cu_BuscarPersonaFuncionario"
        Me.Cu_AsociarPersonaBodega1.CrearUsuario = False
        Me.Cu_AsociarPersonaBodega1.Location = New System.Drawing.Point(698, 64)
        Me.Cu_AsociarPersonaBodega1.Margin = New System.Windows.Forms.Padding(5)
        Me.Cu_AsociarPersonaBodega1.Name = "Cu_AsociarPersonaBodega1"
        Me.Cu_AsociarPersonaBodega1.Size = New System.Drawing.Size(39, 28)
        Me.Cu_AsociarPersonaBodega1.TabIndex = 33
        Me.Cu_AsociarPersonaBodega1.TipoAsociacion = "DEP"
        Me.Cu_AsociarPersonaBodega1.TipoBúsqueda = "P"
        '
        'Fr_Aprobaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 490)
        Me.Controls.Add(Me.Pn_Datos)
        Me.Controls.Add(Me.Lb_Titulo)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Fr_Aprobaciones"
        Me.Text = "Aprobaciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Pn_Datos.ResumeLayout(False)
        Me.Tc_Datos.ResumeLayout(False)
        Me.Tp_Encabezado.ResumeLayout(False)
        Me.Tp_Encabezado.PerformLayout()
        Me.Tp_Requisición.ResumeLayout(False)
        Me.Tp_Compra.ResumeLayout(False)
        Me.Tp_OrdenServicio.ResumeLayout(False)
        CType(Me.Dgv_ItemRequisión, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_Compras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_OrdenesServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Lb_Titulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Lb_CódigoArtículo As System.Windows.Forms.Label
    Public WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Pn_Datos As System.Windows.Forms.Panel
    Friend WithEvents Tc_Datos As System.Windows.Forms.TabControl
    Friend WithEvents Tp_Encabezado As System.Windows.Forms.TabPage
    Friend WithEvents Tp_Requisición As System.Windows.Forms.TabPage
    Friend WithEvents Tp_Compra As System.Windows.Forms.TabPage
    Friend WithEvents Tp_OrdenServicio As System.Windows.Forms.TabPage
    Friend WithEvents Lb_Fecha As System.Windows.Forms.Label
    Friend WithEvents Dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_Subgerencia As System.Windows.Forms.Label
    Friend WithEvents Cb_Subgerencia As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Funcionario As System.Windows.Forms.Label
    Friend WithEvents Cu_BuscarPersonaFuncionario As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_AsociarPersonaBodega1 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Lb_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cu_CiudadDirección As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Tx_Dirección As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
    Friend WithEvents Cu_AsociarPersonaBodega2 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaBodega3 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_BuscarPersonaFirma As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cu_BuscarPersonaElabora As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cb_RolProyecto As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Dgv_ItemRequisión As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv_Compras As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv_OrdenesServicio As System.Windows.Forms.DataGridView
End Class
