<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ImportarEstructura
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
        Me.Bt_ImportarDesdeArchivoXLS = New System.Windows.Forms.Button()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Bt_Importar = New System.Windows.Forms.Button()
        Me.Tlp_Botones = New System.Windows.Forms.TableLayoutPanel()
        Me.Flp_Estado = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_PegarDesdePortapapeles = New System.Windows.Forms.Button()
        Me.Dgv_Listado = New System.Windows.Forms.DataGridView()
        Me.Cms_Listado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PegarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BorrarColumnaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Flp_Botones.SuspendLayout()
        Me.Tlp_Botones.SuspendLayout()
        Me.Flp_Estado.SuspendLayout()
        CType(Me.Dgv_Listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_Listado.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bt_ImportarDesdeArchivoXLS
        '
        Me.Bt_ImportarDesdeArchivoXLS.AutoSize = True
        Me.Bt_ImportarDesdeArchivoXLS.Location = New System.Drawing.Point(3, 3)
        Me.Bt_ImportarDesdeArchivoXLS.Name = "Bt_ImportarDesdeArchivoXLS"
        Me.Bt_ImportarDesdeArchivoXLS.Size = New System.Drawing.Size(135, 23)
        Me.Bt_ImportarDesdeArchivoXLS.TabIndex = 0
        Me.Bt_ImportarDesdeArchivoXLS.Text = "Cargar desde archivo..."
        Me.Bt_ImportarDesdeArchivoXLS.UseVisualStyleBackColor = True
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cerrar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Importar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(504, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(504, 30)
        Me.Flp_Botones.TabIndex = 0
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cerrar.Location = New System.Drawing.Point(426, 3)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 0
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Bt_Importar
        '
        Me.Bt_Importar.Location = New System.Drawing.Point(345, 3)
        Me.Bt_Importar.Name = "Bt_Importar"
        Me.Bt_Importar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Importar.TabIndex = 1
        Me.Bt_Importar.Text = "Importar"
        Me.Bt_Importar.UseVisualStyleBackColor = True
        '
        'Tlp_Botones
        '
        Me.Tlp_Botones.ColumnCount = 2
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Botones.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.Tlp_Botones.Controls.Add(Me.Flp_Estado, 0, 0)
        Me.Tlp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tlp_Botones.Location = New System.Drawing.Point(0, 531)
        Me.Tlp_Botones.Name = "Tlp_Botones"
        Me.Tlp_Botones.RowCount = 1
        Me.Tlp_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Tlp_Botones.Size = New System.Drawing.Size(1008, 30)
        Me.Tlp_Botones.TabIndex = 0
        '
        'Flp_Estado
        '
        Me.Flp_Estado.Controls.Add(Me.Bt_ImportarDesdeArchivoXLS)
        Me.Flp_Estado.Controls.Add(Me.Bt_PegarDesdePortapapeles)
        Me.Flp_Estado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Estado.Location = New System.Drawing.Point(0, 0)
        Me.Flp_Estado.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Estado.Name = "Flp_Estado"
        Me.Flp_Estado.Size = New System.Drawing.Size(504, 30)
        Me.Flp_Estado.TabIndex = 1
        '
        'Bt_PegarDesdePortapapeles
        '
        Me.Bt_PegarDesdePortapapeles.AutoSize = True
        Me.Bt_PegarDesdePortapapeles.Location = New System.Drawing.Point(144, 3)
        Me.Bt_PegarDesdePortapapeles.Name = "Bt_PegarDesdePortapapeles"
        Me.Bt_PegarDesdePortapapeles.Size = New System.Drawing.Size(153, 23)
        Me.Bt_PegarDesdePortapapeles.TabIndex = 2
        Me.Bt_PegarDesdePortapapeles.Text = "Pegar desde el Portapapeles"
        Me.Bt_PegarDesdePortapapeles.UseVisualStyleBackColor = True
        '
        'Dgv_Listado
        '
        Me.Dgv_Listado.AllowUserToAddRows = False
        Me.Dgv_Listado.AllowUserToOrderColumns = True
        Me.Dgv_Listado.AllowUserToResizeRows = False
        Me.Dgv_Listado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Dgv_Listado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Listado.ContextMenuStrip = Me.Cms_Listado
        Me.Dgv_Listado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Listado.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Listado.Name = "Dgv_Listado"
        Me.Dgv_Listado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Listado.Size = New System.Drawing.Size(1008, 531)
        Me.Dgv_Listado.TabIndex = 0
        '
        'Cms_Listado
        '
        Me.Cms_Listado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PegarToolStripMenuItem, Me.ToolStripSeparator1, Me.BorrarColumnaToolStripMenuItem})
        Me.Cms_Listado.Name = "Cms_Listado"
        Me.Cms_Listado.Size = New System.Drawing.Size(157, 76)
        '
        'PegarToolStripMenuItem
        '
        Me.PegarToolStripMenuItem.Name = "PegarToolStripMenuItem"
        Me.PegarToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.PegarToolStripMenuItem.Text = "Pegar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(153, 6)
        '
        'BorrarColumnaToolStripMenuItem
        '
        Me.BorrarColumnaToolStripMenuItem.Name = "BorrarColumnaToolStripMenuItem"
        Me.BorrarColumnaToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.BorrarColumnaToolStripMenuItem.Text = "Borrar columna"
        '
        'Fr_ImportarEstructura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Bt_Cerrar
        Me.ClientSize = New System.Drawing.Size(1008, 561)
        Me.Controls.Add(Me.Dgv_Listado)
        Me.Controls.Add(Me.Tlp_Botones)
        Me.Name = "Fr_ImportarEstructura"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importar Estructura de Licitación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Flp_Botones.ResumeLayout(False)
        Me.Tlp_Botones.ResumeLayout(False)
        Me.Flp_Estado.ResumeLayout(False)
        Me.Flp_Estado.PerformLayout()
        CType(Me.Dgv_Listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_Listado.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Tlp_Botones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Dgv_Listado As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Cms_Listado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Bt_Importar As System.Windows.Forms.Button
    Friend WithEvents Flp_Estado As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents BorrarColumnaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PegarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Bt_ImportarDesdeArchivoXLS As System.Windows.Forms.Button
    Friend WithEvents Bt_PegarDesdePortapapeles As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
