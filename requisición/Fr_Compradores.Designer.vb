<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Compradores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Compradores))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Cu_Bp_VBSubgerencia = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cb_RequiereVBSubgerencia = New System.Windows.Forms.CheckBox()
        Me.Cu_Bp_VistoBueno = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Cb_RequiereVistoBueno = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Dgv_Compradores = New System.Windows.Forms.DataGridView()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dgv_Compradores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel2.Controls.Add(Me.Cu_Bp_VBSubgerencia)
        Me.Panel2.Controls.Add(Me.Cb_RequiereVBSubgerencia)
        Me.Panel2.Controls.Add(Me.Cu_Bp_VistoBueno)
        Me.Panel2.Controls.Add(Me.Cb_RequiereVistoBueno)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 347)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(788, 55)
        Me.Panel2.TabIndex = 5
        '
        'Cu_Bp_VBSubgerencia
        '
        Me.Cu_Bp_VBSubgerencia.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_Bp_VBSubgerencia.Location = New System.Drawing.Point(197, 28)
        Me.Cu_Bp_VBSubgerencia.Name = "Cu_Bp_VBSubgerencia"
        Me.Cu_Bp_VBSubgerencia.Size = New System.Drawing.Size(427, 23)
        Me.Cu_Bp_VBSubgerencia.TabIndex = 4
        Me.Cu_Bp_VBSubgerencia.Tipo = "PHVBSG"
        Me.Cu_Bp_VBSubgerencia.valorcajatexto = "IDENTIFICACION"
        '
        'Cb_RequiereVBSubgerencia
        '
        Me.Cb_RequiereVBSubgerencia.AutoSize = True
        Me.Cb_RequiereVBSubgerencia.Location = New System.Drawing.Point(3, 32)
        Me.Cb_RequiereVBSubgerencia.Name = "Cb_RequiereVBSubgerencia"
        Me.Cb_RequiereVBSubgerencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Cb_RequiereVBSubgerencia.Size = New System.Drawing.Size(192, 17)
        Me.Cb_RequiereVBSubgerencia.TabIndex = 3
        Me.Cb_RequiereVBSubgerencia.Text = "Requiere Visto Bueno Subgerencia"
        Me.Cb_RequiereVBSubgerencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Cb_RequiereVBSubgerencia.UseVisualStyleBackColor = True
        '
        'Cu_Bp_VistoBueno
        '
        Me.Cu_Bp_VistoBueno.FechaReporteDiario = New Date(CType(0, Long))
        Me.Cu_Bp_VistoBueno.Location = New System.Drawing.Point(197, 3)
        Me.Cu_Bp_VistoBueno.Name = "Cu_Bp_VistoBueno"
        Me.Cu_Bp_VistoBueno.Size = New System.Drawing.Size(427, 23)
        Me.Cu_Bp_VistoBueno.TabIndex = 2
        Me.Cu_Bp_VistoBueno.Tipo = "PHVB"
        Me.Cu_Bp_VistoBueno.valorcajatexto = "IDENTIFICACION"
        '
        'Cb_RequiereVistoBueno
        '
        Me.Cb_RequiereVistoBueno.AutoSize = True
        Me.Cb_RequiereVistoBueno.Location = New System.Drawing.Point(66, 7)
        Me.Cb_RequiereVistoBueno.Name = "Cb_RequiereVistoBueno"
        Me.Cb_RequiereVistoBueno.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Cb_RequiereVistoBueno.Size = New System.Drawing.Size(129, 17)
        Me.Cb_RequiereVistoBueno.TabIndex = 1
        Me.Cb_RequiereVistoBueno.Text = "Requiere Visto Bueno"
        Me.Cb_RequiereVistoBueno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Cb_RequiereVistoBueno.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(630, 22)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
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
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Dgv_Compradores
        '
        Me.Dgv_Compradores.AllowUserToAddRows = False
        Me.Dgv_Compradores.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Compradores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Compradores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv_Compradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Compradores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Compradores.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Compradores.Name = "Dgv_Compradores"
        Me.Dgv_Compradores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Compradores.Size = New System.Drawing.Size(788, 347)
        Me.Dgv_Compradores.TabIndex = 6
        '
        'Fr_Compradores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 402)
        Me.Controls.Add(Me.Dgv_Compradores)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Fr_Compradores"
        Me.Text = "Compradores"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dgv_Compradores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Dgv_Compradores As System.Windows.Forms.DataGridView
    Friend WithEvents Cu_Bp_VistoBueno As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cb_RequiereVistoBueno As System.Windows.Forms.CheckBox
    Friend WithEvents Cu_Bp_VBSubgerencia As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents Cb_RequiereVBSubgerencia As System.Windows.Forms.CheckBox
End Class
