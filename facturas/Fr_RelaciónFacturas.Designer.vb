<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_RelaciónFacturas
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Bt_AplicarVacias = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cb_Facturas = New System.Windows.Forms.ComboBox()
        Me.Bt_AdicionarFactura = New System.Windows.Forms.Button()
        Me.Bt_AplicarTodas = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dgv_ListaItemEntrada = New System.Windows.Forms.DataGridView()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Dgv_ListaItemEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Bt_Guardar)
        Me.Panel3.Controls.Add(Me.Bt_Cerrar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 271)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(808, 33)
        Me.Panel3.TabIndex = 6
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Guardar.Location = New System.Drawing.Point(666, 6)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(62, 23)
        Me.Bt_Guardar.TabIndex = 9
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Cerrar.Location = New System.Drawing.Point(734, 6)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(71, 23)
        Me.Bt_Cerrar.TabIndex = 8
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Bt_AplicarVacias
        '
        Me.Bt_AplicarVacias.Location = New System.Drawing.Point(280, 6)
        Me.Bt_AplicarVacias.Name = "Bt_AplicarVacias"
        Me.Bt_AplicarVacias.Size = New System.Drawing.Size(105, 23)
        Me.Bt_AplicarVacias.TabIndex = 7
        Me.Bt_AplicarVacias.Text = "Aplicar a vacias"
        Me.Bt_AplicarVacias.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Factura No."
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Cb_Facturas)
        Me.Panel1.Controls.Add(Me.Bt_AdicionarFactura)
        Me.Panel1.Controls.Add(Me.Bt_AplicarTodas)
        Me.Panel1.Controls.Add(Me.Bt_AplicarVacias)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(808, 37)
        Me.Panel1.TabIndex = 0
        '
        'Cb_Facturas
        '
        Me.Cb_Facturas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Facturas.FormattingEnabled = True
        Me.Cb_Facturas.Location = New System.Drawing.Point(90, 8)
        Me.Cb_Facturas.Name = "Cb_Facturas"
        Me.Cb_Facturas.Size = New System.Drawing.Size(150, 21)
        Me.Cb_Facturas.TabIndex = 10
        '
        'Bt_AdicionarFactura
        '
        Me.Bt_AdicionarFactura.Location = New System.Drawing.Point(246, 6)
        Me.Bt_AdicionarFactura.Name = "Bt_AdicionarFactura"
        Me.Bt_AdicionarFactura.Size = New System.Drawing.Size(28, 23)
        Me.Bt_AdicionarFactura.TabIndex = 9
        Me.Bt_AdicionarFactura.Text = "+"
        Me.Bt_AdicionarFactura.UseVisualStyleBackColor = True
        '
        'Bt_AplicarTodas
        '
        Me.Bt_AplicarTodas.Location = New System.Drawing.Point(391, 6)
        Me.Bt_AplicarTodas.Name = "Bt_AplicarTodas"
        Me.Bt_AplicarTodas.Size = New System.Drawing.Size(105, 23)
        Me.Bt_AplicarTodas.TabIndex = 8
        Me.Bt_AplicarTodas.Text = "Aplicar a todas"
        Me.Bt_AplicarTodas.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Info
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(808, 19)
        Me.Panel2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(808, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Relacionar facturas con Item's de Entrada de Almacén Asociadas a la Orden de Comp" & _
    "ra"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_ListaItemEntrada
        '
        Me.Dgv_ListaItemEntrada.AllowUserToAddRows = False
        Me.Dgv_ListaItemEntrada.AllowUserToDeleteRows = False
        Me.Dgv_ListaItemEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ListaItemEntrada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaItemEntrada.Location = New System.Drawing.Point(0, 56)
        Me.Dgv_ListaItemEntrada.Name = "Dgv_ListaItemEntrada"
        Me.Dgv_ListaItemEntrada.Size = New System.Drawing.Size(808, 215)
        Me.Dgv_ListaItemEntrada.TabIndex = 8
        '
        'Fr_RelaciónFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 304)
        Me.Controls.Add(Me.Dgv_ListaItemEntrada)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "Fr_RelaciónFacturas"
        Me.Text = "RelacionFacturas"
        Me.Panel3.ResumeLayout(false)
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.Panel2.ResumeLayout(false)
        CType(Me.Dgv_ListaItemEntrada,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Bt_AplicarVacias As System.Windows.Forms.Button
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Dgv_ListaItemEntrada As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_AplicarTodas As System.Windows.Forms.Button
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_AdicionarFactura As System.Windows.Forms.Button
    Friend WithEvents Cb_Facturas As System.Windows.Forms.ComboBox
End Class
