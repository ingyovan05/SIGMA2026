<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_SubirArchivosFacturaElectronica
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
        Me.Bt_SubirArchivos = New System.Windows.Forms.Button()
        Me.Tx_RutaFacturaPdf = New System.Windows.Forms.TextBox()
        Me.Tx_RutaFacturaXml = New System.Windows.Forms.TextBox()
        Me.Tx_RutaAcusePdf = New System.Windows.Forms.TextBox()
        Me.Tx_RutaAcuseXml = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarFacturaPdf = New System.Windows.Forms.Button()
        Me.Bt_BuscarFacturaXml = New System.Windows.Forms.Button()
        Me.Bt_BuscarAcusePdf = New System.Windows.Forms.Button()
        Me.Bt_BuscarAcuseXml = New System.Windows.Forms.Button()
        Me.Pn_Controles = New System.Windows.Forms.Panel()
        Me.Lb_FacturaPdf = New System.Windows.Forms.Label()
        Me.Bt_VerFacturaPdf = New System.Windows.Forms.Button()
        Me.Lb_FacturaXml = New System.Windows.Forms.Label()
        Me.Bt_VerFacturaXml = New System.Windows.Forms.Button()
        Me.Lb_AcusePdf = New System.Windows.Forms.Label()
        Me.Bt_VerAcusePdf = New System.Windows.Forms.Button()
        Me.Lb_AcuseXml = New System.Windows.Forms.Label()
        Me.Bt_VerAcuseXml = New System.Windows.Forms.Button()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Controles.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_SubirArchivos)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 131)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(584, 30)
        Me.Flp_Botones.TabIndex = 1
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(506, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_SubirArchivos
        '
        Me.Bt_SubirArchivos.AutoSize = True
        Me.Bt_SubirArchivos.Location = New System.Drawing.Point(415, 3)
        Me.Bt_SubirArchivos.Name = "Bt_SubirArchivos"
        Me.Bt_SubirArchivos.Size = New System.Drawing.Size(85, 23)
        Me.Bt_SubirArchivos.TabIndex = 0
        Me.Bt_SubirArchivos.Text = "Subir Archivos"
        Me.Bt_SubirArchivos.UseVisualStyleBackColor = True
        '
        'Tx_RutaFacturaPdf
        '
        Me.Tx_RutaFacturaPdf.Location = New System.Drawing.Point(140, 13)
        Me.Tx_RutaFacturaPdf.Name = "Tx_RutaFacturaPdf"
        Me.Tx_RutaFacturaPdf.ReadOnly = True
        Me.Tx_RutaFacturaPdf.Size = New System.Drawing.Size(360, 20)
        Me.Tx_RutaFacturaPdf.TabIndex = 1
        '
        'Tx_RutaFacturaXml
        '
        Me.Tx_RutaFacturaXml.Location = New System.Drawing.Point(140, 42)
        Me.Tx_RutaFacturaXml.Name = "Tx_RutaFacturaXml"
        Me.Tx_RutaFacturaXml.ReadOnly = True
        Me.Tx_RutaFacturaXml.Size = New System.Drawing.Size(360, 20)
        Me.Tx_RutaFacturaXml.TabIndex = 5
        '
        'Tx_RutaAcusePdf
        '
        Me.Tx_RutaAcusePdf.Location = New System.Drawing.Point(140, 71)
        Me.Tx_RutaAcusePdf.Name = "Tx_RutaAcusePdf"
        Me.Tx_RutaAcusePdf.ReadOnly = True
        Me.Tx_RutaAcusePdf.Size = New System.Drawing.Size(360, 20)
        Me.Tx_RutaAcusePdf.TabIndex = 9
        '
        'Tx_RutaAcuseXml
        '
        Me.Tx_RutaAcuseXml.Location = New System.Drawing.Point(140, 100)
        Me.Tx_RutaAcuseXml.Name = "Tx_RutaAcuseXml"
        Me.Tx_RutaAcuseXml.ReadOnly = True
        Me.Tx_RutaAcuseXml.Size = New System.Drawing.Size(360, 20)
        Me.Tx_RutaAcuseXml.TabIndex = 13
        '
        'Bt_BuscarFacturaPdf
        '
        Me.Bt_BuscarFacturaPdf.AutoSize = True
        Me.Bt_BuscarFacturaPdf.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_BuscarFacturaPdf.Location = New System.Drawing.Point(506, 12)
        Me.Bt_BuscarFacturaPdf.Name = "Bt_BuscarFacturaPdf"
        Me.Bt_BuscarFacturaPdf.Size = New System.Drawing.Size(26, 23)
        Me.Bt_BuscarFacturaPdf.TabIndex = 2
        Me.Bt_BuscarFacturaPdf.Text = "..."
        Me.Bt_BuscarFacturaPdf.UseVisualStyleBackColor = True
        '
        'Bt_BuscarFacturaXml
        '
        Me.Bt_BuscarFacturaXml.AutoSize = True
        Me.Bt_BuscarFacturaXml.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_BuscarFacturaXml.Location = New System.Drawing.Point(506, 41)
        Me.Bt_BuscarFacturaXml.Name = "Bt_BuscarFacturaXml"
        Me.Bt_BuscarFacturaXml.Size = New System.Drawing.Size(26, 23)
        Me.Bt_BuscarFacturaXml.TabIndex = 6
        Me.Bt_BuscarFacturaXml.Text = "..."
        Me.Bt_BuscarFacturaXml.UseVisualStyleBackColor = True
        '
        'Bt_BuscarAcusePdf
        '
        Me.Bt_BuscarAcusePdf.AutoSize = True
        Me.Bt_BuscarAcusePdf.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_BuscarAcusePdf.Location = New System.Drawing.Point(506, 70)
        Me.Bt_BuscarAcusePdf.Name = "Bt_BuscarAcusePdf"
        Me.Bt_BuscarAcusePdf.Size = New System.Drawing.Size(26, 23)
        Me.Bt_BuscarAcusePdf.TabIndex = 10
        Me.Bt_BuscarAcusePdf.Text = "..."
        Me.Bt_BuscarAcusePdf.UseVisualStyleBackColor = True
        '
        'Bt_BuscarAcuseXml
        '
        Me.Bt_BuscarAcuseXml.AutoSize = True
        Me.Bt_BuscarAcuseXml.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_BuscarAcuseXml.Location = New System.Drawing.Point(506, 99)
        Me.Bt_BuscarAcuseXml.Name = "Bt_BuscarAcuseXml"
        Me.Bt_BuscarAcuseXml.Size = New System.Drawing.Size(26, 23)
        Me.Bt_BuscarAcuseXml.TabIndex = 14
        Me.Bt_BuscarAcuseXml.Text = "..."
        Me.Bt_BuscarAcuseXml.UseVisualStyleBackColor = True
        '
        'Pn_Controles
        '
        Me.Pn_Controles.Controls.Add(Me.Lb_FacturaPdf)
        Me.Pn_Controles.Controls.Add(Me.Tx_RutaFacturaPdf)
        Me.Pn_Controles.Controls.Add(Me.Bt_BuscarFacturaPdf)
        Me.Pn_Controles.Controls.Add(Me.Bt_VerFacturaPdf)
        Me.Pn_Controles.Controls.Add(Me.Lb_FacturaXml)
        Me.Pn_Controles.Controls.Add(Me.Tx_RutaFacturaXml)
        Me.Pn_Controles.Controls.Add(Me.Bt_BuscarFacturaXml)
        Me.Pn_Controles.Controls.Add(Me.Bt_VerFacturaXml)
        Me.Pn_Controles.Controls.Add(Me.Lb_AcusePdf)
        Me.Pn_Controles.Controls.Add(Me.Tx_RutaAcusePdf)
        Me.Pn_Controles.Controls.Add(Me.Bt_BuscarAcusePdf)
        Me.Pn_Controles.Controls.Add(Me.Bt_VerAcusePdf)
        Me.Pn_Controles.Controls.Add(Me.Lb_AcuseXml)
        Me.Pn_Controles.Controls.Add(Me.Tx_RutaAcuseXml)
        Me.Pn_Controles.Controls.Add(Me.Bt_BuscarAcuseXml)
        Me.Pn_Controles.Controls.Add(Me.Bt_VerAcuseXml)
        Me.Pn_Controles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Controles.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Controles.Name = "Pn_Controles"
        Me.Pn_Controles.Size = New System.Drawing.Size(584, 131)
        Me.Pn_Controles.TabIndex = 0
        '
        'Lb_FacturaPdf
        '
        Me.Lb_FacturaPdf.AutoSize = True
        Me.Lb_FacturaPdf.Location = New System.Drawing.Point(11, 16)
        Me.Lb_FacturaPdf.Name = "Lb_FacturaPdf"
        Me.Lb_FacturaPdf.Size = New System.Drawing.Size(126, 13)
        Me.Lb_FacturaPdf.TabIndex = 0
        Me.Lb_FacturaPdf.Text = "Factura Electrónica PDF:"
        '
        'Bt_VerFacturaPdf
        '
        Me.Bt_VerFacturaPdf.AutoSize = True
        Me.Bt_VerFacturaPdf.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_VerFacturaPdf.Enabled = False
        Me.Bt_VerFacturaPdf.Location = New System.Drawing.Point(538, 12)
        Me.Bt_VerFacturaPdf.Name = "Bt_VerFacturaPdf"
        Me.Bt_VerFacturaPdf.Size = New System.Drawing.Size(33, 23)
        Me.Bt_VerFacturaPdf.TabIndex = 3
        Me.Bt_VerFacturaPdf.Text = "Ver"
        Me.Bt_VerFacturaPdf.UseVisualStyleBackColor = True
        '
        'Lb_FacturaXml
        '
        Me.Lb_FacturaXml.AutoSize = True
        Me.Lb_FacturaXml.Location = New System.Drawing.Point(10, 45)
        Me.Lb_FacturaXml.Name = "Lb_FacturaXml"
        Me.Lb_FacturaXml.Size = New System.Drawing.Size(127, 13)
        Me.Lb_FacturaXml.TabIndex = 4
        Me.Lb_FacturaXml.Text = "Factura Electrónica XML:"
        '
        'Bt_VerFacturaXml
        '
        Me.Bt_VerFacturaXml.AutoSize = True
        Me.Bt_VerFacturaXml.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_VerFacturaXml.Enabled = False
        Me.Bt_VerFacturaXml.Location = New System.Drawing.Point(538, 41)
        Me.Bt_VerFacturaXml.Name = "Bt_VerFacturaXml"
        Me.Bt_VerFacturaXml.Size = New System.Drawing.Size(33, 23)
        Me.Bt_VerFacturaXml.TabIndex = 7
        Me.Bt_VerFacturaXml.Text = "Ver"
        Me.Bt_VerFacturaXml.UseVisualStyleBackColor = True
        '
        'Lb_AcusePdf
        '
        Me.Lb_AcusePdf.AutoSize = True
        Me.Lb_AcusePdf.Location = New System.Drawing.Point(21, 74)
        Me.Lb_AcusePdf.Name = "Lb_AcusePdf"
        Me.Lb_AcusePdf.Size = New System.Drawing.Size(116, 13)
        Me.Lb_AcusePdf.TabIndex = 8
        Me.Lb_AcusePdf.Text = "Acuse de Recibo PDF:"
        '
        'Bt_VerAcusePdf
        '
        Me.Bt_VerAcusePdf.AutoSize = True
        Me.Bt_VerAcusePdf.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_VerAcusePdf.Enabled = False
        Me.Bt_VerAcusePdf.Location = New System.Drawing.Point(538, 70)
        Me.Bt_VerAcusePdf.Name = "Bt_VerAcusePdf"
        Me.Bt_VerAcusePdf.Size = New System.Drawing.Size(33, 23)
        Me.Bt_VerAcusePdf.TabIndex = 11
        Me.Bt_VerAcusePdf.Text = "Ver"
        Me.Bt_VerAcusePdf.UseVisualStyleBackColor = True
        '
        'Lb_AcuseXml
        '
        Me.Lb_AcuseXml.AutoSize = True
        Me.Lb_AcuseXml.Location = New System.Drawing.Point(20, 103)
        Me.Lb_AcuseXml.Name = "Lb_AcuseXml"
        Me.Lb_AcuseXml.Size = New System.Drawing.Size(117, 13)
        Me.Lb_AcuseXml.TabIndex = 12
        Me.Lb_AcuseXml.Text = "Acuse de Recibo XML:"
        '
        'Bt_VerAcuseXml
        '
        Me.Bt_VerAcuseXml.AutoSize = True
        Me.Bt_VerAcuseXml.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_VerAcuseXml.Enabled = False
        Me.Bt_VerAcuseXml.Location = New System.Drawing.Point(538, 99)
        Me.Bt_VerAcuseXml.Name = "Bt_VerAcuseXml"
        Me.Bt_VerAcuseXml.Size = New System.Drawing.Size(33, 23)
        Me.Bt_VerAcuseXml.TabIndex = 15
        Me.Bt_VerAcuseXml.Text = "Ver"
        Me.Bt_VerAcuseXml.UseVisualStyleBackColor = True
        '
        'Fr_SubirArchivosFacturaElectronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 161)
        Me.Controls.Add(Me.Pn_Controles)
        Me.Controls.Add(Me.Flp_Botones)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_SubirArchivosFacturaElectronica"
        Me.ShowIcon = False
        Me.Text = "Subir Archivos de Factura Electrónica"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Flp_Botones.PerformLayout()
        Me.Pn_Controles.ResumeLayout(False)
        Me.Pn_Controles.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Tx_RutaFacturaPdf As System.Windows.Forms.TextBox
    Friend WithEvents Tx_RutaFacturaXml As System.Windows.Forms.TextBox
    Friend WithEvents Tx_RutaAcusePdf As System.Windows.Forms.TextBox
    Friend WithEvents Tx_RutaAcuseXml As System.Windows.Forms.TextBox
    Friend WithEvents Bt_BuscarFacturaPdf As System.Windows.Forms.Button
    Friend WithEvents Bt_BuscarFacturaXml As System.Windows.Forms.Button
    Friend WithEvents Bt_BuscarAcusePdf As System.Windows.Forms.Button
    Friend WithEvents Bt_BuscarAcuseXml As System.Windows.Forms.Button
    Friend WithEvents Pn_Controles As System.Windows.Forms.Panel
    Friend WithEvents Lb_FacturaPdf As System.Windows.Forms.Label
    Friend WithEvents Lb_FacturaXml As System.Windows.Forms.Label
    Friend WithEvents Lb_AcusePdf As System.Windows.Forms.Label
    Friend WithEvents Lb_AcuseXml As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_SubirArchivos As System.Windows.Forms.Button
    Friend WithEvents Bt_VerAcuseXml As System.Windows.Forms.Button
    Friend WithEvents Bt_VerAcusePdf As System.Windows.Forms.Button
    Friend WithEvents Bt_VerFacturaXml As System.Windows.Forms.Button
    Friend WithEvents Bt_VerFacturaPdf As System.Windows.Forms.Button
End Class
