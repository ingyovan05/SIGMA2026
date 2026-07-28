Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class Fr_OrdenCompra
    ''' <summary>Indica si el formulario se abre con los campos habilitados para impresión</summary>
    Public Editando As Boolean = False
    ''' <summary></summary>
    Public Imprimir As Boolean = False
    ''' <summary>Identificador de la requisición a partir de la cual se va a realizar la orden de compra</summary>
    Public IDREQUISICION As Long = -1
    ''' <summary>Identificador de la bodega a la que pertenece la orden de compra</summary>
    Public IDBODEGAORDENCOMPRA As Integer = VariablesBase.VariablesBase.IdBodegaActual
    ''' <summary>Identificador de la orden de compra que se va a editar</summary>
    Public IDORDENCOMPRAMODIFICANDO As Long
    ''' <summary>Identificador del proveedor de la orden de compra</summary>
    Public IDENTIFICACIONPROVEEDOR As String
    ''' <summary></summary>
    Public guardado As Boolean = False

    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private DsOrdenCompra As New DatosOrdenCompra.Ds_OrdenCompra
    Private dsCargar As New DataSet
    Private FilaRequisicion As DataRow
    Private FilaOC As DataRow
    Private TempBodega As Integer
    Private FilaProveedor As DataRow
    Private Estilo_Celda_Error As New DataGridViewCellStyle
    Private Calculando As Boolean = False
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private cargado As Boolean = False
    Private ultimaTRM As Decimal = 1

    Private Sub Fr_OrdenCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Tx_TRM.KeyPress, AddressOf FuncionesBase.FuncionesBase.TextBoxMoneda_KeyPress
        AddHandler Tx_TRM.LostFocus, AddressOf FuncionesBase.FuncionesBase.TextBoxMoneda_Lostfocus
    End Sub

    ''' <summary></summary>
    Public Sub Comportamiento_Predeterminado()
        Me.Dgv_Item.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Item.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Cu_ApbRevisa.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbRevisa.Tag)
        Cu_ApbAutoriza.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbAutoriza.Tag)
        Cu_ApbAprueba.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbAprueba.Tag)
        Cu_ApbGerencia.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbGerencia.Tag)
    End Sub

    ''' <summary></summary>
    Public Sub CargarDatos()
        ' 0 --> ORDENCOMPRA
        ' 1 --> ITEMORDENCOMPRA
        ' 2 --> MA_TIPOORDENCOMPRA
        ' 3 --> MA_TIPOMONEDA
        ' 4 --> dbo.ListaDirecciones
        ' 5 --> Cu_BuscarPersonaSolicita
        ' 6 --> Cu_BuscarPersonaAprueba
        ' 7 --> Cu_BuscarPersonaAutoriza
        ' 8 --> Cu_BuscarPersonaRevisa

        Dim identificador As Long
        Dim tipo As Integer

        If IDORDENCOMPRAMODIFICANDO <= 0 Then
            identificador = IDREQUISICION
            tipo = 1 'Crear
        Else
            identificador = IDORDENCOMPRAMODIFICANDO
            tipo = 2 'Editar
        End If

        'Cargar tablas
        dsCargar = bddatos.CargarMaestrasMateriales(1, VariablesBase.VariablesBase.IdBodegaActual, identificador, tipo)

        If Editando = False Then ' Nueva orden de compra a partir de la RQ
            If Me.dsCargar.Tables(1).Rows.Count = 0 Then
                MsgBox("No hay ítem pendientes de esta requisición", MsgBoxStyle.Information, "No hay ítems pendientes")
                guardado = True
                Me.Close()
                Exit Sub
            End If

            FilaRequisicion = dsCargar.Tables(0).Rows(0)

            Me.Lb_Requisición.Text = "Nro Req:  " + FilaRequisicion("REQUISICION") + "   Fecha Solicitud:  " + CDate(FilaRequisicion("FECHASOLICITUD")).ToShortDateString
            Me.Tx_Encabezado.Text = Trim(FilaRequisicion("ENCABEZADO"))

            Me.Cu_CentroCosto1.IdCentroCosto = FilaRequisicion("IDCENTROCOSTO")
            Me.Cu_CentroCosto1.Ll_CentroCostos.Text = FilaRequisicion("CENTROCOSTO")
            Me.Cu_CentroCosto1.Editando = 0

            Me.Dgv_Item.DataSource = Me.dsCargar.Tables(1)
            Me.Dgv_Item.AllowUserToOrderColumns = False
            'Definir el estilo de encabezado del DataGrid para que salga en dos renglones
            Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
            DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle5.Font = New Font("Arial", 7.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.WrapMode = DataGridViewTriState.[True]
            Me.Dgv_Item.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
            Me.Dgv_Item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

            Me.Cu_BuscarPersonaAutoriza.DT_BUSCARPERSONA = dsCargar.Tables(5)
            Me.Cu_BuscarPersonaAutoriza.Cb_Persona.DataSource = Me.Cu_BuscarPersonaAutoriza.DT_BUSCARPERSONA
            Me.Cu_BuscarPersonaAprueba.DT_BUSCARPERSONA = dsCargar.Tables(6)
            Me.Cu_BuscarPersonaAprueba.Cb_Persona.DataSource = Me.Cu_BuscarPersonaAprueba.DT_BUSCARPERSONA
            Me.Cu_BuscarPersonaGerencia.DT_BUSCARPERSONA = dsCargar.Tables(7)
            Me.Cu_BuscarPersonaGerencia.Cb_Persona.DataSource = Me.Cu_BuscarPersonaGerencia.DT_BUSCARPERSONA
            Me.Cu_BuscarPersonaRevisa.DT_BUSCARPERSONA = dsCargar.Tables(8)
            Me.Cu_BuscarPersonaRevisa.Cb_Persona.DataSource = Me.Cu_BuscarPersonaRevisa.DT_BUSCARPERSONA

            Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "OC", "AUTORIZA", -1)
            Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "OC", "REVISA", -1)
            Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "OC", "APRUEBA", -1)
            Cu_BuscarPersonaGerencia.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "OC", "GERENCIA", -1)
        End If

        Me.Cb_TipoDescuento.SelectedIndex = 0
        Me.Cu_CiudadDirección.CargarDatos()
        Me.Cb_TipoOrdenCompra.DataSource = Me.dsCargar.Tables(2)
        Me.Cb_TipoOrdenCompra.DisplayMember = "NOMBRETIPOORDENCOMPRA"
        Me.Cb_TipoOrdenCompra.ValueMember = "CODIGOTIPOORDENCOMPRA"

        If Editando = False Then
            Tx_CondiciónPago.Text = "CRÉDITO 45 DÍAS FECHA RADICACIÓN FACTURA"
        End If

        Me.Cb_TipoMoneda.DataSource = Me.dsCargar.Tables(3)
        Me.Cb_TipoMoneda.DisplayMember = "NOMBRETIPOMONEDA"
        Me.Cb_TipoMoneda.ValueMember = "CODIGOTIPOMONEDA"

        Me.Tx_TRM.Enabled = False
        Me.Ck_ValorIncluyeArancel.Enabled = False

        Me.Dtp_FechaDespacho.MinDate = Date.Now
        Me.Dtp_FechaDespacho.MaxDate = Date.Now.AddDays(90)

        If Editando = False Then
            Me.Cms_Direcciones.Items.Clear()
            For i = 0 To Me.dsCargar.Tables(4).Rows.Count - 1
                Dim fila As DataRow
                fila = Me.dsCargar.Tables(4).Rows(i)
                Dim Item As New ToolStripMenuItem("DIRECCION", Nothing, New EventHandler(AddressOf Me.ClickMenuDirección))
                Item.Text = fila("DIRECCION")
                Me.Cms_Direcciones.Items.Add(Item)
            Next

            Try
                Dim fila1 As DataRow
                fila1 = Me.dsCargar.Tables(0).Rows(0)
                Me.Tx_DespacharA.Text = fila1("DESTINO")
            Catch ex As Exception
                Me.Tx_DespacharA.Text = VariablesBase.VariablesBase.DireccionBodegaActual
            End Try
        End If

        Comportamiento_Predeterminado()
        Marcar_Cajas_Vacias()
        If Editando = True Then
            Cargar_Orden_Compra()
        End If
    End Sub

    Private Sub ClickMenuDirección(sender As Object, e As EventArgs)
        Dim item As New ToolStripMenuItem
        item = sender
        Me.Tx_DespacharA.Text = item.Text
    End Sub

    'Private Sub ClickMenuIngreso(sender As Object, e As EventArgs)
    '    Dim item As New ToolStripMenuItem
    '    item = sender
    '    'Me.Tx_CondiciónPago.Text = item.Text
    'End Sub

    ''' <summary></summary>
    Private Sub Cargar_Orden_Compra()
        FilaOC = dsCargar.Tables(0).Rows(0)
        Me.Lb_Requisición.Text = "Nro Req:  " + FilaOC("REQUISICION") + "   Fecha Solicitud:  " + CDate(FilaOC("FECHASOLICITUD")).ToShortDateString
        Me.Cu_CentroCosto1.IdCentroCosto = FilaOC("IDCENTROCOSTO")
        Me.Cu_CentroCosto1.Ll_CentroCostos.Text = FilaOC("CENTROCOSTO")
        Me.Dgv_Item.DataSource = Me.dsCargar.Tables(1)
        Me.Dgv_Item.AllowUserToOrderColumns = False
        'Definir el estilo de encabezado del DataGrid para que salga en dos renglones
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New Font("Arial", 7.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.[True]
        Me.Dgv_Item.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Dgv_Item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        If Editando = True Then
            Dim filaordencompra As DataRow
            filaordencompra = dsCargar.Tables(0).Rows(0)

            Me.Tx_Identificación.Text = IDENTIFICACIONPROVEEDOR
            Me.Cargar_Proveedor()
            Me.Tx_Identificación.Enabled = False
            Me.Bt_BuscarProveedor.Enabled = False
            Me.Tx_NombreProveedor.Enabled = False
            IDBODEGAORDENCOMPRA = filaordencompra("IDBODEGACOMPRA")
            Me.Cb_TipoOrdenCompra.SelectedValue = filaordencompra("CODIGOTIPOORDENCOMPRA")
            Me.Cb_TipoOrdenCompra.Enabled = False
            Me.Tx_DespacharA.Text = Trim(filaordencompra("DESPACHAR_A"))
            Dtp_FechaDespacho.Checked = True
            If Date.Now() < filaordencompra("FECHAENTREGA") Then
                Me.Dtp_FechaDespacho.MinDate = filaordencompra("FECHAENTREGA")
            Else
                Me.Dtp_FechaDespacho.MinDate = Date.Now()
            End If
            If Dtp_FechaDespacho.MaxDate < filaordencompra("FECHAENTREGA") Then
                Me.Dtp_FechaDespacho.Value = filaordencompra("FECHAENTREGA")
            End If
            Me.Tx_CondiciónPago.Text = filaordencompra("CONDICIONPAGO")

            'Necesario para poder cargar los usuarios de la bodega donde se digitó la orden de compra
            TempBodega = VariablesBase.VariablesBase.IdBodegaActual
            VariablesBase.VariablesBase.IdBodegaActual = filaordencompra("IDBODEGACOMPRA")
            Me.Cu_BuscarPersonaAutoriza.CargarDatos(filaordencompra("IDPERSONAAUTORIZA"))
            Me.Cu_BuscarPersonaAprueba.CargarDatos(filaordencompra("IDPERSONAAPRUEBA"))
            Me.Cu_BuscarPersonaGerencia.CargarDatos(filaordencompra("IDPERSONAGERENCIA"))
            Me.Cu_BuscarPersonaRevisa.CargarDatos(filaordencompra("IDPERSONAREVISA"))

            Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = filaordencompra("IDPERSONAAUTORIZA")
            Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = filaordencompra("IDPERSONAAPRUEBA")
            Me.Cu_BuscarPersonaGerencia.Cb_Persona.SelectedValue = filaordencompra("IDPERSONAGERENCIA")
            Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue = filaordencompra("IDPERSONAREVISA")

            Me.Cb_TipoMoneda.SelectedValue = filaordencompra("CODIGOTIPOMONEDA")
            Dim TRMDecimal As Decimal = filaordencompra("TRM")
            Tx_TRM.Text = Format(TRMDecimal, "C")
            Select Case filaordencompra("VALORINCLUYEARANCEL")
                Case "S"
                    Ck_ValorIncluyeArancel.CheckState = CheckState.Checked
                Case "N"
                    Ck_ValorIncluyeArancel.CheckState = CheckState.Unchecked
                Case Else
                    Ck_ValorIncluyeArancel.CheckState = CheckState.Indeterminate
            End Select
            If IsDBNull(filaordencompra("COTIZACION")) = False Then
                Me.Tx_Cotización.Text = Trim(filaordencompra("COTIZACION"))
            End If
            Me.Tx_Observación.Text = Trim(filaordencompra("OBSERVACION"))
            Me.Tx_Encabezado.Text = Trim(filaordencompra("ENCABEZADO"))
            Me.Tx_DirecciónProveedor.Text = Trim(filaordencompra("DIRECCION"))
            Me.Cu_CiudadDirección.Cb_Ciudad.SelectedValue = filaordencompra("CODIGOCIUDADDIRECCION")
            Me.Tx_TelefonoProveedor.Text = Trim(filaordencompra("TELEFONO"))
            Me.Tx_CelularProveedor.Text = Trim(filaordencompra("CELULAR"))
            Me.Tx_FaxProveedor.Text = Trim(filaordencompra("FAX"))
            Me.Tx_NombreProveedor.Text = Trim(filaordencompra("NOMBRE"))
            If Not IsDBNull(filaordencompra("DIRECCIONNOTIFICACION")) Then
                Tx_DireccionNotificacion.Text = Trim(filaordencompra("DIRECCIONNOTIFICACION"))
            Else
                Tx_DireccionNotificacion.Text = ""
            End If
            If Not IsDBNull(filaordencompra("CORREONOTIFICACION")) Then
                Tx_CorreoNotificacion.Text = Trim(filaordencompra("CORREONOTIFICACION"))
            Else
                Tx_CorreoNotificacion.Text = ""
            End If
            If Not IsDBNull(filaordencompra("PERSONACONTACTO")) Then
                Tx_PersonaContacto.Text = Trim(filaordencompra("PERSONACONTACTO"))
            Else
                Tx_PersonaContacto.Text = ""
            End If
            CalcularTotal()
        Else
            Me.Cu_CentroCosto1.Editando = 0
        End If
        Me.Cu_CentroCosto1.CargarCentro()
    End Sub


    Private Sub Caja_Texto_GotFocus(sender As Object, e As EventArgs) _
        Handles Tx_Identificación.GotFocus, Tx_NombreProveedor.GotFocus, Tx_TelefonoProveedor.GotFocus

        Dim Objeto As Object = sender
        Objeto.backcolor = Color.MintCream
    End Sub


    Private Sub TextBox_PrimerNombre_LostFocus(sender As Object, e As EventArgs) _
        Handles Tx_Identificación.LostFocus, Tx_NombreProveedor.LostFocus, Tx_TelefonoProveedor.LostFocus

        Dim Objeto As Object = sender
        Objeto.backcolor = Color.White
        If sender.text = "" Or sender.text = "SIN INFORMACION" Or _
          sender.text = "SE DESCONOCE" Or sender.text = "SIN IDENTIFICAR" Then
            sender.backcolor = Color.Salmon
        End If
        If sender.name = "Tx_Identificación" Then
            Cargar_Proveedor()
        End If
    End Sub


    Private Sub Tx_Identificación_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_Identificación.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Cargar_Proveedor()
            End If
        Catch ex As Exception

        End Try
    End Sub


    ''' <summary></summary>
    Private Sub Marcar_Cajas_Vacias()
        If Tx_Identificación.Text = "" Then
            Tx_Identificación.BackColor = Color.Salmon
        Else
            Tx_Identificación.BackColor = Color.White
        End If
        If Tx_NombreProveedor.Text = "" Then
            Tx_NombreProveedor.BackColor = Color.Salmon
        Else
            Tx_NombreProveedor.BackColor = Color.White
        End If
        If Tx_TelefonoProveedor.Text = "" Then
            Tx_TelefonoProveedor.BackColor = Color.Salmon
        Else
            Tx_TelefonoProveedor.BackColor = Color.White
        End If
    End Sub


    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        Try
            If ValidarOrdenCompra() = True Then
                If ValidarItemsOrdenCompra() = True Then
                    GuardarOrdenCompra()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    ''' <summary></summary>
    ''' <returns></returns>
    Private Function ValidarOrdenCompra() As Boolean
        If Trim(Me.Tx_Identificación.Text) = "" Then
            MsgBox("Debe digitar la identificación del proveedor", MsgBoxStyle.Critical, "IDENTIFICACION")
            Me.Tx_Identificación.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If
        If IsNothing(FilaProveedor) Then
            MsgBox("Debe digitar el proveedor", MsgBoxStyle.Critical, "PROVEEDOR")
            Me.Tx_Identificación.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If
        If Trim(Tx_DireccionNotificacion.Text).Length <= 0 Then
            MsgBox("Debe digitar la dirección de notificación del proveedor", MsgBoxStyle.Critical, "DIRECCIÓN DE NOTIFICACIÓN DEL PROVEEDOR")
            Tx_DireccionNotificacion.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If
        If Trim(Tx_CorreoNotificacion.Text).Length <= 0 Then
            MsgBox("Debe digitar el correo electrónico de notificación del proveedor", MsgBoxStyle.Critical, "CORREO DE NOTIFICACIÓN DEL PROVEEDOR")
            Tx_CorreoNotificacion.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If
        If Trim(Tx_PersonaContacto.Text).Length <= 0 Then
            MsgBox("Debe digitar la persona de contacto del proveedor", MsgBoxStyle.Critical, "PERSONA DE CONTACTO DEL PROVEEDOR")
            Tx_PersonaContacto.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If

        If Me.Cb_TipoOrdenCompra.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de orden de compra", MsgBoxStyle.Critical, "TIPO ORDEN COMPRA")
            Me.Cb_TipoOrdenCompra.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If

        If Trim(Me.Tx_CondiciónPago.Text) = "" Then
            MsgBox("Debe seleccionar la condición de pago", MsgBoxStyle.Critical, "CONDICION DE PAGO")
            Me.Tx_CondiciónPago.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If

        If Me.Cb_TipoMoneda.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de moneda", MsgBoxStyle.Critical, "TIPO DE MONEDA")
            Me.Cb_TipoMoneda.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If

        Me.Tx_ValorDescuento.Text = Trim(Me.Tx_ValorDescuento.Text)
        Select Case Me.Cb_TipoDescuento.SelectedIndex
            Case 0 'No tiene
                If Me.Tx_ValorDescuento.Text <> "" Then
                    MsgBox("Si no tiene descuento el valor se debe dejar vacío", MsgBoxStyle.Critical, "DESCUENTO")
                    Me.Tx_ValorDescuento.Focus()
                    Me.Tx_ValorDescuento.SelectAll()
                    ValidarOrdenCompra = False
                    Exit Function
                End If
            Case 1 'Por valor
                If Me.Tx_ValorDescuento.Text = "" Then
                    MsgBox("Si tiene descuento el valor no puede ser vacío", MsgBoxStyle.Critical, "DESCUENTO")
                    Me.Tx_ValorDescuento.Focus()
                    ValidarOrdenCompra = False
                    Exit Function
                End If
                If IsNumeric(Me.Tx_ValorDescuento.Text) = False Then
                    MsgBox("El valor debe ser numérico", MsgBoxStyle.Critical, "DESCUENTO")
                    Me.Tx_ValorDescuento.Focus()
                    ValidarOrdenCompra = False
                    Exit Function
                End If

            Case 2 'Por porcentaje
                If Me.Tx_ValorDescuento.Text = "" Then
                    MsgBox("Si tiene descuento el valor no puede ser vacío", MsgBoxStyle.Critical, "DESCUENTO")
                    Me.Tx_ValorDescuento.Focus()
                    ValidarOrdenCompra = False
                    Exit Function
                End If
                If IsNumeric(Me.Tx_ValorDescuento.Text) = False Then
                    MsgBox("El valor debe ser numérico", MsgBoxStyle.Critical, "DESCUENTO")
                    Me.Tx_ValorDescuento.Focus()
                    ValidarOrdenCompra = False
                    Exit Function
                End If
                If CInt(Me.Tx_ValorDescuento.Text) > 100 Then
                    MsgBox("El descuento en porcentaje no puede ser mayor al 100%", MsgBoxStyle.Critical, "DESCUENTO")
                    Me.Tx_ValorDescuento.Focus()
                    ValidarOrdenCompra = False
                    Exit Function
                End If
        End Select

        If Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Seleccione la persona que revisa", MsgBoxStyle.Critical, "REVISA")
            Me.Cu_BuscarPersonaRevisa.Cb_Persona.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If

        If Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Seleccione la persona que autoriza", MsgBoxStyle.Critical, "AUTORIZA")
            Me.Cu_BuscarPersonaAutoriza.Cb_Persona.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If

        If Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Seleccione la persona que aprueba", MsgBoxStyle.Critical, "APRUEBA")
            Me.Cu_BuscarPersonaAprueba.Cb_Persona.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If

        If Me.Cu_BuscarPersonaGerencia.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Seleccione la persona que gerencia o director de obra", MsgBoxStyle.Critical, "GERENCIA O DIRECTOR DE OBRA")
            Me.Cu_BuscarPersonaGerencia.Cb_Persona.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If

        If Tx_TRM.Enabled = True Then
            If Tx_TRM.TextLength < 1 Then
                MsgBox("Debe digitar el valor de la Tasa Representativa del Mercado.", MsgBoxStyle.Exclamation, "Valor de TRM erróneo")
                Me.Tx_TRM.Focus()
                ValidarOrdenCompra = False
                Exit Function
            End If

            Dim valorTRM As Decimal = FuncionesBase.FuncionesBase.ValorRealDec(Tx_TRM.Text)
            ultimaTRM = ConsultarValorUltimaTRM(Cb_TipoMoneda.SelectedValue)
            If valorTRM < 0 Then
                MsgBox("El valor de la Tasa Representativa del Mercado debe ser mayor que 0 (cero).", MsgBoxStyle.Exclamation, "Valor de TRM erróneo")
                Me.Tx_TRM.Focus()
                ValidarOrdenCompra = False
                Exit Function
            ElseIf valorTRM < Decimal.Multiply(ultimaTRM, 0.8) OrElse valorTRM > Decimal.Multiply(ultimaTRM, 1.2) Then
                MsgBox("El valor de la Tasa Representativa del Mercado no debe exceder en más del 20% al último valor de TRM registrado ($ " & ultimaTRM & ").", MsgBoxStyle.Exclamation, "Valor de TRM erróneo")
                Me.Tx_TRM.Focus()
                ValidarOrdenCompra = False
                Exit Function
            End If
        End If

        If Ck_ValorIncluyeArancel.Enabled Then
            If Ck_ValorIncluyeArancel.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe indicar si los artículos incluyen o no el valor de Nacionalización.", MsgBoxStyle.Exclamation, "Valores incluyen Nacionalización")
                Me.Ck_ValorIncluyeArancel.Focus()
                ValidarOrdenCompra = False
                Exit Function
            End If
        End If

        If Dtp_FechaDespacho.Checked = False Then
            MsgBox("Seleccione la fecha de entrega.", MsgBoxStyle.Exclamation, "FECHA DE DESPACHO")
            Dtp_FechaDespacho.Focus()
            ValidarOrdenCompra = False
            Exit Function
        End If

        ValidarOrdenCompra = True
    End Function


    ''' <summary></summary>
    ''' <returns></returns>
    Private Function ValidarItemsOrdenCompra() As Boolean
        Dim CANTIDAD As Single
        Dim CANTIDADPENDIENTE As Single
        Dim VALORUNITARIO As Decimal
        Dim TIPODESCUENTO As String
        Dim VALORDESCUENTO As Decimal
        Dim IVA As Decimal

        With Dgv_Item
            For x As Integer = 0 To Dgv_Item.Rows.Count - 1
                'Validar Cantidad
                If CStr(.Rows(x).Cells("CANTIDADDataGridViewTextBoxColumn").Value) <> "" Then
                    If IsNumeric(.Rows(x).Cells("CANTIDADDataGridViewTextBoxColumn").Value) = True Then
                        CANTIDAD = .Rows(x).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                        CANTIDADPENDIENTE = .Rows(x).Cells("CANTIDADPENDIENTEDataGridViewTextBoxColumn").Value
                        If CANTIDAD > CANTIDADPENDIENTE Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "La cantidad es mayor a la cantidad pendiente"
                            MsgBox("La cantidad es mayor a la cantidad pendiente", MsgBoxStyle.OkOnly, "CANTIDAD")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        Else
                            If CANTIDAD <= 0 Then
                                .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(x).ErrorText = "La cantidad debe ser mayor que 0"
                                MsgBox("La cantidad debe ser mayor que 0", MsgBoxStyle.OkOnly, "CANTIDAD")
                                ValidarItemsOrdenCompra = False
                                Try
                                    Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                                Catch ex As Exception
                                End Try
                                Exit Function
                            End If
                        End If
                    Else
                        .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                        .Rows(x).ErrorText = "La cantidad no es valida"
                        MsgBox("La cantidad no es valida", MsgBoxStyle.OkOnly, "CANTIDAD")
                        ValidarItemsOrdenCompra = False
                        Try
                            Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                        Catch ex As Exception
                        End Try
                        Exit Function
                    End If
                Else
                    .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                    .Rows(x).ErrorText = "La cantidad no es valida"
                    MsgBox("La cantidad no es valida", MsgBoxStyle.OkOnly, "CANTIDAD")
                    ValidarItemsOrdenCompra = False
                    Try
                        Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                    Catch ex As Exception
                    End Try
                    Exit Function
                End If
                'validar valor unitario
                If IsNumeric(.Rows(x).Cells("VALORUNITARIODataGridViewTextBoxColumn").Value) = True Then
                    If .Rows(x).Cells("VALORUNITARIODataGridViewTextBoxColumn").Value <= 0 Then
                        .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                        .Rows(x).ErrorText = "El valor unitario no es valido"
                        MsgBox("El valor unitario no es valido", MsgBoxStyle.OkOnly, "VALOR UNITARIO")
                        ValidarItemsOrdenCompra = False
                        Exit Function
                    Else
                        VALORUNITARIO = .Rows(x).Cells("VALORUNITARIODataGridViewTextBoxColumn").Value
                    End If
                Else
                    .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                    .Rows(x).ErrorText = "El valor unitario no es valido"
                    MsgBox("El valor unitario no es valido", MsgBoxStyle.OkOnly, "VALOR UNITARIO")
                    ValidarItemsOrdenCompra = False
                    'Calculando = False
                    Exit Function
                End If

                TIPODESCUENTO = (.Rows(x).Cells("TIPODESCUENTODataGridViewTextBoxColumn").Value).ToString
                IVA = .Rows(x).Cells("PORCENTAJEIVADataGridViewTextBoxColumn").Value

                Select Case TIPODESCUENTO
                    Case "No tiene"
                        If IsDBNull(.Rows(x).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value) = False Then
                            VALORDESCUENTO = .Rows(x).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value
                        Else
                            VALORDESCUENTO = 0
                        End If
                        If CStr(VALORDESCUENTO) <> 0 Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento debe ser vacío"
                            MsgBox("El descuento debe ser vacío", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        VALORDESCUENTO = 0
                    Case "Valor Total"
                        If IsDBNull(.Rows(x).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value) = True Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser vacío"
                            MsgBox("El descuento no puede ser vacío", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        VALORDESCUENTO = .Rows(x).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value
                        If CStr(VALORDESCUENTO) = "" Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser vacío"
                            MsgBox("El descuento no puede ser vacío", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        If IsNumeric(VALORDESCUENTO) = False Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento debe ser numérico"
                            MsgBox("El descuento debe ser numérico", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        If VALORDESCUENTO <= 0 Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser menor o igual 0"
                            MsgBox("El descuento no puede ser menor o igual 0", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        If VALORDESCUENTO > CANTIDAD * VALORUNITARIO * (1 + (IVA / 100)) Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser mayor al valor de los artículos"
                            MsgBox("El descuento no puede ser mayor al valor de los artículos", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                    Case "Porcentaje"
                        If IsDBNull(.Rows(x).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value) = True Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser vacío"
                            MsgBox("El descuento no puede ser vacío", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Calculando = False
                            Exit Function
                        End If
                        VALORDESCUENTO = .Rows(x).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value
                        If CStr(VALORDESCUENTO) = "" Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser vacío"
                            MsgBox("El descuento no puede ser vacío", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        If IsNumeric(VALORDESCUENTO) = False Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento debe ser numérico"
                            MsgBox("El descuento debe ser numérico", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        If VALORDESCUENTO <= 0 Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser menor o igual 0"
                            MsgBox("El descuento no puede ser menor o igual 0", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        If VALORDESCUENTO > 100 Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser mayor a 100%"
                            MsgBox("El descuento no puede ser mayor a 100%", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Calculando = False
                            Exit Function
                        End If
                        VALORDESCUENTO = CANTIDAD * VALORUNITARIO * (VALORDESCUENTO / 100)
                    Case "Por Unidad"
                        If IsDBNull(.Rows(x).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value) = True Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser vacío"
                            MsgBox("El descuento no puede ser vacío", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        VALORDESCUENTO = .Rows(x).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value
                        If CStr(VALORDESCUENTO) = "" Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser vacío"
                            MsgBox("El descuento no puede ser vacío", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        If IsNumeric(VALORDESCUENTO) = False Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento debe ser numérico"
                            MsgBox("El descuento debe ser numérico", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        If VALORDESCUENTO <= 0 Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser menor o igual 0"
                            MsgBox("El descuento no puede ser menor o igual 0", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        If VALORDESCUENTO > VALORUNITARIO Then
                            .Rows(x).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(x).ErrorText = "El descuento no puede ser mayor al valor unitario"
                            MsgBox("El descuento no puede ser mayor al valor unitario", MsgBoxStyle.OkOnly, "DESCUENTO")
                            ValidarItemsOrdenCompra = False
                            Try
                                Me.Dgv_Item.CurrentCell = Me.Dgv_Item(0, x)
                            Catch ex As Exception
                            End Try
                            Exit Function
                        End If
                        VALORDESCUENTO = CANTIDAD * VALORDESCUENTO
                End Select

                Dim VALORITEMTOTAL As Decimal
                VALORITEMTOTAL = (CANTIDAD * VALORUNITARIO) * (1 + (IVA / 100)) - VALORDESCUENTO

                .Rows(x).Cells("VALORTOTALITEMDataGridViewTextBoxColumn").Value = VALORITEMTOTAL
                CalcularTotal()
            Next
        End With
        ValidarItemsOrdenCompra = True
    End Function


    ''' <summary></summary>
    Private Sub GuardarOrdenCompra()
        Try
            'DsOrdenCompra.ListaOrdenCompra.AcceptChanges()
            dsCargar.Tables(1).AcceptChanges()
        Catch ex As Exception

        End Try

        Dim fila As DataRow

        'Crear tabla @TableITEMCOMPRA
        Dim TableITEMCOMPRA As New DataTable
        TableITEMCOMPRA.Columns.Add("IDITEMORDENCOMPRA", Type.GetType("System.Byte"))
        TableITEMCOMPRA.Columns.Add("IDORDENCOMPRA", Type.GetType("System.Int64"))
        TableITEMCOMPRA.Columns.Add("IDARTICULO", Type.GetType("System.Int32"))
        TableITEMCOMPRA.Columns.Add("IDREQUISICION", Type.GetType("System.Int64"))
        TableITEMCOMPRA.Columns.Add("IDITEMREQUISICION", Type.GetType("System.Byte"))
        TableITEMCOMPRA.Columns.Add("CANTIDAD", Type.GetType("System.Double"))
        TableITEMCOMPRA.Columns.Add("VALORUNITARIO", Type.GetType("System.Decimal"))
        TableITEMCOMPRA.Columns.Add("PORCENTAJEIVA", Type.GetType("System.Decimal"))
        TableITEMCOMPRA.Columns.Add("APLICADESCUENTO", Type.GetType("System.String"))
        TableITEMCOMPRA.Columns.Add("VALORDESCUENTO", Type.GetType("System.Decimal"))

        For i = 0 To dsCargar.Tables(1).Rows.Count - 1
            Dim filaitemordencompra As DataRow
            filaitemordencompra = dsCargar.Tables(1).Rows(i)
            fila = TableITEMCOMPRA.NewRow
            fila("IDITEMORDENCOMPRA") = filaitemordencompra("IDITEMORDENCOMPRA")
            fila("IDORDENCOMPRA") = filaitemordencompra("IDORDENCOMPRA")
            fila("IDARTICULO") = filaitemordencompra("IDARTICULO")
            fila("IDREQUISICION") = filaitemordencompra("IDREQUISICION")
            fila("IDITEMREQUISICION") = filaitemordencompra("IDITEMREQUISICION")
            fila("CANTIDAD") = CDbl(filaitemordencompra("CANTIDAD"))
            fila("VALORUNITARIO") = CDec(filaitemordencompra("VALORUNITARIO"))
            fila("PORCENTAJEIVA") = CDec(filaitemordencompra("PORCENTAJEIVA"))

            Select Case filaitemordencompra("TIPODESCUENTO")
                Case "No tiene"
                    fila("APLICADESCUENTO") = "N"
                    fila("VALORDESCUENTO") = 0
                Case "Valor Total"
                    fila("APLICADESCUENTO") = "T"
                    fila("VALORDESCUENTO") = CDec(filaitemordencompra("VALORDESCUENTO"))
                Case "Porcentaje"
                    fila("APLICADESCUENTO") = "P"
                    fila("VALORDESCUENTO") = CDec(filaitemordencompra("VALORDESCUENTO"))
                Case "Por Unidad"
                    fila("APLICADESCUENTO") = "U"
                    fila("VALORDESCUENTO") = CDec(filaitemordencompra("VALORDESCUENTO"))
            End Select
            TableITEMCOMPRA.Rows.Add(fila)
        Next

        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarOrdenCompra")
        Comando.CommandType = CommandType.StoredProcedure
        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
        End If
        Comando.Parameters.AddWithValue("@TableITEMORDENCOMPRA", TableITEMCOMPRA)
        Comando.Parameters.AddWithValue("@IDORDENCOMPRA", IDORDENCOMPRAMODIFICANDO)
        Comando.Parameters.AddWithValue("@IDBODEGACOMPRA", IDBODEGAORDENCOMPRA)
        Comando.Parameters.AddWithValue("@IDREQUISICION", IDREQUISICION)
        Comando.Parameters.AddWithValue("@CODIGOTIPOORDENCOMPRA", Me.Cb_TipoOrdenCompra.SelectedValue)
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@IDPROVEEDOR", FilaProveedor("IDPROVEEDOR"))
        Comando.Parameters.AddWithValue("@IDPERSONACOMPRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@DESPACHAR_A", Trim(Tx_DespacharA.Text))
        Comando.Parameters.AddWithValue("@IDCENTROCOSTO", Me.Cu_CentroCosto1.IdCentroCosto)
        Comando.Parameters.AddWithValue("@FECHAENTREGA", Me.Dtp_FechaDespacho.Value)
        Comando.Parameters.AddWithValue("@CONDICIONPAGO", Me.Tx_CondiciónPago.Text)
        Comando.Parameters.AddWithValue("@ESTADO", "P")
        Comando.Parameters.AddWithValue("@IDPERSONAAUTORIZA", Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHAAUTORIZADA", DBNull.Value)
        Comando.Parameters.AddWithValue("@AUTORIZADA", DBNull.Value)
        Comando.Parameters.AddWithValue("@IDPERSONAAPRUEBA", Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHAAPRUEBA", DBNull.Value)
        Comando.Parameters.AddWithValue("@APROBADA", DBNull.Value)
        Comando.Parameters.AddWithValue("@REQUIEREAPROBACIONGERENCIA", DBNull.Value)
        Comando.Parameters.AddWithValue("@IDPERSONAGERENCIA", Me.Cu_BuscarPersonaGerencia.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHAAPRUEBAGERENCIA", DBNull.Value)
        Comando.Parameters.AddWithValue("@APROBADAGERENCIA", DBNull.Value)
        Comando.Parameters.AddWithValue("@IDPERSONAREVISA", Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHAPERSONAREVISA", DBNull.Value)
        Comando.Parameters.AddWithValue("@REVISADO", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOMONEDA", Me.Cb_TipoMoneda.SelectedValue)
        If Tx_TRM.Enabled = True Then
            Comando.Parameters.AddWithValue("@TRM", FuncionesBase.FuncionesBase.ValorRealDec(Me.Tx_TRM.Text))
        Else
            Comando.Parameters.AddWithValue("@TRM", 1)
        End If
        If Ck_ValorIncluyeArancel.Enabled = True Then
            If Ck_ValorIncluyeArancel.CheckState = CheckState.Checked Then
                Comando.Parameters.AddWithValue("@VALORINCLUYEARANCEL", "S")
            Else
                Comando.Parameters.AddWithValue("@VALORINCLUYEARANCEL", "N")
            End If
        Else
            Comando.Parameters.AddWithValue("@VALORINCLUYEARANCEL", "S")
        End If
        Comando.Parameters.AddWithValue("@IMPRESA", "N")
        If Tx_Cotización.Text = "" Then
            Comando.Parameters.AddWithValue("@COTIZACION", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@COTIZACION", Me.Tx_Cotización.Text)
        End If
        Dim Obser As String = Trim(Tx_Observación.Text)
        If Obser <> "" Then
            Obser = Replace(Obser, vbTab, " ")
            Obser = Replace(Obser, vbCrLf, " ")
            Obser = Replace(Obser, vbCr, " ")
            Obser = Replace(Obser, vbLf, " ")
        End If
        Comando.Parameters.AddWithValue("@OBSERVACION", Obser)
        Dim Encab As String = Trim(Tx_Encabezado.Text)
        If Not IsNothing(Encab) Then
            If Encab <> "" Then
                Dim EncabSB As New StringBuilder
                Dim lineas As String() = Split(Encab, Environment.NewLine)
                For i = 0 To lineas.Count - 1
                    lineas(i) = Trim(Regex.Replace(lineas(i), "[\s][\s]+", " ")) ' Caracteres blancos seguidos dentro del texto
                    lineas(i) = Trim(Regex.Replace(lineas(i), "\s$", "")) ' Último carácter blanco antes del salto de línea
                    lineas(i) = Trim(Regex.Replace(lineas(i), "[ ][ ]+", " ")) ' Espacios seguidos resultado de los reemplazos anteriores
                    If lineas(i) <> "" Then
                        EncabSB.Append(lineas(i))
                        If i < lineas.Count - 1 Then
                            EncabSB.Append(Environment.NewLine)
                        End If
                    End If
                Next
                Comando.Parameters.AddWithValue("@ENCABEZADO", EncabSB.ToString)
            Else
                Comando.Parameters.AddWithValue("@ENCABEZADO", "")
            End If
        Else
            Comando.Parameters.AddWithValue("@ENCABEZADO", "")
        End If
        Comando.Parameters.AddWithValue("@DIRECCION", Me.Tx_DirecciónProveedor.Text)
        Comando.Parameters.AddWithValue("@CODIGOCIUDADDIRECCION", Me.Cu_CiudadDirección.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@TELEFONO", Me.Tx_TelefonoProveedor.Text)
        Comando.Parameters.AddWithValue("@CELULAR", Me.Tx_CelularProveedor.Text)
        Comando.Parameters.AddWithValue("@FAX", Me.Tx_FaxProveedor.Text)
        Comando.Parameters.AddWithValue("@NOMBRE", Me.Tx_NombreProveedor.Text)
        Comando.Parameters.AddWithValue("@DIRECCIONNOTIFICACION", Trim(Tx_DireccionNotificacion.Text))
        Comando.Parameters.AddWithValue("@CORREONOTIFICACION", Trim(Tx_CorreoNotificacion.Text))
        Comando.Parameters.AddWithValue("@PERSONACONTACTO", Trim(Tx_PersonaContacto.Text))
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim TipoOrdenParam As New SqlParameter("@ABREVIATURA", SqlDbType.NChar, 1)
        TipoOrdenParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(TipoOrdenParam)
        Dim ConsecutivoParam As New SqlParameter("@CONSECUTIVO_MOSTRAR", SqlDbType.NChar, 4)
        ConsecutivoParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(ConsecutivoParam)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Comando.Connection = conn
        Try
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()

            Dim Consecutivo As String
            Dim NoConsecutivo As String = 0
            Dim Mes As String = 0
            Select Case ConsecutivoParam.Value.ToString.Length
                Case 1
                    NoConsecutivo = "000" + CStr(ConsecutivoParam.Value)
                Case 2
                    NoConsecutivo = "00" + CStr(ConsecutivoParam.Value)
                Case 3
                    NoConsecutivo = "0" + CStr(ConsecutivoParam.Value)
                Case 4
                    NoConsecutivo = CStr(ConsecutivoParam.Value)
            End Select

            Select Case CStr(Now.Month).Length
                Case 1
                    Mes = "0" + CStr(Now.Month)
                Case 2
                    Mes = CStr(Now.Month)
            End Select

            Consecutivo = VariablesBase.VariablesBase.AbreviaturaBodegaActual & "-" & Now.Year & CStr(Comando.Parameters("@ABREVIATURA").Value) & Mes & NoConsecutivo
            Select Case Comando.Parameters("@IDMENSAJE").Value
                Case 0
                    MsgBox("No se pudo realizar la operación", MsgBoxStyle.Exclamation, "No se completo la operación")
                    guardado = False
                    Imprimir = False
                    Exit Sub
                Case Is > 0
                    MsgBox("Se guardo la orden de compra correctamente " & Consecutivo, MsgBoxStyle.Information, "Nueva Orden de Compra")
                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "OC", "AUTORIZA", Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue)
                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "OC", "REVISA", Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue)
                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "OC", "APRUEBA", Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue)
                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "OC", "GERENCIA", Cu_BuscarPersonaGerencia.Cb_Persona.SelectedValue)

                    If MsgBox("¿Desea imprimir la orden de compra" & Consecutivo, MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                        Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                        Dim Array As New ArrayList
                        Array.Add(62)
                        climpresiones.IDORDENDECOMPRA = Comando.Parameters("@IDMENSAJE").Value
                        climpresiones.copiaparacontabilidad1 = True
                        climpresiones.copiaparacontabilidad2 = False
                        climpresiones.copiaparaconsecutivo = False
                        climpresiones.copiaparafolderpedido = False
                        climpresiones.FormatoImprimirMateriales(Array, True, False)
                    End If
                    guardado = True
                    Me.Close()
                Case -2
                    MsgBox("Se guardaron los cambios de la orden de compra correctamente", MsgBoxStyle.Information, "Modificar Orden de Compra")
                    guardado = True
                    Me.Close()
            End Select
        Catch ex As Exception
            MsgBox("No se pudo realizar la operación", MsgBoxStyle.Exclamation, "No se completo la operación")
            guardado = False
            Imprimir = False
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub


    Private Sub Tx_Identificación_TextChanged(sender As Object, e As EventArgs) Handles Tx_Identificación.TextChanged
        LimpiarProveedor()
    End Sub


    ''' <summary></summary>
    Private Sub Cargar_Proveedor()
        comando = New SqlCommand("SELECT * FROM DatosProveedorOC(@IDENTIFICACION)", conexion)
        comando.Parameters.AddWithValue("@IDENTIFICACION", Trim(Tx_Identificación.Text))
        adaptador = New SqlDataAdapter(comando)
        Dim dtProveedor As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtProveedor)
            conexion.Close()
            If dtProveedor.Rows.Count > 0 Then
                FilaProveedor = dtProveedor.Rows(0)

                Tx_DigVerificación.Text = Trim(FilaProveedor("DIGITOVERIFICACION"))
                If Trim(FilaProveedor("NOMBRE")) <> "" Then
                    Tx_NombreProveedor.Text = Trim(FilaProveedor("NOMBRE"))
                Else
                    Tx_NombreProveedor.Text = Trim(FilaProveedor("NOMBREPROVEEDOR"))
                End If
                Tx_DirecciónProveedor.Text = Trim(FilaProveedor("DIRECCION"))
                Cu_CiudadDirección.Cb_Ciudad.SelectedValue = FilaProveedor("CODIGOCIUDADDIRECCION")
                Tx_TelefonoProveedor.Text = Trim(FilaProveedor("TELEFONO"))
                Tx_CelularProveedor.Text = Trim(FilaProveedor("CELULAR"))
                Tx_FaxProveedor.Text = Trim(FilaProveedor("FAX"))
                Tx_DireccionNotificacion.Text = ""
                Tx_CorreoNotificacion.Text = FilaProveedor("EMAILREPRESENTANTEVENTA")
                Tx_PersonaContacto.Text = FilaProveedor("NOMBREREPRESENTANTEVENTA")
                Cb_TipoOrdenCompra.Focus()
            Else
                Me.Tx_Identificación.Focus()
            End If
            Marcar_Cajas_Vacias()
        Catch ex As Exception
            MessageBox.Show("No fue posible cargar los datos del proveedor", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary></summary>
    Private Sub LimpiarProveedor()
        FilaProveedor = Nothing
        Tx_DigVerificación.Text = ""
        Tx_NombreProveedor.Text = ""
        Tx_DirecciónProveedor.Text = ""
        Cu_CiudadDirección.Cb_Ciudad.SelectedIndex = -1
        Tx_TelefonoProveedor.Text = ""
        Tx_CelularProveedor.Text = ""
        Tx_FaxProveedor.Text = ""
        Tx_DireccionNotificacion.Text = ""
        Tx_CorreoNotificacion.Text = ""
        Tx_PersonaContacto.Text = ""
    End Sub


    Private Sub Dgv_Item_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Item.CellValueChanged
        Try
            If Calculando = False Then
                Calculando = True
                Estilo_Celda_Error.BackColor = Color.Red
                Dim CANTIDAD As Single
                Dim CANTIDADPENDIENTE As Single
                Dim VALORUNITARIO As Decimal
                Dim TIPODESCUENTO As String
                Dim VALORDESCUENTO As Decimal
                Dim IVA As Decimal
                Dim Estilo_Celda As New DataGridViewCellStyle
                Estilo_Celda.BackColor = Color.White

                With Dgv_Item
                    .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda
                    .Rows(e.RowIndex).ErrorText = ""
                    'Validar Cantidad
                    If CStr(.Rows(e.RowIndex).Cells("CANTIDADDataGridViewTextBoxColumn").Value) <> "" Then
                        If IsNumeric(.Rows(e.RowIndex).Cells("CANTIDADDataGridViewTextBoxColumn").Value) = True Then
                            CANTIDAD = .Rows(e.RowIndex).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                            CANTIDADPENDIENTE = .Rows(e.RowIndex).Cells("CANTIDADPENDIENTEDataGridViewTextBoxColumn").Value
                            If CANTIDAD > CANTIDADPENDIENTE Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "La cantidad es mayor a la cantidad pendiente"
                                Calculando = False
                                Exit Sub
                            Else
                                If CANTIDAD <= 0 Then
                                    .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                    .Rows(e.RowIndex).ErrorText = "La cantidad debe ser mayor que 0"
                                    Calculando = False
                                    Exit Sub
                                End If
                            End If
                        Else
                            .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(e.RowIndex).ErrorText = "La cantidad no es valida"
                            Calculando = False
                            Exit Sub
                        End If
                    Else
                        .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                        .Rows(e.RowIndex).ErrorText = "La cantidad no es valida"
                        Calculando = False
                        Exit Sub
                    End If
                    'validar valor unitario
                    If CStr(.Rows(e.RowIndex).Cells("VALORUNITARIODataGridViewTextBoxColumn").Value) <> "" Then
                        If IsNumeric(.Rows(e.RowIndex).Cells("VALORUNITARIODataGridViewTextBoxColumn").Value) = True Then
                            If .Rows(e.RowIndex).Cells("VALORUNITARIODataGridViewTextBoxColumn").Value <= 0 Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El valor unitario no es valido"
                                Calculando = False
                                Exit Sub
                            Else
                                VALORUNITARIO = .Rows(e.RowIndex).Cells("VALORUNITARIODataGridViewTextBoxColumn").Value
                            End If
                        Else
                            .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(e.RowIndex).ErrorText = "El valor unitario no es valido"
                            Calculando = False
                            Exit Sub
                        End If
                    Else
                        .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                        .Rows(e.RowIndex).ErrorText = "El valor unitario no es valido"
                        Calculando = False
                        Exit Sub
                    End If

                    TIPODESCUENTO = (.Rows(e.RowIndex).Cells("TIPODESCUENTODataGridViewTextBoxColumn").Value).ToString
                    IVA = .Rows(e.RowIndex).Cells("PORCENTAJEIVADataGridViewTextBoxColumn").Value

                    Select Case TIPODESCUENTO
                        Case "No tiene"

                            If IsDBNull(.Rows(e.RowIndex).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value) = False Then
                                VALORDESCUENTO = .Rows(e.RowIndex).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value
                            Else
                                VALORDESCUENTO = 0
                            End If
                            If CStr(VALORDESCUENTO) <> 0 Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento debe ser vacío"
                                Calculando = False
                                Exit Sub
                            End If
                            VALORDESCUENTO = 0
                        Case "Valor Total"
                            If IsDBNull(.Rows(e.RowIndex).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value) = True Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser vacío"
                                Calculando = False
                                Exit Sub
                            End If
                            VALORDESCUENTO = .Rows(e.RowIndex).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value
                            If CStr(VALORDESCUENTO) = "" Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser vacío"
                                Calculando = False
                                Exit Sub
                            End If
                            If IsNumeric(VALORDESCUENTO) = False Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento debe ser numérico"
                                Calculando = False
                                Exit Sub
                            End If
                            If VALORDESCUENTO <= 0 Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser menor o igual 0"
                                Calculando = False
                                Exit Sub
                            End If
                            If VALORDESCUENTO > CANTIDAD * VALORUNITARIO * (1 + (IVA / 100)) Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser mayor al valor de los artículos"
                                Calculando = False
                                Exit Sub
                            End If
                        Case "Porcentaje"
                            If IsDBNull(.Rows(e.RowIndex).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value) = True Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser vacío"
                                Calculando = False
                                Exit Sub
                            End If
                            VALORDESCUENTO = .Rows(e.RowIndex).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value
                            If CStr(VALORDESCUENTO) = "" Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser vacío"
                                Calculando = False
                                Exit Sub
                            End If
                            If IsNumeric(VALORDESCUENTO) = False Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento debe ser numérico"
                                Calculando = False
                                Exit Sub
                            End If
                            If VALORDESCUENTO <= 0 Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser menor o igual 0"
                                Calculando = False
                                Exit Sub
                            End If
                            If VALORDESCUENTO > 100 Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser mayor a 100%"
                                Calculando = False
                                Exit Sub
                            End If
                            VALORDESCUENTO = CANTIDAD * VALORUNITARIO * (VALORDESCUENTO / 100)
                        Case "Por Unidad"
                            If IsDBNull(.Rows(e.RowIndex).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value) = True Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser vacío"
                                Calculando = False
                                Exit Sub
                            End If
                            VALORDESCUENTO = .Rows(e.RowIndex).Cells("VALORDESCUENTODataGridViewTextBoxColumn").Value
                            If CStr(VALORDESCUENTO) = "" Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser vacío"
                                Calculando = False
                                Exit Sub
                            End If
                            If IsNumeric(VALORDESCUENTO) = False Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento debe ser numérico"
                                Calculando = False
                                Exit Sub
                            End If
                            If VALORDESCUENTO <= 0 Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser menor o igual 0"
                                Calculando = False
                                Exit Sub
                            End If
                            If VALORDESCUENTO > VALORUNITARIO Then
                                .Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(e.RowIndex).ErrorText = "El descuento no puede ser mayor al valor unitario"
                                Calculando = False
                                Exit Sub
                            End If
                            VALORDESCUENTO = CANTIDAD * VALORDESCUENTO
                    End Select

                    Dim VALORITEMTOTAL As Decimal
                    VALORITEMTOTAL = ((CANTIDAD * VALORUNITARIO) - VALORDESCUENTO) * (1 + (IVA / 100))

                    .Rows(e.RowIndex).Cells("VALORTOTALITEMDataGridViewTextBoxColumn").Value = VALORITEMTOTAL
                    CalcularTotal()
                End With
                Calculando = False
            End If
        Catch ex As Exception
            Calculando = False
        End Try
    End Sub


    ''' <summary></summary>
    Private Sub CalcularTotal()
        Try
            Dim sumObject As Object
            sumObject = Me.dsCargar.Tables(1).Compute("Sum(VALORTOTALITEM)", "")
            Me.Lb_TotalOC.Visible = True
            Dim SIMBOLOMoneda As String
            Dim filas As DataRow()
            filas = Me.dsCargar.Tables(3).Select("CODIGOTIPOMONEDA=" + Cb_TipoMoneda.SelectedValue.ToString)
            Dim Fila As DataRow
            Fila = filas(0)
            SIMBOLOMoneda = Fila("SIMBOLO")
            Me.Lb_TotalOC.Text = "VALOR TOTAL ORDEN COMPRA:  " + SIMBOLOMoneda + " " + FormatNumber((sumObject).ToString, , , TriState.True, TriState.True).ToString
        Catch ex As Exception
            Me.Lb_TotalOC.Visible = False
        End Try
    End Sub


    ''' <summary></summary>
    ''' <param name="IDPERSONA"></param>
    ''' <param name="NOMBRECOMPONENTE"></param>
    Public Sub cargarpersonalasociadobodega(Optional IDPERSONA As Integer = -1, Optional NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaAutoriza.CargarDatos()
            Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaAutoriza.CargarCajaTexto()
        Catch ex As Exception

        End Try
        Try
            temp = Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaRevisa.CargarDatos()
            Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaRevisa.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaAprueba.CargarDatos()
            Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaAprueba.CargarCajaTexto()
        Catch ex As Exception

        End Try
        Try
            temp = Me.Cu_BuscarPersonaGerencia.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaGerencia.CargarDatos()
            Me.Cu_BuscarPersonaGerencia.Cb_Persona.SelectedValue = temp
        Catch ex As Exception
        End Try

        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarPersonaAutoriza.Name
                Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaRevisa.Name
                Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaAprueba.Name
                Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaGerencia.Name
                Me.Cu_BuscarPersonaGerencia.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub


    ''' <summary></summary>
    ''' <param name="NombreComponente"></param>
    Public Sub EventoCajaEnter(Optional NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Me.Cu_BuscarPersonaAutoriza.Name
                Try
                    filas = Cu_BuscarPersonaAutoriza.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAutoriza.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaAutoriza.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaRevisa.Name
                Try
                    filas = Cu_BuscarPersonaRevisa.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaRevisa.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaRevisa.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaAprueba.Name
                Try
                    filas = Cu_BuscarPersonaAprueba.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAprueba.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaAprueba.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaGerencia.Name
                Try
                    filas = Cu_BuscarPersonaGerencia.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaGerencia.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaGerencia.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaGerencia.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub


    Private Sub Cb_TipoMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoMoneda.SelectedIndexChanged
        CalcularTotal()
        If RTrim(Cb_TipoMoneda.Text) = "PESOS" Then
            Label12.Enabled = False
            Tx_TRM.Enabled = False
            Tx_TRM.Text = "1"
            Ck_ValorIncluyeArancel.Enabled = False
            Ck_ValorIncluyeArancel.ThreeState = True
            Ck_ValorIncluyeArancel.CheckState = CheckState.Indeterminate
        Else
            Label12.Enabled = True
            Tx_TRM.Enabled = True
            Ck_ValorIncluyeArancel.Enabled = True
            Try
                ultimaTRM = ConsultarValorUltimaTRM(Cb_TipoMoneda.SelectedValue)
                ToolTipOrdenCompra.SetToolTip(Tx_TRM, "Valor última TRM: " & ultimaTRM.ToString("C2"))
            Catch ex As Exception

            End Try
        End If
        Dim codigoMoneda As String = ""
    End Sub


    'Private Sub Dgv_Item_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles Dgv_Item.UserDeletingRow
    'MsgBox("¿Está seguro de eliminar el ítem de la Orden de Compra?", MsgBoxStyle.OkCancel, "Borrar Item Orden de Compra")
    'If MsgBoxResult.Cancel = False Then
    'e.Cancel = True
    ''Else
    ''Me.Dgv_Item.Rows.RemoveAt(e.Row.Index)
    'End If
    'End Sub


    Private Sub Dgv_Item_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Item.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                Try
                    If Me.Dgv_Item.SelectedRows Is Nothing Then Exit Sub

                    Dim selectedRowCount As Integer = Dgv_Item.Rows.GetRowCount(DataGridViewElementStates.Selected)
                    For I As Integer = 0 To selectedRowCount - 1
                        Me.Dgv_Item.Rows.Remove(Dgv_Item.SelectedRows(0))
                    Next
                Catch ex As Exception

                End Try
                Try
                    dsCargar.Tables(1).AcceptChanges()
                Catch ex As Exception
                End Try
                If Me.Dgv_Item.Rows.Count > 0 Then
                    For x As Integer = Dgv_Item.CurrentCell.RowIndex To dsCargar.Tables(1).Rows.Count - 1
                        If IsDBNull(dsCargar.Tables(1).Rows(x).Item("IDITEMORDENCOMPRA")) = False Then
                            dsCargar.Tables(1).Rows(x).Item("IDITEMORDENCOMPRA") = x + 1
                        End If
                    Next
                End If
            Case Keys.F6
                Dim FrHistoricoPrecio As New Fr_HistoricoPrecio
                Try
                    FrHistoricoPrecio.CargarTablas(1, _
                VariablesBase.VariablesBase.IdBodegaActual, Dgv_Item.SelectedRows(0).Cells(2).Value, -1)
                Catch ex As Exception
                End Try
                FrHistoricoPrecio.ShowDialog()
            Case Windows.Forms.Keys.Enter
                Me.Dgv_Item.CurrentCell = Me.Dgv_Item.Item(Me.Dgv_Item.Columns(7).Index, Me.Dgv_Item.CurrentCell.RowIndex)
        End Select
    End Sub


    Private Sub Dgv_Item_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Dgv_Item.DataError
        If e.Exception IsNot Nothing AndAlso _
        e.Context = DataGridViewDataErrorContexts.Commit Then
            MessageBox.Show("Favor comunicarse con el personal de sistemas")
        End If
    End Sub


    Private Sub Fr_OrdenCompra_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If cargado = False Then
            Me.Tx_Identificación.Focus()
            cargado = True
        End If
    End Sub


    Private Sub Fr_OrdenCompra_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If guardado = False And Me.Bt_Guardar.Enabled = True Then
            If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR SIN GUARDAR") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                If Editando = True Then
                    VariablesBase.VariablesBase.IdBodegaActual = TempBodega
                End If
            End If
        Else
            If Editando = True Then
                VariablesBase.VariablesBase.IdBodegaActual = TempBodega
            End If
        End If
    End Sub


    Private Sub Bt_Aplicar_Click(sender As Object, e As EventArgs) Handles Bt_Aplicar.Click
        If MsgBox("¿Desea aplicar el descuento sobre los item's de la orden de compra?", vbYesNo, "Aplicar Descuento") = MsgBoxResult.Yes Then
            If MsgBox("Se borraran los descuentos actuales y se aplicara la regla del descuento general, ¿Desea continuar?", MsgBoxStyle.YesNo, "Borrar y Aplicar Descuento") = MsgBoxResult.Yes Then
                Select Case Me.Cb_TipoDescuento.Text
                    Case "No tiene"
                        For i = 0 To Me.dsCargar.Tables(1).Rows.Count - 1
                            Dim fila As DataRow
                            fila = Me.dsCargar.Tables(1).Rows(i)
                            fila("TIPODESCUENTO") = Me.Cb_TipoDescuento.Text
                            fila("VALORDESCUENTO") = 0
                            fila("VALORTOTALITEM") = (fila("CANTIDAD") * fila("VALORUNITARIO")) * (1 + fila("PORCENTAJEIVA") / 100)
                        Next
                    Case "Porcentaje"
                        If Trim(Me.Tx_ValorDescuento.Text) = "" Then
                            MsgBox("Valor del descuento no es valido")
                            Exit Sub
                        End If
                        If IsNumeric(Me.Tx_ValorDescuento.Text) = False Then
                            MsgBox("Valor del descuento no es valido")
                            Exit Sub
                        End If
                        If CDec(Me.Tx_ValorDescuento.Text) > 100 Then
                            MsgBox("Valor del descuento no es valido")
                            Exit Sub
                        End If
                        For i = 0 To Me.dsCargar.Tables(1).Rows.Count - 1
                            Dim fila As DataRow
                            fila = Me.dsCargar.Tables(1).Rows(i)
                            fila("TIPODESCUENTO") = Me.Cb_TipoDescuento.Text
                            fila("VALORDESCUENTO") = CDec(Me.Tx_ValorDescuento.Text)
                            fila("VALORTOTALITEM") = ((fila("CANTIDAD") * fila("VALORUNITARIO")) - ((fila("VALORDESCUENTO") / 100) * fila("CANTIDAD") * fila("VALORUNITARIO"))) * (1 + fila("PORCENTAJEIVA") / 100)
                        Next
                    Case "Valor Total"
                        If Trim(Me.Tx_ValorDescuento.Text) = "" Then
                            MsgBox("Valor del descuento no es valido")
                            Exit Sub
                        End If
                        If IsNumeric(Me.Tx_ValorDescuento.Text) = False Then
                            MsgBox("Valor del descuento no es valido")
                            Exit Sub
                        End If
                        Dim valortotalsindescuento As Double = 0
                        For i = 0 To Me.dsCargar.Tables(1).Rows.Count - 1
                            Dim fila As DataRow
                            fila = Me.dsCargar.Tables(1).Rows(i)
                            valortotalsindescuento = valortotalsindescuento + (fila("CANTIDAD") * fila("VALORUNITARIO"))
                        Next
                        If CDec(Me.Tx_ValorDescuento.Text) > valortotalsindescuento Then
                            MsgBox("Valor del descuento no es valido")
                            Exit Sub
                        End If

                        For i = 0 To Me.dsCargar.Tables(1).Rows.Count - 1
                            Dim fila As DataRow
                            Dim ValorDescuento As Double
                            fila = Me.dsCargar.Tables(1).Rows(i)
                            fila("TIPODESCUENTO") = Me.Cb_TipoDescuento.Text

                            If i = Me.dsCargar.Tables(1).Rows.Count - 1 Then
                                fila("VALORDESCUENTO") = 0
                                Dim sumdescuentos As Object
                                sumdescuentos = Me.dsCargar.Tables(1).Compute("Sum(VALORDESCUENTO)", "")
                                ValorDescuento = CDec(Me.Tx_ValorDescuento.Text) - sumdescuentos
                            Else
                                ValorDescuento = fila("CANTIDAD") * fila("VALORUNITARIO")
                                ValorDescuento = ValorDescuento * 100
                                ValorDescuento = ValorDescuento / valortotalsindescuento
                                ValorDescuento = CInt((ValorDescuento / 100) * CDec(Me.Tx_ValorDescuento.Text))
                            End If

                            fila("VALORDESCUENTO") = ValorDescuento
                            fila("VALORTOTALITEM") = ((fila("CANTIDAD") * fila("VALORUNITARIO")) - (fila("VALORDESCUENTO"))) * (1 + fila("PORCENTAJEIVA") / 100)
                        Next
                End Select
                CalcularTotal()
            End If
        End If
    End Sub


    Private Sub Bt_BuscarProveedor_Click(sender As Object, e As EventArgs) Handles Bt_BuscarProveedor.Click
        Dim FrBuscarProveedor As New Fr_BuscarProveedor
        FrBuscarProveedor.Cargar_Tabla()
        FrBuscarProveedor.ShowDialog()
        Try
            Me.Tx_Identificación.Text = FrBuscarProveedor.Identificacion
            Cargar_Proveedor()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Tx_Identificación_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_Identificación.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F3 Then
            Dim FrBuscarProveedor As New Fr_BuscarProveedor
            FrBuscarProveedor.Cargar_Tabla()
            FrBuscarProveedor.ShowDialog()
            Try
                Me.Tx_Identificación.Text = FrBuscarProveedor.Identificacion
                Cargar_Proveedor()
            Catch ex As Exception
            End Try
        End If
    End Sub


    Private Sub Ll_ActualizarContacto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Ll_ActualizarContacto.LinkClicked
        If MsgBox("Desea ver o actualizar los contactos asociados al documento", MsgBoxStyle.YesNo, "Ver o Actualizar Contactos") = MsgBoxResult.Yes Then
            If Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedIndex <> -1 And
                Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedIndex <> -1 And
                Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedIndex <> -1 And
                Me.Cu_BuscarPersonaGerencia.Cb_Persona.SelectedIndex <> -1 Then
                Dim FrActualizarContacto As New FormulariosClasesBase.Fr_ActualizarContacto
                FrActualizarContacto.Bt_Aceptar.Enabled = Me.Bt_Guardar.Enabled
                FrActualizarContacto.Cu_Contacto1.IDPERSONA = Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto1.Gb_Contacto.Text = "Solicita: " + Me.Cu_BuscarPersonaRevisa.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto2.IDPERSONA = Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto2.Gb_Contacto.Text = "Autoriza: " + Me.Cu_BuscarPersonaAutoriza.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto3.IDPERSONA = Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto3.Gb_Contacto.Text = "Revisa: " + Me.Cu_BuscarPersonaAprueba.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto4.IDPERSONA = Me.Cu_BuscarPersonaGerencia.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto4.Gb_Contacto.Text = "Aprueba: " + Me.Cu_BuscarPersonaGerencia.Cb_Persona.Text
                FrActualizarContacto.CargarDatos()
                FrActualizarContacto.ShowDialog()
            Else
                MsgBox("Debe seleccionar todas las persona que interactúan con el documento", MsgBoxStyle.Information, "Seleccionar todas las personas")
            End If
        End If
    End Sub


    Private Sub Ck_ValorIncluyeArancel_CheckStateChanged(sender As Object, e As EventArgs) Handles Ck_ValorIncluyeArancel.CheckStateChanged
        If Ck_ValorIncluyeArancel.CheckState <> CheckState.Indeterminate Then
            Ck_ValorIncluyeArancel.ThreeState = False
        End If
    End Sub

    Private Sub Bt_PersonalizarCondicionPago_Click(sender As Object, e As EventArgs) Handles Bt_PersonalizarCondicionPago.Click
        Using frCondicionPago As New Fr_CondicionPago
            frCondicionPago.ShowDialog()
            If frCondicionPago.DialogResult = Windows.Forms.DialogResult.OK Then
                Tx_CondiciónPago.Text = frCondicionPago.GetCondicionPago()
            End If
        End Using
    End Sub


    ''' <summary>
    ''' Devuelve el último valor de TRM registrado en órdenes de compra para el tipo de moneda indicado.
    ''' </summary>
    ''' <param name="tipoMoneda">Código de la moneda de la cual se consulta la TRM</param>
    ''' <returns>Valor de la última TRM registrada para el tipo de moneda indicado</returns>
    Private Function ConsultarValorUltimaTRM(tipoMoneda As Integer) As Decimal
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT dbo.ValorUltimaTRM(@TIPOMONEDA)", conexion)
        comando.Parameters.AddWithValue("@TIPOMONEDA", tipoMoneda)
        Try
            conexion.Open()
            ultimaTRM = comando.ExecuteScalar()
            conexion.Close()
            Return ultimaTRM
        Catch ex As Exception
            'MessageBox.Show("No se pudo obtener el último valor de TRM registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New Exception("No se pudo obtener el último valor de TRM registrado.", ex)
        Finally
            conexion.Close()
        End Try
    End Function

End Class