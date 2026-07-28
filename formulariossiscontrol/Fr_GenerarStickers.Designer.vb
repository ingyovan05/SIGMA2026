<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_GenerarStickers
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
        Me.Lb_TextoCantidadHojas = New System.Windows.Forms.Label()
        Me.Nud_CantidadHojas = New System.Windows.Forms.NumericUpDown()
        Me.Lb_TextoCantidadStickers = New System.Windows.Forms.Label()
        Me.Tlp_GenerarStickers = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Lb_CantidadStickers = New System.Windows.Forms.Label()
        CType(Me.Nud_CantidadHojas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tlp_GenerarStickers.SuspendLayout()
        Me.Flp_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lb_TextoCantidadHojas
        '
        Me.Lb_TextoCantidadHojas.AutoSize = True
        Me.Lb_TextoCantidadHojas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoCantidadHojas.Location = New System.Drawing.Point(3, 0)
        Me.Lb_TextoCantidadHojas.Name = "Lb_TextoCantidadHojas"
        Me.Lb_TextoCantidadHojas.Size = New System.Drawing.Size(95, 26)
        Me.Lb_TextoCantidadHojas.TabIndex = 0
        Me.Lb_TextoCantidadHojas.Text = "Cantidad de hojas:"
        Me.Lb_TextoCantidadHojas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Nud_CantidadHojas
        '
        Me.Nud_CantidadHojas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Nud_CantidadHojas.Location = New System.Drawing.Point(104, 3)
        Me.Nud_CantidadHojas.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.Nud_CantidadHojas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_CantidadHojas.Name = "Nud_CantidadHojas"
        Me.Nud_CantidadHojas.Size = New System.Drawing.Size(40, 20)
        Me.Nud_CantidadHojas.TabIndex = 1
        Me.Nud_CantidadHojas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Lb_TextoCantidadStickers
        '
        Me.Lb_TextoCantidadStickers.AutoSize = True
        Me.Lb_TextoCantidadStickers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoCantidadStickers.Location = New System.Drawing.Point(150, 0)
        Me.Lb_TextoCantidadStickers.Name = "Lb_TextoCantidadStickers"
        Me.Lb_TextoCantidadStickers.Size = New System.Drawing.Size(90, 26)
        Me.Lb_TextoCantidadStickers.TabIndex = 2
        Me.Lb_TextoCantidadStickers.Text = "Total de Stickers:"
        Me.Lb_TextoCantidadStickers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Tlp_GenerarStickers
        '
        Me.Tlp_GenerarStickers.AutoSize = True
        Me.Tlp_GenerarStickers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Tlp_GenerarStickers.ColumnCount = 4
        Me.Tlp_GenerarStickers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_GenerarStickers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_GenerarStickers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_GenerarStickers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_GenerarStickers.Controls.Add(Me.Lb_CantidadStickers, 3, 0)
        Me.Tlp_GenerarStickers.Controls.Add(Me.Lb_TextoCantidadHojas, 0, 0)
        Me.Tlp_GenerarStickers.Controls.Add(Me.Nud_CantidadHojas, 1, 0)
        Me.Tlp_GenerarStickers.Controls.Add(Me.Lb_TextoCantidadStickers, 2, 0)
        Me.Tlp_GenerarStickers.Location = New System.Drawing.Point(12, 12)
        Me.Tlp_GenerarStickers.Name = "Tlp_GenerarStickers"
        Me.Tlp_GenerarStickers.RowCount = 1
        Me.Tlp_GenerarStickers.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_GenerarStickers.Size = New System.Drawing.Size(270, 26)
        Me.Tlp_GenerarStickers.TabIndex = 0
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 55)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(308, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(230, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(149, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Generar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Lb_CantidadStickers
        '
        Me.Lb_CantidadStickers.AutoSize = True
        Me.Lb_CantidadStickers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_CantidadStickers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CantidadStickers.Location = New System.Drawing.Point(246, 0)
        Me.Lb_CantidadStickers.Name = "Lb_CantidadStickers"
        Me.Lb_CantidadStickers.Size = New System.Drawing.Size(21, 26)
        Me.Lb_CantidadStickers.TabIndex = 2
        Me.Lb_CantidadStickers.Text = "30"
        Me.Lb_CantidadStickers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Fr_GenerarStickers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 85)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Controls.Add(Me.Tlp_GenerarStickers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Fr_GenerarStickers"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generar Stickers de Documentos"
        CType(Me.Nud_CantidadHojas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tlp_GenerarStickers.ResumeLayout(False)
        Me.Tlp_GenerarStickers.PerformLayout()
        Me.Flp_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lb_TextoCantidadHojas As System.Windows.Forms.Label
    Friend WithEvents Nud_CantidadHojas As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lb_TextoCantidadStickers As System.Windows.Forms.Label
    Friend WithEvents Tlp_GenerarStickers As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Lb_CantidadStickers As System.Windows.Forms.Label
End Class
