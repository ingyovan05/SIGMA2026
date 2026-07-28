<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Listado
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Gb_Correspondencia = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cb_Año = New System.Windows.Forms.ComboBox()
        Me.Tx_Hasta = New System.Windows.Forms.TextBox()
        Me.Tx_Desde = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lb_Titulo = New System.Windows.Forms.Label()
        Me.Btn_CargarCorrespondencia = New System.Windows.Forms.Button()
        Me.Gb_CargaRecepcion = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Lb_Listado = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_Cargar = New System.Windows.Forms.Button()
        Me.Dtp_Desde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dtp_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_ExportarExcel = New System.Windows.Forms.Button()
        Me.Btn_Cerrar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Lb_CantidadRegistros = New System.Windows.Forms.Label()
        Me.Dgv_Listado = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Gb_Correspondencia.SuspendLayout()
        Me.Gb_CargaRecepcion.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.Dgv_Listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Gb_Correspondencia)
        Me.Panel1.Controls.Add(Me.Gb_CargaRecepcion)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 60)
        Me.Panel1.TabIndex = 0
        '
        'Gb_Correspondencia
        '
        Me.Gb_Correspondencia.Controls.Add(Me.Label6)
        Me.Gb_Correspondencia.Controls.Add(Me.Cb_Año)
        Me.Gb_Correspondencia.Controls.Add(Me.Tx_Hasta)
        Me.Gb_Correspondencia.Controls.Add(Me.Tx_Desde)
        Me.Gb_Correspondencia.Controls.Add(Me.Label5)
        Me.Gb_Correspondencia.Controls.Add(Me.Label4)
        Me.Gb_Correspondencia.Controls.Add(Me.Lb_Titulo)
        Me.Gb_Correspondencia.Controls.Add(Me.Btn_CargarCorrespondencia)
        Me.Gb_Correspondencia.Location = New System.Drawing.Point(7, 3)
        Me.Gb_Correspondencia.Name = "Gb_Correspondencia"
        Me.Gb_Correspondencia.Size = New System.Drawing.Size(984, 51)
        Me.Gb_Correspondencia.TabIndex = 1
        Me.Gb_Correspondencia.TabStop = False
        Me.Gb_Correspondencia.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(433, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Año:"
        '
        'Cb_Año
        '
        Me.Cb_Año.FormattingEnabled = True
        Me.Cb_Año.Location = New System.Drawing.Point(465, 17)
        Me.Cb_Año.Name = "Cb_Año"
        Me.Cb_Año.Size = New System.Drawing.Size(86, 21)
        Me.Cb_Año.TabIndex = 7
        '
        'Tx_Hasta
        '
        Me.Tx_Hasta.Location = New System.Drawing.Point(784, 18)
        Me.Tx_Hasta.Name = "Tx_Hasta"
        Me.Tx_Hasta.Size = New System.Drawing.Size(100, 20)
        Me.Tx_Hasta.TabIndex = 6
        Me.Tx_Hasta.Text = "0"
        '
        'Tx_Desde
        '
        Me.Tx_Desde.Location = New System.Drawing.Point(618, 18)
        Me.Tx_Desde.Name = "Tx_Desde"
        Me.Tx_Desde.Size = New System.Drawing.Size(100, 20)
        Me.Tx_Desde.TabIndex = 5
        Me.Tx_Desde.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(740, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(571, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Desde:"
        '
        'Lb_Titulo
        '
        Me.Lb_Titulo.AutoSize = True
        Me.Lb_Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Titulo.Location = New System.Drawing.Point(6, 17)
        Me.Lb_Titulo.Name = "Lb_Titulo"
        Me.Lb_Titulo.Size = New System.Drawing.Size(76, 24)
        Me.Lb_Titulo.TabIndex = 0
        Me.Lb_Titulo.Text = "Listado"
        '
        'Btn_CargarCorrespondencia
        '
        Me.Btn_CargarCorrespondencia.Location = New System.Drawing.Point(903, 16)
        Me.Btn_CargarCorrespondencia.Name = "Btn_CargarCorrespondencia"
        Me.Btn_CargarCorrespondencia.Size = New System.Drawing.Size(75, 23)
        Me.Btn_CargarCorrespondencia.TabIndex = 2
        Me.Btn_CargarCorrespondencia.Text = "Cargar"
        Me.Btn_CargarCorrespondencia.UseVisualStyleBackColor = True
        '
        'Gb_CargaRecepcion
        '
        Me.Gb_CargaRecepcion.Controls.Add(Me.Label1)
        Me.Gb_CargaRecepcion.Controls.Add(Me.Cb_Dependencia)
        Me.Gb_CargaRecepcion.Controls.Add(Me.Lb_Listado)
        Me.Gb_CargaRecepcion.Controls.Add(Me.Label3)
        Me.Gb_CargaRecepcion.Controls.Add(Me.Btn_Cargar)
        Me.Gb_CargaRecepcion.Controls.Add(Me.Dtp_Desde)
        Me.Gb_CargaRecepcion.Controls.Add(Me.Label2)
        Me.Gb_CargaRecepcion.Controls.Add(Me.Dtp_Hasta)
        Me.Gb_CargaRecepcion.Location = New System.Drawing.Point(7, 6)
        Me.Gb_CargaRecepcion.Name = "Gb_CargaRecepcion"
        Me.Gb_CargaRecepcion.Size = New System.Drawing.Size(984, 51)
        Me.Gb_CargaRecepcion.TabIndex = 0
        Me.Gb_CargaRecepcion.TabStop = False
        Me.Gb_CargaRecepcion.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(218, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Dependencia"
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.Location = New System.Drawing.Point(295, 16)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(277, 21)
        Me.Cb_Dependencia.TabIndex = 5
        '
        'Lb_Listado
        '
        Me.Lb_Listado.AutoSize = True
        Me.Lb_Listado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Listado.Location = New System.Drawing.Point(6, 17)
        Me.Lb_Listado.Name = "Lb_Listado"
        Me.Lb_Listado.Size = New System.Drawing.Size(76, 24)
        Me.Lb_Listado.TabIndex = 0
        Me.Lb_Listado.Text = "Listado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(578, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha Desde"
        '
        'Btn_Cargar
        '
        Me.Btn_Cargar.Location = New System.Drawing.Point(903, 16)
        Me.Btn_Cargar.Name = "Btn_Cargar"
        Me.Btn_Cargar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cargar.TabIndex = 2
        Me.Btn_Cargar.Text = "Cargar"
        Me.Btn_Cargar.UseVisualStyleBackColor = True
        '
        'Dtp_Desde
        '
        Me.Dtp_Desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Desde.Location = New System.Drawing.Point(655, 17)
        Me.Dtp_Desde.Name = "Dtp_Desde"
        Me.Dtp_Desde.Size = New System.Drawing.Size(98, 20)
        Me.Dtp_Desde.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(759, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'Dtp_Hasta
        '
        Me.Dtp_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Hasta.Location = New System.Drawing.Point(800, 17)
        Me.Dtp_Hasta.Name = "Dtp_Hasta"
        Me.Dtp_Hasta.Size = New System.Drawing.Size(97, 20)
        Me.Dtp_Hasta.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.Btn_Imprimir)
        Me.Panel2.Controls.Add(Me.Btn_ExportarExcel)
        Me.Panel2.Controls.Add(Me.Btn_Cerrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 430)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1008, 32)
        Me.Panel2.TabIndex = 3
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Location = New System.Drawing.Point(114, 5)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Imprimir.TabIndex = 1
        Me.Btn_Imprimir.Text = "Imprimir"
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Btn_ExportarExcel
        '
        Me.Btn_ExportarExcel.Location = New System.Drawing.Point(16, 5)
        Me.Btn_ExportarExcel.Name = "Btn_ExportarExcel"
        Me.Btn_ExportarExcel.Size = New System.Drawing.Size(92, 23)
        Me.Btn_ExportarExcel.TabIndex = 0
        Me.Btn_ExportarExcel.Text = "Exportar Excel"
        Me.Btn_ExportarExcel.UseVisualStyleBackColor = True
        '
        'Btn_Cerrar
        '
        Me.Btn_Cerrar.Location = New System.Drawing.Point(921, 5)
        Me.Btn_Cerrar.Name = "Btn_Cerrar"
        Me.Btn_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cerrar.TabIndex = 2
        Me.Btn_Cerrar.Text = "Cerrar"
        Me.Btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Dgv_Listado)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1008, 370)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Lb_CantidadRegistros)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 347)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1008, 23)
        Me.Panel4.TabIndex = 5
        '
        'Lb_CantidadRegistros
        '
        Me.Lb_CantidadRegistros.AutoSize = True
        Me.Lb_CantidadRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadRegistros.Location = New System.Drawing.Point(4, 7)
        Me.Lb_CantidadRegistros.Name = "Lb_CantidadRegistros"
        Me.Lb_CantidadRegistros.Size = New System.Drawing.Size(45, 13)
        Me.Lb_CantidadRegistros.TabIndex = 0
        Me.Lb_CantidadRegistros.Text = "Label1"
        Me.Lb_CantidadRegistros.Visible = False
        '
        'Dgv_Listado
        '
        Me.Dgv_Listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Listado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Listado.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Listado.Name = "Dgv_Listado"
        Me.Dgv_Listado.Size = New System.Drawing.Size(1008, 370)
        Me.Dgv_Listado.TabIndex = 0
        '
        'Fr_Listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 462)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Fr_Listado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado"
        Me.Panel1.ResumeLayout(False)
        Me.Gb_Correspondencia.ResumeLayout(False)
        Me.Gb_Correspondencia.PerformLayout()
        Me.Gb_CargaRecepcion.ResumeLayout(False)
        Me.Gb_CargaRecepcion.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.Dgv_Listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Dtp_Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Btn_ExportarExcel As System.Windows.Forms.Button
    Friend WithEvents Btn_Cargar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Listado As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Lb_Listado As System.Windows.Forms.Label
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Gb_CargaRecepcion As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Lb_CantidadRegistros As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Gb_Correspondencia As System.Windows.Forms.GroupBox
    Public WithEvents Lb_Titulo As System.Windows.Forms.Label
    Friend WithEvents Btn_CargarCorrespondencia As System.Windows.Forms.Button
    Friend WithEvents Tx_Hasta As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Desde As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cb_Año As System.Windows.Forms.ComboBox
End Class
