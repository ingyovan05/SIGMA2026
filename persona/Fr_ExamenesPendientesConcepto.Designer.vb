<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_ExamenesPendientesConcepto
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
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Lb_TextoConfirmacion = New System.Windows.Forms.Label()
        Me.Tlp_Encabezado = New System.Windows.Forms.TableLayoutPanel()
        Me.Lb_TextoNombre = New System.Windows.Forms.Label()
        Me.Lb_Identificación = New System.Windows.Forms.Label()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Lb_TextoCodigo = New System.Windows.Forms.Label()
        Me.Dgv_Examenes = New System.Windows.Forms.DataGridView()
        Me.DGVTBC_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGBTBC_Base = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_Cargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_Registra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVTBC_FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Tlp_Encabezado.SuspendLayout()
        CType(Me.Dgv_Examenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(569, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "No"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(490, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Si"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Lb_TextoConfirmacion
        '
        Me.Lb_TextoConfirmacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoConfirmacion.Location = New System.Drawing.Point(363, 1)
        Me.Lb_TextoConfirmacion.Name = "Lb_TextoConfirmacion"
        Me.Lb_TextoConfirmacion.Size = New System.Drawing.Size(122, 23)
        Me.Lb_TextoConfirmacion.TabIndex = 13
        Me.Lb_TextoConfirmacion.Text = "¿Desea Continuar?"
        Me.Lb_TextoConfirmacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Tlp_Encabezado
        '
        Me.Tlp_Encabezado.ColumnCount = 4
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_TextoNombre, 0, 0)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_Identificación, 3, 0)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_Nombre, 1, 0)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_TextoCodigo, 2, 0)
        Me.Tlp_Encabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tlp_Encabezado.Location = New System.Drawing.Point(0, 0)
        Me.Tlp_Encabezado.Name = "Tlp_Encabezado"
        Me.Tlp_Encabezado.RowCount = 1
        Me.Tlp_Encabezado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Encabezado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.Tlp_Encabezado.Size = New System.Drawing.Size(650, 41)
        Me.Tlp_Encabezado.TabIndex = 4
        '
        'Lb_TextoNombre
        '
        Me.Lb_TextoNombre.AutoSize = True
        Me.Lb_TextoNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoNombre.Location = New System.Drawing.Point(3, 0)
        Me.Lb_TextoNombre.Name = "Lb_TextoNombre"
        Me.Lb_TextoNombre.Size = New System.Drawing.Size(47, 41)
        Me.Lb_TextoNombre.TabIndex = 0
        Me.Lb_TextoNombre.Text = "Nombre:"
        Me.Lb_TextoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_Identificación
        '
        Me.Lb_Identificación.AutoSize = True
        Me.Lb_Identificación.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Identificación.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Identificación.Location = New System.Drawing.Point(212, 0)
        Me.Lb_Identificación.Name = "Lb_Identificación"
        Me.Lb_Identificación.Size = New System.Drawing.Size(435, 41)
        Me.Lb_Identificación.TabIndex = 3
        Me.Lb_Identificación.Text = "Lb_Identificacion"
        Me.Lb_Identificación.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.Location = New System.Drawing.Point(56, 0)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(71, 41)
        Me.Lb_Nombre.TabIndex = 1
        Me.Lb_Nombre.Text = "Lb_Nombre"
        Me.Lb_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_TextoCodigo
        '
        Me.Lb_TextoCodigo.AutoSize = True
        Me.Lb_TextoCodigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoCodigo.Location = New System.Drawing.Point(133, 0)
        Me.Lb_TextoCodigo.Name = "Lb_TextoCodigo"
        Me.Lb_TextoCodigo.Size = New System.Drawing.Size(73, 41)
        Me.Lb_TextoCodigo.TabIndex = 2
        Me.Lb_TextoCodigo.Text = "Identificación:"
        Me.Lb_TextoCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dgv_Examenes
        '
        Me.Dgv_Examenes.AllowUserToAddRows = False
        Me.Dgv_Examenes.AllowUserToDeleteRows = False
        Me.Dgv_Examenes.AllowUserToOrderColumns = True
        Me.Dgv_Examenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_Examenes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Examenes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_Examenes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Examenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Examenes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVTBC_Id, Me.DGBTBC_Base, Me.DGVTBC_Fecha, Me.DGVTBC_Cargo, Me.DGVTBC_Motivo, Me.DGVTBC_Registra, Me.DGVTBC_FechaRegistro})
        Me.Dgv_Examenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Examenes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Dgv_Examenes.Location = New System.Drawing.Point(0, 41)
        Me.Dgv_Examenes.Name = "Dgv_Examenes"
        Me.Dgv_Examenes.Size = New System.Drawing.Size(650, 229)
        Me.Dgv_Examenes.TabIndex = 5
        '
        'DGVTBC_Id
        '
        Me.DGVTBC_Id.DataPropertyName = "IDENVIOEXAMEN"
        Me.DGVTBC_Id.HeaderText = "Id"
        Me.DGVTBC_Id.Name = "DGVTBC_Id"
        Me.DGVTBC_Id.ReadOnly = True
        Me.DGVTBC_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVTBC_Id.ToolTipText = "Id Examen"
        Me.DGVTBC_Id.Width = 22
        '
        'DGBTBC_Base
        '
        Me.DGBTBC_Base.DataPropertyName = "BASE"
        Me.DGBTBC_Base.HeaderText = "Base"
        Me.DGBTBC_Base.Name = "DGBTBC_Base"
        Me.DGBTBC_Base.ReadOnly = True
        Me.DGBTBC_Base.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGBTBC_Base.ToolTipText = "Base"
        Me.DGBTBC_Base.Width = 37
        '
        'DGVTBC_Fecha
        '
        Me.DGVTBC_Fecha.DataPropertyName = "FECHAENVIO"
        Me.DGVTBC_Fecha.HeaderText = "Fecha Envío"
        Me.DGVTBC_Fecha.Name = "DGVTBC_Fecha"
        Me.DGVTBC_Fecha.ReadOnly = True
        Me.DGVTBC_Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVTBC_Fecha.ToolTipText = "Fecha Envío"
        Me.DGVTBC_Fecha.Width = 75
        '
        'DGVTBC_Cargo
        '
        Me.DGVTBC_Cargo.DataPropertyName = "CARGO"
        Me.DGVTBC_Cargo.HeaderText = "Cargo"
        Me.DGVTBC_Cargo.Name = "DGVTBC_Cargo"
        Me.DGVTBC_Cargo.ReadOnly = True
        Me.DGVTBC_Cargo.Width = 60
        '
        'DGVTBC_Motivo
        '
        Me.DGVTBC_Motivo.DataPropertyName = "MOTIVO"
        Me.DGVTBC_Motivo.HeaderText = "Motivo"
        Me.DGVTBC_Motivo.Name = "DGVTBC_Motivo"
        Me.DGVTBC_Motivo.ReadOnly = True
        Me.DGVTBC_Motivo.Width = 64
        '
        'DGVTBC_Registra
        '
        Me.DGVTBC_Registra.DataPropertyName = "USUARIOREGISTRA"
        Me.DGVTBC_Registra.HeaderText = "Usuario Registra"
        Me.DGVTBC_Registra.Name = "DGVTBC_Registra"
        Me.DGVTBC_Registra.ToolTipText = "Usuario Registra"
        Me.DGVTBC_Registra.Width = 110
        '
        'DGVTBC_FechaRegistro
        '
        Me.DGVTBC_FechaRegistro.DataPropertyName = "FECHAREGISTRO"
        Me.DGVTBC_FechaRegistro.HeaderText = "Fecha Registro"
        Me.DGVTBC_FechaRegistro.Name = "DGVTBC_FechaRegistro"
        Me.DGVTBC_FechaRegistro.ToolTipText = "Fecha Registro"
        Me.DGVTBC_FechaRegistro.Width = 104
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDENVIOEXAMEN"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id Examén"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.ToolTipText = "Id Examén"
        Me.DataGridViewTextBoxColumn1.Width = 89
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "BASE"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Base"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.ToolTipText = "Base"
        Me.DataGridViewTextBoxColumn2.Width = 88
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "FECHAENVIO"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha Envio"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.ToolTipText = "Fecha Envio"
        Me.DataGridViewTextBoxColumn3.Width = 89
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "USUARIOREGISTRA"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Usuario Registra"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.ToolTipText = "Usuario Registra"
        Me.DataGridViewTextBoxColumn4.Width = 88
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "FECHAREGISTRO"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Fecha Registro"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.ToolTipText = "Fecha Registro"
        Me.DataGridViewTextBoxColumn5.Width = 89
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "USUARIOREGISTRA"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Usuario Registra"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ToolTipText = "Usuario Registra"
        Me.DataGridViewTextBoxColumn6.Width = 105
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "FECHAREGISTRO"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Fecha Registro"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ToolTipText = "Fecha Registro"
        Me.DataGridViewTextBoxColumn7.Width = 104
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.Color.Silver
        Me.Pn_Botones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_Botones.Controls.Add(Me.Lb_TextoConfirmacion)
        Me.Pn_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 240)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(650, 30)
        Me.Pn_Botones.TabIndex = 6
        '
        'Fr_ExamenesPendientesConcepto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 270)
        Me.Controls.Add(Me.Pn_Botones)
        Me.Controls.Add(Me.Dgv_Examenes)
        Me.Controls.Add(Me.Tlp_Encabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(666, 309)
        Me.MinimumSize = New System.Drawing.Size(666, 309)
        Me.Name = "Fr_ExamenesPendientesConcepto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exámenes Pendientes Por Concepto"
        Me.Tlp_Encabezado.ResumeLayout(False)
        Me.Tlp_Encabezado.PerformLayout()
        CType(Me.Dgv_Examenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Tlp_Encabezado As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lb_TextoNombre As System.Windows.Forms.Label
    Friend WithEvents Lb_Identificación As System.Windows.Forms.Label
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCodigo As System.Windows.Forms.Label
    Friend WithEvents Dgv_Examenes As System.Windows.Forms.DataGridView
    Friend WithEvents Lb_TextoConfirmacion As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGBTBC_Base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_Cargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_Motivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_Registra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVTBC_FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
End Class
