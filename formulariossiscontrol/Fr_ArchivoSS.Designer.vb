<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ArchivoSS
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
        Me.Pn_Controles = New System.Windows.Forms.Panel()
        Me.Cb_EPS = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cb_AFP = New System.Windows.Forms.ComboBox()
        Me.Lb_PeriodoMedicion = New System.Windows.Forms.Label()
        Me.Dtp_FechaArchivoSS = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaMedicion = New System.Windows.Forms.Label()
        Me.Tlp_Archivo = New System.Windows.Forms.TableLayoutPanel()
        Me.Bt_QuitarArchivo = New System.Windows.Forms.Button()
        Me.Bt_VerArchivo = New System.Windows.Forms.Button()
        Me.Bt_CargarArchivo = New System.Windows.Forms.Button()
        Me.Tx_Archivo = New System.Windows.Forms.TextBox()
        Me.Lb_Archivo = New System.Windows.Forms.Label()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Ofd_ArchivoTBG = New System.Windows.Forms.OpenFileDialog()
        Me.Pn_Controles.SuspendLayout()
        Me.Tlp_Archivo.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Controles
        '
        Me.Pn_Controles.Controls.Add(Me.Cb_EPS)
        Me.Pn_Controles.Controls.Add(Me.Label1)
        Me.Pn_Controles.Controls.Add(Me.Cb_AFP)
        Me.Pn_Controles.Controls.Add(Me.Lb_PeriodoMedicion)
        Me.Pn_Controles.Controls.Add(Me.Dtp_FechaArchivoSS)
        Me.Pn_Controles.Controls.Add(Me.Lb_FechaMedicion)
        Me.Pn_Controles.Controls.Add(Me.Tlp_Archivo)
        Me.Pn_Controles.Controls.Add(Me.Lb_Archivo)
        Me.Pn_Controles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Controles.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Controles.MaximumSize = New System.Drawing.Size(434, 147)
        Me.Pn_Controles.MinimumSize = New System.Drawing.Size(434, 147)
        Me.Pn_Controles.Name = "Pn_Controles"
        Me.Pn_Controles.Size = New System.Drawing.Size(434, 147)
        Me.Pn_Controles.TabIndex = 1
        '
        'Cb_EPS
        '
        Me.Cb_EPS.DisplayMember = "NOMBREMES"
        Me.Cb_EPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_EPS.FormattingEnabled = True
        Me.Cb_EPS.Location = New System.Drawing.Point(109, 65)
        Me.Cb_EPS.Name = "Cb_EPS"
        Me.Cb_EPS.Size = New System.Drawing.Size(189, 21)
        Me.Cb_EPS.TabIndex = 7
        Me.Cb_EPS.ValueMember = "NUMEROMES"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "EPS:"
        '
        'Cb_AFP
        '
        Me.Cb_AFP.DisplayMember = "NOMBREMES"
        Me.Cb_AFP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_AFP.FormattingEnabled = True
        Me.Cb_AFP.Location = New System.Drawing.Point(109, 38)
        Me.Cb_AFP.Name = "Cb_AFP"
        Me.Cb_AFP.Size = New System.Drawing.Size(189, 21)
        Me.Cb_AFP.TabIndex = 5
        Me.Cb_AFP.ValueMember = "NUMEROMES"
        '
        'Lb_PeriodoMedicion
        '
        Me.Lb_PeriodoMedicion.AutoSize = True
        Me.Lb_PeriodoMedicion.Location = New System.Drawing.Point(73, 41)
        Me.Lb_PeriodoMedicion.Name = "Lb_PeriodoMedicion"
        Me.Lb_PeriodoMedicion.Size = New System.Drawing.Size(30, 13)
        Me.Lb_PeriodoMedicion.TabIndex = 4
        Me.Lb_PeriodoMedicion.Text = "AFP:"
        '
        'Dtp_FechaArchivoSS
        '
        Me.Dtp_FechaArchivoSS.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaArchivoSS.Location = New System.Drawing.Point(109, 11)
        Me.Dtp_FechaArchivoSS.Name = "Dtp_FechaArchivoSS"
        Me.Dtp_FechaArchivoSS.Size = New System.Drawing.Size(112, 20)
        Me.Dtp_FechaArchivoSS.TabIndex = 3
        '
        'Lb_FechaMedicion
        '
        Me.Lb_FechaMedicion.AutoSize = True
        Me.Lb_FechaMedicion.Location = New System.Drawing.Point(63, 14)
        Me.Lb_FechaMedicion.Name = "Lb_FechaMedicion"
        Me.Lb_FechaMedicion.Size = New System.Drawing.Size(40, 13)
        Me.Lb_FechaMedicion.TabIndex = 2
        Me.Lb_FechaMedicion.Text = "Fecha:"
        '
        'Tlp_Archivo
        '
        Me.Tlp_Archivo.ColumnCount = 4
        Me.Tlp_Archivo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Archivo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.Tlp_Archivo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.Tlp_Archivo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.Tlp_Archivo.Controls.Add(Me.Bt_QuitarArchivo, 3, 0)
        Me.Tlp_Archivo.Controls.Add(Me.Bt_VerArchivo, 2, 0)
        Me.Tlp_Archivo.Controls.Add(Me.Bt_CargarArchivo, 1, 0)
        Me.Tlp_Archivo.Controls.Add(Me.Tx_Archivo, 0, 0)
        Me.Tlp_Archivo.Location = New System.Drawing.Point(109, 92)
        Me.Tlp_Archivo.Name = "Tlp_Archivo"
        Me.Tlp_Archivo.RowCount = 1
        Me.Tlp_Archivo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Archivo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.Tlp_Archivo.Size = New System.Drawing.Size(321, 22)
        Me.Tlp_Archivo.TabIndex = 1
        '
        'Bt_QuitarArchivo
        '
        Me.Bt_QuitarArchivo.Enabled = False
        Me.Bt_QuitarArchivo.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_QuitarArchivo.Location = New System.Drawing.Point(296, 0)
        Me.Bt_QuitarArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.Bt_QuitarArchivo.Name = "Bt_QuitarArchivo"
        Me.Bt_QuitarArchivo.Size = New System.Drawing.Size(24, 22)
        Me.Bt_QuitarArchivo.TabIndex = 3
        Me.Bt_QuitarArchivo.Text = "❌"
        Me.Bt_QuitarArchivo.UseVisualStyleBackColor = True
        '
        'Bt_VerArchivo
        '
        Me.Bt_VerArchivo.Enabled = False
        Me.Bt_VerArchivo.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_VerArchivo.Location = New System.Drawing.Point(272, 0)
        Me.Bt_VerArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.Bt_VerArchivo.Name = "Bt_VerArchivo"
        Me.Bt_VerArchivo.Size = New System.Drawing.Size(24, 22)
        Me.Bt_VerArchivo.TabIndex = 2
        Me.Bt_VerArchivo.Text = "👁️"
        Me.Bt_VerArchivo.UseVisualStyleBackColor = True
        '
        'Bt_CargarArchivo
        '
        Me.Bt_CargarArchivo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_CargarArchivo.Location = New System.Drawing.Point(248, 0)
        Me.Bt_CargarArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.Bt_CargarArchivo.Name = "Bt_CargarArchivo"
        Me.Bt_CargarArchivo.Size = New System.Drawing.Size(24, 22)
        Me.Bt_CargarArchivo.TabIndex = 1
        Me.Bt_CargarArchivo.Text = "..."
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
        Me.Tx_Archivo.Size = New System.Drawing.Size(247, 20)
        Me.Tx_Archivo.TabIndex = 0
        Me.Tx_Archivo.TabStop = False
        '
        'Lb_Archivo
        '
        Me.Lb_Archivo.AutoSize = True
        Me.Lb_Archivo.Location = New System.Drawing.Point(12, 94)
        Me.Lb_Archivo.Name = "Lb_Archivo"
        Me.Lb_Archivo.Size = New System.Drawing.Size(91, 13)
        Me.Lb_Archivo.TabIndex = 0
        Me.Lb_Archivo.Text = "Adjuntar Archivo :"
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 117)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(435, 30)
        Me.Flp_Botones.TabIndex = 2
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(357, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(276, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Ofd_ArchivoTBG
        '
        Me.Ofd_ArchivoTBG.Filter = "Libro de Excel|*.xlsx;*.xls|Todos los archivos|*.*"
        '
        'Fr_ArchivoSS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 147)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Controls.Add(Me.Pn_Controles)
        Me.MaximumSize = New System.Drawing.Size(451, 186)
        Me.MinimumSize = New System.Drawing.Size(451, 186)
        Me.Name = "Fr_ArchivoSS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargar Archivo SS"
        Me.Pn_Controles.ResumeLayout(False)
        Me.Pn_Controles.PerformLayout()
        Me.Tlp_Archivo.ResumeLayout(False)
        Me.Tlp_Archivo.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Controles As System.Windows.Forms.Panel
    Friend WithEvents Cb_AFP As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_PeriodoMedicion As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaArchivoSS As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaMedicion As System.Windows.Forms.Label
    Friend WithEvents Tlp_Archivo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Bt_QuitarArchivo As System.Windows.Forms.Button
    Friend WithEvents Bt_VerArchivo As System.Windows.Forms.Button
    Friend WithEvents Bt_CargarArchivo As System.Windows.Forms.Button
    Friend WithEvents Tx_Archivo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Archivo As System.Windows.Forms.Label
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Ofd_ArchivoTBG As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Cb_EPS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
