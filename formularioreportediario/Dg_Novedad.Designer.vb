<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dg_Novedad
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tx_HN = New System.Windows.Forms.TextBox()
        Me.Tx_ED = New System.Windows.Forms.TextBox()
        Me.Tx_EN = New System.Windows.Forms.TextBox()
        Me.Tx_RN = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lb_Nombre = New System.Windows.Forms.Label()
        Me.Lb_CodigoContrato = New System.Windows.Forms.Label()
        Me.Lb_Reporte = New System.Windows.Forms.Label()
        Me.Lb_TOTAL = New System.Windows.Forms.Label()
        Me.Lb_Error = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tm_Totalizar = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(408, 127)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "HN:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(114, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ED:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(201, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "EN:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(288, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "RN:"
        '
        'Tx_HN
        '
        Me.Tx_HN.Location = New System.Drawing.Point(58, 72)
        Me.Tx_HN.MaxLength = 4
        Me.Tx_HN.Name = "Tx_HN"
        Me.Tx_HN.Size = New System.Drawing.Size(50, 20)
        Me.Tx_HN.TabIndex = 5
        '
        'Tx_ED
        '
        Me.Tx_ED.Location = New System.Drawing.Point(145, 72)
        Me.Tx_ED.MaxLength = 4
        Me.Tx_ED.Name = "Tx_ED"
        Me.Tx_ED.Size = New System.Drawing.Size(50, 20)
        Me.Tx_ED.TabIndex = 6
        '
        'Tx_EN
        '
        Me.Tx_EN.Location = New System.Drawing.Point(232, 72)
        Me.Tx_EN.MaxLength = 4
        Me.Tx_EN.Name = "Tx_EN"
        Me.Tx_EN.Size = New System.Drawing.Size(50, 20)
        Me.Tx_EN.TabIndex = 7
        '
        'Tx_RN
        '
        Me.Tx_RN.Location = New System.Drawing.Point(320, 72)
        Me.Tx_RN.MaxLength = 4
        Me.Tx_RN.Name = "Tx_RN"
        Me.Tx_RN.Size = New System.Drawing.Size(50, 20)
        Me.Tx_RN.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lb_Nombre)
        Me.GroupBox1.Controls.Add(Me.Lb_CodigoContrato)
        Me.GroupBox1.Controls.Add(Me.Lb_Reporte)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(542, 65)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información:"
        '
        'Lb_Nombre
        '
        Me.Lb_Nombre.AutoSize = True
        Me.Lb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nombre.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Nombre.Location = New System.Drawing.Point(77, 41)
        Me.Lb_Nombre.Name = "Lb_Nombre"
        Me.Lb_Nombre.Size = New System.Drawing.Size(77, 16)
        Me.Lb_Nombre.TabIndex = 4
        Me.Lb_Nombre.Text = "NOMBRE:"
        '
        'Lb_CodigoContrato
        '
        Me.Lb_CodigoContrato.AutoSize = True
        Me.Lb_CodigoContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CodigoContrato.ForeColor = System.Drawing.Color.Blue
        Me.Lb_CodigoContrato.Location = New System.Drawing.Point(297, 20)
        Me.Lb_CodigoContrato.Name = "Lb_CodigoContrato"
        Me.Lb_CodigoContrato.Size = New System.Drawing.Size(158, 16)
        Me.Lb_CodigoContrato.TabIndex = 3
        Me.Lb_CodigoContrato.Text = "CODIGO CONTRATO:"
        '
        'Lb_Reporte
        '
        Me.Lb_Reporte.AutoSize = True
        Me.Lb_Reporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Reporte.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Reporte.Location = New System.Drawing.Point(7, 20)
        Me.Lb_Reporte.Name = "Lb_Reporte"
        Me.Lb_Reporte.Size = New System.Drawing.Size(147, 16)
        Me.Lb_Reporte.TabIndex = 2
        Me.Lb_Reporte.Text = "CODIGO REPORTE:"
        '
        'Lb_TOTAL
        '
        Me.Lb_TOTAL.AutoSize = True
        Me.Lb_TOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TOTAL.ForeColor = System.Drawing.Color.Blue
        Me.Lb_TOTAL.Location = New System.Drawing.Point(443, 74)
        Me.Lb_TOTAL.Name = "Lb_TOTAL"
        Me.Lb_TOTAL.Size = New System.Drawing.Size(24, 16)
        Me.Lb_TOTAL.TabIndex = 10
        Me.Lb_TOTAL.Text = "00"
        '
        'Lb_Error
        '
        Me.Lb_Error.AutoSize = True
        Me.Lb_Error.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Error.ForeColor = System.Drawing.Color.Red
        Me.Lb_Error.Location = New System.Drawing.Point(9, 98)
        Me.Lb_Error.Name = "Lb_Error"
        Me.Lb_Error.Size = New System.Drawing.Size(42, 13)
        Me.Lb_Error.TabIndex = 11
        Me.Lb_Error.Text = "Error: "
        Me.Lb_Error.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(376, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "TOTAL:"
        '
        'Tm_Totalizar
        '
        '
        'Dg_Novedad
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(566, 159)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Lb_Error)
        Me.Controls.Add(Me.Lb_TOTAL)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Tx_RN)
        Me.Controls.Add(Me.Tx_EN)
        Me.Controls.Add(Me.Tx_ED)
        Me.Controls.Add(Me.Tx_HN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dg_Novedad"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Novedad Personal"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Lb_TOTAL As System.Windows.Forms.Label
    Public WithEvents Lb_Nombre As System.Windows.Forms.Label
    Public WithEvents Lb_CodigoContrato As System.Windows.Forms.Label
    Public WithEvents Lb_Reporte As System.Windows.Forms.Label
    Public WithEvents Lb_Error As System.Windows.Forms.Label
    Public WithEvents Tx_HN As System.Windows.Forms.TextBox
    Public WithEvents Tx_ED As System.Windows.Forms.TextBox
    Public WithEvents Tx_EN As System.Windows.Forms.TextBox
    Public WithEvents Tx_RN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Tm_Totalizar As System.Windows.Forms.Timer

End Class
