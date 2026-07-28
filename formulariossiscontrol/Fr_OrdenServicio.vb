Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_OrdenServicio
    Private DsOrdenServicio As New DatosSisControl.Ds_Siscontrol

    'Private SC_BaseTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_BASETableAdapter
    'Private sc_DependenciaTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_DEPENDENCIATableAdapter
    'Private SC_CONTRATISTATableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_CONTRATISTATableAdapter
    'Private MA_TIPOMONEDATableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.MA_TIPOMONEDATableAdapter

    Public IdOrdenServicio As Integer = -1
    Public IdDependencia As Integer
    Public TipoEditando As String = "C" ' N: Crear , E: Editar, C: CLonar , V: Ver
    Public CierreOrden As Boolean = False

    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter

    Private IdContratista As Integer
    Private Año As String = Year(Date.Now)
    Private Consecutivo As Integer = -1
    Private CargaDependencia As Boolean = False

    Private Fila_Contratista As DataRow
    Dim Temp_IdDependencia As Integer = -1

    Private bddatos As New FuncionesBase.ClaseCargarMaestras

    Private dt_DependenciaSC As New DataTable
    Private dt_BaseSC As New DataTable

    Public Sub Comportamiento_Predeterminado()

    End Sub


    Public Sub CargarDatos()
        If CierreOrden Then
            Pn_Cierre.Enabled = True
            Pn_Inicial.Enabled = False
        Else
            Pn_Cierre.Enabled = False
            Pn_Inicial.Enabled = True

        End If

        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        CargarCombos()

        Select Case TipoEditando
            Case "E", "V"
                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                Dim comando As New SqlCommand("SELECT * FROM dbo.ListaOrdenServicio(@ACCION, @VARIABLE, @IDBASE)", conexion)
                comando.Parameters.AddWithValue("@ACCION", 1)
                comando.Parameters.AddWithValue("@VARIABLE", IdOrdenServicio)
                comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dtOrdenServicio As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dtOrdenServicio)
                    conexion.Close()

                    Dim fila As DataRow
                    If dtOrdenServicio.Rows.Count > 0 Then
                        fila = dtOrdenServicio.Rows(0)
                        IdOrdenServicio = fila("Id")
                        Tx_Contratista.Text = Trim(fila("Identificación"))
                        Cargar_Contratista()
                        Tx_Dirección.Text = fila("Dirección")
                        Cb_Base.SelectedValue = fila("IDBASESISCONTROL")
                        Cb_Base.Enabled = False
                        Cb_Dependencia.SelectedValue = fila("IDDEPENDENCIA")
                        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = fila("IDDEPENDENCIA")
                        CargarPersonas()
                        Cb_Dependencia.Enabled = False
                        Cu_Ciudad.Cb_Ciudad.SelectedValue = fila("CODIGOCIUDAD")
                        Dtp_Fecha.Value = fila("FECHA")
                        Dtp_Fecha.MinDate = fila("FECHA")
                        Tx_Descripción.Text = Trim(fila("Descripción"))
                        CargarPersonasPorDependencia()
                        If IsDBNull(fila("IDPERSONAACEPTA")) = True Then
                            Cb_AcepatadaPor.Checked = False
                            Cu_Aceptada.Cb_Persona.SelectedIndex = -1
                        Else
                            Cb_AcepatadaPor.Checked = True
                            Cu_Aceptada.Cb_Persona.SelectedValue = fila("IDPERSONAACEPTA")
                        End If
                        Cu_Recibido.Cb_Persona.SelectedValue = fila("IDPERSONARECIBE")
                        Cu_Solicitada.Cb_Persona.SelectedValue = fila("IDSOLICITADOPOR")
                        Me.Cu_CentroCosto1.IdCentroCosto = fila("IDCENTROCOSTO")
                        Me.Cu_CentroCosto1.Editando = 3
                        Me.Cu_CentroCosto1.CargarCentro()
                        If IsDBNull(fila("FECHAFACTURA")) = False Then
                            Dtp_FechaFactura.Value = fila("FECHAFACTURA")
                            Dtp_FechaFactura.Checked = True
                        End If
                        If IsDBNull(fila("FECHARECIBE")) = False Then
                            Dtp_FechaRecibido.Value = fila("FECHARECIBE")
                        End If
                        If IsDBNull(fila("FECHAVENCIMIENTOFACTURA")) = False Then
                            Dtp_FechaVencimiento.Value = fila("FECHAVENCIMIENTOFACTURA")
                            Dtp_FechaVencimiento.Checked = True
                        End If
                        Cb_TipoMoneda.SelectedValue = fila("CODIGOTIPOMONEDA")
                        Tx_NroFactura.Text = Trim(fila("FACTURA"))
                        If CierreOrden Then
                            Lb_Titulo.Text = "CIERRE " + Lb_Titulo.Text
                            If fila("CERRADA") = "S" Then
                                Tx_ValorCierre.Text = fila("VALORCIERRE")
                                Tx_ValorFactura.Text = fila("VALORFACTURA")
                            Else
                                Tx_ValorFactura.Text = fila("VALORFACTURA")
                            End If
                        Else
                            Tx_ValorFactura.Text = fila("VALORFACTURA")
                        End If
                        Tx_Observación.Text = fila("Observación")
                        Año = fila("Año")
                        Consecutivo = fila("Consecutivo")
                        Me.AOC.Identificador = fila("IdOrdenCompra")
                        Me.AOC.Cargar()
                        Me.AOT.Identificador = fila("IdOrdenTrabajo")
                        Me.AOT.Cargar()
                        Cb_AurorizaDctoSS.SelectedValue = fila("AUTORIZADESCTSS")

                    End If
                Catch ex As Exception
                    conexion.Close()
                    MsgBox(ex.Message)
                Finally
                    conexion.Close()
                End Try
            Case "C"
                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                Dim comando As New SqlCommand("SELECT * FROM dbo.ListaOrdenServicio(@ACCION, @VARIABLE, @IDBASE)", conexion)
                comando.Parameters.AddWithValue("@ACCION", 1)
                comando.Parameters.AddWithValue("@VARIABLE", IdOrdenServicio)
                comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dtOrdenServicio As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dtOrdenServicio)
                    conexion.Close()

                    Dim fila As DataRow
                    If dtOrdenServicio.Rows.Count > 0 Then
                        fila = dtOrdenServicio.Rows(0)
                        IdOrdenServicio = fila("Id")
                        Tx_Contratista.Text = Trim(fila("Identificación"))
                        Cargar_Contratista()
                        Tx_Dirección.Text = fila("Dirección")
                        CargarPersonas()
                        Cu_Ciudad.Cb_Ciudad.SelectedValue = fila("CODIGOCIUDAD")
                        Tx_Descripción.Text = Trim(fila("Descripción"))
                        CargarPersonasPorDependencia()
                        If IsDBNull(fila("IDPERSONAACEPTA")) = True Then
                            Cb_AcepatadaPor.Checked = False
                            Cu_Aceptada.Cb_Persona.SelectedIndex = -1
                        Else
                            Cb_AcepatadaPor.Checked = True
                            Cu_Aceptada.Cb_Persona.SelectedValue = fila("IDPERSONAACEPTA")
                        End If
                        Cu_Recibido.Cb_Persona.SelectedValue = fila("IDPERSONARECIBE")
                        Cu_Solicitada.Cb_Persona.SelectedValue = fila("IDSOLICITADOPOR")

                        If fila("CC_ACTIVO") = "S" Then
                            Me.Cu_CentroCosto1.IdCentroCosto = fila("IDCENTROCOSTO")
                        Else
                            Me.Cu_CentroCosto1.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
                        End If
                        Me.Cu_CentroCosto1.Editando = 3
                        Me.Cu_CentroCosto1.CargarCentro()

                        Cb_TipoMoneda.SelectedValue = fila("CODIGOTIPOMONEDA")

                        Año = fila("Año")
                        Dtp_Fecha.MinDate = DateAdd(DateInterval.Day, -3, Date.Now)
                        Me.AOC.Identificador = fila("IdOrdenCompra")
                        Me.AOC.Cargar()
                        Me.AOT.Identificador = fila("IdOrdenTrabajo")
                        Me.AOT.Cargar()
                    End If
                Catch ex As Exception
                    conexion.Close()
                    MsgBox(ex.Message)
                Finally
                    conexion.Close()
                End Try
            Case "N"
                Dtp_Fecha.MinDate = DateAdd(DateInterval.Day, -3, Date.Now)
                Me.Cu_CentroCosto1.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
                Me.Cu_CentroCosto1.Editando = 2
                Me.Cu_CentroCosto1.CargarCentro()
                Me.AOC.Identificador = -1
                Me.AOC.Ll_Asociar.Text = "SIN ASOCIAR OC"
                Me.AOT.Identificador = -1
                Me.AOT.Ll_Asociar.Text = "SIN ASOCIAR OT"
            Case Else
                MsgBox("Falta definir")
        End Select
    End Sub

    Dim dsCargar As New DataSet
    Private Sub CargarCombos()

        dsCargar = bddatos.CargarMaestrasSiscontrol(2, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, IdOrdenServicio, 1)
        '-- 0 --> BASE
        '-- 1 --> DEPENDENCIA
        '-- 2 --> MONEDA

        Cu_Ciudad.CargarDatos()
        Cu_Ciudad.Cb_Ciudad.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "OS", "CIDUAD", -1)

        'Me.SC_BaseTableAdapter.Fill(Me.DsOrdenServicio.SC_BASE)
        'Me.Cb_Base.DataSource = Me.DsOrdenServicio.SC_BASE
        Me.Cb_Base.DataSource = Me.dsCargar.Tables(0)
        Me.Cb_Base.DisplayMember = "BASE"
        Me.Cb_Base.ValueMember = "IDBASESISCONTROL"
        Me.Cb_Base.SelectedValue = VariablesBase.VariablesBase.IdBaseSiscontrolActual

        'Me.sc_DependenciaTableAdapter.Fill(DsOrdenServicio.SC_DEPENDENCIA, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        'Me.Cb_Dependencia.DataSource = Me.DsOrdenServicio.SC_DEPENDENCIA
        Me.Cb_Dependencia.DataSource = Me.dsCargar.Tables(1)
        Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
        Me.Cb_Dependencia.SelectedValue = VariablesBase.VariablesBase.IddependenciaSiscontrolActual

        'MA_TIPOMONEDATableAdapter.Fill(Me.DsOrdenServicio.MA_TIPOMONEDA)
        'Me.Cb_TipoMoneda.DataSource = Me.DsOrdenServicio.MA_TIPOMONEDA
        Me.Cb_TipoMoneda.DataSource = Me.dsCargar.Tables(2)
        Me.Cb_TipoMoneda.DisplayMember = "NOMBRETIPOMONEDA"
        Me.Cb_TipoMoneda.ValueMember = "CODIGOTIPOMONEDA"

        Cb_AurorizaDctoSS.DataSource = dsCargar.Tables(3)
        Cb_AurorizaDctoSS.ValueMember = "CODIGO"
        Cb_AurorizaDctoSS.DisplayMember = "NOMBRE"
        Cb_AurorizaDctoSS.SelectedIndex = -1

        Select Case TipoEditando
            Case "N", "C"
                Dtp_Fecha.MaxDate = DateAdd(DateInterval.Month, 3, Date.Now)
                Dtp_FechaFactura.MaxDate = Date.Now
                Dtp_FechaRecibido.MaxDate = Date.Now
        End Select

        CargarPersonas()
    End Sub


    Private Sub CargarPersonas()
        Cu_Recibido.CargarDatos()
        Cu_Aceptada.CargarDatos()
        Cu_Solicitada.CargarDatos()

        Cu_Recibido.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "OS", "ACEPTA", -1)
        Cu_Aceptada.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "OS", "SOLICITADO", -1)
        Cu_Solicitada.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "OS", "RECIBIDO", -1)
    End Sub


    Private Sub Bt_Guardar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Guardar.Click
        If ValidarOrdenServicio() Then
            GuardarOrdenServicio()
        End If
    End Sub


    Private Sub GuardarOrdenServicio()
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarOrdenServicio")
        Comando.CommandType = CommandType.StoredProcedure

        Select Case TipoEditando
            Case "N", "C"
                Comando.Parameters.AddWithValue("@TIPO", 1)
            Case Else
                Comando.Parameters.AddWithValue("@TIPO", 2)
        End Select

        Comando.Parameters.AddWithValue("@IDORDENESSERVICIO", IdOrdenServicio)
        Comando.Parameters.AddWithValue("@AÑO", Año)
        Comando.Parameters.AddWithValue("@CONSECUTIVO", Consecutivo)
        Comando.Parameters.AddWithValue("@IDCONSTRATISTA", IdContratista)
        Comando.Parameters.AddWithValue("@NOMBRE", UCase(Trim(Tx_NombreContratista.Text)))
        Comando.Parameters.AddWithValue("@CODIGOCIUDAD", Cu_Ciudad.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHA", Dtp_Fecha.Value)
        Comando.Parameters.AddWithValue("@DIRECCION", UCase(Trim(Tx_Dirección.Text)))
        Comando.Parameters.AddWithValue("@IDBASESISCONTROL", Cb_Base.SelectedValue)
        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencia.SelectedValue)
        Comando.Parameters.AddWithValue("@DESCRIPCION", UCase(Trim(Tx_Descripción.Text)))
        Comando.Parameters.AddWithValue("@IDSOLICITADOPOR", Cu_Solicitada.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDCENTROCOSTO", Me.Cu_CentroCosto1.IdCentroCosto)
        Comando.Parameters.AddWithValue("@IDORDENCOMPRA", Me.AOC.Identificador)
        Comando.Parameters.AddWithValue("@IDORDENTRABAJO", Me.AOT.Identificador)

        If CierreOrden = False Then
            Comando.Parameters.AddWithValue("@IDPERSONARECIBE", DBNull.Value)
            Comando.Parameters.AddWithValue("@FECHARECIBE", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@IDPERSONARECIBE", Cu_Recibido.Cb_Persona.SelectedValue)
            Comando.Parameters.AddWithValue("@FECHARECIBE", Dtp_FechaRecibido.Value)
        End If

        Comando.Parameters.AddWithValue("@FACTURA", UCase(Trim(Tx_NroFactura.Text)))

        If Dtp_FechaFactura.Checked = True Then
            Comando.Parameters.AddWithValue("@FECHAFACTURA", Dtp_FechaFactura.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAFACTURA", DBNull.Value)
        End If

        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAREGISTRO", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAMODIFICACION", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAANULA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAANULACION", Date.Now)
        Comando.Parameters.AddWithValue("@ANULADA", "N")

        If Dtp_FechaVencimiento.Checked = True Then
            Comando.Parameters.AddWithValue("@FECHAVENCIMIENTOFACTURA", Dtp_FechaVencimiento.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAVENCIMIENTOFACTURA", DBNull.Value)
        End If

        Comando.Parameters.AddWithValue("@OBSERVACION", UCase(Tx_Observación.Text))
        Comando.Parameters.AddWithValue("@IMPRESA", "N")

        If Cb_AcepatadaPor.Checked = True Then
            Comando.Parameters.AddWithValue("@IDPERSONAACEPTA", Cu_Aceptada.Cb_Persona.SelectedValue)
        Else
            Comando.Parameters.AddWithValue("@IDPERSONAACEPTA", DBNull.Value)
        End If

        Comando.Parameters.AddWithValue("@CODIGOTIPOMONEDA", Cb_TipoMoneda.SelectedValue)

        If CierreOrden Then
            Comando.Parameters.AddWithValue("@CERRADA", "S")
            Comando.Parameters.AddWithValue("@VALORCIERRE", CDec(Trim(Tx_ValorCierre.Text)))
            Comando.Parameters.AddWithValue("@VALORFACTURA", CDec(Trim(Tx_ValorFactura.Text)))
            Comando.Parameters.AddWithValue("@AUTORIZADESCTSS", Cb_AurorizaDctoSS.SelectedValue)
        Else
            Comando.Parameters.AddWithValue("@CERRADA", "N")
            Comando.Parameters.AddWithValue("@VALORCIERRE", CDec("0,0"))
            Comando.Parameters.AddWithValue("@VALORFACTURA", CDec(Trim(Tx_ValorFactura.Text)))
            Comando.Parameters.AddWithValue("@AUTORIZADESCTSS", DBNull.Value)
        End If


        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        conn.Close()

        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "OS", "BASE", Cb_Base.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "OS", "DEPENDENCIA", Cb_Dependencia.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "OS", "ACEPTA", Cu_Aceptada.Cb_Persona.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "OS", "SOLICITADO", Cu_Solicitada.Cb_Persona.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "OS", "RECIBIDO", Cu_Recibido.Cb_Persona.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "OS", "IDCENTROCOSTO", Me.Cu_CentroCosto1.IdCentroCosto)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "OS", "CIDUAD", Cu_Ciudad.Cb_Ciudad.SelectedValue)

        Me.Close()

        If MsgBox("¿Desea imprimir la Orden de Servicio?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
            Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
            Dim Array As New ArrayList
            Array.Add(70)
            If MsgBox("¿Desea imprimir formato completo?", MsgBoxStyle.YesNo, "Formato") = MsgBoxResult.Yes Then
                climpresiones.Formatoorden = True
            End If

            Select Case TipoEditando
                Case "N", "C"
                    climpresiones.IdOrdenServicio = msgParam.Value
                Case Else
                    climpresiones.IdOrdenServicio = IdOrdenServicio
            End Select

            If CierreOrden Then
                climpresiones.OrdenCierre = True
            End If

            climpresiones.FormatoImprimirSisControl(Array, True, False)
            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
        End If

        If CierreOrden Then
            If Cb_AurorizaDctoSS.SelectedValue <> "X" Then
                If MsgBox("¿Desea subir el Documento de Autorización Descuentos de Seguridad Social?", MsgBoxStyle.YesNo, "SUBIR DOCUMENTO ICA-GRAL-F-193") = MsgBoxResult.Yes Then

                    Dim FrArchivoSS As New FormulariosSisControl.Fr_ArchivoSS
                    FrArchivoSS.CargarTablas()
                    FrArchivoSS.Tipo = "OS"

                    Select Case TipoEditando
                        Case "N", "C"
                            FrArchivoSS.IdDocumento = msgParam.Value
                        Case Else
                            FrArchivoSS.IdDocumento = IdOrdenServicio
                    End Select

                    FrArchivoSS.ShowDialog()
                End If

            End If
        End If
    End Sub


    Private Function ValidarOrdenServicio() As Boolean
        If Tx_Contratista.Text = "" Then
            MsgBox("Debe agregar un contratista", MsgBoxStyle.Critical, "IDENTIFICACIÓN CONTRATISTA")
            Me.Tx_Contratista.Focus()
            ValidarOrdenServicio = False
            Exit Function
        End If

        If Tx_Descripción.Text = "" Then
            MsgBox("Agregue una descripción", MsgBoxStyle.Critical, "DESCRIPCIÓN")
            Me.Tx_Descripción.Focus()
            ValidarOrdenServicio = False
            Exit Function
        End If

        If Tx_Dirección.Text = "" Then
            MsgBox("Agregue la dirección del contratista", MsgBoxStyle.Critical, "DIRECCIÓN")
            Me.Tx_Descripción.Focus()
            ValidarOrdenServicio = False
            Exit Function
        End If

        If IsNumeric(Tx_ValorFactura.Text) = False Then
            MsgBox("El valor del servicio debe ser numérico", MsgBoxStyle.Critical, "VALOR FACTURA")
            Tx_ValorFactura.Text = ""
            Me.Tx_ValorFactura.Focus()
            ValidarOrdenServicio = False
            Exit Function
        End If

        If Cb_AcepatadaPor.Checked = True Then
            If Me.Cu_Aceptada.Cb_Persona.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la persona que acepta la Orden de Servicio por parte del contratista, si no cuenta con esta información, quitar el chequeo", MsgBoxStyle.Critical, "ACEPTA")
                Me.Cu_Aceptada.Cb_Persona.Focus()
                ValidarOrdenServicio = False
                Exit Function
            End If
        End If

        If IsNothing(Cu_Solicitada.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione la persona que solicitó", MsgBoxStyle.Critical, "SOLICITA")
            Cu_Solicitada.Cb_Persona.Focus()
            ValidarOrdenServicio = False
            Exit Function
        End If

        If IsNothing(Cu_Ciudad.Cb_Ciudad.SelectedValue) Then
            MsgBox("Seleccione la ciudad donde se ejecutó el servicio", MsgBoxStyle.Critical, "CIUDAD")
            Cu_Ciudad.Cb_Ciudad.Focus()
            ValidarOrdenServicio = False
            Exit Function
        End If

        If CierreOrden = True Then
            If IsNothing(Cu_Recibido.Cb_Persona.SelectedValue) Then
                MsgBox("Seleccione la persona que recibió", MsgBoxStyle.Critical, "RECIBIÓ")
                Cu_Recibido.Cb_Persona.Focus()
                ValidarOrdenServicio = False
                Exit Function
            End If
        End If

        If Cu_CentroCosto1.IdCentroCosto <= 0 Then
            MsgBox("Seleccione el centro de costos", MsgBoxStyle.Critical, "CENTRO DE COSTOS")
            Cu_CentroCosto1.Focus()
            ValidarOrdenServicio = False
            Exit Function
        End If

        If CierreOrden = True Then
            If Cb_AurorizaDctoSS.SelectedIndex < 0 Then
                MsgBox("Seleccione una opción de Autoriza Dcto SS", MsgBoxStyle.Information, "AUTORIZA DCTO SS")
                Cb_AurorizaDctoSS.Focus()
                ValidarOrdenServicio = False
                Exit Function
            End If
        End If

        ValidarOrdenServicio = True
    End Function


    Private Sub Bt_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub


    Private Sub Tx_Contratista_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(Tx_Contratista.Text) = False Then
            Tx_Contratista.Text = ""
        End If
        If e.KeyChar = Convert.ToChar(Windows.Forms.Keys.Return) Then
            Cargar_Contratista()
        End If
    End Sub


    Public Sub Cargar_Contratista()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Tx_Contratista.Text = Trim(Replace(Replace(Tx_Contratista.Text, ".", ""), ",", ""))
        'Me.SC_CONTRATISTATableAdapter.FillIDENTIFICACION(Me.DsOrdenServicio.SC_CONTRATISTA, Tx_Contratista.Text)
        'If Me.DsOrdenServicio.SC_CONTRATISTA.Count > 0 Then
        comando = New SqlCommand("SELECT * FROM DatosContratista(@IDENTIFICACION)", conexion)
        comando.Parameters.AddWithValue("@IDENTIFICACION", Trim(Tx_Contratista.Text))
        adaptador = New SqlDataAdapter(comando)
        Dim dtContratista As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtContratista)
            conexion.Close()
            If dtContratista.Rows.Count > 0 Then
                Fila_Contratista = dtContratista.Rows(0)
                'Fila_Contratista = Me.DsOrdenServicio.SC_CONTRATISTA(0)
                Me.Tx_DigVerificación.Text = Trim(Fila_Contratista("Digito Verificación"))
                Me.Tx_NombreContratista.Text = Trim(Fila_Contratista("Nombre"))
                Me.Tx_Dirección.Text = Trim(Fila_Contratista("Dirección"))
                IdContratista = Fila_Contratista("IDCONSTRATISTA")
            Else
                Me.Tx_Contratista.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("No fue posible cargar los datos del proveedor", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub


    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Me.Cu_Aceptada.Name
                Try
                    filas = Cu_Aceptada.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_Aceptada.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_Aceptada.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_Aceptada.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_Solicitada.Name
                Try
                    filas = Cu_Solicitada.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_Solicitada.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_Solicitada.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_Solicitada.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_Recibido.Name
                Try
                    filas = Cu_Recibido.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_Recibido.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_Recibido.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_Recibido.Tx_TextoCódigo.Text = ""
                End Try

        End Select
    End Sub


    Private Sub Cb_Dependencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CargaDependencia = True Then
            CargarPersonasPorDependencia()
        End If
        CargaDependencia = True
    End Sub


    Private Sub CargarPersonasPorDependencia()
        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = Cb_Dependencia.SelectedValue
        Cu_Recibido.CargarDatos()
        Cu_Aceptada.CargarDatos()
        Cu_Solicitada.CargarDatos()
    End Sub


    ''' <summary>
    ''' Para cargar al asociar una persona.
    ''' </summary>
    ''' <param name="IDPERSONA"></param>
    ''' <param name="NOMBRECOMPONENTE"></param>
    ''' <remarks></remarks>
    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_Aceptada.Cb_Persona.SelectedValue
            Me.Cu_Aceptada.CargarDatos()
            Me.Cu_Aceptada.Cb_Persona.SelectedValue = temp
            Me.Cu_Aceptada.CargarCajaTexto()
        Catch ex As Exception
        End Try

        Try
            temp = Me.Cu_Solicitada.Cb_Persona.SelectedValue
            Me.Cu_Solicitada.CargarDatos()
            Me.Cu_Solicitada.Cb_Persona.SelectedValue = temp
            Me.Cu_Solicitada.CargarCajaTexto()
        Catch ex As Exception
        End Try

        Try
            temp = Me.Cu_Recibido.Cb_Persona.SelectedValue
            Me.Cu_Recibido.CargarDatos()
            Me.Cu_Recibido.Cb_Persona.SelectedValue = temp
            Me.Cu_Recibido.CargarCajaTexto()
        Catch ex As Exception
        End Try

        Select Case NOMBRECOMPONENTE
            Case Cu_Aceptada.Name
                Me.Cu_Aceptada.Cb_Persona.SelectedValue = IDPERSONA

            Case Cu_Solicitada.Name
                Me.Cu_Solicitada.Cb_Persona.SelectedValue = IDPERSONA

            Case Cu_Recibido.Name
                Me.Cu_Recibido.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub


    Private Sub Fr_CorrespondenciaRecibida_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Temp_IdDependencia <> -1 Then
            VariablesBase.VariablesBase.IddependenciaSiscontrolActual = Temp_IdDependencia
        End If
    End Sub


    Public Sub CambiarDependenciaParaAsociar()
        Temp_IdDependencia = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        VariablesBase.VariablesBase.IddependenciaSiscontrolActual = Me.Cb_Dependencia.SelectedValue
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        MsgBox(sender.tag)
    End Sub


    Private Sub Cb_AcepatadaPor_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Cb_AcepatadaPor.Checked = False Then
            Me.Cu_Aceptada.Cb_Persona.SelectedIndex = -1
            Me.Cu_Aceptada.Enabled = False
        Else
            Me.Cu_Aceptada.Enabled = True
        End If
    End Sub
    Private Sub Bt_BuscarDeContratista_Click_1(sender As System.Object, e As System.EventArgs) Handles Bt_BuscarDeContratista.Click
        Dim fr_buscarcontratista As New Fr_BuscarContratista
        fr_buscarcontratista.Cargar_Tabla()
        fr_buscarcontratista.ShowDialog()
        Try
            Me.Tx_Contratista.Text = fr_buscarcontratista.Identificacion
            Cargar_Contratista()
        Catch ex As Exception
        End Try
    End Sub




    Private Sub cb_base_selectedindexchanged(sender As System.Object, e As System.EventArgs) Handles Cb_Base.SelectedIndexChanged
        ActualizarDependencias()
    End Sub

    Private Sub ActualizarDependencias()

        Try
            Dim cn As New SqlConnection(My.Settings.CadenaConexión)
            Dim cmd As String = "SELECT D.IDDEPENDENCIA,LTRIM(RTRIM(D.NOMBREDEPENDENCIA)) AS NOMBREDEPENDENCIA FROM SC_FUNCIONARIOS AS F " +
            " JOIN SC_DEPENDENCIA AS D ON D.IDDEPENDENCIA = F.IDDEPENDENCIA JOIN SC_BASE AS B ON B.IDBASESISCONTROL = D.IDBASESISCONTROL " +
            " WHERE F.IDPERSONA = " & VariablesBase.VariablesBase.IdPersona & " AND F.ACTIVO = 'S' AND B.ACTIVO = 'S' AND D.ACTIVO = 'S' And B.IDBASESISCONTROL = " & Cb_Base.SelectedValue.ToString & ""
            '" & Me.ComboBox1.Text & "'"
            Dim da As New SqlDataAdapter(cmd, cn)
            Dim ds As New DataSet
            da.Fill(ds)
            With Me.Cb_Dependencia
                Me.Cb_Dependencia.DataSource = ds.Tables(0)
                Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
            End With
        Catch ex As Exception
        End Try
    End Sub

End Class