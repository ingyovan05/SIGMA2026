<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_TrasladoCustodias
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pn_Encabezado = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Bt_Buscar = New System.Windows.Forms.Button()
        Me.Tx_Valor = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cu_AsociarPersonaBodega2 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Cu_AsociarPersonaBodega1 = New FormulariosClasesBase.Cu_AsociarPersonaBodega()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tb_ObservaciónSAE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Tb_ObservaciónEAE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cb_Actividad = New System.Windows.Forms.ComboBox()
        Me.Tx_Destino = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tb_ObservaciónSAH = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersona1 = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Tb_ObservaciónEAH = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersona = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Ck_VistaPrevia = New System.Windows.Forms.CheckBox()
        Me.Bt_Desseleccionar = New System.Windows.Forms.Button()
        Me.Bt_Seleccionar = New System.Windows.Forms.Button()
        Me.Bt_Imprimir = New System.Windows.Forms.Button()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Dgv_Custodias = New System.Windows.Forms.DataGridView()
        Me.TIPOCUSTODIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDARTICULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ARTICULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDEQUIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EQUIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDEQUIPOPADRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EQUIPOPADRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MARCAR = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Pn_Encabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_Custodias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pn_Encabezado
        '
        Me.Pn_Encabezado.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Pn_Encabezado.Controls.Add(Me.Label2)
        Me.Pn_Encabezado.Controls.Add(Me.Bt_Buscar)
        Me.Pn_Encabezado.Controls.Add(Me.Tx_Valor)
        Me.Pn_Encabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Encabezado.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Encabezado.Name = "Pn_Encabezado"
        Me.Pn_Encabezado.Size = New System.Drawing.Size(876, 41)
        Me.Pn_Encabezado.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "C.C. o Identificación:"
        '
        'Bt_Buscar
        '
        Me.Bt_Buscar.Location = New System.Drawing.Point(305, 9)
        Me.Bt_Buscar.Name = "Bt_Buscar"
        Me.Bt_Buscar.Size = New System.Drawing.Size(86, 23)
        Me.Bt_Buscar.TabIndex = 12
        Me.Bt_Buscar.Text = "Buscar"
        Me.Bt_Buscar.UseVisualStyleBackColor = True
        '
        'Tx_Valor
        '
        Me.Tx_Valor.Location = New System.Drawing.Point(117, 10)
        Me.Tx_Valor.Name = "Tx_Valor"
        Me.Tx_Valor.Size = New System.Drawing.Size(180, 20)
        Me.Tx_Valor.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Cu_AsociarPersonaBodega2)
        Me.Panel1.Controls.Add(Me.Cu_AsociarPersonaBodega1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Tb_ObservaciónSAE)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Tb_ObservaciónEAE)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Cb_Actividad)
        Me.Panel1.Controls.Add(Me.Tx_Destino)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Tb_ObservaciónSAH)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Cu_BuscarPersona1)
        Me.Panel1.Controls.Add(Me.Tb_ObservaciónEAH)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Cu_BuscarPersona)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Ck_VistaPrevia)
        Me.Panel1.Controls.Add(Me.Bt_Desseleccionar)
        Me.Panel1.Controls.Add(Me.Bt_Seleccionar)
        Me.Panel1.Controls.Add(Me.Bt_Imprimir)
        Me.Panel1.Controls.Add(Me.Bt_Cerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 282)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(876, 374)
        Me.Panel1.TabIndex = 10
        '
        'Cu_AsociarPersonaBodega2
        '
        Me.Cu_AsociarPersonaBodega2.componenteasociado = "Cu_BuscarPersona1"
        Me.Cu_AsociarPersonaBodega2.CrearUsuario = True
        Me.Cu_AsociarPersonaBodega2.Location = New System.Drawing.Point(616, 332)
        Me.Cu_AsociarPersonaBodega2.Name = "Cu_AsociarPersonaBodega2"
        Me.Cu_AsociarPersonaBodega2.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega2.TabIndex = 28
        Me.Cu_AsociarPersonaBodega2.Tag = "330"
        Me.Cu_AsociarPersonaBodega2.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodega2.TipoBúsqueda = "P"
        '
        'Cu_AsociarPersonaBodega1
        '
        Me.Cu_AsociarPersonaBodega1.componenteasociado = "Cu_BuscarPersona"
        Me.Cu_AsociarPersonaBodega1.CrearUsuario = True
        Me.Cu_AsociarPersonaBodega1.Location = New System.Drawing.Point(616, 306)
        Me.Cu_AsociarPersonaBodega1.Name = "Cu_AsociarPersonaBodega1"
        Me.Cu_AsociarPersonaBodega1.Size = New System.Drawing.Size(27, 23)
        Me.Cu_AsociarPersonaBodega1.TabIndex = 27
        Me.Cu_AsociarPersonaBodega1.Tag = "331"
        Me.Cu_AsociarPersonaBodega1.TipoAsociacion = "BOD"
        Me.Cu_AsociarPersonaBodega1.TipoBúsqueda = "P"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 255)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Observación SA Equipos:"
        '
        'Tb_ObservaciónSAE
        '
        Me.Tb_ObservaciónSAE.Location = New System.Drawing.Point(140, 251)
        Me.Tb_ObservaciónSAE.MaxLength = 200
        Me.Tb_ObservaciónSAE.Multiline = True
        Me.Tb_ObservaciónSAE.Name = "Tb_ObservaciónSAE"
        Me.Tb_ObservaciónSAE.Size = New System.Drawing.Size(717, 49)
        Me.Tb_ObservaciónSAE.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Observación EA Equipos:"
        '
        'Tb_ObservaciónEAE
        '
        Me.Tb_ObservaciónEAE.Location = New System.Drawing.Point(140, 196)
        Me.Tb_ObservaciónEAE.MaxLength = 200
        Me.Tb_ObservaciónEAE.Multiline = True
        Me.Tb_ObservaciónEAE.Name = "Tb_ObservaciónEAE"
        Me.Tb_ObservaciónEAE.Size = New System.Drawing.Size(717, 49)
        Me.Tb_ObservaciónEAE.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(85, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Actividad:"
        '
        'Cb_Actividad
        '
        Me.Cb_Actividad.FormattingEnabled = True
        Me.Cb_Actividad.Location = New System.Drawing.Point(140, 33)
        Me.Cb_Actividad.Name = "Cb_Actividad"
        Me.Cb_Actividad.Size = New System.Drawing.Size(510, 21)
        Me.Cb_Actividad.TabIndex = 22
        '
        'Tx_Destino
        '
        Me.Tx_Destino.Location = New System.Drawing.Point(140, 60)
        Me.Tx_Destino.MaxLength = 100
        Me.Tx_Destino.Name = "Tx_Destino"
        Me.Tx_Destino.Size = New System.Drawing.Size(510, 20)
        Me.Tx_Destino.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(90, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Destino :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Observación SA Hta:"
        '
        'Tb_ObservaciónSAH
        '
        Me.Tb_ObservaciónSAH.Location = New System.Drawing.Point(140, 141)
        Me.Tb_ObservaciónSAH.MaxLength = 200
        Me.Tb_ObservaciónSAH.Multiline = True
        Me.Tb_ObservaciónSAH.Name = "Tb_ObservaciónSAH"
        Me.Tb_ObservaciónSAH.Size = New System.Drawing.Size(717, 49)
        Me.Tb_ObservaciónSAH.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Observación EA Hta:"
        '
        'Cu_BuscarPersona1
        '
        Me.Cu_BuscarPersona1.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersona1.Location = New System.Drawing.Point(140, 332)
        Me.Cu_BuscarPersona1.Name = "Cu_BuscarPersona1"
        Me.Cu_BuscarPersona1.Size = New System.Drawing.Size(470, 23)
        Me.Cu_BuscarPersona1.TabIndex = 10
        Me.Cu_BuscarPersona1.Tipo = "PUABO"
        Me.Cu_BuscarPersona1.valorcajatexto = "IDENTIFICACION"
        '
        'Tb_ObservaciónEAH
        '
        Me.Tb_ObservaciónEAH.Location = New System.Drawing.Point(140, 86)
        Me.Tb_ObservaciónEAH.MaxLength = 200
        Me.Tb_ObservaciónEAH.Multiline = True
        Me.Tb_ObservaciónEAH.Name = "Tb_ObservaciónEAH"
        Me.Tb_ObservaciónEAH.Size = New System.Drawing.Size(717, 49)
        Me.Tb_ObservaciónEAH.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 337)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Persona Autoriza:"
        '
        'Cu_BuscarPersona
        '
        Me.Cu_BuscarPersona.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersona.Location = New System.Drawing.Point(140, 305)
        Me.Cu_BuscarPersona.Name = "Cu_BuscarPersona"
        Me.Cu_BuscarPersona.Size = New System.Drawing.Size(470, 23)
        Me.Cu_BuscarPersona.TabIndex = 8
        Me.Cu_BuscarPersona.Tipo = "PUABO"
        Me.Cu_BuscarPersona.valorcajatexto = "IDENTIFICACION"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 310)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Persona Recibe Custodia:"
        '
        'Ck_VistaPrevia
        '
        Me.Ck_VistaPrevia.AutoSize = True
        Me.Ck_VistaPrevia.Checked = True
        Me.Ck_VistaPrevia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_VistaPrevia.Location = New System.Drawing.Point(160, 10)
        Me.Ck_VistaPrevia.Name = "Ck_VistaPrevia"
        Me.Ck_VistaPrevia.Size = New System.Drawing.Size(82, 17)
        Me.Ck_VistaPrevia.TabIndex = 4
        Me.Ck_VistaPrevia.Text = "Vista Previa"
        Me.Ck_VistaPrevia.UseVisualStyleBackColor = True
        '
        'Bt_Desseleccionar
        '
        Me.Bt_Desseleccionar.Location = New System.Drawing.Point(82, 4)
        Me.Bt_Desseleccionar.Name = "Bt_Desseleccionar"
        Me.Bt_Desseleccionar.Size = New System.Drawing.Size(61, 23)
        Me.Bt_Desseleccionar.TabIndex = 1
        Me.Bt_Desseleccionar.Text = "Ninguno"
        Me.Bt_Desseleccionar.UseVisualStyleBackColor = True
        '
        'Bt_Seleccionar
        '
        Me.Bt_Seleccionar.Location = New System.Drawing.Point(12, 4)
        Me.Bt_Seleccionar.Name = "Bt_Seleccionar"
        Me.Bt_Seleccionar.Size = New System.Drawing.Size(64, 23)
        Me.Bt_Seleccionar.TabIndex = 0
        Me.Bt_Seleccionar.Text = "Todos"
        Me.Bt_Seleccionar.UseVisualStyleBackColor = True
        '
        'Bt_Imprimir
        '
        Me.Bt_Imprimir.Location = New System.Drawing.Point(700, 344)
        Me.Bt_Imprimir.Name = "Bt_Imprimir"
        Me.Bt_Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Imprimir.TabIndex = 2
        Me.Bt_Imprimir.Text = "Imprimir"
        Me.Bt_Imprimir.UseVisualStyleBackColor = True
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(782, 344)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 3
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Dgv_Custodias
        '
        Me.Dgv_Custodias.AllowUserToAddRows = False
        Me.Dgv_Custodias.AllowUserToDeleteRows = False
        Me.Dgv_Custodias.AllowUserToResizeColumns = False
        Me.Dgv_Custodias.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Custodias.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Custodias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Custodias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Custodias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TIPOCUSTODIA, Me.IDARTICULO, Me.ARTICULO, Me.CANTIDAD, Me.IDEQUIPO, Me.EQUIPO, Me.IDEQUIPOPADRE, Me.EQUIPOPADRE, Me.MARCAR})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv_Custodias.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_Custodias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Custodias.Location = New System.Drawing.Point(0, 41)
        Me.Dgv_Custodias.Name = "Dgv_Custodias"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_Custodias.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_Custodias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Custodias.Size = New System.Drawing.Size(876, 241)
        Me.Dgv_Custodias.TabIndex = 11
        '
        'TIPOCUSTODIA
        '
        Me.TIPOCUSTODIA.DataPropertyName = "Tipo Custodia"
        Me.TIPOCUSTODIA.HeaderText = "Tipo Custodia"
        Me.TIPOCUSTODIA.Name = "TIPOCUSTODIA"
        Me.TIPOCUSTODIA.Width = 130
        '
        'IDARTICULO
        '
        Me.IDARTICULO.DataPropertyName = "Id Artículo"
        Me.IDARTICULO.HeaderText = "Id Art."
        Me.IDARTICULO.Name = "IDARTICULO"
        Me.IDARTICULO.Width = 50
        '
        'ARTICULO
        '
        Me.ARTICULO.DataPropertyName = "Artículo"
        Me.ARTICULO.HeaderText = "Artículo"
        Me.ARTICULO.Name = "ARTICULO"
        Me.ARTICULO.Width = 280
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "Cantidad"
        Me.CANTIDAD.HeaderText = "Cant."
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.Width = 40
        '
        'IDEQUIPO
        '
        Me.IDEQUIPO.DataPropertyName = "Id Equipo"
        Me.IDEQUIPO.HeaderText = "Id Eq."
        Me.IDEQUIPO.Name = "IDEQUIPO"
        Me.IDEQUIPO.Width = 50
        '
        'EQUIPO
        '
        Me.EQUIPO.DataPropertyName = "Equipo"
        Me.EQUIPO.HeaderText = "Equipo"
        Me.EQUIPO.Name = "EQUIPO"
        Me.EQUIPO.Width = 110
        '
        'IDEQUIPOPADRE
        '
        Me.IDEQUIPOPADRE.DataPropertyName = "Id Equipo Padre"
        Me.IDEQUIPOPADRE.HeaderText = "Id Equipo Padre"
        Me.IDEQUIPOPADRE.Name = "IDEQUIPOPADRE"
        Me.IDEQUIPOPADRE.Visible = False
        '
        'EQUIPOPADRE
        '
        Me.EQUIPOPADRE.DataPropertyName = "Equipo Padre"
        Me.EQUIPOPADRE.HeaderText = "Equipo Padre"
        Me.EQUIPOPADRE.Name = "EQUIPOPADRE"
        Me.EQUIPOPADRE.Width = 110
        '
        'MARCAR
        '
        Me.MARCAR.DataPropertyName = "MARCAR"
        Me.MARCAR.FalseValue = "N"
        Me.MARCAR.HeaderText = "Marcar"
        Me.MARCAR.Name = "MARCAR"
        Me.MARCAR.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MARCAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MARCAR.TrueValue = "S"
        Me.MARCAR.Width = 50
        '
        'Fr_TrasladoCustodias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 656)
        Me.Controls.Add(Me.Dgv_Custodias)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pn_Encabezado)
        Me.MaximumSize = New System.Drawing.Size(892, 695)
        Me.MinimumSize = New System.Drawing.Size(892, 695)
        Me.Name = "Fr_TrasladoCustodias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traslado Custodias"
        Me.Pn_Encabezado.ResumeLayout(False)
        Me.Pn_Encabezado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Dgv_Custodias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Encabezado As System.Windows.Forms.Panel
    Friend WithEvents Bt_Buscar As System.Windows.Forms.Button
    Friend WithEvents Tx_Valor As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Ck_VistaPrevia As System.Windows.Forms.CheckBox
    Friend WithEvents Bt_Desseleccionar As System.Windows.Forms.Button
    Friend WithEvents Bt_Seleccionar As System.Windows.Forms.Button
    Friend WithEvents Bt_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Public WithEvents Cu_BuscarPersona As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Dgv_Custodias As System.Windows.Forms.DataGridView
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Cu_BuscarPersona1 As FormulariosClasesBase.Cu_BuscarPersona
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Tb_ObservaciónSAH As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tb_ObservaciónEAH As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Destino As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cb_Actividad As System.Windows.Forms.ComboBox
    Public WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Tb_ObservaciónSAE As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Tb_ObservaciónEAE As System.Windows.Forms.TextBox
    Friend WithEvents Cu_AsociarPersonaBodega1 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents Cu_AsociarPersonaBodega2 As FormulariosClasesBase.Cu_AsociarPersonaBodega
    Friend WithEvents TIPOCUSTODIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDARTICULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARTICULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDEQUIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EQUIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDEQUIPOPADRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EQUIPOPADRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MARCAR As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
