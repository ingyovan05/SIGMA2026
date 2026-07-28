<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Busquedas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Busquedas))
        Me.Cb_Criterio = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tx_valor = New System.Windows.Forms.TextBox()
        Me.Cb_Condicion = New System.Windows.Forms.ComboBox()
        Me.Bt_Buscar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Dtp_valor = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_valorHasta = New System.Windows.Forms.DateTimePicker()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cb_Top = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Cb_Criterio
        '
        Me.Cb_Criterio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cb_Criterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Criterio.FormattingEnabled = True
        Me.Cb_Criterio.Location = New System.Drawing.Point(11, 51)
        Me.Cb_Criterio.Name = "Cb_Criterio"
        Me.Cb_Criterio.Size = New System.Drawing.Size(226, 21)
        Me.Cb_Criterio.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(594, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccione los criterios de Búsqueda y de click en Buscar"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(97, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Criterio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(279, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Condición"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(466, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Valor"
        '
        'Tx_valor
        '
        Me.Tx_valor.Location = New System.Drawing.Point(372, 51)
        Me.Tx_valor.MaxLength = 8
        Me.Tx_valor.Name = "Tx_valor"
        Me.Tx_valor.Size = New System.Drawing.Size(218, 20)
        Me.Tx_valor.TabIndex = 5
        '
        'Cb_Condicion
        '
        Me.Cb_Condicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Condicion.FormattingEnabled = True
        Me.Cb_Condicion.Location = New System.Drawing.Point(246, 51)
        Me.Cb_Condicion.Name = "Cb_Condicion"
        Me.Cb_Condicion.Size = New System.Drawing.Size(120, 21)
        Me.Cb_Condicion.TabIndex = 1
        '
        'Bt_Buscar
        '
        Me.Bt_Buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Bt_Buscar.ForeColor = System.Drawing.Color.DarkGreen
        Me.Bt_Buscar.Location = New System.Drawing.Point(215, 88)
        Me.Bt_Buscar.Name = "Bt_Buscar"
        Me.Bt_Buscar.Size = New System.Drawing.Size(75, 28)
        Me.Bt_Buscar.TabIndex = 6
        Me.Bt_Buscar.Text = "Buscar"
        Me.Bt_Buscar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Bt_Cancelar.ForeColor = System.Drawing.Color.Maroon
        Me.Bt_Cancelar.Location = New System.Drawing.Point(304, 88)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 28)
        Me.Bt_Cancelar.TabIndex = 7
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Dtp_valor
        '
        Me.Dtp_valor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Dtp_valor.Checked = False
        Me.Dtp_valor.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_valor.Location = New System.Drawing.Point(372, 51)
        Me.Dtp_valor.Name = "Dtp_valor"
        Me.Dtp_valor.Size = New System.Drawing.Size(218, 20)
        Me.Dtp_valor.TabIndex = 3
        Me.Dtp_valor.Visible = False
        '
        'Dtp_valorHasta
        '
        Me.Dtp_valorHasta.Checked = False
        Me.Dtp_valorHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_valorHasta.Location = New System.Drawing.Point(484, 51)
        Me.Dtp_valorHasta.Name = "Dtp_valorHasta"
        Me.Dtp_valorHasta.Size = New System.Drawing.Size(106, 20)
        Me.Dtp_valorHasta.TabIndex = 8
        Me.Dtp_valorHasta.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "FavoriteStar_16x16.jpg")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Cantidad Registros:"
        '
        'Cb_Top
        '
        Me.Cb_Top.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Top.FormattingEnabled = True
        Me.Cb_Top.Items.AddRange(New Object() {"1", "20", "50", "100", "200", "500"})
        Me.Cb_Top.Location = New System.Drawing.Point(128, 88)
        Me.Cb_Top.Name = "Cb_Top"
        Me.Cb_Top.Size = New System.Drawing.Size(48, 21)
        Me.Cb_Top.TabIndex = 10
        '
        'Fr_Busquedas
        '
        Me.AcceptButton = Me.Bt_Buscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 128)
        Me.Controls.Add(Me.Cb_Top)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Dtp_valorHasta)
        Me.Controls.Add(Me.Cb_Criterio)
        Me.Controls.Add(Me.Bt_Cancelar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Bt_Buscar)
        Me.Controls.Add(Me.Dtp_valor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Tx_valor)
        Me.Controls.Add(Me.Cb_Condicion)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Fr_Busquedas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtrar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cb_Criterio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tx_valor As System.Windows.Forms.TextBox
    Friend WithEvents Cb_Condicion As System.Windows.Forms.ComboBox
    Friend WithEvents Bt_Buscar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Dtp_valor As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_valorHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cb_Top As System.Windows.Forms.ComboBox
End Class
