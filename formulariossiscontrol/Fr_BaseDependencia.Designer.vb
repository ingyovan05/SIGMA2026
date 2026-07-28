<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_BaseDependencia
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
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Lb_NombreBase = New System.Windows.Forms.Label()
        Me.Tx_NombreBase = New System.Windows.Forms.TextBox()
        Me.Lb_Abreviatura = New System.Windows.Forms.Label()
        Me.Tx_Abreviatura = New System.Windows.Forms.TextBox()
        Me.Pn_Base = New System.Windows.Forms.Panel()
        Me.Tx_Direccion = New System.Windows.Forms.TextBox()
        Me.Lb_Direccion = New System.Windows.Forms.Label()
        Me.Cu_Ciudad_Base = New FormulariosClasesBase.Cu_Ciudad()
        Me.Cb_Empresa = New System.Windows.Forms.ComboBox()
        Me.Lb_Empresa = New System.Windows.Forms.Label()
        Me.Lb_Municipio = New System.Windows.Forms.Label()
        Me.Ck_BaseActiva = New System.Windows.Forms.CheckBox()
        Me.Pn_Dependencia = New System.Windows.Forms.Panel()
        Me.Cu_CentroCosto_Dependencia = New FormulariosClasesBase.Cu_CentroCosto()
        Me.Cb_Gerencia = New System.Windows.Forms.ComboBox()
        Me.Tx_NombreDependencia = New System.Windows.Forms.TextBox()
        Me.Lb_Gerencia = New System.Windows.Forms.Label()
        Me.Lb_NombreDependencia = New System.Windows.Forms.Label()
        Me.Ck_DependenciaActiva = New System.Windows.Forms.CheckBox()
        Me.Pn_TituloDependencia = New System.Windows.Forms.Panel()
        Me.Lb_TituloDependencia = New System.Windows.Forms.Label()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Base.SuspendLayout()
        Me.Pn_Dependencia.SuspendLayout()
        Me.Pn_TituloDependencia.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.AutoSize = True
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 237)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(434, 29)
        Me.Flp_Botones.TabIndex = 4
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.Location = New System.Drawing.Point(356, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(275, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Lb_NombreBase
        '
        Me.Lb_NombreBase.AutoSize = True
        Me.Lb_NombreBase.Location = New System.Drawing.Point(3, 20)
        Me.Lb_NombreBase.Name = "Lb_NombreBase"
        Me.Lb_NombreBase.Size = New System.Drawing.Size(74, 13)
        Me.Lb_NombreBase.TabIndex = 0
        Me.Lb_NombreBase.Text = "Nombre Base:"
        '
        'Tx_NombreBase
        '
        Me.Tx_NombreBase.Location = New System.Drawing.Point(80, 17)
        Me.Tx_NombreBase.MaxLength = 100
        Me.Tx_NombreBase.Name = "Tx_NombreBase"
        Me.Tx_NombreBase.Size = New System.Drawing.Size(345, 20)
        Me.Tx_NombreBase.TabIndex = 1
        '
        'Lb_Abreviatura
        '
        Me.Lb_Abreviatura.AutoSize = True
        Me.Lb_Abreviatura.Location = New System.Drawing.Point(13, 44)
        Me.Lb_Abreviatura.Name = "Lb_Abreviatura"
        Me.Lb_Abreviatura.Size = New System.Drawing.Size(64, 13)
        Me.Lb_Abreviatura.TabIndex = 2
        Me.Lb_Abreviatura.Text = "Abreviatura:"
        '
        'Tx_Abreviatura
        '
        Me.Tx_Abreviatura.Location = New System.Drawing.Point(80, 41)
        Me.Tx_Abreviatura.MaxLength = 10
        Me.Tx_Abreviatura.Name = "Tx_Abreviatura"
        Me.Tx_Abreviatura.Size = New System.Drawing.Size(107, 20)
        Me.Tx_Abreviatura.TabIndex = 3
        '
        'Pn_Base
        '
        Me.Pn_Base.Controls.Add(Me.Tx_Direccion)
        Me.Pn_Base.Controls.Add(Me.Lb_Direccion)
        Me.Pn_Base.Controls.Add(Me.Cu_Ciudad_Base)
        Me.Pn_Base.Controls.Add(Me.Cb_Empresa)
        Me.Pn_Base.Controls.Add(Me.Lb_Empresa)
        Me.Pn_Base.Controls.Add(Me.Lb_Municipio)
        Me.Pn_Base.Controls.Add(Me.Ck_BaseActiva)
        Me.Pn_Base.Controls.Add(Me.Tx_Abreviatura)
        Me.Pn_Base.Controls.Add(Me.Lb_Abreviatura)
        Me.Pn_Base.Controls.Add(Me.Tx_NombreBase)
        Me.Pn_Base.Controls.Add(Me.Lb_NombreBase)
        Me.Pn_Base.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Base.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Base.Name = "Pn_Base"
        Me.Pn_Base.Size = New System.Drawing.Size(434, 116)
        Me.Pn_Base.TabIndex = 0
        '
        'Tx_Direccion
        '
        Me.Tx_Direccion.Location = New System.Drawing.Point(80, 90)
        Me.Tx_Direccion.MaxLength = 200
        Me.Tx_Direccion.Name = "Tx_Direccion"
        Me.Tx_Direccion.Size = New System.Drawing.Size(345, 20)
        Me.Tx_Direccion.TabIndex = 10
        '
        'Lb_Direccion
        '
        Me.Lb_Direccion.AutoSize = True
        Me.Lb_Direccion.Location = New System.Drawing.Point(22, 93)
        Me.Lb_Direccion.Name = "Lb_Direccion"
        Me.Lb_Direccion.Size = New System.Drawing.Size(55, 13)
        Me.Lb_Direccion.TabIndex = 9
        Me.Lb_Direccion.Text = "Dirección:"
        '
        'Cu_Ciudad_Base
        '
        Me.Cu_Ciudad_Base.Location = New System.Drawing.Point(80, 63)
        Me.Cu_Ciudad_Base.Name = "Cu_Ciudad_Base"
        Me.Cu_Ciudad_Base.Size = New System.Drawing.Size(345, 23)
        Me.Cu_Ciudad_Base.TabIndex = 8
        '
        'Cb_Empresa
        '
        Me.Cb_Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Empresa.FormattingEnabled = True
        Me.Cb_Empresa.Location = New System.Drawing.Point(250, 41)
        Me.Cb_Empresa.Name = "Cb_Empresa"
        Me.Cb_Empresa.Size = New System.Drawing.Size(76, 21)
        Me.Cb_Empresa.TabIndex = 5
        '
        'Lb_Empresa
        '
        Me.Lb_Empresa.AutoSize = True
        Me.Lb_Empresa.Location = New System.Drawing.Point(197, 44)
        Me.Lb_Empresa.Name = "Lb_Empresa"
        Me.Lb_Empresa.Size = New System.Drawing.Size(51, 13)
        Me.Lb_Empresa.TabIndex = 4
        Me.Lb_Empresa.Text = "Empresa:"
        '
        'Lb_Municipio
        '
        Me.Lb_Municipio.AutoSize = True
        Me.Lb_Municipio.Location = New System.Drawing.Point(23, 67)
        Me.Lb_Municipio.Name = "Lb_Municipio"
        Me.Lb_Municipio.Size = New System.Drawing.Size(55, 13)
        Me.Lb_Municipio.TabIndex = 7
        Me.Lb_Municipio.Text = "Municipio:"
        '
        'Ck_BaseActiva
        '
        Me.Ck_BaseActiva.AutoSize = True
        Me.Ck_BaseActiva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_BaseActiva.Location = New System.Drawing.Point(339, 44)
        Me.Ck_BaseActiva.Name = "Ck_BaseActiva"
        Me.Ck_BaseActiva.Size = New System.Drawing.Size(86, 17)
        Me.Ck_BaseActiva.TabIndex = 6
        Me.Ck_BaseActiva.Text = "Base Activa:"
        Me.Ck_BaseActiva.UseVisualStyleBackColor = True
        '
        'Pn_Dependencia
        '
        Me.Pn_Dependencia.Controls.Add(Me.Cu_CentroCosto_Dependencia)
        Me.Pn_Dependencia.Controls.Add(Me.Cb_Gerencia)
        Me.Pn_Dependencia.Controls.Add(Me.Tx_NombreDependencia)
        Me.Pn_Dependencia.Controls.Add(Me.Lb_Gerencia)
        Me.Pn_Dependencia.Controls.Add(Me.Lb_NombreDependencia)
        Me.Pn_Dependencia.Controls.Add(Me.Ck_DependenciaActiva)
        Me.Pn_Dependencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Dependencia.Location = New System.Drawing.Point(0, 136)
        Me.Pn_Dependencia.Name = "Pn_Dependencia"
        Me.Pn_Dependencia.Size = New System.Drawing.Size(434, 100)
        Me.Pn_Dependencia.TabIndex = 3
        '
        'Cu_CentroCosto_Dependencia
        '
        Me.Cu_CentroCosto_Dependencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cu_CentroCosto_Dependencia.Location = New System.Drawing.Point(6, 57)
        Me.Cu_CentroCosto_Dependencia.Name = "Cu_CentroCosto_Dependencia"
        Me.Cu_CentroCosto_Dependencia.Size = New System.Drawing.Size(418, 38)
        Me.Cu_CentroCosto_Dependencia.TabIndex = 5
        '
        'Cb_Gerencia
        '
        Me.Cb_Gerencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Gerencia.FormattingEnabled = True
        Me.Cb_Gerencia.Location = New System.Drawing.Point(80, 32)
        Me.Cb_Gerencia.Name = "Cb_Gerencia"
        Me.Cb_Gerencia.Size = New System.Drawing.Size(212, 21)
        Me.Cb_Gerencia.TabIndex = 3
        '
        'Tx_NombreDependencia
        '
        Me.Tx_NombreDependencia.Location = New System.Drawing.Point(80, 6)
        Me.Tx_NombreDependencia.MaxLength = 100
        Me.Tx_NombreDependencia.Name = "Tx_NombreDependencia"
        Me.Tx_NombreDependencia.Size = New System.Drawing.Size(345, 20)
        Me.Tx_NombreDependencia.TabIndex = 1
        '
        'Lb_Gerencia
        '
        Me.Lb_Gerencia.AutoSize = True
        Me.Lb_Gerencia.Location = New System.Drawing.Point(24, 35)
        Me.Lb_Gerencia.Name = "Lb_Gerencia"
        Me.Lb_Gerencia.Size = New System.Drawing.Size(53, 13)
        Me.Lb_Gerencia.TabIndex = 2
        Me.Lb_Gerencia.Text = "Gerencia:"
        '
        'Lb_NombreDependencia
        '
        Me.Lb_NombreDependencia.AutoSize = True
        Me.Lb_NombreDependencia.Location = New System.Drawing.Point(30, 9)
        Me.Lb_NombreDependencia.Name = "Lb_NombreDependencia"
        Me.Lb_NombreDependencia.Size = New System.Drawing.Size(47, 13)
        Me.Lb_NombreDependencia.TabIndex = 0
        Me.Lb_NombreDependencia.Text = "Nombre:"
        '
        'Ck_DependenciaActiva
        '
        Me.Ck_DependenciaActiva.AutoSize = True
        Me.Ck_DependenciaActiva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_DependenciaActiva.Location = New System.Drawing.Point(299, 34)
        Me.Ck_DependenciaActiva.Name = "Ck_DependenciaActiva"
        Me.Ck_DependenciaActiva.Size = New System.Drawing.Size(126, 17)
        Me.Ck_DependenciaActiva.TabIndex = 4
        Me.Ck_DependenciaActiva.Text = "Dependencia Activa:"
        Me.Ck_DependenciaActiva.UseVisualStyleBackColor = True
        '
        'Pn_TituloDependencia
        '
        Me.Pn_TituloDependencia.Controls.Add(Me.Lb_TituloDependencia)
        Me.Pn_TituloDependencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_TituloDependencia.Location = New System.Drawing.Point(0, 116)
        Me.Pn_TituloDependencia.Name = "Pn_TituloDependencia"
        Me.Pn_TituloDependencia.Size = New System.Drawing.Size(434, 20)
        Me.Pn_TituloDependencia.TabIndex = 2
        '
        'Lb_TituloDependencia
        '
        Me.Lb_TituloDependencia.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Lb_TituloDependencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_TituloDependencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lb_TituloDependencia.Location = New System.Drawing.Point(0, 0)
        Me.Lb_TituloDependencia.Name = "Lb_TituloDependencia"
        Me.Lb_TituloDependencia.Size = New System.Drawing.Size(434, 20)
        Me.Lb_TituloDependencia.TabIndex = 0
        Me.Lb_TituloDependencia.Text = "DEPENDENCIA"
        Me.Lb_TituloDependencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Fr_BaseDependencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.Bt_Cancelar
        Me.ClientSize = New System.Drawing.Size(434, 266)
        Me.Controls.Add(Me.Pn_Dependencia)
        Me.Controls.Add(Me.Pn_TituloDependencia)
        Me.Controls.Add(Me.Pn_Base)
        Me.Controls.Add(Me.Flp_Botones)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_BaseDependencia"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionando Base y/o Dependencia de SisControl"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Base.ResumeLayout(False)
        Me.Pn_Base.PerformLayout()
        Me.Pn_Dependencia.ResumeLayout(False)
        Me.Pn_Dependencia.PerformLayout()
        Me.Pn_TituloDependencia.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Lb_NombreBase As System.Windows.Forms.Label
    Friend WithEvents Tx_NombreBase As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Abreviatura As System.Windows.Forms.Label
    Friend WithEvents Tx_Abreviatura As System.Windows.Forms.TextBox
    Friend WithEvents Pn_Base As System.Windows.Forms.Panel
    Friend WithEvents Lb_Municipio As System.Windows.Forms.Label
    Friend WithEvents Ck_BaseActiva As System.Windows.Forms.CheckBox
    Friend WithEvents Pn_Dependencia As System.Windows.Forms.Panel
    Friend WithEvents Ck_DependenciaActiva As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_NombreDependencia As System.Windows.Forms.TextBox
    Friend WithEvents Lb_NombreDependencia As System.Windows.Forms.Label
    Friend WithEvents Cb_Empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Empresa As System.Windows.Forms.Label
    Friend WithEvents Cb_Gerencia As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_Gerencia As System.Windows.Forms.Label
    Friend WithEvents Cu_Ciudad_Base As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Cu_CentroCosto_Dependencia As FormulariosClasesBase.Cu_CentroCosto
    Friend WithEvents Pn_TituloDependencia As System.Windows.Forms.Panel
    Friend WithEvents Lb_TituloDependencia As System.Windows.Forms.Label
    Friend WithEvents Tx_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Direccion As System.Windows.Forms.Label

End Class
