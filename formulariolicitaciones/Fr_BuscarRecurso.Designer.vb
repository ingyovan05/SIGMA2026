<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_BuscarRecurso
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
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Bt_Insertar = New System.Windows.Forms.Button()
        Me.Dgv_Buscar = New System.Windows.Forms.DataGridView()
        Me.Gb_Filtro = New System.Windows.Forms.GroupBox()
        Me.Ck_Filtrar = New System.Windows.Forms.CheckBox()
        Me.Cb_Filtrar = New System.Windows.Forms.ComboBox()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Pn_Criterios = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Bt_AgregarRecurso = New System.Windows.Forms.Button()
        Me.Flp_Botones.SuspendLayout()
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gb_Filtro.SuspendLayout()
        Me.Pn_Criterios.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cerrar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Insertar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(103, 0)
        Me.Flp_Botones.Margin = New System.Windows.Forms.Padding(0)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(661, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cerrar.Location = New System.Drawing.Point(583, 3)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 1
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Bt_Insertar
        '
        Me.Bt_Insertar.Location = New System.Drawing.Point(502, 3)
        Me.Bt_Insertar.Name = "Bt_Insertar"
        Me.Bt_Insertar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Insertar.TabIndex = 0
        Me.Bt_Insertar.Text = "Insertar"
        Me.Bt_Insertar.UseVisualStyleBackColor = True
        '
        'Dgv_Buscar
        '
        Me.Dgv_Buscar.AllowUserToAddRows = False
        Me.Dgv_Buscar.AllowUserToDeleteRows = False
        Me.Dgv_Buscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Buscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Buscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Buscar.Location = New System.Drawing.Point(0, 60)
        Me.Dgv_Buscar.MultiSelect = False
        Me.Dgv_Buscar.Name = "Dgv_Buscar"
        Me.Dgv_Buscar.ReadOnly = True
        Me.Dgv_Buscar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Buscar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Buscar.Size = New System.Drawing.Size(764, 252)
        Me.Dgv_Buscar.TabIndex = 1
        '
        'Gb_Filtro
        '
        Me.Gb_Filtro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Gb_Filtro.Controls.Add(Me.Ck_Filtrar)
        Me.Gb_Filtro.Controls.Add(Me.Cb_Filtrar)
        Me.Gb_Filtro.Controls.Add(Me.Tx_Descripcion)
        Me.Gb_Filtro.Location = New System.Drawing.Point(3, 3)
        Me.Gb_Filtro.Name = "Gb_Filtro"
        Me.Gb_Filtro.Size = New System.Drawing.Size(749, 46)
        Me.Gb_Filtro.TabIndex = 0
        Me.Gb_Filtro.TabStop = False
        Me.Gb_Filtro.Text = "Filtro"
        '
        'Ck_Filtrar
        '
        Me.Ck_Filtrar.AutoSize = True
        Me.Ck_Filtrar.Checked = True
        Me.Ck_Filtrar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ck_Filtrar.Location = New System.Drawing.Point(13, 19)
        Me.Ck_Filtrar.Name = "Ck_Filtrar"
        Me.Ck_Filtrar.Size = New System.Drawing.Size(15, 14)
        Me.Ck_Filtrar.TabIndex = 0
        Me.Ck_Filtrar.UseVisualStyleBackColor = True
        '
        'Cb_Filtrar
        '
        Me.Cb_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Filtrar.FormattingEnabled = True
        Me.Cb_Filtrar.Location = New System.Drawing.Point(34, 16)
        Me.Cb_Filtrar.Name = "Cb_Filtrar"
        Me.Cb_Filtrar.Size = New System.Drawing.Size(210, 21)
        Me.Cb_Filtrar.TabIndex = 1
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_Descripcion.Location = New System.Drawing.Point(256, 17)
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(486, 20)
        Me.Tx_Descripcion.TabIndex = 2
        '
        'Pn_Criterios
        '
        Me.Pn_Criterios.Controls.Add(Me.Gb_Filtro)
        Me.Pn_Criterios.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Criterios.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Criterios.Name = "Pn_Criterios"
        Me.Pn_Criterios.Size = New System.Drawing.Size(764, 60)
        Me.Pn_Criterios.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Silver
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Flp_Botones, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Bt_AgregarRecurso, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 312)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(764, 30)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Bt_AgregarRecurso
        '
        Me.Bt_AgregarRecurso.AutoSize = True
        Me.Bt_AgregarRecurso.Location = New System.Drawing.Point(3, 3)
        Me.Bt_AgregarRecurso.Name = "Bt_AgregarRecurso"
        Me.Bt_AgregarRecurso.Size = New System.Drawing.Size(97, 23)
        Me.Bt_AgregarRecurso.TabIndex = 0
        Me.Bt_AgregarRecurso.Text = "Agregar Recurso"
        Me.Bt_AgregarRecurso.UseVisualStyleBackColor = True
        '
        'Fr_BuscarRecurso
        '
        Me.AcceptButton = Me.Bt_Insertar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Bt_Cerrar
        Me.ClientSize = New System.Drawing.Size(764, 342)
        Me.Controls.Add(Me.Dgv_Buscar)
        Me.Controls.Add(Me.Pn_Criterios)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_BuscarRecurso"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Buscar Recurso"
        Me.Flp_Botones.ResumeLayout(False)
        CType(Me.Dgv_Buscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gb_Filtro.ResumeLayout(False)
        Me.Gb_Filtro.PerformLayout()
        Me.Pn_Criterios.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Dgv_Buscar As System.Windows.Forms.DataGridView
    Friend WithEvents Gb_Filtro As System.Windows.Forms.GroupBox
    Friend WithEvents Pn_Criterios As System.Windows.Forms.Panel
    Friend WithEvents Ck_Filtrar As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Filtrar As System.Windows.Forms.ComboBox
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Bt_Insertar As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Bt_AgregarRecurso As System.Windows.Forms.Button
End Class
