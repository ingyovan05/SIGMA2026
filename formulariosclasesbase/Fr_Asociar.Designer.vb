<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Asociar
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
        Me.Bt_SinAsociar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Tb_Identificador = New System.Windows.Forms.TextBox()
        Me.ComboBox_Filtrar = New System.Windows.Forms.ComboBox()
        Me.Bt_Buscar = New System.Windows.Forms.Button()
        Me.Dgv_Buscar = New System.Windows.Forms.DataGridView()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel2.Controls.Add(Me.Bt_SinAsociar)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 377)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(629, 33)
        Me.Panel2.TabIndex = 11
        '
        'Bt_SinAsociar
        '
        Me.Bt_SinAsociar.Location = New System.Drawing.Point(399, 6)
        Me.Bt_SinAsociar.Name = "Bt_SinAsociar"
        Me.Bt_SinAsociar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_SinAsociar.TabIndex = 1
        Me.Bt_SinAsociar.Text = "Sin Asociar"
        Me.Bt_SinAsociar.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(480, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Tb_Identificador)
        Me.Panel1.Controls.Add(Me.ComboBox_Filtrar)
        Me.Panel1.Controls.Add(Me.Bt_Buscar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(629, 40)
        Me.Panel1.TabIndex = 12
        '
        'Tb_Identificador
        '
        Me.Tb_Identificador.Location = New System.Drawing.Point(187, 12)
        Me.Tb_Identificador.Name = "Tb_Identificador"
        Me.Tb_Identificador.Size = New System.Drawing.Size(233, 20)
        Me.Tb_Identificador.TabIndex = 0
        '
        'ComboBox_Filtrar
        '
        Me.ComboBox_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Filtrar.FormattingEnabled = True
        Me.ComboBox_Filtrar.Location = New System.Drawing.Point(10, 12)
        Me.ComboBox_Filtrar.Name = "ComboBox_Filtrar"
        Me.ComboBox_Filtrar.Size = New System.Drawing.Size(171, 21)
        Me.ComboBox_Filtrar.TabIndex = 2
        '
        'Bt_Buscar
        '
        Me.Bt_Buscar.Location = New System.Drawing.Point(426, 10)
        Me.Bt_Buscar.Name = "Bt_Buscar"
        Me.Bt_Buscar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Buscar.TabIndex = 14
        Me.Bt_Buscar.Text = "Buscar"
        Me.Bt_Buscar.UseVisualStyleBackColor = True
        '
        'Dgv_Buscar
        '
        Me.Dgv_Buscar.AllowUserToAddRows = False
        Me.Dgv_Buscar.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Buscar.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Buscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Buscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Buscar.Location = New System.Drawing.Point(0, 40)
        Me.Dgv_Buscar.Name = "Dgv_Buscar"
        Me.Dgv_Buscar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Buscar.Size = New System.Drawing.Size(629, 337)
        Me.Dgv_Buscar.TabIndex = 13
        '
        'Fr_Asociar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 410)
        Me.Controls.Add(Me.Dgv_Buscar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_Asociar"
        Me.Text = "Buscar"
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Tb_Identificador As System.Windows.Forms.TextBox
    Public WithEvents ComboBox_Filtrar As System.Windows.Forms.ComboBox
    Friend WithEvents Bt_Buscar As System.Windows.Forms.Button
    Friend WithEvents Dgv_Buscar As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_SinAsociar As System.Windows.Forms.Button
End Class
