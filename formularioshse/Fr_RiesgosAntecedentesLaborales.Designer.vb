<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_RiesgosAntecedentesLaborales
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
        Me.Tb_TiempoTrabajadoMeses = New System.Windows.Forms.TextBox()
        Me.Lb_TiempoTrabajadoMeses = New System.Windows.Forms.Label()
        Me.Tb_TiempoTrabajadoAños = New System.Windows.Forms.TextBox()
        Me.Lb_TiempoTrabajadoAños = New System.Windows.Forms.Label()
        Me.Lb_Empresa = New System.Windows.Forms.Label()
        Me.Tb_Empresa = New System.Windows.Forms.TextBox()
        Me.Tb_ARL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Tb_Cargo = New System.Windows.Forms.TextBox()
        Me.Lb_Cargo = New System.Windows.Forms.Label()
        Me.Tb_Turno = New System.Windows.Forms.TextBox()
        Me.Lb_Turno = New System.Windows.Forms.Label()
        Me.Tb_Jornada = New System.Windows.Forms.TextBox()
        Me.Lb_Jornada = New System.Windows.Forms.Label()
        Me.Tb_Secuela = New System.Windows.Forms.TextBox()
        Me.Lb_Secuela = New System.Windows.Forms.Label()
        Me.Tb_DiasIT = New System.Windows.Forms.TextBox()
        Me.Lb_DiasIT = New System.Windows.Forms.Label()
        Me.Tb_Origen = New System.Windows.Forms.TextBox()
        Me.Lb_Origen = New System.Windows.Forms.Label()
        Me.Tb_IT = New System.Windows.Forms.TextBox()
        Me.Lb_IT = New System.Windows.Forms.Label()
        Me.Dgv_Riesgos = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Bt_AgregarRiesgos = New System.Windows.Forms.Button()
        Me.Lb_Riesgos = New System.Windows.Forms.Label()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDITEMANTECEDENTELABORAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPERSONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVT_NROITEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVC_TipoRiesgo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DGVC_AgenteCausal = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Dgv_Riesgos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Pn_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tb_TiempoTrabajadoMeses
        '
        Me.Tb_TiempoTrabajadoMeses.Location = New System.Drawing.Point(454, 6)
        Me.Tb_TiempoTrabajadoMeses.Name = "Tb_TiempoTrabajadoMeses"
        Me.Tb_TiempoTrabajadoMeses.ReadOnly = True
        Me.Tb_TiempoTrabajadoMeses.Size = New System.Drawing.Size(30, 20)
        Me.Tb_TiempoTrabajadoMeses.TabIndex = 3
        '
        'Lb_TiempoTrabajadoMeses
        '
        Me.Lb_TiempoTrabajadoMeses.AutoSize = True
        Me.Lb_TiempoTrabajadoMeses.Location = New System.Drawing.Point(317, 10)
        Me.Lb_TiempoTrabajadoMeses.Name = "Lb_TiempoTrabajadoMeses"
        Me.Lb_TiempoTrabajadoMeses.Size = New System.Drawing.Size(130, 13)
        Me.Lb_TiempoTrabajadoMeses.TabIndex = 2
        Me.Lb_TiempoTrabajadoMeses.Text = "Tiempo Trabajado Meses:"
        '
        'Tb_TiempoTrabajadoAños
        '
        Me.Tb_TiempoTrabajadoAños.Location = New System.Drawing.Point(621, 6)
        Me.Tb_TiempoTrabajadoAños.Name = "Tb_TiempoTrabajadoAños"
        Me.Tb_TiempoTrabajadoAños.ReadOnly = True
        Me.Tb_TiempoTrabajadoAños.Size = New System.Drawing.Size(30, 20)
        Me.Tb_TiempoTrabajadoAños.TabIndex = 5
        '
        'Lb_TiempoTrabajadoAños
        '
        Me.Lb_TiempoTrabajadoAños.AutoSize = True
        Me.Lb_TiempoTrabajadoAños.Location = New System.Drawing.Point(491, 10)
        Me.Lb_TiempoTrabajadoAños.Name = "Lb_TiempoTrabajadoAños"
        Me.Lb_TiempoTrabajadoAños.Size = New System.Drawing.Size(123, 13)
        Me.Lb_TiempoTrabajadoAños.TabIndex = 4
        Me.Lb_TiempoTrabajadoAños.Text = "Tiempo Trabajado Años:"
        '
        'Lb_Empresa
        '
        Me.Lb_Empresa.AutoSize = True
        Me.Lb_Empresa.Location = New System.Drawing.Point(8, 10)
        Me.Lb_Empresa.Name = "Lb_Empresa"
        Me.Lb_Empresa.Size = New System.Drawing.Size(51, 13)
        Me.Lb_Empresa.TabIndex = 0
        Me.Lb_Empresa.Text = "Empresa:"
        '
        'Tb_Empresa
        '
        Me.Tb_Empresa.Location = New System.Drawing.Point(66, 6)
        Me.Tb_Empresa.Name = "Tb_Empresa"
        Me.Tb_Empresa.ReadOnly = True
        Me.Tb_Empresa.Size = New System.Drawing.Size(244, 20)
        Me.Tb_Empresa.TabIndex = 1
        '
        'Tb_ARL
        '
        Me.Tb_ARL.Location = New System.Drawing.Point(66, 39)
        Me.Tb_ARL.Name = "Tb_ARL"
        Me.Tb_ARL.ReadOnly = True
        Me.Tb_ARL.Size = New System.Drawing.Size(244, 20)
        Me.Tb_ARL.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ARL:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tb_Cargo)
        Me.GroupBox1.Controls.Add(Me.Lb_Cargo)
        Me.GroupBox1.Controls.Add(Me.Tb_Turno)
        Me.GroupBox1.Controls.Add(Me.Lb_Turno)
        Me.GroupBox1.Controls.Add(Me.Tb_Jornada)
        Me.GroupBox1.Controls.Add(Me.Lb_Jornada)
        Me.GroupBox1.Controls.Add(Me.Tb_Secuela)
        Me.GroupBox1.Controls.Add(Me.Lb_Secuela)
        Me.GroupBox1.Controls.Add(Me.Tb_DiasIT)
        Me.GroupBox1.Controls.Add(Me.Lb_DiasIT)
        Me.GroupBox1.Controls.Add(Me.Tb_Origen)
        Me.GroupBox1.Controls.Add(Me.Lb_Origen)
        Me.GroupBox1.Controls.Add(Me.Tb_IT)
        Me.GroupBox1.Controls.Add(Me.Lb_IT)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(682, 89)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alteración estado de salud en el periodo trabajado"
        '
        'Tb_Cargo
        '
        Me.Tb_Cargo.Location = New System.Drawing.Point(426, 54)
        Me.Tb_Cargo.Name = "Tb_Cargo"
        Me.Tb_Cargo.ReadOnly = True
        Me.Tb_Cargo.Size = New System.Drawing.Size(245, 20)
        Me.Tb_Cargo.TabIndex = 21
        '
        'Lb_Cargo
        '
        Me.Lb_Cargo.AutoSize = True
        Me.Lb_Cargo.Location = New System.Drawing.Point(382, 58)
        Me.Lb_Cargo.Name = "Lb_Cargo"
        Me.Lb_Cargo.Size = New System.Drawing.Size(38, 13)
        Me.Lb_Cargo.TabIndex = 20
        Me.Lb_Cargo.Text = "Cargo:"
        '
        'Tb_Turno
        '
        Me.Tb_Turno.Location = New System.Drawing.Point(323, 54)
        Me.Tb_Turno.Name = "Tb_Turno"
        Me.Tb_Turno.ReadOnly = True
        Me.Tb_Turno.Size = New System.Drawing.Size(30, 20)
        Me.Tb_Turno.TabIndex = 19
        '
        'Lb_Turno
        '
        Me.Lb_Turno.AutoSize = True
        Me.Lb_Turno.Location = New System.Drawing.Point(279, 58)
        Me.Lb_Turno.Name = "Lb_Turno"
        Me.Lb_Turno.Size = New System.Drawing.Size(38, 13)
        Me.Lb_Turno.TabIndex = 18
        Me.Lb_Turno.Text = "Turno:"
        '
        'Tb_Jornada
        '
        Me.Tb_Jornada.Location = New System.Drawing.Point(60, 54)
        Me.Tb_Jornada.Name = "Tb_Jornada"
        Me.Tb_Jornada.ReadOnly = True
        Me.Tb_Jornada.Size = New System.Drawing.Size(195, 20)
        Me.Tb_Jornada.TabIndex = 17
        '
        'Lb_Jornada
        '
        Me.Lb_Jornada.AutoSize = True
        Me.Lb_Jornada.Location = New System.Drawing.Point(6, 58)
        Me.Lb_Jornada.Name = "Lb_Jornada"
        Me.Lb_Jornada.Size = New System.Drawing.Size(48, 13)
        Me.Lb_Jornada.TabIndex = 16
        Me.Lb_Jornada.Text = "Jornada:"
        '
        'Tb_Secuela
        '
        Me.Tb_Secuela.Location = New System.Drawing.Point(426, 25)
        Me.Tb_Secuela.Name = "Tb_Secuela"
        Me.Tb_Secuela.ReadOnly = True
        Me.Tb_Secuela.Size = New System.Drawing.Size(245, 20)
        Me.Tb_Secuela.TabIndex = 15
        '
        'Lb_Secuela
        '
        Me.Lb_Secuela.AutoSize = True
        Me.Lb_Secuela.Location = New System.Drawing.Point(371, 28)
        Me.Lb_Secuela.Name = "Lb_Secuela"
        Me.Lb_Secuela.Size = New System.Drawing.Size(49, 13)
        Me.Lb_Secuela.TabIndex = 14
        Me.Lb_Secuela.Text = "Secuela:"
        '
        'Tb_DiasIT
        '
        Me.Tb_DiasIT.Location = New System.Drawing.Point(323, 25)
        Me.Tb_DiasIT.Name = "Tb_DiasIT"
        Me.Tb_DiasIT.ReadOnly = True
        Me.Tb_DiasIT.Size = New System.Drawing.Size(30, 20)
        Me.Tb_DiasIT.TabIndex = 13
        '
        'Lb_DiasIT
        '
        Me.Lb_DiasIT.AutoSize = True
        Me.Lb_DiasIT.Location = New System.Drawing.Point(273, 28)
        Me.Lb_DiasIT.Name = "Lb_DiasIT"
        Me.Lb_DiasIT.Size = New System.Drawing.Size(44, 13)
        Me.Lb_DiasIT.TabIndex = 12
        Me.Lb_DiasIT.Text = "Dias IT:"
        '
        'Tb_Origen
        '
        Me.Tb_Origen.Location = New System.Drawing.Point(155, 25)
        Me.Tb_Origen.Name = "Tb_Origen"
        Me.Tb_Origen.ReadOnly = True
        Me.Tb_Origen.Size = New System.Drawing.Size(100, 20)
        Me.Tb_Origen.TabIndex = 11
        '
        'Lb_Origen
        '
        Me.Lb_Origen.AutoSize = True
        Me.Lb_Origen.Location = New System.Drawing.Point(108, 28)
        Me.Lb_Origen.Name = "Lb_Origen"
        Me.Lb_Origen.Size = New System.Drawing.Size(41, 13)
        Me.Lb_Origen.TabIndex = 10
        Me.Lb_Origen.Text = "Origen:"
        '
        'Tb_IT
        '
        Me.Tb_IT.Location = New System.Drawing.Point(60, 24)
        Me.Tb_IT.Name = "Tb_IT"
        Me.Tb_IT.ReadOnly = True
        Me.Tb_IT.Size = New System.Drawing.Size(30, 20)
        Me.Tb_IT.TabIndex = 9
        '
        'Lb_IT
        '
        Me.Lb_IT.AutoSize = True
        Me.Lb_IT.Location = New System.Drawing.Point(34, 27)
        Me.Lb_IT.Name = "Lb_IT"
        Me.Lb_IT.Size = New System.Drawing.Size(20, 13)
        Me.Lb_IT.TabIndex = 8
        Me.Lb_IT.Text = "IT:"
        '
        'Dgv_Riesgos
        '
        Me.Dgv_Riesgos.AllowUserToAddRows = False
        Me.Dgv_Riesgos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Riesgos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDITEMANTECEDENTELABORAL, Me.IDPERSONA, Me.DGVT_NROITEM, Me.DGVC_TipoRiesgo, Me.DGVC_AgenteCausal})
        Me.Dgv_Riesgos.Location = New System.Drawing.Point(0, 186)
        Me.Dgv_Riesgos.Name = "Dgv_Riesgos"
        Me.Dgv_Riesgos.Size = New System.Drawing.Size(705, 163)
        Me.Dgv_Riesgos.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.Bt_AgregarRiesgos)
        Me.Panel2.Controls.Add(Me.Lb_Riesgos)
        Me.Panel2.Location = New System.Drawing.Point(0, 160)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(705, 26)
        Me.Panel2.TabIndex = 142
        '
        'Bt_AgregarRiesgos
        '
        Me.Bt_AgregarRiesgos.Location = New System.Drawing.Point(75, 3)
        Me.Bt_AgregarRiesgos.Name = "Bt_AgregarRiesgos"
        Me.Bt_AgregarRiesgos.Size = New System.Drawing.Size(60, 21)
        Me.Bt_AgregarRiesgos.TabIndex = 3
        Me.Bt_AgregarRiesgos.Text = "Agregar"
        Me.Bt_AgregarRiesgos.UseVisualStyleBackColor = True
        '
        'Lb_Riesgos
        '
        Me.Lb_Riesgos.AutoSize = True
        Me.Lb_Riesgos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Riesgos.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Riesgos.Location = New System.Drawing.Point(3, 4)
        Me.Lb_Riesgos.Name = "Lb_Riesgos"
        Me.Lb_Riesgos.Size = New System.Drawing.Size(66, 16)
        Me.Lb_Riesgos.TabIndex = 0
        Me.Lb_Riesgos.Text = "Riesgos"
        Me.Lb_Riesgos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.Color.Silver
        Me.Pn_Botones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Pn_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 349)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(705, 34)
        Me.Pn_Botones.TabIndex = 143
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(539, 4)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Aceptar.TabIndex = 148
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(620, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 149
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDITEM"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "NROITEM"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Ítem"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NROITEM"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Ítem"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'IDITEMANTECEDENTELABORAL
        '
        Me.IDITEMANTECEDENTELABORAL.DataPropertyName = "IDITEMANTECEDENTELABORAL"
        Me.IDITEMANTECEDENTELABORAL.HeaderText = "IDITEM"
        Me.IDITEMANTECEDENTELABORAL.Name = "IDITEMANTECEDENTELABORAL"
        Me.IDITEMANTECEDENTELABORAL.ReadOnly = True
        Me.IDITEMANTECEDENTELABORAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IDITEMANTECEDENTELABORAL.Visible = False
        '
        'IDPERSONA
        '
        Me.IDPERSONA.DataPropertyName = "IDPERSONA"
        Me.IDPERSONA.HeaderText = "IDPERSONA"
        Me.IDPERSONA.Name = "IDPERSONA"
        Me.IDPERSONA.ReadOnly = True
        Me.IDPERSONA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IDPERSONA.Visible = False
        '
        'DGVT_NROITEM
        '
        Me.DGVT_NROITEM.DataPropertyName = "NROITEM"
        Me.DGVT_NROITEM.HeaderText = "Ítem"
        Me.DGVT_NROITEM.Name = "DGVT_NROITEM"
        Me.DGVT_NROITEM.ReadOnly = True
        Me.DGVT_NROITEM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DGVT_NROITEM.Visible = False
        '
        'DGVC_TipoRiesgo
        '
        Me.DGVC_TipoRiesgo.DataPropertyName = "TIPORIESGO"
        Me.DGVC_TipoRiesgo.HeaderText = "Tipo De Riesgo"
        Me.DGVC_TipoRiesgo.Name = "DGVC_TipoRiesgo"
        Me.DGVC_TipoRiesgo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DGVC_AgenteCausal
        '
        Me.DGVC_AgenteCausal.DataPropertyName = "AGENTECAUSAL"
        Me.DGVC_AgenteCausal.HeaderText = "Agente Causal"
        Me.DGVC_AgenteCausal.Name = "DGVC_AgenteCausal"
        Me.DGVC_AgenteCausal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC_AgenteCausal.Width = 300
        '
        'Fr_RiesgosAntecedentesLaborales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 384)
        Me.Controls.Add(Me.Pn_Botones)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Dgv_Riesgos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Tb_ARL)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tb_TiempoTrabajadoAños)
        Me.Controls.Add(Me.Lb_TiempoTrabajadoAños)
        Me.Controls.Add(Me.Tb_TiempoTrabajadoMeses)
        Me.Controls.Add(Me.Lb_TiempoTrabajadoMeses)
        Me.Controls.Add(Me.Tb_Empresa)
        Me.Controls.Add(Me.Lb_Empresa)
        Me.Name = "Fr_RiesgosAntecedentesLaborales"
        Me.ShowIcon = False
        Me.Text = "Antecedentes Laborales"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Dgv_Riesgos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Pn_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tb_TiempoTrabajadoMeses As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TiempoTrabajadoMeses As System.Windows.Forms.Label
    Friend WithEvents Tb_TiempoTrabajadoAños As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TiempoTrabajadoAños As System.Windows.Forms.Label
    Friend WithEvents Lb_Empresa As System.Windows.Forms.Label
    Friend WithEvents Tb_Empresa As System.Windows.Forms.TextBox
    Friend WithEvents Tb_ARL As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_Cargo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Cargo As System.Windows.Forms.Label
    Friend WithEvents Tb_Turno As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Turno As System.Windows.Forms.Label
    Friend WithEvents Tb_Jornada As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Jornada As System.Windows.Forms.Label
    Friend WithEvents Tb_Secuela As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Secuela As System.Windows.Forms.Label
    Friend WithEvents Tb_DiasIT As System.Windows.Forms.TextBox
    Friend WithEvents Lb_DiasIT As System.Windows.Forms.Label
    Friend WithEvents Lb_Origen As System.Windows.Forms.Label
    Friend WithEvents Tb_IT As System.Windows.Forms.TextBox
    Friend WithEvents Lb_IT As System.Windows.Forms.Label
    Friend WithEvents Dgv_Riesgos As System.Windows.Forms.DataGridView
    Friend WithEvents Tb_Origen As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AgregarRiesgos As System.Windows.Forms.Button
    Friend WithEvents Lb_Riesgos As System.Windows.Forms.Label
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Public WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDITEMANTECEDENTELABORAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPERSONA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVT_NROITEM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVC_TipoRiesgo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGVC_AgenteCausal As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
