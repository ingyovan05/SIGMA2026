<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ImprimirSticker
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Nud_InicioImpresión = New System.Windows.Forms.NumericUpDown()
        Me.Lb_InicioImpresión = New System.Windows.Forms.Label()
        Me.Tx_Descripción = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cb_Formato = New System.Windows.Forms.ComboBox()
        Me.Dgv_Sticker = New System.Windows.Forms.DataGridView()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Nud_InicioImpresión, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Dgv_Sticker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 377)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(811, 33)
        Me.Panel2.TabIndex = 7
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(662, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 9
        Me.Cancel_Button.Text = "Cancelar"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 8
        Me.OK_Button.Text = "Imprimir"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Nud_InicioImpresión)
        Me.Panel1.Controls.Add(Me.Lb_InicioImpresión)
        Me.Panel1.Controls.Add(Me.Tx_Descripción)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(811, 98)
        Me.Panel1.TabIndex = 8
        '
        'Nud_InicioImpresión
        '
        Me.Nud_InicioImpresión.Location = New System.Drawing.Point(405, 12)
        Me.Nud_InicioImpresión.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.Nud_InicioImpresión.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_InicioImpresión.Name = "Nud_InicioImpresión"
        Me.Nud_InicioImpresión.Size = New System.Drawing.Size(41, 20)
        Me.Nud_InicioImpresión.TabIndex = 8
        Me.Nud_InicioImpresión.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Lb_InicioImpresión
        '
        Me.Lb_InicioImpresión.AutoSize = True
        Me.Lb_InicioImpresión.Location = New System.Drawing.Point(316, 14)
        Me.Lb_InicioImpresión.Name = "Lb_InicioImpresión"
        Me.Lb_InicioImpresión.Size = New System.Drawing.Size(83, 13)
        Me.Lb_InicioImpresión.TabIndex = 7
        Me.Lb_InicioImpresión.Text = "Inicio Impresión:"
        '
        'Tx_Descripción
        '
        Me.Tx_Descripción.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_Descripción.Location = New System.Drawing.Point(3, 53)
        Me.Tx_Descripción.Multiline = True
        Me.Tx_Descripción.Name = "Tx_Descripción"
        Me.Tx_Descripción.ReadOnly = True
        Me.Tx_Descripción.Size = New System.Drawing.Size(986, 40)
        Me.Tx_Descripción.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cb_Formato)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 46)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Formato"
        '
        'Cb_Formato
        '
        Me.Cb_Formato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Formato.FormattingEnabled = True
        Me.Cb_Formato.Items.AddRange(New Object() {"REF: 67*25 C3 x 30 Rótulos", "REF: 67*25 C3 x 30 Código Barras FREE3OF9", "REF: 67*25 C3 x 30 Rótulos Cód Barras  FREE3OF9", "REF: 67*25 C3 x 30 Rótulos Sistemas"})
        Me.Cb_Formato.Location = New System.Drawing.Point(6, 19)
        Me.Cb_Formato.Name = "Cb_Formato"
        Me.Cb_Formato.Size = New System.Drawing.Size(284, 21)
        Me.Cb_Formato.TabIndex = 5
        '
        'Dgv_Sticker
        '
        Me.Dgv_Sticker.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Sticker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Sticker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Sticker.Location = New System.Drawing.Point(0, 98)
        Me.Dgv_Sticker.Name = "Dgv_Sticker"
        Me.Dgv_Sticker.Size = New System.Drawing.Size(811, 279)
        Me.Dgv_Sticker.TabIndex = 9
        '
        'Fr_ImprimirSticker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 410)
        Me.Controls.Add(Me.Dgv_Sticker)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(827, 449)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(827, 449)
        Me.Name = "Fr_ImprimirSticker"
        Me.Text = "Imprimir Sticker"
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Nud_InicioImpresión, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Dgv_Sticker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Tx_Descripción As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_Formato As System.Windows.Forms.ComboBox
    Friend WithEvents Dgv_Sticker As System.Windows.Forms.DataGridView
    Friend WithEvents Nud_InicioImpresión As System.Windows.Forms.NumericUpDown
    Friend WithEvents Lb_InicioImpresión As System.Windows.Forms.Label
End Class
