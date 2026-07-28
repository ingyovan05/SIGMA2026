<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_CaracterísticaArtículo
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
        Me.Btn_AceptarCambio = New System.Windows.Forms.Button()
        Me.Btn_CancelarCambio = New System.Windows.Forms.Button()
        Me.Tx_Descripción = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lb_BodegaActual = New System.Windows.Forms.Label()
        Me.Tx_Ubicación = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nud_Mínimo = New System.Windows.Forms.NumericUpDown()
        Me.Lb_UnidadMínimo = New System.Windows.Forms.Label()
        Me.Lb_UnidadMáximo = New System.Windows.Forms.Label()
        Me.Nud_Máximo = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.Nud_Mínimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_Máximo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.Controls.Add(Me.Btn_AceptarCambio)
        Me.Panel1.Controls.Add(Me.Btn_CancelarCambio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 151)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 30)
        Me.Panel1.TabIndex = 22
        '
        'Btn_AceptarCambio
        '
        Me.Btn_AceptarCambio.Location = New System.Drawing.Point(422, 3)
        Me.Btn_AceptarCambio.Name = "Btn_AceptarCambio"
        Me.Btn_AceptarCambio.Size = New System.Drawing.Size(75, 23)
        Me.Btn_AceptarCambio.TabIndex = 1
        Me.Btn_AceptarCambio.Text = "Aceptar"
        Me.Btn_AceptarCambio.UseVisualStyleBackColor = True
        '
        'Btn_CancelarCambio
        '
        Me.Btn_CancelarCambio.Location = New System.Drawing.Point(503, 3)
        Me.Btn_CancelarCambio.Name = "Btn_CancelarCambio"
        Me.Btn_CancelarCambio.Size = New System.Drawing.Size(75, 23)
        Me.Btn_CancelarCambio.TabIndex = 0
        Me.Btn_CancelarCambio.Text = "Cancelar"
        Me.Btn_CancelarCambio.UseVisualStyleBackColor = True
        '
        'Tx_Descripción
        '
        Me.Tx_Descripción.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tx_Descripción.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tx_Descripción.Location = New System.Drawing.Point(0, 0)
        Me.Tx_Descripción.Multiline = True
        Me.Tx_Descripción.Name = "Tx_Descripción"
        Me.Tx_Descripción.ReadOnly = True
        Me.Tx_Descripción.Size = New System.Drawing.Size(584, 40)
        Me.Tx_Descripción.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(7, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 16)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Localización en la Bodega:"
        '
        'Lb_BodegaActual
        '
        Me.Lb_BodegaActual.AutoSize = True
        Me.Lb_BodegaActual.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Lb_BodegaActual.Location = New System.Drawing.Point(172, 48)
        Me.Lb_BodegaActual.Name = "Lb_BodegaActual"
        Me.Lb_BodegaActual.Size = New System.Drawing.Size(50, 16)
        Me.Lb_BodegaActual.TabIndex = 21
        Me.Lb_BodegaActual.Text = "Label3"
        '
        'Tx_Ubicación
        '
        Me.Tx_Ubicación.Location = New System.Drawing.Point(7, 67)
        Me.Tx_Ubicación.MaxLength = 100
        Me.Tx_Ubicación.Name = "Tx_Ubicación"
        Me.Tx_Ubicación.Size = New System.Drawing.Size(569, 20)
        Me.Tx_Ubicación.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(15, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Stock Mínimo:"
        '
        'Nud_Mínimo
        '
        Me.Nud_Mínimo.Location = New System.Drawing.Point(107, 95)
        Me.Nud_Mínimo.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.Nud_Mínimo.Name = "Nud_Mínimo"
        Me.Nud_Mínimo.Size = New System.Drawing.Size(95, 20)
        Me.Nud_Mínimo.TabIndex = 27
        '
        'Lb_UnidadMínimo
        '
        Me.Lb_UnidadMínimo.AutoSize = True
        Me.Lb_UnidadMínimo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Lb_UnidadMínimo.Location = New System.Drawing.Point(205, 97)
        Me.Lb_UnidadMínimo.Name = "Lb_UnidadMínimo"
        Me.Lb_UnidadMínimo.Size = New System.Drawing.Size(50, 16)
        Me.Lb_UnidadMínimo.TabIndex = 28
        Me.Lb_UnidadMínimo.Text = "Label3"
        '
        'Lb_UnidadMáximo
        '
        Me.Lb_UnidadMáximo.AutoSize = True
        Me.Lb_UnidadMáximo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Lb_UnidadMáximo.Location = New System.Drawing.Point(205, 123)
        Me.Lb_UnidadMáximo.Name = "Lb_UnidadMáximo"
        Me.Lb_UnidadMáximo.Size = New System.Drawing.Size(50, 16)
        Me.Lb_UnidadMáximo.TabIndex = 31
        Me.Lb_UnidadMáximo.Text = "Label4"
        '
        'Nud_Máximo
        '
        Me.Nud_Máximo.Location = New System.Drawing.Point(108, 121)
        Me.Nud_Máximo.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.Nud_Máximo.Name = "Nud_Máximo"
        Me.Nud_Máximo.Size = New System.Drawing.Size(95, 20)
        Me.Nud_Máximo.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(13, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 16)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Stock Máximo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(355, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(217, 16)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "* Para no fijar valores dejar en cero"
        '
        'Fr_CaracterísticaArtículo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 181)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Lb_UnidadMáximo)
        Me.Controls.Add(Me.Nud_Máximo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Lb_UnidadMínimo)
        Me.Controls.Add(Me.Nud_Mínimo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tx_Ubicación)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Tx_Descripción)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Lb_BodegaActual)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 219)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 219)
        Me.Name = "Fr_CaracterísticaArtículo"
        Me.Text = "Característica Artículo X Bodega"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Nud_Mínimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_Máximo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btn_AceptarCambio As System.Windows.Forms.Button
    Friend WithEvents Btn_CancelarCambio As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Tx_Descripción As System.Windows.Forms.TextBox
    Public WithEvents Lb_BodegaActual As System.Windows.Forms.Label
    Private WithEvents Tx_Ubicación As System.Windows.Forms.TextBox
    Private WithEvents Nud_Mínimo As System.Windows.Forms.NumericUpDown
    Public WithEvents Lb_UnidadMínimo As System.Windows.Forms.Label
    Public WithEvents Lb_UnidadMáximo As System.Windows.Forms.Label
    Private WithEvents Nud_Máximo As System.Windows.Forms.NumericUpDown
End Class
