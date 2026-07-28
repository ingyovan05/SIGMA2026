<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Informe
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pn_Formulario = New System.Windows.Forms.Panel()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Dgv_Informe = New System.Windows.Forms.DataGridView()
        Me.Pn_Comandos = New System.Windows.Forms.Panel()
        Me.Gb_Descripción = New System.Windows.Forms.GroupBox()
        Me.Ck_VerColumnasInforme = New System.Windows.Forms.CheckBox()
        Me.Lb_TextoTipo = New System.Windows.Forms.Label()
        Me.Cb_TipoConsulta = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoDescripcion = New System.Windows.Forms.Label()
        Me.ComboBox_Consulta = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoFechaInicial = New System.Windows.Forms.Label()
        Me.Dtp_FechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Lb_TextoFechaFinal = New System.Windows.Forms.Label()
        Me.Dtp_FechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Lb_TextoProveedor = New System.Windows.Forms.Label()
        Me.Tx_Proveedor = New System.Windows.Forms.TextBox()
        Me.Cu_CentroCosto1 = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Button_Cargar = New System.Windows.Forms.Button()
        Me.Cu_Fecha1 = New Clasesbase.Cu_Fecha()
        Me.Lb_Titulo_Informe = New System.Windows.Forms.Label()
        Me.Pn_Formulario.SuspendLayout()
        CType(Me.Dgv_Informe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Comandos.SuspendLayout()
        Me.Gb_Descripción.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Formulario
        '
        Me.Pn_Formulario.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Pn_Formulario.Controls.Add(Me.ReportViewer1)
        Me.Pn_Formulario.Controls.Add(Me.Dgv_Informe)
        Me.Pn_Formulario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Formulario.Location = New System.Drawing.Point(0, 186)
        Me.Pn_Formulario.Name = "Pn_Formulario"
        Me.Pn_Formulario.Size = New System.Drawing.Size(1235, 261)
        Me.Pn_Formulario.TabIndex = 2
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.ReportViewer1.Size = New System.Drawing.Size(1235, 261)
        Me.ReportViewer1.TabIndex = 1
        '
        'Dgv_Informe
        '
        Me.Dgv_Informe.AllowUserToAddRows = False
        Me.Dgv_Informe.AllowUserToDeleteRows = False
        Me.Dgv_Informe.AllowUserToOrderColumns = True
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.Dgv_Informe.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_Informe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_Informe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Informe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Informe.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Informe.Name = "Dgv_Informe"
        Me.Dgv_Informe.ReadOnly = True
        Me.Dgv_Informe.Size = New System.Drawing.Size(1235, 261)
        Me.Dgv_Informe.TabIndex = 0
        '
        'Pn_Comandos
        '
        Me.Pn_Comandos.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Pn_Comandos.Controls.Add(Me.Gb_Descripción)
        Me.Pn_Comandos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Comandos.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Comandos.Name = "Pn_Comandos"
        Me.Pn_Comandos.Size = New System.Drawing.Size(1235, 161)
        Me.Pn_Comandos.TabIndex = 0
        '
        'Gb_Descripción
        '
        Me.Gb_Descripción.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Gb_Descripción.Controls.Add(Me.Ck_VerColumnasInforme)
        Me.Gb_Descripción.Controls.Add(Me.Lb_TextoTipo)
        Me.Gb_Descripción.Controls.Add(Me.Cb_TipoConsulta)
        Me.Gb_Descripción.Controls.Add(Me.Lb_TextoDescripcion)
        Me.Gb_Descripción.Controls.Add(Me.ComboBox_Consulta)
        Me.Gb_Descripción.Controls.Add(Me.Lb_TextoFechaInicial)
        Me.Gb_Descripción.Controls.Add(Me.Dtp_FechaInicial)
        Me.Gb_Descripción.Controls.Add(Me.Lb_TextoFechaFinal)
        Me.Gb_Descripción.Controls.Add(Me.Dtp_FechaFinal)
        Me.Gb_Descripción.Controls.Add(Me.Lb_TextoProveedor)
        Me.Gb_Descripción.Controls.Add(Me.Tx_Proveedor)
        Me.Gb_Descripción.Controls.Add(Me.Cu_CentroCosto1)
        Me.Gb_Descripción.Controls.Add(Me.Button_Cargar)
        Me.Gb_Descripción.Controls.Add(Me.Cu_Fecha1)
        Me.Gb_Descripción.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gb_Descripción.Location = New System.Drawing.Point(4, 3)
        Me.Gb_Descripción.Name = "Gb_Descripción"
        Me.Gb_Descripción.Size = New System.Drawing.Size(983, 155)
        Me.Gb_Descripción.TabIndex = 1
        Me.Gb_Descripción.TabStop = False
        Me.Gb_Descripción.Text = "Informe"
        '
        'Ck_VerColumnasInforme
        '
        Me.Ck_VerColumnasInforme.AutoSize = True
        Me.Ck_VerColumnasInforme.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_VerColumnasInforme.Location = New System.Drawing.Point(800, 20)
        Me.Ck_VerColumnasInforme.Name = "Ck_VerColumnasInforme"
        Me.Ck_VerColumnasInforme.Size = New System.Drawing.Size(178, 20)
        Me.Ck_VerColumnasInforme.TabIndex = 16
        Me.Ck_VerColumnasInforme.Text = "Ver columnas del informe"
        Me.Ck_VerColumnasInforme.UseVisualStyleBackColor = True
        '
        'Lb_TextoTipo
        '
        Me.Lb_TextoTipo.AutoSize = True
        Me.Lb_TextoTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoTipo.Location = New System.Drawing.Point(74, 21)
        Me.Lb_TextoTipo.Name = "Lb_TextoTipo"
        Me.Lb_TextoTipo.Size = New System.Drawing.Size(39, 16)
        Me.Lb_TextoTipo.TabIndex = 0
        Me.Lb_TextoTipo.Text = "Tipo:"
        '
        'Cb_TipoConsulta
        '
        Me.Cb_TipoConsulta.DisplayMember = "NOMBRETIPOCONSULTA"
        Me.Cb_TipoConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_TipoConsulta.FormattingEnabled = True
        Me.Cb_TipoConsulta.Location = New System.Drawing.Point(116, 18)
        Me.Cb_TipoConsulta.Name = "Cb_TipoConsulta"
        Me.Cb_TipoConsulta.Size = New System.Drawing.Size(220, 24)
        Me.Cb_TipoConsulta.TabIndex = 1
        Me.Cb_TipoConsulta.ValueMember = "CODIGOTIPOCONSULTA"
        '
        'Lb_TextoDescripcion
        '
        Me.Lb_TextoDescripcion.AutoSize = True
        Me.Lb_TextoDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoDescripcion.Location = New System.Drawing.Point(30, 52)
        Me.Lb_TextoDescripcion.Name = "Lb_TextoDescripcion"
        Me.Lb_TextoDescripcion.Size = New System.Drawing.Size(83, 16)
        Me.Lb_TextoDescripcion.TabIndex = 2
        Me.Lb_TextoDescripcion.Text = "Descripción:"
        '
        'ComboBox_Consulta
        '
        Me.ComboBox_Consulta.DisplayMember = "NOMBRECONSULTA"
        Me.ComboBox_Consulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Consulta.FormattingEnabled = True
        Me.ComboBox_Consulta.Location = New System.Drawing.Point(116, 49)
        Me.ComboBox_Consulta.Name = "ComboBox_Consulta"
        Me.ComboBox_Consulta.Size = New System.Drawing.Size(861, 24)
        Me.ComboBox_Consulta.TabIndex = 3
        Me.ComboBox_Consulta.ValueMember = "CONSULTA"
        '
        'Lb_TextoFechaInicial
        '
        Me.Lb_TextoFechaInicial.AutoSize = True
        Me.Lb_TextoFechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoFechaInicial.Location = New System.Drawing.Point(27, 85)
        Me.Lb_TextoFechaInicial.Name = "Lb_TextoFechaInicial"
        Me.Lb_TextoFechaInicial.Size = New System.Drawing.Size(86, 16)
        Me.Lb_TextoFechaInicial.TabIndex = 4
        Me.Lb_TextoFechaInicial.Text = "Fecha Inicial:"
        '
        'Dtp_FechaInicial
        '
        Me.Dtp_FechaInicial.Enabled = False
        Me.Dtp_FechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_FechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaInicial.Location = New System.Drawing.Point(116, 82)
        Me.Dtp_FechaInicial.Name = "Dtp_FechaInicial"
        Me.Dtp_FechaInicial.Size = New System.Drawing.Size(110, 22)
        Me.Dtp_FechaInicial.TabIndex = 5
        '
        'Lb_TextoFechaFinal
        '
        Me.Lb_TextoFechaFinal.AutoSize = True
        Me.Lb_TextoFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoFechaFinal.Location = New System.Drawing.Point(238, 85)
        Me.Lb_TextoFechaFinal.Name = "Lb_TextoFechaFinal"
        Me.Lb_TextoFechaFinal.Size = New System.Drawing.Size(81, 16)
        Me.Lb_TextoFechaFinal.TabIndex = 6
        Me.Lb_TextoFechaFinal.Text = "Fecha Final:"
        '
        'Dtp_FechaFinal
        '
        Me.Dtp_FechaFinal.Enabled = False
        Me.Dtp_FechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_FechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaFinal.Location = New System.Drawing.Point(322, 82)
        Me.Dtp_FechaFinal.Name = "Dtp_FechaFinal"
        Me.Dtp_FechaFinal.Size = New System.Drawing.Size(99, 22)
        Me.Dtp_FechaFinal.TabIndex = 7
        '
        'Lb_TextoProveedor
        '
        Me.Lb_TextoProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoProveedor.Location = New System.Drawing.Point(8, 116)
        Me.Lb_TextoProveedor.Name = "Lb_TextoProveedor"
        Me.Lb_TextoProveedor.Size = New System.Drawing.Size(106, 16)
        Me.Lb_TextoProveedor.TabIndex = 8
        Me.Lb_TextoProveedor.Text = "Nit Proveedor:"
        Me.Lb_TextoProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Tx_Proveedor
        '
        Me.Tx_Proveedor.Enabled = False
        Me.Tx_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_Proveedor.Location = New System.Drawing.Point(116, 114)
        Me.Tx_Proveedor.Name = "Tx_Proveedor"
        Me.Tx_Proveedor.Size = New System.Drawing.Size(305, 22)
        Me.Tx_Proveedor.TabIndex = 9
        '
        'Cu_CentroCosto1
        '
        Me.Cu_CentroCosto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto1.Enabled = False
        Me.Cu_CentroCosto1.Location = New System.Drawing.Point(427, 82)
        Me.Cu_CentroCosto1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cu_CentroCosto1.Name = "Cu_CentroCosto1"
        Me.Cu_CentroCosto1.Size = New System.Drawing.Size(207, 49)
        Me.Cu_CentroCosto1.TabIndex = 10
        '
        'Button_Cargar
        '
        Me.Button_Cargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Cargar.Location = New System.Drawing.Point(637, 81)
        Me.Button_Cargar.Name = "Button_Cargar"
        Me.Button_Cargar.Size = New System.Drawing.Size(136, 31)
        Me.Button_Cargar.TabIndex = 11
        Me.Button_Cargar.Tag = "171"
        Me.Button_Cargar.Text = "Cargar Informe"
        Me.Button_Cargar.UseVisualStyleBackColor = True
        '
        'Cu_Fecha1
        '
        Me.Cu_Fecha1.BackColor = System.Drawing.Color.Transparent
        Me.Cu_Fecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cu_Fecha1.Location = New System.Drawing.Point(779, 73)
        Me.Cu_Fecha1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cu_Fecha1.Name = "Cu_Fecha1"
        Me.Cu_Fecha1.Size = New System.Drawing.Size(208, 82)
        Me.Cu_Fecha1.TabIndex = 13
        '
        'Lb_Titulo_Informe
        '
        Me.Lb_Titulo_Informe.BackColor = System.Drawing.SystemColors.Info
        Me.Lb_Titulo_Informe.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_Titulo_Informe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Titulo_Informe.Location = New System.Drawing.Point(0, 161)
        Me.Lb_Titulo_Informe.Name = "Lb_Titulo_Informe"
        Me.Lb_Titulo_Informe.Size = New System.Drawing.Size(1235, 25)
        Me.Lb_Titulo_Informe.TabIndex = 1
        Me.Lb_Titulo_Informe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cu_Informe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pn_Formulario)
        Me.Controls.Add(Me.Lb_Titulo_Informe)
        Me.Controls.Add(Me.Pn_Comandos)
        Me.Name = "Cu_Informe"
        Me.Size = New System.Drawing.Size(1235, 447)
        Me.Pn_Formulario.ResumeLayout(False)
        CType(Me.Dgv_Informe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Comandos.ResumeLayout(False)
        Me.Gb_Descripción.ResumeLayout(False)
        Me.Gb_Descripción.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Formulario As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Informe As System.Windows.Forms.DataGridView
    Friend WithEvents Pn_Comandos As System.Windows.Forms.Panel
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Lb_Titulo_Informe As System.Windows.Forms.Label
    Friend WithEvents Gb_Descripción As System.Windows.Forms.GroupBox
    Friend WithEvents Ck_VerColumnasInforme As System.Windows.Forms.CheckBox
    Friend WithEvents Lb_TextoTipo As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoConsulta As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoDescripcion As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Consulta As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoFechaInicial As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_TextoFechaFinal As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_TextoProveedor As System.Windows.Forms.Label
    Friend WithEvents Tx_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Cu_CentroCosto1 As FormulariosClasesBase.Cu_CentroCosto
    Friend WithEvents Button_Cargar As System.Windows.Forms.Button
    Friend WithEvents Cu_Fecha1 As Clasesbase.Cu_Fecha

End Class
