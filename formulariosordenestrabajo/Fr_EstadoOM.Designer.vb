<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_EstadoOM
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Dgv_OrdenSap = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Bt_AgregarOMPortapapeles = New System.Windows.Forms.Button()
        Me.Bt_LimpiarTabla = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Lb_TotalSAP = New System.Windows.Forms.Label()
        Me.Cb_Estado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Pn_Facturación = New System.Windows.Forms.Panel()
        Me.Ck_Actualizar = New System.Windows.Forms.CheckBox()
        Me.Lb_HojaEntrada = New System.Windows.Forms.Label()
        Me.Tx_HojaEntrada = New System.Windows.Forms.TextBox()
        Me.Lb_Factura = New System.Windows.Forms.Label()
        Me.Tx_Factura = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_OrdenSap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Pn_Facturación.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Dgv_OrdenSap)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(333, 464)
        Me.Panel1.TabIndex = 2
        '
        'Dgv_OrdenSap
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_OrdenSap.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_OrdenSap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_OrdenSap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_OrdenSap.Location = New System.Drawing.Point(0, 33)
        Me.Dgv_OrdenSap.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dgv_OrdenSap.Name = "Dgv_OrdenSap"
        Me.Dgv_OrdenSap.Size = New System.Drawing.Size(333, 431)
        Me.Dgv_OrdenSap.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(333, 33)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Info
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(333, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lista OM's"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bt_AgregarOMPortapapeles
        '
        Me.Bt_AgregarOMPortapapeles.Location = New System.Drawing.Point(341, 284)
        Me.Bt_AgregarOMPortapapeles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bt_AgregarOMPortapapeles.Name = "Bt_AgregarOMPortapapeles"
        Me.Bt_AgregarOMPortapapeles.Size = New System.Drawing.Size(239, 28)
        Me.Bt_AgregarOMPortapapeles.TabIndex = 4
        Me.Bt_AgregarOMPortapapeles.Text = "<-- Agregar desde portapapeles"
        Me.Bt_AgregarOMPortapapeles.UseVisualStyleBackColor = True
        '
        'Bt_LimpiarTabla
        '
        Me.Bt_LimpiarTabla.Location = New System.Drawing.Point(341, 320)
        Me.Bt_LimpiarTabla.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bt_LimpiarTabla.Name = "Bt_LimpiarTabla"
        Me.Bt_LimpiarTabla.Size = New System.Drawing.Size(239, 28)
        Me.Bt_LimpiarTabla.TabIndex = 5
        Me.Bt_LimpiarTabla.Text = "Limpiar Tabla"
        Me.Bt_LimpiarTabla.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(341, 431)
        Me.Bt_Aceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(105, 28)
        Me.Bt_Aceptar.TabIndex = 6
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(471, 431)
        Me.Bt_Cancelar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(109, 28)
        Me.Bt_Cancelar.TabIndex = 7
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Lb_TotalSAP
        '
        Me.Lb_TotalSAP.AutoSize = True
        Me.Lb_TotalSAP.Location = New System.Drawing.Point(337, 375)
        Me.Lb_TotalSAP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_TotalSAP.Name = "Lb_TotalSAP"
        Me.Lb_TotalSAP.Size = New System.Drawing.Size(80, 17)
        Me.Lb_TotalSAP.TabIndex = 13
        Me.Lb_TotalSAP.Text = "Total OM's:"
        '
        'Cb_Estado
        '
        Me.Cb_Estado.FormattingEnabled = True
        Me.Cb_Estado.Location = New System.Drawing.Point(404, 46)
        Me.Cb_Estado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cb_Estado.Name = "Cb_Estado"
        Me.Cb_Estado.Size = New System.Drawing.Size(183, 24)
        Me.Cb_Estado.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(339, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Estado:"
        '
        'Pn_Facturación
        '
        Me.Pn_Facturación.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Facturación.Controls.Add(Me.Lb_HojaEntrada)
        Me.Pn_Facturación.Controls.Add(Me.Tx_HojaEntrada)
        Me.Pn_Facturación.Controls.Add(Me.Lb_Factura)
        Me.Pn_Facturación.Controls.Add(Me.Tx_Factura)
        Me.Pn_Facturación.Controls.Add(Me.Ck_Actualizar)
        Me.Pn_Facturación.Location = New System.Drawing.Point(351, 88)
        Me.Pn_Facturación.Name = "Pn_Facturación"
        Me.Pn_Facturación.Size = New System.Drawing.Size(224, 127)
        Me.Pn_Facturación.TabIndex = 16
        Me.Pn_Facturación.Visible = False
        '
        'Ck_Actualizar
        '
        Me.Ck_Actualizar.AutoSize = True
        Me.Ck_Actualizar.Location = New System.Drawing.Point(13, 14)
        Me.Ck_Actualizar.Name = "Ck_Actualizar"
        Me.Ck_Actualizar.Size = New System.Drawing.Size(156, 21)
        Me.Ck_Actualizar.TabIndex = 0
        Me.Ck_Actualizar.Text = "Registrar en las OM"
        Me.Ck_Actualizar.UseVisualStyleBackColor = True
        '
        'Lb_HojaEntrada
        '
        Me.Lb_HojaEntrada.AutoSize = True
        Me.Lb_HojaEntrada.Location = New System.Drawing.Point(12, 43)
        Me.Lb_HojaEntrada.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_HojaEntrada.Name = "Lb_HojaEntrada"
        Me.Lb_HojaEntrada.Size = New System.Drawing.Size(115, 17)
        Me.Lb_HojaEntrada.TabIndex = 135
        Me.Lb_HojaEntrada.Text = "Hoja de Entrada:"
        '
        'Tx_HojaEntrada
        '
        Me.Tx_HojaEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_HojaEntrada.Location = New System.Drawing.Point(130, 42)
        Me.Tx_HojaEntrada.Margin = New System.Windows.Forms.Padding(4)
        Me.Tx_HojaEntrada.MaxLength = 10
        Me.Tx_HojaEntrada.Name = "Tx_HojaEntrada"
        Me.Tx_HojaEntrada.Size = New System.Drawing.Size(81, 20)
        Me.Tx_HojaEntrada.TabIndex = 133
        '
        'Lb_Factura
        '
        Me.Lb_Factura.AutoSize = True
        Me.Lb_Factura.Location = New System.Drawing.Point(40, 76)
        Me.Lb_Factura.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_Factura.Name = "Lb_Factura"
        Me.Lb_Factura.Size = New System.Drawing.Size(87, 17)
        Me.Lb_Factura.TabIndex = 136
        Me.Lb_Factura.Text = "Factura ISM:"
        '
        'Tx_Factura
        '
        Me.Tx_Factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_Factura.Location = New System.Drawing.Point(130, 74)
        Me.Tx_Factura.Margin = New System.Windows.Forms.Padding(4)
        Me.Tx_Factura.MaxLength = 10
        Me.Tx_Factura.Name = "Tx_Factura"
        Me.Tx_Factura.Size = New System.Drawing.Size(81, 20)
        Me.Tx_Factura.TabIndex = 134
        '
        'Fr_EstadoOM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 464)
        Me.Controls.Add(Me.Pn_Facturación)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cb_Estado)
        Me.Controls.Add(Me.Lb_TotalSAP)
        Me.Controls.Add(Me.Bt_Cancelar)
        Me.Controls.Add(Me.Bt_Aceptar)
        Me.Controls.Add(Me.Bt_LimpiarTabla)
        Me.Controls.Add(Me.Bt_AgregarOMPortapapeles)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximumSize = New System.Drawing.Size(609, 511)
        Me.MinimumSize = New System.Drawing.Size(609, 511)
        Me.Name = "Fr_EstadoOM"
        Me.Text = "Cambiar Estado"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Dgv_OrdenSap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Pn_Facturación.ResumeLayout(False)
        Me.Pn_Facturación.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_OrdenSap As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bt_AgregarOMPortapapeles As System.Windows.Forms.Button
    Friend WithEvents Bt_LimpiarTabla As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Lb_TotalSAP As System.Windows.Forms.Label
    Friend WithEvents Cb_Estado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pn_Facturación As System.Windows.Forms.Panel
    Friend WithEvents Ck_Actualizar As System.Windows.Forms.CheckBox
    Friend WithEvents Lb_HojaEntrada As System.Windows.Forms.Label
    Friend WithEvents Tx_HojaEntrada As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Factura As System.Windows.Forms.Label
    Friend WithEvents Tx_Factura As System.Windows.Forms.TextBox
End Class
