<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_MaterialNoConforme
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
        Me.Pn_DatosMNC = New System.Windows.Forms.Panel()
        Me.Tx_ItemOC = New System.Windows.Forms.TextBox()
        Me.Tx_NitProveedor = New System.Windows.Forms.TextBox()
        Me.Tx_NombreProveedor = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarProveedor = New System.Windows.Forms.Button()
        Me.Tx_Contrato = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarOC = New System.Windows.Forms.Button()
        Me.Tx_OrdenCompra = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarRQ = New System.Windows.Forms.Button()
        Me.Tx_Requisicion = New System.Windows.Forms.TextBox()
        Me.Bt_BuscarOT = New System.Windows.Forms.Button()
        Me.Tx_OrdenTrabajo = New System.Windows.Forms.TextBox()
        Me.CuC_Ciudad = New FormulariosClasesBase.Cu_Ciudad()
        Me.Lb_TextoOT = New System.Windows.Forms.Label()
        Me.Tx_Seguimiento = New System.Windows.Forms.TextBox()
        Me.Lb_TextoSeguimiento = New System.Windows.Forms.Label()
        Me.Ck_LlevadoAreaCuarentena = New System.Windows.Forms.CheckBox()
        Me.Tx_Cantidad = New System.Windows.Forms.TextBox()
        Me.Tx_Observacion = New System.Windows.Forms.TextBox()
        Me.Lb_TextoObservacion = New System.Windows.Forms.Label()
        Me.Lb_TextoCantidad = New System.Windows.Forms.Label()
        Me.Cb_Unidad = New System.Windows.Forms.ComboBox()
        Me.Lb_TextoUnidad = New System.Windows.Forms.Label()
        Me.Lb_TextoItemOC = New System.Windows.Forms.Label()
        Me.Lb_TextoOC = New System.Windows.Forms.Label()
        Me.Lb_TextoCiudad = New System.Windows.Forms.Label()
        Me.Lb_TextoRQ = New System.Windows.Forms.Label()
        Me.Lb_TextoProveedor = New System.Windows.Forms.Label()
        Me.Ck_Marcado = New System.Windows.Forms.CheckBox()
        Me.Tx_Descripcion = New System.Windows.Forms.TextBox()
        Me.Lb_TextoDescripcion = New System.Windows.Forms.Label()
        Me.Tx_Material = New System.Windows.Forms.TextBox()
        Me.Lb_TextoMaterial = New System.Windows.Forms.Label()
        Me.Tx_Remision = New System.Windows.Forms.TextBox()
        Me.Tx_Lugar = New System.Windows.Forms.TextBox()
        Me.Dtp_FechaRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.Tx_NumeroReporte = New System.Windows.Forms.TextBox()
        Me.Lb_TextoNumeroReporte = New System.Windows.Forms.Label()
        Me.Lb_TextoRemision = New System.Windows.Forms.Label()
        Me.Lb_TextoLugar = New System.Windows.Forms.Label()
        Me.Lb_TextoContrato = New System.Windows.Forms.Label()
        Me.Lb_TextoFechaRecepcion = New System.Windows.Forms.Label()
        Me.Pn_Firmas = New System.Windows.Forms.Panel()
        Me.CuBP_Acepta = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.CuBP_Elabora = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.CuBP_Verifica = New FormulariosClasesBase.Cu_BuscarPersona()
        Me.Lb_TextoAcepta = New System.Windows.Forms.Label()
        Me.Lb_TextoVerifica = New System.Windows.Forms.Label()
        Me.Lb_TextoElabora = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_TextoFechaCierre = New System.Windows.Forms.Label()
        Me.Dtp_FechaCierre = New System.Windows.Forms.DateTimePicker()
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_DatosMNC.SuspendLayout()
        Me.Pn_Firmas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flp_Botones
        '
        Me.Flp_Botones.BackColor = System.Drawing.Color.Silver
        Me.Flp_Botones.Controls.Add(Me.Bt_Cancelar)
        Me.Flp_Botones.Controls.Add(Me.Bt_Aceptar)
        Me.Flp_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flp_Botones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.Flp_Botones.Location = New System.Drawing.Point(0, 425)
        Me.Flp_Botones.Name = "Flp_Botones"
        Me.Flp_Botones.Size = New System.Drawing.Size(694, 30)
        Me.Flp_Botones.TabIndex = 3
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bt_Cancelar.Location = New System.Drawing.Point(616, 3)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(535, 3)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 0
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Pn_DatosMNC
        '
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_ItemOC)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_NitProveedor)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_NombreProveedor)
        Me.Pn_DatosMNC.Controls.Add(Me.Bt_BuscarProveedor)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_Contrato)
        Me.Pn_DatosMNC.Controls.Add(Me.Bt_BuscarOC)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_OrdenCompra)
        Me.Pn_DatosMNC.Controls.Add(Me.Bt_BuscarRQ)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_Requisicion)
        Me.Pn_DatosMNC.Controls.Add(Me.Bt_BuscarOT)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_OrdenTrabajo)
        Me.Pn_DatosMNC.Controls.Add(Me.CuC_Ciudad)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoOT)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_Seguimiento)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoSeguimiento)
        Me.Pn_DatosMNC.Controls.Add(Me.Ck_LlevadoAreaCuarentena)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_Cantidad)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_Observacion)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoObservacion)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoCantidad)
        Me.Pn_DatosMNC.Controls.Add(Me.Cb_Unidad)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoUnidad)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoItemOC)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoOC)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoCiudad)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoRQ)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoProveedor)
        Me.Pn_DatosMNC.Controls.Add(Me.Ck_Marcado)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_Descripcion)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoDescripcion)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_Material)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoMaterial)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_Remision)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_Lugar)
        Me.Pn_DatosMNC.Controls.Add(Me.Dtp_FechaRecepcion)
        Me.Pn_DatosMNC.Controls.Add(Me.Tx_NumeroReporte)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoNumeroReporte)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoRemision)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoLugar)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoContrato)
        Me.Pn_DatosMNC.Controls.Add(Me.Lb_TextoFechaRecepcion)
        Me.Pn_DatosMNC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_DatosMNC.Location = New System.Drawing.Point(0, 0)
        Me.Pn_DatosMNC.Name = "Pn_DatosMNC"
        Me.Pn_DatosMNC.Size = New System.Drawing.Size(694, 329)
        Me.Pn_DatosMNC.TabIndex = 0
        '
        'Tx_ItemOC
        '
        Me.Tx_ItemOC.Location = New System.Drawing.Point(72, 189)
        Me.Tx_ItemOC.MaxLength = 3
        Me.Tx_ItemOC.Name = "Tx_ItemOC"
        Me.Tx_ItemOC.Size = New System.Drawing.Size(40, 20)
        Me.Tx_ItemOC.TabIndex = 41
        '
        'Tx_NitProveedor
        '
        Me.Tx_NitProveedor.Location = New System.Drawing.Point(72, 63)
        Me.Tx_NitProveedor.Name = "Tx_NitProveedor"
        Me.Tx_NitProveedor.Size = New System.Drawing.Size(40, 20)
        Me.Tx_NitProveedor.TabIndex = 9
        '
        'Tx_NombreProveedor
        '
        Me.Tx_NombreProveedor.Enabled = False
        Me.Tx_NombreProveedor.Location = New System.Drawing.Point(114, 63)
        Me.Tx_NombreProveedor.Name = "Tx_NombreProveedor"
        Me.Tx_NombreProveedor.ReadOnly = True
        Me.Tx_NombreProveedor.Size = New System.Drawing.Size(177, 20)
        Me.Tx_NombreProveedor.TabIndex = 10
        '
        'Bt_BuscarProveedor
        '
        Me.Bt_BuscarProveedor.Location = New System.Drawing.Point(293, 62)
        Me.Bt_BuscarProveedor.Name = "Bt_BuscarProveedor"
        Me.Bt_BuscarProveedor.Size = New System.Drawing.Size(30, 23)
        Me.Bt_BuscarProveedor.TabIndex = 11
        Me.Bt_BuscarProveedor.Text = "..."
        Me.Bt_BuscarProveedor.UseVisualStyleBackColor = True
        '
        'Tx_Contrato
        '
        Me.Tx_Contrato.Enabled = False
        Me.Tx_Contrato.Location = New System.Drawing.Point(72, 11)
        Me.Tx_Contrato.Name = "Tx_Contrato"
        Me.Tx_Contrato.ReadOnly = True
        Me.Tx_Contrato.Size = New System.Drawing.Size(250, 20)
        Me.Tx_Contrato.TabIndex = 1
        '
        'Bt_BuscarOC
        '
        Me.Bt_BuscarOC.Enabled = False
        Me.Bt_BuscarOC.Location = New System.Drawing.Point(653, 115)
        Me.Bt_BuscarOC.Name = "Bt_BuscarOC"
        Me.Bt_BuscarOC.Size = New System.Drawing.Size(30, 23)
        Me.Bt_BuscarOC.TabIndex = 24
        Me.Bt_BuscarOC.Text = "..."
        Me.Bt_BuscarOC.UseVisualStyleBackColor = True
        '
        'Tx_OrdenCompra
        '
        Me.Tx_OrdenCompra.Location = New System.Drawing.Point(420, 116)
        Me.Tx_OrdenCompra.Name = "Tx_OrdenCompra"
        Me.Tx_OrdenCompra.Size = New System.Drawing.Size(231, 20)
        Me.Tx_OrdenCompra.TabIndex = 23
        '
        'Bt_BuscarRQ
        '
        Me.Bt_BuscarRQ.Enabled = False
        Me.Bt_BuscarRQ.Location = New System.Drawing.Point(653, 88)
        Me.Bt_BuscarRQ.Name = "Bt_BuscarRQ"
        Me.Bt_BuscarRQ.Size = New System.Drawing.Size(30, 23)
        Me.Bt_BuscarRQ.TabIndex = 19
        Me.Bt_BuscarRQ.Text = "..."
        Me.Bt_BuscarRQ.UseVisualStyleBackColor = True
        '
        'Tx_Requisicion
        '
        Me.Tx_Requisicion.Location = New System.Drawing.Point(420, 89)
        Me.Tx_Requisicion.Name = "Tx_Requisicion"
        Me.Tx_Requisicion.Size = New System.Drawing.Size(231, 20)
        Me.Tx_Requisicion.TabIndex = 18
        '
        'Bt_BuscarOT
        '
        Me.Bt_BuscarOT.Enabled = False
        Me.Bt_BuscarOT.Location = New System.Drawing.Point(653, 62)
        Me.Bt_BuscarOT.Name = "Bt_BuscarOT"
        Me.Bt_BuscarOT.Size = New System.Drawing.Size(30, 23)
        Me.Bt_BuscarOT.TabIndex = 14
        Me.Bt_BuscarOT.Text = "..."
        Me.Bt_BuscarOT.UseVisualStyleBackColor = True
        '
        'Tx_OrdenTrabajo
        '
        Me.Tx_OrdenTrabajo.Location = New System.Drawing.Point(420, 63)
        Me.Tx_OrdenTrabajo.Name = "Tx_OrdenTrabajo"
        Me.Tx_OrdenTrabajo.Size = New System.Drawing.Size(231, 20)
        Me.Tx_OrdenTrabajo.TabIndex = 13
        '
        'CuC_Ciudad
        '
        Me.CuC_Ciudad.Location = New System.Drawing.Point(70, 88)
        Me.CuC_Ciudad.Name = "CuC_Ciudad"
        Me.CuC_Ciudad.Size = New System.Drawing.Size(256, 23)
        Me.CuC_Ciudad.TabIndex = 16
        '
        'Lb_TextoOT
        '
        Me.Lb_TextoOT.AutoSize = True
        Me.Lb_TextoOT.Location = New System.Drawing.Point(392, 66)
        Me.Lb_TextoOT.Name = "Lb_TextoOT"
        Me.Lb_TextoOT.Size = New System.Drawing.Size(25, 13)
        Me.Lb_TextoOT.TabIndex = 12
        Me.Lb_TextoOT.Text = "OT:"
        '
        'Tx_Seguimiento
        '
        Me.Tx_Seguimiento.Location = New System.Drawing.Point(72, 285)
        Me.Tx_Seguimiento.MaxLength = 300
        Me.Tx_Seguimiento.Multiline = True
        Me.Tx_Seguimiento.Name = "Tx_Seguimiento"
        Me.Tx_Seguimiento.Size = New System.Drawing.Size(610, 40)
        Me.Tx_Seguimiento.TabIndex = 40
        '
        'Lb_TextoSeguimiento
        '
        Me.Lb_TextoSeguimiento.AutoSize = True
        Me.Lb_TextoSeguimiento.Location = New System.Drawing.Point(3, 288)
        Me.Lb_TextoSeguimiento.Name = "Lb_TextoSeguimiento"
        Me.Lb_TextoSeguimiento.Size = New System.Drawing.Size(68, 13)
        Me.Lb_TextoSeguimiento.TabIndex = 39
        Me.Lb_TextoSeguimiento.Text = "Seguimiento:"
        '
        'Ck_LlevadoAreaCuarentena
        '
        Me.Ck_LlevadoAreaCuarentena.AutoSize = True
        Me.Ck_LlevadoAreaCuarentena.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_LlevadoAreaCuarentena.Checked = True
        Me.Ck_LlevadoAreaCuarentena.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_LlevadoAreaCuarentena.Location = New System.Drawing.Point(508, 262)
        Me.Ck_LlevadoAreaCuarentena.Name = "Ck_LlevadoAreaCuarentena"
        Me.Ck_LlevadoAreaCuarentena.Size = New System.Drawing.Size(174, 17)
        Me.Ck_LlevadoAreaCuarentena.TabIndex = 38
        Me.Ck_LlevadoAreaCuarentena.Text = "Llevado a Área de Cuarentena:"
        Me.Ck_LlevadoAreaCuarentena.UseVisualStyleBackColor = True
        '
        'Tx_Cantidad
        '
        Me.Tx_Cantidad.Location = New System.Drawing.Point(284, 189)
        Me.Tx_Cantidad.Name = "Tx_Cantidad"
        Me.Tx_Cantidad.Size = New System.Drawing.Size(38, 20)
        Me.Tx_Cantidad.TabIndex = 32
        '
        'Tx_Observacion
        '
        Me.Tx_Observacion.Location = New System.Drawing.Point(420, 189)
        Me.Tx_Observacion.MaxLength = 100
        Me.Tx_Observacion.Name = "Tx_Observacion"
        Me.Tx_Observacion.Size = New System.Drawing.Size(262, 20)
        Me.Tx_Observacion.TabIndex = 34
        '
        'Lb_TextoObservacion
        '
        Me.Lb_TextoObservacion.AutoSize = True
        Me.Lb_TextoObservacion.Location = New System.Drawing.Point(347, 192)
        Me.Lb_TextoObservacion.Name = "Lb_TextoObservacion"
        Me.Lb_TextoObservacion.Size = New System.Drawing.Size(70, 13)
        Me.Lb_TextoObservacion.TabIndex = 33
        Me.Lb_TextoObservacion.Text = "Observación:"
        '
        'Lb_TextoCantidad
        '
        Me.Lb_TextoCantidad.AutoSize = True
        Me.Lb_TextoCantidad.Location = New System.Drawing.Point(229, 192)
        Me.Lb_TextoCantidad.Name = "Lb_TextoCantidad"
        Me.Lb_TextoCantidad.Size = New System.Drawing.Size(52, 13)
        Me.Lb_TextoCantidad.TabIndex = 31
        Me.Lb_TextoCantidad.Text = "Cantidad:"
        '
        'Cb_Unidad
        '
        Me.Cb_Unidad.DisplayMember = "ABREVIATURA"
        Me.Cb_Unidad.FormattingEnabled = True
        Me.Cb_Unidad.Items.AddRange(New Object() {"N/A", "GL", "KG", "LT", "M", "M2", "M3", "ML", "UND", "ROL"})
        Me.Cb_Unidad.Location = New System.Drawing.Point(163, 189)
        Me.Cb_Unidad.Name = "Cb_Unidad"
        Me.Cb_Unidad.Size = New System.Drawing.Size(60, 21)
        Me.Cb_Unidad.TabIndex = 30
        Me.Cb_Unidad.ValueMember = "CODIGOTIPOUNIDAD"
        '
        'Lb_TextoUnidad
        '
        Me.Lb_TextoUnidad.AutoSize = True
        Me.Lb_TextoUnidad.Location = New System.Drawing.Point(116, 192)
        Me.Lb_TextoUnidad.Name = "Lb_TextoUnidad"
        Me.Lb_TextoUnidad.Size = New System.Drawing.Size(44, 13)
        Me.Lb_TextoUnidad.TabIndex = 29
        Me.Lb_TextoUnidad.Text = "Unidad:"
        '
        'Lb_TextoItemOC
        '
        Me.Lb_TextoItemOC.AutoSize = True
        Me.Lb_TextoItemOC.Location = New System.Drawing.Point(21, 192)
        Me.Lb_TextoItemOC.Name = "Lb_TextoItemOC"
        Me.Lb_TextoItemOC.Size = New System.Drawing.Size(48, 13)
        Me.Lb_TextoItemOC.TabIndex = 27
        Me.Lb_TextoItemOC.Text = "Item OC:"
        '
        'Lb_TextoOC
        '
        Me.Lb_TextoOC.AutoSize = True
        Me.Lb_TextoOC.Location = New System.Drawing.Point(339, 119)
        Me.Lb_TextoOC.Name = "Lb_TextoOC"
        Me.Lb_TextoOC.Size = New System.Drawing.Size(78, 13)
        Me.Lb_TextoOC.TabIndex = 22
        Me.Lb_TextoOC.Text = "Orden Compra:"
        '
        'Lb_TextoCiudad
        '
        Me.Lb_TextoCiudad.AutoSize = True
        Me.Lb_TextoCiudad.Location = New System.Drawing.Point(26, 92)
        Me.Lb_TextoCiudad.Name = "Lb_TextoCiudad"
        Me.Lb_TextoCiudad.Size = New System.Drawing.Size(43, 13)
        Me.Lb_TextoCiudad.TabIndex = 15
        Me.Lb_TextoCiudad.Text = "Ciudad:"
        '
        'Lb_TextoRQ
        '
        Me.Lb_TextoRQ.AutoSize = True
        Me.Lb_TextoRQ.Location = New System.Drawing.Point(352, 92)
        Me.Lb_TextoRQ.Name = "Lb_TextoRQ"
        Me.Lb_TextoRQ.Size = New System.Drawing.Size(65, 13)
        Me.Lb_TextoRQ.TabIndex = 17
        Me.Lb_TextoRQ.Text = "Requisición:"
        '
        'Lb_TextoProveedor
        '
        Me.Lb_TextoProveedor.AutoSize = True
        Me.Lb_TextoProveedor.Location = New System.Drawing.Point(10, 66)
        Me.Lb_TextoProveedor.Name = "Lb_TextoProveedor"
        Me.Lb_TextoProveedor.Size = New System.Drawing.Size(59, 13)
        Me.Lb_TextoProveedor.TabIndex = 8
        Me.Lb_TextoProveedor.Text = "Proveedor:"
        '
        'Ck_Marcado
        '
        Me.Ck_Marcado.AutoSize = True
        Me.Ck_Marcado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ck_Marcado.Checked = True
        Me.Ck_Marcado.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ck_Marcado.Location = New System.Drawing.Point(420, 262)
        Me.Ck_Marcado.Name = "Ck_Marcado"
        Me.Ck_Marcado.Size = New System.Drawing.Size(71, 17)
        Me.Ck_Marcado.TabIndex = 37
        Me.Ck_Marcado.Text = "Marcado:"
        Me.Ck_Marcado.UseVisualStyleBackColor = True
        '
        'Tx_Descripcion
        '
        Me.Tx_Descripcion.Location = New System.Drawing.Point(72, 216)
        Me.Tx_Descripcion.MaxLength = 300
        Me.Tx_Descripcion.Multiline = True
        Me.Tx_Descripcion.Name = "Tx_Descripcion"
        Me.Tx_Descripcion.Size = New System.Drawing.Size(610, 40)
        Me.Tx_Descripcion.TabIndex = 36
        '
        'Lb_TextoDescripcion
        '
        Me.Lb_TextoDescripcion.AutoSize = True
        Me.Lb_TextoDescripcion.Location = New System.Drawing.Point(3, 219)
        Me.Lb_TextoDescripcion.Name = "Lb_TextoDescripcion"
        Me.Lb_TextoDescripcion.Size = New System.Drawing.Size(66, 13)
        Me.Lb_TextoDescripcion.TabIndex = 35
        Me.Lb_TextoDescripcion.Text = "Descripción:"
        '
        'Tx_Material
        '
        Me.Tx_Material.Location = New System.Drawing.Point(72, 143)
        Me.Tx_Material.Multiline = True
        Me.Tx_Material.Name = "Tx_Material"
        Me.Tx_Material.Size = New System.Drawing.Size(610, 40)
        Me.Tx_Material.TabIndex = 26
        '
        'Lb_TextoMaterial
        '
        Me.Lb_TextoMaterial.AutoSize = True
        Me.Lb_TextoMaterial.Location = New System.Drawing.Point(22, 146)
        Me.Lb_TextoMaterial.Name = "Lb_TextoMaterial"
        Me.Lb_TextoMaterial.Size = New System.Drawing.Size(47, 13)
        Me.Lb_TextoMaterial.TabIndex = 25
        Me.Lb_TextoMaterial.Text = "Material:"
        '
        'Tx_Remision
        '
        Me.Tx_Remision.Location = New System.Drawing.Point(72, 116)
        Me.Tx_Remision.MaxLength = 10
        Me.Tx_Remision.Name = "Tx_Remision"
        Me.Tx_Remision.Size = New System.Drawing.Size(95, 20)
        Me.Tx_Remision.TabIndex = 21
        '
        'Tx_Lugar
        '
        Me.Tx_Lugar.Location = New System.Drawing.Point(72, 37)
        Me.Tx_Lugar.MaxLength = 100
        Me.Tx_Lugar.Name = "Tx_Lugar"
        Me.Tx_Lugar.Size = New System.Drawing.Size(250, 20)
        Me.Tx_Lugar.TabIndex = 5
        '
        'Dtp_FechaRecepcion
        '
        Me.Dtp_FechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaRecepcion.Location = New System.Drawing.Point(562, 37)
        Me.Dtp_FechaRecepcion.Name = "Dtp_FechaRecepcion"
        Me.Dtp_FechaRecepcion.ShowCheckBox = True
        Me.Dtp_FechaRecepcion.Size = New System.Drawing.Size(120, 20)
        Me.Dtp_FechaRecepcion.TabIndex = 7
        '
        'Tx_NumeroReporte
        '
        Me.Tx_NumeroReporte.Location = New System.Drawing.Point(420, 11)
        Me.Tx_NumeroReporte.MaxLength = 50
        Me.Tx_NumeroReporte.Name = "Tx_NumeroReporte"
        Me.Tx_NumeroReporte.Size = New System.Drawing.Size(262, 20)
        Me.Tx_NumeroReporte.TabIndex = 3
        '
        'Lb_TextoNumeroReporte
        '
        Me.Lb_TextoNumeroReporte.AutoSize = True
        Me.Lb_TextoNumeroReporte.Location = New System.Drawing.Point(349, 14)
        Me.Lb_TextoNumeroReporte.Name = "Lb_TextoNumeroReporte"
        Me.Lb_TextoNumeroReporte.Size = New System.Drawing.Size(68, 13)
        Me.Lb_TextoNumeroReporte.TabIndex = 2
        Me.Lb_TextoNumeroReporte.Text = "Reporte No.:"
        '
        'Lb_TextoRemision
        '
        Me.Lb_TextoRemision.AutoSize = True
        Me.Lb_TextoRemision.Location = New System.Drawing.Point(16, 119)
        Me.Lb_TextoRemision.Name = "Lb_TextoRemision"
        Me.Lb_TextoRemision.Size = New System.Drawing.Size(53, 13)
        Me.Lb_TextoRemision.TabIndex = 20
        Me.Lb_TextoRemision.Text = "Remisión:"
        '
        'Lb_TextoLugar
        '
        Me.Lb_TextoLugar.AutoSize = True
        Me.Lb_TextoLugar.Location = New System.Drawing.Point(32, 40)
        Me.Lb_TextoLugar.Name = "Lb_TextoLugar"
        Me.Lb_TextoLugar.Size = New System.Drawing.Size(37, 13)
        Me.Lb_TextoLugar.TabIndex = 4
        Me.Lb_TextoLugar.Text = "Lugar:"
        '
        'Lb_TextoContrato
        '
        Me.Lb_TextoContrato.AutoSize = True
        Me.Lb_TextoContrato.Location = New System.Drawing.Point(19, 14)
        Me.Lb_TextoContrato.Name = "Lb_TextoContrato"
        Me.Lb_TextoContrato.Size = New System.Drawing.Size(50, 13)
        Me.Lb_TextoContrato.TabIndex = 0
        Me.Lb_TextoContrato.Text = "Contrato:"
        '
        'Lb_TextoFechaRecepcion
        '
        Me.Lb_TextoFechaRecepcion.AutoSize = True
        Me.Lb_TextoFechaRecepcion.Location = New System.Drawing.Point(464, 40)
        Me.Lb_TextoFechaRecepcion.Name = "Lb_TextoFechaRecepcion"
        Me.Lb_TextoFechaRecepcion.Size = New System.Drawing.Size(95, 13)
        Me.Lb_TextoFechaRecepcion.TabIndex = 6
        Me.Lb_TextoFechaRecepcion.Text = "Fecha Recepción:"
        '
        'Pn_Firmas
        '
        Me.Pn_Firmas.Controls.Add(Me.CuBP_Acepta)
        Me.Pn_Firmas.Controls.Add(Me.CuBP_Elabora)
        Me.Pn_Firmas.Controls.Add(Me.CuBP_Verifica)
        Me.Pn_Firmas.Controls.Add(Me.Lb_TextoAcepta)
        Me.Pn_Firmas.Controls.Add(Me.Lb_TextoVerifica)
        Me.Pn_Firmas.Controls.Add(Me.Lb_TextoElabora)
        Me.Pn_Firmas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn_Firmas.Location = New System.Drawing.Point(0, 329)
        Me.Pn_Firmas.Name = "Pn_Firmas"
        Me.Pn_Firmas.Size = New System.Drawing.Size(694, 62)
        Me.Pn_Firmas.TabIndex = 1
        '
        'CuBP_Acepta
        '
        Me.CuBP_Acepta.FechaReporteDiario = New Date(CType(0, Long))
        Me.CuBP_Acepta.Location = New System.Drawing.Point(418, 6)
        Me.CuBP_Acepta.Name = "CuBP_Acepta"
        Me.CuBP_Acepta.Size = New System.Drawing.Size(269, 23)
        Me.CuBP_Acepta.TabIndex = 3
        Me.CuBP_Acepta.Tipo = "PABASESC"
        Me.CuBP_Acepta.valorcajatexto = Nothing
        '
        'CuBP_Elabora
        '
        Me.CuBP_Elabora.FechaReporteDiario = New Date(CType(0, Long))
        Me.CuBP_Elabora.Location = New System.Drawing.Point(70, 6)
        Me.CuBP_Elabora.Name = "CuBP_Elabora"
        Me.CuBP_Elabora.Size = New System.Drawing.Size(257, 23)
        Me.CuBP_Elabora.TabIndex = 1
        Me.CuBP_Elabora.Tipo = "PABASESC"
        Me.CuBP_Elabora.valorcajatexto = Nothing
        '
        'CuBP_Verifica
        '
        Me.CuBP_Verifica.FechaReporteDiario = New Date(CType(0, Long))
        Me.CuBP_Verifica.Location = New System.Drawing.Point(70, 35)
        Me.CuBP_Verifica.Name = "CuBP_Verifica"
        Me.CuBP_Verifica.Size = New System.Drawing.Size(257, 23)
        Me.CuBP_Verifica.TabIndex = 5
        Me.CuBP_Verifica.Tipo = "PABASESC"
        Me.CuBP_Verifica.valorcajatexto = Nothing
        '
        'Lb_TextoAcepta
        '
        Me.Lb_TextoAcepta.AutoSize = True
        Me.Lb_TextoAcepta.Location = New System.Drawing.Point(373, 10)
        Me.Lb_TextoAcepta.Name = "Lb_TextoAcepta"
        Me.Lb_TextoAcepta.Size = New System.Drawing.Size(44, 13)
        Me.Lb_TextoAcepta.TabIndex = 2
        Me.Lb_TextoAcepta.Text = "Acepta:"
        '
        'Lb_TextoVerifica
        '
        Me.Lb_TextoVerifica.AutoSize = True
        Me.Lb_TextoVerifica.Location = New System.Drawing.Point(24, 39)
        Me.Lb_TextoVerifica.Name = "Lb_TextoVerifica"
        Me.Lb_TextoVerifica.Size = New System.Drawing.Size(45, 13)
        Me.Lb_TextoVerifica.TabIndex = 4
        Me.Lb_TextoVerifica.Text = "Verifica:"
        '
        'Lb_TextoElabora
        '
        Me.Lb_TextoElabora.AutoSize = True
        Me.Lb_TextoElabora.Location = New System.Drawing.Point(23, 10)
        Me.Lb_TextoElabora.Name = "Lb_TextoElabora"
        Me.Lb_TextoElabora.Size = New System.Drawing.Size(46, 13)
        Me.Lb_TextoElabora.TabIndex = 0
        Me.Lb_TextoElabora.Text = "Elabora:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Lb_TextoFechaCierre)
        Me.Panel1.Controls.Add(Me.Dtp_FechaCierre)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 391)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(694, 34)
        Me.Panel1.TabIndex = 2
        '
        'Lb_TextoFechaCierre
        '
        Me.Lb_TextoFechaCierre.AutoSize = True
        Me.Lb_TextoFechaCierre.Enabled = False
        Me.Lb_TextoFechaCierre.Location = New System.Drawing.Point(-1, 9)
        Me.Lb_TextoFechaCierre.Name = "Lb_TextoFechaCierre"
        Me.Lb_TextoFechaCierre.Size = New System.Drawing.Size(70, 13)
        Me.Lb_TextoFechaCierre.TabIndex = 0
        Me.Lb_TextoFechaCierre.Text = "Fecha Cierre:"
        '
        'Dtp_FechaCierre
        '
        Me.Dtp_FechaCierre.Checked = False
        Me.Dtp_FechaCierre.Enabled = False
        Me.Dtp_FechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FechaCierre.Location = New System.Drawing.Point(72, 6)
        Me.Dtp_FechaCierre.Name = "Dtp_FechaCierre"
        Me.Dtp_FechaCierre.Size = New System.Drawing.Size(95, 20)
        Me.Dtp_FechaCierre.TabIndex = 1
        '
        'Fr_MaterialNoConforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 455)
        Me.Controls.Add(Me.Pn_DatosMNC)
        Me.Controls.Add(Me.Pn_Firmas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Flp_Botones)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_MaterialNoConforme"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Material No Conforme"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_DatosMNC.ResumeLayout(False)
        Me.Pn_DatosMNC.PerformLayout()
        Me.Pn_Firmas.ResumeLayout(False)
        Me.Pn_Firmas.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Flp_Botones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Pn_DatosMNC As System.Windows.Forms.Panel
    Friend WithEvents Pn_Firmas As System.Windows.Forms.Panel
    Friend WithEvents Lb_TextoOT As System.Windows.Forms.Label
    Friend WithEvents Tx_Seguimiento As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoSeguimiento As System.Windows.Forms.Label
    Friend WithEvents Ck_LlevadoAreaCuarentena As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Observacion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoObservacion As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCantidad As System.Windows.Forms.Label
    Friend WithEvents Cb_Unidad As System.Windows.Forms.ComboBox
    Friend WithEvents Lb_TextoUnidad As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoItemOC As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoOC As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoCiudad As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoRQ As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoProveedor As System.Windows.Forms.Label
    Friend WithEvents Ck_Marcado As System.Windows.Forms.CheckBox
    Friend WithEvents Tx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoDescripcion As System.Windows.Forms.Label
    Friend WithEvents Tx_Material As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoMaterial As System.Windows.Forms.Label
    Friend WithEvents Tx_Remision As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Lugar As System.Windows.Forms.TextBox
    Friend WithEvents Dtp_FechaRecepcion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tx_NumeroReporte As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoNumeroReporte As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoRemision As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoLugar As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoContrato As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoFechaRecepcion As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoAcepta As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoVerifica As System.Windows.Forms.Label
    Friend WithEvents Lb_TextoElabora As System.Windows.Forms.Label
    Friend WithEvents CuBP_Elabora As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents CuBP_Verifica As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents CuBP_Acepta As FormulariosClasesBase.Cu_BuscarPersona
    Friend WithEvents CuC_Ciudad As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Dtp_FechaCierre As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_TextoFechaCierre As System.Windows.Forms.Label
    Friend WithEvents Tx_OrdenTrabajo As System.Windows.Forms.TextBox
    Friend WithEvents Bt_BuscarOT As System.Windows.Forms.Button
    Friend WithEvents Bt_BuscarOC As System.Windows.Forms.Button
    Friend WithEvents Tx_OrdenCompra As System.Windows.Forms.TextBox
    Friend WithEvents Bt_BuscarRQ As System.Windows.Forms.Button
    Friend WithEvents Tx_Requisicion As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Contrato As System.Windows.Forms.TextBox
    Friend WithEvents Bt_BuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Tx_NitProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Tx_NombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Tx_ItemOC As System.Windows.Forms.TextBox
End Class
