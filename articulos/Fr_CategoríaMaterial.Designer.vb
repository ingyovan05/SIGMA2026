<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_CategoríaMaterial
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_CódigoArtículo = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Cb_Unidad = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Cb_TipoMedida = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Tx_NombreCategoría = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MA_TIPOMEDIDATableAdapter1 = New DatosArticulos.Ds_ArtículosTableAdapters.MA_TIPOMEDIDATableAdapter()
        Me.MA_TIPOUNIDADTableAdapter1 = New DatosArticulos.Ds_ArtículosTableAdapters.MA_TIPOUNIDADTableAdapter()
        Me.Tx_CódigoCategoría = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lb_CódigoArtículo)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(649, 30)
        Me.Panel1.TabIndex = 29
        '
        'Lb_CódigoArtículo
        '
        Me.Lb_CódigoArtículo.AutoSize = True
        Me.Lb_CódigoArtículo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CódigoArtículo.ForeColor = System.Drawing.Color.Red
        Me.Lb_CódigoArtículo.Location = New System.Drawing.Point(11, 8)
        Me.Lb_CódigoArtículo.Name = "Lb_CódigoArtículo"
        Me.Lb_CódigoArtículo.Size = New System.Drawing.Size(52, 13)
        Me.Lb_CódigoArtículo.TabIndex = 2
        Me.Lb_CódigoArtículo.Text = "Label13"
        Me.Lb_CódigoArtículo.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(486, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(567, 2)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Cb_Unidad
        '
        Me.Cb_Unidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Unidad.FormattingEnabled = True
        Me.Cb_Unidad.Location = New System.Drawing.Point(316, 39)
        Me.Cb_Unidad.Name = "Cb_Unidad"
        Me.Cb_Unidad.Size = New System.Drawing.Size(132, 21)
        Me.Cb_Unidad.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(267, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Unidad:"
        '
        'Cb_TipoMedida
        '
        Me.Cb_TipoMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoMedida.FormattingEnabled = True
        Me.Cb_TipoMedida.Location = New System.Drawing.Point(115, 38)
        Me.Cb_TipoMedida.Name = "Cb_TipoMedida"
        Me.Cb_TipoMedida.Size = New System.Drawing.Size(132, 21)
        Me.Cb_TipoMedida.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(25, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Tipo de Medida:"
        '
        'Tx_NombreCategoría
        '
        Me.Tx_NombreCategoría.Location = New System.Drawing.Point(115, 12)
        Me.Tx_NombreCategoría.MaxLength = 40
        Me.Tx_NombreCategoría.Name = "Tx_NombreCategoría"
        Me.Tx_NombreCategoría.Size = New System.Drawing.Size(333, 20)
        Me.Tx_NombreCategoría.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Nombre Categoría:"
        '
        'MA_TIPOMEDIDATableAdapter1
        '
        Me.MA_TIPOMEDIDATableAdapter1.ClearBeforeFill = True
        '
        'MA_TIPOUNIDADTableAdapter1
        '
        Me.MA_TIPOUNIDADTableAdapter1.ClearBeforeFill = True
        '
        'Tx_CódigoCategoría
        '
        Me.Tx_CódigoCategoría.Location = New System.Drawing.Point(511, 13)
        Me.Tx_CódigoCategoría.MaxLength = 2
        Me.Tx_CódigoCategoría.Name = "Tx_CódigoCategoría"
        Me.Tx_CódigoCategoría.Size = New System.Drawing.Size(28, 20)
        Me.Tx_CódigoCategoría.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(463, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Código:"
        '
        'Fr_CategoríaMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 99)
        Me.Controls.Add(Me.Tx_CódigoCategoría)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Tx_NombreCategoría)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cb_Unidad)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Cb_TipoMedida)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Fr_CategoríaMaterial"
        Me.Text = "Categoría Material"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lb_CódigoArtículo As System.Windows.Forms.Label
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MA_TIPOMEDIDATableAdapter1 As DatosArticulos.Ds_ArtículosTableAdapters.MA_TIPOMEDIDATableAdapter
    Friend WithEvents MA_TIPOUNIDADTableAdapter1 As DatosArticulos.Ds_ArtículosTableAdapters.MA_TIPOUNIDADTableAdapter
    Public WithEvents Cb_Unidad As System.Windows.Forms.ComboBox
    Public WithEvents Cb_TipoMedida As System.Windows.Forms.ComboBox
    Public WithEvents Tx_NombreCategoría As System.Windows.Forms.TextBox
    Public WithEvents Tx_CódigoCategoría As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
