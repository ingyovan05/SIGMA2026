<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_BuscarArtículo
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_AplicarFiltroOM = New System.Windows.Forms.Button()
        Me.Gb_filtro = New System.Windows.Forms.GroupBox()
        Me.Cb_fechas = New System.Windows.Forms.CheckBox()
        Me.Cb_Bodega = New System.Windows.Forms.CheckBox()
        Me.Cb_BodegaAbreviatura = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dtp_FechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_FechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Bt_filtrar = New System.Windows.Forms.Button()
        Me.Tx_Descripción = New System.Windows.Forms.TextBox()
        Me.Gb_Búsqueda = New System.Windows.Forms.GroupBox()
        Me.Cb_Filtrar = New System.Windows.Forms.CheckBox()
        Me.Tb_Descripción = New System.Windows.Forms.TextBox()
        Me.ComboBox_Filtrar = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Bt_Actualizar = New System.Windows.Forms.Button()
        Me.Lb_FechaArchivo = New System.Windows.Forms.Label()
        Me.Dgv_Buscar = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Gb_filtro.SuspendLayout()
        Me.Gb_Búsqueda.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1136, 2)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(195, 36)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(101, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(89, 28)
        Me.Cancel_Button.TabIndex = 9
        Me.Cancel_Button.Text = "Cancelar"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(4, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(89, 28)
        Me.OK_Button.TabIndex = 8
        Me.OK_Button.Text = "Aceptar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Bt_AplicarFiltroOM)
        Me.Panel1.Controls.Add(Me.Gb_filtro)
        Me.Panel1.Controls.Add(Me.Tx_Descripción)
        Me.Panel1.Controls.Add(Me.Gb_Búsqueda)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1335, 121)
        Me.Panel1.TabIndex = 1
        '
        'Bt_AplicarFiltroOM
        '
        Me.Bt_AplicarFiltroOM.Location = New System.Drawing.Point(818, 20)
        Me.Bt_AplicarFiltroOM.Margin = New System.Windows.Forms.Padding(4)
        Me.Bt_AplicarFiltroOM.Name = "Bt_AplicarFiltroOM"
        Me.Bt_AplicarFiltroOM.Size = New System.Drawing.Size(290, 38)
        Me.Bt_AplicarFiltroOM.TabIndex = 8
        Me.Bt_AplicarFiltroOM.Text = "Aplicar Filtro x OM Registradas en RD"
        Me.Bt_AplicarFiltroOM.UseVisualStyleBackColor = True
        '
        'Gb_filtro
        '
        Me.Gb_filtro.Controls.Add(Me.Cb_fechas)
        Me.Gb_filtro.Controls.Add(Me.Cb_Bodega)
        Me.Gb_filtro.Controls.Add(Me.Cb_BodegaAbreviatura)
        Me.Gb_filtro.Controls.Add(Me.Label2)
        Me.Gb_filtro.Controls.Add(Me.Label1)
        Me.Gb_filtro.Controls.Add(Me.Dtp_FechaInicial)
        Me.Gb_filtro.Controls.Add(Me.Dtp_FechaFinal)
        Me.Gb_filtro.Controls.Add(Me.Bt_filtrar)
        Me.Gb_filtro.Location = New System.Drawing.Point(812, 1)
        Me.Gb_filtro.Margin = New System.Windows.Forms.Padding(4)
        Me.Gb_filtro.Name = "Gb_filtro"
        Me.Gb_filtro.Padding = New System.Windows.Forms.Padding(4)
        Me.Gb_filtro.Size = New System.Drawing.Size(508, 112)
        Me.Gb_filtro.TabIndex = 7
        Me.Gb_filtro.TabStop = False
        Me.Gb_filtro.Text = "Filtro"
        '
        'Cb_fechas
        '
        Me.Cb_fechas.AutoSize = True
        Me.Cb_fechas.Location = New System.Drawing.Point(8, 32)
        Me.Cb_fechas.Margin = New System.Windows.Forms.Padding(4)
        Me.Cb_fechas.Name = "Cb_fechas"
        Me.Cb_fechas.Size = New System.Drawing.Size(80, 21)
        Me.Cb_fechas.TabIndex = 21
        Me.Cb_fechas.Text = "Fechas:"
        Me.Cb_fechas.UseVisualStyleBackColor = True
        '
        'Cb_Bodega
        '
        Me.Cb_Bodega.AutoSize = True
        Me.Cb_Bodega.Location = New System.Drawing.Point(8, 76)
        Me.Cb_Bodega.Margin = New System.Windows.Forms.Padding(4)
        Me.Cb_Bodega.Name = "Cb_Bodega"
        Me.Cb_Bodega.Size = New System.Drawing.Size(83, 21)
        Me.Cb_Bodega.TabIndex = 20
        Me.Cb_Bodega.Text = "Bodega:"
        Me.Cb_Bodega.UseVisualStyleBackColor = True
        '
        'Cb_BodegaAbreviatura
        '
        Me.Cb_BodegaAbreviatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_BodegaAbreviatura.FormattingEnabled = True
        Me.Cb_BodegaAbreviatura.Location = New System.Drawing.Point(100, 74)
        Me.Cb_BodegaAbreviatura.Margin = New System.Windows.Forms.Padding(4)
        Me.Cb_BodegaAbreviatura.Name = "Cb_BodegaAbreviatura"
        Me.Cb_BodegaAbreviatura.Size = New System.Drawing.Size(276, 24)
        Me.Cb_BodegaAbreviatura.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(96, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Inicial:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(307, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Final:"
        '
        'Dtp_FechaInicial
        '
        Me.Dtp_FechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaInicial.Location = New System.Drawing.Point(148, 31)
        Me.Dtp_FechaInicial.Margin = New System.Windows.Forms.Padding(4)
        Me.Dtp_FechaInicial.Name = "Dtp_FechaInicial"
        Me.Dtp_FechaInicial.Size = New System.Drawing.Size(148, 22)
        Me.Dtp_FechaInicial.TabIndex = 15
        '
        'Dtp_FechaFinal
        '
        Me.Dtp_FechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaFinal.Location = New System.Drawing.Point(359, 32)
        Me.Dtp_FechaFinal.Margin = New System.Windows.Forms.Padding(4)
        Me.Dtp_FechaFinal.Name = "Dtp_FechaFinal"
        Me.Dtp_FechaFinal.Size = New System.Drawing.Size(140, 22)
        Me.Dtp_FechaFinal.TabIndex = 14
        '
        'Bt_filtrar
        '
        Me.Bt_filtrar.Location = New System.Drawing.Point(385, 73)
        Me.Bt_filtrar.Margin = New System.Windows.Forms.Padding(4)
        Me.Bt_filtrar.Name = "Bt_filtrar"
        Me.Bt_filtrar.Size = New System.Drawing.Size(117, 28)
        Me.Bt_filtrar.TabIndex = 0
        Me.Bt_filtrar.Text = "Aplicar Filtro"
        Me.Bt_filtrar.UseVisualStyleBackColor = True
        '
        'Tx_Descripción
        '
        Me.Tx_Descripción.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_Descripción.Location = New System.Drawing.Point(4, 65)
        Me.Tx_Descripción.Margin = New System.Windows.Forms.Padding(4)
        Me.Tx_Descripción.Multiline = True
        Me.Tx_Descripción.Name = "Tx_Descripción"
        Me.Tx_Descripción.ReadOnly = True
        Me.Tx_Descripción.Size = New System.Drawing.Size(799, 49)
        Me.Tx_Descripción.TabIndex = 6
        '
        'Gb_Búsqueda
        '
        Me.Gb_Búsqueda.Controls.Add(Me.Cb_Filtrar)
        Me.Gb_Búsqueda.Controls.Add(Me.Tb_Descripción)
        Me.Gb_Búsqueda.Controls.Add(Me.ComboBox_Filtrar)
        Me.Gb_Búsqueda.Location = New System.Drawing.Point(4, 4)
        Me.Gb_Búsqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.Gb_Búsqueda.MaximumSize = New System.Drawing.Size(800, 54)
        Me.Gb_Búsqueda.MinimumSize = New System.Drawing.Size(800, 54)
        Me.Gb_Búsqueda.Name = "Gb_Búsqueda"
        Me.Gb_Búsqueda.Padding = New System.Windows.Forms.Padding(4)
        Me.Gb_Búsqueda.Size = New System.Drawing.Size(800, 54)
        Me.Gb_Búsqueda.TabIndex = 2
        Me.Gb_Búsqueda.TabStop = False
        Me.Gb_Búsqueda.Text = "Búsqueda"
        '
        'Cb_Filtrar
        '
        Me.Cb_Filtrar.AutoSize = True
        Me.Cb_Filtrar.Checked = True
        Me.Cb_Filtrar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_Filtrar.Location = New System.Drawing.Point(17, 23)
        Me.Cb_Filtrar.Margin = New System.Windows.Forms.Padding(4)
        Me.Cb_Filtrar.Name = "Cb_Filtrar"
        Me.Cb_Filtrar.Size = New System.Drawing.Size(18, 17)
        Me.Cb_Filtrar.TabIndex = 4
        Me.Cb_Filtrar.UseVisualStyleBackColor = True
        '
        'Tb_Descripción
        '
        Me.Tb_Descripción.Location = New System.Drawing.Point(340, 21)
        Me.Tb_Descripción.Margin = New System.Windows.Forms.Padding(4)
        Me.Tb_Descripción.Name = "Tb_Descripción"
        Me.Tb_Descripción.Size = New System.Drawing.Size(451, 22)
        Me.Tb_Descripción.TabIndex = 3
        '
        'ComboBox_Filtrar
        '
        Me.ComboBox_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Filtrar.FormattingEnabled = True
        Me.ComboBox_Filtrar.Location = New System.Drawing.Point(45, 20)
        Me.ComboBox_Filtrar.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Filtrar.Name = "ComboBox_Filtrar"
        Me.ComboBox_Filtrar.Size = New System.Drawing.Size(279, 24)
        Me.ComboBox_Filtrar.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel2.Controls.Add(Me.Bt_Actualizar)
        Me.Panel2.Controls.Add(Me.Lb_FechaArchivo)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 578)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1335, 41)
        Me.Panel2.TabIndex = 6
        '
        'Bt_Actualizar
        '
        Me.Bt_Actualizar.Location = New System.Drawing.Point(4, 7)
        Me.Bt_Actualizar.Margin = New System.Windows.Forms.Padding(4)
        Me.Bt_Actualizar.Name = "Bt_Actualizar"
        Me.Bt_Actualizar.Size = New System.Drawing.Size(81, 28)
        Me.Bt_Actualizar.TabIndex = 9
        Me.Bt_Actualizar.Text = "Actualizar"
        Me.Bt_Actualizar.UseVisualStyleBackColor = True
        '
        'Lb_FechaArchivo
        '
        Me.Lb_FechaArchivo.AutoSize = True
        Me.Lb_FechaArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_FechaArchivo.ForeColor = System.Drawing.Color.Blue
        Me.Lb_FechaArchivo.Location = New System.Drawing.Point(93, 12)
        Me.Lb_FechaArchivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_FechaArchivo.Name = "Lb_FechaArchivo"
        Me.Lb_FechaArchivo.Size = New System.Drawing.Size(65, 20)
        Me.Lb_FechaArchivo.TabIndex = 8
        Me.Lb_FechaArchivo.Text = "Label1"
        '
        'Dgv_Buscar
        '
        Me.Dgv_Buscar.AllowUserToAddRows = False
        Me.Dgv_Buscar.AllowUserToDeleteRows = False
        Me.Dgv_Buscar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Buscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Buscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Buscar.Location = New System.Drawing.Point(0, 121)
        Me.Dgv_Buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.Dgv_Buscar.Name = "Dgv_Buscar"
        Me.Dgv_Buscar.Size = New System.Drawing.Size(1335, 457)
        Me.Dgv_Buscar.TabIndex = 6
        '
        'Timer1
        '
        '
        'Fr_BuscarArtículo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1335, 619)
        Me.Controls.Add(Me.Dgv_Buscar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1350, 655)
        Me.Name = "Fr_BuscarArtículo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Artículo"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Gb_filtro.ResumeLayout(False)
        Me.Gb_filtro.PerformLayout()
        Me.Gb_Búsqueda.ResumeLayout(False)
        Me.Gb_Búsqueda.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Gb_Búsqueda As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_Filtrar As System.Windows.Forms.CheckBox
    Friend WithEvents Tb_Descripción As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox_Filtrar As System.Windows.Forms.ComboBox
    Friend WithEvents Dgv_Buscar As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Lb_FechaArchivo As System.Windows.Forms.Label
    Friend WithEvents Bt_Actualizar As System.Windows.Forms.Button
    Friend WithEvents Tx_Descripción As System.Windows.Forms.TextBox
    Friend WithEvents Gb_filtro As Windows.Forms.GroupBox
    Friend WithEvents Bt_filtrar As Windows.Forms.Button
    Friend WithEvents Dtp_FechaFinal As Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_FechaInicial As Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Cb_BodegaAbreviatura As Windows.Forms.ComboBox
    Friend WithEvents Cb_fechas As Windows.Forms.CheckBox
    Friend WithEvents Cb_Bodega As Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AplicarFiltroOM As System.Windows.Forms.Button
End Class
