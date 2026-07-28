<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_RelacionarFacturas
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Dtp_FechaDocumento = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Dgv_ListaItemEntrada = New System.Windows.Forms.DataGridView()
        Me.PerteneceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FacturaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContratoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequisiciónDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProveedorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdenDeCompraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntradaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnexoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaDocumentoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVencimientoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDRELACIONDOCUMENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDDOCUMENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RELACIONARDOCUMENTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_Facturas = New Facturas.Ds_Facturas()
        Me.RELACIONARDOCUMENTOSTableAdapter = New Facturas.Ds_FacturasTableAdapters.RELACIONARDOCUMENTOSTableAdapter()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Dgv_ListaItemEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RELACIONARDOCUMENTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Info
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(823, 19)
        Me.Panel2.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(823, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Seleccione las facturas que desea inlcuir en la relación"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Dtp_FechaDocumento)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Bt_Guardar)
        Me.Panel3.Controls.Add(Me.Bt_Cerrar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 320)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(823, 33)
        Me.Panel3.TabIndex = 10
        '
        'Dtp_FechaDocumento
        '
        Me.Dtp_FechaDocumento.Enabled = False
        Me.Dtp_FechaDocumento.Location = New System.Drawing.Point(116, 9)
        Me.Dtp_FechaDocumento.Name = "Dtp_FechaDocumento"
        Me.Dtp_FechaDocumento.Size = New System.Drawing.Size(200, 20)
        Me.Dtp_FechaDocumento.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Fecha Documento:"
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Guardar.Location = New System.Drawing.Point(681, 6)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(62, 23)
        Me.Bt_Guardar.TabIndex = 9
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Cerrar.Location = New System.Drawing.Point(749, 6)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(71, 23)
        Me.Bt_Cerrar.TabIndex = 8
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Dgv_ListaItemEntrada
        '
        Me.Dgv_ListaItemEntrada.AllowUserToAddRows = False
        Me.Dgv_ListaItemEntrada.AllowUserToDeleteRows = False
        Me.Dgv_ListaItemEntrada.AutoGenerateColumns = False
        Me.Dgv_ListaItemEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_ListaItemEntrada.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PerteneceDataGridViewTextBoxColumn, Me.FacturaDataGridViewTextBoxColumn, Me.ContratoDataGridViewTextBoxColumn, Me.RequisiciónDataGridViewTextBoxColumn, Me.ProveedorDataGridViewTextBoxColumn, Me.OrdenDeCompraDataGridViewTextBoxColumn, Me.EntradaDataGridViewTextBoxColumn, Me.ValorDataGridViewTextBoxColumn, Me.AnexoDataGridViewTextBoxColumn, Me.FechaDocumentoDataGridViewTextBoxColumn, Me.FechaVencimientoDataGridViewTextBoxColumn, Me.IDRELACIONDOCUMENTODataGridViewTextBoxColumn, Me.IDDOCUMENTODataGridViewTextBoxColumn})
        Me.Dgv_ListaItemEntrada.DataSource = Me.RELACIONARDOCUMENTOSBindingSource
        Me.Dgv_ListaItemEntrada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_ListaItemEntrada.Location = New System.Drawing.Point(0, 19)
        Me.Dgv_ListaItemEntrada.Name = "Dgv_ListaItemEntrada"
        Me.Dgv_ListaItemEntrada.Size = New System.Drawing.Size(823, 301)
        Me.Dgv_ListaItemEntrada.TabIndex = 12
        '
        'PerteneceDataGridViewTextBoxColumn
        '
        Me.PerteneceDataGridViewTextBoxColumn.DataPropertyName = "Pertenece"
        Me.PerteneceDataGridViewTextBoxColumn.FalseValue = "N"
        Me.PerteneceDataGridViewTextBoxColumn.HeaderText = "+"
        Me.PerteneceDataGridViewTextBoxColumn.Name = "PerteneceDataGridViewTextBoxColumn"
        Me.PerteneceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PerteneceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PerteneceDataGridViewTextBoxColumn.TrueValue = "S"
        Me.PerteneceDataGridViewTextBoxColumn.Width = 30
        '
        'FacturaDataGridViewTextBoxColumn
        '
        Me.FacturaDataGridViewTextBoxColumn.DataPropertyName = "Nro Factura"
        Me.FacturaDataGridViewTextBoxColumn.HeaderText = "Nro Factura"
        Me.FacturaDataGridViewTextBoxColumn.Name = "FacturaDataGridViewTextBoxColumn"
        Me.FacturaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ContratoDataGridViewTextBoxColumn
        '
        Me.ContratoDataGridViewTextBoxColumn.DataPropertyName = "Contrato"
        Me.ContratoDataGridViewTextBoxColumn.HeaderText = "Contrato"
        Me.ContratoDataGridViewTextBoxColumn.Name = "ContratoDataGridViewTextBoxColumn"
        Me.ContratoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RequisiciónDataGridViewTextBoxColumn
        '
        Me.RequisiciónDataGridViewTextBoxColumn.DataPropertyName = "Requisición"
        Me.RequisiciónDataGridViewTextBoxColumn.HeaderText = "Requisición"
        Me.RequisiciónDataGridViewTextBoxColumn.Name = "RequisiciónDataGridViewTextBoxColumn"
        Me.RequisiciónDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ProveedorDataGridViewTextBoxColumn
        '
        Me.ProveedorDataGridViewTextBoxColumn.DataPropertyName = "Proveedor"
        Me.ProveedorDataGridViewTextBoxColumn.HeaderText = "Proveedor"
        Me.ProveedorDataGridViewTextBoxColumn.Name = "ProveedorDataGridViewTextBoxColumn"
        Me.ProveedorDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OrdenDeCompraDataGridViewTextBoxColumn
        '
        Me.OrdenDeCompraDataGridViewTextBoxColumn.DataPropertyName = "Orden de Compra"
        Me.OrdenDeCompraDataGridViewTextBoxColumn.HeaderText = "Orden de Compra"
        Me.OrdenDeCompraDataGridViewTextBoxColumn.Name = "OrdenDeCompraDataGridViewTextBoxColumn"
        Me.OrdenDeCompraDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EntradaDataGridViewTextBoxColumn
        '
        Me.EntradaDataGridViewTextBoxColumn.DataPropertyName = "Entrada"
        Me.EntradaDataGridViewTextBoxColumn.HeaderText = "Entrada"
        Me.EntradaDataGridViewTextBoxColumn.Name = "EntradaDataGridViewTextBoxColumn"
        Me.EntradaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ValorDataGridViewTextBoxColumn
        '
        Me.ValorDataGridViewTextBoxColumn.DataPropertyName = "Valor"
        Me.ValorDataGridViewTextBoxColumn.HeaderText = "Valor"
        Me.ValorDataGridViewTextBoxColumn.Name = "ValorDataGridViewTextBoxColumn"
        Me.ValorDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AnexoDataGridViewTextBoxColumn
        '
        Me.AnexoDataGridViewTextBoxColumn.DataPropertyName = "Anexo"
        Me.AnexoDataGridViewTextBoxColumn.HeaderText = "Anexo"
        Me.AnexoDataGridViewTextBoxColumn.Name = "AnexoDataGridViewTextBoxColumn"
        Me.AnexoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FechaDocumentoDataGridViewTextBoxColumn
        '
        Me.FechaDocumentoDataGridViewTextBoxColumn.DataPropertyName = "Fecha Documento"
        Me.FechaDocumentoDataGridViewTextBoxColumn.HeaderText = "Fecha Documento"
        Me.FechaDocumentoDataGridViewTextBoxColumn.Name = "FechaDocumentoDataGridViewTextBoxColumn"
        Me.FechaDocumentoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FechaVencimientoDataGridViewTextBoxColumn
        '
        Me.FechaVencimientoDataGridViewTextBoxColumn.DataPropertyName = "Fecha Vencimiento"
        Me.FechaVencimientoDataGridViewTextBoxColumn.HeaderText = "Fecha Vencimiento"
        Me.FechaVencimientoDataGridViewTextBoxColumn.Name = "FechaVencimientoDataGridViewTextBoxColumn"
        Me.FechaVencimientoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IDRELACIONDOCUMENTODataGridViewTextBoxColumn
        '
        Me.IDRELACIONDOCUMENTODataGridViewTextBoxColumn.DataPropertyName = "IDRELACIONDOCUMENTO"
        Me.IDRELACIONDOCUMENTODataGridViewTextBoxColumn.HeaderText = "IDRELACIONDOCUMENTO"
        Me.IDRELACIONDOCUMENTODataGridViewTextBoxColumn.Name = "IDRELACIONDOCUMENTODataGridViewTextBoxColumn"
        Me.IDRELACIONDOCUMENTODataGridViewTextBoxColumn.Visible = False
        '
        'IDDOCUMENTODataGridViewTextBoxColumn
        '
        Me.IDDOCUMENTODataGridViewTextBoxColumn.DataPropertyName = "IDDOCUMENTO"
        Me.IDDOCUMENTODataGridViewTextBoxColumn.HeaderText = "IDDOCUMENTO"
        Me.IDDOCUMENTODataGridViewTextBoxColumn.Name = "IDDOCUMENTODataGridViewTextBoxColumn"
        Me.IDDOCUMENTODataGridViewTextBoxColumn.Visible = False
        '
        'RELACIONARDOCUMENTOSBindingSource
        '
        Me.RELACIONARDOCUMENTOSBindingSource.DataMember = "RELACIONARDOCUMENTOS"
        Me.RELACIONARDOCUMENTOSBindingSource.DataSource = Me.Ds_Facturas
        '
        'Ds_Facturas
        '
        Me.Ds_Facturas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RELACIONARDOCUMENTOSTableAdapter
        '
        Me.RELACIONARDOCUMENTOSTableAdapter.ClearBeforeFill = True
        '
        'Fr_RelacionarFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 353)
        Me.Controls.Add(Me.Dgv_ListaItemEntrada)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Fr_RelacionarFacturas"
        Me.Text = "Relacionar Facturas"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Dgv_ListaItemEntrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RELACIONARDOCUMENTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Facturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Dgv_ListaItemEntrada As System.Windows.Forms.DataGridView
    Friend WithEvents Ds_Facturas As Facturas.Ds_Facturas
    Friend WithEvents RELACIONARDOCUMENTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RELACIONARDOCUMENTOSTableAdapter As Facturas.Ds_FacturasTableAdapters.RELACIONARDOCUMENTOSTableAdapter
    Friend WithEvents PerteneceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FacturaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContratoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequisiciónDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProveedorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdenDeCompraDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntradaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnexoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaDocumentoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaVencimientoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDRELACIONDOCUMENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDDOCUMENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Dtp_FechaDocumento As System.Windows.Forms.DateTimePicker
End Class
