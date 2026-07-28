<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_GestionarActividadPrincipal
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
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Dgv_Actividades = New System.Windows.Forms.DataGridView()
        Me.IDACTIVIDADPRINCIPAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDBODEGA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOACTIVIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREACTIVIDADPRINCIPAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADOACTIVIDADPRINCIPAL = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Tx_CrearActividad = New System.Windows.Forms.TextBox()
        Me.Lb_CrearActividad = New System.Windows.Forms.Label()
        Me.Bt_CrearActividad = New System.Windows.Forms.Button()
        Me.Pn_CrearActividad = New System.Windows.Forms.Panel()
        Me.Ck_HabilitarCrearActividad = New System.Windows.Forms.CheckBox()
        Me.Flp_Botones.SuspendLayout()
        CType(Me.Dgv_Actividades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_CrearActividad.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 406)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Padding = New System.Windows.Forms.Padding(3)
        Me.Flp_Botones.Size = New System.Drawing.Size(624, 36)
        Me.Flp_Botones.TabIndex = 2
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.Location = New System.Drawing.Point(540, 6)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(459, 6)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Dgv_Actividades
        '
        Me.Dgv_Actividades.AllowUserToAddRows = False
        Me.Dgv_Actividades.AllowUserToDeleteRows = False
        Me.Dgv_Actividades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Dgv_Actividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Actividades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDACTIVIDADPRINCIPAL, Me.IDBODEGA, Me.CODIGOACTIVIDAD, Me.NOMBREACTIVIDADPRINCIPAL, Me.ESTADOACTIVIDADPRINCIPAL})
        Me.Dgv_Actividades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Actividades.Location = New System.Drawing.Point(0, 50)
        Me.Dgv_Actividades.MultiSelect = False
        Me.Dgv_Actividades.Name = "Dgv_Actividades"
        Me.Dgv_Actividades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Actividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Actividades.Size = New System.Drawing.Size(624, 356)
        Me.Dgv_Actividades.TabIndex = 1
        '
        'IDACTIVIDADPRINCIPAL
        '
        Me.IDACTIVIDADPRINCIPAL.DataPropertyName = "IDACTIVIDADPRINCIPAL"
        Me.IDACTIVIDADPRINCIPAL.HeaderText = "IdActividadPrincipal"
        Me.IDACTIVIDADPRINCIPAL.Name = "IDACTIVIDADPRINCIPAL"
        Me.IDACTIVIDADPRINCIPAL.ReadOnly = True
        Me.IDACTIVIDADPRINCIPAL.Visible = False
        '
        'IDBODEGA
        '
        Me.IDBODEGA.DataPropertyName = "IDBODEGA"
        Me.IDBODEGA.HeaderText = "IdBodega"
        Me.IDBODEGA.Name = "IDBODEGA"
        Me.IDBODEGA.ReadOnly = True
        Me.IDBODEGA.Visible = False
        '
        'CODIGOACTIVIDAD
        '
        Me.CODIGOACTIVIDAD.DataPropertyName = "CODIGOACTIVIDAD"
        Me.CODIGOACTIVIDAD.HeaderText = "Código"
        Me.CODIGOACTIVIDAD.Name = "CODIGOACTIVIDAD"
        Me.CODIGOACTIVIDAD.ReadOnly = True
        Me.CODIGOACTIVIDAD.Width = 65
        '
        'NOMBREACTIVIDADPRINCIPAL
        '
        Me.NOMBREACTIVIDADPRINCIPAL.DataPropertyName = "NOMBREACTIVIDADPRINCIPAL"
        Me.NOMBREACTIVIDADPRINCIPAL.HeaderText = "Actividad Principal"
        Me.NOMBREACTIVIDADPRINCIPAL.Name = "NOMBREACTIVIDADPRINCIPAL"
        Me.NOMBREACTIVIDADPRINCIPAL.ReadOnly = True
        Me.NOMBREACTIVIDADPRINCIPAL.Width = 430
        '
        'ESTADOACTIVIDADPRINCIPAL
        '
        Me.ESTADOACTIVIDADPRINCIPAL.DataPropertyName = "ESTADOACTIVIDADPRINCIPAL"
        Me.ESTADOACTIVIDADPRINCIPAL.FalseValue = "I"
        Me.ESTADOACTIVIDADPRINCIPAL.HeaderText = "Estado"
        Me.ESTADOACTIVIDADPRINCIPAL.Name = "ESTADOACTIVIDADPRINCIPAL"
        Me.ESTADOACTIVIDADPRINCIPAL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ESTADOACTIVIDADPRINCIPAL.TrueValue = "A"
        Me.ESTADOACTIVIDADPRINCIPAL.Width = 65
        '
        'Tx_CrearActividad
        '
        Me.Tx_CrearActividad.Enabled = False
        Me.Tx_CrearActividad.Location = New System.Drawing.Point(118, 20)
        Me.Tx_CrearActividad.Name = "Tx_CrearActividad"
        Me.Tx_CrearActividad.Size = New System.Drawing.Size(466, 20)
        Me.Tx_CrearActividad.TabIndex = 2
        '
        'Lb_CrearActividad
        '
        Me.Lb_CrearActividad.AutoSize = True
        Me.Lb_CrearActividad.Location = New System.Drawing.Point(33, 23)
        Me.Lb_CrearActividad.Name = "Lb_CrearActividad"
        Me.Lb_CrearActividad.Size = New System.Drawing.Size(82, 13)
        Me.Lb_CrearActividad.TabIndex = 1
        Me.Lb_CrearActividad.Text = "Crear Actividad:"
        '
        'Bt_CrearActividad
        '
        Me.Bt_CrearActividad.Enabled = False
        Me.Bt_CrearActividad.Location = New System.Drawing.Point(590, 19)
        Me.Bt_CrearActividad.Name = "Bt_CrearActividad"
        Me.Bt_CrearActividad.Size = New System.Drawing.Size(22, 22)
        Me.Bt_CrearActividad.TabIndex = 3
        Me.Bt_CrearActividad.Text = "+"
        Me.Bt_CrearActividad.UseVisualStyleBackColor = True
        '
        'Pn_CrearActividad
        '
        Me.Pn_CrearActividad.Controls.Add(Me.Ck_HabilitarCrearActividad)
        Me.Pn_CrearActividad.Controls.Add(Me.Bt_CrearActividad)
        Me.Pn_CrearActividad.Controls.Add(Me.Tx_CrearActividad)
        Me.Pn_CrearActividad.Controls.Add(Me.Lb_CrearActividad)
        Me.Pn_CrearActividad.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_CrearActividad.Enabled = False
        Me.Pn_CrearActividad.Location = New System.Drawing.Point(0, 0)
        Me.Pn_CrearActividad.Name = "Pn_CrearActividad"
        Me.Pn_CrearActividad.Size = New System.Drawing.Size(624, 50)
        Me.Pn_CrearActividad.TabIndex = 0
        Me.Pn_CrearActividad.Visible = False
        '
        'Ck_HabilitarCrearActividad
        '
        Me.Ck_HabilitarCrearActividad.AutoSize = True
        Me.Ck_HabilitarCrearActividad.Location = New System.Drawing.Point(12, 23)
        Me.Ck_HabilitarCrearActividad.Name = "Ck_HabilitarCrearActividad"
        Me.Ck_HabilitarCrearActividad.Size = New System.Drawing.Size(15, 14)
        Me.Ck_HabilitarCrearActividad.TabIndex = 0
        Me.Ck_HabilitarCrearActividad.UseVisualStyleBackColor = True
        '
        'Fr_GestionarActividadPrincipal
        '
        Me.AcceptButton = Me.Bt_Aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Bt_Cancelar
        Me.ClientSize = New System.Drawing.Size(624, 442)
        Me.Controls.Add(Me.Dgv_Actividades)
        Me.Controls.Add(Me.Pn_CrearActividad)
        Me.Controls.Add(Me.Flp_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_GestionarActividadPrincipal"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionar Actividades Principales"
        Me.Flp_Botones.ResumeLayout(False)
        CType(Me.Dgv_Actividades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_CrearActividad.ResumeLayout(False)
        Me.Pn_CrearActividad.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Dgv_Actividades As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Tx_CrearActividad As System.Windows.Forms.TextBox
    Friend WithEvents Lb_CrearActividad As System.Windows.Forms.Label
    Friend WithEvents Bt_CrearActividad As System.Windows.Forms.Button
    Friend WithEvents Pn_CrearActividad As System.Windows.Forms.Panel
    Friend WithEvents Ck_HabilitarCrearActividad As System.Windows.Forms.CheckBox
    Friend WithEvents IDACTIVIDADPRINCIPAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDBODEGA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOACTIVIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREACTIVIDADPRINCIPAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADOACTIVIDADPRINCIPAL As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
