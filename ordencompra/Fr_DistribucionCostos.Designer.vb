<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_DistribucionCostos
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pn_Básicos = New System.Windows.Forms.Panel()
        Me.Lb_Consecutivo = New System.Windows.Forms.Label()
        Me.Lb_OrdenCompra = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Tc_Ventanas = New System.Windows.Forms.TabControl()
        Me.Tp_SAAfectadas = New System.Windows.Forms.TabPage()
        Me.Dgv_ListaSAI = New System.Windows.Forms.DataGridView()
        Me.Tp_DistribucionxArticulo = New System.Windows.Forms.TabPage()
        Me.Dgv_ListaDistribucionA = New System.Windows.Forms.DataGridView()
        Me.Tp_DistribucionxCC = New System.Windows.Forms.TabPage()
        Me.Dgv_ListaDistribucionCC = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pn_Básicos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Tc_Ventanas.SuspendLayout()
        Me.Tp_SAAfectadas.SuspendLayout()
        CType(Me.Dgv_ListaSAI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tp_DistribucionxArticulo.SuspendLayout()
        CType(Me.Dgv_ListaDistribucionA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tp_DistribucionxCC.SuspendLayout()
        CType(Me.Dgv_ListaDistribucionCC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Básicos
        '
        Me.Pn_Básicos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Básicos.Controls.Add(Me.Lb_Consecutivo)
        Me.Pn_Básicos.Controls.Add(Me.Lb_OrdenCompra)
        Me.Pn_Básicos.Controls.Add(Me.Label5)
        Me.Pn_Básicos.Controls.Add(Me.Label2)
        Me.Pn_Básicos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Básicos.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Básicos.Name = "Pn_Básicos"
        Me.Pn_Básicos.Size = New System.Drawing.Size(690, 49)
        Me.Pn_Básicos.TabIndex = 1
        '
        'Lb_Consecutivo
        '
        Me.Lb_Consecutivo.AutoSize = True
        Me.Lb_Consecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Consecutivo.Location = New System.Drawing.Point(445, 8)
        Me.Lb_Consecutivo.Name = "Lb_Consecutivo"
        Me.Lb_Consecutivo.Size = New System.Drawing.Size(81, 20)
        Me.Lb_Consecutivo.TabIndex = 39
        Me.Lb_Consecutivo.Text = "XXXXXX"
        '
        'Lb_OrdenCompra
        '
        Me.Lb_OrdenCompra.AutoSize = True
        Me.Lb_OrdenCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_OrdenCompra.Location = New System.Drawing.Point(156, 8)
        Me.Lb_OrdenCompra.Name = "Lb_OrdenCompra"
        Me.Lb_OrdenCompra.Size = New System.Drawing.Size(141, 20)
        Me.Lb_OrdenCompra.TabIndex = 36
        Me.Lb_OrdenCompra.Text = "XXXXXXXXXXX"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Distribución Orden Compra:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(354, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nro Distribución:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Tc_Ventanas)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 49)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(690, 573)
        Me.Panel2.TabIndex = 3
        '
        'Tc_Ventanas
        '
        Me.Tc_Ventanas.Controls.Add(Me.Tp_SAAfectadas)
        Me.Tc_Ventanas.Controls.Add(Me.Tp_DistribucionxArticulo)
        Me.Tc_Ventanas.Controls.Add(Me.Tp_DistribucionxCC)
        Me.Tc_Ventanas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tc_Ventanas.Location = New System.Drawing.Point(0, 0)
        Me.Tc_Ventanas.Name = "Tc_Ventanas"
        Me.Tc_Ventanas.SelectedIndex = 0
        Me.Tc_Ventanas.Size = New System.Drawing.Size(690, 573)
        Me.Tc_Ventanas.TabIndex = 3
        '
        'Tp_SAAfectadas
        '
        Me.Tp_SAAfectadas.Controls.Add(Me.Dgv_ListaSAI)
        Me.Tp_SAAfectadas.Location = New System.Drawing.Point(4, 22)
        Me.Tp_SAAfectadas.Name = "Tp_SAAfectadas"
        Me.Tp_SAAfectadas.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_SAAfectadas.Size = New System.Drawing.Size(682, 547)
        Me.Tp_SAAfectadas.TabIndex = 0
        Me.Tp_SAAfectadas.Text = "Salidas Almacén Afectadas"
        Me.Tp_SAAfectadas.UseVisualStyleBackColor = True
        '
        'Dgv_ListaSAI
        '
        Me.Dgv_ListaSAI.AllowUserToAddRows = False
        Me.Dgv_ListaSAI.AllowUserToDeleteRows = False
        Me.Dgv_ListaSAI.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_ListaSAI.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_ListaSAI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ListaSAI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaSAI.Location = New System.Drawing.Point(3, 3)
        Me.Dgv_ListaSAI.MultiSelect = False
        Me.Dgv_ListaSAI.Name = "Dgv_ListaSAI"
        Me.Dgv_ListaSAI.ReadOnly = True
        Me.Dgv_ListaSAI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_ListaSAI.Size = New System.Drawing.Size(676, 541)
        Me.Dgv_ListaSAI.TabIndex = 1
        '
        'Tp_DistribucionxArticulo
        '
        Me.Tp_DistribucionxArticulo.Controls.Add(Me.Dgv_ListaDistribucionA)
        Me.Tp_DistribucionxArticulo.Location = New System.Drawing.Point(4, 22)
        Me.Tp_DistribucionxArticulo.Name = "Tp_DistribucionxArticulo"
        Me.Tp_DistribucionxArticulo.Size = New System.Drawing.Size(682, 547)
        Me.Tp_DistribucionxArticulo.TabIndex = 3
        Me.Tp_DistribucionxArticulo.Text = "Distribución por Artículo"
        Me.Tp_DistribucionxArticulo.UseVisualStyleBackColor = True
        '
        'Dgv_ListaDistribucionA
        '
        Me.Dgv_ListaDistribucionA.AllowUserToAddRows = False
        Me.Dgv_ListaDistribucionA.AllowUserToDeleteRows = False
        Me.Dgv_ListaDistribucionA.AllowUserToOrderColumns = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_ListaDistribucionA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_ListaDistribucionA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ListaDistribucionA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaDistribucionA.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_ListaDistribucionA.MultiSelect = False
        Me.Dgv_ListaDistribucionA.Name = "Dgv_ListaDistribucionA"
        Me.Dgv_ListaDistribucionA.ReadOnly = True
        Me.Dgv_ListaDistribucionA.Size = New System.Drawing.Size(682, 547)
        Me.Dgv_ListaDistribucionA.TabIndex = 1
        '
        'Tp_DistribucionxCC
        '
        Me.Tp_DistribucionxCC.Controls.Add(Me.Dgv_ListaDistribucionCC)
        Me.Tp_DistribucionxCC.Location = New System.Drawing.Point(4, 22)
        Me.Tp_DistribucionxCC.Name = "Tp_DistribucionxCC"
        Me.Tp_DistribucionxCC.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_DistribucionxCC.Size = New System.Drawing.Size(682, 547)
        Me.Tp_DistribucionxCC.TabIndex = 1
        Me.Tp_DistribucionxCC.Text = "Distribución por Centro de Costos."
        Me.Tp_DistribucionxCC.UseVisualStyleBackColor = True
        '
        'Dgv_ListaDistribucionCC
        '
        Me.Dgv_ListaDistribucionCC.AllowUserToAddRows = False
        Me.Dgv_ListaDistribucionCC.AllowUserToDeleteRows = False
        Me.Dgv_ListaDistribucionCC.AllowUserToOrderColumns = True
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_ListaDistribucionCC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_ListaDistribucionCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ListaDistribucionCC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaDistribucionCC.Location = New System.Drawing.Point(3, 3)
        Me.Dgv_ListaDistribucionCC.MultiSelect = False
        Me.Dgv_ListaDistribucionCC.Name = "Dgv_ListaDistribucionCC"
        Me.Dgv_ListaDistribucionCC.ReadOnly = True
        Me.Dgv_ListaDistribucionCC.Size = New System.Drawing.Size(676, 541)
        Me.Dgv_ListaDistribucionCC.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 622)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(690, 30)
        Me.Panel1.TabIndex = 4
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(526, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 1
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(607, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(351, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Oprimir la tecla F6 para exportar los archivos a Excel."
        '
        'Fr_DistribucionCostos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 652)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pn_Básicos)
        Me.MaximumSize = New System.Drawing.Size(706, 691)
        Me.MinimumSize = New System.Drawing.Size(706, 691)
        Me.Name = "Fr_DistribucionCostos"
        Me.Text = "Fr_DistribucionCostos"
        Me.Pn_Básicos.ResumeLayout(False)
        Me.Pn_Básicos.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Tc_Ventanas.ResumeLayout(False)
        Me.Tp_SAAfectadas.ResumeLayout(False)
        CType(Me.Dgv_ListaSAI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tp_DistribucionxArticulo.ResumeLayout(False)
        CType(Me.Dgv_ListaDistribucionA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tp_DistribucionxCC.ResumeLayout(False)
        CType(Me.Dgv_ListaDistribucionCC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Pn_Básicos As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Tc_Ventanas As System.Windows.Forms.TabControl
    Friend WithEvents Tp_SAAfectadas As System.Windows.Forms.TabPage
    Friend WithEvents Tp_DistribucionxArticulo As System.Windows.Forms.TabPage
    Friend WithEvents Tp_DistribucionxCC As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Lb_Consecutivo As System.Windows.Forms.Label
    Friend WithEvents Lb_OrdenCompra As System.Windows.Forms.Label
    Friend WithEvents Dgv_ListaSAI As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv_ListaDistribucionA As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv_ListaDistribucionCC As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
