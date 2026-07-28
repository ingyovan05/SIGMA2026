<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_RecibirStickers
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
        Me.Dgv_StickersRecepcion = New System.Windows.Forms.DataGridView()
        Me.Tx_CodigoBarras = New System.Windows.Forms.TextBox()
        Me.Flp_Botones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lb_TextoLeerCodigoBarras = New System.Windows.Forms.Label()
        Me.Pn_Controles = New System.Windows.Forms.Panel()
        Me.Col_Etiqueta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Base = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Consecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_De = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NombreTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NumeroDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Memorando = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_DependenciaPara = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NombreGerencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdRecepcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_IdSticker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_NumeroSticker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Dgv_StickersRecepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Controles.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_StickersRecepcion
        '
        Me.Dgv_StickersRecepcion.AllowUserToAddRows = False
        Me.Dgv_StickersRecepcion.AllowUserToDeleteRows = False
        Me.Dgv_StickersRecepcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv_StickersRecepcion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_Etiqueta, Me.Col_Base, Me.Col_Consecutivo, Me.Col_De, Me.Col_NIT, Me.Col_NombreTipo, Me.Col_NumeroDocumento, Me.Col_Valor, Me.Col_Memorando, Me.Col_DependenciaPara, Me.Col_NombreGerencia, Me.Col_IdRecepcion, Me.Col_Descripcion, Me.Col_IdSticker, Me.Col_NumeroSticker})
        Me.Dgv_StickersRecepcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_StickersRecepcion.Location = New System.Drawing.Point(0, 36)
        Me.Dgv_StickersRecepcion.Name = "Dgv_StickersRecepcion"
        Me.Dgv_StickersRecepcion.Size = New System.Drawing.Size(1044, 415)
        Me.Dgv_StickersRecepcion.TabIndex = 1
        '
        'Tx_CodigoBarras
        '
        Me.Tx_CodigoBarras.Location = New System.Drawing.Point(181, 7)
        Me.Tx_CodigoBarras.Name = "Tx_CodigoBarras"
        Me.Tx_CodigoBarras.Size = New System.Drawing.Size(340, 20)
        Me.Tx_CodigoBarras.TabIndex = 0
        '
        'Flp_Botones
        '
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 451)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(1044, 30)
        Me.Flp_Botones.TabIndex = 2
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(966, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 0
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(885, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 1
        Me.Bt_Aceptar.Text = "Guardar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ETIQUETA"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Sticker"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.ToolTipText = "Etiqueta del sticker"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IDBASESISCONTROL"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Base"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.ToolTipText = "Base donde se registró el documento"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "IDRECEPCION"
        Me.DataGridViewTextBoxColumn3.HeaderText = "IDRECEPCION"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "NUMEROSTICKER"
        Me.DataGridViewTextBoxColumn4.HeaderText = "NUMEROSTICKER"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'Lb_TextoLeerCodigoBarras
        '
        Me.Lb_TextoLeerCodigoBarras.AutoSize = True
        Me.Lb_TextoLeerCodigoBarras.Location = New System.Drawing.Point(10, 10)
        Me.Lb_TextoLeerCodigoBarras.Name = "Lb_TextoLeerCodigoBarras"
        Me.Lb_TextoLeerCodigoBarras.Size = New System.Drawing.Size(168, 13)
        Me.Lb_TextoLeerCodigoBarras.TabIndex = 1
        Me.Lb_TextoLeerCodigoBarras.Text = "Leer sticker con código de barras:"
        '
        'Pn_Controles
        '
        Me.Pn_Controles.Controls.Add(Me.Lb_TextoLeerCodigoBarras)
        Me.Pn_Controles.Controls.Add(Me.Tx_CodigoBarras)
        Me.Pn_Controles.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Controles.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Controles.Name = "Pn_Controles"
        Me.Pn_Controles.Size = New System.Drawing.Size(1044, 36)
        Me.Pn_Controles.TabIndex = 2
        '
        'Col_Etiqueta
        '
        Me.Col_Etiqueta.DataPropertyName = "ETIQUETA"
        Me.Col_Etiqueta.HeaderText = "Sticker"
        Me.Col_Etiqueta.Name = "Col_Etiqueta"
        Me.Col_Etiqueta.ReadOnly = True
        Me.Col_Etiqueta.ToolTipText = "Etiqueta del sticker"
        '
        'Col_Base
        '
        Me.Col_Base.DataPropertyName = "BASE"
        Me.Col_Base.HeaderText = "Base"
        Me.Col_Base.Name = "Col_Base"
        Me.Col_Base.ReadOnly = True
        Me.Col_Base.ToolTipText = "Base desde donde se envía el documento"
        '
        'Col_Consecutivo
        '
        Me.Col_Consecutivo.DataPropertyName = "CONSECUTIVO"
        Me.Col_Consecutivo.HeaderText = "Consecutivo"
        Me.Col_Consecutivo.Name = "Col_Consecutivo"
        Me.Col_Consecutivo.ReadOnly = True
        Me.Col_Consecutivo.ToolTipText = "Consecutivo del documento"
        '
        'Col_De
        '
        Me.Col_De.DataPropertyName = "DE"
        Me.Col_De.HeaderText = "De"
        Me.Col_De.Name = "Col_De"
        Me.Col_De.ReadOnly = True
        Me.Col_De.ToolTipText = "Entidad de donde proviene el documento"
        '
        'Col_NIT
        '
        Me.Col_NIT.DataPropertyName = "NIT"
        Me.Col_NIT.HeaderText = "NIT"
        Me.Col_NIT.Name = "Col_NIT"
        Me.Col_NIT.ReadOnly = True
        Me.Col_NIT.ToolTipText = "NIT de la entidad que emite el documento"
        '
        'Col_NombreTipo
        '
        Me.Col_NombreTipo.DataPropertyName = "NOMBRETIPO"
        Me.Col_NombreTipo.HeaderText = "Tipo"
        Me.Col_NombreTipo.Name = "Col_NombreTipo"
        Me.Col_NombreTipo.ReadOnly = True
        Me.Col_NombreTipo.ToolTipText = "Tipo de documento"
        '
        'Col_NumeroDocumento
        '
        Me.Col_NumeroDocumento.DataPropertyName = "NUMERODOCUMENTO"
        Me.Col_NumeroDocumento.HeaderText = "Nº Documento"
        Me.Col_NumeroDocumento.Name = "Col_NumeroDocumento"
        Me.Col_NumeroDocumento.ReadOnly = True
        Me.Col_NumeroDocumento.ToolTipText = "Número o serial del documento"
        '
        'Col_Valor
        '
        Me.Col_Valor.DataPropertyName = "VALOR"
        Me.Col_Valor.HeaderText = "Valor"
        Me.Col_Valor.Name = "Col_Valor"
        Me.Col_Valor.ReadOnly = True
        Me.Col_Valor.ToolTipText = "Valor del documento"
        '
        'Col_Memorando
        '
        Me.Col_Memorando.DataPropertyName = "MEMORANDO"
        Me.Col_Memorando.HeaderText = "Memo"
        Me.Col_Memorando.Name = "Col_Memorando"
        Me.Col_Memorando.ReadOnly = True
        Me.Col_Memorando.ToolTipText = "Memorando"
        '
        'Col_DependenciaPara
        '
        Me.Col_DependenciaPara.DataPropertyName = "DEPENDENCIAPARA"
        Me.Col_DependenciaPara.HeaderText = "Dep. Para"
        Me.Col_DependenciaPara.Name = "Col_DependenciaPara"
        Me.Col_DependenciaPara.ReadOnly = True
        Me.Col_DependenciaPara.ToolTipText = "Dependencia a la que se dirige el documento"
        '
        'Col_NombreGerencia
        '
        Me.Col_NombreGerencia.DataPropertyName = "NOMBREGERENCIA"
        Me.Col_NombreGerencia.HeaderText = "Gerencia"
        Me.Col_NombreGerencia.Name = "Col_NombreGerencia"
        Me.Col_NombreGerencia.ReadOnly = True
        Me.Col_NombreGerencia.ToolTipText = "Gerencia a la que se dirige el documento"
        '
        'Col_IdRecepcion
        '
        Me.Col_IdRecepcion.DataPropertyName = "IDRECEPCION"
        Me.Col_IdRecepcion.HeaderText = "IDRECEPCION"
        Me.Col_IdRecepcion.Name = "Col_IdRecepcion"
        Me.Col_IdRecepcion.ReadOnly = True
        Me.Col_IdRecepcion.Visible = False
        '
        'Col_Descripcion
        '
        Me.Col_Descripcion.DataPropertyName = "DESCRIPCION"
        Me.Col_Descripcion.HeaderText = "DESCRIPCION"
        Me.Col_Descripcion.Name = "Col_Descripcion"
        Me.Col_Descripcion.ReadOnly = True
        Me.Col_Descripcion.Visible = False
        '
        'Col_IdSticker
        '
        Me.Col_IdSticker.DataPropertyName = "IDSTICKER"
        Me.Col_IdSticker.HeaderText = "IDSTICKER"
        Me.Col_IdSticker.Name = "Col_IdSticker"
        Me.Col_IdSticker.ReadOnly = True
        Me.Col_IdSticker.Visible = False
        '
        'Col_NumeroSticker
        '
        Me.Col_NumeroSticker.DataPropertyName = "NUMEROSTICKER"
        Me.Col_NumeroSticker.HeaderText = "NUMEROSTICKER"
        Me.Col_NumeroSticker.Name = "Col_NumeroSticker"
        Me.Col_NumeroSticker.ReadOnly = True
        Me.Col_NumeroSticker.Visible = False
        '
        'Fr_RecibirStickers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 481)
        Me.Controls.Add(Me.Dgv_StickersRecepcion)
        Me.Controls.Add(Me.Pn_Controles)
        Me.Controls.Add(Me.Flp_Botones)
        Me.Name = "Fr_RecibirStickers"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recibir Documentos"
        CType(Me.Dgv_StickersRecepcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Controles.ResumeLayout(False)
        Me.Pn_Controles.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv_StickersRecepcion As System.Windows.Forms.DataGridView
    Friend WithEvents Tx_CodigoBarras As System.Windows.Forms.TextBox
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Lb_TextoLeerCodigoBarras As System.Windows.Forms.Label
    Friend WithEvents Pn_Controles As System.Windows.Forms.Panel
    Friend WithEvents Col_Etiqueta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Consecutivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_De As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NombreTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NumeroDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Memorando As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_DependenciaPara As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NombreGerencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdRecepcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_IdSticker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_NumeroSticker As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
