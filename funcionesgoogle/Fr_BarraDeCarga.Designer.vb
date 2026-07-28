<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_BarraDeCarga
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
        Me.Pb_ArchivosSubidos = New System.Windows.Forms.ProgressBar()
        Me.Lb_ArchivosSubidos = New System.Windows.Forms.Label()
        Me.Pn_ArchivosSubidos = New System.Windows.Forms.Panel()
        Me.Bgw_ArchivosSubidos = New System.ComponentModel.BackgroundWorker()
        Me.Pn_Label = New System.Windows.Forms.Panel()
        Me.Pn_ArchivosSubidos.SuspendLayout()
        Me.Pn_Label.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pb_ArchivosSubidos
        '
        Me.Pb_ArchivosSubidos.Location = New System.Drawing.Point(11, 9)
        Me.Pb_ArchivosSubidos.Name = "Pb_ArchivosSubidos"
        Me.Pb_ArchivosSubidos.Size = New System.Drawing.Size(638, 23)
        Me.Pb_ArchivosSubidos.TabIndex = 1
        '
        'Lb_ArchivosSubidos
        '
        Me.Lb_ArchivosSubidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_ArchivosSubidos.AutoSize = True
        Me.Lb_ArchivosSubidos.Location = New System.Drawing.Point(275, 7)
        Me.Lb_ArchivosSubidos.Name = "Lb_ArchivosSubidos"
        Me.Lb_ArchivosSubidos.Size = New System.Drawing.Size(107, 13)
        Me.Lb_ArchivosSubidos.TabIndex = 2
        Me.Lb_ArchivosSubidos.Text = "Archivos Procesados"
        Me.Lb_ArchivosSubidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pn_ArchivosSubidos
        '
        Me.Pn_ArchivosSubidos.Controls.Add(Me.Pb_ArchivosSubidos)
        Me.Pn_ArchivosSubidos.Location = New System.Drawing.Point(1, 32)
        Me.Pn_ArchivosSubidos.Name = "Pn_ArchivosSubidos"
        Me.Pn_ArchivosSubidos.Size = New System.Drawing.Size(659, 37)
        Me.Pn_ArchivosSubidos.TabIndex = 3
        '
        'Bgw_ArchivosSubidos
        '
        Me.Bgw_ArchivosSubidos.WorkerReportsProgress = True
        '
        'Pn_Label
        '
        Me.Pn_Label.Controls.Add(Me.Lb_ArchivosSubidos)
        Me.Pn_Label.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Label.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Label.Name = "Pn_Label"
        Me.Pn_Label.Size = New System.Drawing.Size(662, 28)
        Me.Pn_Label.TabIndex = 3
        '
        'Fr_BarraDeCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 76)
        Me.Controls.Add(Me.Pn_Label)
        Me.Controls.Add(Me.Pn_ArchivosSubidos)
        Me.MaximumSize = New System.Drawing.Size(678, 115)
        Me.MinimumSize = New System.Drawing.Size(678, 115)
        Me.Name = "Fr_BarraDeCarga"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Archivos Subidos"
        Me.Pn_ArchivosSubidos.ResumeLayout(False)
        Me.Pn_Label.ResumeLayout(False)
        Me.Pn_Label.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pb_ArchivosSubidos As System.Windows.Forms.ProgressBar
    Friend WithEvents Lb_ArchivosSubidos As System.Windows.Forms.Label
    Friend WithEvents Pn_ArchivosSubidos As System.Windows.Forms.Panel
    Friend WithEvents Bgw_ArchivosSubidos As System.ComponentModel.BackgroundWorker
    Friend WithEvents Pn_Label As System.Windows.Forms.Panel
End Class
