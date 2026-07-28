Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Net.Mail

Public Class Fr_EntradaAlmacen

    Public Editando As Boolean = False
    Public IDENTRADAALMACEN As Integer
    Public IDENTRADAALMACENMODIFICANDO As Integer = -1
    Public EditarEquipos As String = "NUEVO" 'NUEVO, VER, EDITAR"
    Public validacionequipos As Boolean = False
    Public tablaequipos As New DataTable
    Public tablaequiposfin As New DataTable
    Public tablacomponentes As New DataTable
    Public tablacomponentesfin As New DataTable
    Public nuevosequipos As Boolean = True
    Public edicionequipos As Boolean = False
    Public equiposborrados As Boolean = False
    Public pivoteSeleccionarEquipos As Boolean = False 'se usa para que no limpie las tablas cuando se extraen los componentes

    Dim DsEntradaAlmacén As New DatosEntradaAlmacén.Ds_EntradaAlmacén
    Dim Estilo_Celda_Error As New DataGridViewCellStyle
    Dim Estilo_Celda As New DataGridViewCellStyle
    Dim guardado As Boolean
    Dim MensajeError As String
    Dim familia As Integer = -1
    Dim articulos As New DataTable("ListarArticulos")
    Dim ARTICULOTableAdapter As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.ARTICULOTableAdapter
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos
    Dim TempBodega As Integer
    Dim ValorAnteriorEdiciónIDArticulo As Integer
    Dim Agregarautomaticamente As Boolean = False
    Private bddatos1 As New FuncionesBase.ClaseCargarMaestras

    Dim LISTAITEMENTRADAALMACEN As DataTable

    Dim Index_Registro_Actual As Integer

    Public Sub New()
        InitializeComponent()
        AddHandler Cb_Relación.KeyDown, AddressOf FuncionesBase.FuncionesBase.ComboBoxAutocompletar_KeyDown
    End Sub

    Dim dsCargar As New DataSet
    Public Sub CargarDatos()

        Dim identificador As Long
        Dim tipo As Integer

        If IDENTRADAALMACENMODIFICANDO <= 0 Then
            identificador = IDENTRADAALMACEN
            tipo = 1 'Crear
        Else
            identificador = IDENTRADAALMACENMODIFICANDO
            tipo = 2 'Editar
        End If

        dsCargar = bddatos1.CargarMaestrasMateriales(2, VariablesBase.VariablesBase.IdBodegaActual, identificador, tipo)

        Dtp_FechaRecibido.MaxDate = Date.Now
        Dtp_FechaRemisión.MaxDate = Date.Now
        guardado = False

        'Dim dtTipoEntrada As New DataTable
        'dtTipoEntrada.Columns.Add("CODIGO")
        'dtTipoEntrada.Columns.Add("NOMBRE")

        'dtTipoEntrada.Rows.Add("V", "Inventario Inicial")
        'If EditarEquipos = "VER" Or EditarEquipos = "EDITAR" Then
        '    dtTipoEntrada.Rows.Add("I", "Ajuste de inventario")
        'Else
        '    If VariablesBase.VariablesBase.TipoUsuario = 0 Or VariablesBase.VariablesBase.TipoUsuario = 16 Or
        '       VariablesBase.VariablesBase.TipoUsuario = 15 Then
        '        dtTipoEntrada.Rows.Add("I", "Ajuste de inventario")
        '    End If
        'End If
        'dtTipoEntrada.Rows.Add("A", "Alquiler")
        'dtTipoEntrada.Rows.Add("C", "Orden de Compra")
        'dtTipoEntrada.Rows.Add("D", "Devolución a Bodega")
        'dtTipoEntrada.Rows.Add("H", "Devolución Herramienta")
        'dtTipoEntrada.Rows.Add("S", "Retorno de Custodia")
        'dtTipoEntrada.Rows.Add("T", "Traslado de Bodega")

        Me.Cb_TipoEntrada.DataSource = Me.dsCargar.Tables(2)
        Me.Cb_TipoEntrada.DisplayMember = "NOMBRE"
        Me.Cb_TipoEntrada.ValueMember = "CODIGO"

        If Editando = False Then
            Me.Cu_BPRecibio.CargarDatos()
            Me.Cu_BpAprobo.CargarDatos()
            Me.Cu_BpVerifico.CargarDatos()
            Me.Cu_BpEntregaABodega.CargarDatos()

            Cu_BpAprobo.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "EA", "APROBO", -1)
            Cu_BpVerifico.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "EA", "AUTORIZA", -1)
            Cu_BPRecibio.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "EA", "RECIBE", -1)
        End If

        Comportamiento_Predeterminado()

        LISTAITEMENTRADAALMACEN = Me.dsCargar.Tables(1)

        'Dim ada As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.LISTAITEMENTRADAALMACENTableAdapter
        'ada.FillIDENTRADAALMACEN(Me.DsEntradaAlmacén.LISTAITEMENTRADAALMACEN, IDENTRADAALMACENMODIFICANDO)
        Me.Dgv_item.DataSource = LISTAITEMENTRADAALMACEN



        If Editando = True Then
            CargarEntradaAlmacen()
            Bt_Agregar.Enabled = False
        End If

        'DATOS APRA TRASLADOS DE EQUIPOS

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

        If EditarEquipos = "VER" Or EditarEquipos = "EDITAR" Then
            If Cb_TipoEntrada.SelectedValue = "T" Or Cb_TipoEntrada.SelectedValue = "S" Then
                If EditarEquipos = "VER" Then
                    Dgv_item.ReadOnly = True
                End If
                Bt_SeleccionarEquipos.Enabled = True
                ' revisar si esta salida posee ítems y de ser así se debe llenar una tabla con los equipos y una con los componentes
                Dim dscargarequipos As New DataSet
                Select Case Cb_TipoEntrada.SelectedValue
                    Case "T" ' para traslados revisar los equipos que pertenecen a una salida en la tabla CAF_ENTRADASSALIDASBODEGA
                        dscargarequipos = bddatos.ModificarEntradasSalidas(16, 0, 0, 0, Date.Now, 0, Date.Now, "", 0, IDENTRADAALMACENMODIFICANDO, )
                    Case "S" ' para custodias revisar los equipos que pertenecen a una salida en la tabla CAF_CUSTODIAS
                        dscargarequipos = bddatos.ModificarCustodias(8, 0, 0, 0, 0, 0, IDENTRADAALMACENMODIFICANDO)
                End Select

                ' si existen ítems llenar las tablas, si no, deshabilitar el botón "Ver Equipos" porque no hay nada.
                If dscargarequipos.Tables(0).Rows.Count > 0 Then
                    ' EDICIÓN PARA QUE NO SE PUEDAN MODIFICAR LAS ENTRADAS DE ALMACÉN QUE YA TIENEN EQUIPOS REGISTRADOS.
                    ' QUITAR SI SE CAMBIA DE OPINIÓN.
                    If EditarEquipos = "EDITAR" Then
                        Dgv_item.ReadOnly = True
                        MsgBox("No se pueden editar Entradas de Almacén que tengan equipos ya ingresados.")
                        EditarEquipos = "VER"
                        Bt_Guardar.Enabled = False
                    End If

                    validacionequipos = True
                    tablaequiposfin = dscargarequipos.Tables(0)
                    If dscargarequipos.Tables(1).Rows.Count > 0 Then
                        tablacomponentesfin = dscargarequipos.Tables(1)
                    End If
                Else
                    Bt_SeleccionarEquipos.Enabled = False
                    Cbx_VerificacionEquipos.Checked = False
                End If
                Cbx_VerificacionEquipos.Enabled = False
            Else
                Bt_SeleccionarEquipos.Enabled = False
            End If
            Me.Cb_TipoEntrada.Enabled = False
            Me.Cb_Relación.Enabled = False
        End If

    End Sub

    Public Sub CargarEntradaAlmacen()

        'Dim ada As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.ENTRADAALMACENTableAdapter
        'ada.FillIDENTRADAALMACEN(Me.DsEntradaAlmacén.ENTRADAALMACEN, IDENTRADAALMACENMODIFICANDO)
        Dim fila As DataRow
        'fila = Me.DsEntradaAlmacén.ENTRADAALMACEN.Rows(0)
        fila = Me.dsCargar.Tables(0).Rows(0)
        Me.Cb_TipoEntrada.SelectedValue = fila("TIPOENTRADAALMACEN")
        Me.Tx_Remisión.Text = IIf(IsDBNull(fila("NROREMISION")) = True, "", fila("NROREMISION"))
        If IsDBNull(fila("FECHAREMISION")) = False Then
            Me.Dtp_FechaRemisión.Value = fila("FECHAREMISION")
            Me.Dtp_FechaRemisión.Checked = True
        End If
        If IsDBNull(fila("FECHARECIBIDO")) = False Then
            Me.Dtp_FechaRecibido.Value = fila("FECHARECIBIDO")
            Me.Dtp_FechaRecibido.Checked = True
        End If
        Me.Tx_Transportador.Text = Trim(fila("TRANSPORTADOR"))
        Me.Tx_Entrega.Text = Trim(fila("ENTREGA"))
        Me.Tx_Observacion_AI.Text = Trim(fila("OBSERVACION"))


        '******************************************
        'Necesario para poder cargar los usuarios de la bodega donde se digitó la orden de compra
        TempBodega = VariablesBase.VariablesBase.IdBodegaActual
        VariablesBase.VariablesBase.IdBodegaActual = fila("IDBODEGA")
        Me.Cu_BPRecibio.CargarDatos(fila("IDPERSONARECIBIO"))
        Me.Cu_BpAprobo.CargarDatos(fila("IDPERSONAAPROBO"))
        Me.Cu_BpVerifico.CargarDatos(fila("IDPERSONAVERIFICO"))
        If Not IsDBNull(fila("IDPERSONAENTREGAABODEGA")) Then
            Cu_BpEntregaABodega.CargarDatos(fila("IDPERSONAENTREGAABODEGA"))
        End If

        Cu_BPRecibio.Cb_Persona.SelectedValue = fila("IDPERSONARECIBIO")
        Cu_BpAprobo.Cb_Persona.SelectedValue = fila("IDPERSONAAPROBO")
        Cu_BpVerifico.Cb_Persona.SelectedValue = fila("IDPERSONAVERIFICO")
        If Not IsDBNull(fila("IDPERSONAENTREGAABODEGA")) Then
            Cu_BpEntregaABodega.Cb_Persona.SelectedValue = fila("IDPERSONAENTREGAABODEGA")
        End If

    End Sub

    Public Sub Comportamiento_Predeterminado()
        Me.Dgv_item.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_item.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Cu_APB_Recibido.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_APB_Recibido.Tag)
        Cu_APB_Verifica.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_APB_Verifica.Tag)
        Cu_APB_Aprueba.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_APB_Aprueba.Tag)
    End Sub

    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BpAprobo.Cb_Persona.SelectedValue
            Me.Cu_BpAprobo.CargarDatos()
            Me.Cu_BpAprobo.Cb_Persona.SelectedValue = temp
            Me.Cu_BpAprobo.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BPRecibio.Cb_Persona.SelectedValue
            Me.Cu_BPRecibio.CargarDatos()
            Me.Cu_BPRecibio.Cb_Persona.SelectedValue = temp
            Me.Cu_BPRecibio.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BpVerifico.Cb_Persona.SelectedValue
            Me.Cu_BpVerifico.CargarDatos()
            Me.Cu_BpVerifico.Cb_Persona.SelectedValue = temp
            Me.Cu_BpVerifico.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BpEntregaABodega.Cb_Persona.SelectedValue
            Me.Cu_BpEntregaABodega.CargarDatos()
            Me.Cu_BpEntregaABodega.Cb_Persona.SelectedValue = temp
            Me.Cu_BpEntregaABodega.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Select Case NOMBRECOMPONENTE
            Case Cu_BpAprobo.Name
                Me.Cu_BpAprobo.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BPRecibio.Name
                Me.Cu_BPRecibio.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BpVerifico.Name
                Me.Cu_BpVerifico.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BpEntregaABodega.Name
                Cu_BpEntregaABodega.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub

    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Me.Cu_BpAprobo.Name
                Try
                    filas = Cu_BpAprobo.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BpAprobo.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BpAprobo.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la bodega.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BpAprobo.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BPRecibio.Name
                Try
                    filas = Cu_BPRecibio.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BPRecibio.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BPRecibio.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la bodega.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BPRecibio.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BpVerifico.Name
                Try
                    filas = Cu_BpVerifico.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BpVerifico.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BpVerifico.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la bodega.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BpVerifico.Tx_TextoCódigo.Text = ""
                End Try
            Case Cu_BpEntregaABodega.Name
                Try
                    filas = Cu_BpEntregaABodega.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BpEntregaABodega.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_BpEntregaABodega.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la bodega.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_BpEntregaABodega.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub

    Private Sub Bt_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Guardar.Click
        If ValidarEntradaAlmacen() = True Then
            If Cbx_VerificacionEquipos.Checked = True Then
                'hago una revisión, si todos los ítems se van a entregar se cambia la variable de validación

                'verificar que los equipos sean correctos -- se borraron equipos --
                If validacionequipos = False Or equiposborrados = True Then
                    If tablaequiposfin.Rows.Count > 0 Then
                    Else
                        MsgBox("No ha seleccionado o faltan equipos por seleccionar, verifique que las cantidades coincidan en el botón SELECCIONAR / VER EQUIPOS", MsgBoxStyle.Critical, "EQUIPOS")
                        Bt_SeleccionarEquipos.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If Cbx_VerificacionEquipos.Checked = True Then
                If tablaequiposfin.Rows.Count > 0 Then
                    If MsgBox("Esta Entrada tiene Equipos asociados y NO SE PODRÁ EDITAR O CANCELAR después de guardada, ¿desea guardar la Entrada de Almacén?", MsgBoxStyle.YesNo, "CONFIRMACIÓN DE GUARDADO") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            GuardarEntradaAlmacen()
        End If
    End Sub

    Private Function ValidarEntradaAlmacen(Optional Tipo As Integer = 0) As Boolean
        ELiminarFilaVacia()

        If Cb_TipoEntrada.SelectedValue = "A" Or Cb_TipoEntrada.SelectedValue = "C" Then
            If Trim(Tx_Remisión.Text) = "" Then
                MsgBox("Ingrese la remisión", MsgBoxStyle.Critical, "Remisión")
                Tx_Remisión.Focus()
                ValidarEntradaAlmacen = False
                Exit Function
            End If
        End If

        If Dtp_FechaRecibido.Checked = False Then
            MsgBox("Debe especificar la fecha de recibido", MsgBoxStyle.Critical, "Fecha Recibido")
            Dtp_FechaRecibido.Focus()
            ValidarEntradaAlmacen = False
            Exit Function
        End If

        If FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Observacion_AI.Text).Length = 0 Then
            MsgBox("Debe agregar una observación", MsgBoxStyle.Critical, "Entrada Almacén")
            Tx_Observacion_AI.Focus()
            ValidarEntradaAlmacen = False
            Exit Function
        End If

        If Dgv_item.RowCount = 1 Then
            MsgBox("Debe agregar los ítems", MsgBoxStyle.Critical, "Ítems Entrada Almacén")
            ValidarEntradaAlmacen = False
            Exit Function
        End If

        If Me.LISTAITEMENTRADAALMACEN.Rows.Count = 0 Then
            MsgBox("Debe tener al menos un artículo", MsgBoxStyle.Critical, "Cantidad de artículos")
            Dgv_item.Focus()
            ValidarEntradaAlmacen = False
            Exit Function
        Else
            Dim valida As Boolean = True

            For i = 0 To Me.LISTAITEMENTRADAALMACEN.Rows.Count - 1
                Dim FilaDGVItem As DataRow
                FilaDGVItem = Me.LISTAITEMENTRADAALMACEN.Rows(i)
                Me.Dgv_item.Rows(i).ErrorText = ""
                Me.Dgv_item.Rows(i).DefaultCellStyle = Estilo_Celda
                If IsDBNull(FilaDGVItem("PENDIENTE")) = False Then
                    If FilaDGVItem("Cant") > FilaDGVItem("PENDIENTE") Then
                        Me.Dgv_item.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                        Me.Dgv_item.Rows(i).ErrorText = "La cantidad pendiente es " + FilaDGVItem("PENDIENTE").ToString
                        valida = False
                        Try
                            Me.Dgv_item.CurrentCell = Me.Dgv_item(0, i)
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If FilaDGVItem("Cant") <= 0 Then
                    Me.Dgv_item.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    Me.Dgv_item.Rows(i).ErrorText = "La cantidad debe ser mayor a 0"
                    valida = False
                    Try
                        Me.Dgv_item.CurrentCell = Me.Dgv_item(0, i)
                    Catch ex As Exception
                    End Try
                End If
                '' validacion ??
                If IsDBNull(Dgv_item.Item("Validar", i).Value) = False Then
                    If Dgv_item.Item("CantDataGridViewTextBoxColumn", i).Value > Dgv_item.Item("Validar", i).Value Then
                        Me.Dgv_item.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                        Me.Dgv_item.Rows(i).ErrorText = "La cantidad no puede ser superior"
                        valida = False
                        Try
                            Me.Dgv_item.CurrentCell = Me.Dgv_item(0, i)
                        Catch ex As Exception
                        End Try
                    End If
                End If
            Next
            If valida = False Then
                Dgv_item.Focus()
                ValidarEntradaAlmacen = False
                Exit Function
            End If
        End If

        If Me.Cu_BPRecibio.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la persona que recibió", MsgBoxStyle.Critical, "Persona que Recibió")
            Cu_BPRecibio.Cb_Persona.Focus()
            ValidarEntradaAlmacen = False
            Exit Function
        End If

        If Me.Cu_BpAprobo.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la persona que aprueba", MsgBoxStyle.Critical, "Persona que Aprueba")
            Cu_BpAprobo.Cb_Persona.Focus()
            ValidarEntradaAlmacen = False
            Exit Function
        End If

        If Me.Cu_BpVerifico.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la persona que verifica", MsgBoxStyle.Critical, "Persona que Verifica")
            Cu_BpVerifico.Cb_Persona.Focus()
            ValidarEntradaAlmacen = False
            Exit Function
        End If

        If Cb_TipoEntrada.SelectedValue = "D" Or Cb_TipoEntrada.SelectedValue = "H" Or Cb_TipoEntrada.SelectedValue = "S" Then
            If Cu_BpEntregaABodega.Cb_Persona.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la persona que entrega a bodega", MsgBoxStyle.Critical, "Persona que Entrega a Bodega")
                Cu_BpEntregaABodega.Cb_Persona.Focus()
                ValidarEntradaAlmacen = False
                Exit Function
            End If
        End If


        If Tipo = 0 Then
            If EditarEquipos = "NUEVO" Then
                If Cbx_VerificacionEquipos.Checked = True Then
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
                                CadenaEquipos += DtEquiposEstadoUso.Rows(i).Item("CODIGO").ToString
                            Next
                            MsgBox("No se puede realizar el movimiento de equipos que su estado de uso es diferente a 'OPERANDO'. Verificar el estado de uso de los siguientes equipos: " + CadenaEquipos, MsgBoxStyle.Critical, "Estado De Uso")
                            ValidarEntradaAlmacen = False
                            Exit Function
                        End If
                    End If
                End If
            End If
        End If

        ValidarEntradaAlmacen = True
    End Function

    Public Sub GuardarEntradaAlmacen()

        'validar que si en los item de entrada de almacen existen articulos con equipos asociados se debe revisar que la tabla de equipos tenga
        'los equipos y las cantidades correspondientes--- 

        Select Case Cb_TipoEntrada.SelectedValue
            Case "T", "S"
                Dim dsremisionValidarArticulos As New DataSet
                dsremisionValidarArticulos = CargarArticulos(Me.Cb_Relación.SelectedValue)

                'validar articulos 
                If Cb_TipoEntrada.SelectedValue = "T" Then
                    For i = 0 To Me.LISTAITEMENTRADAALMACEN.Rows.Count - 1
                        Dim valoritem As Double
                        Dim FilaDGVItem As DataRow
                        FilaDGVItem = Me.LISTAITEMENTRADAALMACEN.Rows(i)
                        Try
                            If LISTAITEMENTRADAALMACEN.Rows.Count > dsremisionValidarArticulos.Tables(0).Rows.Count Then
                                MsgBox("verificar si ya se realizo la entrada a bodega del item" + Str(i))
                            Else
                                If dsremisionValidarArticulos.Tables(0).Rows.Count > 0 Then
                                    valoritem = Convert.ToDouble(dsremisionValidarArticulos.Tables(0).Rows(i)("CANT").ToString())
                                End If
                            End If
                        Catch ex As Exception
                        End Try

                        If FilaDGVItem("Cant") > valoritem Then
                            Me.Dgv_item.Rows(i).ErrorText = " Cantidad Item de la remision no concuerdan, máximo permitido es: " + CStr(valoritem)
                            Exit Sub
                            Try
                                Me.Dgv_item.CurrentCell = Me.Dgv_item(0, i)
                            Catch ex As Exception
                                MsgBox(ex.ToString)
                            End Try
                        End If

                    Next
                End If

                If tablaequiposfin.Rows.Count > 0 Then
                    Dim _TABLA_IDEQUPO2 As New DataTable
                    Dim dsentradas2 As New DataSet
                    _TABLA_IDEQUPO2.Columns.Add("IDEQUIPO")

                    'Veririfacion de equipos con articulos

                    Dim CantidadArticulos As Integer = 0
                    Dim CantidadEquipos As Integer = 0
                    Dim IdArticuloValidar As Integer = 0
                    For i As Integer = 0 To Me.LISTAITEMENTRADAALMACEN.Rows.Count - 1
                        CantidadArticulos += Convert.ToInt64(Me.LISTAITEMENTRADAALMACEN.Rows(i).Item("Cant").ToString)
                    Next

                    If Cbx_VerificacionEquipos.Checked = True Then
                        If tablaequiposfin.Rows.Count > 0 Then
                            For i As Integer = 0 To tablaequiposfin.Rows.Count - 1
                                CantidadEquipos += 1
                                Dim fila As DataRow
                                fila = _TABLA_IDEQUPO2.NewRow
                                fila("IDEQUIPO") = tablaequiposfin.Rows(i).Item(0)
                                _TABLA_IDEQUPO2.Rows.Add(fila)
                            Next

                        End If
                        If tablacomponentesfin.Rows.Count > 0 Then
                            For i As Integer = 0 To tablacomponentesfin.Rows.Count - 1
                                CantidadEquipos += 1
                            Next
                            For i = 0 To tablacomponentesfin.Rows.Count - 1
                                Dim fila As DataRow
                                fila = _TABLA_IDEQUPO2.NewRow
                                fila("IDEQUIPO") = tablacomponentesfin.Rows(i).Item(0)
                                _TABLA_IDEQUPO2.Rows.Add(fila)
                            Next
                        End If
                    End If

                    Dim dsEquiposBuscar As DataSet
                    dsEquiposBuscar = bddatos.ModificarEntradasSalidas(25, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, Date.Now, 0, Date.Now, "", 0, 0, _TABLA_IDEQUPO2)
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

                    'If tablaequiposfin.Rows.Count > 0 Then
                    '    If CantidadArticulos <> CantidadEquipos Then
                    '        If tablacomponentesfin.Rows.Count = 0 Or Cbx_VerificacionEquipos.Checked = False Then
                    '            MsgBox("No ha seleccionado o faltan equipos por seleccionar, verifique que las cantidades coincidan en el botón SELECCIONAR / VER EQUIPOS", MsgBoxStyle.Critical, "EQUIPOS")
                    '            Bt_SeleccionarEquipos.Focus()
                    '            Exit Sub
                    '        End If
                    '    End If

                    'For i = 0 To tablaequiposfin.Rows.Count - 1
                    '    Dim fila As DataRow
                    '    fila = _TABLA_IDEQUPO2.NewRow
                    '    fila("IDEQUIPO") = tablaequiposfin.Rows(i).Item(0)
                    '    _TABLA_IDEQUPO2.Rows.Add(fila)
                    'Next

                    'End If
                    'If tablacomponentesfin.Rows.Count > 0 Then
                    '    For i = 0 To tablacomponentesfin.Rows.Count - 1
                    '        Dim fila As DataRow
                    '        fila = _TABLA_IDEQUPO2.NewRow
                    '        fila("IDEQUIPO") = tablacomponentesfin.Rows(i).Item(0)
                    '        _TABLA_IDEQUPO2.Rows.Add(fila)
                    '    Next
                    'End If

                    If Cb_TipoEntrada.SelectedValue = "T" Then
                        If _TABLA_IDEQUPO2.Rows.Count > 0 Then
                            Dim dsentradas3 As DataSet
                            dsentradas3 = bddatos.ModificarEntradasSalidas(24, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, Date.Now, 0, Date.Now, "", Cb_Relación.SelectedValue, 0, _TABLA_IDEQUPO2)

                            If dsentradas3.Tables(0).Rows.Count > 0 Then
                                MsgBox("Verificar si la remisión tiene entradas de los items en bodega ")
                                Exit Sub
                            End If
                        End If
                    End If
                End If
        End Select
        'total por items 

        Dim EntradaCompra As Boolean = False
        Dim TablaItemEA As New DataTable
        TablaItemEA.Columns.Add("IDITEMENTRADAALMACEN")
        TablaItemEA.Columns.Add("IDORDENCOMPRA")
        TablaItemEA.Columns.Add("IDITEMORDENCOMPRA")
        TablaItemEA.Columns.Add("CANTIDAD")
        TablaItemEA.Columns.Add("IDARTICULO")
        TablaItemEA.Columns.Add("IDREQUISICION")
        TablaItemEA.Columns.Add("IDITEMREQUISICION")
        TablaItemEA.Columns.Add("NUMEROFACTURA")
        TablaItemEA.Columns.Add("IDREMISION")

        Dim FilaTablaItemEA As DataRow
        For i = 0 To Me.LISTAITEMENTRADAALMACEN.Rows.Count - 1
            Dim FilaDGVItem As DataRow
            FilaDGVItem = Me.LISTAITEMENTRADAALMACEN.Rows(i)
            FilaTablaItemEA = TablaItemEA.NewRow
            FilaTablaItemEA("IDITEMENTRADAALMACEN") = FilaDGVItem("Item")
            FilaTablaItemEA("IDORDENCOMPRA") = FilaDGVItem("IDORDENCOMPRA")
            FilaTablaItemEA("IDITEMORDENCOMPRA") = FilaDGVItem("Item OC")
            FilaTablaItemEA("CANTIDAD") = Replace(FilaDGVItem("Cant"), ",", ".")
            FilaTablaItemEA("IDARTICULO") = FilaDGVItem("Código")
            FilaTablaItemEA("IDREQUISICION") = FilaDGVItem("IDREQUISICION")
            FilaTablaItemEA("IDITEMREQUISICION") = FilaDGVItem("Item RQ")

            If IsDBNull(FilaDGVItem("Factura")) = True Then
                FilaTablaItemEA("NUMEROFACTURA") = Me.Tx_NroFactura.Text
            Else
                If FilaDGVItem("Factura") = "" Then
                    FilaTablaItemEA("NUMEROFACTURA") = Me.Tx_NroFactura.Text
                Else

                    FilaTablaItemEA("NUMEROFACTURA") = FilaDGVItem("Factura")
                End If
            End If

            FilaTablaItemEA("IDREMISION") = FilaDGVItem("IDREMISION")
            TablaItemEA.Rows.Add(FilaTablaItemEA)
        Next

        Dim Comando As New SqlClient.SqlCommand("GestionarEntradaAlmacen")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TableItemEA", TablaItemEA)
        Comando.Parameters.AddWithValue("@IDENTRADAALMACEN", IDENTRADAALMACENMODIFICANDO)
        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 0)
        End If
        Comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        Comando.Parameters.AddWithValue("@TIPOENTRADAALMACEN", Me.Cb_TipoEntrada.SelectedValue)

        If Me.Cb_TipoEntrada.SelectedValue = "C" Then
            EntradaCompra = True
        End If

        Comando.Parameters.AddWithValue("@FECHARECIBIDO", Me.Dtp_FechaRecibido.Value)
        Comando.Parameters.AddWithValue("@IDPERSONARECIBIO", Me.Cu_BPRecibio.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAVERIFICO", Me.Cu_BpVerifico.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAAPROBO", Me.Cu_BpAprobo.Cb_Persona.SelectedValue)
        If Cb_TipoEntrada.SelectedValue = "D" Or Cb_TipoEntrada.SelectedValue = "H" Or Cb_TipoEntrada.SelectedValue = "S" Then
            Comando.Parameters.AddWithValue("@IDPERSONAENTREGAABODEGA", Cu_BpEntregaABodega.Cb_Persona.SelectedValue)
        Else
            Comando.Parameters.AddWithValue("@IDPERSONAENTREGAABODEGA", DBNull.Value)
        End If
        Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
        Dim Obser As String = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Observacion_AI.Text)
        'Obser = Trim(Tx_Observacion_AI.Text)
        'Obser = Replace(Obser, vbTab, " ")
        'Obser = Replace(Obser, vbLf, " ")
        Comando.Parameters.AddWithValue("@OBSERVACION", Obser)
        Comando.Parameters.AddWithValue("@NROREMISION", Me.Tx_Remisión.Text)
        If Dtp_FechaRemisión.Checked = True Then
            Comando.Parameters.AddWithValue("@FECHAREMISION", Dtp_FechaRemisión.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAREMISION", DBNull.Value)
        End If
        Comando.Parameters.AddWithValue("@TRANSPORTADOR", Me.Tx_Transportador.Text)
        Comando.Parameters.AddWithValue("@ENTREGA", Me.Tx_Entrega.Text)

        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Try
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        guardado = True
        conn.Close()
        Me.Close()
        Dim IdEntrada As Integer = msgParam.Value

        If EntradaCompra Then
            'Función que envía correo a comprador si es entrada de almacén por orden de compra
            Try
                If Editando Then
                    CorreoAComprador(IDENTRADAALMACENMODIFICANDO)
                Else
                    CorreoAComprador(IdEntrada)
                End If
            Catch ex As Exception
                MsgBox("No se envió notificación al correo, Verificar correo de comprador", MsgBoxStyle.Information, "Entrada de Almacén")
            End Try

        End If

        Select Case Trim(Comando.Parameters("@IDMENSAJE").Value)
            Case "0"
                MsgBox("No se pudo realizar la operación", MsgBoxStyle.Exclamation, "No se completó la operación")
                guardado = False
                Exit Sub

            Case "-2"
                MsgBox("Se guardaron los cambios de la Entrada de Almacén", MsgBoxStyle.Information, "Modificar Entrada de Almacén")
                guardado = True
                Me.Close()
            Case Else
                MsgBox("Se guardó la entrada de almacén", MsgBoxStyle.Information, "Nueva Entrada de Almacén")

                FuncionesBase.FuncionesBase.ValoresxDefecto("G", "EA", "APROBO", Cu_BpAprobo.Cb_Persona.SelectedValue)
                FuncionesBase.FuncionesBase.ValoresxDefecto("G", "EA", "AUTORIZA", Cu_BpVerifico.Cb_Persona.SelectedValue)
                FuncionesBase.FuncionesBase.ValoresxDefecto("G", "EA", "RECIBE", Cu_BPRecibio.Cb_Persona.SelectedValue)

                'NUEVO REGISTRO guardar los equipos y ponerlos en la nueva bodega en estado activo
                If Cbx_VerificacionEquipos.Checked = True And Bt_SeleccionarEquipos.Enabled = True And validacionequipos = True Then 'si esta activo el botón de seleccionar y la variable de validación de equipos es verdadera
                    Select Case Cb_TipoEntrada.SelectedValue
                        Case "T" ' traslado de bodega
                            Try
                                Dim dsentradas As New DataSet
                                Dim _TABLA_IDEQUPO As New DataTable
                                _TABLA_IDEQUPO.Columns.Add("IDEQUIPO")



                                If tablaequiposfin.Rows.Count > 0 Then
                                    For i = 0 To tablaequiposfin.Rows.Count - 1
                                        Dim fila As DataRow
                                        fila = _TABLA_IDEQUPO.NewRow
                                        fila("IDEQUIPO") = tablaequiposfin.Rows(i).Item(0)
                                        _TABLA_IDEQUPO.Rows.Add(fila)
                                    Next
                                End If
                                If tablacomponentesfin.Rows.Count > 0 Then
                                    For i = 0 To tablacomponentesfin.Rows.Count - 1
                                        Dim fila As DataRow
                                        fila = _TABLA_IDEQUPO.NewRow
                                        fila("IDEQUIPO") = tablacomponentesfin.Rows(i).Item(0)
                                        _TABLA_IDEQUPO.Rows.Add(fila)
                                    Next
                                End If
                                If _TABLA_IDEQUPO.Rows.Count > 0 Then

                                    dsentradas = bddatos.ModificarEntradasSalidas(4, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, Date.Now, 0, Date.Now, "", Cb_Relación.SelectedValue, IdEntrada, _TABLA_IDEQUPO)
                                End If

                            Catch ex As Exception
                                MsgBox("error de registro de entrada de artículos")
                            End Try
                        Case "S" ' retorno de custodia
                            Try
                                Dim dsentradas As New DataSet
                                If tablaequiposfin.Rows.Count > 0 Then
                                    For i = 0 To tablaequiposfin.Rows.Count - 1
                                        dsentradas = bddatos.ModificarCustodias(3, 0, tablaequiposfin.Rows(i)("IDEQUIPO"), 6, 0, 0, IdEntrada)
                                    Next
                                End If
                                If tablacomponentesfin.Rows.Count > 0 Then ' ingresar los componentes
                                    For i = 0 To tablacomponentesfin.Rows.Count - 1
                                        dsentradas = bddatos.ModificarCustodias(3, 0, tablacomponentesfin.Rows(i)("IDEQUIPO"), 6, 0, 0, IdEntrada)
                                    Next
                                End If
                            Catch ex As Exception
                                MsgBox("error de registro de Entrada de Almacén por Retorno de Custodia")
                            End Try
                    End Select

                End If



                If MsgBox("¿Desea imprimir la entrada de almacén?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                    Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                    Dim Array As New ArrayList
                    Array.Add(64)
                    climpresiones.IDENTRADAALMACEN = Comando.Parameters("@IDMENSAJE").Value
                    climpresiones.FormatoImprimirMateriales(Array, True, False)
                    MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESIÓN")
                End If

                If Cbx_ImpSticker.CheckState = CheckState.Checked Then
                    If Cb_TipoEntrada.SelectedValue = "C" And (VariablesBase.VariablesBase.IdBodegaActual = 20 Or VariablesBase.VariablesBase.IdBodegaActual = 71) Then

                        Dim FrImprimirSticker As New Articulos.Fr_ImprimirSticker
                        FrImprimirSticker.Tipo = "EAS"

                        Dim dt_sticker As New DataTable("STICKER")
                        dt_sticker.Columns.Add("Cód", Type.GetType("System.Int32"))
                        'dt_sticker.Columns.Add("Und")
                        dt_sticker.Columns.Add("Requisición")
                        dt_sticker.Columns.Add("Orden Compra")
                        dt_sticker.Columns.Add("Descripción")
                        dt_sticker.Columns.Add("Cant", Type.GetType("System.Int32"))

                        For Each row As DataRow In LISTAITEMENTRADAALMACEN.Rows

                            Dim newRow As DataRow = dt_sticker.NewRow()
                            newRow("Cód") = row("Código")
                            newRow("Requisición") = row("Requisición")
                            newRow("Orden Compra") = row("Orden Compra")
                            newRow("Descripción") = row("Descripción")
                            newRow("Cant") = row("Cant")
                            dt_sticker.Rows.Add(newRow)
                        Next
                        FrImprimirSticker.FechaEA = Dtp_FechaRecibido.Value
                        FrImprimirSticker.EA = Comando.Parameters("@IDMENSAJE").Value
                        FrImprimirSticker.Tb_Sticker_EA = dt_sticker
                        FrImprimirSticker.ShowDialog()

                    Else
                        Dim FrImprimirSticker As New Articulos.Fr_ImprimirSticker
                        FrImprimirSticker.Tipo = "EA"

                        Dim dt_sticker As New DataTable("STICKER")
                        dt_sticker.Columns.Add("Cód", Type.GetType("System.Int32"))
                        dt_sticker.Columns.Add("Und")
                        dt_sticker.Columns.Add("Descripción")
                        dt_sticker.Columns.Add("Cant", Type.GetType("System.Int32"))

                        For Each row As DataRow In LISTAITEMENTRADAALMACEN.Rows

                            Dim newRow As DataRow = dt_sticker.NewRow()
                            newRow("Cód") = row("Código")
                            newRow("Und") = row("Und")
                            newRow("Descripción") = row("Descripción")
                            newRow("Cant") = row("Cant")
                            dt_sticker.Rows.Add(newRow)
                        Next
                        FrImprimirSticker.Tb_Sticker_EA = dt_sticker
                        FrImprimirSticker.ShowDialog()
                    End If

                End If
                Me.Close()
        End Select

    End Sub


    Private Sub Dgv_item_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Dgv_item.CellBeginEdit
        If IsDBNull(Me.Dgv_item.Item(e.ColumnIndex, e.RowIndex).Value) = False Then
            ValorAnteriorEdiciónIDArticulo = Me.Dgv_item.Item(e.ColumnIndex, e.RowIndex).Value
        Else
            ValorAnteriorEdiciónIDArticulo = -1
        End If
    End Sub


    Private Sub Dgv_EntradaAlmacen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv_item.KeyDown
        If EditarEquipos = "VER" Then
            Exit Sub
        End If
        If e.KeyCode = Windows.Forms.Keys.F3 Then
            Select Case Me.Cb_TipoEntrada.SelectedValue
                Case "I", "V", "D", "S", "H" ' Inventario Inicial, Ajuste de Inventario, Devolución a Bodega, Retorno de Custodia, Devolución de Herramienta
                    'Abrir formulario de búsquedas

                    Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
                    FrBuscarArtículo.Familia = familia
                    FrBuscarArtículo._Tipo = "T"
                    FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar

                    FrBuscarArtículo.ShowDialog()
                    If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
                        Exit Sub
                    End If

                    Dim IDARTICULO As Integer = -1
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
                        FilasArticulos = articulos.Select("ID=" + FrBuscarArtículo.IdArtículo.ToString)
                        If FilasArticulos.Length > 0 Then
                            Dim FilaArticulo As DataRow
                            FilaArticulo = FilasArticulos(0)
                            Dim NuevaFilaItem As DataRow
                            NuevaFilaItem = LISTAITEMENTRADAALMACEN.NewRow
                            NuevaFilaItem("Item") = Me.LISTAITEMENTRADAALMACEN.Rows.Count + 1
                            NuevaFilaItem("Código") = FilaArticulo("ID")
                            NuevaFilaItem("Descripción") = FilaArticulo("NOMBRE")
                            NuevaFilaItem("Requisición") = DBNull.Value
                            NuevaFilaItem("Item RQ") = DBNull.Value
                            NuevaFilaItem("Und") = FilaArticulo("UND")
                            NuevaFilaItem("Orden Compra") = DBNull.Value
                            NuevaFilaItem("Item OC") = DBNull.Value
                            NuevaFilaItem("Factura") = DBNull.Value
                            NuevaFilaItem("Cant") = 0
                            NuevaFilaItem("IDORDENCOMPRA") = DBNull.Value
                            NuevaFilaItem("IDREQUISICION") = DBNull.Value
                            NuevaFilaItem("IDREMISION") = DBNull.Value
                            NuevaFilaItem("PENDIENTE") = DBNull.Value
                            LISTAITEMENTRADAALMACEN.Rows.Add(NuevaFilaItem)
                        Else
                            ' no existe un articulo con este código
                            MensajeError = "No se encontró un artículo con ese código"
                            MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Artículo no Encontrado")
                        End If
                    Else
                        MensajeError = "El ítem que desea ingresar, ya se encuentra incluido en la requisición"
                        MsgBox(MensajeError, MsgBoxStyle.Critical, "Ítem Repetido")
                    End If
                Case "R" ' Requisición (TIPO DE ENTRADA EN DESUSO)
                    MensajeError = "Solo puede ingresar los Ítems de la Requisición"
                    MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Articulo Requisición")
                Case "A" ' Alquiler
                    MensajeError = "Solo puede ingresar los Ítems de Alquiler"
                    MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Artículo Alquiler")
                Case "C" ' Orden de Compra
                    MensajeError = "Solo puede ingresar los Ítems de la Orden de Compra"
                    MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Artículo Orden de Compra")
                Case "T" ' Traslado de Bodega
                    MensajeError = "Solo puede ingresar los Ítems del Traslado de Bodega"
                    MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Artículo Traslado de Bodega")
            End Select
            ELiminarFilaVacia()
        ElseIf e.KeyCode = Windows.Forms.Keys.Delete Then
            'HABILITAR SI SE DESEAN BLOQUEAR LAS ENTRADAS PARCIALES POR TRASLADO DE EQUIPO CAPITAL
            '*****
            'If Cb_TipoEntrada.SelectedValue = "T" And tablaequiposfin.Rows.Count > 0 Then
            '    MsgBox("No se permiten entradas parciales de órdenes con equipo capital asociado")
            '    Exit Sub
            'End If
            '*****
            Try
                Me.Dgv_item.Rows.RemoveAt(Me.Dgv_item.CurrentCell.RowIndex)
            Catch ex As Exception
            End Try
            Try
                LISTAITEMENTRADAALMACEN.AcceptChanges()
            Catch ex As Exception
            End Try
            'If Me.DsEntradaAlmacén.LISTAITEMENTRADAALMACEN.Count = 0 Then
            If Me.LISTAITEMENTRADAALMACEN.Rows.Count = 0 Then
                Me.Cb_TipoEntrada.Enabled = True
                Me.Cb_Relación.Enabled = True
            Else
                For x As Integer = Dgv_item.CurrentCell.RowIndex To LISTAITEMENTRADAALMACEN.Rows.Count - 1
                    'If IsDBNull(DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(x).Item) = False Then
                    'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(x).Item = x + 1
                    If IsDBNull(LISTAITEMENTRADAALMACEN(x).Item(0)) = False Then
                        LISTAITEMENTRADAALMACEN(x).Item(0) = x + 1
                    End If
                Next

                Try
                    Me.Dgv_item.CurrentCell = Me.Dgv_item(1, Index_Registro_Actual - 1)
                Catch ex As Exception
                End Try
                moverEnfoque()

            End If
            ELiminarFilaVacia()
            LimpiarTablas()
        End If
    End Sub


    Private Function ValidarItems(ByVal IdArticulo As Integer) As Boolean
        Dim filas As DataRow()
        filas = Me.LISTAITEMENTRADAALMACEN.Select("Código=" + IdArticulo.ToString)
        If filas.Length > 0 Then
            ValidarItems = False
            Exit Function
        End If
        ValidarItems = True
    End Function

    'Private Function ValidarItems(ByVal IdArticulo As String, ByVal Fila As Integer) As Boolean
    '    For x As Integer = 0 To Me.Dgv_item.Rows.Count - 2
    '        If x <> Fila Then
    '            If Me.Dgv_item.Item(1, x).Value = IdArticulo Then
    '                ValidarItems = True
    '                Exit Function
    '            End If
    '        End If
    '    Next
    '    ValidarItems = False
    'End Function

    Private Sub NumeroItems()
        For x As Integer = 0 To Me.Dgv_item.Rows.Count - 2
            Me.Dgv_item.Item(0, x).Value = x + 1
        Next
    End Sub

    Private Sub EliminarFila(ByVal FILA As Integer)
        Me.Dgv_item.Rows.RemoveAt(FILA)
    End Sub

    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub



    Private Sub Cb_TipoEntrada_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_TipoEntrada.SelectedIndexChanged
        Try
            Cb_Relación.Visible = False
            Lb_Relación.Visible = False
            Tx_NroFactura.Visible = False
            Lb_Factura.Visible = False
            Bt_Agregar.Visible = False

            ' ** DESHABILITAR SELECCIÓN DE EQUIPOS **
            Cbx_VerificacionEquipos.Enabled = False
            Cbx_VerificacionEquipos.Checked = False
            Bt_SeleccionarEquipos.Enabled = False
            ' ** DESHABILITAR SELECCIÓN DE EQUIPOS **

            ' ** DESHABILITAR COMBOBOX PERSONA QUE ENTREGA A BODEGA **
            Label8.Visible = False
            Cu_BpEntregaABodega.Visible = False
            Cu_BpEntregaABodega.Enabled = False
            Cu_APB_EntregaABodega.Visible = False
            Cu_APB_EntregaABodega.Enabled = False
            ' ** DESHABILITAR COMBOBOX PERSONA QUE ENTREGA A BODEGA **

            Select Case Cb_TipoEntrada.SelectedValue
                Case "I", "V" ' Ajuste de inventario, Inventario Inicial
                    Me.Cb_Relación.DataSource = Nothing
                    Me.Dgv_item.Columns.Item(1).ReadOnly = False
                Case "R" ' Requisición (TIPO DE ENTRADA EN DESUSO)
                    Me.Cb_Relación.Visible = True
                    Me.Lb_Relación.Visible = True
                    Me.Bt_Agregar.Visible = True
                    Me.Lb_Relación.Text = "Requisición:"
                    Dim ada As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.REQUISICIONTableAdapter
                    If FuncionesBase.FuncionesBase.EsBodegaPrincipal(VariablesBase.VariablesBase.IdBodegaActual) Then
                        ada.FillIDBODEGA(Me.DsEntradaAlmacén.REQUISICION, 0, VariablesBase.VariablesBase.IdBodegaActual)
                    Else
                        ada.FillIDBODEGA(Me.DsEntradaAlmacén.REQUISICION, 1, VariablesBase.VariablesBase.IdBodegaActual)
                    End If

                    Me.Cb_Relación.DataSource = Me.DsEntradaAlmacén.REQUISICION
                    Me.Cb_Relación.DisplayMember = "Requisición"
                    Me.Cb_Relación.ValueMember = "Id"
                    Me.Dgv_item.Columns.Item(1).ReadOnly = True
                Case "A" ' Alquiler
                    Me.Cb_Relación.Visible = True
                    Me.Lb_Relación.Visible = True
                    Me.Bt_Agregar.Visible = True
                    Me.Lb_Relación.Text = "Requisición:"
                    Dim ada As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.REQUISICIONTableAdapter
                    Select Case VariablesBase.VariablesBase.IdBodegaActual
                        Case 1, 2, 3, 4, 20, 49
                            ada.FillIDBODEGA(Me.DsEntradaAlmacén.REQUISICION, 0, VariablesBase.VariablesBase.IdBodegaActual)
                        Case Else
                            ada.FillIDBODEGA(Me.DsEntradaAlmacén.REQUISICION, 1, VariablesBase.VariablesBase.IdBodegaActual)
                    End Select
                    Me.Cb_Relación.DataSource = Me.DsEntradaAlmacén.REQUISICION
                    Me.Cb_Relación.DisplayMember = "Requisición"
                    Me.Cb_Relación.ValueMember = "Id"
                    Me.Dgv_item.Columns.Item(1).ReadOnly = True
                Case "C" ' Orden de Compra
                    Me.Dgv_item.Columns.Item(1).ReadOnly = True
                    Me.Cb_Relación.Visible = True
                    Me.Lb_Relación.Visible = True
                    Me.Tx_NroFactura.Visible = True
                    Me.Lb_Factura.Visible = True
                    Me.Bt_Agregar.Visible = True
                    Me.Lb_Relación.Text = "Orden Compra:"

                    Dim datas As New DataSet
                    Dim cmde As New SqlClient.SqlCommand
                    Dim da As New SqlClient.SqlDataAdapter
                    Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)

                    sqlconeccion.Open()
                    cmde.Parameters.Clear()
                    cmde.CommandType = CommandType.StoredProcedure
                    cmde.Connection = sqlconeccion
                    cmde.CommandText = "ListarOrdenesCompraPendientes"
                    cmde.Parameters.Add("@IDpersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
                    cmde.Parameters.Add("@IDbodegaActual", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBodegaActual

                    da = New SqlClient.SqlDataAdapter(cmde)
                    datas = New DataSet()

                    da.Fill(datas)
                    sqlconeccion.Close()

                    Me.Cb_Relación.DataSource = datas.Tables(0)
                    Me.Cb_Relación.DisplayMember = "ORDENCOMPRA"
                    Me.Cb_Relación.ValueMember = "IDORDENCOMPRA"
                Case "T" ' Traslado de Bodega
                    Me.Dgv_item.Columns.Item(1).ReadOnly = True
                    Me.Cb_Relación.Visible = True
                    Me.Lb_Relación.Visible = True
                    Me.Bt_Agregar.Visible = True
                    Me.Lb_Relación.Text = "Nro Remisión:"
                    Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    Dim Consulta As New SqlClient.SqlCommand("SELECT IDREMISION FROM dbo.RemisionesConItemsPendientesxbodegadestino(@IDBODEGADESTINO) order by IDREMISION DESC", Conexión)
                    Consulta.Parameters.AddWithValue("@IDBODEGADESTINO", VariablesBase.VariablesBase.IdBodegaActual.ToString)
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Dim dtremisiones As New DataTable
                    Adaptador.Fill(dtremisiones)
                    Consulta.Connection.Close()
                    Me.Cb_Relación.DataSource = dtremisiones
                    Me.Cb_Relación.DisplayMember = "IDREMISION"
                    Me.Cb_Relación.ValueMember = "IDREMISION"
                    '------HABILITAR--------
                    Cbx_VerificacionEquipos.Enabled = True
                    Cbx_VerificacionEquipos.Checked = True
                    Bt_SeleccionarEquipos.Enabled = True
                Case "D" ' Devolución a Bodega
                    Me.Cb_Relación.DataSource = Nothing
                    Me.Dgv_item.Columns.Item(1).ReadOnly = False
                    Label8.Visible = True
                    Cu_BpEntregaABodega.Visible = True
                    Cu_BpEntregaABodega.Enabled = True
                    Cu_APB_EntregaABodega.Visible = True
                    Cu_APB_EntregaABodega.Enabled = True
                Case "H" ' Devolución de Herramienta
                    Me.Cb_Relación.DataSource = Nothing
                    Me.Dgv_item.Columns.Item(1).ReadOnly = False
                    Label8.Visible = True
                    Cu_BpEntregaABodega.Visible = True
                    Cu_BpEntregaABodega.Enabled = True
                    Cu_APB_EntregaABodega.Visible = True
                    Cu_APB_EntregaABodega.Enabled = True
                Case "S" ' Retorno de Custodia
                    Me.Cb_Relación.DataSource = Nothing
                    Me.Dgv_item.Columns.Item(1).ReadOnly = False
                    Label8.Visible = True
                    Cu_BpEntregaABodega.Visible = True
                    Cu_BpEntregaABodega.Enabled = True
                    Cu_APB_EntregaABodega.Visible = True
                    Cu_APB_EntregaABodega.Enabled = True
                    '------HABILITAR--------
                    Cbx_VerificacionEquipos.Checked = True
                    Bt_SeleccionarEquipos.Enabled = True
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Bt_Agregar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Agregar.Click
        AgregarItem()
    End Sub

    Dim dsCargar1 As New DataSet
    Dim dsCargar2 As New DataSet
    Dim dsCargar3 As New DataSet
    Private Sub AgregarItem()

        Select Case Me.Cb_TipoEntrada.SelectedValue
            Case "I", "V", "D", "S", "H" ' Ajuste de Inventario, Inventario Inicial, Devolución a Bodega, Retorno de Custodia
                Me.Dgv_item.Columns.Item(1).ReadOnly = False
            Case "R", "A" ' Alquiler, Requisición
                Me.Dgv_item.Columns.Item(1).ReadOnly = True

                'Dim ada As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.ITEMREQUISICIONTableAdapter
                'ada.FillIDREQUISICION(Me.DsEntradaAlmacén.ITEMREQUISICION, Me.Cb_Relación.SelectedValue)
                'For i = 0 To Me.DsEntradaAlmacén.ITEMREQUISICION.Rows.Count - 1

                dsCargar1 = bddatos1.CargarMaestrasMateriales(5, VariablesBase.VariablesBase.IdBodegaActual, Me.Cb_Relación.SelectedValue, 1)

                For i = 0 To Me.dsCargar1.Tables(0).Rows.Count - 1
                    Dim FilaItemRQ As DataRow
                    'FilaItemRQ = Me.DsEntradaAlmacén.ITEMREQUISICION.Rows(i)
                    FilaItemRQ = Me.dsCargar1.Tables(0).Rows(i)
                    Dim filasarticulos As DataRow()
                    'filasarticulos = Me.DsEntradaAlmacén.LISTAITEMENTRADAALMACEN.Select("Código=" + FilaItemRQ("Código").ToString + " AND IDREQUISICION=" + FilaItemRQ("IDREQUISICION").ToString)


                    filasarticulos = Me.LISTAITEMENTRADAALMACEN.Select("Código=" + FilaItemRQ("Código").ToString + " AND IDREQUISICION=" + FilaItemRQ("IDREQUISICION").ToString)
                    If filasarticulos.Length = 0 Then
                        Dim FilaNueva As DataRow
                        'FilaNueva = Me.DsEntradaAlmacén.LISTAITEMENTRADAALMACEN.NewRow
                        'FilaNueva("Item") = Me.DsEntradaAlmacén.LISTAITEMENTRADAALMACEN.Rows.Count + 1
                        FilaNueva = Me.LISTAITEMENTRADAALMACEN.NewRow
                        FilaNueva("Item") = Me.LISTAITEMENTRADAALMACEN.Rows.Count + 1
                        FilaNueva("Código") = FilaItemRQ("Código")
                        FilaNueva("Descripción") = FilaItemRQ("Descripción")
                        FilaNueva("Requisición") = FilaItemRQ("Requisición")
                        FilaNueva("Item RQ") = FilaItemRQ("Item RQ")
                        FilaNueva("Und") = FilaItemRQ("Und")
                        FilaNueva("Orden Compra") = FilaItemRQ("Orden Compra")
                        FilaNueva("Item OC") = FilaItemRQ("Item OC")
                        FilaNueva("Factura") = FilaItemRQ("Factura")
                        FilaNueva("Cant") = Replace(FilaItemRQ("Cant"), ".", ",")
                        FilaNueva("IDORDENCOMPRA") = FilaItemRQ("IDORDENCOMPRA")
                        FilaNueva("IDREQUISICION") = FilaItemRQ("IDREQUISICION")
                        FilaNueva("IDREMISION") = DBNull.Value
                        FilaNueva("PENDIENTE") = DBNull.Value 'pendiente calcular esta cantidad
                        'Me.DsEntradaAlmacén.LISTAITEMENTRADAALMACEN.Rows.Add(FilaNueva)
                        Me.LISTAITEMENTRADAALMACEN.Rows.Add(FilaNueva)
                    End If
                Next
            Case "C" ' Orden de Compra
                Me.Dgv_item.Columns.Item(1).ReadOnly = True
                'Dim ada As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.ITEMORDENCOMPRATableAdapter
                'ada.FillIDORDENCOMPRA(Me.DsEntradaAlmacén.ITEMORDENCOMPRA, Me.Cb_Relación.SelectedValue)
                'For i = 0 To Me.DsEntradaAlmacén.ITEMORDENCOMPRA.Rows.Count - 1

                dsCargar2 = bddatos1.CargarMaestrasMateriales(6, VariablesBase.VariablesBase.IdBodegaActual, Me.Cb_Relación.SelectedValue, 1)
                For i = 0 To Me.dsCargar2.Tables(0).Rows.Count - 1
                    Dim FilaItemOC As DataRow
                    FilaItemOC = Me.dsCargar2.Tables(0).Rows(i)
                    Dim filasarticulos As DataRow()
                    filasarticulos = Me.LISTAITEMENTRADAALMACEN.Select("Código=" + FilaItemOC("Código").ToString + " AND IDORDENCOMPRA=" + FilaItemOC("IDORDENCOMPRA").ToString)
                    If filasarticulos.Length = 0 Then
                        Dim FilaNueva As DataRow
                        FilaNueva = Me.LISTAITEMENTRADAALMACEN.NewRow
                        FilaNueva("Item") = Me.LISTAITEMENTRADAALMACEN.Rows.Count + 1
                        FilaNueva("Código") = FilaItemOC("Código")
                        FilaNueva("Descripción") = FilaItemOC("Descripción")
                        FilaNueva("Requisición") = FilaItemOC("Requisición")
                        FilaNueva("Item RQ") = FilaItemOC("Item RQ")
                        FilaNueva("Und") = FilaItemOC("Und")
                        FilaNueva("Orden Compra") = FilaItemOC("Orden Compra")
                        FilaNueva("Item OC") = FilaItemOC("Item OC")
                        FilaNueva("Factura") = Me.Tx_NroFactura.Text
                        FilaNueva("Cant") = Replace(FilaItemOC("Cant"), ".", ",")
                        FilaNueva("IDORDENCOMPRA") = FilaItemOC("IDORDENCOMPRA")
                        FilaNueva("IDREQUISICION") = FilaItemOC("IDREQUISICION")
                        FilaNueva("IDREMISION") = DBNull.Value
                        FilaNueva("PENDIENTE") = FilaItemOC("PENDIENTE")
                        Me.LISTAITEMENTRADAALMACEN.Rows.Add(FilaNueva)
                    End If
                Next
            Case "T" ' Traslado de Bodega
                Me.Dgv_item.Columns.Item(1).ReadOnly = True
                'Dim ada As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.ITEMREMISIONTableAdapter
                'ada.FillIDREMISION(Me.DsEntradaAlmacén.ITEMREMISION, Me.Cb_Relación.SelectedValue)

                dsCargar3 = CargarArticulos(Me.Cb_Relación.SelectedValue)



                For i = 0 To Me.dsCargar3.Tables(0).Rows.Count - 1
                    Dim FilaItemRemisión As DataRow
                    FilaItemRemisión = Me.dsCargar3.Tables(0).Rows(i)
                    Dim filasarticulos As DataRow()
                    filasarticulos = Me.LISTAITEMENTRADAALMACEN.Select("Código=" + FilaItemRemisión("Código").ToString + " AND IDREMISION=" + FilaItemRemisión("IDREMISION").ToString)
                    If filasarticulos.Length = 0 Then
                        Dim FilaNueva As DataRow
                        FilaNueva = Me.LISTAITEMENTRADAALMACEN.NewRow
                        FilaNueva("Item") = Me.LISTAITEMENTRADAALMACEN.Rows.Count + 1
                        FilaNueva("Código") = FilaItemRemisión("Código")
                        FilaNueva("Descripción") = FilaItemRemisión("Descripción")
                        FilaNueva("Requisición") = FilaItemRemisión("Requisición")
                        FilaNueva("Item RQ") = FilaItemRemisión("Item RQ")
                        FilaNueva("Und") = FilaItemRemisión("Und")
                        FilaNueva("Orden Compra") = FilaItemRemisión("Orden Compra")
                        FilaNueva("Item OC") = FilaItemRemisión("Item OC")
                        FilaNueva("Factura") = Me.Tx_NroFactura.Text
                        FilaNueva("Cant") = Replace(FilaItemRemisión("Cant"), ".", ",")
                        FilaNueva("IDORDENCOMPRA") = FilaItemRemisión("IDORDENCOMPRA")
                        FilaNueva("IDREQUISICION") = FilaItemRemisión("IDREQUISICION")
                        FilaNueva("IDREMISION") = FilaItemRemisión("IDREMISION")
                        FilaNueva("PENDIENTE") = DBNull.Value 'Pendiente definir los pendientes por traslado de bodega
                        Me.LISTAITEMENTRADAALMACEN.Rows.Add(FilaNueva)
                        If tablaequiposfin.Rows.Count > 0 Then
                            Dgv_item.ReadOnly = True
                        End If
                    End If
                Next

                'REVISAR SI EXISTEN EQUIPOS ASOCIADOS A LA REMISION PARA ENTRADA
                Dim dsremision As New DataSet
                dsremision = CargarEquipos(Me.Cb_Relación.SelectedValue)

        End Select
        Me.Cb_TipoEntrada.Enabled = False
        Me.Cb_Relación.Enabled = False
        Me.Tx_lectora.Enabled = False

    End Sub


    ''' <summary>
    ''' traer lista de  articulos que contiene la remison 
    ''' </summary>

    Function CargarArticulos(ByVal idremision As Integer)
        Dim dsarticulos As New DataSet
        dsarticulos = bddatos1.CargarMaestrasMateriales(7, VariablesBase.VariablesBase.IdBodegaActual, idremision, 1)
        Return dsarticulos

    End Function





    ''' <summary>
    ''' traer lista de  Equipos  que contiene la remison 
    ''' </summary>
    ''' 


    Function CargarEquipos(ByVal idremision As Integer) As DataSet
        Dim dsremision As New DataSet
        dsremision = bddatos.ModificarEntradasSalidas(10, 0, 0, 0, Date.Now, 0, Date.Now, "", idremision, 0)
        'si existen ítems lleno las tablas, si no deshabilito el botón de ver los equipos porque no hay equipos asociados a la entrada
        If dsremision.Tables(0).Rows.Count > 0 Then
            validacionequipos = True
            tablaequiposfin = dsremision.Tables(0)
            If dsremision.Tables(1).Rows.Count > 0 Then
                tablacomponentesfin = dsremision.Tables(1)
            End If
            Bt_SeleccionarEquipos.Enabled = True
            Cbx_VerificacionEquipos.Checked = True
        Else
            Bt_SeleccionarEquipos.Enabled = False
            Cbx_VerificacionEquipos.Checked = False
        End If
        Return dsremision
    End Function

    Function VerificaequiposGuardados(ByVal _equipos As DataTable) As DataSet
        Dim dsEquiposEntradas As New DataSet
        dsEquiposEntradas = bddatos.ModificarEntradasSalidas(24, 0, 0, 0, Date.Now, 0, Date.Now, "", 0, 0, _equipos)
        'si existen ítems lleno las tablas, si no deshabilito el botón de ver los equipos porque no hay equipos asociados a la entrada
        If dsEquiposEntradas.Tables(0).Rows.Count > 0 Then
            validacionequipos = True
            tablaequiposfin = dsEquiposEntradas.Tables(0)
            If dsEquiposEntradas.Tables(1).Rows.Count > 0 Then
                tablacomponentesfin = dsEquiposEntradas.Tables(1)
            End If
            Bt_SeleccionarEquipos.Enabled = True
            Cbx_VerificacionEquipos.Checked = True
        Else
            Bt_SeleccionarEquipos.Enabled = False
            Cbx_VerificacionEquipos.Checked = False
        End If
        Return dsEquiposEntradas
    End Function



    Private Sub Dgv_item_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_item.CellEndEdit

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

        Dim Estilo_Celda As New DataGridViewCellStyle
        Estilo_Celda.BackColor = Color.White
        Me.Dgv_item.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda
        Me.Dgv_item.Rows(e.RowIndex).ErrorText = ""
        If Me.Dgv_item.Rows.Count <> 0 Then
            If Me.Cb_TipoEntrada.Enabled = True Then
                Me.Cb_TipoEntrada.Enabled = False
            End If

            If Me.Cb_Relación.Enabled = True Then
                Me.Cb_Relación.Enabled = False
            End If
        End If
        'Validar Articulo
        Select Case e.ColumnIndex
            Case Dgv_item.Columns(CódigoDataGridViewTextBoxColumn.Name).Index
                'Try
                '    Me.Dgv_item.Rows.RemoveAt(e.RowIndex)
                'Catch ex As Exception
                'End Try
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
                    FilasArticulos = articulos.Select("ID=" + IDARTICULO.ToString)

                    If FilasArticulos.Length > 0 Then
                        Dim FilaArticulo As DataRow
                        FilaArticulo = FilasArticulos(0)
                        Dim FilaNueva As DataRow
                        FilaNueva = Me.LISTAITEMENTRADAALMACEN.NewRow
                        FilaNueva("Item") = e.RowIndex + 1
                        FilaNueva("Código") = IDARTICULO
                        FilaNueva("Descripción") = FilaArticulo("NOMBRE")
                        FilaNueva("Requisición") = DBNull.Value
                        FilaNueva("Item RQ") = DBNull.Value
                        FilaNueva("Und") = FilaArticulo("UND")
                        FilaNueva("Orden Compra") = DBNull.Value
                        FilaNueva("Item OC") = DBNull.Value
                        FilaNueva("Factura") = DBNull.Value
                        If IsDBNull(Me.Dgv_item.Rows(Index_Registro_Actual).Cells("DescripciónDataGridViewTextBoxColumn").Value) = False Then
                            FilaNueva("Cant") = CANTIDAD
                        Else
                            FilaNueva("Cant") = 1
                        End If
                        FilaNueva("IDORDENCOMPRA") = DBNull.Value
                        FilaNueva("IDREQUISICION") = DBNull.Value
                        FilaNueva("IDREMISION") = DBNull.Value
                        If Me.LISTAITEMENTRADAALMACEN.Rows.Count = Me.Dgv_item.CurrentCell.RowIndex Then
                            Try
                                Me.Dgv_item.Rows.RemoveAt(e.RowIndex)
                            Catch ex As Exception
                            End Try
                            LISTAITEMENTRADAALMACEN.Rows.Add(FilaNueva)
                        Else
                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).Item = FilaNueva("Item")

                            LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Item") = FilaNueva("Item")
                            LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Código") = FilaNueva("Código")
                            LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Descripción") = FilaNueva("Descripción")
                            LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Requisición") = IIf(IsDBNull(FilaNueva("Requisición")), "", FilaNueva("Requisición"))
                            If IsDBNull(FilaNueva("Item RQ")) = False Then
                                LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Item_RQ") = FilaNueva("Item RQ")
                            End If
                            LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Und") = IIf(IsDBNull(FilaNueva("Und")), "", FilaNueva("Und"))
                            If IsDBNull(FilaNueva("Orden Compra")) = False Then
                                LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Orden_Compra") = IIf(IsDBNull(FilaNueva("Orden Compra")), "", FilaNueva("Orden Compra"))
                            End If
                            If IsDBNull(FilaNueva("Item OC")) = False Then
                                LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Item_RQ") = FilaNueva("Item OC")
                            End If
                            LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Factura") = IIf(IsDBNull(FilaNueva("Factura")), "", FilaNueva("Factura"))
                            LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Cant") = IIf(IsDBNull(Replace(FilaNueva("Cant"), ".", ",")), "", Replace(FilaNueva("Cant"), ".", ","))
                            If IsDBNull(FilaNueva("IDORDENCOMPRA")) = False Then
                                LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("IDORDENCOMPRA") = IIf(IsDBNull(FilaNueva("IDORDENCOMPRA")), Nothing, FilaNueva("IDORDENCOMPRA"))
                            End If
                            If IsDBNull(FilaNueva("IDREQUISICION")) = False Then
                                LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("IDREQUISICION") = IIf(IsDBNull(FilaNueva("IDREQUISICION")), Nothing, FilaNueva("IDREQUISICION"))
                            End If
                            If IsDBNull(FilaNueva("IDREMISION")) = False Then
                                LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("IDREMISION") = IIf(IsDBNull(FilaNueva("IDREMISION")), Nothing, FilaNueva("IDREMISION"))
                            End If


                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).Código = FilaNueva("Código")
                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).Descripción = FilaNueva("Descripción")
                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).Requisición = IIf(IsDBNull(FilaNueva("Requisición")), "", FilaNueva("Requisición"))
                            'If IsDBNull(FilaNueva("Item RQ")) = False Then
                            '    DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).Item_RQ = FilaNueva("Item RQ")
                            'End If
                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).Und = IIf(IsDBNull(FilaNueva("Und")), "", FilaNueva("Und"))
                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).Orden_Compra = IIf(IsDBNull(FilaNueva("Orden Compra")), "", FilaNueva("Orden Compra"))

                            'If IsDBNull(FilaNueva("Item OC")) = False Then
                            '    DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).Item_RQ = FilaNueva("Item OC")
                            'End If
                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).Factura = IIf(IsDBNull(FilaNueva("Factura")), "", FilaNueva("Factura"))
                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).Cant = IIf(IsDBNull(Replace(FilaNueva("Cant"), ".", ",")), "", Replace(FilaNueva("Cant"), ".", ","))
                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).IDORDENCOMPRA = IIf(IsDBNull(FilaNueva("IDORDENCOMPRA")), Nothing, FilaNueva("IDORDENCOMPRA"))
                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).IDREQUISICION = IIf(IsDBNull(FilaNueva("IDREQUISICION")), Nothing, FilaNueva("IDREQUISICION"))
                            'DsEntradaAlmacén.LISTAITEMENTRADAALMACEN(e.RowIndex).IDREMISION = IIf(IsDBNull(FilaNueva("IDREMISION")), Nothing, FilaNueva("IDREMISION"))

                        End If
                    Else
                        ' no existe un articulo con este código
                        MsgBox("No se encontraron artículos con el código digitado.", MsgBoxStyle.Exclamation, "Artículo no encontrado")
                        moverEnfoque()
                    End If
                    UbicarRegistros()
                    ELiminarFilaVacia()
                    LimpiarTablas()
                Else
                    Dim i As Integer = LISTAITEMENTRADAALMACEN.Select("Código=" + IDARTICULO.ToString)(0).Item("Item")
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

                    'MsgBox("El ítem que desea ingresar ya se encuentra incluido en la requisición", MsgBoxStyle.Critical, "Ítem repetido")
                    'Try
                    '    LISTAITEMENTRADAALMACEN.Rows(e.RowIndex).Item("Código") = ValorAnteriorEdiciónIDArticulo
                    'Catch ex As Exception
                    'End Try
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
        filas = Me.LISTAITEMENTRADAALMACEN.Select("Código=" + IdArticulo.ToString)
        If filas.Length > 0 Then
            ValidarItem = False
            Exit Function
        End If
        ValidarItem = True
    End Function

    Private Sub Fr_EntradaAlmacen_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If guardado = False And Bt_Guardar.Enabled = True Then
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


    Private Sub ELiminarFilaVacia()
        Try
            For i = 0 To Dgv_item.Rows.Count - 2
                If IsDBNull(Me.Dgv_item.Rows(i).Cells("DescripciónDataGridViewTextBoxColumn").Value) = True Then
                    Me.Dgv_item.Rows.RemoveAt(i)
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ELiminarFilallena()
        Try
            Index_Registro_Actual = Dgv_item.CurrentRow.Index
            If IsDBNull(Me.Dgv_item.Rows(Index_Registro_Actual).Cells("DescripciónDataGridViewTextBoxColumn").Value) = False Then
                Me.Dgv_item.Rows.RemoveAt(Index_Registro_Actual)

                Try
                    LISTAITEMENTRADAALMACEN.AcceptChanges()
                Catch ex As Exception
                End Try

                For x As Integer = Dgv_item.CurrentCell.RowIndex To LISTAITEMENTRADAALMACEN.Rows.Count - 1
                    If IsDBNull(LISTAITEMENTRADAALMACEN(x).Item("Item")) = False Then
                        LISTAITEMENTRADAALMACEN(x).Item("Item") = x + 1
                    End If
                Next

            End If
        Catch
        End Try
    End Sub

    Private Sub Ll_ActualizarContacto_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_ActualizarContacto.LinkClicked
        If MsgBox("¿Desea ver o actualizar los contactos asociados al documento?", MsgBoxStyle.YesNo, "Ver o Actualizar Contactos") = MsgBoxResult.Yes Then
            If Me.Cu_BPRecibio.Cb_Persona.SelectedIndex <> -1 And
                Me.Cu_BpVerifico.Cb_Persona.SelectedIndex <> -1 And
                Me.Cu_BpAprobo.Cb_Persona.SelectedIndex <> -1 Then
                Dim FrActualizarContacto As New FormulariosClasesBase.Fr_ActualizarContacto
                FrActualizarContacto.Bt_Aceptar.Enabled = Me.Bt_Guardar.Enabled
                FrActualizarContacto.Cu_Contacto1.IDPERSONA = Me.Cu_BPRecibio.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto1.Gb_Contacto.Text = "Recibió: " + Me.Cu_BPRecibio.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto2.IDPERSONA = Me.Cu_BpVerifico.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto2.Gb_Contacto.Text = "Verificó: " + Me.Cu_BpVerifico.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto3.IDPERSONA = Me.Cu_BpAprobo.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto3.Gb_Contacto.Text = "Revisa: " + Me.Cu_BpAprobo.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto4.IDPERSONA = -1
                FrActualizarContacto.CargarDatos()
                FrActualizarContacto.ShowDialog()
            Else
                MsgBox("Debe seleccionar todas las personas que interactúan con el documento", MsgBoxStyle.Information, "Seleccionar todas las personas")
            End If
        End If
    End Sub

    Private Sub Cbx_VerificacionEquipos_CheckedChanged(sender As System.Object, e As EventArgs) Handles Cbx_VerificacionEquipos.CheckedChanged
        If Cbx_VerificacionEquipos.Checked = True Then
            Bt_SeleccionarEquipos.Enabled = True
        Else
            Bt_SeleccionarEquipos.Enabled = False
        End If
    End Sub

    Private Sub Bt_SeleccionarEquipos_Click(sender As System.Object, e As EventArgs) Handles Bt_SeleccionarEquipos.Click
        If ValidarEntradaAlmacen(1) = True Then
            If EditarEquipos = "NUEVO" Then
                If equiposborrados = False Then
                    Dim dscargarequipos As New DataSet
                    dscargarequipos = bddatos.ModificarEntradasSalidas(10, 0, 0, 0, Date.Now, 0, Date.Now, "", Me.Cb_Relación.SelectedValue, 0)
                    tablaequiposfin = dscargarequipos.Tables(0)
                    If dscargarequipos.Tables(1).Rows.Count > 0 Then
                        tablacomponentesfin = dscargarequipos.Tables(1)
                    End If
                Else
                    ' no hace nada, los equipos fueron limpiados
                End If
            End If
            Dim tablaitemsReset As New DataTable("LISTAITEMSALIDAALMACEN")
            Dim tablaitemsResetCopia As New DataTable ' crear una tabla
            tablaitemsResetCopia = Dgv_item.DataSource ' la tabla posee el DataSource de la grilla
            tablaitemsReset = tablaitemsResetCopia.Copy() ' copiar los datos en una nueva para desligar los datos

            Dim formtrasladar As New FormulariosActivosFijos.Fr_TrasladosEquipos
            ' ENVIAR UN DATATABLE CON LAS COLUMNAS
            ' | CÓDIGO ARTÍCULO | DESCRIPCIÓN ARTÍCULO | CANTIDAD |
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

            ' ANTES DE ABRIR EL FORMULARIO REVISAR SI LA TABLA "tablacomponentesfin" TIENE DATOS Y QUITARLOS ANTES DE MANDARLOS
            Dim j, existe As Integer
            If tablacomponentesfin.Rows.Count > 0 Then
                For i = 0 To tablacomponentesfin.Rows.Count - 1
                    existe = 0
                    For j = 0 To Dgv_item.RowCount - 1
                        If tablacomponentesfin.Rows(i)("IDARTICULO") = Dgv_item.Rows(j).Cells("CódigoDataGridViewTextBoxColumn").Value Then
                            ' restar una unidad
                            pivoteSeleccionarEquipos = True ' variable de verificación para que no resetee las tablas de equipos ni componentes
                            Dgv_item.Rows(j).Cells("CantDataGridViewTextBoxColumn").Value = Dgv_item.Rows(j).Cells("CantDataGridViewTextBoxColumn").Value - 1
                            If Dgv_item.Rows(j).Cells("CantDataGridViewTextBoxColumn").Value = 0 Then
                                Dgv_item.Rows.Remove(Dgv_item.Rows(j))
                                LISTAITEMENTRADAALMACEN.AcceptChanges()
                            End If
                            pivoteSeleccionarEquipos = False
                            Exit For
                        End If
                    Next
                Next
            End If

            ' abrir formulario de traslados
            formtrasladar.AccionEquipos = EditarEquipos
            formtrasladar.IDSALIDAALMACENMODIFICANDO = Cb_Relación.SelectedValue
            formtrasladar.IDENTRADAALMACENMODIFICANDO = IDENTRADAALMACENMODIFICANDO
            Dim guardar As Boolean = False
            formtrasladar.tipoEntradaSalida = "ENTRADA"
            formtrasladar.tipoentrada = Cb_TipoEntrada.SelectedValue
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
                                Agregarautomaticamente = True
                                Dgv_item.Rows(j).Cells("CantDataGridViewTextBoxColumn").Value = Dgv_item.Rows(j).Cells("CantDataGridViewTextBoxColumn").Value + 1
                                Agregarautomaticamente = False
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
            Else
                ' regresar el DataSet de los ítems a un estado anterior
                Me.LISTAITEMENTRADAALMACEN.Clear()
                For k = 0 To tablaitemsReset.Rows.Count - 1
                    Dim fila1 As DataRow
                    fila1 = tablaitemsReset.Rows(k)
                    Dim Fila As DataRow
                    Fila = Me.LISTAITEMENTRADAALMACEN.NewRow
                    For l = 0 To tablaitemsReset.Columns.Count - 1
                        Fila(l) = fila1(l)
                    Next
                    Me.LISTAITEMENTRADAALMACEN.Rows.Add(Fila)
                Next
            End If
        End If
    End Sub

    Public Sub AgregarArticulo(ByVal IDARTICULO As Integer)
        ' Validar Artículo
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

            FilasArticulos = articulos.Select("ID=" + IDARTICULO.ToString)
            If FilasArticulos.Length > 0 Then

                Dim FilaArticulo As DataRow
                FilaArticulo = FilasArticulos(0)
                Dim FilaNueva As DataRow
                FilaNueva = Me.LISTAITEMENTRADAALMACEN.NewRow
                FilaNueva("Item") = Me.LISTAITEMENTRADAALMACEN.Rows.Count + 1
                FilaNueva("Código") = IDARTICULO
                FilaNueva("Descripción") = FilaArticulo("NOMBRE")
                FilaNueva("Requisición") = DBNull.Value
                FilaNueva("Item RQ") = DBNull.Value
                FilaNueva("Und") = FilaArticulo("UND")
                FilaNueva("Cant") = 1
                FilaNueva("IDREQUISICION") = DBNull.Value

                LISTAITEMENTRADAALMACEN.Rows.Add(FilaNueva)
                Dim filaultima As Integer = LISTAITEMENTRADAALMACEN.Rows.Count - 1

                LISTAITEMENTRADAALMACEN.Rows(filaultima).Item("Código") = FilaNueva("Código")
                LISTAITEMENTRADAALMACEN.Rows(filaultima).Item("Descripción") = FilaNueva("Descripción")

                If IsDBNull(FilaNueva("Requisición")) = False Then
                    LISTAITEMENTRADAALMACEN.Rows(filaultima).Item("Requisición") = FilaNueva("Requisición")
                End If
                If IsDBNull(FilaNueva("Item RQ")) = False Then
                    LISTAITEMENTRADAALMACEN.Rows(filaultima).Item("Item_RQ") = FilaNueva("Item RQ")
                End If
                If IsDBNull(FilaNueva("IDREQUISICION")) = False Then
                    LISTAITEMENTRADAALMACEN.Rows(filaultima).Item("IDREQUISICION") = FilaNueva("IDREQUISICION")
                End If

                LISTAITEMENTRADAALMACEN.Rows(filaultima).Item("Und") = FilaNueva("Und")
                LISTAITEMENTRADAALMACEN.Rows(filaultima).Item("Cant") = FilaNueva("Cant")
            End If
        End If
    End Sub


    Private Sub Dgv_item_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_item.CellValueChanged
        ' si se edita la celda se vuelve a cambiar el valor de verificación de equipos a falso
        Select Case Cb_TipoEntrada.SelectedValue
            Case "T", "S"
                If pivoteSeleccionarEquipos = False And Agregarautomaticamente = False Then
                    validacionequipos = True
                End If
        End Select
    End Sub

    Private Sub LimpiarTablas()
        If pivoteSeleccionarEquipos = False Then
            tablaequipos.Rows.Clear()
            tablacomponentes.Rows.Clear()
            tablacomponentesfin.Rows.Clear()
            tablaequiposfin.Rows.Clear()
            equiposborrados = True
        End If
    End Sub

    Private Sub CorreoAComprador(ByVal IDENTRADAALMACEN As Integer)
        Dim Cadena_Consulta As String = ""
        Dim Dt_EntradaAlmacen As DataTable
        Dim FilaEntradaAlmacen As DataRow
        Dim textoContenido As New System.Text.StringBuilder
        Dim correoDestino As String = ""
        Dim asunto As String = ""
        Dim ContadorItems As Integer = 0
        Dim FilaEA As DataRow

        Cadena_Consulta += "SELECT EA.ENTRADAALMACEN, EA.BODEGA, "
        Cadena_Consulta += "EA.ORDENCOMPRA, EA.IDITEMENTRADAALMACEN, RTRIM(EA.ABREVIATURA) AS ABREVIATURA, EA.IDARTICULO, EA.DESCRIPCION, "
        Cadena_Consulta += "EA.CANTIDAD, EA.COMPRADO ,RTRIM(U.CORREOELECTRONICOCORPORTATIVO) AS CORREO, "
        Cadena_Consulta += "EA.PERSONARECIBIO, EA.PERSONAVERIFICO, EA.PERSONAAPROBO, EA.REQUISICION, EA.PERSONACOMPRA, EA.NOMBREPROVEEDOR, EA.NOREMISION, OC.FECHAENTREGA, "
        Cadena_Consulta += "EA.FECHARECIBIDO, EA.IDBODEGA, B.CORREOELECTRONICOCOMPRA "
        Cadena_Consulta += "FROM dbo.ImpresionEntradaAlmacen(" + CStr(IDENTRADAALMACEN) + ") EA, ORDENCOMPRA OC, ITEMENTRADAALMACEN IEA, USUARIO U, BODEGA B "
        Cadena_Consulta += "WHERE IEA.IDENTRADAALMACEN = " + CStr(IDENTRADAALMACEN) + " "
        Cadena_Consulta += "AND OC.IDORDENCOMPRA = IEA.IDORDENCOMPRA "
        Cadena_Consulta += "AND U.IDPERSONA = OC.IDPERSONACOMPRA AND B.IDBODEGA = EA.IDBODEGA "
        Cadena_Consulta += "GROUP BY EA.ENTRADAALMACEN, EA.BODEGA, "
        Cadena_Consulta += "EA.ORDENCOMPRA, EA.IDITEMENTRADAALMACEN, EA.ABREVIATURA, EA.IDARTICULO, EA.DESCRIPCION,"
        Cadena_Consulta += "EA.CANTIDAD, EA.COMPRADO, U.CORREOELECTRONICOCORPORTATIVO, EA.PERSONARECIBIO, EA.PERSONAVERIFICO, EA.PERSONAAPROBO, EA.REQUISICION, "
        Cadena_Consulta += "EA.PERSONACOMPRA, EA.NOMBREPROVEEDOR, EA.NOREMISION, OC.FECHAENTREGA, EA.FECHARECIBIDO, EA.IDBODEGA, B.CORREOELECTRONICOCOMPRA"

        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Dt_EntradaAlmacen = New DataTable
        Adaptador.FillSchema(Dt_EntradaAlmacen, SchemaType.Source)
        Adaptador.Fill(Dt_EntradaAlmacen)
        Consulta.Connection.Close()
        FilaEntradaAlmacen = Dt_EntradaAlmacen.Rows(0)

        Dim CantidadFaltante As Double
        For i As Integer = 0 To Dt_EntradaAlmacen.Rows.Count - 1
            Dim cadena_consulta2 As String = " select dbo.EntradaParcial(@IdEntrada, @IdArticulo)"
            Dim consulta2 As New SqlClient.SqlCommand(cadena_consulta2, Conexión)
            consulta2.Parameters.AddWithValue("@IdEntrada", IDENTRADAALMACEN)
            consulta2.Parameters.AddWithValue("@IdArticulo", Dt_EntradaAlmacen.Rows(i).Item("IDITEMENTRADAALMACEN").ToString)
            consulta2.Connection.Open()
            CantidadFaltante = consulta2.ExecuteScalar()
            consulta2.Connection.Close()
        Next

        Dim entradaparcial As String
        If CantidadFaltante > 0 Then
            entradaparcial = "Entrada Parcial"
        Else
            entradaparcial = "Orden Completa Para Facturacion"
        End If

        Dim mail As New MailMessage
        If VariablesBase.VariablesBase.NombreBaseDatos = "ISMOCOLPRODUCCION" Then

            correoDestino = Dt_EntradaAlmacen.Rows(0)("CORREO").ToString()

            'If FuncionesBase.FuncionesBase.EsBodegaPrincipal(Dt_EntradaAlmacen.Rows(0)("IDBODEGA").ToString()) = True Then
            '    mail.Bcc.Add("compras7@ismocol.com")
            'Else
            '    mail.Bcc.Add("compras5@ismocol.com")
            'End If

            mail.Bcc.Add("compras@ismocol.com")
            If CStr(Trim(FilaEntradaAlmacen("CORREOELECTRONICOCOMPRA"))) <> "" Then
                'Correo destino Compra Bodega
                mail.Bcc.Add(New MailAddress(CStr(Trim(FilaEntradaAlmacen("CORREOELECTRONICOCOMPRA")))))
            End If

        Else
            correoDestino = "soporteaplicaciones@ismocol.com"
        End If

        asunto = "Se creó la entrada de almacén  " + CStr(Trim(FilaEntradaAlmacen("ENTRADAALMACEN")))

        textoContenido.AppendLine("<div style='padding:10px; max-width:1000px;'>")
        textoContenido.AppendLine("    <table style='width:100%;' border='1'>")
        textoContenido.AppendLine("        <tr style='border:1px solid; text-align:center;'>")
        textoContenido.AppendLine("            <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='100px'/></td>")
        textoContenido.AppendLine("            <td><center><b>SISTEMA DE MATERIALES</b></center></td>")
        textoContenido.AppendLine("            <td><center><b>Entrada de almacén</b> " + CStr(Trim(FilaEntradaAlmacen("ENTRADAALMACEN"))) + "</center></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("    </table>")

        textoContenido.AppendLine("    <p>")
        textoContenido.AppendLine("    <table border='1' style='width:100%;'>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td colspan='2'><center><b>ENTRADA DE ALMACEN</b></center><p><center>" + Trim(FilaEntradaAlmacen("ENTRADAALMACEN")) + "</center></p>")
        textoContenido.AppendLine("            <td colspan='2'><center><b>FECHA RECIBIDO</b></center><p><center>" + Trim(FilaEntradaAlmacen("FECHARECIBIDO")) + "</center></p>")
        textoContenido.AppendLine("        </tr>")

        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td style ='width:25%;'><b> BODEGA</b><p><center>" + Trim(FilaEntradaAlmacen("BODEGA")) + "</center></p></td>")
        textoContenido.AppendLine("            <td style ='width:25%;'><b> REQUISICIÓN No.</b><p><center>" + Trim(FilaEntradaAlmacen("REQUISICION")) + "</center></p></td>")
        textoContenido.AppendLine("            <td style ='width:25%;'><b> ORDEN DE COMPRA No.</b><p><center>" + Trim(FilaEntradaAlmacen("ORDENCOMPRA")) + "</center></p></td>")
        textoContenido.AppendLine("            <td style ='width:25%;'><b> FECHA ENTREGA</b><p><center>" + Trim(FilaEntradaAlmacen("FECHAENTREGA")) + "</center></p></td>")
        textoContenido.AppendLine("        </tr>")

        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td colspan='2'><b>PROVEEDOR</b><p><center>" + Trim(FilaEntradaAlmacen("NOMBREPROVEEDOR")) + "</center><p></td>")
        textoContenido.AppendLine("            <td colspan='2'><b>COMPRADOR</b><p><center>" + Trim(FilaEntradaAlmacen("PERSONACOMPRA")) + "</center><p></td>")
        textoContenido.AppendLine("        </tr>")

        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td colspan='4'><b>Estado</b><p><center>" + entradaparcial + "</center><p></td>")
        textoContenido.AppendLine("        </tr>")

        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("    </p>")

        textoContenido.AppendLine("    <table border= '1'>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td width='40'><center><b>ÍTEM</b></center></td>")
        textoContenido.AppendLine("            <td width='50'><center><b>UNIDAD</b></center></td>")
        textoContenido.AppendLine("            <td width='50'><center><b>CÓDIGO</b></center></td>")
        textoContenido.AppendLine("            <td width='760'><center><b>DESCRIPCIÓN</b></center></td>")
        textoContenido.AppendLine("            <td width='50'><center><b>CANTIDAD</b></center></td>")
        textoContenido.AppendLine("            <td width='50'><center><b>CANTIDAD OC</b></center></td>")
        textoContenido.AppendLine("        </tr>")
        For i = ContadorItems To Dt_EntradaAlmacen.Rows.Count - 1
            FilaEA = Dt_EntradaAlmacen.Rows(i)

            textoContenido.AppendLine("        <tr>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("IDITEMENTRADAALMACEN")) + "</td>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("ABREVIATURA")) + "</td>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("IDARTICULO")) + "</td>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("DESCRIPCION")) + "</td>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("CANTIDAD")) + "</td>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("COMPRADO")) + "</td>")
            textoContenido.AppendLine("        </tr>")
            ContadorItems = ContadorItems + 1
        Next
        textoContenido.AppendLine("    </table>")

        textoContenido.AppendLine("    <p>")
        textoContenido.AppendLine("    <table style='width:100%;' border='1'>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><center><b>RECIBIDO POR</b></center></td>")
        textoContenido.AppendLine("            <td><center><b>VERIFICADO POR</b></center></td>")
        textoContenido.AppendLine("            <td><center><b>APROBADO POR</b></center></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><center>" + Trim(FilaEntradaAlmacen("PERSONARECIBIO")) + "</center></td>")
        textoContenido.AppendLine("            <td><center>" + Trim(FilaEntradaAlmacen("PERSONAVERIFICO")) + "</center></td>")
        textoContenido.AppendLine("            <td><center>" + Trim(FilaEntradaAlmacen("PERSONAAPROBO")) + "</center></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("    </p>")

        textoContenido.AppendLine("    <tr>")
        textoContenido.AppendLine("        <td colspan='3'>Por favor no contestar el e-mail a esta cuenta de Correo.</td>")
        textoContenido.AppendLine("    </tr>")
        textoContenido.AppendLine("    <tr>")
        textoContenido.AppendLine("        <td colspan='3'>Para cualquier consulta comuníquese a soporteaplicaciones@ismocol.com</td>")
        textoContenido.AppendLine("    </tr>")

        textoContenido.AppendLine("</div>")

        ' Se arma el HTML que va a llegar al correo
        Dim cuerpo As String = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>"
        cuerpo += "<html xmlns='http://www.w3.org/1999/xhtml'>"
        cuerpo += "    <head>"
        cuerpo += "        <meta http-equiv='Content-Type' content='text/html charset=utf-8' />"
        cuerpo += "        <title>REQUISICIÓN</title>"
        cuerpo += "    </head>"
        cuerpo += "    <body>"
        cuerpo += "        <center>"
        cuerpo += "        " + textoContenido.ToString()
        cuerpo += "        </center>"
        cuerpo += "    </body>"
        cuerpo += "</html>"

        '********************************************** Envío de mail ************************************************/

        Dim strSMTP As String = "smtp.gmail.com"
        'revisar conteo para cambiar de correo cuando se llegue a 450 enviados
        Dim correoOrigen As String = "informacion-noreplicar@ismocol.com"
        Dim correoOrigenClave As String = "Sap753150"

        Dim SmtpServer As New SmtpClient("smtp.gmail.com", 587)
        SmtpServer.UseDefaultCredentials = False
        SmtpServer.Credentials = New Net.NetworkCredential(correoOrigen, correoOrigenClave)
        SmtpServer.EnableSsl = True
        mail.To.Add(correoDestino)
        mail.From = New MailAddress(correoOrigen)
        mail.Subject = asunto
        mail.Body = cuerpo
        mail.IsBodyHtml = True
        mail.Priority = MailPriority.Normal
        'QUITAR PARA QUE FUNCIONE
        SmtpServer.Send(mail)
        MsgBox("Se envió notificación al correo " + Trim(correoDestino), MsgBoxStyle.Information, "Entrada de Almacén")

    End Sub

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
                    filas = Me.LISTAITEMENTRADAALMACEN.Select("Código=" + IdArticuloLEctor)
                    If filas.Length > 0 Then ' ya existe el id articulo en la lista
                        Dim fila As DataRow
                        fila = filas(0)
                        fila("Cant") = fila("Cant") + 1
                    Else 'no existe agregar
                        AgregarArticulo(IdArticuloLEctor)
                    End If
                    Tx_lectora.Clear()
                    Tx_lectora.Focus()
                    LISTAITEMENTRADAALMACEN.AcceptChanges()
                    Me.Cb_TipoEntrada.Enabled = False
                Catch ex As Exception
                    System.Media.SystemSounds.Exclamation.Play()
                Finally
                    e.SuppressKeyPress = True
                    Tx_lectora.Clear()
                    Tx_lectora.Focus()
                End Try
        End Select

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


End Class