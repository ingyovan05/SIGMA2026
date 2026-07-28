<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_AsociarDependencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_AsociarDependencia))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Asociar = New System.Windows.Forms.Button()
        Me.Cb_Dependencia = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dgv_PersonasAsociadas = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Cu_BuscarPersona = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_PersonasAsociadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Persona:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.Btn_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 366)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 32)
        Me.Panel1.TabIndex = 2
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Location = New System.Drawing.Point(787, 5)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cancelar.TabIndex = 1
        Me.Btn_Cancelar.Text = "Cerrar"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Asociar
        '
        Me.Btn_Asociar.Location = New System.Drawing.Point(787, 13)
        Me.Btn_Asociar.Name = "Btn_Asociar"
        Me.Btn_Asociar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Asociar.TabIndex = 2
        Me.Btn_Asociar.Text = "Asociar"
        Me.Btn_Asociar.UseVisualStyleBackColor = True
        '
        'Cb_Dependencia
        '
        Me.Cb_Dependencia.FormattingEnabled = True
        Me.Cb_Dependencia.Location = New System.Drawing.Point(517, 13)
        Me.Cb_Dependencia.Name = "Cb_Dependencia"
        Me.Cb_Dependencia.Size = New System.Drawing.Size(264, 21)
        Me.Cb_Dependencia.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(437, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Dependencia:"
        '
        'Dgv_PersonasAsociadas
        '
        Me.Dgv_PersonasAsociadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_PersonasAsociadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_PersonasAsociadas.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_PersonasAsociadas.Name = "Dgv_PersonasAsociadas"
        Me.Dgv_PersonasAsociadas.Size = New System.Drawing.Size(873, 315)
        Me.Dgv_PersonasAsociadas.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Cu_BuscarPersona)
        Me.Panel2.Controls.Add(Me.Btn_Asociar)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Cb_Dependencia)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(873, 51)
        Me.Panel2.TabIndex = 0
        '
        'Cu_BuscarPersona
        '
        Me.Cu_BuscarPersona.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_BuscarPersona.Location = New System.Drawing.Point(66, 11)
        Me.Cu_BuscarPersona.Name = "Cu_BuscarPersona"
        Me.Cu_BuscarPersona.Size = New System.Drawing.Size(365, 23)
        Me.Cu_BuscarPersona.TabIndex = 0
        Me.Cu_BuscarPersona.Tipo = "PUABO"
        Me.Cu_BuscarPersona.valorcajatexto = "IDENTIFICACION"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Dgv_PersonasAsociadas)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 51)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(873, 315)
        Me.Panel3.TabIndex = 1
        '
        'Fr_AsociarDependencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 398)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Fr_AsociarDependencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fr_AsociarDependencia"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Dgv_PersonasAsociadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Asociar As System.Windows.Forms.Button
    Friend WithEvents Cb_Dependencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dgv_PersonasAsociadas As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Cu_BuscarPersona As FormulariosClasesBase.Cu_BuscarPersona
End Class
