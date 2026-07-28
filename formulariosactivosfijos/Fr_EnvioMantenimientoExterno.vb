Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class Fr_EnvioMantenimientoExterno
    ''' <summary>
    ''' Indica el tipo de edición.
    ''' 0: Agregar
    ''' 1: Modificar
    ''' 2: Cerrar servicio
    ''' 4: ¿Ver?
    ''' </summary>
    Public TipoEdicion As Integer
    ''' <summary>Identificador del equipo al cual se realiza el mantenimiento.</summary>
    Public IdEquipo As Integer
    ''' <summary>Identificador del envío a mantenimiento externo a gestionar.</summary>
    Public IdMantenimientoModificando As Integer = -1
    Private IdContratista As Integer
    Private conn As New SqlConnection(My.Settings.CadenaConexión)
    Private cmde As New SqlCommand
    Private da As New SqlDataAdapter
    Private datas As New DataSet
    Private Fila_Contratista As DataRow
    Private DsOrdenServicio As New DatosClasesBase.Ds_Contratista
    Private MA_TIPOMONEDATableAdapter As New DatosClasesBase.Ds_ContratistaTableAdapters.MA_TIPOMONEDATableAdapter
    Private SC_CONTRATISTATableAdapter As New DatosClasesBase.Ds_ContratistaTableAdapters.SC_CONTRATISTATableAdapter


    Public Sub New()
        InitializeComponent()
        AddHandler Tx_ValorAseguradora.KeyPress, AddressOf FuncionesBase.FuncionesBase.TextBoxMoneda_KeyPress
        AddHandler Tx_ValorAseguradora.LostFocus, AddressOf FuncionesBase.FuncionesBase.TextBoxMoneda_Lostfocus
    End Sub

    Public Sub Comportamiento_Predeterminado()
        Dim puedeSeleccionarTipoEnvio As Boolean = FuncionesBase.FuncionesBase.ConsultarPermiso(Cb_TipoEnvio.Tag)
        Cb_TipoEnvio.Enabled = puedeSeleccionarTipoEnvio
        Lb_TipoEnvio.Enabled = puedeSeleccionarTipoEnvio
        'Pn_TipoEnvio.Visible = puedeSeleccionarTipoEnvio
    End Sub

    Private Sub Bt_BuscarDeContratista_Click(sender As Object, e As EventArgs) Handles Bt_BuscarDeContratista.Click
        Dim fr_buscarcontratista As New FormulariosClasesBase.Fr_BuscarContratista
        fr_buscarcontratista.Cargar_Tabla()
        fr_buscarcontratista.ShowDialog()
        Try
            Tx_Contratista.Text = fr_buscarcontratista.Identificacion
            Cargar_Contratista()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CargarComponentesFormularios()
        Dim dtTipoEnvio As New DataTable
        dtTipoEnvio.Columns.Add("CODIGO")
        dtTipoEnvio.Columns.Add("NOMBRE")
        dtTipoEnvio.Rows.Add("E", "Exportación")
        dtTipoEnvio.Rows.Add("I", "Importación")
        dtTipoEnvio.Rows.Add("N", "No Aplica")
        Cb_TipoEnvio.DataSource = dtTipoEnvio
        Cb_TipoEnvio.ValueMember = "CODIGO"
        Cb_TipoEnvio.DisplayMember = "NOMBRE"
        Cb_TipoEnvio.SelectedValue = "N"
        Comportamiento_Predeterminado()
        Cu_Ciudad.CargarDatos()
        MA_TIPOMONEDATableAdapter.Fill(DsOrdenServicio.MA_TIPOMONEDA)
        Cb_TipoMoneda.DataSource = DsOrdenServicio.MA_TIPOMONEDA
        Cb_TipoMoneda.DisplayMember = "NOMBRETIPOMONEDA"
        Cb_TipoMoneda.ValueMember = "CODIGOTIPOMONEDA"
        CargarPersonas()
        CargarListaEstados(0)
        CargarListaEstados(1)
        Pn_Cierre.Enabled = False
        Select Case TipoEdicion
            Case 0 'Crear
                Dtp_FechaRecibido.MinDate = Date.Now
                Dtp_FechaMantenimientoExt.MaxDate = Date.Now
                Cb_TipoEnvio.Enabled = True
            Case 1 'Modificar
                Cb_TipoEnvio.Enabled = False
            Case 2 'Cerrar servicio
                Pn_Cierre.Enabled = True
                Dtp_FechaRecibido.MinDate = DateAdd(DateInterval.Minute, 1, Dtp_FechaEnvio.Value)
                Dtp_FechaMantenimientoExt.MaxDate = DateAdd(DateInterval.Minute, 10, Dtp_FechaMantenimientoExt.Value)
                Cb_TipoEnvio.Enabled = False
            Case 4 'Ver

        End Select
        'Consultar valor de referencia del equipo
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT dbo.ValorReferenciaDeEquipo(@IDEQUIPO)", conexion)
        comando.Parameters.AddWithValue("@IDEQUIPO", IdEquipo)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt_ValorReferencia As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dt_ValorReferencia)
            conexion.Close()
            If Not IsDBNull(dt_ValorReferencia.Rows(0).Item(0)) Then
                Tx_ValorAseguradora.Text = Format(dt_ValorReferencia.Rows(0).Item(0), "C")
                If dt_ValorReferencia.Rows(0).Item(0) > 10000 Then
                    Tx_ValorAseguradora.Enabled = False
                End If
            Else
                Tx_ValorAseguradora.Text = ""
            End If
        Catch ex As Exception
            Tx_ValorAseguradora.Text = ""
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub CargarPersonas()
        Cu_Recibido.CargarDatos()
        Cu_Solicitada.CargarDatos()
        Cu_Aprobada.CargarDatos()
        Cu_Recibido.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "ME", "RECIBIDO", -1)
        Cu_Solicitada.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "ME", "SOLICITADO", -1)
        Cu_Aprobada.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "ME", "APROBADO", -1)
    End Sub

    Public Sub Cargar_Datos_Editar_Ver()
        cmde = New SqlCommand("dbo.GestionarMantenimientoExterno", conn)
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Parameters.AddWithValue("@accion", 7)
        cmde.Parameters.AddWithValue("@IDMANTENIMIENTOEXTERNO", IdMantenimientoModificando)
        cmde.Parameters.AddWithValue("@IDEQUIPO", DBNull.Value)
        cmde.Parameters.AddWithValue("@IDESTADOPARAUSOENVIO", DBNull.Value)
        cmde.Parameters.AddWithValue("@IDCONTRATISTA", DBNull.Value)
        cmde.Parameters.AddWithValue("@NOMBRE", "")
        cmde.Parameters.AddWithValue("@CODIGOCIUDAD", "")
        cmde.Parameters.AddWithValue("@FECHAENVIO", Date.Now)
        cmde.Parameters.AddWithValue("@DIRECCIONENVIO", "")
        cmde.Parameters.AddWithValue("@VALORESTIMADO", CDec("0,0"))
        cmde.Parameters.AddWithValue("@CODIGOTIPOMONEDA", DBNull.Value)
        cmde.Parameters.AddWithValue("@IDSOLICITADOPOR", DBNull.Value)
        cmde.Parameters.AddWithValue("@DESCRIPCION", "")
        cmde.Parameters.AddWithValue("@IDBODEGA", DBNull.Value)
        cmde.Parameters.AddWithValue("@IDPERSONAREGISTRA", DBNull.Value)
        cmde.Parameters.AddWithValue("@IDPERSONAMODIFICA", DBNull.Value)
        cmde.Parameters.AddWithValue("@FECHARECIBIDO", Date.Now)
        cmde.Parameters.AddWithValue("@VALORCIERRE", CDec("0,0"))
        cmde.Parameters.AddWithValue("@IDESTADOPARAUSORECIBIDO", DBNull.Value)
        cmde.Parameters.AddWithValue("@OBSERVACION", "")
        cmde.Parameters.AddWithValue("@IDPERSONARECIBE", DBNull.Value)
        cmde.Parameters.AddWithValue("@IDPERSONACIERRA", DBNull.Value)
        cmde.Parameters.AddWithValue("@IDPERSONAANULA", DBNull.Value)
        cmde.Parameters.AddWithValue("@OBERVACIONANULACION", "")
        cmde.Parameters.AddWithValue("@VALORASEGURADORA", CDec("0,0"))
        cmde.Parameters.AddWithValue("@IDPERSONAAPRUEBA", DBNull.Value)
        cmde.Parameters.AddWithValue("@TIPOENVIO", DBNull.Value)
        cmde.Parameters.AddWithValue("@FECHADESPACHO", DBNull.Value)
        cmde.Parameters.AddWithValue("@TRANSPORTADOR", DBNull.Value)
        cmde.Parameters.AddWithValue("@CELULAR", DBNull.Value)
        cmde.Parameters.AddWithValue("@PLACAVEHICULO", DBNull.Value)
        cmde.Parameters.AddWithValue("@EMPRESATRANSPORTADORA", DBNull.Value)
        cmde.Parameters.AddWithValue("@GUIA", DBNull.Value)
        cmde.Parameters.AddWithValue("@NOMBRERESPONSABLE", DBNull.Value)
        cmde.Parameters.AddWithValue("@FECHAMANTENIMIENTOEXTERNO", DBNull.Value)
        cmde.Parameters.Add(New SqlParameter("@IDMANTENIMIENTOEXTERNONUEVO", SqlDbType.Int, 1) With {.Direction = ParameterDirection.Output})
        da = New SqlDataAdapter(cmde)
        datas = New DataSet()
        Try
            conn.Open()
            da.Fill(datas)
            conn.Close()
        Catch
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Finally
            conn.Close()
        End Try

        Dim fila As DataRow
        fila = datas.Tables(0).Rows(0)

        IdEquipo = fila("IDEQUIPO")
        Cb_TipoMantenimiento.SelectedValue = fila("IDESTADOPARAUSOENVIO")
        Cb_TipoMantenimiento.Enabled = False
        IdContratista = fila("IDCONTRATISTA")
        Tx_Contratista.Text = fila("IDENTIFICACION")
        Tx_DigitoVerificacion.Text = fila("DIGITOVERIFICACION")
        Tx_NombreContratista.Text = UCase(Trim(fila("NOMBRE")))
        Cu_Ciudad.Cb_Ciudad.SelectedValue = fila("CODIGOCIUDAD")
        Dtp_FechaEnvio.Value = fila("FECHAENVIO")
        Tx_Direccion.Text = fila("DIRECCIONENVIO")
        Tx_ValorEstimado.Text = fila("VALORESTIMADO")
        Cb_TipoMoneda.SelectedValue = fila("CODIGOTIPOMONEDA")
        Cu_Solicitada.Cb_Persona.SelectedValue = fila("IDSOLICITADOPOR")
        Cu_Aprobada.Cb_Persona.SelectedValue = fila("IDPERSONAAPRUEBA")
        Tx_Descripcion.Text = UCase(Trim(fila("DESCRIPCION")))
        If fila("CERRADA") = "S" Then
            Dtp_FechaRecibido.Value = fila("FECHARECIBIDO")
            Tx_ValorCierre.Text = fila("VALORCIERRE")
            Cb_EstadoUsoDespues.SelectedValue = fila("IDESTADOPARAUSORECIBIDO")
            Tx_Observacion.Text = fila("OBSERVACION")
            Cu_Recibido.Cb_Persona.SelectedValue = fila("IDPERSONARECIBE")

            If IsDBNull(fila("FECHAMANTENIMIENTOEXTERNO")) Then
                Dtp_FechaMantenimientoExt.Value = Date.Now
            Else
                Dtp_FechaMantenimientoExt.Value = fila("FECHAMANTENIMIENTOEXTERNO")
            End If

        Else
            Dtp_FechaRecibido.Value = Date.Now.AddMinutes(1)
            Tx_ValorCierre.Text = ""
            Cb_EstadoUsoDespues.SelectedIndex = -1
            Tx_Observacion.Text = ""
            Cu_Recibido.Cb_Persona.SelectedIndex = -1
            Dtp_FechaMantenimientoExt.Value = Date.Now.AddMinutes(1)
        End If
        If IsDBNull(fila("VALORASEGURADORA")) Then
            Tx_ValorAseguradora.Text = ""
        Else
            Dim ValorAseguradoraDecimal As Decimal = FuncionesBase.FuncionesBase.ValorRealDec(fila("VALORASEGURADORA")).ToString()
            Tx_ValorAseguradora.Text = Format(ValorAseguradoraDecimal, "C")
            Tx_ValorAseguradora.Enabled = False
        End If
        If Not IsDBNull(fila("FECHADESPACHO")) Then
            Dtp_FechaDespacho.Checked = True
            Dtp_FechaDespacho.Value = fila("FECHADESPACHO")
        Else
            Dtp_FechaDespacho.Checked = False
        End If
        If Not IsDBNull(fila("TRANSPORTADOR")) Then
            Tx_NombreTransportador.Text = fila("TRANSPORTADOR")
        End If
        If Not IsDBNull(fila("CELULAR")) Then
            Tx_CelularTransportador.Text = fila("CELULAR")
        End If
        If Not IsDBNull(fila("PLACAVEHICULO")) Then
            Tx_PlacaVehiculo.Text = fila("PLACAVEHICULO")
        End If
        If Not IsDBNull(fila("EMPRESATRANSPORTADORA")) Then
            Tx_EmpresaTransporta.Text = fila("EMPRESATRANSPORTADORA")
        End If
        If Not IsDBNull(fila("GUIA")) Then
            Tx_Guia.Text = fila("GUIA")
        End If
        If Not IsDBNull(fila("NOMBRERESPONSABLE")) Then
            Tx_NombreResponsable.Text = fila("NOMBRERESPONSABLE")
        End If
        If Not IsDBNull(fila("TIPOENVIO")) Then
            If Trim(fila("TIPOENVIO")) <> "" Then
                Cb_TipoEnvio.SelectedValue = fila("TIPOENVIO")
            Else
                Cb_TipoEnvio.SelectedValue = "N"
            End If
        Else
            Cb_TipoEnvio.SelectedValue = "N"
        End If
        Cb_TipoEnvio.Enabled = False
        Select Case TipoEdicion
            Case 2 'Cerrar servicio
                Cb_TipoMantenimiento.Enabled = False
                Tx_Contratista.Enabled = False
                Bt_BuscarDeContratista.Enabled = False
                Tx_Direccion.Enabled = False
                Cu_Ciudad.Enabled = False
                Tx_ValorEstimado.Enabled = False
                Cb_TipoMoneda.Enabled = False
                Tx_ValorAseguradora.Enabled = False
                Cu_Solicitada.Enabled = False
                Cu_AsociarPersonaSolicitado.Enabled = False
                Dtp_FechaEnvio.Enabled = False
                Tx_Descripcion.Enabled = False
                Cu_Aprobada.Enabled = False
                Cu_AsociarPersonaAprobado.Enabled = False
                Tx_NombreTransportador.Enabled = False
                Tx_EmpresaTransporta.Enabled = False
                Tx_CelularTransportador.Enabled = False
                Tx_PlacaVehiculo.Enabled = False
                Bt_BuscarPlaca.Enabled = False
                Tx_Guia.Enabled = False
                Dtp_FechaDespacho.Enabled = False
                Tx_NombreResponsable.Enabled = False
                Pn_Cierre.Enabled = True
            Case 4 'Ver
                Tx_Contratista.ReadOnly = True
                Bt_BuscarDeContratista.Enabled = False
                Tx_DigitoVerificacion.ReadOnly = True
                Tx_NombreContratista.ReadOnly = True
                Tx_Direccion.ReadOnly = True
                Cu_Ciudad.Enabled = False
                Tx_ValorEstimado.ReadOnly = True
                Cb_TipoMoneda.Enabled = False
                Tx_ValorAseguradora.ReadOnly = True
                Cu_Solicitada.Enabled = False
                Cu_AsociarPersonaSolicitado.Enabled = False
                Dtp_FechaEnvio.Enabled = False
                Tx_Descripcion.ReadOnly = True
                Cu_Aprobada.Enabled = False
                Cu_AsociarPersonaAprobado.Enabled = False
                Tx_NombreTransportador.ReadOnly = True
                Tx_EmpresaTransporta.ReadOnly = True
                Tx_CelularTransportador.ReadOnly = True
                Tx_PlacaVehiculo.ReadOnly = True
                Bt_BuscarPlaca.Enabled = False
                Tx_Guia.ReadOnly = True
                Dtp_FechaDespacho.Enabled = False
                Tx_NombreResponsable.ReadOnly = True
                If fila("CERRADA") = "S" Then
                    Pn_Cierre.Enabled = True
                    Cu_Recibido.Enabled = False
                    Dtp_FechaRecibido.Enabled = False
                    Dtp_FechaMantenimientoExt.Enabled = False
                    Tx_ValorCierre.ReadOnly = True
                    Cb_EstadoUsoDespues.Enabled = False
                    Tx_Observacion.ReadOnly = True
                Else
                    Pn_Cierre.Enabled = False
                End If
                Bt_Guardar.Visible = False
        End Select
    End Sub

    Public Sub CargarListaEstados(ByVal Tipo As Integer)
        cmde = New SqlCommand("dbo.GestionarEquipos", conn)
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Parameters.AddWithValue("@accion", If(Tipo = 0, 38, 39)) 'Tipo de mantenimiento, 39: Estado después del mantenimiento
        cmde.Parameters.AddWithValue("@idproveedor", 0)
        cmde.Parameters.AddWithValue("@idarticulo", 0)
        cmde.Parameters.AddWithValue("@idequipo", -1)
        cmde.Parameters.AddWithValue("@idtipo", 0)
        cmde.Parameters.AddWithValue("@idsubtipo", 0)
        cmde.Parameters.AddWithValue("@idestado", 0)
        cmde.Parameters.AddWithValue("@idequipopadre", 0)
        cmde.Parameters.AddWithValue("@idbodegaingreso", 0)
        cmde.Parameters.AddWithValue("@idpersonaingreso", 0)
        cmde.Parameters.AddWithValue("@idpersonaregistro", 0)
        cmde.Parameters.AddWithValue("@idpersonaactual", 0)
        cmde.Parameters.AddWithValue("@idmodelo", 0)
        cmde.Parameters.AddWithValue("@idmarca", 0)
        cmde.Parameters.AddWithValue("@idbodega", 0)
        cmde.Parameters.AddWithValue("@descripcionequipo", "")
        cmde.Parameters.AddWithValue("@codigoismocol", "")
        cmde.Parameters.AddWithValue("@codigoaccess", "")
        cmde.Parameters.AddWithValue("@codigomecanico", "")
        cmde.Parameters.AddWithValue("@activo", 0)
        cmde.Parameters.AddWithValue("@fechaingreso", Date.Now)
        da = New SqlDataAdapter(cmde)
        datas = New DataSet()
        Try
            conn.Open()
            da.Fill(datas)
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        If Tipo = 0 Then 'Tipo de mantenimiento
            Cb_TipoMantenimiento.DataSource = datas.Tables(0)
            Cb_TipoMantenimiento.DisplayMember = "NOMBREESTADO"
            Cb_TipoMantenimiento.ValueMember = "IDESTADOPARAUSO"
        Else
            Cb_EstadoUsoDespues.DataSource = datas.Tables(0)
            Cb_EstadoUsoDespues.DisplayMember = "NOMBREESTADO"
            Cb_EstadoUsoDespues.ValueMember = "IDESTADOPARAUSO"
        End If
    End Sub

    Public Sub Cargar_Contratista()
        Me.Cursor = Cursors.WaitCursor
        Tx_Contratista.Text = Trim(Replace(Replace(Tx_Contratista.Text, ".", ""), ",", ""))
        SC_CONTRATISTATableAdapter.FillIDENTIFICACION(DsOrdenServicio.SC_CONTRATISTA, Tx_Contratista.Text)
        If DsOrdenServicio.SC_CONTRATISTA.Count > 0 Then
            Fila_Contratista = DsOrdenServicio.SC_CONTRATISTA(0)
            Tx_DigitoVerificacion.Text = Trim(Fila_Contratista("Digito Verificación"))
            Tx_NombreContratista.Text = Trim(Fila_Contratista("Nombre"))
            Tx_Direccion.Text = Trim(Fila_Contratista("Dirección"))
            IdContratista = Fila_Contratista("IDCONSTRATISTA")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Fr_EnvioMantenimientoExterno_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Select Case TipoEdicion
            Case 0, 1
                Cb_TipoMantenimiento.Select()
            Case 2
                Cu_Recibido.Cb_Persona.Select()
            Case 4
                Bt_Cancelar.Select()
        End Select
    End Sub


    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        Dim Validar As Boolean
        Select Case TipoEdicion
            Case 0, 1 'Crear, modificar
                Validar = ValidarRegistro()
            Case 2 'Cerrar servicio
                Validar = ValidarCierre()
        End Select
        If Validar = True Then
            cmde = New SqlCommand("dbo.GestionarMantenimientoExterno", conn)
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Parameters.AddWithValue("@accion", TipoEdicion)
            cmde.Parameters.AddWithValue("@IDMANTENIMIENTOEXTERNO", IdMantenimientoModificando)
            cmde.Parameters.AddWithValue("@IDEQUIPO", IdEquipo)
            cmde.Parameters.AddWithValue("@IDESTADOPARAUSOENVIO", Cb_TipoMantenimiento.SelectedValue)
            cmde.Parameters.AddWithValue("@IDCONTRATISTA", IdContratista)
            cmde.Parameters.AddWithValue("@NOMBRE", UCase(Trim(Tx_NombreContratista.Text)))
            cmde.Parameters.AddWithValue("@CODIGOCIUDAD", Cu_Ciudad.Cb_Ciudad.SelectedValue)
            cmde.Parameters.AddWithValue("@FECHAENVIO", Dtp_FechaEnvio.Value)
            cmde.Parameters.AddWithValue("@DIRECCIONENVIO", UCase(Trim(Tx_Direccion.Text)))
            If Trim(Tx_ValorEstimado.Text) = "" Then
                cmde.Parameters.AddWithValue("@VALORESTIMADO", CDec("0,0"))
            Else
                cmde.Parameters.AddWithValue("@VALORESTIMADO", CDec(Trim(Tx_ValorEstimado.Text)))
            End If
            cmde.Parameters.AddWithValue("@CODIGOTIPOMONEDA", Cb_TipoMoneda.SelectedValue)
            cmde.Parameters.AddWithValue("@IDSOLICITADOPOR", Cu_Solicitada.Cb_Persona.SelectedValue)
            cmde.Parameters.AddWithValue("@DESCRIPCION", UCase(Trim(Tx_Descripcion.Text)))
            cmde.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
            cmde.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
            cmde.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
            cmde.Parameters.AddWithValue("@FECHARECIBIDO", Dtp_FechaRecibido.Value)
            Select Case TipoEdicion
                Case 0, 1 'Crear, modificar
                    cmde.Parameters.AddWithValue("@VALORCIERRE", CDec("0,0"))
                    cmde.Parameters.AddWithValue("@IDESTADOPARAUSORECIBIDO", DBNull.Value)
                    cmde.Parameters.AddWithValue("@OBSERVACION", "")
                    cmde.Parameters.AddWithValue("@IDPERSONARECIBE", DBNull.Value)
                    cmde.Parameters.AddWithValue("@FECHAMANTENIMIENTOEXTERNO", DBNull.Value)
                Case 2 'Cerrar servicio
                    cmde.Parameters.AddWithValue("@VALORCIERRE", CDec(Trim(Tx_ValorCierre.Text)))
                    cmde.Parameters.AddWithValue("@IDESTADOPARAUSORECIBIDO", Cb_EstadoUsoDespues.SelectedValue)
                    cmde.Parameters.AddWithValue("@OBSERVACION", UCase(Trim(Tx_Observacion.Text)))
                    cmde.Parameters.AddWithValue("@IDPERSONARECIBE", Cu_Recibido.Cb_Persona.SelectedValue)
                    cmde.Parameters.AddWithValue("@FECHAMANTENIMIENTOEXTERNO", Dtp_FechaMantenimientoExt.Value)
            End Select
            cmde.Parameters.AddWithValue("@IDPERSONACIERRA", VariablesBase.VariablesBase.IdPersona)
            cmde.Parameters.AddWithValue("@IDPERSONAANULA", VariablesBase.VariablesBase.IdPersona)
            cmde.Parameters.AddWithValue("@OBERVACIONANULACION", "")
            If Trim(Tx_ValorAseguradora.Text) = "" Then
                cmde.Parameters.AddWithValue("@VALORASEGURADORA", CDec("0,0"))
            Else
                cmde.Parameters.AddWithValue("@VALORASEGURADORA", CDec(Trim(Tx_ValorAseguradora.Text)))
            End If
            If IsNothing(Cu_Aprobada.Cb_Persona.SelectedValue) Then
                cmde.Parameters.AddWithValue("@IDPERSONAAPRUEBA", DBNull.Value)
            Else
                cmde.Parameters.AddWithValue("@IDPERSONAAPRUEBA", Cu_Aprobada.Cb_Persona.SelectedValue)
            End If
            cmde.Parameters.AddWithValue("@TIPOENVIO", Cb_TipoEnvio.SelectedValue)
            cmde.Parameters.AddWithValue("@FECHADESPACHO", If(Dtp_FechaDespacho.Checked, Dtp_FechaDespacho.Value, DBNull.Value))
            cmde.Parameters.AddWithValue("@TRANSPORTADOR", If(Tx_NombreTransportador.Text <> "", Trim(Tx_NombreTransportador.Text), DBNull.Value))
            cmde.Parameters.AddWithValue("@CELULAR", If(Tx_CelularTransportador.Text <> "", Trim(Tx_CelularTransportador.Text), DBNull.Value))
            cmde.Parameters.AddWithValue("@PLACAVEHICULO", If(Tx_PlacaVehiculo.Text <> "", Trim(Tx_PlacaVehiculo.Text), DBNull.Value))
            cmde.Parameters.AddWithValue("@EMPRESATRANSPORTADORA", If(Tx_EmpresaTransporta.Text <> "", Trim(Tx_EmpresaTransporta.Text), DBNull.Value))
            cmde.Parameters.AddWithValue("@GUIA", If(Tx_Guia.Text <> "", Trim(Tx_Guia.Text), DBNull.Value))
            cmde.Parameters.AddWithValue("@NOMBRERESPONSABLE", If(Tx_NombreResponsable.Text <> "", Trim(Tx_NombreResponsable.Text), DBNull.Value))
            cmde.Parameters.Add(New SqlParameter("@IDMANTENIMIENTOEXTERNONUEVO", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
            Try
                conn.Open()
                cmde.ExecuteNonQuery()
                conn.Close()

                FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "ME", "SOLICITADO", Cu_Solicitada.Cb_Persona.SelectedValue)
                FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "ME", "RECIBIDO", Cu_Recibido.Cb_Persona.SelectedValue)
                FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "ME", "APROBADO", Cu_Aprobada.Cb_Persona.SelectedValue)

                If MsgBox("¿Desea imprimir la Orden de Servicio de revisión externa", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                    Dim FrOpcionesImpresión As New ImpresiónMateriales.Fr_OpcionesImpresión
                    FrOpcionesImpresión.Tipo = 2
                    If TipoEdicion = 0 Then
                        FrOpcionesImpresión.ID = cmde.Parameters("@IDMANTENIMIENTOEXTERNONUEVO").Value
                    Else
                        FrOpcionesImpresión.ID = IdMantenimientoModificando
                    End If

                    FrOpcionesImpresión.Ck_Impresión1.Text = "Copia Destinatario"
                    FrOpcionesImpresión.Ck_Impresión1.Checked = True
                    FrOpcionesImpresión.Ck_Impresión2.Text = "Copia Transportador"
                    FrOpcionesImpresión.Ck_Impresión2.Checked = True
                    FrOpcionesImpresión.Ck_Impresión3.Text = "Copia Consecutivo"
                    FrOpcionesImpresión.Ck_Impresión3.Checked = True
                    FrOpcionesImpresión.Ck_Impresión4.Text = "Copia Portería de Salida"
                    FrOpcionesImpresión.Ck_Impresión4.Checked = True
                    FrOpcionesImpresión.Ck_Impresión5.Visible = False
                    FrOpcionesImpresión.Ck_Impresión5.Checked = False
                    FrOpcionesImpresión.ShowDialog()
                End If
                Me.Close()
            Catch
                MessageBox.Show("Ocurrió un error al guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Private Function ValidarRegistro() As Boolean
        If Cb_TipoMantenimiento.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de mantenimiento externo", MsgBoxStyle.Critical, "Tipo Mantenimiento")
            Cb_TipoMantenimiento.Focus()
            Return False
        End If
        If Tx_Contratista.Text = "" Then
            MsgBox("Debe Agregar un contratista", MsgBoxStyle.Critical, "Identificación Contratista")
            Tx_Contratista.Focus()
            Return False
        End If

        If Tx_Direccion.Text = "" Then
            MsgBox("Agregue la dirección del contratista", MsgBoxStyle.Critical, "Dirección")
            Tx_Descripcion.Focus()
            Return False
        End If
        If Tx_ValorEstimado.Text <> "" Then
            If IsNumeric(Tx_ValorEstimado.Text) = False Then
                MsgBox("El valor del servicio debe ser numérico", MsgBoxStyle.Critical, "Valor Factura")
                Tx_ValorEstimado.Text = ""
                Tx_ValorEstimado.Focus()
                Return False
            End If
        End If

        If Cb_TipoMoneda.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de moneda del servicio", MsgBoxStyle.Critical, "Tipo Moneda")
            Cb_TipoMoneda.Focus()
            Return False
        End If

        If IsNothing(Cu_Solicitada.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione la persona que solicitó", MsgBoxStyle.Critical, "Solicitado por")
            Cu_Solicitada.Cb_Persona.Focus()
            Return False
        End If

        If IsNothing(Cu_Aprobada.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione la persona que aprueba", MsgBoxStyle.Critical, "Aprobado por")
            Cu_Aprobada.Cb_Persona.Focus()
            Return False
        End If

        If Tx_Descripcion.Text = "" Then
            MsgBox("Agregue una descripción", MsgBoxStyle.Critical, "Descripción del Servicio")
            Tx_Descripcion.Focus()
            Return False
        End If

        If Tx_ValorAseguradora.Text <> "" Then
            If IsNumeric(Tx_ValorAseguradora.Text) = False Then
                MsgBox("El valor del equipo para la aseguradora debe ser numérico", MsgBoxStyle.Critical, "Valor para la Aseguradora")
                Tx_ValorAseguradora.Text = ""
                Tx_ValorAseguradora.Focus()
                Return False
            Else
                If CDec(Tx_ValorAseguradora.Text) < 10000 Then
                    MsgBox("El valor del equipo para la aseguradora debe ser mayor a $10,000", MsgBoxStyle.Critical, "Valor para la Aseguradora")
                    Tx_ValorAseguradora.Focus()
                    Return False
                End If
            End If
        End If

        Return True
    End Function


    Private Function ValidarCierre() As Boolean
        If IsNothing(Cu_Recibido.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione la persona que recibió", MsgBoxStyle.Critical, "RECIBIÓ")
            Cu_Recibido.Cb_Persona.Focus()
            Return False
        End If
        If Tx_ValorCierre.Text <> "" Then
            If IsNumeric(Tx_ValorCierre.Text) = False Then
                MsgBox("El valor del cierre del servicio debe ser numérico", MsgBoxStyle.Critical, "Valor Cierre")
                Tx_ValorCierre.Text = ""
                Tx_ValorCierre.Focus()
                Return False
            End If
        Else
            MsgBox("El valor del cierre del servicio debe ser numérico", MsgBoxStyle.Critical, "Valor Cierre")
            Return False
        End If
        If Cb_EstadoUsoDespues.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el estado de uso después del mantenimiento", MsgBoxStyle.Critical, "Estado Uso Después Mantenimiento")
            Cb_EstadoUsoDespues.Focus()
            Return False
        End If
        If Dtp_FechaRecibido.Value < Dtp_FechaEnvio.Value Then
            MsgBox("La fecha de recibido no puedo ser menor a la fecha de envió", MsgBoxStyle.Critical, "Estado Uso Después Mantenimiento")
            Dtp_FechaRecibido.Focus()
            Return False
        End If
        If Dtp_FechaMantenimientoExt.Value < Dtp_FechaEnvio.Value Then
            MsgBox("La fecha de mantenimiento externo no puede ser menor a la fecha de envió", MsgBoxStyle.Critical, "Estado Uso Después Mantenimiento")
            Dtp_FechaRecibido.Focus()
            Return False
        End If

        Return True
    End Function


    ''' <summary>Para cargar al asociar una persona.</summary>
    ''' <param name="IDPERSONA"></param>
    ''' <param name="NOMBRECOMPONENTE"></param>
    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Cu_Solicitada.Cb_Persona.SelectedValue
            Cu_Solicitada.CargarDatos()
            Cu_Solicitada.Cb_Persona.SelectedValue = temp
            Cu_Solicitada.CargarCajaTexto()
        Catch ex As Exception

        End Try
        Try
            temp = Cu_Aprobada.Cb_Persona.SelectedValue
            Cu_Aprobada.CargarDatos()
            Cu_Aprobada.Cb_Persona.SelectedValue = temp
            Cu_Aprobada.CargarCajaTexto()
        Catch ex As Exception

        End Try
        Try
            temp = Cu_Recibido.Cb_Persona.SelectedValue
            Cu_Recibido.CargarDatos()
            Cu_Recibido.Cb_Persona.SelectedValue = temp
            Cu_Recibido.CargarCajaTexto()
        Catch ex As Exception

        End Try
        Select Case NOMBRECOMPONENTE
            Case Cu_Solicitada.Name
                Cu_Solicitada.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_Aprobada.Name
                Cu_Aprobada.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_Recibido.Name
                Cu_Recibido.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Bt_BuscarPlaca_Click(sender As Object, e As EventArgs) Handles Bt_BuscarPlaca.Click
        Dim placa As String = ""
        Dim frBuscarPlaca As New Fr_PlacaVehiculo()
        If frBuscarPlaca.ShowDialog() = DialogResult.OK Then
            placa = frBuscarPlaca.Placa
        End If
        If placa <> "" Then
            Tx_PlacaVehiculo.Text = placa
        End If
    End Sub

End Class 'Fr_EnvioMantenimientoExterno


Class Fr_PlacaVehiculo
    Inherits Form

    ''' <summary>Placa del vehículo seleccionado.</summary>
    Public Placa As String = ""
    Private WithEvents Pn_Busqueda As New Panel
    Private WithEvents Lb_CodigoBusqueda As New Label
    Private WithEvents Lb_PlacaBusqueda As New Label
    Private WithEvents Tx_CodigoBusqueda As New TextBox
    Private WithEvents Tx_PlacaBusqueda As New TextBox
    Private WithEvents Flp_Botones As New FlowLayoutPanel
    Private WithEvents Bt_Aceptar As New Button
    Private WithEvents Bt_Cancelar As New Button
    Private WithEvents Dgv_PlacaVehiculo As New DataGridView
    Private WithEvents Dt_Placas As New DataTable
    Private WithEvents Dv_Filtro As New DataView
    Private WithEvents Tm_Buscar As New Timer

    Public Sub New()
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

        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.AutoSize = True
        Me.AcceptButton = Bt_Aceptar
        Me.CancelButton = Bt_Cancelar
        Me.StartPosition = FormStartPosition.CenterParent
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New Size(400, 600)
        Me.Text = "Elegir Placa de Vehículo"
        Me.Controls.Add(Dgv_PlacaVehiculo)
        Me.Controls.Add(Pn_Busqueda)
        Me.Controls.Add(Flp_Botones)

        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("SELECT * FROM dbo.ListarPlacaVehiculos() ORDER BY CODIGO", conn)
        Dim da As New SqlDataAdapter(Comando)
        Try
            conn.Open()
            da.Fill(Dt_Placas)
            conn.Close()
            Dgv_PlacaVehiculo.DataSource = Dt_Placas
        Catch

        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Tx_CodigoBusqueda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_CodigoBusqueda.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
        Dim regex As New System.Text.RegularExpressions.Regex("[A-Z0-9-]")
        If Not (regex.IsMatch(e.KeyChar) Or e.KeyChar = Convert.ToChar(Keys.Back)) Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tx_PlacaBusqueda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_PlacaBusqueda.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
        Dim regex As New System.Text.RegularExpressions.Regex("[A-Z0-9]")
        If Not (regex.IsMatch(e.KeyChar) Or e.KeyChar = Convert.ToChar(Keys.Back)) Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tx_CodigoBusqueda_TextChanged(sender As Object, e As EventArgs) Handles Tx_CodigoBusqueda.TextChanged
        Tm_Buscar.Stop()
        Tm_Buscar.Interval = VariablesBase.VariablesBase.TiempoRespuestaBuscador * 2
        Tm_Buscar.Start()
    End Sub

    Private Sub Tx_PlacaBusqueda_TextChanged(sender As Object, e As EventArgs) Handles Tx_PlacaBusqueda.TextChanged
        Tm_Buscar.Stop()
        Tm_Buscar.Interval = VariablesBase.VariablesBase.TiempoRespuestaBuscador * 2
        Tm_Buscar.Start()
    End Sub

    Private Sub Tm_Buscar_Tick(sender As Object, e As EventArgs) Handles Tm_Buscar.Tick
        Tm_Buscar.Stop()
        Me.Cursor = Cursors.WaitCursor
        Dim vista As New DataView(Dt_Placas)
        Dgv_PlacaVehiculo.SuspendLayout()
        Dgv_PlacaVehiculo.DataSource = vista
        Dgv_PlacaVehiculo.ResumeLayout()
        vista.RowFilter = String.Format("CODIGO like '%{0}%' and PLACAVEHICULO like '%{1}%'", Tx_CodigoBusqueda.Text, Tx_PlacaBusqueda.Text)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Dgv_PlacaVehiculo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_PlacaVehiculo.CellDoubleClick
        AceptarPlaca()
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        AceptarPlaca()
    End Sub

    Private Sub AceptarPlaca()
        Placa = Dgv_PlacaVehiculo.SelectedRows(0).Cells("PLACAVEHICULO").Value
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        'CargarPlacasVehiculos = Nothing 'Dejar el valor de la placa anterior.
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class 'Fr_PlacaVehiculo