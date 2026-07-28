<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ArticulosSinValorReferencia
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Dgv_ArticulosSinValorReferencia = New System.Windows.Forms.DataGridView()
        Me.IDARTICULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREDESCRIPTIVO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALORREFERENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAMODIFICACIONREF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dgv_ArticulosSinValorReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 347)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(788, 55)
        Me.Panel1.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(595, 22)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(181, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(111, 3)
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
        Me.OK_Button.Size = New System.Drawing.Size(102, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Guardar e Imprimir"
        '
        'Dgv_ArticulosSinValorReferencia
        '
        Me.Dgv_ArticulosSinValorReferencia.AllowUserToAddRows = False
        Me.Dgv_ArticulosSinValorReferencia.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_ArticulosSinValorReferencia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_ArticulosSinValorReferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ArticulosSinValorReferencia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDARTICULO, Me.NOMBREDESCRIPTIVO, Me.VALORREFERENCIA, Me.FECHAMODIFICACIONREF})
        Me.Dgv_ArticulosSinValorReferencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ArticulosSinValorReferencia.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_ArticulosSinValorReferencia.Name = "Dgv_ArticulosSinValorReferencia"
        Me.Dgv_ArticulosSinValorReferencia.Size = New System.Drawing.Size(788, 347)
        Me.Dgv_ArticulosSinValorReferencia.TabIndex = 6
        '
        'IDARTICULO
        '
        Me.IDARTICULO.DataPropertyName = "IDARTICULO"
        Me.IDARTICULO.HeaderText = "Id. Artículo"
        Me.IDARTICULO.Name = "IDARTICULO"
        Me.IDARTICULO.ReadOnly = True
        Me.IDARTICULO.Width = 90
        '
        'NOMBREDESCRIPTIVO
        '
        Me.NOMBREDESCRIPTIVO.DataPropertyName = "NOMBREDESCRIPTIVO"
        Me.NOMBREDESCRIPTIVO.HeaderText = "Nombre Descriptivo"
        Me.NOMBREDESCRIPTIVO.Name = "NOMBREDESCRIPTIVO"
        Me.NOMBREDESCRIPTIVO.ReadOnly = True
        Me.NOMBREDESCRIPTIVO.Width = 334
        '
        'VALORREFERENCIA
        '
        Me.VALORREFERENCIA.DataPropertyName = "VALORREFERENCIA"
        DataGridViewCellStyle2.Format = "C0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.VALORREFERENCIA.DefaultCellStyle = DataGridViewCellStyle2
        Me.VALORREFERENCIA.HeaderText = "Valor de Referencia"
        Me.VALORREFERENCIA.Name = "VALORREFERENCIA"
        Me.VALORREFERENCIA.Width = 130
        '
        'FECHAMODIFICACIONREF
        '
        Me.FECHAMODIFICACIONREF.DataPropertyName = "FECHAMODIFICACIONREF"
        Me.FECHAMODIFICACIONREF.HeaderText = "Fecha de Modificación del Valor"
        Me.FECHAMODIFICACIONREF.Name = "FECHAMODIFICACIONREF"
        Me.FECHAMODIFICACIONREF.ReadOnly = True
        Me.FECHAMODIFICACIONREF.Width = 190
        '
        'Fr_ArticulosSinValorReferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 402)
        Me.Controls.Add(Me.Dgv_ArticulosSinValorReferencia)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Fr_ArticulosSinValorReferencia"
        Me.Text = "Artículos sin Valor de Referencia"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dgv_ArticulosSinValorReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Dgv_ArticulosSinValorReferencia As System.Windows.Forms.DataGridView
    Friend WithEvents IDARTICULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDESCRIPTIVO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALORREFERENCIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAMODIFICACIONREF As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
