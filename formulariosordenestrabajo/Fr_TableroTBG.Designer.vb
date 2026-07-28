<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_TableroTBG
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
        Me.Tx_Archivo = New System.Windows.Forms.TextBox()
        Me.Bt_CargarArchivo = New System.Windows.Forms.Button()
        Me.Bt_VerArchivo = New System.Windows.Forms.Button()
        Me.Bt_QuitarArchivo = New System.Windows.Forms.Button()
        Me.Lb_Archivo = New System.Windows.Forms.Label()
        Me.Lb_FechaMedicion = New System.Windows.Forms.Label()
        Me.Dtp_FechaPresentacion = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaPresentacion = New System.Windows.Forms.Label()
        Me.Tlp_Archivo = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Dtp_FechaMedicion = New System.Windows.Forms.DateTimePicker()
        Me.Pn_Controles = New System.Windows.Forms.Panel()
        Me.Cb_PeriodoMedicion = New System.Windows.Forms.ComboBox()
        Me.Lb_PeriodoMedicion = New System.Windows.Forms.Label()
        Me.Ofd_ArchivoTBG = New System.Windows.Forms.OpenFileDialog()
        Me.Tt_Info = New System.Windows.Forms.ToolTip()
        Me.Tlp_Archivo.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Controles.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tx_Archivo
        '
        Me.Tx_Archivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tx_Archivo.Enabled = False
        Me.Tx_Archivo.Location = New System.Drawing.Point(0, 1)
        Me.Tx_Archivo.Margin = New System.Windows.Forms.Padding(0, 1, 1, 0)
        Me.Tx_Archivo.Name = "Tx_Archivo"
        Me.Tx_Archivo.ReadOnly = True
        Me.Tx_Archivo.Size = New System.Drawing.Size(326, 20)
        Me.Tx_Archivo.TabIndex = 0
        Me.Tx_Archivo.TabStop = False
        Me.Tt_Info.SetToolTip(Me.Tx_Archivo, "Nombre del archivo")
        '
        'Bt_CargarArchivo
        '
        Me.Bt_CargarArchivo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_CargarArchivo.Location = New System.Drawing.Point(327, 0)
        Me.Bt_CargarArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.Bt_CargarArchivo.Name = "Bt_CargarArchivo"
        Me.Bt_CargarArchivo.Size = New System.Drawing.Size(24, 22)
        Me.Bt_CargarArchivo.TabIndex = 1
        Me.Bt_CargarArchivo.Text = "..."
        Me.Tt_Info.SetToolTip(Me.Bt_CargarArchivo, "Cargar archivo")
        Me.Bt_CargarArchivo.UseVisualStyleBackColor = True
        '
        'Bt_VerArchivo
        '
        Me.Bt_VerArchivo.Enabled = False
        Me.Bt_VerArchivo.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_VerArchivo.Location = New System.Drawing.Point(351, 0)
        Me.Bt_VerArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.Bt_VerArchivo.Name = "Bt_VerArchivo"
        Me.Bt_VerArchivo.Size = New System.Drawing.Size(24, 22)
        Me.Bt_VerArchivo.TabIndex = 2
        Me.Bt_VerArchivo.Text = "👁️"
        Me.Tt_Info.SetToolTip(Me.Bt_VerArchivo, "Ver archivo")
        Me.Bt_VerArchivo.UseVisualStyleBackColor = True
        '
        'Bt_QuitarArchivo
        '
        Me.Bt_QuitarArchivo.Enabled = False
        Me.Bt_QuitarArchivo.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_QuitarArchivo.Location = New System.Drawing.Point(375, 0)
        Me.Bt_QuitarArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.Bt_QuitarArchivo.Name = "Bt_QuitarArchivo"
        Me.Bt_QuitarArchivo.Size = New System.Drawing.Size(24, 22)
        Me.Bt_QuitarArchivo.TabIndex = 3
        Me.Bt_QuitarArchivo.Text = "❌"
        Me.Tt_Info.SetToolTip(Me.Bt_QuitarArchivo, "Quitar archivo")
        Me.Bt_QuitarArchivo.UseVisualStyleBackColor = True
        '
        'Lb_Archivo
        '
        Me.Lb_Archivo.AutoSize = True
        Me.Lb_Archivo.Location = New System.Drawing.Point(3, 16)
        Me.Lb_Archivo.Name = "Lb_Archivo"
        Me.Lb_Archivo.Size = New System.Drawing.Size(162, 13)
        Me.Lb_Archivo.TabIndex = 0
        Me.Lb_Archivo.Text = "Archivo (tamaño máximo 10 MB):"
        '
        'Lb_FechaMedicion
        '
        Me.Lb_FechaMedicion.AutoSize = True
        Me.Lb_FechaMedicion.Location = New System.Drawing.Point(64, 43)
        Me.Lb_FechaMedicion.Name = "Lb_FechaMedicion"
        Me.Lb_FechaMedicion.Size = New System.Drawing.Size(101, 13)
        Me.Lb_FechaMedicion.TabIndex = 2
        Me.Lb_FechaMedicion.Text = "Fecha de Medición:"
        '
        'Dtp_FechaPresentacion
        '
        Me.Dtp_FechaPresentacion.Checked = False
        Me.Dtp_FechaPresentacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaPresentacion.Location = New System.Drawing.Point(168, 66)
        Me.Dtp_FechaPresentacion.Name = "Dtp_FechaPresentacion"
        Me.Dtp_FechaPresentacion.ShowCheckBox = True
        Me.Dtp_FechaPresentacion.Size = New System.Drawing.Size(112, 20)
        Me.Dtp_FechaPresentacion.TabIndex = 7
        '
        'Lb_FechaPresentacion
        '
        Me.Lb_FechaPresentacion.AutoSize = True
        Me.Lb_FechaPresentacion.Location = New System.Drawing.Point(45, 69)
        Me.Lb_FechaPresentacion.Name = "Lb_FechaPresentacion"
        Me.Lb_FechaPresentacion.Size = New System.Drawing.Size(120, 13)
        Me.Lb_FechaPresentacion.TabIndex = 6
        Me.Lb_FechaPresentacion.Text = "Fecha de Presentación:"
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
        Me.Tlp_Archivo.Location = New System.Drawing.Point(168, 12)
        Me.Tlp_Archivo.Name = "Tlp_Archivo"
        Me.Tlp_Archivo.RowCount = 1
        Me.Tlp_Archivo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Archivo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.Tlp_Archivo.Size = New System.Drawing.Size(400, 22)
        Me.Tlp_Archivo.TabIndex = 1
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 98)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(574, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(496, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(415, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Dtp_FechaMedicion
        '
        Me.Dtp_FechaMedicion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaMedicion.Location = New System.Drawing.Point(168, 40)
        Me.Dtp_FechaMedicion.Name = "Dtp_FechaMedicion"
        Me.Dtp_FechaMedicion.Size = New System.Drawing.Size(112, 20)
        Me.Dtp_FechaMedicion.TabIndex = 3
        '
        'Pn_Controles
        '
        Me.Pn_Controles.Controls.Add(Me.Dtp_FechaPresentacion)
        Me.Pn_Controles.Controls.Add(Me.Lb_FechaPresentacion)
        Me.Pn_Controles.Controls.Add(Me.Cb_PeriodoMedicion)
        Me.Pn_Controles.Controls.Add(Me.Lb_PeriodoMedicion)
        Me.Pn_Controles.Controls.Add(Me.Dtp_FechaMedicion)
        Me.Pn_Controles.Controls.Add(Me.Lb_FechaMedicion)
        Me.Pn_Controles.Controls.Add(Me.Tlp_Archivo)
        Me.Pn_Controles.Controls.Add(Me.Lb_Archivo)
        Me.Pn_Controles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Controles.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Controles.Name = "Pn_Controles"
        Me.Pn_Controles.Size = New System.Drawing.Size(574, 98)
        Me.Pn_Controles.TabIndex = 0
        '
        'Cb_PeriodoMedicion
        '
        Me.Cb_PeriodoMedicion.DisplayMember = "NOMBREMES"
        Me.Cb_PeriodoMedicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_PeriodoMedicion.FormattingEnabled = True
        Me.Cb_PeriodoMedicion.Location = New System.Drawing.Point(396, 40)
        Me.Cb_PeriodoMedicion.Name = "Cb_PeriodoMedicion"
        Me.Cb_PeriodoMedicion.Size = New System.Drawing.Size(98, 21)
        Me.Cb_PeriodoMedicion.TabIndex = 5
        Me.Cb_PeriodoMedicion.ValueMember = "NUMEROMES"
        '
        'Lb_PeriodoMedicion
        '
        Me.Lb_PeriodoMedicion.AutoSize = True
        Me.Lb_PeriodoMedicion.Location = New System.Drawing.Point(286, 43)
        Me.Lb_PeriodoMedicion.Name = "Lb_PeriodoMedicion"
        Me.Lb_PeriodoMedicion.Size = New System.Drawing.Size(107, 13)
        Me.Lb_PeriodoMedicion.TabIndex = 4
        Me.Lb_PeriodoMedicion.Text = "Periodo de Medición:"
        '
        'Ofd_ArchivoTBG
        '
        Me.Ofd_ArchivoTBG.Filter = "Libro de Excel|*.xlsx;*.xls|Todos los archivos|*.*"
        '
        'Fr_TableroTBG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 128)
        Me.Controls.Add(Me.Pn_Controles)
        Me.Controls.Add(Me.Flp_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_TableroTBG"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionar TBG"
        Me.Tlp_Archivo.ResumeLayout(False)
        Me.Tlp_Archivo.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Controles.ResumeLayout(False)
        Me.Pn_Controles.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tx_Archivo As System.Windows.Forms.TextBox
    Friend WithEvents Bt_CargarArchivo As System.Windows.Forms.Button
    Friend WithEvents Bt_VerArchivo As System.Windows.Forms.Button
    Friend WithEvents Bt_QuitarArchivo As System.Windows.Forms.Button
    Friend WithEvents Lb_Archivo As System.Windows.Forms.Label
    Friend WithEvents Lb_FechaMedicion As System.Windows.Forms.Label
    Friend WithEvents Dtp_FechaPresentacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_FechaPresentacion As System.Windows.Forms.Label
    Friend WithEvents Tlp_Archivo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Dtp_FechaMedicion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Pn_Controles As System.Windows.Forms.Panel
    Friend WithEvents Cb_PeriodoMedicion As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_PeriodoMedicion As System.Windows.Forms.Label
    Friend WithEvents Ofd_ArchivoTBG As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Tt_Info As System.Windows.Forms.ToolTip

End Class
