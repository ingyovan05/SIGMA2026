Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class Fr_SalidaAlmacen
    Public validacionequipos As Boolean = True
    Public tablaequipos As New DataTable
    Public tablaequiposfin As New DataTable
    Public Copiatablaequiposfin As New DataTable
    Public tablacomponentes As New DataTable
    Public tablacomponentesfin As New DataTable
    Public Copiatablacomponentesfin As New DataTable
    Public nuevosequipos As Boolean = True
    Public edicionequipos As Boolean = False
    Public Editando As Boolean = False
    Public IDSALIDAALMACEN As Integer
    Public IDSALIDAALMACENMODIFICANDO As Integer = -1
    Public EditarEquipos As String = "NUEVO" 'NUEVO, VER, EDITAR"
    Dim MensajeError As String
    Dim dtSalidaAlmacen As New DataTable
    Dim dtItemSalidaAlmacen As New DataTable
    Dim dtBodegasListado As New DataTable
    Dim dtItemOrdenCompra As New DataTable
    Dim dtItemSobre As New DataTable
    Dim Estilo_Celda_Error As New DataGridViewCellStyle
    Dim Estilo_Celda As New DataGridViewCellStyle
    Dim familia As Integer = -1
    Dim articulos As New DataTable("ListarArticulos")
    'Dim ARTICULOTableAdapter As New DatosSalidaAlmacén.Ds_SalidaAlmacénTableAdapters.ARTICULOTableAdapter
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()
    Dim TempBodega As Integer
    Dim guardado As Boolean = False
    Dim ValorAnteriorEdiciónIDArticulo As Integer
    Private bddatos1 As New FuncionesBase.ClaseCargarMaestras
    Dim Index_Registro_Actual As Integer


    Public Sub New()
        InitializeComponent()
        AddHandler Cb_Relación.KeyDown, AddressOf FuncionesBase.FuncionesBase.ComboBoxAutocompletar_KeyDown
    End Sub

    Dim dsCargar As New DataSet
    Public Sub CargarDatos()

        Dim identificador As Long
        Dim tipo As Integer

        If IDSALIDAALMACENMODIFICANDO <= 0 Then
            identificador = IDSALIDAALMACEN
            tipo = 1 'Crear
        Else
            identificador = IDSALIDAALMACENMODIFICANDO
            tipo = 2 'Editar
        End If

        dsCargar = bddatos1.CargarMaestrasMateriales(3, VariablesBase.VariablesBase.IdBodegaActual, identificador, tipo)
        Me.Cu_CentroCosto1.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoBodegaActual
        Dtp_FechaDespacho.MaxDate = Date.Now.AddDays(7)

        'Verificar si es bodega CMC o principal Ismocol
        Me.Cu_AsociarOT.Identificador = -1
        Me.Cu_AsociarOT.Ll_Asociar.Text = "SIN ASOCIAR OT"

        Me.Cb_TipoSalida.DataSource = Me.dsCargar.Tables(2)
        Me.Cb_TipoSalida.DisplayMember = "NOMBRE"
        Me.Cb_TipoSalida.ValueMember = "CODIGO"

        CargarComboTipo()

        If Editando = False Then
            Me.Cu_BuscarPersonaDespacha.CargarDatos()
            Me.Cu_BuscarPersonaAutoriza.CargarDatos()
            Me.Cu_BuscarPersonaRecibe.CargarDatos()

            Cu_BuscarPersonaDespacha.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "SA", "DESPACHA", -1)
            Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "SA", "AUTORIZA", -1)
            Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "SA", "RECIBE", -1)
        Else
            Cu_CentroCosto1.Editando = 1
        End If

        CargarActividades()
        Me.Cb_Actividad.SelectedIndex = 0

        'Dim dtTipoEnvio As New DataTable
        'dtTipoEnvio.Columns.Add("CODIGO")
        'dtTipoEnvio.Columns.Add("NOMBRE")
        'dtTipoEnvio.Rows.Add("E", "Exportación")
        'dtTipoEnvio.Rows.Add("I", "Importación")
        'dtTipoEnvio.Rows.Add("N", "No Aplica")
        Me.Cb_TipoEnvio.DataSource = Me.dsCargar.Tables(3)
        Me.Cb_TipoEnvio.ValueMember = "CODIGO"
        Me.Cb_TipoEnvio.DisplayMember = "NOMBRE"
        Cb_TipoEnvio.SelectedValue = "N"
        Cu_AsociarActivoFijo1.Tipo = "X"
        Comportamiento_Predeterminado()

        dtItemSalidaAlmacen = dsCargar.Tables(1)

        'Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        'Dim comando As New SqlCommand("SELECT * FROM dbo.SA_ItemSalidaAlmacen(@IDSALIDAALMACEN) ORDER BY [Item]", conexion)
        'comando.Parameters.AddWithValue("@IDSALIDAALMACEN", IDSALIDAALMACENMODIFICANDO)
        'Dim adaptador As New SqlDataAdapter(comando)
        'Try
        '    conexion.Open()
        '    adaptador.FillSchema(dtItemSalidaAlmacen, SchemaType.Source)
        '    adaptador.Fill(dtItemSalidaAlmacen)
        '    conexion.Close()
        Me.Dgv_item.DataSource = dtItemSalidaAlmacen
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    conexion.Close()
        'End Try

        If Editando = True Then
            Cb_TipoSalida.Enabled = False
            Cb_TipoEnvio.Enabled = False
            Cb_Relación.Enabled = False
            'dtSalidaAlmacen = dsCargar.Tables(0)
            CargarSalidaAlmacen()
        End If

        'establecer las columnas de las tablas de equipos y artículos
        tablaequipos.Columns.Add("IDEQUIPO")
        tablaequipos.Columns.Add("IDARTICULO")
        tablaequipos.Columns.Add("CODIGO")
        tablaequipos.Columns.Add("NOMBREEQUIPO")

        tablacomponentes.Columns.Add("IDEQUIPO")
        tablacomponentes.Columns.Add("IDARTICULO")
        tablacomponentes.Columns.Add("CODIGO")
        tablacomponentes.Columns.Add("NOMBREEQUIPO")
        tablacomponentes.Columns.Add("IDEQUIPOPADRE")
        tablacomponentes.Columns.Add("CODIGOPADRE")

        Cbx_VerificacionEquipos.Enabled = False
        If EditarEquipos = "VER" Or EditarEquipos = "EDITAR" Then
            Select Case Cb_TipoSalida.SelectedValue
                Case "T" 'para traslados
                    If EditarEquipos = "VER" Then
                        Dgv_item.ReadOnly = True
                    End If
                    '----------REHABILITAR--------------
                    Bt_SeleccionarEquipos.Enabled = True
                    '----------REHABILITAR--------------
                    Cbx_VerificacionEquipos.Enabled = False
                    ' debo revisar si esta orden de salida posee items y de ser así se deben llenar una tabla con los equipos y una con los componentes
                    Dim dscargarequipos As New DataSet
                    'para traslados reviso los equipos que pertenecen a una orden de salida en la tabla CAF_ENTRADASSALIDAS
                    dscargarequipos = bddatos.ModificarEntradasSalidas(8, 0, 0, 0, Date.Now, 0, Date.Now, "", IDSALIDAALMACENMODIFICANDO, 0)
                    'si existen items lleno las tablas, si no deshabilito el botón de ver los equipos porque no hay nada
                    If dscargarequipos.Tables(0).Rows.Count > 0 Then
                        '+++ EDICIÓN PARA QUE NO SE PUEDAN MODIFICAR LAS SALIDAS DE ALMACÉN QUE YA TIENEN EQUIPOS REGISTRADOS. QUITAR EN UN FUTURO SI SE CAMBIA DE OPINIÓN
                        If EditarEquipos = "EDITAR" Then
                            Dgv_item.ReadOnly = True
                            MsgBox("No se pueden editar Salidas de Almacén que tengan equipos ya ingresados")
                            EditarEquipos = "VER"
                            Bt_GuardarSalida.Enabled = False
                        End If
                        '+++
                        validacionequipos = True
                        tablaequiposfin = dscargarequipos.Tables(0)
                        If dscargarequipos.Tables(1).Rows.Count > 0 Then
                            tablacomponentesfin = dscargarequipos.Tables(1)
                        End If
                    Else
                        Bt_SeleccionarEquipos.Enabled = False
                        Cbx_VerificacionEquipos.Checked = False
                    End If
                Case "S"
                    Dgv_item.ReadOnly = True

                    Bt_SeleccionarEquipos.Enabled = True
                    Cbx_VerificacionEquipos.Enabled = False
                    Cbx_VerificacionEquipos.Checked = True

                    ' debo revisar si esta orden de salida posee items y llenar una tabla con los equipos y una con los componentes
                    Dim dscargarequipos As New DataSet
                    'PARA CUSTORIAS REVISO LOS EQUIPOS QUE PERTENECEN A UNA SALIDA EN LA TABLA CAF_CUSTODIAS
                    dscargarequipos = bddatos.ModificarCustodias(2, 0, 0, 0, 0, IDSALIDAALMACENMODIFICANDO, 0)
                    ' lleno las tablas
                    If dscargarequipos.Tables(0).Rows.Count > 0 Then
                        '+++ EDICIÓN PARA QUE NO SE PUEDAN MODIFICAR LAS SALIDAS DE ALMACÉN QUE YA TIENEN EQUIPOS REGISTRADOS. QUITAR EN UN FUTURO SI SE CAMBIA DE OPINIÓN
                        If EditarEquipos = "EDITAR" Then
                            Dgv_item.ReadOnly = True
                            MsgBox("No se pueden editar Salidas de Almacén que tengan equipos ya ingresados")
                            EditarEquipos = "VER"
                            Bt_GuardarSalida.Enabled = False
                        End If
                        '+++
                        validacionequipos = True
                        tablaequiposfin = dscargarequipos.Tables(0)
                        If dscargarequipos.Tables(1).Rows.Count > 0 Then
                            tablacomponentesfin = dscargarequipos.Tables(1)
                        End If
                    Else
                        Cbx_VerificacionEquipos.Checked = False
                    End If
                Case Else
                    Bt_SeleccionarEquipos.Enabled = False
            End Select
        End If
        Me.Cu_CentroCosto1.CargarCentro()
        Select Case Me.Cb_TipoSalida.SelectedValue
            Case "C", "R"
                Me.Cu_AsociarActivoFijo1.Visible = True
            Case Else
                Me.Cu_AsociarActivoFijo1.Visible = False
        End Select
        Select Case Me.Cb_TipoSalida.SelectedValue
            Case "C", "T"
                Cb_TipoEnvio.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Cb_TipoEnvio.Tag)
                Lb_TipoEnvio.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Cb_TipoEnvio.Tag)
            Case Else
                Cb_TipoEnvio.Visible = False
                Lb_TipoEnvio.Visible = False
        End Select
    End Sub


    Public Sub Comportamiento_Predeterminado()
        Me.Dgv_item.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_item.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        'Definir el estilo de encabezado del DataGrid para que salga en dos renglones
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_item.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Dgv_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Cu_APB_Despacha.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_APB_Despacha.Tag)
        Cu_APB_Autoriza.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_APB_Autoriza.Tag)
        Cu_APB_Recibe.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_APB_Recibe.Tag)

        Cb_TipoEnvio.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Cb_TipoEnvio.Tag)
        Lb_TipoEnvio.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Cb_TipoEnvio.Tag)
    End Sub


    Public Sub CargarSalidaAlmacen()
        'Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        'Dim comando As New SqlCommand("SELECT * FROM dbo.SA_SalidaAlmacen(@IDSALIDAALMACEN)", conexion)
        'comando.Parameters.AddWithValue("@IDSALIDAALMACEN", IDSALIDAALMACENMODIFICANDO)
        'Dim adaptador As New SqlDataAdapter(comando)

        Try
            'conexion.Open()
            'adaptador.Fill(dtSalidaAlmacen)
            'conexion.Close()
            Dim fila As DataRow
            fila = dsCargar.Tables(0).Rows(0)
            Me.Cb_TipoSalida.SelectedValue = fila("TIPOSALIDAALMACEN")
            If Not IsDBNull(fila("TIPOENVIO")) Then
                If Trim(fila("TIPOENVIO")) <> "" Then
                    Me.Cb_TipoEnvio.SelectedValue = fila("TIPOENVIO")
                Else
                    Cb_TipoEnvio.SelectedValue = "N"
                End If
            Else
                Cb_TipoEnvio.SelectedValue = "N"
            End If
            If IsDBNull(fila("FECHADESPACHO")) = False Then
                Me.Dtp_FechaDespacho.Value = fila("FECHADESPACHO")
                Me.Dtp_FechaDespacho.Checked = True
            End If
            Me.Tx_Destino.Text = Trim(fila("DESTINO"))
            Me.Tx_Transportador.Text = Trim(fila("TRANSPORTADOR"))
            Me.Tx_RecibeTransportador.Text = Trim(fila("RECIBETRANSPORTADOR"))
            Me.Tb_Observaciones.Text = Trim(fila("OBSERVACION"))
            If Not IsDBNull(fila("IDORDENTRABAJO")) AndAlso fila("IDORDENTRABAJO") > 0 Then
                Cu_AsociarOT.Identificador = fila("IDORDENTRABAJO")
                Cu_AsociarOT.Cargar()
            End If
            '******************************************
            'Necesario para poder cargar los usuarios de la bodega donde se digitó la orden de compra
            TempBodega = VariablesBase.VariablesBase.IdBodegaActual
            VariablesBase.VariablesBase.IdBodegaActual = fila("IDBODEGA")
            Me.Cu_BuscarPersonaDespacha.CargarDatos(fila("IDPERSONADESPACHA"))
            Me.Cu_BuscarPersonaAutoriza.CargarDatos(fila("IDPERSONAAUTORIZA"))
            Me.Cu_BuscarPersonaRecibe.CargarDatos(fila("IDPERSONARECIBE"))

            Cu_BuscarPersonaDespacha.Cb_Persona.SelectedValue = fila("IDPERSONADESPACHA")
            Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = fila("IDPERSONAAUTORIZA")
            Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue = fila("IDPERSONARECIBE")

            Me.Cb_Actividad.SelectedValue = fila("IDACTIVIDADPRINCIPAL")

            If IsDBNull(fila("IDCENTROCOSTO")) = False Then
                Me.Cu_CentroCosto1.IdCentroCosto = fila("IDCENTROCOSTO")
                Me.Cu_CentroCosto1.Editando = 1
                Me.Cu_CentroCosto1.CargarCentro()
            Else
                Me.Cu_CentroCosto1.Visible = False
            End If

            Me.Cu_AsociarActivoFijo1.Visible = False

            Select Case fila("TIPOSALIDAALMACEN")
                Case "T"
                    Me.Cb_Relación.SelectedValue = fila("IDBODEGADESTINO")
                Case "R", "C"
                    Me.Cu_AsociarActivoFijo1.Visible = True
                    Try
                        Me.Cu_AsociarActivoFijo1.IdEquipo = fila("IDEQUIPO")
                        Me.Cu_AsociarActivoFijo1.Ll_ActivoFijo.Text = fila("CODIGO")
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
            End Select
            If IsDBNull(fila("registroodometrohorometro")) = False Then
                Me.Cu_AsociarActivoFijo1.LL_odometro.Text = fila("registroodometrohorometro")
            End If

            Me.Tx_PlacaVehiculo.Text = fila("PLACAVEHICULO")

            Me.Tx_Guía.Text = fila("GUIA")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'conexion.Close()
        End Try

        Cb_TipoSalida.Enabled = False
        Cb_Relación.Enabled = False
        Cb_AsociarRq.Enabled = False
        Bt_AsociarRq.Enabled = False
        Cb_OrdenCompra.Enabled = False
        Bt_AgregarOC.Enabled = False
        Cb_TipoEnvio.Enabled = False
        Bt_GestionarActividades.Enabled = False
    End Sub


    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1,
                                            Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BuscarPersonaDespacha.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaDespacha.CargarDatos()
            Me.Cu_BuscarPersonaDespacha.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaDespacha.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaAutoriza.CargarDatos()
            Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaAutoriza.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaRecibe.CargarDatos()
            Me.Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaRecibe.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarPersonaDespacha.Name
                Me.Cu_BuscarPersonaDespacha.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaAutoriza.Name
                Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaRecibe.Name
                Me.Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub


    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Me.Cu_BuscarPersonaDespacha.Name
                Try
                    filas = Cu_BuscarPersonaDespacha.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaDespacha.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaDespacha.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaDespacha.Tx_TextoCódigo.Text = ""
                End Try
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
            Case Me.Cu_BuscarPersonaRecibe.Name
                Try
                    filas = Cu_BuscarPersonaRecibe.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaRecibe.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaRecibe.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub

    Private Sub CargarComboTipo()
        If Cb_TipoSalida.ValueMember <> "" Then
            'limpio las tablas y las variables de validación de equipos
            validacionequipos = True
            LimpiarTablas()
            Bt_SeleccionarEquipos.Enabled = False
            Cbx_VerificacionEquipos.Enabled = False
            Cbx_VerificacionEquipos.Checked = False
            '--
            Me.Cb_Relación.Visible = False
            Me.Lb_Relación.Visible = False
            Me.Bt_Agregar.Visible = False
            Me.Cb_Actividad.Enabled = False
            Me.Bt_AgregarActividad.Enabled = False
            Me.Cb_AsociarRq.Enabled = False
            Me.Bt_AsociarRq.Enabled = False
            Me.Cb_OrdenCompra.Enabled = False
            Me.Bt_AgregarOC.Enabled = False
            Me.Cu_AsociarActivoFijo1.Visible = False
            Select Case Cb_TipoSalida.SelectedValue
                Case "I" ', "Ajuste de inventario"
                    Me.Cb_Relación.DataSource = Nothing
                    Me.Dgv_item.AllowUserToAddRows = True
                    Me.Dgv_item.Columns(1).ReadOnly = False
                    Cbx_VerificacionEquipos.Checked = False
                    Me.Text = "Salida Almacén   -->   A J U S T E   D E   I N V E N T A R I O "
                Case "R" ', "Requisición"
                    Me.Cb_Relación.Visible = True
                    Me.Lb_Relación.Visible = True
                    Me.Bt_Agregar.Visible = True
                    Me.Lb_Relación.Text = "Requisición:"

                    Dim dt_RqPendientes As New DataTable
                    dt_RqPendientes = CargarRequisicionesPendientesXAtender(1, -1)
                    If dt_RqPendientes.Rows.Count > 0 Then
                        Me.Cb_Relación.DataSource = dt_RqPendientes
                        Me.Cb_Relación.DisplayMember = "REQUISICION"
                        Me.Cb_Relación.ValueMember = "IDREQUISICION"
                    Else
                        Me.Cb_Relación.DataSource = Nothing
                    End If

                    Me.Dgv_item.AllowUserToAddRows = False
                    Me.Dgv_item.Columns(1).ReadOnly = True
                    Me.Cb_Actividad.Enabled = True
                    Me.Bt_AgregarActividad.Enabled = True
                    Me.Cu_AsociarActivoFijo1.Visible = True
                    Cbx_VerificacionEquipos.Checked = False
                    Me.Text = "Salida Almacén   -->    A T E N D E R   R E Q U I S I C I Ó N"
                Case "A" ', "Devolución Alquiler"
                    Me.Cb_Relación.DataSource = Nothing
                    Me.Dgv_item.AllowUserToAddRows = True
                    Me.Dgv_item.Columns(1).ReadOnly = False
                    Cbx_VerificacionEquipos.Checked = False
                    Me.Text = "Salida Almacén   -->  D E V O L U C I Ó N   A L Q U I L E R"
                Case "C" ', "Consumo"
                    Me.Dgv_item.AllowUserToAddRows = True
                    Me.Dgv_item.Columns(1).ReadOnly = False
                    Me.Cb_Actividad.Enabled = True
                    Me.Bt_AgregarActividad.Enabled = True
                    Me.Cu_AsociarActivoFijo1.Visible = True
                    Cu_AsociarActivoFijo1.Tipo = Cb_TipoSalida.SelectedValue
                    Cbx_VerificacionEquipos.Checked = False
                    Me.Text = "Salida Almacén   -->  C O N S U M O"
                Case "H" ', "Custodia Herramienta"
                    Me.Dgv_item.AllowUserToAddRows = True
                    Me.Dgv_item.Columns(1).ReadOnly = False
                    Me.Cb_Actividad.Enabled = True
                    Me.Bt_AgregarActividad.Enabled = True
                    Cbx_VerificacionEquipos.Checked = False
                    Me.Text = "Salida Almacén   -->  C U S T O D I A  H E R R A M I E N T A"
                Case "D" ' Dotación
                    Me.Dgv_item.AllowUserToAddRows = True
                    Me.Dgv_item.Columns(1).ReadOnly = False
                    Me.Cb_Actividad.Enabled = True
                    Me.Bt_AgregarActividad.Enabled = True
                    Cbx_VerificacionEquipos.Checked = False
                    Me.Text = "Salida Almacén   -->  D O T A C I Ó N"
                Case "T" ', "Traslado de Bodega"
                    Me.Dgv_item.AllowUserToAddRows = True
                    Me.Dgv_item.Columns(1).ReadOnly = False
                    Me.Cb_Relación.Visible = True
                    Me.Lb_Relación.Visible = True
                    Me.Lb_Relación.Text = "Bodega Destino:"

                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT * FROM dbo.SA_BodegasListado(@IDBODEGA) ORDER BY [NOMBRE]", conexion)
                    comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Try
                        conexion.Open()
                        adaptador.Fill(dtBodegasListado)
                        conexion.Close()
                        Cb_Relación.DataSource = dtBodegasListado
                        Cb_Relación.DisplayMember = "NOMBRE"
                        Cb_Relación.ValueMember = "IDBODEGA"
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conexion.Close()
                    End Try

                    Me.Cb_AsociarRq.Enabled = True
                    Me.Bt_AsociarRq.Enabled = True
                    Me.Cb_OrdenCompra.Enabled = True
                    Me.Bt_AgregarOC.Enabled = True

                    Dim dt_RqPendientes As New DataTable
                    dt_RqPendientes = CargarRequisicionesPendientesXTraslado(1, -1, Cb_Relación.SelectedValue)
                    If dt_RqPendientes.Rows.Count > 0 Then
                        Me.Cb_AsociarRq.DataSource = dt_RqPendientes
                        Me.Cb_AsociarRq.DisplayMember = "REQUISICION"
                        Me.Cb_AsociarRq.ValueMember = "IDREQUISICION"
                    Else
                        Me.Cb_AsociarRq.DataSource = Nothing
                    End If

                    CargarOrdenesPendienteEnvio(1) '1 para solicitar los pendientes solo dos columnas

                    'para agregar equipos de activos fijos
                    '----------REHABILITAR--------------
                    Me.Bt_SeleccionarEquipos.Enabled = True
                    '----------REHABILITAR--------------
                    Me.Cbx_VerificacionEquipos.Enabled = True
                    If EditarEquipos = "VER" Then
                        Me.Cbx_VerificacionEquipos.Enabled = False
                    End If
                    validacionequipos = False
                    Cbx_VerificacionEquipos.Checked = True
                    Me.Text = "Salida Almacén   -->  T R A S L A D O   D E   B O D E G A"
                Case "S" 'Custodia de Equipo
                    Me.Cb_Actividad.Enabled = True
                    Me.Bt_AgregarActividad.Enabled = True
                    Me.Dgv_item.AllowUserToAddRows = True
                    Me.Dgv_item.Columns(1).ReadOnly = False
                    'para agregar equipos de activos fijos
                    '----------REHABILITAR--------------
                    Me.Bt_SeleccionarEquipos.Enabled = True
                    '----------REHABILITAR--------------
                    validacionequipos = False
                    Cbx_VerificacionEquipos.Enabled = False
                    Cbx_VerificacionEquipos.Checked = True
                    Me.Text = "Salida Almacén   -->  C U S T O D I A   D E   E Q U I P O"
            End Select
            Select Case Me.Cb_TipoSalida.SelectedValue
                Case "C", "T"
                    Cb_TipoEnvio.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Cb_TipoEnvio.Tag)
                    Lb_TipoEnvio.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Cb_TipoEnvio.Tag)
                Case Else
                    Cb_TipoEnvio.Visible = False
                    Lb_TipoEnvio.Visible = False
            End Select

        End If
    End Sub


    Private Sub Cb_TipoSalida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_TipoSalida.SelectedIndexChanged
        CargarComboTipo()
    End Sub


    Private Sub CargarOrdenesPendienteEnvio(ByVal Tipo As Integer)
        Dim datas As New DataSet
        Dim cmde As New SqlClient.SqlCommand
        Dim da As New SqlClient.SqlDataAdapter

        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        'declaro la cadena de conexión
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        cmde.Parameters.Clear()
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Connection = sqlconeccion
        cmde.CommandText = "dbo.SA_OrdenesCompraPendienteEnvio"
        cmde.Parameters.AddWithValue("@IDBODEGAORIGEN", VariablesBase.VariablesBase.IdBodegaActual)
        cmde.Parameters.AddWithValue("@IDBODEGADESTINO", Me.Cb_Relación.SelectedValue)
        cmde.Parameters.AddWithValue("@TIPO", Tipo)
        cmde.Parameters.AddWithValue("@IDORDENCOMPRA", -1)
        da = New SqlClient.SqlDataAdapter(cmde)
        datas = New DataSet()
        Try
            sqlconeccion.Open()
            da.Fill(datas)
            sqlconeccion.Close()

            If datas.Tables(0).Rows.Count > 0 Then
                Me.Cb_OrdenCompra.DataSource = datas.Tables(0)
                Me.Cb_OrdenCompra.DisplayMember = "ORDENCOMPRA"
                Me.Cb_OrdenCompra.ValueMember = "IDORDENCOMPRA"
            Else
                Me.Cb_OrdenCompra.DataSource = Nothing
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()
        End Try
    End Sub


    Private Function CargarRequisicionesPendientesXAtender(ByVal Tipo As Integer, ByVal IdRequisicion As Integer) As DataTable
        Dim dt As New DataTable
        Dim cmde As New SqlClient.SqlCommand
        Dim da As New SqlClient.SqlDataAdapter

        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        'declaro la cadena de conexión
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        cmde.Parameters.Clear()
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Connection = sqlconeccion
        cmde.CommandText = "dbo.SA_RQ_PendientexAtender"
        cmde.Parameters.AddWithValue("@TIPO", Tipo)
        cmde.Parameters.AddWithValue("@IDBODEGAACTUAL", VariablesBase.VariablesBase.IdBodegaActual)
        cmde.Parameters.AddWithValue("@IDREQUISICION", IdRequisicion)
        da = New SqlClient.SqlDataAdapter(cmde)
        Try
            sqlconeccion.Open()
            da.Fill(dt)
            sqlconeccion.Close()
            Return dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()
        End Try
    End Function


    Private Function CargarRequisicionesPendientesXTraslado(ByVal Tipo As Integer, ByVal IdRequisicion As Integer, ByVal IdBodega As Integer) As DataTable
        Dim dt As New DataTable
        Dim cmde As New SqlClient.SqlCommand
        Dim da As New SqlClient.SqlDataAdapter

        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        'declaro la cadena de conexión
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        cmde.Parameters.Clear()
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Connection = sqlconeccion

        cmde.CommandText = "dbo.SA_RQ_PendientexTraslado"
        cmde.Parameters.AddWithValue("@TIPO", Tipo)
        cmde.Parameters.AddWithValue("@IDBODEGAORIGEN", VariablesBase.VariablesBase.IdBodegaActual)
        cmde.Parameters.AddWithValue("@IDBODEGADESTINO", IdBodega)
        cmde.Parameters.AddWithValue("@IDREQUISICION", IdRequisicion)

        da = New SqlClient.SqlDataAdapter(cmde)
        Try
            sqlconeccion.Open()
            da.Fill(dt)
            sqlconeccion.Close()
            Return dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()
        End Try
    End Function


    Private Sub Bt_Agregar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Agregar.Click
        AgregarItem()
    End Sub


    Private Sub AgregarItem()
        Select Case Me.Cb_TipoSalida.SelectedValue
            Case "I" ' Ajuste de inventario
            Case "R" ' Requisición
                Dim dt_ItemsRqPendientes As New DataTable
                dt_ItemsRqPendientes = CargarRequisicionesPendientesXAtender(2, Cb_Relación.SelectedValue)

                For i = 0 To dt_ItemsRqPendientes.Rows.Count - 1
                    Dim FilaItemRQ As DataRow
                    FilaItemRQ = dt_ItemsRqPendientes.Rows(i)
                    Dim FilaNueva As DataRow
                    FilaNueva = dtItemSalidaAlmacen.NewRow()
                    FilaNueva("Item") = dtItemSalidaAlmacen.Rows.Count + 1
                    FilaNueva("Código") = FilaItemRQ("Código")
                    FilaNueva("Descripción") = FilaItemRQ("Descripción")
                    FilaNueva("Requisición") = Trim(FilaItemRQ("Requisición"))
                    FilaNueva("Item RQ") = FilaItemRQ("Item RQ")
                    FilaNueva("Und") = FilaItemRQ("Und")
                    FilaNueva("Cant") = Replace(FilaItemRQ("Cant"), ".", ",")
                    FilaNueva("Existencia") = Replace(FilaItemRQ("EXISTENCIA"), ".", ",")
                    FilaNueva("IDREQUISICION") = FilaItemRQ("IDREQUISICION")
                    FilaNueva("ValidarCant") = Replace(FilaItemRQ("ValidarCant"), ".", ",")
                    FilaNueva("IDSALIDAALMACEN") = -1
                    dtItemSalidaAlmacen.Rows.Add(FilaNueva)
                    Me.Cb_TipoSalida.Enabled = False
                Next

                Me.Cu_CentroCosto1.IdCentroCosto = dt_ItemsRqPendientes.Rows(0).Item("IDCENTROCOSTO")
                Me.Cu_CentroCosto1.CargarCentro()

            Case "A" ' Devolución Alquiler
                Me.Cb_Relación.DataSource = Nothing
            Case "C" ' Consumo
            Case "D" ' Dotación
            Case "T" ' Traslado de Bodega
            Case "H" ' Custodia Herramienta
        End Select

        Me.Cb_AsociarRq.Enabled = False
        Me.Bt_AsociarRq.Enabled = False
        Me.Cb_OrdenCompra.Enabled = False
        Me.Bt_AgregarOC.Enabled = False
        Me.Cb_TipoSalida.Enabled = False
        Me.Cb_Relación.Enabled = False
        Me.Bt_Agregar.Enabled = False
        Me.Tx_lectora.Enabled = False

    End Sub


    Private Sub Bt_GuardarSalida_Click(sender As System.Object, e As System.EventArgs) Handles Bt_GuardarSalida.Click
        If ValidarSalidaAlmacen() = True Then
            'verificar que este check el cuadro de verificar equipos
            If Cbx_VerificacionEquipos.Checked = True Then
                'verificar que los equipos sean correctos
                If validacionequipos = False Then
                    MsgBox("No ha seleccionado o faltan equipos por seleccionar, verifique bien que las cantidades coincidan en el botón 'SELECCIONAR / VER EQUIPOS'", MsgBoxStyle.Critical, "EQUIPOS")
                    Bt_SeleccionarEquipos.Focus()
                    Exit Sub
                End If
            End If

            If Cbx_VerificacionEquipos.Checked = True Then
                If tablaequiposfin.Rows.Count > 0 Then
                    If MsgBox("Esta salida tiene Equipos asociados, ¿esta seguro que desea guardarla?. Las salidas y entradas con equipos asociados NO SE PODRÁN EDITAR O CANCELAR en el futuro.", MsgBoxStyle.YesNo, "CONFIRMACION DE SALIDA") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
            GuardarSalidaAlmacen()
        End If
    End Sub

    Private Function ValidarSalidaAlmacen(Optional Tipo As Integer = 0) As Boolean
        If Me.Tx_Destino.Text = "" Then
            MsgBox("Debe digitar el destino", MsgBoxStyle.Critical, "DESTINO")
            Me.Tx_Destino.Focus()
            ValidarSalidaAlmacen = False
            Exit Function
        End If

        If Tb_Observaciones.Text = Nothing Then
            MsgBox("El campo de Observación no puede estar vacío", MsgBoxStyle.Critical, "OBSERVACION")
            Me.Tb_Observaciones.Focus()
            ValidarSalidaAlmacen = False
            Exit Function
        End If

        If dtItemSalidaAlmacen.Rows.Count = 0 Then
            MsgBox("La salida debe tener al menos un item", MsgBoxStyle.Critical, "ITEM DE LA SALIDA")
            ValidarSalidaAlmacen = False
            Exit Function
        End If

        For i = 0 To dtItemSalidaAlmacen.Rows.Count - 1
            If IsDBNull(Me.Dgv_item.Item("CantDataGridViewTextBoxColumn", i).Value) = True Then
                Me.Dgv_item.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Me.Dgv_item.Rows(i).ErrorText = "El campo Cantidad Solicitada no es válido"
                ValidarSalidaAlmacen = False
                Try
                    Me.Dgv_item.CurrentCell = Me.Dgv_item(0, i)
                Catch ex As Exception
                End Try
                Exit Function
            End If

            If Me.Dgv_item.Item("CantDataGridViewTextBoxColumn", i).Value <= 0 Then
                Me.Dgv_item.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Me.Dgv_item.Rows(i).ErrorText = "El campo Cantidad Solicitada no es válido"
                ValidarSalidaAlmacen = False
                Try
                    Me.Dgv_item.CurrentCell = Me.Dgv_item(0, i)
                Catch ex As Exception
                End Try
                Exit Function
            End If

            If Me.Dgv_item.Item("CantDataGridViewTextBoxColumn", i).Value > Me.Dgv_item.Item("Existencia", i).Value Then
                Me.Dgv_item.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Me.Dgv_item.Rows(i).ErrorText = "La Cantidad Solicitada no esta disponible"
                ValidarSalidaAlmacen = False
                Try
                    Me.Dgv_item.CurrentCell = Me.Dgv_item(0, i)
                Catch ex As Exception
                End Try
                Exit Function
            End If

            If IsDBNull(Me.Dgv_item.Item("ValidarCant", i).Value) = False Then
                If Me.Dgv_item.Item("CantDataGridViewTextBoxColumn", i).Value > Me.Dgv_item.Item("ValidarCant", i).Value Then
                    Me.Dgv_item.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    Me.Dgv_item.Rows(i).ErrorText = "La Cantidad Solicitada no puede ser superior a la cantidad de la requisición"
                    ValidarSalidaAlmacen = False
                    Try
                        Me.Dgv_item.CurrentCell = Me.Dgv_item(0, i)
                    Catch ex As Exception
                    End Try
                    Exit Function
                End If
            End If
        Next

        If Tipo = 0 Then
            If EditarEquipos = "NUEVO" Then
                If Cbx_VerificacionEquipos.Checked = True Then
                    'Verificar Estado Uso
                    If tablaequiposfin.Rows.Count > 0 Then
                        Dim DtEquiposEstadoUso As New DataTable
                        DtEquiposEstadoUso.Columns.Add("IDEQUIPO")
                        DtEquiposEstadoUso.Columns.Add("ESTADO")
                        DtEquiposEstadoUso.Columns.Add("CODIGO")
                        DtEquiposEstadoUso.Clear()
                        For i As Integer = 0 To tablaequiposfin.Rows.Count - 1
                            Dim dsEquipoEstado As DataSet
                            dsEquipoEstado = bddatos.ModificarEntradasSalidas(26, 0, tablaequiposfin.Rows(i).Item("IDEQUIPO"), 0, Date.Now, 0, Date.Now, "", 0, 0, Nothing)
                            If dsEquipoEstado.Tables(0).Rows(0).Item("ESTADO") <> 1 Then
                                Dim Fila As DataRow
                                Fila = DtEquiposEstadoUso.NewRow
                                Fila("IDEQUIPO") = dsEquipoEstado.Tables(0).Rows(0).Item("IDEQUIPO")
                                Fila("ESTADO") = dsEquipoEstado.Tables(0).Rows(0).Item("ESTADO")
                                Fila("CODIGO") = dsEquipoEstado.Tables(0).Rows(0).Item("CODIGO")
                                DtEquiposEstadoUso.Rows.Add(Fila)
                            End If
                        Next
                        For i As Integer = 0 To tablacomponentesfin.Rows.Count - 1
                            Dim dsEquipoEstado2 As New DataSet
                            dsEquipoEstado2 = bddatos.ModificarEntradasSalidas(26, 0, tablacomponentesfin.Rows(i).Item("IDEQUIPO"), 0, Date.Now, 0, Date.Now, "", 0, 0, Nothing)
                            If dsEquipoEstado2.Tables(0).Rows(0).Item("ESTADO") <> 1 Then
                                Dim Fila2 As DataRow
                                Fila2 = DtEquiposEstadoUso.NewRow
                                Fila2("IDEQUIPO") = dsEquipoEstado2.Tables(0).Rows(0).Item("IDEQUIPO")
                                Fila2("ESTADO") = dsEquipoEstado2.Tables(0).Rows(0).Item("ESTADO")
                                Fila2("CODIGO") = dsEquipoEstado2.Tables(0).Rows(0).Item("CODIGO")
                                DtEquiposEstadoUso.Rows.Add(Fila2)
                            End If
                        Next
                        If DtEquiposEstadoUso.Rows.Count > 0 Then
                            Dim CadenaEquipos As String = ""
                            For i As Integer = 0 To DtEquiposEstadoUso.Rows.Count - 1
                                CadenaEquipos += DtEquiposEstadoUso.Rows(i).Item("CODIGO").ToString + ", "
                            Next
                            CadenaEquipos = CadenaEquipos.Substring(0, CadenaEquipos.Length - 2)
                            MsgBox("No se puede realizar el movimiento de equipos que su estado de uso es diferente a 'OPERANDO'. Verificar el estado de uso de los siguientes equipos: " + CadenaEquipos, MsgBoxStyle.Critical, "Estado De Uso")
                            ValidarSalidaAlmacen = False
                            Exit Function
                        End If
                    End If
                End If
            End If

        End If
        

        ValidarSalidaAlmacen = True
    End Function


    Public Sub GuardarSalidaAlmacen()

        Select Case Cb_TipoSalida.SelectedValue
            Case "T", "S"
                Dim _TABLA_BUSCARARTEQ As New DataTable
                _TABLA_BUSCARARTEQ.Columns.Add("IDEQUIPO")

                For i = 0 To (Dgv_item.Rows.Count - 2)
                    Dim fila As DataRow
                    fila = _TABLA_BUSCARARTEQ.NewRow
                    fila("IDEQUIPO") = Dgv_item.Rows(i).Cells(1).Value.ToString()
                    _TABLA_BUSCARARTEQ.Rows.Add(fila)
                Next
                Dim dsEquiposBuscar As DataSet
                dsEquiposBuscar = bddatos.ModificarEntradasSalidas(25, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, Date.Now, 0, Date.Now, "", 0, 0, _TABLA_BUSCARARTEQ)

                Dim CantidadArticulos As Integer = 0
                Dim CantidadEquipos As Integer = 0
                Dim IdArticuloValidar As Integer = 0
                Dim DataArticulos As New DataTable
                DataArticulos = Me.Dgv_item.DataSource
                For i As Integer = 0 To DataArticulos.Rows.Count - 1
                    CantidadArticulos += Convert.ToInt64(DataArticulos.Rows(i).Item("Cant"))
                Next

                If Cbx_VerificacionEquipos.Checked = True Then
                    If tablaequiposfin.Rows.Count > 0 Then
                        For i As Integer = 0 To tablaequiposfin.Rows.Count - 1
                            CantidadEquipos += 1
                        Next
                    End If
                    If tablacomponentesfin.Rows.Count > 0 Then
                        For i As Integer = 0 To tablacomponentesfin.Rows.Count - 1
                            CantidadEquipos += 1
                        Next
                    End If
                End If

                'Revisar si los articulos que estan en la entrada son activos fijos
                Dim FilaItemDS As DataRow
                FilaItemDS = dsEquiposBuscar.Tables(0).Rows(0)

                If Convert.ToInt64(FilaItemDS("Cant").ToString) > 0 And CantidadEquipos = 0 Then
                    If CantidadArticulos <> CantidadEquipos Then
                        If tablacomponentesfin.Rows.Count = 0 Or Cbx_VerificacionEquipos.Checked = False Then
                            MsgBox("No ha seleccionado o faltan equipos por seleccionar, verifique que las cantidades coincidan en el botón SELECCIONAR / VER EQUIPOS", MsgBoxStyle.Critical, "EQUIPOS")
                            Bt_SeleccionarEquipos.Focus()
                            Exit Sub
                        End If
                    End If
                Else
                    If tablacomponentesfin.Rows.Count > 0 Or Cbx_VerificacionEquipos.Checked = True Then
                        If CantidadArticulos <> CantidadEquipos Then
                            MsgBox("No ha seleccionado o faltan equipos por seleccionar, verifique que las cantidades coincidan en el botón SELECCIONAR / VER EQUIPOS", MsgBoxStyle.Critical, "EQUIPOS")
                            Bt_SeleccionarEquipos.Focus()
                            Exit Sub
                        End If
                    End If
                End If

        End Select


        Try
            dtItemSalidaAlmacen.AcceptChanges()
        Catch ex As Exception
        End Try
        Dim ContarItemsSA As Integer
        Dim TablaItemSA As New DataTable
        TablaItemSA.Columns.Add("IDITEMSALIDAALMACEN")
        TablaItemSA.Columns.Add("IDREQUISICION")
        TablaItemSA.Columns.Add("IDITEMREQUISICION")
        TablaItemSA.Columns.Add("IDARTICULO")
        TablaItemSA.Columns.Add("CANTIDAD")
        TablaItemSA.Columns.Add("IDREMISION")
        TablaItemSA.Columns.Add("IDORDENCOMPRA")
        TablaItemSA.Columns.Add("IDITEMORDENCOMPRA")
        Dim FilaTablaItemEA As DataRow
        For i = 0 To dtItemSalidaAlmacen.Rows.Count - 1
            ContarItemsSA += 1
            Dim FilaDGVItem As DataRow
            FilaDGVItem = dtItemSalidaAlmacen.Rows(i)
            FilaTablaItemEA = TablaItemSA.NewRow
            FilaTablaItemEA("IDITEMSALIDAALMACEN") = FilaDGVItem("Item")
            FilaTablaItemEA("CANTIDAD") = Replace(FilaDGVItem("Cant"), ",", ".")
            FilaTablaItemEA("IDARTICULO") = FilaDGVItem("Código")
            FilaTablaItemEA("IDREQUISICION") = FilaDGVItem("IDREQUISICION")
            FilaTablaItemEA("IDITEMREQUISICION") = FilaDGVItem("Item RQ")
            FilaTablaItemEA("IDREMISION") = FilaDGVItem("IDREMISION")
            FilaTablaItemEA("IDORDENCOMPRA") = FilaDGVItem("IDORDENCOMPRA")
            FilaTablaItemEA("IDITEMORDENCOMPRA") = FilaDGVItem("Item OC")
            TablaItemSA.Rows.Add(FilaTablaItemEA)
        Next

        Dim Comando As New SqlClient.SqlCommand("GestionarSalidaAlmacen")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TableItemSA", TablaItemSA)

        Comando.Parameters.AddWithValue("@IDSALIDAALMACEN", IDSALIDAALMACENMODIFICANDO)
        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 0)
        End If
        Comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        Comando.Parameters.AddWithValue("@TIPOSALIDAALMACEN", Me.Cb_TipoSalida.SelectedValue)
        Comando.Parameters.AddWithValue("@DESTINO", Me.Tx_Destino.Text)
        Comando.Parameters.AddWithValue("@IDPERSONAAUTORIZA", Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHADESPACHO", Me.Dtp_FechaDespacho.Value)
        Comando.Parameters.AddWithValue("@IDPERSONADESPACHA", Me.Cu_BuscarPersonaDespacha.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONARECIBE", Me.Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
        Dim Obser As String = Trim(Tb_Observaciones.Text)
        Obser = Replace(Obser, vbTab, " ")
        Obser = Replace(Obser, vbLf, " ")
        Comando.Parameters.AddWithValue("@OBSERVACION", Obser)
        Comando.Parameters.AddWithValue("@TRANSPORTADOR", Me.Tx_Transportador.Text)
        Comando.Parameters.AddWithValue("@PLACAVEHICULO", Me.Tx_PlacaVehiculo.Text)
        Comando.Parameters.AddWithValue("@RECIBETRANSPORTADOR", Me.Tx_RecibeTransportador.Text)
        Comando.Parameters.AddWithValue("@GUIA", Me.Tx_Guía.Text)
        Comando.Parameters.AddWithValue("@TIPOENVIO", Me.Cb_TipoEnvio.SelectedValue)
        Comando.Parameters.AddWithValue("@IDORDENTRABAJO", Me.Cu_AsociarOT.Identificador)
        If Editando = False Then
            Select Case Me.Cb_TipoSalida.SelectedValue
                Case "I", "R", "A", "C", "S", "H"
                    If MsgBox("¿Requiere una remisión para el despacho?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Requiere Remisión") = MsgBoxResult.Yes Then
                        Comando.Parameters.AddWithValue("@CREARREMISION", 1)
                    Else
                        Comando.Parameters.AddWithValue("@CREARREMISION", 0)
                    End If
                Case "D" ' Dotación
                    Comando.Parameters.AddWithValue("@CREARREMISION", 0)
                Case "T" ' Traslado de Bodega
                    Comando.Parameters.AddWithValue("@CREARREMISION", 1)
            End Select
        Else
            Comando.Parameters.AddWithValue("@CREARREMISION", 0)
        End If
        Select Case Me.Cb_TipoSalida.SelectedValue
            Case "I", "R", "A", "C", "D", "S", "H"
                Comando.Parameters.AddWithValue("@IDBODEGADESTINO", DBNull.Value)
            Case "T" ' Traslado de Bodega
                Comando.Parameters.AddWithValue("@IDBODEGADESTINO", Me.Cb_Relación.SelectedValue)
        End Select

        Select Case Me.Cb_TipoSalida.SelectedValue
            Case "C", "R", "D", "S", "H"
                Comando.Parameters.AddWithValue("@IDACTIVIDADPRINCIPAL", Me.Cb_Actividad.SelectedValue)
            Case "I", "A", "T" ' Traslado de Bodega
                Comando.Parameters.AddWithValue("@IDACTIVIDADPRINCIPAL", DBNull.Value)
        End Select

        Select Case Me.Cb_TipoSalida.SelectedValue
            Case "C", "D"
                Comando.Parameters.AddWithValue("@IDCENTROCOSTO", Me.Cu_CentroCosto1.IdCentroCosto)

            Case "I", "R", "A", "T", "S", "H" ' Traslado de Bodega
                Comando.Parameters.AddWithValue("@IDCENTROCOSTO", DBNull.Value)

        End Select

        Select Case Me.Cb_TipoSalida.SelectedValue
            Case "C", "R"
                If Me.Cu_AsociarActivoFijo1.IdEquipo = -1 Then
                    Comando.Parameters.AddWithValue("@IDEQUIPO", DBNull.Value)
                Else
                    Comando.Parameters.AddWithValue("@IDEQUIPO", Me.Cu_AsociarActivoFijo1.IdEquipo)
                End If
            Case Else
                Comando.Parameters.AddWithValue("@IDEQUIPO", DBNull.Value)
        End Select
        Select Case Me.Cb_TipoSalida.SelectedValue
            Case "C"

                If Me.Cu_AsociarActivoFijo1.LL_odometro.Text = "" Then
                    Comando.Parameters.AddWithValue("@REGISTROODOMETROHOROMETRO", DBNull.Value)
                Else
                    If Me.Cu_AsociarActivoFijo1.LL_odometro.Text = "###" Then
                        Comando.Parameters.AddWithValue("@REGISTROODOMETROHOROMETRO", DBNull.Value)
                    Else
                        Comando.Parameters.AddWithValue("@REGISTROODOMETROHOROMETRO", Convert.ToInt32(Cu_AsociarActivoFijo1.LL_odometro.Text))
                    End If
                End If


            Case Else
                Comando.Parameters.AddWithValue("@REGISTROODOMETROHOROMETRO", DBNull.Value)
        End Select

        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim msgParam1 As New SqlParameter("@CONSECUTIVOREMISION", SqlDbType.BigInt, 1)
        msgParam1.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam1)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)

        Comando.Connection = conn
        Dim errorguardado As Boolean = False

        Try
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            errorguardado = True
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        Dim idsalida As Integer = msgParam.Value

        If errorguardado = False Then
            ' si esta habilitado el guardado de equipos
            If Cbx_VerificacionEquipos.Checked = True Then
                'GUARDAR LOS EQUIPOS

                ' si es nuevo o edición
                ' SI ES REGISTRO NUEVO
                If EditarEquipos = "NUEVO" Or EditarEquipos = "EDITAR" Then
                    Try
                        Dim dstraslado As New DataSet
                        If EditarEquipos = "EDITAR" Then 'SI ES UNA EDICIÓN
                            ' regresar los equipos guardados inicialmente a estado activo en bodega
                            idsalida = IDSALIDAALMACENMODIFICANDO
                            dstraslado = bddatos.ModificarEntradasSalidas(9, 0, 0, 0, Date.Now, 0, Date.Now, "", idsalida, 0)
                        End If

                        Select Case Cb_TipoSalida.SelectedValue
                            Case "T" ' TRASLADOS
                                Dim _TABLA_IDEQUPO As New DataTable
                                _TABLA_IDEQUPO.Columns.Add("IDEQUIPO")

                                ' guardar bodega de destino y fecha actual, agregar equipos al traslado
                                For i = 0 To (tablaequiposfin.Rows.Count - 1)
                                    Dim fila As DataRow
                                    fila = _TABLA_IDEQUPO.NewRow
                                    fila("IDEQUIPO") = tablaequiposfin.Rows(i).Item(0)
                                    _TABLA_IDEQUPO.Rows.Add(fila)
                                Next

                                ' agregar componentes si existen
                                If tablacomponentesfin.Rows.Count > 0 Then
                                    For i = 0 To tablacomponentesfin.Rows.Count - 1
                                        Dim fila As DataRow
                                        fila = _TABLA_IDEQUPO.NewRow
                                        fila("IDEQUIPO") = tablacomponentesfin.Rows(i).Item(0)
                                        _TABLA_IDEQUPO.Rows.Add(fila)
                                    Next
                                End If

                                If _TABLA_IDEQUPO.Rows.Count > 0 Then
                                    dstraslado = bddatos.ModificarEntradasSalidas(3, 0, 0, 0, Date.Now, Cb_Relación.SelectedValue, Date.Now, "", idsalida, 0, _TABLA_IDEQUPO)
                                End If


                            Case "S" ' CUSTODIAS
                                ' Asignar los elementos a la persona que recibe y guardar salida de custodia
                                For i = 0 To (tablaequiposfin.Rows.Count - 1)
                                    dstraslado = bddatos.ModificarCustodias(1, 0, tablaequiposfin.Rows(i)("IDEQUIPO"), 7, Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue, idsalida, 0)
                                Next
                                ' agregar componentes si existen
                                If tablacomponentesfin.Rows.Count > 0 Then
                                    For i = 0 To (tablacomponentesfin.Rows.Count - 1)
                                        dstraslado = bddatos.ModificarCustodias(1, 0, tablacomponentesfin.Rows(i)("IDEQUIPO"), 7, Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue, idsalida, 0)
                                    Next
                                End If
                        End Select
                    Catch ex As Exception
                        MsgBox("No se pudieron guardar los equipos")
                    End Try
                End If
            End If

            ' impresión
            Select Case Trim(Comando.Parameters("@IDMENSAJE").Value)
                Case -3
                    MsgBox("No se posee las cantidades necesarias. Revisar Existencias", MsgBoxStyle.Exclamation, "No se completó la operación")
                    Exit Sub
                Case 0
                    MsgBox("No se pudo realizar la operación", MsgBoxStyle.Exclamation, "No se completó la operación")
                    Exit Sub
                Case Is > 0
                    MsgBox("Se guardo la salida de almacén correctamente", MsgBoxStyle.Information, "Nueva Salida de Almacén")

                    Dim FlagCorreo As Integer = 0
                    Dim ArticulosArray As ArrayList = New ArrayList()

                    If Editando = False Then
                        For i = 0 To dtItemSalidaAlmacen.Rows.Count - 1
                            Dim FilaDGVItem As DataRow
                            FilaDGVItem = dtItemSalidaAlmacen.Rows(i)
                            If FilaDGVItem("Código") = 5440 Or FilaDGVItem("Código") = 5441 Then
                                FlagCorreo = 1
                                ArticulosArray.Add(FilaDGVItem("Código"))
                            End If
                        Next
                    End If
                    If FlagCorreo = 1 Then
                        Dim Cadena_Consulta3 As String
                        Cadena_Consulta3 = "select CORREOELECTRONICOCORPORTATIVO from USUARIO where IDPERSONA = @IdPersona"
                        Dim Correo As String
                        Dim Consulta3 As New SqlClient.SqlCommand(Cadena_Consulta3)
                        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                        Consulta3.Connection = Conexión
                        Consulta3.Parameters.AddWithValue("@IdPersona", VariablesBase.VariablesBase.IdPersona)
                        Consulta3.Connection.Open()
                        Correo = Consulta3.ExecuteScalar()
                        Consulta3.Connection.Close()
                        Correo = Trim(Correo)
                        If IsDBNull(Correo) Or Correo = "" Then
                            MsgBox("El usuario que genero la salida no tiene correo asignado, recuerde llenar el formato ICS GRAL-F-043 R5 Reporte Diario de Productos Químicos SICOQ y enviarlo al correo coordinadorqaqc@ismocol.com y con copia al correo compras3@ismocol.com")
                        Else
                            EnviarCorreoSalidaAlmacen(ArticulosArray, dtItemSalidaAlmacen, Comando.Parameters("@IDMENSAJE").Value)
                        End If
                    End If

                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "SA", "DESPACHA", Cu_BuscarPersonaDespacha.Cb_Persona.SelectedValue)
                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "SA", "AUTORIZA", Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue)
                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "SA", "RECIBE", Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue)

                    If MsgBox("¿Desea imprimir la Salida de Almacén?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                        Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                        Dim Array As New ArrayList
                        Array.Add(66)
                        climpresiones.IDSALIDAALMACEN = Comando.Parameters("@IDMENSAJE").Value
                        climpresiones.FormatoImprimirMateriales(Array, True, False)
                    End If
                    If IsDBNull(Comando.Parameters("@CONSECUTIVOREMISION").Value) = False Then
                        If Comando.Parameters("@CONSECUTIVOREMISION").Value > 0 Then
                            'Dim seleccion As String = ""

                            Dim FrImprimirTipoRemision As New Form
                            Dim Lb_Mensaje As New Label
                            Dim Bt_Imprimir As New Button
                            Dim Bt_RemisionValorizada As New Button
                            Dim Bt_Cancelar As New Button
                            AddHandler Bt_Imprimir.Click, Sub()
                                                              'seleccion = "R"
                                                              FrImprimirTipoRemision.DialogResult = DialogResult.Yes
                                                              FrImprimirTipoRemision.Close()
                                                          End Sub
                            'AddHandler Bt_RemisionValorizada.Click, Sub()
                            '                                            seleccion = "V"
                            '                                            FrImprimirTipoRemision.DialogResult = DialogResult.Yes
                            '                                            FrImprimirTipoRemision.Close()
                            '                                        End Sub
                            AddHandler Bt_Cancelar.Click, Sub()
                                                              'seleccion = ""
                                                              FrImprimirTipoRemision.DialogResult = DialogResult.No
                                                              FrImprimirTipoRemision.Close()
                                                          End Sub
                            With Lb_Mensaje
                                .AutoSize = True
                                .Text = "¿Desea imprimir la remisión?"
                                .Location = New Point(10, 20)
                            End With
                            With Bt_Imprimir
                                .AutoSize = True
                                .Text = "Imprimir"
                                .Location = New Point(20, 60)
                            End With
                            'With Bt_RemisionValorizada
                            '    .AutoSize = True
                            '    .Text = "Remisión Valorizada"
                            '    .Location = New Point(124, 60)
                            'End With
                            With Bt_Cancelar
                                .AutoSize = True
                                .Text = "No imprimir"
                                .Location = New Point(120, 60)
                            End With
                            With FrImprimirTipoRemision
                                .ClientSize = New Size(220, 90)
                                .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
                                .Controls.Add(Lb_Mensaje)
                                .Controls.Add(Bt_Imprimir)
                                '.Controls.Add(Bt_RemisionValorizada)
                                .Controls.Add(Bt_Cancelar)
                                .StartPosition = FormStartPosition.CenterScreen
                                .Text = "IMPRIMIR"
                                .MaximizeBox = False
                                .MinimizeBox = False
                            End With
                            Dim drImprimirTipoRemision As DialogResult = FrImprimirTipoRemision.ShowDialog()

                            If drImprimirTipoRemision = DialogResult.Yes Then

                                Dim FrOpcionesImpresión As New ImpresiónMateriales.Fr_OpcionesImpresión

                                FrOpcionesImpresión.Tipo = 5

                                FrOpcionesImpresión.Lb_Segundo.Text = "Remisión Valorizada"
                                Dim FrArticulosSinValorReferencia As New FormulariosClasesBase.Fr_ArticulosSinValorReferencia
                                FrArticulosSinValorReferencia.IDREMISIONVALORIZADA = Comando.Parameters("@CONSECUTIVOREMISION").Value
                                FrArticulosSinValorReferencia.Cargar()
                                If FrArticulosSinValorReferencia.ValidarValoresRemision() = False Then
                                    Dim drASinVRef As DialogResult = FrArticulosSinValorReferencia.ShowDialog()
                                    If drASinVRef = DialogResult.Cancel Then
                                        Exit Sub
                                    End If
                                End If



                                FrOpcionesImpresión.Lb_Primero.Text = "Remisión"
                                FrOpcionesImpresión.ID = Comando.Parameters("@CONSECUTIVOREMISION").Value
                                FrOpcionesImpresión.IdSalida = Comando.Parameters("@IDMENSAJE").Value
                                FrOpcionesImpresión.Ck_Impresión1.Text = "Copia Destinatario"
                                FrOpcionesImpresión.Ck_Impresión1.Checked = True
                                FrOpcionesImpresión.Ck_Impresión2.Text = "Copia Transportador"
                                FrOpcionesImpresión.Ck_Impresión2.Checked = True
                                FrOpcionesImpresión.Ck_Impresión3.Text = "Copia Consecutivo"
                                FrOpcionesImpresión.Ck_Impresión3.Checked = False
                                FrOpcionesImpresión.Ck_Impresión4.Text = "Copia Portería de Salida"
                                FrOpcionesImpresión.Ck_Impresión4.Checked = True
                                FrOpcionesImpresión.Ck_Impresión5.Visible = False
                                FrOpcionesImpresión.Ck_Impresión5.Checked = False

                                FrOpcionesImpresión.Ck_Impresión6.Text = "Copia Destinatario"
                                FrOpcionesImpresión.Ck_Impresión6.Checked = False
                                FrOpcionesImpresión.Ck_Impresión7.Text = "Copia Transportador"
                                FrOpcionesImpresión.Ck_Impresión7.Checked = False
                                FrOpcionesImpresión.Ck_Impresión8.Text = "Copia Consecutivo"
                                FrOpcionesImpresión.Ck_Impresión8.Checked = True
                                FrOpcionesImpresión.Ck_Impresión9.Text = "Copia Portería de Salida"
                                FrOpcionesImpresión.Ck_Impresión9.Checked = False
                                FrOpcionesImpresión.Ck_VistaPrevia.Visible = True
                                FrOpcionesImpresión.Ck_VistaPrevia.Checked = False
                                FrOpcionesImpresión.Width = 852
                                FrOpcionesImpresión.MaximumSize = New System.Drawing.Size(852, 216)
                                FrOpcionesImpresión.MinimumSize = New System.Drawing.Size(852, 216)

                                Dim CantidadLineasOcupa As Integer = 0
                                Dim dt_Articulos As New DataTable
                                Dim MediaCarta As Boolean = False
                                dt_Articulos = Dgv_item.DataSource

                                For i As Integer = 0 To dt_Articulos.Rows.Count - 1
                                    Dim filaItemRemision As DataRow
                                    filaItemRemision = dt_Articulos.Rows(i)
                                    Dim dsequipos As New DataSet
                                    dsequipos = bddatos.ModificarCustodias(9, 0, filaItemRemision("Código"), 0, 0, Comando.Parameters("@CONSECUTIVOREMISION").Value, 0)
                                    Dim LargoArticulo As Integer = dt_Articulos.Rows(i).Item("Descripción").ToString.Length
                                    If dt_Articulos.Rows(i).Item("Descripción").ToString.Length < 91 Then
                                        CantidadLineasOcupa += 1
                                    Else
                                        If dt_Articulos.Rows(i).Item("Descripción").ToString.Length < 181 Then
                                            CantidadLineasOcupa += 2
                                        Else
                                            CantidadLineasOcupa += 3
                                        End If

                                    End If
                                    If CantidadLineasOcupa > 6 Then
                                        MediaCarta = False
                                        Exit For
                                    End If

                                    If dsequipos.Tables(0).Rows.Count > 0 Then
                                        Dim CadenaEquipos As String = "Códigos: "
                                        For j As Integer = 0 To dsequipos.Tables(0).Rows.Count - 1
                                            CadenaEquipos += dsequipos.Tables(0).Rows(j)("CODIGO")
                                            If j <> dsequipos.Tables(0).Rows.Count - 1 Then
                                                CadenaEquipos += ", "
                                            End If
                                        Next

                                        If CadenaEquipos.Length < 71 Then
                                            CantidadLineasOcupa += 1
                                        Else
                                            If CadenaEquipos.Length < 140 Then
                                                CantidadLineasOcupa += 2
                                            Else
                                                If CadenaEquipos.Length < 210 Then
                                                    CantidadLineasOcupa += 3
                                                Else
                                                    If CadenaEquipos.Length < 280 Then
                                                        CantidadLineasOcupa += 4
                                                    Else
                                                        If CadenaEquipos.Length < 350 Then
                                                            CantidadLineasOcupa += 5
                                                        End If
                                                    End If
                                                End If
                                            End If

                                        End If
                                    End If
                                Next

                                If CantidadLineasOcupa < 6 Then
                                    FrOpcionesImpresión.Ck_MediaCarta.Text = "Imprimir en media carta"
                                    FrOpcionesImpresión.Ck_MediaCarta.Checked = False
                                    FrOpcionesImpresión.Ck_MediaCarta.Location = New System.Drawing.Point(15, 122)
                                    FrOpcionesImpresión.Ck_MediaCarta.Visible = True
                                End If

                                FrOpcionesImpresión.cargar()
                                FrOpcionesImpresión.ShowDialog()

                                'crear el sobre y envia a imprimir
                                'Select Case seleccion
                                '    Case "R"
                                '        FrOpcionesImpresión.Tipo = 1
                                '    Case "V"
                                '        FrOpcionesImpresión.Tipo = 3
                                '        Dim FrArticulosSinValorReferencia As New FormulariosClasesBase.Fr_ArticulosSinValorReferencia
                                '        FrArticulosSinValorReferencia.IDREMISIONVALORIZADA = Comando.Parameters("@CONSECUTIVOREMISION").Value
                                '        FrArticulosSinValorReferencia.Cargar()
                                '        If FrArticulosSinValorReferencia.ValidarValoresRemision() = False Then
                                '            Dim drASinVRef As DialogResult = FrArticulosSinValorReferencia.ShowDialog()
                                '            If drASinVRef = DialogResult.Cancel Then
                                '                Exit Sub
                                '            End If
                                '        End If
                                'End Select


                            End If
                        End If
                    End If
                    guardado = True
                    Me.Close()
                Case -2
                    MsgBox("Se guardaron los cambios de la Salida de Almacén", MsgBoxStyle.Information, "Modificar Salida de Almacén")
                    guardado = True
                    Me.Close()
            End Select
        End If
    End Sub
    Public Sub EnviarCorreoSalidaAlmacen(ArticulosArray As ArrayList, dtItems As DataTable, IdSalida As String)
        Dim textoContenido As String = ""
        Dim asunto As String
        Dim Cadena_Consulta As String
        Dim Cadena_Consulta2 As String
        Dim Cadena_Consulta3 As String
        Dim Dt_Salida As DataTable
        Dim FilaSalida As DataRow

        Cadena_Consulta = "SELECT IDUSUARIOREGISTRO,SALIDAALMACEN FROM SALIDAALMACEN WHERE SALIDAALMACEN.IDSALIDAALMACEN = " + Convert.ToString(IdSalida)

        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Dt_Salida = New DataTable
        Adaptador.FillSchema(Dt_Salida, SchemaType.Source)
        Adaptador.Fill(Dt_Salida)
        Consulta.Connection.Close()
        FilaSalida = Dt_Salida.Rows(0)

        Cadena_Consulta2 = "SELECT dbo.Personanombrecompleto(@IdPersona)"
        Dim nombre As String
        Dim Consulta2 As New SqlClient.SqlCommand(Cadena_Consulta2)
        Consulta2.Connection = Conexión
        Consulta2.Parameters.AddWithValue("@IdPersona", FilaSalida("IDUSUARIOREGISTRO"))
        Consulta2.Connection.Open()
        nombre = Consulta2.ExecuteScalar()
        Consulta2.Connection.Close()

        Cadena_Consulta3 = "select CORREOELECTRONICOCORPORTATIVO from USUARIO where IDPERSONA = @IdPersona"
        Dim Correo As String
        Dim Consulta3 As New SqlClient.SqlCommand(Cadena_Consulta3)
        Consulta3.Connection = Conexión
        Consulta3.Parameters.AddWithValue("@IdPersona", FilaSalida("IDUSUARIOREGISTRO"))
        Consulta3.Connection.Open()
        Correo = Consulta3.ExecuteScalar()
        Consulta3.Connection.Close()
        asunto = "Se realizo la salida: " + CStr(Trim(FilaSalida("SALIDAALMACEN"))) + ".  "

        textoContenido = ""
        textoContenido += "<div style =""padding:10px; max-width :1000px; "">"
        textoContenido += "<table style =""width:100%;"" border= ""1""  >"
        textoContenido += "    <tr style=""border:1px solid;"" text-align:center;>"
        textoContenido += "        <td style=""width:170px; text-align:center; padding:10px;""><img src=""http://190.0.43.174:7070/imagenes/logo.png"" width=""100px"" /></td>"
        textoContenido += "        <td> <CENTER> <B>SISTEMA DE MATERIALES</B> </CENTER></td>"
        textoContenido += "        <td> <CENTER> <B>Salida: </B> " + CStr(Trim(FilaSalida("SALIDAALMACEN"))) + " </CENTER> </td>"
        textoContenido += "    </tr>"

        textoContenido += "</table>"
        textoContenido += "<P>"
        textoContenido += "<table border= ""1"" style =""width:100%;"" >"

        For i As Integer = 0 To dtItems.Rows.Count - 1
            If (dtItems.Rows(i).Item("Código") = 5440 Or dtItems.Rows(i).Item("Código") = 5441) Then
                textoContenido += "<tr>"
                textoContenido += "<td> <B>Artículo Id:  </B>" + Trim(dtItems.Rows(i).Item("Código")) + "</td>"
                textoContenido += "<td> <B>Nombre Artículo:  </B>" + "THINNER" + "</td>"
                textoContenido += "<td> <B>Cantidad:  </B>" + Replace(dtItems.Rows(i).Item("Cant"), ",", ".") + "</td>"
                textoContenido += "</tr>"
            End If
        Next

        textoContenido += "<tr>"
        textoContenido += "<td colspan=""3""> <B>Salida realizada por:  </B>" + Trim(nombre) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<tr>"
        textoContenido += "<td colspan=""3""> Usted realizó la salida: " + CStr(Trim(FilaSalida("SALIDAALMACEN"))) + " de THINNER, no olvide diligenciar el formato <b>ICS GRAL-F-043 R5 Reporte Diario de Productos Químicos SICOQ</b> con la versión vigente y <b>enviarlo el mismo día</b> en que se realizó la salida al correo <b>coordinadorqaqc@ismocol.com</b> y con copia al correo <b>compras3@ismocol.com</b></td>"
        textoContenido += "</tr>"

        textoContenido += "<P>"
        textoContenido += "<tr>"
        textoContenido += "<td colspan=""3""><CENTER>Por favor no contestar el E-Mail a esta cuenta de Correo.</CENTER></td>"
        textoContenido += "</tr>"
        textoContenido += "<tr>"
        textoContenido += "<td colspan=""3""><CENTER>Para cualquier consulta comuníquese a soporteaplicaciones@ismocol.com</CENTER></td>"
        textoContenido += "</tr>"

        textoContenido += "</div>"
        textoContenido += "</center>"

        ' Se arma el html que va a llegar al correo
        Dim cuerpo As String = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>"
        cuerpo += "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        cuerpo += "<head>"
        cuerpo += "<meta http-equiv=""Content-Type"" content=""text/html charset=utf-8"" />"
        cuerpo += "<title>Salida Almacen</title>"
        cuerpo += "</head>"
        cuerpo += "<body>"
        cuerpo += "<center>"
        cuerpo += textoContenido
        cuerpo += "</center>"
        cuerpo += "</body>"
        cuerpo += "</html>"

        '********************************************** Envío de mail ************************************************/

        Dim strSMTP As String = "smtp.gmail.com"
        'revisar conteo para cambiar de correo cuando se llegue a 450 enviados
        Dim correoOrigen As String
        Dim correoOrigenClave As String

        correoOrigen = "informacion-noreplicar@ismocol.com"
        correoOrigenClave = "Sap753150"

        Dim SmtpServer As New SmtpClient("smtp.gmail.com", 587)
        SmtpServer.UseDefaultCredentials = False
        SmtpServer.Credentials = New Net.NetworkCredential(correoOrigen, correoOrigenClave)
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        If VariablesBase.VariablesBase.NombreBaseDatos = "ISMOCOLPRODUCCION" Then
            mail.To.Add(Trim(Correo.ToString))
        Else
            mail.To.Add("soporteaplicaciones@ismocol.com")
        End If
        mail.From = New MailAddress(correoOrigen)
        mail.Subject = asunto
        mail.Body = cuerpo

        mail.IsBodyHtml = True
        mail.Priority = MailPriority.Normal
        'QUITAR PARA QUE FUNCIONE
        SmtpServer.Send(mail)
        'MsgBox("Se envió notificación al correo " + Trim(correoDestino), MsgBoxStyle.Information, "Entrada de Almacén")

    End Sub
    Private Sub Dgv_item_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_item.CellEndEdit

        Index_Registro_Actual = Dgv_item.CurrentRow.Index

        If IsDBNull(Me.Dgv_item.Item(e.ColumnIndex, e.RowIndex).Value) = True Then
            Me.Dgv_item.Item(e.ColumnIndex, e.RowIndex).Value = 0
        End If
        If Trim(Me.Dgv_item.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then

            If e.RowIndex > 0 Then
                Me.Dgv_item.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                Me.Dgv_item.Rows(e.RowIndex).ErrorText = ""
            Else
                Try
                    Me.Dgv_item.Rows.RemoveAt(e.RowIndex)
                Catch ex As Exception
                End Try
            End If
            Exit Sub
        End If



        Dim IDARTICULO As Integer = -1
        If IsDBNull(Me.Dgv_item.Item("CódigoDataGridViewTextBoxColumn", e.RowIndex).Value) = False Then
            IDARTICULO = Me.Dgv_item.Item("CódigoDataGridViewTextBoxColumn", e.RowIndex).Value
        End If
        Dim CANTIDAD As Double = -1
        If IsDBNull(Me.Dgv_item.Item("CantDataGridViewTextBoxColumn", e.RowIndex).Value) = False Then
            CANTIDAD = Me.Dgv_item.Item("CantDataGridViewTextBoxColumn", e.RowIndex).Value
        End If

        Dim EXISTENCIA As Double = -1
        If IsDBNull(Me.Dgv_item.Item("Existencia", e.RowIndex).Value) = False Then
            EXISTENCIA = Me.Dgv_item.Item("Existencia", e.RowIndex).Value
        End If

        Dim Estilo_Celda As New DataGridViewCellStyle
        Estilo_Celda.BackColor = Color.White
        Me.Dgv_item.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda
        Me.Dgv_item.Rows(e.RowIndex).ErrorText = ""

        Dim FilasArticulos As DataRow()
        ' Validar Artículo
        Select Case e.ColumnIndex

            Case Dgv_item.Columns(CódigoDataGridViewTextBoxColumn.Name).Index
                If ValidarItem(IDARTICULO) = True Then

                    articulos = New DataTable("ListarArticulos_1")
                    Dim Cadena_Consulta As String =
                        "SELECT * FROM " + _
                        " dbo.DatosArticuloxBodega(" & IDARTICULO & "," & VariablesBase.VariablesBase.IdBodegaActual & ") AS ListarArticulos_1"
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Adaptador.FillSchema(articulos, SchemaType.Source)
                    Adaptador.Fill(articulos)
                    Consulta.Connection.Close()
                    FilasArticulos = articulos.Select("ID=" + IDARTICULO.ToString)
                    If FilasArticulos.Length > 0 Then


                        Dim FilaArticulo As DataRow
                        FilaArticulo = FilasArticulos(0)
                        Dim FilaNueva As DataRow
                        FilaNueva = dtItemSalidaAlmacen.NewRow
                        FilaNueva("Item") = e.RowIndex + 1
                        FilaNueva("Código") = IDARTICULO
                        FilaNueva("Descripción") = FilaArticulo("NOMBRE")
                        FilaNueva("Requisición") = DBNull.Value
                        FilaNueva("Item RQ") = DBNull.Value
                        FilaNueva("Und") = FilaArticulo("UND")
                        If IsDBNull(Me.Dgv_item.Rows(Index_Registro_Actual).Cells("DescripciónDataGridViewTextBoxColumn").Value) = False Then
                            FilaNueva("Cant") = CANTIDAD
                        Else
                            FilaNueva("Cant") = 1
                        End If
                        FilaNueva("Existencia") = Replace(FilaArticulo("EXISTENCIAS"), ".", ",")
                        FilaNueva("IDREQUISICION") = DBNull.Value
                        FilaNueva("IDSALIDAALMACEN") = -1


                        'If Me.Dgv_item.CurrentRow.Index = dtItemSalidaAlmacen.Rows.Count Then
                        '    Try
                        '        Me.Dgv_item.Rows.RemoveAt(e.RowIndex)
                        '    Catch
                        '    End Try
                        '    dtItemSalidaAlmacen.Rows.Add(FilaNueva)
                        '    Me.Cb_TipoSalida.Enabled = False
                        'Else
                        '    dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("Item") = e.RowIndex + 1
                        '    dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("Código") = FilaNueva("Código")
                        '    dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("Descripción") = FilaNueva("Descripción")
                        '    dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("Und") = FilaNueva("Und")
                        '    dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("Cant") = IIf(IsDBNull(dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("Cant")) = True, 1, dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("Cant"))
                        '    dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("Existencia") = FilaNueva("Existencia")
                        '    If IsDBNull(FilaNueva("Requisición")) = False Then
                        '        dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("Requisición") = FilaNueva("Requisición")
                        '    End If
                        '    If IsDBNull(FilaNueva("Item RQ")) = False Then
                        '        dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("Item_RQ") = FilaNueva("Item RQ")
                        '    End If
                        '    If IsDBNull(FilaNueva("IDREQUISICION")) = False Then
                        '        dtItemSalidaAlmacen.Rows(Me.Dgv_item.CurrentRow.Index).Item("IDREQUISICION") = FilaNueva("IDREQUISICION")
                        '    End If

                        '    End If
                        '    dtItemSalidaAlmacen.AcceptChanges()
                        If ValorAnteriorEdiciónIDArticulo = -1 Then
                            Try
                                Me.Dgv_item.Rows.RemoveAt(e.RowIndex)
                            Catch
                            End Try
                            dtItemSalidaAlmacen.Rows.Add(FilaNueva)
                            Me.Cb_TipoSalida.Enabled = False
                        Else
                            dtItemSalidaAlmacen(e.RowIndex).Item("Código") = FilaNueva("Código")
                            dtItemSalidaAlmacen(e.RowIndex).Item("Descripción") = FilaNueva("Descripción")
                            If IsDBNull(FilaNueva("Requisición")) = False Then
                                dtItemSalidaAlmacen(e.RowIndex).Item("Requisición") = FilaNueva("Requisición")
                            End If
                            If IsDBNull(FilaNueva("Item RQ")) = False Then
                                dtItemSalidaAlmacen(e.RowIndex).Item("Item_RQ") = FilaNueva("Item RQ")
                            End If
                            If IsDBNull(FilaNueva("IDREQUISICION")) = False Then
                                dtItemSalidaAlmacen(e.RowIndex).Item("IDREQUISICION") = FilaNueva("IDREQUISICION")
                            End If

                            dtItemSalidaAlmacen(e.RowIndex).Item("Und") = FilaNueva("Und")
                            dtItemSalidaAlmacen(e.RowIndex).Item("Cant") = FilaNueva("Cant")
                            dtItemSalidaAlmacen(e.RowIndex).Item("Existencia") = FilaNueva("Existencia")
                        End If
                    Else
                        ' No existe un articulo con este código
                        MsgBox("No se encontró un artículo con ese código", MsgBoxStyle.Exclamation, "Artículo no Encontrado")
                        Try
                            Me.Dgv_item.Item(e.ColumnIndex, e.RowIndex).Value = ValorAnteriorEdiciónIDArticulo
                        Catch ex As Exception
                        End Try
                        moverEnfoque()
                    End If

                    BloquearCajas()
                    LimpiarTablas()
                    UbicarRegistros()
                    ELiminarFilaVacia()
                Else
                    Dim i As Integer = dtItemSalidaAlmacen.Select("Código=" + IDARTICULO.ToString)(0).Item("Item")
                    Dim n As Integer = Dgv_item.Rows(i - 1).Cells(4).Value
                    n = n + 1
                    Dgv_item.Rows(i - 1).Cells(4).Value = n
                    Try
                        Me.Dgv_item.Item(e.ColumnIndex, e.RowIndex).Value = ValorAnteriorEdiciónIDArticulo
                    Catch ex As Exception
                    End Try


                    If IsDBNull(Dgv_item.Item(4, e.RowIndex).Value) = False Then
                        ELiminarFilallena()
                        UbicarRegistros()
                    Else
                        ELiminarFilaVacia()
                    End If
                    moverEnfoque()

                End If
            Case 4
                If Trim(CANTIDAD) = "" Then
                    Me.Dgv_item.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                    Me.Dgv_item.Rows(e.RowIndex).ErrorText = "El campo Cantidad Solicitada no es válido"
                Else
                    If IsNumeric(CANTIDAD) = False Then
                        Me.Dgv_item.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                        Me.Dgv_item.Rows(e.RowIndex).ErrorText = "El campo Cantidad Solicitada no es válido"
                    Else
                        If CANTIDAD <= 0 Then
                            Me.Dgv_item.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                            Me.Dgv_item.Rows(e.RowIndex).ErrorText = "El campo Cantidad Solicitada no es válido"
                        Else
                            If CANTIDAD > EXISTENCIA Then
                                Me.Dgv_item.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                Me.Dgv_item.Rows(e.RowIndex).ErrorText = "Cantidad Solicitada debe ser igual o menor a la Existencia"
                            End If
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub moverEnfoque()
        SendKeys.Send("{ENTER}")
    End Sub

    Public Sub UbicarRegistros()
        Try
            Me.Dgv_item.CurrentCell = Me.Dgv_item(1, Index_Registro_Actual)
        Catch ex As Exception
        End Try
    End Sub

    Private Function ValidarItem(ByVal IdArticulo As Integer) As Boolean
        Dim filas As DataRow()
        filas = dtItemSalidaAlmacen.Select("Código=" + IdArticulo.ToString)
        If filas.Length > 0 Then
            ValidarItem = False
            Exit Function
        End If
        ValidarItem = True
    End Function


    Private Sub Cb_Relación_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_Relación.SelectedIndexChanged
        If Me.Cb_TipoSalida.SelectedValue = "T" Then
            Try
                Dim filas As DataRow()
                filas = dtBodegasListado.Select("IDBODEGA=" + Cb_Relación.SelectedValue.ToString)
                Me.Tx_Destino.Text = filas(0).Item(3)

                Dim dt_RqPendientes As New DataTable
                dt_RqPendientes = CargarRequisicionesPendientesXTraslado(1, -1, Cb_Relación.SelectedValue)
                If dt_RqPendientes.Rows.Count > 0 Then
                    Me.Cb_AsociarRq.DataSource = dt_RqPendientes
                    Me.Cb_AsociarRq.DisplayMember = "REQUISICION"
                    Me.Cb_AsociarRq.ValueMember = "IDREQUISICION"
                Else
                    Me.Cb_AsociarRq.DataSource = Nothing
                End If

                CargarOrdenesPendienteEnvio(1) '1 para solicitar los pendientes solo dos columnas 

            Catch
            End Try
        End If
    End Sub


    Private Sub Bt_AgregarActividad_Click(sender As System.Object, e As System.EventArgs) Handles Bt_AgregarActividad.Click
        Dim NuevaActividad As String
        NuevaActividad = Trim(Mid(InputBox("Digite la actividad que desea agregar", "Agregar Actividad", ""), 1, 300))
        If NuevaActividad = "" Then
            Exit Sub
        End If

        Dim Comando As New SqlClient.SqlCommand("GestionarActividadPrincipal")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TablaActividadesPrincipales", Nothing)
        Comando.Parameters.AddWithValue("@ACCION", 1)
        Comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        Comando.Parameters.AddWithValue("@NOMBREACTIVIDADPRINCIPAL", NuevaActividad)
        Dim msgParam As New SqlParameter("@ACTIVIDADPRINCIPAL", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Comando.Connection = conn
        Try
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        Select Case Comando.Parameters("@ACTIVIDADPRINCIPAL").Value
            Case 0
                MsgBox("No se pudo realizar la operación", MsgBoxStyle.Exclamation, "No se completó la operación")
                Exit Sub
            Case Is > 0
                MsgBox("Se agregó la actividad correctamente", MsgBoxStyle.Information, "Nueva Salida de Almacén")
                CargarActividades()
                Me.Cb_Actividad.SelectedValue = Comando.Parameters("@ACTIVIDADPRINCIPAL").Value
        End Select
    End Sub


    Private Sub Bt_CancelarSalida_Click(sender As System.Object, e As System.EventArgs) Handles Bt_CancelarSalida.Click
        Me.Close()
    End Sub


    Private Sub Fr_SalidaAlmacen_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If guardado = False And Me.Bt_GuardarSalida.Enabled = True Then
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


    Private Sub Dgv_item_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv_item.KeyDown
        If EditarEquipos = "VER" Then
            'no se puede editar
            Exit Sub
        End If

        Select Case e.KeyCode
            Case Windows.Forms.Keys.F3
                Select Case Me.Cb_TipoSalida.SelectedValue
                    Case "I" ' Ajuste de inventario
                        BuscarItems()
                    Case "R" ' Requisición
                        MensajeError = "Solo puede ingresar los Items de la Requisición"
                        MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Articulo Requisición")
                    Case "A" ' Alquiler
                        MensajeError = "Solo puede ingresar los Items del Alquiler"
                        MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Articulo Alquiler")
                    Case "C" ' Consumo
                        BuscarItems()
                    Case "T" ' Traslado de Bodega
                        BuscarItems()
                    Case "D" ' Dotación
                        BuscarItems()
                    Case "S" ' Custodia de Equipo
                        BuscarItems()
                    Case "H" ' Custodia Herramienta
                        BuscarItems()
                End Select


            Case Windows.Forms.Keys.Delete
                Try
                    Me.Dgv_item.Rows.RemoveAt(Me.Dgv_item.CurrentCell.RowIndex)
                    LimpiarTablas()
                Catch ex As Exception
                End Try
                Try
                    dtItemSalidaAlmacen.AcceptChanges()
                Catch ex As Exception
                End Try
                If dtItemSalidaAlmacen.Rows.Count = 0 Then
                    If Editando = False Then
                        Me.Cb_TipoSalida.Enabled = True
                        Me.Cb_Relación.Enabled = True
                    End If
                Else
                    For x As Integer = Dgv_item.CurrentCell.RowIndex To dtItemSalidaAlmacen.Rows.Count - 1
                        If IsDBNull(dtItemSalidaAlmacen(x).Item("Item")) = False Then
                            dtItemSalidaAlmacen(x).Item("Item") = x + 1
                        End If
                    Next
                    Try
                        Me.Dgv_item.CurrentCell = Me.Dgv_item(1, Index_Registro_Actual)
                    Catch ex As Exception
                    End Try
                    moverEnfoque()
                End If
        End Select
        BloquearCajas()
        ELiminarFilaVacia()
    End Sub


    Private Sub BuscarItems()
        Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
        FrBuscarArtículo._Tipo = "T"
        FrBuscarArtículo.Familia = familia
        FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar

        FrBuscarArtículo.ShowDialog()
        If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
            Exit Sub
        End If

        If ValidarItems(FrBuscarArtículo.IdArtículo) = True Then
            Dim FilasArticulos As DataRow()

            articulos = New DataTable("ListarArticulos_1")
            Dim Cadena_Consulta As String =
                "SELECT * FROM " + _
                " dbo.DatosArticuloxBodega(" & FrBuscarArtículo.IdArtículo.ToString & "," & VariablesBase.VariablesBase.IdBodegaActual & ") AS ListarArticulos_1"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Adaptador.FillSchema(articulos, SchemaType.Source)
            Adaptador.Fill(articulos)
            Consulta.Connection.Close()
            FilasArticulos = articulos.Select("ID=" + FrBuscarArtículo.IdArtículo.ToString)
            If FilasArticulos.Length > 0 Then
                Dim FilaArticulo As DataRow
                FilaArticulo = FilasArticulos(0)
                Dim NuevaFilaItem As DataRow
                NuevaFilaItem = dtItemSalidaAlmacen.NewRow
                NuevaFilaItem("Item") = dtItemSalidaAlmacen.Rows.Count + 1
                NuevaFilaItem("Código") = FilaArticulo("ID")
                NuevaFilaItem("Descripción") = FilaArticulo("NOMBRE")
                NuevaFilaItem("Requisición") = DBNull.Value
                NuevaFilaItem("Item RQ") = DBNull.Value
                NuevaFilaItem("Und") = FilaArticulo("UND")
                NuevaFilaItem("Orden Compra") = DBNull.Value
                NuevaFilaItem("Item OC") = DBNull.Value

                NuevaFilaItem("Cant") = 1

                NuevaFilaItem("Existencia") = Replace(FilaArticulo("EXISTENCIAS"), ".", ",")
                NuevaFilaItem("IDORDENCOMPRA") = DBNull.Value
                NuevaFilaItem("IDREQUISICION") = DBNull.Value
                NuevaFilaItem("IDREMISION") = DBNull.Value
                NuevaFilaItem("IDSALIDAALMACEN") = -1
                dtItemSalidaAlmacen.Rows.Add(NuevaFilaItem)

                UbicarRegistros()
                ELiminarFilaVacia()
            Else
                ' no existe un artículo con este código
                MensajeError = "No se encontró un artículo con ese código"
                MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Articulo no Encontrado")
                moverEnfoque()
            End If
        Else
            Dim i As Integer = dtItemSalidaAlmacen.Select("Código=" + FrBuscarArtículo.IdArtículo.ToString)(0).Item("Item")
            Dim n As Integer = Dgv_item.Rows(i - 1).Cells(4).Value
            n = n + 1
            Dgv_item.Rows(i - 1).Cells(4).Value = n
            ELiminarFilallena()
            ELiminarFilaVacia()

            moverEnfoque()

        End If
    End Sub


    Private Function ValidarItems(ByVal IdArticulo As Integer) As Boolean
        Dim filas As DataRow()
        filas = dtItemSalidaAlmacen.Select("Código=" + IdArticulo.ToString)
        If filas.Length > 0 Then
            ValidarItems = False
            Exit Function
        End If
        ValidarItems = True
    End Function


    Private Sub Bt_AsociarRq_Click(sender As System.Object, e As System.EventArgs) Handles Bt_AsociarRq.Click
        Dim dt_ItemsRqPendientes As New DataTable
        dt_ItemsRqPendientes = CargarRequisicionesPendientesXTraslado(2, Cb_AsociarRq.SelectedValue, Cb_AsociarRq.SelectedValue)

        For i = 0 To dt_ItemsRqPendientes.Rows.Count - 1
            Dim FilaItemRQ As DataRow
            FilaItemRQ = dt_ItemsRqPendientes.Rows(i)
            Dim FilaNueva As DataRow
            FilaNueva = dtItemSalidaAlmacen.NewRow
            FilaNueva("Item") = dtItemSalidaAlmacen.Rows.Count + 1
            FilaNueva("Código") = FilaItemRQ("Código")
            FilaNueva("Descripción") = FilaItemRQ("Descripción")
            FilaNueva("Requisición") = Trim(FilaItemRQ("Requisición"))
            FilaNueva("Item RQ") = FilaItemRQ("Item RQ")
            FilaNueva("Und") = FilaItemRQ("Und")
            FilaNueva("Cant") = Replace(FilaItemRQ("Cant"), ".", ",")
            FilaNueva("Existencia") = Replace(FilaItemRQ("EXISTENCIA"), ".", ",")
            FilaNueva("IDREQUISICION") = FilaItemRQ("IDREQUISICION")
            FilaNueva("Orden Compra") = DBNull.Value
            FilaNueva("IDORDENCOMPRA") = DBNull.Value
            FilaNueva("Item OC") = DBNull.Value
            FilaNueva("ValidarCant") = FilaItemRQ("ValidarCant")
            FilaNueva("IDSALIDAALMACEN") = -1
            dtItemSalidaAlmacen.Rows.Add(FilaNueva)
        Next

        Me.Cu_CentroCosto1.IdCentroCosto = dt_ItemsRqPendientes.Rows(0).Item("IDCENTROCOSTO")
        Me.Cu_CentroCosto1.CargarCentro()

        'Creo la tabla de articulos a verificar si son activos fijos
        Dim _TABLA_BUSCARARTEQ As New DataTable
        _TABLA_BUSCARARTEQ.Columns.Add("IDEQUIPO")
        For i = 0 To (Dgv_item.Rows.Count - 2)
            Dim fila As DataRow
            fila = _TABLA_BUSCARARTEQ.NewRow
            fila("IDEQUIPO") = dtItemSalidaAlmacen.Rows(i).Item("Código")
            _TABLA_BUSCARARTEQ.Rows.Add(fila)
        Next

        'Verifico si los articulos no son activos fijos para desactivar el Cbx_VerificacionEquipos
        Dim dsEquiposBuscar As DataSet
        dsEquiposBuscar = bddatos.ModificarEntradasSalidas(25, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, Date.Now, 0, Date.Now, "", 0, 0, _TABLA_BUSCARARTEQ)
        If dsEquiposBuscar.Tables(0).Rows(0).Item(0) = 0 Then
            Me.Cbx_VerificacionEquipos.Checked = False
        End If

        Me.Cb_AsociarRq.Enabled = False
        Me.Bt_AsociarRq.Enabled = False
        Me.Cb_OrdenCompra.Enabled = False
        Me.Bt_AgregarOC.Enabled = False
        Me.Cb_TipoSalida.Enabled = False
        Me.Cb_Relación.Enabled = False
        Me.Tx_lectora.Enabled = False
    End Sub


    Private Sub Bt_AgregarOC_Click(sender As System.Object, e As System.EventArgs) Handles Bt_AgregarOC.Click
        Me.Dgv_item.Columns.Item(1).ReadOnly = True

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.SA_ItemOrdenCompra(@IDORDENCOMPRA, @IDBODEGA) ORDER BY [Item OC]", conexion)
        comando.Parameters.AddWithValue("@IDORDENCOMPRA", Cb_OrdenCompra.SelectedValue)
        comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dtItemOrdenCompra)
            conexion.Close()
            For i = 0 To dtItemOrdenCompra.Rows.Count - 1
                Dim FilaItemOC As DataRow
                FilaItemOC = dtItemOrdenCompra.Rows(i)
                Dim filasarticulos As DataRow()
                filasarticulos = dtItemSalidaAlmacen.Select("Código=" + FilaItemOC("Código").ToString + " AND IDORDENCOMPRA=" + FilaItemOC("IDORDENCOMPRA").ToString)
                If filasarticulos.Length = 0 Then
                    Dim FilaNueva As DataRow
                    FilaNueva = dtItemSalidaAlmacen.NewRow
                    FilaNueva("Item") = dtItemSalidaAlmacen.Rows.Count + 1
                    FilaNueva("Código") = FilaItemOC("Código")
                    FilaNueva("Descripción") = FilaItemOC("Descripción")
                    FilaNueva("Requisición") = FilaItemOC("Requisición")
                    FilaNueva("Item RQ") = FilaItemOC("Item RQ")
                    FilaNueva("Und") = FilaItemOC("Und")
                    FilaNueva("Cant") = FilaItemOC("Cant")
                    FilaNueva("IDREQUISICION") = FilaItemOC("IDREQUISICION")
                    FilaNueva("Orden Compra") = FilaItemOC("Orden Compra")
                    FilaNueva("Existencia") = FilaItemOC("Existencia")
                    FilaNueva("IDORDENCOMPRA") = FilaItemOC("IDORDENCOMPRA")
                    FilaNueva("Item OC") = FilaItemOC("Item OC")
                    FilaNueva("IDSALIDAALMACEN") = -1
                    dtItemSalidaAlmacen.Rows.Add(FilaNueva)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try

        Me.Cb_AsociarRq.Enabled = False
        Me.Bt_AsociarRq.Enabled = False
        Me.Cb_OrdenCompra.Enabled = False
        Me.Bt_AgregarOC.Enabled = False
        Me.Cb_TipoSalida.Enabled = False
        Me.Cb_Relación.Enabled = False
        Me.Tx_lectora.Enabled = False
    End Sub


    Private Sub BloquearCajas()
        Select Case Me.Cb_TipoSalida.SelectedValue
            Case "I" ' Ajuste de inventario
            Case "R" ' Requisición
            Case "A" ' Alquiler
            Case "C" ' Consumo
            Case "T" ' Traslado de Bodega
                If Dgv_item.RowCount > 1 Then
                    Me.Cb_AsociarRq.Enabled = False
                    Me.Bt_AsociarRq.Enabled = False
                    Me.Cb_OrdenCompra.Enabled = False
                    Me.Bt_AgregarOC.Enabled = False
                    Me.Cb_TipoSalida.Enabled = False
                Else
                    Me.Cb_AsociarRq.Enabled = True
                    Me.Bt_AsociarRq.Enabled = True
                    Me.Cb_OrdenCompra.Enabled = True
                    Me.Bt_AgregarOC.Enabled = True
                    Me.Cb_TipoSalida.Enabled = True
                End If
            Case "D" ' Dotación
            Case "S" ' Custodia de Equipo
            Case "H" ' Custodia Herramienta
        End Select
    End Sub


    Private Sub ELiminarFilaVacia()
        Try
            For i = 0 To Dgv_item.Rows.Count - 2
                If IsDBNull(Me.Dgv_item.Rows(i).Cells("DescripciónDataGridViewTextBoxColumn").Value) = True Then
                    Me.Dgv_item.Rows.RemoveAt(i)

                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub ELiminarFilallena()
        Try
            Index_Registro_Actual = Dgv_item.CurrentRow.Index
            If IsDBNull(Me.Dgv_item.Rows(Index_Registro_Actual).Cells("DescripciónDataGridViewTextBoxColumn").Value) = False Then
                Me.Dgv_item.Rows.RemoveAt(Index_Registro_Actual)

                Try
                    dtItemSalidaAlmacen.AcceptChanges()
                Catch ex As Exception
                End Try

                For x As Integer = Dgv_item.CurrentCell.RowIndex To dtItemSalidaAlmacen.Rows.Count - 1
                    If IsDBNull(dtItemSalidaAlmacen(x).Item("Item")) = False Then
                        dtItemSalidaAlmacen(x).Item("Item") = x + 1
                    End If
                Next

            End If

        Catch
        End Try
    End Sub


    Private Sub Ll_ActualizarContacto_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_ActualizarContacto.LinkClicked
        If MsgBox("¿Desea ver o actualizar los contactos asociados al documento?", MsgBoxStyle.YesNo, "Ver o Actualizar Contactos") = MsgBoxResult.Yes Then
            If Me.Cu_BuscarPersonaDespacha.Cb_Persona.SelectedIndex <> -1 And
                Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedIndex <> -1 And
                Me.Cu_BuscarPersonaRecibe.Cb_Persona.SelectedIndex <> -1 Then
                Dim FrActualizarContacto As New FormulariosClasesBase.Fr_ActualizarContacto
                FrActualizarContacto.Bt_Aceptar.Enabled = Me.Bt_GuardarSalida.Enabled
                FrActualizarContacto.Cu_Contacto1.IDPERSONA = Me.Cu_BuscarPersonaDespacha.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto1.Gb_Contacto.Text = "Despacha: " + Me.Cu_BuscarPersonaDespacha.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto2.IDPERSONA = Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto2.Gb_Contacto.Text = "Autoriza: " + Me.Cu_BuscarPersonaAutoriza.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto3.IDPERSONA = Me.Cu_BuscarPersonaRecibe.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto3.Gb_Contacto.Text = "Recibe: " + Me.Cu_BuscarPersonaRecibe.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto4.IDPERSONA = -1
                FrActualizarContacto.CargarDatos()
                FrActualizarContacto.ShowDialog()
            Else
                MsgBox("Debe seleccionar todas las personas que interactúan con el documento", MsgBoxStyle.Information, "Seleccionar todas las personas")
            End If
        End If
    End Sub



    Private Sub Dgv_item_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Dgv_item.CellBeginEdit
        Try

            If IsDBNull(Me.Dgv_item.Item(e.ColumnIndex, e.RowIndex).Value) = False Then
                ValorAnteriorEdiciónIDArticulo = Me.Dgv_item.Item(e.ColumnIndex, e.RowIndex).Value
            Else
                ValorAnteriorEdiciónIDArticulo = -1
            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Sub Bt_SeleccionarEquipos_Click(sender As System.Object, e As System.EventArgs) Handles Bt_SeleccionarEquipos.Click
        'If Copiatablaequiposfin.Rows.Count > 0 Then
        '    tablaequiposfin = Copiatablaequiposfin.Copy
        'End If

        'If Copiatablacomponentesfin.Rows.Count > 0 Then
        '    tablacomponentesfin = Copiatablacomponentesfin.Copy
        'End If

        If ValidarSalidaAlmacen(1) = True Then
            Dim tablaitemsReset As New DataTable
            tablaitemsReset = dtItemSalidaAlmacen.Clone() 'copio la estructura de la tabla en una nueva para desligar los datos
            tablaitemsReset = Dgv_item.DataSource.Copy() 'copio los datos en una nueva para desligar los datos

            Dim formtrasladar As New FormulariosActivosFijos.Fr_TrasladosEquipos
            ' ENVIAR UN DATATABLE CON LAS COLUMNAS
            '| CÓDIGO ARTÍCULO | DESCRIPCIÓN ARTÍCULO | CANTIDAD |
            Dim datostraslado As New DataTable
            datostraslado.Columns.Add("IDARTICULO")
            datostraslado.Columns.Add("DESCRIPCION")
            datostraslado.Columns.Add("CANTIDAD")

            Dim i As Integer
            For i = 0 To (Dgv_item.Rows.Count - 2)
                datostraslado.Rows.Add(Dgv_item.Rows(i).Cells("CódigoDataGridViewTextBoxColumn").Value, Dgv_item.Rows(i).Cells("DescripciónDataGridViewTextBoxColumn").Value, Dgv_item.Rows(i).Cells("CantDataGridViewTextBoxColumn").Value)
            Next

            formtrasladar.tablaarticulos = datostraslado
            formtrasladar.tablaequipos = tablaequipos
            formtrasladar.tablaequiposfin = tablaequiposfin
            formtrasladar.tablacomponentesfin = tablacomponentesfin
            formtrasladar.tablacomponentes = tablacomponentes
            formtrasladar.bodegadestino = Cb_Relación.SelectedValue

            ' ANTES DE ABRIR EL FORMULARIO REVISO SI LA TABLA DE COMPONENTES TIENE DATOS Y SE LOS QUITO ANTES DE MANDARLOS
            Dim j, existe As Integer
            If tablacomponentesfin.Rows.Count > 0 Then
                For i = 0 To tablacomponentesfin.Rows.Count - 1
                    existe = 0
                    For j = 0 To Dgv_item.RowCount - 1
                        If tablacomponentesfin.Rows(i)("IDARTICULO") = Dgv_item.Rows(j).Cells("CódigoDataGridViewTextBoxColumn").Value Then
                            ' restar una unidad
                            Dgv_item.Rows(j).Cells("CantDataGridViewTextBoxColumn").Value = Dgv_item.Rows(j).Cells("CantDataGridViewTextBoxColumn").Value - 1
                            If Dgv_item.Rows(j).Cells("CantDataGridViewTextBoxColumn").Value = 0 Then
                                Dgv_item.Rows.Remove(Dgv_item.Rows(j))
                                dtItemSalidaAlmacen.AcceptChanges()
                            End If
                            Exit For
                        End If
                    Next
                Next
            End If

            ' abrir formulario de traslados
            formtrasladar.AccionEquipos = EditarEquipos
            formtrasladar.IDSALIDAALMACENMODIFICANDO = IDSALIDAALMACENMODIFICANDO
            Dim guardar As Boolean = False

            formtrasladar.ShowDialog()
            guardar = formtrasladar.guardar
            If guardar = True Then
                validacionequipos = True
                edicionequipos = formtrasladar.EdicionEquipos
                tablaequiposfin = formtrasladar.tablaequiposfin
                tablacomponentesfin = formtrasladar.tablacomponentesfin
                ' nivelar componentes, los equipos no deben ser nivelador porque estos ya vienen fijos de cuando se abre el formulario
                If tablacomponentesfin.Rows.Count > 0 Then
                    For i = 0 To tablacomponentesfin.Rows.Count - 1
                        existe = 0
                        For j = 0 To Dgv_item.RowCount - 1
                            If tablacomponentesfin.Rows(i)("IDARTICULO") = Dgv_item.Rows(j).Cells("CódigoDataGridViewTextBoxColumn").Value Then
                                ' sumar una unidad
                                Dgv_item.Rows(j).Cells("CantDataGridViewTextBoxColumn").Value = Dgv_item.Rows(j).Cells("CantDataGridViewTextBoxColumn").Value + 1
                                existe = 1
                                Exit For
                            End If
                        Next
                        If existe = 0 Then
                            ' agregar el artículo
                            AgregarArticulo(tablacomponentesfin.Rows(i)("IDARTICULO"))
                        End If
                    Next
                End If
                validacionequipos = True
            Else
                ' regreso el DataSet de los ítems a un estado anterior
                dtItemSalidaAlmacen.Clear()
                For k = 0 To tablaitemsReset.Rows.Count - 1
                    Dim fila1 As DataRow
                    fila1 = tablaitemsReset.Rows(k)
                    Dim Fila As DataRow
                    Fila = dtItemSalidaAlmacen.NewRow
                    For l = 0 To tablaitemsReset.Columns.Count - 1
                        Fila(l) = fila1(l)
                    Next
                    dtItemSalidaAlmacen.Rows.Add(Fila)
                Next
            End If
        End If
    End Sub


    Private Sub Dgv_item_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_item.CellValueChanged
        'si se edita la celda se vuelve a cambiar el valor de verificación de equipos a falso
        If Cb_TipoSalida.SelectedValue = "T" Then
            validacionequipos = False
        End If
    End Sub


    Private Sub LimpiarTablas()
        tablaequipos.Rows.Clear()
        tablacomponentes.Rows.Clear()
        tablacomponentesfin.Rows.Clear()
        tablaequiposfin.Rows.Clear()
        validacionequipos = False
    End Sub


    Public Sub AgregarArticulo(ByVal IDARTICULO As Integer)
        'Validar Artículo
        If ValidarItem(IDARTICULO) = True Then
            Dim FilasArticulos As DataRow()

            articulos = New DataTable("ListarArticulos_1")
            Dim Cadena_Consulta As String =
                "SELECT * FROM " + _
                " dbo.DatosArticuloxBodega(" & IDARTICULO & "," & VariablesBase.VariablesBase.IdBodegaActual & ") AS ListarArticulos_1"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Adaptador.FillSchema(articulos, SchemaType.Source)
            Adaptador.Fill(articulos)
            Consulta.Connection.Close()
            FilasArticulos = articulos.Select("ID=" + IDARTICULO.ToString)
            If FilasArticulos.Length > 0 Then

                Dim FilaArticulo As DataRow
                FilaArticulo = FilasArticulos(0)
                Dim FilaNueva As DataRow
                FilaNueva = dtItemSalidaAlmacen.NewRow
                FilaNueva("Item") = dtItemSalidaAlmacen.Rows.Count + 1
                FilaNueva("Código") = IDARTICULO
                FilaNueva("Descripción") = FilaArticulo("NOMBRE")
                FilaNueva("Requisición") = DBNull.Value
                FilaNueva("Item RQ") = DBNull.Value
                FilaNueva("Und") = FilaArticulo("UND")
                FilaNueva("Cant") = 1
                FilaNueva("Existencia") = Replace(FilaArticulo("EXISTENCIAS"), ".", ",")
                FilaNueva("IDREQUISICION") = DBNull.Value
                FilaNueva("IDSALIDAALMACEN") = -1

                dtItemSalidaAlmacen.Rows.Add(FilaNueva)

                'Dim filaultima As Integer = dtItemSalidaAlmacen.Rows.Count - 1
                'dtItemSalidaAlmacen(filaultima).Item("Código") = FilaNueva("Código")
                'dtItemSalidaAlmacen(filaultima).Item("Descripción") = FilaNueva("Descripción")
                'If IsDBNull(FilaNueva("Requisición")) = False Then
                '    dtItemSalidaAlmacen(filaultima).Item("Requisición") = FilaNueva("Requisición")
                'End If
                'If IsDBNull(FilaNueva("Item RQ")) = False Then
                '    dtItemSalidaAlmacen(filaultima).Item("Item_RQ") = FilaNueva("Item RQ")
                'End If
                'If IsDBNull(FilaNueva("IDREQUISICION")) = False Then
                '    dtItemSalidaAlmacen(filaultima).Item("IDREQUISICION") = FilaNueva("IDREQUISICION")
                'End If
                'dtItemSalidaAlmacen(filaultima).Item("Und") = FilaNueva("Und")
                'dtItemSalidaAlmacen(filaultima).Item("Cant") = FilaNueva("Cant")
                'dtItemSalidaAlmacen(filaultima).Item("Existencia") = FilaNueva("Existencia")
            End If
        End If
    End Sub


    Private Sub Cbx_VerificacionEquipos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Cbx_VerificacionEquipos.CheckedChanged
        If Cbx_VerificacionEquipos.Checked = True Then
            Bt_SeleccionarEquipos.Enabled = True
            'If Copiatablaequiposfin.Rows.Count > 0 Then
            '    tablaequiposfin = Copiatablaequiposfin.Copy
            'End If

            'If Copiatablacomponentesfin.Rows.Count > 0 Then
            '    tablacomponentesfin = Copiatablacomponentesfin.Copy
            'End If
        Else
            Bt_SeleccionarEquipos.Enabled = False
            'Copiatablaequiposfin = tablaequiposfin.Copy
            'Copiatablacomponentesfin = tablacomponentesfin.Copy
            'tablaequiposfin.Clear()
            'tablacomponentesfin.Clear()
        End If
    End Sub


    Private Sub Tx_PlacaVehiculo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_PlacaVehiculo.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
        Dim regex As New System.Text.RegularExpressions.Regex("[A-Z0-9]")
        If Not (regex.IsMatch(e.KeyChar) Or e.KeyChar = Convert.ToChar(Keys.Back)) Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub


    Public Shared Function CargarPlacasVehiculos() As String
        Dim Fr_PlacaVehiculo As New Form
        Dim Pn_Busqueda As New Panel
        Dim Lb_CodigoBusqueda As New Label
        Dim Lb_PlacaBusqueda As New Label
        Dim Tx_CodigoBusqueda As New TextBox
        Dim Tx_PlacaBusqueda As New TextBox
        Dim Flp_Botones As New FlowLayoutPanel
        Dim Bt_Aceptar As New Button
        Dim Bt_Cancelar As New Button
        Dim Dgv_PlacaVehiculo As New DataGridView
        Dim Dt_Placas As New DataTable
        Dim Dv_Filtro As New DataView
        Dim Tm_Buscar As New Timer

        With Lb_CodigoBusqueda
            .AutoSize = True
            .Location = New Point(10, 16)
            .Text = "Código de ISMOCOL:"
        End With
        With Tx_CodigoBusqueda
            .Location = New Point(120, 16)
            .MaxLength = 17
            .Width = 120
        End With
        With Lb_PlacaBusqueda
            .AutoSize = True
            .Location = New Point(16, 40)
            .Text = "Placa del vehículo:"
        End With
        With Tx_PlacaBusqueda
            .Location = New Point(120, 40)
            .MaxLength = 7
            .Width = 70
        End With
        With Pn_Busqueda
            .Dock = DockStyle.Top
            .Height = 70
            .Controls.Add(Lb_CodigoBusqueda)
            .Controls.Add(Lb_PlacaBusqueda)
            .Controls.Add(Tx_CodigoBusqueda)
            .Controls.Add(Tx_PlacaBusqueda)
        End With
        With Dgv_PlacaVehiculo
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
            .Dock = DockStyle.Fill
            .MultiSelect = False
            .ReadOnly = True
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        With Bt_Aceptar
            .AutoSize = True
            .Text = "Aceptar"
        End With
        With Bt_Cancelar
            .AutoSize = True
            .Text = "Cancelar"
        End With
        With Flp_Botones
            .Dock = DockStyle.Bottom
            .FlowDirection = FlowDirection.RightToLeft
            .Height = 40
            .Padding = New Padding(0, 7, 3, 3)
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
        End With
        With Fr_PlacaVehiculo
            .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            .AutoSize = True
            .AcceptButton = Bt_Aceptar
            .CancelButton = Bt_Cancelar
            .StartPosition = FormStartPosition.CenterParent
            .MaximizeBox = False
            .MinimizeBox = False
            .MinimumSize = New Size(400, 600)
            .Text = "Elegir Placa de Vehículo"
            .Controls.Add(Dgv_PlacaVehiculo)
            .Controls.Add(Pn_Busqueda)
            .Controls.Add(Flp_Botones)
        End With
        AddHandler Tx_CodigoBusqueda.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                                   e.KeyChar = Char.ToUpper(e.KeyChar)
                                                   Dim regex As New System.Text.RegularExpressions.Regex("[A-Z0-9-]")
                                                   If Not (regex.IsMatch(e.KeyChar) Or e.KeyChar = Convert.ToChar(Keys.Back)) Then
                                                       e.Handled = True
                                                       e.KeyChar = CChar("")
                                                   End If
                                               End Sub
        AddHandler Tx_PlacaBusqueda.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                                  e.KeyChar = Char.ToUpper(e.KeyChar)
                                                  Dim regex As New System.Text.RegularExpressions.Regex("[A-Z0-9]")
                                                  If Not (regex.IsMatch(e.KeyChar) Or e.KeyChar = Convert.ToChar(Keys.Back)) Then
                                                      e.Handled = True
                                                      e.KeyChar = CChar("")
                                                  End If
                                              End Sub
        AddHandler Tx_CodigoBusqueda.TextChanged, Sub(sender As System.Object, e As System.EventArgs)
                                                      Tm_Buscar.Stop()
                                                      Tm_Buscar.Interval = VariablesBase.VariablesBase.TiempoRespuestaBuscador * 2
                                                      Tm_Buscar.Start()
                                                  End Sub
        AddHandler Tx_PlacaBusqueda.TextChanged, Sub(sender As System.Object, e As System.EventArgs)
                                                     Tm_Buscar.Stop()
                                                     Tm_Buscar.Interval = VariablesBase.VariablesBase.TiempoRespuestaBuscador * 2
                                                     Tm_Buscar.Start()
                                                 End Sub
        AddHandler Tm_Buscar.Tick, Sub(sender As System.Object, e As System.EventArgs)
                                       Tm_Buscar.Stop()
                                       Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
                                       Dim vista As New DataView(Dt_Placas)
                                       Dgv_PlacaVehiculo.SuspendLayout()
                                       Dgv_PlacaVehiculo.DataSource = vista
                                       Dgv_PlacaVehiculo.ResumeLayout()
                                       vista.RowFilter = String.Format("CODIGO like '%{0}%' and PLACAVEHICULO like '%{1}%'", Tx_CodigoBusqueda.Text, Tx_PlacaBusqueda.Text)
                                       Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                                   End Sub
        AddHandler Bt_Aceptar.Click, Sub()
                                         CargarPlacasVehiculos = Dgv_PlacaVehiculo.SelectedRows(0).Cells("PLACAVEHICULO").Value
                                         Fr_PlacaVehiculo.DialogResult = DialogResult.OK
                                         Fr_PlacaVehiculo.Close()
                                     End Sub
        AddHandler Bt_Cancelar.Click, Sub()
                                          'CargarPlacasVehiculos = Nothing 'Dejar el valor de la placa anterior.
                                          Fr_PlacaVehiculo.DialogResult = DialogResult.Cancel
                                          Fr_PlacaVehiculo.Close()
                                      End Sub
        AddHandler Dgv_PlacaVehiculo.CellDoubleClick, Sub()
                                                          CargarPlacasVehiculos = Dgv_PlacaVehiculo.SelectedRows(0).Cells("PLACAVEHICULO").Value
                                                          Fr_PlacaVehiculo.DialogResult = DialogResult.OK
                                                          Fr_PlacaVehiculo.Close()
                                                      End Sub
        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("SELECT * FROM dbo.ListarPlacaVehiculos() ORDER BY CODIGO", conn)
        Dim da As New SqlDataAdapter(Comando)
        Try
            conn.Open()
            da.Fill(Dt_Placas)
            conn.Close()
            Dgv_PlacaVehiculo.DataSource = Dt_Placas
            Fr_PlacaVehiculo.ShowDialog()
        Finally
            conn.Close()
        End Try
    End Function


    Private Sub Bt_BuscarPlaca_Click(sender As Object, e As EventArgs) Handles Bt_BuscarPlaca.Click
        Dim placa As String = CargarPlacasVehiculos()
        If placa <> "" Then
            Tx_PlacaVehiculo.Text = placa
        End If
    End Sub


    Private Sub Bt_GestionarActividades_Click(sender As Object, e As EventArgs) Handles Bt_GestionarActividades.Click
        If Editando = False Then
            Dim dr As New DialogResult
            Using frGestionarActividades As New FormulariosClasesBase.Fr_GestionarActividadPrincipal
                dr = frGestionarActividades.ShowDialog()
            End Using
            If dr <> Windows.Forms.DialogResult.Cancel Then
                CargarActividades()
            End If
        End If
    End Sub


    Private Sub CargarActividades()
        Dim dt_Actividades As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("GestionarActividadPrincipal", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TablaActividadesPrincipales", Nothing)
        comando.Parameters.AddWithValue("@ACCION", 2)
        comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        comando.Parameters.AddWithValue("@NOMBREACTIVIDADPRINCIPAL", "")
        Dim msgParam As New SqlParameter("@ACTIVIDADPRINCIPAL", DbType.Int32)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dt_Actividades)
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
        Me.Cb_Actividad.DataSource = dt_Actividades
        Me.Cb_Actividad.DisplayMember = "ACTIVIDAD"
        Me.Cb_Actividad.ValueMember = "IDACTIVIDADPRINCIPAL"
    End Sub

    Private Function EsBodegaCMCoPrincipalIsmocol() As Boolean
        'SELECT dbo.EsBodegaCMCoPrincipalIsmocol(@IDBODEGA)
        Return True
    End Function

    Private Sub Tx_lectora_GotFocus(sender As Object, e As EventArgs) Handles Tx_lectora.GotFocus
        Tx_lectora.BackColor = Color.DarkOrange
    End Sub

    Private Sub Tx_lectora_LostFocus(sender As Object, e As EventArgs) Handles Tx_lectora.LostFocus
        Tx_lectora.BackColor = SystemColors.Window
    End Sub

    Private Sub Tx_lectora_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_lectora.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Try
                    Dim IdArticuloLEctor As String = Me.Tx_lectora.Text
                    Dim filas() As DataRow
                    filas = Me.dtItemSalidaAlmacen.Select("Código=" + IdArticuloLEctor)
                    If filas.Length > 0 Then ' ya existe el id articulo en la lista
                        Dim fila As DataRow
                        fila = filas(0)
                        fila("Cant") = fila("Cant") + 1
                    Else 'no existe agregar
                        AgregarArticulo(IdArticuloLEctor)
                    End If
                    Tx_lectora.Clear()
                    Tx_lectora.Focus()
                    dtItemSalidaAlmacen.AcceptChanges()
                    Me.Cb_TipoSalida.Enabled = False
                Catch ex As Exception
                    System.Media.SystemSounds.Exclamation.Play()
                Finally
                    e.SuppressKeyPress = True
                    Tx_lectora.Clear()
                    Tx_lectora.Focus()
                End Try
        End Select

    End Sub

    Private Sub agregararticulo(ByVal IDARTICULO As String)
        Dim FilasArticulos As DataRow()
        articulos = New DataTable("ListarArticulos_1")
        Dim Cadena_Consulta As String =
            "SELECT * FROM " + _
            " dbo.DatosArticuloxBodega(" & IDARTICULO & "," & VariablesBase.VariablesBase.IdBodegaActual & ") AS ListarArticulos_1"
        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Adaptador.FillSchema(articulos, SchemaType.Source)
        Adaptador.Fill(articulos)
        Consulta.Connection.Close()
        FilasArticulos = articulos.Select("ID=" + IDARTICULO.ToString)
        If FilasArticulos.Length > 0 Then
            Dim FilaArticulo As DataRow
            FilaArticulo = FilasArticulos(0)
            Dim FilaNueva As DataRow
            FilaNueva = dtItemSalidaAlmacen.NewRow
            FilaNueva("Item") = dtItemSalidaAlmacen.Rows.Count + 1
            FilaNueva("Código") = IDARTICULO
            FilaNueva("Descripción") = FilaArticulo("NOMBRE")
            FilaNueva("Requisición") = DBNull.Value
            FilaNueva("Item RQ") = DBNull.Value
            FilaNueva("Und") = FilaArticulo("UND")
            FilaNueva("Cant") = 1
            FilaNueva("Existencia") = Replace(FilaArticulo("EXISTENCIAS"), ".", ",")
            FilaNueva("IDREQUISICION") = DBNull.Value
            FilaNueva("IDSALIDAALMACEN") = -1
            dtItemSalidaAlmacen.Rows.Add(FilaNueva)
        End If
    End Sub

    Private Sub Dgv_item_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles Dgv_item.CellValidating
        Dim nNumero As Integer
        Dim oDGVC As DataGridViewColumn = Me.Dgv_item.Columns(e.ColumnIndex)

        If oDGVC.DataPropertyName = "Código" Then
            If e.FormattedValue.ToString().Length > 0 Then
                If Not Integer.TryParse(e.FormattedValue, nNumero) Then
                    MessageBox.Show("Sólo se permiten números")
                    e.Cancel = True
                End If
            End If
        End If

    End Sub
End Class 'Fr_SalidaAlmacen