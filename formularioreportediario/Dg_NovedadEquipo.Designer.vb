<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dg_NovedadEquipo
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lb_Disponibilidad = New System.Windows.Forms.Label()
        Me.Lb_TipoDisponibilidad = New System.Windows.Forms.Label()
        Me.Lb_FormaReporte = New System.Windows.Forms.Label()
        Me.Lb_ULTIMOHIKI = New System.Windows.Forms.Label()
        Me.Lb_Descripción = New System.Windows.Forms.Label()
        Me.Lb_CodigoEquipo = New System.Windows.Forms.Label()
        Me.Lb_Reporte = New System.Windows.Forms.Label()
        Me.Tx_DIS = New System.Windows.Forms.TextBox()
        Me.Tx_HF_KF = New System.Windows.Forms.TextBox()
        Me.Tx_HI_KI = New System.Windows.Forms.TextBox()
        Me.Tx_TOTAL = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tx_VAR = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Lb_Error = New System.Windows.Forms.Label()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(471, 188)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lb_Disponibilidad)
        Me.GroupBox1.Controls.Add(Me.Lb_TipoDisponibilidad)
        Me.GroupBox1.Controls.Add(Me.Lb_FormaReporte)
        Me.GroupBox1.Controls.Add(Me.Lb_ULTIMOHIKI)
        Me.GroupBox1.Controls.Add(Me.Lb_Descripción)
        Me.GroupBox1.Controls.Add(Me.Lb_CodigoEquipo)
        Me.GroupBox1.Controls.Add(Me.Lb_Reporte)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(605, 116)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información:"
        '
        'Lb_Disponibilidad
        '
        Me.Lb_Disponibilidad.AutoSize = True
        Me.Lb_Disponibilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Disponibilidad.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Disponibilidad.Location = New System.Drawing.Point(334, 89)
        Me.Lb_Disponibilidad.Name = "Lb_Disponibilidad"
        Me.Lb_Disponibilidad.Size = New System.Drawing.Size(131, 16)
        Me.Lb_Disponibilidad.TabIndex = 8
        Me.Lb_Disponibilidad.Text = "DISPONIBILIDAD:"
        '
        'Lb_TipoDisponibilidad
        '
        Me.Lb_TipoDisponibilidad.AutoSize = True
        Me.Lb_TipoDisponibilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TipoDisponibilidad.ForeColor = System.Drawing.Color.Blue
        Me.Lb_TipoDisponibilidad.Location = New System.Drawing.Point(295, 66)
        Me.Lb_TipoDisponibilidad.Name = "Lb_TipoDisponibilidad"
        Me.Lb_TipoDisponibilidad.Size = New System.Drawing.Size(170, 16)
        Me.Lb_TipoDisponibilidad.TabIndex = 7
        Me.Lb_TipoDisponibilidad.Text = "TIPO DISPONIBILIDAD:"
        '
        'Lb_FormaReporte
        '
        Me.Lb_FormaReporte.AutoSize = True
        Me.Lb_FormaReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_FormaReporte.ForeColor = System.Drawing.Color.Blue
        Me.Lb_FormaReporte.Location = New System.Drawing.Point(13, 89)
        Me.Lb_FormaReporte.Name = "Lb_FormaReporte"
        Me.Lb_FormaReporte.Size = New System.Drawing.Size(142, 16)
        Me.Lb_FormaReporte.TabIndex = 6
        Me.Lb_FormaReporte.Text = "FORMA REPORTE:"
        '
        'Lb_ULTIMOHIKI
        '
        Me.Lb_ULTIMOHIKI.AutoSize = True
        Me.Lb_ULTIMOHIKI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_ULTIMOHIKI.ForeColor = System.Drawing.Color.Blue
        Me.Lb_ULTIMOHIKI.Location = New System.Drawing.Point(50, 66)
        Me.Lb_ULTIMOHIKI.Name = "Lb_ULTIMOHIKI"
        Me.Lb_ULTIMOHIKI.Size = New System.Drawing.Size(105, 16)
        Me.Lb_ULTIMOHIKI.TabIndex = 5
        Me.Lb_ULTIMOHIKI.Text = "ULTIMO HI/KI:"
        '
        'Lb_Descripción
        '
        Me.Lb_Descripción.AutoSize = True
        Me.Lb_Descripción.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Descripción.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Descripción.Location = New System.Drawing.Point(41, 43)
        Me.Lb_Descripción.Name = "Lb_Descripción"
        Me.Lb_Descripción.Size = New System.Drawing.Size(114, 16)
        Me.Lb_Descripción.TabIndex = 4
        Me.Lb_Descripción.Text = "DESCRIPCION:"
        '
        'Lb_CodigoEquipo
        '
        Me.Lb_CodigoEquipo.AutoSize = True
        Me.Lb_CodigoEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CodigoEquipo.ForeColor = System.Drawing.Color.Blue
        Me.Lb_CodigoEquipo.Location = New System.Drawing.Point(334, 20)
        Me.Lb_CodigoEquipo.Name = "Lb_CodigoEquipo"
        Me.Lb_CodigoEquipo.Size = New System.Drawing.Size(131, 16)
        Me.Lb_CodigoEquipo.TabIndex = 3
        Me.Lb_CodigoEquipo.Text = "CODIGO EQUIPO:"
        '
        'Lb_Reporte
        '
        Me.Lb_Reporte.AutoSize = True
        Me.Lb_Reporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Reporte.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Reporte.Location = New System.Drawing.Point(8, 20)
        Me.Lb_Reporte.Name = "Lb_Reporte"
        Me.Lb_Reporte.Size = New System.Drawing.Size(147, 16)
        Me.Lb_Reporte.TabIndex = 2
        Me.Lb_Reporte.Text = "CODIGO REPORTE:"
        '
        'Tx_DIS
        '
        Me.Tx_DIS.Location = New System.Drawing.Point(461, 134)
        Me.Tx_DIS.MaxLength = 4
        Me.Tx_DIS.Name = "Tx_DIS"
        Me.Tx_DIS.Size = New System.Drawing.Size(50, 20)
        Me.Tx_DIS.TabIndex = 20
        '
        'Tx_HF_KF
        '
        Me.Tx_HF_KF.Location = New System.Drawing.Point(355, 134)
        Me.Tx_HF_KF.MaxLength = 7
        Me.Tx_HF_KF.Name = "Tx_HF_KF"
        Me.Tx_HF_KF.Size = New System.Drawing.Size(50, 20)
        Me.Tx_HF_KF.TabIndex = 19
        '
        'Tx_HI_KI
        '
        Me.Tx_HI_KI.Location = New System.Drawing.Point(213, 134)
        Me.Tx_HI_KI.MaxLength = 7
        Me.Tx_HI_KI.Name = "Tx_HI_KI"
        Me.Tx_HI_KI.Size = New System.Drawing.Size(50, 20)
        Me.Tx_HI_KI.TabIndex = 18
        '
        'Tx_TOTAL
        '
        Me.Tx_TOTAL.Location = New System.Drawing.Point(77, 134)
        Me.Tx_TOTAL.MaxLength = 4
        Me.Tx_TOTAL.Name = "Tx_TOTAL"
        Me.Tx_TOTAL.Size = New System.Drawing.Size(50, 20)
        Me.Tx_TOTAL.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(423, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "D:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(281, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "HF / KF:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(145, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "HI / KI:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "TOTAL:"
        '
        'Tx_VAR
        '
        Me.Tx_VAR.Location = New System.Drawing.Point(566, 134)
        Me.Tx_VAR.MaxLength = 4
        Me.Tx_VAR.Name = "Tx_VAR"
        Me.Tx_VAR.Size = New System.Drawing.Size(50, 20)
        Me.Tx_VAR.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(529, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "V:"
        '
        'Lb_Error
        '
        Me.Lb_Error.AutoSize = True
        Me.Lb_Error.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Error.ForeColor = System.Drawing.Color.Red
        Me.Lb_Error.Location = New System.Drawing.Point(17, 164)
        Me.Lb_Error.Name = "Lb_Error"
        Me.Lb_Error.Size = New System.Drawing.Size(42, 13)
        Me.Lb_Error.TabIndex = 23
        Me.Lb_Error.Text = "Error: "
        Me.Lb_Error.Visible = False
        '
        'Tm_Totalizar
        '
        '
        'Dg_NovedadEquipo
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(624, 223)
        Me.Controls.Add(Me.Lb_Error)
        Me.Controls.Add(Me.Tx_VAR)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Tx_DIS)
        Me.Controls.Add(Me.Tx_HF_KF)
        Me.Controls.Add(Me.Tx_HI_KI)
        Me.Controls.Add(Me.Tx_TOTAL)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dg_NovedadEquipo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Novedad Equipo"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents Lb_Descripción As System.Windows.Forms.Label
    Public WithEvents Lb_CodigoEquipo As System.Windows.Forms.Label
    Public WithEvents Lb_Reporte As System.Windows.Forms.Label
    Public WithEvents Tx_DIS As System.Windows.Forms.TextBox
    Public WithEvents Tx_HF_KF As System.Windows.Forms.TextBox
    Public WithEvents Tx_HI_KI As System.Windows.Forms.TextBox
    Public WithEvents Tx_TOTAL As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Tx_VAR As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Lb_Error As System.Windows.Forms.Label
    Public WithEvents Lb_FormaReporte As System.Windows.Forms.Label
    Public WithEvents Lb_ULTIMOHIKI As System.Windows.Forms.Label
    Public WithEvents Lb_Disponibilidad As System.Windows.Forms.Label
    Public WithEvents Lb_TipoDisponibilidad As System.Windows.Forms.Label
    Friend WithEvents Tm_Totalizar As System.Windows.Forms.Timer

End Class
