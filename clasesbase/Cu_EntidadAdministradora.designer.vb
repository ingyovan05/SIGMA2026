<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_EntidadAdministradora
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.Bt_Buscar = New System.Windows.Forms.Button()
        Me.Tx_Codigo = New System.Windows.Forms.TextBox()
        Me.Cb_NombreAdministradora = New System.Windows.Forms.ComboBox()
        Me.MATIPOENTIDADADMINISTRADORABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_Maestros = New Dscomunes.Ds_Maestros()
        Me.Dtp_FechaAfiliacion = New System.Windows.Forms.DateTimePicker()
        Me.Lb_FechaAfiliacion = New System.Windows.Forms.Label()
        CType(Me.MATIPOENTIDADADMINISTRADORABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Maestros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bt_Buscar
        '
        Me.Bt_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Bt_Buscar.AutoSize = True
        Me.Bt_Buscar.Location = New System.Drawing.Point(232, 0)
        Me.Bt_Buscar.Name = "Bt_Buscar"
        Me.Bt_Buscar.Size = New System.Drawing.Size(29, 23)
        Me.Bt_Buscar.TabIndex = 2
        Me.Bt_Buscar.Text = "..."
        Me.Bt_Buscar.UseVisualStyleBackColor = True
        '
        'Tx_Codigo
        '
        Me.Tx_Codigo.Location = New System.Drawing.Point(0, 1)
        Me.Tx_Codigo.Name = "Tx_Codigo"
        Me.Tx_Codigo.Size = New System.Drawing.Size(44, 20)
        Me.Tx_Codigo.TabIndex = 0
        '
        'Cb_NombreAdministradora
        '
        Me.Cb_NombreAdministradora.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_NombreAdministradora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_NombreAdministradora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_NombreAdministradora.DataSource = Me.MATIPOENTIDADADMINISTRADORABindingSource
        Me.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Me.Cb_NombreAdministradora.FormattingEnabled = True
        Me.Cb_NombreAdministradora.Location = New System.Drawing.Point(45, 1)
        Me.Cb_NombreAdministradora.Name = "Cb_NombreAdministradora"
        Me.Cb_NombreAdministradora.Size = New System.Drawing.Size(185, 21)
        Me.Cb_NombreAdministradora.TabIndex = 1
        Me.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        '
        'Ds_Maestros
        '
        Me.Ds_Maestros.DataSetName = "Ds_Maestros"
        Me.Ds_Maestros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Dtp_FechaAfiliacion
        '
        Me.Dtp_FechaAfiliacion.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Dtp_FechaAfiliacion.Checked = False
        Me.Dtp_FechaAfiliacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaAfiliacion.Location = New System.Drawing.Point(352, 2)
        Me.Dtp_FechaAfiliacion.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.Dtp_FechaAfiliacion.Name = "Dtp_FechaAfiliacion"
        Me.Dtp_FechaAfiliacion.ShowCheckBox = True
        Me.Dtp_FechaAfiliacion.Size = New System.Drawing.Size(102, 20)
        Me.Dtp_FechaAfiliacion.TabIndex = 3
        Me.Dtp_FechaAfiliacion.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'Lb_FechaAfiliacion
        '
        Me.Lb_FechaAfiliacion.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Lb_FechaAfiliacion.AutoSize = True
        Me.Lb_FechaAfiliacion.Location = New System.Drawing.Point(264, 6)
        Me.Lb_FechaAfiliacion.Name = "Lb_FechaAfiliacion"
        Me.Lb_FechaAfiliacion.Size = New System.Drawing.Size(85, 13)
        Me.Lb_FechaAfiliacion.TabIndex = 89
        Me.Lb_FechaAfiliacion.Text = "Fecha Afiliación:"
        '
        'Cu_EntidadAdministradora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Dtp_FechaAfiliacion)
        Me.Controls.Add(Me.Lb_FechaAfiliacion)
        Me.Controls.Add(Me.Cb_NombreAdministradora)
        Me.Controls.Add(Me.Tx_Codigo)
        Me.Controls.Add(Me.Bt_Buscar)
        Me.Name = "Cu_EntidadAdministradora"
        Me.Size = New System.Drawing.Size(460, 23)
        CType(Me.MATIPOENTIDADADMINISTRADORABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Maestros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MATIPOENTIDADADMINISTRADORABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_Maestros As Dscomunes.Ds_Maestros
    Friend WithEvents Lb_FechaAfiliacion As System.Windows.Forms.Label
    Public WithEvents Tx_Codigo As System.Windows.Forms.TextBox
    Public WithEvents Cb_NombreAdministradora As System.Windows.Forms.ComboBox
    Public WithEvents Dtp_FechaAfiliacion As System.Windows.Forms.DateTimePicker
    Public WithEvents Bt_Buscar As System.Windows.Forms.Button

End Class
