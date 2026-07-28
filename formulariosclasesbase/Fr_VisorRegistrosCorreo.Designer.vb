<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_VisorRegistrosCorreo
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Dgv_CorreosEnviados = New System.Windows.Forms.DataGridView()
        Me.Bt_ExportarEnviados = New System.Windows.Forms.Button()
        Me.Lb_CorreosEnviados = New System.Windows.Forms.Label()
        Me.Dgv_CorreosSinEnviar = New System.Windows.Forms.DataGridView()
        Me.Bt_ExportarNoEnviados = New System.Windows.Forms.Button()
        Me.Lb_CorreosSinEnviar = New System.Windows.Forms.Label()
        Me.Lb_ConteoRegistros = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Dgv_CorreosEnviados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_CorreosSinEnviar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Lb_ConteoRegistros)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(15)
        Me.Panel1.Size = New System.Drawing.Size(1097, 570)
        Me.Panel1.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(15, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1067, 517)
        Me.Panel2.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Dgv_CorreosEnviados)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Bt_ExportarEnviados)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Lb_CorreosEnviados)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Dgv_CorreosSinEnviar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Bt_ExportarNoEnviados)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Lb_CorreosSinEnviar)
        Me.SplitContainer1.Size = New System.Drawing.Size(1067, 517)
        Me.SplitContainer1.SplitterDistance = 520
        Me.SplitContainer1.TabIndex = 0
        '
        'Dgv_CorreosEnviados
        '
        Me.Dgv_CorreosEnviados.AllowUserToAddRows = False
        Me.Dgv_CorreosEnviados.AllowUserToDeleteRows = False
        Me.Dgv_CorreosEnviados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_CorreosEnviados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_CorreosEnviados.Location = New System.Drawing.Point(0, 23)
        Me.Dgv_CorreosEnviados.Name = "Dgv_CorreosEnviados"
        Me.Dgv_CorreosEnviados.ReadOnly = True
        Me.Dgv_CorreosEnviados.Size = New System.Drawing.Size(516, 463)
        Me.Dgv_CorreosEnviados.TabIndex = 8
        '
        'Bt_ExportarEnviados
        '
        Me.Bt_ExportarEnviados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bt_ExportarEnviados.Enabled = False
        Me.Bt_ExportarEnviados.ForeColor = System.Drawing.Color.DarkGreen
        Me.Bt_ExportarEnviados.Location = New System.Drawing.Point(0, 486)
        Me.Bt_ExportarEnviados.Name = "Bt_ExportarEnviados"
        Me.Bt_ExportarEnviados.Size = New System.Drawing.Size(516, 27)
        Me.Bt_ExportarEnviados.TabIndex = 7
        Me.Bt_ExportarEnviados.Text = "Exportar a Excel"
        Me.Bt_ExportarEnviados.UseVisualStyleBackColor = True
        '
        'Lb_CorreosEnviados
        '
        Me.Lb_CorreosEnviados.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Lb_CorreosEnviados.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_CorreosEnviados.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CorreosEnviados.Name = "Lb_CorreosEnviados"
        Me.Lb_CorreosEnviados.Size = New System.Drawing.Size(516, 23)
        Me.Lb_CorreosEnviados.TabIndex = 0
        Me.Lb_CorreosEnviados.Text = "Correos Enviados"
        Me.Lb_CorreosEnviados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv_CorreosSinEnviar
        '
        Me.Dgv_CorreosSinEnviar.AllowUserToAddRows = False
        Me.Dgv_CorreosSinEnviar.AllowUserToDeleteRows = False
        Me.Dgv_CorreosSinEnviar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_CorreosSinEnviar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_CorreosSinEnviar.Location = New System.Drawing.Point(0, 23)
        Me.Dgv_CorreosSinEnviar.Name = "Dgv_CorreosSinEnviar"
        Me.Dgv_CorreosSinEnviar.ReadOnly = True
        Me.Dgv_CorreosSinEnviar.Size = New System.Drawing.Size(539, 463)
        Me.Dgv_CorreosSinEnviar.TabIndex = 5
        '
        'Bt_ExportarNoEnviados
        '
        Me.Bt_ExportarNoEnviados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bt_ExportarNoEnviados.Enabled = False
        Me.Bt_ExportarNoEnviados.ForeColor = System.Drawing.Color.DarkGreen
        Me.Bt_ExportarNoEnviados.Location = New System.Drawing.Point(0, 486)
        Me.Bt_ExportarNoEnviados.Name = "Bt_ExportarNoEnviados"
        Me.Bt_ExportarNoEnviados.Size = New System.Drawing.Size(539, 27)
        Me.Bt_ExportarNoEnviados.TabIndex = 2
        Me.Bt_ExportarNoEnviados.Text = "Exportar a Excel"
        Me.Bt_ExportarNoEnviados.UseVisualStyleBackColor = True
        '
        'Lb_CorreosSinEnviar
        '
        Me.Lb_CorreosSinEnviar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Lb_CorreosSinEnviar.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_CorreosSinEnviar.Location = New System.Drawing.Point(0, 0)
        Me.Lb_CorreosSinEnviar.Name = "Lb_CorreosSinEnviar"
        Me.Lb_CorreosSinEnviar.Size = New System.Drawing.Size(539, 23)
        Me.Lb_CorreosSinEnviar.TabIndex = 1
        Me.Lb_CorreosSinEnviar.Text = "Correos Sin Enviar"
        Me.Lb_CorreosSinEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_ConteoRegistros
        '
        Me.Lb_ConteoRegistros.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Lb_ConteoRegistros.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_ConteoRegistros.Location = New System.Drawing.Point(15, 15)
        Me.Lb_ConteoRegistros.Name = "Lb_ConteoRegistros"
        Me.Lb_ConteoRegistros.Size = New System.Drawing.Size(1067, 23)
        Me.Lb_ConteoRegistros.TabIndex = 5
        Me.Lb_ConteoRegistros.Text = "Cantidad de Registros: 0"
        Me.Lb_ConteoRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Fr_VisorRegistrosCorreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 570)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Fr_VisorRegistrosCorreo"
        Me.Text = "Visor Envío de correos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Dgv_CorreosEnviados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_CorreosSinEnviar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Dgv_CorreosEnviados As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_ExportarEnviados As System.Windows.Forms.Button
    Friend WithEvents Lb_CorreosEnviados As System.Windows.Forms.Label
    Friend WithEvents Dgv_CorreosSinEnviar As System.Windows.Forms.DataGridView
    Friend WithEvents Bt_ExportarNoEnviados As System.Windows.Forms.Button
    Friend WithEvents Lb_CorreosSinEnviar As System.Windows.Forms.Label
    Friend WithEvents Lb_ConteoRegistros As System.Windows.Forms.Label
End Class
