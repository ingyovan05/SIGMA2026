<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_GestionarUsuarioCorrespondencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_GestionarUsuarioCorrespondencia))
        Me.Pn_Filtro = New System.Windows.Forms.Panel()
        Me.Bt_Cargar = New System.Windows.Forms.Button()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Cu_BuscarPersonaCorrespondencia = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Dgv_Cantidades = New System.Windows.Forms.DataGridView()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Pn_Opciones = New System.Windows.Forms.Panel()
        Me.Lb_LlenarTodo = New System.Windows.Forms.Label()
        Me.Tx_LlenarTodo = New System.Windows.Forms.TextBox()
        Me.Bt_LLenarTodo = New System.Windows.Forms.Button()
        Me.Pn_Filtro.SuspendLayout()
        CType(Me.Dgv_Cantidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Opciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pn_Filtro
        '
        Me.Pn_Filtro.Controls.Add(Me.Bt_Cargar)
        Me.Pn_Filtro.Controls.Add(Me.Lb_Nombre)
        Me.Pn_Filtro.Controls.Add(Me.Cu_BuscarPersonaCorrespondencia)
        Me.Pn_Filtro.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Filtro.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Filtro.Name = "Pn_Filtro"
        Me.Pn_Filtro.Size = New System.Drawing.Size(624, 40)
        Me.Pn_Filtro.TabIndex = 0
        '
        'Bt_Cargar
        '
        Me.Bt_Cargar.Location = New System.Drawing.Point(515, 9)
        Me.Bt_Cargar.Name = "Bt_Cargar"
        Me.Bt_Cargar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cargar.TabIndex = 2
        Me.Bt_Cargar.Text = "Cargar"
        Me.Bt_Cargar.UseVisualStyleBackColor = True
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Location = New System.Drawing.Point(12, 14)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(47, 13)
        Me.Lb_Nombre.TabIndex = 0
        Me.Lb_Nombre.Text = "Nombre:"
        '
        'Cu_BuscarPersonaCorrespondencia
        '
        Me.Cu_BuscarPersonaCorrespondencia.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersonaCorrespondencia.Location = New System.Drawing.Point(65, 9)
        Me.Cu_BuscarPersonaCorrespondencia.Name = "Cu_BuscarPersonaCorrespondencia"
        Me.Cu_BuscarPersonaCorrespondencia.Size = New System.Drawing.Size(444, 23)
        Me.Cu_BuscarPersonaCorrespondencia.TabIndex = 1
        Me.Cu_BuscarPersonaCorrespondencia.Tipo = "PUACB"
        Me.Cu_BuscarPersonaCorrespondencia.valorcajatexto = Nothing
        '
        'Dgv_Cantidades
        '
        Me.Dgv_Cantidades.AllowDrop = True
        Me.Dgv_Cantidades.AllowUserToAddRows = False
        Me.Dgv_Cantidades.AllowUserToDeleteRows = False
        Me.Dgv_Cantidades.AllowUserToResizeColumns = False
        Me.Dgv_Cantidades.AllowUserToResizeRows = False
        Me.Dgv_Cantidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Cantidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_Cantidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Cantidades.Location = New System.Drawing.Point(0, 40)
        Me.Dgv_Cantidades.MultiSelect = False
        Me.Dgv_Cantidades.Name = "Dgv_Cantidades"
        Me.Dgv_Cantidades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv_Cantidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Cantidades.Size = New System.Drawing.Size(624, 221)
        Me.Dgv_Cantidades.TabIndex = 1
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cerrar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Guardar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 291)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(624, 30)
        Me.Flp_Botones.TabIndex = 3
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Location = New System.Drawing.Point(546, 3)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 2
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(465, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(384, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Pn_Opciones
        '
        Me.Pn_Opciones.Controls.Add(Me.Lb_LlenarTodo)
        Me.Pn_Opciones.Controls.Add(Me.Tx_LlenarTodo)
        Me.Pn_Opciones.Controls.Add(Me.Bt_LLenarTodo)
        Me.Pn_Opciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Opciones.Location = New System.Drawing.Point(0, 261)
        Me.Pn_Opciones.Name = "Pn_Opciones"
        Me.Pn_Opciones.Size = New System.Drawing.Size(624, 30)
        Me.Pn_Opciones.TabIndex = 2
        '
        'Lb_LlenarTodo
        '
        Me.Lb_LlenarTodo.AutoSize = True
        Me.Lb_LlenarTodo.Location = New System.Drawing.Point(12, 8)
        Me.Lb_LlenarTodo.Name = "Lb_LlenarTodo"
        Me.Lb_LlenarTodo.Size = New System.Drawing.Size(84, 13)
        Me.Lb_LlenarTodo.TabIndex = 0
        Me.Lb_LlenarTodo.Text = "Llenar todo con:"
        '
        'Tx_LlenarTodo
        '
        Me.Tx_LlenarTodo.Location = New System.Drawing.Point(99, 5)
        Me.Tx_LlenarTodo.MaxLength = 3
        Me.Tx_LlenarTodo.Name = "Tx_LlenarTodo"
        Me.Tx_LlenarTodo.Size = New System.Drawing.Size(30, 20)
        Me.Tx_LlenarTodo.TabIndex = 1
        '
        'Bt_LLenarTodo
        '
        Me.Bt_LLenarTodo.Location = New System.Drawing.Point(135, 3)
        Me.Bt_LLenarTodo.Name = "Bt_LLenarTodo"
        Me.Bt_LLenarTodo.Size = New System.Drawing.Size(75, 23)
        Me.Bt_LLenarTodo.TabIndex = 2
        Me.Bt_LLenarTodo.Text = "Llenar"
        Me.Bt_LLenarTodo.UseVisualStyleBackColor = True
        '
        'Fr_GestionarUsuarioCorrespondencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 321)
        Me.Controls.Add(Me.Dgv_Cantidades)
        Me.Controls.Add(Me.Pn_Filtro)
        Me.Controls.Add(Me.Pn_Opciones)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Name = "Fr_GestionarUsuarioCorrespondencia"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionando Límites de Correspondencia Pendiente"
        Me.Pn_Filtro.ResumeLayout(False)
        Me.Pn_Filtro.PerformLayout()
        CType(Me.Dgv_Cantidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Opciones.ResumeLayout(False)
        Me.Pn_Opciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pn_Filtro As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Cantidades As System.Windows.Forms.DataGridView
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Cu_BuscarPersonaCorrespondencia As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Bt_Cargar As System.Windows.Forms.Button
    Friend WithEvents Pn_Opciones As System.Windows.Forms.Panel
    Friend WithEvents Tx_LlenarTodo As System.Windows.Forms.TextBox
    Friend WithEvents Lb_LlenarTodo As System.Windows.Forms.Label
    Friend WithEvents Bt_LLenarTodo As System.Windows.Forms.Button
End Class
