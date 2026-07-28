<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_GestionarVacunas
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
        Me.Tlp_Encabezado = New System.Windows.Forms.TableLayoutPanel()
        Me.Lb_TextoNombre = New System.Windows.Forms.Label()
        Me.Lb_Identificacion = New System.Windows.Forms.Label()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Lb_TextoCodigo = New System.Windows.Forms.Label()
        Me.Cu_Vacuna1 = New FormulariosClasesBase.Cu_Vacuna()
        Me.Pn_Botones = New System.Windows.Forms.Panel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Pn_Cuerpo = New System.Windows.Forms.Panel()
        Me.Tlp_Encabezado.SuspendLayout()
        Me.Pn_Botones.SuspendLayout()
        Me.Pn_Cuerpo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tlp_Encabezado
        '
        Me.Tlp_Encabezado.ColumnCount = 4
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_TextoNombre, 0, 0)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_Identificacion, 3, 0)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_Nombre, 1, 0)
        Me.Tlp_Encabezado.Controls.Add(Me.Lb_TextoCodigo, 2, 0)
        Me.Tlp_Encabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tlp_Encabezado.Location = New System.Drawing.Point(0, 0)
        Me.Tlp_Encabezado.Name = "Tlp_Encabezado"
        Me.Tlp_Encabezado.RowCount = 1
        Me.Tlp_Encabezado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Tlp_Encabezado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Tlp_Encabezado.Size = New System.Drawing.Size(819, 35)
        Me.Tlp_Encabezado.TabIndex = 1
        '
        'Lb_TextoNombre
        '
        Me.Lb_TextoNombre.AutoSize = True
        Me.Lb_TextoNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TextoNombre.Location = New System.Drawing.Point(3, 0)
        Me.Lb_TextoNombre.Name = "Lb_TextoNombre"
        Me.Lb_TextoNombre.Size = New System.Drawing.Size(47, 35)
        Me.Lb_TextoNombre.TabIndex = 0
        Me.Lb_TextoNombre.Text = "Nombre:"
        Me.Lb_TextoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lb_Identificacion
        '
        Me.Lb_Identificacion.AutoSize = True
        Me.Lb_Identificacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Identificacion.Location = New System.Drawing.Point(212, 0)
        Me.Lb_Identificacion.Name = "Lb_Identificacion"
        Me.Lb_Identificacion.Size = New System.Drawing.Size(604, 35)
        Me.Lb_Identificacion.TabIndex = 3
        Me.Lb_Identificacion.Text = "Lb_Codigo"
        Me.Lb_Identificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.Location = New System.Drawing.Point(56, 0)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(71, 35)
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
        Me.Lb_TextoCodigo.Size = New System.Drawing.Size(73, 35)
        Me.Lb_TextoCodigo.TabIndex = 2
        Me.Lb_TextoCodigo.Text = "Identificación:"
        Me.Lb_TextoCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cu_Vacuna1
        '
        Me.Cu_Vacuna1.Location = New System.Drawing.Point(0, 6)
        Me.Cu_Vacuna1.Name = "Cu_Vacuna1"
        Me.Cu_Vacuna1.Size = New System.Drawing.Size(819, 283)
        Me.Cu_Vacuna1.TabIndex = 4
        '
        'Pn_Botones
        '
        Me.Pn_Botones.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Pn_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Pn_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Pn_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Botones.Location = New System.Drawing.Point(0, 295)
        Me.Pn_Botones.Name = "Pn_Botones"
        Me.Pn_Botones.Size = New System.Drawing.Size(819, 30)
        Me.Pn_Botones.TabIndex = 55
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Cancelar.Location = New System.Drawing.Point(735, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 2
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Aceptar.Location = New System.Drawing.Point(650, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 1
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Pn_Cuerpo
        '
        Me.Pn_Cuerpo.Controls.Add(Me.Cu_Vacuna1)
        Me.Pn_Cuerpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Cuerpo.Location = New System.Drawing.Point(0, 35)
        Me.Pn_Cuerpo.Name = "Pn_Cuerpo"
        Me.Pn_Cuerpo.Size = New System.Drawing.Size(819, 260)
        Me.Pn_Cuerpo.TabIndex = 59
        '
        'Fr_GestionarVacunas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 325)
        Me.Controls.Add(Me.Pn_Cuerpo)
        Me.Controls.Add(Me.Pn_Botones)
        Me.Controls.Add(Me.Tlp_Encabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(835, 378)
        Me.MinimumSize = New System.Drawing.Size(835, 364)
        Me.Name = "Fr_GestionarVacunas"
        Me.Text = "Gestionar Vacunas"
        Me.Tlp_Encabezado.ResumeLayout(False)
        Me.Tlp_Encabezado.PerformLayout()
        Me.Pn_Botones.ResumeLayout(False)
        Me.Pn_Cuerpo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tlp_Encabezado As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lb_TextoNombre As System.Windows.Forms.Label
    Friend WithEvents Lb_Identificacion As System.Windows.Forms.Label
    Friend WithEvents Lb_Nombre As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCodigo As System.Windows.Forms.Label
    Friend WithEvents Cu_Vacuna1 As FormulariosClasesBase.Cu_Vacuna
    Friend WithEvents Pn_Botones As System.Windows.Forms.Panel
    Friend WithEvents Lb_Estado As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Public WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Pn_Cuerpo As System.Windows.Forms.Panel
End Class
