<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cu_Ciudad
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
        Me.Cb_Ciudad = New System.Windows.Forms.ComboBox()
        Me.MAPOBLACIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_FrBuscarCiudad = New DatosClasesBaseBuscar.Ds_FrBuscarCiudad()
        Me.MA_POBLACIONTableAdapter = New DatosClasesBaseBuscar.Ds_FrBuscarCiudadTableAdapters.MA_POBLACIONTableAdapter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.MAPOBLACIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_FrBuscarCiudad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bt_Buscar
        '
        Me.Bt_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Bt_Buscar.Location = New System.Drawing.Point(334, 1)
        Me.Bt_Buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.Bt_Buscar.Name = "Bt_Buscar"
        Me.Bt_Buscar.Size = New System.Drawing.Size(40, 24)
        Me.Bt_Buscar.TabIndex = 2
        Me.Bt_Buscar.Text = "..."
        Me.Bt_Buscar.UseVisualStyleBackColor = True
        '
        'Tx_Codigo
        '
        Me.Tx_Codigo.Location = New System.Drawing.Point(3, 1)
        Me.Tx_Codigo.Margin = New System.Windows.Forms.Padding(4)
        Me.Tx_Codigo.Name = "Tx_Codigo"
        Me.Tx_Codigo.Size = New System.Drawing.Size(52, 22)
        Me.Tx_Codigo.TabIndex = 0
        '
        'Cb_Ciudad
        '
        Me.Cb_Ciudad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Ciudad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_Ciudad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Ciudad.DataSource = Me.MAPOBLACIONBindingSource
        Me.Cb_Ciudad.DisplayMember = "NOMBREPOBLACION"
        Me.Cb_Ciudad.FormattingEnabled = True
        Me.Cb_Ciudad.Location = New System.Drawing.Point(59, 1)
        Me.Cb_Ciudad.Margin = New System.Windows.Forms.Padding(4)
        Me.Cb_Ciudad.Name = "Cb_Ciudad"
        Me.Cb_Ciudad.Size = New System.Drawing.Size(271, 24)
        Me.Cb_Ciudad.TabIndex = 1
        Me.Cb_Ciudad.ValueMember = "CODIGOPOBLACION"
        '
        'MAPOBLACIONBindingSource
        '
        Me.MAPOBLACIONBindingSource.DataMember = "MA_POBLACION"
        Me.MAPOBLACIONBindingSource.DataSource = Me.Ds_FrBuscarCiudad
        '
        'Ds_FrBuscarCiudad
        '
        Me.Ds_FrBuscarCiudad.DataSetName = "Ds_FrBuscarCiudad"
        Me.Ds_FrBuscarCiudad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MA_POBLACIONTableAdapter
        '
        Me.MA_POBLACIONTableAdapter.ClearBeforeFill = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Tx_Codigo)
        Me.Panel1.Controls.Add(Me.Bt_Buscar)
        Me.Panel1.Controls.Add(Me.Cb_Ciudad)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(377, 28)
        Me.Panel1.TabIndex = 3
        '
        'Cu_Ciudad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Cu_Ciudad"
        Me.Size = New System.Drawing.Size(377, 28)
        CType(Me.MAPOBLACIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_FrBuscarCiudad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bt_Buscar As System.Windows.Forms.Button
    Public WithEvents Cb_Ciudad As System.Windows.Forms.ComboBox
    Friend WithEvents MAPOBLACIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_FrBuscarCiudad As DatosClasesBaseBuscar.Ds_FrBuscarCiudad
    Friend WithEvents MA_POBLACIONTableAdapter As DatosClasesBaseBuscar.Ds_FrBuscarCiudadTableAdapters.MA_POBLACIONTableAdapter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Tx_Codigo As System.Windows.Forms.TextBox

End Class
